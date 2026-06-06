using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class INVValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // INV - MODULO INVENTARIOS 
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // INVMOVCOMPRASMA: Tabla maestro movimientos compras
        //-------------------------------------------------------
        #region Buscar INVMOVCOMPRASMA: Logica
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TITULO: Tabla maestro movimientos compras</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovcomprasma(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVMOVCOMPRASMA: String
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TITULO: Tabla maestro movimientos compras</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_desreg_inca
        /// (campo 'DE' de la tabla invmovcomprasma) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvmovcomprasma(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desreg_inca;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVMOVCOMPRASMA: Registro
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TITULO: Tabla maestro movimientos compras</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovcomprasma desde la tabla
        /// invmovcomprasma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static EFinvmovcomprasma fobRegBuscarInvmovcomprasma(string tcrCodigo)
        {
            EFinvmovcomprasma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVTIPOREGIMOVI: Tipos registro movimientos inventarios
        //-------------------------------------------------------
        #region Buscar INVTIPOREGIMOVI: Logica
        /// <summary>
        /// <para>TABLA: invtiporegimovi</para>
        /// <para>TITULO: Tipos registro movimientos inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// </para>
        /// </summary>
        public static bool flgBuscarInvtiporegimovi(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporegimovi.FirstOrDefault(p => p.inv_tipmov_intr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVTIPOREGIMOVI: String
        /// <summary>
        /// <para>TABLA: invtiporegimovi</para>
        /// <para>TITULO: Tipos registro movimientos inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_desreg_intr
        /// (campo 'DE' de la tabla invtiporegimovi) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvtiporegimovi(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporegimovi.FirstOrDefault(p => p.inv_tipmov_intr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desreg_intr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVTIPOREGIMOVI: Registro
        /// <summary>
        /// <para>TABLA: invtiporegimovi</para>
        /// <para>TITULO: Tipos registro movimientos inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvtiporegimovi desde la tabla
        /// invtiporegimovi cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// </para>
        /// </summary>
        public static EFinvtiporegimovi fobRegBuscarInvtiporegimovi(string tcrCodigo)
        {
            EFinvtiporegimovi lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporegimovi.FirstOrDefault(p => p.inv_tipmov_intr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVTIPORECOMPRA: Tipos registro movimientos en compra
        //-------------------------------------------------------
        #region Buscar INVTIPORECOMPRA: Logica
        /// <summary>
        /// <para>TABLA: invtiporecompra</para>
        /// <para>TITULO: Tipos registro movimientos en compra</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento compras (manejo interno del modulo):Tabla
        /// maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static bool flgBuscarInvtiporecompra(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporecompra.FirstOrDefault(p => p.inv_tipreg_incx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVTIPORECOMPRA: String
        /// <summary>
        /// <para>TABLA: invtiporecompra</para>
        /// <para>TITULO: Tipos registro movimientos en compra</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_desreg_incx
        /// (campo 'DE' de la tabla invtiporecompra) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento compras (manejo interno del modulo):Tabla
        /// maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvtiporecompra(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporecompra.FirstOrDefault(p => p.inv_tipreg_incx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desreg_incx;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVTIPORECOMPRA: Registro
        /// <summary>
        /// <para>TABLA: invtiporecompra</para>
        /// <para>TITULO: Tipos registro movimientos en compra</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvtiporecompra desde la tabla
        /// invtiporecompra cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro movimiento compras (manejo interno del modulo):Tabla
        /// maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static EFinvtiporecompra fobRegBuscarInvtiporecompra(string tcrCodigo)
        {
            EFinvtiporecompra lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtiporecompra.FirstOrDefault(p => p.inv_tipreg_incx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVTIPOCONCEMOV: Concepto del detalle movimiento diario
        //-------------------------------------------------------
        #region Buscar INVTIPOCONCEMOV: Logica
        /// <summary>
        /// <para>TABLA: invtipoconcemov</para>
        /// <para>TITULO: Concepto del detalle movimiento diario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Concepto movimiento diario:E11= Entradas compras E12= Entrada
        /// Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas
        /// 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24=
        /// Salida entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarInvtipoconcemov(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtipoconcemov.FirstOrDefault(p => p.inv_conmov_incm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVTIPOCONCEMOV: String
        /// <summary>
        /// <para>TABLA: invtipoconcemov</para>
        /// <para>TITULO: Concepto del detalle movimiento diario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_descon_incm
        /// (campo 'DE' de la tabla invtipoconcemov) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Concepto movimiento diario:E11= Entradas compras E12= Entrada
        /// Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas
        /// 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24=
        /// Salida entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvtipoconcemov(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtipoconcemov.FirstOrDefault(p => p.inv_conmov_incm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_descon_incm;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVTIPOCONCEMOV: Registro
        /// <summary>
        /// <para>TABLA: invtipoconcemov</para>
        /// <para>TITULO: Concepto del detalle movimiento diario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvtipoconcemov desde la tabla
        /// invtipoconcemov cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Concepto movimiento diario:E11= Entradas compras E12= Entrada
        /// Traslado interno E13=Entradas por ajustes  S21= Salidas Ventas
        /// 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24=
        /// Salida entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public static EFinvtipoconcemov fobRegBuscarInvtipoconcemov(string tcrCodigo)
        {
            EFinvtipoconcemov lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invtipoconcemov.FirstOrDefault(p => p.inv_conmov_incm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVALMACENMAEST: Tabla Maestro almacenes
        //-------------------------------------------------------
        #region Buscar INVALMACENMAEST: Logica
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TITULO: Tabla Maestro almacenes</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registra todos los almacenes existentes dentro de la empresa
        /// </para>
        /// </summary>
        public static bool flgBuscarInvalmacenmaest(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVALMACENMAEST: String
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TITULO: Tabla Maestro almacenes</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_desalm_inal
        /// (campo 'DE' de la tabla invalmacenmaest) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registra todos los almacenes existentes dentro de la empresa
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvalmacenmaest(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desalm_inal;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVALMACENMAEST: Registro
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TITULO: Tabla Maestro almacenes</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvalmacenmaest desde la tabla
        /// invalmacenmaest cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registra todos los almacenes existentes dentro de la empresa
        /// </para>
        /// </summary>
        public static EFinvalmacenmaest fobRegBuscarInvalmacenmaest(string tcrCodigo)
        {
            EFinvalmacenmaest lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVMAEARTICULOS: Tabla Maestro Artículos
        //-------------------------------------------------------
        #region Buscar INVMAEARTICULOS: Logica
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmaearticulos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVMAEARTICULOS: String
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_nomart_inar
        /// (campo 'DE' de la tabla invmaearticulos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvmaearticulos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_nomart_inar;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVMAEARTICULOS: Registro secuenciales articulos
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmaearticulos desde la tabla
        /// invmaearticulos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static EFinvmaearticulos fobRegBuscarInvmaearticulos(string tcrCodigo)
        {
            EFinvmaearticulos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Invmaearticulos where tmp.inv_secart_inar == tcrCodigo select tmp).ToList();
                //var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tcrCodigo);

                if (lobjRegistro != null && lobjRegistro.Count != 0)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVMAEARTICULOS: Registro por codigo auxiliar
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmaearticulos desde la tabla
        /// invmaearticulos, dado el codigo auxiliar de digitacion, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static EFinvmaearticulos fobRegBuscarInvmaearticulosAux(string tcrCodigo)
        {
            EFinvmaearticulos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Invmaearticulos where tmp.inv_codaux_inar == tcrCodigo select tmp).ToList();

                if (lobjRegistro != null && lobjRegistro.Count != 0)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVMAEARTICULOS: Registro por codigo barras
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmaearticulos desde la tabla
        /// invmaearticulos, dado el codigo auxiliar de digitacion, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static EFinvmaearticulos fobRegBuscarInvmaearticulosBarr(string tcrCodigo)
        {
            EFinvmaearticulos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Invmaearticulos where tmp.inv_codbar_inar == tcrCodigo select tmp).ToList();

                if (lobjRegistro != null && lobjRegistro.Count != 0)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVALMACENESTAN: Tabla Estantes para cada almacen
        //-------------------------------------------------------
        #region Buscar INVALMACENESTAN: Registro Estante y almacen
        /// <summary>
        /// <para>TABLA: invalmacenestan</para>
        /// <para>TITULO: Tabla Estantes para cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO: Devuelve un registro de tipo EFinvalmacenestan dado el codigo del estante y el almacen</para>
        /// <para>al que pertenece, cuando no exite retorna  null.</para>
        /// <para>DESCRIPCION TABLA: Tabla detalles de estantes existentes en cada  almacén</para>
        /// </summary>
        public static EFinvalmacenestan fobRegBuscarInvalmacenestanEx(String tcrCodigoAlmacen, String tcrCodigoEstante)
        {
            EFinvalmacenestan lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenestan.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigoAlmacen && p.inv_codest_ines == tcrCodigoEstante);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVINVENTGRUPOS: Grupos  articulos de inventarios
        //-------------------------------------------------------
        #region Buscar INVINVENTGRUPOS: Logica
        /// <summary>
        /// <para>TABLA: invinventgrupos</para>
        /// <para>TITULO: Grupos  articulos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla grupos de clasificacion articulos de inventario, para
        /// gestion contable y organización
        /// </para>
        /// </summary>
        public static bool flgBuscarInvinventgrupos(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventgrupos.FirstOrDefault(p => p.inv_codgru_ingr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVINVENTGRUPOS: String
        /// <summary>
        /// <para>TABLA: invinventgrupos</para>
        /// <para>TITULO: Grupos  articulos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desgru_ingr
        /// (campo 'DE' de la tabla invinventgrupos) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla grupos de clasificacion articulos de inventario, para
        /// gestion contable y organización
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvinventgrupos(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventgrupos.FirstOrDefault(p => p.inv_codgru_ingr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desgru_ingr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVINVENTGRUPOS: Registro
        /// <summary>
        /// <para>TABLA: invinventgrupos</para>
        /// <para>TITULO: Grupos  articulos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvinventgrupos desde la tabla
        /// invinventgrupos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla grupos de clasificacion articulos de inventario, para
        /// gestion contable y organización
        /// </para>
        /// </summary>
        public static EFinvinventgrupos fobRegBuscarInvinventgrupos(String tcrCodigo)
        {
            EFinvinventgrupos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventgrupos.FirstOrDefault(p => p.inv_codgru_ingr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVINVENTSUBGRU: Subgrupos de inventarios
        //-------------------------------------------------------
        #region Buscar INVINVENTSUBGRU: Logica
        /// <summary>
        /// <para>TABLA: invinventsubgru</para>
        /// <para>TITULO: Subgrupos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla subgrupos contables para gestion de inventarios, gestion
        /// de lotes fechas vencimiento y vida util de articulos o medicamentos
        /// </para>
        /// </summary>
        public static bool flgBuscarInvinventsubgru(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventsubgru.FirstOrDefault(p => p.inv_codsub_insg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVINVENTSUBGRU: String
        /// <summary>
        /// <para>TABLA: invinventsubgru</para>
        /// <para>TITULO: Subgrupos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_dessub_insg
        /// (campo 'DE' de la tabla invinventsubgru) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla subgrupos contables para gestion de inventarios, gestion
        /// de lotes fechas vencimiento y vida util de articulos o medicamentos
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvinventsubgru(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventsubgru.FirstOrDefault(p => p.inv_codsub_insg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_dessub_insg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVINVENTSUBGRU: Registro
        /// <summary>
        /// <para>TABLA: invinventsubgru</para>
        /// <para>TITULO: Subgrupos de inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvinventsubgru desde la tabla
        /// invinventsubgru cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla subgrupos contables para gestion de inventarios, gestion
        /// de lotes fechas vencimiento y vida util de articulos o medicamentos
        /// </para>
        /// </summary>
        public static EFinvinventsubgru fobRegBuscarInvinventsubgru(String tcrCodigo)
        {
            EFinvinventsubgru lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invinventsubgru.FirstOrDefault(p => p.inv_codsub_insg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVMAEARTIMAGEN: Tabla lista de imágenes fotograficas de un articulo
        //-------------------------------------------------------
        #region Buscar INVMAEARTIMAGEN: Logica
        /// <summary>
        /// <para>TABLA: invmaeartimagen</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de un articulo</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de imágenes fotograficas de un articulo
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmaeartimagen(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaeartimagen.FirstOrDefault(p => p.inv_secimg_inaj == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVMAEARTIMAGEN: String
        /// <summary>
        /// <para>TABLA: invmaeartimagen</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de un articulo</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_nomimg_inaj
        /// (campo 'DE' de la tabla invmaeartimagen) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de imágenes fotograficas de un articulo
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvmaeartimagen(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaeartimagen.FirstOrDefault(p => p.inv_secimg_inaj == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_nomimg_inaj;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVMAEARTIMAGEN: Registro
        /// <summary>
        /// <para>TABLA: invmaeartimagen</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de un articulo</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmaeartimagen desde la tabla
        /// invmaeartimagen cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de imágenes fotograficas de un articulo
        /// </para>
        /// </summary>
        public static EFinvmaeartimagen fobRegBuscarInvmaeartimagen(String tcrCodigo)
        {
            EFinvmaeartimagen lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaeartimagen.FirstOrDefault(p => p.inv_secimg_inaj == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVCONTENEDORES: Tabla tipos de contenedores (presentacion articulos)
        //-------------------------------------------------------
        #region Buscar INVCONTENEDORES: Logica
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TITULO: Tabla tipos de contenedores (presentacion articulos)</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes tipos de contenedores conocidos
        /// o presentaciones de un Artículo: Caja Bolsas, Sacos,Bultos,Galones,Docena
        /// s y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvcontenedores(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVCONTENEDORES: String
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TITULO: Tabla tipos de contenedores (presentacion articulos)</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desctn_intc
        /// (campo 'DE' de la tabla invcontenedores) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes tipos de contenedores conocidos
        /// o presentaciones de un Artículo: Caja Bolsas, Sacos,Bultos,Galones,Docena
        /// s y otros.
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvcontenedores(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desctn_intc;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVCONTENEDORES: Registro
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TITULO: Tabla tipos de contenedores (presentacion articulos)</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvcontenedores desde la tabla
        /// invcontenedores cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes tipos de contenedores conocidos
        /// o presentaciones de un Artículo: Caja Bolsas, Sacos,Bultos,Galones,Docena
        /// s y otros.
        /// </para>
        /// </summary>
        public static EFinvcontenedores fobRegBuscarInvcontenedores(String tcrCodigo)
        {
            EFinvcontenedores lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVALMACENESTAN: Tabla Estantes para cada almacen
        //-------------------------------------------------------
        #region Buscar INVALMACENESTAN: Logica
        /// <summary>
        /// <para>TABLA: invalmacenestan</para>
        /// <para>TITULO: Tabla Estantes para cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla detalles de estantes existentes en cada  almacén
        /// </para>
        /// </summary>
        public static bool flgBuscarInvalmacenestan(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenestan.FirstOrDefault(p => p.inv_secest_ines == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVALMACENESTAN: String
        /// <summary>
        /// <para>TABLA: invalmacenestan</para>
        /// <para>TITULO: Tabla Estantes para cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desest_ines
        /// (campo 'DE' de la tabla invalmacenestan) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla detalles de estantes existentes en cada  almacén
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvalmacenestan(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenestan.FirstOrDefault(p => p.inv_secest_ines == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desest_ines;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVALMACENESTAN: Registro codigo unico
        /// <summary>
        /// <para>TABLA: invalmacenestan</para>
        /// <para>TITULO: Tabla Estantes para cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvalmacenestan desde la tabla
        /// invalmacenestan cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla detalles de estantes existentes en cada almacén
        /// </para>
        /// </summary>
        public static EFinvalmacenestan fobRegBuscarInvalmacenestan(String tcrCodigo)
        {
            EFinvalmacenestan lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenestan.FirstOrDefault(p => p.inv_secest_ines == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVALMACENESTAN: Registro codigo del estante y almacen
        /// <summary>
        /// <para>TABLA: invalmacenestan</para>
        /// <para>TITULO: Tabla Estantes para cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvalmacenestan desde la tabla
        /// invalmacenestan cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla detalles de estantes existentes en cada almacén
        /// </para>
        /// </summary>
        public static EFinvalmacenestan fobRegBuscarInvalmacenestan(String tcrCodigoEstante, String tcrCodigoAlmacen)
        {
            EFinvalmacenestan lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenestan.FirstOrDefault(p => p.inv_codest_ines == tcrCodigoEstante && p.inv_codalm_inal == tcrCodigoAlmacen);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVPERIODOMAEST: Maestro gestion periodos inventario
        //-------------------------------------------------------
        #region Buscar INVPERIODOMAEST: Logica
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TITULO: Maestro gestion periodos inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro gestion periodos inventario para control de cierres
        /// y demas
        /// </para>
        /// </summary>
        public static bool flgBuscarInvperiodomaest(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVPERIODOMAEST: String
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TITULO: Maestro gestion periodos inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desper_inpe
        /// (campo 'DE' de la tabla invperiodomaest) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro gestion periodos inventario para control de cierres
        /// y demas
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvperiodomaest(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desper_inpe;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVPERIODOMAEST: Registro
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TITULO: Maestro gestion periodos inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvperiodomaest desde la tabla
        /// invperiodomaest cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro gestion periodos inventario para control de cierres
        /// y demas
        /// </para>
        /// </summary>
        public static EFinvperiodomaest fobRegBuscarInvperiodomaest(String tcrCodigo)
        {
            EFinvperiodomaest lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVPERIODOMAEST: Registro por fecha
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TITULO: Maestro gestion periodos inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvperiodomaest dado un valor fecha desde la tabla
        /// invperiodomaest cuando no exite retorna  null.
        /// </para>
        /// <para>RETORNO: registro que cumple con rango fecha periodo</para>
        /// </summary>
        public static EFinvperiodomaest fobRegBuscarInvperiodomaest(String tcrCodigoAlamacen, DateTime tdaFecha)
        {
            EFinvperiodomaest lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => tdaFecha >= p.inv_fecini_inpe &&
                                                                                tdaFecha <= p.inv_fecfin_inpe &&
                                                                                p.inv_codalm_inal == tcrCodigoAlamacen);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVAJUSTECONCEP: Tabla Conceptos de ajuste inventario 				
        //-------------------------------------------------------
        #region Buscar INVAJUSTECONCEP: Logica
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TITULO: Tabla Concepto de ajuste inventario </para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de concepto de ajuste inventario: 
        /// 01=Por reconteo inventario 02=Aprovechamiento sobrantes 
        /// 03= Reingreso prestamos 04=Deterioro del producto y otros 			
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajusteconcep(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajusteconcep.FirstOrDefault(p => p.inv_conaju_incp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVAJUSTECONCEP: Registro
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TITULO: Concepto de ajuste inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvajusteconcep desde la tabla
        /// invajusteconcep cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///  Lista de concepto de ajuste inventario: 
        ///  01=Por reconteo inventario 02=Aprovechamiento sobrantes
        ///  03= Reingreso prestamos 04=Deterioro del producto y otros 			
        /// </para>
        /// </summary>
        public static EFinvajusteconcep fobRegBuscarInvajusteconcep(String tcrCodigo)
        {
            EFinvajusteconcep lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajusteconcep.FirstOrDefault(p => p.inv_conaju_incp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVRESPONSABLES: Tabla personas responsables				
        //-------------------------------------------------------
        #region Buscar INVRESPONSABLES: Logica
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TITULO: Tabla personas responsables </para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla personas responsables en proceso de gestion en el modulo 
        /// inventarios, persona que solicita pedido para gasto interno de 
        /// la empresa,y otros procesos  			
        /// </para>
        /// </summary>
        public static bool flgBuscarInvresponsables(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVRESPONSABLES: String
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TITULO: Tabla personas responsables</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en inv_nomres_inre
        /// (campo 'DE' de la tabla invresponsables) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla personas responsables en proceso de gestion en el modulo
        /// inventarios, persona que solicita pedido para gasto interno
        /// de la empresa y otros procesos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarInvresponsables(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_nomres_inre;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVRESPONSABLES: Registro
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TITULO: Tabla personas responsables</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvresponsables desde la tabla
        /// invresponsables cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla personas responsables en proceso de gestion en el modulo 
        /// inventarios, persona que solicita pedido para gasto interno de 
        /// la empresa,y otros procesos 			 			
        /// </para>
        /// </summary>
        public static EFinvresponsables fobRegBuscarInvresponsables(String tcrCodigo)
        {
            EFinvresponsables lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVMOVDIARIOSMA: Tabla maestro movimientos diarios inventarios
        //-------------------------------------------------------
        #region Buscar INVMOVDIARIOSMA: Logica
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TITULO: Tabla maestro movimientos diarios inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos diarios inventarios, contiene un
        /// registro maestro según cada tipo registro movimiento del inventario:
        /// (INMA = Maestro de movimientos diarios del inventario) ,traslado
        /// entre almacenes, pedidos para consumo interno y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovdiariosma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVMOVDIARIOSMA: String
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TITULO: Tabla maestro movimientos diarios inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desreg_inma
        /// (campo 'DE' de la tabla invmovdiariosma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos diarios inventarios, contiene un
        /// registro maestro según cada tipo registro movimiento del inventario:
        /// (INMA = Maestro de movimientos diarios del inventario) ,traslado
        /// entre almacenes, pedidos para consumo interno y otros.
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvmovdiariosma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desreg_inma;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVMOVDIARIOSMA: Registro
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TITULO: Tabla maestro movimientos diarios inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosma desde la tabla
        /// invmovdiariosma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos diarios inventarios, contiene un
        /// registro maestro según cada tipo registro movimiento del inventario:
        /// (INMA = Maestro de movimientos diarios del inventario) ,traslado
        /// entre almacenes, pedidos para consumo interno y otros.
        /// </para>
        /// </summary>
        public static EFinvmovdiariosma fobRegBuscarInvmovdiariosma(String tcrCodigo)
        {
            EFinvmovdiariosma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVMOVDIARIOSMD: Tabla Detalle movimientos diarios
        //-------------------------------------------------------
        #region Buscar INVMOVDIARIOSMD: Logica
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovdiariosmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosmd.FirstOrDefault(p => p.inv_secreg_inmd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVMOVDIARIOSMD: Registro
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosmd desde la tabla
        /// invmovdiariosmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static EFinvmovdiariosmd fobRegBuscarInvmovdiariosmd(String tcrCodigo)
        {
            EFinvmovdiariosmd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosmd.FirstOrDefault(p => p.inv_secreg_inmd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVALMACEXISTEN: Tabla Maestro existencias en cada almacen 			
        //-------------------------------------------------------
        #region Buscar INVALMACEXISTEN: Registro Secuencial Articulo Inactivo
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosmd desde la tabla
        /// invmovdiariosmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        //public static ModeloInvAlmacenExistencias fobRegBuscarInvalmacexisten(String tcrCodigoAlmacen, String tcrCodigoArticulo)
        //{
        //    ModeloInvAlmacenExistencias lobReturn = null;
        //    using (_context = new DbAplicacion())
        //    {
        //        var lobjRegistro = from invalmacexisten in _context.Invalmacexisten
        //                           join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
        //                           join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos                                   
        //                           join sisgrupomedidas in _context.Sisgrupomedidas on invalmacexisten.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
        //                           join sisunidadmedida in _context.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
        //                           from inal in tminvalmacenmaest.DefaultIfEmpty()
        //                           from inar in tminvmaearticulos.DefaultIfEmpty()                                  
        //                           from sigr in tmsisgrupomedidas.DefaultIfEmpty()
        //                           from sium in tmsisunidadmedida.DefaultIfEmpty()
        //                           where invalmacexisten.inv_codalm_inal == tcrCodigoAlmacen &&
        //                                 invalmacexisten.inv_secart_inar == tcrCodigoArticulo
        //                           select new ModeloInvAlmacenExistencias
        //                           {
        //                               #region Datos
        //                               Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
        //                               Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
        //                               Inv_secart_inar = invalmacexisten.inv_secart_inar,
        //                               Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
        //                               Inv_codbar_inar = inar.inv_codbar_inar,
        //                               Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
        //                               Sis_codume_sium = invalmacexisten.sis_codume_sium,
        //                               Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
        //                               Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
        //                               Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
        //                               Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
        //                               Inv_codest_ines = invalmacexisten.inv_codest_ines,
        //                               Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
        //                               Inv_estant_ines = invalmacexisten.inv_estant_ines,
        //                               Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
        //                               Inv_desalm_inal = inal.inv_desalm_inal,
        //                               Inv_nomart_inar = inar.inv_nomart_inar,
        //                               Sis_desgme_sigr = sigr.sis_desgme_sigr,
        //                               Sis_desume_sium = sium.sis_desume_sium,
        //                               Inv_codctn_intc = inar.inv_codctn_intc,                             
        //                               #endregion
        //                           };
        //        /*
        //        var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigoAlmacen && p.inv_secart_inar ==  tcrCodigoArticulo);
        //        if (lobjRegistro != null)
        //        {
        //            lobReturn = lobjRegistro;
        //        };
        //        */
        //        if (lobjRegistro != null)
        //        {
        //            lobReturn = lobjRegistro.FirstOrDefault();
        //        };

        //    }
        //    return lobReturn;
        //}
        //#endregion

        #endregion
        #region Buscar INVALMACEXISTEN: Registro Secuencial Articulo
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosmd desde la tabla
        /// invmovdiariosmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static EFinvalmacexisten fobRegBuscarInvalmacexisten(String tcrCodigoAlmacen, String tcrCodigoArticulo)
        {
            EFinvalmacexisten lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigoAlmacen && p.inv_secart_inar == tcrCodigoArticulo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVALMACEXISTEN: Registro Codigo Auxiliar Articulo
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosmd desde la tabla
        /// invmovdiariosmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static EFinvalmacexisten fobRegBuscarInvalmacexistenAux(String tcrCodigoAlmacen, String tcrCodigoArticulo)
        {
            EFinvalmacexisten lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigoAlmacen && p.inv_codaux_inar == tcrCodigoArticulo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar INVALMACEXISTEN: Registro Codigo de Barras Articulo
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvmovdiariosmd desde la tabla
        /// invmovdiariosmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static EFinvalmacexisten fobRegBuscarInvalmacexistenBarra(String tcrCodigoAlmacen, String tcrCodigoArticulo)
        {
            EFinvalmacexisten lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigoAlmacen && p.inv_secart_inar == tcrCodigoArticulo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVAJUSTESMAEMA: Maestro ajustes de inventario
        //-------------------------------------------------------
        #region Buscar INVAJUSTESMAEMA: Logica
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TITULO: Maestro ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo maestro para registrar los ajustes de inventarios
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajustesmaema(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVAJUSTESMAEMA: String
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TITULO: Maestro ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en inv_desaju_inja
        /// (campo 'DE' de la tabla invajustesmaema) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo maestro para registrar los ajustes de inventarios
        /// </para>
        /// </summary>
        public static String fcrDEBuscarInvajustesmaema(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.inv_desaju_inja;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar INVAJUSTESMAEMA: Registro
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TITULO: Maestro ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvajustesmaema desde la tabla
        /// invajustesmaema cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo maestro para registrar los ajustes de inventarios
        /// </para>
        /// </summary>
        public static EFinvajustesmaema fobRegBuscarInvajustesmaema(String tcrCodigo)
        {
            EFinvajustesmaema lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // INVAJUSTESMAEMD: Registros tipo detalles para ajustes de inventario
        //-------------------------------------------------------
        #region Buscar INVAJUSTESMAEMD: Logica
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TITULO: Registros tipo detalles para ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros tipo detalles para archivo maestro INVAJUSTESMAEMA,
        /// ajustes de inventarios
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajustesmaemd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaemd.FirstOrDefault(p => p.inv_secreg_injd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar INVAJUSTESMAEMD: Registro
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TITULO: Registros tipo detalles para ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFinvajustesmaemd desde la tabla
        /// invajustesmaemd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros tipo detalles para archivo maestro INVAJUSTESMAEMA,
        /// ajustes de inventarios
        /// </para>
        /// </summary>
        public static EFinvajustesmaemd fobRegBuscarInvajustesmaemd(String tcrCodigo)
        {
            EFinvajustesmaemd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaemd.FirstOrDefault(p => p.inv_secreg_injd == tcrCodigo);
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



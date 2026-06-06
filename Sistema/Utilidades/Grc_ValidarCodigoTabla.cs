using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;
namespace Sistema.Utilidades
{
    public class GRCValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // GRC - MODULO GESTOR RECURSOS 
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // GRCTIPORECURSOS: Tipo origene recurso
        //-------------------------------------------------------
        #region Buscar GRCTIPORECURSOS: Logica
        /// <summary>
        /// <para>TABLA: grctiporecursos</para>
        /// <para>TITULO: Tipo origene recurso</para>
        /// <para>MODULO: GRC</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo origene recurso según el sistema que lo ejecuta o donde
        /// se crea, ejemplo: los tipos DOC vienen de Microsoft Word, XLS
        /// Vienen de Microsoft Excel
        /// </para>
        /// </summary>
        public static bool flgBuscarGrctiporecursos(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grctiporecursos.FirstOrDefault(p => p.grc_tiprec_grtr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar GRCTIPORECURSOS: String
        /// <summary>
        /// <para>TABLA: grctiporecursos</para>
        /// <para>TITULO: Tipo origene recurso</para>
        /// <para>MODULO: GRC</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en grc_titulo_grtr
        /// (campo 'DE' de la tabla grctiporecursos) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo origene recurso según el sistema que lo ejecuta o donde
        /// se crea, ejemplo: los tipos DOC vienen de Microsoft Word, XLS
        /// Vienen de Microsoft Excel
        /// </para>
        /// </summary>
        public static String fcrDEBuscarGrctiporecursos(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grctiporecursos.FirstOrDefault(p => p.grc_tiprec_grtr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.grc_titulo_grtr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar GRCTIPORECURSOS: Registro
        /// <summary>
        /// <para>TABLA: grctiporecursos</para>
        /// <para>TITULO: Tipo origene recurso</para>
        /// <para>MODULO: GRC</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFgrctiporecursos desde la tabla
        /// grctiporecursos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo origene recurso según el sistema que lo ejecuta o donde
        /// se crea, ejemplo: los tipos DOC vienen de Microsoft Word, XLS
        /// Vienen de Microsoft Excel
        /// </para>
        /// </summary>
        public static EFgrctiporecursos fobRegBuscarGrctiporecursos(String tcrCodigo)
        {
            EFgrctiporecursos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grctiporecursos.FirstOrDefault(p => p.grc_tiprec_grtr == tcrCodigo);
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

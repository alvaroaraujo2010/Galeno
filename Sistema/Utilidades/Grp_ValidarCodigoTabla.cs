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
    public class GRPValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // GRP - MODULO GESTOR FORMATOS H.CLINICAS Y FORMATOS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // GRPMAEVERSPLANT: Maestro versiones de plantillas
        //-------------------------------------------------------
        #region Buscar GRPMAEVERSPLANT: Logica
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TITULO: Maestro versiones de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de las diferentes versiones de  plantillas diseñadas
        /// en el gestor, por cada modelo de plantilla solo una estara
        /// en uso a la vez
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpmaeversplant(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar GRPMAEVERSPLANT: String
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TITULO: Maestro versiones de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla grpmaeversplant) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de las diferentes versiones de  plantillas diseñadas
        /// en el gestor, por cada modelo de plantilla solo una estara
        /// en uso a la vez
        /// </para>
        /// </summary>
        public static string fcrDEBuscarGrpmaeversplant(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.grp_idepla_grpv;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar GRPMAEVERSPLANT: Registro
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TITULO: Maestro versiones de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFgrpmaeversplant desde la tabla
        /// grpmaeversplant cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de las diferentes versiones de  plantillas diseñadas
        /// en el gestor, por cada modelo de plantilla solo una estara
        /// en uso a la vez
        /// </para>
        /// </summary>
        public static EFgrpmaeversplant fobRegBuscarGrpmaeversplant(string tcrCodigo)
        {
            EFgrpmaeversplant lobReturn = new EFgrpmaeversplant();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // GRPFORMATOPLANT: Lista de formatos basicos para nueva plantilla
        //-------------------------------------------------------
        #region Buscar GRPFORMATOPLANT: Logica
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TITULO: Lista de formatos basicos para nueva plantilla</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// listado de formatos basicos utlizados al momento de crea una
        /// nueva plantilla
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpformatoplant(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar GRPFORMATOPLANT: String
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TITULO: Lista de formatos basicos para nueva plantilla</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en grp_desfor_grfp
        /// (campo 'DE' de la tabla grpformatoplant) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// listado de formatos basicos utlizados al momento de crea una
        /// nueva plantilla
        /// </para>
        /// </summary>
        public static string fcrDEBuscarGrpformatoplant(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.grp_desfor_grfp;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar GRPFORMATOPLANT: Registro
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TITULO: Lista de formatos basicos para nueva plantilla</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFgrpformatoplant desde la tabla
        /// grpformatoplant cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// listado de formatos basicos utlizados al momento de crea una
        /// nueva plantilla
        /// </para>
        /// </summary>
        public static EFgrpformatoplant fobRegBuscarGrpformatoplant(string tcrCodigo)
        {
            EFgrpformatoplant lobReturn = new EFgrpformatoplant();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // GRPMAEPLANTILLA: Maestro de plantillas
        //-------------------------------------------------------
        #region Buscar GRPMAEPLANTILLA: Logica
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TITULO: Maestro de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas diseñadas en el gestor, para diferentes
        /// propositos: Gestion de Historias clinicas, Reportes  y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpmaeplantilla(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar GRPMAEPLANTILLA: String
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TITULO: Maestro de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en grp_despla_grpl
        /// (campo 'DE' de la tabla grpmaeplantilla) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas diseñadas en el gestor, para diferentes
        /// propositos: Gestion de Historias clinicas, Reportes  y otros.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarGrpmaeplantilla(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.grp_despla_grpl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar GRPMAEPLANTILLA: Registro
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TITULO: Maestro de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFgrpmaeplantilla desde la tabla
        /// grpmaeplantilla cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas diseñadas en el gestor, para diferentes
        /// propositos: Gestion de Historias clinicas, Reportes  y otros.
        /// </para>
        /// </summary>
        public static EFgrpmaeplantilla fobRegBuscarGrpmaeplantilla(string tcrCodigo)
        {
            EFgrpmaeplantilla lobReturn = new EFgrpmaeplantilla();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // GRPGRUPOPLANTIL: Grupos  de plantillas
        //-------------------------------------------------------
        #region Buscar GRPGRUPOPLANTIL: Logica
        /// <summary>
        /// <para>TABLA: grpgrupoplantil</para>
        /// <para>TITULO: Grupos  de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de plantillas ejemplo: FR001 = Formato para Gestion
        /// Rips Atencion consulta FR002 = Ficha Mujer Gestante  y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpgrupoplantil(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpgrupoplantil.FirstOrDefault(p => p.grp_idegru_grpg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar GRPGRUPOPLANTIL: String
        /// <summary>
        /// <para>TABLA: grpgrupoplantil</para>
        /// <para>TITULO: Grupos  de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en grp_desgru_grpg
        /// (campo 'DE' de la tabla grpgrupoplantil) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de plantillas ejemplo: FR001 = Formato para Gestion
        /// Rips Atencion consulta FR002 = Ficha Mujer Gestante  y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarGrpgrupoplantil(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpgrupoplantil.FirstOrDefault(p => p.grp_idegru_grpg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.grp_desgru_grpg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar GRPGRUPOPLANTIL: Registro
        /// <summary>
        /// <para>TABLA: grpgrupoplantil</para>
        /// <para>TITULO: Grupos  de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFgrpgrupoplantil desde la tabla
        /// grpgrupoplantil cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de plantillas ejemplo: FR001 = Formato para Gestion
        /// Rips Atencion consulta FR002 = Ficha Mujer Gestante  y otros
        /// </para>
        /// </summary>
        public static EFgrpgrupoplantil fobRegBuscarGrpgrupoplantil(string tcrCodigo)
        {
            EFgrpgrupoplantil lobReturn = new EFgrpgrupoplantil();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpgrupoplantil.FirstOrDefault(p => p.grp_idegru_grpg == tcrCodigo);
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

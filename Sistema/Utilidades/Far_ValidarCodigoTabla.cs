using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;
namespace Sistema.Utilidades
{
    public class FARValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // FAR - MODULO FARMACIA
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // FARGRUFARMACOMA: Grupo farmacologico del medicamento
        //-------------------------------------------------------
        #region Buscar FARGRUFARMACOMA: Logica
        /// <summary>
        /// <para>TABLA: fargrufarmacoma</para>
        /// <para>TITULO: Grupo farmacologico del medicamento</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo farmacologico del medicamento cuando el articulo es un
        /// medicamento
        /// </para>
        /// </summary>
        public static bool flgBuscarFargrufarmacoma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacoma.FirstOrDefault(p => p.far_grufar_fagf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARGRUFARMACOMA: String
        /// <summary>
        /// <para>TABLA: fargrufarmacoma</para>
        /// <para>TITULO: Grupo farmacologico del medicamento</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desgru_fagf
        /// (campo 'DE' de la tabla fargrufarmacoma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo farmacologico del medicamento cuando el articulo es un
        /// medicamento
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFargrufarmacoma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacoma.FirstOrDefault(p => p.far_grufar_fagf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desgru_fagf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARGRUFARMACOMA: Registro
        /// <summary>
        /// <para>TABLA: fargrufarmacoma</para>
        /// <para>TITULO: Grupo farmacologico del medicamento</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfargrufarmacoma desde la tabla
        /// fargrufarmacoma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo farmacologico del medicamento cuando el articulo es un
        /// medicamento
        /// </para>
        /// </summary>
        public static EFfargrufarmacoma fobRegBuscarFargrufarmacoma(String tcrCodigo)
        {
            EFfargrufarmacoma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacoma.FirstOrDefault(p => p.far_grufar_fagf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARGRUFARMACOMD: Subgrupo farmacologico del medicamento (detalles)
        //-------------------------------------------------------
        #region Buscar FARGRUFARMACOMD: Logica
        /// <summary>
        /// <para>TABLA: fargrufarmacomd</para>
        /// <para>TITULO: Subgrupo farmacologico del medicamento (detalles)</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla detalles o subgrupo farmacologico del medicamento cuando
        /// el articulo es un medicamento, según el ATC internacional
        /// </para>
        /// </summary>
        public static bool flgBuscarFargrufarmacomd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacomd.FirstOrDefault(p => p.far_sugfar_fasg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARGRUFARMACOMD: String
        /// <summary>
        /// <para>TABLA: fargrufarmacomd</para>
        /// <para>TITULO: Subgrupo farmacologico del medicamento (detalles)</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desgru_fasg
        /// (campo 'DE' de la tabla fargrufarmacomd) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla detalles o subgrupo farmacologico del medicamento cuando
        /// el articulo es un medicamento, según el ATC internacional
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFargrufarmacomd(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacomd.FirstOrDefault(p => p.far_sugfar_fasg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desgru_fasg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARGRUFARMACOMD: Registro
        /// <summary>
        /// <para>TABLA: fargrufarmacomd</para>
        /// <para>TITULO: Subgrupo farmacologico del medicamento (detalles)</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfargrufarmacomd desde la tabla
        /// fargrufarmacomd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla detalles o subgrupo farmacologico del medicamento cuando
        /// el articulo es un medicamento, según el ATC internacional
        /// </para>
        /// </summary>
        public static EFfargrufarmacomd fobRegBuscarFargrufarmacomd(String tcrCodigo)
        {
            EFfargrufarmacomd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fargrufarmacomd.FirstOrDefault(p => p.far_sugfar_fasg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARMOVMEDICAMMA: Maestro entrega formulas y medicamentos intrahospitalarios
        //-------------------------------------------------------
        #region Buscar FARMOVMEDICAMMA: Logica
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TITULO: Maestro entrega formulas y medicamentos intrahospitalarios</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro movimientos entrega desde Almacen/Farmacia,
        /// de los medicamentos dados en Planes de manejo interno/consumo
        /// y externo (ordenes servicios y/o formulas receta medicas)
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmovmedicamma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARMOVMEDICAMMA: String
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TITULO: Maestro entrega formulas y medicamentos intrahospitalarios</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_observ_fams
        /// (campo 'DE' de la tabla farmovmedicamma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro movimientos entrega desde Almacen/Farmacia,
        /// de los medicamentos dados en Planes de manejo interno/consumo
        /// y externo (ordenes servicios y/o formulas receta medicas)
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarmovmedicamma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_observ_fams;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARMOVMEDICAMMA: Registro
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TITULO: Maestro entrega formulas y medicamentos intrahospitalarios</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmovmedicamma desde la tabla
        /// farmovmedicamma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro movimientos entrega desde Almacen/Farmacia,
        /// de los medicamentos dados en Planes de manejo interno/consumo
        /// y externo (ordenes servicios y/o formulas receta medicas)
        /// </para>
        /// </summary>
        public static EFfarmovmedicamma fobRegBuscarFarmovmedicamma(String tcrCodigo)
        {
            EFfarmovmedicamma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARMOVMEDICAMMD: Maestro detalles entrega formulas y medicamentos intrahospit
        //-------------------------------------------------------
        #region Buscar FARMOVMEDICAMMD: Logica
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TITULO: Maestro detalles entrega formulas y medicamentos intrahospit</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para detalles suministro de mdicamentos desde Almacen/Farmacia
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmovmedicammd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicammd.FirstOrDefault(p => p.far_nroreg_fads == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion      
        #region Buscar FARMOVMEDICAMMD: Registro
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TITULO: Maestro detalles entrega formulas y medicamentos intrahospit</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmovmedicammd desde la tabla
        /// farmovmedicammd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para detalles suministro de mdicamentos desde Almacen/Farmacia
        /// </para>
        /// </summary>
        public static EFfarmovmedicammd fobRegBuscarFarmovmedicammd(String tcrCodigo)
        {
            EFfarmovmedicammd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicammd.FirstOrDefault(p => p.far_nroreg_fads == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FAREXPEDMEDICMA: Maestro expediente registro medicamentos INVIMA
        //-------------------------------------------------------
        #region Buscar FAREXPEDMEDICMA: Logica
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TITULO: Maestro expediente registro medicamentos INVIMA</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro expediente medicamentos INVIMA con registro Codigo
        /// Expediente codigo ATC (principio activo) y laboratorios
        /// </para>
        /// </summary>
        public static bool flgBuscarFarexpedmedicma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FAREXPEDMEDICMA: String
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TITULO: Maestro expediente registro medicamentos INVIMA</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desexp_fama
        /// (campo 'DE' de la tabla farexpedmedicma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro expediente medicamentos INVIMA con registro Codigo
        /// Expediente codigo ATC (principio activo) y laboratorios
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarexpedmedicma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desexp_fama;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FAREXPEDMEDICMA: Registro
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TITULO: Maestro expediente registro medicamentos INVIMA</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarexpedmedicma desde la tabla
        /// farexpedmedicma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro expediente medicamentos INVIMA con registro Codigo
        /// Expediente codigo ATC (principio activo) y laboratorios
        /// </para>
        /// </summary>
        public static EFfarexpedmedicma fobRegBuscarFarexpedmedicma(String tcrCodigo)
        {
            EFfarexpedmedicma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FAREXPEDMEDICMD: Detalles expediente medicamentos INVIMA según concentracion 
        //-------------------------------------------------------
        #region Buscar FAREXPEDMEDICMD: Logica
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TITULO: Detalles expediente medicamentos INVIMA según concentracion </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles medicamentos INVIMA según detallados según concentracion
        /// presentacion y expediente para los diferentes laboratorios
        /// </para>
        /// </summary>
        public static bool flgBuscarFarexpedmedicmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FAREXPEDMEDICMD: String
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TITULO: Detalles expediente medicamentos INVIMA según concentracion </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_precom_famd
        /// (campo 'DE' de la tabla farexpedmedicmd) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles medicamentos INVIMA según detallados según concentracion
        /// presentacion y expediente para los diferentes laboratorios
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarexpedmedicmd(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_precom_famd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FAREXPEDMEDICMD: Registro
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TITULO: Detalles expediente medicamentos INVIMA según concentracion </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarexpedmedicmd desde la tabla
        /// farexpedmedicmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles medicamentos INVIMA según detallados según concentracion
        /// presentacion y expediente para los diferentes laboratorios
        /// </para>
        /// </summary>
        public static EFfarexpedmedicmd fobRegBuscarFarexpedmedicmd(String tcrCodigo)
        {
            EFfarexpedmedicmd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FAREXPEDMEDICMD: Registro
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TITULO: Detalles expediente medicamentos INVIMA según concentracion </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarexpedmedicmd con la descripcion concatenada del expediente y la presentacion CUM </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles medicamentos INVIMA según detallados según concentracion
        /// presentacion y expediente para los diferentes laboratorios
        /// </para>
        /// </summary>
        public static EFfarexpedmedicmd fobRegBuscarFarexpedmedicmdCUM(String tcrCodigoCum)
        {
            EFfarexpedmedicmd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                #region Busqueda por filtro
                var lobQuery = (from tme in _context.Farexpedmedicmd
                               join farexpedmedicma in _context.Farexpedmedicma on tme.far_expedi_fama equals farexpedmedicma.far_expedi_fama into tmfarexpedmedicma
                               from tma in tmfarexpedmedicma.DefaultIfEmpty()
                               where tme.far_codcum_famd == tcrCodigoCum
                               select new 
                               {
                                   far_secreg_famd = tme.far_secreg_famd,
                                   far_expedi_fama = tme.far_expedi_fama,
                                   far_concum_famd = tme.far_concum_famd,
                                   far_codcum_famd = tme.far_codcum_famd,
                                   far_cancum_famd = tme.far_cancum_famd,
                                   far_precom_famd = tme.far_precom_famd,
                                   far_secimg_faim = tme.far_secimg_faim,
                                   far_fecact_famd = tme.far_fecact_famd,
                                   far_fecina_famd = tme.far_fecina_famd,
                                   far_gencom_famd = tme.far_gencom_famd,
                                   far_estreg_famd = tme.far_estreg_famd,
                                   far_desexp_fama = tma.far_desexp_fama,
                               }).FirstOrDefault();
                #endregion
                if (lobQuery != null)
                {
                    lobReturn = new EFfarexpedmedicmd();

                    lobReturn.far_secreg_famd = lobQuery.far_secreg_famd;
                    lobReturn.far_expedi_fama = lobQuery.far_expedi_fama;
                    lobReturn.far_concum_famd = lobQuery.far_concum_famd;
                    lobReturn.far_codcum_famd = lobQuery.far_codcum_famd;
                    lobReturn.far_cancum_famd = lobQuery.far_cancum_famd;
                    lobReturn.far_precom_famd = lobQuery.far_desexp_fama.Trim() + " - " + lobQuery.far_precom_famd;
                    lobReturn.far_secimg_faim = lobQuery.far_secimg_faim;
                    lobReturn.far_fecact_famd = lobQuery.far_fecact_famd;
                    lobReturn.far_fecina_famd = lobQuery.far_fecina_famd;
                    lobReturn.far_gencom_famd = lobQuery.far_gencom_famd;
                    lobReturn.far_estreg_famd = lobQuery.far_estreg_famd;


                }
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARLABORATORIOS: Tabla lista de laboratorios que fabrican o comercializan med
        //-------------------------------------------------------
        #region Buscar FARLABORATORIOS: Logica
        /// <summary>
        /// <para>TABLA: farlaboratorios</para>
        /// <para>TITULO: Tabla lista de laboratorios que fabrican o comercializan med</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla lista laboratorios o empresas que fabrican o comercializan
        /// medicamentos en colombia
        /// </para>
        /// </summary>
        public static bool flgBuscarFarlaboratorios(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farlaboratorios.FirstOrDefault(p => p.far_codlab_falb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARLABORATORIOS: String
        /// <summary>
        /// <para>TABLA: farlaboratorios</para>
        /// <para>TITULO: Tabla lista de laboratorios que fabrican o comercializan med</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_deslab_falb
        /// (campo 'DE' de la tabla farlaboratorios) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla lista laboratorios o empresas que fabrican o comercializan
        /// medicamentos en colombia
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarlaboratorios(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farlaboratorios.FirstOrDefault(p => p.far_codlab_falb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_deslab_falb;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARLABORATORIOS: Registro
        /// <summary>
        /// <para>TABLA: farlaboratorios</para>
        /// <para>TITULO: Tabla lista de laboratorios que fabrican o comercializan med</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarlaboratorios desde la tabla
        /// farlaboratorios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla lista laboratorios o empresas que fabrican o comercializan
        /// medicamentos en colombia
        /// </para>
        /// </summary>
        public static EFfarlaboratorios fobRegBuscarFarlaboratorios(String tcrCodigo)
        {
            EFfarlaboratorios lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farlaboratorios.FirstOrDefault(p => p.far_codlab_falb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARMAECLASIFATC: Tabla clasificacion ATC indice de sustancias farmacológicas 
        //-------------------------------------------------------
        #region Buscar FARMAECLASIFATC: Logica
        /// <summary>
        /// <para>TABLA: farmaeclasifatc</para>
        /// <para>TITULO: Tabla clasificacion ATC indice de sustancias farmacológicas </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion ATC indice de sustancias farmacológicas y medicamentos,
        /// organizados según grupos terapéuticos.
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmaeclasifatc(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmaeclasifatc.FirstOrDefault(p => p.far_codatc_fatc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARMAECLASIFATC: String
        /// <summary>
        /// <para>TABLA: farmaeclasifatc</para>
        /// <para>TITULO: Tabla clasificacion ATC indice de sustancias farmacológicas </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desatc_fatc
        /// (campo 'DE' de la tabla farmaeclasifatc) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion ATC indice de sustancias farmacológicas y medicamentos,
        /// organizados según grupos terapéuticos.
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarmaeclasifatc(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmaeclasifatc.FirstOrDefault(p => p.far_codatc_fatc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desatc_fatc;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARMAECLASIFATC: Registro
        /// <summary>
        /// <para>TABLA: farmaeclasifatc</para>
        /// <para>TITULO: Tabla clasificacion ATC indice de sustancias farmacológicas </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmaeclasifatc desde la tabla
        /// farmaeclasifatc cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion ATC indice de sustancias farmacológicas y medicamentos,
        /// organizados según grupos terapéuticos.
        /// </para>
        /// </summary>
        public static EFfarmaeclasifatc fobRegBuscarFarmaeclasifatc(String tcrCodigo)
        {
            EFfarmaeclasifatc lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmaeclasifatc.FirstOrDefault(p => p.far_codatc_fatc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARMEDICAMIMAGE: Tabla lista de imágenes fotograficas de medicamentos
        //-------------------------------------------------------
        #region Buscar FARMEDICAMIMAGE: Logica
        /// <summary>
        /// <para>TABLA: farmedicamimage</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes fotograficas relacionadas con un medicamento
        /// y según presentacion codigo CUM
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmedicamimage(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamimage.FirstOrDefault(p => p.far_secimg_faim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARMEDICAMIMAGE: String
        /// <summary>
        /// <para>TABLA: farmedicamimage</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_nomimg_faim
        /// (campo 'DE' de la tabla farmedicamimage) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes fotograficas relacionadas con un medicamento
        /// y según presentacion codigo CUM
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarmedicamimage(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamimage.FirstOrDefault(p => p.far_secimg_faim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_nomimg_faim;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARMEDICAMIMAGE: Registro
        /// <summary>
        /// <para>TABLA: farmedicamimage</para>
        /// <para>TITULO: Tabla lista de imágenes fotograficas de medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmedicamimage desde la tabla
        /// farmedicamimage cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes fotograficas relacionadas con un medicamento
        /// y según presentacion codigo CUM
        /// </para>
        /// </summary>
        public static EFfarmedicamimage fobRegBuscarFarmedicamimage(String tcrCodigo)
        {
            EFfarmedicamimage lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamimage.FirstOrDefault(p => p.far_secimg_faim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion    
        //-------------------------------------------------------
        // FARMEDICAMVIADM: Tabla vias de administracion medicamentos
        //-------------------------------------------------------
        #region Buscar FARMEDICAMVIADM: Logica
        /// <summary>
        /// <para>TABLA: farmedicamviadm</para>
        /// <para>TITULO: Tabla vias de administracion medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla clasificacion vias de administracion medicamentos
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmedicamviadm(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamviadm.FirstOrDefault(p => p.far_viaadm_fava == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARMEDICAMVIADM: String
        /// <summary>
        /// <para>TABLA: farmedicamviadm</para>
        /// <para>TITULO: Tabla vias de administracion medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desvia_fava
        /// (campo 'DE' de la tabla farmedicamviadm) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla clasificacion vias de administracion medicamentos
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarmedicamviadm(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamviadm.FirstOrDefault(p => p.far_viaadm_fava == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desvia_fava;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARMEDICAMVIADM: Registro
        /// <summary>
        /// <para>TABLA: farmedicamviadm</para>
        /// <para>TITULO: Tabla vias de administracion medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmedicamviadm desde la tabla
        /// farmedicamviadm cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla clasificacion vias de administracion medicamentos
        /// </para>
        /// </summary>
        public static EFfarmedicamviadm fobRegBuscarFarmedicamviadm(String tcrCodigo)
        {
            EFfarmedicamviadm lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmedicamviadm.FirstOrDefault(p => p.far_viaadm_fava == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARMODALICOMERC: Tabla Modalidad de venta comercial
        //-------------------------------------------------------
        #region Buscar FARMODALICOMERC: Logica
        /// <summary>
        /// <para>TABLA: farmodalicomerc</para>
        /// <para>TITULO: Tabla Modalidad de venta comercial</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Modalidad de venta comercial ralizada por el fabricante o quien
        /// realiza actividad de distribucion
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmodalicomerc(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmodalicomerc.FirstOrDefault(p => p.far_modcom_famc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARMODALICOMERC: String
        /// <summary>
        /// <para>TABLA: farmodalicomerc</para>
        /// <para>TITULO: Tabla Modalidad de venta comercial</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desmod_famc
        /// (campo 'DE' de la tabla farmodalicomerc) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Modalidad de venta comercial ralizada por el fabricante o quien
        /// realiza actividad de distribucion
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarmodalicomerc(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmodalicomerc.FirstOrDefault(p => p.far_modcom_famc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desmod_famc;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARMODALICOMERC: Registro
        /// <summary>
        /// <para>TABLA: farmodalicomerc</para>
        /// <para>TITULO: Tabla Modalidad de venta comercial</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarmodalicomerc desde la tabla
        /// farmodalicomerc cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Modalidad de venta comercial ralizada por el fabricante o quien
        /// realiza actividad de distribucion
        /// </para>
        /// </summary>
        public static EFfarmodalicomerc fobRegBuscarFarmodalicomerc(String tcrCodigo)
        {
            EFfarmodalicomerc lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmodalicomerc.FirstOrDefault(p => p.far_modcom_famc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FARUNIDADMEDIDA: Tabla clasificacion undad medida para medicamentos
        //-------------------------------------------------------
        #region Buscar FARUNIDADMEDIDA: Logica
        /// <summary>
        /// <para>TABLA: farunidadmedida</para>
        /// <para>TITULO: Tabla clasificacion undad medida para medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla clasificacion undad medida para medicamentos, en tabla
        /// maestra de expedientes
        /// </para>
        /// </summary>
        public static bool flgBuscarFarunidadmedida(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farunidadmedida.FirstOrDefault(p => p.far_unimed_faum == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FARUNIDADMEDIDA: String
        /// <summary>
        /// <para>TABLA: farunidadmedida</para>
        /// <para>TITULO: Tabla clasificacion undad medida para medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en far_desmed_faum
        /// (campo 'DE' de la tabla farunidadmedida) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla clasificacion undad medida para medicamentos, en tabla
        /// maestra de expedientes
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFarunidadmedida(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farunidadmedida.FirstOrDefault(p => p.far_unimed_faum == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.far_desmed_faum;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FARUNIDADMEDIDA: Registro
        /// <summary>
        /// <para>TABLA: farunidadmedida</para>
        /// <para>TITULO: Tabla clasificacion undad medida para medicamentos</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfarunidadmedida desde la tabla
        /// farunidadmedida cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla clasificacion undad medida para medicamentos, en tabla
        /// maestra de expedientes
        /// </para>
        /// </summary>
        public static EFfarunidadmedida fobRegBuscarFarunidadmedida(String tcrCodigo)
        {
            EFfarunidadmedida lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farunidadmedida.FirstOrDefault(p => p.far_unimed_faum == tcrCodigo);
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

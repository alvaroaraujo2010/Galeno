using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SISValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // SIS - CONFIGURACION SISTEMA
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // SISESTADOREGIST: Estados de registros (Activos o Inactivos)
        //-------------------------------------------------------
        #region Buscar SISESTADOREGIST: Logica
        /// <summary>
        /// <para>TABLA: sisestadoregist</para>
        /// <para>TITULO: Estados de registros (Activos o Inactivos)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de registros en modulos para:  Registros de Atencion
        /// medica, Historias clinicas, Citas medicas, Contabilidad, Cartera,
        /// Servicios Prestados y otros, los estados son: 1= Activo 2=
        /// Inactivo
        /// </para>
        /// </summary>
        public static bool flgBuscarSisestadoregist(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoregist.FirstOrDefault(p => p.sis_estreg_esrg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISESTADOREGIST: String
        /// <summary>
        /// <para>TABLA: sisestadoregist</para>
        /// <para>TITULO: Estados de registros (Activos o Inactivos)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desest_esrg
        /// (campo 'DE' de la tabla sisestadoregist) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de registros en modulos para:  Registros de Atencion
        /// medica, Historias clinicas, Citas medicas, Contabilidad, Cartera,
        /// Servicios Prestados y otros, los estados son: 1= Activo 2=
        /// Inactivo
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisestadoregist(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoregist.FirstOrDefault(p => p.sis_estreg_esrg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desest_esrg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISESTADOREGIST: Registro
        /// <summary>
        /// <para>TABLA: sisestadoregist</para>
        /// <para>TITULO: Estados de registros (Activos o Inactivos)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisestadoregist desde la tabla
        /// sisestadoregist cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de registros en modulos para:  Registros de Atencion
        /// medica, Historias clinicas, Citas medicas, Contabilidad, Cartera,
        /// Servicios Prestados y otros, los estados son: 1= Activo 2=
        /// Inactivo
        /// </para>
        /// </summary>
        public static EFsisestadoregist fobRegBuscarSisestadoregist(string tcrCodigo)
        {
            EFsisestadoregist lobReturn = new EFsisestadoregist();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoregist.FirstOrDefault(p => p.sis_estreg_esrg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISUNIDADMEDIDA: Tabla Unidades de Medidas
        //-------------------------------------------------------
        #region Buscar SISUNIDADMEDIDA: Tabla Unidades de Medidas
        /// <summary>
        /// <para>TABLA: sisunidadmedida</para>
        /// <para>TITULO: Tabla Unidades de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes unidades de medidas. ejemplo:
        /// Litros, Centilitros, Mililitros etc.
        /// </para>
        /// </summary>
        public static bool flgBuscarSisunidadmedida(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisunidadmedida.FirstOrDefault(p => p.sis_codume_sium == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISUNIDADMEDIDA: Tabla Unidades de Medidas
        /// <summary>
        /// <para>TABLA: sisunidadmedida</para>
        /// <para>TITULO: Tabla Unidades de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desume_unme
        /// (campo 'DE' de la tabla sisunidadmedida) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes unidades de medidas. ejemplo:
        /// Litros, Centilitros, Mililitros etc.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisunidadmedida(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisunidadmedida.FirstOrDefault(p => p.sis_codume_sium == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desume_sium;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISUNIDADMEDIDA: Tabla Unidades de Medidas
        /// <summary>
        /// <para>TABLA: sisunidadmedida</para>
        /// <para>TITULO: Tabla Unidades de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisunidadmedida desde la tabla
        /// sisunidadmedida cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes unidades de medidas. ejemplo:
        /// Litros, Centilitros, Mililitros etc.
        /// </para>
        /// </summary>
        public static EFsisunidadmedida fobRegBuscarSisunidadmedida(string tcrCodigo)
        {
            EFsisunidadmedida lobReturn = new EFsisunidadmedida();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisunidadmedida.FirstOrDefault(p => p.sis_codume_sium == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISGRUPOMEDIDAS: Tabla Grupo de Medidas
        //-------------------------------------------------------
        #region Buscar SISGRUPOMEDIDAS: Tabla Grupo de Medidas
        /// <summary>
        /// <para>TABLA: sisgrupomedidas</para>
        /// <para>TITULO: Tabla Grupo de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes grupos de medidas, Ejemplo:
        /// UNIDAD, MASA, VOLUMEN, LONGITUD
        /// </para>
        /// </summary>
        public static bool flgBuscarSisgrupomedidas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisgrupomedidas.FirstOrDefault(p => p.sis_codgme_sigr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISGRUPOMEDIDAS: Tabla Grupo de Medidas
        /// <summary>
        /// <para>TABLA: sisgrupomedidas</para>
        /// <para>TITULO: Tabla Grupo de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desgme_grme
        /// (campo 'DE' de la tabla sisgrupomedidas) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes grupos de medidas, Ejemplo:
        /// UNIDAD, MASA, VOLUMEN, LONGITUD
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisgrupomedidas(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisgrupomedidas.FirstOrDefault(p => p.sis_codgme_sigr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desgme_sigr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISGRUPOMEDIDAS: Tabla Grupo de Medidas
        /// <summary>
        /// <para>TABLA: sisgrupomedidas</para>
        /// <para>TITULO: Tabla Grupo de Medidas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisgrupomedidas desde la tabla
        /// sisgrupomedidas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes grupos de medidas, Ejemplo:
        /// UNIDAD, MASA, VOLUMEN, LONGITUD
        /// </para>
        /// </summary>
        public static EFsisgrupomedidas fobRegBuscarSisgrupomedidas(string tcrCodigo)
        {
            EFsisgrupomedidas lobReturn = new EFsisgrupomedidas();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisgrupomedidas.FirstOrDefault(p => p.sis_codgme_sigr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISESTADOPROCES: Estados de procesos (Abierto, Cerrado,Anulado)
        //-------------------------------------------------------
        #region Buscar SISESTADOPROCES: Logica
        /// <summary>
        /// <para>TABLA: sisestadoproces</para>
        /// <para>TITULO: Estados de procesos (Abierto, Cerrado,Anulado)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de procesos en modulos: Registros de Atencion medica,inventarios,
        /// Contabilidad, Historias clinicas, Citas medicas, Servicios
        /// Prestados y otros, los estados son: 1= Abierto(a) 2= Cerrado/Confirmado
        /// 3=Anulado(a)
        /// </para>
        /// </summary>
        public static bool flgBuscarSisestadoproces(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoproces.FirstOrDefault(p => p.sis_estpro_espr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISESTADOPROCES: String
        /// <summary>
        /// <para>TABLA: sisestadoproces</para>
        /// <para>TITULO: Estados de procesos (Abierto, Cerrado,Anulado)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_despro_espr
        /// (campo 'DE' de la tabla sisestadoproces) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de procesos en modulos: Registros de Atencion medica,inventarios,
        /// Contabilidad, Historias clinicas, Citas medicas, Servicios
        /// Prestados y otros, los estados son: 1= Abierto(a) 2= Cerrado/Confirmado
        /// 3=Anulado(a)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisestadoproces(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoproces.FirstOrDefault(p => p.sis_estpro_espr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_despro_espr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISESTADOPROCES: Registro
        /// <summary>
        /// <para>TABLA: sisestadoproces</para>
        /// <para>TITULO: Estados de procesos (Abierto, Cerrado,Anulado)</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisestadoproces desde la tabla
        /// sisestadoproces cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estados de procesos en modulos: Registros de Atencion medica,inventarios,
        /// Contabilidad, Historias clinicas, Citas medicas, Servicios
        /// Prestados y otros, los estados son: 1= Abierto(a) 2= Cerrado/Confirmado
        /// 3=Anulado(a)
        /// </para>
        /// </summary>
        public static EFsisestadoproces fobRegBuscarSisestadoproces(string tcrCodigo)
        {
            EFsisestadoproces lobReturn = new EFsisestadoproces();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisestadoproces.FirstOrDefault(p => p.sis_estpro_espr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTABLASEXOS: Sexo Personas
        //-------------------------------------------------------
        #region Buscar SISTABLASEXOS: Logica
        /// <summary>
        /// <para>TABLA: sistablasexos</para>
        /// <para>TITULO: Sexo Personas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro para almacenar los tipos de sexos
        /// </para>
        /// </summary>
        public static bool flgBuscarSistablasexos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablasexos.FirstOrDefault(p => p.sis_codsex_sexo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTABLASEXOS: String
        /// <summary>
        /// <para>TABLA: sistablasexos</para>
        /// <para>TITULO: Sexo Personas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_dessex_sexo
        /// (campo 'DE' de la tabla sistablasexos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro para almacenar los tipos de sexos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSistablasexos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablasexos.FirstOrDefault(p => p.sis_codsex_sexo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_dessex_sexo;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTABLASEXOS: Registro
        /// <summary>
        /// <para>TABLA: sistablasexos</para>
        /// <para>TITULO: Sexo Personas</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistablasexos desde la tabla
        /// sistablasexos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro para almacenar los tipos de sexos
        /// </para>
        /// </summary>
        public static EFsistablasexos fobRegBuscarSistablasexos(string tcrCodigo)
        {
            EFsistablasexos lobReturn = new EFsistablasexos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablasexos.FirstOrDefault(p => p.sis_codsex_sexo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTABMUNICIPIO: Listado de Municipios  DANE
        //-------------------------------------------------------
        #region Buscar SISTABMUNICIPIO: Logica
        /// <summary>
        /// <para>TABLA: sistabmunicipio</para>
        /// <para>TITULO: Listado de Municipios  DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Municipios del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static bool flgBuscarSistabmunicipio(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabmunicipio.FirstOrDefault(p => p.sis_idemun_muni == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTABMUNICIPIO: String
        /// <summary>
        /// <para>TABLA: sistabmunicipio</para>
        /// <para>TITULO: Listado de Municipios  DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_nommun_muni
        /// (campo 'DE' de la tabla sistabmunicipio) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Municipios del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSistabmunicipio(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabmunicipio.FirstOrDefault(p => p.sis_idemun_muni == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_nommun_muni;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTABMUNICIPIO: Registro
        /// <summary>
        /// <para>TABLA: sistabmunicipio</para>
        /// <para>TITULO: Listado de Municipios  DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistabmunicipio desde la tabla
        /// sistabmunicipio cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Municipios del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static EFsistabmunicipio fobRegBuscarSistabmunicipio(string tcrCodigo)
        {
            EFsistabmunicipio lobReturn = new EFsistabmunicipio();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabmunicipio.FirstOrDefault(p => p.sis_idemun_muni == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTABDEPARTAME: Departamentos del Pais DANE
        //-------------------------------------------------------
        #region Buscar SISTABDEPARTAME: Logica
        /// <summary>
        /// <para>TABLA: sistabdepartame</para>
        /// <para>TITULO: Departamentos del Pais DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Departamentos del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static bool flgBuscarSistabdepartame(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabdepartame.FirstOrDefault(p => p.sis_coddep_dpto == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTABDEPARTAME: String
        /// <summary>
        /// <para>TABLA: sistabdepartame</para>
        /// <para>TITULO: Departamentos del Pais DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desdep_dpto
        /// (campo 'DE' de la tabla sistabdepartame) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Departamentos del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSistabdepartame(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabdepartame.FirstOrDefault(p => p.sis_coddep_dpto == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desdep_dpto;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTABDEPARTAME: Registro
        /// <summary>
        /// <para>TABLA: sistabdepartame</para>
        /// <para>TITULO: Departamentos del Pais DANE</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistabdepartame desde la tabla
        /// sistabdepartame cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Listado de Departamentos del Pais según Codigo DANE
        /// </para>
        /// </summary>
        public static EFsistabdepartame fobRegBuscarSistabdepartame(string tcrCodigo)
        {
            EFsistabdepartame lobReturn = new EFsistabdepartame();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistabdepartame.FirstOrDefault(p => p.sis_coddep_dpto == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISZONARESIDENC: Zona de residencia
        //-------------------------------------------------------
        #region Buscar SISZONARESIDENC: Logica
        /// <summary>
        /// <para>TABLA: siszonaresidenc</para>
        /// <para>TITULO: Zona de residencia</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Zona de residencia según norma Rips 3374 y Resol: 1344 BDUA:
        /// U=Urbana R= Rural
        /// </para>
        /// </summary>
        public static bool flgBuscarSiszonaresidenc(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siszonaresidenc.FirstOrDefault(p => p.sis_zonres_tzon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISZONARESIDENC: String
        /// <summary>
        /// <para>TABLA: siszonaresidenc</para>
        /// <para>TITULO: Zona de residencia</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_deszon_tzon
        /// (campo 'DE' de la tabla siszonaresidenc) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Zona de residencia según norma Rips 3374 y Resol: 1344 BDUA:
        /// U=Urbana R= Rural
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiszonaresidenc(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siszonaresidenc.FirstOrDefault(p => p.sis_zonres_tzon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_deszon_tzon;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISZONARESIDENC: Registro
        /// <summary>
        /// <para>TABLA: siszonaresidenc</para>
        /// <para>TITULO: Zona de residencia</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiszonaresidenc desde la tabla
        /// siszonaresidenc cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Zona de residencia según norma Rips 3374 y Resol: 1344 BDUA:
        /// U=Urbana R= Rural
        /// </para>
        /// </summary>
        public static EFsiszonaresidenc fobRegBuscarSiszonaresidenc(string tcrCodigo)
        {
            EFsiszonaresidenc lobReturn = new EFsiszonaresidenc();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siszonaresidenc.FirstOrDefault(p => p.sis_zonres_tzon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTABLAIVA: Tabla de valores para el I.V.A.
        //-------------------------------------------------------
        #region Buscar SISTABLAIVA: Logica
        /// <summary>
        /// <para>TABLA: sistablaiva</para>
        /// <para>TITULO: Tabla de valores para el I.V.A.</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que contiene los diferentes valores para el I.V.A.
        /// </para>
        /// </summary>
        public static bool flgBuscarSistablaiva(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablaiva.FirstOrDefault(p => p.sis_codiva_tiva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTABLAIVA: String
        /// <summary>
        /// <para>TABLA: sistablaiva</para>
        /// <para>TITULO: Tabla de valores para el I.V.A.</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desiva_tiva
        /// (campo 'DE' de la tabla sistablaiva) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que contiene los diferentes valores para el I.V.A.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSistablaiva(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablaiva.FirstOrDefault(p => p.sis_codiva_tiva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desiva_tiva;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTABLAIVA: Registro
        /// <summary>
        /// <para>TABLA: sistablaiva</para>
        /// <para>TITULO: Tabla de valores para el I.V.A.</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistablaiva desde la tabla sistablaiva
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que contiene los diferentes valores para el I.V.A.
        /// </para>
        /// </summary>
        public static EFsistablaiva fobRegBuscarSistablaiva(string tcrCodigo)
        {
            EFsistablaiva lobReturn = new EFsistablaiva();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistablaiva.FirstOrDefault(p => p.sis_codiva_tiva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISSALARIOMIN: Tabla de salarios minimos mensuales
        //-------------------------------------------------------
        #region Buscar SISSALARIOMIN: Logica
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TITULO: Tabla de salarios minimos mensuales</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes salarios minimos mensuales
        /// </para>
        /// </summary>
        public static bool flgBuscarSissalariomin(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sissalariomin.FirstOrDefault(p => p.sis_codsal_tsal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISSALARIOMIN: String
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TITULO: Tabla de salarios minimos mensuales</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_dessal_tsal
        /// (campo 'DE' de la tabla sissalariomin) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes salarios minimos mensuales
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSissalariomin(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sissalariomin.FirstOrDefault(p => p.sis_codsal_tsal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_dessal_tsal;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISSALARIOMIN: Registro
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TITULO: Tabla de salarios minimos mensuales</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsissalariomin desde la tabla
        /// sissalariomin cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes salarios minimos mensuales
        /// </para>
        /// </summary>
        public static EFsissalariomin fobRegBuscarSissalariomin(string tcrCodigo)
        {
            EFsissalariomin lobReturn = new EFsissalariomin();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sissalariomin.FirstOrDefault(p => p.sis_codsal_tsal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISSALARIOMIN: Registro Salario Fecha
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TITULO: Tabla de salarios minimos mensuales</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsissalariomin desde la tabla
        /// sissalariomin recibiendo como parametro una fecha
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes salarios minimos mensuales
        /// </para>
        /// </summary>
        public static EFsissalariomin fobRegBuscarSissalariominFx(DateTime tdaFecha)
        {
            EFsissalariomin lobReturn = new EFsissalariomin();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sissalariomin.FirstOrDefault(p => p.sis_feivig_tsal <= tdaFecha &&
                                                                              p.sis_fefvig_tsal >= tdaFecha);
                if (lobjRegistro != null && !String.IsNullOrWhiteSpace(lobjRegistro.sis_dessal_tsal))
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISOCUPACIONES: Tabla ocupaciones o profesiones
        //-------------------------------------------------------
        #region Buscar SISOCUPACIONES: Logica
        /// <summary>
        /// <para>TABLA: sisocupaciones</para>
        /// <para>TITULO: Tabla ocupaciones o profesiones</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de ocupaciones o profesiones para usuarios atendidos
        /// y o terceros
        /// </para>
        /// </summary>
        public static bool flgBuscarSisocupaciones(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisocupaciones.FirstOrDefault(p => p.sis_codocu_ocup == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISOCUPACIONES: String
        /// <summary>
        /// <para>TABLA: sisocupaciones</para>
        /// <para>TITULO: Tabla ocupaciones o profesiones</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desocu_ocup
        /// (campo 'DE' de la tabla sisocupaciones) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de ocupaciones o profesiones para usuarios atendidos
        /// y o terceros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisocupaciones(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisocupaciones.FirstOrDefault(p => p.sis_codocu_ocup == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desocu_ocup;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISOCUPACIONES: Registro
        /// <summary>
        /// <para>TABLA: sisocupaciones</para>
        /// <para>TITULO: Tabla ocupaciones o profesiones</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisocupaciones desde la tabla
        /// sisocupaciones cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de ocupaciones o profesiones para usuarios atendidos
        /// y o terceros
        /// </para>
        /// </summary>
        public static EFsisocupaciones fobRegBuscarSisocupaciones(string tcrCodigo)
        {
            EFsisocupaciones lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisocupaciones.FirstOrDefault(p => p.sis_codocu_ocup == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISACTUALIZARCH: Archivos actualizables desde historia clinica
        //-------------------------------------------------------
        #region Buscar SISACTUALIZARCH: Logica
        /// <summary>
        /// <para>TABLA: sisactualizarch</para>
        /// <para>TITULO: Archivos actualizables desde historia clinica</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de archivos actualizables desde los formatos de Historia
        /// clinica ejemplo: RIPSAC=Rips Archivo consulta, RIPSAP =Rips
        /// Archivo Procedimientos, RE4505 =Archivo Resolución 4505 y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSisactualizarch(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizarch.FirstOrDefault(p => p.sis_secreg_siaa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISACTUALIZARCH: String
        /// <summary>
        /// <para>TABLA: sisactualizarch</para>
        /// <para>TITULO: Archivos actualizables desde historia clinica</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desarc_siaa
        /// (campo 'DE' de la tabla sisactualizarch) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de archivos actualizables desde los formatos de Historia
        /// clinica ejemplo: RIPSAC=Rips Archivo consulta, RIPSAP =Rips
        /// Archivo Procedimientos, RE4505 =Archivo Resolución 4505 y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisactualizarch(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizarch.FirstOrDefault(p => p.sis_secreg_siaa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desarc_siaa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISACTUALIZARCH: Registro
        /// <summary>
        /// <para>TABLA: sisactualizarch</para>
        /// <para>TITULO: Archivos actualizables desde historia clinica</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisactualizarch desde la tabla
        /// sisactualizarch cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de archivos actualizables desde los formatos de Historia
        /// clinica ejemplo: RIPSAC=Rips Archivo consulta, RIPSAP =Rips
        /// Archivo Procedimientos, RE4505 =Archivo Resolución 4505 y otros
        /// </para>
        /// </summary>
        public static EFsisactualizarch fobRegBuscarSisactualizarch(string tcrCodigo)
        {
            EFsisactualizarch lobReturn = new EFsisactualizarch();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizarch.FirstOrDefault(p => p.sis_secreg_siaa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISACTUALIZARCH: Lista 
        /// <summary>
        /// <para>TABLA: sisactualizarch</para>
        /// <para>TITULO: Archivos actualizables desde historia clinica</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisactualizarch desde la tabla
        /// sisactualizarch cuando no exite retorna  null.
        /// <para>tcrEstado:</para>
        /// <para>"TODOS" = Devuelve todos los registros de la tabla</para>
        /// <para>"1" = Devuelve registros Activos "2" = Devuelve registros inactivos</para>
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de archivos actualizables desde los formatos de Historia
        /// clinica ejemplo: RIPSAC=Rips Archivo consulta, RIPSAP =Rips
        /// Archivo Procedimientos, RE4505 =Archivo Resolución 4505 y otros
        /// </para>
        /// </summary>
        public static  List<EFsisactualizarch> fobRegBuscarSisactualizarchLista(String tcrEstado)
        {
            List<EFsisactualizarch> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                if (tcrEstado != "TODOS")
                {
                    lobReturn = (from lst in _context.Sisactualizarch
                                 where lst.sis_estreg_siaa.Equals(tcrEstado)
                                 select lst).ToList();
                }
                else 
                {
                    lobReturn = (from lst in _context.Sisactualizarch select lst).ToList();
                }
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISACTUALIZARCH: Registro
        /// <summary>
        /// <para>TABLA: sisactualizarch</para>
        /// <para>TITULO: Archivos actualizables desde historia clinica</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisactualizarch desde la tabla
        /// sisactualizarch cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de archivos actualizables desde los formatos de Historia
        /// clinica ejemplo: RIPSAC=Rips Archivo consulta, RIPSAP =Rips
        /// Archivo Procedimientos, RE4505 =Archivo Resolución 4505 y otros
        /// </para>
        /// </summary>
        public static EFsisactualizarch fobRegBuscarSisactualizarchIu(string tcrCodigoArchivo)
        {
            EFsisactualizarch lobReturn = new EFsisactualizarch();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizarch.FirstOrDefault(p => p.sis_codarc_siaa == tcrCodigoArchivo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // SISACTUALIZCAMP: Campos actalizables según archivo
        //-------------------------------------------------------
        #region Buscar SISACTUALIZCAMP: Logica
        /// <summary>
        /// <para>TABLA: sisactualizcamp</para>
        /// <para>TITULO: Campos actalizables según archivo</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de campos relacionados a cada archivo actualizable según
        /// la Tabla Principal SISACTUALIZARCH
        /// </para>
        /// </summary>
        public static bool flgBuscarSisactualizcamp(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizcamp.FirstOrDefault(p => p.sis_secreg_siac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISACTUALIZCAMP: String
        /// <summary>
        /// <para>TABLA: sisactualizcamp</para>
        /// <para>TITULO: Campos actalizables según archivo</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_nomcam_siac
        /// (campo 'DE' de la tabla sisactualizcamp) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de campos relacionados a cada archivo actualizable según
        /// la Tabla Principal SISACTUALIZARCH
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisactualizcamp(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizcamp.FirstOrDefault(p => p.sis_secreg_siac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_nomcam_siac;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISACTUALIZCAMP: Registro
        /// <summary>
        /// <para>TABLA: sisactualizcamp</para>
        /// <para>TITULO: Campos actalizables según archivo</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisactualizcamp desde la tabla
        /// sisactualizcamp cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de campos relacionados a cada archivo actualizable según
        /// la Tabla Principal SISACTUALIZARCH
        /// </para>
        /// </summary>
        public static EFsisactualizcamp fobRegBuscarSisactualizcamp(string tcrCodigo)
        {
            EFsisactualizcamp lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizcamp.FirstOrDefault(p => p.sis_secreg_siac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISACTUALIZCAMP: Registro ID Unico (digitado)
        /// <summary>
        /// <para>TABLA: sisactualizcamp</para>
        /// <para>TITULO: Campos actalizables según archivo</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisactualizcamp desde la tabla
        /// sisactualizcamp cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de campos relacionados a cada archivo actualizable según
        /// la Tabla Principal SISACTUALIZARCH
        /// </para>
        /// </summary>
        public static EFsisactualizcamp fobRegBuscarSisactualizcampIu(string tcrIuCodigo)
        {
            EFsisactualizcamp lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisactualizcamp.FirstOrDefault(p => p.sis_codcam_siac == tcrIuCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISMAESPLAVALID: Maestro plantillas para validación de archivos
        //-------------------------------------------------------
        #region Buscar SISMAESPLAVALID: Logica
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TITULO: Maestro plantillas para validación de archivos</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas para configurar validacion personalizada
        /// de archivos tales como: Archivos Rips  Archivo Resolución 4505
        /// y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarSismaesplavalid(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISMAESPLAVALID: String
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TITULO: Maestro plantillas para validación de archivos</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_despla_siva
        /// (campo 'DE' de la tabla sismaesplavalid) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas para configurar validacion personalizada
        /// de archivos tales como: Archivos Rips  Archivo Resolución 4505
        /// y otros.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSismaesplavalid(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_despla_siva;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISMAESPLAVALID: Registro
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TITULO: Maestro plantillas para validación de archivos</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsismaesplavalid desde la tabla
        /// sismaesplavalid cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas para configurar validacion personalizada
        /// de archivos tales como: Archivos Rips  Archivo Resolución 4505
        /// y otros.
        /// </para>
        /// </summary>
        public static EFsismaesplavalid fobRegBuscarSismaesplavalid(string tcrCodigo)
        {
            EFsismaesplavalid lobReturn = new EFsismaesplavalid();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISMAESPLAVALID: Registro
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TITULO: Maestro plantillas para validación de archivos</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve el primer registro plantilla tipo base, segun el tipo archivo dado en el parametro tcrTipoArchivo</para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas para configurar validacion personalizada
        /// de archivos tales como: Archivos Rips  Archivo Resolución 4505
        /// y otros.
        /// </para>
        /// </summary>
        public static EFsismaesplavalid fobRegBuscarSismaesplavalidPb(String tcrTipoArchivo)
        {
            EFsismaesplavalid lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_codarc_siar == tcrTipoArchivo && p.sis_tippla_siva == "1");
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTIPOARCHIVOS: Clasificacion de archivos para gestion de datos e informes
        //-------------------------------------------------------
        #region Buscar SISTIPOARCHIVOS: Logica
        /// <summary>
        /// <para>TABLA: sistipoarchivos</para>
        /// <para>TITULO: Clasificacion de archivos para gestion de datos e informes</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion de archivos para gestion de datos e informes
        /// RIPS Resolucion 4505 y otros, identificador clasificacion del
        /// archivo: RIPSGN = Referencia a Rips General, RIPSAC = Rips
        /// consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505
        /// y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSistipoarchivos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipoarchivos.FirstOrDefault(p => p.sis_codarc_siar == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTIPOARCHIVOS: String
        /// <summary>
        /// <para>TABLA: sistipoarchivos</para>
        /// <para>TITULO: Clasificacion de archivos para gestion de datos e informes</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_desarc_siar
        /// (campo 'DE' de la tabla sistipoarchivos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion de archivos para gestion de datos e informes
        /// RIPS Resolucion 4505 y otros, identificador clasificacion del
        /// archivo: RIPSGN = Referencia a Rips General, RIPSAC = Rips
        /// consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505
        /// y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSistipoarchivos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipoarchivos.FirstOrDefault(p => p.sis_codarc_siar == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_desarc_siar;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTIPOARCHIVOS: Registro
        /// <summary>
        /// <para>TABLA: sistipoarchivos</para>
        /// <para>TITULO: Clasificacion de archivos para gestion de datos e informes</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistipoarchivos desde la tabla
        /// sistipoarchivos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion de archivos para gestion de datos e informes
        /// RIPS Resolucion 4505 y otros, identificador clasificacion del
        /// archivo: RIPSGN = Referencia a Rips General, RIPSAC = Rips
        /// consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505
        /// y otros
        /// </para>
        /// </summary>
        public static EFsistipoarchivos fobRegBuscarSistipoarchivos(string tcrCodigo)
        {
            EFsistipoarchivos lobReturn = new EFsistipoarchivos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipoarchivos.FirstOrDefault(p => p.sis_codarc_siar == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISMADEPLAVALID: Registros o campos detalle para plantillas de validación
        //-------------------------------------------------------
        #region Buscar SISMADEPLAVALID: Logica
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TITULO: Registros o campos detalle para plantillas de validación</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros o campos detalle para configurar las validaciones
        /// de cada plantilla personalizada
        /// </para>
        /// </summary>
        public static bool flgBuscarSismadeplavalid(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISMADEPLAVALID: String
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TITULO: Registros o campos detalle para plantillas de validación</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_nomcam_sivd
        /// (campo 'DE' de la tabla sismadeplavalid) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros o campos detalle para configurar las validaciones
        /// de cada plantilla personalizada
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSismadeplavalid(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_nomcam_sivd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISMADEPLAVALID: Registro
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TITULO: Registros o campos detalle para plantillas de validación</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsismadeplavalid desde la tabla
        /// sismadeplavalid cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros o campos detalle para configurar las validaciones
        /// de cada plantilla personalizada
        /// </para>
        /// </summary>
        public static EFsismadeplavalid fobRegBuscarSismadeplavalid(string tcrCodigo)
        {
            EFsismadeplavalid lobReturn = new EFsismadeplavalid();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISMADEPLAVALID: Temporal 
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TITULO: Registros o campos detalle para plantillas de validación</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un temporal de tipo EFsismadeplavalid dado el codigo de la plantilla
        /// sismadeplavalid cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION:
        /// Retorna un temporal con los registros que pertenecen a la plantilla dada en el 
        /// parametro tcrCodigoPlantilla
        /// </para>
        /// </summary>
        public static List<EFsismadeplavalid> fobRegBuscarSismadeplavalidTemp(String tcrCodigoPlantilla)
        {
            List<EFsismadeplavalid> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Sismadeplavalid
                                    where tmp.sis_secreg_siva == tcrCodigoPlantilla
                                    select tmp).ToList();

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISPARAMETROIPS: Parametros basicos configuración IPS
        //-------------------------------------------------------
        #region Buscar SISPARAMETROIPS: Logica
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TITULO: Parametros basicos configuración IPS</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro para configracion de datos basicos IPS tales
        /// como:  razon social Nit codigo prestador logotipo eslogan y
        /// mas
        /// </para>
        /// </summary>
        public static bool flgBuscarSisparametroips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISPARAMETROIPS: String
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TITULO: Parametros basicos configuración IPS</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_razsoc_pips
        /// (campo 'DE' de la tabla sisparametroips) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro para configracion de datos basicos IPS tales
        /// como:  razon social Nit codigo prestador logotipo eslogan y
        /// mas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisparametroips(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_razsoc_pips;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISPARAMETROIPS: Registro
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TITULO: Parametros basicos configuración IPS</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisparametroips desde la tabla
        /// sisparametroips cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro para configracion de datos basicos IPS tales
        /// como:  razon social Nit codigo prestador logotipo eslogan y
        /// mas
        /// </para>
        /// </summary>
        public static EFsisparametroips fobRegBuscarSisparametroips(string tcrCodigo)
        {
            EFsisparametroips lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        public static EFsisparametroips fobRegBuscarSisparametroips()
        {
            EFsisparametroips lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault();
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISPROVEEDORES: Maestro Proveedores
        //-------------------------------------------------------
        #region Buscar SISPROVEEDORES: Logica
        /// <summary>
        /// <para>TABLA: sisproveedores</para>
        /// <para>TITULO: Maestro Proveedores</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las diferentes empresas /
        /// personas naturales proveedoras de articulos o servicios.
        /// </para>
        /// </summary>
        public static bool flgBuscarSisproveedores(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisproveedores.FirstOrDefault(p => p.sis_secpro_sipr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISPROVEEDORES: String
        /// <summary>
        /// <para>TABLA: sisproveedores</para>
        /// <para>TITULO: Maestro Proveedores</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_razsoc_sipr
        /// (campo 'DE' de la tabla sisproveedores) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las diferentes empresas /
        /// personas naturales proveedoras de articulos o servicios.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSisproveedores(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisproveedores.FirstOrDefault(p => p.sis_secpro_sipr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_razsoc_sipr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISPROVEEDORES: Registro
        /// <summary>
        /// <para>TABLA: sisproveedores</para>
        /// <para>TITULO: Maestro Proveedores</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsisproveedores desde la tabla
        /// sisproveedores cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las diferentes empresas /
        /// personas naturales proveedoras de articulos o servicios.
        /// </para>
        /// </summary>
        public static EFsisproveedores fobRegBuscarSisproveedores(string tcrCodigo)
        {
            EFsisproveedores lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisproveedores.FirstOrDefault(p => p.sis_secpro_sipr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISMAESTERCEROS: Tabla terceros para gestion contable
        //-------------------------------------------------------
        #region Buscar SISMAESTERCEROS: Logica
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla terceros para gestion contable y referencias en otros
        /// modulos del sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarSismaesterceros(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISMAESTERCEROS: String
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sis_razsoc_sitr
        /// (campo 'DE' de la tabla sismaesterceros) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla terceros para gestion contable y referencias en otros
        /// modulos del sistema
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSismaesterceros(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_razsoc_sitr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISMAESTERCEROS: Registro
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsismaesterceros desde la tabla
        /// sismaesterceros cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla terceros para gestion contable y referencias en otros
        /// modulos del sistema
        /// </para>
        /// </summary>
        public static EFsismaesterceros fobRegBuscarSismaesterceros(string tcrCodigo)
        {
            EFsismaesterceros lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SISMAESTERCEROS: Registro
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsismaesterceros desde la tabla
        /// sismaesterceros cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla terceros para gestion contable y referencias en otros
        /// modulos del sistema
        /// </para>
        /// </summary>
        public static EFsismaesterceros fobRegBuscarSismaestercerosNit(string tcrCodigo)
        {
            EFsismaesterceros lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_numide_sitr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISMAESDEPENDEN: Dependencias o areas funcionales de la empresa
        //-------------------------------------------------------
        #region Buscar SISMAESDEPENDEN: Logica
        /// <summary>
        /// <para>TABLA: sismaesdependen</para>
        /// <para>TITULO: Dependencias o areas funcionales de la empresa</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla dependencias o areas funcionales de la empresa
        /// </para>
        /// </summary>
        public static bool flgBuscarSismaesdependen(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesdependen.FirstOrDefault(p => p.sis_coddep_sidp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISMAESDEPENDEN: String
        /// <summary>
        /// <para>TABLA: sismaesdependen</para>
        /// <para>TITULO: Dependencias o areas funcionales de la empresa</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sis_nomdep_sidp
        /// (campo 'DE' de la tabla sismaesdependen) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla dependencias o areas funcionales de la empresa
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSismaesdependen(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesdependen.FirstOrDefault(p => p.sis_coddep_sidp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_nomdep_sidp;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISMAESDEPENDEN: Registro
        /// <summary>
        /// <para>TABLA: sismaesdependen</para>
        /// <para>TITULO: Dependencias o areas funcionales de la empresa</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsismaesdependen desde la tabla
        /// sismaesdependen cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla dependencias o areas funcionales de la empresa
        /// </para>
        /// </summary>
        public static EFsismaesdependen fobRegBuscarSismaesdependen(String tcrCodigo)
        {
            EFsismaesdependen lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesdependen.FirstOrDefault(p => p.sis_coddep_sidp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SISTIPIDTERCER: Tipo identificacion tercero contable
        //-------------------------------------------------------
        #region Buscar SISTIPIDTERCER: Logica
        /// <summary>
        /// <para>TABLA: sistipidtercer</para>
        /// <para>TITULO: Tipo identificacion tercero contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public static bool flgBuscarSistipidtercer(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipidtercer.FirstOrDefault(p => p.sis_tipide_tido == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISTIPIDTERCER: String
        /// <summary>
        /// <para>TABLA: sistipidtercer</para>
        /// <para>TITULO: Tipo identificacion tercero contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sis_deside_tido
        /// (campo 'DE' de la tabla sistipidtercer) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSistipidtercer(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipidtercer.FirstOrDefault(p => p.sis_tipide_tido == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sis_deside_tido;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SISTIPIDTERCER: Registro
        /// <summary>
        /// <para>TABLA: sistipidtercer</para>
        /// <para>TITULO: Tipo identificacion tercero contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsistipidtercer desde la tabla
        /// sistipidtercer cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public static EFsistipidtercer fobRegBuscarSistipidtercer(String tcrCodigo)
        {
            EFsistipidtercer lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sistipidtercer.FirstOrDefault(p => p.sis_tipide_tido == tcrCodigo);
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

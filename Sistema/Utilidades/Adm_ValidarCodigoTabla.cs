using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class ADMValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // ADM - MODULO ADMISION DE PACIENTES
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // ADMTIPOATENCION: Ambito de atención paciente
        //-------------------------------------------------------
        #region Buscar ADMTIPOATENCION: Logica
        /// <summary>
        /// <para>TABLA: admtipoatencion</para>
        /// <para>TITULO: Ambito de atención paciente</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Ambito en Admision de Pacientes según Resolución 3374 RIPS:
        /// 1=Ambulatoria 2=Hospitalizacion 3=Urgencias
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtipoatencion(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtipoatencion.FirstOrDefault(p => p.adm_codtat_tatn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMTIPOATENCION: String
        /// <summary>
        /// <para>TABLA: admtipoatencion</para>
        /// <para>TITULO: Ambito de atención paciente</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en adm_destat_tatn
        /// (campo 'DE' de la tabla admtipoatencion) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Ambito en Admision de Pacientes según Resolución 3374 RIPS:
        /// 1=Ambulatoria 2=Hospitalizacion 3=Urgencias
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmtipoatencion(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtipoatencion.FirstOrDefault(p => p.adm_codtat_tatn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_destat_tatn;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMTIPOATENCION: Registro
        /// <summary>
        /// <para>TABLA: admtipoatencion</para>
        /// <para>TITULO: Ambito de atención paciente</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmtipoatencion desde la tabla
        /// admtipoatencion cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Ambito en Admision de Pacientes según Resolución 3374 RIPS:
        /// 1=Ambulatoria 2=Hospitalizacion 3=Urgencias
        /// </para>
        /// </summary>
        public static EFadmtipoatencion fobRegBuscarAdmtipoatencion(string tcrCodigo)
        {
            EFadmtipoatencion lobReturn = new EFadmtipoatencion();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtipoatencion.FirstOrDefault(p => p.adm_codtat_tatn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMREGADMISION: Admisión de pacientes
        //-------------------------------------------------------
        #region Buscar ADMREGADMISION: Logica
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del modulo de facturación médica (fcm) - Registrar todas
        /// las admisiones de pacientes en la institución IPS;
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregadmision(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMREGADMISION: Registro
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmregadmision desde la tabla
        /// admregadmision cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del modulo de facturación médica (fcm) - Registrar todas
        /// las admisiones de pacientes en la institución IPS;
        /// </para>
        /// </summary>
        public static EFadmregadmision fobRegBuscarAdmregadmision(string tcrCodigoAdmision)
        {
            EFadmregadmision lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMREGADMISION: Registro codigo Triage
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmregadmision desde la tabla
        /// admregadmision dado el codigo triage, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del modulo de facturación médica (fcm) - Registrar todas
        /// las admisiones de pacientes en la institución IPS;
        /// </para>
        /// </summary>
        public static EFadmregadmision fobRegBuscarAdmregadmisionTriage(string tcrCodigoTriage)
        {
            EFadmregadmision lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigoTriage);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMREGADMISION: Registro por IG
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve registros de tipo EFadmregadmision desde la tabla
        /// admregadmision cuando no exite retorna  null.
        /// <para>Parametro:</para>
        /// <para>tcrNumeroIgUsuario: Numero unico del usuario o paciente en base de datos</para>
        /// <para>de pacientes atendidos</para>
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del modulo Admision servicios medicos para Registrar todas
        /// las admisiones de pacientes en la institución IPS;
        /// </para>
        /// </summary>
        public static List<EFadmregadmision> fobRegBuscarAdmregadmisionIG(String tcrNumeroIgUsuario)
        {
            List<EFadmregadmision> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro =  (from admregadmision in _context.Admregadmision 
                                     where admregadmision.sia_idesec_usua.Equals(tcrNumeroIgUsuario)
                                     select admregadmision).ToList();

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMREGADMISION: Registro id unica y finalizar atencion
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO: Devuelve el primer registro de tipo EFadmtriagemaestr Admitido/Ambulatoria con </para>
        /// <para>estado de atencion segun finalizado "1"/"2"</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdUnicoUsuario: Id unico del usario en base de datos del sistema</para>
        /// <para>tcrTipoRegAdmision: "1" = Admitido "2" = Ambulatoria</para>
        /// <para>tcrFinalizAdmision: "1" = No esta Finalizado "2"= Registro Finalizado</para>
        /// <para>PARAMETROS:</para>
        /// </summary>
        public static EFadmregadmision fobRegBuscarAdmregadmisionFinAtencion(String tcrIdUnicoUsuario, String tcrTipoRegAdmision, String tcrFinalizAdmision)
        {
            EFadmregadmision lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.sia_idesec_usua == tcrIdUnicoUsuario && 
                                                                           p.sia_regate_rgat == tcrTipoRegAdmision &&
                                                                           p.adm_finate_rgad == tcrFinalizAdmision);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region flstListaAdmregadmisionFiltro: devuelve una lista de admisiones dado un rango de fechas
        /// <summary>
        /// <para>devuelve una lista de admisiones dado un rango de fechas</para>
        /// </summary>
        public static List<EFadmregadmision> flstListaAdmregadmisionFiltro(String tcrCodigoEps, String tcrFechaInicial, String tcrFechaFinal)
        {
            List<EFadmregadmision> tmReturn = null;
            var ldaFechaIni = Funciones.fdaConvertFecha("DMY","/",tcrFechaInicial);
            var ldaFechaFin = Funciones.fdaConvertFecha("DMY","/",tcrFechaFinal);

            using (_context = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigoEps))
                {
                    tmReturn = (from tmp in _context.Admregadmision
                                where tmp.adm_fecadm_rgad >= ldaFechaIni &&
                                           tmp.adm_fecadm_rgad <= ldaFechaFin &&
                                           tmp.sia_codeps_teps == tcrCodigoEps
                                select tmp).ToList();
                }
                else
                {
                    tmReturn = (from tmp in _context.Admregadmision
                                where tmp.adm_fecadm_rgad >= ldaFechaIni &&
                                           tmp.adm_fecadm_rgad <= ldaFechaFin select tmp).ToList();
                }
            }
            return tmReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMVIAINGRESO: Tipo origen de la admisión
        //-------------------------------------------------------
        #region Buscar ADMVIAINGRESO: Logica
        /// <summary>
        /// <para>TABLA: admviaingreso</para>
        /// <para>TITULO: Tipo origen de la admisión</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código Tipo Origen de Admisión o vía de ingreso a la institución:
        /// 1=Urgencias 2=Consulta externa 3=Remitido 4=Nacido en la institución
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmviaingreso(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admviaingreso.FirstOrDefault(p => p.adm_codoad_toad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMVIAINGRESO: String
        /// <summary>
        /// <para>TABLA: admviaingreso</para>
        /// <para>TITULO: Tipo origen de la admisión</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en adm_desoad_toad
        /// (campo 'DE' de la tabla admviaingreso) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código Tipo Origen de Admisión o vía de ingreso a la institución:
        /// 1=Urgencias 2=Consulta externa 3=Remitido 4=Nacido en la institución
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmviaingreso(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admviaingreso.FirstOrDefault(p => p.adm_codoad_toad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_desoad_toad;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMVIAINGRESO: Registro
        /// <summary>
        /// <para>TABLA: admviaingreso</para>
        /// <para>TITULO: Tipo origen de la admisión</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmviaingreso desde la tabla
        /// admviaingreso cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código Tipo Origen de Admisión o vía de ingreso a la institución:
        /// 1=Urgencias 2=Consulta externa 3=Remitido 4=Nacido en la institución
        /// </para>
        /// </summary>
        public static EFadmviaingreso fobRegBuscarAdmviaingreso(string tcrCodigo)
        {
            EFadmviaingreso lobReturn = new EFadmviaingreso();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admviaingreso.FirstOrDefault(p => p.adm_codoad_toad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMCAUSAEXTERNA: Causa externa origen de atención
        //-------------------------------------------------------
        #region Buscar ADMCAUSAEXTERNA: Logica
        /// <summary>
        /// <para>TABLA: admcausaexterna</para>
        /// <para>TITULO: Causa externa origen de atención</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Causa Externa Origen de Atención que origina la atención según
        /// Resolución: 3374 RIPS: 01=ACCIDENTE DE TRABAJO 02=ACCIDENTE
        /// DE TRANSITO…15=OTRA
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmcausaexterna(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admcausaexterna.FirstOrDefault(p => p.adm_codcex_tcex == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMCAUSAEXTERNA: String
        /// <summary>
        /// <para>TABLA: admcausaexterna</para>
        /// <para>TITULO: Causa externa origen de atención</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en adm_descex_tcex
        /// (campo 'DE' de la tabla admcausaexterna) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Causa Externa Origen de Atención que origina la atención según
        /// Resolución: 3374 RIPS: 01=ACCIDENTE DE TRABAJO 02=ACCIDENTE
        /// DE TRANSITO…15=OTRA
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmcausaexterna(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admcausaexterna.FirstOrDefault(p => p.adm_codcex_tcex == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_descex_tcex;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMCAUSAEXTERNA: Registro
        /// <summary>
        /// <para>TABLA: admcausaexterna</para>
        /// <para>TITULO: Causa externa origen de atención</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmcausaexterna desde la tabla
        /// admcausaexterna cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Causa Externa Origen de Atención que origina la atención según
        /// Resolución: 3374 RIPS: 01=ACCIDENTE DE TRABAJO 02=ACCIDENTE
        /// DE TRANSITO…15=OTRA
        /// </para>
        /// </summary>
        public static EFadmcausaexterna fobRegBuscarAdmcausaexterna(string tcrCodigo)
        {
            EFadmcausaexterna lobReturn = new EFadmcausaexterna();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admcausaexterna.FirstOrDefault(p => p.adm_codcex_tcex == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMDESTINOSALIR: Tabla de destino al Salir
        //-------------------------------------------------------
        #region Buscar ADMDESTINOSALIR: Logica
        /// <summary>
        /// <para>TABLA: admdestinosalir</para>
        /// <para>TITULO: Tabla de destino al Salir</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que almacena los diferentes destinos al salir
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmdestinosalir(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admdestinosalir.FirstOrDefault(p => p.adm_coddsa_tdsa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMDESTINOSALIR: String
        /// <summary>
        /// <para>TABLA: admdestinosalir</para>
        /// <para>TITULO: Tabla de destino al Salir</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en adm_desdsa_tdsa
        /// (campo 'DE' de la tabla admdestinosalir) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que almacena los diferentes destinos al salir
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmdestinosalir(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admdestinosalir.FirstOrDefault(p => p.adm_coddsa_tdsa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_desdsa_tdsa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMDESTINOSALIR: Registro
        /// <summary>
        /// <para>TABLA: admdestinosalir</para>
        /// <para>TITULO: Tabla de destino al Salir</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmdestinosalir desde la tabla
        /// admdestinosalir cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla que almacena los diferentes destinos al salir
        /// </para>
        /// </summary>
        public static EFadmdestinosalir fobRegBuscarAdmdestinosalir(string tcrCodigo)
        {
            EFadmdestinosalir lobReturn = new EFadmdestinosalir();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admdestinosalir.FirstOrDefault(p => p.adm_coddsa_tdsa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMREGISTEGRESO: Maestro registro egresos de hospitalizacion
        //-------------------------------------------------------
        #region Buscar ADMREGISTEGRESO: Logica
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TITULO: Maestro registro egresos de hospitalizacion</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro egresos de hospitalizacion, se diligencia
        /// al momento de confirmada la Autorizacion de salida del paciente
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregistegreso(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secegr_regr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMREGISTEGRESO: Registro
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TITULO: Maestro registro egresos de hospitalizacion</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmregistegreso desde la tabla
        /// admregistegreso cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro egresos de hospitalizacion, se diligencia
        /// al momento de confirmada la Autorizacion de salida del paciente
        /// </para>
        /// </summary>
        public static EFadmregistegreso fobRegBuscarAdmregistegreso(string tcrCodigo)
        {
            EFadmregistegreso lobReturn = new EFadmregistegreso();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secegr_regr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMREGISTEGRESO: Registro Admisión
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TITULO: Maestro registro egresos de hospitalizacion</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmregistegreso desde la tabla
        /// admregistegreso cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro egresos de hospitalizacion, se diligencia
        /// al momento de confirmada la Autorizacion de salida del paciente
        /// La busqueda se realiza por el numero de Registro Admision
        /// </para>
        /// </summary>
        public static EFadmregistegreso fobRegBuscarAdmregistegresoAdm(string tcrCodigo)
        {
            EFadmregistegreso lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMORDENDSALIDA: Autorizacion de salida o egreso a pacientes
        //-------------------------------------------------------
        #region Buscar ADMORDENDSALIDA: Logica
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TITULO: Autorizacion de salida o egreso a pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Autorización de egreso a pacientes que se encuentran admitidos
        /// por hospitalización o urgencias, estas autorizaciones las hacen
        /// los profesionales (Médicos enfermeras y otros profesionales
        /// de salud)
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmordendsalida(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secaut_aegr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMORDENDSALIDA: Registro
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TITULO: Autorizacion de salida o egreso a pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmordendsalida desde la tabla
        /// admordendsalida cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Autorización de egreso a pacientes que se encuentran admitidos
        /// por hospitalización o urgencias, estas autorizaciones las hacen
        /// los profesionales (Médicos enfermeras y otros profesionales
        /// de salud)
        /// </para>
        /// </summary>
        public static EFadmordendsalida fobRegBuscarAdmordendsalida(string tcrCodigo)
        {
            EFadmordendsalida lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secaut_aegr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMORDENDSALIDA: Numero de admision
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TITULO: Autorizacion de salida o egreso a pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmordendsalida desde la tabla
        /// admordendsalida utilizando como llave el numero de admisión
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Autorización de egreso a pacientes que se encuentran admitidos
        /// por hospitalización o urgencias, estas autorizaciones las hacen
        /// los profesionales (Médicos enfermeras y otros profesionales
        /// de salud)
        /// </para>
        /// <para>tcrEstadoRegistro:</para>
        /// <para>"TODOS" = Todos los estados</para>
        /// <para>"12X" = Abiertos y Confirmados</para>
        /// <para>"1XX" = Solo Abiertos</para>
        /// <para>"2XX" = Solo Confirmados</para>
        /// <para>"3XX" = Solo Anulados</para>
        /// </summary>
        public static EFadmordendsalida fobRegBuscarAdmordendsalidaAd(String tcrCodigo, String tcrEstadoRegistro)
        {
            EFadmordendsalida lobReturn = null;
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrWhiteSpace(tcrEstadoRegistro))
                {
                    var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo);
                    if (lobjRegistro != null)
                    {
                        lobReturn = lobjRegistro;
                    };
                }
                else 
                {
                    var lcrEstado1 = tcrEstadoRegistro.Substring(0, 1);
                    var lcrEstado2 = tcrEstadoRegistro.Substring(1, 1);
                    var lcrEstado3 = tcrEstadoRegistro.Substring(2, 1);

                    if (tcrEstadoRegistro == "TODOS")
                    {
                        lcrEstado1 = "1"; // Abierto
                        lcrEstado2 = "2"; // Cerrado
                        lcrEstado3 = "3"; // Anulado
                    }

                    var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo && 
                                        (p.adm_estreg_aegr == lcrEstado1 || p.adm_estreg_aegr == lcrEstado2 || p.adm_estreg_aegr == lcrEstado3));
                    if (lobjRegistro != null)
                    {
                        lobReturn = lobjRegistro;
                    };
                }
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMTRIAGEMAESTR: Maestro evaluación Triage
        //-------------------------------------------------------
        #region Buscar ADMTRIAGEMAESTR: Logica
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtriagemaestr(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMTRIAGEMAESTR: String
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nomusu_usua
        /// (campo 'DE' de la tabla admtriagemaestr) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmtriagemaestr(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nomusu_usua;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMTRIAGEMAESTR: Registro
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmtriagemaestr desde la tabla
        /// admtriagemaestr cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static EFadmtriagemaestr fobRegBuscarAdmtriagemaestr(string tcrCodigo)
        {
            EFadmtriagemaestr lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        // Busqueda por identificacion
        #region Buscar IU ADMTRIAGEMAESTR: Logica
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtriagemaestrIU(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.sia_nroide_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar IU ADMTRIAGEMAESTR: String
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nomusu_usua
        /// (campo 'DE' de la tabla admtriagemaestr) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmtriagemaestrIU(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.sia_nroide_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nomusu_usua;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region BuscarIU ADMTRIAGEMAESTR: Registro
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmtriagemaestr desde la tabla
        /// admtriagemaestr cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static EFadmtriagemaestr fobRegBuscarAdmtriagemaestrIU(string tcrCodigo)
        {
            EFadmtriagemaestr lobReturn = new EFadmtriagemaestr();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.sia_nroide_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMREGURGENCIAS: Maestro registro salida de urgencias
        //-------------------------------------------------------
        #region Buscar ADMREGURGENCIAS: Logica
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TITULO: Maestro registro salida de urgencias</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro datos salida de urgencias con observación
        /// (sea que pase a hospitalizacion o salga de la IPS)
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregurgencias(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMREGURGENCIAS: String
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TITULO: Maestro registro salida de urgencias</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en adm_observ_regu
        /// (campo 'DE' de la tabla admregurgencias) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro datos salida de urgencias con observación
        /// (sea que pase a hospitalizacion o salga de la IPS)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarAdmregurgencias(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_observ_regu;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMREGURGENCIAS: Registro
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TITULO: Maestro registro salida de urgencias</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmregurgencias desde la tabla
        /// admregurgencias cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro datos salida de urgencias con observación
        /// (sea que pase a hospitalizacion o salga de la IPS)
        /// </para>
        /// </summary>
        public static EFadmregurgencias fobRegBuscarAdmregurgencias(string tcrCodigo)
        {
            EFadmregurgencias lobReturn = null;
            using (_context = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigo))
                {
                    var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tcrCodigo);
                    if (lobjRegistro != null)
                    {
                        lobReturn = lobjRegistro;
                    };
                }
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMREGURGENCIAS: Registro Admision
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TITULO: Maestro registro salida de urgencias</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve registro tipo EFadmregurgencias en estado confirmado dado  el Id de admisión cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro datos salida de urgencias con observación
        /// (sea que pase a hospitalizacion o salga de la IPS)
        /// </para>
        /// </summary>
        public static EFadmregurgencias fobRegBuscarAdmregurgenciasAdm(string tcrIdAdmision)
        {
            EFadmregurgencias lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision && p.sis_estpro_espr=="2");
                if (lobjRegistro == null)
                {
                    lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision && p.sis_estpro_espr == "1");
                }
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                }
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ADMTRIAGEMACONF: Configuracion parametros evaluación Triage
        //-------------------------------------------------------
        #region Buscar ADMTRIAGEMACONF: Logica
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TITULO: Configuracion parametros evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion parametros según niveles en la evaluación inicial
        /// Triage realizada a pacientes.
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtriagemaconf(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMTRIAGEMACONF: String
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TITULO: Configuracion parametros evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en adm_titcla_adct
        /// (campo 'DE' de la tabla admtriagemaconf) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion parametros según niveles en la evaluación inicial
        /// Triage realizada a pacientes.
        /// </para>
        /// </summary>
        public static String fcrDEBuscarAdmtriagemaconf(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.adm_titcla_adct;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ADMTRIAGEMACONF: Registro
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TITULO: Configuracion parametros evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFadmtriagemaconf desde la tabla
        /// admtriagemaconf cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion parametros según niveles en la evaluación inicial
        /// Triage realizada a pacientes.
        /// </para>
        /// </summary>
        public static EFadmtriagemaconf fobRegBuscarAdmtriagemaconf(String tcrCodigo)
        {
            EFadmtriagemaconf lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ADMTRIAGEMACONF: Registro  Nivel Triage
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TITULO: Configuracion parametros evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro desde la tabla segun el nivel clasificacion triage cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion parametros según niveles en la evaluación inicial
        /// Triage realizada a pacientes.
        /// </para>
        /// </summary>
        public static EFadmtriagemaconf fobRegBuscarAdmtriagemaconfNivel(String tcrCodigo)
        {
            EFadmtriagemaconf lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_clasif_tria == tcrCodigo);
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

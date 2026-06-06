using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Vista;

namespace Sistema.Utilidades
{
    public class FCMValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // FCM - MODULO FACTURACION SERVICIOS MEDICOS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // FCMMANSERVICIPS: Maestro de servicios habilitados para la IPS, contiene la va
        //-------------------------------------------------------
        #region Buscar FCMMANSERVICIPS String
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS, contiene la validacion de pertinencia, tipo de servicio RIPS, configuracion general del servicio (sexo al que aplica edad y otros)</para>
        /// <para>MODULO: FCM</para>
        /// <para>DESCRIPCION:
        /// Maestro de servicios habilitados para la IPS, contiene la validacion
        /// de pertinencia, tipo de servicio RIPS, configuracion general
        /// del servicio (sexo al que aplica edad y otros)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmmanservicips(string tcrCodigo)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.fcm_desser_sips;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIPS Registro
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmanservicips desde la tabla
        /// fcmmanservicips cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios habilitados para la IPS, contiene la validacion
        /// de pertinencia, tipo de servicio RIPS, configuracion general
        /// del servicio (sexo al que aplica edad y otros)
        /// </para>
        /// </summary>
        public static EFfcmmanservicips fobRegBuscarFcmmanservicips(string tcrCodigo)
        {
            EFfcmmanservicips lobReturn = new EFfcmmanservicips();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIPS Logica
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios habilitados para la IPS, contiene la validacion
        /// de pertinencia, tipo de servicio RIPS, configuracion general
        /// del servicio (sexo al que aplica edad y otros)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmanservicips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIPS Codigo Digitacion
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmanservicips segun codigo auxiliar de digitación
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// <para>Maestro de servicios habilitados para la IPS, contiene la validacion</para>
        /// <para>de pertinencia, tipo de servicio RIPS, configuracion general</para>
        /// <para>del servicio (sexo al que aplica edad y otros)</para>
        /// </para>
        /// </summary>
        public static EFfcmmanservicips fobRegBuscarFcmmanservicipsCx(string tcrCodigo)
        {
            EFfcmmanservicips lobReturn =null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_coddig_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIPS Codigo Digitacion
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO: Devuelve un registro de tipo EFfcmmanservicips dado el id Unico del servicio IPS </para>
        /// <para>DESCRIPCION TABLA: Maestro de servicios habilitados para la IPS, contiene la validacion</para>
        /// <para>de pertinencia, tipo de servicio RIPS, configuracion general</para>
        /// <para>del servicio (sexo al que aplica edad y otros)</para>
        /// </summary>
        public static EFfcmmanservicips fobRegBuscarFcmmanservicipsId(string tcrCodigo)
        {
            EFfcmmanservicips lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMMANSERVICIOS: Manual ventas de servicios medicos
        //-------------------------------------------------------
        #region Buscar FCMMANSERVICIOS: Logica
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crea paquetes de servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmanservicios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIOS: String
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desser_mant
        /// (campo 'DE' de la tabla fcmmanservicios) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crea paquetes de servicios
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmmanservicios(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desser_mant;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMMANSERVICIOS: Registro
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmanservicios desde la tabla
        /// fcmmanservicios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crea paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmanservicios fobRegBuscarFcmmanservicios(string tcrCodigo)
        {
            EFfcmmanservicios lobReturn = new EFfcmmanservicios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar IU FCMMANSERVICIOS: Registro
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmanservicios desde la tabla
        /// fcmmanservicios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crean paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmanservicios fobRegBuscarIuFcmmanservicios(string tcrCodigo)
        {
            EFfcmmanservicios lobReturn = new EFfcmmanservicios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_coddig_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar IU FCMMANSERVICIOS: Registro y tarifario
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmanservicios desde la tabla
        /// fcmmanservicios, segun codigo digitacion y codigo tarifario 
        /// dado en parametros, cuando no existe retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crean paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmanservicios fobRegBuscarIuFcmmanservicios(String tcrCodigo, String tcrCodigoTarifario)
        {
            EFfcmmanservicios lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = from tmp in _context.Fcmmanservicios
                                   where tmp.fcm_coddig_mant == tcrCodigo && tmp.fcm_codman_mans == tcrCodigoTarifario
                                   select tmp;
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar IU FCMMANSERVICIOS: Medicamentos Registro y tarifario
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve un registro de tipo EFfcmmanservicios desde la tabla</para>
        /// <para>fcmmanservicios solo registros de medicamentos, segun codigo digitacion y codigo tarifario </para>
        /// <para>dado en parametros, cuando no existe retorna  null.</para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crean paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmanservicios fobRegBuscarIuFcmmanserviciosMed(String tcrCodigo, String tcrCodigoTarifario)
        {
            EFfcmmanservicios lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = from tmp in _context.Fcmmanservicios
                                   join fcmserviciosips in _context.Fcmmanservicips on tmp.fcm_idesec_sips equals fcmserviciosips.fcm_idesec_sips
                                   where tmp.fcm_coddig_mant == tcrCodigo && tmp.fcm_codman_mans == tcrCodigoTarifario &&
                                         (fcmserviciosips.sia_codrip_trip.Equals("12") ||
                                         fcmserviciosips.sia_codrip_trip.Equals("13"))
                                   select tmp;
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar IU FCMMANSERVICIOS: Registro tarifario servicios personalizados
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve un registro de tipo EFfcmmanservicios desde la tabla fcmmanservicios, segun codigo digitacion,</para>
        /// <para>codigo tarifario y Id del contrato para validaciones de servicios personalizados en contratos</para>
        /// <para>devuelve "E%1" cuando hay error de servicios personalizados en el contrato</para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crean paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmanservicios fobRegBuscarIuFcmmanserviciosProg(String tcrCodigoDigitacion, String tcrCodigoTarifario,
                                                                          String tcrIdContrato, String tcrServPersonalizados)
        {
            EFfcmmanservicios lobReturn = null;
            EFctomanservicios lobjRegPer = null;
            using (_context = new DbAplicacion())
            {
                lobjRegPer = _context.Ctomanservicios.FirstOrDefault(p => p.cto_seccon_cont == tcrIdContrato && p.fcm_coddig_mant == tcrCodigoDigitacion);
                if (lobjRegPer != null)
                {
                    if (tcrServPersonalizados != "3") // 1= Tariafario y Personalizados 2=Solo personalizados 3= No usar personalizados
                    {
                        var lobjRegAux = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_coddig_mant == tcrCodigoDigitacion &&
                                                                                      p.fcm_codman_mans == lobjRegPer.fcm_codman_mans);
                        #region complementar datos
                        if (lobjRegAux != null)
                        {
                            lobReturn = lobjRegAux;
                            // Reasignar parametros del servicio
                            lobReturn.fcm_codser_mant = lobjRegPer.fcm_codser_mant;
                            lobReturn.fcm_codser_mant = lobjRegPer.fcm_codser_mant;
                            lobReturn.fcm_desser_mant = lobjRegPer.fcm_desser_mant;
                            lobReturn.fcm_valser_mant = lobjRegPer.fcm_valser_mant;
                            lobReturn.fcm_punuvr_mant = lobjRegPer.fcm_punuvr_mant;
                            lobReturn.fcm_valren_mant = lobjRegPer.fcm_valren_mant;
                            lobReturn.fcm_tipccp_mant = lobjRegPer.fcm_tipccp_mant;
                            lobReturn.fcm_vficop_mant = lobjRegPer.fcm_vficop_mant;
                            lobReturn.fcm_facvmc_mant = lobjRegPer.fcm_facvmc_mant;
                            lobReturn.fcm_codman_mans = lobjRegPer.fcm_codman_mans;
                        }
                        #endregion
                    }
                    else
                    {
                        // 3= No usar personalizados  - la lista es para restringir servicios del contrato
                        lobReturn = new EFfcmmanservicios();
                        lobReturn.fcm_codser_mant = "E%1";
                        lobReturn.fcm_desser_mant = "(" + tcrCodigoDigitacion + ") No esta permitido en contrato (ver servicios personalizados para el contrato)";
                    }
                }
                else if (tcrServPersonalizados == "2")
                {
                    lobReturn = new EFfcmmanservicios();
                    lobReturn.fcm_codser_mant = "E%1";
                    lobReturn.fcm_desser_mant = "(" + tcrCodigoDigitacion + ") No existe en servicios personalizados para el contrato";
                }
                else
                {
                    lobReturn = fobRegBuscarIuFcmmanserviciosProgAux(tcrCodigoDigitacion, tcrCodigoTarifario);
                }
            };
            return lobReturn;
        }
        public static EFfcmmanservicios fobRegBuscarIuFcmmanserviciosProgAux(String tcrCodigoDigitacion, String tcrCodigoTarifario)
        {
            var lobReturn = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_coddig_mant == tcrCodigoDigitacion && p.fcm_codman_mans == tcrCodigoTarifario);

            if (lobReturn != null)
            {
                // Verificar que este activo en servicis IPS
                var lobReturnIps = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_coddig_mant == tcrCodigoDigitacion);
                if (lobReturnIps != null)
                {
                    if (lobReturnIps.fcm_estser_sips != "1")
                    {
                        lobReturn.fcm_codser_mant = "E%1";
                        lobReturn.fcm_desser_mant = "(" + tcrCodigoDigitacion + ") servicios no esta activo en configuración servicios IPS";
                    }
                }
            }

            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMCENPRODUCCIO: Centros de produccion asistenciales
        //-------------------------------------------------------
        #region Buscar FCMCENPRODUCCIO: Logica
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TITULO: Centros de produccion asistenciales</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Centros de produccion, existentes en las diferentes areas de
        /// prestacion de servicios medicos ejm : 1110 = Consulta Médica
        /// General   1145 = Consulta de Nutrición (esta tabla pertenece
        /// a facturacion)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmcenproduccio(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMCENPRODUCCIO: String
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TITULO: Centros de produccion asistenciales</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_descpr_cpro
        /// (campo 'DE' de la tabla fcmcenproduccio) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Centros de produccion, existentes en las diferentes areas de
        /// prestacion de servicios medicos ejm : 1110 = Consulta Médica
        /// General   1145 = Consulta de Nutrición (esta tabla pertenece
        /// a facturacion)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmcenproduccio(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_descpr_cpro;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMCENPRODUCCIO: Registro
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TITULO: Centros de produccion asistenciales</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmcenproduccio desde la tabla
        /// fcmcenproduccio cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Centros de produccion, existentes en las diferentes areas de
        /// prestacion de servicios medicos ejm : 1110 = Consulta Médica
        /// General   1145 = Consulta de Nutrición (esta tabla pertenece
        /// a facturacion)
        /// </para>
        /// </summary>
        public static EFfcmcenproduccio fobRegBuscarFcmcenproduccio(string tcrCodigo)
        {
            EFfcmcenproduccio lobReturn = new EFfcmcenproduccio();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMACTQUIRURGIC: Forma de realizacion acto quirurgico
        //-------------------------------------------------------
        #region Buscar FCMACTQUIRURGIC: Logica
        /// <summary>
        /// <para>TABLA: fcmactquirurgic</para>
        /// <para>TITULO: Forma de realizacion acto quirurgico</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmactquirurgic(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmactquirurgic.FirstOrDefault(p => p.fcm_codaqx_aqir == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMACTQUIRURGIC: String
        /// <summary>
        /// <para>TABLA: fcmactquirurgic</para>
        /// <para>TITULO: Forma de realizacion acto quirurgico</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desaqx_aqir
        /// (campo 'DE' de la tabla fcmactquirurgic) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmactquirurgic(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmactquirurgic.FirstOrDefault(p => p.fcm_codaqx_aqir == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desaqx_aqir;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMACTQUIRURGIC: Registro
        /// <summary>
        /// <para>TABLA: fcmactquirurgic</para>
        /// <para>TITULO: Forma de realizacion acto quirurgico</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmactquirurgic desde la tabla
        /// fcmactquirurgic cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public static EFfcmactquirurgic fobRegBuscarFcmactquirurgic(string tcrCodigo)
        {
            EFfcmactquirurgic lobReturn = new EFfcmactquirurgic();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmactquirurgic.FirstOrDefault(p => p.fcm_codaqx_aqir == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMMANTARIFARIO: Lista de manuales tarifarios
        //-------------------------------------------------------
        #region Buscar FCMMANTARIFARIO: Logica
        /// <summary>
        /// <para>TABLA: fcmmantarifario</para>
        /// <para>TITULO: Lista de manuales tarifarios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de manuales tarifarios disponibles o creados según las
        /// necesidades, ajustados a los tipos de manuales tarifarios basicos
        /// de la tabla:SIATIPTARIFARIO
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmantarifario(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmantarifario.FirstOrDefault(p => p.fcm_codman_mans == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMANTARIFARIO: String
        /// <summary>
        /// <para>TABLA: fcmmantarifario</para>
        /// <para>TITULO: Lista de manuales tarifarios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desman_mans
        /// (campo 'DE' de la tabla fcmmantarifario) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de manuales tarifarios disponibles o creados según las
        /// necesidades, ajustados a los tipos de manuales tarifarios basicos
        /// de la tabla:SIATIPTARIFARIO
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmmantarifario(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmantarifario.FirstOrDefault(p => p.fcm_codman_mans == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desman_mans;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMMANTARIFARIO: Registro
        /// <summary>
        /// <para>TABLA: fcmmantarifario</para>
        /// <para>TITULO: Lista de manuales tarifarios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmantarifario desde la tabla
        /// fcmmantarifario cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de manuales tarifarios disponibles o creados según las
        /// necesidades, ajustados a los tipos de manuales tarifarios basicos
        /// de la tabla:SIATIPTARIFARIO
        /// </para>
        /// </summary>
        public static EFfcmmantarifario fobRegBuscarFcmmantarifario(string tcrCodigo)
        {
            EFfcmmantarifario lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmantarifario.FirstOrDefault(p => p.fcm_codman_mans == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMMAESCAJATRAN: Maestro Transacciones caja
        //-------------------------------------------------------
        #region Buscar FCMMAESCAJATRAN: Logica
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TITULO: Maestro Transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los datos de recibos de cajas que se
        /// generen en facturacion por concepto de pagos en efectivo o
        /// en cheque de: copagos, cuotas moderadoras, pagos particulares
        /// y otros pagos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaescajatran(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMAESCAJATRAN: String
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TITULO: Maestro Transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_descon_mtrc
        /// (campo 'DE' de la tabla fcmmaescajatran) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los datos de recibos de cajas que se
        /// generen en facturacion por concepto de pagos en efectivo o
        /// en cheque de: copagos, cuotas moderadoras, pagos particulares
        /// y otros pagos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmmaescajatran(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_descon_mtrc;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMMAESCAJATRAN: Registro
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TITULO: Maestro Transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmaescajatran desde la tabla
        /// fcmmaescajatran cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los datos de recibos de cajas que se
        /// generen en facturacion por concepto de pagos en efectivo o
        /// en cheque de: copagos, cuotas moderadoras, pagos particulares
        /// y otros pagos
        /// </para>
        /// </summary>
        public static EFfcmmaescajatran fobRegBuscarFcmmaescajatran(string tcrCodigo)
        {
            EFfcmmaescajatran lobReturn = new EFfcmmaescajatran();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMDESCUEAUTORI: Maestro para registrar los descuentos solicitados y  autoriz
        //-------------------------------------------------------
        #region Buscar FCMDESCUEAUTORI: Logica
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TITULO: Maestro para registrar los descuentos solicitados y  autoriz</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar los descuentos solicitados y  autorizados
        /// en pagos de servicios, copagos y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmdescueautori(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMDESCUEAUTORI: String
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TITULO: Maestro para registrar los descuentos solicitados y  autoriz</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_notaut_ades
        /// (campo 'DE' de la tabla fcmdescueautori) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar los descuentos solicitados y  autorizados
        /// en pagos de servicios, copagos y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmdescueautori(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_notaut_ades;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMDESCUEAUTORI: Registro
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TITULO: Maestro para registrar los descuentos solicitados y  autoriz</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmdescueautori desde la tabla
        /// fcmdescueautori cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar los descuentos solicitados y  autorizados
        /// en pagos de servicios, copagos y otros
        /// </para>
        /// </summary>
        public static EFfcmdescueautori fobRegBuscarFcmdescueautori(string tcrCodigo)
        {
            EFfcmdescueautori lobReturn = new EFfcmdescueautori();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMGRQUIRURGICO: Archivo para grupo quirurgicos
        //-------------------------------------------------------
        #region Buscar FCMGRQUIRURGICO: Logica
        /// <summary>
        /// <para>TABLA: fcmgrquirurgico</para>
        /// <para>TITULO: Archivo para grupo quirurgicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo para guardar los diferentes grupos quirurgicos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmgrquirurgico(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmgrquirurgico.FirstOrDefault(p => p.fcm_codgqx_grqx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMGRQUIRURGICO: String
        /// <summary>
        /// <para>TABLA: fcmgrquirurgico</para>
        /// <para>TITULO: Archivo para grupo quirurgicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desgqx_grqx
        /// (campo 'DE' de la tabla fcmgrquirurgico) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo para guardar los diferentes grupos quirurgicos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmgrquirurgico(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmgrquirurgico.FirstOrDefault(p => p.fcm_codgqx_grqx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desgqx_grqx;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMGRQUIRURGICO: Registro
        /// <summary>
        /// <para>TABLA: fcmgrquirurgico</para>
        /// <para>TITULO: Archivo para grupo quirurgicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmgrquirurgico desde la tabla
        /// fcmgrquirurgico cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo para guardar los diferentes grupos quirurgicos
        /// </para>
        /// </summary>
        public static EFfcmgrquirurgico fobRegBuscarFcmgrquirurgico(string tcrCodigo)
        {
            EFfcmgrquirurgico lobReturn = new EFfcmgrquirurgico();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmgrquirurgico.FirstOrDefault(p => p.fcm_codgqx_grqx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMMANSERCOMPAQ: Archivo para Codigos servicios que hacen un paquete de servi
        //-------------------------------------------------------
        #region Buscar FCMMANSERCOMPAQ: Registro
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TITULO: Archivo para Codigos servicios que hacen un paquete de servi</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmansercompaq desde la tabla
        /// fcmmansercompaq cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Archivo para guardar los codigos de servicios que hacen parte
        /// de un paquete de servicios, solo para los servicios en la tabla
        /// FCMMANSERVICIOS, que esten marcados como paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmansercompaq fobRegBuscarFcmmansercompaq(string tcrCodigo)
        {
            EFfcmmansercompaq lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmansercompaq.FirstOrDefault(p => p.fcm_idesec_copq == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMANSERCOMPAQ: Registro maestro R1
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TITULO: Archivo para Codigos servicios que hacen un paquete de servi</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmansercompaq desde la tabla
        /// fcmmansercompaq dado el codigo del registro maestro (fcm_idesec_mant),  cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Archivo para guardar los codigos de servicios que hacen parte
        /// de un paquete de servicios, solo para los servicios en la tabla
        /// FCMMANSERVICIOS, que esten marcados como paquetes de servicios
        /// </para>
        /// </summary>
        public static EFfcmmansercompaq fobRegBuscarFcmmansercompaqR1(string tcrCodigo)
        {
            EFfcmmansercompaq lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmansercompaq.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMANSERCOMPAQ: Registro maestro Lista
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TITULO: Archivo para Codigos servicios que hacen un paquete de servi</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve lista de tipo EFfcmmansercompaq desde la tabla
        /// fcmmansercompaq dado el codigo del registro maestro (fcm_idesec_mant),  cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Archivo para guardar los codigos de servicios que hacen parte
        /// de un paquete de servicios, solo para los servicios en la tabla
        /// FCMMANSERVICIOS, que esten marcados como paquetes de servicios
        /// </para>
        /// </summary>
        public static List<EFfcmmanservicios> fobRegBuscarFcmmansercompaqR1List(string tcrCodigo)
        {
            List<EFfcmmanservicios> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                //var lobjRegistro = from tmp in _context.Fcmmansercompaq where tmp.fcm_idesec_mant == tcrCodigo select tmp;

                var lobjRegistro = from tmpPqx in _context.Fcmmansercompaq
                                   join tmpServ in _context.Fcmmanservicios on tmpPqx.fcm_idesec_mant equals tmpServ.fcm_idesec_mant
                                   where tmpPqx.fcm_idesec_mant == tcrCodigo
                                   select tmpServ;

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro.ToList();
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMMAEDETALLFAC: Detalles servicios medicos prestados
        //-------------------------------------------------------
        #region Buscar FCMMAEDETALLFAC: Logica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaedetallfac(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMMAEDETALLFAC: String
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desser_dfac
        /// (campo 'DE' de la tabla fcmmaedetallfac) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmmaedetallfac(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desser_dfac;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMMAEDETALLFAC: Registro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmmaedetallfac desde la tabla
        /// fcmmaedetallfac cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static EFfcmmaedetallfac fobRegBuscarFcmmaedetallfac(string tcrCodigo)
        {
            EFfcmmaedetallfac lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMAEDETALLFAC: Registro Relacion R1
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Dado el codigo Admision, devuelve lista de registros de tipo EFfcmmaedetallfac desde la tabla
        /// fcmmaedetallfac, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static List<EFfcmmaedetallfac> fobRegBuscarFcmmaedetallfacR1(string tcrCodigoAdmision, String tcrEstadoRegistro)
        {
            List<EFfcmmaedetallfac> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrWhiteSpace(tcrEstadoRegistro))
                {
                    lobReturn = (from tmp in _context.Fcmmaedetallfac
                                 where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp).ToList();
                }
                else 
                {
                    lobReturn = (from tmp in _context.Fcmmaedetallfac
                                 where tmp.adm_secadm_rgad == tcrCodigoAdmision && 
                                       tmp.sis_estpro_espr == tcrEstadoRegistro select tmp).ToList();

                }
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMMAEDETALLFAC: Registro dado Id Paciente Codigo digitacion y rango fechas 
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Dado el codigo unico paciente, el codigo digitacion servicio y rango de fechas devuelve un registro  tipo fcmmaedetallfac, cuando no exite retorna  null.</para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static EFfcmmaedetallfac fobRegServicioFactIdUsuarioFecha(String tcrIdUsuario, String tcrCodigoDigitacion,
                                                                         DateTime tdaFechaInicial, DateTime tdaFechaFinal)
        {
            EFfcmmaedetallfac lobReturn = null;
            using (_context = new DbAplicacion())
            {
                lobReturn = (from tmp in _context.Fcmmaedetallfac
                             where tmp.sia_idesec_usua == tcrIdUsuario &&
                                   tmp.fcm_coddig_mant == tcrCodigoDigitacion &&
                                   tmp.fcm_fecser_dfac >= tdaFechaInicial &&
                                   tmp.fcm_fecser_dfac <= tdaFechaFinal &&
                                   tmp.sis_estpro_espr == "2"
                             select tmp).FirstOrDefault();

            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMCUENTACOBRMS: Maestro de facturas - Cuentas de cobro facturación
        //-------------------------------------------------------
        #region Buscar FCMCUENTACOBRMS: Logica
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TITULO: Maestro de facturas - Cuentas de cobro facturación</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para realizar la clasificacion de facturas para cuentras
        /// de cobro a las EPS
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmcuentacobrms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMCUENTACOBRMS: String
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TITULO: Maestro de facturas - Cuentas de cobro facturación</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_descue_mfcb
        /// (campo 'DE' de la tabla fcmcuentacobrms) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para realizar la clasificacion de facturas para cuentras
        /// de cobro a las EPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarFcmcuentacobrms(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_descue_mfcb;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMCUENTACOBRMS: Registro
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TITULO: Maestro de facturas - Cuentas de cobro facturación</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmcuentacobrms desde la tabla
        /// fcmcuentacobrms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para realizar la clasificacion de facturas para cuentras
        /// de cobro a las EPS
        /// </para>
        /// </summary>
        public static EFfcmcuentacobrms fobRegBuscarFcmcuentacobrms(string tcrCodigo)
        {
            EFfcmcuentacobrms lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFRECUENCIUSO: Registro historico frecuencia uso servicios
        //-------------------------------------------------------
        #region Buscar FCMFRECUENCIUSO: Logica
        /// <summary>
        /// <para>TABLA: fcmfrecuenciuso</para>
        /// <para>TITULO: Registro historico frecuencia uso servicios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro historico frecuencia uso servicios, según parametros
        /// configurados para validacion de frecuencia en maestro de servicios
        /// IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfrecuenciuso(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfrecuenciuso.FirstOrDefault(p => p.fcm_idesec_fcfu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMFRECUENCIUSO: Registro
        /// <summary>
        /// <para>TABLA: fcmfrecuenciuso</para>
        /// <para>TITULO: Registro historico frecuencia uso servicios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfrecuenciuso desde la tabla
        /// fcmfrecuenciuso cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro historico frecuencia uso servicios, según parametros
        /// configurados para validacion de frecuencia en maestro de servicios
        /// IPS
        /// </para>
        /// </summary>
        public static EFfcmfrecuenciuso fobRegBuscarFcmfrecuenciuso(String tcrCodigo)
        {
            EFfcmfrecuenciuso lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfrecuenciuso.FirstOrDefault(p => p.fcm_idesec_fcfu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMFRECUENCIUSO: Registro Codigo digitacion e Id unico
        /// <summary>
        /// <para>TABLA: fcmfrecuenciuso</para>
        /// <para>TITULO: Registro historico frecuencia uso servicios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfrecuenciuso desde la tabla
        /// fcmfrecuenciuso cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Consulta por Id del usuario y Codigo digitacion en Registro historico frecuencia uso servicios IPS
        /// </para>
        /// </summary>
        public static EFfcmfrecuenciuso fobRegBuscarFcmfrecuenciuso(String tcrIdUnicoUsuario, String tcrCodigoDigitacion)
        {
            EFfcmfrecuenciuso lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfrecuenciuso.FirstOrDefault(p => p.sia_idesec_usua == tcrIdUnicoUsuario && p.fcm_coddig_mant == tcrCodigoDigitacion);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMSECRFACTURAS: Secuenciales resolución numero de facturas
        //-------------------------------------------------------
        #region Buscar FCMSECRFACTURAS: Logica
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TITULO: Secuenciales resolución numero de facturas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para gestion de secuenciales de facturación asignados
        /// por la Dian con fecha inicio vigencia y estado en el sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmsecrfacturas(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMSECRFACTURAS: String
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TITULO: Secuenciales resolución numero de facturas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_desres_srfa
        /// (campo 'DE' de la tabla fcmsecrfacturas) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para gestion de secuenciales de facturación asignados
        /// por la Dian con fecha inicio vigencia y estado en el sistema
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmsecrfacturas(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desres_srfa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMSECRFACTURAS: Registro
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TITULO: Secuenciales resolución numero de facturas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmsecrfacturas desde la tabla
        /// fcmsecrfacturas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para gestion de secuenciales de facturación asignados
        /// por la Dian con fecha inicio vigencia y estado en el sistema
        /// </para>
        /// </summary>
        public static EFfcmsecrfacturas fobRegBuscarFcmsecrfacturas(String tcrCodigo)
        {
            EFfcmsecrfacturas lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMSOATMANUALMA: Maestro listado  tarifario soat
        //-------------------------------------------------------
        #region Buscar FCMSOATMANUALMA: Logica
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TITULO: Maestro listado  tarifario soat</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios con puntajes y valores según tarifario SOAT,
        /// para consulta y referencia actualizable cada año
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmsoatmanualma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMSOATMANUALMA: String
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TITULO: Maestro listado  tarifario soat</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_desman_soat
        /// (campo 'DE' de la tabla fcmsoatmanualma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios con puntajes y valores según tarifario SOAT,
        /// para consulta y referencia actualizable cada año
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmsoatmanualma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desman_soat;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMSOATMANUALMA: Registro
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TITULO: Maestro listado  tarifario soat</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmsoatmanualma desde la tabla
        /// fcmsoatmanualma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios con puntajes y valores según tarifario SOAT,
        /// para consulta y referencia actualizable cada año
        /// </para>
        /// </summary>
        public static EFfcmsoatmanualma fobRegBuscarFcmsoatmanualma(String tcrCodigo)
        {
            EFfcmsoatmanualma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEUNSPSCDPRODU: UNSPSC Para productos
        //-------------------------------------------------------
        #region Buscar FCMFEUNSPSCDPRODU: Logica
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TITULO: UNSPSC Para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// UNSPSC Para productos  (Código Estándar de Productos y Servicios
        /// de Naciones Unidas)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfeunspscdprodu(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscdprodu.FirstOrDefault(p => p.fcm_codpro_fcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCDPRODU: String
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TITULO: UNSPSC Para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_despro_fcpr
        /// (campo 'DE' de la tabla fcmfeunspscdprodu) cuando no exite,
        /// retorna String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// UNSPSC Para productos  (Código Estándar de Productos y Servicios
        /// de Naciones Unidas)
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmfeunspscdprodu(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscdprodu.FirstOrDefault(p => p.fcm_codpro_fcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_despro_fcpr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCDPRODU: Registro
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TITULO: UNSPSC Para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfeunspscdprodu desde la tabla
        /// fcmfeunspscdprodu cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// UNSPSC Para productos  (Código Estándar de Productos y Servicios
        /// de Naciones Unidas)
        /// </para>
        /// </summary>
        public static EFfcmfeunspscdprodu fobRegBuscarFcmfeunspscdprodu(String tcrCodigo)
        {
            EFfcmfeunspscdprodu lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscdprodu.FirstOrDefault(p => p.fcm_codpro_fcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEUNSPSCASEGME: Segmento de mercado UNSPSC para productos
        //-------------------------------------------------------
        #region Buscar FCMFEUNSPSCASEGME: Logica
        /// <summary>
        /// <para>TABLA: fcmfeunspscasegme</para>
        /// <para>TITULO: Segmento de mercado UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Segmento de mercado UNSPSC para clasificacion base del producto
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfeunspscasegme(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscasegme.FirstOrDefault(p => p.fcm_codseg_fcsg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCASEGME: String
        /// <summary>
        /// <para>TABLA: fcmfeunspscasegme</para>
        /// <para>TITULO: Segmento de mercado UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_desseg_fcsg
        /// (campo 'DE' de la tabla fcmfeunspscasegme) cuando no exite,
        /// retorna String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Segmento de mercado UNSPSC para clasificacion base del producto
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmfeunspscasegme(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscasegme.FirstOrDefault(p => p.fcm_codseg_fcsg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desseg_fcsg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCASEGME: Registro
        /// <summary>
        /// <para>TABLA: fcmfeunspscasegme</para>
        /// <para>TITULO: Segmento de mercado UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfeunspscasegme desde la tabla
        /// fcmfeunspscasegme cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Segmento de mercado UNSPSC para clasificacion base del producto
        /// </para>
        /// </summary>
        public static EFfcmfeunspscasegme fobRegBuscarFcmfeunspscasegme(String tcrCodigo)
        {
            EFfcmfeunspscasegme lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscasegme.FirstOrDefault(p => p.fcm_codseg_fcsg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEUNSPSCBFAMIL: Familia UNSPSC para productos
        //-------------------------------------------------------
        #region Buscar FCMFEUNSPSCBFAMIL: Logica
        /// <summary>
        /// <para>TABLA: fcmfeunspscbfamil</para>
        /// <para>TITULO: Familia UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion familia UNSPSC para productos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfeunspscbfamil(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscbfamil.FirstOrDefault(p => p.fcm_codfam_fcfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCBFAMIL: String
        /// <summary>
        /// <para>TABLA: fcmfeunspscbfamil</para>
        /// <para>TITULO: Familia UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_desfam_fcfa
        /// (campo 'DE' de la tabla fcmfeunspscbfamil) cuando no exite,
        /// retorna String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion familia UNSPSC para productos
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmfeunspscbfamil(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscbfamil.FirstOrDefault(p => p.fcm_codfam_fcfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desfam_fcfa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCBFAMIL: Registro
        /// <summary>
        /// <para>TABLA: fcmfeunspscbfamil</para>
        /// <para>TITULO: Familia UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfeunspscbfamil desde la tabla
        /// fcmfeunspscbfamil cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion familia UNSPSC para productos
        /// </para>
        /// </summary>
        public static EFfcmfeunspscbfamil fobRegBuscarFcmfeunspscbfamil(String tcrCodigo)
        {
            EFfcmfeunspscbfamil lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspscbfamil.FirstOrDefault(p => p.fcm_codfam_fcfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEUNSPSCCCLASE: Clase UNSPSC para productos
        //-------------------------------------------------------
        #region Buscar FCMFEUNSPSCCCLASE: Logica
        /// <summary>
        /// <para>TABLA: fcmfeunspsccclase</para>
        /// <para>TITULO: Clase UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion clases UNSPSC para productos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfeunspsccclase(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspsccclase.FirstOrDefault(p => p.fcm_codcla_fccl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCCCLASE: String
        /// <summary>
        /// <para>TABLA: fcmfeunspsccclase</para>
        /// <para>TITULO: Clase UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en fcm_descla_fccl
        /// (campo 'DE' de la tabla fcmfeunspsccclase) cuando no exite,
        /// retorna String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion clases UNSPSC para productos
        /// </para>
        /// </summary>
        public static String fcrDEBuscarFcmfeunspsccclase(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspsccclase.FirstOrDefault(p => p.fcm_codcla_fccl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_descla_fccl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar FCMFEUNSPSCCCLASE: Registro
        /// <summary>
        /// <para>TABLA: fcmfeunspsccclase</para>
        /// <para>TITULO: Clase UNSPSC para productos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfeunspsccclase desde la tabla
        /// fcmfeunspsccclase cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Clasificacion clases UNSPSC para productos
        /// </para>
        /// </summary>
        public static EFfcmfeunspsccclase fobRegBuscarFcmfeunspsccclase(String tcrCodigo)
        {
            EFfcmfeunspsccclase lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfeunspsccclase.FirstOrDefault(p => p.fcm_codcla_fccl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // flsSeleccionFacturasGeneral: Filtro avanzado para informes de servicios facturados
        //-------------------------------------------------------
        #region flsBrowserSeleccionFacturasGeneral: Filtro avanzado para informes de servicios facturados
        /// <summary>
        /// <para>Filtro avanzado para informes de servicios facturados</para>
        /// <para>Ventana Filtro avanzado para informes de servicios facturados</para>
        /// </summary>
        public static List<TmpListaSeleccion> flsBrowserSeleccionFacturasGeneral(Window tobOwner, String tcrFechaInicio, String tcrFechaFinal)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            oApp.gcrWinMsCodigoMensaje = "%X%";
            List<TmpListaSeleccion> lobReturn = null;

            var lobForm     = new FacturacionResumenFiltro(tcrFechaInicio, tcrFechaFinal);
            lobForm.Owner   = tobOwner;
            lobForm.ShowDialog();

            // Revisar si se devolvio un parametro
            if (oApp.gcrWinMsCodigoMensaje != "%X%")
            {
                lobReturn = new List<TmpListaSeleccion>();
                String[] larArray = (oApp.gcrWinMsCodigoMensaje).Split(",".ToCharArray());
                var i = 0;

                for (i = 0; i < larArray.Length; i++)
                {
                    var lobReg = new TmpListaSeleccion { IdIndice = i.ToString(), ValorSeleccion = larArray[i] };

                    lobReturn.Add(lobReg);
                }
            }

            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEMAESRAZSOCMA: Maestro Razon social de la empresa
        //-------------------------------------------------------
        #region Buscar FCMFEMAESRAZSOCMA: Registro con ID unico
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TITULO: Maestro Razon social de la empresa</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfemaesrazsocma desde la tabla
        /// fcmfemaesrazsocma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Razones sociales con las que se puede enviar documentos
        /// eletronicos  firmados a la DIAN
        /// </para>
        /// </summary>
        public static EFfcmfemaesrazsocma FobRegBuscarFcmfemaesrazsocma(String tcrCodigo)
        {
            EFfcmfemaesrazsocma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMFEMAESRAZSOCMA: Registro con NIT
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TITULO: Maestro Razon social de la empresa</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfemaesrazsocma desde la tabla
        /// fcmfemaesrazsocma dado el NIT como parametro, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Razones sociales con las que se puede enviar documentos
        /// eletronicos  firmados a la DIAN
        /// </para>
        /// </summary>
        public static EFfcmfemaesrazsocma FobRegBuscarFcmfemaesrazsocmaNIT(String tcrNitEmpresa)
        {
            EFfcmfemaesrazsocma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_numdoc_fcem == tcrNitEmpresa);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // FCMFEMAESFACTEFMA: Maestro de facturas electronicas
        //-------------------------------------------------------
        #region Buscar FCMFEMAESFACTEFMA: ID unico Registro
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TITULO: Maestro de facturas electronicas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfemaesfactefma desde la tabla
        /// fcmfemaesfactefma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas  electronicas Notas debito y Notas Credito
        /// </para>
        /// </summary>
        public static EFfcmfemaesfactefma FobRegBuscarFcmfemaesfactefma(String tcrCodigo)
        {
            EFfcmfemaesfactefma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_secreg_mfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                }
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMFEMAESFACTEFMA: Registro Por Numero Documento
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TITULO: Maestro de facturas electronicas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfemaesfactefma desde la tabla
        /// fcmfemaesfactefma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas  electronicas Notas debito y Notas Credito
        /// </para>
        /// </summary>
        public static EFfcmfemaesfactefma FobRegBuscarFcmfemaesfactefmaDoc(String tcrNumeroDoc)
        {
            EFfcmfemaesfactefma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_numfac_mfac == tcrNumeroDoc);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                }
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMFEMAESFACTEFMA: Registro Numero Documento para referencias
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TITULO: Maestro de facturas electronicas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo DataRow desde la tabla
        /// fcmfemaesfactefma y la tabla adquirentes, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Maestro facturas electronicas Notas debito y Notas Credito</para>
        /// </summary>
        public static DataRow FobRegBuscarFcmfemaesfactefmaDataRow(string tcrNumeroDoc, string tctIdRazonSocial)
        {
            DataRow lobReturn = null;
            var lcrSqlSelect = "SELECT fcmfemaesfactefma.fcm_secreg_mfac," +
                                       "fcmfemaesfactefma.fcm_secraz_fcem," +
                                       "fcmfemaesfactefma.fcm_numfac_mfac," +
                                       "fcmfemaesfactefma.fcm_typdoc_fctd," +
                                       "fcmfetipodocument.fcm_destyp_fctd," +
                                       "fcmfemaesfactefma.fcm_fecfac_mfac," +
                                       "fcmfemaesfactefma.fcm_horfac_mfac," +
                                       "fcmfemaesfactefma.fcm_notdoc_mfac," +
                                       "fcmfemaesfactefma.fcm_facori_mfac," +
                                       "fcmfemaesfactefma.fcm_idcufe_mfac," +
                                       "fcmfemaesfactefma.fcm_diafec_mfac," +
                                       "fcmfemaesfactefma.fcm_diahor_mfac," +
                                       "fcmfemaesfactefma.fcm_metpag_mfac," +
                                       "fcmfemaesfactefma.fcm_codest_fcws," +
                                       "fcmfeestadoresdian.fcm_desest_fcws," +
                                       "sismaesterceros.sis_tipper_sitr," +
                                       "sismaesterceros.sis_numide_sitr," +
                                       "sismaesterceros.sis_razsoc_sitr," +
                                       "sismaesterceros.sis_nomcon_sitr," +
                                       "sismaesterceros.sis_telefo_sitr," +
                                       "sismaesterceros.sis_emailc_sitr," +
                                       "sismaesterceros.sis_direcc_sitr," +
                                       "sismaesterceros.sis_codmun_muni," +
                                       "sistabmunicipio.sis_nommun_muni," +
                                       "sismaesterceros.sis_coddep_dpto," +
                                       "sistabdepartame.sis_desdep_dpto," +
                                       "sismaesterceros.sis_codpos_sicp," +
                                       "fcmfemaesfactefma.fcm_valdes_dfac," +
                                       "fcmfemaesfactefma.fcm_valcpa_dfac," +
                                       "fcmfemaesfactefma.fcm_valcmo_dfac," +
                                       "fcmfemaesfactefma.fcm_valusu_dfac," +
                                       "fcmfemaesfactefma.fcm_valbru_dfac," +
                                       "fcmfemaesfactefma.fcm_valsub_dfac," +
                                       "fcmfemaesfactefma.fcm_valfac_dfac " +
                                    "FROM fcmfemaesfactefma " +
                                      "INNER JOIN fcmfetipodocument ON(fcmfemaesfactefma.fcm_typdoc_fctd = fcmfetipodocument.fcm_typdoc_fctd) " +
                                      "INNER JOIN sismaesterceros ON(fcmfemaesfactefma.sis_idterc_sitr = sismaesterceros.sis_idterc_sitr) " +
                                      "INNER JOIN sistabmunicipio ON(sismaesterceros.sis_idemun_muni = sistabmunicipio.sis_idemun_muni) " +
                                      "INNER JOIN sistabdepartame ON(sismaesterceros.sis_coddep_dpto = sistabdepartame.sis_coddep_dpto) " +
                                      "INNER JOIN fcmfeestadoresdian ON(fcmfemaesfactefma.fcm_codest_fcws = fcmfeestadoresdian.fcm_codest_fcws) " +
                                    "WHERE fcmfemaesfactefma.fcm_numfac_mfac = '" + tcrNumeroDoc + "' AND "+
                                          "fcmfemaesfactefma.fcm_secraz_fcem = '" + tctIdRazonSocial + "'";

            var lobjRegistro = Funciones.fobConsultaSqlDataAdapter(lcrSqlSelect);

            if (lobjRegistro != null && lobjRegistro.Rows.Count > 0)
            {
                lobReturn = lobjRegistro.Rows[0];
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // FCMFETIPODOCUMENT: Tipos de documentos para envio a Dian
        //-------------------------------------------------------
        #region Buscar FCMFETIPODOCUMENT: Registro
        /// <summary>
        /// <para>TABLA: fcmfetipodocument</para>
        /// <para>TITULO: Tipos de documentos para envio a Dian</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFfcmfetipodocument desde la tabla
        /// fcmfetipodocument cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica
        /// de Venta 02=Factura electrónica venta-xportación 91=Nota Credito
        /// 92=Nota Debito y otros
        /// </para>
        /// </summary>
        public static EFfcmfetipodocument fobRegBuscarFcmfetipodocument(String tcrCodigo)
        {
            EFfcmfetipodocument lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfetipodocument.FirstOrDefault(p => p.fcm_typdoc_fctd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // FCMMANSERVICATE: Categorias servicios
        //-------------------------------------------------------
        #region Buscar FCMMANSERVICATE: Registro
        /// <summary>
        /// <para>TABLA: fcmmanservicate</para>
        /// <para>TITULO: Categorias servicios</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO: 
        /// Devuelve un registro de tipo EFfcmmanservicate desde la tabla fcmmanservicate cuando no exite
        /// retorna  null.
        /// </para>
        /// <para>DESCRIPCIÓN TABLA: Clasificacion por categoria para servicios IPS</para>
        /// </summary>
        public static EFfcmmanservicate fobRegBuscarFcmmanservicate(String tcrCodigo)
        {
            EFfcmmanservicate lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicate.FirstOrDefault(p => p.fcm_idesec_fcct == tcrCodigo);
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

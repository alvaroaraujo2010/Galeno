using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class CTOValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // CTO - CONTRATACION ASEGURADORES SERVICIOS DE SALUD
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // CTOMAESCONTRATO: Maestro contratos con  EPS o aseguradores
        //-------------------------------------------------------
        #region Buscar CTOMAESCONTRATO: Logica
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomaescontrato(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CTOMAESCONTRATO: String
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cto_descon_cont
        /// (campo 'DE' de la tabla ctomaescontrato) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCtomaescontrato(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cto_descon_cont;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CTOMAESCONTRATO: Registro
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomaescontrato dado el secuencial unico, desde la tabla
        /// ctomaescontrato cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static EFctomaescontrato fobRegBuscarCtomaescontrato(string tcrCodigo)
        {
            EFctomaescontrato lobReturn = new EFctomaescontrato();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar CTOMAESCONTRATO: Registro dado secuencial id unico
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomaescontrato dado el secuencial unico, desde la tabla
        /// ctomaescontrato cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static EFctomaescontrato fobRegBuscarCtomaescontratoEx(string tcrCodigo)
        {
            EFctomaescontrato lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar FCMFEMAESFACTEFMA: Registro Numero Documento para referencias
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro con datos de la razon social asociada al contrato y 
        /// la resolucion de facturacio Dian
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static DataRow FobRegBuscarContratoRazonSocialDataRow(string tctIdContrato)
        {
            DataRow lobReturn = null;
            var lcrSqlSelect = "SELECT ctomaescontrato.cto_seccon_cont," +
                                       "ctomaescontrato.cto_nrocon_cont," +
                                       "ctomaescontrato.sia_codeps_teps," +
                                       "ctomaescontrato.sis_idterc_sitr," +
                                       "fcmfemaesrazsocma.fcm_secraz_fcem," +
                                       "fcmfemaesrazsocma.fcm_numdoc_fcem," +
                                       "fcmfemaesrazsocma.fcm_digver_fcem," +
                                       "fcmfemaesrazsocma.fcm_codips_fcem," +
                                       "fcmfemaesrazsocma.fcm_nomcom_fcem," +
                                       "fcmfemaesrazsocma.fcm_razsoc_fcem," +
                                       "fcmsecrfacturas.fcm_secres_srfa," +
                                       "fcmsecrfacturas.fcm_numres_srfa," +
                                       "fcmsecrfacturas.fcm_desres_srfa," +
                                       "fcmsecrfacturas.fcm_notenc_srfa," +
                                       "fcmsecrfacturas.fcm_noppag_srfa " +
                                    "FROM ctomaescontrato " +
                                      "INNER JOIN fcmfemaesrazsocma ON(ctomaescontrato.fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem) " +
                                      "INNER JOIN fcmsecrfacturas ON(fcmfemaesrazsocma.fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa) " +
                                    "WHERE ctomaescontrato.cto_seccon_cont = '" + tctIdContrato + "'";

            var lobjRegistro = Funciones.fobConsultaSqlDataAdapter(lcrSqlSelect);

            if (lobjRegistro != null && lobjRegistro.Rows.Count > 0)
            {
                lobReturn = lobjRegistro.Rows[0];
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // CTOMAESCONTRATO IU: Maestro contratos con  EPS o aseguradores
        //-------------------------------------------------------
        #region Buscar IU CTOMAESCONTRATO: Logica
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static bool flgBuscarIuCtomaescontrato(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_nrocon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar IU CTOMAESCONTRATO: String
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cto_descon_cont
        /// (campo 'DE' de la tabla ctomaescontrato) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static string fcrDEBuscarIuCtomaescontrato(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_nrocon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cto_descon_cont;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar IU CTOMAESCONTRATO: Registro
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomaescontrato desde la tabla
        /// ctomaescontrato cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static EFctomaescontrato fobRegBuscarIuCtomaescontrato(string tcrCodigo)
        {
            EFctomaescontrato lobReturn = new EFctomaescontrato();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_nrocon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CTOMAEAFILIADOS: Maestro de afiliados en contrato
        //-------------------------------------------------------
        #region Buscar CTOMAEAFILIADOS: Logica
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TITULO: Maestro de afiliados en contrato</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios afiliados correspondientes a un contrato
        /// contiene datos personales de afiliacion a EPS o algun seguro
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomaeafiliados(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CTOMAEAFILIADOS: String
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TITULO: Maestro de afiliados en contrato</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nomusu_usua
        /// (campo 'DE' de la tabla ctomaeafiliados) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios afiliados correspondientes a un contrato
        /// contiene datos personales de afiliacion a EPS o algun seguro
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCtomaeafiliados(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nomusu_usua;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CTOMAEAFILIADOS: Registro
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TITULO: Maestro de afiliados en contrato</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomaeafiliados desde la tabla
        /// ctomaeafiliados cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios afiliados correspondientes a un contrato
        /// contiene datos personales de afiliacion a EPS o algun seguro
        /// </para>
        /// </summary>
        public static EFctomaeafiliados fobRegBuscarCtomaeafiliados(String tcrCodigo)
        {
            EFctomaeafiliados lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar CTOMAEAFILIADOS: Registro Id usuario
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TITULO: Maestro de afiliados en contrato</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomaeafiliados desde la tabla
        /// ctomaeafiliados cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios afiliados correspondientes a un contrato
        /// contiene datos personales de afiliacion a EPS o algun seguro
        /// </para>
        /// </summary>
        public static EFctomaeafiliados fobRegBuscarCtomaeafiliadosIu(string tcrNumeroIdentificacion)
        {
            EFctomaeafiliados lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.sia_nroide_usua == tcrNumeroIdentificacion);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CTOMANSERVICIOS: Manual ventas servicios personalizados
        //-------------------------------------------------------
        #region Buscar CTOMANSERVICIOS: Logica
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TITULO: Manual ventas servicios personalizados</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro servicios personalizados en cada contrato  para ventas,
        /// derivados de SERVICIOS IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomanservicios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CTOMANSERVICIOS: String
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TITULO: Manual ventas servicios personalizados</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en fcm_desser_mant
        /// (campo 'DE' de la tabla ctomanservicios) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro servicios personalizados en cada contrato  para ventas,
        /// derivados de SERVICIOS IPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCtomanservicios(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.fcm_desser_mant;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CTOMANSERVICIOS: Registro
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TITULO: Manual ventas servicios personalizados</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomanservicios desde la tabla
        /// ctomanservicios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro servicios personalizados en cada contrato  para ventas,
        /// derivados de SERVICIOS IPS
        /// </para>
        /// </summary>
        public static EFctomanservicios fobRegBuscarCtomanservicios(string tcrCodigo)
        {
            EFctomanservicios lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar CTOMANSERVICIOS: Registro
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TITULO: Manual ventas servicios personalizados</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFctomanservicios dado el codigo de digitacion y 
        /// el Id del contrato
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro servicios personalizados en cada contrato  para ventas,
        /// derivados de SERVICIOS IPS
        /// </para>
        /// </summary>
        public static EFctomanservicios fobRegBuscarCtomanserviciosReg(String tcrIDDigitacion, String tcrIdContrato)
        {
            EFctomanservicios lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_seccon_cont == tcrIdContrato && p.fcm_coddig_mant == tcrIDDigitacion);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // VALIDACION REFERENCIAL AFILIADOS EN CONTRATO
        //-------------------------------------------------------
        #region fcrValidarUsuarioEnContrato: validar identificacion en maestro afiliados contrato
        /// <summary>
        /// <para>Validar identificacion del paciente/afiliado en maestro afiliados contrato</para>
        /// <para>VALOR RETORNO: Devuelve vacio cuando existe, Cuando el registro no existe </para>
        /// <para>devuelve un mensaje de texto que inidica el error.</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoIde: Tipo identificacion del usuario o afiliado</para>
        /// <para>tcrNumeroIdAfiliado: Numero de identificacion del afiliado</para>
        /// <para>tobRegContrato: Registro temporal del tipo EFctomaescontrato, para realizar gestion</para>
        /// </summary>
        public static String fcrValidarUsuarioEnContrato(String tcrTipoIde, String tcrNumeroIdAfiliado, EFctomaescontrato tobRegContrato)
        {
            var lcrValorReturn = String.Empty;
            // Validar si el contrato verifica el usuario en maestro afiliados
            if (tobRegContrato.cto_idvalc_cont == "1")
            {
                var tmpx = CTOValidarCodigo.fobRegBuscarCtomaeafiliadosIu(tcrNumeroIdAfiliado);
                if (tmpx == null)
                {
                    lcrValorReturn = "Identificación del usuario: No existe en maestro afiliados del contrato.";
                }
                else
                {
                    var lcrTexto = String.Empty;
                    // Tipo Ide Diferente
                    if (tcrTipoIde != tmpx.sia_tipide_tide) { lcrValorReturn = "Tipo Identificación: No concuerdad en maestro afiliados contrato"; }

                    // Contrato diferente
                    if (tobRegContrato.cto_nrocon_cont != tmpx.cto_nrocon_cont) 
                    { 
                        lcrTexto = "Numero del contrato: No concuerdad en maestro afiliados contrato";
                        lcrValorReturn = String.IsNullOrWhiteSpace(lcrValorReturn) ? lcrTexto : lcrValorReturn + "/ " + lcrTexto; 
                    }
                }
            }
            return lcrValorReturn;
        }
        #endregion

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class HCLValidarCodigo : clBaseInpc
    {

        //-------------------------------------------------------
        // INV - MODULO HISTORIAS CLINICAS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // HCLMAESTROHISCL: Maestro de historias clínicas
        //-------------------------------------------------------
        #region Buscar HCLMAESTROHISCL: Logica
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de historias clínicas electrónicas abiertas a pacientes
        /// </para>
        /// </summary>
        public static bool flgBuscarHclmaestrohiscl(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: String
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_notape_hicl
        /// (campo 'DE' de la tabla hclmaestrohiscl) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de historias clínicas electrónicas abiertas a pacientes
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclmaestrohiscl(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_notape_hicl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: Registro
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Dado el IG, devuelve un registro de tipo EFhclmaestrohiscl desde la tabla
        /// hclmaestrohiscl cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de historias clínicas electrónicas abiertas a pacientes
        /// </para>
        /// </summary>
        public static EFhclmaestrohiscl fobRegBuscarHclmaestrohiscl(string tcrCodigo)
        {
            EFhclmaestrohiscl lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: Registro IG
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclmaestrohiscl desde la tabla
        /// hclmaestrohiscl dado el IG del usuario atendido, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de historias clínicas electrónicas abiertas a pacientes
        /// </para>
        /// </summary>
        public static EFhclmaestrohiscl fobRegBuscarHclmaestrohisclIG(string tcrNumeroIgUsuario)
        {
            EFhclmaestrohiscl lobReturn = new EFhclmaestrohiscl();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.sia_idesec_usua == tcrNumeroIgUsuario);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: Registro IG y Estado
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve un registro de tipo EFhclmaestrohiscl desde la tabla</para>
        /// <para>hclmaestrohiscl dado el IG del usuario atendido y el estado del registro historia clinica, cuando no exite retorna  null.</para>
        /// <para>DESCRIPCION TABLA: Maestro de historias clínicas electrónicas abiertas a pacientes</para>
        /// </summary>
        public static EFhclmaestrohiscl fobRegBuscarHclmaestrohisclIGEst(String tcrNumeroIgUsuario, String tcrEstadoRegistro)
        {
            EFhclmaestrohiscl lobReturn = null;
            using (_context = new DbAplicacion())
            {
                lobReturn = _context.Hclmaestrohiscl.FirstOrDefault(p => p.sia_idesec_usua == tcrNumeroIgUsuario &&
                                                                         p.sis_estreg_esrg == tcrEstadoRegistro);
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: Registro desde Numero admision
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve un registro de tipo EFhclmaestrohiscl, dado el Id Admision cuando no existe genera el nuevo registro para el usuario automaticamente</para>
        /// </summary>
        public static EFhclmaestrohiscl fobRegBuscarHclmaestrohisclIAdm(String tcrNumeroAdmision)
        {
            EFhclmaestrohiscl lobReturn = null;
            lobReturn = ModeloHclmaehistoriasclinicas.fobAddRegistroAdmision(tcrNumeroAdmision);
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTIPOREGACTIV: Tipo registro de actividad en historial
        //-------------------------------------------------------
        #region Buscar HCLTIPOREGACTIV: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegactiv(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGACTIV: String
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desreg_hcca
        /// (campo 'DE' de la tabla hcltiporegactiv) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHcltiporegactiv(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desreg_hcca;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGACTIV: Registro
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltiporegactiv desde la tabla
        /// hcltiporegactiv cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static EFhcltiporegactiv fobRegBuscarHcltiporegactiv(string tcrCodigo)
        {
            EFhcltiporegactiv lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGORDESERDE: Detalles ordenes servicios intrahospitalarios
        //-------------------------------------------------------
        #region Buscar HCLREGORDESERDE: Logica
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TITULO: Detalles ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles solicitude ordenes servicios intrahospitalarios, almacena
        /// los registros de los consumos de medicamentos y servicios medicos
        /// de los pacientes durante la estancia en la IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregordeserde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGORDESERDE: String
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TITULO: Detalles ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_notreg_hcor
        /// (campo 'DE' de la tabla hclregordeserde) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles solicitude ordenes servicios intrahospitalarios, almacena
        /// los registros de los consumos de medicamentos y servicios medicos
        /// de los pacientes durante la estancia en la IPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregordeserde(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_notreg_hcor;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGORDESERDE: Registro
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TITULO: Detalles ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregordeserde desde la tabla
        /// hclregordeserde cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles solicitude ordenes servicios intrahospitalarios, almacena
        /// los registros de los consumos de medicamentos y servicios medicos
        /// de los pacientes durante la estancia en la IPS
        /// </para>
        /// </summary>
        public static EFhclregordeserde fobRegBuscarHclregordeserde(string tcrCodigo)
        {
            EFhclregordeserde lobReturn = new EFhclregordeserde();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGORDESERMS: Maestro ordenes servicios intrahospitalarios
        //-------------------------------------------------------
        #region Buscar HCLREGORDESERMS: Logica
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TITULO: Maestro ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro solicitude ordenes servicios intrahospitalarios, registro
        /// maestro  para ordenes de servicios y o medicamen, solicitud
        /// de examenes y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregordeserms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGORDESERMS: String
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TITULO: Maestro ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla hclregordeserms) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro solicitude ordenes servicios intrahospitalarios, registro
        /// maestro  para ordenes de servicios y o medicamen, solicitud
        /// de examenes y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregordeserms(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_nroreg_hcms;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGORDESERMS: Registro
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TITULO: Maestro ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregordeserms desde la tabla
        /// hclregordeserms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro solicitude ordenes servicios intrahospitalarios, registro
        /// maestro  para ordenes de servicios y o medicamen, solicitud
        /// de examenes y otros
        /// </para>
        /// </summary>
        public static EFhclregordeserms fobRegBuscarHclregordeserms(string tcrCodigo)
        {
            EFhclregordeserms lobReturn = new EFhclregordeserms();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLREGORDESERMS: Registro Ex
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TITULO: Maestro ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregordeserms desde la tabla
        /// hclregordeserms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro solicitude ordenes servicios intrahospitalarios, registro
        /// maestro  para ordenes de servicios y o medicamen, solicitud
        /// de examenes y otros
        /// </para>
        /// </summary>
        public static EFhclregordeserms fobRegBuscarHclregordesermsEx(String tcrCodigo)
        {
            EFhclregordeserms lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTIPOREGTURNO: Tipo registro turnos diarios prestacion de servicios medicos
        //-------------------------------------------------------
        #region Buscar HCLTIPOREGTURNO: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TITULO: Tipo registro turnos diarios prestacion de servicios medicos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro turnos diarios prestacion de servicios medicos:
        /// T01=MAÑANA T02 = TARDE T03 = NOCHE
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegturno(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGTURNO: String
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TITULO: Tipo registro turnos diarios prestacion de servicios medicos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_destur_hctu
        /// (campo 'DE' de la tabla hcltiporegturno) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro turnos diarios prestacion de servicios medicos:
        /// T01=MAÑANA T02 = TARDE T03 = NOCHE
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHcltiporegturno(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_destur_hctu;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGTURNO: Registro
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TITULO: Tipo registro turnos diarios prestacion de servicios medicos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltiporegturno desde la tabla
        /// hcltiporegturno cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro turnos diarios prestacion de servicios medicos:
        /// T01=MAÑANA T02 = TARDE T03 = NOCHE
        /// </para>
        /// </summary>
        public static EFhcltiporegturno fobRegBuscarHcltiporegturno(string tcrCodigo)
        {
            EFhcltiporegturno lobReturn = new EFhcltiporegturno();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTIPOREGSERMS: Tipo registro en maestro HCLREGORDESERMS
        //-------------------------------------------------------
        #region Buscar HCLTIPOREGSERMS: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegserms</para>
        /// <para>TITULO: Tipo registro en maestro HCLREGORDESERMS</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro en maestro HCLREGORDESERMS: MEDI= Medicamentos
        /// SERV = Servicios EVOL= Evoluciones NENF = Notas de enfermeria
        /// y otros SVIT,INCO,DIAG,ALIQ,ELIQ…
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegserms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegserms.FirstOrDefault(p => p.hcl_tipreg_hctr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGSERMS: String
        /// <summary>
        /// <para>TABLA: hcltiporegserms</para>
        /// <para>TITULO: Tipo registro en maestro HCLREGORDESERMS</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desreg_hctr
        /// (campo 'DE' de la tabla hcltiporegserms) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro en maestro HCLREGORDESERMS: MEDI= Medicamentos
        /// SERV = Servicios EVOL= Evoluciones NENF = Notas de enfermeria
        /// y otros SVIT,INCO,DIAG,ALIQ,ELIQ…
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHcltiporegserms(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegserms.FirstOrDefault(p => p.hcl_tipreg_hctr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desreg_hctr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGSERMS: Registro
        /// <summary>
        /// <para>TABLA: hcltiporegserms</para>
        /// <para>TITULO: Tipo registro en maestro HCLREGORDESERMS</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltiporegserms desde la tabla
        /// hcltiporegserms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro en maestro HCLREGORDESERMS: MEDI= Medicamentos
        /// SERV = Servicios EVOL= Evoluciones NENF = Notas de enfermeria
        /// y otros SVIT,INCO,DIAG,ALIQ,ELIQ…
        /// </para>
        /// </summary>
        public static EFhcltiporegserms fobRegBuscarHcltiporegserms(string tcrCodigo)
        {
            EFhcltiporegserms lobReturn = new EFhcltiporegserms();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegserms.FirstOrDefault(p => p.hcl_tipreg_hctr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGBLIQIDOMS: Maestro registros balance de liquidos
        //-------------------------------------------------------
        #region Buscar HCLREGBLIQIDOMS: Logica
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TITULO: Maestro registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro  maestro que agrupa balance de liquidos administrados
        /// y eliminados en cada turno medico o de enfermeria y datos total
        /// del cierre
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregbliqidoms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGBLIQIDOMS: String
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TITULO: Maestro registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_obsape_hcbm
        /// (campo 'DE' de la tabla hclregbliqidoms) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro  maestro que agrupa balance de liquidos administrados
        /// y eliminados en cada turno medico o de enfermeria y datos total
        /// del cierre
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregbliqidoms(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_obsape_hcbm;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGBLIQIDOMS: Registro
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TITULO: Maestro registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregbliqidoms desde la tabla
        /// hclregbliqidoms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro  maestro que agrupa balance de liquidos administrados
        /// y eliminados en cada turno medico o de enfermeria y datos total
        /// del cierre
        /// </para>
        /// </summary>
        public static EFhclregbliqidoms fobRegBuscarHclregbliqidoms(string tcrCodigo)
        {
            EFhclregbliqidoms lobReturn = new EFhclregbliqidoms();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGBLIQIDODE: Detalles registros balance de liquidos
        //-------------------------------------------------------
        #region Buscar HCLREGBLIQIDODE: Logica
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TITULO: Detalles registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros balance de liquidos administrados y eliminados
        /// en cada turno medico o de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregbliqidode(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGBLIQIDODE: String
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TITULO: Detalles registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla hclregbliqidode) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros balance de liquidos administrados y eliminados
        /// en cada turno medico o de enfermeria
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregbliqidode(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.hcl_notreg_hcbd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGBLIQIDODE: Registro
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TITULO: Detalles registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregbliqidode desde la tabla
        /// hclregbliqidode cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros balance de liquidos administrados y eliminados
        /// en cada turno medico o de enfermeria
        /// </para>
        /// </summary>
        public static EFhclregbliqidode fobRegBuscarHclregbliqidode(string tcrCodigo)
        {
            EFhclregbliqidode lobReturn = new EFhclregbliqidode();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTIPOLIQUIDOS: Nombres tipos de liquidos administrados o eliminados
        //-------------------------------------------------------
        #region Buscar HCLTIPOLIQUIDOS: Logica
        /// <summary>
        /// <para>TABLA: hcltipoliquidos</para>
        /// <para>TITULO: Nombres tipos de liquidos administrados o eliminados</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nombre de los diferentes tipo de liquidos administrados o eliminados
        /// por el paciente un turno de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltipoliquidos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltipoliquidos.FirstOrDefault(p => p.hcl_codliq_hctl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTIPOLIQUIDOS: String
        /// <summary>
        /// <para>TABLA: hcltipoliquidos</para>
        /// <para>TITULO: Nombres tipos de liquidos administrados o eliminados</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desliq_hctl
        /// (campo 'DE' de la tabla hcltipoliquidos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nombre de los diferentes tipo de liquidos administrados o eliminados
        /// por el paciente un turno de enfermeria
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHcltipoliquidos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltipoliquidos.FirstOrDefault(p => p.hcl_codliq_hctl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desliq_hctl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTIPOLIQUIDOS: Registro
        /// <summary>
        /// <para>TABLA: hcltipoliquidos</para>
        /// <para>TITULO: Nombres tipos de liquidos administrados o eliminados</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltipoliquidos desde la tabla
        /// hcltipoliquidos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nombre de los diferentes tipo de liquidos administrados o eliminados
        /// por el paciente un turno de enfermeria
        /// </para>
        /// </summary>
        public static EFhcltipoliquidos fobRegBuscarHcltipoliquidos(string tcrCodigo)
        {
            EFhcltipoliquidos lobReturn = new EFhcltipoliquidos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltipoliquidos.FirstOrDefault(p => p.hcl_codliq_hctl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLVIASLIQUIDOS: Vias de administración o eliminación de  liquidos
        //-------------------------------------------------------
        #region Buscar HCLVIASLIQUIDOS: Logica
        /// <summary>
        /// <para>TABLA: hclviasliquidos</para>
        /// <para>TITULO: Vias de administración o eliminación de  liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista vias de administración o eliminación de liquidos en pacientes
        /// hospitalizados
        /// </para>
        /// </summary>
        public static bool flgBuscarHclviasliquidos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclviasliquidos.FirstOrDefault(p => p.hcl_vialiq_hcvl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLVIASLIQUIDOS: String
        /// <summary>
        /// <para>TABLA: hclviasliquidos</para>
        /// <para>TITULO: Vias de administración o eliminación de  liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desvia_hcvl
        /// (campo 'DE' de la tabla hclviasliquidos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista vias de administración o eliminación de liquidos en pacientes
        /// hospitalizados
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclviasliquidos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclviasliquidos.FirstOrDefault(p => p.hcl_vialiq_hcvl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desvia_hcvl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLVIASLIQUIDOS: Registro
        /// <summary>
        /// <para>TABLA: hclviasliquidos</para>
        /// <para>TITULO: Vias de administración o eliminación de  liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclviasliquidos desde la tabla
        /// hclviasliquidos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista vias de administración o eliminación de liquidos en pacientes
        /// hospitalizados
        /// </para>
        /// </summary>
        public static EFhclviasliquidos fobRegBuscarHclviasliquidos(string tcrCodigo)
        {
            EFhclviasliquidos lobReturn = new EFhclviasliquidos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclviasliquidos.FirstOrDefault(p => p.hcl_vialiq_hcvl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGISEVENTOS: Maestro historial actividades clinicas paciente
        //-------------------------------------------------------
        #region Buscar HCLREGISEVENTOS: Logica
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro historial actividades clinicas paciente</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro secuencial de cada actividad  realiza al paciente
        /// durante la estancia el la institucion (genera el historial
        /// de la historia clinica)
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregiseventos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: String
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro historial actividades clinicas paciente</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desreg_hcev
        /// (campo 'DE' de la tabla hclregiseventos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro secuencial de cada actividad  realiza al paciente
        /// durante la estancia el la institucion (genera el historial
        /// de la historia clinica)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregiseventos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desreg_hcev;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Registro
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro historial actividades clinicas paciente</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregiseventos desde la tabla
        /// hclregiseventos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro secuencial de cada actividad  realiza al paciente
        /// durante la estancia el la institucion (genera el historial
        /// de la historia clinica)
        /// </para>
        /// </summary>
        public static EFhclregiseventos fobRegBuscarHclregiseventos(string tcrCodigo)
        {
            EFhclregiseventos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Registro Id Admision y Formato registrado
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro historial actividades clinicas paciente</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Devuelve un registro de tipo EFhclregiseventos desde la tabla</para>
        /// <para>hclregiseventos dado el id del formato y Numero de la Admision</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Retorna el primer registro del tipo Registro actividad historial </para>
        /// <para>dado el Numero de admision y el Identificador del tipo documento formato (campo hcl_codreg_hcca)</para>
        /// <para>ejemplo: Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura Historia clinica general</para>
        /// <para>APE-HCL-ODON= Apertura Historia clinica odontologia</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrOrdenVista: "ASCEN" = Orden Acendente "DESEN"=Orden Desendente</para>
        /// </summary>
        public static EFhclregiseventos fobRegBuscarHclregiseventosAdm(String tcrIdAdmision, String tcrIdFormatoActividad, String tcrOrdenVista)
        {
            EFhclregiseventos lobReturn = null;
            EFhclregiseventos lobjRegistro = null;
            using (_context = new DbAplicacion())
            {
                //var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision && p.hcl_codreg_hcca == tcrIdFormatoActividad);
                if (tcrOrdenVista == "DESEN")
                {
                    lobjRegistro = (from tmp in _context.Hclregiseventos
                                    where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                          tmp.hcl_codreg_hcca == tcrIdFormatoActividad
                                    orderby tmp.hcl_secreg_hcev descending
                                    select tmp).FirstOrDefault();
                }
                else
                {
                    lobjRegistro = (from tmp in _context.Hclregiseventos
                                    where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                          tmp.hcl_codreg_hcca == tcrIdFormatoActividad
                                    orderby tmp.hcl_secreg_hcev ascending
                                    select tmp).FirstOrDefault();

               }
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Revisar para saber si hay formatos abiertos
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro historial actividades clinicas paciente</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrIdAdmision: Numero Registro admision para el cual se revisa el historial eventos medicos</para>
        /// <para>VALOR RETORNO:</para>
        /// <para>Revisar para saber si hay formatos en historial eventos medicos abiertos para la admision dada en parametro</para>
        /// <para>Devuelve verdadero (true) cuando hay formatos pendientes por diligenciar en historial de eventos medicos</para>
        /// <para>devuelve falso (false) cuando no hay formatos en estado abiertos</para>
        /// </summary>
        public static bool flgHclregiseventosAbiertos(String tcrIdAdmision)
        {
            var llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision && 
                                                                                p.hcl_desreg_hcev != null && p.sis_estpro_espr == "1");
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Registro Id Admision y Formatos que indiquen embarazo
        /// <summary>
        /// <para>Buscar en historial de eventos dados en la admision, algún evento que indique que la paciente esta embarazada</para>
        /// <para>devuelve verdadero o falso TRUE/FALSE</para>
        /// </summary>
        public static bool flgRegBuscarHclregiseventosEmbarazadas(String tcrIdAdmision)
        {
            var llgReturn = false;
            EFhclregiseventos lobjRegistro = null;
            using (_context = new DbAplicacion())
            {
                lobjRegistro = (from tmp in _context.Hclregiseventos
                                where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                      (tmp.hcl_codreg_hcca == "PYP-CTRL-EMBAR-ENFER" ||
                                       tmp.hcl_codreg_hcca == "PYP-PRIM-VEZ-EMBARAZ" ||
                                       tmp.hcl_codreg_hcca == "PYP-CTRL-EMBAR-MEDIC" ||
                                       tmp.hcl_codreg_hcca == "HCL-MATER-PART-ABORT" ||
                                       tmp.hcl_codreg_hcca == "HCL-ATEN-EMBAR-RNACI" ||
                                       tmp.hcl_codreg_hcca == " HCL-ATEN-EMBAR-PART")
                                select tmp).FirstOrDefault();

                llgReturn = lobjRegistro != null ? true : false;
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Registro Id Admision y Formatos que indiquen atencion del parto
        /// <summary>
        /// <para>Buscar en historial de eventos dados en la admision, algún evento que indique atencion del parto</para>
        /// <para>devuelve verdadero o falso TRUE/FALSE</para>
        /// </summary>
        public static bool flgRegBuscarHclregiseventosAtencionParto(String tcrIdAdmision)
        {
            var llgReturn = false;
            EFhclregiseventos lobjRegistro = null;
            using (_context = new DbAplicacion())
            {
                lobjRegistro = (from tmp in _context.Hclregiseventos
                                where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                      (tmp.hcl_codreg_hcca == "HCL-MATER-PART-ABORT" ||
                                       tmp.hcl_codreg_hcca == "HCL-ATEN-EMBAR-RNACI" ||
                                       tmp.hcl_codreg_hcca == " HCL-ATEN-EMBAR-PART")
                                select tmp).FirstOrDefault();

                llgReturn = lobjRegistro != null ? true : false;
            }
            return llgReturn;
        }
        #endregion
        #region fcrValidEventosObligdosAdmitidos: Formatos obligatorios diligenciados para dar egreso a pacientes
        /// <summary>
        /// <para>Buscar en historial eventos dados en la admision, formatos minimos que debe tener diligenciado el pacienta</para>
        /// <para>para que pueda ser dado de alta, dedevuelve un listado con los formatos que no estan diligenciados</para>
        /// <para>Cuando totos los formatos estan diligenciados, devuelve una cadena String vacia</para>
        /// </summary>
        public static String fcrValidFormatoObligdosAdmitidos(String tcrIdAdmision)
        {

            var lcrReturn = String.Empty;
            List<EFhclregiseventos> tmpEventos = null;
            var llgVarEpic = false;
            var llgVarHcon = false;
            var llgVarEvol = false;
            var llgVarUrge = false;

            using (_context = new DbAplicacion())
            {
                tmpEventos = (from tmp in _context.Hclregiseventos
                              where tmp.adm_secadm_rgad == tcrIdAdmision && 
                                    tmp.sis_estpro_espr == "2"
                              select tmp).ToList();

                if (tmpEventos != null)
                {
                    foreach (var lobReg in tmpEventos)
                    {
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-EPIC") { llgVarEpic = true; }     // Epicrisis
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-HCON") { llgVarHcon = true; }     // Hoja de consumo
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-EVOL") { llgVarEvol = true; }     // Evolucion medica
                        // La atencion de urgencias son varios tipos de formatos, basta con uno solo
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-URG-ADMI") { llgVarUrge = true; } // Atencion inicial de urgencias
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-ATI-URGE") { llgVarUrge = true; } // Atención de Urgencias
                        if (lobReg.hcl_codreg_hcca.Trim() == "HCL-CAPTURA-ATI-URGX") { llgVarUrge = true; } // Urgencia con anamnesis

                    }
                }
                if (llgVarEpic == false) { lcrReturn = "Epicrisis"; }
                if (llgVarHcon == false) { lcrReturn = String.IsNullOrWhiteSpace(lcrReturn) ? "Hoja consumo medicamentos" : lcrReturn + " / " + "Hoja consumo medicamentos"; }
                if (llgVarEvol == false) { lcrReturn = String.IsNullOrWhiteSpace(lcrReturn) ? "Evolución médica" : lcrReturn + " / " + "Evolución médica"; }
                if (llgVarUrge == false) { lcrReturn = String.IsNullOrWhiteSpace(lcrReturn) ? "Atención de urgencias" : lcrReturn + " / " + "Atención de urgencias"; }
                
            }
            return lcrReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLREGNOTASMEDI: Detalles registros evoluciones medicas y notas de enfermeria
        //-------------------------------------------------------
        #region Buscar HCLREGNOTASMEDI: Logica
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TITULO: Detalles registros evoluciones medicas y notas de enfermeria</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros evoluciones medicas y notas de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregnotasmedi(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLREGNOTASMEDI: String
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TITULO: Detalles registros evoluciones medicas y notas de enfermeria</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_notreg_hcnm
        /// (campo 'DE' de la tabla hclregnotasmedi) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros evoluciones medicas y notas de enfermeria
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclregnotasmedi(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_notreg_hcnm;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLREGNOTASMEDI: Registro
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TITULO: Detalles registros evoluciones medicas y notas de enfermeria</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregnotasmedi desde la tabla
        /// hclregnotasmedi cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros evoluciones medicas y notas de enfermeria
        /// </para>
        /// </summary>
        public static EFhclregnotasmedi fobRegBuscarHclregnotasmedi(string tcrCodigo)
        {
            EFhclregnotasmedi lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLREGNOTASMEDI: Registro mas reciente
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TITULO: Detalles registros evoluciones medicas y notas de enfermeria</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el registro mas reciente del tipo EFhclregnotasmedi  para la admision dada en el parametro tcrCodigoAdmision, cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Detalles registros evoluciones medicas y notas de enfermeria </para>
        /// <para>tcrTipoRegistro: "1" = Evoluciones medicas "2" = Notas de Enfermeria "3"= Evolucion o Nota (cualquiera de las dos)</para>
        /// </summary>
        public static EFhclregnotasmedi fobRegBuscarHclregnotasmediUltima(String tcrCodigoAdmision, String tcrTipoRegistro)
        {
            EFhclregnotasmedi lobReturn = null;
            List<EFhclregnotasmedi> lobjRegistro = null;
            
            using (_context = new DbAplicacion())
            {
                if (tcrTipoRegistro == "3") // Todas
                {
                    lobjRegistro = (from tmp in _context.Hclregnotasmedi
                                        where tmp.adm_secadm_rgad == tcrCodigoAdmision &&
                                              tmp.sis_estpro_espr != "3"
                                        orderby tmp.hcl_secreg_hcnm descending
                                        select tmp).ToList();
                }
                else 
                {
                    lobjRegistro = (from tmp in _context.Hclregnotasmedi
                                        where tmp.adm_secadm_rgad == tcrCodigoAdmision &&
                                              tmp.hcl_tipreg_hcnm == tcrTipoRegistro &&
                                              tmp.sis_estpro_espr != "3"
                                        orderby tmp.hcl_secreg_hcnm descending
                                        select tmp).ToList();
                }

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro.FirstOrDefault();
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLVARIABMAESTR: Maestro Variables publicas de gestion en formatos
        //-------------------------------------------------------
        #region Buscar HCLVARIABMAESTR: Logica
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Variables publicas gestion en formatos de historias
        /// clinicas
        /// </para>
        /// </summary>
        public static bool flgBuscarHclvariabmaestr(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLVARIABMAESTR: String
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_titulo_hcvr
        /// (campo 'DE' de la tabla hclvariabmaestr) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Variables publicas gestion en formatos de historias
        /// clinicas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclvariabmaestr(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_titulo_hcvr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLVARIABMAESTR: Registro
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclvariabmaestr desde la tabla
        /// hclvariabmaestr cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Variables publicas gestion en formatos de historias
        /// clinicas
        /// </para>
        /// </summary>
        public static EFhclvariabmaestr fobRegBuscarHclvariabmaestr(string tcrCodigo)
        {
            EFhclvariabmaestr lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLVARIABMAESTR: Nombre Variable
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el registro de configuracion dado el nombre de la variable ejemplo: "USUARIO_NUMERO_HIST_CLINICA"
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Variables publicas gestion en formatos de historias
        /// clinicas
        /// </para>
        /// </summary>
        public static EFhclvariabmaestr fobRegBuscarHclvariabmaestrVr(String tcrNombreVariable)
        {
            EFhclvariabmaestr lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nomvar_hcvr == tcrNombreVariable);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLVARIABMAESTR: Solo Variables tipo resumen
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO: Devuelve una lista variables tipo resumen que pertenencen a un grupo, para gestion en formatos de HC</para>
        /// <para>tcrCodgoGrupo: Codigo del grupos para localizar las variable tipo resumen</para>
        /// <para>DESCRIPCION TABLA: Maestro Variables publicas gestion en formatos de historias clinicas </para>
        /// </summary>
        public static List<EFhclvariabmaestr> fobRegBuscarHclvariabmaestrVrResumen(String tcrCodgoGrupo)
        {
            List<EFhclvariabmaestr> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Hclvariabmaestr 
                                    where tmp.hcl_secgru_hcgv == tcrCodgoGrupo && 
                                          tmp.hcl_modoca_hcvr !="1" && tmp.hcl_camdig_hcvr !="3" select tmp).ToList();

                if (lobjRegistro != null && lobjRegistro.Count != 0)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLVARIABGRUPOS: Maestro grupos de variables publicas
        //-------------------------------------------------------
        #region Buscar HCLVARIABGRUPOS: Logica
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TITULO: Maestro grupos de variables publicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro grupos de variables publicas de historias clinicas,
        /// para organización y visualizacion en formatos de impresion
        /// </para>
        /// </summary>
        public static bool flgBuscarHclvariabgrupos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLVARIABGRUPOS: String
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TITULO: Maestro grupos de variables publicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hcl_desgru_hcgv
        /// (campo 'DE' de la tabla hclvariabgrupos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro grupos de variables publicas de historias clinicas,
        /// para organización y visualizacion en formatos de impresion
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHclvariabgrupos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desgru_hcgv;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLVARIABGRUPOS: Registro
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TITULO: Maestro grupos de variables publicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclvariabgrupos desde la tabla
        /// hclvariabgrupos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro grupos de variables publicas de historias clinicas,
        /// para organización y visualizacion en formatos de impresion
        /// </para>
        /// </summary>
        public static EFhclvariabgrupos fobRegBuscarHclvariabgrupos(string tcrCodigo)
        {
            EFhclvariabgrupos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // Historico datos de formatos Historias Clinicas
        //-------------------------------------------------------
        #region Historico datos tipo texto de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: EFhclregisextxa01</para>
        /// <para>TITULO: Historico datos tipo texto de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisextxa01 desde la tabla
        /// hclregisextxa01 dado el Codigo Admision y Codigo Registro (ejemplo HCL-CONST-EXTER) actividad medica
        /// </para>
        /// </summary>
        public static EFhclregisextxa01 fobRegBuscarhclregisextxa01(String tcrCodigoAdmision, String tcrCodigoActividad)
        {
            EFhclregisextxa01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisextxa01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.hcl_codreg_hcca == tcrCodigoActividad);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Historico datos tipo fecha de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: hclregisexfec01</para>
        /// <para>TITULO: Historico datos tipo fechas de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisexfec01 desde la tabla
        /// Hclregisexfec01 dado el Codigo Admision y Codigo Registro (ejemplo HCL-CONST-EXTER) actividad medica
        /// </para>
        /// </summary>
        public static EFhclregisexfec01 fobRegBuscarHclregisexfec01(String tcrCodigoAdmision, String tcrCodigoActividad)
        {
            EFhclregisexfec01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisexfec01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.hcl_codreg_hcca == tcrCodigoActividad);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Historico datos tipo texto combobox de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: hclregisexcbo01</para>
        /// <para>TITULO: Historico datos tipo texto combobox de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisexcbo01 desde la tabla
        /// Hclregisexcbo01 dado el Codigo Admision  y Codigo Registro (ejemplo HCL-CONST-EXTER) actividad medica
        /// </para>
        /// </summary>
        public static EFhclregisexcbo01 fobRegBuscarHclregisexcbo01(String tcrCodigoAdmision, String tcrCodigoActividad)
        {
            EFhclregisexcbo01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisexcbo01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.hcl_codreg_hcca == tcrCodigoActividad);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        // Codigo plantilla
        #region Historico datos tipo texto de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: EFhclregisextxa01</para>
        /// <para>TITULO: Historico datos tipo texto de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisextxa01 desde la tabla
        /// hclregisextxa01 dado el Codigo Admision y Codigo plantilla
        /// </para>
        /// </summary>
        public static EFhclregisextxa01 fobRegBuscarhclregisextxa01Pl(String tcrCodigoAdmision, String tcrCodigoFormato)
        {
            EFhclregisextxa01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisextxa01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.grp_idepla_grpl == tcrCodigoFormato);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Historico datos tipo fecha de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: hclregisexfec01</para>
        /// <para>TITULO: Historico datos tipo fechas de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisexfec01 desde la tabla
        /// Hclregisexfec01 dado el Codigo Admision y Codigo plantilla
        /// </para>
        /// </summary>
        public static EFhclregisexfec01 fobRegBuscarHclregisexfec01Pl(String tcrCodigoAdmision, String tcrCodigoFormato)
        {
            EFhclregisexfec01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisexfec01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.grp_idepla_grpl == tcrCodigoFormato);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Historico datos tipo texto combobox de formatos Historias Clinicas
        /// <summary>
        /// <para>TABLA: hclregisexcbo01</para>
        /// <para>TITULO: Historico datos tipo texto combobox de formatos Historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclregisexcbo01 desde la tabla
        /// Hclregisexcbo01 dado el Codigo Admision  y Codigo plantilla
        /// </para>
        /// </summary>
        public static EFhclregisexcbo01 fobRegBuscarHclregisexcbo01Pl(String tcrCodigoAdmision, String tcrCodigoFormato)
        {
            EFhclregisexcbo01 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisexcbo01.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision && p.grp_idepla_grpl == tcrCodigoFormato);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFORMATVISTMA: Grupo vista actividades medicas  en captura Historias clinic
        //-------------------------------------------------------
        #region Buscar HCLFORMATVISTMA: Registro
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TITULO: Grupo vista actividades medicas  en captura Historias clinic</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclformatvistma desde la tabla
        /// hclformatvistma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos formatos de actividad o servicios para organización
        /// en vista captura historias clinicas (capa Propiedades) y agrupados
        /// según funcionalidad de cada formato y perfil de usuario
        /// </para>
        /// </summary>
        public static EFhclformatvistma fobRegBuscarHclformatvistma(String tcrCodigo)
        {
            EFhclformatvistma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMEDAD: Tabla puntuacion según edad y sexo test Framingham
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMEDAD: Registro
        /// <summary>
        /// <para>TABLA: hclframghamedad</para>
        /// <para>TITULO: Tabla puntuacion según edad y sexo test Framingham</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamedad desde la tabla
        /// hclframghamedad cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla puntuacion según edad y sexo para la gestion test Framingham en hipertension</para>
        /// </summary>
        public static EFhclframghamedad fobRegBuscarHclframghamedad(String tcrCodigo)
        {
            EFhclframghamedad lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamedad.FirstOrDefault(p => p.hcl_nroreg_hcfe == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMEDAD: Seleccion segun rango edad sexo
        /// <summary>
        /// <para>TABLA: hclframghamedad</para>
        /// <para>TITULO: Tabla puntuacion según edad y sexo test Framingham</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamedad desde la tabla
        /// hclframghamedad cuando no exite retorna  null.
        /// </para> 
        /// <para>DESCRIPCION TABLA: Tabla puntuacion según edad y sexo para la gestion test Framingham en hipertension</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino</para>
        /// <para>tnuEdad: Edad del paciente (en años) al momento de realizar el Test</para>
        /// </summary>
        public static EFhclframghamedad fobRegBuscarHclframghamedadRango(String tcrSexo, int tnuEdad)
        {
            EFhclframghamedad lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamedad.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo &&
                                                                           p.hcl_edaini_hcfe <= tnuEdad && p.hcl_edafin_hcfe >= tnuEdad);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMCTRL: Tabla puntuacion según colesterol HDL y colesterol total
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMCTRL: Registro
        /// <summary>
        /// <para>TABLA: hclframghamctrl</para>
        /// <para>TITULO: Tabla puntuacion según colesterol HDL y colesterol total</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamctrl desde la tabla
        /// hclframghamctrl cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla puntuacion según colesterol HDL y colesterol total 1=Colesterol HDL 2= Colesterol Total</para>
        /// </summary>
        public static EFhclframghamctrl fobRegBuscarHclframghamctrl(String tcrCodigo)
        {
            EFhclframghamctrl lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamctrl.FirstOrDefault(p => p.hcl_nroreg_hcfc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMCTRL: Seleccion segun rango
        /// <summary>
        /// <para>TABLA: hclframghamctrl</para>
        /// <para>TITULO: Tabla puntuacion según colesterol HDL y colesterol total y otros</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamctrl desde la tabla
        /// hclframghamctrl cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla puntuacion según colesterol HDL y colesterol total 1=Colesterol HDL 2= Colesterol Total</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino "A"=Ambos sexos</para>
        /// <para>Tipo: "1"=Colesterol HDL "2"=Colesterol Total "3"=Indice de masa corporal (IMC) ... y otros</para>
        /// <para>Valor: Valor lectura resultado del examen de colesterol</para>
        /// </summary>
        public static EFhclframghamctrl fobRegBuscarHclframghamctrlRango(String tcrSexo, String tcrTipo, Double tnuValor)
        {
            EFhclframghamctrl lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamctrl.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo && 
                                                                           p.hcl_tipcol_hcfc == tcrTipo &&
                                                                           p.hcl_medini_hcfc <= tnuValor && p.hcl_medfin_hcfc >= tnuValor);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMOTRS: Tabla puntuacion según otros tipos de riesgo y respuesta SI/NO
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMOTRS: Registro
        /// <summary>
        /// <para>TABLA: hclframghamotrs</para>
        /// <para>TITULO: Tabla puntuacion según otros tipos de riesgo y respuesta SI/</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamotrs desde la tabla
        /// hclframghamotrs cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según otros tipos de riesgo y respuesta SI/NO
        /// 1=Diabetes 2=Tabaco
        /// </para>
        /// </summary>
        public static EFhclframghamotrs fobRegBuscarHclframghamotrs(String tcrCodigo)
        {
            EFhclframghamotrs lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamotrs.FirstOrDefault(p => p.hcl_nroreg_hcft == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMOTRS: Seleccion segun rango
        /// <summary>
        /// <para>TABLA: hclframghamotrs</para>
        /// <para>TITULO: Tabla puntuacion según otros tipos de riesgo y respuesta SI/NO</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamotrs desde la tabla
        /// hclframghamotrs cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla puntuacion según otros tipos de riesgo y respuesta SI/NO 1=Diabetes 2=Tabaco</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino "A"=Ambos sexos</para>
        /// <para>tcrTipo: "1"=Diabetes "2"=Tabaco "3"=Familiares muerte cardiaca ... y otros</para>
        /// <para>tcrRespusta: "SI"=Afirmativo del reisgo "NO"=Negativo para el riesgo  </para>
        /// </summary>
        public static EFhclframghamotrs fobRegBuscarHclframghamotrsRango(String tcrSexo, String tcrTipo, String tcrRespusta)
        {
            EFhclframghamotrs lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamotrs.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo &&
                                                                           p.hcl_tipcol_hcft == tcrTipo && p.hcl_respue_hcft == tcrRespusta);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMPART: Tabla puntuacion según presion arterial sistolica edad y sex
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMPART: Registro
        /// <summary>
        /// <para>TABLA: hclframghampart</para>
        /// <para>TITULO: Tabla puntuacion según presion arterial sistolica edad y sex</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghampart desde la tabla
        /// hclframghampart cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según presion arterial sistolica edad y sexo
        /// test Framingham para programa hipertension
        /// </para>
        /// </summary>
        public static EFhclframghampart fobRegBuscarHclframghampart(String tcrCodigo)
        {
            EFhclframghampart lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghampart.FirstOrDefault(p => p.hcl_nroreg_hcfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMPART: Seleccion segun rango
        /// <summary>
        /// <para>TABLA: hclframghampart</para>
        /// <para>TITULO: Tabla puntuacion según presion arterial sistolica edad y sex</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghampart desde la tabla
        /// hclframghampart cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según presion arterial sistolica edad y sexo
        /// test Framingham para programa hipertension
        /// </para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino</para>
        /// <para>tnuEdad: Edad del paciente (en años) al momento de realizar el Test</para>
        /// <para>tnuValor: Valor lectura presion sistolica</para>
        /// </summary>
        public static EFhclframghampart fobRegBuscarHclframghampartRango(String tcrSexo, int tnuEdad, int tnuValor)
        {
            EFhclframghampart lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghampart.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo &&
                                                                           p.hcl_edaini_hcfp <= tnuEdad && 
                                                                           p.hcl_edafin_hcfp >= tnuEdad &&
                                                                           p.hcl_prsini_hcfp <= tnuValor&&
                                                                           p.hcl_prsfin_hcfp >= tnuValor);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMR10A: Tabla puntuacion según riesgo a 10 años
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMR10A: Registro
        /// <summary>
        /// <para>TABLA: hclframghamr10a</para>
        /// <para>TITULO: Tabla puntuacion según riesgo a 10 años</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamr10a desde la tabla
        /// hclframghamr10a cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla porcentaje riesgo a 10 años, dados los rangos de puntaje
        /// del test, se hace la valoracion en porcentaje del riesgo
        /// </para>
        /// </summary>
        public static EFhclframghamr10a fobRegBuscarHclframghamr10a(String tcrCodigo)
        {
            EFhclframghamr10a lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamr10a.FirstOrDefault(p => p.hcl_nroreg_hcfr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMR10A: Seleccion segun rango
        /// <summary>
        /// <para>TABLA: hclframghamr10a</para>
        /// <para>TITULO: Tabla puntuacion según riesgo a 10 años</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamr10a desde la tabla
        /// hclframghamr10a cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla porcentaje riesgo a 10 años, dados los rangos de puntaje
        /// del test, se hace la valoracion en porcentaje del riesgo
        /// </para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino</para>
        /// <para>tnuPuntaje: Puntaje o valor Sumatoria puntos del test</para>
        /// </summary>
        public static EFhclframghamr10a fobRegBuscarHclframghamr10aRango(String tcrSexo, int tnuPuntaje)
        {
            EFhclframghamr10a lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamr10a.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo &&
                                                                           p.hcl_punini_hcfr <= tnuPuntaje &&
                                                                           p.hcl_punfin_hcfr >= tnuPuntaje);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLFRAMGHAMNIVE: Tabla nivel de riesgo según porcentaje dado en test
        //-------------------------------------------------------
        #region Buscar HCLFRAMGHAMNIVE: Registro
        /// <summary>
        /// <para>TABLA: hclframghamnive</para>
        /// <para>TITULO: Tabla nivel de riesgo según porcentaje dado en test</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamnive desde la tabla
        /// hclframghamnive cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla nivel de riesgo según porcentaje dado en test para mostrar grafco titulo o color</para>
        /// </summary>
        public static EFhclframghamnive fobRegBuscarHclframghamnive(String tcrCodigo)
        {
            EFhclframghamnive lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamnive.FirstOrDefault(p => p.hcl_nroreg_hcfn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HCLFRAMGHAMNIVE: Seleccion segun rango
        /// <summary>
        /// <para>TABLA: hclframghamnive</para>
        /// <para>TITULO: Tabla nivel de riesgo según porcentaje dado en test</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhclframghamnive desde la tabla
        /// hclframghamnive cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Tabla nivel de riesgo según porcentaje dado en test para mostrar grafico titulo o color</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrSexo: "F"=Femenino "M"=Masculino</para>
        /// <para>tnuPorcentaje: Porcentaje de riesgo segun sumatorria de puntos</para>
        /// </summary>
        public static EFhclframghamnive fobRegBuscarHclframghamniveRango(String tcrSexo, int tnuPorcentaje)
        {
            EFhclframghamnive lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclframghamnive.FirstOrDefault(p => p.sis_codsex_sexo == tcrSexo &&
                                                                           p.hcl_porini_hcfn <= tnuPorcentaje && p.hcl_porfin_hcfn >= tnuPorcentaje);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTESTEADAREAS: Areas de evaluacion en test escala del desarrollo EAD
        //-------------------------------------------------------
        #region Buscar HCLTESTEADAREAS: Logica
        /// <summary>
        /// <para>TABLA: hcltesteadareas</para>
        /// <para>TITULO: Areas de evaluacion en test escala del desarrollo EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla areas de evaluacion en test escala del desarrollo EAD
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltesteadareas(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadareas.FirstOrDefault(p => p.hcl_nroreg_hcea == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTESTEADAREAS: String
        /// <summary>
        /// <para>TABLA: hcltesteadareas</para>
        /// <para>TITULO: Areas de evaluacion en test escala del desarrollo EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en hcl_desreg_hcea
        /// (campo 'DE' de la tabla hcltesteadareas) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla areas de evaluacion en test escala del desarrollo EAD
        /// </para>
        /// </summary>
        public static String fcrDEBuscarHcltesteadareas(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadareas.FirstOrDefault(p => p.hcl_nroreg_hcea == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desreg_hcea;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTESTEADAREAS: Registro
        /// <summary>
        /// <para>TABLA: hcltesteadareas</para>
        /// <para>TITULO: Areas de evaluacion en test escala del desarrollo EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltesteadareas desde la tabla
        /// hcltesteadareas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla areas de evaluacion en test escala del desarrollo EAD
        /// </para>
        /// </summary>
        public static EFhcltesteadareas fobRegBuscarHcltesteadareas(String tcrCodigo)
        {
            EFhcltesteadareas lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadareas.FirstOrDefault(p => p.hcl_nroreg_hcea == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTESTEADRANGO: Rangos según areas de evaluacion test escala del desarrollo 
        //-------------------------------------------------------
        #region Buscar HCLTESTEADRANGO: Logica
        /// <summary>
        /// <para>TABLA: hcltesteadrango</para>
        /// <para>TITULO: Rangos según areas de evaluacion test escala del desarrollo </para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla Rangos según areas de evaluacion en test escala del desarrollo
        /// EAD
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltesteadrango(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadrango.FirstOrDefault(p => p.hcl_nroreg_hcer == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTESTEADRANGO: String
        /// <summary>
        /// <para>TABLA: hcltesteadrango</para>
        /// <para>TITULO: Rangos según areas de evaluacion test escala del desarrollo </para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en hcl_desreg_hcer
        /// (campo 'DE' de la tabla hcltesteadrango) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla Rangos según areas de evaluacion en test escala del desarrollo
        /// EAD
        /// </para>
        /// </summary>
        public static String fcrDEBuscarHcltesteadrango(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadrango.FirstOrDefault(p => p.hcl_nroreg_hcer == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hcl_desreg_hcer;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HCLTESTEADRANGO: Registro
        /// <summary>
        /// <para>TABLA: hcltesteadrango</para>
        /// <para>TITULO: Rangos según areas de evaluacion test escala del desarrollo </para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltesteadrango desde la tabla
        /// hcltesteadrango cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla Rangos según areas de evaluacion en test escala del desarrollo
        /// EAD
        /// </para>
        /// </summary>
        public static EFhcltesteadrango fobRegBuscarHcltesteadrango(String tcrCodigo)
        {
            EFhcltesteadrango lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadrango.FirstOrDefault(p => p.hcl_nroreg_hcer == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HCLTESTEADESCAL: Tabla puntuacion según para escala EAD
        //-------------------------------------------------------
        #region Buscar HCLTESTEADESCAL: Logica
        /// <summary>
        /// <para>TABLA: hcltesteadescal</para>
        /// <para>TITULO: Tabla puntuacion según para escala EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según para escala EAD (escala abrevida de
        /// desarrollo) para generar grafica de puntuacion transformada
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltesteadescal(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadescal.FirstOrDefault(p => p.hcl_nroreg_hceb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTESTEADESCAL: Registro
        /// <summary>
        /// <para>TABLA: hcltesteadescal</para>
        /// <para>TITULO: Tabla puntuacion según para escala EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltesteadescal desde la tabla
        /// hcltesteadescal cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según para escala EAD (escala abrevida de
        /// desarrollo) para generar grafica de puntuacion transformada
        /// </para>
        /// </summary>
        public static EFhcltesteadescal fobRegBuscarHcltesteadescal(String tcrCodigo)
        {
            EFhcltesteadescal lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadescal.FirstOrDefault(p => p.hcl_nroreg_hceb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar fobRegBuscarHcltesteadescalValor: Registro Valor
        /// <summary>
        /// <para>TABLA: hcltesteadescal</para>
        /// <para>TITULO: Tabla puntuacion según para escala EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltesteadescal desde la tabla
        /// hcltesteadescal cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla puntuacion según para escala EAD (escala abrevida de
        /// desarrollo) para generar grafica de puntuacion transformada
        /// </para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigoArea: "A01"=Motricidad gruesa "A02"=Motricidad fina </para>
        /// </summary>
        public static EFhcltesteadescal fobRegBuscarHcltesteadescalValor(String tcrCodigoArea, int tnuPuntajeDirecto  , int tnuEdadDias)
        {
            EFhcltesteadescal lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadescal.FirstOrDefault(p => p.hcl_nroreg_hcea == tcrCodigoArea &&
                                                                           p.hcl_puntos_hceb == tnuPuntajeDirecto &&
                                                                           p.hcl_medini_hceb <= tnuEdadDias &&
                                                                           p.hcl_medfin_hceb >= tnuEdadDias);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar fobRegBuscarHcltesteadescalRango: Registro Valor
        /// <summary>
        /// <para>TABLA: hcltesteadescal</para>
        /// <para>TITULO: Tabla puntuacion según para escala EAD</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhcltesteadescal desde la tabla
        /// hcltesteadescal cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION: Devuelve un registro para identificar el rango segun area y edad </para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigoArea: "A01"=Motricidad gruesa "A02"=Motricidad fina </para>
        /// </summary>
        public static EFhcltesteadescal fobRegBuscarHcltesteadescalRango(String tcrCodigoArea, int tnuEdadDias)
        {
            EFhcltesteadescal lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltesteadescal.FirstOrDefault(p => p.hcl_nroreg_hcea == tcrCodigoArea &&
                                                                           p.hcl_medini_hceb <= tnuEdadDias &&
                                                                           p.hcl_medfin_hceb >= tnuEdadDias);
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

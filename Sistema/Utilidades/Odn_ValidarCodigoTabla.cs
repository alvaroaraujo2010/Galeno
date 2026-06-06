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
    public class ODNValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // ODN - MODULO SERVICIOS ODONTOLOGICOS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // ODNEVENTOSMAEST: Maestro tratamiento odontologico
        //-------------------------------------------------------
        #region Buscar ODNEVENTOSMAEST: Logica
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro tratamiento odontologico</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro tratamiento odontologico genera actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosmaest(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSMAEST: String
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro tratamiento odontologico</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_obsape_odev
        /// (campo 'DE' de la tabla odneventosmaest) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro tratamiento odontologico genera actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdneventosmaest(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_obsape_odev;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSMAEST: Registro id unico
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro tratamiento odontologico</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodneventosmaest desde la tabla
        /// odneventosmaest cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro tratamiento odontologico genera actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static EFodneventosmaest fobRegBuscarOdneventosmaest(string tcrCodigo)
        {
            EFodneventosmaest lobReturn = new EFodneventosmaest();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSMAEST: Registro Numero de admision
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro tratamiento odontologico</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodneventosmaest desde la tabla
        /// odneventosmaest cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro tratamiento odontologico genera actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static EFodneventosmaest fobRegBuscarOdneventosmaestAd(string tcrAdmision)
        {
            var lcrCodigo = String.Empty;
            var lobReg = fobRegBuscarOdneventosactmsAd(tcrAdmision);
            if (lobReg != null)
            {
                lcrCodigo = lobReg.odn_nroreg_odev;
            }
            EFodneventosmaest lobReturn =null;

            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == lcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSMAEST: Registro Numero Id unico usuario y estado
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro tratamiento odontologico</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodneventosmaest desde la tabla
        /// odneventosmaest dado el id del paciente y el estado de gestion registro (odn_estado_odev), cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro tratamiento odontologico genera actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static EFodneventosmaest fobRegBuscarOdneventosmaestEstado(String tcrIdUnico, String tcrEstado)
        {
            EFodneventosmaest lobReturn = null;

            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.sia_idesec_usua == tcrIdUnico && p.odn_estado_odev == tcrEstado);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNEVENTOSACTMS: Maestro registro unico actividad en cada cita
        //-------------------------------------------------------
        #region Buscar ODNEVENTOSACTMS: Logica
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosactms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSACTMS: String
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_observ_odac
        /// (campo 'DE' de la tabla odneventosactms) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdneventosactms(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_observ_odac;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSACTMS: Registro
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodneventosactms desde la tabla
        /// odneventosactms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static EFodneventosactms fobRegBuscarOdneventosactms(string tcrCodigo)
        {
            EFodneventosactms lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region fobRegBuscarOdneventosactmsAd: Buscar ODNEVENTOSACTMS: Registro
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve registro de tipo EFodneventosactms dado el numero de Admision del paciente
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static EFodneventosactms fobRegBuscarOdneventosactmsAd(string tcrAdmision)
        {
            EFodneventosactms lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.adm_secadm_rgad == tcrAdmision);
                //orderby odneventosmaest.odn_secreg_odev descending

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region fobRegBuscarOdneventosactmsTemp: Registros temporal
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve lista registro tipo EFodneventosactms dado el Codigo del registro maestro tratamiento (odn_nroreg_odev)
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static List<EFodneventosactms> fobRegBuscarOdneventosactmsTemp(String tcrIdTratamiento)
        {
            List<EFodneventosactms> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lcrQuery = from tmp in _context.Odneventosactms
                               where tmp.odn_nroreg_odev.Equals(tcrIdTratamiento) orderby tmp.odn_secreg_odac select tmp;

                if (lcrQuery != null)
                {
                    lobReturn = lcrQuery.ToList();
                };
            }
            return lobReturn;
        }
        #endregion
        #region fobRegBuscarOdneventosactmsEstado Buscar ODNEVENTOSACTMS: Registro
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve registro tipo EFodneventosactms dado Codigo del registro maestro tratamiento (odn_nroreg_odev) 
        ///  y el estado del registro cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static EFodneventosactms fobRegBuscarOdneventosactmsEstado(String tcrIdTratamiento, String tcrEstado)
        {
            EFodneventosactms lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odev == tcrIdTratamiento && p.sis_estpro_espr == tcrEstado);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region fcrValidaOdontologiaDiagPlanTratamiento: Validar si existe Diagnostico inicial y plan en un tratamiento odontologico
        /// <summary>
        /// <para>Validar si existe Diagnostico inicial y plan en un tratamiento odontologico</para>
        /// <para>Devuelve una cadena de texto compuesta por ODDX y ODTR cuado no existe alguna la repemplaza por XXXX </para>
        /// <para>ejemplo: "ODDX-XXXX" = No existe plan tratamiento, "XXXX-ODTR" = No existe diagnostico, "XXXX-XXXX" = No existen ambos</para>
        /// </summary>
        public static String fcrValidaOdontologiaDiagPlanTratamiento(String tcrIdTratamiento)
        {
            var lcrDiagnostico = "XXXX";
            var lcrPTratamiento = "XXXX";
            var tmpRegMaestro = fobRegBuscarOdneventosactmsTemp(tcrIdTratamiento);

            if (tmpRegMaestro != null)
            {
                foreach (var lobReg in tmpRegMaestro)
                {
                    if (lobReg.hcl_tipreg_hctr == "ODDX") { lcrDiagnostico = "ODDX"; }
                    if (lobReg.hcl_tipreg_hctr == "ODTR") { lcrPTratamiento = "ODTR"; }
                }
            }
            return lcrDiagnostico + "-" + lcrPTratamiento;
        }
        #endregion
        //-------------------------------------------------------
        // ODNEVENTOSACTDE: Maestro detalles de actividad
        //-------------------------------------------------------
        #region Buscar ODNEVENTOSACTDE: Logica
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TITULO: Maestro detalles de actividad</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalle registro individual de cada una de las actividades
        /// dadas en una cita (ODNEVENTOSACTMS)
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosactde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSACTDE: String
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TITULO: Maestro detalles de actividad</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desreg_odde
        /// (campo 'DE' de la tabla odneventosactde) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalle registro individual de cada una de las actividades
        /// dadas en una cita (ODNEVENTOSACTMS)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdneventosactde(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desreg_odde;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSACTDE: Registro
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TITULO: Maestro detalles de actividad</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodneventosactde desde la tabla
        /// odneventosactde cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalle registro individual de cada una de las actividades
        /// dadas en una cita (ODNEVENTOSACTMS)
        /// </para>
        /// </summary>
        public static EFodneventosactde fobRegBuscarOdneventosactde(string tcrCodigo)
        {
            EFodneventosactde lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNSERVICIOSIPS: Servicios Ips para odontologia
        //-------------------------------------------------------
        #region Buscar ODNSERVICIOSIPS: Logica
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TITULO: Servicios Ips para odontologia</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista servicios desde manual de Servicios IPS que son graficables
        /// en el odontograma
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnserviciosips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnserviciosips.FirstOrDefault(p => p.odn_codser_odsi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNSERVICIOSIPS: String
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TITULO: Servicios Ips para odontologia</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desser_odsi
        /// (campo 'DE' de la tabla odnserviciosips) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista servicios desde manual de Servicios IPS que son graficables
        /// en el odontograma
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnserviciosips(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnserviciosips.FirstOrDefault(p => p.odn_codser_odsi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desser_odsi;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNSERVICIOSIPS: Registro
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TITULO: Servicios Ips para odontologia</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnserviciosips desde la tabla
        /// odnserviciosips cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista servicios desde manual de Servicios IPS que son graficables
        /// en el odontograma
        /// </para>
        /// </summary>
        public static EFodnserviciosips fobRegBuscarOdnserviciosips(string tcrCodigo)
        {
            EFodnserviciosips lobReturn = new EFodnserviciosips();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnserviciosips.FirstOrDefault(p => p.odn_codser_odsi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ODNSERVICIOSIPS: Registro Codigo IPS
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TITULO: Servicios Ips para odontologia</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnserviciosips dado el codigo IPS, cuando no exite retorna  null.</para>
        /// <para>DESCRIPCION TABLA:
        /// Lista servicios desde manual de Servicios IPS que son graficables
        /// en el odontograma
        /// </para>
        /// </summary>
        public static EFodnserviciosips fobRegBuscarOdnserviciosipsEx(string tcrCodigo)
        {
            EFodnserviciosips lobReturn = new EFodnserviciosips();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnserviciosips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ODNSERVICIOSIPS: Registro Codigo IPS
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TITULO: Servicios Ips para odontologia</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnserviciosips dado el codigo IPS, cuando no exite retorna  null.</para>
        /// </summary>
        public static EFodnserviciosips fobRegBuscarOdnserviciosipsExN(string tcrCodigoServIPS)
        {
            EFodnserviciosips lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnserviciosips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigoServIPS);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNDIAGNOSTICOS: Diagnosticos odontologicos
        //-------------------------------------------------------
        #region Buscar ODNDIAGNOSTICOS: Logica
        /// <summary>
        /// <para>TABLA: odndiagnosticos</para>
        /// <para>TITULO: Diagnosticos odontologicos</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Diagnosticos Utilizados en Odontologia, homologables
        /// con la CIE-10
        /// </para>
        /// </summary>
        public static bool flgBuscarOdndiagnosticos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odndiagnosticos.FirstOrDefault(p => p.odn_coddia_oddx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNDIAGNOSTICOS: String
        /// <summary>
        /// <para>TABLA: odndiagnosticos</para>
        /// <para>TITULO: Diagnosticos odontologicos</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desdia_oddx
        /// (campo 'DE' de la tabla odndiagnosticos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Diagnosticos Utilizados en Odontologia, homologables
        /// con la CIE-10
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdndiagnosticos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odndiagnosticos.FirstOrDefault(p => p.odn_coddia_oddx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desdia_oddx;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNDIAGNOSTICOS: Registro
        /// <summary>
        /// <para>TABLA: odndiagnosticos</para>
        /// <para>TITULO: Diagnosticos odontologicos</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodndiagnosticos desde la tabla
        /// odndiagnosticos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Diagnosticos Utilizados en Odontologia, homologables
        /// con la CIE-10
        /// </para>
        /// </summary>
        public static EFodndiagnosticos fobRegBuscarOdndiagnosticos(string tcrCodigo)
        {
            EFodndiagnosticos lobReturn = new EFodndiagnosticos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odndiagnosticos.FirstOrDefault(p => p.odn_coddia_oddx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNIMAGENGRAFMS: Maestro imágenes para configurar graficas
        //-------------------------------------------------------
        #region Buscar ODNIMAGENGRAFMS: Logica
        /// <summary>
        /// <para>TABLA: odnimagengrafms</para>
        /// <para>TITULO: Maestro imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista imágenes para configurar graficas en odontograma o vista
        /// maxilofacial u  otro tipo de graficas para historia clinica
        /// odontologica
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnimagengrafms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafms.FirstOrDefault(p => p.odn_codimg_odim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNIMAGENGRAFMS: String
        /// <summary>
        /// <para>TABLA: odnimagengrafms</para>
        /// <para>TITULO: Maestro imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desimg_odim
        /// (campo 'DE' de la tabla odnimagengrafms) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista imágenes para configurar graficas en odontograma o vista
        /// maxilofacial u  otro tipo de graficas para historia clinica
        /// odontologica
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnimagengrafms(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafms.FirstOrDefault(p => p.odn_codimg_odim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desimg_odim;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNIMAGENGRAFMS: Registro
        /// <summary>
        /// <para>TABLA: odnimagengrafms</para>
        /// <para>TITULO: Maestro imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnimagengrafms desde la tabla
        /// odnimagengrafms cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista imágenes para configurar graficas en odontograma o vista
        /// maxilofacial u  otro tipo de graficas para historia clinica
        /// odontologica
        /// </para>
        /// </summary>
        public static EFodnimagengrafms fobRegBuscarOdnimagengrafms(string tcrCodigo)
        {
            EFodnimagengrafms lobReturn = new EFodnimagengrafms();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafms.FirstOrDefault(p => p.odn_codimg_odim == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNIMAGENGRAFDE: Maestro detalles imágenes para configurar graficas
        //-------------------------------------------------------
        #region Buscar ODNIMAGENGRAFDE: Logica
        /// <summary>
        /// <para>TABLA: odnimagengrafde</para>
        /// <para>TITULO: Maestro detalles imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles de imágenes para configurar graficas en odontograma
        /// o vista maxilofacial u  otro tipo de graficas para historia
        /// clinica odontologica
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnimagengrafde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafde.FirstOrDefault(p => p.odn_codimg_odid == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNIMAGENGRAFDE: String
        /// <summary>
        /// <para>TABLA: odnimagengrafde</para>
        /// <para>TITULO: Maestro detalles imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desimg_odid
        /// (campo 'DE' de la tabla odnimagengrafde) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles de imágenes para configurar graficas en odontograma
        /// o vista maxilofacial u  otro tipo de graficas para historia
        /// clinica odontologica
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnimagengrafde(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafde.FirstOrDefault(p => p.odn_codimg_odid == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desimg_odid;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNIMAGENGRAFDE: Registro
        /// <summary>
        /// <para>TABLA: odnimagengrafde</para>
        /// <para>TITULO: Maestro detalles imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnimagengrafde desde la tabla
        /// odnimagengrafde cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles de imágenes para configurar graficas en odontograma
        /// o vista maxilofacial u  otro tipo de graficas para historia
        /// clinica odontologica
        /// </para>
        /// </summary>
        public static EFodnimagengrafde fobRegBuscarOdnimagengrafde(string tcrCodigo)
        {
            EFodnimagengrafde lobReturn = new EFodnimagengrafde();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafde.FirstOrDefault(p => p.odn_codimg_odid == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ODNIMAGENGRAFDE: Registro llave generada
        /// <summary>
        /// <para>TABLA: odnimagengrafde</para>
        /// <para>TITULO: Maestro detalles imágenes para configurar graficas</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnimagengrafde desde la tabla
        /// odnimagengrafde dada la llave para graficar, devuelve null cuando no existen datos.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles de imágenes para configurar graficas en odontograma
        /// o vista maxilofacial u  otro tipo de graficas para historia
        /// clinica odontologica
        /// </para>
        /// </summary>
        public static EFodnimagengrafde fobRegBuscarOdnimagengrafdeEx(string tcrCodigo)
        {
            EFodnimagengrafde lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimagengrafde.FirstOrDefault(p => p.odn_llavei_odid == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNMAESTDIENTES: Maestro lista de Dientes segun el odontograma
        //-------------------------------------------------------
        #region Buscar ODNMAESTDIENTES: Logica
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TITULO: Maestro lista de Dientes segun el odontograma</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Lista de Dientes segun el odontograma  Ejm: 11, 12,
        /// 13,…
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnmaestdientes(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmaestdientes.FirstOrDefault(p => p.odn_coddie_oddi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNMAESTDIENTES: String
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TITULO: Maestro lista de Dientes segun el odontograma</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desdie_oddi
        /// (campo 'DE' de la tabla odnmaestdientes) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Lista de Dientes segun el odontograma  Ejm: 11, 12,
        /// 13,…
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnmaestdientes(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmaestdientes.FirstOrDefault(p => p.odn_coddie_oddi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desdie_oddi;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNMAESTDIENTES: Registro
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TITULO: Maestro lista de Dientes segun el odontograma</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnmaestdientes desde la tabla
        /// odnmaestdientes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Lista de Dientes segun el odontograma  Ejm: 11, 12,
        /// 13,…
        /// </para>
        /// </summary>
        public static EFodnmaestdientes fobRegBuscarOdnmaestdientes(string tcrCodigo)
        {
            EFodnmaestdientes lobReturn = new EFodnmaestdientes();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmaestdientes.FirstOrDefault(p => p.odn_coddie_oddi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNMSCUADRANTES: Cuadrantes del odontograma o graficador
        //-------------------------------------------------------
        #region Buscar ODNMSCUADRANTES: Logica
        /// <summary>
        /// <para>TABLA: odnmscuadrantes</para>
        /// <para>TITULO: Cuadrantes del odontograma o graficador</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Cuadrantes que conforman el odontograma o cualquier
        /// otro graficadorejem:  1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante
        /// 3, 4=Cuadrante 4
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnmscuadrantes(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmscuadrantes.FirstOrDefault(p => p.odn_codcte_odcd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNMSCUADRANTES: String
        /// <summary>
        /// <para>TABLA: odnmscuadrantes</para>
        /// <para>TITULO: Cuadrantes del odontograma o graficador</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_descte_odcd
        /// (campo 'DE' de la tabla odnmscuadrantes) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Cuadrantes que conforman el odontograma o cualquier
        /// otro graficadorejem:  1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante
        /// 3, 4=Cuadrante 4
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnmscuadrantes(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmscuadrantes.FirstOrDefault(p => p.odn_codcte_odcd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_descte_odcd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNMSCUADRANTES: Registro
        /// <summary>
        /// <para>TABLA: odnmscuadrantes</para>
        /// <para>TITULO: Cuadrantes del odontograma o graficador</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnmscuadrantes desde la tabla
        /// odnmscuadrantes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Cuadrantes que conforman el odontograma o cualquier
        /// otro graficadorejem:  1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante
        /// 3, 4=Cuadrante 4
        /// </para>
        /// </summary>
        public static EFodnmscuadrantes fobRegBuscarOdnmscuadrantes(string tcrCodigo)
        {
            EFodnmscuadrantes lobReturn = new EFodnmscuadrantes();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnmscuadrantes.FirstOrDefault(p => p.odn_codcte_odcd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNANATOMDIENTE: Anatomia  y caras de cada diente
        //-------------------------------------------------------
        #region Buscar ODNANATOMDIENTE: Logica
        /// <summary>
        /// <para>TABLA: odnanatomdiente</para>
        /// <para>TITULO: Anatomia  y caras de cada diente</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Anatomia del Diente: Lista de Caras anatomicas del diente ejm
        /// :1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal, 5=Oclusal,
        /// 6 = Corona, 7 = Diente, 8 = NA
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnanatomdiente(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnanatomdiente.FirstOrDefault(p => p.odn_codana_odan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNANATOMDIENTE: String
        /// <summary>
        /// <para>TABLA: odnanatomdiente</para>
        /// <para>TITULO: Anatomia  y caras de cada diente</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en odn_desana_odan
        /// (campo 'DE' de la tabla odnanatomdiente) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Anatomia del Diente: Lista de Caras anatomicas del diente ejm
        /// :1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal, 5=Oclusal,
        /// 6 = Corona, 7 = Diente, 8 = NA
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnanatomdiente(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnanatomdiente.FirstOrDefault(p => p.odn_codana_odan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_desana_odan;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNANATOMDIENTE: Registro
        /// <summary>
        /// <para>TABLA: odnanatomdiente</para>
        /// <para>TITULO: Anatomia  y caras de cada diente</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnanatomdiente desde la tabla
        /// odnanatomdiente cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Anatomia del Diente: Lista de Caras anatomicas del diente ejm
        /// :1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal, 5=Oclusal,
        /// 6 = Corona, 7 = Diente, 8 = NA
        /// </para>
        /// </summary>
        public static EFodnanatomdiente fobRegBuscarOdnanatomdiente(string tcrCodigo)
        {
            EFodnanatomdiente lobReturn = new EFodnanatomdiente();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnanatomdiente.FirstOrDefault(p => p.odn_codana_odan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ODNIMGCRACORONA: Nombre de imágenes para caras vista corona
        //-------------------------------------------------------
        #region Buscar ODNIMGCRACORONA: Logica
        /// <summary>
        /// <para>TABLA: odnimgcracorona</para>
        /// <para>TITULO: Nombre de imágenes para caras vista corona</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes para cada una de  las caras  de la corona
        /// en la vista del odontograma, con sus diferentes estados: 1=
        /// Pendiente 2= En proceso 3 = Finalizado
        /// </para>
        /// </summary>
        public static bool flgBuscarOdnimgcracorona(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimgcracorona.FirstOrDefault(p => p.odn_codcar_odcr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ODNIMGCRACORONA: String
        /// <summary>
        /// <para>TABLA: odnimgcracorona</para>
        /// <para>TITULO: Nombre de imágenes para caras vista corona</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla odnimgcracorona) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes para cada una de  las caras  de la corona
        /// en la vista del odontograma, con sus diferentes estados: 1=
        /// Pendiente 2= En proceso 3 = Finalizado
        /// </para>
        /// </summary>
        public static string fcrDEBuscarOdnimgcracorona(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimgcracorona.FirstOrDefault(p => p.odn_codcar_odcr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.odn_imagen_odcr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ODNIMGCRACORONA: Registro
        /// <summary>
        /// <para>TABLA: odnimgcracorona</para>
        /// <para>TITULO: Nombre de imágenes para caras vista corona</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFodnimgcracorona desde la tabla
        /// odnimgcracorona cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de imágenes para cada una de  las caras  de la corona
        /// en la vista del odontograma, con sus diferentes estados: 1=
        /// Pendiente 2= En proceso 3 = Finalizado
        /// </para>
        /// </summary>
        public static EFodnimgcracorona fobRegBuscarOdnimgcracorona(string tcrCodigo)
        {
            EFodnimgcracorona lobReturn = new EFodnimgcracorona();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odnimgcracorona.FirstOrDefault(p => p.odn_codcar_odcr == tcrCodigo);
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

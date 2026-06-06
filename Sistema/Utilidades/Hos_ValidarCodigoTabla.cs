using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class HOSValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // HOS - MODULO HOSPITALIZACION 
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // HOSHABITACIONES: Habitaciones
        //-------------------------------------------------------
        #region Buscar HOSHABITACIONES: Habitaciones
        #region Buscar Tipo string
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TITULO: Habitaciones</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hos_deshab_habi
        /// (campo 'DE' de la tabla hoshabitaciones) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista habitaciones con sus numeros, que pertenecen a una seccion
        /// (una secccion puede tener varias habitaciones) ejm: HA001=
        /// 201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
        /// HA004 = 103 HOSPITALIZACION NIÑOS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHoshabitaciones(string tcrCodigo)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.hos_deshab_habi;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar Tipo Registro
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TITULO: Habitaciones</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhoshabitaciones desde la tabla
        /// hoshabitaciones cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista habitaciones con sus numeros, que pertenecen a una seccion
        /// (una secccion puede tener varias habitaciones) ejm: HA001=
        /// 201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
        /// HA004 = 103 HOSPITALIZACION NIÑOS
        /// </para>
        /// </summary>
        public static EFhoshabitaciones fobRegBuscarHoshabitaciones(string tcrCodigo)
        {
            EFhoshabitaciones lobReturn = new EFhoshabitaciones();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar Tipo logica
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TITULO: Habitaciones</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista habitaciones con sus numeros, que pertenecen a una seccion
        /// (una secccion puede tener varias habitaciones) ejm: HA001=
        /// 201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
        /// HA004 = 103 HOSPITALIZACION NIÑOS
        /// </para>
        /// </summary>
        public static bool flgBuscarHoshabitaciones(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // HOSTIPOCAMAS: Tipos de camas según ergonomia
        //-------------------------------------------------------
        #region Buscar HOSTIPOCAMAS: Tipos de camas según ergonomia
        #region Buscar Tipo string
        /// <summary>
        /// <para>TABLA: hostipocamas</para>
        /// <para>TITULO: Tipos de camas según ergonomia</para>
        /// <para>MODULO: HOS</para>
        /// <para>DESCRIPCION:
        /// Tipos de camas según ergonomia : 1 = Cama Metaica de somier
        /// Rigido 2 = Cama articulada 3 = Cama electronica motorizada
        /// 4 = Camas Ortopedicas y otras, Fuente: http://apuntesauxiliarenfermeria.b
        /// logspot.com/2011/02/tipos-de-camas-hospitalarias.html
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHostipocamas(string tcrCodigo)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hostipocamas.FirstOrDefault(p => p.hos_tipcam_tcam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.hos_destip_tcam;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar Tipo Registro
        /// <summary>
        /// <para>TABLA: hostipocamas</para>
        /// <para>TITULO: Tipos de camas según ergonomia</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhostipocamas desde la tabla
        /// hostipocamas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipos de camas según ergonomia : 1 = Cama Metaica de somier
        /// Rigido 2 = Cama articulada 3 = Cama electronica motorizada
        /// 4 = Camas Ortopedicas y otras. 
        /// </para>
        /// </summary>
        public static EFhostipocamas fobRegBuscarHostipocamas(string tcrCodigo)
        {
            EFhostipocamas lobReturn = new EFhostipocamas();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hostipocamas.FirstOrDefault(p => p.hos_tipcam_tcam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar Tipo Logica
        /// <summary>
        /// <para>TABLA: hostipocamas</para>
        /// <para>TITULO: Tipos de camas según ergonomia</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipos de camas según ergonomia : 1 = Cama Metaica de somier
        /// Rigido 2 = Cama articulada 3 = Cama electronica motorizada
        /// 4 = Camas Ortopedicas y otras, Fuente: http://apuntesauxiliarenfermeria.b
        /// logspot.com/2011/02/tipos-de-camas-hospitalarias.html
        /// </para>
        /// </summary>
        public static bool flgBuscarHostipocamas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hostipocamas.FirstOrDefault(p => p.hos_tipcam_tcam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // HOSSECCIONAREAS: Secciones por area prestacion servicios
        //-------------------------------------------------------
        #region Buscar HOSSECCIONAREAS: Secciones por area prestacion servicios
        #region Buscar Tipo string
        /// <summary>
        /// <para>TABLA: hosseccionareas</para>
        /// <para>TITULO: Secciones por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>DESCRIPCION:
        /// Secciones en las cuales estan subdivididas las areas de prestacion
        /// de servicios de  hospitalizacion y observacion  ejm: S001=
        /// Hospitalizacion Mujeres, S002 =Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHosseccionareas(string tcrCodigo)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosseccionareas.FirstOrDefault(p => p.hos_codsec_hsec == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.hos_dessec_hsec;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar Tipo Registro
        /// <summary>
        /// <para>TABLA: hosseccionareas</para>
        /// <para>TITULO: Secciones por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhosseccionareas desde la tabla
        /// hosseccionareas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Secciones en las cuales estan subdivididas las areas de prestacion
        /// de servicios de  hospitalizacion y observacion  ejm: S001=
        /// Hospitalizacion Mujeres, S002 =Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static EFhosseccionareas fobRegBuscarHosseccionareas(string tcrCodigo)
        {
            EFhosseccionareas lobReturn = new EFhosseccionareas();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosseccionareas.FirstOrDefault(p => p.hos_codsec_hsec == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar Tipo Logica
        /// <summary>
        /// <para>TABLA: hosseccionareas</para>
        /// <para>TITULO: Secciones por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Secciones en las cuales estan subdivididas las areas de prestacion
        /// de servicios de  hospitalizacion y observacion  ejm: S001=
        /// Hospitalizacion Mujeres, S002 =Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static bool flgBuscarHosseccionareas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosseccionareas.FirstOrDefault(p => p.hos_codsec_hsec == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // HOSESTADOCAMA: Estado de las camas existentes
        //-------------------------------------------------------
        #region Buscar HOSESTADOCAMA: Estado de las camas existentes
        #region Buscar Tipo String
        /// <summary>
        /// <para>TABLA: hosestadocamas</para>
        /// <para>TITULO: Estado de las camas existentes</para>
        /// <para>MODULO: HOS</para>
        /// <para>DESCRIPCION:
        /// Estado de las camas existentes en un area especifica de la
        /// IPS:  1=Libre 2=Ocupada 3=Reserva 4=Reparacion 5=Inactiva
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHosestadocama(string tcrCodigo)
        {
            string llgReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestadocama.FirstOrDefault(p => p.hos_estcam_ecam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = lobjRegistro.hos_desest_ecam;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar Tipo Registro
        /// <summary>
        /// <para>TABLA: hosestadocama</para>
        /// <para>TITULO: Estado de las camas existentes</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhosestadocama desde la tabla
        /// hosestadocama cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estado de las camas existentes en un area especifica de la
        /// IPS:  1=Libre 2=Ocupada 3=Reserva 4=Reparacion 5=Inactiva
        /// </para>
        /// </summary>
        public static EFhosestadocama fobRegBuscarHosestadocama(string tcrCodigo)
        {
            EFhosestadocama lobReturn = new EFhosestadocama();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestadocama.FirstOrDefault(p => p.hos_estcam_ecam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar Tipo Logica
        /// <summary>
        /// <para>TABLA: hosestadocama</para>
        /// <para>TITULO: Estado de las camas existentes</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estado de las camas existentes en un area especifica de la
        /// IPS:  1=Libre 2=Ocupada 3=Reserva 4=Reparacion 5=Inactiva
        /// </para>
        /// </summary>
        public static bool flgBuscarHosestadocama(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestadocama.FirstOrDefault(p => p.hos_estcam_ecam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // HOSCAMASAREAS: Camas por area prestacion servicios
        //-------------------------------------------------------
        #region Buscar HOSCAMASAREAS: Logica
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TITULO: Camas por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de camas creadas en el sistema, según las camas existentes
        /// en cada area funcional de la IPS ejm: Cama Hospitalizacion
        /// Mujeres, Cama Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static bool flgBuscarHoscamasareas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HOSCAMASAREAS: String
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TITULO: Camas por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en hos_descam_caho
        /// (campo 'DE' de la tabla hoscamasareas) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de camas creadas en el sistema, según las camas existentes
        /// en cada area funcional de la IPS ejm: Cama Hospitalizacion
        /// Mujeres, Cama Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static string fcrDEBuscarHoscamasareas(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.hos_descam_caho;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar HOSCAMASAREAS: Registro
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TITULO: Camas por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhoscamasareas desde la tabla
        /// hoscamasareas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de camas creadas en el sistema, según las camas existentes
        /// en cada area funcional de la IPS ejm: Cama Hospitalizacion
        /// Mujeres, Cama Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static EFhoscamasareas fobRegBuscarHoscamasareas(string tcrCodigo)
        {
            EFhoscamasareas lobReturn = new EFhoscamasareas();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // HOSESTANCIAPACI: Maestro de estancias y traslados
        //-------------------------------------------------------
        #region Buscar HOSESTANCIAPACI: Logica
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TITULO: Maestro de estancias y traslados</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar las estancias y traslados de pacientes
        /// desde una cama a otra que esta en la misma area o difrentes
        /// areas de prestacion servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarHosestanciapaci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestanciapaci.FirstOrDefault(p => p.hos_codesp_espa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HOSESTANCIAPACI: Registro
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TITULO: Maestro de estancias y traslados</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhosestanciapaci desde la tabla
        /// hosestanciapaci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar las estancias y traslados de pacientes
        /// desde una cama a otra que esta en la misma area o difrentes
        /// areas de prestacion servicios
        /// </para>
        /// </summary>
        public static EFhosestanciapaci fobRegBuscarHosestanciapaci(string tcrCodigo)
        {
            EFhosestanciapaci lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestanciapaci.FirstOrDefault(p => p.hos_codesp_espa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar HOSESTANCIAPACI: Registro por Id Admision
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TITULO: Maestro de estancias y traslados</para>
        /// <para>MODULO: HOS: HOSPITALIZACION</para>
        /// <para>VALOR RETORNO: Devuelve el registro de traslado mas reciente dado el codigo de admision </para>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoRegistro: "TODOS" = No especifica el tipo  "1"= Traslado desde urgencias "2"= Traslados intrahospitalarios</para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar las estancias y traslados de pacientes
        /// desde una cama a otra que esta en la misma area o difrentes
        /// areas de prestacion servicios
        /// </para>
        /// </summary>
        public static EFhosestanciapaci fobRegBuscarHosestanciapaciEx(String tcrTipoRegistro, String tcrIdAdmision)
        {
            EFhosestanciapaci lobReturn = null;
            IOrderedQueryable<EFhosestanciapaci> lobjRegistro = null;

            using (_context = new DbAplicacion())
            {
                if (tcrTipoRegistro == "TODOS")
                {
                    lobjRegistro = from tmp in _context.Hosestanciapaci
                                   where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                         tmp.sis_estpro_espr != "3"
                                   orderby tmp.hos_vistar_espa descending
                                   select tmp;
                }
                else
                {
                    lobjRegistro = from tmp in _context.Hosestanciapaci
                                   where tmp.adm_secadm_rgad == tcrIdAdmision &&
                                         tmp.hos_tipesp_espa == tcrTipoRegistro &&
                                         tmp.sis_estpro_espr != "3"
                                   orderby tmp.hos_vistar_espa descending
                                   select tmp;
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
        // HOSCONFIGMODULO: Configuración modulo hospitalización
        //-------------------------------------------------------
        #region Buscar HOSCONFIGMODULO: Logica
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TITULO: Configuración modulo hospitalización</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuración parametros generales de funcionamiento modulo
        /// hospitalización
        /// </para>
        /// </summary>
        public static bool flgBuscarHosconfigmodulo(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosconfigmodulo.FirstOrDefault(p => p.hos_codsys_hoxx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HOSCONFIGMODULO: Registro
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TITULO: Configuración modulo hospitalización</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFhosconfigmodulo desde la tabla
        /// hosconfigmodulo cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuración parametros generales de funcionamiento modulo
        /// hospitalización
        /// </para>
        /// </summary>
        public static EFhosconfigmodulo fobRegBuscarHosconfigmodulo(string tcrCodigo)
        {
            EFhosconfigmodulo lobReturn =null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosconfigmodulo.FirstOrDefault(p => p.hos_codsys_hoxx == tcrCodigo);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sistema.Utilidades;
using Datos.Modelos;

namespace Sistema.Modelo
{
    //public class SysModelo : clBaseInpc
    public class SysModelo
    {
        //-------------------------------------------------------
        // Funciones de gestion par datos dentro de un perfil 
        // y edicion de registros 
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------

        //-------------------------------------------------------
        // fcrGenerarNuevoCodigo: Generar nuevo secuencial de registros en formularios
        //-------------------------------------------------------
        #region fcrGenerarNuevoCodigo: Generar nuevo secuencial de registros en formularios
        #region Modelo Propiedades pivadas
        static string  Sys_codsec_gcod;
        static string  Sys_codmod_modu;
        static string  Sys_dessec_gcod;
        static int     Sys_ultsec_gcod;
        static int     Sys_inisec_gcod;
        static int     Sys_finsec_gcod;
        static int     Sys_maxsec_gcod;
        static int     Sys_alrsec_gcod;
        static string  Sys_relcer_gcod;
        static string  Sys_prefij_gcod;
        static string  Sys_sufijo_gcod;
        static string  Sys_incfec_gcod;
        static string  Sys_locfec_gcod;
        static string  Sys_forfec_gcod;
        static string  Sys_incdia_gcod;
        static string  Sys_incmes_gcod;
        static string  Sys_incano_gcod;
        static string  Sys_nivacc_gcod;
        #endregion
        // Modelo Propiedades Notificacion
        //-----------------------------------------
        // fcrGenerarNuevoCodigo: Metodo publico 
        //-----------------------------------------
        #region fcrGenerarNuevoCodigo: Metodo publico para gestion uso comun
        /// <summary>
        /// <para>fcrGenerarNuevoCodigo:</para>
        /// <para>Genera el nuevo secuencial de registro para la llave dada en el parametro 'tcrllave' 
        /// cuando no existe en Maestros de Secuenciales, se crea el generador del registro con 
        /// parametros por defecto.
        /// </para>
        /// <para>RETORNA:</para>
        /// <para> Valor de tipo string con formato configurado en
        /// maestro de secuenciales ejm: ID0025, AD01013-25,...
        /// </para>
        /// <para>PARAMETROS</para>
        /// <para>tcrllave:</para>
        /// <para>Llave para localizar el registro en Maestro de Secuenciales</para>
        /// <para>tcrCodigoModulo:</para> 
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// <para>tcrTitulo:</para>
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// </summary>
        public static string fcrGenerarNuevoCodigo(string tcrllave, string tcrCodigoModulo, string tcrTitulo)
        {
            //- Tomar parametros
            Sys_codsec_gcod = tcrllave;	        // llave  Registro
            Sys_codmod_modu	= tcrCodigoModulo;  // Codigo Modulo
            Sys_dessec_gcod = tcrTitulo;        // Nombre Secuencial
            //- Variables de control
            string lcrNuevoCodigo = string.Empty;
            bool llgSinError = true;

            if (flgBuscar()) // si lo encuentra actualiza
            {
                llgSinError = flgActualizar();
            }
            else 
            {
                llgSinError = flgAdicionar();
            }

            //- si no hubo error complementar codigo
            if (llgSinError == true)
            {
                lcrNuevoCodigo = fcrGenFormatoSecuencial();
            }
            return lcrNuevoCodigo;
        }
        #endregion
        #region fnuGenerarNuevoCodigoNumerico: Metodo publico para gestion Numerico
        /// <summary>
        /// <para>fcrGenerarNuevoCodigo:</para>
        /// <para>Genera el nuevo secuencial de registro para la llave dada en el parametro 'tcrllave' </para>
        /// <para>cuando no existe en Maestros lo genera, devuelve nuevo valor secuencial numerico </para>
        /// <para>RETORNA:</para>
        /// <para> Valor tipo numerico entero que representa el nuevo numero secuencial generado</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrllave:</para>
        /// <para>Llave para localizar el registro en Maestro de Secuenciales</para>
        /// <para>tcrCodigoModulo:</para> 
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// <para>tcrTitulo:</para>
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// </summary>
        public static int fnuGenerarNuevoCodigoNumerico(string tcrllave, string tcrCodigoModulo, string tcrTitulo)
        {
            //- Tomar parametros
            Sys_codsec_gcod = tcrllave;	        // llave  Registro
            Sys_codmod_modu = tcrCodigoModulo;  // Codigo Modulo
            Sys_dessec_gcod = tcrTitulo;        // Nombre Secuencial
            //- Variables de control
            string lcrNuevoCodigo = string.Empty;
            bool llgSinError = true;

            if (flgBuscar()) // si lo encuentra actualiza
            {
                llgSinError = flgActualizar();
            }
            else
            {
                llgSinError = flgAdicionar();
            }

            return Sys_ultsec_gcod;
        }
        #endregion
        //-----------------------------------------
        // fcrGenFormatoSecuencial:  complementa el nuevo secuencial
        //-----------------------------------------
        #region Complementa el formato del nuevo secuencial
        private static string fcrGenFormatoSecuencial()
        {
            string lcrReturn = string.Empty;
            int lnuCharExiste = 0;
            int lnuMaxRelleno = 0;
            try
            {
                lnuCharExiste = Sys_prefij_gcod.Trim().Length + Sys_ultsec_gcod.ToString().Trim().Length;
                lnuMaxRelleno=(Sys_maxsec_gcod-lnuCharExiste);
                if (Sys_relcer_gcod == "1" && lnuMaxRelleno > 0 ) // Rellenar con ceros
                {
                    string lcrRelleno = "0";
                    lcrReturn = Sys_prefij_gcod.Trim() + lcrRelleno.PadLeft(lnuMaxRelleno,'0').Trim() + Sys_ultsec_gcod.ToString().Trim();
                }
                else 
                {
                    lcrReturn = Sys_prefij_gcod.Trim().ToUpper() + Sys_ultsec_gcod.ToString().Trim();
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al complementar Nuevo Secuencial Metodo: fcrGenFormatoSecuencial");
            }
            return lcrReturn;
        }
        #endregion
        #region Complementa el formato del nuevo secuencial extra
        /// <summary>
        /// Genera el complemento del numero secuencial dado en parametro tnuUltimoSecGenerado, util para procesos por lotes
        /// </summary>
        /// <param name="tobRegSecuencial">Registro en maestro de secuenciales</param>
        /// <param name="tnuUltimoSecGenerado">Valor numerico secuencial al cual se pretende completar la llave</param>
        /// <returns>dado el numero a completar, retorna un codigo secuencial completo con prefijos y demas</returns>
        public static String fcrGenFormatoSecuencial(EFsysgeneradorcod tobRegSecuencial, int tnuUltimoSecGenerado)
        {
            string lcrReturn = string.Empty;
            int lnuCharExiste = 0;
            int lnuMaxRelleno = 0;
            try
            {
                lnuCharExiste = tobRegSecuencial.sys_prefij_gcod.Trim().Length + tnuUltimoSecGenerado.ToString().Trim().Length;
                lnuMaxRelleno = ((int)tobRegSecuencial.sys_maxsec_gcod - lnuCharExiste);
                if (tobRegSecuencial.sys_relcer_gcod == "1" && lnuMaxRelleno > 0) // Rellenar con ceros
                {
                    String lcrRelleno = "0";
                    lcrReturn = tobRegSecuencial.sys_prefij_gcod.Trim() + lcrRelleno.PadLeft(lnuMaxRelleno, '0').Trim() + tnuUltimoSecGenerado.ToString().Trim();
                }
                else
                {
                    lcrReturn = tobRegSecuencial.sys_prefij_gcod.Trim().ToUpper() + tnuUltimoSecGenerado.ToString().Trim();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al complementar Nuevo Secuencial Metodo: fcrGenFormatoSecuencial");
            }
            return lcrReturn;
        }
        #endregion
        //-----------------------------------------
        // flgAdicionar: Adicionar Nuevo Registro
        //-----------------------------------------
        #region Adicionar Registro
        private static bool flgAdicionar()
        {
            bool llgReturn = false;
            try
            {
                if (flgValoresIniciales())
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFsysgeneradorcod
                        {
                            sys_codsec_gcod = Sys_codsec_gcod,
                            sys_codmod_modu = Sys_codmod_modu,
                            sys_dessec_gcod = Sys_dessec_gcod,
                            sys_ultsec_gcod = Sys_ultsec_gcod,
                            sys_inisec_gcod = Sys_inisec_gcod,
                            sys_finsec_gcod = Sys_finsec_gcod,
                            sys_maxsec_gcod = Sys_maxsec_gcod,
                            sys_alrsec_gcod = Sys_alrsec_gcod,
                            sys_relcer_gcod = Sys_relcer_gcod,
                            sys_prefij_gcod = Sys_prefij_gcod,
                            sys_sufijo_gcod = Sys_sufijo_gcod,
                            sys_incfec_gcod = Sys_incfec_gcod,
                            sys_locfec_gcod = Sys_locfec_gcod,
                            sys_forfec_gcod = Sys_forfec_gcod,
                            sys_incdia_gcod = Sys_incdia_gcod,
                            sys_incmes_gcod = Sys_incmes_gcod,
                            sys_incano_gcod = Sys_incano_gcod,
                            sys_nivacc_gcod = Sys_nivacc_gcod,
                        };
                        _context.AddToSysgeneradorcod(lobjRegistro);
                        _context.SaveChanges();
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al Crear Nuevo registro de Secuencial Metodo: flgAdicionar");
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion
        //-----------------------------------------
        // flgValoresIniciales: Valores iniciales para Adicionar Nuevo Registro
        //-----------------------------------------
        #region Valores iniciales
        private static bool flgValoresIniciales()
        {
            bool llgReturn = false;
            try
            {
                Sys_ultsec_gcod	=1;     // Ultimo secuencial generado
                Sys_inisec_gcod	=0;     // Numero Sec Inicial
                Sys_finsec_gcod	=0;     // Numero Sec Final
                Sys_maxsec_gcod	=10;    // Tamaño Secuencial
                Sys_alrsec_gcod	=200;  // Limite Sec Alarma
                Sys_relcer_gcod	="1";   // Rellenar con Ceros  1= Si por defecto
                Sys_prefij_gcod	="";    // Prefijo vacio por defecto
                Sys_sufijo_gcod	="";    // Sufjo vacio por defecto
                Sys_incfec_gcod	="2";   // Incluir datos Fecha 2=No por defecto
                Sys_locfec_gcod	="2";   // Localizacion del dato fecha dentro del nuevo secencial  1= Antes 2=Despues
                Sys_forfec_gcod	="1";   // Formato fecha 1= DD/MM/AA
                Sys_incdia_gcod	="2";   // Incluir Dia 2=No por defecto
                Sys_incmes_gcod	="2";   // Incluir Mes 2=No por defecto
                Sys_incano_gcod	="2";   // Incluir Año 2=No por defecto
                Sys_nivacc_gcod	="1";   // Nivel de acceso 1 = Si por defecto
                llgReturn = true;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al Iniciar valores Nuevo registro Metodo: flgValoresIniciales");
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion
        //-----------------------------------------
        // flgActualizar:  Actualizar el registro existente
        //-----------------------------------------
        #region Actualizar el registro y devolver nuevo secuencial 
        /// <summary>
        /// Actualiza y generar el nuevo numero secuencial sumando una nueva unidad
        /// </summary>
        /// <returns>Retorna un valor logico que indica si la operacion fue exitosa</returns>
        private static bool flgActualizar()
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var oReg = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == Sys_codsec_gcod);
                    if (oReg != null)
                    {
                        Sys_ultsec_gcod = (int)oReg.sys_ultsec_gcod + 1;
                        oReg.sys_ultsec_gcod = Sys_ultsec_gcod;
                        _context.SaveChanges();
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al Generar Nuevo Secuencial Metodo: flgActualizar");
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion
        #region Actualiza el maestro secuencial con el valor dado en parametro
        /// <summary>
        /// Actualiza el maestro secuencial con el valor dado en parametro
        /// </summary>
        /// <param name="tcrAccion">Accion a realizar: "1"=Sumar tnuValorSecuencial al maestro, "2"=Reemplazar tnuValorSecuencial en maestro</param>
        /// <param name="tcrLlaveSecuencial"></param>
        /// <param name="tnuValorSecuencial"></param>
        /// <returns>Retorna valor numerico actualizado en maestro secuencial, retorna cero cuando ocurre algun error</returns>
        public static int fnuActualizar(String tcrAccion, String tcrLlaveSecuencial, int tnuValorSecuencial)
        {
            int lnuReturn = 0;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var oReg = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrLlaveSecuencial);
                    if (oReg != null)
                    {
                        if (tcrAccion == "1")
                        {
                            // Sumar 
                            oReg.sys_ultsec_gcod = oReg.sys_ultsec_gcod + tnuValorSecuencial;
                        }
                        else
                        {
                            oReg.sys_ultsec_gcod = tnuValorSecuencial;
                        }
                        _context.SaveChanges();
                        lnuReturn = (int)oReg.sys_ultsec_gcod;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al Generar Nuevo Secuencial Metodo: fnuActualizar");
                lnuReturn = 0;
            }
            return lnuReturn;
        }
        #endregion
        //-----------------------------------------
        // flgBuscar : Buscar registro existente
        //-----------------------------------------
        #region Buscar registro existente
        private static bool flgBuscar()
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var oReg = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == Sys_codsec_gcod);
                if (oReg != null)
                {
                    Sys_codsec_gcod = oReg.sys_codsec_gcod;
                    Sys_codmod_modu = oReg.sys_codmod_modu;
                    Sys_dessec_gcod = oReg.sys_dessec_gcod;
                    Sys_ultsec_gcod = (int)oReg.sys_ultsec_gcod;
                    Sys_inisec_gcod = (int)oReg.sys_inisec_gcod;
                    Sys_finsec_gcod = (int)oReg.sys_finsec_gcod;
                    Sys_maxsec_gcod = (int)oReg.sys_maxsec_gcod;
                    Sys_alrsec_gcod = (int)oReg.sys_alrsec_gcod;
                    Sys_relcer_gcod = oReg.sys_relcer_gcod;
                    Sys_prefij_gcod = oReg.sys_prefij_gcod;
                    Sys_sufijo_gcod = oReg.sys_sufijo_gcod;
                    Sys_incfec_gcod = oReg.sys_incfec_gcod;
                    Sys_locfec_gcod = oReg.sys_locfec_gcod;
                    Sys_forfec_gcod = oReg.sys_forfec_gcod;
                    Sys_incdia_gcod = oReg.sys_incdia_gcod;
                    Sys_incmes_gcod = oReg.sys_incmes_gcod;
                    Sys_incano_gcod = oReg.sys_incano_gcod;
                    Sys_nivacc_gcod = oReg.sys_nivacc_gcod;
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // SYSACCIONPERFIL: Acciones y eventos de formulario  para un perfil
        //-------------------------------------------------------
        #region SYSACCIONPERFIL: Acciones y eventos de formulario  para un perfil
        /// <summary>
        /// <para>fcrValidarAcccionPerfil:</para>
        /// <para>Valida que el perfil activo pueda realizar la accion dada en parametro 'tcrllave' 
        /// </para>
        /// <para>RETORNA:</para>
        /// <para> Valor de tipo string: 'OK' = El perfil esta autorizado para realizar la acción 
        /// 'NO' = El perfil no tiene permiso para realizar la acción
        /// </para>
        /// <para>PARAMETROS</para>
        /// <para>tcrllave:</para>
        /// <para>(IdFormulario+CmdBoton+Accion) Llave para localizar el registro en Maestro de acciones por perfil
        /// ejem: 'FRM023-CMDADICIONAR-ADD' -> Validacion si el perfil puede Adicionar registros en 
        /// el formulario con el Id: FRM023
        /// </para>
        /// <para>tcrPefil:</para> 
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// <para>tcrTitulo:</para>
        /// <para>Se requiere por si es necesario generar el registro en Maestro de Secuenciales</para>
        /// </summary>
        public static string fcrValidarAcccionPerfil(string tcrPerfil, string tcrllave, string tcTipoAccion)
        {
            string llgReturn = "NO";
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysaccionperfil.FirstOrDefault(p => p.sys_codper_perf == tcrPerfil && p.sys_accper_aper == tcrllave);
                if (lobjRegistro != null)
                {
                    llgReturn = "OK";
                };
            }
            return llgReturn;
        }
        #endregion

    }
}

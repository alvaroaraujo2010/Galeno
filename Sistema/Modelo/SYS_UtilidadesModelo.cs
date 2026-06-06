using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Sistema.Clases;
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
    //Genrar Numero factura dian
    public class SysModeloFacturaDian : clBaseInpc
    {
        #pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        //-------------------------------------------------------
        // Funciones de gestion Nuevo numero de factura Dian
        //-------------------------------------------------------
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secres_srfa: Codgo unico resolución
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codgo unico resolución</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Secuencial unico resolución Dian en sistema, registro desde el cual se genero el numero de factura</para>
        /// </summary>
        public String Fcm_secres_srfa;
        #endregion
        #region Fcm_numres_srfa: Resolucion DIAN
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Numero de resolucion Dian autorizada</para>
        /// </summary>
        public String Fcm_numres_srfa;
        #endregion
        #region Fcm_desres_srfa: Descripción
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota  de la resolucion Dian
        /// </para>
        /// </summary>
        public String Fcm_desres_srfa;
        #endregion
        #region Fcm_notenc_srfa: Nota de encabezado
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_notenc_srfa;
        #endregion
        #region Fcm_noppag_srfa: Nota pie de pagina
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_noppag_srfa;
        #endregion
        #region Fcm_fecini_srfa: Fecha Inicia vigencia
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha Inicia vigencia</para>
        /// <para>NOMBRE: fcm_fecini_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha en que inicia vigencia para ser utilzada por el sistema
        /// </para>
        /// </summary>
        public DateTime Fcm_fecini_srfa;
        #endregion
        #region Fcm_facini_srfa: Numero secuencial inicio
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial inicio</para>
        /// <para>NOMBRE: fcm_facini_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde inicia el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facini_srfa;
        #endregion
        #region Fcm_facfin_srfa: Numero secuencial fin
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial fin</para>
        /// <para>NOMBRE: fcm_facfin_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde finaliza el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facfin_srfa;
        #endregion
        #region Fcm_ultgen_srfa: Ultimo secuencial generado
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Ultimo secuencial generado</para>
        /// <para>NOMBRE: fcm_ultgen_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ultimo Numero de factura generado (se utiliza como base para
        /// generar el siguiente)
        /// </para>
        /// </summary>
        public int Fcm_ultgen_srfa;
        #endregion
        #region Fcm_prefij_srfa: Numero de resolucion
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero de resolucion</para>
        /// <para>NOMBRE: fcm_prefij_srfa (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION: Prefijo para el numero generado</para>
        /// </summary>
        public String Fcm_prefij_srfa;
        #endregion
        #region Fcm_maxsec_srfa: Tamaño Secuencial
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: fcm_maxsec_srfa (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Inidica el tamaño maximo en caracteres para el secuencial generado
        /// como numero de factura
        /// </para>
        /// </summary>
        public int Fcm_maxsec_srfa;
        #endregion
        #region Fcm_alrsec_srfa: Limite secuencial alarma
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Limite secuencial alarma</para>
        /// <para>NOMBRE: fcm_alrsec_srfa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos numeros secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int Fcm_alrsec_srfa;
        #endregion
        #region Fcm_relcer_srfa: Rellenar con Ceros
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: fcm_relcer_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Inidica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public String Fcm_relcer_srfa;
        #endregion
        #region Fcm_estreg_srfa: Estado registro
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: fcm_estreg_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estreg_srfa;
        #endregion
        #region TipoRespuesta: Tipo Respuesta
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Tipo Respuesta Resultado secuencial</para>
        /// <para>DESCRIPCION Tipo resultado: 1=Codigo Generado OK 2=No Hay Resolución activa</para>
        /// <para>3=Secuencial agotado en resolución activa 4=Fecha Fuera del rango de resolución</para>
        /// </summary>
        public String TipoRespuesta;
        #endregion
        #region MensajeError: Mensaje error
        /// <summary>
        /// <para>Mensaje error cuando ocurren</para>
        /// </summary>
        public String MensajeError;
        #endregion
        // Datos  adicionales Dian
        #region Fcm_secraz_fcem: Razon social Empresa
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public String Fcm_secraz_fcem
        {
            get { return _fcm_secraz_fcem; }
            set
            {
                if (_fcm_secraz_fcem == value) return;
                _fcm_secraz_fcem = value;
                OnPropertyChanged("Fcm_secraz_fcem");
            }
        }
        #endregion
        #region NuevoNumeroFactura: Nuevo secuencial Generado
        /// <summary>
        /// <para>DESCRIPCION: Nuevo numero factura generado incluye prefijos y rellenos</para>
        /// </summary>
        public String NuevoNumeroFactura;
        #endregion
        #endregion

        #region FobGenerarNumeroFacturaIdResolucion: Generar numero de factura segun codigo unico Resolución
        /// <summary>
        /// Generar numero de factura segun Id Resolucion dada en parametro
        /// </summary>
        /// <param name="tcrIdResolucion">Id unico de la resolucion dentro de la base de datos</param>
        /// <returns></returns>
        public static SysModeloFacturaDian FobGenerarNumeroFacturaIdResolucion(String tcrIdResolucion)
        {
            return FobNumeroFacturaDian(null, tcrIdResolucion);
        }
        #endregion
        #region fobGenerarNumeroFactura: Generar numero de factura Parametro Tipo Texto
        /// <summary>
        /// Generar numero de factura segun resolucion Dian activa, fecha dada en formato texto
        /// </summary>
        /// <param name="tcrTipoId">Tipo factura a generar 1=Numero Factura Dian autorizado 2=Secuencial del Sistema</param>
        /// <param name="tcrFecha">Fecha dada (en formato texto DMY) para filtrar la resolucion activa</param>
        /// <returns></returns>
        public static SysModeloFacturaDian FobGenerarNumeroFactura(String tcrTipoId, String tcrFecha)
        {
            DateTime tdaFecha = Funciones.fdaConvertFecha("DMY", "/", tcrFecha);
            return fobGenerarNumeroFactura(tcrTipoId, tdaFecha);
        }
        #endregion
        #region fobGenerarNumeroFactura: Generar numero de factura Parametro Tipo DateTime
        /// <summary>
        /// Generar numero de factura segun resolucion Dian activa, fecha dada en formato texto
        /// </summary>
        /// <param name="tcrTipoId">Tipo factura a generar 1=Numero Factura Dian autorizado 2=Secuencial del Sistema</param>
        /// <param name="tdaFecha">Fecha dada (en formato DateTime) para filtrar la resolucion activa</param>
        /// <returns></returns>
        public static SysModeloFacturaDian fobGenerarNumeroFactura(String tcrTipoId, DateTime tdaFecha)
        {
            var lobRegRegistro = new SysModeloFacturaDian();
            lobRegRegistro.TipoRespuesta = "2";
            lobRegRegistro.NuevoNumeroFactura = String.Empty;

            if (tcrTipoId == "2")
            {
                lobRegRegistro.NuevoNumeroFactura = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                lobRegRegistro.Fcm_secres_srfa = "NA";
                lobRegRegistro.Fcm_numres_srfa = "NA";

                if (String.IsNullOrWhiteSpace(lobRegRegistro.NuevoNumeroFactura))
                {
                    lobRegRegistro.TipoRespuesta = "2";
                    lobRegRegistro.MensajeError = "Error al generar Secuencial del sistema para factura";
                }
            }
            else
            {
                // secuencial segun resolucion Dian
                lobRegRegistro = FobNumeroFacturaDian(tdaFecha);
            }
            return lobRegRegistro;
        }
        #endregion
        #region fobNumeroFacturaDian: Generar numero de factura Dian Parametro Tipo Texto
        /// <summary>
        /// Generar numero de factura segun resolucion Dian activa, fecha dada en formato texto
        /// </summary>
        /// <param name="tdaFecha">Fecha dada (en formato texto DMY) para filtrar la resolucion activa</param>
        /// <returns></returns>
        public static SysModeloFacturaDian fobNumeroFacturaDian(String tcrFecha)
        {
            DateTime tdaFecha = Funciones.fdaConvertFecha("DMY", "/", tcrFecha);
            return FobNumeroFacturaDian(tdaFecha);
        }
        #endregion
        #region fobNumeroFacturaDian: Generar numero de factura Dian Principal
        /// <summary>
        /// Generar numero de factura segun resolucion Dian activa
        /// </summary>
        /// <param name="tdaFecha">Fecha dada (en formato DateTime) para filtrar la resolucion activa</param>
        /// <param name="tcrIdResolucion">Resolucion de autorizacion para secuenciales de facturacion</param>
        /// <returns></returns>
        public static SysModeloFacturaDian FobNumeroFacturaDian(DateTime? tdaFecha = null, string? tcrIdResolucion = null)
        {
            var lobjRegistro = new SysModeloFacturaDian();
            lobjRegistro.TipoRespuesta      = "1";
            lobjRegistro.NuevoNumeroFactura = String.Empty;
            lobjRegistro.MensajeError       = String.Empty;

            using (_context = new DbAplicacion())
            {
                EFfcmsecrfacturas lobjReg = null;

                if (tdaFecha != null)
                {
                    lobjReg = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_fecini_srfa <= tdaFecha &&
                                                                           p.fcm_fecfin_srfa >= tdaFecha &&
                                                                           p.fcm_secres_srfa != "NA" &&
                                                                           p.fcm_estreg_srfa == "1");
                }
                else
                {
                    lobjReg = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrIdResolucion);
                }

                // si todo salio bien 
                if (lobjReg != null)
                {
                    if (lobjReg.fcm_ultgen_srfa < lobjReg.fcm_facfin_srfa)
                    {
                        lobjReg.fcm_ultgen_srfa = lobjReg.fcm_ultgen_srfa + 1;
                        _context.SaveChanges();
                        #region cargar Registro
                        lobjRegistro.Fcm_secres_srfa = lobjReg.fcm_secres_srfa;
                        lobjRegistro.Fcm_numres_srfa = lobjReg.fcm_numres_srfa;
                        lobjRegistro.Fcm_desres_srfa = lobjReg.fcm_desres_srfa;
                        lobjRegistro.Fcm_notenc_srfa = lobjReg.fcm_notenc_srfa;
                        lobjRegistro.Fcm_noppag_srfa = lobjReg.fcm_noppag_srfa;
                        lobjRegistro.Fcm_fecini_srfa = (DateTime)lobjReg.fcm_fecini_srfa;
                        lobjRegistro.Fcm_facini_srfa = (int)lobjReg.fcm_facini_srfa;
                        lobjRegistro.Fcm_facfin_srfa = (int)lobjReg.fcm_facfin_srfa;
                        lobjRegistro.Fcm_ultgen_srfa = (int)lobjReg.fcm_ultgen_srfa;
                        lobjRegistro.Fcm_prefij_srfa = lobjReg.fcm_prefij_srfa;
                        lobjRegistro.Fcm_maxsec_srfa = (int)lobjReg.fcm_maxsec_srfa;
                        lobjRegistro.Fcm_alrsec_srfa = (int)lobjReg.fcm_alrsec_srfa;
                        lobjRegistro.Fcm_relcer_srfa = lobjReg.fcm_relcer_srfa;
                        lobjRegistro.Fcm_estreg_srfa = lobjReg.fcm_estreg_srfa;
                        #endregion
                        lobjRegistro.NuevoNumeroFactura = FcrGenFormatoSecuencial(lobjRegistro);
                    }
                    else
                    {
                        lobjRegistro.TipoRespuesta = "2";
                        lobjRegistro.MensajeError = "Resolución Dian: " + lobjReg.fcm_secres_srfa + "  para facturación," +
                                                    " secuencial esta agotado, ultimo numero generado es " + lobjReg.fcm_ultgen_srfa.ToString().Trim() + ".";
                    }
                }
                else
                {
                    lobjRegistro.TipoRespuesta = "2";
                    lobjRegistro.MensajeError = "ERROR 20 - No Hay Resolución dian activa";
                }
            }
            return lobjRegistro;
        }
        #endregion
        #region FobGenerarNumeroNotasCredDeb: Generar numero para notas creditos notas debito y documentos Attached
        /// <summary>
        /// Generar numero para notas creditos, notas debito y documentos Attached
        /// </summary>
        /// <param name="tcrTipoIdDoc">Tipo documento "91"=Nota Credito "92"=Nota Debito "AT"=Documento Attached</param>
        /// <param name="tcrIdResolucion">Resolucion de autorizacion para secuenciales de facturacion</param>
        /// <param name="tcrIdRazonSocial">Id unico de la Razon social para la cual se genera el Id</param>
        /// <returns>Devuelve un numero string que repesenta el nuevo codigo generado</returns>
        public static SysModeloFacturaDian FobGenerarNumeroDocumento(string tcrTipoIdDoc, 
                                                                        string tcrIdResolucion,
                                                                        string tcrIdRazonSocial)
        {
            //var lcrLlave = tcrTipoIdDoc == "91" ? "FCM-NOTACREDITO-ID" : "FCM-NOTADEBITO-ID";
            var lcrLlave = tcrTipoIdDoc switch
            {
                "91" => "FCM-NOTACREDITO-ID",
                "92" => "FCM-NOTADEBITO-ID",
                "AT" => "FCM-ATTACHEDDOC-ID",
                 _   => "FCM-ATTACHEDDOC-ID",
            };
            lcrLlave = lcrLlave + "-" + tcrIdRazonSocial;

            //var lcrDescrp = tcrTipoIdDoc == "91" ? "Secuenciales para Notas Credito" : "Secuenciales para Notas Debito";
            var lcrDescrp = tcrTipoIdDoc switch
            {
                "91" => "Secuenciales para Notas Credito",
                "92" => "Secuenciales para Notas Debito",
                "AT" => "Secuenciales para Documento Attached",
                _    => "Secuenciales para Documento Attached",
            };

            var lobjRegistro = new SysModeloFacturaDian();
            lobjRegistro.TipoRespuesta = "2";
            lobjRegistro.NuevoNumeroFactura = string.Empty;
            EFfcmsecrfacturas lobjReg = null;

            using (_context = new DbAplicacion())
            {
                // Traer los datos de la resolucion
                lobjReg = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrIdResolucion);
                // si todo salio bien 
                if (lobjReg != null)
                {
                    #region cargar Registro
                    lobjRegistro.Fcm_secres_srfa = lobjReg.fcm_secres_srfa;
                    lobjRegistro.Fcm_numres_srfa = lobjReg.fcm_numres_srfa;
                    lobjRegistro.Fcm_desres_srfa = lobjReg.fcm_desres_srfa;
                    lobjRegistro.Fcm_notenc_srfa = lobjReg.fcm_notenc_srfa;
                    lobjRegistro.Fcm_noppag_srfa = lobjReg.fcm_noppag_srfa;
                    lobjRegistro.Fcm_fecini_srfa = (DateTime)lobjReg.fcm_fecini_srfa;
                    lobjRegistro.Fcm_facini_srfa = (int)lobjReg.fcm_facini_srfa;
                    lobjRegistro.Fcm_facfin_srfa = (int)lobjReg.fcm_facfin_srfa;
                    lobjRegistro.Fcm_ultgen_srfa = (int)lobjReg.fcm_ultgen_srfa;
                    lobjRegistro.Fcm_prefij_srfa = lobjReg.fcm_prefij_srfa;
                    lobjRegistro.Fcm_maxsec_srfa = (int)lobjReg.fcm_maxsec_srfa;
                    lobjRegistro.Fcm_alrsec_srfa = (int)lobjReg.fcm_alrsec_srfa;
                    lobjRegistro.Fcm_relcer_srfa = lobjReg.fcm_relcer_srfa;
                    lobjRegistro.Fcm_estreg_srfa = lobjReg.fcm_estreg_srfa;
                    #endregion
                    lobjRegistro.NuevoNumeroFactura = SysModelo.fcrGenerarNuevoCodigo(lcrLlave, "FCM", lcrDescrp);
                }

                if (String.IsNullOrWhiteSpace(lobjRegistro.NuevoNumeroFactura))
                {
                    lobjRegistro.TipoRespuesta = "2";
                    lobjRegistro.MensajeError = "Error al generar Secuencial del sistema para factura";
                }
            }

            return lobjRegistro;
        }
        #endregion
        #region Complementa el formato del nuevo secuencial
        /// <summary>
        /// Complementar el formato del nuevo secuencial generado
        /// </summary>
        /// <returns>Devuelve el nuevo secuencial completo aplicando relleno y prefigo si lo requiere</returns>
        private static string FcrGenFormatoSecuencial(SysModeloFacturaDian tobRegistro)
        {
            string lcrReturn = string.Empty;
            int lnuCharExiste = 0;
            int lnuMaxRelleno = 0;
            try
            {
                lnuCharExiste = tobRegistro.Fcm_prefij_srfa.Trim().Length + tobRegistro.Fcm_ultgen_srfa.ToString().Trim().Length;
                lnuMaxRelleno = (tobRegistro.Fcm_maxsec_srfa - lnuCharExiste);
                if (tobRegistro.Fcm_relcer_srfa == "1" && lnuMaxRelleno > 0) // Rellenar con ceros
                {
                    string lcrRelleno = "0";
                    lcrReturn = tobRegistro.Fcm_prefij_srfa.Trim() + lcrRelleno.PadLeft(lnuMaxRelleno, '0').Trim() + tobRegistro.Fcm_ultgen_srfa.ToString().Trim();
                }
                else
                {
                    lcrReturn = tobRegistro.Fcm_prefij_srfa.Trim().ToUpper() + tobRegistro.Fcm_ultgen_srfa.ToString().Trim();
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al generar Nuevo secuencial factura Dian : fcrGenFormatoSecuencial");
            }
            return lcrReturn;
        }
        #endregion
        #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
    }
}

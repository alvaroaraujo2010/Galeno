using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SYSValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // SYS - CONFIGURACION ENTORNO GENERAL DEL SISTEMA
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // SYSUSUARIOS: Maestro de Usuarios del Sistema
        //-------------------------------------------------------
        #region Buscar SYSUSUARIOS: Logica
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TITULO: Maestro de Usuarios del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Usuarios del Sistema a quienes se les asignan perfiles
        /// para  realizar acciones o  ejecutan modulos
        /// </para>
        /// </summary>
        public static bool flgBuscarSysusuarios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSUSUARIOS: String
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TITULO: Maestro de Usuarios del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_nomusu_usux
        /// (campo 'DE' de la tabla sysusuarios) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Usuarios del Sistema a quienes se les asignan perfiles
        /// para  realizar acciones o  ejecutan modulos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysusuarios(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_nomusu_usux;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSUSUARIOS: Registro
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TITULO: Maestro de Usuarios del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysusuarios desde la tabla sysusuarios
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Usuarios del Sistema a quienes se les asignan perfiles
        /// para  realizar acciones o  ejecutan modulos
        /// </para>
        /// </summary>
        public static EFsysusuarios fobRegBuscarSysusuarios(string tcrCodigo)
        {
            EFsysusuarios lobReturn = new EFsysusuarios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SYSUSUARIOS: ID Unico del Usuario
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TITULO: Maestro de Usuarios del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysusuarios desde la tabla sysusuarios
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Usuarios del Sistema a quienes se les asignan perfiles
        /// para  realizar acciones o  ejecutan modulos
        /// </para>
        /// </summary>
        public static EFsysusuarios fobRegBuscarSysusuariosCx(string tcrCodigo)
        {
            EFsysusuarios lobReturn = new EFsysusuarios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_ideusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSGENERADORCOD: Tabla Generador de  secuenciales
        //-------------------------------------------------------
        #region Buscar SYSGENERADORCOD: Logica
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TITULO: Tabla Generador de  secuenciales</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del sistema donde se almacenan los secuenciales generados,
        /// se agrupan según el módulo al cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarSysgeneradorcod(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSGENERADORCOD: String
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TITULO: Tabla Generador de  secuenciales</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_dessec_gcod
        /// (campo 'DE' de la tabla sysgeneradorcod) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del sistema donde se almacenan los secuenciales generados,
        /// se agrupan según el módulo al cual pertenecen
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysgeneradorcod(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_dessec_gcod;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSGENERADORCOD: Registro
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TITULO: Tabla Generador de  secuenciales</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysgeneradorcod desde la tabla
        /// sysgeneradorcod cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del sistema donde se almacenan los secuenciales generados,
        /// se agrupan según el módulo al cual pertenecen
        /// </para>
        /// </summary>
        public static EFsysgeneradorcod fobRegBuscarSysgeneradorcod(string tcrCodigo)
        {
            EFsysgeneradorcod lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSMODULOSISTEM: Módulos del Sistema
        //-------------------------------------------------------
        #region Buscar SYSMODULOSISTEM: Logica
        /// <summary>
        /// <para>TABLA: sysmodulosistem</para>
        /// <para>TITULO: Módulos del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene los códigos identificadores de Módulos que conforman
        /// el sistema integrado Ejm: NOM=NOMINA, CON=CONTABILIDAD, PRE=PRESUPUESTO,
        /// FCM=FACTURACION SERV MEDICOS, ETC..
        /// </para>
        /// </summary>
        public static bool flgBuscarSysmodulosistem(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysmodulosistem.FirstOrDefault(p => p.sys_codmod_modu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSMODULOSISTEM: String
        /// <summary>
        /// <para>TABLA: sysmodulosistem</para>
        /// <para>TITULO: Módulos del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_nommod_modu
        /// (campo 'DE' de la tabla sysmodulosistem) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene los códigos identificadores de Módulos que conforman
        /// el sistema integrado Ejm: NOM=NOMINA, CON=CONTABILIDAD, PRE=PRESUPUESTO,
        /// FCM=FACTURACION SERV MEDICOS, ETC..
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysmodulosistem(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysmodulosistem.FirstOrDefault(p => p.sys_codmod_modu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_nommod_modu;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSMODULOSISTEM: Registro
        /// <summary>
        /// <para>TABLA: sysmodulosistem</para>
        /// <para>TITULO: Módulos del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysmodulosistem desde la tabla
        /// sysmodulosistem cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene los códigos identificadores de Módulos que conforman
        /// el sistema integrado Ejm: NOM=NOMINA, CON=CONTABILIDAD, PRE=PRESUPUESTO,
        /// FCM=FACTURACION SERV MEDICOS, ETC..
        /// </para>
        /// </summary>
        public static EFsysmodulosistem fobRegBuscarSysmodulosistem(string tcrCodigo)
        {
            EFsysmodulosistem lobReturn = new EFsysmodulosistem();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysmodulosistem.FirstOrDefault(p => p.sys_codmod_modu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSPERFIUSUARIO: Maestro perfiles de usuarios
        //-------------------------------------------------------
        #region Buscar SYSPERFIUSUARIO: Logica
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TITULO: Maestro perfiles de usuarios</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestra para registrar perfiles de usuarios que creados
        /// para gestión de datos en el sistema ejm: P01 =Súper Usuario
        /// P02=Administrador  P03=Facturadores P04=Regente de farmacia
        /// </para>
        /// </summary>
        public static bool flgBuscarSysperfiusuario(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSPERFIUSUARIO: String
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TITULO: Maestro perfiles de usuarios</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_desper_perf
        /// (campo 'DE' de la tabla sysperfiusuario) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestra para registrar perfiles de usuarios que creados
        /// para gestión de datos en el sistema ejm: P01 =Súper Usuario
        /// P02=Administrador  P03=Facturadores P04=Regente de farmacia
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysperfiusuario(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_desper_perf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSPERFIUSUARIO: Registro
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TITULO: Maestro perfiles de usuarios</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysperfiusuario desde la tabla
        /// sysperfiusuario cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestra para registrar perfiles de usuarios que creados
        /// para gestión de datos en el sistema ejm: P01 =Súper Usuario
        /// P02=Administrador  P03=Facturadores P04=Regente de farmacia
        /// </para>
        /// </summary>
        public static EFsysperfiusuario fobRegBuscarSysperfiusuario(string tcrCodigo)
        {
            EFsysperfiusuario lobReturn = new EFsysperfiusuario();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // SYSCOMPONPERFIL: Componentes asignados a un perfil
        //-------------------------------------------------------
        #region Buscar SYSCOMPONPERFIL: Logica
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TITULO: Componentes asignados a un perfil</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes asignados a un perfil (por defecto al P01 ADMIN
        /// se le asignan todos los permisos), registra todos los componentes
        /// a los cuales un perfil pude accesar y que se muestran en el
        /// menú del sistema, cuando un usuario con perfil tal inicia sesió
        /// </para>
        /// </summary>
        public static bool flgBuscarSyscomponperfil(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSCOMPONPERFIL: String
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TITULO: Componentes asignados a un perfil</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla syscomponperfil) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes asignados a un perfil (por defecto al P01 ADMIN
        /// se le asignan todos los permisos), registra todos los componentes
        /// a los cuales un perfil pude accesar y que se muestran en el
        /// menú del sistema, cuando un usuario con perfil tal inicia sesió
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSyscomponperfil(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.sys_codreg_cper;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSCOMPONPERFIL: Registro
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TITULO: Componentes asignados a un perfil</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsyscomponperfil desde la tabla
        /// syscomponperfil cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes asignados a un perfil (por defecto al P01 ADMIN
        /// se le asignan todos los permisos), registra todos los componentes
        /// a los cuales un perfil pude accesar y que se muestran en el
        /// menú del sistema, cuando un usuario con perfil tal inicia sesió
        /// </para>
        /// </summary>
        public static EFsyscomponperfil fobRegBuscarSyscomponperfil(string tcrCodigo)
        {
            EFsyscomponperfil lobReturn = new EFsyscomponperfil();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

        //-------------------------------------------------------
        // SYSCOMPMODULOS: Componentes tipo formulario u opción en Módulo
        //-------------------------------------------------------
        #region Buscar SYSCOMPMODULOS: Logica
        /// <summary>
        /// <para>TABLA: syscompmodulos</para>
        /// <para>TITULO: Componentes tipo formulario u opción en Módulo</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Listado general de componentes de tipo formulario u opción,
        /// que se asignan a un Módulo
        /// </para>
        /// </summary>
        public static bool flgBuscarSyscompmodulos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscompmodulos.FirstOrDefault(p => p.sys_codcom_comd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSCOMPMODULOS: String
        /// <summary>
        /// <para>TABLA: syscompmodulos</para>
        /// <para>TITULO: Componentes tipo formulario u opción en Módulo</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla syscompmodulos) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Listado general de componentes de tipo formulario u opción,
        /// que se asignan a un Módulo
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSyscompmodulos(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscompmodulos.FirstOrDefault(p => p.sys_codcom_comd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_codcom_comd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSCOMPMODULOS: Registro
        /// <summary>
        /// <para>TABLA: syscompmodulos</para>
        /// <para>TITULO: Componentes tipo formulario u opción en Módulo</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsyscompmodulos desde la tabla
        /// syscompmodulos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Listado general de componentes de tipo formulario u opción,
        /// que se asignan a un Módulo
        /// </para>
        /// </summary>
        public static EFsyscompmodulos fobRegBuscarSyscompmodulos(string tcrCodigo)
        {
            EFsyscompmodulos lobReturn = new EFsyscompmodulos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscompmodulos.FirstOrDefault(p => p.sys_codcom_comd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSCOMPONENTES: Componentes tipo formulario u opción de Módulos
        //-------------------------------------------------------
        #region Buscar SYSCOMPONENTES: Logica
        /// <summary>
        /// <para>TABLA: syscomponentes</para>
        /// <para>TITULO: Componentes tipo formulario u opción de Módulos</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes de tipo formulario u opción, son mostrados en
        /// el sistema como opciones dentro de un Módulo, un registro en
        /// esta tabla representa un formulario funcional, una opción de
        /// reporte, llamada a una función, etc.
        /// </para>
        /// </summary>
        public static bool flgBuscarSyscomponentes(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponentes.FirstOrDefault(p => p.sys_codcom_comp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSCOMPONENTES: String
        /// <summary>
        /// <para>TABLA: syscomponentes</para>
        /// <para>TITULO: Componentes tipo formulario u opción de Módulos</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_titcom_comp
        /// (campo 'DE' de la tabla syscomponentes) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes de tipo formulario u opción, son mostrados en
        /// el sistema como opciones dentro de un Módulo, un registro en
        /// esta tabla representa un formulario funcional, una opción de
        /// reporte, llamada a una función, etc.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSyscomponentes(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponentes.FirstOrDefault(p => p.sys_codcom_comp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_titcom_comp;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSCOMPONENTES: Registro
        /// <summary>
        /// <para>TABLA: syscomponentes</para>
        /// <para>TITULO: Componentes tipo formulario u opción de Módulos</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsyscomponentes desde la tabla
        /// syscomponentes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes de tipo formulario u opción, son mostrados en
        /// el sistema como opciones dentro de un Módulo, un registro en
        /// esta tabla representa un formulario funcional, una opción de
        /// reporte, llamada a una función, etc.
        /// </para>
        /// </summary>
        public static EFsyscomponentes fobRegBuscarSyscomponentes(string tcrCodigo)
        {
            EFsyscomponentes lobReturn = new EFsyscomponentes();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponentes.FirstOrDefault(p => p.sys_codcom_comp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSADMSMENSAJES: Administrador para notificación servicio de mensajes
        //-------------------------------------------------------
        #region Buscar SYSADMSMENSAJES: Logica
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TITULO: Administrador para notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Administrador para notificación del  servicio de mensajes que
        /// son generados en los distintos procesos en módulos del sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarSysadmsmensajes(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSADMSMENSAJES: String
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TITULO: Administrador para notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_desmsj_syam
        /// (campo 'DE' de la tabla sysadmsmensajes) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Administrador para notificación del  servicio de mensajes que
        /// son generados en los distintos procesos en módulos del sistema
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysadmsmensajes(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_desmsj_syam;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSADMSMENSAJES: Registro
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TITULO: Administrador para notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysadmsmensajes desde la tabla
        /// sysadmsmensajes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Administrador para notificación del  servicio de mensajes que
        /// son generados en los distintos procesos en módulos del sistema
        /// </para>
        /// </summary>
        public static EFsysadmsmensajes fobRegBuscarSysadmsmensajes(string tcrCodigo)
        {
            EFsysadmsmensajes lobReturn = new EFsysadmsmensajes();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSADMSTIPOMENS: Tipo notificación servicio de mensajes
        //-------------------------------------------------------
        #region Buscar SYSADMSTIPOMENS: Logica
        /// <summary>
        /// <para>TABLA: sysadmstipomens</para>
        /// <para>TITULO: Tipo notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de mensaje según módulos del sistema para notificación
        /// ejemplo: ADM001 = Registro de admisión generado para un paciente
        /// (viene del modulo admisión) ADM002 = Solicitud para autorizar
        /// salida paciente (dar de alta)
        /// </para>
        /// </summary>
        public static bool flgBuscarSysadmstipomens(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmstipomens.FirstOrDefault(p => p.sys_codtip_sytm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSADMSTIPOMENS: String
        /// <summary>
        /// <para>TABLA: sysadmstipomens</para>
        /// <para>TITULO: Tipo notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_desmsj_sytm
        /// (campo 'DE' de la tabla sysadmstipomens) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de mensaje según módulos del sistema para notificación
        /// ejemplo: ADM001 = Registro de admisión generado para un paciente
        /// (viene del modulo admisión) ADM002 = Solicitud para autorizar
        /// salida paciente (dar de alta)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysadmstipomens(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmstipomens.FirstOrDefault(p => p.sys_codtip_sytm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_desmsj_sytm;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSADMSTIPOMENS: Registro
        /// <summary>
        /// <para>TABLA: sysadmstipomens</para>
        /// <para>TITULO: Tipo notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysadmstipomens desde la tabla
        /// sysadmstipomens cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de mensaje según módulos del sistema para notificación
        /// ejemplo: ADM001 = Registro de admisión generado para un paciente
        /// (viene del modulo admisión) ADM002 = Solicitud para autorizar
        /// salida paciente (dar de alta)
        /// </para>
        /// </summary>
        public static EFsysadmstipomens fobRegBuscarSysadmstipomens(string tcrCodigo)
        {
            EFsysadmstipomens lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmstipomens.FirstOrDefault(p => p.sys_codtip_sytm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSADMGRUPOMENS: Grupos de mensajes
        //-------------------------------------------------------
        #region Buscar SYSADMGRUPOMENS: Logica
        /// <summary>
        /// <para>TABLA: sysadmgrupomens</para>
        /// <para>TITULO: Grupos de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de  mensajes para priorizar filtros en cada modulo ejemplo
        /// MSG = Mensajes general SYS: = Grupos mensajes de sistema ADM:=
        /// Mensajes modulo admisión FCM=Mensajes para modulo facturación.
        /// </para>
        /// </summary>
        public static bool flgBuscarSysadmgrupomens(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmgrupomens.FirstOrDefault(p => p.sys_codmsg_symg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSADMGRUPOMENS: String
        /// <summary>
        /// <para>TABLA: sysadmgrupomens</para>
        /// <para>TITULO: Grupos de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sys_desmsg_symg
        /// (campo 'DE' de la tabla sysadmgrupomens) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de  mensajes para priorizar filtros en cada modulo ejemplo
        /// MSG = Mensajes general SYS: = Grupos mensajes de sistema ADM:=
        /// Mensajes modulo admisión FCM=Mensajes para modulo facturación.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSysadmgrupomens(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmgrupomens.FirstOrDefault(p => p.sys_codmsg_symg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_desmsg_symg;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSADMGRUPOMENS: Registro
        /// <summary>
        /// <para>TABLA: sysadmgrupomens</para>
        /// <para>TITULO: Grupos de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysadmgrupomens desde la tabla
        /// sysadmgrupomens cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos de  mensajes para priorizar filtros en cada modulo ejemplo
        /// MSG = Mensajes general SYS: = Grupos mensajes de sistema ADM:=
        /// Mensajes modulo admisión FCM=Mensajes para modulo facturación.
        /// </para>
        /// </summary>
        public static EFsysadmgrupomens fobRegBuscarSysadmgrupomens(string tcrCodigo)
        {
            EFsysadmgrupomens lobReturn = new EFsysadmgrupomens();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmgrupomens.FirstOrDefault(p => p.sys_codmsg_symg == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SYSVARCONFIGMD: Lista variables configuracion general sistema
        //-------------------------------------------------------
        #region Buscar SYSVARCONFIGMD: Logica
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Gran lista  variables por cada grupo de configuracion del sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarSysvarconfigmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.FirstOrDefault(p => p.sys_secvar_sycv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SYSVARCONFIGMD: String
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sys_varnom_sycv
        /// (campo 'DE' de la tabla sysvarconfigmd) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Gran lista  variables por cada grupo de configuracion del sistema
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSysvarconfigmd(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.FirstOrDefault(p => p.sys_secvar_sycv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sys_varnom_sycv;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SYSVARCONFIGMD: Registro
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysvarconfigmd desde la tabla
        /// sysvarconfigmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Gran lista  variables por cada grupo de configuracion del sistema
        /// </para>
        /// </summary>
        public static EFsysvarconfigmd fobRegBuscarSysvarconfigmd(String tcrCodigo)
        {
            EFsysvarconfigmd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.FirstOrDefault(p => p.sys_secvar_sycv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SYSVARCONFIGMD: llave de Variable
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsysvarconfigmd dada la llave de variable, desde la tabla
        /// sysvarconfigmd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Gran lista  variables por cada grupo de configuracion del sistema </para>
        /// </summary>
        public static EFsysvarconfigmd fobRegBuscarSysvarconfigmdKey(String tcrKeyVariable)
        {
            EFsysvarconfigmd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.FirstOrDefault(p => p.sys_varkey_sycv == tcrKeyVariable);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SYSVARCONFIGMD: llave de Variable grupo
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un temporal con todos los registros que pertenecen a un grupo de variables.
        /// Cuando no exiten datos retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Lista  variables por cada grupo de configuracion del sistema</para>
        /// </summary>
        public static List<EFsysvarconfigmd> FlsSelectGrupoSysvarconfigmd(String tcrCodigoGrupo)
        {
            List<EFsysvarconfigmd> ltmpReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.Where(p => p.sys_seggru_sycg == tcrCodigoGrupo);
                if (lobjRegistro != null)
                {
                    ltmpReturn = (List<EFsysvarconfigmd>)lobjRegistro;
                };
            }
            return ltmpReturn;
        }
        #endregion
        #region Buscar SYSVARCONFIGMD: Variables Facturación Electronica
        /// <summary>
        /// <para>TABLA: sysvarconfigmd</para>
        /// <para>TITULO: Lista variables configuracion general sistema para facturación electronica</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un temporal con todos los registros que pertenecen a los grupos de  variables.
        /// facturacion Electronica, Cuando no exiten datos retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA: Lista  variables por cada grupo de configuracion del sistema</para>
        /// </summary>
        public static List<EFsysvarconfigmd> FlsSelectGrupoSysvarconfigmdEx()
        {
            List<EFsysvarconfigmd> ltmpReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysvarconfigmd.Where(p => p.sys_seggru_sycg == "GS003" ||
                                                                      p.sys_seggru_sycg == "GS004" ||
                                                                      p.sys_seggru_sycg == "GS005").ToList();
                if (lobjRegistro != null)
                {
                    //ltmpReturn = (List<EFsysvarconfigmd>)lobjRegistro;
                    ltmpReturn = lobjRegistro;
                };
            }
            return ltmpReturn;
        }
        #endregion
    }
}

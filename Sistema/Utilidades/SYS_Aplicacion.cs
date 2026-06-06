using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class Aplicacion
    {
        private static Aplicacion oApp;

        private Aplicacion()
        {
        }

        public static Aplicacion Instancia()
        {
            if (oApp == null)
            {
                oApp = new Aplicacion();
            }

            return oApp;
        }
        //---------------------------------------------------------------------
        //- Configuracion datos de usuarios del sistema
        //---------------------------------------------------------------------
        #region Variables configuracion general del sitema
        /// <summary>
        /// Codigo Unico de Usuario en sistema (codigo de gestion)
        /// </summary>
        public String gcrUsuIdUsuario { get; set; }
        /// <summary>
        /// Nick unico de Usuario en sistema (nombre corto)
        /// </summary>
        public String gcrUsuNickUsuario { get; set; }
        /// <summary>
        /// Codigo Perfil de Usuario activo en el sistema (para roles)
        /// </summary>
        public String gcrUsuCodigoPerfil { get; set; }
        /// <summary>
        /// Nombre completo de usuario (Apellidos y Nombres)
        /// </summary>
        public String gcrUsuNombreUsuario { get; set; }
        #endregion
        //---------------------------------------------------------------------
        //- Configuracion Conexion base de datos, historicos y ruta recursos
        //---------------------------------------------------------------------
        #region Configuracion Conexion base de datos, historicos y ruta recursos
        /// <summary>
        /// <para>Tipo guardado de datos Historias clinicas en grupos de archivos o XML</para>
        /// <para>"XM" = Los datos se guardan en Formato XML // "01","02"..."10" = Se guardan en grupos de tablas</para>
        /// </summary>
        public String gcrAppBdatosArchvioGuardarDatos = "01";
        /// <summary>
        /// Nombre de la conexion por defecto a base de datos (ejemplo: DbAplicacion)
        /// </summary>
        public String gcrAppBdatosConexionDefault = "DbAplicacion";
        /// <summary>
        /// Descripcion de la conexion por defecto a base de datos (ejemplo: Conexion local desde MySql)
        /// </summary>
        public String gcrAppBdatosConexionDefaultDesc = "Conexion local desde MySql";
        /// <summary>
        /// Motor de base de datos para realizar la conexion (Valores: MYSQL/SQL/FIREBIR/ORACLE)
        /// </summary>
        public String gcrAppBdatosMotorBaseDeDatos = "MYSQL";
        /// <summary>
        /// Tipo conexion para acceso a datos (valor: /RED/WEB/NORED/)
        /// </summary>
        public String gcrAppBdatoTipoIpServidor = "RED";
        /// <summary>
        /// Unidad de red o direccion IP del servidor de datos (localhost//192.168.1.1//wwww.conexion....//c://d://...)
        /// </summary>
        public String gcrAppBdatosIpServidor = "localhost";  //192.168.10.1 / 192.168.26.21 / 192.168.1.40 / c: -> para NORED
        /// <summary>
        /// ruta donde se encuentra instalado el sistema 
        /// </summary>
        public String gcrAppInicioPath = @"Proyectos\Galeno40";        // Ruta base del software NORMAL ES "Galeno40"/ RUTA EQUIPO DESARROLLO "Proyectos\Galeno40"
        /// <summary>
        /// ruta donde se encuentra instalado el sistema concatenada con la ruta base de la aplicacion
        /// </summary>
        public String gcrAppInicioPathCompleta = @"Proyectos\Galeno40";        // Ruta base del software NORMAL ES "Galeno40"/ RUTA EQUIPO DESARROLLO "Proyectos\Galeno40"
        /// <summary>
        /// Linea de conexion segun el motor en modo enttityframework
        /// </summary>
        public String gcrAppBdatosSqlLineaConexion = String.Empty;
        /// <summary>
        /// Linea conexion nativa sin enttityframework, SQL/MySQL/ORACLE... ejemplo: "server=localhost;uid=root;pwd=root;database=dbprueba;"
        /// </summary>
        public String gcrAppBdatosSqlLineaConnNativa = String.Empty;
        /// <summary>
        /// Nombre del archivo almacen de conexion dentro de la ruta Windows/System "TiggerPackConfig.dll"
        /// </summary>
        public String gcrAppBdatosArchivoLineaConn = "GalenoConfig.dll";
        //----------------------------------------------------------------------
        /// <summary>
        /// Tipo conexion para acceso a recursos /RED/WEB/NORED/
        /// </summary>
        public String gcrAppRecursoTipoIpServidor = "RED";
        /// <summary>
        /// Unidad de red o direccion IP del servidor de recursos (localhost//192.168.1.1//wwww.conexion....//c:,d:,...)
        /// </summary>
        public String gcrAppRecursoIpServidor = "localhost";  //192.168.26.21 / 192.168.1.40 / c: -> para NORED
        /// <summary>
        /// Ruta para localizar los archivos de recurso compartidos, por defecto es la carpeta "GaleriaRecursos"
        /// </summary>
        public String gcrAppRecursoPath = @"GaleriaRecursos";
        /// <summary>
        /// Ruta Completa de archivos de recurso compartidos "GaleriaRecursos" (concatenada con ruta base aplicación)
        /// </summary>
        public String gcrAppRecursoPathCompleta = @"GaleriaRecursos";
        /// <summary>
        /// ruta donde se encuentra instalado el sistema ejemplo : "Proyectos\Galeno40"
        /// </summary>
        public String gcrAppRecursoInicioPath = @"Proyectos\Galeno40";        // Ruta base del software NORMAL ES "Galeno40"/ RUTA EQUIPO DESARROLLO "Proyectos\Galeno40"
        /// <summary>
        /// ruta temporal para envio de reportes desde modulos que asi lo requieran
        /// </summary>
        public String gcrAppPathInicioTempReportes = @"c:\GalenoReportes";     
        #endregion
        //---------------------------------------------------------------------
        //- Configuracion Recolector de mensajes por perfil
        //---------------------------------------------------------------------
        #region Configuracion Recolector de mensajes por perfil
        /// <summary>
        /// Codigo del modulo activo segun acceso desde el menu principal
        /// </summary>
        public String gcrSysActivoIdModulo = String.Empty;
        /// <summary>
        /// Codigo de la Ventana o formulario activo segun acceso desde algun modulo 
        /// </summary>
        public String gcrSysActivoIdVentana = String.Empty;
        /// <summary>
        /// <para>Variable que se activa a true cuando  el sistema esta actualizando el temporal</para> 
        /// <para>gtmpSysListNotifi que es el recolector de notificaciones desde el servidor</para>
        /// </summary>
        public bool glgSysActivoActualizNotifi = false;
        /// <summary>
        /// Variable que se activa a true cuando un modulo esta consultando el tempral de notificaciones (gtmpSysListNotifi)
        /// </summary>
        public bool glgSysActivoConsultaNotifi = false;
        /// <summary>
        /// Lista de notificaciones para el perfil activo
        /// </summary>
        public List<SysAdmGrupoNotifi> gtmpSysListNotifi = null;
        /// <summary>
        /// Lista de notificaciones auxiliar para el perfil activo, se usua para detectar si hay nuevas y activar a Onairis
        /// </summary>
        public List<SysAdmGrupoNotifi> gtmpSysListNotifiAx = null;
        /// <summary>
        /// Lista filtros de busquedas activos en ventana notificaciones para cada modulo
        /// </summary>
        public List<SysAdmGrupoNotifi> gtmpSysListNotifiFx = null;
        /// <summary>
        /// Mensaje tipo texto para que onairis lo trasmita como mensaje de voz
        /// </summary>
        public String OnairisMensajeDeVoz = String.Empty;
        #endregion
        //---------------------------------------------------------------------
        //- Gestion activacion aplicacion
        //---------------------------------------------------------------------
        #region Gestion activacion vistas de la aplicacion
        /// <summary>
        /// <para>Se le asigna el valor "true" y desencadena el evento activar cuando la Aplicacion recibe el enfoque</para> 
        /// </summary>
        public bool glgWiniAplicacionActivar = false;
        /// <summary>
        /// <para>Se le asigna el valor "true" y para desencadenar el evento desactivar</para> 
        /// </summary>
        public bool glgWiniAplicacionDesactivar = false;
        /// <summary>
        /// <para>Variable que se activa a "true" cuando la aplicacion pierde el enfoque o esta minimizada</para> 
        /// </summary>
        public bool glgWiniAplicacionInactiva = false;
        /// <summary>
        /// <para>Variable que se activa a "true" cuando  el sistema esta actualizando estados</para> 
        /// <para>de ventanas a minimizadas/maximizadas o realizando algun proceso critico relacionado con la Aplicación</para>
        /// <para>con esto evita que valores importantes cambien en otros eventos</para>
        /// </summary>
        public bool glgWinGestionProcesos = false;
        /// <summary>
        /// <para>Total de ventanas abiertas en el sistema cuando el valor de esta variable cambia</para> 
        /// <para>se actualiza la lista de refrencia a ventans abiertas</para>
        /// </summary>
        public int gnuWinTotalVentanas = 0;
        /// <summary>
        /// Lista de ventanas activas en la aplicacion
        /// </summary>
        public List<RefVistaWindows> gtmpWinVentanasAct = null;
        #endregion
        //---------------------------------------------------------------------
        //- Gestion Mensajes auxiliares entre capas y/o ventanas
        //---------------------------------------------------------------------
        #region Gestion mensajes auxiliares para ventanas o capas 
        /// <summary>
        /// <para>Codigo mensaje enviando entre capas o ventanas</para> 
        /// </summary>
        public String gcrWinMsCodigoMensaje = String.Empty;
        /// <summary>
        /// <para>Descripcion mensaje enviado entre capas o ventanas</para> 
        /// </summary>
        public String gcrWinMsDescripcionMensaje = String.Empty;
        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Globalization;
using System.Windows.Threading;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Sistema.Servicios
{
    public class AdmServicios
    {
        // Clase para recoletor de mensajes
        #region Mensajes: clase para Recojer los mensajes
        /// <summary>
        /// <para>lista de mensajes de texto para leer Onairis</para>
        /// <para>clase para cargar lista de mensajes desde cualquier parte del sistema</para>
        /// </summary>
        public class Mensajes
        {
            #region Parametros
            /// <summary>Id unico del mensaje</summary>
            public String IdMensaje { get; set; }
            /// <summary>Texto del mensaje</summary>
            public String Mensaje { get; set; }
            /// <summary>Fecha y Hora en que fue recibido en fromato largo del sistema</summary>
            public String FechayHora { get; set; }
            /// <summary>Estado: "1"=Pendiente por leer "2" = Ya Fue leido</summary>
            public String Estado { get; set; }
            #endregion
        }
        #endregion
        // Variables de control 
        #region Variables publicas
        private bool llgPausar               = false;
        private bool llgOnairisAddMens       = false;
        private bool llgOnairisHablando      = false;
        public String lcrMensajeAccion       = "Iniciando...";
        public String lcrMensajeError        = String.Empty;
        public String lcrIdUsuario           = String.Empty;
        public String lcrRutaRecursos        = String.Empty;
        #endregion
        // Temporales de gestion
        #region Temporales de gestion
        private List<Mensajes> tmpOnairisMsj = new List<Mensajes>();
        #endregion
        // Variables publicas de servicios
        #region Variables publicas de Servicios activos
        public String gcrEstadoOnairis      = "1";
        public String gcrEstadoNotificacion = "1";
        public String gcrEstadoAlertas      = "1";
        public String gcrEstadoBuzon        = "1";
        #endregion
        // Servicios activos
        Aplicacion oApp                 = Aplicacion.Instancia();
        Onairis ObOnairis               = Onairis.Instancia();
        Notificaciones ObNotificaciones = Notificaciones.Instancia();
        // Reloj Procesos 
        #region Contadores de Tiempo
        public int lnuTiempoOnairis        = 0;
        public int lnuTiempoNotificaciones = 0;
        public int lnuTiempoAlertas        = 0;
        public int lnuTiempoBuzon          = 0;
        public int lnuContadorAddMensaje   = 0;
        #endregion
        // Clase principal
        #region Clase principal
        private static AdmServicios ObServicios;
        private AdmServicios()
        {
            // clase principal
        }
        #endregion
        #region Instancia
        /// <summary>
        /// Admisistrador de servicios: Iniciar la instancia unica en todo el sistema
        /// </summary>
        public static AdmServicios Instancia()
        {
            if (ObServicios == null)
            {
                ObServicios = new AdmServicios();
            }
            return ObServicios;
        }
        #endregion
        #region Activar
        /// <summary>
        /// Carga los parametros de configuracion de procesos se activa
        /// </summary>
        public void Activar()
        {
            // Estado activo/inactivo de los procesos 
            fcvRutaRecursos();
            fcvCargarParametrosSistema();
            #region Activar Onairis
            if (gcrEstadoOnairis == "1")
            {
                ObOnairis.lcrRutaRecursos = lcrRutaRecursos;
                ObOnairis.Activar();
            }
            #endregion
            #region Activar Notificaciones
            if (gcrEstadoNotificacion == "1")
            {
                ObNotificaciones.Activar();
            }
            #endregion
        }
        #endregion
        //---------------------------------------------------------------
        // Administrador: proceso servicios
        //---------------------------------------------------------------
        #region Lanzador de servicios
        /// <summary>
        /// Lanzador de servicios
        /// </summary>
        public void Administrador()
        {
            //gobTarea = new Thread(new ParameterizedThreadStart(Procesos));
            //gobTarea.Start("OK");
            Procesos();
        }
        #endregion
        #region Procesos
        //private void Procesos(Object tobParametro)
        private void Procesos()
        {
            Proceso_Onairis();
            Proceso_Notificaciones();
        }
        #endregion
        // Procesos de cada servicio
        #region Proceso_Onairis
        /// <summary>
        ///  Mantener activo el servicio de Asistente de voz
        /// </summary>
        private void Proceso_Onairis()
        {
            #region Onairis: Gestion Asistente de Voz
            if (ObOnairis != null)
            {
                if (gcrEstadoOnairis == "1" && llgOnairisAddMens == false)
                {
                    // Ver si esta desocupada para entregarle el mensaje
                    if (ObOnairis.lobVoz.State != SynthesizerState.Speaking && tmpOnairisMsj.Count > 0)
                    {
                        // El mensaje esta en accion
                        llgOnairisHablando = true;
                        var lcrMensaje = fcrOnairisCargarMensaje();
                        ObOnairis.Hablar(lcrMensaje);
                    }
                }
                llgOnairisHablando = ObOnairis.lobVoz.State == SynthesizerState.Speaking ? true : false;
            }
            #endregion
        }
        #endregion
        #region Proceso_Notificaciones
        /// <summary>
        ///  Mantener activo el servicio de notificaciones
        /// </summary>
        private void Proceso_Notificaciones()
        {
            #region Notificaciones: Gestion 
            if (gcrEstadoNotificacion == "1" && lnuTiempoNotificaciones > 10)
            {
                if (oApp.glgSysActivoActualizNotifi == false && oApp.glgSysActivoConsultaNotifi == false)
                {
                    Funciones.flgWinAppAddNuevaVentana();
                }
                // Recolectar notificaciones
                if (ObNotificaciones.RecolectorNotificaciones())
                {
                    lnuTiempoNotificaciones = 0;
                }
            }
            else
            {
                lnuTiempoNotificaciones++;
            }
            // Entregar los mensajes de notificacion al asistente de voz
            if (!String.IsNullOrWhiteSpace(ObNotificaciones.gcrOnairisMensajes) && gcrEstadoOnairis == "1")
            { 
                if (OnairisMensaje(ObNotificaciones.gcrOnairisMensajes))
                {
                    // Cuando lo entrega se quita de la espera
                    ObNotificaciones.gcrOnairisMensajes = String.Empty;
                }
            }
            #endregion
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION procesos
        //---------------------------------------------------------------
        #region Finalizar
        public bool Finalizar()
        {
            var llgReturn = false;
            lock (this)
            {
                ObOnairis.Finalizar();
                Monitor.PulseAll(this);
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region Error Proceso
        public void ErrorProceso()
        {
            lock (this)
            {
                Finalizar();
            }
        }
        #endregion
        #region Reanudar
        public void ReAnudado()
        {
            lock (this)
            {
                if (this.llgPausar == true)
                {
                    this.llgPausar = false;
                }
            }
        }
        #endregion
        #region fcvCargarParametrosSistema
        private void fcvCargarParametrosSistema()
        {
            // Estado activo o inactivo los servicios
            gcrEstadoOnairis        = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-ESTADO-ONAIRIS", "1");
            gcrEstadoNotificacion   = Funciones.fcrLeerConfigVarSistema("ADS-ADSERV-ACTIVAR-NOTIFICACION", "1");
            gcrEstadoAlertas        = Funciones.fcrLeerConfigVarSistema("ADS-ADSERV-ACTIVAR-ALERTAS", "1");
            gcrEstadoBuzon          = Funciones.fcrLeerConfigVarSistema("ADS-ADSERV-ACTIVAR-BUZON", "1");
        }
        #endregion
        #region fcvRutaRecursos: Definir la ruta de los recursos 
        /// <summary>
        /// Activa la ruta de donde los servicios optendran los recursos
        /// tales como: imagenes, sonidos, videos y otros
        /// </summary>
        public void fcvRutaRecursos()
        {
            if (oApp.gcrAppBdatoTipoIpServidor == "RED")
            {
                lcrRutaRecursos = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            }
            else
            {
                lcrRutaRecursos = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            }
        }
        #endregion
        // Procesos Onairis
        #region fcrOnairisCargarMensaje: Cargar el mensaje desde la lista para leer
        /// <summary>
        /// Cargar el mensaje desde la lista para leer
        /// </summary>
        /// <returns>Retorna valor String con el texto completo de los mensaje contenidos en la lista de espera</returns>
        private String fcrOnairisCargarMensaje()
        {
            var lcrMensaje = String.Empty;

            if (ObOnairis != null && tmpOnairisMsj.Count > 0)
            {
                llgOnairisAddMens = true;
                foreach (var lobReg in tmpOnairisMsj)
                {
                    lcrMensaje += lobReg.Mensaje + " \r\n";
                }
                tmpOnairisMsj = new List<Mensajes>();
                llgOnairisAddMens = false;
            }
            return lcrMensaje;
        }
        #endregion
        #region OnairisMensaje: Entregar un mensaje para que onairis lo leea
        /// <summary>
        /// Entregar un mensaje para que onairis lo leea
        /// </summary>
        /// <param name="tcrMensaje">Mensaje de texto para leer</param>
        /// <returns>Retorna Verdadero cuando el mensaje es entregado a Onairis con exito, de lo contrario retorna falso.</returns>
        public bool OnairisMensaje(String tcrMensaje)
        {
            var llgReturn = false;
            if (ObOnairis != null)
            {
                if (llgOnairisAddMens == false)
                {
                    llgOnairisAddMens = true;
                    lnuContadorAddMensaje++;

                    var lobReg = new Mensajes
                    {
                        IdMensaje = lnuContadorAddMensaje.ToString().Trim(),
                        Mensaje = tcrMensaje,
                        FechayHora = DateTime.Now.ToString("f"),
                        Estado = "1"
                    };
                    tmpOnairisMsj.Add(lobReg);

                    llgOnairisAddMens = false;
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion

    }
}

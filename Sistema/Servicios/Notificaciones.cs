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
    public class Notificaciones
    {
        // Variables de gestion 
        Aplicacion oApp = Aplicacion.Instancia();
        private String gcrEstadoNotificacion  = "1";
        public String gcrOnairisMensajes      = String.Empty;

        // Clase principal
        #region Clase principal
        private static Notificaciones ObNotificaciones;
        private Notificaciones()
        {
            // clase principal
        }
        #endregion
        #region Instancia
        /// <summary>
        /// Onairis Asistente de voz: Iniciar la instancia unica en todo el sistema
        /// </summary>
        public static Notificaciones Instancia()
        {
            if (ObNotificaciones == null)
            {
                ObNotificaciones = new Notificaciones();
            }
            return ObNotificaciones;
        }
        #endregion
        #region Activar
        /// <summary>
        /// Carga los parametros de configuracion y se activa
        /// </summary>
        public void Activar()
        {
            // Valores por defecto
            fcvCargarParametrosSistema();
        }
        #endregion
        #region fcvCargarParametrosSistema
        private void fcvCargarParametrosSistema()
        {
            // Estado activo o inactivo los servicios
            gcrEstadoNotificacion = Funciones.fcrLeerConfigVarSistema("ADS-ADSERV-ACTIVAR-NOTIFICACION", "1");
        }
        #endregion
        //------------------------------------------------------------
        // RECOLECTOR GENERAL DE NOTIFICACIONES DEL SISTEMA
        //------------------------------------------------------------
        #region RecolectorNotificaciones: Actualizar temporal de notificaciones
        /// <summary>
        /// Ejecutar recolecto de mensajes de notificacion para el perfil y modulo activo
        /// </summary>
        public bool RecolectorNotificaciones()
        {
            var llgReturn = false;
            if (oApp.glgSysActivoActualizNotifi == false && oApp.glgSysActivoConsultaNotifi == false)
            {
                oApp.glgSysActivoActualizNotifi = true;
                oApp.gtmpSysListNotifi = SysModeloAdminMensajes.flstMensajesPorGruposYPerfil(oApp.gcrUsuCodigoPerfil, oApp.gcrUsuIdUsuario, oApp.gcrSysActivoIdModulo);
                fcvOnairisRevisarNotificaciones();
                oApp.glgSysActivoActualizNotifi = false;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region fcvOnairisRevisarNotificaciones: revisar el resumen anterior de notificaciones
        /// <summary>
        /// Revisar el resumen de notificaciones para informar al usuario activo cuando hay nuevas
        /// </summary>
        private void fcvOnairisRevisarNotificaciones()
        {
            gcrOnairisMensajes = String.Empty;
            foreach (var lobReg in oApp.gtmpSysListNotifi)
            {
                var lobRegEx = oApp.gtmpSysListNotifiAx.FirstOrDefault(x => x.IdNotificacion == lobReg.IdNotificacion && x.IdGrupo == lobReg.IdGrupo);
                if (lobRegEx == null)
                {
                    gcrOnairisMensajes += fcrOnairisGenMsjNotificacion(lobReg);

                    var lobRegAux = new SysAdmGrupoNotifi();

                    lobRegAux.IdGrupo            = lobReg.IdGrupo;
                    lobRegAux.NombreGrupo        = lobReg.NombreGrupo;
                    lobRegAux.IdNotificacion     = lobReg.IdNotificacion;
                    lobRegAux.NombreNotificacion = lobReg.NombreNotificacion;
                    lobRegAux.IdPerfil           = lobReg.IdPerfil;
                    lobRegAux.IdUsuario          = lobReg.IdUsuario;
                    lobRegAux.TipoNotifiPublico  = lobReg.TipoNotifiPublico;
                    lobRegAux.LlaveFechaHora     = lobReg.LlaveFechaHora;
                    lobRegAux.Contador           = lobReg.Contador;

                    oApp.gtmpSysListNotifiAx.Add(lobRegAux);
                }
                else
                {
                    // Verificar si hay uno nuevo
                    if (lobReg.LlaveFechaHora > lobRegEx.LlaveFechaHora)
                    {
                        lobRegEx.LlaveFechaHora = lobReg.LlaveFechaHora;
                        gcrOnairisMensajes += fcrOnairisGenMsjNotificacion(lobReg);
                    }
                    lobRegEx.Contador = lobReg.Contador;
                }
            }
            gcrOnairisMensajes = !String.IsNullOrWhiteSpace(gcrOnairisMensajes) ? "Hay Nuevas notificaciones. " + gcrOnairisMensajes : String.Empty;

        }
        #endregion
        #region fcrOnairisGenMsjNotificacion: Genera el mensaje de la notificacion
        /// <summary>
        /// Genera el mensaje de la notificacion
        /// </summary>
        private String fcrOnairisGenMsjNotificacion(SysAdmGrupoNotifi tobRegistro)
        {
            var lcrReturn = tobRegistro.NombreGrupo + ": " + tobRegistro.OnairisMensaje + ". \r\n";

            return lcrReturn;
        }
        #endregion

    }
}

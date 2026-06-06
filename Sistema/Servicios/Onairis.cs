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
    public class Onairis
    {
        // Variables de control 
        #region Variables publicas
        public bool EstaHablando        = false;
        public bool llgFinalizar        = false;
        public bool llgPausar           = false;
        public bool glgErrorProceso     = false;
        public String lcrMensajeAccion  = "Iniciando...";
        public String lcrMensajeError   = String.Empty;
        public String lcrIdUsuario      = String.Empty;
        #endregion
        #region Variables publicas
        public String gcrEstadoOnairis      = "1";
        public String gcrEstadoNotificacion = "1";
        public String gcrEstadoAlertas      = "1";
        public String gcrEstadoBuzon        = "1";
        public String lcrSonidoActivacion   = "Data_7.wav";
        public String lcrSonidoIniHablar    = "Data_2.wav";
        public String lcrSonidoFinHablar    = "Data_3.wav";
        public String lcrRutaRecursos       = String.Empty;
        #endregion

        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        Thread gobTarea = null;
        public SpeechSynthesizer lobVoz = new SpeechSynthesizer();

        // Clase principal
        #region Clase principal
        private static Onairis ObOnairis;
        private Onairis()
        {
            // clase principal
        }
        #endregion
        #region Instancia
        /// <summary>
        /// Onairis Asistente de voz: Iniciar la instancia unica en todo el sistema
        /// </summary>
        public static Onairis Instancia()
        {
            if (ObOnairis == null)
            {
                ObOnairis = new Onairis();
            }
            return ObOnairis;
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
            var lobLen = new CultureInfo("es-MX");
            lobVoz.SetOutputToDefaultAudioDevice();
            lobVoz.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child, 1, lobLen);
            lobVoz.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(reader_SpeakCompleted);
            Sonido(lcrSonidoActivacion);
        }
        #endregion
        //---------------------------------------------------------------
        //  Timer Para propositos varios
        //---------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            if (lobVoz.State == SynthesizerState.Speaking)
            {
                EstaHablando = true;
            }
            else
            {
                EstaHablando = false;
            }
        }
        #endregion
        //---------------------------------------------------------------
        // Hablar
        //---------------------------------------------------------------
        #region Hablar llamada publica
        public void Hablar(String tcrTexto)
        {
            if (!String.IsNullOrWhiteSpace(tcrTexto))
            {
                Sonido(lcrSonidoIniHablar);
                Thread.Sleep(500);
                gobTarea = new Thread(new ParameterizedThreadStart(Hablar));
                gobTarea.Start(tcrTexto);
            }
        }
        #endregion
        #region Hablar llamada privada de gestion
        private void Hablar(Object tobTexto)
        {
            if (tobTexto != null)
            {
                var lcrTexto = tobTexto.ToString();

                if (!String.IsNullOrWhiteSpace(lcrTexto))
                {
                    lobVoz.SpeakAsync(lcrTexto);
                }
            }
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION procesos
        //---------------------------------------------------------------
        #region Pausar
        public void Pausar()
        {
            lock (this)
            {
                if (this.llgPausar == false)
                {
                    this.llgPausar = true;
                    lobVoz.Pause();
                }
            }
        }
        #endregion
        #region Finalizar
        public bool Finalizar()
        {
            var llgReturn = false;
            lock (this)
            {
                gdspTimerSistema.Stop();
                Monitor.PulseAll(this);
                lobVoz.Dispose();
                this.llgFinalizar = true;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region Error Proceso
        public void ErrorProceso()
        {
            /*
            lock (this)
            {
                glgErrorProceso = true;
                //Monitor.PulseAll(this);
            }
            */
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
                    lobVoz.Resume();
                }
            }
        }
        #endregion
        #region Sonido
        private void Sonido(String tcrSonido)
        {
            if (tcrSonido != "NA")
            {
                var lobSonido = new SoundPlayer(lcrRutaRecursos + @"\Onairis\Sonidos\" + tcrSonido);
                lobSonido.Play();
            }
        }
        #endregion
        #region Sonido de cierre del evento
        private void reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            Sonido(lcrSonidoFinHablar);
        }
        #endregion
        // Cargar parametros
        #region fcvCargarParametrosSistema
        private void fcvCargarParametrosSistema()
        {
            // Estado activo o inactivo del asistente
            gcrEstadoOnairis = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-ESTADO-ONAIRIS", "1");

            //  Sonidos para gestion 
            lcrSonidoActivacion = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-SONIDO-ACTIVACION", "Data_7.wav");
            lcrSonidoIniHablar  = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-SONIDO-VOZ-INICIO", "Data_2.wav");
            lcrSonidoFinHablar  = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-SONIDO-VOZ-FIN", "Data_3.wav");

            // Estado activo o inactivo para notificaciones 
            gcrEstadoNotificacion = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-ACTIVAR-NOTIFICACION", "1");
            gcrEstadoAlertas      = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-ACTIVAR-ALERTAS", "1");
            gcrEstadoBuzon        = Funciones.fcrLeerConfigVarSistema("ONR-ONRCNF-ACTIVAR-BUZON", "1");
        }
        #endregion
    }
}

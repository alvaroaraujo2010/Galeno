using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for ControlNotificaciones.xaml
    /// </summary>
    public partial class ControlNotificaciones : UserControl
    {
        String lcrUri = "/Sistema;component/Imagenes/";
        public bool flgActualizando = false;
        public bool flgFinalizado = false;
        public int lnuContarTime = 0;
        public List<SysAdmGrupoNotifi> tmpObjetos = null;
        public List<SysAdmGrupoNotifi> tmpListNotif = null;
        public String gcrIdModulo = String.Empty;
        public String gcrIdvista = String.Empty;
        DispatcherTimer ldspTimerSistema = null;
        Aplicacion oApp = Aplicacion.Instancia();

        public ControlNotificaciones()
        {
            InitializeComponent();
            fcvTimerGeneral();
        }
        //------------------------------------------------------------
        // Timer actualizar notificaciones
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            ldspTimerSistema = new DispatcherTimer();
            ldspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 2000);
            ldspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            // al mostrar la vista del historial
            if (flgActualizando == false && lnuContarTime >= 10)
            {
                fcvActalizarVistaNotificaciones();
            }
            else 
            {
                lnuContarTime++;
            }
            if (flgFinalizado == true && flgActualizando == false && ldspTimerSistema!=null)
            {
                ldspTimerSistema.Stop();
                ldspTimerSistema = null;
            }
        }
        #endregion
        #region fcvActalizarVistaNotificaciones: Actualizar vista notificaciones
        /// <summary>
        /// Actualizar vista notificaciones
        /// </summary>
        public void fcvActalizarVistaNotificaciones()
        {
            flgActualizando = true;
            if (ldspTimerSistema != null && oApp.glgSysActivoActualizNotifi == false && oApp.gtmpSysListNotifi != null)
            {
                oApp.glgSysActivoConsultaNotifi = true;
                foreach (var lobReg in tmpObjetos)
                {
                    fcvActualizarBoton(lobReg);
                    if (flgFinalizado == true) 
                    {
                        oApp.glgSysActivoConsultaNotifi = false; 
                        break; 
                    }
                }
                oApp.glgSysActivoConsultaNotifi = false;
            }
            flgActualizando = false;
            lnuContarTime = 0;
        }
        #endregion
        //------------------------------------------------------------
        // Eventos para cargar notificaciones
        //------------------------------------------------------------
        #region flgCargarVistaNotificaciones: Cargar vista botones de notificacion
        /// <summary>
        /// Cargar vista botones notificaciones segun vista modulo dada en prametro tcrIdvista
        /// </summary>
        public bool flgCargarVistaNotificaciones(String tcrIdPerfil, String tcrIdModulo, String tcrIdvista)
        {
            flgActualizando = true;
            gcrIdModulo = tcrIdModulo;
            gcrIdvista = tcrIdvista;

            tmpObjetos = new List<SysAdmGrupoNotifi>();
            var llgReturn = false;
            var tmpDatos = SysModeloNotifiPorGrupo.flsListaSysadmnotigrupoEx(tcrIdPerfil,tcrIdvista);
            var lobRegEx = new SysAdmGrupoNotifi();
            var lobBoton = new TilesNotificacion();
            foreach (var lobReg in tmpDatos)
            {
                llgReturn = true;
                lobRegEx = new SysAdmGrupoNotifi();

                // Cargar caracteristicas boton
                lobBoton = new TilesNotificacion();
                //lobBoton.Name          = lobReg.Sys_codtip_sytm;
                lobBoton.ToolTip         = lobReg.Sys_desmsj_sytm;
                lobBoton.TileTitulo.Text = lobReg.Sys_titulo_syng;
                lobBoton.imgIcono.Source = new BitmapImage(new Uri(lcrUri + lobReg.Grc_iderec_grcm.Trim(), UriKind.RelativeOrAbsolute));
                lobBoton.fcvNotificaciones(0, tcrIdModulo, lobReg.Sys_codtip_sytm);

                // Datos para el temporal
                lobRegEx.IdGrupo            = lobReg.Sys_codmsg_symg;
                lobRegEx.IdNotificacion     = lobReg.Sys_codtip_sytm;
                lobRegEx.NombreNotificacion = lobReg.Sys_desmsj_sytm;
                lobRegEx.Contador           = 0;
                lobRegEx.RefObjeto          = lobBoton;
                lobRegEx.FiltroBusqueda     = String.Empty;

                tmpObjetos.Add(lobRegEx);
                this.stkVista.Children.Add(lobBoton);
            }
            // si no carga objetos finalizar el timer
            flgFinalizado = tmpObjetos != null ? false : true;

            flgActualizando = false;
            lnuContarTime = 0;

            return llgReturn;
        }
        #endregion
        #region fcvActualizarBoton: Actualizar notifcaciones en cada boton de la vista
        /// <summary>
        /// Actualizar notifcaciones en cada boton de la vista
        /// </summary>
        private void fcvActualizarBoton(SysAdmGrupoNotifi tobRegistro)
        {
            int lnuContador = 0;
            if (oApp.gtmpSysListNotifi != null)
            {
                var lobRegEx = oApp.gtmpSysListNotifi.FirstOrDefault(x => x.IdNotificacion == tobRegistro.IdNotificacion && 
                                                                     x.IdGrupo == tobRegistro.IdGrupo);
                if (lobRegEx != null)
                {
                    lnuContador = lobRegEx.Contador;
                }
            }
            var lobObj = tobRegistro.RefObjeto as TilesNotificacion;
            lobObj.fcvActualizarNotificacion(lnuContador);
        }
        #endregion
        #region fcvFinalizarEventos: Finalizar los eventos que actualizan notificaciones
        /// <summary>
        /// Finalizar los eventos que actualizan notificaciones
        /// </summary>
        public void fcvFinalizarEventos()
        {
            flgFinalizado = true;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Shapes;
using Sistema.Clases;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for DialogVistaNotificaciones.xaml
    /// </summary>
    public partial class DialogVistaNotificaciones : Window
    {
        #region ClassTempNotific: Clase para temporal referencias a los registros  notificación
        /// <summary>
        /// <para>Clase para temporal referencias a los registros de notificación</para>
        /// </summary>
        public class ClassTempNotific
        {
            #region Clase
            public FrameworkElement RefObjeto { get; set; } // Referencia a la instancia del Objeto Tile en la vista muro
            public String LlaveBusqueda { get; set; }       // HCL_KEYDAT_HCEV	Palabras claves para usar como llaves de busqueda 
            public DateTime ldaLlaveFecha { get; set; }     // Llave fecha del grupo
            public String EstadoRegistro { get; set; }      // SIS_ESTPRO_ESPR	Estado de procesos en atencion asistencial : 1= Abierto  2= Cerrado/Confirmado 3=Anulado
            #endregion
        }
        #endregion

        private double lduWidth;
        private double lduHeight;
        private bool glgVistaPropVisible = false;
        DispatcherTimer ldspTimerSistema = null;
        public String gcrTitulo = String.Empty;
        public String gcrIdModulo = String.Empty;
        public String gcrTipoNotificacion = String.Empty;
        public String gcrIdPerfil = String.Empty;
        public String gcrIdUsuario = String.Empty;
        public DateTime gdaFechaAux = Funciones.fdaConvertFecha("DMY", "/", "01/01/0001");
        public String gcrFechaAux = String.Empty;
        public int gnuTotalRegistros = 0;
        public int gnuTotalRegCargados = 0;
        public List<ClassTempNotific> tmpRefGrupos = null;
        private List<SysModeloAdminMensajes> tmpDatos = null;
        private List<ClassTempNotific> tmpRefCargarMas = new List<ClassTempNotific>();

        public DialogVistaNotificaciones()
        {
            InitializeComponent();

            fcvResizePantalla();
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvTimerGeneral();
        }
        //------------------------------------------------------------
        // Evento para detectar el cambio de Resolucion de Pantalla en Windows
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            ldspTimerSistema = new DispatcherTimer();
            ldspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 120);
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
            if (glgVistaPropVisible == false && this.Left == (lduWidth + 10))
            {
                Window lobRefEnlace = this.Owner as Window;
                if (lobRefEnlace != null)
                {
                    lobRefEnlace.Activate();
                }
                ldspTimerSistema.Tick -= new System.EventHandler(out fcvTimerProcesos);
                ldspTimerSistema.Stop();
                ldspTimerSistema = null;
                fcvLimpiarHandlerVistaDatos();
                this.Close();
            }
        }
        #endregion
        #region fcvResizePantalla: Tamaños de pantalla y objetos
        /// <summary>
        /// <para>Detectar el cambio de Resolucion de Pantalla en Windows y realizar ajustes</para>
        /// </summary>
        void SystemEvents_ReajustarVistaPantalla(object sender, EventArgs e)
        {
            fcvResizePantalla();
        }
        public void fcvResizePantalla()
        {

            lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 96.8;
            lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;

            this.Height = lduHeight;
            this.Fondo.Height = lduHeight;
            this.Left = lduWidth + 10;
        }
        #endregion
        //------------------------------------------------------------
        // Cargar vista de datos
        //------------------------------------------------------------
        #region fcvCargarVista: Carga lista para log de errores
        /// <summary>
        /// <para>Carga lista notificaciones segun tipo (tcrTipoNotificacion)</para>
        /// </summary>
        public void fcvCargarVista(String tcrTitulo,  String tcrIdPerfil, String tcrIdUsuario, 
                                   String tcrIdModulo, String tcrTipoNotificacion)
        {
            gcrTitulo           = tcrTitulo;
            gcrIdPerfil         = tcrIdPerfil;
            gcrIdUsuario        = tcrIdUsuario;
            gcrIdModulo         = tcrIdModulo;
            gcrTipoNotificacion = tcrTipoNotificacion;

            this.lblTitulo.Text = gcrTitulo;

            fcvCargarVistaDatos();
        }
        #endregion
        #region fcvCargarVistaDatos: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaDatos()
        {
            var llgTipoNotify = false;
            tmpRefGrupos = new List<ClassTempNotific>();
            tmpDatos = new List<SysModeloAdminMensajes>();
            tmpRefCargarMas = new List<ClassTempNotific>();

            this.stkHistorial.Children.Clear();

            // Verificar el tipo de mensaje
            var lobTipo = SYSValidarCodigo.fobRegBuscarSysadmstipomens(gcrTipoNotificacion);

            if (lobTipo != null)
            {
                var lcrUri = "/Sistema;component/Imagenes/";
                llgTipoNotify = lobTipo.sys_tipmsj_syam == "3" ? true : false;
                this.imgVista.Source = new BitmapImage(new Uri(lcrUri + lobTipo.grc_iderec_grcm, UriKind.RelativeOrAbsolute));
            }

            // Cargar datos
            if (llgTipoNotify == true)
            {
                // Privado o particular para un usuario
                tmpDatos = SysModeloAdminMensajes.flsListaSysadmsmensajesModuloUs(gcrIdUsuario, gcrIdModulo, gcrTipoNotificacion);
            }
            else
            {
                tmpDatos = SysModeloAdminMensajes.flsListaSysadmsmensajesModulo(gcrIdPerfil, gcrIdModulo, gcrTipoNotificacion);
            }
            // Cargar datos iniciales
            gnuTotalRegistros = tmpDatos != null ? tmpDatos.Count : 0;
            gnuTotalRegCargados = 0;
            fcvCargarVistaDatosLotes(30);
        }
        #endregion
        #region fcvCargarVistaDatosLotes: Carga registros por lotes
        /// <summary>
        /// <para>Carga registros en vista detalles por lotes segun cantidad dada en parametro</para>
        /// </summary>
        public void fcvCargarVistaDatosLotes(int tnuRegistrosCantidad)
        {
            // Cargar datos
            if (tmpDatos != null && tmpDatos.Count != 0)
            {
                var lnuCont = 0;
                foreach (var lobReg in tmpDatos)
                {
                    if (lobReg.GestionEstadoRegistro == "XX" && lnuCont <= tnuRegistrosCantidad)
                    {
                        lnuCont++;
                        gnuTotalRegCargados++;

                        // titulo del grupo de registros
                        if (gdaFechaAux != lobReg.Sys_sisfec_syam)
                        {
                            var lcrFecha  = lobReg.Sys_sisfec_syam.ToString("D");
                            var lobTitulo = new ControlNotificacionTituloGrupo();

                            lobTitulo.txtTitulo.Text = lcrFecha.Substring(0, 1).ToUpper() + lcrFecha.Substring(1, lcrFecha.Length - 1);
                            this.stkHistorial.Children.Add(lobTitulo);

                            // aqgregar titulo al grupo
                            var lcrRegx = new ClassTempNotific();
                            lcrRegx.RefObjeto       = lobTitulo;
                            lcrRegx.ldaLlaveFecha   = lobReg.Sys_sisfec_syam;
                            lcrRegx.EstadoRegistro  = "1"; // Visible
                            tmpRefGrupos.Add(lcrRegx);
                        }
                        gdaFechaAux = lobReg.Sys_sisfec_syam;

                        // Generar el registro
                        var lobRegNotific = new ClassTempNotific();
                        var lobDetalle = new ControlNotificacionReg();
                        //Generar llave
                        gcrFechaAux = lobReg.Sys_sisfec_syam.ToString("D") + " " + lobReg.Sys_sisfec_syam.ToShortDateString(); 
                        var lcrLlave = (lobReg.Sys_desmsj_sytm.Trim() + " " + 
                                        lobReg.Sys_desmsj_syam.Trim() + " " + 
                                        lobReg.Sys_notmsj_syam.Trim() + " " +
                                        gcrFechaAux).ToLower();

                        lobDetalle.fcvCargarVistaDatos(lobReg);
                        lobDetalle.cmdHistorialVer.Click += new RoutedEventHandler(fcvCmdVerDatos);
                        lobDetalle.cmdOk.Click += new RoutedEventHandler(fcvCmdMarcarYaVisto);

                        lobReg.GestionRefObjeto = lobDetalle;
                        lobReg.GestionLlaveBusqueda = lcrLlave;
                        lobReg.GestionEstadoRegistro = "OK"; // ya fue cargado

                        this.stkHistorial.Children.Add(lobDetalle);
                    }
                }
                // Cuando quedan registros pendientes por cargar mostrar boton: "Mostrar mas..."
                if (gnuTotalRegCargados < gnuTotalRegistros)
                {
                    var lobVerMas = new ControlNotificacionVerMas();

                    if (lobVerMas != null)
                    {
                        lobVerMas.cmdVerMas.Click += new RoutedEventHandler(fcvCmdVerMasRegistros);

                        var lcrReg = new ClassTempNotific();
                        lcrReg.RefObjeto = lobVerMas;
                        tmpRefCargarMas.Add(lcrReg);

                        this.stkHistorial.Children.Add(lobVerMas);
                    }

                }
            }
        }
        #endregion
        #region fcvLimpiarHandlereVistaDatos: Quitar referencia eventos registros en vista detalles
        /// <summary>
        /// <para>Quitar referencia eventos registros en vista detalles</para>
        /// </summary>
        public void fcvLimpiarHandlerVistaDatos()
        {
            #region Referencias a boton "Mostrar mas..." despues de cada cargue
            if (tmpRefCargarMas != null)
            {
                foreach (var lobReg in tmpRefCargarMas)
                {
                    var lobDetalle = lobReg.RefObjeto as ControlNotificacionVerMas;

                    if (lobDetalle != null)
                    {
                        lobDetalle.cmdVerMas.Click -= new RoutedEventHandler(fcvCmdVerMasRegistros);
                    }
                }
                tmpRefCargarMas = null;
            }
            #endregion
            #region Referencias a todos los registros cargados
            if (tmpDatos != null)
            {
                foreach (var lobReg in tmpDatos)
                {
                    if (lobReg.GestionEstadoRegistro == "OK")
                    {
                        var lobDetalle = lobReg.GestionRefObjeto as ControlNotificacionReg;

                        if (lobDetalle != null)
                        {
                            lobDetalle.cmdHistorialVer.Click -= new RoutedEventHandler(fcvCmdVerDatos);
                            lobDetalle.cmdOk.Click -= new RoutedEventHandler(fcvCmdMarcarYaVisto);
                        }
                    }
                }
                tmpDatos = null;
            }
            #endregion
            this.stkHistorial.Children.Clear();
            System.GC.Collect();
        }
        #endregion
        //------------------------------------------------------------
        // Interface para devolver valores seleccionados y opciones
        //------------------------------------------------------------
        #region fcvCmdMarcarYaVisto: Marcar notificacion como ya vista
        /// <summary>
        /// Marcar notificacion como ya vista
        /// </summary>
        private void fcvCmdMarcarYaVisto(object sender, RoutedEventArgs e)
        {

            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobCrt = lobGrid.Parent as ControlNotificacionReg;

            if (lobCrt != null)
            {
                var tmpRegBase = SysModeloAdminMensajes.flsListaSysadmsmensajes(lobCrt.gcrIdUnicoRegistro);
                if (tmpRegBase != null)
                {
                    var lcrIdRegistroBase = tmpRegBase.FirstOrDefault().Sys_parent_syam;
                    var oApp = Aplicacion.Instancia();
                    lobBoton.IsEnabled = false;
                    var lcrUri = "/Sistema;component/Imagenes/";
                    lobCrt.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));

                    var tmpList = SysModeloAdminMensajes.flstCargarNotifiYaVistaPerfil(oApp.gcrUsuCodigoPerfil, lobCrt.gcrIdNotificacion);
                    foreach (var lobReg in tmpList)
                    {
                        if (lcrIdRegistroBase == lobReg.sys_parent_syam)
                        {
                            SysModeloAdminMensajes.fcvMarcaNotifiYaVista(lobReg.sys_codsec_syam, oApp.gcrUsuIdUsuario);
                        }
                    }
                    ((Button)sender).Visibility = Visibility.Collapsed;
                }
            }
        }
        #endregion
        #region fcvCmdVerDatos: Ver los datos referenciados en la notificacion
        /// <summary>
        /// Ver los datos referenciados en la notificacion
        /// </summary>
        private void fcvCmdVerDatos(object sender, RoutedEventArgs e)
        {
            fcvRetornoInterface(sender);
        }
        #endregion
        #region fcvCmdVerMasRegistros: Cargar mas registros en vista 
        /// <summary>
        /// Cargar mas registros en vista
        /// </summary>
        private void fcvCmdVerMasRegistros(object sender, RoutedEventArgs e)
        {
            var lobButton               = (Button)sender;
            var lobGrid                 = lobButton.Parent as Grid;
            var lobCrt                  = lobGrid.Parent as ControlNotificacionVerMas;
            lobButton.Visibility        = Visibility.Collapsed;
            lobCrt.txtTitulo.Visibility = Visibility.Visible;
            
            // Cargar los datos
            fcvCargarVistaDatosLotes(100);

            //Ocultar vista boton
            lobCrt.Visibility = Visibility.Collapsed;
        }
        #endregion
        #region fcvRetornoInterface
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(object sender)
        {
            var lobBoton = sender as  Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobCrt = lobGrid.Parent as ControlNotificacionReg;

            INotificacion lobRefEnlace = this.Owner as INotificacion;
            if (lobRefEnlace != null && lobCrt != null) 
            {
                lobRefEnlace.fcvINotificacion(lobCrt.gcrIdUnicoRegistro, lobCrt.gcrIdModulo, lobCrt.gcrIdNotificacion, lobCrt.gcrIdRegReferencia);
            }
        }
        #endregion
        //------------------------------------------------------------
        // Mostrar /Ocultar Ventana
        //------------------------------------------------------------
        #region fcvCerraVista: cerrar la vista
        /// <summary>
        /// <para>cerrar la vista</para>
        /// </summary>
        private void fcvCerraVista(object sender, RoutedEventArgs e)
        {
            fcvCerrarVista();
        }
        #endregion
        #region fcvActivarVista: Mostrar u Ocultar la Ventana Historial de notificaciones
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial de notificaciones</para>
        /// </summary>
        public void fcvActivarVista()
        {

            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                this.Show();
                this.Top = 0;
                var lnuLeft = lduWidth - 540;
                luxAnimacion.To = lnuLeft; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
                glgVistaPropVisible = true;
                this.BeginAnimation(Window.LeftProperty, luxAnimacion);
            }
        }
        #endregion
        #region fcvCerrarVista: Mostrar u Ocultar la Ventana 
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial</para>
        /// </summary>
        public void fcvCerrarVista()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == true)
            {
                var lnuLeft = lduWidth + 10;
                luxAnimacion.To = lnuLeft; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = false;
                this.BeginAnimation(Window.LeftProperty, luxAnimacion);
            }
        }
        #endregion
        //------------------------------------------------------------
        // BUSCAR EN NOTIFICACIONES
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            fcvVistaHistorialFiltro(lobTexto.Text);
        }
        #endregion
        #region fcvVistaHistorialFiltro: filtro acercado del historial de eventos en el muro
        /// <summary>
        /// <para>filtro acercado del historial de eventos en el muro, oculta los eventos que </para>
        /// <para>no cumplen con el parametro texto del filtro.</para>
        /// </summary>
        public void fcvVistaHistorialFiltro(String tcrTexto)
        {
            if (tmpDatos == null || tmpDatos.Count == 0) { return; }

            // ocultar titulos grupos 
            foreach (var lobReg in tmpRefGrupos)
            {
                lobReg.EstadoRegistro = "2";
            }

            // Filtrar datos
            var lcrTexto = tcrTexto.ToLower();
            foreach (var lobReg in tmpDatos)
            {
                if (lobReg.GestionEstadoRegistro == "OK")
                {
                    var lobTile = lobReg.GestionRefObjeto as ControlNotificacionReg;

                    if (lobTile != null)
                    {
                        lobTile.Visibility = Visibility.Visible;

                        if (!String.IsNullOrWhiteSpace(tcrTexto))
                        {
                            if (lobReg.GestionLlaveBusqueda != null)
                            {
                                if (!lobReg.GestionLlaveBusqueda.Contains(lcrTexto))
                                {
                                    lobTile.Visibility = Visibility.Collapsed;
                                }
                                else
                                {
                                    tmpRefGrupos.FirstOrDefault(x => x.ldaLlaveFecha == lobReg.Sys_sisfec_syam).EstadoRegistro = "1";
                                }
                            }
                            else
                            {
                                lobTile.Visibility = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            tmpRefGrupos.FirstOrDefault(x => x.ldaLlaveFecha == lobReg.Sys_sisfec_syam).EstadoRegistro = "1";
                        }
                    }
                }
            }
            // Mostrar/ocultar titulos de grupos
            foreach (var lobReg in tmpRefGrupos)
            {
                var lobObj = lobReg.RefObjeto as ControlNotificacionTituloGrupo;
                if (lobObj != null)
                {
                    lobObj.Visibility = lobReg.EstadoRegistro == "1" ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
        #endregion

    }
}

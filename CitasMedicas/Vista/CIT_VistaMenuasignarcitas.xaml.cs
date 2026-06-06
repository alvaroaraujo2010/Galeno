using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Windows.Input;
using System.Security.Principal;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using CitasMedicas.VistaModelo;
using Sistema.Vista;
using Sistema.Utilidades;
using Microsoft.Win32;
using Datos.Modelos;
using CitasMedicas.Vista;
using CitasMedicas.Utilidades;
using Reportes.Utilidades;

namespace CitasMedicas.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VistaMenuasignarcitas : Window, SIS_Interface
    {
        #region VistaMenuasignarcitas
        private double initMouseX;
        private double finalMouseX;
        private double x;
        private double newX;
        private DispatcherTimer timer;
        private DispatcherTimer objHora;
        private DoubleAnimationUsingKeyFrames anim;
        public Dictionary<string, string[]> garDiccionario;
        public Dictionary<string, string[]> garDiccionarioAux;
        public Dictionary<string, string[]> garDiccionarioAux1;
        public Dictionary<string, double> garDiccPosGrupo;
        public IUMetro lobIUMetro;
        public String gcrCodigoModulo;
        public String gcrOpcionFiltro;
        public String gcrValorFiltro;
        public int lnuContTouchDown = 0;
        public int gnuContTouchMiliseg = 0;
        public String gcrListaLiveTiles = String.Empty;
        public bool glgEjecutandoLiveTiles = false;
        public int gnuContLiveTilesMiliseg = 0;
        public int gnuContRefreshLiveTiles = 0;
        public bool glgVistaCapaVisible = false;

        Aplicacion oApp = Aplicacion.Instancia();
        // Constructor de la clase 
        public VistaMenuasignarcitas()
        {
            InitializeComponent();

            fcTimer();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            fcvResizePantalla();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            //this.GotFocus += new RoutedEventHandler(fcvGotFocus);

        }
        #endregion
        //------------------------------------------------------------
        // Filtrar Vista Browser 
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscar_Loaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }

        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            TextBox lobTexto = (TextBox)sender;
            // Buscar por Titulo Columna 3
            if (lobTexto.Text.Trim().Length==1)
            {
                IUMetro.fcvIrTopVistaGrupo(ref MetroStackPanel,-15);
            }
            if (lobIUMetro != null)
            {
                IUMetro.fcvFiltrarVistaTiles02(ref garDiccionario, ref lobIUMetro.garRefWPGrupos,
                                               ref lobIUMetro.garRefTiles02, lobTexto.Text.Trim(), "4,5,7,18"); // Se cuenta el orden desde columna desde 1 (no segun c#)
            }
            glgEjecutandoLiveTiles = false;

        }
        #endregion
        //------------------------------------------------------------
        // Ejecutar Vista de gestion
        //------------------------------------------------------------
        #region Ejecutar Vista de gestion
        private void fcvClickTiles(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            fcvTilesEjecutar(sender);
        }
        private void fcvTilesTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            if (lnuContTouchDown > 0)
            {
                lnuContTouchDown = 0;
                fcvTilesEjecutar(sender);
            }
            lnuContTouchDown++;
        }
        private void fcvTilesEjecutar(Object sender)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            Tiles02 lobTiles = (Tiles02)sender;
            VistaAsignarCitas lobform = new VistaAsignarCitas(lobTiles.gcrCodigoItem);

            gcrOpcionFiltro = "ESTADOCITA";
            lobform.llgAccionEdicion = false;
            lobform.Owner = this;
            lobform.ShowDialog();
            lobform = null;

            fcvEjecutarRecolectorBasuraMemoria();

            glgEjecutandoLiveTiles = false;
        }

        #endregion
        //------------------------------------------------------------
        // Mover Canvas segun Gestos
        //------------------------------------------------------------
        #region Mover Canvas segun Gestos
        private void MenuComponentes_KeyUp(Object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Move MetroStackPanel so that the WrapPanel with the 
            // required alphabetical group is displayed first.
            //String ss = e.Key.ToString();
            //QuickJumper.ShiftStackPanel(ref ss, ref MetroStackPanel);
        }
        private void fcvMainCanvas_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            initMouseX = e.GetTouchPoint(MainCanvas).Position.X;
            x = Canvas.GetLeft(MetroStackPanel);
        }

        private void fcvMainCanvas_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            finalMouseX = e.GetTouchPoint(MainCanvas).Position.X;
            Double diff = Math.Abs(finalMouseX - initMouseX);

            // Make sure the diff is substantial so that tiles 
            // don't scroll on double-click.
            if (diff > 5)
            {
                if (finalMouseX < initMouseX)
                {
                    newX = x - (diff * 2);
                }
                else if (finalMouseX > initMouseX)
                {
                    newX = x + (diff * 2);
                }
                lnuContTouchDown = 0;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
                timer.Start();
            }
        }

        private void MainCanvas_PreviewMouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            initMouseX = e.GetPosition(MainCanvas).X;
            x = Canvas.GetLeft(MetroStackPanel);
        }
        private void MainCanvas_PreviewMouseLeftButtonUp(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            finalMouseX = e.GetPosition(MainCanvas).X;
            Double diff = Math.Abs(finalMouseX - initMouseX);
            // Make sure the diff is substantial so that tiles 
            // don't scroll on double-click.
            if (diff > 5)
            {
                if (finalMouseX < initMouseX)
                {
                    newX = x - (diff * 2);
                }
                else if (finalMouseX > initMouseX)
                {
                    newX = x + (diff * 2);
                }
                lnuContTouchDown = 0;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
                timer.Start();
            }
        }
        // Check whether the StackPanel is no longer in view and
        // return it to a suitable postion.
        private void timer_Tick(Object sender, EventArgs e)
        {
            Double mspWidth = MetroStackPanel.ActualWidth;

            if (newX > 200)
            {
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(45, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            else if ((newX + mspWidth) < 500)
            {
                Double widthX = 500 - (newX + mspWidth);
                Double shiftX = newX + widthX;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(shiftX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            timer.Stop();
        }
        #endregion
        //------------------------------------------------------------
        // Gestion Procesos y Hora del sistema
        //------------------------------------------------------------
        #region Hora del sistema
        public void fcTimer()
        {
            txtnick.Text = oApp.gcrUsuNombreUsuario;
            timer = new DispatcherTimer();
            objHora = new DispatcherTimer();
            objHora.Tick += new System.EventHandler(out fcvHoraSistema_Tick);
            objHora.Interval = new TimeSpan(0, 0, 0, 0, 200);
            objHora.Start();
            anim = new DoubleAnimationUsingKeyFrames();
            anim.Duration = TimeSpan.FromMilliseconds(1800);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += new System.EventHandler(out timer_Tick);
        }
        void fcvHoraSistema_Tick(object sender, EventArgs e)
        {
            this.TxtHora.Text = DateTime.Now.ToString("f");//hh:mm tt dd/MM/yyyy");
            #region Control para TouchScreen
            if (lnuContTouchDown > 0 && gnuContTouchMiliseg < 4)
            {
                gnuContTouchMiliseg++;
            }
            else
            {
                lnuContTouchDown = 0;
                gnuContTouchMiliseg = 0;
            }
            #endregion
            fcvRefreshVistaTiles();
        }
        private void MainBgrndRct_MouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
        //  fcvRefreshVistaTiles: Refresh para Live Tiles
        #region fcvRefreshVistaTiles: Rerescar Vista
        public void fcvRefreshVistaTiles()
        {
            if (!String.IsNullOrWhiteSpace(gcrValorFiltro))
            {
                if (glgEjecutandoLiveTiles == false && gnuContLiveTilesMiliseg < 30)
                {
                    gnuContLiveTilesMiliseg++;
                }
                else
                {
                    if (glgEjecutandoLiveTiles == false)
                    {
                        glgEjecutandoLiveTiles = true;
                        // Refresh
                        fcvActualizIUMetroTurno(gcrValorFiltro);
                        gnuContLiveTilesMiliseg = 0;
                        glgEjecutandoLiveTiles = false;
                    }
                }
            }
            else
            {
                glgEjecutandoLiveTiles = false;
                gnuContRefreshLiveTiles = 0;
                gnuContLiveTilesMiliseg = 0;
            }
        }
        #endregion
        //------------------------------------------------------------
        // Cerrar o Minimizar la aplicacion
        //------------------------------------------------------------
        #region Cerrar o Minimizar la aplicacion
        private void MinimizeButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            oApp.glgWiniAplicacionDesactivar = true;
            //this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void MinimizeButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            oApp.glgWiniAplicacionDesactivar = true;
            //this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void CloseButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            fcvCerrarVista();
        }
        private void CloseButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvCerrarVista();
        }
        private void fcvCerrarVista()
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;
            objHora.Stop();
            fcvQuitarIUVistaTiles();
            LocalizadorVistaModelo.Cleanup();
            this.Close();
        }
        // Quitar vista de los tiles 
        #region Quitar vista de los tiles
        public void fcvQuitarIUVistaTiles()
        {
            // Cargar Vista Tiles
            lobIUMetro = new IUMetro();
            int i;
            //- Enlazar los eventos de Tiles
            for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
            {
                Tiles02 gobjTiles = lobIUMetro.garRefTiles02[i] as Tiles02;
                gobjTiles.MouseDoubleClick -= new MouseButtonEventHandler(fcvClickTiles);
                gobjTiles.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
            }
            this.MetroStackPanel.Children.Clear();
        }
        #endregion

        #endregion
        //------------------------------------------------------------
        // Evento para detectar el cambio de Resolucion de Pantalla en Windows
        //------------------------------------------------------------
        #region Resolucion de Pantalla en Windows
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            fcvResizePantalla();
        }

        public void fcvResizePantalla()
        {
            double lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 120;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 120;

            this.GridMenuBottom.Width = lduBarraWidth;
            var lnuStkheight = lduHeight * 0.62;
            this.MetroStackPanel.Height = lnuStkheight;
        }
        #endregion
        //-------------------------------------------------
        //  llamada desde filtros para cambiar vista browser
        //-------------------------------------------------
        #region llamada desde filtros para cambiar vista browser
        //-------------------------------------------------
        //  llamada desde Filtro para varios turnos
        //-------------------------------------------------
        #region llamada desde Browser para un turno en particular
        private void fcvFiltroBuscar(object sender, RoutedEventArgs e)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            VistaFiltroturnos frbro = new VistaFiltroturnos("");
            gcrOpcionFiltro = "FILTRO";
            frbro.Owner = this;
            frbro.ShowDialog();

            glgEjecutandoLiveTiles = false;
        }
        private void fcvFiltroBuscar_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            VistaFiltroturnos frbro = new VistaFiltroturnos("");
            gcrOpcionFiltro = "FILTRO";
            frbro.Owner = this;
            frbro.ShowDialog();

            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //-------------------------------------------------
        //  llamada desde Browser para un turno en particular
        //-------------------------------------------------
        #region llamada desde Browser para un turno en particular
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            //gcrValorFiltro = ""; // -aqui-
            var lcrFiltro = String.Empty;
            lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            Browser02 frbro = new Browser02("CIT", "CITMAESTROTURNO", 1, lcrFiltro, "Maestro de turnos por profesional...");
            gcrOpcionFiltro = "TURNO";
            frbro.Owner = this;
            frbro.ShowDialog();
            glgEjecutandoLiveTiles = false;
        }
        private void fcvBrowserBuscar_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            //gcrValorFiltro = ""; // -aqui-
            var lcrFiltro = String.Empty;
            lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            Browser02 frbro = new Browser02("CIT", "CITMAESTROTURNO", 1, lcrFiltro, "Maestro de turnos por profesional...");
            gcrOpcionFiltro = "TURNO";
            frbro.Owner = this;
            frbro.ShowDialog();
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //-------------------------------------------------
        //  llamada desde Browser para un turno en particular
        //-------------------------------------------------
        #region llamada desde Browser para un turno en particular
        private void fcvBrowserHistorialUsuario(object sender, RoutedEventArgs e)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            //gcrValorFiltro = ""; // -aqui-
            fcvBrowseHistorialUsuario();
        }
        private void fcvBrowseHistorialUsuario_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;

            fcvActivarVistaMenuInferior(false);
            //gcrValorFiltro = ""; // -aqui-
            fcvBrowseHistorialUsuario();
        }
        private void fcvBrowseHistorialUsuario()
        {
            //gcrValorFiltro = ""; // -aqui-
            var lcrFiltro = String.Empty;
            //lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            Browser02 frbro = new Browser02("CIT", "CITMAESASIGCITA", 1, lcrFiltro, "Historial citas del usuario...");
            gcrOpcionFiltro = "TURNO-US";
            frbro.Owner = this;
            frbro.ShowDialog();
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //-------------------------------------------------
        // Ejecutar filtros para cambiar vista
        //-------------------------------------------------
        #region Ejecutar filtros para cambiar vista
        public void fcvBuscarRegistro(String tcrCodigo)
        {
            switch (gcrOpcionFiltro)
            {
                case "FILTRO": // Varios turnos varios profesionales
                    gcrValorFiltro = tcrCodigo;
                    fcvCargarIUMetroTurno(gcrValorFiltro);
                    break;

                case "TURNO": // Un turno en particular
                    gcrValorFiltro = tcrCodigo;
                    fcvCargarIUMetroTurno(gcrValorFiltro);
                    break;

                case "TURNO-US": // Un turno en particular desde historial de un usuario
                    var lobReg = CITValidarCodigo.fobRegBuscarCitmaesasigcita(tcrCodigo);
                    if (lobReg != null)
                    {
                        gcrValorFiltro = lobReg.cit_codtur_turn;
                        fcvCargarIUMetroTurno(gcrValorFiltro);
                    }
                    break;

                case "ESTADOCITA": // se cambio estado a una Cita
                    if (tcrCodigo != "CANCELADA")
                    {
                        fcvActualizIUMetroTiles(tcrCodigo);
                    }
                    else
                    {
                        fcvCargarIUMetroTurno(gcrValorFiltro);
                    }
                    break;
            }
        }
        #endregion
        //-------------------------------------------------
        //  Cargar la vista Iu Metro 
        //-------------------------------------------------
        #region Cargar la vista Iu Metro 
        public void fcvCargarIUMetroTurno(String tcrTurnos)
        {
            glgEjecutandoLiveTiles = true;
            gnuContLiveTilesMiliseg = 0;
            //- quitar los eventos de Tiles
            if (lobIUMetro != null)
            {
                if (lobIUMetro.gnuTotalTiles > 0)
                {
                    int ix;
                    for (ix = 0; ix < lobIUMetro.gnuTotalTiles; ix++)
                    {
                        Tiles02 gobjTiles = lobIUMetro.garRefTiles02[ix] as Tiles02;
                        gobjTiles.MouseDoubleClick -= new MouseButtonEventHandler(fcvClickTiles);
                        gobjTiles.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
                    }
                }
            }
            // Cargar Vista Tiles
            lobIUMetro = new IUMetro();
            int i;
            garDiccionario = new clTilesTurno().fcArListaMenuTilesTurnos("1", tcrTurnos, "", "", "");
            garDiccPosGrupo = new Dictionary<string, double>();
            lobIUMetro.fcvVistaMetroTiles(ref garDiccionario, ref MetroStackPanel, ref garDiccPosGrupo, "GRUPO", "TILES02",17,18); //Lista sin titulos
            //- Enlazar los eventos de Tiles
            for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
            {
                Tiles02 gobjTiles = lobIUMetro.garRefTiles02[i] as Tiles02;
                gobjTiles.MouseDoubleClick += new MouseButtonEventHandler(fcvClickTiles);
                gobjTiles.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
            }
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //  Actualizar Todos los Tiles en la vista
        #region Actualizar todos Tiles
        public void fcvActualizIUMetroTurno(String tcrTurnos)
        {
            // Cargar Vista Tiles
            glgEjecutandoLiveTiles = true;
            garDiccionarioAux = new clTilesTurno().fcArListaMenuTilesTurnos("1", tcrTurnos, "", "", "");
            if (garDiccionarioAux.Count != garDiccionario.Count)
            {
                // Cargar de nuevo la vista
                fcvCargarIUMetroTurno(tcrTurnos);
            }
            else
            {
                IUMetro.fcvActualizarTiles02(ref garDiccionario, ref garDiccionarioAux, ref lobIUMetro.garRefTiles02);
                garDiccionario = new clTilesTurno().fcvActualizDiccTiles02(ref garDiccionario, ref garDiccionarioAux);
            }
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //  Actualizar solo uno o pocos Tiles
        #region Actualizar algunos Tiles
        public void fcvActualizIUMetroTiles(String tcrTiles)
        {
            // Cargar Vista Tiles
            glgEjecutandoLiveTiles = true;
            garDiccionarioAux = new clTilesTurno().fcArListaMenuTilesTurnos("2", tcrTiles, "", "", "");
            IUMetro.fcvActualizarTiles02(ref garDiccionario, ref garDiccionarioAux, ref lobIUMetro.garRefTiles02);
            garDiccionario = new clTilesTurno().fcvActualizDiccTiles02(ref garDiccionario, ref garDiccionarioAux);
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  ACTIVAR VISTA CAPA MENU INFERIOR 
        //-------------------------------------------------
        #region fcvGotFocus: Ocultar capas
        /// <summary>
        /// Ocultar las capas al dar clic en escritorio
        /// </summary>
        private void fcvGotFocus(object sender, EventArgs e)
        {
            // Ocultar Menu inferior
            if (glgVistaCapaVisible == true)
            {
                fcvActivarVistaMenuInferior(false);
            }
        }
        #endregion
        #region fcvActivarVistaMenuBottomMouseEnter: Gesto para mostrar Ventana Menu inferior
        /// <summary>
        /// <para>Gesto para mostrar Ventana Menu inferior </para>
        /// </summary>
        private void fcvActivarVistaMenuBottomMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaCapaVisible == false)
            {
                fcvActivarVistaMenuInferior(true);
            }
        }
        #endregion
        #region fcvActivarVistaMenuBottomTouchEnter: Gesto para mostrar Ventana Menu inferior
        /// <summary>
        /// <para>Gesto para mostrar Ventana Menu inferior</para>
        /// </summary>
        private void fcvActivarVistaMenuBottomTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaCapaVisible == false)
            {
                fcvActivarVistaMenuInferior(true);
            }
        }
        #endregion
        #region fcvActivarVistaMenuInferior: Mostrar u Ocultar Vista Capa Menu inferior
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa Menu inferior</para> 
        /// </summary>
        private void fcvActivarVistaMenuInferior(bool tlgModo)
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaCapaVisible == false)
            {
                if (tlgModo == true)
                {
                    luxAnimacion.To = -58; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaCapaVisible = true;
                    this.GridMenuBottom.BeginAnimation(Canvas.TopProperty, luxAnimacion);
                }
            }
            else
            {
                if (tlgModo == false)
                {
                    luxAnimacion.To = 30; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaCapaVisible = false;
                    this.GridMenuBottom.BeginAnimation(Canvas.TopProperty, luxAnimacion);
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // IMPRIMIR TURNOS ACTIVOS
        //-------------------------------------------------
        #region fcvPlantillaImprimir: Vista preliminar modelo imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            fcvImprimir();
        }
        private void fcvImprimir_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            fcvImprimir();
        }
        private void fcvImprimir()
        {
            if (!String.IsNullOrWhiteSpace(gcrValorFiltro))
            {
                var lobRegVista = new CITImprimirTurnos();

                lobRegVista.gcrListaCodigoTurnos = gcrValorFiltro; // Lista turnos activos en vista
                lobRegVista.glgVistaPrevia = true;     // true = mostrar vista previa / fase = no mostrar vista previa
                lobRegVista.gobOwner = this;
                lobRegVista.fcvEjecutar();
            }
        }
        #endregion
        //-------------------------------------------------
        // Limpiar la memoria 
        //-------------------------------------------------
        #region fcvEjecutarRecolectorBasuraMemoria: Recolectar la basura de memoria
        /// <summary>
        /// Recolectar la basura y liberar memoria 
        /// </summary>
        public void fcvEjecutarRecolectorBasuraMemoria()
        {
            ReleaseMemoria.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            System.GC.Collect();
        }
        #endregion
        #region ReleaseMemoria: Realizar limpieza de memoria
        /// <summary>
        /// Realizar limpieza de memoria usada por el VistaModelo
        /// </summary>
        public class ReleaseMemoria
        {
            [DllImport("kernel32.dll")]
            public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
        }
        #endregion
    }
}
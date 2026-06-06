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
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Win32;
using Sistema.Vista;
using Sistema.Utilidades;
using Datos.Modelos;
using ConsultaExterna.Utilidades;
using ConsultaExterna.VistaModelo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestorReportes.Vista;
using Sistema.Modelo;
using ConsultaExterna.Modelo;
using HistoriasClinicas.Vista;

namespace ConsultaExterna.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VistaConsultaExterna : Window, IAntencionAdmitidos
    {
        #region Variables
        //--------------------------------
        // Vista de menus capas
        private bool glgVistaPropVisible = false;
        private bool glgVistaCapaVisible = false;
        //private bool glgVistaMenuVisible = false;
        //--------------------------------
        private double gduInicioPuntoMouseX;
        private double gduFinalPuntoMouseX;
        private double gduOldPosStkPanelX;
        private double gduNewPosStkPanelX;
        private DispatcherTimer gobTimerCex;
        private DispatcherTimer gobjHoraCex;
        private DoubleAnimationUsingKeyFrames anim;
        //--------------------------------
        public Dictionary<string, string[]> garDiccionario;
        public Dictionary<string, string[]> garDiccionarioAux;
        public Dictionary<string, double> garDiccPosGrupo;
        //--------------------------------
        public IUMetro lobIUMetro;
        public String gcrCodigoModulo;
        public String gcrOpcionFiltro;
        public int lnuContTouchDown = 0;
        public int gnuContTouchMiliseg = 0;
        public bool glgEjecutandoLiveTiles = false;
        public bool glgRefreshVistaTiles = true;
        
        public int gnuContLiveTilesMiliseg = 0;
        Aplicacion oApp = Aplicacion.Instancia();
        //--------------------------------
        public String gcrNumeroAdmision = String.Empty;
        public String gcrNumeroEgreso   = String.Empty;
        public String gcrCodigoRegCita  = String.Empty;
        public String gcrIdUnicoUsuario = String.Empty;
        public String gcrIdAutorizEgreso= String.Empty;
        public ModeloAtencionAmbulatoria TmpG1RegActivo;
        //--------------------------------
        //- Para el filtro de la vista
        public String gcrVistaTipoRegistros     = "ADM";
        public String gcrVistaEstadoRegistro    = String.Empty;
        public String gcrVistaAgrupar           = String.Empty;
        public String gcrValorFiltro            = String.Empty;
        public String gcrCampoVista             = String.Empty;
        public String gcrCodProfesionalActivo   = String.Empty;
        public String gcrNomProfesionalActivo   = String.Empty;
        public DateTime gdaFiltroFechaActiva    = Funciones.FdaFechaActual();
        public bool llgObjetosCargados          = false;
        #endregion
        //--------------------------------
        #region Parametros
        public String gcrNumeroIdentifi = String.Empty;
        public String gcrNumeroHClinica = String.Empty;
        public bool   glgExisteHclinica = false;
        #endregion
        //--------------------------------
        // Constructor de la clase 
        //--------------------------------
        public VistaConsultaExterna(String tcrTituloVentana)
        {
            InitializeComponent();

            #region Inicio 
            Aplicacion oApp = Aplicacion.Instancia();
            TextTitulo.Text = tcrTituloVentana;

            //- Datos del Profesional activo que presta servicios medicos
            var lobRegProfActivo = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario);
            if (!String.IsNullOrWhiteSpace(lobRegProfActivo.sia_codpfa_prof))
            {
                gcrCodProfesionalActivo = lobRegProfActivo.sia_codpfa_prof.Trim();
                gcrNomProfesionalActivo = lobRegProfActivo.sia_nompro_prof.Trim();
                TextTitulo.Text = tcrTituloVentana + ": " + gcrNomProfesionalActivo;
            }
            //----------
            gcrVistaAgrupar = "CP"; // Agrupar por Centro de produccion
            gcrCampoVista   = "AR"; // Mostrar campo areas de servicios
            gcrOpcionFiltro = "TODOS";
            //----------
            fcTimer();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            fcvResizePantalla();
            fcvBuscarTodosPorFecha(gdaFiltroFechaActiva);
            this.txtFechaActiva.Text = Funciones.fcrConvertFecha(gdaFiltroFechaActiva);
            llgObjetosCargados = true;
            gcrOpcionFiltro = "TODOS";

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            //this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            #endregion
        }
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
            TextBox lobTexto = (TextBox)sender;
            // Buscar por Titulo Columna 3
            if (lobTexto.Text.Trim().Length == 1)
            {
                IUMetro.fcvIrTopVistaGrupo(ref MetroStackPanel, -15);
            }
            IUMetro.fcvFiltrarVistaTiles02(ref garDiccionario, ref lobIUMetro.garRefWPGrupos,
                                           ref lobIUMetro.garRefTiles02, lobTexto.Text.Trim(), "4,5,7,18"); // Se cuenta el orden columna desde 1 (no segun c#)
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
            Tiles02 lobTiles = (Tiles02)sender;

            fcvTilesCargarVista(lobTiles.gcrCodigoItem);
            //----------------------
            lblPaciente.Text = "Admisión: " + gcrNumeroAdmision + " - " + lobTiles.gcrTexto5;
            //----------------------
            lblCodigoAdmision.Text = "Admisión: " + gcrNumeroAdmision;
            lblNombrePaciente.Text = lobTiles.gcrTexto5;

        }
        private void fcvTilesCargarVista(String tcrCodgoAdmision)
        {
            glgRefreshVistaTiles = false;
            EFadmregadmision lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmision(tcrCodgoAdmision);
            gcrOpcionFiltro = "ESTADO";
            //- Datos de la admision
            var lcrAmbitoAtencion   = lobReg.adm_codtat_tatn.Trim();
            gcrNumeroAdmision       = lobReg.adm_secadm_rgad.Trim();
            gcrCodigoRegCita        = lobReg.cit_codasi_mcit.Trim();
            gcrIdUnicoUsuario       = lobReg.sia_idesec_usua.Trim();
            gcrNumeroIdentifi       = lobReg.sia_nroide_usua.Trim();

            gcrNumeroHClinica       = String.Empty;
            gcrNumeroEgreso         = String.Empty;
            gcrIdAutorizEgreso      = String.Empty;
            glgExisteHclinica       = false;
            //-------------------------------------------
            //- Verificar Numero de Egreso
            EFadmregistegreso lobRegEg = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(gcrNumeroAdmision);
            if (lobRegEg != null && lobRegEg.adm_secegr_regr != null)
            {
                gcrNumeroEgreso = lobRegEg.adm_secegr_regr.Trim();
                gcrIdAutorizEgreso = lobRegEg.adm_secaut_aegr.Trim();
            }
            //-------------------------------------------
            // Historia clinica
            var lobRegHc = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIAdm(gcrNumeroAdmision);
            if (lobRegHc != null)
            {
                gcrNumeroHClinica = lobRegHc.hcl_nrohis_hicl.Trim();
                glgExisteHclinica = lobRegHc.sis_estreg_esrg == "2" ? true : false;
            }
            //-------------------------------------------
            // Activar o desactivar botones 
            //-------------------------------------------
            //this.cmdADMFinalizar.IsEnabled = lobReg.adm_ctarip_rgad == "2" && lobReg.adm_estrad_rgad == "1" ? true : false;
            this.cmdADMFinalizar.IsEnabled = lobReg.adm_estrad_rgad == "1" ? true : false;
            this.cmdHCLClinica.IsEnabled = glgExisteHclinica;

            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
            glgRefreshVistaTiles = true;
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
            gduInicioPuntoMouseX = e.GetTouchPoint(MainCanvas).Position.X;
            gduOldPosStkPanelX = Canvas.GetLeft(MetroStackPanel); // inicial - posicion extremo izquierdo del MetroStackPanel dentro del Canvas 
        }
        private void fcvMainCanvas_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            gduFinalPuntoMouseX = e.GetTouchPoint(MainCanvas).Position.X;
            Double lduDiferencia = Math.Abs(gduFinalPuntoMouseX - gduInicioPuntoMouseX);

            // se mueve solo cuando hay una diferencia sustancial
            // no se mueve cuando sea un  double-click.
            if (lduDiferencia > 5)
            {
                if (gduFinalPuntoMouseX < gduInicioPuntoMouseX)
                {
                    gduNewPosStkPanelX = gduOldPosStkPanelX - (lduDiferencia * 2);
                }
                else if (gduFinalPuntoMouseX > gduInicioPuntoMouseX)
                {
                    gduNewPosStkPanelX = gduOldPosStkPanelX + (lduDiferencia * 2);
                }
                lnuContTouchDown = 0;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(gduNewPosStkPanelX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
                gobTimerCex.Start();
            }
        }
        private void MainCanvas_PreviewMouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gduInicioPuntoMouseX = e.GetPosition(MainCanvas).X;
            gduOldPosStkPanelX = Canvas.GetLeft(MetroStackPanel);
        }
        private void MainCanvas_PreviewMouseLeftButtonUp(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gduFinalPuntoMouseX = e.GetPosition(MainCanvas).X;
            Double diff = Math.Abs(gduFinalPuntoMouseX - gduInicioPuntoMouseX);
            // Make sure the diff is substantial so that tiles 
            // don't scroll on double-click.
            if (diff > 5)
            {
                if (gduFinalPuntoMouseX < gduInicioPuntoMouseX)
                {
                    gduNewPosStkPanelX = gduOldPosStkPanelX - (diff * 2);
                }
                else if (gduFinalPuntoMouseX > gduInicioPuntoMouseX)
                {
                    gduNewPosStkPanelX = gduOldPosStkPanelX + (diff * 2);
                }
                lnuContTouchDown = 0;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(gduNewPosStkPanelX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
                gobTimerCex.Start();
            }
        }
        // Check whether the StackPanel is no longer in view and
        // return it to a suitable postion.
        private void timer_Tick(Object sender, EventArgs e)
        {
            Double mspWidth = MetroStackPanel.ActualWidth;

            if (gduNewPosStkPanelX > 200)
            {
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(45, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            else if ((gduNewPosStkPanelX + mspWidth) < 500)
            {
                Double widthX = 500 - (gduNewPosStkPanelX + mspWidth);
                Double shiftX = gduNewPosStkPanelX + widthX;
                anim.KeyFrames.Add(new SplineDoubleKeyFrame(shiftX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                anim.FillBehavior = FillBehavior.HoldEnd;
                MetroStackPanel.BeginAnimation(Canvas.LeftProperty, anim);
                anim.KeyFrames.Clear();
            }
            gobTimerCex.Stop();
        }
        #endregion
        //------------------------------------------------------------
        // Timer gestion del sistema
        //------------------------------------------------------------
        #region fcTimer: gestion timer del sistema
        public void fcTimer()
        {
            txtnick.Text = oApp.gcrUsuNombreUsuario;
            gobTimerCex = new DispatcherTimer();
            gobjHoraCex = new DispatcherTimer();
            gobjHoraCex.Tick += new System.EventHandler(out fcvHoraSistema_Tick);
            gobjHoraCex.Interval = new TimeSpan(0, 0, 0, 0, 200);
            gobjHoraCex.Start();
            anim = new DoubleAnimationUsingKeyFrames();
            anim.Duration = TimeSpan.FromMilliseconds(1800);
            gobTimerCex.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            gobTimerCex.Tick += new System.EventHandler(out timer_Tick);
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
        #region fcvRefreshVistaTiles: Refrescar Tiles de la Vista
        public void fcvRefreshVistaTiles()
        {
            // no hay gestion 
            if (glgRefreshVistaTiles == false) { return; }

            try
            {
                // Ejecutar procesos
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
                            gnuContLiveTilesMiliseg = 0;

                            if (gcrVistaTipoRegistros == "FIL")
                            {
                                garDiccionarioAux = new clTilesConsultaExterna().fcArListaMenuTiles("FIL", gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrCampoVista, gcrValorFiltro);
                                gnuContLiveTilesMiliseg = 0;
                                if (garDiccionario.Count != garDiccionarioAux.Count && garDiccionarioAux.Count != 0)
                                {
                                    fcvCargarIUMetro();
                                }
                            }
                            else
                            {
                                int lnuTotalReg = clTilesConsultaExterna.fnuTotalRegAmbulatoriosFecha(gdaFiltroFechaActiva, gcrCodProfesionalActivo);
                                gnuContLiveTilesMiliseg = 0;
                                if (garDiccionario.Count != lnuTotalReg && lnuTotalReg != 0)
                                {
                                    gcrValorFiltro = clTilesConsultaExterna.fcrListaRegAmbulatoriosFecha(gdaFiltroFechaActiva, gcrCodProfesionalActivo);
                                    gcrVistaEstadoRegistro = String.Empty;
                                    fcvCargarIUMetro();
                                }
                            }
                            gnuContLiveTilesMiliseg = 0;
                            glgEjecutandoLiveTiles = false;
                        }
                    }
                }
                else
                {
                    gnuContLiveTilesMiliseg++;
                    if (llgObjetosCargados == true && gcrOpcionFiltro == "TODOS" && gnuContLiveTilesMiliseg >= 30)
                    {
                        glgRefreshVistaTiles = false;
                        glgEjecutandoLiveTiles = true;
                        gnuContLiveTilesMiliseg = 0;
                        gcrVistaAgrupar = "CP"; // Agrupar por Centro de produccion
                        gcrCampoVista = "AR"; // Mostrar campo areas de servicios

                        fcvBuscarTodosPorFecha(gdaFiltroFechaActiva);
                        glgRefreshVistaTiles = true;
                        gcrOpcionFiltro = "TODOS";
                    }
                    glgEjecutandoLiveTiles = false;
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Error Metodo: fcvRefreshVistaTiles");
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
            gcrValorFiltro = String.Empty;
            gobjHoraCex.Stop();
            gobTimerCex.Stop();
            this.Close();
        }
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
            this.ExtrasGrid.Height = lduHeight;
            this.ExtrasCanvas.Height = lduHeight;
            var lnuStkheight = lduHeight * 0.62;
            this.MetroStackPanel.Height = lnuStkheight;
        }
        #endregion
        //-------------------------------------------------
        // CAPA INFERIOR Configuracion y acciones capa inferior
        //-------------------------------------------------
        #region Configuracion y acciones capa inferior
        //-------------------------------------------------
        #region fcvMostrarMenuContextual: Mostrar menu contextual
        private void fcvMostrarMenuContextual(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        //-------------------------------------------------
        #region  Menu contextual Buscar registros para atencion
        #region fcvBuscarTodosHoy: Buscar todos los pacientes para el dia de hoy
        //- Buscar Turno para el dia de hoy
        private void fcvBuscarTodosHoy(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaMenuInferior(false);
            gcrVistaAgrupar         = "CP"; // Agrupar por Centro de produccion
            gcrCampoVista           = "AR"; // Mostrar campo areas de servicios
            gcrVistaTipoRegistros   = "ADM";
            gcrOpcionFiltro         = "TODOS";
            this.txtFechaActiva.Text = String.Empty;
            this.txtFechaActiva.Text = Funciones.fcrFechaActual();
            //fcvBuscarTodosPorFecha(DateTime.Now);
        }
        private void fcvBuscarTodosPorFecha(DateTime tdaFecha)
        {
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Cargando vista de datos...", "CENTRO");
            lobDlgAdd.Show();

            var ldaFecha = Funciones.FdaFechaActual();
            gcrValorFiltro = clTilesConsultaExterna.fcrListaRegAmbulatoriosFecha(ldaFecha, gcrCodProfesionalActivo);
            gcrVistaEstadoRegistro = String.Empty;

            fcvCargarIUMetro();
            IUMetro.fcvIrTopVistaGrupo(ref MetroStackPanel, -15);

            lobDlgAdd.Close();
        }
        #endregion
        #region fcvBuscarTurnoHoy: Buscar Turno para el dia de hoy
        //- Buscar Turno para el dia de hoy
        private void fcvBuscarTurnoHoy(object sender, RoutedEventArgs e)
        {
            var ldaFecha = DateTime.Parse(DateTime.Now.ToShortDateString());
            gcrValorFiltro = clTilesConsultaExterna.fcrListaTurnosFecha(ldaFecha, gcrCodProfesionalActivo);
            if (!String.IsNullOrWhiteSpace(gcrValorFiltro))
            {
                gcrVistaTipoRegistros = "FIL";
                gcrVistaEstadoRegistro = String.Empty;
                fcvCargarIUMetro();
                IUMetro.fcvIrTopVistaGrupo(ref MetroStackPanel, -15);
            }
        }
        #endregion
        #region Menu contextual Buscar
        //- Buscar turno en la base de datos
        private void fcvBuscarFiltro(object sender, RoutedEventArgs e)
        {
            // Parametros para el filtro
            fcvActivarVistaMenuInferior(false);
            gcrVistaAgrupar     = "TR"; // Agrupar por Turnos de citas
            gcrCampoVista       = "SE"; // Mostrar campo servicios programados
            gcrVistaTipoRegistros = "FIL";
            gcrVistaEstadoRegistro = String.Empty;
            // Ejecutar Filtro
            VistaFiltroturnos frbro = new VistaFiltroturnos(gcrCodProfesionalActivo);
            gcrOpcionFiltro = "FILTRO";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Menu contextual del boton agrupar
        //- Agrupar por Turnos
        private void fcvAgruparPorTurnos(object sender, RoutedEventArgs e)
        {
            gcrVistaAgrupar = "TR";
            gcrCampoVista = gcrCampoVista == "TR" ? "SE" : gcrCampoVista;
            fcvCargarIUMetro();
        }
        //- Agrupar por Profesional
        private void fcvAgruparPorProfesional(object sender, RoutedEventArgs e)
        {
            gcrVistaAgrupar = "PR";
            gcrCampoVista = gcrCampoVista == "PR" ? "SE" : gcrCampoVista;
            fcvCargarIUMetro();
        }
        //- Agrupar por servcio programado (solo para citas)
        private void fcvAgruparPorServicio(object sender, RoutedEventArgs e)
        {
            gcrVistaAgrupar = "SE";
            gcrCampoVista = gcrCampoVista == "SE" ? "PR" : gcrCampoVista;
            fcvCargarIUMetro();
        }
        //- Agrupar por centro de produccion (solo atención ambulatoria no admitido)
        private void fcvAgruparPorCentroProduccion(object sender, RoutedEventArgs e)
        {
            gcrVistaAgrupar = "CP";
            gcrCampoVista = gcrCampoVista == "PR" ? "AR" : gcrCampoVista;
            fcvCargarIUMetro();
        }
        //- Agrupar por Area de Servico
        private void fcvAgruparPorAreaServicio(object sender, RoutedEventArgs e)
        {
            gcrVistaAgrupar = "AR";
            gcrCampoVista = gcrCampoVista == "AR" ? "PR" : gcrCampoVista;
            fcvCargarIUMetro();
        }
        #endregion
        #region Menu contextual del boton Vista campos
        //- Vista Turnos
        private void fcvVistaCampoTurnos(object sender, RoutedEventArgs e)
        {
            gcrCampoVista = "TR";
            fcvCargarIUMetro();
        }
        //- Vista por Servico o programa
        private void fcvVistaCampoServicio(object sender, RoutedEventArgs e)
        {
            gcrCampoVista = "SE";
            fcvCargarIUMetro();
        }
        //- Vista por Centro de produccion
        private void fcvVistaCampoCProduccion(object sender, RoutedEventArgs e)
        {
            gcrCampoVista = "SE";
            fcvCargarIUMetro();
        }
        //- Vista por Profesional
        private void fcvVistaCampoProfesional(object sender, RoutedEventArgs e)
        {
            gcrCampoVista = "PR";
            fcvCargarIUMetro();
        }
        //- Vista por Area de Servico
        private void fcvVistaCampoAreaServicio(object sender, RoutedEventArgs e)
        {
            gcrCampoVista = "AR";
            fcvCargarIUMetro();
        }
        #endregion
        //-------------------------------------------------
        #endregion Fin Configuracion y acciones capa inferior
        //-------------------------------------------------
        // Ejecutar filtros para cambiar vista
        //-------------------------------------------------
        #region Ejecutar filtros para cambiar vista
        public void fcvBuscarRegistro(String tcrCodigo)
        {
            gcrValorFiltro = tcrCodigo; //Lista Seleccion desde Browser filtro en ventana auxiliar
            if (glgVistaPropVisible == true)
            {
                fcvActivarVistaPropiedades();
            }
            switch (gcrOpcionFiltro)
            {
                case "INICIAL": // Toda la vista del maestro admision y tipo con parametros de inicio vista
                    fcvCargarIUMetro();
                    break;

                case "FILTRO": // Toda la vista de admision
                    fcvCargarIUMetro();
                    break;

                case "TURNO": // Un turno o fecha en particular
                    fcvCargarIUMetro();
                    break;

                case "RIPS": // llamado desde la vista completar rips
                    //MessageBox.Show("completar rips " + gcrValorFiltro);
                    fcvActualizIUMetro();
                    break;
            }
        }
        #endregion
        //-------------------------------------------------
        //  Cargar la vista Iu Metro  y actualizar
        //-------------------------------------------------
        #region fcvCargarIUMetro: Cargar la vista Iu Metro
        /// <summary>
        /// Cargar la vista Iu Metro
        /// </summary>
        public void fcvCargarIUMetro()
        {
            // Cargar Vista Tiles
            lobIUMetro = new IUMetro();
            bool llgControl = false;
            int i;
            gcrOpcionFiltro = "CARGANDO"; // para que el contro seleccion fecha no se mueva

            //garDiccionario = new clTilesConsultaExterna().fcArListaMenuTiles(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrCampoVista, gcrValorFiltro);
            garDiccionario = new clTilesConsultaExterna().fcvListaFiltroAmbulatoriosFecha(gdaFiltroFechaActiva, gcrCodProfesionalActivo, gcrVistaAgrupar, gcrCampoVista);

            garDiccPosGrupo = new Dictionary<string, double>();
            lobIUMetro.fcvVistaMetroTiles(ref garDiccionario, ref MetroStackPanel, ref garDiccPosGrupo, "GRUPO", "TILES02", 17, 18); //Lista sin titulos
            //- Enlazar los eventos de Tiles
            for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
            {
                Tiles02 gobjTiles = lobIUMetro.garRefTiles02[i] as Tiles02;
                gobjTiles.MouseDoubleClick += new MouseButtonEventHandler(fcvClickTiles);
                gobjTiles.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);

                // Para que el control de seleccion por fecha funcione bien despues
                if (llgControl == false && gcrVistaTipoRegistros != "ADM")
                {
                    dpkFechaActiva.SelectedDate = DateTime.Now;
                    dpkFechaActiva.SelectedDate = DateTime.Now.AddDays(-1);
                    llgControl = true;
                }
            }
            gcrOpcionFiltro = String.Empty; // Abierto para cualquier otra accion
        }
        #endregion
        #region fcvActualizIUMetro: Actualizar Tiles
        public void fcvActualizIUMetro()
        {
            glgRefreshVistaTiles = false;
            if (glgVistaPropVisible == true)
            {
                fcvActivarVistaPropiedades();
            }
            // Cargar Vista Tiles
            if (glgEjecutandoLiveTiles == false)
            {
                glgEjecutandoLiveTiles = true;
                garDiccionarioAux = new clTilesConsultaExterna().fcArListaMenuTiles("ADM", gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrCampoVista, gcrValorFiltro);
                IUMetro.fcvActualizarTiles02(ref garDiccionario, ref garDiccionarioAux, ref lobIUMetro.garRefTiles02);
                garDiccionario = new clTilesConsultaExterna().fcvActualizDiccTiles02(ref garDiccionario, ref garDiccionarioAux);
                //glgEjecutandoLiveTiles = false;
            }
            glgRefreshVistaTiles = true;
        }
        #endregion
        //-------------------------------------------------
        // Ejecutar Menu Contextual de cortina
        //-------------------------------------------------
        #region Ejecutar Menu Contextual de cortina
        #region cmdHCLClinica -REGHCL- Historia clinica
        private void cmdAperturaHCLClinica_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("ADDHCL");
        }
        #endregion
        #region cmdAMBConsulta -AMBCON- Atención consulta
        private void cmdAMBConsulta_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("AMBCON");
        }
        private void cmdAMBConsulta_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("AMBCON");
        }
        #endregion
        #region cmdAMBFacturacion -AMBFAC- Ambulatoria Facturación
        private void cmdAMBFacturacion_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("AMBFAC");
        }
        private void cmdAMBFacturacion_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("AMBFAC");
        }
        #endregion
        #region cmdAMBRegistroCita -AMBCIT- Ambulatoria Registro Cita
        private void cmdAMBRegistroCita_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("AMBCIT");
        }
        private void cmdAMBRegistroCita_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("AMBCIT");
        }
        #endregion
        #region cmdHCLClinica -REGHCL- Historia clinica
        private void cmdHCLClinica_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("REGHCL");
        }
        private void cmdHCLClinica_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvActivarVistaPropiedades();
            fcvEjecutarVista("REGHCL");
        }
        #endregion
        #region cmdAMBFinalizar -FINCON - Finalizar registro atención consulta
        private void cmdAMBFinalizar_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("FINCON");
        }
        #endregion
        //-------------------------------------------------
        #region Ejecutar acción
        private void fcvEjecutarVista(String tcrOpcion)
        {
            glgRefreshVistaTiles = false;
            //-----------------------------------
            //- Verificar el estado de la admision
            var lcrAccion = "DFL";
            fcvActivarVistaPropiedades(); // ocultar la capa menu propiedades
            fcvActivarVistaMenuInferior(false);

            if (!String.IsNullOrWhiteSpace(gcrNumeroAdmision))
            {
                EFadmregadmision lobAdem = ADMValidarCodigo.fobRegBuscarAdmregadmision(gcrNumeroAdmision);
                if (lobAdem != null && !String.IsNullOrWhiteSpace(lobAdem.adm_secadm_rgad))
                {
                    //if (lobAdem.sis_estpro_espr.Trim() == "1") { lcrAccion = "EDT"; }
                    if (lobAdem.adm_ctarip_rgad.Trim() == "1") { lcrAccion = "EDT"; }
                }
                EFadmordendsalida lobAutegr = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision,"1XX");
                if (lobAutegr != null && !String.IsNullOrWhiteSpace(lobAutegr.adm_secadm_rgad))
                {
                    gcrIdAutorizEgreso = lobAutegr.adm_secaut_aegr.Trim(); 
                }

                switch (tcrOpcion)
                {

                    case "AMBCON": // Atención Ambulatoria consulta
                        gcrOpcionFiltro = "RIPS";
                        VistaAtencionAmbulatoria lobCEXConsultaExterna = new VistaAtencionAmbulatoria(lcrAccion, gcrNumeroAdmision, "", "", "");
                        lobCEXConsultaExterna.Owner = this;
                        lobCEXConsultaExterna.ShowDialog();
                        break;

                    case "AMBFAC": // Atención Ambulatoria Facturación
                        //VistaOrdenesmedicas lobAMOrdenesMedicas = new VistaOrdenesmedicas(lcrAccion, gcrNumeroAdmision, "", "", "");
                        //lobAMOrdenesMedicas.ShowDialog();
                        break;

                    case "AMBCIT": // Atención Ambulatoria Registro Cita
                        MessageBox.Show("Atención Ambulatoria Registro Cita");
                        break;

                    case "REGHCL": // Historia Clinica
                        VistaCapturaReportes lobHCL002 = new VistaCapturaReportes("IG", lobAdem.sia_idesec_usua, gcrNumeroAdmision);
                        lobHCL002.Owner = this; // referencial al formulario
                        lobHCL002.ShowDialog();
                        break;

                    case "FINCON": // Finalizar Registro
                        if (HCLValidarCodigo.flgHclregiseventosAbiertos(gcrNumeroAdmision))
                        {
                            MessageBox.Show("Antes debe diligenciar y confirmar formatos de eventos medicos abiertos.");
                        }
                        else
                        {
                            flgFinalizarAtencion("NA");
                        }
                        break;

                    case "ADDHCL": // Apertura de Historia clinica
                        #region Maestro de Historia Clínicas:
                        lcrAccion = !String.IsNullOrWhiteSpace(gcrNumeroHClinica) ? "DFL" : "ADD";
                        VistaHclmaehistoriasclinicas lobMaestroHClinica = new VistaHclmaehistoriasclinicas(lcrAccion, gcrNumeroHClinica, gcrNumeroIdentifi, "", "");
                        lobMaestroHClinica.ShowDialog();
                        break;
                        #endregion
                }
            }
            // Reactivar Refresh de la vista
            glgRefreshVistaTiles = true;
            glgEjecutandoLiveTiles = false;
            gnuContLiveTilesMiliseg = 40;


        }
        #endregion
        #region flgFinalizarAtencion Finalizar atencion medica
        /// <summary>
        /// Finalizar atencion medica.
        /// </summary>
        public bool flgFinalizarAtencion(String tcrNumeroAdmision)
        {
            var llgReturn = false;
            try
            {
                if (MessageBox.Show("Desea finalizar la atención y confirmar datos?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Guardando datos de la atención médica...", "CENTRO");
                    lobDlgAdd.Show();

                    if (tcrNumeroAdmision != "NA")
                    { 
                        gcrNumeroAdmision = tcrNumeroAdmision;
                        fcvTilesCargarVista(gcrNumeroAdmision);
                    }

                    llgReturn = true;
                    TmpG1RegActivo = ModeloAtencionAmbulatoria.flsListaAdmregadmision(gcrNumeroAdmision).FirstOrDefault();
                    // marcar todos los estados del registro de atencion como cerrados
                    TmpG1RegActivo.Adm_estfac_rgad = "1";
                    TmpG1RegActivo.Adm_estrad_rgad = "2";
                    TmpG1RegActivo.Adm_liqest_rgad = "2";
                    TmpG1RegActivo.Adm_ctarip_rgad = "2";
                    TmpG1RegActivo.Sis_estpro_espr = "2";
                    TmpG1RegActivo.Adm_finate_rgad = "2";
                    TmpG1RegActivo.Sis_despro_espr = "CERRADO";

                    //- Actualizar en maestro y detalles servicios
                    ModeloAtencionAmbulatoria.fcvActualizar(TmpG1RegActivo);
                    // Actaulizar estado registro cita 
                    ModeloCitaAtendida.fcrActualizar(TmpG1RegActivo.Cit_codasi_mcit, "4"); // marcar como atendida por el profesional

                    // actaulizar detalles de facturacion
                    gcrValorFiltro = gcrNumeroAdmision;
                    var TmpG2ListaBrow = ModeloDetServicios.flsListaFcmmaedetallfac(gcrNumeroAdmision);
                    fcvActualizIUMetro();
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloDetServicios lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "M";
                            lobReg.Sis_estpro_espr = "2";
                            // Actualizar en Base de Datos
                            ModeloDetServicios.flgAddRegistro(lobReg, gcrNumeroAdmision);
                        }
                    }
                    ModeloHclvariabactual.fcvEliminarVariablesPublicas(TmpG1RegActivo.Sia_idesec_usua);
                    lobDlgAdd.Close();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FinalizarAtencion");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        //  Actualizar Campo TextBox desde DatePiker
        //-------------------------------------------------
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkFechaActiva":
                        gcrOpcionFiltro = gcrOpcionFiltro != "CARGANDO" ? "TODOS" : gcrOpcionFiltro;
                        this.txtFechaActiva.Text = String.Empty;
                        if (gcrOpcionFiltro != "CARGANDO")
                        {
                            this.txtFechaActiva.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        }
                        //FocusManager.SetFocusedElement(this, this.txtFechaActiva);
                        break;

                    case "dpkxx":
                        // programar aqui
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar DatePiker desde Campo Texto
        //-------------------------------------------------
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    DateTime ldaFecha;
                    TextBox lobTexto = (TextBox)sender;
                    if (DateTime.TryParse(lobTexto.Text, out ldaFecha) && lobTexto.Text.Trim().Length == 10)
                    {
                        switch (lobTexto.Name)
                        {
                            case "txtFechaActiva":
                                if (llgObjetosCargados == true && gcrOpcionFiltro == "TODOS")
                                {
                                    fcvActivarVistaMenuInferior(false);

                                    dpkFechaActiva.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                    gcrVistaAgrupar         = "CP"; // Agrupar por Centro de produccion
                                    gcrCampoVista           = "AR"; // Mostrar campo areas de servicios
                                    gcrVistaTipoRegistros   = "ADM";
                                    gdaFiltroFechaActiva    = Convert.ToDateTime(lobTexto.Text);
                                    fcvBuscarTodosPorFecha(gdaFiltroFechaActiva);
                                }
                                // Actualizar vista desde qui
                                break;

                            case "txtXX":
                                // Programar
                                break;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarDatePicker");
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // ACTIVAR CAPA MENU PROPIEDADES y MENU INFERIOR
        //------------------------------------------------------------
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
        // PROPIEDADES
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades, clic en boton
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #endregion
        #region fcvActivarVistaPropiedadesMouseEnter: Mostrar Ventana Propiedades gesto en la derecha
        /// <summary>
        /// <para>Mostrar Ventana Propiedades con gesto en la derecha de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadesMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedadesTouchEnter: Mostrar Ventana Propiedades gesto en la derecha
        /// <summary>
        /// <para>Mostrar Ventana Propiedades con gesto en la derecha de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadesTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                luxAnimacion.To = -240; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = true;
            }
            else
            {
                luxAnimacion.To = 33; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = false;
            }
            this.ExtrasGrid.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        //  ACTIVAR VISTA CAPA MENU INFERIOR 
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
    }
}
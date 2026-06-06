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
using Inicio.Vista;
using Inicio.VistaModelo;
using Sistema.Vista;
using Sistema.Utilidades;
using Microsoft.Win32;
using Admision.Utilidades;
using Cartera.Utilidades;
using Hospitalizacion.Utilidades;
using CitasMedicas.Utilidades;
using ConfigAsistencial.Utilidades;
using FacturacionMedica.Utilidades;
using ContratoAseguramiento.Utilidades;
using ConsultaExterna.Utilidades;
using SaludPublica.Utilidades;
using GestorReportes.Utilidades;
using HistoriasClinicas.Utilidades;
using Systemas.Utilidades;
using Estadisticas.Utilidades;
using Inventarios.Utilidades;
using Farmacia.Utilidades;
using Meci.Utilidades;

namespace Inicio.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuComponentes : Window
    {
        private double initMouseX;
        private double finalMouseX;
        private double x;
        private double newX;
        private DispatcherTimer timer;
        private DispatcherTimer objHora;
        private DoubleAnimationUsingKeyFrames anim;
        public Dictionary<string, string[]> garDiccionario;
        public Dictionary<string, double> garDiccPosGrupo;
        public IUMetro lobIUMetro;
        public String gcrCodigoModulo;
        public int lnuContTouchDown = 0;
        public int gnuContTouchMiliseg = 0;
        public bool glgCarguevistaInicial = true;

        Aplicacion oApp = Aplicacion.Instancia();
        // Constructor de la clase 
        public MenuComponentes(String tcrModulo, String tcrTituloModulo, String tcrImgIcono, String tcrImgTiles, String tcrRutaImg)
        {
            gcrCodigoModulo = tcrModulo;
            InitializeComponent();

            glgCarguevistaInicial = true; 
            String lcrRutIcon = tcrRutaImg + tcrImgIcono;
            ImgPpal.Source = new BitmapImage(new Uri(lcrRutIcon, UriKind.RelativeOrAbsolute));
            TextTitulo.Text = tcrTituloModulo.Trim();
            fcTimer();
            // Cargar Vista Tiles
            lobIUMetro = new IUMetro();
            int i;
            garDiccionario = new clrutaseiconos().fcArObtenerRutaseIconos(tcrModulo, tcrImgTiles, tcrRutaImg, "FRM", oApp.gcrUsuCodigoPerfil);
            garDiccPosGrupo = new Dictionary<string, double>();

            lobIUMetro.fcvVistaMetroTiles(ref garDiccionario, ref MetroStackPanel, ref garDiccPosGrupo, "LISTA", "TILES01", 0, 0); //Lista sin titulos
            //- Enlazar los eventos de Tiles
            for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
            {
                Tiles01 gobjTiles = lobIUMetro.garRefTiles01[i] as Tiles01;
                gobjTiles.MouseDoubleClick += new MouseButtonEventHandler(fcvClickTiles);
                gobjTiles.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
            }
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            fcvResizePantalla();
        }
        private void MenuComponentes_Loaded(Object sender, System.Windows.RoutedEventArgs e)
        {
            string path = Properties.Settings.Default.SkinPath;
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri(path, UriKind.Relative);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newDictionary);
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
            IUMetro.fcvFiltrarVistaTiles01(ref garDiccionario, ref lobIUMetro.garRefWPGrupos,
                                           ref lobIUMetro.garRefTiles01, lobTexto.Text.Trim(), "3");
        }
        #endregion
        //------------------------------------------------------------
        // Ejecutar Componentes por modulo
        //------------------------------------------------------------
        #region Ejecutar Componentes por modulo
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
            Tiles01 lobTiles = (Tiles01)sender;
            // Buscar el modulo que llama el componente

            // Ejeucutar el componente
            switch (gcrCodigoModulo)
            {
                case "ADM": // Componentes de Admision
                    ADMEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "CAR": // Componentes de Cartera
                    CAREjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "HOS": // Componentes de Hospitalizacion
                    HOSEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "FCM": // Componentes de Facturacion
                    FCMEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "CIT": // Componentes de Hospitalizacion
                    CITEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "SIA": // Configuracion asistencial
                    SIAEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "CTO": // Contratos de Aseguraniento con EPS y aseguradores
                    CTOEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "CEX": // Consulta externa
                    CEXEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "EST": // Estadisticas
                    ESTEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "SSP": // Salud Publica
                    SSPEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "HCL": // Historia clinica
                    HCLEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "INV": // Inventarios
                    INVEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "SYS": // Configuración del Sistema
                    SYSEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

                case "MCI": // MECI
                    MCIEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem);
                    break;

                case "FAR": // Farmacia
                    FAREjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                    break;

            }
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
                if (glgCarguevistaInicial != true)
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
                glgCarguevistaInicial = false;
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
        // Hora del sistema
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
            if (lnuContTouchDown > 0 && gnuContTouchMiliseg < 4)
            {
                gnuContTouchMiliseg++;
            }
            else
            {
                lnuContTouchDown = 0;
                gnuContTouchMiliseg = 0;
            }
        }

        private void MainBgrndRct_MouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
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
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 120;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 120;
            var lnuStkheight = lduHeight * 0.62;
            this.MetroStackPanel.Height = lnuStkheight;
        }
        #endregion
    }
}
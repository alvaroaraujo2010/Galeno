using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using Inicio.VistaModelo;
using Inicio.Vista;
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
using Farmacia.Utilidades;
using Meci.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Servicios;

namespace Inicio.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double initMouseX;
        private double finalMouseX;
        private double x;
        private double newX;
        private DispatcherTimer timer;
        private DispatcherTimer objHora;
        private DoubleAnimationUsingKeyFrames anim;
        // Inistancia de servicios
        Aplicacion oApp = Aplicacion.Instancia();
        AdmServicios ObServicios = AdmServicios.Instancia();
        //Onairis ObOnairis = Onairis.Instancia();

        public Dictionary<string, string[]> garDiccionario;
        public Dictionary<string, double> garDiccPosGrupo;
        public IUMetro lobIUMetro;
        public int lnuContTouchDown = 0;
        public int gnuContTouchMiliseg = 0;
        //public int lnuContNotificaciones = 0;
        public int lnuContReleaseMemoria = 130;
        public bool flgActivateVista = false; // para saber si se minimiza en barra de tarea de windows
        public String gcrOnairisMsjNoficacion = String.Empty;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            //- Iniciar
            InitializeComponent();

            oApp.gtmpSysListNotifiAx = new List<SysAdmGrupoNotifi>();
            lobIUMetro = new IUMetro();
            int i;
            garDiccionario = new clrutaseiconos().fcArObtenerRutaseIconos("", "", "", "MOD", oApp.gcrUsuCodigoPerfil);
            garDiccPosGrupo = new Dictionary<string, double>();

            lobIUMetro.fcvVistaMetroTiles(ref garDiccionario, ref MetroStackPanel, ref garDiccPosGrupo, "GRUPO", "TILES01", 7, 8);
            //- Enlazar los eventos de Tiles
            for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
            {
                Tiles01 gobjTiles = lobIUMetro.garRefTiles01[i] as Tiles01;
                gobjTiles.MouseDoubleClick += new MouseButtonEventHandler(fcvClickTiles);
                gobjTiles.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
            }
            fcTimer();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            fcvResizePantalla();
            Application.Current.Activated += new EventHandler(fcvAppActivated);
            Application.Current.Deactivated += new EventHandler(fcvAppDeactivated);

            ObServicios.Activar();
            //fcvOnairisActivar();
        }
        //------------------------------------------------------------
        // Evento Timer del sistema 
        //------------------------------------------------------------
        #region Timer del sistema
        public void fcTimer()
        {
            txtnick.Text = oApp.gcrUsuNombreUsuario;
            timer = new DispatcherTimer();
            objHora = new DispatcherTimer();
            objHora.Tick += new System.EventHandler(out fcvProcesosSitema_Tick);
            objHora.Interval = new TimeSpan(0, 0, 0, 0, 200);
            objHora.Start();
            anim = new DoubleAnimationUsingKeyFrames();
            anim.Duration = TimeSpan.FromMilliseconds(1800);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += new System.EventHandler(out timer_Tick);

        }
        // Evento Timer del sistema 
        #region fcvProcesosSitema_Tick : eventos del sistema
        void fcvProcesosSitema_Tick(object sender, EventArgs e)
        {
            // Administrador de servicios
            ObServicios.Administrador();
            // Gestion General
            #region Gestion General
            // MOSTRAR HORA DEL SISTEMA
            this.TxtHora.Text = DateTime.Now.ToString("f");

            // Gestion animacion Tiles
            if (lnuContTouchDown > 0 && gnuContTouchMiliseg < 4)
            {
                gnuContTouchMiliseg++;
            }
            else
            {
                lnuContTouchDown = 0;
                gnuContTouchMiliseg = 0;
            }

            // Recolector Basura de memoria
            if (lnuContReleaseMemoria >= 150)
            {
                fcvEjecutarRecolectorBasuraMemoria();
            }
            else
            {
                lnuContReleaseMemoria++;
            }
            if (oApp.glgWiniAplicacionActivar == true || oApp.glgWiniAplicacionDesactivar == true)
            {
                if (oApp.glgWinGestionProcesos == false)
                {
                    oApp.glgWinGestionProcesos = true;
                    var lcrAccion = oApp.glgWiniAplicacionActivar == true ? "MA" : "MI"; // Maximizar/Minimizar

                    oApp.glgWiniAplicacionActivar = false;
                    oApp.glgWiniAplicacionDesactivar = false;

                    Funciones.flgWinAppMaximizarMinimizar(lcrAccion);
                    oApp.glgWinGestionProcesos = false;
                    oApp.glgWiniAplicacionInactiva = lcrAccion == "MA" ? false : true;

                }
            }
            #endregion
        }
        #endregion
        // Movimiento de la vista de baldosas
        #region timer_Tick
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
        #endregion
        //------------------------------------------------------------
        // ACTIVAR O DESACTIVAR LA APLICACION
        //------------------------------------------------------------
        #region fcvAppActivated: Activar la aplicacion
        private void fcvAppActivated(object sender, EventArgs e)
        {
            // Application se activa 
            if (oApp.glgWiniAplicacionInactiva == true)
            {
                // para que se activen las vistas desde el tiemer
                oApp.glgWiniAplicacionInactiva = false;
                oApp.glgWiniAplicacionActivar = true;
            }
        }
        #endregion
        #region fcvAppActivated: Se desactiva la aplicacion
        private void fcvAppDeactivated(object sender, EventArgs e)
        {
            if (oApp.glgWiniAplicacionDesactivar == true || this.WindowState == System.Windows.WindowState.Minimized)
            {
                oApp.glgWiniAplicacionInactiva = true;
            }
        }
        #endregion
        private void MainWindow_Loaded(Object sender, RoutedEventArgs e)
        {
            string path = Properties.Settings.Default.SkinPath;
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri(path, UriKind.Relative);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newDictionary);
        }
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
            fcvCerrarAplicacion();
        }
        private void CloseButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvCerrarAplicacion();

        }
        private void fcvCerrarAplicacion()
        {
            MessageBoxResult result = MessageBox.Show("Salir de la Aplicación?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ObServicios.Finalizar();
                Application.Current.Shutdown();
            }
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
            TextBox lobTexto = (TextBox)sender;
            // Buscar por Titulo Columna 3
            IUMetro.fcvFiltrarVistaTiles01(ref garDiccionario, ref lobIUMetro.garRefWPGrupos,
                                           ref lobIUMetro.garRefTiles01, lobTexto.Text.Trim(), "3");
        }
        #endregion
        //------------------------------------------------------------
        // Ejecutar modulos 
        //------------------------------------------------------------
        #region Ejecutar modulos
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
            Tiles01 lobj = (Tiles01)sender;
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
            oApp.gcrSysActivoIdModulo = lobTiles.gcrCodigoItem;
            ObServicios.lnuTiempoNotificaciones = 11; // para que realice la consulta por Modulo

            if (lobTiles.gcrComponente == "NA")
            {
                MenuComponentes form = new MenuComponentes(lobTiles.gcrCodigoItem, lobTiles.gcrTitulo,
                                                           lobTiles.gcrImgIcono, lobTiles.gcrImgTiles, lobTiles.gcrRutImagen);
                form.Owner = this;
                form.ShowDialog();
            }
            else 
            {
                switch (lobTiles.gcrCodigoItem)
                {
                    case "ADM": // Componentes de Admision
                        ADMEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "CAR": // Componentes Cartera
                        CAREjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "HOS": // Componentes de Hospitalizacion
                        HOSEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "FCM": // Componentes de Facturacion
                        FCMEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "CIT": // Componentes Citas medicas
                        CITEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "SIA": // Configuracion asistencial
                        SIAEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "CTO": // Contratos de Aseguraniento con EPS y aseguradores
                        CTOEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "CEX": // Consulta externa
                        oApp.gcrSysActivoIdModulo = "HOS";
                        CEXEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "EST": // Estadisticas
                        ESTEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                        break;

                    case "SSP": // Salud Publica
                        SSPEjecutar.fcvEjecutarFormularios(lobTiles.gcrComponente, this);
                        break;

                    case "HCL": // Historia clinica
                        HCLEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                        break;

                    case "SYS": // Configuración del Sistema 
                        SYSEjecutar.fcvEjecutarFormularios(lobTiles.gcrCodigoItem, this);
                        break;

                    case "SIS": // Configuración del Sistema tambien se dirige a SYS
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
            flgActivateVista = true;
            oApp.gcrSysActivoIdModulo = String.Empty; // Limpiar par que el recolector carge todo del perfil
        }
        #endregion
        //------------------------------------------------------------
        // Mover Canvas segun Gestos
        //------------------------------------------------------------
        #region Mover Canvas segun Gestos
        private void MainWindow_KeyUp(Object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Movee el MetroStackPanel a un titulo de grupo que 
            // contiene la letra que se pulso
            //String lcrLetra = e.Key.ToString();
            //IUMetro.fcvIrPosVistaGrupo(lcrLetra, ref MetroStackPanel, ref garDiccPosGrupo);
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
        private void MainBgrndRct_MouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
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
            var lnuStkheight = lduHeight * 0.66;
            this.MetroStackPanel.Height = lnuStkheight;
        }
        #endregion
        //------------------------------------------------------------
        // Cambiar Skins
        //------------------------------------------------------------
        #region Cambiar Skins
        private void RedSkinButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeSkin("Skins/RedSkin.xaml");
            SaveSkin("Skins/RedSkin.xaml");
        }

        private void BlueSkinButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeSkin("Skins/BlueSkin.xaml");
            SaveSkin("Skins/BlueSkin.xaml");
        }

        private void GreenSkinButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeSkin("Skins/GreenSkin.xaml");
            SaveSkin("Skins/GreenSkin.xaml");
        }

        private void PurpleSkinButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeSkin("Skins/PurpleSkin.xaml");
            SaveSkin("Skins/PurpleSkin.xaml");
        }
        private void ChangeSkin(String path)
        {
            ResourceDictionary skinRD = new ResourceDictionary();
            skinRD.Source = new Uri(path, UriKind.Relative);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(skinRD);
        }

        private void SaveSkin(String path)
        {
            Properties.Settings.Default.SkinPath = path;
            Properties.Settings.Default.Save();
        }
        #endregion
        //------------------------------------------------------------
        // Mover el stkPanle a  la posicion del grupo
        //------------------------------------------------------------
        private void fcvMoverPosGrupo(object sender, RoutedEventArgs e)
        {
            IUMetro.fcvIrPosVistaGrupo("Adm", ref MetroStackPanel, ref garDiccPosGrupo);
        }
        //------------------------------------------------------------
        // RECOLECTOR DE BASURA EN LA MEMORIA 
        //------------------------------------------------------------
        #region fcvEjecutarRecolectorBasuraMemoria: Recolectar la basura de memoria
        /// <summary>
        /// Recolectar la basura y liberar memoria 
        /// </summary>
        public void fcvEjecutarRecolectorBasuraMemoria()
        {
            ReleaseMemoria.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            lnuContReleaseMemoria = 0;
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
        private void Window_Activated_1(object sender, EventArgs e)
        {
            //MessageBox.Show("se activa la venta");
            if (flgActivateVista == true)
            {
                //flgActivateVista = false;
                //MessageBox.Show("se activa la venta");
            }
        }

    }
}

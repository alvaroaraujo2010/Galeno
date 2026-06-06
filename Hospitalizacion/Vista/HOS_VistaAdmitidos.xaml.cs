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
using Microsoft.Win32;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Utilidades;
using Sistema.Clases;
using Datos.Modelos;
using HistoriasClinicas.Vista;
using Hospitalizacion.Vista;
using Hospitalizacion.Utilidades;
using Hospitalizacion.VistaModelo;
using GestorReportes.Vista;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VistaAdmitidos : Window, IAntencionAdmitidos
    {
        //--------------------------------
        // Vista de menus capas
        #region Vista de menus capas
        private bool glgVistaPropVisible = false;
        //private bool glgVistaMenuVisible = false;
        private double initMouseX;
        private double finalMouseX;
        private double x;
        private double newX;
        private DispatcherTimer timer;
        private DispatcherTimer objHora;
        private DoubleAnimationUsingKeyFrames anim;
        #endregion
        //--------------------------------
        #region Diccionarios
        public Dictionary<string, string[]> garDiccionario;
        public Dictionary<string, string[]> garDiccionarioAux;
        public Dictionary<string, string[]> garDiccionarioAux1; // ------------- ojo quitar
        public Dictionary<string, double> garDiccPosGrupo;
        #endregion
        //--------------------------------
        #region Variables
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
        public bool glgRefreshVistaTiles = true;
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        #endregion
        //--------------------------------
        #region Parametros 
        public String gcrNumeroAdmision = String.Empty;
        public String gcrNumeroEgreso   = String.Empty;
        public String gcrCodigoRegCita  = String.Empty;
        public String gcrNumeroIdentifi = String.Empty;
        public String gcrIdUnicoUsuario = String.Empty;
        public String gcrIdAutorizEgreso = String.Empty;
        public String gcrIdEgresoUrgenci = String.Empty;
        public String gcrIdTrasladUrgHos = String.Empty;
        public String gcrNumeroHClinica = String.Empty;
        public bool glgExisteHclinica   = false;
        public bool glgEsAdmisionUrgenci = false;
        public bool glgPuedeFinalAtencion = false;
        public EFadmregadmision gobRegAdmision = null;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        #endregion
        //--------------------------------
        //- Para el filtro de la vista
        #region Para el filtro de la vista
        public String gcrVistaTipoRegistros = String.Empty;
        public String gcrVistaEstadoRegistro = String.Empty;
        public String gcrVistaAgrupar = String.Empty;
        public String gcrVistaLista = String.Empty;
        #endregion
        //--------------------------------
        // Constructor de la clase 
        //--------------------------------
        /// <summary>
        /// <para>tcrVistaTipoRegistros : "1"=Atencion Admitidos "2"=Atención Ambulatoria, "F"=Cuando es un filtro y lista</para>
        /// <para>tcrVistaEstadoRegistro: "1"=Abierto "2"=Cerrado "3"= Anulado "T" =Todos</para>
        /// <para>tcrVistaAgrupar       : "DX"=Diagnostico,"AR"=Area servicio,"SE"=Seccion hospitalizacion,"PC"=Programa de agenda Cita,
        /// "PR"=Profesional del servicio, "PA" = Filtro Profesional Activo en sistema (usuario activo)</para>
        /// <para>tcrVistaLista         : lista de Codigos registros de atencion separada por coma (,) dada como filtro</para>
        /// </summary>
        public VistaAdmitidos(String tcrVistaTipoRegistros, String tcrVistaEstadoRegistro, String tcrVistaAgrupar,
                              String tcrVistaLista, String tcrTituloVentana, String tcrIconoImagen)
        {
            InitializeComponent();

            //- Titulo e imagen de la ventana
            #region Titulo e imagen de la ventana
            String lcrRutIcon = "/Sistema;component/Imagenes/" + tcrIconoImagen;
            ImgPpal.Source = new BitmapImage(new Uri(lcrRutIcon, UriKind.RelativeOrAbsolute));
            TextTitulo.Text = tcrTituloVentana;
            #endregion
            //--------------------------------
            //- Tomar parametros del contructor
            //--------------------------------
            #region Tomar parametros del contructor
            gcrVistaTipoRegistros = tcrVistaTipoRegistros;
            gcrVistaEstadoRegistro  = tcrVistaEstadoRegistro;
            gcrVistaAgrupar         = tcrVistaAgrupar;
            gcrVistaLista           = tcrVistaLista;
            #endregion
            //--------------------------------
            //- Datos para iniciar
            //--------------------------------
            #region Datos para iniciar
            fcTimer();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            fcvResizePantalla();
            gcrOpcionFiltro = "INICIAL";
            fcvBuscarRegistro(gcrVistaLista);

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

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
            gcrValorFiltro = String.Empty;
            gobRegAdmision = ADMValidarCodigo.fobRegBuscarAdmregadmision(lobTiles.gcrCodigoItem);
            gcrOpcionFiltro = "ESTADO";
            //- Datos de la admision
            #region Datos Basicos
            var lcrOrigenAdmision   = gobRegAdmision.adm_codoad_toad.Trim();
            gcrNumeroAdmision       = gobRegAdmision.adm_secadm_rgad.Trim();
            gcrCodigoRegCita        = gobRegAdmision.cit_codasi_mcit.Trim();
            gcrIdUnicoUsuario       = gobRegAdmision.sia_idesec_usua.Trim();
            gcrNumeroIdentifi       = gobRegAdmision.sia_nroide_usua.Trim();
            // Reiniciar valores
            gcrNumeroHClinica       = String.Empty; 
            gcrNumeroEgreso         = String.Empty;
            gcrIdAutorizEgreso      = String.Empty;
            glgExisteHclinica       = false;
            glgEsAdmisionUrgenci    = lcrOrigenAdmision == "1" ? true : false;
            gcrIdEgresoUrgenci      = String.Empty;
            gcrIdTrasladUrgHos      = String.Empty;
            #endregion
            // ACTIVAR O DESACTIVAR BOTONES 
            fcvValidarParaActivarOpciones();
            //-------------------------------------------
            // DATOS DE LA VISTA PROPIEDADES
            //-------------------------------------------
            #region Datos vista propiedades
            this.lblPaciente.Text = "Admisión: " + gcrNumeroAdmision + " - " + lobTiles.gcrTexto5;
            this.lblCodigoAdmision.Text = "Admisión: " + gcrNumeroAdmision;
            this.lblNombrePaciente.Text = lobTiles.gcrTexto5;

            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
            #endregion

        }
        #endregion
        #region fcvActivarOpciones: Activa o desactiva opciones en capa propiedades
        /// <summary>
        /// <para>asignar valores a variables publicas y activar o desactiva opciones en capa propiedades.</para>
        /// </summary>
        /// <param name="tobRegHClinica">Registro de tipo tabla historial clinico: EFhclmaestrohiscl</param>
        /// <param name="tobRegAsalida">Registro de tipo tabla Autorizacion salida:EFadmordendsalida</param>
        /// <param name="tobRegEgreso">Registro de tipo registros egresos paciente:EFadmregistegreso</param>
        /// <returns>Retorna vacio</returns>
        public void fcvValidarParaActivarOpciones()
        {
            //-------------------------------------------
            //- Verificar Numero de Egreso
            //-------------------------------------------
            #region Validar Datos

            // Historia clinica
            var lobRegHc = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIAdm(gcrNumeroAdmision);
            if (lobRegHc != null)
            {
                gcrNumeroHClinica = lobRegHc.hcl_nrohis_hicl.Trim();
                glgExisteHclinica = lobRegHc.sis_estreg_esrg == "2" ? true : false;
            }
            /*
            EFhclmaestrohiscl lobRegHc = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIG(gcrIdUnicoUsuario);
            if (lobRegHc != null && !String.IsNullOrWhiteSpace(lobRegHc.hcl_nrohis_hicl))
            {
                gcrNumeroHClinica = lobRegHc.hcl_nrohis_hicl.Trim();
                glgExisteHclinica = lobRegHc.sis_estreg_esrg == "2" ? true : false;
            }
            */
            // Autorizar egreso
            EFadmordendsalida lobRegAe = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision, "12X");
            if (lobRegAe != null)
            {
                gcrIdAutorizEgreso = lobRegAe.adm_secaut_aegr.Trim();
            }
            // Registro de egreso
            EFadmregistegreso lobRegEg = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(gcrNumeroAdmision);
            if (lobRegEg != null)
            {
                gcrNumeroEgreso = lobRegEg.adm_secegr_regr.Trim();
            }
            // Registro Traslado desde Urgencias a Hospitalizacion
            EFhosestanciapaci lobRegTrasl = HOSValidarCodigo.fobRegBuscarHosestanciapaciEx("1", gcrNumeroAdmision);
            if (lobRegTrasl != null)
            {
                gcrIdTrasladUrgHos = lobRegTrasl.hos_codesp_espa;
            }
            // Registro egreso urgencias
            EFadmregurgencias lobRegEgrUrg = ADMValidarCodigo.fobRegBuscarAdmregurgenciasAdm(gcrNumeroAdmision);
            if (lobRegEgrUrg != null)
            {
                gcrIdEgresoUrgenci = lobRegEgrUrg.adm_secegr_regu;
            }
            // Permiso para finalizar atencion medica 
            var gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(oApp.gcrUsuCodigoPerfil, "FRM003-CMDFINALIZAR-ADD", "ADD");
            glgPuedeFinalAtencion = gcrSIS_PerfilCmdEDT == "OK" ? true : false;
            #endregion
            //-------------------------------------------
            //- Activar Botones
            //-------------------------------------------
            #region Activar Botones
            this.cmdADMEgreso.IsEnabled = false;
            this.cmdHOSEgresoUrgencia.IsEnabled = false;
            this.cmdHOSTrasladoInterno.IsEnabled = true;
            this.cmdHCLClinica.IsEnabled = glgExisteHclinica;
            this.cmdADMAutorizaEgreso.IsEnabled = glgExisteHclinica;
            this.cmdADMFinalizar.IsEnabled = false;

            // boton de egreso paciente desde hospitalizacion 
            if (!String.IsNullOrWhiteSpace(gcrIdAutorizEgreso))
            {
                if (glgEsAdmisionUrgenci == false || (glgEsAdmisionUrgenci == true && lobRegTrasl != null))
                {
                    this.cmdADMEgreso.IsEnabled = lobRegAe.adm_estreg_aegr == "2" ? true : false;
                }
            }
            //Boton Salida de Urgencias
            if (glgEsAdmisionUrgenci == true)
            {
                if (lobRegTrasl != null || lobRegAe != null)
                {
                    this.cmdHOSEgresoUrgencia.IsEnabled = true;
                    if (lobRegAe != null && lobRegTrasl == null)
                    {
                        this.cmdHOSEgresoUrgencia.IsEnabled = lobRegAe.adm_estreg_aegr == "2" ? true : false;
                    }
                }
            }
            #endregion
            // Traslado cama
            if (!String.IsNullOrWhiteSpace(gcrIdAutorizEgreso))
            {
                //this.cmdHOSTrasladoInterno.IsEnabled = lobRegAe.adm_estreg_aegr == "2" ? false : true;
            }
            // FINALIZAR Atencion accion segun perfil :  FRM003-CMDFINALIZAR-ADD 
            //if (glgPuedeFinalAtencion == true && lobRegAe != null)
            if (glgPuedeFinalAtencion == true)
            {
                this.cmdADMFinalizar.IsEnabled = true;
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
        //-------------------------------------------------
        //  fcvRefreshVistaTiles: Refresh para Live Tiles
        // Se llama desde el timer
        //-------------------------------------------------
        #region fcvRefreshVistaTiles: Rerescar Vista
        public void fcvRefreshVistaTiles()
        {
            // no hay gestion 
            if (glgRefreshVistaTiles == false) { return; }

            if (glgEjecutandoLiveTiles == false && gnuContLiveTilesMiliseg < 10)
            {
                gnuContLiveTilesMiliseg++;
            }
            else
            {

                if (glgEjecutandoLiveTiles == false)
                {
                    glgRefreshVistaTiles = false;
                    glgEjecutandoLiveTiles = true;
                    // Refresh
                    fcvActualizIUMetro();
                    gnuContLiveTilesMiliseg = 0;
                    glgEjecutandoLiveTiles = false;
                    glgRefreshVistaTiles = true;
                }
            }

        }
        #endregion

        //------------------------------------------------------------
        // Cerrar o Minimizar la aplicacion
        //------------------------------------------------------------
        #region Cerrar o Minimizar la aplicacion
        private void MinimizeButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void MinimizeButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            this.WindowState = System.Windows.WindowState.Minimized;
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
            double lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 120;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 120;

            this.GridMenuBottom.Width = lduBarraWidth;
            this.ExtrasGrid.Height = lduHeight;
            this.ExtrasCanvas.Height = (lduHeight);
            var lnuStkheight = lduHeight * 0.62;
            this.MetroStackPanel.Height = lnuStkheight;
        }
        #endregion
        //------------------------------------------------------------
        // ACTIVAR CAPA MENU PROPIEDADES
        //------------------------------------------------------------
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
            //VistaFiltroturnos frbro = new VistaFiltroturnos();
            gcrOpcionFiltro = "FILTRO";
            //frbro.Owner = this;
            //frbro.ShowDialog();
        }
        private void fcvFiltroBuscar_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            //var lcrFiltro = String.Empty;
            //lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            //Browser02 frbro = new Browser02("CIT", "CITMAESTROTURNO", 1, lcrFiltro, "Maestro de turnos por profesional...");
            gcrOpcionFiltro = "TURNO";
            //frbro.Owner = this;
            //frbro.ShowDialog();

        }
        #endregion
        //-------------------------------------------------
        //  llamada desde Browser para un turno en particular
        //-------------------------------------------------
        #region llamada desde Browser para un turno en particular
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            gcrValorFiltro = "";
            var lcrFiltro = String.Empty;
            lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            Browser02 frbro = new Browser02("CIT", "CITMAESTROTURNO", 1, lcrFiltro, "Maestro de turnos por profesional...");
            gcrOpcionFiltro = "TURNO";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        private void fcvBrowserBuscar_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            gcrValorFiltro = "";
            var lcrFiltro = String.Empty;
            lcrFiltro = "sis_estpro_espr='1'"; // solo se mostraran turnos confirmados
            Browser02 frbro = new Browser02("CIT", "CITMAESTROTURNO", 1, lcrFiltro, "Maestro de turnos por profesional...");
            gcrOpcionFiltro = "TURNO";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //-------------------------------------------------
        // fcvBuscarRegistro: Ejecutar filtros para cambiar vista
        //-------------------------------------------------
        #region fcvBuscarRegistro: Ejecutar filtros para cambiar vista
        public void fcvBuscarRegistro(String tcrCodigo)
        {
            gcrListaLiveTiles = "";
            gcrValorFiltro = tcrCodigo; //Lista Seleccion desde Browser filtro en ventana auxiliar
            switch (gcrOpcionFiltro)
            {
                case "INICIAL": // Toda la vista del maestro admision y tipo con parametros de inicio vista
                    fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);
                    break;

                case "FILTRO": // Toda la vista de admision
                    gcrVistaTipoRegistros = "F";
                    gcrVistaEstadoRegistro = "";
                    fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);
                    break;

                case "TURNO": // Un turno o fecha en particular
                    fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);
                    break;

                case "ESTADO": // se cambio estado a un Tiles
                    gcrListaLiveTiles = gcrValorFiltro;
                    break;
            }
        }
        #endregion
        //-------------------------------------------------
        //  Cargar la vista Iu Metro 
        //-------------------------------------------------
        #region Cargar la vista Iu Metro
        /// <summary>
        /// <para>tcrVistaTipoRegistros : "1"=Atencion Admitidos "2"=Atención Ambulatoria, "F"=Cuando es un filtro y lista</para>
        /// <para>tcrVistaEstadoRegistro: "1"=Abierto "2"=Cerrado "3"= Anulado "T" =Todos</para>
        /// <para>tcrVistaAgrupar       : "DX"=Diagnostico,"AR"=Area servicio,"SE"=Seccion hospitalizacion,"PC"=Programación agenda Cita,"PR"=Profesonal del servicio</para>
        /// <para>tcrVistaLista         : lista de Codigos registros de atencion separada por coma (,) dada desde Ventana filtro</para>
        /// </summary>
        public void fcvCargarIUMetro(String tcrVistaTipoRegistros, String tcrVistaEstadoRegistro, String tcrVistaAgrupar, String tcrVistaLista)
        {
            // Cargar Vista Tiles
            try
            {

                lobIUMetro = new IUMetro();
                int i;
                garDiccionario = new clTilesAdmision().fcArListaMenuTiles(tcrVistaTipoRegistros, tcrVistaEstadoRegistro, tcrVistaAgrupar, tcrVistaLista);
                garDiccPosGrupo = new Dictionary<string, double>();
                lobIUMetro.fcvVistaMetroTiles(ref garDiccionario, ref MetroStackPanel, ref garDiccPosGrupo, "GRUPO", "TILES02", 17, 18); //Lista sin titulos
                //- Enlazar los eventos de Tiles
                for (i = 0; i < lobIUMetro.gnuTotalTiles; i++)
                {
                    Tiles02 gobjTiles = lobIUMetro.garRefTiles02[i] as Tiles02;
                    gobjTiles.MouseDoubleClick += new MouseButtonEventHandler(fcvClickTiles);
                    gobjTiles.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Error Metodo: fcvCargarIUMetro");
            }
        }
        #endregion
        //-------------------------------------------------
        //  Actualizar Tiles
        //-------------------------------------------------
        #region Actualizar Tiles
        public void fcvActualizIUMetro()
        {
            // Cargar Vista Tiles
            garDiccionarioAux = new clTilesAdmision().fcArListaMenuTiles(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, "");
            if (garDiccionarioAux.Count != garDiccionario.Count)
            {
                fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);
            }
            else
            {
                IUMetro.fcvActualizarTiles02(ref garDiccionario, ref garDiccionarioAux, ref lobIUMetro.garRefTiles02);
                garDiccionario = new clTilesAdmision().fcvActualizDiccTiles02(ref garDiccionario, ref garDiccionarioAux);
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Ejecutar Menu Contextual de cortina
        //-------------------------------------------------
        #region Ejecutar Menu Contextual de cortina
        //- ADMISION
        #region cmdADMAdmision -REGADM- Registro Admision
        private void cmdADMAdmision_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("REGADM");
        }
        private void cmdADMAdmision_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("REGADM");
        }
        #endregion
        #region cmdHCLClinica -REGHCL- Historia clinica
        private void cmdAperturaHCLClinica_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("ADDHCL");
        }
        #endregion
        #region cmdHCLClinica -REGHCL- Visor Historia clinica
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
            fcvEjecutarVista("REGHCL");
        }
        #endregion
        #region cmdADMOrdenServicios -REGSER- Orden servicios medicos
        private void cmdADMOrdenServicios_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("REGSER");
        }
        #endregion
        #region cmdADMAutorizSalida -REGAUT- Autorizacion de salida
        private void cmdADMAutorizSalida_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("REGAUT");
        }
        private void cmdADMAutorizSalida_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("REGAUT");
        }
        #endregion
        #region cmdHOSEgresoUrgencia -EGRURGEN- egreso desde urgencias
        private void cmdHOSEgresoUrgencia_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("EGRURGEN");
        }
        #endregion
        #region cmdHOSTrasladoInterno -TRASLADO- Traslado interno
        private void cmdHOSTrasladoInterno_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("TRASLADO");
        }
        #endregion
        #region cmdADMEgreso -REGEGR- Registro Egreso
        private void cmdADMEgreso_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("REGEGR");
        }
        private void cmdADMEgreso_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("REGEGR");
        }
        #endregion
        #region cmdADMFinalizar -FINALIZAR - Finalizar atención medica
        private void cmdADMFinalizar_Click(object sender, RoutedEventArgs e)
        {
            fcvEjecutarVista("FINALIZAR");
        }
        private void cmdADMFinalizar_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvEjecutarVista("FINALIZAR");
        }
        #endregion
        //- AMBULATORIA
        #region cmdAMBConsulta -AMBCON- Atención consulta
        private void cmdAMBConsulta_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
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
        private void cmdAMBFacturacion_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
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
        private void cmdAMBRegistroCita_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
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
        //-------------------------------------------------
        #region Ejecutar acción
        private void fcvEjecutarVista(String tcrOpcion)
        {
            glgRefreshVistaTiles = false;
            //-----------------------------------
            //- Verificar el estado de la admision
            var lcrAccion = "DFL";
            fcvActivarVistaPropiedades(); // ocultar la capa

            if (!String.IsNullOrWhiteSpace(gcrNumeroAdmision))
            {
                EFadmregadmision lobAdem = ADMValidarCodigo.fobRegBuscarAdmregadmision(gcrNumeroAdmision);
                if (lobAdem != null && !String.IsNullOrWhiteSpace(lobAdem.adm_secadm_rgad))
                {
                    if (lobAdem.sis_estpro_espr.Trim() == "1") { lcrAccion = "EDT"; }
                }
                // registro autorizacion egreso
                EFadmordendsalida lobAutegr = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision, "12X");
                if (lobAutegr != null && !String.IsNullOrWhiteSpace(lobAutegr.adm_secadm_rgad))
                {
                    gcrIdAutorizEgreso = lobAutegr.adm_secaut_aegr.Trim();
                }

                switch (tcrOpcion)
                {
                    case "REGADM":
                        #region Egreso de pacientes
                        //- Admision de pacientes
                        //VistaAdmadmisiones lobADM001 = new VistaAdmadmisiones("DFL", gcrNumeroAdmision, "", "", "");
                        //lobADM001.ShowDialog();
                        break;
                        #endregion

                    case "REGEGR": // Regitro Egreso
                        #region Egreso de pacientes
                        if (lobAdem.sis_estpro_espr.Trim() == "2")
                        {
                            if (!String.IsNullOrWhiteSpace(gcrIdAutorizEgreso))
                            {
                                lcrAccion = !String.IsNullOrWhiteSpace(gcrNumeroEgreso) ? "DFL" : "ADD";
                                VistaRegistrosalida lobADM002 = new VistaRegistrosalida(lcrAccion, gcrNumeroEgreso, gcrNumeroAdmision, gcrIdAutorizEgreso, "");
                                lobADM002.Owner = this;
                                lobADM002.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No existe autorizacion de egreso para esta admisión");
                            }
                        }
                        else if (lobAdem.sis_estpro_espr.Trim() == "3")
                        {
                            if (!String.IsNullOrWhiteSpace(gcrNumeroEgreso))
                            {
                                lcrAccion = "DFL";
                                VistaRegistrosalida lobADM002 = new VistaRegistrosalida(lcrAccion, gcrNumeroEgreso, gcrNumeroAdmision, "", "");
                                lobADM002.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No se existe registro egreso para admisión anulada");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar egreso para admisión abierta");
                        }
                        break;
                        #endregion

                    case "REGHCL": // Historia Clinica
                        #region Historia Clinica
                        VistaCapturaReportes lobHCL002 = new VistaCapturaReportes("IG", lobAdem.sia_idesec_usua, gcrNumeroAdmision);
                        lobHCL002.Owner = this;
                        lobHCL002.ShowDialog();
                        break;
                        #endregion

                    case "REGAUT": // Autorizacion de salida
                        #region Autorizar Salida
                        if (!flgValidarAutorizarSalida())
                        {
                            fcvVistaLogErrores();
                        }
                        else
                        {
                            if (lobAdem.sis_estpro_espr.Trim() == "2")
                            {
                                lcrAccion = "ADD";
                                if (!String.IsNullOrWhiteSpace(gcrIdAutorizEgreso) && lobAutegr != null)
                                {
                                    lcrAccion = lobAutegr.adm_estreg_aegr == "1" ? "EDT" : "DFL";
                                }
                                VistaAutorizarEgreso lobAutorizarEgreso = new VistaAutorizarEgreso(lcrAccion, gcrIdAutorizEgreso, gcrNumeroAdmision, "", "");
                                lobAutorizarEgreso.ShowDialog();
                            }
                            else if (lobAdem.sis_estpro_espr.Trim() == "3")
                            {
                                if (!String.IsNullOrWhiteSpace(gcrIdAutorizEgreso))
                                {
                                    lcrAccion = "DFL";
                                    VistaAutorizarEgreso lobAutorizarEgreso = new VistaAutorizarEgreso(lcrAccion, gcrIdAutorizEgreso, gcrNumeroAdmision, "", "");
                                    lobAutorizarEgreso.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("No existe registro para admisión anulada");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe confirmar el registro de admisión");
                            }
                        }
                        break;
                        #endregion

                    case "ADDHCL": // Apertura de Historia clinica
                        #region Maestro de Historia Clínicas:
                        lcrAccion = !String.IsNullOrWhiteSpace(gcrNumeroHClinica) ? "DFL" : "ADD";
                        VistaHclmaehistoriasclinicas lobMaestroHClinica = new VistaHclmaehistoriasclinicas(lcrAccion, gcrNumeroHClinica, gcrNumeroIdentifi, "", "");
                        lobMaestroHClinica.ShowDialog();
                        break;
                        #endregion

                    case "AMBCIT":
                        #region Atención Ambulatoria Registro Cita
                        MessageBox.Show("Atención Ambulatoria Registro Cita");
                        break;
                        #endregion

                    case "EGRURGEN": // Egreso desde urgencias
                        #region Historia Clinica
                        lcrAccion = "ADD";
                        var lobReg = ADMValidarCodigo.fobRegBuscarAdmregurgencias(gcrIdEgresoUrgenci);
                        if (lobReg != null)
                        {
                            lcrAccion = lobReg.sis_estpro_espr == "1" ? "EDT" : "DFL";
                        }

                        VistaHosEgresoUrgencias lobEGRURGEN = new VistaHosEgresoUrgencias(lcrAccion, gcrIdEgresoUrgenci, gcrNumeroAdmision, 
                                                                                                gcrIdAutorizEgreso, gcrIdTrasladUrgHos);
                        lobEGRURGEN.Owner = this;
                        lobEGRURGEN.ShowDialog();
                        break;
                        #endregion

                    case "TRASLADO": // Traslado interno
                        #region Registro traslado cama
                        VistaTrasladoCama HOS007 = new VistaTrasladoCama("DFL", gcrNumeroAdmision, "", "", "");
                        HOS007.Owner = this;
                        HOS007.ShowDialog();
                        fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);

                        break;
                        #endregion

                    case "FINALIZAR": // Finalizar atencion medica
                        #region Finalizar atencion medica
                        if (!flgValidarFinalizarAtencion())
                        {
                            fcvVistaLogErrores();
                        }
                        else
                        {
                            // Marcar el registro como finalizado y actualizar vista
                            if (MessageBox.Show("Desea finalizar la atención del paciente", "Confirmación",
                                                 MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                ADMModeloAdmadmisiones.fcvActualizarEstados(gcrNumeroAdmision, "", "2","", "2", "", "2", 0);
                                ModeloHclvariabactual.fcvEliminarVariablesPublicas(lobAdem.sia_idesec_usua);
                                fcvCargarIUMetro(gcrVistaTipoRegistros, gcrVistaEstadoRegistro, gcrVistaAgrupar, gcrValorFiltro);
                            }
                        }
                        break;
                        #endregion
                }
            }
            glgRefreshVistaTiles = true;
            gnuContLiveTilesMiliseg = 30;
            glgEjecutandoLiveTiles = false;
        }
        #endregion
        //-------------------------------------------------
        // Validar Finalizar atencion /Autorizar egreso
        //-------------------------------------------------
        #region flgFinalizarAtencion: Solo para compatibilidad con la Interfas
        /// <summary>
        /// Solo para compatibilidad con la Interfas en gestion finalizar citas ambulatorias
        /// </summary>
        public bool flgFinalizarAtencion(String tcrCodigoAdmision)
        {
            return false;
            // no hay codigo fuente solo es compatibilidad con atencion ambulatoria
        }
        #endregion
        #region flgValidarFinalizarAtencion: Validar Finalizar atencion medica
        /// <summary>
        /// Validar Finalizar atencion medica para quitar el paciente de la vista 
        /// </summary>
        private bool flgValidarFinalizarAtencion()
        {

            String lcrFormatosObigat = String.Empty;
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            int lnuContErrores = 0;
            var llgReturn = false;
            var llgFormatosAbiertos = false;
            tmpLogErrores = new List<LogsErrores>();
            gcrIdTrasladUrgHos = String.Empty;
            gcrIdEgresoUrgenci = String.Empty;

            // Autorizar egreso del paciente
            EFadmordendsalida lobRegAe = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision, "12X");

            // Registro Traslado desde Urgencias a Hospitalizacion
            EFhosestanciapaci lobRegTrasl = HOSValidarCodigo.fobRegBuscarHosestanciapaciEx("1", gcrNumeroAdmision);
            if (lobRegTrasl != null) { gcrIdTrasladUrgHos = lobRegTrasl.hos_codesp_espa; }

            // Egreso de hospitalizacion
            EFadmregistegreso lobRegEg = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(gcrNumeroAdmision);

            // Registro egreso urgencias
            EFadmregurgencias lobRegEgrUrg = ADMValidarCodigo.fobRegBuscarAdmregurgenciasAdm(gcrNumeroAdmision);
            if (lobRegEgrUrg != null) { gcrIdEgresoUrgenci = lobRegEgrUrg.adm_secegr_regu; }

            // Varificar si hay formatos abiertos
            llgFormatosAbiertos = HCLValidarCodigo.flgHclregiseventosAbiertos(gcrNumeroAdmision);

            // Verificar formatos obilgatirios en la atencion 
            lcrFormatosObigat = HCLValidarCodigo.fcrValidFormatoObligdosAdmitidos(gcrNumeroAdmision);
            //-----------------------------------------------------------------------
            // Autorizacion de Egreso hospitalizacion/ Urgencias
            //-----------------------------------------------------------------------
            #region Autorizacion de Egreso hospitalizacion/ Urgencias
            lcrNombreCampo = "Autorización Egreso";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A01";

            if (lobRegAe != null)
            {
                if (lobRegAe.adm_estreg_aegr != "2")
                {
                    lnuContErrores++;
                    lcrValorReturn = "Autorización Egreso debe estar en estado confirmada para finalizar atención medica";
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            else 
            {
                    lnuContErrores++;
                    lcrValorReturn = "No existe Autorización Egreso para este paciente";
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            //-----------------------------------------------------------------------
            // Egreso de hospitalizacion cuando hay traslado desde urgencias
            //-----------------------------------------------------------------------
            #region Egreso de hospitalizacion
            lcrNombreCampo = "Egreso desde Hospitalización";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A02";
            if (!String.IsNullOrWhiteSpace(gcrIdTrasladUrgHos))
            {
                if (lobRegEg == null)
                {
                    lnuContErrores++;
                    lcrValorReturn = "Se debe diligenciar egreso hospitalización para el paciente";
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
                else if (lobRegEg.sis_estpro_espr !="2")
                {
                    lnuContErrores++;
                    lcrValorReturn = "Registro egreso hospitalización debe estar en estado comfirmado";
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            else 
            {
                if (lobRegEg != null)
                {
                    if (lobRegEg.sis_estpro_espr != "2")
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Registro egreso hospitalización debe estar en estado comfirmado";
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                    lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                    }
                }
            }
            #endregion
            //-----------------------------------------------------------------------
            // Estado del cierre de facturación 
            //-----------------------------------------------------------------------
            #region Estado del cierre de facturación
            lcrNombreCampo = "Estado cierre de facturación";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A03";
            lcrNivelError = "BAJO";

            if (gobRegAdmision.adm_estfac_rgad=="1")
            {
                //lnuContErrores++;
                lcrValorReturn = "Falta realizar el cierre de facturación";
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                // Notificar
                fcvSYSGenerarNotificacionEgrFacturacion();
            }
            #endregion
            //-----------------------------------------------------------------------
            // Regsitro egreso de urgencias 
            //-----------------------------------------------------------------------
            #region Regsitro egreso de urgencias
            lcrNombreCampo = "Registro egreso de urgencias";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A04";

            if (gobRegAdmision.adm_codoad_toad == "1" && lobRegEgrUrg == null)
            {
                lnuContErrores++;
                lcrValorReturn = "Se debe diligenciar registro egreso de urgencias";
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            //-----------------------------------------------------------------------
            // Verificar si hay formatos sin diligenciar
            //-----------------------------------------------------------------------
            #region Verificar si hay foramtos sin diligenciar
            lcrNombreCampo = "Formatos sin diligenciar";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A05";

            if (llgFormatosAbiertos == true)
            {
                lnuContErrores++;
                lcrValorReturn = "Se debe diligenciar y confirmar formatos de eventos medicos abiertos.";
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            //-----------------------------------------------------------------------
            // Verificar formatos obligatorios 
            //-----------------------------------------------------------------------
            #region Verificar formatos obligatorios
            lcrNombreCampo = "Formatos obligatorios";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A06";

            if (!String.IsNullOrWhiteSpace(lcrFormatosObigat))
            {
                lnuContErrores++;
                lcrValorReturn = "Se requiere diligenciar y confirmar: " + lcrFormatosObigat;
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            llgReturn = lnuContErrores > 0 ? false : true;
            return llgReturn;
        }
        #endregion
        #region flgValidarAutorizarSalida: Validar autorizar salida del paciente
        /// <summary>
        /// Validar autorizar salida del paciente
        /// </summary>
        private bool flgValidarAutorizarSalida()
        {
            return true;
            /*
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            int lnuContErrores = 0;
            var llgReturn = true;
            tmpLogErrores = new List<LogsErrores>();
            gcrIdTrasladUrgHos = String.Empty;
            gcrIdEgresoUrgenci = String.Empty;

            // Autorizar egreso del paciente
            var lobRegAe = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision, "12X");

            // Registro Traslado desde Urgencias a Hospitalizacion
            var lobRegTrasl = HOSValidarCodigo.fobRegBuscarHosestanciapaciEx("1", gcrNumeroAdmision);
            if (lobRegTrasl != null) { gcrIdTrasladUrgHos = lobRegTrasl.hos_codesp_espa; }

            // Egreso de hospitalizacion
            var lobRegEg = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(gcrNumeroAdmision);

            // Registro egreso urgencias
            var lobRegEgrUrg = ADMValidarCodigo.fobRegBuscarAdmregurgenciasAdm(gcrNumeroAdmision);
            if (lobRegEgrUrg != null) { gcrIdEgresoUrgenci = lobRegEgrUrg.adm_secegr_regu; }

            // Registro de Epicrisis  HCL-CAPTURA-EPIC
            var lobRegEpiCris = HCLValidarCodigo.fobRegBuscarHclregiseventosAdm(gcrNumeroAdmision, "HCL-CAPTURA-EPIC","ASCEN");

            // Registro configuracion Modulo Hospitalizacion
            var lobRegConfig = HOSValidarCodigo.fobRegBuscarHosconfigmodulo("01");
            //-----------------------------------------------------------------------
            // Autorizacion de Egreso hospitalizacion/ Urgencias
            //-----------------------------------------------------------------------
            #region Autorizacion de Egreso hospitalizacion/ Urgencias
            lcrNombreCampo = "Autorización Egreso";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A01";
            if (lobRegAe == null)
            {
                // Egreso de hospitalizacion cuando hay traslado desde urgencias
                #region Egreso de hospitalizacion
                lcrNombreCampo = "Egreso desde Hospitalización";
                lcrValorReturn = String.Empty;
                lcrCodigoError = "A02";
                if (!String.IsNullOrWhiteSpace(gcrIdTrasladUrgHos))
                {
                    if (lobRegEg == null)
                    {
                        lnuContErrores++;
                        lcrValorReturn = "Antes del egreso debe diligenciar Registro Egreso Hospitalización";
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                    lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                    else if (lobRegEg.sis_estpro_espr != "2")
                    {
                        lnuContErrores++;
                        lcrValorReturn = "Registro egreso hospitalización debe estar en estado comfirmado";
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                    lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (lobRegEg != null)
                    {
                        if (lobRegEg.sis_estpro_espr != "2")
                        {
                            lnuContErrores++;
                            lcrValorReturn = "Registro egreso hospitalización debe estar en estado comfirmado";
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                        lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                // Regsitro egreso de urgencias 
                #region Regsitro egreso de urgencias
                lcrNombreCampo = "Registro egreso de urgencias";
                lcrValorReturn = String.Empty;
                lcrCodigoError = "A03";

                if (gobRegAdmision.adm_codoad_toad == "1" && lobRegEgrUrg == null)
                {
                    lnuContErrores++;
                    lcrValorReturn = "Se debe diligenciar registro egreso de urgencias";
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
                #endregion
                llgReturn = lnuContErrores > 0 ? false : true;
            }
            #endregion
            //-----------------------------------------------------------------------
            //- Gestion de la Epicrisis
            //-----------------------------------------------------------------------
            #region Autorizacion de Egreso hospitalizacion/ Urgencias
            lcrNombreCampo = "Gestion de la Epicrisis";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "A04";
            if (lobRegConfig.hos_epicri_hoxx == "1")
            {
                if (lobRegEpiCris == null)
                {
                    lcrValorReturn = "Epiciris es requerida antes de autorizar egreso";
                    lnuContErrores++;
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
                else
                {
                    lcrValorReturn = lobRegEpiCris.sis_estpro_espr == "1" ? "Epiciris debe estar confirmada antes del egreso" : "";
                    lnuContErrores++;
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            #endregion
            return llgReturn;
            */
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        private void fcvVistaLogErrores(object sender, RoutedEventArgs e)
        {
            fcvVistaLogErrores();
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        /// <summary>
        /// Mostrar la vista de errores
        /// </summary>
        public void fcvVistaLogErrores()
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.Close();
                lobDlgLogs = null;
            }
            lobDlgLogs = new DialogVistaErrores();
            lobDlgLogs.fcvCargarVista("Vista errores", tmpLogErrores);
            lobDlgLogs.Show();
            lobDlgLogs.fcvActivarVista();
        }
        private void fcvGotFocus(object sender, EventArgs e)
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.fcvCerrarVista();
            }
        }
        #endregion
        #endregion
        //-----------------------------------------------------------------------
        // Generar notificaciones 
        //-----------------------------------------------------------------------
        #region fcvGenerarNotificacion: Notificacion egreso paciente para informar a facturación
        /// <summary>
        /// <para>Generar registro notificacion egreso para informar a facturación</para>
        /// </summary>
        public void fcvSYSGenerarNotificacionEgrFacturacion()
        {
            try
            {
                // Autorizar egreso en estado confirmado
                EFadmordendsalida lobRegAe = ADMValidarCodigo.fobRegBuscarAdmordendsalidaAd(gcrNumeroAdmision, "2XX");
                if (lobRegAe != null)
                {
                    gcrIdAutorizEgreso = lobRegAe.adm_secaut_aegr.Trim();
                }

                var oApp = Aplicacion.Instancia();
                var lcrTipoIdNotfificacion  = "HOS-AUTORI-SALIDA-F";
                var lcrTipoMensPublico      = "1";  // Publico por defecto
                var lcrIdModuloNotfific     = String.Empty;
                var lcrIdUsuarioRecibe      = String.Empty;
                var lcrIdPerfilRecibe       = String.Empty;

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrTipoIdNotfificacion);
                var lcrIden = "ADMISIÓN: " + gobRegAdmision.adm_secadm_rgad.Trim() + " " + 
                                             gobRegAdmision.sia_tipide_tide.Trim() + " " + gobRegAdmision.sia_nroide_usua.Trim();

                var lcrDesc = this.lblNombrePaciente.Text;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = gcrNumeroAdmision + "*" + gcrIdAutorizEgreso;
                lobjRegistro.Sys_tipmsj_syam = lcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = lcrTipoIdNotfificacion;
                lobjRegistro.Sys_codmsg_symg = lcrIdModuloNotfific;     // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vinfec_syam = lobjRegistro.Sys_sisfec_syam;
                lobjRegistro.Sys_vinhor_syam = lobjRegistro.Sys_sishor_syam;
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual()).AddDays((Double)lobReg.sys_tievig_sytm);
                lobjRegistro.Sys_vfnhor_syam = lobjRegistro.Sys_vinhor_syam;
                lobjRegistro.Sys_vfrfec_syam = Convert.ToDateTime("01/01/1000");
                lobjRegistro.Sys_vfrhor_syam = 0;
                lobjRegistro.Sys_msjvis_syam = "1";

                SysNotificaciones.flgGenerarNotificaciones(lobjRegistro);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvSYSGenerarNotificacion");
            }
        }
        #endregion
        /*
            // Historia clinica
            var lobRegHc =  HCLValidarCodigo.fobRegBuscarHclmaestrohisclIAdm(gcrNumeroAdmision);
            if (lobRegHc != null)
            {
                gcrNumeroHClinica = lobRegHc.hcl_nrohis_hicl.Trim();
                glgExisteHclinica = lobRegHc.sis_estreg_esrg == "2" ? true : false;
            }

        */
    }
}

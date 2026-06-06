//- MARMOTA-GENCODE: VERSION 2.0 - 07/11/2016 10:49:33 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Inventarios.VistaModelo;

namespace Inventarios.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invmaearticulos
    /// </summary>
    public partial class VistaInvmaestroarticulo : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public int gnuContTime = 0;
        public bool llgBrowCumCargados = false;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public bool glgVistPropiedades = false;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        VistaModeloInvmaestroarticulo vm = null;
        DialogVistaErrores lobDlgLogs = null;
        public List<CrtForms.ListaComboBox> lstG1TipoFiltroVista;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaInvmaestroarticulo(String tcrCodigoArticulo)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloInvmaestroarticulo;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            IniciarComboBox();

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            vm.GcrFiltroDatos = tcrCodigoArticulo; // por si el formulario se llama con un filtro activo
            fcvTimerGeneral();
        }
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
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
            if (this.IsLoaded && llgModoEdicion == false)
            {
                if (vm.G1Inv_tipart_inar == "2" && !String.IsNullOrWhiteSpace(vm.G1Inv_lotref_inar))
                { 
                    if (vm.glgPressKeyExpediente == true)
                    {
                        gnuContTime = 0;
                        llgBrowCumCargados = false;
                    }
                    else
                    {
                        gnuContTime++;
                    }
                    vm.glgPressKeyExpediente = false;

                    if (gnuContTime > 4 && llgBrowCumCargados == false)
                    {
                        llgBrowCumCargados = true;
                        vm.FiltroExpedientes();
                    }
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // Cambio de Resolucion de Pantalla y Logs de Errores
        //------------------------------------------------------------
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
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 10;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;

            this.grdPropSelect.Height = lduHeight;

            var myGridLengthConverter = new GridLengthConverter();
            this.grdCol1.Width = (System.Windows.GridLength)myGridLengthConverter.ConvertFromString("200");
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Inv_codaux_inar);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Inv_codaux_inar);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CAN");
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
            lobDlgLogs.fcvCargarVista("Vista errores", vm.tmpLogErrores);
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
        #region  Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    break;

                case "CAN":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    break;
            }

            if (tcrTipoEdicion == "ADD" || tcrTipoEdicion == "EDT")
            {
                FocusManager.SetFocusedElement(this, txtG1Inv_secart_inar);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                grdDetalles.IsEnabled = true;
                cmdAdicionar.Visibility = Visibility.Visible;
                cmdModificar.Visibility = Visibility.Visible;
                cmdGuardar.Visibility = Visibility.Hidden;
                cmdCancelar.Visibility = Visibility.Hidden;
            }

        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            gdspTimerSistema.Stop();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloInvmaestroarticulo();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            #endregion
        }
        #endregion
        //-------------------------------------------------
        //  KeyDown y GotFocus General
        //-------------------------------------------------
        #region KeyDown y GotFocus General
        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }
        #endregion
        #region fcvTouchEnterTeclado: mostrar teclado virtual
        private void fcvTouchEnterTeclado(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                TextBox lobTexto = sender as TextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
            }
        }
        #endregion
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Inv_codgru_ingr":
                    txtG1Inv_codgru_ingr.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codsub_insg":
                    txtG1Inv_codsub_insg.Text = tcrCodigo;
                    break;

                case "txtG1Inv_secimg_inaj":
                    txtG1Inv_secimg_inaj.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_sips":
                    txtG1Fcm_idesec_sips.Text = tcrCodigo;
                    var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(tcrCodigo);
                    if (tmp != null)
                    {
                        this.txtG1Fcm_coddig_mant.Text = tmp.fcm_coddig_mant;
                    }
                    break;

                case "txtG1Far_grufar_fagf":
                    txtG1Far_grufar_fagf.Text = tcrCodigo;
                    break;

                case "txtG1Far_sugfar_fasg":
                    txtG1Far_sugfar_fasg.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codgme_sigr":
                    txtG1Sis_codgme_sigr.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codume_sium":
                    txtG1Sis_codume_sium.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codctn_intc":
                    txtG1Inv_codctn_intc.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codiva_tiva":
                    txtG1Sis_codiva_tiva.Text = tcrCodigo;
                    break;

            }
        }
        // INVMAEARTICULOS : Tabla Maestro Artículos
        #region KeyDown para campos con F2 Tabla: INVMAEARTICULOS
        #region INV_CODGRU_INGR : Grupos  articulos de inventarios
        private void txtG1Inv_codgru_ingr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codgru_ingr_Browser();
            }
        }
        private void cmdG1Inv_codgru_ingr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codgru_ingr_Browser();
        }
        private void txtG1Inv_codgru_ingr_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVINVENTGRUPOS", "", "Grupos  articulos de inventarios...");
            gcrCtrF2TexBox = "txtG1Inv_codgru_ingr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODSUB_INSG : Subgrupos de inventarios
        private void txtG1Inv_codsub_insg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codsub_insg_Browser();
            }
        }
        private void cmdG1Inv_codsub_insg_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codsub_insg_Browser();
        }
        private void txtG1Inv_codsub_insg_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVINVENTSUBGRU", "", "Subgrupos de inventarios...");
            gcrCtrF2TexBox = "txtG1Inv_codsub_insg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_SECIMG_INAJ : Tabla lista de imágenes fotograficas de un articulo
        private void txtG1Inv_secimg_inaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_secimg_inaj_Browser();
            }
        }
        private void cmdG1Inv_secimg_inaj_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_secimg_inaj_Browser();
        }
        private void txtG1Inv_secimg_inaj_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVMAEARTIMAGEN", "", "Tabla lista de imágenes fotograficas de un articulo...");
            gcrCtrF2TexBox = "txtG1Inv_secimg_inaj";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_IDESEC_SIPS : Maestro de servicios habilitados para la IPS
        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_idesec_sips_Browser();
            }
        }
        private void cmdG1Fcm_idesec_sips_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_idesec_sips_Browser();
        }
        private void txtG1Fcm_idesec_sips_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "", "Maestro de servicios habilitados para la IPS...");
            gcrCtrF2TexBox = "txtG1Fcm_idesec_sips";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_GRUFAR_FAGF : Grupo farmacologico del medicamento
        private void txtG1Far_grufar_fagf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_grufar_fagf_Browser();
            }
        }
        private void cmdG1Far_grufar_fagf_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_grufar_fagf_Browser();
        }
        private void txtG1Far_grufar_fagf_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARGRUFARMACOMA", "", "Grupo farmacologico del medicamento...");
            gcrCtrF2TexBox = "txtG1Far_grufar_fagf";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_SUGFAR_FASG : Subgrupo farmacologico del medicamento (detalles)
        private void txtG1Far_sugfar_fasg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_sugfar_fasg_Browser();
            }
        }
        private void cmdG1Far_sugfar_fasg_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_sugfar_fasg_Browser();
        }
        private void txtG1Far_sugfar_fasg_Browser()
        {
            Browser01Ex frbro = new Browser01Ex("FAR", "FARGRUFARMACOMD", "", "Subgrupo farmacologico del medicamento (detalles)...");
            gcrCtrF2TexBox = "txtG1Far_sugfar_fasg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODGME_SIGR : Tabla Grupo de Medidas
        private void txtG1Sis_codgme_sigr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codgme_sigr_Browser();
            }
        }
        private void cmdG1Sis_codgme_sigr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codgme_sigr_Browser();
        }
        private void txtG1Sis_codgme_sigr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISGRUPOMEDIDAS", "", "Tabla Grupo de Medidas...");
            gcrCtrF2TexBox = "txtG1Sis_codgme_sigr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODUME_SIUM : Tabla Unidades de Medidas
        private void txtG1Sis_codume_sium_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codume_sium_Browser();
            }
        }
        private void cmdG1Sis_codume_sium_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codume_sium_Browser();
        }
        private void txtG1Sis_codume_sium_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISUNIDADMEDIDA", "", "Tabla Unidades de Medidas...");
            gcrCtrF2TexBox = "txtG1Sis_codume_sium";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODCTN_INTC : Tabla tipos de contenedores (presentacion articulos)
        private void txtG1Inv_codctn_intc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codctn_intc_Browser();
            }
        }
        private void cmdG1Inv_codctn_intc_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codctn_intc_Browser();
        }
        private void txtG1Inv_codctn_intc_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVCONTENEDORES", "", "Tabla tipos de contenedores (presentacion articulos)...");
            gcrCtrF2TexBox = "txtG1Inv_codctn_intc";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODIVA_TIVA : Tabla de valores para el I.V.A.
        private void txtG1Sis_codiva_tiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codiva_tiva_Browser();
            }
        }
        private void cmdG1Sis_codiva_tiva_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codiva_tiva_Browser();
        }
        private void txtG1Sis_codiva_tiva_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABLAIVA", "", "Tabla de valores para el I.V.A....");
            gcrCtrF2TexBox = "txtG1Sis_codiva_tiva";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Actualizar Objeto TextBox desde CombBox
        //-------------------------------------------------
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                    ComboBox lobCombo = (ComboBox)sender;

                    switch (lobCombo.Name)
                    {
                        case "cboG1Inv_tipart_inar":
                            txtG1Inv_tipart_inar.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Inv_tipart_inar.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Inv_tipart_inar.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Inv_sistok_inar":
                            txtG1Inv_sistok_inar.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Inv_sistok_inar.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Inv_sistok_inar.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Inv_simcrt_inar":
                            txtG1Inv_simcrt_inar.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Inv_simcrt_inar.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Inv_simcrt_inar.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Inv_gesips_inar":
                            txtG1Inv_gesips_inar.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Inv_gesips_inar.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Inv_gesips_inar.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1TipoFiltroVista":

                            this.txtG1TipoFiltroVista.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtG1TipoFiltroVista.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtG1TipoFiltroVista.Text, ",", lobList.ListaValoresSel);
                            vm.gcrFiltroTipoVistaBrowser = this.txtG1TipoFiltroVista.Text;
                            vm.gcrFiltroAplicado = "%&$";

                            break;

                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar ComboBox desde Campo Texto
        //-------------------------------------------------
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Inv_tipart_inar":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Inv_tipart_inar.SelectedItem;
                            cboG1Inv_tipart_inar.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Inv_sistok_inar":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Inv_sistok_inar.SelectedItem;
                            cboG1Inv_sistok_inar.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Inv_simcrt_inar":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Inv_simcrt_inar.SelectedItem;
                            cboG1Inv_simcrt_inar.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Inv_gesips_inar":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Inv_gesips_inar.SelectedItem;
                            cboG1Inv_gesips_inar.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Vista Capa Propiedades al hacer click sobre el Odontograma
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistPropiedades == false)
            {
                luxAnimacion.To = -480; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistPropiedades = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // Tipo Filtro
                //-------------------------------------------------
                #region HCL_APLMED_HCOR: Tipo filtro vista
                string lcrG14Seleccion   = "1,2,3";
                string lcrG14Descripcion = "Articulos y suministros,Medicamentos,Todos";
                lstG1TipoFiltroVista = new List<CrtForms.ListaComboBox>();
                lstG1TipoFiltroVista = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                //- Asignar al control
                this.cboG1TipoFiltroVista.ItemsSource   = lstG1TipoFiltroVista;
                this.cboG1TipoFiltroVista.SelectedIndex = Convert.ToInt32(lstG1TipoFiltroVista[3].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
    }
}
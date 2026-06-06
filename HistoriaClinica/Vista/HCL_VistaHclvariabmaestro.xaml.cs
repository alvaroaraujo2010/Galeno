//- MARMOTA-GENCODE: VERSION 2.0 - 28/06/2016 06:00:41 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using HistoriasClinicas.VistaModelo;

namespace HistoriasClinicas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclvariabmaestr
    /// </summary>
    public partial class VistaHclvariabmaestro : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaPropiedades = false;
        public string gcrCtrF2TexBox;
        VistaModeloHclvariabmaestro vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaHclvariabmaestro()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloHclvariabmaestro;

            vm.G1Hcl_secgru_hcgv = String.Empty;
            vm.G1Hcl_desgru_hcgv = String.Empty;
            vm.gcrFiltroAplicado = "1*#%77";
            vm.GcrFiltroDatos = String.Empty;

            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();


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
            FocusManager.SetFocusedElement(this, txtG1Hcl_titulo_hcvr);
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Hcl_titulo_hcvr);
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
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
        // Cuando se agregan variables a la lista, hay que validar
        private void txtG1Hcl_vresum_hcvr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtG1Hcl_vresum_hcvr.Text))
            {
                vm.glgSIS_ValidacionListaOk = vm.GlgSIS_ModoEdicion == true ? false : true;
            }
            else 
            {
                vm.glgSIS_ValidacionListaOk = true;
            }
        }
        // Ejecutar la validacion de lista de variables
        private void cmdValidLista_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(vm.fcrValidacion("G1Hcl_vresum_hcvrxx")))
            {
                fcvVistaLogErrores();
            }
            else
            {
                vm.glgSIS_ValidacionListaOk = true;
                MessageBox.Show("Validación correcta!!");
            }
        }
        #endregion
        #region Filtrar Vista Seleccion servicios
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            this.txtFiltroDatos.Text = lobTexto.Text;
            //gobObjVModelo.fcvFiltroSelect(lobTexto.Text);
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
                FocusManager.SetFocusedElement(this, txtG1Hcl_nroreg_hcvr);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;

                cmdAdicionarEx.Visibility = Visibility.Hidden;
                cmdModificarEx.Visibility = Visibility.Hidden;
                cmdGuardarEx.Visibility = Visibility.Visible;
                cmdCancelarEx.Visibility = Visibility.Visible;

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

                cmdAdicionarEx.Visibility = Visibility.Visible;
                cmdModificarEx.Visibility = Visibility.Visible;
                cmdGuardarEx.Visibility = Visibility.Hidden;
                cmdCancelarEx.Visibility = Visibility.Hidden;

            }

        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
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
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloHclvariabmaestro();
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
        // Vista Capa Seleccion
        //-------------------------------------------------
        #region Ventana Vista de propiedades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana seleccion obra
        /// <summary>
        /// <para>Mostrar Ventana seleccion obra</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = -610; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Hcl_secgru_hcgv":
                    txtG1Hcl_secgru_hcgv.Text = tcrCodigo;
                    break;

                case "cmdAddVariables":

                    if (!Funciones.flgExisteElemento(tcrCodigo, ";", this.txtG1Hcl_vresum_hcvr.Text))
                    {
                        //var lcrRegVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrCodigo);
                        this.txtG1Hcl_vresum_hcvr.Text = String.IsNullOrWhiteSpace(this.txtG1Hcl_vresum_hcvr.Text) ? tcrCodigo : this.txtG1Hcl_vresum_hcvr.Text + ";" + tcrCodigo;
                    }
                    break;
            }
        }
        // HCLVARIABMAESTR : Maestro Variables publicas de gestion en formatos
        #region KeyDown para campos con F2 Tabla: HCLVARIABMAESTR
        #region HCL_SECGRU_HCGV : Maestro grupos de variables publicas
        private void txtG1Hcl_secgru_hcgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_secgru_hcgv_Browser();
            }
        }
        private void cmdG1Hcl_secgru_hcgv_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_secgru_hcgv_Browser();
        }
        private void txtG1Hcl_secgru_hcgv_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLVARIABGRUPOS", "", "Maestro grupos de variables publicas...");
            gcrCtrF2TexBox = "txtG1Hcl_secgru_hcgv";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region Browser grupos de variables
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_secgru_hcgv_Browser();
        }
        #endregion
        // Browser Variables publicas
        #region fcvSetObjBrowserVariablesPublicas: buscar Variables publicas
        private void fcvSetObjBrowserVariablesPublicas(object sender, RoutedEventArgs e)
        {
            Browser01Ex frbro = new Browser01Ex("HCL", "HCLVARIABMAESTR", "", "Variables Publicas...");
            gcrCtrF2TexBox = "cmdAddVariables";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion

        #endregion
        #endregion
        #region Cargar grupo de variables selecionadas desde el browser
        /// <summary>
        /// <para>Cargar grupo de variables selecionadas desde el browser</para>
        /// </summary>
        private void txtG1Hcl_secgru_hcgv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(this.txtG1Hcl_secgru_hcgv.Text))
                {
                    var tmp = HCLValidarCodigo.fobRegBuscarHclvariabgrupos(this.txtG1Hcl_secgru_hcgv.Text);
                    if (tmp != null)
                    {
                        vm.G1Hcl_desgru_hcgv = tmp.hcl_desgru_hcgv;
                        vm.G1Hcl_nomvar_hcgv = tmp.hcl_nomvar_hcgv;
                        vm.G1Hcl_sisgru_hcgv = tmp.hcl_sisgru_hcgv;
                        vm.G1Sis_dessis_hcgv = tmp.hcl_sisgru_hcgv == "1" ? "PROTEGIDO" : "MODIFICABLE";
                        //vm.G1Fcm_codtar_ttar = tmp.fcm_codtar_ttar;
                        //this.txtG1Fcm_estman_mans.Text = tmp.fcm_estman_mans == "1" ? "ACTIVO" : "INACTIVO";
                        vm.gcrFiltroAplicado = "1*#%77"; // para que se ejecute CanFIL() en vistamodelo base la primera vez para 
                    }
                }
            }
        }
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
                        case "cboG1Hcl_tipval_hcvr":
                            txtG1Hcl_tipval_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tipval_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipval_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_camdig_hcvr":
                            txtG1Hcl_camdig_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_camdig_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_camdig_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_nivvar_hcvr":
                            txtG1Hcl_nivvar_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_nivvar_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_nivvar_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_sistem_hcvr":
                            txtG1Hcl_sistem_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_sistem_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_sistem_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Hcl_modoca_hcvr":
                            txtG1Hcl_modoca_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_modoca_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_modoca_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_resume_hcvr":
                            txtG1Hcl_resume_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_resume_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_resume_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Hcl_siresu_hcvr":
                            txtG1Hcl_siresu_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_siresu_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_siresu_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Hcl_tvigen_hcvr":
                            txtG1Hcl_tvigen_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tvigen_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tvigen_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Hcl_varray_hcvr":
                            txtG1Hcl_varray_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_varray_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_varray_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Hcl_sisvar_hcvr":
                            txtG1Hcl_sisvar_hcvr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_sisvar_hcvr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_sisvar_hcvr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_estreg_esrg":
                            txtG1Sis_estreg_esrg.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_estreg_esrg.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_estreg_esrg.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Hcl_tipval_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipval_hcvr.SelectedItem;
                            cboG1Hcl_tipval_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Hcl_camdig_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Hcl_camdig_hcvr.SelectedItem;
                            cboG1Hcl_camdig_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Hcl_nivvar_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Hcl_nivvar_hcvr.SelectedItem;
                            cboG1Hcl_nivvar_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Hcl_sistem_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Hcl_sistem_hcvr.SelectedItem;
                            cboG1Hcl_sistem_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Hcl_modoca_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Hcl_modoca_hcvr.SelectedItem;
                            cboG1Hcl_modoca_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Hcl_resume_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Hcl_resume_hcvr.SelectedItem;
                            cboG1Hcl_resume_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Hcl_siresu_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Hcl_siresu_hcvr.SelectedItem;
                            cboG1Hcl_siresu_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Hcl_tvigen_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Hcl_tvigen_hcvr.SelectedItem;
                            cboG1Hcl_tvigen_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
                            break;
                        case "txtG1Hcl_varray_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Hcl_varray_hcvr.SelectedItem;
                            cboG1Hcl_varray_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Hcl_sisvar_hcvr":
                            CrtForms.ListaComboBox lobG1ComboBox10 = (CrtForms.ListaComboBox)cboG1Hcl_sisvar_hcvr.SelectedItem;
                            cboG1Hcl_sisvar_hcvr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox10.ListaValoresSel);
                            break;
                        case "txtG1Sis_estreg_esrg":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)cboG1Sis_estreg_esrg.SelectedItem;
                            cboG1Sis_estreg_esrg.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
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
    }
}
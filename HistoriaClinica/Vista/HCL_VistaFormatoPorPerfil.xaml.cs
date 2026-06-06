//- MARMOTA-GENCODE: VERSION 2.0 - 12/12/2017 10:21:54 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using HistoriasClinicas.VistaModelo;
using Microsoft.Win32;
using System.Windows.Media.Animation;



namespace HistoriasClinicas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sysperfiusuario
    /// </summary>
    public partial class VistaFormatoPorPerfil : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public bool glgVistPropiedades = false;
        //Variable para el Filtro
        crtBuscar lobControl = null;


        VistaModeloFormatoPorPerfil vm = null;
        DialogVistaErrores lobDlgLogs = null;

        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaFormatoPorPerfil()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloFormatoPorPerfil;
            vm.G1Sys_codper_perf = String.Empty;
            vm.gcrFiltroAplicado = "1*#%77";
            vm.GcrFiltroDatos = String.Empty;

            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;


            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

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

            //var myGridLengthConverter = new GridLengthConverter();
            //this.grdCol1.Width = (System.Windows.GridLength)myGridLengthConverter.ConvertFromString("200");
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
            FocusManager.SetFocusedElement(this, txtG1Sys_desper_perf);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Hcl_codreg_hcca);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sys_desper_perf);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
            lobControl.txtBuscar.Text = String.Empty;
        }

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("SAVREL");
            FocusManager.SetFocusedElement(this, txtG2Hcl_codreg_hcca);
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CAN");
            lobControl.txtBuscar.Text = String.Empty;


        }

        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("DELREL");
            FocusManager.SetFocusedElement(this, txtG2Hcl_codreg_hcca);
        }

        #endregion
        #region Filtrar Vista Seleccion servicios
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            lobControl = (crtBuscar)sender;
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
                //cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                //cmdAdicionar.Visibility = Visibility.Visible;
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
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloFormatoPorPerfil();
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
                case "txtG1Sys_codper_perf":
                    txtG1Sys_codper_perf.Text = tcrCodigo;
                    break;


                case "txtG2Hcl_codreg_hcca":
                    txtG2Hcl_codreg_hcca.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // SYSPERFIUSUARIO : Maestro perfiles de usuarios
        #region KeyDown para campos con F2 Tabla: SYSPERFIUSUARIO
        #endregion
        // HCLFORMATPERFIL : Acceso a formatos actividades de historia clinica según perf
        #region KeyDown para campos con F2 Tabla: HCLFORMATPERFIL
        #region SYS_CODPER_PERF : Maestro perfiles de usuarios
        private void txtG2Sys_codper_perf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sys_codper_perf_Browser();
            }
        }
        private void cmdG2Sys_codper_perf_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sys_codper_perf_Browser();
        }
        private void txtG2Sys_codper_perf_Browser()
        {
            Browser01 frbro = new Browser01("SYS", "SYSPERFIUSUARIO", "", "Maestro perfiles de usuarios...");
            gcrCtrF2TexBox = "txtG2Sys_codper_perf";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_CODREG_HCCA : Detalles tipo registro de actividad en historial
        private void txtG2Hcl_codreg_hcca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Hcl_codreg_hcca_Browser();
            }
        }
        private void cmdG2Hcl_codreg_hcca_Click(object sender, RoutedEventArgs e)
        {
            txtG2Hcl_codreg_hcca_Browser();
        }
        private void txtG2Hcl_codreg_hcca_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGACTIV", "", "Detalles tipo registro de actividad en historial...");
            gcrCtrF2TexBox = "txtG2Hcl_codreg_hcca";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region fcvBrowserBuscar
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SYS", "SYSPERFIUSUARIO", "", "Maestro perfiles de usuarios...");
            gcrCtrF2TexBox = "txtG1Sys_codper_perf";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Cargar grupo de variables selecionadas desde el browser
        /// <summary>
        /// <para>Cargar grupo de variables selecionadas desde el browser</para>
        /// </summary>
        private void txtG1Sys_codper_perf_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(this.txtG1Sys_codper_perf.Text))
                {
                    var tmp = SYSValidarCodigo.fobRegBuscarSysperfiusuario(this.txtG1Sys_codper_perf.Text);
                    if (tmp != null)
                    {

                        vm.gcrFiltroAplicado = "1*#%77"; // para que se ejecute CanFIL() en vistamodelo base la primera vez para 
                        vm.G1Sys_codper_perf = tmp.sys_codper_perf;

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
                        case "cboG1Sys_estper_perf":
                            txtG1Sys_estper_perf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_estper_perf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_estper_perf.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_accvis_hcpr":
                            txtG2Hcl_accvis_hcpr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_accvis_hcpr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_accvis_hcpr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_accedt_hcpr":
                            txtG2Hcl_accedt_hcpr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_accedt_hcpr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_accedt_hcpr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_accprn_hcpr":
                            txtG2Hcl_accprn_hcpr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_accprn_hcpr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_accprn_hcpr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_accges_hcpr":
                            txtG2Hcl_accges_hcpr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_accges_hcpr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_accges_hcpr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_estfor_hcpr":
                            txtG2Hcl_estfor_hcpr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_estfor_hcpr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_estfor_hcpr.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sys_estper_perf":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sys_estper_perf.SelectedItem;
                            cboG1Sys_estper_perf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Hcl_accvis_hcpr":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Hcl_accvis_hcpr.SelectedItem;
                            cboG2Hcl_accvis_hcpr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Hcl_accedt_hcpr":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Hcl_accedt_hcpr.SelectedItem;
                            cboG2Hcl_accedt_hcpr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Hcl_accprn_hcpr":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Hcl_accprn_hcpr.SelectedItem;
                            cboG2Hcl_accprn_hcpr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
                            break;
                        case "txtG2Hcl_accges_hcpr":
                            CrtForms.ListaComboBox lobG2ComboBox4 = (CrtForms.ListaComboBox)cboG2Hcl_accges_hcpr.SelectedItem;
                            cboG2Hcl_accges_hcpr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox4.ListaValoresSel);
                            break;
                        case "txtG2Hcl_estfor_hcpr":
                            CrtForms.ListaComboBox lobG2ComboBox5 = (CrtForms.ListaComboBox)cboG2Hcl_estfor_hcpr.SelectedItem;
                            cboG2Hcl_estfor_hcpr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox5.ListaValoresSel);
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
        #endregion
    }
}
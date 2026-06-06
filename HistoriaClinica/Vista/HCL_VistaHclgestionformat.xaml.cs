//- MARMOTA-GENCODE: VERSION 2.0 - 15/01/2018 06:29:40 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
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
    /// Descripcion para la Vista de  la tabla: hclformatvistma
    /// </summary>
    public partial class VistaHclgestionformat : Window, SIS_Interface
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

        VistaModeloHclgestionformat vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaHclgestionformat()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloHclgestionformat;
            vm.G1Hcl_codreg_hcra = String.Empty;
            vm.G2Hcl_desreg_hcca = String.Empty;
            vm.gcrFiltroAplicado = "1*#%77";
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
            FocusManager.SetFocusedElement(this, txtG1Hcl_tipvis_hcra);
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
            //FocusManager.SetFocusedElement(this, txtG2Hcl_codreg_hcca);
            //this.txtG2Hcl_codreg_hcca.IsEnabled = false;
            //this.txtG2Hcl_desreg_hcca.IsEnabled = false;
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
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloHclgestionformat();
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
                case "txtG1Hcl_codreg_hcra":
                    txtG1Hcl_codreg_hcra.Text = tcrCodigo;
                    break;

                //case "txtG2Hcl_codreg_hcra":
                //    txtG2Hcl_codreg_hcra.Text = tcrCodigo;
                //    break;

                case "txtG2Grp_idepla_grpl":
                    txtG2Grp_idepla_grpl.Text = tcrCodigo;
                    break;

                case "txtG2Sys_codtip_sytm":
                    txtG2Sys_codtip_sytm.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // HCLFORMATVISTMA : Grupo vista actividades medicas  en captura Historias clinic
        #region KeyDown para campos con F2 Tabla: HCLFORMATVISTMA
        #endregion
        // HCLTIPOREGACTIV : Detalles tipo registro de actividad en historial
        #region KeyDown para campos con F2 Tabla: HCLTIPOREGACTIV
        #region HCL_CODREG_HCRA : Grupo vista actividades medicas  en captura Historias clinic
        private void txtG2Hcl_codreg_hcra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Hcl_codreg_hcra_Browser();
            }
        }
        private void cmdG2Hcl_codreg_hcra_Click(object sender, RoutedEventArgs e)
        {
            txtG2Hcl_codreg_hcra_Browser();
        }
        private void txtG2Hcl_codreg_hcra_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLFORMATVISTMA", "", "Grupo vista actividades medicas  en captura Historias clinic...");
            gcrCtrF2TexBox = "txtG2Hcl_codreg_hcra";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region GRP_IDEPLA_GRPL : Maestro de plantillas
        private void txtG2Grp_idepla_grpl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Grp_idepla_grpl_Browser();
            }
        }
        private void cmdG2Grp_idepla_grpl_Click(object sender, RoutedEventArgs e)
        {
            txtG2Grp_idepla_grpl_Browser();
        }
        private void txtG2Grp_idepla_grpl_Browser()
        {
            Browser01 frbro = new Browser01("GRP", "GRPMAEPLANTILLA", "", "Maestro de plantillas...");
            gcrCtrF2TexBox = "txtG2Grp_idepla_grpl";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODTIP_SYTM : Tipo notificación servicio de mensajes
        private void txtG2Sys_codtip_sytm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sys_codtip_sytm_Browser();
            }
        }
        private void cmdG2Sys_codtip_sytm_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sys_codtip_sytm_Browser();
        }
        private void txtG2Sys_codtip_sytm_Browser()
        {
            Browser01 frbro = new Browser01("SYS", "SYSADMSTIPOMENS", "", "Tipo notificación servicio de mensajes...");
            gcrCtrF2TexBox = "txtG2Sys_codtip_sytm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region fcvBrowserBuscar
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HCL", "HCLFORMATVISTMA", "", "Grupo vista actividades medicas  en captura Historias clinic...");
            gcrCtrF2TexBox = "txtG1Hcl_codreg_hcra";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Cargar grupo de variables selecionadas desde el browser
        /// <summary>
        /// <para>Cargar grupo de variables selecionadas desde el browser</para>
        /// </summary>
        private void txtG1Hcl_codreg_hcra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(this.txtG1Hcl_codreg_hcra.Text))
                {
                    var tmp = HCLValidarCodigo.fobRegBuscarHclformatvistma(this.txtG1Hcl_codreg_hcra.Text);
                    if (tmp != null)
                    {

                        vm.gcrFiltroAplicado = "1*#%77"; // para que se ejecute CanFIL() en vistamodelo base la primera vez para 
                        vm.G1Hcl_codreg_hcra = tmp.hcl_codreg_hcra;

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
                        case "cboG1Hcl_tipvis_hcra":
                            txtG1Hcl_tipvis_hcra.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tipvis_hcra.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipvis_hcra.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_estreg_hcra":
                            txtG1Hcl_estreg_hcra.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_estreg_hcra.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_estreg_hcra.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_psubgr_hcca":
                            txtG2Hcl_psubgr_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_psubgr_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_psubgr_hcca.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_mededi_hcca":
                            txtG2Hcl_mededi_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_mededi_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_mededi_hcca.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_mededf_hcca":
                            txtG2Hcl_mededf_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_mededf_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_mededf_hcca.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_sexapl_hcca":
                            txtG2Hcl_sexapl_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_sexapl_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_sexapl_hcca.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_mededl_hcca":
                            txtG2Hcl_mededl_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_mededl_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_mededl_hcca.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Hcl_estreg_hcca":
                            txtG2Hcl_estreg_hcca.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Hcl_estreg_hcca.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hcl_estreg_hcca.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Hcl_tipvis_hcra":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipvis_hcra.SelectedItem;
                            cboG1Hcl_tipvis_hcra.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Hcl_estreg_hcra":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Hcl_estreg_hcra.SelectedItem;
                            cboG1Hcl_estreg_hcra.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Hcl_psubgr_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Hcl_psubgr_hcca.SelectedItem;
                            cboG2Hcl_psubgr_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Hcl_mededi_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Hcl_mededi_hcca.SelectedItem;
                            cboG2Hcl_mededi_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Hcl_mededf_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Hcl_mededf_hcca.SelectedItem;
                            cboG2Hcl_mededf_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
                            break;
                        case "txtG2Hcl_sexapl_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox4 = (CrtForms.ListaComboBox)cboG2Hcl_sexapl_hcca.SelectedItem;
                            cboG2Hcl_sexapl_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox4.ListaValoresSel);
                            break;
                        case "txtG2Hcl_mededl_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox5 = (CrtForms.ListaComboBox)cboG2Hcl_mededl_hcca.SelectedItem;
                            cboG2Hcl_mededl_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox5.ListaValoresSel);
                            break;
                        case "txtG2Hcl_estreg_hcca":
                            CrtForms.ListaComboBox lobG2ComboBox6 = (CrtForms.ListaComboBox)cboG2Hcl_estreg_hcca.SelectedItem;
                            cboG2Hcl_estreg_hcca.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox6.ListaValoresSel);
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
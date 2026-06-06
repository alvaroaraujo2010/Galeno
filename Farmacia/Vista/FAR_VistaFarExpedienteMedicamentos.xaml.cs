//- MARMOTA-GENCODE: VERSION 2.0 - 14/11/2017 10:56:06 AM
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
using Farmacia.VistaModelo;
using Microsoft.Win32;
using System.Windows.Media.Animation;

namespace Farmacia.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: farexpedmedicma
    /// </summary>
    public partial class VistaFarExpedienteMedicamento : Window, SIS_Interface
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
        VistaModeloFarExpedienteMedicamento vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaFarExpedienteMedicamento()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloFarExpedienteMedicamento;
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

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Far_fecexp_fama.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Far_fecven_fama.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Far_fecact_famd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Far_fecina_famd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
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
            //FocusManager.SetFocusedElement(this, txtG2Far_expedi_fama);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            //FocusManager.SetFocusedElement(this, txtG2Far_expedi_fama);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            //FocusManager.SetFocusedElement(this, txtG2Far_expedi_fama);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
        }

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("SAVREL");
            //FocusManager.SetFocusedElement(this, txtG2Far_expedi_fama);
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CAN");
        }

        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("DELREL");
            //FocusManager.SetFocusedElement(this, txtG2Far_expedi_fama);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloFarExpedienteMedicamento();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            dpkG1Far_fecexp_fama.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Far_fecven_fama.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Far_fecact_famd.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Far_fecina_famd.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                case "txtG1Far_expedi_fama":
                    txtG1Far_expedi_fama.Text = tcrCodigo;
                    break;

                case "txtG1Far_codatc_fatc":
                    txtG1Far_codatc_fatc.Text = tcrCodigo;
                    break;

                case "txtG1Far_grufar_fagf":
                    txtG1Far_grufar_fagf.Text = tcrCodigo;
                    break;

                case "txtG1Far_sugfar_fasg":
                    txtG1Far_sugfar_fasg.Text = tcrCodigo;
                    break;

                case "txtG1Far_unimed_faum":
                    txtG1Far_unimed_faum.Text = tcrCodigo;
                    break;

                case "txtG1Far_viaadm_fava":
                    txtG1Far_viaadm_fava.Text = tcrCodigo;
                    break;

                case "txtG1Far_codlab_falb":
                    txtG1Far_codlab_falb.Text = tcrCodigo;
                    break;

                case "txtG1Far_comerc_falb":
                    txtG1Far_comerc_falb.Text = tcrCodigo;
                    break;

                case "txtG1Far_modcom_famc":
                    txtG1Far_modcom_famc.Text = tcrCodigo;
                    break;

                case "txtG2Far_expedi_fama":
                    txtG2Far_expedi_fama.Text = tcrCodigo;
                    break;

                case "txtG2Far_secimg_faim":
                    txtG2Far_secimg_faim.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // FAREXPEDMEDICMA : Maestro expediente registro medicamentos INVIMA
        #region KeyDown para campos con F2 Tabla: FAREXPEDMEDICMA
        #region FAR_CODATC_FATC : Tabla clasificacion ATC indice de sustancias farmacológicas
        private void txtG1Far_codatc_fatc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_codatc_fatc_Browser();
            }
        }
        private void cmdG1Far_codatc_fatc_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_codatc_fatc_Browser();
        }
        private void txtG1Far_codatc_fatc_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARMAECLASIFATC", "", "Tabla clasificacion ATC indice de sustancias farmacológicas ...");
            gcrCtrF2TexBox = "txtG1Far_codatc_fatc";
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
            Browser01 frbro = new Browser01("FAR", "FARGRUFARMACOMD", "", "Subgrupo farmacologico del medicamento (detalles)...");
            gcrCtrF2TexBox = "txtG1Far_sugfar_fasg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_UNIMED_FAUM : Tabla clasificacion undad medida para medicamentos
        private void txtG1Far_unimed_faum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_unimed_faum_Browser();
            }
        }
        private void cmdG1Far_unimed_faum_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_unimed_faum_Browser();
        }
        private void txtG1Far_unimed_faum_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARUNIDADMEDIDA", "", "Tabla clasificacion undad medida para medicamentos...");
            gcrCtrF2TexBox = "txtG1Far_unimed_faum";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_VIAADM_FAVA : Tabla vias de administracion medicamentos
        private void txtG1Far_viaadm_fava_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_viaadm_fava_Browser();
            }
        }
        private void cmdG1Far_viaadm_fava_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_viaadm_fava_Browser();
        }
        private void txtG1Far_viaadm_fava_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARMEDICAMVIADM", "", "Tabla vias de administracion medicamentos...");
            gcrCtrF2TexBox = "txtG1Far_viaadm_fava";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_CODLAB_FALB : Tabla lista de laboratorios que fabrican o comercializan med
        private void txtG1Far_codlab_falb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_codlab_falb_Browser();
            }
        }
        private void cmdG1Far_codlab_falb_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_codlab_falb_Browser();
        }
        private void txtG1Far_codlab_falb_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARLABORATORIOS", "", "Tabla lista de laboratorios que fabrican o comercializan med...");
            gcrCtrF2TexBox = "txtG1Far_codlab_falb";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_COMERC_FALB : Tabla lista de laboratorios que fabrican o comercializan med
        private void txtG1Far_comerc_falb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_comerc_falb_Browser();
            }
        }
        private void cmdG1Far_comerc_falb_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_comerc_falb_Browser();
        }
        private void txtG1Far_comerc_falb_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARLABORATORIOS", "", "Tabla lista de laboratorios que fabrican o comercializan med...");
            gcrCtrF2TexBox = "txtG1Far_comerc_falb";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_MODCOM_FAMC : Tabla Modalidad de venta comercial
        private void txtG1Far_modcom_famc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Far_modcom_famc_Browser();
            }
        }
        private void cmdG1Far_modcom_famc_Click(object sender, RoutedEventArgs e)
        {
            txtG1Far_modcom_famc_Browser();
        }
        private void txtG1Far_modcom_famc_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARMODALICOMERC", "", "Tabla Modalidad de venta comercial...");
            gcrCtrF2TexBox = "txtG1Far_modcom_famc";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // FAREXPEDMEDICMD : Detalles expediente medicamentos INVIMA según concentracion 
        #region KeyDown para campos con F2 Tabla: FAREXPEDMEDICMD
        #region FAR_EXPEDI_FAMA : Maestro expediente registro medicamentos INVIMA
        private void txtG2Far_expedi_fama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Far_expedi_fama_Browser();
            }
        }
        private void cmdG2Far_expedi_fama_Click(object sender, RoutedEventArgs e)
        {
            txtG2Far_expedi_fama_Browser();
        }
        private void txtG2Far_expedi_fama_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FAREXPEDMEDICMA", "", "Maestro expediente registro medicamentos INVIMA...");
            gcrCtrF2TexBox = "txtG2Far_expedi_fama";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FAR_SECIMG_FAIM : Tabla lista de imágenes fotograficas de medicamentos
        private void txtG2Far_secimg_faim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Far_secimg_faim_Browser();
            }
        }
        private void cmdG2Far_secimg_faim_Click(object sender, RoutedEventArgs e)
        {
            txtG2Far_secimg_faim_Browser();
        }
        private void txtG2Far_secimg_faim_Browser()
        {
            Browser01 frbro = new Browser01("FAR", "FARMEDICAMIMAGE", "", "Tabla lista de imágenes fotograficas de medicamentos...");
            gcrCtrF2TexBox = "txtG2Far_secimg_faim";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("FAR", "FAREXPEDMEDICMA", "", "Maestro expediente registro medicamentos INVIMA...");
            gcrCtrF2TexBox = "txtG1Far_expedi_fama";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                        case "cboG1Far_tiprol_fama":
                            txtG1Far_tiprol_fama.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_tiprol_fama.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_tiprol_fama.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Far_estreg_fama":
                            txtG1Far_estreg_fama.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_estreg_fama.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_estreg_fama.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Far_estreg_famd":
                            txtG2Far_estreg_famd.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Far_estreg_famd.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Far_estreg_famd.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Far_tiprol_fama":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Far_tiprol_fama.SelectedItem;
                            cboG1Far_tiprol_fama.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Far_estreg_fama":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Far_estreg_fama.SelectedItem;
                            cboG1Far_estreg_fama.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Far_estreg_famd":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Far_estreg_famd.SelectedItem;
                            cboG2Far_estreg_famd.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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
                    case "dpkG1Far_fecexp_fama":
                        txtG1Far_fecexp_fama.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Far_fecexp_fama);
                        break;
                    case "dpkG1Far_fecven_fama":
                        txtG1Far_fecven_fama.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Far_fecven_fama);
                        break;
                    case "dpkG2Far_fecact_famd":
                        txtG2Far_fecact_famd.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG2Far_fecact_famd);
                        break;
                    case "dpkG2Far_fecina_famd":
                        txtG2Far_fecina_famd.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG2Far_fecina_famd);
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
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaFecha("DMY", "/", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorFecha("DMY", lnuPosCursor);
                    }
                    if (DateTime.TryParse(lobTexto.Text, out ldaFecha) && lobTexto.Text.Trim().Length == 10)
                    {
                        switch (lobTexto.Name)
                        {
                            case "txtG1Far_fecexp_fama":
                                dpkG1Far_fecexp_fama.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Far_fecven_fama":
                                dpkG1Far_fecven_fama.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG2Far_fecact_famd":
                                dpkG2Far_fecact_famd.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG2Far_fecina_famd":
                                dpkG2Far_fecina_famd.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        //-------------------------------------------------
        // Vista Capa Propiedades al hacer click sobre el Odontograma
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar Ventana detalles Ajuste Inventario</para>
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
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
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
        //--------------------------------------------------
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 17/10/2020 08:35:54 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.VistaModelo;

namespace Sistema.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carfemailgestioma
    /// </summary>
    public partial class VistaGestorCorreos : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloGestorCorreos vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Gestor de correos
        /// </summary>
        /// <param name="tcrOrigenGestion">Origen gestion correo: NA=Llamado desde el modulo gestion correo 
        /// 01=Desde Gestion Cartera (cuenta de cobro) 02=Desde Facturacion Ventas (punto pos) 03=Desde Facturacion Medica</param>
        /// <param name="tcrIdCodigo">Codigo unico del registro a localizar cuando sea requerido</param>
        public VistaGestorCorreos(string tcrOrigenGestion, string tcrIdCodigo)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloGestorCorreos;
            vm.Restaurar();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            vm.GcrUsuIdUsuario = oAppEntorno.gcrUsuIdUsuario;
            vm.GcrUsuCodigoPerfil = oAppEntorno.gcrUsuCodigoPerfil;

            //cmdGuardar.Visibility = Visibility.Hidden;
            //cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            //dpkG1Car_envfec_caml.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Car_subjec_caml);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG1Car_subjec_caml);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Car_subjec_caml);
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
            FocusManager.SetFocusedElement(this, txtG1Car_subjec_caml);
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
            FocusManager.SetFocusedElement(this, txtG1Car_subjec_caml);
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
                //cmdModificar.Visibility = Visibility.Hidden;
                //cmdGuardar.Visibility = Visibility.Visible;
                //cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                //cmdAdicionar.Visibility = Visibility.Visible;
                //cmdModificar.Visibility = Visibility.Visible;
                //cmdGuardar.Visibility = Visibility.Hidden;
                //cmdCancelar.Visibility = Visibility.Hidden;
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

        private void CmdSalir_Click(object sender, RoutedEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloGestorCorreos();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            //dpkG1Car_envfec_caml.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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
                case "txtG1Car_secreg_cagm":
                    txtG1Car_secreg_cagm.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idterc_sitr":
                    txtG1Sis_idterc_sitr.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_secreg_mfac":
                    MessageBox.Show(" aui voy "+ tcrCodigo);
                    // txtG2Fcm_secreg_mfac.Text = tcrCodigo;
                    // llamar al metodo que adiciona al registro detalle
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // CARFEMAILGESTIOMA : Maestro gestor de correos grupales que se envian al adquiren
        #region KeyDown para campos con F2 Tabla: CARFEMAILGESTIOMA
        #region CAR_SECREF_CAGM : Maestro gestor de correos grupales que se envian al adquiren
        private void txtG1Car_secref_cagm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Car_secref_cagm_Browser();
            }
        }
        private void cmdG1Car_secref_cagm_Click(object sender, RoutedEventArgs e)
        {
            txtG1Car_secref_cagm_Browser();
        }
        private void txtG1Car_secref_cagm_Browser()
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG1Car_secref_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_IDTERC_SITR : Tabla terceros para gestion contable
        private void txtG1Sis_idterc_sitr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_idterc_sitr_Browser();
            }
        }
        private void cmdG1Sis_idterc_sitr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_idterc_sitr_Browser();
        }
        private void txtG1Sis_idterc_sitr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS", "", "Tabla terceros para gestion contable...");
            gcrCtrF2TexBox = "txtG1Sis_idterc_sitr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // CARFEMAILGESTIOMF : Referencias a documentos en cuentas de cobro con varias fact
        #region KeyDown para campos con F2 Tabla: CARFEMAILGESTIOMF
        #region CAR_SECREG_CAGM : Maestro gestor de correos grupales que se envian al adquiren
        private void txtG2Car_secreg_cagm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Car_secreg_cagm_Browser();
            }
        }
        private void cmdG2Car_secreg_cagm_Click(object sender, RoutedEventArgs e)
        {
            txtG2Car_secreg_cagm_Browser();
        }
        private void txtG2Car_secreg_cagm_Browser()
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG2Car_secreg_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_SECREG_MFAC : Maestro de facturas electronicas
        private void txtG2Fcm_secreg_mfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Fcm_secreg_mfac_Browser();
            }
        }
        private void cmdG2Fcm_secreg_mfac_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_secreg_mfac_Browser();
        }
        private void txtG2Fcm_secreg_mfac_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESFACTEFMA", "", "Maestro de facturas electronicas...");
            gcrCtrF2TexBox = "txtG2Fcm_secreg_mfac";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG1Car_secreg_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #region Vista Maestro Razon social
        private void CmdG1Car_faddre_caml_Click(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESRAZSOCMA", "", "Maestro Razon social de la empresa...");
            gcrCtrF2TexBox = "txtG2Fcm_secreg_mfac";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        /*
        private void CmdG1Car_faddre_caml_Click(object sender, RoutedEventArgs e)
        {

        }
        */

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
                    /*
                    switch (lobCombo.Name)
                    {
                        case "cboG1Car_gresum_cagm":
                            txtG1Car_gresum_cagm.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_gresum_cagm.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_gresum_cagm.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_gesori_cagm":
                            txtG1Car_gesori_cagm.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_gesori_cagm.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_gesori_cagm.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_tphost_caml":
                            txtG1Car_tphost_caml.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_tphost_caml.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_tphost_caml.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_estenv_caml":
                            txtG1Car_estenv_caml.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_estenv_caml.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_estenv_caml.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_estpro_cagm":
                            txtG1Car_estpro_cagm.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_estpro_cagm.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_estpro_cagm.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Car_estreg_cagf":
                            txtG2Car_estreg_cagf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Car_estreg_cagf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Car_estreg_cagf.Text, ",", lobList.ListaValoresSel);
                            break;
                    }
                    */
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

                    /*
                    switch (lobTexto.Name)
                    {
                        case "txtG1Car_gresum_cagm":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Car_gresum_cagm.SelectedItem;
                            cboG1Car_gresum_cagm.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Car_gesori_cagm":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Car_gesori_cagm.SelectedItem;
                            cboG1Car_gesori_cagm.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Car_tphost_caml":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Car_tphost_caml.SelectedItem;
                            cboG1Car_tphost_caml.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Car_estenv_caml":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Car_estenv_caml.SelectedItem;
                            cboG1Car_estenv_caml.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Car_estpro_cagm":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Car_estpro_cagm.SelectedItem;
                            cboG1Car_estpro_cagm.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG2Car_estreg_cagf":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Car_estreg_cagf.SelectedItem;
                            cboG2Car_estreg_cagf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                    }
                    */
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
                    case "dpkG1Car_envfec_caml":
                        /*
                        txtG1Car_envfec_caml.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Car_envfec_caml);
                        */
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
                            case "txtG1Car_envfec_caml":
                                //dpkG1Car_envfec_caml.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        //Formato para captura de la hora 
        //-------------------------------------------------
        #region Formato para captura de la hora
        private void fcvCapturaHora(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaHora("12", ":", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorHora("12", lnuPosCursor);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora.");
            }
        }
        #endregion

        //-------------------------------------------------
        // Enviar correo 
        //-------------------------------------------------
        #region enviar correo
        /// <summary>
        /// Llamada al proceso que envia el correo 
        /// </summary>
        private void CmdEnviarCorreo_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion enviar correo>
    }
}
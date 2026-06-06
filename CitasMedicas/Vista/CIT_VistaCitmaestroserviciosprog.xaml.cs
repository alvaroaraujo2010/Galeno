//- MARMOTA-GENCODE: VERSION 2.0 - 06/05/2013 08:56:21 PM
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
using CitasMedicas.VistaModelo;

namespace CitasMedicas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citservicioprog
    /// </summary>
    public partial class VistaCitmaestroserviciosprog : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloCitmaestroserviciosprog gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaCitmaestroserviciosprog()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloCitmaestroserviciosprog;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

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
            FocusManager.SetFocusedElement(this, txtG1Cit_desspr_spro);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_idesec_sips);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Cit_desspr_spro);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_idesec_sips);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_idesec_sips);
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
            lobDlgLogs.fcvCargarVista("Vista errores", gobObjVModelo.tmpLogErrores);
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
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                case "txtG1Cit_codspr_spro":
                    txtG1Cit_codspr_spro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codesp_esme":
                    txtG1Sia_codesp_esme.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_sips":
                    txtG1Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG1Adm_codtat_tatn":
                    txtG1Adm_codtat_tatn.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estreg_esrg":
                    txtG1Sis_estreg_esrg.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_idesec_sips":
                    txtG2Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG2Sia_tipact_tsac":
                    txtG2Sia_tipact_tsac.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codcpr_cpro":
                    txtG2Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG2Hcl_codreg_hcca":
                    txtG2Hcl_codreg_hcca.Text = tcrCodigo;
                    break;

                case "txtG2Sis_estreg_esrg":
                    txtG2Sis_estreg_esrg.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // CITSERVICIOPROG : Servicios para programación o citas medicas
        #region KeyDown para campos con F2 Tabla: CITSERVICIOPROG
        #region SIA_CODESP_ESME : Especialidades medicas
        private void txtG1Sia_codesp_esme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codesp_esme_Browser();
            }
        }
        private void cmdG1Sia_codesp_esme_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codesp_esme_Browser();
        }
        private void txtG1Sia_codesp_esme_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAESPECIALIMED", "", "Especialidades medicas...");
            gcrCtrF2TexBox = "txtG1Sia_codesp_esme";
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
        #region ADM_CODTAT_TATN : Ambito de atención paciente
        private void txtG1Adm_codtat_tatn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_codtat_tatn_Browser();
            }
        }
        private void cmdG1Adm_codtat_tatn_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_codtat_tatn_Browser();
        }
        private void txtG1Adm_codtat_tatn_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMTIPOATENCION", "", "Ambito de atención paciente...");
            gcrCtrF2TexBox = "txtG1Adm_codtat_tatn";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG1Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codcpr_cpro_Browser();
            }
        }
        private void cmdG1Fcm_codcpr_cpro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codcpr_cpro_Browser();
        }
        private void txtG1Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "txtG1Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_ESTREG_ESRG : Estados de registros (Activos o Inactivos)
        private void txtG1Sis_estreg_esrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_estreg_esrg_Browser();
            }
        }
        private void cmdG1Sis_estreg_esrg_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_estreg_esrg_Browser();
        }
        private void txtG1Sis_estreg_esrg_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "", "Estados de registros (Activos o Inactivos)...");
            gcrCtrF2TexBox = "txtG1Sis_estreg_esrg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // CITSERVPROTOCOL : Servicios o suministros  de protocolo medico
        #region KeyDown para campos con F2 Tabla: CITSERVPROTOCOL
        #region FCM_IDESEC_SIPS : Maestro de servicios habilitados para la IPS
        private void txtG2Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Fcm_idesec_sips_Browser();
            }
        }
        private void cmdG2Fcm_idesec_sips_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_idesec_sips_Browser();
        }
        private void txtG2Fcm_idesec_sips_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "", "Maestro de servicios habilitados para la IPS...");
            gcrCtrF2TexBox = "txtG2Fcm_idesec_sips";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPACT_TSAC : Tipo de servicio o actividad
        private void txtG2Sia_tipact_tsac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sia_tipact_tsac_Browser();
            }
        }
        private void cmdG2Sia_tipact_tsac_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sia_tipact_tsac_Browser();
        }
        private void txtG2Sia_tipact_tsac_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPACTIVIDAD", "", "Tipo de servicio o actividad...");
            gcrCtrF2TexBox = "txtG2Sia_tipact_tsac";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG2Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Fcm_codcpr_cpro_Browser();
            }
        }
        private void cmdG2Fcm_codcpr_cpro_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_codcpr_cpro_Browser();
        }
        private void txtG2Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "txtG2Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_CODREG_HCCA : Tipo registro de actividad en historial
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
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGACTIV", "", "Tipo registro de actividad en historial...");
            gcrCtrF2TexBox = "txtG2Hcl_codreg_hcca";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_ESTREG_ESRG : Estados de registros (Activos o Inactivos)
        private void txtG2Sis_estreg_esrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_estreg_esrg_Browser();
            }
        }
        private void cmdG2Sis_estreg_esrg_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_estreg_esrg_Browser();
        }
        private void txtG2Sis_estreg_esrg_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "", "Estados de registros (Activos o Inactivos)...");
            gcrCtrF2TexBox = "txtG2Sis_estreg_esrg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("CIT", "CITSERVICIOPROG", "", "Programación actividades o servicios citas medicas...");
            gcrCtrF2TexBox = "txtG1Cit_codspr_spro";
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
                        case "cboG1Cit_indspr_spro":
                            txtG1Cit_indspr_spro.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cit_indspr_spro.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cit_indspr_spro.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_tiprfa_mfac":
                            txtG1Fcm_tiprfa_mfac.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_tiprfa_mfac.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_tiprfa_mfac.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Cit_incrme_sprt":
                            txtG2Cit_incrme_sprt.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Cit_incrme_sprt.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Cit_incrme_sprt.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Cit_incfac_sprt":
                            txtG2Cit_incfac_sprt.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Cit_incfac_sprt.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Cit_incfac_sprt.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Cit_incfrm_sprt":
                            txtG2Cit_incfrm_sprt.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Cit_incfrm_sprt.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Cit_incfrm_sprt.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Cit_indspr_spro":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Cit_indspr_spro.SelectedItem;
                            cboG1Cit_indspr_spro.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Fcm_tiprfa_mfac":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Fcm_tiprfa_mfac.SelectedItem;
                            cboG1Fcm_tiprfa_mfac.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Cit_incrme_sprt":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Cit_incrme_sprt.SelectedItem;
                            cboG2Cit_incrme_sprt.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Cit_incfac_sprt":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Cit_incfac_sprt.SelectedItem;
                            cboG2Cit_incfac_sprt.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Cit_incfrm_sprt":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Cit_incfrm_sprt.SelectedItem;
                            cboG2Cit_incfrm_sprt.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 21/07/2018 02:10:14 PM
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
using Estadisticas.VistaModelo;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: estplangr2193ma
    /// </summary>
    public partial class VistaEstParametros2193 : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloEstParametros2193 vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaEstParametros2193()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloEstParametros2193;
            vm.Restaurar();
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
            FocusManager.SetFocusedElement(this, txtG1Est_codinf_esin);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_codser_sips);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Est_codinf_esin);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_codser_sips);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_codser_sips);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloEstParametros2193();
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
                case "txtG1Est_nroreg_esgr":
                    txtG1Est_nroreg_esgr.Text = tcrCodigo;                   
                    break;

                case "txtG1Est_codinf_esin":
                    txtG1Est_codinf_esin.Text = tcrCodigo;
                    break;

                case "txtG2Est_nroreg_esgr":
                    txtG2Est_nroreg_esgr.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_coddig_mant":
                    txtG2Fcm_coddig_mant.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codrip_trip":
                    txtG2Sia_codrip_trip.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codfpr_fpro":
                    txtG2Sia_codfpr_fpro.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codfco_fcon":
                    txtG2Sia_codfco_fcon.Text = tcrCodigo;
                    break;

                case "txtG2Adm_codcex_tcex":
                    txtG2Adm_codcex_tcex.Text = tcrCodigo;                   
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // ESTPLANGR2193MA : Grupos para plantillas de informes
        #region KeyDown para campos con F2 Tabla: ESTPLANGR2193MA
        #region EST_CODINF_ESIN : Plantills para informes
        private void txtG1Est_codinf_esin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Est_codinf_esin_Browser();
            }
        }
        private void cmdG1Est_codinf_esin_Click(object sender, RoutedEventArgs e)
        {
            txtG1Est_codinf_esin_Browser();
        }
        private void txtG1Est_codinf_esin_Browser()
        {
            Browser01 frbro = new Browser01("EST", "ESTPLANINFORMES", "", "Plantills para informes...");
            gcrCtrF2TexBox = "txtG1Est_codinf_esin";            
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // ESTPLANGR2193MD : Servicios para grupos de registros
        #region KeyDown para campos con F2 Tabla: ESTPLANGR2193MD
        #region EST_NROREG_ESGR : Grupos para plantillas de informes
        private void txtG2Est_nroreg_esgr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Est_nroreg_esgr_Browser();
            }
        }
        private void cmdG2Est_nroreg_esgr_Click(object sender, RoutedEventArgs e)
        {
            txtG2Est_nroreg_esgr_Browser();
        }
        private void txtG2Est_nroreg_esgr_Browser()
        {
            Browser01 frbro = new Browser01("EST", "ESTPLANGR2193MA", "", "Grupos para plantillas de informes...");
            gcrCtrF2TexBox = "txtG2Est_nroreg_esgr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODDIG_MANT : Manual ventas de servicios medicos
        private void txtG2Fcm_coddig_mant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Fcm_coddig_mant_Browser();
            }
        }
        private void cmdG2Fcm_coddig_mant_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_coddig_mant_Browser();
        }
        private void txtG2Fcm_coddig_mant_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPSAUX", "", "Manual ventas de servicios medicos...");
            gcrCtrF2TexBox = "txtG2Fcm_coddig_mant";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODRIP_TRIP : Tabla tipo RIPS
        private void txtG2Sia_codrip_trip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sia_codrip_trip_Browser();
            }
        }
        private void cmdG2Sia_codrip_trip_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sia_codrip_trip_Browser();
        }
        private void txtG2Sia_codrip_trip_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLATPRIPS", "", "Tabla tipo RIPS...");
            gcrCtrF2TexBox = "txtG2Sia_codrip_trip";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODFPR_FPRO : Finalidad del Procedimiento
        private void txtG2Sia_codfpr_fpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sia_codfpr_fpro_Browser();
            }
        }
        private void cmdG2Sia_codfpr_fpro_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sia_codfpr_fpro_Browser();
        }
        private void txtG2Sia_codfpr_fpro_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAFINALIPROCED", "", "Finalidad del Procedimiento...");
            gcrCtrF2TexBox = "txtG2Sia_codfpr_fpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODFCO_FCON : Finalidad de la Consulta
        private void txtG2Sia_codfco_fcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sia_codfco_fcon_Browser();
            }
        }
        private void cmdG2Sia_codfco_fcon_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sia_codfco_fcon_Browser();
        }
        private void txtG2Sia_codfco_fcon_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAFINALICONSUL", "", "Finalidad de la Consulta...");
            gcrCtrF2TexBox = "txtG2Sia_codfco_fcon";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region ADM_CODCEX_TCEX : Causa externa origen de atención
        private void txtG2Adm_codcex_tcex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Adm_codcex_tcex_Browser();
            }
        }
        private void cmdG2Adm_codcex_tcex_Click(object sender, RoutedEventArgs e)
        {
            txtG2Adm_codcex_tcex_Browser();
        }
        private void txtG2Adm_codcex_tcex_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMCAUSAEXTERNA", "", "Causa externa origen de atención...");
            gcrCtrF2TexBox = "txtG2Adm_codcex_tcex";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("EST", "ESTPLANGR2193MA", "", "Grupos para plantillas de informes...");
            gcrCtrF2TexBox = "txtG1Est_nroreg_esgr";            
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
                        case "cboG1Est_estreg_esgr":
                            txtG1Est_estreg_esgr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Est_estreg_esgr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Est_estreg_esgr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_mededi_sips":
                            txtG2Fcm_mededi_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_mededi_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_mededi_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_mededf_sips":
                            txtG2Fcm_mededf_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_mededf_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_mededf_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_sexapl_sips":
                            txtG2Fcm_sexapl_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_sexapl_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_sexapl_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Est_estreg_esgr":
                            txtG2Est_estreg_esgr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Est_estreg_esgr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Est_estreg_esgr.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Est_estreg_esgr":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Est_estreg_esgr.SelectedItem;
                            cboG1Est_estreg_esgr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Fcm_mededi_sips":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Fcm_mededi_sips.SelectedItem;
                            cboG2Fcm_mededi_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Fcm_mededf_sips":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Fcm_mededf_sips.SelectedItem;
                            cboG2Fcm_mededf_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Fcm_sexapl_sips":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Fcm_sexapl_sips.SelectedItem;
                            cboG2Fcm_sexapl_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
                            break;
                        case "txtG2Est_estreg_esgr":
                            CrtForms.ListaComboBox lobG2ComboBox4 = (CrtForms.ListaComboBox)cboG2Est_estreg_esgr.SelectedItem;
                            cboG2Est_estreg_esgr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox4.ListaValoresSel);
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
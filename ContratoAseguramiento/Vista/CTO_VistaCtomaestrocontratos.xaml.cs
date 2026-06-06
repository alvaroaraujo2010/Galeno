//- MARMOTA-GENCODE: VERSION 2.0 - 19/04/2015 08:12:54 AM
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
using ContratoAseguramiento.VistaModelo;

namespace ContratoAseguramiento.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: ctomaescontrato
    /// </summary>
    public partial class VistaCtomaestrocontratos : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloCtomaestrocontratos gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaCtomaestrocontratos()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloCtomaestrocontratos;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Cto_fecico_cont.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cto_fecfco_cont.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
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
            FocusManager.SetFocusedElement(this, txtG1Cto_nrocon_cont);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Cto_nrocon_cont);
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

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, txtG2Fcm_idesec_sips);
        }
        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, txtG2Fcm_idesec_sips);
        }

        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
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
                FocusManager.SetFocusedElement(this, txtG1Cto_seccon_cont);
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
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
            gcrCtrF2TexBox = "txtG1Cto_seccon_cont";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                case "txtG1Fcm_numdoc_fcem":
                    txtG1Fcm_numdoc_fcem.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idterc_sitr":
                    txtG1Sis_idterc_sitr.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codman_mans":
                    txtG1Fcm_codman_mans.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codman_mans":
                    txtG2Fcm_codman_mans.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipusu_regi":
                    txtG1Sia_tipusu_regi.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipase_sita":
                    txtG1Sia_tipase_sita.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codsal_tsal":
                    txtG2Sis_codsal_tsal.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_idesec_sips":
                    txtG2Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_coddig_mant":
                    txtG2Fcm_coddig_mant.Text = tcrCodigo;
                    break;
           }
        }
        // Para seleccion vista 
        #region KeyDown para campos con F2 
        // Razon social 
        #region FCM_SECRAZ_FCEM : Maestro Razon social de la empresa
        private void TxtG1Fcm_numdoc_fcem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtG1Fcm_numdoc_fcem_Browser();
            }
        }
        private void CmdG1Fcm_numdoc_fcem_Click(object sender, RoutedEventArgs e)
        {
            TxtG1Fcm_numdoc_fcem_Browser();
        }
        private void TxtG1Fcm_numdoc_fcem_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESRAZSOCMA-NIT", "", "Maestro Razon social de la empresa...");
            gcrCtrF2TexBox = "txtG1Fcm_numdoc_fcem";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o seguradores
        private void txtG1Sia_codeps_teps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codeps_teps_Browser();
            }
        }
        private void cmdG1Sia_codeps_teps_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codeps_teps_Browser();
        }
        private void txtG1Sia_codeps_teps_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
            gcrCtrF2TexBox = "txtG1Sia_codeps_teps";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region CON_IDESEC_MTER : Tabla terceros para gestion contable
        private void txtG1Con_idesec_mter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Con_idesec_mter_Browser();
            }
        }
        private void cmdG1Con_idesec_mter_Click(object sender, RoutedEventArgs e)
        {
            txtG1Con_idesec_mter_Browser();
        }
        private void txtG1Con_idesec_mter_Browser()
        {
            Browser01 frbro = new Browser01("CON", "CONTERCEROS", "", "Tabla terceros para gestion contable...");
            gcrCtrF2TexBox = "txtG1Con_idesec_mter";
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
        #region FCM_CODMAN_MANS : Maestro manuales tarifarios
        private void txtG1Fcm_codman_mans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG1Fcm_codman_mans";
                txtG1Fcm_codman_mans_Browser();
            }
        }
        private void txtG2Fcm_codman_mans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Fcm_codman_mans";
                txtG1Fcm_codman_mans_Browser();
            }
        }
        private void cmdG1Fcm_codman_mans_Click(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG1Fcm_codman_mans";
            txtG1Fcm_codman_mans_Browser();
        }
        private void cmdG2Fcm_codman_mans_Click(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Fcm_codman_mans";
            txtG1Fcm_codman_mans_Browser();
        }
        private void txtG1Fcm_codman_mans_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANTARIFARIO", "", "Maestro manuales tarifarios...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPUSU_REGI : Lista de Régimenes en Salud
        private void txtG1Sia_tipusu_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipusu_regi_Browser();
            }
        }
        private void cmdG1Sia_tipusu_regi_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipusu_regi_Browser();
        }
        private void txtG1Sia_tipusu_regi_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAREGIMENSALUD", "", "Lista de Régimenes en Salud...");
            gcrCtrF2TexBox = "txtG1Sia_tipusu_regi";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPASE_SITA : Clasificacion aseguradores servicios de salud
        private void txtG1Sia_tipase_sita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipase_sita_Browser();
            }
        }
        private void cmdG1Sia_tipase_sita_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipase_sita_Browser();
        }
        private void txtG1Sia_tipase_sita_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPOASEGURAD", "", "Clasificacion aseguradores servicios de salud...");
            gcrCtrF2TexBox = "txtG1Sia_tipase_sita";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODSAL_TSAL : Tabla de salarios minimos mensuales
        private void txtG2Sis_codsal_tsal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_codsal_tsal_Browser();
            }
        }
        private void cmdG2Sis_codsal_tsal_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_codsal_tsal_Browser();
        }
        private void txtG2Sis_codsal_tsal_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISSALARIOMIN", "", "Tabla de salarios minimos mensuales...");
            gcrCtrF2TexBox = "txtG2Sis_codsal_tsal";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
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
            gcrCtrF2TexBox = "txtG2Fcm_coddig_mant";
            var lcrTitulo = "Manual ventas de servicios medicos" + this.txtG2Fcm_desman_mans.Text + "...";
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + txtG2Fcm_codman_mans.Text.Trim() + "'";
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIOSIU", lcrFiltro, lcrTitulo);
            gcrCtrF2TexBox = "txtG2Fcm_coddig_mant";
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
                        case "cboG1Cto_estcon_cont":
                            txtG1Cto_estcon_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_estcon_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_estcon_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_modeps_cont":
                            txtG1Cto_modeps_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_modeps_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_modeps_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_codtco_cont":
                            txtG1Cto_codtco_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_codtco_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_codtco_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_tipact_cont":
                            txtG1Cto_tipact_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_tipact_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_tipact_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_sepser_cont":
                            txtG1Cto_sepser_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_sepser_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_sepser_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_gruite_cont":
                            txtG1Cto_gruite_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_gruite_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_gruite_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_fcdian_cont":
                            txtG1Cto_fcdian_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_fcdian_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_fcdian_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_ajupre_cont":
                            txtG1Cto_ajupre_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_ajupre_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_ajupre_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_frecus_cont":
                            txtG1Cto_frecus_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_frecus_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_frecus_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_cubniv_cont":
                            txtG1Cto_cubniv_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_cubniv_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_cubniv_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_posnpo_cont":
                            txtG1Cto_posnpo_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_posnpo_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_posnpo_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_genrip_cont":
                            txtG1Cto_genrip_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_genrip_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_genrip_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_gcorip_cont":
                            txtG1Cto_gcorip_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_gcorip_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_gcorip_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_autrad_cont":
                            txtG1Cto_autrad_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_autrad_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_autrad_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_autram_cont":
                            txtG1Cto_autram_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_autram_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_autram_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_serper_cont":
                            txtG1Cto_serper_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_serper_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_serper_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_idvalc_cont":
                            txtG1Cto_idvalc_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_idvalc_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_idvalc_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_vibaud_cont":
                            txtG1Cto_vibaud_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_vibaud_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_vibaud_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_prnord_cont":
                            txtG1Cto_prnord_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_prnord_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_prnord_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_prnrca_cont":
                            txtG1Cto_prnrca_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_prnrca_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_prnrca_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_apldes_cont":
                            txtG1Cto_apldes_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_apldes_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_apldes_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_cobser_cont":
                            txtG1Cto_cobser_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_cobser_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_cobser_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_cobcop_cont":
                            txtG1Cto_cobcop_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_cobcop_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_cobcop_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_cobmod_cont":
                            txtG1Cto_cobmod_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_cobmod_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_cobmod_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_cobcus_cont":
                            txtG1Cto_cobcus_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_cobcus_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_cobcus_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_liqcop_cont":
                            txtG1Cto_liqcop_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_liqcop_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_liqcop_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_liqmod_cont":
                            txtG1Cto_liqmod_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_liqmod_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_liqmod_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_tiplcp_cont":
                            txtG1Cto_tiplcp_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_tiplcp_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_tiplcp_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_dedcop_cont":
                            txtG1Cto_dedcop_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_dedcop_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_dedcop_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_sepcon_cont":
                            txtG1Cto_sepcon_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_sepcon_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_sepcon_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_suminv_cont":
                            txtG1Cto_suminv_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_suminv_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_suminv_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_liqvsm_cont":
                            txtG1Cto_liqvsm_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_liqvsm_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_liqvsm_cont.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cto_topval_cont":
                            txtG1Cto_topval_cont.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cto_topval_cont.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cto_topval_cont.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG2Fcm_tipccp_mant":
                            txtG2Fcm_tipccp_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_tipccp_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_tipccp_mant.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG2Fcm_estser_mant":
                            txtG2Fcm_estser_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_estser_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_estser_mant.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG2Fcm_facvmc_mant":
                            txtG2Fcm_facvmc_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_facvmc_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_facvmc_mant.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Cto_estcon_cont":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Cto_estcon_cont.SelectedItem;
                            cboG1Cto_estcon_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Cto_modeps_cont":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Cto_modeps_cont.SelectedItem;
                            cboG1Cto_modeps_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Cto_codtco_cont":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Cto_codtco_cont.SelectedItem;
                            cboG1Cto_codtco_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Cto_tipact_cont":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Cto_tipact_cont.SelectedItem;
                            cboG1Cto_tipact_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Cto_sepser_cont":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Cto_sepser_cont.SelectedItem;
                            cboG1Cto_sepser_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Cto_gruite_cont":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Cto_gruite_cont.SelectedItem;
                            cboG1Cto_gruite_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Cto_fcdian_cont":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Cto_fcdian_cont.SelectedItem;
                            cboG1Cto_fcdian_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Cto_frecus_cont":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Cto_frecus_cont.SelectedItem;
                            cboG1Cto_frecus_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Cto_cubniv_cont":
                            CrtForms.ListaComboBox lobG1ComboBox10 = (CrtForms.ListaComboBox)cboG1Cto_cubniv_cont.SelectedItem;
                            cboG1Cto_cubniv_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox10.ListaValoresSel);
                            break;
                        case "txtG1Cto_posnpo_cont":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)cboG1Cto_posnpo_cont.SelectedItem;
                            cboG1Cto_posnpo_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
                            break;
                        case "txtG1Cto_genrip_cont":
                            CrtForms.ListaComboBox lobG1ComboBox12 = (CrtForms.ListaComboBox)cboG1Cto_genrip_cont.SelectedItem;
                            cboG1Cto_genrip_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox12.ListaValoresSel);
                            break;
                        case "txtG1Cto_gcorip_cont":
                            CrtForms.ListaComboBox lobG1ComboBox13 = (CrtForms.ListaComboBox)cboG1Cto_gcorip_cont.SelectedItem;
                            cboG1Cto_gcorip_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox13.ListaValoresSel);
                            break;
                        case "txtG1Cto_autrad_cont":
                            CrtForms.ListaComboBox lobG1ComboBox26X = (CrtForms.ListaComboBox)cboG1Cto_autrad_cont.SelectedItem;
                            cboG1Cto_autrad_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox26X.ListaValoresSel);
                            break;
                        case "txtG1Cto_autram_cont":
                            CrtForms.ListaComboBox lobG1ComboBox27X = (CrtForms.ListaComboBox)cboG1Cto_autram_cont.SelectedItem;
                            cboG1Cto_autram_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox27X.ListaValoresSel);
                            break;
                        case "txtG1Cto_serper_cont":
                            CrtForms.ListaComboBox lobG1ComboBox33 = (CrtForms.ListaComboBox)cboG1Cto_serper_cont.SelectedItem;
                            cboG1Cto_serper_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox33.ListaValoresSel);
                            break;
                        case "txtG1Cto_idvalc_cont":
                            CrtForms.ListaComboBox lobG1ComboBox281 = (CrtForms.ListaComboBox)cboG1Cto_idvalc_cont.SelectedItem;
                            cboG1Cto_idvalc_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox281.ListaValoresSel);
                            break;
                        case "txtG1Cto_vibaud_cont":
                            CrtForms.ListaComboBox lobG1ComboBox14 = (CrtForms.ListaComboBox)cboG1Cto_vibaud_cont.SelectedItem;
                            cboG1Cto_vibaud_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox14.ListaValoresSel);
                            break;
                        case "txtG1Cto_prnord_cont":
                            CrtForms.ListaComboBox lobG1ComboBox15 = (CrtForms.ListaComboBox)cboG1Cto_prnord_cont.SelectedItem;
                            cboG1Cto_prnord_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox15.ListaValoresSel);
                            break;
                        case "txtG1Cto_prnrca_cont":
                            CrtForms.ListaComboBox lobG1ComboBox16 = (CrtForms.ListaComboBox)cboG1Cto_prnrca_cont.SelectedItem;
                            cboG1Cto_prnrca_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox16.ListaValoresSel);
                            break;
                        case "txtG1Cto_apldes_cont":
                            CrtForms.ListaComboBox lobG1ComboBox17 = (CrtForms.ListaComboBox)cboG1Cto_apldes_cont.SelectedItem;
                            cboG1Cto_apldes_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox17.ListaValoresSel);
                            break;
                        case "txtG1Cto_cobser_cont":
                            CrtForms.ListaComboBox lobG1ComboBox18 = (CrtForms.ListaComboBox)cboG1Cto_cobser_cont.SelectedItem;
                            cboG1Cto_cobser_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox18.ListaValoresSel);
                            break;
                        case "txtG1Cto_cobcop_cont":
                            CrtForms.ListaComboBox lobG1ComboBox19 = (CrtForms.ListaComboBox)cboG1Cto_cobcop_cont.SelectedItem;
                            cboG1Cto_cobcop_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox19.ListaValoresSel);
                            break;
                        case "txtG1Cto_cobmod_cont":
                            CrtForms.ListaComboBox lobG1ComboBox20 = (CrtForms.ListaComboBox)cboG1Cto_cobmod_cont.SelectedItem;
                            cboG1Cto_cobmod_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox20.ListaValoresSel);
                            break;
                        case "txtG1Cto_cobcus_cont":
                            CrtForms.ListaComboBox lobG1ComboBox21 = (CrtForms.ListaComboBox)cboG1Cto_cobcus_cont.SelectedItem;
                            cboG1Cto_cobcus_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox21.ListaValoresSel);
                            break;
                        case "txtG1Cto_liqcop_cont":
                            CrtForms.ListaComboBox lobG1ComboBox22 = (CrtForms.ListaComboBox)cboG1Cto_liqcop_cont.SelectedItem;
                            cboG1Cto_liqcop_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox22.ListaValoresSel);
                            break;
                        case "txtG1Cto_liqmod_cont":
                            CrtForms.ListaComboBox lobG1ComboBox23 = (CrtForms.ListaComboBox)cboG1Cto_liqmod_cont.SelectedItem;
                            cboG1Cto_liqmod_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox23.ListaValoresSel);
                            break;
                        case "txtG1Cto_tiplcp_cont":
                            CrtForms.ListaComboBox lobG1ComboBox24 = (CrtForms.ListaComboBox)cboG1Cto_tiplcp_cont.SelectedItem;
                            cboG1Cto_tiplcp_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox24.ListaValoresSel);
                            break;
                        case "txtG1Cto_dedcop_cont":
                            CrtForms.ListaComboBox lobG1ComboBox32 = (CrtForms.ListaComboBox)cboG1Cto_dedcop_cont.SelectedItem;
                            cboG1Cto_dedcop_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox32.ListaValoresSel);
                            break;
                        case "txtG1Cto_sepcon_cont":
                            CrtForms.ListaComboBox lobG1ComboBox25 = (CrtForms.ListaComboBox)cboG1Cto_sepcon_cont.SelectedItem;
                            cboG1Cto_sepcon_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox25.ListaValoresSel);
                            break;
                        case "txtG1Cto_suminv_cont":
                            CrtForms.ListaComboBox lobG1ComboBox26 = (CrtForms.ListaComboBox)cboG1Cto_suminv_cont.SelectedItem;
                            cboG1Cto_suminv_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox26.ListaValoresSel);
                            break;
                        case "txtG1Cto_liqvsm_cont":
                            CrtForms.ListaComboBox lobG1ComboBox27 = (CrtForms.ListaComboBox)cboG1Cto_liqvsm_cont.SelectedItem;
                            cboG1Cto_liqvsm_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox27.ListaValoresSel);
                            break;
                        case "txtG1Cto_topval_cont":
                            CrtForms.ListaComboBox lobG1ComboBox28 = (CrtForms.ListaComboBox)cboG1Cto_topval_cont.SelectedItem;
                            cboG1Cto_topval_cont.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox28.ListaValoresSel);
                            break;
                        case "txtG2Fcm_tipccp_mant":
                            CrtForms.ListaComboBox lobG1ComboBox29 = (CrtForms.ListaComboBox)cboG2Fcm_tipccp_mant.SelectedItem;
                            cboG2Fcm_tipccp_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox29.ListaValoresSel);
                            break;
                        case "txtG2Fcm_facvmc_mant":
                            CrtForms.ListaComboBox lobG1ComboBox30 = (CrtForms.ListaComboBox)cboG2Fcm_facvmc_mant.SelectedItem;
                            cboG2Fcm_facvmc_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox30.ListaValoresSel);
                            break;
                        case "txtG2Fcm_estser_mant":
                            CrtForms.ListaComboBox lobG1ComboBox31 = (CrtForms.ListaComboBox)cboG2Fcm_estser_mant.SelectedItem;
                            cboG2Fcm_estser_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox31.ListaValoresSel);
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
                    case "dpkG1Cto_fecico_cont":
                        txtG1Cto_fecico_cont.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cto_fecico_cont);
                        break;
                    case "dpkG1Cto_fecfco_cont":
                        txtG1Cto_fecfco_cont.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cto_fecfco_cont);
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
                            case "txtG1Cto_fecico_cont":
                                dpkG1Cto_fecico_cont.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Cto_fecfco_cont":
                                dpkG1Cto_fecfco_cont.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 04/10/2017 11:49:52 AM
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
using Systemas.VistaModelo;

namespace Systemas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sismaesterceros
    /// </summary>
    public partial class VistaSisMaestroterceros : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloSisMaestroTerceros vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSisMaestroterceros()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloSisMaestroTerceros;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

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
            FocusManager.SetFocusedElement(this, txtG1Sis_tipide_tido);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sis_tipide_tido);
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
                FocusManager.SetFocusedElement(this, txtG1Sis_idterc_sitr);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloSisMaestroTerceros();
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
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS", "", "Tabla terceros para gestion contable...");
            gcrCtrF2TexBox = "txtG1Sis_idterc_sitr";
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
                case "txtG1Sis_idterc_sitr":
                    txtG1Sis_idterc_sitr.Text = tcrCodigo;
                    break;

                case "txtG1Sis_tipide_tido":
                    txtG1Sis_tipide_tido.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idemun_muni":
                    txtG1Sis_idemun_muni.Text = tcrCodigo;
                    break;

                case "txtG1Sis_coddep_dpto":
                    txtG1Sis_coddep_dpto.Text = tcrCodigo;
                    break;

            }
        }
        // SISMAESTERCEROS : Tabla terceros para gestion contable
        #region KeyDown para campos con F2 Tabla: SISMAESTERCEROS
        #region SIS_TIPIDE_TIDO : Tipo identificacion tercero contable
        private void txtG1Sis_tipide_tido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_tipide_tido_Browser();
            }
        }
        private void cmdG1Sis_tipide_tido_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_tipide_tido_Browser();
        }
        private void txtG1Sis_tipide_tido_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTIPIDTERCER", "", "Tipo identificacion tercero contable...");
            gcrCtrF2TexBox = "txtG1Sis_tipide_tido";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_IDEMUN_MUNI : Listado de Municipios  DANE
        private void txtG1Sis_idemun_muni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_idemun_muni_Browser();
            }
        }
        private void cmdG1Sis_idemun_muni_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_idemun_muni_Browser();
        }
        private void txtG1Sis_idemun_muni_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABMUNICIPIO", "", "Listado de Municipios  DANE...");
            gcrCtrF2TexBox = "txtG1Sis_idemun_muni";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODDEP_DPTO : Departamentos del Pais DANE
        private void txtG1Sis_coddep_dpto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_coddep_dpto_Browser();
            }
        }
        private void cmdG1Sis_coddep_dpto_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_coddep_dpto_Browser();
        }
        private void txtG1Sis_coddep_dpto_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABDEPARTAME", "", "Departamentos del Pais DANE...");
            gcrCtrF2TexBox = "txtG1Sis_coddep_dpto";
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
                        case "cboG1Sis_tipper_sitr":
                            txtG1Sis_tipper_sitr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_tipper_sitr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_tipper_sitr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_tipcnt_sitr":
                            txtG1Sis_tipcnt_sitr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_tipcnt_sitr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_tipcnt_sitr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_relret_sitr":
                            txtG1Sis_relret_sitr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_relret_sitr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_relret_sitr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_tipter_tter":
                            txtG1Sis_tipter_tter.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_tipter_tter.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_tipter_tter.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sis_tipper_sitr":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sis_tipper_sitr.SelectedItem;
                            cboG1Sis_tipper_sitr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Sis_tipcnt_sitr":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Sis_tipcnt_sitr.SelectedItem;
                            cboG1Sis_tipcnt_sitr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Sis_relret_sitr":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Sis_relret_sitr.SelectedItem;
                            cboG1Sis_relret_sitr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Sis_tipter_tter":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Sis_tipter_tter.SelectedItem;
                            cboG1Sis_tipter_tter.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Sis_estreg_esrg":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Sis_estreg_esrg.SelectedItem;
                            cboG1Sis_estreg_esrg.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
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
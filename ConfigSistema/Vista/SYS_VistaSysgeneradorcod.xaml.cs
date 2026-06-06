//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2014 07:49:08 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Systemas.VistaModelo;

namespace Systemas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sysgeneradorcod
    /// </summary>
    public partial class VistaSysgeneradorcod : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSysgeneradorcod()
        {
            InitializeComponent();
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
            FocusManager.SetFocusedElement(this, txtG1Sys_codsec_gcod);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sys_codsec_gcod);
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
                FocusManager.SetFocusedElement(this, txtG1Sys_codsec_gcod);
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
        //-------------------------------------------------
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SYS", "SYSGENERADORCOD", "", "Tabla Generador de  secuenciales...");
            gcrCtrF2TexBox = "txtG1Sys_codsec_gcod";
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
                case "txtG1Sys_codsec_gcod":
                    txtG1Sys_codsec_gcod.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codmod_modu":
                    txtG1Sys_codmod_modu.Text = tcrCodigo;
                    break;

            }
        }
        // SYSGENERADORCOD : Tabla Generador de  secuenciales
        #region KeyDown para campos con F2 Tabla: SYSGENERADORCOD
        #region SYS_CODMOD_MODU : Módulos del Sistema
        private void txtG1Sys_codmod_modu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SYS", "SYSMODULOSISTEM", "", "Módulos del Sistema...");
                gcrCtrF2TexBox = "txtG1Sys_codmod_modu";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
                        case "cboG1Sys_relcer_gcod":
                            txtG1Sys_relcer_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_relcer_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_relcer_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_incfec_gcod":
                            txtG1Sys_incfec_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_incfec_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_incfec_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_locfec_gcod":
                            txtG1Sys_locfec_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_locfec_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_locfec_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_forfec_gcod":
                            txtG1Sys_forfec_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_forfec_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_forfec_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_incdia_gcod":
                            txtG1Sys_incdia_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_incdia_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_incdia_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_incmes_gcod":
                            txtG1Sys_incmes_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_incmes_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_incmes_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_incano_gcod":
                            txtG1Sys_incano_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_incano_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_incano_gcod.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_nivacc_gcod":
                            txtG1Sys_nivacc_gcod.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_nivacc_gcod.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_nivacc_gcod.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sys_relcer_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sys_relcer_gcod.SelectedItem;
                            cboG1Sys_relcer_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Sys_incfec_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Sys_incfec_gcod.SelectedItem;
                            cboG1Sys_incfec_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Sys_locfec_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Sys_locfec_gcod.SelectedItem;
                            cboG1Sys_locfec_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Sys_forfec_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Sys_forfec_gcod.SelectedItem;
                            cboG1Sys_forfec_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Sys_incdia_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Sys_incdia_gcod.SelectedItem;
                            cboG1Sys_incdia_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Sys_incmes_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Sys_incmes_gcod.SelectedItem;
                            cboG1Sys_incmes_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Sys_incano_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Sys_incano_gcod.SelectedItem;
                            cboG1Sys_incano_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Sys_nivacc_gcod":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Sys_nivacc_gcod.SelectedItem;
                            cboG1Sys_nivacc_gcod.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
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
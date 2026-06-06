//- MARMOTA-GENCODE: VERSION 2.0 - 27/04/2015 05:12:42 PM
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
using Meci.VistaModelo;

namespace Meci.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: mcievaluacionms
    /// </summary>
    public partial class VistaMcievaluacionms : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloMcievaluacionms gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaMcievaluacionms()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloMcievaluacionms;
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
            FocusManager.SetFocusedElement(this, txtG1Mci_deseva_mcms);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Mci_deseva_mcms);
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
                FocusManager.SetFocusedElement(this, txtG1Mci_idesec_mcms);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
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
                grdDetalles.IsEnabled = true;
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
                case "txtG1Mci_idepla_mcpl":
                    txtG1Mci_idepla_mcpl.Text = tcrCodigo;
                    break;

            }
        }
        // MCIEVALUACIONMS : Maestro de Evaluaciones Meci
        #region KeyDown para campos con F2 Tabla: MCIEVALUACIONMS
        #region MCI_IDEPLA_MCPL : Plantillas de Evaluación
        private void txtG1Mci_idepla_mcpl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Mci_idepla_mcpl_Browser();
            }
        }
        private void cmdG1Mci_idepla_mcpl_Click(object sender, RoutedEventArgs e)
        {
            txtG1Mci_idepla_mcpl_Browser();
        }
        private void txtG1Mci_idepla_mcpl_Browser()
        {
            Browser01 frbro = new Browser01("MCI", "MCIPLANTILLMECI", "", "Plantillas de Evaluación...");
            gcrCtrF2TexBox = "txtG1Mci_idepla_mcpl";
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
                        case "cboG1Mci_estreg_mcms":
                            txtG1Mci_estreg_mcms.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Mci_estreg_mcms.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Mci_estreg_mcms.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Mci_estreg_mcms":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Mci_estreg_mcms.SelectedItem;
                            cboG1Mci_estreg_mcms.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
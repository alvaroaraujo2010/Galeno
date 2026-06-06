//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 05:29:25 PM
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
    /// Descripcion para la Vista de  la tabla: mcigrupoprgmeci
    /// </summary>
    public partial class VistaMcigrupoprgmeci : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg 		 = -1;
        public bool llgModoAdicion	 = false;
        public bool llgModoEdicion	 = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloMcigrupoprgmeci gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaMcigrupoprgmeci()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloMcigrupoprgmeci;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno 	 = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text    = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility  = Visibility.Hidden;
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
            FocusManager.SetFocusedElement(this, txtG1Mci_desgrp_mcgr);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Mci_desgrp_mcgr);
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
                FocusManager.SetFocusedElement(this, txtG1Mci_idesec_mcgr);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility   = Visibility.Visible;
                cmdCancelar.Visibility  = Visibility.Visible;
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
                case "txtG1Mci_idesec_mcpa":
                    txtG1Mci_idesec_mcpa.Text = tcrCodigo;
                    break;

            }
        }
        /// <summary>
        /// <para>Seleccionar Parametros</para>
        /// </summary>
        #region evento TextChanged
        private void txtG1Mci_idesec_mcpa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(txtG1Mci_idesec_mcpa.Text))
                {

                    var tmp = MCIValidarCodigo.fobRegBuscarMciparametrmeci(txtG1Mci_idesec_mcpa.Text);
                    if (tmp != null)
                    {
                        this.txtG1Mci_despar_mcpa.Text = tmp.mci_despar_mcpa;
                        this.txtG1Mci_idesec_mcpl.Text = tmp.mci_idesec_mcpl;
                        this.txtG1Mci_idesec_mcmo.Text = tmp.mci_idesec_mcmo;
                        this.txtG1Mci_idesec_mcco.Text = tmp.mci_idesec_mcco;
                        this.txtG1Mci_estreg_mcpa.Text = tmp.mci_estreg_mcpa == "1" ? "ACTIVO" : "INACTIVO";
                    }

                    gobObjVModelo.gcrFiltroAplicado = "1*#%77"; // para que se ejecute CanFIL() en vistamodelo base la primera vez para 
                }
            }
        }
        #endregion
        #region Browser Componentes
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("MCI", "mciparametrmeci", "", "Parametros...");
            gcrCtrF2TexBox = "txtG1Mci_idesec_mcpa";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion                 
        // MCIGRUPOPRGMECI : Grupos en Parametros en Componentes de Módulos Meci
        #region KeyDown para campos con F2 Tabla: MCIGRUPOPRGMECI
        #region MCI_IDESEC_MCPA : Parametros en Componentes de Módulos Meci
        private void txtG1Mci_idesec_mcpa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Mci_idesec_mcpa_Browser();
            }
        }
        private void cmdG1Mci_idesec_mcpa_Click(object sender, RoutedEventArgs e)
        {
            txtG1Mci_idesec_mcpa_Browser();
        }
        private void txtG1Mci_idesec_mcpa_Browser()
        {
            Browser01 frbro = new Browser01("MCI","MCIPARAMETRMECI","","Parametros en Componentes de Módulos Meci...");
            gcrCtrF2TexBox = "txtG1Mci_idesec_mcpa";
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
                    case "cboG1Mci_estreg_mcgr":
                        txtG1Mci_estreg_mcgr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                txtG1Mci_estreg_mcgr.Text,",",
                                                                                lobList.ListaValoresSel);
                        lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Mci_estreg_mcgr.Text,",",lobList.ListaValoresSel);
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
                    case "txtG1Mci_estreg_mcgr":
                        CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Mci_estreg_mcgr.SelectedItem;
                        cboG1Mci_estreg_mcgr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",",lobG1ComboBox1.ListaValoresSel);
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
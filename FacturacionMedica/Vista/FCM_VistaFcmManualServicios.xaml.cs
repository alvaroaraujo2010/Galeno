//- MARMOTA-GENCODE: VERSION 2.0 - 27/03/2015 01:18:44 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using System.Collections.ObjectModel;
using FacturacionMedica.Modelo;
using FacturacionMedica.VistaModelo;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmanservicios
    /// </summary>
    public partial class VistaFcmManualServicios : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaPropiedades = false;
        public string gcrCtrF2TexBox;
        VistaModeloFcmManualServicios gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaFcmManualServicios()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloFcmManualServicios;

            gobObjVModelo.TmpG1ListaBrow = new ObservableCollection<ModeloFcmManualServicios>();
            gobObjVModelo.G1Fcm_codman_mans = String.Empty;
            gobObjVModelo.G1Fcm_desman_mans = String.Empty;
            gobObjVModelo.gcrFiltroAplicado = "1*#%77";
            gobObjVModelo.GcrFiltroDatos = String.Empty;
            gobObjVModelo.Restaurar();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;
            cmdGuardarEx.Visibility = Visibility.Hidden;
            cmdCancelarEx.Visibility = Visibility.Hidden;
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

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
            FocusManager.SetFocusedElement(this, txtG1Fcm_idesec_sips);
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Fcm_idesec_sips);
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
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
        #region Filtrar Vista Seleccion servicios
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
           crtBuscar lobControl = (crtBuscar)sender;
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
                FocusManager.SetFocusedElement(this, txtG1Fcm_idesec_mant);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;

                cmdAdicionarEx.Visibility = Visibility.Hidden;
                cmdModificarEx.Visibility = Visibility.Hidden;
                cmdGuardarEx.Visibility = Visibility.Visible;
                cmdCancelarEx.Visibility = Visibility.Visible;

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

                cmdAdicionarEx.Visibility = Visibility.Visible;
                cmdModificarEx.Visibility = Visibility.Visible;
                cmdGuardarEx.Visibility = Visibility.Hidden;
                cmdCancelarEx.Visibility = Visibility.Hidden;
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
        // Vista Capa Seleccion
        //-------------------------------------------------
        #region Ventana Vista de propiedades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana seleccion obra
        /// <summary>
        /// <para>Mostrar Ventana seleccion obra</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = -610; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
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
                case "txtG1Fcm_codman_mans":
                    txtG1Fcm_codman_mans.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_sips":
                    txtG1Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codsal_tsal":
                    txtG1Sis_codsal_tsal.Text = tcrCodigo;
                    break;

            }
        }
        #region Cargar manual tarifario seleccionado en browser
        /// <summary>
        /// <para>Seleccionar Manual de servicios</para>
        /// </summary>
        private void txtG1Fcm_codman_mans_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(txtG1Fcm_codman_mans.Text))
                {
                    var tmp = FCMValidarCodigo.fobRegBuscarFcmmantarifario(txtG1Fcm_codman_mans.Text);
                    if (tmp != null)
                    {
                        this.txtG1Fcm_desman_mans.Text = tmp.fcm_desman_mans;
                        gobObjVModelo.G1Fcm_codtar_ttar = tmp.fcm_codtar_ttar;
                        this.txtG1Fcm_estman_mans.Text = tmp.fcm_estman_mans == "1" ? "ACTIVO" : "INACTIVO";
                        gobObjVModelo.gcrFiltroAplicado = "1*#%77"; // para que se ejecute CanFIL() en vistamodelo base la primera vez para 
                    }
                }
            }
        }
        #endregion
        //fobRegBuscarFcmmantarifario(string tcrCodigo)
        // FCMMANSERVICIOS : Manual ventas de servicios medicos
        #region KeyDown para campos con F2 Tabla: FCMMANSERVICIOS
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
        #region SIS_CODSAL_TSAL : Tabla de salarios minimos mensuales
        private void txtG1Sis_codsal_tsal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codsal_tsal_Browser();
            }
        }
        private void cmdG1Sis_codsal_tsal_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codsal_tsal_Browser();
        }
        private void txtG1Sis_codsal_tsal_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISSALARIOMIN", "", "Tabla de salarios minimos mensuales...");
            gcrCtrF2TexBox = "txtG1Sis_codsal_tsal";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region Browser Manual Tarifario
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANTARIFARIO","","Maestro manuales tarifarios...");
            gcrCtrF2TexBox = "txtG1Fcm_codman_mans";
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
                        case "cboG1Fcm_tipccp_mant":
                            txtG1Fcm_tipccp_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_tipccp_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_tipccp_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_facpln_mant":
                            txtG1Fcm_facpln_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_facpln_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_facpln_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_facvmc_mant":
                            txtG1Fcm_facvmc_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_facvmc_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_facvmc_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_perman_mant":
                            txtG1Fcm_perman_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_perman_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_perman_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_alcamb_mant":
                            txtG1Fcm_alcamb_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_alcamb_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_alcamb_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_alcurg_mant":
                            txtG1Fcm_alcurg_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_alcurg_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_alcurg_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_alchos_mant":
                            txtG1Fcm_alchos_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_alchos_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_alchos_mant.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_aplfus_sips":
                            txtG1Fcm_aplfus_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_aplfus_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_aplfus_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_estser_mant":
                            txtG1Fcm_estser_mant.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_estser_mant.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_estser_mant.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Fcm_tipccp_mant":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Fcm_tipccp_mant.SelectedItem;
                            cboG1Fcm_tipccp_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Fcm_facvmc_mant":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Fcm_facvmc_mant.SelectedItem;
                            cboG1Fcm_facvmc_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Fcm_facpln_mant":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Fcm_facpln_mant.SelectedItem;
                            cboG1Fcm_facpln_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Fcm_perman_mant":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Fcm_perman_mant.SelectedItem;
                            cboG1Fcm_perman_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Fcm_alcamb_mant":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Fcm_alcamb_mant.SelectedItem;
                            cboG1Fcm_alcamb_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Fcm_alcurg_mant":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Fcm_alcurg_mant.SelectedItem;
                            cboG1Fcm_alcurg_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Fcm_alchos_mant":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Fcm_alchos_mant.SelectedItem;
                            cboG1Fcm_alchos_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Fcm_aplfus_sips":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Fcm_aplfus_sips.SelectedItem;
                            cboG1Fcm_aplfus_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Fcm_estser_mant":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Fcm_estser_mant.SelectedItem;
                            cboG1Fcm_estser_mant.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
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
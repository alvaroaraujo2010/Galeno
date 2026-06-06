//- MARMOTA-GENCODE: VERSION 2.0 - 05/12/2013 10:49:10 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using FacturacionMedica.VistaModelo;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public partial class VistaCompletarRips : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public string lcrFormModoPopup = "DFL";
        public bool glgVistPropiedades = false;
        DialogVistaErrores lobDlgLogs = null;
        VistaModeloCompletarRips vm = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaCompletarRips(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloCompletarRips;
            vm.Restaurar();
            llgObjetosCargados = true;

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoIgTabla, tcrCodigo1, tcrCodigo2, tcrCodigo3);
            }
        }
        #endregion
        //-------------------------------------------------
        // Cambio de Resolucion de Pantalla y Logs de Errores
        //-------------------------------------------------
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
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            var llgExiste = true;

            switch (tcrModoAccion)
            {
                case "ADD": // Modo Adicion
                    lcrFormModoPopup = "ADD";
                    if (llgExiste == true) { lcrFormModoPopup = "EDT"; }
                    break;

                case "EDT": // Modo Edicion
                    lcrFormModoPopup = "EDT";
                    if (llgExiste == false) { lcrFormModoPopup = "ADD"; }
                    break;

                default:
                    //- Opcion por Defecto
                    lcrFormModoPopup = "DFL";
                    break;
            }
            txtG1Adm_secadm_rgad.Text = tcrCodigoIgTabla;
            lblFormModoPopup.Text = lcrFormModoPopup;
            fcvActivarModoEdicion(lcrFormModoPopup);

            //vm.Filtro(); // Cargar datos en vista
            
            cmdBrowser.Visibility = Visibility.Hidden;

        }
        #endregion
        //-------------------------------------------------
        //  ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        //-------------------------------------------------
        #region  ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        private void ActualizarFormModoPopup(String tcrTipoEdicion, String tcrEstado)
        {
            try
            {
                if (lcrFormModoPopup == "ADD" || lcrFormModoPopup == "EDT")
                {
                    cmdModificar.Visibility = Visibility.Hidden;
                    cmdGuardar.Visibility = Visibility.Visible;
                    cmdCancelar.Visibility = Visibility.Visible;
                    cmdBrowser.Visibility = Visibility.Hidden;
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "ADD")
                    {
                        this.Close();
                    }
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "EDT")
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "EDT" && llgModoEdicion == false)
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "SAV")
                    {
                        lcrFormModoPopup = "EDT";
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarFormModoPopup");
            }
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
            FocusManager.SetFocusedElement(this, txtG1Adm_codoad_toad);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_serpos_sips);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Adm_codoad_toad);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_serpos_sips);
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
            FocusManager.SetFocusedElement(this, txtG2Fcm_serpos_sips);
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
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                cmdModificar.Visibility = Visibility.Visible;
                cmdGuardar.Visibility = Visibility.Hidden;
                cmdCancelar.Visibility = Visibility.Hidden;
            }
            ActualizarFormModoPopup(tcrTipoEdicion, "1");
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
            if (txtG1Sis_estpro_espr.Text == "2") // datos conpletados confirmado
            {
                SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
                if (lobRefEnlace != null)
                {
                    lobRefEnlace.fcvBuscarRegistro(txtG1Adm_secadm_rgad.Text.Trim());
                }
            }
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloCompletarRips();
            this.Close();
        }

        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtG1Sis_estpro_espr.Text == "2") // datos conpletados confirmado
            {
                SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
                if (lobRefEnlace != null)
                {
                    lobRefEnlace.fcvBuscarRegistro(txtG1Adm_secadm_rgad.Text.Trim());
                }
            }
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloCompletarRips();
            this.Close();
        }
        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            if (txtG1Sis_estpro_espr.Text == "2") // datos conpletados confirmado
            {
                SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
                if (lobRefEnlace != null)
                {
                    lobRefEnlace.fcvBuscarRegistro(txtG1Adm_secadm_rgad.Text.Trim());
                }
            }
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloCompletarRips();
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Adm_secadm_rgad":
                    txtG1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codart_mart":
                    txtG2Inv_codart_mart.Text = tcrCodigo;
                    break;

                case "txtG2Sia_coddx1_tdia":
                    txtG2Sia_coddx1_tdia.Text = tcrCodigo;
                    break;

                case "txtG2Sia_coddx2_tdia":
                    txtG2Sia_coddx2_tdia.Text = tcrCodigo;
                    break;

                case "txtG2Sia_coddx3_tdia":
                    txtG2Sia_coddx3_tdia.Text = tcrCodigo;
                    break;

                case "txtG2Sia_coddxc_tdia":
                    txtG2Sia_coddxc_tdia.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codrip_trip":
                    txtG2Sia_codrip_trip.Text = tcrCodigo;
                    break;

                case "txtG2Inv_secart_mart":
                    txtG2Inv_secart_mart.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codaqx_aqir":
                    txtG2Fcm_codaqx_aqir.Text = tcrCodigo;
                    break;

                case "txtG2Sia_tipact_tsac":
                    txtG2Sia_tipact_tsac.Text = tcrCodigo;
                    break;

                case "txtG2Adm_codtat_tatn":
                    txtG2Adm_codtat_tatn.Text = tcrCodigo;
                    break;

                case "txtG2Sia_coddia_tdia":
                    txtG2Sia_coddia_tdia.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // FCMMAEDETALLFAC : Detalles servicios medicos prestados
        #region KeyDown para campos con F2 Tabla: FCMMAEDETALLFAC
        #region INV_CODART_MART :
        private void txtG2Inv_codart_mart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("", "", "", "...");
                gcrCtrF2TexBox = "txtG2Inv_codart_mart";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        // Diagnosticos de consultas
        #region SIA_CODDIA_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_coddia_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Sia_coddia_tdia";
                fcvBrowserDiagnosticos();
            }
        }
        private void fcvDiagnosticoPrin(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Sia_coddia_tdia";
            fcvBrowserDiagnosticos();
        }
        #endregion
        #region SIA_CODDX1_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_coddx1_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Sia_coddx1_tdia";
                fcvBrowserDiagnosticos();
            }
        }
        private void fcvDiagnosticoRel1(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Sia_coddx1_tdia";
            fcvBrowserDiagnosticos();
        }
        #endregion
        #region SIA_CODDX2_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_coddx2_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Sia_coddx2_tdia";
                fcvBrowserDiagnosticos();
            }
        }
        private void fcvDiagnosticoRel2(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Sia_coddx2_tdia";
            fcvBrowserDiagnosticos();
        }
        #endregion
        #region SIA_CODDX3_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_coddx3_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Sia_coddx3_tdia";
                fcvBrowserDiagnosticos();
            }
        }
        private void fcvDiagnosticoRel3(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Sia_coddx3_tdia";
            fcvBrowserDiagnosticos();
        }
        #endregion
        #region SIA_CODDXC_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_coddxc_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = "txtG2Sia_coddxc_tdia";
                fcvBrowserDiagnosticos();
            }
        }
        private void fcvDiagnosticoComplicacion(object sender, RoutedEventArgs e)
        {
            gcrCtrF2TexBox = "txtG2Sia_coddxc_tdia";
            fcvBrowserDiagnosticos();
        }
        #endregion
        #region BROWSER: Tabla de diagnosticos CIE - 10
        private void fcvBrowserDiagnosticos()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        // Resto de datos
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
                Browser01 frbro = new Browser01("SIA", "SIATABLATPRIPS", "", "Tabla tipo RIPS...");
                gcrCtrF2TexBox = "txtG2Sia_codrip_trip";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region INV_SECART_MART :
        private void txtG2Inv_secart_mart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("", "", "", "...");
                gcrCtrF2TexBox = "txtG2Inv_secart_mart";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_CODAQX_AQIR : Forma de realizacion acto quirurgico
        private void txtG2Fcm_codaqx_aqir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMACTQUIRURGIC", "", "Forma de realizacion acto quirurgico...");
                gcrCtrF2TexBox = "txtG2Fcm_codaqx_aqir";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
                Browser01 frbro = new Browser01("SIA", "SIATIPACTIVIDAD", "", "Tipo de servicio o actividad...");
                gcrCtrF2TexBox = "txtG2Sia_tipact_tsac";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region ADM_CODTAT_TATN : Ambito de atención paciente
        private void txtG2Adm_codtat_tatn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("ADM", "ADMTIPOATENCION", "", "Ambito de atención paciente...");
                gcrCtrF2TexBox = "txtG2Adm_codtat_tatn";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("ADM", "ADMREGADMISION", "", "Admisión de pacientes...");
            gcrCtrF2TexBox = "txtG1Adm_secadm_rgad";
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
                        case "cboG1Adm_codoad_toad":
                            txtG1Adm_codoad_toad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_codoad_toad.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_codoad_toad.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_codcex_tcex":
                            txtG1Adm_codcex_tcex.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_codcex_tcex.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_codcex_tcex.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_coddsa_tdsa":
                            txtG1Adm_coddsa_tdsa.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_coddsa_tdsa.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_coddsa_tdsa.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_pacemb_rgad":
                            txtG1Adm_pacemb_rgad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_pacemb_rgad.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_pacemb_rgad.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_serpos_sips":
                            txtG2Fcm_serpos_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_serpos_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_serpos_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sia_codfco_fcon":
                            txtG2Sia_codfco_fcon.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_codfco_fcon.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_codfco_fcon.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Adm_codcex_tcex":
                            txtG2Adm_codcex_tcex.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Adm_codcex_tcex.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Adm_codcex_tcex.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_codtse_sips":
                            txtG2Fcm_codtse_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_codtse_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_codtse_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sia_codfpr_fpor":
                            txtG2Sia_codfpr_fpor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_codfpr_fpor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_codfpr_fpor.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG2Sia_tipdxp_tdix":
                            txtG2Sia_tipdxp_tdix.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_tipdxp_tdix.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_tipdxp_tdix.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_codoad_toad":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Adm_codoad_toad.SelectedItem;
                            cboG1Adm_codoad_toad.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Adm_codcex_tcex":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Adm_codcex_tcex.SelectedItem;
                            cboG1Adm_codcex_tcex.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Adm_coddsa_tdsa":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Adm_coddsa_tdsa.SelectedItem;
                            cboG1Adm_coddsa_tdsa.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Adm_pacemb_rgad":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Adm_pacemb_rgad.SelectedItem;
                            cboG1Adm_pacemb_rgad.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG2Fcm_serpos_sips":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Fcm_serpos_sips.SelectedItem;
                            cboG2Fcm_serpos_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Sia_codfco_fcon":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Sia_codfco_fcon.SelectedItem;
                            cboG2Sia_codfco_fcon.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Adm_codcex_tcex":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Adm_codcex_tcex.SelectedItem;
                            cboG2Adm_codcex_tcex.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
                            break;
                        case "txtG2Fcm_codtse_sips":
                            CrtForms.ListaComboBox lobG2ComboBox4 = (CrtForms.ListaComboBox)cboG2Fcm_codtse_sips.SelectedItem;
                            cboG2Fcm_codtse_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox4.ListaValoresSel);
                            break;
                        case "txtG2Sia_codfpr_fpor":
                            CrtForms.ListaComboBox lobG2ComboBox5 = (CrtForms.ListaComboBox)cboG2Sia_codfpr_fpor.SelectedItem;
                            cboG2Sia_codfpr_fpor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox5.ListaValoresSel);
                            break;
                        case "txtG2Sia_tipdxp_tdix":
                            CrtForms.ListaComboBox lobG2ComboBox6 = (CrtForms.ListaComboBox)cboG2Sia_tipdxp_tdix.SelectedItem;
                            cboG2Sia_tipdxp_tdix.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox6.ListaValoresSel);
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
        // Activar la pestaña segun el tipo de RIPS
        //-------------------------------------------------
        #region Activar la pestaña segun el tipo de RIPS
        private void fcvActivarVistaTabsRips(object sender, TextChangedEventArgs e)
        {
            //var lcrNombreTab = "pagTABS2";

            // Ocultar todas 
            this.pagTABS2.Visibility = Visibility.Collapsed;
            this.pagTABS3.Visibility = Visibility.Collapsed;
            this.pagTABS4.Visibility = Visibility.Collapsed;

            if (txtG2Sia_codrip_trip.Text.Trim() == "01") // Consultas
            {
                this.pagTABS2.Visibility = Visibility.Visible;
            }
            else if (txtG2Sia_codrip_trip.Text.Trim() == "02" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "03" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "04" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "05") // Procedimientos
            {
                this.pagTABS3.Visibility = Visibility.Visible;
            }
            else if (txtG2Sia_codrip_trip.Text.Trim() == "12" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "13") // Medicamentos POS y NO POS
            {
                this.pagTABS4.Visibility = Visibility.Visible;
            }
            else // Otros servicios (Honorarios, Estancias, Bancos de Sangre, Traslados y otros)
            {
            }
            //pagG2Rips.SelectedItem = (TabItem)pagG2Rips.FindName(lcrNombreTab);
        }
        #endregion
        //-------------------------------------------------
        // Vista Capa Propiedades al hacer click sobre el Odontograma
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
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
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
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
    }
}
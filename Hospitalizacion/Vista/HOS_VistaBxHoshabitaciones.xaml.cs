//- MARMOTA-GENCODE: VERSION 2.0 - 19/03/2013 06:04:27 PM
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
using Hospitalizacion.VistaModelo;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hoshabitaciones
    /// </summary>
    public partial class VistaBxHoshabitaciones : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Declara Listas para ComboBox Desplegables
        //-------------------------------------------------
        #region Valores para ComboBox Listas Desplegables
        public List<CrtForms.ListaComboBox> lstG1Hos_tiphab_habi;
        public List<CrtForms.ListaComboBox> lstG2Hos_camaux_caho;
        #endregion
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaBxHoshabitaciones()
        {
            InitializeComponent();
            llgObjetosCargados = true;

            IniciarComboBox();
            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG2Hos_fechac_caho.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Hos_nrohab_habi);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Hos_descam_caho);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Hos_deshab_habi);
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
            FocusManager.SetFocusedElement(this, txtG2Hos_descam_caho);
        }

        //-Clic en Boton Confirmar registro
        private void fcvConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CON");
        }

        //-Clic en Boton Anular registro
        private void fcvAnularRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ANU");
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
            FocusManager.SetFocusedElement(this, txtG2Hos_descam_caho);
        }
        #endregion
        #endregion
        //- Activar modo edicion en Vista
        #region  Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Hos_nrohab_habi);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Hos_nrohab_habi);
                    break;

                case "CAN":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;

                case "SAV":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;

                default:
                    //- los demas metodos (ANU,CON,DEL) los cambia el
                    //- textbox que maneja el estado 
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;
            }
        }
        #endregion
        //-Actualizar Modo Edicion del formulario
        #region Actualizar Estado edicion del formulario
        //- Activar modo edicion en la Vista
        private void ActualizarModoEdicion(string tcrEstado)
        {
            try
            {

                if (llgModoEdicion == true)
                {
                    cmdAdicionar.Visibility = Visibility.Hidden;
                    cmdModificar.Visibility = Visibility.Hidden;
                    cmdGuardar.Visibility = Visibility.Visible;
                    cmdCancelar.Visibility = Visibility.Visible;
                }
                else
                {
                    cmdAdicionar.Visibility = Visibility.Visible;
                    cmdModificar.Visibility = Visibility.Visible;
                    cmdGuardar.Visibility = Visibility.Hidden;
                    cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdCancelar.Visibility = Visibility.Hidden;
                }
                cmdConfirmar.Visibility = Visibility.Hidden;

                switch (tcrEstado)
                {
                    case "1":

                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
                        }
                        break;

                    case "2":
                        if (llgModoAdicion == true)
                        {
                            // se resutaura desde TextBox que maneja el estado
                            llgModoAdicion = false;
                            llgModoEdicion = false;
                            cmdAdicionar.Visibility = Visibility.Visible;
                            cmdModificar.Visibility = Visibility.Visible;
                        }
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    case "3":
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    default:
                        // se asume modo inicial vacio
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdGuardar.Visibility = Visibility.Visible;
                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
                        }
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarModoEdicion");
            }
        }
        #endregion
        #region Actualizar Estado edicion desde TextBox Estado
        void ActualizarEdtDesdeTextBoxEstado(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    ActualizarModoEdicion(lobTexto.Text);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarEdtDesdeTextBoxEstado");
            }
        }
        #endregion
        //- Configuracion modo Edicion Guardar o Confirmar
        #region Modo Guardar (por defecto) o  Confirmar
        public void fcvConfigModoGuardar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = true;
        }
        //- Configuracion modo Confirmar
        public void fcvConfigModoConfirmar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = false;
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
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Hos_nrohab_habi":
                    txtG1Hos_nrohab_habi.Text = tcrCodigo;
                    break;

                case "txtG1Hos_codsec_hsec":
                    txtG1Hos_codsec_hsec.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estreg_esrg":
                    txtG1Sis_estreg_esrg.Text = tcrCodigo;
                    break;

                case "txtG2Hos_nrohab_habi":
                    txtG2Hos_nrohab_habi.Text = tcrCodigo;
                    break;

                case "txtG2Hos_tipcam_tcam":
                    txtG2Hos_tipcam_tcam.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_idesec_sips":
                    txtG2Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG2Hos_codsec_hsec":
                    txtG2Hos_codsec_hsec.Text = tcrCodigo;
                    break;

                case "txtG2Hos_estcam_ecam":
                    txtG2Hos_estcam_ecam.Text = tcrCodigo;
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
        // HOSHABITACIONES : Habitaciones
        #region KeyDown para campos con F2 Tabla: HOSHABITACIONES
        #region HOS_CODSEC_HSEC : Secciones por area prestacion servicios
        private void txtG1Hos_codsec_hsec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS", "", "Secciones por area prestacion servicios...");
                gcrCtrF2TexBox = "txtG1Hos_codsec_hsec";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIS_ESTREG_ESRG : Estados de registros en modulos para:  Registros de Atencion
        private void txtG1Sis_estreg_esrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "", "Estados de registros en modulos para:  Registros de Atencion...");
                gcrCtrF2TexBox = "txtG1Sis_estreg_esrg";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        // HOSCAMASAREAS : Camas por area prestacion servicios
        #region KeyDown para campos con F2 Tabla: HOSCAMASAREAS
        #region HOS_NROHAB_HABI : Habitaciones
        private void txtG2Hos_nrohab_habi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSHABITACIONES", "", "Habitaciones...");
                gcrCtrF2TexBox = "txtG2Hos_nrohab_habi";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HOS_TIPCAM_TCAM : Tipos de camas según ergonomia
        private void txtG2Hos_tipcam_tcam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSTIPOCAMAS", "", "Tipos de camas según ergonomia...");
                gcrCtrF2TexBox = "txtG2Hos_tipcam_tcam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
                Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "", "Maestro de servicios habilitados para la IPS...");
                gcrCtrF2TexBox = "txtG2Fcm_idesec_sips";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HOS_CODSEC_HSEC : Secciones por area prestacion servicios
        private void txtG2Hos_codsec_hsec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS", "", "Secciones por area prestacion servicios...");
                gcrCtrF2TexBox = "txtG2Hos_codsec_hsec";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HOS_ESTCAM_ECAM : Estado de las camas existentes
        private void txtG2Hos_estcam_ecam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSESTADOCAMA", "", "Estado de las camas existentes...");
                gcrCtrF2TexBox = "txtG2Hos_estcam_ecam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIS_ESTREG_ESRG : Estados de registros en modulos para:  Registros de Atencion
        private void txtG2Sis_estreg_esrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "", "Estados de registros en modulos para:  Registros de Atencion...");
                gcrCtrF2TexBox = "txtG2Sis_estreg_esrg";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos":
                    lcrFiltro = String.Empty;
                    break;

                case "opAbierto":
                    lcrFiltro = "Hoshabitaciones.sis_estreg_esrg = '1'";
                    break;

                case "opCerrado":
                    lcrFiltro = "Hoshabitaciones.sis_estreg_esrg = '2'";
                    break;

                case "opAnulado":
                    lcrFiltro = "Hoshabitaciones.sis_estreg_esrg = '3'";
                    break;

            }
            Browser01 frbro = new Browser01("HOS", "HOSHABITACIONES", lcrFiltro, "Habitaciones...");
            gcrCtrF2TexBox = "txtG1Hos_nrohab_habi";
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
                CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                ComboBox lobCombo = (ComboBox)sender;

                switch (lobCombo.Name)
                {
                    case "cboG1Hos_tiphab_habi":
                        txtG1Hos_tiphab_habi.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                txtG1Hos_tiphab_habi.Text, ",",
                                                                                lobList.ListaValoresSel);
                        lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hos_tiphab_habi.Text, ",", lobList.ListaValoresSel);
                        break;
                    case "cboG2Hos_camaux_caho":
                        txtG2Hos_camaux_caho.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                txtG2Hos_camaux_caho.Text, ",",
                                                                                lobList.ListaValoresSel);
                        lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Hos_camaux_caho.Text, ",", lobList.ListaValoresSel);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Formato para captura de la hora
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
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora");
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
                        case "txtG1Hos_tiphab_habi":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hos_tiphab_habi.SelectedItem;
                            cboG1Hos_tiphab_habi.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Hos_camaux_caho":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Hos_camaux_caho.SelectedItem;
                            cboG2Hos_camaux_caho.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //HOS_TIPHAB_HABI: Unipersonal SI/NO
                //-------------------------------------------------
                #region HOS_TIPHAB_HABI: Unipersonal SI/NO
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Opcion 1,Opcion 2";
                lstG1Hos_tiphab_habi = new List<CrtForms.ListaComboBox>();
                lstG1Hos_tiphab_habi = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                cboG1Hos_tiphab_habi.ItemsSource = lstG1Hos_tiphab_habi;
                cboG1Hos_tiphab_habi.SelectedIndex = Convert.ToInt32(lstG1Hos_tiphab_habi[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //HOS_CAMAUX_CAHO: Cama adecuada SI/NO
                //-------------------------------------------------
                #region HOS_CAMAUX_CAHO: Cama adecuada SI/NO
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Opcion 1,Opcion 2";
                lstG2Hos_camaux_caho = new List<CrtForms.ListaComboBox>();
                lstG2Hos_camaux_caho = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                //- Asignar al control
                cboG2Hos_camaux_caho.ItemsSource = lstG2Hos_camaux_caho;
                cboG2Hos_camaux_caho.SelectedIndex = Convert.ToInt32(lstG2Hos_camaux_caho[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
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
                    case "dpkG2Hos_fechac_caho":
                        txtG2Hos_fechac_caho.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG2Hos_fechac_caho);
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
                            case "txtG2Hos_fechac_caho":
                                dpkG2Hos_fechac_caho.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
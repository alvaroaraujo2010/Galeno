//- MARMOTA-GENCODE: VERSION 2.0 - 21/02/2013 05:13:41 PM
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
    public partial class VistaBcHoshabitaciones : Window, SIS_Interface
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
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaBcHoshabitaciones()
        {
            lstG1Hos_tiphab_habi = new List<CrtForms.ListaComboBox>();
            lstG2Hos_camaux_caho = new List<CrtForms.ListaComboBox>();
            InitializeComponent();

            IniciarComboBox();
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
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS","", "Secciones por area prestacion servicios...");
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
                Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "","Estados de registros en modulos para:  Registros de Atencion...");
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
                Browser01 frbro = new Browser01("HOS", "HOSHABITACIONES", "Habitaciones...", "");
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
                Browser01 frbro = new Browser01("HOS", "HOSTIPOCAMAS", "Tipos de camas según ergonomia...", "");
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
                Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "Maestro de servicios habilitados para la IPS...", "");
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
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS", "Secciones por area prestacion servicios...", "");
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
                Browser01 frbro = new Browser01("HOS", "HOSESTADOCAMA", "Estado de las camas existentes...", "");
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
                Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "Estados de registros en modulos para:  Registros de Atencion...", "");
                gcrCtrF2TexBox = "txtG2Sis_estreg_esrg";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HOS", "HOSHABITACIONES", "Habitaciones...","");
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
                                                                                txtG1Hos_tiphab_habi.Text,",",
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
        // Actualizar ComboBox desde Campo Texto
        //-------------------------------------------------
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
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
    }
}
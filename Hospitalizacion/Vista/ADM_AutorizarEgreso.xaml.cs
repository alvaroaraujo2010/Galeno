//- MARMOTA-GENCODE: VERSION 2.0 - 01/08/2013 12:07:57 PM
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
using Hospitalizacion.VistaModelo;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admordendsalida
    /// </summary>
    public partial class VistaAutorizarEgreso : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public String gcrCodigoAdmision = String.Empty;
        public string gcrCtrF2TexBox;
        public string lcrFormModoPopup = "DFL";
        VistaModeloAutorizarEgreso gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaAutorizarEgreso(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloAutorizarEgreso;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;
            gcrCodigoAdmision = tcrCodigo1;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Adm_fecsol_aegr.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fecsal_aegr.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoIgTabla, tcrCodigo1, tcrCodigo2, tcrCodigo3);
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            var llgExiste = false;
            if (!String.IsNullOrWhiteSpace(tcrCodigoIgTabla))
            {
                EFadmordendsalida lobReg = ADMValidarCodigo.fobRegBuscarAdmordendsalida(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_secaut_aegr)) { llgExiste = true; }
            }

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
            txtG1Adm_secaut_aegr.Text = tcrCodigoIgTabla;
            txtG1Adm_secadm_rgad.Text = tcrCodigo1;
            lblFormModoPopup.Text = lcrFormModoPopup;
            fcvActivarModoEdicion(lcrFormModoPopup);
            this.cmdBrowser.Visibility = !String.IsNullOrWhiteSpace(tcrCodigo1) ? Visibility.Collapsed : Visibility.Visible;
            this.cmdAdicionar.Visibility = !String.IsNullOrWhiteSpace(tcrCodigo1) ? Visibility.Collapsed : Visibility.Visible;
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
                    cmdAdicionar.Visibility = Visibility.Hidden;
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
                    if (tcrTipoEdicion == "CON")
                    {
                        if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
                        {
                            cmdGuardar.Visibility = Visibility.Collapsed;
                            cmdCancelar.Visibility = Visibility.Collapsed;
                        }
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
        // Mostrar menu contextual
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Adm_fecsol_aegr);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Adm_fecsol_aegr);
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
        //-Clic en Boton Confirmar registro
        private void fcvConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("CON");
        }
        //-Clic en Boton Anular registro
        private void fcvAnularRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ANU");
        }
        //-Clic en Boton Eliminar registro
        private void fcvEliminarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("DEL");
        }
        #endregion
        #region fcvActivarModoEdicion: Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
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
            ActualizarFormModoPopup(tcrTipoEdicion, "1");
        }
        #endregion
        #region ActualizarModoEdicion: Actualizar Estado edicion del formulario
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
                    cmdCancelar.Visibility = Visibility.Hidden;
                }

                switch (tcrEstado)
                {
                    case "1":

                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
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
                        break;

                    case "3":
                        break;

                    default:
                        // se asume modo inicial vacio
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdGuardar.Visibility = Visibility.Visible;
                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
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
            Browser01 frbro = new Browser01("ADM", "ADMORDENDSALIDA", "", "Autorizacion de salida o egreso a pacientes...");
            gcrCtrF2TexBox = "txtG1Adm_secaut_aegr";
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
                case "txtG1Adm_secaut_aegr":
                    txtG1Adm_secaut_aegr.Text = tcrCodigo;
                    break;

                case "txtG1Adm_secadm_rgad":
                    txtG1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG1Sia_idesec_usua":
                    txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipide_tide":
                    txtG1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

            }
        }
        // ADMORDENDSALIDA : Autorizacion de salida o egreso a pacientes
        #region KeyDown para campos con F2 Tabla: ADMORDENDSALIDA
        #region ADM_SECADM_RGAD : Admisión de pacientes
        private void txtG1Adm_secadm_rgad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("ADM", "ADMREGADMISION", "", "Admisión de pacientes...");
                gcrCtrF2TexBox = "txtG1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_IDESEC_USUA : Maestro de Pacientes atendidos
        private void txtG1Sia_idesec_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtG1Sia_idesec_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_TIPIDE_TIDE : Configuracion para los tipos de identificacion de los uauari
        private void txtG1Sia_tipide_tide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Configuracion para los tipos de identificacion usuarios...");
                gcrCtrF2TexBox = "txtG1Sia_tipide_tide";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void txtG1Sia_codpfa_prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
                gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
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
                        case "cboG1Adm_estreg_aegr":
                            txtG1Adm_estreg_aegr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_estreg_aegr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_estreg_aegr.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_estreg_aegr":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Adm_estreg_aegr.SelectedItem;
                            cboG1Adm_estreg_aegr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
                    case "dpkG1Adm_fecsol_aegr":
                        txtG1Adm_fecsol_aegr.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecsol_aegr);
                        break;
                    case "dpkG1Adm_fecsal_aegr":
                        txtG1Adm_fecsal_aegr.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecsal_aegr);
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
                            case "txtG1Adm_fecsol_aegr":
                                dpkG1Adm_fecsol_aegr.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fecsal_aegr":
                                dpkG1Adm_fecsal_aegr.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        //-------------------------------------------------
        //Formato para captura de la hora 
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
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora.");
            }
        }
        #endregion
    }
}
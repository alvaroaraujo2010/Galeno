//- MARMOTA-GENCODE: VERSION 2.0 - 24/08/2015 07:17:03 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Reportes.Utilidades;
using FacturacionMedica.VistaModelo;
using FacturacionMedica.Utilidades;
using Excel = Microsoft.Office.Interop.Excel;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmcuentacobrms
    /// </summary>
    public partial class VistaCuentaCobro : Window, ISelccionFacturas
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public bool llgObjetosCargados = false;
        public string lcrFormModoPopup = "DFL";
        public string gcrCtrF2TexBox;
        VistaModeloCuentaCobro vm = null;
        DialogVistaErrores lobDlgLogs = null;
        public String gcrExportarArchivoNombreyRuta = String.Empty;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaCuentaCobro(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloCuentaCobro;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Fcm_fecfac_mfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Sia_fecini_mfcb.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Sia_fecfin_mfcb.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                EFfcmcuentacobrms lobReg = FCMValidarCodigo.fobRegBuscarFcmcuentacobrms(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.fcm_secreg_mfcb)) { llgExiste = true; }
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
            txtG1Fcm_secreg_mfcb.Text = tcrCodigoIgTabla;
            txtG1Fcm_secreg_mfcb.Text = tcrCodigo1;
            lblFormModoPopup.Text = lcrFormModoPopup;
            fcvActivarModoEdicion(lcrFormModoPopup);
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
                    cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdConfiguracion.Visibility = Visibility.Hidden;

                    if (llgConfigModoGuardar == false)
                    {
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Visible;
                    }
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "ADD")
                    {
                        this.Close();
                    }
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "EDT")
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "EDT" && llgModoEdicion == false)
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "SAV")
                    {
                        lcrFormModoPopup = "EDT";
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
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
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        //-Clic en Boton Imprimir
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_CUENTA01": // Vista  previa cuenta facturas 

                    var lobPrnCuenta01 = new FCMImprimir();
                    lobPrnCuenta01.gcrCodigoRegistro = this.txtG1Fcm_secreg_mfcb.Text;
                    lobPrnCuenta01.gcrTipoRegistro = "CUENTA01";
                    lobPrnCuenta01.fcvEjecutar();

                    break;

                case "opPRN_CUENTA02": // Vista  previa Relacion usuarios y facturas

                    var lobPrnCuenta02 = new FCMImprimir();
                    lobPrnCuenta02.gcrCodigoRegistro = this.txtG1Fcm_secreg_mfcb.Text;
                    lobPrnCuenta02.gcrTipoRegistro = "CUENTA02";
                    lobPrnCuenta02.fcvEjecutar();

                    break;

                case "opPRN_CUENTA03": // Vista  previa Relacion usuarios y servicios en facturas

                    var lobPrnCuenta03 = new FCMImprimir();
                    lobPrnCuenta03.gcrCodigoRegistro = this.txtG1Fcm_secreg_mfcb.Text;
                    lobPrnCuenta03.gcrTipoRegistro = "CUENTA03";
                    lobPrnCuenta03.fcvEjecutar();

                    break;

            }
        }
        #endregion
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, this.txtG1Cto_seccon_cont);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            //FocusManager.SetFocusedElement(this, txtG2);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            //FocusManager.SetFocusedElement(this, txtG2);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
        }

        //-Clic en Boton Guardar registro Grilla
        private void fcvAddFacturas(object sender, RoutedEventArgs e)
        {
            String lcrIdContrato = this.txtG1Cto_seccon_cont.Text;
            String lcrCodigoEps  = this.txtG1Sia_codeps_teps.Text;
            String lcrFechaIni   = this.txtG1Sia_fecini_mfcb.Text;
            String lcrFechaFin   = this.txtG1Sia_fecfin_mfcb.Text;
            //List<SeleccionFacturas> lsFacturasSelect = null;

            var lobForm = new VistaCuentaCobroSelect(lcrIdContrato, lcrCodigoEps, lcrFechaIni, lcrFechaFin, vm.lsFacturasVista);
            lobForm.Owner = this;
            lobForm.ShowDialog();
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
            //FocusManager.SetFocusedElement(this, txtG2);
        }
        #endregion
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
                    //FocusManager.SetFocusedElement(this, txtG2);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    //FocusManager.SetFocusedElement(this, txtG2);
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
            fcvFinalizarInstanciaDatos();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloCuentaCobro();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            this.dpkG1Fcm_fecfac_mfac.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Sia_fecini_mfcb.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Sia_fecfin_mfcb.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region fcvISleeccionFacturas: cargar facturas seleccionadas
        public void fcvISleeccionFacturas(List<SeleccionFacturas> tlsSeleccionFacturas)
        {
            if (tlsSeleccionFacturas != null)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando facturas seleccionadas...", "CENTRO");
                lobDlgAdd.Show();

                foreach (var lobReg in tlsSeleccionFacturas)
                {
                    vm.GuardarRegistroFactura(lobReg);
                }

                lobDlgAdd.Close();
                // Sumatoria
                vm.fcvSumatoriaCuentaCobro();
            }
        }
        #endregion
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Fcm_secreg_mfcb":
                    this.txtG1Fcm_secreg_mfcb.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    this.txtG1Sia_codeps_teps.Text = String.Empty;
                    this.txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    this.txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        #region CTO_SECCON_CONT : Maestro contratos con  EPS o aseguradores
        private void txtG1Cto_seccon_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Cto_seccon_cont_Browser();
            }
        }
        private void cmdG1Cto_seccon_cont_Click(object sender, RoutedEventArgs e)
        {
            txtG1Cto_seccon_cont_Browser();
        }
        private void txtG1Cto_seccon_cont_Browser()
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
            gcrCtrF2TexBox = "txtG1Cto_seccon_cont";
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
        #region KeyDown para campos con F2 Tabla: FCMCUENTACOBRDE
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos":
                    lcrFiltro = "TODOS";
                    break;

                case "opAbierto":
                    lcrFiltro = "1";
                    break;

                case "opCerrado":
                    lcrFiltro = "2";
                    break;

                case "opAnulado":
                    lcrFiltro = "3";
                    break;
            }
            Browser01Ex frbro = new Browser01Ex("FCM", "FCMCUENTACOBRMS", lcrFiltro, "Cuentas de cobro facturación...");
            gcrCtrF2TexBox = "txtG1Fcm_secreg_mfcb";
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
                        case "cboG1Fcm_tipfac_mfcb":
                            txtG1Fcm_tipfac_mfcb.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_tipfac_mfcb.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_tipfac_mfcb.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Fcm_tipfac_mfcb":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Fcm_tipfac_mfcb.SelectedItem;
                            cboG1Fcm_tipfac_mfcb.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
                    case "dpkG1Fcm_fecfac_mfac":
                        txtG1Fcm_fecfac_mfac.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Fcm_fecfac_mfac);
                        break;
                    case "dpkG1Sia_fecini_mfcb":
                        txtG1Sia_fecini_mfcb.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Sia_fecini_mfcb);
                        break;
                    case "dpkG1Sia_fecfin_mfcb":
                        txtG1Sia_fecfin_mfcb.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Sia_fecfin_mfcb);
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
                            case "txtG1Fcm_fecfac_mfac":
                                dpkG1Fcm_fecfac_mfac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Sia_fecini_mfcb":
                                dpkG1Sia_fecini_mfcb.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Sia_fecfin_mfcb":
                                dpkG1Sia_fecfin_mfcb.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // IMPRIMIR O EXPORTAR A EXCEL
        //-------------------------------------------------
        #region fcvExportarForamtoExcel: Exportar a excel opcion desde menu
        private void fcvExportarForamtoExcel(object sender, RoutedEventArgs e)
        {
            if (flgDialogoExportarPlantilla())
            {
                Thread.Sleep(500);
                flgExportarFormatoExcel();
                MessageBox.Show("Exportación de datos finalizada!!");
            }
        }
        #endregion
        #region flgDialogoExportarPlantilla: Dialogo Exportar plantilla
        public bool flgDialogoExportarPlantilla()
        {
            var llgReturn = false;
            SaveFileDialog lsaveFileDialog = new SaveFileDialog();
            lsaveFileDialog.Title = "Exportar datos a Microsoft Excel...";
            lsaveFileDialog.Filter = "Exportar datos a Microsoft Excel  (.xls)|*.xls|All Files (*.*)|*.*";
            lsaveFileDialog.DefaultExt = ".xls"; // Extencion de archivos
            lsaveFileDialog.FilterIndex = 1;
            bool? llgSelectOK = lsaveFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                gcrExportarArchivoNombreyRuta = lsaveFileDialog.FileName;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgExportarFormatoExcel: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcel()
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Exportando datos a Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            int i = 2;

            Excel.Application lobApp;
            Excel.Workbook lobLibroTrabajo;
            Excel.Worksheet lobHoja;

            lobApp = new Excel.Application();
            lobLibroTrabajo = lobApp.Workbooks.Add();
            lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);

            // poner formato texto a la hoja
            //var lobCells = (Excel.Range)lobHoja.Cells;
            //lobCells.NumberFormat = "@";

            // Encabezado del informe
            lobHoja.Cells[1, 1] = "Numero Admison";
            lobHoja.Cells[1, 2] = "Numero Factura";
            lobHoja.Cells[1, 3] = "Id sistema";
            lobHoja.Cells[1, 4] = "Tipo Id";
            lobHoja.Cells[1, 5] = "Identificación";
            lobHoja.Cells[1, 6] = "Nombre Usuario";
            lobHoja.Cells[1, 7] = "Fecha Factura";
            lobHoja.Cells[1, 8] = "Valor Copago";
            lobHoja.Cells[1, 9] = "Cuota moderadora";
            lobHoja.Cells[1, 10] = "Cargo al usuaurio";
            lobHoja.Cells[1, 11] = "Valor Factura";

            //Recorremos el temporal y rellenando la hoja de trabajo
            foreach (var lobReg in vm.TmpG2ListaBrow)
            {
                #region Campos
                lobHoja.Cells[i, 2].NumberFormat = "@";
                lobHoja.Cells[i, 5].NumberFormat = "@";
                lobHoja.Cells[i, 7].NumberFormat = "@";

                lobHoja.Cells[i, 1] = lobReg.Adm_secadm_rgad.Trim();
                lobHoja.Cells[i, 2] = lobReg.Fcm_numfac_mfac.Trim();
                lobHoja.Cells[i, 3] = lobReg.Sia_idesec_usua.Trim();
                lobHoja.Cells[i, 4] = lobReg.Sia_tipide_tide.Trim();
                lobHoja.Cells[i, 5] = lobReg.Sia_nroide_usua.Trim();
                lobHoja.Cells[i, 6] = lobReg.Sia_nomusu_usua.Trim();
                lobHoja.Cells[i, 7] = lobReg.Fcm_fecfac_mfac.ToShortDateString();
                lobHoja.Cells[i, 8] = lobReg.Fcm_valcpa_dfac.ToString();
                lobHoja.Cells[i, 9] = lobReg.Fcm_valcmo_dfac.ToString();
                lobHoja.Cells[i, 10] = lobReg.Fcm_valusu_dfac.ToString();
                lobHoja.Cells[i, 11] = lobReg.Fcm_valfac_dfac.ToString();
                #endregion
                i++;
            }
            lobLibroTrabajo.SaveAs(@gcrExportarArchivoNombreyRuta, Excel.XlFileFormat.xlWorkbookNormal);
            lobLibroTrabajo.Close(true);
            lobApp.Quit();

            lobDlgAdd.Close();

            return llgreturn;
        }
        #endregion

    }
}
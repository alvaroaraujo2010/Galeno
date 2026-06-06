//- MARMOTA-GENCODE: VERSION 2.0 - 01/07/2013 02:04:52 PM
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
using Admision.VistaModelo;
using ConfigAsistencial.Vista;

namespace Admision.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public partial class VistaAdmadmisiones : Window, INotificacion
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public string lcrFormModoPopup = "DFL";
        Aplicacion oApp = Aplicacion.Instancia();
        ControlNotificaciones lobCrtNotifi = null;
        VistaModeloAdmadmisiones vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaAdmadmisiones(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();
            vm = this.DataContext as VistaModeloAdmadmisiones; //Binding con el Vista Modelo
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Adm_fecadm_rgad.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fechos_rgad.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fecrem_rgad.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoIgTabla, tcrCodigo1, tcrCodigo2, tcrCodigo3);
            }
            fcvCargarVistaNotificaciones();
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
                EFadmregadmision lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmision(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_secadm_rgad)) { llgExiste = true; }
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
            txtG1Adm_secadm_rgad.Text = tcrCodigoIgTabla;
            txtG1Cit_codasi_mcit.Text = tcrCodigo1;
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

                    if (llgConfigModoGuardar == false)
                    {
                        cmdGuardar.Visibility = Visibility.Hidden;
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
        // fcvCargarVistaNotificaciones: Cargar vista notificaciones
        //-------------------------------------------------
        #region fcvCargarVistaNotificaciones
        private void fcvCargarVistaNotificaciones()
        {
            lobCrtNotifi = new ControlNotificaciones();
            lobCrtNotifi.Height = 570;
            Canvas.SetLeft(lobCrtNotifi, -3);
            this.cnvPropSelect.Children.Add(lobCrtNotifi);

            if (this.lobCrtNotifi.flgCargarVistaNotificaciones(oApp.gcrUsuCodigoPerfil, "ADM", "ADM001"))
            {
                foreach (var lobreg in this.lobCrtNotifi.tmpObjetos)
                {
                    var lobBoton = lobreg.RefObjeto as TilesNotificacion;
                    lobBoton.MouseDown += new MouseButtonEventHandler(fcvVistaNotificacionClick);
                    lobBoton.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
                }
                this.lobCrtNotifi.fcvActalizarVistaNotificaciones();
            }
        }
        #endregion
        #region fcvVistaNotificacion
        private void fcvVistaNotificacionClick(object sender, RoutedEventArgs e)
        {
            fcvVistaNotificacion(sender);
        }
        #endregion
        #region fcvTilesTouchDown
        private void fcvTilesTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvVistaNotificacion(sender);

        }
        #endregion
        #region fcvVistaNotificacion
        private void fcvVistaNotificacion(object sender)
        {
            var lobTile = sender as TilesNotificacion;
            DialogVistaNotificaciones lobNotif = new DialogVistaNotificaciones();
            lobNotif.Owner = this;
            lobNotif.fcvCargarVista(lobTile.ToolTip.ToString(), oApp.gcrUsuCodigoPerfil,
                                    oApp.gcrUsuIdUsuario, lobTile.gcrIdModulo, lobTile.gcrTipoNotificacion);
            lobNotif.fcvActivarVista();

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

        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
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
            fcvActivarModoEdicion("CON");
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
                    FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Adm_pacemb_rgad);
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
        //-----------------------------------------
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
                //this.objControlVistaAdmitido.fcvCargarVista(this.txtG1Adm_secadm_rgad.Text);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarModoEdicion");
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloAdmadmisiones();
            // Quitar referencias
            dpkG1Adm_fecadm_rgad.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fechos_rgad.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fecrem_rgad.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
        #region fcvBrowserBuscar: llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos":
                    lcrFiltro = "1*TODOS"; // Admitodos y todos los estados 
                    break;

                case "opAbierto":
                    lcrFiltro = "1*1"; // Admitodos solo abiertos
                    break;

                case "opCerrado":
                    lcrFiltro = "1*2"; // Admitodos solo cerrados
                    break;

                case "opAnulado":
                    lcrFiltro = "1*3"; // Admitodos solo anulados
                    break;

                case "opDatosUsuario":
                    lcrFiltro = "NA"; // Vista del registro de usuario
                    if (!String.IsNullOrWhiteSpace(this.txtG1Sia_idesec_usua.Text))
                    {
                        //- Maestro de Usuarios Atendidos
                        VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos("DFL", this.txtG1Sia_idesec_usua.Text, "", "", "");
                        lobSIA002.ShowDialog();
                    }
                    break;
            }
            if (lcrFiltro != "NA")
            {
                Browser02 frbro = new Browser02("ADM", "ADMREGADMISION", 1, lcrFiltro, "Admisión de pacientes...");
                gcrCtrF2TexBox = "txtG1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
            }

        }
        #endregion
        #region fcvBrowsUsuarios Buscar usuarios para realizar admision
        private void fcvBrowsUsuarios(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opUSContrato": // Buscar en maestro de contrato

                    Browser01 frbroCt = new Browser01("CTO", "CTOMAEAFILIADOS", "", "Maestro afiliados en contratos...");
                    gcrCtrF2TexBox = "ADD-DESDE-MAESTRO-CONTRATO";
                    frbroCt.Owner = this;
                    frbroCt.ShowDialog();

                    break;

                case "opUSAdmitidos": // Buscar en maestro de admitidos
                    Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes atendidos...");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    frbro.Owner = this;
                    frbro.ShowDialog();
                    break;

                case "opUSCrear": // Crear Usuario en base de datos
                    //- Maestro de Usuarios Atendidos
                    var lcrAccion = !String.IsNullOrWhiteSpace(this.txtG1Sia_nroide_usua.Text) ? "EDT" : "DFL";
                    VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos(lcrAccion, "", this.txtG1Sia_nroide_usua.Text, "", "");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    lobSIA002.Owner = this;
                    lobSIA002.ShowDialog();
                    break;
            }
        }
        #endregion
        #region fcvVistaDatosTriage Mostrar la vista de los datos Triage 
        private void fcvVistaDatosTriage(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtG1Adm_nroreg_tria.Text))
            {
                //- Maestro de Usuarios Atendidos
                var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(this.txtG1Adm_nroreg_tria.Text);
                if (tmp != null)
                {
                    VistaValoracionTriage lobTriage = new VistaValoracionTriage("DFL", this.txtG1Adm_nroreg_tria.Text, "", "", "");
                    lobTriage.ShowDialog();
                }
                else
                {
                    if (vm.GlgSIS_ModoEdicion == true)
                    {
                        txtG1Adm_nroreg_tria_Browser(); // Mostrar el Browse de busqueda
                    }
                }
            }
            else
            {
                if (vm.GlgSIS_ModoEdicion == true)
                {
                    txtG1Adm_nroreg_tria_Browser(); // Mostrar el Browse de busqueda
                }
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  INotificacion Y fcvBuscarRegistro  recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region fcvBuscarRegistro: Metodo que recoge el valor Key desde browser F2
        #region fcvBuscarRegistro: Retorno el metodo seleccion Browser
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Adm_secadm_rgad":
                    txtG1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG1Sia_areing_aser":
                    txtG1Sia_areing_aser.Text = tcrCodigo;
                    break;

                case "txtG1Sia_idesec_usua":
                    txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG1Cit_codasi_mcit":
                    txtG1Cit_codasi_mcit.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Hos_codcam_caho":
                    txtG1Hos_codcam_caho.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixing_tdia":
                    txtG1Sia_dixing_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idemun_muni":
                    txtG1Sis_idemun_muni.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codips_tips":
                    txtG1Sia_codips_tips.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codcat_ceat":
                    txtG1Sia_codcat_ceat.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":

                    this.txtG1Sia_nroide_usua.Text = String.Empty;
                    this.txtG1Cto_seccon_cont.Text = String.Empty;
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "txtG1Adm_nroreg_tria":
                    this.txtG1Adm_nroreg_tria.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipdxp_tdix":
                    txtG1Sia_tipdxp_tdix.Text = tcrCodigo;
                    break;

                case "txtG1Sis_numide_sitr":
                    txtG1Sis_numide_sitr.Text = tcrCodigo;
                    break;

                case "ADD-DESDE-MAESTRO-CONTRATO":
                    //- Maestro de Usuarios Atendidos
                    var llgOk = true;
                    var lobReg = CTOValidarCodigo.fobRegBuscarCtomaeafiliados(tcrCodigo);
                    if (lobReg != null)
                    {
                        var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(lobReg.sia_nroide_usua);
                        if (tmp != null)
                        {
                            llgOk = false;
                            txtG1Sia_idesec_usua.Text = tmp.sia_idesec_usua;
                        }
                    }
                    if (llgOk == true)
                    {
                        VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos("ADAF", "", tcrCodigo, "", "");
                        gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                        lobSIA002.Owner = this;
                        lobSIA002.ShowDialog();
                    }
                    break;
            }
        }
        #endregion
        #region KeyDown para campos con F2 Tabla: ADMREGADMISION
        #region SIA_AREING_ASER : Areas prestacion de servicios
        private void txtG1Sia_areing_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_areing_aser_Browser();
            }
        }
        private void txtG1Sia_areing_aser_Click(object sender, RoutedEventArgs e)
        {
             txtG1Sia_areing_aser_Browser();
        }
        private void txtG1Sia_areing_aser_Browser()
        {  
                Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
                gcrCtrF2TexBox = "txtG1Sia_areing_aser";
                frbro.Owner = this;
                frbro.ShowDialog();
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
        #region CIT_CODASI_MCIT : Asignación de citas a Pacientes
        private void txtG1Cit_codasi_mcit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CIT", "CITMAESASIGCITA", "", "Asignación de citas a Pacientes...");
                gcrCtrF2TexBox = "txtG1Cit_codasi_mcit";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODARE_ASER : Areas prestacion de servicios
        private void txtG1Sia_codare_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codare_aser_Browser();
            }
        }
        private void cmdG1Sia_codare_aser_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codare_aser_Browser();            
        }
        private void txtG1Sia_codare_aser_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codare_aser";
            frbro.Owner = this;
            frbro.ShowDialog();              
        }
        #endregion
        #region HOS_CODCAM_CAHO : Camas por area prestacion servicios
        private void txtG1Hos_codcam_caho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hos_codcam_caho_Browser();
            }
        }
        private void txtG1Hos_codcam_caho_Click(object sender, RoutedEventArgs e)
        {
                txtG1Hos_codcam_caho_Browser();
        }
        private void txtG1Hos_codcam_caho_Browser()
        {
                Browser01 frbro = new Browser01("HOS", "HOSCAMASAREAS", "", "Camas por area prestacion servicios...");
                gcrCtrF2TexBox = "txtG1Hos_codcam_caho";
                frbro.Owner = this;
                frbro.ShowDialog();
        }
        #endregion
        #region SIA_DIXING_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixing_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_dixing_tdia_Browser();
            }
        }
        private void txtG1Sia_dixing_tdia_Click(object sender, RoutedEventArgs e)
        {
                txtG1Sia_dixing_tdia_Browser();
        }
        private void txtG1Sia_dixing_tdia_Browser()
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixing_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
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
        private void txtG1Cto_seccon_cont_Click(object sender, RoutedEventArgs e)
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
        private void txtG1Sia_codeps_teps_Click(object sender, RoutedEventArgs e)
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
                txtG1Sia_codpfa_prof_Browser();
            }
        }
        private void txtG1Sia_codpfa_prof_Click(object sender, RoutedEventArgs e)
        {
           txtG1Sia_codpfa_prof_Browser();
        }
        private void txtG1Sia_codpfa_prof_Browser()
        {
                Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
                gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
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
        private void txtG1Sis_idemun_muni_Click(object sender, RoutedEventArgs e)
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
        #region SIA_CODIPS_TIPS : Lista de IPS
        private void txtG1Sia_codips_tips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codips_tips_Browser();
            }
        }
        private void txtG1Sia_codips_tips_Click(object sender, RoutedEventArgs e)
        {
          txtG1Sia_codips_tips_Browser();
        }
        private void txtG1Sia_codips_tips_Browser()
            {
                Browser01 frbro = new Browser01("SIA", "SIATABLAIPS", "", "Lista de IPS...");
                gcrCtrF2TexBox = "txtG1Sia_codips_tips";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        #endregion
        #region SIA_CODCAT_CEAT : Lista Centros de Atención  cuando hay varias sedes en lugare
        private void txtG1Sia_codcat_ceat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                 txtG1Sia_codcat_ceat_Browser();
            }
        }
        private void txtG1Sia_codcat_ceat_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codcat_ceat_Browser();
        }
        private void txtG1Sia_codcat_ceat_Browser()
        {
                Browser01 frbro = new Browser01("SIA", "SIACENTROATEN", "", "Lista Centros de Atención  cuando hay varias sedes en lugare...");
                gcrCtrF2TexBox = "txtG1Sia_codcat_ceat";
                frbro.Owner = this;
                frbro.ShowDialog();
        }
        #endregion
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtG1Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
                gcrCtrF2TexBox = "txtG1Sis_estpro_espr";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_NROIDE_USUA : Maestro de Pacientes atendidos
        private void txtG1Sia_nroide_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
                FocusManager.SetFocusedElement(this, txtG1Adm_fecadm_rgad);
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region ADM_NROREG_TRIA : Maestro evaluación Triage
        private void txtG1Adm_nroreg_tria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_nroreg_tria_Browser();
            }
        }
        private void txtG1Adm_nroreg_tria_Browser()
        {
            var lcrFiltro = "3"; // 3 =Remision para atencion en urgencias

            Browser01Ex frbro = new Browser01Ex("ADM", "ADMTRIAGEMAESTR", lcrFiltro, "Maestro evaluación Triage...");
            gcrCtrF2TexBox = "txtG1Adm_nroreg_tria";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPDXP_TDIX : Tipo diagnostico principal
        private void txtG1Sia_tipdxp_tdix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipdxp_tdix_Browser();
            }
        }
        private void txtG1Sia_tipdxp_tdix_Click(object sender, RoutedEventArgs e)
        {
               txtG1Sia_tipdxp_tdix_Browser();
        }
        private void txtG1Sia_tipdxp_tdix_Browser()
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPODIAGPRIN", "", "Tipo diagnostico principal...");
                gcrCtrF2TexBox = "txtG1Sia_tipdxp_tdix";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        #endregion
        #region SIS_NUMIDE_SITR Tabla terceros o Adquirentes Por Nit
        private void TxtG1Sis_numide_sitr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtG1Sis_numide_sitr_Browser();
            }
        }
        private void CmdG1Sis_numide_sitr_Click(object sender, RoutedEventArgs e)
        {
            TxtG1Sis_numide_sitr_Browser();
        }
        private void TxtG1Sis_numide_sitr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS-NIT", "", "Maestro Adquiretes...");
            gcrCtrF2TexBox = "txtG1Sis_numide_sitr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #endregion
        #region INotificacion: Interface para devolver id registro notificacion
        /// <summary>
        /// <para>Devolver id registro notificacion, modulo y tipo Notificacion</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdRegNotificacion: Id registro unico en maestro de notificaciones</para>
        /// <para>tcrIdModulo: Módulo al cual se envia notificación:  MSG = Mensajes general SYS: = Grupos mensajes de sistema FCM =Facturacion</para>
        /// <para>tcrTipoNotificacion: Tipo de notificacion: ADM001 = Registro de admisión FCM001 = Autorizacion descuento en caja facturacion</para>
        /// <para>tcrRegEvento: Registro evento que genera la notificacion: puede ser Id del paciente, Numero H.Clinica, Numero admision y otros.</para>
        /// </summary>
        public void fcvINotificacion(String tcrIdRegNotificacion, String tcrIdModulo, String tcrTipoNotificacion, String tcrRegEvento)
        {
            switch (tcrTipoNotificacion)
            {
                case "ADM-ADMI-URGENCIAS":
                    // Adimision urgencias
                    //this.txtA1Adm_secadm_rgad.Text = tcrRegEvento;
                    break;

                case "ADM-ADMI-HOSPITALIZ":
                    // Adimision Hospitalizacion
                    ///this.txtA1Adm_secadm_rgad.Text = tcrRegEvento;
                    break;

                case "ADM-TRIAGE-URGENCIA":
                    // hoja de consumo viene: RegistroAdmision*RegistroHojaConsumo
                    if (vm.GlgSIS_ModoEdicion == true)
                    {
                        String[] larArray = tcrRegEvento.Split('*');
                        if (larArray.Length > 0)
                        {
                            fcvCargarDatosTriage(larArray[0].Trim());
                        }
                    }
                    break;
            }
        }
        #endregion
        #region fcvCargarDatosTriage: Cargar parametros desde registro atencion Tirage Urgencias
        public void fcvCargarDatosTriage(String tcrCodigoTriage)
        {
            var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(tcrCodigoTriage);
            if (tmp != null)
            {
                var lcrCodigoClasif = tmp.adm_clasif_tria;

                // Limpiar los campos antes de cargar datos
                this.txtG1Adm_fechos_rgad.Text = "  /  /    ";
                this.txtG1Adm_fecrem_rgad.Text = "  /  /    ";

                // Datos de la atencion paciente en triage
                vm.G1Sia_idesec_usua = tmp.sia_idesec_usua;
                vm.G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                vm.G1Sia_tipide_tide = tmp.sia_tipide_tide;
                vm.G1Sia_nroide_usua = tmp.sia_nroide_usua;
                vm.G1Sia_codeps_teps = tmp.sia_codeps_teps;
                vm.G1Sia_codcat_ceat = tmp.sia_codcat_ceat;
                vm.G1Sia_dixing_tdia = tmp.sia_coddia_tdia;
                vm.G1Adm_caucon_rgad = tmp.adm_motcon_tria;
                //vm.G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                // Parametros generales para admision
                var tmpx = ADMValidarCodigo.fobRegBuscarAdmtriagemaconfNivel(lcrCodigoClasif);
                if (tmpx != null)
                {
                    vm.G1Adm_codoad_toad = tmpx.adm_codoad_toad;
                    vm.G1Sia_codare_aser = tmpx.sia_codare_aser;
                    vm.G1Sia_areing_aser = tmpx.sia_areing_aser;
                    vm.G1Fcm_codcpr_cpro = tmpx.fcm_codcpr_cpro;
                    vm.G1Adm_codtat_tatn = tmpx.adm_codtat_tatn;
                    vm.G1Adm_codcex_tcex = tmpx.adm_codcex_tcex;
                    vm.G1Sia_tipdxp_tdix = "1";
                }
                this.txtG1Adm_nroreg_tria.Text = tmp.adm_nroreg_tria;
            }
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
                        case "cboG1Adm_pacemb_rgad":
                            txtG1Adm_pacemb_rgad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_pacemb_rgad.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_pacemb_rgad.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_reingr_rgad":
                            txtG1Adm_reingr_rgad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_reingr_rgad.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_reingr_rgad.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_codoad_toad":
                            txtG1Adm_codoad_toad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_codoad_toad.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_codoad_toad.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_codtat_tatn":
                            txtG1Adm_codtat_tatn.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_codtat_tatn.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_codtat_tatn.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_codcex_tcex":
                            txtG1Adm_codcex_tcex.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_codcex_tcex.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_codcex_tcex.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_tipusu_regi":
                            txtG1Sia_tipusu_regi.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_tipusu_regi.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_tipusu_regi.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_tipafi_tafi":
                            txtG1Sia_tipafi_tafi.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_tipafi_tafi.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_tipafi_tafi.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_nivsbn_nsbn":
                            txtG1Sia_nivsbn_nsbn.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_nivsbn_nsbn.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_nivsbn_nsbn.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_tippob_tpob":
                            txtG1Sia_tippob_tpob.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_tippob_tpob.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_tippob_tpob.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_nivcon_ncon":
                            txtG1Sia_nivcon_ncon.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_nivcon_ncon.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_nivcon_ncon.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_pacemb_rgad":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Adm_pacemb_rgad.SelectedItem;
                            cboG1Adm_pacemb_rgad.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Adm_reingr_rgad":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Adm_reingr_rgad.SelectedItem;
                            cboG1Adm_reingr_rgad.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Adm_codoad_toad":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Adm_codoad_toad.SelectedItem;
                            cboG1Adm_codoad_toad.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Adm_codtat_tatn":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Adm_codtat_tatn.SelectedItem;
                            cboG1Adm_codtat_tatn.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Adm_codcex_tcex":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Adm_codcex_tcex.SelectedItem;
                            cboG1Adm_codcex_tcex.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Sia_tipusu_regi":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Sia_tipusu_regi.SelectedItem;
                            cboG1Sia_tipusu_regi.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
                            break;
                        case "txtG1Sia_tipafi_tafi":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Sia_tipafi_tafi.SelectedItem;
                            cboG1Sia_tipafi_tafi.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Sia_nivsbn_nsbn":
                            CrtForms.ListaComboBox lobG1ComboBox10 = (CrtForms.ListaComboBox)cboG1Sia_nivsbn_nsbn.SelectedItem;
                            cboG1Sia_nivsbn_nsbn.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox10.ListaValoresSel);
                            break;
                        case "txtG1Sia_tippob_tpob":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)cboG1Sia_tippob_tpob.SelectedItem;
                            cboG1Sia_tippob_tpob.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
                            break;
                        case "txtG1Sia_nivcon_ncon":
                            CrtForms.ListaComboBox lobG1ComboBox12 = (CrtForms.ListaComboBox)cboG1Sia_nivcon_ncon.SelectedItem;
                            cboG1Sia_nivcon_ncon.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox12.ListaValoresSel);
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
                    case "dpkG1Adm_fecadm_rgad":
                        txtG1Adm_fecadm_rgad.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecadm_rgad);
                        break;
                    case "dpkG1Adm_fechos_rgad":
                        txtG1Adm_fechos_rgad.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fechos_rgad);
                        break;
                    case "dpkG1Adm_fecrem_rgad":
                        txtG1Adm_fecrem_rgad.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecrem_rgad);
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
                            case "txtG1Adm_fecadm_rgad":
                                dpkG1Adm_fecadm_rgad.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fechos_rgad":
                                dpkG1Adm_fechos_rgad.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fecrem_rgad":
                                dpkG1Adm_fecrem_rgad.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        //-------------------------------------------------
        // Actualizar datos de la admision en control
        //-------------------------------------------------
        #region Cargar coontrol al cambiar id adimision
        private void txtG1Adm_secadm_rgadTextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados == true)
            {
                if (!String.IsNullOrWhiteSpace(this.txtG1Adm_secadm_rgad.Text))
                {
                    this.objControlVistaAdmitido.fcvCargarVista(this.txtG1Adm_secadm_rgad.Text);
                }
                else 
                {
                    this.objControlVistaAdmitido.fcvLimpiarVista();
                }
            }
        }
        #endregion
        #region cargar al guardar cambios
        private void txtG1GcrSIS_FormModoTextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados == true)
            {
                if (txtG1GcrSIS_FormModo.Text == "SAV")
                {
                    //txtG1GcrSIS_FormModo.Text = String.Empty;
                    this.objControlVistaAdmitido.fcvCargarVista(this.txtG1Adm_secadm_rgad.Text);
                }
            }
        }
        #endregion

    }
}
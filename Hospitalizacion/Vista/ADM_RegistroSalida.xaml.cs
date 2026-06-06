//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 08:13:33 AM
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
    /// Descripcion para la Vista de  la tabla: admregistegreso
    /// </summary>
    public partial class VistaRegistrosalida : Window, INotificacion
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
        Aplicacion oApp = Aplicacion.Instancia();
        ControlNotificaciones lobCrtNotifi = null;
        VistaModeloRegistroSalida gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaRegistrosalida(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloRegistroSalida;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Adm_fecegr_regr.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fecmue_regr.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Adm_fecpar_regr.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Adm_fecnac_regn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Adm_fecmue_regn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoIgTabla, tcrCodigo1, tcrCodigo2, tcrCodigo3);
            }
            fcvCargarVistaNotificaciones();
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

            if (this.lobCrtNotifi.flgCargarVistaNotificaciones(oApp.gcrUsuCodigoPerfil, "ADM", "ADM002"))
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
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            var llgExiste = false;
            if (!String.IsNullOrWhiteSpace(tcrCodigoIgTabla))
            {
                EFadmregistegreso lobReg = ADMValidarCodigo.fobRegBuscarAdmregistegreso(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_secegr_regr)) { llgExiste = true; }
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
            txtG1Adm_secegr_regr.Text = tcrCodigoIgTabla;
            txtG1Adm_secadm_rgad.Text = tcrCodigo1;
            txtG1Adm_secaut_aegr.Text = tcrCodigo2;
            lblFormModoPopup.Text = lcrFormModoPopup;
            fcvActivarModoEdicion(lcrFormModoPopup);
            if (gobObjVModelo.GlgSIS_ModoEdicion == true) { gobObjVModelo.CanSAV(); }
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
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Adm_secadm_rgad);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Adm_fecnac_regn);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Adm_secadm_rgad);
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
            FocusManager.SetFocusedElement(this, txtG2Adm_fecnac_regn);
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
            FocusManager.SetFocusedElement(this, txtG2Adm_fecnac_regn);
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
                    FocusManager.SetFocusedElement(this, txtG1Adm_secadm_rgad);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Adm_secadm_rgad);
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
                    //cmdAdicionar.Visibility = Visibility.Visible;
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
                            //cmdAdicionar.Visibility = Visibility.Visible;
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
        // fcvINotificacion y fcvBuscarRegistro valor Key desde browser F2
        //-------------------------------------------------
        #region fcvBuscarRegistro: Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Adm_secegr_regr":
                    txtG1Adm_secegr_regr.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixing_tdia":
                    txtG1Sia_dixing_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixre1_tdia":
                    txtG1Sia_dixre1_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixre2_tdia":
                    txtG1Sia_dixre2_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixre3_tdia":
                    txtG1Sia_dixre3_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixcom_tdia":
                    txtG1Sia_dixcom_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixmue_tdia":
                    txtG1Sia_dixmue_tdia.Text = tcrCodigo;
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

                case "txtG1Adm_secaut_aegr":
                    txtG1Adm_secaut_aegr.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixsal_tdia":
                    txtG1Sia_dixsal_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipdxp_tdix":
                    txtG1Sia_tipdxp_tdix.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipdis_tdis":
                    txtG1Sia_tipdis_tdis.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "txtG2Sia_dixmue_tdia":
                    txtG2Sia_dixmue_tdia.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codsex_sexo":
                    txtG2Sis_codsex_sexo.Text = tcrCodigo;
                    break;

                case "txtG2Sia_dixnac_tdia":
                    txtG2Sia_dixnac_tdia.Text = tcrCodigo;
                    break;

            }
        }
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
            String[] larArray = null;
            switch (tcrTipoNotificacion)
            {
                case "ADM-ADMI-URGENCIAS":
                    // Adimision urgencias
                    this.txtG1Adm_secegr_regr.Text = tcrRegEvento;
                    break;

                case "ADM-ADMI-HOSPITALIZ":
                    // Adimision Hospitalizacion
                    this.txtG1Adm_secegr_regr.Text = tcrRegEvento;
                    break;

                case "HOS-AUTORI-SALIDA":
                    // Regitro autorizacion salida
                    larArray = tcrRegEvento.Split('*');
                    this.txtG1Adm_secegr_regr.Text = larArray[0];
                    break;
            }

        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // ADMREGISTEGRESO : Maestro registro egresos de hospitalizacion
        #region KeyDown para campos con F2 Tabla: ADMREGISTEGRESO
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
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixing_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXRE1_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixre1_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixre1_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXRE2_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixre2_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixre2_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXRE3_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixre3_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixre3_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXCOM_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixcom_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixcom_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXMUE_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixmue_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixmue_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
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
                Browser02 frbro = new Browser02("ADM", "ADMREGADMISION", 3, "1*1", "Admisiones abiertas...");
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
                Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Configuracion para los tipos de identificacion de los uauari...");
                gcrCtrF2TexBox = "txtG1Sia_tipide_tide";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region ADM_SECAUT_AEGR : Ordenes de salida o egreso a pacientes
        private void txtG1Adm_secaut_aegr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("ADM", "ADMORDENDSALIDA", "", "Ordenes de salida o egreso a pacientes...");
                gcrCtrF2TexBox = "txtG1Adm_secaut_aegr";
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
        #region SIA_DIXSAL_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_dixsal_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG1Sia_dixsal_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
                Browser01 frbro = new Browser01("SIA", "SIATIPODIAGPRIN", "", "Tipo diagnostico principal...");
                gcrCtrF2TexBox = "txtG1Sia_tipdxp_tdix";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_TIPDIS_TDIS : Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi
        private void txtG1Sia_tipdis_tdis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPDISCAPACI", "", "Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi...");
                gcrCtrF2TexBox = "txtG1Sia_tipdis_tdis";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        // ADMREGNACIMIENT : Maestro registro nacimiento en servicio hospitalizacion
        #region KeyDown para campos con F2 Tabla: ADMREGNACIMIENT
        #region SIA_DIXMUE_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_dixmue_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG2Sia_dixmue_tdia";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIS_CODSEX_SEXO : Sexo Personas
        private void txtG2Sis_codsex_sexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISTABLASEXOS", "", "Sexo Personas...");
                gcrCtrF2TexBox = "txtG2Sis_codsex_sexo";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_DIXNAC_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG2Sia_dixnac_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
                gcrCtrF2TexBox = "txtG2Sia_dixnac_tdia";
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
            Browser02 frbro = new Browser02("ADM", "ADMREGISTEGRESO", 1, lcrFiltro, "Maestro registro egresos de hospitalizacion...");
            gcrCtrF2TexBox = "txtG1Adm_secegr_regr";
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
                        case "cboG1Adm_estsal_regr":
                            txtG1Adm_estsal_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_estsal_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_estsal_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_dessal_regr":
                            txtG1Adm_dessal_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_dessal_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_dessal_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_tipmue_regr":
                            txtG1Adm_tipmue_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_tipmue_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_tipmue_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_aparto_regr":
                            txtG1Adm_aparto_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_aparto_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_aparto_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_tippar_regr":
                            txtG1Adm_tippar_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_tippar_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_tippar_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_actpar_regr":
                            txtG1Adm_actpar_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_actpar_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_actpar_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_contrl_regr":
                            txtG1Adm_contrl_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_contrl_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_contrl_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Adm_estnac_regn":
                            txtG2Adm_estnac_regn.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Adm_estnac_regn.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Adm_estnac_regn.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Adm_tipmue_regn":
                            txtG2Adm_tipmue_regn.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Adm_tipmue_regn.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Adm_tipmue_regn.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_estsal_regr":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Adm_estsal_regr.SelectedItem;
                            cboG1Adm_estsal_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Adm_dessal_regr":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Adm_dessal_regr.SelectedItem;
                            cboG1Adm_dessal_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Adm_tipmue_regr":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Adm_tipmue_regr.SelectedItem;
                            cboG1Adm_tipmue_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Adm_aparto_regr":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Adm_aparto_regr.SelectedItem;
                            cboG1Adm_aparto_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Adm_tippar_regr":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Adm_tippar_regr.SelectedItem;
                            cboG1Adm_tippar_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Adm_actpar_regr":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Adm_actpar_regr.SelectedItem;
                            cboG1Adm_actpar_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Adm_contrl_regr":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Adm_contrl_regr.SelectedItem;
                            cboG1Adm_contrl_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG2Adm_estnac_regn":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Adm_estnac_regn.SelectedItem;
                            cboG2Adm_estnac_regn.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Adm_tipmue_regn":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Adm_tipmue_regn.SelectedItem;
                            cboG2Adm_tipmue_regn.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
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
                    case "dpkG1Adm_fecegr_regr":
                        txtG1Adm_fecegr_regr.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecegr_regr);
                        break;
                    case "dpkG1Adm_fecmue_regr":
                        txtG1Adm_fecmue_regr.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecmue_regr);
                        break;
                    case "dpkG1Adm_fecpar_regr":
                        txtG1Adm_fecpar_regr.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecpar_regr);
                        break;
                    case "dpkG2Adm_fecnac_regn":
                        txtG2Adm_fecnac_regn.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG2Adm_fecnac_regn);
                        break;
                    case "dpkG2Adm_fecmue_regn":
                        txtG2Adm_fecmue_regn.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG2Adm_fecmue_regn);
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
                            case "txtG1Adm_fecegr_regr":
                                dpkG1Adm_fecegr_regr.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fecmue_regr":
                                dpkG1Adm_fecmue_regr.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fecpar_regr":
                                dpkG1Adm_fecpar_regr.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG2Adm_fecnac_regn":
                                dpkG2Adm_fecnac_regn.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG2Adm_fecmue_regn":
                                dpkG2Adm_fecmue_regn.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
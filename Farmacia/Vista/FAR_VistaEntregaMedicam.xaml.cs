//- MARMOTA-GENCODE: VERSION 2.0 - 04/11/2017 06:08:41 PM
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
using Farmacia.VistaModelo;
using Farmacia.Utilidades;
using Farmacia.Vista;
using Sistema.Modelo;
using ConfigAsistencial.Vista;
using System.Windows.Media.Animation;

namespace Farmacia.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: farmovmedicamma
    /// </summary>
    public partial class VistaEntregaMedica : Window, INotificacion
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
        public bool glgVistPropiedades = false;
        VistaModeloEntregaMedica vm = null;
        DialogVistaErrores lobDlgLogs = null;
        ControlNotificaciones lobCrtNotifi = null;
        DialogVistaNotificaciones lobNotif = null;
        Aplicacion oApp = Aplicacion.Instancia();
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaEntregaMedica()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloEntregaMedica;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Far_gesfec_fams.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            fcvCargarVistaNotificaciones();
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

            //var myGridLengthConverter = new GridLengthConverter();
            //this.grdCol1.Width = (System.Windows.GridLength)myGridLengthConverter.ConvertFromString("200");
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
            FocusManager.SetFocusedElement(this, this.txtG1Cto_seccon_cont);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Inv_secart_inar);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, this.txtG1Cto_seccon_cont);
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
            FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
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
            FocusManager.SetFocusedElement(this, txtG2Inv_secart_inar);
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
                    FocusManager.SetFocusedElement(this, txtG2Inv_secart_inar);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG2Inv_secart_inar);
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
                    //cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdCancelar.Visibility = Visibility.Hidden;
                }
                //cmdConfirmar.Visibility = Visibility.Hidden;

                switch (tcrEstado)
                {
                    case "1":

                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            //cmdConfirmar.Visibility = Visibility.Visible;
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
                        //cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    case "3":
                        //cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    default:
                        // se asume modo inicial vacio
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdGuardar.Visibility = Visibility.Visible;
                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            //cmdConfirmar.Visibility = Visibility.Visible;
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
        // fcvCargarVistaNotificaciones: Cargar vista notificaciones
        //-------------------------------------------------
        #region fcvCargarVistaNotificaciones
        private void fcvCargarVistaNotificaciones()
        {
            lobCrtNotifi = new ControlNotificaciones();
            lobCrtNotifi.Height = 610;
            Canvas.SetLeft(lobCrtNotifi, -3);
            this.cnvPropNotific.Children.Add(lobCrtNotifi);

            if (this.lobCrtNotifi.flgCargarVistaNotificaciones(oApp.gcrUsuCodigoPerfil, "FAR", vm.gcrIdVistaModeloForm))
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
            if (vm.GlgSIS_ModoEdicion == false)
            {
                var lobTile = sender as TilesNotificacion;
                lobNotif = new DialogVistaNotificaciones();
                lobNotif.Owner = this;
                lobNotif.fcvCargarVista(lobTile.ToolTip.ToString(), oApp.gcrUsuCodigoPerfil,
                                        oApp.gcrUsuIdUsuario, lobTile.gcrIdModulo, lobTile.gcrTipoNotificacion);
                lobNotif.fcvActivarVista();
            }

        }
        private void fcvCerrarVistaNotifcaciones()
        {
            if (lobNotif != null)
            {
                lobNotif.fcvCerrarVista();
            }
        }
        #endregion
        #region fcvLiberarVistaNotificaciones
        private void fcvLiberarVistaNotificaciones()
        {
            foreach (var lobreg in this.lobCrtNotifi.tmpObjetos)
            {
                var lobBoton = lobreg.RefObjeto as TilesNotificacion;
                lobBoton.MouseDown -= new MouseButtonEventHandler(fcvVistaNotificacionClick);
                lobBoton.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloEntregaMedica();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            dpkG1Far_gesfec_fams.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Far_nroreg_fams":
                    txtG1Far_nroreg_fams.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codusx_usux":
                    txtG1Sys_codusx_usux.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":
                    this.txtG1Sia_nroide_usua.Text = String.Empty;
                    this.txtG1Cto_seccon_cont.Text = String.Empty;
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_nroreg_hcms":
                    txtG1Hcl_nroreg_hcms.Text = tcrCodigo;
                    break;

                case "txtG1Adm_secadm_rgad":
                    txtG1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sia_idesec_usua":
                    txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipide_tide":
                    txtG1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codalm_inal":
                    txtG1Inv_codalm_inal.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_tiptur_hctu":
                    txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codusu_usux":
                    txtG1Sys_codusu_usux.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG2Inv_secart_inar":
                    txtG2Inv_secart_inar.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codaux_inar":
                    this.txtG2Inv_codaux_inar.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_idesec_sips":
                    txtG2Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codume_sium":
                    txtG2Sis_codume_sium.Text = tcrCodigo;
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

                case "BROWSER":
                    gcrCtrF2TexBox = tcrCodigo;
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
            if (vm.GlgSIS_ModoEdicion == false)
            {
                switch (tcrTipoNotificacion)
                {
                    case "INV-CONSUMO-INTERNO":
                        // hoja de consumo INTERNO
                        //larArray = tcrRegEvento.Split('*');
                        //this.txtA1Adm_secadm_rgad.Text = larArray[0];
                        break;

                    case "CEX-FORMULA-MEDICA":
                        // Formula medica 
                        larArray = tcrRegEvento.Split('*'); // viene -> "Adm_secadm_rgad*Hcl_nroreg_hcms*Far_nroreg_fams"
                        this.txtG1Far_nroreg_fams.Text = larArray[2];
                        break;
                }
            }

        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // FARMOVMEDICAMMA : Maestro entrega formulas y medicamentos intrahospitalarios
        #region KeyDown para campos con F2 Tabla: FARMOVMEDICAMMA
        #region SYS_CODUSX_USUX :
        private void txtG1Sys_codusx_usux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sys_codusx_usux_Browser();
            }
        }
        private void cmdG1Sys_codusx_usux_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sys_codusx_usux_Browser();
        }
        private void txtG1Sys_codusx_usux_Browser()
        {
            Browser01 frbro = new Browser01("", "", "", "...");
            gcrCtrF2TexBox = "txtG1Sys_codusx_usux";
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
                txtG1Sia_idesec_usua_Browser();
            }
        }
        private void cmdG1Sia_idesec_usua_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_idesec_usua_Browser();
        }
        private void txtG1Sia_idesec_usua_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
            gcrCtrF2TexBox = "txtG1Sia_idesec_usua";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPIDE_TIDE : Tipo Identificación usuario - paciente
        private void txtG1Sia_tipide_tide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipide_tide_Browser();
            }
        }
        private void cmdG1Sia_tipide_tide_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipide_tide_Browser();
        }
        private void txtG1Sia_tipide_tide_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Tipo Identificación usuario - paciente...");
            gcrCtrF2TexBox = "txtG1Sia_tipide_tide";
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
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG1Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codcpr_cpro_Browser();
            }
        }
        private void cmdG1Fcm_codcpr_cpro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codcpr_cpro_Browser();
        }
        private void txtG1Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "txtG1Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_TIPTUR_HCTU : Tipo registro turnos diarios prestacion de servicios medicos
        private void txtG1Hcl_tiptur_hctu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_tiptur_hctu_Browser();
            }
        }
        private void cmdG1Hcl_tiptur_hctu_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_tiptur_hctu_Browser();
        }
        private void txtG1Hcl_tiptur_hctu_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Tipo registro turnos diarios prestacion de servicios medicos...");
            gcrCtrF2TexBox = "txtG1Hcl_tiptur_hctu";
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
        private void cmdG1Sia_codpfa_prof_Click(object sender, RoutedEventArgs e)
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
        #region INV_CODALM_INAL : Tabla Maestro almacenes
        private void txtG1Inv_codalm_inal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codalm_inal_Browser();
            }
        }
        private void cmdG1Inv_codalm_inal_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codalm_inal_Browser();
        }
        private void txtG1Inv_codalm_inal_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVALMACENMAEST", "", "Tabla Maestro almacenes...");
            gcrCtrF2TexBox = "txtG1Inv_codalm_inal";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODUSU_USUX :
        private void txtG1Sys_codusu_usux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sys_codusu_usux_Browser();
            }
        }
        private void cmdG1Sys_codusu_usux_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sys_codusu_usux_Browser();
        }
        private void txtG1Sys_codusu_usux_Browser()
        {
            Browser01 frbro = new Browser01("", "", "", "...");
            gcrCtrF2TexBox = "txtG1Sys_codusu_usux";
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
                txtG1Sis_estpro_espr_Browser();
            }
        }
        private void cmdG1Sis_estpro_espr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_estpro_espr_Browser();
        }
        private void txtG1Sis_estpro_espr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
            gcrCtrF2TexBox = "txtG1Sis_estpro_espr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // FARMOVMEDICAMMD : Maestro detalles entrega formulas y medicamentos intrahospit
        #region KeyDown para campos con F2 Tabla: FARMOVMEDICAMMD
        #region INV_SECART_INAR : Tabla Maestro Artículos
        private void txtG2Inv_secart_inar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                //txtG2Inv_secart_inar_Browser();
            }
        }
        private void cmdG2Inv_secart_inar_Click(object sender, RoutedEventArgs e)
        {
            //txtG2Inv_secart_inar_Browser();
        }
        private void txtG2Inv_secart_inar_Browser()
        {
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + vm.tmpRegContrato.fcm_codman_mans.Trim() + "'";

            Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN-SERV-IPS-CODAUX", vm.G1Inv_codalm_inal, vm.G1Inv_desalm_inal + "...");
            gcrCtrF2TexBox = "txtG2Inv_secart_inar";
            frbro.Owner = this;
            frbro.ShowDialog();

            /*
            Browser01 frbro = new Browser01("INV", "INVMAEARTICULOS", "", "Tabla Maestro Artículos...");
            gcrCtrF2TexBox = "txtG2Inv_secart_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
        }
        #endregion
        #region INV_CODAUX_INAR : Tabla Maestro Artículos
        private void txtG2Inv_codaux_inar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Inv_codaux_inar_Browser();
            }
        }
        private void cmdG2Inv_codaux_inar_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_codaux_inar_Browser();
        }
        private void txtG2Inv_codaux_inar_Browser()
        {
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + vm.tmpRegContrato.fcm_codman_mans.Trim() + "'";

            Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN-SERV-IPS-CODAUX", vm.G1Inv_codalm_inal, vm.G1Inv_desalm_inal + "...");
            gcrCtrF2TexBox = "txtG2Inv_codaux_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG2Fcm_idesec_sips_Browser();
            }
        }
        private void cmdG2Fcm_idesec_sips_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_idesec_sips_Browser();
        }
        private void txtG2Fcm_idesec_sips_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "", "Maestro de servicios habilitados para la IPS...");
            gcrCtrF2TexBox = "txtG2Fcm_idesec_sips";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODUME_SIUM : Tabla Unidades de Medidas
        private void txtG2Sis_codume_sium_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_codume_sium_Browser();
            }
        }
        private void cmdG2Sis_codume_sium_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_codume_sium_Browser();
        }
        private void txtG2Sis_codume_sium_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISUNIDADMEDIDA", "", "Tabla Unidades de Medidas...");
            gcrCtrF2TexBox = "txtG2Sis_codume_sium";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Metodo Opciones Browser Tabla: FARMOVMEDICAMMD
        //-------------------------------------------------
        //  Metodos Para Browser Tabla: FARMOVMEDICAMMD
        //-------------------------------------------------
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {

            Browser01 lobBrow = new Browser01("INV", "INVALMACENMAEST", "", "Tabla Maestro almacenes...");
            gcrCtrF2TexBox = "BROWSER";
            lobBrow.Owner = this;
            lobBrow.ShowDialog();
            
            var lcrFiltro = gcrCtrF2TexBox != "BROWSER" ? gcrCtrF2TexBox : String.Empty;
            
            if (!String.IsNullOrWhiteSpace(lcrFiltro))
            {
                MenuItem lobOp = (MenuItem)sender;
                switch (lobOp.Name)
                {
                    case "opTodos":
                        lcrFiltro = lcrFiltro + "*TODOS";
                        break;

                    case "opAbierto":
                        lcrFiltro =  lcrFiltro + "*1";
                        break;

                    case "opCerrado":
                        lcrFiltro = lcrFiltro + "*2";
                        break;

                    case "opAnulado":
                        lcrFiltro = lcrFiltro + "*3";
                        break;

                }
                Browser01Ex frbro = new Browser01Ex("FAR", "FARMOVMEDICAMMA", lcrFiltro, "Maestro entrega formulas y medicamentos intrahospitalarios...");
                gcrCtrF2TexBox = "txtG1Far_nroreg_fams";
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
                    var lobSIA002 = new VistaSiaUsuariosAtendidos(lcrAccion, "", this.txtG1Sia_nroide_usua.Text, "", "");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    lobSIA002.Owner = this;
                    lobSIA002.ShowDialog();
                    break;

                case "opUSModificar": // Crear Usuario en base de datos
                    //- Maestro de Usuarios Atendidos
                    var lcrAccionx = !String.IsNullOrWhiteSpace(vm.G1Sia_nroide_usua) ? "EDT" : "DFL";
                    var lobSIA002x = new VistaSiaUsuariosAtendidos(lcrAccionx, "", vm.G1Sia_nroide_usua, "", "");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    lobSIA002x.Owner = this;
                    lobSIA002x.ShowDialog();
                    break;
            }
        }
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
                        case "cboG1Far_tipreg_fams":
                            txtG1Far_tipreg_fams.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_tipreg_fams.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_tipreg_fams.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Far_tipges_fams":
                            txtG1Far_tipges_fams.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_tipges_fams.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_tipges_fams.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Far_entreg_fams":
                            txtG1Far_entreg_fams.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_entreg_fams.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_entreg_fams.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Far_entrex_fams":
                            txtG1Far_entrex_fams.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Far_entrex_fams.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Far_entrex_fams.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Far_tipreg_fams":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Far_tipreg_fams.SelectedItem;
                            cboG1Far_tipreg_fams.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Far_tipges_fams":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Far_tipges_fams.SelectedItem;
                            cboG1Far_tipges_fams.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Far_entreg_fams":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Far_entreg_fams.SelectedItem;
                            cboG1Far_entreg_fams.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Far_entrex_fams":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Far_entrex_fams.SelectedItem;
                            cboG1Far_entrex_fams.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
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
                    case "dpkG1Far_gesfec_fams":
                        txtG1Far_gesfec_fams.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Far_gesfec_fams);
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
                            case "txtG1Far_gesfec_fams":
                                dpkG1Far_gesfec_fams.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // Vista Capa Propiedades al hacer click sobre el Odontograma
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar Ventana detalles Ajuste Inventario</para>
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
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles Ajuste Inventario
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles Ajuste Inventario</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
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
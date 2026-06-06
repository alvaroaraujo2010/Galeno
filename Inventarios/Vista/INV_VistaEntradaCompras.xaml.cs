//- MARMOTA-GENCODE: VERSION 2.0 - 16/11/2016 06:36:40 AM
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
using Inventarios.VistaModelo;
using Inventarios.Utilidades;
using Sistema.Modelo;
using System.Windows.Media.Animation;

namespace Inventarios.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invmovcomprasma
    /// </summary>
    public partial class VistaEntradaCompras : Window, SIS_Interface
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
        VistaModeloEntradaCompras vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaEntradaCompras()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloEntradaCompras;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();


            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;
            vm.GcrUsuCodigoPerfil = oAppEntorno.gcrUsuCodigoPerfil;
            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Inv_fecges_inca.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Inv_fecdoc_inca.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Inv_fecven_incd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
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
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_COMPRAS": // Vista previa reporte entrada compras

                    var lobPrnTraslado = new INVImprimirFormato();
                    lobPrnTraslado.gcrCodigoRegistro = this.txtG1Inv_secreg_inca.Text;
                    lobPrnTraslado.gcrTipoRegistro = "COMPRAS";
                    lobPrnTraslado.fcvEjecutar();

                    break;
            }
        }
        #endregion
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            if (String.IsNullOrWhiteSpace(this.txtG1Inv_codalm_inal.Text))
            {
                FocusManager.SetFocusedElement(this, this.txtG1Inv_codalm_inal);
            }
            else
            {
                FocusManager.SetFocusedElement(this, this.txtG2Inv_codaux_inar);
            }
        }
        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
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
            FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
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
                    FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloEntradaCompras();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            dpkG1Inv_fecges_inca.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Inv_fecdoc_inca.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG2Inv_fecven_incd.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                case "txtG1Inv_secreg_inca":
                    txtG1Inv_secreg_inca.Text = tcrCodigo;
                    break;

                case "txtG1Sis_secpro_sipr":
                    txtG1Sis_secpro_sipr.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codalm_inal":
                    txtG1Inv_codalm_inal.Text = tcrCodigo;
                    break;

                case "txtG1Con_codsco_ccos":
                    txtG1Con_codsco_ccos.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codusu_usux":
                    txtG1Sys_codusu_usux.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codaux_inar":
                    txtG2Inv_codaux_inar.Text = tcrCodigo;
                    break;

                case "txtG2Inv_secart_inar":
                    txtG2Inv_secart_inar.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codume_sium":
                    txtG2Sis_codume_sium.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codctn_intc":
                    txtG2Inv_codctn_intc.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codest_ines":
                    txtG2Inv_codest_ines.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_sips":
                    this.txtG2Fcm_idesec_sips.Text = tcrCodigo;
                    var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(tcrCodigo);
                    if (tmp != null)
                    {
                        this.txtG2Fcm_coddig_mant.Text = tmp.fcm_coddig_mant;
                    }
                    break;

                case "BROWSER":
                    gcrCtrF2TexBox = tcrCodigo;
                    break;
            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // INVMOVCOMPRASMA : Tabla maestro movimientos compras
        #region KeyDown para campos con F2 Tabla: INVMOVCOMPRASMA
        #region SIS_SECPRO_SIPR : Maestro Proveedores
        private void txtG1Sis_secpro_sipr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_secpro_sipr_Browser();
            }
        }
        private void cmdG1Sis_secpro_sipr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_secpro_sipr_Browser();
        }
        private void txtG1Sis_secpro_sipr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISPROVEEDORES", "", "Maestro Proveedores...");
            gcrCtrF2TexBox = "txtG1Sis_secpro_sipr";
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
        #region CON_CODSCO_CCOS : Centros de costos contables
        private void txtG1Con_codsco_ccos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Con_codsco_ccos_Browser();
            }
        }
        private void cmdG1Con_codsco_ccos_Click(object sender, RoutedEventArgs e)
        {
            txtG1Con_codsco_ccos_Browser();
        }
        private void txtG1Con_codsco_ccos_Browser()
        {
            Browser01 frbro = new Browser01("CON", "CONCENTRODCOSTO", "", "Centros de costos contables...");
            gcrCtrF2TexBox = "txtG1Con_codsco_ccos";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODUSU_USUX : Maestro de Usuarios del Sistema
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
            Browser01 frbro = new Browser01("SYS", "SYSUSUARIOS", "", "Maestro de Usuarios del Sistema...");
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
        // INVMOVCOMPRASMD : Tabla detalle movimiento diarios por compra
        #region KeyDown para campos con F2 Tabla: INVMOVCOMPRASMD
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
                txtG2Inv_secart_inar_Browser();
            }
        }
        private void txtG2Inv_codaux_inar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Inv_secart_inar_Browser();
            }
        }
        private void cmdG2Inv_secart_inar_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_secart_inar_Browser();
        }
        private void txtG2Inv_secart_inar_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVMAEARTICULOS", "", "Tabla Maestro Artículos...");
            gcrCtrF2TexBox = "txtG2Inv_secart_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        // Vista gestion/modificar articulos 
        private void cmdMaestroArticulos_Click(object sender, RoutedEventArgs e)
        {
            // Gestion maestro de articulos
            var lobInv002 = new VistaInvmaestroarticulo(vm.G2Inv_secart_inar);
            lobInv002.Owner = this;
            lobInv002.ShowDialog();
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
        #region INV_CODCTN_INTC : Tabla tipos de contenedores (presentacion articulos)
        private void txtG2Inv_codctn_intc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Inv_codctn_intc_Browser();
            }
        }
        private void cmdG2Inv_codctn_intc_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_codctn_intc_Browser();
        }
        private void txtG2Inv_codctn_intc_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVCONTENEDORES", "", "Tabla tipos de contenedores (presentacion articulos)...");
            gcrCtrF2TexBox = "txtG2Inv_codctn_intc";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODEST_INES : Tabla Estantes para cada almacen
        private void txtG2Inv_codest_ines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Inv_codest_ines_Browser();
            }
        }
        private void cmdG2Inv_codest_ines_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_codest_ines_Browser();
        }
        private void txtG2Inv_codest_ines_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVALMACENESTAN", "", "Tabla Estantes para cada almacen...");
            gcrCtrF2TexBox = "txtG2Inv_codest_ines";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
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
        #endregion
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

                    case "opActivos":
                        lcrFiltro = lcrFiltro + "*ACTIVOS";
                        break;

                    case "opAbierto":
                        lcrFiltro = lcrFiltro + "*1";
                        break;


                    case "opCerrado":
                        lcrFiltro = lcrFiltro + "*2";
                        break;

                    case "opAnulado":
                        lcrFiltro = lcrFiltro + "*3";
                        break;
                }
                Browser01Ex frbro = new Browser01Ex("INV", "INVMOVCOMPRASMA", lcrFiltro, "Entradas por compras...");
                gcrCtrF2TexBox = "txtG1Inv_secreg_inca";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
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
                    case "dpkG1Inv_fecges_inca":
                        txtG1Inv_fecges_inca.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Inv_fecges_inca);
                        break;
                    case "dpkG1Inv_fecdoc_inca":
                        txtG1Inv_fecdoc_inca.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Inv_fecdoc_inca);
                        break;
                    case "dpkG1Inv_fecanu_inca":
                        txtG1Inv_fecanu_inca.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Inv_fecanu_inca);
                        break;
                    case "dpkG2Inv_fecven_incd":
                        txtG2Inv_fecven_incd.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG2Inv_fecven_incd);
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
                            case "txtG1Inv_fecges_inca":
                                dpkG1Inv_fecges_inca.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Inv_fecdoc_inca":
                                dpkG1Inv_fecdoc_inca.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG2Inv_fecven_incd":
                                dpkG2Inv_fecven_incd.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 15/06/2017 11:25:16 AM
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Inventarios.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invmovdiariosma
    /// </summary>
    public partial class VistaInvMovSuministro : Window, SIS_Interface
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
        VistaModeloMovSuministro vm = null;
        public List<ModeloInvKardexMaestro> lobTempkardex;
        DialogVistaErrores lobDlgLogs = null;
        public String gcrExportarArchivoNombreyRuta = String.Empty;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaInvMovSuministro()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloMovSuministro;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;
            vm.GcrUsuCodigoPerfil = "P001";

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Inv_fecges_inma.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Inv_fecdoc_inma.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_GENERAL": // Vista previa suministro interno reporte(Traslado/Salida)

                    var lobPrnTraslado = new INVImprimir();
                    lobPrnTraslado.gcrCodigoRegistro = this.txtG1Inv_secreg_inma.Text;
                    lobPrnTraslado.gcrTipoRegistro = "GENERAL";
                    lobPrnTraslado.fcvEjecutar();

                    break;

                case "opPRN_DETALLES": // Vista previa suministro interno reporte detalles

                    var lobPrnDetalles = new INVImprimir();
                    lobPrnDetalles.gcrCodigoRegistro = this.txtG1Inv_secreg_inma.Text;
                    lobPrnDetalles.gcrTipoRegistro = "DETALLES";
                    lobPrnDetalles.fcvEjecutar();

                    break;
            }
        }
        #endregion
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, this.txtG1Inv_codalm_inal);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, this.txtG2Inv_secart_inar);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Inv_codalm_inal);
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
            FocusManager.SetFocusedElement(this, txtG2Inv_secart_inar);
            FocusManager.SetFocusedElement(this, txtG2Inv_codaux_inar);
            FocusManager.SetFocusedElement(this, txtG2Inv_codbar_inar);
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
                    FocusManager.SetFocusedElement(this, txtG1Inv_conmov_incm);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Inv_conmov_incm);
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
                            // se restaura desde TextBox que maneja el estado
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloMovSuministro();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            dpkG1Inv_fecges_inma.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Inv_fecdoc_inma.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                case "txtG1Inv_secreg_inma":
                    txtG1Inv_secreg_inma.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codald_inal":
                    txtG1Inv_codald_inal.Text = tcrCodigo;
                    break;

                case "txtG1Inv_conmov_incm":
                    txtG1Inv_conmov_incm.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codalm_inal":
                    txtG1Inv_codalm_inal.Text = tcrCodigo;
                    //Linea para limpiar grilla si contiene registros de existencias diferentes al de almacen origen 
                    //vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloInvMovSuministroDe>(); 
                    break;

                case "txtG1Inv_codres_inre":
                    txtG1Inv_codres_inre.Text = tcrCodigo;
                    break;

                case "txtG1Sis_coddep_sidp":
                    txtG1Sis_coddep_sidp.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG2Inv_secart_inar":
                    txtG2Inv_secart_inar.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codaux_inar":
                    txtG2Inv_codaux_inar.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codbar_inar":
                    txtG2Inv_codbar_inar.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codgme_sigr":
                    txtG2Sis_codgme_sigr.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codctn_intc":
                    txtG2Inv_codctn_intc.Text = tcrCodigo;
                    break;

                case "txtG2Inv_codest_ines":
                    txtG2Inv_codest_ines.Text = tcrCodigo;
                    break;

                case "BROWSER":
                    gcrCtrF2TexBox = tcrCodigo;
                    break;

                case "BROWSER-EXIST":
                    gcrCtrF2TexBox = tcrCodigo;
                    break;


            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // INVMOVDIARIOSMA : Tabla maestro movimientos diarios inventarios
        #region KeyDown para campos con F2 Tabla: INVMOVDIARIOSMA
        #region INV_CODALD_INAL : Tabla Maestro almacenes
        private void txtG1Inv_codald_inal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codald_inal_Browser();
            }
        }
        private void cmdG1Inv_codald_inal_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codald_inal_Browser();
        }
        private void txtG1Inv_codald_inal_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVALMACENMAEST", "", "Tabla Maestro almacenes...");
            gcrCtrF2TexBox = "txtG1Inv_codald_inal";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CONMOV_INCM : Concepto del detalle movimiento diario
        private void txtG1Inv_conmov_incm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_conmov_incm_Browser();
            }
        }
        private void cmdG1Inv_conmov_incm_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_conmov_incm_Browser();
        }
        private void txtG1Inv_conmov_incm_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVTIPOCONCEMOV", "", "Concepto del detalle movimiento diario...");
            gcrCtrF2TexBox = "txtG1Inv_conmov_incm";
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
            //vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloInvMovSuministroDe>();           
        }
        #endregion
        #region INV_CODRES_INRE : Tabla personas responsables
        private void txtG1Inv_codres_inre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codres_inre_Browser();
            }
        }
        private void cmdG1Inv_codres_inre_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codres_inre_Browser();
        }
        private void txtG1Inv_codres_inre_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVRESPONSABLES", "", "Tabla personas responsables...");
            gcrCtrF2TexBox = "txtG1Inv_codres_inre";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODDEP_SIDP : Dependencias o areas funcionales de la empresa
        private void txtG1Sis_coddep_sidp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_coddep_sidp_Browser();
            }
        }
        private void cmdG1Sis_coddep_sidp_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_coddep_sidp_Browser();
        }
        private void txtG1Sis_coddep_sidp_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESDEPENDEN", "", "Dependencias o areas funcionales de la empresa...");
            gcrCtrF2TexBox = "txtG1Sis_coddep_sidp";
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
        // INVMOVDIARIOSMD : Tabla Detalle movimientos diarios
        #region KeyDown para campos con F2 Tabla: INVMOVDIARIOSMD
        #region INV_SECART_INAR : Tabla Maestro Artículos
        private void txtG2Inv_secart_KeyDown(object sender, KeyEventArgs e)
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
            var lcrFiltro = this.txtG1Inv_codalm_inal.Text;
            Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN", lcrFiltro, "Tabla de existencias en almacen..." + this.txtG1Inv_desalm_inal.Text);
            gcrCtrF2TexBox = "txtG2Inv_secart_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODAUX_INAR : Tabla Maestro Artículos
        private void txtG2Inv_codaux_KeyDown(object sender, KeyEventArgs e)
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
        private void cmdG2Inv_codaux_inar_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_secart_inar_Browser();
        }
        private void txtG2Inv_codaux_inar_Browser()
        {
            var lcrFiltro = this.txtG1Inv_codalm_inal.Text;
            Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN", lcrFiltro, "Tabla de existencias en almacen..." + this.txtG1Inv_desalm_inal.Text);
            gcrCtrF2TexBox = "txtG2Inv_codaux_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODBAR_INAR : Tabla Maestro Artículos
        private void txtG2Inv_codbar_KeyDown(object sender, KeyEventArgs e)
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
        private void cmdG2Inv_codbar_inar_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_secart_inar_Browser();
        }
        private void txtG2Inv_codbar_inar_Browser()
        {
            var lcrFiltro = this.txtG1Inv_codalm_inal.Text;
            Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN", lcrFiltro, "Tabla de existencias en almacen..." + this.txtG1Inv_desalm_inal.Text);
            gcrCtrF2TexBox = "txtG2Inv_codbar_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODGME_SIGR : Tabla Grupo de Medidas
        private void txtG2Sis_codgme_sigr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_codgme_sigr_Browser();
            }
        }
        private void cmdG2Sis_codgme_sigr_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_codgme_sigr_Browser();
        }
        private void txtG2Sis_codgme_sigr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISGRUPOMEDIDAS", "", "Tabla Grupo de Medidas...");
            gcrCtrF2TexBox = "txtG2Sis_codgme_sigr";
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
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtG2Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_estpro_espr_Browser();
            }
        }
        private void cmdG2Sis_estpro_espr_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_estpro_espr_Browser();
        }
        private void txtG2Sis_estpro_espr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
            gcrCtrF2TexBox = "txtG2Sis_estpro_espr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Metodo Opciones Browser Tabla: INMOVDIARIOSMD
        //-------------------------------------------------
        //  Metodos Para Browser
        //-------------------------------------------------
        #region fcvBrowserBuscar: Browser INMOVDIARIOSMD
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
                Browser01Ex frbro = new Browser01Ex("INV", "INVMOVDIARIOSMA-TS", lcrFiltro, "Tabla maestro movimientos diarios inventarios...");
                gcrCtrF2TexBox = "txtG1Inv_secreg_inma";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region fcvConfiguracion: Configuracion Botones Codigos de Articulo
        private void fcvConfiguracion(object sender, RoutedEventArgs e)
        {
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opSECART":
                    lblG2inv_secart_inar.Visibility = Visibility.Visible;
                    txtG2Inv_secart_inar.Visibility = Visibility.Visible;
                    lblG2inv_codaux_inar.Visibility = Visibility.Collapsed;
                    lblG2inv_codbar_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_codaux_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_codbar_inar.Visibility = Visibility.Collapsed;
                    break;

                case "opCODAUX":
                    lblG2inv_codaux_inar.Visibility = Visibility.Visible;
                    txtG2Inv_codaux_inar.Visibility = Visibility.Visible;
                    lblG2inv_secart_inar.Visibility = Visibility.Collapsed;
                    lblG2inv_codbar_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_secart_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_codbar_inar.Visibility = Visibility.Collapsed;
                    break;

                case "opCODBAR":
                    lblG2inv_codbar_inar.Visibility = Visibility.Visible;
                    txtG2Inv_codbar_inar.Visibility = Visibility.Visible;
                    lblG2inv_secart_inar.Visibility = Visibility.Collapsed;
                    lblG2inv_codaux_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_secart_inar.Visibility = Visibility.Collapsed;
                    txtG2Inv_codaux_inar.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        #endregion
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
                    case "dpkG1Inv_fecges_inma":
                        txtG1Inv_fecges_inma.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Inv_fecges_inma);
                        break;
                    case "dpkG1Inv_fecdoc_inma":
                        txtG1Inv_fecdoc_inma.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Inv_fecdoc_inma);
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
                            case "txtG1Inv_fecges_inma":
                                dpkG1Inv_fecges_inma.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Inv_fecdoc_inma":
                                dpkG1Inv_fecdoc_inma.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        //-------------------------------------------------
        //Limpiar campos de articulos
        //-------------------------------------------------
        #region Limpiar Campos de texto
        private void cmdLimpiarCamposArticulo_Click(object sender, RoutedEventArgs e)
        {
            txtG2Inv_secart_inar.Text = " ";
            txtG2Inv_codbar_inar.Text = " ";
            txtG2Inv_codaux_inar.Text = " ";
            txtG2Inv_nomart_inar.Text = " ";
            txtG2Inv_totctn_inmd.Text = "" + 0;
            txtG2Inv_unictn_inmd.Text = "" + 0;
            txtG2Inv_unisue_inmd.Text = "" + 0;
            txtG2Inv_unitot_inmd.Text = "" + 0;
            txtG2Inv_desctn_intc.Text = " ";
            txtG2Sis_desgme_sigr.Text = " ";

        }
        #endregion
        #endregion
        //-------------------------------------------------
        // IMPRIMIR O EXPORTAR A EXCEL
        //-------------------------------------------------
        #region fcvExportarFormatoExcel: Exportar a excel opcion desde menu
        private void fcvExportarFormatoExcel(object sender, RoutedEventArgs e)
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
            lobHoja.Cells[1, 1] = "Numero de Registro";
            lobHoja.Cells[1, 2] = "Almacen";
            lobHoja.Cells[1, 3] = "Almacen Destino";
            lobHoja.Cells[1, 4] = "Fecha de Gestion";
            lobHoja.Cells[1, 5] = "Codigo Articulo";
            lobHoja.Cells[1, 6] = "Descripcion";
            lobHoja.Cells[1, 7] = "Total Unidades";
            lobHoja.Cells[1, 8] = "Valor Unidad Compra";
            lobHoja.Cells[1, 9] = "Valor Unidad Venta";

            //Variable del rango para resaltar
            lobApp.get_Range("A1:I1").Select();
            lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);
            lobApp.Columns.AutoFit();
            //Recorremos el temporal y rellenando la hoja de trabajo
            foreach (var lobReg in vm.TmpG2ListaBrow)
            {
                #region Campos
                lobHoja.Cells[i, 1].NumberFormat = "@";
                lobHoja.Cells[i, 1] = lobReg.Inv_secreg_inma.Trim();
                lobHoja.Cells[i, 2] = lobReg.Inv_desalm_inal.Trim();
                lobHoja.Cells[i, 3] = vm.G1Inv_descon_incm;
                lobHoja.Cells[i, 4] = lobReg.Inv_fecges_inma.ToShortDateString();
                lobHoja.Cells[i, 5] = lobReg.Inv_secart_inar.Trim();
                lobHoja.Cells[i, 6] = lobReg.Inv_nomart_inar.Trim();
                lobHoja.Cells[i, 7] = lobReg.Inv_unitot_inmd.ToString();
                lobHoja.Cells[i, 8] = lobReg.Inv_valing_inar.ToString();
                lobHoja.Cells[i, 9] = lobReg.Inv_valmov_inar.ToString();

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
        //-------------------------------------------------
        // IMPRIMIR O EXPORTAR A EXCEL DETALLES
        //-------------------------------------------------
        #region fcvExportarFormatoExcelDetalles: Exportar a excel opcion desde menu
        private void fcvExportarFormatoExcelDetalles(object sender, RoutedEventArgs e)
        {
            if (flgDialogoExportarPlantillaDetalles())
            {
                Thread.Sleep(500);
                flgExportarFormatoExcelDetalles();
                MessageBox.Show("Exportación de datos finalizada!!");
            }
        }
        #endregion
        #region flgDialogoExportarPlantillaDetalles: Dialogo Exportar plantilla
        public bool flgDialogoExportarPlantillaDetalles()
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
        #region flgExportarFormatoExcelDetalles: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcelDetalles()
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

            // Encabezado del informe            
            lobHoja.Cells[1, 1] = "Codigo Articulo";
            lobHoja.Cells[1, 2] = "Nombre del Articulo";
            lobHoja.Cells[1, 3] = "Cantidad";
            lobHoja.Cells[1, 4] = "Valor Unidad Compra";
            lobHoja.Cells[1, 5] = "Valor Unidad Venta";

            //Variable del rango seleccionado para resaltar
            lobApp.get_Range("A1:E1").Select();
            lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);
            lobApp.Columns.AutoFit();
            // poner formato texto a la hoja
            //var lobCells = (Excel.Range)lobHoja.Cells;
            //lobCells.NumberFormat = "@";                                          

            //Recorremos el temporal y rellenando la hoja de trabajo
            foreach (var lobReg in vm.TmpG2ListaBrow)
            {

                #region Campos
                lobHoja.Cells[i, 1].NumberFormat = "@";
                lobHoja.Cells[i, 1] = lobReg.Inv_secart_inar.Trim();
                lobHoja.Cells[i, 2] = lobReg.Inv_nomart_inar.Trim();
                lobHoja.Cells[i, 3] = lobReg.Inv_unitot_inmd.ToString();
                lobHoja.Cells[i, 4] = lobReg.Inv_valing_inar.ToString();
                lobHoja.Cells[i, 5] = lobReg.Inv_valmov_inar.ToString();

                i = i + 1;
                //Encabezado por lote y cantidad          
                lobHoja.Cells[i, 4] = "Lote o Referencia";
                lobHoja.Cells[i, 5] = "Cantidad";
                #endregion

                lobTempkardex = ModeloInvKardexMaestro.flsInvRegArticuloLotes(lobReg.Inv_secreg_inma.Trim(), lobReg.Inv_secart_inar.Trim());
                foreach (var logRegistro in lobTempkardex)
                {
                    i++;
                    lobHoja.Cells[i, 4] = logRegistro.Inv_lotref_inar.Trim();
                    lobHoja.Cells[i, 5] = logRegistro.Inv_tottra_inex.ToString();
                }
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

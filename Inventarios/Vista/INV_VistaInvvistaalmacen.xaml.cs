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
using System.Windows.Media.Animation;

namespace Inventarios.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invalmacexisten
    /// </summary>
    public partial class VistaInvVistalmacen : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public bool glgVistPropiedades = false;
        VistaModeloInvVistalmacen vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaInvVistalmacen()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloInvVistalmacen;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;
            vm.G1Inv_codalm_inal = String.Empty;
            vm.G1Inv_desalm_inal = String.Empty;
            //vm.TmpG1ListaBrow = new System.Collections.ObjectModel.ObservableCollection<S>();
            vm.GcrFiltroDatos = String.Empty;
            vm.gcrFiltroAplicado = "1*#%77";
            vm.G3limpiar_control = "oK";

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;
            // cmdGuardar.Visibility = Visibility.Hidden;
            // cmdCancelar.Visibility = Visibility.Hidden;

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
        #region Boton ver Existencias en Kardex
        private void fcvVistaExistencias(object sender, RoutedEventArgs e)
        {
            vm.CargarExisten();
            fcvCargarVistaExistenKardexLotes();
            //Referencia de objetos en la vista..para expandir existencias
            this.expPropiedades.IsExpanded = true;
      }
        #endregion
        #region Menu Imprimir Reporte VistaAlmacen Agrupados por secciones y Estantes
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_ARTICULOS": // Vista previa de vista de almacen Agrupados por Articulos
                    var lobPrnArticulos = new INVImprimirVistaAlmacen();
                    lobPrnArticulos.gcrCodigoRegistro = this.txtG1Inv_codalm_inal.Text;
                    lobPrnArticulos.gcrTipoRegistro = "ARTICULOS";
                    lobPrnArticulos.fcvEjecutar();
                    break;

                case "opPRN_DETALLES": // Vista previa de vista de almacen Agrupados por estante y secciones
                    var lobPrnDetalles = new INVImprimirVistaAlmacen();
                    lobPrnDetalles.gcrCodigoRegistro = this.txtG1Inv_codalm_inal.Text;
                    lobPrnDetalles.gcrTipoRegistro = "DETALLES";
                    lobPrnDetalles.fcvEjecutar();
                    break;
            }
        }
        #endregion
        #region Limpiar Datos de el Datagrid
        private void fcvLimpiarDatos(object sender, RoutedEventArgs e)
        {
            //vm.TmpG1ListaBrow = new System.Collections.ObjectModel.ObservableCollection<Modelo.ModeloInvVistalmacen>();
            vm.G1Inv_codalm_inal = "";
            vm.G1Inv_desalm_inal = "";
            vm.fcvReiniVariables("1");
            vm.fcvReiniVariables("2");
            this.stkKardex.Children.Clear();
        }
        #endregion
        //------------------------------------------------
        // Cargar vista detalles Existencias Kardex
        //------------------------------------------------
        #region fcvCargarVistaExistenKardexLotes: Carga registros detalles Lotes Kardex
        /// <summary>
        /// <para>Carga registros detalles Lotes Kardex</para>
        /// </summary>
        public void fcvCargarVistaExistenKardexLotes()
        {
            if (vm.TmpG3ListaBrowLot.Count > 0)
            {
                this.stkKardex.Children.Clear();
                foreach (var lobReg in vm.TmpG3ListaBrowLot)
                {
                    //var lcrUri = "/Sistema;component/Imagenes/";
                    var lobDetalle = new ControlKardexRegExistencias();
                    lobReg.RefObjeto = lobDetalle;
                    //lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);
                    lobDetalle.cmdVerRegistro.Click += new RoutedEventHandler(fcvVerRegExistenciaKardex);

                    lobDetalle.IdR1Registro = lobReg.Inv_secart_inar;
                    lobDetalle.IdRegistro = lobReg.Inv_seckar_inka;

                    lobDetalle.txtInv_lotref_inar.Text = lobReg.Inv_lotref_inar;
                    lobDetalle.txtInv_fecven_inka.Text = lobReg.Inv_fecven_inka.ToShortDateString();
                    lobDetalle.txtInv_totuni_inex.Text = lobReg.Inv_totuni_inex.ToString();
                    lobDetalle.txtInv_codest_ines.Text = lobReg.Inv_codest_ines;

                    //lobDetalle.cmdEliminar.Visibility = vm.TmpG1ListaBrow.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                    //lobDetalle.imgEstado.Visibility = vm.TmpG1ListaBrow.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
                    lobDetalle.cmdEliminar.Visibility = Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility = Visibility.Collapsed;
                    this.stkKardex.Children.Add(lobDetalle);
                }
            }
        }
        #endregion
        #region fcvEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle</para>
        /// </summary>
        private void fcvVerRegExistenciaKardex(object sender, RoutedEventArgs e)
        {
            var lcrIdRegistro = String.Empty;

            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobObjeto = lobGrid2.Parent as ControlKardexRegExistencias;
            lcrIdRegistro = lobObjeto.IdRegistro;
            fcvVerRegistroExistenKardex(lcrIdRegistro);
        }
        #endregion
        #region fcvVerRegistroExistenKardex: Ver registro para editar..
        /// <summary>
        ///  Ver registro para editar, cargar como registro activo
        ///  
        /// </summary>
        private void fcvVerRegistroExistenKardex(String tcrIdCodigoUnico)
        {
            vm.TmpG3RegActivoLot = vm.fobBuscarRegTempKardexExistencias(tcrIdCodigoUnico);
            vm.fcvCargarVariablesDesdeRegActivo("2");
        }
        #endregion
        #endregion
        #region Filtrar Vista Seleccion de Almacen
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            vm.GcrFiltroDatos = this.txtFiltroDatos.Text;
            //gobObjVModelo.fcvFiltroSelect(lobTexto.Text);
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloInvVistalmacen();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            #endregion
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
                case "txtG1Inv_codalm_inal":
                    txtG1Inv_codalm_inal.Text = tcrCodigo;
                    break;

                case "txtG1Inv_secart_inar":
                    txtG1Inv_secart_inar.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codaux_inar":
                    txtG1Inv_codaux_inar.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codume_sium":
                    //txtG1Sis_codume_sium.Text = tcrCodigo;
                    break;

                case "txtG1Inv_nomart_inar":
                    txtG1Inv_nomart_inar.Text = tcrCodigo;
                    break;

            }
        }
        // INVALMACEXISTEN : Maestro existencias en cada almacen
        #region Cargar Almacenes seleccionado en browser
        /// <summary>
        /// <para>Seleccionar Almacen..</para>
        /// </summary>
        //fobRegBuscarInvalmacenmaest(string tcrCodigo)
        // INVALMACENMAESTR : Almacenes 
        private void txtG1Inv_codalm_inal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados)
            {
                if (!String.IsNullOrWhiteSpace(txtG1Inv_codalm_inal.Text))
                {
                    var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(txtG1Inv_codalm_inal.Text);
                    if (tmp != null)
                    {
                        this.txtG1Inv_desalm_inal.Text = tmp.inv_desalm_inal;
                        vm.gcrFiltroAplicado = "1*#%77";
                    }
                }

            }
        }
        #endregion
        #region KeyDown para campos con F2 Tabla: INVALMACEXISTEN
        #region INV_SECART_INAR : Tabla Maestro Artículos
        private void txtG1Inv_secart_inar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_secart_inar_Browser();
            }
        }
        private void cmdG1Inv_secart_inar_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_secart_inar_Browser();
        }
        private void txtG1Inv_secart_inar_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVMAEARTICULOS", "", "Tabla Maestro Artículos...");
            gcrCtrF2TexBox = "txtG1Inv_secart_inar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODGME_SIGR : Tabla Grupo de Medidas
        private void txtG1Sis_codgme_sigr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codgme_sigr_Browser();
            }
        }
        private void cmdG1Sis_codgme_sigr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codgme_sigr_Browser();
        }
        private void txtG1Sis_codgme_sigr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISGRUPOMEDIDAS", "", "Tabla Grupo de Medidas...");
            gcrCtrF2TexBox = "txtG1Sis_codgme_sigr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODUME_SIUM : Tabla Unidades de Medidas
        private void txtG1Sis_codume_sium_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codume_sium_Browser();
            }
        }
        private void cmdG1Sis_codume_sium_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codume_sium_Browser();
        }
        private void txtG1Sis_codume_sium_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISUNIDADMEDIDA", "", "Tabla Unidades de Medidas...");
            gcrCtrF2TexBox = "txtG1Sis_codume_sium";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODEST_INES : Tabla Estantes para cada almacen
        private void txtG1Inv_codest_ines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codest_ines_Browser();
            }
        }
        private void cmdG1Inv_codest_ines_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codest_ines_Browser();
        }
        private void txtG1Inv_codest_ines_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVALMACENESTAN", "", "Tabla Estantes para cada almacen...");
            gcrCtrF2TexBox = "txtG1Inv_codest_ines";
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
        #region Browser Maestro de Almacenes
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("INV", "INVALMACENMAEST", "", "MAESTRO DE ALMACENES...");
            gcrCtrF2TexBox = "txtG1Inv_codalm_inal";
            frbro.Owner = this;
            frbro.ShowDialog();

        }
        #endregion
        #endregion
        #endregion
        //-------------------------------------------------
        // Vista Capa Propiedades 
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
        //-----------------------------------------------
        //Limpiar y reiniciar varibles del control de usuario
        //---------------------
        #region Limpiar Control de usuario
        private void FcvLimpiarControl(object sender, TextChangedEventArgs e)
        {
            if (this.txtLimpiarcontrol.Text == "L")
            {
                foreach (var lobReg in vm.TmpG3ListaBrowLot)
                {
                    //Quitar la referencia a la funcion que muestre la existencias en las variables.
                    var lobDetalle = lobReg.RefObjeto as ControlKardexRegExistencias;
                    lobDetalle.cmdVerRegistro.Click -= new RoutedEventHandler(fcvVerRegExistenciaKardex);
                }

                this.stkKardex.Children.Clear();
                this.txtLimpiarcontrol.Text ="oK";
                this.expPropiedades.IsExpanded = false;
            }
        }
        #endregion
        #endregion
    }
}

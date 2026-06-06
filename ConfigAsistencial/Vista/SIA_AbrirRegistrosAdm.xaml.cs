using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.Vista
{
    /// <summary>
    /// Descripcion para la Vista abrir facturas
    /// </summary>
    public partial class AbrirRegistrosAdm : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaPropiedades = false;
        public string gcrCtrF2TexBox;
        public List<CrtForms.ListaComboBox> lstDatosFacturacion;
        public List<CrtForms.ListaComboBox> lstDatosRips;
        public List<CrtForms.ListaComboBox> lstDatosMedicos;
        public List<CrtForms.ListaComboBox> lstDatosFinalAtencion;
        public List<CrtForms.ListaComboBox> lstDatosHistorial;
        public List<CrtForms.ListaComboBox> lstDatosAdmision;
        public List<ModeloHistorialHc> lstVistaHitorial;
        //DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public AbrirRegistrosAdm()
        {
            InitializeComponent();

            IniciarComboBox();
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

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
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtAdmision.Text))
            {
                // Ejecutar los cambios
                if (MessageBox.Show("Desea ejecutar los cambios?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Modificando registros...", "CENTRO");
                    lobDlgAdd.Show();

                    var lcrDatoFact = fcrDevolverEstados("FACT");
                    var lcrDatoMedi = fcrDevolverEstados("MEDI");
                    var lcrDatoFina = fcrDevolverEstados("ADMI");
                    var lcrDatoRips = fcrDevolverEstados("RIPS");
                    var lcrDatoHist = fcrDevolverEstados("HIST");
                    var lcrDatoDele = fcrDevolverEstados("ADM2");

                    ADMModeloAdmadmisiones.fcvActualizarEstados(this.txtAdmision.Text, "", lcrDatoMedi, lcrDatoFact, "", lcrDatoRips, lcrDatoFina, 0);
                    if (!String.IsNullOrWhiteSpace(lcrDatoHist))
                    {
                        ModeloHistorialHc.flgModificarRegHistoral(lcrDatoHist, lstVistaHitorial);
                    }
                    if (!String.IsNullOrWhiteSpace(lcrDatoFact))
                    {
                        //FcmModeloMaestrofacturas.fcvActualizarEstadosFacturas(this.txtAdmision.Text, lcrDatoFact);
                        FcmModeloMaestrofacturas.fcvReAbrirFacturacion(this.txtAdmision.Text);
                    }
                    /*
                    if (!String.IsNullOrWhiteSpace(lcrDatoFact))
                    {
                        FcmModeloServDetallFacturas.fcvActualizarEstadosFacturas(this.txtAdmision.Text, lcrDatoFact);
                    }
                    */
                    if (!String.IsNullOrWhiteSpace(lcrDatoDele))
                    {
                        ModeloHistorialHc.flgEliminaAdmision(this.txtAdmision.Text);

                        this.txtAdmision.Text = String.Empty;
                        this.txtUsuario.Text = String.Empty;
                        this.txtFechaAdmision.Text = String.Empty;
                        // Retornar al valor por defecto (no realizar cambios)
                        this.cboDatosAdimision.SelectedIndex = Convert.ToInt32(lstDatosAdmision[1].IdIndice);
                        this.txtDatosAdimision.Text = "2";
                        grdDataGrid.ItemsSource = null;

                    }
                    // Actualizar la vista
                    fcvCargarDatosVistaUsuario();

                    lobDlgAdd.Close();
                }
            }
        }
        #endregion
        #region fcrDevolverEstados: Devolver tipo registro
        /// <summary>
        ///  <para>Devolver tipo registro</para>
        /// </summary>
        private String fcrDevolverEstados(String tcrTipo)
        {
            var lcrReturn = String.Empty;

            switch (tcrTipo)
            {
                case "FACT":
                    // Gestion regostros de facturacion
                    // 1=Abrir gestion,2=Confirmados,3=Anular,4=No realizar cambios
                    lcrReturn = this.txtDatosFacturacion.Text;
                    lcrReturn = lcrReturn == "4" ? String.Empty : lcrReturn;
                    break;

                case "MEDI":
                    // Datos atencion medica
                    // 1=Abrir gestion,2=Confirmados,3=No realizar cambios
                    lcrReturn = this.txtDatosGestionMedica.Text;
                    lcrReturn = lcrReturn == "3" ? String.Empty : lcrReturn;
                    break;

                case "ADMI":
                    // Abrir datos en vista admitidos
                    // 1=Activar en vista,2=Quitar de vista,3=No realizar cambios
                    lcrReturn = this.txtDatosFinAtencion.Text;
                    lcrReturn = lcrReturn == "3" ? String.Empty : lcrReturn;
                    break;

                case "HIST":
                    // Abrir datos en vista admitidos
                    // 1= Abrir registros,2=Confirmar registros,3=Anular Registros,4=Eliminar registros,5=No realizar cambios
                    lcrReturn = this.txtDatosHistorial.Text;
                    lcrReturn = lcrReturn == "4" ? "5" : lcrReturn;
                    lcrReturn = lcrReturn == "5" ? String.Empty : lcrReturn;
                    break;

                case "ADM2":
                    // Eliminar registros de una admision
                    // 1=Eliminar registros,2=No realizar cambios
                    lcrReturn = this.txtDatosAdimision.Text;
                    //lcrReturn = lcrReturn == "2" ? String.Empty : lcrReturn;
                    lcrReturn = lcrReturn = String.Empty;
                    break;
            }

            return lcrReturn;
        }
        #endregion
        #region Filtrar Vista Seleccion autorizacion
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            //lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            //this.txtFiltroDatos.Text = lobTexto.Text;
            //gobObjVModelo.fcvFiltroSelect(lobTexto.Text);
        }
        #endregion
        //-------------------------------------------------------
        // fcrCodigoSeleccionado: Obtener Codigos Seleccionado
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            if (lstVistaHitorial != null)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Marcando todos los registros...", "CENTRO");
                lobDlgAdd.Show();

                var lobjChk = sender as CheckBox;
                //- se posicicona en el primer registro de la grilla
                if (this.grdDataGrid.Items.Count > 0)
                {
                    object item = grdDataGrid.Items[0];
                    grdDataGrid.SelectedItem = item;
                    grdDataGrid.ScrollIntoView(item);
                }
                // Recorrer todo el temporal de objetos
                foreach (var lobjItem in grdDataGrid.Items)
                {
                    DataGridRow lobjFila = (DataGridRow)grdDataGrid.ItemContainerGenerator.ContainerFromItem(lobjItem);
                    if (lobjFila != null)
                    {
                        CheckBox lobChk = grdDataGrid.Columns[0].GetCellContent(lobjFila) as CheckBox;
                        if (lobChk != null)
                        {
                            lobChk.IsChecked = lobjChk.IsChecked == true ? true : false;
                        }
                    }

                    // marcar los registros del temporal asociado a la vista de la grilla
                    ModeloHistorialHc lobjRegistro = (ModeloHistorialHc)lobjItem;
                    lobjRegistro.MarcaBool = lobjChk.IsChecked == true ? true : false;
                }
                CollectionViewSource.GetDefaultView(this.grdDataGrid.ItemsSource).Refresh();

                lobDlgAdd.Close();
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
        // Gestion Edicion
        //-------------------------------------------------
        #region Mostrar menu contextual
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
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
                case "txtAdmision":
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Cargando vista registros...", "CENTRO");
                    lobDlgAdd.Show();

                    this.txtAdmision.Text = tcrCodigo;
                    fcvCargarDatosVistaUsuario();

                    lobDlgAdd.Close();
                    break;

                case "txtG4Adm_secadm_rgad":
                    //txtG4Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG4Sia_idesec_usua":
                    //txtG4Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG4Sys_codusu_usux":
                    //txtG4Sys_codusu_usux.Text = tcrCodigo;
                    break;

            }
        }
        // FCMDESCUEAUTORI : Maestro para registrar los descuentos solicitados y  autoriz
        #region Metodo Buscar admision
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos":
                    lcrFiltro = "TODOS*TODOS";
                    break;

                case "opAbierto":
                    //lcrFiltro = "TODOS*1";
                    break;

                case "opCerrado":
                    //lcrFiltro = "TODOS*2";
                    break;

                case "opAnulado":
                    //lcrFiltro = "TODOS*3";
                    break;
            }
            if (lobOp.Name != "opFacturas")
            {
                Browser02 frbro = new Browser02("ADM", "ADMREGADMISION", 1, lcrFiltro, "Admisión de pacientes...");
                gcrCtrF2TexBox = "txtAdmision";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                lcrFiltro = "TODOS*TODOS";

                Browser02 frbro = new Browser02("ADM", "ADMVISTAFACTURAS", 1, lcrFiltro, "Vista facturas...");
                gcrCtrF2TexBox = "txtAdmision";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region Buscar datos del usuario
        private void fcvCargarDatosVistaUsuario()
        {
            if (!String.IsNullOrWhiteSpace(this.txtAdmision.Text))
            {
                var tmpAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(this.txtAdmision.Text);

                if (tmpAdm != null)
                {
                    this.txtFechaAdmision.Text = Funciones.fcrConvertFecha((DateTime)tmpAdm.adm_fecadm_rgad);

                    var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(tmpAdm.sia_idesec_usua);
                    if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
                    {
                        this.txtUsuario.Text = (String)tmp.sia_nomusu_usua;
                    }
                    // Cargar el Historial 
                    lstVistaHitorial = ModeloHistorialHc.flsBuscarHistorialEventos(this.txtAdmision.Text);
                    grdDataGrid.ItemsSource = lstVistaHitorial;

                }
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        // Actualizar Objeto TextBox desde CombBox
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
                        case "cboDatosFacturacion":
                            this.txtDatosFacturacion.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosFacturacion.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboDatosGestionMedica":
                            this.txtDatosGestionMedica.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosGestionMedica.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboDatosFinAtencion":
                            this.txtDatosFinAtencion.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosFinAtencion.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboDatosRips":
                            this.txtDatosRips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosRips.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboDatosHistorial":
                            this.txtDatosHistorial.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosHistorial.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboDatosAdimision":
                            this.txtDatosAdimision.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDatosAdimision.Text, ",", lobList.ListaValoresSel) - 1;
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
        // Actualizar ComboBox desde Campo Texto
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
                        case "txtDatosFacturacion":
                            //CrtForms.ListaComboBox lobG4ComboBox1 = (CrtForms.ListaComboBox)cboDatosFacturacion.SelectedItem;
                            //this.cboDatosFacturacion.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG4ComboBox1.ListaValoresSel);
                            break;

                        case "txtDatosGestionMedica":
                            //CrtForms.ListaComboBox lobG4ComboBox2 = (CrtForms.ListaComboBox)cboDatosGestionMedica.SelectedItem;
                            //this.cboDatosGestionMedica.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG4ComboBox2.ListaValoresSel);
                            break;

                        case "txtDatosFinAtencion":
                            //CrtForms.ListaComboBox lobG4ComboBox3 = (CrtForms.ListaComboBox)cboDatosFinAtencion.SelectedItem;
                            //this.cboDatosFinAtencion.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG4ComboBox3.ListaValoresSel);
                            break;

                        case "txtDatosRips":
                            //CrtForms.ListaComboBox lobG4ComboBox4 = (CrtForms.ListaComboBox)cboDatosRips.SelectedItem;
                            //this.cboDatosRips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG4ComboBox4.ListaValoresSel);
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //  Datos Facturacion
                //-------------------------------------------------
                #region Datos Facturacion 
                //string lcrG11Seleccion = "1,2,3,4";
                //string lcrG11Descripcion = "Abrir gestion datos factuacion,Cerrar o confirmados,Anular datos facturados,No realizar cambios";
                string lcrG11Seleccion = "1,4";
                string lcrG11Descripcion = "Abrir gestion datos factuacion,No realizar cambios";
                lstDatosFacturacion = new List<CrtForms.ListaComboBox>();
                lstDatosFacturacion = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboDatosFacturacion.ItemsSource = lstDatosFacturacion;
                this.cboDatosFacturacion.SelectedIndex = Convert.ToInt32(lstDatosFacturacion[1].IdIndice);
                this.txtDatosFacturacion.Text = "4";
                #endregion
                //-------------------------------------------------
                // Datos atencion medica
                //-------------------------------------------------
                #region Datos atencion medica
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Abrir gestion de datos medicos,Cerrar o confirmar datos,No realizar cambios";
                lstDatosMedicos = new List<CrtForms.ListaComboBox>();
                lstDatosMedicos = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion, "1");
                //- Asignar al control
                this.cboDatosGestionMedica.ItemsSource = lstDatosMedicos;
                this.cboDatosGestionMedica.SelectedIndex = Convert.ToInt32(lstDatosMedicos[2].IdIndice);
                this.txtDatosGestionMedica.Text = "3";
                #endregion
                //-------------------------------------------------
                // Datos Rips 
                //-------------------------------------------------
                #region Datos Rips 
                string lcrG13Seleccion = "1,2,3";
                string lcrG13Descripcion = "Marca Rips como completados,Marcar Rips pendientes por completar,No realizar cambios";
                lstDatosRips = new List<CrtForms.ListaComboBox>();
                lstDatosRips = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion, "1");
                //- Asignar al control
                this.cboDatosRips.ItemsSource = lstDatosRips;
                this.cboDatosRips.SelectedIndex = Convert.ToInt32(lstDatosRips[2].IdIndice);
                this.txtDatosFinAtencion.Text = "3";
                #endregion
                //-------------------------------------------------
                // Abrir datos en vista admitidos
                //-------------------------------------------------
                #region Abrir datos en vista admitidos
                string lcrG14Seleccion = "1,2,3";
                string lcrG14Descripcion = "Mostrar en vista admitidos,Quitar de vista admitidos,No realizar cambios";
                lstDatosFinalAtencion = new List<CrtForms.ListaComboBox>();
                lstDatosFinalAtencion = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion, "1");
                //- Asignar al control
                this.cboDatosFinAtencion.ItemsSource = lstDatosFinalAtencion;
                this.cboDatosFinAtencion.SelectedIndex = Convert.ToInt32(lstDatosFinalAtencion[2].IdIndice);
                this.txtDatosRips.Text = "3";
                #endregion
                //-------------------------------------------------
                // Datos del historial clinico
                //-------------------------------------------------
                #region Datos historial clinico
                string lcrG15Seleccion = "1,2,3,4,5";
                string lcrG15Descripcion = "Abrir registros,Confirmar registros,Anular Registros,Eliminar registros,No realizar cambios";
                lstDatosHistorial = new List<CrtForms.ListaComboBox>();
                lstDatosHistorial = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion, "1");
                //- Asignar al control
                this.cboDatosHistorial.ItemsSource = lstDatosHistorial;
                this.cboDatosHistorial.SelectedIndex = Convert.ToInt32(lstDatosHistorial[4].IdIndice);
                this.txtDatosHistorial.Text = "5";
                #endregion
                //-------------------------------------------------
                // Datos Admision pacientes
                //-------------------------------------------------
                #region Datos historial clinico
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "Eliminar datos del registro de admisión,No realizar cambios";
                lstDatosAdmision = new List<CrtForms.ListaComboBox>();
                lstDatosAdmision = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion, "1");
                //- Asignar al control
                this.cboDatosAdimision.ItemsSource = lstDatosAdmision;
                this.cboDatosAdimision.SelectedIndex = Convert.ToInt32(lstDatosAdmision[1].IdIndice);
                this.txtDatosAdimision.Text = "2";
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
    }
}

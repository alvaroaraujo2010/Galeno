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
using System.Windows.Threading;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using FacturacionMedica.Utilidades;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Interaction logic for FCM_VistaCuentaCobroSelect.xaml
    /// </summary>
    public partial class VistaCuentaCobroSelect : Window, SIS_Interface
    {
        #region Inicio Formulario
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaSeleccion = false;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrCtrF2TexBox;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        List<SeleccionFacturas> glsFacturasSelect = null;
        List<SeleccionFacturas> glsFacturasVista = null;
        public List<CrtForms.ListaComboBox> lstTipoActividad;
        #endregion
        // Varaibles de control proceso
        #region Variables Parametros
        static String lcrPrmTipoActividad       = String.Empty; // asistencial/pyp
        static String lcrPrmCodigoContrato      = String.Empty;
        static String lcrPrmCodigoEps           = String.Empty;
        static String lcrPrmRegimenSalud        = String.Empty;
        static String lcrPrmCentroProduccion    = String.Empty;
        static String lcrPrmFechaInicioFiltro   = "01/07/2015";
        static String lcrPrmFechaFinFiltro      = "30/07/2015";
        static DateTime ldaPrmFechaInicioFiltro = Funciones.fdaConvertFecha("DMY", "/", "01/07/2015");
        static DateTime ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", "30/07/2015");
        #endregion

        public VistaCuentaCobroSelect(String tcrIdContrato, String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin, List<SeleccionFacturas> tlsFacturasSelect)
        {
            InitializeComponent();

            this.txtG1Cto_seccon_cont.Text  = tcrIdContrato;
            this.txtG1Sia_codeps_teps.Text  = tcrCodigoEps;
            this.txtFiltroFechaInicio.Text  = tcrFechaIni;
            this.txtFiltroFechaFin.Text     = tcrFechaFin;

            glsFacturasSelect = tlsFacturasSelect;
            IniciarComboBox();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            fcvTimerGeneral();
            grdDataGrid.ItemsSource = flsVistaFacturasFiltro();
            llgObjetosCargados = true;

        }
        #region fcvCargarParametros: Cargar parametros para generar de planos
        /// <summary>
        /// Cargar parametros para generar de planos
        /// </summary>
        private void fcvCargarParametros()
        {
            #region Cargar datos en variables
            lcrPrmTipoActividad     = this.txtTipoActividad.Text;
            lcrPrmCodigoContrato    = this.txtG1Cto_seccon_cont.Text.Trim();
            lcrPrmCodigoEps         = this.txtG1Sia_codeps_teps.Text;
            lcrPrmRegimenSalud      = this.txtG1Sia_tipusu_regi.Text.Trim();
            lcrPrmFechaInicioFiltro = this.txtFiltroFechaInicio.Text.Trim();
            lcrPrmFechaFinFiltro    = this.txtFiltroFechaFin.Text.Trim();
            lcrPrmCentroProduccion  = this.txtG1Fcm_codcpr_cpro.Text;
            ldaPrmFechaInicioFiltro = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaInicio.Text);
            ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaFin.Text);
            #endregion
        }
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            if (this.IsLoaded)
            {
                if (llgModoEdicionKey == false && llgModoEdicionValid == false)
                {
                    llgModoEdicionValid = true;
                    flgValidacion();
                }
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
            gdspTimerSistema.Stop();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            gdspTimerSistema.Stop();
            this.Close();
        }
        #endregion
        #region Clic Boton aceptar
        /// <summary>
        /// Clic en Boton Aceptar
        /// </summary>
        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            fcvRetornoInterface();
        }
        #endregion
        #region Clic Boton Consultar
        /// <summary>
        /// Clic en Boton Consultar
        /// </summary>
        private void cmdConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdDataGrid.ItemsSource = flsVistaFacturasFiltro();
        }
        #endregion
        //-------------------------------------------------------
        // fcvRetornoInterface: Retornar lista de facturas seleccionadas
        //-------------------------------------------------------
        #region fcvRetornoInterface: Retornar lista de facturas seleccionadas
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega lista de facturas seleccionadas
        /// </summary>
        private void fcvRetornoInterface()
        {
            ISelccionFacturas lobRefEnlace = this.Owner as ISelccionFacturas;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvISleeccionFacturas(flstListaFacturasSeleccion());
                this.Close();
            }
        }
        #endregion
        //-------------------------------------------------------
        // fcrCodigoSeleccionado: Obtener Codigos Seleccionado
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            if (glsFacturasVista != null)
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
                    SeleccionFacturas lobjRegistro = (SeleccionFacturas)lobjItem;
                    lobjRegistro.MarcaBool = lobjChk.IsChecked == true ? true : false;
                }
                CollectionViewSource.GetDefaultView(this.grdDataGrid.ItemsSource).Refresh();

                lobDlgAdd.Close();
            }
        }
        #endregion
        #region flstListaFacturasSeleccion: Obtener Lista de facturas seleccionadas
        /// <summary>
        /// Recorre el Datagrid para incluir facturas seleccionadas y devolver una lista
        /// </summary>
        public List<SeleccionFacturas> flstListaFacturasSeleccion()
        {
            List<SeleccionFacturas> lcrReturn = null;
            if (glsFacturasVista != null)
            {

                foreach (var lobjItem in grdDataGrid.Items)
                {
                    DataGridRow lobjFila = (DataGridRow)grdDataGrid.ItemContainerGenerator.ContainerFromItem(lobjItem);
                    if (lobjFila != null)
                    {
                        CheckBox lobChk = grdDataGrid.Columns[0].GetCellContent(lobjFila) as CheckBox;

                        // marcar los registros del temporal asociado a la vista de la grilla
                        SeleccionFacturas lobjRegistro = (SeleccionFacturas)lobjItem;
                        lobjRegistro.MarcaBool = lobChk.IsChecked == true ? true : false;
                    }
                }
                lcrReturn = (from tmp in glsFacturasVista where tmp.MarcaBool == true select tmp).ToList();
            }
            return lcrReturn;
        }
        #endregion
        //-------------------------------------------------
        //  Vista errores y validacion
        //-------------------------------------------------
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
            lobDlgLogs.fcvCargarVista("Vista errores", tmpLogErrores);
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
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipusu_regi":
                    txtG1Sia_tipusu_regi.Text = tcrCodigo;
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
        #region SIA_TIPUSU_REGI : Lista de Régimenes en Salud
        private void txtG1Sia_tipusu_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipusu_regi_Browser();
            }
        }
        private void cmdG1Sia_tipusu_regi_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipusu_regi_Browser();
        }
        private void txtG1Sia_tipusu_regi_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAREGIMENSALUD", "", "Lista de Régimenes en Salud...");
            gcrCtrF2TexBox = "txtG1Sia_tipusu_regi";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region fcvValidacionTexto: Validacion campos
        /// <summary>
        /// <para>Validacion campos</para>
        /// </summary>
        private void fcvValidacionTexto(object sender, TextChangedEventArgs e)
        {
            llgModoEdicionKey = true;
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);

            if (llgObjetosCargados == true)
            {
                fcvLimpiarVistaDatos();
            }

            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos del registro maestro antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codeps_teps"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_tipusu_regi"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_codcpr_cpro"))) { lnuCont++; }

            this.cmdConsultar.IsEnabled = lnuCont > 0 ? false : true;
            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region fcrValidacion: Validacion Campos general
        /// <summary>
        /// Funcion para validar parametros de filtro antes de la consulta
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {

            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            try
            {

                switch (tcrNombrePropiedad)
                {
                    case "txtG1Cto_seccon_cont":
                        #region Validacion
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        /*
                        if (String.IsNullOrWhiteSpace(this.txtG1Cto_seccon_cont.Text))
                        {
                            this.txtG1Cto_nrocon_cont.Text = String.Empty;
                            this.txtG1Cto_descon_cont.Text = String.Empty;
                            //this.txtG1Sia_codeps_teps.Text = String.Empty;
                        }
                        else
                        {
                            tmpContrato = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(this.txtG1Cto_seccon_cont.Text);
                            if (tmpContrato != null)
                            {
                                this.txtG1Cto_nrocon_cont.Text = tmpContrato.cto_nrocon_cont;
                                this.txtG1Cto_descon_cont.Text = tmpContrato.cto_descon_cont;
                                if (gcrCtrF2TexBox == "txtG1Cto_seccon_cont")
                                {
                                    this.txtG1Sia_codeps_teps.Text = String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text) ?
                                                                                              tmpContrato.sia_codeps_teps : this.txtG1Sia_codeps_teps.Text;
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Cto_seccon_cont, lcrValorReturn);
                        */
                        break;
                        #endregion

                    case "txtG1Sia_codeps_teps":
                        #region Validacion
                        lcrNombreCampo = "Código Empresa (EPS)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (!String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaepsEx(this.txtG1Sia_codeps_teps.Text);
                            if (tmp != null)
                            {
                                this.txtG1Sia_deseps_teps.Text = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            this.txtG1Sia_deseps_teps.Text = String.Empty;
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codeps_teps, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_tipusu_regi":
                        #region Validacion
                        lcrNombreCampo = "Regimen Salud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (!String.IsNullOrWhiteSpace(this.txtG1Sia_tipusu_regi.Text))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaregimensalud(this.txtG1Sia_tipusu_regi.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipusu_regi))
                            {
                                this.txtG1Sia_destip_regi.Text = tmp.sia_destip_regi;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            this.txtG1Sia_destip_regi.Text = String.Empty;
                        }
                        fcvSetColorValidacion(this.txtG1Sia_tipusu_regi, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_codcpr_cpro":
                        #region Validacion
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (!String.IsNullOrWhiteSpace(this.txtG1Fcm_codcpr_cpro.Text))
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(this.txtG1Fcm_codcpr_cpro.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                this.txtG1Fcm_descpr_cpro.Text = tmp.fcm_descpr_cpro;

                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_codcpr_cpro, lcrValorReturn);
                        break;
                        #endregion
                }
                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
                this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvSetColorValidacion: Color de objetos al validar
        private void fcvSetColorValidacion(TextBox tobObjeto, String tcrValorReturn)
        {
            tobObjeto.ToolTip = !String.IsNullOrWhiteSpace(tcrValorReturn) ? tcrValorReturn : null;
            if (!String.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;

            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }
        #endregion
        #region fcvLimpiarVistaDatos: Quitar valores de la vista cuando el filtro cambia
        /// <summary>
        /// <para>Quitar valores de la vista cuando el filtro cambia</para>
        /// </summary>
        private void fcvLimpiarVistaDatos()
        {
            glsFacturasVista = null;
            this.cmdAceptar.IsEnabled = false;
            grdDataGrid.ItemsSource = null;
            this.txtConFacturas.Text = String.Empty;
            this.txtValorFacturas.Text = String.Empty;
            glsFacturasVista = null;
        }
        #endregion
        //-------------------------------------------------
        // Actualizar Objetos TextBox  y CombBox Relacionados
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
                        case "cboTipoFiltro":
                            //this.txtTipoFiltro.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            //lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoFiltro.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboTipoActividad":
                            this.txtTipoActividad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoActividad.Text, ",", lobList.ListaValoresSel) - 1;
                            fcvLimpiarVistaDatos();
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
                /*
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtTipoFiltro":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboTipoFiltro.SelectedItem;
                            cboTipoFiltro.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActivarTabs(lcrValor);
                            break;
                    }
                }
                */
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
                // TIPO TIPO ACTIVIDAD
                //-------------------------------------------------
                #region Tipo actividad
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Activiades asistenciales,Activiades de Promoción y Prevención,Todas las actividades";
                lstTipoActividad = new List<CrtForms.ListaComboBox>();
                lstTipoActividad = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion, "1");
                //- Asignar al control
                this.cboTipoActividad.ItemsSource = lstTipoActividad;
                this.cboTipoActividad.SelectedIndex = Convert.ToInt32(lstTipoActividad[2].IdIndice);
                this.txtTipoActividad.Text = "3";
                #endregion

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //----------------------------------------------------------------------
        // FILTRO CONSULTAR FACTURAS
        //----------------------------------------------------------------------
        #region flsVistaFacturasFiltro: Mostrar las facturas en la vista
        /// <summary>
        /// Mostrar las facturas en la vista
        /// </summary>
        public List<SeleccionFacturas> flsVistaFacturasFiltro()
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Consultado numeros de facturas...", "CENTRO");
            lobDlgAdd.Show();

            fcvCargarParametros();

            if (lcrPrmTipoActividad == "3")
            {
                // No se separa por actividades
                glsFacturasVista = flsEjectarFiltro();
            }
            else 
            {
                // Asistencial o PyP
                glsFacturasVista = flsEjectarFiltroAsistPyP();
            }
            // Cerrar la vista de espera
            lobDlgAdd.Close();
            this.cmdAceptar.IsEnabled = glsFacturasVista != null ? true : false;
            // Sumatorias y valores
            this.txtConFacturas.Text = glsFacturasVista != null ? glsFacturasVista.Count().ToString() : "0";
            if (glsFacturasVista != null)
            {
                var lcrSuma = (from tmp in glsFacturasVista  select tmp.Fcm_valfac_dfac).Sum();
                this.txtValorFacturas.Text = ((int)lcrSuma).ToString();

            }
            return glsFacturasVista;
        }
        #endregion
        #region flsEjectarFiltro: Filtro consulta desde base de datos sencillo
        /// <summary>
        /// Cargar lista de facturas sin tipo actividad (asistencial / PyP)
        /// </summary>
        public List<SeleccionFacturas> flsEjectarFiltro()
        {

            List<SeleccionFacturas> llstFiltro = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //EPS y Regimen
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                join usuarios in  db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2"
                                orderby facturas.fcm_numfac_mfac
                                select new SeleccionFacturas
                                {
                                   #region Parametros
                                   Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                   Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                   Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                   Sia_idesec_usua = facturas.sia_idesec_usua,
                                   Sia_tipide_tide = facturas.sia_tipide_tide,
                                   Sia_nroide_usua = facturas.sia_nroide_usua,
                                   Cto_seccon_cont = facturas.cto_seccon_cont,
                                   Sia_codeps_teps = facturas.sia_codeps_teps,
                                   Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                   Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                   Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                   Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                   Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                   Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                   Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                   Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                   Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                   Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                   Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                   Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                   Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                   Sia_priape_usua = usuarios.sia_priape_usua,
                                   Sia_segape_usua = usuarios.sia_segape_usua,
                                   Sia_prinom_usua = usuarios.sia_prinom_usua,
                                   Sia_segnom_usua = usuarios.sia_segnom_usua,
                                   Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                   Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                   Sia_desact_tsac = facturas.sia_tipact_tsac=="1"? "ASISTENCIAL":"PROMOCION Y PREVENCION",
                                   Sia_regate_rgat = facturas.sia_regate_rgat,
                                   Sia_desate_rgat = facturas.sia_regate_rgat=="1"? "ADMITIDO":"AMBULATORIA",
                                   MarcaBool = false,
                                    #endregion

                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // Eps
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Regimen
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                        facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCentroProduccion) && llstFiltro != null)
            {
                llstFiltro = flstConsultarCentroProduccion(ref llstFiltro);
            }
            llstFiltro = flstConsultarExceptFacturas(ref llstFiltro);

            return llstFiltro;
        }
        #endregion
        #region flsEjectarFiltroAsistPyP: Filtro consulta desde base de datos asistencial o PyP
        /// <summary>
        /// Cargar lista de facturas con filtro asistencial o PyP
        /// </summary>
        public List<SeleccionFacturas> flsEjectarFiltroAsistPyP()
        {

            List<SeleccionFacturas> llstFiltro = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //EPS y Regimen
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                  join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                        facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                        facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // Eps
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                        facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Regimen
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                        facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro
                    llstFiltro = (from facturas in db.Fcmmaesfacturas
                                  join usuarios in db.Siausuarioatend on facturas.sia_idesec_usua equals usuarios.sia_idesec_usua
                                  where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                        facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                        facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                        facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                        facturas.fcm_estfac_mfac == "2"
                                  orderby facturas.fcm_numfac_mfac
                                  select new SeleccionFacturas
                                  {
                                      #region Parametros
                                      Fcm_secreg_mfac = facturas.fcm_secreg_mfac,
                                      Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                      Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                      Sia_idesec_usua = facturas.sia_idesec_usua,
                                      Sia_tipide_tide = facturas.sia_tipide_tide,
                                      Sia_nroide_usua = facturas.sia_nroide_usua,
                                      Cto_seccon_cont = facturas.cto_seccon_cont,
                                      Sia_codeps_teps = facturas.sia_codeps_teps,
                                      Sis_idterc_sitr = facturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                      Fcm_valbru_dfac = (float)facturas.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)facturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)facturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)facturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)facturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)facturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)facturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)facturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)facturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)facturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)facturas.fcm_valfac_dfac,
                                      Sia_priape_usua = usuarios.sia_priape_usua,
                                      Sia_segape_usua = usuarios.sia_segape_usua,
                                      Sia_prinom_usua = usuarios.sia_prinom_usua,
                                      Sia_segnom_usua = usuarios.sia_segnom_usua,
                                      Sia_nomusu_usua = usuarios.sia_nomusu_usua,
                                      Sia_tipact_tsac = facturas.sia_tipact_tsac,
                                      Sia_desact_tsac = facturas.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCION Y PREVENCION",
                                      Sia_regate_rgat = facturas.sia_regate_rgat,
                                      Sia_desate_rgat = facturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      MarcaBool = false,
                                      #endregion

                                  }).ToList();
                    #endregion
                }
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCentroProduccion) && llstFiltro != null)
            {
                llstFiltro = flstConsultarCentroProduccion(ref llstFiltro);
            }
            llstFiltro = flstConsultarExceptFacturas(ref llstFiltro);

            return llstFiltro;
        }
        #endregion
        #region flstConsultarExceptFacturas: Generar lista de facturas distintas a seleccionadas en gestion cuentas
        /// <summary>
        /// Generar lista de facturas distintas a seleccionadas en gestion cuentas
        /// </summary>
        public List<SeleccionFacturas> flstConsultarExceptFacturas(ref List<SeleccionFacturas> tlsFiltro)
        {
            List<SeleccionFacturas> llsReturn = tlsFiltro;
            if (tlsFiltro != null && glsFacturasSelect!= null)
            {
                var lstQuery = (from filtro in tlsFiltro from vista in glsFacturasSelect
                                where filtro.Fcm_numfac_mfac == vista.Fcm_numfac_mfac
                                select filtro).ToList();

                llsReturn = tlsFiltro.Except(lstQuery).ToList();
            }
            return llsReturn;
        }
        #endregion
        #region fcvConsultarCentroProduccion: Consultar centro de produccion para las facturas
        /// <summary>
        /// Consultar centro de produccion y  para las facturas
        /// </summary>
        public List<SeleccionFacturas> flstConsultarCentroProduccion(ref List<SeleccionFacturas> tlsFiltro)
        {
            List<SeleccionFacturas> llsReturn = null;
            // cuando hay centro de produccion
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Filtro
                var tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where detalles.fcm_codcpr_cpro == lcrPrmCentroProduccion &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.fcm_estfac_mfac == "2"
                                select detalles).ToList();
                #endregion

                foreach (var loReg in tlsFiltro)
                {
                    if (tmpDatos != null)
                    {
                        var lobSelec = tmpDatos.FirstOrDefault(x => x.fcm_numfac_mfac == loReg.Fcm_numfac_mfac);
                        loReg.MarcaBool = lobSelec != null ? true : false;
                    }
                    else
                    {
                        loReg.MarcaBool = false;
                    }
                }
            }
            llsReturn = (from tmp in tlsFiltro where tmp.MarcaBool == true select tmp).ToList();

            return llsReturn;
        }
        #endregion
    }
}

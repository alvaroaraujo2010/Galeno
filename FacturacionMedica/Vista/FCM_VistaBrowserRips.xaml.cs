//- MARMOTA-GENCODE: VERSION 2.0 - 18/10/2015 05:06:38 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using Sistema.Validacion;
using FacturacionMedica.VistaModelo;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public partial class VistaBrowserRips : Window, SIS_Interface
    {
        //-------------------------------------------------
        //- Variables de gestion
        //-------------------------------------------------
        #region Variables
        List<ADMModeloAdmadmisiones> tmpRegistros = null;
        ADMModeloAdmadmisiones gobRegAdmision = null;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        #endregion
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public int gnuIndexReg = -1;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        DialogVistaErrores lobDlgLogs = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstTipoFiltro;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaBrowserRips()
        {
            InitializeComponent();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;
            IniciarComboBox();

            Aplicacion oAppEntorno = Aplicacion.Instancia();

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkFiltroFechaInicio.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkFiltroFechaFin.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            fcvTimerGeneral();
            this.cmdBuscar.IsEnabled = false;
        }
        #endregion
        //-------------------------------------------------
        //  Timer Para propositos varios
        //-------------------------------------------------
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
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADD");
            //FocusManager.SetFocusedElement(this, txtG1Sia_idesec_usua);
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
            fcvFinalizarTimer();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            fcvFinalizarTimer();      
            this.Close();
        }

        private void fcvFinalizarTimer()
        {
            gdspTimerSistema.Tick -= new System.EventHandler(out fcvTimerProcesos);
            gdspTimerSistema.Stop();
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
                case "txtG1Sia_areing_aser":
                    //txtG1Sia_areing_aser.Text = tcrCodigo;
                    break;

                case "txtG1Sia_dixre1_tdia":
                    //txtG1Sia_dixre1_tdia.Text = tcrCodigo;
                    break;

                case "RIPS":
                    var lobRegAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(gobRegAdmision.Adm_secadm_rgad);
                    if (lobRegAdm != null)
                    {
                        var lobReg = tmpRegistros.FirstOrDefault(x => x.Adm_secadm_rgad == gobRegAdmision.Adm_secadm_rgad);
                        if (lobReg != null)
                        {
                            if (lobReg.Adm_ctarip_rgad == "1" && lobRegAdm.adm_ctarip_rgad == "2")
                            {
                                lobReg.Adm_ctarip_rgad = lobRegAdm.adm_ctarip_rgad == "2" ? "4" : lobRegAdm.adm_ctarip_rgad;
                            }
                        }
                    }
                    //txtG1Sia_dixre1_tdia.Text = tcrCodigo;
                    break;
            }
        }
        // ADMREGADMISION : Admisión de pacientes
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
        private void cmdG1Sia_areing_aser_Click(object sender, RoutedEventArgs e)
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
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
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
                            this.txtTipoFiltro.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoFiltro.Text, ",", lobList.ListaValoresSel) - 1;
                            break;

                        case "cboTipoActividad":
                            //this.txtTipoActividad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            //lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoActividad.Text, ",", lobList.ListaValoresSel) - 1;
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
                    case "dpkFiltroFechaInicio":
                        txtFiltroFechaInicio.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtFiltroFechaInicio);
                        break;

                    case "dpkFiltroFechaFin":
                        txtFiltroFechaFin.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtFiltroFechaFin);
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
                    llgModoEdicionKey = true;
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
                            case "txtFiltroFechaInicio":
                                dpkFiltroFechaInicio.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtFiltroFechaFin":
                                dpkFiltroFechaFin.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                    llgModoEdicionKey = false;
                    llgModoEdicionValid = false;
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // TIPO REGISTRO DE ATENCION
                //-------------------------------------------------
                #region Tipo Filtro
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Mostrar todos los registros,Solo registros con rips incompletos";
                lstTipoFiltro = new List<CrtForms.ListaComboBox>();
                lstTipoFiltro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboTipoFiltro.ItemsSource = lstTipoFiltro;
                this.cboTipoFiltro.SelectedIndex = Convert.ToInt32(lstTipoFiltro[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //-------------------------------------------------
        // ACCINES PARA DETALLES EN GRILLA
        //-------------------------------------------------
        #region fcvGrillaMostrarDetalles: Mostrar los detalles del registro de la grilla
        /// <summary>
        /// <para>Mostrar los detalles del registro de la grilla</para>
        /// </summary>
        private void fcvGrillaMostrarDetalles(object sender, RoutedEventArgs e)
        {
            gobRegAdmision = null;
            for (var lobVisual = sender as Visual; lobVisual != null; lobVisual = VisualTreeHelper.GetParent(lobVisual) as Visual)
            {
                if (lobVisual is DataGridRow)
                {
                    var lobFila = (DataGridRow)lobVisual;
                    // Seleccionar el registro como activo
                    gobRegAdmision = (ADMModeloAdmadmisiones)lobFila.Item;
                    break;
                }
            }
            if (gobRegAdmision != null)
            {
                //- vista completar Rips
                gcrCtrF2TexBox = "RIPS";
                VistaCompletarRips lobFCM001 = new VistaCompletarRips("EDT", gobRegAdmision.Adm_secadm_rgad, "", "", "");
                lobFCM001.Owner = this;
                lobFCM001.ShowDialog();
            }
        }
        #endregion
        //-------------------------------------------------
        // BUSCAR DATOS Y VALIDACIONES
        //-------------------------------------------------
        #region Filtrar Vista Seleccion servicios
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            this.txtFiltroDatos.Text = lobTexto.Text;
            //gobObjVModelo.fcvFiltroSelect(lobTexto.Text);
        }
        #endregion
        // fcvBrowserBuscar: Buscar datos para mostrar en vista
        #region fcvBrowserBuscar: 
        /// <summary>
        /// Buscar datos para mostrar en vista
        /// </summary>
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Cargando datos...", "CENTRO");
            lobDlgAdd.Show();

            this.grdDetalles.ItemsSource = flsBuscarRegistros();

            lobDlgAdd.Close();
        }
        #endregion
        // fcvValidarPeriodo: Validar datos Rips del periodo seleccionado
        #region fcvValidarPeriodo: Validar datos Rips del periodo seleccionado
        /// <summary>
        /// Validar datos Rips del periodo seleccionado
        /// </summary>
        private void fcvValidarPeriodo(object sender, RoutedEventArgs e)
        {
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Validando datos Rips...", "CENTRO");
            lobDlgAdd.Show();
            FcmValidarRips.fcvValidarPeriodoDatosFacturados("", this.txtFiltroFechaInicio.Text, this.txtFiltroFechaFin.Text);
            lobDlgAdd.Close();

            this.grdDetalles.ItemsSource = flsBuscarRegistros();

        }
        #endregion
        //flgValidacion: Valida todos los datos antes de guardar
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos del registro maestro antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            flgValidarRangoFechas();
            lnuCont = tmpLogErrores.Count;

            this.cmdBuscar.IsEnabled     = lnuCont > 0 ? false : true;
            this.cmdLogErrores.IsEnabled = lnuCont > 0 ? true : false;
            this.cmdValidar.IsEnabled    = lnuCont > 0 ? false : true;
            return lnuCont == 0 ? true : false;
        }
        #endregion
        // flgValidarRangoFechas: Validar Rango Fecha filtro
        #region flgValidarRangoFechas: Validar Rango Fecha filtro
        public bool flgValidarRangoFechas()
        {
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = "A01";
            String lcrNombreCampo = "Filtro rango de fechas";
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            var llgReturn = true;
            var lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaInicio.Text, "Fecha Inicio filtro");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaFin.Text, "Fecha fin filtro")))
            {
                // Validar Rango 
                if (!Funciones.flgValidarRangoFecha(this.txtFiltroFechaInicio.Text, this.txtFiltroFechaFin.Text))
                {
                    llgReturn = false;
                    lcrValorReturn = "Rango fechas esta errado.";
                }
            }
            else
            {
                lcrValorReturn = "Algun valor fecha no es valida.";
                llgReturn = false;
            }

            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // FILTRO - DESDE ADMISIONES
        //-------------------------------------------------
        #region FILTRO
        public List<ADMModeloAdmadmisiones> flsBuscarRegistros()
        {
            DateTime ldaFechaIni, ldaFechaFin;
            DateTime.TryParse(this.txtFiltroFechaInicio.Text, out ldaFechaIni);
            DateTime.TryParse(this.txtFiltroFechaFin.Text, out ldaFechaFin);
            tmpRegistros = null;
            IQueryable<ADMModeloAdmadmisiones> lcrQuery = null;
            this.txtRegistros.Text = "0";

            using (DbAplicacion db = new DbAplicacion())
            {
                //-------------------------------------------------------------------
                // VALIDACION FILTRO PRINCIPAL
                //-------------------------------------------------------------------
                var lcrTexto = this.txtFiltroDatos.Text;
                //-------------------------------------------------------------------
                // txtTipoFiltro = "1" Mostrar Rips completos e incompletos
                //-------------------------------------------------------------------
                if (this.txtTipoFiltro.Text == "1")
                {
                    if (!String.IsNullOrWhiteSpace(lcrTexto))
                    {
                        // se digito algo de texto
                        #region Consulta
                        lcrQuery = from tmpadm in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on tmpadm.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siamaeprofsalud in db.Siamaeprofsalud on tmpadm.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                   join admtipoatencion in db.Admtipoatencion on tmpadm.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                   join siatablaeps in db.Siatablaeps on tmpadm.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join siaareapreservi in db.Siaareapreservi on tmpadm.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                   from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from aser in tmsiaareapreservi.DefaultIfEmpty()
                                   where (tmpadm.adm_fecadm_rgad >= ldaFechaIni &&
                                          tmpadm.adm_fecadm_rgad <= ldaFechaFin &&
                                          tmpadm.sis_estpro_espr == "2") &&
                                        (tmpadm.adm_secadm_rgad.Contains(lcrTexto.Trim()) ||
                                         tmpadm.sia_nroide_usua.Contains(lcrTexto.Trim()) ||
                                         tmpadm.sia_codeps_teps.Contains(lcrTexto.Trim()) ||
                                         aser.sia_desare_aser.Contains(lcrTexto.Trim()) ||
                                         teps.sia_deseps_teps.Contains(lcrTexto.Trim()) ||
                                         usua.sia_nomusu_usua.Contains(lcrTexto.Trim()))
                                   orderby tmpadm.adm_fecadm_rgad descending
                                   select new ADMModeloAdmadmisiones
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = tmpadm.adm_secadm_rgad,
                                       Sia_idesec_usua = tmpadm.sia_idesec_usua,
                                       Sia_tipide_tide = tmpadm.sia_tipide_tide,
                                       Sia_nroide_usua = tmpadm.sia_nroide_usua,
                                       Hcl_nrohis_hicl = tmpadm.hcl_nrohis_hicl,
                                       Adm_fecadm_rgad = (DateTime)tmpadm.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)tmpadm.adm_horadm_rgad,
                                       Adm_pacemb_rgad = tmpadm.adm_pacemb_rgad,
                                       Adm_reingr_rgad = tmpadm.adm_reingr_rgad,
                                       Adm_codoad_toad = tmpadm.adm_codoad_toad,
                                       Sia_codare_aser = tmpadm.sia_codare_aser,
                                       Sia_areing_aser = tmpadm.sia_areing_aser,
                                       Fcm_codcpr_cpro = tmpadm.fcm_codcpr_cpro,
                                       Adm_codtat_tatn = tmpadm.adm_codtat_tatn,
                                       Sia_dixing_tdia = tmpadm.sia_dixing_tdia,
                                       Cto_seccon_cont = tmpadm.cto_seccon_cont,
                                       Cto_nrocon_cont = tmpadm.cto_nrocon_cont,
                                       Sia_codeps_teps = tmpadm.sia_codeps_teps,
                                       Sia_edaano_usua = (int)tmpadm.sia_edaano_usua,
                                       Sia_edames_usua = (int)tmpadm.sia_edames_usua,
                                       Sia_edadia_usua = (int)tmpadm.sia_edadia_usua,
                                       Sia_edaymd_usua = tmpadm.sia_edaymd_usua,
                                       Sia_codpfa_prof = tmpadm.sia_codpfa_prof,
                                       Sia_regate_rgat = tmpadm.sia_regate_rgat,
                                       Adm_estfac_rgad = tmpadm.adm_estfac_rgad,
                                       Adm_estrad_rgad = tmpadm.adm_estrad_rgad,
                                       Adm_liqest_rgad = tmpadm.adm_liqest_rgad,
                                       Adm_ctarip_rgad = tmpadm.adm_ctarip_rgad,
                                       Adm_finate_rgad = tmpadm.adm_finate_rgad,
                                       Sia_codfco_fcon = tmpadm.sia_codfco_fcon,
                                       Sia_coddia_tdia = tmpadm.sia_coddia_tdia,
                                       Adm_dessal_regr = tmpadm.adm_dessal_regr,
                                       Sis_estpro_espr = tmpadm.sis_estpro_espr,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_nomusu_usua = usua.sia_nomusu_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sia_tipdis_tdis = usua.sia_tipdis_tdis,
                                       Sia_nompro_prof = prof.sia_nompro_prof,
                                       Adm_destat_tatn = tatn.adm_destat_tatn,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_desare_aser = aser.sia_desare_aser,
                                       #endregion
                                   };
                        #endregion
                    }
                    else
                    {
                        // No se digito texto
                        #region Consulta
                        lcrQuery = from tmpadm in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on tmpadm.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siamaeprofsalud in db.Siamaeprofsalud on tmpadm.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                   join admtipoatencion in db.Admtipoatencion on tmpadm.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                   join siatablaeps in db.Siatablaeps on tmpadm.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join siaareapreservi in db.Siaareapreservi on tmpadm.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                   from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from aser in tmsiaareapreservi.DefaultIfEmpty()
                                   where (tmpadm.adm_fecadm_rgad >= ldaFechaIni &&
                                          tmpadm.adm_fecadm_rgad <= ldaFechaFin &&
                                          tmpadm.sis_estpro_espr == "2")
                                   orderby tmpadm.adm_fecadm_rgad descending
                                   select new ADMModeloAdmadmisiones
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = tmpadm.adm_secadm_rgad,
                                       Sia_idesec_usua = tmpadm.sia_idesec_usua,
                                       Sia_tipide_tide = tmpadm.sia_tipide_tide,
                                       Sia_nroide_usua = tmpadm.sia_nroide_usua,
                                       Hcl_nrohis_hicl = tmpadm.hcl_nrohis_hicl,
                                       Adm_fecadm_rgad = (DateTime)tmpadm.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)tmpadm.adm_horadm_rgad,
                                       Adm_pacemb_rgad = tmpadm.adm_pacemb_rgad,
                                       Adm_reingr_rgad = tmpadm.adm_reingr_rgad,
                                       Adm_codoad_toad = tmpadm.adm_codoad_toad,
                                       Sia_codare_aser = tmpadm.sia_codare_aser,
                                       Sia_areing_aser = tmpadm.sia_areing_aser,
                                       Fcm_codcpr_cpro = tmpadm.fcm_codcpr_cpro,
                                       Adm_codtat_tatn = tmpadm.adm_codtat_tatn,
                                       Sia_dixing_tdia = tmpadm.sia_dixing_tdia,
                                       Cto_seccon_cont = tmpadm.cto_seccon_cont,
                                       Cto_nrocon_cont = tmpadm.cto_nrocon_cont,
                                       Sia_codeps_teps = tmpadm.sia_codeps_teps,
                                       Sia_edaano_usua = (int)tmpadm.sia_edaano_usua,
                                       Sia_edames_usua = (int)tmpadm.sia_edames_usua,
                                       Sia_edadia_usua = (int)tmpadm.sia_edadia_usua,
                                       Sia_edaymd_usua = tmpadm.sia_edaymd_usua,
                                       Sia_codpfa_prof = tmpadm.sia_codpfa_prof,
                                       Sia_regate_rgat = tmpadm.sia_regate_rgat,
                                       Adm_estfac_rgad = tmpadm.adm_estfac_rgad,
                                       Adm_estrad_rgad = tmpadm.adm_estrad_rgad,
                                       Adm_liqest_rgad = tmpadm.adm_liqest_rgad,
                                       Adm_ctarip_rgad = tmpadm.adm_ctarip_rgad,
                                       Adm_finate_rgad = tmpadm.adm_finate_rgad,
                                       Sia_codfco_fcon = tmpadm.sia_codfco_fcon,
                                       Sia_coddia_tdia = tmpadm.sia_coddia_tdia,
                                       Adm_dessal_regr = tmpadm.adm_dessal_regr,
                                       Sis_estpro_espr = tmpadm.sis_estpro_espr,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_nomusu_usua = usua.sia_nomusu_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sia_tipdis_tdis = usua.sia_tipdis_tdis,
                                       Sia_nompro_prof = prof.sia_nompro_prof,
                                       Adm_destat_tatn = tatn.adm_destat_tatn,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_desare_aser = aser.sia_desare_aser,
                                       #endregion
                                   };
                        #endregion
                    }
                }
                //-------------------------------------------------------------------
                // txtTipoFiltro = "2" Mostrar solo Rips incompletos
                //-------------------------------------------------------------------
                else
                {
                    if (!String.IsNullOrWhiteSpace(lcrTexto))
                    {
                        // se digito algo de texto
                        #region Consulta
                        lcrQuery = from tmpadm in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on tmpadm.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siamaeprofsalud in db.Siamaeprofsalud on tmpadm.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                   join admtipoatencion in db.Admtipoatencion on tmpadm.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                   join siatablaeps in db.Siatablaeps on tmpadm.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join siaareapreservi in db.Siaareapreservi on tmpadm.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                   from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from aser in tmsiaareapreservi.DefaultIfEmpty()
                                   where (tmpadm.adm_fecadm_rgad >= ldaFechaIni &&
                                          tmpadm.adm_fecadm_rgad <= ldaFechaFin &&
                                          tmpadm.adm_ctarip_rgad == "1" &&
                                          tmpadm.sis_estpro_espr == "2") &&
                                        (tmpadm.adm_secadm_rgad.Contains(lcrTexto.Trim()) ||
                                         tmpadm.sia_nroide_usua.Contains(lcrTexto.Trim()) ||
                                         tmpadm.sia_codeps_teps.Contains(lcrTexto.Trim()) ||
                                         aser.sia_desare_aser.Contains(lcrTexto.Trim()) ||
                                         teps.sia_deseps_teps.Contains(lcrTexto.Trim()) ||
                                         usua.sia_nomusu_usua.Contains(lcrTexto.Trim()))
                                   orderby tmpadm.adm_fecadm_rgad descending
                                   select new ADMModeloAdmadmisiones
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = tmpadm.adm_secadm_rgad,
                                       Sia_idesec_usua = tmpadm.sia_idesec_usua,
                                       Sia_tipide_tide = tmpadm.sia_tipide_tide,
                                       Sia_nroide_usua = tmpadm.sia_nroide_usua,
                                       Hcl_nrohis_hicl = tmpadm.hcl_nrohis_hicl,
                                       Adm_fecadm_rgad = (DateTime)tmpadm.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)tmpadm.adm_horadm_rgad,
                                       Adm_pacemb_rgad = tmpadm.adm_pacemb_rgad,
                                       Adm_reingr_rgad = tmpadm.adm_reingr_rgad,
                                       Adm_codoad_toad = tmpadm.adm_codoad_toad,
                                       Sia_codare_aser = tmpadm.sia_codare_aser,
                                       Sia_areing_aser = tmpadm.sia_areing_aser,
                                       Fcm_codcpr_cpro = tmpadm.fcm_codcpr_cpro,
                                       Adm_codtat_tatn = tmpadm.adm_codtat_tatn,
                                       Sia_dixing_tdia = tmpadm.sia_dixing_tdia,
                                       Cto_seccon_cont = tmpadm.cto_seccon_cont,
                                       Cto_nrocon_cont = tmpadm.cto_nrocon_cont,
                                       Sia_codeps_teps = tmpadm.sia_codeps_teps,
                                       Sia_edaano_usua = (int)tmpadm.sia_edaano_usua,
                                       Sia_edames_usua = (int)tmpadm.sia_edames_usua,
                                       Sia_edadia_usua = (int)tmpadm.sia_edadia_usua,
                                       Sia_edaymd_usua = tmpadm.sia_edaymd_usua,
                                       Sia_codpfa_prof = tmpadm.sia_codpfa_prof,
                                       Sia_regate_rgat = tmpadm.sia_regate_rgat,
                                       Adm_estfac_rgad = tmpadm.adm_estfac_rgad,
                                       Adm_estrad_rgad = tmpadm.adm_estrad_rgad,
                                       Adm_liqest_rgad = tmpadm.adm_liqest_rgad,
                                       Adm_ctarip_rgad = tmpadm.adm_ctarip_rgad,
                                       Adm_finate_rgad = tmpadm.adm_finate_rgad,
                                       Sia_codfco_fcon = tmpadm.sia_codfco_fcon,
                                       Sia_coddia_tdia = tmpadm.sia_coddia_tdia,
                                       Adm_dessal_regr = tmpadm.adm_dessal_regr,
                                       Sis_estpro_espr = tmpadm.sis_estpro_espr,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_nomusu_usua = usua.sia_nomusu_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sia_tipdis_tdis = usua.sia_tipdis_tdis,
                                       Sia_nompro_prof = prof.sia_nompro_prof,
                                       Adm_destat_tatn = tatn.adm_destat_tatn,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_desare_aser = aser.sia_desare_aser,
                                       #endregion
                                   };
                        #endregion
                    }
                    else
                    {
                        // No se digito texto
                        #region Consulta
                        lcrQuery = from tmpadm in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on tmpadm.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siamaeprofsalud in db.Siamaeprofsalud on tmpadm.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                   join admtipoatencion in db.Admtipoatencion on tmpadm.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                   join siatablaeps in db.Siatablaeps on tmpadm.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join siaareapreservi in db.Siaareapreservi on tmpadm.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                   from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from aser in tmsiaareapreservi.DefaultIfEmpty()
                                   where (tmpadm.adm_fecadm_rgad >= ldaFechaIni &&
                                          tmpadm.adm_fecadm_rgad <= ldaFechaFin &&
                                          tmpadm.adm_ctarip_rgad == "1" &&
                                          tmpadm.sis_estpro_espr == "2")
                                   orderby tmpadm.adm_fecadm_rgad descending
                                   select new ADMModeloAdmadmisiones
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = tmpadm.adm_secadm_rgad,
                                       Sia_idesec_usua = tmpadm.sia_idesec_usua,
                                       Sia_tipide_tide = tmpadm.sia_tipide_tide,
                                       Sia_nroide_usua = tmpadm.sia_nroide_usua,
                                       Hcl_nrohis_hicl = tmpadm.hcl_nrohis_hicl,
                                       Adm_fecadm_rgad = (DateTime)tmpadm.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)tmpadm.adm_horadm_rgad,
                                       Adm_pacemb_rgad = tmpadm.adm_pacemb_rgad,
                                       Adm_reingr_rgad = tmpadm.adm_reingr_rgad,
                                       Adm_codoad_toad = tmpadm.adm_codoad_toad,
                                       Sia_codare_aser = tmpadm.sia_codare_aser,
                                       Sia_areing_aser = tmpadm.sia_areing_aser,
                                       Fcm_codcpr_cpro = tmpadm.fcm_codcpr_cpro,
                                       Adm_codtat_tatn = tmpadm.adm_codtat_tatn,
                                       Sia_dixing_tdia = tmpadm.sia_dixing_tdia,
                                       Cto_seccon_cont = tmpadm.cto_seccon_cont,
                                       Cto_nrocon_cont = tmpadm.cto_nrocon_cont,
                                       Sia_codeps_teps = tmpadm.sia_codeps_teps,
                                       Sia_edaano_usua = (int)tmpadm.sia_edaano_usua,
                                       Sia_edames_usua = (int)tmpadm.sia_edames_usua,
                                       Sia_edadia_usua = (int)tmpadm.sia_edadia_usua,
                                       Sia_edaymd_usua = tmpadm.sia_edaymd_usua,
                                       Sia_codpfa_prof = tmpadm.sia_codpfa_prof,
                                       Sia_regate_rgat = tmpadm.sia_regate_rgat,
                                       Adm_estfac_rgad = tmpadm.adm_estfac_rgad,
                                       Adm_estrad_rgad = tmpadm.adm_estrad_rgad,
                                       Adm_liqest_rgad = tmpadm.adm_liqest_rgad,
                                       Adm_ctarip_rgad = tmpadm.adm_ctarip_rgad,
                                       Adm_finate_rgad = tmpadm.adm_finate_rgad,
                                       Sia_codfco_fcon = tmpadm.sia_codfco_fcon,
                                       Sia_coddia_tdia = tmpadm.sia_coddia_tdia,
                                       Adm_dessal_regr = tmpadm.adm_dessal_regr,
                                       Sis_estpro_espr = tmpadm.sis_estpro_espr,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_nomusu_usua = usua.sia_nomusu_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sia_tipdis_tdis = usua.sia_tipdis_tdis,
                                       Sia_nompro_prof = prof.sia_nompro_prof,
                                       Adm_destat_tatn = tatn.adm_destat_tatn,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_desare_aser = aser.sia_desare_aser,
                                       #endregion
                                   };
                        #endregion
                    }
                }
                if (lcrQuery != null)
                {
                    tmpRegistros = lcrQuery.ToList();
                    this.txtRegistros.Text = tmpRegistros.Count.ToString();
                }
            }

            return tmpRegistros;
        }
        #endregion
    }
}
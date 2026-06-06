//- MARMOTA-GENCODE: VERSION 2.0 - 04/04/2014 10:56:04 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Reportes.Utilidades;
using Admision.VistaModelo;
using Admision.Utilidades;
using System.Diagnostics;
using GestorReportes.Utilidades;

namespace Admision.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admtriagemaestr
    /// </summary>
    public partial class VistaValoracionTriage : Window, SIS_Interface
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
        VistaModeloTriageValoracion gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaValoracionTriage(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();
            gobObjVModelo = this.DataContext as VistaModeloTriageValoracion;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Adm_gesfec_tria.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                EFadmtriagemaestr lobReg = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_nroreg_tria)) { llgExiste = true; }
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
            txtG1Adm_nroreg_tria.Text = tcrCodigoIgTabla;
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
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        // Mostrar menu contextual
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
            FocusManager.SetFocusedElement(this, txtG1Adm_gesfec_tria);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Adm_gesfec_tria);
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
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_GENERAL": // Vista previa Evaluacion Triage

                    var lobPrnTriage = new ADMImprimirTriage();
                    lobPrnTriage.gcrCodigoRegistro = this.txtG1Adm_nroreg_tria.Text;
                    lobPrnTriage.gcrTipoRegistro = "GENERAL";
                    lobPrnTriage.fcvEjecutar();

                    break;
            }
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
                    FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
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
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarModoEdicion");
            }
        }
        #endregion
        #region fcvCmdTecladoVirtual: Mostrar teclado en pantalla
        private void fcvCmdTecladoVirtual(object sender, RoutedEventArgs e)
        {
            Process.Start("osk.exe");
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
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01Ex frbro = new Browser01Ex("ADM", "ADMTRIAGEMAESTR", "", "Maestro evaluación Triage...");
            gcrCtrF2TexBox = "txtG1Adm_nroreg_tria";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                case "txtG1Adm_nroreg_tria":
                    txtG1Adm_nroreg_tria.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codcat_ceat":
                    txtG1Sia_codcat_ceat.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG1Sia_coddia_tdia":
                    txtG1Sia_coddia_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":

                    var lobReg = SIAValidarCodigo.fobRegBuscarSiausuarioatendEx(tcrCodigo);

                    gobObjVModelo.G1Sia_idesec_usua = lobReg.sia_idesec_usua;
                    this.txtG1Sia_nroide_usua.Text       = lobReg.sia_nroide_usua;
                    this.txtG1Sia_priape_usua.Text = lobReg.sia_priape_usua;
                    this.txtG1Sia_segape_usua.Text = lobReg.sia_segape_usua;
                    this.txtG1Sia_prinom_usua.Text = lobReg.sia_prinom_usua;
                    this.txtG1Sia_segnom_usua.Text = lobReg.sia_segnom_usua;
                    this.txtG1Sis_codsex_sexo.Text = lobReg.sis_codsex_sexo;
                    this.txtG1Sia_edapac_usua.Text = lobReg.sia_edapac_usua.ToString();
                    this.txtG1Sia_codmed_tmed.Text = lobReg.sia_codmed_tmed;

                    if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/",  gobObjVModelo.G1Adm_gesfec_tria, "Fecha del triage")))
                    {
                        var ldaFechaTriage = Funciones.fdaConvertFecha("DMY", "/", gobObjVModelo.G1Adm_gesfec_tria);

                        this.txtG1Sia_edapac_usua.Text = Funciones.fnuValorAñosMesesDias((DateTime)lobReg.sia_fecnac_usua, ldaFechaTriage).ToString();
                        this.txtG1Sia_codmed_tmed.Text = Funciones.fcrMedidaAñosMesesDias((DateTime)lobReg.sia_fecnac_usua, ldaFechaTriage);
                    }
                    break;
            }
        }
        // ADMTRIAGEMAESTR : Maestro evaluación Triage
        #region KeyDown para campos con F2 Tabla: ADMTRIAGEMAESTR
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
        #region SIA_CODCAT_CEAT : Centros de Atención
        private void txtG1Sia_codcat_ceat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIACENTROATEN", "", "Centros de Atención...");
                gcrCtrF2TexBox = "txtG1Sia_codcat_ceat";
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
                txtG1Sia_nroide_usua_Browser();
            }
        }
        private void txtG1Sia_nroide_usua_Click(object sender, RoutedEventArgs e)
        {
           txtG1Sia_nroide_usua_Browser();
        }
        private void txtG1Sia_nroide_usua_Browser()
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        #endregion
        #region SIA_NROIDE_USUA : Browser - Maestro de Pacientes atendidos browser por Identificación
        private void fcvBuscarPacienteBaseDeDatos(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes ...");
            gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODEPS_TEPS : Browser - Lista de EPS o seguradores
        private void fcvBuscarEmpresaEps(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
            gcrCtrF2TexBox = "txtG1Sia_codeps_teps";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODCAT_CEAT : Browser - Centros de Atención
        private void fcvBuscarSede(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIACENTROATEN", "", "Centros de Atención...");
            gcrCtrF2TexBox = "txtG1Sia_codcat_ceat";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPFA_PROF : Browser - Profesionales que prestan servicios
        private void fcvBuscarProfesional(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODDIA_TDIA : Tabla de diagnosticos CIE - 10
        private void txtG1Sia_coddia_tdia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_coddia_tdia_Browser();
            }
        }
        private void cmdG1Sia_coddia_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_coddia_tdia_Browser();
        }
        private void txtG1Sia_coddia_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_coddia_tdia";
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
                        case "cboG1Sia_tipide_tide":
                            txtG1Sia_tipide_tide.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_tipide_tide.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_tipide_tide.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_codsex_sexo":
                            txtG1Sis_codsex_sexo.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_codsex_sexo.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_codsex_sexo.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_codmed_tmed":
                            txtG1Sia_codmed_tmed.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_codmed_tmed.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_codmed_tmed.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_clasif_tria":
                            txtG1Adm_clasif_tria.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_clasif_tria.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_clasif_tria.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_remisi_tria":
                            txtG1Adm_remisi_tria.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_remisi_tria.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_remisi_tria.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sia_tipide_tide":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sia_tipide_tide.SelectedItem;
                            cboG1Sia_tipide_tide.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;

                        case "txtG1Sis_codsex_sexo":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Sis_codsex_sexo.SelectedItem;
                            cboG1Sis_codsex_sexo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;

                        case "txtG1Sia_codmed_tmed":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Sia_codmed_tmed.SelectedItem;
                            cboG1Sia_codmed_tmed.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;

                        case "txtG1Adm_clasif_tria":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Adm_clasif_tria.SelectedItem;
                            cboG1Adm_clasif_tria.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            // Actuslizar vista 
                            fcvActualizarVistaTriage();
                            break;

                        case "txtG1Adm_remisi_tria":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Adm_remisi_tria.SelectedItem;
                            cboG1Adm_remisi_tria.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
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
        // fcvActualizarVistaTriage: Actualziar vista parametros triage
        //-------------------------------------------------
        #region Actualziar vista parametros triage
        private void fcvActualizarVistaTriage()
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    var lcrUri = "/Sistema;component/Imagenes/";
                    var lcrTituloNivel  = "NIVEL TRIAGE";
                    var lcrTextoDescri  = String.Empty;
                    var lcrTiempoAtenc  = String.Empty;
                    var lcrDestinoAten  = String.Empty;
                    var lcrImagenVista  = "sys_usu02.png";
                    var lcrColorNivelC  = "#FFF3F3F3";

                    var lcrCodigoClasif = this.txtG1Adm_clasif_tria.Text;

                    if (!String.IsNullOrWhiteSpace(lcrCodigoClasif))
                    {
                        var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaconfNivel(lcrCodigoClasif);
                        if (tmp != null)
                        {
                            lcrTituloNivel = (tmp.adm_titcla_adct).ToUpper();
                            lcrTextoDescri = tmp.adm_descla_adct;
                            lcrTiempoAtenc = tmp.adm_tiempo_adct;
                            lcrDestinoAten = tmp.adm_remisi_tria;
                            lcrImagenVista = tmp.adm_imagen_adct;
                            lcrColorNivelC = tmp.adm_icolor_adct;
                            lcrDestinoAten = lcrDestinoAten == "1" ? "CONSULTA EXTERNA" : lcrDestinoAten == "2" ? "CONSULTA PRIORITARIA" : "ATENCIÓN URGENCIAS";
                        }
                    }
                    this.lblAdm_titcla_adct.Text = lcrTituloNivel;
                    this.txtAdm_descla_adct.Text = lcrTextoDescri;
                    this.lblAdm_tiempo_adct.Text = lcrTiempoAtenc;
                    this.lblAdm_remisi_tria.Text = lcrDestinoAten;
                    this.objColorTriage.Background = Funciones.FuxSetSolidColorBrush(lcrColorNivelC);
                    this.imgImagenNivel.Source      = new BitmapImage(new Uri(lcrUri + lcrImagenVista, UriKind.RelativeOrAbsolute));
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarVistaTriage");
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
                    case "dpkG1Adm_gesfec_tria":
                        txtG1Adm_gesfec_tria.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_gesfec_tria);
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
                            case "txtG1Adm_gesfec_tria":
                                dpkG1Adm_gesfec_tria.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 12/04/2015 07:04:40 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using ConfigAsistencial.VistaModelo;

namespace ConfigAsistencial.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: siausuarioatend
    /// </summary>
    public partial class VistaSiaUsuariosAtendidos : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloSiaUsuariosAtendidos vm = null;
        DialogVistaErrores lobDlgLogs = null;
        public string lcrFormModoPopup = "DFL";
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSiaUsuariosAtendidos(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloSiaUsuariosAtendidos;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Sia_fecnac_usua.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Sia_feceps_usua.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
            var lcrModoAccion = tcrModoAccion;

            tcrModoAccion = tcrModoAccion == "ADAF" ? "ADD" : tcrModoAccion;

            if (!String.IsNullOrWhiteSpace(tcrCodigoIgTabla))
            {
                EFsiausuarioatend lobReg = SIAValidarCodigo.fobRegBuscarSiausuarioatend(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.sia_idesec_usua)) { llgExiste = true; }
            }
            else if (!String.IsNullOrWhiteSpace(tcrCodigo1))
            {
                if (lcrModoAccion != "ADAF")
                {
                    var lobReg = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(tcrCodigo1);
                    if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.sia_idesec_usua))
                    {
                        tcrCodigoIgTabla = lobReg.sia_idesec_usua;
                        tcrCodigo1 = String.Empty;
                        llgExiste = true;
                    }
                }
                else
                {
                    vm.lcrIdAfiliado = tcrCodigo1;
                }
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
            txtG1Sia_idesec_usua.Text = tcrCodigoIgTabla;
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
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_tipide_tide);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sia_tipide_tide);
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
        #region  Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    break;

                case "CAN":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    break;
            }

            if (tcrTipoEdicion == "ADD" || tcrTipoEdicion == "EDT")
            {
                FocusManager.SetFocusedElement(this, txtG1Sia_idesec_usua);
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                cmdAdicionar.Visibility = Visibility.Visible;
                cmdModificar.Visibility = Visibility.Visible;
                cmdGuardar.Visibility = Visibility.Hidden;
                cmdCancelar.Visibility = Visibility.Hidden;
            }
            ActualizarFormModoPopup(tcrTipoEdicion, "1");
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
            fcvRetornoInterface();
            fcvFinalizarInstanciaDatos();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloSiaUsuariosAtendidos();
            // Quitar referencias
            dpkG1Sia_fecnac_usua.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Sia_feceps_usua.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
        }
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra la vista del formulario
        /// </summary>
        private void fcvRetornoInterface()
        {
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvBuscarRegistro(this.txtG1Sia_nroide_usua.Text);
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
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
            gcrCtrF2TexBox = "txtG1Sia_idesec_usua";
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
                case "txtG1Sia_idesec_usua":
                    txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipide_tide":
                    txtG1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codsex_sexo":
                    txtG1Sis_codsex_sexo.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipusu_regi":
                    txtG1Sia_tipusu_regi.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipcot_tcot":
                    txtG1Sia_tipcot_tcot.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipafi_tafi":
                    txtG1Sia_tipafi_tafi.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tippob_tpob":
                    txtG1Sia_tippob_tpob.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nivedu_sine":
                    txtG1Sia_nivedu_sine.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nivsbn_nsbn":
                    txtG1Sia_nivsbn_nsbn.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nivcon_ncon":
                    txtG1Sia_nivcon_ncon.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idemun_muni":
                    txtG1Sis_idemun_muni.Text = tcrCodigo;
                    break;

                case "txtG1Sis_coddep_dpto":
                    txtG1Sis_coddep_dpto.Text = tcrCodigo;
                    break;

                case "txtG1Sis_zonres_tzon":
                    txtG1Sis_zonres_tzon.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codocu_ocup":
                    txtG1Sis_codocu_ocup.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipdis_tdis":
                    txtG1Sia_tipdis_tdis.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codmed_tmed":
                    txtG1Sia_codmed_tmed.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codper_pret":
                    txtG1Sia_codper_pret.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codcat_ceat":
                    txtG1Sia_codcat_ceat.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estreg_esrg":
                    txtG1Sis_estreg_esrg.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_nrohis_hicl":
                    txtG1Hcl_nrohis_hicl.Text = tcrCodigo;
                    break;

            }
        }
        // SIAUSUARIOATEND : Maestro de Pacientes atendidos
        #region KeyDown para campos con F2 Tabla: SIAUSUARIOATEND
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
        #region SIS_CODSEX_SEXO : Sexo Personas
        private void txtG1Sis_codsex_sexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codsex_sexo_Browser();
            }
        }
        private void cmdG1Sis_codsex_sexo_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codsex_sexo_Browser();
        }
        private void txtG1Sis_codsex_sexo_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABLASEXOS", "", "Sexo Personas...");
            gcrCtrF2TexBox = "txtG1Sis_codsex_sexo";
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
        #region SIA_TIPCOT_TCOT : Tipo cotizante contributivo
        private void txtG1Sia_tipcot_tcot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipcot_tcot_Browser();
            }
        }
        private void cmdG1Sia_tipcot_tcot_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipcot_tcot_Browser();
        }
        private void txtG1Sia_tipcot_tcot_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPOCOTIZANTE", "", "Tipo cotizante contributivo...");
            gcrCtrF2TexBox = "txtG1Sia_tipcot_tcot";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPAFI_TAFI : Tipo Afiliado contributivo
        private void txtG1Sia_tipafi_tafi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipafi_tafi_Browser();
            }
        }
        private void cmdG1Sia_tipafi_tafi_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipafi_tafi_Browser();
        }
        private void txtG1Sia_tipafi_tafi_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPAFICONTRI", "", "Tipo Afiliado contributivo...");
            gcrCtrF2TexBox = "txtG1Sia_tipafi_tafi";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPPOB_TPOB : Tipo poblacional especial subsidiado
        private void txtG1Sia_tippob_tpob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tippob_tpob_Browser();
            }
        }
        private void cmdG1Sia_tippob_tpob_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tippob_tpob_Browser();
        }
        private void txtG1Sia_tippob_tpob_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPPOBLACION", "", "Tipo poblacional especial subsidiado...");
            gcrCtrF2TexBox = "txtG1Sia_tippob_tpob";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_NIVSBN_NSBN : Nivel Sisben
        private void txtG1Sia_nivsbn_nsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_nivsbn_nsbn_Browser();
            }
        }
        private void cmdG1Sia_nivsbn_nsbn_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_nivsbn_nsbn_Browser();
        }
        private void txtG1Sia_nivsbn_nsbn_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIANIVELSISBEN", "", "Nivel Sisben...");
            gcrCtrF2TexBox = "txtG1Sia_nivsbn_nsbn";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_NIVCON_NCON : Nivel Contributivo
        private void txtG1Sia_nivcon_ncon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_nivcon_ncon_Browser();
            }
        }
        private void cmdG1Sia_nivcon_ncon_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_nivcon_ncon_Browser();
        }
        private void txtG1Sia_nivcon_ncon_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIANIVCONTRIBUT", "", "Nivel Contributivo...");
            gcrCtrF2TexBox = "txtG1Sia_nivcon_ncon";
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
        private void cmdG1Sis_idemun_muni_Click(object sender, RoutedEventArgs e)
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
        #region SIS_CODDEP_DPTO : Departamentos del Pais DANE
        private void txtG1Sis_coddep_dpto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_coddep_dpto_Browser();
            }
        }
        private void cmdG1Sis_coddep_dpto_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_coddep_dpto_Browser();
        }
        private void txtG1Sis_coddep_dpto_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABDEPARTAME", "", "Departamentos del Pais DANE...");
            gcrCtrF2TexBox = "txtG1Sis_coddep_dpto";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_ZONRES_TZON : Zona de residencia
        private void txtG1Sis_zonres_tzon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_zonres_tzon_Browser();
            }
        }
        private void cmdG1Sis_zonres_tzon_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_zonres_tzon_Browser();
        }
        private void txtG1Sis_zonres_tzon_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISZONARESIDENC", "", "Zona de residencia...");
            gcrCtrF2TexBox = "txtG1Sis_zonres_tzon";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODOCU_OCUP : Tabla ocupaciones o profesiones
        private void txtG1Sis_codocu_ocup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codocu_ocup_Browser();
            }
        }
        private void cmdG1Sis_codocu_ocup_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codocu_ocup_Browser();
        }
        private void txtG1Sis_codocu_ocup_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISOCUPACIONES", "", "Tabla ocupaciones o profesiones...");
            gcrCtrF2TexBox = "txtG1Sis_codocu_ocup";
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
        #region SIA_TIPDIS_TDIS : Tipo de Discapacidad
        private void txtG1Sia_tipdis_tdis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipdis_tdis_Browser();
            }
        }
        private void cmdG1Sia_tipdis_tdis_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipdis_tdis_Browser();
        }
        private void txtG1Sia_tipdis_tdis_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPDISCAPACI", "", "Tipo de Discapacidad...");
            gcrCtrF2TexBox = "txtG1Sia_tipdis_tdis";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODMED_TMED : Medida de la edad del Usuario - Paciente
        private void txtG1Sia_codmed_tmed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codmed_tmed_Browser();
            }
        }
        private void cmdG1Sia_codmed_tmed_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codmed_tmed_Browser();
        }
        private void txtG1Sia_codmed_tmed_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAMEDIDAEDAD", "", "Medida de la edad del Usuario - Paciente...");
            gcrCtrF2TexBox = "txtG1Sia_codmed_tmed";
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
                txtG1Sia_codcat_ceat_Browser();
            }
        }
        private void cmdG1Sia_codcat_ceat_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codcat_ceat_Browser();
        }
        private void txtG1Sia_codcat_ceat_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIACENTROATEN", "", "Centros de Atención...");
            gcrCtrF2TexBox = "txtG1Sia_codcat_ceat";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_ESTREG_ESRG : Estados de registros (Activos o Inactivos)
        private void txtG1Sis_estreg_esrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_estreg_esrg_Browser();
            }
        }
        private void cmdG1Sis_estreg_esrg_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_estreg_esrg_Browser();
        }
        private void txtG1Sis_estreg_esrg_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISESTADOREGIST", "", "Estados de registros (Activos o Inactivos)...");
            gcrCtrF2TexBox = "txtG1Sis_estreg_esrg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_NROHIS_HICL : Maestro de historias clinicas
        private void txtG1Hcl_nrohis_hicl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_nrohis_hicl_Browser();
            }
        }
        private void cmdG1Hcl_nrohis_hicl_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_nrohis_hicl_Browser();
        }
        private void txtG1Hcl_nrohis_hicl_Browser()
        {
            Browser02 frbro = new Browser02("HCL", "HCLMAESTROHISCL", 1, "1*TODOS", "Maestro de historias clínicas...");
            gcrCtrF2TexBox = "txtG1Hcl_nrohis_hicl";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPER_PRET : Perntenencia Etnica
        private void txtG1Sia_codper_pret_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codper_pret_Browser();
            }
        }
        private void cmdG1Sia_codper_pret_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codper_pret_Browser();
        }
        private void txtG1Sia_codper_pret_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAPERTENETNICA", "", "Pertenencia Etnica...");
            gcrCtrF2TexBox = "txtG1Sia_codper_pret";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_NIVEDU_SINE : Nivel educativo usuario paciente
        private void txtG1Sia_nivedu_sine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_nivedu_sine_Browser();
            }
        }
        private void cmdG1Sia_nivedu_sine_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_nivedu_sine_Browser();
        }
        private void txtG1Sia_nivedu_sine_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIANIVELEDUCATI", "", "Nivel educativo usuario paciente...");
            gcrCtrF2TexBox = "txtG1Sia_nivedu_sine";
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
                        case "cboG1Sia_discap_usua":
                            txtG1Sia_discap_usua.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_discap_usua.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_discap_usua.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sia_discap_usua":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sia_discap_usua.SelectedItem;
                            cboG1Sia_discap_usua.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
                    case "dpkG1Sia_fecnac_usua":
                        txtG1Sia_fecnac_usua.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Sia_fecnac_usua);
                        break;
                    case "dpkG1Sia_feceps_usua":
                        txtG1Sia_feceps_usua.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Sia_feceps_usua);
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
                            case "txtG1Sia_fecnac_usua":
                                dpkG1Sia_fecnac_usua.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Sia_feceps_usua":
                                dpkG1Sia_feceps_usua.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
    }
}
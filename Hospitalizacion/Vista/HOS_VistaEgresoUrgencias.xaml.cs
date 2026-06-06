//- MARMOTA-GENCODE: VERSION 2.0 - 08/06/2015 06:15:38 AM
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
using Hospitalizacion.VistaModelo;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregurgencias
    /// </summary>
    public partial class VistaHosEgresoUrgencias : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloHosEgresoUrgencias gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        public string lcrFormModoPopup = "DFL";
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaHosEgresoUrgencias(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloHosEgresoUrgencias;
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
            dpkG1Adm_fecmue_regu.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                EFadmregurgencias lobReg = ADMValidarCodigo.fobRegBuscarAdmregurgencias(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_secegr_regu)) { llgExiste = true; }
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
            txtG1Adm_secegr_regu.Text = tcrCodigoIgTabla;
            txtG1Adm_secadm_rgad.Text = tcrCodigo1;
            txtG1Hos_codesp_espa.Text = tcrCodigo3;
            txtG1Adm_secaut_aegr.Text = tcrCodigo2;
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
            FocusManager.SetFocusedElement(this, txtG1Sia_idesec_usua);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sia_idesec_usua);
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
                FocusManager.SetFocusedElement(this, txtG1Adm_secegr_regu);
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
            Browser01 frbro = new Browser01("ADM", "ADMREGURGENCIAS", "", "Maestro registro salida de urgencias...");
            gcrCtrF2TexBox = "txtG1Adm_secegr_regu";
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
                case "txtG1Adm_secegr_regu":
                    txtG1Adm_secegr_regu.Text = tcrCodigo;
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

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

            }
        }
        // ADMREGURGENCIAS : Maestro registro salida de urgencias
        #region KeyDown para campos con F2 Tabla: ADMREGURGENCIAS
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
                txtG1Sia_dixre1_tdia_Browser();
            }
        }
        private void cmdG1Sia_dixre1_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_dixre1_tdia_Browser();
        }
        private void txtG1Sia_dixre1_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_dixre1_tdia";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG1Sia_dixre2_tdia_Browser();
            }
        }
        private void cmdG1Sia_dixre2_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_dixre2_tdia_Browser();
        }
        private void txtG1Sia_dixre2_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_dixre2_tdia";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG1Sia_dixre3_tdia_Browser();
            }
        }
        private void cmdG1Sia_dixre3_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_dixre3_tdia_Browser();
        }
        private void txtG1Sia_dixre3_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_dixre3_tdia";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG1Sia_dixmue_tdia_Browser();
            }
        }
        private void cmdG1Sia_dixmue_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_dixmue_tdia_Browser();
        }
        private void txtG1Sia_dixmue_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_dixmue_tdia";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG1Adm_secadm_rgad_Browser();
            }
        }
        private void cmdG1Adm_secadm_rgad_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_secadm_rgad_Browser();
        }
        private void txtG1Adm_secadm_rgad_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMREGADMISION", "", "Admisión de pacientes...");
            gcrCtrF2TexBox = "txtG1Adm_secadm_rgad";
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
        #region ADM_SECAUT_AEGR : Autorizacion de salida o egreso a pacientes
        private void txtG1Adm_secaut_aegr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_secaut_aegr_Browser();
            }
        }
        private void cmdG1Adm_secaut_aegr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_secaut_aegr_Browser();
        }
        private void txtG1Adm_secaut_aegr_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMORDENDSALIDA", "", "Autorizacion de salida o egreso a pacientes...");
            gcrCtrF2TexBox = "txtG1Adm_secaut_aegr";
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
                txtG1Sia_dixsal_tdia_Browser();
            }
        }
        private void cmdG1Sia_dixsal_tdia_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_dixsal_tdia_Browser();
        }
        private void txtG1Sia_dixsal_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "txtG1Sia_dixsal_tdia";
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
        private void cmdG1Sia_nroide_usua_Click(object sender, RoutedEventArgs e)
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
                        case "cboG1Adm_estsal_regu":
                            txtG1Adm_estsal_regu.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_estsal_regu.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_estsal_regu.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_dessal_regr":
                            txtG1Adm_dessal_regr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_dessal_regr.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_dessal_regr.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Adm_tipmue_regu":
                            txtG1Adm_tipmue_regu.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_tipmue_regu.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_tipmue_regu.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_estsal_regu":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Adm_estsal_regu.SelectedItem;
                            cboG1Adm_estsal_regu.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Adm_dessal_regr":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Adm_dessal_regr.SelectedItem;
                            cboG1Adm_dessal_regr.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Adm_tipmue_regu":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Adm_tipmue_regu.SelectedItem;
                            cboG1Adm_tipmue_regu.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
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
                    case "dpkG1Adm_fecegr_regu":
                        txtG1Adm_fecegr_regu.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecegr_regu);
                        break;
                    case "dpkG1Adm_fecmue_regu":
                        txtG1Adm_fecmue_regu.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Adm_fecmue_regu);
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
                            case "txtG1Adm_fecegr_regu":
                                //dpkG1Adm_fecegr_regu.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Adm_fecmue_regu":
                                dpkG1Adm_fecmue_regu.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
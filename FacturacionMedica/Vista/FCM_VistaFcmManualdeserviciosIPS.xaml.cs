//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2015 07:30:42 AM
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
using FacturacionMedica.VistaModelo;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmanservicips
    /// </summary>
    public partial class VistaFcmManualdeserviciosIPS : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloFcmManualdeserviciosIPS gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaFcmManualdeserviciosIPS()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloFcmManualdeserviciosIPS;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

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
            FocusManager.SetFocusedElement(this, txtG1Fcm_desser_sips);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Fcm_desser_sips);
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
        // Cuando se agregan variables a la lista, hay que validar
        private void txtG1Fcm_coddia_sips_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtG1Fcm_coddia_sips.Text))
            {
                gobObjVModelo.glgSIS_ValidacionListaOk = gobObjVModelo.GlgSIS_ModoEdicion == true ? false : true;
            }
            else
            {
                gobObjVModelo.glgSIS_ValidacionListaOk = true;
            }
        }
        // Cuando se cambia el diagnostico por defecto hay que validar lista de diagnósticos
        private void txtG1Sia_coddia_tdia_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtG1Sia_coddia_tdia.Text))
            {
                if (this.txtG1Sia_coddia_tdia.Text != "NA")
                {
                    gobObjVModelo.glgSIS_ValidacionListaOk = gobObjVModelo.GlgSIS_ModoEdicion == true ? false : true;
                }
            }
        }

        // Ejecutar la validacion de lista de variables
        private void cmdValidLista_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(gobObjVModelo.fcrValidacion("G1Fcm_coddia_sipsxx")))
            {
                fcvVistaLogErrores();
            }
            else
            {
                gobObjVModelo.glgSIS_ValidacionListaOk = true;
                MessageBox.Show("Validación correcta!!");
            }
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
                FocusManager.SetFocusedElement(this, txtG1Fcm_idesec_sips);
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
            var frbro = new Browser01Ex("FCM", "FCMMANSERVICIPS", "", "Maestro de servicios habilitados para la IPS...");
            gcrCtrF2TexBox = "txtG1Fcm_idesec_sips";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        // Browser Variables publicas
        #region fcvSetObjBrowserVariablesPublicas: buscar Variables publicas
        private void fcvSetObjBrowserVariablesPublicas(object sender, RoutedEventArgs e)
        {
            Browser01Ex frbro = new Browser01Ex("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "cmdAddVariables";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Fcm_idesec_sips":
                    txtG1Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codfpr_fpro":
                    txtG1Sia_codfpr_fpro.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codfco_fcon":
                    txtG1Sia_codfco_fcon.Text = tcrCodigo;
                    break;

                case "txtG1Adm_codcex_tcex":
                    txtG1Adm_codcex_tcex.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codrip_trip":
                    txtG1Sia_codrip_trip.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codser_soat":
                    txtG1Fcm_codser_soat.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codiva_tiva":
                    txtG1Sis_codiva_tiva.Text = tcrCodigo;
                    break;

                case "txtG1Inv_secart_mart":
                    txtG1Inv_secart_mart.Text = tcrCodigo;
                    break;

                case "txtG1Ssp_codcam_resc":
                    txtG1Ssp_codcam_resc.Text = tcrCodigo;
                    break;

                case "txtG1Inv_codaux_mart":
                    txtG1Inv_codaux_mart.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codsal_tsal":
                    txtG1Sis_codsal_tsal.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codgqx_grqx":
                    txtG1Fcm_codgqx_grqx.Text = tcrCodigo;
                    break;

                case "txtG1Grp_idepla_grpl":
                    txtG1Grp_idepla_grpl.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_codreg_hcca":
                    txtG1Hcl_codreg_hcca.Text = tcrCodigo;
                    break;

                case "txtG1Sia_coddia_tdia":
                    txtG1Sia_coddia_tdia.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipdxp_tdix":
                    txtG1Sia_tipdxp_tdix.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codpro_fcpr":
                    txtG1Fcm_codpro_fcpr.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_fcct":
                    txtG1Fcm_idesec_fcct.Text = tcrCodigo;
                    break;

                case "cmdAddVariables":

                    if (!Funciones.flgExisteElemento(tcrCodigo, ";", this.txtG1Fcm_coddia_sips.Text))
                    {                        
                        this.txtG1Fcm_coddia_sips.Text = String.IsNullOrWhiteSpace(this.txtG1Fcm_coddia_sips.Text) ? tcrCodigo : this.txtG1Fcm_coddia_sips.Text + ";" + tcrCodigo;
                    }
                    break;
            }
        }
        // FCMMANSERVICIPS : Maestro de servicios habilitados para la IPS
        #region KeyDown para campos con F2 Tabla: FCMMANSERVICIPS
        #region SIA_CODFPR_FPRO : Finalidad del Procedimiento
        private void txtG1Sia_codfpr_fpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codfpr_fpro_Browser();
            }
        }
        private void cmdG1Sia_codfpr_fpro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codfpr_fpro_Browser();
        }
        private void txtG1Sia_codfpr_fpro_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAFINALIPROCED", "", "Finalidad del Procedimiento...");
            gcrCtrF2TexBox = "txtG1Sia_codfpr_fpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODFCO_FCON : Finalidad de la Consulta
        private void txtG1Sia_codfco_fcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codfco_fcon_Browser();
            }
        }
        private void cmdG1Sia_codfco_fcon_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codfco_fcon_Browser();
        }
        private void txtG1Sia_codfco_fcon_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAFINALICONSUL", "", "Finalidad de la Consulta...");
            gcrCtrF2TexBox = "txtG1Sia_codfco_fcon";
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
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion...");
            gcrCtrF2TexBox = "txtG1Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region ADM_CODCEX_TCEX : Causa externa origen de atención
        private void txtG1Adm_codcex_tcex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_codcex_tcex_Browser();
            }
        }
        private void cmdG1Adm_codcex_tcex_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_codcex_tcex_Browser();
        }
        private void txtG1Adm_codcex_tcex_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMCAUSAEXTERNA", "", "Causa externa origen de atención...");
            gcrCtrF2TexBox = "txtG1Adm_codcex_tcex";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODRIP_TRIP : Tabla tipo RIPS
        private void txtG1Sia_codrip_trip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codrip_trip_Browser();
            }
        }
        private void cmdG1Sia_codrip_trip_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codrip_trip_Browser();
        }
        private void txtG1Sia_codrip_trip_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLATPRIPS", "", "Tabla tipo RIPS...");
            gcrCtrF2TexBox = "txtG1Sia_codrip_trip";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODSER_SOAT : Maestro listado  tarifario soat
        private void txtG1Fcm_codser_soat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codser_soat_Browser();
            }
        }
        private void cmdG1Fcm_codser_soat_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codser_soat_Browser();
        }
        private void txtG1Fcm_codser_soat_Browser()
        {
            Browser01Ex frbro = new Browser01Ex("FCM", "FCMSOATMANUALMA", "", "Tarifario SOAT...");
            gcrCtrF2TexBox = "txtG1Fcm_codser_soat";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODIVA_TIVA : Tabla de valores para el I.V.A.
        private void txtG1Sis_codiva_tiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codiva_tiva_Browser();
            }
        }
        private void cmdG1Sis_codiva_tiva_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codiva_tiva_Browser();
        }
        private void txtG1Sis_codiva_tiva_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTABLAIVA", "", "Tabla de valores para el I.V.A....");
            gcrCtrF2TexBox = "txtG1Sis_codiva_tiva";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_SECART_MART : Tabla Maestro Artículos
        private void txtG1Inv_secart_mart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_secart_mart_Browser();
            }
        }
        private void cmdG1Inv_secart_mart_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_secart_mart_Browser();
        }
        private void txtG1Inv_secart_mart_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVMAEARTICULOS", "", "Tabla Maestro Artículos...");
            gcrCtrF2TexBox = "txtG1Inv_secart_mart";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SSP_CODCAM_RESC : Campos de la Resolución 4505
        private void txtG1Ssp_codcam_resc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Ssp_codcam_resc_Browser();
            }
        }
        private void cmdG1Ssp_codcam_resc_Click(object sender, RoutedEventArgs e)
        {
            txtG1Ssp_codcam_resc_Browser();
        }
        private void txtG1Ssp_codcam_resc_Browser()
        {
            Browser01 frbro = new Browser01("SSP", "SPTABCAMPOS4505", "", "Campos de la Resolución 4505...");
            gcrCtrF2TexBox = "txtG1Ssp_codcam_resc";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region INV_CODAUX_MART : Tabla Maestro Artículos
        private void txtG1Inv_codaux_mart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codaux_mart_Browser();
            }
        }
        private void cmdG1Inv_codaux_mart_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codaux_mart_Browser();
        }
        private void txtG1Inv_codaux_mart_Browser()
        {
            Browser01 frbro = new Browser01("INV", "INVMAEARTICULOS", "", "Tabla Maestro Artículos...");
            gcrCtrF2TexBox = "txtG1Inv_codaux_mart";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODSAL_TSAL : Tabla de salarios minimos mensuales
        private void txtG1Sis_codsal_tsal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codsal_tsal_Browser();
            }
        }
        private void cmdG1Sis_codsal_tsal_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codsal_tsal_Browser();
        }
        private void txtG1Sis_codsal_tsal_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISSALARIOMIN", "", "Tabla de salarios minimos mensuales...");
            gcrCtrF2TexBox = "txtG1Sis_codsal_tsal";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODGQX_GRQX : Archivo para grupo quirurgicos
        private void txtG1Fcm_codgqx_grqx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codgqx_grqx_Browser();
            }
        }
        private void cmdG1Fcm_codgqx_grqx_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codgqx_grqx_Browser();
        }
        private void txtG1Fcm_codgqx_grqx_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMGRQUIRURGICO", "", "Grupos quirúrgicos...");
            gcrCtrF2TexBox = "txtG1Fcm_codgqx_grqx";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region GRP_IDEPLA_GRPL : Maestro de plantillas
        private void txtG1Grp_idepla_grpl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Grp_idepla_grpl_Browser();
            }
        }
        private void cmdG1Grp_idepla_grpl_Click(object sender, RoutedEventArgs e)
        {
            txtG1Grp_idepla_grpl_Browser();
        }
        private void txtG1Grp_idepla_grpl_Browser()
        {
            Browser01 frbro = new Browser01("GRP", "GRPMAEPLANTILLA", "", "Maestro de plantillas...");
            gcrCtrF2TexBox = "txtG1Grp_idepla_grpl";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_CODREG_HCCA : Tipo registro de actividad en historial
        private void txtG1Hcl_codreg_hcca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_codreg_hcca_Browser();
            }
        }
        private void cmdG1Hcl_codreg_hcca_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_codreg_hcca_Browser();
        }
        private void txtG1Hcl_codreg_hcca_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGACTIV", "", "Tipo registro de actividad en historial...");
            gcrCtrF2TexBox = "txtG1Hcl_codreg_hcca";
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
        #region SIA_TIPDXP_TDIX : Tipo diagnostico principal
        private void txtG1Sia_tipdxp_tdix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipdxp_tdix_Browser();
            }
        }
        private void cmdG1Sia_tipdxp_tdix_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipdxp_tdix_Browser();
        }
        private void txtG1Sia_tipdxp_tdix_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPODIAGPRIN", "", "Tipo diagnostico principal...");
            gcrCtrF2TexBox = "txtG1Sia_tipdxp_tdix";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODPRO_FCPR : UNSPSC Para productos
        private void txtG1Fcm_codpro_fcpr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codpro_fcpr_Browser();
            }
        }
        private void cmdG1Fcm_codpro_fcpr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codpro_fcpr_Browser();
        }
        private void txtG1Fcm_codpro_fcpr_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEUNSPSCDPRODU", "", "UNSPSC Para productos...");
            gcrCtrF2TexBox = "txtG1Fcm_codpro_fcpr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_IDESEC_FCCT : Categorias servicios y suministros IPS
        private void txtG1Fcm_idesec_fcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_idesec_fcct_Browser();
            }
        }
        private void cmdG1Fcm_idesec_fcct_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_idesec_fcct_Browser();
        }
        private void txtG1Fcm_idesec_fcct_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICATE", "", "Categorias servicios y suministros...");
            gcrCtrF2TexBox = "txtG1Fcm_idesec_fcct";
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
                        case "cboG1Fcm_tipser_sips":
                            txtG1Fcm_tipser_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_tipser_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_tipser_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_estser_sips":
                            txtG1Fcm_estser_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_estser_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_estser_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_codtse_sips":
                            txtG1Fcm_codtse_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_codtse_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_codtse_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_claser_sips":
                            txtG1Fcm_claser_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_claser_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_claser_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_edtval_sips":
                            txtG1Fcm_edtval_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_edtval_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_edtval_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_nivcom_sips":
                            txtG1Fcm_nivcom_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_nivcom_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_nivcom_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_codpat_tpat":
                            txtG1Sia_codpat_tpat.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_codpat_tpat.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_codpat_tpat.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_lamccp_sips":
                            txtG1Fcm_lamccp_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_lamccp_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_lamccp_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_lhoccp_sips":
                            txtG1Fcm_lhoccp_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_lhoccp_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_lhoccp_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_luoccp_sips":
                            txtG1Fcm_luoccp_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_luoccp_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_luoccp_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sia_tipact_tsac":
                            txtG1Sia_tipact_tsac.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sia_tipact_tsac.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sia_tipact_tsac.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_otserv_sips":
                            txtG1Fcm_otserv_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_otserv_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_otserv_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_serpos_sips":
                            txtG1Fcm_serpos_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_serpos_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_serpos_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_tipval_resc":
                            txtG1Ssp_tipval_resc.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_tipval_resc.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_tipval_resc.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_camdig_resc":
                            txtG1Ssp_camdig_resc.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_camdig_resc.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_camdig_resc.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_mededi_sips":
                            txtG1Fcm_mededi_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_mededi_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_mededi_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_mededf_sips":
                            txtG1Fcm_mededf_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_mededf_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_mededf_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_mededp_sips":
                            txtG1Fcm_mededp_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_mededp_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_mededp_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_sexapl_sips":
                            txtG1Fcm_sexapl_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_sexapl_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_sexapl_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_aplfus_sips":
                            txtG1Fcm_aplfus_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_aplfus_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_aplfus_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_perfus_sips":
                            txtG1Fcm_perfus_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_perfus_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_perfus_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_genhis_sips":
                            txtG1Fcm_genhis_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_genhis_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_genhis_sips.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Fcm_tipser_sips":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Fcm_tipser_sips.SelectedItem;
                            cboG1Fcm_tipser_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Fcm_estser_sips":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Fcm_estser_sips.SelectedItem;
                            cboG1Fcm_estser_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Fcm_codtse_sips":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Fcm_codtse_sips.SelectedItem;
                            cboG1Fcm_codtse_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Fcm_claser_sips":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Fcm_claser_sips.SelectedItem;
                            cboG1Fcm_claser_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Fcm_edtval_sips":
                            CrtForms.ListaComboBox lobG1ComboBox4X = (CrtForms.ListaComboBox)cboG1Fcm_edtval_sips.SelectedItem;
                            cboG1Fcm_edtval_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4X.ListaValoresSel);
                            break;
                        case "txtG1Fcm_nivcom_sips":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Fcm_nivcom_sips.SelectedItem;
                            cboG1Fcm_nivcom_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Sia_codpat_tpat":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Sia_codpat_tpat.SelectedItem;
                            cboG1Sia_codpat_tpat.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Fcm_lamccp_sips":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Fcm_lamccp_sips.SelectedItem;
                            cboG1Fcm_lamccp_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Fcm_lhoccp_sips":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Fcm_lhoccp_sips.SelectedItem;
                            cboG1Fcm_lhoccp_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
                            break;
                        case "txtG1Fcm_luoccp_sips":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Fcm_luoccp_sips.SelectedItem;
                            cboG1Fcm_luoccp_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Sia_tipact_tsac":
                            CrtForms.ListaComboBox lobG1ComboBox10 = (CrtForms.ListaComboBox)cboG1Sia_tipact_tsac.SelectedItem;
                            cboG1Sia_tipact_tsac.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox10.ListaValoresSel);
                            break;
                        case "txtG1Fcm_otserv_sips":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)cboG1Fcm_otserv_sips.SelectedItem;
                            cboG1Fcm_otserv_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
                            break;
                        case "txtG1Fcm_serpos_sips":
                            CrtForms.ListaComboBox lobG1ComboBox12 = (CrtForms.ListaComboBox)cboG1Fcm_serpos_sips.SelectedItem;
                            cboG1Fcm_serpos_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox12.ListaValoresSel);
                            break;
                        case "txtG1Ssp_tipval_resc":
                            CrtForms.ListaComboBox lobG1ComboBox13 = (CrtForms.ListaComboBox)cboG1Ssp_tipval_resc.SelectedItem;
                            cboG1Ssp_tipval_resc.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox13.ListaValoresSel);
                            break;
                        case "txtG1Ssp_camdig_resc":
                            CrtForms.ListaComboBox lobG1ComboBox14 = (CrtForms.ListaComboBox)cboG1Ssp_camdig_resc.SelectedItem;
                            cboG1Ssp_camdig_resc.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox14.ListaValoresSel);
                            break;
                        case "txtG1Fcm_mededi_sips":
                            CrtForms.ListaComboBox lobG1ComboBox15 = (CrtForms.ListaComboBox)cboG1Fcm_mededi_sips.SelectedItem;
                            cboG1Fcm_mededi_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox15.ListaValoresSel);
                            break;
                        case "txtG1Fcm_mededf_sips":
                            CrtForms.ListaComboBox lobG1ComboBox16 = (CrtForms.ListaComboBox)cboG1Fcm_mededf_sips.SelectedItem;
                            cboG1Fcm_mededf_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox16.ListaValoresSel);
                            break;
                        case "txtG1Fcm_mededp_sips":
                            CrtForms.ListaComboBox lobG1ComboBox17 = (CrtForms.ListaComboBox)cboG1Fcm_mededp_sips.SelectedItem;
                            cboG1Fcm_mededp_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox17.ListaValoresSel);
                            break;
                        case "txtG1Fcm_sexapl_sips":
                            CrtForms.ListaComboBox lobG1ComboBox18 = (CrtForms.ListaComboBox)cboG1Fcm_sexapl_sips.SelectedItem;
                            cboG1Fcm_sexapl_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox18.ListaValoresSel);
                            break;
                        case "txtG1Fcm_aplfus_sips":
                            CrtForms.ListaComboBox lobG1ComboBox19 = (CrtForms.ListaComboBox)cboG1Fcm_aplfus_sips.SelectedItem;
                            cboG1Fcm_aplfus_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox19.ListaValoresSel);
                            break;
                        case "txtG1Fcm_perfus_sips":
                            CrtForms.ListaComboBox lobG1ComboBox20 = (CrtForms.ListaComboBox)cboG1Fcm_perfus_sips.SelectedItem;
                            cboG1Fcm_perfus_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox20.ListaValoresSel);
                            break;
                        case "txtG1Fcm_genhis_sips":
                            CrtForms.ListaComboBox lobG1ComboBox21 = (CrtForms.ListaComboBox)cboG1Fcm_genhis_sips.SelectedItem;
                            cboG1Fcm_genhis_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox21.ListaValoresSel);
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
    }
}
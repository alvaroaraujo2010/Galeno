//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2018 04:59:56 PM
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
using Admision.VistaModelo;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace Admision.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admtriagemaconf
    /// </summary>
    public partial class VistaConfigTriage : Window, SIS_Interface
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
        public bool glgVistaPropiedades = false;
        VistaModeloConfigTriage vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaConfigTriage()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloConfigTriage;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            //SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

        }
        #endregion
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

            this.grdPropiedadZona1.Height = lduHeight;
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
            FocusManager.SetFocusedElement(this, txtG1Adm_clasif_tria);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Adm_clasif_tria);
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
                FocusManager.SetFocusedElement(this, txtG1Adm_nroreg_adct);
                gnuIndexReg = grdDetalles.SelectedIndex;
                grdDetalles.IsEnabled = false;
                //cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                grdDetalles.IsEnabled = true;
                //cmdAdicionar.Visibility = Visibility.Visible;
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloConfigTriage();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
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
                case "txtG1Sia_areing_aser":
                    txtG1Sia_areing_aser.Text = tcrCodigo;
                    break;

                case "txtG1Adm_codoad_toad":
                    txtG1Adm_codoad_toad.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Adm_codtat_tatn":
                    txtG1Adm_codtat_tatn.Text = tcrCodigo;
                    break;

                case "txtG1Adm_codcex_tcex":
                    txtG1Adm_codcex_tcex.Text = tcrCodigo;
                    break;

            }
        }
        // ADMTRIAGEMACONF : Configuracion parametros evaluación Triage
        #region KeyDown para campos con F2 Tabla: ADMTRIAGEMACONF
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
        #region ADM_CODOAD_TOAD : Tipo origen de la admisión
        private void txtG1Adm_codoad_toad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_codoad_toad_Browser();
            }
        }
        private void cmdG1Adm_codoad_toad_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_codoad_toad_Browser();
        }
        private void txtG1Adm_codoad_toad_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMVIAINGRESO", "", "Tipo origen de la admisión...");
            gcrCtrF2TexBox = "txtG1Adm_codoad_toad";
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
        #region ADM_CODTAT_TATN : Ambito de atención paciente
        private void txtG1Adm_codtat_tatn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Adm_codtat_tatn_Browser();
            }
        }
        private void cmdG1Adm_codtat_tatn_Click(object sender, RoutedEventArgs e)
        {
            txtG1Adm_codtat_tatn_Browser();
        }
        private void txtG1Adm_codtat_tatn_Browser()
        {
            Browser01 frbro = new Browser01("ADM", "ADMTIPOATENCION", "", "Ambito de atención paciente...");
            gcrCtrF2TexBox = "txtG1Adm_codtat_tatn";
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
                        case "cboG1Adm_estreg_adct":
                            txtG1Adm_estreg_adct.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Adm_estreg_adct.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Adm_estreg_adct.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Adm_clasif_tria":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Adm_clasif_tria.SelectedItem;
                            cboG1Adm_clasif_tria.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActualizarVistaTriage();
                            break;
                        case "txtG1Adm_remisi_tria":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Adm_remisi_tria.SelectedItem;
                            cboG1Adm_remisi_tria.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Adm_estreg_adct":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Adm_estreg_adct.SelectedItem;
                            cboG1Adm_estreg_adct.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
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
                    var lcrImagenVista = "sys_usu02.png";
                    var lcrColorNivelC = "#FFF3F3F3";

                    var lcrCodigoClasif = this.txtG1Adm_clasif_tria.Text;
                    if (!String.IsNullOrWhiteSpace(lcrCodigoClasif))
                    {
                        var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaconfNivel(lcrCodigoClasif);
                        if (tmp != null)
                        {                            
                            lcrImagenVista = tmp.adm_imagen_adct;
                            lcrColorNivelC = tmp.adm_icolor_adct;                      
                        }
                    }
                    this.objColorTriage.Background = Funciones.FuxSetSolidColorBrush(lcrColorNivelC);
                    //this.imgImagenNivel.Source = new BitmapImage(new Uri(lcrUri + lcrImagenVista, UriKind.RelativeOrAbsolute));

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarVistaTriage");
            }
        }
        #endregion
        //-------------------------------------------------
        // Capa de Propiedades
        //-------------------------------------------------
        #region Capa de Propiedades
        //-------------------------------------------------
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana seleccion obra
        /// <summary>
        /// <para>Mostrar Ventana seleccion obra</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = -610; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = false;
            }
            this.grdPropiedadZona1.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 06/10/2014 05:17:31 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using Sistema.Utilidades;
using Sistema.VistaModelo;
using System.Xml;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Sistema.Vista;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Validacion;

namespace Sistema.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sismaesplavalid
    /// </summary>
    public partial class VistaSismaesplavalid : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        bool glgVistaEtiquetaEstadoVisible = false;
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        VistaModeloSismaesplavalid gobObjVModelo = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSismaesplavalid()
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloSismaesplavalid;
            gobObjVModelo.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;
            // solo codigo c# por defecto
            this.txtCodigoEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
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
            double lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;

            this.cvaEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.036);
            this.grdEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.036);

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
            FocusManager.SetFocusedElement(this, txtG1Sis_codarc_siar);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Sis_ordvis_sivd);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sis_codarc_siar);
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
            gobObjVModelo.G2Sis_codval_sivd = this.txtCodigoEditor.Text.Trim();
            gobObjVModelo.GuardarRel();
            FocusManager.SetFocusedElement(this, txtG2Sis_ordvis_sivd);
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
            FocusManager.SetFocusedElement(this, txtG2Sis_ordvis_sivd);
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Sis_secreg_siva":
                    this.txtG1Sis_secreg_siva.Text = tcrCodigo;
                    break;

                case "txtG1Sis_codarc_siar":
                    this.txtG1Sis_codarc_siar.Text = tcrCodigo;
                    break;

                case "txtG2Sis_codcam_sivd":
                    var lobReg = SISValidarCodigo.fobRegBuscarSismadeplavalid(tcrCodigo);
                    if (!String.IsNullOrWhiteSpace(lobReg.sis_codcam_sivd))
                    {
                        this.txtG2Sis_ordvis_sivd.Text = lobReg.sis_ordvis_sivd.ToString();
                        this.txtG2Sis_codcam_sivd.Text = lobReg.sis_codcam_sivd.Trim();
                        this.txtG2Sis_nomcam_sivd.Text = lobReg.sis_nomcam_sivd.Trim();
                        this.txtG2Sis_estreg_sivd.Text = lobReg.sis_estreg_sivd.Trim();
                        this.txtG2Sis_codval_sivd.Text = lobReg.sis_codval_sivd.Trim();
                    }
                    break;

                    
            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // SISMAESPLAVALID : Maestro plantillas para validación de archivos
        #region KeyDown para campos con F2 Tabla: SISMAESPLAVALID
        #region SIS_CODARC_SIAR : Clasificacion de archivos para gestion de datos e informes
        private void txtG1Sis_codarc_siar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_codarc_siar_Browser();
            }
        }
        private void cmdG1Sis_codarc_siar_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_codarc_siar_Browser();
        }
        private void txtG1Sis_codarc_siar_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISTIPOARCHIVOS", "", "Clasificacion de archivos para gestion de datos e informes...");
            gcrCtrF2TexBox = "txtG1Sis_codarc_siar";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //Nombre único de campos (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD) 
        //Buscar en plantilla base segun archivo: RIPSAC = Rips consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505 y otros
        #region SIS_CODCAM_SIVD : Nombre único del campo (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD)
        private void txtG2Sis_codcam_sivd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sis_codcam_sivd_Browser();
            }
        }
        private void cmdG2Sis_codcam_sivd_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sis_codcam_sivd_Browser();
        }
        private void txtG2Sis_codcam_sivd_Browser()
        {
            // Verificar si existe plantilla base 
            if (!String.IsNullOrWhiteSpace(txtG1Sis_codarc_siar.Text) && txtG1Sis_tippla_siva.Text != "1")
            {
                var lobReg = SISValidarCodigo.fobRegBuscarSismaesplavalidPb(txtG1Sis_codarc_siar.Text);
                if (lobReg == null) { return; }

                if (lobReg.sis_secreg_siva != this.txtG1Sis_secreg_siva.Text)
                {
                    var lcrFiltro = "Sismadeplavalid.sis_secreg_siva = '" + lobReg.sis_secreg_siva.Trim() + "'";

                    Browser01 frbro = new Browser01("SIS", "SISMADEPLAVALID", lcrFiltro, "Buscar en: " + lobReg.sis_despla_siva.Trim() + "...");
                    gcrCtrF2TexBox = "txtG2Sis_codcam_sivd";
                    frbro.Owner = this;
                    frbro.ShowDialog();
                }
            }
        }
        #endregion
        #endregion
        // SISMADEPLAVALID : Registros o campos detalle para plantillas de validación
        #region KeyDown para campos con F2 Tabla: SISMADEPLAVALID
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESPLAVALID", "", "Maestro plantillas para validación de archivos...");
            gcrCtrF2TexBox = "txtG1Sis_secreg_siva";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
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
                        case "cboG1Sis_tippla_siva":
                            txtG1Sis_tippla_siva.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_tippla_siva.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_tippla_siva.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sis_estreg_siva":
                            txtG1Sis_estreg_siva.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_estreg_siva.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_estreg_siva.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sis_estreg_sivd":
                            txtG2Sis_estreg_sivd.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sis_estreg_sivd.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sis_estreg_sivd.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sis_tippla_siva":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sis_tippla_siva.SelectedItem;
                            cboG1Sis_tippla_siva.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Sis_estreg_siva":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Sis_estreg_siva.SelectedItem;
                            cboG1Sis_estreg_siva.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Sis_estreg_sivd":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Sis_estreg_sivd.SelectedItem;
                            cboG2Sis_estreg_sivd.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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
        // Actualizar Actualizar Editor codigo fuente
        //-------------------------------------------------
        #region Actualizar Editor codigo fuente
        private void ActualizarEditor(object sender, TextChangedEventArgs e)
        {
            if (this.txtCodigoEditor != null)
            {
                StringBuilder lobString = new StringBuilder();
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");
                                lobString.AppendLine("");

                if (!String.IsNullOrWhiteSpace(txtG2Sis_codval_sivd.Text))
                {
                    this.txtCodigoEditor.Text = lobString.ToString() + txtG2Sis_codval_sivd.Text;
                }
                else
                {
                    this.txtCodigoEditor.Text = String.Empty;
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // EJECUTAR VALIDACION 
        //-------------------------------------------------
        #region  fcvEjecutaValidacion: Ejecutar la validacion
        private void fcvEjecutaValidacion(object sender, RoutedEventArgs e)
        {
            fcvIniciarValidacionDatos();
            if (glgVistaEtiquetaEstadoVisible == false)
            {
                fcvVistaErroresCompilacion();
            }
        }
        #endregion
        #region fcvIniciarValidacionDatos: Inicia el proceso de validacion de los datos en la vista
        /// <summary>
        /// <para>Inicia el proceso de validacion de los datos en la vista</para>
        /// </summary>
        private void fcvIniciarValidacionDatos()
        {
            if (String.IsNullOrWhiteSpace(this.txtCodigoEditor.Text)) { MessageBox.Show("No hay datos para validar"); return; }

            StringBuilder lobString = new StringBuilder();
                        lobString.AppendLine("using System;              ");
                        lobString.AppendLine("using System.Text;         ");
                        lobString.AppendLine("using Sistema.Utilidades;  ");
                        lobString.AppendLine("using Sistema.Modelo;      ");
                        lobString.AppendLine("using Sistema.Clases;      ");
                        lobString.AppendLine("using Sistema.Validacion;  ");
                        lobString.AppendLine("using Datos.Modelos;       ");
                        lobString.AppendLine(" ");

            String lcrCodigoFuente = lobString.ToString() + this.txtCodigoEditor.Text.Trim();
            var larListaDll = new List<String>();
            larListaDll.Add("System.dll");
            larListaDll.Add("Datos.dll");
            larListaDll.Add("System.Data.Entity.dll");

            this.txtErrorCompiler.Foreground = Brushes.Blue;
            this.txtErrorCompiler.Text = String.Empty;

            gobEnsamblado = Compilador.fobCompilarEnsamblado("C#", lcrCodigoFuente, larListaDll);

            if (gobEnsamblado.Errors.Count == 0)
            {
                this.txtErrorCompiler.Text = "Validación ok...";
            }
            else
            {
                this.txtErrorCompiler.Foreground = Brushes.Red;

                foreach (CompilerError CompErr in gobEnsamblado.Errors)
                {
                    this.txtErrorCompiler.Text = this.txtErrorCompiler.Text +
                                                "Número de línea " + CompErr.Line +
                                                ", Número de error: " + CompErr.ErrorNumber +
                                                ", '" + CompErr.ErrorText + ";" +
                                                Environment.NewLine + Environment.NewLine;
                }
            }

        }
        #endregion
        #region Capa Vista errores de compilacion 
        #region fcvActivarVistaErrores: Mostrar u Ocultar Vista Capa Vista errores de compilacion
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa Vista errores de compilacion</para> 
        /// </summary>
        private void fcvActivarVistaErrores(object sender, RoutedEventArgs e)
        {
            fcvVistaErroresCompilacion();
        }
        #endregion
        #region fcvVistaErroresCompilacion: Mostrar u Ocultar Vista Capa errores compilacion
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa Etiqueta</para> 
        /// </summary>
        private void fcvVistaErroresCompilacion()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaEtiquetaEstadoVisible == false)
            {
                luxAnimacion.To = -340; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaEtiquetaEstadoVisible = true;
                this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
            }
            else
            {
                luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaEtiquetaEstadoVisible = false;
                this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
            }
        }
        #endregion
        #endregion
    }
}
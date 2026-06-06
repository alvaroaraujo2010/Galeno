//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2015 08:40:29 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using ConfigAsistencial.VistaModelo;

namespace ConfigAsistencial.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: siamaeprofsalud
    /// </summary>
    public partial class VistaSiamaeprofsalud : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public Aplicacion oApp = Aplicacion.Instancia();
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public String gcrCtrF2TexBox;
        public String gcrRutaImgGaleria = String.Empty;
        public String gcrRutaImgDestino = String.Empty;
        public ArchivoRecurso gobImagenFirma = null;
        VistaModeloSiamaeprofsalud vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSiamaeprofsalud()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloSiamaeprofsalud;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            // ruta por defecto para las imagenes de firmas
            gcrRutaImgGaleria = oApp.gcrAppRecursoPath + @"\Imagenes\General\Sistemas";
            gcrRutaImgDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + gcrRutaImgGaleria;

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

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Sia_codesp_esme);
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

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("SAVREL");
            FocusManager.SetFocusedElement(this, txtG2Sia_codesp_esme);
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
            FocusManager.SetFocusedElement(this, txtG2Sia_codesp_esme);
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
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                if (tcrTipoEdicion == "SAV")
                {
                    // Guardar para poder generar el nombre del archivo
                    vm.Guardar();
                    fcvCopiarImagen();
                    this.txtFirmaImagenRuta.Text = String.Empty;
                    gobImagenFirma = null;
                }
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
                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipide_tide":
                    txtG1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codprm_prom":
                    txtG1Sia_codprm_prom.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpat_tpat":
                    txtG1Sia_codpat_tpat.Text = tcrCodigo;
                    break;

                case "txtG1Con_idesec_mter":
                    txtG1Con_idesec_mter.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codusu_usux":
                    txtG1Sys_codusu_usux.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codesp_esme":
                    txtG2Sia_codesp_esme.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // SIAMAEPROFSALUD : Profesionales que prestan servicios
        #region KeyDown para campos con F2 Tabla: SIAMAEPROFSALUD
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
        #region SIA_CODPRM_PROM : Profesiones de salud
        private void txtG1Sia_codprm_prom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codprm_prom_Browser();
            }
        }
        private void cmdG1Sia_codprm_prom_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codprm_prom_Browser();
        }
        private void txtG1Sia_codprm_prom_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAPROFESISALUD", "", "Profesiones de salud...");
            gcrCtrF2TexBox = "txtG1Sia_codprm_prom";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPAT_TPAT : Tipo profesional que atiende
        private void txtG1Sia_codpat_tpat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codpat_tpat_Browser();
            }
        }
        private void cmdG1Sia_codpat_tpat_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codpat_tpat_Browser();
        }
        private void txtG1Sia_codpat_tpat_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPPROFATIEN", "", "Tipo profesional que atiende...");
            gcrCtrF2TexBox = "txtG1Sia_codpat_tpat";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region CON_IDESEC_MTER : Tabla terceros para gestion contable
        private void txtG1Con_idesec_mter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Con_idesec_mter_Browser();
            }
        }
        private void cmdG1Con_idesec_mter_Click(object sender, RoutedEventArgs e)
        {
            txtG1Con_idesec_mter_Browser();
        }
        private void txtG1Con_idesec_mter_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS", "", "Tabla terceros para gestion contable...");
            gcrCtrF2TexBox = "txtG1Con_idesec_mter";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODUSU_USUX : Maestro de Usuarios del Sistema
        private void txtG1Sys_codusu_usux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sys_codusu_usux_Browser();
            }
        }
        private void cmdG1Sys_codusu_usux_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sys_codusu_usux_Browser();
        }
        private void txtG1Sys_codusu_usux_Browser()
        {
            Browser01 frbro = new Browser01("SYS", "SYSUSUARIOS", "", "Maestro de Usuarios del Sistema...");
            gcrCtrF2TexBox = "txtG1Sys_codusu_usux";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // SIAMAEPROFESPAS : Especialidades asignadas a profesional
        #region KeyDown para campos con F2 Tabla: SIAMAEPROFESPAS
        #region SIA_CODESP_ESME : Especialidades medicas
        private void txtG2Sia_codesp_esme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Sia_codesp_esme_Browser();
            }
        }
        private void cmdG2Sia_codesp_esme_Click(object sender, RoutedEventArgs e)
        {
            txtG2Sia_codesp_esme_Browser();
        }
        private void txtG2Sia_codesp_esme_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAESPECIALIMED", "", "Especialidades medicas...");
            gcrCtrF2TexBox = "txtG2Sia_codesp_esme";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
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
                        case "cboG1Sis_estreg_esrg":
                            txtG1Sis_estreg_esrg.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sis_estreg_esrg.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sis_estreg_esrg.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sis_estreg_esrg":
                            txtG2Sis_estreg_esrg.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sis_estreg_esrg.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sis_estreg_esrg.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sis_estreg_esrg":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sis_estreg_esrg.SelectedItem;
                            cboG1Sis_estreg_esrg.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG2Sis_estreg_esrg":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Sis_estreg_esrg.SelectedItem;
                            cboG2Sis_estreg_esrg.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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
        //  Metodos Buscar imagen de la firma
        //-------------------------------------------------
        #region fcvGetObjRecursoImportar: Abrir el explorador de windows para buscar una imagen fija
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar una imagen fija</para>
        /// </summary>
        private void fcvGetObjRecursoImportar(object sender, RoutedEventArgs e)
        {

            try
            {
                gobImagenFirma = fobBuscarArchivoRecurso("Buscar Imagen...", ".jpg", "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg");

                if (gobImagenFirma != null)
                {
                    String lcrArchivoOrigen = gobImagenFirma.RutayArchivo;

                    // poner doble lineas cuando lo requiera
                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        gcrRutaImgDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + gcrRutaImgGaleria;
                        lcrArchivoOrigen = System.IO.Path.Combine(gobImagenFirma.RutayArchivo);
                    }
                    var lobUri = new Uri(lcrArchivoOrigen, UriKind.RelativeOrAbsolute);

                    // Mostrar datos en vista
                    this.txtFirmaTipo.Text       = "IMAGEN";
                    this.txtFirmaArchivoUri.Text = gcrRutaImgGaleria;
                    this.txtFirmaImagen.Text     = gobImagenFirma.Extencion;   //Para indicar en el vistamodelobase cual es l tipo de archivo  
                    this.txtFirmaImagenRuta.Text = gobImagenFirma.RutayArchivo;

                    // Mostrar la imagen
                    this.imgFirma.Source = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvGetObjImagenImportar");
            }
        }
        #region xxxx
        /*
        private void fcvGetObjRecursoImportar(object sender, RoutedEventArgs e)
        {
            var lcrRutayArchivo = String.Empty;
            var lcrNombreArchivo = String.Empty;

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                GcrRutaImgDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + gcrRutaImgGaleria;
            }

            try
            {
                gobImagenFirma = fobBuscarArchivoRecurso("Buscar Imagen...", ".jpg", "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg");

                if (gobImagenFirma != null)
                {
                    lcrRutayArchivo = gobImagenFirma.RutayArchivo;
                    lcrNombreArchivo = "IMG001_" + gobImagenFirma.NombreArchivo;
                    String lcrArchivoOrigen = lcrRutayArchivo;
                    String lcrArchivoDestino = GcrRutaImgDestino + @"\" + lcrNombreArchivo;

                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        lcrArchivoOrigen = System.IO.Path.Combine(lcrRutayArchivo);
                        lcrArchivoDestino = System.IO.Path.Combine(GcrRutaImgDestino, lcrNombreArchivo);
                    }

                    if (!File.Exists(lcrArchivoDestino))
                    {
                        System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                    }

                    var lobUri = new Uri(lcrArchivoDestino, UriKind.RelativeOrAbsolute);

                    // Mostrar datos en vista
                    this.txtFirmaTipo.Text = "IMAGEN";
                    this.txtFirmaArchivoUri.Text = gcrRutaImgGaleria;
                    this.txtPropTxtRecursoArchivoNombre.Text = lcrNombreArchivo;
                    this.txtImagenRuta.Text = gobImagenFirma.RutayArchivo;

                    // Mostrar la imagen
                    this.imgFirma.Source = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvGetObjImagenImportar");
            }
        }
        */
        #endregion
        #endregion
        #region ArchivoRecurso: Datos del archivo de recursos localizado en sistema
        /// <summary>
        /// <para>Datos del archivo de recursos localizado desde el explorador de windows</para>
        /// </summary>
        public class ArchivoRecurso
        {
            public ArchivoRecurso() { }

            public String RutayArchivo { get; set; }
            public String NombreArchivo { get; set; }
            public String Extencion { get; set; }
        }
        #endregion
        #region fobBuscarArchivoRecurso: Abrir el explorador de windows para buscar un archivo de recurso
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar un archivo de recurso</para>
        /// <para>tcrExtPorDefecto: ".jpg"</para>
        /// <para>tcrFiltro: "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg" </para>
        /// </summary>
        public static ArchivoRecurso fobBuscarArchivoRecurso(String tcrTitulo, String tcrExtPorDefecto, String tcrFiltro)
        {
            ArchivoRecurso lobValor = null;

            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title = tcrTitulo;
            lopenFileDialog.Filter = tcrFiltro;
            lopenFileDialog.DefaultExt = tcrExtPorDefecto; // Extencion de archivos por defecto
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;
            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                lobValor = new ArchivoRecurso();
                lobValor.RutayArchivo = lopenFileDialog.FileName;
                lobValor.NombreArchivo = lopenFileDialog.SafeFileName;
                lobValor.Extencion = lobValor.NombreArchivo.Substring(lobValor.NombreArchivo.Length - 3, 3).ToUpper();
            }
            return lobValor;
        }
        #endregion
        #region fcvCopiarImagen: Enviar la imagen a la ruta de almacenamiento en el servidor
        /// <summary>
        /// <para>Enviar la imagen a la ruta de almacenamiento en el servidor</para>
        /// </summary>
        private void fcvCopiarImagen()
        {
            try
            {
                if (gobImagenFirma != null)
                {
                    var lcrRutayArchivo = String.Empty;
                    var lcrNombreArchivo = String.Empty;
                    //lcrNombreArchivo = vm.G1Sia_codpfa_prof.Trim() + "_FIRMA";
                    lcrRutayArchivo          = gobImagenFirma.RutayArchivo; // leer archivo desde ruta origen
                    //lcrNombreArchivo = vm.G1Sia_ifirma_prof;
                    lcrNombreArchivo = this.txtFirmaImagen.Text;
                    String lcrArchivoOrigen  = lcrRutayArchivo;
                    String lcrArchivoDestino = gcrRutaImgDestino + @"\" + lcrNombreArchivo;

                    // Colocar doble barras en divisores de ruta ejemplo: c://ruta//galeria
                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        lcrArchivoOrigen = System.IO.Path.Combine(lcrRutayArchivo);
                        lcrArchivoDestino = System.IO.Path.Combine(gcrRutaImgDestino, lcrNombreArchivo);
                    }
                    // Sobre escribir cuando el archivo exista
                    System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvCopiarImagen");
            }
        }
        #endregion
        #region txtFirmaImagen_TextChanged: Cambiar la vista imagen firma del profesional
        /// <summary>
        /// <para>Cambiar la vista imagen firma del profesional</para>
        /// </summary>
        private void txtFirmaImagen_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lobTexto = (TextBox)sender;
            if (lobTexto != null)
            { 
                if (!String.IsNullOrWhiteSpace(lobTexto.Text) && lobTexto.Text != "PNG"  && 
                    lobTexto.Text != "JPG"  && lobTexto.Text != "BMP")
                {
                    if (llgModoEdicion == false) { this.imgFirma.Source = null; }

                    String lcrArchivoDestino = gcrRutaImgDestino + @"\" + lobTexto.Text;

                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        lcrArchivoDestino = System.IO.Path.Combine(gcrRutaImgDestino, lobTexto.Text);
                    }

                    // Mostrar la imagen
                    if (File.Exists(lcrArchivoDestino))
                    {
                        var lobUri = new Uri(lcrArchivoDestino, UriKind.RelativeOrAbsolute);
                        this.imgFirma.Source = new BitmapImage(lobUri);
                    }
                }
                else if (String.IsNullOrWhiteSpace(lobTexto.Text))
                {
                    if (llgModoEdicion == false) 
                    { 
                        this.imgFirma.Source = null;
                        this.txtFirmaImagenRuta.Text = String.Empty;
                    }
                }
            }
        }
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 29/08/2017 05:48:09 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Data;
using System.Xml;
using System.Diagnostics;
//using System.Threading;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Windows.Media.Animation;
//using Datos.Modelos;
//using Reportes.DataSet;
//using Reportes.Vista;
//using Cartera.Utilidades;
using Sistema.Clases;
using Sistema.Vista;
using Sistema.Modelo;
using Reportes.Utilidades;
using Cartera.VistaModelo;
using Sistema.Utilidades;
using Datos.Modelos;
using Sistema.Dian;
using static Sistema.Dian.Global;
using static Sistema.Dian.Utilidades;


namespace Cartera.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carmaesfactuma
    /// </summary>
    public partial class VistaCarGenFactDian : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio 
        #region Variables de gestion
        public bool llgModoAdicion       = false;
        public bool llgModoEdicion       = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public bool glgVistPropiedades   = false;
        public bool llgObjetosCargados   = false;
        public bool llgActualizandoVista = false;
        public string gcrTextoCodigoQr   = string.Empty; // Para el texto del codigo QR
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

        // Variables para referenciar ultimo cambio ralizado en vistas
        public string lcrRefVistaDocumento   = "NA";
        public string lcrRefVistaResolucion  = "NA";
        public string lcrRefVistaAdquirente  = "NA";
        public string lcrRefVistaNotaCredito = "NA";
        public string lcrRefVistaNotaDebito  = "NA";

        // Otras variables
        public string gcrCtrF2TexBox;
        VistaModeloCarGenFactDian vm = null;
        DialogVistaErrores lobDlgLogs = null;
        #endregion Variables de gestion>

        // Inicio formulario
        #region Inicio formulario
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaCarGenFactDian()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloCarGenFactDian;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Car_fecfac_camf.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Fcm_fecven_mfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            //dpkG1Car_fecfac_camfx.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            FcvTimerGeneral();
            vm.lobOwner = this;
        }
        #endregion Inicio formulario>
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
        #region FcvTimerGeneral: Control Tiempo para cosas varias
        public void FcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out FcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void FcvTimerProcesos(object sender, EventArgs e)
        {
            if (this.IsLoaded && llgObjetosCargados == true && llgActualizandoVista == false)
            {
                llgActualizandoVista = true;
                FcvTimerActivarProcesos();
                llgActualizandoVista = false;
            }
        }
        #endregion
        #region FcvTimerActivarProcesos: Activa vistas u oculta segun proceso de gestion
        /// <summary>
        /// <para>Activa vistas u oculta segun proceso de gestion</para>
        /// </summary>
        void FcvTimerActivarProcesos()
        {
            FcvGestionVistaDocumento();
            FcvGestionVistaResolucion();
            FcvGestionVistaAdquirente();
            FcvGestionVistaNotaCredito();
            FcvGestionVistaNotaDebito();
        }
        #endregion
        //lobRegFeFactura.Fcm_notdoc_mfac = "NEW"
        #region FcvGestionVistaDocumento: ctualizar vista datos Documento desde Facturas Dian
        /// <summary>
        /// <para>Actualizar vista datos Documento desde Facturas Dian</para>
        /// </summary>
        void FcvGestionVistaDocumento()
        {
            if (vm.lobRegFeFactura == null)
            {
                if (lcrRefVistaDocumento != "NULL")
                {
                    lcrRefVistaDocumento = "NULL";
                    FcvCargarDatosDocumentoActivo(null);
                }
            }
            else
            {
                // si ya se cargo, no cargar de nuevo
                if (vm.lobRegFeFactura.Fcm_numfac_mfac != lcrRefVistaDocumento || vm.lobRegFeFactura.Fcm_notdoc_mfac == "NEW")
                {
                    vm.lobRegFeFactura.Fcm_notdoc_mfac = "OK"; // Para que no se vuelva a cargar
                    lcrRefVistaDocumento = vm.lobRegFeFactura.Fcm_numfac_mfac;
                    FcvCargarDatosDocumentoActivo(vm.lobRegFeFactura);
                }
            }
        }
        #endregion FcvGestionVistaAdquirente>
        #region FcvGestionVistaResolucion: Actualizar vista datos Resolucion Dian
        /// <summary>
        /// <para>Actualizar vista datos Resolucion Dian</para>
        /// </summary>
        void FcvGestionVistaResolucion()
        {
            if (vm.lobRegResolDian == null)
            {
                if (lcrRefVistaResolucion != "NULL")
                {
                    lcrRefVistaResolucion = "NULL";
                    FcvCargarDatosResolucionDian(null);
                }
            }
            else
            {
                // si ya se cargo, no cargar de nuevo
                if (vm.lobRegResolDian.fcm_secres_srfa != lcrRefVistaResolucion)
                {
                    lcrRefVistaResolucion = vm.lobRegResolDian.fcm_secres_srfa;
                    FcvCargarDatosResolucionDian(vm.lobRegResolDian);
                }
            }
        }
        #endregion FcvGestionVistaAdquirente>
        #region FcvGestionVistaAdquirente: Actualizar vista datos Adquirente
        /// <summary>
        /// <para>Actualizar vista datos Adquirente</para>
        /// </summary>
        void FcvGestionVistaAdquirente()
        {
            if (vm.lobRegAdquirente == null)
            {
                if (lcrRefVistaAdquirente != "NULL")
                {
                    lcrRefVistaAdquirente = "NULL";
                    FcvCargarDatosAdquirente(null);
                }
            }
            else
            {
                // si ya se cargo, no cargar de nuevo
                if (vm.lobRegAdquirente.Sis_idterc_sitr != lcrRefVistaAdquirente)
                {
                    lcrRefVistaAdquirente = vm.lobRegAdquirente.Sis_idterc_sitr;
                    FcvCargarDatosAdquirente(vm.lobRegAdquirente);
                }
            }
        }
        #endregion FcvGestionVistaAdquirente>
        #region FcvGestionVistaNotaCredito: Activa vistas u oculta Nota Credito
        /// <summary>
        /// <para>Activa vistas u oculta Nota Credito</para>
        /// </summary>
        void FcvGestionVistaNotaCredito()
        {
            #region Gestion vista Nota Credito
            if (txtG1Fcm_typdoc_fctd.Text == "01" || txtG1Fcm_typdoc_fctd.Text == "91")
            {
                // Mostrar la vista cuando no lo este
                if (expReferenciaNotaCredito.Visibility != Visibility.Visible)
                {
                    expReferenciaNotaCredito.Visibility = Visibility.Visible;
                }

                if (vm.lobRefNotaCredito == null)
                {
                    if (lcrRefVistaNotaCredito != "NULL")
                    {
                        lcrRefVistaNotaCredito = "NULL";
                        FcvCargarReferenciaNotaCredito(null);
                    }
                }
                else
                {
                    // si ya se cargo, no cargar de nuevo
                    if (vm.lobRefNotaCredito["fcm_numfac_mfac"].ToString().Trim() != lcrRefVistaNotaCredito)
                    {
                        lcrRefVistaNotaCredito = vm.lobRefNotaCredito["fcm_numfac_mfac"].ToString().Trim();
                        FcvCargarReferenciaNotaCredito(vm.lobRefNotaCredito);
                    }
                }
            }
            else
            {
                // ocultar vista
                if (expReferenciaNotaCredito.Visibility == Visibility.Visible)
                {
                    expReferenciaNotaCredito.Visibility = Visibility.Collapsed;
                }

                if (lcrRefVistaNotaCredito != "NULL")
                {
                    lcrRefVistaNotaCredito = "NULL";
                    FcvCargarReferenciaNotaCredito(null);
                }
            }
            #endregion Gestion vista Nota Credito>
        }
        #endregion FcvGestionVistaNotaCredito>
        #region FcvGestionVistaNotaDebito: Activa vistas u oculta Nota Debito
        /// <summary>
        /// <para>Activa vistas u oculta Nota Debito</para>
        /// </summary>
        void FcvGestionVistaNotaDebito()
        {
            #region Gestion vista Nota Debito
            if (txtG1Fcm_typdoc_fctd.Text == "01" || txtG1Fcm_typdoc_fctd.Text == "92")
            {
                // Mostrar la vista cuando no lo este
                if (expReferenciaNotaDebito.Visibility != Visibility.Visible)
                {
                    expReferenciaNotaDebito.Visibility = Visibility.Visible;
                }

                if (vm.lobRefNotaDebito == null)
                {
                    if (lcrRefVistaNotaDebito != "NULL")
                    {
                        lcrRefVistaNotaDebito = "NULL";
                        FcvCargarReferenciaNotaDebito(null);
                    }
                }
                else
                {
                    // si ya se cargo, no cargar de nuevo
                    if (vm.lobRefNotaDebito["fcm_numfac_mfac"].ToString().Trim() != lcrRefVistaNotaDebito)
                    {
                        lcrRefVistaNotaDebito = vm.lobRefNotaDebito["fcm_numfac_mfac"].ToString().Trim();
                        FcvCargarReferenciaNotaDebito(vm.lobRefNotaDebito);
                    }
                }
            }
            else
            {
                // ocultar vista
                if (expReferenciaNotaDebito.Visibility == Visibility.Visible)
                {
                    expReferenciaNotaDebito.Visibility = Visibility.Collapsed;
                }

                if (lcrRefVistaNotaDebito != "NULL")
                {
                    lcrRefVistaNotaDebito = "NULL";
                    FcvCargarReferenciaNotaDebito(null);
                }
            }
            #endregion Gestion vista Nota Debito>
        }
        #endregion FcvGestionVistaNotaDebito>
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

            this.grdPropSelect.Height = lduHeight;

            //var myGridLengthConverter = new GridLengthConverter();
            //this.grdCol1.Width = (System.Windows.GridLength)myGridLengthConverter.ConvertFromString("200");
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            try
            {
                switch (lobOpcion.Name)
                {
                    case "opPRN_FACTURA": // Vista previa para factura Dian

                        var lobPrnTraslado = new CARImprimirFactura
                        {
                            gcrRazonSocialTipoId = "ID",
                            gcrRazonSocialCodigo = vm.G1Fcm_secraz_fcem,
                            gcrCodigoRegistro    = this.txtG1Car_secfac_camf.Text,
                            gcrTextoCodigoQr     = gcrTextoCodigoQr,
                            gcrTipoRegistro      = "GENERAL"
                        };
                        lobPrnTraslado.FcvEjecutar();

                        break;

                    case "opPRN_CUENTA03": // Vista  previa Relacion usuarios y servicios en facturas

                        if (vm.G1Car_tipfac_camf == "1")
                        {
                            var lobPrnCuenta03 = new FCMImprimir
                            {
                                gcrCodigoRegistro = this.txtG1Fcm_secreg_mfcb.Text,
                                gcrNumFacResolucion = this.txtG1Car_nrofac_camf.Text,
                                gcrTipoRegistro = "CUENTA03"
                            };
                            lobPrnCuenta03.fcvEjecutar();
                        }
                        else
                        {
                            MessageBox.Show("No hay listado relación facturas de usuarios");
                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista fcvImprimir()");
            }

        }
        #endregion
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Cto_seccon_cont);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Car_codcon_cacf);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Car_observ_camf);
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
            FocusManager.SetFocusedElement(this, txtG2Car_codcon_cacf);
        }

        //-Clic en Boton Confirmar registro
        private void fcvConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CON");
        }

        //-Clic en Boton Anular registro
        private void fcvAnularRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ANU");
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
            FocusManager.SetFocusedElement(this, txtG2Car_codcon_cacf);
        }
        #endregion
        // Consultar Documentos en Dian
        #region Consulas documentos Dian
        #region FcvConsultaEstadoValidacion_Click: Estado validacion
        public void FcvConsultaEstadoValidacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea consultar estado validación del Documento?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando estado Validación en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                //XmlDocument lobRespuestaXml;

                if (!FlgConsultarGetStatusZip(txtG1ProFcm_trakid_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error Solicitud estado Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lobDlgAdd.Close();
                    FcvActualizarDatosYVista(lobRespuestaXml, "NA", "Estado validación documento en DIAN");
                }
            }
        }
        #endregion FcvConsultaEstadoValidacion_Click
        #region FcvConsultaResponseDian_Click: Respuesta validación (Response)
        public void FcvConsultaResponseDian_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Consultar respuesta radicación del Documento (Response)?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                //XmlDocument respuestaXml;

                if (!FlgConsultarGetStatusDocumento(txtG1ProFcm_idcufe_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    FcvActualizarDatosYVista(lobRespuestaXml, "b:XmlBase64Bytes", "XML Respuesta resultado validación (response) DIAN");

                }
            }
        }
        #endregion FcvConsultaResponseDian_Click>
        #region FcvConsultaXMLRadicadoDian_Click: Consultar XML del Documento Radicado en DIAN
        /// <summary>
        /// Consultar XML del Documento Radicado en DIAN
        /// </summary>
        public void FcvConsultaXMLRadicadoDian_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Consultar XML del Documento radicado en DIAN?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                Empresa.FcvCargarRazonSocial("ID", vm.TmpG1RegActivo.Fcm_secraz_fcem);
                //XmlDocument respuestaXml;

                if (!FlgConsultarGetXmlByDocumentKey(txtG1ProFcm_idcufe_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lobDlgAdd.Close();
                    FcvActualizarDatosYVista(lobRespuestaXml, "b:XmlBytesBase64", "XML del Documento Radicado en DIAN"); // b:XmlBytesBase64 - Ahi esta el documento en Base64
                }
            }
        }
        #endregion FcvConsultaXMLRadicadoDian_Click>
        #region FcvEnviarCorreoAdquirente_Click: Enviar correo al adquirente
        public void FcvEnviarCorreoAdquirente_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Enviar el documento al adquirente?", "Enviar Adjunto",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (vm.TmpG1RegActivo.Fcm_codest_fcws == "R01") // Cuando ya esta recibida
                {

                    var lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                    lobDlgAdd.Owner = this;
                    lobDlgAdd.Show();

                    // actualizar la vista datos registro documento activo
                    vm.TmpG1RegActivo.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", vm.G1Car_secfac_camf);
                    if (vm.TmpG1RegActivo.lobRegDocDian != null)
                    {
                        vm.TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista

                        if (FlgGenerarDocumentoAttached(vm.TmpG1RegActivo.lobRegDocDian,
                                                           out string tcrMensaje,
                                                           out DocumentoAttached tobRefAttacehd))
                        {
                            lobDlgAdd.Close();
                            //- Conceptos para facturas de venta
                            var lobCar003 = new VistaEnviarCorreos(vm.TmpG1RegActivo.lobRegDocDian, tobRefAttacehd);
                            lobCar003.Owner = this;
                            lobCar003.ShowDialog();
                        }
                        else
                        {
                            lobDlgAdd.Close();
                        }
                    }
                    else
                    {
                        lobDlgAdd.Close();
                    }
                }
            }
        }
        #endregion FcvEnviarCorreoAdquirente_Click
        #region FcvActualizarDatosYVista: Mostrar vista
        private void FcvActualizarDatosYVista(XmlDocument lobRespuestaXml, string tcrTagName, string tcrTituloVista)
        {
            if (vm.G1Fcm_codest_fcws != "R01") // Cuando ya esta recibda no se modifica
            {
                if (vm.FlgDianCuentaActualizarMaestros(lobRespuestaXml, out _, out _))
                {
                    // actualizar la vista datos registro documento activo
                    vm.lobRegFeFactura = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", vm.G1Car_secfac_camf);
                    if (vm.lobRegFeFactura != null)
                    {
                        vm.lobRegFeFactura.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista
                    }
                }
            }
            //Funciones.FcvVistaResponse(lobRespuestaXml.DocumentElement.OuterXml, "Resultados", this);

            string tcrStringRespuesta = lobRespuestaXml.DocumentElement.OuterXml;
            if (tcrTagName != "NA")
            {
                if (!FlgCargarFromBase64String(tcrTagName, lobRespuestaXml, out tcrStringRespuesta))
                {
                    tcrStringRespuesta = $"Error en la consulta No hay datos en el tag {tcrTagName}";
                }
            }
            // equivalente a usar sin decodificar el documento: lobRespuestaXml.DocumentElement.OuterXml
            Funciones.FcvVistaResponse(tcrStringRespuesta, tcrTituloVista, this);

        }
        #endregion FcvActualizarDatosYVista>
        #endregion Consulas documentos Dian
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
        //- Activar modo edicion en Vista
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
                    FocusManager.SetFocusedElement(this, txtG1Car_observ_camf);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG1Car_observ_camf);
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
        }
        #endregion
        //-Actualizar Modo Edicion del formulario
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
                    cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdCancelar.Visibility = Visibility.Hidden;
                }
                cmdConfirmar.Visibility = Visibility.Hidden;

                switch (tcrEstado)
                {
                    case "1":

                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
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
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    case "3":
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    default:
                        // se asume modo inicial vacio
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdGuardar.Visibility = Visibility.Visible;
                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
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
        #region Actualizar Estado edicion desde TextBox Estado
        void ActualizarEdtDesdeTextBoxEstado(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    ActualizarModoEdicion(lobTexto.Text);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarEdtDesdeTextBoxEstado");
            }
        }
        #endregion
        //- Configuracion modo Edicion Guardar o Confirmar
        #region Modo Guardar (por defecto) o  Confirmar
        public void fcvConfigModoGuardar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = true;
        }
        //- Configuracion modo Confirmar
        public void fcvConfigModoConfirmar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = false;
        }
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
            LocalizadorVistaModelo.fcvLiberarVistaModeloCarGenFactDian();
            gdspTimerSistema.Stop();
            // Quitar eventos asociados a los DatePicker
            #region Finalizar Manejador SelectedDateChanged en DatePiker
            dpkG1Car_fecfac_camf.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            //dpkG1Car_fecfac_camfx.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                case "txtG1Car_secfac_camf":
                    txtG1Car_secfac_camf.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idterc_sitr":
                    txtG1Sis_idterc_sitr.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_secres_srfa":
                    //txtG1Fcm_secres_srfa.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_numdoc_fcem":
                    txtG1Fcm_numdoc_fcem.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idrcre_mfac":
                    txtG1Fcm_idrcre_mfac.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idrdeb_mfac":
                    txtG1Fcm_idrdeb_mfac.Text = tcrCodigo;
                    break;

                case "txtG1Sis_numide_sitr":
                    txtG1Sis_numide_sitr.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_secreg_mfcb":
                    txtG1Fcm_secreg_mfcb.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG2Car_codcon_cacf":
                    txtG2Car_codcon_cacf.Text = tcrCodigo;
                    break;

                case "BROWSER":
                    gcrCtrF2TexBox = tcrCodigo;
                    break;
            }
           
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // CARMAESFACTUMA : Maestro facturas cobro facturacion
        #region KeyDown para campos con F2 Tabla: CARMAESFACTUMA
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
        // Terceros o ADquirentes
        #region SIS_IDTERC_SITR Tabla terceros o Adquirentes por Id unico
        private void txtG1Sis_idterc_sitr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_idterc_sitr_Browser();
            }
        }
        private void cmdG1Sis_idterc_sitr_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_idterc_sitr_Browser();
        }
        private void txtG1Sis_idterc_sitr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS", "", "Tabla terceros para gestion contable...");
            gcrCtrF2TexBox = "txtG1Sis_idterc_sitr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_NUMIDE_SITR Tabla terceros o Adquirentes Por Nit
        private void TxtG1Sis_numide_sitr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtG1Sis_numide_sitr_Browser();
            }
        }
        private void CmdG1Sis_numide_sitr_Click(object sender, RoutedEventArgs e)
        {
            TxtG1Sis_numide_sitr_Browser();
        }
        private void TxtG1Sis_numide_sitr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS-NIT", "", "Maestro Adquiretes...");
            gcrCtrF2TexBox = "txtG1Sis_numide_sitr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        // Otros
        #region FCM_SECRES_SRFA : Secuenciales resolución numero de facturas
        private void txtG1Fcm_secres_srfa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_secres_srfa_Browser();
            }
        }
        private void cmdG1Fcm_secres_srfa_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_secres_srfa_Browser();
        }
        private void txtG1Fcm_secres_srfa_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMSECRFACTURAS", "", "Secuenciales resolución numero de facturas...");
            gcrCtrF2TexBox = "txtG1Fcm_secres_srfa";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_SECREG_MFCB : Maestro de facturas - Cuentas de cobro facturación
        private void txtG1Fcm_secreg_mfcb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_secreg_mfcb_Browser();
            }
        }
        private void cmdG1Fcm_secreg_mfcb_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_secreg_mfcb_Browser();
        }
        private void txtG1Fcm_secreg_mfcb_Browser()
        {
          
            Browser01Ex frbro = new Browser01Ex("FCM", "FCMCUENTACOBRMS", "2", "Maestro de facturas - Cuentas de cobro facturación...");
            gcrCtrF2TexBox = "txtG1Fcm_secreg_mfcb";
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
        // Razon social 
        #region FCM_SECRAZ_FCEM : Maestro Razon social de la empresa
        private void TxtG1Fcm_numdoc_fcem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtG1Fcm_numdoc_fcem_Browser();
            }
        }
        private void CmdG1Fcm_numdoc_fcem_Click(object sender, RoutedEventArgs e)
        {
            TxtG1Fcm_numdoc_fcem_Browser();
        }
        private void TxtG1Fcm_numdoc_fcem_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESRAZSOCMA-NIT", "", "Maestro Razon social de la empresa...");
            gcrCtrF2TexBox = "txtG1Fcm_numdoc_fcem";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        // Referencias a facturas para Notas Creditos y Debito o Factura
        #region FCM_IDRCRE_MFAC : Maestro de facturas - Radicadas en Dian
        private void TxtG1Fcm_idrcre_mfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtReferenciasFacutraBrowser("91","txtG1Fcm_idrcre_mfac");
            }
        }
        private void CmdG1Fcm_idrcre_mfac_Click(object sender, RoutedEventArgs e)
        {
            TxtReferenciasFacutraBrowser("91","txtG1Fcm_idrcre_mfac");
        }

        //txtG1Fcm_idrdeb_mfac
        private void TxtG1Fcm_idrdeb_mfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtReferenciasFacutraBrowser("92","txtG1Fcm_idrdeb_mfac");
            }
        }
        private void CmdG1Fcm_idrdeb_mfac_Click(object sender, RoutedEventArgs e)
        {
            TxtReferenciasFacutraBrowser("92","txtG1Fcm_idrdeb_mfac");
        }
        private void TxtReferenciasFacutraBrowser(String tcrTipo, String tcrNombreCampo)
        {
            var lcrFiltro = "01"; // Documento tipo factura

            // Documento Factura
            if (txtG1Fcm_typdoc_fctd.Text.Trim() == "01")
            {
                lcrFiltro = tcrTipo;
            }
            // Documento Nota Credito
            if (txtG1Fcm_typdoc_fctd.Text.Trim() == "91")
            {
                lcrFiltro = tcrTipo == "91" ? "01" : "NA";
            }
            // Documento Nota Debito
            if (txtG1Fcm_typdoc_fctd.Text.Trim() == "92")
            {
                lcrFiltro = tcrTipo == "92" ? "01" : "NA";
            }

            // Segun tipo documento a generar se filtra la vista
            // "ND" = Para que devuelva Numero docuemento
            // "01" = Documento tipo Factura
            if (lcrFiltro != "NA")
            {
                lcrFiltro = $"fcmfemaesfactefma.fcm_typdoc_fctd ='{lcrFiltro}' AND fcmfemaesfactefma.fcm_secraz_fcem ='{txtG1Fcm_secraz_fcem.Text}'";

                var frbro = new Browser01Ex("FCM", "FCMFEMAESFACTEFMA-ND", lcrFiltro, "Facturas Radicadas en DIAN...");
                gcrCtrF2TexBox = tcrNombreCampo;
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        // CARMAESFACTUMD : Detalles conceptos y valores facturados
        #region KeyDown para campos con F2 Tabla: CARMAESFACTUMD
        #region CAR_SECFAC_CAMF : Maestro facturas cobro facturacion
        private void txtG2Car_secfac_camf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Car_secfac_camf_Browser();
            }
        }
        private void cmdG2Car_secfac_camf_Click(object sender, RoutedEventArgs e)
        {
            txtG2Car_secfac_camf_Browser();
        }
        private void txtG2Car_secfac_camf_Browser()
        {
            Browser01 frbro = new Browser01("CAR", "CARMAESFACTUMD", "", "Maestro facturas cobro facturacion...");
            gcrCtrF2TexBox = "txtG2Car_secfac_camf";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region CAR_CODCON_CACF : Conceptos para detalles facturas venta Dian
        private void txtG2Car_codcon_cacf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Car_codcon_cacf_Browser();
            }
        }
        private void cmdG2Car_codcon_cacf_Click(object sender, RoutedEventArgs e)
        {
            txtG2Car_codcon_cacf_Browser();
        }
        private void txtG2Car_codcon_cacf_Browser()
        {
            Browser01 frbro = new Browser01("CAR","CARCONCEPTFACT", "", "Conceptos para detalles facturas venta...");
            gcrCtrF2TexBox = "txtG2Car_codcon_cacf";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = gcrCtrF2TexBox != "BROWSER" ? gcrCtrF2TexBox : string.Empty;
            var lcrTitulo = "Todos los Documentos abiertos...";

            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos": // todos los documentos abiertos
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='1'";
                    break;

                case "op01Abierto": // Facturas
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='1' AND carmaesfactuma.fcm_typdoc_fctd ='01'";
                    lcrTitulo = "Facturas abiertas...";
                    break;

                case "op01Cerrado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='2' AND carmaesfactuma.fcm_typdoc_fctd ='01'";
                    lcrTitulo = "Facturas Confirmadas...";
                    break;

                case "op01Anulado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='3' AND carmaesfactuma.fcm_typdoc_fctd ='01'";
                    lcrTitulo = "Facturas Anuladas...";
                    break;

                case "op91Abierto": // Notas Credito
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='1' AND carmaesfactuma.fcm_typdoc_fctd ='91'";
                    lcrTitulo = "Notas Crédito Abiertas...";
                    break;

                case "op91Cerrado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='2' AND carmaesfactuma.fcm_typdoc_fctd ='91'";
                    lcrTitulo = "Notas Crédito Confirmadas...";
                    break;

                case "op91Anulado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='3' AND carmaesfactuma.fcm_typdoc_fctd ='91'";
                    lcrTitulo = "Notas Crédito Anuladas...";
                    break;
                case "op92Abierto": // Notas Debito
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='1' AND carmaesfactuma.fcm_typdoc_fctd ='92'";
                    lcrTitulo = "Notas Debito Abiertas...";
                    break;

                case "op92Cerrado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='2' AND carmaesfactuma.fcm_typdoc_fctd ='92'";
                    lcrTitulo = "Notas Debito Confirmadas...";
                    break;

                case "op92Anulado":
                    lcrFiltro = "carmaesfactuma.sis_estpro_espr='3' AND carmaesfactuma.fcm_typdoc_fctd ='92'";
                    lcrTitulo = "Notas Debito Anuladas...";
                    break;
            }
            Browser01Ex frbro = new Browser01Ex("CAR", "CARMAESFACTUMA", lcrFiltro, lcrTitulo);
            gcrCtrF2TexBox = "txtG1Car_secfac_camf";
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
                        case "cboG1Fcm_typdoc_fctd":
                            txtG1Fcm_typdoc_fctd.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_typdoc_fctd.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_typdoc_fctd.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_prnobs_camf":
                            txtG1Car_prnobs_camf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_prnobs_camf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_prnobs_camf.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_prnnot_camf":
                            txtG1Car_prnnot_camf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_prnnot_camf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_prnnot_camf.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Fcm_metpag_mfac":
                            txtG1Fcm_metpag_mfac.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_metpag_mfac.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_metpag_mfac.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Car_tipfac_camf":
                            txtG1Car_tipfac_camf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Car_tipfac_camf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_tipfac_camf.Text, ",", lobList.ListaValoresSel);
                            break;

                            /*
                            case "cboG1Car_prnobs_camf":
                                txtG1Car_prnobs_camf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                        txtG1Car_prnobs_camf.Text, ",",
                                                                                        lobList.ListaValoresSel);
                                lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_prnobs_camf.Text, ",", lobList.ListaValoresSel);
                                break;
                            case "cboG1Car_tipfac_camf":
                                txtG1Car_tipfac_camf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                        txtG1Car_tipfac_camf.Text, ",",
                                                                                        lobList.ListaValoresSel);
                                lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Car_tipfac_camf.Text, ",", lobList.ListaValoresSel);
                                break;
                            */
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
                        /*
                        case "txtG1Car_prnobs_camf":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Car_prnobs_camf.SelectedItem;
                            cboG1Car_prnobs_camf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Car_tipfac_camf":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Car_tipfac_camf.SelectedItem;
                            cboG1Car_tipfac_camf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        */
                        case "txtG1Fcm_typdoc_fctd":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Fcm_typdoc_fctd.SelectedItem;
                            cboG1Fcm_typdoc_fctd.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Car_prnobs_camf":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Car_prnobs_camf.SelectedItem;
                            cboG1Car_prnobs_camf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Car_prnnot_camf":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Car_prnnot_camf.SelectedItem;
                            cboG1Car_prnnot_camf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Fcm_metpag_mfac":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Fcm_metpag_mfac.SelectedItem;
                            cboG1Fcm_metpag_mfac.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Car_tipfac_camf":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Car_tipfac_camf.SelectedItem;
                            cboG1Car_tipfac_camf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
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
                    case "dpkG1Car_fecfac_camf":
                        txtG1Car_fecfac_camf.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Car_fecfac_camf);
                        break;
                    /*
                    case "dpkG1Car_fecfac_camfx":
                        txtG1Car_fecfac_camfx.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Car_fecfac_camfx);
                        break;
                    */    

                    case "dpkG1Fcm_fecven_mfac":
                        txtG1Fcm_fecven_mfac.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Fcm_fecven_mfac);
                        break;

                    case "dpkG1Fcm_fecfac_mfac":
                        //txtG1Fcm_fecfac_mfac.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        //FocusManager.SetFocusedElement(this, txtG1Fcm_fecfac_mfac);
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
                            case "txtG1Car_fecfac_camf":
                                dpkG1Car_fecfac_camf.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                                /*
                            case "txtG1Car_fecfac_camfx":
                                dpkG1Car_fecfac_camfx.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                                */
                            case "txtG1Fcm_fecven_mfac":
                                dpkG1Fcm_fecven_mfac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Fcm_fecfac_mfac":
                                //dpkG1Fcm_fecfac_mfac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        private void FcvCapturaHora(object sender, TextChangedEventArgs e)
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
        //-------------------------------------------------
        // Vista Capa Propiedades 
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistPropiedades == false)
            {
                luxAnimacion.To = -480; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistPropiedades = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion

        //-------------------------------------------------
        // Cargar datos de las vistas en capa derecha
        //-------------------------------------------------
        #region Ventana Propiedades Vista de datos 
        #region FcvCargarDatosDocumentoActivo: Mostrar u limpiar datos Documento activo Dian
        /// <summary>
        /// Mostrar u limpiar datos Documento activo Dian
        /// </summary>
        /// <param name="tobReg">Registro</param>
        private void FcvCargarDatosDocumentoActivo(ModeloFeFacturaMa tobReg)
        {
            if (tobReg != null)
            {
                txtG1ProFcm_idcufe_mfac.Text = tobReg.Fcm_idcufe_mfac;
                txtG1ProFcm_diafec_mfac.Text = Funciones.fcrConvertFecha(tobReg.Fcm_diafec_mfac);
                txtG1ProFcm_diahor_mfac.Text = Funciones.fcrConvierteHora(tobReg.Fcm_diahor_mfac.ToString(), "24", gcrSeparadorDecimal, ":");
                txtG1ProFcm_codest_fcws.Text = tobReg.Fcm_codest_fcws;
                txtG1ProFcm_desest_fcws.Text = tobReg.Fcm_desest_fcws;
                txtG1ProFcm_trakid_mfac.Text = tobReg.Fcm_trakid_mfac;
                txtG1ProFcm_nomarc_mfac.Text = tobReg.Fcm_nomarc_mfac;
                txtG1ProFcm_errore_mfac.Text = tobReg.Fcm_errore_mfac;

                FcrGenerarCodigoQR(tobReg, tobReg.Fcm_idcufe_mfac, out gcrTextoCodigoQr);
                imgImagenQR.Source = Funciones.FobCodigoQrBitmapSource(gcrTextoCodigoQr, 250);
                // https://stackoverrun.com/es/q/83987 ejemplo de convertir a array
            }
            else
            {
                txtG1ProFcm_idcufe_mfac.Text = string.Empty;
                txtG1ProFcm_diafec_mfac.Text = "  /  /  ";
                txtG1ProFcm_diahor_mfac.Text = " : ";
                txtG1ProFcm_codest_fcws.Text = string.Empty;
                txtG1ProFcm_desest_fcws.Text = string.Empty;
                txtG1ProFcm_trakid_mfac.Text = string.Empty;
                txtG1ProFcm_nomarc_mfac.Text = string.Empty;
                txtG1ProFcm_errore_mfac.Text = string.Empty;
                imgImagenQR.Source           = null;
                gcrTextoCodigoQr             = string.Empty;
            }
        }
        #endregion FcvCargarDatosResolucionDian>
        #region FcvCargarDatosResolucionDian: Mostrar u limpiar datos Resolución Dian
        /// <summary>
        /// Cargar o limpiar la vista datos Resolucion Dian en la 
        /// capa derecha
        /// </summary>
        /// <param name="tobReg"></param>
        private void FcvCargarDatosResolucionDian(EFfcmsecrfacturas tobReg)
        {
            if (tobReg != null)
            {
                txtG1ResFcm_secres_srfa.Text = tobReg.fcm_secres_srfa;
                txtG1ResFcm_numres_srfa.Text = tobReg.fcm_numres_srfa;
                txtG1ResFcm_desres_srfa.Text = tobReg.fcm_desres_srfa;
                txtG1ResFcm_notenc_srfa.Text = tobReg.fcm_notenc_srfa;
                txtG1ResFcm_noppag_srfa.Text = tobReg.fcm_noppag_srfa;
                txtG1ResFcm_fecini_srfa.Text = Funciones.fcrConvertFecha((DateTime)tobReg.fcm_fecini_srfa);
                txtG1ResFcm_fecfin_srfa.Text = Funciones.fcrConvertFecha((DateTime)tobReg.fcm_fecfin_srfa);
                txtG1ResFcm_facini_srfa.Text = ((int)tobReg.fcm_facini_srfa).ToString();
                txtG1ResFcm_facfin_srfa.Text = ((int)tobReg.fcm_facfin_srfa).ToString();
                txtG1ResFcm_ultgen_srfa.Text = ((int)tobReg.fcm_ultgen_srfa).ToString();
                txtG1ResFcm_prefij_srfa.Text = tobReg.fcm_prefij_srfa;
            }
            else
            {
                txtG1ResFcm_secres_srfa.Text = String.Empty;
                txtG1ResFcm_numres_srfa.Text = String.Empty;
                txtG1ResFcm_desres_srfa.Text = String.Empty;
                txtG1ResFcm_notenc_srfa.Text = String.Empty;
                txtG1ResFcm_noppag_srfa.Text = String.Empty;
                txtG1ResFcm_fecini_srfa.Text = "  /  /  ";
                txtG1ResFcm_fecfin_srfa.Text = "  /  /  ";
                txtG1ResFcm_facini_srfa.Text = String.Empty;
                txtG1ResFcm_facfin_srfa.Text = String.Empty;
                txtG1ResFcm_ultgen_srfa.Text = String.Empty;
                txtG1ResFcm_prefij_srfa.Text = String.Empty;
            }
        }
        #endregion FcvCargarDatosResolucionDian>
        #region FcvCargarDatosAdquirente: Cargar datos del adquirente
        /// <summary>
        /// Cargar datos del adquirente
        /// </summary>
        /// <param name="tobReg"></param>
        private void FcvCargarDatosAdquirente(ModeloSismaesterceros tobReg)
        {
            if (tobReg != null)
            {
                #region Cargar datos>
                txtG1AdqSis_idterc_sitr.Text = tobReg.Sis_idterc_sitr;
                txtG1AdqSis_tipper_sitr.Text = tobReg.Sis_tipper_sitr;
                txtG1AdqSis_tipide_tido.Text = tobReg.Sis_tipide_tido;
                txtG1AdqSis_numide_sitr.Text = tobReg.Sis_numide_sitr;
                txtG1AdqSis_razsoc_sitr.Text = tobReg.Sis_razsoc_sitr;
                txtG1AdqSis_nomcon_sitr.Text = tobReg.Sis_nomcon_sitr;
                txtG1AdqSis_telefo_sitr.Text = tobReg.Sis_telefo_sitr;
                txtG1AdqSis_emailc_sitr.Text = tobReg.Sis_emailc_sitr;
                txtG1AdqSis_direcc_sitr.Text = tobReg.Sis_direcc_sitr;
                txtG1AdqSis_idemun_muni.Text = tobReg.Sis_idemun_muni;
                txtG1AdqSis_nommun_muni.Text = tobReg.Sis_nommun_muni;
                txtG1AdqSis_coddep_dpto.Text = tobReg.Sis_coddep_dpto;
                txtG1AdqSis_desdep_dpto.Text = tobReg.Sis_desdep_dpto;
                txtG1AdqSis_codpos_sicp.Text = tobReg.Sis_codpos_sicp;
                txtG1AdqSis_codact_sitr.Text = tobReg.Sis_codact_sitr;
                txtG1AdqSis_codobl_sioc.Text = tobReg.Sis_codobl_sioc;
                txtG1AdqSis_estreg_esrg.Text = tobReg.Sis_estreg_esrg;
                #endregion Cargar datos>
            }
            else
            {
                #region Cargar datos>
                txtG1AdqSis_idterc_sitr.Text = String.Empty;
                txtG1AdqSis_tipper_sitr.Text = String.Empty;
                txtG1AdqSis_tipide_tido.Text = String.Empty;
                txtG1AdqSis_numide_sitr.Text = String.Empty;
                txtG1AdqSis_razsoc_sitr.Text = String.Empty;
                txtG1AdqSis_nomcon_sitr.Text = String.Empty;
                txtG1AdqSis_telefo_sitr.Text = String.Empty;
                txtG1AdqSis_emailc_sitr.Text = String.Empty;
                txtG1AdqSis_direcc_sitr.Text = String.Empty;
                txtG1AdqSis_idemun_muni.Text = String.Empty;
                txtG1AdqSis_nommun_muni.Text = String.Empty;
                txtG1AdqSis_coddep_dpto.Text = String.Empty;
                txtG1AdqSis_desdep_dpto.Text = String.Empty;
                txtG1AdqSis_codpos_sicp.Text = String.Empty;
                txtG1AdqSis_codact_sitr.Text = String.Empty;
                txtG1AdqSis_codobl_sioc.Text = String.Empty;
                txtG1AdqSis_estreg_esrg.Text = String.Empty;
                #endregion Cargar datos>
            }
        }
        #endregion FcvCargarReferenciaNotaDebito>
        #region FcvCargarReferenciaNotaCredito: Mostrar u limpiar datos Referencia Nota Credito
        /// <summary>
        /// Mostrar u limpiar datos Referencia Nota Credito
        /// </summary>
        /// <param name="tobReg"></param>
        private void FcvCargarReferenciaNotaCredito(DataRow tobReg)
        {
            if (tobReg != null)
            {
                var lcrFcm_fecfac_mfac = tobReg["fcm_fecfac_mfac"] != null ? tobReg["fcm_fecfac_mfac"].ToString() : String.Empty;
                if (!string.IsNullOrWhiteSpace(lcrFcm_fecfac_mfac))
                {
                    //lcrFcm_fecfac_mfac = Funciones.fcrConvertFecha(DateTime.Parse(lcrFcm_fecfac_mfac));
                    lcrFcm_fecfac_mfac = lcrFcm_fecfac_mfac.Length > 10 ? lcrFcm_fecfac_mfac.Substring(0, 10) : lcrFcm_fecfac_mfac;
                }

                var lcrfcm_diafec_mfac = tobReg["fcm_diafec_mfac"] != null ? tobReg["fcm_diafec_mfac"].ToString() : String.Empty;
                if (!string.IsNullOrWhiteSpace(lcrfcm_diafec_mfac))
                {
                    lcrfcm_diafec_mfac = lcrfcm_diafec_mfac.Length > 10 ? lcrfcm_diafec_mfac.Substring(0, 10) : lcrfcm_diafec_mfac;
                }

                #region Cargar datos
                txtG1RcrFcm_numfac_mfac.Text = tobReg["fcm_numfac_mfac"] != null ? tobReg["fcm_numfac_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_typdoc_fctd.Text = tobReg["fcm_typdoc_fctd"] != null ? tobReg["fcm_typdoc_fctd"].ToString() : String.Empty;
                txtG1RcrFcm_destyp_fctd.Text = tobReg["fcm_destyp_fctd"] != null ? tobReg["fcm_destyp_fctd"].ToString() : String.Empty;
                txtG1RcrFcm_fecfac_mfac.Text = lcrFcm_fecfac_mfac;
                txtG1RcrFcm_horfac_mfac.Text = tobReg["fcm_horfac_mfac"] != null ? tobReg["fcm_horfac_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_notdoc_mfac.Text = tobReg["fcm_notdoc_mfac"] != null ? tobReg["fcm_notdoc_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_facori_mfac.Text = tobReg["fcm_facori_mfac"] != null ? tobReg["fcm_facori_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_idcufe_mfac.Text = tobReg["fcm_idcufe_mfac"] != null ? tobReg["fcm_idcufe_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_diafec_mfac.Text = lcrfcm_diafec_mfac;
                txtG1RcrFcm_diahor_mfac.Text = tobReg["fcm_diahor_mfac"] != null ? tobReg["fcm_diahor_mfac"].ToString() : String.Empty;
                txtG1RcrFcm_codest_fcws.Text = tobReg["fcm_codest_fcws"] != null ? tobReg["fcm_codest_fcws"].ToString() : String.Empty;
                txtG1RcrFcm_desest_fcws.Text = tobReg["fcm_desest_fcws"] != null ? tobReg["fcm_desest_fcws"].ToString() : String.Empty;
                txtG1RcrSis_tipper_sitr.Text = tobReg["sis_tipper_sitr"] != null ? tobReg["sis_tipper_sitr"].ToString() : String.Empty;
                txtG1RcrSis_numide_sitr.Text = tobReg["sis_numide_sitr"] != null ? tobReg["sis_numide_sitr"].ToString() : String.Empty;
                txtG1RcrSis_razsoc_sitr.Text = tobReg["sis_razsoc_sitr"] != null ? tobReg["sis_razsoc_sitr"].ToString() : String.Empty;
                txtG1RcrSis_nomcon_sitr.Text = tobReg["sis_nomcon_sitr"] != null ? tobReg["sis_nomcon_sitr"].ToString() : String.Empty;
                txtG1RcrSis_telefo_sitr.Text = tobReg["sis_telefo_sitr"] != null ? tobReg["sis_telefo_sitr"].ToString() : String.Empty;
                txtG1RcrSis_emailc_sitr.Text = tobReg["sis_emailc_sitr"] != null ? tobReg["sis_emailc_sitr"].ToString() : String.Empty;
                txtG1RcrSis_direcc_sitr.Text = tobReg["sis_direcc_sitr"] != null ? tobReg["sis_direcc_sitr"].ToString() : String.Empty;
                txtG1RcrSis_codmun_muni.Text = tobReg["sis_codmun_muni"] != null ? tobReg["sis_codmun_muni"].ToString() : String.Empty;
                txtG1RcrSis_nommun_muni.Text = tobReg["sis_nommun_muni"] != null ? tobReg["sis_nommun_muni"].ToString() : String.Empty;
                txtG1RcrSis_coddep_dpto.Text = tobReg["sis_coddep_dpto"] != null ? tobReg["sis_coddep_dpto"].ToString() : String.Empty;
                txtG1RcrSis_desdep_dpto.Text = tobReg["sis_desdep_dpto"] != null ? tobReg["sis_desdep_dpto"].ToString() : String.Empty;
                txtG1RcrSis_codpos_sicp.Text = tobReg["sis_codpos_sicp"] != null ? tobReg["sis_codpos_sicp"].ToString() : String.Empty;
                #endregion Cargar datos>
            }
            else
            {
                #region Cargar datos
                txtG1RcrFcm_numfac_mfac.Text = String.Empty;
                txtG1RcrFcm_typdoc_fctd.Text = String.Empty;
                txtG1RcrFcm_destyp_fctd.Text = String.Empty;
                txtG1RcrFcm_fecfac_mfac.Text = String.Empty;
                txtG1RcrFcm_horfac_mfac.Text = String.Empty;
                txtG1RcrFcm_notdoc_mfac.Text = String.Empty;
                txtG1RcrFcm_facori_mfac.Text = String.Empty;
                txtG1RcrFcm_idcufe_mfac.Text = String.Empty;
                txtG1RcrFcm_diafec_mfac.Text = String.Empty;
                txtG1RcrFcm_diahor_mfac.Text = String.Empty;
                txtG1RcrFcm_codest_fcws.Text = String.Empty;
                txtG1RcrFcm_desest_fcws.Text = String.Empty;
                txtG1RcrSis_tipper_sitr.Text = String.Empty;
                txtG1RcrSis_numide_sitr.Text = String.Empty;
                txtG1RcrSis_razsoc_sitr.Text = String.Empty;
                txtG1RcrSis_nomcon_sitr.Text = String.Empty;
                txtG1RcrSis_telefo_sitr.Text = String.Empty;
                txtG1RcrSis_emailc_sitr.Text = String.Empty;
                txtG1RcrSis_direcc_sitr.Text = String.Empty;
                txtG1RcrSis_codmun_muni.Text = String.Empty;
                txtG1RcrSis_nommun_muni.Text = String.Empty;
                txtG1RcrSis_coddep_dpto.Text = String.Empty;
                txtG1RcrSis_desdep_dpto.Text = String.Empty;
                txtG1RcrSis_codpos_sicp.Text = String.Empty;
                #endregion Cargar datos>
            }
        }
        #endregion FcvCargarReferenciaNotaCredito>
        #region FcvCargarReferenciaNotaDebito: Mostrar u limpiar datos Referencia Nota Debito
        /// <summary>
        /// Mostrar u limpiar datos Referencia Nota Debito
        /// </summary>
        /// <param name="tobReg"></param>
        private void FcvCargarReferenciaNotaDebito(DataRow tobReg)
        {
            if (tobReg != null)
            {
                var lcrFcm_fecfac_mfac = tobReg["fcm_fecfac_mfac"] != null ? tobReg["fcm_fecfac_mfac"].ToString() : String.Empty;
                if (!string.IsNullOrWhiteSpace(lcrFcm_fecfac_mfac))
                {
                    //lcrFcm_fecfac_mfac = Funciones.fcrConvertFecha(DateTime.Parse(lcrFcm_fecfac_mfac));
                    lcrFcm_fecfac_mfac = lcrFcm_fecfac_mfac.Length > 10 ? lcrFcm_fecfac_mfac.Substring(0, 10) : lcrFcm_fecfac_mfac;
                }

                var lcrfcm_diafec_mfac = tobReg["fcm_diafec_mfac"] != null ? tobReg["fcm_diafec_mfac"].ToString() : String.Empty;
                if (!string.IsNullOrWhiteSpace(lcrfcm_diafec_mfac))
                {
                    lcrfcm_diafec_mfac = lcrfcm_diafec_mfac.Length > 10 ? lcrfcm_diafec_mfac.Substring(0, 10) : lcrfcm_diafec_mfac;
                }

                #region Cargar datos
                txtG1RdvFcm_numfac_mfac.Text = tobReg["fcm_numfac_mfac"] != null ? tobReg["fcm_numfac_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_typdoc_fctd.Text = tobReg["fcm_typdoc_fctd"] != null ? tobReg["fcm_typdoc_fctd"].ToString() : String.Empty;
                txtG1RdvFcm_destyp_fctd.Text = tobReg["fcm_destyp_fctd"] != null ? tobReg["fcm_destyp_fctd"].ToString() : String.Empty;
                txtG1RdvFcm_fecfac_mfac.Text = lcrFcm_fecfac_mfac;
                txtG1RdvFcm_horfac_mfac.Text = tobReg["fcm_horfac_mfac"] != null ? tobReg["fcm_horfac_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_notdoc_mfac.Text = tobReg["fcm_notdoc_mfac"] != null ? tobReg["fcm_notdoc_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_facori_mfac.Text = tobReg["fcm_facori_mfac"] != null ? tobReg["fcm_facori_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_idcufe_mfac.Text = tobReg["fcm_idcufe_mfac"] != null ? tobReg["fcm_idcufe_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_diafec_mfac.Text = lcrfcm_diafec_mfac;
                txtG1RdvFcm_diahor_mfac.Text = tobReg["fcm_diahor_mfac"] != null ? tobReg["fcm_diahor_mfac"].ToString() : String.Empty;
                txtG1RdvFcm_codest_fcws.Text = tobReg["fcm_codest_fcws"] != null ? tobReg["fcm_codest_fcws"].ToString() : String.Empty;
                txtG1RdvFcm_desest_fcws.Text = tobReg["fcm_desest_fcws"] != null ? tobReg["fcm_desest_fcws"].ToString() : String.Empty;
                txtG1RdvSis_tipper_sitr.Text = tobReg["sis_tipper_sitr"] != null ? tobReg["sis_tipper_sitr"].ToString() : String.Empty;
                txtG1RdvSis_numide_sitr.Text = tobReg["sis_numide_sitr"] != null ? tobReg["sis_numide_sitr"].ToString() : String.Empty;
                txtG1RdvSis_razsoc_sitr.Text = tobReg["sis_razsoc_sitr"] != null ? tobReg["sis_razsoc_sitr"].ToString() : String.Empty;
                txtG1RdvSis_nomcon_sitr.Text = tobReg["sis_nomcon_sitr"] != null ? tobReg["sis_nomcon_sitr"].ToString() : String.Empty;
                txtG1RdvSis_telefo_sitr.Text = tobReg["sis_telefo_sitr"] != null ? tobReg["sis_telefo_sitr"].ToString() : String.Empty;
                txtG1RdvSis_emailc_sitr.Text = tobReg["sis_emailc_sitr"] != null ? tobReg["sis_emailc_sitr"].ToString() : String.Empty;
                txtG1RdvSis_direcc_sitr.Text = tobReg["sis_direcc_sitr"] != null ? tobReg["sis_direcc_sitr"].ToString() : String.Empty;
                txtG1RdvSis_codmun_muni.Text = tobReg["sis_codmun_muni"] != null ? tobReg["sis_codmun_muni"].ToString() : String.Empty;
                txtG1RdvSis_nommun_muni.Text = tobReg["sis_nommun_muni"] != null ? tobReg["sis_nommun_muni"].ToString() : String.Empty;
                txtG1RdvSis_coddep_dpto.Text = tobReg["sis_coddep_dpto"] != null ? tobReg["sis_coddep_dpto"].ToString() : String.Empty;
                txtG1RdvSis_desdep_dpto.Text = tobReg["sis_desdep_dpto"] != null ? tobReg["sis_desdep_dpto"].ToString() : String.Empty;
                txtG1RdvSis_codpos_sicp.Text = tobReg["sis_codpos_sicp"] != null ? tobReg["sis_codpos_sicp"].ToString() : String.Empty;
                #endregion Cargar datos>
            }
            else
            {
                #region Cargar datos
                txtG1RdvFcm_numfac_mfac.Text = String.Empty;
                txtG1RdvFcm_typdoc_fctd.Text = String.Empty;
                txtG1RdvFcm_destyp_fctd.Text = String.Empty;
                txtG1RdvFcm_fecfac_mfac.Text = String.Empty;
                txtG1RdvFcm_horfac_mfac.Text = String.Empty;
                txtG1RdvFcm_notdoc_mfac.Text = String.Empty;
                txtG1RdvFcm_facori_mfac.Text = String.Empty;
                txtG1RdvFcm_idcufe_mfac.Text = String.Empty;
                txtG1RdvFcm_diafec_mfac.Text = String.Empty;
                txtG1RdvFcm_diahor_mfac.Text = String.Empty;
                txtG1RdvFcm_codest_fcws.Text = String.Empty;
                txtG1RdvFcm_desest_fcws.Text = String.Empty;
                txtG1RdvSis_tipper_sitr.Text = String.Empty;
                txtG1RdvSis_numide_sitr.Text = String.Empty;
                txtG1RdvSis_razsoc_sitr.Text = String.Empty;
                txtG1RdvSis_nomcon_sitr.Text = String.Empty;
                txtG1RdvSis_telefo_sitr.Text = String.Empty;
                txtG1RdvSis_emailc_sitr.Text = String.Empty;
                txtG1RdvSis_direcc_sitr.Text = String.Empty;
                txtG1RdvSis_codmun_muni.Text = String.Empty;
                txtG1RdvSis_nommun_muni.Text = String.Empty;
                txtG1RdvSis_coddep_dpto.Text = String.Empty;
                txtG1RdvSis_desdep_dpto.Text = String.Empty;
                txtG1RdvSis_codpos_sicp.Text = String.Empty;
                #endregion Cargar datos>
            }
        }
        #endregion FcvCargarReferenciaNotaDebito>
        #endregion Ventana Propiedades Vista de datos 

    }
}
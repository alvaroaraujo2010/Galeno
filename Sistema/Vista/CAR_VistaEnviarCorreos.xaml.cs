//- MARMOTA-GENCODE: VERSION 2.0 - 17/10/2020 08:35:54 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.VistaModelo;
using Sistema.Clases;
using Sistema.Modelo;
using Sistema.Dian;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Windows.Media;
using System.Text.RegularExpressions;
using static Sistema.Dian.General;

namespace Sistema.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carfemailgestioma
    /// </summary>
    public partial class VistaEnviarCorreos : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false; 
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        //- Gestion de Errores
        DialogVistaErrores lobDlgLogs = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public ModeloFeFacturaMa lobRegDoc;
        public DocumentoAttached lobXmlDoc;
        /// <summary>
        /// Enviar correo al ADquirente
        /// </summary>
        /// <param name="tcrOrigenGestion">Registro documento completo para Generar Attached (Adjunto)</param>
        /// <param name="tcrIdCodigo">Codigo unico del registro a localizar cuando sea requerido</param>
        public VistaEnviarCorreos(ModeloFeFacturaMa tobRegDocument, DocumentoAttached tobXmlDoc)
        {
            InitializeComponent();

            lobRegDoc = tobRegDocument;
            lobXmlDoc = tobXmlDoc;
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            //vm.GcrUsuIdUsuario = oAppEntorno.gcrUsuIdUsuario;
            //vm.GcrUsuCodigoPerfil = oAppEntorno.gcrUsuCodigoPerfil;

            //cmdGuardar.Visibility = Visibility.Hidden;
            //cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            //dpkG1Car_envfec_caml.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            // cargar datos
            FcvCargarDatosVista();
            fcvTimerGeneral();
            llgModoEdicion = true;
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
            if (this.IsLoaded && llgModoEdicion == true)
            {
                if (llgModoEdicionKey == false && llgModoEdicionValid == false)
                {
                    llgModoEdicionValid = true;
                    flgValidacion();
                }
            }
            if (llgModoEdicion == false) { gdspTimerSistema.Stop(); }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region FcvCargarDatosVista: Cargar vista de datos

        /// <summary>
        /// Cargar datos vista campos 
        /// </summary>
        private void FcvCargarDatosVista()
        {
            // Datos Razon social
            this.txtG1Fcm_numprn_fcem.Text = lobRegDoc.lobRegEmpresa.Fcm_numprn_fcem;
            this.txtG1Fcm_razsoc_fcem.Text = lobRegDoc.lobRegEmpresa.Fcm_razsoc_fcem;
            this.txtG1Fcm_ctoema_fcem.Text = lobRegDoc.lobRegEmpresa.Fcm_ctoema_fcem;
            this.txtInstCorreo.Text        = lobRegDoc.lobRegEmpresa.Fcm_ctoema_fcem;
            // Datos del Cliente
            this.txtG1Sis_idterc_sitr.Text = lobRegDoc.lobRegCliente.Sis_idterc_sitr;
            this.txtG1Sis_razsoc_sitr.Text = lobRegDoc.lobRegCliente.Sis_razsoc_sitr;
            this.txtG1Sis_emailc_sitr.Text = lobRegDoc.lobRegCliente.Sis_emailc_sitr;
            this.txtG1Car_attached_caml.Text = lobXmlDoc.DocGenNombreXmlRutaFirmado;
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
                //cmdAdicionar.Visibility = Visibility.Hidden;
                //cmdModificar.Visibility = Visibility.Hidden;
                //cmdGuardar.Visibility = Visibility.Visible;
                //cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                //cmdAdicionar.Visibility = Visibility.Visible;
                //cmdModificar.Visibility = Visibility.Visible;
                //cmdGuardar.Visibility = Visibility.Hidden;
                //cmdCancelar.Visibility = Visibility.Hidden;
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
            //fcvFinalizarInstanciaDatos();
            gdspTimerSistema.Stop();
            this.Close();
        }

        private void CmdSalir_Click(object sender, RoutedEventArgs e)
        {
            //fcvFinalizarInstanciaDatos();
            gdspTimerSistema.Stop();
            this.Close();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
        //-------------------------------------------------
        // Envio de correo
        //-------------------------------------------------
        #region Envio de correo
        private async void CmdButton_EnviarCorreo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Enviar el correo?", "Enviar",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var _lobDlgAdd = new DialogProgressBarEx();
                _lobDlgAdd.fcvProgressBarIniciar("Enviando el correo...", "CENTRO");
                _lobDlgAdd.Owner = this;
                _lobDlgAdd.Show();

                try
                {
                    await FobEnviarCorreo();
                    _lobDlgAdd.Close();
                }
                catch (Exception ex)
                {
                    _lobDlgAdd.Close();
                    MessageBox.Show("Error al enviar: " + ex.Message);
                }
            }
        }
        #endregion Envio de correo
        #region FobEnviarCorreo: Enviar correo
        private async Task FobEnviarCorreo()
        {
            #region enviar correo
            var lcrHost = "smtp.gmail.com"; // Gnail por defecto
            var lcrMail = this.txtInstCorreo.Text.ToLower();
            lcrHost = lcrMail.Contains("@hotmail") ||
                      lcrMail.Contains("@live") ||
                      lcrMail.Contains("@outlook") ? "smtp.live.com" : lcrHost;

            var lobFromAddress = new MailAddress(this.txtInstCorreo.Text); 

            string lcrFromPassword = this.txtInstClave.Password;
            string lcrSubject      = this.txtG1Car_subjec_caml.Text;
            string lcrBody         = this.txtG1Car_bodyms_caml.Text;

            var smtp = new SmtpClient
            {
                Host = lcrHost, // smtp.live.com -> Hotmail / smtp.gmail.com -> Gmail 
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(lobFromAddress.Address, lcrFromPassword),
                //Timeout = 20000,
            };
            using (var lobMessage = new MailMessage()
            {
                Subject = lcrSubject,
                Body    = lcrBody,
            })
            {
                // quien envia
                lobMessage.From = new MailAddress(lobFromAddress.Address, this.txtG1Fcm_razsoc_fcem.Text, Encoding.UTF8);

                // quien recibe
                //string[] to = { "jbarrios1973@gmail.com", "freddynr@hotmail.com" };
                var lcrDestino = this.txtG1Sis_emailc_sitr.Text;
                string[] to = lcrDestino.Split(',');
                foreach (string item in to)
                {
                    lobMessage.To.Add(new MailAddress(item));
                }

                // Generar el comprimido 
                var lcrRutaDestinoZip = ObtenerRutaCambiandoExtension(this.txtG1Car_attached_caml.Text, "zip");
                CrearZip(this.txtG1Car_attached_caml.Text, lcrRutaDestinoZip, true);

                //  1 - Archivo adicional
                if (string.IsNullOrWhiteSpace(this.txtArchivoAdjunto1.Text) == false)
                {
                    CrearZip(this.txtArchivoAdjunto1.Text, lcrRutaDestinoZip, false);
                }

                //  2 - Archivo adicional
                if (string.IsNullOrWhiteSpace(this.txtArchivoAdjunto2.Text) == false)
                {
                    CrearZip(this.txtArchivoAdjunto2.Text, lcrRutaDestinoZip, false);
                }

                // Adjuntar archivo para enviar al correo
                var lobAttachment = new System.Net.Mail.Attachment(lcrRutaDestinoZip);
                lobMessage.Attachments.Add(lobAttachment);

                /*
                // Adjuntar archivo por defecto
                var lobAttachment = new System.Net.Mail.Attachment(this.txtG1Car_attached_caml.Text);
                lobMessage.Attachments.Add(lobAttachment);

                // cuando hay un archivo adicional
                if (string.IsNullOrWhiteSpace(this.txtArchivoAdjunto.Text) == false)
                {
                    lobAttachment = new System.Net.Mail.Attachment(this.txtArchivoAdjunto.Text);
                    lobMessage.Attachments.Add(lobAttachment);
                }
                */

                // Enviar el correo
                await smtp.SendMailAsync(lobMessage);

                MessageBox.Show("Se envio el correo");
            }
            #endregion enviar correo>
            return;
        }
        #endregion Envio de correo>
        // Buscar el archivos adjuntos
        #region Buscar los archivos adjunto
        private void CmdButton_GetFile_Click1(object sender, RoutedEventArgs e)
        {
            GetFile("1");
        }
        private void CmdButton_DeleteGetFile_Click1(object sender, RoutedEventArgs e)
        {
            this.txtArchivoAdjunto1.Text = string.Empty;
        }
        private void CmdButton_GetFile_Click2(object sender, RoutedEventArgs e)
        {
            GetFile("2");
        }
        private void CmdButton_DeleteGetFile_Click2(object sender, RoutedEventArgs e)
        {
            this.txtArchivoAdjunto2.Text = string.Empty;
        }

        private void GetFile(string tcrTipo)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                if (tcrTipo == "1")
                {
                    this.txtArchivoAdjunto1.Text = openFileDialog.FileName;
                }
                else
                {
                    this.txtArchivoAdjunto2.Text = openFileDialog.FileName;
                }
            }
        }
        #endregion Buscar el archivo adjunto>
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
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region fcvValidacionTextoPassword: Validacion del campo contraseña
        // Validacion del campo contraseña
        private void fcvValidacionTextoPassword(object sender, RoutedEventArgs e)
        {
            llgModoEdicionKey = true;
            var lobTextBox = sender as PasswordBox;
            fcrValidacion(lobTextBox.Name);
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion fcvValidacionTextoPassword>

        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (!string.IsNullOrWhiteSpace(fcrValidacion("txtInstCorreo"))) { lnuCont++; }
            if (!string.IsNullOrWhiteSpace(fcrValidacion("txtInstClave"))) { lnuCont++; }
            if (!string.IsNullOrWhiteSpace(fcrValidacion("txtG1Sis_emailc_sitr"))) { lnuCont++; }
            if (!string.IsNullOrWhiteSpace(fcrValidacion("txtG1Car_subjec_caml"))) { lnuCont++; }
            if (!string.IsNullOrWhiteSpace(fcrValidacion("txtG1Car_bodyms_caml"))) { lnuCont++; }
            
            this.cmdEnviar.IsEnabled = lnuCont > 0 || llgModoEdicion == false ? false : true;
            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public string fcrValidacion(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;
            string lcrNumeroRegistro = "USUARIO";
            string lcrCodigoError = string.Empty;
            string lcrNombreCampo = string.Empty;
            string lcrNivelError = "ALTO";
            string lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtInstCorreo":
                        #region Validacion
                        lcrNombreCampo = "Correo institucional de envio";
                        lcrValorReturn = string.Empty;
                        lcrCodigoError = "A01";

                        if (string.IsNullOrWhiteSpace(this.txtInstCorreo.Text))
                        {
                            lcrValorReturn = lcrNombreCampo +  ": Es requerido";
                        }
                        else
                        {
                            // Validar el correo
                            if (FlgValidarCorreo(this.txtInstCorreo.Text) == false)
                            {
                                lcrValorReturn = lcrNombreCampo + ": no es un nombre válido";
                            }
                            else
                            {
                                var lcrMail = this.txtInstCorreo.Text.ToLower();
                                lcrValorReturn = lcrMail.Contains("@hotmail") ||
                                                 lcrMail.Contains("@live") ||
                                                 lcrMail.Contains("@outlook") ||
                                                 lcrMail.Contains("@gmail") ? "" :
                                                 lcrNombreCampo + ": solo se permite enviar desde correos de HOTMAIL y GMAIL";
                            }
                        }

                        // cuando no hay error
                        if (this.txtG1Fcm_ctoema_fcem != null)
                        {
                            this.txtG1Fcm_ctoema_fcem.Text = string.IsNullOrWhiteSpace(lcrValorReturn) ?
                                                                            this.txtInstCorreo.Text : "Correo Errado";
                        }

                        fcvSetColorValidacion(this.txtInstCorreo, lcrValorReturn);
                        break;
                        #endregion

                    case "txtInstClave":
                        #region Validacion
                        lcrNombreCampo = "Contraseña";
                        lcrValorReturn = string.Empty;
                        lcrCodigoError = "A02";

                        if (string.IsNullOrWhiteSpace(this.txtInstClave.Password))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerida";
                        }

                        fcvSetColorValidacionPss(this.txtInstClave, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sis_emailc_sitr":
                        #region Validacion
                        lcrNombreCampo = "Correo del adquirente (destinatario)";
                        lcrValorReturn = string.Empty;
                        lcrCodigoError = "A03";

                        if (string.IsNullOrWhiteSpace(this.txtG1Sis_emailc_sitr.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (this.txtG1Sis_emailc_sitr.Text.Contains(",") == true)
                            {
                                if (FlgValidarVariosCorreos(this.txtG1Sis_emailc_sitr.Text) == false)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": algún correo no es válido";
                                }
                            }
                            else
                            {
                                // Validar el correo
                                if (FlgValidarCorreo(this.txtG1Sis_emailc_sitr.Text) == false)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": no es un nombre válido";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sis_emailc_sitr, lcrValorReturn);
                        break;
                    #endregion

                    case "txtG1Car_subjec_caml":
                        #region Validacion
                        lcrNombreCampo = "Asunto";
                        lcrValorReturn = string.Empty;
                        lcrCodigoError = "A04";

                        if (string.IsNullOrWhiteSpace(this.txtG1Car_subjec_caml.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Validar el correo
                            if (this.txtG1Car_subjec_caml.Text.Trim().Length <= 10)
                            {
                                lcrValorReturn = lcrNombreCampo + ": es demasiado corto";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Car_subjec_caml, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Car_bodyms_caml":
                        #region Validacion
                        lcrNombreCampo = "Mensaje";
                        lcrValorReturn = string.Empty;
                        lcrCodigoError = "A05";

                        if (string.IsNullOrWhiteSpace(this.txtG1Car_bodyms_caml.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Validar el correo
                            if (this.txtG1Car_bodyms_caml.Text.Trim().Length <= 10)
                            {
                                lcrValorReturn = lcrNombreCampo + ": es demasiado corto";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Car_bodyms_caml, lcrValorReturn);
                        break;
                        #endregion
                }

                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                if (this.cmdLogErrores != null && this.cmdEnviar != null)
                {
                    this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;
                    this.cmdEnviar.IsEnabled = tmpLogErrores.Count > 0 ? false : true;
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        // Validar correo
        private bool FlgValidarCorreo(string tcrCorreo)
        {
            var lcrExpresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return Regex.IsMatch(tcrCorreo, lcrExpresion);
        }
        private bool FlgValidarVariosCorreos(string tcrCorreos)
        {
            var llgReturn = true;
            string[] larList = tcrCorreos.Split(',');
            foreach (var lcrCorreo in larList)
            {
                if (string.IsNullOrWhiteSpace(lcrCorreo) == false && llgReturn == true)
                {
                    llgReturn = FlgValidarCorreo(lcrCorreo);
                }
            }

            return llgReturn;
        }
        private void fcvSetColorValidacion(TextBox tobObjeto, string tcrValorReturn)
        {
            tobObjeto.ToolTip = SetToolTip(tcrValorReturn);
            if (!string.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;

            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }
        private void fcvSetColorValidacionPss(PasswordBox tobObjeto, string tcrValorReturn)
        {
            tobObjeto.ToolTip = SetToolTip(tcrValorReturn);
            if (!string.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;

            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }

        #endregion
        #region SetToolTip : Devolver el valor para texto ayuda 
        /// <summary>
        /// <para>Devolver el valor para texto ayuda, cuando es vacio devuelve null </para>
        /// <para>para que no se muestre la vista del tooltip vacia.</para>
        /// </summary>
        public static string SetToolTip(string tcrTexto)
        {
            var lcrValor = !string.IsNullOrWhiteSpace(tcrTexto) ? tcrTexto : null;
            return lcrValor;
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
                case "txtG1Car_secreg_cagm":
                    txtG1Car_secreg_cagm.Text = tcrCodigo;
                    break;

                case "txtG1Sis_idterc_sitr":
                    txtG1Sis_idterc_sitr.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_secreg_mfac":
                    //MessageBox.Show(" aui voy "+ tcrCodigo);
                    txtG1Fcm_numprn_fcem.Text = tcrCodigo;
                    // llamar al metodo que adiciona al registro detalle
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // CARFEMAILGESTIOMA : Maestro gestor de correos grupales que se envian al adquiren
        #region KeyDown para campos con F2 Tabla: CARFEMAILGESTIOMA
        #region CAR_SECREF_CAGM : Maestro gestor de correos grupales que se envian al adquiren
        private void txtG1Car_secref_cagm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Car_secref_cagm_Browser();
            }
        }
        private void cmdG1Car_secref_cagm_Click(object sender, RoutedEventArgs e)
        {
            txtG1Car_secref_cagm_Browser();
        }
        private void txtG1Car_secref_cagm_Browser()
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG1Car_secref_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_IDTERC_SITR : Tabla terceros para gestion contable
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
        #endregion
        // CARFEMAILGESTIOMF : Referencias a documentos en cuentas de cobro con varias fact
        #region KeyDown para campos con F2 Tabla: CARFEMAILGESTIOMF
        #region CAR_SECREG_CAGM : Maestro gestor de correos grupales que se envian al adquiren
        private void txtG2Car_secreg_cagm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Car_secreg_cagm_Browser();
            }
        }
        private void cmdG2Car_secreg_cagm_Click(object sender, RoutedEventArgs e)
        {
            txtG2Car_secreg_cagm_Browser();
        }
        private void txtG2Car_secreg_cagm_Browser()
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG2Car_secreg_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_SECREG_MFAC : Maestro de facturas electronicas
        private void txtG2Fcm_secreg_mfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Fcm_secreg_mfac_Browser();
            }
        }
        private void cmdG2Fcm_secreg_mfac_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_secreg_mfac_Browser();
        }
        private void txtG2Fcm_secreg_mfac_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESFACTEFMA", "", "Maestro de facturas electronicas...");
            gcrCtrF2TexBox = "txtG2Fcm_secreg_mfac";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("CAR", "CARFEMAILGESTIOMA", "", "Maestro gestor de correos grupales que se envian al adquiren...");
            gcrCtrF2TexBox = "txtG1Car_secreg_cagm";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #region Vista Maestro Razon social
        private void CmdG1Car_faddre_caml_Click(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("FCM", "FCMFEMAESRAZSOCMA", "", "Maestro Razon social de la empresa...");
            gcrCtrF2TexBox = "txtG2Fcm_secreg_mfac";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                    case "dpkG1Car_envfec_caml":
                        /*
                        txtG1Car_envfec_caml.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Car_envfec_caml);
                        */
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
                            case "txtG1Car_envfec_caml":
                                //dpkG1Car_envfec_caml.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
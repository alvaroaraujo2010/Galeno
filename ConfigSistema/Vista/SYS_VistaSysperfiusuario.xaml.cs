//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2014 09:42:28 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Systemas.VistaModelo;
using System.IO;

using Sistema.Dian;
//using Sistema.Modelo;
using static Sistema.Dian.Global;
//using static Sistema.Dian.General;
using static Sistema.Dian.Utilidades;
using static Sistema.Dian.ParametrosDian;
//using System.Runtime.CompilerServices;

namespace Systemas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sysperfiusuario
    /// </summary>
    public partial class VistaSysperfiusuario : Window, SIS_Interface
    {

        public string DocGenNombreXmlFirmado;
        public string DocGenNombreXmlSinFirma;
        public string DocGenNombreZipFirmado;
        public string DocGenNombreXmlRutaFirmado;
        public string DocGenNombreXmlRutaSinFirma;
        public string DocGenNombreZipRutaFirmado;
        public int DocGenNombreContadorSecuencial = 0;

        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSysperfiusuario()
        {
            //AppContext.SetSwitch("Switch.System.Security.Cryptography.Xml.UseInsecureHashAlgorithms", true);
            //AppContext.SetSwitch("Switch.System.Security.Cryptography.Pkcs.UseInsecureHashAlgorithms", true);

            InitializeComponent();
            llgObjetosCargados = true;

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

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
            FocusManager.SetFocusedElement(this, txtG1Sys_desper_perf);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Sys_codcom_comd);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sys_desper_perf);
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
            FocusManager.SetFocusedElement(this, txtG2Sys_codcom_comd);
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
            FocusManager.SetFocusedElement(this, txtG2Sys_codcom_comd);
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
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Sys_codper_perf":
                    txtG1Sys_codper_perf.Text = tcrCodigo;
                    break;

                case "txtG2Sys_codcom_comd":
                    txtG2Sys_codcom_comd.Text = tcrCodigo;
                    break;

                case "txtG2Sys_codmod_modu":
                    txtG2Sys_codmod_modu.Text = tcrCodigo;
                    break;

                case "txtG2Sys_codcom_comp":
                    txtG2Sys_codcom_comp.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // SYSPERFIUSUARIO : Maestro perfiles de usuarios
        #region KeyDown para campos con F2 Tabla: SYSPERFIUSUARIO
        #endregion
        // SYSCOMPONPERFIL : Componentes asignados a un perfil
        #region KeyDown para campos con F2 Tabla: SYSCOMPONPERFIL
        #region SYS_CODCOM_COMD : Componentes tipo formulario u opción en Módulo
        private void txtG2Sys_codcom_comd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SYS", "SYSCOMPMODULOS", "", "Componentes tipo formulario u opción en Módulo...");
                gcrCtrF2TexBox = "txtG2Sys_codcom_comd";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SYS_CODMOD_MODU : Módulos del Sistema
        private void txtG2Sys_codmod_modu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SYS", "SYSMODULOSISTEM", "", "Módulos del Sistema...");
                gcrCtrF2TexBox = "txtG2Sys_codmod_modu";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SYS_CODCOM_COMP : Componentes tipo formulario u opción de Módulos
        private void txtG2Sys_codcom_comp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SYS", "SYSCOMPONENTES", "", "Componentes tipo formulario u opción de Módulos...");
                gcrCtrF2TexBox = "txtG2Sys_codcom_comp";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SYS", "SYSPERFIUSUARIO", "", "Maestro perfiles de usuarios...");
            gcrCtrF2TexBox = "txtG1Sys_codper_perf";
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
                        case "cboG1Sys_nivusu_perf":
                            txtG1Sys_nivusu_perf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_nivusu_perf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_nivusu_perf.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Sys_estper_perf":
                            txtG1Sys_estper_perf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Sys_estper_perf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Sys_estper_perf.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sys_estccp_cper":
                            txtG2Sys_estccp_cper.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sys_estccp_cper.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sys_estccp_cper.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Sys_nivusu_perf":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Sys_nivusu_perf.SelectedItem;
                            cboG1Sys_nivusu_perf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Sys_estper_perf":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Sys_estper_perf.SelectedItem;
                            cboG1Sys_estper_perf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Sys_estccp_cper":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG2Sys_estccp_cper.SelectedItem;
                            cboG2Sys_estccp_cper.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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

        #region Metodos pruebas factura electronica

        #region Metodos pruebas
        private void cmdPrueba_Click(object sender, RoutedEventArgs e)
        {
            if (txtTipoDocumento.Text.Trim() == "FV") // Factura
            {
                FcvGenerarFacturaEjemploXml();
            }

            if (txtTipoDocumento.Text.Trim() == "NC") // Nota Credito
            {
                FcvGenerarNotaCreditoEjemploXml();
            }

            if (txtTipoDocumento.Text.Trim() == "ND") // Nota Debito
            {
                FcvGenerarNotaDebitoEjemploXml();
            }

        }

        private void cmdPruebaFirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtTipoDocumento.Text.Trim() == "FV") // Factura
            {
                FcvFirmarDocumento(TipoFirma.Factura);
            }
            if (txtTipoDocumento.Text.Trim() == "NC") // Nota Credito
            {
                FcvFirmarDocumento(TipoFirma.NotaCrédito);
            }
            if (txtTipoDocumento.Text.Trim() == "ND") // Nota Debito
            {
                FcvFirmarDocumento(TipoFirma.NotaDébito);
            }
        }

        private void cmdPruebaEnviar_Click(object sender, RoutedEventArgs e)
        {
            FcvEjemploEnvio();
        }

        public void cmdPruebaConsultar_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument respuestaXml;

            if (!FlgEnviarSolicitud("<wcf:GetStatusZip><wcf:trackId>" + txtIDTestSetPrueba.Text.Trim() + "</wcf:trackId></wcf:GetStatusZip>", Operación.GetStatusZip,
                  out string mensajeEnvío, out respuestaXml))
            {
                MessageBox.Show(mensajeEnvío, "Error en Solicitud GetStatus a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        
            // Extraer el ZipKey para consultar estado validación mas tarde
            var lobNodo = respuestaXml.DocumentElement.GetElementsByTagName("b:XmlDocumentKey");
            if (lobNodo.Count > 0)
            {
                txtIDRadicadoFactura.Text = lobNodo[0].InnerText;
            }

            Funciones.FcvVistaResponse(respuestaXml.DocumentElement.OuterXml, "Resultados", this);

        }
                        
        public void cmdPruebaRadicado_Click(object sender, RoutedEventArgs e)
        {
            
            XmlDocument respuestaXml;

            if (!FlgConsultarGetStatusDocumento(txtIDRadicadoFactura.Text.Trim(), out string tcrMensaje, out respuestaXml))
            {
                MessageBox.Show(tcrMensaje, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Funciones.FcvVistaResponse(respuestaXml.DocumentElement.OuterXml, "Resultados");
            }

            /*
            XmlDocument respuestaXml;

            if (!FlgEnviarSolicitud("<wcf:GetStatus><wcf:trackId>" + txtIDRadicadoFactura.Text.Trim() + "</wcf:trackId></wcf:GetStatus>", Operación.GetStatus,
                  out string mensajeEnvío, out respuestaXml))
            {
                MessageBox.Show(mensajeEnvío, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
            Funciones.FcvVistaResponse(respuestaXml.DocumentElement.OuterXml, "Resultados");
            */
        }

        public void CmdllaveTecnicaProducc_Click(object sender, RoutedEventArgs e)
        {

            XmlDocument respuestaXml;
       
            // Cargar los dato de la razon social 
            Empresa.FcvCargarRazonSocial("NIT", txtNit.Text.Trim());

            if (!FlgConsultarGetNumberingRange(Empresa.Nit, Empresa.IdentificadorAplicación, out string tcrMensaje, out respuestaXml))
            {
                MessageBox.Show(tcrMensaje, "Error en Solicitud Clave tenica Produccion a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Funciones.FcvVistaResponse(respuestaXml.DocumentElement.OuterXml, "Resultados");
            }
            

            /*
            XmlDocument respuestaXml;

            if (!FlgEnviarSolicitud("<wcf:GetStatus><wcf:trackId>" + txtIDRadicadoFactura.Text.Trim() + "</wcf:trackId></wcf:GetStatus>", Operación.GetStatus,
                  out string mensajeEnvío, out respuestaXml))
            {
                MessageBox.Show(mensajeEnvío, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
            Funciones.FcvVistaResponse(respuestaXml.DocumentElement.OuterXml, "Resultados");
            */
        }



        #endregion Metodos pruebas

        #region Funciones

        public void FcvGenerarFacturaEjemploXml()
        {
            var lcrNumFactura = txtNumeroFactura.Text.Trim();
            Empresa.ConsecutivoDianAnual = Convert.ToInt32(txtSecuencial.Text.Trim());

            if (FlgGenerarDocumentoFactura(lcrNumFactura, out _, out string tcrMensaje, out DocumentoFactura lobRefFact))
            {
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                MessageBox.Show("¡Éxito al generar Factura a la DIAN!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information); // Éxito. Se puede continuar con los procedimientos posteriores como grabar en la base de datos, hacer cambios en la interfaz y demás.

            }
            else
            {
                MessageBox.Show(tcrMensaje, "Error en Factura Electrónica", MessageBoxButton.OK, MessageBoxImage.Error);  // Error. Se aborta la operación, no se debe grabar en la base de datos y se debe mantener la interfaz inalterada para que se realicen las correcciones necesarias.
            }

        } // FacturaEjemploXml>

        public void FcvGenerarNotaCreditoEjemploXml()
        {
            var lcrNumFactura = txtNumeroFactura.Text.Trim();
            Empresa.ConsecutivoDianAnual = Convert.ToInt32(txtSecuencial.Text.Trim());

            if (FlgGenerarDocumentoNotaCredito(lcrNumFactura, out _, out string tcrMensaje, out DocumentoNotaCredito lobRefFact))
            {
                DocGenNombreXmlFirmado = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial = lobRefFact.DocGenNombreContadorSecuencial;

                MessageBox.Show("¡Éxito al generar Nota Credito a la DIAN!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information); // Éxito. Se puede continuar con los procedimientos posteriores como grabar en la base de datos, hacer cambios en la interfaz y demás.

            }
            else
            {
                MessageBox.Show(tcrMensaje, "Error en Nota Credito Electrónica", MessageBoxButton.OK, MessageBoxImage.Error);  // Error. Se aborta la operación, no se debe grabar en la base de datos y se debe mantener la interfaz inalterada para que se realicen las correcciones necesarias.
            }

            /*
            if (FlgGenerarDocumentoNotaCredito(lcrNumFactura, out _, out string tcrMensaje, out DocumentoNotaCredito lobRefFact))
            {
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                MessageBox.Show("¡Éxito al generar Nota Credito a la DIAN!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information); // Éxito. Se puede continuar con los procedimientos posteriores como grabar en la base de datos, hacer cambios en la interfaz y demás.

            }
            else
            {
                MessageBox.Show(tcrMensaje, "Error en Nota Credito Electrónica", MessageBoxButton.OK, MessageBoxImage.Error);  // Error. Se aborta la operación, no se debe grabar en la base de datos y se debe mantener la interfaz inalterada para que se realicen las correcciones necesarias.
            }
            */

        } // FacturaEjemploXml>


        public void FcvGenerarNotaDebitoEjemploXml()
        {
            var lcrNumFactura = txtNumeroFactura.Text.Trim();
            Empresa.ConsecutivoDianAnual = Convert.ToInt32(txtSecuencial.Text.Trim());

            if (FlgGenerarDocumentoNotaDebito(lcrNumFactura, out _, out string tcrMensaje, out DocumentoNotaDebito lobRefFact))
            {
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                MessageBox.Show("¡Éxito al generar Nota Debito a la DIAN!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information); // Éxito. Se puede continuar con los procedimientos posteriores como grabar en la base de datos, hacer cambios en la interfaz y demás.

            }
            else
            {
                MessageBox.Show(tcrMensaje, "Error en Nota Debito Electrónica", MessageBoxButton.OK, MessageBoxImage.Error);  // Error. Se aborta la operación, no se debe grabar en la base de datos y se debe mantener la interfaz inalterada para que se realicen las correcciones necesarias.
            }

        } // FacturaEjemploXml>


        public void FcvFirmarDocumento(TipoFirma tenTipoFirma)
        {
            var ldaFecha = DateTime.Now;

            if (!FlgFirmarArchivo(tenTipoFirma,
                                 ldaFecha,
                                 DocGenNombreXmlRutaSinFirma,
                                 DocGenNombreXmlRutaFirmado,
                                 out string tcrMensajeError))
            {
                MessageBox.Show(tcrMensajeError);
            }
            else
            {
                MessageBox.Show("Archivo firmado con éxito!!");
            }
        }

        public void FcvEjemploEnvio()
        {
            if (!FlgSendTestSetAsync(DocGenNombreXmlFirmado,Empresa.RutaDocumentoFirmado, 
                                                out string tcrMensaje, out XmlDocument tobRespuestaXml))
            {
                MessageBox.Show(tcrMensaje, "Error al enviar la factura", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Extraer el ZipKey para consultar estado validación mas tarde
            var lobNodo = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:ZipKey");
            if (lobNodo.Count > 0)
            {
                txtIDTestSetPrueba.Text = lobNodo[0].InnerText;
            }

            Funciones.FcvVistaResponse(tobRespuestaXml.DocumentElement.OuterXml, "Resultados");
        }

        #endregion Funciones> 

        #endregion Metodos pruebas factura electronica>

    }
}
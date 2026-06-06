using System;
using System.Windows;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Dian;
//using Sistema.Modelo;
using static Sistema.Dian.Global;
//using static Sistema.Dian.General;
using static Sistema.Dian.Utilidades;


namespace Sistema.Dian
{
    /// <summary>
    /// Clase para gestion, creación del Documento y realizar el envio a la Dian
    /// </summary>
    public class FeGenDocumento
    {
        //-------------------------------------------------
        // Propiedades del documento generado
        //-------------------------------------------------
        #region Propiedades para documento generado
        /// <summary>
        /// Codigo CUFE/CUDE del Documento generado
        /// </summary>
        public string DocGenNombreCodigoCufe { get; set; }
        /// <summary>
        /// Nombre del archivo fisico general sin ninguan extension generado en el proceso: : Ejemplo "fv08240046880002000000001"
        /// </summary>
        public string DocGenNombreXmlSinExtension { get; set; }
        /// <summary>
        /// Nombre del archivo firmado con extension .XML generado en el proceso: : Ejemplo "fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlFirmado { get; set; }
        /// <summary>
        /// Nombre del archivo con extension .XML antes de ser firmado: Ejemplo "fv08240046880002000000001-sf.xml"
        /// <para>Nota: Aqui solo se genera el nombre, el archivo fisico .XML se genera cuando se firma.</para>
        /// </summary>
        public string DocGenNombreXmlSinFirma { get; set; }
        /// <summary>
        /// Nombre del archivo firmado con extension .ZIP generado en el proceso: : Ejemplo "fv08240046880002000000001.zip"
        /// <para>Nota: Aqui solo se genera el nombre, el archivo fisico .ZIP se genera cuando se firma.</para>
        /// </summary>
        public string DocGenNombreZipFirmado { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .XML firmado pendiente para enviar: Ejemplo "c:/archivos/firmados/fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlRutaFirmado { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .xml sin firmar: Ejemplo "c:/archivos/sinfirma/fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlRutaSinFirma { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .ZIP firmado pendiente para enviar: Ejemplo "c:/archivos/firmados/fv08240046880002000000001.zip"
        /// </summary>
        public string DocGenNombreZipRutaFirmado { get; set; }
        /// <summary>
        /// Numero secuencial de gestion (contador de empaquetados para envios)
        /// </summary>
        public int DocGenNombreContadorSecuencial { get; set; } = 0;
        #endregion Propiedades para docuemento generado>
        // Variables gestion vista de espera 
        #region Variables gestion vista de espera 
        DialogProgressBarEx LobVistaEspera = null;
        /// <summary>
        /// Activar o desactivar las ventantas de espera que se muestran durante el proceso (ocultas por defecto = false)
        /// </summary>
        public bool LlgMostrarVistaEspera = false;

        /// <summary>
        /// Referencia a la ventana Windows que hace la llamada al proceso, para bloquear vista con la pantalla de espera
        /// </summary>
        public Window LobOwner;
        #endregion Variables gestion vista de espera 
        // Variables Tipo parametros
        #region Variables Tipo parametros
        /// <summary>
        /// Codigo unico del registro en el Maestro Facturacion Electronica para consultas utilitarias del proceso
        /// </summary>
        public string GestIdUnicoDocumento { get; set; }
        /// <summary>
        /// Numero del documento Factura/Nota Credito/Nota Debito
        /// </summary>
        public string GestNumeroDocumento { get; set; }

        /// <summary>
        /// Fecha de envio solictud radicacion documento en la plataforma DIAN
        /// </summary>
        public DateTime GestFechaEnvioDian { get; set; } = Funciones.FdaFechaActual();

        /// <summary>
        /// Hora de envio solicitud radicacion documento en la plataforma DIAN
        /// </summary>
        public decimal GestHoraEnvioDian { get; set; } = Funciones.FdeHoraActualMilitar();
        #endregion Variables Tipo parametros
        // Variables Tipo registro
        #region Variables Tipo Referencias auxiliares de gestion
        /// <summary>
        /// Registro Maestro del documento a generar Factura/Nota Credito/Nota Debito
        /// </summary>
        public ModeloFeFacturaMa TobRegDoc { get; set; }

        /// <summary>
        /// Referencia al documento Tipo Factura Generado
        /// </summary>
        DocumentoFactura LobRefFact { get; set; }

        /// <summary>
        /// Referencia al documento Tipo Nota Credito Generado
        /// </summary>
        DocumentoNotaCredito LobRefCred { get; set; }

        /// <summary>
        /// Referencia al documento Tipo Nota Debito Generado
        /// </summary>
        DocumentoNotaDebito LobRefDebi { get; set; }

        #endregion Referencias

        // Iniciar Gestion del documento
        #region FlgEnviarDocumentoDian Iniciar el proceso para generar XML y enviar
        /// <summary>
        /// Iniciar el proceso para generar XML y enviar a la Dian
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NF"=Numero de Factura</param>
        /// <param name="tcrNumDocumento">Numero del documento a generar y enviar</param>
        /// <param name="tobRespuestaXml">XML Respuesta entregada por los serivcios Dian</param>
        /// <param name="tobResponse">Objeto con la Respusta Response Dian procesada para gestion interna</param>
        /// <param name="tcrMensaje">Devuelve el mensaje del error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgEnviarDocumentoDian(string tcrTipo, string tcrNumDocumento, out XmlDocument tobRespuestaXml, out DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgSiguientePaso;
            tobRespuestaXml = null;
            tobResponse     = null;

            try
            {
                var lobRegDoc = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma(tcrTipo, tcrNumDocumento);

                if (lobRegDoc == null)
                {
                    tcrMensaje = $"Numero de documento {GestNumeroDocumento} no existe en la base de datos.";
                    llgSiguientePaso = false;
                }
                else
                {
                    llgSiguientePaso = FlgEnviarDocumentoDian(lobRegDoc, out tobRespuestaXml, out tobResponse, out tcrMensaje);
                }
            }
            catch (Exception ex)
            {
                tcrMensaje = "Error al generar el documento " + ex.Message;
                llgSiguientePaso = false;
            }
            return llgSiguientePaso;
        }
        #endregion FlgEnviarDocumentoDian>

        #region FlgEnviarDocuentoDian Generar XML desde el registro dado en parametro y enviar 
        /// <summary>
        /// Generar XML desde el registro dado en parametro y enviar
        /// </summary>
        /// <param name="tobRegistro">Registro desde la base de datos para generar XML y enviar a la DIAN</param>
        /// <param name="tobRespuestaXml">XML Respuesta entregada por los serivcios Dian</param>
        /// <param name="tobResponse">Objeto con la Respusta Response Dian procesada para gestion interna</param>
        /// <param name="tcrMensaje">Devuelve el mensaje del error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgEnviarDocumentoDian(ModeloFeFacturaMa tobRegistro, out XmlDocument tobRespuestaXml, out DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgSiguientePaso;
            tobRespuestaXml = null;
            tobResponse = null;

            try
            {
                TobRegDoc = tobRegistro;

                if (TobRegDoc == null)
                {
                    tcrMensaje = $"El registro dado en parametro no debe ser nulo.";
                    llgSiguientePaso = false;
                }
                else
                {
                    // por si algun proceso posterior lo necesita 
                    GestNumeroDocumento  = tobRegistro.Fcm_numfac_mfac;
                    GestIdUnicoDocumento = TobRegDoc.Fcm_secreg_mfac; 

                    // Generar el documento
                    llgSiguientePaso = FlgDianGenerarDocumento(out tcrMensaje);
                    // Firmar el documento
                    if (llgSiguientePaso)
                    {
                        llgSiguientePaso = FlgDianFirmarDocumento(out tcrMensaje);
                    }
                    // Enviar documento
                    if (llgSiguientePaso)
                    {
                        llgSiguientePaso = FlgDianEnviarDocumento(out tobRespuestaXml, out tcrMensaje);
                    }
                    // Leer respuesta recibida
                    if (llgSiguientePaso)
                    {
                        llgSiguientePaso = FlgDianActualizarMaestros(tobRespuestaXml, out tobResponse, out tcrMensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                tcrMensaje = "Error al generar el documento " + ex.Message;
                llgSiguientePaso = false;
            }
            return llgSiguientePaso;
        }
        #endregion
        //-------------------------------------------------
        // Generar Documento Dian
        //-------------------------------------------------
        // Generar/Firmar/Enviar
        #region FlgDianGenerarDocumento: Genera el archivo XML del tipo documento solicitado
        /// <summary>
        /// Genera el archivo XML del tipo documento solicitado
        /// </summary>
        /// <param name="tcrMensaje">Devuelve el mensaje de error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgDianGenerarDocumento(out string tcrMensaje)
        {
            var llgReturn = false;
            tcrMensaje = null;

            if (LlgMostrarVistaEspera == true)
            {
                LobVistaEspera = new DialogProgressBarEx();
                LobVistaEspera.Owner = LobOwner;
                LobVistaEspera.fcvProgressBarIniciar("Generando el Documento...", "CENTRO");
                LobVistaEspera.Show();
            }

            if (TobRegDoc.Fcm_typdoc_fctd == "01") // Factura
            {
                llgReturn = FlgDianGenerarFacturaXml(out tcrMensaje);
            }

            if (TobRegDoc.Fcm_typdoc_fctd == "91") // Nota Credito
            {
                llgReturn = FlgDianGenerarNotaCreditoXml(out tcrMensaje);
            }

            if (TobRegDoc.Fcm_typdoc_fctd == "92") // Nota Debito
            {
                llgReturn = FlgDianGenerarNotaDebitoXml(out tcrMensaje);
            }

            if (LobVistaEspera != null) { LobVistaEspera.Close(); }

            return llgReturn;
        }
        #endregion FlgDianGenerarDocumento
        #region FlgDianFirmarDocumento: Firmar el documento generado
        /// <summary>
        /// Enviar documento a la Dian
        /// </summary>
        /// <param name="tcrMensaje">Devuelve el mensaje de error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgDianFirmarDocumento(out string tcrMensaje)
        {
            var llgReturn = false;
            tcrMensaje = null;

            if (LlgMostrarVistaEspera == true)
            {
                LobVistaEspera = new DialogProgressBarEx();
                LobVistaEspera.Owner = LobOwner;
                LobVistaEspera.fcvProgressBarIniciar("Firmando el Documento...", "CENTRO");
                LobVistaEspera.Show();
            }

            if (TobRegDoc.Fcm_typdoc_fctd == "01") // Factura
            {
                llgReturn = FlgDianSolicitarFirmarDocumento(TipoFirma.Factura, out tcrMensaje);
            }
            if (TobRegDoc.Fcm_typdoc_fctd == "91") // Nota Credito
            {
                llgReturn = FlgDianSolicitarFirmarDocumento(TipoFirma.NotaCrédito, out tcrMensaje);
            }
            if (TobRegDoc.Fcm_typdoc_fctd == "92") // Nota Debito
            {
                llgReturn = FlgDianSolicitarFirmarDocumento(TipoFirma.NotaDébito, out tcrMensaje);
            }

            if (LobVistaEspera != null) { LobVistaEspera.Close(); }

            return llgReturn;
        }
        #endregion FlgDianFirmarDocumento
        #region FlgDianSolicitarFirmarDocumento: Solicitar Firmar el documento generado
        /// <summary>
        /// Enviar documento al proceso que realiza la firma
        /// </summary>
        /// <param name="tenTipoFirma">Tipo firma: Factura/NotaCredito/NotaDebito</param>
        /// <param name="tcrMensaje">Devuelve el mensaje de error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgDianSolicitarFirmarDocumento(TipoFirma tenTipoFirma, out string tcrMensaje)
        {
            bool llgReturn;
            var ldaFecha = TobRegDoc.Fcm_fecfac_mfac;

            if (!FlgFirmarArchivo(tenTipoFirma,
                                 ldaFecha,
                                 DocGenNombreXmlRutaSinFirma,
                                 DocGenNombreXmlRutaFirmado,
                                 out tcrMensaje))
            {
                llgReturn = false;
            }
            else
            {
                llgReturn = true;
            }

            return llgReturn;
        }
        #endregion FlgFirmarDocumento>
        #region FlgDianEnviarDocumento: Enviar el Documento a la plataforma DIAN
        /// <summary>
        /// Enviar documento a la Dian
        /// </summary>
        /// <param name="tobRespuestaXml">Devuelve las respustas XML response dadas por el servidor Dian</param>
        /// <param name="tcrMensaje">Devuelve el mensaje de error cuando este ocurra</param>
        /// <returns></returns>
        public bool FlgDianEnviarDocumento(out XmlDocument tobRespuestaXml, out string tcrMensaje)
        {
            var llgReturn = true;

            if (LlgMostrarVistaEspera == true)
            {
                LobVistaEspera = new DialogProgressBarEx();
                LobVistaEspera.Owner = LobOwner;
                LobVistaEspera.fcvProgressBarIniciar("Enviando el Documento a la DIAN...", "CENTRO");
                LobVistaEspera.Show();
            }

            if (Empresa.AmbienteFacturacionElectronica == AmbienteFacturacionElectronica.Pruebas)
            {
                if (!FlgSendTestSetAsync(DocGenNombreXmlFirmado, Empresa.RutaDocumentoFirmado,
                                                    out tcrMensaje, out tobRespuestaXml))
                {
                    llgReturn = false;
                }
            }
            else
            {
                if (!FlgEnviarSendBillSync(DocGenNombreXmlFirmado, Empresa.RutaDocumentoFirmado,
                                                    out tcrMensaje, out tobRespuestaXml))
                {
                    llgReturn = false;
                }
            }

            if (LobVistaEspera != null) { LobVistaEspera.Close(); }

            return llgReturn;
        }
        #endregion FlgDianEnviarDocumento>
        // Generar Documentos
        #region FlgDianGenerarFacturaXml: Generar documento tipo Factura
        /// <summary>
        /// Generar documento tipo Factura
        /// </summary>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianGenerarFacturaXml(out string tcrMensaje)
        {
            bool llgReturn = false;

            if (FlgGenerarDocumentoFactura(TobRegDoc, out tcrMensaje, out DocumentoFactura lobRefFact))
            {
                LobRefFact = lobRefFact;

                DocGenNombreCodigoCufe          = lobRefFact.DocGenNombreCodigoCufe;
                DocGenNombreXmlSinExtension     = lobRefFact.DocGenNombreXmlSinExtension;
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                llgReturn = true;
            }

            return llgReturn;

        }
        #endregion FlgDianGenerarFacturaXml>
        #region FlgDianGenerarNotaCreditoXml: Generar documento tipo Nota Credito
        /// <summary>
        /// Generar documento tipo Nota Credito
        /// </summary>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianGenerarNotaCreditoXml(out string tcrMensaje)
        {
            bool llgReturn = false;

            if (FlgGenerarDocumentoNotaCredito(TobRegDoc, out tcrMensaje, out DocumentoNotaCredito lobRefFact))
            {
                LobRefCred = lobRefFact;

                DocGenNombreCodigoCufe          = lobRefFact.DocGenNombreCodigoCufe;
                DocGenNombreXmlSinExtension     = lobRefFact.DocGenNombreXmlSinExtension;
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                llgReturn = true;
            }

            return llgReturn;
        } // FacturaEjemploXml>
        #endregion FlgDianGenerarNotaCreditoXml>
        #region FlgDianGenerarNotaDebitoXml: Generar documento tipo Nota Debito
        /// <summary>
        /// Generar documento tipo Nota Debito
        /// </summary>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianGenerarNotaDebitoXml(out string tcrMensaje)
        {
            bool llgReturn = false;

            if (FlgGenerarDocumentoNotaDebito(TobRegDoc, out tcrMensaje, out DocumentoNotaDebito lobRefFact))
            {
                LobRefDebi = lobRefFact;

                DocGenNombreCodigoCufe          = lobRefFact.DocGenNombreCodigoCufe;
                DocGenNombreXmlSinExtension     = lobRefFact.DocGenNombreXmlSinExtension;
                DocGenNombreXmlFirmado          = lobRefFact.DocGenNombreXmlFirmado;
                DocGenNombreXmlSinFirma         = lobRefFact.DocGenNombreXmlSinFirma;
                DocGenNombreZipFirmado          = lobRefFact.DocGenNombreZipFirmado;
                DocGenNombreXmlRutaFirmado      = lobRefFact.DocGenNombreXmlRutaFirmado;
                DocGenNombreXmlRutaSinFirma     = lobRefFact.DocGenNombreXmlRutaSinFirma;
                DocGenNombreZipRutaFirmado      = lobRefFact.DocGenNombreZipRutaFirmado;
                DocGenNombreContadorSecuencial  = lobRefFact.DocGenNombreContadorSecuencial;

                llgReturn = true;
            }

            return llgReturn;
        }
        #endregion FlgDianGenerarNotaDebitoXml>
        // Actualizar base de datos según resultados de envio documento
        #region FlgDianActualizarMaestros: Actualizar maestros con los resultados del envio
        /// <summary>
        /// Carga el response y actualiza maestros con los resultados de envio del documento a Dian
        /// </summary>
        /// <param name="tobRespuestaXml">Recibe el XML Response que se cargará</param>
        /// <param name="tobResponse">Objeto response para tomar los datos de estado y actualizar en maestros</param>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianActualizarMaestros(XmlDocument tobRespuestaXml, out DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgReturn = false;

            if (!FlgCargarDianResponse(tobRespuestaXml, out tobResponse, out tcrMensaje))
            {
                llgReturn = false; // no se pudo extraer datos del response (es un formato que no corresponde)
                tcrMensaje = "No se pudo leer la respusta desde el servicio DIAN";
            }
            else
            {
                if (tobResponse.TipoResponse != "NA") // es un response valido como proceso gestion documento
                {
                    // Desde cuentas de cobro
                    if (TobRegDoc.Fcm_facori_mfac == "01")
                    {
                        llgReturn = FlgDianCuentaActualziarDatosEnvio(tobResponse, out tcrMensaje);
                    }
                    // Desde Facturacion Medica
                    if (TobRegDoc.Fcm_facori_mfac == "03")
                    {
                        llgReturn = FlgDianFactMedicaActualziarDatosEnvio(tobResponse, out tcrMensaje);
                    }
                }
            }
            return llgReturn;
        }
        #endregion FlgDianCuentaActualizarMaestros>
        #region FlgDianCuentaActualziarDatosEnvio: Actualizar maestros con los resultados del envio
        /// <summary>
        /// Actualizar maestros con los resultados del envio del documento a Dian
        /// </summary>
        /// <param name="tobResponse">objeto response para tomar los datos de estado y actualizar en maestros</param>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianCuentaActualziarDatosEnvio(DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgReturn = false;
            tcrMensaje = null;
            // Tomar los parametros genrados y el ZipKey y guardar en base de datos
            var lobReg = new ModeloFeFacturaMa();
            lobReg.Fcm_secreg_mfac = TobRegDoc.Fcm_secreg_mfac; // para llave de busqueda
            lobReg.Fcm_idcufe_mfac = DocGenNombreCodigoCufe;
            lobReg.Fcm_nomarc_mfac = DocGenNombreXmlSinExtension;
            lobReg.Fcm_trakid_mfac = tobResponse.ZipKey;
            lobReg.Fcm_errore_mfac = tobResponse.ErrorMessage;
            lobReg.Fcm_diafec_mfac = GestFechaEnvioDian;
            lobReg.Fcm_diahor_mfac = GestHoraEnvioDian;
            lobReg.Fcm_codest_fcws = tobResponse.EstadoGestion;

            if (ModeloFeFacturaMa.FlgActualizarParametros(lobReg, out tcrMensaje))
            {
                llgReturn = true;
                var lobRegCar = new ModeloCarGenFactDian();
                lobRegCar.Car_secfac_camf = TobRegDoc.Fcm_secreg_mfac;
                lobRegCar.Fcm_codest_fcws = tobResponse.EstadoGestion;
                ModeloCarGenFactDian.FlgActualizarParametros(lobRegCar, out tcrMensaje);
            }

            return llgReturn;
        }
        #endregion FlgDianCuentaActualziarDatosEnvio
        #region FlgDianFactMedicaActualziarDatosEnvio: Actualizar maestros con los resultados del envio
        /// <summary>
        /// Actualizar maestros facturacion medica y facturas Dian con resultados del envio documento a Dian
        /// </summary>
        /// <param name="tobResponse">objeto response para tomar los datos de estado y actualizar en maestros</param>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianFactMedicaActualziarDatosEnvio(DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgReturn = false;
            tcrMensaje = null;
            // Tomar los parametros genrados y el ZipKey y guardar en base de datos
            var lobReg = new ModeloFeFacturaMa();
            lobReg.Fcm_secreg_mfac = TobRegDoc.Fcm_secreg_mfac; // para llave de busqueda
            lobReg.Fcm_idcufe_mfac = DocGenNombreCodigoCufe;
            lobReg.Fcm_nomarc_mfac = DocGenNombreXmlSinExtension;
            lobReg.Fcm_trakid_mfac = tobResponse.ZipKey;
            lobReg.Fcm_errore_mfac = tobResponse.ErrorMessage;
            lobReg.Fcm_diafec_mfac = GestFechaEnvioDian;
            lobReg.Fcm_diahor_mfac = GestHoraEnvioDian;
            lobReg.Fcm_codest_fcws = tobResponse.EstadoGestion;

            if (ModeloFeFacturaMa.FlgActualizarParametros(lobReg, out tcrMensaje))
            {
                llgReturn = true;
                var lobRegFac = new FcmModeloMaestrofacturas();
                lobRegFac.Fcm_secreg_mfac = TobRegDoc.Fcm_secreg_mfac;
                lobRegFac.Fcm_codest_fcws = tobResponse.EstadoGestion;
                FcmModeloMaestrofacturas.FlgActualizarParametros(lobRegFac, out tcrMensaje);
            }

            return llgReturn;
        }
        #endregion FlgDianCuentaActualziarDatosEnvio
    }
}

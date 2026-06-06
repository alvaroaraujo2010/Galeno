using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.Collections.Generic;
using System.Xml.Serialization;

using Sistema.Modelo;
using static Sistema.Dian.Global;
using static Sistema.Dian.General;
using static Sistema.Dian.ParametrosDian;
using static Sistema.Dian.Utilidades;
using System.Windows.Documents;
using Sistema.Utilidades;

namespace Sistema.Dian
{
    #pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
    #pragma warning disable CS8618

    /// <summary>
    /// Inicia la clase base para generar el tipo docuemto Attached (adjunto)
    /// </summary>
    public class DocumentoAttached
    {
        #region Propiedades

        #region Propiedades Generales
        public string Observaciones { get; set; }

        //public TipoDocumentoElectronico Tipo { get; set; } = TipoDocumentoElectronico.FacturaVenta;

        public ModeloSismaesterceros lobRegCliente { get; set; } // Cliente real 

        public TipoFirma TipoFirma { get; set; } = TipoFirma.Attached;

        //public string TextoTipo { get; set; } = "AT";

        public string CódigoFacturaContingencia { get; set; }

        public DateTime? FechaFacturaContingencia { get; set; }

        /// <summary>
        /// Para saber si se genera CUFE = true / CUDE = false
        /// </summary>
        public bool llgEsCufe { get; set; } = true;

        /// <summary>
        /// Código Único de Documento Electrónico.
        /// </summary>
        public string Cude { get; set; }

        public string Cufe { get; set; }

        //public string CudeEfectivo => (Cufe ?? Cude); // En el constructor se asegura que al menos uno no es nulo.
        public string CudeEfectivo { get; set; } // En el constructor se asegura que al menos uno no es nulo.

        public decimal Anticipo { get; set; }

        #endregion Propiedades Generales>

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

        #endregion Propiedades>

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DocumentoAttached()
        {
            //llgEsCufe = FlgEsCufe(Tipo);
            TipoFirma = TipoFirma.Attached;

            //RutaDocumentosElectrónicosHoy = ObtenerRutaDocumentosElectrónicosDeHoy();
        }
        #endregion Constructores>

        /// <summary>
        /// Funcion principal para generar documento en formato XML
        /// </summary>
        public bool FlgCrearDocumento(ModeloFeFacturaMa toboRegFactura, 
                                      ParamDocAttachment tobParamDocument, 
                                      out string mensaje)
        {
            // Variables Auxiliares
            #region Variables Auxiliares

            mensaje = null;
            var llgReturn      = true;
            var lcrFormatoHora = $"HH:mm:ss{HorasAjusteUtc.ATexto("00")}:00";

            // Datos de la factura
            //var lcrNumeroDocuemento      = toboRegFactura.Fcm_numfac_mfac;
            var lcrRegNroDoc = SysModeloFacturaDian.FobGenerarNumeroDocumento("AT",
                                                                              toboRegFactura.Fcm_secres_srfa,
                                                                              toboRegFactura.Fcm_secraz_fcem);
            var lcrNumeroDocuemento = lcrRegNroDoc.NuevoNumeroFactura;

            // var lnuFacturaTotalRegistros = toboRegFactura.tmpListVenta.Count;
            //var lcrFacturaFechaHora        = Funciones.FdaConcatenarFechaYHora(toboRegFactura.Fcm_fecfac_mfac, toboRegFactura.Fcm_horfac_mfac);
            var lcrDocumentoFechaHora      = Funciones.FdaConcatenarFechaYHora(Funciones.FdaFechaActual(), Funciones.FdeHoraActualMilitar());

            lobRegCliente                  = toboRegFactura.lobRegCliente;
            //TextoTipo                    = FcrSeleccionInvoiceTypeCode(Tipo);

            CudeEfectivo = toboRegFactura.Fcm_idcufe_mfac;
            DocGenNombreCodigoCufe = CudeEfectivo;

            #endregion Variables Auxiliares>

            // Objetos Reusables
            #region Objetos Reusables
            // El código que se muestra en comentarios es el de su primera aparición.

            var companyIDFacturador = new CompanyIDType
            {
                Value = Validar(Empresa.Nit, "5..12"), // 1..1 FAJ21.
                schemeAgencyID = AgenciaID195, // 0..1 FAJ22.
                schemeAgencyName = NombreAgenciaDian, // 0..1 FAJ23.
                schemeID = Empresa.DigitoVerificacionNit, // 1..1 FAJ24.
                schemeName = Empresa.TipoNit, // 0..1 FAJ25.
                //schemeName = TipoDocIdentificacion.Nit.AValor(), // 0..1 FAJ25.
            };

            var companyIDCliente = new CompanyIDType
            {
                //Value = Validar(lcrDatosCliente.NitLegalEfectivo, "5..12"), // 1..1 FAK21.
                Value = Validar(lobRegCliente.Sis_FactEleNitAdquirente, "5..12"), // 1..1 FAK21.
                schemeAgencyID = AgenciaID195, // 1..1 FAK22.
                schemeAgencyName = NombreAgenciaDian, // 1..1 FAK23.
                schemeID = toboRegFactura.lobRegCliente.Sis_FactEleDigitoVerificNit, // 0..1 FAK24.
                schemeName = toboRegFactura.lobRegCliente.TipoNit // 1..1 FAK25.
            };

            var registrationNameCliente = new RegistrationNameType { Value = Validar(lobRegCliente.Sis_FactEleRazonSocial, "5..450", true) }; // 1..1 FAK43.

            var registrationNameFacturador = new RegistrationNameType { Value = Validar(Empresa.RazonSocial, "5..450", true) };

            #endregion Objetos Reusables>

            //*************************************************
            // INICIO NODO PRINCIPAL
            //*************************************************
            //var invoice = new AttachedDocumentType { UBLExtensions = new UBLExtensionType[2] }; // 1..1 FAA01. 1..1 FAA02. 
            var invoice = new AttachedDocumentType {}; 

            //*************************************************
            // ENCABEZADO FACTURA
            //*************************************************
            #region Encabezado Factura

            invoice.UBLVersionID = new UBLVersionIDType { Value = Validar(VersionUBL, "7..8") }; // 7..8 AE02.
            invoice.CustomizationID = new CustomizationIDType { Value = Validar(CustomizationID, "1..20") }; // 1..20 AE03. 
            invoice.ProfileID = new ProfileIDType { Value = NombreYVersionFacturaElectronica }; // 1..55 AE04. Versión del Formato: Indicar versión del documento.
            invoice.ProfileExecutionID = new ProfileExecutionIDType { Value = Empresa.AmbienteFacturacionElectronica.AValor() }; // 1..1 AE04a Código que describe el “ambiente de destino donde será procesada la validación previa de este documento electrónico”
            invoice.ID = new IDType { Value = Validar(lcrNumeroDocuemento, "1..20") }; // 1..1 AE04b.- Consecutivo propio del generador del documento
            invoice.IssueDate    = new IssueDateType { Value = lcrDocumentoFechaHora }; // 1..1 AE05. Fecha de generación del contenedor
            invoice.IssueTime    = new IssueTimeType { Value = lcrDocumentoFechaHora.ATexto(lcrFormatoHora) }; // 1..1 AE06. Hora de generación del contenedor
            invoice.DocumentType = new DocumentTypeType { Value = DocumentType }; // 1..1 AE08. Tipo de documento
            invoice.ParentDocumentID = new ParentDocumentIDType { Value = toboRegFactura.Fcm_numfac_mfac }; // 1..1 AE08a. ID del documento soporte que origina el contenedor

            #endregion Encabezado Factura>

            //*************************************************
            // DATOS FACTURADOR
            //*************************************************
            #region Datos Facturador

            var supplierParty = new PartyType
            {
                PartyTaxScheme = new PartyTaxSchemeType[1] { // 1..1 AE10 - Grupo de información tributaria del generador del documento.
                    new PartyTaxSchemeType {
                        RegistrationName = registrationNameFacturador,  // 1..1 AE11 - Nombre o Razón Social del generador del documento.
                        CompanyID = companyIDFacturador,                // AE12 - NIT del generador del documento
                        TaxLevelCode = new TaxLevelCodeType {

                            Value = Validar(Empresa.ResponsabelFiscal, "1..30", true), // 1..1 CAJ26. El tamaño la documentación dice 30 único pero ese valor no tiene sentido. Se usará 1..30.
                            listName = Empresa.TipoContribuyente, // Supuestamente CAJ27 es un elemento opcional, pero el servidor de la DIAN si lo exige. Se encontró que se debe usar 48 o 49 dependiendo de si es o no responsable de IVA aquí http://facturasyrespuestas.com/2225/inquietud-campo-taxlevelcode. Estos valores se pueden ver en el numeral 16.1.6. Modificación del anexo técnico (06-09-2019) de la documentación.

                        },
                        TaxScheme = new TaxSchemeType { // 1..1 CAJ39.

                            ID = new IDType { Value = Validar("01", "2..10") }, // 1..1 CAJ40. Aunque la documentación dice tamaño 3..10 esto va en contradicción con el código "01" o "04" se usa 2..10. La documentación dice usar los valores de la tabla 13.2.6.2 pero a la vez restringe los valores a 01 o 04 sin especificar que se debe hacer en los casos de IVA y INC, por esto se usa el parámetro forzar01 = true en el que si es IVA e INC se devuelve el valor de IVA = 01.
                            Name = new NameType1 { Value = Validar("IVA", "3..30") } // 1..1 CAJ41. Aunque la documentación dice tamaño 10..30 esto va en contradicción con el tamaño de "IVA", se usa 3..30.

                        },
                    }
                }
            }; // 1..1 AE09 - Persona que genera el contenedor.
            invoice.SenderParty = supplierParty;
            #endregion Datos Facturador>

            //*************************************************
            // DATOS DEL CLIENTE 
            //*************************************************
            #region Datos Cliente

            var receiverParty = new PartyType // 1..1  AE21 - Persona que recibe el contenedor
            {
                PartyTaxScheme = new PartyTaxSchemeType[1] { // 1..1 AE22 - Grupo de información tributaria.
                    new PartyTaxSchemeType {
                        RegistrationName = registrationNameCliente,  // 1..1 AE23 - Nombre o Razón social del receptor.
                        CompanyID = companyIDCliente,                // AE24 - NIT del receptor del documento
                        TaxLevelCode = new TaxLevelCodeType { // 1..1 AE28 - Diligenciar de acuerdo a la tabla 11.2.5.1

                            Value = Validar("R-99-PN", "1..30"), // 1..1 AE28. Diligenciar de acuerdo a la tabla 11.2.5.1
                            listName = "48",

                        },
                        TaxScheme = new TaxSchemeType { // 1..1 AE30 - Usar valores de la tabla 11.2.5.2.

                            ID = new IDType { Value = Validar("01", "2..10") }, // 1..1 AE31. Usar valores de la tabla 11.2.5.2
                            Name = new NameType1 { Value = Validar("IVA", "3..30") } // 1..1 AE32. Usar valores de la tabla 11.2.5.2

                        },
                    }
                }
            }; // 1..1 AE21 - Persona que recibe el contenedor.
            invoice.ReceiverParty = receiverParty;

            #endregion Datos Cliente>

            //*************************************************
            // Attachment - DATOS DEL DOCUMENTO
            //*************************************************
            #region Attachment: Datos del documento enviado en el contenedor

            var attachment = new AttachmentType // 1..1  AE33 - Información del Documento Electrónico (Documento Soporte) enviado en el contenedor. La información del AppResponse está más abajo
            {
                ExternalReference = new ExternalReferenceType // 1..1 AE34 - ExternalReference
                { 
                    MimeCode = new MimeCodeType { Value = Validar(MimeCode, "1..20") },  // 1..1 AE35 - Tipo mime utilizado para el envío, debe ser text/xml
                    EncodingCode = new EncodingCodeType { Value = "UTF-8" },  // 1..1 AE36 - Formato envio debe ser "UTF-8"
                    Description = new DescriptionType[] { // 1..1 AE37 - Acá se coloca el DDS en formato xml.
                      new DescriptionType { 
                          //Value = "<![CDATA[" + tobParamDocument.AttachmentDocument + "]]>"
                          Value = "-DOCUMENTO-"
                      }
                    }, 
                },
            }; 
            invoice.Attachment = attachment;

            #endregion Attachment: Datos del documento>

            //*************************************************
            // ParentDocumentLineReference - DATOS RESPONSE
            //*************************************************
            #region ParentDocumentLineReference: Datos del Response DIAN

            var parentDocumentLineReference = new LineReferenceType[] // 1..1  AE38 - Referencia al Response - Puede referenciar 1 documento a la vez
            {
                new LineReferenceType{

                    LineID = new LineIDType{ Value = "1"}, // 1..1  AE39 - Consecutivo para informar el documento
                    DocumentReference = new DocumentReferenceType // 1..1 AE40 - DocumentReference
                    {
                        ID = new IDType { Value = toboRegFactura.Fcm_numfac_mfac },  // 1..1 AE41 - Número del DDS
                        UUID = new UUIDType {  // 1..1 AE42 - CUDE/CUFE del DDS
                            Value = CudeEfectivo,
                            schemeName = "CUDE‐SHA384", // 1..1 AE43 - CUDE‐SHA384
                        },
                        IssueDate = new IssueDateType { Value = tobParamDocument.IssueDate }, // 1..1 AE44 - Fecha de generación de la respuesta
                        DocumentType = new DocumentTypeType { Value = "ApplicationResponse" }, // 1..1 AE45 - Tipo de documento

                        // Datos del Response
                        Attachment = new AttachmentType { // 1..1 AE46 - Para informar el ApplicationResponse

                            ExternalReference = new ExternalReferenceType { // 1..1 AE47 -ExternalReference

                                MimeCode = new MimeCodeType { Value = Validar(MimeCode, "1..20") },  // 1..1 AE48 - Tipo mime utilizado para el envío, debe ser text/xml
                                EncodingCode = new EncodingCodeType { Value = "UTF-8" },  // 1..1 AE49 - Formato envio debe ser "UTF-8"

                                Description = new DescriptionType[] { // 1..1 AE50 - Acá se coloca el ApplicationResponse en formato.
                                  new DescriptionType {
                                      //Value = "<![CDATA[" + tobParamDocument.AttachmentResponse + "]]>"
                                      Value = "-ApplicationResponse-"
                                  }
                                },
                            },
                        },

                        // 1..1 AE51 - Resultado de verificación
                        ResultOfVerification = new ResultOfVerificationType
                        {
                            ValidatorID = new ValidatorIDType { Value = NombreAgenciaDianValidacion },
                            ValidationResultCode = new ValidationResultCodeType{ Value = "01" },
                            ValidationDate = new ValidationDateType { Value = tobParamDocument.IssueDate },
                            ValidationTime = new ValidationTimeType { Value = tobParamDocument.IssueTime }
                        }
                    },
                },
            };
            invoice.ParentDocumentLineReference = parentDocumentLineReference;
            #endregion ParentDocumentLineReference>

            //*************************************************
            // ESCRITURA DEL XML
            //*************************************************
            #region Escritura XML

            // Generar rutas y nombrees de archivos fisicos firmados y sin firma
            FcvGenNombreYRutaArchivos();

            var espaciosNombres = new XmlSerializerNamespaces();
            espaciosNombres.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
            espaciosNombres.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            espaciosNombres.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            espaciosNombres.Add("ccts", "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2");
            espaciosNombres.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            espaciosNombres.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            espaciosNombres.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            //espaciosNombres.Add("schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:AttachedDocument-2     " + "http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-CreditNote-2.1.xsd");

            var serializadorXml = new XmlSerializer(typeof(AttachedDocumentType), new Type[] {
                typeof(ExtensionContentDianType), typeof(ExtensionContentFirmaType)
            });

            var flujoEscritura = new StreamWriter(DocGenNombreXmlRutaSinFirma);
            var escritorXml = new XmlTextWriterSinXsi(flujoEscritura); // Para omitir los atributos automáticamente añadidos con nombre ExtensionContentFirmaType y ExtensionContentDianType.
            serializadorXml.Serialize(escritorXml, invoice, espaciosNombres);
            flujoEscritura.Close();
            #endregion Escritura XML>

            //*************************************************
            // fin del proceso
            //*************************************************
            return llgReturn;
        }

        #region Funciones Varias

        #region Generar nombre archivo
        /// <summary>
        /// Generar los nombres y rutas de gestion para el proceso 
        /// </summary>
        public void FcvGenNombreYRutaArchivos()
        {
            DocGenNombreXmlSinExtension = FcrGenNombreArchivoSegunTipo(TipoFirma, tlgFirmado: true, false);
            DocGenNombreXmlFirmado      = FcrGenNombreArchivoSegunTipo(TipoFirma, tlgFirmado: true);
            DocGenNombreXmlSinFirma     = FcrGenNombreArchivoSegunTipo(TipoFirma, tlgFirmado: false);
            DocGenNombreZipFirmado      = DocGenNombreXmlFirmado.Reemplazar("xml", "zip");

            DocGenNombreXmlRutaFirmado  = FcrGenArchivoNombreYRutaDestino(TipoFirma, tlgFirmado: true);
            DocGenNombreXmlRutaSinFirma = FcrGenArchivoNombreYRutaDestino(TipoFirma, tlgFirmado: false);
            DocGenNombreZipRutaFirmado  = DocGenNombreXmlRutaFirmado.Reemplazar("xml", "zip");

            DocGenNombreContadorSecuencial = Empresa.ConsecutivoDianAnual;

        }
        #endregion Generar nombre archivo
        #region CrearZip: Generar el archivo comprimido
        /// <summary>
        /// Útil cuando se están realizando pruebas con SoapUI.
        /// </summary>
        /// <returns></returns>
        public bool CrearZip()
        {
            if (DocGenNombreXmlRutaFirmado == null) throw new Exception("No se esperaba que la ruta estuviera nula. Ejecuta primero Crear().");
            General.CrearZip(DocGenNombreXmlRutaFirmado);
            return true;

        } // CrearZip>
        #endregion CrearZip: Generar el archivo comprimido>

        #endregion Funciones Varias

    }

    #pragma warning disable CS8618
    #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

}

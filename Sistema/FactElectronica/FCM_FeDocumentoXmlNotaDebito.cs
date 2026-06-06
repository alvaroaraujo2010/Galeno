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
    /// Inicia la clase base para generar el tipo docuemto factura eletronica
    /// </summary>
    public class DocumentoNotaDebito
    {
        #region Propiedades

        #region Propiedades Generales
        public string Observaciones { get; set; }

        public TipoDocumentoElectronico Tipo { get; set; } = TipoDocumentoElectronico.NotaDebito;

        public ModeloSismaesterceros lobRegCliente { get; set; } // Cliente real 

        public TipoFirma TipoFirma { get; set; } = TipoFirma.NotaDébito;

        public string TextoTipo { get; set; } = "92";

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
        public DocumentoNotaDebito()
        {
            llgEsCufe = FlgEsCufe(Tipo);
            TipoFirma = FenSelectTipoFirma(Tipo);

            //RutaDocumentosElectrónicosHoy = ObtenerRutaDocumentosElectrónicosDeHoy();
        }
        #endregion Constructores>

        /// <summary>
        /// Funcion principal para generar la factura en formato XML
        /// </summary>
        public bool FlgCrearDocumento(ModeloFeFacturaMa toboRegFactura, out string mensaje)
        {
            // Variables Auxiliares
            #region Variables Auxiliares

            mensaje = null;
            var llgReturn = true;
            var lcrMoneda = Empresa.MunicipioFacturacion.Moneda;
            var lcrFormatoHora = $"HH:mm:ss{HorasAjusteUtc.ATexto("00")}:00";

            // Datos de la factura
            var lcrFacturaNumero = toboRegFactura.Fcm_numfac_mfac;
            var lnuFacturaTotalRegistros = toboRegFactura.tmpListVenta.Count;
            var lcrFacturaFechaHora = Funciones.FdaConcatenarFechaYHora(toboRegFactura.Fcm_fecfac_mfac, toboRegFactura.Fcm_horfac_mfac);

            var lcrFacturaFechaVencimiento = toboRegFactura.Fcm_fecven_mfac;
            lobRegCliente = toboRegFactura.lobRegCliente;
            TextoTipo = FcrSeleccionInvoiceTypeCode(Tipo);

            CudeEfectivo = FcrGenerarCude(toboRegFactura, llgEsCufe);
            DocGenNombreCodigoCufe = CudeEfectivo;

            // referencia a la factura que genera la nota credito
            var lobRegRefFact = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefmaEx("ID", toboRegFactura.Fcm_serdeb_mfac);

            #endregion Variables Auxiliares>

            // Funciones Locales
            #region Funciones Locales - El código que se muestra en comentarios es el de su primera aparición.

            string obtenerCódigoSeguridad() => ObtenerSHA384($"{Empresa.IdentificadorAplicación}{Empresa.PinAplicación}{lcrFacturaNumero}");  // También llamada Huella, aunque antes era única para la aplicación ya no lo es porque depende también del número del documento.

            AddressType obtenerAddress(string tcrDireccion, Municipio tobRegMunicipio)
            {

                if (tcrDireccion == null) return null;

                //var municipio = direcciónCompleta.Municipio;
                if (tobRegMunicipio == null || tobRegMunicipio.CodigoPais == null || tobRegMunicipio.CodigoLenguajePais == null || tobRegMunicipio.CodigoMunicipio == null) return null; // Si no se conoce el país, el lenguaje del país o el código del municipio no se agregará el Address. Este elemento no siempre es obligatorio.

                return new AddressType
                { // 1..1 DAJ08.
                    ID = new IDType { Value = Validar(tobRegMunicipio.IDMunicipio, "5") }, // 1..1 DAJ09.
                    CityName = new CityNameType { Value = Validar(tobRegMunicipio.NombreMunicipio, "1..60", true) }, // 1..1 DAJ10.
                    // PostalZone = , // 0..1 DAJ73 T1..10. Código postal. Ver lista de valores posibles en el numeral 13.4.4. Por lo general no se tiene ni se usa.
                    CountrySubentity = new CountrySubentityType { Value = Validar(tobRegMunicipio.NombreDepartamento, "1..60", true) }, // 1..1 DAJ11.
                    CountrySubentityCode = new CountrySubentityCodeType { Value = Validar(tobRegMunicipio.CodigoDepartamento, "1..5") }, // 1..1 DAJ12.
                    AddressLine = new AddressLineType[1] { // 1..N DAJ13.
                    new AddressLineType { Line = new LineType { Value = Validar(tcrDireccion ?? " ", "1..300", true) } } // 1..1 DAJ14. Elemento de texto libre, que el emisor puede elegir utilizar para poner toda la información de su dirección, en lugar de utilizar elementos estructurados (los demás elementos de este grupo). Informar la dirección, sin ciudad ni departamento. Estos dos textos de la documentación de la DIAN son contradictorios entonces se escribirá la dirección en este campo y se completarán los otros normalmente. Debido a que es un elemento obligatorio de largo 1 si por alguna razón no se dispone de la dirección se enviará un espacio en blanco.
                },
                    Country = new CountryType
                    { // 1..1 DAJ15.
                        IdentificationCode = new IdentificationCodeType { Value = Validar(tobRegMunicipio.CodigoPais, "1..3") }, // 1..1 DAJ16. Debe informar literal "CO". El tamaño en la documentación dice 3 pero no puede ser 3, debe ser flexible para no contradecir el requerimiento de poner "CO".
                        Name = new NameType1
                        {
                            Value = Validar(tobRegMunicipio.NombrePais, "4..41", true), // 0..1 DAJ17. Debe informar el literal "Colombia".
                            languageID = Validar(tobRegMunicipio.CodigoLenguajePais, "2"), // 0..1 DAJ18.
                        },
                    },
                };

            } // ObtenerAddress>

            #endregion Funciones Locales>

            // Objetos Reusables
            #region Objetos Reusables
            // El código que se muestra en comentarios es el de su primera aparición.

            var companyIDFacturador = new CompanyIDType
            {
                Value = Validar(Empresa.Nit, "5..12"), // 1..1 DAJ21.
                schemeAgencyID = AgenciaID195, // 0..1 DAJ22.
                schemeAgencyName = NombreAgenciaDian, // 0..1 DAJ23.
                schemeID = Empresa.DigitoVerificacionNit, // 1..1 DAJ24.
                schemeName = Empresa.TipoNit, // 0..1 FAJ25.
                //schemeName = TipoDocIdentificacion.Nit.AValor(), // 0..1 DAJ25.
            };

            var companyIDCliente = new CompanyIDType
            {
                //Value = Validar(lcrDatosCliente.NitLegalEfectivo, "5..12"), // 1..1 DAK21.
                Value = Validar(lobRegCliente.Sis_FactEleNitAdquirente, "5..12"), // 1..1 DAK21.
                schemeAgencyID = AgenciaID195, // 1..1 DAK22.
                schemeAgencyName = NombreAgenciaDian, // 1..1 DAK23.
                schemeID = toboRegFactura.lobRegCliente.Sis_FactEleDigitoVerificNit, // 0..1 DAK24.
                schemeName = toboRegFactura.lobRegCliente.TipoNit // 1..1 DAK25.
            };

            var registrationNameCliente = new RegistrationNameType { Value = Validar(lobRegCliente.Sis_FactEleRazonSocial, "5..450", true) }; // 1..1 DAK43.

            var registrationNameFacturador = new RegistrationNameType { Value = Validar(Empresa.RazonSocial, "5..450", true) };

            #endregion Objetos Reusables>

            //*************************************************
            // INICIO NODO PRINCIPAL
            //*************************************************
            var invoice = new DebitNoteType { UBLExtensions = new UBLExtensionType[2] }; // 1..1 DAA01. 1..1 DAA02. 

            //*************************************************
            // EXTENCION DIAN
            //*************************************************
            #region Extensión DIAN

            var ublExtension1 = new UBLExtensionType(); // 1 de 2..N DAA01.    
            var extensionContentDian = new ExtensionContentDianType(); // 1..1 DAA01.
            ublExtension1.ExtensionContent = extensionContentDian;
            #pragma warning disable IDE0017 // Simplificar la inicialización de objetos. La sugerencia de crear un arbol de iniciación de dianExtensions produce un código complicado de depurar.
            var dianExtensions = new DianExtensionsType(); // 1..1 DAB03.
            #pragma warning restore IDE0017

            dianExtensions.InvoiceSource = new CountryType
            { // 1..1 CAB14.
                IdentificationCode = new IdentificationCodeType
                {
                    Value = Empresa.MunicipioFacturacion.CodigoPais, // 1..1 CFAB14.
                    listAgencyID = AgenciaIdentificaciónPaísID, // 1..1 CAB15.
                    listAgencyName = AgenciaIdentificaciónPaís, // 1..1 CAB16.
                    listSchemeURI = UriEsquemaIdentificacionPais // 1..1 CAB17.
                }
            };

            dianExtensions.SoftwareProvider = new SoftwareProvider
            { // 1..1 CAB19a.
                ProviderID = new coID2Type
                {
                    Value = Empresa.Nit, // 1..1 CAB19.
                    schemeAgencyID = AgenciaID195, // 1..1 CAB20.
                    schemeAgencyName = NombreAgenciaDian, // 1..1 CAB21.
                    schemeID = Empresa.DigitoVerificacionNit, // 1..1 CAB22.
                    schemeName = TipoDocIdentificacion.Nit.AValor(), // 1..1 CAB23.
                },
                SoftwareID = new IdentifierType1
                {
                    Value = Empresa.IdentificadorAplicación, // 1..1 CAB24.
                    schemeAgencyID = AgenciaID195, // 1..1 CAB25.
                    schemeAgencyName = NombreAgenciaDian, // 1..1 CAB26.     
                }
            };

            dianExtensions.SoftwareSecurityCode = new IdentifierType1
            {
                Value = Validar(obtenerCódigoSeguridad(), "96"), // 1..1 CAB27. En la documentación dice que el tamaño debe ser 48 pero la función devuelve un texto de 96 que coincide con los ejemplos en los XMLs, se deja en 96.
                schemeAgencyID = AgenciaID195, // 1..1 CAB28.
                schemeAgencyName = NombreAgenciaDian, // 1..1 CAB29.
            };

            dianExtensions.AuthorizationProvider = new AuthorizationProvider
            { // 1..1 CAB30.
                AuthorizationProviderID = new coID2Type
                {
                    Value = Validar(NitDian, "9"), // 1..1 CAB31.
                    schemeAgencyID = AgenciaID195, // 1..1 CAB32.
                    schemeAgencyName = NombreAgenciaDian, // 1..1 CAB33.
                    schemeID = DigitoVerificacionNitDian, // 1..1 CAB34
                    schemeName = TipoDocIdentificacion.Nit.AValor(), // 1..1 CAB35.
                }
            };

            dianExtensions.QRCode = FcrGenerarCodigoQR(toboRegFactura, CudeEfectivo, out _); // 1..1 CAB36.

            extensionContentDian.DianExtensions = dianExtensions; // Al no encontrar una clase ExtensionContent en el XSD de la DIAN se genera manualmente. Pendiente verificar si funciona o si se debe hacer algo diferente.  
            invoice.UBLExtensions[0] = ublExtension1;

            #endregion Extensión DIAN>

            //*************************************************
            // EXTENCION FIRMA
            //*************************************************
            #region Extensión Firma

            var ublExtension2 = new UBLExtensionType(); // 2 de 2..N DAC01.
            var extensionContentFirma = new ExtensionContentFirmaType(); // 1..1 DAC02.
            ublExtension2.ExtensionContent = extensionContentFirma;
            invoice.UBLExtensions[1] = ublExtension2;

            #endregion Extensión Firma>

            //*************************************************
            // ENCABEZADO FACTURA
            //*************************************************
            #region Encabezado Factura

            invoice.UBLVersionID = new UBLVersionIDType { Value = Validar(VersionUBL, "7..8") }; // 1..1 DAD01.
            invoice.CustomizationID = new CustomizationIDType { Value = Validar(ObtenerCódigoTipoOperación(Tipo), "1..4") }; // 1..1 DAD02. 
            invoice.ProfileID = new ProfileIDType { Value = NombreYVersionNotaDebito }; // 1..1 DAD03. Según la documentación debería tener una longitud de 55 única pero el texto que dice en la documentación "Dian 2.1 Factura Electrónica de Venta" y el texto realmente exigido por el servicio web "Dian 2.1" contradicen esa restricción entonces no se validará su largo.
            invoice.ProfileExecutionID = new ProfileExecutionIDType { Value = Empresa.AmbienteFacturacionElectronica.AValor() }; // 1..1 CAD04.
            invoice.ID = new IDType { Value = Validar(lcrFacturaNumero, "1..20") }; // 1..1 DAD05.- Numero del documento (factura autorizada DIAN)

            invoice.UUID = new UUIDType
            {
                Value = Validar(CudeEfectivo, "96"), // 1..1 DAD06.
                schemeID = Empresa.AmbienteFacturacionElectronica.AValor(), // 1..1 DAD07.
                schemeName = Validar(AlgoritmoCude, "11"), // 1..1 DAD08.
            };

            invoice.IssueDate = new IssueDateType { Value = lcrFacturaFechaHora }; // 1..1 DAD09. Fecha emision del la Factura
            invoice.IssueTime = new IssueTimeType { Value = lcrFacturaFechaHora.ATexto(lcrFormatoHora) }; // 1..1 DAD10.

            //if (venta != null && venta.FechaVencimiento != null) invoice.DueDate = new DueDateType { Value = (DateTime)venta.FechaVencimiento }; // 0..1 FAD11.
            //if (lcrFacturaFechaVencimiento != null) invoice.DueDate = new DueDateType { Value = lcrFacturaFechaVencimiento }; // 0..1 FAD11.

            //invoice.CreditNoteTypeCode = new CreditNoteTypeCodeType { Value = TextoTipo }; // 1..1 DAD12. parece que la nota debito no lleva el correspondiente
            invoice.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = Validar(lcrMoneda, "3") }; // 1..1 DAD15 (En la documentación se saltan la FAD14)..
            invoice.LineCountNumeric = new LineCountNumericType { Value = Validar(lnuFacturaTotalRegistros, "1..6") }; // 1..1 DAD16.

            // DBF01 Se debe diligenciar únicamente cuando la FE se origina a partir de la correcció o ajuste que se da mediante un NC (nota credito)
            invoice.DiscrepancyResponse = new ResponseType[1];
            var lcrDiscrepancyResponse = new ResponseType
            {
                //ReferenceID =  new ReferenceIDType { Value = toboRegFactura.Fcm_idrcre_mfac },
                ResponseCode = new ResponseCodeType { Value = "1" },
            };
            invoice.DiscrepancyResponse[0] = lcrDiscrepancyResponse;
            
            #region BillingReference 
            // DBG01 - Referencia a la factura que genera la nota credito
            invoice.BillingReference = new BillingReferenceType[1];
            var lobBillingReference = new BillingReferenceType
            { // 1..1 DBG02.
                InvoiceDocumentReference = new DocumentReferenceType
                {
                    ID = new IDType { Value = Validar(lobRegRefFact.Fcm_numfac_mfac, "1..10") }, // 1..1 DBG03. En la documentación la restricción por tamaño es 10. Pero no tiene mucho sentido esta restricción porque siempre podrían ser más cortas entonces se usa 1..10.
                    UUID = new UUIDType
                    {
                        Value = Validar(lobRegRefFact.Fcm_idcufe_mfac, "96"), // 1..1 DBG04.
                        schemeName = Validar(AlgoritmoCufe, "11"), // 1..1 DBG05.
                    },
                    IssueDate = new IssueDateType { Value = lobRegRefFact.Fcm_fecfac_mfac }, // 0..1 DBG06.
                },
            };
            invoice.BillingReference[0] = lobBillingReference;
            
            #endregion BillingReference>

            #endregion Encabezado Factura>

            //*************************************************
            // DATOS FACTURADOR
            //*************************************************
            #region Datos Facturador

            var accountingSupplierParty = new SupplierPartyType()
            { // 1..1 DAJ01.
                AdditionalAccountID = new AdditionalAccountIDType[1] { new AdditionalAccountIDType { Value = Empresa.TipoEntidad.AValor() } } // 1..1 DAJ02.
            };
            var supplierParty = new PartyType(); // 1..1 DAJ03.
            // supplierParty.IndustryClassificationCode = new IndustryClassificationCodeType { Value = } // 0..1 DAJ04. Corresponde al código de actividad económica CIIU. Identifica el código de actividad económica del emisor. Debe informar el código según lista CIIU.Para informar varios códigos, se separan por ejemplo 7020; 5140. Al ser opcional se omite para evitar pedir muchos datos al usuario.
            if (!string.IsNullOrEmpty(Empresa.NombreComercial))
            {
                supplierParty.PartyName = new PartyNameType[1] {
                    new PartyNameType { Name = new NameType1 { Value = Validar(Empresa.NombreComercial, "5..450", true) } } // 0..1 DAJ05. Name: 1..1 DAJ06.
                };
            }

            supplierParty.PhysicalLocation = new LocationType1
            {
                Address = obtenerAddress(Empresa.DirecciónUbicaciónEfectiva, Empresa.MunicipioUbicacion) // 0..1 DAJ07. Es opcional pero los campos más sujetos a errores que son los de nombre solo solo generan notificación en caso de no coincidir con los datos de la DIAN entonces se prefiere informar todo.
            };

            supplierParty.PartyTaxScheme = new PartyTaxSchemeType[1] { // 1..1 DAJ19.
                new PartyTaxSchemeType {
                    RegistrationName = registrationNameFacturador, // 1..1 DAJ20.
                    CompanyID = companyIDFacturador,
                    TaxLevelCode = new TaxLevelCodeType {

                        Value = Validar(Empresa.ResponsabelFiscal, "1..30", true), // 1..1 DAJ26. El tamaño la documentación dice 30 único pero ese valor no tiene sentido. Se usará 1..30.
                        listName = Empresa.TipoContribuyente, // Supuestamente DAJ27 es un elemento opcional, pero el servidor de la DIAN si lo exige. Se encontró que se debe usar 48 o 49 dependiendo de si es o no responsable de IVA aquí http://facturasyrespuestas.com/2225/inquietud-campo-taxlevelcode. Estos valores se pueden ver en el numeral 16.1.6. Modificación del anexo técnico (06-09-2019) de la documentación.
                        //Value = Validar("0-99", "1..30"), // 1..1 DAJ26. El tamaño la documentación dice 30 único pero ese valor no tiene sentido. Se usará 1..30.
                        //listName = "05", // Supuestamente DAJ27 es un elemento opcional, pero el servidor de la DIAN si lo exige. Se encontró que se debe usar 48 o 49 dependiendo de si es o no responsable de IVA aquí http://facturasyrespuestas.com/2225/inquietud-campo-taxlevelcode. Estos valores se pueden ver en el numeral 16.1.6. Modificación del anexo técnico (06-09-2019) de la documentación.

                    },
                    RegistrationAddress = obtenerAddress(Empresa.DireccionFacturacion,Empresa.MunicipioFacturacion), // 0..1 CAJ28. Aquí se incluyen automáticamente los elementos CAJ29, CAJ30, CAJ74, CFAJ31, CAJ32, CAJ33, CAJ34, CAJ35, CAJ36, CAJ37 y CAJ38.
                    TaxScheme = new TaxSchemeType { // 1..1 DAJ39.

                        //ID = new IDType { Value = Validar(ObtenerCódigoTipoImpuesto(tipoImpuesto, forzar01: true), "2..10") }, // 1..1 DAJ40. Aunque la documentación dice tamaño 3..10 esto va en contradicción con el código "01" o "04" se usa 2..10. La documentación dice usar los valores de la tabla 13.2.6.2 pero a la vez restringe los valores a 01 o 04 sin especificar que se debe hacer en los casos de IVA y INC, por esto se usa el parámetro forzar01 = true en el que si es IVA e INC se devuelve el valor de IVA = 01.
                        //Name = new NameType1 { Value = Validar(ObtenerNombreImpuesto(tipoImpuesto, forzarIVA: true), "3..30") } // 1..1 DAJ41. Aunque la documentación dice tamaño 10..30 esto va en contradicción con el tamaño de "IVA", se usa 3..30.

                        ID = new IDType { Value = Validar("01", "2..10") }, // 1..1 DAJ40. Aunque la documentación dice tamaño 3..10 esto va en contradicción con el código "01" o "04" se usa 2..10. La documentación dice usar los valores de la tabla 13.2.6.2 pero a la vez restringe los valores a 01 o 04 sin especificar que se debe hacer en los casos de IVA y INC, por esto se usa el parámetro forzar01 = true en el que si es IVA e INC se devuelve el valor de IVA = 01.
                        Name = new NameType1 { Value = Validar("IVA", "3..30") } // 1..1 DAJ41. Aunque la documentación dice tamaño 10..30 esto va en contradicción con el tamaño de "IVA", se usa 3..30.

                    },
                }
            };

            supplierParty.PartyLegalEntity = new PartyLegalEntityType[1] { // 1..1 DAJ42.
                new PartyLegalEntityType {
                    RegistrationName = registrationNameFacturador, // 1..1 DAJ43.
                    CompanyID = companyIDFacturador, // Se reusa el objeto creado anteriormente. Aquí se incluyen automáticamente los elementos DAJ44, DAJ45, DAJ46, DAJ47 y DAJ48.   
                    CorporateRegistrationScheme = new CorporateRegistrationSchemeType { // 0..1 DAJ49. Grupo de información de registro del emisor. 
                        ID = new IDType { Value = Validar(Empresa.PrefijoNotaDebito, "1..6") }, // ID: 0..1 DAJ50, prefijo de la facturación usada para el punto de venta. Aunque es opcional agrega para evitar que reporte notificación. Dice que el tamaño debe ser 6 pero claramente es incorrecto porque los prefijos pueden ser de menor tamaño, se valida con 1..6.
                        // Name = new NameType1 { Value = } // Name: 0..1 DAJ51 T9 Número de matrícula mercantil. Al ser opcional y al no haber claridad a que se refiere se omite.
                    }    
                    // ShareholderParty = new ShareholderPartyType { PartecipationPercent = new PartecipationPercentType {} , Party = new PartyType {} } // 0..1 FAJ52. Elementos para consorcios y uniones temporales. No implementado porque es opcional y porque no es el público objetivo de SimpleOps. Incluye los códigos FAJ53, FAJ54, FAJ55, FAJ53, FAJ57, FAJ58, FAJ59, FAJ60, FAJ61, FAJ62, FAJ63, FAJ64, FAJ65 y FAJ66.
                },
            };

            supplierParty.Contact = new ContactType
            { // 0..1 DAJ67. Aunque su uso no es obligatorio se considera apropiado informarlo porque es información que se dispone. Los clientes pueden hacer uso de esta información en la factura electrónica.
                Name = new NameType1 { Value = Empresa.NombreContactoFacturación }, // 0..1 DAJ68.
                Telephone = new TelephoneType { Value = Empresa.TeléfonoContactoFacturación }, // 0..1 DAJ69.
                // Telefax = new TelefaxType { Value = }, // 0..1 CAJ70. El fax ya es obsoleto, no se requiere informar.
                ElectronicMail = new ElectronicMailType { Value = Empresa.EmailContactoFacturación }, // 0..1 DAJ71.
                // Note = new NoteType { Value = "" }, // 0..1 DAJ72. No es necesario saturar la interfaz requiriendo notas sobre el contacto.
            };

            accountingSupplierParty.Party = supplierParty;
            invoice.AccountingSupplierParty = accountingSupplierParty;

            #endregion Datos Facturador>

            //*************************************************
            // DATOS DEL CLIENTE 
            //*************************************************
            #region Datos Cliente

            var accountingCustomerParty = new CustomerPartyType
            { // 1..1 DAK01.
                AdditionalAccountID = new AdditionalAccountIDType[1] { new AdditionalAccountIDType { Value = lobRegCliente.Sis_tipper_sitr } } // 1..1 DAK02.
            };

            var customerParty = new PartyType()
            { // 1..1 DAK03.
                PartyIdentification = new PartyIdentificationType[1] {
                new PartyIdentificationType {  // 1..1 DAK03-1.
                    ID = new IDType {
                            Value =  Validar(lobRegCliente.Sis_FactEleNitAdquirente, "5..12"), // 1..1 DAK03-2.
                            schemeName = lobRegCliente.Sis_tipide_tido, // 1..1 DAK03-3.
                            schemeID = lobRegCliente.Sis_FactEleDigitoVerificNit, // 0..1 DAK03-4.
                        }
                    }
                }
            };

            if (!string.IsNullOrEmpty(lobRegCliente.Sis_FactEleRazonSocial)) // 0..1 DAK05.
                customerParty.PartyName = new PartyNameType[1] {
                    new PartyNameType { Name = new NameType1 { Value = Validar(lobRegCliente.Sis_FactEleRazonSocial, "5..450", true) } } // 1..1 CAK06.
                };

            //customerParty.PhysicalLocation = new LocationType1 { Address =  }; // 0..1 CAK07. Este elemento incluye DAK08, DAK09, DAK10, DAK57, DAK11, DAK12, DAK13, DAK14, DAK15, DAK16, DAK18. La mayoría de las empresas tienen la misma ubicación física que su dirección de facturación y en el caso que no sea así no es fácil ni útil para una empresa obtener esta información de sus clientes. Cuando hay diferentes direcciones de entrega para una empresa SimpleOps lo maneja con las Sedes pero no provee la funcionalidad de marcar una de estas sedes como la principal porque esto no aporta valor adicional. No se incluye en la base de datos ni se reportará a la DIAN.

            customerParty.PartyTaxScheme = new PartyTaxSchemeType[1] {
                new PartyTaxSchemeType { // 0..1 DAK19.
                    RegistrationName = registrationNameCliente, // 1..1 DAK20. 
                    CompanyID = companyIDCliente, // 1..1 DAK21. Incluye DAK22, DAK23, DAK24 y DAK25.

                    // 0..1 DAK26. Incluye DAK27. No siempre se dispone de la información correcta de que tipo de contribuyente es un lcrDatosCliente entonces se omite.
                    TaxLevelCode = new TaxLevelCodeType {
                        Value = Validar("R-99-PN", "1..30"), // 1..1 FAK26. El tamaño la documentación dice 30 único pero ese valor no tiene sentido. Se usará 1..30.
                        listName = "48",
                        /*
                        Value = Validar("0-99", "1..30"), // 1..1 DAK26. El tamaño la documentación dice 30 único pero ese valor no tiene sentido. Se usará 1..30.
                        listName = "05",
                        */
                    },

                }
            };

            //customerParty.PartyTaxScheme[0].RegistrationAddress = obtenerAddress(lobRegCliente.Sis_direcc_sitr, Empresa.MunicipioFacturacion); // 0..1 FAK28. Incluye FAK29, FAK30, FAK58, FAK31, FAK32, FAK33, FAK34, FAK35, FAK36, FAK37 y FAK38.
            customerParty.PartyTaxScheme[0].RegistrationAddress = obtenerAddress(lobRegCliente.Sis_direcc_sitr, lobRegCliente.Sis_MunicipioUbicacion); // 0..1 DAK28. Incluye DAK29, DAK30, DAK58, DAK31, DAK32, DAK33, DAK34, DAK35, DAK36, DAK37 y DAK38.
            customerParty.PartyTaxScheme[0].TaxScheme = new TaxSchemeType
            { // 1..1 DAK39.
                //ID = new IDType { Value = Validar(ObtenerCódigoTipoImpuesto(tipoImpuesto), "2..10") }, // 1..1 DAK40. Dice que para el consumidor final debe informar "ZZ" pero quedan dudas al respecto porque no tiene mucho que ver con los impuestos de la factura, se dejará normal.
                //Name = new NameType1 { Value = Validar(tipoImpuesto.ATexto(), "3..30") } // 1..1 DAK41.
                ID = new IDType { Value = Validar("01", "2..10") }, // 1..1 DAK40. Dice que para el consumidor final debe informar "ZZ" pero quedan dudas al respecto porque no tiene mucho que ver con los impuestos de la factura, se dejará normal.
                Name = new NameType1 { Value = Validar("IVA", "3..30") } // 1..1 DAK41.

            }; // 1..1 DAK39. Incluye DAK40 y DAK41.

            customerParty.PartyLegalEntity = new PartyLegalEntityType[1] { // 1..1 DAK42.
                new PartyLegalEntityType {
                    RegistrationName = registrationNameCliente, // 1..1 DAK43.
                    CompanyID = companyIDCliente, // 1..1 DAK44. Incluye DAK45, DAK46, DAK47 y DAK48.
                    // CorporateRegistrationScheme =  // 0..1 DAK49. Incluye DAK50. Es opcional y no hay claridad a que se refiere entonces se omite.
                }
            };

            if (customerParty.PartyLegalEntity[0].RegistrationName.Value != lobRegCliente.Sis_FactEleRazonSocial)
                MessageBox.Show(customerParty.PartyLegalEntity[0].RegistrationName.Value, "Error");

            if (lobRegCliente.Sis_nomcon_sitr != null)
            {

                customerParty.Contact = new ContactType
                { // 0..1 DAK51.
                    Name = new NameType1 { Value = lobRegCliente.Sis_nomcon_sitr }, // 0..1 DAK52.
                    Telephone = new TelephoneType { Value = lobRegCliente.Sis_telefo_sitr }, // 0..1 DAK53.
                    // Telefax = new TelefaxType { Value = }, // 0..1 DAK54. Tecnología obsoleta, no es necesario.
                    ElectronicMail = new ElectronicMailType { Value = lobRegCliente.Sis_emailc_sitr }, // 0..1 DAK55.
                    // Note = new NoteType { Value = }, // 0..1 DAK56. No es necesario saturar la interfaz pidiendo este dato.

                    /*
                    Name = new NameType1 { Value = lcrDatosCliente.ContactoFacturas.Nombre }, // 0..1 DAK52.
                    Telephone = new TelephoneType { Value = lcrDatosCliente.ContactoFacturas.Teléfono }, // 0..1 DAK53.
                    // Telefax = new TelefaxType { Value = }, // 0..1 DAK54. Tecnología obsoleta, no es necesario.
                    ElectronicMail = new ElectronicMailType { Value = lcrDatosCliente.ContactoFacturas.Email }, // 0..1 DAK55.
                    // Note = new NoteType { Value = }, // 0..1 DAK56. No es necesario saturar la interfaz pidiendo este dato.
                    */
                };

            }

            if (lobRegCliente.TipoEntidad != TipoEntidad.Empresa)
            {
                customerParty.Person = new PersonType[1] { // 0..1 DAK56.
                    new PersonType {
                        // ID = new IDType { Value = } // 0..1 DAK56-1.
                        FirstName = new FirstNameType { Value = NombreUsuarioFinal }, // 1..1 DAK56-2.
                        FamilyName = new FamilyNameType { Value = ApellidoUsuarioFinal }, // 0..1 DAK56-3.
                        MiddleName = new MiddleNameType { Value = lobRegCliente.Sis_FactEleRazonSocial }, // 0..1 DAK56-4. Aunque dice Middle Name en la documentación dice poner Nombre del adquiriente entonces se pondrá el nombre completo con apellidos.
                        ResidenceAddress = obtenerAddress(lobRegCliente.Sis_direcc_sitr, lobRegCliente.Sis_MunicipioUbicacion), // 0..1 DAK56-5, Incluye todos los otros DAK56 sin código.
                    }
                };
            }

            accountingCustomerParty.Party = customerParty;
            invoice.AccountingCustomerParty = accountingCustomerParty;
            // invoice.TaxRepresentativeParty = new PartyType { }; // 0..1 DAL01. Incluye DAL02, DAL03, DAL04, DA05, DAL07 y DAL06. No hay claridad a que se refieren con 'Persona autorizada para descargar documentos'. Al ser opcional se omite.

            #endregion Datos Cliente>

            //*************************************************
            // DATOS DE ENTREGA
            //*************************************************
            #region Datos Entrega
            // Aunque son opcionales para la DIAN si se disponen se añaden porque podrían ser usados por el cliente.
            /*
            var deliveries = new DeliveryType[1];
            var delivery = new DeliveryType(); // 0..1 FAM01.

            // delivery.ActualDeliveryDate = ; // 0..1 FAM02. Normalmente no se dispone de esta información porque la factura se suele generar antes de realizar el envío.
            // delivery.ActualDeliveryTime = ; // 0..1 FAM03. Igual que el anterior.

            if (venta != null) delivery.DeliveryAddress = obtenerAddress(venta.DirecciónCompletaEntrega); // 0..1 FAM01. Incluye FAM02, FAM03, FAM04, FAM05, FAM06, FAM68, FAM07, FAM09, FAM10, FAM11, FAM12, FAM13 y FAM14.

            // delivery.DeliveryParty = ; // 0..1 FAM15. Incluye FAM16, FAM17, FAM18, FAM19, FAM20, FAM21, FAM69, FAM22, FAM23, FAM24, FAM25, FAM26, FAM27, FAM28, FAM29, FAM30, FAM31, FAM32, FAM33, FAM34, FAM35, FAM36, FAM37, FAM38, FAM39, FAM40, FAM41, FAM70, FAM42, FAM43, FAM44, FAM45, FAM46, FAM47, FAM48, FAM49, FAM50, FAM51, FAM52, FAM53, FAM54, FAM55, FAM56, FAM57, FAM58, FAM59, FAM60, FAM61, FAM62, FAM63, FAM64, FAM65, FAM66 y FAM67. Normalmente en el momento de la facturación no se dispone de la empresa transportadora que se va a usar para el envío. Al ser opcional se omite.

            deliveries[0] = delivery;
            invoice.Delivery = deliveries;
            if (venta != null)
            {

                invoice.DeliveryTerms = new DeliveryTermsType
                {
                    // ID = new IDType { Value = "1" }, // 0..1 FBC02 No ha claridad a que se refiere la documentación con 'número de línea'.
                    SpecialTerms = new SpecialTermsType[1] { new SpecialTermsType { Value = venta.PagoTransporte.ATexto() } }, // 0..1 FBC03.
                    // LossRiskResponsibilityCode = , // 0..1 FBC04 Términos incoterm, no es necesario para el público objetivo de SimpleOps.
                    // LossRisk = , // 0..1 FBC05. Opcional personalizado, se omite.
                };

            }
            */
            #endregion Datos Entrega>

            //*************************************************
            // DATOS DEL PAGO
            //*************************************************
            #region Datos Pago

            var paymentsMeans = new PaymentMeansType[1]; // 1..N DAN01.
            paymentsMeans[0] = new PaymentMeansType
            {
                ID = new IDType { Value = toboRegFactura.Fcm_forpag_mfac.Trim() }, // 1..1 DAN02.
                PaymentMeansCode = new PaymentMeansCodeType { Value = CodigoMedioPagoPorDefinir }, // 1..1 DAN03. En la documentación dice que el tamaño debe ser 1..2 pero CódigoMedioPagoPorDefinir es ZZZ, entonces no se realiza ninguna validación.
                // PaymentID = new PaymentIDType { Value = } // 0..N no hay claridad a que se refiere y es opcional. El DAN06 PaymentTerms ni está documentado.
            };

            if (Funciones.flgValidaFecha("DMY", "/", Funciones.fcrConvertFecha(toboRegFactura.Fcm_fecven_mfac)) == true)
            {
                paymentsMeans[0].PaymentDueDate = new PaymentDueDateType { Value = toboRegFactura.Fcm_fecven_mfac }; // 0..1 DAN04.
            }

            invoice.PaymentMeans = paymentsMeans;
            /*
            if (venta?.InformePago != null)
            {

                var prepaidPayments = new PaymentType[1]; // 0..N DBD01.
                prepaidPayments[0] = new PaymentType
                {
                    ID = new IDType { Value = Validar(venta.InformePago.Lugar, "1..150", true) }, // 1..1 DBD02.
                    PaidAmount = new PaidAmountType { Value = Validar(Anticipo, "4..15 p (2..6)", 2), currencyID = moneda }, // 1..1 DBD03. Incluye DBD04.
                    ReceivedDate = new ReceivedDateType { Value = venta.InformePago.FechaHoraPago }, // 1..1 DBD05.
                    // PaidDate = , // 0..1 DBD06 No se registra en la base de datos la fecha de realización del pago, se registra es la fecha de recepción. Lo importante para efectos de la empresa es cuando se recibió. Es opcional, entonces no se registra.
                    // PaidTime = , // 0..1 DBD07. Igual que el anterior.
                    // InstructionID = , // 0..1 DBD08. Instrucciones relativas al pago T15..5000. Las observaciones del pago se consideran información de uso privado de la empresa y no se comparten con los clientes en la factura electrónica.
                };
                invoice.PrepaidPayment = prepaidPayments;

            }
            */
            /*
            var descuentoCondicionado = 0M;
            if (venta.PorcentajeDescuentoCondicionado != null)
            {

                descuentoCondicionado = venta.DescuentoCondicionado;
                invoice.AllowanceCharge = new AllowanceChargeType[1] { new AllowanceChargeType { // 0..N FAQ01. Según la documentación son descuentos o cargos a nivel de factura que no afectan las bases gravables es decir están hablando de descuentos condicionados o financieros (Leer más en https://www.globalcontable.com/tratamiento-de-los-descuentos-en-la-facturacion-electronica-oficio-dian-20067-de-2019/). Además en la tabla 13.3.7 lo vuelven a aclarar cuando dicen que los 00. Descuento no condicionado es para descuentos a nivel de línea y 01. Descuento condicionado, son los descuentos a pie de factura. Aunque el término a pie de factura se podría interpretar como descuento comercial, la aclaración sobre que los no condicionados se usan a nivel de línea compensa esa poca claridad y refuerza la indicación de la tabla de documentación para que el elemento FAQ01 se debe use solo para descuentos condicionados.
                    ID = new IDType { Value = "1" }, // 1..1 FAQ02. Solo se agrega un descuento condicionado.
                    ChargeIndicator = new ChargeIndicatorType { Value = false }, // 1..1 FAQ03. Solo se soportarán descuentos, no cargos.
                    AllowanceChargeReasonCode = new AllowanceChargeReasonCodeType { Value = TipoDescuento.Condicionado.AValor(largoForzado: 2) }, // 0..1 FAQ04.
                    AllowanceChargeReason = new AllowanceChargeReasonType[]
                        { new AllowanceChargeReasonType { Value = Validar(TipoDescuento.Condicionado.ATexto(), "10..5000", true) } }, // 1..1 FAQ05.
                    MultiplierFactorNumeric = new MultiplierFactorNumericType {
                        Value = Validar((decimal)venta.PorcentajeDescuentoCondicionado * 100, "1..6 p (0..2)", 2) // 1..1 FAQ06. 
                    },
                    Amount = new AmountType2 { Value = Validar(descuentoCondicionado, "4..15 p (2..6)", 2), currencyID = lcrMoneda }, // 1..1 FAQ07. currencyID: 1..1 FAQ08.
                    BaseAmount = new BaseAmountType { Value = Validar(venta.SubtotalBase, "4..15 p (2..6)", 2), currencyID = lcrMoneda } // 1..1 FAQ09. currencyID: 1..1 FAQ10. Valor base para calcular el descuento o el cargo.
                }};

            }
            */
            // invoice.PaymentExchangeRate = new ExchangeRateType { }; // 0..1 FAR01. Incluye FAR02, FAR03, FAR04, FAR05, FAR06, FAR07, FGB01, FGB02, FGB03, FGB04, FGB05, FGB06 y FGB07. SimpleOps no implementa la posibilidad de múltiples monedas y manejo de tasas de cambio por lo tanto este elemento siempre se omite.

            #endregion Datos Pago>

            //*************************************************
            // TOTALES DATOS DE IMPUESTOS
            //*************************************************
            #region Datos Impuestos 

            invoice.TaxTotal = FobGenerarResumenImpuestos(toboRegFactura);

            //invoice.TaxTotal = FobGenerarTaxTotalesMA(toboRegFactura, 21); // ojo- 21% es de prueba
            // invoice.WithholdingTaxTotal = new TaxTotalType[1] { obtenerTaxTotal(, TipoTributo.RetenciónRenta) }; // 0..N FAT01. Incluye FAT02, FAT03, FAT04, FAT05, FAT06, FAT07, FAT08, FAT09, FAT10, FAT11, FAT12 y FAT13. Grupo de campos para información relacionada con los tributos retenidos. Se usa para los casos que la empresa sea autorretenedor según la documentación de la DIAN. Sin embargo no se agregará por 4 razones: 1. El público objetivo de SimpleOps es improbable que sea autorretenedor. 2. Aún si alguno lo fuera este elemento no es de utilidad para el cliente pues los valores autorretenidos son importantes solo para la empresa y su declaración de impuestos, el cliente lo único que debe saber es que no debe aplicar retenciones. 3 el elemento es opcional, entonces para la DIAN tampoco es importante. 4. Es extraño lo de la autorretención, se supone que cuando un facturador es autorretenedor esto implica que el cliente no le debe aplicar ninguna retención al pagarle la factura, entonces si para los autorretenedores las retenciones son cero, ¿Qué se supone que se informaría aquí?
            #endregion Datos Impuestos>

            //*************************************************
            // DATOS DE TOTALES
            //*************************************************
            #region Datos Totales

            var ldeValorBruto = (decimal)toboRegFactura.Fcm_valbru_dfac;
            var ldeValorTributo = (decimal)toboRegFactura.Fcm_valiva_dfac; // solo IVA por el moento
            var ldaValorBaseImp = (decimal)toboRegFactura.Fcm_valbsi_dfac;
            var ldeAnticipo = (decimal)(toboRegFactura.Fcm_valcpa_dfac + toboRegFactura.Fcm_valcmo_dfac + toboRegFactura.Fcm_valusu_dfac);
            var ldeDescuentos = (decimal)toboRegFactura.Fcm_valdes_dfac;
            var ldeBrutoYTributo = ldeValorBruto + ldeValorTributo;         // 1..1 DAU06 Valor Bruto mas Tirubutos solamente
            var ldeValorAPagar = (decimal)toboRegFactura.Fcm_valfac_dfac;

            var legalMonetaryTotal = new MonetaryTotalType
            { // 1..1 DAU01.
                LineExtensionAmount = new LineExtensionAmountType { Value = Validar(ldeValorBruto, "4..15 p (2..6)", 2), currencyID = lcrMoneda }, // 1..1 CAU02. currencyID: 1..1 CAU03. Total valor bruto antes de tributos. Es la suma de los valores subtotales de las líneas de la factura.
                TaxExclusiveAmount = new TaxExclusiveAmountType { Value = Validar(ldaValorBaseImp, "4..15 p (2..6)", 2), currencyID = lcrMoneda }, // 1..1 CAU04. currencyID: 1..1 CAU05. Total valor base imponible. Es la suma de la base para los impuestos.
                TaxInclusiveAmount = new TaxInclusiveAmountType
                {
                    Value = Validar(ldeBrutoYTributo, "4..15 p (2..6)", 2),
                    currencyID = lcrMoneda // 1..1 DAU06. Moneda: 1..1 DAU07. Total de valor bruto más tributos.
                },

                // No reportar en cero // 0..1 DAU08. currencyID 1..1 DAU09. Suma de todos los descuentos aplicados a nivel de la factura (son los de AllowanceCharge, es decir los condicionados).
                AllowanceTotalAmount = fobAllowanceTotalAmount(ldeDescuentos, lcrMoneda),

                // ChargeTotalAmount = new ChargeTotalAmountType { Value = 0, currencyID = Opciones.Moneda }; // 0..1 DAU10. currencyID 1..1 CAU11. Suma de todos los cargos aplicados a nivel de la factura. No se soportan cargos. La manera más fácil e intuitiva de generarlos facturando un servicio dentro de la factura.
                PrepaidAmount = fobPrepaidAmount(ldeAnticipo, lcrMoneda),
                //PrepaidAmount = new PrepaidAmountType { Value = Validar(ldeAnticipo, "4..15 p (2..6)", 2), currencyID = lcrMoneda }, // 0..1 CAU12. currencyID 1..1 CAU13. Suma de todos los pagos anticipados.

                PayableAmount = new PayableAmountType
                {
                    Value = Validar(ldeValorAPagar, "0..15 p (2..6)", 2),
                    currencyID = lcrMoneda // 1..1 DAU14. El valor a pagar es igual a la suma del valor bruto + tributos - valor del descuento total + valor del cargo total - valor del anticipo total. Moneda: 1..1 CAU15. 
                }
            };

            #region Generar el item Descuento>
            // Generar el item Descuento
            static AllowanceTotalAmountType? fobAllowanceTotalAmount(decimal tdeValorDescuento, string tcrMoneda)
            {
                if (tdeValorDescuento == 0) return null;

                var lobAllowanceTotalAmount = new AllowanceTotalAmountType
                {
                    Value = Validar(tdeValorDescuento, "4..15 p (2..6)", 2),
                    currencyID = tcrMoneda // 0..1 DAU08. currencyID 1..1 DAU09. Suma de todos los descuentos aplicados a nivel de la factura (son los de AllowanceCharge, es decir los condicionados).
                };

                return lobAllowanceTotalAmount;
            }
            #endregion Generar el item Descuento>

            #region Generar el item Anticipo>
            // Generar el item Anticipo
            static PrepaidAmountType? fobPrepaidAmount(decimal tdeValorAnticipo, string tcrMoneda)
            {
                if (tdeValorAnticipo == 0) return null;

                var lobPrepaidAmount = new PrepaidAmountType
                {
                    Value = Validar(tdeValorAnticipo, "4..15 p (2..6)", 2),
                    currencyID = tcrMoneda // 0..1 DAU08. currencyID 1..1 DAU09. Suma de todos los descuentos aplicados a nivel de la factura (son los de AllowanceCharge, es decir los condicionados).
                };

                return lobPrepaidAmount;
            }
            #endregion Generar el item Anticipo>

            invoice.RequestedMonetaryTotal = legalMonetaryTotal;

            #endregion Datos Totales>

            //*************************************************
            // DETALLES FACTURA PRODUCTOS (LINEAS)
            //*************************************************
            #region Líneas

            var invoiceLines = new DebitNoteLineType[toboRegFactura.tmpListVenta.Count];
            var lnuNumIDlinea = 1;

            foreach (var lobReg in toboRegFactura.tmpListVenta)
            { // 1..N CAV01.

                var invoiceLine = new DebitNoteLineType();
                //var producto = línea.Producto!; // Un documento electrónico siempre viene de una previa ejecución de CalcularTodo() y si esta fue exitosa se puede asegurar que ningún producto de las líneas es nulo.

                invoiceLine.ID = new IDType { Value = Validar(lnuNumIDlinea.ATexto(), "1..4") }; // 1..1 DAV02.
                // invoiceLine.Note = new NoteType[] { new NoteType { Value = , "20..5000", true) } }; // 0..N DAV03. Una nota cualquiera sobre la línea. No se agrega para evitar saturar la interfaz pidiendo esta información.
                invoiceLine.DebitedQuantity = new DebitedQuantityType
                {
                    Value = lobReg.Fcm_totuni_dfac, // 1..1 DAV04.
                    unitCode = "94" // Validar(lobReg.Sis_codume_sium, "2..5"), // 1..1 DAV05.  
                };
                invoiceLine.LineExtensionAmount = new LineExtensionAmountType
                {
                    Value = Validar((decimal)lobReg.Fcm_valbru_dfac, "0..15 p (2..6)", 2), // 1..1 DAV06.
                    currencyID = lcrMoneda // currencyID: 1..1 DAV07. 
                };

                invoiceLine.PricingReference = new PricingReferenceType
                { // 0..1 DAW01. Obligatorio informar si se trata de muestras comerciales.
                    AlternativeConditionPrice = new PriceType[] {  // 1..1 DAW02.
                        new PriceType {
                            PriceAmount = new PriceAmountType {
                                Value = Validar((decimal)lobReg.Fcm_valser_mant, "0..15 p (2..6)", 2), // 1..1 DAW03.
                                currencyID = lcrMoneda // currencyID: 1..1 DAW04.
                            },
                            PriceTypeCode =  new PriceTypeCodeType { Value = CódigoPrecioReferencia }, // 1..1 DAW05.
                        }
                    },
                };

                invoiceLine.AllowanceCharge = new AllowanceChargeType[] {
                    new AllowanceChargeType { // 0..N  DBE01. Este grupo se debe informar a nivel de ítem si el cargo o descuento afecta la base gravable del ítem (Es decir es un descuento comercial).
                        ID = new IDType { Value = "1" }, // DBE02.
                        ChargeIndicator = new ChargeIndicatorType { Value = false }, // 1..1 CAB03.
                        // AllowanceChargeReason = , // 0..1 DBE04. Por lo general es un descuento comercial. No se saturará la interfaz requiriendo esta información.
                        MultiplierFactorNumeric = new MultiplierFactorNumericType {
                            Value = Validar(0, "1..6 p (0..2)", 2) // 1..1 DBE05. Aunque debería ser línea.PorcentajeDescuentoComercial * 100, por simplicidad al informar a la DIAN no se reportará porque este está incluído en el SubtotalBase.
                        },
                        Amount = new AmountType2 {
                            Value = Validar(0, "4..15 p (2..6)", 2), currencyID = lcrMoneda // 1..1 DBE06. currencyID: 1..1 DBE07. Aunque debería ser línea.DescuentoComercial, por simplicidad al informar a la DIAN no se reportará porque este está incluído en el SubtotalBase.
                        },
                        BaseAmount = new BaseAmountType {
                            Value = Validar((decimal)lobReg.Fcm_valbru_dfac, "4..15 p (2..6)", 2), currencyID = lcrMoneda // 1..1 DBE08. currencyID: 1..1 DBE09.
                        },
                    }
                };

                // Generar los impuestos dados en la linea
                if (Empresa.TipoContribuyente == "48")
                { // FAX01 no debe ser informado para facturas del régimen simple grupo I ni para ítems cuyo concepto en contratos de AIU no haga parte de la base gravable.
                    invoiceLine.TaxTotal = FobGenerarTaxTotales(lobReg);  // 0..N DAX01.
                }
                // invoiceLine.WithholdingTaxTotal = ; // 0..N CAY01. Igual que en DAT01. Incluye DAY02, DAY03, DAY04, DAY05, DAY06, DAY07, DAY08, DAY09, DAY10, DAY11, DAY12 y DAY13.

                invoiceLine.Item = new ItemType
                {

                    Description = new DescriptionType[] { new DescriptionType { Value = Validar(lobReg.Fcm_desser_dfac, "5..300", true) } }, // 1..3 DAZ02.

                    //PackSizeNumeric = Convert.ToInt32(lobReg.Sis_codume_sium) >= 1000 ? null : new PackSizeNumericType { Value = Convert.ToInt32(lobReg.Sis_codume_sium) }, // 0..1 CAZ03. Como la documentación de la DIAN restringe este campo a 3 números cuando la unidad sea mayor o igual a 1000 se omite.
                    PackSizeNumeric = 1 >= 1000 ? null : new PackSizeNumericType { Value = 1 }, // 0..1 DAZ03. Como la documentación de la DIAN restringe este campo a 3 números cuando la unidad sea mayor o igual a 1000 se omite.

                    //BrandName = producto.Marca == null ? null : new BrandNameType[] { new BrandNameType { Value = Validar(producto.Marca.Nombre, "1..100", true) } }, // 0..3 CAZ04. Se agrega la marca si se tiene. Dependiendo del flujo del programa se puede o no tener la marca en este punto. Lo más probable es que si se tenga pero no se generará error si no.
                    // ModelName = new ModelNameType { Value = }, // 0..3 DAZ05. Tal vez se refiere a un modelo general aplicable para todos los vendedores de este producto. Por el momento no hay campo para especificar este valor en SimpleOps. Las empresas usuarias que deseen pueden usar la referencia para esto, pero esta referencia puede tener un uso diferente otra empresa usuaria entonces se prefiere no agregarla en la factura electrónicacomo ModelName, se agrega en SellersItemIdentiication.ID.
                    SellersItemIdentification = new ItemIdentificationType
                    { // 0..1 DAZ06.
                        ID = new IDType { Value = Validar(lobReg.Fcm_codser_mant, "1..50", true) }, // 0..1 DAZ07.
                        // ExtendedID = new ExtendedIDType { Value = }, // 0..1 DAZ08 T1..50. Código del vendedor correspondiente a una subespecificación del producto.
                    },

                    StandardItemIdentification = new ItemIdentificationType
                    { // 1..N DAZ09.
                        ID = new IDType
                        { // 1..1 DAZ10.
                            Value = lobReg.Fcm_codser_mant, // No hay claridad a que se refiere con el estándar pero se asume como un código internacional, se usa entonces la referencia para este ID si se usa un estándar propio.
                            schemeID = CódigoEstándarAdopciónContribuyente, // 1..1 DAZ12. Para 0..1 DAZ13 no dice nada la documentación.
                                                                            // schemeAgencyID = , // 0..1 DAZ14. Solo aplicable para tipo estándar GTIN.
                                                                            // schemeAgencyName = , // 0..1 DAZ11. Solo aplicable para tipo estándar GTIN.
                        },
                    },
                    // AdditionalItemProperty = new ItemPropertyType { }; // 0..N DBF01. Incluye DBF02 y DBF03. Grupo de información para adicionar información específica del ítem que puede ser solicitada por autoridades o entidades diferentes a la DIAN. Se omite porque no se sabe en que casos es necesario.
                    // InformationContentProviderParty = new PartyType { }; // 0..1 DBA01. Incluye DBA02, DBA03, DAB04, DAB05, DAB06, DAB09, DAB07 y DBA08. Grupo de información que describen el mandante de la operación de venta. Aplica solo para mandatos y se debe informar a nivel de ítem. SimpleOps aún no soporta este tipo de operaciones, se omite.

                };

                invoiceLine.Price = new PriceType
                { // 1..1 DBB01.
                    PriceAmount = new PriceAmountType
                    {
                        Value = Validar((decimal)lobReg.Fcm_valser_mant, "0..15 p (2..6)", 2),
                        currencyID = lcrMoneda // 1..1 DBB02. currencyID: DBB03.
                    },
                    BaseQuantity = new BaseQuantityType { Value = lobReg.Fcm_totuni_dfac, unitCode = lobReg.Sis_codume_sium }, // 1..1 DBB04. 1..1 DBB05.
                };

                invoiceLines[lnuNumIDlinea - 1] = invoiceLine;
                lnuNumIDlinea++;

            }

            invoice.DebitNoteLine = invoiceLines;

            #endregion Líneas>

            //*************************************************
            // ESCRITURA DEL XML
            //*************************************************
            #region Escritura XML

            // Generar rutas y nombrees de archivos fisicos firmados y sin firma
            FcvGenNombreYRutaArchivos();

            var espaciosNombres = new XmlSerializerNamespaces();
            espaciosNombres.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            espaciosNombres.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            espaciosNombres.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
            espaciosNombres.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            espaciosNombres.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            espaciosNombres.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            espaciosNombres.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            espaciosNombres.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            espaciosNombres.Add("schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2     " + "http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-DebitNote-2.1.xsd");

            var serializadorXml = new XmlSerializer(typeof(DebitNoteType), new Type[] {
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

        #region Funciones para Totales impuestos

        #region FobGenerarTaxTotalesMA Maestro
        /// <summary>
        /// Generar los impuestos totales Maestro factura
        /// </summary>
        /// <param name="tobRegistro">Registro Maestro factura (una linea)</param>
        /// <param name="tcrPorcentaje">Porcerntaje del impuesto ap´licado</param>
        /// <returns></returns>
        public static TaxTotalType[]? FobGenerarTaxTotalesMA(ModeloFeFacturaMa tobRegistro, decimal tcrPorcentaje)
        {

            TaxTotalType taxTotal;
            var taxTotales = new List<TaxTotalType>(); // 0..N DAS01, DAX01.

            // Generar registro para IVA % por ahora
            if (tobRegistro.Fcm_valiva_dfac > 0)
            {
                taxTotal = FobOtenerTaxTotal("01", "IVA",
                                             (decimal)tobRegistro.Fcm_valiva_dfac,
                                             (decimal)tobRegistro.Fcm_valbru_dfac,
                                             tcrPorcentaje);

                if (taxTotal != null) taxTotales.Add(taxTotal);
            }

            return taxTotales.ToArray();

        }
        #endregion FobGenerarTaxTotales
        #region FobGenerarTaxTotales Registro
        /// <summary>
        /// Generar los impuestos totales de cada registro
        /// </summary>
        /// <param name="tobRegistro">Registro tipo detalle factura (una linea)</param>
        /// <param name="tlgExito">Devuelve verdadero o falso si se genera el registro</param>
        /// <param name="tcrMensaje">Cuando ocurre algun error se devuelve un mensaje</param>
        /// <returns></returns>
        public static TaxTotalType[]? FobGenerarTaxTotales(ModeloFeFacturaMd tobRegistro)
        {

            TaxTotalType taxTotal;
            var taxTotales = new List<TaxTotalType>(); // 0..N DAS01, DAX01.

            // Generar registro para IVA % por ahora
            if (tobRegistro.Fcm_valiva_dfac > 0)
            {
                taxTotal = FobOtenerTaxTotal("01", "IVA",
                                             (decimal)tobRegistro.Fcm_valiva_dfac,
                                             (decimal)tobRegistro.Fcm_valbsi_dfac,
                                             (decimal)tobRegistro.Fcm_poriva_dfac);

                if (taxTotal != null) taxTotales.Add(taxTotal);
            }

            return taxTotales.ToArray();

        }
        #endregion FobGenerarTaxTotales
        #region FobOtenerTaxTotal
        /// <summary>
        /// Generar el TaxTotal de cada tipo de impuesto (Ver: FAS03, FAX03)
        /// </summary>
        /// <param name="tcrCodigoTipo">Codigo Tipo impuesto "01"=IVA "02"=ICA ...</param>
        /// <param name="tcrNombre">Nombre del impuesto "IVA", "ICA", "ReteICA" ...</param>
        /// <param name="tdeValorImpuesto">Valor del impuesto cobrado al Producto</param>
        /// <param name="tdeBaseGravable">Base grabable del producto</param>
        /// <param name="tdePorcentaje">Porcentage del impuesto aplicado a la base gravable</param>
        /// <returns></returns>
        public static TaxTotalType? FobOtenerTaxTotal(
            string tcrCodigoTipo,
            string tcrNombre,
            decimal tdeValorImpuesto,
            decimal tdeBaseGravable,
            decimal tdePorcentaje)
        {

            var taxSubtotales = new List<TaxSubtotalType>();
            var lcrMoneda = Empresa.MunicipioFacturacion.Moneda;

            var taxTotalType = FobTaxTotalType(tdeValorImpuesto, lcrMoneda);
            var taxSubtotal = FobTaxSubtotalType(tcrCodigoTipo, tcrNombre, tdeValorImpuesto, lcrMoneda);

            taxSubtotal.TaxableAmount = new TaxableAmountType
            {
                Value = Validar(tdeBaseGravable, "0..15 p (2..6)", 2),
                currencyID = lcrMoneda // 1..1DAS05, DAX05. currencyID: 1..1 DAS06, DAX06. En el caso de que el tributo sea una porcentaje del valor tributable informar la base imponible en valor monetario.
            };
            taxSubtotal.TaxCategory.Percent = new PercentType1
            {
                Value = Validar(tdePorcentaje, "0..5 p (0..3)", 2) // 0..1 DAS14, DAX14. Aunque en la tabla 13.3.9 no mencionan el 0 como un valor válido para el INC se permitirá el 0 porque se muestra en el ejemplo de XML.
            };

            taxSubtotales.Add(taxSubtotal);


            taxTotalType.TaxSubtotal = taxSubtotales.ToArray();

            return taxTotalType;

        }
        #endregion FobOtenerTaxTotal
        #region FobTaxTotalType
        /// <summary>
        /// Genera el Elemento principal TaxTotal
        /// </summary>
        /// <param name="tdeTotalImpuesto">Sumatoria total del Valor Impuesto que sea </param>
        /// <param name="tcrMoneda">Tipo moneda para colombia es "COP"</param>
        /// <returns></returns>
        public static TaxTotalType FobTaxTotalType(decimal tdeTotalImpuesto, string tcrMoneda)
        {
            var lobTaxTotalType = new TaxTotalType
            {
                TaxAmount = new TaxAmountType
                {
                    Value = Validar(tdeTotalImpuesto, "0..15 p (2..6)", 2), // 1..1 DAS02, DAX02. 
                    currencyID = tcrMoneda // 1..1 DAS03, DAX03.
                }
            };
            return lobTaxTotalType;
        }
        #endregion FobTaxTotalType>
        #region FobTaxSubtotalType
        /// <summary>
        /// Genera el Elemento principal TaxTotal
        /// </summary>
        /// <param name="tdeTotalImpuesto">Valor Impuesto que sea </param>
        /// <param name="tcrMoneda">Tipo moneda para colombia es "COP"</param>
        /// <returns></returns>
        public static TaxSubtotalType FobTaxSubtotalType(string tcxrTipo, string tcrNombre, decimal tdeTotalImpuesto, string tcrMoneda)
        {
            var lobTaxSubtotal = new TaxSubtotalType
            { // 1..N DAS04, DAX04.      
                TaxAmount = new TaxAmountType { Value = Validar(tdeTotalImpuesto, "0..15 p (2..6)", 2), currencyID = tcrMoneda }, // 1..1 DAS07, DAX07. currencyID: 1..1 DAS08, DAX08.
                TaxCategory = new TaxCategoryType
                { // 1..1 DAS13, DAX13.
                    TaxScheme = new TaxSchemeType
                    { // 1..1 DAS15,DAX15.
                        ID = new IDType { Value = Validar(tcxrTipo, "2..10") }, // 1..1 DAS16, DAX16. Aunque la documentación dice tamaño 3..10 esto va en contradicción con el código "ZZ", se usa entonces 2..10.
                        Name = new NameType1 { Value = Validar(tcrNombre, "2..30") }, // 1..1 DAS17, DAX17. Aunque la documentación dice tamaño 10..30 esto va en contradicción con el nombre "IC", se usa entonces 2..30.
                    }
                },
            };
            return lobTaxSubtotal;
        }
        #endregion FobTaxTotalType>

        #endregion Totales impuestos

        #endregion Funciones Varias

    }

    #pragma warning disable CS8618
    #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

}

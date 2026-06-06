using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;
using static Sistema.Dian.ParametrosDian;

namespace Sistema.Dian
{
    public class FirmaElectronica
    {
        #region Variables de gestion
        public RolFirmante RolFirmante { get; set; }

        public string RutaCertificado { get; set; }

        public string ClaveCertificado { get; set; }

        public X509Certificate2 Certificado { get; set; }
        #endregion Variables de gestion>

        #region Firmar Documento Tipo Factura

        public byte[] FirmarFactura(FileInfo archivo, DateTime fecha)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            // si no se puede leer el archivo
            if (bytesXml == null) return null;

            return FirmarFactura(bytesXml, fecha);
        }

        public byte[] FirmarFactura(string xml, DateTime fecha)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarFactura(bytesXml, fecha);
        }

        public byte[] FirmarFactura(byte[] bytesXml, DateTime fecha)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }

        #endregion Firmar Documento Tipo Factura>

        #region Firmar Documento Tipo Nota Credito
        public byte[] FirmarNotaCredito(FileInfo archivo, DateTime fecha)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarNotaCredito(bytesXml, fecha);
        }

        public byte[] FirmarNotaCredito(string xml, DateTime fecha)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarNotaCredito(bytesXml, fecha);
        }

        public byte[] FirmarNotaCredito(byte[] bytesXml, DateTime fecha)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:CreditNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }

        #endregion Firmar Documento Tipo Nota Credito

        #region Firmar Documento Tipo Nota Debito

        public byte[] FirmarNotaDebito(FileInfo archivo, DateTime fecha)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarNotaDebito(bytesXml, fecha);
        }

        public byte[] FirmarNotaDebito(string xml, DateTime fecha)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarNotaDebito(bytesXml, fecha);
        }

        public byte[] FirmarNotaDebito(byte[] bytesXml, DateTime fecha)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:DebitNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }

        #endregion Firmar Documento Tipo Nota Debito>

        #region Firmar Evento

        public byte[] FirmarEvento(FileInfo archivo, DateTime fecha)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarEvento(bytesXml, fecha);
        }

        public byte[] FirmarEvento(string xml, DateTime fecha)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarEvento(bytesXml, fecha);
        }

        public byte[] FirmarEvento(byte[] bytesXml, DateTime fecha)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:ApplicationResponse/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }

        #endregion Firmar Evento

        #region Funcion Firmar Documento
        protected byte[] FirmarDocumento(byte[] bytesXml, DateTime tdaFechaGestion, SignatureXPathExpression xpathExpression)
        {
            var xadesService = new XadesService(); // aqui en esta clase esta todo el grueso del asunto ojo

            var lobParametros = new SignatureParameters();

            lobParametros.SignatureMethod = SignatureMethod.RSAwithSHA256;
            lobParametros.DigestMethod    = DigestMethod.SHA256;
            lobParametros.SigningDate     = tdaFechaGestion;
            lobParametros.SignerRole = new SignerRole();

            var lcrSignerRole = (RolFirmante == RolFirmante.EMISOR ? "supplier" : "third party");
            lobParametros.SignerRole.ClaimedRoles.Add(lcrSignerRole);

            lobParametros.SignatureDestination = xpathExpression;

            lobParametros.SignaturePolicyInfo = new SignaturePolicyInfo();

            lobParametros.SignaturePolicyInfo.PolicyIdentifier      = "https://facturaelectronica.dian.gov.co/politicadefirma/v2/politicadefirmav2.pdf";
            lobParametros.SignaturePolicyInfo.PolicyDescription     = "Política de firma para facturas electrónicas de la República de Colombia";
            lobParametros.SignaturePolicyInfo.PolicyHash            = "dMoMvtcG5aIzgYo0tIsSQeVJBDnUnfSOfBpxXrmor0Y=";
            lobParametros.SignaturePolicyInfo.PolicyDigestAlgorithm = DigestMethod.SHA256;

            lobParametros.SignaturePackaging = SignaturePackaging.ENVELOPED;
            lobParametros.DataFormat         = new DataFormat { MimeType = "text/xml" };

            using (lobParametros.Signer = new Signer(Certificado ?? new X509Certificate2(RutaCertificado, ClaveCertificado)))
            {
                using (var stream = new MemoryStream(bytesXml))
                {
                    var signatureDocument = xadesService.Sign(stream, lobParametros);

                    var output = new MemoryStream();
                    signatureDocument.Save(output);

                    return output.ToArray();
                }
            }
        }
        #endregion Funcion Firmar Documento>
    }
}

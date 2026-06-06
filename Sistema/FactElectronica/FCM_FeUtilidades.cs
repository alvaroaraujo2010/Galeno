using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
//using System.Text.Json.Serialization;

using Sistema.Clases;
using Sistema.Modelo;
using static Sistema.Dian.Global;
using static Sistema.Dian.General;
using static Sistema.Dian.ParametrosDian;
using Sistema.Utilidades;
using Xceed.Wpf.Toolkit;

namespace Sistema.Dian
{
    #pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

    public class Utilidades
    {
        //----------------------------------------------------------
        // Utilidades de gestion al generar archivos XML
        //----------------------------------------------------------
        #region FlgEsCufe: Decidir segun el tipo de documento
        /// <summary>
        /// Decidir segun el tipo de documento, si generar Cufe o Cude (por defecto cufe)
        /// </summary>
        /// <param name="tcrTipoDocumento"></param>
        /// <returns></returns>
        public static bool FlgEsCufe(TipoDocumentoElectronico tcrTipoDocumento) 
        {
            var llgReturn = tcrTipoDocumento switch
            {
                TipoDocumentoElectronico.FacturaVenta => true,
                TipoDocumentoElectronico.FacturaExportacion => true,
                TipoDocumentoElectronico.FacturaContingenciaFacturador => false,
                TipoDocumentoElectronico.FacturaContingenciaDian => false,
                TipoDocumentoElectronico.NotaCredito => false,
                TipoDocumentoElectronico.NotaDebito => false,
                _ => throw new Exception(CasoNoConsiderado(tcrTipoDocumento)),
            };
            return llgReturn;
        }
        #endregion FlgEsCufe: Decidir segun el tipo de documento>

        #region FenSelecctTipoFirma: Decidir tipo firma 
        /// <summary>
        /// Decidir segun el tipo de documento, que tipo firma se va a aplicar
        /// </summary>
        /// <param name="tcrTipoDocumento"></param>
        /// <returns></returns>
        public static TipoFirma FenSelectTipoFirma(TipoDocumentoElectronico tcrTipoDocumento)
        {
            var lobReturn = tcrTipoDocumento switch
            {
                TipoDocumentoElectronico.FacturaVenta => TipoFirma.Factura,
                TipoDocumentoElectronico.FacturaExportacion => TipoFirma.Factura,
                TipoDocumentoElectronico.FacturaContingenciaFacturador => TipoFirma.Factura,
                TipoDocumentoElectronico.FacturaContingenciaDian => TipoFirma.Factura,
                TipoDocumentoElectronico.NotaCredito => TipoFirma.NotaCrédito,
                TipoDocumentoElectronico.NotaDebito => TipoFirma.NotaDébito,
                _ => throw new Exception(CasoNoConsiderado(tcrTipoDocumento)),
            };

            return lobReturn;

        }
        #endregion FenSelecctTipoFirma: Decidir tipo firma>

        #region FcrTipoDocumento: Devolver Texto segun codigo tipo documento
        /// <summary>
        /// Devolver Texto segun codigo tipo documento
        /// </summary>
        /// <param name="tcrCodigoTipo">Codigo tipo documento eletronico "01"=Factura/"91"=Nota Credito/"92"=Nota Debito</param>
        /// <returns></returns>
        public static string FcrTipoDocumento(string tcrCodigoTipo)
        {
            var lcrReturn = tcrCodigoTipo switch
            {
                "01" => "FACTURA",
                "02" => "FACTURA EXPORTACIÓN",
                "03" => "FACTURA CONTINGENCIA FACTURADOR",
                "04" => "FACTURA CONTINGENCIA DIAN",
                "91" => "NOTA CRÉDITO",
                "92" => "NOTA DEBITO",
                _ => throw new Exception("NA"),
            };

            return lcrReturn;

        }
        #endregion FcrTipoDocumento: Decidir tipo firma>

        #region FcrTipoDocCufeCude: Devolver (CUDE/CUFE) segun codigo tipo documento
        /// <summary>
        /// Devolver (CUDE/CUFE) segun codigo tipo documento
        /// </summary>
        /// <param name="tcrCodigoTipo">Codigo tipo documento eletronico "01"=CUFE/"91"=CUDE/"92"=CUDE</param>
        /// <returns></returns>
        public static string FcrTipoDocCufeCude(string tcrCodigoTipo)
        {
            var lcrReturn = tcrCodigoTipo switch
            {
                "01" => "CUFE",
                "02" => "CUFE",
                "03" => "CUFE",
                "04" => "CUFE",
                "91" => "CUDE",
                "92" => "CUDE",
                _ => throw new Exception("NA"),
            };

            return lcrReturn;

        }
        #endregion FcrTipoDocCufeCude>

        #region FcrSeleccionInvoiceTypeCode: Tipo texto docummento FAD12
        /// <summary>
        /// <para>Tipo texto docummento FAD12 - Tipo Documento (/Invoice/cbc:InvoiceTypeCode)</para>
        /// <para>segun la tabla ->  6.1.3 Tipo de Documento: cbc:InvoiceTypeCode y cbc:CreditnoteTypeCode </para>
        /// </summary>
        /// <param name="tcrTipoDocumento"></param>
        /// <returns></returns>
        public static String FcrSeleccionInvoiceTypeCode(TipoDocumentoElectronico tcrTipoDocumento)
        {
            var lcrReturn = tcrTipoDocumento switch
            {
                TipoDocumentoElectronico.FacturaVenta => "01",                  // 01 - Factura electrónica de Venta
                TipoDocumentoElectronico.FacturaExportacion => "02",            // 02 - Factura electrónica de venta - Exportación
                TipoDocumentoElectronico.FacturaContingenciaFacturador => "03", // 03 - Documento electrónico de transmisión – tipo 03
                TipoDocumentoElectronico.FacturaContingenciaDian => "04",       // 04 - Factura electrónica de Venta - tipo 04
                TipoDocumentoElectronico.NotaCredito => "91",                   // 91 - Nota Crédito
                TipoDocumentoElectronico.NotaDebito => "92",                    // 92 - Nota Débito
                _ => throw new Exception(CasoNoConsiderado(tcrTipoDocumento)),
            };

            return lcrReturn;

        }
        #endregion FcrSeleccionInvoiceTypeCode: Tipo texto docummento FAD12>

        #region FcrGenerarCude: Para Generar Cufe o Cude
        /// <summary>
        /// FAD06: Genera el CUFE cuando el parametro tlgEsCufe=true / Genera CUDE cuando el parametro tlgEsCufe=false.
        /// </summary>
        /// <returns></returns>
        public static string FcrGenerarCude(ModeloFeFacturaMa tobFactura, bool tlgEsCufe)
        {
            //Composición del CUFE = SHA-384(NumFac + FecFac + HorFac + ValFac + CodImp1 + ValImp1 + CodImp2 + ValImp2 + CodImp3 + ValImp3 + ValTot + NitOFE + NumAdq + ClTec + TipoAmbie)

            var lcrNumeroFactura        = tobFactura.Fcm_numfac_mfac;
            var lcrFechaFactura         = tobFactura.Fcm_fecfac_mfac; // ojo aqui falta la hora
            var lcrValorIVA             = (decimal)tobFactura.Fcm_valiva_dfac;
            var lcrValorINC             = (decimal)tobFactura.Fcm_valinc_dfac;
            var lcrValorICA             = (decimal)tobFactura.Fcm_valica_dfac;
            var lcrValorSubTotalFactura = (decimal)tobFactura.Fcm_valbru_dfac; // sin ninguna deducción 
            var lcrValorTotalFactura    = (decimal)tobFactura.Fcm_valfac_dfac;
            var ldaFechaHora            = Funciones.FdaConcatenarFechaYHora(lcrFechaFactura, tobFactura.Fcm_horfac_mfac);

            var lcrFormatoFecha         = "yyyy-MM-dd";
            var lcrFormatoNumero        = "0.00";
            var formatoHora             = $"HH:mm:ss{HorasAjusteUtc.ATexto("00")}:00";

            var lcrTexto = $"{lcrNumeroFactura.Trim()}" +
                           $"{ldaFechaHora.ATexto(lcrFormatoFecha)}{ldaFechaHora.ATexto(formatoHora)}" +
                           $"{(lcrValorSubTotalFactura).ATexto(lcrFormatoNumero)}01"+
                           $"{lcrValorIVA.ATexto(lcrFormatoNumero)}04" +
                           $"{lcrValorINC.ATexto(lcrFormatoNumero)}03{lcrValorICA.ATexto(lcrFormatoNumero)}" +
                           $"{(lcrValorTotalFactura).ATexto(lcrFormatoNumero)}{Empresa.Nit}" +
                           $"{tobFactura.lobRegCliente.Sis_numide_sitr}";

            // se genera CUFE o CUDE
            if (tlgEsCufe)
            {
                lcrTexto += Empresa.ClaveTécnicaAplicación;
            }
            else
            {
                lcrTexto += Empresa.PinAplicación;
            }
            lcrTexto += Empresa.AmbienteFacturacionElectronica.AValor();

            return ObtenerSHA384(lcrTexto);

        } // ObtenerCude>

        #endregion FcrGenerarCude: Para Generar Cufe o Cude>

        #region FcrGenerarCodigoQR: Para Generar Codigo QR
        /// <summary>
        /// <para>FAB36: Genera codigo QR segun el ambiente de facturacion tambien cambia la URL.</para>
        /// </summary>
        /// <returns></returns>
        public static string FcrGenerarCodigoQR(ModeloFeFacturaMa tobFactura, string tcrCufe, out string tcrUrl)
        {
            /*
            NumFac: [NUMERO_FACTURA]
            FecFac: [FECHA_FACTURA]
            HorFac: [HORA_FACTURA(con GMT)]
            NitFac: [NIT FACTURADOR] sin puntos ni guiones
            DocAdq: [NUMERO_ID_ADQUIRENTE] sin puntos ni guiones
            ValFac: [VALOR_FACTURA] con punto decimal, con decimales a dos (2) dígitos, sin separadores de miles, ni símbolo pesos.
            ValIva: [VALOR_IVA] con punto decimal, con decimales a dos (2) dígitos, sin separadores de miles, ni símbolo pesos.
            ValOtroIm: [VALOR_OTROS_IMPUESTOS] con punto decimal, con decimales a dos (2) dígitos, sin separadores de miles, ni símbolo pesos.
            ValTolFac: [VALOR_TOTAL_FACTURA] con punto decimal, con decimales a dos (2) dígitos, sin separadores de miles, ni símbolo pesos.
            CUFE: [CUFE]
            QRCode: [URL disponible por la DIAN]
            */

            var lcrNumeroFactura    = tobFactura.Fcm_numfac_mfac;
            var lcrFechaFactura     = tobFactura.Fcm_fecfac_mfac; // ojo aqui falta la hora
            var lcrValorIVA         = (decimal)tobFactura.Fcm_valiva_dfac;
            var lcrValorOtrosImp    = (decimal)(tobFactura.Fcm_valinc_dfac + tobFactura.Fcm_valica_dfac);
            var lcrValorSubTotalFactura = (decimal)tobFactura.Fcm_valsub_dfac;
            var lcrValorTotalFactura    = (decimal)tobFactura.Fcm_valfac_dfac;
            var ldaFechaHora        = Funciones.FdaConcatenarFechaYHora(lcrFechaFactura, tobFactura.Fcm_horfac_mfac);
            var lcrUrlBase          = Empresa.AmbienteFacturacionElectronica == AmbienteFacturacionElectronica.Pruebas ?
                                                                                BaseUrlPruebas : BaseUrlProducción; // viene de Parametros Dian
            lcrUrlBase = $"https://catalogo-{lcrUrlBase}/document/searchqr?documentkey={tcrCufe}";
            tcrUrl = lcrUrlBase;

            var lcrFormatoFecha = "yyyy-MM-dd";
            var lcrFormatoNumero = "0.00";
            var formatoHora = $"HH:mm:ss{HorasAjusteUtc.ATexto("00")}:00";

            var lcrTexto = $"NumFac:{lcrNumeroFactura.Trim()} " +
                           $"FecFac:{ldaFechaHora.ATexto(lcrFormatoFecha)} " +
                           $"HorFac:{ldaFechaHora.ATexto(formatoHora)} " +
                           $"NitFac:{Empresa.Nit} " +
                           $"DocAdq:{tobFactura.lobRegCliente.Sis_numide_sitr} " +
                           $"ValFac:{(lcrValorSubTotalFactura).ATexto(lcrFormatoNumero)} " +
                           $"ValIva:{lcrValorIVA.ATexto(lcrFormatoNumero)} " +
                           $"ValOtroIm:{lcrValorOtrosImp.ATexto(lcrFormatoNumero)} " +
                           $"ValTolFac:{(lcrValorTotalFactura).ATexto(lcrFormatoNumero)} " +
                           $"CUFE:{tcrCufe} " +
                           $"QRCode:{lcrUrlBase}";

            return lcrTexto;

        } // FcrGenerarCodigoQR>

        #endregion FcrGenerarCodigoQR: Para Generar Codigo QR>

        #region FobGenerarAddressAdquirente
        public static AddressType FobGenerarAddressAdquirente(ModeloSismaesterceros tobRegCliente)
        {

            if (tobRegCliente == null) return null;

            /*
            var municipio = direcciónCompleta.Municipio;
            if (municipio == null || municipio.CódigoPaís == null || municipio.CódigoLenguajePaís == null || municipio.Código == null) return null; // Si no se conoce el país, el lenguaje del país o el código del municipio no se agregará el Address. Este elemento no siempre es obligatorio.
            */
            return new AddressType
            { // 1..1 FAJ08.
                ID                   = new IDType { Value = Validar(tobRegCliente.Sis_idemun_muni, "5") }, // 1..1 FAK09.
                CityName             = new CityNameType { Value = Validar(tobRegCliente.Sis_nommun_muni, "1..60", true) }, // 1..1 FAK10. Nombre
                PostalZone           = new PostalZoneType { Value = Validar(tobRegCliente.Sis_codpos_sicp, "1..10", true) }, // 0..1 FAK57 T1..10. Código postal. Ver lista de valores posibles en el numeral 13.4.4. Por lo general no se tiene ni se usa.
                CountrySubentity     = new CountrySubentityType { Value = Validar(tobRegCliente.Sis_desdep_dpto, "1..60", true) }, // 1..1 FAK11.
                CountrySubentityCode = new CountrySubentityCodeType { Value = Validar(tobRegCliente.Sis_coddep_dpto, "1..5") }, // 1..1 FAK12.
                AddressLine          = new AddressLineType[1] { // 1..N FAJ13.
                    new AddressLineType { Line = new LineType { Value = Validar(tobRegCliente.Sis_direcc_sitr ?? " ", "1..300", true) } } // 1..1 FAJ14. Elemento de texto libre, que el emisor puede elegir utilizar para poner toda la información de su dirección, en lugar de utilizar elementos estructurados (los demás elementos de este grupo). Informar la dirección, sin ciudad ni departamento. Estos dos textos de la documentación de la DIAN son contradictorios entonces se escribirá la dirección en este campo y se completarán los otros normalmente. Debido a que es un elemento obligatorio de largo 1 si por alguna razón no se dispone de la dirección se enviará un espacio en blanco.
                },
                Country = new CountryType
                { // 1..1 FAJ15.
                    IdentificationCode = new IdentificationCodeType { Value = Validar("CO", "1..3") }, // 1..1 FAK16. Debe informar literal "CO". El tamaño en la documentación dice 3 pero no puede ser 3, debe ser flexible para no contradecir el requerimiento de poner "CO".
                    Name = new NameType1
                    {
                        Value = Validar("Colombia", "4..41", true), // 0..1 FAK17. Debe informar el literal "Colombia".
                        languageID = Validar("es", "2"), // 0..1 FAK18.
                    },
                },
            };

        }
        #endregion FobGenerarAddressAdquirente>

        // Gestion Reumen general de Impuestos
        #region FobGenerarResumenImpuestos: resumen general impuestos
        /// <summary>
        /// Generar resumen general segun tipos y porcentajes de impuestos
        /// </summary>
        public static TaxTotalType[]? FobGenerarResumenImpuestos(ModeloFeFacturaMa tobRegFact)
        {
            TaxTotalType taxTotal;
            var taxTotales = new List<TaxTotalType>(); // 0..N FAS01, FAX01.
            List<ResumenImpuesto> tmpResumImp = null;
            var llgSiAdd = false;
            string lcrTipo;
            string lcrNombre;
            decimal ldePorcentaje;
            decimal ldeValorTotal;
            decimal ldeValorBase;

            foreach (var lobReg in tobRegFact.tmpListVenta)
            {
                // Resumen diferentes porcentajes de IVA 
                #region Resumen IVA

                lcrTipo = "01";
                lcrNombre = "IVA";
                ldePorcentaje = (decimal)lobReg.Fcm_poriva_dfac;
                ldeValorTotal = (decimal)lobReg.Fcm_valiva_dfac;
                ldeValorBase  = (decimal)lobReg.Fcm_valbsi_dfac;

                if (ldeValorTotal > 0)
                {
                    llgSiAdd = false;
                    if (tmpResumImp == null) { tmpResumImp = new List<ResumenImpuesto>(); }

                    // buscar si ya existe un registro para ese porcentaje de impuesto
                    var lobIVA = tmpResumImp.FirstOrDefault(x => x.Porcentaje == (decimal)lobReg.Fcm_poriva_dfac &&
                                                              x.Tipo == lcrTipo);
                    if (lobIVA == null)
                    {
                        lobIVA = new ResumenImpuesto();
                        llgSiAdd = true;
                    }

                    // Actualizar el registro
                    lobIVA.Tipo = lcrTipo; // para IVA
                    lobIVA.Nombre = lcrNombre + " " + (ldePorcentaje.ToString()).Replace(",",".");
                    lobIVA.Porcentaje = ldePorcentaje;
                    lobIVA.ValorTotal += ldeValorTotal;
                    lobIVA.ValorBase += ldeValorBase;

                    // Agregar a la lista
                    if (llgSiAdd == true) { tmpResumImp.Add(lobIVA); }
                }
                #endregion IVA>
            }

            // Generar registros 
            if (tmpResumImp != null)
            {
                foreach (var lobReg in tmpResumImp)
                {
                    taxTotal = FobOtenerTaxTotal(lobReg.Tipo,
                                                 lobReg.Nombre,
                                                 lobReg.ValorTotal,
                                                 lobReg.ValorBase,
                                                 lobReg.Porcentaje);

                    if (taxTotal != null) taxTotales.Add(taxTotal);
                }
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
            decimal ldePorcentaje = tdePorcentaje;
            var taxSubtotales = new List<TaxSubtotalType>();
            var lcrMoneda = Empresa.MunicipioFacturacion.Moneda;
            String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

            if (ldePorcentaje < 1) // cuando es esta expresado en decimales
            {
                ldePorcentaje = Convert.ToDecimal((ldePorcentaje.ToString()).Replace(gcrSeparadorDecimal, ""));
            }
            var taxTotalType = FobTaxTotalType(tdeValorImpuesto, lcrMoneda);
            var taxSubtotal = FobTaxSubtotalType(tcrCodigoTipo, tcrNombre, tdeValorImpuesto, lcrMoneda);

            taxSubtotal.TaxableAmount = new TaxableAmountType
            {
                Value = Validar(tdeBaseGravable, "0..15 p (2..6)", 2),
                currencyID = lcrMoneda // 1..1 FAS05, FAX05. currencyID: 1..1 FAS06, FAX06. En el caso de que el tributo sea una porcentaje del valor tributable informar la base imponible en valor monetario.
            };
            taxSubtotal.TaxCategory.Percent = new PercentType1
            {
                Value = Validar(ldePorcentaje, "0..5 p (0..3)", 2) // 0..1 FAS14, FAX14. Aunque en la tabla 13.3.9 no mencionan el 0 como un valor válido para el INC se permitirá el 0 porque se muestra en el ejemplo de XML.
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
                    Value = Validar(tdeTotalImpuesto, "0..15 p (2..6)", 2), // 1..1 FAS02, FAX02. 
                    currencyID = tcrMoneda // 1..1 FAS03, FAX03.
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
            { // 1..N FAS04, FAX04.      
                TaxAmount = new TaxAmountType { Value = Validar(tdeTotalImpuesto, "0..15 p (2..6)", 2), currencyID = tcrMoneda }, // 1..1 FAS07, FAX07. currencyID: 1..1 FAS08, FAX08.
                TaxCategory = new TaxCategoryType
                { // 1..1 FAS13, FAX13.
                    TaxScheme = new TaxSchemeType
                    { // 1..1 FAS15, FAX15.
                        ID = new IDType { Value = Validar(tcxrTipo, "2..10") }, // 1..1 FAS16, FAX16. Aunque la documentación dice tamaño 3..10 esto va en contradicción con el código "ZZ", se usa entonces 2..10.
                        Name = new NameType1 { Value = Validar(tcrNombre, "2..30") }, // 1..1 FAS17, FAX17. Aunque la documentación dice tamaño 10..30 esto va en contradicción con el nombre "IC", se usa entonces 2..30.
                    }
                },
            };
            return lobTaxSubtotal;
        }
        #endregion FobTaxTotalType>

        //-----------------------------------------------------------
        // Funciones de Gestion archivos
        //-----------------------------------------------------------

        #region FcrGenNombreArchivoSegunTipo: Generar nombre del archivo segun tipo 
        /// <summary>
        /// Generar nombre del archivo segun tipo Factura/NotaCredito/NotaDebito y si es firmado o no
        /// </summary>
        /// <param name="tenTipoFirma">Tipo firma fv=Factura nc=Nota Credito nd=Nota Debito.</param>
        /// <param name="tlgFirmado">true = Generar nombre y ruta del archivo firmado false=Generar nombre archivo y ruta sin firma.</param>
        /// <returns></returns>
        public static string FcrGenNombreArchivoSegunTipo(TipoFirma tenTipoFirma, bool tlgFirmado, bool tlgConExtencion = true)
        {

            if (Empresa.Nit == null) throw new Exception("El nit de la empresa es nulo.");
            if (Empresa.ConsecutivoDianAnual == 0) throw new Exception("El consecutivo de la DIAN anual debe ser mayor que cero.");

            var lcrPrefijo = tenTipoFirma.ATexto();
            string lcrPreFirmado = "";

            if (tenTipoFirma != TipoFirma.Attached)
            {
                lcrPreFirmado = tlgFirmado ? "" : "-sf";
            }
            var lcrNombreArchivo = $"{lcrPrefijo}{Empresa.Nit.PadLeft(10, '0')}000" +
                                   $"{AhoraUtcAjustado.ATexto("yy")}" +
                                   $"{((int)Empresa.ConsecutivoDianAnual).ATexto().PadLeft(8, '0')}" +
                                   $"{lcrPreFirmado}{(tlgConExtencion ? ".xml" : "")}";

            return lcrNombreArchivo;

        } // ObtenerRuta>
        #endregion FcrGenNombreArchivoSegunTipo>

        #region FcrGenArchivoNombreYRutaDestino: Generar nombre del archivo y ruta destino
        /// <summary>
        /// Generar el nombre de archivo xml con la ruta para destino sin firma o para destino firmado
        /// </summary>
        /// <param name="tenTipoFirma">Tipo firma fv=Factura nc=Nota Credito nd=Nota Debito.</param>
        /// <param name="tlgFirmado">true = Generar nombre y ruta del archivo firmado false=Generar nombre archivo y ruta sin firma.</param>
        /// <returns></returns>
        public static string FcrGenArchivoNombreYRutaDestino(TipoFirma tenTipoFirma, bool tlgFirmado)
        {

            var lcrNombreArchivo = FcrGenNombreArchivoSegunTipo(tenTipoFirma, tlgFirmado);

            if (tlgFirmado == true)
            {
                return Path.Combine(Empresa.RutaDocumentoFirmado, lcrNombreArchivo);
            }
            else
            {
                return Path.Combine(Empresa.RutaDocumentoSinFirmar, lcrNombreArchivo);
            }

        } // ObtenerRuta>
        #endregion FcrGenArchivoNombreYRutaDestino>

        // Funciones de gestion archivo
        #region FlgFirmarArchivo: Genera el archivo firmado en formato .XML y en Foramto .ZIP
        /// <summary>
        /// Genera el archivo firmado en formato .XML y lo copia en la ruta destino dada en parametro.
        /// </summary>
        /// <param name="tenTipoFirma">Tipo documento a firmar: Factura/NotaCredito/NotaDevito/Eventos</param>
        /// <param name="tdaFechaFirma">Fecha en que se firma el documento</param>
        /// <param name="tcrRutaArchivoSinFirmar">Ruta y Nombre donde se encuentra el archivo en formato .XML para firmar(el archivo debe existir en fisico)</param>
        /// <param name="tcrRutaArchivoDestinoXmlFirmado">Ruta y nombre del archivo en formato .XML para guardar como destino al generar la firma</param>
        /// <param name="tcrMensajeError">Devuelve el mensaje de error en caso de ocurrir</param>
        /// <returns></returns>
        public static bool FlgFirmarArchivo(TipoFirma tenTipoFirma, 
                                            DateTime tdaFechaFirma,    
                                            string tcrRutaArchivoSinFirmar,
                                            string tcrRutaArchivoDestinoXmlFirmado,
                                            out string tcrMensajeError)
        {
            var llgReturn            = true;
            tcrMensajeError          = null;
            var larArchivoXml        = new FileInfo(tcrRutaArchivoSinFirmar); // Ejemplo "C:/Proyectos/TiggerPack20/GaleriaRecursos/FacturacionEletronica/Facturas/SinFirmar/fv08240046880002000000001-sf.xml"
            byte[] lbyDocumenFirmado = null;

            // crear instancia
            var lobFirma = new FirmaElectronica
            {
                RolFirmante = RolFirmante.EMISOR,
                RutaCertificado = Empresa.CertificadoRutaArchivo,     //"C:/Proyectos/TiggerPack20/GaleriaRecursos/FacturacionEletronica/Certificado/Certificado.pfx"
                ClaveCertificado = Empresa.CertificadoClaveAcceso     // "gvPRcEKnx9"
            };

            #region Firmar documentos

            // Factura
            if (tenTipoFirma == TipoFirma.Factura)
            {
                lbyDocumenFirmado = lobFirma.FirmarFactura(larArchivoXml, tdaFechaFirma);
            }
            // Nota Credito
            if (tenTipoFirma == TipoFirma.NotaCrédito)
            {
                lbyDocumenFirmado = lobFirma.FirmarNotaCredito(larArchivoXml, tdaFechaFirma);
            }
            // Nota Debito
            if (tenTipoFirma == TipoFirma.NotaDébito)
            {
                lbyDocumenFirmado = lobFirma.FirmarNotaDebito(larArchivoXml, tdaFechaFirma);
            }
            // Eventos
            if (tenTipoFirma == TipoFirma.Evento)
            {
                lbyDocumenFirmado = lobFirma.FirmarEvento(larArchivoXml, tdaFechaFirma);
            }
            #endregion Firmar documentos>

            // usar horario colombiano
            //var ldaFecha = DateTime.Now;

            if (lbyDocumenFirmado != null)
            {
                // guardar xml firmado
                File.WriteAllBytes(tcrRutaArchivoDestinoXmlFirmado, lbyDocumenFirmado); // "C:/Proyectos/TiggerPack20/GaleriaRecursos/FacturacionEletronica/Facturas/Firmadas/PendienteEnvio/fv08240046880002000000002.xml"
            }
            else
            {
                tcrMensajeError = "No hay contenido para firmar o se especificó un tipo de documento errado.";
                llgReturn = false;
            }

            return llgReturn;
        }
        #endregion FlgFirmarArchivo>
        // Documento Factura
        #region FlgGenerarDocumentoFactura: Consulta en maestro facturas para generar XML
        /// <summary>
        /// Consulta en el maestro facturas para generar el documento tipo Factura en formato .XML y lo guardad 
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tcrNumDocumento">Numero de factura existente en la base de datos</param>
        /// <param name="tobRegFactura">Devuelve una referencia al Registro factura usado para generar el XML</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento factura para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoFactura(string tcrNumDocumento, out ModeloFeFacturaMa tobRegFactura, out string tcrMensaje, out DocumentoFactura tobRefFact)
        {
            tobRefFact = null;

            tobRegFactura = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("NF", tcrNumDocumento);

            if (tobRegFactura == null)
            {
                tcrMensaje = $"No se econtró la factura {tcrNumDocumento} en maestro.";
                return false;
            }

            return FlgGenerarDocumentoFactura(tobRegFactura, out tcrMensaje, out tobRefFact);

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoFactura>
        #region FlgGenerarDocumentoFactura: Generar Factura XML desde registro dado en prametro
        /// <summary>
        /// Generar el documento tipo Factura en formato .XML segun registro dado en parametro y lo guarda
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tobRegFactura">Registro de factura existente en la base de datos</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento factura para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoFactura(ModeloFeFacturaMa tobRegFactura, out string tcrMensaje, out DocumentoFactura tobRefFact)
        {
            tcrMensaje = null;
            tobRefFact = null;

            if (tobRegFactura == null)
            {
                tcrMensaje = $"El registro dado en parametro no es valido.";
                return false;
            }

            // iniciar la clase principal documento electronico
            var lobFactura = new DocumentoFactura()
            {
                Tipo = TipoDocumentoElectronico.FacturaVenta,
            };

            // asignar el consecutivo del envio a la clase publica 
            Empresa.ConsecutivoDianAnual = tobRegFactura.Fcm_secrad_mfac;

            if (!lobFactura.FlgCrearDocumento(tobRegFactura, out string tcrMensajeCreacion))
            {
                return Falso(out tcrMensaje, $"Error creando documento electrónico.{DobleLínea}{tcrMensajeCreacion}");
            }
            else
            {
                tobRefFact = lobFactura;
            }

            return true;

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoFactura>
        // Documento Nota Credito
        #region FlgGenerarDocumentoNotaCredito: Consulta en maestro facturas para generar XML
        /// <summary>
        /// Consulta en el maestro facturas para generar el documento tipo NotaCredito en formato .XML y lo guardad 
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tcrNumDocumento">Numero documento NotaCredito existente en la base de datos</param>
        /// <param name="tobRegDocumento">Devuelve una referencia al Registro Nota Credito usado para generar el XML</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento NotaCredito para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoNotaCredito(string tcrNumDocumento, out ModeloFeFacturaMa tobRegDocumento, out string tcrMensaje, out DocumentoNotaCredito tobRefFact)
        {
            tcrMensaje = null;
            tobRefFact = null;

            tobRegDocumento = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("NF", tcrNumDocumento);

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"No se econtró la factura {tcrNumDocumento} en maestro.";
                return false;
            }

            return FlgGenerarDocumentoNotaCredito(tobRegDocumento, out tcrMensaje, out tobRefFact);
            /*
            tobRegDocumento = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("NF", tcrNumDocumento);

            // iniciar la clase principal documento electronico
            var lobNotaCredito= new DocumentoNotaCredito()
            {
                Tipo = TipoDocumentoElectronico.NotaCredito,
            };

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"No se econtró la factura {tcrNumDocumento} en maestro.";
                return false;
            }
            // asignar el consevutivo del envio a la clase publica 
            Empresa.ConsecutivoDianAnual = tobRegDocumento.Fcm_secrad_mfac;

            if (!lobNotaCredito.FlgCrearDocumento(tobRegDocumento, out string tcrMensajeCreacion))
            {
                return Falso(out tcrMensaje, $"Error creando documento electrónico Nota Credito.{DobleLínea}{tcrMensajeCreacion}");
            }
            else
            {
                tobRefFact = lobNotaCredito;
            }

            return true;
            */

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoNotaCredito>
        #region FlgGenerarDocumentoNotaCredito: Generar Nota Credito XML desde registro dado en parametro
        /// <summary>
        /// Generar el documento tipo NotaCredito en formato .XML desde registro dado en parametro y lo guarda 
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tobRegDocumento">Registro Nota Credito existente en la base de datos</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento NotaCredito para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoNotaCredito(ModeloFeFacturaMa tobRegDocumento, out string tcrMensaje, out DocumentoNotaCredito tobRefFact)
        {
            tcrMensaje = null;
            tobRefFact = null;

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"El registro dado en parametro no es valido.";
                return false;
            }

            // iniciar la clase principal documento electronico
            var lobNotaCredito = new DocumentoNotaCredito()
            {
                Tipo = TipoDocumentoElectronico.NotaCredito,
            };

            // asignar el consevutivo del envio a la clase publica 
            Empresa.ConsecutivoDianAnual = tobRegDocumento.Fcm_secrad_mfac;

            if (!lobNotaCredito.FlgCrearDocumento(tobRegDocumento, out string tcrMensajeCreacion))
            {
                return Falso(out tcrMensaje, $"Error creando documento electrónico Nota Credito.{DobleLínea}{tcrMensajeCreacion}");
            }
            else
            {
                tobRefFact = lobNotaCredito;
            }

            return true;

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoNotaCredito>
        // Documento Nota Debito
        #region FlgGenerarDocumentoNotaDebito: Consulta en el maestro facturas para generar XML
        /// <summary>
        /// Consulta en el maestro facturas para generar el documento tipo NotaDebito en formato .XML y lo guardad 
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tcrNumDocumento">Numero del documento tipo NotaDebito existente en la base de datos</param>
        /// <param name="tobRegDocumento">Devuelve una referencia al Registro Nota Debito usado para generar el XML</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento NotaDebito para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoNotaDebito(string tcrNumDocumento, out ModeloFeFacturaMa tobRegDocumento, out string tcrMensaje, out DocumentoNotaDebito tobRefFact)
        {
            tcrMensaje = null;
            tobRefFact = null;

            tobRegDocumento = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("NF", tcrNumDocumento);

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"No se econtró la factura {tcrNumDocumento} en maestro.";
                return false;
            }

            return FlgGenerarDocumentoNotaDebito(tobRegDocumento, out tcrMensaje, out tobRefFact);

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoNotaCredito>
        #region FlgGenerarDocumentoNotaDebito: Generar Nota Debito XML desde registro dado en parametro
        /// <summary>
        /// Generar el documento tipo Nota Debito en formato .XML desde registro dado en parametro y lo guarda 
        /// en la ruta de archivos para firmar (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tobRegDocumento">Registro Nota Debito existente en la base de datos</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefFact">Devuelve una referencia al objeto documento NotaDebito para gestión</param>
        /// <returns></returns>
        public static bool FlgGenerarDocumentoNotaDebito(ModeloFeFacturaMa tobRegDocumento, out string tcrMensaje, out DocumentoNotaDebito tobRefFact)
        {
            tcrMensaje = null;
            tobRefFact = null;

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"El registro dado en parametro no es valido.";
                return false;
            }

            // iniciar la clase principal documento electronico
            var lobNotaDebito = new DocumentoNotaDebito()
            {
                Tipo = TipoDocumentoElectronico.NotaDebito,
            };

            // asignar el consevutivo del envio a la clase publica 
            Empresa.ConsecutivoDianAnual = tobRegDocumento.Fcm_secrad_mfac;

            if (!lobNotaDebito.FlgCrearDocumento(tobRegDocumento, out string tcrMensajeCreacion))
            {
                return Falso(out tcrMensaje, $"Error creando documento electrónico Nota Debito.{DobleLínea}{tcrMensajeCreacion}");
            }
            else
            {
                tobRefFact = lobNotaDebito;
            }

            return true;

        } // FlgGenerarDocumentoFactura>
        #endregion FlgGenerarDocumentoNotaCredito>

        // Documento Attached - Adjunto
        #region FlgGenerarDocumentoAttacehd: Generar Archivo Adjunto (Attached) XML desde registro dado en parametro
        /// <summary>
        /// Generar el documento tipo Adjunto en formato .XML desde registro dado en parametro y lo guarda 
        /// en la ruta de archivos (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tcrNumDocumento">Registro unico ("ID") del documento existente en la base de datos</param>
        /// <param name="tobParamDocument">Contiene los datos en formato XML del documento (FA/NC/ND) y el Response DIAN</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefAttacehd">Devuelve una referencia al objeto documento Attacehd para gestión</param>
        /// <returns>Generar el documento tipo Adjunto en formato .XML</returns>
        public static bool FlgGenerarDocumentoAttached(string tcrNumDocumento,
                                                       out ModeloFeFacturaMa tobRegDocumento,
                                                       out string tcrMensaje,
                                                       out DocumentoAttached tobRefAttacehd)
        {
            tcrMensaje = null;
            tobRefAttacehd = null;

            tobRegDocumento = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", tcrNumDocumento);

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"No se econtró el documento {tcrNumDocumento} en maestro.";
                return false;
            }

            return FlgGenerarDocumentoAttached(tobRegDocumento,
                                               out tcrMensaje, 
                                               out tobRefAttacehd);

        }
        #endregion FlgGenerarDocumentoAttached>
        #region FlgGenerarDocumentoAttacehd: Generar Archivo Adjunto (Attached) XML desde registro dado en parametro
        /// <summary>
        /// Generar el documento tipo Adjunto en formato .XML desde registro dado en parametro y lo guarda 
        /// en la ruta de archivos (genera el archivo fisico), tambien genera los nombres 
        /// (no genera archivos fisicos) de archivos .zip y rutas de gestion 
        /// </summary>
        /// <param name="tobRegDocumento">Registro en maestro documentos existente en la base de datos</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefAttacehd">Devuelve una referencia al objeto documento Attacehd para gestión</param>
        /// <returns>Generar el documento tipo Adjunto en formato .XML</returns>
        public static bool FlgGenerarDocumentoAttached(ModeloFeFacturaMa tobRegDocumento,
                                                       out string tcrMensaje, 
                                                       out DocumentoAttached tobRefAttacehd)
        {
            tobRefAttacehd = null;

            if (tobRegDocumento == null)
            {
                tcrMensaje = $"El registro dado en parametro no es valido.";
                return false;
            }
            if (FlgConsultarDianAttached(tobRegDocumento, out ParamDocAttachment tobParamDocument, out tcrMensaje))
            {
                // iniciar la clase principal documento electronico
                var lobAttached = new DocumentoAttached();

                // asignar el consevutivo del envio a la clase publica 
                Empresa.ConsecutivoDianAnual = tobRegDocumento.Fcm_secrad_mfac;

                if (!lobAttached.FlgCrearDocumento(tobRegDocumento, tobParamDocument, out string tcrMensajeCreacion))
                {
                    return Falso(out tcrMensaje, $"Error creando documento electrónico Attached (Adjunto).{DobleLínea}{tcrMensajeCreacion}");
                }
                else
                {
                    tobRefAttacehd = lobAttached;

                    var xmlDoc = File.ReadAllText(tobRefAttacehd.DocGenNombreXmlRutaSinFirma);

                    xmlDoc = xmlDoc.Replace("-DOCUMENTO-", "<![CDATA[" + tobParamDocument.AttachmentDocument + "]]>");
                    xmlDoc = xmlDoc.Replace("-ApplicationResponse-", "<![CDATA[" + tobParamDocument.AttachmentResponse + "]]>");
                    // Gaurdar el archivo en la nueva ruta 
                    File.WriteAllText(@tobRefAttacehd.DocGenNombreXmlRutaFirmado, xmlDoc, Encoding.UTF8);
                }
            }

            return true;
        }
        #endregion FlgGenerarDocumentoAttached>
        #region FlgConsultarDianAttached: Consultar el response y el XNL del documento en la Dian
        /// <summary>
        /// Consultar el response y el XNL del documento en la Dian
        /// </summary>
        /// <param name="tobRegDocumento">Temporal de datos Maestro factura electronica</param>
        /// <param name="tobParamDocument">Contiene los datos en formato XML del documento (FA/NC/ND) y el Response DIAN</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRefAttacehd">Devuelve una referencia al objeto documento Attacehd para gestión</param>
        /// <returns>Consultar los archivos en formato XML en la DIAN</returns>
        public static bool FlgConsultarDianAttached(ModeloFeFacturaMa tobRegDocumento,
                                                    out ParamDocAttachment tobParamDocument,
                                                    out string tcrMensaje)
        {
            var llgSigPaso = false;
            tcrMensaje = null;
            tobParamDocument = new ParamDocAttachment();

            Empresa.FcvCargarRazonSocial("ID", tobRegDocumento.Fcm_secraz_fcem);

            // leer el response
            if (FlgConsultarGetStatusDocumento(tobRegDocumento.Fcm_idcufe_mfac.Trim(), out tcrMensaje, out XmlDocument lobRespuestaXml))
            {
                if (FlgCargarFromBase64String("b:XmlBase64Bytes", lobRespuestaXml, out string tcrStringRespuesta))
                {
                    //tobParamDocument.AttachmentResponse = lobRespuestaXml.DocumentElement.OuterXml;
                    llgSigPaso = true;
                    tobParamDocument.AttachmentResponse = tcrStringRespuesta;

                    // Cargar datos de validación documento
                    #region Cargar Fecha y hora de validacion
                    var lobXml = new XmlDocument();
                    lobXml.LoadXml(tcrStringRespuesta);

                    // Fecha generación response validación 
                    var lobNodos = lobXml.DocumentElement.GetElementsByTagName("cbc:IssueDate");
                    if (lobNodos.Count > 0)
                    {
                        tobParamDocument.IssueDate = DateTime.Parse(lobNodos[0].InnerText);
                    }
                    // Hora generación response validación 
                    lobNodos = lobXml.DocumentElement.GetElementsByTagName("cbc:IssueTime");
                    if (lobNodos.Count > 0)
                    {
                        tobParamDocument.IssueTime = lobNodos[0].InnerText;
                    }
                    #endregion
                }
            }
            if (llgSigPaso == true)
            {
                if (FlgConsultarGetXmlByDocumentKey(tobRegDocumento.Fcm_idcufe_mfac.Trim(), out tcrMensaje, out lobRespuestaXml))
                {
                    if (FlgCargarFromBase64String("b:XmlBytesBase64", lobRespuestaXml, out string tcrStringRespuesta))
                    {
                        llgSigPaso = true;
                        tobParamDocument.AttachmentDocument = tcrStringRespuesta;
                        //tobParamDocument.AttachmentDocument = lobRespuestaXml.DocumentElement.OuterXml;
                    }
                }
            }

            return llgSigPaso;
        }
        #endregion FlgGenerarDocumentoAttached>

        // Generar ZIP desde XML
        #region FbyGenerarArchivoZipDesdeXmlYCargar: Generar ZIP desde XML y cargar en  byte[]
        /// <summary>
        /// Dado el archivo en formato XML se genera el archivo .ZIP  y luego se carga en tipo byte[]
        /// </summary>
        /// <param name="tcrRutaYNombreArchivoXml">Ruta y Nombre fisico del archivo .XML</param>
        /// <param name="tcrRutaDestinoZip">Ruta y nombre del archivo destino para el ZIP</param>
        /// <returns></returns>
        public static byte[] FbyGenerarArchivoZipDesdeXmlYCargar(string tcrRutaYNombreArchivoXml, string? tcrRutaDestinoZip = null)
        {

            if (tcrRutaDestinoZip == null) { tcrRutaDestinoZip = ObtenerRutaCambiandoExtension(tcrRutaYNombreArchivoXml, "zip"); }

            if (!File.Exists(tcrRutaYNombreArchivoXml)) return null;

            // generar archivo comprimido apartir del archivo xml firmado, si ya existe lo sobre escribe
            CrearZip(tcrRutaYNombreArchivoXml, tcrRutaDestinoZip);

            if (!File.Exists(tcrRutaDestinoZip)) return null;

            byte[] lbyArchivo = File.ReadAllBytes(tcrRutaDestinoZip);

            return lbyArchivo;

        }
        #endregion FarLeerDatosArchivo>
        //----------------------------------------------------------
        // Procesos gestion Web Service DIAN 
        //----------------------------------------------------------
        // GetStatusZip
        #region FlgConsultarGetStatusZip: Realiza consulta de estado documento zip enviado para validacion
        /// <summary>
        /// Dado el Codigo ZipKey del envio a Validacion, Realiza consulta de estado documento zip enviado para validacion y devuelve XML 
        /// entregado por el servicio DIAN
        /// </summary>
        /// <param name="tcrCodigoRadicado">Codigo ZipKey entregado en el momento del envio del documento a la DIAN</param>
        /// <param name="tcrMemsaje">Mensaje de respuesta segun gestión</param>
        /// <param name="tobXmlRespuesta">Devuelve el XML del Response DIAN</param>
        /// <returns></returns>
        public static bool FlgConsultarGetStatusZip(string tcrCodigoZipKey, out string tcrMensaje, out XmlDocument tobXmlRespuesta)
        {
            var llgReturn = true;

            if (!FlgEnviarSolicitud("<wcf:GetStatusZip><wcf:trackId>" + tcrCodigoZipKey + "</wcf:trackId></wcf:GetStatusZip>", Operación.GetStatusZip,
                  out tcrMensaje, out tobXmlRespuesta))
            {
                tcrMensaje = "Error en Solicitud StatusZip DIAN // " + tcrMensaje;
                llgReturn = false;
            }

            return llgReturn;
        }
        #endregion FlgConsultarGetStatusZip
        // GetStatus
        #region FlgConsultarGetStatusDocumento
        /// <summary>
        /// Realiza la consulta del estado documento radicado en la Dian y devuelve XML 
        /// entregado por el servicio DIAN
        /// </summary>
        /// <param name="tcrCodigoRadicado">Codigo Cufe/Cude del documento</param>
        /// <param name="tcrMemsaje">Mensaje de respuesta segun conexion al servidor DIAN</param>
        /// <param name="tobXmlRespuesta">Devuelve el XML del Response DIAN</param>
        /// <returns></returns>
        public static bool FlgConsultarGetStatusDocumento(string tcrCodigoRadicado, out string tcrMensaje, out XmlDocument tobXmlRespuesta)
        {
            var llgReturn = true;

            if (!FlgEnviarSolicitud("<wcf:GetStatus><wcf:trackId>" + tcrCodigoRadicado + "</wcf:trackId></wcf:GetStatus>", Operación.GetStatus,
                  out tcrMensaje, out tobXmlRespuesta))
            {
                tcrMensaje = "Error en Solicitud Radicado a DIAN // " + tcrMensaje;
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion FlgConsultarGetStatusDocumento
        // GetXmlByDocumentKey
        #region FlgConsultarGetXmlByDocumentKey
        /// <summary>
        /// Descargar el XML de un documento radicado en la DIAN
        /// </summary>
        /// <param name="tcrCodigoRadicado">Codigo Cufe/Cude del documento</param>
        /// <param name="tcrMemsaje">Mensaje de respuesta segun conexion al servidor DIAN</param>
        /// <param name="tobXmlRespuesta">Devuelve el XML del Response DIAN</param>
        /// <returns></returns>
        public static bool FlgConsultarGetXmlByDocumentKey(string tcrCodigoRadicado, out string tcrMensaje, out XmlDocument tobXmlRespuesta)
        {
            var llgReturn = true;

            if (!FlgEnviarSolicitud("<wcf:GetXmlByDocumentKey><wcf:trackId>" + tcrCodigoRadicado + "</wcf:trackId></wcf:GetXmlByDocumentKey>", Operación.GetXmlByDocumentKey,
                  out tcrMensaje, out tobXmlRespuesta))
            {
                tcrMensaje = "Error en Solicitud Radicado a DIAN // " + tcrMensaje;
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion FlgConsultarGetXmlByDocumentKey

        // SendBillSync
        #region flgEnviarSendBillSync: Envía el documento ZIP a la DIAN.
        /// <summary>
        /// Genera el archivo .ZIP y envía el documento electrónico empaquetado en ZIP a la DIAN. (para modo produccion facturación)
        /// </summary>
        /// <param name="tcrNombreArchivoXml">Nombre fisico del archivo .XML firmado para para enviar</param>
        /// <param name="tcrRuta">Ruta del archivo firmado .XML</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRespuestaXml">Devuelve el XML Response resultante del envio a la DIAN</param>
        /// <returns></returns>
        public static bool FlgEnviarSendBillSync(string tcrNombreArchivoXml, string tcrRuta, out string? tcrMensaje, out XmlDocument? tobRespuestaXml)
        {
            var lcrRutaArchivoFirmado = tcrRuta + @"\" +tcrNombreArchivoXml; // nombre del archivo con extension .xml

            return FlgEnviarSendBillSync(lcrRutaArchivoFirmado, out tcrMensaje, out tobRespuestaXml);

        }
        #endregion FlgEnviarSendBillSync>
        #region flgEnviarSendBillSync: Envía el documento ZIP a la DIAN (funcion sobrecarga).
        /// <summary>
        /// Genera el archivo .ZIP y envía el documento electrónico empaquetado en ZIP a la DIAN. (para modo produccion facturación)
        /// </summary>
        /// <param name="tcrRutaYNombreArchivoXml">Ruta y Nombre fisico del archivo .XML o .ZIP firmado para para enviar</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRespuestaXml">Devuelve el XML Response resultante del envio a la DIAN</param>
        /// <returns></returns>
        public static bool FlgEnviarSendBillSync(string tcrRutaYNombreArchivoXml, out string? tcrMensaje, out XmlDocument? tobRespuestaXml)
        {
            tobRespuestaXml = null;
            var lcrArchivoZIP = Path.GetFileName(tcrRutaYNombreArchivoXml).Reemplazar("xml", "zip");
            byte[] larArchivo = FbyGenerarArchivoZipDesdeXmlYCargar(tcrRutaYNombreArchivoXml);

            if (larArchivo == null)
            {
                tcrMensaje = "No fue posible cargar el archivo comprimido para ser enviado.";
                return false;
            }

            var lcrCuerpo = $"<wcf:SendBillSync>" +
                             $"<wcf:fileName>{lcrArchivoZIP}</wcf:fileName>" +
                             $"<wcf:contentFile>{Convert.ToBase64String(larArchivo)}</wcf:contentFile>" +
                         $"</wcf:SendBillSync>";

            return FlgEnviarSolicitud(lcrCuerpo, Operación.SendBillSync, out tcrMensaje, out tobRespuestaXml);

        }
        #endregion FlgEnviarSendBillSync>
        // SendTestSetAsync
        #region FlgSendTestSetAsync: Envía el documento ZIP a la DIAN SET de Pruebas.
        /// <summary>
        /// Genera el archivo .ZIP y envía el documento electrónico empaquetado en ZIP a la DIAN. (para modo set de pruebas facturación)
        /// </summary>
        /// <param name="tcrNombreArchivo">Nombre fisico del archivo .XML firmado para para enviar</param>
        /// <param name="tcrRuta">Ruta del archivo firmado .XML</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRespuestaXml">Devuelve el XML Response resultante del envio a la DIAN</param>
        /// <returns></returns>
        public static bool FlgSendTestSetAsync(string tcrNombreArchivo, string tcrRuta, out string? tcrMensaje, out XmlDocument? tobRespuestaXml)
        {
            var lcrRutaArchivoFirmado = tcrRuta + @"\" + tcrNombreArchivo; // nombre del archivo con extension .xml

            return FlgSendTestSetAsync(lcrRutaArchivoFirmado, out tcrMensaje, out tobRespuestaXml);

        } // Enviar>
        #endregion Enviar FlgSendTestSetAsync>
        #region FlgSendTestSetAsync: Envía el documento ZIP a la DIAN SET de Pruebas (funcion sobrecarga).
        /// <summary>
        /// Envía el documento electrónico firmado empaquetado en un ZIP a la DIAN. (para modo set de pruebas facturación)
        /// </summary>
        /// <param name="tcrRutaYNombreArchivoXml">Ruta y Nombre fisico del archivo .XML firmado para para enviar</param>
        /// <param name="tcrMensaje">Cuando ocurre algún error se informa en este parametro</param>
        /// <param name="tobRespuestaXml">Devuelve el XML Response resultante del envio a la DIAN</param>
        /// <returns></returns>
        public static bool FlgSendTestSetAsync(string tcrRutaYNombreArchivoXml, out string? tcrMensaje, out XmlDocument? tobRespuestaXml)
        {
            tobRespuestaXml = null;
            var lcrArchivoZIP = Path.GetFileName(tcrRutaYNombreArchivoXml).Reemplazar("xml", "zip");
            byte[] larArchivo = FbyGenerarArchivoZipDesdeXmlYCargar(tcrRutaYNombreArchivoXml);

            if (larArchivo == null)
            {
                tcrMensaje = "No fue posible cargar el archivo comprimido para ser enviado.";
                return false;
            }

            var lcrCuerpo = $"<wcf:SendTestSetAsync>" +
                             $"<wcf:fileName>{lcrArchivoZIP}</wcf:fileName>" +
                             $"<wcf:contentFile>{Convert.ToBase64String(larArchivo)}</wcf:contentFile>" +
                             $"<wcf:testSetId>{Empresa.IdentificadorPruebas}</wcf:testSetId>" +
                         $"</wcf:SendTestSetAsync>";

            return FlgEnviarSolicitud(lcrCuerpo, Operación.SendTestSetAsync, out tcrMensaje, out tobRespuestaXml);

        } // Enviar>
        #endregion Enviar FlgSendTestSetAsync>
        // GetStatus
        #region FlgConsultarGetNumberingRange
        /// <summary>
        /// Consultar los rangos de factuación aprobados
        /// </summary>
        /// <param name="tcrNitEmpresa">Nit de la razon social que lanza la solicitud</param>
        /// <param name="tcrIdSoftwareAplicacion">Codigo identificador del software habilitado en Dian para la Empresa</param>
        /// <param name="tcrMemsaje">Mensaje de respuesta segun conexion al servidor DIAN</param>
        /// <param name="tobXmlRespuesta">Devuelve el XML del Response DIAN</param>
        /// <returns></returns>
        public static bool FlgConsultarGetNumberingRange(string tcrNitEmpresa, string tcrIdSoftwareAplicacion, out string tcrMensaje, out XmlDocument tobXmlRespuesta)
        {
            var llgReturn = true;
            var lcrCuerpo = $"<wcf:GetNumberingRange>" +
                                $"<wcf:accountCode>{tcrNitEmpresa}</wcf:accountCode>" +
                                $"<wcf:accountCodeT>{tcrNitEmpresa}</wcf:accountCodeT>" +
                                $"<wcf:softwareCode>{tcrIdSoftwareAplicacion}</wcf:softwareCode>" +
                             $"</wcf:GetNumberingRange>";

            if (!FlgEnviarSolicitud(lcrCuerpo, Operación.GetNumberingRange,
                  out tcrMensaje, out tobXmlRespuesta))
            {
                tcrMensaje = "Error en Solicitud Clave Tecnica Produccion DIAN // " + tcrMensaje;
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion FlgConsultarGetNumberingRange
        // Sobre y solicitud
        #region FlgEnviarSobre: Enviar sobre al WS Dian
        /// <summary>
        /// Se conecta al servicio web de la DIAN y envía un sobre XML con el contenido de la solicitud y la firma electrónica.
        /// </summary>
        public static bool FlgEnviarSobre(string tcrSobre, Operación tobOperacion, out string? tcrMensaje, out XmlDocument? tobRespuestaXml)
        {

            tcrMensaje = null;
            tobRespuestaXml = null;

            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Obliga a usar TLS 1.2 en las conexiones seguras.
                var solicitud = (HttpWebRequest)WebRequest.Create(new Uri($"https://{BaseUrl}/WcfDianCustomerServices.svc"));
                solicitud.Method = "POST";
                solicitud.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                solicitud.ContentType = $@"application/soap+xml;charset=UTF-8;action=""http://wcf.dian.colombia/IWcfDianCustomerServices/{tobOperacion}""";
                solicitud.ContentLength = tcrSobre.Length;
                solicitud.KeepAlive = true;
                solicitud.Host = BaseUrl;
                solicitud.UserAgent = WebAplicación;
                using (var flujo = solicitud.GetRequestStream())
                {
                    var bytes = Encoding.UTF8.GetBytes(tcrSobre);
                    flujo.Write(bytes, 0, bytes.Length);
                }

                tobRespuestaXml = FobObtenerXml((HttpWebResponse)solicitud.GetResponse());

            }
            catch (WebException excepciónWeb)
            {

                if (!(excepciónWeb.Response is HttpWebResponse respuesta)) throw;

                string? lcrMensajeRespuesta = "";
                if (respuesta.StatusCode == HttpStatusCode.InternalServerError)
                {

                    tobRespuestaXml = FobObtenerXml(respuesta);
                    if (tobRespuestaXml == null) return Falso(out tcrMensaje, $"No se esperaba respuestaXml nulo.{DobleLínea}{excepciónWeb.Message}");
                    lcrMensajeRespuesta = tobRespuestaXml.DocumentElement?["s:Body"]?["s:Fault"]?["s:Code"]?["s:Subcode"]?["s:Value"]?.InnerText;

                }
                else
                {
                    lcrMensajeRespuesta = ""; // En otros casos hasta que no se verifique que no devuelvan XML se asumirá que no lo hacen.
                }

                return lcrMensajeRespuesta switch
                {
                    "a:InvalidSecurity" => Falso(out tcrMensaje, "Sucedió un error de verificación de seguridad en el servidor de la DIAN. " +
                                                              "Usualmente esto indica un problema " +
                                                             $"con la firma electrónica, con las horas o un mensaje XML mal formado.{DobleLínea}" +
                                                             $"{excepciónWeb.Message}{DobleLínea}Estado: {respuesta.StatusCode}."),
                    "a:InternalServiceFault" => Falso(out tcrMensaje, $"Error interno de servicio del servidor de la DIAN. Puede suceder cuando se especifica " +
                                                                   $"una operación diferente en el XML y en el encabezado de la solicitud POST.{DobleLínea}" +
                                                                   $"{excepciónWeb.Message}{DobleLínea}Estado: {respuesta.StatusCode}."),
                    _ => Falso(out tcrMensaje, $"Sucedió un error desconocido en el servidor de la DIAN.{DobleLínea}{excepciónWeb.Message}{DobleLínea}" +
                                            $"Estado: {respuesta.StatusCode}."),
                };

                #pragma warning disable CA1031 // No capture tipos de excepción generales. Se desactiva porque se necesita el texto de la excepción. No hay mayor problema porque es común que sucedan errores con el servicio web de la DIAN y esto es controlado con el flujo del programa a continuación.
            }
            catch (Exception ex)
            {
                #pragma warning restore CA1031
                return Falso(out tcrMensaje, $"Sucedió un error desconocido.{DobleLínea}{ex.Message}");
            }

            return true;

        } // EnviarSobre>
        #endregion FlgEnviarSobre: Enviar sobre al WS Dian>
        #region FlgEnviarSolicitud
        /// <summary>
        /// Envía una solicitud al servicio de la DIAN usando un <paramref name="tcrCuerpo"/> con el contenido del mensaje y 
        /// el tipo de <paramref name="operación"/>.
        /// </summary>
        public static bool FlgEnviarSolicitud(string tcrCuerpo, Operación operación, out string? mensaje, out XmlDocument? respuestaXml)
        {

            mensaje = null;
            string? sobreFirmado = null;
            respuestaXml = null;

            try
            {
                using var certificado = new X509Certificate2(Empresa.CertificadoRutaArchivo, Empresa.CertificadoClaveAcceso);

                var claveTitularID = ((X509SubjectKeyIdentifierExtension)certificado.Extensions.Cast<X509Extension>()
                                    .Where(e => e is X509SubjectKeyIdentifierExtension).Single()).SubjectKeyIdentifier; // Obtiene el SubjectKeyIdentifier del certificado según requerido por la documentación Oasis WSS X509 Token Profile 1.1. En realidad a la DIAN no le importa este valor mientras sea consistente en todo el documento pero se prefiere hacer según el estándar Oasis.

                var tokenBinarioDeSeguridad = Convert.ToBase64String(certificado.Export(X509ContentType.Cert, Empresa.CertificadoClaveAcceso)); // Según https://stackoverflow.com/questions/32404687/c-sharp-add-wssesecurity-and-binarysecuritytoken-to-envelope-xml-file-programma.

                var wsaTo = @"<wsa:To xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" " +
                            $@"wsu:Id=""ID-{claveTitularID}"">https://{BaseUrl}/WcfDianCustomerServices.svc</wsa:To>"; // Es el único elemento que se firma.
                var wsaToDigerido = FcrObtenerValorDigerido(wsaTo, certificado, claveTitularID);

                var signedInfo =
                    @"<ds:SignedInfo xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" " +
                    @"xmlns:wcf=""http://wcf.dian.colombia"" xmlns:wsa=""http://www.w3.org/2005/08/addressing"">" +
                        @"<ds:CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#"">" +
                            @"<ec:InclusiveNamespaces xmlns:ec=""http://www.w3.org/2001/10/xml-exc-c14n#"" PrefixList=""wsa soap wcf"">" +
                            "</ec:InclusiveNamespaces>" +
                        "</ds:CanonicalizationMethod>" +
                        @"<ds:SignatureMethod Algorithm=""http://www.w3.org/2001/04/xmldsig-more#rsa-sha256""></ds:SignatureMethod>" +
                        $@"<ds:Reference URI=""#ID-{claveTitularID}"">" +
                            "<ds:Transforms>" +
                                @"<ds:Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#"">" +
                                    @"<ec:InclusiveNamespaces xmlns:ec=""http://www.w3.org/2001/10/xml-exc-c14n#"" PrefixList=""soap wcf"">" +
                                    "</ec:InclusiveNamespaces>" +
                                "</ds:Transform>" +
                            "</ds:Transforms>" +
                            @"<ds:DigestMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#sha256""></ds:DigestMethod>" +
                            $@"<ds:DigestValue>{wsaToDigerido}</ds:DigestValue>" +
                        "</ds:Reference>" +
                    "</ds:SignedInfo>"; // En el XML sugerido por la DIAN (tomado desde SoapUI) debería tener el elemento ds:Signed sin espacios de nombres (<ds:SignedInfo>), pero se encontró que así la firma resulta incorrecta y el servidor la rechaza. Se usa entonces con todos los espacios de nombres completos aunque esto pueda ser una infracción al estándar del XML Oasis porque estos espacios de nombres también se agregan al soap:Evelope, pero se acepta porque lo importante es que es aprobado por la DIAN. En el XML original los elementos ec:InclusiveNamespaces, ds:SignatureMethod, ec:InclusiveNamespaces y ds:DigestMethod se usan con autocierre (<.../>) pero para la firma se requieren como elementos completos (<...></...>). Si fuera necesario usar una versión de este elemento para calcular la firma y otra para agregar en el sobre firmado, se puede hacer.

                /*
                var utf8 = new UTF8Encoding();
                var firma = Convert.ToBase64String(((RSACng)certificado.PrivateKey).SignData(utf8.GetBytes(signedInfo), HashAlgorithmName.SHA256,
                    RSASignaturePadding.Pkcs1));
                */

                var utf8 = new UTF8Encoding();
                RSACng lobKeyRsa = certificado.GetRSAPrivateKey() as RSACng;
                var firma = Convert.ToBase64String(lobKeyRsa.SignData(utf8.GetBytes(signedInfo), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));

                sobreFirmado =
                        @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:wcf=""http://wcf.dian.colombia"">" +
                            @"<soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">" +
                                @"<wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" " +
                                 @"xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">" +
                                   $@"<wsu:Timestamp wsu:Id=""TS-{claveTitularID}"">" +
                                        $"<wsu:Created>{DateTime.UtcNow.ATexto("yyyy-MM-ddTHH:mm:ssZ")}</wsu:Created>" +
                                        $"<wsu:Expires>{DateTime.UtcNow.AddSeconds(60000).ATexto("yyyy-MM-ddTHH:mm:ssZ")}</wsu:Expires>" +
                                    @"</wsu:Timestamp>" +
                                     "<wsse:BinarySecurityToken " +
                                     @"EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"" " +
                                     @"ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" " +
                                    $@"wsu:Id=""X509-{claveTitularID}"">" +
                                          tokenBinarioDeSeguridad +
                                     "</wsse:BinarySecurityToken>" +
                                    @"<ds:Signature xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" Id=""SIG-{claveTitularID}"">" +
                                          signedInfo +
                                        $"<ds:SignatureValue>{firma}</ds:SignatureValue>" +
                                       $@"<ds:KeyInfo Id=""KI-{claveTitularID}"">" +
                                           $@"<wsse:SecurityTokenReference wsu:Id=""STR-{claveTitularID}"">" +
                                           $@"<wsse:Reference URI=""#X509-{claveTitularID}"" " +
                                             @"ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3""/>" +
                                             "</wsse:SecurityTokenReference>" +
                                         "</ds:KeyInfo>" +
                                     "</ds:Signature>" +
                                "</wsse:Security>" +
                               $"<wsa:Action>http://wcf.dian.colombia/IWcfDianCustomerServices/{operación}</wsa:Action>" +
                                 wsaTo +
                             "</soap:Header>" +
                            $"<soap:Body>{tcrCuerpo}</soap:Body>" +
                        "</soap:Envelope>";
            }
            catch (CryptographicException)
            {
                return Falso(out mensaje, "Ocurrió un error criptográfico. La clave del certificado puede ser incorrecta.");
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "error metodo FlgEnviarSolicitud");
                throw;
            }

            return FlgEnviarSobre(sobreFirmado, operación, out mensaje, out respuestaXml);

        } // EnviarSolicitud>
        #endregion FlgEnviarSolicitud
        // Validaciones de Respuestas
        #region FcrObtenerValorDigerido
        /// <summary>
        /// Usa las clases de firma de xml propias de .Net para obtener el valor digerido del objeto a firmar.
        /// </summary>
        private static string FcrObtenerValorDigerido(string wsaTo, X509Certificate2 certificado, string id)
        { // No se usa las clases de .Net para obtener el XML firmado definitivo porque existen muchas inconsistencias entre el XML generado por estas y el requerido por el estándar Oasis. Aquí solo se obtiene el valor digerido que se usa para calcular la firma e insertarlos en el XML definitivo.

            var xml = new XmlDocument();
            xml.LoadXml(@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:wcf=""http://wcf.dian.colombia"">" +
                            $@"<soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">{wsaTo}</soap:Header>" +
                        @"</soap:Envelope>");

            var xmlFirmado = new XmlFirmadoConWsuID(xml) { SigningKey = certificado.GetRSAPrivateKey() };

            var referencia = new Reference { Uri = $"#ID-{id}" };
            var transformaciónC14N = new XmlDsigExcC14NTransform(includeComments: false, inclusiveNamespacesPrefixList: "wsa soap wcf");
            referencia.AddTransform(transformaciónC14N);
            xmlFirmado.AddReference(referencia);

            var informaciónClave = new KeyInfo();
            informaciónClave.AddClause(new KeyInfoX509Data(certificado));
            xmlFirmado.KeyInfo = informaciónClave;

            xmlFirmado.ComputeSignature();

            return xmlFirmado.GetXml()["SignedInfo"]["Reference"]["DigestValue"].InnerText;

        } // ObtenerValorDigerido>
        #endregion FcrObtenerValorDigerido>
        #region FlgValidarResponseInicial sin ZipKey
        /// <summary>
        /// Realiza una verificacion para determinar si el response es valido y asi poder 
        /// obtener el ZipKey de envio y poder consultar respuesta de validacion mas tarde
        /// </summary>
        /// <param name="tobRespuestaXml">Mensaje de respuesta enviado por el servicio Dian</param>
        /// <param name="tcrMensaje">Mensaje de respuesta que decribe si el response es valido o no</param>
        /// <returns></returns>
        public static bool FlgValidarResponseInicial(XmlDocument tobRespuestaXml, out string tcrMensaje)
        {
            return FlgValidarResponseInicial(tobRespuestaXml, out _, out tcrMensaje); // se descarta el parametro ZipKey
        }
        #endregion FlgValidarResponseIncicial>
        #region FlgValidarResponseInicial
        /// <summary>
        /// Realiza una verificacion para determinar si el response es valido y asi poder 
        /// obtener el ZipKey de envio y poder consultar respuesta de validacion mas tarde
        /// </summary>
        /// <param name="tobRespuestaXml">Mensaje de respuesta enviado por el servicio Dian</param>
        /// <param name="tcrZipKey">Cuando la respuesta Dian es correcta, aqui devuelve el ZipKey para consulta posterior</param>
        /// <param name="tcrMensaje">Mensaje de respuesta que decribe si el response es valido o no</param>
        /// <returns></returns>
        public static bool FlgValidarResponseInicial(XmlDocument tobRespuestaXml, out string tcrZipKey, out string tcrMensaje)
        {
            bool llgReturn;
            tcrZipKey = null;

            if (tobRespuestaXml == null)
            {
                tcrMensaje = "La Respuesta Dian esta vacia.";
                llgReturn = false;
            }
            else
            {
                // Extraer el ZipKey para consultar estado validación mas tarde
                var lobNodo = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:ZipKey");
                if (lobNodo.Count > 0)
                {
                    tcrZipKey  = lobNodo[0].InnerText;
                    llgReturn  = true;
                    tcrMensaje = "Se Finalizó envio del documento, puede consultar detalles de la respuesta.";
                }
                else
                {
                    tcrMensaje = "La Peticion Validacion del documento no fué Recibida en servicio DIAN por algún error.";
                    llgReturn = false;
                }
            }
            return llgReturn;
        }
        #endregion FlgValidarResponseInicial>
        #region FlgCargarDianResponse: Cargar el archivo response  
        /// <summary>
        /// Realiza el cargue del Response y devuelve un objeto tipo  clase "DianResponse"
        /// con todos los campos de la respuesta dada.
        /// </summary>
        /// <param name="tobRespuestaXml">Mensaje de respuesta enviado por el servicio Dian</param>
        /// <param name="tcrMensaje">Mensaje de respuesta que decribe si el response es valido o no</param>
        /// <returns></returns>
        public static bool FlgCargarDianResponse(XmlDocument tobRespuestaXml, out DianResponse tobResponse , out string tcrMensaje)
        {
            var llgReturn = false;
            tobResponse = null;
            DianResponse lobResponse = new DianResponse();
            tcrMensaje = null;
            XmlNodeList lobNodos;
            lobResponse.TipoResponse = "NA";  // Inicia como no valido 

            if (tobRespuestaXml != null)
            {
                #region ZipKey
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:ZipKey");
                if (lobNodos.Count > 0)
                {
                    llgReturn = true;
                    lobResponse.ZipKey = lobNodos[0].InnerText;
                    lobResponse.TipoResponse = "ZipKey"; // se asume que es el Response inicial de envio 
                }
                #endregion ZipKey

                #region ErrorMessage
                lobResponse.ErrorMessage = "NA";
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:ErrorMessage");
                if (lobNodos.Count > 0)
                {
                    var lobNodosErrores = lobNodos[0].ChildNodes;
                    if (lobNodosErrores.Count > 0)
                    {
                        lobResponse.ErrorMessage = string.Empty;
                        for (int i = 0; i < lobNodosErrores.Count; i++)
                        {
                            var lcrReturnCar = (i == (lobNodosErrores.Count - 1)) ? "" : "\r\n"; // agregar retorno de carro para que cada lina quede independiente

                            lobResponse.ErrorMessage += lobNodosErrores[i].InnerText + lcrReturnCar;
                        }

                        /*
                        foreach (XmlNode lobReg in lobNodosErrores)
                        {
                            MessageBox.Show(lobReg.InnerText);
                        }
                        */
                    }
                }
                #endregion ErrorMessage

                #region IsValid
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:IsValid");
                if (lobNodos.Count > 0)
                {
                    lobResponse.IsValid = lobNodos[0].InnerText;
                    llgReturn = true;
                }
                #endregion IsValid

                #region StatusCode
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:StatusCode");
                if (lobNodos.Count > 0)
                {
                    lobResponse.StatusCode = lobNodos[0].InnerText;
                    llgReturn = true;
                }
                #endregion StatusCode

                #region StatusDescription
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:StatusDescription");
                if (lobNodos.Count > 0)
                {
                    lobResponse.StatusDescription = lobNodos[0].InnerText;
                    if (lobResponse.IsValid == "false" && 
                        (string.IsNullOrWhiteSpace(lobResponse.ErrorMessage) == true || 
                        lobResponse.ErrorMessage == "NA"))
                    {
                        lobResponse.ErrorMessage = lobResponse.StatusDescription;
                    }
                }
                #endregion StatusDescription

                #region StatusMessage
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:StatusMessage");
                if (lobNodos.Count > 0)
                {
                    lobResponse.StatusMessage = lobNodos[0].InnerText;
                }
                #endregion StatusMessage

                #region XmlBase64Bytes
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:XmlBase64Bytes");
                if (lobNodos.Count > 0)
                {
                    lobResponse.XmlBase64Bytes = Convert.FromBase64String(lobNodos[0].InnerText).ToString();
                }
                #endregion XmlBase64Bytes

                #region XmlBytes
                lobResponse.XmlBytes = ""; // por ahora no se ve util
                #endregion XmlBytes

                #region XmlDocumentKey
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:XmlDocumentKey");
                if (lobNodos.Count > 0)
                {
                    lobResponse.XmlDocumentKey = lobNodos[0].InnerText;
                    lobResponse.TipoResponse = "DocumentKey"; // se asume que es envio en modo produccion
                    llgReturn = true;
                }
                #endregion XmlDocumentKey

                #region XmlFileName
                lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName("b:XmlFileName");
                if (lobNodos.Count > 0)
                {
                    lobResponse.XmlFileName = lobNodos[0].InnerText;
                }
                #endregion XmlFileName

                // Decidir en que tipo de estado
                if (lobResponse.TipoResponse == "ZipKey")
                {
                    lobResponse.EstadoGestion = "R03";
                }
                else
                {
                    lobResponse.EstadoGestion = lobResponse.IsValid == "true" ? "R01" : "R02";
                }
                
            }

            if (llgReturn == true)
            {
                tobResponse = lobResponse;
            }

            tcrMensaje = llgReturn == true ? "Registro cargado con Éxito!!"
                                           : "El archivo Response no tiene el formato correcto DIAN.";

            return llgReturn;
        }
        #endregion FlgValidarResponseIncicial>
        // Convertir datos a string desde Base64 
        #region FlgCargarResponseXMLFromBase64: Cargar el archivo response desde Base64 
        /// <summary>
        /// Leer desde el response y devuelve un objeto tipo  XmlDocument
        /// </summary>
        /// <param name="tobRespuestaXml">Mensaje de respuesta enviado por el servicio Dian</param>
        /// <param name="tcrTagName">Nombre etiqueta Tag a buscar (Ejemplo "b:XmlBase64Bytes") dentro del XML donde se encuentra el achivo en formato Base64</param>
        /// <param name="tcrMensaje">Mensaje de respuesta que decribe si el response es valido o no</param>
        /// <returns></returns>
        public static bool FlgCargarResponseXMLFromBase64(string tcrTagName, XmlDocument tobRespuestaXml, out XmlDocument tobResponse, out string tcrMensaje)
        {
            var llgReturn = false;
            tobResponse = null;

            if (tobRespuestaXml != null)
            {
                if (FlgCargarFromBase64String(tcrTagName, tobRespuestaXml, out string tcrStringRespuesta))
                {
                    llgReturn = true;
                    tobResponse.LoadXml(tcrStringRespuesta);
                }
            }

            tcrMensaje = llgReturn == true ? "Registro cargado con Éxito!!"
                                           : "El archivo Response no tiene el formato correcto DIAN.";

            return llgReturn;
        }
        #endregion FlgCargarResponseXMLFromBase64>
        #region FlgCargarFromBase64String: Cargar string desde Base64 
        /// <summary>
        /// Leer la etiqueda dada en el parametro TagName y devolver un valor string decodificado desde Base64
        /// </summary>
        /// <param name="tobRespuestaXml">Mensaje de respuesta enviado por el servicio Dian</param>
        /// <param name="tcrTagName">Nombre etiqueta Tag a buscar (Ejemplo "b:XmlBase64Bytes") dentro del XML donde se encuentra el achivo en formato Base64</param>
        /// <param name="tcrStringRespuesta">Devuelve el contenido encontrado del TagName dado en parametro (decodificado desde Base64)</param>
        /// <returns>Retorna valor tipo string apartir del contenido encontrado en TagName y decodifcado desde Base64</returns>
        public static bool FlgCargarFromBase64String(string tcrTagName, XmlDocument tobRespuestaXml, out string tcrStringRespuesta)
        {
            var llgReturn = false;
            tcrStringRespuesta = null;

            if (tobRespuestaXml != null)
            {
                var lobNodos = tobRespuestaXml.DocumentElement.GetElementsByTagName(tcrTagName); // Ejemplo "b:XmlBase64Bytes"
                if (lobNodos.Count > 0)
                {
                    llgReturn = true;
                    tcrStringRespuesta = Encoding.UTF8.GetString(Convert.FromBase64String(lobNodos[0].InnerText));
                }
            }

            return llgReturn;
        }
        #endregion FlgCargarFromBase64String>
        // Otros
        #region EnviarFacturaElectrónica
        /*
        public static bool EnviarFacturaElectrónica(Venta venta, out string? mensaje, bool prueba = false)
        {

            mensaje = null;

            /*
            if (!venta.CalcularTodo()) return Falso(out mensaje, $"Error calculando factura.{DobleLínea}Error en CalcularTodo().");

            var facturaElectrónica = new DocumentoElectrónico<Venta, LíneaVenta>(venta, observaciones: "Una observación", TipoFacturaVenta.Venta,
                    códigoFacturaContingencia: "CMP1454", fechaFacturaContingencia: new DateTime(2019, 06, 19));

            if (!facturaElectrónica.Crear(out string? mensajeCreación))
                return Falso(out mensaje, $"Error creando documento electrónico.{DobleLínea}{mensajeCreación}");

            XmlDocument? respuestaXml;
            if (prueba)
            {
                if (!facturaElectrónica.EnviarPrueba(out string? mensajeSolicitud, out respuestaXml))
                    return Falso(out mensaje, $"Error enviando prueba a la DIAN.{DobleLínea}{mensajeSolicitud}");
            }
            else
            {
                if (!facturaElectrónica.Enviar(out string? mensajeSolicitud, out respuestaXml))
                    return Falso(out mensaje, $"Error enviando a la DIAN.{DobleLínea}{mensajeSolicitud}");
            }

            if (respuestaXml == null) return Falso(out mensaje, $"Error en respuesta de la DIAN.{DobleLínea}El XML está vacío.");

            var respuestaDian = new RespuestaDian(respuestaXml, prueba ? Operación.SendTestSetAsync : Operación.SendBillSync);
            if (!respuestaDian.Éxito) return Falso(out mensaje, $"Error en respuesta de la DIAN.{DobleLínea}{respuestaDian.MensajeError}");

            
            return true;

        } // EnviarFacturaElectrónica>
        */
        #endregion EnviarFacturaElectrónica
        //-----------------------------------------------------------
        // Utilidad quitar espacios de nombres no deseados al generar XML
        //-----------------------------------------------------------
        /// <summary>
        /// Clase auxiliar específica para el espacio de nombres wsu del estándar Oasis que permite la obtención de un elemento de un xml firmado usando el wsu:id.
        /// </summary>
        public class XmlFirmadoConWsuID : SignedXml // Tomado de https://stackoverflow.com/questions/5099156/malformed-reference-element-when-adding-a-reference-based-on-an-id-attribute-w.
        {
            #region Constructores

            public XmlFirmadoConWsuID(XmlDocument xml) : base(xml) { }

            public XmlFirmadoConWsuID(XmlElement xmlElement) : base(xmlElement) { }

            #endregion Constructores>

            #region Métodos y Funciones

            public override XmlElement GetIdElement(XmlDocument xml, string id)
            {

                if (xml == null) return null!; // Se debe controlar con el código externo el caso que sea null. Esto se hace por compatibildiad con la función sobreescrita de la clase base. 
                XmlElement? elementoEncontrado = base.GetIdElement(xml, id);

                if (elementoEncontrado == null)
                {

                    var administradorEspacios = new XmlNamespaceManager(xml.NameTable);
                    administradorEspacios.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                    elementoEncontrado = xml.SelectSingleNode($@"//*[@wsu:Id=""{id}""]", administradorEspacios) as XmlElement;

                }

                return elementoEncontrado!; // Para hacerlo compatible con la función override se supondrá que nunca es nulo. Si lo es, su manejo se tendrá que dar en el código que lo llame.

            } // GetIdElement>

            #endregion Métodos y Funciones>

        } // XmlFirmadoConWsuID>

    }
    /// <summary>
    /// XmlTextWriter personalizado que omite la escritura de los atributos con nombre en AtributosAOmitir.
    /// </summary>
    class XmlTextWriterSinXsi : XmlTextWriter
    { // Tomado de https://stackoverflow.com/questions/7656557/remove-xsitype-from-generated-xml-when-serializing.

        #region Variables y Campos
        private bool llgSaltar = false;
        private bool llgEliminarDeRaíz = false;
        #endregion Variables y Campos>

        #region Constructores
        public XmlTextWriterSinXsi(TextWriter w) : base(w) { }
        public XmlTextWriterSinXsi(Stream w, Encoding encoding) : base(w, encoding) { }
        public XmlTextWriterSinXsi(string filename, Encoding encoding) : base(filename, encoding) { }
        #endregion Constructores>

        #region Métodos y Funciones
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            if (prefix == "xmlns" && localName == "xsi" && llgEliminarDeRaíz)
            {
                llgSaltar = true;
                return;
            }
            else if (localName == "type")
            { // Es equivalente a if (ns == XmlSchema.InstanceNamespace). Pero se prefiere == "type" para ser más explícito que lo que se quiere evitar es ese atributo, por si aparece otro caso que cumpla InstanceNamespace pero no == "type".
                llgSaltar = true;
                return;
            }
            base.WriteStartAttribute(prefix, localName, ns);

        } // WriteStartAttribute>

        public override void WriteString(string text)
        {
            if (llgSaltar) return;
            base.WriteString(text);
        } // WriteString>

        public override void WriteEndAttribute()
        {
            if (llgSaltar)
            {
                llgSaltar = false;
                return;
            }
            base.WriteEndAttribute();

        } // WriteEndAttribute>
        #endregion Métodos y Funciones
    } // XmlTextWriterSinXsi>

    #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

}

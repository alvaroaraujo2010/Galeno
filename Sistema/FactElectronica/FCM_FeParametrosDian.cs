using System;
using System.Collections.Generic;
using static Sistema.Dian.Global;

namespace Sistema.Dian
{
    /// <summary>
    /// Parametros requeridos dian
    /// </summary>
    public static class ParametrosDian
    {

        #region Enumeraciones
        // Enumeraciones que solo se usan en el contexto de esta clase Dian o de DocumentoElectrónico.

        public enum AgrupaciónTaxTotales { Línea, Tarifa };

        public enum Operación
        {
            GetExchangeEmails, GetNumberingRange, GetStatus, GetStatusZip, GetXmlByDocumentKey, SendBillAsync, SendBillAttachmentAsync, SendBillSync,
            SendEventUpdateStatus, SendTestSetAsync
        }

        public enum RolFirmante
        {
            EMISOR,
            PROVEEDOR_TECNOLOGICO
        }

        #endregion Enumeraciones>

        #region Constantes

        #region Constantes simples
        public const string BaseUrlPruebas = "vpfe-hab.dian.gov.co";

        public const string BaseUrlProducción = "vpfe.dian.gov.co";

        public const string AgenciaID195 = "195";

        public const string NombreAgenciaDian = "CO, DIAN (Dirección de Impuestos y Aduanas Nacionales)";

        public const string NombreAgenciaDianValidacion = "Unidad Especial Dirección de Impuestos Y Aduanas Nacionales";

        public const string NitDian = "800197268";

        public const string DigitoVerificacionNitDian = "4";

        public const string VersionUBL = "UBL 2.1"; // Versión base de UBL usada para crear este perfil

        /// <summary> AE35 - Tipo mime utilizado para el envío, debe ser text/xml</summary>
        public const string MimeCode = "text/xml";

        /// <summary> AE36 - Encoding del archivo, debe ser UTF‐8</summary>
        public const string EncodingCode = "UTF‐8";

        public const string CustomizationID = "Documentos adjuntos";

        public const string DocumentType = "Contenedor de Factura Electrónica";

        public const string CodigoFacturaEstandar = "10"; //  Indicador del tipo de operación. Rechazo: Si contiene un valor distinto a los definidos en el grupo en el numeral 13.1.5.1: 10 Estandar (Valor predeterminado), 09 AIU, 11 Mandatos. SimpleOps no implementa aún AIU ni mandatos. 

        public const string CodigoNotaCreditoConFactura = "20";

        public const string CodigoNotaCreditoSinFactura = "22";

        public const string CodigoNotaDebitoConFactura = "30";

        public const string CodigoNotaDebitoSinFactura = "32";

        public const string AgenciaIdentificaciónPaís = "United Nations Economic Commission for Europe";

        public const string UriEsquemaIdentificacionPais = "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.1";

        public const string AgenciaIdentificaciónPaísID = "6";

        public const string NombreYVersionFacturaElectronica = "DIAN 2.1: Factura Electrónica de Venta"; // Versión del Formato: Indicar versión del documento. A pesar que la documentación dice que se debe usar "DIAN 2.1: Factura Electrónica de Venta" el servicio web responde con error y exige que sea "DIAN 2.1".

        public const string NombreYVersionNotaCredito = "DIAN 2.1: Nota Crédito de Factura Electrónica de Venta"; //"DIAN 2.1" 

        public const string NombreYVersionNotaDebito = "DIAN 2.1: Nota Debito de Factura Electrónica de Venta"; //"DIAN 2.1" 

        public const string AlgoritmoCufe = "CUFE-SHA384"; // Identificador del esquema de identificación. Algoritmo utilizado para el cáculo del CUFE. Ver lista de valores posibles en el numeral 13.1.2.1.

        public const string AlgoritmoCude = "CUDE-SHA384"; // Identificador del esquema de identificación. Algoritmo utilizado para el cáculo del CUDE. Ver lista de valores posibles en el numeral 13.1.2.2.

        public const string CódigoFacturaContingencia = "FTC"; // 13.1.4. Referencia a otros documentos. Otros: FTP Factura Talonario Papel, FTPC Factura Talonario Por computador.

        public const string CódigoRemisión = "AAJ"; // 13.1.4. Referencia a otros documentos.

        public const string NombreUsuarioFinal = "usuario";

        public const string ApellidoUsuarioFinal = "final";

        public const string CodigoMedioPagoPorDefinir = "ZZZ"; // Tomado de la tabla 13.3.4.2.

        public const string CódigoPrecioReferencia = "01"; // Tomado de la tabla 13.3.8.

        public const string CódigoEstándarAdopciónContribuyente = "999"; // Tomado de la tabla 6.3.5.

        public const int HorasAjusteUtc = -5; // -5 para Colombia. Cantidad de horas fijas que se le restarán a la hora UTC para obtener la hora semilocal que se usará para almacenar las fechas de las operaciones en la base de datos. Es semilocal porque coincide con la hora local del equipo en los paises en los que no hay horario de verano ni zonas horarias. Para evitar referenciar a SimpleOps.exe desde Dian.dll este valor es escrito manualmente en Dian.sln.

        #endregion Constantes simples>


        public static Dictionary<string, string> CódigosDepartamentos = new Dictionary<string, string> { // Tomados del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN. Departamentos (ISO 3166-2:CO). Se manejan en un diccionario por facilidad y para no tener que crear una nueva tabla en la base de datos o agregarlo a cada municipio. Es inncesario para estos datos tan estáticos.
            {"Amazonas","91"},
            {"Antioquia","05"},
            {"Arauca","81"},
            {"Atlántico","08"},
            {"Distrito Capital","11"},
            {"Bolívar","13"},
            {"Boyacá","15"},
            {"Caldas","17"},
            {"Caquetá","18"},
            {"Casanare","85"},
            {"Cauca","19"},
            {"Cesar","20"},
            {"Chocó","27"},
            {"Córdoba","23"},
            {"Cundinamarca","25"},
            {"Guainía","94"},
            {"Guaviare","95"},
            {"Huila","41"},
            {"La Guajira","44"},
            {"Magdalena","47"},
            {"Meta","50"},
            {"Nariño","52"},
            {"Norte De Santander","54"},
            {"Putumayo","86"},
            {"Quindío","63"},
            {"Risaralda","66"},
            {"Archipiélago De San Andrés, Providencia Y Santa Catalina","88"},
            {"Santander","68"},
            {"Sucre","70"},
            {"Tolima","73"},
            {"Valle Del Cauca","76"},
            {"Vaupés","97"},
            {"Vichada","99"},
        };


        public static Dictionary<TipoContribuyente, string> CódigosTiposContribuyentes = new Dictionary<TipoContribuyente, string> { // Tomados de la tabla 13.2.6.1. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN.
            {TipoContribuyente.Ordinario, "ZZ" }, // Código aplicable para el elemento FAJ26.
            {TipoContribuyente.GranContribuyente, "O-13" }, // Código aplicable para el elemento FAJ26.
            {TipoContribuyente.Autorretenedor, "O-15" }, // Código aplicable para el elemento FAJ26.
            {TipoContribuyente.RetenedorIVA, "O-23" }, // Código aplicable para el elemento FAJ26.
            {TipoContribuyente.RégimenSimple, "O-47" }, // Código aplicable para el elemento FAJ26.
            {TipoContribuyente.ResponsableIVA, "48" }, // Código aplicable para el elemento FAJ27. Se obtiene de la tabla 16.1.6. Modificación del anexo técnico (06-09-2019).
            {TipoContribuyente.NoResponsableIVA, "49" }, // Código aplicable para el elemento FAJ27. Se obtiene de la tabla 16.1.6. Modificación del anexo técnico (06-09-2019).
        };


        public static Dictionary<Unidad, string> CódigosUnidades = new Dictionary<Unidad, string> { // Tomados de la tabla 13.3.5.1. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN.
            {Unidad.Unidad, "94" },
            {Unidad.Par, "PR" },
            {Unidad.Trío, "P3" }, // También QD: Cuarto de docena.
            {Unidad.Cuarteto, "P4" },
            {Unidad.Quinteto, "P5" },
            {Unidad.MediaCentena, "P6" }, // También HD: Media docena.
            {Unidad.Septeto, "P7" },
            {Unidad.Octeto, "P8" },
            {Unidad.Decena, "TP" }, // También TPR: Diez pares.
            {Unidad.Docena, "DZN" }, // También DPC: Docena pieza, DPR: Docena par, DZP: Paquete de doce.
            {Unidad.Veintena, "4E" },
            {Unidad.Centena, "CEN" }, // También CNP: Paquete de cien.
            {Unidad.Millar, "MIL" }, // También T3, T5: Caja de mil, T4: Bolsa de mil y T3: Mil piezas.
            {Unidad.Millón, "MIO" },
            {Unidad.Millardo, "MLD" }, // Mil millones.
        }; // No agregadas: P9: Paquete de nueve, EP: Paquete de once.


        public static Dictionary<TipoImpuesto, string> CódigosTiposImpuestos = new Dictionary<TipoImpuesto, string> { // Tomados de la tabla 13.2.6.2. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN.
            {TipoImpuesto.IVA, "01" },
            {TipoImpuesto.INC, "04" },
            {TipoImpuesto.IVAeINC, "ZA" },
            {TipoImpuesto.NoAplica, "ZZ" },
        };

        #endregion Constantes>

        #region Variables Autocalculadas

        public static string BaseUrl
            => Empresa.AmbienteFacturacionElectronica == AmbienteFacturacionElectronica.Producción ? BaseUrlProducción : BaseUrlPruebas;

        #endregion Variables Autocalculadas>

        #region Métodos y Funciones

        /// <summary>
        /// Valida un elemento de acuerdo a las restricciones de la 'Tabla 4: Tamaños de Elementos' del archivo 'Anexo Técnico de Factura Electrónica'.
        /// </summary>
        /// <param name="elemento">Texto del elemento a validar puede ser un texto o un número con punto como separador decimal. En general pueden ser varios elementos separados por coma.</param>
        /// <param name="restricción">De formato: (x1..y1) p (n1..m1), (x2..y2) p (n2..m2), ..., (xn..yn) p (nn..mn) donde se permiten n elementos
        /// separados por coma (o un solo elemento si no hay coma), donde (xi..yi) p (ni..mi) indica un elemento de mínimo xi de largo total y 
        /// máximo yi de largo total (incluyendo el punto de decimal y la parte decimal) y que es un decimal con mínimo ni posiciones decimales 
        /// y máximo mi posiciones decimales. Si se omite p (...) aplica para solo textos y números enteros. Si se omiten los dos puntos, así: 
        /// zi p li implica que el elemento debe ser exactamente zi de largo y tener li posiciones decimales si es un número.</param>
        /// <param name="largoMáximo">Solo válido para los que no tienen decimales ni comas.</param>
        /// <param name="largoMínimo">Solo válido para los que no tienen decimales ni comas.</param>
        /// <returns></returns>
        public static bool EsVálido(string elemento, string restricción, out int largoMáximo, out int largoMínimo)
        {

            largoMáximo = 0;
            largoMínimo = 0;

            if (string.IsNullOrEmpty(restricción)) return false;

            var restricciones = restricción.Split(',');
            string[] elementos;
            if (restricciones.Length > 1)
            {
                elementos = elemento == null ? new string[1] { "" } : elemento.Split(',');
                if (restricciones.Length != elementos.Length) return false; // Si la restricción tiene comas el elemento necesariamente tiene que tener la misma cantidad de comas y
                if (string.IsNullOrEmpty(restricción)) return false;
            }

            return true;

        } // EsVálido>


        /// <summary>
        /// Revisa el elemento de texto y lo devuelve igual si cumple con la restricción. Genera una excepción si no cumple la restricción.
        /// Si <paramref name="forzarCumplimiento"/> es verdadero y se trata de una restricción de largo de texto sencilla X..Y 
        /// se recortan los elementos muy largos al tamaño máximo permitido y se agregan espacios al final de los elementos muy cortos
        /// para llevarlos al tamaño mínimo permitido.
        /// </summary>
        public static string Validar(string texto, string restricción, bool forzarCumplimiento = false)
        {

            var válido = EsVálido(texto, restricción, out int largoMáximo, out int largoMínimo);
            if (!válido && forzarCumplimiento)
            {

                if (texto == null) texto = "";
                if (texto.Length < largoMínimo) texto = texto.PadRight(largoMínimo);
                if (texto.Length > largoMáximo) texto = texto.Substring(0, largoMáximo);
                válido = EsVálido(texto, restricción, out _, out _); // Si no se pudo corregir con las restricciones es porque posiblemente la restricción está mal formada, debe lanzar excepción.

            }

            if (!válido) throw new Exception($"El elemento {texto} no cumple con la restricción {restricción}.");
            return texto;

        } // Validar>


        /// <summary>
        /// Revisa el elemento decimal y lo devuelve igual si cumple con la restricción. Genera una excepción si no cumple la restricción.
        /// </summary>
        public static decimal Validar(decimal número, string restricción, int posicionesDecimalesForzadas)
        {

            var númeroTexto = número.ATexto($"0.{new string('0', posicionesDecimalesForzadas)}");
            var númeroDecimalesForzados = númeroTexto.ADecimal(); // El mismo número decimal pero con las posiciones decimales forzadas.
            if (!EsVálido(númeroDecimalesForzados.ATexto(), restricción, out _, out _))
                throw new Exception($"El elemento {número} no cumple con la restricción {restricción}.");
            return númeroDecimalesForzados;

        } // Validar>


        /// <summary>
        /// Revisa el elemento long y lo devuelve igual si cumple con la restricción. Genera una excepción si no cumple la restricción.
        /// </summary>
        /// <param name="número"></param>
        /// <param name="restricción"></param>
        /// <returns></returns>
        public static long Validar(long número, string restricción)
        {

            if (!EsVálido(número.ATexto(), restricción, out _, out _))
                throw new Exception($"El elemento {número} no cumple con la restricción {restricción}.");
            return número;

        } // Validar>


        public static string ObtenerCódigoTipoOperación(TipoDocumentoElectronico? tcrTipoDocumento) // SimpleOps no implementa los otros códigos, porque no es usual en la actividad comercial generar una nota crédito o débito sin una factura asociada.
        {
            var lcrReturn = "10"; // Codigo Factura Esandar
            switch (tcrTipoDocumento)
            {
                case TipoDocumentoElectronico.FacturaVenta: // Codigo Factura Esandar
                    lcrReturn = "10";
                    break;
                case TipoDocumentoElectronico.NotaCredito: // Nota credito con factura
                    lcrReturn = "20";
                    break;
                case TipoDocumentoElectronico.NotaDebito: // Nota debito con factura
                    lcrReturn = "30";
                    break;
            }

            return lcrReturn;
            /* 
              => tcrTipoDocumento switch
              {
                  TipoDocumentoElectronico.FacturaVenta => "10", // Codigo Factura Esandar
                  TipoDocumentoElectronico.NotaCredito => "20",  // Nota credito con factura
                  TipoDocumentoElectronico.NotaDebito => "30",   // Nota debito con factura
                  _ => throw new Exception("Tipo documentos no valido"),
              };
          */
        }
        #endregion Métodos y Funciones>
    }
}

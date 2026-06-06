using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Media;
using System.IO;
using static Sistema.Dian.General;

namespace Sistema.Dian
{
    public class Global
    {
        #region Constantes
        // Configuraciones del comportamiento de SimpleOps que solo se pueden hacer desde este código. No estarán accesibles a los usuarios en Opciones.

        public const bool UsarSQLite = true; // Si es falso se usa MS SQL.

        public const bool GuardarFechaReducidaSQLite = true; // Si es verdadero la base de datos se construirá con algunas columnas (FechaHoraDeCreación y otras que no requieren exactitud a la hora y minuto) con formato yyMMdd y otras columnas con formato yyMMddhhmmssf. Esto ahorra alrededor de 15% de espacio comparado con el formato por defecto. En los ensayos realizados con los datos iniciales se obtuvo el mismo tiempo de escritura de toda la base de datos de 5:30 min así que se espera que el rendimiento sea el mismo y el tamaño pasó de 23 752 KB a 20 268 KB. Ver https://stackoverflow.com/questions/49261542/entityframework-core-format-datetime-in-sqlite-database/59981186#59981186. Para que cambiar este comportamiento se debe borrar la base de datos, reiniciar las migraciones y recrearla.

        public const bool GuardarDecimalComoDoubleSQLite = true; // Si es verdadero todas las propiedades decimal se almacenarán en la base de datos SQLite como double (real). Esto implica una pérdida de resolución númerica pero permite realizar operaciones de comparación como OrderBy() directamente en la base de datos y reduce en alrededor de 7% el tamaño de la base de datos. En los ensayos realizados se pasó de 20 268 KB (usando OptimizarTamañoSQLiteConFechaReducida) a 18 816 KB. Ver recomendación en https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli.

        public static bool HabilitarRastreoDeDatosSensibles = false; // Si se establece en verdadero en la ventana 'Inmediato' se podrá ver el detalle de las acciones ejecutados en la base de datos, incluyendo los datos. Si se deja en falso EF Core reemplazará los datos por textos de reemplazo. En producción siempre debe estar en falso.

        public const string NombreAplicación = "SimpleOps";

        public const string WebAplicación = "SimpleOps.net";

        public const string CarpetaDatosJson = "Datos JSON";

        public const string CarpetaCopiasSeguridad = "Copias de Seguridad";

        public const string NombreBaseDatosSQLite = "Datos";

        public const string CarpetaLibrerías = "Librerías";

        public const string CarpetaOpciones = "Opciones";

        public const string CarpetaDocumentosElectrónicos = "Documentos Electrónicos";

        //public const int HorasAjusteUtc = -5; // -5 para Colombia. Cantidad de horas fijas que se le restarán a la hora UTC para obtener la hora semilocal que se usará para almacenar las fechas de las operaciones en la base de datos. Es semilocal porque coincide con la hora local del equipo en los paises en los que no hay horario de verano ni zonas horarias. Para evitar referenciar a SimpleOps.exe desde Dian.dll este valor es escrito manualmente en Dian.sln.

        #endregion

        #region Variables Constantes

        public static OpcionesEmpresa Empresa = OpcionesEmpresa.Datos; // Variable auxiliar para almacenar el objeto singleton OpcionesEmpresa.Datos y poderlo acceder más fácilmente. Se inicia la variable singleton OpcionesEmpresa.Datos con alias global Empresa de la clase OpcionesEmpresa para que no sea iniciada en otro lugar. Aunque eso no debería generar problemas se prefiere evitarlo y tener esta variable lista lo más pronto posible en la ejecución. Los valores iniciales son temporales pues son sobreescritos con los valores en Empresa.json en CargarOpciones().

        //public static OpcionesGenerales Generales = OpcionesGenerales.Datos; // Variable auxiliar para almacenar el objeto singleton OpcionesGenerales.Datos y poderlo acceder más fácilmente. Se inicia la variable singleton OpcionesGenerales.Datos con alias global Generales de la clase OpcionesGenerales para que no sea iniciada en otro lugar. Aunque eso no debería generar problemas se prefiere evitarlo y tener esta variable lista lo más pronto posible en la ejecución. Los valores iniciales son temporales pues son sobreescritos con los valores en GeneralesPredeterminados.json y GeneralesPropios.json en CargarOpciones().

        //public static OpcionesEquipo Equipo = OpcionesEquipo.Datos; // Variable auxiliar para almacenar el objeto singleton OpcionesEquipo.Datos y poderlo acceder más fácilmente. Se inicia la variable singleton OpcionesEquipo.Datos con alias global Equipo de la clase OpcionesEquipo para que no sea iniciada en otro lugar. Aunque eso no debería generar problemas se prefiere evitarlo y tener esta variable lista lo más pronto posible en la ejecución. Los valores iniciales son temporales pues son sobreescritos con los valores en Equipo.json en CargarOpciones().

        #endregion Variables Constantes>

        #region Enumeraciones 

        public enum TipoEntidad : byte { Desconocido = 0, Empresa = 1, Persona = 2 } // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Identificador de tipo de organización jurídica. Los valores deben ser coincidentes con numeral 13.2.3 de la guía de facturación electrónica de la DIAN. 1 Persona jurídica y asimiladas, 2 Persona natural.

        public enum TipoCliente : byte { Desconocido = 0, Consumidor = 1, Distribuidor = 2, GrandesContratos = 3, Otro = 255 } // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Nuevos elementos se añaden antes de Otro. Cada vez que se añada un elemento se deben agregar los elementos necesarios en TipoClienteFormaEntrega.

        public enum Prioridad : byte { Desconocida = 0, Ninguna = 1, MuyBaja = 10, Baja = 20, Media = 30, Alta = 40, MuyAlta = 50 } // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Ninguna es necesario cuando no existe ninguna prioridad para el elemento y no debe ser tenido en cuenta. Si fuera necesario nuevos elementos de prioridad intermedia se pueden añadir entre los valores existentes.

        public enum FormaEntrega : byte
        { // Virtual es útil para productos o servicios que se proveen sin necesidad de representación o presencia física. Cada vez que se añada un elemento se deben agregar los elementos necesarios en TipoClienteFormaEntrega.
            Desconocida = 0, Virtual = 1, PuntoVenta = 2, Mensajería = 3, Transportadora = 4, TransportadoraInternacional = 5, Otra = 255
        }
        public enum AmbienteFacturacionElectronica { Producción = 1, Pruebas = 2 }; // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Tomados del numeral 13.1.1 de la documentación de la DIAN para la facturación electrónica: 1 Producción, 2 Pruebas. Se debe mantener el valor de cada enumeración igual al código en la tabla de la DIAN.

        /// <summary>
        /// Tipo documento (@schemeName) : Tabla 6.2.1 Tipos de Identificador fiscal
        /// </summary>
        public enum TipoDocIdentificacion
        { // Tomados de la tabla 13.2.1 de la documentación de la DIAN para la facturación electrónica.
            RegistroCivil = 11, TarjetaIdentidad = 12, CédulaCiudadanía = 12, TarjetaExtranjería = 21, CédulaExtranjería = 22, Nit = 31, Pasaporte = 41,
            DocumentoIdentificaciónExtranjero = 42, NitOtroPaís = 50, Nuip = 91
        }

        public enum PagoTransporte
        {
            Desconocido, [Display(Name = "Transporte Gratis")] Gratis, [Display(Name = "Transporte Pago Contraentrega")] Contraentrega
        }

        public enum TipoFirma {
            [Display(Name = "fv")] Factura, 
            [Display(Name = "nd")] NotaDébito, 
            [Display(Name = "nc")] NotaCrédito,
            [Display(Name = "ev")] Evento,
            [Display(Name = "ad")] Attached
        }

        public enum FormaPago { Contado = 1, Crédito = 2 } // Tomados del numeral 13.3.4.1 de la documentación de la DIAN para la facturación electrónica.

        public enum TipoDocumentoElectronico
        { // Ver lista de valores posibles en el numeral 13.1.3 de la documentación de la DIAN para la facturación electrónica.
            FacturaVenta = 1, 
            FacturaExportacion = 2, 
            FacturaContingenciaFacturador = 3, 
            FacturaContingenciaDian = 4, 
            NotaCredito = 91, 
            NotaDebito = 92,
        }

        public enum TipoFacturaVenta { Venta = 1, Exportación = 2, ContingenciaFacturador = 3, ContingenciaDian = 4 };

        public enum TipoDescuento { Comercial = 0, Condicionado = 1 }; // Tomados del numeral 13.3.7 de la documentación de la DIAN para la facturación electrónica.

        public enum TipoCobro : byte { Desconocido = 0, Email = 1, Telefónico = 2, Personal = 3, AgenciaDeCobros = 4, Prejurídico = 5, Jurídico = 6, Otro = 255 } // Nuevos elementos se añaden antes de Otro.

        [Flags]
        public enum TipoContribuyente
        { // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Tomados de la tabla 13.2.6.1. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN. Se usa en el primer elemento 'Ordinario' en vez de 'No aplica' y 'Retenedor IVA' en vez de 'Agente de Retención de IVA' porque se entienden más que como están en la tabla de la DIAN. Si se agregaran nuevos elementos que no constituyen una responsabilidad fiscal según la tabla 13.2.6.1., (Como los de las responsabilidades de IVA) se deben omitir en Dian.ObtenerResponsabilidadFiscal().
            [Display(Name = "Ordinario")] Ordinario = 1, [Display(Name = "Gran Contribuyente")] GranContribuyente = 2, Autorretenedor = 4, // Ordinario es el que le aplica a una empresa normal que no se ha acogido a uno de los otros régimenes como Simple o Gran Contribuyente.
            [Display(Name = "Retenedor de IVA")] RetenedorIVA = 8, [Display(Name = "Régimen Simple")] RégimenSimple = 16,
            [Display(Name = "Responsable de IVA")] ResponsableIVA = 32, [Display(Name = "No Responsable de IVA")] NoResponsableIVA = 64 // Se complementa esta enumeración con las responsabilidades de IVA para forzar a realizar un manejo integrado en esta enumeración de todas las responsabilidades actuales y futuras. Tomadas de la tabla 'Modificación del anexo técnico (06-09-2019)' de la documentación de la DIAN para la facturación electrónica. ResponsableIVA es el equivalente al antiguo régimen común y NoResponsableIVA al antiguo régimen simplificado.
        }

        public enum TipoImpuestoConsumo : byte
        { // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Tomados parcialmente de la tabla TipoTributo. Es el tipo que realmente se guarda en la base de datos. No se incluyen todos los tributos porque hay muchos que pueden confundir a los usuarios y sus nombres según deben enviarse a la DIAN no son muy claros. Se pueden incluir tantos impuestos al consumo como se deseen incluso si son del mismo tipo general porque estos serán relacionados con TipoTributo antes de enviar a la DIAN. General no tiene asociado una tasa automáticamente, se debe especificar por producto. Las opciones de para los que son INC (Hasta TelefoníaCelularYDatos) se tomaron de https://www.gerencie.com/que-es-el-impuesto-al-consumo.html.
            Desconocido = 0, General = 1, VehículosLujo = 2, Aeronaves = 3, Vehículos = 4, MotocicletasLujo = 5, Embarcaciones = 6,
            ServiciosRestaurante = 7, TelefoníaCelularYDatos = 8, BolsasPlásticas = 9, Carbono = 10, Combustibles = 11, DepartamentalNominal = 12,
            DepartamentalPorcentual = 13, SobretasaCombustibles = 14, Otro = 255
        }

        public enum ModoImpuesto { Exento, Porcentaje, Unitario }

        public enum ConceptoRetención : byte
        { // No cambiar los nombres de las enumeración ni de los elementos porque estos se usan en los archivos de opciones JSON. Tomados de https://www.gerencie.com/tabla-de-retencion-en-la-fuente-2020.html.
            Desconocido = 0, Generales = 1, TarjetaDébitoOCrédito = 2, AgrícolasOPecuariosSinProcesamiento = 3, AgrícolasOPecuaríosConProcesamiento = 4,
            CaféPergaminoOCereza = 5, CombustiblesDerivadosPetróleo = 6, ActivosFijosPersonasNaturales = 7, Vehículos = 8, BienesRaícesVivienda = 9,
            BienesRaícesNoVivienda = 10, ServiciosGenerales = 11, EmolumentosEclesiásticos = 12, TransporteCarga = 13,
            TransporteNacionalTerrestrePasajeros = 14, TransporteNacionalAéreoOMarítimoPasajeros = 15, ServiciosPorEmpresasTemporales = 16,
            ServiciosPorEmpresasVigilanciaYAseo = 17, SaludPorIPS = 18, HotelesYRestaurantes = 19, ArrendamientoBienesMuebles = 20,
            ArrendamientoBienesInmuebles = 21, OtrosIngresosTributarios = 22, HonorariosYComisiones = 23, LicenciamientoSoftware = 24, Intereses = 25,
            RendimientosFinacierosRentaFija = 26, LoteríasRifasYApuestas = 27, ColocaciónIndependienteJuegosAzar = 28, ContratosConstruccionYUrbanización = 29
        }

        public enum Unidad
        { // Aunque un nombre más apropiado sería TamañoPaquete se prefiere Unidad porque está más difundido así no sea del todo correcto porque Unidad se podría referir a cualquier unidad de medida, como metro, kilogramo, etc. En caso que se necesite usar esas unidades de medida se puede agregar una nueva enumeración con nombre UnidadFísica.
            Desconocida = 0, Unidad = 1, Par = 2, Trío = 3, Cuarteto = 4, Quinteto = 5, MediaDocena = 6, Septeto = 7, Octeto = 8, Decena = 10,
            Docena = 12, DocenaLarga = 13, Quincena = 15, Veintena = 20, DobleDocena = 24, CuartoDeCentena = 25, Treintena = 30, Cuarentena = 40,
            CuatroDocenas = 48, MediaCentena = 50, OchoDecenas = 80, OchoDocenas = 96, DiezDocenas = 120, Centena = 100, Gruesa = 144,
            DobleCentena = 200, VeinteDocenas = 240, TripleCentena = 300, CuatroCentenas = 400, MedioMillar = 500, Millar = 1000, DobleMillar = 2000,
            TripleMillar = 3000, CuatroMillares = 4000, Miríada = 10000, Millón = 1000000, Millardo = 1000000000
        }
        public enum TipoImpuesto { IVA, INC, [Display(Name = "IVA e INC")] IVAeINC, [Display(Name = "No aplica")] NoAplica }; // Tomados de la tabla 13.2.6.2. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN.

        public enum TipoTributo
        { // Tomados de la tabla 13.2.2. del 'Anexo técnico de factura electrónica de venta validación previa.pdf' de la DIAN.
            IVA = 1, INC = 4, [Display(Name = "INC Bolsas")] Bolsas = 22, [Display(Name = "INCarbono")] Carbono = 23,
            [Display(Name = "INCombustibles")] Combustibles = 24, [Display(Name = "ReteIVA")] RetenciónIVA = 5,
            [Display(Name = "ReteRenta")] RetenciónRenta = 6, [Display(Name = "IC")] DepartamentalNominal = 2,
            [Display(Name = "IC Porcentual")] DepartamentalPorcentual = 8, ICA = 3, [Display(Name = "ReteICA")] RetenciónICA = 7,
            [Display(Name = "FtoHorticultura")] Horticultura = 20, Timbre = 21, [Display(Name = "Sobretasa Combustibles")] SobretasaCombustibles = 25,
            Sordicom = 26, [Display(Name = "IC Datos")] Datos = 30, Otro = 999
        }
        #endregion Fin - Enumeraciones

        #region Métodos y Funciones
        public static string ObtenerDígitoVerificación(string nit)
        {

            if (nit == null) return null;
            var primos = new[] { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 }; // Algunos números primos seleccionados por la DIAN.
            var largoNit = nit.Length;
            var suma = 0;

            for (var i = 0; i < largoNit; i++)
            {
                suma += (nit[i].AEntero() * primos[largoNit - i - 1]);
            }

            int residuo = suma % 11; // Módulo el restante después de una división entera, por ejemplo 13 % 3 da 4,33.. con 4 como parte entera. El módulo se obtiene de 13 - 4 * 3 = 1.
            return residuo <= 1 ? residuo.ATexto() : (11 - residuo).ATexto();

        } // ObtenerDígitoVerificación>
        #endregion Métodos y Funciones>


        #region Variables Autocalculadas

        public static DateTime AhoraUtcAjustado => AhoraUtc(-5);

        #endregion Variables Autocalculadas>

    }
}

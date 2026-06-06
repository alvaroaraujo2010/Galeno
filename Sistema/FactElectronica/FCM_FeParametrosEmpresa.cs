using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text.Json.Serialization;
using static Sistema.Dian.Global;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace Sistema.Dian
{
#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

    /// <summary>
    /// Opciones, datos y configuraciones propias de la empresa usuaria de SimpleOps. Suelen iniciar nulas o en valores predeterminados muy probables. 
    /// Son propiedades particulares para cada empresa usuaria de SimpleOps que son comunes a todos los usuarios en la misma empresa.
    /// Su modificación está restringida por roles y se actualiza automáticamente en los otros equipos cuando se da un cambio en uno de ellos.
    /// Los valores iniciales en código solo sirven para autogenerar el archivo Empresa.json cuando no exista y para evitar tener que 
    /// declarar las propiedades permitiendo valores nulos.
    /// </summary>
    public sealed class OpcionesEmpresa
    { // No cambiar los nombres de las propiedades porque estos se usan en los archivos de opciones JSON. Si alguna propiedad pudiera tener valores diferentes para diferentes usuarios/equipos de la empresa se debe usar OpcionesEquipo. No debe tener métodos (estos van en Global), pero si se permiten propiedades autocalculadas para algunas propiedades que tiene sentido que le pertenezcan al objeto Empresa.


        #region Patrón Singleton
        // Tomado de https://csharpindepth.com/Articles/Singleton.

        private static readonly Lazy<OpcionesEmpresa> DatosLazy = new Lazy<OpcionesEmpresa>(() => new OpcionesEmpresa());

        public static OpcionesEmpresa Datos { get { return DatosLazy.Value; } } // Normalmente esta sería la variable que se accede pero se prefiere hacer una variable auxiliar Empresa en Global.cs para tener un acceso más fácil sin necesidad de escribir OpcionesEmpresa.Datos.

        private OpcionesEmpresa()
        {
            // Cargar aqui todos los datos desde tabla variables del sistema y desde tablas
            //FcvCargarDatos();
            //FcvGenerarRutas();
            //CertificadoClaveAcceso = File.ReadAllText(CertificadoRutaArchivoClave);

        }

        #endregion Patrón Singleton>

        #region Propiedades y Variables

        public Municipio MunicipioFacturacion = new Municipio(); // Es un clon de solo lectura. Se garantiza no será nulo porque siempre se carga al iniciar. Datos del municipio de la dirección de facturación de la empresa. Se actualiza al iniciar SimpleOps, al cambiar Empresa.Datos.MunicipioFacturaciónID y al realizar cambios en la tabla municipios. Para que funcione la factura electrónica debe tener un departamento de Colombia y este corresponder a uno de los valores del la columna Nombre en el numeral 13.4.2 de la documentación de factura electrónica. Aunque si no corresponde no genera Rechazo si no Notificación. El código del municipio debe corresponder a un valor válido de lista de municipios en el numeral 13.4.3 de la documentación de factura electrónica de la DIAN. Para que funcione la factura electrónica con la DIAN debe ser un municipio de Colombia y su nombre corresponder a uno de los valores del la columna Nombre Municipio en el numeral 13.4.3 de la documentación de factura electrónica. Aunque si no corresponde no genera Rechazo si no Notificación.
        private string municipioFacturacionID; // ID del municipio de la dirección de facturación
        public string MunicipioFacturacionID
        {

            get => municipioFacturacionID;

            set
            {

                if (municipioFacturacionID != value)
                {
                    municipioFacturacionID = value;
                }

            }

        } // MunicipioFacturaciónID>


        public Municipio MunicipioUbicacion = new Municipio(); // Es un clon de solo lectura. Se garantiza que no será nulo porque siempre se carga al iniciar, incluso si MunicipioUbicaciónID es nulo porque en ese caso usa MunicipioFacturaciónID. Municipio de la dirección de ubicación de la empresa. Se actualiza al iniciar SimpleOps, al cambiar Empresa.Datos.MunicipioUbicaciónID y al realizar cambios en la tabla municipios.

        private string? municipioUbicacionID = null; // Se usa si es necesario especificar un municipioID diferente al de facturación para la ubicación de la empresa. Si es nulo se usa MunicipioFacturaciónID.
        public string? MunicipioUbicacionID
        {

            get => municipioUbicacionID;

            set
            {

                if (municipioUbicacionID != value)
                {
                    municipioUbicacionID = value;
                }

            }

        } // MunicipioUbicaciónID>


        public string? RazonSocial { get; set; } = "Ventas de Toditos la Eperazna";// Razón social de la empresa como está registrada en el RUT.

        public string? DireccionFacturacion { get; set; } = "Calle 16A - 19D - 65"; // Dirección de facturación registrada en el RUT.

        public string? DireccionUbicacion { get; set; } = "Valledupar - Cesar"; // Se usa si es necesario especificar una dirección diferente a la de facturación para la ubicación de la empresa. Si es nula se usa la dirección de facturación.

        public bool ExentoIVA { get; set; } = false; // Si la empresa es exenta de IVA y todos los proveedores le deben vender sin IVA. Podría aplicar a algunas empresas con régimenes especiales de impuestos independiente de su tipo de contribuyente. Si MunicipioFacturación es un municipio exento de IVA será exento sin importar el valor que se establezca aquí.

        public TipoEntidad TipoEntidad { get; set; } = TipoEntidad.Empresa; // Especifica si es empresa o persona natural. No puede ser desconocida porque se necesita para la facturación electrónica.

        /// <summary>
        /// Tipo documento (@schemeName) : Tabla 6.2.1 Tipos de Identificador fiscal (por defecto 31=Nit)
        /// </summary>
        public string TipoNit { get; set; } = "31";

        /// <summary>
        /// Nit de la empresa sin dígito de verificación.
        /// </summary>
        public string? Nit { get; set; } = "7617981";

        public string? NombreComercial { get; set; } = "Megassoft - Makiia";// Se usa para notificar a la DIAN en la factura electrónica y para usarlo en representación gráfica de las facturas. Si es nulo se omite en la factura electrónica y en la representación gráfica se usa la razón social.

        //public TipoContribuyente TipoContribuyente { get; set; } = TipoContribuyente.Ordinario | TipoContribuyente.ResponsableIVA; // Si se necesitan agregar varios valores se hace así: Global.TipoContribuyente.Autorretenedor | Global.TipoContribuyente.AgenteDeRetenciónIVA. 
        /// <summary>
        /// viene de la tabla (6.2.4 Regimen fiscal - Pagina 347) 48=Responsable de Impuesto IVA 49=No responsable de IVA
        /// </summary>
        public string TipoContribuyente { get; set; } = "48"; // viene de la tabla (6.2.4 Regimen fiscal - Pagina 347)

        /// <summary>
        /// FAJ26: viene de la tabla (6.2.7 Regimen fiscal - Pagina 347, por defecto "0-49" =No responsable de IVA
        /// </summary>
        public string ResponsabelFiscal { get; set; } = "0-48"; // viene de la tabla (6.2.7 Regimen fiscal - Pagina 347)

        public double PorcentajeIVAPredeterminado { get; set; } = 0.19; // El porcentaje de IVA que se aplica si no se especifica ni en el producto ni en el cliente ni en el municipio del cliente. Si el TipoContribuyente es NoResponsableIVA el PorcentajeIVAPredeterminadoEfectivo que es el que verderamente se usa es cero sin importar el valor que se use aquí.

        public double PorcentajeImpuestoConsumoPredeterminado { get; set; } = 0; // El porcentaje de impuesto de consumo que se aplica si no se especifica en el producto ni se puede obtener del tipo.

        public double PorcentajeRetenciónICA { get; set; } = 0;

        public double PorcentajeRetencionesExtra { get; set; } = 0;

        public decimal MínimoRetenciónICA { get; set; } = 0;

        public decimal MínimoRetencionesExtra { get; set; } = 0;

        #endregion Propiedades y Variables>

        #region Variables Facturación Electrónica

        #region Configuracion base 1>

        public AmbienteFacturacionElectronica AmbienteFacturacionElectronica { get; set; } = AmbienteFacturacionElectronica.Producción; // Código que describe el ambiente de destino donde será procesada la validación previa de los documentos electrónicos. Siempre inicia en Pruebas porque parte del proceso de habilitación de la facturación electrónica implica iniciar en modo Pruebas y después cambiarlo a Producción.

        public decimal? NúmeroAutorizaciónFacturación { get; set; } = 18764004346680; // Número del código de la resolución otorgada para la numeración de facturación.

        public DateTime? InicioAutorizaciónFacturación { get; set; } = DateTime.Parse("17/09/2020"); // Fecha inicial de la autorización de la numeración de facturación.

        public DateTime? FinAutorizaciónFacturación { get; set; } = DateTime.Parse("16/09/2021"); // Fecha final de la autorización de la numeración de facturación.

        public string? PrefijoFacturas { get; set; } = "FE"; // Prefijo de la autorización de numeración de facturación dado por el SIE de numeración. 

        public string? PrefijoNotaCredito { get; set; } = "NC"; // Prefijo de la autorización de numeración de facturación dado por el SIE de numeración. 

        public string? PrefijoNotaDebito { get; set; } = "ND"; // Prefijo de la autorización de numeración de facturación dado por el SIE de numeración. 

        public int? PrimerNúmeroFacturaAutorizada { get; set; } = 1; // Valor inicial del rango de numeración otorgado por la DIAN.

        public int? ÚltimoNúmeroFacturaAutorizada { get; set; } = 1000; // Valor final del rango de numeración otorgado por la DIAN.

        /// <summary>
        /// TestSetID provisto por la DIAN para realizar las pruebas de habilitación de facturación electrónica.
        /// </summary>
        public string? IdentificadorPruebas { get; set; } = "TestSetID"; // TestSetID provisto por la DIAN para realizar las pruebas de habilitación de facturación electrónica.

        //public int PróximoNúmeroDocumentoElectrónicoPruebas { get; set; } = 1; // Se usa tanto para las facturas como para las notas, no importa que en cada tipo de documento se salten números.
        /// <summary>
        /// Número consecutivo del documento electrónico. Se reinicia automáticamente cada año. Se genera autoincrementa automáticamente para los 
        /// documentos de venta y se pueden cargar desde el archivo xml para los documentos de compra.
        /// </summary>
        public int ConsecutivoDianAnual { get; set; } = 1; // Puede ser nulo para permitir la migración de datos anteriores y para compras de proveedores que aún no tengan implementada la factura electrónica o si no se manejan las compras mediante archivos xml de facturas electrónicas.

        /// <summary>
        ///  Identificador de la aplicación habilitado para la emisión de facturas electrónicas. Es único para cada empresa que use SimpleOps.
        /// </summary>
        public string? IdentificadorAplicación { get; set; } = "a45454f7878-e-4545454-e4545-f4545";

        public string? PinAplicación { get; set; } = "5855"; // Pin elegido por el usuario que habilitó la facturación electrónica en la DIAN.

        public string? ClaveTécnicaAplicación { get; set; } = "a45454f7878-e-4545454-e4545-f4545-56546546";// Clave dada por la DIAN al habilitar la facturación electrónica.

        public string? NombreContactoFacturación { get; set; } = "FULANO DE TAL"; // Se usa para escribirlo en la factura electrónica. No es obligatorio, pero los clientes podrían hacer uso de él.

        public string? TeléfonoContactoFacturación { get; set; } = "3107289965"; // Se usa para escribirlo en la factura electrónica. No es obligatorio, pero los clientes podrían hacer uso de él.

        public string? EmailContactoFacturación { get; set; } = "correocliente@hotmail.com"; // Se usa para escribirlo en la factura electrónica. No es obligatorio, pero los clientes podrían hacer uso de él.

        public decimal ImpuestoConsumoUnitarioPredeterminado { get; set; } = 0; // El valor unitario de impuesto de consumo que se aplica si no se especifica en el producto ni se puede obtener del tipo.

        public TipoImpuestoConsumo TipoImpuestoConsumoPredeterminado { get; set; } = TipoImpuestoConsumo.General; // Se usará como predeterminado para todos los productos que tengan TipoImpuestoConsumoPropio desconocido. Nunca debe ser desconocido, si lo es saca excepción en ObtenerTipoTributo().

        public ConceptoRetención ConceptoRetenciónPredeterminado { get; set; } = ConceptoRetención.Generales; // Concepto de retención en la fuente que se usará cuando el ConceptoRetenciónPropio de un producto sea desconocido.
        #endregion Configuracion base 1>

        public Aplicacion oApp = Aplicacion.Instancia();

        #region Rutas

        public static string RutaBase;
        public static string RutaBaseRecursos;
        public string RutaAplicación = RutaBase;

        /// <summary>
        /// Solo ruta del XML del documento electrónico sin firmar
        /// </summary>
        public string RutaDocumentoSinFirmar { get; set; } // "C:/Proyectos/TiggerPack20/GaleriaRecursos/FacturacionEletronica/Facturas/SinFirmar/" // Se maneja como una propiedad para asegurar que su valor es el mismo durante el tiempo de vida del objeto y evitar casos especiales en los que se inicie el procesamiento antes de media noche, se finalice después y no se pueda realizar porque no encuentre el archivo sin firma.

        /// <summary>
        /// Solo ruta del XML del documento electrónico firmado. Pendiente para enviar a la Dian
        /// </summary>
        public string RutaDocumentoFirmado { get; set; } // "C:/Proyectos/TiggerPack20/GaleriaRecursos/FacturacionEletronica/Facturas/Firmadas/PendienteEnvio/"

        #endregion Rutas>

        #region Ceritificado Digital

        /// <summary>
        /// Tipo certificado digital PFX/P12
        /// </summary>
        public string CertificadoTipo { get; set; } = "PFX";

        /// <summary>
        /// Nombre del archivo fisico del certificado digital con extension
        /// </summary>
        public string CertificadoNombreArchivo { get; set; }

        /// <summary>
        /// Nombre del archivo fisico (archivo .txt) que contiene la clave para abrir certificado digital
        /// </summary>
        public string CertificadoNombreArchivoClave { get; set; }

        /// <summary>
        /// Clave proveniente del archivo .txt, para abrir el archivo fisico del certificado digital
        /// </summary>
        public string CertificadoClaveAcceso { get; set; }

        /// <summary>
        /// Ruta y nombre archivio fisico con extension .pfx /.p12 que contiene el certificado para la firma digital.
        /// </summary>
        public string CertificadoRutaArchivo { get; set; }

        /// <summary>
        /// Ruta y nombre archivo .txt clave del certificado sin ningún espacio al frente ni atrás.
        /// </summary>
        public string CertificadoRutaArchivoClave { get; set; }

        #endregion Ceritificado Digital

        #endregion Variables Facturación Electrónica>

        #region Propiedades Autocalculadas>

        [JsonIgnore]
        public string? DirecciónUbicaciónEfectiva => DireccionUbicacion ?? DireccionFacturacion;

        /*
        [JsonIgnore]
        public int MunicipioUbicaciónEfectivoID => MunicipioUbicaciónID ?? MunicipioFacturaciónID;
        */
        /// <summary>
        /// El nombre de la empresa. Se usa el nombre comercial si no es nulo, si es nulo se usa la razón social.
        /// </summary>
        [JsonIgnore]
        public string? Nombre => NombreComercial ?? RazonSocial;


        //[JsonIgnore]
        public string? DigitoVerificacionNit;
        //public string? DígitoVerificaciónNit => ObtenerDígitoVerificación(Nit);

        /*
        [JsonIgnore]
        public string CódigoDocumentoIdentificación => ObtenerDocumentoIdentificación(TipoEntidad).AValor();

        [JsonIgnore]
        public double PorcentajeIVAPredeterminadoEfectivo => TipoContribuyente.HasFlag(TipoContribuyente.NoResponsableIVA) ? 0 : PorcentajeIVAPredeterminado;
        */

        #endregion Propiedades Autocalculadas>

        #region FcvCargarRazonSocial
        /// <summary>
        /// Cargar parametros desde tabla razon social
        /// </summary>
        /// <param name="tcrTipoId">Tipo "ID"=Codigo unico de la tabla "NIT"=Numero del Nit Razón social </param>
        /// <param name="tcrCodigoRegistro">Codigo unico o Nit de la razon social</param>
        public void FcvCargarRazonSocial(string tcrTipoId, string tcrCodigoRegistro)
        {
            var lobReg = ModeloFeRazonSocial.FlsListaFcmfemaesrazsocmaID(tcrTipoId, tcrCodigoRegistro);

            if (lobReg != null)
            {
                //-----------------------------------------------
                // Paramtros Empresa
                //-----------------------------------------------
                #region Paramtros Empresa

                // "EMPRESA-TIPO-JURIDICA" - Identificador de tipo de organización jurídica de la de persona
                TipoEntidad = lobReg.Fcm_tipjur_fcem == "1" ? TipoEntidad.Empresa : TipoEntidad.Persona;
                TipoContribuyente = lobReg.Fcm_tipjur_fcem.Trim() == "1" ? "48" : "49";

                // "EMPRESA-TIPO-DOC-NIT" - Tipo numero documento Nit
                TipoNit = lobReg.Fcm_tipdoc_fctn.Trim();

                // "EMPRESA-NUMERO-NIT" - Numero del Nit de la empresa
                Nit = lobReg.Fcm_numdoc_fcem.Trim();

                // "EMPRESA-DIGITO-VER-NIT" - Digito de verifcacion del Nit
                DigitoVerificacionNit = lobReg.Fcm_digver_fcem.Trim();

                // "EMPRESA-NOMBRE-COMERCIAL" - Nombre comercial de la empresa
                NombreComercial = lobReg.Fcm_nomcom_fcem.Trim();

                // "EMPRESA-RAZON-SOCIAL" - Nombre o Razón Social (para inforamción tributaria)
                RazonSocial = lobReg.Fcm_razsoc_fcem.Trim();

                // "EMPRESA-RESPONSAB-FISCAL")  - FAJ26 *- Responsable Fiscal Tipo Contribuyente Responsabilidades fiscales de la empresa
                ResponsabelFiscal = lobReg.Fcm_codres_fcrf.Trim();

                // "EMPRESA-ACTIVIDAD-ECONOMICA" - Corresponde al código de actividad económica CIIU
                // por el momento no - lobReg.Sis_codact_sitr

                // "EMPRESA-RESIDENCIA-MUNICIPIO" - Codigo DANE Municipio de residencia  donde ejerce la actividad comercial
                MunicipioUbicacion.CargarDatos(lobReg.Sis_idemun_muni.Trim());
                MunicipioFacturacion = MunicipioUbicacion;

                // "EMPRESA-RESIDENCIA-DIRECCION") - Direccion de residencia comercial
                DireccionFacturacion = lobReg.Fcm_dirres_fcem.Trim();
                DireccionUbicacion = DireccionFacturacion;

                // "EMPRESA-RESIDENCIA-TELEFONO" - Telefonos para contacto 
                // add aqui - lobReg.Fcm_nrotel_fcem

                // "EMPRESA-RESIDENCIA-CORREO" - Correo eletronico  empresarial para recibir notificaciones legales
                // add aqui - lobReg.Fcm_correo_fcem

                // "EMPRESA-RESIDENCIA-COD-POSTAL" - Codigo postal según lugar de Residencia
                // add aqui - lobReg.Sis_codpos_sicp

                #endregion Paramtros Empresa

                //-----------------------------------------------
                // Paramtros Ambiente facturación
                //-----------------------------------------------
                #region Paramtros Ambiente facturación

                // "DIAN-AMBIENTE-FACTURACION" - Ambiente facturación  Activo
                var lcrAmb = lobReg.Fcm_ambien_fcem.Trim();
                AmbienteFacturacionElectronica = lcrAmb == "1" ? AmbienteFacturacionElectronica.Producción :
                                                                     AmbienteFacturacionElectronica.Pruebas;

                // "DIAN-SOFTWARE-NOMBRE" - Nombre del Software en la DIAN
                // add aqui - lobReg.Fcm_sofnom_fcem

                // "DIAN-SOFTWARE-ID" - Codigo unico registro del Software en la DIAN
                IdentificadorAplicación = lobReg.Fcm_sofide_fcem.Trim();

                // "DIAN-SOFTWARE-PIN" - Numero de Pin del Software dado en el registro DIAN 
                PinAplicación = lobReg.Fcm_sofpin_fcem.Trim();

                // "DIAN-ID-SET-PRUEBAS" - Numero del set de pruebas (TestSetId) dado por DIAN para el Software
                IdentificadorPruebas = lobReg.Fcm_setpru_fcem.Trim();

                // "DIAN-URL-SET-PRUEBAS" - Url del Web Service para conexión y envio del set de pruebas
                // add aqui - lobReg.Fcm_urlset_fcem

                // "DIAN-URL-PRODUCCION" - Url del Web Service para conexión y envio en producción
                // add aqui - lobReg.Fcm_urlset_fcem

                // "DIAN-CLAVE-TECNICA-PRODUCCION" - Codigo clave Tecnica del Software habilitado para  Producción
                ClaveTécnicaAplicación = lobReg.Fcm_clatec_fcem.Trim();

                // "DIAN-CERT-FIRMA-TIPO-FORMATO" - Tipo de certificado digital expedido por la DIAN
                CertificadoTipo = lobReg.Fcm_certip_fcem.Trim();

                // "DIAN-CERT-FIRMA-NOMBRE-ARCHIVO" - Nombre del archivo fisico del certificado digital
                CertificadoNombreArchivo = lobReg.Fcm_cerarc_fcem.Trim();

                // "DIAN-CERT-FIRMA-NOM-ARCH-CLAVE" - Nombre del archivo fisico  con clave del certificado
                CertificadoNombreArchivoClave = lobReg.Fcm_cerark_fcem.Trim();

                // "DIAN-CERT-FIRMA-HASH-ARCHIVO" - Certificado digital almacenado en un campo de la base de dats
                // add aqui - lobReg.Fcm_cerhas_fcem

                #endregion Paramtros Ambiente facturación>

                #region Usuario de facturación>

                // "CONTACTO-DIAN-NOMBRE" - Nombre del Usuario facturador o contacto
                NombreContactoFacturación = lobReg.Fcm_ctonom_fcem.Trim();

                // "CONTACTO-DIAN-TELEFONO" - Telefono del Area de Facturacion o contacto con la empresa
                TeléfonoContactoFacturación = lobReg.Fcm_ctotel_fcem.Trim();

                // "CONTACTO-DIAN-EMAIL" - Correo eletronico para contacto con Facturación 
                EmailContactoFacturación = lobReg.Fcm_ctoema_fcem.Trim();

                #endregion Usuario de facturación>

                FcvCargarResolucionFacturacion("ID", lobReg.Fcm_secres_srfa);
                FcvGenerarRutasCertificados();
                FcvGenerarRutas();
                CertificadoClaveAcceso = File.ReadAllText(CertificadoRutaArchivoClave);
            }
        }
        #endregion FcvCargarRazonSocial

        #region FcvCargarDatos
        /// <summary>
        /// Cargar parametros desde variables de configuracion del sistema
        /// </summary>
        private void FcvCargarDatos()
        {
            var tmpDatos = SYSValidarCodigo.FlsSelectGrupoSysvarconfigmdEx();

            if (tmpDatos != null)
            {
                foreach (var lobReg in tmpDatos)
                {
                    var lcrVarKey = lobReg.sys_varkey_sycv.Trim();

                    //-----------------------------------------------
                    // Paramtros Empresa
                    //-----------------------------------------------
                    #region Paramtros Empresa

                    if (lcrVarKey == "EMPRESA-TIPO-JURIDICA")   // Identificador de tipo de organización jurídica de la de persona
                    {
                        TipoEntidad = lobReg.sys_vardfl_sycv.Trim() == "1" ? TipoEntidad.Empresa : TipoEntidad.Persona;
                        TipoContribuyente = lobReg.sys_vardfl_sycv.Trim() == "1" ? "48" : "49";
                    }

                    if (lcrVarKey == "EMPRESA-TIPO-DOC-NIT")   // Tipo numero documento Nit
                    {
                        TipoNit = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-NUMERO-NIT")   // Numero del Nit de la empresa
                    {
                        Nit = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-DIGITO-VER-NIT")   // Digito de verifcacion del Nit
                    {
                        DigitoVerificacionNit = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-NOMBRE-COMERCIAL")   // Nombre comercial de la empresa
                    {
                        NombreComercial = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-RAZON-SOCIAL")   // Nombre o Razón Social (para inforamción tributaria)
                    {
                        RazonSocial = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-RESPONSAB-FISCAL")   // FAJ26 *- Responsable Fiscal Tipo Contribuyente Responsabilidades fiscales de la empresa
                    {
                        ResponsabelFiscal = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "EMPRESA-ACTIVIDAD-ECONOMICA")   // Corresponde al código de actividad económica CIIU
                    {
                        // por el momento no 
                    }

                    if (lcrVarKey == "EMPRESA-RESIDENCIA-MUNICIPIO")   // Codigo DANE Municipio de residencia  donde ejerce la actividad comercial
                    {
                        MunicipioUbicacion.CargarDatos(lobReg.sys_vardfl_sycv.Trim());
                        MunicipioFacturacion = MunicipioUbicacion;
                    }

                    if (lcrVarKey == "EMPRESA-RESIDENCIA-DIRECCION")   // Direccion de residencia comercial
                    {
                        DireccionFacturacion = lobReg.sys_vardfl_sycv.Trim();
                        DireccionUbicacion = DireccionFacturacion;
                    }

                    if (lcrVarKey == "EMPRESA-RESIDENCIA-TELEFONO")   // Telefonos para contacto 
                    { }

                    if (lcrVarKey == "EMPRESA-RESIDENCIA-CORREO")   // Correo eletronico  empresarial para recibir notificaciones legales
                    { }

                    if (lcrVarKey == "EMPRESA-RESIDENCIA-COD-POSTAL")   // Codigo postal según lugar de Residencia
                    { }
                    #endregion Paramtros Empresa

                    //-----------------------------------------------
                    // Paramtros Ambiente facturación
                    //-----------------------------------------------
                    #region Paramtros Ambiente facturación

                    if (lcrVarKey == "DIAN-AMBIENTE-FACTURACION")   // Ambiente facturación  Activo
                    {
                        var lcrAmb = lobReg.sys_vardfl_sycv.Trim();
                        AmbienteFacturacionElectronica = lcrAmb == "1" ? AmbienteFacturacionElectronica.Producción :
                                                                         AmbienteFacturacionElectronica.Pruebas;
                    }

                    if (lcrVarKey == "DIAN-SOFTWARE-NOMBRE")   // Nombre del Software en la DIAN
                    { }

                    if (lcrVarKey == "DIAN-SOFTWARE-ID")   // Codigo unico registro del Software en la DIAN
                    {
                        IdentificadorAplicación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-SOFTWARE-PIN")   // Numero de Pin del Software dado en el registro DIAN 
                    {
                        PinAplicación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-ID-SET-PRUEBAS")   // Numero del set de pruebas (TestSetId) dado por DIAN para el Software
                    {
                        IdentificadorPruebas = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-URL-SET-PRUEBAS")   // Url del Web Service para conexión y envio del set de pruebas
                    { }

                    if (lcrVarKey == "DIAN-URL-PRODUCCION")   // Url del Web Service para conexión y envio en producción
                    { }

                    if (lcrVarKey == "DIAN-CLAVE-TECNICA-PRODUCCION")   // Codigo clave Tecnica del Software habilitado para  Producción
                    {
                        ClaveTécnicaAplicación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-CERT-FIRMA-TIPO-FORMATO")   // Tipo de certificado digital expedido por la DIAN
                    {
                        CertificadoTipo = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-CERT-FIRMA-NOMBRE-ARCHIVO")   // Nombre del archivo fisico del certificado digital
                    {
                        CertificadoNombreArchivo = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "DIAN-CERT-FIRMA-NOM-ARCH-CLAVE")   // Nombre del archivo fisico  con clave del certificado
                    {
                        CertificadoNombreArchivoClave = lobReg.sys_vardfl_sycv.Trim();
                    }

                    #endregion Paramtros Ambiente facturación>

                    #region Usuario de facturación>

                    if (lcrVarKey == "CONTACTO-DIAN-NOMBRE")   // Nombre del Usuario facturador o contacto
                    {
                        NombreContactoFacturación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "CONTACTO-DIAN-TELEFONO")   // Telefono del Area de Facturacion o contacto con la empresa
                    {
                        TeléfonoContactoFacturación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    if (lcrVarKey == "CONTACTO-DIAN-EMAIL")   // Correo eletronico para contacto con Facturación 
                    {
                        EmailContactoFacturación = lobReg.sys_vardfl_sycv.Trim();
                    }

                    #endregion Usuario de facturación>

                }

                FcvGenerarRutasCertificados();
            }

        }
        #endregion FcvCargarDatos

        #region FcvGenerarRutasCertificados
        /// <summary>
        /// Generar las rutas del certificado
        /// </summary>
        private void FcvGenerarRutasCertificados()
        {
            // Generar las rutas del certificado
            CertificadoRutaArchivo = oApp.gcrAppRecursoPathCompleta +
                                        @"\FacturacionEletronica\Certificado\" + CertificadoNombreArchivo;

            CertificadoRutaArchivoClave = oApp.gcrAppRecursoPathCompleta +
                                        @"\FacturacionEletronica\Certificado\" + CertificadoNombreArchivoClave;
        }
        #endregion FcvGenerarRutasCertificados

        #region FcvGenerarRutas
        /// <summary>
        /// Generar las diferentes rutas que se necesitan en los procesos
        /// </summary>
        private void FcvGenerarRutas()
        {
            // Iniciar las Rutas Base de la aplicacion
            RutaBase = oApp.gcrAppInicioPathCompleta;
            RutaAplicación = RutaBase;
            RutaBaseRecursos = oApp.gcrAppRecursoPathCompleta;

            RutaDocumentoSinFirmar = oApp.gcrAppRecursoPathCompleta + @"\FacturacionEletronica\Documentos\SinFirmar\";
            RutaDocumentoFirmado   = oApp.gcrAppRecursoPathCompleta + @"\FacturacionEletronica\Documentos\Firmados\PendienteEnvio\";
        }
        #endregion FcvCargarDatos

        #region FcvCargarResolucionFacturacion
        /// <summary>
        /// Cargar parametros tabla de resoluciones facturacion
        /// </summary>
        /// <param name="tcrTipoId">Tipo ID = Codigo unico de la tabla "NR"=Numero Resolución</param>
        /// <param name="tcrCodigoRegistro">Codigo unico en la tabla o Numero de la resolución</param>
        public void FcvCargarResolucionFacturacion(string tcrTipoId, string tcrCodigoRegistro)
        {
            var lobReg = ModeloResolDianFacturas.FobRegistroResolucionDian(tcrTipoId, tcrCodigoRegistro);

            if (lobReg != null)
            {
                FcvCargarResolucionFacturacion(lobReg);
            }
        }
        #endregion FcvCargarResolucionFacturacion>
        #region FcvCargarResolucionFacturacion
        /// <summary>
        /// Cargar parametros de la Resolución Autorizada para facturacion DIAN
        /// </summary>
        public void FcvCargarResolucionFacturacion(ModeloResolDianFacturas tobReg)
        {
            if (tobReg != null)
            {
                NúmeroAutorizaciónFacturación = Convert.ToDecimal(tobReg.Fcm_numres_srfa);
                PrefijoFacturas               = tobReg.Fcm_prefij_srfa;
                InicioAutorizaciónFacturación = tobReg.Fcm_fecini_srfa;
                FinAutorizaciónFacturación    = tobReg.Fcm_fecfin_srfa;
                PrimerNúmeroFacturaAutorizada = tobReg.Fcm_facini_srfa;
                ÚltimoNúmeroFacturaAutorizada = tobReg.Fcm_facfin_srfa;
            }
        }
        #endregion FcvCargarResolucionFacturacion>

    } // OpcionesEmpresa>

#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
}


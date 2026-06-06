using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Sistema.Dian.Global;
using static Sistema.Dian.General;

namespace Sistema.Dian
{
    #pragma warning disable CS8632 
    #pragma warning disable CS8625
    #pragma warning disable CS8618


    /// <summary>
    /// Cliente o Proveedor.
    /// </summary>
    public abstract class EntidadEconómica 
    { // Es Rastreable porque las entidades económicas son actualizados frecuentemente y es de interés tener la información de su creación.


        #region Propiedades

        [Key]
        public int ID { get; set; }


        /// <summary>
        /// Razón social de la empresa o nombre de la persona.
        /// </summary>
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string Nombre { get; set; } // Obligatorio. No es la clave principal porque podría ser cambiado y aumentaría mucho el tamaño de las tablas que lo relacionan.

        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string? NombreComercial { get; set; } // Opcional. Se puede usar para ser impreso en la representación gráfica de las facturas y también se informa a la DIAN en la factura electrónica.

        /// <summary>
        /// Desconocido = 0, Empresa = 1, Persona = 2.
        /// </summary>
        public TipoEntidad TipoEntidad { get; set; } = TipoEntidad.Desconocido; // Empresa o Persona. Por lo general no se necesita realizar esta distinción porque una distinción más apropiada para fines de precios y condiciones comerciales se puede establecer en TipoCliente. No se usa el nombre más simple Tipo porque en el caso de clientes también existe TipoCliente entonces se prefiere hacer una distinción explicita de ambos tipos.

        /// <summary>
        /// Ordinario = 1, GranContribuyente = 2, Autorretenedor = 4, RetenedorIVA = 8, RégimenSimple = 16, ResponsableIVA = 32, NoResponsableIVA = 64. 
        /// Una entidad económica (cliente o proveedor) puede tener múltiples tipos de contribuyente, en estos casos se suman los valores de los tipos que 
        /// le apliquen. Por ejemplo, si es GranContribuyente = 2, Autorretenedor = 4 y ResponsableIVA = 32, se usa el valor 2 + 4 + 32 = 38. 
        /// Si la empresa usuaria de SimpleOps no es gran contribuyente ni retenedor de IVA no es necesario conocer si los clientes son responsables de 
        /// IVA o no pues la empresa usuaria nunca necesita aplicar retención de IVA y esta información solo se necesita para su cálculo.
        /// En el caso de los proveedores si es necesario establecer si es o no responsable de IVA porque se usa esta información no aplicar IVA a sus compras.
        /// </summary>
        public TipoContribuyente TipoContribuyente { get; set; } = TipoContribuyente.Ordinario | TipoContribuyente.ResponsableIVA;

        /// <summary>
        /// NIT (sin dígito de verificación) o cédula de ciudadanía.
        /// </summary>
        /// <MaxLength>20</MaxLength>
        [MaxLength(20)]
        public string? Identificación { get; set; } // Es opcional porque para cotizar no es necesario disponer de él.

        /// <summary>
        /// Principal. Usado en la factura.
        /// </summary>
        /// <MaxLength>30</MaxLength>
        [MaxLength(30)]
        public string? Teléfono { get; set; }

        /// <summary>
        /// General alternativo. Es útil para facilitar la adición de un telefono general alternativo de la entidad económica sin necesidad de crear un contacto asociado.
        /// </summary>
        /// <MaxLength>30</MaxLength>
        [MaxLength(30)]
        public string? TeléfonoAlternativo { get; set; }

        public DirecciónCompleta? DirecciónCompleta { get; set; }


        public string? _Dirección;
        /// <summary>
        /// Principal. Usada en la factura.
        /// </summary>
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string? Dirección
        {
            get => _Dirección;
            set
            {
                _Dirección = value;
                DirecciónCompleta = DirecciónCompleta.CrearDirecciónCompleta(_Municipio, _Dirección);
            }
        }


        public Municipio? _Municipio;
        /// <summary>
        /// Principal. Usado en la factura.
        /// </summary>
        [ForeignKey("MunicipioID")]
        public Municipio? Municipio
        {
            get => _Municipio;
            set
            {
                _Municipio = value;
                DirecciónCompleta = DirecciónCompleta.CrearDirecciónCompleta(_Municipio, _Dirección);
            }
        } // Municipio>


        public string? MunicipioID { get; set; }  // No es obligatorio porque las empresas que provean productos o servicios que no requieran representación o presencia física pueden realizar cotizaciones sin necesidad de conocer el municipio del cliente.

        /// <summary>
        /// Si es positivo es a favor de la entidad económica. Si es negativo es el valor que la entidad económica le debe a la empresa.
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        /// Referencia identificadora de la entidad económica en los movimientos bancarios. Nombre basado en columna 'Referencia' en bancolombia.com.
        /// </summary>
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string? ReferenciaEnBanco { get; set; }

        /// <summary>
        /// Descripción identificadora de la entidad económica en los movimientos bancarios. Nombre basado en 'Descripción' en bancolombia.com.
        /// </summary>
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string? DescripciónEnBanco { get; set; }

        /// <summary>
        /// Cero si no tiene crédito aprobado. Aplica tanto para clientes (días de crédito dado a ellos), como para proveedores (días de crédito con ellos).
        /// </summary>
        public int DíasCrédito { get; set; }

        /// <summary>
        /// Cero si no tiene crédito aprobado, nulo si no tiene cupo definido, es decir tiene crédito ilimitado, por lo menos en SimpleOps. Aplica tanto para clientes (cupo de crédito dado a ellos), como para proveedores (cupo de crédito con ellos).
        /// </summary>
        public int? CupoCrédito { get; set; }

        #endregion Propiedades>


        #region Constructores

        public EntidadEconómica(string nombre) => (Nombre) = (nombre);

        public EntidadEconómica(string nombre, Municipio municipio) => (Nombre, MunicipioID, Municipio) = (nombre, municipio.IDMunicipio, municipio);

        #endregion Constructores>


        #region Propiedades Autocalculadas

        public bool TieneCrédito => (DíasCrédito > 0) && (CupoCrédito != 0);

        public FormaPago FormaPago => TieneCrédito ? FormaPago.Crédito : FormaPago.Contado; // Útil para la factura electrónica de la DIAN.


        /// <summary>
        /// Si es persona natural o si no tiene identificación devuelve nulo.
        /// </summary>
        /// <returns></returns>
        public string? DígitoVerificaciónNit
            => TipoEntidad switch
            {
                TipoEntidad.Desconocido => null,
                TipoEntidad.Empresa => ObtenerDígitoVerificación(Identificación),
                TipoEntidad.Persona => null,
                _ => throw new Exception(CasoNoConsiderado(TipoEntidad))
            };


        public string? NitLegalEfectivo
            => TipoEntidad switch
            {
                TipoEntidad.Desconocido => "2222222222", // Para efectos de la Dian se asumirá que un desconocido es una persona natural.
                TipoEntidad.Empresa => Identificación,
                TipoEntidad.Persona => "2222222222", // Según el elemento FAK03-2 de la tabla Invoice del archivo de documentación de facturación electrónica de la DIAN cuando es pesona natural se usa un pseudo NIT con 10 números dos.
                _ => throw new Exception(CasoNoConsiderado(TipoEntidad))
            };


        public string? NombreLegalEfectivo
            => TipoEntidad switch
            {
                TipoEntidad.Desconocido => "adquiriente final", // Para efectos de la Dian se asumirá que un desconocido es una persona natural.
                TipoEntidad.Empresa => Identificación,
                TipoEntidad.Persona => "adquiriente final", // Según el elemento FAK20 de la tabla Invoice del archivo de documentación de facturación electrónica de la DIAN cuando es pesona natural se reporta "adquiriente final".
                _ => throw new Exception(CasoNoConsiderado(TipoEntidad))
            };


        //public string CódigoDocumentoIdentificación => ObtenerDocumentoIdentificación(TipoEntidad).AValor();
        public string CódigoDocumentoIdentificación => "31";

        #endregion Propiedades Autocalculadas>


    } // Entidad>

    /// <summary>
    /// Entidad a la que se le venden productos.
    /// </summary>
    public class Cliente : EntidadEconómica
    {


        #region Propiedades

        /// <summary>
        /// Al que se enviarán las facturas electrónicas.
        /// </summary>
        public Contacto? ContactoFacturas { get; set; }
        public int? ContactoFacturasID { get; set; }

        /// <summary>
        /// Al que se enviarán las comunicaciones de cobros y estados de cuenta.
        /// </summary>
        public Contacto? ContactoCobros { get; set; }
        public int? ContactoCobrosID { get; set; }

        /// <summary>
        /// Desconocido = 0, Consumidor = 1, Distribuidor = 2, GrandesContratos = 3, Otro = 255. Desconocido solo es aceptado si se establece Global.PermitirTipoClienteDesconocido = true.
        /// </summary>
        public TipoCliente TipoCliente { get; set; } = TipoCliente.Desconocido; // No se usa el nombre más simple Tipo porque en en la entidad económica también existe TipoEntidad entonces se prefiere hacer una distinción explicita de ambos tipos.

        /// <summary>
        /// Subtipo adicional del cliente. Especialmente útil cuando TipoCliente = Otro o TipoCliente = Grandes Contratos para agrupar las razones sociales (clientes) de cada contrato.
        /// </summary>
        /// <MaxLength>50</MaxLength>
        [MaxLength(50)]
        public string? SubtipoCliente { get; set; } // Se mantiene Cliente en el nombre de la propiedad para hacerlo consistente con TipoCliente.

        /// <summary>
        /// Si es nulo se usan las reglas legales. Cero si no aplica retención de IVA.
        /// </summary>
        public double? PorcentajeRetenciónIVAPropio { get; set; }

        /// <summary>
        /// Si es nulo se usan las reglas legales. Cero si no aplica retención en la fuente.
        /// </summary>
        public double? PorcentajeRetenciónFuentePropio { get; set; }

        /// <summary>
        /// Si es nulo se usa el porcentaje en opciones. Cero si no aplica retención del ICA.
        /// </summary>
        public double? PorcentajeRetenciónICAPropio { get; set; }

        /// <summary>
        /// Si es nulo se usa el porcentaje en opciones. Retenciones varias que algunas empresas aplican al pago de todas sus facturas. Lo suelen hacer las públicas. Cero si no aplican. 
        /// </summary>
        public double? PorcentajeRetencionesExtraPropio { get; set; }

        /// <summary>
        /// Si es nulo se usan las reglas legales. Si no, realiza retención de IVA para facturas con subtotal superior o igual a este mínimo. Puede ser cero para aplicarla a todas.
        /// </summary>
        public decimal? MínimoRetenciónIVAPropio { get; set; }

        /// <summary>
        /// Si es nulo se usan las reglas legales. Si no, realiza retención en la fuente de renta para facturas con subtotal superior o igual a este mínimo. Puede ser cero para aplicarla a todas.
        /// </summary>
        public decimal? MínimoRetenciónFuentePropio { get; set; }

        /// <summary>
        /// Si es nulo se usa el mínimo en opciones. Si no, realiza retención del ICA para facturas con subtotal superior o igual a este mínimo. Puede ser cero para aplicarla a todas.
        /// </summary>
        public decimal? MínimoRetenciónICAPropio { get; set; }

        /// <summary>
        /// Si es nulo, como no hay mínimo en opciones, se aplica a todas. Si no, realiza retenciones extra para facturas con subtotal superior o igual a este mínimo. Puede ser cero para aplicarla a todas.
        /// </summary>
        public decimal? MínimoRetencionesExtraPropio { get; set; }

        /// <summary>
        /// Desconocida = 0, Ninguna = 1, MuyBaja = 10, Baja = 20, Media = 30, Alta = 40, MuyAlta = 50. Si es desconocida se usan las reglas en opciones. Al programar la asignación de los productos en inventario a las ordenes de compra pendientes se prefieren los clientes de mayor prioridad.
        /// </summary>
        public Prioridad PrioridadPropia { get; set; } = Prioridad.Desconocida;

        /// <summary>
        /// Desconocida = 0, Virtual = 1, PuntoDeVenta = 2, Mensajería = 3, Transportadora = 4, TransportadoraInternacional = 5, Otra = 255. Si es desconocida se usan las reglas en opciones. Forma de entrega predeterminada para pedidos que cumplen con las condiciones comerciales y que no se ha recibido comunicación del cliente para hacerlo de otra forma.
        /// </summary>
        public FormaEntrega FormaEntregaPropia { get; set; } = FormaEntrega.Desconocida;

        /// <summary>
        /// Si es nulo se usan las reglas en opciones. El subtotal mínimo de la orden de compra para ser envíada con transporte gratis.
        /// </summary>
        public decimal? MínimoTransporteGratisPropio { get; set; }

        /// <summary>
        /// Si es nula se usa el valor en opciones. La cantidad de copias de la factura que se imprime. Legalmente puede ser cero pues la factura electrónica es legalmente suficiente.
        /// </summary>
        public int? CopiasFacturaPropia { get; set; } // Se refiere a Propia porque el significado viene de CantidadCopiasFacturaPropia.

        /// <summary>
        /// Si es nulo se usan las reglas en opciones. El porcentaje de ganancia que se le aplica a los costos de los productos para obtener sus precios de venta. Es útil cuando no se quieren usar las listas de precios o cuando el producto no está en ellas.
        /// </summary>
        public double? PorcentajeGananciaPropio { get; set; }

        /// <summary>
        /// Si es nulo se usan las reglas en Global.ObtenerPorcentajeIVA(). Algunas entidades pueden estar exentas de IVA.
        /// </summary>
        public double? PorcentajeIVAPropio { get; set; }

        /// <summary>
        /// Se escriben en el campo observaciones de las facturas y se muestran en un cuadro de mensaje en la interfaz al hacer una factura.
        /// </summary>
        /// <MaxLength>500</MaxLength>
        [MaxLength(500)]
        public string? ObservacionesFactura { get; set; }

        [ForeignKey("RepresentanteComercialID")]
        public Usuario? RepresentanteComercial { get; set; }
        public int? RepresentanteComercialID { get; set; }

        /// <summary>
        /// Campaña de ventas que generó el primer contacto o recontacto efectivo con el cliente.
        /// </summary>
        //public Campaña? Campaña { get; set; }
        public int? CampañaID { get; set; }

        public List<ContactoCliente> ContactosClientes { get; set; } = new List<ContactoCliente>();

        public List<Sede> Sedes { get; set; } = new List<Sede>();

        #endregion Propiedades>


        #region Constructores

        private Cliente() : base(null!) { } // Solo para que EF Core no saque error.

        public Cliente(string nombre) : this(nombre, TipoCliente.Desconocido) { }

        public Cliente(string nombre, Municipio municipio) : this(nombre, municipio, TipoCliente.Desconocido) { }

        public Cliente(string nombre, TipoCliente tipoCliente) : base(nombre)
        {
            (TipoCliente) = (tipoCliente);
            VerificarNecesidadMunicipioYTipoCliente(null, tipoCliente);
        } // Cliente>

        public Cliente(string nombre, Municipio municipio, TipoCliente tipoCliente) : base(nombre, municipio)
        {
            (TipoCliente) = (tipoCliente);
            VerificarNecesidadMunicipioYTipoCliente(municipio, tipoCliente);
        } // Cliente>

        #endregion Constructores>


        #region Propiedades Autocalculadas
        /*
        public double PorcentajeRetenciónICA => PorcentajeRetenciónICAPropio ?? Generales.PorcentajeRetenciónICAPredeterminado;

        public double PorcentajeRetencionesExtra => PorcentajeRetencionesExtraPropio ?? Generales.PorcentajeRetencionesExtraPredeterminado;

        public decimal MínimoRetenciónICA => MínimoRetenciónICAPropio ?? Generales.MínimoRetenciónICAPredeterminado;

        public decimal MínimoRetencionesExtra => MínimoRetencionesExtraPropio ?? Generales.MínimoRetencionesExtraPredeterminado;

        public int CopiasFactura => CopiasFacturaPropia ?? Empresa.CopiasFacturaPredeterminada;

        public Prioridad Prioridad => PrioridadPropia != Prioridad.Desconocida ? PrioridadPropia : ObtenerPrioridadCliente(TipoCliente);

        public FormaEntrega FormaEntrega => FormaEntregaPropia != FormaEntrega.Desconocida ? FormaEntregaPropia : ObtenerFormaEntrega(Municipio);

        public decimal MínimoTransporteGratis => MínimoTransporteGratisPropio ?? ObtenerMínimoTransporteGratis(TipoCliente, Municipio);

        public double PorcentajeGanancia => PorcentajeGananciaPropio ?? ObtenerPorcentajeGananciaCliente(TipoCliente);

        public double PorcentajeIVA => PorcentajeIVAPropio ?? Empresa.PorcentajeIVAPredeterminadoEfectivo; // Es solo para fines informativos porque al facturar se debe usar la función Global.ObtenerPorcentajeIVA().
        
        public bool ExentoIVA => PorcentajeIVA == 0; // Es solo para fines informativos porque al facturar se debe usar la función Global.ObtenerPorcentajeIVA().
        */
        #endregion Propiedades Autocalculadas>


        #region Métodos y Funciones

        public override string ToString() => Nombre;


        public static void VerificarNecesidadMunicipioYTipoCliente(Municipio? municipio, TipoCliente tipoCliente)
        {

            /*
            if (municipio == null && !Empresa.HabilitarProductosVirtuales && !OperacionesEspecialesDatos)
                throw new Exception("Si no están habilitados los productos virtuales se debe establecer el municipio del cliente en el constructor.");

            if (tipoCliente == TipoCliente.Desconocido && !Empresa.PermitirTipoClienteDesconocido && !OperacionesEspecialesDatos)
                throw new Exception("Si no se permite clientes de tipo desconocido se debe establecer el tipo del cliente en el constructor.");

            */
        } // VerificarNecesidadMunicipioYTipoCliente>


        /// <summary>
        /// Cumple una función de segunda verificación que la venta no se genere con datos incorrectos porque en la 
        /// interfaz de usuario se hace el control principal.
        /// </summary>
        public static void VerificarDatosVenta(Cliente? cliente)
        {

            var éxito = true;
            if (cliente != null)
            {
                if (cliente.TipoEntidad == TipoEntidad.Desconocido) éxito = false;
                if (cliente.Identificación == null) éxito = false;
                if (cliente.Municipio == null) éxito = false;
                if (cliente.Teléfono == null) éxito = false;
                if (cliente.Dirección == null) éxito = false;
            }
            else
            {
                éxito = false;
            }
            if (!éxito) throw new Exception("Faltan datos de cliente para poder generar una venta.");

        } // VerificarDatosVenta>


        #endregion Métodos y Funciones>


    } // Cliente>

    /// <summary>
    /// Datos de contacto asociados a una dirección de email. No está restringido a una entidad económica porque un contacto puede ser válido para varias.
    /// </summary>
    public class Contacto 
    { // Es Actualizable porque todos sus datos excepto el email pueden actualizarse, pero no se hace Rastreable porque no es de mucho interés conocer la fecha de creación y es una tabla que puede crecer mucho.


        #region Propiedades

        public int ID { get; set; }

        private string _Email = null!;
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string Email
        { // Obligatorio y de solo lectura. Solo se puede establecer en la creación. 
            get => _Email;
            set
            {
                //if (!OperacionesEspecialesDatos) throw new Exception($"No se permite cambiar el email de un contacto.");
                _Email = value;
            }
        } // Email>

        /// <summary>
        /// Móvil o fijo.
        /// </summary>
        /// <MaxLength>30</MaxLength>
        [MaxLength(30)]
        public string? Teléfono { get; set; }

        /// <MaxLength>50</MaxLength>
        [MaxLength(50)]
        public string? Nombre { get; set; } // El nombre puede ser cambiado porque puede pasar que la dirección de emails corporativos permanezcan cuando cambie la persona que los atiende.

        /// <summary>
        /// Algunos contactos se pueden querer mantener en la base de datos así el email esté desactivado o eliminado. Es útil para evitar enviar comunicaciones a este email.
        /// </summary>
        public bool EmailActivo { get; set; } = true;

        #endregion Propiedades>


        #region Constructores

        private Contacto() { } // Solo para que EF Core no saque error.

        public Contacto(string email) => (_Email) = (email); // Para evitar la excepción ExcepciónNoPermitidoCambiarEmailContacto.

        #endregion Constructores>


        #region Métodos y Funciones

        public override string ToString() => Email;

        #endregion Métodos y Funciones>


    } // Contacto>

    /// <summary>
    /// Asocia los contactos a cada cliente.
    /// </summary>
    public class ContactoCliente
    { // Es Actualizable porque puede cambiar el Tipo. No es de interés conocer la fecha de creación entonces no se hace Rastreable.


        #region Propiedades

        public Cliente? Cliente { get; set; } // Obligatorio.
        public int ClienteID { get; set; } // Clave foránea que con ContactoID forman la clave principal.

        public Contacto? Contacto { get; set; } // Obligatorio.
        public int ContactoID { get; set; } // Clave foránea que con ClienteID forman la clave principal.

        /// <summary>
        /// Observaciones adicionales a Cliente.ObservacionesFactura que se escribirán en el campo de observaciones de la factura y se mostrarán en la interfaz al hacer una factura a la empresa de este contacto.
        /// </summary>
        /// <MaxLength>500</MaxLength>
        [MaxLength(500)]
        public string? ObservacionesFactura { get; set; }

        /// <summary>
        /// Desconocido = 0, Comprador = 1, Almacenista = 2, Tesorería = 5, JefeCompras = 10, AltoDirectivo = 15, Gerente = 20, Propietario = 25, Otro = 255.
        /// </summary>
        //public TipoContactoCliente Tipo { get; set; } = TipoContactoCliente.Desconocido;

        #endregion Propiedades>


        #region Constructores

        private ContactoCliente() { } // Solo para que EF Core no saque error. 

        public ContactoCliente(Cliente cliente, Contacto contacto)
            => (ClienteID, ContactoID, Cliente, Contacto) = (cliente.ID, contacto.ID, cliente, contacto);

        #endregion Constructores>


        #region Métodos y Funciones

        //public override string ToString() => $"{ATexto(Contacto, ContactoID)} de {ATexto(Cliente, ClienteID)}";

        #endregion Métodos y Funciones>


    } // ContactoCliente>

    /// <summary>
    /// Persona autorizada para usar SimpleOps.
    /// </summary>
    public class Usuario
    { // Es una tabla usualmente pequeña. No hay problema en hacerla Rastreable.


        #region Propiedades

        public int ID { get; set; }

        /// <MaxLength>50</MaxLength>
        [MaxLength(50)]
        public string Nombre { get; set; } = null!; // Obligatorio.

        public bool EsRepresentanteComercial { get; set; }

        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string Email { get; set; } = null!; // Obligatorio. Necesario para enviar notificaciones e informes.

        /// <MaxLength>30</MaxLength>
        [MaxLength(30)]
        public string? Teléfono { get; set; }

        /// <summary>
        /// Si es falso el usuario no puede iniciar la aplicación.
        /// </summary>
        public bool Activo { get; set; } = true;

        #endregion Propiedades>


        #region Constructores

        private Usuario() { } // Solo para que EF Core no saque error.

        public Usuario(string nombre, string email) => (Nombre, Email) = (nombre, email);

        #endregion Constructores>


        #region Métodos y Funciones

        public override string ToString() => Nombre;

        #endregion Métodos y Funciones>


    } // Usuario>

    /// <summary>
    /// Sucursal, oficina o bodega de un cliente.
    /// </summary>
    public class Sede
    { // Es Actualizable porque todos sus datos pueden actualizarse, pero no se hace Rastreable porque no es de mucho interés conocer la fecha de creación y es una tabla que puede crecer mucho.


        #region Propiedades

        public int ID { get; set; }

        /// <summary>
        /// Nombre identificador. Único por cada Cliente.
        /// </summary>
        /// <MaxLength>50</MaxLength>
        [MaxLength(50)]
        public string Nombre { get; set; } = null!; // Obligatorio.

        public Cliente? Cliente { get; set; } // Obligatorio.
        public int ClienteID { get; set; }

        /// <summary>
        /// Si se asocia la sede a un contacto se le podrá notificar el progreso del envío.
        /// </summary>
        public Contacto? Contacto { get; set; } // Opcional.
        public int? ContactoID { get; set; }

        /// <summary>
        /// Observaciones de envío que se escribirán en las etiquetas de envío.
        /// </summary>
        /// <MaxLength>500</MaxLength>
        [MaxLength(500)]
        public string? ObservacionesEnvío { get; set; }

        [NotMapped]
        public DirecciónCompleta? DirecciónCompleta { get; set; }


        public string MunicipioID { get; set; }
        public Municipio? _Municipio;
        public Municipio? Municipio
        { // Obligatorio.
            get => _Municipio;
            set
            {
                _Municipio = value;
                DirecciónCompleta = DirecciónCompleta.CrearDirecciónCompleta(_Municipio, _Dirección);
            }
        }


        public string _Dirección = null!;
        /// <MaxLength>100</MaxLength>
        [MaxLength(100)]
        public string Dirección
        { // Obligatorio.
            get => _Dirección;
            set
            {
                _Dirección = value;
                DirecciónCompleta = DirecciónCompleta.CrearDirecciónCompleta(_Municipio, _Dirección);
            }
        }


        #endregion Propiedades>


        #region Constructores

        private Sede() { } // Solo para que EF Core no saque error.

        public Sede(string nombre, Cliente cliente, string dirección, Municipio municipio)
            => (Nombre, ClienteID, MunicipioID, Dirección, Cliente, Municipio) = (nombre, cliente.ID, municipio.IDMunicipio, dirección, cliente, municipio);

        #endregion Constructores>


        #region Métodos y Funciones

        //public override string ToString() => $"{Nombre} de {ATexto(Cliente, ClienteID)}";

        #endregion Métodos y Funciones>


    } // Sede>

    #pragma warning restore CS8618
    #pragma warning restore CS8625
    #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".

}

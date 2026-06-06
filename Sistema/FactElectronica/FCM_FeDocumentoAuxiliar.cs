using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sistema.Modelo;
using Datos.Modelos;

namespace Sistema.Dian
{
#pragma warning disable CS8602

    /// <summary>
    /// Parametros para generar el AttachmentDocument 
    /// </summary>
    public class ParamDocAttachment
    {
        #region Campos

        /// <summary>
        /// String XML del documento a enviar en el contenedor 
        /// </summary>
        public string AttachmentDocument { get; set; }

        /// <summary>
        /// String XML del documento Response recibido como respuesta del servidor DIAN
        /// </summary>
        public string AttachmentResponse { get; set; }

        /// <summary>
        /// Fecha generacion de la respuesta
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Hora generacion de la respuesta
        /// </summary>
        public string IssueTime { get; set; }

        /// <summary>
        /// Fecha de validacion en la plataforma DIAN
        /// </summary>
        public DateTime ValidationDate { get; set; }

        /// <summary>
        /// Hora validación
        /// </summary>
        public DateTime ValidationTime { get; set; }

        #endregion Campos>
    } // Parametros Attachement

    /// <summary>
    /// Clase para gestion resumen de impuestos al generar documentos XML
    /// </summary>
    public class ResumenImpuesto
    {
        #region Campos
        /// <summary>
        /// Tipo impueto "01"=IVA "02"=ICA ...
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Nombre o descripcion del impuesto
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Porcentaje aplicado del impuesto
        /// </summary>
        public decimal Porcentaje { get; set; }

        /// <summary>
        /// Valor Base imponible para calcular el impuesto
        /// </summary>
        public decimal ValorBase { get; set; }

        /// <summary>
        /// Valor aplicado segun base imponible
        /// </summary>
        public decimal ValorTotal { get; set; }
        #endregion Campos>
    } // Resumen Impuestos

    public class Dimensión
    {
        #region Campos

        public double Alto { get; set; }

        public double Ancho { get; set; }

        public double Largo { get; set; }

        #endregion Campos>

        #region Constructores

        public Dimensión() { }

        public Dimensión(double alto, double ancho, double largo) { }

        #endregion

        #region Propiedades Autocalculadas

        public double Volumen => Alto * Ancho * Largo;

        #endregion Propiedades Autocalculadas>

    } // Dimensión>

    /// <summary>
    /// Ciudad o pueblo.
    /// </summary>
    public class Municipio
    { // Es una tabla usualmente pequeña. No hay problema en hacerla Rastreable.


        #region Propiedades

        /// <summary>
        /// ID: Concatenado codigo del Municipio DANE y codigo Departamento DANE ejemplo: 20001 -> Valledupar
        /// </summary>
        public string IDMunicipio { get; set; }

        /// <summary>
        /// Nombre del municipio segun DANE
        /// </summary>
        [MaxLength(50)]
        public string NombreMunicipio { get; set; } = "Valledupar"; // Obligatorio. No es la clave principal porque podría ser cambiado y podrían haber varios con el mismo nombre en diferentes departamentos.

        /// <summary>
        /// Nombre del departamento DANE
        /// </summary>
        [MaxLength(60)]
        public string NombreDepartamento { get; set; } = "Cesar"; // Obligatorio. Aunque se podría pensar en establecer una clave. Es 60 para cumplir con el caso de 'Archipiélago De San Andrés, Providencia Y Santa Catalina'.

        /// <summary>
        /// Código único del municipio asignado por el DANE.
        /// </summary>
        /// <MaxLength>10</MaxLength>
        [MaxLength(10)]
        public string CodigoMunicipio { get; set; } = "20001";

        #endregion Propiedades>


        #region Constructores

        public Municipio() { } // Solo para que EF Core no saque error. Se permite público para poderlo pasar nulo al método genérico C26K.CopiarA() y que dentro de este se cree la nueva instancia de Municipio.

        public Municipio(string nombre, string departamento) { }

        #endregion Constructores>


        #region Propiedades Autocalculadas

        /// <summary>
        /// Nombre del Pais (Colombia/Polombia/Locombia)
        /// </summary>
        public string NombrePais  { get; set; } = "Colombia"; 

        /// <summary>
        /// Codigo departamento segun DANE
        /// </summary>
        public string CodigoDepartamento { get; set; } = "20";

        /// <summary>
        /// Codigo del Pais (CO) Colombia
        /// </summary>
        public string CodigoPais => NombrePais == "Colombia" ? "CO" : null;

        /// <summary>
        /// Moneda Colombia
        /// </summary>
        public string Moneda { get; set; } = "COP"; // COP para Peso Colombiano. Divisa aplicable a todas las facturas. Ver lista de valores posibles en el numeral 13.3.3 en la documentación de la facturación electrónica de la DIAN. Algunos valores: COP, USD, EUR, CNY, MXN, BRL, XAU, XAG, etc. Como no se implementa el elemento PaymentExchangeRate en la facturación electrónica este valor solo puede ser COP.

        /// <summary>
        /// Codigo del lenguaje Pais = "es" => Españolete
        /// </summary>
        public string CodigoLenguajePais => NombrePais == "Colombia" ? "es" : null; // Identificador del lenguaje utilizado en el nombre del país. Para español, utilizar el literal "es". Ver lista de valores posibles en el numeral 0, columna ISO639-1. Debe ser "es" para que funcione la facturación electrónica.

        #endregion Propiedades Autocalculadas>


        #region Métodos y Funciones

        /// <summary>
        /// Devuelve el nombre del Municipio
        /// </summary>
        /// <returns></returns>
        public override string ToString() => NombreMunicipio;

        /// <summary>
        /// Cargar los datos del municipio dado el parametro tcrIdMunicipio (concatenado:  dpto+municipio)
        /// </summary>
        /// <param name="tcrIdMunicipio"></param>
        public void CargarDatos(string tcrIdMunicipio)
        {
            #region 
            using (DbAplicacion _context = new DbAplicacion())
            {

                var lobReg = (from tmp in _context.Sistabmunicipio
                              join sistabdepartame in _context.Sistabdepartame on tmp.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                              from dpto in tmsistabdepartame.DefaultIfEmpty()
                              where tmp.sis_idemun_muni == tcrIdMunicipio
                              select new
                              {
                                  Sis_idemun_muni = tmp.sis_idemun_muni,
                                  Sis_codmun_muni = tmp.sis_codmun_muni,
                                  Sis_nommun_muni = tmp.sis_nommun_muni,
                                  Sis_coddep_dpto = tmp.sis_coddep_dpto,
                                  Sis_desdep_dpto = dpto.sis_desdep_dpto,
                              }).FirstOrDefault();

                if (lobReg != null)
                {
                    IDMunicipio         = lobReg.Sis_idemun_muni;
                    CodigoMunicipio     = lobReg.Sis_codmun_muni;
                    NombreMunicipio     = lobReg.Sis_nommun_muni;
                    CodigoDepartamento  = lobReg.Sis_coddep_dpto; //-Probocar el error al drede para no subir facturas mientras pruebo cosas
                    NombreDepartamento  = lobReg.Sis_desdep_dpto;
                }
            }
            #endregion

        }

#endregion Métodos y Funciones>


    } // Municipio>

    public class DirecciónCompleta
    {


        #region Propiedades

        public Municipio Municipio { get; set; }

        public string Dirección { get; set; }

        #endregion  Propiedades>


        #region Constructores

        public DirecciónCompleta(Municipio municipio, string dirección) 
        {

        }

        #endregion Constructores>


        #region Métodos y Funciones

        /// <summary>
        /// Si no se dispone del municipio o de la dirección no se puede crear la dirección completa y esta será nula.
        /// </summary>
        public static DirecciónCompleta CrearDirecciónCompleta(Municipio municipio, string dirección)
            => municipio == null || dirección == null ? null : new DirecciónCompleta(municipio, dirección);

        #endregion Métodos y Funciones>


    } // DirecciónCompleta>

    #pragma warning restore CS8602
}

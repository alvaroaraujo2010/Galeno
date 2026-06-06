//- MARMOTA-GENCODE: VERSION 2.0 - 26/09/2017 06:22:20 AM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace Cartera.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carconceptfact
    /// </summary>
    public class ModeloCarconceptfact : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Car_codcon_cacf: Codigo concepto
        private String _car_codcon_cacf;
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Codigo concepto</para>
        /// <para>NOMBRE: car_codcon_cacf (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico del concepto generado por el sistema
        /// </para>
        /// </summary>
        public String Car_codcon_cacf
        {
            get { return _car_codcon_cacf; }
            set
            {
                if (_car_codcon_cacf == value) return;
                _car_codcon_cacf = value;
                OnPropertyChanged("Car_codcon_cacf");
            }
        }
        #endregion
        #region Car_descon_cacf: Descripcion concepto
        private String _car_descon_cacf;
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Descripcion concepto</para>
        /// <para>NOMBRE: car_descon_cacf (char:170)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del concepto de venta facturacion
        /// </para>
        /// </summary>
        public String Car_descon_cacf
        {
            get { return _car_descon_cacf; }
            set
            {
                if (_car_descon_cacf == value) return;
                _car_descon_cacf = value;
                OnPropertyChanged("Car_descon_cacf");
            }
        }
        #endregion
        #region Car_estreg_cacf: Estado registro
        private String _car_estreg_cacf;
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: car_estreg_cacf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Estado registro: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Car_estreg_cacf
        {
            get { return _car_estreg_cacf; }
            set
            {
                if (_car_estreg_cacf == value) return;
                _car_estreg_cacf = value;
                OnPropertyChanged("Car_estreg_cacf");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloCarconceptfact tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CAR-DETALL-FAC-VENTA", "CAR", "Conceptos detalles facturas venta");
            try
            {
                if (!flgBuscarCarconceptfact(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFcarconceptfact
                        {
                            #region cargar Registro
                            car_codcon_cacf = tobjModelo.Car_codcon_cacf,
                            car_descon_cacf = tobjModelo.Car_descon_cacf,
                            car_estreg_cacf = tobjModelo.Car_estreg_cacf,
                            #endregion
                        };
                        lobjRegistro.car_codcon_cacf = lcrCodigoGen;
                        _context.AddToCarconceptfact(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CAR-DETALL-FAC-VENTA': Conceptos detalles facturas venta en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloCarconceptfact tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tobjModelo.Car_codcon_cacf);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.car_codcon_cacf = tobjModelo.Car_codcon_cacf;
                        lobjRegistro.car_descon_cacf = tobjModelo.Car_descon_cacf;
                        lobjRegistro.car_estreg_cacf = tobjModelo.Car_estreg_cacf;
                        #endregion
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tcrCodigo);
                    if (lobjRegistro != null)
                    {
                        _context.DeleteObject(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvEliminar");
            }
        }
        #endregion
        #region Buscar CARCONCEPTFACT: Logica
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TITULO: Conceptos para detalles facturas venta Dian</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista conceptos para detalles facturas de venta Dian
        /// </para>
        /// </summary>
        public static bool flgBuscarCarconceptfact(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCarconceptfact> flsListaCarconceptfact(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from carconceptfact in _context.Carconceptfact
                                      select new ModeloCarconceptfact
                                      {
                                          #region Datos
                                          Car_codcon_cacf = carconceptfact.car_codcon_cacf,
                                          Car_descon_cacf = carconceptfact.car_descon_cacf,
                                          Car_estreg_cacf = carconceptfact.car_estreg_cacf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from carconceptfact in _context.Carconceptfact
                                      where carconceptfact.car_codcon_cacf.Contains(tcrBuscar) || carconceptfact.car_descon_cacf.Contains(tcrBuscar)
                                      select new ModeloCarconceptfact
                                      {
                                          #region Datos
                                          Car_codcon_cacf = carconceptfact.car_codcon_cacf,
                                          Car_descon_cacf = carconceptfact.car_descon_cacf,
                                          Car_estreg_cacf = carconceptfact.car_estreg_cacf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
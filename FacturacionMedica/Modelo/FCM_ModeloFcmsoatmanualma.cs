//- MARMOTA-GENCODE: VERSION 2.0 - 31/01/2018 04:56:06 PM
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

namespace FacturacionMedica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmsoatmanualma
    /// </summary>
    public class ModeloFcmsoatmanualma : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_codser_soat: Codigo SOAT
        private String _fcm_codser_soat;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Codigo SOAT</para>
        /// <para>NOMBRE: fcm_codser_soat (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo SOAT del servicio para gestion de actualizacion de precios
        /// </para>
        /// </summary>
        public String Fcm_codser_soat
        {
            get { return _fcm_codser_soat; }
            set
            {
                if (_fcm_codser_soat == value) return;
                _fcm_codser_soat = value;
                OnPropertyChanged("Fcm_codser_soat");
            }
        }
        #endregion
        #region Fcm_desman_soat: Descripcion servicio
        private String _fcm_desman_soat;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Descripcion servicio</para>
        /// <para>NOMBRE: fcm_desman_soat (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del servicio
        /// </para>
        /// </summary>
        public String Fcm_desman_soat
        {
            get { return _fcm_desman_soat; }
            set
            {
                if (_fcm_desman_soat == value) return;
                _fcm_desman_soat = value;
                OnPropertyChanged("Fcm_desman_soat");
            }
        }
        #endregion
        #region Fcm_punuvr_sips: Puntaje o UVR
        private float _fcm_punuvr_sips;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_sips (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float Fcm_punuvr_sips
        {
            get { return _fcm_punuvr_sips; }
            set
            {
                if (_fcm_punuvr_sips == value) return;
                _fcm_punuvr_sips = value;
                OnPropertyChanged("Fcm_punuvr_sips");
            }
        }
        #endregion
        #region Fcm_valser_sips: Valor de servicio
        private float _fcm_valser_sips;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_sips (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
        /// </para>
        /// </summary>
        public float Fcm_valser_sips
        {
            get { return _fcm_valser_sips; }
            set
            {
                if (_fcm_valser_sips == value) return;
                _fcm_valser_sips = value;
                OnPropertyChanged("Fcm_valser_sips");
            }
        }
        #endregion
        #region Fcm_deskey_soat: Campo llave
        private String _fcm_deskey_soat;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Campo llave</para>
        /// <para>NOMBRE: fcm_deskey_soat (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Campo llave de busqueda sin tildes y solo 250 catacteres
        /// </para>
        /// </summary>
        public String Fcm_deskey_soat
        {
            get { return _fcm_deskey_soat; }
            set
            {
                if (_fcm_deskey_soat == value) return;
                _fcm_deskey_soat = value;
                OnPropertyChanged("Fcm_deskey_soat");
            }
        }
        #endregion
        #region Fcm_valkey_soat: Indice llave
        private int _fcm_valkey_soat;
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Indice llave</para>
        /// <para>NOMBRE: fcm_valkey_soat (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Total caracteres que contiene el campo descripcion servicio
        /// </para>
        /// </summary>
        public int Fcm_valkey_soat
        {
            get { return _fcm_valkey_soat; }
            set
            {
                if (_fcm_valkey_soat == value) return;
                _fcm_valkey_soat = value;
                OnPropertyChanged("Fcm_valkey_soat");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFcmsoatmanualma tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmsoatmanualma
                    {
                        #region cargar Registro
                        fcm_codser_soat = tobjModelo.Fcm_codser_soat,
                        fcm_desman_soat = tobjModelo.Fcm_desman_soat,
                        fcm_punuvr_sips = tobjModelo.Fcm_punuvr_sips,
                        fcm_valser_sips = tobjModelo.Fcm_valser_sips,
                        fcm_deskey_soat = tobjModelo.Fcm_deskey_soat,
                        fcm_valkey_soat = tobjModelo.Fcm_valkey_soat,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.fcm_codser_soat;
                    _context.AddToFcmsoatmanualma(lobjRegistro);
                    _context.SaveChanges();
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
        public static void fcvActualizar(ModeloFcmsoatmanualma tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tobjModelo.Fcm_codser_soat);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_codser_soat = tobjModelo.Fcm_codser_soat;
                        lobjRegistro.fcm_desman_soat = tobjModelo.Fcm_desman_soat;
                        lobjRegistro.fcm_punuvr_sips = (float)tobjModelo.Fcm_punuvr_sips;
                        lobjRegistro.fcm_valser_sips = (float)tobjModelo.Fcm_valser_sips;
                        lobjRegistro.fcm_deskey_soat = tobjModelo.Fcm_deskey_soat;
                        lobjRegistro.fcm_valkey_soat = (int)tobjModelo.Fcm_valkey_soat;
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
                    var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tcrCodigo);
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
        #region Buscar FCMSOATMANUALMA: Logica
        /// <summary>
        /// <para>TABLA: fcmsoatmanualma</para>
        /// <para>TITULO: Maestro listado  tarifario soat</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios con puntajes y valores según tarifario SOAT,
        /// para consulta y referencia actualizable cada año
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmsoatmanualma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsoatmanualma.FirstOrDefault(p => p.fcm_codser_soat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFcmsoatmanualma> flsListaFcmsoatmanualma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmsoatmanualma in _context.Fcmsoatmanualma
                                      select new ModeloFcmsoatmanualma
                                      {
                                          #region Datos
                                          Fcm_codser_soat = fcmsoatmanualma.fcm_codser_soat,
                                          Fcm_desman_soat = fcmsoatmanualma.fcm_desman_soat,
                                          Fcm_punuvr_sips = (float)fcmsoatmanualma.fcm_punuvr_sips,
                                          Fcm_valser_sips = (float)fcmsoatmanualma.fcm_valser_sips,
                                          Fcm_deskey_soat = fcmsoatmanualma.fcm_deskey_soat,
                                          Fcm_valkey_soat = (int)fcmsoatmanualma.fcm_valkey_soat,
                                          #endregion
                                      };
                    return lobConsulta.Take(500).ToList();
                }
                else
                {
                    var lobConsulta = from fcmsoatmanualma in _context.Fcmsoatmanualma
                                      where fcmsoatmanualma.fcm_codser_soat.Contains(tcrBuscar) ||
                                      fcmsoatmanualma.fcm_deskey_soat.Contains(tcrBuscar)
                                      orderby fcmsoatmanualma.fcm_valkey_soat
                                      select new ModeloFcmsoatmanualma
                                      {
                                          #region Datos
                                          Fcm_codser_soat = fcmsoatmanualma.fcm_codser_soat,
                                          Fcm_desman_soat = fcmsoatmanualma.fcm_desman_soat,
                                          Fcm_punuvr_sips = (float)fcmsoatmanualma.fcm_punuvr_sips,
                                          Fcm_valser_sips = (float)fcmsoatmanualma.fcm_valser_sips,
                                          Fcm_deskey_soat = fcmsoatmanualma.fcm_deskey_soat,
                                          Fcm_valkey_soat = (int)fcmsoatmanualma.fcm_valkey_soat,
                                          #endregion
                                      };
                    return lobConsulta.Take(500).ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
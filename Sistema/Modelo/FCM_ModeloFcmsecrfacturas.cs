//- MARMOTA-GENCODE: VERSION 2.0 - 24/08/2017 04:13:05 PM
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

namespace Sistema.Modelo
{
    #region ModeloResolDianFacturas
    /// <summary>
    /// fcmsecrfacturas: Maestro Resoluciones Secuenciales Dian para Facturacion
    /// </summary>
    public class ModeloResolDianFacturas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secres_srfa: Codgo unico resolución
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codgo unico resolución</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la resolución Dian en el sistema (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secres_srfa
        {
            get { return _fcm_secres_srfa; }
            set
            {
                if (_fcm_secres_srfa == value) return;
                _fcm_secres_srfa = value;
                OnPropertyChanged("Fcm_secres_srfa");
            }
        }
        #endregion
        #region Fcm_numres_srfa: Resolucion DIAN
        private String _fcm_numres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la resolucion Dian
        /// </para>
        /// </summary>
        public String Fcm_numres_srfa
        {
            get { return _fcm_numres_srfa; }
            set
            {
                if (_fcm_numres_srfa == value) return;
                _fcm_numres_srfa = value;
                OnPropertyChanged("Fcm_numres_srfa");
            }
        }
        #endregion
        #region Fcm_desres_srfa: Descripción
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota  de la resolucion Dian
        /// </para>
        /// </summary>
        public String Fcm_desres_srfa
        {
            get { return _fcm_desres_srfa; }
            set
            {
                if (_fcm_desres_srfa == value) return;
                _fcm_desres_srfa = value;
                OnPropertyChanged("Fcm_desres_srfa");
            }
        }
        #endregion
        #region Fcm_notenc_srfa: Nota de encabezado
        private String _fcm_notenc_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_notenc_srfa
        {
            get { return _fcm_notenc_srfa; }
            set
            {
                if (_fcm_notenc_srfa == value) return;
                _fcm_notenc_srfa = value;
                OnPropertyChanged("Fcm_notenc_srfa");
            }
        }
        #endregion
        #region Fcm_noppag_srfa: Nota pie de pagina
        private String _fcm_noppag_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_noppag_srfa
        {
            get { return _fcm_noppag_srfa; }
            set
            {
                if (_fcm_noppag_srfa == value) return;
                _fcm_noppag_srfa = value;
                OnPropertyChanged("Fcm_noppag_srfa");
            }
        }
        #endregion
        #region Fcm_fecini_srfa: Fecha Inicia vigencia
        private DateTime _fcm_fecini_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha Inicia vigencia</para>
        /// <para>NOMBRE: fcm_fecini_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha en que inicia vigencia para ser utilzada por el sistema
        /// </para>
        /// </summary>
        public DateTime Fcm_fecini_srfa
        {
            get { return _fcm_fecini_srfa; }
            set
            {
                if (_fcm_fecini_srfa == value) return;
                _fcm_fecini_srfa = value;
                OnPropertyChanged("Fcm_fecini_srfa");
            }
        }
        #endregion
        #region Fcm_fecfin_srfa: Fecha final vigencia
        private DateTime _fcm_fecfin_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha final vigencia</para>
        /// <para>NOMBRE: fcm_fecfin_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha en que finaliza vigencia para ser utilizada por el sistema
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfin_srfa
        {
            get { return _fcm_fecfin_srfa; }
            set
            {
                if (_fcm_fecfin_srfa == value) return;
                _fcm_fecfin_srfa = value;
                OnPropertyChanged("Fcm_fecfin_srfa");
            }
        }
        #endregion
        #region Fcm_facini_srfa: Numero secuencial inicio
        private int _fcm_facini_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial inicio</para>
        /// <para>NOMBRE: fcm_facini_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde inicia el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facini_srfa
        {
            get { return _fcm_facini_srfa; }
            set
            {
                if (_fcm_facini_srfa == value) return;
                _fcm_facini_srfa = value;
                OnPropertyChanged("Fcm_facini_srfa");
            }
        }
        #endregion
        #region Fcm_facfin_srfa: Numero secuencial fin
        private int _fcm_facfin_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial fin</para>
        /// <para>NOMBRE: fcm_facfin_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde finaliza el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facfin_srfa
        {
            get { return _fcm_facfin_srfa; }
            set
            {
                if (_fcm_facfin_srfa == value) return;
                _fcm_facfin_srfa = value;
                OnPropertyChanged("Fcm_facfin_srfa");
            }
        }
        #endregion
        #region Fcm_ultgen_srfa: Ultimo secuencial generado
        private int _fcm_ultgen_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Ultimo secuencial generado</para>
        /// <para>NOMBRE: fcm_ultgen_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ultimo Numero de factura generado (se utiliza como base para
        /// generar el siguiente)
        /// </para>
        /// </summary>
        public int Fcm_ultgen_srfa
        {
            get { return _fcm_ultgen_srfa; }
            set
            {
                if (_fcm_ultgen_srfa == value) return;
                _fcm_ultgen_srfa = value;
                OnPropertyChanged("Fcm_ultgen_srfa");
            }
        }
        #endregion
        #region Fcm_prefij_srfa: Prefijo del secuencial generado
        private String _fcm_prefij_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero de resolucion</para>
        /// <para>NOMBRE: fcm_prefij_srfa (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION: Prefijo para el numero  secuencial generado</para>
        /// </summary>
        public String Fcm_prefij_srfa
        {
            get { return _fcm_prefij_srfa; }
            set
            {
                if (_fcm_prefij_srfa == value) return;
                _fcm_prefij_srfa = value;
                OnPropertyChanged("Fcm_prefij_srfa");
            }
        }
        #endregion
        #region Fcm_maxsec_srfa: Tamaño Secuencial
        private int _fcm_maxsec_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: fcm_maxsec_srfa (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Inidica el tamaño maximo en caracteres para el secuencial generado
        /// como numero de factura
        /// </para>
        /// </summary>
        public int Fcm_maxsec_srfa
        {
            get { return _fcm_maxsec_srfa; }
            set
            {
                if (_fcm_maxsec_srfa == value) return;
                _fcm_maxsec_srfa = value;
                OnPropertyChanged("Fcm_maxsec_srfa");
            }
        }
        #endregion
        #region Fcm_alrsec_srfa: Limite secuencial alarma
        private int _fcm_alrsec_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Limite secuencial alarma</para>
        /// <para>NOMBRE: fcm_alrsec_srfa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos numeros secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int Fcm_alrsec_srfa
        {
            get { return _fcm_alrsec_srfa; }
            set
            {
                if (_fcm_alrsec_srfa == value) return;
                _fcm_alrsec_srfa = value;
                OnPropertyChanged("Fcm_alrsec_srfa");
            }
        }
        #endregion
        #region Fcm_relcer_srfa: Rellenar con Ceros
        private String _fcm_relcer_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: fcm_relcer_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Inidica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public String Fcm_relcer_srfa
        {
            get { return _fcm_relcer_srfa; }
            set
            {
                if (_fcm_relcer_srfa == value) return;
                _fcm_relcer_srfa = value;
                OnPropertyChanged("Fcm_relcer_srfa");
            }
        }
        #endregion
        #region Fcm_estreg_srfa: Estado registro
        private String _fcm_estreg_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: fcm_estreg_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estreg_srfa
        {
            get { return _fcm_estreg_srfa; }
            set
            {
                if (_fcm_estreg_srfa == value) return;
                _fcm_estreg_srfa = value;
                OnPropertyChanged("Fcm_estreg_srfa");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloResolDianFacturas tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-RESOLUCIONES-DIAN", "FCM", " Resoluciones Dian");
            try
            {
                if (!flgBuscarFcmsecrfacturas(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmsecrfacturas
                        {
                            #region cargar Registro
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            fcm_numres_srfa = tobjModelo.Fcm_numres_srfa,
                            fcm_desres_srfa = tobjModelo.Fcm_desres_srfa,
                            fcm_notenc_srfa = tobjModelo.Fcm_notenc_srfa,
                            fcm_noppag_srfa = tobjModelo.Fcm_noppag_srfa,
                            fcm_fecini_srfa = tobjModelo.Fcm_fecini_srfa,
                            fcm_fecfin_srfa = tobjModelo.Fcm_fecfin_srfa,
                            fcm_facini_srfa = tobjModelo.Fcm_facini_srfa,
                            fcm_facfin_srfa = tobjModelo.Fcm_facfin_srfa,
                            fcm_ultgen_srfa = tobjModelo.Fcm_ultgen_srfa,
                            fcm_prefij_srfa = tobjModelo.Fcm_prefij_srfa,
                            fcm_maxsec_srfa = tobjModelo.Fcm_maxsec_srfa,
                            fcm_alrsec_srfa = tobjModelo.Fcm_alrsec_srfa,
                            fcm_relcer_srfa = tobjModelo.Fcm_relcer_srfa,
                            fcm_estreg_srfa = tobjModelo.Fcm_estreg_srfa,
                            #endregion
                        };
                        lobjRegistro.fcm_secres_srfa = lcrCodigoGen;
                        _context.AddToFcmsecrfacturas(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-RESOLUCIONES-DIAN':  Resoluciones Dian en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloResolDianFacturas tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tobjModelo.Fcm_secres_srfa);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.fcm_numres_srfa = tobjModelo.Fcm_numres_srfa;
                        lobjRegistro.fcm_desres_srfa = tobjModelo.Fcm_desres_srfa;
                        lobjRegistro.fcm_notenc_srfa = tobjModelo.Fcm_notenc_srfa;
                        lobjRegistro.fcm_noppag_srfa = tobjModelo.Fcm_noppag_srfa;
                        lobjRegistro.fcm_fecini_srfa = (DateTime)tobjModelo.Fcm_fecini_srfa;
                        lobjRegistro.fcm_fecfin_srfa = (DateTime)tobjModelo.Fcm_fecfin_srfa;
                        lobjRegistro.fcm_facini_srfa = (int)tobjModelo.Fcm_facini_srfa;
                        lobjRegistro.fcm_facfin_srfa = (int)tobjModelo.Fcm_facfin_srfa;
                        lobjRegistro.fcm_ultgen_srfa = (int)tobjModelo.Fcm_ultgen_srfa;
                        lobjRegistro.fcm_prefij_srfa = tobjModelo.Fcm_prefij_srfa;
                        lobjRegistro.fcm_maxsec_srfa = (int)tobjModelo.Fcm_maxsec_srfa;
                        lobjRegistro.fcm_alrsec_srfa = (int)tobjModelo.Fcm_alrsec_srfa;
                        lobjRegistro.fcm_relcer_srfa = tobjModelo.Fcm_relcer_srfa;
                        lobjRegistro.fcm_estreg_srfa = tobjModelo.Fcm_estreg_srfa;
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
                    var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
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
        #region Buscar FCMSECRFACTURAS: Logica
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TITULO: Secuenciales resolución numero de facturas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para gestion de secuenciales de facturación asignados
        /// por la Dian con fecha inicio vigencia y estado en el sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmsecrfacturas(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloResolDianFacturas> flsListaFcmsecrfacturas(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmsecrfacturas in _context.Fcmsecrfacturas
                                      select new ModeloResolDianFacturas
                                      {
                                          #region Datos
                                          Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                          Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                          Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                          Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                          Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                          Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                          Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                          Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                          Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                          Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                          Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                          Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                          Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmsecrfacturas in _context.Fcmsecrfacturas
                                      where fcmsecrfacturas.fcm_secres_srfa.Contains(tcrBuscar) || fcmsecrfacturas.fcm_desres_srfa.Contains(tcrBuscar)
                                      select new ModeloResolDianFacturas
                                      {
                                          #region Datos
                                          Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                          Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                          Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                          Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                          Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                          Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                          Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                          Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                          Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                          Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                          Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                          Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                          Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Un solo registro
        /// <summary>
        /// Generar y devuelve un registro del tipo Resoluciones Dian
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NR"=Numero de Resolucion</param>
        /// <param name="tcrIdRegistro">Codigo del Registro o numero de Resolucion</param>
        /// <returns></returns>
        public static ModeloResolDianFacturas FobRegistroResolucionDian(string tcrTipo, string tcrBuscar)
        {
            ModeloResolDianFacturas lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "ID")
                {
                    lobConsulta = (from fcmsecrfacturas in _context.Fcmsecrfacturas
                                   where fcmsecrfacturas.fcm_secres_srfa == tcrBuscar
                                   select new ModeloResolDianFacturas
                                   {
                                       #region Datos
                                       Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                       Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                       Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                       Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                       Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                       Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                       Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                       Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                       Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                       Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                       Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                       Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                       Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                       Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                       Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                       #endregion
                                   }).FirstOrDefault();
                }
                else
                {
                    lobConsulta = (from fcmsecrfacturas in _context.Fcmsecrfacturas
                                   where fcmsecrfacturas.fcm_numres_srfa == tcrBuscar
                                   select new ModeloResolDianFacturas
                                   {
                                       #region Datos
                                       Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                       Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                       Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                       Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                       Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                       Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                       Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                       Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                       Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                       Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                       Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                       Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                       Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                       Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                       Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                       #endregion
                                   }).FirstOrDefault();
                }
            }
            return lobConsulta;
        }
        #endregion

        #endregion
    }
    #endregion ModeloResolDianFacturas

    #region Modelo ModeloFcmsecrfacturas
    /*
    /// <summary>
    /// <para>FCMSECRFACTURAS: Maestro para gestion de secuenciales de facturación asignados</para>  
    /// <para>por la Dian con fecha inicio vigencia y estado en el sistema</para>
    /// </summary>
    public class ModeloFcmsecrfacturas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secres_srfa: Codgo unico resolución
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codgo unico resolución</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la resolución Dian en el sistema (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secres_srfa
        {
            get { return _fcm_secres_srfa; }
            set
            {
                if (_fcm_secres_srfa == value) return;
                _fcm_secres_srfa = value;
                OnPropertyChanged("Fcm_secres_srfa");
            }
        }
        #endregion
        #region Fcm_numres_srfa: Resolucion DIAN
        private String _fcm_numres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// InvoiceAuthorization: Número autorización Dian: Número del
        /// código de la resolución otorgada para la numeración
        /// </para>
        /// </summary>
        public String Fcm_numres_srfa
        {
            get { return _fcm_numres_srfa; }
            set
            {
                if (_fcm_numres_srfa == value) return;
                _fcm_numres_srfa = value;
                OnPropertyChanged("Fcm_numres_srfa");
            }
        }
        #endregion
        #region Fcm_desres_srfa: Descripción
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota  de la resolucion Dian
        /// </para>
        /// </summary>
        public String Fcm_desres_srfa
        {
            get { return _fcm_desres_srfa; }
            set
            {
                if (_fcm_desres_srfa == value) return;
                _fcm_desres_srfa = value;
                OnPropertyChanged("Fcm_desres_srfa");
            }
        }
        #endregion
        #region Fcm_notenc_srfa: Nota de encabezado
        private String _fcm_notenc_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_notenc_srfa
        {
            get { return _fcm_notenc_srfa; }
            set
            {
                if (_fcm_notenc_srfa == value) return;
                _fcm_notenc_srfa = value;
                OnPropertyChanged("Fcm_notenc_srfa");
            }
        }
        #endregion
        #region Fcm_noppag_srfa: Nota pie de pagina
        private String _fcm_noppag_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_noppag_srfa
        {
            get { return _fcm_noppag_srfa; }
            set
            {
                if (_fcm_noppag_srfa == value) return;
                _fcm_noppag_srfa = value;
                OnPropertyChanged("Fcm_noppag_srfa");
            }
        }
        #endregion
        #region Fcm_fecini_srfa: Fecha Inicia vigencia
        private DateTime _fcm_fecini_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha Inicia vigencia</para>
        /// <para>NOMBRE: fcm_fecini_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// StartDate:Fecha de inicio de la autorización de la numeración
        /// </para>
        /// </summary>
        public DateTime Fcm_fecini_srfa
        {
            get { return _fcm_fecini_srfa; }
            set
            {
                if (_fcm_fecini_srfa == value) return;
                _fcm_fecini_srfa = value;
                OnPropertyChanged("Fcm_fecini_srfa");
            }
        }
        #endregion
        #region Fcm_fecfin_srfa: Fecha final vigencia
        private DateTime _fcm_fecfin_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha final vigencia</para>
        /// <para>NOMBRE: fcm_fecfin_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// EndDate: Fecha finalizacion de la autorización de la numeración
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfin_srfa
        {
            get { return _fcm_fecfin_srfa; }
            set
            {
                if (_fcm_fecfin_srfa == value) return;
                _fcm_fecfin_srfa = value;
                OnPropertyChanged("Fcm_fecfin_srfa");
            }
        }
        #endregion
        #region Fcm_prefij_srfa: Prefijo de secuencial
        private String _fcm_prefij_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Prefijo de secuencial</para>
        /// <para>NOMBRE: fcm_prefij_srfa (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Prefix: Prefijo de la autorización de numeración de facturación
        /// dado por el SIE de Numeración
        /// </para>
        /// </summary>
        public String Fcm_prefij_srfa
        {
            get { return _fcm_prefij_srfa; }
            set
            {
                if (_fcm_prefij_srfa == value) return;
                _fcm_prefij_srfa = value;
                OnPropertyChanged("Fcm_prefij_srfa");
            }
        }
        #endregion
        #region Fcm_facini_srfa: Numero secuencial inicio
        private int _fcm_facini_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial inicio</para>
        /// <para>NOMBRE: fcm_facini_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// From: Numero secuencial de factura donde inicia el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facini_srfa
        {
            get { return _fcm_facini_srfa; }
            set
            {
                if (_fcm_facini_srfa == value) return;
                _fcm_facini_srfa = value;
                OnPropertyChanged("Fcm_facini_srfa");
            }
        }
        #endregion
        #region Fcm_facfin_srfa: Numero secuencial fin
        private int _fcm_facfin_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial fin</para>
        /// <para>NOMBRE: fcm_facfin_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// To: Numero secuencial de factura donde finaliza el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facfin_srfa
        {
            get { return _fcm_facfin_srfa; }
            set
            {
                if (_fcm_facfin_srfa == value) return;
                _fcm_facfin_srfa = value;
                OnPropertyChanged("Fcm_facfin_srfa");
            }
        }
        #endregion
        #region Fcm_ultgen_srfa: Ultimo secuencial generado
        private int _fcm_ultgen_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Ultimo secuencial generado</para>
        /// <para>NOMBRE: fcm_ultgen_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Ultimo Numero de factura generado (se utiliza como base para
        /// generar el siguiente)
        /// </para>
        /// </summary>
        public int Fcm_ultgen_srfa
        {
            get { return _fcm_ultgen_srfa; }
            set
            {
                if (_fcm_ultgen_srfa == value) return;
                _fcm_ultgen_srfa = value;
                OnPropertyChanged("Fcm_ultgen_srfa");
            }
        }
        #endregion
        #region Fcm_maxsec_srfa: Tamaño Secuencial
        private int _fcm_maxsec_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: fcm_maxsec_srfa (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Inidica el tamaño maximo en caracteres para el secuencial generado
        /// como numero de factura
        /// </para>
        /// </summary>
        public int Fcm_maxsec_srfa
        {
            get { return _fcm_maxsec_srfa; }
            set
            {
                if (_fcm_maxsec_srfa == value) return;
                _fcm_maxsec_srfa = value;
                OnPropertyChanged("Fcm_maxsec_srfa");
            }
        }
        #endregion
        #region Fcm_alrsec_srfa: Limite secuencial alarma
        private int _fcm_alrsec_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Limite secuencial alarma</para>
        /// <para>NOMBRE: fcm_alrsec_srfa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos numeros secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int Fcm_alrsec_srfa
        {
            get { return _fcm_alrsec_srfa; }
            set
            {
                if (_fcm_alrsec_srfa == value) return;
                _fcm_alrsec_srfa = value;
                OnPropertyChanged("Fcm_alrsec_srfa");
            }
        }
        #endregion
        #region Fcm_relcer_srfa: Rellenar con Ceros
        private String _fcm_relcer_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: fcm_relcer_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Inidica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public String Fcm_relcer_srfa
        {
            get { return _fcm_relcer_srfa; }
            set
            {
                if (_fcm_relcer_srfa == value) return;
                _fcm_relcer_srfa = value;
                OnPropertyChanged("Fcm_relcer_srfa");
            }
        }
        #endregion
        #region Fcm_estreg_srfa: Estado registro
        private String _fcm_estreg_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: fcm_estreg_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estreg_srfa
        {
            get { return _fcm_estreg_srfa; }
            set
            {
                if (_fcm_estreg_srfa == value) return;
                _fcm_estreg_srfa = value;
                OnPropertyChanged("Fcm_estreg_srfa");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFcmsecrfacturas tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMSECRFACTURAS", "FCM", "Secuenciales resolución numero de facturas");
            try
            {
                if (!flgBuscarFcmsecrfacturas(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmsecrfacturas
                        {
                            #region cargar Registro
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            fcm_numres_srfa = tobjModelo.Fcm_numres_srfa,
                            fcm_desres_srfa = tobjModelo.Fcm_desres_srfa,
                            fcm_notenc_srfa = tobjModelo.Fcm_notenc_srfa,
                            fcm_noppag_srfa = tobjModelo.Fcm_noppag_srfa,
                            fcm_fecini_srfa = tobjModelo.Fcm_fecini_srfa,
                            fcm_fecfin_srfa = tobjModelo.Fcm_fecfin_srfa,
                            fcm_prefij_srfa = tobjModelo.Fcm_prefij_srfa,
                            fcm_facini_srfa = tobjModelo.Fcm_facini_srfa,
                            fcm_facfin_srfa = tobjModelo.Fcm_facfin_srfa,
                            fcm_ultgen_srfa = tobjModelo.Fcm_ultgen_srfa,
                            fcm_maxsec_srfa = tobjModelo.Fcm_maxsec_srfa,
                            fcm_alrsec_srfa = tobjModelo.Fcm_alrsec_srfa,
                            fcm_relcer_srfa = tobjModelo.Fcm_relcer_srfa,
                            fcm_estreg_srfa = tobjModelo.Fcm_estreg_srfa,
                            #endregion
                        };
                        lobjRegistro.fcm_secres_srfa = lcrCodigoGen;
                        _context.AddToFcmsecrfacturas(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMSECRFACTURAS': Secuenciales resolución numero de facturas en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloFcmsecrfacturas tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tobjModelo.Fcm_secres_srfa);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.fcm_numres_srfa = tobjModelo.Fcm_numres_srfa;
                        lobjRegistro.fcm_desres_srfa = tobjModelo.Fcm_desres_srfa;
                        lobjRegistro.fcm_notenc_srfa = tobjModelo.Fcm_notenc_srfa;
                        lobjRegistro.fcm_noppag_srfa = tobjModelo.Fcm_noppag_srfa;
                        lobjRegistro.fcm_fecini_srfa = (DateTime)tobjModelo.Fcm_fecini_srfa;
                        lobjRegistro.fcm_fecfin_srfa = (DateTime)tobjModelo.Fcm_fecfin_srfa;
                        lobjRegistro.fcm_prefij_srfa = tobjModelo.Fcm_prefij_srfa;
                        lobjRegistro.fcm_facini_srfa = (int)tobjModelo.Fcm_facini_srfa;
                        lobjRegistro.fcm_facfin_srfa = (int)tobjModelo.Fcm_facfin_srfa;
                        lobjRegistro.fcm_ultgen_srfa = (int)tobjModelo.Fcm_ultgen_srfa;
                        lobjRegistro.fcm_maxsec_srfa = (int)tobjModelo.Fcm_maxsec_srfa;
                        lobjRegistro.fcm_alrsec_srfa = (int)tobjModelo.Fcm_alrsec_srfa;
                        lobjRegistro.fcm_relcer_srfa = tobjModelo.Fcm_relcer_srfa;
                        lobjRegistro.fcm_estreg_srfa = tobjModelo.Fcm_estreg_srfa;
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
                    var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
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
        #region Buscar FCMSECRFACTURAS: Logica
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TITULO: Secuenciales resolución numero de facturas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para gestion de secuenciales de facturación asignados
        /// por la Dian con fecha inicio vigencia y estado en el sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmsecrfacturas(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmsecrfacturas.FirstOrDefault(p => p.fcm_secres_srfa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFcmsecrfacturas> flsListaFcmsecrfacturas(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmsecrfacturas in _context.Fcmsecrfacturas
                                      select new ModeloFcmsecrfacturas
                                      {
                                          #region Datos
                                          Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                          Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                          Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                          Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                          Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                          Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                          Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                          Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                          Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                          Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                          Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                          Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                          Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmsecrfacturas in _context.Fcmsecrfacturas
                                      where fcmsecrfacturas.fcm_secres_srfa == tcrBuscar
                                      select new ModeloFcmsecrfacturas
                                      {
                                          #region Datos
                                          Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                          Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                          Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                          Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                          Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                          Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                          Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                          Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                          Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                          Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                          Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                          Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                          Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion

        #region Listar Registros
        public static ModeloFcmsecrfacturas fobRegistroFcmsecrfacturas(String tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from fcmsecrfacturas in _context.Fcmsecrfacturas
                                  where fcmsecrfacturas.fcm_secres_srfa == tcrCodigo
                                  select new ModeloFcmsecrfacturas
                                      {
                                          #region Datos
                                          Fcm_secres_srfa = fcmsecrfacturas.fcm_secres_srfa,
                                          Fcm_numres_srfa = fcmsecrfacturas.fcm_numres_srfa,
                                          Fcm_desres_srfa = fcmsecrfacturas.fcm_desres_srfa,
                                          Fcm_notenc_srfa = fcmsecrfacturas.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = fcmsecrfacturas.fcm_noppag_srfa,
                                          Fcm_fecini_srfa = (DateTime)fcmsecrfacturas.fcm_fecini_srfa,
                                          Fcm_fecfin_srfa = (DateTime)fcmsecrfacturas.fcm_fecfin_srfa,
                                          Fcm_prefij_srfa = fcmsecrfacturas.fcm_prefij_srfa,
                                          Fcm_facini_srfa = (int)fcmsecrfacturas.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)fcmsecrfacturas.fcm_facfin_srfa,
                                          Fcm_ultgen_srfa = (int)fcmsecrfacturas.fcm_ultgen_srfa,
                                          Fcm_maxsec_srfa = (int)fcmsecrfacturas.fcm_maxsec_srfa,
                                          Fcm_alrsec_srfa = (int)fcmsecrfacturas.fcm_alrsec_srfa,
                                          Fcm_relcer_srfa = fcmsecrfacturas.fcm_relcer_srfa,
                                          Fcm_estreg_srfa = fcmsecrfacturas.fcm_estreg_srfa,
                                          #endregion
                                      }).FirstOrDefault();
                return lobConsulta;
            }
        }
        #endregion

        #endregion
    }
    */
    #endregion Modelo ModeloFcmsecrfacturas
}
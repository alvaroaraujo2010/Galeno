//- MARMOTA-GENCODE: VERSION 2.0 - 21/07/2018 02:10:15 PM
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
using Sistema.Clases;

namespace Estadisticas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: estplangr2193ma
    /// </summary>
    public class ModeloEstParametros2193MA : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Est_nroreg_esgr: Código unico grupo
        private String _est_nroreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Código unico grupo</para>
        /// <para>NOMBRE: est_nroreg_esgr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único grupo del informe
        /// </para>
        /// </summary>
        public String Est_nroreg_esgr
        {
            get { return _est_nroreg_esgr; }
            set
            {
                if (_est_nroreg_esgr == value) return;
                _est_nroreg_esgr = value;
                OnPropertyChanged("Est_nroreg_esgr");
            }
        }
        #endregion
        #region Est_codinf_esin: Código infrome
        private String _est_codinf_esin;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplaninformes</para>
        /// <para>CAMPO: Código infrome</para>
        /// <para>NOMBRE: est_codinf_esin (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del informe o plantilla
        /// </para>
        /// </summary>
        public String Est_codinf_esin
        {
            get { return _est_codinf_esin; }
            set
            {
                if (_est_codinf_esin == value) return;
                _est_codinf_esin = value;
                OnPropertyChanged("Est_codinf_esin");
            }
        }
        #endregion
        #region Est_nomgru_esgr: Nombre del  grupo
        private String _est_nomgru_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Nombre del  grupo</para>
        /// <para>NOMBRE: est_nomgru_esgr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del grupo de registro en el informe
        /// </para>
        /// </summary>
        public String Est_nomgru_esgr
        {
            get { return _est_nomgru_esgr; }
            set
            {
                if (_est_nomgru_esgr == value) return;
                _est_nomgru_esgr = value;
                OnPropertyChanged("Est_nomgru_esgr");
            }
        }
        #endregion
        #region Est_ordgru_esgr: Orden Grupo
        private int _est_ordgru_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Grupo</para>
        /// <para>NOMBRE: est_ordgru_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Orden para organizar grupos  dentro del informe
        /// </para>
        /// </summary>
        public int Est_ordgru_esgr
        {
            get { return _est_ordgru_esgr; }
            set
            {
                if (_est_ordgru_esgr == value) return;
                _est_ordgru_esgr = value;
                OnPropertyChanged("Est_ordgru_esgr");
            }
        }
        #endregion
        #region Est_ordvis_esgr: Orden Vista
        private int _est_ordvis_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: est_ordvis_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion registro dentro del grupo en informe
        /// </para>
        /// </summary>
        public int Est_ordvis_esgr
        {
            get { return _est_ordvis_esgr; }
            set
            {
                if (_est_ordvis_esgr == value) return;
                _est_ordvis_esgr = value;
                OnPropertyChanged("Est_ordvis_esgr");
            }
        }
        #endregion
        #region Est_codcon_esgr: Codigo condicion grupos
        private String _est_codcon_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Codigo condicion grupos</para>
        /// <para>NOMBRE: est_codcon_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo condiciones cada grupo de registros  1= Generar Según
        /// Norma 2=Segun condicion o ecepción grupo 3=otros
        /// </para>
        /// </summary>
        public String Est_codcon_esgr
        {
            get { return _est_codcon_esgr; }
            set
            {
                if (_est_codcon_esgr == value) return;
                _est_codcon_esgr = value;
                OnPropertyChanged("Est_codcon_esgr");
            }
        }
        #endregion
        #region Est_descon_esgr: Descripción condicion
        private String _est_descon_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Descripción condicion</para>
        /// <para>NOMBRE: est_descon_esgr (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Descripcion para cada grupo de registros según se requiera
        /// configurar :  1= Generar Según Norma 2=Ecepción según grupo
        /// 3=Condicion según grupo 4=Ecepción según grupo…
        /// </para>
        /// </summary>
        public String Est_descon_esgr
        {
            get { return _est_descon_esgr; }
            set
            {
                if (_est_descon_esgr == value) return;
                _est_descon_esgr = value;
                OnPropertyChanged("Est_descon_esgr");
            }
        }
        #endregion
        #region Est_secdet_esgr: Secuencial reg detalles
        private int _est_secdet_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: est_secdet_esgr (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Campo para generar el secuencial de registros detalles
        /// </para>
        /// </summary>
        public int Est_secdet_esgr
        {
            get { return _est_secdet_esgr; }
            set
            {
                if (_est_secdet_esgr == value) return;
                _est_secdet_esgr = value;
                OnPropertyChanged("Est_secdet_esgr");
            }
        }
        #endregion
        #region Est_estreg_esgr: Estado del registro
        private String _est_estreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: est_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Est_estreg_esgr
        {
            get { return _est_estreg_esgr; }
            set
            {
                if (_est_estreg_esgr == value) return;
                _est_estreg_esgr = value;
                OnPropertyChanged("Est_estreg_esgr");
            }
        }
        #endregion
        #region Est_nominf_esin: Nombre del informe
        private String _est_nominf_esin;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplaninformes</para>
        /// <para>CAMPO: Nombre del informe</para>
        /// <para>NOMBRE: est_nominf_esin (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del informe o plantilla
        /// </para>
        /// </summary>
        public String Est_nominf_esin
        {
            get { return _est_nominf_esin; }
            set
            {
                if (_est_nominf_esin == value) return;
                _est_nominf_esin = value;
                OnPropertyChanged("Est_nominf_esin");
            }
        }
        #endregion        
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloEstParametros2193MA tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("EST-ESTPLANGR2193MA", "EST", "Grupos para plantillas de informes");
            try
            {
                if (!flgBuscarEstplangr2193ma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFestplangr2193ma
                        {
                            #region cargar Registro
                            est_nroreg_esgr = tobjModelo.Est_nroreg_esgr,
                            est_codinf_esin = tobjModelo.Est_codinf_esin,
                            est_nomgru_esgr = tobjModelo.Est_nomgru_esgr,
                            est_ordgru_esgr = tobjModelo.Est_ordgru_esgr,
                            est_ordvis_esgr = tobjModelo.Est_ordvis_esgr,
                            est_codcon_esgr = tobjModelo.Est_codcon_esgr,
                            est_descon_esgr = tobjModelo.Est_descon_esgr,
                            est_secdet_esgr = tobjModelo.Est_secdet_esgr,
                            est_estreg_esgr = tobjModelo.Est_estreg_esgr,
                            #endregion
                        };
                        lobjRegistro.est_nroreg_esgr = lcrCodigoGen;
                        _context.AddToEstplangr2193ma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'EST-ESTPLANGR2193MA': Grupos para plantillas de informes en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloEstParametros2193MA tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tobjModelo.Est_nroreg_esgr);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.est_nroreg_esgr = tobjModelo.Est_nroreg_esgr;
                        lobjRegistro.est_codinf_esin = tobjModelo.Est_codinf_esin;
                        lobjRegistro.est_nomgru_esgr = tobjModelo.Est_nomgru_esgr;
                        lobjRegistro.est_ordgru_esgr = (int)tobjModelo.Est_ordgru_esgr;
                        lobjRegistro.est_ordvis_esgr = (int)tobjModelo.Est_ordvis_esgr;
                        lobjRegistro.est_codcon_esgr = tobjModelo.Est_codcon_esgr;
                        lobjRegistro.est_descon_esgr = tobjModelo.Est_descon_esgr;
                        lobjRegistro.est_secdet_esgr = (int)tobjModelo.Est_secdet_esgr;
                        lobjRegistro.est_estreg_esgr = tobjModelo.Est_estreg_esgr;
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
                    var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tcrCodigo);
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
        #region Buscar ESTPLANGR2193MA: Logica
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TITULO: Grupos para plantillas de informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// grupos tipo detalles para plantillas de informes de la tabla
        /// ESTPLANINFORMES
        /// </para>
        /// </summary>
        public static bool flgBuscarEstplangr2193ma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloEstParametros2193MA> flsListaEstplangr2193ma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from estplangr2193ma in _context.Estplangr2193ma
                                      join estplaninformes in _context.Estplaninformes on estplangr2193ma.est_codinf_esin equals estplaninformes.est_nroreg_esin into tmestplaninformes
                                      from esin in tmestplaninformes.DefaultIfEmpty()
                                      select new ModeloEstParametros2193MA
                                      {
                                          #region Datos
                                          Est_nroreg_esgr = estplangr2193ma.est_nroreg_esgr,
                                          Est_codinf_esin = estplangr2193ma.est_codinf_esin,
                                          Est_nomgru_esgr = estplangr2193ma.est_nomgru_esgr,
                                          Est_ordgru_esgr = (int)estplangr2193ma.est_ordgru_esgr,
                                          Est_ordvis_esgr = (int)estplangr2193ma.est_ordvis_esgr,
                                          Est_codcon_esgr = estplangr2193ma.est_codcon_esgr,
                                          Est_descon_esgr = estplangr2193ma.est_descon_esgr,
                                          Est_secdet_esgr = (int)estplangr2193ma.est_secdet_esgr,
                                          Est_estreg_esgr = estplangr2193ma.est_estreg_esgr,
                                          Est_nominf_esin = esin.est_nominf_esin,                                         
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from estplangr2193ma in _context.Estplangr2193ma
                                      join estplaninformes in _context.Estplaninformes on estplangr2193ma.est_codinf_esin equals estplaninformes.est_nroreg_esin into tmestplaninformes
                                      from esin in tmestplaninformes.DefaultIfEmpty()
                                      where estplangr2193ma.est_nroreg_esgr.Contains(tcrBuscar) || estplangr2193ma.est_nomgru_esgr.Contains(tcrBuscar)
                                      select new ModeloEstParametros2193MA
                                      {
                                          #region Datos
                                          Est_nroreg_esgr = estplangr2193ma.est_nroreg_esgr,
                                          Est_codinf_esin = estplangr2193ma.est_codinf_esin,
                                          Est_nomgru_esgr = estplangr2193ma.est_nomgru_esgr,
                                          Est_ordgru_esgr = (int)estplangr2193ma.est_ordgru_esgr,
                                          Est_ordvis_esgr = (int)estplangr2193ma.est_ordvis_esgr,
                                          Est_codcon_esgr = estplangr2193ma.est_codcon_esgr,
                                          Est_descon_esgr = estplangr2193ma.est_descon_esgr,
                                          Est_secdet_esgr = (int)estplangr2193ma.est_secdet_esgr,
                                          Est_estreg_esgr = estplangr2193ma.est_estreg_esgr,
                                          Est_nominf_esin = esin.est_nominf_esin,                                         
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        // Temporal Resumen 2193
        #region Listar Registros temporal resumen 2193
        /// <summary>
        /// Listar Registros para el temporal resumen 2193
        /// </summary>
        public static List<ClasseTmpResumen> flsListaTempResumen()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from estplangr2193ma in _context.Estplangr2193ma
                                  where estplangr2193ma.est_estreg_esgr == "1"
                                  orderby estplangr2193ma.est_ordgru_esgr, estplangr2193ma.est_ordvis_esgr
                                  select new ClasseTmpResumen
                                  {
                                      #region Datos
                                      // Datos del grupo
                                      GrupoIdRegistro ="NA",
                                      GrupoTitulo     ="NA",
                                      GrupoOrdenVista = (int)estplangr2193ma.est_ordgru_esgr,
                                      // Datos del registro
                                      LlaveRegistro  = estplangr2193ma.est_nroreg_esgr,
                                      RegistroCodigo = estplangr2193ma.est_nroreg_esgr,
                                      RegistroTitulo = estplangr2193ma.est_nomgru_esgr,
                                      Parametro1     = estplangr2193ma.est_codcon_esgr,
                                      #endregion
                                  }).ToList();

                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        if (lobReg.GrupoOrdenVista == 1)
                        {
                            lobReg.GrupoIdRegistro = "G01";
                            lobReg.GrupoTitulo = "Producción de servicios";
                        }
                        if (lobReg.GrupoOrdenVista == 2)
                        {
                            lobReg.GrupoIdRegistro = "G02";
                            lobReg.GrupoTitulo = "Egresos Hospitalarios";
                        }
                        if (lobReg.GrupoOrdenVista == 3)
                        {
                            lobReg.GrupoIdRegistro = "G03";
                            lobReg.GrupoTitulo = "Dias de estancia";
                        }
                        if (lobReg.GrupoOrdenVista == 4)
                        {
                            lobReg.GrupoIdRegistro = "G04";
                            lobReg.GrupoTitulo = "Gestion camas en admitidos";
                        }
                        if (lobReg.GrupoOrdenVista == 5)
                        {
                            lobReg.GrupoIdRegistro = "G05";
                            lobReg.GrupoTitulo = "Cirugias";
                        }
                        if (lobReg.GrupoOrdenVista == 6)
                        {
                            lobReg.GrupoIdRegistro = "G06";
                            lobReg.GrupoTitulo = "Laboratorios, Sesiones Terapías y Visitas";
                        }
                    }
                }
                return lobConsulta;
            }
        }
        #endregion

        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: estplangr2193md
    /// </summary>
    public class ModeloEstParametros2193MD : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Est_nroreg_essr: Código unico registro
        private String _est_nroreg_essr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193md</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: est_nroreg_essr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro
        /// </para>
        /// </summary>
        public String Est_nroreg_essr
        {
            get { return _est_nroreg_essr; }
            set
            {
                if (_est_nroreg_essr == value) return;
                _est_nroreg_essr = value;
                OnPropertyChanged("Est_nroreg_essr");
            }
        }
        #endregion
        #region Est_nroreg_esgr: Código unico grupo
        private String _est_nroreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Código unico grupo</para>
        /// <para>NOMBRE: est_nroreg_esgr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único grupo del informe
        /// </para>
        /// </summary>
        public String Est_nroreg_esgr
        {
            get { return _est_nroreg_esgr; }
            set
            {
                if (_est_nroreg_esgr == value) return;
                _est_nroreg_esgr = value;
                OnPropertyChanged("Est_nroreg_esgr");
            }
        }
        #endregion
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public String Fcm_codser_sips
        {
            get { return _fcm_codser_sips; }
            set
            {
                if (_fcm_codser_sips == value) return;
                _fcm_codser_sips = value;
                OnPropertyChanged("Fcm_codser_sips");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public String Fcm_coddig_mant
        {
            get { return _fcm_coddig_mant; }
            set
            {
                if (_fcm_coddig_mant == value) return;
                _fcm_coddig_mant = value;
                OnPropertyChanged("Fcm_coddig_mant");
            }
        }
        #endregion
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public String Sia_codrip_trip
        {
            get { return _sia_codrip_trip; }
            set
            {
                if (_sia_codrip_trip == value) return;
                _sia_codrip_trip = value;
                OnPropertyChanged("Sia_codrip_trip");
            }
        }
        #endregion
        #region Sia_codfpr_fpro: Finalidad Procedimiento
        private String _sia_codfpr_fpro;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: sia_codfpr_fpro (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public String Sia_codfpr_fpro
        {
            get { return _sia_codfpr_fpro; }
            set
            {
                if (_sia_codfpr_fpro == value) return;
                _sia_codfpr_fpro = value;
                OnPropertyChanged("Sia_codfpr_fpro");
            }
        }
        #endregion
        #region Sia_codfco_fcon: Finalidad consulta
        private String _sia_codfco_fcon;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: sia_codfco_fcon (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta: 01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas según Resolucion 3374RIPS
        /// </para>
        /// </summary>
        public String Sia_codfco_fcon
        {
            get { return _sia_codfco_fcon; }
            set
            {
                if (_sia_codfco_fcon == value) return;
                _sia_codfco_fcon = value;
                OnPropertyChanged("Sia_codfco_fcon");
            }
        }
        #endregion
        #region Adm_codcex_tcex: Causa Externa
        private String _adm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public String Adm_codcex_tcex
        {
            get { return _adm_codcex_tcex; }
            set
            {
                if (_adm_codcex_tcex == value) return;
                _adm_codcex_tcex = value;
                OnPropertyChanged("Adm_codcex_tcex");
            }
        }
        #endregion
        #region Fcm_mededi_sips: Medida edad Inicial
        private String _fcm_mededi_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: fcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_mededi_sips
        {
            get { return _fcm_mededi_sips; }
            set
            {
                if (_fcm_mededi_sips == value) return;
                _fcm_mededi_sips = value;
                OnPropertyChanged("Fcm_mededi_sips");
            }
        }
        #endregion
        #region Fcm_edaini_sips: Edad Inicial
        private int _fcm_edaini_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: fcm_edaini_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Fcm_edaini_sips
        {
            get { return _fcm_edaini_sips; }
            set
            {
                if (_fcm_edaini_sips == value) return;
                _fcm_edaini_sips = value;
                OnPropertyChanged("Fcm_edaini_sips");
            }
        }
        #endregion
        #region Fcm_mededf_sips: Medida edad final
        private String _fcm_mededf_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: fcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_mededf_sips
        {
            get { return _fcm_mededf_sips; }
            set
            {
                if (_fcm_mededf_sips == value) return;
                _fcm_mededf_sips = value;
                OnPropertyChanged("Fcm_mededf_sips");
            }
        }
        #endregion
        #region Fcm_edafin_sips: Edad final
        private int _fcm_edafin_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: fcm_edafin_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Fcm_edafin_sips
        {
            get { return _fcm_edafin_sips; }
            set
            {
                if (_fcm_edafin_sips == value) return;
                _fcm_edafin_sips = value;
                OnPropertyChanged("Fcm_edafin_sips");
            }
        }
        #endregion
        #region Fcm_sexapl_sips: Sexo que aplica
        private String _fcm_sexapl_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: fcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public String Fcm_sexapl_sips
        {
            get { return _fcm_sexapl_sips; }
            set
            {
                if (_fcm_sexapl_sips == value) return;
                _fcm_sexapl_sips = value;
                OnPropertyChanged("Fcm_sexapl_sips");
            }
        }
        #endregion
        #region Fcm_coddia_sips: Lista diagnosticos
        private String _fcm_coddia_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista diagnosticos</para>
        /// <para>NOMBRE: fcm_coddia_sips (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Lista de diagnosticos CIE -10 permitidos, separados por (punto
        /// y coma)  para validacion en prestacion de servicios y  Gestion
        /// foramtos de Historias clinicas
        /// </para>
        /// </summary>
        public String Fcm_coddia_sips
        {
            get { return _fcm_coddia_sips; }
            set
            {
                if (_fcm_coddia_sips == value) return;
                _fcm_coddia_sips = value;
                OnPropertyChanged("Fcm_coddia_sips");
            }
        }
        #endregion
        #region Est_ordvis_esgr: Orden Vista
        private int _est_ordvis_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: est_ordvis_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Orden visualizacion del registro dentro del grupo en informe
        /// </para>
        /// </summary>
        public int Est_ordvis_esgr
        {
            get { return _est_ordvis_esgr; }
            set
            {
                if (_est_ordvis_esgr == value) return;
                _est_ordvis_esgr = value;
                OnPropertyChanged("Est_ordvis_esgr");
            }
        }
        #endregion
        #region Est_estreg_esgr: Estado del registro
        private String _est_estreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: est_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Est_estreg_esgr
        {
            get { return _est_estreg_esgr; }
            set
            {
                if (_est_estreg_esgr == value) return;
                _est_estreg_esgr = value;
                OnPropertyChanged("Est_estreg_esgr");
            }
        }
        #endregion
        #region Est_nomgru_esgr: Nombre del  grupo
        private String _est_nomgru_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Nombre del  grupo</para>
        /// <para>NOMBRE: est_nomgru_esgr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del grupo de registro en el informe
        /// </para>
        /// </summary>
        public String Est_nomgru_esgr
        {
            get { return _est_nomgru_esgr; }
            set
            {
                if (_est_nomgru_esgr == value) return;
                _est_nomgru_esgr = value;
                OnPropertyChanged("Est_nomgru_esgr");
            }
        }
        #endregion
        #region Fcm_desser_mant: Nombre servicio
        private String _fcm_desser_mant;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public String Fcm_desser_mant
        {
            get { return _fcm_desser_mant; }
            set
            {
                if (_fcm_desser_mant == value) return;
                _fcm_desser_mant = value;
                OnPropertyChanged("Fcm_desser_mant");
            }
        }
        #endregion
        #region Sia_desrip_trip: Descripcion tipo Rips
        private String _sia_desrip_trip;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Descripcion tipo Rips</para>
        /// <para>NOMBRE: sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del servicio según tipo Rips  Resolucion
        /// 3374 RIPS: 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public String Sia_desrip_trip
        {
            get { return _sia_desrip_trip; }
            set
            {
                if (_sia_desrip_trip == value) return;
                _sia_desrip_trip = value;
                OnPropertyChanged("Sia_desrip_trip");
            }
        }
        #endregion
        #region Sia_desfpr_fpro: Descripción
        private String _sia_desfpr_fpro;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfpr_fpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Procedimiento
        /// </para>
        /// </summary>
        public String Sia_desfpr_fpro
        {
            get { return _sia_desfpr_fpro; }
            set
            {
                if (_sia_desfpr_fpro == value) return;
                _sia_desfpr_fpro = value;
                OnPropertyChanged("Sia_desfpr_fpro");
            }
        }
        #endregion
        #region Sia_desfco_fcon: Descripción
        private String _sia_desfco_fcon;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad
        /// </para>
        /// </summary>
        public String Sia_desfco_fcon
        {
            get { return _sia_desfco_fcon; }
            set
            {
                if (_sia_desfco_fcon == value) return;
                _sia_desfco_fcon = value;
                OnPropertyChanged("Sia_desfco_fcon");
            }
        }
        #endregion
        #region Adm_descex_tcex: Decripcion causa externa
        private String _adm_descex_tcex;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public String Adm_descex_tcex
        {
            get { return _adm_descex_tcex; }
            set
            {
                if (_adm_descex_tcex == value) return;
                _adm_descex_tcex = value;
                OnPropertyChanged("Adm_descex_tcex");
            }
        }
        #endregion
        #region Fcm_desmededi_sips: Descripcion medida edad Inicial
        private String _fcm_desmededi_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Descripcion medida edad Inicial</para>
        /// <para>NOMBRE: fcm_desmededi_sips (char:20)</para>       
        /// <para>DESCRIPCION:
        /// Descripcion Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_desmededi_sips
        {
            get { return _fcm_desmededi_sips; }
            set
            {
                if (_fcm_desmededi_sips == value) return;
                _fcm_desmededi_sips = value;
                OnPropertyChanged("Fcm_desmededi_sips");
            }
        }
        #endregion
        #region Fcm_desmededf_sips: Descripcion medida edad final
        private String _fcm_desmededf_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: fcm_desmededf_sips (char:20)</para>        
        /// <para>DESCRIPCION:
        /// Descripcion medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_desmededf_sips
        {
            get { return _fcm_desmededf_sips; }
            set
            {
                if (_fcm_desmededf_sips == value) return;
                _fcm_desmededf_sips = value;
                OnPropertyChanged("Fcm_desmededf_sips");
            }
        }
        #endregion
        #region Est_destreg_esgr: Estado del registro
        private String _est_destreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: est_destreg_esgr (char:1)</para>
        /// <para>DESCRIPCION:
        /// Descripcion Estado del registro  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Est_destreg_esgr
        {
            get { return _est_destreg_esgr; }
            set
            {
                if (_est_destreg_esgr == value) return;
                _est_destreg_esgr = value;
                OnPropertyChanged("Est_destreg_esgr");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private String _sis_estado_imaen;
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public String Sis_estado_imaen
        {
            get { return _sis_estado_imaen; }
            set
            {
                if (_sis_estado_imaen == value) return;
                _sis_estado_imaen = value;
                OnPropertyChanged("Sis_estado_imaen");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloEstParametros2193MD tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFestplangr2193md();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Estplangr2193md.FirstOrDefault(p => p.est_nroreg_essr == tobTempReg.Est_nroreg_essr);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.est_nroreg_essr = tobTempReg.Est_nroreg_essr;
                            lobEFReg.est_nroreg_esgr = tobTempReg.Est_nroreg_esgr;
                            lobEFReg.fcm_codser_sips = tobTempReg.Fcm_codser_sips;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.sia_codrip_trip = tobTempReg.Sia_codrip_trip;
                            lobEFReg.sia_codfpr_fpro = tobTempReg.Sia_codfpr_fpro;
                            lobEFReg.sia_codfco_fcon = tobTempReg.Sia_codfco_fcon;
                            lobEFReg.adm_codcex_tcex = tobTempReg.Adm_codcex_tcex;
                            lobEFReg.fcm_mededi_sips = tobTempReg.Fcm_mededi_sips;
                            lobEFReg.fcm_edaini_sips = (int)tobTempReg.Fcm_edaini_sips;
                            lobEFReg.fcm_mededf_sips = tobTempReg.Fcm_mededf_sips;
                            lobEFReg.fcm_edafin_sips = (int)tobTempReg.Fcm_edafin_sips;
                            lobEFReg.fcm_sexapl_sips = tobTempReg.Fcm_sexapl_sips;
                            lobEFReg.fcm_coddia_sips = tobTempReg.Fcm_coddia_sips;
                            lobEFReg.est_ordvis_esgr = (int)tobTempReg.Est_ordvis_esgr;
                            lobEFReg.est_estreg_esgr = tobTempReg.Est_estreg_esgr;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        switch (tobTempReg.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobEFReg.est_nroreg_essr = tcrCodigoR1 + lobEFReg.est_nroreg_essr; // concatenar
                                _context.AddToEstplangr2193md(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Estplangr2193md.FirstOrDefault(p => p.est_nroreg_essr == tobTempReg.Est_nroreg_essr);
                                if (lobjRegistro != null)
                                {
                                    _context.DeleteObject(lobjRegistro);
                                    _context.SaveChanges();
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ESTPLANGR2193MD: Logica
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TITULO: Servicios para grupos de registros</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Servicios para grupos de registros dentro de un informe
        /// </para>
        /// </summary>
        public static bool flgBuscarEstplangr2193md(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193md.FirstOrDefault(p => p.est_nroreg_essr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloEstParametros2193MD> flsListaEstplangr2193md(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from estplangr2193md in _context.Estplangr2193md
                                  join estplangr2193ma in _context.Estplangr2193ma on estplangr2193md.est_nroreg_esgr equals estplangr2193ma.est_nroreg_esgr into tmestplangr2193ma
                                  join fcmmanservicips in _context.Fcmmanservicips on estplangr2193md.fcm_coddig_mant equals fcmmanservicips.fcm_coddig_mant into tmfcmmanservicips                                 
                                  join siafinaliproced in _context.Siafinaliproced on estplangr2193md.sia_codfpr_fpro equals siafinaliproced.sia_codfpr_fpro into tmsiafinaliproced
                                  join siafinaliconsul in _context.Siafinaliconsul on estplangr2193md.sia_codfco_fcon equals siafinaliconsul.sia_codfco_fcon into tmsiafinaliconsul
                                  join admcausaexterna in _context.Admcausaexterna on estplangr2193md.adm_codcex_tcex equals admcausaexterna.adm_codcex_tcex into tmadmcausaexterna
                                  from esgr in tmestplangr2193ma.DefaultIfEmpty()
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()                                  
                                  from fpro in tmsiafinaliproced.DefaultIfEmpty()
                                  from fcon in tmsiafinaliconsul.DefaultIfEmpty()
                                  from tcex in tmadmcausaexterna.DefaultIfEmpty()
                                  where estplangr2193md.est_nroreg_esgr == tcrBuscar
                                  select new ModeloEstParametros2193MD
                                  {
                                      Est_nroreg_essr = estplangr2193md.est_nroreg_essr,
                                      Est_nroreg_esgr = estplangr2193md.est_nroreg_esgr,
                                      Fcm_codser_sips = estplangr2193md.fcm_codser_sips,
                                      Fcm_coddig_mant = estplangr2193md.fcm_coddig_mant,
                                      Sia_codrip_trip = estplangr2193md.sia_codrip_trip,
                                      Sia_codfpr_fpro = estplangr2193md.sia_codfpr_fpro,
                                      Sia_codfco_fcon = estplangr2193md.sia_codfco_fcon,
                                      Adm_codcex_tcex = estplangr2193md.adm_codcex_tcex,
                                      Fcm_mededi_sips = estplangr2193md.fcm_mededi_sips,
                                      Fcm_edaini_sips = (int)estplangr2193md.fcm_edaini_sips,
                                      Fcm_mededf_sips = estplangr2193md.fcm_mededf_sips,
                                      Fcm_edafin_sips = (int)estplangr2193md.fcm_edafin_sips,
                                      Fcm_sexapl_sips = estplangr2193md.fcm_sexapl_sips,
                                      Fcm_coddia_sips = estplangr2193md.fcm_coddia_sips,
                                      Est_ordvis_esgr = (int)estplangr2193md.est_ordvis_esgr,
                                      Est_estreg_esgr = estplangr2193md.est_estreg_esgr,
                                      Est_nomgru_esgr = esgr.est_nomgru_esgr,
                                      Fcm_desser_mant = sips.fcm_desser_sips,
                                      Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(rpx => rpx.sia_codrip_trip == estplangr2193md.sia_codrip_trip).sia_desrip_trip,
                                      Sia_desfpr_fpro = fpro.sia_desfpr_fpro,
                                      Sia_desfco_fcon = fcon.sia_desfco_fcon,
                                      Adm_descex_tcex = tcex.adm_descex_tcex,
                                      Fcm_desmededi_sips = estplangr2193md.fcm_mededi_sips == "1" ? "Años" : estplangr2193md.fcm_mededi_sips == "2" ? "Meses" : "Dias",
                                      Fcm_desmededf_sips = estplangr2193md.fcm_mededf_sips == "1" ? "Años" : estplangr2193md.fcm_mededf_sips == "2" ? "Meses" : "Dias",
                                      Est_destreg_esgr = estplangr2193md.est_estreg_esgr == "1" ? "Activo" : "Inactivo",
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
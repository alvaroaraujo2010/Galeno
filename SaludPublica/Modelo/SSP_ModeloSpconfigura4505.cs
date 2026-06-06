//- MARMOTA-GENCODE: VERSION 2.0 - 10/10/2014 07:41:12 AM
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

namespace SaludPublica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: spconfigura4505
    /// </summary>
    public class ModeloSpconfigura4505 : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Ssp_codcon_sscf: Código registro
        private String _ssp_codcon_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: ssp_codcon_sscf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código  registro de configuracion
        /// </para>
        /// </summary>
        public String Ssp_codcon_sscf
        {
            get { return _ssp_codcon_sscf; }
            set
            {
                if (_ssp_codcon_sscf == value) return;
                _ssp_codcon_sscf = value;
                OnPropertyChanged("Ssp_codcon_sscf");
            }
        }
        #endregion
        #region Ssp_codips_sscf: Codigo IPS
        private String _ssp_codips_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Codigo IPS</para>
        /// <para>NOMBRE: ssp_codips_sscf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo prestador de servicio IPS asignado para habilitacion
        /// </para>
        /// </summary>
        public String Ssp_codips_sscf
        {
            get { return _ssp_codips_sscf; }
            set
            {
                if (_ssp_codips_sscf == value) return;
                _ssp_codips_sscf = value;
                OnPropertyChanged("Ssp_codips_sscf");
            }
        }
        #endregion
        #region Ssp_nitips_sscf: Nit IPS
        private String _ssp_nitips_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Nit IPS</para>
        /// <para>NOMBRE: ssp_nitips_sscf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nit de la  IPS sin incluir puntos (ejemplo: 845126156-3)
        /// </para>
        /// </summary>
        public String Ssp_nitips_sscf
        {
            get { return _ssp_nitips_sscf; }
            set
            {
                if (_ssp_nitips_sscf == value) return;
                _ssp_nitips_sscf = value;
                OnPropertyChanged("Ssp_nitips_sscf");
            }
        }
        #endregion
        #region Ssp_nomips_sscf: Nombre Razon social
        private String _ssp_nomips_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Nombre Razon social</para>
        /// <para>NOMBRE: ssp_nomips_sscf (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nombre Razon social IPS con que aparece registrada ante el
        /// Ministerio de Salud
        /// </para>
        /// </summary>
        public String Ssp_nomips_sscf
        {
            get { return _ssp_nomips_sscf; }
            set
            {
                if (_ssp_nomips_sscf == value) return;
                _ssp_nomips_sscf = value;
                OnPropertyChanged("Ssp_nomips_sscf");
            }
        }
        #endregion
        #region Ssp_dirent_sscf: Direccion IPS
        private String _ssp_dirent_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Direccion IPS</para>
        /// <para>NOMBRE: ssp_dirent_sscf (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Direccion ubicación de la sede IPS
        /// </para>
        /// </summary>
        public String Ssp_dirent_sscf
        {
            get { return _ssp_dirent_sscf; }
            set
            {
                if (_ssp_dirent_sscf == value) return;
                _ssp_dirent_sscf = value;
                OnPropertyChanged("Ssp_dirent_sscf");
            }
        }
        #endregion
        #region Ssp_telent_sscf: Telefono IPS
        private String _ssp_telent_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Telefono IPS</para>
        /// <para>NOMBRE: ssp_telent_sscf (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Telefono de la entidad IPS
        /// </para>
        /// </summary>
        public String Ssp_telent_sscf
        {
            get { return _ssp_telent_sscf; }
            set
            {
                if (_ssp_telent_sscf == value) return;
                _ssp_telent_sscf = value;
                OnPropertyChanged("Ssp_telent_sscf");
            }
        }
        #endregion
        #region Ssp_rutarc_sscf: Ruta destino planos
        private String _ssp_rutarc_sscf;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Ruta destino planos</para>
        /// <para>NOMBRE: ssp_rutarc_sscf (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Ruta por defecto para generar los archivos planos
        /// </para>
        /// </summary>
        public String Ssp_rutarc_sscf
        {
            get { return _ssp_rutarc_sscf; }
            set
            {
                if (_ssp_rutarc_sscf == value) return;
                _ssp_rutarc_sscf = value;
                OnPropertyChanged("Ssp_rutarc_sscf");
            }
        }
        #endregion
        #region Sis_secreg_siva: Codigo plantilla
        private String _sis_secreg_siva;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro para plantillas
        /// </para>
        /// </summary>
        public String Sis_secreg_siva
        {
            get { return _sis_secreg_siva; }
            set
            {
                if (_sis_secreg_siva == value) return;
                _sis_secreg_siva = value;
                OnPropertyChanged("Sis_secreg_siva");
            }
        }
        #endregion
        #region Sis_despla_siva: Descripción  plantilla
        private String _sis_despla_siva;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public String Sis_despla_siva
        {
            get { return _sis_despla_siva; }
            set
            {
                if (_sis_despla_siva == value) return;
                _sis_despla_siva = value;
                OnPropertyChanged("Sis_despla_siva");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSpconfigura4505 tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFspconfigura4505
                {
                    #region cargar Registro
                    ssp_codcon_sscf = tobjModelo.Ssp_codcon_sscf,
                    ssp_codips_sscf = tobjModelo.Ssp_codips_sscf,
                    ssp_nitips_sscf = tobjModelo.Ssp_nitips_sscf,
                    ssp_nomips_sscf = tobjModelo.Ssp_nomips_sscf,
                    ssp_dirent_sscf = tobjModelo.Ssp_dirent_sscf,
                    ssp_telent_sscf = tobjModelo.Ssp_telent_sscf,
                    ssp_rutarc_sscf = tobjModelo.Ssp_rutarc_sscf,
                    sis_secreg_siva = tobjModelo.Sis_secreg_siva,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.ssp_codcon_sscf;
                _context.AddToSpconfigura4505(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSpconfigura4505 tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spconfigura4505.FirstOrDefault(p => p.ssp_codcon_sscf == tobjModelo.Ssp_codcon_sscf);
                if (lobjRegistro != null)
                {
                    lobjRegistro.ssp_codcon_sscf = tobjModelo.Ssp_codcon_sscf;
                    lobjRegistro.ssp_codips_sscf = tobjModelo.Ssp_codips_sscf;
                    lobjRegistro.ssp_nitips_sscf = tobjModelo.Ssp_nitips_sscf;
                    lobjRegistro.ssp_nomips_sscf = tobjModelo.Ssp_nomips_sscf;
                    lobjRegistro.ssp_dirent_sscf = tobjModelo.Ssp_dirent_sscf;
                    lobjRegistro.ssp_telent_sscf = tobjModelo.Ssp_telent_sscf;
                    lobjRegistro.ssp_rutarc_sscf = tobjModelo.Ssp_rutarc_sscf;
                    lobjRegistro.sis_secreg_siva = tobjModelo.Sis_secreg_siva;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spconfigura4505.FirstOrDefault(p => p.ssp_codcon_sscf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SPCONFIGURA4505: Logica
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TITULO: Configuracion general modulo Resolución 4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Parametros de configuracion para el modulo gestion de datos
        /// resolución 4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSpconfigura4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spconfigura4505.FirstOrDefault(p => p.ssp_codcon_sscf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Consultar IPS: código ips default
        /// <summary>
        /// <para>TABLA: fcrBuscarIpsSpconfigura4505</para>
        /// <para>TITULO: Configuracion general modulo Resolución 4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor del código de la ips por defecto en el sistema.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Parametros de configuracion para el modulo gestion de datos
        /// resolución 4505
        /// </para>
        /// </summary>
        public static String fcrBuscarIpsSpconfigura4505()
        {
            string lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spconfigura4505.FirstOrDefault();
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_codips_sscf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSpconfigura4505> flsListaSpconfigura4505(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from spconfigura4505 in _context.Spconfigura4505
                                      join sismaesplavalid in _context.Sismaesplavalid on spconfigura4505.sis_secreg_siva equals sismaesplavalid.sis_secreg_siva into tmsismaesplavalid
                                      from siva in tmsismaesplavalid.DefaultIfEmpty()
                                      select new ModeloSpconfigura4505
                                      {
                                          Ssp_codcon_sscf = spconfigura4505.ssp_codcon_sscf,
                                          Ssp_codips_sscf = spconfigura4505.ssp_codips_sscf,
                                          Ssp_nitips_sscf = spconfigura4505.ssp_nitips_sscf,
                                          Ssp_nomips_sscf = spconfigura4505.ssp_nomips_sscf,
                                          Ssp_dirent_sscf = spconfigura4505.ssp_dirent_sscf,
                                          Ssp_telent_sscf = spconfigura4505.ssp_telent_sscf,
                                          Ssp_rutarc_sscf = spconfigura4505.ssp_rutarc_sscf,
                                          Sis_secreg_siva = spconfigura4505.sis_secreg_siva,
                                          Sis_despla_siva = siva.sis_despla_siva,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from spconfigura4505 in _context.Spconfigura4505
                                      join sismaesplavalid in _context.Sismaesplavalid on spconfigura4505.sis_secreg_siva equals sismaesplavalid.sis_secreg_siva into tmsismaesplavalid
                                      from siva in tmsismaesplavalid.DefaultIfEmpty()
                                      where spconfigura4505.ssp_codcon_sscf == tcrBuscar
                                      select new ModeloSpconfigura4505
                                      {
                                          Ssp_codcon_sscf = spconfigura4505.ssp_codcon_sscf,
                                          Ssp_codips_sscf = spconfigura4505.ssp_codips_sscf,
                                          Ssp_nitips_sscf = spconfigura4505.ssp_nitips_sscf,
                                          Ssp_nomips_sscf = spconfigura4505.ssp_nomips_sscf,
                                          Ssp_dirent_sscf = spconfigura4505.ssp_dirent_sscf,
                                          Ssp_telent_sscf = spconfigura4505.ssp_telent_sscf,
                                          Ssp_rutarc_sscf = spconfigura4505.ssp_rutarc_sscf,
                                          Sis_secreg_siva = spconfigura4505.sis_secreg_siva,
                                          Sis_despla_siva = siva.sis_despla_siva,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
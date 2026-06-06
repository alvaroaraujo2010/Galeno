//- MARMOTA-GENCODE: VERSION 2.0 - 01/04/2015 05:53:46 PM
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

namespace Systemas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sisparametroips
    /// </summary>
    public class ModeloSisparametroips : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sis_idereg_pips: Codigo registro
        private String _sis_idereg_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: sis_idereg_pips (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial detalle id unico para cada registro de campo
        /// </para>
        /// </summary>
        public String Sis_idereg_pips
        {
            get { return _sis_idereg_pips; }
            set
            {
                if (_sis_idereg_pips == value) return;
                _sis_idereg_pips = value;
                OnPropertyChanged("Sis_idereg_pips");
            }
        }
        #endregion
        #region Sis_razsoc_pips: Razon social
        private String _sis_razsoc_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Razon social</para>
        /// <para>NOMBRE: sis_razsoc_pips (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre completo razon social razon social IPS
        /// </para>
        /// </summary>
        public String Sis_razsoc_pips
        {
            get { return _sis_razsoc_pips; }
            set
            {
                if (_sis_razsoc_pips == value) return;
                _sis_razsoc_pips = value;
                OnPropertyChanged("Sis_razsoc_pips");
            }
        }
        #endregion
        #region Sis_nitips_pips: Numero Nit
        private String _sis_nitips_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Numero Nit</para>
        /// <para>NOMBRE: sis_nitips_pips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero del NIT sin separadores decimales
        /// </para>
        /// </summary>
        public String Sis_nitips_pips
        {
            get { return _sis_nitips_pips; }
            set
            {
                if (_sis_nitips_pips == value) return;
                _sis_nitips_pips = value;
                OnPropertyChanged("Sis_nitips_pips");
            }
        }
        #endregion
        #region Sis_codips_pips: Codigo Prestador IPS
        private String _sis_codips_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Codigo Prestador IPS</para>
        /// <para>NOMBRE: sis_codips_pips (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo prestador de servicios medicos IPS asignado por el Ministerio
        /// </para>
        /// </summary>
        public String Sis_codips_pips
        {
            get { return _sis_codips_pips; }
            set
            {
                if (_sis_codips_pips == value) return;
                _sis_codips_pips = value;
                OnPropertyChanged("Sis_codips_pips");
            }
        }
        #endregion
        #region Sis_nitipx_pips: Nit  con separadores
        private String _sis_nitipx_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Nit  con separadores</para>
        /// <para>NOMBRE: sis_nitipx_pips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero del NIT con  separadores decimales para vista en impresión
        /// de reportes y otros
        /// </para>
        /// </summary>
        public String Sis_nitipx_pips
        {
            get { return _sis_nitipx_pips; }
            set
            {
                if (_sis_nitipx_pips == value) return;
                _sis_nitipx_pips = value;
                OnPropertyChanged("Sis_nitipx_pips");
            }
        }
        #endregion
        #region Sis_dirips_pips: Direccion
        private String _sis_dirips_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Direccion</para>
        /// <para>NOMBRE: sis_dirips_pips (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Direccion sede de la empresa IPS
        /// </para>
        /// </summary>
        public String Sis_dirips_pips
        {
            get { return _sis_dirips_pips; }
            set
            {
                if (_sis_dirips_pips == value) return;
                _sis_dirips_pips = value;
                OnPropertyChanged("Sis_dirips_pips");
            }
        }
        #endregion
        #region Sis_telefo_pips: Telefono
        private String _sis_telefo_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: sis_telefo_pips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de telefono de la IPS
        /// </para>
        /// </summary>
        public String Sis_telefo_pips
        {
            get { return _sis_telefo_pips; }
            set
            {
                if (_sis_telefo_pips == value) return;
                _sis_telefo_pips = value;
                OnPropertyChanged("Sis_telefo_pips");
            }
        }
        #endregion
        #region Sis_nomdpt_pips: Departamento
        private String _sis_nomdpt_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Departamento</para>
        /// <para>NOMBRE: sis_nomdpt_pips (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento residencia
        /// </para>
        /// </summary>
        public String Sis_nomdpt_pips
        {
            get { return _sis_nomdpt_pips; }
            set
            {
                if (_sis_nomdpt_pips == value) return;
                _sis_nomdpt_pips = value;
                OnPropertyChanged("Sis_nomdpt_pips");
            }
        }
        #endregion
        #region Sis_nommun_pips: Ciudad
        private String _sis_nommun_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Ciudad</para>
        /// <para>NOMBRE: sis_nommun_pips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre  ciudad direccion residencia
        /// </para>
        /// </summary>
        public String Sis_nommun_pips
        {
            get { return _sis_nommun_pips; }
            set
            {
                if (_sis_nommun_pips == value) return;
                _sis_nommun_pips = value;
                OnPropertyChanged("Sis_nommun_pips");
            }
        }
        #endregion
        #region Sis_eslog_pips: Eslogan IPS
        private String _sis_eslog_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Eslogan IPS</para>
        /// <para>NOMBRE: sis_eslog_pips (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Eslogan IPS
        /// </para>
        /// </summary>
        public String Sis_eslog_pips
        {
            get { return _sis_eslog_pips; }
            set
            {
                if (_sis_eslog_pips == value) return;
                _sis_eslog_pips = value;
                OnPropertyChanged("Sis_eslog_pips");
            }
        }
        #endregion
        #region Sis_logtip_pips: Logotipo
        private String _sis_logtip_pips;
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TABLA NATIVA: sisparametroips</para>
        /// <para>CAMPO: Llogotipo</para>
        /// <para>NOMBRE: sis_logtip_pips (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Ruta y nombre del logotipo
        /// </para>
        /// </summary>
        public String Sis_logtip_pips
        {
            get { return _sis_logtip_pips; }
            set
            {
                if (_sis_logtip_pips == value) return;
                _sis_logtip_pips = value;
                OnPropertyChanged("Sis_logtip_pips");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSisparametroips tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsisparametroips
                {
                    #region cargar Registro
                    sis_idereg_pips = tobjModelo.Sis_idereg_pips,
                    sis_razsoc_pips = tobjModelo.Sis_razsoc_pips,
                    sis_nitips_pips = tobjModelo.Sis_nitips_pips,
                    sis_codips_pips = tobjModelo.Sis_codips_pips,
                    sis_nitipx_pips = tobjModelo.Sis_nitipx_pips,
                    sis_dirips_pips = tobjModelo.Sis_dirips_pips,
                    sis_telefo_pips = tobjModelo.Sis_telefo_pips,
                    sis_nomdpt_pips = tobjModelo.Sis_nomdpt_pips,
                    sis_nommun_pips = tobjModelo.Sis_nommun_pips,
                    sis_eslog_pips = tobjModelo.Sis_eslog_pips,
                    sis_logtip_pips = tobjModelo.Sis_logtip_pips,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.sis_idereg_pips;
                _context.AddToSisparametroips(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSisparametroips tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tobjModelo.Sis_idereg_pips);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sis_idereg_pips = tobjModelo.Sis_idereg_pips;
                    lobjRegistro.sis_razsoc_pips = tobjModelo.Sis_razsoc_pips;
                    lobjRegistro.sis_nitips_pips = tobjModelo.Sis_nitips_pips;
                    lobjRegistro.sis_codips_pips = tobjModelo.Sis_codips_pips;
                    lobjRegistro.sis_nitipx_pips = tobjModelo.Sis_nitipx_pips;
                    lobjRegistro.sis_dirips_pips = tobjModelo.Sis_dirips_pips;
                    lobjRegistro.sis_telefo_pips = tobjModelo.Sis_telefo_pips;
                    lobjRegistro.sis_nomdpt_pips = tobjModelo.Sis_nomdpt_pips;
                    lobjRegistro.sis_nommun_pips = tobjModelo.Sis_nommun_pips;
                    lobjRegistro.sis_eslog_pips = tobjModelo.Sis_eslog_pips;
                    lobjRegistro.sis_logtip_pips = tobjModelo.Sis_logtip_pips;
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
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SISPARAMETROIPS: Logica
        /// <summary>
        /// <para>TABLA: sisparametroips</para>
        /// <para>TITULO: Parametros basicos configuración IPS</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro para configracion de datos basicos IPS tales
        /// como:  razon social Nit codigo prestador logotipo eslogan y
        /// mas
        /// </para>
        /// </summary>
        public static bool flgBuscarSisparametroips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sisparametroips.FirstOrDefault(p => p.sis_idereg_pips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSisparametroips> flsListaSisparametroips(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sisparametroips in _context.Sisparametroips
                                  where sisparametroips.sis_idereg_pips == tcrBuscar
                                  select new ModeloSisparametroips
                                  {
                                      Sis_idereg_pips = sisparametroips.sis_idereg_pips,
                                      Sis_razsoc_pips = sisparametroips.sis_razsoc_pips,
                                      Sis_nitips_pips = sisparametroips.sis_nitips_pips,
                                      Sis_codips_pips = sisparametroips.sis_codips_pips,
                                      Sis_nitipx_pips = sisparametroips.sis_nitipx_pips,
                                      Sis_dirips_pips = sisparametroips.sis_dirips_pips,
                                      Sis_telefo_pips = sisparametroips.sis_telefo_pips,
                                      Sis_nomdpt_pips = sisparametroips.sis_nomdpt_pips,
                                      Sis_nommun_pips = sisparametroips.sis_nommun_pips,
                                      Sis_eslog_pips = sisparametroips.sis_eslog_pips,
                                      Sis_logtip_pips = sisparametroips.sis_logtip_pips,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar Registro por defecto
        public static ModeloSisparametroips flsListaSisparametroipsRg()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sisparametroips in _context.Sisparametroips
                                  select new ModeloSisparametroips
                                  {
                                      Sis_idereg_pips = sisparametroips.sis_idereg_pips,
                                      Sis_razsoc_pips = sisparametroips.sis_razsoc_pips,
                                      Sis_nitips_pips = sisparametroips.sis_nitips_pips,
                                      Sis_codips_pips = sisparametroips.sis_codips_pips,
                                      Sis_nitipx_pips = sisparametroips.sis_nitipx_pips,
                                      Sis_dirips_pips = sisparametroips.sis_dirips_pips,
                                      Sis_telefo_pips = sisparametroips.sis_telefo_pips,
                                      Sis_nomdpt_pips = sisparametroips.sis_nomdpt_pips,
                                      Sis_nommun_pips = sisparametroips.sis_nommun_pips,
                                      Sis_eslog_pips = sisparametroips.sis_eslog_pips,
                                      Sis_logtip_pips = sisparametroips.sis_logtip_pips,
                                  };
                return lobConsulta.ToList().FirstOrDefault();
            }
        }
        #endregion
        #endregion
    }
}
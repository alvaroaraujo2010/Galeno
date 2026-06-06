//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2014 07:49:10 AM
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
    /// Descripcion para la Vista de  la tabla: sysgeneradorcod
    /// </summary>
    public class ModeloSysgeneradorcod : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codsec_gcod: llave  Registro
        private String _sys_codsec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: llave  Registro</para>
        /// <para>NOMBRE: sys_codsec_gcod (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Llave única para localizar el Secuencial
        /// </para>
        /// </summary>
        public String Sys_codsec_gcod
        {
            get { return _sys_codsec_gcod; }
            set
            {
                if (_sys_codsec_gcod == value) return;
                _sys_codsec_gcod = value;
                OnPropertyChanged("Sys_codsec_gcod");
            }
        }
        #endregion
        #region Sys_codmod_modu: Código Módulo
        private String _sys_codmod_modu;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: sys_codmod_modu (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código del módulo al cual pertenece el secuencial esto para
        /// mostrarlos como grupos
        /// </para>
        /// </summary>
        public String Sys_codmod_modu
        {
            get { return _sys_codmod_modu; }
            set
            {
                if (_sys_codmod_modu == value) return;
                _sys_codmod_modu = value;
                OnPropertyChanged("Sys_codmod_modu");
            }
        }
        #endregion
        #region Sys_dessec_gcod: Nombre Secuencial
        private String _sys_dessec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Nombre Secuencial</para>
        /// <para>NOMBRE: sys_dessec_gcod (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del Secuencial
        /// </para>
        /// </summary>
        public String Sys_dessec_gcod
        {
            get { return _sys_dessec_gcod; }
            set
            {
                if (_sys_dessec_gcod == value) return;
                _sys_dessec_gcod = value;
                OnPropertyChanged("Sys_dessec_gcod");
            }
        }
        #endregion
        #region Sys_ultsec_gcod: Último Sec Generado
        private int _sys_ultsec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Último Sec Generado</para>
        /// <para>NOMBRE: sys_ultsec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Último secuencial generado
        /// </para>
        /// </summary>
        public int Sys_ultsec_gcod
        {
            get { return _sys_ultsec_gcod; }
            set
            {
                if (_sys_ultsec_gcod == value) return;
                _sys_ultsec_gcod = value;
                OnPropertyChanged("Sys_ultsec_gcod");
            }
        }
        #endregion
        #region Sys_inisec_gcod: Número Sec Inicial
        private int _sys_inisec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Número Sec Inicial</para>
        /// <para>NOMBRE: sys_inisec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Número desde el cual inicia el conteo
        /// </para>
        /// </summary>
        public int Sys_inisec_gcod
        {
            get { return _sys_inisec_gcod; }
            set
            {
                if (_sys_inisec_gcod == value) return;
                _sys_inisec_gcod = value;
                OnPropertyChanged("Sys_inisec_gcod");
            }
        }
        #endregion
        #region Sys_finsec_gcod: Número Sec Final
        private int _sys_finsec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Número Sec Final</para>
        /// <para>NOMBRE: sys_finsec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Número en el cual Finaliza el conteo
        /// </para>
        /// </summary>
        public int Sys_finsec_gcod
        {
            get { return _sys_finsec_gcod; }
            set
            {
                if (_sys_finsec_gcod == value) return;
                _sys_finsec_gcod = value;
                OnPropertyChanged("Sys_finsec_gcod");
            }
        }
        #endregion
        #region Sys_maxsec_gcod: Tamaño Secuencial
        private int _sys_maxsec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: sys_maxsec_gcod (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Indica el tamaño máximo en caracteres para el secuencial generado
        /// </para>
        /// </summary>
        public int Sys_maxsec_gcod
        {
            get { return _sys_maxsec_gcod; }
            set
            {
                if (_sys_maxsec_gcod == value) return;
                _sys_maxsec_gcod = value;
                OnPropertyChanged("Sys_maxsec_gcod");
            }
        }
        #endregion
        #region Sys_alrsec_gcod: Limite Sec Alarma
        private int _sys_alrsec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Limite Sec Alarma</para>
        /// <para>NOMBRE: sys_alrsec_gcod (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos números secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int Sys_alrsec_gcod
        {
            get { return _sys_alrsec_gcod; }
            set
            {
                if (_sys_alrsec_gcod == value) return;
                _sys_alrsec_gcod = value;
                OnPropertyChanged("Sys_alrsec_gcod");
            }
        }
        #endregion
        #region Sys_relcer_gcod: Rellenar con Ceros
        private String _sys_relcer_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: sys_relcer_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Indica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public String Sys_relcer_gcod
        {
            get { return _sys_relcer_gcod; }
            set
            {
                if (_sys_relcer_gcod == value) return;
                _sys_relcer_gcod = value;
                OnPropertyChanged("Sys_relcer_gcod");
            }
        }
        #endregion
        #region Sys_prefij_gcod: Prefijo
        private String _sys_prefij_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Prefijo</para>
        /// <para>NOMBRE: sys_prefij_gcod (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Texto o Identificador Inicial del nuevo código generado
        /// </para>
        /// </summary>
        public String Sys_prefij_gcod
        {
            get { return _sys_prefij_gcod; }
            set
            {
                if (_sys_prefij_gcod == value) return;
                _sys_prefij_gcod = value;
                OnPropertyChanged("Sys_prefij_gcod");
            }
        }
        #endregion
        #region Sys_sufijo_gcod: Sufijo
        private String _sys_sufijo_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Sufijo</para>
        /// <para>NOMBRE: sys_sufijo_gcod (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Texto o Identificador final del nuevo código generado
        /// </para>
        /// </summary>
        public String Sys_sufijo_gcod
        {
            get { return _sys_sufijo_gcod; }
            set
            {
                if (_sys_sufijo_gcod == value) return;
                _sys_sufijo_gcod = value;
                OnPropertyChanged("Sys_sufijo_gcod");
            }
        }
        #endregion
        #region Sys_incfec_gcod: Incluir datos Fecha
        private String _sys_incfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir datos Fecha</para>
        /// <para>NOMBRE: sys_incfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica si se incluye datos de fecha en el nuevo secuencial
        /// 1=Incluir en prefijo  2=Incluir sufijo 3 =No incluir
        /// </para>
        /// </summary>
        public String Sys_incfec_gcod
        {
            get { return _sys_incfec_gcod; }
            set
            {
                if (_sys_incfec_gcod == value) return;
                _sys_incfec_gcod = value;
                OnPropertyChanged("Sys_incfec_gcod");
            }
        }
        #endregion
        #region Sys_locfec_gcod: Localización
        private String _sys_locfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Localización</para>
        /// <para>NOMBRE: sys_locfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Localización del dato fecha dentro del nuevo secuencial  1=
        /// Antes 2=Después
        /// </para>
        /// </summary>
        public String Sys_locfec_gcod
        {
            get { return _sys_locfec_gcod; }
            set
            {
                if (_sys_locfec_gcod == value) return;
                _sys_locfec_gcod = value;
                OnPropertyChanged("Sys_locfec_gcod");
            }
        }
        #endregion
        #region Sys_forfec_gcod: Formato de Fecha
        private String _sys_forfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Formato de Fecha</para>
        /// <para>NOMBRE: sys_forfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Formato fecha 1= DD/MM/AA 2=MM/DD/AA 3= AA/MM/DD 4=AA/DD/MM
        /// </para>
        /// </summary>
        public String Sys_forfec_gcod
        {
            get { return _sys_forfec_gcod; }
            set
            {
                if (_sys_forfec_gcod == value) return;
                _sys_forfec_gcod = value;
                OnPropertyChanged("Sys_forfec_gcod");
            }
        }
        #endregion
        #region Sys_incdia_gcod: Incluir Día
        private String _sys_incdia_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Día</para>
        /// <para>NOMBRE: sys_incdia_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Incluir el día para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public String Sys_incdia_gcod
        {
            get { return _sys_incdia_gcod; }
            set
            {
                if (_sys_incdia_gcod == value) return;
                _sys_incdia_gcod = value;
                OnPropertyChanged("Sys_incdia_gcod");
            }
        }
        #endregion
        #region Sys_incmes_gcod: Incluir Mes
        private String _sys_incmes_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Mes</para>
        /// <para>NOMBRE: sys_incmes_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Incluir el mes para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public String Sys_incmes_gcod
        {
            get { return _sys_incmes_gcod; }
            set
            {
                if (_sys_incmes_gcod == value) return;
                _sys_incmes_gcod = value;
                OnPropertyChanged("Sys_incmes_gcod");
            }
        }
        #endregion
        #region Sys_incano_gcod: Incluir Año
        private String _sys_incano_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Año</para>
        /// <para>NOMBRE: sys_incano_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Incluir el año para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public String Sys_incano_gcod
        {
            get { return _sys_incano_gcod; }
            set
            {
                if (_sys_incano_gcod == value) return;
                _sys_incano_gcod = value;
                OnPropertyChanged("Sys_incano_gcod");
            }
        }
        #endregion
        #region Sys_nivacc_gcod: Nivel de acceso
        private String _sys_nivacc_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Nivel de acceso</para>
        /// <para>NOMBRE: sys_nivacc_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Nivel Prioridad de acceso a vista del registro de secuencial,
        /// para súper usuarios y usuarios de gestión: 1=Sólo Súper Usuarios
        /// 2=Administradores
        /// </para>
        /// </summary>
        public String Sys_nivacc_gcod
        {
            get { return _sys_nivacc_gcod; }
            set
            {
                if (_sys_nivacc_gcod == value) return;
                _sys_nivacc_gcod = value;
                OnPropertyChanged("Sys_nivacc_gcod");
            }
        }
        #endregion
        #region Sys_nommod_modu: Nombre Módulo
        private String _sys_nommod_modu;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Nombre Módulo</para>
        /// <para>NOMBRE: sys_nommod_modu (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del Módulo, que se mostrara como titulo en las opciones
        /// del sistema
        /// </para>
        /// </summary>
        public String Sys_nommod_modu
        {
            get { return _sys_nommod_modu; }
            set
            {
                if (_sys_nommod_modu == value) return;
                _sys_nommod_modu = value;
                OnPropertyChanged("Sys_nommod_modu");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSysgeneradorcod tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsysgeneradorcod
                {
                    #region cargar Registro
                    sys_codsec_gcod = tobjModelo.Sys_codsec_gcod,
                    sys_codmod_modu = tobjModelo.Sys_codmod_modu,
                    sys_dessec_gcod = tobjModelo.Sys_dessec_gcod,
                    sys_ultsec_gcod = tobjModelo.Sys_ultsec_gcod,
                    sys_inisec_gcod = tobjModelo.Sys_inisec_gcod,
                    sys_finsec_gcod = tobjModelo.Sys_finsec_gcod,
                    sys_maxsec_gcod = tobjModelo.Sys_maxsec_gcod,
                    sys_alrsec_gcod = tobjModelo.Sys_alrsec_gcod,
                    sys_relcer_gcod = tobjModelo.Sys_relcer_gcod,
                    sys_prefij_gcod = tobjModelo.Sys_prefij_gcod,
                    sys_sufijo_gcod = tobjModelo.Sys_sufijo_gcod,
                    sys_incfec_gcod = tobjModelo.Sys_incfec_gcod,
                    sys_locfec_gcod = tobjModelo.Sys_locfec_gcod,
                    sys_forfec_gcod = tobjModelo.Sys_forfec_gcod,
                    sys_incdia_gcod = tobjModelo.Sys_incdia_gcod,
                    sys_incmes_gcod = tobjModelo.Sys_incmes_gcod,
                    sys_incano_gcod = tobjModelo.Sys_incano_gcod,
                    sys_nivacc_gcod = tobjModelo.Sys_nivacc_gcod,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.sys_codsec_gcod;
                _context.AddToSysgeneradorcod(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSysgeneradorcod tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tobjModelo.Sys_codsec_gcod);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sys_codsec_gcod = tobjModelo.Sys_codsec_gcod;
                    lobjRegistro.sys_codmod_modu = tobjModelo.Sys_codmod_modu;
                    lobjRegistro.sys_dessec_gcod = tobjModelo.Sys_dessec_gcod;
                    lobjRegistro.sys_ultsec_gcod = (int)tobjModelo.Sys_ultsec_gcod;
                    lobjRegistro.sys_inisec_gcod = (int)tobjModelo.Sys_inisec_gcod;
                    lobjRegistro.sys_finsec_gcod = (int)tobjModelo.Sys_finsec_gcod;
                    lobjRegistro.sys_maxsec_gcod = (int)tobjModelo.Sys_maxsec_gcod;
                    lobjRegistro.sys_alrsec_gcod = (int)tobjModelo.Sys_alrsec_gcod;
                    lobjRegistro.sys_relcer_gcod = tobjModelo.Sys_relcer_gcod;
                    lobjRegistro.sys_prefij_gcod = tobjModelo.Sys_prefij_gcod;
                    lobjRegistro.sys_sufijo_gcod = tobjModelo.Sys_sufijo_gcod;
                    lobjRegistro.sys_incfec_gcod = tobjModelo.Sys_incfec_gcod;
                    lobjRegistro.sys_locfec_gcod = tobjModelo.Sys_locfec_gcod;
                    lobjRegistro.sys_forfec_gcod = tobjModelo.Sys_forfec_gcod;
                    lobjRegistro.sys_incdia_gcod = tobjModelo.Sys_incdia_gcod;
                    lobjRegistro.sys_incmes_gcod = tobjModelo.Sys_incmes_gcod;
                    lobjRegistro.sys_incano_gcod = tobjModelo.Sys_incano_gcod;
                    lobjRegistro.sys_nivacc_gcod = tobjModelo.Sys_nivacc_gcod;
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
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SYSGENERADORCOD: Logica
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TITULO: Tabla Generador de  secuenciales</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del sistema donde se almacenan los secuenciales generados,
        /// se agrupan según el módulo al cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarSysgeneradorcod(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSysgeneradorcod> flsListaSysgeneradorcod(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sysgeneradorcod in _context.Sysgeneradorcod
                                      join sysmodulosistem in _context.Sysmodulosistem on sysgeneradorcod.sys_codmod_modu equals sysmodulosistem.sys_codmod_modu into tmsysmodulosistem
                                      from modu in tmsysmodulosistem.DefaultIfEmpty()
                                      select new ModeloSysgeneradorcod
                                      {
                                          Sys_codsec_gcod = sysgeneradorcod.sys_codsec_gcod,
                                          Sys_codmod_modu = sysgeneradorcod.sys_codmod_modu,
                                          Sys_dessec_gcod = sysgeneradorcod.sys_dessec_gcod,
                                          Sys_ultsec_gcod = (int)sysgeneradorcod.sys_ultsec_gcod,
                                          Sys_inisec_gcod = (int)sysgeneradorcod.sys_inisec_gcod,
                                          Sys_finsec_gcod = (int)sysgeneradorcod.sys_finsec_gcod,
                                          Sys_maxsec_gcod = (int)sysgeneradorcod.sys_maxsec_gcod,
                                          Sys_alrsec_gcod = (int)sysgeneradorcod.sys_alrsec_gcod,
                                          Sys_relcer_gcod = sysgeneradorcod.sys_relcer_gcod,
                                          Sys_prefij_gcod = sysgeneradorcod.sys_prefij_gcod,
                                          Sys_sufijo_gcod = sysgeneradorcod.sys_sufijo_gcod,
                                          Sys_incfec_gcod = sysgeneradorcod.sys_incfec_gcod,
                                          Sys_locfec_gcod = sysgeneradorcod.sys_locfec_gcod,
                                          Sys_forfec_gcod = sysgeneradorcod.sys_forfec_gcod,
                                          Sys_incdia_gcod = sysgeneradorcod.sys_incdia_gcod,
                                          Sys_incmes_gcod = sysgeneradorcod.sys_incmes_gcod,
                                          Sys_incano_gcod = sysgeneradorcod.sys_incano_gcod,
                                          Sys_nivacc_gcod = sysgeneradorcod.sys_nivacc_gcod,
                                          Sys_nommod_modu = modu.sys_nommod_modu,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sysgeneradorcod in _context.Sysgeneradorcod
                                      join sysmodulosistem in _context.Sysmodulosistem on sysgeneradorcod.sys_codmod_modu equals sysmodulosistem.sys_codmod_modu into tmsysmodulosistem
                                      from modu in tmsysmodulosistem.DefaultIfEmpty()
                                      where sysgeneradorcod.sys_codsec_gcod == tcrBuscar
                                      select new ModeloSysgeneradorcod
                                      {
                                          Sys_codsec_gcod = sysgeneradorcod.sys_codsec_gcod,
                                          Sys_codmod_modu = sysgeneradorcod.sys_codmod_modu,
                                          Sys_dessec_gcod = sysgeneradorcod.sys_dessec_gcod,
                                          Sys_ultsec_gcod = (int)sysgeneradorcod.sys_ultsec_gcod,
                                          Sys_inisec_gcod = (int)sysgeneradorcod.sys_inisec_gcod,
                                          Sys_finsec_gcod = (int)sysgeneradorcod.sys_finsec_gcod,
                                          Sys_maxsec_gcod = (int)sysgeneradorcod.sys_maxsec_gcod,
                                          Sys_alrsec_gcod = (int)sysgeneradorcod.sys_alrsec_gcod,
                                          Sys_relcer_gcod = sysgeneradorcod.sys_relcer_gcod,
                                          Sys_prefij_gcod = sysgeneradorcod.sys_prefij_gcod,
                                          Sys_sufijo_gcod = sysgeneradorcod.sys_sufijo_gcod,
                                          Sys_incfec_gcod = sysgeneradorcod.sys_incfec_gcod,
                                          Sys_locfec_gcod = sysgeneradorcod.sys_locfec_gcod,
                                          Sys_forfec_gcod = sysgeneradorcod.sys_forfec_gcod,
                                          Sys_incdia_gcod = sysgeneradorcod.sys_incdia_gcod,
                                          Sys_incmes_gcod = sysgeneradorcod.sys_incmes_gcod,
                                          Sys_incano_gcod = sysgeneradorcod.sys_incano_gcod,
                                          Sys_nivacc_gcod = sysgeneradorcod.sys_nivacc_gcod,
                                          Sys_nommod_modu = modu.sys_nommod_modu,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
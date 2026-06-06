//- MARMOTA-GENCODE: VERSION 2.0 - 27/02/2014 09:09:27 PM
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

namespace GestorReportes.Modelo
{
    
    /// <summary>
    /// Maestro versiones de plantillas
    /// </summary>
    public class VersionPlantilla : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Grp_idepla_grpv: Código version plantilla
        private String _grp_idepla_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de la version plantilla (generado por el
        /// sistema)
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv
        {
            get { return _grp_idepla_grpv; }
            set
            {
                if (_grp_idepla_grpv == value) return;
                _grp_idepla_grpv = value;
                OnPropertyChanged("Grp_idepla_grpv");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Grp_verpla_grpv: Version plantilla
        private String _grp_verpla_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Version plantilla</para>
        /// <para>NOMBRE: grp_verpla_grpv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero de la Version plantilla ejemplo: 10,11,12…
        /// </para>
        /// </summary>
        public String Grp_verpla_grpv
        {
            get { return _grp_verpla_grpv; }
            set
            {
                if (_grp_verpla_grpv == value) return;
                _grp_verpla_grpv = value;
                OnPropertyChanged("Grp_verpla_grpv");
            }
        }
        #endregion
        #region Grp_xmlpla_grpv: XML Version plantilla
        private String _grp_xmlpla_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Version plantilla</para>
        /// <para>NOMBRE: grp_xmlpla_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla
        /// </para>
        /// </summary>
        public String Grp_xmlpla_grpv
        {
            get { return _grp_xmlpla_grpv; }
            set
            {
                if (_grp_xmlpla_grpv == value) return;
                _grp_xmlpla_grpv = value;
                OnPropertyChanged("Grp_xmlpla_grpv");
            }
        }
        #endregion
        #region Grp_xmlplb_grpv: XML Plantilla parte 2
        private String _grp_xmlplb_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 2</para>
        /// <para>NOMBRE: grp_xmlplb_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 2
        /// </para>
        /// </summary>
        public String Grp_xmlplb_grpv
        {
            get { return _grp_xmlplb_grpv; }
            set
            {
                if (_grp_xmlplb_grpv == value) return;
                _grp_xmlplb_grpv = value;
                OnPropertyChanged("Grp_xmlplb_grpv");
            }
        }
        #endregion
        #region Grp_xmlplc_grpv: XML Plantilla parte 3
        private String _grp_xmlplc_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 3</para>
        /// <para>NOMBRE: grp_xmlplc_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 3
        /// </para>
        /// </summary>
        public String Grp_xmlplc_grpv
        {
            get { return _grp_xmlplc_grpv; }
            set
            {
                if (_grp_xmlplc_grpv == value) return;
                _grp_xmlplc_grpv = value;
                OnPropertyChanged("Grp_xmlplc_grpv");
            }
        }
        #endregion
        #region Grp_xmlpld_grpv: XML Plantilla parte 4
        private String _grp_xmlpld_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 4</para>
        /// <para>NOMBRE: grp_xmlpld_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 4
        /// </para>
        /// </summary>
        public String Grp_xmlpld_grpv
        {
            get { return _grp_xmlpld_grpv; }
            set
            {
                if (_grp_xmlpld_grpv == value) return;
                _grp_xmlpld_grpv = value;
                OnPropertyChanged("Grp_xmlpld_grpv");
            }
        }
        #endregion
        #region Grp_fcodig_grpv: Codigo fuente
        private String _grp_fcodig_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Codigo fuente</para>
        /// <para>NOMBRE: grp_fcodig_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION: Codigo fuente para gestion en formatos diseñados </para>
        /// </summary>
        public String Grp_fcodig_grpv
        {
            get { return _grp_fcodig_grpv; }
            set
            {
                if (_grp_fcodig_grpv == value) return;
                _grp_fcodig_grpv = value;
                OnPropertyChanged("Grp_fcodig_grpv");
            }
        }
        #endregion
        #region Grp_numver_grpv: Numero Version plantilla
        private int _grp_numver_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Numero Version plantilla</para>
        /// <para>NOMBRE: grp_numver_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero (en formato numerico) de la Version plantilla para
        /// organizar en consultas ejemplo: 10,11,12…
        /// </para>
        /// </summary>
        public int Grp_numver_grpv
        {
            get { return _grp_numver_grpv; }
            set
            {
                if (_grp_numver_grpv == value) return;
                _grp_numver_grpv = value;
                OnPropertyChanged("Grp_numver_grpv");
            }
        }
        #endregion
        #region Grp_hojalt_grpv: Alto Hoja
        private int _grp_hojalt_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Alto Hoja</para>
        /// <para>NOMBRE: grp_hojalt_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Alto hojas de la plantilla
        /// </para>
        /// </summary>
        public int Grp_hojalt_grpv
        {
            get { return _grp_hojalt_grpv; }
            set
            {
                if (_grp_hojalt_grpv == value) return;
                _grp_hojalt_grpv = value;
                OnPropertyChanged("Grp_hojalt_grpv");
            }
        }
        #endregion
        #region Grp_hojanc_grpv: Ancho Hoja
        private int _grp_hojanc_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Ancho Hoja</para>
        /// <para>NOMBRE: grp_hojanc_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Ancho Hojas de la plantilla
        /// </para>
        /// </summary>
        public int Grp_hojanc_grpv
        {
            get { return _grp_hojanc_grpv; }
            set
            {
                if (_grp_hojanc_grpv == value) return;
                _grp_hojanc_grpv = value;
                OnPropertyChanged("Grp_hojanc_grpv");
            }
        }
        #endregion
        #region Grp_marver_grpv: Margen vertical
        private int _grp_marver_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen vertical</para>
        /// <para>NOMBRE: grp_marver_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Margen vertical de la plantilla
        /// </para>
        /// </summary>
        public int Grp_marver_grpv
        {
            get { return _grp_marver_grpv; }
            set
            {
                if (_grp_marver_grpv == value) return;
                _grp_marver_grpv = value;
                OnPropertyChanged("Grp_marver_grpv");
            }
        }
        #endregion
        #region Grp_marhor_grpv: Margen Horizontal
        private int _grp_marhor_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen Horizontal</para>
        /// <para>NOMBRE: grp_marhor_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Margen horizontal de la plantilla
        /// </para>
        /// </summary>
        public int Grp_marhor_grpv
        {
            get { return _grp_marhor_grpv; }
            set
            {
                if (_grp_marhor_grpv == value) return;
                _grp_marhor_grpv = value;
                OnPropertyChanged("Grp_marhor_grpv");
            }
        }
        #endregion
        #region Grp_epapel_grpv: Estilo tamaño del papel
        private String _grp_epapel_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Estilo tamaño del papel</para>
        /// <para>NOMBRE: grp_epapel_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Nombre de la presentacion estilo del papel: OFICIO, CARTA,
        /// MEDIACARTA, ETIQUETA,PERSONALIZADO
        /// </para>
        /// </summary>
        public String Grp_epapel_grpv
        {
            get { return _grp_epapel_grpv; }
            set
            {
                if (_grp_epapel_grpv == value) return;
                _grp_epapel_grpv = value;
                OnPropertyChanged("Grp_epapel_grpv");
            }
        }
        #endregion
        #region Grp_estilo_grpv: Tema presenenacion Skin
        private String _grp_estilo_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Tema presenenacion Skin</para>
        /// <para>NOMBRE: grp_estilo_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Referenicia al estilo o tema del diseño  y presentacion de
        /// plantilla (para el futuro)
        /// </para>
        /// </summary>
        public String Grp_estilo_grpv
        {
            get { return _grp_estilo_grpv; }
            set
            {
                if (_grp_estilo_grpv == value) return;
                _grp_estilo_grpv = value;
                OnPropertyChanged("Grp_estilo_grpv");
            }
        }
        #endregion
        #region Grp_decima_grpv: Separador decimal
        private String _grp_decima_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Separador decimal</para>
        /// <para>NOMBRE: grp_decima_grpv (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Carácter separador decimal utilizado en el diseño de la plantilla.
        /// </para>
        /// </summary>
        public String Grp_decima_grpv
        {
            get { return _grp_decima_grpv; }
            set
            {
                if (_grp_decima_grpv == value) return;
                _grp_decima_grpv = value;
                OnPropertyChanged("Grp_decima_grpv");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static bool flgAddRegistro(VersionPlantilla tobjModelo)
        {
            // se asume que el nuevo codigo de la version lo realiza el vistamodelo
            var llgReturn = false;
            using (_context = new DbAplicacion())
            {
                llgReturn = true;
                var lobjRegistro = new EFgrpmaeversplant
                {
                    #region cargar Registro
                    grp_idepla_grpv = tobjModelo.Grp_idepla_grpv,
                    grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                    grp_verpla_grpv = tobjModelo.Grp_verpla_grpv,
                    grp_xmlpla_grpv = tobjModelo.Grp_xmlpla_grpv,
                    grp_xmlplb_grpv = tobjModelo.Grp_xmlplb_grpv,
                    grp_xmlplc_grpv = tobjModelo.Grp_xmlplc_grpv,
                    grp_xmlpld_grpv = tobjModelo.Grp_xmlpld_grpv,
                    grp_fcodig_grpv = tobjModelo.Grp_fcodig_grpv,
                    grp_numver_grpv = tobjModelo.Grp_numver_grpv,
                    grp_hojalt_grpv = tobjModelo.Grp_hojalt_grpv,
                    grp_hojanc_grpv = tobjModelo.Grp_hojanc_grpv,
                    grp_marver_grpv = tobjModelo.Grp_marver_grpv,
                    grp_marhor_grpv = tobjModelo.Grp_marhor_grpv,
                    grp_epapel_grpv = tobjModelo.Grp_epapel_grpv,
                    grp_estilo_grpv = tobjModelo.Grp_estilo_grpv,
                    grp_decima_grpv = tobjModelo.Grp_decima_grpv,
                    sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                    #endregion
                };
                _context.AddToGrpmaeversplant(lobjRegistro);
                _context.SaveChanges();
            }
            return llgReturn;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(VersionPlantilla tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tobjModelo.Grp_idepla_grpv);
                try
                {
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.grp_idepla_grpv = tobjModelo.Grp_idepla_grpv;
                        lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                        lobjRegistro.grp_verpla_grpv = tobjModelo.Grp_verpla_grpv;
                        lobjRegistro.grp_xmlpla_grpv = tobjModelo.Grp_xmlpla_grpv;
                        lobjRegistro.grp_xmlplb_grpv = tobjModelo.Grp_xmlplb_grpv;
                        lobjRegistro.grp_xmlplc_grpv = tobjModelo.Grp_xmlplc_grpv;
                        lobjRegistro.grp_xmlpld_grpv = tobjModelo.Grp_xmlpld_grpv;
                        lobjRegistro.grp_fcodig_grpv = tobjModelo.Grp_fcodig_grpv;
                        lobjRegistro.grp_numver_grpv = (int)tobjModelo.Grp_numver_grpv;
                        lobjRegistro.grp_hojalt_grpv = (int)tobjModelo.Grp_hojalt_grpv;
                        lobjRegistro.grp_hojanc_grpv = (int)tobjModelo.Grp_hojanc_grpv;
                        lobjRegistro.grp_marver_grpv = (int)tobjModelo.Grp_marver_grpv;
                        lobjRegistro.grp_marhor_grpv = (int)tobjModelo.Grp_marhor_grpv;
                        lobjRegistro.grp_epapel_grpv = tobjModelo.Grp_epapel_grpv;
                        lobjRegistro.grp_estilo_grpv = tobjModelo.Grp_estilo_grpv;
                        lobjRegistro.grp_decima_grpv = tobjModelo.Grp_decima_grpv;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: ModeloPlantilla.fcvActualizar");
                }

            }

        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar GRPMAEVERSPLANT: Logica
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TITULO: Maestro versiones de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de las diferentes versiones de  plantillas diseñadas
        /// en el gestor, por cada modelo de plantilla solo una estara
        /// en uso a la vez
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpmaeversplant(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeversplant.FirstOrDefault(p => p.grp_idepla_grpv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<VersionPlantilla> flsBuscarVersionPlantilla(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from grpmaeversplant in _context.Grpmaeversplant
                                      join grpmaeplantilla in _context.Grpmaeplantilla on grpmaeversplant.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sisestadoregist in _context.Sisestadoregist on grpmaeversplant.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      select new VersionPlantilla
                                      {
                                          #region Listar
                                          Grp_idepla_grpv = grpmaeversplant.grp_idepla_grpv,
                                          Grp_idepla_grpl = grpmaeversplant.grp_idepla_grpl,
                                          Grp_verpla_grpv = grpmaeversplant.grp_verpla_grpv,
                                          Grp_xmlpla_grpv = grpmaeversplant.grp_xmlpla_grpv,
                                          Grp_xmlplb_grpv = grpmaeversplant.grp_xmlplb_grpv,
                                          Grp_xmlplc_grpv = grpmaeversplant.grp_xmlplc_grpv,
                                          Grp_xmlpld_grpv = grpmaeversplant.grp_xmlpld_grpv,
                                          Grp_fcodig_grpv = grpmaeversplant.grp_fcodig_grpv,
                                          Grp_numver_grpv = (int)grpmaeversplant.grp_numver_grpv,
                                          Grp_hojalt_grpv = (int)grpmaeversplant.grp_hojalt_grpv,
                                          Grp_hojanc_grpv = (int)grpmaeversplant.grp_hojanc_grpv,
                                          Grp_marver_grpv = (int)grpmaeversplant.grp_marver_grpv,
                                          Grp_marhor_grpv = (int)grpmaeversplant.grp_marhor_grpv,
                                          Grp_epapel_grpv = grpmaeversplant.grp_epapel_grpv,
                                          Grp_estilo_grpv = grpmaeversplant.grp_estilo_grpv,
                                          Grp_decima_grpv = grpmaeversplant.grp_decima_grpv,
                                          Sis_estreg_esrg = grpmaeversplant.sis_estreg_esrg,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from grpmaeversplant in _context.Grpmaeversplant
                                      join grpmaeplantilla in _context.Grpmaeplantilla on grpmaeversplant.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sisestadoregist in _context.Sisestadoregist on grpmaeversplant.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      where grpmaeversplant.grp_idepla_grpv == tcrBuscar
                                      select new VersionPlantilla
                                      {
                                          #region Listar
                                          Grp_idepla_grpv = grpmaeversplant.grp_idepla_grpv,
                                          Grp_idepla_grpl = grpmaeversplant.grp_idepla_grpl,
                                          Grp_verpla_grpv = grpmaeversplant.grp_verpla_grpv,
                                          Grp_xmlpla_grpv = grpmaeversplant.grp_xmlpla_grpv,
                                          Grp_xmlplb_grpv = grpmaeversplant.grp_xmlplb_grpv,
                                          Grp_xmlplc_grpv = grpmaeversplant.grp_xmlplc_grpv,
                                          Grp_xmlpld_grpv = grpmaeversplant.grp_xmlpld_grpv,
                                          Grp_fcodig_grpv = grpmaeversplant.grp_fcodig_grpv,
                                          Grp_numver_grpv = (int)grpmaeversplant.grp_numver_grpv,
                                          Grp_hojalt_grpv = (int)grpmaeversplant.grp_hojalt_grpv,
                                          Grp_hojanc_grpv = (int)grpmaeversplant.grp_hojanc_grpv,
                                          Grp_marver_grpv = (int)grpmaeversplant.grp_marver_grpv,
                                          Grp_marhor_grpv = (int)grpmaeversplant.grp_marhor_grpv,
                                          Grp_epapel_grpv = grpmaeversplant.grp_epapel_grpv,
                                          Grp_estilo_grpv = grpmaeversplant.grp_estilo_grpv,
                                          Grp_decima_grpv = grpmaeversplant.grp_decima_grpv,
                                          Sis_estreg_esrg = grpmaeversplant.sis_estreg_esrg,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Lista de formatos para generar nueva plantilla
    /// </summary>
    public class ModeloFormatos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Grp_idefor_grfp: Código del formato basico
        private String _grp_idefor_grfp;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpformatoplant</para>
        /// <para>CAMPO: Código del formato basico</para>
        /// <para>NOMBRE: grp_idefor_grfp (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único del formato
        /// </para>
        /// </summary>
        public String Grp_idefor_grfp
        {
            get { return _grp_idefor_grfp; }
            set
            {
                if (_grp_idefor_grfp == value) return;
                _grp_idefor_grfp = value;
                OnPropertyChanged("Grp_idefor_grfp");
            }
        }
        #endregion
        #region Grp_desfor_grfp: Nombre formato
        private String _grp_desfor_grfp;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpformatoplant</para>
        /// <para>CAMPO: Nombre formato</para>
        /// <para>NOMBRE: grp_desfor_grfp (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre  o descripcion del nuevo formato al generar plantilla
        /// </para>
        /// </summary>
        public String Grp_desfor_grfp
        {
            get { return _grp_desfor_grfp; }
            set
            {
                if (_grp_desfor_grfp == value) return;
                _grp_desfor_grfp = value;
                OnPropertyChanged("Grp_desfor_grfp");
            }
        }
        #endregion
        #region Grp_hojalt_grpv: Alto Hoja
        private int _grp_hojalt_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Alto Hoja</para>
        /// <para>NOMBRE: grp_hojalt_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Alto hojas de la plantilla
        /// </para>
        /// </summary>
        public int Grp_hojalt_grpv
        {
            get { return _grp_hojalt_grpv; }
            set
            {
                if (_grp_hojalt_grpv == value) return;
                _grp_hojalt_grpv = value;
                OnPropertyChanged("Grp_hojalt_grpv");
            }
        }
        #endregion
        #region Grp_hojanc_grpv: Ancho Hoja
        private int _grp_hojanc_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Ancho Hoja</para>
        /// <para>NOMBRE: grp_hojanc_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Ancho Hojas de la plantilla
        /// </para>
        /// </summary>
        public int Grp_hojanc_grpv
        {
            get { return _grp_hojanc_grpv; }
            set
            {
                if (_grp_hojanc_grpv == value) return;
                _grp_hojanc_grpv = value;
                OnPropertyChanged("Grp_hojanc_grpv");
            }
        }
        #endregion
        #region Grp_marver_grpv: Margen vertical
        private int _grp_marver_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen vertical</para>
        /// <para>NOMBRE: grp_marver_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Margen vertical de la plantilla
        /// </para>
        /// </summary>
        public int Grp_marver_grpv
        {
            get { return _grp_marver_grpv; }
            set
            {
                if (_grp_marver_grpv == value) return;
                _grp_marver_grpv = value;
                OnPropertyChanged("Grp_marver_grpv");
            }
        }
        #endregion
        #region Grp_marhor_grpv: Margen Horizontal
        private int _grp_marhor_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen Horizontal</para>
        /// <para>NOMBRE: grp_marhor_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Margen horizontal de la plantilla
        /// </para>
        /// </summary>
        public int Grp_marhor_grpv
        {
            get { return _grp_marhor_grpv; }
            set
            {
                if (_grp_marhor_grpv == value) return;
                _grp_marhor_grpv = value;
                OnPropertyChanged("Grp_marhor_grpv");
            }
        }
        #endregion
        #region Grp_xmlpla_grpv: XML Version plantilla
        private String _grp_xmlpla_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Version plantilla</para>
        /// <para>NOMBRE: grp_xmlpla_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla
        /// </para>
        /// </summary>
        public String Grp_xmlpla_grpv
        {
            get { return _grp_xmlpla_grpv; }
            set
            {
                if (_grp_xmlpla_grpv == value) return;
                _grp_xmlpla_grpv = value;
                OnPropertyChanged("Grp_xmlpla_grpv");
            }
        }
        #endregion
        #region Grp_idegru_grpg: Grupo plantilla
        private String _grp_idegru_grpg;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Grupo plantilla</para>
        /// <para>NOMBRE: grp_idegru_grpg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigos Grupos de plantillas (GF001 = Formato para Gestion 
        /// medica GF002=Formatos para reportes ...)
        /// </para>
        /// </summary>
        public String Grp_idegru_grpg
        {
            get { return _grp_idegru_grpg; }
            set
            {
                if (_grp_idegru_grpg == value) return;
                _grp_idegru_grpg = value;
                OnPropertyChanged("Grp_idegru_grpg");
            }
        }
        #endregion
        #region Grp_epapel_grpv: Estilo tamaño del papel
        private String _grp_epapel_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Estilo tamaño del papel</para>
        /// <para>NOMBRE: grp_epapel_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la presentacion estilo del papel: OFICIO, CARTA,
        /// MEDIACARTA, ETIQUETA,PERSONALIZADO
        /// </para>
        /// </summary>
        public String Grp_epapel_grpv
        {
            get { return _grp_epapel_grpv; }
            set
            {
                if (_grp_epapel_grpv == value) return;
                _grp_epapel_grpv = value;
                OnPropertyChanged("Grp_epapel_grpv");
            }
        }
        #endregion
        #region Grp_tipfor_grpl: Tipo formato plantilla
        private String _grp_tipfor_grpl;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Tipo formato plantilla</para>
        /// <para>NOMBRE: grp_tipfor_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Tipo formato: PLANTILLA, ETIQUETA, REPORTES  y Otros
        /// </para>
        /// </summary>
        public String Grp_tipfor_grpl
        {
            get { return _grp_tipfor_grpl; }
            set
            {
                if (_grp_tipfor_grpl == value) return;
                _grp_tipfor_grpl = value;
                OnPropertyChanged("Grp_tipfor_grpl");
            }
        }
        #endregion
        #region Grp_estilo_grpv: Tema presenenacion Skin
        private String _grp_estilo_grpv;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Tema presenenacion Skin</para>
        /// <para>NOMBRE: grp_estilo_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Referenicia al estilo o tema del diseño  y presentacion de
        /// plantilla (para el futuro)
        /// </para>
        /// </summary>
        public String Grp_estilo_grpv
        {
            get { return _grp_estilo_grpv; }
            set
            {
                if (_grp_estilo_grpv == value) return;
                _grp_estilo_grpv = value;
                OnPropertyChanged("Grp_estilo_grpv");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #region Grp_desgru_grpg: Descripción grupo
        private String _grp_desgru_grpg;
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Descripción grupo</para>
        /// <para>NOMBRE: grp_desgru_grpg (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción textual  del grupo plantilla
        /// </para>
        /// </summary>
        public String Grp_desgru_grpg
        {
            get { return _grp_desgru_grpg; }
            set
            {
                if (_grp_desgru_grpg == value) return;
                _grp_desgru_grpg = value;
                OnPropertyChanged("Grp_desgru_grpg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloFormatos tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("GRP-GRPFORMATOPLANT", "GRP", "Lista de formatos basicos para nueva plantilla");
            if (!flgBuscarGrpformatoplant(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFgrpformatoplant
                    {
                        #region cargar Registro
                        grp_idefor_grfp = tobjModelo.Grp_idefor_grfp,
                        grp_desfor_grfp = tobjModelo.Grp_desfor_grfp,
                        grp_hojalt_grpv = tobjModelo.Grp_hojalt_grpv,
                        grp_hojanc_grpv = tobjModelo.Grp_hojanc_grpv,
                        grp_marver_grpv = tobjModelo.Grp_marver_grpv,
                        grp_marhor_grpv = tobjModelo.Grp_marhor_grpv,
                        grp_xmlpla_grpv = tobjModelo.Grp_xmlpla_grpv,
                        grp_idegru_grpg = tobjModelo.Grp_idegru_grpg,
                        grp_epapel_grpv = tobjModelo.Grp_epapel_grpv,
                        grp_tipfor_grpl = tobjModelo.Grp_tipfor_grpl,
                        grp_estilo_grpv = tobjModelo.Grp_estilo_grpv,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.grp_idefor_grfp = lcrCodigoGen;
                    _context.AddToGrpformatoplant(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'GRP-GRPFORMATOPLANT': Lista de formatos basicos para nueva plantilla en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloFormatos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tobjModelo.Grp_idefor_grfp);
                if (lobjRegistro != null)
                {
                    lobjRegistro.grp_idefor_grfp = tobjModelo.Grp_idefor_grfp;
                    lobjRegistro.grp_desfor_grfp = tobjModelo.Grp_desfor_grfp;
                    lobjRegistro.grp_hojalt_grpv = (int)tobjModelo.Grp_hojalt_grpv;
                    lobjRegistro.grp_hojanc_grpv = (int)tobjModelo.Grp_hojanc_grpv;
                    lobjRegistro.grp_marver_grpv = (int)tobjModelo.Grp_marver_grpv;
                    lobjRegistro.grp_marhor_grpv = (int)tobjModelo.Grp_marhor_grpv;
                    lobjRegistro.grp_xmlpla_grpv = tobjModelo.Grp_xmlpla_grpv;
                    lobjRegistro.grp_idegru_grpg = tobjModelo.Grp_idegru_grpg;
                    lobjRegistro.grp_epapel_grpv = tobjModelo.Grp_epapel_grpv;
                    lobjRegistro.grp_tipfor_grpl = tobjModelo.Grp_tipfor_grpl;
                    lobjRegistro.grp_estilo_grpv = tobjModelo.Grp_estilo_grpv;
                    lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar GRPFORMATOPLANT: Logica
        /// <summary>
        /// <para>TABLA: grpformatoplant</para>
        /// <para>TITULO: Lista de formatos basicos para nueva plantilla</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// listado de formatos basicos utlizados al momento de crea una
        /// nueva plantilla
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpformatoplant(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpformatoplant.FirstOrDefault(p => p.grp_idefor_grfp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFormatos> flsListaFormatoPlantillas(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from grpformatoplant in _context.Grpformatoplant
                                      join sisestadoregist in _context.Sisestadoregist on grpformatoplant.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      join grpgrupoplantil in _context.Grpgrupoplantil on grpformatoplant.grp_idegru_grpg equals grpgrupoplantil.grp_idegru_grpg into tmgrpgrupoplantil
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      from grpg in tmgrpgrupoplantil.DefaultIfEmpty()
                                      select new ModeloFormatos
                                      {
                                          Grp_idefor_grfp = grpformatoplant.grp_idefor_grfp,
                                          Grp_desfor_grfp = grpformatoplant.grp_desfor_grfp,
                                          Grp_hojalt_grpv = (int)grpformatoplant.grp_hojalt_grpv,
                                          Grp_hojanc_grpv = (int)grpformatoplant.grp_hojanc_grpv,
                                          Grp_marver_grpv = (int)grpformatoplant.grp_marver_grpv,
                                          Grp_marhor_grpv = (int)grpformatoplant.grp_marhor_grpv,
                                          Grp_xmlpla_grpv = grpformatoplant.grp_xmlpla_grpv,
                                          Grp_idegru_grpg = grpformatoplant.grp_idegru_grpg,
                                          Grp_epapel_grpv = grpformatoplant.grp_epapel_grpv,
                                          Grp_tipfor_grpl = grpformatoplant.grp_tipfor_grpl,
                                          Grp_estilo_grpv = grpformatoplant.grp_estilo_grpv,
                                          Sis_estreg_esrg = grpformatoplant.sis_estreg_esrg,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          Grp_desgru_grpg = grpg.grp_desgru_grpg,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from grpformatoplant in _context.Grpformatoplant
                                      join sisestadoregist in _context.Sisestadoregist on grpformatoplant.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      join grpgrupoplantil in _context.Grpgrupoplantil on grpformatoplant.grp_idegru_grpg equals grpgrupoplantil.grp_idegru_grpg into tmgrpgrupoplantil
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      from grpg in tmgrpgrupoplantil.DefaultIfEmpty()
                                      where grpformatoplant.grp_idefor_grfp == tcrBuscar
                                      select new ModeloFormatos
                                      {
                                          Grp_idefor_grfp = grpformatoplant.grp_idefor_grfp,
                                          Grp_desfor_grfp = grpformatoplant.grp_desfor_grfp,
                                          Grp_hojalt_grpv = (int)grpformatoplant.grp_hojalt_grpv,
                                          Grp_hojanc_grpv = (int)grpformatoplant.grp_hojanc_grpv,
                                          Grp_marver_grpv = (int)grpformatoplant.grp_marver_grpv,
                                          Grp_marhor_grpv = (int)grpformatoplant.grp_marhor_grpv,
                                          Grp_xmlpla_grpv = grpformatoplant.grp_xmlpla_grpv,
                                          Grp_idegru_grpg = grpformatoplant.grp_idegru_grpg,
                                          Grp_epapel_grpv = grpformatoplant.grp_epapel_grpv,
                                          Grp_tipfor_grpl = grpformatoplant.grp_tipfor_grpl,
                                          Grp_estilo_grpv = grpformatoplant.grp_estilo_grpv,
                                          Sis_estreg_esrg = grpformatoplant.sis_estreg_esrg,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          Grp_desgru_grpg = grpg.grp_desgru_grpg,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// <para>Maestro de plantillas diseñadas en el gestor, para diferentes propositos:</para> 
    /// <para>Gestion de Historias clinicas, Reportes  y otros.</para> 
    /// </summary>
    public class ModeloPlantilla : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de la plantilla (generado por el sistema)
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Grp_hl7for_grpl: Formato HL7
        private String _grp_hl7for_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Formato HL7</para>
        /// <para>NOMBRE: grp_hl7for_grpl (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del formato HL7 que homologa la plantilla
        /// </para>
        /// </summary>
        public String Grp_hl7for_grpl
        {
            get { return _grp_hl7for_grpl; }
            set
            {
                if (_grp_hl7for_grpl == value) return;
                _grp_hl7for_grpl = value;
                OnPropertyChanged("Grp_hl7for_grpl");
            }
        }
        #endregion
        #region Grp_idegru_grpg: Grupo plantilla
        private String _grp_idegru_grpg;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Grupo plantilla</para>
        /// <para>NOMBRE: grp_idegru_grpg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigos Grupos de plantillas (GF001 = Formato para Gestion 
        /// medica GF002=Formatos para reportes ...)
        /// </para>
        /// </summary>
        public String Grp_idegru_grpg
        {
            get { return _grp_idegru_grpg; }
            set
            {
                if (_grp_idegru_grpg == value) return;
                _grp_idegru_grpg = value;
                OnPropertyChanged("Grp_idegru_grpg");
            }
        }
        #endregion
        #region Grp_tipfor_grpl: Tipo formato plantilla
        private String _grp_tipfor_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Tipo plantilla</para>
        /// <para>NOMBRE: grp_tipfor_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Tipo formato: PLANTILLA, ETIQUETA, REPORTES  y Otros
        /// </para>
        /// </summary>
        public String Grp_tipfor_grpl
        {
            get { return _grp_tipfor_grpl; }
            set
            {
                if (_grp_tipfor_grpl == value) return;
                _grp_tipfor_grpl = value;
                OnPropertyChanged("Grp_tipfor_grpl");
            }
        }
        #endregion
        #region Grc_iderec_grcm: Codigo imagen icono
        private String _grc_iderec_grcm;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grcmaesrecursos</para>
        /// <para>CAMPO: Codigo imagen icono</para>
        /// <para>NOMBRE: grc_iderec_grcm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo recurso imagen en la galeria de recursos, que representa
        /// el icono de la plantilla
        /// </para>
        /// </summary>
        public String Grc_iderec_grcm
        {
            get { return _grc_iderec_grcm; }
            set
            {
                if (_grc_iderec_grcm == value) return;
                _grc_iderec_grcm = value;
                OnPropertyChanged("Grc_iderec_grcm");
            }
        }
        #endregion
        #region Grp_conver_grpl: Contador version plantilla
        private int _grp_conver_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Contador version plantilla</para>
        /// <para>NOMBRE: grp_conver_grpl (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Contador para generar versiones plantilla
        /// </para>
        /// </summary>
        public int Grp_conver_grpl
        {
            get { return _grp_conver_grpl; }
            set
            {
                if (_grp_conver_grpl == value) return;
                _grp_conver_grpl = value;
                OnPropertyChanged("Grp_conver_grpl");
            }
        }
        #endregion
        #region Grp_conobj_grpl: Contador generar objetos
        private int _grp_conobj_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Contador generar objetos</para>
        /// <para>NOMBRE: grp_conobj_grpl (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Contador para generar Nombres unicos de los objetos en la plantilla
        /// </para>
        /// </summary>
        public int Grp_conobj_grpl
        {
            get { return _grp_conobj_grpl; }
            set
            {
                if (_grp_conobj_grpl == value) return;
                _grp_conobj_grpl = value;
                OnPropertyChanged("Grp_conobj_grpl");
            }
        }
        #endregion
        #region Grp_prefij_grpl: Prefijos para nombres obj
        private String _grp_prefij_grpl;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Prefijos para nombres obj</para>
        /// <para>NOMBRE: grp_prefij_grpl (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Prefijo para  generar Nombres unicos de los objetos en la plantilla
        /// ejemplo: EX, FR, OBJ …
        /// </para>
        /// </summary>
        public String Grp_prefij_grpl
        {
            get { return _grp_prefij_grpl; }
            set
            {
                if (_grp_prefij_grpl == value) return;
                _grp_prefij_grpl = value;
                OnPropertyChanged("Grp_prefij_grpl");
            }
        }
        #endregion
        #region Grp_idepla_grpv: Codigo version en uso
        private String _grp_idepla_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Codigo version en uso</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo version formato que esta en uso por defecto (util
        /// para formatos de Historia clinica que se modifican con el tiempo)
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv
        {
            get { return _grp_idepla_grpv; }
            set
            {
                if (_grp_idepla_grpv == value) return;
                _grp_idepla_grpv = value;
                OnPropertyChanged("Grp_idepla_grpv");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Grp_xmlpla_grpv: XML Version plantilla en uso
        private String _grp_xmlpla_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Version plantilla </para>
        /// <para>NOMBRE: grp_xmlpla_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo XML versión formato en uso por defecto en la plantilla
        /// </para>
        /// </summary>
        public String Grp_xmlpla_grpv
        {
            get { return _grp_xmlpla_grpv; }
            set
            {
                if (_grp_xmlpla_grpv == value) return;
                _grp_xmlpla_grpv = value;
                OnPropertyChanged("Grp_xmlpla_grpv");
            }
        }
        #endregion
        #region Grp_xmlplb_grpv: XML Plantilla parte 2
        private String _grp_xmlplb_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 2</para>
        /// <para>NOMBRE: grp_xmlplb_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 2
        /// </para>
        /// </summary>
        public String Grp_xmlplb_grpv
        {
            get { return _grp_xmlplb_grpv; }
            set
            {
                if (_grp_xmlplb_grpv == value) return;
                _grp_xmlplb_grpv = value;
                OnPropertyChanged("Grp_xmlplb_grpv");
            }
        }
        #endregion
        #region Grp_xmlplc_grpv: XML Plantilla parte 3
        private String _grp_xmlplc_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 3</para>
        /// <para>NOMBRE: grp_xmlplc_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 3
        /// </para>
        /// </summary>
        public String Grp_xmlplc_grpv
        {
            get { return _grp_xmlplc_grpv; }
            set
            {
                if (_grp_xmlplc_grpv == value) return;
                _grp_xmlplc_grpv = value;
                OnPropertyChanged("Grp_xmlplc_grpv");
            }
        }
        #endregion
        #region Grp_xmlpld_grpv: XML Plantilla parte 4
        private String _grp_xmlpld_grpv;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 4</para>
        /// <para>NOMBRE: grp_xmlpld_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 4
        /// </para>
        /// </summary>
        public String Grp_xmlpld_grpv
        {
            get { return _grp_xmlpld_grpv; }
            set
            {
                if (_grp_xmlpld_grpv == value) return;
                _grp_xmlpld_grpv = value;
                OnPropertyChanged("Grp_xmlpld_grpv");
            }
        }
        #endregion
        #region Grp_desgru_grpg: Descripción grupo
        private String _grp_desgru_grpg;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Descripción grupo</para>
        /// <para>NOMBRE: grp_desgru_grpg (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción textual  del grupo plantilla
        /// </para>
        /// </summary>
        public String Grp_desgru_grpg
        {
            get { return _grp_desgru_grpg; }
            set
            {
                if (_grp_desgru_grpg == value) return;
                _grp_desgru_grpg = value;
                OnPropertyChanged("Grp_desgru_grpg");
            }
        }
        #endregion
        #region Grc_desrec_grcm: Descripción recurso
        private String _grc_desrec_grcm;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grcmaesrecursos</para>
        /// <para>CAMPO: Descripción recurso</para>
        /// <para>NOMBRE: grc_desrec_grcm (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Titulo o descripción textual corta  del recurso  imagen, video,
        /// audio  capturada
        /// </para>
        /// </summary>
        public String Grc_desrec_grcm
        {
            get { return _grc_desrec_grcm; }
            set
            {
                if (_grc_desrec_grcm == value) return;
                _grc_desrec_grcm = value;
                OnPropertyChanged("Grc_desrec_grcm");
            }
        }
        #endregion
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloPlantilla tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("GRP-GRPMAEPLANTILLA", "GRP", "Maestro de plantillas");
            if (!flgBuscarGrpmaeplantilla(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFgrpmaeplantilla
                    {
                        #region cargar Registro
                        grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                        grp_despla_grpl = tobjModelo.Grp_despla_grpl,
                        grp_hl7for_grpl = tobjModelo.Grp_hl7for_grpl,
                        grp_idegru_grpg = tobjModelo.Grp_idegru_grpg,
                        grp_tipfor_grpl = tobjModelo.Grp_tipfor_grpl,
                        grc_iderec_grcm = tobjModelo.Grc_iderec_grcm,
                        grp_conver_grpl = tobjModelo.Grp_conver_grpl,
                        grp_conobj_grpl = tobjModelo.Grp_conobj_grpl,
                        grp_prefij_grpl = tobjModelo.Grp_prefij_grpl,
                        grp_idepla_grpv = tobjModelo.Grp_idepla_grpv,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.grp_idepla_grpl = lcrCodigoGen;
                    _context.AddToGrpmaeplantilla(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'GRP-GRPMAEPLANTILLA': Maestro de plantillas en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        /// <summary>
        /// Actualizar maestro plantillas (tabla grpmaeplantilla)
        /// </summary>
        public static void fcvActualizar(ModeloPlantilla tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                try
                {
                    var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tobjModelo.Grp_idepla_grpl);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                        lobjRegistro.grp_despla_grpl = tobjModelo.Grp_despla_grpl;
                        lobjRegistro.grp_hl7for_grpl = tobjModelo.Grp_hl7for_grpl;
                        lobjRegistro.grp_idegru_grpg = tobjModelo.Grp_idegru_grpg;
                        lobjRegistro.grp_tipfor_grpl = tobjModelo.Grp_tipfor_grpl;
                        lobjRegistro.grc_iderec_grcm = tobjModelo.Grc_iderec_grcm;
                        lobjRegistro.grp_conver_grpl = (int)tobjModelo.Grp_conver_grpl;
                        lobjRegistro.grp_conobj_grpl = (int)tobjModelo.Grp_conobj_grpl;
                        lobjRegistro.grp_prefij_grpl = tobjModelo.Grp_prefij_grpl;
                        lobjRegistro.grp_idepla_grpv = tobjModelo.Grp_idepla_grpv;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: ModeloPlantilla.fcvActualizar");
                }

            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar GRPMAEPLANTILLA: Logica
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TITULO: Maestro de plantillas</para>
        /// <para>MODULO: GRP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas diseñadas en el gestor, para diferentes
        /// propositos: Gestion de Historias clinicas, Reportes  y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarGrpmaeplantilla(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Grpmaeplantilla.FirstOrDefault(p => p.grp_idepla_grpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// consultar maestro plantillas (tabla grpmaeplantilla) y tambien trae xml de plantilla en uso
        /// </summary>
        public static List<ModeloPlantilla> flsListaGrpmaeplantilla(string tcrBuscar)
        {
            List<ModeloPlantilla> tmpConsulta = null;
            IQueryable<ModeloPlantilla> lobTmp = null;

            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    lobTmp = from grpmaeplantilla in _context.Grpmaeplantilla
                                      join grpgrupoplantil in _context.Grpgrupoplantil on grpmaeplantilla.grp_idegru_grpg equals grpgrupoplantil.grp_idegru_grpg into tmgrpgrupoplantil
                                      join grcmaesrecursos in _context.Grcmaesrecursos on grpmaeplantilla.grc_iderec_grcm equals grcmaesrecursos.grc_iderec_grcm into tmgrcmaesrecursos
                                      join grpmaeversplant in _context.Grpmaeversplant on grpmaeplantilla.grp_idepla_grpv equals grpmaeversplant.grp_idepla_grpv into tmgrpmaeversplant
                                      join sisestadoregist in _context.Sisestadoregist on grpmaeplantilla.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from grpg in tmgrpgrupoplantil.DefaultIfEmpty()
                                      from grcm in tmgrcmaesrecursos.DefaultIfEmpty()
                                      from grpv in tmgrpmaeversplant.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      select new ModeloPlantilla
                                      {
                                          #region Listar
                                          Grp_idepla_grpl = grpmaeplantilla.grp_idepla_grpl,
                                          Grp_despla_grpl = grpmaeplantilla.grp_despla_grpl,
                                          Grp_hl7for_grpl = grpmaeplantilla.grp_hl7for_grpl,
                                          Grp_idegru_grpg = grpmaeplantilla.grp_idegru_grpg,
                                          Grp_tipfor_grpl = grpmaeplantilla.grp_tipfor_grpl,
                                          Grc_iderec_grcm = grpmaeplantilla.grc_iderec_grcm,
                                          Grp_conver_grpl = (int)grpmaeplantilla.grp_conver_grpl,
                                          Grp_conobj_grpl = (int)grpmaeplantilla.grp_conobj_grpl,
                                          Grp_prefij_grpl = grpmaeplantilla.grp_prefij_grpl,
                                          Grp_idepla_grpv = grpmaeplantilla.grp_idepla_grpv,
                                          Sis_estreg_esrg = grpmaeplantilla.sis_estreg_esrg,
                                          Grp_xmlpla_grpv = grpv.grp_xmlpla_grpv,
                                          Grp_xmlplb_grpv = grpv.grp_xmlplb_grpv,
                                          Grp_xmlplc_grpv = grpv.grp_xmlplc_grpv,
                                          Grp_xmlpld_grpv = grpv.grp_xmlpld_grpv,
                                          Grp_desgru_grpg = grpg.grp_desgru_grpg,
                                          Grc_desrec_grcm = grcm.grc_desrec_grcm,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          #endregion
                                      };
                }
                else
                {
                    lobTmp = from grpmaeplantilla in _context.Grpmaeplantilla
                                      join grpgrupoplantil in _context.Grpgrupoplantil on grpmaeplantilla.grp_idegru_grpg equals grpgrupoplantil.grp_idegru_grpg into tmgrpgrupoplantil
                                      join grcmaesrecursos in _context.Grcmaesrecursos on grpmaeplantilla.grc_iderec_grcm equals grcmaesrecursos.grc_iderec_grcm into tmgrcmaesrecursos
                                      join grpmaeversplant in _context.Grpmaeversplant on grpmaeplantilla.grp_idepla_grpv equals grpmaeversplant.grp_idepla_grpv into tmgrpmaeversplant
                                      join sisestadoregist in _context.Sisestadoregist on grpmaeplantilla.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from grpg in tmgrpgrupoplantil.DefaultIfEmpty()
                                      from grcm in tmgrcmaesrecursos.DefaultIfEmpty()
                                      from grpv in tmgrpmaeversplant.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      where grpmaeplantilla.grp_idepla_grpl == tcrBuscar
                                      select new ModeloPlantilla
                                      {
                                          #region Listar
                                          Grp_idepla_grpl = grpmaeplantilla.grp_idepla_grpl,
                                          Grp_despla_grpl = grpmaeplantilla.grp_despla_grpl,
                                          Grp_hl7for_grpl = grpmaeplantilla.grp_hl7for_grpl,
                                          Grp_idegru_grpg = grpmaeplantilla.grp_idegru_grpg,
                                          Grp_tipfor_grpl = grpmaeplantilla.grp_tipfor_grpl,
                                          Grc_iderec_grcm = grpmaeplantilla.grc_iderec_grcm,
                                          Grp_conver_grpl = (int)grpmaeplantilla.grp_conver_grpl,
                                          Grp_conobj_grpl = (int)grpmaeplantilla.grp_conobj_grpl,
                                          Grp_prefij_grpl = grpmaeplantilla.grp_prefij_grpl,
                                          Grp_idepla_grpv = grpmaeplantilla.grp_idepla_grpv,
                                          Sis_estreg_esrg = grpmaeplantilla.sis_estreg_esrg,
                                          Grp_xmlpla_grpv = grpv.grp_xmlpla_grpv,
                                          Grp_xmlplb_grpv = grpv.grp_xmlplb_grpv,
                                          Grp_xmlplc_grpv = grpv.grp_xmlplc_grpv,
                                          Grp_xmlpld_grpv = grpv.grp_xmlpld_grpv,
                                          Grp_desgru_grpg = grpg.grp_desgru_grpg,
                                          Grc_desrec_grcm = grcm.grc_desrec_grcm,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                          #endregion
                                      };
                }

                // Concatenar todo
                if (lobTmp != null)
                {
                    tmpConsulta = lobTmp.ToList();
                    foreach (var lobReg in tmpConsulta)
                    {
                        lobReg.Grp_xmlpla_grpv = lobReg.Grp_xmlplb_grpv != null ? lobReg.Grp_xmlpla_grpv + lobReg.Grp_xmlplb_grpv : lobReg.Grp_xmlpla_grpv;
                        lobReg.Grp_xmlpla_grpv = lobReg.Grp_xmlplc_grpv != null ? lobReg.Grp_xmlpla_grpv + lobReg.Grp_xmlplc_grpv : lobReg.Grp_xmlpla_grpv;
                        lobReg.Grp_xmlpla_grpv = lobReg.Grp_xmlpld_grpv != null ? lobReg.Grp_xmlpla_grpv + lobReg.Grp_xmlpld_grpv : lobReg.Grp_xmlpla_grpv;
                    }
                }
            }
            return tmpConsulta;
        }
        #endregion
        #endregion
    }
}

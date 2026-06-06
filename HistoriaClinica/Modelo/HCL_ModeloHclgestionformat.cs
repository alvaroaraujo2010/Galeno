//- MARMOTA-GENCODE: VERSION 2.0 - 15/01/2018 06:29:43 PM
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

namespace HistoriasClinicas.Modelo
{
    #region Modelo Maestro Gestion Formato
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclformatvistma
    /// </summary>
    public class ModeloHclgestionformat : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_codreg_hcra: Codigo grupo actividad
        private String _hcl_codreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcra
        {
            get { return _hcl_codreg_hcra; }
            set
            {
                if (_hcl_codreg_hcra == value) return;
                _hcl_codreg_hcra = value;
                OnPropertyChanged("Hcl_codreg_hcra");
            }
        }
        #endregion
        #region Hcl_desgru_hcra: Nombre grupo actividad
        private String _hcl_desgru_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcra
        {
            get { return _hcl_desgru_hcra; }
            set
            {
                if (_hcl_desgru_hcra == value) return;
                _hcl_desgru_hcra = value;
                OnPropertyChanged("Hcl_desgru_hcra");
            }
        }
        #endregion
        #region Hcl_tipvis_hcra: Mostrar según admision
        private String _hcl_tipvis_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Mostrar según admision</para>
        /// <para>NOMBRE: hcl_tipvis_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Saber si se muestra el grupo según el tipo de registro de atencion
        /// activo: 1= Solo en pacientes admitidos 2=Solo en Pacientes
        /// ambulatoria 3= Ambos casos
        /// </para>
        /// </summary>
        public String Hcl_tipvis_hcra
        {
            get { return _hcl_tipvis_hcra; }
            set
            {
                if (_hcl_tipvis_hcra == value) return;
                _hcl_tipvis_hcra = value;
                OnPropertyChanged("Hcl_tipvis_hcra");
            }
        }
        #endregion
        #region Hcl_ordvis_hcra: Orden visualizacion
        private int _hcl_ordvis_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: hcl_ordvis_hcra (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcra
        {
            get { return _hcl_ordvis_hcra; }
            set
            {
                if (_hcl_ordvis_hcra == value) return;
                _hcl_ordvis_hcra = value;
                OnPropertyChanged("Hcl_ordvis_hcra");
            }
        }
        #endregion
        #region Hcl_imagen_hcra: Imagen (jpg)
        private String _hcl_imagen_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcra (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nombre de la imagen que representa el grupo
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcra
        {
            get { return _hcl_imagen_hcra; }
            set
            {
                if (_hcl_imagen_hcra == value) return;
                _hcl_imagen_hcra = value;
                OnPropertyChanged("Hcl_imagen_hcra");
            }
        }
        #endregion
        #region Hcl_conreg_hcra: Contador items
        private int _hcl_conreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: hcl_conreg_hcra (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int Hcl_conreg_hcra
        {
            get { return _hcl_conreg_hcra; }
            set
            {
                if (_hcl_conreg_hcra == value) return;
                _hcl_conreg_hcra = value;
                OnPropertyChanged("Hcl_conreg_hcra");
            }
        }
        #endregion
        #region Hcl_estreg_hcra: Estado registro
        private String _hcl_estreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: hcl_estreg_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_estreg_hcra
        {
            get { return _hcl_estreg_hcra; }
            set
            {
                if (_hcl_estreg_hcra == value) return;
                _hcl_estreg_hcra = value;
                OnPropertyChanged("Hcl_estreg_hcra");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHclgestionformat tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-GESTION-FORMATOS", "HCL", "Codigo grupo actividad para vista captura Historia clinica");
            try
            {
                if (!flgBuscarHclformatvistma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclformatvistma
                        {
                            #region cargar Registro
                            hcl_codreg_hcra = tobjModelo.Hcl_codreg_hcra,
                            hcl_desgru_hcra = tobjModelo.Hcl_desgru_hcra,
                            hcl_tipvis_hcra = tobjModelo.Hcl_tipvis_hcra,
                            hcl_ordvis_hcra = tobjModelo.Hcl_ordvis_hcra,
                            hcl_imagen_hcra = tobjModelo.Hcl_imagen_hcra,
                            //hcl_conreg_hcra = tobjModelo.Hcl_conreg_hcra,
                            hcl_estreg_hcra = tobjModelo.Hcl_estreg_hcra,
                            #endregion
                        };
                        lobjRegistro.hcl_codreg_hcra = lcrCodigoGen;
                        _context.AddToHclformatvistma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-GESTION-FORMATOS': Codigo grupo actividad para vista captura Historia clinica en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloHclgestionformat tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tobjModelo.Hcl_codreg_hcra);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_codreg_hcra = tobjModelo.Hcl_codreg_hcra;
                        lobjRegistro.hcl_desgru_hcra = tobjModelo.Hcl_desgru_hcra;
                        lobjRegistro.hcl_tipvis_hcra = tobjModelo.Hcl_tipvis_hcra;
                        lobjRegistro.hcl_ordvis_hcra = (int)tobjModelo.Hcl_ordvis_hcra;
                        lobjRegistro.hcl_imagen_hcra = tobjModelo.Hcl_imagen_hcra;
                        lobjRegistro.hcl_conreg_hcra = (int)tobjModelo.Hcl_conreg_hcra;
                        lobjRegistro.hcl_estreg_hcra = tobjModelo.Hcl_estreg_hcra;
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
                    var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tcrCodigo);
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
        #region Buscar HCLFORMATVISTMA: Logica
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TITULO: Grupo vista actividades medicas  en captura Historias clinic</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos formatos de actividad o servicios para organización
        /// en vista captura historias clinicas (capa Propiedades) y agrupados
        /// según funcionalidad de cada formato y perfil de usuario
        /// </para>
        /// </summary>
        public static bool flgBuscarHclformatvistma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclgestionformat> flsListaHclformatvistma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclformatvistma in _context.Hclformatvistma
                                      select new ModeloHclgestionformat
                                      {
                                          #region Datos
                                          Hcl_codreg_hcra = hclformatvistma.hcl_codreg_hcra,
                                          Hcl_desgru_hcra = hclformatvistma.hcl_desgru_hcra,
                                          Hcl_tipvis_hcra = hclformatvistma.hcl_tipvis_hcra,
                                          Hcl_ordvis_hcra = (int)hclformatvistma.hcl_ordvis_hcra,
                                          Hcl_imagen_hcra = hclformatvistma.hcl_imagen_hcra,
                                          //Hcl_conreg_hcra = (int)hclformatvistma.hcl_conreg_hcra,
                                          Hcl_estreg_hcra = hclformatvistma.hcl_estreg_hcra,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclformatvistma in _context.Hclformatvistma
                                      where hclformatvistma.hcl_codreg_hcra.Contains(tcrBuscar) || hclformatvistma.hcl_desgru_hcra.Contains(tcrBuscar)
                                      select new ModeloHclgestionformat
                                      {
                                          #region Datos
                                          Hcl_codreg_hcra = hclformatvistma.hcl_codreg_hcra,
                                          Hcl_desgru_hcra = hclformatvistma.hcl_desgru_hcra,
                                          Hcl_tipvis_hcra = hclformatvistma.hcl_tipvis_hcra,
                                          Hcl_ordvis_hcra = (int)hclformatvistma.hcl_ordvis_hcra,
                                          Hcl_imagen_hcra = hclformatvistma.hcl_imagen_hcra,
                                          Hcl_conreg_hcra = (int)hclformatvistma.hcl_conreg_hcra,
                                          Hcl_estreg_hcra = hclformatvistma.hcl_estreg_hcra,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Gestion Formato
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hcltiporegactiv
    /// </summary>
    public class ModeloHclDetallgestionformat : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_secreg_hcca: Codigo registro
        private String _hcl_secreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: hcl_secreg_hcca (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial registro en la tabla (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public String Hcl_secreg_hcca
        {
            get { return _hcl_secreg_hcca; }
            set
            {
                if (_hcl_secreg_hcca == value) return;
                _hcl_secreg_hcca = value;
                OnPropertyChanged("Hcl_secreg_hcca");
            }
        }
        #endregion
        #region Hcl_codreg_hcra: Codigo grupo actividad
        private String _hcl_codreg_hcra;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcra
        {
            get { return _hcl_codreg_hcra; }
            set
            {
                if (_hcl_codreg_hcra == value) return;
                _hcl_codreg_hcra = value;
                OnPropertyChanged("Hcl_codreg_hcra");
            }
        }
        #endregion
        #region Hcl_codreg_hcca: Tipo registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcca
        {
            get { return _hcl_codreg_hcca; }
            set
            {
                if (_hcl_codreg_hcca == value) return;
                _hcl_codreg_hcca = value;
                OnPropertyChanged("Hcl_codreg_hcca");
            }
        }
        #endregion
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcca
        {
            get { return _hcl_desreg_hcca; }
            set
            {
                if (_hcl_desreg_hcca == value) return;
                _hcl_desreg_hcca = value;
                OnPropertyChanged("Hcl_desreg_hcca");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla asociada para generar registro actividad
        /// en historia clinica
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
        #region Sys_codtip_sytm: Tipo de mensajes sistema
        private String _sys_codtip_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Tipo de mensajes sistema</para>
        /// <para>NOMBRE: sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico tipos de mensaje que desencadena en el adminstrador
        /// de mensajeria del sistema
        /// </para>
        /// </summary>
        public String Sys_codtip_sytm
        {
            get { return _sys_codtip_sytm; }
            set
            {
                if (_sys_codtip_sytm == value) return;
                _sys_codtip_sytm = value;
                OnPropertyChanged("Sys_codtip_sytm");
            }
        }
        #endregion
        #region Hcl_imagen_hcca: Imagen (jpg)
        private String _hcl_imagen_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcca (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de actividad
        /// en las diferentes vistas
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcca
        {
            get { return _hcl_imagen_hcca; }
            set
            {
                if (_hcl_imagen_hcca == value) return;
                _hcl_imagen_hcca = value;
                OnPropertyChanged("Hcl_imagen_hcca");
            }
        }
        #endregion
        #region Hcl_icolor_hcca: Color fondo HC
        private String _hcl_icolor_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Color fondo HC</para>
        /// <para>NOMBRE: hcl_icolor_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Color del fondo en la vista navegacion del historial clinico
        /// </para>
        /// </summary>
        public String Hcl_icolor_hcca
        {
            get { return _hcl_icolor_hcca; }
            set
            {
                if (_hcl_icolor_hcca == value) return;
                _hcl_icolor_hcca = value;
                OnPropertyChanged("Hcl_icolor_hcca");
            }
        }
        #endregion
        #region Hcl_rutarc_hcca: Ruta archivos
        private String _hcl_rutarc_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Ruta archivos</para>
        /// <para>NOMBRE: hcl_rutarc_hcca (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ruta en historial clinico de archivos generados por el grupo
        /// de actividad
        /// </para>
        /// </summary>
        public String Hcl_rutarc_hcca
        {
            get { return _hcl_rutarc_hcca; }
            set
            {
                if (_hcl_rutarc_hcca == value) return;
                _hcl_rutarc_hcca = value;
                OnPropertyChanged("Hcl_rutarc_hcca");
            }
        }
        #endregion
        #region Hcl_ordvis_hcca: Orden visualizacion
        private int _hcl_ordvis_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: hcl_ordvis_hcca (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcca
        {
            get { return _hcl_ordvis_hcca; }
            set
            {
                if (_hcl_ordvis_hcca == value) return;
                _hcl_ordvis_hcca = value;
                OnPropertyChanged("Hcl_ordvis_hcca");
            }
        }
        #endregion
        #region Hcl_psubgr_hcca: Primer reg subgrupo
        private String _hcl_psubgr_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Primer reg subgrupo</para>
        /// <para>NOMBRE: hcl_psubgr_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Primer registro cada subgrupo cuando dentro de un grupo hay
        /// varios sugrupos: 1= Primer registro 2=No es primero
        /// </para>
        /// </summary>
        public String Hcl_psubgr_hcca
        {
            get { return _hcl_psubgr_hcca; }
            set
            {
                if (_hcl_psubgr_hcca == value) return;
                _hcl_psubgr_hcca = value;
                OnPropertyChanged("Hcl_psubgr_hcca");
            }
        }
        #endregion
        #region Hcl_mededi_hcca: Medida edad Inicial
        private String _hcl_mededi_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: hcl_mededi_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica la actividad medica para
        /// validación pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededi_hcca
        {
            get { return _hcl_mededi_hcca; }
            set
            {
                if (_hcl_mededi_hcca == value) return;
                _hcl_mededi_hcca = value;
                OnPropertyChanged("Hcl_mededi_hcca");
            }
        }
        #endregion
        #region Hcl_edaini_hcca: Edad Inicial
        private int _hcl_edaini_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: hcl_edaini_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Hcl_edaini_hcca
        {
            get { return _hcl_edaini_hcca; }
            set
            {
                if (_hcl_edaini_hcca == value) return;
                _hcl_edaini_hcca = value;
                OnPropertyChanged("Hcl_edaini_hcca");
            }
        }
        #endregion
        #region Hcl_mededf_hcca: Medida edad final
        private String _hcl_mededf_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: hcl_mededf_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia actividad medica:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededf_hcca
        {
            get { return _hcl_mededf_hcca; }
            set
            {
                if (_hcl_mededf_hcca == value) return;
                _hcl_mededf_hcca = value;
                OnPropertyChanged("Hcl_mededf_hcca");
            }
        }
        #endregion
        #region Hcl_edafin_hcca: Edad final
        private int _hcl_edafin_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: hcl_edafin_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Hcl_edafin_hcca
        {
            get { return _hcl_edafin_hcca; }
            set
            {
                if (_hcl_edafin_hcca == value) return;
                _hcl_edafin_hcca = value;
                OnPropertyChanged("Hcl_edafin_hcca");
            }
        }
        #endregion
        #region Hcl_sexapl_hcca: Sexo que aplica
        private String _hcl_sexapl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: hcl_sexapl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino
        /// 3=Ambos
        /// </para>
        /// </summary>
        public String Hcl_sexapl_hcca
        {
            get { return _hcl_sexapl_hcca; }
            set
            {
                if (_hcl_sexapl_hcca == value) return;
                _hcl_sexapl_hcca = value;
                OnPropertyChanged("Hcl_sexapl_hcca");
            }
        }
        #endregion
        #region Hcl_mededl_hcca: Medida edad lista
        private String _hcl_mededl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad lista</para>
        /// <para>NOMBRE: hcl_mededl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad validacion para lista valores permitidos pertinencia:
        /// 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededl_hcca
        {
            get { return _hcl_mededl_hcca; }
            set
            {
                if (_hcl_mededl_hcca == value) return;
                _hcl_mededl_hcca = value;
                OnPropertyChanged("Hcl_mededl_hcca");
            }
        }
        #endregion
        #region Hcl_listar_hcca: Lista rango edades
        private String _hcl_listar_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Lista rango edades</para>
        /// <para>NOMBRE: hcl_listar_hcca (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Lista valores permitidos validacion edad según rango separados
        /// por el carácter COMA
        /// </para>
        /// </summary>
        public String Hcl_listar_hcca
        {
            get { return _hcl_listar_hcca; }
            set
            {
                if (_hcl_listar_hcca == value) return;
                _hcl_listar_hcca = value;
                OnPropertyChanged("Hcl_listar_hcca");
            }
        }
        #endregion
        #region Hcl_parxml_hcca: Parametros XML
        private String _hcl_parxml_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Parametros XML</para>
        /// <para>NOMBRE: hcl_parxml_hcca (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Lista parametros en formato XML para los objetos que esten
        /// marcados para cargar Valores personalizados al gestionar los
        /// formatos en vista historias clinicas
        /// </para>
        /// </summary>
        public String Hcl_parxml_hcca
        {
            get { return _hcl_parxml_hcca; }
            set
            {
                if (_hcl_parxml_hcca == value) return;
                _hcl_parxml_hcca = value;
                OnPropertyChanged("Hcl_parxml_hcca");
            }
        }
        #endregion
        #region Hcl_estreg_hcca: Estado registro
        private String _hcl_estreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: hcl_estreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_estreg_hcca
        {
            get { return _hcl_estreg_hcca; }
            set
            {
                if (_hcl_estreg_hcca == value) return;
                _hcl_estreg_hcca = value;
                OnPropertyChanged("Hcl_estreg_hcca");
            }
        }
        #endregion
        #region Hcl_destreg_hcca: Descripcion Estado registro
        private String _hcl_destreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: hcl_destreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Descripcion del Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_destreg_hcca
        {
            get { return _hcl_destreg_hcca; }
            set
            {
                if (_hcl_destreg_hcca == value) return;
                _hcl_destreg_hcca = value;
                OnPropertyChanged("Hcl_destreg_hcca");
            }
        }
        #endregion
        #region Hcl_desgru_hcra: Nombre grupo actividad
        private String _hcl_desgru_hcra;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcra
        {
            get { return _hcl_desgru_hcra; }
            set
            {
                if (_hcl_desgru_hcra == value) return;
                _hcl_desgru_hcra = value;
                OnPropertyChanged("Hcl_desgru_hcra");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
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
        #region Sys_desmsj_sytm: Descripción tipo
        private String _sys_desmsj_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripción tipo</para>
        /// <para>NOMBRE: sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del tipo notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_sytm
        {
            get { return _sys_desmsj_sytm; }
            set
            {
                if (_sys_desmsj_sytm == value) return;
                _sys_desmsj_sytm = value;
                OnPropertyChanged("Sys_desmsj_sytm");
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
        #region Hcl_desmedin_hcca: Descripcion Edad Inicial
        private String _hcl_desmedin_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion de Edad Inicial</para>
        /// <para>NOMBRE: hcl_desmedin_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de edad Inicial
        ///
        /// </para>
        /// </summary>
        public String Hcl_desmedin_hcca
        {
            get { return _hcl_desmedin_hcca; }
            set
            {
                if (_hcl_desmedin_hcca == value) return;
                _hcl_desmedin_hcca = value;
                OnPropertyChanged("Hcl_desmedin_hcca");
            }
        }
        #endregion
        #region Hcl_desmedif_hcca: Descripcion Edad Final
        private String _hcl_desmedif_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion de Edad Final</para>
        /// <para>NOMBRE: hcl_desmedif_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de edad Final
        ///
        /// </para>
        /// </summary>
        public String Hcl_desmedif_hcca
        {
            get { return _hcl_desmedif_hcca; }
            set
            {
                if (_hcl_desmedif_hcca == value) return;
                _hcl_desmedif_hcca = value;
                OnPropertyChanged("Hcl_desmedif_hcca");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloHclDetallgestionformat tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFhcltiporegactiv();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tobTempReg.Hcl_secreg_hcca);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.hcl_secreg_hcca = tobTempReg.Hcl_secreg_hcca;
                            lobEFReg.hcl_codreg_hcra = tobTempReg.Hcl_codreg_hcra;
                            lobEFReg.hcl_codreg_hcca = tobTempReg.Hcl_codreg_hcca;
                            lobEFReg.hcl_desreg_hcca = tobTempReg.Hcl_desreg_hcca;
                            lobEFReg.grp_idepla_grpl = tobTempReg.Grp_idepla_grpl;
                            lobEFReg.sys_codtip_sytm = tobTempReg.Sys_codtip_sytm;
                            lobEFReg.hcl_imagen_hcca = tobTempReg.Hcl_imagen_hcca;
                            lobEFReg.hcl_icolor_hcca = tobTempReg.Hcl_icolor_hcca;
                            lobEFReg.hcl_rutarc_hcca = tobTempReg.Hcl_rutarc_hcca;
                            lobEFReg.hcl_ordvis_hcca = (int)tobTempReg.Hcl_ordvis_hcca;
                            lobEFReg.hcl_psubgr_hcca = tobTempReg.Hcl_psubgr_hcca;
                            lobEFReg.hcl_mededi_hcca = tobTempReg.Hcl_mededi_hcca;
                            lobEFReg.hcl_edaini_hcca = (int)tobTempReg.Hcl_edaini_hcca;
                            lobEFReg.hcl_mededf_hcca = tobTempReg.Hcl_mededf_hcca;
                            lobEFReg.hcl_edafin_hcca = (int)tobTempReg.Hcl_edafin_hcca;
                            lobEFReg.hcl_sexapl_hcca = tobTempReg.Hcl_sexapl_hcca;
                            lobEFReg.hcl_mededl_hcca = tobTempReg.Hcl_mededl_hcca;
                            lobEFReg.hcl_listar_hcca = tobTempReg.Hcl_listar_hcca;
                            lobEFReg.hcl_parxml_hcca = tobTempReg.Hcl_parxml_hcca;
                            lobEFReg.hcl_estreg_hcca = tobTempReg.Hcl_estreg_hcca;
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
                                lobEFReg.hcl_secreg_hcca = tcrCodigoR1 + lobEFReg.hcl_secreg_hcca; // concatenar
                                _context.AddToHcltiporegactiv(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tobTempReg.Hcl_secreg_hcca);
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
        #region Buscar HCLTIPOREGACTIV: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Detalles tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegactiv(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tcrCodigo);
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
        /// Flitro de la vista Gestion Formatos
        /// </summary>
        /// <param name="tcrCodigoGrupo">Codigo Registro</param>
        /// <param name="tcrTextoBuscar">Texto a buscar</param>
        /// <returns></returns>
        public static List<ModeloHclDetallgestionformat> flsListaHcltiporegactiv(String tcrCodigoRegistro, String tcrTextoBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrTextoBuscar))
                {
                    var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                      join hclformatvistma in _context.Hclformatvistma on hcltiporegactiv.hcl_codreg_hcra equals hclformatvistma.hcl_codreg_hcra into tmhclformatvistma
                                      join grpmaeplantilla in _context.Grpmaeplantilla on hcltiporegactiv.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sysadmstipomens in _context.Sysadmstipomens on hcltiporegactiv.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      from hcra in tmhclformatvistma.DefaultIfEmpty()
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      where hcltiporegactiv.hcl_codreg_hcra.Equals(tcrCodigoRegistro)
                                      orderby hcra.hcl_codreg_hcra, hcra.hcl_desgru_hcra
                                      select new ModeloHclDetallgestionformat
                                      {
                                          #region datos
                                          Hcl_secreg_hcca = hcltiporegactiv.hcl_secreg_hcca,
                                          Hcl_codreg_hcra = hcltiporegactiv.hcl_codreg_hcra,
                                          Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                          Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                          Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                          Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcltiporegactiv.hcl_icolor_hcca,
                                          Hcl_rutarc_hcca = hcltiporegactiv.hcl_rutarc_hcca,
                                          Hcl_ordvis_hcca = (int)hcltiporegactiv.hcl_ordvis_hcca,
                                          Hcl_psubgr_hcca = hcltiporegactiv.hcl_psubgr_hcca,
                                          Hcl_mededi_hcca = hcltiporegactiv.hcl_mededi_hcca,
                                          Hcl_desmedin_hcca = hcltiporegactiv.hcl_mededi_hcca == "1" ? "Años" : hcltiporegactiv.hcl_mededi_hcca == "2" ? "Meses" : "Dias",
                                          Hcl_edaini_hcca = (int)hcltiporegactiv.hcl_edaini_hcca,
                                          Hcl_mededf_hcca = hcltiporegactiv.hcl_mededf_hcca,
                                          Hcl_desmedif_hcca = hcltiporegactiv.hcl_mededf_hcca == "1" ? "Años" : hcltiporegactiv.hcl_mededf_hcca == "2" ? "Meses" : "Dias",
                                          Hcl_edafin_hcca = (int)hcltiporegactiv.hcl_edafin_hcca,
                                          Hcl_sexapl_hcca = hcltiporegactiv.hcl_sexapl_hcca,
                                          Hcl_mededl_hcca = hcltiporegactiv.hcl_mededl_hcca,
                                          Hcl_listar_hcca = hcltiporegactiv.hcl_listar_hcca,
                                          Hcl_parxml_hcca = hcltiporegactiv.hcl_parxml_hcca,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Hcl_estreg_hcca = hcltiporegactiv.hcl_estreg_hcca,
                                          Hcl_destreg_hcca = hcltiporegactiv.hcl_estreg_hcca == "1" ? "Activo " : "Inactivo",
                                          Hcl_desgru_hcra = hcra.hcl_desgru_hcra,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                      join hclformatvistma in _context.Hclformatvistma on hcltiporegactiv.hcl_codreg_hcra equals hclformatvistma.hcl_codreg_hcra into tmhclformatvistma
                                      join grpmaeplantilla in _context.Grpmaeplantilla on hcltiporegactiv.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sysadmstipomens in _context.Sysadmstipomens on hcltiporegactiv.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      from hcra in tmhclformatvistma.DefaultIfEmpty()
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      where (hcltiporegactiv.hcl_codreg_hcra.Equals(tcrCodigoRegistro) &&
                                            hcltiporegactiv.hcl_desreg_hcca.Contains(tcrTextoBuscar) || hcltiporegactiv.grp_idepla_grpl.Contains(tcrTextoBuscar))
                                      orderby hcra.hcl_codreg_hcra, hcra.hcl_desgru_hcra
                                      select new ModeloHclDetallgestionformat
                                      {
                                          #region datos
                                          Hcl_secreg_hcca = hcltiporegactiv.hcl_secreg_hcca,
                                          Hcl_codreg_hcra = hcltiporegactiv.hcl_codreg_hcra,
                                          Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                          Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                          Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                          Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcltiporegactiv.hcl_icolor_hcca,
                                          Hcl_rutarc_hcca = hcltiporegactiv.hcl_rutarc_hcca,
                                          Hcl_ordvis_hcca = (int)hcltiporegactiv.hcl_ordvis_hcca,
                                          Hcl_psubgr_hcca = hcltiporegactiv.hcl_psubgr_hcca,
                                          Hcl_mededi_hcca = hcltiporegactiv.hcl_mededi_hcca,
                                          Hcl_desmedin_hcca = hcltiporegactiv.hcl_mededi_hcca == "1" ? "Años" : hcltiporegactiv.hcl_mededi_hcca == "2" ? "Meses" : "Dias",
                                          Hcl_edaini_hcca = (int)hcltiporegactiv.hcl_edaini_hcca,
                                          Hcl_mededf_hcca = hcltiporegactiv.hcl_mededf_hcca,
                                          Hcl_desmedif_hcca = hcltiporegactiv.hcl_mededf_hcca == "1" ? "Años" : hcltiporegactiv.hcl_mededf_hcca == "2" ? "Meses" : "Dias",
                                          Hcl_edafin_hcca = (int)hcltiporegactiv.hcl_edafin_hcca,
                                          Hcl_sexapl_hcca = hcltiporegactiv.hcl_sexapl_hcca,
                                          Hcl_mededl_hcca = hcltiporegactiv.hcl_mededl_hcca,
                                          Hcl_listar_hcca = hcltiporegactiv.hcl_listar_hcca,
                                          Hcl_parxml_hcca = hcltiporegactiv.hcl_parxml_hcca,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Hcl_estreg_hcca = hcltiporegactiv.hcl_estreg_hcca,
                                          Hcl_destreg_hcca = hcltiporegactiv.hcl_estreg_hcca == "1" ? "Activo " : "Inactivo",
                                          Hcl_desgru_hcra = hcra.hcl_desgru_hcra,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
}
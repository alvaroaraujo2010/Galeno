//- MARMOTA-GENCODE: VERSION 2.0 - 01/07/2016 06:45:23 AM
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
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclvariabgrupos
    /// </summary>
    public class ModeloHclvariabgrupos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_secgru_hcgv: Codigo grupo
        private String _hcl_secgru_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Codigo grupo</para>
        /// <para>NOMBRE: hcl_secgru_hcgv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo grupo de variables, generado por el sistema
        /// </para>
        /// </summary>
        public String Hcl_secgru_hcgv
        {
            get { return _hcl_secgru_hcgv; }
            set
            {
                if (_hcl_secgru_hcgv == value) return;
                _hcl_secgru_hcgv = value;
                OnPropertyChanged("Hcl_secgru_hcgv");
            }
        }
        #endregion
        #region Hcl_desgru_hcgv: Descripcion grupo
        private String _hcl_desgru_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Descripcion grupo</para>
        /// <para>NOMBRE: hcl_desgru_hcgv (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion de la clasificacion grupo de variables
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcgv
        {
            get { return _hcl_desgru_hcgv; }
            set
            {
                if (_hcl_desgru_hcgv == value) return;
                _hcl_desgru_hcgv = value;
                OnPropertyChanged("Hcl_desgru_hcgv");
            }
        }
        #endregion
        #region Hcl_nomvar_hcgv: Nombre variable
        private String _hcl_nomvar_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Nombre variable</para>
        /// <para>NOMBRE: hcl_nomvar_hcgv (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre de la variable que representa el grupo, este nombre
        /// se usara como prefijo en todas las variables que esten asociadas
        /// al grupo, ejemplo: c
        /// </para>
        /// </summary>
        public String Hcl_nomvar_hcgv
        {
            get { return _hcl_nomvar_hcgv; }
            set
            {
                if (_hcl_nomvar_hcgv == value) return;
                _hcl_nomvar_hcgv = value;
                OnPropertyChanged("Hcl_nomvar_hcgv");
            }
        }
        #endregion
        #region Hcl_conobj_hcgv: Generador de registros
        private int _hcl_conobj_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Generador de registros</para>
        /// <para>NOMBRE: hcl_conobj_hcgv (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Contador para generar id unicos de registros
        /// </para>
        /// </summary>
        public int Hcl_conobj_hcgv
        {
            get { return _hcl_conobj_hcgv; }
            set
            {
                if (_hcl_conobj_hcgv == value) return;
                _hcl_conobj_hcgv = value;
                OnPropertyChanged("Hcl_conobj_hcgv");
            }
        }
        #endregion
        #region Hcl_sisgru_hcgv: Grupo protegido
        private String _hcl_sisgru_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Grupo protegido</para>
        /// <para>NOMBRE: hcl_sisgru_hcgv (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Grupo del sistema: 1= Grupo protegido de sistema 2=Grupo normal
        /// no protegido
        /// </para>
        /// </summary>
        public String Hcl_sisgru_hcgv
        {
            get { return _hcl_sisgru_hcgv; }
            set
            {
                if (_hcl_sisgru_hcgv == value) return;
                _hcl_sisgru_hcgv = value;
                OnPropertyChanged("Hcl_sisgru_hcgv");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclvariabgrupos tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-GRUPO-VARIABLES", "HCL", "Maestro grupos de variables publicas");
            try
            {
                if (!flgBuscarHclvariabgrupos(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclvariabgrupos
                        {
                            #region cargar Registro
                            hcl_secgru_hcgv = tobjModelo.Hcl_secgru_hcgv,
                            hcl_desgru_hcgv = tobjModelo.Hcl_desgru_hcgv,
                            hcl_nomvar_hcgv = tobjModelo.Hcl_nomvar_hcgv,
                            hcl_conobj_hcgv = tobjModelo.Hcl_conobj_hcgv,
                            hcl_sisgru_hcgv = tobjModelo.Hcl_sisgru_hcgv,
                            sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                            #endregion
                        };
                        lobjRegistro.hcl_secgru_hcgv = lcrCodigoGen;
                        _context.AddToHclvariabgrupos(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-GRUPO-VARIABLES': Maestro grupos de variables publicas en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloHclvariabgrupos tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tobjModelo.Hcl_secgru_hcgv);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.hcl_secgru_hcgv = tobjModelo.Hcl_secgru_hcgv;
                        lobjRegistro.hcl_desgru_hcgv = tobjModelo.Hcl_desgru_hcgv;
                        lobjRegistro.hcl_nomvar_hcgv = tobjModelo.Hcl_nomvar_hcgv;
                        lobjRegistro.hcl_conobj_hcgv = (int)tobjModelo.Hcl_conobj_hcgv;
                        lobjRegistro.hcl_sisgru_hcgv = tobjModelo.Hcl_sisgru_hcgv;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tcrCodigo);
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
        #region Buscar HCLVARIABGRUPOS: Logica
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TITULO: Maestro grupos de variables publicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro grupos de variables publicas de historias clinicas,
        /// para organización y visualizacion en formatos de impresion
        /// </para>
        /// </summary>
        public static bool flgBuscarHclvariabgrupos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabgrupos.FirstOrDefault(p => p.hcl_secgru_hcgv == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclvariabgrupos> flsListaHclvariabgrupos(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclvariabgrupos in _context.Hclvariabgrupos
                                      select new ModeloHclvariabgrupos
                                      {
                                          Hcl_secgru_hcgv = hclvariabgrupos.hcl_secgru_hcgv,
                                          Hcl_desgru_hcgv = hclvariabgrupos.hcl_desgru_hcgv,
                                          Hcl_nomvar_hcgv = hclvariabgrupos.hcl_nomvar_hcgv,
                                          Hcl_conobj_hcgv = (int)hclvariabgrupos.hcl_conobj_hcgv,
                                          Hcl_sisgru_hcgv = hclvariabgrupos.hcl_sisgru_hcgv,
                                          Sis_estreg_esrg = hclvariabgrupos.sis_estreg_esrg,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclvariabgrupos in _context.Hclvariabgrupos
                                      where hclvariabgrupos.hcl_secgru_hcgv.Contains(tcrBuscar) || hclvariabgrupos.hcl_desgru_hcgv.Contains(tcrBuscar)
                                      select new ModeloHclvariabgrupos
                                      {
                                          Hcl_secgru_hcgv = hclvariabgrupos.hcl_secgru_hcgv,
                                          Hcl_desgru_hcgv = hclvariabgrupos.hcl_desgru_hcgv,
                                          Hcl_nomvar_hcgv = hclvariabgrupos.hcl_nomvar_hcgv,
                                          Hcl_conobj_hcgv = (int)hclvariabgrupos.hcl_conobj_hcgv,
                                          Hcl_sisgru_hcgv = hclvariabgrupos.hcl_sisgru_hcgv,
                                          Sis_estreg_esrg = hclvariabgrupos.sis_estreg_esrg,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
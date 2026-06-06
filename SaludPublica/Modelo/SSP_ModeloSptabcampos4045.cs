//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 01:29:28 AM
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
    /// Descripcion para la Vista de  la tabla: sptabcampos4045
    /// </summary>
    public class ModeloSptabcampos4045 : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _ssp_codcam_resc;
        private String _ssp_nomcam_resc;
        private String _ssp_ordvis_resc;
        private String _ssp_descam_resc;
        private String _ssp_tipval_resc;
        private String _ssp_valper_resc;
        private String _ssp_camdig_resc;
        private String _ssp_ranini_resc;
        private String _ssp_ranfin_resc;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Ssp_codcam_resc: Código Campo
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Código Campo</para>
        /// <para>NOMBRE: ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de campo o nombre (ejemplo: SSP_CAM025_SPRO)
        /// </para>
        /// </summary>
        public String Ssp_codcam_resc
        {
            get { return _ssp_codcam_resc; }
            set
            {
                if (_ssp_codcam_resc == value) return;
                _ssp_codcam_resc = value;
                OnPropertyChanged("Ssp_codcam_resc");
            }
        }
        #endregion
        #region Ssp_nomcam_resc: Titulo o Etiqueta
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: ssp_nomcam_resc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Etiqueta del campo (descripcion campo)
        /// </para>
        /// </summary>
        public String Ssp_nomcam_resc
        {
            get { return _ssp_nomcam_resc; }
            set
            {
                if (_ssp_nomcam_resc == value) return;
                _ssp_nomcam_resc = value;
                OnPropertyChanged("Ssp_nomcam_resc");
            }
        }
        #endregion
        #region Ssp_ordvis_resc: Orden Vista
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: ssp_ordvis_resc (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Orden de vista del campo en la resolucion (inicia desde campo
        /// cero (0) hasta 118)
        /// </para>
        /// </summary>
        public String Ssp_ordvis_resc
        {
            get { return _ssp_ordvis_resc; }
            set
            {
                if (_ssp_ordvis_resc == value) return;
                _ssp_ordvis_resc = value;
                OnPropertyChanged("Ssp_ordvis_resc");
            }
        }
        #endregion
        #region Ssp_descam_resc: Descripción
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: ssp_descam_resc (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción del Campo
        /// </para>
        /// </summary>
        public String Ssp_descam_resc
        {
            get { return _ssp_descam_resc; }
            set
            {
                if (_ssp_descam_resc == value) return;
                _ssp_descam_resc = value;
                OnPropertyChanged("Ssp_descam_resc");
            }
        }
        #endregion
        #region Ssp_tipval_resc: Tipo de Valor
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: ssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico
        /// </para>
        /// </summary>
        public String Ssp_tipval_resc
        {
            get { return _ssp_tipval_resc; }
            set
            {
                if (_ssp_tipval_resc == value) return;
                _ssp_tipval_resc = value;
                OnPropertyChanged("Ssp_tipval_resc");
            }
        }
        #endregion
        #region Ssp_valper_resc: Valor Permitido
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: ssp_valper_resc (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public String Ssp_valper_resc
        {
            get { return _ssp_valper_resc; }
            set
            {
                if (_ssp_valper_resc == value) return;
                _ssp_valper_resc = value;
                OnPropertyChanged("Ssp_valper_resc");
            }
        }
        #endregion
        #region Ssp_camdig_resc: Campo digitable
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: ssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Ssp_camdig_resc
        {
            get { return _ssp_camdig_resc; }
            set
            {
                if (_ssp_camdig_resc == value) return;
                _ssp_camdig_resc = value;
                OnPropertyChanged("Ssp_camdig_resc");
            }
        }
        #endregion
        #region Ssp_ranini_resc: Rango inicial
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: ssp_ranini_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Rango inicial del valor digitable
        /// </para>
        /// </summary>
        public String Ssp_ranini_resc
        {
            get { return _ssp_ranini_resc; }
            set
            {
                if (_ssp_ranini_resc == value) return;
                _ssp_ranini_resc = value;
                OnPropertyChanged("Ssp_ranini_resc");
            }
        }
        #endregion
        #region Ssp_ranfin_resc: Rango final
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: ssp_ranfin_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Rango final del valor digitable
        /// </para>
        /// </summary>
        public String Ssp_ranfin_resc
        {
            get { return _ssp_ranfin_resc; }
            set
            {
                if (_ssp_ranfin_resc == value) return;
                _ssp_ranfin_resc = value;
                OnPropertyChanged("Ssp_ranfin_resc");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSptabcampos4045 tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsptabcampos4045
                {
                    #region cargar Registro
                    ssp_codcam_resc = tobjModelo.Ssp_codcam_resc,
                    ssp_nomcam_resc = tobjModelo.Ssp_nomcam_resc,
                    ssp_ordvis_resc = tobjModelo.Ssp_ordvis_resc,
                    ssp_descam_resc = tobjModelo.Ssp_descam_resc,
                    ssp_tipval_resc = tobjModelo.Ssp_tipval_resc,
                    ssp_valper_resc = tobjModelo.Ssp_valper_resc,
                    ssp_camdig_resc = tobjModelo.Ssp_camdig_resc,
                    ssp_ranini_resc = tobjModelo.Ssp_ranini_resc,
                    ssp_ranfin_resc = tobjModelo.Ssp_ranfin_resc,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.ssp_codcam_resc;
                _context.AddToSptabcampos4045(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSptabcampos4045 tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptabcampos4045.FirstOrDefault(p => p.ssp_codcam_resc == tobjModelo.Ssp_codcam_resc);
                if (lobjRegistro != null)
                {
                    lobjRegistro.ssp_codcam_resc = tobjModelo.Ssp_codcam_resc;
                    lobjRegistro.ssp_nomcam_resc = tobjModelo.Ssp_nomcam_resc;
                    lobjRegistro.ssp_ordvis_resc = tobjModelo.Ssp_ordvis_resc;
                    lobjRegistro.ssp_descam_resc = tobjModelo.Ssp_descam_resc;
                    lobjRegistro.ssp_tipval_resc = tobjModelo.Ssp_tipval_resc;
                    lobjRegistro.ssp_valper_resc = tobjModelo.Ssp_valper_resc;
                    lobjRegistro.ssp_camdig_resc = tobjModelo.Ssp_camdig_resc;
                    lobjRegistro.ssp_ranini_resc = tobjModelo.Ssp_ranini_resc;
                    lobjRegistro.ssp_ranfin_resc = tobjModelo.Ssp_ranfin_resc;
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
                var lobjRegistro = _context.Sptabcampos4045.FirstOrDefault(p => p.ssp_codcam_resc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SPTABCAMPOS4045: Logica
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TITULO: Campos de la Resolución 4045</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de campos de la Tabla SISPRO (Resoluión 4045)
        /// </para>
        /// </summary>
        public static bool flgBuscarSptabcampos4045(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptabcampos4045.FirstOrDefault(p => p.ssp_codcam_resc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSptabcampos4045> flsListaSptabcampos4045(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sptabcampos4045 in _context.Sptabcampos4045
                                      select new ModeloSptabcampos4045
                                      {
                                          Ssp_codcam_resc = sptabcampos4045.ssp_codcam_resc,
                                          Ssp_nomcam_resc = sptabcampos4045.ssp_nomcam_resc,
                                          Ssp_ordvis_resc = sptabcampos4045.ssp_ordvis_resc,
                                          Ssp_descam_resc = sptabcampos4045.ssp_descam_resc,
                                          Ssp_tipval_resc = sptabcampos4045.ssp_tipval_resc,
                                          Ssp_valper_resc = sptabcampos4045.ssp_valper_resc,
                                          Ssp_camdig_resc = sptabcampos4045.ssp_camdig_resc,
                                          Ssp_ranini_resc = sptabcampos4045.ssp_ranini_resc,
                                          Ssp_ranfin_resc = sptabcampos4045.ssp_ranfin_resc,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sptabcampos4045 in _context.Sptabcampos4045
                                      where sptabcampos4045.ssp_codcam_resc.Contains(tcrBuscar) || sptabcampos4045.ssp_nomcam_resc.Contains(tcrBuscar)
                                      select new ModeloSptabcampos4045
                                      {
                                          Ssp_codcam_resc = sptabcampos4045.ssp_codcam_resc,
                                          Ssp_nomcam_resc = sptabcampos4045.ssp_nomcam_resc,
                                          Ssp_ordvis_resc = sptabcampos4045.ssp_ordvis_resc,
                                          Ssp_descam_resc = sptabcampos4045.ssp_descam_resc,
                                          Ssp_tipval_resc = sptabcampos4045.ssp_tipval_resc,
                                          Ssp_valper_resc = sptabcampos4045.ssp_valper_resc,
                                          Ssp_camdig_resc = sptabcampos4045.ssp_camdig_resc,
                                          Ssp_ranini_resc = sptabcampos4045.ssp_ranini_resc,
                                          Ssp_ranfin_resc = sptabcampos4045.ssp_ranfin_resc,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
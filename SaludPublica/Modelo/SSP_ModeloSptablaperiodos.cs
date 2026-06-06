//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 12:35:46 AM
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
    /// Descripcion para la Vista de  la tabla: sptablaperiodos
    /// </summary>
    public class ModeloSptablaperiodos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _ssp_codper_peri;
        private String _ssp_desper_peri;
        private String _ssp_mesper_peri;
        private String _ssp_anoper_peri;
        private DateTime _ssp_fecini_peri;
        private DateTime _ssp_fecfin_peri;
        private String _ssp_estper_peri;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Ssp_codper_peri: Código de periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Código de periodo</para>
        /// <para>NOMBRE: ssp_codper_peri (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código de periodo
        /// </para>
        /// </summary>
        public String Ssp_codper_peri
        {
            get { return _ssp_codper_peri; }
            set
            {
                if (_ssp_codper_peri == value) return;
                _ssp_codper_peri = value;
                OnPropertyChanged("Ssp_codper_peri");
            }
        }
        #endregion
        #region Ssp_desper_peri: Descripción periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Descripción periodo</para>
        /// <para>NOMBRE: ssp_desper_peri (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public String Ssp_desper_peri
        {
            get { return _ssp_desper_peri; }
            set
            {
                if (_ssp_desper_peri == value) return;
                _ssp_desper_peri = value;
                OnPropertyChanged("Ssp_desper_peri");
            }
        }
        #endregion
        #region Ssp_mesper_peri: Mes del periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Mes del periodo</para>
        /// <para>NOMBRE: ssp_mesper_peri (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Mes del periodo
        /// </para>
        /// </summary>
        public String Ssp_mesper_peri
        {
            get { return _ssp_mesper_peri; }
            set
            {
                if (_ssp_mesper_peri == value) return;
                _ssp_mesper_peri = value;
                OnPropertyChanged("Ssp_mesper_peri");
            }
        }
        #endregion
        #region Ssp_anoper_peri: Año del periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Año del periodo</para>
        /// <para>NOMBRE: ssp_anoper_peri (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Año del periodo
        /// </para>
        /// </summary>
        public String Ssp_anoper_peri
        {
            get { return _ssp_anoper_peri; }
            set
            {
                if (_ssp_anoper_peri == value) return;
                _ssp_anoper_peri = value;
                OnPropertyChanged("Ssp_anoper_peri");
            }
        }
        #endregion
        #region Ssp_fecini_peri: Fecha de inicio del periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Fecha de inicio del periodo</para>
        /// <para>NOMBRE: ssp_fecini_peri (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha de inicio del periodo
        /// </para>
        /// </summary>
        public DateTime Ssp_fecini_peri
        {
            get { return _ssp_fecini_peri; }
            set
            {
                if (_ssp_fecini_peri == value) return;
                _ssp_fecini_peri = value;
                OnPropertyChanged("Ssp_fecini_peri");
            }
        }
        #endregion
        #region Ssp_fecfin_peri: Fecha de fin del periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Fecha de fin del periodo</para>
        /// <para>NOMBRE: ssp_fecfin_peri (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha de fin del periodo
        /// </para>
        /// </summary>
        public DateTime Ssp_fecfin_peri
        {
            get { return _ssp_fecfin_peri; }
            set
            {
                if (_ssp_fecfin_peri == value) return;
                _ssp_fecfin_peri = value;
                OnPropertyChanged("Ssp_fecfin_peri");
            }
        }
        #endregion
        #region Ssp_estper_peri: Estado del periodo
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Estado del periodo</para>
        /// <para>NOMBRE: ssp_estper_peri (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del periodo
        /// </para>
        /// </summary>
        public String Ssp_estper_peri
        {
            get { return _ssp_estper_peri; }
            set
            {
                if (_ssp_estper_peri == value) return;
                _ssp_estper_peri = value;
                OnPropertyChanged("Ssp_estper_peri");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSptablaperiodos tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsptablaperiodos
                {
                    #region cargar Registro
                    ssp_codper_peri = tobjModelo.Ssp_codper_peri,
                    ssp_desper_peri = tobjModelo.Ssp_desper_peri,
                    ssp_mesper_peri = tobjModelo.Ssp_mesper_peri,
                    ssp_anoper_peri = tobjModelo.Ssp_anoper_peri,
                    ssp_fecini_peri = tobjModelo.Ssp_fecini_peri,
                    ssp_fecfin_peri = tobjModelo.Ssp_fecfin_peri,
                    ssp_estper_peri = tobjModelo.Ssp_estper_peri,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.ssp_codper_peri;
                _context.AddToSptablaperiodos(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSptablaperiodos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tobjModelo.Ssp_codper_peri);
                if (lobjRegistro != null)
                {
                    lobjRegistro.ssp_codper_peri = tobjModelo.Ssp_codper_peri;
                    lobjRegistro.ssp_desper_peri = tobjModelo.Ssp_desper_peri;
                    lobjRegistro.ssp_mesper_peri = tobjModelo.Ssp_mesper_peri;
                    lobjRegistro.ssp_anoper_peri = tobjModelo.Ssp_anoper_peri;
                    lobjRegistro.ssp_fecini_peri = (DateTime)tobjModelo.Ssp_fecini_peri;
                    lobjRegistro.ssp_fecfin_peri = (DateTime)tobjModelo.Ssp_fecfin_peri;
                    lobjRegistro.ssp_estper_peri = tobjModelo.Ssp_estper_peri;
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
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SPTABLAPERIODOS: Logica
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TITULO: Tabla periodos SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla periodos para reportes informe SISPRO 4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablaperiodos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSptablaperiodos> flsListaSptablaperiodos(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sptablaperiodos in _context.Sptablaperiodos
                                      select new ModeloSptablaperiodos
                                      {
                                          Ssp_codper_peri = sptablaperiodos.ssp_codper_peri,
                                          Ssp_desper_peri = sptablaperiodos.ssp_desper_peri,
                                          Ssp_mesper_peri = sptablaperiodos.ssp_mesper_peri,
                                          Ssp_anoper_peri = sptablaperiodos.ssp_anoper_peri,
                                          Ssp_fecini_peri = (DateTime)sptablaperiodos.ssp_fecini_peri,
                                          Ssp_fecfin_peri = (DateTime)sptablaperiodos.ssp_fecfin_peri,
                                          Ssp_estper_peri = sptablaperiodos.ssp_estper_peri,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sptablaperiodos in _context.Sptablaperiodos
                                      where sptablaperiodos.ssp_codper_peri.Contains(tcrBuscar) || sptablaperiodos.ssp_desper_peri.Contains(tcrBuscar)
                                      select new ModeloSptablaperiodos
                                      {
                                          Ssp_codper_peri = sptablaperiodos.ssp_codper_peri,
                                          Ssp_desper_peri = sptablaperiodos.ssp_desper_peri,
                                          Ssp_mesper_peri = sptablaperiodos.ssp_mesper_peri,
                                          Ssp_anoper_peri = sptablaperiodos.ssp_anoper_peri,
                                          Ssp_fecini_peri = (DateTime)sptablaperiodos.ssp_fecini_peri,
                                          Ssp_fecfin_peri = (DateTime)sptablaperiodos.ssp_fecfin_peri,
                                          Ssp_estper_peri = sptablaperiodos.ssp_estper_peri,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 10:08:54 PM
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

namespace Meci.Modelo
{
    /// <summary>
    /// tabla mcipreguntameci: Preguntas por cada grupo en una plantilla
    /// </summary>
    public class ModeloMcipreguntameci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcpr: Código de Pregunta
        private String _mci_idesec_mcpr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Código de Pregunta</para>
        /// <para>NOMBRE: mci_idesec_mcpr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código unico de la Pregunta
        /// </para>
        /// </summary>
        public String Mci_idesec_mcpr
        {
            get { return _mci_idesec_mcpr; }
            set
            {
                if (_mci_idesec_mcpr == value) return;
                _mci_idesec_mcpr = value;
                OnPropertyChanged("Mci_idesec_mcpr");
            }
        }
        #endregion
        #region Mci_idesec_mcpl: Código Plantilla
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código Plantilla</para>
        /// <para>NOMBRE: mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de plantilla en el sistema, se genera al
        /// momento de crear el registro o cuando la base de datos es cargada
        /// en el sistema
        /// </para>
        /// </summary>
        public String Mci_idesec_mcpl
        {
            get { return _mci_idesec_mcpl; }
            set
            {
                if (_mci_idesec_mcpl == value) return;
                _mci_idesec_mcpl = value;
                OnPropertyChanged("Mci_idesec_mcpl");
            }
        }
        #endregion
        #region Mci_idesec_mcmo: Código Módulo
        private String _mci_idesec_mcmo;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: mci_idesec_mcmo (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de módulos en el sistema MECI, se genera
        /// al momento de crear el registro o cuando la base de datos es
        /// cargada en el sistema
        /// </para>
        /// </summary>
        public String Mci_idesec_mcmo
        {
            get { return _mci_idesec_mcmo; }
            set
            {
                if (_mci_idesec_mcmo == value) return;
                _mci_idesec_mcmo = value;
                OnPropertyChanged("Mci_idesec_mcmo");
            }
        }
        #endregion
        #region Mci_idesec_mcco: Código de Componente
        private String _mci_idesec_mcco;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Código de Componente</para>
        /// <para>NOMBRE: mci_idesec_mcco (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código de Componente
        /// </para>
        /// </summary>
        public String Mci_idesec_mcco
        {
            get { return _mci_idesec_mcco; }
            set
            {
                if (_mci_idesec_mcco == value) return;
                _mci_idesec_mcco = value;
                OnPropertyChanged("Mci_idesec_mcco");
            }
        }
        #endregion
        #region Mci_idesec_mcpa: Código de Parámetro
        private String _mci_idesec_mcpa;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Código de Parámetro</para>
        /// <para>NOMBRE: mci_idesec_mcpa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código de Parámetro
        /// </para>
        /// </summary>
        public String Mci_idesec_mcpa
        {
            get { return _mci_idesec_mcpa; }
            set
            {
                if (_mci_idesec_mcpa == value) return;
                _mci_idesec_mcpa = value;
                OnPropertyChanged("Mci_idesec_mcpa");
            }
        }
        #endregion
        #region Mci_idesec_mcgr: Código de Grupo
        private String _mci_idesec_mcgr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Código de Grupo</para>
        /// <para>NOMBRE: mci_idesec_mcgr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Código de Grupo
        /// </para>
        /// </summary>
        public String Mci_idesec_mcgr
        {
            get { return _mci_idesec_mcgr; }
            set
            {
                if (_mci_idesec_mcgr == value) return;
                _mci_idesec_mcgr = value;
                OnPropertyChanged("Mci_idesec_mcgr");
            }
        }
        #endregion
        #region Mci_etqpre_mcpr: Etiqueta Pregunta
        private String _mci_etqpre_mcpr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Etiqueta Pregunta</para>
        /// <para>NOMBRE: mci_etqpre_mcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Etiqueta Pregunta
        /// </para>
        /// </summary>
        public String Mci_etqpre_mcpr
        {
            get { return _mci_etqpre_mcpr; }
            set
            {
                if (_mci_etqpre_mcpr == value) return;
                _mci_etqpre_mcpr = value;
                OnPropertyChanged("Mci_etqpre_mcpr");
            }
        }
        #endregion
        #region Mci_despre_mcpr: Descripción Pregunta
        private String _mci_despre_mcpr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Descripción Pregunta</para>
        /// <para>NOMBRE: mci_despre_mcpr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripción Pregunta
        /// </para>
        /// </summary>
        public String Mci_despre_mcpr
        {
            get { return _mci_despre_mcpr; }
            set
            {
                if (_mci_despre_mcpr == value) return;
                _mci_despre_mcpr = value;
                OnPropertyChanged("Mci_despre_mcpr");
            }
        }
        #endregion
        #region Mci_ordvis_mcpr: Orden Vista
        private int _mci_ordvis_mcpr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: mci_ordvis_mcpr (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int Mci_ordvis_mcpr
        {
            get { return _mci_ordvis_mcpr; }
            set
            {
                if (_mci_ordvis_mcpr == value) return;
                _mci_ordvis_mcpr = value;
                OnPropertyChanged("Mci_ordvis_mcpr");
            }
        }
        #endregion
        #region Mci_estreg_mcpr: Estado del Pregunta
        private String _mci_estreg_mcpr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Estado del Pregunta</para>
        /// <para>NOMBRE: mci_estreg_mcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del Pregunta
        /// </para>
        /// </summary>
        public String Mci_estreg_mcpr
        {
            get { return _mci_estreg_mcpr; }
            set
            {
                if (_mci_estreg_mcpr == value) return;
                _mci_estreg_mcpr = value;
                OnPropertyChanged("Mci_estreg_mcpr");
            }
        }
        #endregion
        #region Mci_desgrp_mcgr: Descripción Grupo
        private String _mci_desgrp_mcgr;
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Descripción Grupo</para>
        /// <para>NOMBRE: mci_desgrp_mcgr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción Grupo
        /// </para>
        /// </summary>
        public String Mci_desgrp_mcgr
        {
            get { return _mci_desgrp_mcgr; }
            set
            {
                if (_mci_desgrp_mcgr == value) return;
                _mci_desgrp_mcgr = value;
                OnPropertyChanged("Mci_desgrp_mcgr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMcipreguntameci tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIPREGUNTAMECI", "MCI", "Preguntas Dentro de Grupos en la Plantilla del Módulos Meci");
            if (!flgBuscarMcipreguntameci(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmcipreguntameci
                    {
                        #region cargar Registro
                        mci_idesec_mcpr = tobjModelo.Mci_idesec_mcpr,
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo,
                        mci_idesec_mcco = tobjModelo.Mci_idesec_mcco,
                        mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa,
                        mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr,
                        mci_etqpre_mcpr = tobjModelo.Mci_etqpre_mcpr,
                        mci_despre_mcpr = tobjModelo.Mci_despre_mcpr,
                        mci_ordvis_mcpr = (int)tobjModelo.Mci_ordvis_mcpr,
                        mci_estreg_mcpr = tobjModelo.Mci_estreg_mcpr,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcpr = lcrCodigoGen;
                    _context.AddToMcipreguntameci(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIPREGUNTAMECI': Preguntas Dentro de Grupos en la Plantilla del Módulos Meci en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMcipreguntameci tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tobjModelo.Mci_idesec_mcpr);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcpr = tobjModelo.Mci_idesec_mcpr;
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo;
                    lobjRegistro.mci_idesec_mcco = tobjModelo.Mci_idesec_mcco;
                    lobjRegistro.mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa;
                    lobjRegistro.mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr;
                    lobjRegistro.mci_etqpre_mcpr = tobjModelo.Mci_etqpre_mcpr;
                    lobjRegistro.mci_despre_mcpr = tobjModelo.Mci_despre_mcpr;
                    lobjRegistro.mci_ordvis_mcpr = tobjModelo.Mci_ordvis_mcpr;
                    lobjRegistro.mci_estreg_mcpr = tobjModelo.Mci_estreg_mcpr;
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
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIPREGUNTAMECI: Logica
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TITULO: Preguntas Dentro de Grupos en la Plantilla del Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para las preguntas de un grupo en los parámetros dentro
        /// de los componentes pertenecientes a los módulos de las plantillas
        /// de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcipreguntameci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcipreguntameci> flsListaMcipreguntameci(String tcrIdGrupo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mcipreguntameci in _context.Mcipreguntameci
                                      join mcigrupoprgmeci in _context.Mcigrupoprgmeci on mcipreguntameci.mci_idesec_mcgr equals mcigrupoprgmeci.mci_idesec_mcgr into tmmcigrupoprgmeci
                                      from mcgr in tmmcigrupoprgmeci.DefaultIfEmpty()
                                      where mcipreguntameci.mci_idesec_mcgr.Equals(tcrIdGrupo)
                                      select new ModeloMcipreguntameci
                                      {
                                          Mci_idesec_mcpr = mcipreguntameci.mci_idesec_mcpr,
                                          Mci_idesec_mcpl = mcipreguntameci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcipreguntameci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mcipreguntameci.mci_idesec_mcco,
                                          Mci_idesec_mcpa = mcipreguntameci.mci_idesec_mcpa,
                                          Mci_idesec_mcgr = mcipreguntameci.mci_idesec_mcgr,
                                          Mci_etqpre_mcpr = mcipreguntameci.mci_etqpre_mcpr,
                                          Mci_despre_mcpr = mcipreguntameci.mci_despre_mcpr,
                                          Mci_ordvis_mcpr = (int)mcipreguntameci.mci_ordvis_mcpr,
                                          Mci_estreg_mcpr = mcipreguntameci.mci_estreg_mcpr,
                                          Mci_desgrp_mcgr = mcgr.mci_desgrp_mcgr,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mcipreguntameci in _context.Mcipreguntameci
                                      join mcigrupoprgmeci in _context.Mcigrupoprgmeci on mcipreguntameci.mci_idesec_mcgr equals mcigrupoprgmeci.mci_idesec_mcgr into tmmcigrupoprgmeci
                                      from mcgr in tmmcigrupoprgmeci.DefaultIfEmpty()
                                      where mcipreguntameci.mci_idesec_mcgr.Equals(tcrIdGrupo) &&
                                           mcipreguntameci.mci_despre_mcpr.Contains(tcrBuscar) || 
                                           mcipreguntameci.mci_idesec_mcpr.Contains(tcrBuscar)
                                      select new ModeloMcipreguntameci
                                      {
                                          Mci_idesec_mcpr = mcipreguntameci.mci_idesec_mcpr,
                                          Mci_idesec_mcpl = mcipreguntameci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcipreguntameci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mcipreguntameci.mci_idesec_mcco,
                                          Mci_idesec_mcpa = mcipreguntameci.mci_idesec_mcpa,
                                          Mci_idesec_mcgr = mcipreguntameci.mci_idesec_mcgr,
                                          Mci_etqpre_mcpr = mcipreguntameci.mci_etqpre_mcpr,
                                          Mci_despre_mcpr = mcipreguntameci.mci_despre_mcpr,
                                          Mci_ordvis_mcpr = (int)mcipreguntameci.mci_ordvis_mcpr,
                                          Mci_estreg_mcpr = mcipreguntameci.mci_estreg_mcpr,
                                          Mci_desgrp_mcgr = mcgr.mci_desgrp_mcgr,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Listar Registros que pertenecen a una plantilla
        /// <summary>
        /// Listar Registros que pertenecen a una plantilla
        /// </summary>
        public static List<ModeloMcipreguntameci> flsListaMcipreguntameciPlantilla(String tcrCodigoPlantilla, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from mcipreguntameci in _context.Mcipreguntameci
                                  where mcipreguntameci.mci_idesec_mcpl.Equals(tcrCodigoPlantilla) && 
                                        mcipreguntameci.mci_estreg_mcpr.Equals(tcrEstadoRegistro)
                                  select new ModeloMcipreguntameci
                                  {
                                      Mci_idesec_mcpr = mcipreguntameci.mci_idesec_mcpr,
                                      Mci_idesec_mcpl = mcipreguntameci.mci_idesec_mcpl,
                                      Mci_idesec_mcmo = mcipreguntameci.mci_idesec_mcmo,
                                      Mci_idesec_mcco = mcipreguntameci.mci_idesec_mcco,
                                      Mci_idesec_mcpa = mcipreguntameci.mci_idesec_mcpa,
                                      Mci_idesec_mcgr = mcipreguntameci.mci_idesec_mcgr,
                                      Mci_etqpre_mcpr = mcipreguntameci.mci_etqpre_mcpr,
                                      Mci_despre_mcpr = mcipreguntameci.mci_despre_mcpr,
                                      Mci_ordvis_mcpr = (int)mcipreguntameci.mci_ordvis_mcpr,
                                      Mci_estreg_mcpr = mcipreguntameci.mci_estreg_mcpr,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
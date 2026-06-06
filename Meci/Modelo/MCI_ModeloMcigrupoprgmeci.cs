//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 05:29:27 PM
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
    /// Descripcion para la Vista de  la tabla: mcigrupoprgmeci
    /// </summary>
    public class ModeloMcigrupoprgmeci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcgr: Código de Grupo
        private String _mci_idesec_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Código de Grupo</para>
        /// <para>NOMBRE: mci_idesec_mcgr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_idesec_mcpl: Código Plantilla
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
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
        /// <para>TABLA: mcigrupoprgmeci</para>
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
        /// <para>TABLA: mcigrupoprgmeci</para>
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
        /// <para>TABLA: mcigrupoprgmeci</para>
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
        #region Mci_etqgrp_mcgr: Etiqueta Grupo
        private String _mci_etqgrp_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Etiqueta Grupo</para>
        /// <para>NOMBRE: mci_etqgrp_mcgr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Etiqueta Grupo
        /// </para>
        /// </summary>
        public String Mci_etqgrp_mcgr
        {
            get { return _mci_etqgrp_mcgr; }
            set
            {
                if (_mci_etqgrp_mcgr == value) return;
                _mci_etqgrp_mcgr = value;
                OnPropertyChanged("Mci_etqgrp_mcgr");
            }
        }
        #endregion
        #region Mci_desgrp_mcgr: Descripción Grupo
        private String _mci_desgrp_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
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
        #region Mci_ordvis_mcgr: Orden Vista
        private int _mci_ordvis_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: mci_ordvis_mcgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int Mci_ordvis_mcgr
        {
            get { return _mci_ordvis_mcgr; }
            set
            {
                if (_mci_ordvis_mcgr == value) return;
                _mci_ordvis_mcgr = value;
                OnPropertyChanged("Mci_ordvis_mcgr");
            }
        }
        #endregion
        #region Mci_secdet_mcgr: Secuencial detalle MCGR
        private int _mci_secdet_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Secuencial detalle MCGR</para>
        /// <para>NOMBRE: mci_secdet_mcgr (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de las preguntas dentro de
        /// un grupo
        /// </para>
        /// </summary>
        public int Mci_secdet_mcgr
        {
            get { return _mci_secdet_mcgr; }
            set
            {
                if (_mci_secdet_mcgr == value) return;
                _mci_secdet_mcgr = value;
                OnPropertyChanged("Mci_secdet_mcgr");
            }
        }
        #endregion
        #region Mci_estreg_mcgr: Estado del grupo
        private String _mci_estreg_mcgr;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Estado del grupo</para>
        /// <para>NOMBRE: mci_estreg_mcgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del grupo
        /// </para>
        /// </summary>
        public String Mci_estreg_mcgr
        {
            get { return _mci_estreg_mcgr; }
            set
            {
                if (_mci_estreg_mcgr == value) return;
                _mci_estreg_mcgr = value;
                OnPropertyChanged("Mci_estreg_mcgr");
            }
        }
        #endregion
        #region Mci_despar_mcpa: Descripción parámetro
        private String _mci_despar_mcpa;
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Descripción parámetro</para>
        /// <para>NOMBRE: mci_despar_mcpa (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción parámetro
        /// </para>
        /// </summary>
        public String Mci_despar_mcpa
        {
            get { return _mci_despar_mcpa; }
            set
            {
                if (_mci_despar_mcpa == value) return;
                _mci_despar_mcpa = value;
                OnPropertyChanged("Mci_despar_mcpa");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMcigrupoprgmeci tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIGRUPOPRGMECI", "MCI", "Grupos en Parametros en Componentes de Módulos Meci");
            if (!flgBuscarMcigrupoprgmeci(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmcigrupoprgmeci
                    {
                        #region cargar Registro
                        mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr,
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo,
                        mci_idesec_mcco = tobjModelo.Mci_idesec_mcco,
                        mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa,
                        mci_etqgrp_mcgr = tobjModelo.Mci_etqgrp_mcgr,
                        mci_desgrp_mcgr = tobjModelo.Mci_desgrp_mcgr,
                        mci_ordvis_mcgr = tobjModelo.Mci_ordvis_mcgr,
                        mci_secdet_mcgr = tobjModelo.Mci_secdet_mcgr,
                        mci_estreg_mcgr = tobjModelo.Mci_estreg_mcgr,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcgr = lcrCodigoGen;
                    _context.AddToMcigrupoprgmeci(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIGRUPOPRGMECI': Grupos en Parametros en Componentes de Módulos Meci en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMcigrupoprgmeci tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tobjModelo.Mci_idesec_mcgr);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr;
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo;
                    lobjRegistro.mci_idesec_mcco = tobjModelo.Mci_idesec_mcco;
                    lobjRegistro.mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa;
                    lobjRegistro.mci_etqgrp_mcgr = tobjModelo.Mci_etqgrp_mcgr;
                    lobjRegistro.mci_desgrp_mcgr = tobjModelo.Mci_desgrp_mcgr;
                    lobjRegistro.mci_ordvis_mcgr = tobjModelo.Mci_ordvis_mcgr;
                    lobjRegistro.mci_secdet_mcgr = (int)tobjModelo.Mci_secdet_mcgr;
                    lobjRegistro.mci_estreg_mcgr = tobjModelo.Mci_estreg_mcgr;
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
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIGRUPOPRGMECI: Logica
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TITULO: Grupos en Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los grupos que contendrán las preguntas en los parámetros
        /// dentro de los componentes pertenecientes a los módulos de las
        /// plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcigrupoprgmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcigrupoprgmeci> flsListaMcigrupoprgmeci(String tcrIdParametro,String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mcigrupoprgmeci in _context.Mcigrupoprgmeci
                                      join mciparametrmeci in _context.Mciparametrmeci on mcigrupoprgmeci.mci_idesec_mcpa equals mciparametrmeci.mci_idesec_mcpa into tmmciparametrmeci
                                      from mcpa in tmmciparametrmeci.DefaultIfEmpty()
                                      where mcigrupoprgmeci.mci_idesec_mcpa.Equals(tcrIdParametro)
                                      select new ModeloMcigrupoprgmeci
                                      {
                                          Mci_idesec_mcgr = mcigrupoprgmeci.mci_idesec_mcgr,
                                          Mci_idesec_mcpl = mcigrupoprgmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcigrupoprgmeci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mcigrupoprgmeci.mci_idesec_mcco,
                                          Mci_idesec_mcpa = mcigrupoprgmeci.mci_idesec_mcpa,
                                          Mci_etqgrp_mcgr = mcigrupoprgmeci.mci_etqgrp_mcgr,
                                          Mci_desgrp_mcgr = mcigrupoprgmeci.mci_desgrp_mcgr,
                                          Mci_ordvis_mcgr = (int)mcigrupoprgmeci.mci_ordvis_mcgr,
                                          Mci_secdet_mcgr = (int)mcigrupoprgmeci.mci_secdet_mcgr,
                                          Mci_estreg_mcgr = mcigrupoprgmeci.mci_estreg_mcgr,
                                          Mci_despar_mcpa = mcpa.mci_despar_mcpa,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mcigrupoprgmeci in _context.Mcigrupoprgmeci
                                      join mciparametrmeci in _context.Mciparametrmeci on mcigrupoprgmeci.mci_idesec_mcpa equals mciparametrmeci.mci_idesec_mcpa into tmmciparametrmeci
                                      from mcpa in tmmciparametrmeci.DefaultIfEmpty()
                                      where mcigrupoprgmeci.mci_idesec_mcpa.Equals(tcrIdParametro) &&
                                              mcigrupoprgmeci.mci_desgrp_mcgr.Contains(tcrBuscar) || 
                                              mcigrupoprgmeci.mci_idesec_mcgr.Contains(tcrBuscar)
                                      select new ModeloMcigrupoprgmeci
                                      {
                                          Mci_idesec_mcgr = mcigrupoprgmeci.mci_idesec_mcgr,
                                          Mci_idesec_mcpl = mcigrupoprgmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcigrupoprgmeci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mcigrupoprgmeci.mci_idesec_mcco,
                                          Mci_idesec_mcpa = mcigrupoprgmeci.mci_idesec_mcpa,
                                          Mci_etqgrp_mcgr = mcigrupoprgmeci.mci_etqgrp_mcgr,
                                          Mci_desgrp_mcgr = mcigrupoprgmeci.mci_desgrp_mcgr,
                                          Mci_ordvis_mcgr = (int)mcigrupoprgmeci.mci_ordvis_mcgr,
                                          Mci_secdet_mcgr = (int)mcigrupoprgmeci.mci_secdet_mcgr,
                                          Mci_estreg_mcgr = mcigrupoprgmeci.mci_estreg_mcgr,
                                          Mci_despar_mcpa = mcpa.mci_despar_mcpa,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
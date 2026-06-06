//- MARMOTA-GENCODE: VERSION 2.0 - 27/04/2015 06:47:21 PM
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
    /// tabla: mcievaluacionde detalles respuestas evauacion
    /// </summary>
    public class ModeloMcievaluacionde : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcdt: Código registro
        private String _mci_idesec_mcdt;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionde</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: mci_idesec_mcdt (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código unico del registro pregunta
        /// </para>
        /// </summary>
        public String Mci_idesec_mcdt
        {
            get { return _mci_idesec_mcdt; }
            set
            {
                if (_mci_idesec_mcdt == value) return;
                _mci_idesec_mcdt = value;
                OnPropertyChanged("Mci_idesec_mcdt");
            }
        }
        #endregion
        #region Mci_idesec_mcms: Código evaluación
        private String _mci_idesec_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Código evaluación</para>
        /// <para>NOMBRE: mci_idesec_mcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de evaluaciones en el sistema, se genera
        /// al momento de crear el registro o cuando la base de datos es
        /// cargada en el sistema
        /// </para>
        /// </summary>
        public String Mci_idesec_mcms
        {
            get { return _mci_idesec_mcms; }
            set
            {
                if (_mci_idesec_mcms == value) return;
                _mci_idesec_mcms = value;
                OnPropertyChanged("Mci_idesec_mcms");
            }
        }
        #endregion
        #region Mci_idesec_mcpl: Código Plantilla
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código Plantilla</para>
        /// <para>NOMBRE: mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo de plantilla de evaluación en el sistema
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
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: mci_idesec_mcmo (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Código de Componente</para>
        /// <para>NOMBRE: mci_idesec_mcco (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Código de Parámetro</para>
        /// <para>NOMBRE: mci_idesec_mcpa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcigrupoprgmeci</para>
        /// <para>CAMPO: Código de Grupo</para>
        /// <para>NOMBRE: mci_idesec_mcgr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Mci_idesec_mcpr: Código de Pregunta
        private String _mci_idesec_mcpr;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcipreguntameci</para>
        /// <para>CAMPO: Código de Pregunta</para>
        /// <para>NOMBRE: mci_idesec_mcpr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código de Pregunta
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
        #region Mci_idesec_mcmd: Código respuesta
        private String _mci_idesec_mcmd;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcitiporespuede</para>
        /// <para>CAMPO: Código respuesta</para>
        /// <para>NOMBRE: mci_idesec_mcmd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Consecutivo maestro respuesta
        /// </para>
        /// </summary>
        public String Mci_idesec_mcmd
        {
            get { return _mci_idesec_mcmd; }
            set
            {
                if (_mci_idesec_mcmd == value) return;
                _mci_idesec_mcmd = value;
                OnPropertyChanged("Mci_idesec_mcmd");
            }
        }
        #endregion
        #region Mci_respre_mcmd: Calificación texto
        private String _mci_respre_mcmd;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcitiporespuede</para>
        /// <para>CAMPO: Calificación texto</para>
        /// <para>NOMBRE: mci_respre_mcmd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Calificación de la pregunta  texto
        /// </para>
        /// </summary>
        public String Mci_respre_mcmd
        {
            get { return _mci_respre_mcmd; }
            set
            {
                if (_mci_respre_mcmd == value) return;
                _mci_respre_mcmd = value;
                OnPropertyChanged("Mci_respre_mcmd");
            }
        }
        #endregion
        #region Mci_valpre_mcmd: Calificación numero
        private float _mci_valpre_mcmd;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcitiporespuede</para>
        /// <para>CAMPO: Calificación numero</para>
        /// <para>NOMBRE: mci_valpre_mcmd (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Calificación o equivalencia  númerica respuesta de la pregunta
        /// </para>
        /// </summary>
        public float Mci_valpre_mcmd
        {
            get { return _mci_valpre_mcmd; }
            set
            {
                if (_mci_valpre_mcmd == value) return;
                _mci_valpre_mcmd = value;
                OnPropertyChanged("Mci_valpre_mcmd");
            }
        }
        #endregion
        #region Mci_eviora_mcdt: Evidencia Oral
        private String _mci_eviora_mcdt;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionde</para>
        /// <para>CAMPO: Evidencia Oral</para>
        /// <para>NOMBRE: mci_eviora_mcdt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Existe evidencia Oral 1=SI, 2=NO
        /// </para>
        /// </summary>
        public String Mci_eviora_mcdt
        {
            get { return _mci_eviora_mcdt; }
            set
            {
                if (_mci_eviora_mcdt == value) return;
                _mci_eviora_mcdt = value;
                OnPropertyChanged("Mci_eviora_mcdt");
            }
        }
        #endregion
        #region Mci_evifis_mcdt: Evidencia Física
        private String _mci_evifis_mcdt;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionde</para>
        /// <para>CAMPO: Evidencia Física</para>
        /// <para>NOMBRE: mci_evifis_mcdt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Existe evidencia Física 1=SI, 2=NO
        /// </para>
        /// </summary>
        public String Mci_evifis_mcdt
        {
            get { return _mci_evifis_mcdt; }
            set
            {
                if (_mci_evifis_mcdt == value) return;
                _mci_evifis_mcdt = value;
                OnPropertyChanged("Mci_evifis_mcdt");
            }
        }
        #endregion
        #region Mci_otrevi_mcdt: Otro tipo de evidencia
        private String _mci_otrevi_mcdt;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionde</para>
        /// <para>CAMPO: Otro tipo de evidencia</para>
        /// <para>NOMBRE: mci_otrevi_mcdt (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Existe otro tipo de evidencia, Cual?
        /// </para>
        /// </summary>
        public String Mci_otrevi_mcdt
        {
            get { return _mci_otrevi_mcdt; }
            set
            {
                if (_mci_otrevi_mcdt == value) return;
                _mci_otrevi_mcdt = value;
                OnPropertyChanged("Mci_otrevi_mcdt");
            }
        }
        #endregion
        #region Mci_estreg_mcdt: Estado
        private String _mci_estreg_mcdt;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionde</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: mci_estreg_mcdt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Estado de la Pregunta evaluada 1= Abierta 2= Confirmada 3=
        /// Anulada
        /// </para>
        /// </summary>
        public String Mci_estreg_mcdt
        {
            get { return _mci_estreg_mcdt; }
            set
            {
                if (_mci_estreg_mcdt == value) return;
                _mci_estreg_mcdt = value;
                OnPropertyChanged("Mci_estreg_mcdt");
            }
        }
        #endregion
        #region Mci_deseva_mcms: Evaluación
        private String _mci_deseva_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Evaluación</para>
        /// <para>NOMBRE: mci_deseva_mcms (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la Evaluación
        /// </para>
        /// </summary>
        public String Mci_deseva_mcms
        {
            get { return _mci_deseva_mcms; }
            set
            {
                if (_mci_deseva_mcms == value) return;
                _mci_deseva_mcms = value;
                OnPropertyChanged("Mci_deseva_mcms");
            }
        }
        #endregion
        #region Mci_desgrp_mcgr: Descripción Grupo
        private String _mci_desgrp_mcgr;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
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
        #region Mci_despre_mcpr: Descripción Pregunta
        private String _mci_despre_mcpr;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
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
        #region Mci_desres_mcmd: Descripcion respuesta
        private String _mci_desres_mcmd;
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TABLA NATIVA: mcitiporespuede</para>
        /// <para>CAMPO: Descripcion respuesta</para>
        /// <para>NOMBRE: mci_desres_mcmd (char:70)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripcion cada respuestas en  evaluacion ejemplo: 1 = Cumple
        /// con modelos en manuales 2=No cumple con planes de trabajo
        /// </para>
        /// </summary>
        public String Mci_desres_mcmd
        {
            get { return _mci_desres_mcmd; }
            set
            {
                if (_mci_desres_mcmd == value) return;
                _mci_desres_mcmd = value;
                OnPropertyChanged("Mci_desres_mcmd");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMcievaluacionde tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIEVALUACIONDE", "MCI", "Detalles respuestas preguntas de una Evaluación");
            if (!flgBuscarMcievaluacionde(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmcievaluacionde
                    {
                        #region cargar Registro
                        mci_idesec_mcdt = tobjModelo.Mci_idesec_mcdt,
                        mci_idesec_mcms = tobjModelo.Mci_idesec_mcms,
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo,
                        mci_idesec_mcco = tobjModelo.Mci_idesec_mcco,
                        mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa,
                        mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr,
                        mci_idesec_mcpr = tobjModelo.Mci_idesec_mcpr,
                        mci_idesec_mcmd = tobjModelo.Mci_idesec_mcmd,
                        mci_respre_mcmd = tobjModelo.Mci_respre_mcmd,
                        mci_valpre_mcmd = tobjModelo.Mci_valpre_mcmd,
                        mci_eviora_mcdt = tobjModelo.Mci_eviora_mcdt,
                        mci_evifis_mcdt = tobjModelo.Mci_evifis_mcdt,
                        mci_otrevi_mcdt = tobjModelo.Mci_otrevi_mcdt,
                        mci_estreg_mcdt = tobjModelo.Mci_estreg_mcdt,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcdt = lcrCodigoGen;
                    _context.AddToMcievaluacionde(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIEVALUACIONDE': Detalles respuestas preguntas de una Evaluación en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMcievaluacionde tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcievaluacionde.FirstOrDefault(p => p.mci_idesec_mcdt == tobjModelo.Mci_idesec_mcdt);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcdt = tobjModelo.Mci_idesec_mcdt;
                    lobjRegistro.mci_idesec_mcms = tobjModelo.Mci_idesec_mcms;
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo;
                    lobjRegistro.mci_idesec_mcco = tobjModelo.Mci_idesec_mcco;
                    lobjRegistro.mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa;
                    lobjRegistro.mci_idesec_mcgr = tobjModelo.Mci_idesec_mcgr;
                    lobjRegistro.mci_idesec_mcpr = tobjModelo.Mci_idesec_mcpr;
                    lobjRegistro.mci_idesec_mcmd = tobjModelo.Mci_idesec_mcmd;
                    lobjRegistro.mci_respre_mcmd = tobjModelo.Mci_respre_mcmd;
                    lobjRegistro.mci_valpre_mcmd = (float)tobjModelo.Mci_valpre_mcmd;
                    lobjRegistro.mci_eviora_mcdt = tobjModelo.Mci_eviora_mcdt;
                    lobjRegistro.mci_evifis_mcdt = tobjModelo.Mci_evifis_mcdt;
                    lobjRegistro.mci_otrevi_mcdt = tobjModelo.Mci_otrevi_mcdt;
                    lobjRegistro.mci_estreg_mcdt = tobjModelo.Mci_estreg_mcdt;
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
                var lobjRegistro = _context.Mcievaluacionde.FirstOrDefault(p => p.mci_idesec_mcdt == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIEVALUACIONDE: Logica
        /// <summary>
        /// <para>TABLA: mcievaluacionde</para>
        /// <para>TITULO: Detalles respuestas preguntas de una Evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla detalles respuestas de preguntas en evaluacion según
        /// plantilla utilizada
        /// </para>
        /// </summary>
        public static bool flgBuscarMcievaluacionde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcievaluacionde.FirstOrDefault(p => p.mci_idesec_mcdt == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcievaluacionde> flsListaMcievaluacionde(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from mcievaluacionde in _context.Mcievaluacionde
                                  join mcievaluacionms in _context.Mcievaluacionms on mcievaluacionde.mci_idesec_mcms equals mcievaluacionms.mci_idesec_mcms into tmmcievaluacionms
                                  join mcigrupoprgmeci in _context.Mcigrupoprgmeci on mcievaluacionde.mci_idesec_mcgr equals mcigrupoprgmeci.mci_idesec_mcgr into tmmcigrupoprgmeci
                                  join mcipreguntameci in _context.Mcipreguntameci on mcievaluacionde.mci_idesec_mcpr equals mcipreguntameci.mci_idesec_mcpr into tmmcipreguntameci
                                  join mcitiporespuede in _context.Mcitiporespuede on mcievaluacionde.mci_idesec_mcmd equals mcitiporespuede.mci_idesec_mcmd into tmmcitiporespuede
                                  from mcms in tmmcievaluacionms.DefaultIfEmpty()
                                  from mcgr in tmmcigrupoprgmeci.DefaultIfEmpty()
                                  from mcpr in tmmcipreguntameci.DefaultIfEmpty()
                                  from mcmd in tmmcitiporespuede.DefaultIfEmpty()
                                  where mcievaluacionde.mci_idesec_mcdt == tcrBuscar
                                  select new ModeloMcievaluacionde
                                  {
                                      Mci_idesec_mcdt = mcievaluacionde.mci_idesec_mcdt,
                                      Mci_idesec_mcms = mcievaluacionde.mci_idesec_mcms,
                                      Mci_idesec_mcpl = mcievaluacionde.mci_idesec_mcpl,
                                      Mci_idesec_mcmo = mcievaluacionde.mci_idesec_mcmo,
                                      Mci_idesec_mcco = mcievaluacionde.mci_idesec_mcco,
                                      Mci_idesec_mcpa = mcievaluacionde.mci_idesec_mcpa,
                                      Mci_idesec_mcgr = mcievaluacionde.mci_idesec_mcgr,
                                      Mci_idesec_mcpr = mcievaluacionde.mci_idesec_mcpr,
                                      Mci_idesec_mcmd = mcievaluacionde.mci_idesec_mcmd,
                                      Mci_respre_mcmd = mcievaluacionde.mci_respre_mcmd,
                                      Mci_valpre_mcmd = (float)mcievaluacionde.mci_valpre_mcmd,
                                      Mci_eviora_mcdt = mcievaluacionde.mci_eviora_mcdt,
                                      Mci_evifis_mcdt = mcievaluacionde.mci_evifis_mcdt,
                                      Mci_otrevi_mcdt = mcievaluacionde.mci_otrevi_mcdt,
                                      Mci_estreg_mcdt = mcievaluacionde.mci_estreg_mcdt,
                                      Mci_deseva_mcms = mcms.mci_deseva_mcms,
                                      Mci_desgrp_mcgr = mcgr.mci_desgrp_mcgr,
                                      Mci_despre_mcpr = mcpr.mci_despre_mcpr,
                                      Mci_desres_mcmd = mcmd.mci_desres_mcmd,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar Registros por evaluacion
        /// <summary>
        /// <para>Filtrar por codigo Evaluacion R1 y estado</para> 
        /// </summary>
        public static List<ModeloMcievaluacionde> flsListaMcievaluaciondeEx(String tcrIdCodigoR1)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from mcievaluacionde in _context.Mcievaluacionde
                                  join mcigrupoprgmeci in _context.Mcigrupoprgmeci on mcievaluacionde.mci_idesec_mcgr equals mcigrupoprgmeci.mci_idesec_mcgr into tmmcigrupoprgmeci
                                  join mcipreguntameci in _context.Mcipreguntameci on mcievaluacionde.mci_idesec_mcpr equals mcipreguntameci.mci_idesec_mcpr into tmmcipreguntameci
                                  join mcitiporespuede in _context.Mcitiporespuede on mcievaluacionde.mci_idesec_mcmd equals mcitiporespuede.mci_idesec_mcmd into tmmcitiporespuede
                                  from mcgr in tmmcigrupoprgmeci.DefaultIfEmpty()
                                  from mcpr in tmmcipreguntameci.DefaultIfEmpty()
                                  from mcmd in tmmcitiporespuede.DefaultIfEmpty()
                                  where mcievaluacionde.mci_idesec_mcms == tcrIdCodigoR1 
                                  select new ModeloMcievaluacionde
                                  {
                                      Mci_idesec_mcdt = mcievaluacionde.mci_idesec_mcdt,
                                      Mci_idesec_mcms = mcievaluacionde.mci_idesec_mcms,
                                      Mci_idesec_mcpl = mcievaluacionde.mci_idesec_mcpl,
                                      Mci_idesec_mcmo = mcievaluacionde.mci_idesec_mcmo,
                                      Mci_idesec_mcco = mcievaluacionde.mci_idesec_mcco,
                                      Mci_idesec_mcpa = mcievaluacionde.mci_idesec_mcpa,
                                      Mci_idesec_mcgr = mcievaluacionde.mci_idesec_mcgr,
                                      Mci_idesec_mcpr = mcievaluacionde.mci_idesec_mcpr,
                                      Mci_idesec_mcmd = mcievaluacionde.mci_idesec_mcmd,
                                      Mci_respre_mcmd = mcievaluacionde.mci_respre_mcmd,
                                      Mci_valpre_mcmd = (float)mcievaluacionde.mci_valpre_mcmd,
                                      Mci_eviora_mcdt = mcievaluacionde.mci_eviora_mcdt,
                                      Mci_evifis_mcdt = mcievaluacionde.mci_evifis_mcdt,
                                      Mci_otrevi_mcdt = mcievaluacionde.mci_otrevi_mcdt,
                                      Mci_estreg_mcdt = mcievaluacionde.mci_estreg_mcdt,
                                      Mci_desgrp_mcgr = mcgr.mci_desgrp_mcgr,
                                      Mci_despre_mcpr = mcpr.mci_despre_mcpr,
                                      Mci_desres_mcmd = mcmd.mci_desres_mcmd,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
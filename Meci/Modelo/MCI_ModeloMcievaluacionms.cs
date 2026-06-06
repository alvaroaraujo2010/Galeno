//- MARMOTA-GENCODE: VERSION 2.0 - 27/04/2015 05:12:43 PM
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
    /// tabla: mcievaluacionms Maestro evaluaciones
    /// </summary>
    public class ModeloMcievaluacionms : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcms: Código
        private String _mci_idesec_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: mci_idesec_mcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_deseva_mcms: Evaluación
        private String _mci_deseva_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
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
        #region Mci_feceva_mcms: Fecha
        private DateTime _mci_feceva_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Fecha</para>
        /// <para>NOMBRE: mci_feceva_mcms (date:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha Evaluación
        /// </para>
        /// </summary>
        public DateTime Mci_feceva_mcms
        {
            get { return _mci_feceva_mcms; }
            set
            {
                if (_mci_feceva_mcms == value) return;
                _mci_feceva_mcms = value;
                OnPropertyChanged("Mci_feceva_mcms");
            }
        }
        #endregion
        #region Mci_idepla_mcpl: Plantilla
        private String _mci_idepla_mcpl;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: mci_idepla_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo en sistema  de plantilla a utilizar en esta evaluación
        /// </para>
        /// </summary>
        public String Mci_idepla_mcpl
        {
            get { return _mci_idepla_mcpl; }
            set
            {
                if (_mci_idepla_mcpl == value) return;
                _mci_idepla_mcpl = value;
                OnPropertyChanged("Mci_idepla_mcpl");
            }
        }
        #endregion
        #region Mci_estreg_mcms: Estado Evaluación
        private String _mci_estreg_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Estado Evaluación</para>
        /// <para>NOMBRE: mci_estreg_mcms (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado Evaluación 1=Abierta 2= Cerrada
        /// </para>
        /// </summary>
        public String Mci_estreg_mcms
        {
            get { return _mci_estreg_mcms; }
            set
            {
                if (_mci_estreg_mcms == value) return;
                _mci_estreg_mcms = value;
                OnPropertyChanged("Mci_estreg_mcms");
            }
        }
        #endregion
        #region Mci_despla_mcpl: Plantilla
        private String _mci_despla_mcpl;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: mci_despla_mcpl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la plantilla
        /// </para>
        /// </summary>
        public String Mci_despla_mcpl
        {
            get { return _mci_despla_mcpl; }
            set
            {
                if (_mci_despla_mcpl == value) return;
                _mci_despla_mcpl = value;
                OnPropertyChanged("Mci_despla_mcpl");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMcievaluacionms tobjModelo)
        {
            var llgReturn = false;
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIEVALUACIONMS", "MCI", "Maestro de Evaluaciones Meci");
            if (!flgBuscarMcievaluacionms(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmcievaluacionms
                    {
                        #region cargar Registro
                        mci_idesec_mcms = tobjModelo.Mci_idesec_mcms,
                        mci_deseva_mcms = tobjModelo.Mci_deseva_mcms,
                        mci_feceva_mcms = tobjModelo.Mci_feceva_mcms,
                        mci_idepla_mcpl = tobjModelo.Mci_idepla_mcpl,
                        mci_estreg_mcms = tobjModelo.Mci_estreg_mcms,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcms = lcrCodigoGen;
                    _context.AddToMcievaluacionms(lobjRegistro);
                    _context.SaveChanges();
                    llgReturn = true;
                }
                // Generar los registros para las respuestas
                if (llgReturn == true)
                {
                    var tmpPreguntas = ModeloMcipreguntameci.flsListaMcipreguntameciPlantilla(tobjModelo.Mci_idepla_mcpl, "1");
                    if (tmpPreguntas != null)
                    {
                        ModeloMcievaluacionde lobRegDetalle = null;
                        foreach (var lobReg in tmpPreguntas)
                        {
                            lobRegDetalle = new ModeloMcievaluacionde();
                            lobRegDetalle.Mci_idesec_mcdt = String.Empty;
                            lobRegDetalle.Mci_idesec_mcms = lcrCodigoGen;
                            lobRegDetalle.Mci_idesec_mcpl = lobReg.Mci_idesec_mcpl;
                            lobRegDetalle.Mci_idesec_mcmo = lobReg.Mci_idesec_mcmo;
                            lobRegDetalle.Mci_idesec_mcco = lobReg.Mci_idesec_mcco;
                            lobRegDetalle.Mci_idesec_mcpa = lobReg.Mci_idesec_mcpa;
                            lobRegDetalle.Mci_idesec_mcgr = lobReg.Mci_idesec_mcgr;
                            lobRegDetalle.Mci_idesec_mcpr = lobReg.Mci_idesec_mcpr;
                            lobRegDetalle.Mci_idesec_mcmd = String.Empty;
                            lobRegDetalle.Mci_respre_mcmd = String.Empty; 
                            lobRegDetalle.Mci_valpre_mcmd = 0;
                            lobRegDetalle.Mci_eviora_mcdt = String.Empty;
                            lobRegDetalle.Mci_evifis_mcdt = String.Empty;
                            lobRegDetalle.Mci_otrevi_mcdt = String.Empty;
                            lobRegDetalle.Mci_estreg_mcdt = "1";
                            ModeloMcievaluacionde.flgAddRegistro(lobRegDetalle);
                        }
                    }
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIEVALUACIONMS': Maestro de Evaluaciones Meci en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMcievaluacionms tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcievaluacionms.FirstOrDefault(p => p.mci_idesec_mcms == tobjModelo.Mci_idesec_mcms);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcms = tobjModelo.Mci_idesec_mcms;
                    lobjRegistro.mci_deseva_mcms = tobjModelo.Mci_deseva_mcms;
                    lobjRegistro.mci_feceva_mcms = (DateTime)tobjModelo.Mci_feceva_mcms;
                    lobjRegistro.mci_idepla_mcpl = tobjModelo.Mci_idepla_mcpl;
                    lobjRegistro.mci_estreg_mcms = tobjModelo.Mci_estreg_mcms;
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
                var lobjRegistro = _context.Mcievaluacionms.FirstOrDefault(p => p.mci_idesec_mcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIEVALUACIONMS: Logica
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TITULO: Maestro de Evaluaciones Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar las evaluaciones que se realizan con una
        /// plantilla MECI en el sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarMcievaluacionms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcievaluacionms.FirstOrDefault(p => p.mci_idesec_mcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcievaluacionms> flsListaMcievaluacionms(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mcievaluacionms in _context.Mcievaluacionms
                                      join mciplantillmeci in _context.Mciplantillmeci on mcievaluacionms.mci_idepla_mcpl equals mciplantillmeci.mci_idesec_mcpl into tmmciplantillmeci
                                      from mcpl in tmmciplantillmeci.DefaultIfEmpty()
                                      select new ModeloMcievaluacionms
                                      {
                                          Mci_idesec_mcms = mcievaluacionms.mci_idesec_mcms,
                                          Mci_deseva_mcms = mcievaluacionms.mci_deseva_mcms,
                                          Mci_feceva_mcms = (DateTime)mcievaluacionms.mci_feceva_mcms,
                                          Mci_idepla_mcpl = mcievaluacionms.mci_idepla_mcpl,
                                          Mci_estreg_mcms = mcievaluacionms.mci_estreg_mcms,
                                          Mci_despla_mcpl = mcpl.mci_despla_mcpl,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mcievaluacionms in _context.Mcievaluacionms
                                      join mciplantillmeci in _context.Mciplantillmeci on mcievaluacionms.mci_idepla_mcpl equals mciplantillmeci.mci_idesec_mcpl into tmmciplantillmeci
                                      from mcpl in tmmciplantillmeci.DefaultIfEmpty()
                                      where mcievaluacionms.mci_idesec_mcms.Contains(tcrBuscar) || mcievaluacionms.mci_deseva_mcms.Contains(tcrBuscar)
                                      select new ModeloMcievaluacionms
                                      {
                                          Mci_idesec_mcms = mcievaluacionms.mci_idesec_mcms,
                                          Mci_deseva_mcms = mcievaluacionms.mci_deseva_mcms,
                                          Mci_feceva_mcms = (DateTime)mcievaluacionms.mci_feceva_mcms,
                                          Mci_idepla_mcpl = mcievaluacionms.mci_idepla_mcpl,
                                          Mci_estreg_mcms = mcievaluacionms.mci_estreg_mcms,
                                          Mci_despla_mcpl = mcpl.mci_despla_mcpl,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
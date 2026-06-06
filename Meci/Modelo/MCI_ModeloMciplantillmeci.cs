//- MARMOTA-GENCODE: VERSION 2.0 - 21/04/2015 10:16:58 PM
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
    /// Descripcion para la Vista de  la tabla: mciplantillmeci
    /// </summary>
    public class ModeloMciplantillmeci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcpl: Código
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_despla_mcpl: Plantilla
        private String _mci_despla_mcpl;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
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
        #region Mci_secdet_mcpl: Secuencial detalle MCPL
        private int _mci_secdet_mcpl;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Secuencial detalle MCPL</para>
        /// <para>NOMBRE: mci_secdet_mcpl (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los módulos de una plantilla
        /// </para>
        /// </summary>
        public int Mci_secdet_mcpl
        {
            get { return _mci_secdet_mcpl; }
            set
            {
                if (_mci_secdet_mcpl == value) return;
                _mci_secdet_mcpl = value;
                OnPropertyChanged("Mci_secdet_mcpl");
            }
        }
        #endregion
        #region Mci_estreg_mcpl: Estado
        private String _mci_estreg_mcpl;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: mci_estreg_mcpl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla
        /// </para>
        /// </summary>
        public String Mci_estreg_mcpl
        {
            get { return _mci_estreg_mcpl; }
            set
            {
                if (_mci_estreg_mcpl == value) return;
                _mci_estreg_mcpl = value;
                OnPropertyChanged("Mci_estreg_mcpl");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMciplantillmeci tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIPLANTILLMECI", "MCI", "PLANTILLAS DE EVALUACIÓN");
            if (!flgBuscarMciplantillmeci(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmciplantillmeci
                    {
                        #region cargar Registro
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_despla_mcpl = tobjModelo.Mci_despla_mcpl,
                        mci_secdet_mcpl = tobjModelo.Mci_secdet_mcpl,
                        mci_estreg_mcpl = tobjModelo.Mci_estreg_mcpl,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcpl = lcrCodigoGen;
                    _context.AddToMciplantillmeci(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIPLANTILLMECI': PLANTILLAS DE EVALUACIÓN en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMciplantillmeci tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tobjModelo.Mci_idesec_mcpl);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_despla_mcpl = tobjModelo.Mci_despla_mcpl;
                    lobjRegistro.mci_secdet_mcpl = (int)tobjModelo.Mci_secdet_mcpl;
                    lobjRegistro.mci_estreg_mcpl = tobjModelo.Mci_estreg_mcpl;
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
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIPLANTILLMECI: Logica
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TITULO: PLANTILLAS DE EVALUACIÓN</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las plantillas a utilizar
        /// en una evaluación
        /// </para>
        /// </summary>
        public static bool flgBuscarMciplantillmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMciplantillmeci> flsListaMciplantillmeci(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mciplantillmeci in _context.Mciplantillmeci
                                      select new ModeloMciplantillmeci
                                      {
                                          Mci_idesec_mcpl = mciplantillmeci.mci_idesec_mcpl,
                                          Mci_despla_mcpl = mciplantillmeci.mci_despla_mcpl,
                                          Mci_secdet_mcpl = (int)mciplantillmeci.mci_secdet_mcpl,
                                          Mci_estreg_mcpl = mciplantillmeci.mci_estreg_mcpl,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mciplantillmeci in _context.Mciplantillmeci
                                      where mciplantillmeci.mci_idesec_mcpl.Contains(tcrBuscar) || mciplantillmeci.mci_despla_mcpl.Contains(tcrBuscar)
                                      select new ModeloMciplantillmeci
                                      {
                                          Mci_idesec_mcpl = mciplantillmeci.mci_idesec_mcpl,
                                          Mci_despla_mcpl = mciplantillmeci.mci_despla_mcpl,
                                          Mci_secdet_mcpl = (int)mciplantillmeci.mci_secdet_mcpl,
                                          Mci_estreg_mcpl = mciplantillmeci.mci_estreg_mcpl,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: mcimoduloevmeci
    /// </summary>
    public class ModeloMcimoduloevmeci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcmo: Código Módulo
        private String _mci_idesec_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: mci_idesec_mcmo (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_idesec_mcpl: Código
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código</para>
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
        #region Mci_etqpla_mcmo: Etiqueta
        private String _mci_etqpla_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Etiqueta</para>
        /// <para>NOMBRE: mci_etqpla_mcmo (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public String Mci_etqpla_mcmo
        {
            get { return _mci_etqpla_mcmo; }
            set
            {
                if (_mci_etqpla_mcmo == value) return;
                _mci_etqpla_mcmo = value;
                OnPropertyChanged("Mci_etqpla_mcmo");
            }
        }
        #endregion
        #region Mci_desmod_mcmo: Descripción
        private String _mci_desmod_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: mci_desmod_mcmo (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción
        /// </para>
        /// </summary>
        public String Mci_desmod_mcmo
        {
            get { return _mci_desmod_mcmo; }
            set
            {
                if (_mci_desmod_mcmo == value) return;
                _mci_desmod_mcmo = value;
                OnPropertyChanged("Mci_desmod_mcmo");
            }
        }
        #endregion
        #region Mci_ordvis_mcmo: Orden
        private int _mci_ordvis_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Orden</para>
        /// <para>NOMBRE: mci_ordvis_mcmo (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int Mci_ordvis_mcmo
        {
            get { return _mci_ordvis_mcmo; }
            set
            {
                if (_mci_ordvis_mcmo == value) return;
                _mci_ordvis_mcmo = value;
                OnPropertyChanged("Mci_ordvis_mcmo");
            }
        }
        #endregion
        #region Mci_secdet_mcmo: Secuencial detalle MCMO
        private int _mci_secdet_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Secuencial detalle MCMO</para>
        /// <para>NOMBRE: mci_secdet_mcmo (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los componentes en módulos
        /// </para>
        /// </summary>
        public int Mci_secdet_mcmo
        {
            get { return _mci_secdet_mcmo; }
            set
            {
                if (_mci_secdet_mcmo == value) return;
                _mci_secdet_mcmo = value;
                OnPropertyChanged("Mci_secdet_mcmo");
            }
        }
        #endregion
        #region Mci_estreg_mcmo: Estado
        private String _mci_estreg_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: mci_estreg_mcmo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado Módulo
        /// </para>
        /// </summary>
        public String Mci_estreg_mcmo
        {
            get { return _mci_estreg_mcmo; }
            set
            {
                if (_mci_estreg_mcmo == value) return;
                _mci_estreg_mcmo = value;
                OnPropertyChanged("Mci_estreg_mcmo");
            }
        }
        #endregion
        #region Mci_despla_mcpl: Plantilla
        private String _mci_despla_mcpl;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
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
        #region Sis_estado_imaen: Estado del registro para edicion
        private string _sis_estado_imaen;
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloMcimoduloevmeci tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFmcimoduloevmeci();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tobTempReg.Mci_idesec_mcmo);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.mci_idesec_mcmo = tobTempReg.Mci_idesec_mcmo;
                            lobEFReg.mci_idesec_mcpl = tobTempReg.Mci_idesec_mcpl;
                            lobEFReg.mci_etqmod_mcmo = tobTempReg.Mci_etqpla_mcmo;
                            lobEFReg.mci_desmod_mcmo = tobTempReg.Mci_desmod_mcmo;
                            lobEFReg.mci_ordvis_mcmo = tobTempReg.Mci_ordvis_mcmo;
                            lobEFReg.mci_secdet_mcmo = (int)tobTempReg.Mci_secdet_mcmo;
                            lobEFReg.mci_estreg_mcmo = tobTempReg.Mci_estreg_mcmo;
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
                                lobEFReg.mci_idesec_mcmo = tcrCodigoR1 + lobEFReg.mci_idesec_mcmo; // concatenar
                                _context.AddToMcimoduloevmeci(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tobTempReg.Mci_idesec_mcmo);
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
            catch (NotImplementedException ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIMODULOEVMECI: Logica
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TITULO: MÓDULOS PLANTILLA EVALUACIÓN MECI</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los módulos pertenecientes a una plantilla de evaluación
        /// de MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcimoduloevmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcimoduloevmeci> flsListaMcimoduloevmeci(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from mcimoduloevmeci in _context.Mcimoduloevmeci
                                  join mciplantillmeci in _context.Mciplantillmeci on mcimoduloevmeci.mci_idesec_mcpl equals mciplantillmeci.mci_idesec_mcpl into tmmciplantillmeci
                                  from mcpl in tmmciplantillmeci.DefaultIfEmpty()
                                  where mcimoduloevmeci.mci_idesec_mcpl == tcrBuscar
                                  select new ModeloMcimoduloevmeci
                                  {
                                      Mci_idesec_mcmo = mcimoduloevmeci.mci_idesec_mcmo,
                                      Mci_idesec_mcpl = mcimoduloevmeci.mci_idesec_mcpl,
                                      Mci_etqpla_mcmo = mcimoduloevmeci.mci_etqmod_mcmo,
                                      Mci_desmod_mcmo = mcimoduloevmeci.mci_desmod_mcmo,
                                      Mci_ordvis_mcmo = (int)mcimoduloevmeci.mci_ordvis_mcmo,
                                      Mci_secdet_mcmo = (int)mcimoduloevmeci.mci_secdet_mcmo,
                                      Mci_estreg_mcmo = mcimoduloevmeci.mci_estreg_mcmo,
                                      Mci_despla_mcpl = mcpl.mci_despla_mcpl,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
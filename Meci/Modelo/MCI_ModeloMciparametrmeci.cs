//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 07:33:26 AM
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
    /// Descripcion para la Vista de  la tabla: mciparametrmeci
    /// </summary>
    public class ModeloMciparametrmeci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcpa: Código de Parámetro
        private String _mci_idesec_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Código de Parámetro</para>
        /// <para>NOMBRE: mci_idesec_mcpa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_idesec_mcpl: Código Plantilla
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
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
        /// <para>TABLA: mciparametrmeci</para>
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
        /// <para>TABLA: mciparametrmeci</para>
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
        #region Mci_etqpar_mcpa: Etiqueta Parámetro
        private String _mci_etqpar_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Etiqueta Parámetro</para>
        /// <para>NOMBRE: mci_etqpar_mcpa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Etiqueta Parámetro
        /// </para>
        /// </summary>
        public String Mci_etqpar_mcpa
        {
            get { return _mci_etqpar_mcpa; }
            set
            {
                if (_mci_etqpar_mcpa == value) return;
                _mci_etqpar_mcpa = value;
                OnPropertyChanged("Mci_etqpar_mcpa");
            }
        }
        #endregion
        #region Mci_despar_mcpa: Descripción parámetro
        private String _mci_despar_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
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
        #region Mci_ordvis_mcpa: Orden Vista
        private int _mci_ordvis_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: mci_ordvis_mcpa (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int Mci_ordvis_mcpa
        {
            get { return _mci_ordvis_mcpa; }
            set
            {
                if (_mci_ordvis_mcpa == value) return;
                _mci_ordvis_mcpa = value;
                OnPropertyChanged("Mci_ordvis_mcpa");
            }
        }
        #endregion
        #region Mci_secdet_mcpa: Secuencial detalle MCPA
        private int _mci_secdet_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Secuencial detalle MCPA</para>
        /// <para>NOMBRE: mci_secdet_mcpa (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los grupos dentro de parámetros
        /// </para>
        /// </summary>
        public int Mci_secdet_mcpa
        {
            get { return _mci_secdet_mcpa; }
            set
            {
                if (_mci_secdet_mcpa == value) return;
                _mci_secdet_mcpa = value;
                OnPropertyChanged("Mci_secdet_mcpa");
            }
        }
        #endregion
        #region Mci_estreg_mcpa: Estado del parámetro
        private String _mci_estreg_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Estado del parámetro</para>
        /// <para>NOMBRE: mci_estreg_mcpa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del parámetro
        /// </para>
        /// </summary>
        public String Mci_estreg_mcpa
        {
            get { return _mci_estreg_mcpa; }
            set
            {
                if (_mci_estreg_mcpa == value) return;
                _mci_estreg_mcpa = value;
                OnPropertyChanged("Mci_estreg_mcpa");
            }
        }
        #endregion
        #region Mci_descom_mcco: Descripción Componente
        private String _mci_descom_mcco;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Descripción Componente</para>
        /// <para>NOMBRE: mci_descom_mcco (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción componente
        /// </para>
        /// </summary>
        public String Mci_descom_mcco
        {
            get { return _mci_descom_mcco; }
            set
            {
                if (_mci_descom_mcco == value) return;
                _mci_descom_mcco = value;
                OnPropertyChanged("Mci_descom_mcco");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMciparametrmeci tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCIPARAMETRMECI", "MCI", "Parametros en Componentes de Módulos Meci");
            if (!flgBuscarMciparametrmeci(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmciparametrmeci
                    {
                        #region cargar Registro
                        mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa,
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo,
                        mci_idesec_mcco = tobjModelo.Mci_idesec_mcco,
                        mci_etqpar_mcpa = tobjModelo.Mci_etqpar_mcpa,
                        mci_despar_mcpa = tobjModelo.Mci_despar_mcpa,
                        mci_ordvis_mcpa = tobjModelo.Mci_ordvis_mcpa,
                        mci_secdet_mcpa = tobjModelo.Mci_secdet_mcpa,
                        mci_estreg_mcpa = tobjModelo.Mci_estreg_mcpa,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcpa = lcrCodigoGen;
                    _context.AddToMciparametrmeci(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCIPARAMETRMECI': Parametros en Componentes de Módulos Meci en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMciparametrmeci tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tobjModelo.Mci_idesec_mcpa);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcpa = tobjModelo.Mci_idesec_mcpa;
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo;
                    lobjRegistro.mci_idesec_mcco = tobjModelo.Mci_idesec_mcco;
                    lobjRegistro.mci_etqpar_mcpa = tobjModelo.Mci_etqpar_mcpa;
                    lobjRegistro.mci_despar_mcpa = tobjModelo.Mci_despar_mcpa;
                    lobjRegistro.mci_ordvis_mcpa = tobjModelo.Mci_ordvis_mcpa;
                    lobjRegistro.mci_secdet_mcpa = (int)tobjModelo.Mci_secdet_mcpa;
                    lobjRegistro.mci_estreg_mcpa = tobjModelo.Mci_estreg_mcpa;
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
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCIPARAMETRMECI: Logica
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TITULO: Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los parámetros dentro de los componentes pertenecientes
        /// a los módulos de las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMciparametrmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMciparametrmeci> flsListaMciparametrmeci(String tcrIdComponente, string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mciparametrmeci in _context.Mciparametrmeci
                                      join mcicomponenmeci in _context.Mcicomponenmeci on mciparametrmeci.mci_idesec_mcco equals mcicomponenmeci.mci_idesec_mcco into tmmcicomponenmeci
                                      from mcco in tmmcicomponenmeci.DefaultIfEmpty()
                                      where mciparametrmeci.mci_idesec_mcco.Equals(tcrIdComponente)
                                      select new ModeloMciparametrmeci
                                      {
                                          Mci_idesec_mcpa = mciparametrmeci.mci_idesec_mcpa,
                                          Mci_idesec_mcpl = mciparametrmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mciparametrmeci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mciparametrmeci.mci_idesec_mcco,
                                          Mci_etqpar_mcpa = mciparametrmeci.mci_etqpar_mcpa,
                                          Mci_despar_mcpa = mciparametrmeci.mci_despar_mcpa,
                                          Mci_ordvis_mcpa = (int)mciparametrmeci.mci_ordvis_mcpa,
                                          Mci_secdet_mcpa = (int)mciparametrmeci.mci_secdet_mcpa,
                                          Mci_estreg_mcpa = mciparametrmeci.mci_estreg_mcpa,
                                          Mci_descom_mcco = mcco.mci_descom_mcco,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mciparametrmeci in _context.Mciparametrmeci
                                      join mcicomponenmeci in _context.Mcicomponenmeci on mciparametrmeci.mci_idesec_mcco equals mcicomponenmeci.mci_idesec_mcco into tmmcicomponenmeci
                                      from mcco in tmmcicomponenmeci.DefaultIfEmpty()
                                      where mciparametrmeci.mci_idesec_mcco.Equals(tcrIdComponente) &&
                                            mciparametrmeci.mci_despar_mcpa.Contains(tcrBuscar) || 
                                            mciparametrmeci.mci_idesec_mcpa.Contains(tcrBuscar)

                                      select new ModeloMciparametrmeci
                                      {
                                          Mci_idesec_mcpa = mciparametrmeci.mci_idesec_mcpa,
                                          Mci_idesec_mcpl = mciparametrmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mciparametrmeci.mci_idesec_mcmo,
                                          Mci_idesec_mcco = mciparametrmeci.mci_idesec_mcco,
                                          Mci_etqpar_mcpa = mciparametrmeci.mci_etqpar_mcpa,
                                          Mci_despar_mcpa = mciparametrmeci.mci_despar_mcpa,
                                          Mci_ordvis_mcpa = (int)mciparametrmeci.mci_ordvis_mcpa,
                                          Mci_secdet_mcpa = (int)mciparametrmeci.mci_secdet_mcpa,
                                          Mci_estreg_mcpa = mciparametrmeci.mci_estreg_mcpa,
                                          Mci_descom_mcco = mcco.mci_descom_mcco,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
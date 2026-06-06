//- MARMOTA-GENCODE: VERSION 2.0 - 23/04/2015 05:16:15 PM
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
    /// Descripcion para la Vista de  la tabla: mcicomponenmeci
    /// </summary>
    public class ModeloMcicomponenmeci : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Mci_idesec_mcco: Código de Componente
        private String _mci_idesec_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Código de Componente</para>
        /// <para>NOMBRE: mci_idesec_mcco (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region Mci_idesec_mcpl: Código Plantilla
        private String _mci_idesec_mcpl;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
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
        /// <para>TABLA: mcicomponenmeci</para>
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
        #region Mci_etqcom_mcco: Etiqueta Componente
        private String _mci_etqcom_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Etiqueta Componente</para>
        /// <para>NOMBRE: mci_etqcom_mcco (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Etiqueta componente
        /// </para>
        /// </summary>
        public String Mci_etqcom_mcco
        {
            get { return _mci_etqcom_mcco; }
            set
            {
                if (_mci_etqcom_mcco == value) return;
                _mci_etqcom_mcco = value;
                OnPropertyChanged("Mci_etqcom_mcco");
            }
        }
        #endregion
        #region Mci_descom_mcco: Descripción Componente
        private String _mci_descom_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
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
        #region Mci_ordvis_mcco: Orden Vista
        private int _mci_ordvis_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: mci_ordvis_mcco (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int Mci_ordvis_mcco
        {
            get { return _mci_ordvis_mcco; }
            set
            {
                if (_mci_ordvis_mcco == value) return;
                _mci_ordvis_mcco = value;
                OnPropertyChanged("Mci_ordvis_mcco");
            }
        }
        #endregion
        #region Mci_secdet_mcco: Secuencial detalle MCCO
        private int _mci_secdet_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Secuencial detalle MCCO</para>
        /// <para>NOMBRE: mci_secdet_mcco (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los parámetros en componentes
        /// </para>
        /// </summary>
        public int Mci_secdet_mcco
        {
            get { return _mci_secdet_mcco; }
            set
            {
                if (_mci_secdet_mcco == value) return;
                _mci_secdet_mcco = value;
                OnPropertyChanged("Mci_secdet_mcco");
            }
        }
        #endregion
        #region Mci_estreg_mcco: Estado del Componente
        private String _mci_estreg_mcco;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Estado del Componente</para>
        /// <para>NOMBRE: mci_estreg_mcco (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Estado del componente
        /// </para>
        /// </summary>
        public String Mci_estreg_mcco
        {
            get { return _mci_estreg_mcco; }
            set
            {
                if (_mci_estreg_mcco == value) return;
                _mci_estreg_mcco = value;
                OnPropertyChanged("Mci_estreg_mcco");
            }
        }
        #endregion
        #region Mci_desmod_mcmo: Descripción Plantilla
        private String _mci_desmod_mcmo;
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Descripción Plantilla</para>
        /// <para>NOMBRE: mci_desmod_mcmo (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción para la Plantilla
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
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloMcicomponenmeci tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("MCI-MCICOMPONENMECI", "MCI", "Componentes de los Módulos Meci");
            if (!flgBuscarMcicomponenmeci(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFmcicomponenmeci
                    {
                        #region cargar Registro
                        mci_idesec_mcco = tobjModelo.Mci_idesec_mcco,
                        mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl,
                        mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo,
                        mci_etqcom_mcco = tobjModelo.Mci_etqcom_mcco,
                        mci_descom_mcco = tobjModelo.Mci_descom_mcco,
                        mci_ordvis_mcco = tobjModelo.Mci_ordvis_mcco,
                        mci_secdet_mcco = tobjModelo.Mci_secdet_mcco,
                        mci_estreg_mcco = tobjModelo.Mci_estreg_mcco,
                        #endregion
                    };
                    lobjRegistro.mci_idesec_mcco = lcrCodigoGen;
                    _context.AddToMcicomponenmeci(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'MCI-MCICOMPONENMECI': Componentes de los Módulos Meci en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloMcicomponenmeci tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tobjModelo.Mci_idesec_mcco);
                if (lobjRegistro != null)
                {
                    lobjRegistro.mci_idesec_mcco = tobjModelo.Mci_idesec_mcco;
                    lobjRegistro.mci_idesec_mcpl = tobjModelo.Mci_idesec_mcpl;
                    lobjRegistro.mci_idesec_mcmo = tobjModelo.Mci_idesec_mcmo;
                    lobjRegistro.mci_etqcom_mcco = tobjModelo.Mci_etqcom_mcco;
                    lobjRegistro.mci_descom_mcco = tobjModelo.Mci_descom_mcco;
                    lobjRegistro.mci_ordvis_mcco = (int)tobjModelo.Mci_ordvis_mcco;
                    lobjRegistro.mci_secdet_mcco = (int)tobjModelo.Mci_secdet_mcco;
                    lobjRegistro.mci_estreg_mcco = tobjModelo.Mci_estreg_mcco;
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
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar MCICOMPONENMECI: Logica
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TITULO: Componentes de los Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los componentes pertenecientes a los módulos de
        /// las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcicomponenmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloMcicomponenmeci> flsListaMcicomponenmeci(String tcrIdModulo, string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from mcicomponenmeci in _context.Mcicomponenmeci
                                      join mcimoduloevmeci in _context.Mcimoduloevmeci on mcicomponenmeci.mci_idesec_mcmo equals mcimoduloevmeci.mci_idesec_mcmo into tmmcimoduloevmeci
                                      from mcmo in tmmcimoduloevmeci.DefaultIfEmpty()
                                      where mcicomponenmeci.mci_idesec_mcmo.Equals(tcrIdModulo) 
                                      select new ModeloMcicomponenmeci
                                      {
                                          Mci_idesec_mcco = mcicomponenmeci.mci_idesec_mcco,
                                          Mci_idesec_mcpl = mcicomponenmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcicomponenmeci.mci_idesec_mcmo,
                                          Mci_etqcom_mcco = mcicomponenmeci.mci_etqcom_mcco,
                                          Mci_descom_mcco = mcicomponenmeci.mci_descom_mcco,
                                          Mci_ordvis_mcco = (int)mcicomponenmeci.mci_ordvis_mcco,
                                          Mci_secdet_mcco = (int)mcicomponenmeci.mci_secdet_mcco,
                                          Mci_estreg_mcco = mcicomponenmeci.mci_estreg_mcco,
                                          Mci_desmod_mcmo = mcmo.mci_desmod_mcmo,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from mcicomponenmeci in _context.Mcicomponenmeci
                                      join mcimoduloevmeci in _context.Mcimoduloevmeci on mcicomponenmeci.mci_idesec_mcmo equals mcimoduloevmeci.mci_idesec_mcmo into tmmcimoduloevmeci
                                      from mcmo in tmmcimoduloevmeci.DefaultIfEmpty()
                                      where mcicomponenmeci.mci_idesec_mcmo.Equals(tcrIdModulo) &&
                                           (mcicomponenmeci.mci_descom_mcco.Contains(tcrBuscar) ||
                                           mcicomponenmeci.mci_idesec_mcco.Contains(tcrBuscar))
                                      select new ModeloMcicomponenmeci
                                      {
                                          Mci_idesec_mcco = mcicomponenmeci.mci_idesec_mcco,
                                          Mci_idesec_mcpl = mcicomponenmeci.mci_idesec_mcpl,
                                          Mci_idesec_mcmo = mcicomponenmeci.mci_idesec_mcmo,
                                          Mci_etqcom_mcco = mcicomponenmeci.mci_etqcom_mcco,
                                          Mci_descom_mcco = mcicomponenmeci.mci_descom_mcco,
                                          Mci_ordvis_mcco = (int)mcicomponenmeci.mci_ordvis_mcco,
                                          Mci_secdet_mcco = (int)mcicomponenmeci.mci_secdet_mcco,
                                          Mci_estreg_mcco = mcicomponenmeci.mci_estreg_mcco,
                                          Mci_desmod_mcmo = mcmo.mci_desmod_mcmo,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
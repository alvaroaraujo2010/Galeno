//- MARMOTA-GENCODE: VERSION 2.0 - 16/08/2017 06:15:05 PM
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

namespace Inventarios.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invperiodomaest
    /// </summary>
    public class ModeloInvperiodomaest : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_codper_inpe: Código periodo
        private String _inv_codper_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Código periodo</para>
        /// <para>NOMBRE: inv_codper_inpe (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes
        /// febrero = 201602
        /// </para>
        /// </summary>
        public String Inv_codper_inpe
        {
            get { return _inv_codper_inpe; }
            set
            {
                if (_inv_codper_inpe == value) return;
                _inv_codper_inpe = value;
                OnPropertyChanged("Inv_codper_inpe");
            }
        }
        #endregion
        #region Inv_desper_inpe: Descripcion
        private String _inv_desper_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: inv_desper_inpe (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del periodo
        /// </para>
        /// </summary>
        public String Inv_desper_inpe
        {
            get { return _inv_desper_inpe; }
            set
            {
                if (_inv_desper_inpe == value) return;
                _inv_desper_inpe = value;
                OnPropertyChanged("Inv_desper_inpe");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
        /// </para>
        /// </summary>
        public String Inv_codalm_inal
        {
            get { return _inv_codalm_inal; }
            set
            {
                if (_inv_codalm_inal == value) return;
                _inv_codalm_inal = value;
                OnPropertyChanged("Inv_codalm_inal");
            }
        }
        #endregion
        #region Inv_fecini_inpe: Fecha inicio
        private DateTime _inv_fecini_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Fecha inicio</para>
        /// <para>NOMBRE: inv_fecini_inpe (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha inicio perodo
        /// </para>
        /// </summary>
        public DateTime Inv_fecini_inpe
        {
            get { return _inv_fecini_inpe; }
            set
            {
                if (_inv_fecini_inpe == value) return;
                _inv_fecini_inpe = value;
                OnPropertyChanged("Inv_fecini_inpe");
            }
        }
        #endregion
        #region Inv_fecfin_inpe: Fecha fin
        private DateTime _inv_fecfin_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Fecha fin</para>
        /// <para>NOMBRE: inv_fecfin_inpe (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha fin del perodo
        /// </para>
        /// </summary>
        public DateTime Inv_fecfin_inpe
        {
            get { return _inv_fecfin_inpe; }
            set
            {
                if (_inv_fecfin_inpe == value) return;
                _inv_fecfin_inpe = value;
                OnPropertyChanged("Inv_fecfin_inpe");
            }
        }
        #endregion
        #region Inv_peract_inpe: Estado periodo
        private String _inv_peract_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: inv_peract_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Periodo activo gestion actual:  1=Periodo actual de gestion
        /// 2=Periodo anterior 3=Cerrado
        /// </para>
        /// </summary>
        public String Inv_peract_inpe
        {
            get { return _inv_peract_inpe; }
            set
            {
                if (_inv_peract_inpe == value) return;
                _inv_peract_inpe = value;
                OnPropertyChanged("Inv_peract_inpe");
            }
        }
        #endregion
        #region Inv_estreg_inpe: Estado Registro
        private String _inv_estreg_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: inv_estreg_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Abierto 2=Cerrado
        /// </para>
        /// </summary>
        public String Inv_estreg_inpe
        {
            get { return _inv_estreg_inpe; }
            set
            {
                if (_inv_estreg_inpe == value) return;
                _inv_estreg_inpe = value;
                OnPropertyChanged("Inv_estreg_inpe");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public String Inv_desalm_inal
        {
            get { return _inv_desalm_inal; }
            set
            {
                if (_inv_desalm_inal == value) return;
                _inv_desalm_inal = value;
                OnPropertyChanged("Inv_desalm_inal");
            }
        }
        #endregion
        #region Inv_desperact_inpe: Descripción estado periodo
        private String _inv_desperact_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripción estado periodo</para>
        /// <para>NOMBRE: inv_desperact_inpe (char:60)</para>        
        /// <para>DESCRIPCION:
        ///Descripción estado periodo
        /// </para>
        /// </summary>
        public String Inv_desperact_inpe
        {
            get { return _inv_desperact_inpe; }
            set
            {
                if (_inv_desperact_inpe == value) return;
                _inv_desperact_inpe = value;
                OnPropertyChanged("Inv_desperact_inpe");
            }
        }
        #endregion
        #region Inv_destreg_inpe: Descripción estado registro
        private String _inv_destreg_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripción estado registro</para>
        /// <para>NOMBRE: inv_destreg_inpe (char:60)</para>        
        /// <para>DESCRIPCION:
        ///Descripción estado registro
        /// </para>
        /// </summary>
        public String Inv_destreg_inpe
        {
            get { return _inv_destreg_inpe; }
            set
            {
                if (_inv_destreg_inpe == value) return;
                _inv_destreg_inpe = value;
                OnPropertyChanged("Inv_destreg_inpe");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvperiodomaest tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-MAESTRO-PERIODO", "INV", "Codigo unico registro para maestro periodos de inventario");
            try
            {
                if (!flgBuscarInvperiodomaest(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvperiodomaest
                        {
                            #region cargar Registro
                            inv_codper_inpe = tobjModelo.Inv_codper_inpe,
                            inv_desper_inpe = tobjModelo.Inv_desper_inpe,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            inv_fecini_inpe = tobjModelo.Inv_fecini_inpe,
                            inv_fecfin_inpe = tobjModelo.Inv_fecfin_inpe,
                            inv_peract_inpe = tobjModelo.Inv_peract_inpe,
                            inv_estreg_inpe = tobjModelo.Inv_estreg_inpe,
                            #endregion
                        };
                        lobjRegistro.inv_codper_inpe = lcrCodigoGen;
                        _context.AddToInvperiodomaest(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-MAESTRO-PERIODO': Codigo grupo actividad para vista captura Historia clinica en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvperiodomaest tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tobjModelo.Inv_codper_inpe);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_codper_inpe = tobjModelo.Inv_codper_inpe;
                        lobjRegistro.inv_desper_inpe = tobjModelo.Inv_desper_inpe;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_fecini_inpe = (DateTime)tobjModelo.Inv_fecini_inpe;
                        lobjRegistro.inv_fecfin_inpe = (DateTime)tobjModelo.Inv_fecfin_inpe;
                        lobjRegistro.inv_peract_inpe = tobjModelo.Inv_peract_inpe;
                        lobjRegistro.inv_estreg_inpe = tobjModelo.Inv_estreg_inpe;
                        #endregion
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
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tcrCodigo);
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
        #region Buscar INVPERIODOMAEST: Logica
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TITULO: Maestro gestion periodos inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro gestion periodos inventario para control de cierres
        /// y demas
        /// </para>
        /// </summary>
        public static bool flgBuscarInvperiodomaest(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invperiodomaest.FirstOrDefault(p => p.inv_codper_inpe == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvperiodomaest> flsListaInvperiodomaest(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invperiodomaest in _context.Invperiodomaest
                                      join invalmacenmaest in _context.Invalmacenmaest on invperiodomaest.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      select new ModeloInvperiodomaest
                                      {
                                          #region Datos
                                          Inv_codper_inpe = invperiodomaest.inv_codper_inpe,
                                          Inv_desper_inpe = invperiodomaest.inv_desper_inpe,
                                          Inv_codalm_inal = invperiodomaest.inv_codalm_inal,
                                          Inv_fecini_inpe = (DateTime)invperiodomaest.inv_fecini_inpe,
                                          Inv_fecfin_inpe = (DateTime)invperiodomaest.inv_fecfin_inpe,
                                          Inv_peract_inpe = invperiodomaest.inv_peract_inpe,
                                          Inv_estreg_inpe = invperiodomaest.inv_estreg_inpe,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_desperact_inpe = invperiodomaest.inv_peract_inpe == "1" ? "Periodo actual de gestion" : invperiodomaest.inv_peract_inpe == "2" ? "Periodo anterior" : "Cerrado",
                                          Inv_destreg_inpe = invperiodomaest.inv_estreg_inpe == "1" ? "Abierto" : "Cerrado",
                                          #endregion 
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invperiodomaest in _context.Invperiodomaest
                                      join invalmacenmaest in _context.Invalmacenmaest on invperiodomaest.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      where invperiodomaest.inv_codper_inpe.Contains(tcrBuscar) ||
                                            invperiodomaest.inv_desper_inpe.Contains(tcrBuscar) ||
                                            invperiodomaest.inv_codalm_inal.Contains(tcrBuscar) ||
                                            inal.inv_desalm_inal.Contains(tcrBuscar)

                                      select new ModeloInvperiodomaest
                                      {
                                          #region Datos
                                          Inv_codper_inpe = invperiodomaest.inv_codper_inpe,
                                          Inv_desper_inpe = invperiodomaest.inv_desper_inpe,
                                          Inv_codalm_inal = invperiodomaest.inv_codalm_inal,
                                          Inv_fecini_inpe = (DateTime)invperiodomaest.inv_fecini_inpe,
                                          Inv_fecfin_inpe = (DateTime)invperiodomaest.inv_fecfin_inpe,
                                          Inv_peract_inpe = invperiodomaest.inv_peract_inpe,
                                          Inv_estreg_inpe = invperiodomaest.inv_estreg_inpe,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_desperact_inpe = invperiodomaest.inv_peract_inpe == "1" ? "Periodo actual de gestion" : invperiodomaest.inv_peract_inpe == "2" ? "Periodo anterior" : "Cerrado",
                                          Inv_destreg_inpe = invperiodomaest.inv_estreg_inpe == "1" ? "Abierto" : "Cerrado",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
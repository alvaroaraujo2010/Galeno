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
    /// Descripcion para la Vista de la tabla: invajusteconcep
    /// </summary>
    public class ModeloInvajusteconcep : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_conaju_incp: Codigo concepto ajuste
        private String _inv_conaju_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Codigo Concepto Ajuste</para>
        /// <para>NOMBRE: inv_conaju_incp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///  Código concepto de Ajuste inventario: 01=Por reconteo inventario 
        /// 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro del producto y otros
        /// </para>
        /// </summary>
        public String Inv_conaju_incp
        {
            get { return _inv_conaju_incp; }
            set
            {
                if (_inv_conaju_incp == value) return;
                _inv_conaju_incp = value;
                OnPropertyChanged("Inv_conaju_incp");
            }
        }
        #endregion
        #region Inv_desaju_incp: Descripción Concepto
        private String _inv_desaju_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Descripción Concepto</para>
        /// <para>NOMBRE: inv_desaju_incp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///  Descripción Concepto de Ajuste
        /// </para>
        /// </summary>
        public String Inv_desaju_incp
        {
            get { return _inv_desaju_incp; }
            set
            {
                if (_inv_desaju_incp == value) return;
                _inv_desaju_incp = value;
                OnPropertyChanged("Inv_desaju_incp");
            }
        }
        #endregion
        #region Inv_tipaju_incp: Tipo de Ajuste
        private String _inv_tipaju_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Tipo de Ajuste</para>
        /// <para>NOMBRE: inv_tipaju_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///  Tipo ajuste 1= Reconteo Total inventario 2= Por suma o Resta de Unidades
        /// </para>
        /// </summary>
        public String Inv_tipaju_incp
        {
            get { return _inv_tipaju_incp; }
            set
            {
                if (_inv_tipaju_incp == value) return;
                _inv_tipaju_incp = value;
                OnPropertyChanged("Inv_tipaju_incp");
            }
        }
        #endregion
        #region Inv_conmov_incm: Concepto de Movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto de Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///  Concepto movimiento diario: E11 =Entrada saldo inicial inventario o del mes E12= Entradas compras ...  
        ///  S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras 
        ///  Áreas Empresa S24= Salida entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_descon_incm : Descripcion concepto movimiento
        private String _inv_descon_incm;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripcion concepto movimiento</para>
        /// <para>NOMBRE: inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///  Descripcion concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm
        {
            get { return _inv_descon_incm; }
            set
            {
                if (_inv_descon_incm == value) return;
                _inv_descon_incm = value;
                OnPropertyChanged("Inv_descon_incm ");
            }
        }
        #endregion
        #region Inv_estreg_incp: Estado del registro
        private String _inv_estreg_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: inv_estreg_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///  Estado del registro 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Inv_estreg_incp
        {
            get { return _inv_estreg_incp; }
            set
            {
                if (_inv_estreg_incp == value) return;
                _inv_estreg_incp = value;
                OnPropertyChanged("Inv_estreg_incp");
            }
        }
        #endregion

        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvajusteconcep tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFinvajusteconcep
                    {
                        #region cargar Registro
                        inv_conaju_incp = tobjModelo.Inv_conaju_incp,
                        inv_desaju_incp = tobjModelo.Inv_desaju_incp,
                        inv_tipaju_incp = tobjModelo.Inv_tipaju_incp,
                        inv_conmov_incm = tobjModelo.Inv_conmov_incm,
                        inv_estreg_incp = tobjModelo.Inv_estreg_incp,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.inv_conaju_incp;
                    _context.AddToInvajusteconcep(lobjRegistro);
                    _context.SaveChanges();
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
        public static void fcvActualizar(ModeloInvajusteconcep tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invajusteconcep.FirstOrDefault(p => p.inv_conaju_incp == tobjModelo.Inv_conaju_incp);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_conaju_incp = tobjModelo.Inv_conaju_incp;
                        lobjRegistro.inv_desaju_incp = tobjModelo.Inv_desaju_incp;
                        lobjRegistro.inv_tipaju_incp = tobjModelo.Inv_tipaju_incp;
                        lobjRegistro.inv_conmov_incm = tobjModelo.Inv_conmov_incm;
                        lobjRegistro.inv_estreg_incp = tobjModelo.Inv_estreg_incp;
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
                    var lobjRegistro = _context.Invajusteconcep.FirstOrDefault(p => p.inv_conaju_incp == tcrCodigo);
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
        #region Buscar INVAJUSTECONCEP: Logica
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TITULO: Conceptos de ajuste inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///  Lista de concepto de ajuste inventario: 01=Por reconteo inventario 
        ///  02=Aprovechamiento sobrantes 03= Reingreso prestamos 
        ///  04=Deterioro del producto y otros 			
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajusteconcep(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajusteconcep.FirstOrDefault(p => p.inv_conaju_incp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvajusteconcep> flsListaInvajusteconcep(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invajusteconcep in _context.Invajusteconcep
                                      join invtipoconcemov in _context.Invtipoconcemov on invajusteconcep.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      select new ModeloInvajusteconcep
                                      {
                                          #region Datos
                                          Inv_conaju_incp = invajusteconcep.inv_conaju_incp,
                                          Inv_desaju_incp = invajusteconcep.inv_desaju_incp,
                                          Inv_tipaju_incp = invajusteconcep.inv_tipaju_incp,
                                          Inv_conmov_incm = invajusteconcep.inv_conmov_incm,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Inv_estreg_incp = invajusteconcep.inv_estreg_incp,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invajusteconcep in _context.Invajusteconcep
                                      join invtipoconcemov in _context.Invtipoconcemov on invajusteconcep.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      where invajusteconcep.inv_conaju_incp == tcrBuscar
                                      select new ModeloInvajusteconcep
                                      {
                                          #region Datos
                                          Inv_conaju_incp = invajusteconcep.inv_conaju_incp,
                                          Inv_desaju_incp = invajusteconcep.inv_desaju_incp,
                                          Inv_tipaju_incp = invajusteconcep.inv_tipaju_incp,
                                          Inv_conmov_incm = invajusteconcep.inv_conmov_incm,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Inv_estreg_incp = invajusteconcep.inv_estreg_incp,
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
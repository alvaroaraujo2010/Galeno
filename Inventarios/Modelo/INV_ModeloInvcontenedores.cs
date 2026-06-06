//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2017 08:07:11 PM
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
    /// invcontenedores:Tabla tipos de contenedores (presentacion articulos) EEEE
    /// </summary>
    public class ModeloInvcontenedores : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_codctn_intc: Código Contenedor
        private String _inv_codctn_intc;
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código Contenedor</para>
        /// <para>NOMBRE: inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código tipo de contenedor o presentación FFFF
        /// </para>
        /// </summary>
        public String Inv_codctn_intc
        {
            get { return _inv_codctn_intc; }
            set
            {
                if (_inv_codctn_intc == value) return;
                _inv_codctn_intc = value;
                OnPropertyChanged("Inv_codctn_intc");
            }
        }
        #endregion
        #region Inv_desctn_intc: Descripción Contenedor
        private String _inv_desctn_intc;
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Descripción Contenedor</para>
        /// <para>NOMBRE: inv_desctn_intc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public String Inv_desctn_intc
        {
            get { return _inv_desctn_intc; }
            set
            {
                if (_inv_desctn_intc == value) return;
                _inv_desctn_intc = value;
                OnPropertyChanged("Inv_desctn_intc");
            }
        }
        #endregion
        #region Inv_estreg_intc: Estado del registro
        private String _inv_estreg_intc;
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: inv_estreg_intc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Inv_estreg_intc
        {
            get { return _inv_estreg_intc; }
            set
            {
                if (_inv_estreg_intc == value) return;
                _inv_estreg_intc = value;
                OnPropertyChanged("Inv_estreg_intc");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvcontenedores tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFinvcontenedores
                    {
                        #region cargar Registro
                        inv_codctn_intc = tobjModelo.Inv_codctn_intc,
                        inv_desctn_intc = tobjModelo.Inv_desctn_intc,
                        inv_estreg_intc = tobjModelo.Inv_estreg_intc,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.inv_codctn_intc;
                    _context.AddToInvcontenedores(lobjRegistro);
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
        public static void fcvActualizar(ModeloInvcontenedores tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tobjModelo.Inv_codctn_intc);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_codctn_intc = tobjModelo.Inv_codctn_intc;
                        lobjRegistro.inv_desctn_intc = tobjModelo.Inv_desctn_intc;
                        lobjRegistro.inv_estreg_intc = tobjModelo.Inv_estreg_intc;
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
                    var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tcrCodigo);
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
        #region Buscar INVCONTENEDORES: Logica
        /// <summary>
        /// <para>TABLA: invcontenedores</para>
        /// <para>TITULO: Tabla tipos de contenedores (presentacion articulos)</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que contiene los diferentes tipos de contenedores conocidos
        /// o presentaciones de un Artículo: Caja Bolsas, Sacos,Bultos,Galones,Docena
        /// s y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvcontenedores(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invcontenedores.FirstOrDefault(p => p.inv_codctn_intc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvcontenedores> flsListaInvcontenedores(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invcontenedores in _context.Invcontenedores
                                      select new ModeloInvcontenedores
                                      {
                                          #region Datos
                                          Inv_codctn_intc = invcontenedores.inv_codctn_intc,
                                          Inv_desctn_intc = invcontenedores.inv_desctn_intc,
                                          Inv_estreg_intc = invcontenedores.inv_estreg_intc,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invcontenedores in _context.Invcontenedores
                                      where invcontenedores.inv_codctn_intc == tcrBuscar
                                      select new ModeloInvcontenedores
                                      {
                                          #region Datos
                                          Inv_codctn_intc = invcontenedores.inv_codctn_intc,
                                          Inv_desctn_intc = invcontenedores.inv_desctn_intc,
                                          Inv_estreg_intc = invcontenedores.inv_estreg_intc,
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
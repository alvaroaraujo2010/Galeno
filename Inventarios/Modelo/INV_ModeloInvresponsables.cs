//- MARMOTA-GENCODE: VERSION 2.0 - 06/06/2017 12:50:34 PM
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
    /// Descripcion para la Vista de  la tabla: invresponsables
    /// </summary>
    public class ModeloInvresponsables : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_codres_inre: Código responsable
        private String _inv_codres_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Código responsable</para>
        /// <para>NOMBRE: inv_codres_inre (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código de la persona responsable o que solicita  pedido para
        /// gasto interno de la empresa, viene de la tabla: INVRESPONSABLES
        /// </para>
        /// </summary>
        public String Inv_codres_inre
        {
            get { return _inv_codres_inre; }
            set
            {
                if (_inv_codres_inre == value) return;
                _inv_codres_inre = value;
                OnPropertyChanged("Inv_codres_inre");
            }
        }
        #endregion
        #region Inv_nroide_inre: Identificacion
        private String _inv_nroide_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Identificacion</para>
        /// <para>NOMBRE: inv_nroide_inre (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de identificacion de la persona natural
        /// </para>
        /// </summary>
        public String Inv_nroide_inre
        {
            get { return _inv_nroide_inre; }
            set
            {
                if (_inv_nroide_inre == value) return;
                _inv_nroide_inre = value;
                OnPropertyChanged("Inv_nroide_inre");
            }
        }
        #endregion
        #region Inv_nomres_inre: Persona responsable
        private String _inv_nomres_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Persona responsable</para>
        /// <para>NOMBRE: inv_nomres_inre (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public String Inv_nomres_inre
        {
            get { return _inv_nomres_inre; }
            set
            {
                if (_inv_nomres_inre == value) return;
                _inv_nomres_inre = value;
                OnPropertyChanged("Inv_nomres_inre");
            }
        }
        #endregion
        #region Inv_telefo_inre: Teléfonos
        private String _inv_telefo_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Teléfonos</para>
        /// <para>NOMBRE: inv_telefo_inre (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Teléfono persona responsable
        /// </para>
        /// </summary>
        public String Inv_telefo_inre
        {
            get { return _inv_telefo_inre; }
            set
            {
                if (_inv_telefo_inre == value) return;
                _inv_telefo_inre = value;
                OnPropertyChanged("Inv_telefo_inre");
            }
        }
        #endregion
        #region Inv_dirres_inre: Dirección recidencia
        private String _inv_dirres_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Dirección recidencia</para>
        /// <para>NOMBRE: inv_dirres_inre (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Dirección recidencia persona responsable
        /// </para>
        /// </summary>
        public String Inv_dirres_inre
        {
            get { return _inv_dirres_inre; }
            set
            {
                if (_inv_dirres_inre == value) return;
                _inv_dirres_inre = value;
                OnPropertyChanged("Inv_dirres_inre");
            }
        }
        #endregion
        #region Inv_correo_inre: Correo electronico
        private String _inv_correo_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Correo electronico</para>
        /// <para>NOMBRE: inv_correo_inre (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Correo electronico
        /// </para>
        /// </summary>
        public String Inv_correo_inre
        {
            get { return _inv_correo_inre; }
            set
            {
                if (_inv_correo_inre == value) return;
                _inv_correo_inre = value;
                OnPropertyChanged("Inv_correo_inre");
            }
        }
        #endregion
        #region Sys_codusu_usux: Usuario del sistema
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario del sistema</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código usuario del sistema para los personas que lo requieran
        /// (no obligatorio) , NA = cuando no sea requerido
        /// </para>
        /// </summary>
        public String Sys_codusu_usux
        {
            get { return _sys_codusu_usux; }
            set
            {
                if (_sys_codusu_usux == value) return;
                _sys_codusu_usux = value;
                OnPropertyChanged("Sys_codusu_usux");
            }
        }
        #endregion
        #region Inv_estreg_inre: Estado del registro
        private String _inv_estreg_inre;
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: inv_estreg_inre (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Inv_estreg_inre
        {
            get { return _inv_estreg_inre; }
            set
            {
                if (_inv_estreg_inre == value) return;
                _inv_estreg_inre = value;
                OnPropertyChanged("Inv_estreg_inre");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloInvresponsables tobjModelo)
        {
            MessageBox.Show("Aqui voy:" + tobjModelo);
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-INVRESPONSABLES", "INV", "Tabla personas responsables");
            try
            {
                if (!flgBuscarInvresponsables(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvresponsables
                        {
                            #region cargar Registro
                            inv_codres_inre = tobjModelo.Inv_codres_inre,
                            inv_nroide_inre = tobjModelo.Inv_nroide_inre,
                            inv_nomres_inre = tobjModelo.Inv_nomres_inre,
                            inv_telefo_inre = tobjModelo.Inv_telefo_inre,
                            inv_dirres_inre = tobjModelo.Inv_dirres_inre,
                            inv_correo_inre = tobjModelo.Inv_correo_inre,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            inv_estreg_inre = tobjModelo.Inv_estreg_inre,
                            #endregion
                        };
                        lobjRegistro.inv_codres_inre = lcrCodigoGen;
                        _context.AddToInvresponsables(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-INVRESPONSABLES': Tabla personas responsables en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvresponsables tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tobjModelo.Inv_codres_inre);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.inv_codres_inre = tobjModelo.Inv_codres_inre;
                        lobjRegistro.inv_nroide_inre = tobjModelo.Inv_nroide_inre;
                        lobjRegistro.inv_nomres_inre = tobjModelo.Inv_nomres_inre;
                        lobjRegistro.inv_telefo_inre = tobjModelo.Inv_telefo_inre;
                        lobjRegistro.inv_dirres_inre = tobjModelo.Inv_dirres_inre;
                        lobjRegistro.inv_correo_inre = tobjModelo.Inv_correo_inre;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.inv_estreg_inre = tobjModelo.Inv_estreg_inre;
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
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tcrCodigo);
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
        #region Buscar INVRESPONSABLES: Logica
        /// <summary>
        /// <para>TABLA: invresponsables</para>
        /// <para>TITULO: Tabla personas responsables</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla personas responsables en proceso de gestion en el modulo
        /// inventarios, persona que solicita pedido para gasto interno
        /// de la empresa y otros procesos
        /// </para>
        /// </summary>
        public static bool flgBuscarInvresponsables(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invresponsables.FirstOrDefault(p => p.inv_codres_inre == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvresponsables> flsListaInvresponsables(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invresponsables in _context.Invresponsables
                                      join invresponsable in _context.Invresponsables on invresponsables.sys_codusu_usux equals invresponsable.sys_codusu_usux into tminvresponsables
                                      from inre in tminvresponsables.DefaultIfEmpty()
                                      select new ModeloInvresponsables
                                      {
                                          Inv_codres_inre = invresponsables.inv_codres_inre,
                                          Inv_nroide_inre = invresponsables.inv_nroide_inre,
                                          Inv_nomres_inre = invresponsables.inv_nomres_inre,
                                          Inv_telefo_inre = invresponsables.inv_telefo_inre,
                                          Inv_dirres_inre = invresponsables.inv_dirres_inre,
                                          Inv_correo_inre = invresponsables.inv_correo_inre,
                                          Sys_codusu_usux = invresponsables.sys_codusu_usux,
                                          Inv_estreg_inre = invresponsables.inv_estreg_inre,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invresponsables in _context.Invresponsables
                                      join invresponsablex in _context.Invresponsables on invresponsables.sys_codusu_usux equals invresponsablex.sys_codusu_usux into tminvresponsables
                                      from inre in tminvresponsables.DefaultIfEmpty()
                                      where invresponsables.inv_codres_inre == tcrBuscar
                                      select new ModeloInvresponsables
                                      {
                                          Inv_codres_inre = invresponsables.inv_codres_inre,
                                          Inv_nroide_inre = invresponsables.inv_nroide_inre,
                                          Inv_nomres_inre = invresponsables.inv_nomres_inre,
                                          Inv_telefo_inre = invresponsables.inv_telefo_inre,
                                          Inv_dirres_inre = invresponsables.inv_dirres_inre,
                                          Inv_correo_inre = invresponsables.inv_correo_inre,
                                          Sys_codusu_usux = invresponsables.sys_codusu_usux,
                                          Inv_estreg_inre = invresponsables.inv_estreg_inre,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
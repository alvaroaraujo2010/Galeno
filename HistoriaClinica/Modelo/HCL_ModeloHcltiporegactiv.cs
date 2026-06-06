//- MARMOTA-GENCODE: VERSION 2.0 - 13/04/2015 03:37:54 PM
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

namespace HistoriasClinicas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hcltiporegactiv
    /// </summary>
    public class ModeloHcltiporegactivXX : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_codreg_hcca: Tipo registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcca
        {
            get { return _hcl_codreg_hcca; }
            set
            {
                if (_hcl_codreg_hcca == value) return;
                _hcl_codreg_hcca = value;
                OnPropertyChanged("Hcl_codreg_hcca");
            }
        }
        #endregion
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcca
        {
            get { return _hcl_desreg_hcca; }
            set
            {
                if (_hcl_desreg_hcca == value) return;
                _hcl_desreg_hcca = value;
                OnPropertyChanged("Hcl_desreg_hcca");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla asociada para generar registro actividad
        /// en historia clinica
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Sys_codtip_sytm: Codigo tipo de mensajes
        private String _sys_codtip_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Codigo tipo de mensajes</para>
        /// <para>NOMBRE: sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo unico tipos de mensaje que desencadena en el adminstrador
        /// de mensajeria del sistema
        /// </para>
        /// </summary>
        public String Sys_codtip_sytm
        {
            get { return _sys_codtip_sytm; }
            set
            {
                if (_sys_codtip_sytm == value) return;
                _sys_codtip_sytm = value;
                OnPropertyChanged("Sys_codtip_sytm");
            }
        }
        #endregion
        #region Hcl_imagen_hcca: Imagen (jpg)
        private String _hcl_imagen_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcca (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de actividad
        /// en las diferentes vistas
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcca
        {
            get { return _hcl_imagen_hcca; }
            set
            {
                if (_hcl_imagen_hcca == value) return;
                _hcl_imagen_hcca = value;
                OnPropertyChanged("Hcl_imagen_hcca");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Sys_desmsj_sytm: Descripcion tipo
        private String _sys_desmsj_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripcion tipo</para>
        /// <para>NOMBRE: sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo notificacion enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_sytm
        {
            get { return _sys_desmsj_sytm; }
            set
            {
                if (_sys_desmsj_sytm == value) return;
                _sys_desmsj_sytm = value;
                OnPropertyChanged("Sys_desmsj_sytm");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHcltiporegactiv tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFhcltiporegactiv
                {
                    #region cargar Registro
                    hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca,
                    hcl_desreg_hcca = tobjModelo.Hcl_desreg_hcca,
                    grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                    sys_codtip_sytm = tobjModelo.Sys_codtip_sytm,
                    hcl_imagen_hcca = tobjModelo.Hcl_imagen_hcca,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.hcl_codreg_hcca;
                _context.AddToHcltiporegactiv(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHcltiporegactiv tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tobjModelo.Hcl_codreg_hcca);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca;
                    lobjRegistro.hcl_desreg_hcca = tobjModelo.Hcl_desreg_hcca;
                    lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                    lobjRegistro.sys_codtip_sytm = tobjModelo.Sys_codtip_sytm;
                    lobjRegistro.hcl_imagen_hcca = tobjModelo.Hcl_imagen_hcca;
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
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLTIPOREGACTIV: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegactiv(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_codreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHcltiporegactiv> flsListaHcltiporegactiv(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                      join grpmaeplantilla in _context.Grpmaeplantilla on hcltiporegactiv.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sysadmstipomens in _context.Sysadmstipomens on hcltiporegactiv.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      select new ModeloHcltiporegactiv
                                      {
                                          Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                          Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                          Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                          Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                      join grpmaeplantilla in _context.Grpmaeplantilla on hcltiporegactiv.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join sysadmstipomens in _context.Sysadmstipomens on hcltiporegactiv.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      where hcltiporegactiv.hcl_codreg_hcca.Contains(tcrBuscar) || hcltiporegactiv.hcl_desreg_hcca.Contains(tcrBuscar)
                                      select new ModeloHcltiporegactiv
                                      {
                                          Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                          Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                          Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                          Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
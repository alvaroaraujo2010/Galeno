//- MARMOTA-GENCODE: VERSION 2.0 - 29/11/2018 04:41:43 PM
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

namespace Systemas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sysusuarios
    /// </summary>
    public class ModeloSysusuarios : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codusu_usux: Código único sistema
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código único sistema</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del usuario generado por el sistema: ejm US001
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
        #region Sys_ideusu_usux: ID del  Usuario
        private String _sys_ideusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: ID del  Usuario</para>
        /// <para>NOMBRE: sys_ideusu_usux (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// ID que digita el usuario  para acceso al sistema ejm: calos4,
        /// juanb, MAN34,mile25
        /// </para>
        /// </summary>
        public String Sys_ideusu_usux
        {
            get { return _sys_ideusu_usux; }
            set
            {
                if (_sys_ideusu_usux == value) return;
                _sys_ideusu_usux = value;
                OnPropertyChanged("Sys_ideusu_usux");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux
        {
            get { return _sys_nomusu_usux; }
            set
            {
                if (_sys_nomusu_usux == value) return;
                _sys_nomusu_usux = value;
                OnPropertyChanged("Sys_nomusu_usux");
            }
        }
        #endregion
        #region Sys_clausu_usux: Clave del Usuario
        private String _sys_clausu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Clave del Usuario</para>
        /// <para>NOMBRE: sys_clausu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Clave del Usuario
        /// </para>
        /// </summary>
        public String Sys_clausu_usux
        {
            get { return _sys_clausu_usux; }
            set
            {
                if (_sys_clausu_usux == value) return;
                _sys_clausu_usux = value;
                OnPropertyChanged("Sys_clausu_usux");
            }
        }
        #endregion
        #region Clave: Digite la clave
        private String _lcrTmp_clave;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: local</para>
        /// <para>CAMPO: Clave de digitada</para>
        /// <para>NOMBRE: Clave (char:50)</para>
        /// <para></para>
        /// <para>DESCRIPCION:
        ///Clave de Digitada
        /// </para>
        /// </summary>
        public String lcrTmpClave
        {
            get { return _lcrTmp_clave; }
            set
            {
                if (_lcrTmp_clave == value) return;
                _lcrTmp_clave = value;
                OnPropertyChanged("Clave");
            }
        }
        #endregion
        #region lcrTmpConfirmar: Clave a confirmar
        private String _lcrTmpConfirmar;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: local</para>
        /// <para>CAMPO: lcrTmpConfirmar</para>
        /// <para>NOMBRE: _lcrTmpConfirmar (char:50)</para>
        /// <para></para>
        /// <para>DESCRIPCION:
        ///Clave Confirmada
        /// </para>
        /// </summary>
        public String lcrTmpConfirmar
        {
            get { return _lcrTmpConfirmar; }
            set
            {
                if (_lcrTmpConfirmar == value) return;
                _lcrTmpConfirmar = value;
                OnPropertyChanged("lcrTmpConfirmar");
            }
        }
        #endregion
        #region Sys_codper_perf: Código del Perfil
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del perfil de usuario
        /// </para>
        /// </summary>
        public String Sys_codper_perf
        {
            get { return _sys_codper_perf; }
            set
            {
                if (_sys_codper_perf == value) return;
                _sys_codper_perf = value;
                OnPropertyChanged("Sys_codper_perf");
            }
        }
        #endregion
        #region Sys_imagen_usux: Imagen usuario
        private String _sys_imagen_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Imagen usuario</para>
        /// <para>NOMBRE: sys_imagen_usux (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Ruta nombre y extensión del archivo de imagen que representa
        /// al usuario (cuando este vacio se representa con imagen del
        /// perfil)
        /// </para>
        /// </summary>
        public String Sys_imagen_usux
        {
            get { return _sys_imagen_usux; }
            set
            {
                if (_sys_imagen_usux == value) return;
                _sys_imagen_usux = value;
                OnPropertyChanged("Sys_imagen_usux");
            }
        }
        #endregion
        #region Sys_estusu_usux: Estado Usuario
        private String _sys_estusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Estado Usuario</para>
        /// <para>NOMBRE: sys_estusu_usux (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del Usuario  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sys_estusu_usux
        {
            get { return _sys_estusu_usux; }
            set
            {
                if (_sys_estusu_usux == value) return;
                _sys_estusu_usux = value;
                OnPropertyChanged("Sys_estusu_usux");
            }
        }
        #endregion
        #region Sys_desper_perf: Nombre del Perfil
        private String _sys_desper_perf;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nombre del Perfil</para>
        /// <para>NOMBRE: sys_desper_perf (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del perfil textual del perfil
        /// </para>
        /// </summary>
        public String Sys_desper_perf
        {
            get { return _sys_desper_perf; }
            set
            {
                if (_sys_desper_perf == value) return;
                _sys_desper_perf = value;
                OnPropertyChanged("Sys_desper_perf");
            }
        }
        #endregion
        #region Sys_destusu_usux: Estado Usuario
        private String _sys_destusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO:Descrpcion Estado Usuario</para>
        /// <para>NOMBRE: sys_destusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Descrpcion estado del usuario  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sys_destusu_usux
        {
            get { return _sys_destusu_usux; }
            set
            {
                if (_sys_destusu_usux == value) return;
                _sys_destusu_usux = value;
                OnPropertyChanged("Sys_destusu_usux");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloSysusuarios tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SYS-SYSUSUARIOS", "SYS", "Maestro de Usuarios del Sistema");
            try
            {
                if (!flgBuscarSysusuarios(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFsysusuarios
                        {
                            #region cargar Registro
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            sys_ideusu_usux = tobjModelo.Sys_ideusu_usux,
                            sys_nomusu_usux = tobjModelo.Sys_nomusu_usux,
                            sys_clausu_usux = tobjModelo.Sys_clausu_usux,
                            sys_codper_perf = tobjModelo.Sys_codper_perf,
                            sys_imagen_usux = tobjModelo.Sys_imagen_usux,
                            sys_estusu_usux = tobjModelo.Sys_estusu_usux,
                            #endregion
                        };
                        if (tobjModelo.lcrTmpClave == tobjModelo.lcrTmpConfirmar)
                        {
                            lobjRegistro.sys_clausu_usux = Encriptacion.fcSISEncritar(tobjModelo.lcrTmpClave);
                            lobjRegistro.sys_codusu_usux = lcrCodigoGen;
                            _context.AddToSysusuarios(lobjRegistro);
                            _context.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar: Las Claves deben ser Iguales");
                        }
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SYS-SYSUSUARIOS': Maestro de Usuarios del Sistema en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloSysusuarios tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tobjModelo.Sys_codusu_usux);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.sys_ideusu_usux = tobjModelo.Sys_ideusu_usux;
                        lobjRegistro.sys_nomusu_usux = tobjModelo.Sys_nomusu_usux;
                        lobjRegistro.sys_clausu_usux = tobjModelo.Sys_clausu_usux;
                        lobjRegistro.sys_codper_perf = tobjModelo.Sys_codper_perf;
                        lobjRegistro.sys_imagen_usux = tobjModelo.Sys_imagen_usux;
                        lobjRegistro.sys_estusu_usux = tobjModelo.Sys_estusu_usux;
                        #endregion
                        if (tobjModelo.lcrTmpClave == tobjModelo.lcrTmpConfirmar)
                        {
                            lobjRegistro.sys_clausu_usux = Encriptacion.fcSISEncritar(tobjModelo.lcrTmpClave);
                            _context.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar: Las Claves deben ser Iguales");
                        }
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
                    var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
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
        #region Buscar SYSUSUARIOS: Logica
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TITULO: Maestro de Usuarios del Sistema</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Usuarios del Sistema a quienes se les asignan perfiles
        /// para  realizar acciones o  ejecutan módulos
        /// </para>
        /// </summary>
        public static bool flgBuscarSysusuarios(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysusuarios.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSysusuarios> flsListaSysusuarios(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sysusuarios in _context.Sysusuarios
                                      join sysperfiusuario in _context.Sysperfiusuario on sysusuarios.sys_codper_perf equals sysperfiusuario.sys_codper_perf into tmsysperfiusuario
                                      from perf in tmsysperfiusuario.DefaultIfEmpty()
                                      select new ModeloSysusuarios
                                      {
                                          #region Datos
                                          Sys_codusu_usux = sysusuarios.sys_codusu_usux,
                                          Sys_ideusu_usux = sysusuarios.sys_ideusu_usux,
                                          Sys_nomusu_usux = sysusuarios.sys_nomusu_usux,
                                          Sys_clausu_usux = sysusuarios.sys_clausu_usux,
                                          Sys_codper_perf = sysusuarios.sys_codper_perf,
                                          Sys_imagen_usux = sysusuarios.sys_imagen_usux,
                                          Sys_estusu_usux = sysusuarios.sys_estusu_usux,
                                          Sys_desper_perf = perf.sys_desper_perf,
                                          Sys_destusu_usux = sysusuarios.sys_estusu_usux == "1" ? "Activo" : "Inactivo",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sysusuarios in _context.Sysusuarios
                                      join sysperfiusuario in _context.Sysperfiusuario on sysusuarios.sys_codper_perf equals sysperfiusuario.sys_codper_perf into tmsysperfiusuario
                                      from perf in tmsysperfiusuario.DefaultIfEmpty()
                                      where sysusuarios.sys_codusu_usux.Contains(tcrBuscar) ||
                                            sysusuarios.sys_ideusu_usux.Contains(tcrBuscar) || 
                                            sysusuarios.sys_nomusu_usux.Contains(tcrBuscar)
                                      select new ModeloSysusuarios
                                      {
                                          #region Datos
                                          Sys_codusu_usux = sysusuarios.sys_codusu_usux,
                                          Sys_ideusu_usux = sysusuarios.sys_ideusu_usux,
                                          Sys_nomusu_usux = sysusuarios.sys_nomusu_usux,
                                          Sys_clausu_usux = sysusuarios.sys_clausu_usux,
                                          Sys_codper_perf = sysusuarios.sys_codper_perf,
                                          Sys_imagen_usux = sysusuarios.sys_imagen_usux,
                                          Sys_estusu_usux = sysusuarios.sys_estusu_usux,
                                          Sys_desper_perf = perf.sys_desper_perf,
                                          Sys_destusu_usux = sysusuarios.sys_estusu_usux == "1" ? "Activo" : "Inactivo",
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
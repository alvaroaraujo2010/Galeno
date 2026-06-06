//- MARMOTA-GENCODE: VERSION 2.0 - 12/12/2017 10:21:55 AM
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
    #region Modelo Maestro Formato por perfil
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sysperfiusuario
    /// </summary>
    public class ModeloFormatoPorPerfil : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codper_perf: Código del Perfil
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del perfil en el sistema (generado por el sistema)
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
        #region Sys_desper_perf: Nombre del Perfil
        private String _sys_desper_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
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
        #region Sys_rutimg_perf: Imagen de  Vista
        private String _sys_rutimg_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Imagen de  Vista</para>
        /// <para>NOMBRE: sys_rutimg_perf (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Ruta y Nombre de la Imagen jpg que lo representa en las vista
        /// de Menú
        /// </para>
        /// </summary>
        public String Sys_rutimg_perf
        {
            get { return _sys_rutimg_perf; }
            set
            {
                if (_sys_rutimg_perf == value) return;
                _sys_rutimg_perf = value;
                OnPropertyChanged("Sys_rutimg_perf");
            }
        }
        #endregion
        #region Sys_secreg_perf: Contador Registros
        private int _sys_secreg_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Contador Registros</para>
        /// <para>NOMBRE: sys_secreg_perf (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Control Contador de Nuevos Registros
        /// </para>
        /// </summary>
        public int Sys_secreg_perf
        {
            get { return _sys_secreg_perf; }
            set
            {
                if (_sys_secreg_perf == value) return;
                _sys_secreg_perf = value;
                OnPropertyChanged("Sys_secreg_perf");
            }
        }
        #endregion
        #region Sys_nivusu_perf: Nivel del Usuario
        private String _sys_nivusu_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nivel del Usuario</para>
        /// <para>NOMBRE: sys_nivusu_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nivel del usuario en el sistema: 1=Súper usuario 2=Administrador
        /// 3=Usuario de gestión
        /// </para>
        /// </summary>
        public String Sys_nivusu_perf
        {
            get { return _sys_nivusu_perf; }
            set
            {
                if (_sys_nivusu_perf == value) return;
                _sys_nivusu_perf = value;
                OnPropertyChanged("Sys_nivusu_perf");
            }
        }
        #endregion
        #region Sys_estper_perf: Estado del perfil
        private String _sys_estper_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Estado del perfil</para>
        /// <para>NOMBRE: sys_estper_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado del Perfil: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Sys_estper_perf
        {
            get { return _sys_estper_perf; }
            set
            {
                if (_sys_estper_perf == value) return;
                _sys_estper_perf = value;
                OnPropertyChanged("Sys_estper_perf");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFormatoPorPerfil tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-FORMATO-POR-PERFIL", "HCL", "Secuencial Unico maestro formato por perfil");
            try
            {
                if (!flgBuscarSysperfiusuario(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFsysperfiusuario
                        {
                            #region cargar Registro
                            sys_codper_perf = tobjModelo.Sys_codper_perf,
                            sys_desper_perf = tobjModelo.Sys_desper_perf,
                            sys_rutimg_perf = tobjModelo.Sys_rutimg_perf,
                            sys_secreg_perf = tobjModelo.Sys_secreg_perf,
                            sys_nivusu_perf = tobjModelo.Sys_nivusu_perf,
                            sys_estper_perf = tobjModelo.Sys_estper_perf,
                            #endregion
                        };
                        lobjRegistro.sys_codper_perf = lcrCodigoGen;
                        _context.AddToSysperfiusuario(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-FORMATO-POR-PERFIL': Secuencial Unico maestro formato por perfil en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloFormatoPorPerfil tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tobjModelo.Sys_codper_perf);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.sys_codper_perf = tobjModelo.Sys_codper_perf;
                        lobjRegistro.sys_desper_perf = tobjModelo.Sys_desper_perf;
                        lobjRegistro.sys_rutimg_perf = tobjModelo.Sys_rutimg_perf;
                        lobjRegistro.sys_secreg_perf = (int)tobjModelo.Sys_secreg_perf;
                        lobjRegistro.sys_nivusu_perf = tobjModelo.Sys_nivusu_perf;
                        lobjRegistro.sys_estper_perf = tobjModelo.Sys_estper_perf;
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
                    var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
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
        #region Buscar SYSPERFIUSUARIO: Logica
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TITULO: Maestro perfiles de usuarios</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestra para registrar perfiles de usuarios que creados
        /// para gestión de datos en el sistema ejm: P01 =Súper Usuario
        /// P02=Administrador  P03=Facturadores P04=Regente de farmacia
        /// </para>
        /// </summary>
        public static bool flgBuscarSysperfiusuario(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFormatoPorPerfil> flsListaSysperfiusuario(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sysperfiusuario in _context.Sysperfiusuario
                                      select new ModeloFormatoPorPerfil
                                      {
                                          #region Datos
                                          Sys_codper_perf = sysperfiusuario.sys_codper_perf,
                                          Sys_desper_perf = sysperfiusuario.sys_desper_perf,
                                          Sys_rutimg_perf = sysperfiusuario.sys_rutimg_perf,
                                          Sys_secreg_perf = (int)sysperfiusuario.sys_secreg_perf,
                                          Sys_nivusu_perf = sysperfiusuario.sys_nivusu_perf,
                                          Sys_estper_perf = sysperfiusuario.sys_estper_perf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sysperfiusuario in _context.Sysperfiusuario
                                      where sysperfiusuario.sys_codper_perf.Contains(tcrBuscar) || sysperfiusuario.sys_desper_perf.Contains(tcrBuscar)
                                      select new ModeloFormatoPorPerfil
                                      {
                                          #region Datos
                                          Sys_codper_perf = sysperfiusuario.sys_codper_perf,
                                          Sys_desper_perf = sysperfiusuario.sys_desper_perf,
                                          Sys_rutimg_perf = sysperfiusuario.sys_rutimg_perf,
                                          Sys_secreg_perf = (int)sysperfiusuario.sys_secreg_perf,
                                          Sys_nivusu_perf = sysperfiusuario.sys_nivusu_perf,
                                          Sys_estper_perf = sysperfiusuario.sys_estper_perf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Formato por perfil
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclformatperfil
    /// </summary>
    public class ModeloDetallFormatoPorPerfil : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_codreg_hcpr: Código registro
        private String _hcl_codreg_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: hcl_codreg_hcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro generado por el sistema
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcpr
        {
            get { return _hcl_codreg_hcpr; }
            set
            {
                if (_hcl_codreg_hcpr == value) return;
                _hcl_codreg_hcpr = value;
                OnPropertyChanged("Hcl_codreg_hcpr");
            }
        }
        #endregion
        #region Sys_codper_perf: Código del Perfil
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del perfil usuario del sistema
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
        #region Hcl_codreg_hcca: Tipo registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia desde la tabla: HCLTIPOREGACTIV
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
        #region Hcl_accvis_hcpr: Acceso a vistia
        private String _hcl_accvis_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a vistia</para>
        /// <para>NOMBRE: hcl_accvis_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo vista del formato, sin permiso para modificaciones:
        /// 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Hcl_accvis_hcpr
        {
            get { return _hcl_accvis_hcpr; }
            set
            {
                if (_hcl_accvis_hcpr == value) return;
                _hcl_accvis_hcpr = value;
                OnPropertyChanged("Hcl_accvis_hcpr");
            }
        }
        #endregion
        #region Hcl_accedt_hcpr: Acceso a edicion
        private String _hcl_accedt_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a edicion</para>
        /// <para>NOMBRE: hcl_accedt_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo EDT o edicion, permite al usuario realizar cambios
        /// en contenidos del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Hcl_accedt_hcpr
        {
            get { return _hcl_accedt_hcpr; }
            set
            {
                if (_hcl_accedt_hcpr == value) return;
                _hcl_accedt_hcpr = value;
                OnPropertyChanged("Hcl_accedt_hcpr");
            }
        }
        #endregion
        #region Hcl_accprn_hcpr: Acceso a imprimir
        private String _hcl_accprn_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a imprimir</para>
        /// <para>NOMBRE: hcl_accprn_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Acceso para imprimir, permite al usuario imprimir valores contenidos
        /// del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Hcl_accprn_hcpr
        {
            get { return _hcl_accprn_hcpr; }
            set
            {
                if (_hcl_accprn_hcpr == value) return;
                _hcl_accprn_hcpr = value;
                OnPropertyChanged("Hcl_accprn_hcpr");
            }
        }
        #endregion
        #region Hcl_accges_hcpr: Acceso a funcionalidad
        private String _hcl_accges_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a funcionalidad</para>
        /// <para>NOMBRE: hcl_accges_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Acceso a otras gestiones, permitir al usuario  acceder a funcionalidad
        /// o procesos adicionales del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Hcl_accges_hcpr
        {
            get { return _hcl_accges_hcpr; }
            set
            {
                if (_hcl_accges_hcpr == value) return;
                _hcl_accges_hcpr = value;
                OnPropertyChanged("Hcl_accges_hcpr");
            }
        }
        #endregion
        #region Hcl_estfor_hcpr: Estado formato
        private String _hcl_estfor_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Estado formato</para>
        /// <para>NOMBRE: hcl_estfor_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del formato dentro del perfil:  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_estfor_hcpr
        {
            get { return _hcl_estfor_hcpr; }
            set
            {
                if (_hcl_estfor_hcpr == value) return;
                _hcl_estfor_hcpr = value;
                OnPropertyChanged("Hcl_estfor_hcpr");
            }
        }
        #endregion
        #region Sys_desper_perf: Nombre del Perfil
        private String _sys_desper_perf;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
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
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Grp_idepla_grpl: Descripcion tipo registro
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: _grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///  Consecutivo Único de la plantilla base
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
        #region Hcl_destfor_hcpr: Descripcion Estado formato
        private String _hcl_destfor_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Descripcion Estado formato</para>
        /// <para>NOMBRE: hcl_destfor_hcpr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Descripcion Estado del formato dentro del perfil:  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_destfor_hcpr
        {
            get { return _hcl_destfor_hcpr; }
            set
            {
                if (_hcl_destfor_hcpr == value) return;
                _hcl_destfor_hcpr = value;
                OnPropertyChanged("Hcl_destfor_hcpr");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private String _sis_estado_imaen;
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
        public static bool flgAddRegistro(ModeloDetallFormatoPorPerfil tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFhclformatperfil();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Hclformatperfil.FirstOrDefault(p => p.hcl_codreg_hcpr == tobTempReg.Hcl_codreg_hcpr);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.hcl_codreg_hcpr = tobTempReg.Hcl_codreg_hcpr;
                            lobEFReg.sys_codper_perf = tobTempReg.Sys_codper_perf;
                            lobEFReg.hcl_codreg_hcca = tobTempReg.Hcl_codreg_hcca;
                            lobEFReg.hcl_accvis_hcpr = tobTempReg.Hcl_accvis_hcpr;
                            lobEFReg.hcl_accedt_hcpr = tobTempReg.Hcl_accedt_hcpr;
                            lobEFReg.hcl_accprn_hcpr = tobTempReg.Hcl_accprn_hcpr;
                            lobEFReg.hcl_accges_hcpr = tobTempReg.Hcl_accges_hcpr;
                            lobEFReg.hcl_estfor_hcpr = tobTempReg.Hcl_estfor_hcpr;
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
                                lobEFReg.hcl_codreg_hcpr = tcrCodigoR1 + lobEFReg.hcl_codreg_hcpr; // concatenar
                                _context.AddToHclformatperfil(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Hclformatperfil.FirstOrDefault(p => p.hcl_codreg_hcpr == tobTempReg.Hcl_codreg_hcpr);
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
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLFORMATPERFIL: Logica
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TITULO: Acceso a formatos actividades de historia clinica según perf</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista formatos activiades o servicios en Historia clinica Autorizados
        /// para cada perfil de usuario que gestiona
        /// </para>
        /// </summary>
        public static bool flgBuscarHclformatperfil(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclformatperfil.FirstOrDefault(p => p.hcl_codreg_hcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// Flitro de la vista Formatos por Perfil 
        /// </summary>
        /// <param name="tcrCodigoGrupo">Codigo Perfil</param>
        /// <param name="tcrTextoBuscar">Texto a buscar</param>
        /// <returns></returns>
        public static List<ModeloDetallFormatoPorPerfil> flsListaHclformatperfilForm(String tcrCodigoPerfil, String tcrTextoBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrTextoBuscar))
                {
                    var lobConsulta = from hclformatperfil in _context.Hclformatperfil
                                      join sysperfiusuario in _context.Sysperfiusuario on hclformatperfil.sys_codper_perf equals sysperfiusuario.sys_codper_perf into tmsysperfiusuario
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclformatperfil.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from perf in tmsysperfiusuario.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclformatperfil.sys_codper_perf.Equals(tcrCodigoPerfil)
                                      select new ModeloDetallFormatoPorPerfil
                                      {
                                          #region datos
                                          Hcl_codreg_hcpr = hclformatperfil.hcl_codreg_hcpr,
                                          Sys_codper_perf = hclformatperfil.sys_codper_perf,
                                          Hcl_codreg_hcca = hclformatperfil.hcl_codreg_hcca,
                                          Hcl_accvis_hcpr = hclformatperfil.hcl_accvis_hcpr,
                                          Hcl_accedt_hcpr = hclformatperfil.hcl_accedt_hcpr,
                                          Hcl_accprn_hcpr = hclformatperfil.hcl_accprn_hcpr,
                                          Hcl_accges_hcpr = hclformatperfil.hcl_accges_hcpr,
                                          Hcl_estfor_hcpr = hclformatperfil.hcl_estfor_hcpr,
                                          Sys_desper_perf = perf.sys_desper_perf,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcca.grp_idepla_grpl,
                                          Hcl_destfor_hcpr = hclformatperfil.hcl_estfor_hcpr == "1" ? "ACTIVO" : "INACTIVO",
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclformatperfil in _context.Hclformatperfil
                                      join sysperfiusuario in _context.Sysperfiusuario on hclformatperfil.sys_codper_perf equals sysperfiusuario.sys_codper_perf into tmsysperfiusuario
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclformatperfil.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from perf in tmsysperfiusuario.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclformatperfil.sys_codper_perf.Equals(tcrCodigoPerfil) &&
                                            (hclformatperfil.hcl_codreg_hcca.Contains(tcrTextoBuscar) ||
                                             hcca.hcl_desreg_hcca.Contains(tcrTextoBuscar) ||
                                             hcca.grp_idepla_grpl.Contains(tcrTextoBuscar))
                                      select new ModeloDetallFormatoPorPerfil
                                      {
                                          #region datos
                                          Hcl_codreg_hcpr = hclformatperfil.hcl_codreg_hcpr,
                                          Sys_codper_perf = hclformatperfil.sys_codper_perf,
                                          Hcl_codreg_hcca = hclformatperfil.hcl_codreg_hcca,
                                          Hcl_accvis_hcpr = hclformatperfil.hcl_accvis_hcpr,
                                          Hcl_accedt_hcpr = hclformatperfil.hcl_accedt_hcpr,
                                          Hcl_accprn_hcpr = hclformatperfil.hcl_accprn_hcpr,
                                          Hcl_accges_hcpr = hclformatperfil.hcl_accges_hcpr,
                                          Hcl_estfor_hcpr = hclformatperfil.hcl_estfor_hcpr,
                                          Sys_desper_perf = perf.sys_desper_perf,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          Grp_idepla_grpl = hcca.grp_idepla_grpl,
                                          Hcl_destfor_hcpr = hclformatperfil.hcl_estfor_hcpr == "1" ? "ACTIVO" : "INACTIVO",
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
}
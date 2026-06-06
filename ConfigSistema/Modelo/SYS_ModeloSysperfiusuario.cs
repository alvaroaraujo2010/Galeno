//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2014 11:11:22 AM
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
    /// Descripcion para la Vista de  la tabla: sysperfiusuario
    /// </summary>
    public class ModeloSysperfiusuario : clBaseInpc
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
        public static string flgAddRegistro(ModeloSysperfiusuario tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SYS-PERFILES-USUARIOS", "SYS", "Perfiles de usuarios");
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
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SYS-PERFILES-USUARIOS': Perfiles de usuarios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSysperfiusuario tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tobjModelo.Sys_codper_perf);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sys_codper_perf = tobjModelo.Sys_codper_perf;
                    lobjRegistro.sys_desper_perf = tobjModelo.Sys_desper_perf;
                    lobjRegistro.sys_rutimg_perf = tobjModelo.Sys_rutimg_perf;
                    lobjRegistro.sys_secreg_perf = (int)tobjModelo.Sys_secreg_perf;
                    lobjRegistro.sys_nivusu_perf = tobjModelo.Sys_nivusu_perf;
                    lobjRegistro.sys_estper_perf = tobjModelo.Sys_estper_perf;
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
                var lobjRegistro = _context.Sysperfiusuario.FirstOrDefault(p => p.sys_codper_perf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
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
        public static bool flgBuscarSysperfiusuario(string tcrCodigo)
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
        public static List<ModeloSysperfiusuario> flsListaSysperfiusuario(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sysperfiusuario in _context.Sysperfiusuario
                                      select new ModeloSysperfiusuario
                                      {
                                          Sys_codper_perf = sysperfiusuario.sys_codper_perf,
                                          Sys_desper_perf = sysperfiusuario.sys_desper_perf,
                                          Sys_rutimg_perf = sysperfiusuario.sys_rutimg_perf,
                                          Sys_secreg_perf = (int)sysperfiusuario.sys_secreg_perf,
                                          Sys_nivusu_perf = sysperfiusuario.sys_nivusu_perf,
                                          Sys_estper_perf = sysperfiusuario.sys_estper_perf,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sysperfiusuario in _context.Sysperfiusuario
                                      where sysperfiusuario.sys_codper_perf.Contains(tcrBuscar) || sysperfiusuario.sys_desper_perf.Contains(tcrBuscar)
                                      select new ModeloSysperfiusuario
                                      {
                                          Sys_codper_perf = sysperfiusuario.sys_codper_perf,
                                          Sys_desper_perf = sysperfiusuario.sys_desper_perf,
                                          Sys_rutimg_perf = sysperfiusuario.sys_rutimg_perf,
                                          Sys_secreg_perf = (int)sysperfiusuario.sys_secreg_perf,
                                          Sys_nivusu_perf = sysperfiusuario.sys_nivusu_perf,
                                          Sys_estper_perf = sysperfiusuario.sys_estper_perf,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: syscomponperfil
    /// </summary>
    public class ModeloSysperfiusuariocomp : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codreg_cper: Código registro
        private String _sys_codreg_cper;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: sys_codreg_cper (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro generado por el sistema
        /// </para>
        /// </summary>
        public String Sys_codreg_cper
        {
            get { return _sys_codreg_cper; }
            set
            {
                if (_sys_codreg_cper == value) return;
                _sys_codreg_cper = value;
                OnPropertyChanged("Sys_codreg_cper");
            }
        }
        #endregion
        #region Sys_codper_perf: Código del Perfil
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del perfil asociado con componente
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
        #region Sys_codcom_comd: Código asignación en Módulo
        private String _sys_codcom_comd;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscompmodulos</para>
        /// <para>CAMPO: Código asignación en Módulo</para>
        /// <para>NOMBRE: sys_codcom_comd (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código Único del componente en asignación en módulos (código
        /// de asignación)
        /// </para>
        /// </summary>
        public String Sys_codcom_comd
        {
            get { return _sys_codcom_comd; }
            set
            {
                if (_sys_codcom_comd == value) return;
                _sys_codcom_comd = value;
                OnPropertyChanged("Sys_codcom_comd");
            }
        }
        #endregion
        #region Sys_codmod_modu: Código Módulo
        private String _sys_codmod_modu;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: sys_codmod_modu (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código único del Módulo al cual se asocia el componente asignado
        /// al perfil
        /// </para>
        /// </summary>
        public String Sys_codmod_modu
        {
            get { return _sys_codmod_modu; }
            set
            {
                if (_sys_codmod_modu == value) return;
                _sys_codmod_modu = value;
                OnPropertyChanged("Sys_codmod_modu");
            }
        }
        #endregion
        #region Sys_llavco_cper: Llave verificación
        private String _sys_llavco_cper;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Llave verificación</para>
        /// <para>NOMBRE: sys_llavco_cper (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Llave de verificación  es el Código Módulo + Código único del
        /// Componente (SYS_CODMOD_MODU+SYS_CODCOM_COMP) ejm:  FCMCOM0015
        /// donde FCM y COM0015 son Módulo y componente
        /// </para>
        /// </summary>
        public String Sys_llavco_cper
        {
            get { return _sys_llavco_cper; }
            set
            {
                if (_sys_llavco_cper == value) return;
                _sys_llavco_cper = value;
                OnPropertyChanged("Sys_llavco_cper");
            }
        }
        #endregion
        #region Sys_codcom_comp: Código componente
        private String _sys_codcom_comp;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Código componente</para>
        /// <para>NOMBRE: sys_codcom_comp (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código Único del componente (Formulario, opción reporte y otros)
        /// asociado al Módulo ejm: COM0015
        /// </para>
        /// </summary>
        public String Sys_codcom_comp
        {
            get { return _sys_codcom_comp; }
            set
            {
                if (_sys_codcom_comp == value) return;
                _sys_codcom_comp = value;
                OnPropertyChanged("Sys_codcom_comp");
            }
        }
        #endregion
        #region Sys_prmetr_comp: Parámetros
        private String _sys_prmetr_comp;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Parámetros</para>
        /// <para>NOMBRE: sys_prmetr_comp (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Expresión de texto que se agregan como parámetros en los casos
        /// que sean requeridos
        /// </para>
        /// </summary>
        public String Sys_prmetr_comp
        {
            get { return _sys_prmetr_comp; }
            set
            {
                if (_sys_prmetr_comp == value) return;
                _sys_prmetr_comp = value;
                OnPropertyChanged("Sys_prmetr_comp");
            }
        }
        #endregion
        #region Sys_estccp_cper: Estado componente
        private String _sys_estccp_cper;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Estado componente</para>
        /// <para>NOMBRE: sys_estccp_cper (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del Componente  dentro del perfil  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sys_estccp_cper
        {
            get { return _sys_estccp_cper; }
            set
            {
                if (_sys_estccp_cper == value) return;
                _sys_estccp_cper = value;
                OnPropertyChanged("Sys_estccp_cper");
            }
        }
        #endregion
        #region Sys_desper_perf: Nombre del Perfil
        private String _sys_desper_perf;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
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
        #region Sys_nommod_modu: Nombre Módulo
        private String _sys_nommod_modu;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Nombre Módulo</para>
        /// <para>NOMBRE: sys_nommod_modu (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del Módulo, que se mostrara como titulo en las opciones
        /// del sistema
        /// </para>
        /// </summary>
        public String Sys_nommod_modu
        {
            get { return _sys_nommod_modu; }
            set
            {
                if (_sys_nommod_modu == value) return;
                _sys_nommod_modu = value;
                OnPropertyChanged("Sys_nommod_modu");
            }
        }
        #endregion
        #region Sys_titcom_comp: Titulo del componente
        private String _sys_titcom_comp;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Titulo del componente</para>
        /// <para>NOMBRE: sys_titcom_comp (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Titulo de la opción, este texto se mostrara en las opciones
        /// del menú del sistema
        /// </para>
        /// </summary>
        public String Sys_titcom_comp
        {
            get { return _sys_titcom_comp; }
            set
            {
                if (_sys_titcom_comp == value) return;
                _sys_titcom_comp = value;
                OnPropertyChanged("Sys_titcom_comp");
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
        public static bool flgAddRegistro(ModeloSysperfiusuariocomp tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFsyscomponperfil();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tobTempReg.Sys_codreg_cper);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.sys_codreg_cper = tobTempReg.Sys_codreg_cper;
                            lobEFReg.sys_codper_perf = tobTempReg.Sys_codper_perf;
                            lobEFReg.sys_codcom_comd = tobTempReg.Sys_codcom_comd;
                            lobEFReg.sys_codmod_modu = tobTempReg.Sys_codmod_modu;
                            lobEFReg.sys_llavco_cper = tobTempReg.Sys_llavco_cper;
                            lobEFReg.sys_codcom_comp = tobTempReg.Sys_codcom_comp;
                            lobEFReg.sys_prmetr_comp = tobTempReg.Sys_prmetr_comp;
                            lobEFReg.sys_estccp_cper = tobTempReg.Sys_estccp_cper;
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
                                lobEFReg.sys_codreg_cper = tcrCodigoR1 + lobEFReg.sys_codreg_cper; // concatenar
                                _context.AddToSyscomponperfil(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tobTempReg.Sys_codreg_cper);
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
        #region Buscar SYSCOMPONPERFIL: Logica
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TITULO: Componentes asignados a un perfil</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Componentes asignados a un perfil (por defecto al P01 ADMIN
        /// se le asignan todos los permisos), registra todos los componentes
        /// a los cuales un perfil pude accesar y que se muestran en el
        /// menú del sistema, cuando un usuario con perfil tal inicia sesió
        /// </para>
        /// </summary>
        public static bool flgBuscarSyscomponperfil(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Syscomponperfil.FirstOrDefault(p => p.sys_codreg_cper == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSysperfiusuariocomp> flsListaSyscomponperfil(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from syscomponperfil in _context.Syscomponperfil
                                  join sysperfiusuario in _context.Sysperfiusuario on syscomponperfil.sys_codper_perf equals sysperfiusuario.sys_codper_perf into tmsysperfiusuario
                                  join syscompmodulos in _context.Syscompmodulos on syscomponperfil.sys_codcom_comd equals syscompmodulos.sys_codcom_comd into tmsyscompmodulos
                                  join sysmodulosistem in _context.Sysmodulosistem on syscomponperfil.sys_codmod_modu equals sysmodulosistem.sys_codmod_modu into tmsysmodulosistem
                                  join syscomponentes in _context.Syscomponentes on syscomponperfil.sys_codcom_comp equals syscomponentes.sys_codcom_comp into tmsyscomponentes
                                  from perf in tmsysperfiusuario.DefaultIfEmpty()
                                  from comd in tmsyscompmodulos.DefaultIfEmpty()
                                  from modu in tmsysmodulosistem.DefaultIfEmpty()
                                  from comp in tmsyscomponentes.DefaultIfEmpty()
                                  where syscomponperfil.sys_codper_perf == tcrBuscar
                                  select new ModeloSysperfiusuariocomp
                                  {
                                      Sys_codreg_cper = syscomponperfil.sys_codreg_cper,
                                      Sys_codper_perf = syscomponperfil.sys_codper_perf,
                                      Sys_codcom_comd = syscomponperfil.sys_codcom_comd,
                                      Sys_codmod_modu = syscomponperfil.sys_codmod_modu,
                                      Sys_llavco_cper = syscomponperfil.sys_llavco_cper,
                                      Sys_codcom_comp = syscomponperfil.sys_codcom_comp,
                                      Sys_prmetr_comp = syscomponperfil.sys_prmetr_comp,
                                      Sys_estccp_cper = syscomponperfil.sys_estccp_cper,
                                      Sys_desper_perf = perf.sys_desper_perf,
                                      Sys_nommod_modu = modu.sys_nommod_modu,
                                      Sys_titcom_comp = comp.sys_titcom_comp,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
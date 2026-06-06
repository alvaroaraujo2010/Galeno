using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Datos.Modelos;
using Sistema.Utilidades;

namespace Sistema.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclxxcontrol
    /// </summary>
    public class ModeloHclxxcontrol : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_regist_hixx: Codigo unico  bloque
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Codigo unico  bloque</para>
        /// <para>NOMBRE: hcl_regist_hixx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del registro que representa el bloque de proceso
        /// </para>
        /// </summary>
        public String Hcl_regist_hixx = String.Empty;
        #endregion
        #region Hcl_ordges_hixx: Orden secuencial gestion
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Orden secuencial gestion</para>
        /// <para>NOMBRE: hcl_ordges_hixx (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Orden secuencial para gestion en procesos
        /// </para>
        /// </summary>
        public int Hcl_ordges_hixx = 0;
        #endregion
        #region Hcl_rangoi_hixx: Rango inicial de registros
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Rango inicial de registros</para>
        /// <para>NOMBRE: hcl_rangoi_hixx (int:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Rango inicial de registros asignados
        /// </para>
        /// </summary>
        public int Hcl_rangoi_hixx = 0;
        #endregion
        #region Hcl_rangof_hixx: Rango final registros
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Rango final registros</para>
        /// <para>NOMBRE: hcl_rangof_hixx (int:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Rango final de registros asignados
        /// </para>
        /// </summary>
        public int Hcl_rangof_hixx = 0;
        #endregion
        #region Hcl_usuasi_hixx: Usuario del rango
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Usuario del rango</para>
        /// <para>NOMBRE: hcl_usuasi_hixx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Usuario al cual fue asigando el bloque de proceso
        /// </para>
        /// </summary>
        public String Hcl_usuasi_hixx = String.Empty;
        #endregion
        #region Hcl_avance_hixa: Avance Proceso
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxavance</para>
        /// <para>CAMPO: Avance Proceso</para>
        /// <para>NOMBRE: hcl_avance_hixa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///total registros procesados por el usario en tiempo real
        /// </para>
        /// </summary>
        public int Hcl_avance_hixa = 0;
        #endregion
        #region Hcl_estado_hixx: Código Estado Registro
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: hcl_estado_hixx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Estado proceso del  registros  :1 = Libre para ser asignado
        /// 2 = Activo o en proceso 3= Detenido o interrumpido por algun
        /// error 4=Finalizado
        /// </para>
        /// </summary>
        public String Hcl_estado_hixx = String.Empty;
        #endregion
        #region Hcl_error_hixx: Descripcion del Error
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Descripcion del Error</para>
        /// <para>NOMBRE: hcl_error_hixx (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Texto del error por el cual el proceso esta detenido
        /// </para>
        /// </summary>
        public String Hcl_error_hixx = String.Empty;
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHclxxcontrol tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLXXCONTROL", "HCL", "Maestro control proceso conversion historicos");
            try
            {
                if (!flgBuscarHclxxcontrol(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclxxcontrol
                        {
                            #region cargar Registro
                            hcl_regist_hixx = tobjModelo.Hcl_regist_hixx,
                            hcl_ordges_hixx = tobjModelo.Hcl_ordges_hixx,
                            hcl_rangoi_hixx = tobjModelo.Hcl_rangoi_hixx,
                            hcl_rangof_hixx = tobjModelo.Hcl_rangof_hixx,
                            hcl_usuasi_hixx = tobjModelo.Hcl_usuasi_hixx,
                            hcl_avance_hixa = tobjModelo.Hcl_avance_hixa,
                            hcl_estado_hixx = tobjModelo.Hcl_estado_hixx,
                            hcl_error_hixx = tobjModelo.Hcl_error_hixx,
                            #endregion
                        };
                        lobjRegistro.hcl_regist_hixx = lcrCodigoGen;
                        _context.AddToHclxxcontrol(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLXXCONTROL': Maestro control proceso conversion historicos en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Actualizar Registro
        public static void fcvActualizar(ModeloHclxxcontrol tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tobjModelo.Hcl_regist_hixx);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_usuasi_hixx = tobjModelo.Hcl_usuasi_hixx;
                        lobjRegistro.hcl_estado_hixx = tobjModelo.Hcl_estado_hixx;
                        lobjRegistro.hcl_error_hixx  = tobjModelo.Hcl_error_hixx;
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
        #region Actualizar registro error
        public static void fcvActualizarError(String tcrCodigoBloque, String tcrError)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigoBloque);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_error_hixx = tcrError;
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
        #region fcvActualizarAvanceBloque Actualizar Avance del Bloque activo
        public static void fcvActualizarAvanceBloque(String tcrCodigoBloque, int tnuAvance)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigoBloque);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_avance_hixa = lobjRegistro.hcl_avance_hixa + tnuAvance;
                        #endregion
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizarAvance");
            }
        }
        #endregion
        #region fnuConsultarAvanceTotal Consultar avance total de todo el proceso en base de datos
        public static int fnuConsultarAvanceTotal()
        {
            int lnuTotal = 0;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobConsulta = (from hclxxcontrol in _context.Hclxxcontrol
                                       where hclxxcontrol.hcl_avance_hixa > 0
                                       select new { hcl_avance_hixa = (int)hclxxcontrol.hcl_avance_hixa }).ToList();

                    lnuTotal = lobConsulta.Sum(elemento => elemento.hcl_avance_hixa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizarAvance");
            }
            return lnuTotal;
        }
        #endregion
        #region flgAsignarProceso Asignar un bloque de proceso
        /// <summary>
        /// Verificar y Asignar un bloque de proceso a un usuario
        /// </summary>
        public static bool flgAsignarProceso(String tcrCodigoBloque, String tcrCodigoUsuario)
        {
            var llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigoBloque);
                    if (lobjRegistro != null)
                    {
                        // Que este libre 
                        if (lobjRegistro.hcl_estado_hixx == "1")
                        {
                            llgReturn = true;
                            #region cargar Registro
                            lobjRegistro.hcl_usuasi_hixx = tcrCodigoUsuario;
                            lobjRegistro.hcl_estado_hixx = "2";
                            #endregion
                        }
                        else if (lobjRegistro.hcl_estado_hixx == "2" || lobjRegistro.hcl_estado_hixx == "3")
                        {
                            if (lobjRegistro.hcl_usuasi_hixx == tcrCodigoUsuario)
                            {
                                lobjRegistro.hcl_estado_hixx = "2";
                                llgReturn = true;
                            }
                        }
                        // Gaurdar el cambio
                        if (llgReturn == true)
                        {
                            _context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAsignarProceso");
            }
            return llgReturn;
        }
        #endregion
        #region flgSiProcesoAsignado Asignar un bloque de proceso
        /// <summary>
        /// Verificar si el proceso fue asignado correctamente al usuario activo
        /// </summary>
        public static bool flgSiProcesoAsignado(String tcrCodigoBloque, String tcrCodigoUsuario)
        {
            var llgReturn = false;
            try
            {
                Thread.Sleep(50); // darle tiempo a alguna transaccion que este actualizando el registro 
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigoBloque);
                    if (lobjRegistro != null)
                    {
                        if (lobjRegistro.hcl_estado_hixx == "2" || lobjRegistro.hcl_estado_hixx == "3")
                        {
                            if (lobjRegistro.hcl_usuasi_hixx == tcrCodigoUsuario)
                            {
                                llgReturn = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgSiProcesoAsignado");
            }
            return llgReturn;
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigo);
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
        #region Buscar HCLXXCONTROL: Logica
        /// <summary>
        /// <para>TABLA: hclxxcontrol</para>
        /// <para>TITULO: Maestro control proceso conversion historicos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro control proceso conversion historicos
        /// </para>
        /// </summary>
        public static bool flgBuscarHclxxcontrol(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclxxcontrol.FirstOrDefault(p => p.hcl_regist_hixx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclxxcontrol> flsListaHclxxcontrol(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclxxcontrol in _context.Hclxxcontrol
                                      orderby hclxxcontrol.hcl_ordges_hixx
                                      select new ModeloHclxxcontrol
                                      {
                                          #region Datos
                                          Hcl_regist_hixx = hclxxcontrol.hcl_regist_hixx,
                                          Hcl_ordges_hixx = (int)hclxxcontrol.hcl_ordges_hixx,
                                          Hcl_rangoi_hixx = (int)hclxxcontrol.hcl_rangoi_hixx,
                                          Hcl_rangof_hixx = (int)hclxxcontrol.hcl_rangof_hixx,
                                          Hcl_usuasi_hixx = hclxxcontrol.hcl_usuasi_hixx,
                                          Hcl_avance_hixa = (int)hclxxcontrol.hcl_avance_hixa,
                                          Hcl_estado_hixx = hclxxcontrol.hcl_estado_hixx,
                                          Hcl_error_hixx = hclxxcontrol.hcl_error_hixx,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclxxcontrol in _context.Hclxxcontrol
                                      where hclxxcontrol.hcl_regist_hixx == tcrBuscar
                                      orderby hclxxcontrol.hcl_ordges_hixx
                                      select new ModeloHclxxcontrol
                                      {
                                          #region Datos
                                          Hcl_regist_hixx = hclxxcontrol.hcl_regist_hixx,
                                          Hcl_ordges_hixx = (int)hclxxcontrol.hcl_ordges_hixx,
                                          Hcl_rangoi_hixx = (int)hclxxcontrol.hcl_rangoi_hixx,
                                          Hcl_rangof_hixx = (int)hclxxcontrol.hcl_rangof_hixx,
                                          Hcl_usuasi_hixx = hclxxcontrol.hcl_usuasi_hixx,
                                          Hcl_avance_hixa = (int)hclxxcontrol.hcl_avance_hixa,
                                          Hcl_estado_hixx = hclxxcontrol.hcl_estado_hixx,
                                          Hcl_error_hixx = hclxxcontrol.hcl_error_hixx,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclxxproceso
    /// </summary>
    public class ModeloHclxxproceso : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hixp: Codigo unico registro
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclxxproceso</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: hcl_nroreg_hixp (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial del registro igual que  evento medico en
        /// historial
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hixp = String.Empty;
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código secuencial del evento medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev = String.Empty;
        #endregion
        #region Hcl_regist_hixx: Codigo unico  bloque
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclxxcontrol</para>
        /// <para>CAMPO: Codigo unico  bloque</para>
        /// <para>NOMBRE: hcl_regist_hixx (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del registro que representa el bloque de proceso
        /// </para>
        /// </summary>
        public String Hcl_regist_hixx = String.Empty;
        #endregion
        #region Hcl_secreg_hcev: Secuencial evento
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcev (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del evento medico, generado desde el contador
        /// en registro maestro de historia clinica del paciente, para
        /// organizar la vista
        /// </para>
        /// </summary>
        public int Hcl_secreg_hcev = 0;
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
        /// </para>
        /// </summary>
        public String Adm_secadm_rgad = String.Empty;
        #endregion
        #region Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public String Sia_tipide_tide = String.Empty;
        #endregion
        #region Sia_nroide_usua: Numero de Identificación
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public String Sia_nroide_usua = String.Empty;
        #endregion
        #region Hcl_gesfec_hcev: Fecha servicio
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcev = DateTime.Parse("01/01/00001");
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl = String.Empty;
        #endregion
        #region Grp_idepla_grpv: Código version plantilla
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la version plantilla usada
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv = String.Empty;
        #endregion
        #region Hcl_archiv_hcev: Destino datos archivo
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Destino datos archivo</para>
        /// <para>NOMBRE: hcl_archiv_hcev (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Indica en que tipo destino se guardo el registro de datos del
        /// evento actual XM = Formato XML dentro del registro actual
        /// 01=Grupo de archivos Historicos01  02 = Grupos de archivos02
        /// y 03 Grupo archivos … hasta el grupo 10
        /// </para>
        /// </summary>
        public String Hcl_archiv_hcev = String.Empty;
        #endregion
        #region Hcl_observ_hixp: observacion
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclxxproceso</para>
        /// <para>CAMPO: observacion</para>
        /// <para>NOMBRE: hcl_observ_hixp (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Observacion que se genera en el proceso de conversion de datos
        /// </para>
        /// </summary>
        public String Hcl_observ_hixp = String.Empty;
        #endregion
        #region Sis_estpro_espr: Estado Registro
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Estado de procesos en atencion asistencial : 1= Abierto  2=
        /// Cerrado/Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr = String.Empty;
        #endregion
        #region Hcl_xmldat_hcev: Datos formato XML diligenciados
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Datos formato XML diligenciados</para>
        /// <para>NOMBRE: Hcl_xmldat_hcev (texto: largo)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Datos en formato XML diligenciados en plantilla (incluye imágenes y objetos vistas del muro) para cada registro
        /// </para>
        /// </summary>
        public String Hcl_xmldat_hcev = String.Empty;
        #endregion
        #region Grp_despla_grpl: Nombre o descripcion de la plantilla en usu
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: Grpmaeplantilla</para>
        /// <para>CAMPO: Nombre Plantilla</para>
        /// <para>NOMBRE: Grp_despla_grpl (texto: 100)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion de la plantilla en usu
        /// </para>
        /// </summary>
        public String Grp_despla_grpl = String.Empty;
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHclxxproceso tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLXXPROCESO", "HCL", "Maestro historial actividades clinicas pacientes para el proceso");
            try
            {
                if (!flgBuscarHclxxproceso(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclxxproceso
                        {
                            #region cargar Registro
                            hcl_nroreg_hixp = tobjModelo.Hcl_nroreg_hixp,
                            hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                            hcl_regist_hixx = tobjModelo.Hcl_regist_hixx,
                            hcl_secreg_hcev = tobjModelo.Hcl_secreg_hcev,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                            sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                            hcl_gesfec_hcev = tobjModelo.Hcl_gesfec_hcev,
                            grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                            grp_idepla_grpv = tobjModelo.Grp_idepla_grpv,
                            hcl_archiv_hcev = tobjModelo.Hcl_archiv_hcev,
                            hcl_observ_hixp = tobjModelo.Hcl_observ_hixp,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.hcl_nroreg_hixp = lcrCodigoGen;
                        _context.AddToHclxxproceso(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLXXPROCESO': Maestro historial actividades clinicas pacientes para el proceso en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Actualizar Registro en historial auxiliar
        public static void fcvActualizar(ModeloHclxxproceso tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclxxproceso.FirstOrDefault(p => p.hcl_nroreg_hixp == tobjModelo.Hcl_nroreg_hixp);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_archiv_hcev = tobjModelo.Hcl_archiv_hcev;
                        lobjRegistro.hcl_observ_hixp = tobjModelo.Hcl_observ_hixp;
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
                    var lobjRegistro = _context.Hclxxproceso.FirstOrDefault(p => p.hcl_nroreg_hixp == tcrCodigo);
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
        #region Buscar HCLXXPROCESO: Logica
        /// <summary>
        /// <para>TABLA: hclxxproceso</para>
        /// <para>TITULO: Maestro historial actividades clinicas pacientes para el pro</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro historial actividades clinicas pacientes para el proceso
        /// </para>
        /// </summary>
        public static bool flgBuscarHclxxproceso(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclxxproceso.FirstOrDefault(p => p.hcl_nroreg_hixp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclxxproceso> flsListaHclxxproceso(String tcrCodigoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hclxxproceso in _context.Hclxxproceso
                                  join hclregiseventos in _context.Hclregiseventos on hclxxproceso.hcl_nroreg_hcev equals hclregiseventos.hcl_nroreg_hcev into tmhclregiseventos
                                  from hcev in tmhclregiseventos.DefaultIfEmpty()
                                  where hclxxproceso.hcl_nroreg_hixp == tcrCodigoRegistro
                                  select new ModeloHclxxproceso
                                  {
                                      #region Datos
                                      Hcl_nroreg_hixp = hclxxproceso.hcl_nroreg_hixp,
                                      Hcl_nroreg_hcev = hclxxproceso.hcl_nroreg_hcev,
                                      Hcl_regist_hixx = hclxxproceso.hcl_regist_hixx,
                                      Hcl_secreg_hcev = (int)hclxxproceso.hcl_secreg_hcev,
                                      Adm_secadm_rgad = hclxxproceso.adm_secadm_rgad,
                                      Sia_tipide_tide = hclxxproceso.sia_tipide_tide,
                                      Sia_nroide_usua = hclxxproceso.sia_nroide_usua,
                                      Hcl_gesfec_hcev = (DateTime)hclxxproceso.hcl_gesfec_hcev,
                                      Grp_idepla_grpl = hclxxproceso.grp_idepla_grpl,
                                      Grp_idepla_grpv = hclxxproceso.grp_idepla_grpv,
                                      Hcl_archiv_hcev = hclxxproceso.hcl_archiv_hcev,
                                      Hcl_observ_hixp = hclxxproceso.hcl_observ_hixp,
                                      Sis_estpro_espr = hclxxproceso.sis_estpro_espr,
                                      Hcl_xmldat_hcev = hcev.hcl_xmldat_hcev,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar Registros de un bloque de proceso
        public static List<ModeloHclxxproceso> flsListaHclxxprocesoBloque(String tcrCodigoBloque)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hclxxproceso in _context.Hclxxproceso
                                  join grpmaeplantilla in _context.Grpmaeplantilla on hclxxproceso.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                  from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                  where hclxxproceso.hcl_regist_hixx == tcrCodigoBloque
                                  orderby hclxxproceso.hcl_secreg_hcev
                                  select new ModeloHclxxproceso
                                  {
                                      #region Datos
                                      Hcl_nroreg_hixp = hclxxproceso.hcl_nroreg_hixp,
                                      Hcl_nroreg_hcev = hclxxproceso.hcl_nroreg_hcev,
                                      Hcl_regist_hixx = hclxxproceso.hcl_regist_hixx,
                                      Hcl_secreg_hcev = (int)hclxxproceso.hcl_secreg_hcev,
                                      Adm_secadm_rgad = hclxxproceso.adm_secadm_rgad,
                                      Sia_tipide_tide = hclxxproceso.sia_tipide_tide,
                                      Sia_nroide_usua = hclxxproceso.sia_nroide_usua,
                                      Hcl_gesfec_hcev = (DateTime)hclxxproceso.hcl_gesfec_hcev,
                                      Grp_idepla_grpl = hclxxproceso.grp_idepla_grpl,
                                      Grp_idepla_grpv = hclxxproceso.grp_idepla_grpv,
                                      Hcl_archiv_hcev = hclxxproceso.hcl_archiv_hcev,
                                      Hcl_observ_hixp = hclxxproceso.hcl_observ_hixp,
                                      Sis_estpro_espr = hclxxproceso.sis_estpro_espr,
                                      Grp_despla_grpl = grpl.grp_despla_grpl,
                                      #endregion
                                  };
                return lobConsulta.ToList();
                /*
                var lobConsulta = from hclxxproceso in _context.Hclxxproceso
                                  join hclregiseventos in _context.Hclregiseventos on hclxxproceso.hcl_nroreg_hcev equals hclregiseventos.hcl_nroreg_hcev into tmhclregiseventos
                                  from hcev in tmhclregiseventos.DefaultIfEmpty()
                                  where hclxxproceso.hcl_regist_hixx == tcrCodigoBloque
                                  orderby hclxxproceso.hcl_secreg_hcev
                                  select new ModeloHclxxproceso
                                  {
                                      #region Datos
                                      Hcl_nroreg_hixp = hclxxproceso.hcl_nroreg_hixp,
                                      Hcl_nroreg_hcev = hclxxproceso.hcl_nroreg_hcev,
                                      Hcl_regist_hixx = hclxxproceso.hcl_regist_hixx,
                                      Hcl_secreg_hcev = (int)hclxxproceso.hcl_secreg_hcev,
                                      Adm_secadm_rgad = hclxxproceso.adm_secadm_rgad,
                                      Sia_tipide_tide = hclxxproceso.sia_tipide_tide,
                                      Sia_nroide_usua = hclxxproceso.sia_nroide_usua,
                                      Hcl_gesfec_hcev = (DateTime)hclxxproceso.hcl_gesfec_hcev,
                                      Grp_idepla_grpl = hclxxproceso.grp_idepla_grpl,
                                      Grp_idepla_grpv = hclxxproceso.grp_idepla_grpv,
                                      Hcl_archiv_hcev = hclxxproceso.hcl_archiv_hcev,
                                      Hcl_observ_hixp = hclxxproceso.hcl_observ_hixp,
                                      Sis_estpro_espr = hclxxproceso.sis_estpro_espr,
                                      Hcl_xmldat_hcev = hcev.hcl_xmldat_hcev,
                                      #endregion
                                  };
                return lobConsulta.ToList();
                */
            }
        }
        #endregion
        #region Contar total registros a procesar en general
        public static int fnuTotalRegistrosGeneral()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hclxxproceso in _context.Hclxxproceso
                                  select new 
                                  {
                                      Hcl_nroreg_hixp = hclxxproceso.hcl_nroreg_hixp,
                                  };
                return lobConsulta.ToList().Count;
            }
        }
        #endregion
        #endregion
    }

}

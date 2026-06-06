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

namespace ConfigAsistencial.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: siatablaeps
    /// </summary>
    public class ModeloHistorialHc : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        // aqui las propiedades
        #region Hcl_nroreg_hcev: Codigo Evento medico
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial del evento medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev { get; set; }
        #endregion
        #region Hcl_codaux_hcev: Codigo auxiliar de gestion registros
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: Hcl_codaux_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo auxiliar de gestion registros para referencia a datos adicionales
        /// </para>
        /// </summary>
        public String Hcl_codaux_hcev { get; set; }
        #endregion
        #region Hcl_codreg_hcca: Clasificacion Tipo de registro actividad
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: Hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///  Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL = Apertura Historia clinica
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcca { get; set; }
        #endregion
        #region Hcl_desreg_hcev: Descripción Evento
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev { get; set; }
        #endregion
        #region Hcl_gesfec_hcev: Fecha servicio
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcev  { get; set; }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr { get; set; }
        #endregion
        /// <summary>marca de seleccion Boleana</summary>
        public bool MarcaBool { get; set; }
        public static Aplicacion oApp = Aplicacion.Instancia();
        #endregion
        #region Modificar registros historial clinico
        public static bool flgModificarRegHistoral(String tcrValor, List<ModeloHistorialHc> tmpHistorial)
        {
            var llgReturn = false;
            EFhclregiseventos lobjRegistro = null;
            //-------------------------------------------------------------
            // Gestion registros en tabla vista historial clinico
            //-------------------------------------------------------------
            #region Gestion registros en tabla vista historial clinico
            using (_context = new DbAplicacion())
            {
                foreach (var loReg in tmpHistorial)
                {
                    if (loReg.MarcaBool == true) // esta seleccionado
                    {
                        lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == loReg.Hcl_nroreg_hcev);
                        if (lobjRegistro != null)
                        {
                            // verficar si son datos de odontologia
                            if (lobjRegistro.hcl_codreg_hcca == "HCL-CAPTURA-ODAP" ||
                                lobjRegistro.hcl_codreg_hcca == "HCL-CAPTURA-ODDX" ||
                                lobjRegistro.hcl_codreg_hcca == "HCL-CAPTURA-ODTR" ||
                                lobjRegistro.hcl_codreg_hcca == "HCL-CAPTURA-ODEV" ||
                                lobjRegistro.hcl_codreg_hcca == "HCL-CAPTURA-ODIM")
                            {
                               // flgModificarRegHistoralOdontologia(lobjRegistro.hcl_codaux_hcev, lobjRegistro.hcl_codreg_hcca, tcrValor);
                            }

                            if (tcrValor == "4") // Eliminar registro
                            {
                                _context.DeleteObject(lobjRegistro);
                            }
                            else
                            {
                                lobjRegistro.sis_estpro_espr = tcrValor;
                            }
                            llgReturn = true;
                        }
                    }
                }

                if (llgReturn == true)
                {
                    _context.SaveChanges();
                }
            }
            #endregion
            //-------------------------------------------------------------
            // cuando es eliminar, ir a todas las tablas del guardado HC registros en tablas
            //-------------------------------------------------------------
            #region Eliminar datos del Registros en tablas
            if (tcrValor == "4")
            {
                foreach (var loReg in tmpHistorial)
                {
                    if (loReg.MarcaBool == true) // esta seleccionado
                    {
                        ModeloHclAcciones.flgEliminarRegistro(loReg.Hcl_nroreg_hcev, oApp.gcrAppBdatosArchvioGuardarDatos);
                    }
                }
            }
            #endregion
            //-------------------------------------------------------------
            // Modificacion las evoluciones medicas y notas de enfermeria
            //-------------------------------------------------------------
            #region Modificar datos en tablas de evoluciones medicas
            foreach (var loReg in tmpHistorial)
            {
                if (loReg.MarcaBool == true) // esta seleccionado
                {
                    if (loReg.Hcl_codreg_hcca == "HCL-CAPTURA-EVOL" || loReg.Hcl_codreg_hcca == "HCL-CAPTURA-NENF")
                    {
                        ModeloHclregordeserms.fcvActualizarEstadoRegistro(loReg.Hcl_codaux_hcev, tcrValor);
                        ModeloHclregnotasmedi.fcvActualizarEstadoRegistrosEvento(loReg.Hcl_codaux_hcev, tcrValor);
                    }
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgModificarRegHistoralOdontologia: Modificar registros historia clinica de odontologia
        public static bool flgModificarRegHistoralOdontologia(String tcrIdRegistro, String tcrTipoRegistro, String tcrValor)
        {
            var llgReturn = false;

            #region Tratamiento
            if (tcrTipoRegistro == "HCL-CAPTURA-ODAP")
            {
                //MessageBox.Show("aqui voy 2");

                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrIdRegistro);
                if (lobjRegistro != null)
                {
                    //MessageBox.Show("aqui voy 3");

                    if (tcrValor == "4") // Eliminar registro
                    {
                        //MessageBox.Show("aqui voy 4");
                        _context.DeleteObject(lobjRegistro);
                    }
                    else
                    {
                        //MessageBox.Show("aqui voy 5");
                        lobjRegistro.sis_estpro_espr = tcrValor;
                    }
                }
            }
            else
            {
                // Los restantes  son en la dos tablas
                #region  Registro Maestro 
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrIdRegistro);
                if (lobjRegistro != null)
                {
                    if (tcrValor == "4") // Eliminar registro
                    {
                        _context.DeleteObject(lobjRegistro);
                    }
                    else
                    {
                        lobjRegistro.sis_estpro_espr = tcrValor;
                    }

                    // Modificar los registros tipo detalles
                    var lobConsulta = from tmp in _context.Odneventosactde where tmp.odn_nroreg_odac == tcrIdRegistro select tmp;
                    if (lobConsulta != null)
                    {
                        foreach (var lobReg in lobConsulta)
                        {
                            if (tcrValor == "4") // Eliminar registro
                            {
                                _context.DeleteObject(lobReg);
                            }
                            else
                            {
                                lobReg.sis_estpro_espr = tcrValor;
                            }

                        }
                    }
                }
                #endregion
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flsBuscarHistorialEventos: Listar Registros
        /// <summary>
        /// Seleccionar registros que pertenecen a una admisión
        /// </summary>
        public static List<ModeloHistorialHc> flsBuscarHistorialEventos(String tcrCodigoAdmision)
        {
            //List<ModeloHistorialEventos> lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                #region Registros
                var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                  join sisestadoproces in _context.Sisestadoproces on hclregiseventos.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where hclregiseventos.adm_secadm_rgad == tcrCodigoAdmision
                                  orderby hclregiseventos.hcl_secreg_hcev descending
                                  select new ModeloHistorialHc
                                  {
                                      Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                      Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                      Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                      Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                      Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      MarcaBool = false,
                                  };
                #endregion
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flgEliminaAdmision: Eliminar todos los registro de la admision
        /// <summary>
        /// Eliminar todos los registro de la admision
        /// </summary>
        public static bool flgEliminaAdmision(String tcrCodigoAdmision)
        {
            var llgReturn = true;
            #region Eliminar Admision
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigoAdmision);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar Maestro facturas
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Fcmmaesfacturas where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar detalles facturas
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Fcmmaedetallfac where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar Maestro historial
            IQueryable<EFhclregiseventos> tmpHistorial = null;
            using (_context = new DbAplicacion())
            {
                tmpHistorial = from tmp in _context.Hclregiseventos where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (tmpHistorial != null)
                {
                    foreach (var lobReg in tmpHistorial)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            // Eliminar de tablas los detalles de cada registro del historial
            if (tmpHistorial != null)
            {
                foreach (var lobReg in tmpHistorial)
                {
                    ModeloHclAcciones.flgEliminarRegistro(lobReg.hcl_nroreg_hcev, oApp.gcrAppBdatosArchvioGuardarDatos);
                }
            }
            #endregion
            #region Eliminar Maestro egreso urgencias
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Admregurgencias where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar Maestro egreso hospitalizacion
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Admregistegreso where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar Maestro Ordenes servicio h.clinica
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Hclregordeserms where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar detalles Ordenes servicio h.clinica
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Hclregordeserde where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            #region Eliminar Maestro asignacion de citas
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Citmaesasigcita where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    _context.SaveChanges();
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
    }
}

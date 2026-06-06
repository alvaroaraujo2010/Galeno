//- MARMOTA-GENCODE: VERSION 2.0 - 07/05/2015 07:39:00 AM
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

namespace Hospitalizacion.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hoscamasareas
    /// </summary>
    public class ModeloHoscamasareas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hos_codcam_caho: Codigo cama
        private String _hos_codcam_caho;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Codigo cama</para>
        /// <para>NOMBRE: hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo Cama generado por el sistema
        /// </para>
        /// </summary>
        public String Hos_codcam_caho
        {
            get { return _hos_codcam_caho; }
            set
            {
                if (_hos_codcam_caho == value) return;
                _hos_codcam_caho = value;
                OnPropertyChanged("Hos_codcam_caho");
            }
        }
        #endregion
        #region Hos_nrohab_habi: Habitacion
        private String _hos_nrohab_habi;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Habitacion</para>
        /// <para>NOMBRE: hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo o numero de habitacion en area de servicios donde se
        /// encuentra la cama, ejemplo: N201= Segundo piso Neonatos habitacion
        /// 201
        /// </para>
        /// </summary>
        public String Hos_nrohab_habi
        {
            get { return _hos_nrohab_habi; }
            set
            {
                if (_hos_nrohab_habi == value) return;
                _hos_nrohab_habi = value;
                OnPropertyChanged("Hos_nrohab_habi");
            }
        }
        #endregion
        #region Hos_descam_caho: Descripcion cama
        private String _hos_descam_caho;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public String Hos_descam_caho
        {
            get { return _hos_descam_caho; }
            set
            {
                if (_hos_descam_caho == value) return;
                _hos_descam_caho = value;
                OnPropertyChanged("Hos_descam_caho");
            }
        }
        #endregion
        #region Hos_tipcam_tcam: Tipo cama
        private String _hos_tipcam_tcam;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Tipo cama</para>
        /// <para>NOMBRE: hos_tipcam_tcam (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo cama : 01 =Reclinable electronica   2=Reclinable
        /// Mecanica, otras
        /// </para>
        /// </summary>
        public String Hos_tipcam_tcam
        {
            get { return _hos_tipcam_tcam; }
            set
            {
                if (_hos_tipcam_tcam == value) return;
                _hos_tipcam_tcam = value;
                OnPropertyChanged("Hos_tipcam_tcam");
            }
        }
        #endregion
        #region Hos_camaux_caho: Cama adecuada
        private String _hos_camaux_caho;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama adecuada</para>
        /// <para>NOMBRE: hos_camaux_caho (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cama adecuada o auxiliar imporvisada, cuando   no hay camas
        /// disponibles (en casos de urgencia), se utilizan camas no adecuadas:
        /// 1=Cama Adecuada 2=Cama Auxiliar
        /// </para>
        /// </summary>
        public String Hos_camaux_caho
        {
            get { return _hos_camaux_caho; }
            set
            {
                if (_hos_camaux_caho == value) return;
                _hos_camaux_caho = value;
                OnPropertyChanged("Hos_camaux_caho");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Codigo servicio estancia
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Codigo servicio estancia</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS con el cual se realiza
        /// el cobro de la estancia en la cama
        /// </para>
        /// </summary>
        public String Fcm_idesec_sips
        {
            get { return _fcm_idesec_sips; }
            set
            {
                if (_fcm_idesec_sips == value) return;
                _fcm_idesec_sips = value;
                OnPropertyChanged("Fcm_idesec_sips");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public String Fcm_coddig_mant
        {
            get { return _fcm_coddig_mant; }
            set
            {
                if (_fcm_coddig_mant == value) return;
                _fcm_coddig_mant = value;
                OnPropertyChanged("Fcm_coddig_mant");
            }
        }
        #endregion
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public String Fcm_codser_sips
        {
            get { return _fcm_codser_sips; }
            set
            {
                if (_fcm_codser_sips == value) return;
                _fcm_codser_sips = value;
                OnPropertyChanged("Fcm_codser_sips");
            }
        }
        #endregion
        #region Hos_codsec_hsec: Sección
        private String _hos_codsec_hsec;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion para las subdiviciones de Hopitalización y Urgencias
        /// con observación EJM:S001= Hospitalizacion Mujeres, S002 =Hospitalizacion
        /// Niños y otras
        /// </para>
        /// </summary>
        public String Hos_codsec_hsec
        {
            get { return _hos_codsec_hsec; }
            set
            {
                if (_hos_codsec_hsec == value) return;
                _hos_codsec_hsec = value;
                OnPropertyChanged("Hos_codsec_hsec");
            }
        }
        #endregion
        #region Hos_estcam_ecam: Disponibilidad
        private String _hos_estcam_ecam;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Disponibilidad</para>
        /// <para>NOMBRE: hos_estcam_ecam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion
        /// 5-Inactiva
        /// </para>
        /// </summary>
        public String Hos_estcam_ecam
        {
            get { return _hos_estcam_ecam; }
            set
            {
                if (_hos_estcam_ecam == value) return;
                _hos_estcam_ecam = value;
                OnPropertyChanged("Hos_estcam_ecam");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Estado
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama según estado habItacion  1= Activa 2=Inactiva
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Hos_deshab_habi: Nombre habitación
        private String _hos_deshab_habi;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Nombre habitación</para>
        /// <para>NOMBRE: hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public String Hos_deshab_habi
        {
            get { return _hos_deshab_habi; }
            set
            {
                if (_hos_deshab_habi == value) return;
                _hos_deshab_habi = value;
                OnPropertyChanged("Hos_deshab_habi");
            }
        }
        #endregion
        #region Hos_destip_tcam: Descripción tipo camas
        private String _hos_destip_tcam;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Descripción tipo camas</para>
        /// <para>NOMBRE: hos_destip_tcam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion Tipos de camas hospitalarias: Cama Metaica de somier
        /// Rigido,  Cama articulada, Cama electronica motorizada, Camas
        /// Ortopedicas y  mas
        /// </para>
        /// </summary>
        public String Hos_destip_tcam
        {
            get { return _hos_destip_tcam; }
            set
            {
                if (_hos_destip_tcam == value) return;
                _hos_destip_tcam = value;
                OnPropertyChanged("Hos_destip_tcam");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public String Fcm_desser_sips
        {
            get { return _fcm_desser_sips; }
            set
            {
                if (_fcm_desser_sips == value) return;
                _fcm_desser_sips = value;
                OnPropertyChanged("Fcm_desser_sips");
            }
        }
        #endregion
        #region Hos_dessec_hsec: Nombre sección
        private String _hos_dessec_hsec;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Nombre sección</para>
        /// <para>NOMBRE: hos_dessec_hsec (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion de la seccion de hospitalización o Urgencias con
        /// observación
        /// </para>
        /// </summary>
        public String Hos_dessec_hsec
        {
            get { return _hos_dessec_hsec; }
            set
            {
                if (_hos_dessec_hsec == value) return;
                _hos_dessec_hsec = value;
                OnPropertyChanged("Hos_dessec_hsec");
            }
        }
        #endregion
        #region Hos_desest_ecam: Decripcion estado cama
        private String _hos_desest_ecam;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Decripcion estado cama</para>
        /// <para>NOMBRE: hos_desest_ecam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del estado de la cama
        /// </para>
        /// </summary>
        public String Hos_desest_ecam
        {
            get { return _hos_desest_ecam; }
            set
            {
                if (_hos_desest_ecam == value) return;
                _hos_desest_ecam = value;
                OnPropertyChanged("Hos_desest_ecam");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHoscamasareas tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HOS-HOSCAMASAREAS", "HOS", "Camas por area prestacion servicios");
            if (!flgBuscarHoscamasareas(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhoscamasareas
                    {
                        #region cargar Registro
                        hos_codcam_caho = tobjModelo.Hos_codcam_caho,
                        hos_nrohab_habi = tobjModelo.Hos_nrohab_habi,
                        hos_descam_caho = tobjModelo.Hos_descam_caho,
                        hos_tipcam_tcam = tobjModelo.Hos_tipcam_tcam,
                        hos_camaux_caho = tobjModelo.Hos_camaux_caho,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                        hos_codsec_hsec = tobjModelo.Hos_codsec_hsec,
                        hos_estcam_ecam = tobjModelo.Hos_estcam_ecam,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.hos_codcam_caho = lcrCodigoGen;
                    _context.AddToHoscamasareas(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HOS-HOSCAMASAREAS': Camas por area prestacion servicios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHoscamasareas tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tobjModelo.Hos_codcam_caho);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hos_codcam_caho = tobjModelo.Hos_codcam_caho;
                    lobjRegistro.hos_nrohab_habi = tobjModelo.Hos_nrohab_habi;
                    lobjRegistro.hos_descam_caho = tobjModelo.Hos_descam_caho;
                    lobjRegistro.hos_tipcam_tcam = tobjModelo.Hos_tipcam_tcam;
                    lobjRegistro.hos_camaux_caho = tobjModelo.Hos_camaux_caho;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.hos_codsec_hsec = tobjModelo.Hos_codsec_hsec;
                    lobjRegistro.hos_estcam_ecam = tobjModelo.Hos_estcam_ecam;
                    lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Actaulizar estado de camas
        /// <summary>
        /// Cambiar el estado de la cama dada a : "1"=Libre "2"=Ocupada "3"=Reserva "4"=Reparación
        /// </summary>
        public static void fcvActualizarEstado(String tcrCodigoCama, String tcrEstado)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigoCama);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hos_estcam_ecam = tcrEstado;
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
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HOSCAMASAREAS: Logica
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TITULO: Camas por area prestacion servicios</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de camas creadas en el sistema, según las camas existentes
        /// en cada area funcional de la IPS ejm: Cama Hospitalizacion
        /// Mujeres, Cama Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public static bool flgBuscarHoscamasareas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHoscamasareas> flsListaHoscamasareas(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hoscamasareas in _context.Hoscamasareas
                                      join hoshabitaciones in _context.Hoshabitaciones on hoscamasareas.hos_nrohab_habi equals hoshabitaciones.hos_nrohab_habi into tmhoshabitaciones
                                      join hostipocamas in _context.Hostipocamas on hoscamasareas.hos_tipcam_tcam equals hostipocamas.hos_tipcam_tcam into tmhostipocamas
                                      join fcmmanservicips in _context.Fcmmanservicips on hoscamasareas.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join hosseccionareas in _context.Hosseccionareas on hoscamasareas.hos_codsec_hsec equals hosseccionareas.hos_codsec_hsec into tmhosseccionareas
                                      join hosestadocama in _context.Hosestadocama on hoscamasareas.hos_estcam_ecam equals hosestadocama.hos_estcam_ecam into tmhosestadocama
                                      from habi in tmhoshabitaciones.DefaultIfEmpty()
                                      from tcam in tmhostipocamas.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from hsec in tmhosseccionareas.DefaultIfEmpty()
                                      from ecam in tmhosestadocama.DefaultIfEmpty()
                                      select new ModeloHoscamasareas
                                      {
                                          Hos_codcam_caho = hoscamasareas.hos_codcam_caho,
                                          Hos_nrohab_habi = hoscamasareas.hos_nrohab_habi,
                                          Hos_descam_caho = hoscamasareas.hos_descam_caho,
                                          Hos_tipcam_tcam = hoscamasareas.hos_tipcam_tcam,
                                          Hos_camaux_caho = hoscamasareas.hos_camaux_caho,
                                          Fcm_idesec_sips = hoscamasareas.fcm_idesec_sips,
                                          Fcm_coddig_mant = hoscamasareas.fcm_coddig_mant,
                                          Hos_codsec_hsec = hoscamasareas.hos_codsec_hsec,
                                          Hos_estcam_ecam = hoscamasareas.hos_estcam_ecam,
                                          Sis_estreg_esrg = hoscamasareas.sis_estreg_esrg,
                                          Hos_deshab_habi = habi.hos_deshab_habi,
                                          Hos_destip_tcam = tcam.hos_destip_tcam,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Hos_dessec_hsec = hsec.hos_dessec_hsec,
                                          Hos_desest_ecam = ecam.hos_desest_ecam,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hoscamasareas in _context.Hoscamasareas
                                      join hoshabitaciones in _context.Hoshabitaciones on hoscamasareas.hos_nrohab_habi equals hoshabitaciones.hos_nrohab_habi into tmhoshabitaciones
                                      join hostipocamas in _context.Hostipocamas on hoscamasareas.hos_tipcam_tcam equals hostipocamas.hos_tipcam_tcam into tmhostipocamas
                                      join fcmmanservicips in _context.Fcmmanservicips on hoscamasareas.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join hosseccionareas in _context.Hosseccionareas on hoscamasareas.hos_codsec_hsec equals hosseccionareas.hos_codsec_hsec into tmhosseccionareas
                                      join hosestadocama in _context.Hosestadocama on hoscamasareas.hos_estcam_ecam equals hosestadocama.hos_estcam_ecam into tmhosestadocama
                                      from habi in tmhoshabitaciones.DefaultIfEmpty()
                                      from tcam in tmhostipocamas.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from hsec in tmhosseccionareas.DefaultIfEmpty()
                                      from ecam in tmhosestadocama.DefaultIfEmpty()
                                      where hoscamasareas.hos_codcam_caho.Contains(tcrBuscar) || 
                                            hoscamasareas.hos_descam_caho.Contains(tcrBuscar) ||
                                            tcam.hos_destip_tcam.Contains(tcrBuscar) ||
                                            hsec.hos_dessec_hsec.Contains(tcrBuscar) ||
                                            ecam.hos_desest_ecam.Contains(tcrBuscar) 
                                      select new ModeloHoscamasareas
                                      {
                                          Hos_codcam_caho = hoscamasareas.hos_codcam_caho,
                                          Hos_nrohab_habi = hoscamasareas.hos_nrohab_habi,
                                          Hos_descam_caho = hoscamasareas.hos_descam_caho,
                                          Hos_tipcam_tcam = hoscamasareas.hos_tipcam_tcam,
                                          Hos_camaux_caho = hoscamasareas.hos_camaux_caho,
                                          Fcm_idesec_sips = hoscamasareas.fcm_idesec_sips,
                                          Fcm_coddig_mant = hoscamasareas.fcm_coddig_mant,
                                          Hos_codsec_hsec = hoscamasareas.hos_codsec_hsec,
                                          Hos_estcam_ecam = hoscamasareas.hos_estcam_ecam,
                                          Sis_estreg_esrg = hoscamasareas.sis_estreg_esrg,
                                          Hos_deshab_habi = habi.hos_deshab_habi,
                                          Hos_destip_tcam = tcam.hos_destip_tcam,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Hos_dessec_hsec = hsec.hos_dessec_hsec,
                                          Hos_desest_ecam = ecam.hos_desest_ecam,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
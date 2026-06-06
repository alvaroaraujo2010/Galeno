//- MARMOTA-GENCODE: VERSION 2.0 - 21/02/2013 05:13:43 PM
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Sistema.Utilidades;
using Sistema.Modelo;
using Datos.Modelos;

namespace Hospitalizacion.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hoshabitaciones
    /// </summary>
    public class ModeloBcHoshabitaciones : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private string _hos_nrohab_habi;
        private string _hos_deshab_habi;
        private string _hos_codsec_hsec;
        private string _hos_tiphab_habi;
        private int _hos_concam_habi;
        private string _sis_estreg_esrg;
        private string _hos_dessec_hsec;
        private string _sis_desest_esrg;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Hos_nrohab_habi: Codigo habitacion
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Codigo habitacion</para>
        /// <para>NOMBRE: hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo de habitacion generado por el sistema
        /// </para>
        /// </summary>
        public string Hos_nrohab_habi
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
        #region Hos_deshab_habi: Numero/nombre habitacion
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public string Hos_deshab_habi
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
        #region Hos_codsec_hsec: Codigo sección
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Codigo sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion de Hopitalización y Urgencias con observación
        /// a la cual pertenece la habitacion  Ejm: S001= Hospitalizacion
        /// Mujeres, S002 =Hospitalizacion Niños y otras
        /// </para>
        /// </summary>
        public string Hos_codsec_hsec
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
        #region Hos_tiphab_habi: Unipersonal SI/NO
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Unipersonal SI/NO</para>
        /// <para>NOMBRE: hos_tiphab_habi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo habitacion (para saber si es unipersonal o para varias
        /// personas) asi: 1= Unipersonal 2=Varias personas
        /// </para>
        /// </summary>
        public string Hos_tiphab_habi
        {
            get { return _hos_tiphab_habi; }
            set
            {
                if (_hos_tiphab_habi == value) return;
                _hos_tiphab_habi = value;
                OnPropertyChanged("Hos_tiphab_habi");
            }
        }
        #endregion
        #region Hos_concam_habi: Contador Camas
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Contador Camas</para>
        /// <para>NOMBRE: hos_concam_habi (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de las camas asignadas
        /// en la habitacion
        /// </para>
        /// </summary>
        public int Hos_concam_habi
        {
            get { return _hos_concam_habi; }
            set
            {
                if (_hos_concam_habi == value) return;
                _hos_concam_habi = value;
                OnPropertyChanged("Hos_concam_habi");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Estado habitacion
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado habitacion</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo estado habItacion  1= Activa 2=Inactiva
        /// </para>
        /// </summary>
        public string Sis_estreg_esrg
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
        #region Hos_dessec_hsec: Nombre sección
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Nombre sección</para>
        /// <para>NOMBRE: hos_dessec_hsec (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion de la seccion de hospitalización o Urgencias con
        /// observación
        /// </para>
        /// </summary>
        public string Hos_dessec_hsec
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
        #region Sis_desest_esrg: Decripción estado registro
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloBcHoshabitaciones tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFhoshabitaciones
                {
                    #region cargar Registro
                    hos_nrohab_habi = tobjModelo.Hos_nrohab_habi,
                    hos_deshab_habi = tobjModelo.Hos_deshab_habi,
                    hos_codsec_hsec = tobjModelo.Hos_codsec_hsec,
                    hos_tiphab_habi = tobjModelo.Hos_tiphab_habi,
                    hos_concam_habi = tobjModelo.Hos_concam_habi,
                    sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.hos_nrohab_habi;
                _context.AddToHoshabitaciones(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloBcHoshabitaciones tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tobjModelo.Hos_nrohab_habi);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hos_nrohab_habi = tobjModelo.Hos_nrohab_habi;
                    lobjRegistro.hos_deshab_habi = tobjModelo.Hos_deshab_habi;
                    lobjRegistro.hos_codsec_hsec = tobjModelo.Hos_codsec_hsec;
                    lobjRegistro.hos_tiphab_habi = tobjModelo.Hos_tiphab_habi;
                    lobjRegistro.hos_concam_habi = tobjModelo.Hos_concam_habi;
                    lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HOSHABITACIONES: Habitaciones
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TITULO: Habitaciones</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista habitaciones con sus numeros, que pertenecen a una seccion
        /// (una secccion puede tener varias habitaciones) ejm: HA001=
        /// 201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
        /// HA004 = 103 HOSPITALIZACION NIÑOS
        /// </para>
        /// </summary>
        public static bool flgBuscarHoshabitaciones(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hoshabitaciones.FirstOrDefault(p => p.hos_nrohab_habi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloBcHoshabitaciones> flsListaHoshabitaciones(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    return _context.Hoshabitaciones.Select(p => new ModeloBcHoshabitaciones
                    {
                        Hos_nrohab_habi = p.hos_nrohab_habi,
                        Hos_deshab_habi = p.hos_deshab_habi,
                        Hos_codsec_hsec = p.hos_codsec_hsec,
                        Hos_tiphab_habi = p.hos_tiphab_habi,
                        Hos_concam_habi = (int)p.hos_concam_habi,
                        Sis_estreg_esrg = p.sis_estreg_esrg,
                        Hos_dessec_hsec = _context.Hosseccionareas.FirstOrDefault(rxp => rxp.hos_codsec_hsec == p.hos_codsec_hsec).hos_dessec_hsec,
                        Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == p.sis_estreg_esrg).sis_desest_esrg,
                    }).ToList();
                }
                else
                {
                    var lobConsulta = from tmp in _context.Hoshabitaciones
                                      where tmp.hos_nrohab_habi.Contains(tcrBuscar) || tmp.hos_deshab_habi.Contains(tcrBuscar)
                                      select new ModeloBcHoshabitaciones
                                      {
                                          Hos_nrohab_habi = tmp.hos_nrohab_habi,
                                          Hos_deshab_habi = tmp.hos_deshab_habi,
                                          Hos_codsec_hsec = tmp.hos_codsec_hsec,
                                          Hos_tiphab_habi = tmp.hos_tiphab_habi,
                                          Hos_concam_habi = (int)tmp.hos_concam_habi,
                                          Sis_estreg_esrg = tmp.sis_estreg_esrg,
                                          Hos_dessec_hsec = _context.Hosseccionareas.FirstOrDefault(rxp => rxp.hos_codsec_hsec == tmp.hos_codsec_hsec).hos_dessec_hsec,
                                          Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == tmp.sis_estreg_esrg).sis_desest_esrg,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hoscamasareas
    /// </summary>
    public class ModeloBcHoscamasareas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private string _hos_codcam_caho;
        private string _hos_nrohab_habi;
        private string _hos_descam_caho;
        private string _hos_tipcam_tcam;
        private string _hos_camaux_caho;
        private string _fcm_idesec_sips;
        private string _hos_codsec_hsec;
        private string _hos_estcam_ecam;
        private string _sis_estreg_esrg;
        private string _hos_deshab_habi;
        private string _hos_destip_tcam;
        private string _fcm_desser_sips;
        private string _hos_dessec_hsec;
        private string _hos_desest_ecam;
        private string _sis_desest_esrg;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Hos_codcam_caho: Codigo cama
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
        public string Hos_codcam_caho
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
        #region Hos_nrohab_habi: Numero/nombre habitacion
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo o numero de habitacion en area de servicios donde se
        /// encuentra la cama, ejemplo: N201= Segundo piso Neonatos habitacion
        /// 201
        /// </para>
        /// </summary>
        public string Hos_nrohab_habi
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
        public string Hos_descam_caho
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
        #region Hos_tipcam_tcam: Codigo Tipo cama
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Codigo Tipo cama</para>
        /// <para>NOMBRE: hos_tipcam_tcam (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo cama : 01 =Reclinable electronica   2=Reclinable
        /// Mecanica, otras
        /// </para>
        /// </summary>
        public string Hos_tipcam_tcam
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
        #region Hos_camaux_caho: Cama adecuada SI/NO
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama adecuada SI/NO</para>
        /// <para>NOMBRE: hos_camaux_caho (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cama adecuada o auxiliar imporvisada, cuando   no hay camas
        /// disponibles (en casos de urgencia), se utilizan camas no adecuadas:
        /// 1=Cama Adecuada 2=Cama Auxiliar
        /// </para>
        /// </summary>
        public string Hos_camaux_caho
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
        public string Fcm_idesec_sips
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
        #region Hos_codsec_hsec: Codigo sección
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Codigo sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion para las subdiviciones de Hopitalización y Urgencias
        /// con observación EJM:S001= Hospitalizacion Mujeres, S002 =Hospitalizacion
        /// Niños y otras
        /// </para>
        /// </summary>
        public string Hos_codsec_hsec
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
        #region Hos_estcam_ecam: Codigo estado cama
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Codigo estado cama</para>
        /// <para>NOMBRE: hos_estcam_ecam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion
        /// 5-Inactiva
        /// </para>
        /// </summary>
        public string Hos_estcam_ecam
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
        #region Sis_estreg_esrg: Estado habitacion
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado habitacion</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama según estado habItacion  1= Activa 2=Inactiva
        /// </para>
        /// </summary>
        public string Sis_estreg_esrg
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
        #region Hos_deshab_habi: Numero/nombre habitacion
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public string Hos_deshab_habi
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
        public string Hos_destip_tcam
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
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string Fcm_desser_sips
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
        public string Hos_dessec_hsec
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
        public string Hos_desest_ecam
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
        #region Sis_desest_esrg: Decripción estado registro
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public string Sis_estado_imaen
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
        public static bool flgAddRegistro(ModeloBcHoscamasareas tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFhoscamasareas();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tobTempReg.Hos_codcam_caho);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.hos_codcam_caho = tobTempReg.Hos_codcam_caho;
                            lobEFReg.hos_nrohab_habi = tobTempReg.Hos_nrohab_habi;
                            lobEFReg.hos_descam_caho = tobTempReg.Hos_descam_caho;
                            lobEFReg.hos_tipcam_tcam = tobTempReg.Hos_tipcam_tcam;
                            lobEFReg.hos_camaux_caho = tobTempReg.Hos_camaux_caho;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.hos_codsec_hsec = tobTempReg.Hos_codsec_hsec;
                            lobEFReg.hos_estcam_ecam = tobTempReg.Hos_estcam_ecam;
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
                                lobEFReg.hos_codcam_caho = tcrCodigoR1 + lobEFReg.hos_codcam_caho; // concatenar
                                _context.AddToHoscamasareas(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Hoscamasareas.FirstOrDefault(p => p.hos_codcam_caho == tobTempReg.Hos_codcam_caho);
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
        #region Buscar HOSCAMASAREAS: Camas por area prestacion servicios
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
        public static List<ModeloBcHoscamasareas> flsListaHoscamasareas(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Hoscamasareas
                                  where tmp.hos_nrohab_habi == tcrBuscar
                                  select new ModeloBcHoscamasareas
                                  {
                                      Hos_codcam_caho = tmp.hos_codcam_caho,
                                      Hos_nrohab_habi = tmp.hos_nrohab_habi,
                                      Hos_descam_caho = tmp.hos_descam_caho,
                                      Hos_tipcam_tcam = tmp.hos_tipcam_tcam,
                                      Hos_camaux_caho = tmp.hos_camaux_caho,
                                      Fcm_idesec_sips = tmp.fcm_idesec_sips,
                                      Hos_codsec_hsec = tmp.hos_codsec_hsec,
                                      Hos_estcam_ecam = tmp.hos_estcam_ecam,
                                      Hos_deshab_habi = _context.Hoshabitaciones.FirstOrDefault(rxp => rxp.hos_nrohab_habi == tmp.hos_nrohab_habi).hos_deshab_habi,
                                      Hos_destip_tcam = _context.Hostipocamas.FirstOrDefault(rxp => rxp.hos_tipcam_tcam == tmp.hos_tipcam_tcam).hos_destip_tcam,
                                      Fcm_desser_sips = _context.Fcmmanservicips.FirstOrDefault(rxp => rxp.fcm_idesec_sips == tmp.fcm_idesec_sips).fcm_desser_sips,
                                      Hos_dessec_hsec = _context.Hosseccionareas.FirstOrDefault(rxp => rxp.hos_codsec_hsec == tmp.hos_codsec_hsec).hos_dessec_hsec,
                                      Hos_desest_ecam = _context.Hosestadocama.FirstOrDefault(rxp => rxp.hos_estcam_ecam == tmp.hos_estcam_ecam).hos_desest_ecam,
                                      //Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == tmp.sis_estreg_esrg).sis_desest_esrg,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
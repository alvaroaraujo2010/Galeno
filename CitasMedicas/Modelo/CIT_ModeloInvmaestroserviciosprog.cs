//- MARMOTA-GENCODE: VERSION 2.0 - 31/05/2013 05:27:03 AM
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

namespace CitasMedicas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citservicioprog
    /// </summary>
    public class ModeloInvmaestroserviciosprog : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _cit_codspr_spro;
        private String _cit_desspr_spro;
        private String _cit_indspr_spro;
        private int _cit_nropas_spro;
        private String _cit_indmed_spro;
        private int _cit_hordur_spro;
        private String _sia_codesp_esme;
        private String _fcm_idesec_sips;
        private String _adm_codtat_tatn;
        private String _fcm_codcpr_cpro;
        private int _cit_contad_spro;
        private String _sis_estreg_esrg;
        private String _sia_desesp_esme;
        private String _fcm_desser_sips;
        private String _adm_destat_tatn;
        private String _fcm_descpr_cpro;
        private String _sis_desest_esrg;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Cit_codspr_spro: Código servicio
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código servicio</para>
        /// <para>NOMBRE: cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros (Generado por el sistema) ejm =S001 = Consulta
        /// externa S003=Consulta Control pyp Adulto joven
        /// </para>
        /// </summary>
        public String Cit_codspr_spro
        {
            get { return _cit_codspr_spro; }
            set
            {
                if (_cit_codspr_spro == value) return;
                _cit_codspr_spro = value;
                OnPropertyChanged("Cit_codspr_spro");
            }
        }
        #endregion
        #region Cit_desspr_spro: Nombre servicio
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public String Cit_desspr_spro
        {
            get { return _cit_desspr_spro; }
            set
            {
                if (_cit_desspr_spro == value) return;
                _cit_desspr_spro = value;
                OnPropertyChanged("Cit_desspr_spro");
            }
        }
        #endregion
        #region Cit_indspr_spro: Tipo Pacientes
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Tipo Pacientes</para>
        /// <para>NOMBRE: cit_indspr_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Servicio para programación individual o grupal (aplica para
        /// un  o un grupo de pacientes) : 1= Individual 2=Grupal
        /// </para>
        /// </summary>
        public String Cit_indspr_spro
        {
            get { return _cit_indspr_spro; }
            set
            {
                if (_cit_indspr_spro == value) return;
                _cit_indspr_spro = value;
                OnPropertyChanged("Cit_indspr_spro");
            }
        }
        #endregion
        #region Cit_nropas_spro: Total pacientes
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Total pacientes</para>
        /// <para>NOMBRE: cit_nropas_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero total de pacientes que cubre el servicio en la programación
        /// (uno es el mínimo)
        /// </para>
        /// </summary>
        public int Cit_nropas_spro
        {
            get { return _cit_nropas_spro; }
            set
            {
                if (_cit_nropas_spro == value) return;
                _cit_nropas_spro = value;
                OnPropertyChanged("Cit_nropas_spro");
            }
        }
        #endregion
        #region Cit_indmed_spro: Indicación medica
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Indicación medica</para>
        /// <para>NOMBRE: cit_indmed_spro (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Indicaciones medicas para el paciente (se imprimen en el reporte
        /// de asignación cita que se entrega al paciente)
        /// </para>
        /// </summary>
        public String Cit_indmed_spro
        {
            get { return _cit_indmed_spro; }
            set
            {
                if (_cit_indmed_spro == value) return;
                _cit_indmed_spro = value;
                OnPropertyChanged("Cit_indmed_spro");
            }
        }
        #endregion
        #region Cit_hordur_spro: Minutos Duración cita
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Minutos Duración cita</para>
        /// <para>NOMBRE: cit_hordur_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero de  minutos que demora la prestación del servicio por
        /// cada paciente ejm 00:30 es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int Cit_hordur_spro
        {
            get { return _cit_hordur_spro; }
            set
            {
                if (_cit_hordur_spro == value) return;
                _cit_hordur_spro = value;
                OnPropertyChanged("Cit_hordur_spro");
            }
        }
        #endregion
        #region Sia_codesp_esme: Código especialidad
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código de la especialidad medica que aplica al  servicio
        /// </para>
        /// </summary>
        public String Sia_codesp_esme
        {
            get { return _sia_codesp_esme; }
            set
            {
                if (_sia_codesp_esme == value) return;
                _sia_codesp_esme = value;
                OnPropertyChanged("Sia_codesp_esme");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código único secuencial del servicio IPS con el que esta relacionado
        /// (no es obligatorio)
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
        #region Adm_codtat_tatn: Ambito Atención
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Ambito Atención</para>
        /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito dende se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalizacion 3=Urgencia
        /// </para>
        /// </summary>
        public String Adm_codtat_tatn
        {
            get { return _adm_codtat_tatn; }
            set
            {
                if (_adm_codtat_tatn == value) return;
                _adm_codtat_tatn = value;
                OnPropertyChanged("Adm_codtat_tatn");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código del centro de producción dentro de las diferentes áreas
        /// de servicios (para registro de facturación)
        /// </para>
        /// </summary>
        public String Fcm_codcpr_cpro
        {
            get { return _fcm_codcpr_cpro; }
            set
            {
                if (_fcm_codcpr_cpro == value) return;
                _fcm_codcpr_cpro = value;
                OnPropertyChanged("Fcm_codcpr_cpro");
            }
        }
        #endregion
        #region Cit_contad_spro: Contador protocolo
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Contador protocolo</para>
        /// <para>NOMBRE: cit_contad_spro (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Contador para generar códigos únicos  registros de servicios
        /// incluidos en el protocolo medico
        /// </para>
        /// </summary>
        public int Cit_contad_spro
        {
            get { return _cit_contad_spro; }
            set
            {
                if (_cit_contad_spro == value) return;
                _cit_contad_spro = value;
                OnPropertyChanged("Cit_contad_spro");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Estado programa
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado programa</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del programa: 1 =Activo 2=Inactivo
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
        #region Sia_desesp_esme: Nombre especialidad
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public String Sia_desesp_esme
        {
            get { return _sia_desesp_esme; }
            set
            {
                if (_sia_desesp_esme == value) return;
                _sia_desesp_esme = value;
                OnPropertyChanged("Sia_desesp_esme");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Adm_destat_tatn: Descripción tipo atención
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public String Adm_destat_tatn
        {
            get { return _adm_destat_tatn; }
            set
            {
                if (_adm_destat_tatn == value) return;
                _adm_destat_tatn = value;
                OnPropertyChanged("Adm_destat_tatn");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public String Fcm_descpr_cpro
        {
            get { return _fcm_descpr_cpro; }
            set
            {
                if (_fcm_descpr_cpro == value) return;
                _fcm_descpr_cpro = value;
                OnPropertyChanged("Fcm_descpr_cpro");
            }
        }
        #endregion
        #region Sis_desest_esrg: Decripción estado registro
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
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
        public static string flgAddRegistro(ModeloInvmaestroserviciosprog tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CIT-MAE-SERV-PROG", "CIT", "Maestro de Servicios prog");
            if (!flgBuscarCitservicioprog(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFcitservicioprog
                    {
                        #region cargar Registro
                        cit_codspr_spro = tobjModelo.Cit_codspr_spro,
                        cit_desspr_spro = tobjModelo.Cit_desspr_spro,
                        cit_indspr_spro = tobjModelo.Cit_indspr_spro,
                        cit_nropas_spro = tobjModelo.Cit_nropas_spro,
                        cit_indmed_spro = tobjModelo.Cit_indmed_spro,
                        cit_hordur_spro = tobjModelo.Cit_hordur_spro,
                        sia_codesp_esme = tobjModelo.Sia_codesp_esme,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        cit_contad_spro = tobjModelo.Cit_contad_spro,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.cit_codspr_spro = lcrCodigoGen;
                    _context.AddToCitservicioprog(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CIT-MAE-SERV-PROG': Maestro de Servicios prog en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloInvmaestroserviciosprog tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tobjModelo.Cit_codspr_spro);
                if (lobjRegistro != null)
                {
                    lobjRegistro.cit_codspr_spro = tobjModelo.Cit_codspr_spro;
                    lobjRegistro.cit_desspr_spro = tobjModelo.Cit_desspr_spro;
                    lobjRegistro.cit_indspr_spro = tobjModelo.Cit_indspr_spro;
                    lobjRegistro.cit_nropas_spro = tobjModelo.Cit_nropas_spro;
                    lobjRegistro.cit_indmed_spro = tobjModelo.Cit_indmed_spro;
                    lobjRegistro.cit_hordur_spro = tobjModelo.Cit_hordur_spro;
                    lobjRegistro.sia_codesp_esme = tobjModelo.Sia_codesp_esme;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.cit_contad_spro = tobjModelo.Cit_contad_spro;
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
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar CITSERVICIOPROG: Logica
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TITULO: Servicios para programación o citas medicas</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios que se manejan a través de programación
        /// o citas medicas en la IPS tales como: Cirugías, consulta externa,
        /// PyP, Laboratorios, Citas odontológicas y otros ejm: S001 =
        /// Consulta externa S003=Consulta Control pyp Adulto joven
        /// </para>
        /// </summary>
        public static bool flgBuscarCitservicioprog(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvmaestroserviciosprog> flsListaCitservicioprog(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    return _context.Citservicioprog.Select(p => new ModeloInvmaestroserviciosprog
                    {
                        Cit_codspr_spro = p.cit_codspr_spro,
                        Cit_desspr_spro = p.cit_desspr_spro,
                        Cit_indspr_spro = p.cit_indspr_spro,
                        Cit_nropas_spro = (int)p.cit_nropas_spro,
                        Cit_indmed_spro = p.cit_indmed_spro,
                        Cit_hordur_spro = (int)p.cit_hordur_spro,
                        Sia_codesp_esme = p.sia_codesp_esme,
                        Fcm_idesec_sips = p.fcm_idesec_sips,
                        Adm_codtat_tatn = p.adm_codtat_tatn,
                        Fcm_codcpr_cpro = p.fcm_codcpr_cpro,
                        Cit_contad_spro = (int)p.cit_contad_spro,
                        Sis_estreg_esrg = p.sis_estreg_esrg,
                        Sia_desesp_esme = _context.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == p.sia_codesp_esme).sia_desesp_esme,
                        Fcm_desser_sips = _context.Fcmmanservicips.FirstOrDefault(rxp => rxp.fcm_idesec_sips == p.fcm_idesec_sips).fcm_desser_sips,
                        Adm_destat_tatn = _context.Admtipoatencion.FirstOrDefault(rxp => rxp.adm_codtat_tatn == p.adm_codtat_tatn).adm_destat_tatn,
                        Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == p.fcm_codcpr_cpro).fcm_descpr_cpro,
                        Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == p.sis_estreg_esrg).sis_desest_esrg,
                    }).ToList();
                }
                else
                {
                    var lobConsulta = from tmp in _context.Citservicioprog
                                      where tmp.cit_codspr_spro.Contains(tcrBuscar) || tmp.cit_desspr_spro.Contains(tcrBuscar)
                                      select new ModeloInvmaestroserviciosprog
                                      {
                                          Cit_codspr_spro = tmp.cit_codspr_spro,
                                          Cit_desspr_spro = tmp.cit_desspr_spro,
                                          Cit_indspr_spro = tmp.cit_indspr_spro,
                                          Cit_nropas_spro = (int)tmp.cit_nropas_spro,
                                          Cit_indmed_spro = tmp.cit_indmed_spro,
                                          Cit_hordur_spro = (int)tmp.cit_hordur_spro,
                                          Sia_codesp_esme = tmp.sia_codesp_esme,
                                          Fcm_idesec_sips = tmp.fcm_idesec_sips,
                                          Adm_codtat_tatn = tmp.adm_codtat_tatn,
                                          Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro,
                                          Cit_contad_spro = (int)tmp.cit_contad_spro,
                                          Sis_estreg_esrg = tmp.sis_estreg_esrg,
                                          Sia_desesp_esme = _context.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                          Fcm_desser_sips = _context.Fcmmanservicips.FirstOrDefault(rxp => rxp.fcm_idesec_sips == tmp.fcm_idesec_sips).fcm_desser_sips,
                                          Adm_destat_tatn = _context.Admtipoatencion.FirstOrDefault(rxp => rxp.adm_codtat_tatn == tmp.adm_codtat_tatn).adm_destat_tatn,
                                          Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == tmp.fcm_codcpr_cpro).fcm_descpr_cpro,
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
    /// Descripcion para la Vista de  la tabla: citservprotocol
    /// </summary>
    public class ModeloInvmaestroprotocolo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _cit_codspt_sprt;
        private String _cit_codspr_spro;
        private String _fcm_idesec_sips;
        private String _fcm_tipact_sips;
        private int _fcm_totuni_dfac;
        private String _cit_incrme_sprt;
        private String _cit_incfac_sprt;
        private String _cit_incfrm_sprt;
        private String _sis_estreg_esrg;
        private String _cit_desspr_spro;
        private String _fcm_desser_sips;
        private String _sis_desest_esrg;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Cit_codspt_sprt: Código registro
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: cit_codspt_sprt (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro (generado por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codspt_sprt
        {
            get { return _cit_codspt_sprt; }
            set
            {
                if (_cit_codspt_sprt == value) return;
                _cit_codspt_sprt = value;
                OnPropertyChanged("Cit_codspt_sprt");
            }
        }
        #endregion
        #region Cit_codspr_spro: Código programa
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public String Cit_codspr_spro
        {
            get { return _cit_codspr_spro; }
            set
            {
                if (_cit_codspr_spro == value) return;
                _cit_codspr_spro = value;
                OnPropertyChanged("Cit_codspr_spro");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código único secuencial del servicio IPS con el que esta relacionado
        /// (es obligatorio)
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
        #region Fcm_tipact_sips: Tipo Asistencial o PyP
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Asistencial o PyP</para>
        /// <para>NOMBRE: fcm_tipact_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promoción y Prevención
        /// </para>
        /// </summary>
        public String Fcm_tipact_sips
        {
            get { return _fcm_tipact_sips; }
            set
            {
                if (_fcm_tipact_sips == value) return;
                _fcm_tipact_sips = value;
                OnPropertyChanged("Fcm_tipact_sips");
            }
        }
        #endregion
        #region Fcm_totuni_dfac: Total unidades
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Total de unidades para facturar o receta medica del servicio
        /// o suministro
        /// </para>
        /// </summary>
        public int Fcm_totuni_dfac
        {
            get { return _fcm_totuni_dfac; }
            set
            {
                if (_fcm_totuni_dfac == value) return;
                _fcm_totuni_dfac = value;
                OnPropertyChanged("Fcm_totuni_dfac");
            }
        }
        #endregion
        #region Cit_incrme_sprt: Incluir en receta medica
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en receta medica</para>
        /// <para>NOMBRE: cit_incrme_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Incluir en receta medica: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public String Cit_incrme_sprt
        {
            get { return _cit_incrme_sprt; }
            set
            {
                if (_cit_incrme_sprt == value) return;
                _cit_incrme_sprt = value;
                OnPropertyChanged("Cit_incrme_sprt");
            }
        }
        #endregion
        #region Cit_incfac_sprt: Incluir en facturación
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en facturación</para>
        /// <para>NOMBRE: cit_incfac_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para facturación: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public String Cit_incfac_sprt
        {
            get { return _cit_incfac_sprt; }
            set
            {
                if (_cit_incfac_sprt == value) return;
                _cit_incfac_sprt = value;
                OnPropertyChanged("Cit_incfac_sprt");
            }
        }
        #endregion
        #region Cit_incfrm_sprt: Entrega en farmacia
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Entrega en farmacia</para>
        /// <para>NOMBRE: cit_incfrm_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para entrega en farmacia: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public String Cit_incfrm_sprt
        {
            get { return _cit_incfrm_sprt; }
            set
            {
                if (_cit_incfrm_sprt == value) return;
                _cit_incfrm_sprt = value;
                OnPropertyChanged("Cit_incfrm_sprt");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Estado servicio
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado servicio</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
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
        #region Cit_desspr_spro: Nombre servicio
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public String Cit_desspr_spro
        {
            get { return _cit_desspr_spro; }
            set
            {
                if (_cit_desspr_spro == value) return;
                _cit_desspr_spro = value;
                OnPropertyChanged("Cit_desspr_spro");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Sis_desest_esrg: Decripción estado registro
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
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
        public static bool flgAddRegistro(ModeloInvmaestroprotocolo tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFcitservprotocol();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Citservprotocol.FirstOrDefault(p => p.cit_codspt_sprt == tobTempReg.Cit_codspt_sprt);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.cit_codspt_sprt = tobTempReg.Cit_codspt_sprt;
                            lobEFReg.cit_codspr_spro = tobTempReg.Cit_codspr_spro;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_tipact_sips = tobTempReg.Fcm_tipact_sips;
                            lobEFReg.fcm_totuni_dfac = tobTempReg.Fcm_totuni_dfac;
                            lobEFReg.cit_incrme_sprt = tobTempReg.Cit_incrme_sprt;
                            lobEFReg.cit_incfac_sprt = tobTempReg.Cit_incfac_sprt;
                            lobEFReg.cit_incfrm_sprt = tobTempReg.Cit_incfrm_sprt;
                            lobEFReg.sis_estreg_esrg = tobTempReg.Sis_estreg_esrg;
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
                                lobEFReg.cit_codspt_sprt = tcrCodigoR1 + lobEFReg.cit_codspt_sprt; // concatenar
                                _context.AddToCitservprotocol(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Citservprotocol.FirstOrDefault(p => p.cit_codspt_sprt == tobTempReg.Cit_codspt_sprt);
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
        #region Buscar CITSERVPROTOCOL: Logica
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TITULO: Servicios o suministros  de protocolo medico</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios o suministros que deben ser facturados o
        /// recetados por el profesional según protocolo medico en atención
        /// de Citas medicas y controles
        /// </para>
        /// </summary>
        public static bool flgBuscarCitservprotocol(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservprotocol.FirstOrDefault(p => p.cit_codspt_sprt == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvmaestroprotocolo> flsListaCitservprotocol(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Citservprotocol
                                  where tmp.cit_codspr_spro == tcrBuscar
                                  select new ModeloInvmaestroprotocolo
                                  {
                                      Cit_codspt_sprt = tmp.cit_codspt_sprt,
                                      Cit_codspr_spro = tmp.cit_codspr_spro,
                                      Fcm_idesec_sips = tmp.fcm_idesec_sips,
                                      Fcm_tipact_sips = tmp.fcm_tipact_sips,
                                      Fcm_totuni_dfac = (int)tmp.fcm_totuni_dfac,
                                      Cit_incrme_sprt = tmp.cit_incrme_sprt,
                                      Cit_incfac_sprt = tmp.cit_incfac_sprt,
                                      Cit_incfrm_sprt = tmp.cit_incfrm_sprt,
                                      Sis_estreg_esrg = tmp.sis_estreg_esrg,
                                      Cit_desspr_spro = _context.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                      Fcm_desser_sips = _context.Fcmmanservicips.FirstOrDefault(rxp => rxp.fcm_idesec_sips == tmp.fcm_idesec_sips).fcm_desser_sips,
                                      Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == tmp.sis_estreg_esrg).sis_desest_esrg,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 13/06/2013 06:11:43 AM
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
    public class ModeloCitmaestroserviciosprog : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cit_codspr_spro: Código servicio
        private String _cit_codspr_spro;
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
        private String _cit_desspr_spro;
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
        private String _cit_indspr_spro;
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
        private int _cit_nropas_spro;
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
        private String _cit_indmed_spro;
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
        private int _cit_hordur_spro;
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
        private String _sia_codesp_esme;
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
        private String _fcm_idesec_sips;
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
        private String _adm_codtat_tatn;
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
        private String _fcm_codcpr_cpro;
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
        #region Fcm_tiprfa_mfac: Tipo registro factuación
        private String _fcm_tiprfa_mfac;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro factuación</para>
        /// <para>NOMBRE: fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro factura generada: 1= Registro ordenes de servicios
        /// (pre factura) 2= Numero de Factura Valida Dian
        /// </para>
        /// </summary>
        public String Fcm_tiprfa_mfac
        {
            get { return _fcm_tiprfa_mfac; }
            set
            {
                if (_fcm_tiprfa_mfac == value) return;
                _fcm_tiprfa_mfac = value;
                OnPropertyChanged("Fcm_tiprfa_mfac");
            }
        }
        #endregion
        #region Cit_contad_spro: Contador protocolo
        private int _cit_contad_spro;
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
        private String _sis_estreg_esrg;
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
        private String _sia_desesp_esme;
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
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
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
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:80)</para>
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
        private String _sis_desest_esrg;
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
        public static string flgAddRegistro(ModeloCitmaestroserviciosprog tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CIT-MAE-SERV-PROG", "CIT", "Maestro Servicios progamados");
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
                        fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac,
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
                                "'CIT-MAE-SERV-PROG': Maestro Servicios progamados en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloCitmaestroserviciosprog tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tobjModelo.Cit_codspr_spro);
                if (lobjRegistro != null)
                {
                    lobjRegistro.cit_codspr_spro = tobjModelo.Cit_codspr_spro;
                    lobjRegistro.cit_desspr_spro = tobjModelo.Cit_desspr_spro;
                    lobjRegistro.cit_indspr_spro = tobjModelo.Cit_indspr_spro;
                    lobjRegistro.cit_nropas_spro = (int)tobjModelo.Cit_nropas_spro;
                    lobjRegistro.cit_indmed_spro = tobjModelo.Cit_indmed_spro;
                    lobjRegistro.cit_hordur_spro = (int)tobjModelo.Cit_hordur_spro;
                    lobjRegistro.sia_codesp_esme = tobjModelo.Sia_codesp_esme;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac;
                    lobjRegistro.cit_contad_spro = (int)tobjModelo.Cit_contad_spro;
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
        public static List<ModeloCitmaestroserviciosprog> flsListaCitservicioprog(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from citservicioprog in _context.Citservicioprog
                                      join siaespecialimed in _context.Siaespecialimed on citservicioprog.sia_codesp_esme equals siaespecialimed.sia_codesp_esme into tmsiaespecialimed
                                      join fcmmanservicips in _context.Fcmmanservicips on citservicioprog.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join admtipoatencion in _context.Admtipoatencion on citservicioprog.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join fcmcenproduccio in _context.Fcmcenproduccio on citservicioprog.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join sisestadoregist in _context.Sisestadoregist on citservicioprog.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from esme in tmsiaespecialimed.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      select new ModeloCitmaestroserviciosprog
                                      {
                                          Cit_codspr_spro = citservicioprog.cit_codspr_spro,
                                          Cit_desspr_spro = citservicioprog.cit_desspr_spro,
                                          Cit_indspr_spro = citservicioprog.cit_indspr_spro,
                                          Cit_nropas_spro = (int)citservicioprog.cit_nropas_spro,
                                          Cit_indmed_spro = citservicioprog.cit_indmed_spro,
                                          Cit_hordur_spro = (int)citservicioprog.cit_hordur_spro,
                                          Sia_codesp_esme = citservicioprog.sia_codesp_esme,
                                          Fcm_idesec_sips = citservicioprog.fcm_idesec_sips,
                                          Adm_codtat_tatn = citservicioprog.adm_codtat_tatn,
                                          Fcm_codcpr_cpro = citservicioprog.fcm_codcpr_cpro,
                                          Fcm_tiprfa_mfac = citservicioprog.fcm_tiprfa_mfac,
                                          Cit_contad_spro = (int)citservicioprog.cit_contad_spro,
                                          Sis_estreg_esrg = citservicioprog.sis_estreg_esrg,
                                          Sia_desesp_esme = esme.sia_desesp_esme,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from citservicioprog in _context.Citservicioprog
                                      join siaespecialimed in _context.Siaespecialimed on citservicioprog.sia_codesp_esme equals siaespecialimed.sia_codesp_esme into tmsiaespecialimed
                                      join fcmmanservicips in _context.Fcmmanservicips on citservicioprog.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join admtipoatencion in _context.Admtipoatencion on citservicioprog.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join fcmcenproduccio in _context.Fcmcenproduccio on citservicioprog.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join sisestadoregist in _context.Sisestadoregist on citservicioprog.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                      from esme in tmsiaespecialimed.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from esrg in tmsisestadoregist.DefaultIfEmpty()
                                      where citservicioprog.cit_codspr_spro.Contains(tcrBuscar) || citservicioprog.cit_desspr_spro.Contains(tcrBuscar)
                                      select new ModeloCitmaestroserviciosprog
                                      {
                                          Cit_codspr_spro = citservicioprog.cit_codspr_spro,
                                          Cit_desspr_spro = citservicioprog.cit_desspr_spro,
                                          Cit_indspr_spro = citservicioprog.cit_indspr_spro,
                                          Cit_nropas_spro = (int)citservicioprog.cit_nropas_spro,
                                          Cit_indmed_spro = citservicioprog.cit_indmed_spro,
                                          Cit_hordur_spro = (int)citservicioprog.cit_hordur_spro,
                                          Sia_codesp_esme = citservicioprog.sia_codesp_esme,
                                          Fcm_idesec_sips = citservicioprog.fcm_idesec_sips,
                                          Adm_codtat_tatn = citservicioprog.adm_codtat_tatn,
                                          Fcm_codcpr_cpro = citservicioprog.fcm_codcpr_cpro,
                                          Fcm_tiprfa_mfac = citservicioprog.fcm_tiprfa_mfac,
                                          Cit_contad_spro = (int)citservicioprog.cit_contad_spro,
                                          Sis_estreg_esrg = citservicioprog.sis_estreg_esrg,
                                          Sia_desesp_esme = esme.sia_desesp_esme,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sis_desest_esrg = esrg.sis_desest_esrg,
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
    public class ModeloCitmaestroprotocolo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cit_codspt_sprt: Código registro
        private String _cit_codspt_sprt;
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
        private String _cit_codspr_spro;
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
        private String _fcm_idesec_sips;
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (puede ser el codigo en el tarifario) es un codigo auxiliar
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
        #region Sia_tipact_tsac: Tipo Asistencial o PyP
        private String _sia_tipact_tsac;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo Asistencial o PyP</para>
        /// <para>NOMBRE: sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promoción y Prevención 3=Salud publica 4= todas o General
        /// </para>
        /// </summary>
        public String Sia_tipact_tsac
        {
            get { return _sia_tipact_tsac; }
            set
            {
                if (_sia_tipact_tsac == value) return;
                _sia_tipact_tsac = value;
                OnPropertyChanged("Sia_tipact_tsac");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Fcm_totuni_dfac: Total unidades
        private int _fcm_totuni_dfac;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        private String _cit_incrme_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en receta medica</para>
        /// <para>NOMBRE: cit_incrme_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        private String _cit_incfac_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en facturación</para>
        /// <para>NOMBRE: cit_incfac_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        private String _cit_incfrm_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Entrega en farmacia</para>
        /// <para>NOMBRE: cit_incfrm_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Hcl_codreg_hcca: Registro actividad clinica
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Registro actividad clinica</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Generar registro actividad en historial clinico: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia
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
        #region Sis_estreg_esrg: Estado servicio
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado servicio</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        private String _cit_desspr_spro;
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
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
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
        #region Sia_desact_tsac: Tipo servicio o actividad
        private String _sia_desact_tsac;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o actividad</para>
        /// <para>NOMBRE: sia_desact_tsac (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Tipo servico o actividad de salud
        /// </para>
        /// </summary>
        public String Sia_desact_tsac
        {
            get { return _sia_desact_tsac; }
            set
            {
                if (_sia_desact_tsac == value) return;
                _sia_desact_tsac = value;
                OnPropertyChanged("Sia_desact_tsac");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:80)</para>
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
        private String _sis_desest_esrg;
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
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
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
        //- Para servicios asignados en citas
        #region Cit_codspt_cide: Código registro
        private String _cit_codspt_cide;
        /// <summary>
        /// <para>TABLA: citmaesdetacita</para>
        /// <para>TABLA NATIVA: citmaesdetacita</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: cit_codspt_cide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único servicio detalle asigando en cita (generado por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codspt_cide
        {
            get { return _cit_codspt_cide; }
            set
            {
                if (_cit_codspt_cide == value) return;
                _cit_codspt_cide = value;
                OnPropertyChanged("Cit_codspt_cide");
            }
        }
        #endregion
        #region Cit_codasi_mcit: Código registro cita
        private String _cit_codasi_mcit;
        /// <summary>
        /// <para>TABLA: citmaesdetacita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código único del registro asignación de cita a paciente (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codasi_mcit
        {
            get { return _cit_codasi_mcit; }
            set
            {
                if (_cit_codasi_mcit == value) return;
                _cit_codasi_mcit = value;
                OnPropertyChanged("Cit_codasi_mcit");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloCitmaestroprotocolo tobTempReg, string tcrCodigoR1)
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
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.sia_tipact_tsac = tobTempReg.Sia_tipact_tsac;
                            lobEFReg.fcm_codcpr_cpro = tobTempReg.Fcm_codcpr_cpro;
                            lobEFReg.fcm_totuni_dfac = (int)tobTempReg.Fcm_totuni_dfac;
                            lobEFReg.cit_incrme_sprt = tobTempReg.Cit_incrme_sprt;
                            lobEFReg.cit_incfac_sprt = tobTempReg.Cit_incfac_sprt;
                            lobEFReg.cit_incfrm_sprt = tobTempReg.Cit_incfrm_sprt;
                            lobEFReg.hcl_codreg_hcca = tobTempReg.Hcl_codreg_hcca;
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
        #region Adicionar servicios asignados en la cita antes de confirmar y facturar
        /// <summary>
        /// Servicios asignados en la cita antes de confirmar y facturar: tabla citmaesdetacita
        /// </summary>
        public static bool flgAddRegistroAsigCitas(ModeloCitmaestroprotocolo tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFcitmaesdetacita();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Citmaesdetacita.FirstOrDefault(p => p.cit_codspt_cide == tobTempReg.Cit_codspt_cide);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.cit_codspt_cide = tobTempReg.Cit_codspt_cide;
                            lobEFReg.cit_codasi_mcit = tobTempReg.Cit_codasi_mcit;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.sia_tipact_tsac = tobTempReg.Sia_tipact_tsac;
                            lobEFReg.fcm_codcpr_cpro = tobTempReg.Fcm_codcpr_cpro;
                            lobEFReg.fcm_totuni_dfac = (int)tobTempReg.Fcm_totuni_dfac;
                            lobEFReg.hcl_codreg_hcca = tobTempReg.Hcl_codreg_hcca;
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
                                lobEFReg.cit_codspt_cide = tcrCodigoR1 + lobEFReg.cit_codspt_cide; // concatenar
                                _context.AddToCitmaesdetacita(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Citmaesdetacita.FirstOrDefault(p => p.cit_codspt_cide == tobTempReg.Cit_codspt_cide);
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
        #region Eliminar registro
        /// <summary>
        /// Eliminar lista detalles servicios programados en registro citas
        /// </summary>
        /// <param name="tcrCodigo">Codigo del regisro asignacion cita</param>
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobTmpRegistro = (from tmp in _context.Citmaesdetacita where tmp.cit_codasi_mcit == tcrCodigo select tmp).ToList();
                if (lobTmpRegistro != null && lobTmpRegistro.Count != 0)
                {
                    foreach (var lobjRegistro in lobTmpRegistro)
                    {
                        _context.DeleteObject(lobjRegistro);
                    }
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Listar Registros servicios programados
        /// <summary>
        /// Lista detalles servicios del protocolo medico programados para facturacion
        /// </summary>
        public static List<ModeloCitmaestroprotocolo> flsListaCitservprotocol(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from citservprotocol in _context.Citservprotocol
                                  join fcmmanservicips in _context.Fcmmanservicips on citservprotocol.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  join siatipactividad in _context.Siatipactividad on citservprotocol.sia_tipact_tsac equals siatipactividad.sia_tipact_tsac into tmsiatipactividad
                                  join fcmcenproduccio in _context.Fcmcenproduccio on citservprotocol.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                  join hcltiporegactiv in _context.Hcltiporegactiv on citservprotocol.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                  join sisestadoregist in _context.Sisestadoregist on citservprotocol.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  from tsac in tmsiatipactividad.DefaultIfEmpty()
                                  from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                  from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                  from esrg in tmsisestadoregist.DefaultIfEmpty()
                                  where citservprotocol.cit_codspr_spro == tcrBuscar
                                  select new ModeloCitmaestroprotocolo
                                  {
                                      Cit_codspt_sprt = citservprotocol.cit_codspt_sprt,
                                      Cit_codspr_spro = citservprotocol.cit_codspr_spro,
                                      Fcm_idesec_sips = citservprotocol.fcm_idesec_sips,
                                      Fcm_coddig_mant = citservprotocol.fcm_coddig_mant,
                                      Sia_tipact_tsac = citservprotocol.sia_tipact_tsac,
                                      Fcm_codcpr_cpro = citservprotocol.fcm_codcpr_cpro,
                                      Fcm_totuni_dfac = (int)citservprotocol.fcm_totuni_dfac,
                                      Cit_incrme_sprt = citservprotocol.cit_incrme_sprt,
                                      Cit_incfac_sprt = citservprotocol.cit_incfac_sprt,
                                      Cit_incfrm_sprt = citservprotocol.cit_incfrm_sprt,
                                      Hcl_codreg_hcca = citservprotocol.hcl_codreg_hcca,
                                      Sis_estreg_esrg = citservprotocol.sis_estreg_esrg,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Sia_desact_tsac = tsac.sia_desact_tsac,
                                      Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                      Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                      Sis_desest_esrg = esrg.sis_desest_esrg,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar detalles servicios asignados a citas
        /// <summary>
        /// Lista detalles servicios asignados a citas
        /// </summary>
        public static List<ModeloCitmaestroprotocolo> flsListaCitmaesdetacita(string tcrIdCitaAsignada)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from citmaesdetacita in _context.Citmaesdetacita
                                  join fcmmanservicips in _context.Fcmmanservicips on citmaesdetacita.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  join siatipactividad in _context.Siatipactividad on citmaesdetacita.sia_tipact_tsac equals siatipactividad.sia_tipact_tsac into tmsiatipactividad
                                  join hcltiporegactiv in _context.Hcltiporegactiv on citmaesdetacita.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  from tsac in tmsiatipactividad.DefaultIfEmpty()
                                  from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                  where citmaesdetacita.cit_codasi_mcit == tcrIdCitaAsignada
                                  select new ModeloCitmaestroprotocolo
                                  {
                                      Cit_codspt_cide = citmaesdetacita.cit_codspt_cide,
                                      Cit_codasi_mcit = citmaesdetacita.cit_codasi_mcit,
                                      Fcm_idesec_sips = citmaesdetacita.fcm_idesec_sips,
                                      Fcm_coddig_mant = citmaesdetacita.fcm_coddig_mant,
                                      Sia_tipact_tsac = citmaesdetacita.sia_tipact_tsac,
                                      Fcm_codcpr_cpro = citmaesdetacita.fcm_codcpr_cpro,
                                      Fcm_totuni_dfac = (int)citmaesdetacita.fcm_totuni_dfac,
                                      Hcl_codreg_hcca = citmaesdetacita.hcl_codreg_hcca,
                                      Cit_incfac_sprt = "1",
                                      Sis_estreg_esrg = citmaesdetacita.sis_estreg_esrg,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Sia_desact_tsac = tsac.sia_desact_tsac,
                                      Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 28/04/2015 03:43:31 PM
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

namespace FacturacionMedica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmcenproduccio
    /// </summary>
    public class ModeloFcmcenproduccio : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción generado por el sistema
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
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
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
        #region Sia_codare_aser: Código área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo area prestacion de servicios medicos  a la cual pertenece
        /// el centro de producción
        /// </para>
        /// </summary>
        public String Sia_codare_aser
        {
            get { return _sia_codare_aser; }
            set
            {
                if (_sia_codare_aser == value) return;
                _sia_codare_aser = value;
                OnPropertyChanged("Sia_codare_aser");
            }
        }
        #endregion
        #region Con_codafu_afun: Código área funcional
        private String _con_codafu_afun;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: conareasfuncion</para>
        /// <para>CAMPO: Código área funcional</para>
        /// <para>NOMBRE: con_codafu_afun (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo area funcional de la empresa
        /// </para>
        /// </summary>
        public String Con_codafu_afun
        {
            get { return _con_codafu_afun; }
            set
            {
                if (_con_codafu_afun == value) return;
                _con_codafu_afun = value;
                OnPropertyChanged("Con_codafu_afun");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_codcat_ceat
        {
            get { return _sia_codcat_ceat; }
            set
            {
                if (_sia_codcat_ceat == value) return;
                _sia_codcat_ceat = value;
                OnPropertyChanged("Sia_codcat_ceat");
            }
        }
        #endregion
        #region Con_codsco_ccos: Código centro de costo
        private String _con_codsco_ccos;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codgio del centro de costo para manejo contable
        /// </para>
        /// </summary>
        public String Con_codsco_ccos
        {
            get { return _con_codsco_ccos; }
            set
            {
                if (_con_codsco_ccos == value) return;
                _con_codsco_ccos = value;
                OnPropertyChanged("Con_codsco_ccos");
            }
        }
        #endregion
        #region Fcm_genhis_cpro: Registrar actividad
        private String _fcm_genhis_cpro;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: fcm_genhis_cpro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public String Fcm_genhis_cpro
        {
            get { return _fcm_genhis_cpro; }
            set
            {
                if (_fcm_genhis_cpro == value) return;
                _fcm_genhis_cpro = value;
                OnPropertyChanged("Fcm_genhis_cpro");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla historia clinica asociada al programa
        /// o centro de produccion para generar registro actividad en historia
        /// clinica
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
        #region Hcl_codreg_hcca: Tipo Registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad medica ejemplo: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia y otras
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
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Sis_estreg_esrg: Estado centro producción
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado centro producción</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado  del centro produccion: 1=Activo  2=Inactivo
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public String Sia_desare_aser
        {
            get { return _sia_desare_aser; }
            set
            {
                if (_sia_desare_aser == value) return;
                _sia_desare_aser = value;
                OnPropertyChanged("Sia_desare_aser");
            }
        }
        #endregion
        #region Con_desafu_afun: Nombre área funcional
        private String _con_desafu_afun;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: conareasfuncion</para>
        /// <para>CAMPO: Nombre área funcional</para>
        /// <para>NOMBRE: con_desafu_afun (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del Área funcional
        /// </para>
        /// </summary>
        public String Con_desafu_afun
        {
            get { return _con_desafu_afun; }
            set
            {
                if (_con_desafu_afun == value) return;
                _con_desafu_afun = value;
                OnPropertyChanged("Con_desafu_afun");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_descat_ceat
        {
            get { return _sia_descat_ceat; }
            set
            {
                if (_sia_descat_ceat == value) return;
                _sia_descat_ceat = value;
                OnPropertyChanged("Sia_descat_ceat");
            }
        }
        #endregion
        #region Con_dessco_ccos: Nombre centro de costo
        private String _con_dessco_ccos;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Nombre centro de costo</para>
        /// <para>NOMBRE: con_dessco_ccos (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del centro de costo
        /// </para>
        /// </summary>
        public String Con_dessco_ccos
        {
            get { return _con_dessco_ccos; }
            set
            {
                if (_con_dessco_ccos == value) return;
                _con_dessco_ccos = value;
                OnPropertyChanged("Con_dessco_ccos");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
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
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
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
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloFcmcenproduccio tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMCENPRODUCCIO", "FCM", "Centros de produccion asistenciales");
            if (!flgBuscarFcmcenproduccio(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmcenproduccio
                    {
                        #region cargar Registro
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        fcm_descpr_cpro = tobjModelo.Fcm_descpr_cpro,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        con_codafu_afun = tobjModelo.Con_codafu_afun,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        con_codsco_ccos = tobjModelo.Con_codsco_ccos,
                        fcm_genhis_cpro = tobjModelo.Fcm_genhis_cpro,
                        grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                        hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.fcm_codcpr_cpro = lcrCodigoGen;
                    _context.AddToFcmcenproduccio(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMCENPRODUCCIO': Centros de produccion asistenciales en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloFcmcenproduccio tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tobjModelo.Fcm_codcpr_cpro);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.fcm_descpr_cpro = tobjModelo.Fcm_descpr_cpro;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.con_codafu_afun = tobjModelo.Con_codafu_afun;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.con_codsco_ccos = tobjModelo.Con_codsco_ccos;
                    lobjRegistro.fcm_genhis_cpro = tobjModelo.Fcm_genhis_cpro;
                    lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                    lobjRegistro.hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
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
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMCENPRODUCCIO: Logica
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TITULO: Centros de produccion asistenciales</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Centros de produccion, existentes en las diferentes areas de
        /// prestacion de servicios medicos ejm : 1110 = Consulta Médica
        /// General   1145 = Consulta de Nutrición (esta tabla pertenece
        /// a facturacion)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmcenproduccio(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcenproduccio.FirstOrDefault(p => p.fcm_codcpr_cpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFcmcenproduccio> flsListaFcmcenproduccio(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmcenproduccio in _context.Fcmcenproduccio
                                      join siaareapreservi in _context.Siaareapreservi on fcmcenproduccio.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join conareasfuncion in _context.Conareasfuncion on fcmcenproduccio.con_codafu_afun equals conareasfuncion.con_codafu_afun into tmconareasfuncion
                                      join siacentroaten in _context.Siacentroaten on fcmcenproduccio.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join concentrodcosto in _context.Concentrodcosto on fcmcenproduccio.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join grpmaeplantilla in _context.Grpmaeplantilla on fcmcenproduccio.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join hcltiporegactiv in _context.Hcltiporegactiv on fcmcenproduccio.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      join fcmmanservicips in _context.Fcmmanservicips on fcmcenproduccio.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from afun in tmconareasfuncion.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      select new ModeloFcmcenproduccio
                                      {
                                          Fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro,
                                          Fcm_descpr_cpro = fcmcenproduccio.fcm_descpr_cpro,
                                          Sia_codare_aser = fcmcenproduccio.sia_codare_aser,
                                          Con_codafu_afun = fcmcenproduccio.con_codafu_afun,
                                          Sia_codcat_ceat = fcmcenproduccio.sia_codcat_ceat,
                                          Con_codsco_ccos = fcmcenproduccio.con_codsco_ccos,
                                          Fcm_genhis_cpro = fcmcenproduccio.fcm_genhis_cpro,
                                          Grp_idepla_grpl = fcmcenproduccio.grp_idepla_grpl,
                                          Hcl_codreg_hcca = fcmcenproduccio.hcl_codreg_hcca,
                                          Fcm_idesec_sips = fcmcenproduccio.fcm_idesec_sips,
                                          Fcm_coddig_mant = fcmcenproduccio.fcm_coddig_mant,
                                          Sis_estreg_esrg = fcmcenproduccio.sis_estreg_esrg,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Con_desafu_afun = afun.con_desafu_afun,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Con_dessco_ccos = ccos.con_dessco_ccos,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmcenproduccio in _context.Fcmcenproduccio
                                      join siaareapreservi in _context.Siaareapreservi on fcmcenproduccio.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join conareasfuncion in _context.Conareasfuncion on fcmcenproduccio.con_codafu_afun equals conareasfuncion.con_codafu_afun into tmconareasfuncion
                                      join siacentroaten in _context.Siacentroaten on fcmcenproduccio.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join concentrodcosto in _context.Concentrodcosto on fcmcenproduccio.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join grpmaeplantilla in _context.Grpmaeplantilla on fcmcenproduccio.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                      join hcltiporegactiv in _context.Hcltiporegactiv on fcmcenproduccio.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      join fcmmanservicips in _context.Fcmmanservicips on fcmcenproduccio.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from afun in tmconareasfuncion.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      where fcmcenproduccio.fcm_codcpr_cpro.Contains(tcrBuscar) || fcmcenproduccio.fcm_descpr_cpro.Contains(tcrBuscar)
                                      select new ModeloFcmcenproduccio
                                      {
                                          Fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro,
                                          Fcm_descpr_cpro = fcmcenproduccio.fcm_descpr_cpro,
                                          Sia_codare_aser = fcmcenproduccio.sia_codare_aser,
                                          Con_codafu_afun = fcmcenproduccio.con_codafu_afun,
                                          Sia_codcat_ceat = fcmcenproduccio.sia_codcat_ceat,
                                          Con_codsco_ccos = fcmcenproduccio.con_codsco_ccos,
                                          Fcm_genhis_cpro = fcmcenproduccio.fcm_genhis_cpro,
                                          Grp_idepla_grpl = fcmcenproduccio.grp_idepla_grpl,
                                          Hcl_codreg_hcca = fcmcenproduccio.hcl_codreg_hcca,
                                          Fcm_idesec_sips = fcmcenproduccio.fcm_idesec_sips,
                                          Fcm_coddig_mant = fcmcenproduccio.fcm_coddig_mant,
                                          Sis_estreg_esrg = fcmcenproduccio.sis_estreg_esrg,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Con_desafu_afun = afun.con_desafu_afun,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Con_dessco_ccos = ccos.con_dessco_ccos,
                                          Grp_despla_grpl = grpl.grp_despla_grpl,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
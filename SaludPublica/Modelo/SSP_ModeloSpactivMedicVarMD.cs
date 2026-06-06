//- MARMOTA-GENCODE: VERSION 2.0 - 19/02/2018 03:55:33 PM
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

namespace SaludPublica.Modelo
{
    /// <summary>
    ///spactivmedicvar: Lista formato actividades pertenecientes a una variable 4505 relacionadas con variables publicas en un formato.
    /// </summary>
    public class ModeloSpactivMedicVarMD : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Ssp_secreg_ssvr: Código registro
        private String _ssp_secreg_ssvr;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: spactivmedicvar</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: ssp_secreg_ssvr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Consecutivo unico del registro generado por el sistema
        /// </para>
        /// </summary>
        public String Ssp_secreg_ssvr
        {
            get { return _ssp_secreg_ssvr; }
            set
            {
                if (_ssp_secreg_ssvr == value) return;
                _ssp_secreg_ssvr = value;
                OnPropertyChanged("Ssp_secreg_ssvr");
            }
        }
        #endregion
        #region Ssp_secreg_sspd: Código ID variables
        private String _ssp_secreg_sspd;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: spprogramgrupmd</para>
        /// <para>CAMPO: Código ID variables</para>
        /// <para>NOMBRE: ssp_secreg_sspd (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo id unico campo variable 4505 relacionados con programas
        /// de salud
        /// </para>
        /// </summary>
        public String Ssp_secreg_sspd
        {
            get { return _ssp_secreg_sspd; }
            set
            {
                if (_ssp_secreg_sspd == value) return;
                _ssp_secreg_sspd = value;
                OnPropertyChanged("Ssp_secreg_sspd");
            }
        }
        #endregion
        #region Ssp_codpro_sspa: Grupo Activdad
        private String _ssp_codpro_sspa;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Grupo programas</para>
        /// <para>NOMBRE: ssp_codpro_sspa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo unico Grupo Actividad o Programa de salud</para>
        /// </summary>
        public String Ssp_codpro_sspa
        {
            get { return _ssp_codpro_sspa; }
            set
            {
                if (_ssp_codpro_sspa == value) return;
                _ssp_codpro_sspa = value;
                OnPropertyChanged("Ssp_codpro_sspa");
            }
        }
        #endregion
        #region Ssp_codcam_resc: Campo 4505
        private String _ssp_codcam_resc;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo 4505</para>
        /// <para>NOMBRE: ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Consecutivo unico de campo o nombre (ejemplo: SSP_CAM025_MS45)
        /// en historicos resolucion 4505
        /// </para>
        /// </summary>
        public String Ssp_codcam_resc
        {
            get { return _ssp_codcam_resc; }
            set
            {
                if (_ssp_codcam_resc == value) return;
                _ssp_codcam_resc = value;
                OnPropertyChanged("Ssp_codcam_resc");
            }
        }
        #endregion
        #region Hcl_nomvar_hcvr: Nombre variable publica
        private String _hcl_nomvar_hcvr;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Nombre variable publica</para>
        /// <para>NOMBRE: hcl_nomvar_hcvr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Nombre unico identificador de la variable, para referencia
        /// dentro del sistema, este nombre debe incluir nombre identificador
        /// del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS
        /// 1, JOVEN_PLANIFICACION_SI_NO
        /// </para>
        /// </summary>
        public String Hcl_nomvar_hcvr
        {
            get { return _hcl_nomvar_hcvr; }
            set
            {
                if (_hcl_nomvar_hcvr == value) return;
                _hcl_nomvar_hcvr = value;
                OnPropertyChanged("Hcl_nomvar_hcvr");
            }
        }
        #endregion
        #region Hcl_codreg_hcca: Tipo registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia
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
        #region Ssp_parmet_ssvr: Parametros
        private String _ssp_parmet_ssvr;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: spactivmedicvar</para>
        /// <para>CAMPO: Parametros</para>
        /// <para>NOMBRE: ssp_parmet_ssvr (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Parametros especiales de gestion
        /// </para>
        /// </summary>
        public String Ssp_parmet_ssvr
        {
            get { return _ssp_parmet_ssvr; }
            set
            {
                if (_ssp_parmet_ssvr == value) return;
                _ssp_parmet_ssvr = value;
                OnPropertyChanged("Ssp_parmet_ssvr");
            }
        }
        #endregion
        #region Ssp_estreg_ssvr: Estado del registro
        private String _ssp_estreg_ssvr;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: spactivmedicvar</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: ssp_estreg_ssvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Ssp_estreg_ssvr
        {
            get { return _ssp_estreg_ssvr; }
            set
            {
                if (_ssp_estreg_ssvr == value) return;
                _ssp_estreg_ssvr = value;
                OnPropertyChanged("Ssp_estreg_ssvr");
            }
        }
        #endregion
        #region Ssp_nomcam_resc: Titulo o Etiqueta desde campos 4505
        private String _ssp_nomcam_resc;
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: ssp_nomcam_resc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:Titulo o Etiqueta desde campos 4505</para>
        /// </summary>
        public String Ssp_nomcam_resc
        {
            get { return _ssp_nomcam_resc; }
            set
            {
                if (_ssp_nomcam_resc == value) return;
                _ssp_nomcam_resc = value;
                OnPropertyChanged("Ssp_nomcam_resc");
            }
        }
        #endregion
        #region Hcl_titulo_hcvr: Titulo desde maestro variables historias clinicas
        private String _hcl_titulo_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: Hcl_titulo_hcvr (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION: Titulo desde maestro variables historias clinicas</para>
        /// </summary>
        public String Hcl_titulo_hcvr
        {
            get { return _hcl_titulo_hcvr; }
            set
            {
                if (_hcl_titulo_hcvr == value) return;
                _hcl_titulo_hcvr = value;
                OnPropertyChanged("Hcl_titulo_hcvr");
            }
        }
        #endregion
        #region Hcl_desreg_hcca: Titulo desde maestro actividades de historias clinicas
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Titulo actividad</para>
        /// <para>NOMBRE: Hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION: Titulo desde maestro actividades de historias clinicas asociadas a formatos</para>
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
        #region Estado: Marca en procesos, se usa como campo temporal de gestion
        private String _estado;
        /// <summary>
        /// <para>Marca en procesos, se usa como campo temporal de gestion</para>
        /// </summary>
        public String Estado
        {
            get { return _estado; }
            set
            {
                if (_estado == value) return;
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }
        #endregion
        // Datos complementos del campo 4505
        #region Ssp_ordvis_resc: Orden Vista
        private int _ssp_ordvis_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: ssp_ordvis_resc (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Orden de vista del campo en la resolucion (inicia desde campo
        /// cero (0) hasta 118)
        /// </para>
        /// </summary>
        public int Ssp_ordvis_resc
        {
            get { return _ssp_ordvis_resc; }
            set
            {
                if (_ssp_ordvis_resc == value) return;
                _ssp_ordvis_resc = value;
                OnPropertyChanged("Ssp_ordvis_resc");
            }
        }
        #endregion
        #region Ssp_tipval_resc: Tipo de Valor
        private String _ssp_tipval_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: ssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico
        /// </para>
        /// </summary>
        public String Ssp_tipval_resc
        {
            get { return _ssp_tipval_resc; }
            set
            {
                if (_ssp_tipval_resc == value) return;
                _ssp_tipval_resc = value;
                OnPropertyChanged("Ssp_tipval_resc");
            }
        }
        #endregion
        #region Ssp_valper_resc: Valor Permitido
        private String _ssp_valper_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: ssp_valper_resc (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public String Ssp_valper_resc
        {
            get { return _ssp_valper_resc; }
            set
            {
                if (_ssp_valper_resc == value) return;
                _ssp_valper_resc = value;
                OnPropertyChanged("Ssp_valper_resc");
            }
        }
        #endregion
        #region Ssp_camdig_resc: Campo digitable
        private String _ssp_camdig_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: ssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Ssp_camdig_resc
        {
            get { return _ssp_camdig_resc; }
            set
            {
                if (_ssp_camdig_resc == value) return;
                _ssp_camdig_resc = value;
                OnPropertyChanged("Ssp_camdig_resc");
            }
        }
        #endregion
        #region Ssp_ranini_resc: Rango inicial
        private String _ssp_ranini_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: ssp_ranini_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Rango inicial del valor digitable
        /// </para>
        /// </summary>
        public String Ssp_ranini_resc
        {
            get { return _ssp_ranini_resc; }
            set
            {
                if (_ssp_ranini_resc == value) return;
                _ssp_ranini_resc = value;
                OnPropertyChanged("Ssp_ranini_resc");
            }
        }
        #endregion
        #region Ssp_ranfin_resc: Rango final
        private String _ssp_ranfin_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: ssp_ranfin_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Rango final del valor digitable
        /// </para>
        /// </summary>
        public String Ssp_ranfin_resc
        {
            get { return _ssp_ranfin_resc; }
            set
            {
                if (_ssp_ranfin_resc == value) return;
                _ssp_ranfin_resc = value;
                OnPropertyChanged("Ssp_ranfin_resc");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloSpactivMedicVarMD tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SSP-SPACTIVMEDICVAR", "SSP", "Lista formatos actividades por variables");
            try
            {
                if (!flgBuscarSpactivmedicvar(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFspactivmedicvar
                        {
                            #region cargar Registro
                            ssp_secreg_ssvr = tobjModelo.Ssp_secreg_ssvr,
                            ssp_secreg_sspd = tobjModelo.Ssp_secreg_sspd,
                            ssp_codpro_sspa = tobjModelo.Ssp_codpro_sspa,
                            ssp_codcam_resc = tobjModelo.Ssp_codcam_resc,
                            hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr,
                            hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca,
                            ssp_parmet_ssvr = tobjModelo.Ssp_parmet_ssvr,
                            ssp_estreg_ssvr = tobjModelo.Ssp_estreg_ssvr,
                            #endregion
                        };
                        lobjRegistro.ssp_secreg_ssvr = lcrCodigoGen;
                        _context.AddToSpactivmedicvar(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SSP-SPACTIVMEDICVAR': Lista formatos actividades por variables en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloSpactivMedicVarMD tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Spactivmedicvar.FirstOrDefault(p => p.ssp_secreg_ssvr == tobjModelo.Ssp_secreg_ssvr);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.ssp_secreg_ssvr = tobjModelo.Ssp_secreg_ssvr;
                        lobjRegistro.ssp_secreg_sspd = tobjModelo.Ssp_secreg_sspd;
                        lobjRegistro.ssp_codpro_sspa = tobjModelo.Ssp_codpro_sspa;
                        lobjRegistro.ssp_codcam_resc = tobjModelo.Ssp_codcam_resc;
                        lobjRegistro.hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr;
                        lobjRegistro.hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca;
                        lobjRegistro.ssp_parmet_ssvr = tobjModelo.Ssp_parmet_ssvr;
                        lobjRegistro.ssp_estreg_ssvr = tobjModelo.Ssp_estreg_ssvr;
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
                    var lobjRegistro = _context.Spactivmedicvar.FirstOrDefault(p => p.ssp_secreg_ssvr == tcrCodigo);
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
        #region Buscar SPACTIVMEDICVAR: Logica
        /// <summary>
        /// <para>TABLA: spactivmedicvar</para>
        /// <para>TITULO: Lista formatos actividades por variables</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista formato actividades pertenecientes a una variable 4505
        /// relacionadas con variables publicas en un formato.
        /// </para>
        /// </summary>
        public static bool flgBuscarSpactivmedicvar(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spactivmedicvar.FirstOrDefault(p => p.ssp_secreg_ssvr == tcrCodigo);
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
        /// Retorna una lista de registros desde la tabla actividades relacionadas variables 4505 y variables publicas
        /// </summary>
        /// <param name="tcrBuscar">Cuando se envia parametro vacio, devuelve todos los registros de la tabla</param>
        /// <returns></returns>
        public static List<ModeloSpactivMedicVarMD> flsListaSpactivmedicvar(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from spactivmedicvar in _context.Spactivmedicvar
                                      join sptabcampos4505 in _context.Sptabcampos4505 on spactivmedicvar.ssp_codcam_resc equals sptabcampos4505.ssp_codcam_resc into tmsptabcampos4505
                                      join hclvariabmaestr in _context.Hclvariabmaestr on spactivmedicvar.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                      join Hcltiporegactiv in _context.Hcltiporegactiv on spactivmedicvar.hcl_codreg_hcca equals Hcltiporegactiv.hcl_secreg_hcca into tmHcltiporegactiv
                                      from resc in tmsptabcampos4505.DefaultIfEmpty()
                                      from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                      from hcca in tmHcltiporegactiv.DefaultIfEmpty()
                                      orderby spactivmedicvar.ssp_codpro_sspa
                                      select new ModeloSpactivMedicVarMD
                                      {
                                          #region Datos
                                          Ssp_secreg_ssvr = spactivmedicvar.ssp_secreg_ssvr,
                                          Ssp_secreg_sspd = spactivmedicvar.ssp_secreg_sspd,
                                          Ssp_codpro_sspa = spactivmedicvar.ssp_codpro_sspa,
                                          Ssp_codcam_resc = spactivmedicvar.ssp_codcam_resc,
                                          Hcl_nomvar_hcvr = spactivmedicvar.hcl_nomvar_hcvr,
                                          Hcl_codreg_hcca = spactivmedicvar.hcl_codreg_hcca,
                                          Ssp_parmet_ssvr = spactivmedicvar.ssp_parmet_ssvr,
                                          Ssp_estreg_ssvr = spactivmedicvar.ssp_estreg_ssvr,
                                          Ssp_nomcam_resc = resc.ssp_nomcam_resc,
                                          Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from spactivmedicvar in _context.Spactivmedicvar
                                      join sptabcampos4505 in _context.Sptabcampos4505 on spactivmedicvar.ssp_codcam_resc equals sptabcampos4505.ssp_codcam_resc into tmsptabcampos4505
                                      join hclvariabmaestr in _context.Hclvariabmaestr on spactivmedicvar.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                      join Hcltiporegactiv in _context.Hcltiporegactiv on spactivmedicvar.hcl_codreg_hcca equals Hcltiporegactiv.hcl_secreg_hcca into tmHcltiporegactiv
                                      from resc in tmsptabcampos4505.DefaultIfEmpty()
                                      from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                      from hcca in tmHcltiporegactiv.DefaultIfEmpty()
                                      where spactivmedicvar.ssp_secreg_ssvr == tcrBuscar
                                      select new ModeloSpactivMedicVarMD
                                      {
                                          #region Datos
                                          Ssp_secreg_ssvr = spactivmedicvar.ssp_secreg_ssvr,
                                          Ssp_secreg_sspd = spactivmedicvar.ssp_secreg_sspd,
                                          Ssp_codpro_sspa = spactivmedicvar.ssp_codpro_sspa,
                                          Ssp_codcam_resc = spactivmedicvar.ssp_codcam_resc,
                                          Hcl_nomvar_hcvr = spactivmedicvar.hcl_nomvar_hcvr,
                                          Hcl_codreg_hcca = spactivmedicvar.hcl_codreg_hcca,
                                          Ssp_parmet_ssvr = spactivmedicvar.ssp_parmet_ssvr,
                                          Ssp_estreg_ssvr = spactivmedicvar.ssp_estreg_ssvr,
                                          Ssp_nomcam_resc = resc.ssp_nomcam_resc,
                                          Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                          Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Listar Registros todos 
        /// <summary>
        /// <para>Retorna todos los registros desde la tabla (Spactivmedicvar) Grupos Actividades variables 4505</para>
        /// <para>relacionadas con variables publicas y formatos actividades medicas</para>
        /// </summary>
        public static List<ModeloSpactivMedicVarMD> flsListaSpactivmedicvarTodos()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from spactivmedicvar in _context.Spactivmedicvar
                                  join sptabcampos4505 in _context.Sptabcampos4505 on spactivmedicvar.ssp_codcam_resc equals sptabcampos4505.ssp_codcam_resc into tmsptabcampos4505
                                  join hclvariabmaestr in _context.Hclvariabmaestr on spactivmedicvar.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                  join Hcltiporegactiv in _context.Hcltiporegactiv on spactivmedicvar.hcl_codreg_hcca equals Hcltiporegactiv.hcl_secreg_hcca into tmHcltiporegactiv
                                  from resc in tmsptabcampos4505.DefaultIfEmpty()
                                  from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                  from hcca in tmHcltiporegactiv.DefaultIfEmpty()
                                  orderby spactivmedicvar.ssp_codpro_sspa, resc.ssp_ordvis_resc
                                  select new ModeloSpactivMedicVarMD
                                  {
                                      #region Datos
                                      Ssp_secreg_ssvr = spactivmedicvar.ssp_secreg_ssvr,
                                      Ssp_secreg_sspd = spactivmedicvar.ssp_secreg_sspd,
                                      Ssp_codpro_sspa = spactivmedicvar.ssp_codpro_sspa,
                                      Ssp_codcam_resc = spactivmedicvar.ssp_codcam_resc,
                                      Hcl_nomvar_hcvr = spactivmedicvar.hcl_nomvar_hcvr,
                                      Hcl_codreg_hcca = spactivmedicvar.hcl_codreg_hcca,
                                      Ssp_parmet_ssvr = spactivmedicvar.ssp_parmet_ssvr,
                                      Ssp_estreg_ssvr = spactivmedicvar.ssp_estreg_ssvr,
                                      Ssp_nomcam_resc = resc.ssp_nomcam_resc,
                                      Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                      Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                      Ssp_ordvis_resc = (int)resc.ssp_ordvis_resc,
                                      Ssp_tipval_resc = resc.ssp_tipval_resc,
                                      Ssp_valper_resc = resc.ssp_valper_resc,
                                      Ssp_camdig_resc = resc.ssp_camdig_resc,
                                      Ssp_ranini_resc = resc.ssp_ranini_resc,
                                      Ssp_ranfin_resc = resc.ssp_ranfin_resc,
                                      Estado = "NA"
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsListGrupoVarPubicasPlantillas: Listar Variables publicas relacionas en actividades medicas
        /// <summary>
        /// <para>Retorna Listar registros tipo (Grpplantvistcam) objetos plantillas (Campos Archivos y Variables publicas)</para>
        /// <para>relacionadas con formatos actividades medicas 4505</para>
        /// <para>Ejecuta un proceso que genera todas las posiblidades de una variable publica en versiones de plantillas</para>
        /// </summary>
        public static List<ModeloGrpplantvistcam> flsListGrupoVarPubicasPlantillas()
        {
            var tmpRelacion = new List<ModeloGrpplantvistcam>();
            var tmpGrupoVar = flsListaSpactivmedicvarTodos();
            var tmpListPlan = ModeloGrpplantvistcam.flsListaGrpplantvistcamTodas();
            var lnuContador = 0;

            // Recorrer todas las variables en cada grupo de actividad
            foreach (var lobReg in tmpGrupoVar)
            {
                // Buscar la variable publica y filtrar todos donde este
                #region gestion
                var tmpSelect = (from tmp in tmpListPlan
                                 where tmp.Hcl_nomvar_hcvr == lobReg.Hcl_nomvar_hcvr &&
                                       tmp.Hcl_nomvar_hcvr != "NA"
                                 select tmp).ToList();

                if (tmpSelect != null)
                {
                    // agregar todas las referencias desde versiones plantillas
                    foreach (var lobRegv in tmpSelect)
                    {
                        var lobRegx = tmpRelacion.FirstOrDefault(x => x.Ssp_codcam_resc == lobReg.Ssp_codcam_resc &&
                                                                      x.Hcl_nomvar_hcvr == lobReg.Hcl_nomvar_hcvr &&
                                                                      x.Ssp_codpro_sspa == lobReg.Ssp_codpro_sspa &&
                                                                      x.Grp_idepla_grpv == lobRegv.Grp_idepla_grpv);
                        //Cuando no existe se agrega
                        if (lobRegx == null)
                        {
                            /*
                            if (lobRegv.Hcl_nomarc_hccm.ToLower() == "hclregisexrel" && lobReg.Ssp_codcam_resc == "SSP_CAM021_MS45" && lobReg.Ssp_codpro_sspa == "09")
                            {
                                MessageBox.Show("CAMPO " + lobReg.Ssp_codcam_resc + " PLANTILLA " + lobRegv.Grp_idepla_grpv + " VARIABLE " + lobRegv.Hcl_nomvar_hcvr);
                            }
                            */

                            lnuContador++;
                            var lcrIDReg = lobReg.Ssp_codpro_sspa.Trim() + "R" + lnuContador.ToString().Trim();

                            var lobRegTmp = new ModeloGrpplantvistcam
                            {
                                #region datos
                                Grp_idereg_grob = lcrIDReg,
                                Grp_idepla_grpv = lobRegv.Grp_idepla_grpv,
                                Grp_idepla_grpl = lobRegv.Grp_idepla_grpl,
                                Grp_nomobj_grob = lobRegv.Grp_nomobj_grob,
                                Grp_desobj_grob = lobRegv.Grp_desobj_grob,
                                Grp_varobj_grob = lobRegv.Grp_varobj_grob,
                                Grp_claseb_grob = lobRegv.Grp_claseb_grob,
                                Grp_claseg_grob = lobRegv.Grp_claseg_grob,
                                Hcl_nomcam_hccm = lobRegv.Hcl_nomcam_hccm,
                                Hcl_camdes_hccm = lobRegv.Hcl_camdes_hccm,
                                Hcl_nomvar_hcvr = lobRegv.Hcl_nomvar_hcvr,
                                Grp_repcam_grob = lobRegv.Grp_repcam_grob,
                                Grp_dessec_grse = lobRegv.Grp_dessec_grse,
                                Hcl_nomarc_hccm = lobRegv.Hcl_nomarc_hccm,
                                Ssp_codcam_resc = lobReg.Ssp_codcam_resc,
                                Ssp_codpro_sspa = lobReg.Ssp_codpro_sspa
                                #endregion
                            };
                            tmpRelacion.Add(lobRegTmp);
                        }
                    }
                }
                #endregion
            }
            return tmpRelacion;
        }
        #endregion
        #endregion
    }
}

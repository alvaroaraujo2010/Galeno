//- MARMOTA-GENCODE: VERSION 2.0 - 01/08/2013 05:08:23 PM
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
    /// Descripcion para la Vista de  la tabla: admordendsalida
    /// </summary>
    public class ModeloAutorizarEgreso : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _adm_secaut_aegr;
        private String _adm_secadm_rgad;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private DateTime _adm_fecsol_aegr;
        private DateTime _adm_fecsal_aegr;
        private Decimal _adm_horsal_aegr;
        private String _sia_codpfa_prof;
        private String _adm_observ_aegr;
        private String _adm_estreg_aegr;
        private String _sia_nomusu_usua;
        private String _sia_deside_tide;
        private String _sia_nompro_prof;
        private DateTime _sia_fecnac_usua;
        private String _sis_codsex_sexo;
        private String _sia_edaymd_usua;
        private DateTime _adm_fecadm_rgad;
        private Decimal _adm_horadm_rgad;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Adm_secaut_aegr: Código Autorización
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Código Autorización</para>
        /// <para>NOMBRE: adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial Autorización de egreso paciente (generado por el
        /// sistema)
        /// </para>
        /// </summary>
        public String Adm_secaut_aegr
        {
            get { return _adm_secaut_aegr; }
            set
            {
                if (_adm_secaut_aegr == value) return;
                _adm_secaut_aegr = value;
                OnPropertyChanged("Adm_secaut_aegr");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente al cual se realizara la
        /// orden de salida
        /// </para>
        /// </summary>
        public String Adm_secadm_rgad
        {
            get { return _adm_secadm_rgad; }
            set
            {
                if (_adm_secadm_rgad == value) return;
                _adm_secadm_rgad = value;
                OnPropertyChanged("Adm_secadm_rgad");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public String Sia_idesec_usua
        {
            get { return _sia_idesec_usua; }
            set
            {
                if (_sia_idesec_usua == value) return;
                _sia_idesec_usua = value;
                OnPropertyChanged("Sia_idesec_usua");
            }
        }
        #endregion
        #region Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de d atos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public String Sia_tipide_tide
        {
            get { return _sia_tipide_tide; }
            set
            {
                if (_sia_tipide_tide == value) return;
                _sia_tipide_tide = value;
                OnPropertyChanged("Sia_tipide_tide");
            }
        }
        #endregion
        #region Sia_nroide_usua: Numero de Identificación
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public String Sia_nroide_usua
        {
            get { return _sia_nroide_usua; }
            set
            {
                if (_sia_nroide_usua == value) return;
                _sia_nroide_usua = value;
                OnPropertyChanged("Sia_nroide_usua");
            }
        }
        #endregion
        #region Adm_fecsol_aegr: Fecha solicitud
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Fecha solicitud</para>
        /// <para>NOMBRE: adm_fecsol_aegr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud salida
        /// </para>
        /// </summary>
        public DateTime Adm_fecsol_aegr
        {
            get { return _adm_fecsol_aegr; }
            set
            {
                if (_adm_fecsol_aegr == value) return;
                _adm_fecsol_aegr = value;
                OnPropertyChanged("Adm_fecsol_aegr");
            }
        }
        #endregion
        #region Adm_fecsal_aegr: Fecha salida
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Fecha salida</para>
        /// <para>NOMBRE: adm_fecsal_aegr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha autorización salida
        /// </para>
        /// </summary>
        public DateTime Adm_fecsal_aegr
        {
            get { return _adm_fecsal_aegr; }
            set
            {
                if (_adm_fecsal_aegr == value) return;
                _adm_fecsal_aegr = value;
                OnPropertyChanged("Adm_fecsal_aegr");
            }
        }
        #endregion
        #region Adm_horsal_aegr: Hora de salida
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: adm_horsal_aegr (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora autorización salida  formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_horsal_aegr
        {
            get { return _adm_horsal_aegr; }
            set
            {
                if (_adm_horsal_aegr == value) return;
                _adm_horsal_aegr = value;
                OnPropertyChanged("Adm_horsal_aegr");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Profesional Autoriza
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional Autoriza</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código Profesional Que Autoriza salida del paciente
        /// </para>
        /// </summary>
        public String Sia_codpfa_prof
        {
            get { return _sia_codpfa_prof; }
            set
            {
                if (_sia_codpfa_prof == value) return;
                _sia_codpfa_prof = value;
                OnPropertyChanged("Sia_codpfa_prof");
            }
        }
        #endregion
        #region Adm_observ_aegr: Observación
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Observación</para>
        /// <para>NOMBRE: adm_observ_aegr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Nota u Observación para el la salida
        /// </para>
        /// </summary>
        public String Adm_observ_aegr
        {
            get { return _adm_observ_aegr; }
            set
            {
                if (_adm_observ_aegr == value) return;
                _adm_observ_aegr = value;
                OnPropertyChanged("Adm_observ_aegr");
            }
        }
        #endregion
        #region Adm_estreg_aegr: Estado orden
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Estado orden</para>
        /// <para>NOMBRE: adm_estreg_aegr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado registro autorizacion salida: 1 =Activa 2=Confirmada 3= Anulada
        /// </para>
        /// </summary>
        public String Adm_estreg_aegr
        {
            get { return _adm_estreg_aegr; }
            set
            {
                if (_adm_estreg_aegr == value) return;
                _adm_estreg_aegr = value;
                OnPropertyChanged("Adm_estreg_aegr");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public String Sia_nomusu_usua
        {
            get { return _sia_nomusu_usua; }
            set
            {
                if (_sia_nomusu_usua == value) return;
                _sia_nomusu_usua = value;
                OnPropertyChanged("Sia_nomusu_usua");
            }
        }
        #endregion
        #region Sia_deside_tide: Descripción Tipo Usuario
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public String Sia_deside_tide
        {
            get { return _sia_deside_tide; }
            set
            {
                if (_sia_deside_tide == value) return;
                _sia_deside_tide = value;
                OnPropertyChanged("Sia_deside_tide");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public String Sia_nompro_prof
        {
            get { return _sia_nompro_prof; }
            set
            {
                if (_sia_nompro_prof == value) return;
                _sia_nompro_prof = value;
                OnPropertyChanged("Sia_nompro_prof");
            }
        }
        #endregion
        #region Sia_fecnac_usua:
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_fecnac_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public DateTime Sia_fecnac_usua
        {
            get { return _sia_fecnac_usua; }
            set
            {
                if (_sia_fecnac_usua == value) return;
                _sia_fecnac_usua = value;
                OnPropertyChanged("Sia_fecnac_usua");
            }
        }
        #endregion
        #region Sis_codsex_sexo:
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sis_codsex_sexo (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sis_codsex_sexo
        {
            get { return _sis_codsex_sexo; }
            set
            {
                if (_sis_codsex_sexo == value) return;
                _sis_codsex_sexo = value;
                OnPropertyChanged("Sis_codsex_sexo");
            }
        }
        #endregion
        #region Sia_edaymd_usua:
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_edaymd_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_edaymd_usua
        {
            get { return _sia_edaymd_usua; }
            set
            {
                if (_sia_edaymd_usua == value) return;
                _sia_edaymd_usua = value;
                OnPropertyChanged("Sia_edaymd_usua");
            }
        }
        #endregion
        #region Adm_fecadm_rgad:
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: adm_fecadm_rgad (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public DateTime Adm_fecadm_rgad
        {
            get { return _adm_fecadm_rgad; }
            set
            {
                if (_adm_fecadm_rgad == value) return;
                _adm_fecadm_rgad = value;
                OnPropertyChanged("Adm_fecadm_rgad");
            }
        }
        #endregion
        #region Adm_horadm_rgad:
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: adm_horadm_rgad (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public Decimal Adm_horadm_rgad
        {
            get { return _adm_horadm_rgad; }
            set
            {
                if (_adm_horadm_rgad == value) return;
                _adm_horadm_rgad = value;
                OnPropertyChanged("Adm_horadm_rgad");
            }
        }
        #endregion
        #region Hcl_nrohis_hicl: número historia clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Número o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Hcl_nrohis_hicl
        {
            get { return _hcl_nrohis_hicl; }
            set
            {
                if (_hcl_nrohis_hicl == value) return;
                _hcl_nrohis_hicl = value;
                OnPropertyChanged("Hcl_nrohis_hicl");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloAutorizarEgreso tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ADM-SECEGR-AUTORIZA", "ADM", "Secuencial unico autorizaciones de egreso pacientes");
            if (!flgBuscarAdmordendsalida(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFadmordendsalida
                    {
                        #region cargar Registro
                        adm_secaut_aegr = tobjModelo.Adm_secaut_aegr,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        adm_fecsol_aegr = tobjModelo.Adm_fecsol_aegr,
                        adm_fecsal_aegr = tobjModelo.Adm_fecsal_aegr,
                        adm_horsal_aegr = tobjModelo.Adm_horsal_aegr,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        adm_observ_aegr = tobjModelo.Adm_observ_aegr,
                        adm_estreg_aegr = tobjModelo.Adm_estreg_aegr,
                        #endregion
                    };
                    lobjRegistro.adm_secaut_aegr = lcrCodigoGen;
                    _context.AddToAdmordendsalida(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ADM-SECEGR-AUTORIZA': Secuencial unico autorizaciones de egreso pacientes en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloAutorizarEgreso tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secaut_aegr == tobjModelo.Adm_secaut_aegr);
                if (lobjRegistro != null)
                {
                    lobjRegistro.adm_secaut_aegr = tobjModelo.Adm_secaut_aegr;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.adm_fecsol_aegr = (DateTime)tobjModelo.Adm_fecsol_aegr;
                    lobjRegistro.adm_fecsal_aegr = (DateTime)tobjModelo.Adm_fecsal_aegr;
                    lobjRegistro.adm_horsal_aegr = (Decimal)tobjModelo.Adm_horsal_aegr;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.adm_observ_aegr = tobjModelo.Adm_observ_aegr;
                    lobjRegistro.adm_estreg_aegr = tobjModelo.Adm_estreg_aegr;
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
                var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secaut_aegr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ADMORDENDSALIDA: Logica
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TITULO: Autorizacion de salida o egreso a pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Autorización de egreso a pacientes que se encuentran admitidos
        /// por hospitalización o urgencias, estas autorizaciones las hacen
        /// los profesionales (Médicos enfermeras y otros profesionales
        /// de salud)
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmordendsalida(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admordendsalida.FirstOrDefault(p => p.adm_secaut_aegr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloAutorizarEgreso> flsListaAdmordendsalida(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from admordendsalida in _context.Admordendsalida
                                      join admregadmision in _context.Admregadmision on admordendsalida.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admordendsalida.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admordendsalida.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join siamaeprofsalud in _context.Siamaeprofsalud on admordendsalida.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      select new ModeloAutorizarEgreso
                                      {
                                          Adm_secaut_aegr = admordendsalida.adm_secaut_aegr,
                                          Adm_secadm_rgad = admordendsalida.adm_secadm_rgad,
                                          Sia_idesec_usua = admordendsalida.sia_idesec_usua,
                                          Sia_tipide_tide = admordendsalida.sia_tipide_tide,
                                          Sia_nroide_usua = admordendsalida.sia_nroide_usua,
                                          Adm_fecsol_aegr = (DateTime)admordendsalida.adm_fecsol_aegr,
                                          Adm_fecsal_aegr = (DateTime)admordendsalida.adm_fecsal_aegr,
                                          Adm_horsal_aegr = (Decimal)admordendsalida.adm_horsal_aegr,
                                          Sia_codpfa_prof = admordendsalida.sia_codpfa_prof,
                                          Adm_observ_aegr = admordendsalida.adm_observ_aegr,
                                          Adm_estreg_aegr = admordendsalida.adm_estreg_aegr,
                                          Adm_fecadm_rgad = (DateTime)rgad.adm_fecadm_rgad,
                                          Adm_horadm_rgad = (Decimal)rgad.adm_horadm_rgad,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Hcl_nrohis_hicl = rgad.hcl_nrohis_hicl,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from admordendsalida in _context.Admordendsalida
                                      join admregadmision in _context.Admregadmision on admordendsalida.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admordendsalida.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admordendsalida.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join siamaeprofsalud in _context.Siamaeprofsalud on admordendsalida.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where admordendsalida.adm_secaut_aegr == tcrBuscar
                                      select new ModeloAutorizarEgreso
                                      {
                                          Adm_secaut_aegr = admordendsalida.adm_secaut_aegr,
                                          Adm_secadm_rgad = admordendsalida.adm_secadm_rgad,
                                          Sia_idesec_usua = admordendsalida.sia_idesec_usua,
                                          Sia_tipide_tide = admordendsalida.sia_tipide_tide,
                                          Sia_nroide_usua = admordendsalida.sia_nroide_usua,
                                          Adm_fecsol_aegr = (DateTime)admordendsalida.adm_fecsol_aegr,
                                          Adm_fecsal_aegr = (DateTime)admordendsalida.adm_fecsal_aegr,
                                          Adm_horsal_aegr = (Decimal)admordendsalida.adm_horsal_aegr,
                                          Sia_codpfa_prof = admordendsalida.sia_codpfa_prof,
                                          Adm_observ_aegr = admordendsalida.adm_observ_aegr,
                                          Adm_estreg_aegr = admordendsalida.adm_estreg_aegr,
                                          Adm_fecadm_rgad = (DateTime)rgad.adm_fecadm_rgad,
                                          Adm_horadm_rgad = (Decimal)rgad.adm_horadm_rgad,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Hcl_nrohis_hicl = rgad.hcl_nrohis_hicl,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
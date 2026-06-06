//- MARMOTA-GENCODE: VERSION 2.0 - 27/08/2013 05:50:05 AM
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
    /// Descripcion para la Vista de  la tabla: siacopagcontrib
    /// </summary>
    public class ModeloSiacopagcontrib : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _sia_codcpo_cpcb;
        private String _sia_descpo_cpcb;
        private String _sia_tipafi_tafi;
        private String _sia_nivcon_ncon;
        private String _sia_tipcob_cpcb;
        private Decimal _sia_porapl_cpsb;
        private String _sia_tippor_cpsb;
        private Decimal _sia_maxeve_cpsb;
        private Decimal _sia_maxano_cpsb;
        private String _sia_descon_ncon;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Sia_codcpo_cpcb: Código rango
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Código rango</para>
        /// <para>NOMBRE: sia_codcpo_cpcb (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único para el registro de rangos de copagos y cuotas
        /// moderadoras
        /// </para>
        /// </summary>
        public String Sia_codcpo_cpcb
        {
            get { return _sia_codcpo_cpcb; }
            set
            {
                if (_sia_codcpo_cpcb == value) return;
                _sia_codcpo_cpcb = value;
                OnPropertyChanged("Sia_codcpo_cpcb");
            }
        }
        #endregion
        #region Sia_descpo_cpcb: Descripción rango
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Descripción rango</para>
        /// <para>NOMBRE: sia_descpo_cpcb (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del porcentaje copago aplicado: NIVEL1  (IBC) MENOR
        /// A 2 SMLMV, NIVEL 2 (IBC) DE 2 A 5  SMLMV y mas
        /// </para>
        /// </summary>
        public String Sia_descpo_cpcb
        {
            get { return _sia_descpo_cpcb; }
            set
            {
                if (_sia_descpo_cpcb == value) return;
                _sia_descpo_cpcb = value;
                OnPropertyChanged("Sia_descpo_cpcb");
            }
        }
        #endregion
        #region Sia_tipafi_tafi: Tipo Afiliado Contributivo
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado Contributivo</para>
        /// <para>NOMBRE: sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado contributivo textual: 1=COTIZANTE  2= BENEFICIARIO
        /// 3=AMBOS
        /// </para>
        /// </summary>
        public String Sia_tipafi_tafi
        {
            get { return _sia_tipafi_tafi; }
            set
            {
                if (_sia_tipafi_tafi == value) return;
                _sia_tipafi_tafi = value;
                OnPropertyChanged("Sia_tipafi_tafi");
            }
        }
        #endregion
        #region Sia_nivcon_ncon: Nivel Contributivo
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3  para Calcular cuotas Moderadoras
        /// y copagos
        /// </para>
        /// </summary>
        public String Sia_nivcon_ncon
        {
            get { return _sia_nivcon_ncon; }
            set
            {
                if (_sia_nivcon_ncon == value) return;
                _sia_nivcon_ncon = value;
                OnPropertyChanged("Sia_nivcon_ncon");
            }
        }
        #endregion
        #region Sia_tipcob_cpcb: Tipo de Cobro
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Tipo de Cobro</para>
        /// <para>NOMBRE: sia_tipcob_cpcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Tipo Cobro: 1= Copago 2= Cuota Moderadora
        /// </para>
        /// </summary>
        public String Sia_tipcob_cpcb
        {
            get { return _sia_tipcob_cpcb; }
            set
            {
                if (_sia_tipcob_cpcb == value) return;
                _sia_tipcob_cpcb = value;
                OnPropertyChanged("Sia_tipcob_cpcb");
            }
        }
        #endregion
        #region Sia_porapl_cpsb: Porcentaje de cobro
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Porcentaje de cobro</para>
        /// <para>NOMBRE: sia_porapl_cpsb (decimal:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de aplicación del cobro copago o cuota moderadora
        /// </para>
        /// </summary>
        public Decimal Sia_porapl_cpsb
        {
            get { return _sia_porapl_cpsb; }
            set
            {
                if (_sia_porapl_cpsb == value) return;
                _sia_porapl_cpsb = value;
                OnPropertyChanged("Sia_porapl_cpsb");
            }
        }
        #endregion
        #region Sia_tippor_cpsb: Tipo Porcentaje aplicación
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Tipo Porcentaje aplicación</para>
        /// <para>NOMBRE: sia_tippor_cpsb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio
        /// 2= sobre SMLMV 3= Salario SMLDV
        /// </para>
        /// </summary>
        public String Sia_tippor_cpsb
        {
            get { return _sia_tippor_cpsb; }
            set
            {
                if (_sia_tippor_cpsb == value) return;
                _sia_tippor_cpsb = value;
                OnPropertyChanged("Sia_tippor_cpsb");
            }
        }
        #endregion
        #region Sia_maxeve_cpsb: Máximo Porcentaje evento
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje evento</para>
        /// <para>NOMBRE: sia_maxeve_cpsb (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Máximo Porcentaje de aplicación en un evento en salario mensual
        /// legal vigente (SMLMV)
        /// </para>
        /// </summary>
        public Decimal Sia_maxeve_cpsb
        {
            get { return _sia_maxeve_cpsb; }
            set
            {
                if (_sia_maxeve_cpsb == value) return;
                _sia_maxeve_cpsb = value;
                OnPropertyChanged("Sia_maxeve_cpsb");
            }
        }
        #endregion
        #region Sia_maxano_cpsb: Máximo Porcentaje año
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje año</para>
        /// <para>NOMBRE: sia_maxano_cpsb (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Máximo Porcentaje de aplicación en un mismo año, en salario
        /// mensual legal vigente (SMLMV)
        /// </para>
        /// </summary>
        public Decimal Sia_maxano_cpsb
        {
            get { return _sia_maxano_cpsb; }
            set
            {
                if (_sia_maxano_cpsb == value) return;
                _sia_maxano_cpsb = value;
                OnPropertyChanged("Sia_maxano_cpsb");
            }
        }
        #endregion
        #region Sia_descon_ncon: Descripción nivel contributivo
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Descripción nivel contributivo</para>
        /// <para>NOMBRE: sia_descon_ncon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel contributivo
        /// </para>
        /// </summary>
        public String Sia_descon_ncon
        {
            get { return _sia_descon_ncon; }
            set
            {
                if (_sia_descon_ncon == value) return;
                _sia_descon_ncon = value;
                OnPropertyChanged("Sia_descon_ncon");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSiacopagcontrib tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsiacopagcontrib
                {
                    #region cargar Registro
                    sia_codcpo_cpcb = tobjModelo.Sia_codcpo_cpcb,
                    sia_descpo_cpcb = tobjModelo.Sia_descpo_cpcb,
                    sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi,
                    sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon,
                    sia_tipcob_cpcb = tobjModelo.Sia_tipcob_cpcb,
                    sia_porapl_cpsb = tobjModelo.Sia_porapl_cpsb,
                    sia_tippor_cpsb = tobjModelo.Sia_tippor_cpsb,
                    sia_maxeve_cpsb = tobjModelo.Sia_maxeve_cpsb,
                    sia_maxano_cpsb = tobjModelo.Sia_maxano_cpsb,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.sia_codcpo_cpcb;
                _context.AddToSiacopagcontrib(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSiacopagcontrib tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tobjModelo.Sia_codcpo_cpcb);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sia_codcpo_cpcb = tobjModelo.Sia_codcpo_cpcb;
                    lobjRegistro.sia_descpo_cpcb = tobjModelo.Sia_descpo_cpcb;
                    lobjRegistro.sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi;
                    lobjRegistro.sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon;
                    lobjRegistro.sia_tipcob_cpcb = tobjModelo.Sia_tipcob_cpcb;
                    lobjRegistro.sia_porapl_cpsb = (Decimal)tobjModelo.Sia_porapl_cpsb;
                    lobjRegistro.sia_tippor_cpsb = tobjModelo.Sia_tippor_cpsb;
                    lobjRegistro.sia_maxeve_cpsb = (Decimal)tobjModelo.Sia_maxeve_cpsb;
                    lobjRegistro.sia_maxano_cpsb = (Decimal)tobjModelo.Sia_maxano_cpsb;
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
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SIACOPAGCONTRIB: Logica
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TITULO: Copagos y cuotas moderadoras contributivo</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos y cuotas moderadoras en
        /// contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
        /// 260 de 2004, se crearan rangos para cada tipo poblacion especial
        /// </para>
        /// </summary>
        public static bool flgBuscarSiacopagcontrib(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSiacopagcontrib> flsListaSiacopagcontrib(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from siacopagcontrib in _context.Siacopagcontrib
                                      join sianivcontribut in _context.Sianivcontribut on siacopagcontrib.sia_nivcon_ncon equals sianivcontribut.sia_nivcon_ncon into tmsianivcontribut
                                      from ncon in tmsianivcontribut.DefaultIfEmpty()
                                      select new ModeloSiacopagcontrib
                                      {
                                          Sia_codcpo_cpcb = siacopagcontrib.sia_codcpo_cpcb,
                                          Sia_descpo_cpcb = siacopagcontrib.sia_descpo_cpcb,
                                          Sia_tipafi_tafi = siacopagcontrib.sia_tipafi_tafi,
                                          Sia_nivcon_ncon = siacopagcontrib.sia_nivcon_ncon,
                                          Sia_tipcob_cpcb = siacopagcontrib.sia_tipcob_cpcb,
                                          Sia_porapl_cpsb = (Decimal)siacopagcontrib.sia_porapl_cpsb,
                                          Sia_tippor_cpsb = siacopagcontrib.sia_tippor_cpsb,
                                          Sia_maxeve_cpsb = (Decimal)siacopagcontrib.sia_maxeve_cpsb,
                                          Sia_maxano_cpsb = (Decimal)siacopagcontrib.sia_maxano_cpsb,
                                          Sia_descon_ncon = ncon.sia_descon_ncon,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from siacopagcontrib in _context.Siacopagcontrib
                                      join sianivcontribut in _context.Sianivcontribut on siacopagcontrib.sia_nivcon_ncon equals sianivcontribut.sia_nivcon_ncon into tmsianivcontribut
                                      from ncon in tmsianivcontribut.DefaultIfEmpty()
                                      where siacopagcontrib.sia_codcpo_cpcb.Contains(tcrBuscar) || siacopagcontrib.sia_descpo_cpcb.Contains(tcrBuscar)
                                      select new ModeloSiacopagcontrib
                                      {
                                          Sia_codcpo_cpcb = siacopagcontrib.sia_codcpo_cpcb,
                                          Sia_descpo_cpcb = siacopagcontrib.sia_descpo_cpcb,
                                          Sia_tipafi_tafi = siacopagcontrib.sia_tipafi_tafi,
                                          Sia_nivcon_ncon = siacopagcontrib.sia_nivcon_ncon,
                                          Sia_tipcob_cpcb = siacopagcontrib.sia_tipcob_cpcb,
                                          Sia_porapl_cpsb = (Decimal)siacopagcontrib.sia_porapl_cpsb,
                                          Sia_tippor_cpsb = siacopagcontrib.sia_tippor_cpsb,
                                          Sia_maxeve_cpsb = (Decimal)siacopagcontrib.sia_maxeve_cpsb,
                                          Sia_maxano_cpsb = (Decimal)siacopagcontrib.sia_maxano_cpsb,
                                          Sia_descon_ncon = ncon.sia_descon_ncon,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
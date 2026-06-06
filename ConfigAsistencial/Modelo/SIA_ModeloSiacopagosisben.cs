//- MARMOTA-GENCODE: VERSION 2.0 - 27/08/2013 06:26:40 AM
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
    /// Descripcion para la Vista de  la tabla: siacopagosisben
    /// </summary>
    public class ModeloSiacopagosisben : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _sia_codcpo_cpsb;
        private String _sia_descpo_cpsb;
        private String _sia_tipcob_cpcb;
        private String _sia_nivsbn_nsbn;
        private Decimal _sia_porapl_cpsb;
        private String _sia_tippor_cpsb;
        private Decimal _sia_maxeve_cpsb;
        private Decimal _sia_maxano_cpsb;
        private String _sia_dessbn_nsbn;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Sia_codcpo_cpsb: Código rango
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Código rango</para>
        /// <para>NOMBRE: sia_codcpo_cpsb (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único para el registro de rangos de copagos según nivel
        /// sisben
        /// </para>
        /// </summary>
        public String Sia_codcpo_cpsb
        {
            get { return _sia_codcpo_cpsb; }
            set
            {
                if (_sia_codcpo_cpsb == value) return;
                _sia_codcpo_cpsb = value;
                OnPropertyChanged("Sia_codcpo_cpsb");
            }
        }
        #endregion
        #region Sia_descpo_cpsb: Descripción Copago
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Descripción Copago</para>
        /// <para>NOMBRE: sia_descpo_cpsb (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del porcentaje copago aplicado
        /// </para>
        /// </summary>
        public String Sia_descpo_cpsb
        {
            get { return _sia_descpo_cpsb; }
            set
            {
                if (_sia_descpo_cpsb == value) return;
                _sia_descpo_cpsb = value;
                OnPropertyChanged("Sia_descpo_cpsb");
            }
        }
        #endregion
        #region Sia_tipcob_cpcb: Tipo de Cobro
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Tipo de Cobro</para>
        /// <para>NOMBRE: sia_tipcob_cpcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Sia_nivsbn_nsbn: Nivel Sisben
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos y cuotas moderadoras
        /// según Resolución: 1344 de 2012 BDUA y  Acuerdo 260 de 2004:
        /// 1,2,3,N
        /// </para>
        /// </summary>
        public String Sia_nivsbn_nsbn
        {
            get { return _sia_nivsbn_nsbn; }
            set
            {
                if (_sia_nivsbn_nsbn == value) return;
                _sia_nivsbn_nsbn = value;
                OnPropertyChanged("Sia_nivsbn_nsbn");
            }
        }
        #endregion
        #region Sia_porapl_cpsb: Porcentaje copago
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Porcentaje copago</para>
        /// <para>NOMBRE: sia_porapl_cpsb (decimal:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de aplicación del copago
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
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Tipo Porcentaje aplicación</para>
        /// <para>NOMBRE: sia_tippor_cpsb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje evento</para>
        /// <para>NOMBRE: sia_maxeve_cpsb (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje año</para>
        /// <para>NOMBRE: sia_maxano_cpsb (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sia_dessbn_nsbn: Descripción nivel sisben
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Descripción nivel sisben</para>
        /// <para>NOMBRE: sia_dessbn_nsbn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel sisben
        /// </para>
        /// </summary>
        public String Sia_dessbn_nsbn
        {
            get { return _sia_dessbn_nsbn; }
            set
            {
                if (_sia_dessbn_nsbn == value) return;
                _sia_dessbn_nsbn = value;
                OnPropertyChanged("Sia_dessbn_nsbn");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSiacopagosisben tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFsiacopagosisben
                {
                    #region cargar Registro
                    sia_codcpo_cpsb = tobjModelo.Sia_codcpo_cpsb,
                    sia_descpo_cpsb = tobjModelo.Sia_descpo_cpsb,
                    sia_tipcob_cpcb = tobjModelo.Sia_tipcob_cpcb,
                    sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn,
                    sia_porapl_cpsb = tobjModelo.Sia_porapl_cpsb,
                    sia_tippor_cpsb = tobjModelo.Sia_tippor_cpsb,
                    sia_maxeve_cpsb = tobjModelo.Sia_maxeve_cpsb,
                    sia_maxano_cpsb = tobjModelo.Sia_maxano_cpsb,
                    #endregion
                };
                lcrCodigoGen = lobjRegistro.sia_codcpo_cpsb;
                _context.AddToSiacopagosisben(lobjRegistro);
                _context.SaveChanges();
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSiacopagosisben tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tobjModelo.Sia_codcpo_cpsb);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sia_codcpo_cpsb = tobjModelo.Sia_codcpo_cpsb;
                    lobjRegistro.sia_descpo_cpsb = tobjModelo.Sia_descpo_cpsb;
                    lobjRegistro.sia_tipcob_cpcb = tobjModelo.Sia_tipcob_cpcb;
                    lobjRegistro.sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn;
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
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SIACOPAGOSISBEN: Logica
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TITULO: Copagos y cuotas moderadoras Sisben</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos a subsidiados con nivel
        /// sisben  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260
        /// de 2004 los niveles son: 1,2,3,N   para cada uno aplica un
        /// rango
        /// </para>
        /// </summary>
        public static bool flgBuscarSiacopagosisben(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSiacopagosisben> flsListaSiacopagosisben(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from siacopagosisben in _context.Siacopagosisben
                                      join sianivelsisben in _context.Sianivelsisben on siacopagosisben.sia_nivsbn_nsbn equals sianivelsisben.sia_nivsbn_nsbn into tmsianivelsisben
                                      from nsbn in tmsianivelsisben.DefaultIfEmpty()
                                      select new ModeloSiacopagosisben
                                      {
                                          Sia_codcpo_cpsb = siacopagosisben.sia_codcpo_cpsb,
                                          Sia_descpo_cpsb = siacopagosisben.sia_descpo_cpsb,
                                          Sia_tipcob_cpcb = siacopagosisben.sia_tipcob_cpcb,
                                          Sia_nivsbn_nsbn = siacopagosisben.sia_nivsbn_nsbn,
                                          Sia_porapl_cpsb = (Decimal)siacopagosisben.sia_porapl_cpsb,
                                          Sia_tippor_cpsb = siacopagosisben.sia_tippor_cpsb,
                                          Sia_maxeve_cpsb = (Decimal)siacopagosisben.sia_maxeve_cpsb,
                                          Sia_maxano_cpsb = (Decimal)siacopagosisben.sia_maxano_cpsb,
                                          Sia_dessbn_nsbn = nsbn.sia_dessbn_nsbn,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from siacopagosisben in _context.Siacopagosisben
                                      join sianivelsisben in _context.Sianivelsisben on siacopagosisben.sia_nivsbn_nsbn equals sianivelsisben.sia_nivsbn_nsbn into tmsianivelsisben
                                      from nsbn in tmsianivelsisben.DefaultIfEmpty()
                                      where siacopagosisben.sia_codcpo_cpsb.Contains(tcrBuscar) || siacopagosisben.sia_descpo_cpsb.Contains(tcrBuscar)
                                      select new ModeloSiacopagosisben
                                      {
                                          Sia_codcpo_cpsb = siacopagosisben.sia_codcpo_cpsb,
                                          Sia_descpo_cpsb = siacopagosisben.sia_descpo_cpsb,
                                          Sia_tipcob_cpcb = siacopagosisben.sia_tipcob_cpcb,
                                          Sia_nivsbn_nsbn = siacopagosisben.sia_nivsbn_nsbn,
                                          Sia_porapl_cpsb = (Decimal)siacopagosisben.sia_porapl_cpsb,
                                          Sia_tippor_cpsb = siacopagosisben.sia_tippor_cpsb,
                                          Sia_maxeve_cpsb = (Decimal)siacopagosisben.sia_maxeve_cpsb,
                                          Sia_maxano_cpsb = (Decimal)siacopagosisben.sia_maxano_cpsb,
                                          Sia_dessbn_nsbn = nsbn.sia_dessbn_nsbn,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
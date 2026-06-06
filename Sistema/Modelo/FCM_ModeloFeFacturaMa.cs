//- MARMOTA-GENCODE: VERSION 2.0 - 10/08/2020 05:00:32 PM
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
using Sistema.Dian;
using static Sistema.Dian.Global;

namespace Sistema.Modelo
{
    /// <summary>
    /// Tabla: fcmfemaesfactefma Maestro para guardar facturacion eletronica proveniente de los diferentes modulos del sistema
    /// </summary>
    public class ModeloFeFacturaMa : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_mfac: Código Único registro
        private String _fcm_secreg_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico facturada-Nota Credito-Nota Debito (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfac
        {
            get { return _fcm_secreg_mfac; }
            set
            {
                if (_fcm_secreg_mfac == value) return;
                _fcm_secreg_mfac = value;
                OnPropertyChanged("Fcm_secreg_mfac");
            }
        }
        #endregion
        #region Fcm_secraz_fcem: Razon social Empresa
        private string _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public string Fcm_secraz_fcem
        {
            get { return _fcm_secraz_fcem; }
            set
            {
                if (_fcm_secraz_fcem == value) return;
                _fcm_secraz_fcem = value;
                OnPropertyChanged("Fcm_secraz_fcem");
            }
        }
        #endregion
        #region Fcm_numfac_mfac: Numero Factura
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de factura generada /Invoice/cbc:ID - Número de documento:
        /// Número de factura o factura cambiaria. Incluye prefijo + consecutivo
        /// de factura autorizados por la DIAN
        /// </para>
        /// </summary>
        public String Fcm_numfac_mfac
        {
            get { return _fcm_numfac_mfac; }
            set
            {
                if (_fcm_numfac_mfac == value) return;
                _fcm_numfac_mfac = value;
                OnPropertyChanged("Fcm_numfac_mfac");
            }
        }
        #endregion
        #region Fcm_fecfac_mfac: Fecha factura
        private DateTime _fcm_fecfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfac_mfac
        {
            get { return _fcm_fecfac_mfac; }
            set
            {
                if (_fcm_fecfac_mfac == value) return;
                _fcm_fecfac_mfac = value;
                OnPropertyChanged("Fcm_fecfac_mfac");
            }
        }
        #endregion
        #region Fcm_horfac_mfac: Hora emision factura
        private Decimal _fcm_horfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Hora emision factura</para>
        /// <para>NOMBRE: fcm_horfac_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Hora emision de la factura
        /// </para>
        /// </summary>
        public Decimal Fcm_horfac_mfac
        {
            get { return _fcm_horfac_mfac; }
            set
            {
                if (_fcm_horfac_mfac == value) return;
                _fcm_horfac_mfac = value;
                OnPropertyChanged("Fcm_horfac_mfac");
            }
        }
        #endregion
        #region Fcm_typdoc_fctd: Tipo documento
        private String _fcm_typdoc_fctd;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfetipodocument</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: fcm_typdoc_fctd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica
        /// de Venta 02=Factura electrónica venta-xportación 91=Nota Credito
        /// 92=Nota Debito y otros
        /// </para>
        /// </summary>
        public String Fcm_typdoc_fctd
        {
            get { return _fcm_typdoc_fctd; }
            set
            {
                if (_fcm_typdoc_fctd == value) return;
                _fcm_typdoc_fctd = value;
                OnPropertyChanged("Fcm_typdoc_fctd");
            }
        }
        #endregion
        #region Fcm_notdoc_mfac: Nota textual
        private String _fcm_notdoc_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Nota textual</para>
        /// <para>NOMBRE: fcm_notdoc_mfac (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Nota Textual del documento
        /// </para>
        /// </summary>
        public String Fcm_notdoc_mfac
        {
            get { return _fcm_notdoc_mfac; }
            set
            {
                if (_fcm_notdoc_mfac == value) return;
                _fcm_notdoc_mfac = value;
                OnPropertyChanged("Fcm_notdoc_mfac");
            }
        }
        #endregion
        #region Fcm_forpag_mfac: Forma de pago
        private String _fcm_forpag_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Forma de pago</para>
        /// <para>NOMBRE: fcm_forpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Forma de pago: 1=Contado 2=Crédito
        /// </para>
        /// </summary>
        public String Fcm_forpag_mfac
        {
            get { return _fcm_forpag_mfac; }
            set
            {
                if (_fcm_forpag_mfac == value) return;
                _fcm_forpag_mfac = value;
                OnPropertyChanged("Fcm_forpag_mfac");
            }
        }
        #endregion
        #region Fcm_facori_mfac: Origen gestion de la factura
        private String _fcm_facori_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Forma de pago</para>
        /// <para>NOMBRE: Fcm_facori_mfac (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:Origen gestion de la factura: 01=Desde Gestion Cartera (cuenta de cobro) 
        /// 02=Desde Facturacion Ventas (punto pos) 03=Desde Facturacion Medica</para>
        /// </summary>
        public String Fcm_facori_mfac
        {
            get { return _fcm_facori_mfac; }
            set
            {
                if (_fcm_facori_mfac == value) return;
                _fcm_facori_mfac = value;
                OnPropertyChanged("Fcm_facori_mfac");
            }
        }
        #endregion
        #region Fcm_secres_srfa: Codigo Resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico  en el sistema (maestro de resoluciones para
        /// rangos de facturacion DIAN ) para referenciar de la resolución
        /// Dian
        /// </para>
        /// </summary>
        public String Fcm_secres_srfa
        {
            get { return _fcm_secres_srfa; }
            set
            {
                if (_fcm_secres_srfa == value) return;
                _fcm_secres_srfa = value;
                OnPropertyChanged("Fcm_secres_srfa");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión o del registro de atencion ambulatoria
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public String Cto_seccon_cont
        {
            get { return _cto_seccon_cont; }
            set
            {
                if (_cto_seccon_cont == value) return;
                _cto_seccon_cont = value;
                OnPropertyChanged("Cto_seccon_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public String Sia_codeps_teps
        {
            get { return _sia_codeps_teps; }
            set
            {
                if (_sia_codeps_teps == value) return;
                _sia_codeps_teps = value;
                OnPropertyChanged("Sia_codeps_teps");
            }
        }
        #endregion
        #region Sis_idterc_sitr: Código tercero (contable)
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public String Sis_idterc_sitr
        {
            get { return _sis_idterc_sitr; }
            set
            {
                if (_sis_idterc_sitr == value) return;
                _sis_idterc_sitr = value;
                OnPropertyChanged("Sis_idterc_sitr");
            }
        }
        #endregion
        #region Fcm_sercre_mfac: Secuencial Nota Credito
        private String _fcm_sercre_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Secuencial Nota Credito</para>
        /// <para>NOMBRE: fcm_sercre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Secuencial unico Documento Factura o  Documento Nota Credito 
        /// de referencia, por la cual se genera este documento </para>
        /// </summary>
        public String Fcm_sercre_mfac
        {
            get { return _fcm_sercre_mfac; }
            set
            {
                if (_fcm_sercre_mfac == value) return;
                _fcm_sercre_mfac = value;
                OnPropertyChanged("Fcm_sercre_mfac");
            }
        }
        #endregion
        #region Fcm_idrcre_mfac: Referencia Notas Credito
        private String _fcm_idrcre_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: fcm_idrcre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Opcional cuando el documento es factura se referencia la nota crédito, 
        ///  se referencia numero de factura cuando este documento es nota credito (obligatorio), 
        ///  Se debe diligenciar únicamente cuando la FE se origina a partir 
        /// de la corrección ajuste que se da mediante un Nota Crédito</para>
        /// </summary>
        public String Fcm_idrcre_mfac
        {
            get { return _fcm_idrcre_mfac; }
            set
            {
                if (_fcm_idrcre_mfac == value) return;
                _fcm_idrcre_mfac = value;
                OnPropertyChanged("Fcm_idrcre_mfac");
            }
        }
        #endregion
        #region Fcm_serdeb_mfac: Secuencial Nota Debito
        private String _fcm_serdeb_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Secuencial Nota Debito</para>
        /// <para>NOMBRE: fcm_serdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION: Secuencial unico Documento Factura o  Documento Nota Debito 
        /// de referencia, por la cual se genera este documento </para>
        /// </summary>
        public String Fcm_serdeb_mfac
        {
            get { return _fcm_serdeb_mfac; }
            set
            {
                if (_fcm_serdeb_mfac == value) return;
                _fcm_serdeb_mfac = value;
                OnPropertyChanged("Fcm_serdeb_mfac");
            }
        }
        #endregion
        #region Fcm_idrdeb_mfac: Referencia Notas Debito
        private String _fcm_idrdeb_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: fcm_idrdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION: Opcional cuando el documento es factura se referencia la nota debito,
        ///  se referencia numero de factura cuando este documento es nota debito (obligatorio), 
        ///  Se debe diligenciar únicamente cuando la FE se origina a partir 
        /// de la corrección ajuste que se da mediante un Nota Debito</para>
        /// </summary>
        public String Fcm_idrdeb_mfac
        {
            get { return _fcm_idrdeb_mfac; }
            set
            {
                if (_fcm_idrdeb_mfac == value) return;
                _fcm_idrdeb_mfac = value;
                OnPropertyChanged("Fcm_idrdeb_mfac");
            }
        }
        #endregion
        #region Fcm_valbsi_dfac: Valor Base impuestos
        private decimal _fcm_valbsi_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: fcm_valbsi_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION: Valor de la base Imponible (base para el calculo de impuesto) </para>
        /// </summary>
        public decimal Fcm_valbsi_dfac
        {
            get { return _fcm_valbsi_dfac; }
            set
            {
                if (_fcm_valbsi_dfac == value) return;
                _fcm_valbsi_dfac = value;
                OnPropertyChanged("Fcm_valbsi_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        private decimal _fcm_valiva_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Valor del IVA aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valiva_dfac
        {
            get { return _fcm_valiva_dfac; }
            set
            {
                if (_fcm_valiva_dfac == value) return;
                _fcm_valiva_dfac = value;
                OnPropertyChanged("Fcm_valiva_dfac");
            }
        }
        #endregion
        #region Fcm_valicd_dfac: Valor IC Impuesto consumo
        private decimal _fcm_valicd_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: fcm_valicd_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Valor del IC - Impuesto de Industria, Comercio y Aviso
        /// </para>
        /// </summary>
        public decimal Fcm_valicd_dfac
        {
            get { return _fcm_valicd_dfac; }
            set
            {
                if (_fcm_valicd_dfac == value) return;
                _fcm_valicd_dfac = value;
                OnPropertyChanged("Fcm_valicd_dfac");
            }
        }
        #endregion
        #region Fcm_valica_dfac: Valor ICA
        private decimal _fcm_valica_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: fcm_valica_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Valor ICA Impuesto Nacional al Consumo
        /// </para>
        /// </summary>
        public decimal Fcm_valica_dfac
        {
            get { return _fcm_valica_dfac; }
            set
            {
                if (_fcm_valica_dfac == value) return;
                _fcm_valica_dfac = value;
                OnPropertyChanged("Fcm_valica_dfac");
            }
        }
        #endregion
        #region Fcm_valinc_dfac: Valor INC - Impuesto Nacional Consumo
        private decimal _fcm_valinc_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INC - Impuesto Nacional Consumo</para>
        /// <para>NOMBRE: fcm_valinc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION: Valor INC Impuesto Nacional al Consumo</para>
        /// </summary>
        public decimal Fcm_valinc_dfac
        {
            get { return _fcm_valinc_dfac; }
            set
            {
                if (_fcm_valinc_dfac == value) return;
                _fcm_valinc_dfac = value;
                OnPropertyChanged("Fcm_valinc_dfac");
            }
        }
        #endregion
        #region Fcm_valrti_dfac: Valor RetVA Retención sobre el IVA
        private decimal _fcm_valrti_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: fcm_valrti_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor RetVA Retención sobre el IVA
        /// </para>
        /// </summary>
        public decimal Fcm_valrti_dfac
        {
            get { return _fcm_valrti_dfac; }
            set
            {
                if (_fcm_valrti_dfac == value) return;
                _fcm_valrti_dfac = value;
                OnPropertyChanged("Fcm_valrti_dfac");
            }
        }
        #endregion
        #region Fcm_valrtf_dfac: Valor ReteFuente
        private decimal _fcm_valrtf_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: fcm_valrtf_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor ReteFuente (reteción en la fuente)
        /// </para>
        /// </summary>
        public decimal Fcm_valrtf_dfac
        {
            get { return _fcm_valrtf_dfac; }
            set
            {
                if (_fcm_valrtf_dfac == value) return;
                _fcm_valrtf_dfac = value;
                OnPropertyChanged("Fcm_valrtf_dfac");
            }
        }
        #endregion
        #region Fcm_valrtc_dfac: Valor ReteICA
        private decimal _fcm_valrtc_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: fcm_valrtc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Valor del ReteICA aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valrtc_dfac
        {
            get { return _fcm_valrtc_dfac; }
            set
            {
                if (_fcm_valrtc_dfac == value) return;
                _fcm_valrtc_dfac = value;
                OnPropertyChanged("Fcm_valrtc_dfac");
            }
        }
        #endregion
        #region Fcm_valcre_dfac: VAaor RedCREE
        private decimal _fcm_valcre_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: VAaor RedCREE</para>
        /// <para>NOMBRE: fcm_valcre_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Valor del ReteCRE aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valcre_dfac
        {
            get { return _fcm_valcre_dfac; }
            set
            {
                if (_fcm_valcre_dfac == value) return;
                _fcm_valcre_dfac = value;
                OnPropertyChanged("Fcm_valcre_dfac");
            }
        }
        #endregion
        #region Fcm_valfth_dfac: Valor FtoHorticultura
        private decimal _fcm_valfth_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: fcm_valfth_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Valor del FtoHorticultura aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valfth_dfac
        {
            get { return _fcm_valfth_dfac; }
            set
            {
                if (_fcm_valfth_dfac == value) return;
                _fcm_valfth_dfac = value;
                OnPropertyChanged("Fcm_valfth_dfac");
            }
        }
        #endregion
        #region Fcm_valtim_dfac: Valor Timbre
        private decimal _fcm_valtim_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: fcm_valtim_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Valor del Timbre aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valtim_dfac
        {
            get { return _fcm_valtim_dfac; }
            set
            {
                if (_fcm_valtim_dfac == value) return;
                _fcm_valtim_dfac = value;
                OnPropertyChanged("Fcm_valtim_dfac");
            }
        }
        #endregion
        #region Fcm_valbol_dfac: Valor Impuesto Bolsas
        private decimal _fcm_valbol_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: fcm_valbol_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Valor Impuesto Bolsas aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valbol_dfac
        {
            get { return _fcm_valbol_dfac; }
            set
            {
                if (_fcm_valbol_dfac == value) return;
                _fcm_valbol_dfac = value;
                OnPropertyChanged("Fcm_valbol_dfac");
            }
        }
        #endregion
        #region Fcm_valicr_dfac: Valor INCarbono
        private decimal _fcm_valicr_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: fcm_valicr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Valor del IVA aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valicr_dfac
        {
            get { return _fcm_valicr_dfac; }
            set
            {
                if (_fcm_valicr_dfac == value) return;
                _fcm_valicr_dfac = value;
                OnPropertyChanged("Fcm_valicr_dfac");
            }
        }
        #endregion
        #region Fcm_valicb_dfac: Valor INCombustibles
        private decimal _fcm_valicb_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: fcm_valicb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Valor del INCombustibles aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valicb_dfac
        {
            get { return _fcm_valicb_dfac; }
            set
            {
                if (_fcm_valicb_dfac == value) return;
                _fcm_valicb_dfac = value;
                OnPropertyChanged("Fcm_valicb_dfac");
            }
        }
        #endregion
        #region Fcm_valscb_dfac: Valor Sobretasa Combustibles
        private decimal _fcm_valscb_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_valscb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Valor de Sobretasa Combustibles aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valscb_dfac
        {
            get { return _fcm_valscb_dfac; }
            set
            {
                if (_fcm_valscb_dfac == value) return;
                _fcm_valscb_dfac = value;
                OnPropertyChanged("Fcm_valscb_dfac");
            }
        }
        #endregion
        #region Fcm_valsco_dfac: Valor Sordicom
        private decimal _fcm_valsco_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: fcm_valsco_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Valor del Sordicom aplicado
        /// </para>
        /// </summary>
        public decimal Fcm_valsco_dfac
        {
            get { return _fcm_valsco_dfac; }
            set
            {
                if (_fcm_valsco_dfac == value) return;
                _fcm_valsco_dfac = value;
                OnPropertyChanged("Fcm_valsco_dfac");
            }
        }
        #endregion
        #region Fcm_valftr_dfac: Figura tributaria aplicada
        private decimal _fcm_valftr_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Figura tributaria aplicada</para>
        /// <para>NOMBRE: fcm_valftr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Valor figura tributaria aplicada
        /// </para>
        /// </summary>
        public decimal Fcm_valftr_dfac
        {
            get { return _fcm_valftr_dfac; }
            set
            {
                if (_fcm_valftr_dfac == value) return;
                _fcm_valftr_dfac = value;
                OnPropertyChanged("Fcm_valftr_dfac");
            }
        }
        #endregion
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private decimal _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public decimal Fcm_pordes_dfac
        {
            get { return _fcm_pordes_dfac; }
            set
            {
                if (_fcm_pordes_dfac == value) return;
                _fcm_pordes_dfac = value;
                OnPropertyChanged("Fcm_pordes_dfac");
            }
        }
        #endregion
        #region Fcm_valdes_dfac: Valor del descuento
        private decimal _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public decimal Fcm_valdes_dfac
        {
            get { return _fcm_valdes_dfac; }
            set
            {
                if (_fcm_valdes_dfac == value) return;
                _fcm_valdes_dfac = value;
                OnPropertyChanged("Fcm_valdes_dfac");
            }
        }
        #endregion
        #region Fcm_valcpa_dfac: Valor copago
        private decimal _fcm_valcpa_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public decimal Fcm_valcpa_dfac
        {
            get { return _fcm_valcpa_dfac; }
            set
            {
                if (_fcm_valcpa_dfac == value) return;
                _fcm_valcpa_dfac = value;
                OnPropertyChanged("Fcm_valcpa_dfac");
            }
        }
        #endregion
        #region Fcm_valcmo_dfac: Valor cuota moderadora
        private decimal _fcm_valcmo_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public decimal Fcm_valcmo_dfac
        {
            get { return _fcm_valcmo_dfac; }
            set
            {
                if (_fcm_valcmo_dfac == value) return;
                _fcm_valcmo_dfac = value;
                OnPropertyChanged("Fcm_valcmo_dfac");
            }
        }
        #endregion
        #region Fcm_valusu_dfac: Valor cargo al usuario
        private decimal _fcm_valusu_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public decimal Fcm_valusu_dfac
        {
            get { return _fcm_valusu_dfac; }
            set
            {
                if (_fcm_valusu_dfac == value) return;
                _fcm_valusu_dfac = value;
                OnPropertyChanged("Fcm_valusu_dfac");
            }
        }
        #endregion
        #region Fcm_valbru_dfac: Valor bruto factura
        private decimal _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public decimal Fcm_valbru_dfac
        {
            get { return _fcm_valbru_dfac; }
            set
            {
                if (_fcm_valbru_dfac == value) return;
                _fcm_valbru_dfac = value;
                OnPropertyChanged("Fcm_valbru_dfac");
            }
        }
        #endregion
        #region Fcm_valsub_dfac: Valor subtotal servicio
        private decimal _fcm_valsub_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public decimal Fcm_valsub_dfac
        {
            get { return _fcm_valsub_dfac; }
            set
            {
                if (_fcm_valsub_dfac == value) return;
                _fcm_valsub_dfac = value;
                OnPropertyChanged("Fcm_valsub_dfac");
            }
        }
        #endregion
        #region Fcm_valfac_dfac: Valor total facturado
        private decimal _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo impuestos (IVA
        /// y otros impuestos)  y con las anteriores  valor a entidad deducciones:FCM
        /// _VALSUB_DFAC+IMPUESTOS
        /// </para>
        /// </summary>
        public decimal Fcm_valfac_dfac
        {
            get { return _fcm_valfac_dfac; }
            set
            {
                if (_fcm_valfac_dfac == value) return;
                _fcm_valfac_dfac = value;
                OnPropertyChanged("Fcm_valfac_dfac");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor en efectivo
        private decimal _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public decimal Fcm_valref_dfac
        {
            get { return _fcm_valref_dfac; }
            set
            {
                if (_fcm_valref_dfac == value) return;
                _fcm_valref_dfac = value;
                OnPropertyChanged("Fcm_valref_dfac");
            }
        }
        #endregion
        #region Fcm_valefe_dfac: Valor efectivo final
        private decimal _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: fcm_valefe_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public decimal Fcm_valefe_dfac
        {
            get { return _fcm_valefe_dfac; }
            set
            {
                if (_fcm_valefe_dfac == value) return;
                _fcm_valefe_dfac = value;
                OnPropertyChanged("Fcm_valefe_dfac");
            }
        }
        #endregion
        #region Fcm_idcufe_mfac: Codigo CUFE - CUDE
        private String _fcm_idcufe_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo CUFE - CUDE</para>
        /// <para>NOMBRE: fcm_idcufe_mfac (char:110)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION: Numero unico CUFE o CUDE según el tipo de documento generado</para>
        /// </summary>
        public String Fcm_idcufe_mfac
        {
            get { return _fcm_idcufe_mfac; }
            set
            {
                if (_fcm_idcufe_mfac == value) return;
                _fcm_idcufe_mfac = value;
                OnPropertyChanged("Fcm_idcufe_mfac");
            }
        }
        #endregion
        #region Fcm_diafec_mfac: Fecha radicacion dian
        private DateTime _fcm_diafec_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha radicacion dian</para>
        /// <para>NOMBRE: fcm_diafec_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION: Fecha radicacion factura en Dian  y es recibida correcta en
        /// la validacion
        /// </para>
        /// </summary>
        public DateTime Fcm_diafec_mfac
        {
            get { return _fcm_diafec_mfac; }
            set
            {
                if (_fcm_diafec_mfac == value) return;
                _fcm_diafec_mfac = value;
                OnPropertyChanged("Fcm_diafec_mfac");
            }
        }
        #endregion
        #region Fcm_diahor_mfac: Hora radicacion dian
        private Decimal _fcm_diahor_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Hora radicacion dian</para>
        /// <para>NOMBRE: fcm_diahor_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Hora radicacion factura en Dian y es recibida correcta en validacion
        /// </para>
        /// </summary>
        public Decimal Fcm_diahor_mfac
        {
            get { return _fcm_diahor_mfac; }
            set
            {
                if (_fcm_diahor_mfac == value) return;
                _fcm_diahor_mfac = value;
                OnPropertyChanged("Fcm_diahor_mfac");
            }
        }
        #endregion
        #region Fcm_codest_fcws: Estado gestion Dian
        private String _fcm_codest_fcws;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresdian</para>
        /// <para>CAMPO: Estado gestion Dian</para>
        /// <para>NOMBRE: fcm_codest_fcws (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION Estado gestion WS DIAN:</para>
        /// <para>C01=El Servicio DIAN no respondio</para>
        /// <para>C02=Error de conexión Internet</para>
        /// <para>P01=Sin Enviar a DIAN</para>
        /// <para>R01=Aceptada con Exito  en DIAN</para>
        /// <para>R02=Rechazada DIAN errores en Validación</para>
        /// <para>R03=Enviado y Pendiente validación en DIAN</para>
        /// </summary>
        public String Fcm_codest_fcws
        {
            get { return _fcm_codest_fcws; }
            set
            {
                if (_fcm_codest_fcws == value) return;
                _fcm_codest_fcws = value;
                OnPropertyChanged("Fcm_codest_fcws");
            }
        }
        #endregion
        #region Fcm_errore_mfac: Lista de Errores
        private String _fcm_errore_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Lista de Errores</para>
        /// <para>NOMBRE: fcm_errore_mfac (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION: Listado de errores en validación Dian</para>
        /// </summary>
        public String Fcm_errore_mfac
        {
            get { return _fcm_errore_mfac; }
            set
            {
                if (_fcm_errore_mfac == value) return;
                _fcm_errore_mfac = value;
                OnPropertyChanged("Fcm_errore_mfac");
            }
        }
        #endregion
        #region Fcm_trakid_mfac: Codigo TrackId
        private String _fcm_trakid_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo TrackId</para>
        /// <para>NOMBRE: fcm_trakid_mfac (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// TrackId: Con el trackId obtenido en el método, se consume otro
        /// método de consulta para obtener el resultado de las validaciones
        /// posteriores realizadas a la factura
        /// </para>
        /// </summary>
        public String Fcm_trakid_mfac
        {
            get { return _fcm_trakid_mfac; }
            set
            {
                if (_fcm_trakid_mfac == value) return;
                _fcm_trakid_mfac = value;
                OnPropertyChanged("Fcm_trakid_mfac");
            }
        }
        #endregion
        #region Fcm_nomarc_mfac: Nombre fisico archivo
        private String _fcm_nomarc_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Nombre fisico archivo</para>
        /// <para>NOMBRE: fcm_nomarc_mfac (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Nombre del archivo fisico sin ninguna extension  generado y
        /// enviado a la DIAN
        /// </para>
        /// </summary>
        public String Fcm_nomarc_mfac
        {
            get { return _fcm_nomarc_mfac; }
            set
            {
                if (_fcm_nomarc_mfac == value) return;
                _fcm_nomarc_mfac = value;
                OnPropertyChanged("Fcm_nomarc_mfac");
            }
        }
        #endregion
        #region Fcm_secrad_mfac: Secuencia de envio DIAN
        private int _fcm_secrad_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Secuencia de envio DIAN</para>
        /// <para>NOMBRE: fcm_secrad_mfac (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del radicado, generado por el contador del
        /// sistema, corresponde al numero secuencial de envios a la DIAN
        /// </para>
        /// </summary>
        public int Fcm_secrad_mfac
        {
            get { return _fcm_secrad_mfac; }
            set
            {
                if (_fcm_secrad_mfac == value) return;
                _fcm_secrad_mfac = value;
                OnPropertyChanged("Fcm_secrad_mfac");
            }
        }
        #endregion
        #region Fcm_adqfec_mfac: Fecha envio adquirente
        private DateTime _fcm_adqfec_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha envio adquirente</para>
        /// <para>NOMBRE: fcm_adqfec_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        ///Fecha envio al adquirente a travez de correo electronico
        /// </para>
        /// </summary>
        public DateTime Fcm_adqfec_mfac
        {
            get { return _fcm_adqfec_mfac; }
            set
            {
                if (_fcm_adqfec_mfac == value) return;
                _fcm_adqfec_mfac = value;
                OnPropertyChanged("Fcm_adqfec_mfac");
            }
        }
        #endregion
        #region Fcm_adqhor_mfac: Hora envio adquirente
        private Decimal _fcm_adqhor_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Hora envio adquirente</para>
        /// <para>NOMBRE: fcm_adqhor_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        ///Hora envio adquirente a travez de correo electronico
        /// </para>
        /// </summary>
        public Decimal Fcm_adqhor_mfac
        {
            get { return _fcm_adqhor_mfac; }
            set
            {
                if (_fcm_adqhor_mfac == value) return;
                _fcm_adqhor_mfac = value;
                OnPropertyChanged("Fcm_adqhor_mfac");
            }
        }
        #endregion
        #region Fcm_codest_fcaq: Estado Adquirente
        private String _fcm_codest_fcaq;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresadqu</para>
        /// <para>CAMPO: Estado Adquirente</para>
        /// <para>NOMBRE: fcm_codest_fcaq (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Estado envio al adquirente: A01=Pendiente por enviar al Adquirente
        /// A02=Enviada al Adquirente por correo
        /// </para>
        /// </summary>
        public String Fcm_codest_fcaq
        {
            get { return _fcm_codest_fcaq; }
            set
            {
                if (_fcm_codest_fcaq == value) return;
                _fcm_codest_fcaq = value;
                OnPropertyChanged("Fcm_codest_fcaq");
            }
        }
        #endregion
        #region Fcm_metpag_mfac: Metodo de pago
        private String _fcm_metpag_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Metodo de pago</para>
        /// <para>NOMBRE: fcm_metpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION: Metodo de pago 1=Contado 2=Credito </para>
        /// </summary>
        public String Fcm_metpag_mfac
        {
            get { return _fcm_metpag_mfac; }
            set
            {
                if (_fcm_metpag_mfac == value) return;
                _fcm_metpag_mfac = value;
                OnPropertyChanged("Fcm_metpag_mfac");
            }
        }
        #endregion
        #region Fcm_codmpg_fcmp: Medio de pago
        private String _fcm_codmpg_fcmp;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemediosdepago</para>
        /// <para>CAMPO: Medio de pago</para>
        /// <para>NOMBRE: fcm_codmpg_fcmp (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// FAN02: Codigo secuencial medios de pago según cuadro  No:
        /// 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode: 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo
        /// </para>
        /// </summary>
        public String Fcm_codmpg_fcmp
        {
            get { return _fcm_codmpg_fcmp; }
            set
            {
                if (_fcm_codmpg_fcmp == value) return;
                _fcm_codmpg_fcmp = value;
                OnPropertyChanged("Fcm_codmpg_fcmp");
            }
        }
        #endregion
        #region Fcm_fecven_mfac: Fecha Vencimiento
        private DateTime _fcm_fecven_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha Vencimiento</para>
        /// <para>NOMBRE: fcm_fecven_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento factura contada desde el momento que fue
        /// generado el secuencial factrua Dian
        /// </para>
        /// </summary>
        public DateTime Fcm_fecven_mfac
        {
            get { return _fcm_fecven_mfac; }
            set
            {
                if (_fcm_fecven_mfac == value) return;
                _fcm_fecven_mfac = value;
                OnPropertyChanged("Fcm_fecven_mfac");
            }
        }
        #endregion
        #region Fcm_idepag_fcmp: Identificador del pago
        private String _fcm_idepag_fcmp;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemediosdepago</para>
        /// <para>CAMPO: Identificador del pago</para>
        /// <para>NOMBRE: fcm_idepag_fcmp (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION: FAN05: Identificador del pago
        /// </para>
        /// </summary>
        public String Fcm_idepag_fcmp
        {
            get { return _fcm_idepag_fcmp; }
            set
            {
                if (_fcm_idepag_fcmp == value) return;
                _fcm_idepag_fcmp = value;
                OnPropertyChanged("Fcm_idepag_fcmp");
            }
        }
        #endregion
        #region Fcm_fecanu_mfac: Fecha anulación
        private DateTime _fcm_fecanu_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha anulación</para>
        /// <para>NOMBRE: fcm_fecanu_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha en que la cual se anulo la factura confirmada (estado
        /// 2)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecanu_mfac
        {
            get { return _fcm_fecanu_mfac; }
            set
            {
                if (_fcm_fecanu_mfac == value) return;
                _fcm_fecanu_mfac = value;
                OnPropertyChanged("Fcm_fecanu_mfac");
            }
        }
        #endregion
        #region Fcm_horanu_mfac: Hora anulacion factura
        private Decimal _fcm_horanu_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Hora anulacion factura</para>
        /// <para>NOMBRE: fcm_horanu_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        ///Hora en la cual fue anulada la factura
        /// </para>
        /// </summary>
        public Decimal Fcm_horanu_mfac
        {
            get { return _fcm_horanu_mfac; }
            set
            {
                if (_fcm_horanu_mfac == value) return;
                _fcm_horanu_mfac = value;
                OnPropertyChanged("Fcm_horanu_mfac");
            }
        }
        #endregion
        #region Sys_usuanu_usux: Usuario que anula
        private String _sys_usuanu_usux;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario que anula</para>
        /// <para>NOMBRE: sys_usuanu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Código del factuador  usuario del sistema que que anula
        /// </para>
        /// </summary>
        public String Sys_usuanu_usux
        {
            get { return _sys_usuanu_usux; }
            set
            {
                if (_sys_usuanu_usux == value) return;
                _sys_usuanu_usux = value;
                OnPropertyChanged("Sys_usuanu_usux");
            }
        }
        #endregion
        #region Fcm_notanu_mfac: Motivo anulacion factura
        private String _fcm_notanu_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Motivo anulacion factura</para>
        /// <para>NOMBRE: fcm_notanu_mfac (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Motivo textual por el cual se anula la factura
        /// </para>
        /// </summary>
        public String Fcm_notanu_mfac
        {
            get { return _fcm_notanu_mfac; }
            set
            {
                if (_fcm_notanu_mfac == value) return;
                _fcm_notanu_mfac = value;
                OnPropertyChanged("Fcm_notanu_mfac");
            }
        }
        #endregion
        #region Fcm_algori_mfac: Algoritomo
        private String _fcm_algori_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Algoritomo</para>
        /// <para>NOMBRE: fcm_algori_mfac (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Algoritmo utilizado para generar CUDE o el CUFE  (se usa como
        /// referencia): SHA384 - SHA512 pero  por defecto SHA384
        /// </para>
        /// </summary>
        public String Fcm_algori_mfac
        {
            get { return _fcm_algori_mfac; }
            set
            {
                if (_fcm_algori_mfac == value) return;
                _fcm_algori_mfac = value;
                OnPropertyChanged("Fcm_algori_mfac");
            }
        }
        #endregion
        #region Fcm_conest_mfac: Contador detalles
        private int _fcm_conest_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Contador detalles</para>
        /// <para>NOMBRE: fcm_conest_mfac (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Contador para generar los registros únicos  detalles
        /// </para>
        /// </summary>
        public int Fcm_conest_mfac
        {
            get { return _fcm_conest_mfac; }
            set
            {
                if (_fcm_conest_mfac == value) return;
                _fcm_conest_mfac = value;
                OnPropertyChanged("Fcm_conest_mfac");
            }
        }
        #endregion
        #region Fcm_fecedt_mfac: Fecha ultima modificación
        private DateTime _fcm_fecedt_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: fcm_fecedt_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Fecha ultima modificacion realizada por un usario o facturador
        /// </para>
        /// </summary>
        public DateTime Fcm_fecedt_mfac
        {
            get { return _fcm_fecedt_mfac; }
            set
            {
                if (_fcm_fecedt_mfac == value) return;
                _fcm_fecedt_mfac = value;
                OnPropertyChanged("Fcm_fecedt_mfac");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Código del factuador  usuario del sistema que que realiza la
        /// ultima modificacion
        /// </para>
        /// </summary>
        public String Sys_codusu_usux
        {
            get { return _sys_codusu_usux; }
            set
            {
                if (_sys_codusu_usux == value) return;
                _sys_codusu_usux = value;
                OnPropertyChanged("Sys_codusu_usux");
            }
        }
        #endregion
        #region Fcm_tiprfa_mfac: Tipo registro facturación
        private String _fcm_tiprfa_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Tipo registro facturación</para>
        /// <para>NOMBRE: fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
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
        #region Fcm_estfac_mfac: Estado Factura
        private String _fcm_estfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public String Fcm_estfac_mfac
        {
            get { return _fcm_estfac_mfac; }
            set
            {
                if (_fcm_estfac_mfac == value) return;
                _fcm_estfac_mfac = value;
                OnPropertyChanged("Fcm_estfac_mfac");
            }
        }
        #endregion
        #region Fcm_desres_srfa: Descripción
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota  de la resolucion Dian
        /// </para>
        /// </summary>
        public String Fcm_desres_srfa
        {
            get { return _fcm_desres_srfa; }
            set
            {
                if (_fcm_desres_srfa == value) return;
                _fcm_desres_srfa = value;
                OnPropertyChanged("Fcm_desres_srfa");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: cto_descon_cont (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public String Cto_descon_cont
        {
            get { return _cto_descon_cont; }
            set
            {
                if (_cto_descon_cont == value) return;
                _cto_descon_cont = value;
                OnPropertyChanged("Cto_descon_cont");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
        /// </summary>
        public String Sis_razsoc_sitr
        {
            get { return _sis_razsoc_sitr; }
            set
            {
                if (_sis_razsoc_sitr == value) return;
                _sis_razsoc_sitr = value;
                OnPropertyChanged("Sis_razsoc_sitr");
            }
        }
        #endregion
        #region Fcm_desest_fcws: Descripción estado
        private String _fcm_desest_fcws;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresdian</para>
        /// <para>CAMPO: Descripción estado</para>
        /// <para>NOMBRE: fcm_desest_fcws (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción estado gestion WS Dian
        /// </para>
        /// </summary>
        public String Fcm_desest_fcws
        {
            get { return _fcm_desest_fcws; }
            set
            {
                if (_fcm_desest_fcws == value) return;
                _fcm_desest_fcws = value;
                OnPropertyChanged("Fcm_desest_fcws");
            }
        }
        #endregion
        #region Fcm_desest_fcaq: Descripción estado
        private String _fcm_desest_fcaq;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresadqu</para>
        /// <para>CAMPO: Descripción estado</para>
        /// <para>NOMBRE: fcm_desest_fcaq (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción estado gestion WS Dian
        /// </para>
        /// </summary>
        public String Fcm_desest_fcaq
        {
            get { return _fcm_desest_fcaq; }
            set
            {
                if (_fcm_desest_fcaq == value) return;
                _fcm_desest_fcaq = value;
                OnPropertyChanged("Fcm_desest_fcaq");
            }
        }
        #endregion
        #region Fcm_desmpg_fcmp: Descripcion medio
        private String _fcm_desmpg_fcmp;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemediosdepago</para>
        /// <para>CAMPO: Descripcion medio</para>
        /// <para>NOMBRE: fcm_desmpg_fcmp (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// FAN03: Descripcion medios de pago según  cuadro  No: 6.3.4.2
        /// - Medios de Pago: cbc:PaymentMeansCode
        /// </para>
        /// </summary>
        public String Fcm_desmpg_fcmp
        {
            get { return _fcm_desmpg_fcmp; }
            set
            {
                if (_fcm_desmpg_fcmp == value) return;
                _fcm_desmpg_fcmp = value;
                OnPropertyChanged("Fcm_desmpg_fcmp");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux
        {
            get { return _sys_nomusu_usux; }
            set
            {
                if (_sys_nomusu_usux == value) return;
                _sys_nomusu_usux = value;
                OnPropertyChanged("Sys_nomusu_usux");
            }
        }
        #endregion
        #endregion
        // Datos complementarios del registro
        #region Datos complementarios del registro

        #region lobRegEmpresa: Registro datos de la empresa
        /// <summary>
        /// <para>Registro datos  de la empresa para AccountingSupplierParty</para> 
        /// </summary>
        public ModeloFeRazonSocial lobRegEmpresa;
        #endregion lobRegEmpresa: Registro datos de la empresa>

        #region tmpRegCliente: Registro datos del cliente Adquirente
        /// <summary>
        /// <para>Registro para acceder a los datos completos del cliente o </para> 
        /// <para>adquirente de la factura</para>
        /// </summary>
        public ModeloSismaesterceros lobRegCliente;
        #endregion tmpRegCliente: Datos del Cliente Adquirente>

        #region tmpRegResolDian: Registro Resolucion Dian facturación
        /// <summary>
        /// <para>Registro para acceder a los datos de la resolucion Dian para facturación</para> 
        /// </summary>
        public ModeloResolDianFacturas lobRegResolDian;
        #endregion tmpRegResolDian: Registro Resolucion Dian facturación>

        #region tmpListVenta: Lista de registros tipo detalle ventas de productos 
        /// <summary>
        /// Listado de registros tipo detalle que representan las ventas de la factura
        /// </summary>
        public List<ModeloFeFacturaMd> tmpListVenta;
        #endregion tmpListVenta>

        #endregion Datos complementarios del registro>
        #endregion
        // Metodos
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFeFacturaMa tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMFEMAESFACTEFMA", "FCM", "Maestro de facturas electronicas");
            try
            {
                if (!FlgBuscarFcmfemaesfactefma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmfemaesfactefma
                        {
                            #region cargar Registro
                            fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac,
                            fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_fecfac_mfac = tobjModelo.Fcm_fecfac_mfac,
                            fcm_horfac_mfac = tobjModelo.Fcm_horfac_mfac,
                            fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd,
                            fcm_notdoc_mfac = tobjModelo.Fcm_notdoc_mfac,
                            fcm_forpag_mfac = tobjModelo.Fcm_forpag_mfac,
                            fcm_facori_mfac = tobjModelo.Fcm_facori_mfac,
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            fcm_sercre_mfac = tobjModelo.Fcm_sercre_mfac,
                            fcm_idrcre_mfac = tobjModelo.Fcm_idrcre_mfac,
                            fcm_serdeb_mfac = tobjModelo.Fcm_serdeb_mfac,
                            fcm_idrdeb_mfac = tobjModelo.Fcm_idrdeb_mfac,
                            fcm_valbsi_dfac = tobjModelo.Fcm_valbsi_dfac,
                            fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac,
                            fcm_valicd_dfac = tobjModelo.Fcm_valicd_dfac,
                            fcm_valica_dfac = tobjModelo.Fcm_valica_dfac,
                            fcm_valinc_dfac = tobjModelo.Fcm_valinc_dfac,
                            fcm_valrti_dfac = tobjModelo.Fcm_valrti_dfac,
                            fcm_valrtf_dfac = tobjModelo.Fcm_valrtf_dfac,
                            fcm_valrtc_dfac = tobjModelo.Fcm_valrtc_dfac,
                            fcm_valcre_dfac = tobjModelo.Fcm_valcre_dfac,
                            fcm_valfth_dfac = tobjModelo.Fcm_valfth_dfac,
                            fcm_valtim_dfac = tobjModelo.Fcm_valtim_dfac,
                            fcm_valbol_dfac = tobjModelo.Fcm_valbol_dfac,
                            fcm_valicr_dfac = tobjModelo.Fcm_valicr_dfac,
                            fcm_valicb_dfac = tobjModelo.Fcm_valicb_dfac,
                            fcm_valscb_dfac = tobjModelo.Fcm_valscb_dfac,
                            fcm_valsco_dfac = tobjModelo.Fcm_valsco_dfac,
                            fcm_valftr_dfac = tobjModelo.Fcm_valftr_dfac,
                            fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_valcpa_dfac = tobjModelo.Fcm_valcpa_dfac,
                            fcm_valcmo_dfac = tobjModelo.Fcm_valcmo_dfac,
                            fcm_valusu_dfac = tobjModelo.Fcm_valusu_dfac,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                            fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                            fcm_idcufe_mfac = tobjModelo.Fcm_idcufe_mfac,
                            fcm_diafec_mfac = tobjModelo.Fcm_diafec_mfac,
                            fcm_diahor_mfac = tobjModelo.Fcm_diahor_mfac,
                            fcm_codest_fcws = tobjModelo.Fcm_codest_fcws,
                            fcm_errore_mfac = tobjModelo.Fcm_errore_mfac,
                            fcm_trakid_mfac = tobjModelo.Fcm_trakid_mfac,
                            fcm_nomarc_mfac = tobjModelo.Fcm_nomarc_mfac,
                            fcm_secrad_mfac = tobjModelo.Fcm_secrad_mfac,
                            fcm_adqfec_mfac = tobjModelo.Fcm_adqfec_mfac,
                            fcm_adqhor_mfac = tobjModelo.Fcm_adqhor_mfac,
                            fcm_codest_fcaq = tobjModelo.Fcm_codest_fcaq,
                            fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac,
                            fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp,
                            fcm_fecven_mfac = tobjModelo.Fcm_fecven_mfac,
                            fcm_idepag_fcmp = tobjModelo.Fcm_idepag_fcmp,
                            fcm_fecanu_mfac = tobjModelo.Fcm_fecanu_mfac,
                            fcm_horanu_mfac = tobjModelo.Fcm_horanu_mfac,
                            sys_usuanu_usux = tobjModelo.Sys_usuanu_usux,
                            fcm_notanu_mfac = tobjModelo.Fcm_notanu_mfac,
                            fcm_algori_mfac = tobjModelo.Fcm_algori_mfac,
                            fcm_conest_mfac = tobjModelo.Fcm_conest_mfac,
                            fcm_fecedt_mfac = tobjModelo.Fcm_fecedt_mfac,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac,
                            fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac,
                            #endregion
                        };
                        lobjRegistro.fcm_secreg_mfac = lcrCodigoGen;
                        _context.AddToFcmfemaesfactefma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMFEMAESFACTEFMA': Maestro de facturas electronicas en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Adicionar o Modificar Registro
        /// <summary>
        /// Adiciona cuando no existe o lo modifica cuando ya esta en la base de datos
        /// </summary>
        public static bool FlgActualizar(ModeloFeFacturaMa tobjModelo, out string tcrMensaje)
        {
            var llgReturn = true;
            tcrMensaje = null;
            var lnuSecuencialEnvio = 0;

            try
            {
                // cuando no existe el registro , generar el nuevo secuencial de envio
                if (!FlgBuscarFcmfemaesfactefma(tobjModelo.Fcm_secreg_mfac))
                {
                    //lcreSecEnvio = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-ENVIOS-DIAN", "FCM", "Secuencial de envios documentos a la DIAN");
                    lnuSecuencialEnvio = ModeloFeRazonSocial.FnuGenerarSecuencialEnvioDian("NIT", Empresa.Nit);
                }
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_secreg_mfac == tobjModelo.Fcm_secreg_mfac);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac;
                        lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                        lobjRegistro.fcm_fecfac_mfac = (DateTime)tobjModelo.Fcm_fecfac_mfac;
                        lobjRegistro.fcm_horfac_mfac = (Decimal)tobjModelo.Fcm_horfac_mfac;
                        lobjRegistro.fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd;
                        lobjRegistro.fcm_notdoc_mfac = tobjModelo.Fcm_notdoc_mfac;
                        lobjRegistro.fcm_forpag_mfac = tobjModelo.Fcm_forpag_mfac;
                        //lobjRegistro.fcm_facori_mfac = tobjModelo.Fcm_facori_mfac;
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.fcm_sercre_mfac = tobjModelo.Fcm_sercre_mfac;
                        lobjRegistro.fcm_idrcre_mfac = tobjModelo.Fcm_idrcre_mfac;
                        lobjRegistro.fcm_serdeb_mfac = tobjModelo.Fcm_serdeb_mfac;
                        lobjRegistro.fcm_idrdeb_mfac = tobjModelo.Fcm_idrdeb_mfac;
                        lobjRegistro.fcm_valbsi_dfac = (decimal)tobjModelo.Fcm_valbsi_dfac;
                        lobjRegistro.fcm_valiva_dfac = (decimal)tobjModelo.Fcm_valiva_dfac;
                        lobjRegistro.fcm_valicd_dfac = (decimal)tobjModelo.Fcm_valicd_dfac;
                        lobjRegistro.fcm_valica_dfac = (decimal)tobjModelo.Fcm_valica_dfac;
                        lobjRegistro.fcm_valinc_dfac = (decimal)tobjModelo.Fcm_valinc_dfac;
                        lobjRegistro.fcm_valrti_dfac = (decimal)tobjModelo.Fcm_valrti_dfac;
                        lobjRegistro.fcm_valrtf_dfac = (decimal)tobjModelo.Fcm_valrtf_dfac;
                        lobjRegistro.fcm_valrtc_dfac = (decimal)tobjModelo.Fcm_valrtc_dfac;
                        lobjRegistro.fcm_valcre_dfac = (decimal)tobjModelo.Fcm_valcre_dfac;
                        lobjRegistro.fcm_valfth_dfac = (decimal)tobjModelo.Fcm_valfth_dfac;
                        lobjRegistro.fcm_valtim_dfac = (decimal)tobjModelo.Fcm_valtim_dfac;
                        lobjRegistro.fcm_valbol_dfac = (decimal)tobjModelo.Fcm_valbol_dfac;
                        lobjRegistro.fcm_valicr_dfac = (decimal)tobjModelo.Fcm_valicr_dfac;
                        lobjRegistro.fcm_valicb_dfac = (decimal)tobjModelo.Fcm_valicb_dfac;
                        lobjRegistro.fcm_valscb_dfac = (decimal)tobjModelo.Fcm_valscb_dfac;
                        lobjRegistro.fcm_valsco_dfac = (decimal)tobjModelo.Fcm_valsco_dfac;
                        lobjRegistro.fcm_valftr_dfac = (decimal)tobjModelo.Fcm_valftr_dfac;
                        lobjRegistro.fcm_pordes_dfac = (decimal)tobjModelo.Fcm_pordes_dfac;
                        lobjRegistro.fcm_valdes_dfac = (decimal)tobjModelo.Fcm_valdes_dfac;
                        lobjRegistro.fcm_valcpa_dfac = (decimal)tobjModelo.Fcm_valcpa_dfac;
                        lobjRegistro.fcm_valcmo_dfac = (decimal)tobjModelo.Fcm_valcmo_dfac;
                        lobjRegistro.fcm_valusu_dfac = (decimal)tobjModelo.Fcm_valusu_dfac;
                        lobjRegistro.fcm_valbru_dfac = (decimal)tobjModelo.Fcm_valbru_dfac;
                        lobjRegistro.fcm_valsub_dfac = (decimal)tobjModelo.Fcm_valsub_dfac;
                        lobjRegistro.fcm_valfac_dfac = (decimal)tobjModelo.Fcm_valfac_dfac;
                        lobjRegistro.fcm_valref_dfac = (decimal)tobjModelo.Fcm_valref_dfac;
                        lobjRegistro.fcm_valefe_dfac = (decimal)tobjModelo.Fcm_valefe_dfac;
                        //lobjRegistro.fcm_idcufe_mfac = tobjModelo.Fcm_idcufe_mfac;         // se debe conservar como estaba en bd
                        lobjRegistro.fcm_diafec_mfac = (DateTime)tobjModelo.Fcm_diafec_mfac; // se actualiza al radicar en dian
                        lobjRegistro.fcm_diahor_mfac = (Decimal)tobjModelo.Fcm_diahor_mfac;  // se actualiza al radicar en dian
                        lobjRegistro.fcm_codest_fcws = tobjModelo.Fcm_codest_fcws;           // se actualiza al radicar en dian
                        lobjRegistro.fcm_errore_mfac = tobjModelo.Fcm_errore_mfac;           // se actualiza al radicar en dian
                        //lobjRegistro.fcm_nomarc_mfac = tobjModelo.Fcm_nomarc_mfac;         // se debe conservar como estaba en bd
                        //lobjRegistro.fcm_secrad_mfac = (int)tobjModelo.Fcm_secrad_mfac;    // se debe conservar como estaba en bd
                        //lobjRegistro.fcm_trakid_mfac = tobjModelo.Fcm_trakid_mfac;         // se debe conservar como estaba en bd
                        lobjRegistro.fcm_adqfec_mfac = (DateTime)tobjModelo.Fcm_adqfec_mfac; // es cambiable segun la  ultima vez que se envie
                        lobjRegistro.fcm_adqhor_mfac = (Decimal)tobjModelo.Fcm_adqhor_mfac;  // es cambiable segun la  ultima vez que se envie
                        lobjRegistro.fcm_codest_fcaq = tobjModelo.Fcm_codest_fcaq;           // es cambiable segun la  ultima vez que se envie
                        lobjRegistro.fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac; 
                        lobjRegistro.fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp;
                        lobjRegistro.fcm_fecven_mfac = (DateTime)tobjModelo.Fcm_fecven_mfac;
                        lobjRegistro.fcm_idepag_fcmp = tobjModelo.Fcm_idepag_fcmp;
                        lobjRegistro.fcm_fecanu_mfac = (DateTime)tobjModelo.Fcm_fecanu_mfac;
                        lobjRegistro.fcm_horanu_mfac = (Decimal)tobjModelo.Fcm_horanu_mfac;
                        lobjRegistro.sys_usuanu_usux = tobjModelo.Sys_usuanu_usux;
                        lobjRegistro.fcm_notanu_mfac = tobjModelo.Fcm_notanu_mfac;
                        lobjRegistro.fcm_algori_mfac = tobjModelo.Fcm_algori_mfac;
                        lobjRegistro.fcm_conest_mfac = (int)tobjModelo.Fcm_conest_mfac;
                        lobjRegistro.fcm_fecedt_mfac = (DateTime)tobjModelo.Fcm_fecedt_mfac;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac;
                        lobjRegistro.fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac;
                        #endregion
                        _context.SaveChanges();
                    }
                    else
                    {
                       lobjRegistro = new EFfcmfemaesfactefma
                        {
                            //var lcreSecEnvio = FCM-SECUENCIAL-ENVIOS-DIAN
                            #region cargar Registro
                            fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac,
                            fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_fecfac_mfac = tobjModelo.Fcm_fecfac_mfac,
                            fcm_horfac_mfac = tobjModelo.Fcm_horfac_mfac,
                            fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd,
                            fcm_notdoc_mfac = tobjModelo.Fcm_notdoc_mfac,
                            fcm_forpag_mfac = tobjModelo.Fcm_forpag_mfac,
                            fcm_facori_mfac = tobjModelo.Fcm_facori_mfac,
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            fcm_sercre_mfac = tobjModelo.Fcm_sercre_mfac,
                            fcm_idrcre_mfac = tobjModelo.Fcm_idrcre_mfac,
                            fcm_serdeb_mfac = tobjModelo.Fcm_serdeb_mfac,
                            fcm_idrdeb_mfac = tobjModelo.Fcm_idrdeb_mfac,
                            fcm_valbsi_dfac = tobjModelo.Fcm_valbsi_dfac,
                            fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac,
                            fcm_valicd_dfac = tobjModelo.Fcm_valicd_dfac,
                            fcm_valica_dfac = tobjModelo.Fcm_valica_dfac,
                            fcm_valinc_dfac = tobjModelo.Fcm_valinc_dfac,
                            fcm_valrti_dfac = tobjModelo.Fcm_valrti_dfac,
                            fcm_valrtf_dfac = tobjModelo.Fcm_valrtf_dfac,
                            fcm_valrtc_dfac = tobjModelo.Fcm_valrtc_dfac,
                            fcm_valcre_dfac = tobjModelo.Fcm_valcre_dfac,
                            fcm_valfth_dfac = tobjModelo.Fcm_valfth_dfac,
                            fcm_valtim_dfac = tobjModelo.Fcm_valtim_dfac,
                            fcm_valbol_dfac = tobjModelo.Fcm_valbol_dfac,
                            fcm_valicr_dfac = tobjModelo.Fcm_valicr_dfac,
                            fcm_valicb_dfac = tobjModelo.Fcm_valicb_dfac,
                            fcm_valscb_dfac = tobjModelo.Fcm_valscb_dfac,
                            fcm_valsco_dfac = tobjModelo.Fcm_valsco_dfac,
                            fcm_valftr_dfac = tobjModelo.Fcm_valftr_dfac,
                            fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_valcpa_dfac = tobjModelo.Fcm_valcpa_dfac,
                            fcm_valcmo_dfac = tobjModelo.Fcm_valcmo_dfac,
                            fcm_valusu_dfac = tobjModelo.Fcm_valusu_dfac,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                            fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                            fcm_idcufe_mfac = tobjModelo.Fcm_idcufe_mfac,
                            fcm_diafec_mfac = tobjModelo.Fcm_diafec_mfac,
                            fcm_diahor_mfac = tobjModelo.Fcm_diahor_mfac,
                            fcm_codest_fcws = tobjModelo.Fcm_codest_fcws,
                            fcm_errore_mfac = tobjModelo.Fcm_errore_mfac,
                            fcm_nomarc_mfac = tobjModelo.Fcm_nomarc_mfac,
                            fcm_secrad_mfac = lnuSecuencialEnvio,
                            fcm_trakid_mfac = tobjModelo.Fcm_trakid_mfac,
                            fcm_adqfec_mfac = tobjModelo.Fcm_adqfec_mfac,
                            fcm_adqhor_mfac = tobjModelo.Fcm_adqhor_mfac,
                            fcm_codest_fcaq = tobjModelo.Fcm_codest_fcaq,
                            fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac,
                            fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp,
                            fcm_fecven_mfac = tobjModelo.Fcm_fecven_mfac,
                            fcm_idepag_fcmp = tobjModelo.Fcm_idepag_fcmp,
                            fcm_fecanu_mfac = tobjModelo.Fcm_fecanu_mfac,
                            fcm_horanu_mfac = tobjModelo.Fcm_horanu_mfac,
                            sys_usuanu_usux = tobjModelo.Sys_usuanu_usux,
                            fcm_notanu_mfac = tobjModelo.Fcm_notanu_mfac,
                            fcm_algori_mfac = tobjModelo.Fcm_algori_mfac,
                            fcm_conest_mfac = tobjModelo.Fcm_conest_mfac,
                            fcm_fecedt_mfac = tobjModelo.Fcm_fecedt_mfac,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac,
                            fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac,
                            #endregion
                        };
                        _context.AddToFcmfemaesfactefma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }

                // Actualizar los registros detalles
                if (tobjModelo.tmpListVenta != null)
                {
                    foreach (var lobReg in tobjModelo.tmpListVenta)
                    {
                        ModeloFeFacturaMd.FcvActualizar(lobReg);
                    }
                }
                else
                {
                    tcrMensaje = "No hay registros de venta";
                    llgReturn = false;
                }

            }
            catch (Exception ex)
            {
                llgReturn = false;
                tcrMensaje = "ModeloFeFacturaMa error metodo FlgActualizar: " + ex.Message;
                Funciones.fcvVistaErroresEjecucion(ref ex, "ModeloFeFacturaMa error metodo FlgActualizar");
                return llgReturn;
            }

            return llgReturn;
        }
        #endregion
        #region Actualizar parametros
        /// <summary>
        /// Actualizar parametros de gestion consulta DIAN
        /// </summary>
        public static bool FlgActualizarParametros(ModeloFeFacturaMa tobRegistro, out string tcrMensaje)
        {
            var llgReturn = true;
            tcrMensaje = null;

            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjReg = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac);
                    if (lobjReg != null)
                    {
                        #region cargar Registro
                        lobjReg.fcm_idcufe_mfac = tobRegistro.Fcm_idcufe_mfac != null ? tobRegistro.Fcm_idcufe_mfac: lobjReg.fcm_idcufe_mfac;
                        lobjReg.fcm_diafec_mfac = tobRegistro.Fcm_diafec_mfac != null ? (DateTime)tobRegistro.Fcm_diafec_mfac: lobjReg.fcm_diafec_mfac;
                        lobjReg.fcm_diahor_mfac = tobRegistro.Fcm_diahor_mfac != 0 ? (Decimal)tobRegistro.Fcm_diahor_mfac: lobjReg.fcm_diahor_mfac;
                        lobjReg.fcm_codest_fcws = tobRegistro.Fcm_codest_fcws != null ? tobRegistro.Fcm_codest_fcws: lobjReg.fcm_codest_fcws;
                        lobjReg.fcm_errore_mfac = tobRegistro.Fcm_errore_mfac != null ? tobRegistro.Fcm_errore_mfac : lobjReg.fcm_errore_mfac;
                        lobjReg.fcm_nomarc_mfac = tobRegistro.Fcm_nomarc_mfac != null ? tobRegistro.Fcm_nomarc_mfac: lobjReg.fcm_nomarc_mfac;
                        lobjReg.fcm_secrad_mfac = tobRegistro.Fcm_secrad_mfac != 0 ? (int)tobRegistro.Fcm_secrad_mfac: lobjReg.fcm_secrad_mfac;
                        lobjReg.fcm_trakid_mfac = tobRegistro.Fcm_trakid_mfac != null ? tobRegistro.Fcm_trakid_mfac: lobjReg.fcm_trakid_mfac;
                        lobjReg.fcm_adqfec_mfac = tobRegistro.Fcm_adqfec_mfac != null ? (DateTime)tobRegistro.Fcm_adqfec_mfac : lobjReg.fcm_adqfec_mfac;
                        lobjReg.fcm_adqhor_mfac = tobRegistro.Fcm_adqhor_mfac != 0 ? (Decimal)tobRegistro.Fcm_adqhor_mfac: lobjReg.fcm_adqhor_mfac;
                        lobjReg.fcm_codest_fcaq = tobRegistro.Fcm_codest_fcaq != null ? tobRegistro.Fcm_codest_fcaq : lobjReg.fcm_codest_fcaq;
                        #endregion
                        _context.SaveChanges();
                    }
                    else
                    {
                        llgReturn = false;
                        tcrMensaje = "No se encontro el registro para actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                llgReturn = false;
                tcrMensaje = "ModeloFeFacturaMa error metodo FlgActualizarParametros: " + ex.Message;
            }

            return llgReturn;
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_secreg_mfac == tcrCodigo);
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
        #region FlgBuscarFcmfemaesfactefma: Buscar en FCMFEMAESFACTEFMA
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TITULO: Maestro de facturas electronicas</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas  electronicas Notas debito y Notas Credito
        /// </para>
        /// </summary>
        public static bool FlgBuscarFcmfemaesfactefma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesfactefma.FirstOrDefault(p => p.fcm_secreg_mfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        // consultas
        #region Listar Registros
        public static List<ModeloFeFacturaMa> FlsListaFcmfemaesfactefma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                      join fcmfesecrfacturas in _context.Fcmsecrfacturas on fcmfemaesfactefma.fcm_secres_srfa equals fcmfesecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmfemaescontrato in _context.Fcmfemaescontrato on fcmfemaesfactefma.cto_seccon_cont equals fcmfemaescontrato.cto_seccon_cont into tmfcmfemaescontrato
                                      join sismaesterceros in _context.Sismaesterceros on fcmfemaesfactefma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join sysusuarios in _context.Sysusuarios on fcmfemaesfactefma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join fcmfemediosdepago in _context.Fcmfemediosdepago on fcmfemaesfactefma.fcm_codmpg_fcmp equals fcmfemediosdepago.fcm_codmpg_fcmp into tmfcmfemediosdepago
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from cont in tmfcmfemaescontrato.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from fcmp in tmfcmfemediosdepago.DefaultIfEmpty()
                                      select new ModeloFeFacturaMa
                                      {
                                          #region Datos
                                          Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                          Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                          Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                          Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                          Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                          Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                          Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                          Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                          Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                          Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                          Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                          Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                          Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                          Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                          Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                          Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                          Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                          Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                          Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                          Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                          Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                          Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                          Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                          Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                          Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                          Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                          Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                          Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                          Fcm_metpag_mfac = fcmfemaesfactefma.fcm_metpag_mfac,
                                          Fcm_codmpg_fcmp = fcmfemaesfactefma.fcm_codmpg_fcmp,
                                          Fcm_fecven_mfac = (DateTime)fcmfemaesfactefma.fcm_fecven_mfac,
                                          Fcm_idepag_fcmp = fcmfemaesfactefma.fcm_idepag_fcmp,
                                          Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                          Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                          Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                          Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                          Fcm_algori_mfac = fcmfemaesfactefma.fcm_algori_mfac,
                                          Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                          Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                          Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                          Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                          Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Fcm_desmpg_fcmp = fcmp.fcm_desmpg_fcmp,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                      join fcmfesecrfacturas in _context.Fcmsecrfacturas on fcmfemaesfactefma.fcm_secres_srfa equals fcmfesecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmfemaescontrato in _context.Fcmfemaescontrato on fcmfemaesfactefma.cto_seccon_cont equals fcmfemaescontrato.cto_seccon_cont into tmfcmfemaescontrato
                                      join sismaesterceros in _context.Sismaesterceros on fcmfemaesfactefma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join sysusuarios in _context.Sysusuarios on fcmfemaesfactefma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join fcmfemediosdepago in _context.Fcmfemediosdepago on fcmfemaesfactefma.fcm_codmpg_fcmp equals fcmfemediosdepago.fcm_codmpg_fcmp into tmfcmfemediosdepago
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from cont in tmfcmfemaescontrato.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from fcmp in tmfcmfemediosdepago.DefaultIfEmpty()
                                      where fcmfemaesfactefma.fcm_secreg_mfac == tcrBuscar
                                      select new ModeloFeFacturaMa
                                      {
                                          #region Datos
                                          Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                          Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                          Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                          Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                          Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                          Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                          Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                          Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                          Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                          Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                          Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                          Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                          Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                          Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                          Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                          Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                          Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                          Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                          Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                          Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                          Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                          Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                          Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                          Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                          Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                          Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                          Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                          Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                          Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                          Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                          Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                          Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                          Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                          Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                          Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                          Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                          Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Un solo Registro
        /// <summary>
        /// Consultar un registro de factura con datos del vendedor, cliente y demas
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NF"=Numero de Factura</param>
        /// <param name="tcrIdRegistro">Codigo del registro o numero de factura</param>
        /// <returns></returns>
        public static ModeloFeFacturaMa FobRegistroFcmfemaesfactefma(String tcrTipo, String tcrIdRegistro)
        {
            ModeloFeFacturaMa lobConsulta = null;

            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "ID") // por el Id del registro factura
                {
                    lobConsulta = (from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                      join fcmfesecrfacturas in _context.Fcmsecrfacturas on fcmfemaesfactefma.fcm_secres_srfa equals fcmfesecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmfemaescontrato in _context.Fcmfemaescontrato on fcmfemaesfactefma.cto_seccon_cont equals fcmfemaescontrato.cto_seccon_cont into tmfcmfemaescontrato
                                      join sismaesterceros in _context.Sismaesterceros on fcmfemaesfactefma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join sysusuarios in _context.Sysusuarios on fcmfemaesfactefma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from cont in tmfcmfemaescontrato.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      where fcmfemaesfactefma.fcm_secreg_mfac == tcrIdRegistro
                                      select new ModeloFeFacturaMa
                                      {
                                          #region Datos
                                          Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                          Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                          Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                          Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                          Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                          Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                          Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                          Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                          Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                          Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                          Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                          Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                          Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                          Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                          Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                          Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                          Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                          Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                          Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                          Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                          Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                          Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                          Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                          Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                          Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                          Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                          Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                          Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                          Fcm_metpag_mfac = fcmfemaesfactefma.fcm_metpag_mfac,
                                          Fcm_codmpg_fcmp = fcmfemaesfactefma.fcm_codmpg_fcmp,
                                          Fcm_fecven_mfac = (DateTime)fcmfemaesfactefma.fcm_fecven_mfac,
                                          Fcm_idepag_fcmp = fcmfemaesfactefma.fcm_idepag_fcmp,
                                          Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                          Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                          Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                          Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                          Fcm_algori_mfac = fcmfemaesfactefma.fcm_algori_mfac,
                                          Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                          Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                          Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                          Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                          Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Fcm_desest_fcws = _context.Fcmfeestadoresdian.FirstOrDefault(x => x.fcm_codest_fcws == fcmfemaesfactefma.fcm_codest_fcws).fcm_desest_fcws,
                                          #endregion
                                      }).FirstOrDefault();
                }
                else // por numero de factura
                {
                    lobConsulta = (from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                      join fcmfesecrfacturas in _context.Fcmsecrfacturas on fcmfemaesfactefma.fcm_secres_srfa equals fcmfesecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmfemaescontrato in _context.Fcmfemaescontrato on fcmfemaesfactefma.cto_seccon_cont equals fcmfemaescontrato.cto_seccon_cont into tmfcmfemaescontrato
                                      join sismaesterceros in _context.Sismaesterceros on fcmfemaesfactefma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join sysusuarios in _context.Sysusuarios on fcmfemaesfactefma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from cont in tmfcmfemaescontrato.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      where fcmfemaesfactefma.fcm_numfac_mfac == tcrIdRegistro
                                      select new ModeloFeFacturaMa
                                      {
                                          #region Datos
                                          Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                          Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                          Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                          Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                          Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                          Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                          Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                          Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                          Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                          Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                          Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                          Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                          Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                          Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                          Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                          Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                          Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                          Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                          Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                          Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                          Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                          Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                          Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                          Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                          Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                          Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                          Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                          Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                          Fcm_metpag_mfac = fcmfemaesfactefma.fcm_metpag_mfac,
                                          Fcm_codmpg_fcmp = fcmfemaesfactefma.fcm_codmpg_fcmp,
                                          Fcm_fecven_mfac = (DateTime)fcmfemaesfactefma.fcm_fecven_mfac,
                                          Fcm_idepag_fcmp = fcmfemaesfactefma.fcm_idepag_fcmp,
                                          Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                          Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                          Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                          Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                          Fcm_algori_mfac = fcmfemaesfactefma.fcm_algori_mfac,
                                          Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                          Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                          Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                          Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                          Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Fcm_desest_fcws = _context.Fcmfeestadoresdian.FirstOrDefault(x => x.fcm_codest_fcws == fcmfemaesfactefma.fcm_codest_fcws).fcm_desest_fcws,
                                          #endregion
                                      }).FirstOrDefault();
                }

                // Llenar los temporales que complementan la factura
                if (lobConsulta != null)
                {
                    lobConsulta.lobRegEmpresa    = ModeloFeRazonSocial.FlsListaFcmfemaesrazsocmaID("ID", lobConsulta.Fcm_secraz_fcem);
                    lobConsulta.tmpListVenta     = ModeloFeFacturaMd.FlsListaFcmfemaesfactefmd(lobConsulta.Fcm_secreg_mfac);
                    lobConsulta.lobRegCliente    = ModeloSismaesterceros.FobRegistrosSismaesterceros("ID", lobConsulta.Sis_idterc_sitr);
                    lobConsulta.lobRegResolDian  = ModeloResolDianFacturas.FobRegistroResolucionDian("ID",lobConsulta.Fcm_secres_srfa);

                }

            }
            return lobConsulta;
        }
        #endregion
        #region Un solo Registro sin detalles ni datos de terceros
        /// <summary>
        /// Generar un registro de factura sin detalles ni datos de terceros
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NF"=Numero de Factura</param>
        /// <param name="tcrIdRegistro">Codigo del registro o numero de factura</param>
        /// <returns></returns>
        public static ModeloFeFacturaMa FobRegistroFcmfemaesfactefmaEx(String tcrTipo, String tcrIdRegistro)
        {
            ModeloFeFacturaMa lobConsulta = null;

            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "ID") // por el Id del registro factura
                {
                    lobConsulta = (from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                   where fcmfemaesfactefma.fcm_secreg_mfac == tcrIdRegistro
                                   select new ModeloFeFacturaMa
                                   {
                                       #region Datos
                                       Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                       Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                       Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                       Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                       Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                       Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                       Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                       Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                       Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                       Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                       Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                       Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                       Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                       Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                       Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                       Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                       Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                       Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                       Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                       Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                       Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                       Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                       Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                       Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                       Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                       Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                       Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                       Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                       Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                       Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                       Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                       Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                       Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                       Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                       Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                       Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                       Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                       Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                       Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                       Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                       Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                       Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                       Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                       Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                       Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                       Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                       Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                       Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                       Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                       Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                       Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                       Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                       Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                       Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                       Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                       Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                       Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                       Fcm_metpag_mfac = fcmfemaesfactefma.fcm_metpag_mfac,
                                       Fcm_codmpg_fcmp = fcmfemaesfactefma.fcm_codmpg_fcmp,
                                       Fcm_fecven_mfac = (DateTime)fcmfemaesfactefma.fcm_fecven_mfac,
                                       Fcm_idepag_fcmp = fcmfemaesfactefma.fcm_idepag_fcmp,
                                       Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                       Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                       Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                       Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                       Fcm_algori_mfac = fcmfemaesfactefma.fcm_algori_mfac,
                                       Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                       Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                       Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                       Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                       Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                       #endregion
                                   }).FirstOrDefault();
                }
                else // por numero de factura
                {
                    lobConsulta = (from fcmfemaesfactefma in _context.Fcmfemaesfactefma
                                   where fcmfemaesfactefma.fcm_numfac_mfac == tcrIdRegistro
                                   select new ModeloFeFacturaMa
                                   {
                                       #region Datos
                                       Fcm_secreg_mfac = fcmfemaesfactefma.fcm_secreg_mfac,
                                       Fcm_secraz_fcem = fcmfemaesfactefma.fcm_secraz_fcem,
                                       Fcm_numfac_mfac = fcmfemaesfactefma.fcm_numfac_mfac,
                                       Fcm_fecfac_mfac = (DateTime)fcmfemaesfactefma.fcm_fecfac_mfac,
                                       Fcm_horfac_mfac = (Decimal)fcmfemaesfactefma.fcm_horfac_mfac,
                                       Fcm_typdoc_fctd = fcmfemaesfactefma.fcm_typdoc_fctd,
                                       Fcm_notdoc_mfac = fcmfemaesfactefma.fcm_notdoc_mfac,
                                       Fcm_forpag_mfac = fcmfemaesfactefma.fcm_forpag_mfac,
                                       Fcm_facori_mfac = fcmfemaesfactefma.fcm_facori_mfac,
                                       Fcm_secres_srfa = fcmfemaesfactefma.fcm_secres_srfa,
                                       Adm_secadm_rgad = fcmfemaesfactefma.adm_secadm_rgad,
                                       Sia_idesec_usua = fcmfemaesfactefma.sia_idesec_usua,
                                       Cto_seccon_cont = fcmfemaesfactefma.cto_seccon_cont,
                                       Sia_codeps_teps = fcmfemaesfactefma.sia_codeps_teps,
                                       Sis_idterc_sitr = fcmfemaesfactefma.sis_idterc_sitr,
                                       Fcm_sercre_mfac = fcmfemaesfactefma.fcm_sercre_mfac,
                                       Fcm_idrcre_mfac = fcmfemaesfactefma.fcm_idrcre_mfac,
                                       Fcm_serdeb_mfac = fcmfemaesfactefma.fcm_serdeb_mfac,
                                       Fcm_idrdeb_mfac = fcmfemaesfactefma.fcm_idrdeb_mfac,
                                       Fcm_valbsi_dfac = (decimal)fcmfemaesfactefma.fcm_valbsi_dfac,
                                       Fcm_valiva_dfac = (decimal)fcmfemaesfactefma.fcm_valiva_dfac,
                                       Fcm_valicd_dfac = (decimal)fcmfemaesfactefma.fcm_valicd_dfac,
                                       Fcm_valica_dfac = (decimal)fcmfemaesfactefma.fcm_valica_dfac,
                                       Fcm_valinc_dfac = (decimal)fcmfemaesfactefma.fcm_valinc_dfac,
                                       Fcm_valrti_dfac = (decimal)fcmfemaesfactefma.fcm_valrti_dfac,
                                       Fcm_valrtf_dfac = (decimal)fcmfemaesfactefma.fcm_valrtf_dfac,
                                       Fcm_valrtc_dfac = (decimal)fcmfemaesfactefma.fcm_valrtc_dfac,
                                       Fcm_valcre_dfac = (decimal)fcmfemaesfactefma.fcm_valcre_dfac,
                                       Fcm_valfth_dfac = (decimal)fcmfemaesfactefma.fcm_valfth_dfac,
                                       Fcm_valtim_dfac = (decimal)fcmfemaesfactefma.fcm_valtim_dfac,
                                       Fcm_valbol_dfac = (decimal)fcmfemaesfactefma.fcm_valbol_dfac,
                                       Fcm_valicr_dfac = (decimal)fcmfemaesfactefma.fcm_valicr_dfac,
                                       Fcm_valicb_dfac = (decimal)fcmfemaesfactefma.fcm_valicb_dfac,
                                       Fcm_valscb_dfac = (decimal)fcmfemaesfactefma.fcm_valscb_dfac,
                                       Fcm_valsco_dfac = (decimal)fcmfemaesfactefma.fcm_valsco_dfac,
                                       Fcm_valftr_dfac = (decimal)fcmfemaesfactefma.fcm_valftr_dfac,
                                       Fcm_pordes_dfac = (decimal)fcmfemaesfactefma.fcm_pordes_dfac,
                                       Fcm_valdes_dfac = (decimal)fcmfemaesfactefma.fcm_valdes_dfac,
                                       Fcm_valcpa_dfac = (decimal)fcmfemaesfactefma.fcm_valcpa_dfac,
                                       Fcm_valcmo_dfac = (decimal)fcmfemaesfactefma.fcm_valcmo_dfac,
                                       Fcm_valusu_dfac = (decimal)fcmfemaesfactefma.fcm_valusu_dfac,
                                       Fcm_valbru_dfac = (decimal)fcmfemaesfactefma.fcm_valbru_dfac,
                                       Fcm_valsub_dfac = (decimal)fcmfemaesfactefma.fcm_valsub_dfac,
                                       Fcm_valfac_dfac = (decimal)fcmfemaesfactefma.fcm_valfac_dfac,
                                       Fcm_valref_dfac = (decimal)fcmfemaesfactefma.fcm_valref_dfac,
                                       Fcm_valefe_dfac = (decimal)fcmfemaesfactefma.fcm_valefe_dfac,
                                       Fcm_idcufe_mfac = fcmfemaesfactefma.fcm_idcufe_mfac,
                                       Fcm_diafec_mfac = (DateTime)fcmfemaesfactefma.fcm_diafec_mfac,
                                       Fcm_diahor_mfac = (Decimal)fcmfemaesfactefma.fcm_diahor_mfac,
                                       Fcm_codest_fcws = fcmfemaesfactefma.fcm_codest_fcws,
                                       Fcm_errore_mfac = fcmfemaesfactefma.fcm_errore_mfac,
                                       Fcm_nomarc_mfac = fcmfemaesfactefma.fcm_nomarc_mfac,
                                       Fcm_secrad_mfac = (int)fcmfemaesfactefma.fcm_secrad_mfac,
                                       Fcm_trakid_mfac = fcmfemaesfactefma.fcm_trakid_mfac,
                                       Fcm_adqfec_mfac = (DateTime)fcmfemaesfactefma.fcm_adqfec_mfac,
                                       Fcm_adqhor_mfac = (Decimal)fcmfemaesfactefma.fcm_adqhor_mfac,
                                       Fcm_codest_fcaq = fcmfemaesfactefma.fcm_codest_fcaq,
                                       Fcm_metpag_mfac = fcmfemaesfactefma.fcm_metpag_mfac,
                                       Fcm_codmpg_fcmp = fcmfemaesfactefma.fcm_codmpg_fcmp,
                                       Fcm_fecven_mfac = (DateTime)fcmfemaesfactefma.fcm_fecven_mfac,
                                       Fcm_idepag_fcmp = fcmfemaesfactefma.fcm_idepag_fcmp,
                                       Fcm_fecanu_mfac = (DateTime)fcmfemaesfactefma.fcm_fecanu_mfac,
                                       Fcm_horanu_mfac = (Decimal)fcmfemaesfactefma.fcm_horanu_mfac,
                                       Sys_usuanu_usux = fcmfemaesfactefma.sys_usuanu_usux,
                                       Fcm_notanu_mfac = fcmfemaesfactefma.fcm_notanu_mfac,
                                       Fcm_algori_mfac = fcmfemaesfactefma.fcm_algori_mfac,
                                       Fcm_conest_mfac = (int)fcmfemaesfactefma.fcm_conest_mfac,
                                       Fcm_fecedt_mfac = (DateTime)fcmfemaesfactefma.fcm_fecedt_mfac,
                                       Sys_codusu_usux = fcmfemaesfactefma.sys_codusu_usux,
                                       Fcm_tiprfa_mfac = fcmfemaesfactefma.fcm_tiprfa_mfac,
                                       Fcm_estfac_mfac = fcmfemaesfactefma.fcm_estfac_mfac,
                                       #endregion
                                   }).FirstOrDefault();
                }
            }
            return lobConsulta;
        }
        #endregion
        #endregion
    }
}
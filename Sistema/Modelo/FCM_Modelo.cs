using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Sistema.Modelo
{
    /// <summary>
    /// Vista de tabla: fcmmaesfacturas Maestro facturas de servicios medicos
    /// </summary>
    public class FcmModeloMaestrofacturas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _fcm_secreg_mfac;
        private String _fcm_numfac_mfac;
        private String _adm_secadm_rgad;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private String _cto_seccon_cont;
        private String _cto_nrocon_cont;
        private String _sia_codeps_teps;
        private DateTime _fcm_fecfac_mfac;
        private String _fcm_autdes_ades;
        private float _fcm_valbru_dfac;
        private float _fcm_pordes_dfac;
        private float _fcm_valdes_dfac;
        private float _fcm_poriva_dfac;
        private float _fcm_valiva_dfac;
        private float _fcm_valcpa_dfac;
        private float _fcm_valcmo_dfac;
        private float _fcm_valusu_dfac;
        private float _fcm_valcom_dfac;
        private float _fcm_valsub_dfac;
        private float _fcm_valfac_dfac;
        private float _fcm_valref_dfac;
        private float _fcm_valefe_dfac;
        private DateTime _fcm_fecedt_mfac;
        private String _sys_codusu_usux;
        private String _sia_regate_rgat;
        private String _sia_tipact_tsac;
        private String _sia_codcat_ceat;
        private String _fcm_estfac_mfac;
        private String _sia_nomusu_usua;
        private String _sia_deside_tide;
        private String _cto_descon_cont;
        private String _sia_deseps_teps;
        private String _con_razsoc_mter;
        private String _sys_nomusu_usux;
        private String _sia_desreg_rgat;
        private String _sia_desact_tsac;
        private String _sia_descat_ceat;
        private String _sis_estado_imaen;
        private String _fcm_desfac_mfac;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_mfac: Código Único registro
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
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
        #region Fcm_numfac_mfac: Numero Factura
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
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
        // Datos Gestión Dian						
        #region Fcm_typdoc_fctd: Tipo documento
        private String _fcm_typdoc_fctd;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmfetipodocument</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: fcm_typdoc_fctd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica de Venta 02=Factura electrónica
        /// venta-xportación 91=Nota Credito 92=Nota Debito y otros
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
        #region Fcm_secraz_fcem: Razon social Empresa
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public String Fcm_secraz_fcem
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
        #region Fcm_secres_srfa: Codigo unico en sistema Resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Secuencial unico en sistema resolución Dian desde la cual</para>
        /// <para>se genera el numero de factura (cuando aplique)</para>
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
        // Datos Gestion General						
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion
        /// y otros
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Cto_seccon_cont: Secuencial de Contrato
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Cto_nrocon_cont: Número Contrato
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public String Cto_nrocon_cont
        {
            get { return _cto_nrocon_cont; }
            set
            {
                if (_cto_nrocon_cont == value) return;
                _cto_nrocon_cont = value;
                OnPropertyChanged("Cto_nrocon_cont");
            }
        }
        #endregion
        #region Cto_dedcop_cont: Deduccion desde valor facturado
        private String _cto_dedcop_cont;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Realizar deduccion copago del valor factura </para>
        /// <para>NOMBRE: Cto_dedcop_cont (char:1)</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Parametro para saber si se realizara cobro del copago o c.moderadora desde valor facturado </para>
        /// <para>Deduccion desde valor facturado: 1= Descontar copagos/c.mode 2=No Descontar copagos/c.mode </para>
        /// </summary>
        public String Cto_dedcop_cont
        {
            get { return _cto_dedcop_cont; }
            set
            {
                if (_cto_dedcop_cont == value) return;
                _cto_dedcop_cont = value;
                OnPropertyChanged("Cto_dedcop_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Sia_codnit_teps: Numero Nit EPS
        private String _sia_codnit_teps;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Numero Nit EPS</para>
        /// <para>NOMBRE: sia_codnit_teps (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero del Nit de la EPS o Asegurador
        /// </para>
        /// </summary>
        public String Sia_codnit_teps
        {
            get { return _sia_codnit_teps; }
            set
            {
                if (_sia_codnit_teps == value) return;
                _sia_codnit_teps = value;
                OnPropertyChanged("Sia_codnit_teps");
            }
        }
        #endregion
        #region Sis_idterc_sitr: Código tercero (contable)
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        // Inforamcion sobre el pago de la factura						
        #region Fcm_fecfac_mfac: Fecha factura
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Fcm_diavfa_mfac: Dias vencimiento factura
        private int _fcm_diavfa_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Dias vencimiento factura</para>
        /// <para>NOMBRE: fcm_diavfa_mfac (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCIÓN: 
        /// Numero de dias para vigencia de factura de venta el sistema realiza el calculo del dia final
        /// </para>
        /// </summary>
        public int Fcm_diavfa_mfac
        {
            get { return _fcm_diavfa_mfac; }
            set
            {
                if (_fcm_diavfa_mfac == value) return;
                _fcm_diavfa_mfac = value;
                OnPropertyChanged("Fcm_diavfa_mfac");
            }
        }
        #endregion
        #region Fcm_horfac_mfac: Hora emision factura
        private Decimal _fcm_horfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Hora emision factura</para>
        /// <para>NOMBRE: fcm_horfac_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: Hora emision de la factura</para>
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
        // Inforamcion sobre el pago de la factura						
        #region Fcm_metpag_mfac: Metodo de pago
        private String _fcm_metpag_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Metodo de pago</para>
        /// <para>NOMBRE: fcm_metpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: Metodo de pago 1=Contado 2=Credito</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmfemediosdepago</para>
        /// <para>CAMPO: Medio de pago</para>
        /// <para>NOMBRE: fcm_codmpg_fcmp (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCIÓN: 
        /// FAN02: Codigo secuencial medios de pago según  cuadro  No: 6.3.4.2 - Medios de Pago: cbc:PaymentMeansCode
        /// : 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha Vencimiento</para>
        /// <para>NOMBRE: fcm_fecven_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCIÓN: 
        /// Fecha vencimiento factura contada desde el momento que fue  generado el secuencial factrua
        /// Dian
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
        #region Fcm_codest_fcws: Estado gestion Dian
        private String _fcm_codest_fcws;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmfeestadoresdian</para>
        /// <para>CAMPO: Estado gestion Dian</para>
        /// <para>NOMBRE: fcm_codest_fcws (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
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
        // Inforamcion totales de la factura						
        #region Fcm_autdes_ades: Autorización descuento
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_valbru_dfac: Valor bruto factura
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valbru_dfac
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
        #region Fcm_valbsi_dfac: Valor Base impuestos
        private float _fcm_valbsi_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: fcm_valbsi_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCIÓN: Valor de la base Imponible (base para el calculo de impuesto)</para>
        /// </summary>
        public float Fcm_valbsi_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_poriva_dfac: Porcentaje del IVA
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float Fcm_poriva_dfac
        {
            get { return _fcm_poriva_dfac; }
            set
            {
                if (_fcm_poriva_dfac == value) return;
                _fcm_poriva_dfac = value;
                OnPropertyChanged("Fcm_poriva_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float Fcm_valiva_dfac
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
        #region Fcm_valcpa_dfac: Valor copago
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float Fcm_valcpa_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float Fcm_valcmo_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float Fcm_valusu_dfac
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
        #region Fcm_valcom_dfac: Valor comisión
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: fcm_valcom_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float Fcm_valcom_dfac
        {
            get { return _fcm_valcom_dfac; }
            set
            {
                if (_fcm_valcom_dfac == value) return;
                _fcm_valcom_dfac = value;
                OnPropertyChanged("Fcm_valcom_dfac");
            }
        }
        #endregion
        #region Fcm_valsub_dfac: Valor subtotal servicio
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float Fcm_valsub_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valfac_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor a recaudar en efectivo sin descuento realizado aun (solo valor a cobrar
        /// en efectivo) por copagos cuotas moderadoras o valor total del servicio,
        /// no siempre representa el valor total del servicio.
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente al servicio, representa Fcm_valref_dfac menos el descuento 
        /// cuando aplique desucento, de lo contrario solo es Fcm_valref_dfac.
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
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
        #region Fcm_fecedt_mfac: Fecha ultima modificación
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: fcm_fecedt_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
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
        #region Fcm_tiprfa_mfac: Tipo registro factuación
        private String _fcm_tiprfa_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro factuación</para>
        /// <para>NOMBRE: fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        #region Sia_regate_rgat: Registro de Atención
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
        /// </para>
        /// </summary>
        public String Sia_regate_rgat
        {
            get { return _sia_regate_rgat; }
            set
            {
                if (_sia_regate_rgat == value) return;
                _sia_regate_rgat = value;
                OnPropertyChanged("Sia_regate_rgat");
            }
        }
        #endregion
        #region Sia_tipact_tsac: Tipo servicio o activiad
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o activiad</para>
        /// <para>NOMBRE: sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
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
        #region Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        #region Fcm_fecanu_mfac: Fecha anulación
        private DateTime _fcm_fecanu_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha anulación</para>
        /// <para>NOMBRE: fcm_fecanu_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Hora anulacion factura</para>
        /// <para>NOMBRE: fcm_horanu_mfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario que anula</para>
        /// <para>NOMBRE: sys_usuanu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Motivo anulacion factura</para>
        /// <para>NOMBRE: fcm_notanu_mfac (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        #region Fcm_estfac_mfac: Estado Factura
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region Fcm_desfac_mfac: Descripcion estado Factura
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Descripcion Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Descripcion estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public String Fcm_desfac_mfac
        {
            get { return _fcm_desfac_mfac; }
            set
            {
                if (_fcm_desfac_mfac == value) return;
                _fcm_desfac_mfac = value;
                OnPropertyChanged("Fcm_desfac_mfac");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        #region Cto_descon_cont: Descripción contrato
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sia_deseps_teps: Nombre EPS
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Con_razsoc_mter: Nombre / Razon social
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: con_razsoc_mter (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
        /// </summary>
        public String Con_razsoc_mter
        {
            get { return _con_razsoc_mter; }
            set
            {
                if (_con_razsoc_mter == value) return;
                _con_razsoc_mter = value;
                OnPropertyChanged("Con_razsoc_mter");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
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
        #region Sys_nusua_usux: Nombre Usuario que anula factura
        private String _sys_nousua_usux;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: Sys_nusua_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo usuario que anula la factura
        /// </para>
        /// </summary>
        public String Sys_nousua_usux
        {
            get { return _sys_nousua_usux; }
            set
            {
                if (_sys_nousua_usux == value) return;
                _sys_nousua_usux = value;
                OnPropertyChanged("Sys_nousua_usux");
            }
        }
        #endregion
        #region Sia_desreg_rgat: Registro de atención
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: sia_desreg_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public String Sia_desreg_rgat
        {
            get { return _sia_desreg_rgat; }
            set
            {
                if (_sia_desreg_rgat == value) return;
                _sia_desreg_rgat = value;
                OnPropertyChanged("Sia_desreg_rgat");
            }
        }
        #endregion
        #region Sia_desact_tsac: Tipo servicio o actividad
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_descat_ceat: Descripción centro atención
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
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
        #region Fcm_tipdes_mfac: Tipo Calculo del decuento
        private String _fcm_tipdes_mfac;
        /// <summary>
        /// <para>CAMPO: Tipo de descuento realizado</para>
        /// <para>NOMBRE: Fcm_tipdes_mfac (char:1)</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar no existe fisicamente en las tablas, utilizado para
        /// realizar los tipos de calculo en descuento en pagos en efectivo
        /// 1=Calcular por porcentaje, 2= Calcular por valor, 3= Valor con descuento
        /// </para>
        /// </summary>
        public String Fcm_tipdes_mfac
        {
            get { return _fcm_tipdes_mfac; }
            set
            {
                if (_fcm_tipdes_mfac == value) return;
                _fcm_tipdes_mfac = value;
                OnPropertyChanged("Fcm_tipdes_mfac");
            }
        }
        #endregion
        #region Sis_valor_letra: Valor factura en letras
        private String _sis_valor_letra;
        /// <summary>
        /// <para>CAMPO: Valor factura en letras</para>
        /// <para>NOMBRE: Sis_valor_letra (char: largo)</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar no existe fisicamente en las tablas, utilizado para
        /// mostrar el valor en letra de la factura
        /// </para>
        /// </summary>
        public String Sis_valor_letra
        {
            get { return _sis_valor_letra; }
            set
            {
                if (_sis_valor_letra == value) return;
                _sis_valor_letra = value;
                OnPropertyChanged("Sis_valor_letra");
            }
        }
        #endregion
        #region Sis_auxiliar_datos: Campo para valor auxiliar multiproposito
        private String _sis_auxiliar_datos;
        /// <summary>
        /// <para>CAMPO: temporal</para>
        /// <para>DESCRIPCION: Campo para valor auxiliar multiproposito.</para>
        /// </summary>
        public String Sis_auxiliar_datos
        {
            get { return _sis_auxiliar_datos; }
            set
            {
                if (_sis_auxiliar_datos == value) return;
                _sis_auxiliar_datos = value;
                OnPropertyChanged("Sis_auxiliar_datos");
            }
        }
        #endregion
        #region Cto_fcdian_cont: Generar Secuencial facturas DIAN Si/No
        private String _cto_fcdian_cont;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: cto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Generar Numeros de factura desde Secuencial autorizado DIAN:
        /// 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_fcdian_cont
        {
            get { return _cto_fcdian_cont; }
            set
            {
                if (_cto_fcdian_cont == value) return;
                _cto_fcdian_cont = value;
                OnPropertyChanged("Cto_fcdian_cont");
            }
        }
        #endregion
        // Datos Complemento resolucion Dian (cuando aplique)
        #region Fcm_numres_srfa: Numero Resolución Autorización DIAN
        private String _fcm_numres_srfa;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la resolución Dian (cuando aplique)
        /// </para>
        /// </summary>
        public String Fcm_numres_srfa
        {
            get { return _fcm_numres_srfa; }
            set
            {
                if (_fcm_numres_srfa == value) return;
                _fcm_numres_srfa = value;
                OnPropertyChanged("Fcm_numres_srfa");
            }
        }
        #endregion
        #region Fcm_desres_srfa: Descripción Resolucion Dian
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Descripcion o nota  de la resolucion Dian</para>
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
        #region Fcm_notenc_srfa: Nota de encabezado
        private String _fcm_notenc_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_notenc_srfa
        {
            get { return _fcm_notenc_srfa; }
            set
            {
                if (_fcm_notenc_srfa == value) return;
                _fcm_notenc_srfa = value;
                OnPropertyChanged("Fcm_notenc_srfa");
            }
        }
        #endregion
        #region Fcm_noppag_srfa: Nota pie de pagina
        private String _fcm_noppag_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_noppag_srfa
        {
            get { return _fcm_noppag_srfa; }
            set
            {
                if (_fcm_noppag_srfa == value) return;
                _fcm_noppag_srfa = value;
                OnPropertyChanged("Fcm_noppag_srfa");
            }
        }
        #endregion
        #region Fcm_fecini_srfa: Fecha Inicia vigencia
        private DateTime _fcm_fecini_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha Inicia vigencia</para>
        /// <para>NOMBRE: fcm_fecini_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha en que inicia vigencia para ser utilzada por el sistema
        /// </para>
        /// </summary>
        public DateTime Fcm_fecini_srfa
        {
            get { return _fcm_fecini_srfa; }
            set
            {
                if (_fcm_fecini_srfa == value) return;
                _fcm_fecini_srfa = value;
                OnPropertyChanged("Fcm_fecini_srfa");
            }
        }
        #endregion
        #region Fcm_facini_srfa: Numero secuencial inicio
        private int _fcm_facini_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial inicio</para>
        /// <para>NOMBRE: fcm_facini_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde inicia el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facini_srfa
        {
            get { return _fcm_facini_srfa; }
            set
            {
                if (_fcm_facini_srfa == value) return;
                _fcm_facini_srfa = value;
                OnPropertyChanged("Fcm_facini_srfa");
            }
        }
        #endregion
        #region Fcm_facfin_srfa: Numero secuencial fin
        private int _fcm_facfin_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial fin</para>
        /// <para>NOMBRE: fcm_facfin_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde finaliza el consecutivo
        /// </para>
        /// </summary>
        public int Fcm_facfin_srfa
        {
            get { return _fcm_facfin_srfa; }
            set
            {
                if (_fcm_facfin_srfa == value) return;
                _fcm_facfin_srfa = value;
                OnPropertyChanged("Fcm_facfin_srfa");
            }
        }
        #endregion
        // Datos del tercero contable 
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Sis_tipide_tido: Tipo documento
        private String _sis_tipide_tido;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: sis_tipide_tido (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public String Sis_tipide_tido
        {
            get { return _sis_tipide_tido; }
            set
            {
                if (_sis_tipide_tido == value) return;
                _sis_tipide_tido = value;
                OnPropertyChanged("Sis_tipide_tido");
            }
        }
        #endregion
        #region Sis_numide_sitr: Numero dcumento
        private String _sis_numide_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero dcumento</para>
        /// <para>NOMBRE: sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero docuemto de identificacion del tercero
        /// </para>
        /// </summary>
        public String Sis_numide_sitr
        {
            get { return _sis_numide_sitr; }
            set
            {
                if (_sis_numide_sitr == value) return;
                _sis_numide_sitr = value;
                OnPropertyChanged("Sis_numide_sitr");
            }
        }
        #endregion
        #region Sis_telefo_sitr: Telefono
        private String _sis_telefo_sitr;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: sis_telefo_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Numeros de Telefono del tecrcero
        /// </para>
        /// </summary>
        public String Sis_telefo_sitr
        {
            get { return _sis_telefo_sitr; }
            set
            {
                if (_sis_telefo_sitr == value) return;
                _sis_telefo_sitr = value;
                OnPropertyChanged("Sis_telefo_sitr");
            }
        }
        #endregion
        #region Sis_direcc_sitr: Direccion
        private String _sis_direcc_sitr;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Direccion</para>
        /// <para>NOMBRE: sis_direcc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Direccion domicilio del tercero
        /// </para>
        /// </summary>
        public String Sis_direcc_sitr
        {
            get { return _sis_direcc_sitr; }
            set
            {
                if (_sis_direcc_sitr == value) return;
                _sis_direcc_sitr = value;
                OnPropertyChanged("Sis_direcc_sitr");
            }
        }
        #endregion
        // Referencia a documento Dian
        #region lobRegDocDian: Registro del docuemnto radicado en Dian
        /// <summary>
        /// <para>Registro del docuemnto radicado en Dian</para> 
        /// </summary>
        public ModeloFeFacturaMa lobRegDocDian;
        #endregion lobRegDocDian>
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static bool flgAddRegistro(FcmModeloMaestrofacturas tobjModelo)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmaesfacturas();
                    //-----------------------
                    if (tobjModelo.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tobjModelo.Fcm_secreg_mfac);
                    }
                    if (tobjModelo.Sis_estado_imaen == "A" || tobjModelo.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac;
                            lobEFReg.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                            lobEFReg.fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd;
                            lobEFReg.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                            lobEFReg.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                            lobEFReg.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                            lobEFReg.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                            lobEFReg.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                            lobEFReg.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                            lobEFReg.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                            lobEFReg.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                            lobEFReg.fcm_fecfac_mfac = tobjModelo.Fcm_fecfac_mfac;
                            lobEFReg.fcm_diavfa_mfac = (int)tobjModelo.Fcm_diavfa_mfac;
                            lobEFReg.fcm_horfac_mfac = (Decimal)tobjModelo.Fcm_horfac_mfac;
                            lobEFReg.fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac;
                            lobEFReg.fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp;
                            lobEFReg.fcm_fecven_mfac = (DateTime)tobjModelo.Fcm_fecven_mfac;
                            lobEFReg.fcm_codest_fcws = tobjModelo.Fcm_codest_fcws;
                            lobEFReg.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                            lobEFReg.fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac;
                            lobEFReg.fcm_valbsi_dfac = tobjModelo.Fcm_valbsi_dfac;
                            lobEFReg.fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac;
                            lobEFReg.fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac;
                            lobEFReg.fcm_poriva_dfac = tobjModelo.Fcm_poriva_dfac;
                            lobEFReg.fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac;
                            lobEFReg.fcm_valcpa_dfac = tobjModelo.Fcm_valcpa_dfac;
                            lobEFReg.fcm_valcmo_dfac = tobjModelo.Fcm_valcmo_dfac;
                            lobEFReg.fcm_valusu_dfac = tobjModelo.Fcm_valusu_dfac;
                            lobEFReg.fcm_valcom_dfac = tobjModelo.Fcm_valcom_dfac;
                            lobEFReg.fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac;
                            lobEFReg.fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac;
                            lobEFReg.fcm_valref_dfac = tobjModelo.Fcm_valref_dfac;
                            lobEFReg.fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac;
                            lobEFReg.fcm_fecedt_mfac = tobjModelo.Fcm_fecedt_mfac;
                            lobEFReg.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                            lobEFReg.fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac;
                            lobEFReg.sia_regate_rgat = tobjModelo.Sia_regate_rgat;
                            lobEFReg.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                            lobEFReg.fcm_fecanu_mfac = tobjModelo.Fcm_fecanu_mfac;
                            lobEFReg.fcm_horanu_mfac = tobjModelo.Fcm_horanu_mfac;
                            lobEFReg.sys_usuanu_usux = tobjModelo.Sys_usuanu_usux;
                            lobEFReg.fcm_notanu_mfac = tobjModelo.Fcm_notanu_mfac;
                            lobEFReg.fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac;
                            lobEFReg.sia_tipact_tsac = tobjModelo.Sia_tipact_tsac;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        switch (tobjModelo.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                _context.AddToFcmmaesfacturas(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tobjModelo.Fcm_secreg_mfac);
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
        #region Modificar Registro
        public static void fcvActualizar(FcmModeloMaestrofacturas tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tobjModelo.Fcm_secreg_mfac);
                if (lobjRegistro != null)
                {
                    #region cargar Registro
                    lobjRegistro.fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac;
                    lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                    lobjRegistro.fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd;
                    lobjRegistro.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                    lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                    lobjRegistro.fcm_fecfac_mfac = (DateTime)tobjModelo.Fcm_fecfac_mfac;
                    lobjRegistro.fcm_diavfa_mfac = (int)tobjModelo.Fcm_diavfa_mfac;
                    lobjRegistro.fcm_horfac_mfac = (Decimal)tobjModelo.Fcm_horfac_mfac;
                    lobjRegistro.fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac;
                    lobjRegistro.fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp;
                    lobjRegistro.fcm_fecven_mfac = (DateTime)tobjModelo.Fcm_fecven_mfac;
                    lobjRegistro.fcm_codest_fcws = tobjModelo.Fcm_codest_fcws;
                    lobjRegistro.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                    lobjRegistro.fcm_valbru_dfac = (float)tobjModelo.Fcm_valbru_dfac;
                    lobjRegistro.fcm_valbsi_dfac = (float)tobjModelo.Fcm_valbsi_dfac;
                    lobjRegistro.fcm_pordes_dfac = (float)tobjModelo.Fcm_pordes_dfac;
                    lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                    lobjRegistro.fcm_poriva_dfac = (float)tobjModelo.Fcm_poriva_dfac;
                    lobjRegistro.fcm_valiva_dfac = (float)tobjModelo.Fcm_valiva_dfac;
                    lobjRegistro.fcm_valcpa_dfac = (float)tobjModelo.Fcm_valcpa_dfac;
                    lobjRegistro.fcm_valcmo_dfac = (float)tobjModelo.Fcm_valcmo_dfac;
                    lobjRegistro.fcm_valusu_dfac = (float)tobjModelo.Fcm_valusu_dfac;
                    lobjRegistro.fcm_valcom_dfac = (float)tobjModelo.Fcm_valcom_dfac;
                    lobjRegistro.fcm_valsub_dfac = (float)tobjModelo.Fcm_valsub_dfac;
                    lobjRegistro.fcm_valfac_dfac = (float)tobjModelo.Fcm_valfac_dfac;
                    lobjRegistro.fcm_valref_dfac = (float)tobjModelo.Fcm_valref_dfac;
                    lobjRegistro.fcm_valefe_dfac = (float)tobjModelo.Fcm_valefe_dfac;
                    lobjRegistro.fcm_fecedt_mfac = (DateTime)tobjModelo.Fcm_fecedt_mfac;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac;
                    lobjRegistro.sia_regate_rgat = tobjModelo.Sia_regate_rgat;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.fcm_fecanu_mfac = tobjModelo.Fcm_fecanu_mfac;
                    lobjRegistro.fcm_horanu_mfac = tobjModelo.Fcm_horanu_mfac;
                    lobjRegistro.sys_usuanu_usux = tobjModelo.Sys_usuanu_usux;
                    lobjRegistro.fcm_notanu_mfac = tobjModelo.Fcm_notanu_mfac;
                    lobjRegistro.fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac;
                    #endregion cargar Registro

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
                var lobjRegistro = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        // Gestion adicional
        #region fcvActualizarEstados: Actualizar estados facturas
        /// <summary>
        ///  <para>Actualizar: Estado facturacion</para>
        /// </summary>
        public static void fcvActualizarEstados(String tcrIdOrdenServicio, String tcrEstFact)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tcrIdOrdenServicio);
                if (lobReg != null)
                {
                    lobReg.fcm_estfac_mfac = tcrEstFact;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEstadosFacturas: Actualizar estados facturas 
        /// <summary>
        ///  <para>Actualizar: Estado facturacion para una admision</para>
        /// </summary>
        public static void fcvActualizarEstadosFacturas(String tcrCodigoAdmision, String tcrEstadoFact)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Fcmmaesfacturas where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    var lcrEstTipo = "1";

                    foreach (var lobReg in lobConsulta)
                    {
                        lcrEstTipo = "1";
                        if (tcrEstadoFact == "2")
                        {
                            lcrEstTipo = "2";
                        }
                        else if (tcrEstadoFact == "3")
                        {
                            lcrEstTipo = lobReg.fcm_tiprfa_mfac;
                        }
                        lobReg.fcm_tiprfa_mfac = lcrEstTipo;
                        lobReg.fcm_estfac_mfac = tcrEstadoFact;
                    }
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarAnularFactura: Anular Factura
        /// <summary>
        ///  <para>Actualizar los datos en la factura anulada (cambiar el estado y llenar los datos adicionales)</para>
        /// </summary>
        public static void fcvAnularFactura(String tcrIdOrdenServicio, DateTime tdaFecha, Decimal tdeHora, String tcrIdUsuario, String tcrNota)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tcrIdOrdenServicio);
                if (lobReg != null)
                {
                    lobReg.fcm_fecanu_mfac = tdaFecha;
                    lobReg.fcm_horanu_mfac = tdeHora;
                    lobReg.sys_usuanu_usux = tcrIdUsuario;
                    lobReg.fcm_notanu_mfac = tcrNota;
                    lobReg.fcm_estfac_mfac = "3";

                    _context.SaveChanges();
                }
            }
        }
        #endregion
        // Gestion Datos para factura DIAN
        #region FlgGuardarDocumentoDian: Genera los datos para guardar en base de datos 
        /// <summary>
        /// Genera los datos para guardar en base de datos documentos DIAN
        /// </summary>
        /// <param name="tobjModelo"></param>
        /// <param name="tobRegDetalles"></param>
        /// <param name="tcrMensaje"></param>
        /// <returns></returns>
        public static bool FlgGuardarDocumentoDian(FcmModeloMaestrofacturas tobRegMaestro, List<FcmModeloServDetallFacturas> tmpRegDetalles, out string tcrMensaje)
        {
            var llgReturn = true;
            tcrMensaje = null;
            List<ModeloFeFacturaMd> tmpDetalles;

            try
            {
                // Maestro
                var lobjRegistro = new ModeloFeFacturaMa
                {
                    #region cargar Registro
                    Fcm_secreg_mfac = tobRegMaestro.Fcm_secreg_mfac,
                    Fcm_secraz_fcem = tobRegMaestro.Fcm_secraz_fcem,
                    Fcm_numfac_mfac = tobRegMaestro.Fcm_numfac_mfac,
                    Fcm_typdoc_fctd = tobRegMaestro.Fcm_typdoc_fctd,
                    Fcm_fecfac_mfac = tobRegMaestro.Fcm_fecfac_mfac,
                    Fcm_horfac_mfac = tobRegMaestro.Fcm_horfac_mfac,
                    Fcm_notdoc_mfac = "Servicios medicos prestados a usuarios pacientes",
                    Fcm_forpag_mfac = tobRegMaestro.Fcm_metpag_mfac,
                    Fcm_facori_mfac = "03",
                    Fcm_secres_srfa = tobRegMaestro.Fcm_secres_srfa,
                    Adm_secadm_rgad = tobRegMaestro.Adm_secadm_rgad,
                    Sia_idesec_usua = tobRegMaestro.Sia_idesec_usua,
                    Cto_seccon_cont = tobRegMaestro.Cto_seccon_cont,
                    Sia_codeps_teps = tobRegMaestro.Sia_codeps_teps,
                    Sis_idterc_sitr = tobRegMaestro.Sis_idterc_sitr,
                    Fcm_sercre_mfac = "NA",
                    Fcm_idrcre_mfac = "NA",
                    Fcm_serdeb_mfac = "NA",
                    Fcm_idrdeb_mfac = "NA",
                    //Fcm_valbsi_dfac = tobRegMaestro.Fcm_valiva_dfac > 0 ? tobRegMaestro.Fcm_valbru_dfac : 0,
                    Fcm_valbsi_dfac = (decimal)tobRegMaestro.Fcm_valbsi_dfac,
                    Fcm_valiva_dfac = (decimal)tobRegMaestro.Fcm_valiva_dfac,
                    Fcm_valicd_dfac = 0,
                    Fcm_valica_dfac = 0,
                    Fcm_valinc_dfac = 0,
                    Fcm_valrti_dfac = 0,
                    Fcm_valrtf_dfac = 0,
                    Fcm_valrtc_dfac = 0,
                    Fcm_valcre_dfac = 0,
                    Fcm_valfth_dfac = 0,
                    Fcm_valtim_dfac = 0,
                    Fcm_valbol_dfac = 0,
                    Fcm_valicr_dfac = 0,
                    Fcm_valicb_dfac = 0,
                    Fcm_valscb_dfac = 0,
                    Fcm_valsco_dfac = 0,
                    Fcm_valftr_dfac = 0,
                    Fcm_pordes_dfac = (decimal)tobRegMaestro.Fcm_pordes_dfac,
                    Fcm_valdes_dfac = (decimal)tobRegMaestro.Fcm_valdes_dfac, // Viene de incluir cuentas de cobro
                    Fcm_valcpa_dfac = (decimal)tobRegMaestro.Fcm_valcpa_dfac, // Viene de incluir cuentas de cobro
                    Fcm_valcmo_dfac = (decimal)tobRegMaestro.Fcm_valcmo_dfac, // Viene de incluir cuentas de cobro
                    Fcm_valusu_dfac = 0,                             // Viene de incluir cuentas de cobro
                    Fcm_valbru_dfac = (decimal)tobRegMaestro.Fcm_valbru_dfac,
                    Fcm_valsub_dfac = (decimal)tobRegMaestro.Fcm_valsub_dfac,
                    Fcm_valfac_dfac = (decimal)tobRegMaestro.Fcm_valfac_dfac,
                    Fcm_valref_dfac = 0,
                    Fcm_valefe_dfac = 0,
                    Fcm_idcufe_mfac = "NA",
                    Fcm_diafec_mfac = DateTime.Parse("01/01/0001"),
                    Fcm_diahor_mfac = 0,
                    Fcm_codest_fcws = "P01",  // "P01" = Pendiente para enviar a DIAN
                    Fcm_nomarc_mfac = "NA",
                    Fcm_secrad_mfac = 0, // Lo asigna la funcion que guarda dentro de la tabla Maestro Facturas Dian
                    Fcm_trakid_mfac = "NA", // cuando ya existe el registro de esta factura lo conserva la tabla Maestro Facturas
                    Fcm_adqfec_mfac = DateTime.Parse("01/01/0001"),
                    Fcm_adqhor_mfac = 0,
                    Fcm_codest_fcaq = "A01", // Pendiente por enviar al adquirente por correo
                    Fcm_metpag_mfac = tobRegMaestro.Fcm_metpag_mfac, // 2 por defecto
                    Fcm_codmpg_fcmp = tobRegMaestro.Fcm_codmpg_fcmp, // "ZZZ" = Acuerdo mutuo
                    Fcm_fecven_mfac = tobRegMaestro.Fcm_fecven_mfac,
                    Fcm_idepag_fcmp = "1", // FAN05 - "1"=Instrumento no definido (asi esta en la norma)
                    Fcm_fecanu_mfac = tobRegMaestro.Fcm_fecanu_mfac, //DateTime.Parse("01/01/0001"),
                    Fcm_horanu_mfac = tobRegMaestro.Fcm_horanu_mfac,
                    Sys_usuanu_usux = tobRegMaestro.Sys_usuanu_usux,
                    Fcm_notanu_mfac = "NA",
                    Fcm_algori_mfac = "SHA384",
                    Fcm_conest_mfac = 0,
                    Fcm_fecedt_mfac = Funciones.FdaFechaActual(),
                    Sys_codusu_usux = tobRegMaestro.Sys_codusu_usux,
                    Fcm_tiprfa_mfac = "2", // 1= Registro ordenes de servicios (pre factura) 2= Numero de Factura Valida Dian
                    Fcm_estfac_mfac = "2", // confirmado
                    Fcm_errore_mfac = "NA",
                    #endregion
                };

                // Actualizar los registros detalles
                if (tmpRegDetalles != null)
                {
                    ModeloFeFacturaMd lobjRegDetalle = null;
                    tmpDetalles = new List<ModeloFeFacturaMd>();

                    foreach (var lobReg in tmpRegDetalles)
                    {
                        lobjRegDetalle = new ModeloFeFacturaMd
                        {
                            #region cargar Registro
                            Fcm_secreg_dfac = lobReg.Fcm_secreg_dfac,
                            Fcm_secreg_mfac = lobReg.Fcm_secreg_mfac,
                            Fcm_numfac_mfac = tobRegMaestro.Fcm_numfac_mfac,
                            Fcm_idesec_mant = lobReg.Fcm_idesec_mant,
                            Fcm_tiptar_dfac = "999",                  // 999 Tarifario propio   
                            Fcm_codpro_fcpr = lobReg.Fcm_codpro_fcpr,
                            Fcm_codbar_mant = lobReg.Fcm_codbar_sips,
                            Fcm_codser_mant = lobReg.Fcm_codser_mant, // por ahora pero toca crear fcm_codser_mant en la tabla
                            Fcm_coddig_mant = lobReg.Fcm_coddig_mant, // por ahora pero toca crear fcm_coddig_mant en la tabla
                            Fcm_codman_mans = lobReg.Fcm_codman_mans,
                            Fcm_desser_dfac = lobReg.Fcm_desser_dfac,
                            Fcm_fecser_dfac = tobRegMaestro.Fcm_fecfac_mfac,
                            Fcm_horser_dfac = tobRegMaestro.Fcm_horfac_mfac,
                            Fcm_valser_mant = (decimal)lobReg.Fcm_valser_mant,
                            Fcm_totuni_dfac = lobReg.Fcm_totuni_dfac,
                            Fcm_valbru_dfac = (decimal)lobReg.Fcm_valbru_dfac,
                            Fcm_valbsi_dfac = lobReg.Fcm_valiva_dfac > 0 ? (decimal)lobReg.Fcm_valbru_dfac : 0,
                            Fcm_poriva_dfac = (decimal)lobReg.Fcm_poriva_dfac,
                            Fcm_valiva_dfac = (decimal)lobReg.Fcm_valiva_dfac,
                            Fcm_poricd_dfac = 0,
                            Fcm_valicd_dfac = 0,
                            Fcm_porica_dfac = 0,
                            Fcm_valica_dfac = 0,
                            Fcm_porinc_dfac = 0,
                            Fcm_valinc_dfac = 0,
                            Fcm_porrti_dfac = 0,
                            Fcm_valrti_dfac = 0,
                            Fcm_porrtf_dfac = 0,
                            Fcm_valrtf_dfac = 0,
                            Fcm_porrtc_dfac = 0,
                            Fcm_valrtc_dfac = 0,
                            Fcm_porcre_dfac = 0,
                            Fcm_valcre_dfac = 0,
                            Fcm_porfth_dfac = 0,
                            Fcm_valfth_dfac = 0,
                            Fcm_portim_dfac = 0,
                            Fcm_valtim_dfac = 0,
                            Fcm_porbol_dfac = 0,
                            Fcm_valbol_dfac = 0,
                            Fcm_poricr_dfac = 0,
                            Fcm_valicr_dfac = 0,
                            Fcm_poricb_dfac = 0,
                            Fcm_valicb_dfac = 0,
                            Fcm_porscb_dfac = 0,
                            Fcm_valscb_dfac = 0,
                            Fcm_porsco_dfac = 0,
                            Fcm_valsco_dfac = 0,
                            Fcm_porftr_dfac = 0,
                            Fcm_valftr_dfac = 0,
                            Sis_coddes_side = "NA",
                            Fcm_pordes_dfac = (decimal)lobReg.Fcm_pordes_dfac,
                            Fcm_valdes_dfac = (decimal)lobReg.Fcm_valdes_dfac,
                            Fcm_valsub_dfac = (decimal)lobReg.Fcm_valsub_dfac,
                            Fcm_valfac_dfac = (decimal)lobReg.Fcm_valfac_dfac,
                            Fcm_valref_dfac = 0,
                            Fcm_valefe_dfac = 0,
                            Sis_estpro_espr = "2",
                            #endregion
                        };
                        tmpDetalles.Add(lobjRegDetalle);
                    }
                    lobjRegistro.tmpListVenta = tmpDetalles;

                    if (!ModeloFeFacturaMa.FlgActualizar(lobjRegistro, out tcrMensaje))
                    {
                        llgReturn = false;
                    }
                }
                else
                {
                    tcrMensaje = "No hay registros detalles de ventas";
                    llgReturn = false;
                }

            }
            catch (Exception ex)
            {
                llgReturn = false;
                tcrMensaje = $"Error Metodo FlgGuardarDocumentoDian: {ex.Message}";
                return llgReturn;
            }
            return llgReturn;
        }
        #endregion
        #region FlgActualizarParametros: Actualziar estado gestion Dian
        /// <summary>
        /// Actualziar el estado gestion Dian
        /// </summary>
        /// <param name="tobRegistro">Rgistro que contiene los datos para actualizar</param>
        public static bool FlgActualizarParametros(FcmModeloMaestrofacturas tobRegistro, out string tcrMensaje)
        {
            var llgReturn = true;
            tcrMensaje = null;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_codest_fcws = tobRegistro.Fcm_codest_fcws;
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
                tcrMensaje = "Error al actualizar Maestro facturas metodo fcvActualizar: " + ex.Message;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
            }
            return llgReturn;
        }
        #endregion
        // Consultas
        #region Buscar FCMMAESFACTURAS: Logica
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TITULO: Maestro de facturas - Ordenes de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas de servicios medicos prestados a pacientes
        /// (maestro de facturacion ordenes medicas)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaesfacturas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaesfacturas.FirstOrDefault(p => p.fcm_secreg_mfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<FcmModeloMaestrofacturas> flsListaFcmmaesfacturas(String tcrCodigoAdm, String tcrEstadoRegistro)
        {
            List<FcmModeloMaestrofacturas> lobConsulta;
            using (_context = new DbAplicacion())
            {
                var lcrEstado1 = Funciones.fuxExtraerElemento(1, "*", tcrEstadoRegistro); // Abiertas
                var lcrEstado2 = Funciones.fuxExtraerElemento(2, "*", tcrEstadoRegistro); // Cerradas
                var lcrEstado3 = Funciones.fuxExtraerElemento(3, "*", tcrEstadoRegistro); // Anuladas

                lobConsulta = (from fcmmaesfacturas in _context.Fcmmaesfacturas
                                  join siausuarioatend in _context.Siausuarioatend on fcmmaesfacturas.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join siatablaeps in _context.Siatablaeps on fcmmaesfacturas.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                  join ctomaescontrato in _context.Ctomaescontrato on fcmmaesfacturas.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                  join fcmsecrfacturas in _context.Fcmsecrfacturas on fcmmaesfacturas.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                  join sismaesterceros in _context.Sismaesterceros on fcmmaesfacturas.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from teps in tmsiatablaeps.DefaultIfEmpty()
                                  from cont in tmctomaescontrato.DefaultIfEmpty()
                                  from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  where fcmmaesfacturas.adm_secadm_rgad == tcrCodigoAdm &&
                                        (fcmmaesfacturas.fcm_estfac_mfac == lcrEstado1 ||
                                         fcmmaesfacturas.fcm_estfac_mfac == lcrEstado2 ||
                                         fcmmaesfacturas.fcm_estfac_mfac == lcrEstado3)
                                  select new FcmModeloMaestrofacturas
                                  {
                                      #region Datos
                                      Fcm_secreg_mfac = fcmmaesfacturas.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac,
                                      Fcm_typdoc_fctd = fcmmaesfacturas.fcm_typdoc_fctd,
                                      Fcm_secraz_fcem = fcmmaesfacturas.fcm_secraz_fcem,
                                      Fcm_secres_srfa = fcmmaesfacturas.fcm_secres_srfa,
                                      Adm_secadm_rgad = fcmmaesfacturas.adm_secadm_rgad,
                                      Sia_idesec_usua = fcmmaesfacturas.sia_idesec_usua,
                                      Sia_tipide_tide = fcmmaesfacturas.sia_tipide_tide,
                                      Sia_nroide_usua = fcmmaesfacturas.sia_nroide_usua,
                                      Cto_seccon_cont = fcmmaesfacturas.cto_seccon_cont,
                                      Cto_nrocon_cont = fcmmaesfacturas.cto_nrocon_cont,
                                      Sia_codeps_teps = fcmmaesfacturas.sia_codeps_teps,
                                      Sis_idterc_sitr = fcmmaesfacturas.sis_idterc_sitr,
                                      Fcm_fecfac_mfac = (DateTime)fcmmaesfacturas.fcm_fecfac_mfac,
                                      Fcm_diavfa_mfac = (int)fcmmaesfacturas.fcm_diavfa_mfac,
                                      Fcm_horfac_mfac = (Decimal)fcmmaesfacturas.fcm_horfac_mfac,
                                      Fcm_metpag_mfac = fcmmaesfacturas.fcm_metpag_mfac,
                                      Fcm_codmpg_fcmp = fcmmaesfacturas.fcm_codmpg_fcmp,
                                      Fcm_fecven_mfac = (DateTime)fcmmaesfacturas.fcm_fecven_mfac,
                                      Fcm_codest_fcws = fcmmaesfacturas.fcm_codest_fcws,
                                      Fcm_autdes_ades = fcmmaesfacturas.fcm_autdes_ades,
                                      Fcm_valbru_dfac = (float)fcmmaesfacturas.fcm_valbru_dfac,
                                      Fcm_valbsi_dfac = (float)fcmmaesfacturas.fcm_valbsi_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaesfacturas.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaesfacturas.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)fcmmaesfacturas.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)fcmmaesfacturas.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)fcmmaesfacturas.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)fcmmaesfacturas.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)fcmmaesfacturas.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)fcmmaesfacturas.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)fcmmaesfacturas.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)fcmmaesfacturas.fcm_valfac_dfac,
                                      Fcm_valref_dfac = (float)fcmmaesfacturas.fcm_valref_dfac,
                                      Fcm_valefe_dfac = (float)fcmmaesfacturas.fcm_valefe_dfac,
                                      Fcm_fecedt_mfac = (DateTime)fcmmaesfacturas.fcm_fecedt_mfac,
                                      Sys_codusu_usux = fcmmaesfacturas.sys_codusu_usux,
                                      Fcm_tiprfa_mfac = fcmmaesfacturas.fcm_tiprfa_mfac,
                                      Sia_regate_rgat = fcmmaesfacturas.sia_regate_rgat,
                                      Sia_tipact_tsac = fcmmaesfacturas.sia_tipact_tsac,
                                      Sia_codcat_ceat = fcmmaesfacturas.sia_codcat_ceat,
                                      Fcm_fecanu_mfac = (DateTime)fcmmaesfacturas.fcm_fecanu_mfac,
                                      Fcm_horanu_mfac = (Decimal)fcmmaesfacturas.fcm_horanu_mfac,
                                      Sys_usuanu_usux = fcmmaesfacturas.sys_usuanu_usux,
                                      Fcm_notanu_mfac = fcmmaesfacturas.fcm_notanu_mfac,
                                      Fcm_estfac_mfac = fcmmaesfacturas.fcm_estfac_mfac,
                                      Fcm_desfac_mfac = fcmmaesfacturas.fcm_estfac_mfac == "2" ? "CONFIRMADA" : fcmmaesfacturas.fcm_estfac_mfac == "1"? "ABIERTA": "ANULADA",
                                      Sia_desact_tsac = _context.Siatipactividad.FirstOrDefault(rxp => rxp.sia_tipact_tsac == fcmmaesfacturas.sia_tipact_tsac).sia_desact_tsac,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sia_deseps_teps = teps.sia_deseps_teps,
                                      Sia_codnit_teps = teps.sia_codnit_teps,
                                      Cto_descon_cont = cont.cto_descon_cont,
                                      Cto_dedcop_cont = cont.cto_dedcop_cont,
                                      Cto_fcdian_cont = cont.cto_fcdian_cont,
                                      Fcm_numres_srfa = srfa.fcm_numres_srfa,
                                      Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                      Fcm_notenc_srfa = srfa.fcm_notenc_srfa,
                                      Fcm_noppag_srfa = srfa.fcm_noppag_srfa,
                                      Fcm_fecini_srfa = (DateTime)srfa.fcm_fecini_srfa,
                                      Fcm_facini_srfa = (int)srfa.fcm_facini_srfa,
                                      Fcm_facfin_srfa = (int)srfa.fcm_facfin_srfa,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      Sis_tipide_tido = sitr.sis_tipide_tido,
                                      Sis_numide_sitr = sitr.sis_numide_sitr,
                                      Sis_telefo_sitr = sitr.sis_telefo_sitr,
                                      Sis_direcc_sitr = sitr.sis_direcc_sitr,
                                      Sys_nousua_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == fcmmaesfacturas.sys_usuanu_usux).sys_nomusu_usux,
                                      Fcm_tipdes_mfac = "1",
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  }).ToList(); 
            }

            if (lobConsulta != null)
            {
                foreach(var lobReg in lobConsulta)
                {
                    if (lobReg.Fcm_codest_fcws != null)
                    {
                        if (lobReg.Fcm_estfac_mfac == "2" &&
                            lobReg.Fcm_codest_fcws != "NA" &&
                            String.IsNullOrEmpty(lobReg.Fcm_codest_fcws) == false)
                        {
                            lobReg.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", lobReg.Fcm_secreg_mfac);
                            if (lobReg.lobRegDocDian != null)
                            {
                                lobReg.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // Para que el Timer Recargue los datos de la vista
                            }
                        }
                    }
                }
            }

            return lobConsulta;
        }
        #endregion
        #region Listar Registros FACTURAS simple
        public static List<FcmModeloMaestrofacturas> FlsListaFcmmaesfacturasSimple(String tcrCodigoAdm, String tcrEstadoRegistro)
        {
            List<FcmModeloMaestrofacturas> lobConsulta;
            using (_context = new DbAplicacion())
            {
                var lcrEstado1 = Funciones.fuxExtraerElemento(1, "*", tcrEstadoRegistro); // Abiertas
                var lcrEstado2 = Funciones.fuxExtraerElemento(2, "*", tcrEstadoRegistro); // Cerradas
                var lcrEstado3 = Funciones.fuxExtraerElemento(3, "*", tcrEstadoRegistro); // Anuladas

                lobConsulta = (from fcmmaesfacturas in _context.Fcmmaesfacturas
                               where fcmmaesfacturas.adm_secadm_rgad == tcrCodigoAdm &&
                                     (fcmmaesfacturas.fcm_estfac_mfac == lcrEstado1 ||
                                      fcmmaesfacturas.fcm_estfac_mfac == lcrEstado2 ||
                                      fcmmaesfacturas.fcm_estfac_mfac == lcrEstado3)
                               select new FcmModeloMaestrofacturas
                               {
                                   #region Datos
                                   Fcm_secreg_mfac = fcmmaesfacturas.fcm_secreg_mfac,
                                   Fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac,
                                   Fcm_typdoc_fctd = fcmmaesfacturas.fcm_typdoc_fctd,
                                   Fcm_secraz_fcem = fcmmaesfacturas.fcm_secraz_fcem,
                                   Fcm_secres_srfa = fcmmaesfacturas.fcm_secres_srfa,
                                   Adm_secadm_rgad = fcmmaesfacturas.adm_secadm_rgad,
                                   Sia_idesec_usua = fcmmaesfacturas.sia_idesec_usua,
                                   Sia_tipide_tide = fcmmaesfacturas.sia_tipide_tide,
                                   Sia_nroide_usua = fcmmaesfacturas.sia_nroide_usua,
                                   Cto_seccon_cont = fcmmaesfacturas.cto_seccon_cont,
                                   Cto_nrocon_cont = fcmmaesfacturas.cto_nrocon_cont,
                                   Sia_codeps_teps = fcmmaesfacturas.sia_codeps_teps,
                                   Sis_idterc_sitr = fcmmaesfacturas.sis_idterc_sitr,
                                   Fcm_fecfac_mfac = (DateTime)fcmmaesfacturas.fcm_fecfac_mfac,
                                   Fcm_diavfa_mfac = (int)fcmmaesfacturas.fcm_diavfa_mfac,
                                   Fcm_horfac_mfac = (Decimal)fcmmaesfacturas.fcm_horfac_mfac,
                                   Fcm_metpag_mfac = fcmmaesfacturas.fcm_metpag_mfac,
                                   Fcm_codmpg_fcmp = fcmmaesfacturas.fcm_codmpg_fcmp,
                                   Fcm_fecven_mfac = (DateTime)fcmmaesfacturas.fcm_fecven_mfac,
                                   Fcm_codest_fcws = fcmmaesfacturas.fcm_codest_fcws,
                                   Fcm_autdes_ades = fcmmaesfacturas.fcm_autdes_ades,
                                   Fcm_valbru_dfac = (float)fcmmaesfacturas.fcm_valbru_dfac,
                                   Fcm_valbsi_dfac = (float)fcmmaesfacturas.fcm_valbsi_dfac,
                                   Fcm_pordes_dfac = (float)fcmmaesfacturas.fcm_pordes_dfac,
                                   Fcm_valdes_dfac = (float)fcmmaesfacturas.fcm_valdes_dfac,
                                   Fcm_poriva_dfac = (float)fcmmaesfacturas.fcm_poriva_dfac,
                                   Fcm_valiva_dfac = (float)fcmmaesfacturas.fcm_valiva_dfac,
                                   Fcm_valcpa_dfac = (float)fcmmaesfacturas.fcm_valcpa_dfac,
                                   Fcm_valcmo_dfac = (float)fcmmaesfacturas.fcm_valcmo_dfac,
                                   Fcm_valusu_dfac = (float)fcmmaesfacturas.fcm_valusu_dfac,
                                   Fcm_valcom_dfac = (float)fcmmaesfacturas.fcm_valcom_dfac,
                                   Fcm_valsub_dfac = (float)fcmmaesfacturas.fcm_valsub_dfac,
                                   Fcm_valfac_dfac = (float)fcmmaesfacturas.fcm_valfac_dfac,
                                   Fcm_valref_dfac = (float)fcmmaesfacturas.fcm_valref_dfac,
                                   Fcm_valefe_dfac = (float)fcmmaesfacturas.fcm_valefe_dfac,
                                   Fcm_fecedt_mfac = (DateTime)fcmmaesfacturas.fcm_fecedt_mfac,
                                   Sys_codusu_usux = fcmmaesfacturas.sys_codusu_usux,
                                   Fcm_tiprfa_mfac = fcmmaesfacturas.fcm_tiprfa_mfac,
                                   Sia_regate_rgat = fcmmaesfacturas.sia_regate_rgat,
                                   Sia_tipact_tsac = fcmmaesfacturas.sia_tipact_tsac,
                                   Sia_codcat_ceat = fcmmaesfacturas.sia_codcat_ceat,
                                   Fcm_fecanu_mfac = (DateTime)fcmmaesfacturas.fcm_fecanu_mfac,
                                   Fcm_horanu_mfac = (Decimal)fcmmaesfacturas.fcm_horanu_mfac,
                                   Sys_usuanu_usux = fcmmaesfacturas.sys_usuanu_usux,
                                   Fcm_notanu_mfac = fcmmaesfacturas.fcm_notanu_mfac,
                                   Fcm_estfac_mfac = fcmmaesfacturas.fcm_estfac_mfac,
                                   Fcm_desfac_mfac = fcmmaesfacturas.fcm_estfac_mfac == "2" ? "CONFIRMADA" : fcmmaesfacturas.fcm_estfac_mfac == "1" ? "ABIERTA" : "ANULADA",
                                   Fcm_tipdes_mfac = "1",
                                   Sis_estado_imaen = "I",
                                   #endregion
                               }).ToList();
            }

            return lobConsulta;
        }
        #endregion
        // Abrir facturas
        #region fcvReAbrirFacturacion: Abrir facturacion desde la opcion especial para una admision
        /// <summary>
        ///  <para>Abrir facturacion desde la opcion especial para una admision</para>
        /// </summary>
        public static void fcvReAbrirFacturacion(String tcrCodigoAdmision)
        {
            var lcrGenerarNumFact = Funciones.fcrLeerConfigVarSistema("FCM-PRNFAC-NUMFACTURA-RW", "1");
            var lobConsFact = FlsListaFcmmaesfacturasSimple(tcrCodigoAdmision, "2");

            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Fcmmaesfacturas where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {

                        if (lobReg.fcm_codest_fcws != "R01") // solo las que no estan cargadas en DIAN
                        {
                            lobReg.fcm_numfac_mfac = lcrGenerarNumFact == "1" ? "PREFACTURA" : lobReg.fcm_numfac_mfac;
                            lobReg.fcm_tiprfa_mfac = "1";
                            lobReg.fcm_estfac_mfac = "1";
                        }
                    }
                }

                var lobDetalle = from tmp in _context.Fcmmaedetallfac where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobDetalle != null && lobConsFact != null)
                {
                    foreach (var lobReg in lobDetalle)
                    {
                        var lobRegFac = lobConsFact.FirstOrDefault(x => x.Fcm_numfac_mfac == lobReg.fcm_numfac_mfac);

                        if (lobRegFac != null)
                        {
                            // solo facturas que no estan enviadas a la Dian
                            if (lobRegFac.Fcm_codest_fcws != "R01")
                            {
                                lobReg.fcm_numfac_mfac = lcrGenerarNumFact == "1" ? "PREFACTURA" : lobReg.fcm_numfac_mfac;
                                lobReg.fcm_tiprfa_mfac = "1";
                                lobReg.fcm_estfac_mfac = "1";
                                lobReg.sis_estpro_espr = "1";
                            }
                        }
                    }
                }

                // Guardar cambios
                _context.SaveChanges();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Vista tabla: fcmmaedetallfac detalles de facturacion
    /// </summary>
    public class FcmModeloServDetallFacturas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _fcm_secreg_dfac;
        private String _adm_secadm_rgad;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private String _cto_seccon_cont;
        private String _cto_nrocon_cont;
        private String _sia_codeps_teps;
        private String _sis_idterc_sitr;
        private String _fcm_secreg_mfac;
        private String _fcm_numfac_mfac;
        private DateTime _fcm_fecfac_mfac;
        private String _fcm_estfac_mfac;
        private String _adm_nroaut_rgad;
        private String _sia_codrip_trip;
        private String _fcm_idesec_sips;
        private String _fcm_codbar_sips;
        private String _fcm_idesec_mant;
        private String _fcm_codser_mant;
        private String _fcm_coddig_mant;
        private String _con_codsco_ccos;
        private String _fcm_codcpr_cpro;
        private String _fcm_desser_dfac;
        private String _fcm_codman_mans;
        private DateTime _fcm_fecser_dfac;
        private Decimal _fcm_horser_dfac;
        private String _fcm_perman_sips;
        private String _fcm_forfar_sips;
        private String _fcm_conmed_sips;
        private String _fcm_unimed_sips;
        private String _fcm_autdes_ades;
        private float _fcm_valser_mant;
        private int _fcm_totuni_dfac;
        private float _fcm_valbru_dfac;
        private float _fcm_pordes_dfac;
        private float _fcm_valdes_dfac;
        private float _fcm_poriva_dfac;
        private float _fcm_valiva_dfac;
        private float _fcm_valcpa_dfac;
        private float _fcm_valcmo_dfac;
        private float _fcm_valusu_dfac;
        private float _fcm_valcom_dfac;
        private float _fcm_valsub_dfac;
        private float _fcm_valfac_dfac;
        private float _fcm_valref_dfac;
        private float _fcm_valefe_dfac;
        private String _fcm_codtse_sips;
        private String _fcm_codaqx_aqir;
        private String _sia_tipact_tsac;
        private String _adm_codtat_tatn;
        private String _sia_codfpr_fpor;
        private String _sia_codfco_fcon;
        private String _adm_codcex_tcex;
        private String _sia_coddia_tdia;
        private String _sia_tipdxp_tdix;
        private String _sia_coddx1_tdia;
        private String _sia_coddx2_tdia;
        private String _sia_coddx3_tdia;
        private String _sia_coddxc_tdia;
        private String _sia_codgac_gpyp;
        private String _sia_codact_apyp;
        private String _fcm_serpos_sips;
        private String _cto_tipact_cont;
        private String _sia_codpat_tpat;
        private String _sia_codpfa_prof;
        private Decimal _fac_horprs_dfac;
        private String _fcm_atepro_dfac;
        private String _sia_codare_aser;
        private String _desia_aresol_aser;
        private String _sia_aresol_aser;
        private String _fcm_tipser_sips;
        private DateTime _fcm_fecedt_dfac;
        private String _sys_codusu_usux;
        private String _sia_regate_rgat;
        private String _sia_codcat_ceat;
        private String _fcm_ripsco_dfac;
        private String _inv_codgme_mgme;
        private String _inv_coduma_muma;
        private String _sis_estpro_espr;
        private String _cto_descon_cont;
        private String _sia_deseps_teps;
        private String _fcm_descpr_cpro;
        private String _fcm_desman_mans;
        private String _fcm_desaqx_aqir;
        private String _sia_desact_tsac;
        private String _sia_nompro_prof;
        private String _sia_desare_aser;
        private String _sis_estado_imaen;
        private String _cto_sepser_cont;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_dfac: Código Único registro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico del registro o servicio facturado , generado
        /// por el sistema
        /// </para>
        /// </summary>
        public String Fcm_secreg_dfac
        {
            get { return _fcm_secreg_dfac; }
            set
            {
                if (_fcm_secreg_dfac == value) return;
                _fcm_secreg_dfac = value;
                OnPropertyChanged("Fcm_secreg_dfac");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion
        /// y otros
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Cto_seccon_cont: Secuencial de Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Cto_nrocon_cont: Número Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public String Cto_nrocon_cont
        {
            get { return _cto_nrocon_cont; }
            set
            {
                if (_cto_nrocon_cont == value) return;
                _cto_nrocon_cont = value;
                OnPropertyChanged("Cto_nrocon_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Fcm_secreg_mfac: Código orden medica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
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
        #region Fcm_numfac_mfac: Numero Factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
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
        #region Fcm_tiprfa_mfac: Tipo registro facturación Pre-factura o Valida dian
        private String _fcm_tiprfa_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro facturación</para>
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
        #region Fcm_fecfac_mfac: Fecha factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Fcm_estfac_mfac: Estado Factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region Adm_nroaut_rgad: Numero Autorización
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero Autorizacion solicitada a la EPS o Asegurador para adimision
        /// o servicio que requiera autorizacion
        /// </para>
        /// </summary>
        public String Adm_nroaut_rgad
        {
            get { return _adm_nroaut_rgad; }
            set
            {
                if (_adm_nroaut_rgad == value) return;
                _adm_nroaut_rgad = value;
                OnPropertyChanged("Adm_nroaut_rgad");
            }
        }
        #endregion
        #region Sia_codrip_trip: Tipo servicio RIPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public String Sia_codrip_trip
        {
            get { return _sia_codrip_trip; }
            set
            {
                if (_sia_codrip_trip == value) return;
                _sia_codrip_trip = value;
                OnPropertyChanged("Sia_codrip_trip");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado para referencia
        /// y validacion de pertinencia
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
        #region Fcm_codbar_sips: Código de Barras
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public String Fcm_codbar_sips
        {
            get { return _fcm_codbar_sips; }
            set
            {
                if (_fcm_codbar_sips == value) return;
                _fcm_codbar_sips = value;
                OnPropertyChanged("Fcm_codbar_sips");
            }
        }
        #endregion
        #region Fcm_idesec_mant: Codigo unico tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del servicio para venta con manual tarifario (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_idesec_mant
        {
            get { return _fcm_idesec_mant; }
            set
            {
                if (_fcm_idesec_mant == value) return;
                _fcm_idesec_mant = value;
                OnPropertyChanged("Fcm_idesec_mant");
            }
        }
        #endregion
        #region Fcm_codser_mant: Código servicio en tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS
        /// </para>
        /// </summary>
        public String Fcm_codser_mant
        {
            get { return _fcm_codser_mant; }
            set
            {
                if (_fcm_codser_mant == value) return;
                _fcm_codser_mant = value;
                OnPropertyChanged("Fcm_codser_mant");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        #region Con_codsco_ccos: Código centro de costo
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Para identificar Servicios por centro de costos (desde contabilidad)
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
        #region Fcm_codcpr_cpro: Código centro producción
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de produccion donde se presta el servicio
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
        #region Fcm_desser_dfac: Nombre servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_dfac (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public String Fcm_desser_dfac
        {
            get { return _fcm_desser_dfac; }
            set
            {
                if (_fcm_desser_dfac == value) return;
                _fcm_desser_dfac = value;
                OnPropertyChanged("Fcm_desser_dfac");
            }
        }
        #endregion
        #region Fcm_codman_mans: Código manual tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios configurados para
        /// ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual
        /// SOAT para ventas contributivo (se todam desde el contrato)
        /// </para>
        /// </summary>
        public String Fcm_codman_mans
        {
            get { return _fcm_codman_mans; }
            set
            {
                if (_fcm_codman_mans == value) return;
                _fcm_codman_mans = value;
                OnPropertyChanged("Fcm_codman_mans");
            }
        }
        #endregion
        #region Fcm_fecser_dfac: Fecha servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: fcm_fecser_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha de prestacion del servicio
        /// </para>
        /// </summary>
        public DateTime Fcm_fecser_dfac
        {
            get { return _fcm_fecser_dfac; }
            set
            {
                if (_fcm_fecser_dfac == value) return;
                _fcm_fecser_dfac = value;
                OnPropertyChanged("Fcm_fecser_dfac");
            }
        }
        #endregion
        #region Fcm_horser_dfac: Hora Digitación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora Digitación</para>
        /// <para>NOMBRE: fcm_horser_dfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Hora  digitacion del servicio en facturacion en formato militar
        /// </para>
        /// </summary>
        public Decimal Fcm_horser_dfac
        {
            get { return _fcm_horser_dfac; }
            set
            {
                if (_fcm_horser_dfac == value) return;
                _fcm_horser_dfac = value;
                OnPropertyChanged("Fcm_horser_dfac");
            }
        }
        #endregion
        #region Fcm_perman_sips: Código Pertenece al manual
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: fcm_perman_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public String Fcm_perman_sips
        {
            get { return _fcm_perman_sips; }
            set
            {
                if (_fcm_perman_sips == value) return;
                _fcm_perman_sips = value;
                OnPropertyChanged("Fcm_perman_sips");
            }
        }
        #endregion
        #region Fcm_forfar_sips: Forma farmacéutica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Forma farmaceutica del medicamento (cuando el servicio sea
        /// un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_forfar_sips
        {
            get { return _fcm_forfar_sips; }
            set
            {
                if (_fcm_forfar_sips == value) return;
                _fcm_forfar_sips = value;
                OnPropertyChanged("Fcm_forfar_sips");
            }
        }
        #endregion
        #region Far_codcum_famd: Codigo CUM del medicamento
        private String _far_codcum_famd;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Codigo Cum del medicamento</para>
        /// <para>NOMBRE: far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION: Codigo CUM del medicamento(clasificacion unica de medicamentos) con el cual fue facturado</para>
        /// </summary>
        public String Far_codcum_famd
        {
            get { return _far_codcum_famd; }
            set
            {
                if (_far_codcum_famd == value) return;
                _far_codcum_famd = value;
                OnPropertyChanged("Far_codcum_famd");
            }
        }
        #endregion
        #region Fcm_conmed_sips: Concentración
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Concentración del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_conmed_sips
        {
            get { return _fcm_conmed_sips; }
            set
            {
                if (_fcm_conmed_sips == value) return;
                _fcm_conmed_sips = value;
                OnPropertyChanged("Fcm_conmed_sips");
            }
        }
        #endregion
        #region Fcm_unimed_sips: Unidad de medida
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Unidad medica del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_unimed_sips
        {
            get { return _fcm_unimed_sips; }
            set
            {
                if (_fcm_unimed_sips == value) return;
                _fcm_unimed_sips = value;
                OnPropertyChanged("Fcm_unimed_sips");
            }
        }
        #endregion
        #region Fcm_autdes_ades: Autorización descuento
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_valser_mant: Valor de servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public float Fcm_valser_mant
        {
            get { return _fcm_valser_mant; }
            set
            {
                if (_fcm_valser_mant == value) return;
                _fcm_valser_mant = value;
                OnPropertyChanged("Fcm_valser_mant");
            }
        }
        #endregion
        #region Fcm_totuni_dfac: Total unidades
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Total de unidades facturadas del servicio
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
        #region Fcm_valbru_dfac: Valor bruto factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valbru_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_poriva_dfac: Porcentaje del IVA
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float Fcm_poriva_dfac
        {
            get { return _fcm_poriva_dfac; }
            set
            {
                if (_fcm_poriva_dfac == value) return;
                _fcm_poriva_dfac = value;
                OnPropertyChanged("Fcm_poriva_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float Fcm_valiva_dfac
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
        #region Fcm_valcpa_dfac: Valor copago
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float Fcm_valcpa_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float Fcm_valcmo_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float Fcm_valusu_dfac
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
        #region Fcm_valcom_dfac: Valor comisión
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: fcm_valcom_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float Fcm_valcom_dfac
        {
            get { return _fcm_valcom_dfac; }
            set
            {
                if (_fcm_valcom_dfac == value) return;
                _fcm_valcom_dfac = value;
                OnPropertyChanged("Fcm_valcom_dfac");
            }
        }
        #endregion
        #region Fcm_valsub_dfac: Valor subtotal servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float Fcm_valsub_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valfac_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Valor a recaudar en efectivo sin descuento realizado aun (solo valor a cobrar
        /// en efectivo) por copagos cuotas moderadoras o valor total del servicio,
        /// no siempre representa el valor total del servicio.
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente al servicio, representa Fcm_valref_dfac menos el descuento 
        /// cuando aplique desucento, de lo contrario solo es Fcm_valref_dfac.
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
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
        #region Fcm_codtse_sips: Tipo procedimientos o servicios
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public String Fcm_codtse_sips
        {
            get { return _fcm_codtse_sips; }
            set
            {
                if (_fcm_codtse_sips == value) return;
                _fcm_codtse_sips = value;
                OnPropertyChanged("Fcm_codtse_sips");
            }
        }
        #endregion
        #region Fcm_codaqx_aqir: Tipo Acto Quirúrgico
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Tipo Acto Quirúrgico</para>
        /// <para>NOMBRE: fcm_codaqx_aqir (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public String Fcm_codaqx_aqir
        {
            get { return _fcm_codaqx_aqir; }
            set
            {
                if (_fcm_codaqx_aqir == value) return;
                _fcm_codaqx_aqir = value;
                OnPropertyChanged("Fcm_codaqx_aqir");
            }
        }
        #endregion
        #region Sia_tipact_tsac: Tipo servicio o activiad
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o activiad</para>
        /// <para>NOMBRE: sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
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
        #region Adm_codtat_tatn: Tipo de Atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: adm_codtat_tatn(char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito del servicio:1=Ambulatoria
        /// 2=Hospitalizacion 3=Urgencia
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
        #region Sia_codfpr_fpor: Finalidad Procedimiento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: sia_codfpr_fpor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public String Sia_codfpr_fpor
        {
            get { return _sia_codfpr_fpor; }
            set
            {
                if (_sia_codfpr_fpor == value) return;
                _sia_codfpr_fpor = value;
                OnPropertyChanged("Sia_codfpr_fpor");
            }
        }
        #endregion
        #region Sia_codfco_fcon:
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        ///Finalidad de la consulta:01=Atención del Parto
        /// </para>
        /// </summary>
        public String Sia_codfco_fcon
        {
            get { return _sia_codfco_fcon; }
            set
            {
                if (_sia_codfco_fcon == value) return;
                _sia_codfco_fcon = value;
                OnPropertyChanged("Sia_codfco_fcon");
            }
        }
        #endregion
        #region Adm_codcex_tcex: Causa Externa
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atencion según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public String Adm_codcex_tcex
        {
            get { return _adm_codcex_tcex; }
            set
            {
                if (_adm_codcex_tcex == value) return;
                _adm_codcex_tcex = value;
                OnPropertyChanged("Adm_codcex_tcex");
            }
        }
        #endregion
        #region Sia_coddia_tdia: Diagnostico Principal
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Diagnostico Principal</para>
        /// <para>NOMBRE: sia_coddxa_mdxa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Codigo del diagnostico principal (para Rips AP o AC cuando
        /// sea requerido)  según la CIE 10, desde la tabla maestra de
        /// diagnosticos
        /// </para>
        /// </summary>
        public String Sia_coddia_tdia
        {
            get { return _sia_coddia_tdia; }
            set
            {
                if (_sia_coddia_tdia == value) return;
                _sia_coddia_tdia = value;
                OnPropertyChanged("Sia_coddia_tdia");
            }
        }
        #endregion
        #region Sia_tipdxp_tdix: Tipo de diagnostico
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Tipo de diagnostico según CIE 10: 1=impresion diagnostica 2=Confirmado
        /// nuevo y otros
        /// </para>
        /// </summary>
        public String Sia_tipdxp_tdix
        {
            get { return _sia_tipdxp_tdix; }
            set
            {
                if (_sia_tipdxp_tdix == value) return;
                _sia_tipdxp_tdix = value;
                OnPropertyChanged("Sia_tipdxp_tdix");
            }
        }
        #endregion
        #region Sia_coddx1_tdia: Diagnostico relacionado 1
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 1</para>
        /// <para>NOMBRE: sia_coddx1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx1_tdia
        {
            get { return _sia_coddx1_tdia; }
            set
            {
                if (_sia_coddx1_tdia == value) return;
                _sia_coddx1_tdia = value;
                OnPropertyChanged("Sia_coddx1_tdia");
            }
        }
        #endregion
        #region Sia_coddx2_tdia: Diagnostico relacionado 2
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 2</para>
        /// <para>NOMBRE: sia_coddx2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx2_tdia
        {
            get { return _sia_coddx2_tdia; }
            set
            {
                if (_sia_coddx2_tdia == value) return;
                _sia_coddx2_tdia = value;
                OnPropertyChanged("Sia_coddx2_tdia");
            }
        }
        #endregion
        #region Sia_coddx3_tdia: Diagnostico relacionado 3
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 3</para>
        /// <para>NOMBRE: sia_coddx3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 3 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx3_tdia
        {
            get { return _sia_coddx3_tdia; }
            set
            {
                if (_sia_coddx3_tdia == value) return;
                _sia_coddx3_tdia = value;
                OnPropertyChanged("Sia_coddx3_tdia");
            }
        }
        #endregion
        #region Sia_coddxc_tdia: Diagnostico complicación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: sia_coddxc_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complizacion según tabla CIE10
        /// </para>
        /// </summary>
        public String Sia_coddxc_tdia
        {
            get { return _sia_coddxc_tdia; }
            set
            {
                if (_sia_coddxc_tdia == value) return;
                _sia_coddxc_tdia = value;
                OnPropertyChanged("Sia_coddxc_tdia");
            }
        }
        #endregion
        #region Sia_codgac_gpyp: Grupo Actividades PyP
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siagrupoactipyp</para>
        /// <para>CAMPO: Grupo Actividades PyP</para>
        /// <para>NOMBRE: sia_codgac_gpyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public String Sia_codgac_gpyp
        {
            get { return _sia_codgac_gpyp; }
            set
            {
                if (_sia_codgac_gpyp == value) return;
                _sia_codgac_gpyp = value;
                OnPropertyChanged("Sia_codgac_gpyp");
            }
        }
        #endregion
        #region Sia_codact_apyp: Actividades PyP
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaactividadpyp</para>
        /// <para>CAMPO: Actividades PyP</para>
        /// <para>NOMBRE: sia_codact_apyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public String Sia_codact_apyp
        {
            get { return _sia_codact_apyp; }
            set
            {
                if (_sia_codact_apyp == value) return;
                _sia_codact_apyp = value;
                OnPropertyChanged("Sia_codact_apyp");
            }
        }
        #endregion
        #region Fcm_serpos_sips: servicio POS/NO POS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: servicio POS/NO POS</para>
        /// <para>NOMBRE: fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Fcm_serpos_sips
        {
            get { return _fcm_serpos_sips; }
            set
            {
                if (_fcm_serpos_sips == value) return;
                _fcm_serpos_sips = value;
                OnPropertyChanged("Fcm_serpos_sips");
            }
        }
        #endregion
        #region Cto_tipact_cont: Actividad que cubre Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Actividad que cubre Contrato</para>
        /// <para>NOMBRE: cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Salud Publica 4 =Todas
        /// </para>
        /// </summary>
        public String Cto_tipact_cont
        {
            get { return _cto_tipact_cont; }
            set
            {
                if (_cto_tipact_cont == value) return;
                _cto_tipact_cont = value;
                OnPropertyChanged("Cto_tipact_cont");
            }
        }
        #endregion
        #region Sia_codpat_tpat: Tipo de profesional
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public String Sia_codpat_tpat
        {
            get { return _sia_codpat_tpat; }
            set
            {
                if (_sia_codpat_tpat == value) return;
                _sia_codpat_tpat = value;
                OnPropertyChanged("Sia_codpat_tpat");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código profesional atiende
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        ///Codigo del Profesional que presta servicio medico
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
        #region Fac_horprs_dfac: Hora servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: fac_horprs_dfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Hora en que recibe la prestacion del servicio (lo atiende el
        /// profesional) en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Fac_horprs_dfac
        {
            get { return _fac_horprs_dfac; }
            set
            {
                if (_fac_horprs_dfac == value) return;
                _fac_horprs_dfac = value;
                OnPropertyChanged("Fac_horprs_dfac");
            }
        }
        #endregion
        #region Fcm_atepro_dfac: Servicio atendido SI/NO
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio atendido SI/NO</para>
        /// <para>NOMBRE: fcm_atepro_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Para confirmar si el servicio ya fue antendido por el profesional
        /// o esta pendiente para ser realizado 1= Servicio pendiente para
        /// profesional 2= Servicio atendido por profesional
        /// </para>
        /// </summary>
        public String Fcm_atepro_dfac
        {
            get { return _fcm_atepro_dfac; }
            set
            {
                if (_fcm_atepro_dfac == value) return;
                _fcm_atepro_dfac = value;
                OnPropertyChanged("Fcm_atepro_dfac");
            }
        }
        #endregion
        #region Sia_codare_aser: Código área servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área servicio</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        ///Codigo area donde se presta el servicio
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
        #region Desia_aresol_aser: Nombre área de servicios
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: desia_aresol_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_aresol_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public String Desia_aresol_aser
        {
            get { return _desia_aresol_aser; }
            set
            {
                if (_desia_aresol_aser == value) return;
                _desia_aresol_aser = value;
                OnPropertyChanged("Desia_aresol_aser");
            }
        }
        #endregion
        #region Sia_aresol_aser: Código área solicita
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área solicita</para>
        /// <para>NOMBRE: sia_aresol_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        ///Codigo area que solicita el servicio
        /// </para>
        /// </summary>
        public String Sia_aresol_aser
        {
            get { return _sia_aresol_aser; }
            set
            {
                if (_sia_aresol_aser == value) return;
                _sia_aresol_aser = value;
                OnPropertyChanged("Sia_aresol_aser");
            }
        }
        #endregion
        #region Fcm_tipser_sips: Servicio o Suministro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public String Fcm_tipser_sips
        {
            get { return _fcm_tipser_sips; }
            set
            {
                if (_fcm_tipser_sips == value) return;
                _fcm_tipser_sips = value;
                OnPropertyChanged("Fcm_tipser_sips");
            }
        }
        #endregion
        #region Fcm_fecedt_dfac: Fecha ultima modificación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: fcm_fecedt_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Fecha ultima modificacion realizada por un usario o facturador
        /// </para>
        /// </summary>
        public DateTime Fcm_fecedt_dfac
        {
            get { return _fcm_fecedt_dfac; }
            set
            {
                if (_fcm_fecedt_dfac == value) return;
                _fcm_fecedt_dfac = value;
                OnPropertyChanged("Fcm_fecedt_dfac");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Digitador
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
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
        #region Fcm_otserv_sips: Tipo Rips otros servicios
        private String _fcm_otserv_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public String Fcm_otserv_sips
        {
            get { return _fcm_otserv_sips; }
            set
            {
                if (_fcm_otserv_sips == value) return;
                _fcm_otserv_sips = value;
                OnPropertyChanged("Fcm_otserv_sips");
            }
        }
        #endregion
        #region Sia_regate_rgat: Registro de atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: sia_regate_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public String Sia_regate_rgat
        {
            get { return _sia_regate_rgat; }
            set
            {
                if (_sia_regate_rgat == value) return;
                _sia_regate_rgat = value;
                OnPropertyChanged("Sia_regate_rgat");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
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
        #region Fcm_ripsco_dfac: Rips completados SI/NO
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Rips completados SI/NO</para>
        /// <para>NOMBRE: fcm_ripsco_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si los datos del RIPS fueron completados por
        /// el profesional en la atencion medica: 1=Sin completar 2= Rips
        /// completados
        /// </para>
        /// </summary>
        public String Fcm_ripsco_dfac
        {
            get { return _fcm_ripsco_dfac; }
            set
            {
                if (_fcm_ripsco_dfac == value) return;
                _fcm_ripsco_dfac = value;
                OnPropertyChanged("Fcm_ripsco_dfac");
            }
        }
        #endregion
        #region Far_nroreg_fads: Codigo registro entrega
        private String _far_nroreg_fads;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo registro entrega</para>
        /// <para>NOMBRE: far_nroreg_fads (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Código secuencial registro detalle desde modulo farmacia  cuando
        /// no aplica debe contener el valor NA
        /// </para>
        /// </summary>
        public String Far_nroreg_fads
        {
            get { return _far_nroreg_fads; }
            set
            {
                if (_far_nroreg_fads == value) return;
                _far_nroreg_fads = value;
                OnPropertyChanged("Far_nroreg_fads");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// Codigo del almacen (desde inventario) desde el cual se descargan
        /// los suministros facturados (cuando aplique según tipo servicio
        /// y el contrato) NA cuando no aplica
        /// </para>
        /// </summary>
        public String Inv_codalm_inal
        {
            get { return _inv_codalm_inal; }
            set
            {
                if (_inv_codalm_inal == value) return;
                _inv_codalm_inal = value;
                OnPropertyChanged("Inv_codalm_inal");
            }
        }
        #endregion
        #region Inv_secart_inar: Código articulo farmacia
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código articulo farmacia</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del articulo relacionado con el inventario generado
        /// por el sistema  NA cuando no aplica
        /// </para>
        /// </summary>
        public String Inv_secart_inar
        {
            get { return _inv_secart_inar; }
            set
            {
                if (_inv_secart_inar == value) return;
                _inv_secart_inar = value;
                OnPropertyChanged("Inv_secart_inar");
            }
        }
        #endregion
        #region Inv_codaux_inar: Codigo digitacion farmacia
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo digitacion farmacia</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public String Inv_codaux_inar
        {
            get { return _inv_codaux_inar; }
            set
            {
                if (_inv_codaux_inar == value) return;
                _inv_codaux_inar = value;
                OnPropertyChanged("Inv_codaux_inar");
            }
        }
        #endregion
        #region Inv_codgme_mgme: Patrón unidad medida
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Patrón unidad medida</para>
        /// <para>NOMBRE: inv_codgme_mgme (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Patrón Unidad de Medida (Masa, Volumen, etc) Viene del  almacén
        /// de donde se tome, desde el maestro grupos de medidas
        /// </para>
        /// </summary>
        public String Inv_codgme_mgme
        {
            get { return _inv_codgme_mgme; }
            set
            {
                if (_inv_codgme_mgme == value) return;
                _inv_codgme_mgme = value;
                OnPropertyChanged("Inv_codgme_mgme");
            }
        }
        #endregion
        #region Inv_coduma_muma: Unidad medida descarga
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Unidad medida descarga</para>
        /// <para>NOMBRE: inv_coduma_muma (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// Unidad de medida para descargar desde  almacén (litros, gramos,
        /// centilitros) Viene del Almacén de donde se tome
        /// </para>
        /// </summary>
        public String Inv_coduma_muma
        {
            get { return _inv_coduma_muma; }
            set
            {
                if (_inv_coduma_muma == value) return;
                _inv_coduma_muma = value;
                OnPropertyChanged("Inv_coduma_muma");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la admision: 1=Abierto
        /// 2=Cerrado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        // Campos auxiliares
        #region Cto_descon_cont: Descripción contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sia_deseps_teps: Nombre EPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Fcm_desman_mans: Manual tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion manual tarifario
        /// </para>
        /// </summary>
        public String Fcm_desman_mans
        {
            get { return _fcm_desman_mans; }
            set
            {
                if (_fcm_desman_mans == value) return;
                _fcm_desman_mans = value;
                OnPropertyChanged("Fcm_desman_mans");
            }
        }
        #endregion
        #region Fcm_desaqx_aqir: Descripcion realizacion
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Descripcion realizacion</para>
        /// <para>NOMBRE: fcm_desaqx_aqir (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Dscripción forma de realizacion del acto quirúrgico
        /// </para>
        /// </summary>
        public String Fcm_desaqx_aqir
        {
            get { return _fcm_desaqx_aqir; }
            set
            {
                if (_fcm_desaqx_aqir == value) return;
                _fcm_desaqx_aqir = value;
                OnPropertyChanged("Fcm_desaqx_aqir");
            }
        }
        #endregion
        #region Sia_desact_tsac: Tipo servicio o actividad
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Cto_sepser_cont: Seprar servicios para facturacion segun tipo
        /// <summary>
        /// <para>CAMPO: Separar servicios por Asistencial PyP y salud publica</para>
        /// <para>NOMBRE: Cto_sepser_cont (char:1)</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial, PyP y salud publica, 
        /// para generar facturas por separado cuando el 
        /// contrato cubre varios tipos de servicios: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_sepser_cont
        {
            get { return _cto_sepser_cont; }
            set
            {
                if (_cto_sepser_cont == value) return;
                _cto_sepser_cont = value;
                OnPropertyChanged("Cto_sepser_cont");
            }
        }
        #endregion
        #region Modificado: Marca para saber si el registro fue modificado
        private String _modificado;
        /// <summary>
        /// <para>Marca para saber si el registro fue modificado</para>
        /// </summary>
        public String Modificado
        {
            get { return _modificado; }
            set
            {
                if (_modificado == value) return;
                _modificado = value;
                OnPropertyChanged("Modificado");
            }
        }
        #endregion
        #region Sia_desrip_trip: Nombre Servicio segun Resolucion Rips
        private String _sia_desrip_trip;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Nombre Descripción Rips</para>
        /// <para>NOMBRE: sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del servicio según tipo Rips  Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public String Sia_desrip_trip
        {
            get { return _sia_desrip_trip; }
            set
            {
                if (_sia_desrip_trip == value) return;
                _sia_desrip_trip = value;
                OnPropertyChanged("Sia_desrip_trip");
            }
        }
        #endregion
        #region Fcm_desfac_mfac: Descripcion estado Factura
        private String _fcm_desfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Descripcion Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Descripcion estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public String Fcm_desfac_mfac
        {
            get { return _fcm_desfac_mfac; }
            set
            {
                if (_fcm_desfac_mfac == value) return;
                _fcm_desfac_mfac = value;
                OnPropertyChanged("Fcm_desfac_mfac");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Hcl_codreg_hcca: Registro actividad clinica
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
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
        #region Cto_fcdian_cont: Generar Secuencial facturas DIAN Si/No
        private String _cto_fcdian_cont;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: cto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Generar Numeros de factura desde Secuencial autorizado DIAN:
        /// 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_fcdian_cont
        {
            get { return _cto_fcdian_cont; }
            set
            {
                if (_cto_fcdian_cont == value) return;
                _cto_fcdian_cont = value;
                OnPropertyChanged("Cto_fcdian_cont");
            }
        }
        #endregion
        #region Fcm_codpro_fcpr: Codigo UNSPSC
        private String _fcm_codpro_fcpr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Codigo UNSPSC</para>
        /// <para>NOMBRE: fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION: Codigo Producto segun clasificacion UNSPSC para gestion DIAN</para>
        /// </summary>
        public String Fcm_codpro_fcpr
        {
            get { return _fcm_codpro_fcpr; }
            set
            {
                if (_fcm_codpro_fcpr == value) return;
                _fcm_codpro_fcpr = value;
                OnPropertyChanged("Fcm_codpro_fcpr");
            }
        }
        #endregion
        // Para gestion completar rips
        #region Desia_coddx1_tdia: Descripcion diagnostico
        private String _desia_coddx1_tdia;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx1_tdia
        {
            get { return _desia_coddx1_tdia; }
            set
            {
                if (_desia_coddx1_tdia == value) return;
                _desia_coddx1_tdia = value;
                OnPropertyChanged("Desia_coddx1_tdia");
            }
        }
        #endregion
        #region Desia_coddx2_tdia: Descripcion diagnostico
        private String _desia_coddx2_tdia;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx2_tdia
        {
            get { return _desia_coddx2_tdia; }
            set
            {
                if (_desia_coddx2_tdia == value) return;
                _desia_coddx2_tdia = value;
                OnPropertyChanged("Desia_coddx2_tdia");
            }
        }
        #endregion
        #region Desia_coddx3_tdia: Descripcion diagnostico
        private String _desia_coddx3_tdia;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx3_tdia
        {
            get { return _desia_coddx3_tdia; }
            set
            {
                if (_desia_coddx3_tdia == value) return;
                _desia_coddx3_tdia = value;
                OnPropertyChanged("Desia_coddx3_tdia");
            }
        }
        #endregion
        #region Desia_coddxc_tdia: Descripcion diagnostico
        private String _desia_coddxc_tdia;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddxc_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddxc_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddxc_tdia
        {
            get { return _desia_coddxc_tdia; }
            set
            {
                if (_desia_coddxc_tdia == value) return;
                _desia_coddxc_tdia = value;
                OnPropertyChanged("Desia_coddxc_tdia");
            }
        }
        #endregion
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        private String _sia_desdia_tdia;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdia_tdia
        {
            get { return _sia_desdia_tdia; }
            set
            {
                if (_sia_desdia_tdia == value) return;
                _sia_desdia_tdia = value;
                OnPropertyChanged("Sia_desdia_tdia");
            }
        }
        #endregion
        #region Sia_desdxp_tdix: Tipo diagnostico principal
        private String _sia_desdxp_tdix;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdxp_tdix
        {
            get { return _sia_desdxp_tdix; }
            set
            {
                if (_sia_desdxp_tdix == value) return;
                _sia_desdxp_tdix = value;
                OnPropertyChanged("Sia_desdxp_tdix");
            }
        }
        #endregion
        #region Fcm_desest_rips: Descripción estado del Rips
        private String _fcm_desest_rips;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ninguna </para>
        /// <para>CAMPO: Descripción estado del Rips</para>
        /// <para>NOMBRE: fcm_desest_rips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion estado del Rips: 1=PENDIENTE 2=COMPLETO,
        /// para saber si el registro Rips fue completado al momento de la atención
        /// </para>
        /// </summary>
        public String Fcm_desest_rips
        {
            get { return _fcm_desest_rips; }
            set
            {
                if (_fcm_desest_rips == value) return;
                _fcm_desest_rips = value;
                OnPropertyChanged("Fcm_desest_rips");
            }
        }
        #endregion
        #region Fcm_aplfus_sips: Frecuencia de uso
        private String _fcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso</para>
        /// <para>NOMBRE: fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Aplicar frecuencia de uso al servicio: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Fcm_aplfus_sips
        {
            get { return _fcm_aplfus_sips; }
            set
            {
                if (_fcm_aplfus_sips == value) return;
                _fcm_aplfus_sips = value;
                OnPropertyChanged("Fcm_aplfus_sips");
            }
        }
        #endregion
        #region Fcm_intser_sips: Intervalos días orden servicio
        private int _fcm_intser_sips;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Intervalos días orden servicio</para>
        /// <para>NOMBRE: fcm_intser_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Frecuencia uso servicio: Intervalo en dias para la nueva orden del servicio ejm: cada
        /// 15 o 3 dias , cada 90 dias es decir intser= 15 intser=30 intser=90
        /// </para>
        /// </summary>
        public int Fcm_intser_sips
        {
            get { return _fcm_intser_sips; }
            set
            {
                if (_fcm_intser_sips == value) return;
                _fcm_intser_sips = value;
                OnPropertyChanged("Fcm_intser_sips");
            }
        }
        #endregion
        #region Cto_frecus_cont: Contrato Frecuencia uso servicios
        private String _cto_frecus_cont;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Frecuencia uso servicios</para>
        /// <para>NOMBRE: cto_frecus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Parametro desde maestro contrato: Aplicar Validacion frecuencia uso de servicios: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_frecus_cont
        {
            get { return _cto_frecus_cont; }
            set
            {
                if (_cto_frecus_cont == value) return;
                _cto_frecus_cont = value;
                OnPropertyChanged("Cto_frecus_cont");
            }
        }
        #endregion
        //- para gestion 4505
        #region Sis_codsex_sexo: Sexo del paciente
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Sexo del usuario o paciente
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
        #region Adm_pacemb_rgad: Embarazada SI/NO
        private String _adm_pacemb_rgad;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO 3=NO APLICA
        /// </para>
        /// </summary>
        public String Adm_pacemb_rgad
        {
            get { return _adm_pacemb_rgad; }
            set
            {
                if (_adm_pacemb_rgad == value) return;
                _adm_pacemb_rgad = value;
                OnPropertyChanged("Adm_pacemb_rgad");
            }
        }
        #endregion
        #region Sia_edapac_usua: Edad Paciente
        private int _sia_edapac_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al Momento de Admisión
        /// </para>
        /// </summary>
        public int Sia_edapac_usua
        {
            get { return _sia_edapac_usua; }
            set
            {
                if (_sia_edapac_usua == value) return;
                _sia_edapac_usua = value;
                OnPropertyChanged("Sia_edapac_usua");
            }
        }
        #endregion
        #region Sia_codmed_tmed: Medida Edad
        private String _sia_codmed_tmed;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día
        /// </para>
        /// </summary>
        public String Sia_codmed_tmed
        {
            get { return _sia_codmed_tmed; }
            set
            {
                if (_sia_codmed_tmed == value) return;
                _sia_codmed_tmed = value;
                OnPropertyChanged("Sia_codmed_tmed");
            }
        }
        #endregion
        #region Sia_edaano_usua: Edad en años
        private int _sia_edaano_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Edad en años
        /// </para>
        /// </summary>
        public int Sia_edaano_usua
        {
            get { return _sia_edaano_usua; }
            set
            {
                if (_sia_edaano_usua == value) return;
                _sia_edaano_usua = value;
                OnPropertyChanged("Sia_edaano_usua");
            }
        }
        #endregion
        #region Sia_edames_usua: Edad en meses
        private int _sia_edames_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Edad en meses
        /// </para>
        /// </summary>
        public int Sia_edames_usua
        {
            get { return _sia_edames_usua; }
            set
            {
                if (_sia_edames_usua == value) return;
                _sia_edames_usua = value;
                OnPropertyChanged("Sia_edames_usua");
            }
        }
        #endregion
        #region Sia_edadia_usua: Edad en días
        private int _sia_edadia_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Edad en días
        /// </para>
        /// </summary>
        public int Sia_edadia_usua
        {
            get { return _sia_edadia_usua; }
            set
            {
                if (_sia_edadia_usua == value) return;
                _sia_edadia_usua = value;
                OnPropertyChanged("Sia_edadia_usua");
            }
        }
        #endregion
        #region Sia_edaymd_usua: Edad formato largo
        private String _sia_edaymd_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 días)
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
        // Adicionales
        #region Fcm_secres_srfa: Codigo unico en sistema Resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Secuencial unico en sistema resolución Dian desde la cual</para>
        /// <para>se genera el numero de factura (cuando aplique)</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(FcmModeloServDetallFacturas tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            var lnuContador = 0;

            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmaedetallfac();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tobTempReg.Fcm_secreg_dfac);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            #region Datos
                            lobEFReg.fcm_secreg_dfac = tobTempReg.Fcm_secreg_dfac;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobTempReg.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.cto_seccon_cont = tobTempReg.Cto_seccon_cont;
                            lobEFReg.cto_nrocon_cont = tobTempReg.Cto_nrocon_cont;
                            lobEFReg.sia_codeps_teps = tobTempReg.Sia_codeps_teps;
                            lobEFReg.sis_idterc_sitr = tobTempReg.Sis_idterc_sitr;
                            lobEFReg.fcm_secreg_mfac = tobTempReg.Fcm_secreg_mfac;
                            lobEFReg.fcm_numfac_mfac = tobTempReg.Fcm_numfac_mfac;
                            lobEFReg.fcm_tiprfa_mfac = tobTempReg.Fcm_tiprfa_mfac;
                            lobEFReg.fcm_fecfac_mfac = (DateTime)tobTempReg.Fcm_fecfac_mfac;
                            lobEFReg.fcm_estfac_mfac = tobTempReg.Fcm_estfac_mfac;
                            lobEFReg.adm_nroaut_rgad = tobTempReg.Adm_nroaut_rgad;
                            lobEFReg.sia_codrip_trip = tobTempReg.Sia_codrip_trip;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_codbar_sips = tobTempReg.Fcm_codbar_sips;
                            lobEFReg.fcm_idesec_mant = tobTempReg.Fcm_idesec_mant;
                            lobEFReg.fcm_codser_mant = tobTempReg.Fcm_codser_mant;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.con_codsco_ccos = tobTempReg.Con_codsco_ccos;
                            lobEFReg.fcm_codcpr_cpro = tobTempReg.Fcm_codcpr_cpro;
                            lobEFReg.fcm_desser_dfac = tobTempReg.Fcm_desser_dfac;
                            lobEFReg.fcm_codman_mans = tobTempReg.Fcm_codman_mans;
                            lobEFReg.fcm_fecser_dfac = (DateTime)tobTempReg.Fcm_fecser_dfac;
                            lobEFReg.fcm_horser_dfac = (Decimal)tobTempReg.Fcm_horser_dfac;
                            lobEFReg.fcm_perman_sips = tobTempReg.Fcm_perman_sips;
                            lobEFReg.fcm_forfar_sips = tobTempReg.Fcm_forfar_sips;
                            lobEFReg.fcm_conmed_sips = tobTempReg.Fcm_conmed_sips;
                            lobEFReg.fcm_unimed_sips = tobTempReg.Fcm_unimed_sips;
                            lobEFReg.fcm_autdes_ades = tobTempReg.Fcm_autdes_ades;
                            lobEFReg.fcm_valser_mant = (float)tobTempReg.Fcm_valser_mant;
                            lobEFReg.fcm_totuni_dfac = (int)tobTempReg.Fcm_totuni_dfac;
                            lobEFReg.fcm_valbru_dfac = (float)tobTempReg.Fcm_valbru_dfac;
                            lobEFReg.fcm_pordes_dfac = (float)tobTempReg.Fcm_pordes_dfac;
                            lobEFReg.fcm_valdes_dfac = (float)tobTempReg.Fcm_valdes_dfac;
                            lobEFReg.fcm_poriva_dfac = (float)tobTempReg.Fcm_poriva_dfac;
                            lobEFReg.fcm_valiva_dfac = (float)tobTempReg.Fcm_valiva_dfac;
                            lobEFReg.fcm_valcpa_dfac = (float)tobTempReg.Fcm_valcpa_dfac;
                            lobEFReg.fcm_valcmo_dfac = (float)tobTempReg.Fcm_valcmo_dfac;
                            lobEFReg.fcm_valusu_dfac = (float)tobTempReg.Fcm_valusu_dfac;
                            lobEFReg.fcm_valcom_dfac = (float)tobTempReg.Fcm_valcom_dfac;
                            lobEFReg.fcm_valsub_dfac = (float)tobTempReg.Fcm_valsub_dfac;
                            lobEFReg.fcm_valfac_dfac = (float)tobTempReg.Fcm_valfac_dfac;
                            lobEFReg.fcm_valref_dfac = (float)tobTempReg.Fcm_valref_dfac;
                            lobEFReg.fcm_valefe_dfac = (float)tobTempReg.Fcm_valefe_dfac;
                            lobEFReg.fcm_codtse_sips = tobTempReg.Fcm_codtse_sips;
                            lobEFReg.fcm_codaqx_aqir = tobTempReg.Fcm_codaqx_aqir;
                            lobEFReg.sia_tipact_tsac = tobTempReg.Sia_tipact_tsac;
                            lobEFReg.adm_codtat_tatn = tobTempReg.Adm_codtat_tatn;
                            lobEFReg.sia_codfpr_fpor = tobTempReg.Sia_codfpr_fpor;
                            lobEFReg.sia_codfco_fcon = tobTempReg.Sia_codfco_fcon;
                            lobEFReg.adm_codcex_tcex = tobTempReg.Adm_codcex_tcex;
                            lobEFReg.sia_coddia_tdia = tobTempReg.Sia_coddia_tdia;
                            lobEFReg.sia_tipdxp_tdix = tobTempReg.Sia_tipdxp_tdix;
                            lobEFReg.sia_coddx1_tdia = tobTempReg.Sia_coddx1_tdia;
                            lobEFReg.sia_coddx2_tdia = tobTempReg.Sia_coddx2_tdia;
                            lobEFReg.sia_coddx3_tdia = tobTempReg.Sia_coddx3_tdia;
                            lobEFReg.sia_coddxc_tdia = tobTempReg.Sia_coddxc_tdia;
                            lobEFReg.sia_codgac_gpyp = tobTempReg.Sia_codgac_gpyp;
                            lobEFReg.sia_codact_apyp = tobTempReg.Sia_codact_apyp;
                            lobEFReg.fcm_serpos_sips = tobTempReg.Fcm_serpos_sips;
                            lobEFReg.cto_tipact_cont = tobTempReg.Cto_tipact_cont;
                            lobEFReg.sia_codpat_tpat = tobTempReg.Sia_codpat_tpat;
                            lobEFReg.sia_codpfa_prof = tobTempReg.Sia_codpfa_prof;
                            lobEFReg.fac_horprs_dfac = (Decimal)tobTempReg.Fac_horprs_dfac;
                            lobEFReg.fcm_atepro_dfac = tobTempReg.Fcm_atepro_dfac;
                            lobEFReg.sia_codare_aser = tobTempReg.Sia_codare_aser;
                            lobEFReg.sia_aresol_aser = tobTempReg.Sia_aresol_aser;
                            lobEFReg.fcm_tipser_sips = tobTempReg.Fcm_tipser_sips;
                            lobEFReg.fcm_fecedt_dfac = (DateTime)tobTempReg.Fcm_fecedt_dfac;
                            lobEFReg.sys_codusu_usux = tobTempReg.Sys_codusu_usux;
                            lobEFReg.fcm_otserv_sips = tobTempReg.Fcm_otserv_sips;
                            lobEFReg.sia_regate_rgat = tobTempReg.Sia_regate_rgat;
                            lobEFReg.sia_codcat_ceat = tobTempReg.Sia_codcat_ceat;
                            lobEFReg.fcm_ripsco_dfac = tobTempReg.Fcm_ripsco_dfac;
                            lobEFReg.far_nroreg_fads = tobTempReg.Far_nroreg_fads;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;
                            lobEFReg.inv_codgme_mgme = tobTempReg.Inv_codgme_mgme;
                            lobEFReg.inv_coduma_muma = tobTempReg.Inv_coduma_muma;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
                            #endregion
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    #region Actualizar
                    if (lobEFReg != null)
                    {
                        switch (tobTempReg.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                var lcrCodigoNuevo = tcrCodigoR1 + lobEFReg.fcm_secreg_dfac; // concatenar
                                /*
                                var llgSecuencialValido = false;

                                do
                                {
                                    var lobReg = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == lcrCodigoNuevo);
                                    if (lobReg != null)
                                    {
                                        lnuContador = lnuContador + 3;
                                        lcrCodigoNuevo = tcrCodigoR1 + "R" + lnuContador.ToString().Trim(); // concatenar
                                    }
                                    else
                                    {
                                        llgSecuencialValido = true;
                                    }

                                } while (llgSecuencialValido == false);  
                                */
                                lobEFReg.fcm_secreg_dfac = lcrCodigoNuevo; // Actualizar 
                                _context.AddToFcmmaedetallfac(lobEFReg);
                                //_context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                //_context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tobTempReg.Fcm_secreg_dfac);
                                if (lobjRegistro != null)
                                {
                                    _context.DeleteObject(lobjRegistro);
                                    //_context.SaveChanges();
                                }
                                break;
                        }

                        // funcion que genera registro para validacion frecuencia de uso
                        if (tobTempReg.Cto_frecus_cont == "1" && tobTempReg.Fcm_aplfus_sips == "1" &&
                            tobTempReg.Sis_estpro_espr == "2" && tobTempReg.Sis_estado_imaen != "E")
                        {
                            #region Gestion datos
                            // cargar datos y generar registro
                            var ldaFechaFutura = tobTempReg.Fcm_fecser_dfac.AddDays(tobTempReg.Fcm_intser_sips);
                            var lobFrecUso = new EFfcmfrecuenciuso();
                            var lobRegAux = _context.Fcmfrecuenciuso.FirstOrDefault(p => p.sia_idesec_usua == tobTempReg.Sia_idesec_usua &&
                                                                                         p.fcm_coddig_mant == tobTempReg.Fcm_coddig_mant);
                            if (lobRegAux != null)
                            {
                                lobRegAux.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                                lobRegAux.fcm_totuni_dfac = lobRegAux.fcm_totuni_dfac + tobTempReg.Fcm_totuni_dfac;
                                lobRegAux.fcm_fecser_dfac = tobTempReg.Fcm_fecser_dfac;
                                lobRegAux.fcm_fecpro_fcfu = ldaFechaFutura;
                                lobRegAux.fcm_estaux_fcfu = String.Empty;
                                lobRegAux.fcm_estreg_fcfu = "1";
                            }
                            else
                            {
                                lobFrecUso.fcm_idesec_fcfu = lobEFReg.fcm_secreg_dfac;
                                lobFrecUso.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                                lobFrecUso.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                                lobFrecUso.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                                lobFrecUso.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                                lobFrecUso.fcm_totuni_dfac = tobTempReg.Fcm_totuni_dfac;
                                lobFrecUso.fcm_fecser_dfac = tobTempReg.Fcm_fecser_dfac;
                                lobFrecUso.fcm_fecpro_fcfu = ldaFechaFutura;
                                lobFrecUso.fcm_estaux_fcfu = String.Empty;
                                lobFrecUso.fcm_estreg_fcfu = "1";
                                _context.AddToFcmfrecuenciuso(lobFrecUso);

                            }
                            #endregion
                        }
                        // Guardar todos los cambios 
                        _context.SaveChanges();
                    }
                    #endregion
                }
                // Actualizar contador en admision  (no esta en uso)
                if (lnuContador > 0)
                {
                    ADMModeloAdmadmisiones.fcvActualizGenIdItems(tcrCodigoR1, lnuContador);
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
        #region Modificar Registro
        public static void fcvActualizar(FcmModeloServDetallFacturas tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tobjModelo.Fcm_secreg_dfac);
                if (lobjRegistro != null)
                {
                    #region Datos
                    lobjRegistro.fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                    lobjRegistro.fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac;
                    lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                    lobjRegistro.fcm_tiprfa_mfac = tobjModelo.Fcm_tiprfa_mfac;
                    lobjRegistro.fcm_fecfac_mfac = (DateTime)tobjModelo.Fcm_fecfac_mfac;
                    lobjRegistro.fcm_estfac_mfac = tobjModelo.Fcm_estfac_mfac;
                    lobjRegistro.adm_nroaut_rgad = tobjModelo.Adm_nroaut_rgad;
                    lobjRegistro.sia_codrip_trip = tobjModelo.Sia_codrip_trip;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_codbar_sips = tobjModelo.Fcm_codbar_sips;
                    lobjRegistro.fcm_idesec_mant = tobjModelo.Fcm_idesec_mant;
                    lobjRegistro.fcm_codser_mant = tobjModelo.Fcm_codser_mant;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.con_codsco_ccos = tobjModelo.Con_codsco_ccos;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.fcm_desser_dfac = tobjModelo.Fcm_desser_dfac;
                    lobjRegistro.fcm_codman_mans = tobjModelo.Fcm_codman_mans;
                    lobjRegistro.fcm_fecser_dfac = (DateTime)tobjModelo.Fcm_fecser_dfac;
                    lobjRegistro.fcm_horser_dfac = (Decimal)tobjModelo.Fcm_horser_dfac;
                    lobjRegistro.fcm_perman_sips = tobjModelo.Fcm_perman_sips;
                    lobjRegistro.fcm_forfar_sips = tobjModelo.Fcm_forfar_sips;
                    lobjRegistro.fcm_conmed_sips = tobjModelo.Fcm_conmed_sips;
                    lobjRegistro.fcm_unimed_sips = tobjModelo.Fcm_unimed_sips;
                    lobjRegistro.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                    lobjRegistro.fcm_valser_mant = (float)tobjModelo.Fcm_valser_mant;
                    lobjRegistro.fcm_totuni_dfac = (int)tobjModelo.Fcm_totuni_dfac;
                    lobjRegistro.fcm_valbru_dfac = (float)tobjModelo.Fcm_valbru_dfac;
                    lobjRegistro.fcm_pordes_dfac = (float)tobjModelo.Fcm_pordes_dfac;
                    lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                    lobjRegistro.fcm_poriva_dfac = (float)tobjModelo.Fcm_poriva_dfac;
                    lobjRegistro.fcm_valiva_dfac = (float)tobjModelo.Fcm_valiva_dfac;
                    lobjRegistro.fcm_valcpa_dfac = (float)tobjModelo.Fcm_valcpa_dfac;
                    lobjRegistro.fcm_valcmo_dfac = (float)tobjModelo.Fcm_valcmo_dfac;
                    lobjRegistro.fcm_valusu_dfac = (float)tobjModelo.Fcm_valusu_dfac;
                    lobjRegistro.fcm_valcom_dfac = (float)tobjModelo.Fcm_valcom_dfac;
                    lobjRegistro.fcm_valsub_dfac = (float)tobjModelo.Fcm_valsub_dfac;
                    lobjRegistro.fcm_valfac_dfac = (float)tobjModelo.Fcm_valfac_dfac;
                    lobjRegistro.fcm_valref_dfac = (float)tobjModelo.Fcm_valref_dfac;
                    lobjRegistro.fcm_valefe_dfac = (float)tobjModelo.Fcm_valefe_dfac;
                    lobjRegistro.fcm_codtse_sips = tobjModelo.Fcm_codtse_sips;
                    lobjRegistro.fcm_codaqx_aqir = tobjModelo.Fcm_codaqx_aqir;
                    lobjRegistro.sia_tipact_tsac = tobjModelo.Sia_tipact_tsac;
                    lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                    lobjRegistro.sia_codfpr_fpor = tobjModelo.Sia_codfpr_fpor;
                    lobjRegistro.sia_codfco_fcon = tobjModelo.Sia_codfco_fcon;
                    lobjRegistro.adm_codcex_tcex = tobjModelo.Adm_codcex_tcex;
                    lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                    lobjRegistro.sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix;
                    lobjRegistro.sia_coddx1_tdia = tobjModelo.Sia_coddx1_tdia;
                    lobjRegistro.sia_coddx2_tdia = tobjModelo.Sia_coddx2_tdia;
                    lobjRegistro.sia_coddx3_tdia = tobjModelo.Sia_coddx3_tdia;
                    lobjRegistro.sia_coddxc_tdia = tobjModelo.Sia_coddxc_tdia;
                    lobjRegistro.sia_codgac_gpyp = tobjModelo.Sia_codgac_gpyp;
                    lobjRegistro.sia_codact_apyp = tobjModelo.Sia_codact_apyp;
                    lobjRegistro.fcm_serpos_sips = tobjModelo.Fcm_serpos_sips;
                    lobjRegistro.cto_tipact_cont = tobjModelo.Cto_tipact_cont;
                    lobjRegistro.sia_codpat_tpat = tobjModelo.Sia_codpat_tpat;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.fac_horprs_dfac = (Decimal)tobjModelo.Fac_horprs_dfac;
                    lobjRegistro.fcm_atepro_dfac = tobjModelo.Fcm_atepro_dfac;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.sia_aresol_aser = tobjModelo.Sia_aresol_aser;
                    lobjRegistro.fcm_tipser_sips = tobjModelo.Fcm_tipser_sips;
                    lobjRegistro.fcm_fecedt_dfac = (DateTime)tobjModelo.Fcm_fecedt_dfac;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.fcm_otserv_sips = tobjModelo.Fcm_otserv_sips;
                    lobjRegistro.sia_regate_rgat = tobjModelo.Sia_regate_rgat;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.fcm_ripsco_dfac = tobjModelo.Fcm_ripsco_dfac;
                    lobjRegistro.far_nroreg_fads = tobjModelo.Far_nroreg_fads;
                    lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                    lobjRegistro.inv_secart_inar = tobjModelo.Inv_secart_inar;
                    lobjRegistro.inv_codaux_inar = tobjModelo.Inv_codaux_inar;
                    lobjRegistro.inv_codgme_mgme = tobjModelo.Inv_codgme_mgme;
                    lobjRegistro.inv_coduma_muma = tobjModelo.Inv_coduma_muma;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    #endregion
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
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEstados: Actualizar estados facturas
        /// <summary>
        ///  <para>Actualizar: Estado facturacion</para>
        /// </summary>
        public static void fcvActualizarEstados(String tcrCodigo, String tcrEstFact)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobReg != null)
                {
                    lobReg.fcm_estfac_mfac = tcrEstFact;
                    lobReg.sis_estpro_espr = tcrEstFact;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEstadosFacturas: Estado detalles facturacion para una admision
        /// <summary>
        ///  <para>Actualizar: Estado detalles facturacion para una admision</para>
        /// </summary>
        public static void fcvActualizarEstadosFacturas(String tcrCodigoAdmision, String tcrEstadoFact)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Fcmmaedetallfac where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null)
                {
                    var lcrEstTipo = "1";

                    foreach (var lobReg in lobConsulta)
                    {
                        lcrEstTipo = "1";
                        if (tcrEstadoFact == "2")
                        {
                            lcrEstTipo = "2";
                        }
                        else if (tcrEstadoFact == "3")
                        {
                            lcrEstTipo = lobReg.fcm_tiprfa_mfac;
                        }
                        lobReg.fcm_tiprfa_mfac = lcrEstTipo;
                        lobReg.fcm_estfac_mfac = tcrEstadoFact;
                        lobReg.sis_estpro_espr = tcrEstadoFact;
                    }
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEpsDetallesFacturas: Actualizar codigo eps o contrato en detalles facturacion para una admision
        /// <summary>
        ///  <para> Actualizar codigo eps o contrato en detalles facturacion para una admision y servicios no confirmados</para>
        /// </summary>
        public static void fcvActualizarEpsDetallesFacturas(String tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                var lobAdm = (from tmp in _context.Admregadmision where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp).FirstOrDefault();
                var lobConsulta = from tmp in _context.Fcmmaedetallfac where tmp.adm_secadm_rgad == tcrCodigoAdmision select tmp;
                if (lobConsulta != null && lobAdm != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        if (lobReg.sis_estpro_espr == "1" && lobReg.fcm_estfac_mfac == "1")
                        {
                            lobReg.cto_seccon_cont = lobAdm.cto_seccon_cont;
                            lobReg.cto_nrocon_cont = lobAdm.cto_nrocon_cont;
                            lobReg.sia_codeps_teps = lobAdm.sia_codeps_teps;
                        }
                        if (lobReg.cto_seccon_cont == lobAdm.cto_seccon_cont)
                        {
                            lobReg.cto_seccon_cont = lobAdm.cto_seccon_cont;
                            lobReg.cto_nrocon_cont = lobAdm.cto_nrocon_cont;
                            lobReg.sia_codeps_teps = lobAdm.sia_codeps_teps;
                        }
                    }
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMAEDETALLFAC: Logica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaedetallfac(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<FcmModeloServDetallFacturas> flsListaFcmmaedetallfac(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaedetallfac in _context.Fcmmaedetallfac
                                  join ctomaescontrato in _context.Ctomaescontrato on fcmmaedetallfac.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                  join siatablaeps in _context.Siatablaeps on fcmmaedetallfac.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                  join fcmcenproduccio in _context.Fcmcenproduccio on fcmmaedetallfac.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                  join siatipactividad in _context.Siatipactividad on fcmmaedetallfac.sia_tipact_tsac equals siatipactividad.sia_tipact_tsac into tmsiatipactividad
                                  join siamaeprofsalud in _context.Siamaeprofsalud on fcmmaedetallfac.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join fcmmanservicips in _context.Fcmmanservicips on fcmmaedetallfac.fcm_coddig_mant equals fcmmanservicips.fcm_coddig_mant into tmfcmmanservicips
                                  from cont in tmctomaescontrato.DefaultIfEmpty()
                                  from teps in tmsiatablaeps.DefaultIfEmpty()
                                  from tsac in tmsiatipactividad.DefaultIfEmpty()
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                  where fcmmaedetallfac.adm_secadm_rgad == tcrBuscar
                                  orderby fcmmaedetallfac.fcm_numfac_mfac, fcmmaedetallfac.sia_codrip_trip
                                  select new FcmModeloServDetallFacturas
                                  {
                                      #region Datos
                                      Fcm_secreg_dfac = fcmmaedetallfac.fcm_secreg_dfac,
                                      Adm_secadm_rgad = fcmmaedetallfac.adm_secadm_rgad,
                                      Sia_idesec_usua = fcmmaedetallfac.sia_idesec_usua,
                                      Sia_tipide_tide = fcmmaedetallfac.sia_tipide_tide,
                                      Sia_nroide_usua = fcmmaedetallfac.sia_nroide_usua,
                                      Cto_seccon_cont = fcmmaedetallfac.cto_seccon_cont,
                                      Cto_nrocon_cont = fcmmaedetallfac.cto_nrocon_cont,
                                      Sia_codeps_teps = fcmmaedetallfac.sia_codeps_teps,
                                      Sis_idterc_sitr = fcmmaedetallfac.sis_idterc_sitr,
                                      Fcm_secreg_mfac = fcmmaedetallfac.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = fcmmaedetallfac.fcm_numfac_mfac,
                                      Fcm_tiprfa_mfac = fcmmaedetallfac.fcm_tiprfa_mfac,
                                      Fcm_fecfac_mfac = (DateTime)fcmmaedetallfac.fcm_fecfac_mfac,
                                      Fcm_estfac_mfac = fcmmaedetallfac.fcm_estfac_mfac,
                                      Adm_nroaut_rgad = fcmmaedetallfac.adm_nroaut_rgad,
                                      Sia_codrip_trip = fcmmaedetallfac.sia_codrip_trip,
                                      Fcm_idesec_sips = fcmmaedetallfac.fcm_idesec_sips,
                                      Fcm_codbar_sips = fcmmaedetallfac.fcm_codbar_sips,
                                      Fcm_idesec_mant = fcmmaedetallfac.fcm_idesec_mant,
                                      Fcm_codser_mant = fcmmaedetallfac.fcm_codser_mant,
                                      Fcm_coddig_mant = fcmmaedetallfac.fcm_coddig_mant,
                                      Con_codsco_ccos = fcmmaedetallfac.con_codsco_ccos,
                                      Fcm_codcpr_cpro = fcmmaedetallfac.fcm_codcpr_cpro,
                                      Fcm_desser_dfac = fcmmaedetallfac.fcm_desser_dfac,
                                      Fcm_codman_mans = fcmmaedetallfac.fcm_codman_mans,
                                      Fcm_fecser_dfac = (DateTime)fcmmaedetallfac.fcm_fecser_dfac,
                                      Fcm_horser_dfac = (Decimal)fcmmaedetallfac.fcm_horser_dfac,
                                      Fcm_perman_sips = fcmmaedetallfac.fcm_perman_sips,
                                      Fcm_forfar_sips = fcmmaedetallfac.fcm_forfar_sips,
                                      Fcm_conmed_sips = fcmmaedetallfac.fcm_conmed_sips,
                                      Fcm_unimed_sips = fcmmaedetallfac.fcm_unimed_sips,
                                      Fcm_autdes_ades = fcmmaedetallfac.fcm_autdes_ades,
                                      Fcm_valser_mant = (float)fcmmaedetallfac.fcm_valser_mant,
                                      Fcm_totuni_dfac = (int)fcmmaedetallfac.fcm_totuni_dfac,
                                      Fcm_valbru_dfac = (float)fcmmaedetallfac.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaedetallfac.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaedetallfac.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)fcmmaedetallfac.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)fcmmaedetallfac.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)fcmmaedetallfac.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)fcmmaedetallfac.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)fcmmaedetallfac.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)fcmmaedetallfac.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)fcmmaedetallfac.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)fcmmaedetallfac.fcm_valfac_dfac,
                                      Fcm_valref_dfac = (float)fcmmaedetallfac.fcm_valref_dfac,
                                      Fcm_codtse_sips = fcmmaedetallfac.fcm_codtse_sips,
                                      Fcm_codaqx_aqir = fcmmaedetallfac.fcm_codaqx_aqir,
                                      Sia_tipact_tsac = fcmmaedetallfac.sia_tipact_tsac,
                                      Adm_codtat_tatn = fcmmaedetallfac.adm_codtat_tatn,
                                      Sia_codfpr_fpor = fcmmaedetallfac.sia_codfpr_fpor,
                                      Sia_codfco_fcon = fcmmaedetallfac.sia_codfco_fcon,
                                      Adm_codcex_tcex = fcmmaedetallfac.adm_codcex_tcex,
                                      Sia_coddia_tdia = fcmmaedetallfac.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = fcmmaedetallfac.sia_tipdxp_tdix,
                                      Sia_coddx1_tdia = fcmmaedetallfac.sia_coddx1_tdia,
                                      Sia_coddx2_tdia = fcmmaedetallfac.sia_coddx2_tdia,
                                      Sia_coddx3_tdia = fcmmaedetallfac.sia_coddx3_tdia,
                                      Sia_coddxc_tdia = fcmmaedetallfac.sia_coddxc_tdia,
                                      Sia_codgac_gpyp = fcmmaedetallfac.sia_codgac_gpyp,
                                      Sia_codact_apyp = fcmmaedetallfac.sia_codact_apyp,
                                      Fcm_serpos_sips = fcmmaedetallfac.fcm_serpos_sips,
                                      Cto_tipact_cont = fcmmaedetallfac.cto_tipact_cont,
                                      Sia_codpat_tpat = fcmmaedetallfac.sia_codpat_tpat,
                                      Sia_codpfa_prof = fcmmaedetallfac.sia_codpfa_prof,
                                      Fac_horprs_dfac = (Decimal)fcmmaedetallfac.fac_horprs_dfac,
                                      Fcm_atepro_dfac = fcmmaedetallfac.fcm_atepro_dfac,
                                      Sia_codare_aser = fcmmaedetallfac.sia_codare_aser,
                                      Sia_aresol_aser = fcmmaedetallfac.sia_aresol_aser,
                                      Desia_aresol_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == fcmmaedetallfac.sia_aresol_aser).sia_desare_aser,
                                      Fcm_tipser_sips = fcmmaedetallfac.fcm_tipser_sips,
                                      Fcm_fecedt_dfac = (DateTime)fcmmaedetallfac.fcm_fecedt_dfac,
                                      Sys_codusu_usux = fcmmaedetallfac.sys_codusu_usux,
                                      Fcm_otserv_sips = fcmmaedetallfac.fcm_otserv_sips,
                                      Sia_regate_rgat = fcmmaedetallfac.sia_regate_rgat,
                                      Sia_codcat_ceat = fcmmaedetallfac.sia_codcat_ceat,
                                      Fcm_ripsco_dfac = fcmmaedetallfac.fcm_ripsco_dfac,
                                      Far_nroreg_fads = fcmmaedetallfac.far_nroreg_fads,
                                      Inv_codalm_inal = fcmmaedetallfac.inv_codalm_inal,
                                      Inv_secart_inar = fcmmaedetallfac.inv_secart_inar,
                                      Inv_codaux_inar = fcmmaedetallfac.inv_codaux_inar,
                                      Inv_codgme_mgme = fcmmaedetallfac.inv_codgme_mgme,
                                      Inv_coduma_muma = fcmmaedetallfac.inv_coduma_muma,
                                      Sis_estpro_espr = fcmmaedetallfac.sis_estpro_espr,
                                      Cto_descon_cont = cont.cto_descon_cont,
                                      Cto_sepser_cont = cont.cto_sepser_cont,
                                      Cto_frecus_cont = cont.cto_frecus_cont,
                                      Cto_fcdian_cont = cont.cto_fcdian_cont,
                                      Sia_deseps_teps = teps.sia_deseps_teps,
                                      Sia_desact_tsac = tsac.sia_desact_tsac,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                      Fcm_aplfus_sips = sips.fcm_aplfus_sips,
                                      Fcm_intser_sips = (int)sips.fcm_intser_sips,
                                      Far_codcum_famd = sips.fcm_codcum_sips,
                                      Fcm_secres_srfa = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == cont.fcm_secraz_fcem).fcm_secres_srfa,
                                      Sia_desare_aser = _context.Siaareapreservi.FirstOrDefault(p => p.sia_codare_aser == fcmmaedetallfac.sia_codare_aser).sia_desare_aser,
                                      Fcm_desaqx_aqir = _context.Fcmactquirurgic.FirstOrDefault(p => p.fcm_codaqx_aqir == fcmmaedetallfac.fcm_codaqx_aqir).fcm_desaqx_aqir,
                                      Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(p => p.sia_codrip_trip == fcmmaedetallfac.sia_codrip_trip).sia_desrip_trip,
                                      Fcm_desfac_mfac = fcmmaedetallfac.fcm_estfac_mfac == "2" ? "CONFIRMADA" : fcmmaedetallfac.fcm_estfac_mfac == "1" ? "ABIERTA" : "ANULADA",
                                      Sis_estado_imaen = "I",
                                      Fcm_codpro_fcpr = "NA",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsListaFcmmaedetallfac: Listar Registros detalles admision
        /// <summary>
        /// <para>IG = Codigo unico del paciente en el sistema</para>
        /// <para>AP = Codigo unico del registro Admision</para>
        /// </summary>
        public static List<FcmModeloServDetallFacturas> flsListaFcmmaedetallfac(String tcrTipoId, String tcrIdCodigo)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipoId == "IG")
                {
                    #region Consulta
                    var lobConsulta = from fcmmaedetallfac in _context.Fcmmaedetallfac
                                      where fcmmaedetallfac.sia_idesec_usua == tcrIdCodigo
                                      select new FcmModeloServDetallFacturas
                                      {
                                          Fcm_secreg_dfac = fcmmaedetallfac.fcm_secreg_dfac,
                                          Adm_secadm_rgad = fcmmaedetallfac.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmmaedetallfac.sia_idesec_usua,
                                          Sia_tipide_tide = fcmmaedetallfac.sia_tipide_tide,
                                          Sia_nroide_usua = fcmmaedetallfac.sia_nroide_usua,
                                          Cto_seccon_cont = fcmmaedetallfac.cto_seccon_cont,
                                          Cto_nrocon_cont = fcmmaedetallfac.cto_nrocon_cont,
                                          Sia_codeps_teps = fcmmaedetallfac.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmmaedetallfac.sis_idterc_sitr,
                                          Fcm_secreg_mfac = fcmmaedetallfac.fcm_secreg_mfac,
                                          Fcm_numfac_mfac = fcmmaedetallfac.fcm_numfac_mfac,
                                          Fcm_tiprfa_mfac = fcmmaedetallfac.fcm_tiprfa_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmmaedetallfac.fcm_fecfac_mfac,
                                          Fcm_estfac_mfac = fcmmaedetallfac.fcm_estfac_mfac,
                                          Adm_nroaut_rgad = fcmmaedetallfac.adm_nroaut_rgad,
                                          Sia_codrip_trip = fcmmaedetallfac.sia_codrip_trip,
                                          Fcm_idesec_sips = fcmmaedetallfac.fcm_idesec_sips,
                                          Fcm_codbar_sips = fcmmaedetallfac.fcm_codbar_sips,
                                          Fcm_idesec_mant = fcmmaedetallfac.fcm_idesec_mant,
                                          Fcm_codser_mant = fcmmaedetallfac.fcm_codser_mant,
                                          Fcm_coddig_mant = fcmmaedetallfac.fcm_coddig_mant,
                                          Con_codsco_ccos = fcmmaedetallfac.con_codsco_ccos,
                                          Fcm_codcpr_cpro = fcmmaedetallfac.fcm_codcpr_cpro,
                                          Fcm_desser_dfac = fcmmaedetallfac.fcm_desser_dfac,
                                          Fcm_codman_mans = fcmmaedetallfac.fcm_codman_mans,
                                          Fcm_fecser_dfac = (DateTime)fcmmaedetallfac.fcm_fecser_dfac,
                                          Fcm_horser_dfac = (Decimal)fcmmaedetallfac.fcm_horser_dfac,
                                          Fcm_perman_sips = fcmmaedetallfac.fcm_perman_sips,
                                          Fcm_forfar_sips = fcmmaedetallfac.fcm_forfar_sips,
                                          Fcm_conmed_sips = fcmmaedetallfac.fcm_conmed_sips,
                                          Fcm_unimed_sips = fcmmaedetallfac.fcm_unimed_sips,
                                          Fcm_autdes_ades = fcmmaedetallfac.fcm_autdes_ades,
                                          Fcm_valser_mant = (float)fcmmaedetallfac.fcm_valser_mant,
                                          Fcm_totuni_dfac = (int)fcmmaedetallfac.fcm_totuni_dfac,
                                          Fcm_valbru_dfac = (float)fcmmaedetallfac.fcm_valbru_dfac,
                                          Fcm_pordes_dfac = (float)fcmmaedetallfac.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaedetallfac.fcm_valdes_dfac,
                                          Fcm_poriva_dfac = (float)fcmmaedetallfac.fcm_poriva_dfac,
                                          Fcm_valiva_dfac = (float)fcmmaedetallfac.fcm_valiva_dfac,
                                          Fcm_valcpa_dfac = (float)fcmmaedetallfac.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (float)fcmmaedetallfac.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (float)fcmmaedetallfac.fcm_valusu_dfac,
                                          Fcm_valcom_dfac = (float)fcmmaedetallfac.fcm_valcom_dfac,
                                          Fcm_valsub_dfac = (float)fcmmaedetallfac.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (float)fcmmaedetallfac.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (float)fcmmaedetallfac.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (float)fcmmaedetallfac.fcm_valefe_dfac,
                                          Fcm_codtse_sips = fcmmaedetallfac.fcm_codtse_sips,
                                          Fcm_codaqx_aqir = fcmmaedetallfac.fcm_codaqx_aqir,
                                          Sia_tipact_tsac = fcmmaedetallfac.sia_tipact_tsac,
                                          Adm_codtat_tatn = fcmmaedetallfac.adm_codtat_tatn,
                                          Sia_codfpr_fpor = fcmmaedetallfac.sia_codfpr_fpor,
                                          Sia_codfco_fcon = fcmmaedetallfac.sia_codfco_fcon,
                                          Adm_codcex_tcex = fcmmaedetallfac.adm_codcex_tcex,
                                          Sia_coddia_tdia = fcmmaedetallfac.sia_coddia_tdia,
                                          Sia_tipdxp_tdix = fcmmaedetallfac.sia_tipdxp_tdix,
                                          Sia_coddx1_tdia = fcmmaedetallfac.sia_coddx1_tdia,
                                          Sia_coddx2_tdia = fcmmaedetallfac.sia_coddx2_tdia,
                                          Sia_coddx3_tdia = fcmmaedetallfac.sia_coddx3_tdia,
                                          Sia_coddxc_tdia = fcmmaedetallfac.sia_coddxc_tdia,
                                          Sia_codgac_gpyp = fcmmaedetallfac.sia_codgac_gpyp,
                                          Sia_codact_apyp = fcmmaedetallfac.sia_codact_apyp,
                                          Fcm_serpos_sips = fcmmaedetallfac.fcm_serpos_sips,
                                          Cto_tipact_cont = fcmmaedetallfac.cto_tipact_cont,
                                          Sia_codpat_tpat = fcmmaedetallfac.sia_codpat_tpat,
                                          Sia_codpfa_prof = fcmmaedetallfac.sia_codpfa_prof,
                                          Fac_horprs_dfac = (Decimal)fcmmaedetallfac.fac_horprs_dfac,
                                          Fcm_atepro_dfac = fcmmaedetallfac.fcm_atepro_dfac,
                                          Sia_codare_aser = fcmmaedetallfac.sia_codare_aser,
                                          Sia_aresol_aser = fcmmaedetallfac.sia_aresol_aser,
                                          Fcm_tipser_sips = fcmmaedetallfac.fcm_tipser_sips,
                                          Fcm_fecedt_dfac = (DateTime)fcmmaedetallfac.fcm_fecedt_dfac,
                                          Sys_codusu_usux = fcmmaedetallfac.sys_codusu_usux,
                                          Fcm_otserv_sips = fcmmaedetallfac.fcm_otserv_sips,
                                          Sia_regate_rgat = fcmmaedetallfac.sia_regate_rgat,
                                          Sia_codcat_ceat = fcmmaedetallfac.sia_codcat_ceat,
                                          Fcm_ripsco_dfac = fcmmaedetallfac.fcm_ripsco_dfac,
                                          Far_nroreg_fads = fcmmaedetallfac.far_nroreg_fads,
                                          Inv_codalm_inal = fcmmaedetallfac.inv_codalm_inal,
                                          Inv_secart_inar = fcmmaedetallfac.inv_secart_inar,
                                          Inv_codaux_inar = fcmmaedetallfac.inv_codaux_inar,
                                          Inv_codgme_mgme = fcmmaedetallfac.inv_codgme_mgme,
                                          Inv_coduma_muma = fcmmaedetallfac.inv_coduma_muma,
                                          Sis_estpro_espr = fcmmaedetallfac.sis_estpro_espr,
                                          Fcm_codpro_fcpr = "NA",
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region Consulta
                    var lobConsulta = from fcmmaedetallfac in _context.Fcmmaedetallfac
                                      where fcmmaedetallfac.adm_secadm_rgad == tcrIdCodigo
                                      select new FcmModeloServDetallFacturas
                                      {
                                          Fcm_secreg_dfac = fcmmaedetallfac.fcm_secreg_dfac,
                                          Adm_secadm_rgad = fcmmaedetallfac.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmmaedetallfac.sia_idesec_usua,
                                          Sia_tipide_tide = fcmmaedetallfac.sia_tipide_tide,
                                          Sia_nroide_usua = fcmmaedetallfac.sia_nroide_usua,
                                          Cto_seccon_cont = fcmmaedetallfac.cto_seccon_cont,
                                          Cto_nrocon_cont = fcmmaedetallfac.cto_nrocon_cont,
                                          Sia_codeps_teps = fcmmaedetallfac.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmmaedetallfac.sis_idterc_sitr,
                                          Fcm_secreg_mfac = fcmmaedetallfac.fcm_secreg_mfac,
                                          Fcm_numfac_mfac = fcmmaedetallfac.fcm_numfac_mfac,
                                          Fcm_tiprfa_mfac = fcmmaedetallfac.fcm_tiprfa_mfac,
                                          Fcm_fecfac_mfac = (DateTime)fcmmaedetallfac.fcm_fecfac_mfac,
                                          Fcm_estfac_mfac = fcmmaedetallfac.fcm_estfac_mfac,
                                          Adm_nroaut_rgad = fcmmaedetallfac.adm_nroaut_rgad,
                                          Sia_codrip_trip = fcmmaedetallfac.sia_codrip_trip,
                                          Fcm_idesec_sips = fcmmaedetallfac.fcm_idesec_sips,
                                          Fcm_codbar_sips = fcmmaedetallfac.fcm_codbar_sips,
                                          Fcm_idesec_mant = fcmmaedetallfac.fcm_idesec_mant,
                                          Fcm_codser_mant = fcmmaedetallfac.fcm_codser_mant,
                                          Fcm_coddig_mant = fcmmaedetallfac.fcm_coddig_mant,
                                          Con_codsco_ccos = fcmmaedetallfac.con_codsco_ccos,
                                          Fcm_codcpr_cpro = fcmmaedetallfac.fcm_codcpr_cpro,
                                          Fcm_desser_dfac = fcmmaedetallfac.fcm_desser_dfac,
                                          Fcm_codman_mans = fcmmaedetallfac.fcm_codman_mans,
                                          Fcm_fecser_dfac = (DateTime)fcmmaedetallfac.fcm_fecser_dfac,
                                          Fcm_horser_dfac = (Decimal)fcmmaedetallfac.fcm_horser_dfac,
                                          Fcm_perman_sips = fcmmaedetallfac.fcm_perman_sips,
                                          Fcm_forfar_sips = fcmmaedetallfac.fcm_forfar_sips,
                                          Fcm_conmed_sips = fcmmaedetallfac.fcm_conmed_sips,
                                          Fcm_unimed_sips = fcmmaedetallfac.fcm_unimed_sips,
                                          Fcm_autdes_ades = fcmmaedetallfac.fcm_autdes_ades,
                                          Fcm_valser_mant = (float)fcmmaedetallfac.fcm_valser_mant,
                                          Fcm_totuni_dfac = (int)fcmmaedetallfac.fcm_totuni_dfac,
                                          Fcm_valbru_dfac = (float)fcmmaedetallfac.fcm_valbru_dfac,
                                          Fcm_pordes_dfac = (float)fcmmaedetallfac.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaedetallfac.fcm_valdes_dfac,
                                          Fcm_poriva_dfac = (float)fcmmaedetallfac.fcm_poriva_dfac,
                                          Fcm_valiva_dfac = (float)fcmmaedetallfac.fcm_valiva_dfac,
                                          Fcm_valcpa_dfac = (float)fcmmaedetallfac.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (float)fcmmaedetallfac.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (float)fcmmaedetallfac.fcm_valusu_dfac,
                                          Fcm_valcom_dfac = (float)fcmmaedetallfac.fcm_valcom_dfac,
                                          Fcm_valsub_dfac = (float)fcmmaedetallfac.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (float)fcmmaedetallfac.fcm_valfac_dfac,
                                          Fcm_valref_dfac = (float)fcmmaedetallfac.fcm_valref_dfac,
                                          Fcm_valefe_dfac = (float)fcmmaedetallfac.fcm_valefe_dfac,
                                          Fcm_codtse_sips = fcmmaedetallfac.fcm_codtse_sips,
                                          Fcm_codaqx_aqir = fcmmaedetallfac.fcm_codaqx_aqir,
                                          Sia_tipact_tsac = fcmmaedetallfac.sia_tipact_tsac,
                                          Adm_codtat_tatn = fcmmaedetallfac.adm_codtat_tatn,
                                          Sia_codfpr_fpor = fcmmaedetallfac.sia_codfpr_fpor,
                                          Sia_codfco_fcon = fcmmaedetallfac.sia_codfco_fcon,
                                          Adm_codcex_tcex = fcmmaedetallfac.adm_codcex_tcex,
                                          Sia_coddia_tdia = fcmmaedetallfac.sia_coddia_tdia,
                                          Sia_tipdxp_tdix = fcmmaedetallfac.sia_tipdxp_tdix,
                                          Sia_coddx1_tdia = fcmmaedetallfac.sia_coddx1_tdia,
                                          Sia_coddx2_tdia = fcmmaedetallfac.sia_coddx2_tdia,
                                          Sia_coddx3_tdia = fcmmaedetallfac.sia_coddx3_tdia,
                                          Sia_coddxc_tdia = fcmmaedetallfac.sia_coddxc_tdia,
                                          Sia_codgac_gpyp = fcmmaedetallfac.sia_codgac_gpyp,
                                          Sia_codact_apyp = fcmmaedetallfac.sia_codact_apyp,
                                          Fcm_serpos_sips = fcmmaedetallfac.fcm_serpos_sips,
                                          Cto_tipact_cont = fcmmaedetallfac.cto_tipact_cont,
                                          Sia_codpat_tpat = fcmmaedetallfac.sia_codpat_tpat,
                                          Sia_codpfa_prof = fcmmaedetallfac.sia_codpfa_prof,
                                          Fac_horprs_dfac = (Decimal)fcmmaedetallfac.fac_horprs_dfac,
                                          Fcm_atepro_dfac = fcmmaedetallfac.fcm_atepro_dfac,
                                          Sia_codare_aser = fcmmaedetallfac.sia_codare_aser,
                                          Sia_aresol_aser = fcmmaedetallfac.sia_aresol_aser,
                                          Fcm_tipser_sips = fcmmaedetallfac.fcm_tipser_sips,
                                          Fcm_fecedt_dfac = (DateTime)fcmmaedetallfac.fcm_fecedt_dfac,
                                          Sys_codusu_usux = fcmmaedetallfac.sys_codusu_usux,
                                          Fcm_otserv_sips = fcmmaedetallfac.fcm_otserv_sips,
                                          Sia_regate_rgat = fcmmaedetallfac.sia_regate_rgat,
                                          Sia_codcat_ceat = fcmmaedetallfac.sia_codcat_ceat,
                                          Fcm_ripsco_dfac = fcmmaedetallfac.fcm_ripsco_dfac,
                                          Far_nroreg_fads = fcmmaedetallfac.far_nroreg_fads,
                                          Inv_codalm_inal = fcmmaedetallfac.inv_codalm_inal,
                                          Inv_secart_inar = fcmmaedetallfac.inv_secart_inar,
                                          Inv_codaux_inar = fcmmaedetallfac.inv_codaux_inar,
                                          Inv_codgme_mgme = fcmmaedetallfac.inv_codgme_mgme,
                                          Inv_coduma_muma = fcmmaedetallfac.inv_coduma_muma,
                                          Sis_estpro_espr = fcmmaedetallfac.sis_estpro_espr,
                                          Fcm_codpro_fcpr = "NA",
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmcuentacobrms
    /// </summary>
    public class ModeloCuentaCobro : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_mfcb: Código unico registro
        private String _fcm_secreg_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la cuenta de cobro (generado por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfcb
        {
            get { return _fcm_secreg_mfcb; }
            set
            {
                if (_fcm_secreg_mfcb == value) return;
                _fcm_secreg_mfcb = value;
                OnPropertyChanged("Fcm_secreg_mfcb");
            }
        }
        #endregion
        #region Fcm_numfac_mfac: Numero Factura
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada al confirmar la factura o cuenta
        /// de cobro
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
        #region Fcm_secres_srfa: Codigo unico en sistema Resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Secuencial unico en sistema resolución Dian desde la cual</para>
        /// <para>se genera el numero de factura (cuando aplique)</para>
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
        #region Fcm_tipfac_mfcb: Tipo Factura a generar Sistema/Dian
        private String _fcm_tipfac_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Tipo Factura a generar</para>
        /// <para>NOMBRE: fcm_tipfac_mfcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Tipo factura a generar: 1=Numero Factura Dian 2=Secuencial del Sistema</para>
        /// </summary>
        public String Fcm_tipfac_mfcb
        {
            get { return _fcm_tipfac_mfcb; }
            set
            {
                if (_fcm_tipfac_mfcb == value) return;
                _fcm_tipfac_mfcb = value;
                OnPropertyChanged("Fcm_tipfac_mfcb");
            }
        }
        #endregion
        #region Fcm_fecfac_mfac: Fecha factura
        private DateTime _fcm_fecfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue confirmada y generado
        /// el secuencial de factrua)
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
        #region Sia_fecini_mfcb: Fecha inicio periodo
        private DateTime _sia_fecini_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Fecha inicio periodo</para>
        /// <para>NOMBRE: sia_fecini_mfcb (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Fecha inicial periodo facturacion
        /// </para>
        /// </summary>
        public DateTime Sia_fecini_mfcb
        {
            get { return _sia_fecini_mfcb; }
            set
            {
                if (_sia_fecini_mfcb == value) return;
                _sia_fecini_mfcb = value;
                OnPropertyChanged("Sia_fecini_mfcb");
            }
        }
        #endregion
        #region Sia_fecfin_mfcb: Fecha fin periodo
        private DateTime _sia_fecfin_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Fecha fin periodo</para>
        /// <para>NOMBRE: sia_fecfin_mfcb (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha final periodo facturacion
        /// </para>
        /// </summary>
        public DateTime Sia_fecfin_mfcb
        {
            get { return _sia_fecfin_mfcb; }
            set
            {
                if (_sia_fecfin_mfcb == value) return;
                _sia_fecfin_mfcb = value;
                OnPropertyChanged("Sia_fecfin_mfcb");
            }
        }
        #endregion
        #region Fcm_descue_mfcb: Descripción
        private String _fcm_descue_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_descue_mfcb (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota de la cuanta de cobro
        /// </para>
        /// </summary>
        public String Fcm_descue_mfcb
        {
            get { return _fcm_descue_mfcb; }
            set
            {
                if (_fcm_descue_mfcb == value) return;
                _fcm_descue_mfcb = value;
                OnPropertyChanged("Fcm_descue_mfcb");
            }
        }
        #endregion
        #region Fcm_notcue_mfcb: Nota impresa
        private String _fcm_notcue_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Nota impresa</para>
        /// <para>NOMBRE: fcm_notcue_mfcb (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Nota detallada para el formato impreso
        /// </para>
        /// </summary>
        public String Fcm_notcue_mfcb
        {
            get { return _fcm_notcue_mfcb; }
            set
            {
                if (_fcm_notcue_mfcb == value) return;
                _fcm_notcue_mfcb = value;
                OnPropertyChanged("Fcm_notcue_mfcb");
            }
        }
        #endregion
        #region Fcm_firmar_mfcb: Firma responsable
        private String _fcm_firmar_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Firma responsable</para>
        /// <para>NOMBRE: fcm_firmar_mfcb (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Nombre de la persona que firma el formato impreso
        /// </para>
        /// </summary>
        public String Fcm_firmar_mfcb
        {
            get { return _fcm_firmar_mfcb; }
            set
            {
                if (_fcm_firmar_mfcb == value) return;
                _fcm_firmar_mfcb = value;
                OnPropertyChanged("Fcm_firmar_mfcb");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Cto_nrocon_cont: Número Contrato
        private String _cto_nrocon_cont;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public String Cto_nrocon_cont
        {
            get { return _cto_nrocon_cont; }
            set
            {
                if (_cto_nrocon_cont == value) return;
                _cto_nrocon_cont = value;
                OnPropertyChanged("Cto_nrocon_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Fcm_valbru_dfac: Valor bruto factura
        private float _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valbru_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private float _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_poriva_dfac: Porcentaje del IVA
        private float _fcm_poriva_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float Fcm_poriva_dfac
        {
            get { return _fcm_poriva_dfac; }
            set
            {
                if (_fcm_poriva_dfac == value) return;
                _fcm_poriva_dfac = value;
                OnPropertyChanged("Fcm_poriva_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        private float _fcm_valiva_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float Fcm_valiva_dfac
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
        #region Fcm_valcpa_dfac: Valor copago
        private float _fcm_valcpa_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float Fcm_valcpa_dfac
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
        private float _fcm_valcmo_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float Fcm_valcmo_dfac
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
        private float _fcm_valusu_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float Fcm_valusu_dfac
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
        #region Fcm_valsub_dfac: Valor subtotal servicio
        private float _fcm_valsub_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float Fcm_valsub_dfac
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
        private float _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valfac_dfac
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
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION: Código del facturador usuario del sistema que que realiza la ultima modificacion</para>
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
        #region Fcm_conest_mfcb: Contador detalles
        private int _fcm_conest_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Contador detalles</para>
        /// <para>NOMBRE: fcm_conest_mfcb (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos  detalles cada factura
        /// relacionada
        /// </para>
        /// </summary>
        public int Fcm_conest_mfcb
        {
            get { return _fcm_conest_mfcb; }
            set
            {
                if (_fcm_conest_mfcb == value) return;
                _fcm_conest_mfcb = value;
                OnPropertyChanged("Fcm_conest_mfcb");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la cuenta de cobro: 1=Abierta
        /// 2=Confirmada 3=Anulada
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Sia_codnit_teps: Numero Nit EPS
        private String _sia_codnit_teps;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Numero Nit EPS</para>
        /// <para>NOMBRE: sia_codnit_teps (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero del Nit de la EPS o Asegurador
        /// </para>
        /// </summary>
        public String Sia_codnit_teps
        {
            get { return _sia_codnit_teps; }
            set
            {
                if (_sia_codnit_teps == value) return;
                _sia_codnit_teps = value;
                OnPropertyChanged("Sia_codnit_teps");
            }
        }
        #endregion
        // Datos Complemento resolucion Dian (cuando aplique)
        #region Fcm_numres_srfa: Resolucion DIAN
        private String _fcm_numres_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la resolucion Dian (cuando aplique)
        /// </para>
        /// </summary>
        public String Fcm_numres_srfa
        {
            get { return _fcm_numres_srfa; }
            set
            {
                if (_fcm_numres_srfa == value) return;
                _fcm_numres_srfa = value;
                OnPropertyChanged("Fcm_numres_srfa");
            }
        }
        #endregion
        #region Fcm_desres_srfa: Descripción Resolucion Dian
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Descripcion o nota  de la resolucion Dian</para>
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
        #region Fcm_notenc_srfa: Nota de encabezado
        private String _fcm_notenc_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_notenc_srfa
        {
            get { return _fcm_notenc_srfa; }
            set
            {
                if (_fcm_notenc_srfa == value) return;
                _fcm_notenc_srfa = value;
                OnPropertyChanged("Fcm_notenc_srfa");
            }
        }
        #endregion
        #region Fcm_noppag_srfa: Nota pie de pagina
        private String _fcm_noppag_srfa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public String Fcm_noppag_srfa
        {
            get { return _fcm_noppag_srfa; }
            set
            {
                if (_fcm_noppag_srfa == value) return;
                _fcm_noppag_srfa = value;
                OnPropertyChanged("Fcm_noppag_srfa");
            }
        }
        #endregion
        // Datos del tercero contable 
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Sis_tipide_tido: Tipo documento
        private String _sis_tipide_tido;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: sis_tipide_tido (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public String Sis_tipide_tido
        {
            get { return _sis_tipide_tido; }
            set
            {
                if (_sis_tipide_tido == value) return;
                _sis_tipide_tido = value;
                OnPropertyChanged("Sis_tipide_tido");
            }
        }
        #endregion
        #region Sis_numide_sitr: Numero dcumento
        private String _sis_numide_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero dcumento</para>
        /// <para>NOMBRE: sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero docuemto de identificacion del tercero
        /// </para>
        /// </summary>
        public String Sis_numide_sitr
        {
            get { return _sis_numide_sitr; }
            set
            {
                if (_sis_numide_sitr == value) return;
                _sis_numide_sitr = value;
                OnPropertyChanged("Sis_numide_sitr");
            }
        }
        #endregion
        #region Sis_telefo_sitr: Telefono
        private String _sis_telefo_sitr;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: sis_telefo_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Numeros de Telefono del tecrcero
        /// </para>
        /// </summary>
        public String Sis_telefo_sitr
        {
            get { return _sis_telefo_sitr; }
            set
            {
                if (_sis_telefo_sitr == value) return;
                _sis_telefo_sitr = value;
                OnPropertyChanged("Sis_telefo_sitr");
            }
        }
        #endregion
        #region Sis_direcc_sitr: Direccion
        private String _sis_direcc_sitr;
        /// <summary>
        /// <para>TABLA: teporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Direccion</para>
        /// <para>NOMBRE: sis_direcc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Direccion domicilio del tercero
        /// </para>
        /// </summary>
        public String Sis_direcc_sitr
        {
            get { return _sis_direcc_sitr; }
            set
            {
                if (_sis_direcc_sitr == value) return;
                _sis_direcc_sitr = value;
                OnPropertyChanged("Sis_direcc_sitr");
            }
        }
        #endregion
        // otros datos
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Nombre Completo del usuario digitador o facturador</para>
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
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloCuentaCobro tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-SECCUE-MAECUENTAS", "FCM", "Secuencial Unico cuentas de cobro");
            try
            {
                if (!flgBuscarFcmcuentacobrms(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmcuentacobrms
                        {
                            #region cargar Registro
                            fcm_secreg_mfcb = tobjModelo.Fcm_secreg_mfcb,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            fcm_tipfac_mfcb = tobjModelo.Fcm_tipfac_mfcb,
                            fcm_fecfac_mfac = tobjModelo.Fcm_fecfac_mfac,
                            sia_fecini_mfcb = tobjModelo.Sia_fecini_mfcb,
                            sia_fecfin_mfcb = tobjModelo.Sia_fecfin_mfcb,
                            fcm_descue_mfcb = tobjModelo.Fcm_descue_mfcb,
                            fcm_notcue_mfcb = tobjModelo.Fcm_notcue_mfcb,
                            fcm_firmar_mfcb = tobjModelo.Fcm_firmar_mfcb,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_poriva_dfac = tobjModelo.Fcm_poriva_dfac,
                            fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac,
                            fcm_valcpa_dfac = tobjModelo.Fcm_valcpa_dfac,
                            fcm_valcmo_dfac = tobjModelo.Fcm_valcmo_dfac,
                            fcm_valusu_dfac = tobjModelo.Fcm_valusu_dfac,
                            fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            fcm_conest_mfcb = tobjModelo.Fcm_conest_mfcb,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.fcm_secreg_mfcb = lcrCodigoGen;
                        _context.AddToFcmcuentacobrms(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-SECCUE-MAECUENTAS': Secuencial Unico cuentas de cobro en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloCuentaCobro tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tobjModelo.Fcm_secreg_mfcb);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.fcm_secreg_mfcb = tobjModelo.Fcm_secreg_mfcb;
                        lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.fcm_tipfac_mfcb = tobjModelo.Fcm_tipfac_mfcb;
                        lobjRegistro.fcm_fecfac_mfac = (DateTime)tobjModelo.Fcm_fecfac_mfac;
                        lobjRegistro.sia_fecini_mfcb = (DateTime)tobjModelo.Sia_fecini_mfcb;
                        lobjRegistro.sia_fecfin_mfcb = (DateTime)tobjModelo.Sia_fecfin_mfcb;
                        lobjRegistro.fcm_descue_mfcb = tobjModelo.Fcm_descue_mfcb;
                        lobjRegistro.fcm_notcue_mfcb = tobjModelo.Fcm_notcue_mfcb;
                        lobjRegistro.fcm_firmar_mfcb = tobjModelo.Fcm_firmar_mfcb;
                        lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                        lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.fcm_valbru_dfac = (float)tobjModelo.Fcm_valbru_dfac;
                        lobjRegistro.fcm_pordes_dfac = (float)tobjModelo.Fcm_pordes_dfac;
                        lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                        lobjRegistro.fcm_poriva_dfac = (float)tobjModelo.Fcm_poriva_dfac;
                        lobjRegistro.fcm_valiva_dfac = (float)tobjModelo.Fcm_valiva_dfac;
                        lobjRegistro.fcm_valcpa_dfac = (float)tobjModelo.Fcm_valcpa_dfac;
                        lobjRegistro.fcm_valcmo_dfac = (float)tobjModelo.Fcm_valcmo_dfac;
                        lobjRegistro.fcm_valusu_dfac = (float)tobjModelo.Fcm_valusu_dfac;
                        lobjRegistro.fcm_valsub_dfac = (float)tobjModelo.Fcm_valsub_dfac;
                        lobjRegistro.fcm_valfac_dfac = (float)tobjModelo.Fcm_valfac_dfac;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.fcm_conest_mfcb = (int)tobjModelo.Fcm_conest_mfcb;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tcrCodigo);
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
        #region Buscar FCMCUENTACOBRMS: Logica
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TITULO: Maestro de facturas - Cuentas de cobro facturación</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para realizar la clasificacion de facturas para cuentras
        /// de cobro a las EPS
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmcuentacobrms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcuentacobrms.FirstOrDefault(p => p.fcm_secreg_mfcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCuentaCobro> flsListaFcmcuentacobrms(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    #region Listar
                    var lobConsulta = from fcmcuentacobrms in _context.Fcmcuentacobrms
                                      join ctomaescontrato in _context.Ctomaescontrato on fcmcuentacobrms.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in _context.Siatablaeps on fcmcuentacobrms.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join fcmsecrfacturas in _context.Fcmsecrfacturas on fcmcuentacobrms.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join sismaesterceros in _context.Sismaesterceros on fcmcuentacobrms.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      select new ModeloCuentaCobro
                                      {
                                          Fcm_secreg_mfcb = fcmcuentacobrms.fcm_secreg_mfcb,
                                          Fcm_numfac_mfac = fcmcuentacobrms.fcm_numfac_mfac,
                                          Fcm_secres_srfa = fcmcuentacobrms.fcm_secres_srfa,
                                          Fcm_numres_srfa = srfa.fcm_numres_srfa,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Fcm_notenc_srfa = srfa.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = srfa.fcm_noppag_srfa,
                                          Fcm_tipfac_mfcb = fcmcuentacobrms.fcm_tipfac_mfcb,
                                          Fcm_fecfac_mfac = (DateTime)fcmcuentacobrms.fcm_fecfac_mfac,
                                          Sia_fecini_mfcb = (DateTime)fcmcuentacobrms.sia_fecini_mfcb,
                                          Sia_fecfin_mfcb = (DateTime)fcmcuentacobrms.sia_fecfin_mfcb,
                                          Fcm_descue_mfcb = fcmcuentacobrms.fcm_descue_mfcb,
                                          Fcm_notcue_mfcb = fcmcuentacobrms.fcm_notcue_mfcb,
                                          Fcm_firmar_mfcb = fcmcuentacobrms.fcm_firmar_mfcb,
                                          Cto_seccon_cont = fcmcuentacobrms.cto_seccon_cont,
                                          Cto_nrocon_cont = fcmcuentacobrms.cto_nrocon_cont,
                                          Sia_codeps_teps = fcmcuentacobrms.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmcuentacobrms.sis_idterc_sitr,
                                          Fcm_valbru_dfac = (float)fcmcuentacobrms.fcm_valbru_dfac,
                                          Fcm_pordes_dfac = (float)fcmcuentacobrms.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (float)fcmcuentacobrms.fcm_valdes_dfac,
                                          Fcm_poriva_dfac = (float)fcmcuentacobrms.fcm_poriva_dfac,
                                          Fcm_valiva_dfac = (float)fcmcuentacobrms.fcm_valiva_dfac,
                                          Fcm_valcpa_dfac = (float)fcmcuentacobrms.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (float)fcmcuentacobrms.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (float)fcmcuentacobrms.fcm_valusu_dfac,
                                          Fcm_valsub_dfac = (float)fcmcuentacobrms.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (float)fcmcuentacobrms.fcm_valfac_dfac,
                                          Sys_codusu_usux = fcmcuentacobrms.sys_codusu_usux,
                                          Fcm_conest_mfcb = (int)fcmcuentacobrms.fcm_conest_mfcb,
                                          Sis_estpro_espr = fcmcuentacobrms.sis_estpro_espr,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sia_codnit_teps = teps.sia_codnit_teps,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sis_tipide_tido = sitr.sis_tipide_tido,
                                          Sis_numide_sitr = sitr.sis_numide_sitr,
                                          Sis_telefo_sitr = sitr.sis_telefo_sitr,
                                          Sis_direcc_sitr = sitr.sis_direcc_sitr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region Listar
                    var lobConsulta = from fcmcuentacobrms in _context.Fcmcuentacobrms
                                      join ctomaescontrato in _context.Ctomaescontrato on fcmcuentacobrms.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in _context.Siatablaeps on fcmcuentacobrms.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join fcmsecrfacturas in _context.Fcmsecrfacturas on fcmcuentacobrms.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join sismaesterceros in _context.Sismaesterceros on fcmcuentacobrms.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      where fcmcuentacobrms.fcm_secreg_mfcb.Contains(tcrBuscar) || fcmcuentacobrms.fcm_descue_mfcb.Contains(tcrBuscar)
                                      select new ModeloCuentaCobro
                                      {
                                          Fcm_secreg_mfcb = fcmcuentacobrms.fcm_secreg_mfcb,
                                          Fcm_numfac_mfac = fcmcuentacobrms.fcm_numfac_mfac,
                                          Fcm_secres_srfa = fcmcuentacobrms.fcm_secres_srfa,
                                          Fcm_numres_srfa = srfa.fcm_numres_srfa,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Fcm_notenc_srfa = srfa.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = srfa.fcm_noppag_srfa,
                                          Fcm_tipfac_mfcb = fcmcuentacobrms.fcm_tipfac_mfcb,
                                          Fcm_fecfac_mfac = (DateTime)fcmcuentacobrms.fcm_fecfac_mfac,
                                          Sia_fecini_mfcb = (DateTime)fcmcuentacobrms.sia_fecini_mfcb,
                                          Sia_fecfin_mfcb = (DateTime)fcmcuentacobrms.sia_fecfin_mfcb,
                                          Fcm_descue_mfcb = fcmcuentacobrms.fcm_descue_mfcb,
                                          Fcm_notcue_mfcb = fcmcuentacobrms.fcm_notcue_mfcb,
                                          Fcm_firmar_mfcb = fcmcuentacobrms.fcm_firmar_mfcb,
                                          Cto_seccon_cont = fcmcuentacobrms.cto_seccon_cont,
                                          Cto_nrocon_cont = fcmcuentacobrms.cto_nrocon_cont,
                                          Sia_codeps_teps = fcmcuentacobrms.sia_codeps_teps,
                                          Sis_idterc_sitr = fcmcuentacobrms.sis_idterc_sitr,
                                          Fcm_valbru_dfac = (float)fcmcuentacobrms.fcm_valbru_dfac,
                                          Fcm_pordes_dfac = (float)fcmcuentacobrms.fcm_pordes_dfac,
                                          Fcm_valdes_dfac = (float)fcmcuentacobrms.fcm_valdes_dfac,
                                          Fcm_poriva_dfac = (float)fcmcuentacobrms.fcm_poriva_dfac,
                                          Fcm_valiva_dfac = (float)fcmcuentacobrms.fcm_valiva_dfac,
                                          Fcm_valcpa_dfac = (float)fcmcuentacobrms.fcm_valcpa_dfac,
                                          Fcm_valcmo_dfac = (float)fcmcuentacobrms.fcm_valcmo_dfac,
                                          Fcm_valusu_dfac = (float)fcmcuentacobrms.fcm_valusu_dfac,
                                          Fcm_valsub_dfac = (float)fcmcuentacobrms.fcm_valsub_dfac,
                                          Fcm_valfac_dfac = (float)fcmcuentacobrms.fcm_valfac_dfac,
                                          Sys_codusu_usux = fcmcuentacobrms.sys_codusu_usux,
                                          Fcm_conest_mfcb = (int)fcmcuentacobrms.fcm_conest_mfcb,
                                          Sis_estpro_espr = fcmcuentacobrms.sis_estpro_espr,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sia_codnit_teps = teps.sia_codnit_teps,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sis_tipide_tido = sitr.sis_tipide_tido,
                                          Sis_numide_sitr = sitr.sis_numide_sitr,
                                          Sis_telefo_sitr = sitr.sis_telefo_sitr,
                                          Sis_direcc_sitr = sitr.sis_direcc_sitr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmcuentacobrde
    /// </summary>
    public class ModeloDetallfacturas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente (temporal)
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
        #region Fcm_secreg_mfcd: Código unico registro
        private String _fcm_secreg_mfcd;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmcuentacobrde</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: fcm_secreg_mfcd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico detalles facturas en cuenta de cobro (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfcd
        {
            get { return _fcm_secreg_mfcd; }
            set
            {
                if (_fcm_secreg_mfcd == value) return;
                _fcm_secreg_mfcd = value;
                OnPropertyChanged("Fcm_secreg_mfcd");
            }
        }
        #endregion
        #region Fcm_secreg_mfcb: Código cuenta cobro
        private String _fcm_secreg_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Código cuenta cobro</para>
        /// <para>NOMBRE: fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Secuencial unico de la cuenta de cobro relacion R1
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfcb
        {
            get { return _fcm_secreg_mfcb; }
            set
            {
                if (_fcm_secreg_mfcb == value) return;
                _fcm_secreg_mfcb = value;
                OnPropertyChanged("Fcm_secreg_mfcb");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo unico de paciente en el sistema
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
        #region Fcm_numfac_mfac: Numero Factura
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de factura (desde maestro de facturas) relacionado como
        /// detalles de cuentra de cobro
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la cuenta de cobro: 1=Abierta
        /// 2=Confirmada 3=Anulada
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
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
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  ejm: CC= Cedula,
        /// RC= Registro Civil, TI = Tarjeta de Identidad  AS= Adulto sin
        /// identificación y otros
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
        #region Sia_nroide_usua: Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
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
        #region Sia_priape_usua: Primer Apellido
        private String _sia_priape_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Apellido</para>
        /// <para>NOMBRE: sia_priape_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_priape_usua
        {
            get { return _sia_priape_usua; }
            set
            {
                if (_sia_priape_usua == value) return;
                _sia_priape_usua = value;
                OnPropertyChanged("Sia_priape_usua");
            }
        }
        #endregion
        #region Sia_segape_usua: Segundo Apellido
        private String _sia_segape_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Apellido</para>
        /// <para>NOMBRE: sia_segape_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Segundo apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segape_usua
        {
            get { return _sia_segape_usua; }
            set
            {
                if (_sia_segape_usua == value) return;
                _sia_segape_usua = value;
                OnPropertyChanged("Sia_segape_usua");
            }
        }
        #endregion
        #region Sia_prinom_usua: Primer Nombre
        private String _sia_prinom_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Nombre</para>
        /// <para>NOMBRE: sia_prinom_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_prinom_usua
        {
            get { return _sia_prinom_usua; }
            set
            {
                if (_sia_prinom_usua == value) return;
                _sia_prinom_usua = value;
                OnPropertyChanged("Sia_prinom_usua");
            }
        }
        #endregion
        #region Sia_segnom_usua: Segundo Nombre
        private String _sia_segnom_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Nombre</para>
        /// <para>NOMBRE: sia_segnom_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Segundo nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segnom_usua
        {
            get { return _sia_segnom_usua; }
            set
            {
                if (_sia_segnom_usua == value) return;
                _sia_segnom_usua = value;
                OnPropertyChanged("Sia_segnom_usua");
            }
        }
        #endregion
        #region Sia_fecnac_usua: Fecha nacimiento
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha nacimiento del usuario o paciente
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
        #region Sis_codsex_sexo: Codigo tipo sexo
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Codigo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo Sexo Generado por el sistema
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
        #region Fcm_fecfac_mfac: Fecha factura
        private DateTime _fcm_fecfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Fcm_valbru_dfac: Valor bruto factura
        private float _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valbru_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private float _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_poriva_dfac: Porcentaje del IVA
        private float _fcm_poriva_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float Fcm_poriva_dfac
        {
            get { return _fcm_poriva_dfac; }
            set
            {
                if (_fcm_poriva_dfac == value) return;
                _fcm_poriva_dfac = value;
                OnPropertyChanged("Fcm_poriva_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        private float _fcm_valiva_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float Fcm_valiva_dfac
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
        #region Fcm_valcpa_dfac: Valor copago
        private float _fcm_valcpa_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float Fcm_valcpa_dfac
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
        private float _fcm_valcmo_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float Fcm_valcmo_dfac
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
        private float _fcm_valusu_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float Fcm_valusu_dfac
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
        #region Fcm_valsub_dfac: Valor subtotal servicio
        private float _fcm_valsub_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float Fcm_valsub_dfac
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
        private float _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valfac_dfac
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloDetallfacturas tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmcuentacobrde();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmcuentacobrde.FirstOrDefault(p => p.fcm_secreg_mfcd == tobTempReg.Fcm_secreg_mfcd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.fcm_secreg_mfcd = tobTempReg.Fcm_secreg_mfcd;
                            lobEFReg.fcm_secreg_mfcb = tobTempReg.Fcm_secreg_mfcb;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.fcm_numfac_mfac = tobTempReg.Fcm_numfac_mfac;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
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
                                lobEFReg.fcm_secreg_mfcd = tcrCodigoR1 + lobEFReg.fcm_secreg_mfcd; // concatenar
                                _context.AddToFcmcuentacobrde(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmcuentacobrde.FirstOrDefault(p => p.fcm_secreg_mfcd == tobTempReg.Fcm_secreg_mfcd);
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
        #region Buscar FCMCUENTACOBRDE: Logica
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TITULO: Detalles facturas  en cuentas de cobro</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles facturas  relacionadas en cuentas de cobro facturación
        /// para cobro a EPS
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmcuentacobrde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmcuentacobrde.FirstOrDefault(p => p.fcm_secreg_mfcd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloDetallfacturas> flsListaFcmcuentacobrde(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmcuentacobrde in _context.Fcmcuentacobrde
                                  join usua in _context.Siausuarioatend on fcmcuentacobrde.sia_idesec_usua equals usua.sia_idesec_usua
                                  join mfac in _context.Fcmmaesfacturas on fcmcuentacobrde.fcm_numfac_mfac equals mfac.fcm_numfac_mfac 
                                  where fcmcuentacobrde.fcm_secreg_mfcb == tcrBuscar
                                  orderby fcmcuentacobrde.fcm_numfac_mfac
                                  select new ModeloDetallfacturas
                                  {
                                      Fcm_secreg_mfcd = fcmcuentacobrde.fcm_secreg_mfcd,
                                      Fcm_secreg_mfcb = fcmcuentacobrde.fcm_secreg_mfcb,
                                      Sia_idesec_usua = fcmcuentacobrde.sia_idesec_usua,
                                      Fcm_numfac_mfac = fcmcuentacobrde.fcm_numfac_mfac,
                                      Sis_estpro_espr = fcmcuentacobrde.sis_estpro_espr,
                                      Fcm_fecfac_mfac = (DateTime)mfac.fcm_fecfac_mfac,
                                      Adm_secadm_rgad = mfac.adm_secadm_rgad,
                                      Fcm_valbru_dfac = (float)mfac.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)mfac.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)mfac.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)mfac.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)mfac.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)mfac.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)mfac.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)mfac.fcm_valusu_dfac,
                                      Fcm_valsub_dfac = (float)mfac.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)mfac.fcm_valfac_dfac,
                                      Sia_tipide_tide = usua.sia_tipide_tide,
                                      Sia_nroide_usua = usua.sia_nroide_usua,
                                      Sia_priape_usua = usua.sia_priape_usua,
                                      Sia_segape_usua = usua.sia_segape_usua,
                                      Sia_prinom_usua = usua.sia_prinom_usua,
                                      Sia_segnom_usua = usua.sia_segnom_usua,
                                      Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                      Sis_codsex_sexo = usua.sis_codsex_sexo,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
                /*
                var lobConsulta = from fcmcuentacobrde in _context.Fcmcuentacobrde
                                  join siausuarioatend in _context.Siausuarioatend on fcmcuentacobrde.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join fcmmaesfacturas in _context.Fcmmaesfacturas on fcmcuentacobrde.fcm_numfac_mfac equals fcmmaesfacturas.fcm_numfac_mfac into tmfcmmaesfacturas
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from mfac in tmfcmmaesfacturas.DefaultIfEmpty()
                                  where fcmcuentacobrde.fcm_secreg_mfcb == tcrBuscar
                                  select new ModeloDetallfacturas
                                  {
                                      Fcm_secreg_mfcd = fcmcuentacobrde.fcm_secreg_mfcd,
                                      Fcm_secreg_mfcb = fcmcuentacobrde.fcm_secreg_mfcb,
                                      Sia_idesec_usua = fcmcuentacobrde.sia_idesec_usua,
                                      Fcm_numfac_mfac = fcmcuentacobrde.fcm_numfac_mfac,
                                      Sis_estpro_espr = fcmcuentacobrde.sis_estpro_espr,
                                      Fcm_fecfac_mfac = (DateTime)mfac.fcm_fecfac_mfac,
                                      Adm_secadm_rgad = mfac.adm_secadm_rgad,
                                      Fcm_valbru_dfac = (float)mfac.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)mfac.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)mfac.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)mfac.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)mfac.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)mfac.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)mfac.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)mfac.fcm_valusu_dfac,
                                      Fcm_valsub_dfac = (float)mfac.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)mfac.fcm_valfac_dfac,
                                      Sia_tipide_tide = usua.sia_tipide_tide,
                                      Sia_nroide_usua = usua.sia_nroide_usua,
                                      Sia_priape_usua = usua.sia_priape_usua,
                                      Sia_segape_usua = usua.sia_segape_usua,
                                      Sia_prinom_usua = usua.sia_prinom_usua,
                                      Sia_segnom_usua = usua.sia_segnom_usua,
                                      Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                      Sis_codsex_sexo = usua.sis_codsex_sexo,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
                
                */
            }
        }
        #endregion
        #endregion
    }
    //--------------------------------------------------------
    // GESTION PAGOS EN EFECTIVO
    //--------------------------------------------------------
    #region Gestion Transacciones pago efectivo facturacion
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaescajatran
    /// </summary>
    public class FcmModeloTransacPagoEfectivo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_codtra_mtrc: Código recibo de caja
        private String _fcm_codtra_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codtra_mtrc
        {
            get { return _fcm_codtra_mtrc; }
            set
            {
                if (_fcm_codtra_mtrc == value) return;
                _fcm_codtra_mtrc = value;
                OnPropertyChanged("Fcm_codtra_mtrc");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago
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
        #region Fcm_numfac_mfac: Numero Factura
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada en la confirmación de facturas
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
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Sia_nroide_usua: Numero de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Fcm_autdes_ades: Autorización descuento
        private String _fcm_autdes_ades;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion del descuento aprobado para el momento
        /// del pago (cuando aplique)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_descon_mtrc: Concepto del pago
        private String _fcm_descon_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public String Fcm_descon_mtrc
        {
            get { return _fcm_descon_mtrc; }
            set
            {
                if (_fcm_descon_mtrc == value) return;
                _fcm_descon_mtrc = value;
                OnPropertyChanged("Fcm_descon_mtrc");
            }
        }
        #endregion
        #region Fcm_rfecha_mtrc: Fecha del recibo
        private DateTime _fcm_rfecha_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Fecha del recibo</para>
        /// <para>NOMBRE: fcm_rfecha_mtrc (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha del recibo de caja
        /// </para>
        /// </summary>
        public DateTime Fcm_rfecha_mtrc
        {
            get { return _fcm_rfecha_mtrc; }
            set
            {
                if (_fcm_rfecha_mtrc == value) return;
                _fcm_rfecha_mtrc = value;
                OnPropertyChanged("Fcm_rfecha_mtrc");
            }
        }
        #endregion
        #region Fcm_rehora_mtrc: Hora del recibo
        private Decimal _fcm_rehora_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Hora del recibo</para>
        /// <para>NOMBRE: fcm_rehora_mtrc (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora en que se genero el recibo, hora en formato 12 ejem: 10:25:AM
        /// </para>
        /// </summary>
        public Decimal Fcm_rehora_mtrc
        {
            get { return _fcm_rehora_mtrc; }
            set
            {
                if (_fcm_rehora_mtrc == value) return;
                _fcm_rehora_mtrc = value;
                OnPropertyChanged("Fcm_rehora_mtrc");
            }
        }
        #endregion
        #region Fcm_tipefe_mtrc: Tipo de pago efectivo
        private String _fcm_tipefe_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Tipo de pago efectivo</para>
        /// <para>NOMBRE: fcm_tipefe_mtrc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo de efectivo utlizado par el pago: EFECTIVO, TARJETA,CHEQUE,EFECTIVO-
        /// Y-TARJETA,EFECTIVO-Y-CHEQUE,CHEQUE-Y-TARJETA
        /// </para>
        /// </summary>
        public String Fcm_tipefe_mtrc
        {
            get { return _fcm_tipefe_mtrc; }
            set
            {
                if (_fcm_tipefe_mtrc == value) return;
                _fcm_tipefe_mtrc = value;
                OnPropertyChanged("Fcm_tipefe_mtrc");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor en efectivo
        private float _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor a recaudar en efectivo sin el descuento (solo valor cobrado
        /// en efectivo) por cobros de copagos o valor total del servicio
        /// (no siempre representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
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
        #region Fcm_valdes_dfac: Valor del descuento
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento realizado al cliente cuando exista
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_valefe_mtrc: Valor billete Efectivo
        private int _fcm_valefe_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor billete Efectivo</para>
        /// <para>NOMBRE: fcm_valefe_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Efectivo (Billete) presentado en ventanilla por el cliente,
        /// de este se hara la deduccion del pago
        /// </para>
        /// </summary>
        public int Fcm_valefe_mtrc
        {
            get { return _fcm_valefe_mtrc; }
            set
            {
                if (_fcm_valefe_mtrc == value) return;
                _fcm_valefe_mtrc = value;
                OnPropertyChanged("Fcm_valefe_mtrc");
            }
        }
        #endregion
        #region Fcm_valcam_mtrc: Valor cambio efectivo
        private int _fcm_valcam_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor cambio efectivo</para>
        /// <para>NOMBRE: fcm_valcam_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor del cambio cuando despues de la transaccion se debe un
        /// valor cambio: FCM_VALCAM_MTRC=FCM_VALEFE_MTRC-FCM_VALPAG_MTRC
        /// </para>
        /// </summary>
        public int Fcm_valcam_mtrc
        {
            get { return _fcm_valcam_mtrc; }
            set
            {
                if (_fcm_valcam_mtrc == value) return;
                _fcm_valcam_mtrc = value;
                OnPropertyChanged("Fcm_valcam_mtrc");
            }
        }
        #endregion
        #region Fcm_valefe_dfac: Valor pago en efectivo
        private float _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente al servicio (con el
        /// descuento)
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region Fcm_secdet_mtrc: Secuencial reg Detalles
        private int _fcm_secdet_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: fcm_secdet_mtrc (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los registros detalles
        /// de la transaccion
        /// </para>
        /// </summary>
        public int Fcm_secdet_mtrc
        {
            get { return _fcm_secdet_mtrc; }
            set
            {
                if (_fcm_secdet_mtrc == value) return;
                _fcm_secdet_mtrc = value;
                OnPropertyChanged("Fcm_secdet_mtrc");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atencion o admision
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
        #region Sis_estreg_mtrc: Estado del recibo
        private String _sis_estreg_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: sis_estreg_mtrc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado  del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estreg_mtrc
        {
            get { return _sis_estreg_mtrc; }
            set
            {
                if (_sis_estreg_mtrc == value) return;
                _sis_estreg_mtrc = value;
                OnPropertyChanged("Sis_estreg_mtrc");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #region Fcm_notaut_ades: Nota
        private String _fcm_notaut_ades;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Nota</para>
        /// <para>NOMBRE: fcm_notaut_ades (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota textual de la autorización
        /// </para>
        /// </summary>
        public String Fcm_notaut_ades
        {
            get { return _fcm_notaut_ades; }
            set
            {
                if (_fcm_notaut_ades == value) return;
                _fcm_notaut_ades = value;
                OnPropertyChanged("Fcm_notaut_ades");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(FcmModeloTransacPagoEfectivo tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-CAJA-PAGOS-SERV", "FCM", "Transaccion Caja pagos efectivo facturación");
            if (!flgBuscarFcmmaescajatran(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmmaescajatran
                    {
                        #region cargar Registro
                        fcm_codtra_mtrc = tobjModelo.Fcm_codtra_mtrc,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        fcm_autdes_ades = tobjModelo.Fcm_autdes_ades,
                        fcm_descon_mtrc = tobjModelo.Fcm_descon_mtrc,
                        fcm_rfecha_mtrc = tobjModelo.Fcm_rfecha_mtrc,
                        fcm_rehora_mtrc = tobjModelo.Fcm_rehora_mtrc,
                        fcm_tipefe_mtrc = tobjModelo.Fcm_tipefe_mtrc,
                        fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                        fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                        fcm_valefe_mtrc = tobjModelo.Fcm_valefe_mtrc,
                        fcm_valcam_mtrc = tobjModelo.Fcm_valcam_mtrc,
                        fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        fcm_secdet_mtrc = tobjModelo.Fcm_secdet_mtrc,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        sis_estreg_mtrc = tobjModelo.Sis_estreg_mtrc,
                        #endregion
                    };
                    lobjRegistro.fcm_codtra_mtrc = lcrCodigoGen;
                    _context.AddToFcmmaescajatran(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-CAJA-PAGOS-SERV': Transaccion Caja pagos efectivo facturación en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(FcmModeloTransacPagoEfectivo tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tobjModelo.Fcm_codtra_mtrc);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_codtra_mtrc = tobjModelo.Fcm_codtra_mtrc;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                    lobjRegistro.fcm_descon_mtrc = tobjModelo.Fcm_descon_mtrc;
                    lobjRegistro.fcm_rfecha_mtrc = (DateTime)tobjModelo.Fcm_rfecha_mtrc;
                    lobjRegistro.fcm_rehora_mtrc = (Decimal)tobjModelo.Fcm_rehora_mtrc;
                    lobjRegistro.fcm_tipefe_mtrc = tobjModelo.Fcm_tipefe_mtrc;
                    lobjRegistro.fcm_valref_dfac = (float)tobjModelo.Fcm_valref_dfac;
                    lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                    lobjRegistro.fcm_valefe_mtrc = (int)tobjModelo.Fcm_valefe_mtrc;
                    lobjRegistro.fcm_valcam_mtrc = (int)tobjModelo.Fcm_valcam_mtrc;
                    lobjRegistro.fcm_valefe_dfac = (int)tobjModelo.Fcm_valefe_dfac;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.fcm_secdet_mtrc = (int)tobjModelo.Fcm_secdet_mtrc;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.sis_estreg_mtrc = tobjModelo.Sis_estreg_mtrc;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Actualizar transaccion
        /// <summary>
        ///  <para>Actualizar: Estado , Id  de la admision y Facturas en detalles transaccion</para>
        /// </summary>
        public static void fcvActualizarRegistros(String tcrIdReciboCaja, String tcrIdAdmision, String tcrEstadoRegistro, List<SelectFacturasMaestro> tlsSelectFacturas)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrIdReciboCaja);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sis_estreg_mtrc = !String.IsNullOrWhiteSpace(tcrEstadoRegistro) ? tcrEstadoRegistro : lobjRegistro.sis_estreg_mtrc;
                    lobjRegistro.adm_secadm_rgad = !String.IsNullOrWhiteSpace(tcrIdAdmision) ? tcrIdAdmision : lobjRegistro.adm_secadm_rgad;
                    _context.SaveChanges();
                }
            }
            if (tlsSelectFacturas != null)
            {
                using (_context = new DbAplicacion())
                {
                    var tmpDetalles = (from tmp in _context.Fcmmaescajadeta where tmp.fcm_codtra_mtrc == tcrIdReciboCaja select tmp).ToList();

                    if (tmpDetalles != null)
                    {
                        foreach (var lobReg in tmpDetalles)
                        {
                            // buscar por el ID temporal  ejm:(XXTCN008) 
                            var lobRegFac = tlsSelectFacturas.FirstOrDefault(p => p.Sis_auxiliar_datos == lobReg.fcm_secreg_mfac);
                            if (lobRegFac != null)
                            {
                                lobReg.fcm_secreg_mfac = lobRegFac.Fcm_secreg_mfac;
                                lobReg.fcm_numfac_mfac = lobRegFac.Fcm_numfac_mfac;
                            }
                        }
                        _context.SaveChanges();
                    }
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMAESCAJATRAN: Logica
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TITULO: Maestro Transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los datos de recibos de cajas que se
        /// generen en facturacion por concepto de pagos en efectivo o
        /// en cheque de: copagos, cuotas moderadoras, pagos particulares
        /// y otros pagos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaescajatran(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<FcmModeloTransacPagoEfectivo> flsListaFcmmaescajatran(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmmaescajatran in _context.Fcmmaescajatran
                                      join admregadmision in _context.Admregadmision on fcmmaescajatran.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmmaescajatran.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join fcmdescueautori in _context.Fcmdescueautori on fcmmaescajatran.fcm_autdes_ades equals fcmdescueautori.fcm_autdes_ades into tmfcmdescueautori
                                      join siacentroaten in _context.Siacentroaten on fcmmaescajatran.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join sysusuarios in _context.Sysusuarios on fcmmaescajatran.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from ades in tmfcmdescueautori.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      select new FcmModeloTransacPagoEfectivo
                                      {
                                          Fcm_codtra_mtrc = fcmmaescajatran.fcm_codtra_mtrc,
                                          Adm_secadm_rgad = fcmmaescajatran.adm_secadm_rgad,
                                          Fcm_numfac_mfac = fcmmaescajatran.fcm_numfac_mfac,
                                          Sia_idesec_usua = fcmmaescajatran.sia_idesec_usua,
                                          Sia_nroide_usua = fcmmaescajatran.sia_nroide_usua,
                                          Fcm_autdes_ades = fcmmaescajatran.fcm_autdes_ades,
                                          Fcm_descon_mtrc = fcmmaescajatran.fcm_descon_mtrc,
                                          Fcm_rfecha_mtrc = (DateTime)fcmmaescajatran.fcm_rfecha_mtrc,
                                          Fcm_rehora_mtrc = (Decimal)fcmmaescajatran.fcm_rehora_mtrc,
                                          Fcm_tipefe_mtrc = fcmmaescajatran.fcm_tipefe_mtrc,
                                          Fcm_valref_dfac = (float)fcmmaescajatran.fcm_valref_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaescajatran.fcm_valdes_dfac,
                                          Fcm_valefe_mtrc = (int)fcmmaescajatran.fcm_valefe_mtrc,
                                          Fcm_valcam_mtrc = (int)fcmmaescajatran.fcm_valcam_mtrc,
                                          Fcm_valefe_dfac = (int)fcmmaescajatran.fcm_valefe_dfac,
                                          Sia_codcat_ceat = fcmmaescajatran.sia_codcat_ceat,
                                          Fcm_secdet_mtrc = (int)fcmmaescajatran.fcm_secdet_mtrc,
                                          Sys_codusu_usux = fcmmaescajatran.sys_codusu_usux,
                                          Sis_estreg_mtrc = fcmmaescajatran.sis_estreg_mtrc,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Fcm_notaut_ades = ades.fcm_notaut_ades,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmmaescajatran in _context.Fcmmaescajatran
                                      join admregadmision in _context.Admregadmision on fcmmaescajatran.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmmaescajatran.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join fcmdescueautori in _context.Fcmdescueautori on fcmmaescajatran.fcm_autdes_ades equals fcmdescueautori.fcm_autdes_ades into tmfcmdescueautori
                                      join siacentroaten in _context.Siacentroaten on fcmmaescajatran.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join sysusuarios in _context.Sysusuarios on fcmmaescajatran.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from ades in tmfcmdescueautori.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      where fcmmaescajatran.fcm_codtra_mtrc.Contains(tcrBuscar) || fcmmaescajatran.fcm_descon_mtrc.Contains(tcrBuscar)
                                      select new FcmModeloTransacPagoEfectivo
                                      {
                                          Fcm_codtra_mtrc = fcmmaescajatran.fcm_codtra_mtrc,
                                          Adm_secadm_rgad = fcmmaescajatran.adm_secadm_rgad,
                                          Fcm_numfac_mfac = fcmmaescajatran.fcm_numfac_mfac,
                                          Sia_idesec_usua = fcmmaescajatran.sia_idesec_usua,
                                          Sia_nroide_usua = fcmmaescajatran.sia_nroide_usua,
                                          Fcm_autdes_ades = fcmmaescajatran.fcm_autdes_ades,
                                          Fcm_descon_mtrc = fcmmaescajatran.fcm_descon_mtrc,
                                          Fcm_rfecha_mtrc = (DateTime)fcmmaescajatran.fcm_rfecha_mtrc,
                                          Fcm_rehora_mtrc = (Decimal)fcmmaescajatran.fcm_rehora_mtrc,
                                          Fcm_tipefe_mtrc = fcmmaescajatran.fcm_tipefe_mtrc,
                                          Fcm_valref_dfac = (float)fcmmaescajatran.fcm_valref_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaescajatran.fcm_valdes_dfac,
                                          Fcm_valefe_mtrc = (int)fcmmaescajatran.fcm_valefe_mtrc,
                                          Fcm_valcam_mtrc = (int)fcmmaescajatran.fcm_valcam_mtrc,
                                          Fcm_valefe_dfac = (int)fcmmaescajatran.fcm_valefe_dfac,
                                          Sia_codcat_ceat = fcmmaescajatran.sia_codcat_ceat,
                                          Fcm_secdet_mtrc = (int)fcmmaescajatran.fcm_secdet_mtrc,
                                          Sys_codusu_usux = fcmmaescajatran.sys_codusu_usux,
                                          Sis_estreg_mtrc = fcmmaescajatran.sis_estreg_mtrc,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Fcm_notaut_ades = ades.fcm_notaut_ades,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Temporal de datos agrupados por codigo de admision
        public static List<FcmModeloTransacPagoEfectivo> flsListaFcmmaescajatranRpt(string tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaescajatran in _context.Fcmmaescajatran
                                  join admregadmision in _context.Admregadmision on fcmmaescajatran.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                  join siausuarioatend in _context.Siausuarioatend on fcmmaescajatran.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join fcmdescueautori in _context.Fcmdescueautori on fcmmaescajatran.fcm_autdes_ades equals fcmdescueautori.fcm_autdes_ades into tmfcmdescueautori
                                  join siacentroaten in _context.Siacentroaten on fcmmaescajatran.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                  join sysusuarios in _context.Sysusuarios on fcmmaescajatran.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                  from rgad in tmadmregadmision.DefaultIfEmpty()
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from ades in tmfcmdescueautori.DefaultIfEmpty()
                                  from ceat in tmsiacentroaten.DefaultIfEmpty()
                                  from usux in tmsysusuarios.DefaultIfEmpty()
                                  where fcmmaescajatran.adm_secadm_rgad == tcrCodigoAdmision
                                  select new FcmModeloTransacPagoEfectivo
                                  {
                                      Fcm_codtra_mtrc = fcmmaescajatran.fcm_codtra_mtrc,
                                      Adm_secadm_rgad = fcmmaescajatran.adm_secadm_rgad,
                                      Fcm_numfac_mfac = fcmmaescajatran.fcm_numfac_mfac,
                                      Sia_idesec_usua = fcmmaescajatran.sia_idesec_usua,
                                      Sia_nroide_usua = fcmmaescajatran.sia_nroide_usua,
                                      Fcm_autdes_ades = fcmmaescajatran.fcm_autdes_ades,
                                      Fcm_descon_mtrc = fcmmaescajatran.fcm_descon_mtrc,
                                      Fcm_rfecha_mtrc = (DateTime)fcmmaescajatran.fcm_rfecha_mtrc,
                                      Fcm_rehora_mtrc = (Decimal)fcmmaescajatran.fcm_rehora_mtrc,
                                      Fcm_tipefe_mtrc = fcmmaescajatran.fcm_tipefe_mtrc,
                                      Fcm_valref_dfac = (float)fcmmaescajatran.fcm_valref_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaescajatran.fcm_valdes_dfac,
                                      Fcm_valefe_mtrc = (int)fcmmaescajatran.fcm_valefe_mtrc,
                                      Fcm_valcam_mtrc = (int)fcmmaescajatran.fcm_valcam_mtrc,
                                      Fcm_valefe_dfac = (int)fcmmaescajatran.fcm_valefe_dfac,
                                      Sia_codcat_ceat = fcmmaescajatran.sia_codcat_ceat,
                                      Fcm_secdet_mtrc = (int)fcmmaescajatran.fcm_secdet_mtrc,
                                      Sys_codusu_usux = fcmmaescajatran.sys_codusu_usux,
                                      Sis_estreg_mtrc = fcmmaescajatran.sis_estreg_mtrc,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Fcm_notaut_ades = ades.fcm_notaut_ades,
                                      Sia_descat_ceat = ceat.sia_descat_ceat,
                                      Sys_nomusu_usux = usux.sys_nomusu_usux,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Gestion de detalles transaccion recibo de caja
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaescajadeta
    /// </summary>
    public class FcmModeloTransPagoDetalles : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _fcm_codrca_rcad;
        private String _fcm_codtra_mtrc;
        private String _fcm_secreg_mfac;
        private String _fcm_numfac_mfac;
        private String _fcm_desser_sips;
        private float _fcm_valref_dfac;
        private float _fcm_valefe_dfac;
        private float _fcm_pordes_dfac;
        private float _fcm_valdes_dfac;
        private int _fcm_valpag_mtrc;
        private String _fcm_tippag_rcad;
        private String _fcm_estreg_rcad;
        private String _fcm_descon_mtrc;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Fcm_codrca_rcad: Código único registro
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Código único registro</para>
        /// <para>NOMBRE: fcm_codrca_rcad (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codrca_rcad
        {
            get { return _fcm_codrca_rcad; }
            set
            {
                if (_fcm_codrca_rcad == value) return;
                _fcm_codrca_rcad = value;
                OnPropertyChanged("Fcm_codrca_rcad");
            }
        }
        #endregion
        #region Fcm_codtra_mtrc: Código recibo de caja
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codtra_mtrc
        {
            get { return _fcm_codtra_mtrc; }
            set
            {
                if (_fcm_codtra_mtrc == value) return;
                _fcm_codtra_mtrc = value;
                OnPropertyChanged("Fcm_codtra_mtrc");
            }
        }
        #endregion
        #region Fcm_secreg_mfac: Código orden medica
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
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
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago
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
        #region Fcm_numfac_mfac: Numero Factura
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada en la confirmación de facturas
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
        #region Fcm_desser_sips: Nombre servicios
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicios</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual de lso servicios IPS  que son cobrados
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
        #region Fcm_valref_dfac: Valor en efectivo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_valpag_mtrc: Valor pago en efectivo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: fcm_valpag_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente a la orden de  servicio
        /// </para>
        /// </summary>
        public int Fcm_valpag_mtrc
        {
            get { return _fcm_valpag_mtrc; }
            set
            {
                if (_fcm_valpag_mtrc == value) return;
                _fcm_valpag_mtrc = value;
                OnPropertyChanged("Fcm_valpag_mtrc");
            }
        }
        #endregion
        #region Fcm_tippag_rcad: Tipo pago realizado
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Tipo pago realizado</para>
        /// <para>NOMBRE: fcm_tippag_rcad (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo pago en efectivo textual asi: VALOR-SERVICIO,  COPAGO,
        /// CUOTA-MODERADORA, CARGO-USUARIO y OTROS
        /// </para>
        /// </summary>
        public String Fcm_tippag_rcad
        {
            get { return _fcm_tippag_rcad; }
            set
            {
                if (_fcm_tippag_rcad == value) return;
                _fcm_tippag_rcad = value;
                OnPropertyChanged("Fcm_tippag_rcad");
            }
        }
        #endregion
        #region Sis_idterc_sitr: Código tercero (contable)
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        #region Fcm_estreg_rcad: Estado del recibo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: fcm_estreg_rcad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Fcm_estreg_rcad
        {
            get { return _fcm_estreg_rcad; }
            set
            {
                if (_fcm_estreg_rcad == value) return;
                _fcm_estreg_rcad = value;
                OnPropertyChanged("Fcm_estreg_rcad");
            }
        }
        #endregion
        #region Fcm_descon_mtrc: Concepto del pago
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public String Fcm_descon_mtrc
        {
            get { return _fcm_descon_mtrc; }
            set
            {
                if (_fcm_descon_mtrc == value) return;
                _fcm_descon_mtrc = value;
                OnPropertyChanged("Fcm_descon_mtrc");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre / Razon social Tercero
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: con_razsoc_mter (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        public static bool flgAddRegistro(FcmModeloTransPagoDetalles tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmaescajadeta();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tobTempReg.Fcm_codrca_rcad);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.fcm_codrca_rcad = tobTempReg.Fcm_codrca_rcad;
                            lobEFReg.fcm_codtra_mtrc = tobTempReg.Fcm_codtra_mtrc;
                            lobEFReg.fcm_secreg_mfac = tobTempReg.Fcm_secreg_mfac;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.fcm_numfac_mfac = tobTempReg.Fcm_numfac_mfac;
                            lobEFReg.fcm_desser_sips = tobTempReg.Fcm_desser_sips;
                            lobEFReg.fcm_valref_dfac = (float)tobTempReg.Fcm_valref_dfac;
                            lobEFReg.fcm_pordes_dfac = (float)tobTempReg.Fcm_pordes_dfac;
                            lobEFReg.fcm_valdes_dfac = (float)tobTempReg.Fcm_valdes_dfac;
                            lobEFReg.fcm_valefe_dfac = (int)tobTempReg.Fcm_valefe_dfac;
                            lobEFReg.fcm_tippag_rcad = tobTempReg.Fcm_tippag_rcad;
                            lobEFReg.sis_idterc_sitr = tobTempReg.Sis_idterc_sitr;
                            lobEFReg.fcm_estreg_rcad = tobTempReg.Fcm_estreg_rcad;
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
                                lobEFReg.fcm_codrca_rcad = tcrCodigoR1 + lobEFReg.fcm_codrca_rcad; // concatenar
                                _context.AddToFcmmaescajadeta(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tobTempReg.Fcm_codrca_rcad);
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
        #region Buscar FCMMAESCAJADETA: Logica
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TITULO: Detalles transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los detalles de recibos de cajas, es
        /// decir, registros de cada de las facturas y /o ordenes de  servicios
        /// prestados que dieron lugar a cobro en efectivo
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaescajadeta(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<FcmModeloTransPagoDetalles> flsListaFcmmaescajadeta(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaescajadeta in _context.Fcmmaescajadeta
                                  join admregadmision in _context.Admregadmision on fcmmaescajadeta.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                  join fcmmaescajatran in _context.Fcmmaescajatran on fcmmaescajadeta.fcm_codtra_mtrc equals fcmmaescajatran.fcm_codtra_mtrc into tmfcmmaescajatran
                                  join fcmmaesfacturas in _context.Fcmmaesfacturas on fcmmaescajadeta.fcm_secreg_mfac equals fcmmaesfacturas.fcm_secreg_mfac into tmfcmmaesfacturas
                                  join sismaesterceros in _context.Sismaesterceros on fcmmaescajadeta.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  from rgad in tmadmregadmision.DefaultIfEmpty()
                                  from mtrc in tmfcmmaescajatran.DefaultIfEmpty()
                                  from mfac in tmfcmmaesfacturas.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  where fcmmaescajadeta.fcm_codtra_mtrc == tcrBuscar
                                  select new FcmModeloTransPagoDetalles
                                  {
                                      Fcm_codrca_rcad = fcmmaescajadeta.fcm_codrca_rcad,
                                      Fcm_codtra_mtrc = fcmmaescajadeta.fcm_codtra_mtrc,
                                      Fcm_secreg_mfac = fcmmaescajadeta.fcm_secreg_mfac,
                                      Adm_secadm_rgad = fcmmaescajadeta.adm_secadm_rgad,
                                      Fcm_numfac_mfac = fcmmaescajadeta.fcm_numfac_mfac,
                                      Fcm_desser_sips = fcmmaescajadeta.fcm_desser_sips,
                                      Fcm_valref_dfac = (float)fcmmaescajadeta.fcm_valref_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaescajadeta.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaescajadeta.fcm_valdes_dfac,
                                      Fcm_valefe_dfac = (float)fcmmaescajadeta.fcm_valefe_dfac,
                                      Fcm_tippag_rcad = fcmmaescajadeta.fcm_tippag_rcad,
                                      Sis_idterc_sitr = fcmmaescajadeta.sis_idterc_sitr,
                                      Fcm_estreg_rcad = fcmmaescajadeta.fcm_estreg_rcad,
                                      Fcm_descon_mtrc = mtrc.fcm_descon_mtrc,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal de datos agrupados por codigo de admision
        public static List<FcmModeloTransPagoDetalles> flsListaFcmmaescajadetaRpt(string tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaescajadeta in _context.Fcmmaescajadeta
                                  join admregadmision in _context.Admregadmision on fcmmaescajadeta.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                  join fcmmaescajatran in _context.Fcmmaescajatran on fcmmaescajadeta.fcm_codtra_mtrc equals fcmmaescajatran.fcm_codtra_mtrc into tmfcmmaescajatran
                                  join fcmmaesfacturas in _context.Fcmmaesfacturas on fcmmaescajadeta.fcm_secreg_mfac equals fcmmaesfacturas.fcm_secreg_mfac into tmfcmmaesfacturas
                                  join sismaesterceros in _context.Sismaesterceros on fcmmaescajadeta.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  from rgad in tmadmregadmision.DefaultIfEmpty()
                                  from mtrc in tmfcmmaescajatran.DefaultIfEmpty()
                                  from mfac in tmfcmmaesfacturas.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  where fcmmaescajadeta.adm_secadm_rgad == tcrCodigoAdmision
                                  orderby fcmmaescajadeta.fcm_codtra_mtrc
                                  select new FcmModeloTransPagoDetalles
                                  {
                                      Fcm_codrca_rcad = fcmmaescajadeta.fcm_codrca_rcad,
                                      Fcm_codtra_mtrc = fcmmaescajadeta.fcm_codtra_mtrc,
                                      Fcm_secreg_mfac = fcmmaescajadeta.fcm_secreg_mfac,
                                      Adm_secadm_rgad = fcmmaescajadeta.adm_secadm_rgad,
                                      Fcm_numfac_mfac = fcmmaescajadeta.fcm_numfac_mfac,
                                      Fcm_desser_sips = fcmmaescajadeta.fcm_desser_sips,
                                      Fcm_valref_dfac = (float)fcmmaescajadeta.fcm_valref_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaescajadeta.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaescajadeta.fcm_valdes_dfac,
                                      Fcm_valefe_dfac = (float)fcmmaescajadeta.fcm_valefe_dfac,
                                      Fcm_tippag_rcad = fcmmaescajadeta.fcm_tippag_rcad,
                                      Sis_idterc_sitr = fcmmaescajadeta.sis_idterc_sitr,
                                      Fcm_estreg_rcad = fcmmaescajadeta.fcm_estreg_rcad,
                                      Fcm_descon_mtrc = mtrc.fcm_descon_mtrc,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
    //--------------------------------------------------------
    // AUTORIZAR DESCUENTOS
    //--------------------------------------------------------
    #region Gestion Transacciones pago efectivo facturacion
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmdescueautori
    /// </summary>
    public class ModeloAutorizarDescuento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_autdes_ades: Autorización descuento
        private String _fcm_autdes_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion  del descuento aprobado para el momento
        /// del pago (generado por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_ordvis_ades: Oden vizualizacion
        private int _fcm_ordvis_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Oden vizualizacion</para>
        /// <para>NOMBRE: fcm_ordvis_ades (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Orden visualización en browser: 1 =Solicitud abierta sin aprobar
        /// o negar 2=Confirmada o aprobada 3=Aplicada al usuario 4=Negada
        /// </para>
        /// </summary>
        public int Fcm_ordvis_ades
        {
            get { return _fcm_ordvis_ades; }
            set
            {
                if (_fcm_ordvis_ades == value) return;
                _fcm_ordvis_ades = value;
                OnPropertyChanged("Fcm_ordvis_ades");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago y solicita descuento
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
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Sia_nroide_usua: Numero de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Fcm_fecsol_ades: Fecha solicitud
        private DateTime _fcm_fecsol_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Fecha solicitud</para>
        /// <para>NOMBRE: fcm_fecsol_ades (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del descuento
        /// </para>
        /// </summary>
        public DateTime Fcm_fecsol_ades
        {
            get { return _fcm_fecsol_ades; }
            set
            {
                if (_fcm_fecsol_ades == value) return;
                _fcm_fecsol_ades = value;
                OnPropertyChanged("Fcm_fecsol_ades");
            }
        }
        #endregion
        #region Fcm_horsol_ades: Hora solicitud
        private Decimal _fcm_horsol_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Hora solicitud</para>
        /// <para>NOMBRE: fcm_horsol_ades (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del descuento en formato 12 horas ejm: 10:20:AM
        /// </para>
        /// </summary>
        public Decimal Fcm_horsol_ades
        {
            get { return _fcm_horsol_ades; }
            set
            {
                if (_fcm_horsol_ades == value) return;
                _fcm_horsol_ades = value;
                OnPropertyChanged("Fcm_horsol_ades");
            }
        }
        #endregion
        #region Fcm_fecaut_ades: Fecha autorización
        private DateTime _fcm_fecaut_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Fecha autorización</para>
        /// <para>NOMBRE: fcm_fecaut_ades (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha Autorizacion del descuento
        /// </para>
        /// </summary>
        public DateTime Fcm_fecaut_ades
        {
            get { return _fcm_fecaut_ades; }
            set
            {
                if (_fcm_fecaut_ades == value) return;
                _fcm_fecaut_ades = value;
                OnPropertyChanged("Fcm_fecaut_ades");
            }
        }
        #endregion
        #region Fcm_horaut_ades: Hora autorización
        private Decimal _fcm_horaut_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Hora autorización</para>
        /// <para>NOMBRE: fcm_horaut_ades (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora autorizacion descuento en formato 12 horas ejm: 10:20:AM
        /// </para>
        /// </summary>
        public Decimal Fcm_horaut_ades
        {
            get { return _fcm_horaut_ades; }
            set
            {
                if (_fcm_horaut_ades == value) return;
                _fcm_horaut_ades = value;
                OnPropertyChanged("Fcm_horaut_ades");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor a cobrar en efectivo
        private float _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor a cobrar en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor a cobrar en efectivo antes del descuento por cobros de
        /// copagos o valor total de la factura (no siempre representa
        /// el valor total facturado)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
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
        #region Fcm_valdes_ades: Valor descuento solicitado
        private float _fcm_valdes_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Valor descuento solicitado</para>
        /// <para>NOMBRE: fcm_valdes_ades (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento solicitado
        /// </para>
        /// </summary>
        public float Fcm_valdes_ades
        {
            get { return _fcm_valdes_ades; }
            set
            {
                if (_fcm_valdes_ades == value) return;
                _fcm_valdes_ades = value;
                OnPropertyChanged("Fcm_valdes_ades");
            }
        }
        #endregion
        #region Fcm_valdes_dfac: Valor del descuento
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento realizado al cliente  (valor autorizado)
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private float _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
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
        #region Fcm_valefe_dfac: Valor a pagar efectivo
        private float _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor a pagar efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo con el descuento realizado  por
        /// cobros de copagos o valor total de la factura (no siempre representa
        /// el valor total facturado)
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
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
        #region Fcm_notaut_ades: Nota
        private String _fcm_notaut_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Nota</para>
        /// <para>NOMBRE: fcm_notaut_ades (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Nota textual de la autorización
        /// </para>
        /// </summary>
        public String Fcm_notaut_ades
        {
            get { return _fcm_notaut_ades; }
            set
            {
                if (_fcm_notaut_ades == value) return;
                _fcm_notaut_ades = value;
                OnPropertyChanged("Fcm_notaut_ades");
            }
        }
        #endregion
        #region Desys_ususol_usux: Nombre Usuario
        private String _desys_ususol_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: desys_ususol_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_ususol_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Desys_ususol_usux
        {
            get { return _desys_ususol_usux; }
            set
            {
                if (_desys_ususol_usux == value) return;
                _desys_ususol_usux = value;
                OnPropertyChanged("Desys_ususol_usux");
            }
        }
        #endregion
        #region Sys_ususol_usux: Usuario Digitador
        private String _sys_ususol_usux;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario Digitador</para>
        /// <para>NOMBRE: sys_ususol_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código del facturador usuario del sistema que realiza la solicitud
        /// </para>
        /// </summary>
        public String Sys_ususol_usux
        {
            get { return _sys_ususol_usux; }
            set
            {
                if (_sys_ususol_usux == value) return;
                _sys_ususol_usux = value;
                OnPropertyChanged("Sys_ususol_usux");
            }
        }
        #endregion
        #region Sys_codusu_usux: Quien autoriza
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Quien autoriza</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código del usuario o adminstrativo que autoriza el descuento
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
        #region Fcm_aplcad_ades: Autorización aplicada
        private String _fcm_aplcad_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización aplicada</para>
        /// <para>NOMBRE: fcm_aplcad_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Autorizacion aplicada en descuento al paciente: 1=SI, 2=NO
        /// </para>
        /// </summary>
        public String Fcm_aplcad_ades
        {
            get { return _fcm_aplcad_ades; }
            set
            {
                if (_fcm_aplcad_ades == value) return;
                _fcm_aplcad_ades = value;
                OnPropertyChanged("Fcm_aplcad_ades");
            }
        }
        #endregion
        #region Fcm_estaut_ades: Estado Autorizacion
        private String _fcm_estaut_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Estado Autorizacion</para>
        /// <para>NOMBRE: fcm_estaut_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Estado de la autorizacion:  1=Abierta 2=Autorizada 3=Aplicada a descuento 4=Negada o anulada
        /// </para>
        /// </summary>
        public String Fcm_estaut_ades
        {
            get { return _fcm_estaut_ades; }
            set
            {
                if (_fcm_estaut_ades == value) return;
                _fcm_estaut_ades = value;
                OnPropertyChanged("Fcm_estaut_ades");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
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
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
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
        #region Sia_tipide_tide:
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_tipide_tide (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sia_edaymd_usua:
        private String _sia_edaymd_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
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
        #region Sia_tipusu_regi:
        private String _sia_tipusu_regi;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_tipusu_regi (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_tipusu_regi
        {
            get { return _sia_tipusu_regi; }
            set
            {
                if (_sia_tipusu_regi == value) return;
                _sia_tipusu_regi = value;
                OnPropertyChanged("Sia_tipusu_regi");
            }
        }
        #endregion
        #region Sia_priape_usua:
        private String _sia_priape_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_priape_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_priape_usua
        {
            get { return _sia_priape_usua; }
            set
            {
                if (_sia_priape_usua == value) return;
                _sia_priape_usua = value;
                OnPropertyChanged("Sia_priape_usua");
            }
        }
        #endregion
        #region Sia_segape_usua:
        private String _sia_segape_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_segape_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_segape_usua
        {
            get { return _sia_segape_usua; }
            set
            {
                if (_sia_segape_usua == value) return;
                _sia_segape_usua = value;
                OnPropertyChanged("Sia_segape_usua");
            }
        }
        #endregion
        #region Sia_prinom_usua:
        private String _sia_prinom_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_prinom_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_prinom_usua
        {
            get { return _sia_prinom_usua; }
            set
            {
                if (_sia_prinom_usua == value) return;
                _sia_prinom_usua = value;
                OnPropertyChanged("Sia_prinom_usua");
            }
        }
        #endregion
        #region Sia_segnom_usua:
        private String _sia_segnom_usua;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_segnom_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_segnom_usua
        {
            get { return _sia_segnom_usua; }
            set
            {
                if (_sia_segnom_usua == value) return;
                _sia_segnom_usua = value;
                OnPropertyChanged("Sia_segnom_usua");
            }
        }
        #endregion
        #region Sis_codsex_sexo:
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
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
        #region Sis_dessex_sexo: Sexo
        private String _sis_dessex_sexo;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_dessex_sexo (char:25)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion(Masculino,Femenino)
        /// </para>
        /// </summary>
        public String Sis_dessex_sexo
        {
            get { return _sis_dessex_sexo; }
            set
            {
                if (_sis_dessex_sexo == value) return;
                _sis_dessex_sexo = value;
                OnPropertyChanged("Sis_dessex_sexo");
            }
        }
        #endregion
        #region Sia_destip_regi: Descripción Regimen salud
        private String _sia_destip_regi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: Siaregimensalud</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Regimen salud
        /// </para>
        /// </summary>
        public String Sia_destip_regi
        {
            get { return _sia_destip_regi; }
            set
            {
                if (_sia_destip_regi == value) return;
                _sia_destip_regi = value;
                OnPropertyChanged("Sia_destip_regi");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloAutorizarDescuento tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-SECDES-AUTORIZA", "FCM", "Secuencial unico autorizacion descuento caja");
            if (!flgBuscarFcmdescueautori(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmdescueautori
                    {
                        #region cargar Registro
                        fcm_autdes_ades = tobjModelo.Fcm_autdes_ades,
                        fcm_ordvis_ades = tobjModelo.Fcm_ordvis_ades,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        fcm_fecsol_ades = tobjModelo.Fcm_fecsol_ades,
                        fcm_horsol_ades = tobjModelo.Fcm_horsol_ades,
                        fcm_fecaut_ades = tobjModelo.Fcm_fecaut_ades,
                        fcm_horaut_ades = tobjModelo.Fcm_horaut_ades,
                        fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                        fcm_valdes_ades = tobjModelo.Fcm_valdes_ades,
                        fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                        fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                        fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                        fcm_notaut_ades = tobjModelo.Fcm_notaut_ades,
                        sys_ususol_usux = tobjModelo.Sys_ususol_usux,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        fcm_aplcad_ades = tobjModelo.Fcm_aplcad_ades,
                        fcm_estaut_ades = tobjModelo.Fcm_estaut_ades,
                        #endregion
                    };
                    lobjRegistro.fcm_autdes_ades = lcrCodigoGen;
                    _context.AddToFcmdescueautori(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-SECDES-AUTORIZA': Secuencial unico autorizacion descuento caja en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloAutorizarDescuento tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tobjModelo.Fcm_autdes_ades);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                    lobjRegistro.fcm_ordvis_ades = (int)tobjModelo.Fcm_ordvis_ades;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.fcm_fecsol_ades = (DateTime)tobjModelo.Fcm_fecsol_ades;
                    lobjRegistro.fcm_horsol_ades = (Decimal)tobjModelo.Fcm_horsol_ades;
                    lobjRegistro.fcm_fecaut_ades = (DateTime)tobjModelo.Fcm_fecaut_ades;
                    lobjRegistro.fcm_horaut_ades = (Decimal)tobjModelo.Fcm_horaut_ades;
                    lobjRegistro.fcm_valref_dfac = (float)tobjModelo.Fcm_valref_dfac;
                    lobjRegistro.fcm_valdes_ades = (float)tobjModelo.Fcm_valdes_ades;
                    lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                    lobjRegistro.fcm_pordes_dfac = (float)tobjModelo.Fcm_pordes_dfac;
                    lobjRegistro.fcm_valefe_dfac = (float)tobjModelo.Fcm_valefe_dfac;
                    lobjRegistro.fcm_notaut_ades = tobjModelo.Fcm_notaut_ades;
                    lobjRegistro.sys_ususol_usux = tobjModelo.Sys_ususol_usux;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.fcm_aplcad_ades = tobjModelo.Fcm_aplcad_ades;
                    lobjRegistro.fcm_estaut_ades = tobjModelo.Fcm_estaut_ades;
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
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMDESCUEAUTORI: Logica
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TITULO: Maestro para registrar los descuentos solicitados y  autoriz</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar los descuentos solicitados y  autorizados
        /// en pagos de servicios, copagos y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmdescueautori(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmdescueautori.FirstOrDefault(p => p.fcm_autdes_ades == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloAutorizarDescuento> flsListaFcmdescueautori(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmdescueautori in _context.Fcmdescueautori
                                      join admregadmision in _context.Admregadmision on fcmdescueautori.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmdescueautori.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join sysusuarios in _context.Sysusuarios on fcmdescueautori.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      orderby fcmdescueautori.fcm_ordvis_ades
                                      select new ModeloAutorizarDescuento
                                      {
                                          Fcm_autdes_ades = fcmdescueautori.fcm_autdes_ades,
                                          Fcm_ordvis_ades = (int)fcmdescueautori.fcm_ordvis_ades,
                                          Adm_secadm_rgad = fcmdescueautori.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmdescueautori.sia_idesec_usua,
                                          Sia_nroide_usua = fcmdescueautori.sia_nroide_usua,
                                          Fcm_fecsol_ades = (DateTime)fcmdescueautori.fcm_fecsol_ades,
                                          Fcm_horsol_ades = (Decimal)fcmdescueautori.fcm_horsol_ades,
                                          Fcm_fecaut_ades = (DateTime)fcmdescueautori.fcm_fecaut_ades,
                                          Fcm_horaut_ades = (Decimal)fcmdescueautori.fcm_horaut_ades,
                                          Fcm_valref_dfac = (float)fcmdescueautori.fcm_valref_dfac,
                                          Fcm_valdes_ades = (float)fcmdescueautori.fcm_valdes_ades,
                                          Fcm_valdes_dfac = (float)fcmdescueautori.fcm_valdes_dfac,
                                          Fcm_pordes_dfac = (float)fcmdescueautori.fcm_pordes_dfac,
                                          Fcm_valefe_dfac = (float)fcmdescueautori.fcm_valefe_dfac,
                                          Fcm_notaut_ades = fcmdescueautori.fcm_notaut_ades,
                                          Sys_ususol_usux = fcmdescueautori.sys_ususol_usux,
                                          Desys_ususol_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == fcmdescueautori.sys_ususol_usux).sys_nomusu_usux,
                                          Sys_codusu_usux = fcmdescueautori.sys_codusu_usux,
                                          Fcm_aplcad_ades = fcmdescueautori.fcm_aplcad_ades,
                                          Fcm_estaut_ades = fcmdescueautori.fcm_estaut_ades,
                                          Sia_tipide_tide = rgad.sia_tipide_tide,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Sia_tipusu_regi = rgad.sia_tipusu_regi,
                                          Sia_priape_usua = usua.sia_priape_usua,
                                          Sia_segape_usua = usua.sia_segape_usua,
                                          Sia_prinom_usua = usua.sia_prinom_usua,
                                          Sia_segnom_usua = usua.sia_segnom_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sis_dessex_sexo = _context.Sistablasexos.FirstOrDefault(rxp => rxp.sis_codsex_sexo == usua.sis_codsex_sexo).sis_dessex_sexo,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == rgad.sia_tipusu_regi).sia_destip_regi,
                                      };
                    return lobConsulta.Take(50).ToList();
                }
                else
                {
                    var lobConsulta = from fcmdescueautori in _context.Fcmdescueautori
                                      join admregadmision in _context.Admregadmision on fcmdescueautori.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmdescueautori.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join sysusuarios in _context.Sysusuarios on fcmdescueautori.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      orderby fcmdescueautori.fcm_ordvis_ades
                                      where fcmdescueautori.fcm_autdes_ades.Contains(tcrBuscar) ||
                                            fcmdescueautori.fcm_notaut_ades.Contains(tcrBuscar) ||
                                            usua.sia_nomusu_usua.Contains(tcrBuscar)
                                      select new ModeloAutorizarDescuento
                                      {
                                          Fcm_autdes_ades = fcmdescueautori.fcm_autdes_ades,
                                          Fcm_ordvis_ades = (int)fcmdescueautori.fcm_ordvis_ades,
                                          Adm_secadm_rgad = fcmdescueautori.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmdescueautori.sia_idesec_usua,
                                          Sia_nroide_usua = fcmdescueautori.sia_nroide_usua,
                                          Fcm_fecsol_ades = (DateTime)fcmdescueautori.fcm_fecsol_ades,
                                          Fcm_horsol_ades = (Decimal)fcmdescueautori.fcm_horsol_ades,
                                          Fcm_fecaut_ades = (DateTime)fcmdescueautori.fcm_fecaut_ades,
                                          Fcm_horaut_ades = (Decimal)fcmdescueautori.fcm_horaut_ades,
                                          Fcm_valref_dfac = (float)fcmdescueautori.fcm_valref_dfac,
                                          Fcm_valdes_ades = (float)fcmdescueautori.fcm_valdes_ades,
                                          Fcm_valdes_dfac = (float)fcmdescueautori.fcm_valdes_dfac,
                                          Fcm_pordes_dfac = (float)fcmdescueautori.fcm_pordes_dfac,
                                          Fcm_valefe_dfac = (float)fcmdescueautori.fcm_valefe_dfac,
                                          Fcm_notaut_ades = fcmdescueautori.fcm_notaut_ades,
                                          Sys_ususol_usux = fcmdescueautori.sys_ususol_usux,
                                          Desys_ususol_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == fcmdescueautori.sys_ususol_usux).sys_nomusu_usux,
                                          Sys_codusu_usux = fcmdescueautori.sys_codusu_usux,
                                          Fcm_aplcad_ades = fcmdescueautori.fcm_aplcad_ades,
                                          Fcm_estaut_ades = fcmdescueautori.fcm_estaut_ades,
                                          Sia_tipide_tide = rgad.sia_tipide_tide,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Sia_tipusu_regi = rgad.sia_tipusu_regi,
                                          Sia_priape_usua = usua.sia_priape_usua,
                                          Sia_segape_usua = usua.sia_segape_usua,
                                          Sia_prinom_usua = usua.sia_prinom_usua,
                                          Sia_segnom_usua = usua.sia_segnom_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sis_dessex_sexo = _context.Sistablasexos.FirstOrDefault(rxp => rxp.sis_codsex_sexo == usua.sis_codsex_sexo).sis_dessex_sexo,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == rgad.sia_tipusu_regi).sia_destip_regi,
                                      };
                    return lobConsulta.Take(50).ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
}

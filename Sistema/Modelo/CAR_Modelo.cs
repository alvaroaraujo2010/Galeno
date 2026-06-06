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
    #region Modelo Maestro Cuenta de cobro factura Dian
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carmaesfactuma
    /// </summary>
    public class ModeloCarGenFactDian : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Car_secfac_camf: Codigo unico registro
        private String _car_secfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: car_secfac_camf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial registro
        /// </para>
        /// </summary>
        public String Car_secfac_camf
        {
            get { return _car_secfac_camf; }
            set
            {
                if (_car_secfac_camf == value) return;
                _car_secfac_camf = value;
                OnPropertyChanged("Car_secfac_camf");
            }
        }
        #endregion
        #region Fcm_typdoc_fctd: Tipo documento
        private String _fcm_typdoc_fctd;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: fcm_typdoc_fctd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica
        /// de Venta 02=Factura electrónica venta-xportación 91=Nota Credito
        /// 92=Nota Debito y otros</para>
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
        #region Car_prnobs_camf: Imprimir la observacion
        private String _car_prnobs_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir la observacion</para>
        /// <para>NOMBRE: car_prnobs_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Enviar la observacion a la factura impresa: 1=Imprimir la observacion
        /// 2=No imprimir la observacion
        /// </para>
        /// </summary>
        public String Car_prnobs_camf
        {
            get { return _car_prnobs_camf; }
            set
            {
                if (_car_prnobs_camf == value) return;
                _car_prnobs_camf = value;
                OnPropertyChanged("Car_prnobs_camf");
            }
        }
        #endregion
        #region Car_observ_camf: Observacion
        private String _car_observ_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: car_observ_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nota de Observación
        /// </para>
        /// </summary>
        public String Car_observ_camf
        {
            get { return _car_observ_camf; }
            set
            {
                if (_car_observ_camf == value) return;
                _car_observ_camf = value;
                OnPropertyChanged("Car_observ_camf");
            }
        }
        #endregion
        #region Car_prnnot_camf: Imprimir Nota inferior
        private String _car_prnnot_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir Nota inferior</para>
        /// <para>NOMBRE: car_prnnot_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Enviar la nota inferior a factura  impresa: 1=Imprimir la nota
        /// inferior 2=No imprimir la la nota inferior
        /// </para>
        /// </summary>
        public String Car_prnnot_camf
        {
            get { return _car_prnnot_camf; }
            set
            {
                if (_car_prnnot_camf == value) return;
                _car_prnnot_camf = value;
                OnPropertyChanged("Car_prnnot_camf");
            }
        }
        #endregion
        #region Car_medpag_camf: Nota impresa pagos
        private String _car_medpag_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Nota impresa pagos</para>
        /// <para>NOMBRE: car_medpag_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Descripcion y numeros de cuentas bancarias (Nota de pago en
        /// factura)
        /// </para>
        /// </summary>
        public String Car_medpag_camf
        {
            get { return _car_medpag_camf; }
            set
            {
                if (_car_medpag_camf == value) return;
                _car_medpag_camf = value;
                OnPropertyChanged("Car_medpag_camf");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION: Código Empresa Adquirente/cliente y/o tercero contable segun módulos administrativos</para>
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
        #region Fcm_secraz_fcem: Codigo unico Razon social
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Codigo unico Razon social</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo secuencial unico razon social empresa
        /// </para>
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
        #region Fcm_secres_srfa: Codigo resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo relacion con resolución Dian con la cual se genera la
        /// factura
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
        #region Car_nrofac_camf: Numero factura Dian
        private String _car_nrofac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Numero factura Dian</para>
        /// <para>NOMBRE: car_nrofac_camf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION: Numero de factura generado con resolucion Dian</para>
        /// </summary>
        public String Car_nrofac_camf
        {
            get { return _car_nrofac_camf; }
            set
            {
                if (_car_nrofac_camf == value) return;
                _car_nrofac_camf = value;
                OnPropertyChanged("Car_nrofac_camf");
            }
        }
        #endregion
        #region Car_fecfac_camf: Fecha factura
        private DateTime _car_fecfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: car_fecfac_camf (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)</para>
        /// </summary>
        public DateTime Car_fecfac_camf
        {
            get { return _car_fecfac_camf; }
            set
            {
                if (_car_fecfac_camf == value) return;
                _car_fecfac_camf = value;
                OnPropertyChanged("Car_fecfac_camf");
            }
        }
        #endregion
        #region Fcm_horfac_camf: Hora emision factura
        private Decimal _fcm_horfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Hora emision factura</para>
        /// <para>NOMBRE: fcm_horfac_camf (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Hora emision de la factura
        /// </para>
        /// </summary>
        public Decimal Fcm_horfac_camf
        {
            get { return _fcm_horfac_camf; }
            set
            {
                if (_fcm_horfac_camf == value) return;
                _fcm_horfac_camf = value;
                OnPropertyChanged("Fcm_horfac_camf");
            }
        }
        #endregion
        #region Car_diavfa_camf: Dias vencimiento factura
        private int _car_diavfa_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Dias vencimiento factura</para>
        /// <para>NOMBRE: car_diavfa_camf (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Numero de dias para vigencia de factura de venta el sistema realiza el calculo del dia final</para>
        /// </summary>
        public int Car_diavfa_camf
        {
            get { return _car_diavfa_camf; }
            set
            {
                if (_car_diavfa_camf == value) return;
                _car_diavfa_camf = value;
                OnPropertyChanged("Car_diavfa_camf");
            }
        }
        #endregion
        #region Fcm_valbru_camf: Valor bruto factura
        private decimal _fcm_valbru_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_camf (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public decimal Fcm_valbru_camf
        {
            get { return _fcm_valbru_camf; }
            set
            {
                if (_fcm_valbru_camf == value) return;
                _fcm_valbru_camf = value;
                OnPropertyChanged("Fcm_valbru_camf");
            }
        }
        #endregion
        #region Car_valfac_camf: Valor total factura Dian
        private decimal _car_valfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Valor total factura Dian</para>
        /// <para>NOMBRE: car_valfac_camf (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Valor total a cobrar de la factura generada con codigo DIAN</para>
        /// </summary>
        public decimal Car_valfac_camf
        {
            get { return _car_valfac_camf; }
            set
            {
                if (_car_valfac_camf == value) return;
                _car_valfac_camf = value;
                OnPropertyChanged("Car_valfac_camf");
            }
        }
        #endregion
        #region Fcm_codest_fcws: Estado gestion Dian
        private String _fcm_codest_fcws;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresdian</para>
        /// <para>CAMPO: Estado gestion Dian</para>
        /// <para>NOMBRE: fcm_codest_fcws (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado gestion WS Dian: R01=Enviada y aceptada con Éxito R02=Enviada
        /// con errores en validacion C01=El Servicio Dian no respondio ... Otros </para>
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
        // Impuestos
        #region Fcm_valbsi_dfac: Valor Base impuestos
        private decimal _fcm_valbsi_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: fcm_valbsi_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION: Valor de la base Imponible (base para el calculo de impuesto)</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: fcm_valicd_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor del IC - Impuesto al Consumo Departamental Nomianl
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: fcm_valica_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor ICA - Impuesto de Industria, Comercio y Aviso
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INC - Impuesto Nacional Consumo</para>
        /// <para>NOMBRE: fcm_valinc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Valor INC Impuesto Nacional al Consumo
        /// </para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: fcm_valrti_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: fcm_valrtf_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: fcm_valrtc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: VAaor RedCREE</para>
        /// <para>NOMBRE: fcm_valcre_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: fcm_valfth_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: fcm_valtim_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: fcm_valbol_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: fcm_valicr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: fcm_valicb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_valscb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: fcm_valsco_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Figura tributaria aplicada</para>
        /// <para>NOMBRE: fcm_valftr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        // Inforamcion sobre el pago de la factura
        #region Fcm_metpag_mfac: Metodo de pago
        private String _fcm_metpag_mfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Metodo de pago</para>
        /// <para>NOMBRE: fcm_metpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Metodo de pago 1=Contado 2=Credito
        /// </para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Medio de pago</para>
        /// <para>NOMBRE: fcm_codmpg_fcmp (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// FAN02: Codigo secuencial medios de pago según cuadro No: 6.3.4.2 - Medios de Pago 
        /// cbc:PaymentMeansCode : 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha Vencimiento</para>
        /// <para>NOMBRE: fcm_fecven_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region Car_tipfac_camf: Incluye cuenta de cobro
        private String _car_tipfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Incluye cuenta de cobro</para>
        /// <para>NOMBRE: car_tipfac_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// incluye cuenta de cobro facutracion 1=Incluye  cuenta de cobro
        /// 2=No Incluye cuenta de cobro
        /// </para>
        /// </summary>
        public String Car_tipfac_camf
        {
            get { return _car_tipfac_camf; }
            set
            {
                if (_car_tipfac_camf == value) return;
                _car_tipfac_camf = value;
                OnPropertyChanged("Car_tipfac_camf");
            }
        }
        #endregion
        #region Fcm_secreg_mfcb: Cuenta cobro facturacion
        private String _fcm_secreg_mfcb;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Cuenta cobro facturacion</para>
        /// <para>NOMBRE: fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// codigo cuenta de cobro realizada en facturacion que esta asociada
        /// a esta factura de venta
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region Fcm_fecfac_mfac: Fecha factura
        private DateTime _fcm_fecfac_mfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region Fcm_valbru_dfac: Valor bruto factura
        private decimal _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
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
        #region Fcm_valdes_dfac: Valor del descuento
        private decimal _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        #region Fcm_valcpa_dfac: Valor copagos
        private decimal _fcm_valcpa_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copagos</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago y o cuota moderadora recudado en  servicios
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
        #region Fcm_valfac_dfac: Valor total facturado
        private decimal _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
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
        #region Fcm_sercre_mfac: Secuencial Nota Credito
        private String _fcm_sercre_mfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Secuencial Nota Credito</para>
        /// <para>NOMBRE: fcm_sercre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico Documento Factura o  Documento Nota Credito
        /// de referencia por la cual se genera este documento</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Referencia Notas Credito</para>
        /// <para>NOMBRE: fcm_idrcre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Prefijo + Número de la nota crédito  (se escribe numero de
        /// factura cuando este documento es nota credito) referenciada:
        /// Se debe diligenciar únicamente cuando la FE se origina a partir
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Secuencial Nota Debito</para>
        /// <para>NOMBRE: fcm_serdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico Documento Factura o  Documento Nota Debito
        /// de referencia por la cual se genera este documento</para>
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
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Referencia Notas Debito</para>
        /// <para>NOMBRE: fcm_idrdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Prefijo + Número de la nota debito referenciada (se escribe
        /// numero de factura cuando este documento es nota debito),  Se
        /// debe diligenciar únicamente cuando la FE se origina a partir
        /// de la correcció o ajuste que se da mediante un Nota Debito</para>
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
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        #region Car_conest_camf: Contador detalles
        private int _car_conest_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Contador detalles</para>
        /// <para>NOMBRE: car_conest_camf (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos detalles conceptos
        /// de la factura
        /// </para>
        /// </summary>
        public int Car_conest_camf
        {
            get { return _car_conest_camf; }
            set
            {
                if (_car_conest_camf == value) return;
                _car_conest_camf = value;
                OnPropertyChanged("Car_conest_camf");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        // Datos Descripcion 
        #region Fcm_numdoc_fcem: Numero Nit
        private String _fcm_numdoc_fcem;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero Nit</para>
        /// <para>NOMBRE: fcm_numdoc_fcem (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Numero del Nit de la empresa
        /// </para>
        /// </summary>
        public String Fcm_numdoc_fcem
        {
            get { return _fcm_numdoc_fcem; }
            set
            {
                if (_fcm_numdoc_fcem == value) return;
                _fcm_numdoc_fcem = value;
                OnPropertyChanged("Fcm_numdoc_fcem");
            }
        }
        #endregion
        #region Fcm_nomcom_fcem: Nombre Comercial
        private String _fcm_nomcom_fcem;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Comercial</para>
        /// <para>NOMBRE: fcm_nomcom_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Nombre comercial de la empresa
        /// </para>
        /// </summary>
        public String Fcm_nomcom_fcem
        {
            get { return _fcm_nomcom_fcem; }
            set
            {
                if (_fcm_nomcom_fcem == value) return;
                _fcm_nomcom_fcem = value;
                OnPropertyChanged("Fcm_nomcom_fcem");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        /// <para>TABLA: temporal</para>
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
        #region Fcm_descue_mfcb: Descripción
        private String _fcm_descue_mfcb;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
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
        #region Fcm_desres_srfa: Descripción Resolucion
        private String _fcm_desres_srfa;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        // Datos del Adquirente  o tercero contable 
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
        #region Sis_emailc_sitr: Correo Eletronico
        private string _sis_emailc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Correo Eletronico</para>
        /// <para>NOMBRE: sis_emailc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION: Correo electronico para contacto o envia facturas </para>
        /// </summary>
        public string Sis_emailc_sitr
        {
            get { return _sis_emailc_sitr; }
            set
            {
                if (_sis_emailc_sitr == value) return;
                _sis_emailc_sitr = value;
                OnPropertyChanged("Sis_emailc_sitr");
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
        public static String flgAddRegistro(ModeloCarGenFactDian tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CAR-GENFACT-DIAN", "CAR", "Generar cuenta de cobro con factura dian");
            try
            {
                //MessageBox.Show("PASO 1");
                if (!flgBuscarCarmaesfactuma(lcrCodigoGen))
                {
                    //MessageBox.Show("PASO 2");
                    using (_context = new DbAplicacion())
                    {
                        //MessageBox.Show("PASO 3");

                        var lobjRegistro = new EFcarmaesfactuma
                        {
                            #region cargar Registro
                            car_secfac_camf = tobjModelo.Car_secfac_camf,
                            fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd,
                            car_prnobs_camf = tobjModelo.Car_prnobs_camf,
                            car_observ_camf = tobjModelo.Car_observ_camf,
                            car_prnnot_camf = tobjModelo.Car_prnnot_camf,
                            car_medpag_camf = tobjModelo.Car_medpag_camf,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            car_nrofac_camf = tobjModelo.Car_nrofac_camf,
                            car_fecfac_camf = tobjModelo.Car_fecfac_camf,
                            fcm_horfac_camf = tobjModelo.Fcm_horfac_camf,
                            car_diavfa_camf = tobjModelo.Car_diavfa_camf,
                            fcm_valbru_camf = tobjModelo.Fcm_valbru_camf,
                            car_valfac_camf = tobjModelo.Car_valfac_camf,
                            fcm_codest_fcws = tobjModelo.Fcm_codest_fcws,
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
                            fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac,
                            fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp,
                            fcm_fecven_mfac = tobjModelo.Fcm_fecven_mfac,
                            car_tipfac_camf = tobjModelo.Car_tipfac_camf,
                            fcm_secreg_mfcb = tobjModelo.Fcm_secreg_mfcb,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_fecfac_mfac = tobjModelo.Fcm_fecfac_mfac,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_valcpa_dfac = tobjModelo.Fcm_valcpa_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            fcm_sercre_mfac = tobjModelo.Fcm_sercre_mfac,
                            fcm_idrcre_mfac = tobjModelo.Fcm_idrcre_mfac,
                            fcm_serdeb_mfac = tobjModelo.Fcm_serdeb_mfac,
                            fcm_idrdeb_mfac = tobjModelo.Fcm_idrdeb_mfac,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            car_conest_camf = tobjModelo.Car_conest_camf,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        //MessageBox.Show("PASO 4");

                        lobjRegistro.car_secfac_camf = lcrCodigoGen;
                        _context.AddToCarmaesfactuma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CAR-GENFACT-DIAN': Generar cuenta de cobro con factura dian en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloCarGenFactDian tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tobjModelo.Car_secfac_camf);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.car_secfac_camf = tobjModelo.Car_secfac_camf;
                        lobjRegistro.fcm_typdoc_fctd = tobjModelo.Fcm_typdoc_fctd;
                        lobjRegistro.car_prnobs_camf = tobjModelo.Car_prnobs_camf;
                        lobjRegistro.car_observ_camf = tobjModelo.Car_observ_camf;
                        lobjRegistro.car_prnnot_camf = tobjModelo.Car_prnnot_camf;
                        lobjRegistro.car_medpag_camf = tobjModelo.Car_medpag_camf;
                        lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                        lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.car_nrofac_camf = tobjModelo.Car_nrofac_camf;
                        lobjRegistro.car_fecfac_camf = (DateTime)tobjModelo.Car_fecfac_camf;
                        lobjRegistro.fcm_horfac_camf = (Decimal)tobjModelo.Fcm_horfac_camf;
                        lobjRegistro.car_diavfa_camf = (int)tobjModelo.Car_diavfa_camf;
                        lobjRegistro.fcm_valbru_camf = (decimal)tobjModelo.Fcm_valbru_camf;
                        lobjRegistro.car_valfac_camf = (decimal)tobjModelo.Car_valfac_camf;
                        lobjRegistro.fcm_codest_fcws = tobjModelo.Fcm_codest_fcws;
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
                        lobjRegistro.fcm_metpag_mfac = tobjModelo.Fcm_metpag_mfac;
                        lobjRegistro.fcm_codmpg_fcmp = tobjModelo.Fcm_codmpg_fcmp;
                        lobjRegistro.fcm_fecven_mfac = (DateTime)tobjModelo.Fcm_fecven_mfac;
                        lobjRegistro.car_tipfac_camf = tobjModelo.Car_tipfac_camf;
                        lobjRegistro.fcm_secreg_mfcb = tobjModelo.Fcm_secreg_mfcb;
                        lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                        lobjRegistro.fcm_fecfac_mfac = (DateTime)tobjModelo.Fcm_fecfac_mfac;
                        lobjRegistro.fcm_valbru_dfac = (decimal)tobjModelo.Fcm_valbru_dfac;
                        lobjRegistro.fcm_valdes_dfac = (decimal)tobjModelo.Fcm_valdes_dfac;
                        lobjRegistro.fcm_valcpa_dfac = (decimal)tobjModelo.Fcm_valcpa_dfac;
                        lobjRegistro.fcm_valfac_dfac = (decimal)tobjModelo.Fcm_valfac_dfac;
                        lobjRegistro.fcm_sercre_mfac = tobjModelo.Fcm_sercre_mfac;
                        lobjRegistro.fcm_idrcre_mfac = tobjModelo.Fcm_idrcre_mfac;
                        lobjRegistro.fcm_serdeb_mfac = tobjModelo.Fcm_serdeb_mfac;
                        lobjRegistro.fcm_idrdeb_mfac = tobjModelo.Fcm_idrdeb_mfac;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.car_conest_camf = (int)tobjModelo.Car_conest_camf;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
        #region FlgActualizarParametros: Actualziar estado gestion Dian
        /// <summary>
        /// Actualziar el estado gestion Dian
        /// </summary>
        /// <param name="tobRegistro">Rgistro que contiene los datos para actualizar</param>
        public static bool FlgActualizarParametros(ModeloCarGenFactDian tobRegistro, out string tcrMensaje)
        {
            var llgReturn = true;
            tcrMensaje = null;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tobRegistro.Car_secfac_camf);
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
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
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
                    var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tcrCodigo);
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
        #region Buscar CARMAESFACTUMA: Logica
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TITULO: Maestro facturas cobro facturacion</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas cobro facturacion, para generar facturas con
        /// secuencial DIAN, importa cuentas de cobro generadas en modulo
        /// facturacion
        /// </para>
        /// </summary>
        public static bool flgBuscarCarmaesfactuma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        // Generar Datos para factura DIAN
        #region FlgGuardarDocumentoDian: Genera los datos para guardar en base de datos 
        /// <summary>
        /// Genera los datos para guardar en base de datos documentos DIAN
        /// </summary>
        /// <param name="tobjModelo"></param>
        /// <param name="tobRegDetalles"></param>
        /// <param name="tcrMensaje"></param>
        /// <returns></returns>
        public static bool FlgGuardarDocumentoDian(ModeloCarGenFactDian tobRegMaestro, List<ModeloCarGenFactDianDe> tmpRegDetalles, out string tcrMensaje)
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
                    Fcm_secreg_mfac = tobRegMaestro.Car_secfac_camf,
                    Fcm_secraz_fcem = tobRegMaestro.Fcm_secraz_fcem,
                    Fcm_numfac_mfac = tobRegMaestro.Car_nrofac_camf,
                    Fcm_fecfac_mfac = tobRegMaestro.Car_fecfac_camf,
                    Fcm_horfac_mfac = tobRegMaestro.Fcm_horfac_camf,
                    Fcm_typdoc_fctd = tobRegMaestro.Fcm_typdoc_fctd,
                    Fcm_notdoc_mfac = tobRegMaestro.Car_observ_camf,
                    Fcm_forpag_mfac = tobRegMaestro.Fcm_metpag_mfac,
                    Fcm_facori_mfac = "01",
                    Fcm_secres_srfa = tobRegMaestro.Fcm_secres_srfa,
                    Adm_secadm_rgad = "NA",
                    Sia_idesec_usua = "NA",
                    Cto_seccon_cont = tobRegMaestro.Cto_seccon_cont,
                    Sia_codeps_teps = tobRegMaestro.Sia_codeps_teps,
                    Sis_idterc_sitr = tobRegMaestro.Sis_idterc_sitr,
                    Fcm_sercre_mfac = tobRegMaestro.Fcm_sercre_mfac,
                    Fcm_idrcre_mfac = tobRegMaestro.Fcm_idrcre_mfac,
                    Fcm_serdeb_mfac = tobRegMaestro.Fcm_serdeb_mfac,
                    Fcm_idrdeb_mfac = tobRegMaestro.Fcm_idrdeb_mfac,
                    Fcm_valbsi_dfac = tobRegMaestro.Fcm_valbsi_dfac,
                    Fcm_valiva_dfac = tobRegMaestro.Fcm_valiva_dfac,
                    Fcm_valicd_dfac = tobRegMaestro.Fcm_valicd_dfac,
                    Fcm_valica_dfac = tobRegMaestro.Fcm_valica_dfac,
                    Fcm_valinc_dfac = tobRegMaestro.Fcm_valinc_dfac,
                    Fcm_valrti_dfac = tobRegMaestro.Fcm_valrti_dfac,
                    Fcm_valrtf_dfac = tobRegMaestro.Fcm_valrtf_dfac,
                    Fcm_valrtc_dfac = tobRegMaestro.Fcm_valrtc_dfac,
                    Fcm_valcre_dfac = tobRegMaestro.Fcm_valcre_dfac,
                    Fcm_valfth_dfac = tobRegMaestro.Fcm_valfth_dfac,
                    Fcm_valtim_dfac = tobRegMaestro.Fcm_valtim_dfac,
                    Fcm_valbol_dfac = tobRegMaestro.Fcm_valbol_dfac,
                    Fcm_valicr_dfac = tobRegMaestro.Fcm_valicr_dfac,
                    Fcm_valicb_dfac = tobRegMaestro.Fcm_valicb_dfac,
                    Fcm_valscb_dfac = tobRegMaestro.Fcm_valscb_dfac,
                    Fcm_valsco_dfac = tobRegMaestro.Fcm_valsco_dfac,
                    Fcm_valftr_dfac = tobRegMaestro.Fcm_valftr_dfac,
                    Fcm_pordes_dfac = 0, 
                    Fcm_valdes_dfac = tobRegMaestro.Fcm_valdes_dfac, // Viene de incluir cuentas de cobro
                    Fcm_valcpa_dfac = tobRegMaestro.Fcm_valcpa_dfac, // Viene de incluir cuentas de cobro
                    Fcm_valcmo_dfac = 0,                             // Viene de incluir cuentas de cobro
                    Fcm_valusu_dfac = 0,                             // Viene de incluir cuentas de cobro
                    Fcm_valbru_dfac = tobRegMaestro.Fcm_valbru_camf,
                    Fcm_valsub_dfac = tobRegMaestro.Car_valfac_camf,
                    Fcm_valfac_dfac = tobRegMaestro.Car_valfac_camf,
                    Fcm_valref_dfac = 0,
                    Fcm_valefe_dfac = 0,
                    Fcm_idcufe_mfac = "NA",
                    Fcm_diafec_mfac = DateTime.Parse("01/01/0001"),
                    Fcm_diahor_mfac = 0,
                    Fcm_codest_fcws = tobRegMaestro.Fcm_codest_fcws,  // "P01" = Pendiente para enviar a DIAN
                    Fcm_nomarc_mfac = "NA",
                    Fcm_secrad_mfac = 0, // Lo asigna la funcion que guarda dentro de la tabla Maestro Facturas Dian
                    Fcm_trakid_mfac = "NA", // cuando ya existe el registro de esta factura lo conserva la tabla Maestro Facturas
                    Fcm_adqfec_mfac = DateTime.Parse("01/01/0001"),
                    Fcm_adqhor_mfac = 0,
                    Fcm_codest_fcaq = "A01", // Pendiente por enviar al adquirente por correo
                    Fcm_metpag_mfac = tobRegMaestro.Fcm_metpag_mfac,
                    Fcm_codmpg_fcmp = tobRegMaestro.Fcm_codmpg_fcmp,
                    Fcm_fecven_mfac = tobRegMaestro.Fcm_fecven_mfac,
                    Fcm_idepag_fcmp = "1", // FAN05 - "1"=Instrumento no definido (asi esta en la norma)
                    Fcm_fecanu_mfac = DateTime.Parse("01/01/0001"),
                    Fcm_horanu_mfac = 0,
                    Sys_usuanu_usux = "NA",
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
                            Fcm_secreg_dfac = lobReg.Car_secreg_cadf,
                            Fcm_secreg_mfac = lobReg.Car_secfac_camf,
                            Fcm_numfac_mfac = tobRegMaestro.Car_nrofac_camf,
                            Fcm_idesec_mant = lobReg.Car_codcon_cacf,
                            Fcm_codpro_fcpr = lobReg.Fcm_codpro_fcpr,
                            Fcm_codbar_mant = "NA",
                            Fcm_codser_mant = lobReg.Car_codcon_cacf, // por ahora pero toca crear fcm_codser_mant en la tabla
                            Fcm_coddig_mant = lobReg.Car_codcon_cacf, // por ahora pero toca crear fcm_coddig_mant en la tabla
                            Fcm_codman_mans = "NA",
                            Fcm_desser_dfac = lobReg.Car_descon_cadf,
                            Fcm_fecser_dfac = tobRegMaestro.Car_fecfac_camf,
                            Fcm_horser_dfac = tobRegMaestro.Fcm_horfac_camf,
                            Fcm_valser_mant = lobReg.Car_valuni_cadf,
                            Fcm_totuni_dfac = lobReg.Car_totuni_cadf,
                            Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac,
                            Fcm_valbsi_dfac = lobReg.Fcm_valbsi_dfac,
                            Fcm_poriva_dfac = lobReg.Fcm_poriva_dfac,
                            Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac,
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
                            Sis_coddes_side = lobReg.Sis_coddes_side,
                            Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac,
                            Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac,
                            Fcm_valsub_dfac = lobReg.Fcm_subtot_dfac,
                            Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac,
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
        // Generar consultas 
        #region Listar Registros
        public static List<ModeloCarGenFactDian> FlsListaCarmaesfactuma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from carmaesfactuma in _context.Carmaesfactuma
                                      join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carmaesfactuma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                      join siatablaeps in _context.Siatablaeps on carmaesfactuma.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sismaesterceros in _context.Sismaesterceros on carmaesfactuma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join fcmsecrfacturas in _context.Fcmsecrfacturas on carmaesfactuma.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmcuentacobrms in _context.Fcmcuentacobrms on carmaesfactuma.fcm_secreg_mfcb equals fcmcuentacobrms.fcm_secreg_mfcb into tmfcmcuentacobrms
                                      join sisestadoproces in _context.Sisestadoproces on carmaesfactuma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from mfcb in tmfcmcuentacobrms.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      select new ModeloCarGenFactDian
                                      {
                                          #region Datos
                                          Car_secfac_camf = carmaesfactuma.car_secfac_camf,
                                          Fcm_typdoc_fctd = carmaesfactuma.fcm_typdoc_fctd,
                                          Car_prnobs_camf = carmaesfactuma.car_prnobs_camf,
                                          Car_observ_camf = carmaesfactuma.car_observ_camf,
                                          Car_prnnot_camf = carmaesfactuma.car_prnnot_camf,
                                          Car_medpag_camf = carmaesfactuma.car_medpag_camf,
                                          Cto_seccon_cont = carmaesfactuma.cto_seccon_cont,
                                          Cto_nrocon_cont = carmaesfactuma.cto_nrocon_cont,
                                          Sia_codeps_teps = carmaesfactuma.sia_codeps_teps,
                                          Sis_idterc_sitr = carmaesfactuma.sis_idterc_sitr,
                                          Fcm_secres_srfa = carmaesfactuma.fcm_secres_srfa,
                                          Fcm_secraz_fcem = carmaesfactuma.fcm_secraz_fcem,
                                          Car_nrofac_camf = carmaesfactuma.car_nrofac_camf,
                                          Car_fecfac_camf = (DateTime)carmaesfactuma.car_fecfac_camf,
                                          Fcm_horfac_camf = (Decimal)carmaesfactuma.fcm_horfac_camf,
                                          Car_diavfa_camf = (int)carmaesfactuma.car_diavfa_camf,
                                          Fcm_valbru_camf = (decimal)carmaesfactuma.fcm_valbru_camf,
                                          Car_valfac_camf = (decimal)carmaesfactuma.car_valfac_camf,
                                          Fcm_codest_fcws = carmaesfactuma.fcm_codest_fcws,
                                          Fcm_valbsi_dfac = (decimal)carmaesfactuma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)carmaesfactuma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)carmaesfactuma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)carmaesfactuma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)carmaesfactuma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)carmaesfactuma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)carmaesfactuma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)carmaesfactuma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)carmaesfactuma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)carmaesfactuma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)carmaesfactuma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)carmaesfactuma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)carmaesfactuma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)carmaesfactuma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)carmaesfactuma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)carmaesfactuma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)carmaesfactuma.fcm_valftr_dfac,
                                          Fcm_metpag_mfac = carmaesfactuma.fcm_metpag_mfac,
                                          Fcm_codmpg_fcmp = carmaesfactuma.fcm_codmpg_fcmp,
                                          Fcm_fecven_mfac = (DateTime)carmaesfactuma.fcm_fecven_mfac,
                                          Car_tipfac_camf = carmaesfactuma.car_tipfac_camf,
                                          Fcm_secreg_mfcb = carmaesfactuma.fcm_secreg_mfcb,
                                          Fcm_numfac_mfac = carmaesfactuma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)carmaesfactuma.fcm_fecfac_mfac,
                                          Fcm_valbru_dfac = (decimal)carmaesfactuma.fcm_valbru_dfac,
                                          Fcm_valdes_dfac = (decimal)carmaesfactuma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)carmaesfactuma.fcm_valcpa_dfac,
                                          Fcm_valfac_dfac = (decimal)carmaesfactuma.fcm_valfac_dfac,
                                          Fcm_sercre_mfac = carmaesfactuma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = carmaesfactuma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = carmaesfactuma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = carmaesfactuma.fcm_idrdeb_mfac,
                                          Sys_codusu_usux = carmaesfactuma.sys_codusu_usux,
                                          Car_conest_camf = (int)carmaesfactuma.car_conest_camf,
                                          Sis_estpro_espr = carmaesfactuma.sis_estpro_espr,
                                          Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                          Fcm_numdoc_fcem = fcem.fcm_numdoc_fcem,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sia_codnit_teps = teps.sia_codnit_teps,
                                          Fcm_descue_mfcb = mfcb.fcm_descue_mfcb,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          Fcm_numres_srfa = srfa.fcm_numres_srfa,
                                          Fcm_notenc_srfa = srfa.fcm_notenc_srfa,
                                          Fcm_noppag_srfa = srfa.fcm_noppag_srfa,
                                          Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                          Fcm_fecini_srfa = (DateTime)srfa.fcm_fecini_srfa,
                                          Fcm_facini_srfa = (int)srfa.fcm_facini_srfa,
                                          Fcm_facfin_srfa = (int)srfa.fcm_facfin_srfa,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sis_tipide_tido = sitr.sis_tipide_tido,
                                          Sis_numide_sitr = sitr.sis_numide_sitr,
                                          Sis_telefo_sitr = sitr.sis_telefo_sitr,
                                          Sis_direcc_sitr = sitr.sis_direcc_sitr,
                                          Sis_emailc_sitr = sitr.sis_emailc_sitr,
                                          Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == carmaesfactuma.cto_seccon_cont).cto_descon_cont,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from carmaesfactuma in _context.Carmaesfactuma
                                      join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carmaesfactuma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                      join siatablaeps in _context.Siatablaeps on carmaesfactuma.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sismaesterceros in _context.Sismaesterceros on carmaesfactuma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      join fcmsecrfacturas in _context.Fcmsecrfacturas on carmaesfactuma.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                      join fcmcuentacobrms in _context.Fcmcuentacobrms on carmaesfactuma.fcm_secreg_mfcb equals fcmcuentacobrms.fcm_secreg_mfcb into tmfcmcuentacobrms
                                      join sisestadoproces in _context.Sisestadoproces on carmaesfactuma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                      from mfcb in tmfcmcuentacobrms.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where carmaesfactuma.car_secfac_camf.Contains(tcrBuscar) || carmaesfactuma.car_observ_camf.Contains(tcrBuscar)
                                      select new ModeloCarGenFactDian
                                      {
                                          #region Datos
                                          Car_secfac_camf = carmaesfactuma.car_secfac_camf,
                                          Fcm_typdoc_fctd = carmaesfactuma.fcm_typdoc_fctd,
                                          Car_prnobs_camf = carmaesfactuma.car_prnobs_camf,
                                          Car_observ_camf = carmaesfactuma.car_observ_camf,
                                          Car_prnnot_camf = carmaesfactuma.car_prnnot_camf,
                                          Car_medpag_camf = carmaesfactuma.car_medpag_camf,
                                          Cto_seccon_cont = carmaesfactuma.cto_seccon_cont,
                                          Cto_nrocon_cont = carmaesfactuma.cto_nrocon_cont,
                                          Sia_codeps_teps = carmaesfactuma.sia_codeps_teps,
                                          Sis_idterc_sitr = carmaesfactuma.sis_idterc_sitr,
                                          Fcm_secres_srfa = carmaesfactuma.fcm_secres_srfa,
                                          Fcm_secraz_fcem = carmaesfactuma.fcm_secraz_fcem,
                                          Car_nrofac_camf = carmaesfactuma.car_nrofac_camf,
                                          Car_fecfac_camf = (DateTime)carmaesfactuma.car_fecfac_camf,
                                          Fcm_horfac_camf = (Decimal)carmaesfactuma.fcm_horfac_camf,
                                          Car_diavfa_camf = (int)carmaesfactuma.car_diavfa_camf,
                                          Fcm_valbru_camf = (decimal)carmaesfactuma.fcm_valbru_camf,
                                          Car_valfac_camf = (decimal)carmaesfactuma.car_valfac_camf,
                                          Fcm_codest_fcws = carmaesfactuma.fcm_codest_fcws,
                                          Fcm_valbsi_dfac = (decimal)carmaesfactuma.fcm_valbsi_dfac,
                                          Fcm_valiva_dfac = (decimal)carmaesfactuma.fcm_valiva_dfac,
                                          Fcm_valicd_dfac = (decimal)carmaesfactuma.fcm_valicd_dfac,
                                          Fcm_valica_dfac = (decimal)carmaesfactuma.fcm_valica_dfac,
                                          Fcm_valinc_dfac = (decimal)carmaesfactuma.fcm_valinc_dfac,
                                          Fcm_valrti_dfac = (decimal)carmaesfactuma.fcm_valrti_dfac,
                                          Fcm_valrtf_dfac = (decimal)carmaesfactuma.fcm_valrtf_dfac,
                                          Fcm_valrtc_dfac = (decimal)carmaesfactuma.fcm_valrtc_dfac,
                                          Fcm_valcre_dfac = (decimal)carmaesfactuma.fcm_valcre_dfac,
                                          Fcm_valfth_dfac = (decimal)carmaesfactuma.fcm_valfth_dfac,
                                          Fcm_valtim_dfac = (decimal)carmaesfactuma.fcm_valtim_dfac,
                                          Fcm_valbol_dfac = (decimal)carmaesfactuma.fcm_valbol_dfac,
                                          Fcm_valicr_dfac = (decimal)carmaesfactuma.fcm_valicr_dfac,
                                          Fcm_valicb_dfac = (decimal)carmaesfactuma.fcm_valicb_dfac,
                                          Fcm_valscb_dfac = (decimal)carmaesfactuma.fcm_valscb_dfac,
                                          Fcm_valsco_dfac = (decimal)carmaesfactuma.fcm_valsco_dfac,
                                          Fcm_valftr_dfac = (decimal)carmaesfactuma.fcm_valftr_dfac,
                                          Fcm_metpag_mfac = carmaesfactuma.fcm_metpag_mfac,
                                          Fcm_codmpg_fcmp = carmaesfactuma.fcm_codmpg_fcmp,
                                          Fcm_fecven_mfac = (DateTime)carmaesfactuma.fcm_fecven_mfac,
                                          Car_tipfac_camf = carmaesfactuma.car_tipfac_camf,
                                          Fcm_secreg_mfcb = carmaesfactuma.fcm_secreg_mfcb,
                                          Fcm_numfac_mfac = carmaesfactuma.fcm_numfac_mfac,
                                          Fcm_fecfac_mfac = (DateTime)carmaesfactuma.fcm_fecfac_mfac,
                                          Fcm_valbru_dfac = (decimal)carmaesfactuma.fcm_valbru_dfac,
                                          Fcm_valdes_dfac = (decimal)carmaesfactuma.fcm_valdes_dfac,
                                          Fcm_valcpa_dfac = (decimal)carmaesfactuma.fcm_valcpa_dfac,
                                          Fcm_valfac_dfac = (decimal)carmaesfactuma.fcm_valfac_dfac,
                                          Fcm_sercre_mfac = carmaesfactuma.fcm_sercre_mfac,
                                          Fcm_idrcre_mfac = carmaesfactuma.fcm_idrcre_mfac,
                                          Fcm_serdeb_mfac = carmaesfactuma.fcm_serdeb_mfac,
                                          Fcm_idrdeb_mfac = carmaesfactuma.fcm_idrdeb_mfac,
                                          Sys_codusu_usux = carmaesfactuma.sys_codusu_usux,
                                          Car_conest_camf = (int)carmaesfactuma.car_conest_camf,
                                          Sis_estpro_espr = carmaesfactuma.sis_estpro_espr,
                                          Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                          Fcm_numdoc_fcem = fcem.fcm_numdoc_fcem,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sia_codnit_teps = teps.sia_codnit_teps,
                                          Fcm_descue_mfcb = mfcb.fcm_descue_mfcb,
                                          Sis_despro_espr = espr.sis_despro_espr,
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
                                          Sis_emailc_sitr = sitr.sis_emailc_sitr,
                                          Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == carmaesfactuma.cto_seccon_cont).cto_descon_cont,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region un solo Registro
        /// <summary>
        /// Generar un registro de factura completo 
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NF"=Numero de Factura</param>
        /// <param name="tcrIdRegistro">Codigo del registro o numero de factura</param>
        /// <returns></returns>
        public static ModeloCarGenFactDian FobRegistroCarmaesfactuma(string tcrTipo, string tcrIdRegistro)
        {
            ModeloCarGenFactDian lobConsulta = null;

            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "ID") // por el Id del registro factura
                {
                    lobConsulta = (from carmaesfactuma in _context.Carmaesfactuma
                                   join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carmaesfactuma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                   join siatablaeps in _context.Siatablaeps on carmaesfactuma.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sismaesterceros in _context.Sismaesterceros on carmaesfactuma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                   join fcmsecrfacturas in _context.Fcmsecrfacturas on carmaesfactuma.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                   join fcmcuentacobrms in _context.Fcmcuentacobrms on carmaesfactuma.fcm_secreg_mfcb equals fcmcuentacobrms.fcm_secreg_mfcb into tmfcmcuentacobrms
                                   join sisestadoproces in _context.Sisestadoproces on carmaesfactuma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from sitr in tmsismaesterceros.DefaultIfEmpty()
                                   from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                   from mfcb in tmfcmcuentacobrms.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where carmaesfactuma.car_secfac_camf == tcrIdRegistro
                                   select new ModeloCarGenFactDian
                                   {
                                       #region Datos
                                       Car_secfac_camf = carmaesfactuma.car_secfac_camf,
                                       Fcm_typdoc_fctd = carmaesfactuma.fcm_typdoc_fctd,
                                       Car_prnobs_camf = carmaesfactuma.car_prnobs_camf,
                                       Car_observ_camf = carmaesfactuma.car_observ_camf,
                                       Car_prnnot_camf = carmaesfactuma.car_prnnot_camf,
                                       Car_medpag_camf = carmaesfactuma.car_medpag_camf,
                                       Cto_seccon_cont = carmaesfactuma.cto_seccon_cont,
                                       Cto_nrocon_cont = carmaesfactuma.cto_nrocon_cont,
                                       Sia_codeps_teps = carmaesfactuma.sia_codeps_teps,
                                       Sis_idterc_sitr = carmaesfactuma.sis_idterc_sitr,
                                       Fcm_secres_srfa = carmaesfactuma.fcm_secres_srfa,
                                       Fcm_secraz_fcem = carmaesfactuma.fcm_secraz_fcem,
                                       Car_nrofac_camf = carmaesfactuma.car_nrofac_camf,
                                       Car_fecfac_camf = (DateTime)carmaesfactuma.car_fecfac_camf,
                                       Fcm_horfac_camf = (Decimal)carmaesfactuma.fcm_horfac_camf,
                                       Car_diavfa_camf = (int)carmaesfactuma.car_diavfa_camf,
                                       Fcm_valbru_camf = (decimal)carmaesfactuma.fcm_valbru_camf,
                                       Car_valfac_camf = (decimal)carmaesfactuma.car_valfac_camf,
                                       Fcm_codest_fcws = carmaesfactuma.fcm_codest_fcws,
                                       Fcm_valbsi_dfac = (decimal)carmaesfactuma.fcm_valbsi_dfac,
                                       Fcm_valiva_dfac = (decimal)carmaesfactuma.fcm_valiva_dfac,
                                       Fcm_valicd_dfac = (decimal)carmaesfactuma.fcm_valicd_dfac,
                                       Fcm_valica_dfac = (decimal)carmaesfactuma.fcm_valica_dfac,
                                       Fcm_valinc_dfac = (decimal)carmaesfactuma.fcm_valinc_dfac,
                                       Fcm_valrti_dfac = (decimal)carmaesfactuma.fcm_valrti_dfac,
                                       Fcm_valrtf_dfac = (decimal)carmaesfactuma.fcm_valrtf_dfac,
                                       Fcm_valrtc_dfac = (decimal)carmaesfactuma.fcm_valrtc_dfac,
                                       Fcm_valcre_dfac = (decimal)carmaesfactuma.fcm_valcre_dfac,
                                       Fcm_valfth_dfac = (decimal)carmaesfactuma.fcm_valfth_dfac,
                                       Fcm_valtim_dfac = (decimal)carmaesfactuma.fcm_valtim_dfac,
                                       Fcm_valbol_dfac = (decimal)carmaesfactuma.fcm_valbol_dfac,
                                       Fcm_valicr_dfac = (decimal)carmaesfactuma.fcm_valicr_dfac,
                                       Fcm_valicb_dfac = (decimal)carmaesfactuma.fcm_valicb_dfac,
                                       Fcm_valscb_dfac = (decimal)carmaesfactuma.fcm_valscb_dfac,
                                       Fcm_valsco_dfac = (decimal)carmaesfactuma.fcm_valsco_dfac,
                                       Fcm_valftr_dfac = (decimal)carmaesfactuma.fcm_valftr_dfac,
                                       Fcm_metpag_mfac = carmaesfactuma.fcm_metpag_mfac,
                                       Fcm_codmpg_fcmp = carmaesfactuma.fcm_codmpg_fcmp,
                                       Fcm_fecven_mfac = (DateTime)carmaesfactuma.fcm_fecven_mfac,
                                       Car_tipfac_camf = carmaesfactuma.car_tipfac_camf,
                                       Fcm_secreg_mfcb = carmaesfactuma.fcm_secreg_mfcb,
                                       Fcm_numfac_mfac = carmaesfactuma.fcm_numfac_mfac,
                                       Fcm_fecfac_mfac = (DateTime)carmaesfactuma.fcm_fecfac_mfac,
                                       Fcm_valbru_dfac = (decimal)carmaesfactuma.fcm_valbru_dfac,
                                       Fcm_valdes_dfac = (decimal)carmaesfactuma.fcm_valdes_dfac,
                                       Fcm_valcpa_dfac = (decimal)carmaesfactuma.fcm_valcpa_dfac,
                                       Fcm_valfac_dfac = (decimal)carmaesfactuma.fcm_valfac_dfac,
                                       Fcm_sercre_mfac = carmaesfactuma.fcm_sercre_mfac,
                                       Fcm_idrcre_mfac = carmaesfactuma.fcm_idrcre_mfac,
                                       Fcm_serdeb_mfac = carmaesfactuma.fcm_serdeb_mfac,
                                       Fcm_idrdeb_mfac = carmaesfactuma.fcm_idrdeb_mfac,
                                       Sys_codusu_usux = carmaesfactuma.sys_codusu_usux,
                                       Car_conest_camf = (int)carmaesfactuma.car_conest_camf,
                                       Sis_estpro_espr = carmaesfactuma.sis_estpro_espr,
                                       Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                       Fcm_numdoc_fcem = fcem.fcm_numdoc_fcem,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_codnit_teps = teps.sia_codnit_teps,
                                       Fcm_descue_mfcb = mfcb.fcm_descue_mfcb,
                                       Sis_despro_espr = espr.sis_despro_espr,
                                       Fcm_numres_srfa = srfa.fcm_numres_srfa,
                                       Fcm_notenc_srfa = srfa.fcm_notenc_srfa,
                                       Fcm_noppag_srfa = srfa.fcm_noppag_srfa,
                                       Fcm_desres_srfa = srfa.fcm_desres_srfa,
                                       Fcm_fecini_srfa = (DateTime)srfa.fcm_fecini_srfa,
                                       Fcm_facini_srfa = (int)srfa.fcm_facini_srfa,
                                       Fcm_facfin_srfa = (int)srfa.fcm_facfin_srfa,
                                       Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                       Sis_tipide_tido = sitr.sis_tipide_tido,
                                       Sis_numide_sitr = sitr.sis_numide_sitr,
                                       Sis_telefo_sitr = sitr.sis_telefo_sitr,
                                       Sis_direcc_sitr = sitr.sis_direcc_sitr,
                                       Sis_emailc_sitr = sitr.sis_emailc_sitr,
                                       Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == carmaesfactuma.cto_seccon_cont).cto_descon_cont,
                                       #endregion
                                   }).FirstOrDefault();
                }
                else
                {
                    lobConsulta = (from carmaesfactuma in _context.Carmaesfactuma
                                   join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carmaesfactuma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                   join siatablaeps in _context.Siatablaeps on carmaesfactuma.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sismaesterceros in _context.Sismaesterceros on carmaesfactuma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                   join fcmsecrfacturas in _context.Fcmsecrfacturas on carmaesfactuma.fcm_secres_srfa equals fcmsecrfacturas.fcm_secres_srfa into tmfcmsecrfacturas
                                   join fcmcuentacobrms in _context.Fcmcuentacobrms on carmaesfactuma.fcm_secreg_mfcb equals fcmcuentacobrms.fcm_secreg_mfcb into tmfcmcuentacobrms
                                   join sisestadoproces in _context.Sisestadoproces on carmaesfactuma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from sitr in tmsismaesterceros.DefaultIfEmpty()
                                   from srfa in tmfcmsecrfacturas.DefaultIfEmpty()
                                   from mfcb in tmfcmcuentacobrms.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where carmaesfactuma.car_nrofac_camf == tcrIdRegistro
                                   select new ModeloCarGenFactDian
                                   {
                                       #region Datos
                                       Car_secfac_camf = carmaesfactuma.car_secfac_camf,
                                       Fcm_typdoc_fctd = carmaesfactuma.fcm_typdoc_fctd,
                                       Car_prnobs_camf = carmaesfactuma.car_prnobs_camf,
                                       Car_observ_camf = carmaesfactuma.car_observ_camf,
                                       Car_prnnot_camf = carmaesfactuma.car_prnnot_camf,
                                       Car_medpag_camf = carmaesfactuma.car_medpag_camf,
                                       Cto_seccon_cont = carmaesfactuma.cto_seccon_cont,
                                       Cto_nrocon_cont = carmaesfactuma.cto_nrocon_cont,
                                       Sia_codeps_teps = carmaesfactuma.sia_codeps_teps,
                                       Sis_idterc_sitr = carmaesfactuma.sis_idterc_sitr,
                                       Fcm_secres_srfa = carmaesfactuma.fcm_secres_srfa,
                                       Fcm_secraz_fcem = carmaesfactuma.fcm_secraz_fcem,
                                       Car_nrofac_camf = carmaesfactuma.car_nrofac_camf,
                                       Car_fecfac_camf = (DateTime)carmaesfactuma.car_fecfac_camf,
                                       Fcm_horfac_camf = (Decimal)carmaesfactuma.fcm_horfac_camf,
                                       Car_diavfa_camf = (int)carmaesfactuma.car_diavfa_camf,
                                       Fcm_valbru_camf = (decimal)carmaesfactuma.fcm_valbru_camf,
                                       Car_valfac_camf = (decimal)carmaesfactuma.car_valfac_camf,
                                       Fcm_codest_fcws = carmaesfactuma.fcm_codest_fcws,
                                       Fcm_valbsi_dfac = (decimal)carmaesfactuma.fcm_valbsi_dfac,
                                       Fcm_valiva_dfac = (decimal)carmaesfactuma.fcm_valiva_dfac,
                                       Fcm_valicd_dfac = (decimal)carmaesfactuma.fcm_valicd_dfac,
                                       Fcm_valica_dfac = (decimal)carmaesfactuma.fcm_valica_dfac,
                                       Fcm_valinc_dfac = (decimal)carmaesfactuma.fcm_valinc_dfac,
                                       Fcm_valrti_dfac = (decimal)carmaesfactuma.fcm_valrti_dfac,
                                       Fcm_valrtf_dfac = (decimal)carmaesfactuma.fcm_valrtf_dfac,
                                       Fcm_valrtc_dfac = (decimal)carmaesfactuma.fcm_valrtc_dfac,
                                       Fcm_valcre_dfac = (decimal)carmaesfactuma.fcm_valcre_dfac,
                                       Fcm_valfth_dfac = (decimal)carmaesfactuma.fcm_valfth_dfac,
                                       Fcm_valtim_dfac = (decimal)carmaesfactuma.fcm_valtim_dfac,
                                       Fcm_valbol_dfac = (decimal)carmaesfactuma.fcm_valbol_dfac,
                                       Fcm_valicr_dfac = (decimal)carmaesfactuma.fcm_valicr_dfac,
                                       Fcm_valicb_dfac = (decimal)carmaesfactuma.fcm_valicb_dfac,
                                       Fcm_valscb_dfac = (decimal)carmaesfactuma.fcm_valscb_dfac,
                                       Fcm_valsco_dfac = (decimal)carmaesfactuma.fcm_valsco_dfac,
                                       Fcm_valftr_dfac = (decimal)carmaesfactuma.fcm_valftr_dfac,
                                       Fcm_metpag_mfac = carmaesfactuma.fcm_metpag_mfac,
                                       Fcm_codmpg_fcmp = carmaesfactuma.fcm_codmpg_fcmp,
                                       Fcm_fecven_mfac = (DateTime)carmaesfactuma.fcm_fecven_mfac,
                                       Car_tipfac_camf = carmaesfactuma.car_tipfac_camf,
                                       Fcm_secreg_mfcb = carmaesfactuma.fcm_secreg_mfcb,
                                       Fcm_numfac_mfac = carmaesfactuma.fcm_numfac_mfac,
                                       Fcm_fecfac_mfac = (DateTime)carmaesfactuma.fcm_fecfac_mfac,
                                       Fcm_valbru_dfac = (decimal)carmaesfactuma.fcm_valbru_dfac,
                                       Fcm_valdes_dfac = (decimal)carmaesfactuma.fcm_valdes_dfac,
                                       Fcm_valcpa_dfac = (decimal)carmaesfactuma.fcm_valcpa_dfac,
                                       Fcm_valfac_dfac = (decimal)carmaesfactuma.fcm_valfac_dfac,
                                       Fcm_sercre_mfac = carmaesfactuma.fcm_sercre_mfac,
                                       Fcm_idrcre_mfac = carmaesfactuma.fcm_idrcre_mfac,
                                       Fcm_serdeb_mfac = carmaesfactuma.fcm_serdeb_mfac,
                                       Fcm_idrdeb_mfac = carmaesfactuma.fcm_idrdeb_mfac,
                                       Sys_codusu_usux = carmaesfactuma.sys_codusu_usux,
                                       Car_conest_camf = (int)carmaesfactuma.car_conest_camf,
                                       Sis_estpro_espr = carmaesfactuma.sis_estpro_espr,
                                       Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                       Fcm_numdoc_fcem = fcem.fcm_numdoc_fcem,
                                       Sia_deseps_teps = teps.sia_deseps_teps,
                                       Sia_codnit_teps = teps.sia_codnit_teps,
                                       Fcm_descue_mfcb = mfcb.fcm_descue_mfcb,
                                       Sis_despro_espr = espr.sis_despro_espr,
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
                                       Sis_emailc_sitr = sitr.sis_emailc_sitr,
                                       Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == carmaesfactuma.cto_seccon_cont).cto_descon_cont,
                                       #endregion
                                   }).FirstOrDefault();
                }
                // Llenar los temporales que complementan la factura
                if (lobConsulta != null)
                {
                    lobConsulta.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", lobConsulta.Car_secfac_camf);
                    if (lobConsulta.lobRegDocDian != null)
                    {
                        lobConsulta.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // Para que el Timer Recargue los datos de la vista
                    }
                }
            }
            return lobConsulta;
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Cuenta de cobro Factura Dian
    /// <summary>
    /// Descripcion para la Vista de  la tabla: carmaesfactumd
    /// </summary>
    public class ModeloCarGenFactDianDe : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Car_secreg_cadf: Codigo unico registro
        private String _car_secreg_cadf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: car_secreg_cadf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial registro
        /// </para>
        /// </summary>
        public String Car_secreg_cadf
        {
            get { return _car_secreg_cadf; }
            set
            {
                if (_car_secreg_cadf == value) return;
                _car_secreg_cadf = value;
                OnPropertyChanged("Car_secreg_cadf");
            }
        }
        #endregion
        #region Car_secfac_camf: Codigo maestro facturas
        private String _car_secfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Codigo maestro facturas</para>
        /// <para>NOMBRE: car_secfac_camf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo relacion con maestro facturas
        /// </para>
        /// </summary>
        public String Car_secfac_camf
        {
            get { return _car_secfac_camf; }
            set
            {
                if (_car_secfac_camf == value) return;
                _car_secfac_camf = value;
                OnPropertyChanged("Car_secfac_camf");
            }
        }
        #endregion
        #region Car_seccon_cacf: Codigo unico concepto
        private String _car_seccon_cacf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Codigo unico concepto</para>
        /// <para>NOMBRE: car_seccon_cacf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo unico del concepto en maestro conceptos de venta (generado por el sistema)</para>
        /// </summary>
        public String Car_seccon_cacf
        {
            get { return _car_seccon_cacf; }
            set
            {
                if (_car_seccon_cacf == value) return;
                _car_seccon_cacf = value;
                OnPropertyChanged("Car_seccon_cacf");
            }
        }
        #endregion
        #region Car_codcon_cacf: Codigo concepto
        private String _car_codcon_cacf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Codigo concepto</para>
        /// <para>NOMBRE: car_codcon_cacf (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo unico del concepto venta según tarifario propio o según UNSPSC</para>
        /// </summary>
        public String Car_codcon_cacf
        {
            get { return _car_codcon_cacf; }
            set
            {
                if (_car_codcon_cacf == value) return;
                _car_codcon_cacf = value;
                OnPropertyChanged("Car_codcon_cacf");
            }
        }
        #endregion
        #region Fcm_codpro_fcpr: Codigo UNSPSC
        private String _fcm_codpro_fcpr;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo UNSPSC</para>
        /// <para>NOMBRE: fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Codigo Producto segun clasificacion UNSPSC</para>
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
        #region Car_descon_cadf: Descripcion concepto
        private String _car_descon_cadf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Descripcion concepto</para>
        /// <para>NOMBRE: car_descon_cadf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion concepto detalle del cobro y valor facturado
        /// </para>
        /// </summary>
        public String Car_descon_cadf
        {
            get { return _car_descon_cadf; }
            set
            {
                if (_car_descon_cadf == value) return;
                _car_descon_cadf = value;
                OnPropertyChanged("Car_descon_cadf");
            }
        }
        #endregion
        #region Car_totuni_cadf: Total unidades
        private int _car_totuni_cadf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: car_totuni_cadf (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Total cantidad del item concepto facturado
        /// </para>
        /// </summary>
        public int Car_totuni_cadf
        {
            get { return _car_totuni_cadf; }
            set
            {
                if (_car_totuni_cadf == value) return;
                _car_totuni_cadf = value;
                OnPropertyChanged("Car_totuni_cadf");
            }
        }
        #endregion
        #region Car_valuni_cadf: Valor unidad
        private decimal _car_valuni_cadf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Valor unidad</para>
        /// <para>NOMBRE: car_valuni_cadf (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Valor unitario del item concepto
        /// </para>
        /// </summary>
        public decimal Car_valuni_cadf
        {
            get { return _car_valuni_cadf; }
            set
            {
                if (_car_valuni_cadf == value) return;
                _car_valuni_cadf = value;
                OnPropertyChanged("Car_valuni_cadf");
            }
        }
        #endregion
        #region Fcm_valbru_dfac: Valor bruto factura
        private decimal _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sis_coddes_side: Codigo descuento
        private String _sis_coddes_side;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo descuento</para>
        /// <para>NOMBRE: sis_coddes_side (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo tarifa  descuento aplicado al prodcuto en venta
        /// </para>
        /// </summary>
        public String Sis_coddes_side
        {
            get { return _sis_coddes_side; }
            set
            {
                if (_sis_coddes_side == value) return;
                _sis_coddes_side = value;
                OnPropertyChanged("Sis_coddes_side");
            }
        }
        #endregion
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private decimal _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        // Valores Impiestos
        #region Fcm_valbsi_dfac: Valor Base impuestos
        private decimal _fcm_valbsi_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: fcm_valbsi_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION: Valor de la base Imponible (base para el calculo de impuesto)</para>
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
        #region Fcm_poriva_dfac: % IVA
        private decimal _fcm_poriva_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Porcentaje aplicación IVA</para>
        /// </summary>
        public decimal Fcm_poriva_dfac
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
        private decimal _fcm_valiva_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Valor del IVA aplicado</para>
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
        #region Fcm_poricd_dfac: % IC - Impuesto consumo
        private decimal _fcm_poricd_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IC - Impuesto consumo</para>
        /// <para>NOMBRE: fcm_poricd_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION: Porcentaje aplicación IC -Impuesto al consumo departamental</para>
        /// </summary>
        public decimal Fcm_poricd_dfac
        {
            get { return _fcm_poricd_dfac; }
            set
            {
                if (_fcm_poricd_dfac == value) return;
                _fcm_poricd_dfac = value;
                OnPropertyChanged("Fcm_poricd_dfac");
            }
        }
        #endregion
        #region Fcm_valicd_dfac: Valor IC Impuesto consumo
        private decimal _fcm_valicd_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: fcm_valicd_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION: Valor del IC - IImpuesto al consumo departamental</para>
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
        #region Fcm_porica_dfac: % ICA
        private decimal _fcm_porica_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ICA</para>
        /// <para>NOMBRE: fcm_porica_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION: Porcentaje aplicación ICA Impuesto de Industria Comercio y Aviso</para>
        /// </summary>
        public decimal Fcm_porica_dfac
        {
            get { return _fcm_porica_dfac; }
            set
            {
                if (_fcm_porica_dfac == value) return;
                _fcm_porica_dfac = value;
                OnPropertyChanged("Fcm_porica_dfac");
            }
        }
        #endregion
        #region Fcm_valica_dfac: Valor ICA
        private decimal _fcm_valica_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: fcm_valica_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION: Valor ICA ICA Impuesto de Industria Comercio y Aviso</para>
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
        #region Fcm_porinc_dfac: % INC - Impuesto Nacional al Consumo
        private decimal _fcm_porinc_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INC - Impuesto Nacional al Consumo</para>
        /// <para>NOMBRE: fcm_porinc_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION: Porcentaje aplicación INC Impuesto Nacional al Consumo</para>
        /// </summary>
        public decimal Fcm_porinc_dfac
        {
            get { return _fcm_porinc_dfac; }
            set
            {
                if (_fcm_porinc_dfac == value) return;
                _fcm_porinc_dfac = value;
                OnPropertyChanged("Fcm_porinc_dfac");
            }
        }
        #endregion
        #region Fcm_valinc_dfac: Valor INC - Impuesto Nacional Consumo
        private decimal _fcm_valinc_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
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
        #region Fcm_porrti_dfac: % RetVA Retención sobre el IVA
        private decimal _fcm_porrti_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: fcm_porrti_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION: Porcentaje aplicación RetVA Retención sobre el IVA</para>
        /// </summary>
        public decimal Fcm_porrti_dfac
        {
            get { return _fcm_porrti_dfac; }
            set
            {
                if (_fcm_porrti_dfac == value) return;
                _fcm_porrti_dfac = value;
                OnPropertyChanged("Fcm_porrti_dfac");
            }
        }
        #endregion
        #region Fcm_valrti_dfac: Valor RetVA Retención sobre el IVA
        private decimal _fcm_valrti_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: fcm_valrti_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION: Valor RetVA Retención sobre el IVA</para>
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
        #region Fcm_porrtf_dfac: %ReteFuente
        private decimal _fcm_porrtf_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: %ReteFuente</para>
        /// <para>NOMBRE: fcm_porrtf_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION: Porcentaje aplicación ReteFuente (reteción en la fuente)</para>
        /// </summary>
        public decimal Fcm_porrtf_dfac
        {
            get { return _fcm_porrtf_dfac; }
            set
            {
                if (_fcm_porrtf_dfac == value) return;
                _fcm_porrtf_dfac = value;
                OnPropertyChanged("Fcm_porrtf_dfac");
            }
        }
        #endregion
        #region Fcm_valrtf_dfac: Valor ReteFuente
        private decimal _fcm_valrtf_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: fcm_valrtf_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION: Valor ReteFuente (reteción en la fuente)</para>
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
        #region Fcm_porrtc_dfac: % ReteICA
        private decimal _fcm_porrtc_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteICA</para>
        /// <para>NOMBRE: fcm_porrtc_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION: Porcentaje aplicación ReteICA</para>
        /// </summary>
        public decimal Fcm_porrtc_dfac
        {
            get { return _fcm_porrtc_dfac; }
            set
            {
                if (_fcm_porrtc_dfac == value) return;
                _fcm_porrtc_dfac = value;
                OnPropertyChanged("Fcm_porrtc_dfac");
            }
        }
        #endregion
        #region Fcm_valrtc_dfac: Valor ReteICA
        private decimal _fcm_valrtc_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: fcm_valrtc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION: Valor del ReteICA aplicado</para>
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
        #region Fcm_porcre_dfac: % ReteCREE
        private decimal _fcm_porcre_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteCREE</para>
        /// <para>NOMBRE: fcm_porcre_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION: Porcentaje aplicación ReteCree</para>
        /// </summary>
        public decimal Fcm_porcre_dfac
        {
            get { return _fcm_porcre_dfac; }
            set
            {
                if (_fcm_porcre_dfac == value) return;
                _fcm_porcre_dfac = value;
                OnPropertyChanged("Fcm_porcre_dfac");
            }
        }
        #endregion
        #region Fcm_valcre_dfac: VAaor RedCREE
        private decimal _fcm_valcre_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: VAaor RedCREE</para>
        /// <para>NOMBRE: fcm_valcre_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION: Valor del ReteCRE aplicado</para>
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
        #region Fcm_porfth_dfac: % FtoHorticultura
        private decimal _fcm_porfth_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % FtoHorticultura</para>
        /// <para>NOMBRE: fcm_porfth_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION: Porcentaje aplicación FtoHorticultura</para>
        /// </summary>
        public decimal Fcm_porfth_dfac
        {
            get { return _fcm_porfth_dfac; }
            set
            {
                if (_fcm_porfth_dfac == value) return;
                _fcm_porfth_dfac = value;
                OnPropertyChanged("Fcm_porfth_dfac");
            }
        }
        #endregion
        #region Fcm_valfth_dfac: Valor FtoHorticultura
        private decimal _fcm_valfth_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: fcm_valfth_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION: Valor del FtoHorticultura aplicado</para>
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
        #region Fcm_portim_dfac: % Timbre
        private decimal _fcm_portim_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Timbre</para>
        /// <para>NOMBRE: fcm_portim_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION: Porcentaje aplicación Timbre</para>
        /// </summary>
        public decimal Fcm_portim_dfac
        {
            get { return _fcm_portim_dfac; }
            set
            {
                if (_fcm_portim_dfac == value) return;
                _fcm_portim_dfac = value;
                OnPropertyChanged("Fcm_portim_dfac");
            }
        }
        #endregion
        #region Fcm_valtim_dfac: Valor Timbre
        private decimal _fcm_valtim_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: fcm_valtim_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION: Valor del Timbre aplicado</para>
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
        #region Fcm_porbol_dfac: % Bolsas
        private decimal _fcm_porbol_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Bolsas</para>
        /// <para>NOMBRE: fcm_porbol_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION: Porcentaje aplicación Bolsas</para>
        /// </summary>
        public decimal Fcm_porbol_dfac
        {
            get { return _fcm_porbol_dfac; }
            set
            {
                if (_fcm_porbol_dfac == value) return;
                _fcm_porbol_dfac = value;
                OnPropertyChanged("Fcm_porbol_dfac");
            }
        }
        #endregion
        #region Fcm_valbol_dfac: Valor Impuesto Bolsas
        private decimal _fcm_valbol_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: fcm_valbol_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION: Valor Impuesto Bolsas aplicado</para>
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
        #region Fcm_poricr_dfac: % INCarbono
        private decimal _fcm_poricr_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCarbono</para>
        /// <para>NOMBRE: fcm_poricr_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION: Porcentaje aplicación INCarbono</para>
        /// </summary>
        public decimal Fcm_poricr_dfac
        {
            get { return _fcm_poricr_dfac; }
            set
            {
                if (_fcm_poricr_dfac == value) return;
                _fcm_poricr_dfac = value;
                OnPropertyChanged("Fcm_poricr_dfac");
            }
        }
        #endregion
        #region Fcm_valicr_dfac: Valor INCarbono
        private decimal _fcm_valicr_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: fcm_valicr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION: Valor del INCarbono aplicado</para>
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
        #region Fcm_poricb_dfac: % INCombustibles
        private decimal _fcm_poricb_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCombustibles</para>
        /// <para>NOMBRE: fcm_poricb_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION: Porcentaje aplicado INCombustibles</para>
        /// </summary>
        public decimal Fcm_poricb_dfac
        {
            get { return _fcm_poricb_dfac; }
            set
            {
                if (_fcm_poricb_dfac == value) return;
                _fcm_poricb_dfac = value;
                OnPropertyChanged("Fcm_poricb_dfac");
            }
        }
        #endregion
        #region Fcm_valicb_dfac: Valor INCombustibles
        private decimal _fcm_valicb_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: fcm_valicb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION: Valor del INCombustibles aplicado</para>
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
        #region Fcm_porscb_dfac: % Sobretasa Combustibles
        private decimal _fcm_porscb_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_porscb_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION: Porcentaje aplicación Sobretasa Combustibles </para>
        /// </summary>
        public decimal Fcm_porscb_dfac
        {
            get { return _fcm_porscb_dfac; }
            set
            {
                if (_fcm_porscb_dfac == value) return;
                _fcm_porscb_dfac = value;
                OnPropertyChanged("Fcm_porscb_dfac");
            }
        }
        #endregion
        #region Fcm_valscb_dfac: Valor Sobretasa Combustibles
        private decimal _fcm_valscb_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_valscb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION: Valor de Sobretasa Combustibles aplicado</para>
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
        #region Fcm_porsco_dfac: % Sordicom
        private decimal _fcm_porsco_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sordicom</para>
        /// <para>NOMBRE: fcm_porsco_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION: Porcentaje aplicación Sordicom </para>
        /// </summary>
        public decimal Fcm_porsco_dfac
        {
            get { return _fcm_porsco_dfac; }
            set
            {
                if (_fcm_porsco_dfac == value) return;
                _fcm_porsco_dfac = value;
                OnPropertyChanged("Fcm_porsco_dfac");
            }
        }
        #endregion
        #region Fcm_valsco_dfac: Valor Sordicom
        private decimal _fcm_valsco_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: fcm_valsco_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION: Valor del Sordicom aplicado</para>
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
        #region Fcm_porftr_dfac: % Figura tributaria
        private decimal _fcm_porftr_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Figura tributaria</para>
        /// <para>NOMBRE: fcm_porftr_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION: Porcentaje aplicación figura tributaria</para>
        /// </summary>
        public decimal Fcm_porftr_dfac
        {
            get { return _fcm_porftr_dfac; }
            set
            {
                if (_fcm_porftr_dfac == value) return;
                _fcm_porftr_dfac = value;
                OnPropertyChanged("Fcm_porftr_dfac");
            }
        }
        #endregion
        #region Fcm_valftr_dfac: Figura tributaria aplicada
        private decimal _fcm_valftr_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Figura tributaria aplicada</para>
        /// <para>NOMBRE: fcm_valftr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCIÓN: Valor figura tributaria aplicada</para>
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
        // Valores Totales
        #region Fcm_subtot_dfac: Valor subtotal
        private decimal _fcm_subtot_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal</para>
        /// <para>NOMBRE: fcm_subtot_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:Valor subtotal del registro item</para>
        /// </summary>
        public decimal Fcm_subtot_dfac
        {
            get { return _fcm_subtot_dfac; }
            set
            {
                if (_fcm_subtot_dfac == value) return;
                _fcm_subtot_dfac = value;
                OnPropertyChanged("Fcm_subtot_dfac");
            }
        }
        #endregion
        #region Fcm_valfac_dfac: Valor total facturado
        private decimal _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        #region Car_observ_camf: Observacion
        private String _car_observ_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: car_observ_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nota de Observación
        /// </para>
        /// </summary>
        public String Car_observ_camf
        {
            get { return _car_observ_camf; }
            set
            {
                if (_car_observ_camf == value) return;
                _car_observ_camf = value;
                OnPropertyChanged("Car_observ_camf");
            }
        }
        #endregion
        #region Car_descon_cacf: Descripcion concepto
        private String _car_descon_cacf;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Descripcion concepto</para>
        /// <para>NOMBRE: car_descon_cacf (char:170)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del concepto de venta facturacion
        /// </para>
        /// </summary>
        public String Car_descon_cacf
        {
            get { return _car_descon_cacf; }
            set
            {
                if (_car_descon_cacf == value) return;
                _car_descon_cacf = value;
                OnPropertyChanged("Car_descon_cacf");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private String _sis_estado_imaen;
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
        #region Car_difac_cadf: Diferencia Factura
        private String _car_difac_cadf;
        /// <summary>
        /// Diferencia entre el valor de los datos en la grilla
        /// con el valor de la factura
        /// </para>
        /// </summary>
        public String Car_difac_cadf
        {
            get { return _car_difac_cadf; }
            set
            {
                if (_car_difac_cadf == value) return;
                _car_difac_cadf = value;
                OnPropertyChanged("Car_difac_cadf");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloCarGenFactDianDe tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFcarmaesfactumd();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tobTempReg.Car_secreg_cadf);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.car_secreg_cadf = tobTempReg.Car_secreg_cadf;
                            lobEFReg.car_secfac_camf = tobTempReg.Car_secfac_camf;
                            lobEFReg.car_seccon_cacf = tobTempReg.Car_seccon_cacf;
                            lobEFReg.car_codcon_cacf = tobTempReg.Car_codcon_cacf;
                            lobEFReg.fcm_codpro_fcpr = tobTempReg.Fcm_codpro_fcpr;
                            lobEFReg.car_descon_cadf = tobTempReg.Car_descon_cadf;
                            lobEFReg.car_totuni_cadf = (int)tobTempReg.Car_totuni_cadf;
                            lobEFReg.car_valuni_cadf = (decimal)tobTempReg.Car_valuni_cadf;
                            lobEFReg.fcm_valbru_dfac = (decimal)tobTempReg.Fcm_valbru_dfac;
                            lobEFReg.sis_coddes_side = tobTempReg.Sis_coddes_side;
                            lobEFReg.fcm_pordes_dfac = (decimal)tobTempReg.Fcm_pordes_dfac;
                            lobEFReg.fcm_valdes_dfac = (decimal)tobTempReg.Fcm_valdes_dfac;
                            lobEFReg.fcm_valbsi_dfac = (decimal)tobTempReg.Fcm_valbsi_dfac;
                            lobEFReg.fcm_poriva_dfac = (decimal)tobTempReg.Fcm_poriva_dfac;
                            lobEFReg.fcm_valiva_dfac = (decimal)tobTempReg.Fcm_valiva_dfac;
                            lobEFReg.fcm_poricd_dfac = (decimal)tobTempReg.Fcm_poricd_dfac;
                            lobEFReg.fcm_valicd_dfac = (decimal)tobTempReg.Fcm_valicd_dfac;
                            lobEFReg.fcm_porica_dfac = (decimal)tobTempReg.Fcm_porica_dfac;
                            lobEFReg.fcm_valica_dfac = (decimal)tobTempReg.Fcm_valica_dfac;
                            lobEFReg.fcm_porinc_dfac = (decimal)tobTempReg.Fcm_porinc_dfac;
                            lobEFReg.fcm_valinc_dfac = (decimal)tobTempReg.Fcm_valinc_dfac;
                            lobEFReg.fcm_porrti_dfac = (decimal)tobTempReg.Fcm_porrti_dfac;
                            lobEFReg.fcm_valrti_dfac = (decimal)tobTempReg.Fcm_valrti_dfac;
                            lobEFReg.fcm_porrtf_dfac = (decimal)tobTempReg.Fcm_porrtf_dfac;
                            lobEFReg.fcm_valrtf_dfac = (decimal)tobTempReg.Fcm_valrtf_dfac;
                            lobEFReg.fcm_porrtc_dfac = (decimal)tobTempReg.Fcm_porrtc_dfac;
                            lobEFReg.fcm_valrtc_dfac = (decimal)tobTempReg.Fcm_valrtc_dfac;
                            lobEFReg.fcm_porcre_dfac = (decimal)tobTempReg.Fcm_porcre_dfac;
                            lobEFReg.fcm_valcre_dfac = (decimal)tobTempReg.Fcm_valcre_dfac;
                            lobEFReg.fcm_porfth_dfac = (decimal)tobTempReg.Fcm_porfth_dfac;
                            lobEFReg.fcm_valfth_dfac = (decimal)tobTempReg.Fcm_valfth_dfac;
                            lobEFReg.fcm_portim_dfac = (decimal)tobTempReg.Fcm_portim_dfac;
                            lobEFReg.fcm_valtim_dfac = (decimal)tobTempReg.Fcm_valtim_dfac;
                            lobEFReg.fcm_porbol_dfac = (decimal)tobTempReg.Fcm_porbol_dfac;
                            lobEFReg.fcm_valbol_dfac = (decimal)tobTempReg.Fcm_valbol_dfac;
                            lobEFReg.fcm_poricr_dfac = (decimal)tobTempReg.Fcm_poricr_dfac;
                            lobEFReg.fcm_valicr_dfac = (decimal)tobTempReg.Fcm_valicr_dfac;
                            lobEFReg.fcm_poricb_dfac = (decimal)tobTempReg.Fcm_poricb_dfac;
                            lobEFReg.fcm_valicb_dfac = (decimal)tobTempReg.Fcm_valicb_dfac;
                            lobEFReg.fcm_porscb_dfac = (decimal)tobTempReg.Fcm_porscb_dfac;
                            lobEFReg.fcm_valscb_dfac = (decimal)tobTempReg.Fcm_valscb_dfac;
                            lobEFReg.fcm_porsco_dfac = (decimal)tobTempReg.Fcm_porsco_dfac;
                            lobEFReg.fcm_valsco_dfac = (decimal)tobTempReg.Fcm_valsco_dfac;
                            lobEFReg.fcm_porftr_dfac = (decimal)tobTempReg.Fcm_porftr_dfac;
                            lobEFReg.fcm_valftr_dfac = (decimal)tobTempReg.Fcm_valftr_dfac;
                            lobEFReg.fcm_subtot_dfac = (decimal)tobTempReg.Fcm_subtot_dfac;
                            lobEFReg.fcm_valfac_dfac = (decimal)tobTempReg.Fcm_valfac_dfac;
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
                                lobEFReg.car_secreg_cadf = tcrCodigoR1 + lobEFReg.car_secreg_cadf; // concatenar
                                _context.AddToCarmaesfactumd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tobTempReg.Car_secreg_cadf);
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
        #region Buscar CARMAESFACTUMD: Logica
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TITULO: Detalles conceptos y valores facturados</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles y valores de cobro facturacion para generar
        /// facturas con secuencial DIAN
        /// </para>
        /// </summary>
        public static bool flgBuscarCarmaesfactumd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCarGenFactDianDe> FlsListaCarmaesfactumd(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from carmaesfactumd in _context.Carmaesfactumd
                                  join carconceptfact in _context.Carconceptfact on carmaesfactumd.car_codcon_cacf equals carconceptfact.car_codcon_cacf into tmcarconceptfact
                                  join sisestadoproces in _context.Sisestadoproces on carmaesfactumd.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from cacf in tmcarconceptfact.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where carmaesfactumd.car_secfac_camf == tcrBuscar
                                  select new ModeloCarGenFactDianDe
                                  {
                                      Car_secreg_cadf = carmaesfactumd.car_secreg_cadf,
                                      Car_secfac_camf = carmaesfactumd.car_secfac_camf,
                                      Car_seccon_cacf = carmaesfactumd.car_seccon_cacf,
                                      Car_codcon_cacf = carmaesfactumd.car_codcon_cacf,
                                      Fcm_codpro_fcpr = carmaesfactumd.fcm_codpro_fcpr,
                                      Car_descon_cadf = carmaesfactumd.car_descon_cadf,
                                      Car_totuni_cadf = (int)carmaesfactumd.car_totuni_cadf,
                                      Car_valuni_cadf = (decimal)carmaesfactumd.car_valuni_cadf,
                                      Fcm_valbru_dfac = (decimal)carmaesfactumd.fcm_valbru_dfac,
                                      Sis_coddes_side = carmaesfactumd.sis_coddes_side,
                                      Fcm_pordes_dfac = (decimal)carmaesfactumd.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (decimal)carmaesfactumd.fcm_valdes_dfac,
                                      Fcm_valbsi_dfac = (decimal)carmaesfactumd.fcm_valbsi_dfac,
                                      Fcm_poriva_dfac = (decimal)carmaesfactumd.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (decimal)carmaesfactumd.fcm_valiva_dfac,
                                      Fcm_poricd_dfac = (decimal)carmaesfactumd.fcm_poricd_dfac,
                                      Fcm_valicd_dfac = (decimal)carmaesfactumd.fcm_valicd_dfac,
                                      Fcm_porica_dfac = (decimal)carmaesfactumd.fcm_porica_dfac,
                                      Fcm_valica_dfac = (decimal)carmaesfactumd.fcm_valica_dfac,
                                      Fcm_porinc_dfac = (decimal)carmaesfactumd.fcm_porinc_dfac,
                                      Fcm_valinc_dfac = (decimal)carmaesfactumd.fcm_valinc_dfac,
                                      Fcm_porrti_dfac = (decimal)carmaesfactumd.fcm_porrti_dfac,
                                      Fcm_valrti_dfac = (decimal)carmaesfactumd.fcm_valrti_dfac,
                                      Fcm_porrtf_dfac = (decimal)carmaesfactumd.fcm_porrtf_dfac,
                                      Fcm_valrtf_dfac = (decimal)carmaesfactumd.fcm_valrtf_dfac,
                                      Fcm_porrtc_dfac = (decimal)carmaesfactumd.fcm_porrtc_dfac,
                                      Fcm_valrtc_dfac = (decimal)carmaesfactumd.fcm_valrtc_dfac,
                                      Fcm_porcre_dfac = (decimal)carmaesfactumd.fcm_porcre_dfac,
                                      Fcm_valcre_dfac = (decimal)carmaesfactumd.fcm_valcre_dfac,
                                      Fcm_porfth_dfac = (decimal)carmaesfactumd.fcm_porfth_dfac,
                                      Fcm_valfth_dfac = (decimal)carmaesfactumd.fcm_valfth_dfac,
                                      Fcm_portim_dfac = (decimal)carmaesfactumd.fcm_portim_dfac,
                                      Fcm_valtim_dfac = (decimal)carmaesfactumd.fcm_valtim_dfac,
                                      Fcm_porbol_dfac = (decimal)carmaesfactumd.fcm_porbol_dfac,
                                      Fcm_valbol_dfac = (decimal)carmaesfactumd.fcm_valbol_dfac,
                                      Fcm_poricr_dfac = (decimal)carmaesfactumd.fcm_poricr_dfac,
                                      Fcm_valicr_dfac = (decimal)carmaesfactumd.fcm_valicr_dfac,
                                      Fcm_poricb_dfac = (decimal)carmaesfactumd.fcm_poricb_dfac,
                                      Fcm_valicb_dfac = (decimal)carmaesfactumd.fcm_valicb_dfac,
                                      Fcm_porscb_dfac = (decimal)carmaesfactumd.fcm_porscb_dfac,
                                      Fcm_valscb_dfac = (decimal)carmaesfactumd.fcm_valscb_dfac,
                                      Fcm_porsco_dfac = (decimal)carmaesfactumd.fcm_porsco_dfac,
                                      Fcm_valsco_dfac = (decimal)carmaesfactumd.fcm_valsco_dfac,
                                      Fcm_porftr_dfac = (decimal)carmaesfactumd.fcm_porftr_dfac,
                                      Fcm_valftr_dfac = (decimal)carmaesfactumd.fcm_valftr_dfac,
                                      Fcm_subtot_dfac = (decimal)carmaesfactumd.fcm_subtot_dfac,
                                      Fcm_valfac_dfac = (decimal)carmaesfactumd.fcm_valfac_dfac,
                                      Sis_estpro_espr = carmaesfactumd.sis_estpro_espr,
                                      Car_descon_cacf = cacf.car_descon_cacf,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
}

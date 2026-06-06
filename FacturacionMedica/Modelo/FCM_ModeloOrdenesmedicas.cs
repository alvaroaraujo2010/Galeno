//- MARMOTA-GENCODE: VERSION 2.0 - 29/06/2013 07:31:05 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace FacturacionMedica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaesfacturas
    /// </summary>
    public class ModeloResumenFacturacion : clBaseInpc
    {
        #region Modelo Propiedades Notificacion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
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
        private String _cto_nrocon_cont;
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
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
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
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
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
        #region Fcm_valbru_dfac: Valor bruto factura
        private float _fcm_valbru_dfac;
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
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private float _fcm_pordes_dfac;
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
        private float _fcm_valdes_dfac;
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
        private float _fcm_poriva_dfac;
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
        private float _fcm_valiva_dfac; 
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
        private float _fcm_valcpa_dfac;
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
        private float _fcm_valcmo_dfac;
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
        private float _fcm_valusu_dfac;
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
        private float _fcm_valcom_dfac;
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
        private float _fcm_valsub_dfac;
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
        private float _fcm_valfac_dfac;
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
        private float _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        private float _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        #region Sia_tipact_tsac: Tipo servicio o activiad
        private String _sia_tipact_tsac;
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
        #region Sia_desact_tsac: Descripcion tipo servicio o actividad
        private String _sia_desact_tsac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o actividad</para>
        /// <para>NOMBRE: sia_desact_tsac (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Tipo servico o actividad de salud 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas        
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
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 10/08/2020 08:48:15 PM
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

namespace Sistema.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmfemaesfactefmd
    /// </summary>
    public class ModeloFeFacturaMd : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_dfac: Código Único registro
        private String _fcm_secreg_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
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
        #region Fcm_secreg_mfac: Codigo unico facturacion
        private String _fcm_secreg_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo unico facturacion</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Secuencial unico de la orden Factura-Nota Debito-Nota-Credito (generado por el sistema)</para>
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
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Fcm_idesec_mant: Codigo unico tarifario
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Codigo unico del servicio para venta con manual tarifario (generado por el sistema)</para>
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
        #region Fcm_codpro_fcpr: Codigo UNSPSC
        private String _fcm_codpro_fcpr;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Codigo UNSPSC</para>
        /// <para>NOMBRE: fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Fcm_codbar_mant: Código de Barras
        private String _fcm_codbar_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_mant (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public String Fcm_codbar_mant
        {
            get { return _fcm_codbar_mant; }
            set
            {
                if (_fcm_codbar_mant == value) return;
                _fcm_codbar_mant = value;
                OnPropertyChanged("Fcm_codbar_mant");
            }
        }
        #endregion
        #region Fcm_tiptar_dfac: Tipo Tarifario usado
        private String _fcm_tiptar_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Tipo Tarifario usado</para>
        /// <para>NOMBRE: fcm_tiptar_dfac (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo codigo usado en Tarifario de venta servicios o productos: 001= UNSPSC Codificacion Colombiaa
        /// compra Eficiente 010 = GTIN Numeros Globales  Identificacion Productos 020 = Partida Arancelaria
        /// 999=Esntandar Propio Adoptado por el contribuyente
        /// </para>
        /// </summary>
        public String Fcm_tiptar_dfac
        {
            get { return _fcm_tiptar_dfac; }
            set
            {
                if (_fcm_tiptar_dfac == value) return;
                _fcm_tiptar_dfac = value;
                OnPropertyChanged("Fcm_tiptar_dfac");
            }
        }
        #endregion
        #region Fcm_codser_mant: Codigo servicio o producto
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Codigo servicio</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio o producto según estandar propio del contribuyente:
        /// schemeID = 999  campo: FAZ10 Resolucion facturacion eletronica DIAN </para>
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
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Fcm_codman_mans: Código tarifario
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifama</para>
        /// <para>CAMPO: Código tarifario</para>
        /// <para>NOMBRE: fcm_codman_mans (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios configurados para
        /// ventas ejm: M01=Ventas a particulares  M02=Manual para ventas
        /// empresas contratistas
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
        #region Fcm_desser_dfac: Descripcion servicio
        private String _fcm_desser_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Descripcion servicio</para>
        /// <para>NOMBRE: fcm_desser_dfac (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION: Descripcion textual del servicio o producto para incluir en la factura</para>
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
        #region Fcm_fecser_dfac: Fecha servicio
        private DateTime _fcm_fecser_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: fcm_fecser_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Fecha de prestacion del servicio o fecha venta del producto
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
        private Decimal _fcm_horser_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Hora Digitación</para>
        /// <para>NOMBRE: fcm_horser_dfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Fcm_valser_mant: Valor de servicio
        private decimal _fcm_valser_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public decimal Fcm_valser_mant
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
        private int _fcm_totuni_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        private decimal _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Fcm_valbsi_dfac: Valor Base impuestos
        private decimal _fcm_valbsi_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: fcm_valbsi_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Valor de la base Imponible (base para el calculo de impuesto)
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación IVA
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region Fcm_poricd_dfac: % IC - Impuesto consumo
        private decimal _fcm_poricd_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IC - Impuesto consumo</para>
        /// <para>NOMBRE: fcm_poricd_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Porcentaje aplicación IC -Impuesto al consumo departamental
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: fcm_valicd_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region Fcm_porica_dfac: % ICA
        private decimal _fcm_porica_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ICA</para>
        /// <para>NOMBRE: fcm_porica_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Porcentaje aplicación ICA Impuesto de Industria Comercio y
        /// Aviso
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: fcm_valica_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        #region Fcm_porinc_dfac: % INC - Impuesto Nacional al Consumo
        private decimal _fcm_porinc_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INC - Impuesto Nacional al Consumo</para>
        /// <para>NOMBRE: fcm_porinc_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación INC Impuesto Nacional al Consumo
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INC - Impuesto Nacional Consumo</para>
        /// <para>NOMBRE: fcm_valinc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: fcm_porrti_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación RetVA Retención sobre el IVA
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
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
        #region Fcm_porrtf_dfac: %ReteFuente
        private decimal _fcm_porrtf_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: %ReteFuente</para>
        /// <para>NOMBRE: fcm_porrtf_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación ReteFuente (reteción en la fuente)
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: fcm_valrtf_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        #region Fcm_porrtc_dfac: % ReteICA
        private decimal _fcm_porrtc_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteICA</para>
        /// <para>NOMBRE: fcm_porrtc_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación ReteICA
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: fcm_valrtc_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
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
        #region Fcm_porcre_dfac: % ReteCREE
        private decimal _fcm_porcre_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteCREE</para>
        /// <para>NOMBRE: fcm_porcre_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación ReteCree
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
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
        #region Fcm_porfth_dfac: % FtoHorticultura
        private decimal _fcm_porfth_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % FtoHorticultura</para>
        /// <para>NOMBRE: fcm_porfth_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación FtoHorticultura
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: fcm_valfth_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
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
        #region Fcm_portim_dfac: % Timbre
        private decimal _fcm_portim_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Timbre</para>
        /// <para>NOMBRE: fcm_portim_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación Timbre
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: fcm_valtim_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
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
        #region Fcm_porbol_dfac: % Bolsas
        private decimal _fcm_porbol_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Bolsas</para>
        /// <para>NOMBRE: fcm_porbol_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación Bolsas
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: fcm_valbol_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        #region Fcm_poricr_dfac: % INCarbono
        private decimal _fcm_poricr_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCarbono</para>
        /// <para>NOMBRE: fcm_poricr_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación INCarbono
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: fcm_valicr_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        #region Fcm_poricb_dfac: % INCombustibles
        private decimal _fcm_poricb_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCombustibles</para>
        /// <para>NOMBRE: fcm_poricb_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicado INCombustibles
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: fcm_valicb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
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
        #region Fcm_porscb_dfac: % Sobretasa Combustibles
        private decimal _fcm_porscb_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_porscb_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación Sobretasa Combustibles
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: fcm_valscb_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
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
        #region Fcm_porsco_dfac: % Sordicom
        private decimal _fcm_porsco_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sordicom</para>
        /// <para>NOMBRE: fcm_porsco_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación Sordicom
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: fcm_valsco_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        #region Fcm_porftr_dfac: % Figura tributaria
        private decimal _fcm_porftr_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Figura tributaria</para>
        /// <para>NOMBRE: fcm_porftr_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Porcentaje aplicación figura tributaria
        /// </para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
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
        // Totales
        #region Sis_coddes_side: Codigo descuento
        private String _sis_coddes_side;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo descuento</para>
        /// <para>NOMBRE: sis_coddes_side (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
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
        #region Fcm_valsub_dfac: Valor subtotal servicio
        private decimal _fcm_valsub_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
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
        #region Fcm_valref_dfac: Valor en efectivo
        private decimal _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
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
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: fcm_valefe_dfac (decimal:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
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
        #region Fcm_despro_mant: Nombre producto
        private String _fcm_despro_mant;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifamd</para>
        /// <para>CAMPO: Nombre producto</para>
        /// <para>NOMBRE: fcm_despro_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public String Fcm_despro_mant
        {
            get { return _fcm_despro_mant; }
            set
            {
                if (_fcm_despro_mant == value) return;
                _fcm_despro_mant = value;
                OnPropertyChanged("Fcm_despro_mant");
            }
        }
        #endregion
        #region Fcm_desman_mans: Manual tarifario
        private String _fcm_desman_mans;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfemaestarifama</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region Sis_codume_sium: Código Unidad Medida
        private String _sis_codume_sium;
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Unidad Medida</para>
        /// <para>NOMBRE: sis_codume_sium (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Código unidad de medida</para>
        /// </summary>
        public String Sis_codume_sium
        {
            get { return _sis_codume_sium; }
            set
            {
                if (_sis_codume_sium == value) return;
                _sis_codume_sium = value;
                OnPropertyChanged("Sis_codume_sium");
            }
        }
        #endregion
        #region Fcm_despro_fcpr: Descripcion Producto
        private String _fcm_despro_fcpr;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Descripcion Producto</para>
        /// <para>NOMBRE: fcm_despro_fcpr (char:120)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Descripcion UNSPSC para el producto </para>
        /// </summary>
        public String Fcm_despro_fcpr
        {
            get { return _fcm_despro_fcpr; }
            set
            {
                if (_fcm_despro_fcpr == value) return;
                _fcm_despro_fcpr = value;
                OnPropertyChanged("Fcm_despro_fcpr");
            }
        }
        #endregion
        #region Fcm_desser_mant: Nombre servicio
        private String _fcm_desser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public String Fcm_desser_mant
        {
            get { return _fcm_desser_mant; }
            set
            {
                if (_fcm_desser_mant == value) return;
                _fcm_desser_mant = value;
                OnPropertyChanged("Fcm_desser_mant");
            }
        }
        #endregion

        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFeFacturaMd tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMFEMAESFACTEFMD", "FCM", "Detalles servicios - productos en cada factura digitada");
            try
            {
                if (!flgBuscarFcmfemaesfactefmd(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmfemaesfactefmd
                        {
                            #region cargar Registro
                            fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac,
                            fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_idesec_mant = tobjModelo.Fcm_idesec_mant,
                            fcm_codpro_fcpr = tobjModelo.Fcm_codpro_fcpr,
                            fcm_codbar_mant = tobjModelo.Fcm_codbar_mant,
                            fcm_tiptar_dfac = tobjModelo.Fcm_tiptar_dfac,
                            fcm_codser_mant = tobjModelo.Fcm_codser_mant,
                            fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                            fcm_codman_mans = tobjModelo.Fcm_codman_mans,
                            fcm_desser_dfac = tobjModelo.Fcm_desser_dfac,
                            fcm_fecser_dfac = tobjModelo.Fcm_fecser_dfac,
                            fcm_horser_dfac = tobjModelo.Fcm_horser_dfac,
                            fcm_valser_mant = tobjModelo.Fcm_valser_mant,
                            fcm_totuni_dfac = tobjModelo.Fcm_totuni_dfac,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_valbsi_dfac = tobjModelo.Fcm_valbsi_dfac,
                            fcm_poriva_dfac = tobjModelo.Fcm_poriva_dfac,
                            fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac,
                            fcm_poricd_dfac = tobjModelo.Fcm_poricd_dfac,
                            fcm_valicd_dfac = tobjModelo.Fcm_valicd_dfac,
                            fcm_porica_dfac = tobjModelo.Fcm_porica_dfac,
                            fcm_valica_dfac = tobjModelo.Fcm_valica_dfac,
                            fcm_porinc_dfac = tobjModelo.Fcm_porinc_dfac,
                            fcm_valinc_dfac = tobjModelo.Fcm_valinc_dfac,
                            fcm_porrti_dfac = tobjModelo.Fcm_porrti_dfac,
                            fcm_valrti_dfac = tobjModelo.Fcm_valrti_dfac,
                            fcm_porrtf_dfac = tobjModelo.Fcm_porrtf_dfac,
                            fcm_valrtf_dfac = tobjModelo.Fcm_valrtf_dfac,
                            fcm_porrtc_dfac = tobjModelo.Fcm_porrtc_dfac,
                            fcm_valrtc_dfac = tobjModelo.Fcm_valrtc_dfac,
                            fcm_porcre_dfac = tobjModelo.Fcm_porcre_dfac,
                            fcm_valcre_dfac = tobjModelo.Fcm_valcre_dfac,
                            fcm_porfth_dfac = tobjModelo.Fcm_porfth_dfac,
                            fcm_valfth_dfac = tobjModelo.Fcm_valfth_dfac,
                            fcm_portim_dfac = tobjModelo.Fcm_portim_dfac,
                            fcm_valtim_dfac = tobjModelo.Fcm_valtim_dfac,
                            fcm_porbol_dfac = tobjModelo.Fcm_porbol_dfac,
                            fcm_valbol_dfac = tobjModelo.Fcm_valbol_dfac,
                            fcm_poricr_dfac = tobjModelo.Fcm_poricr_dfac,
                            fcm_valicr_dfac = tobjModelo.Fcm_valicr_dfac,
                            fcm_poricb_dfac = tobjModelo.Fcm_poricb_dfac,
                            fcm_valicb_dfac = tobjModelo.Fcm_valicb_dfac,
                            fcm_porscb_dfac = tobjModelo.Fcm_porscb_dfac,
                            fcm_valscb_dfac = tobjModelo.Fcm_valscb_dfac,
                            fcm_porsco_dfac = tobjModelo.Fcm_porsco_dfac,
                            fcm_valsco_dfac = tobjModelo.Fcm_valsco_dfac,
                            fcm_porftr_dfac = tobjModelo.Fcm_porftr_dfac,
                            fcm_valftr_dfac = tobjModelo.Fcm_valftr_dfac,
                            sis_coddes_side = tobjModelo.Sis_coddes_side,
                            fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                            fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.fcm_secreg_dfac = lcrCodigoGen;
                        _context.AddToFcmfemaesfactefmd(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMFEMAESFACTEFMD': Detalles servicios - productos en cada factura digitada en Maestro Secuenciales.");
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
        /// Adicionar o Modificar Registro, se utiliza para generar desde los modulos que llaman
        /// factura electronica
        /// </summary>
        /// <param name="tobjModelo">Registro maestro para generar datos en la tabla</param>
        public static void FcvActualizar(ModeloFeFacturaMd tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmfemaesfactefmd.FirstOrDefault(p => p.fcm_secreg_dfac == tobjModelo.Fcm_secreg_dfac);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac;
                        lobjRegistro.fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac;
                        lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                        lobjRegistro.fcm_idesec_mant = tobjModelo.Fcm_idesec_mant;
                        lobjRegistro.fcm_codpro_fcpr = tobjModelo.Fcm_codpro_fcpr;
                        lobjRegistro.fcm_codbar_mant = tobjModelo.Fcm_codbar_mant;
                        lobjRegistro.fcm_tiptar_dfac = tobjModelo.Fcm_tiptar_dfac;
                        lobjRegistro.fcm_codser_mant = tobjModelo.Fcm_codser_mant;
                        lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                        lobjRegistro.fcm_codman_mans = tobjModelo.Fcm_codman_mans;
                        lobjRegistro.fcm_desser_dfac = tobjModelo.Fcm_desser_dfac;
                        lobjRegistro.fcm_fecser_dfac = (DateTime)tobjModelo.Fcm_fecser_dfac;
                        lobjRegistro.fcm_horser_dfac = (Decimal)tobjModelo.Fcm_horser_dfac;
                        lobjRegistro.fcm_valser_mant = (decimal)tobjModelo.Fcm_valser_mant;
                        lobjRegistro.fcm_totuni_dfac = (int)tobjModelo.Fcm_totuni_dfac;
                        lobjRegistro.fcm_valbru_dfac = (decimal)tobjModelo.Fcm_valbru_dfac;
                        lobjRegistro.fcm_valbsi_dfac = (decimal)tobjModelo.Fcm_valbsi_dfac;
                        lobjRegistro.fcm_poriva_dfac = (decimal)tobjModelo.Fcm_poriva_dfac;
                        lobjRegistro.fcm_valiva_dfac = (decimal)tobjModelo.Fcm_valiva_dfac;
                        lobjRegistro.fcm_poricd_dfac = (decimal)tobjModelo.Fcm_poricd_dfac;
                        lobjRegistro.fcm_valicd_dfac = (decimal)tobjModelo.Fcm_valicd_dfac;
                        lobjRegistro.fcm_porica_dfac = (decimal)tobjModelo.Fcm_porica_dfac;
                        lobjRegistro.fcm_valica_dfac = (decimal)tobjModelo.Fcm_valica_dfac;
                        lobjRegistro.fcm_porinc_dfac = (decimal)tobjModelo.Fcm_porinc_dfac;
                        lobjRegistro.fcm_valinc_dfac = (decimal)tobjModelo.Fcm_valinc_dfac;
                        lobjRegistro.fcm_porrti_dfac = (decimal)tobjModelo.Fcm_porrti_dfac;
                        lobjRegistro.fcm_valrti_dfac = (decimal)tobjModelo.Fcm_valrti_dfac;
                        lobjRegistro.fcm_porrtf_dfac = (decimal)tobjModelo.Fcm_porrtf_dfac;
                        lobjRegistro.fcm_valrtf_dfac = (decimal)tobjModelo.Fcm_valrtf_dfac;
                        lobjRegistro.fcm_porrtc_dfac = (decimal)tobjModelo.Fcm_porrtc_dfac;
                        lobjRegistro.fcm_valrtc_dfac = (decimal)tobjModelo.Fcm_valrtc_dfac;
                        lobjRegistro.fcm_porcre_dfac = (decimal)tobjModelo.Fcm_porcre_dfac;
                        lobjRegistro.fcm_valcre_dfac = (decimal)tobjModelo.Fcm_valcre_dfac;
                        lobjRegistro.fcm_porfth_dfac = (decimal)tobjModelo.Fcm_porfth_dfac;
                        lobjRegistro.fcm_valfth_dfac = (decimal)tobjModelo.Fcm_valfth_dfac;
                        lobjRegistro.fcm_portim_dfac = (decimal)tobjModelo.Fcm_portim_dfac;
                        lobjRegistro.fcm_valtim_dfac = (decimal)tobjModelo.Fcm_valtim_dfac;
                        lobjRegistro.fcm_porbol_dfac = (decimal)tobjModelo.Fcm_porbol_dfac;
                        lobjRegistro.fcm_valbol_dfac = (decimal)tobjModelo.Fcm_valbol_dfac;
                        lobjRegistro.fcm_poricr_dfac = (decimal)tobjModelo.Fcm_poricr_dfac;
                        lobjRegistro.fcm_valicr_dfac = (decimal)tobjModelo.Fcm_valicr_dfac;
                        lobjRegistro.fcm_poricb_dfac = (decimal)tobjModelo.Fcm_poricb_dfac;
                        lobjRegistro.fcm_valicb_dfac = (decimal)tobjModelo.Fcm_valicb_dfac;
                        lobjRegistro.fcm_porscb_dfac = (decimal)tobjModelo.Fcm_porscb_dfac;
                        lobjRegistro.fcm_valscb_dfac = (decimal)tobjModelo.Fcm_valscb_dfac;
                        lobjRegistro.fcm_porsco_dfac = (decimal)tobjModelo.Fcm_porsco_dfac;
                        lobjRegistro.fcm_valsco_dfac = (decimal)tobjModelo.Fcm_valsco_dfac;
                        lobjRegistro.fcm_porftr_dfac = (decimal)tobjModelo.Fcm_porftr_dfac;
                        lobjRegistro.fcm_valftr_dfac = (decimal)tobjModelo.Fcm_valftr_dfac;
                        lobjRegistro.sis_coddes_side = tobjModelo.Sis_coddes_side;
                        lobjRegistro.fcm_pordes_dfac = (decimal)tobjModelo.Fcm_pordes_dfac;
                        lobjRegistro.fcm_valdes_dfac = (decimal)tobjModelo.Fcm_valdes_dfac;
                        lobjRegistro.fcm_valsub_dfac = (decimal)tobjModelo.Fcm_valsub_dfac;
                        lobjRegistro.fcm_valfac_dfac = (decimal)tobjModelo.Fcm_valfac_dfac;
                        lobjRegistro.fcm_valref_dfac = (decimal)tobjModelo.Fcm_valref_dfac;
                        lobjRegistro.fcm_valefe_dfac = (decimal)tobjModelo.Fcm_valefe_dfac;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                        #endregion
                        _context.SaveChanges();
                    }
                    else
                    {
                        lobjRegistro = new EFfcmfemaesfactefmd
                        {
                            #region cargar Registro
                            fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac,
                            fcm_secreg_mfac = tobjModelo.Fcm_secreg_mfac,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            fcm_idesec_mant = tobjModelo.Fcm_idesec_mant,
                            fcm_codpro_fcpr = tobjModelo.Fcm_codpro_fcpr,
                            fcm_codbar_mant = tobjModelo.Fcm_codbar_mant,
                            fcm_tiptar_dfac = tobjModelo.Fcm_tiptar_dfac,
                            fcm_codser_mant = tobjModelo.Fcm_codser_mant,
                            fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                            fcm_codman_mans = tobjModelo.Fcm_codman_mans,
                            fcm_desser_dfac = tobjModelo.Fcm_desser_dfac,
                            fcm_fecser_dfac = tobjModelo.Fcm_fecser_dfac,
                            fcm_horser_dfac = tobjModelo.Fcm_horser_dfac,
                            fcm_valser_mant = tobjModelo.Fcm_valser_mant,
                            fcm_totuni_dfac = tobjModelo.Fcm_totuni_dfac,
                            fcm_valbru_dfac = tobjModelo.Fcm_valbru_dfac,
                            fcm_valbsi_dfac = tobjModelo.Fcm_valbsi_dfac,
                            fcm_poriva_dfac = tobjModelo.Fcm_poriva_dfac,
                            fcm_valiva_dfac = tobjModelo.Fcm_valiva_dfac,
                            fcm_poricd_dfac = tobjModelo.Fcm_poricd_dfac,
                            fcm_valicd_dfac = tobjModelo.Fcm_valicd_dfac,
                            fcm_porica_dfac = tobjModelo.Fcm_porica_dfac,
                            fcm_valica_dfac = tobjModelo.Fcm_valica_dfac,
                            fcm_porinc_dfac = tobjModelo.Fcm_porinc_dfac,
                            fcm_valinc_dfac = tobjModelo.Fcm_valinc_dfac,
                            fcm_porrti_dfac = tobjModelo.Fcm_porrti_dfac,
                            fcm_valrti_dfac = tobjModelo.Fcm_valrti_dfac,
                            fcm_porrtf_dfac = tobjModelo.Fcm_porrtf_dfac,
                            fcm_valrtf_dfac = tobjModelo.Fcm_valrtf_dfac,
                            fcm_porrtc_dfac = tobjModelo.Fcm_porrtc_dfac,
                            fcm_valrtc_dfac = tobjModelo.Fcm_valrtc_dfac,
                            fcm_porcre_dfac = tobjModelo.Fcm_porcre_dfac,
                            fcm_valcre_dfac = tobjModelo.Fcm_valcre_dfac,
                            fcm_porfth_dfac = tobjModelo.Fcm_porfth_dfac,
                            fcm_valfth_dfac = tobjModelo.Fcm_valfth_dfac,
                            fcm_portim_dfac = tobjModelo.Fcm_portim_dfac,
                            fcm_valtim_dfac = tobjModelo.Fcm_valtim_dfac,
                            fcm_porbol_dfac = tobjModelo.Fcm_porbol_dfac,
                            fcm_valbol_dfac = tobjModelo.Fcm_valbol_dfac,
                            fcm_poricr_dfac = tobjModelo.Fcm_poricr_dfac,
                            fcm_valicr_dfac = tobjModelo.Fcm_valicr_dfac,
                            fcm_poricb_dfac = tobjModelo.Fcm_poricb_dfac,
                            fcm_valicb_dfac = tobjModelo.Fcm_valicb_dfac,
                            fcm_porscb_dfac = tobjModelo.Fcm_porscb_dfac,
                            fcm_valscb_dfac = tobjModelo.Fcm_valscb_dfac,
                            fcm_porsco_dfac = tobjModelo.Fcm_porsco_dfac,
                            fcm_valsco_dfac = tobjModelo.Fcm_valsco_dfac,
                            fcm_porftr_dfac = tobjModelo.Fcm_porftr_dfac,
                            fcm_valftr_dfac = tobjModelo.Fcm_valftr_dfac,
                            sis_coddes_side = tobjModelo.Sis_coddes_side,
                            fcm_pordes_dfac = tobjModelo.Fcm_pordes_dfac,
                            fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                            fcm_valsub_dfac = tobjModelo.Fcm_valsub_dfac,
                            fcm_valfac_dfac = tobjModelo.Fcm_valfac_dfac,
                            fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                            fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        _context.AddToFcmfemaesfactefmd(lobjRegistro);
                        _context.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
                Funciones.fcvVistaErroresEjecucion(ref ex, "ModeloFeFacturaMd error metodo FlgActualizar");

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
                    var lobjRegistro = _context.Fcmfemaesfactefmd.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
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
        #region Buscar FCMFEMAESFACTEFMD: Logica
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefmd</para>
        /// <para>TITULO: Detalles servicios - productos en cada factura digitada</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios y productos  (detalles de facturacion),
        /// cerradas y con numero de factura asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfemaesfactefmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesfactefmd.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
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
        /// Consulta detalles factura (dado el Numero unico de registro en maestro factura)
        /// </summary>
        /// <param name="tcrIdFactura">Secuencial registro en maestro factura</param>
        /// <returns></returns>
        public static List<ModeloFeFacturaMd> FlsListaFcmfemaesfactefmd(String tcrIdFactura)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmfemaesfactefmd in _context.Fcmfemaesfactefmd
                                  join fcmfeunspscdprodu in _context.Fcmfeunspscdprodu on fcmfemaesfactefmd.fcm_codpro_fcpr equals fcmfeunspscdprodu.fcm_codpro_fcpr into tmfcmfeunspscdprodu
                                  from fcpr in tmfcmfeunspscdprodu.DefaultIfEmpty()
                                  where fcmfemaesfactefmd.fcm_secreg_mfac == tcrIdFactura
                                  select new ModeloFeFacturaMd
                                  {
                                      #region Datos
                                      Fcm_secreg_dfac = fcmfemaesfactefmd.fcm_secreg_dfac,
                                      Fcm_secreg_mfac = fcmfemaesfactefmd.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = fcmfemaesfactefmd.fcm_numfac_mfac,
                                      Fcm_idesec_mant = fcmfemaesfactefmd.fcm_idesec_mant,
                                      Fcm_codpro_fcpr = fcmfemaesfactefmd.fcm_codpro_fcpr,
                                      Fcm_codbar_mant = fcmfemaesfactefmd.fcm_codbar_mant,
                                      Fcm_tiptar_dfac = fcmfemaesfactefmd.fcm_tiptar_dfac,
                                      Fcm_codser_mant = fcmfemaesfactefmd.fcm_codser_mant,
                                      Fcm_coddig_mant = fcmfemaesfactefmd.fcm_coddig_mant,
                                      Fcm_codman_mans = fcmfemaesfactefmd.fcm_codman_mans,
                                      Fcm_desser_dfac = fcmfemaesfactefmd.fcm_desser_dfac,
                                      Fcm_fecser_dfac = (DateTime)fcmfemaesfactefmd.fcm_fecser_dfac,
                                      Fcm_horser_dfac = (Decimal)fcmfemaesfactefmd.fcm_horser_dfac,
                                      Fcm_valser_mant = (decimal)fcmfemaesfactefmd.fcm_valser_mant,
                                      Fcm_totuni_dfac = (int)fcmfemaesfactefmd.fcm_totuni_dfac,
                                      Fcm_valbru_dfac = (decimal)fcmfemaesfactefmd.fcm_valbru_dfac,
                                      Fcm_valbsi_dfac = (decimal)fcmfemaesfactefmd.fcm_valbsi_dfac,
                                      Fcm_poriva_dfac = (decimal)fcmfemaesfactefmd.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (decimal)fcmfemaesfactefmd.fcm_valiva_dfac,
                                      Fcm_poricd_dfac = (decimal)fcmfemaesfactefmd.fcm_poricd_dfac,
                                      Fcm_valicd_dfac = (decimal)fcmfemaesfactefmd.fcm_valicd_dfac,
                                      Fcm_porica_dfac = (decimal)fcmfemaesfactefmd.fcm_porica_dfac,
                                      Fcm_valica_dfac = (decimal)fcmfemaesfactefmd.fcm_valica_dfac,
                                      Fcm_porinc_dfac = (decimal)fcmfemaesfactefmd.fcm_porinc_dfac,
                                      Fcm_valinc_dfac = (decimal)fcmfemaesfactefmd.fcm_valinc_dfac,
                                      Fcm_porrti_dfac = (decimal)fcmfemaesfactefmd.fcm_porrti_dfac,
                                      Fcm_valrti_dfac = (decimal)fcmfemaesfactefmd.fcm_valrti_dfac,
                                      Fcm_porrtf_dfac = (decimal)fcmfemaesfactefmd.fcm_porrtf_dfac,
                                      Fcm_valrtf_dfac = (decimal)fcmfemaesfactefmd.fcm_valrtf_dfac,
                                      Fcm_porrtc_dfac = (decimal)fcmfemaesfactefmd.fcm_porrtc_dfac,
                                      Fcm_valrtc_dfac = (decimal)fcmfemaesfactefmd.fcm_valrtc_dfac,
                                      Fcm_porcre_dfac = (decimal)fcmfemaesfactefmd.fcm_porcre_dfac,
                                      Fcm_valcre_dfac = (decimal)fcmfemaesfactefmd.fcm_valcre_dfac,
                                      Fcm_porfth_dfac = (decimal)fcmfemaesfactefmd.fcm_porfth_dfac,
                                      Fcm_valfth_dfac = (decimal)fcmfemaesfactefmd.fcm_valfth_dfac,
                                      Fcm_portim_dfac = (decimal)fcmfemaesfactefmd.fcm_portim_dfac,
                                      Fcm_valtim_dfac = (decimal)fcmfemaesfactefmd.fcm_valtim_dfac,
                                      Fcm_porbol_dfac = (decimal)fcmfemaesfactefmd.fcm_porbol_dfac,
                                      Fcm_valbol_dfac = (decimal)fcmfemaesfactefmd.fcm_valbol_dfac,
                                      Fcm_poricr_dfac = (decimal)fcmfemaesfactefmd.fcm_poricr_dfac,
                                      Fcm_valicr_dfac = (decimal)fcmfemaesfactefmd.fcm_valicr_dfac,
                                      Fcm_poricb_dfac = (decimal)fcmfemaesfactefmd.fcm_poricb_dfac,
                                      Fcm_valicb_dfac = (decimal)fcmfemaesfactefmd.fcm_valicb_dfac,
                                      Fcm_porscb_dfac = (decimal)fcmfemaesfactefmd.fcm_porscb_dfac,
                                      Fcm_valscb_dfac = (decimal)fcmfemaesfactefmd.fcm_valscb_dfac,
                                      Fcm_porsco_dfac = (decimal)fcmfemaesfactefmd.fcm_porsco_dfac,
                                      Fcm_valsco_dfac = (decimal)fcmfemaesfactefmd.fcm_valsco_dfac,
                                      Fcm_porftr_dfac = (decimal)fcmfemaesfactefmd.fcm_porftr_dfac,
                                      Fcm_valftr_dfac = (decimal)fcmfemaesfactefmd.fcm_valftr_dfac,
                                      Sis_coddes_side = fcmfemaesfactefmd.sis_coddes_side,
                                      Fcm_pordes_dfac = (decimal)fcmfemaesfactefmd.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (decimal)fcmfemaesfactefmd.fcm_valdes_dfac,
                                      Fcm_valsub_dfac = (decimal)fcmfemaesfactefmd.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (decimal)fcmfemaesfactefmd.fcm_valfac_dfac,
                                      Fcm_valref_dfac = (decimal)fcmfemaesfactefmd.fcm_valref_dfac,
                                      Fcm_valefe_dfac = (decimal)fcmfemaesfactefmd.fcm_valefe_dfac,
                                      Sis_estpro_espr = fcmfemaesfactefmd.sis_estpro_espr,
                                      Sis_codume_sium = fcpr.sis_codume_sium,
                                      Fcm_despro_fcpr = fcpr.fcm_despro_fcpr,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
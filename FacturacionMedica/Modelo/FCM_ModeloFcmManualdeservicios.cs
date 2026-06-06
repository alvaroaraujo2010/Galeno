//- MARMOTA-GENCODE: VERSION 2.0 - 25/03/2015 05:28:22 PM
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
    /// Descripcion para la Vista de  la tabla: fcmmanservicios
    /// </summary>
    public class ModeloFcmManualServicios : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_idesec_mant: Código único reg. servicio
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio para venta con manual
        /// tarifario (generado por el sistema)
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
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del servicio IPS habilitado
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
        #region Fcm_codman_mans: Código manual tarifario
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del maestro manual tarifario de servicios configurados
        /// para ventas ejm: M01=Manual SOAT para ventas  a particulares
        /// M02=Manual SOAT para ventas contributivo
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
        #region Fcm_codbar_sips: Código de Barras
        private String _fcm_codbar_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
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
        #region Fcm_codser_mant: Código servicio en tarifario
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS (es modificable)
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
        #region Fcm_valser_mant: Valor de servicio
        private float _fcm_valser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
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
        #region Fcm_punuvr_mant: Puntaje o UVR
        private float _fcm_punuvr_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_mant (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float Fcm_punuvr_mant
        {
            get { return _fcm_punuvr_mant; }
            set
            {
                if (_fcm_punuvr_mant == value) return;
                _fcm_punuvr_mant = value;
                OnPropertyChanged("Fcm_punuvr_mant");
            }
        }
        #endregion
        #region Fcm_valren_mant: Valor recargo nocturno
        private int _fcm_valren_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor recargo nocturno</para>
        /// <para>NOMBRE: fcm_valren_mant (int:14)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor del recargo nocturno (cuando aplique)
        /// </para>
        /// </summary>
        public int Fcm_valren_mant
        {
            get { return _fcm_valren_mant; }
            set
            {
                if (_fcm_valren_mant == value) return;
                _fcm_valren_mant = value;
                OnPropertyChanged("Fcm_valren_mant");
            }
        }
        #endregion
        #region Fcm_fecinv_mant: Fecha Ini Vigencia
        private DateTime _fcm_fecinv_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha Ini Vigencia</para>
        /// <para>NOMBRE: fcm_fecinv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual inicia vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecinv_mant
        {
            get { return _fcm_fecinv_mant; }
            set
            {
                if (_fcm_fecinv_mant == value) return;
                _fcm_fecinv_mant = value;
                OnPropertyChanged("Fcm_fecinv_mant");
            }
        }
        #endregion
        #region Fcm_fecfiv_mant: Fecha fin Vigencia
        private DateTime _fcm_fecfiv_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha fin Vigencia</para>
        /// <para>NOMBRE: fcm_fecfiv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual finaliza vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfiv_mant
        {
            get { return _fcm_fecfiv_mant; }
            set
            {
                if (_fcm_fecfiv_mant == value) return;
                _fcm_fecfiv_mant = value;
                OnPropertyChanged("Fcm_fecfiv_mant");
            }
        }
        #endregion
        #region Fcm_tipccp_mant: Tipo liquidación copagos
        private String _fcm_tipccp_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: fcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public String Fcm_tipccp_mant
        {
            get { return _fcm_tipccp_mant; }
            set
            {
                if (_fcm_tipccp_mant == value) return;
                _fcm_tipccp_mant = value;
                OnPropertyChanged("Fcm_tipccp_mant");
            }
        }
        #endregion
        #region Fcm_vficop_mant: Valor fijo Copagos c.mod
        private int _fcm_vficop_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor fijo Copagos c.mod</para>
        /// <para>NOMBRE: fcm_vficop_mant (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Valor del copago o cuota moderadora cuando es fijo
        /// </para>
        /// </summary>
        public int Fcm_vficop_mant
        {
            get { return _fcm_vficop_mant; }
            set
            {
                if (_fcm_vficop_mant == value) return;
                _fcm_vficop_mant = value;
                OnPropertyChanged("Fcm_vficop_mant");
            }
        }
        #endregion
        #region Fcm_facpln_mant: Tarifa Plena SI/NO
        private String _fcm_facpln_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tarifa Plena SI/NO</para>
        /// <para>NOMBRE: fcm_facpln_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Permitir recalcular precio segun porcentajes y cubrimientos del contrato:
        /// 1=Permitir recalcular según contrato  2=Cobrar Tarifa plena </para>
        /// </summary>
        public String Fcm_facpln_mant
        {
            get { return _fcm_facpln_mant; }
            set
            {
                if (_fcm_facpln_mant == value) return;
                _fcm_facpln_mant = value;
                OnPropertyChanged("Fcm_facpln_mant");
            }
        }
        #endregion
        #region Fcm_facvmc_mant: Valores en cero SI/NO
        private String _fcm_facvmc_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: fcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public String Fcm_facvmc_mant
        {
            get { return _fcm_facvmc_mant; }
            set
            {
                if (_fcm_facvmc_mant == value) return;
                _fcm_facvmc_mant = value;
                OnPropertyChanged("Fcm_facvmc_mant");
            }
        }
        #endregion
        #region Fcm_perman_mant: Código Pertenece al manual
        private String _fcm_perman_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: fcm_perman_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public String Fcm_perman_mant
        {
            get { return _fcm_perman_mant; }
            set
            {
                if (_fcm_perman_mant == value) return;
                _fcm_perman_mant = value;
                OnPropertyChanged("Fcm_perman_mant");
            }
        }
        #endregion
        #region Fcm_alcamb_mant: Ambulatoria POS/NO POS
        private String _fcm_alcamb_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Ambulatoria POS/NO POS</para>
        /// <para>NOMBRE: fcm_alcamb_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en ambulatoria: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public String Fcm_alcamb_mant
        {
            get { return _fcm_alcamb_mant; }
            set
            {
                if (_fcm_alcamb_mant == value) return;
                _fcm_alcamb_mant = value;
                OnPropertyChanged("Fcm_alcamb_mant");
            }
        }
        #endregion
        #region Fcm_alcurg_mant: Urgencia POS/NO POS
        private String _fcm_alcurg_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Urgencia POS/NO POS</para>
        /// <para>NOMBRE: fcm_alcurg_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Alcance del servicio en urgencia: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public String Fcm_alcurg_mant
        {
            get { return _fcm_alcurg_mant; }
            set
            {
                if (_fcm_alcurg_mant == value) return;
                _fcm_alcurg_mant = value;
                OnPropertyChanged("Fcm_alcurg_mant");
            }
        }
        #endregion
        #region Fcm_alchos_mant: Hospitalización POS/NO POS
        private String _fcm_alchos_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Hospitalización POS/NO POS</para>
        /// <para>NOMBRE: fcm_alchos_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en Hospitalizacion: 1= Es Pos 2= No es
        /// pos
        /// </para>
        /// </summary>
        public String Fcm_alchos_mant
        {
            get { return _fcm_alchos_mant; }
            set
            {
                if (_fcm_alchos_mant == value) return;
                _fcm_alchos_mant = value;
                OnPropertyChanged("Fcm_alchos_mant");
            }
        }
        #endregion
        #region Fcm_aplfus_sips: Frecuencia de uso SI/NO
        private String _fcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso SI/NO</para>
        /// <para>NOMBRE: fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region Fcm_estser_mant: Estado del servicio
        private String _fcm_estser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: fcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estser_mant
        {
            get { return _fcm_estser_mant; }
            set
            {
                if (_fcm_estser_mant == value) return;
                _fcm_estser_mant = value;
                OnPropertyChanged("Fcm_estser_mant");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
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
        #region Fcm_desman_mans: Manual tarifario
        private String _fcm_desman_mans;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
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
        #region Fcm_codtse_sips: Tipo procedimientos o servicios
        private String _fcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Fcm_claser_sips: Clasificación servicio
        private String _fcm_claser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Clasificación servicio</para>
        /// <para>NOMBRE: fcm_claser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Clasificacion del servicio cuando hace parte de un paquete
        /// o procedimiento quirurgico: 1=Ninguno 2=Cirujano 3=Anestesiólogo
        /// 4=Ayudante 5=derecho de Sala 6=materiales e Insumos 7=Instrumentador
        /// Quirúrgico
        /// </para>
        /// </summary>
        public String Fcm_claser_sips
        {
            get { return _fcm_claser_sips; }
            set
            {
                if (_fcm_claser_sips == value) return;
                _fcm_claser_sips = value;
                OnPropertyChanged("Fcm_claser_sips");
            }
        }
        #endregion
        #region Fcm_codgqx_grqx: Grupo Quirúrgico
        private String _fcm_codgqx_grqx;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmgrquirurgico</para>
        /// <para>CAMPO: Grupo Quirúrgico</para>
        /// <para>NOMBRE: fcm_codgqx_grqx (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Grupo quirurgico (para procedimientos quirurgicos)según manual
        /// SOAT o ISS
        /// </para>
        /// </summary>
        public String Fcm_codgqx_grqx
        {
            get { return _fcm_codgqx_grqx; }
            set
            {
                if (_fcm_codgqx_grqx == value) return;
                _fcm_codgqx_grqx = value;
                OnPropertyChanged("Fcm_codgqx_grqx");
            }
        }
        #endregion
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: siatablatprips</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region Sia_desrip_trip: Descripción tipo Rips
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloFcmManualServicios tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-TARIFAS-SERVICIOS", "FCM", "Registro detalles tarifas servicios");
            if (!flgBuscarFcmmanservicios(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmmanservicios
                    {
                        #region cargar Registro
                        fcm_idesec_mant = tobjModelo.Fcm_idesec_mant,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_codman_mans = tobjModelo.Fcm_codman_mans,
                        fcm_codbar_sips = tobjModelo.Fcm_codbar_sips,
                        fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                        fcm_codser_mant = tobjModelo.Fcm_codser_mant,
                        fcm_desser_mant = tobjModelo.Fcm_desser_mant,
                        fcm_valser_mant = tobjModelo.Fcm_valser_mant,
                        fcm_punuvr_mant = tobjModelo.Fcm_punuvr_mant,
                        fcm_valren_mant = tobjModelo.Fcm_valren_mant,
                        fcm_fecinv_mant = tobjModelo.Fcm_fecinv_mant,
                        fcm_fecfiv_mant = tobjModelo.Fcm_fecfiv_mant,
                        fcm_tipccp_mant = tobjModelo.Fcm_tipccp_mant,
                        fcm_vficop_mant = tobjModelo.Fcm_vficop_mant,
                        fcm_facpln_mant = tobjModelo.Fcm_facpln_mant,
                        fcm_facvmc_mant = tobjModelo.Fcm_facvmc_mant,
                        fcm_perman_mant = tobjModelo.Fcm_perman_mant,
                        fcm_alcamb_mant = tobjModelo.Fcm_alcamb_mant,
                        fcm_alcurg_mant = tobjModelo.Fcm_alcurg_mant,
                        fcm_alchos_mant = tobjModelo.Fcm_alchos_mant,
                        fcm_aplfus_sips = tobjModelo.Fcm_aplfus_sips,
                        fcm_estser_mant = tobjModelo.Fcm_estser_mant,
                        #endregion
                    };
                    lobjRegistro.fcm_idesec_mant = lcrCodigoGen;
                    _context.AddToFcmmanservicios(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-TARIFAS-SERVICIOS': Registro detalles tarifas servicios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloFcmManualServicios tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tobjModelo.Fcm_idesec_mant);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_idesec_mant = tobjModelo.Fcm_idesec_mant;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_codman_mans = tobjModelo.Fcm_codman_mans;
                    lobjRegistro.fcm_codbar_sips = tobjModelo.Fcm_codbar_sips;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.fcm_codser_mant = tobjModelo.Fcm_codser_mant;
                    lobjRegistro.fcm_desser_mant = tobjModelo.Fcm_desser_mant;
                    lobjRegistro.fcm_valser_mant = (float)tobjModelo.Fcm_valser_mant;
                    lobjRegistro.fcm_punuvr_mant = (float)tobjModelo.Fcm_punuvr_mant;
                    lobjRegistro.fcm_valren_mant = (int)tobjModelo.Fcm_valren_mant;
                    lobjRegistro.fcm_fecinv_mant = (DateTime)tobjModelo.Fcm_fecinv_mant;
                    lobjRegistro.fcm_fecfiv_mant = (DateTime)tobjModelo.Fcm_fecfiv_mant;
                    lobjRegistro.fcm_tipccp_mant = tobjModelo.Fcm_tipccp_mant;
                    lobjRegistro.fcm_vficop_mant = (int)tobjModelo.Fcm_vficop_mant;
                    lobjRegistro.fcm_facpln_mant = tobjModelo.Fcm_facpln_mant;
                    lobjRegistro.fcm_facvmc_mant = tobjModelo.Fcm_facvmc_mant;
                    lobjRegistro.fcm_perman_mant = tobjModelo.Fcm_perman_mant;
                    lobjRegistro.fcm_alcamb_mant = tobjModelo.Fcm_alcamb_mant;
                    lobjRegistro.fcm_alcurg_mant = tobjModelo.Fcm_alcurg_mant;
                    lobjRegistro.fcm_alchos_mant = tobjModelo.Fcm_alchos_mant;
                    lobjRegistro.fcm_aplfus_sips = tobjModelo.Fcm_aplfus_sips;
                    lobjRegistro.fcm_estser_mant = tobjModelo.Fcm_estser_mant;
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
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMANSERVICIOS: Logica
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crea paquetes de servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmanservicios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
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
        /// devuelve lista de registros tipo detalles servicios de un tarifario
        /// dado el parametro R1 (del manual tarifario Fcm_codman_mans) y el texto de busqueda
        /// <para>tcrEstadoRegistro: "1" = Activo "2" = Inactivo</para>
        /// </summary>
        public static List<ModeloFcmManualServicios> flsListaFcmmanservicios(String tcrIdTarifario, String tcrTextoBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrTextoBuscar))
                {
                    #region consulta
                    var lobConsulta = from fcmmanservicios in _context.Fcmmanservicios
                                      join fcmmanservicips in _context.Fcmmanservicips on fcmmanservicios.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join fcmmantarifario in _context.Fcmmantarifario on fcmmanservicios.fcm_codman_mans equals fcmmantarifario.fcm_codman_mans into tmfcmmantarifario
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from mans in tmfcmmantarifario.DefaultIfEmpty()
                                      where fcmmanservicios.fcm_codman_mans.Equals(tcrIdTarifario) 
                                      select new ModeloFcmManualServicios
                                      {
                                          Fcm_idesec_mant = fcmmanservicios.fcm_idesec_mant,
                                          Fcm_idesec_sips = fcmmanservicios.fcm_idesec_sips,
                                          Fcm_codman_mans = fcmmanservicios.fcm_codman_mans,
                                          Fcm_codbar_sips = fcmmanservicios.fcm_codbar_sips,
                                          Fcm_coddig_mant = fcmmanservicios.fcm_coddig_mant,
                                          Fcm_codser_mant = fcmmanservicios.fcm_codser_mant,
                                          Fcm_desser_mant = fcmmanservicios.fcm_desser_mant,
                                          Fcm_valser_mant = (float)fcmmanservicios.fcm_valser_mant,
                                          Fcm_punuvr_mant = (float)fcmmanservicios.fcm_punuvr_mant,
                                          Fcm_valren_mant = (int)fcmmanservicios.fcm_valren_mant,
                                          Fcm_fecinv_mant = (DateTime)fcmmanservicios.fcm_fecinv_mant,
                                          Fcm_fecfiv_mant = (DateTime)fcmmanservicios.fcm_fecfiv_mant,
                                          Fcm_tipccp_mant = fcmmanservicios.fcm_tipccp_mant,
                                          Fcm_vficop_mant = (int)fcmmanservicios.fcm_vficop_mant,
                                          Fcm_facpln_mant = fcmmanservicios.fcm_facpln_mant,
                                          Fcm_facvmc_mant = fcmmanservicios.fcm_facvmc_mant,
                                          Fcm_perman_mant = fcmmanservicios.fcm_perman_mant,
                                          Fcm_alcamb_mant = fcmmanservicios.fcm_alcamb_mant,
                                          Fcm_alcurg_mant = fcmmanservicios.fcm_alcurg_mant,
                                          Fcm_alchos_mant = fcmmanservicios.fcm_alchos_mant,
                                          Fcm_aplfus_sips = fcmmanservicios.fcm_aplfus_sips,
                                          Fcm_estser_mant = fcmmanservicios.fcm_estser_mant,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codtse_sips = sips.fcm_codtse_sips,
                                          Fcm_claser_sips = sips.fcm_claser_sips,
                                          Fcm_codgqx_grqx = sips.fcm_codgqx_grqx,
                                          Sia_codrip_trip = sips.sia_codrip_trip,
                                          Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(rxp => rxp.sia_codrip_trip == sips.sia_codrip_trip).sia_desrip_trip,
                                          Fcm_desman_mans = mans.fcm_desman_mans,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from fcmmanservicios in _context.Fcmmanservicios
                                      join fcmmanservicips in _context.Fcmmanservicips on fcmmanservicios.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join fcmmantarifario in _context.Fcmmantarifario on fcmmanservicios.fcm_codman_mans equals fcmmantarifario.fcm_codman_mans into tmfcmmantarifario
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from mans in tmfcmmantarifario.DefaultIfEmpty()
                                      where fcmmanservicios.fcm_codman_mans.Equals(tcrIdTarifario)  &&
                                           (fcmmanservicios.fcm_coddig_mant.Contains(tcrTextoBuscar) ||
                                            fcmmanservicios.fcm_codser_mant.Contains(tcrTextoBuscar) || 
                                            fcmmanservicios.fcm_desser_mant.Contains(tcrTextoBuscar))
                                      select new ModeloFcmManualServicios
                                      {
                                          Fcm_idesec_mant = fcmmanservicios.fcm_idesec_mant,
                                          Fcm_idesec_sips = fcmmanservicios.fcm_idesec_sips,
                                          Fcm_codman_mans = fcmmanservicios.fcm_codman_mans,
                                          Fcm_codbar_sips = fcmmanservicios.fcm_codbar_sips,
                                          Fcm_coddig_mant = fcmmanservicios.fcm_coddig_mant,
                                          Fcm_codser_mant = fcmmanservicios.fcm_codser_mant,
                                          Fcm_desser_mant = fcmmanservicios.fcm_desser_mant,
                                          Fcm_valser_mant = (float)fcmmanservicios.fcm_valser_mant,
                                          Fcm_punuvr_mant = (float)fcmmanservicios.fcm_punuvr_mant,
                                          Fcm_valren_mant = (int)fcmmanservicios.fcm_valren_mant,
                                          Fcm_fecinv_mant = (DateTime)fcmmanservicios.fcm_fecinv_mant,
                                          Fcm_fecfiv_mant = (DateTime)fcmmanservicios.fcm_fecfiv_mant,
                                          Fcm_tipccp_mant = fcmmanservicios.fcm_tipccp_mant,
                                          Fcm_vficop_mant = (int)fcmmanservicios.fcm_vficop_mant,
                                          Fcm_facpln_mant = fcmmanservicios.fcm_facpln_mant,
                                          Fcm_facvmc_mant = fcmmanservicios.fcm_facvmc_mant,
                                          Fcm_perman_mant = fcmmanservicios.fcm_perman_mant,
                                          Fcm_alcamb_mant = fcmmanservicios.fcm_alcamb_mant,
                                          Fcm_alcurg_mant = fcmmanservicios.fcm_alcurg_mant,
                                          Fcm_alchos_mant = fcmmanservicios.fcm_alchos_mant,
                                          Fcm_aplfus_sips = fcmmanservicios.fcm_aplfus_sips,
                                          Fcm_estser_mant = fcmmanservicios.fcm_estser_mant,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codtse_sips = sips.fcm_codtse_sips,
                                          Fcm_claser_sips = sips.fcm_claser_sips,
                                          Fcm_codgqx_grqx = sips.fcm_codgqx_grqx,
                                          Sia_codrip_trip = sips.sia_codrip_trip,
                                          Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(rxp => rxp.sia_codrip_trip == sips.sia_codrip_trip).sia_desrip_trip,
                                          Fcm_desman_mans = mans.fcm_desman_mans,
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
    /// Descripcion para la Vista de  la tabla: fcmmanservicios
    /// </summary>
    public class ModeloFcmManualServiciosDetalles : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_idesec_mant: Código único reg. servicio
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio para venta con manual
        /// tarifario (generado por el sistema)
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
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del servicio IPS habilitado
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
        #region Fcm_codman_mans: Código manual tarifario
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del maestro manual tarifario de servicios configurados
        /// para ventas ejm: M01=Manual SOAT para ventas  a particulares
        /// M02=Manual SOAT para ventas contributivo
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
        #region Fcm_codbar_sips: Código de Barras
        private String _fcm_codbar_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
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
        #region Fcm_codser_mant: Código servicio en tarifario
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS (es modificable)
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
        #region Fcm_valser_mant: Valor de servicio
        private float _fcm_valser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
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
        #region Fcm_punuvr_mant: Puntaje o UVR
        private float _fcm_punuvr_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_mant (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float Fcm_punuvr_mant
        {
            get { return _fcm_punuvr_mant; }
            set
            {
                if (_fcm_punuvr_mant == value) return;
                _fcm_punuvr_mant = value;
                OnPropertyChanged("Fcm_punuvr_mant");
            }
        }
        #endregion
        #region Fcm_valren_mant: Valor recargo nocturno
        private int _fcm_valren_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor recargo nocturno</para>
        /// <para>NOMBRE: fcm_valren_mant (int:14)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor del recargo nocturno (cuando aplique)
        /// </para>
        /// </summary>
        public int Fcm_valren_mant
        {
            get { return _fcm_valren_mant; }
            set
            {
                if (_fcm_valren_mant == value) return;
                _fcm_valren_mant = value;
                OnPropertyChanged("Fcm_valren_mant");
            }
        }
        #endregion
        #region Fcm_fecinv_mant: Fecha Ini Vigencia
        private DateTime _fcm_fecinv_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha Ini Vigencia</para>
        /// <para>NOMBRE: fcm_fecinv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual inicia vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecinv_mant
        {
            get { return _fcm_fecinv_mant; }
            set
            {
                if (_fcm_fecinv_mant == value) return;
                _fcm_fecinv_mant = value;
                OnPropertyChanged("Fcm_fecinv_mant");
            }
        }
        #endregion
        #region Fcm_fecfiv_mant: Fecha fin Vigencia
        private DateTime _fcm_fecfiv_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha fin Vigencia</para>
        /// <para>NOMBRE: fcm_fecfiv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual finaliza vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfiv_mant
        {
            get { return _fcm_fecfiv_mant; }
            set
            {
                if (_fcm_fecfiv_mant == value) return;
                _fcm_fecfiv_mant = value;
                OnPropertyChanged("Fcm_fecfiv_mant");
            }
        }
        #endregion
        #region Fcm_tipccp_mant: Tipo liquidación copagos
        private String _fcm_tipccp_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: fcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public String Fcm_tipccp_mant
        {
            get { return _fcm_tipccp_mant; }
            set
            {
                if (_fcm_tipccp_mant == value) return;
                _fcm_tipccp_mant = value;
                OnPropertyChanged("Fcm_tipccp_mant");
            }
        }
        #endregion
        #region Fcm_vficop_mant: Valor fijo Copagos c.mod
        private int _fcm_vficop_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor fijo Copagos c.mod</para>
        /// <para>NOMBRE: fcm_vficop_mant (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Valor del copago o cuota moderadora cuando es fijo
        /// </para>
        /// </summary>
        public int Fcm_vficop_mant
        {
            get { return _fcm_vficop_mant; }
            set
            {
                if (_fcm_vficop_mant == value) return;
                _fcm_vficop_mant = value;
                OnPropertyChanged("Fcm_vficop_mant");
            }
        }
        #endregion
        #region Fcm_facpln_mant: Tarifa Plena SI/NO
        private String _fcm_facpln_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tarifa Plena SI/NO</para>
        /// <para>NOMBRE: fcm_facpln_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Permitir recalcular segun porcentajes y cubrimientos del contrato:
        /// 1=Permitir recalcular según contrato  2=Cobrar Tarifa plena</para>
        /// </summary>
        public String Fcm_facpln_mant
        {
            get { return _fcm_facpln_mant; }
            set
            {
                if (_fcm_facpln_mant == value) return;
                _fcm_facpln_mant = value;
                OnPropertyChanged("Fcm_facpln_mant");
            }
        }
        #endregion
        #region Fcm_facvmc_mant: Valores en cero SI/NO
        private String _fcm_facvmc_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: fcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public String Fcm_facvmc_mant
        {
            get { return _fcm_facvmc_mant; }
            set
            {
                if (_fcm_facvmc_mant == value) return;
                _fcm_facvmc_mant = value;
                OnPropertyChanged("Fcm_facvmc_mant");
            }
        }
        #endregion
        #region Fcm_perman_mant: Código Pertenece al manual
        private String _fcm_perman_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: fcm_perman_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public String Fcm_perman_mant
        {
            get { return _fcm_perman_mant; }
            set
            {
                if (_fcm_perman_mant == value) return;
                _fcm_perman_mant = value;
                OnPropertyChanged("Fcm_perman_mant");
            }
        }
        #endregion
        #region Fcm_alcamb_mant: Ambulatoria POS/NO POS
        private String _fcm_alcamb_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Ambulatoria POS/NO POS</para>
        /// <para>NOMBRE: fcm_alcamb_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en ambulatoria: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public String Fcm_alcamb_mant
        {
            get { return _fcm_alcamb_mant; }
            set
            {
                if (_fcm_alcamb_mant == value) return;
                _fcm_alcamb_mant = value;
                OnPropertyChanged("Fcm_alcamb_mant");
            }
        }
        #endregion
        #region Fcm_alcurg_mant: Urgencia POS/NO POS
        private String _fcm_alcurg_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Urgencia POS/NO POS</para>
        /// <para>NOMBRE: fcm_alcurg_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Alcance del servicio en urgencia: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public String Fcm_alcurg_mant
        {
            get { return _fcm_alcurg_mant; }
            set
            {
                if (_fcm_alcurg_mant == value) return;
                _fcm_alcurg_mant = value;
                OnPropertyChanged("Fcm_alcurg_mant");
            }
        }
        #endregion
        #region Fcm_alchos_mant: Hospitalización POS/NO POS
        private String _fcm_alchos_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Hospitalización POS/NO POS</para>
        /// <para>NOMBRE: fcm_alchos_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en Hospitalizacion: 1= Es Pos 2= No es
        /// pos
        /// </para>
        /// </summary>
        public String Fcm_alchos_mant
        {
            get { return _fcm_alchos_mant; }
            set
            {
                if (_fcm_alchos_mant == value) return;
                _fcm_alchos_mant = value;
                OnPropertyChanged("Fcm_alchos_mant");
            }
        }
        #endregion
        #region Fcm_aplfus_sips: Frecuencia de uso SI/NO
        private String _fcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso SI/NO</para>
        /// <para>NOMBRE: fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region Fcm_estser_mant: Estado del servicio
        private String _fcm_estser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: fcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estser_mant
        {
            get { return _fcm_estser_mant; }
            set
            {
                if (_fcm_estser_mant == value) return;
                _fcm_estser_mant = value;
                OnPropertyChanged("Fcm_estser_mant");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
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
        #region Fcm_desman_mans: Manual tarifario
        private String _fcm_desman_mans;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
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
        #region Fcm_codtse_sips: Tipo procedimientos o servicios
        private String _fcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Fcm_claser_sips: Clasificación servicio
        private String _fcm_claser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Clasificación servicio</para>
        /// <para>NOMBRE: fcm_claser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Clasificacion del servicio cuando hace parte de un paquete
        /// o procedimiento quirurgico: 1=Ninguno 2=Cirujano 3=Anestesiólogo
        /// 4=Ayudante 5=derecho de Sala 6=materiales e Insumos 7=Instrumentador
        /// Quirúrgico
        /// </para>
        /// </summary>
        public String Fcm_claser_sips
        {
            get { return _fcm_claser_sips; }
            set
            {
                if (_fcm_claser_sips == value) return;
                _fcm_claser_sips = value;
                OnPropertyChanged("Fcm_claser_sips");
            }
        }
        #endregion
        #region Fcm_codgqx_grqx: Grupo Quirúrgico
        private String _fcm_codgqx_grqx;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmgrquirurgico</para>
        /// <para>CAMPO: Grupo Quirúrgico</para>
        /// <para>NOMBRE: fcm_codgqx_grqx (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Grupo quirurgico (para procedimientos quirurgicos)según manual
        /// SOAT o ISS
        /// </para>
        /// </summary>
        public String Fcm_codgqx_grqx
        {
            get { return _fcm_codgqx_grqx; }
            set
            {
                if (_fcm_codgqx_grqx == value) return;
                _fcm_codgqx_grqx = value;
                OnPropertyChanged("Fcm_codgqx_grqx");
            }
        }
        #endregion
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: siatablatprips</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region Sia_desrip_trip: Nombre laboratorio
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
        public static bool flgAddRegistro(ModeloFcmManualServiciosDetalles tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmanservicios();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tobTempReg.Fcm_idesec_mant);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.fcm_idesec_mant = tobTempReg.Fcm_idesec_mant;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_codman_mans = tobTempReg.Fcm_codman_mans;
                            lobEFReg.fcm_codbar_sips = tobTempReg.Fcm_codbar_sips;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.fcm_codser_mant = tobTempReg.Fcm_codser_mant;
                            lobEFReg.fcm_desser_mant = tobTempReg.Fcm_desser_mant;
                            lobEFReg.fcm_valser_mant = (float)tobTempReg.Fcm_valser_mant;
                            lobEFReg.fcm_punuvr_mant = (float)tobTempReg.Fcm_punuvr_mant;
                            lobEFReg.fcm_valren_mant = (int)tobTempReg.Fcm_valren_mant;
                            lobEFReg.fcm_fecinv_mant = (DateTime)tobTempReg.Fcm_fecinv_mant;
                            lobEFReg.fcm_fecfiv_mant = (DateTime)tobTempReg.Fcm_fecfiv_mant;
                            lobEFReg.fcm_tipccp_mant = tobTempReg.Fcm_tipccp_mant;
                            lobEFReg.fcm_vficop_mant = (int)tobTempReg.Fcm_vficop_mant;
                            lobEFReg.fcm_facpln_mant = tobTempReg.Fcm_facpln_mant;
                            lobEFReg.fcm_facvmc_mant = tobTempReg.Fcm_facvmc_mant;
                            lobEFReg.fcm_perman_mant = tobTempReg.Fcm_perman_mant;
                            lobEFReg.fcm_alcamb_mant = tobTempReg.Fcm_alcamb_mant;
                            lobEFReg.fcm_alcurg_mant = tobTempReg.Fcm_alcurg_mant;
                            lobEFReg.fcm_alchos_mant = tobTempReg.Fcm_alchos_mant;
                            lobEFReg.fcm_aplfus_sips = tobTempReg.Fcm_aplfus_sips;
                            lobEFReg.fcm_estser_mant = tobTempReg.Fcm_estser_mant;
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
                                lobEFReg.fcm_idesec_mant = tcrCodigoR1 + lobEFReg.fcm_idesec_mant; // concatenar
                                _context.AddToFcmmanservicios(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tobTempReg.Fcm_idesec_mant);
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
        #region Buscar FCMMANSERVICIOS: Logica
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TITULO: Manual ventas de servicios medicos</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios derivados de SERVICIOS IPS, en este archivo
        /// se configuran los precios y codigos de tarifarios para ventas(SOAT
        /// ISS CUPS), se crea paquetes de servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmanservicios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicios.FirstOrDefault(p => p.fcm_idesec_mant == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFcmManualServiciosDetalles> flsListaFcmmanservicios(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmanservicios in _context.Fcmmanservicios
                                  join fcmmanservicips in _context.Fcmmanservicips on fcmmanservicios.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  join fcmmantarifario in _context.Fcmmantarifario on fcmmanservicios.fcm_codman_mans equals fcmmantarifario.fcm_codman_mans into tmfcmmantarifario
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  from mans in tmfcmmantarifario.DefaultIfEmpty()
                                  where fcmmanservicios.fcm_codman_mans == tcrBuscar
                                  select new ModeloFcmManualServiciosDetalles
                                  {
                                      Fcm_idesec_mant = fcmmanservicios.fcm_idesec_mant,
                                      Fcm_idesec_sips = fcmmanservicios.fcm_idesec_sips,
                                      Fcm_codman_mans = fcmmanservicios.fcm_codman_mans,
                                      Fcm_codbar_sips = fcmmanservicios.fcm_codbar_sips,
                                      Fcm_coddig_mant = fcmmanservicios.fcm_coddig_mant,
                                      Fcm_codser_mant = fcmmanservicios.fcm_codser_mant,
                                      Fcm_desser_mant = fcmmanservicios.fcm_desser_mant,
                                      Fcm_valser_mant = (float)fcmmanservicios.fcm_valser_mant,
                                      Fcm_punuvr_mant = (float)fcmmanservicios.fcm_punuvr_mant,
                                      Fcm_valren_mant = (int)fcmmanservicios.fcm_valren_mant,
                                      Fcm_fecinv_mant = (DateTime)fcmmanservicios.fcm_fecinv_mant,
                                      Fcm_fecfiv_mant = (DateTime)fcmmanservicios.fcm_fecfiv_mant,
                                      Fcm_tipccp_mant = fcmmanservicios.fcm_tipccp_mant,
                                      Fcm_vficop_mant = (int)fcmmanservicios.fcm_vficop_mant,
                                      Fcm_facpln_mant = fcmmanservicios.fcm_facpln_mant,
                                      Fcm_facvmc_mant = fcmmanservicios.fcm_facvmc_mant,
                                      Fcm_perman_mant = fcmmanservicios.fcm_perman_mant,
                                      Fcm_alcamb_mant = fcmmanservicios.fcm_alcamb_mant,
                                      Fcm_alcurg_mant = fcmmanservicios.fcm_alcurg_mant,
                                      Fcm_alchos_mant = fcmmanservicios.fcm_alchos_mant,
                                      Fcm_aplfus_sips = fcmmanservicios.fcm_aplfus_sips,
                                      Fcm_estser_mant = fcmmanservicios.fcm_estser_mant,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Fcm_codtse_sips = sips.fcm_codtse_sips,
                                      Fcm_claser_sips = sips.fcm_claser_sips,
                                      Fcm_codgqx_grqx = sips.fcm_codgqx_grqx,
                                      Sia_codrip_trip = sips.sia_codrip_trip,
                                      Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(rxp => rxp.sia_codrip_trip == sips.sia_codrip_trip).sia_desrip_trip,
                                      Fcm_desman_mans = mans.fcm_desman_mans,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmansercompaq
    /// </summary>
    public class ModeloFcmmansercompaq : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_idesec_copq: Código único reg. servicio
        private String _fcm_idesec_copq;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmansercompaq</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: fcm_idesec_copq (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_idesec_copq
        {
            get { return _fcm_idesec_copq; }
            set
            {
                if (_fcm_idesec_copq == value) return;
                _fcm_idesec_copq = value;
                OnPropertyChanged("Fcm_idesec_copq");
            }
        }
        #endregion
        #region Fcm_idesec_mant: Código único reg. servicio
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio para venta con manual
        /// tarifario (generado por el sistema)
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
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del servicio IPS habilitado
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
        private String _fcm_codbar_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
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
        #region Fcm_codser_mant: Código servicio en tarifario
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS (es modificable)
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
        #region Fcm_numuni_copq: Total unidades
        private int _fcm_numuni_copq;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmansercompaq</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_numuni_copq (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Total unidades del servicio que se incluyen el paquete
        /// </para>
        /// </summary>
        public int Fcm_numuni_copq
        {
            get { return _fcm_numuni_copq; }
            set
            {
                if (_fcm_numuni_copq == value) return;
                _fcm_numuni_copq = value;
                OnPropertyChanged("Fcm_numuni_copq");
            }
        }
        #endregion
        #region Fcm_estser_copq: Estado del servicio
        private String _fcm_estser_copq;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmansercompaq</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: fcm_estser_copq (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Estado del servicio dentro del paquete: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estser_copq
        {
            get { return _fcm_estser_copq; }
            set
            {
                if (_fcm_estser_copq == value) return;
                _fcm_estser_copq = value;
                OnPropertyChanged("Fcm_estser_copq");
            }
        }
        #endregion
        #region Fcm_desser_mant: Nombre servicio
        private String _fcm_desser_mant;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
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
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
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
        #region Fcm_valser_mant: Valor de servicio
        private float _fcm_valser_mant;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
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
        #region Fcm_punuvr_mant: Puntaje o UVR
        private float _fcm_punuvr_mant;
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_mant (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float Fcm_punuvr_mant
        {
            get { return _fcm_punuvr_mant; }
            set
            {
                if (_fcm_punuvr_mant == value) return;
                _fcm_punuvr_mant = value;
                OnPropertyChanged("Fcm_punuvr_mant");
            }
        }
        #endregion
        #region Sia_codrip_trip:
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_codrip_trip (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sia_desrip_trip: Nombre laboratorio
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloFcmmansercompaq tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMMANSERCOMPAQ", "FCM", "Archivo para Codigos servicios que hacen un paquete de servicios");
            if (!flgBuscarFcmmansercompaq(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmmansercompaq
                    {
                        #region cargar Registro
                        fcm_idesec_copq = tobjModelo.Fcm_idesec_copq,
                        fcm_idesec_mant = tobjModelo.Fcm_idesec_mant,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_numuni_copq = tobjModelo.Fcm_numuni_copq,
                        fcm_estser_copq = tobjModelo.Fcm_estser_copq,
                        #endregion
                    };
                    lobjRegistro.fcm_idesec_copq = lcrCodigoGen;
                    _context.AddToFcmmansercompaq(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMMANSERCOMPAQ': Archivo para Codigos servicios que hacen un paquete de servicios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloFcmmansercompaq tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmansercompaq.FirstOrDefault(p => p.fcm_idesec_copq == tobjModelo.Fcm_idesec_copq);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_idesec_copq = tobjModelo.Fcm_idesec_copq;
                    lobjRegistro.fcm_idesec_mant = tobjModelo.Fcm_idesec_mant;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_numuni_copq = (int)tobjModelo.Fcm_numuni_copq;
                    lobjRegistro.fcm_estser_copq = tobjModelo.Fcm_estser_copq;
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
                var lobjRegistro = _context.Fcmmansercompaq.FirstOrDefault(p => p.fcm_idesec_copq == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMANSERCOMPAQ: Logica
        /// <summary>
        /// <para>TABLA: fcmmansercompaq</para>
        /// <para>TITULO: Archivo para Codigos servicios que hacen un paquete de servi</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Archivo para guardar los codigos de servicios que hacen parte
        /// de un paquete de servicios, solo para los servicios en la tabla
        /// FCMMANSERVICIOS, que esten marcados como paquetes de servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmansercompaq(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmansercompaq.FirstOrDefault(p => p.fcm_idesec_copq == tcrCodigo);
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
        /// devuelve lista de registros tipo detalles de paquete de un servicio en manual de ventas 
        /// dado el parametro R1 (fcm_idesec_mant)
        /// <para>tcrEstadoRegistro: "1" = Activo "2" = Inactivo</para>
        /// </summary>
        public static List<ModeloFcmmansercompaq> flsListaFcmmansercompaq(string tcrBuscar, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmansercompaq in _context.Fcmmansercompaq
                                  join fcmmanservicios in _context.Fcmmanservicios on fcmmansercompaq.fcm_idesec_mant equals fcmmanservicios.fcm_idesec_mant into tmfcmmanservicios
                                  join fcmmanservicips in _context.Fcmmanservicips on fcmmansercompaq.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  from mant in tmfcmmanservicios.DefaultIfEmpty()
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  where fcmmansercompaq.fcm_idesec_mant == tcrBuscar && fcmmansercompaq.fcm_estser_copq == tcrEstadoRegistro
                                  select new ModeloFcmmansercompaq
                                  {
                                      Fcm_idesec_copq = fcmmansercompaq.fcm_idesec_copq,
                                      Fcm_idesec_mant = fcmmansercompaq.fcm_idesec_mant,
                                      Fcm_idesec_sips = fcmmansercompaq.fcm_idesec_sips,
                                      Fcm_numuni_copq = (int)fcmmansercompaq.fcm_numuni_copq,
                                      Fcm_estser_copq = fcmmansercompaq.fcm_estser_copq,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Sia_codrip_trip = sips.sia_codrip_trip,
                                      Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(rxp => rxp.sia_codrip_trip == sips.sia_codrip_trip).sia_desrip_trip,
                                      Fcm_codbar_sips = mant.fcm_codbar_sips,
                                      Fcm_coddig_mant = mant.fcm_coddig_mant,
                                      Fcm_codser_mant = mant.fcm_codser_mant,
                                      Fcm_desser_mant = mant.fcm_desser_mant,
                                      Fcm_punuvr_mant = (float)mant.fcm_punuvr_mant,
                                      Fcm_valser_mant = (float)mant.fcm_valser_mant,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }

}
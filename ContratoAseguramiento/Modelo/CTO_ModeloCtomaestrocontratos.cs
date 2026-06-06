//- MARMOTA-GENCODE: VERSION 2.0 - 19/04/2015 08:13:00 AM
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

namespace ContratoAseguramiento.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: ctomaescontrato
    /// </summary>
    public class ModeloCtomaestrocontratos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de Contrato según documento firmado en acuerdo de voluntades
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
        #region Cto_modeps_cont: Modificar código EPS
        private String _cto_modeps_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Modificar código EPS</para>
        /// <para>NOMBRE: cto_modeps_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Modificar Código  EPS que esta asociado al contrato en el momento
        /// de realizar admisión o facturar servicios 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_modeps_cont
        {
            get { return _cto_modeps_cont; }
            set
            {
                if (_cto_modeps_cont == value) return;
                _cto_modeps_cont = value;
                OnPropertyChanged("Cto_modeps_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos en reemplazo de Con_idesec_mter
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
        #region Cto_fecico_cont: Fecha Inicio vigencia
        private DateTime _cto_fecico_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Fecha Inicio vigencia</para>
        /// <para>NOMBRE: cto_fecico_cont (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha Inicio vigencia del contrato
        /// </para>
        /// </summary>
        public DateTime Cto_fecico_cont
        {
            get { return _cto_fecico_cont; }
            set
            {
                if (_cto_fecico_cont == value) return;
                _cto_fecico_cont = value;
                OnPropertyChanged("Cto_fecico_cont");
            }
        }
        #endregion
        #region Cto_fecfco_cont: Fecha fin vigencia
        private DateTime _cto_fecfco_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Fecha fin vigencia</para>
        /// <para>NOMBRE: cto_fecfco_cont (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha finalizacion vigencia contrato
        /// </para>
        /// </summary>
        public DateTime Cto_fecfco_cont
        {
            get { return _cto_fecfco_cont; }
            set
            {
                if (_cto_fecfco_cont == value) return;
                _cto_fecfco_cont = value;
                OnPropertyChanged("Cto_fecfco_cont");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
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
        #region Fcm_codman_mans: Código manual servicios
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejm: 01=SOAT mas el 10 para la empresa XX
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
        #region Cto_plaben_cont: Plan de beneficios
        private String _cto_plaben_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Plan de beneficios</para>
        /// <para>NOMBRE: cto_plaben_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del plan de beneficios ejm: Pos Contributivo,
        /// Pos Subsidiado y otros
        /// </para>
        /// </summary>
        public String Cto_plaben_cont
        {
            get { return _cto_plaben_cont; }
            set
            {
                if (_cto_plaben_cont == value) return;
                _cto_plaben_cont = value;
                OnPropertyChanged("Cto_plaben_cont");
            }
        }
        #endregion
        #region Sia_tipusu_regi: Tipo población Cubierta
        private String _sia_tipusu_regi;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Tipo población Cubierta</para>
        /// <para>NOMBRE: sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// tipo usuarioso pacientes que cubre el contrato segun regimen
        /// 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)
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
        #region Cto_polcon_cont: Numero Póliza del contrato
        private String _cto_polcon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Numero Póliza del contrato</para>
        /// <para>NOMBRE: cto_polcon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Numero de la poliza aseguramiento del contrato
        /// </para>
        /// </summary>
        public String Cto_polcon_cont
        {
            get { return _cto_polcon_cont; }
            set
            {
                if (_cto_polcon_cont == value) return;
                _cto_polcon_cont = value;
                OnPropertyChanged("Cto_polcon_cont");
            }
        }
        #endregion
        #region Cto_codtco_cont: Contrato Capitado/Evento
        private String _cto_codtco_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Capitado/Evento</para>
        /// <para>NOMBRE: cto_codtco_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo de contrato : 1=Capitado 2=Contrato por evento
        /// </para>
        /// </summary>
        public String Cto_codtco_cont
        {
            get { return _cto_codtco_cont; }
            set
            {
                if (_cto_codtco_cont == value) return;
                _cto_codtco_cont = value;
                OnPropertyChanged("Cto_codtco_cont");
            }
        }
        #endregion
        #region Cto_tipact_cont: Contrato Asistencial/PyP
        private String _cto_tipact_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Asistencial/PyP</para>
        /// <para>NOMBRE: cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Ambas
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
        #region Cto_sepser_cont: Separar Asistencial y PyP
        private String _cto_sepser_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separar Asistencial y PyP</para>
        /// <para>NOMBRE: cto_sepser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial y PyP para generar facturas
        /// por separado, cuando el contrato cubre ambos tipos de servicios:
        /// 1=Si 2=No
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
        #region Cto_gruite_cont: Agrupar facturas
        private String _cto_gruite_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Agrupar facturas</para>
        /// <para>NOMBRE: cto_gruite_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Agrupar los Servicios En Facturación por: 1=Código del Servicio
        /// 2=Código Servicio y Fecha de Prestación
        /// </para>
        /// </summary>
        public String Cto_gruite_cont
        {
            get { return _cto_gruite_cont; }
            set
            {
                if (_cto_gruite_cont == value) return;
                _cto_gruite_cont = value;
                OnPropertyChanged("Cto_gruite_cont");
            }
        }
        #endregion
        // Datos para facturacion Dian
        #region Cto_fcdian_cont: Secuencial facturas DIAN
        private String _cto_fcdian_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
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
        #region Fcm_secraz_fcem: Codigo unico Razon social
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
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
        // Otros Datos
        #region Cto_ajupre_cont: Ajuste precio servicios
        private int _cto_ajupre_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Ajuste precio servicios</para>
        /// <para>NOMBRE: cto_ajupre_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Ajuste del precio de servicios a: 10,20,50,100,100 y otros
        /// </para>
        /// </summary>
        public int Cto_ajupre_cont
        {
            get { return _cto_ajupre_cont; }
            set
            {
                if (_cto_ajupre_cont == value) return;
                _cto_ajupre_cont = value;
                OnPropertyChanged("Cto_ajupre_cont");
            }
        }
        #endregion
        #region Cto_frecus_cont: Frecuencia uso servicios
        private String _cto_frecus_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Frecuencia uso servicios</para>
        /// <para>NOMBRE: cto_frecus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Aplicar Validacion de frecuencia de uso de servicio: 1=Si 2=No
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
        #region Cto_porrec_cont: Porcentaje Recargo precio
        private float _cto_porrec_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje Recargo precio</para>
        /// <para>NOMBRE: cto_porrec_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Prcentaje incremento precios de Venta  o descuento (Recargo
        /// o descuento en precios) ejm: tarifa servicio +10, tarifa servicio-
        /// 5
        /// </para>
        /// </summary>
        public float Cto_porrec_cont
        {
            get { return _cto_porrec_cont; }
            set
            {
                if (_cto_porrec_cont == value) return;
                _cto_porrec_cont = value;
                OnPropertyChanged("Cto_porrec_cont");
            }
        }
        #endregion
        #region Cto_porcub_cont: Porcentaje cubrimiento
        private float _cto_porcub_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento</para>
        /// <para>NOMBRE: cto_porcub_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento o amparo del contrato
        /// </para>
        /// </summary>
        public float Cto_porcub_cont
        {
            get { return _cto_porcub_cont; }
            set
            {
                if (_cto_porcub_cont == value) return;
                _cto_porcub_cont = value;
                OnPropertyChanged("Cto_porcub_cont");
            }
        }
        #endregion
        #region Cto_cubniv_cont: Niveles de complejidad
        private String _cto_cubniv_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Niveles de complejidad</para>
        /// <para>NOMBRE: cto_cubniv_cont (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Cubre servicios según niveles de complejidad 1 hasta el 7
        /// </para>
        /// </summary>
        public String Cto_cubniv_cont
        {
            get { return _cto_cubniv_cont; }
            set
            {
                if (_cto_cubniv_cont == value) return;
                _cto_cubniv_cont = value;
                OnPropertyChanged("Cto_cubniv_cont");
            }
        }
        #endregion
        #region Cto_vibaud_cont: Visto Bueno Auditoria SI/NO
        private String _cto_vibaud_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Visto Bueno Auditoria SI/NO</para>
        /// <para>NOMBRE: cto_vibaud_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Requiere visto bueno de auditar para asi poder generar numero
        /// de factura y confirmar : 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_vibaud_cont
        {
            get { return _cto_vibaud_cont; }
            set
            {
                if (_cto_vibaud_cont == value) return;
                _cto_vibaud_cont = value;
                OnPropertyChanged("Cto_vibaud_cont");
            }
        }
        #endregion
        #region Cto_porcn1_cont: Porcentaje cubrimiento Nivel 1
        private float _cto_porcn1_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 1</para>
        /// <para>NOMBRE: cto_porcn1_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 1
        /// </para>
        /// </summary>
        public float Cto_porcn1_cont
        {
            get { return _cto_porcn1_cont; }
            set
            {
                if (_cto_porcn1_cont == value) return;
                _cto_porcn1_cont = value;
                OnPropertyChanged("Cto_porcn1_cont");
            }
        }
        #endregion
        #region Cto_porcn2_cont: Porcentaje cubrimiento Nivel 2
        private float _cto_porcn2_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 2</para>
        /// <para>NOMBRE: cto_porcn2_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 2
        /// </para>
        /// </summary>
        public float Cto_porcn2_cont
        {
            get { return _cto_porcn2_cont; }
            set
            {
                if (_cto_porcn2_cont == value) return;
                _cto_porcn2_cont = value;
                OnPropertyChanged("Cto_porcn2_cont");
            }
        }
        #endregion
        #region Cto_porcn3_cont: Porcentaje cubrimiento Nivel 3
        private float _cto_porcn3_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 3</para>
        /// <para>NOMBRE: cto_porcn3_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 3
        /// </para>
        /// </summary>
        public float Cto_porcn3_cont
        {
            get { return _cto_porcn3_cont; }
            set
            {
                if (_cto_porcn3_cont == value) return;
                _cto_porcn3_cont = value;
                OnPropertyChanged("Cto_porcn3_cont");
            }
        }
        #endregion
        #region Cto_porcn4_cont: Porcentaje cubrimiento Nivel 4
        private float _cto_porcn4_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 4</para>
        /// <para>NOMBRE: cto_porcn4_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 4
        /// </para>
        /// </summary>
        public float Cto_porcn4_cont
        {
            get { return _cto_porcn4_cont; }
            set
            {
                if (_cto_porcn4_cont == value) return;
                _cto_porcn4_cont = value;
                OnPropertyChanged("Cto_porcn4_cont");
            }
        }
        #endregion
        #region Cto_porcn5_cont: Porcentaje cubrimiento Nivel 5
        private float _cto_porcn5_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 5</para>
        /// <para>NOMBRE: cto_porcn5_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 5
        /// </para>
        /// </summary>
        public float Cto_porcn5_cont
        {
            get { return _cto_porcn5_cont; }
            set
            {
                if (_cto_porcn5_cont == value) return;
                _cto_porcn5_cont = value;
                OnPropertyChanged("Cto_porcn5_cont");
            }
        }
        #endregion
        #region Cto_porcn6_cont: Porcentaje cubrimiento Nivel 6
        private float _cto_porcn6_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 6</para>
        /// <para>NOMBRE: cto_porcn6_cont (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 6
        /// </para>
        /// </summary>
        public float Cto_porcn6_cont
        {
            get { return _cto_porcn6_cont; }
            set
            {
                if (_cto_porcn6_cont == value) return;
                _cto_porcn6_cont = value;
                OnPropertyChanged("Cto_porcn6_cont");
            }
        }
        #endregion
        #region Cto_totafi_cont: Total asegurados
        private int _cto_totafi_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Total asegurados</para>
        /// <para>NOMBRE: cto_totafi_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Total afiliados asegurados en el contrato
        /// </para>
        /// </summary>
        public int Cto_totafi_cont
        {
            get { return _cto_totafi_cont; }
            set
            {
                if (_cto_totafi_cont == value) return;
                _cto_totafi_cont = value;
                OnPropertyChanged("Cto_totafi_cont");
            }
        }
        #endregion
        #region Cto_estcon_cont: Estado del contrato
        private String _cto_estcon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Estado del contrato</para>
        /// <para>NOMBRE: cto_estcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Estado del Contrato: 1=Activo 2=Inactivo 3=Suspendido
        /// </para>
        /// </summary>
        public String Cto_estcon_cont
        {
            get { return _cto_estcon_cont; }
            set
            {
                if (_cto_estcon_cont == value) return;
                _cto_estcon_cont = value;
                OnPropertyChanged("Cto_estcon_cont");
            }
        }
        #endregion
        #region Cto_prnord_cont: Imprimir orden Servi SI/NO
        private String _cto_prnord_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir orden Servi SI/NO</para>
        /// <para>NOMBRE: cto_prnord_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto la orden de prestacion de servicios medicos:
        /// 1= Si 2=No
        /// </para>
        /// </summary>
        public String Cto_prnord_cont
        {
            get { return _cto_prnord_cont; }
            set
            {
                if (_cto_prnord_cont == value) return;
                _cto_prnord_cont = value;
                OnPropertyChanged("Cto_prnord_cont");
            }
        }
        #endregion
        #region Cto_prnrca_cont: Imprimir recibo caja SI/NO
        private String _cto_prnrca_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir recibo caja SI/NO</para>
        /// <para>NOMBRE: cto_prnrca_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto recibo de caja  por valores pagados en
        /// efectivo : 1= Si 2=No
        /// </para>
        /// </summary>
        public String Cto_prnrca_cont
        {
            get { return _cto_prnrca_cont; }
            set
            {
                if (_cto_prnrca_cont == value) return;
                _cto_prnrca_cont = value;
                OnPropertyChanged("Cto_prnrca_cont");
            }
        }
        #endregion
        #region Cto_apldes_cont: Aplicar descuento SI/NO
        private String _cto_apldes_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Aplicar descuento SI/NO</para>
        /// <para>NOMBRE: cto_apldes_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Aplicar Descuento: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_apldes_cont
        {
            get { return _cto_apldes_cont; }
            set
            {
                if (_cto_apldes_cont == value) return;
                _cto_apldes_cont = value;
                OnPropertyChanged("Cto_apldes_cont");
            }
        }
        #endregion
        #region Cto_cobser_cont: Cobro efectivo servicios SI/NO
        private String _cto_cobser_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo servicios SI/NO</para>
        /// <para>NOMBRE: cto_cobser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo de valores servicios: 1=Si 2=No
        /// (para mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public String Cto_cobser_cont
        {
            get { return _cto_cobser_cont; }
            set
            {
                if (_cto_cobser_cont == value) return;
                _cto_cobser_cont = value;
                OnPropertyChanged("Cto_cobser_cont");
            }
        }
        #endregion
        #region Cto_cobcop_cont: Cobro efectivo copago SI/NO
        private String _cto_cobcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo copago SI/NO</para>
        /// <para>NOMBRE: cto_cobcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del Copago: 1=Si 2=No (para mostrar
        /// la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public String Cto_cobcop_cont
        {
            get { return _cto_cobcop_cont; }
            set
            {
                if (_cto_cobcop_cont == value) return;
                _cto_cobcop_cont = value;
                OnPropertyChanged("Cto_cobcop_cont");
            }
        }
        #endregion
        #region Cto_cobmod_cont: Cobro efectivo c.moderadora SI/NO
        private String _cto_cobmod_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo c.moderadora SI/NO</para>
        /// <para>NOMBRE: cto_cobmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo cuota moderadora: 1=Si 2=No (para
        /// mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public String Cto_cobmod_cont
        {
            get { return _cto_cobmod_cont; }
            set
            {
                if (_cto_cobmod_cont == value) return;
                _cto_cobmod_cont = value;
                OnPropertyChanged("Cto_cobmod_cont");
            }
        }
        #endregion
        #region Cto_cobcus_cont: Cobro efectivo cargo usuario SI/NO
        private String _cto_cobcus_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo cargo usuario SI/NO</para>
        /// <para>NOMBRE: cto_cobcus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del cargo a usuario por no cubrimiento
        /// del amparo contrato: 1=Si 2=No (para mostrar la Ventana Cobro
        /// en efectivo al Facturar)
        /// </para>
        /// </summary>
        public String Cto_cobcus_cont
        {
            get { return _cto_cobcus_cont; }
            set
            {
                if (_cto_cobcus_cont == value) return;
                _cto_cobcus_cont = value;
                OnPropertyChanged("Cto_cobcus_cont");
            }
        }
        #endregion
        #region Cto_liqcop_cont: Cobrar Copago SI/NO
        private String _cto_liqcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar Copago SI/NO</para>
        /// <para>NOMBRE: cto_liqcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Cobrar Copago: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_liqcop_cont
        {
            get { return _cto_liqcop_cont; }
            set
            {
                if (_cto_liqcop_cont == value) return;
                _cto_liqcop_cont = value;
                OnPropertyChanged("Cto_liqcop_cont");
            }
        }
        #endregion
        #region Cto_liqmod_cont: Cobrar cuota moder SI/NO
        private String _cto_liqmod_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar cuota moder SI/NO</para>
        /// <para>NOMBRE: cto_liqmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Cobrar Cuota moderadora: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_liqmod_cont
        {
            get { return _cto_liqmod_cont; }
            set
            {
                if (_cto_liqmod_cont == value) return;
                _cto_liqmod_cont = value;
                OnPropertyChanged("Cto_liqmod_cont");
            }
        }
        #endregion
        #region Cto_tiplcp_cont: Tipo copago c. moder Liquidado SI/NO
        private String _cto_tiplcp_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo copago c. moder Liquidado SI/NO</para>
        /// <para>NOMBRE: cto_tiplcp_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Tipo liquidacion copagos y cuotas moderadoras: 1= Liquidacion
        /// según Acuerdo 264 y  2= Cobrar valor fijo desde manual tarifario
        /// </para>
        /// </summary>
        public String Cto_tiplcp_cont
        {
            get { return _cto_tiplcp_cont; }
            set
            {
                if (_cto_tiplcp_cont == value) return;
                _cto_tiplcp_cont = value;
                OnPropertyChanged("Cto_tiplcp_cont");
            }
        }
        #endregion
        #region Cto_dedcop_cont: Deducción copagos
        private String _cto_dedcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Deducción copagos</para>
        /// <para>NOMBRE: cto_dedcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Deducir (descontar) copago cobrado del valor servicio : 1=Descontar
        /// copago de valor servicio  2=No descontar copago del valor servicioser
        /// </para>
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
        #region Cto_sepcon_cont: Separa Facturas por contrato SI/NO
        private String _cto_sepcon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separa Facturas por contrato SI/NO</para>
        /// <para>NOMBRE: cto_sepcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Permitir que los servicios se liquiden y se generen facturas
        /// separadas para cada contrato 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_sepcon_cont
        {
            get { return _cto_sepcon_cont; }
            set
            {
                if (_cto_sepcon_cont == value) return;
                _cto_sepcon_cont = value;
                OnPropertyChanged("Cto_sepcon_cont");
            }
        }
        #endregion
        #region Cto_posnpo_cont: Tipo servicios permitidos
        private String _cto_posnpo_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo servicios permitidos</para>
        /// <para>NOMBRE: cto_posnpo_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Servicios permitidos en factruacion 1=POS 2=NO POS 3=Ambos
        /// </para>
        /// </summary>
        public String Cto_posnpo_cont
        {
            get { return _cto_posnpo_cont; }
            set
            {
                if (_cto_posnpo_cont == value) return;
                _cto_posnpo_cont = value;
                OnPropertyChanged("Cto_posnpo_cont");
            }
        }
        #endregion
        #region Cto_genrip_cont: Generar Planos Rips
        private String _cto_genrip_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar Planos Rips</para>
        /// <para>NOMBRE: cto_genrip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Generar planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_genrip_cont
        {
            get { return _cto_genrip_cont; }
            set
            {
                if (_cto_genrip_cont == value) return;
                _cto_genrip_cont = value;
                OnPropertyChanged("Cto_genrip_cont");
            }
        }
        #endregion
        #region Cto_gcorip_cont: Generar copagos en Rips
        private String _cto_gcorip_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar copagos en Rips</para>
        /// <para>NOMBRE: cto_gcorip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Generar valores de copagos en planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_gcorip_cont
        {
            get { return _cto_gcorip_cont; }
            set
            {
                if (_cto_gcorip_cont == value) return;
                _cto_gcorip_cont = value;
                OnPropertyChanged("Cto_gcorip_cont");
            }
        }
        #endregion
        #region Sia_tipase_sita: Código tipo asegurador
        private String _sia_tipase_sita;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Código tipo asegurador</para>
        /// <para>NOMBRE: sia_tipase_sita (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Código tipo asegurador de salud:  01=Adminstradora  de Riesgos
        /// laborales 02=Entidades aseguradoras regimen subsidiado … otros
        /// </para>
        /// </summary>
        public String Sia_tipase_sita
        {
            get { return _sia_tipase_sita; }
            set
            {
                if (_sia_tipase_sita == value) return;
                _sia_tipase_sita = value;
                OnPropertyChanged("Sia_tipase_sita");
            }
        }
        #endregion
        #region Cto_gestho_cont: Horas min cobro estancia hospitalización
        private int _cto_gestho_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas min cobro estancia hospitalización</para>
        /// <para>NOMBRE: cto_gestho_cont (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Horas minimas para generar cobro estancia en hopitalización
        /// </para>
        /// </summary>
        public int Cto_gestho_cont
        {
            get { return _cto_gestho_cont; }
            set
            {
                if (_cto_gestho_cont == value) return;
                _cto_gestho_cont = value;
                OnPropertyChanged("Cto_gestho_cont");
            }
        }
        #endregion
        #region Cto_gestur_cont: Horas min cobro estancia Urgencias
        private int _cto_gestur_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas min cobro estancia Urgencias</para>
        /// <para>NOMBRE: cto_gestur_cont (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        ///Horas minimas para generar cobro estancia en Urgencias
        /// </para>
        /// </summary>
        public int Cto_gestur_cont
        {
            get { return _cto_gestur_cont; }
            set
            {
                if (_cto_gestur_cont == value) return;
                _cto_gestur_cont = value;
                OnPropertyChanged("Cto_gestur_cont");
            }
        }
        #endregion
        #region Cto_esthos_cont: Horas permanecia hospitalización
        private int _cto_esthos_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas permanecia hospitalización</para>
        /// <para>NOMBRE: cto_esthos_cont (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Numero de horas permitidas que el paciente puede permanecer
        /// recluido en estancia hospitalización
        /// </para>
        /// </summary>
        public int Cto_esthos_cont
        {
            get { return _cto_esthos_cont; }
            set
            {
                if (_cto_esthos_cont == value) return;
                _cto_esthos_cont = value;
                OnPropertyChanged("Cto_esthos_cont");
            }
        }
        #endregion
        #region Cto_esturg_cont: Horas permanecia Urgencias
        private int _cto_esturg_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas permanecia Urgencias</para>
        /// <para>NOMBRE: cto_esturg_cont (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Numero de horas permitidas que el paciente puede permanecer
        /// recluido urgencias
        /// </para>
        /// </summary>
        public int Cto_esturg_cont
        {
            get { return _cto_esturg_cont; }
            set
            {
                if (_cto_esturg_cont == value) return;
                _cto_esturg_cont = value;
                OnPropertyChanged("Cto_esturg_cont");
            }
        }
        #endregion
        #region Cto_autrad_cont: Autorización paciente admitido
        private String _cto_autrad_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente admitido</para>
        /// <para>NOMBRE: cto_autrad_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// admitidos: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_autrad_cont
        {
            get { return _cto_autrad_cont; }
            set
            {
                if (_cto_autrad_cont == value) return;
                _cto_autrad_cont = value;
                OnPropertyChanged("Cto_autrad_cont");
            }
        }
        #endregion
        #region Cto_autadh_cont: Horas para solicitar autorizacion
        private int _cto_autadh_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas para solicitar autorizacion</para>
        /// <para>NOMBRE: cto_autadh_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Numero de horas disponibles para realizar solicitud autorizacion
        /// servicios a la EPS del paciente admitido
        /// </para>
        /// </summary>
        public int Cto_autadh_cont
        {
            get { return _cto_autadh_cont; }
            set
            {
                if (_cto_autadh_cont == value) return;
                _cto_autadh_cont = value;
                OnPropertyChanged("Cto_autadh_cont");
            }
        }
        #endregion
        #region Cto_autram_cont: Autorización paciente ambulatoria
        private String _cto_autram_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente ambulatoria</para>
        /// <para>NOMBRE: cto_autram_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// en atención ambulatoria: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Cto_autram_cont
        {
            get { return _cto_autram_cont; }
            set
            {
                if (_cto_autram_cont == value) return;
                _cto_autram_cont = value;
                OnPropertyChanged("Cto_autram_cont");
            }
        }
        #endregion
        #region Cto_autamh_cont: Horas para solicitar autorizacion
        private int _cto_autamh_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas para solicitar autorizacion</para>
        /// <para>NOMBRE: cto_autamh_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Numero de horas disponibles para realizar solicitud autorizacion
        /// servicios a la EPS del paciente en atención ambulatoria
        /// </para>
        /// </summary>
        public int Cto_autamh_cont
        {
            get { return _cto_autamh_cont; }
            set
            {
                if (_cto_autamh_cont == value) return;
                _cto_autamh_cont = value;
                OnPropertyChanged("Cto_autamh_cont");
            }
        }
        #endregion
        #region Cto_serper_cont: Servicios personalizados
        private String _cto_serper_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: cto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public String Cto_serper_cont
        {
            get { return _cto_serper_cont; }
            set
            {
                if (_cto_serper_cont == value) return;
                _cto_serper_cont = value;
                OnPropertyChanged("Cto_serper_cont");
            }
        }
        #endregion
        #region Cto_idvalc_cont: Validar usuarios del contrato
        private String _cto_idvalc_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validar usuarios del contrato</para>
        /// <para>NOMBRE: cto_idvalc_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Validar identificaciones de usuarios ya atendidos en maestro
        /// usuarios del contrato: 1= Validar usuarios en maestro contrato
        /// 2 =  No validar usuarios en maestro
        /// </para>
        /// </summary>
        public String Cto_idvalc_cont
        {
            get { return _cto_idvalc_cont; }
            set
            {
                if (_cto_idvalc_cont == value) return;
                _cto_idvalc_cont = value;
                OnPropertyChanged("Cto_idvalc_cont");
            }
        }
        #endregion
        #region Cto_suminv_cont: Afectar inventarios y farmacia
        private String _cto_suminv_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Afectar inventarios y farmacia</para>
        /// <para>NOMBRE: cto_suminv_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Traer suministros medicamentos y materiales desde inventarios
        /// y afectar existencias: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_suminv_cont
        {
            get { return _cto_suminv_cont; }
            set
            {
                if (_cto_suminv_cont == value) return;
                _cto_suminv_cont = value;
                OnPropertyChanged("Cto_suminv_cont");
            }
        }
        #endregion
        #region Cto_liqvsm_cont: Tipo Valor suministro
        private String _cto_liqvsm_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo Valor suministro</para>
        /// <para>NOMBRE: cto_liqvsm_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Cuando se descarga de inventarios, liquidar valores suministro
        /// desde Manual de servicios o desde valores en inventarios: 1=Manual
        /// Servicios 2=Desde Inventarios
        /// </para>
        /// </summary>
        public String Cto_liqvsm_cont
        {
            get { return _cto_liqvsm_cont; }
            set
            {
                if (_cto_liqvsm_cont == value) return;
                _cto_liqvsm_cont = value;
                OnPropertyChanged("Cto_liqvsm_cont");
            }
        }
        #endregion
        #region Cto_topval_cont: Validación topes servicios
        private String _cto_topval_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validación topes servicios</para>
        /// <para>NOMBRE: cto_topval_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        ///Activar validacion por topes de servicios: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Cto_topval_cont
        {
            get { return _cto_topval_cont; }
            set
            {
                if (_cto_topval_cont == value) return;
                _cto_topval_cont = value;
                OnPropertyChanged("Cto_topval_cont");
            }
        }
        #endregion
        #region Cto_maxpdx_cont: Tope Proc Diagnósticos
        private int _cto_maxpdx_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc Diagnósticos</para>
        /// <para>NOMBRE: cto_maxpdx_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos de diagnostico
        /// </para>
        /// </summary>
        public int Cto_maxpdx_cont
        {
            get { return _cto_maxpdx_cont; }
            set
            {
                if (_cto_maxpdx_cont == value) return;
                _cto_maxpdx_cont = value;
                OnPropertyChanged("Cto_maxpdx_cont");
            }
        }
        #endregion
        #region Cto_maxpnq_cont: Tope Proc no quirúrgicos
        private int _cto_maxpnq_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc no quirúrgicos</para>
        /// <para>NOMBRE: cto_maxpnq_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos no quirurgicos
        /// </para>
        /// </summary>
        public int Cto_maxpnq_cont
        {
            get { return _cto_maxpnq_cont; }
            set
            {
                if (_cto_maxpnq_cont == value) return;
                _cto_maxpnq_cont = value;
                OnPropertyChanged("Cto_maxpnq_cont");
            }
        }
        #endregion
        #region Cto_maxpqx_cont: Tope Proc quirúrgicos
        private int _cto_maxpqx_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc quirúrgicos</para>
        /// <para>NOMBRE: cto_maxpqx_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos quirurgicos
        /// </para>
        /// </summary>
        public int Cto_maxpqx_cont
        {
            get { return _cto_maxpqx_cont; }
            set
            {
                if (_cto_maxpqx_cont == value) return;
                _cto_maxpqx_cont = value;
                OnPropertyChanged("Cto_maxpqx_cont");
            }
        }
        #endregion
        #region Cto_maxpyp_cont: Tope Procedimientos PyP
        private int _cto_maxpyp_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Procedimientos PyP</para>
        /// <para>NOMBRE: cto_maxpyp_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos de PyP
        /// </para>
        /// </summary>
        public int Cto_maxpyp_cont
        {
            get { return _cto_maxpyp_cont; }
            set
            {
                if (_cto_maxpyp_cont == value) return;
                _cto_maxpyp_cont = value;
                OnPropertyChanged("Cto_maxpyp_cont");
            }
        }
        #endregion
        #region Cto_maxcns_cont: Tope Consultas
        private int _cto_maxcns_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Consultas</para>
        /// <para>NOMBRE: cto_maxcns_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Consultas
        /// </para>
        /// </summary>
        public int Cto_maxcns_cont
        {
            get { return _cto_maxcns_cont; }
            set
            {
                if (_cto_maxcns_cont == value) return;
                _cto_maxcns_cont = value;
                OnPropertyChanged("Cto_maxcns_cont");
            }
        }
        #endregion
        #region Cto_maxmps_cont: Tope medicamentos pos
        private int _cto_maxmps_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope medicamentos pos</para>
        /// <para>NOMBRE: cto_maxmps_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Medicamentos pos
        /// </para>
        /// </summary>
        public int Cto_maxmps_cont
        {
            get { return _cto_maxmps_cont; }
            set
            {
                if (_cto_maxmps_cont == value) return;
                _cto_maxmps_cont = value;
                OnPropertyChanged("Cto_maxmps_cont");
            }
        }
        #endregion
        #region Cto_maxmnp_cont: Tope medicamentos no pos
        private int _cto_maxmnp_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope medicamentos no pos</para>
        /// <para>NOMBRE: cto_maxmnp_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Medicamentos no pos
        /// </para>
        /// </summary>
        public int Cto_maxmnp_cont
        {
            get { return _cto_maxmnp_cont; }
            set
            {
                if (_cto_maxmnp_cont == value) return;
                _cto_maxmnp_cont = value;
                OnPropertyChanged("Cto_maxmnp_cont");
            }
        }
        #endregion
        #region Cto_maxots_cont: Tope otros servicios
        private int _cto_maxots_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope otros servicios</para>
        /// <para>NOMBRE: cto_maxots_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo otros servicios
        /// </para>
        /// </summary>
        public int Cto_maxots_cont
        {
            get { return _cto_maxots_cont; }
            set
            {
                if (_cto_maxots_cont == value) return;
                _cto_maxots_cont = value;
                OnPropertyChanged("Cto_maxots_cont");
            }
        }
        #endregion
        #region Cto_secdet_cont: Secuencial reg detalles
        private int _cto_secdet_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: cto_secdet_cont (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros servicios del
        /// tarifario personalizados del contrato
        /// </para>
        /// </summary>
        public int Cto_secdet_cont
        {
            get { return _cto_secdet_cont; }
            set
            {
                if (_cto_secdet_cont == value) return;
                _cto_secdet_cont = value;
                OnPropertyChanged("Cto_secdet_cont");
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
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
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        #region Fcm_desman_mans: Manual tarifario
        private String _fcm_desman_mans;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
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
        #region Sia_destip_regi: Régimen Salud
        private String _sia_destip_regi;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen Salud</para>
        /// <para>NOMBRE: sia_destip_regi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción régimen de salud Contributivo, Subsidiado y otros(Resol:
        /// 3374 RIPS)
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
        #region Sia_desase_sita: Descripcion tipo
        private String _sia_desase_sita;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Descripcion tipo</para>
        /// <para>NOMBRE: sia_desase_sita (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo asegurador servicios de salud
        /// </para>
        /// </summary>
        public String Sia_desase_sita
        {
            get { return _sia_desase_sita; }
            set
            {
                if (_sia_desase_sita == value) return;
                _sia_desase_sita = value;
                OnPropertyChanged("Sia_desase_sita");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloCtomaestrocontratos tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CTO-MAE-CONTRATOS", "CTO", "Maestro de contratos");
            if (!flgBuscarCtomaescontrato(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFctomaescontrato
                    {
                        #region cargar Registro
                        cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                        cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                        cto_modeps_cont = tobjModelo.Cto_modeps_cont,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                        cto_fecico_cont = tobjModelo.Cto_fecico_cont,
                        cto_fecfco_cont = tobjModelo.Cto_fecfco_cont,
                        cto_descon_cont = tobjModelo.Cto_descon_cont,
                        fcm_codman_mans = tobjModelo.Fcm_codman_mans,
                        cto_plaben_cont = tobjModelo.Cto_plaben_cont,
                        sia_tipusu_regi = tobjModelo.Sia_tipusu_regi,
                        cto_polcon_cont = tobjModelo.Cto_polcon_cont,
                        cto_codtco_cont = tobjModelo.Cto_codtco_cont,
                        cto_tipact_cont = tobjModelo.Cto_tipact_cont,
                        cto_sepser_cont = tobjModelo.Cto_sepser_cont,
                        cto_gruite_cont = tobjModelo.Cto_gruite_cont,
                        cto_fcdian_cont = tobjModelo.Cto_fcdian_cont,
                        fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                        cto_ajupre_cont = tobjModelo.Cto_ajupre_cont,
                        cto_frecus_cont = tobjModelo.Cto_frecus_cont,
                        cto_porrec_cont = tobjModelo.Cto_porrec_cont,
                        cto_porcub_cont = tobjModelo.Cto_porcub_cont,
                        cto_cubniv_cont = tobjModelo.Cto_cubniv_cont,
                        cto_vibaud_cont = tobjModelo.Cto_vibaud_cont,
                        cto_porcn1_cont = tobjModelo.Cto_porcn1_cont,
                        cto_porcn2_cont = tobjModelo.Cto_porcn2_cont,
                        cto_porcn3_cont = tobjModelo.Cto_porcn3_cont,
                        cto_porcn4_cont = tobjModelo.Cto_porcn4_cont,
                        cto_porcn5_cont = tobjModelo.Cto_porcn5_cont,
                        cto_porcn6_cont = tobjModelo.Cto_porcn6_cont,
                        cto_totafi_cont = tobjModelo.Cto_totafi_cont,
                        cto_estcon_cont = tobjModelo.Cto_estcon_cont,
                        cto_prnord_cont = tobjModelo.Cto_prnord_cont,
                        cto_prnrca_cont = tobjModelo.Cto_prnrca_cont,
                        cto_apldes_cont = tobjModelo.Cto_apldes_cont,
                        cto_cobser_cont = tobjModelo.Cto_cobser_cont,
                        cto_cobcop_cont = tobjModelo.Cto_cobcop_cont,
                        cto_cobmod_cont = tobjModelo.Cto_cobmod_cont,
                        cto_cobcus_cont = tobjModelo.Cto_cobcus_cont,
                        cto_liqcop_cont = tobjModelo.Cto_liqcop_cont,
                        cto_liqmod_cont = tobjModelo.Cto_liqmod_cont,
                        cto_tiplcp_cont = tobjModelo.Cto_tiplcp_cont,
                        cto_dedcop_cont = tobjModelo.Cto_dedcop_cont,
                        cto_sepcon_cont = tobjModelo.Cto_sepcon_cont,
                        cto_posnpo_cont = tobjModelo.Cto_posnpo_cont,
                        cto_genrip_cont = tobjModelo.Cto_genrip_cont,
                        cto_gcorip_cont = tobjModelo.Cto_gcorip_cont,
                        sia_tipase_sita = tobjModelo.Sia_tipase_sita,
                        cto_gestho_cont = (int)tobjModelo.Cto_gestho_cont,
                        cto_gestur_cont = (int)tobjModelo.Cto_gestur_cont,
                        cto_esthos_cont = (int)tobjModelo.Cto_esthos_cont,
                        cto_esturg_cont = (int)tobjModelo.Cto_esturg_cont,
                        cto_autrad_cont = tobjModelo.Cto_autrad_cont,
                        cto_autadh_cont = (int)tobjModelo.Cto_autadh_cont,
                        cto_autram_cont = tobjModelo.Cto_autram_cont,
                        cto_autamh_cont = (int)tobjModelo.Cto_autamh_cont,
                        cto_serper_cont = tobjModelo.Cto_serper_cont,
                        cto_idvalc_cont = tobjModelo.Cto_idvalc_cont,
                        cto_suminv_cont = tobjModelo.Cto_suminv_cont,
                        cto_liqvsm_cont = tobjModelo.Cto_liqvsm_cont,
                        cto_topval_cont = tobjModelo.Cto_topval_cont,
                        cto_maxpdx_cont = tobjModelo.Cto_maxpdx_cont,
                        cto_maxpnq_cont = tobjModelo.Cto_maxpnq_cont,
                        cto_maxpqx_cont = tobjModelo.Cto_maxpqx_cont,
                        cto_maxpyp_cont = tobjModelo.Cto_maxpyp_cont,
                        cto_maxcns_cont = tobjModelo.Cto_maxcns_cont,
                        cto_maxmps_cont = tobjModelo.Cto_maxmps_cont,
                        cto_maxmnp_cont = tobjModelo.Cto_maxmnp_cont,
                        cto_maxots_cont = tobjModelo.Cto_maxots_cont,
                        cto_secdet_cont = tobjModelo.Cto_secdet_cont,
                        #endregion
                    };
                    lobjRegistro.cto_seccon_cont = lcrCodigoGen;
                    _context.AddToCtomaescontrato(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CTO-MAE-CONTRATOS': Maestro de contratos en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloCtomaestrocontratos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tobjModelo.Cto_seccon_cont);
                if (lobjRegistro != null)
                {
                    #region cargar Registro
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.cto_modeps_cont = tobjModelo.Cto_modeps_cont;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                    lobjRegistro.cto_fecico_cont = (DateTime)tobjModelo.Cto_fecico_cont;
                    lobjRegistro.cto_fecfco_cont = (DateTime)tobjModelo.Cto_fecfco_cont;
                    lobjRegistro.cto_descon_cont = tobjModelo.Cto_descon_cont;
                    lobjRegistro.fcm_codman_mans = tobjModelo.Fcm_codman_mans;
                    lobjRegistro.cto_plaben_cont = tobjModelo.Cto_plaben_cont;
                    lobjRegistro.sia_tipusu_regi = tobjModelo.Sia_tipusu_regi;
                    lobjRegistro.cto_polcon_cont = tobjModelo.Cto_polcon_cont;
                    lobjRegistro.cto_codtco_cont = tobjModelo.Cto_codtco_cont;
                    lobjRegistro.cto_tipact_cont = tobjModelo.Cto_tipact_cont;
                    lobjRegistro.cto_sepser_cont = tobjModelo.Cto_sepser_cont;
                    lobjRegistro.cto_gruite_cont = tobjModelo.Cto_gruite_cont;
                    lobjRegistro.cto_fcdian_cont = tobjModelo.Cto_fcdian_cont;
                    lobjRegistro.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                    lobjRegistro.cto_ajupre_cont = (int)tobjModelo.Cto_ajupre_cont;
                    lobjRegistro.cto_frecus_cont = tobjModelo.Cto_frecus_cont;
                    lobjRegistro.cto_porrec_cont = (float)tobjModelo.Cto_porrec_cont;
                    lobjRegistro.cto_porcub_cont = (float)tobjModelo.Cto_porcub_cont;
                    lobjRegistro.cto_cubniv_cont = tobjModelo.Cto_cubniv_cont;
                    lobjRegistro.cto_vibaud_cont = tobjModelo.Cto_vibaud_cont;
                    lobjRegistro.cto_porcn1_cont = (float)tobjModelo.Cto_porcn1_cont;
                    lobjRegistro.cto_porcn2_cont = (float)tobjModelo.Cto_porcn2_cont;
                    lobjRegistro.cto_porcn3_cont = (float)tobjModelo.Cto_porcn3_cont;
                    lobjRegistro.cto_porcn4_cont = (float)tobjModelo.Cto_porcn4_cont;
                    lobjRegistro.cto_porcn5_cont = (float)tobjModelo.Cto_porcn5_cont;
                    lobjRegistro.cto_porcn6_cont = (float)tobjModelo.Cto_porcn6_cont;
                    lobjRegistro.cto_totafi_cont = (int)tobjModelo.Cto_totafi_cont;
                    lobjRegistro.cto_estcon_cont = tobjModelo.Cto_estcon_cont;
                    lobjRegistro.cto_prnord_cont = tobjModelo.Cto_prnord_cont;
                    lobjRegistro.cto_prnrca_cont = tobjModelo.Cto_prnrca_cont;
                    lobjRegistro.cto_apldes_cont = tobjModelo.Cto_apldes_cont;
                    lobjRegistro.cto_cobser_cont = tobjModelo.Cto_cobser_cont;
                    lobjRegistro.cto_cobcop_cont = tobjModelo.Cto_cobcop_cont;
                    lobjRegistro.cto_cobmod_cont = tobjModelo.Cto_cobmod_cont;
                    lobjRegistro.cto_cobcus_cont = tobjModelo.Cto_cobcus_cont;
                    lobjRegistro.cto_liqcop_cont = tobjModelo.Cto_liqcop_cont;
                    lobjRegistro.cto_liqmod_cont = tobjModelo.Cto_liqmod_cont;
                    lobjRegistro.cto_tiplcp_cont = tobjModelo.Cto_tiplcp_cont;
                    lobjRegistro.cto_dedcop_cont = tobjModelo.Cto_dedcop_cont;
                    lobjRegistro.cto_sepcon_cont = tobjModelo.Cto_sepcon_cont;
                    lobjRegistro.cto_posnpo_cont = tobjModelo.Cto_posnpo_cont;
                    lobjRegistro.cto_genrip_cont = tobjModelo.Cto_genrip_cont;
                    lobjRegistro.cto_gcorip_cont = tobjModelo.Cto_gcorip_cont;
                    lobjRegistro.sia_tipase_sita = tobjModelo.Sia_tipase_sita;
                    lobjRegistro.cto_gestho_cont = (int)tobjModelo.Cto_gestho_cont;
                    lobjRegistro.cto_gestur_cont = (int)tobjModelo.Cto_gestur_cont;
                    lobjRegistro.cto_esthos_cont = (int)tobjModelo.Cto_esthos_cont;
                    lobjRegistro.cto_esturg_cont = (int)tobjModelo.Cto_esturg_cont;
                    lobjRegistro.cto_autrad_cont = tobjModelo.Cto_autrad_cont;
                    lobjRegistro.cto_autadh_cont = (int)tobjModelo.Cto_autadh_cont;
                    lobjRegistro.cto_autram_cont = tobjModelo.Cto_autram_cont;
                    lobjRegistro.cto_autamh_cont = (int)tobjModelo.Cto_autamh_cont;
                    lobjRegistro.cto_serper_cont = tobjModelo.Cto_serper_cont;
                    lobjRegistro.cto_idvalc_cont = tobjModelo.Cto_idvalc_cont;
                    lobjRegistro.cto_suminv_cont = tobjModelo.Cto_suminv_cont;
                    lobjRegistro.cto_liqvsm_cont = tobjModelo.Cto_liqvsm_cont;
                    lobjRegistro.cto_topval_cont = tobjModelo.Cto_topval_cont;
                    lobjRegistro.cto_maxpdx_cont = (int)tobjModelo.Cto_maxpdx_cont;
                    lobjRegistro.cto_maxpnq_cont = (int)tobjModelo.Cto_maxpnq_cont;
                    lobjRegistro.cto_maxpqx_cont = (int)tobjModelo.Cto_maxpqx_cont;
                    lobjRegistro.cto_maxpyp_cont = (int)tobjModelo.Cto_maxpyp_cont;
                    lobjRegistro.cto_maxcns_cont = (int)tobjModelo.Cto_maxcns_cont;
                    lobjRegistro.cto_maxmps_cont = (int)tobjModelo.Cto_maxmps_cont;
                    lobjRegistro.cto_maxmnp_cont = (int)tobjModelo.Cto_maxmnp_cont;
                    lobjRegistro.cto_maxots_cont = (int)tobjModelo.Cto_maxots_cont;
                    lobjRegistro.cto_secdet_cont = (int)tobjModelo.Cto_secdet_cont;
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
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar CTOMAESCONTRATO: Logica
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TITULO: Maestro contratos con  EPS o aseguradores</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de contratos con las EPS o aseguradores para servicios
        /// de salud, incluye todas las condiciones del contrato
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomaescontrato(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaescontrato.FirstOrDefault(p => p.cto_seccon_cont == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCtomaestrocontratos> flsListaCtomaescontrato(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from ctomaescontrato in _context.Ctomaescontrato
                                  join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on ctomaescontrato.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                  join siatablaeps in _context.Siatablaeps on ctomaescontrato.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                  join sismaesterceros in _context.Sismaesterceros on ctomaescontrato.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  join fcmmantarifario in _context.Fcmmantarifario on ctomaescontrato.fcm_codman_mans equals fcmmantarifario.fcm_codman_mans into tmfcmmantarifario
                                  join siaregimensalud in _context.Siaregimensalud on ctomaescontrato.sia_tipusu_regi equals siaregimensalud.sia_tipusu_regi into tmsiaregimensalud
                                  from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                  from teps in tmsiatablaeps.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  from mans in tmfcmmantarifario.DefaultIfEmpty()
                                  from regi in tmsiaregimensalud.DefaultIfEmpty()
                                  where ctomaescontrato.cto_seccon_cont == tcrBuscar
                                  select new ModeloCtomaestrocontratos
                                  {
                                      #region cargar Registro
                                      Cto_seccon_cont = ctomaescontrato.cto_seccon_cont,
                                      Cto_nrocon_cont = ctomaescontrato.cto_nrocon_cont,
                                      Cto_modeps_cont = ctomaescontrato.cto_modeps_cont,
                                      Sia_codeps_teps = ctomaescontrato.sia_codeps_teps,
                                      Sis_idterc_sitr = ctomaescontrato.sis_idterc_sitr,
                                      Cto_fecico_cont = (DateTime)ctomaescontrato.cto_fecico_cont,
                                      Cto_fecfco_cont = (DateTime)ctomaescontrato.cto_fecfco_cont,
                                      Cto_descon_cont = ctomaescontrato.cto_descon_cont,
                                      Fcm_codman_mans = ctomaescontrato.fcm_codman_mans,
                                      Cto_plaben_cont = ctomaescontrato.cto_plaben_cont,
                                      Sia_tipusu_regi = ctomaescontrato.sia_tipusu_regi,
                                      Cto_polcon_cont = ctomaescontrato.cto_polcon_cont,
                                      Cto_codtco_cont = ctomaescontrato.cto_codtco_cont,
                                      Cto_tipact_cont = ctomaescontrato.cto_tipact_cont,
                                      Cto_sepser_cont = ctomaescontrato.cto_sepser_cont,
                                      Cto_gruite_cont = ctomaescontrato.cto_gruite_cont,
                                      Cto_fcdian_cont = ctomaescontrato.cto_fcdian_cont,
                                      Fcm_secraz_fcem = ctomaescontrato.fcm_secraz_fcem,
                                      Cto_ajupre_cont = (int)ctomaescontrato.cto_ajupre_cont,
                                      Cto_frecus_cont = ctomaescontrato.cto_frecus_cont,
                                      Cto_porrec_cont = (float)ctomaescontrato.cto_porrec_cont,
                                      Cto_porcub_cont = (float)ctomaescontrato.cto_porcub_cont,
                                      Cto_cubniv_cont = ctomaescontrato.cto_cubniv_cont,
                                      Cto_vibaud_cont = ctomaescontrato.cto_vibaud_cont,
                                      Cto_porcn1_cont = (float)ctomaescontrato.cto_porcn1_cont,
                                      Cto_porcn2_cont = (float)ctomaescontrato.cto_porcn2_cont,
                                      Cto_porcn3_cont = (float)ctomaescontrato.cto_porcn3_cont,
                                      Cto_porcn4_cont = (float)ctomaescontrato.cto_porcn4_cont,
                                      Cto_porcn5_cont = (float)ctomaescontrato.cto_porcn5_cont,
                                      Cto_porcn6_cont = (float)ctomaescontrato.cto_porcn6_cont,
                                      Cto_totafi_cont = (int)ctomaescontrato.cto_totafi_cont,
                                      Cto_estcon_cont = ctomaescontrato.cto_estcon_cont,
                                      Cto_prnord_cont = ctomaescontrato.cto_prnord_cont,
                                      Cto_prnrca_cont = ctomaescontrato.cto_prnrca_cont,
                                      Cto_apldes_cont = ctomaescontrato.cto_apldes_cont,
                                      Cto_cobser_cont = ctomaescontrato.cto_cobser_cont,
                                      Cto_cobcop_cont = ctomaescontrato.cto_cobcop_cont,
                                      Cto_cobmod_cont = ctomaescontrato.cto_cobmod_cont,
                                      Cto_cobcus_cont = ctomaescontrato.cto_cobcus_cont,
                                      Cto_liqcop_cont = ctomaescontrato.cto_liqcop_cont,
                                      Cto_liqmod_cont = ctomaescontrato.cto_liqmod_cont,
                                      Cto_tiplcp_cont = ctomaescontrato.cto_tiplcp_cont,
                                      Cto_dedcop_cont = ctomaescontrato.cto_dedcop_cont,
                                      Cto_sepcon_cont = ctomaescontrato.cto_sepcon_cont,
                                      Cto_posnpo_cont = ctomaescontrato.cto_posnpo_cont,
                                      Cto_genrip_cont = ctomaescontrato.cto_genrip_cont,
                                      Cto_gcorip_cont = ctomaescontrato.cto_gcorip_cont,
                                      Sia_tipase_sita = ctomaescontrato.sia_tipase_sita,
                                      Cto_gestho_cont = (int)ctomaescontrato.cto_gestho_cont,
                                      Cto_gestur_cont = (int)ctomaescontrato.cto_gestur_cont,
                                      Cto_esthos_cont = (int)ctomaescontrato.cto_esthos_cont,
                                      Cto_esturg_cont = (int)ctomaescontrato.cto_esturg_cont,
                                      Cto_autrad_cont =  ctomaescontrato.cto_autrad_cont,
                                      Cto_autadh_cont = (int)ctomaescontrato.cto_autadh_cont,
                                      Cto_autram_cont = ctomaescontrato.cto_autram_cont,
                                      Cto_autamh_cont = (int)ctomaescontrato.cto_autamh_cont,
                                      Cto_serper_cont = ctomaescontrato.cto_serper_cont,
                                      Cto_idvalc_cont = ctomaescontrato.cto_idvalc_cont,
                                      Cto_suminv_cont = ctomaescontrato.cto_suminv_cont,
                                      Cto_liqvsm_cont = ctomaescontrato.cto_liqvsm_cont,
                                      Cto_topval_cont = ctomaescontrato.cto_topval_cont,
                                      Cto_maxpdx_cont = (int)ctomaescontrato.cto_maxpdx_cont,
                                      Cto_maxpnq_cont = (int)ctomaescontrato.cto_maxpnq_cont,
                                      Cto_maxpqx_cont = (int)ctomaescontrato.cto_maxpqx_cont,
                                      Cto_maxpyp_cont = (int)ctomaescontrato.cto_maxpyp_cont,
                                      Cto_maxcns_cont = (int)ctomaescontrato.cto_maxcns_cont,
                                      Cto_maxmps_cont = (int)ctomaescontrato.cto_maxmps_cont,
                                      Cto_maxmnp_cont = (int)ctomaescontrato.cto_maxmnp_cont,
                                      Cto_maxots_cont = (int)ctomaescontrato.cto_maxots_cont,
                                      Cto_secdet_cont = (int)ctomaescontrato.cto_secdet_cont,
                                      Fcm_numdoc_fcem = fcem.fcm_numdoc_fcem,
                                      Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                      Sia_deseps_teps = teps.sia_deseps_teps,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      Fcm_desman_mans = mans.fcm_desman_mans,
                                      Sia_destip_regi = regi.sia_destip_regi,
                                      Sia_desase_sita = _context.Siatipoasegurad.FirstOrDefault(rxp => rxp.sia_tipase_sita == ctomaescontrato.sia_tipase_sita).sia_desase_sita,
                                      #endregion cargar Registro
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: ctomanservicios
    /// </summary>
    public class ModeloCtomanservicios : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cto_idesec_cspr: Código único reg. servicio
        private String _cto_idesec_cspr;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: ctomanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: cto_idesec_cspr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio personalizado  (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Cto_idesec_cspr
        {
            get { return _cto_idesec_cspr; }
            set
            {
                if (_cto_idesec_cspr == value) return;
                _cto_idesec_cspr = value;
                OnPropertyChanged("Cto_idesec_cspr");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial Unico de Contrato al cual pertenece el servicio
        /// personalizado
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
        #region Fcm_codman_mans: Código manual servicios
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejm: 01=SOAT mas el 10 para la empresa XX
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
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_mant (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor recargo nocturno</para>
        /// <para>NOMBRE: fcm_valren_mant (int:14)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Fcm_tipccp_mant: Tipo liquidación copagos
        private String _fcm_tipccp_mant;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: fcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor fijo Copagos c.mod</para>
        /// <para>NOMBRE: fcm_vficop_mant (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Fcm_facvmc_mant: Valores en cero SI/NO
        private String _fcm_facvmc_mant;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: fcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Fcm_estser_mant: Estado del servicio
        private String _fcm_estser_mant;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: fcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
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
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
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
        /// <para>TABLA: ctomanservicios</para>
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
        #region Fcm_codtar_ttar: Manual tarifario
        private String _fcm_codtar_ttar;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Codigo tipo manual tarifario</para>
        /// <para>NOMBRE: G2Fcm_codtar_ttar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo tipo manual tarifario 1=SOAT 2=ISS 3=CUPS</para>
        /// </summary>
        public String Fcm_codtar_ttar
        {
            get { return _fcm_codtar_ttar; }
            set
            {
                if (_fcm_codtar_ttar == value) return;
                _fcm_codtar_ttar = value;
                OnPropertyChanged("Fcm_codtar_ttar");
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
        public static bool flgAddRegistro(ModeloCtomanservicios tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFctomanservicios();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tobTempReg.Cto_idesec_cspr);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.cto_idesec_cspr = tobTempReg.Cto_idesec_cspr;
                            lobEFReg.cto_seccon_cont = tobTempReg.Cto_seccon_cont;
                            lobEFReg.fcm_codman_mans = tobTempReg.Fcm_codman_mans;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.fcm_codser_mant = tobTempReg.Fcm_codser_mant;
                            lobEFReg.fcm_desser_mant = tobTempReg.Fcm_desser_mant;
                            lobEFReg.fcm_valser_mant = (float)tobTempReg.Fcm_valser_mant;
                            lobEFReg.fcm_punuvr_mant = (float)tobTempReg.Fcm_punuvr_mant;
                            lobEFReg.fcm_valren_mant = (int)tobTempReg.Fcm_valren_mant;
                            lobEFReg.fcm_tipccp_mant = tobTempReg.Fcm_tipccp_mant;
                            lobEFReg.fcm_vficop_mant = (int)tobTempReg.Fcm_vficop_mant;
                            lobEFReg.fcm_facvmc_mant = tobTempReg.Fcm_facvmc_mant;
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
                                lobEFReg.cto_idesec_cspr = tcrCodigoR1.Trim() + lobEFReg.cto_idesec_cspr; // concatenar
                                _context.AddToCtomanservicios(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tobTempReg.Cto_idesec_cspr);
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
        #region Buscar CTOMANSERVICIOS: Logica
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TITULO: Manual ventas servicios personalizados</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro servicios personalizados en cada contrato  para ventas,
        /// derivados de SERVICIOS IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomanservicios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomanservicios.FirstOrDefault(p => p.cto_idesec_cspr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCtomanservicios> flsListaCtomanservicios(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from ctomanservicios in _context.Ctomanservicios
                                  join fcmmanservicips in _context.Fcmmanservicips on ctomanservicios.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  join fcmmantarifario in _context.Fcmmantarifario on ctomanservicios.fcm_codman_mans equals fcmmantarifario.fcm_codman_mans into tmfcmmantarifario
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  from mans in tmfcmmantarifario.DefaultIfEmpty()
                                  where ctomanservicios.cto_seccon_cont == tcrBuscar
                                  select new ModeloCtomanservicios
                                  {
                                      Cto_idesec_cspr = ctomanservicios.cto_idesec_cspr,
                                      Cto_seccon_cont = ctomanservicios.cto_seccon_cont,
                                      Fcm_codman_mans = ctomanservicios.fcm_codman_mans,
                                      Fcm_idesec_sips = ctomanservicios.fcm_idesec_sips,
                                      Fcm_coddig_mant = ctomanservicios.fcm_coddig_mant,
                                      Fcm_codser_mant = ctomanservicios.fcm_codser_mant,
                                      Fcm_desser_mant = ctomanservicios.fcm_desser_mant,
                                      Fcm_valser_mant = (float)ctomanservicios.fcm_valser_mant,
                                      Fcm_punuvr_mant = (float)ctomanservicios.fcm_punuvr_mant,
                                      Fcm_valren_mant = (int)ctomanservicios.fcm_valren_mant,
                                      Fcm_tipccp_mant = ctomanservicios.fcm_tipccp_mant,
                                      Fcm_vficop_mant = (int)ctomanservicios.fcm_vficop_mant,
                                      Fcm_facvmc_mant = ctomanservicios.fcm_facvmc_mant,
                                      Fcm_estser_mant = ctomanservicios.fcm_estser_mant,
                                      Fcm_desman_mans = mans.fcm_desman_mans,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Fcm_codtar_ttar = "",
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
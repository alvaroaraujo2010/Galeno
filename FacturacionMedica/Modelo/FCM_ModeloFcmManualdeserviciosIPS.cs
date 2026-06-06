//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2015 11:09:18 AM
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
    /// Descripcion para la Vista de  la tabla: fcmmanservicips
    /// </summary>
    public class ModeloFcmManualdeserviciosIPS : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado (generado
        /// por el sistema)
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
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public String Fcm_codser_sips
        {
            get { return _fcm_codser_sips; }
            set
            {
                if (_fcm_codser_sips == value) return;
                _fcm_codser_sips = value;
                OnPropertyChanged("Fcm_codser_sips");
            }
        }
        #endregion
        #region Fcm_codser_soat: Codigo SOAT
        private String _fcm_codser_soat;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Codigo SOAT</para>
        /// <para>NOMBRE: fcm_codser_soat (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo SOAT del servicio para gestion de actualizacion de precios
        /// </para>
        /// </summary>
        public String Fcm_codser_soat
        {
            get { return _fcm_codser_soat; }
            set
            {
                if (_fcm_codser_soat == value) return;
                _fcm_codser_soat = value;
                OnPropertyChanged("Fcm_codser_soat");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Fcm_codbar_sips: Código de Barras
        private String _fcm_codbar_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region Fcm_codcum_sips: Código CUM
        private String _fcm_codcum_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: fcm_codcum_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo CUM del medicamento
        /// </para>
        /// </summary>
        public String Fcm_codcum_sips
        {
            get { return _fcm_codcum_sips; }
            set
            {
                if (_fcm_codcum_sips == value) return;
                _fcm_codcum_sips = value;
                OnPropertyChanged("Fcm_codcum_sips");
            }
        }
        #endregion
        #region Fcm_idesec_fcct: Código categoria
        private String _fcm_idesec_fcct;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicate</para>
        /// <para>CAMPO: Código categoria</para>
        /// <para>NOMBRE: fcm_idesec_fcct (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCIÓN: Codigo categoria del servicio IPS</para>
        /// </summary>
        public String Fcm_idesec_fcct
        {
            get { return _fcm_idesec_fcct; }
            set
            {
                if (_fcm_idesec_fcct == value) return;
                _fcm_idesec_fcct = value;
                OnPropertyChanged("Fcm_idesec_fcct");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region Fcm_punuvr_sips: Puntaje o UVR
        private float _fcm_punuvr_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: fcm_punuvr_sips (float:126)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float Fcm_punuvr_sips
        {
            get { return _fcm_punuvr_sips; }
            set
            {
                if (_fcm_punuvr_sips == value) return;
                _fcm_punuvr_sips = value;
                OnPropertyChanged("Fcm_punuvr_sips");
            }
        }
        #endregion
        #region Fcm_valser_sips: Valor de servicio
        private float _fcm_valser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_sips (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
        /// </para>
        /// </summary>
        public float Fcm_valser_sips
        {
            get { return _fcm_valser_sips; }
            set
            {
                if (_fcm_valser_sips == value) return;
                _fcm_valser_sips = value;
                OnPropertyChanged("Fcm_valser_sips");
            }
        }
        #endregion
        #region Fcm_edtval_sips: Editar valor servicio
        private String _fcm_edtval_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Editar valor servicio</para>
        /// <para>NOMBRE: fcm_edtval_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Editar el valor del servicio en la vista de factruacion, sin
        /// tener en cuenta el proceso de liquidacion del tarifario 1=SI
        /// 2=No
        /// </para>
        /// </summary>
        public String Fcm_edtval_sips
        {
            get { return _fcm_edtval_sips; }
            set
            {
                if (_fcm_edtval_sips == value) return;
                _fcm_edtval_sips = value;
                OnPropertyChanged("Fcm_edtval_sips");
            }
        }
        #endregion
        #region Fcm_lamccp_sips: Ambulatoria Copago C.moderad
        private String _fcm_lamccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Ambulatoria Copago C.moderad</para>
        /// <para>NOMBRE: fcm_lamccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion ambulatoria:
        /// 1= Copago 2= Cuota moderadora 3= Copago o C.Moderadora 4=Ningun cobro
        /// </para>
        /// </summary>
        public String Fcm_lamccp_sips
        {
            get { return _fcm_lamccp_sips; }
            set
            {
                if (_fcm_lamccp_sips == value) return;
                _fcm_lamccp_sips = value;
                OnPropertyChanged("Fcm_lamccp_sips");
            }
        }
        #endregion
        #region Fcm_lhoccp_sips: Hospitalización Copago C.moderad
        private String _fcm_lhoccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Hospitalización Copago C.moderad</para>
        /// <para>NOMBRE: fcm_lhoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion hospitalizacion:
        /// 1= Copago 2= Cuota moderadora 3= Copago o C.Moderadora 4=Ningun cobro
        /// </para>
        /// </summary>
        public String Fcm_lhoccp_sips
        {
            get { return _fcm_lhoccp_sips; }
            set
            {
                if (_fcm_lhoccp_sips == value) return;
                _fcm_lhoccp_sips = value;
                OnPropertyChanged("Fcm_lhoccp_sips");
            }
        }
        #endregion
        #region Fcm_luoccp_sips: Urgencias Copago C.moderad
        private String _fcm_luoccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Urgencias Copago C.moderad</para>
        /// <para>NOMBRE: fcm_luoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion urgencias:
        /// 1= Copago 2= Cuota moderadora 3= Copago o C.Moderadora 4=Ningun cobro
        /// </para>
        /// </summary>
        public String Fcm_luoccp_sips
        {
            get { return _fcm_luoccp_sips; }
            set
            {
                if (_fcm_luoccp_sips == value) return;
                _fcm_luoccp_sips = value;
                OnPropertyChanged("Fcm_luoccp_sips");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de producción al cual esta asociado el servicio
        /// por defecto
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
        #region Sia_codfpr_fpro: Finalidad Procedimiento
        private String _sia_codfpr_fpro;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: sia_codfpr_fpro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public String Sia_codfpr_fpro
        {
            get { return _sia_codfpr_fpro; }
            set
            {
                if (_sia_codfpr_fpro == value) return;
                _sia_codfpr_fpro = value;
                OnPropertyChanged("Sia_codfpr_fpro");
            }
        }
        #endregion
        #region Sia_codfco_fcon: Finalidad consulta
        private String _sia_codfco_fcon;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta: 01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas según Resolucion 3374RIPS
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
        private String _adm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución: 3374 RIPS 
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
        #region Fcm_mededi_sips: Medida edad Inicial
        private String _fcm_mededi_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: fcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_mededi_sips
        {
            get { return _fcm_mededi_sips; }
            set
            {
                if (_fcm_mededi_sips == value) return;
                _fcm_mededi_sips = value;
                OnPropertyChanged("Fcm_mededi_sips");
            }
        }
        #endregion
        #region Fcm_edaini_sips: Edad Inicial
        private int _fcm_edaini_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: fcm_edaini_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Fcm_edaini_sips
        {
            get { return _fcm_edaini_sips; }
            set
            {
                if (_fcm_edaini_sips == value) return;
                _fcm_edaini_sips = value;
                OnPropertyChanged("Fcm_edaini_sips");
            }
        }
        #endregion
        #region Fcm_mededf_sips: Medida edad final
        private String _fcm_mededf_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: fcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Fcm_mededf_sips
        {
            get { return _fcm_mededf_sips; }
            set
            {
                if (_fcm_mededf_sips == value) return;
                _fcm_mededf_sips = value;
                OnPropertyChanged("Fcm_mededf_sips");
            }
        }
        #endregion
        #region Fcm_edafin_sips: Edad final
        private int _fcm_edafin_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: fcm_edafin_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Fcm_edafin_sips
        {
            get { return _fcm_edafin_sips; }
            set
            {
                if (_fcm_edafin_sips == value) return;
                _fcm_edafin_sips = value;
                OnPropertyChanged("Fcm_edafin_sips");
            }
        }
        #endregion
        #region Fcm_mededp_sips: Medida edad puntual
        private String _fcm_mededp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad puntual</para>
        /// <para>NOMBRE: fcm_mededp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Medida edad puntual la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días,4=No Aplica edad puntual
        /// </para>
        /// </summary>
        public String Fcm_mededp_sips
        {
            get { return _fcm_mededp_sips; }
            set
            {
                if (_fcm_mededp_sips == value) return;
                _fcm_mededp_sips = value;
                OnPropertyChanged("Fcm_mededp_sips");
            }
        }
        #endregion
        #region Fcm_edapun_sips: Lista edad puntual
        private String _fcm_edapun_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista edad puntual</para>
        /// <para>NOMBRE: fcm_edapun_sips (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Edad puntal para la cual aplica la validación de pertinencia,
        /// separados por punto y coma (;) , Adulto mayor ejemplo: 45;50;55;60;65;70+
        /// (el signo mas es para el resto de 70 en adelante)
        /// </para>
        /// </summary>
        public String Fcm_edapun_sips
        {
            get { return _fcm_edapun_sips; }
            set
            {
                if (_fcm_edapun_sips == value) return;
                _fcm_edapun_sips = value;
                OnPropertyChanged("Fcm_edapun_sips");
            }
        }
        #endregion
        #region Fcm_sexapl_sips: Sexo que aplica
        private String _fcm_sexapl_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: fcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio: 1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public String Fcm_sexapl_sips
        {
            get { return _fcm_sexapl_sips; }
            set
            {
                if (_fcm_sexapl_sips == value) return;
                _fcm_sexapl_sips = value;
                OnPropertyChanged("Fcm_sexapl_sips");
            }
        }
        #endregion
        #region Fcm_nivcom_sips: Nivel de complejidad
        private String _fcm_nivcom_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nivel de complejidad</para>
        /// <para>NOMBRE: fcm_nivcom_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Nivel de complejidad del servicio: 1,2,3,4 5,y 6
        /// </para>
        /// </summary>
        public String Fcm_nivcom_sips
        {
            get { return _fcm_nivcom_sips; }
            set
            {
                if (_fcm_nivcom_sips == value) return;
                _fcm_nivcom_sips = value;
                OnPropertyChanged("Fcm_nivcom_sips");
            }
        }
        #endregion
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region Fcm_semeps_sips: Semanas cotizadas
        private int _fcm_semeps_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Semanas cotizadas</para>
        /// <para>NOMBRE: fcm_semeps_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Semanas minimas cotizadas en la EPS para acceder al servicio
        /// </para>
        /// </summary>
        public int Fcm_semeps_sips
        {
            get { return _fcm_semeps_sips; }
            set
            {
                if (_fcm_semeps_sips == value) return;
                _fcm_semeps_sips = value;
                OnPropertyChanged("Fcm_semeps_sips");
            }
        }
        #endregion
        #region Fcm_semsss_sips: Semanas en SSS
        private int _fcm_semsss_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Semanas en SSS</para>
        /// <para>NOMBRE: fcm_semsss_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Semanas minimas cotizadas en SSS para acceder al servicio
        /// </para>
        /// </summary>
        public int Fcm_semsss_sips
        {
            get { return _fcm_semsss_sips; }
            set
            {
                if (_fcm_semsss_sips == value) return;
                _fcm_semsss_sips = value;
                OnPropertyChanged("Fcm_semsss_sips");
            }
        }
        #endregion
        #region Fcm_aplfus_sips: Frecuencia de uso
        private String _fcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Intervalos días orden servicio</para>
        /// <para>NOMBRE: fcm_intser_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Intervalo en dias para la nueva orden del servicio ejm: cada
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
        #region Fcm_perfus_sips: Periodo frecuencia de uso
        private String _fcm_perfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Periodo frecuencia de uso</para>
        /// <para>NOMBRE: fcm_perfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Periodo en el que aplicar frecuencia de uso servicio: 1=Aplica
        /// el corte en año calendario 2=Hasta que se cumpla la Fecha nueva
        /// de uso
        /// </para>
        /// </summary>
        public String Fcm_perfus_sips
        {
            get { return _fcm_perfus_sips; }
            set
            {
                if (_fcm_perfus_sips == value) return;
                _fcm_perfus_sips = value;
                OnPropertyChanged("Fcm_perfus_sips");
            }
        }
        #endregion
        #region Fcm_maxord_sips: Cantidad orden facturación
        private int _fcm_maxord_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Cantidad orden facturación</para>
        /// <para>NOMBRE: fcm_maxord_sips (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Cantidad maxima por orden en un registro de facturacion del
        /// servicio o suministro
        /// </para>
        /// </summary>
        public int Fcm_maxord_sips
        {
            get { return _fcm_maxord_sips; }
            set
            {
                if (_fcm_maxord_sips == value) return;
                _fcm_maxord_sips = value;
                OnPropertyChanged("Fcm_maxord_sips");
            }
        }
        #endregion
        #region Fcm_maxint_sips: Cantidad máxima intervalo
        private int _fcm_maxint_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Cantidad máxima intervalo</para>
        /// <para>NOMBRE: fcm_maxint_sips (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Cantidad maxima dentro del intervalo de dias ejm: en 90 dias
        /// solo se pude facturar 2 veces es decir canmax= 2
        /// </para>
        /// </summary>
        public int Fcm_maxint_sips
        {
            get { return _fcm_maxint_sips; }
            set
            {
                if (_fcm_maxint_sips == value) return;
                _fcm_maxint_sips = value;
                OnPropertyChanged("Fcm_maxint_sips");
            }
        }
        #endregion
        #region Sis_codiva_tiva: IVA Aplicado
        private String _sis_codiva_tiva;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: IVA Aplicado</para>
        /// <para>NOMBRE: sis_codiva_tiva (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Codigo del porcentaje de Iva que se aplicara al servicio
        /// </para>
        /// </summary>
        public String Sis_codiva_tiva
        {
            get { return _sis_codiva_tiva; }
            set
            {
                if (_sis_codiva_tiva == value) return;
                _sis_codiva_tiva = value;
                OnPropertyChanged("Sis_codiva_tiva");
            }
        }
        #endregion
        #region Sia_tipact_tsac: Tipo Servicio o actividad
        private String _sia_tipact_tsac;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo Servicio o actividad</para>
        /// <para>NOMBRE: sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region Fcm_otserv_sips: Tipo Rips otros servicios
        private String _fcm_otserv_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
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
        #region Fcm_forfar_sips: Forma farmacéutica
        private String _fcm_forfar_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
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
        #region Fcm_conmed_sips: Concentración
        private String _fcm_conmed_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
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
        private String _fcm_unimed_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
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
        #region Sia_codpat_tpat: Tipo de profesional
        private String _sia_codpat_tpat;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        #region Fcm_serpos_sips: Servicio POS/NO POS
        private String _fcm_serpos_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        #region Fcm_tipser_sips: Servicio o Suministro
        private String _fcm_tipser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        #region Fcm_numuni_sips: Total Unidades
        private int _fcm_numuni_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: fcm_numuni_sips (int:17)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Numero de unidades descargadas desd almacen
        /// </para>
        /// </summary>
        public int Fcm_numuni_sips
        {
            get { return _fcm_numuni_sips; }
            set
            {
                if (_fcm_numuni_sips == value) return;
                _fcm_numuni_sips = value;
                OnPropertyChanged("Fcm_numuni_sips");
            }
        }
        #endregion
        #region Ssp_codcam_resc: Campo Resolucion 4505
        private String _ssp_codcam_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo Resolucion 4505</para>
        /// <para>NOMBRE: ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Campo o nombre al cual aplica para informe 4505  (ejemplo:
        /// SSP_CAM025_SPRO)
        /// </para>
        /// </summary>
        public String Ssp_codcam_resc
        {
            get { return _ssp_codcam_resc; }
            set
            {
                if (_ssp_codcam_resc == value) return;
                _ssp_codcam_resc = value;
                OnPropertyChanged("Ssp_codcam_resc");
            }
        }
        #endregion
        #region Ssp_tipval_resc: Tipo de Valor
        private String _ssp_tipval_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: ssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico
        /// </para>
        /// </summary>
        public String Ssp_tipval_resc
        {
            get { return _ssp_tipval_resc; }
            set
            {
                if (_ssp_tipval_resc == value) return;
                _ssp_tipval_resc = value;
                OnPropertyChanged("Ssp_tipval_resc");
            }
        }
        #endregion
        #region Ssp_camdig_resc: Campo digitable
        private String _ssp_camdig_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: ssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Ssp_camdig_resc
        {
            get { return _ssp_camdig_resc; }
            set
            {
                if (_ssp_camdig_resc == value) return;
                _ssp_camdig_resc = value;
                OnPropertyChanged("Ssp_camdig_resc");
            }
        }
        #endregion
        #region Ssp_valper_resc: Valor Permitido
        private String _ssp_valper_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: ssp_valper_resc (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valore permitido o reportado al momento de facturar el servicio
        /// (cuando es digitable debe estar vacio)
        /// </para>
        /// </summary>
        public String Ssp_valper_resc
        {
            get { return _ssp_valper_resc; }
            set
            {
                if (_ssp_valper_resc == value) return;
                _ssp_valper_resc = value;
                OnPropertyChanged("Ssp_valper_resc");
            }
        }
        #endregion
        #region Fcm_genhis_sips: Registrar actividad
        private String _fcm_genhis_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: fcm_genhis_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public String Fcm_genhis_sips
        {
            get { return _fcm_genhis_sips; }
            set
            {
                if (_fcm_genhis_sips == value) return;
                _fcm_genhis_sips = value;
                OnPropertyChanged("Fcm_genhis_sips");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla historia clinica asociada al programa
        /// o centro de produccion para generar registro actividad en historia
        /// clinica
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Hcl_codreg_hcca: Tipo Registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad medica ejemplo: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia y otras
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
        #region Sia_coddia_tdia: Codigo Diagnostico
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo Diagnostico</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        ///Codgo del diagnostico según la tabla CIE-10
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
        #region Sia_tipdxp_tdix: Tipo diagnostico principal
        private String _sia_tipdxp_tdix;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Tipo diagnostico principal: segun CIE 10: 1=impresion diagnostica
        /// 2=Confirmado nuevo 3=Confirmado repetido
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
        #region Fcm_coddia_sips: Lista diagnosticos
        private String _fcm_coddia_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista diagnosticos</para>
        /// <para>NOMBRE: fcm_coddia_sips (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Lista de diagnosticos CIE -10 permitidos, separados por punto
        /// y coma (;) para validacion en prestacion de servicios y  Gestion
        /// foramtos de Historias clinicas
        /// </para>
        /// </summary>
        public String Fcm_coddia_sips
        {
            get { return _fcm_coddia_sips; }
            set
            {
                if (_fcm_coddia_sips == value) return;
                _fcm_coddia_sips = value;
                OnPropertyChanged("Fcm_coddia_sips");
            }
        }
        #endregion
        #region Fcm_codpro_fcpr: Codigo Producto
        private String _fcm_codpro_fcpr;
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Codigo Producto</para>
        /// <para>NOMBRE: fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo Producto UNSPSC
        /// </para>
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
        #region Fcm_estser_sips: Estado del servicio
        private String _fcm_estser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: fcm_estser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Fcm_estser_sips
        {
            get { return _fcm_estser_sips; }
            set
            {
                if (_fcm_estser_sips == value) return;
                _fcm_estser_sips = value;
                OnPropertyChanged("Fcm_estser_sips");
            }
        }
        #endregion
        #region Fcm_descat_fcct: Nombre Categoria
        private String _fcm_descat_fcct;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicate</para>
        /// <para>CAMPO: Nombre Categoria</para>
        /// <para>NOMBRE: fcm_descat_fcct (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: Descripcion Categoria de servicios IPS</para>
        /// </summary>
        public String Fcm_descat_fcct
        {
            get { return _fcm_descat_fcct; }
            set
            {
                if (_fcm_descat_fcct == value) return;
                _fcm_descat_fcct = value;
                OnPropertyChanged("Fcm_descat_fcct");
            }
        }
        #endregion
        #region Fcm_desman_soat: Descripcion servicio
        private String _fcm_desman_soat;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Descripcion servicio</para>
        /// <para>NOMBRE: fcm_desman_soat (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del servicio
        /// </para>
        /// </summary>
        public String Fcm_desman_soat
        {
            get { return _fcm_desman_soat; }
            set
            {
                if (_fcm_desman_soat == value) return;
                _fcm_desman_soat = value;
                OnPropertyChanged("Fcm_desman_soat");
            }
        }
        #endregion
        #region Fcm_desgqx_grqx: Grupo Quirúrgico
        private String _fcm_desgqx_grqx;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmgrquirurgico</para>
        /// <para>CAMPO: Grupo Quirúrgico</para>
        /// <para>NOMBRE: fcm_desgqx_grqx (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// DescripciónGrupo quirurgico (para servicios a que aplique)según
        /// manual SOAT o ISS
        /// </para>
        /// </summary>
        public String Fcm_desgqx_grqx
        {
            get { return _fcm_desgqx_grqx; }
            set
            {
                if (_fcm_desgqx_grqx == value) return;
                _fcm_desgqx_grqx = value;
                OnPropertyChanged("Fcm_desgqx_grqx");
            }
        }
        #endregion
        #region Sia_desfpr_fpro: Descripción Procedimiento
        private String _sia_desfpr_fpro;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfpr_fpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Procedimiento
        /// </para>
        /// </summary>
        public String Sia_desfpr_fpro
        {
            get { return _sia_desfpr_fpro; }
            set
            {
                if (_sia_desfpr_fpro == value) return;
                _sia_desfpr_fpro = value;
                OnPropertyChanged("Sia_desfpr_fpro");
            }
        }
        #endregion
        #region Sia_desfco_fcon: Descripción finalidad consulta
        private String _sia_desfco_fcon;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad consulta
        /// </para>
        /// </summary>
        public String Sia_desfco_fcon
        {
            get { return _sia_desfco_fcon; }
            set
            {
                if (_sia_desfco_fcon == value) return;
                _sia_desfco_fcon = value;
                OnPropertyChanged("Sia_desfco_fcon");
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
        #region Sis_desiva_tiva: Descripción del I.V.A
        private String _sis_desiva_tiva;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Descripción del I.V.A</para>
        /// <para>NOMBRE: sis_desiva_tiva (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del I.V.A Ejemplo 16%
        /// </para>
        /// </summary>
        public String Sis_desiva_tiva
        {
            get { return _sis_desiva_tiva; }
            set
            {
                if (_sis_desiva_tiva == value) return;
                _sis_desiva_tiva = value;
                OnPropertyChanged("Sis_desiva_tiva");
            }
        }
        #endregion
        #region Inv_desart_mart: Descripción Artículo
        private String _inv_desart_mart;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Descripción Artículo</para>
        /// <para>NOMBRE: inv_desart_mart (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción del artículos
        /// </para>
        /// </summary>
        public String Inv_desart_mart
        {
            get { return _inv_desart_mart; }
            set
            {
                if (_inv_desart_mart == value) return;
                _inv_desart_mart = value;
                OnPropertyChanged("Inv_desart_mart");
            }
        }
        #endregion
        #region Ssp_nomcam_resc: Titulo o Etiqueta
        private String _ssp_nomcam_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: ssp_nomcam_resc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Etiqueta del campo (descripcion campo)
        /// </para>
        /// </summary>
        public String Ssp_nomcam_resc
        {
            get { return _ssp_nomcam_resc; }
            set
            {
                if (_ssp_nomcam_resc == value) return;
                _ssp_nomcam_resc = value;
                OnPropertyChanged("Ssp_nomcam_resc");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:80)</para>
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
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcca
        {
            get { return _hcl_desreg_hcca; }
            set
            {
                if (_hcl_desreg_hcca == value) return;
                _hcl_desreg_hcca = value;
                OnPropertyChanged("Hcl_desreg_hcca");
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
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        /// <para>TABLA: fcmmanservicips</para>
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
        #region Adm_descex_tcex: Descripcion diagnostico
        private String _adm_descex_tcex;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Descripcion causa externa</para>
        /// <para>NOMBRE: adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual causa externa que origina la admision o atencion medica
        /// </para>
        /// </summary>
        public String Adm_descex_tcex
        {
            get { return _adm_descex_tcex; }
            set
            {
                if (_adm_descex_tcex == value) return;
                _adm_descex_tcex = value;
                OnPropertyChanged("Adm_descex_tcex");
            }
        }
        #endregion
        #region Fcm_despro_fcpr: Descripcion Producto
        private String _fcm_despro_fcpr;
        /// <summary>
        /// <para>TABLA: fcmfeunspscdprodu</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Descripcion Producto</para>
        /// <para>NOMBRE: fcm_despro_fcpr (char:120)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion UNSPSC para el producto
        /// </para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloFcmManualdeserviciosIPS tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-MAE-SERVICIOS-IPS", "FCM", "Maestro servicios IPS");
            if (!flgBuscarFcmmanservicips(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmmanservicips
                    {
                        #region cargar Registro
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_codser_sips = tobjModelo.Fcm_codser_sips,
                        fcm_codser_soat = tobjModelo.Fcm_codser_soat,
                        fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                        fcm_codbar_sips = tobjModelo.Fcm_codbar_sips,
                        fcm_codcum_sips = tobjModelo.Fcm_codcum_sips,
                        fcm_idesec_fcct = tobjModelo.Fcm_idesec_fcct,
                        fcm_desser_sips = tobjModelo.Fcm_desser_sips,
                        fcm_codtse_sips = tobjModelo.Fcm_codtse_sips,
                        fcm_claser_sips = tobjModelo.Fcm_claser_sips,
                        fcm_codgqx_grqx = tobjModelo.Fcm_codgqx_grqx,
                        fcm_punuvr_sips = tobjModelo.Fcm_punuvr_sips,
                        fcm_valser_sips = tobjModelo.Fcm_valser_sips,
                        fcm_edtval_sips = tobjModelo.Fcm_edtval_sips,
                        fcm_lamccp_sips = tobjModelo.Fcm_lamccp_sips,
                        fcm_lhoccp_sips = tobjModelo.Fcm_lhoccp_sips,
                        fcm_luoccp_sips = tobjModelo.Fcm_luoccp_sips,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        sia_codfpr_fpro = tobjModelo.Sia_codfpr_fpro,
                        sia_codfco_fcon = tobjModelo.Sia_codfco_fcon,
                        adm_codcex_tcex = tobjModelo.Adm_codcex_tcex,
                        fcm_mededi_sips = tobjModelo.Fcm_mededi_sips,
                        fcm_edaini_sips = tobjModelo.Fcm_edaini_sips,
                        fcm_mededf_sips = tobjModelo.Fcm_mededf_sips,
                        fcm_edafin_sips = tobjModelo.Fcm_edafin_sips,
                        fcm_mededp_sips = tobjModelo.Fcm_mededp_sips,
                        fcm_edapun_sips = tobjModelo.Fcm_edapun_sips,
                        fcm_sexapl_sips = tobjModelo.Fcm_sexapl_sips,
                        fcm_nivcom_sips = tobjModelo.Fcm_nivcom_sips,
                        sia_codrip_trip = tobjModelo.Sia_codrip_trip,
                        fcm_semeps_sips = tobjModelo.Fcm_semeps_sips,
                        fcm_semsss_sips = tobjModelo.Fcm_semsss_sips,
                        fcm_aplfus_sips = tobjModelo.Fcm_aplfus_sips,
                        fcm_intser_sips = tobjModelo.Fcm_intser_sips,
                        fcm_perfus_sips = tobjModelo.Fcm_perfus_sips,
                        fcm_maxord_sips = tobjModelo.Fcm_maxord_sips,
                        fcm_maxint_sips = tobjModelo.Fcm_maxint_sips,
                        sis_codiva_tiva = tobjModelo.Sis_codiva_tiva,
                        sia_tipact_tsac = tobjModelo.Sia_tipact_tsac,
                        fcm_otserv_sips = tobjModelo.Fcm_otserv_sips,
                        fcm_forfar_sips = tobjModelo.Fcm_forfar_sips,
                        fcm_conmed_sips = tobjModelo.Fcm_conmed_sips,
                        fcm_unimed_sips = tobjModelo.Fcm_unimed_sips,
                        sia_codpat_tpat = tobjModelo.Sia_codpat_tpat,
                        fcm_serpos_sips = tobjModelo.Fcm_serpos_sips,
                        fcm_tipser_sips = tobjModelo.Fcm_tipser_sips,
                        fcm_numuni_sips = tobjModelo.Fcm_numuni_sips,
                        ssp_codcam_resc = tobjModelo.Ssp_codcam_resc,
                        ssp_tipval_resc = tobjModelo.Ssp_tipval_resc,
                        ssp_camdig_resc = tobjModelo.Ssp_camdig_resc,
                        ssp_valper_resc = tobjModelo.Ssp_valper_resc,
                        fcm_genhis_sips = tobjModelo.Fcm_genhis_sips,
                        grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                        hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca,
                        sia_coddia_tdia = tobjModelo.Sia_coddia_tdia,
                        sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix,
                        fcm_coddia_sips = tobjModelo.Fcm_coddia_sips,
                        fcm_codpro_fcpr = tobjModelo.Fcm_codpro_fcpr,
                        fcm_estser_sips = tobjModelo.Fcm_estser_sips,                     
                        #endregion
                    };
                    lobjRegistro.fcm_idesec_sips = lcrCodigoGen;
                    _context.AddToFcmmanservicips(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-MAE-SERVICIOS IPS': Maestro de contratos en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloFcmManualdeserviciosIPS tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tobjModelo.Fcm_idesec_sips);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_codser_sips = tobjModelo.Fcm_codser_sips;
                    lobjRegistro.fcm_codser_soat = tobjModelo.Fcm_codser_soat;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.fcm_codbar_sips = tobjModelo.Fcm_codbar_sips;
                    lobjRegistro.fcm_codcum_sips = tobjModelo.Fcm_codcum_sips;
                    lobjRegistro.fcm_idesec_fcct = tobjModelo.Fcm_idesec_fcct;
                    lobjRegistro.fcm_desser_sips = tobjModelo.Fcm_desser_sips;
                    lobjRegistro.fcm_codtse_sips = tobjModelo.Fcm_codtse_sips;
                    lobjRegistro.fcm_claser_sips = tobjModelo.Fcm_claser_sips;
                    lobjRegistro.fcm_codgqx_grqx = tobjModelo.Fcm_codgqx_grqx;
                    lobjRegistro.fcm_punuvr_sips = (float)tobjModelo.Fcm_punuvr_sips;
                    lobjRegistro.fcm_valser_sips = (float)tobjModelo.Fcm_valser_sips;
                    lobjRegistro.fcm_edtval_sips = tobjModelo.Fcm_edtval_sips;
                    lobjRegistro.fcm_lamccp_sips = tobjModelo.Fcm_lamccp_sips;
                    lobjRegistro.fcm_lhoccp_sips = tobjModelo.Fcm_lhoccp_sips;
                    lobjRegistro.fcm_luoccp_sips = tobjModelo.Fcm_luoccp_sips;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.sia_codfpr_fpro = tobjModelo.Sia_codfpr_fpro;
                    lobjRegistro.sia_codfco_fcon = tobjModelo.Sia_codfco_fcon;
                    lobjRegistro.adm_codcex_tcex = tobjModelo.Adm_codcex_tcex;
                    lobjRegistro.fcm_mededi_sips = tobjModelo.Fcm_mededi_sips;
                    lobjRegistro.fcm_edaini_sips = (int)tobjModelo.Fcm_edaini_sips;
                    lobjRegistro.fcm_mededf_sips = tobjModelo.Fcm_mededf_sips;
                    lobjRegistro.fcm_edafin_sips = (int)tobjModelo.Fcm_edafin_sips;
                    lobjRegistro.fcm_mededp_sips = tobjModelo.Fcm_mededp_sips;
                    lobjRegistro.fcm_edapun_sips = tobjModelo.Fcm_edapun_sips;
                    lobjRegistro.fcm_sexapl_sips = tobjModelo.Fcm_sexapl_sips;
                    lobjRegistro.fcm_nivcom_sips = tobjModelo.Fcm_nivcom_sips;
                    lobjRegistro.sia_codrip_trip = tobjModelo.Sia_codrip_trip;
                    lobjRegistro.fcm_semeps_sips = (int)tobjModelo.Fcm_semeps_sips;
                    lobjRegistro.fcm_semsss_sips = (int)tobjModelo.Fcm_semsss_sips;
                    lobjRegistro.fcm_aplfus_sips = tobjModelo.Fcm_aplfus_sips;
                    lobjRegistro.fcm_intser_sips = (int)tobjModelo.Fcm_intser_sips;
                    lobjRegistro.fcm_perfus_sips = tobjModelo.Fcm_perfus_sips;
                    lobjRegistro.fcm_maxord_sips = (int)tobjModelo.Fcm_maxord_sips;
                    lobjRegistro.fcm_maxint_sips = (int)tobjModelo.Fcm_maxint_sips;
                    lobjRegistro.sis_codiva_tiva = tobjModelo.Sis_codiva_tiva;
                    lobjRegistro.sia_tipact_tsac = tobjModelo.Sia_tipact_tsac;
                    lobjRegistro.fcm_otserv_sips = tobjModelo.Fcm_otserv_sips;
                    lobjRegistro.fcm_forfar_sips = tobjModelo.Fcm_forfar_sips;
                    lobjRegistro.fcm_conmed_sips = tobjModelo.Fcm_conmed_sips;
                    lobjRegistro.fcm_unimed_sips = tobjModelo.Fcm_unimed_sips;
                    lobjRegistro.sia_codpat_tpat = tobjModelo.Sia_codpat_tpat;
                    lobjRegistro.fcm_serpos_sips = tobjModelo.Fcm_serpos_sips;
                    lobjRegistro.fcm_tipser_sips = tobjModelo.Fcm_tipser_sips;
                    lobjRegistro.fcm_numuni_sips = (int)tobjModelo.Fcm_numuni_sips;
                    lobjRegistro.ssp_codcam_resc = tobjModelo.Ssp_codcam_resc;
                    lobjRegistro.ssp_tipval_resc = tobjModelo.Ssp_tipval_resc;
                    lobjRegistro.ssp_camdig_resc = tobjModelo.Ssp_camdig_resc;
                    lobjRegistro.ssp_valper_resc = tobjModelo.Ssp_valper_resc;
                    lobjRegistro.fcm_genhis_sips = tobjModelo.Fcm_genhis_sips;
                    lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                    lobjRegistro.hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca;
                    lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                    lobjRegistro.sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix;
                    lobjRegistro.fcm_coddia_sips = tobjModelo.Fcm_coddia_sips;
                    lobjRegistro.fcm_codpro_fcpr = tobjModelo.Fcm_codpro_fcpr;
                    lobjRegistro.fcm_estser_sips = tobjModelo.Fcm_estser_sips;
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
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMANSERVICIPS: Logica
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TITULO: Maestro de servicios habilitados para la IPS</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de servicios habilitados para la IPS, contiene la validacion
        /// de pertinencia, tipo de servicio RIPS, configuracion general
        /// del servicio (sexo al que aplica edad y otros)
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmanservicips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmanservicips.FirstOrDefault(p => p.fcm_idesec_sips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFcmManualdeserviciosIPS> flsListaFcmmanservicips(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                #region Consulta
                var lobConsulta = from fcmmanservicips in _context.Fcmmanservicips
                                  join siafinaliproced in _context.Siafinaliproced on fcmmanservicips.sia_codfpr_fpro equals siafinaliproced.sia_codfpr_fpro into tmsiafinaliproced
                                  join siafinaliconsul in _context.Siafinaliconsul on fcmmanservicips.sia_codfco_fcon equals siafinaliconsul.sia_codfco_fcon into tmsiafinaliconsul
                                  join hcltiporegactiv in _context.Hcltiporegactiv on fcmmanservicips.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv                                 
                                  join fcmsoatmanualma in _context.Fcmsoatmanualma on fcmmanservicips.fcm_codser_soat equals fcmsoatmanualma.fcm_codser_soat into tmfcmsoatmanualma
                                  join sptabcampos4505 in _context.Sptabcampos4505 on fcmmanservicips.ssp_codcam_resc equals sptabcampos4505.ssp_codcam_resc into tmsptabcampos4505
                                  join fcmfeunspscdprodu in _context.Fcmfeunspscdprodu on fcmmanservicips.fcm_codpro_fcpr equals fcmfeunspscdprodu.fcm_codpro_fcpr into tmfcmfeunspscdprodu
                                  from fpro in tmsiafinaliproced.DefaultIfEmpty()
                                  from fcon in tmsiafinaliconsul.DefaultIfEmpty()
                                  from hcca in tmhcltiporegactiv.DefaultIfEmpty()                                  
                                  from soat in tmfcmsoatmanualma.DefaultIfEmpty()
                                  from resc in tmsptabcampos4505.DefaultIfEmpty()
                                  from fcpr in tmfcmfeunspscdprodu.DefaultIfEmpty()
                                  where fcmmanservicips.fcm_idesec_sips == tcrBuscar
                                  select new ModeloFcmManualdeserviciosIPS
                                  {
                                      Fcm_idesec_sips = fcmmanservicips.fcm_idesec_sips,
                                      Fcm_codser_sips = fcmmanservicips.fcm_codser_sips,
                                      Fcm_codser_soat = fcmmanservicips.fcm_codser_soat,
                                      Fcm_coddig_mant = fcmmanservicips.fcm_coddig_mant,
                                      Fcm_codbar_sips = fcmmanservicips.fcm_codbar_sips,
                                      Fcm_codcum_sips = fcmmanservicips.fcm_codcum_sips,
                                      Fcm_idesec_fcct = fcmmanservicips.fcm_idesec_fcct,
                                      Fcm_desser_sips = fcmmanservicips.fcm_desser_sips,
                                      Fcm_codtse_sips = fcmmanservicips.fcm_codtse_sips,
                                      Fcm_claser_sips = fcmmanservicips.fcm_claser_sips,
                                      Fcm_codgqx_grqx = fcmmanservicips.fcm_codgqx_grqx,
                                      Fcm_punuvr_sips = (float)fcmmanservicips.fcm_punuvr_sips,
                                      Fcm_valser_sips = (float)fcmmanservicips.fcm_valser_sips,
                                      Fcm_edtval_sips = fcmmanservicips.fcm_edtval_sips,
                                      Fcm_lamccp_sips = fcmmanservicips.fcm_lamccp_sips,
                                      Fcm_lhoccp_sips = fcmmanservicips.fcm_lhoccp_sips,
                                      Fcm_luoccp_sips = fcmmanservicips.fcm_luoccp_sips,
                                      Fcm_codcpr_cpro = fcmmanservicips.fcm_codcpr_cpro,
                                      Sia_codfpr_fpro = fcmmanservicips.sia_codfpr_fpro,
                                      Sia_codfco_fcon = fcmmanservicips.sia_codfco_fcon,
                                      Adm_codcex_tcex = fcmmanservicips.adm_codcex_tcex,
                                      Fcm_mededi_sips = fcmmanservicips.fcm_mededi_sips,
                                      Fcm_edaini_sips = (int)fcmmanservicips.fcm_edaini_sips,
                                      Fcm_mededf_sips = fcmmanservicips.fcm_mededf_sips,
                                      Fcm_edafin_sips = (int)fcmmanservicips.fcm_edafin_sips,
                                      Fcm_mededp_sips = fcmmanservicips.fcm_mededp_sips,
                                      Fcm_edapun_sips = fcmmanservicips.fcm_edapun_sips,
                                      Fcm_sexapl_sips = fcmmanservicips.fcm_sexapl_sips,
                                      Fcm_nivcom_sips = fcmmanservicips.fcm_nivcom_sips,
                                      Sia_codrip_trip = fcmmanservicips.sia_codrip_trip,
                                      Fcm_semeps_sips = (int)fcmmanservicips.fcm_semeps_sips,
                                      Fcm_semsss_sips = (int)fcmmanservicips.fcm_semsss_sips,
                                      Fcm_aplfus_sips = fcmmanservicips.fcm_aplfus_sips,
                                      Fcm_intser_sips = (int)fcmmanservicips.fcm_intser_sips,
                                      Fcm_perfus_sips = fcmmanservicips.fcm_perfus_sips,
                                      Fcm_maxord_sips = (int)fcmmanservicips.fcm_maxord_sips,
                                      Fcm_maxint_sips = (int)fcmmanservicips.fcm_maxint_sips,
                                      Sis_codiva_tiva = fcmmanservicips.sis_codiva_tiva,
                                      Sia_tipact_tsac = fcmmanservicips.sia_tipact_tsac,
                                      Fcm_otserv_sips = fcmmanservicips.fcm_otserv_sips,
                                      Fcm_forfar_sips = fcmmanservicips.fcm_forfar_sips,
                                      Fcm_conmed_sips = fcmmanservicips.fcm_conmed_sips,
                                      Fcm_unimed_sips = fcmmanservicips.fcm_unimed_sips,
                                      Sia_codpat_tpat = fcmmanservicips.sia_codpat_tpat,
                                      Fcm_serpos_sips = fcmmanservicips.fcm_serpos_sips,
                                      Fcm_tipser_sips = fcmmanservicips.fcm_tipser_sips,
                                      Fcm_numuni_sips = (int)fcmmanservicips.fcm_numuni_sips,
                                      Ssp_codcam_resc = fcmmanservicips.ssp_codcam_resc,
                                      Ssp_tipval_resc = fcmmanservicips.ssp_tipval_resc,
                                      Ssp_camdig_resc = fcmmanservicips.ssp_camdig_resc,
                                      Ssp_valper_resc = fcmmanservicips.ssp_valper_resc,
                                      Fcm_genhis_sips = fcmmanservicips.fcm_genhis_sips,
                                      Grp_idepla_grpl = fcmmanservicips.grp_idepla_grpl,
                                      Hcl_codreg_hcca = fcmmanservicips.hcl_codreg_hcca,
                                      Sia_coddia_tdia = fcmmanservicips.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = fcmmanservicips.sia_tipdxp_tdix,
                                      Fcm_coddia_sips = fcmmanservicips.fcm_coddia_sips,
                                      Fcm_codpro_fcpr = fcmmanservicips.fcm_codpro_fcpr,
                                      Fcm_estser_sips = fcmmanservicips.fcm_estser_sips,
                                      Fcm_desman_soat = soat.fcm_desman_soat,
                                      Hcl_desreg_hcca = hcca.hcl_desreg_hcca,
                                      Sia_desfpr_fpro = fpro.sia_desfpr_fpro,
                                      Sia_desfco_fcon = fcon.sia_desfco_fcon,
                                      Ssp_nomcam_resc = resc.ssp_nomcam_resc,
                                      Fcm_descat_fcct = _context.Fcmmanservicate.FirstOrDefault(rxp => rxp.fcm_idesec_fcct == fcmmanservicips.fcm_idesec_fcct).fcm_descat_fcct,
                                      Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == fcmmanservicips.fcm_codcpr_cpro).fcm_descpr_cpro,
                                      Fcm_despro_fcpr = fcpr.fcm_despro_fcpr,
                                      Sis_desiva_tiva = _context.Sistablaiva.FirstOrDefault(rxp => rxp.sis_codiva_tiva == fcmmanservicips.sis_codiva_tiva).sis_desiva_tiva,                                     
                                      Fcm_desgqx_grqx = _context.Fcmgrquirurgico.FirstOrDefault(rxp => rxp.fcm_codgqx_grqx == fcmmanservicips.fcm_codgqx_grqx).fcm_desgqx_grqx,
                                      Adm_descex_tcex = _context.Admcausaexterna.FirstOrDefault(rxp => rxp.adm_codcex_tcex == fcmmanservicips.adm_codcex_tcex).adm_descex_tcex,
                                      Sia_desrip_trip = _context.Siatablatprips.FirstOrDefault(x => x.sia_codrip_trip == fcmmanservicips.sia_codrip_trip).sia_desrip_trip,
                                      Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(x => x.grp_idepla_grpl == fcmmanservicips.grp_idepla_grpl).grp_despla_grpl,
                                      Sia_desdia_tdia = _context.Siadiagnosticos.FirstOrDefault(x => x.sia_coddia_tdia == fcmmanservicips.sia_coddia_tdia).sia_desdia_tdia,
                                      Sia_desdxp_tdix = _context.Siatipodiagprin.FirstOrDefault(x => x.sia_tipdxp_tdix == fcmmanservicips.sia_tipdxp_tdix).sia_desdxp_tdix,

                                  };
                return lobConsulta.ToList();
                #endregion
            }
        }
        #endregion
        #endregion
    }
}
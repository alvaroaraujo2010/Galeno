//- MARMOTA-GENCODE: VERSION 2.0 - 28/06/2016 06:00:43 AM
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

namespace HistoriasClinicas.Modelo
{
    /// <summary>
    /// hclvariabmaestr: Maestro Variables publicas gestion en formatos de historias clinicas
    /// </summary>
    public class ModeloHclvariabmaestro : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcvr: Codigo registro
        private String _hcl_nroreg_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: hcl_nroreg_hcvr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro variables publicas
        /// de gestion
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcvr
        {
            get { return _hcl_nroreg_hcvr; }
            set
            {
                if (_hcl_nroreg_hcvr == value) return;
                _hcl_nroreg_hcvr = value;
                OnPropertyChanged("Hcl_nroreg_hcvr");
            }
        }
        #endregion
        #region Hcl_secgru_hcgv: Grupo de variables
        private String _hcl_secgru_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Grupo de variables</para>
        /// <para>NOMBRE: hcl_secgru_hcgv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo grupo, al cual se asocia la variable
        /// </para>
        /// </summary>
        public String Hcl_secgru_hcgv
        {
            get { return _hcl_secgru_hcgv; }
            set
            {
                if (_hcl_secgru_hcgv == value) return;
                _hcl_secgru_hcgv = value;
                OnPropertyChanged("Hcl_secgru_hcgv");
            }
        }
        #endregion
        #region Hcl_ordvis_hcvr: Orden vista
        private int _hcl_ordvis_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Orden vista</para>
        /// <para>NOMBRE: hcl_ordvis_hcvr (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero para orden vista en gestion impresión en formatos dentro
        /// del grupo al que pertenece
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcvr
        {
            get { return _hcl_ordvis_hcvr; }
            set
            {
                if (_hcl_ordvis_hcvr == value) return;
                _hcl_ordvis_hcvr = value;
                OnPropertyChanged("Hcl_ordvis_hcvr");
            }
        }
        #endregion
        #region Hcl_titulo_hcvr: Titulo Variable
        private String _hcl_titulo_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Titulo Variable</para>
        /// <para>NOMBRE: hcl_titulo_hcvr (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo de la variable para mostrar como descripcion corta
        /// </para>
        /// </summary>
        public String Hcl_titulo_hcvr
        {
            get { return _hcl_titulo_hcvr; }
            set
            {
                if (_hcl_titulo_hcvr == value) return;
                _hcl_titulo_hcvr = value;
                OnPropertyChanged("Hcl_titulo_hcvr");
            }
        }
        #endregion
        #region Hcl_descri_hcvr: Descripción Variable
        private String _hcl_descri_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Descripción Variable</para>
        /// <para>NOMBRE: hcl_descri_hcvr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción larga de la variable
        /// </para>
        /// </summary>
        public String Hcl_descri_hcvr
        {
            get { return _hcl_descri_hcvr; }
            set
            {
                if (_hcl_descri_hcvr == value) return;
                _hcl_descri_hcvr = value;
                OnPropertyChanged("Hcl_descri_hcvr");
            }
        }
        #endregion
        #region Hcl_nomvar_hcvr: Nombre variable publica
        private String _hcl_nomvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nombre variable publica</para>
        /// <para>NOMBRE: hcl_nomvar_hcvr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Nombre unico identificador de la variable, para referencia
        /// dentro del sistema, este nombre debe incluir nombre identificador
        /// del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS
        /// 1, JOVEN_PLANIFICACION_SI_NO
        /// </para>
        /// </summary>
        public String Hcl_nomvar_hcvr
        {
            get { return _hcl_nomvar_hcvr; }
            set
            {
                if (_hcl_nomvar_hcvr == value) return;
                _hcl_nomvar_hcvr = value;
                OnPropertyChanged("Hcl_nomvar_hcvr");
            }
        }
        #endregion
        #region Hcl_tipval_hcvr: Tipo dato Valor campo
        private String _hcl_tipval_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: hcl_tipval_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo dato valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=De
        /// cimal
        /// </para>
        /// </summary>
        public String Hcl_tipval_hcvr
        {
            get { return _hcl_tipval_hcvr; }
            set
            {
                if (_hcl_tipval_hcvr == value) return;
                _hcl_tipval_hcvr = value;
                OnPropertyChanged("Hcl_tipval_hcvr");
            }
        }
        #endregion
        #region Hcl_valper_hcvr: Valor Permitido
        private String _hcl_valper_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: hcl_valper_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public String Hcl_valper_hcvr
        {
            get { return _hcl_valper_hcvr; }
            set
            {
                if (_hcl_valper_hcvr == value) return;
                _hcl_valper_hcvr = value;
                OnPropertyChanged("Hcl_valper_hcvr");
            }
        }
        #endregion
        #region Hcl_valvar_hcvr: Valor por defecto
        private String _hcl_valvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor por defecto</para>
        /// <para>NOMBRE: hcl_valvar_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor digitado, Se usa como valor por defecto al iniciar captura
        /// de datos en la variable
        /// </para>
        /// </summary>
        public String Hcl_valvar_hcvr
        {
            get { return _hcl_valvar_hcvr; }
            set
            {
                if (_hcl_valvar_hcvr == value) return;
                _hcl_valvar_hcvr = value;
                OnPropertyChanged("Hcl_valvar_hcvr");
            }
        }
        #endregion
        #region Hcl_camdig_hcvr: Campo digitable
        private String _hcl_camdig_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: hcl_camdig_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Campo digitable: 1=Valor es modificable  2=Valor modficable desde procesos para variables resumen y otros, 3=Valor protegido.</para>
        /// </summary>
        public String Hcl_camdig_hcvr
        {
            get { return _hcl_camdig_hcvr; }
            set
            {
                if (_hcl_camdig_hcvr == value) return;
                _hcl_camdig_hcvr = value;
                OnPropertyChanged("Hcl_camdig_hcvr");
            }
        }
        #endregion
        #region Hcl_ranini_hcvr: Rango inicial
        private String _hcl_ranini_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: hcl_ranini_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Rango inicial general del valor digitable
        /// </para>
        /// </summary>
        public String Hcl_ranini_hcvr
        {
            get { return _hcl_ranini_hcvr; }
            set
            {
                if (_hcl_ranini_hcvr == value) return;
                _hcl_ranini_hcvr = value;
                OnPropertyChanged("Hcl_ranini_hcvr");
            }
        }
        #endregion
        #region Hcl_ranfin_hcvr: Rango final
        private String _hcl_ranfin_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: hcl_ranfin_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Rango final general del valor digitable
        /// </para>
        /// </summary>
        public String Hcl_ranfin_hcvr
        {
            get { return _hcl_ranfin_hcvr; }
            set
            {
                if (_hcl_ranfin_hcvr == value) return;
                _hcl_ranfin_hcvr = value;
                OnPropertyChanged("Hcl_ranfin_hcvr");
            }
        }
        #endregion
        #region Hcl_raninr_hcvr: Rango inicial normal
        private String _hcl_raninr_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial normal</para>
        /// <para>NOMBRE: hcl_raninr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Rango inicial valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public String Hcl_raninr_hcvr
        {
            get { return _hcl_raninr_hcvr; }
            set
            {
                if (_hcl_raninr_hcvr == value) return;
                _hcl_raninr_hcvr = value;
                OnPropertyChanged("Hcl_raninr_hcvr");
            }
        }
        #endregion
        #region Hcl_ranfnr_hcvr: Rango final normal
        private String _hcl_ranfnr_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final normal</para>
        /// <para>NOMBRE: hcl_ranfnr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Rango final valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public String Hcl_ranfnr_hcvr
        {
            get { return _hcl_ranfnr_hcvr; }
            set
            {
                if (_hcl_ranfnr_hcvr == value) return;
                _hcl_ranfnr_hcvr = value;
                OnPropertyChanged("Hcl_ranfnr_hcvr");
            }
        }
        #endregion
        #region Hcl_nivvar_hcvr: Nivel gestion
        private String _hcl_nivvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nivel gestion</para>
        /// <para>NOMBRE: hcl_nivvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Nivel gestion variable (1,2,3) : 1= Unica  permanente en historia
        /// clinica, ejemplo: Numero admision activa 2=Unica tmporal en
        /// evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable
        /// temporal  gestion evento, ejemplo: resultado de laboratorio
        /// </para>
        /// </summary>
        public String Hcl_nivvar_hcvr
        {
            get { return _hcl_nivvar_hcvr; }
            set
            {
                if (_hcl_nivvar_hcvr == value) return;
                _hcl_nivvar_hcvr = value;
                OnPropertyChanged("Hcl_nivvar_hcvr");
            }
        }
        #endregion
        #region Hcl_sistem_hcvr: Tipo variable
        private String _hcl_sistem_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo variable</para>
        /// <para>NOMBRE: hcl_sistem_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Evaluar gestion de datos y notifcar alarma para valores referenciados
        /// como anormales: 1= Variable normal 2=Genera notificacion cuando
        /// hay valores anormales
        /// </para>
        /// </summary>
        public String Hcl_sistem_hcvr
        {
            get { return _hcl_sistem_hcvr; }
            set
            {
                if (_hcl_sistem_hcvr == value) return;
                _hcl_sistem_hcvr = value;
                OnPropertyChanged("Hcl_sistem_hcvr");
            }
        }
        #endregion
        #region Hcl_modoca_hcvr: Modo captura datos
        private String _hcl_modoca_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Modo captura datos</para>
        /// <para>NOMBRE: hcl_modoca_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Modo captura de datos: 1=Variable simple captura de datos 2=Resumen
        /// general todas las variables del grupo 3=Resumen variables del
        /// grupo que contengan datos
        /// </para>
        /// </summary>
        public String Hcl_modoca_hcvr
        {
            get { return _hcl_modoca_hcvr; }
            set
            {
                if (_hcl_modoca_hcvr == value) return;
                _hcl_modoca_hcvr = value;
                OnPropertyChanged("Hcl_modoca_hcvr");
            }
        }
        #endregion
        #region Hcl_resume_hcvr: Resumen de datos
        private String _hcl_resume_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Resumen de datos</para>
        /// <para>NOMBRE: hcl_resume_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Incluir valor capturado en variable resumen: 1=Incluir en Variables
        /// resumen 2= No incluir en variables resumen
        /// </para>
        /// </summary>
        public String Hcl_resume_hcvr
        {
            get { return _hcl_resume_hcvr; }
            set
            {
                if (_hcl_resume_hcvr == value) return;
                _hcl_resume_hcvr = value;
                OnPropertyChanged("Hcl_resume_hcvr");
            }
        }
        #endregion
        #region Hcl_siresu_hcvr: Opcion lista variables resumen
        private String _hcl_siresu_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Opcion lista variables</para>
        /// <para>NOMBRE: hcl_siresu_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Saber si Incuir lista variables del campo HCL_VRESUM_HCVR en
        /// resumen: 1=Incluir solo lista variables en resumen 2= No incluir
        /// lista variables en resumen 3=No Aplica
        /// </para>
        /// </summary>
        public String Hcl_siresu_hcvr
        {
            get { return _hcl_siresu_hcvr; }
            set
            {
                if (_hcl_siresu_hcvr == value) return;
                _hcl_siresu_hcvr = value;
                OnPropertyChanged("Hcl_siresu_hcvr");
            }
        }
        #endregion
        #region Hcl_vresum_hcvr: Lista Variables del resumen
        private String _hcl_vresum_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variables del resumen</para>
        /// <para>NOMBRE: hcl_vresum_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Lista separada por comas para Nombre de variables que se tendran
        /// en cuenta en el resumen, cuando esta vacia se asume todo el
        /// grupo de variables
        /// </para>
        /// </summary>
        public String Hcl_vresum_hcvr
        {
            get { return _hcl_vresum_hcvr; }
            set
            {
                if (_hcl_vresum_hcvr == value) return;
                _hcl_vresum_hcvr = value;
                OnPropertyChanged("Hcl_vresum_hcvr");
            }
        }
        #endregion
        #region Hcl_tvigen_hcvr: Vigencia en tiempo
        private String _hcl_tvigen_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Vigencia en tiempo</para>
        /// <para>NOMBRE: hcl_tvigen_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Vigencia en tiempo de la variable: 1= Indefinido 2=Dias 3=Meses
        /// 4 =Años
        /// </para>
        /// </summary>
        public String Hcl_tvigen_hcvr
        {
            get { return _hcl_tvigen_hcvr; }
            set
            {
                if (_hcl_tvigen_hcvr == value) return;
                _hcl_tvigen_hcvr = value;
                OnPropertyChanged("Hcl_tvigen_hcvr");
            }
        }
        #endregion
        #region Hcl_vvigen_hcvr: Valor vigencia tiempo
        private int _hcl_vvigen_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor vigencia tiempo</para>
        /// <para>NOMBRE: hcl_vvigen_hcvr (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Cantidad de tiempo según vigencia de la variable (por defecto
        /// cero cuando es indefinido), aplica solo cuando es diferente
        /// de indefinido
        /// </para>
        /// </summary>
        public int Hcl_vvigen_hcvr
        {
            get { return _hcl_vvigen_hcvr; }
            set
            {
                if (_hcl_vvigen_hcvr == value) return;
                _hcl_vvigen_hcvr = value;
                OnPropertyChanged("Hcl_vvigen_hcvr");
            }
        }
        #endregion
        #region Hcl_varray_hcvr: Variable tipo pila
        private String _hcl_varray_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable tipo pila</para>
        /// <para>NOMBRE: hcl_varray_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Variable es tipo pila (array) : 1= La variable es tipo Array
        /// 2=No es tipo array (valor por defecto)
        /// </para>
        /// </summary>
        public String Hcl_varray_hcvr
        {
            get { return _hcl_varray_hcvr; }
            set
            {
                if (_hcl_varray_hcvr == value) return;
                _hcl_varray_hcvr = value;
                OnPropertyChanged("Hcl_varray_hcvr");
            }
        }
        #endregion
        #region Hcl_tmaray_hcvr: Tamaño pila
        private int _hcl_tmaray_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tamaño pila</para>
        /// <para>NOMBRE: hcl_tmaray_hcvr (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tamaño en lista de valores que puede contener la pila (valores
        /// de la variable en diferentes tiempos)
        /// </para>
        /// </summary>
        public int Hcl_tmaray_hcvr
        {
            get { return _hcl_tmaray_hcvr; }
            set
            {
                if (_hcl_tmaray_hcvr == value) return;
                _hcl_tmaray_hcvr = value;
                OnPropertyChanged("Hcl_tmaray_hcvr");
            }
        }
        #endregion
        #region Hcl_sisvar_hcvr: Variable protegida
        private String _hcl_sisvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable protegida</para>
        /// <para>NOMBRE: hcl_sisvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Variable protegida del sistema: 1= Valor Protegido 2=Valor
        /// no protegido
        /// </para>
        /// </summary>
        public String Hcl_sisvar_hcvr
        {
            get { return _hcl_sisvar_hcvr; }
            set
            {
                if (_hcl_sisvar_hcvr == value) return;
                _hcl_sisvar_hcvr = value;
                OnPropertyChanged("Hcl_sisvar_hcvr");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Hcl_desgru_hcgv: Descripcion grupo
        private String _hcl_desgru_hcgv;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Descripcion grupo</para>
        /// <para>NOMBRE: hcl_desgru_hcgv (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion de la clasificacion grupo de variables
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcgv
        {
            get { return _hcl_desgru_hcgv; }
            set
            {
                if (_hcl_desgru_hcgv == value) return;
                _hcl_desgru_hcgv = value;
                OnPropertyChanged("Hcl_desgru_hcgv");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclvariabmaestro tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-MAESTRO-VARIABLES", "HCL", "Maestro Variables publicas de gestion en formatos");
        	try
        	{
            	if (!flgBuscarHclvariabmaestr(lcrCodigoGen))
            	{
                	using (_context = new DbAplicacion())
                	{
        				var lobjRegistro = new EFhclvariabmaestr
        				{
        					#region cargar Registro
                            hcl_nroreg_hcvr = tobjModelo.Hcl_nroreg_hcvr,
                            hcl_secgru_hcgv = tobjModelo.Hcl_secgru_hcgv,
                            hcl_ordvis_hcvr = tobjModelo.Hcl_ordvis_hcvr,
                            hcl_titulo_hcvr = tobjModelo.Hcl_titulo_hcvr,
                            hcl_descri_hcvr = tobjModelo.Hcl_descri_hcvr,
                            hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr,
                            hcl_tipval_hcvr = tobjModelo.Hcl_tipval_hcvr,
                            hcl_valper_hcvr = tobjModelo.Hcl_valper_hcvr,
                            hcl_valvar_hcvr = tobjModelo.Hcl_valvar_hcvr,
                            hcl_camdig_hcvr = tobjModelo.Hcl_camdig_hcvr,
                            hcl_ranini_hcvr = tobjModelo.Hcl_ranini_hcvr,
                            hcl_ranfin_hcvr = tobjModelo.Hcl_ranfin_hcvr,
                            hcl_raninr_hcvr = tobjModelo.Hcl_raninr_hcvr,
                            hcl_ranfnr_hcvr = tobjModelo.Hcl_ranfnr_hcvr,
                            hcl_nivvar_hcvr = tobjModelo.Hcl_nivvar_hcvr,
                            hcl_sistem_hcvr = tobjModelo.Hcl_sistem_hcvr,
                            hcl_modoca_hcvr = tobjModelo.Hcl_modoca_hcvr,
                            hcl_resume_hcvr = tobjModelo.Hcl_resume_hcvr,
                            hcl_siresu_hcvr = tobjModelo.Hcl_siresu_hcvr,
                            hcl_vresum_hcvr = tobjModelo.Hcl_vresum_hcvr,
                            hcl_tvigen_hcvr = tobjModelo.Hcl_tvigen_hcvr,
                            hcl_vvigen_hcvr = tobjModelo.Hcl_vvigen_hcvr,
                            hcl_varray_hcvr  = tobjModelo.Hcl_varray_hcvr,
                            hcl_tmaray_hcvr  = tobjModelo.Hcl_tmaray_hcvr,
                            hcl_sisvar_hcvr = tobjModelo.Hcl_sisvar_hcvr,
                            sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
        					#endregion
        				};
        				lobjRegistro.hcl_nroreg_hcvr = lcrCodigoGen;
        				_context.AddToHclvariabmaestr(lobjRegistro);
        				_context.SaveChanges();
                	}
            	}
            	else
            	{
                	lcrCodigoGen = string.Empty;
                	MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n"+
                                "'HCL-MAESTRO-VARIABLES': Maestro Variables publicas de gestion en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloHclvariabmaestro tobjModelo)
        {
        	try
        	{
                using (_context = new DbAplicacion())
                {
        			var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tobjModelo.Hcl_nroreg_hcvr);
        			if (lobjRegistro != null)
        			{
                        lobjRegistro.hcl_nroreg_hcvr = tobjModelo.Hcl_nroreg_hcvr;
                        lobjRegistro.hcl_secgru_hcgv = tobjModelo.Hcl_secgru_hcgv;
                        lobjRegistro.hcl_ordvis_hcvr = (int)tobjModelo.Hcl_ordvis_hcvr;
                        lobjRegistro.hcl_titulo_hcvr = tobjModelo.Hcl_titulo_hcvr;
                        lobjRegistro.hcl_descri_hcvr = tobjModelo.Hcl_descri_hcvr;
                        lobjRegistro.hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr;
                        lobjRegistro.hcl_tipval_hcvr = tobjModelo.Hcl_tipval_hcvr;
                        lobjRegistro.hcl_valper_hcvr = tobjModelo.Hcl_valper_hcvr;
                        lobjRegistro.hcl_valvar_hcvr = tobjModelo.Hcl_valvar_hcvr;
                        lobjRegistro.hcl_camdig_hcvr = tobjModelo.Hcl_camdig_hcvr;
                        lobjRegistro.hcl_ranini_hcvr = tobjModelo.Hcl_ranini_hcvr;
                        lobjRegistro.hcl_ranfin_hcvr = tobjModelo.Hcl_ranfin_hcvr;
                        lobjRegistro.hcl_raninr_hcvr = tobjModelo.Hcl_raninr_hcvr;
                        lobjRegistro.hcl_ranfnr_hcvr = tobjModelo.Hcl_ranfnr_hcvr;
                        lobjRegistro.hcl_nivvar_hcvr = tobjModelo.Hcl_nivvar_hcvr;
                        lobjRegistro.hcl_sistem_hcvr = tobjModelo.Hcl_sistem_hcvr;
                        lobjRegistro.hcl_modoca_hcvr = tobjModelo.Hcl_modoca_hcvr;
                        lobjRegistro.hcl_resume_hcvr = tobjModelo.Hcl_resume_hcvr;
                        lobjRegistro.hcl_siresu_hcvr = tobjModelo.Hcl_siresu_hcvr;
                        lobjRegistro.hcl_vresum_hcvr = tobjModelo.Hcl_vresum_hcvr;
                        lobjRegistro.hcl_tvigen_hcvr = tobjModelo.Hcl_tvigen_hcvr;
                        lobjRegistro.hcl_vvigen_hcvr = (int)tobjModelo.Hcl_vvigen_hcvr;
                        lobjRegistro.hcl_varray_hcvr  = tobjModelo.Hcl_varray_hcvr;
                        lobjRegistro.hcl_tmaray_hcvr  = (int)tobjModelo.Hcl_tmaray_hcvr;
                        lobjRegistro.hcl_sisvar_hcvr = tobjModelo.Hcl_sisvar_hcvr;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
        			var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tcrCodigo);
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
        #region Buscar HCLVARIABMAESTR: Logica
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TITULO: Maestro Variables publicas de gestion en formatos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro Variables publicas gestion en formatos de historias
        /// clinicas
        /// </para>
        /// </summary>
        public static bool flgBuscarHclvariabmaestr(string tcrCodigo)
        {
        	bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabmaestr.FirstOrDefault(p => p.hcl_nroreg_hcvr == tcrCodigo);
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
        /// Flitro de la vista variables 
        /// </summary>
        /// <param name="tcrCodigoGrupo">Codigo del grupo de variables</param>
        /// <param name="tcrTextoBuscar">Texto a buscar</param>
        /// <returns></returns>
        public static List<ModeloHclvariabmaestro> flsListaHclvariabmaestr(String tcrCodigoGrupo, String tcrTextoBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrTextoBuscar))
                {
                    var lobConsulta = from hclvariabmaestr in _context.Hclvariabmaestr
                                      join hclvariabgrupos in _context.Hclvariabgrupos on hclvariabmaestr.hcl_secgru_hcgv equals hclvariabgrupos.hcl_secgru_hcgv into tmhclvariabgrupos
                                      from hcgv in tmhclvariabgrupos.DefaultIfEmpty()
                                      where hclvariabmaestr.hcl_secgru_hcgv.Equals(tcrCodigoGrupo) 
                                      select new ModeloHclvariabmaestro
                                      {
                                          #region datos
                                          Hcl_nroreg_hcvr = hclvariabmaestr.hcl_nroreg_hcvr,
                                          Hcl_secgru_hcgv = hclvariabmaestr.hcl_secgru_hcgv,
                                          Hcl_ordvis_hcvr = (int)hclvariabmaestr.hcl_ordvis_hcvr,
                                          Hcl_titulo_hcvr = hclvariabmaestr.hcl_titulo_hcvr,
                                          Hcl_descri_hcvr = hclvariabmaestr.hcl_descri_hcvr,
                                          Hcl_nomvar_hcvr = hclvariabmaestr.hcl_nomvar_hcvr,
                                          Hcl_tipval_hcvr = hclvariabmaestr.hcl_tipval_hcvr,
                                          Hcl_valper_hcvr = hclvariabmaestr.hcl_valper_hcvr,
                                          Hcl_valvar_hcvr = hclvariabmaestr.hcl_valvar_hcvr,
                                          Hcl_camdig_hcvr = hclvariabmaestr.hcl_camdig_hcvr,
                                          Hcl_ranini_hcvr = hclvariabmaestr.hcl_ranini_hcvr,
                                          Hcl_ranfin_hcvr = hclvariabmaestr.hcl_ranfin_hcvr,
                                          Hcl_raninr_hcvr = hclvariabmaestr.hcl_raninr_hcvr,
                                          Hcl_ranfnr_hcvr = hclvariabmaestr.hcl_ranfnr_hcvr,
                                          Hcl_nivvar_hcvr = hclvariabmaestr.hcl_nivvar_hcvr,
                                          Hcl_sistem_hcvr = hclvariabmaestr.hcl_sistem_hcvr,
                                          Hcl_modoca_hcvr = hclvariabmaestr.hcl_modoca_hcvr,
                                          Hcl_resume_hcvr = hclvariabmaestr.hcl_resume_hcvr,
                                          Hcl_siresu_hcvr = hclvariabmaestr.hcl_siresu_hcvr,
                                          Hcl_vresum_hcvr = hclvariabmaestr.hcl_vresum_hcvr,
                                          Hcl_tvigen_hcvr = hclvariabmaestr.hcl_tvigen_hcvr,
                                          Hcl_vvigen_hcvr = (int)hclvariabmaestr.hcl_vvigen_hcvr,
                                          Hcl_varray_hcvr  = hclvariabmaestr.hcl_varray_hcvr,
                                          Hcl_tmaray_hcvr  = (int)hclvariabmaestr.hcl_tmaray_hcvr,
                                          Hcl_sisvar_hcvr = hclvariabmaestr.hcl_sisvar_hcvr,
                                          Sis_estreg_esrg = hclvariabmaestr.sis_estreg_esrg,
                                          Hcl_desgru_hcgv = hcgv.hcl_desgru_hcgv,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclvariabmaestr in _context.Hclvariabmaestr
                                      join hclvariabgrupos in _context.Hclvariabgrupos on hclvariabmaestr.hcl_secgru_hcgv equals hclvariabgrupos.hcl_secgru_hcgv into tmhclvariabgrupos
                                      from hcgv in tmhclvariabgrupos.DefaultIfEmpty()
                                      where hclvariabmaestr.hcl_secgru_hcgv.Equals(tcrCodigoGrupo) &&
                                            (hclvariabmaestr.hcl_titulo_hcvr.Contains(tcrTextoBuscar) ||
                                             hclvariabmaestr.hcl_descri_hcvr.Contains(tcrTextoBuscar) ||
                                             hclvariabmaestr.hcl_nomvar_hcvr.Contains(tcrTextoBuscar))
                                      select new ModeloHclvariabmaestro
                                      {
                                          #region datos
                                          Hcl_nroreg_hcvr = hclvariabmaestr.hcl_nroreg_hcvr,
                                          Hcl_secgru_hcgv = hclvariabmaestr.hcl_secgru_hcgv,
                                          Hcl_ordvis_hcvr = (int)hclvariabmaestr.hcl_ordvis_hcvr,
                                          Hcl_titulo_hcvr = hclvariabmaestr.hcl_titulo_hcvr,
                                          Hcl_descri_hcvr = hclvariabmaestr.hcl_descri_hcvr,
                                          Hcl_nomvar_hcvr = hclvariabmaestr.hcl_nomvar_hcvr,
                                          Hcl_tipval_hcvr = hclvariabmaestr.hcl_tipval_hcvr,
                                          Hcl_valper_hcvr = hclvariabmaestr.hcl_valper_hcvr,
                                          Hcl_valvar_hcvr = hclvariabmaestr.hcl_valvar_hcvr,
                                          Hcl_camdig_hcvr = hclvariabmaestr.hcl_camdig_hcvr,
                                          Hcl_ranini_hcvr = hclvariabmaestr.hcl_ranini_hcvr,
                                          Hcl_ranfin_hcvr = hclvariabmaestr.hcl_ranfin_hcvr,
                                          Hcl_raninr_hcvr = hclvariabmaestr.hcl_raninr_hcvr,
                                          Hcl_ranfnr_hcvr = hclvariabmaestr.hcl_ranfnr_hcvr,
                                          Hcl_nivvar_hcvr = hclvariabmaestr.hcl_nivvar_hcvr,
                                          Hcl_sistem_hcvr = hclvariabmaestr.hcl_sistem_hcvr,
                                          Hcl_modoca_hcvr = hclvariabmaestr.hcl_modoca_hcvr,
                                          Hcl_resume_hcvr = hclvariabmaestr.hcl_resume_hcvr,
                                          Hcl_siresu_hcvr = hclvariabmaestr.hcl_siresu_hcvr,
                                          Hcl_vresum_hcvr = hclvariabmaestr.hcl_vresum_hcvr,
                                          Hcl_tvigen_hcvr = hclvariabmaestr.hcl_tvigen_hcvr,
                                          Hcl_vvigen_hcvr = (int)hclvariabmaestr.hcl_vvigen_hcvr,
                                          Hcl_varray_hcvr  = hclvariabmaestr.hcl_varray_hcvr,
                                          Hcl_tmaray_hcvr  = (int)hclvariabmaestr.hcl_tmaray_hcvr,
                                          Hcl_sisvar_hcvr = hclvariabmaestr.hcl_sisvar_hcvr,
                                          Sis_estreg_esrg = hclvariabmaestr.sis_estreg_esrg,
                                          Hcl_desgru_hcgv = hcgv.hcl_desgru_hcgv,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
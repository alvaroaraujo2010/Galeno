//- MARMOTA-GENCODE: VERSION 2.0 - 11/02/2018 05:38:38 AM
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

namespace SaludPublica.Modelo
{
    /// <summary>
    /// spprogramgrupma: Archivo Maestro grupos de programas de salud en vista gestion 4505
    /// </summary>
    public class ModeloGrupoActividadesMA : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Ssp_codpro_sspa: Código programa
        private String _ssp_codpro_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: ssp_codpro_sspa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico del programa de salud digitado por el usuario
        /// </para>
        /// </summary>
        public String Ssp_codpro_sspa
        {
            get { return _ssp_codpro_sspa; }
            set
            {
                if (_ssp_codpro_sspa == value) return;
                _ssp_codpro_sspa = value;
                OnPropertyChanged("Ssp_codpro_sspa");
            }
        }
        #endregion
        #region Ssp_abrevi_sspa: Abreviaturas
        private String _ssp_abrevi_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Abreviaturas</para>
        /// <para>NOMBRE: ssp_abrevi_sspa (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Letras iniciales o abreviaturas para identificacion grafica
        /// del programa
        /// </para>
        /// </summary>
        public String Ssp_abrevi_sspa
        {
            get { return _ssp_abrevi_sspa; }
            set
            {
                if (_ssp_abrevi_sspa == value) return;
                _ssp_abrevi_sspa = value;
                OnPropertyChanged("Ssp_abrevi_sspa");
            }
        }
        #endregion
        #region Ssp_titpro_sspa: Titulo programa
        private String _ssp_titpro_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Titulo programa</para>
        /// <para>NOMBRE: ssp_titpro_sspa (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Titulo del programa o descripcion corta
        /// </para>
        /// </summary>
        public String Ssp_titpro_sspa
        {
            get { return _ssp_titpro_sspa; }
            set
            {
                if (_ssp_titpro_sspa == value) return;
                _ssp_titpro_sspa = value;
                OnPropertyChanged("Ssp_titpro_sspa");
            }
        }
        #endregion
        #region Ssp_despro_sspa: Descripcion programa
        private String _ssp_despro_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Descripcion programa</para>
        /// <para>NOMBRE: ssp_despro_sspa (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion del programa ampliada para mostrar como texto de
        /// ayuda
        /// </para>
        /// </summary>
        public String Ssp_despro_sspa
        {
            get { return _ssp_despro_sspa; }
            set
            {
                if (_ssp_despro_sspa == value) return;
                _ssp_despro_sspa = value;
                OnPropertyChanged("Ssp_despro_sspa");
            }
        }
        #endregion
        #region Ssp_tipreg_sspa: Tipo registro
        private String _ssp_tipreg_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: ssp_tipreg_sspa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo registro: 1= Programa de salud 2=Solo es Grupo para clasificar
        /// registros y organizar vistas
        /// </para>
        /// </summary>
        public String Ssp_tipreg_sspa
        {
            get { return _ssp_tipreg_sspa; }
            set
            {
                if (_ssp_tipreg_sspa == value) return;
                _ssp_tipreg_sspa = value;
                OnPropertyChanged("Ssp_tipreg_sspa");
            }
        }
        #endregion
        #region Ssp_ordvis_sspa: Orden visualizacion
        private int _ssp_ordvis_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: ssp_ordvis_sspa (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Orden vista organización
        /// </para>
        /// </summary>
        public int Ssp_ordvis_sspa
        {
            get { return _ssp_ordvis_sspa; }
            set
            {
                if (_ssp_ordvis_sspa == value) return;
                _ssp_ordvis_sspa = value;
                OnPropertyChanged("Ssp_ordvis_sspa");
            }
        }
        #endregion
        #region Ssp_ordpri_sspa: Orden prioridad
        private int _ssp_ordpri_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Orden prioridad</para>
        /// <para>NOMBRE: ssp_ordpri_sspa (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Orden priopridad para el proceso de clasificacion de registros
        /// en en gestion de 4505
        /// </para>
        /// </summary>
        public int Ssp_ordpri_sspa
        {
            get { return _ssp_ordpri_sspa; }
            set
            {
                if (_ssp_ordpri_sspa == value) return;
                _ssp_ordpri_sspa = value;
                OnPropertyChanged("Ssp_ordpri_sspa");
            }
        }
        #endregion
        #region Ssp_mededi_sspa: Medida edad Inicial
        private String _ssp_mededi_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: ssp_mededi_sspa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Ssp_mededi_sspa
        {
            get { return _ssp_mededi_sspa; }
            set
            {
                if (_ssp_mededi_sspa == value) return;
                _ssp_mededi_sspa = value;
                OnPropertyChanged("Ssp_mededi_sspa");
            }
        }
        #endregion
        #region Ssp_edaini_sspa: Edad Inicial
        private int _ssp_edaini_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: ssp_edaini_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Ssp_edaini_sspa
        {
            get { return _ssp_edaini_sspa; }
            set
            {
                if (_ssp_edaini_sspa == value) return;
                _ssp_edaini_sspa = value;
                OnPropertyChanged("Ssp_edaini_sspa");
            }
        }
        #endregion
        #region Ssp_mededf_sspa: Medida edad final
        private String _ssp_mededf_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: ssp_mededf_sspa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Ssp_mededf_sspa
        {
            get { return _ssp_mededf_sspa; }
            set
            {
                if (_ssp_mededf_sspa == value) return;
                _ssp_mededf_sspa = value;
                OnPropertyChanged("Ssp_mededf_sspa");
            }
        }
        #endregion
        #region Ssp_edafin_sspa: Edad final
        private int _ssp_edafin_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: ssp_edafin_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Ssp_edafin_sspa
        {
            get { return _ssp_edafin_sspa; }
            set
            {
                if (_ssp_edafin_sspa == value) return;
                _ssp_edafin_sspa = value;
                OnPropertyChanged("Ssp_edafin_sspa");
            }
        }
        #endregion
        #region Ssp_sexapl_sspa: Sexo que aplica
        private String _ssp_sexapl_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: ssp_sexapl_sspa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public String Ssp_sexapl_sspa
        {
            get { return _ssp_sexapl_sspa; }
            set
            {
                if (_ssp_sexapl_sspa == value) return;
                _ssp_sexapl_sspa = value;
                OnPropertyChanged("Ssp_sexapl_sspa");
            }
        }
        #endregion
        #region Ssp_tv4505_sspa: Total Variables 4505  verificables
        private int _ssp_tv4505_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Total Variables 4505  verificables</para>
        /// <para>NOMBRE: ssp_tv4505_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Cantidad  variables 4505  de  la actividad que deben ser verificables
        /// para clasificar como actividad que identifica a un registro
        /// 4505
        /// </para>
        /// </summary>
        public int Ssp_tv4505_sspa
        {
            get { return _ssp_tv4505_sspa; }
            set
            {
                if (_ssp_tv4505_sspa == value) return;
                _ssp_tv4505_sspa = value;
                OnPropertyChanged("Ssp_tv4505_sspa");
            }
        }
        #endregion
        #region Ssp_tt4505_sspa: Variables minimas 4505  verificables
        private int _ssp_tt4505_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Variables minimas 4505  verificables</para>
        /// <para>NOMBRE: ssp_tt4505_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Cantidad minima de variables 4505  que deben ser verificadas
        /// para clasificar como actividad que identifica a un registro
        /// 4505
        /// </para>
        /// </summary>
        public int Ssp_tt4505_sspa
        {
            get { return _ssp_tt4505_sspa; }
            set
            {
                if (_ssp_tt4505_sspa == value) return;
                _ssp_tt4505_sspa = value;
                OnPropertyChanged("Ssp_tt4505_sspa");
            }
        }
        #endregion
        #region Ssp_tvrips_sspa: Actividades Rips verificables
        private int _ssp_tvrips_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Actividades Rips verificables</para>
        /// <para>NOMBRE: ssp_tvrips_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Cantidad de registros detalles (actividades Rips) que pertenecen
        /// a la actividad que deben ser verificables para clasificar como
        /// actividad que identifica a un registro 4505
        /// </para>
        /// </summary>
        public int Ssp_tvrips_sspa
        {
            get { return _ssp_tvrips_sspa; }
            set
            {
                if (_ssp_tvrips_sspa == value) return;
                _ssp_tvrips_sspa = value;
                OnPropertyChanged("Ssp_tvrips_sspa");
            }
        }
        #endregion
        #region Ssp_ttrips_sspa: Actividades minimas Rips verificables
        private int _ssp_ttrips_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Actividades minimas Rips verificables</para>
        /// <para>NOMBRE: ssp_ttrips_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Cantidad minima de registros detalles (actividades Rips)  que
        /// deben ser verificados para clasificar como actividad que identifica
        /// a un registro 4505
        /// </para>
        /// </summary>
        public int Ssp_ttrips_sspa
        {
            get { return _ssp_ttrips_sspa; }
            set
            {
                if (_ssp_ttrips_sspa == value) return;
                _ssp_ttrips_sspa = value;
                OnPropertyChanged("Ssp_ttrips_sspa");
            }
        }
        #endregion
        #region Ssp_imagen_sspa: Imagen (jpg)
        private String _ssp_imagen_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: ssp_imagen_sspa (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro en las diferentes
        /// vistas
        /// </para>
        /// </summary>
        public String Ssp_imagen_sspa
        {
            get { return _ssp_imagen_sspa; }
            set
            {
                if (_ssp_imagen_sspa == value) return;
                _ssp_imagen_sspa = value;
                OnPropertyChanged("Ssp_imagen_sspa");
            }
        }
        #endregion
        #region Ssp_icolor_sspa: Color fondo imagen
        private String _ssp_icolor_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Color fondo imagen</para>
        /// <para>NOMBRE: ssp_icolor_sspa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Color del fondo en imagen en vista navegacionde registros
        /// </para>
        /// </summary>
        public String Ssp_icolor_sspa
        {
            get { return _ssp_icolor_sspa; }
            set
            {
                if (_ssp_icolor_sspa == value) return;
                _ssp_icolor_sspa = value;
                OnPropertyChanged("Ssp_icolor_sspa");
            }
        }
        #endregion
        #region Ssp_conreg_sspa: Contador registros detalles
        private int _ssp_conreg_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Contador registros detalles</para>
        /// <para>NOMBRE: ssp_conreg_sspa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Contador para generar los códigos registros detalles
        /// </para>
        /// </summary>
        public int Ssp_conreg_sspa
        {
            get { return _ssp_conreg_sspa; }
            set
            {
                if (_ssp_conreg_sspa == value) return;
                _ssp_conreg_sspa = value;
                OnPropertyChanged("Ssp_conreg_sspa");
            }
        }
        #endregion
        #region Ssp_estreg_sspa: Estado del registro
        private String _ssp_estreg_sspa;
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: ssp_estreg_sspa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Ssp_estreg_sspa
        {
            get { return _ssp_estreg_sspa; }
            set
            {
                if (_ssp_estreg_sspa == value) return;
                _ssp_estreg_sspa = value;
                OnPropertyChanged("Ssp_estreg_sspa");
            }
        }
        #endregion
        #region RefObjeto: Referencia objeto en capa propiedades del registro gestion 4505
        /// <summary>
        /// Referencia objeto en capa propiedades del registro gestion 4505
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #region Ssp_TotValrips_sspa: Total actividades Rips validadas
        private int _ssp_valrips_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Total actividades rips que fueron validadas</para>
        /// <para>NOMBRE: Ssp_Valrips_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Cantidad de registros actividades Rips validadas que suman para calificar</para>
        /// </summary>
        public int Ssp_TotValrips_sspa
        {
            get { return _ssp_valrips_sspa; }
            set
            {
                if (_ssp_valrips_sspa == value) return;
                _ssp_valrips_sspa = value;
                OnPropertyChanged("Ssp_TotValrips_sspa");
            }
        }
        #endregion
        #region Ssp_TotVal4505_sspa: Total actividades 4505 validadas
        private int _ssp_Val4505_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Total actividades 4505 que fueron validadas</para>
        /// <para>NOMBRE: Ssp_Val4505_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Cantidad de registros actividades 4505 validadas que suman para calificar</para>
        /// </summary>
        public int Ssp_TotVal4505_sspa
        {
            get { return _ssp_Val4505_sspa; }
            set
            {
                if (_ssp_Val4505_sspa == value) return;
                _ssp_Val4505_sspa = value;
                OnPropertyChanged("Ssp_TotVal4505_sspa");
            }
        }
        #endregion
        #region Ssp_TotDefinit_sspa: Total actividades que determinan de una vez la calificacion
        private int _ssp_TotDefinit_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Total actividades que definen la calificacin</para>
        /// <para>NOMBRE: Ssp_Val4505_sspa (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Total actividades que determinan de una vez la calificacion sin necesidad de sumar con otras</para>
        /// </summary>
        public int Ssp_TotDefinit_sspa
        {
            get { return _ssp_TotDefinit_sspa; }
            set
            {
                if (_ssp_TotDefinit_sspa == value) return;
                _ssp_TotDefinit_sspa = value;
                OnPropertyChanged("Ssp_TotDefinit_sspa");
            }
        }
        #endregion
        #region Ssp_LstDefinit_sspa: Lista de actividades que determinan calificacion encontradas
        private String _ssp_Lstdefinit_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Lista de actividades que determinan calificacion encontradas</para>
        /// <para>NOMBRE: Ssp_LstDefinit_sspa (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION: Lista de actividades (codigo de digitacion) que determinan calificacion encontradas en servicios facturados</para>
        /// <para>separados por punto y coma asi: C001;C045;Otras...</para>
        /// </summary>
        public String Ssp_LstDefinit_sspa
        {
            get { return _ssp_Lstdefinit_sspa; }
            set
            {
                if (_ssp_Lstdefinit_sspa == value) return;
                _ssp_Lstdefinit_sspa = value;
                OnPropertyChanged("Ssp_LstDefinit_sspa");
            }
        }
        #endregion
        #region Estado: Marca en procesos, se usa como campo temporal de gestion
        private String _estado;
        /// <summary>
        /// <para>Marca en procesos, se usa como campo temporal de gestion</para>
        /// </summary>
        public String Estado
        {
            get { return _estado; }
            set
            {
                if (_estado == value) return;
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloGrupoActividadesMA tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFspprogramgrupma
                    {
                        #region cargar Registro
                        ssp_codpro_sspa = tobjModelo.Ssp_codpro_sspa,
                        ssp_abrevi_sspa = tobjModelo.Ssp_abrevi_sspa,
                        ssp_titpro_sspa = tobjModelo.Ssp_titpro_sspa,
                        ssp_despro_sspa = tobjModelo.Ssp_despro_sspa,
                        ssp_tipreg_sspa = tobjModelo.Ssp_tipreg_sspa,
                        ssp_ordvis_sspa = tobjModelo.Ssp_ordvis_sspa,
                        ssp_ordpri_sspa = tobjModelo.Ssp_ordpri_sspa,
                        ssp_mededi_sspa = tobjModelo.Ssp_mededi_sspa,
                        ssp_edaini_sspa = tobjModelo.Ssp_edaini_sspa,
                        ssp_mededf_sspa = tobjModelo.Ssp_mededf_sspa,
                        ssp_edafin_sspa = tobjModelo.Ssp_edafin_sspa,
                        ssp_sexapl_sspa = tobjModelo.Ssp_sexapl_sspa,
                        ssp_tv4505_sspa = tobjModelo.Ssp_tv4505_sspa,
                        ssp_tt4505_sspa = tobjModelo.Ssp_tt4505_sspa,
                        ssp_tvrips_sspa = tobjModelo.Ssp_tvrips_sspa,
                        ssp_ttrips_sspa = tobjModelo.Ssp_ttrips_sspa,
                        ssp_imagen_sspa = tobjModelo.Ssp_imagen_sspa,
                        ssp_icolor_sspa = tobjModelo.Ssp_icolor_sspa,
                        ssp_conreg_sspa = tobjModelo.Ssp_conreg_sspa,
                        ssp_estreg_sspa = tobjModelo.Ssp_estreg_sspa,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.ssp_codpro_sspa;
                    _context.AddToSpprogramgrupma(lobjRegistro);
                    _context.SaveChanges();
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
        public static void fcvActualizar(ModeloGrupoActividadesMA tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tobjModelo.Ssp_codpro_sspa);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.ssp_codpro_sspa = tobjModelo.Ssp_codpro_sspa;
                        lobjRegistro.ssp_abrevi_sspa = tobjModelo.Ssp_abrevi_sspa;
                        lobjRegistro.ssp_titpro_sspa = tobjModelo.Ssp_titpro_sspa;
                        lobjRegistro.ssp_despro_sspa = tobjModelo.Ssp_despro_sspa;
                        lobjRegistro.ssp_tipreg_sspa = tobjModelo.Ssp_tipreg_sspa;
                        lobjRegistro.ssp_ordvis_sspa = (int)tobjModelo.Ssp_ordvis_sspa;
                        lobjRegistro.ssp_ordpri_sspa = (int)tobjModelo.Ssp_ordpri_sspa;
                        lobjRegistro.ssp_mededi_sspa = tobjModelo.Ssp_mededi_sspa;
                        lobjRegistro.ssp_edaini_sspa = (int)tobjModelo.Ssp_edaini_sspa;
                        lobjRegistro.ssp_mededf_sspa = tobjModelo.Ssp_mededf_sspa;
                        lobjRegistro.ssp_edafin_sspa = (int)tobjModelo.Ssp_edafin_sspa;
                        lobjRegistro.ssp_sexapl_sspa = tobjModelo.Ssp_sexapl_sspa;
                        lobjRegistro.ssp_tv4505_sspa = (int)tobjModelo.Ssp_tv4505_sspa;
                        lobjRegistro.ssp_tt4505_sspa = (int)tobjModelo.Ssp_tt4505_sspa;
                        lobjRegistro.ssp_tvrips_sspa = (int)tobjModelo.Ssp_tvrips_sspa;
                        lobjRegistro.ssp_ttrips_sspa = (int)tobjModelo.Ssp_ttrips_sspa;
                        lobjRegistro.ssp_imagen_sspa = tobjModelo.Ssp_imagen_sspa;
                        lobjRegistro.ssp_icolor_sspa = tobjModelo.Ssp_icolor_sspa;
                        lobjRegistro.ssp_conreg_sspa = (int)tobjModelo.Ssp_conreg_sspa;
                        lobjRegistro.ssp_estreg_sspa = tobjModelo.Ssp_estreg_sspa;
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
        #region Eliminar registro
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tcrCodigo);
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
        #region Buscar SPPROGRAMGRUPMA: Logica
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TITULO: Archivo Maestro grupos de programas de salud</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de programas de salud publica y promocion y prevencion
        /// para agrupar y clasificar los registros de 4505 y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSpprogramgrupma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloGrupoActividadesMA> flsListaSpprogramgrupma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from spprogramgrupma in _context.Spprogramgrupma
                                      orderby spprogramgrupma.ssp_ordpri_sspa
                                      select new ModeloGrupoActividadesMA
                                      {
                                          #region Datos
                                          Ssp_codpro_sspa = spprogramgrupma.ssp_codpro_sspa,
                                          Ssp_abrevi_sspa = spprogramgrupma.ssp_abrevi_sspa,
                                          Ssp_titpro_sspa = spprogramgrupma.ssp_titpro_sspa,
                                          Ssp_despro_sspa = spprogramgrupma.ssp_despro_sspa,
                                          Ssp_tipreg_sspa = spprogramgrupma.ssp_tipreg_sspa,
                                          Ssp_ordvis_sspa = (int)spprogramgrupma.ssp_ordvis_sspa,
                                          Ssp_ordpri_sspa = (int)spprogramgrupma.ssp_ordpri_sspa,
                                          Ssp_mededi_sspa = spprogramgrupma.ssp_mededi_sspa,
                                          Ssp_edaini_sspa = (int)spprogramgrupma.ssp_edaini_sspa,
                                          Ssp_mededf_sspa = spprogramgrupma.ssp_mededf_sspa,
                                          Ssp_edafin_sspa = (int)spprogramgrupma.ssp_edafin_sspa,
                                          Ssp_sexapl_sspa = spprogramgrupma.ssp_sexapl_sspa,
                                          Ssp_tv4505_sspa = (int)spprogramgrupma.ssp_tv4505_sspa,
                                          Ssp_tt4505_sspa = (int)spprogramgrupma.ssp_tt4505_sspa,
                                          Ssp_tvrips_sspa = (int)spprogramgrupma.ssp_tvrips_sspa,
                                          Ssp_ttrips_sspa = (int)spprogramgrupma.ssp_ttrips_sspa,
                                          Ssp_imagen_sspa = spprogramgrupma.ssp_imagen_sspa,
                                          Ssp_icolor_sspa = spprogramgrupma.ssp_icolor_sspa,
                                          Ssp_conreg_sspa = (int)spprogramgrupma.ssp_conreg_sspa,
                                          Ssp_estreg_sspa = spprogramgrupma.ssp_estreg_sspa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from spprogramgrupma in _context.Spprogramgrupma
                                      where spprogramgrupma.ssp_codpro_sspa.Contains(tcrBuscar) || spprogramgrupma.ssp_titpro_sspa.Contains(tcrBuscar)
                                      orderby spprogramgrupma.ssp_ordpri_sspa
                                      select new ModeloGrupoActividadesMA
                                      {
                                          #region Datos
                                          Ssp_codpro_sspa = spprogramgrupma.ssp_codpro_sspa,
                                          Ssp_abrevi_sspa = spprogramgrupma.ssp_abrevi_sspa,
                                          Ssp_titpro_sspa = spprogramgrupma.ssp_titpro_sspa,
                                          Ssp_despro_sspa = spprogramgrupma.ssp_despro_sspa,
                                          Ssp_tipreg_sspa = spprogramgrupma.ssp_tipreg_sspa,
                                          Ssp_ordvis_sspa = (int)spprogramgrupma.ssp_ordvis_sspa,
                                          Ssp_ordpri_sspa = (int)spprogramgrupma.ssp_ordpri_sspa,
                                          Ssp_mededi_sspa = spprogramgrupma.ssp_mededi_sspa,
                                          Ssp_edaini_sspa = (int)spprogramgrupma.ssp_edaini_sspa,
                                          Ssp_mededf_sspa = spprogramgrupma.ssp_mededf_sspa,
                                          Ssp_edafin_sspa = (int)spprogramgrupma.ssp_edafin_sspa,
                                          Ssp_sexapl_sspa = spprogramgrupma.ssp_sexapl_sspa,
                                          Ssp_tv4505_sspa = (int)spprogramgrupma.ssp_tv4505_sspa,
                                          Ssp_tt4505_sspa = (int)spprogramgrupma.ssp_tt4505_sspa,
                                          Ssp_tvrips_sspa = (int)spprogramgrupma.ssp_tvrips_sspa,
                                          Ssp_ttrips_sspa = (int)spprogramgrupma.ssp_ttrips_sspa,
                                          Ssp_imagen_sspa = spprogramgrupma.ssp_imagen_sspa,
                                          Ssp_icolor_sspa = spprogramgrupma.ssp_icolor_sspa,
                                          Ssp_conreg_sspa = (int)spprogramgrupma.ssp_conreg_sspa,
                                          Ssp_estreg_sspa = spprogramgrupma.ssp_estreg_sspa,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// spactivservfact: Lista servicios o actividades desde facturación para detectar 4505
    /// </summary>
    public class ModeloSpactivservfactMD : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Ssp_secreg_ssfc: Código registro
        private String _ssp_secreg_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: ssp_secreg_ssfc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Consecutivo unico del registro generado por el sistema</para>
        /// </summary>
        public String Ssp_secreg_ssfc
        {
            get { return _ssp_secreg_ssfc; }
            set
            {
                if (_ssp_secreg_ssfc == value) return;
                _ssp_secreg_ssfc = value;
                OnPropertyChanged("Ssp_secreg_ssfc");
            }
        }
        #endregion
        #region Ssp_codpro_sspa: Código programa
        private String _ssp_codpro_sspa;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: ssp_codpro_sspa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Codigo unico del programa de salud digitado por el usuario </para>
        /// </summary>
        public String Ssp_codpro_sspa
        {
            get { return _ssp_codpro_sspa; }
            set
            {
                if (_ssp_codpro_sspa == value) return;
                _ssp_codpro_sspa = value;
                OnPropertyChanged("Ssp_codpro_sspa");
            }
        }
        #endregion
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
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
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Ssp_coddig_ssfc: Servicio relacionado
        private String _ssp_coddig_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Servicio relacionado</para>
        /// <para>NOMBRE: ssp_coddig_ssfc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio asociado o relacionado que tambien debe
        /// estar en la facturacion, para poder clasificar el grupo (NA cuando no aplique)</para>
        /// </summary>
        public String Ssp_coddig_ssfc
        {
            get { return _ssp_coddig_ssfc; }
            set
            {
                if (_ssp_coddig_ssfc == value) return;
                _ssp_coddig_ssfc = value;
                OnPropertyChanged("Ssp_coddig_ssfc");
            }
        }
        #endregion
        #region Ssp_desser_ssfc: Nombre servicio
        private String _ssp_desser_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: ssp_desser_ssfc (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public String Ssp_desser_ssfc
        {
            get { return _ssp_desser_ssfc; }
            set
            {
                if (_ssp_desser_ssfc == value) return;
                _ssp_desser_ssfc = value;
                OnPropertyChanged("Ssp_desser_ssfc");
            }
        }
        #endregion
        #region Ssp_priori_ssfc: Prioridad en Actividad
        private String _ssp_priori_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Prioridad en Actividad</para>
        /// <para>NOMBRE: ssp_priori_ssfc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Prioridad de la actividad Rips en procesos de clasificacion
        /// del registro 4505 1=Alta (facturada obligatoria para la actividad)
        /// 2=Baja (no existir en lista de servicios)
        /// </para>
        /// </summary>
        public String Ssp_priori_ssfc
        {
            get { return _ssp_priori_ssfc; }
            set
            {
                if (_ssp_priori_ssfc == value) return;
                _ssp_priori_ssfc = value;
                OnPropertyChanged("Ssp_priori_ssfc");
            }
        }
        #endregion
        #region Sia_codfpr_fpro: Finalidad Procedimiento
        private String _sia_codfpr_fpro;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: sia_codfpr_fpro (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: sia_codfco_fcon (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
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
        #region Fcm_mededi_sips: Medida edad Inicial
        private String _fcm_mededi_sips;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: fcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: fcm_edaini_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: fcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: fcm_edafin_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region Fcm_sexapl_sips: Sexo que aplica
        private String _fcm_sexapl_sips;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: fcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos
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
        #region Fcm_coddia_sips: Lista diagnosticos
        private String _fcm_coddia_sips;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Lista diagnosticos</para>
        /// <para>NOMBRE: fcm_coddia_sips (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Lista de diagnosticos CIE -10 permitidos, separados por (punto
        /// y coma)  para validacion en prestacion de servicios y  Gestion
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
        #region Ssp_parmet_ssfc: Parametros de gestion
        private String _ssp_parmet_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Parametros</para>
        /// <para>NOMBRE: ssp_parmet_ssfc (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION: Parametros especiales de gestion</para>
        /// </summary>
        public String Ssp_parmet_ssfc
        {
            get { return _ssp_parmet_ssfc; }
            set
            {
                if (_ssp_parmet_ssfc == value) return;
                _ssp_parmet_ssfc = value;
                OnPropertyChanged("Ssp_parmet_ssfc");
            }
        }
        #endregion
        #region Ssp_estreg_ssfc: Estado del registro
        private String _ssp_estreg_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: ssp_estreg_ssfc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Ssp_estreg_ssfc
        {
            get { return _ssp_estreg_ssfc; }
            set
            {
                if (_ssp_estreg_ssfc == value) return;
                _ssp_estreg_ssfc = value;
                OnPropertyChanged("Ssp_estreg_ssfc");
            }
        }
        #endregion
        #region Ssp_titpro_sspa: Titulo programa
        private String _ssp_titpro_sspa;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Titulo programa</para>
        /// <para>NOMBRE: ssp_titpro_sspa (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Titulo del programa o descripcion corta
        /// </para>
        /// </summary>
        public String Ssp_titpro_sspa
        {
            get { return _ssp_titpro_sspa; }
            set
            {
                if (_ssp_titpro_sspa == value) return;
                _ssp_titpro_sspa = value;
                OnPropertyChanged("Ssp_titpro_sspa");
            }
        }
        #endregion
        #region Sia_desrip_trip: Descripcion tipo Rips
        private String _sia_desrip_trip;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Descripcion tipo Rips</para>
        /// <para>NOMBRE: sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del servicio según tipo Rips  Resolucion
        /// 3374 RIPS: 01=Consulta 02= Procedimientos y mas
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
        #region Sia_desfpr_fpro: Descripción
        private String _sia_desfpr_fpro;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
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
        #region Sia_desfco_fcon: Descripción
        private String _sia_desfco_fcon;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad
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
        #region IdUnicoRegistro: Id unico referencia del registro rips facturacion  
        private String _idUnicoRegistro;
        /// <summary>
        /// <para>Id unico referencia del registro rips cargado desde facturacion o planos</para>
        /// <para>que en el proceso se asocia con el servicio del grupo gestionado en el momento</para>
        /// <para>se usara como llave para quitar marca cuando la actividad no clasifica y se deben liberar los registros marcados</para>
        /// </summary>
        public String IdUnicoRegistro
        {
            get { return _idUnicoRegistro; }
            set
            {
                if (_idUnicoRegistro == value) return;
                _idUnicoRegistro = value;
                OnPropertyChanged("IdUnicoRegistro");
            }
        }
        #endregion
        #region Estado: Marca en procesos, se usa como campo temporal de gestion
        private String _estado;
        /// <summary>
        /// <para>Marca en procesos, se usa como campo temporal de gestion</para>
        /// </summary>
        public String Estado
        {
            get { return _estado; }
            set
            {
                if (_estado == value) return;
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }
        #endregion
        #region Ssp_abrevi_sspa: Abreviaturas
        private String _ssp_abrevi_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Abreviaturas</para>
        /// <para>NOMBRE: ssp_abrevi_sspa (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Letras iniciales o abreviaturas para identificacion grafica
        /// del programa
        /// </para>
        /// </summary>
        public String Ssp_abrevi_sspa
        {
            get { return _ssp_abrevi_sspa; }
            set
            {
                if (_ssp_abrevi_sspa == value) return;
                _ssp_abrevi_sspa = value;
                OnPropertyChanged("Ssp_abrevi_sspa");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloSpactivservfactMD tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFspactivservfact();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Spactivservfact.FirstOrDefault(p => p.ssp_secreg_ssfc == tobTempReg.Ssp_secreg_ssfc);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.ssp_secreg_ssfc = tobTempReg.Ssp_secreg_ssfc;
                            lobEFReg.ssp_codpro_sspa = tobTempReg.Ssp_codpro_sspa;
                            lobEFReg.fcm_codser_sips = tobTempReg.Fcm_codser_sips;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.sia_codrip_trip = tobTempReg.Sia_codrip_trip;
                            lobEFReg.ssp_coddig_ssfc = tobTempReg.Ssp_coddig_ssfc;
                            lobEFReg.ssp_desser_ssfc = tobTempReg.Ssp_desser_ssfc;
                            lobEFReg.ssp_priori_ssfc = tobTempReg.Ssp_priori_ssfc;
                            lobEFReg.sia_codfpr_fpro = tobTempReg.Sia_codfpr_fpro;
                            lobEFReg.sia_codfco_fcon = tobTempReg.Sia_codfco_fcon;
                            lobEFReg.adm_codcex_tcex = tobTempReg.Adm_codcex_tcex;
                            lobEFReg.fcm_mededi_sips = tobTempReg.Fcm_mededi_sips;
                            lobEFReg.fcm_edaini_sips = (int)tobTempReg.Fcm_edaini_sips;
                            lobEFReg.fcm_mededf_sips = tobTempReg.Fcm_mededf_sips;
                            lobEFReg.fcm_edafin_sips = (int)tobTempReg.Fcm_edafin_sips;
                            lobEFReg.fcm_sexapl_sips = tobTempReg.Fcm_sexapl_sips;
                            lobEFReg.fcm_coddia_sips = tobTempReg.Fcm_coddia_sips;
                            lobEFReg.ssp_parmet_ssfc = tobTempReg.Ssp_parmet_ssfc;
                            lobEFReg.ssp_estreg_ssfc = tobTempReg.Ssp_estreg_ssfc;
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
                                lobEFReg.ssp_secreg_ssfc = tcrCodigoR1 + lobEFReg.ssp_secreg_ssfc; // concatenar
                                _context.AddToSpactivservfact(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Spactivservfact.FirstOrDefault(p => p.ssp_secreg_ssfc == tobTempReg.Ssp_secreg_ssfc);
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
        #region Buscar SPACTIVSERVFACT: Logica
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TITULO: Lista servicios o actividades desde facturacion</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO: Devuelve valor de tipo logico True/False pa indicar si existe o no el código.</para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios o activdades medicas facturadas, relacionadas con resolucion 4505 </para>
        /// </summary>
        public static bool flgBuscarSpactivservfact(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spactivservfact.FirstOrDefault(p => p.ssp_secreg_ssfc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros de un grupo
        public static List<ModeloSpactivservfactMD> flsListaSpactivservfact(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
        		var lobConsulta = from spactivservfact in _context.Spactivservfact
                                  join siatablatprips in _context.Siatablatprips on spactivservfact.sia_codrip_trip equals siatablatprips.sia_codrip_trip into tmsiatablatprips
                                  from trip in tmsiatablatprips.DefaultIfEmpty()
                                  where spactivservfact.ssp_codpro_sspa == tcrBuscar
                                  select new ModeloSpactivservfactMD
                                  {
                                    Ssp_secreg_ssfc = spactivservfact.ssp_secreg_ssfc,
                                    Ssp_codpro_sspa = spactivservfact.ssp_codpro_sspa,
                                    Fcm_codser_sips = spactivservfact.fcm_codser_sips,
                                    Fcm_coddig_mant = spactivservfact.fcm_coddig_mant,
                                    Sia_codrip_trip = spactivservfact.sia_codrip_trip,
                                    Ssp_coddig_ssfc = spactivservfact.ssp_coddig_ssfc,
                                    Ssp_desser_ssfc = spactivservfact.ssp_desser_ssfc,
                                    Ssp_priori_ssfc = spactivservfact.ssp_priori_ssfc,
                                    Sia_codfpr_fpro = spactivservfact.sia_codfpr_fpro,
                                    Sia_codfco_fcon = spactivservfact.sia_codfco_fcon,
                                    Adm_codcex_tcex = spactivservfact.adm_codcex_tcex,
                                    Fcm_mededi_sips = spactivservfact.fcm_mededi_sips,
                                    Fcm_edaini_sips = (int)spactivservfact.fcm_edaini_sips,
                                    Fcm_mededf_sips = spactivservfact.fcm_mededf_sips,
                                    Fcm_edafin_sips = (int)spactivservfact.fcm_edafin_sips,
                                    Fcm_sexapl_sips = spactivservfact.fcm_sexapl_sips,
                                    Fcm_coddia_sips = spactivservfact.fcm_coddia_sips,
                                    Ssp_parmet_ssfc = spactivservfact.ssp_parmet_ssfc,
                                    Ssp_estreg_ssfc = spactivservfact.ssp_estreg_ssfc,
                                    Sia_desrip_trip = trip.sia_desrip_trip,
                                  	Sis_estado_imaen = "I",
                                    IdUnicoRegistro = "NA",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar todos los Registros
        /// <summary>
        /// Lista de servicios medicos o actividades para un grupo, las cuales se 
        /// </summary>
        public static List<ModeloSpactivservfactMD> flsListaSpactivservfactTodos()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from spactivservfact in _context.Spactivservfact
                                  join spprogramgrupma in _context.Spprogramgrupma on spactivservfact.ssp_codpro_sspa equals spprogramgrupma.ssp_codpro_sspa into tmpspprogramgrupma
                                  join siatablatprips in _context.Siatablatprips on spactivservfact.sia_codrip_trip equals siatablatprips.sia_codrip_trip into tmsiatablatprips
                                  from sspa in tmpspprogramgrupma.DefaultIfEmpty()
                                  from trip in tmsiatablatprips.DefaultIfEmpty()
                                  orderby spactivservfact.ssp_codpro_sspa
                                  select new ModeloSpactivservfactMD
                                  {
                                      Ssp_secreg_ssfc = spactivservfact.ssp_secreg_ssfc,
                                      Ssp_codpro_sspa = spactivservfact.ssp_codpro_sspa,
                                      Fcm_codser_sips = spactivservfact.fcm_codser_sips,
                                      Fcm_coddig_mant = spactivservfact.fcm_coddig_mant,
                                      Sia_codrip_trip = spactivservfact.sia_codrip_trip,
                                      Ssp_coddig_ssfc = spactivservfact.ssp_coddig_ssfc,
                                      Ssp_desser_ssfc = spactivservfact.ssp_desser_ssfc,
                                      Ssp_priori_ssfc = spactivservfact.ssp_priori_ssfc,
                                      Sia_codfpr_fpro = spactivservfact.sia_codfpr_fpro,
                                      Sia_codfco_fcon = spactivservfact.sia_codfco_fcon,
                                      Adm_codcex_tcex = spactivservfact.adm_codcex_tcex,
                                      Fcm_mededi_sips = spactivservfact.fcm_mededi_sips,
                                      Fcm_edaini_sips = (int)spactivservfact.fcm_edaini_sips,
                                      Fcm_mededf_sips = spactivservfact.fcm_mededf_sips,
                                      Fcm_edafin_sips = (int)spactivservfact.fcm_edafin_sips,
                                      Fcm_sexapl_sips = spactivservfact.fcm_sexapl_sips,
                                      Fcm_coddia_sips = spactivservfact.fcm_coddia_sips,
                                      Ssp_parmet_ssfc = spactivservfact.ssp_parmet_ssfc,
                                      Ssp_estreg_ssfc = spactivservfact.ssp_estreg_ssfc,
                                      Sia_desrip_trip = trip.sia_desrip_trip,
                                      Sis_estado_imaen = "I",
                                      IdUnicoRegistro = "NA",
                                      Ssp_abrevi_sspa = sspa.ssp_abrevi_sspa,
                                      Estado = "NA",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// <para>Temporal para referenciar eventos y actividades que contienen informacion </para> 
    /// <para>4505 de un paciente teniendo como parametro el Numero de admisión y rangos de fechas</para>
    /// </summary>
    public class ModeloSpaActivRegApEventos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: SIAUSUARIOATEND</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
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
        #region Sia_nroide_usua: Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ADMREGADMISION</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION: Secuencial de Admisión del paciente </para>
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
        #region Hcl_codreg_hcca: Tipo Registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: HCLTIPOREGACTIV</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: HCL-APERTURA-GENERAL
        /// = Apertura Historia clinica general HCL-APERTURA-ODON= Apertura
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
        #region Ssp_secreg_ssfc: Código registro
        private String _ssp_secreg_ssfc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: ssp_secreg_ssfc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Consecutivo unico registro actividad medica</para>
        /// </summary>
        public String Ssp_secreg_ssfc
        {
            get { return _ssp_secreg_ssfc; }
            set
            {
                if (_ssp_secreg_ssfc == value) return;
                _ssp_secreg_ssfc = value;
                OnPropertyChanged("Ssp_secreg_ssfc");
            }
        }
        #endregion
        #region Ssp_codpro_sspa: Código programa
        private String _ssp_codpro_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: ssp_codpro_sspa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Codigo unico del Grupo Programa de salud </para>
        /// </summary>
        public String Ssp_codpro_sspa
        {
            get { return _ssp_codpro_sspa; }
            set
            {
                if (_ssp_codpro_sspa == value) return;
                _ssp_codpro_sspa = value;
                OnPropertyChanged("Ssp_codpro_sspa");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: </para>
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
        #region Fcm_secreg_dfac: Código Único registro
        private String _fcm_secreg_dfac;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Secuencial unico del registro o servicio facturado</para>
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
        #region Fcm_fecser_dfac: Fecha servicio
        private DateTime _fcm_fecser_dfac;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Ssp_parmet_ssfc: Parametros de gestion
        private String _ssp_parmet_ssfc;
        /// <summary>
        /// <para>TABLA: spactivservfact</para>
        /// <para>TABLA NATIVA: spactivservfact</para>
        /// <para>CAMPO: Parametros</para>
        /// <para>NOMBRE: ssp_parmet_ssfc (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION: Parametros especiales de gestion servicios facturados</para>
        /// </summary>
        public String Ssp_parmet_ssfc
        {
            get { return _ssp_parmet_ssfc; }
            set
            {
                if (_ssp_parmet_ssfc == value) return;
                _ssp_parmet_ssfc = value;
                OnPropertyChanged("Ssp_parmet_ssfc");
            }
        }
        #endregion
        #region FechaInicioPeriodo Fecha inicio del periodo
        private DateTime _fechaInicioPeriodo;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>DESCRIPCION: Fecha inicio (fecha mas antigua) de busqueda para el registro</para>
        /// </summary>
        public DateTime FechaInicioPeriodo
        {
            get { return _fechaInicioPeriodo; }
            set
            {
                if (_fechaInicioPeriodo == value) return;
                _fechaInicioPeriodo = value;
                OnPropertyChanged("FechaInicioPeriodo");
            }
        }
        #endregion
        #region FechaFinalPeriodo Fecha final del periodo
        private DateTime _fechaFinalPeriodo;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>DESCRIPCION: Fecha final (fecha mas reciente) de busqueda para el registro</para>
        /// </summary>
        public DateTime FechaFinalPeriodo
        {
            get { return _fechaFinalPeriodo; }
            set
            {
                if (_fechaFinalPeriodo == value) return;
                _fechaFinalPeriodo = value;
                OnPropertyChanged("FechaFinalPeriodo");
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
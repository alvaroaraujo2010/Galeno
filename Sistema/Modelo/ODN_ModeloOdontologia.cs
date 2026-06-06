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

namespace Sistema.Modelo
{
    /// <summary>
    /// <para>maestro tratamiento odontologico genera actividades tales como diagnostico, plan de tratamiento y </para>
    /// <para>evolucion (actividades o procedimientos realizados en cada cita). Un evento contempla varias </para>
    /// <para>actividades en diferentes fechas hasta su cierre.</para>
    /// <para>Tabla: ODNEVENTOSMAEST</para>
    /// </summary>
    public class ModeloOdnMaestroTratamiento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Odn_nroreg_odev: Codigo registro maestro
        private String _odn_nroreg_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: odn_nroreg_odev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro
        /// </para>
        /// </summary>
        public String Odn_nroreg_odev
        {
            get { return _odn_nroreg_odev; }
            set
            {
                if (_odn_nroreg_odev == value) return;
                _odn_nroreg_odev = value;
                OnPropertyChanged("Odn_nroreg_odev");
            }
        }
        #endregion
        #region Odn_secreg_odev: Secuencial evento
        private int _odn_secreg_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: odn_secreg_odev (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public int Odn_secreg_odev
        {
            get { return _odn_secreg_odev; }
            set
            {
                if (_odn_secreg_odev == value) return;
                _odn_secreg_odev = value;
                OnPropertyChanged("Odn_secreg_odev");
            }
        }
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código secuencial actividad medica en historial medico del
        /// paciente
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
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
        #region Odn_fecape_odev: Fecha inicia evento
        private DateTime _odn_fecape_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Fecha inicia evento</para>
        /// <para>NOMBRE: odn_fecape_odev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha apertura del evento medico
        /// </para>
        /// </summary>
        public DateTime Odn_fecape_odev
        {
            get { return _odn_fecape_odev; }
            set
            {
                if (_odn_fecape_odev == value) return;
                _odn_fecape_odev = value;
                OnPropertyChanged("Odn_fecape_odev");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que inicia el evento
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
        #region Sia_codare_aser: Area de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
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
        #region Odn_tgrafi_odev: Tipo odontograma
        private String _odn_tgrafi_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Tipo odontograma</para>
        /// <para>NOMBRE: odn_tgrafi_odev (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo  grafica vista actividades para graficar 1= Odontograma
        /// adultos 2= Odontograma niños
        /// </para>
        /// </summary>
        public String Odn_tgrafi_odev
        {
            get { return _odn_tgrafi_odev; }
            set
            {
                if (_odn_tgrafi_odev == value) return;
                _odn_tgrafi_odev = value;
                OnPropertyChanged("Odn_tgrafi_odev");
            }
        }
        #endregion
        #region Odn_sisfec_odev: Fecha sistema
        private DateTime _odn_sisfec_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: odn_sisfec_odev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Odn_sisfec_odev
        {
            get { return _odn_sisfec_odev; }
            set
            {
                if (_odn_sisfec_odev == value) return;
                _odn_sisfec_odev = value;
                OnPropertyChanged("Odn_sisfec_odev");
            }
        }
        #endregion
        #region Odn_sishor_odev: Hora sistema
        private Decimal _odn_sishor_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: odn_sishor_odev (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Odn_sishor_odev
        {
            get { return _odn_sishor_odev; }
            set
            {
                if (_odn_sishor_odev == value) return;
                _odn_sishor_odev = value;
                OnPropertyChanged("Odn_sishor_odev");
            }
        }
        #endregion
        #region Odn_obsape_odev: Observacion apertura
        private String _odn_obsape_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Observacion apertura</para>
        /// <para>NOMBRE: odn_obsape_odev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Observacion para apertura del evento
        /// </para>
        /// </summary>
        public String Odn_obsape_odev
        {
            get { return _odn_obsape_odev; }
            set
            {
                if (_odn_obsape_odev == value) return;
                _odn_obsape_odev = value;
                OnPropertyChanged("Odn_obsape_odev");
            }
        }
        #endregion
        #region Odn_feccie_odev: Fecha cierre tratamiento
        private DateTime _odn_feccie_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Fecha cierre tratamiento</para>
        /// <para>NOMBRE: odn_feccie_odev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Fecha cierre o finalizacion del tratamiento
        /// </para>
        /// </summary>
        public DateTime Odn_feccie_odev
        {
            get { return _odn_feccie_odev; }
            set
            {
                if (_odn_feccie_odev == value) return;
                _odn_feccie_odev = value;
                OnPropertyChanged("Odn_feccie_odev");
            }
        }
        #endregion
        #region Odn_estado_odev: Estado tratamiento
        private String _odn_estado_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Estado tratamiento</para>
        /// <para>NOMBRE: odn_estado_odev (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Estado del tratamiento : 1= Abierto o en proceso  2 = Finalizado y completado  
        /// 3 = Finalizado sin  completar , inicia con estado 1, se muestra combobox al cierre con estados
        /// 2 y 3
        /// </para>
        /// </summary>
        public String Odn_estado_odev
        {
            get { return _odn_estado_odev; }
            set
            {
                if (_odn_estado_odev == value) return;
                _odn_estado_odev = value;
                OnPropertyChanged("Odn_estado_odev");
            }
        }
        #endregion
        #region Odn_obscie_odev: Observacion cierre
        private String _odn_obscie_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Observacion cierre</para>
        /// <para>NOMBRE: odn_obscie_odev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Datos del cierre  -Observacion para cierre  tratamiento
        /// </para>
        /// </summary>
        public String Odn_obscie_odev
        {
            get { return _odn_obscie_odev; }
            set
            {
                if (_odn_obscie_odev == value) return;
                _odn_obscie_odev = value;
                OnPropertyChanged("Odn_obscie_odev");
            }
        }
        #endregion
        #region Odn_secdet_odev: Secuencial reg actividad
        private int _odn_secdet_odev;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Secuencial reg actividad</para>
        /// <para>NOMBRE: odn_secdet_odev (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial para orden vista cada actividad
        /// del tratamiento
        /// </para>
        /// </summary>
        public int Odn_secdet_odev
        {
            get { return _odn_secdet_odev; }
            set
            {
                if (_odn_secdet_odev == value) return;
                _odn_secdet_odev = value;
                OnPropertyChanged("Odn_secdet_odev");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Sia_deside_tide: Descripción Tipo Usuario
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
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
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloOdnMaestroTratamiento tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ODN-TRATAMIENTO-ODONT", "ODN", "Secuencial Tratamiento odontologico");
            if (!flgBuscarOdneventosmaest(lcrCodigoGen))
            {
                int lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Odn_fecape_odev, tobjModelo.Odn_sishor_odev);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFodneventosmaest
                    {
                        #region cargar Registro
                        odn_nroreg_odev = tobjModelo.Odn_nroreg_odev,
                        odn_secreg_odev = lnullaveIndice,
                        hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        odn_fecape_odev = tobjModelo.Odn_fecape_odev,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        odn_tgrafi_odev = tobjModelo.Odn_tgrafi_odev,
                        odn_sisfec_odev = tobjModelo.Odn_sisfec_odev,
                        odn_sishor_odev = tobjModelo.Odn_sishor_odev,
                        odn_obsape_odev = tobjModelo.Odn_obsape_odev,
                        odn_feccie_odev = tobjModelo.Odn_feccie_odev,
                        odn_estado_odev = tobjModelo.Odn_estado_odev,
                        odn_obscie_odev = tobjModelo.Odn_obscie_odev,
                        odn_secdet_odev = tobjModelo.Odn_secdet_odev,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.odn_nroreg_odev = lcrCodigoGen;
                    _context.AddToOdneventosmaest(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ODN-TRATAMIENTO-ODONT':  en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloOdnMaestroTratamiento tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tobjModelo.Odn_nroreg_odev);
                if (lobjRegistro != null)
                {
                    lobjRegistro.odn_nroreg_odev = tobjModelo.Odn_nroreg_odev;
                    lobjRegistro.odn_secreg_odev = (int)tobjModelo.Odn_secreg_odev;
                    lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.odn_fecape_odev = (DateTime)tobjModelo.Odn_fecape_odev;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.odn_tgrafi_odev = tobjModelo.Odn_tgrafi_odev;
                    lobjRegistro.odn_sisfec_odev = (DateTime)tobjModelo.Odn_sisfec_odev;
                    lobjRegistro.odn_sishor_odev = (Decimal)tobjModelo.Odn_sishor_odev;
                    lobjRegistro.odn_obsape_odev = tobjModelo.Odn_obsape_odev;
                    lobjRegistro.odn_feccie_odev = (DateTime)tobjModelo.Odn_feccie_odev;
                    lobjRegistro.odn_estado_odev = tobjModelo.Odn_estado_odev;
                    lobjRegistro.odn_obscie_odev = tobjModelo.Odn_obscie_odev;
                    lobjRegistro.odn_secdet_odev = tobjModelo.Odn_secdet_odev;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fnuGenerarSecuencialVista: Generar el secuencial de vista para registros actividad del tratmiento
        /// <summary>
        /// <para>Generar el numero secuencial para orden vista registros actividad del tratmiento</para>
        /// </summary>
        public static int fnuGenerarSecuencialVista(String tcrIdTratamiento)
        {
            int lnuReturn = 0;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrIdTratamiento);
                if (lobjRegistro != null)
                {
                    lobjRegistro.odn_secdet_odev = lobjRegistro.odn_secdet_odev + 1;
                    _context.SaveChanges();
                    lnuReturn = (int)lobjRegistro.odn_secdet_odev;
                }
            }
            return lnuReturn;
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ODNEVENTOSMAEST: Logica
        /// <summary>
        /// <para>TABLA: odneventosmaest</para>
        /// <para>TITULO: Maestro eventos de atencion clinica</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro maestro que desencadena una secuenca de actividades
        /// tales como diagnostico, plan de tratamiento y evolucion (actividades
        /// o procedimientos realizados en cada cita). Un evento contempla
        /// varias actividades en diferentes fechas hasta su cierre.
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosmaest(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosmaest.FirstOrDefault(p => p.odn_nroreg_odev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsListaOdneventosmaestEx: Listar Registros
        /// <summary>
        /// <para>tcrTipoConsulta:</para>
        /// <para>"1" = Consulta normal por campo Odn_nroreg_odev IG de la tabla</para>
        /// <para>"2" = Consulta por registro de admision</para>
        /// </summary>
        public static List<ModeloOdnMaestroTratamiento> flsListaOdneventosmaestEx(String tcrTipoConsulta, String tcrIDCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lcrIDCodigo = tcrIDCodigo;
                List<ModeloOdnMaestroTratamiento> lobListTemp = null;
                if (tcrTipoConsulta == "2")
                {
                    lcrIDCodigo = String.Empty;
                    var lobTemp = ODNValidarCodigo.fobRegBuscarOdneventosactmsAd(tcrIDCodigo);
                    if (lobTemp != null)
                    {
                        lcrIDCodigo = lobTemp.odn_nroreg_odev;
                    }
                }
                if (!String.IsNullOrEmpty(lcrIDCodigo))
                {
                    #region consulta
                    var lobConsulta = from odneventosmaest in _context.Odneventosmaest
                                      join siamaeprofsalud in _context.Siamaeprofsalud on odneventosmaest.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join siaareapreservi in _context.Siaareapreservi on odneventosmaest.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      where odneventosmaest.odn_nroreg_odev == lcrIDCodigo
                                      select new ModeloOdnMaestroTratamiento
                                      {
                                          Odn_nroreg_odev = odneventosmaest.odn_nroreg_odev,
                                          Odn_secreg_odev = (int)odneventosmaest.odn_secreg_odev,
                                          Hcl_nroreg_hcev = odneventosmaest.hcl_nroreg_hcev,
                                          Sia_idesec_usua = odneventosmaest.sia_idesec_usua,
                                          Sia_tipide_tide = odneventosmaest.sia_tipide_tide,
                                          Sia_nroide_usua = odneventosmaest.sia_nroide_usua,
                                          Odn_fecape_odev = (DateTime)odneventosmaest.odn_fecape_odev,
                                          Sia_codpfa_prof = odneventosmaest.sia_codpfa_prof,
                                          Sia_codare_aser = odneventosmaest.sia_codare_aser,
                                          Odn_tgrafi_odev = odneventosmaest.odn_tgrafi_odev,
                                          Odn_sisfec_odev = (DateTime)odneventosmaest.odn_sisfec_odev,
                                          Odn_sishor_odev = (Decimal)odneventosmaest.odn_sishor_odev,
                                          Odn_obsape_odev = odneventosmaest.odn_obsape_odev,
                                          Odn_feccie_odev = (DateTime)odneventosmaest.odn_feccie_odev,
                                          Odn_estado_odev = odneventosmaest.odn_estado_odev,
                                          Odn_obscie_odev = odneventosmaest.odn_obscie_odev,
                                          Odn_secdet_odev = (int)odneventosmaest.odn_secdet_odev,
                                          Sis_estpro_espr = odneventosmaest.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosmaest.sis_estpro_espr).sis_despro_espr,
                                      };

                    lobListTemp = lobConsulta.ToList();
                    #endregion
                }
                return lobListTemp;
            }
        }
        #endregion
        #region flsListaOdneventosmaestEstado: Listar Registros segun estado
        /// <summary>
        /// <para>Devuelve una lista con los registros maestros para un pacsiente segun el estado tratamiento</para>
        /// <param name ="tcrIDUnicaUsuario">tcrIDUnicaUsuario: Codigo unico del usuario en el sistema</param>
        /// <param name ="tcrEstadoTratamiento">tcrEstadoTratamiento: Segun campo ODN_ESTADO_ODEV asi:  1= Abierto o en en proceso  2 = Finalizado y completado  3 = Finalizado sin  completar</param>
        /// </summary>
        public static List<ModeloOdnMaestroTratamiento> flsListaOdneventosmaestEstado(String tcrIDUnicaUsuario, String tcrEstadoTratamiento)
        {
            using (_context = new DbAplicacion())
            {
                #region consulta
                var lobConsulta = from odneventosmaest in _context.Odneventosmaest
                                  join siamaeprofsalud in _context.Siamaeprofsalud on odneventosmaest.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join siaareapreservi in _context.Siaareapreservi on odneventosmaest.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from aser in tmsiaareapreservi.DefaultIfEmpty()
                                  where odneventosmaest.sia_idesec_usua == tcrIDUnicaUsuario &&
                                        odneventosmaest.odn_estado_odev == tcrEstadoTratamiento
                                  select new ModeloOdnMaestroTratamiento
                                  {
                                      Odn_nroreg_odev = odneventosmaest.odn_nroreg_odev,
                                      Odn_secreg_odev = (int)odneventosmaest.odn_secreg_odev,
                                      Hcl_nroreg_hcev = odneventosmaest.hcl_nroreg_hcev,
                                      Sia_idesec_usua = odneventosmaest.sia_idesec_usua,
                                      Sia_tipide_tide = odneventosmaest.sia_tipide_tide,
                                      Sia_nroide_usua = odneventosmaest.sia_nroide_usua,
                                      Odn_fecape_odev = (DateTime)odneventosmaest.odn_fecape_odev,
                                      Sia_codpfa_prof = odneventosmaest.sia_codpfa_prof,
                                      Sia_codare_aser = odneventosmaest.sia_codare_aser,
                                      Odn_tgrafi_odev = odneventosmaest.odn_tgrafi_odev,
                                      Odn_sisfec_odev = (DateTime)odneventosmaest.odn_sisfec_odev,
                                      Odn_sishor_odev = (Decimal)odneventosmaest.odn_sishor_odev,
                                      Odn_obsape_odev = odneventosmaest.odn_obsape_odev,
                                      Odn_feccie_odev = (DateTime)odneventosmaest.odn_feccie_odev,
                                      Odn_estado_odev = odneventosmaest.odn_estado_odev,
                                      Odn_obscie_odev = odneventosmaest.odn_obscie_odev,
                                      Odn_secdet_odev = (int)odneventosmaest.odn_secdet_odev,
                                      Sis_estpro_espr = odneventosmaest.sis_estpro_espr,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Sia_desare_aser = aser.sia_desare_aser,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosmaest.sis_estpro_espr).sis_despro_espr,
                                  };
                #endregion
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// <para> Maestro registro unico actividad en cada cita.</para>
    /// <para> Tabla: ODNEVENTOSACTMS es el archivo detalles para el maestro</para>
    /// <para> principal de tratamientos odontologicos ODNEVENTOSMAEST</para>
    /// </summary>
    public class ModeloOdnMsActivTratamiento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Odn_nroreg_odac: Codigo actividad
        private String _odn_nroreg_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Codigo actividad</para>
        /// <para>NOMBRE: odn_nroreg_odac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro actividad
        /// </para>
        /// </summary>
        public String Odn_nroreg_odac
        {
            get { return _odn_nroreg_odac; }
            set
            {
                if (_odn_nroreg_odac == value) return;
                _odn_nroreg_odac = value;
                OnPropertyChanged("Odn_nroreg_odac");
            }
        }
        #endregion
        #region Odn_secreg_odac: Secuencial evento
        private int _odn_secreg_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: odn_secreg_odac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public int Odn_secreg_odac
        {
            get { return _odn_secreg_odac; }
            set
            {
                if (_odn_secreg_odac == value) return;
                _odn_secreg_odac = value;
                OnPropertyChanged("Odn_secreg_odac");
            }
        }
        #endregion
        #region Odn_nroreg_odev: Codigo registro evento
        private String _odn_nroreg_odev;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Codigo registro evento</para>
        /// <para>NOMBRE: odn_nroreg_odev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código maestro evento medico al cual pertenece esta actividad
        /// (ODNEVENTOSMAEST)
        /// </para>
        /// </summary>
        public String Odn_nroreg_odev
        {
            get { return _odn_nroreg_odev; }
            set
            {
                if (_odn_nroreg_odev == value) return;
                _odn_nroreg_odev = value;
                OnPropertyChanged("Odn_nroreg_odev");
            }
        }
        #endregion
        #region Odn_tipreg_odac: Tipo registro actividad
        private String _odn_tipreg_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: odn_tipreg_odac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo tipo registro actividad: 1= Diagnostico, 2= Plan de
        /// tratamiento, 3= Evolucion, 4 =  Toma de imágenes
        /// </para>
        /// </summary>
        public String Odn_tipreg_odac
        {
            get { return _odn_tipreg_odac; }
            set
            {
                if (_odn_tipreg_odac == value) return;
                _odn_tipreg_odac = value;
                OnPropertyChanged("Odn_tipreg_odac");
            }
        }
        #endregion
        #region Hcl_tipreg_hctr: Tipo registro actividad
        private String _hcl_tipreg_hctr;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hcltiporegserms</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_tipreg_hctr (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion tipo registro actividad registrada al
        /// paciente en ordenes medicas: MEDI= Medicamentos SERV = Servicios
        /// EVOL= Evoluciones NENF = Notas de enfermeria  y otros SVIT,INCO,DIAG,ALIQ
        /// ,ELIQ…
        /// </para>
        /// </summary>
        public String Hcl_tipreg_hctr
        {
            get { return _hcl_tipreg_hctr; }
            set
            {
                if (_hcl_tipreg_hctr == value) return;
                _hcl_tipreg_hctr = value;
                OnPropertyChanged("Hcl_tipreg_hctr");
            }
        }
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código secuencial actividad medica en historial medico del
        /// paciente (modulo historia clinica)
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
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
        #region Odn_fecact_odac: Fecha actividad
        private DateTime _odn_fecact_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Fecha actividad</para>
        /// <para>NOMBRE: odn_fecact_odac (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha aregistro de actividad
        /// </para>
        /// </summary>
        public DateTime Odn_fecact_odac
        {
            get { return _odn_fecact_odac; }
            set
            {
                if (_odn_fecact_odac == value) return;
                _odn_fecact_odac = value;
                OnPropertyChanged("Odn_fecact_odac");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codare_aser: Area de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
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
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo centro de produccion donde se presta el servicio solo
        /// aplicable para tipo de registros evolucion (para envio a facturacion)
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
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional  que realiza actividad
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
        #region Odn_sisfec_odac: Fecha sistema
        private DateTime _odn_sisfec_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: odn_sisfec_odac (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Odn_sisfec_odac
        {
            get { return _odn_sisfec_odac; }
            set
            {
                if (_odn_sisfec_odac == value) return;
                _odn_sisfec_odac = value;
                OnPropertyChanged("Odn_sisfec_odac");
            }
        }
        #endregion
        #region Odn_sishor_odac: Hora sistema
        private Decimal _odn_sishor_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: odn_sishor_odac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Odn_sishor_odac
        {
            get { return _odn_sishor_odac; }
            set
            {
                if (_odn_sishor_odac == value) return;
                _odn_sishor_odac = value;
                OnPropertyChanged("Odn_sishor_odac");
            }
        }
        #endregion
        #region Odn_observ_odac: Observacion
        private String _odn_observ_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: odn_observ_odac (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Observacion de la actividad
        /// </para>
        /// </summary>
        public String Odn_observ_odac
        {
            get { return _odn_observ_odac; }
            set
            {
                if (_odn_observ_odac == value) return;
                _odn_observ_odac = value;
                OnPropertyChanged("Odn_observ_odac");
            }
        }
        #endregion
        #region Odn_secdet_odac: Secuencial reg Detalles
        private int _odn_secdet_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: odn_secdet_odac (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los registros detalles
        /// de cada actividad
        /// </para>
        /// </summary>
        public int Odn_secdet_odac
        {
            get { return _odn_secdet_odac; }
            set
            {
                if (_odn_secdet_odac == value) return;
                _odn_secdet_odac = value;
                OnPropertyChanged("Odn_secdet_odac");
            }
        }
        #endregion
        #region Odn_estact_odac: Estado actividad
        private String _odn_estact_odac;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Estado actividad</para>
        /// <para>NOMBRE: odn_estact_odac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Estado actividad: 1= Pendiente  2= En proceso 3=Finalizada
        /// (cuando este finalizada se envia a facturacion) Para los registros
        /// de actividades relacionadas a un plan de tratamiento el valor
        /// sera 3 = Finalizada
        /// </para>
        /// </summary>
        public String Odn_estact_odac
        {
            get { return _odn_estact_odac; }
            set
            {
                if (_odn_estact_odac == value) return;
                _odn_estact_odac = value;
                OnPropertyChanged("Odn_estact_odac");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Odn_obsape_odev: Observacion apertura
        private String _odn_obsape_odev;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Observacion apertura</para>
        /// <para>NOMBRE: odn_obsape_odev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Observacion para apertura del evento
        /// </para>
        /// </summary>
        public String Odn_obsape_odev
        {
            get { return _odn_obsape_odev; }
            set
            {
                if (_odn_obsape_odev == value) return;
                _odn_obsape_odev = value;
                OnPropertyChanged("Odn_obsape_odev");
            }
        }
        #endregion
        #region Hcl_desreg_hcev: Descripción Evento
        private String _hcl_desreg_hcev;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev
        {
            get { return _hcl_desreg_hcev; }
            set
            {
                if (_hcl_desreg_hcev == value) return;
                _hcl_desreg_hcev = value;
                OnPropertyChanged("Hcl_desreg_hcev");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        /// <para>TABLA: odneventosactms</para>
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
        #region Hcl_destur_hctu: Descripcion
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
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
        #region Hcl_desreg_hctr: Descripcion
        private String _hcl_desreg_hctr;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: hcltiporegserms</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_desreg_hctr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  clasificacion tipo registro actividad registrada
        /// al paciente en ordenes medicas
        /// </para>
        /// </summary>
        public String Hcl_desreg_hctr
        {
            get { return _hcl_desreg_hctr; }
            set
            {
                if (_hcl_desreg_hctr == value) return;
                _hcl_desreg_hctr = value;
                OnPropertyChanged("Hcl_desreg_hctr");
            }
        }
        #endregion
        #region Fcm_codman_mans: Código manual servicios
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios (tarifario)</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejemplo: 01= Manual SOAT mas el 10 para la empresa ...
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloOdnMsActivTratamiento tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ODN-ACTIVIDADES-ODONT", "ODN", "Secuencial Actividades Tratamiento odontologico");
            if (!flgBuscarOdneventosactms(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFodneventosactms
                    {
                        #region cargar Registro
                        odn_nroreg_odac = tobjModelo.Odn_nroreg_odac,
                        odn_secreg_odac = ModeloOdnMaestroTratamiento.fnuGenerarSecuencialVista(tobjModelo.Odn_nroreg_odev),
                        odn_nroreg_odev = tobjModelo.Odn_nroreg_odev,
                        odn_tipreg_odac = tobjModelo.Odn_tipreg_odac,
                        hcl_tipreg_hctr = tobjModelo.Hcl_tipreg_hctr,
                        hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                        cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        odn_fecact_odac = tobjModelo.Odn_fecact_odac,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        odn_sisfec_odac = tobjModelo.Odn_sisfec_odac,
                        odn_sishor_odac = tobjModelo.Odn_sishor_odac,
                        odn_observ_odac = tobjModelo.Odn_observ_odac,
                        odn_secdet_odac = tobjModelo.Odn_secdet_odac,
                        odn_estact_odac = tobjModelo.Odn_estact_odac,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.odn_nroreg_odac = lcrCodigoGen;
                    _context.AddToOdneventosactms(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ODN-ODNEVENTOSACTMS': Maestro registro unico actividad en cada cita en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloOdnMsActivTratamiento tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tobjModelo.Odn_nroreg_odac);
                if (lobjRegistro != null)
                {
                    lobjRegistro.odn_nroreg_odac = tobjModelo.Odn_nroreg_odac;
                    lobjRegistro.odn_secreg_odac = (int)tobjModelo.Odn_secreg_odac;
                    lobjRegistro.odn_nroreg_odev = tobjModelo.Odn_nroreg_odev;
                    lobjRegistro.odn_tipreg_odac = tobjModelo.Odn_tipreg_odac;
                    lobjRegistro.hcl_tipreg_hctr = tobjModelo.Hcl_tipreg_hctr;
                    lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.odn_fecact_odac = (DateTime)tobjModelo.Odn_fecact_odac;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.odn_sisfec_odac = (DateTime)tobjModelo.Odn_sisfec_odac;
                    lobjRegistro.odn_sishor_odac = (Decimal)tobjModelo.Odn_sishor_odac;
                    lobjRegistro.odn_observ_odac = tobjModelo.Odn_observ_odac;
                    lobjRegistro.odn_secdet_odac = tobjModelo.Odn_secdet_odac;
                    lobjRegistro.odn_estact_odac = tobjModelo.Odn_estact_odac;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fnuGenerarSecuencialVista: Generar el numero secuencial para orden vista registros detalles de actividad
        /// <summary>
        /// <para>Generar el numero secuencial para orden vista registros detalles de actividad</para>
        /// </summary>
        public static int fnuGenerarSecuencialVista(String tcrIdActividad)
        {
            int lnuReturn = 0;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrIdActividad);
                if (lobjRegistro != null)
                {
                    lobjRegistro.odn_secdet_odac = lobjRegistro.odn_secdet_odac + 1;
                    _context.SaveChanges();
                    lnuReturn = (int)lobjRegistro.odn_secdet_odac;
                }
            }
            return lnuReturn;
        }
        #endregion
        #region Buscar ODNEVENTOSACTMS: Logica
        /// <summary>
        /// <para>TABLA: odneventosactms</para>
        /// <para>TITULO: Maestro registro unico actividad en cada cita</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro registro unico actividad en cada cita, tipos de registro
        /// Actividad: 1= Diagnostico inicial , 2=Plan de tratamiento,
        /// 3= Evolucion en cada cita, 4 = Toma de imágenes o Rx
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosactms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactms.FirstOrDefault(p => p.odn_nroreg_odac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsListaOdneventosactms: Listar Registros
        /// <summary>
        /// <para>tcrTipo: "IG" = Odn_nroreg_odac uno solo  "R1" = Odn_nroreg_odev lista tipo detalles </para>
        /// </summary>
        public static List<ModeloOdnMsActivTratamiento> flsListaOdneventosactms(String tcrTipo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "R1")
                {
                    #region consulta
                    var lobConsulta = from odneventosactms in _context.Odneventosactms
                                      join hcltiporegserms in _context.Hcltiporegserms on odneventosactms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                      join siaareapreservi in _context.Siaareapreservi on odneventosactms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on odneventosactms.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siamaeprofsalud in _context.Siamaeprofsalud on odneventosactms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where odneventosactms.odn_nroreg_odev == tcrBuscar
                                      orderby odneventosactms.odn_secreg_odac descending
                                      select new ModeloOdnMsActivTratamiento
                                      {
                                          Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                          Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                          Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                          Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                          Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                          Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                          Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                          Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                          Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                          Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                          Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                          Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                          Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                          Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                          Sia_codare_aser = odneventosactms.sia_codare_aser,
                                          Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                          Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                          Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                          Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                          Odn_observ_odac = odneventosactms.odn_observ_odac,
                                          Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                          Odn_estact_odac = odneventosactms.odn_estact_odac,
                                          Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                          Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_codman_mans = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == odneventosactms.cto_seccon_cont).fcm_codman_mans,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosactms.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from odneventosactms in _context.Odneventosactms
                                      join hcltiporegserms in _context.Hcltiporegserms on odneventosactms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                      join siaareapreservi in _context.Siaareapreservi on odneventosactms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on odneventosactms.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siamaeprofsalud in _context.Siamaeprofsalud on odneventosactms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where odneventosactms.odn_nroreg_odac == tcrBuscar
                                      select new ModeloOdnMsActivTratamiento
                                      {
                                          Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                          Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                          Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                          Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                          Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                          Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                          Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                          Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                          Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                          Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                          Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                          Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                          Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                          Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                          Sia_codare_aser = odneventosactms.sia_codare_aser,
                                          Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                          Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                          Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                          Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                          Odn_observ_odac = odneventosactms.odn_observ_odac,
                                          Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                          Odn_estact_odac = odneventosactms.odn_estact_odac,
                                          Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                          Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_codman_mans = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == odneventosactms.cto_seccon_cont).fcm_codman_mans,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosactms.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #region flsListaOdneventosactmsEx: Listar Registros
        /// <summary>
        /// <para>tcrTipoConsulta:</para>
        /// <para>"1" = Consulta normal por campo Odn_nroreg_odac IG de la tabla</para>
        /// <para>"2" = Consulta por registro de admision</para>
        /// <para>tcrEstadoRegistro:</para>
        /// <para>Estado registro: "1" = Abierto "2" = Confirmados "3" = Anulados  "" = vacio/todas</para>
        /// <para>El estado registro se usa para  tcrTipoConsulta =="2"</para>
        /// </summary>
        public static List<ModeloOdnMsActivTratamiento> flsListaOdneventosactmsEx(String tcrTipoConsulta, String tcrIDCodigo, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipoConsulta == "2")
                {
                    var lcrIDCodigo = String.Empty;
                    var lobTemp = ODNValidarCodigo.fobRegBuscarOdneventosactmsAd(tcrIDCodigo);
                    if (lobTemp != null)
                    {
                        lcrIDCodigo = lobTemp.odn_nroreg_odev;
                    }

                    if (!String.IsNullOrWhiteSpace(tcrEstadoRegistro))
                    {
                        #region consulta
                        var lobConsulta = from odneventosactms in _context.Odneventosactms
                                          join hcltiporegserms in _context.Hcltiporegserms on odneventosactms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                          join siaareapreservi in _context.Siaareapreservi on odneventosactms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join fcmcenproduccio in _context.Fcmcenproduccio on odneventosactms.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                          join siamaeprofsalud in _context.Siamaeprofsalud on odneventosactms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          where odneventosactms.odn_nroreg_odev == lcrIDCodigo &&
                                                odneventosactms.sis_estpro_espr == tcrEstadoRegistro
                                          orderby odneventosactms.odn_secreg_odac descending
                                          select new ModeloOdnMsActivTratamiento
                                          {
                                              Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                              Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                              Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                              Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                              Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                              Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                              Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                              Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                              Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                              Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                              Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                              Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                              Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                              Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                              Sia_codare_aser = odneventosactms.sia_codare_aser,
                                              Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                              Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                              Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                              Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                              Odn_observ_odac = odneventosactms.odn_observ_odac,
                                              Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                              Odn_estact_odac = odneventosactms.odn_estact_odac,
                                              Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                              Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosactms.sis_estpro_espr).sis_despro_espr,
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                    else 
                    {
                        #region consulta
                        var lobConsulta = from odneventosactms in _context.Odneventosactms
                                          join hcltiporegserms in _context.Hcltiporegserms on odneventosactms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                          join siaareapreservi in _context.Siaareapreservi on odneventosactms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join fcmcenproduccio in _context.Fcmcenproduccio on odneventosactms.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                          join siamaeprofsalud in _context.Siamaeprofsalud on odneventosactms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          where odneventosactms.odn_nroreg_odev == lcrIDCodigo
                                          orderby odneventosactms.odn_secreg_odac descending
                                          select new ModeloOdnMsActivTratamiento
                                          {
                                              Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                              Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                              Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                              Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                              Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                              Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                              Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                              Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                              Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                              Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                              Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                              Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                              Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                              Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                              Sia_codare_aser = odneventosactms.sia_codare_aser,
                                              Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                              Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                              Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                              Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                              Odn_observ_odac = odneventosactms.odn_observ_odac,
                                              Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                              Odn_estact_odac = odneventosactms.odn_estact_odac,
                                              Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                              Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosactms.sis_estpro_espr).sis_despro_espr,
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                }
                else
                {
                    #region consulta
                    var lobConsulta = from odneventosactms in _context.Odneventosactms
                                      join hcltiporegserms in _context.Hcltiporegserms on odneventosactms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                      join siaareapreservi in _context.Siaareapreservi on odneventosactms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on odneventosactms.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siamaeprofsalud in _context.Siamaeprofsalud on odneventosactms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where odneventosactms.odn_nroreg_odac == tcrIDCodigo
                                      select new ModeloOdnMsActivTratamiento
                                      {
                                          Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                          Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                          Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                          Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                          Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                          Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                          Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                          Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                          Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                          Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                          Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                          Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                          Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                          Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                          Sia_codare_aser = odneventosactms.sia_codare_aser,
                                          Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                          Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                          Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                          Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                          Odn_observ_odac = odneventosactms.odn_observ_odac,
                                          Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                          Odn_estact_odac = odneventosactms.odn_estact_odac,
                                          Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                          Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == odneventosactms.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #region flsListaOdneventosactmsRef: Listar registro actividad por tipo en un tratamiento
        /// <summary>
        /// <para>tcrTipo: "1" = Diagnostico inicial "2" = Plan de tratamiento "3" =Actividades Evolucion "4" = Imagenes.</para> 
        /// <para>tcrIdTratamiento: Codigo del Registro maestro de todo el tratamiento</para>
        /// </summary>
        public static List<ModeloOdnMsActivTratamiento> flsListaOdneventosactmsRef(String tcrTipo, String tcrIdTratamiento)
        {
            using (_context = new DbAplicacion())
            {
                #region consulta
                var lobConsulta = from odneventosactms in _context.Odneventosactms
                                  where odneventosactms.odn_nroreg_odev == tcrIdTratamiento &&
                                        odneventosactms.odn_tipreg_odac == tcrTipo
                                  orderby odneventosactms.odn_secreg_odac descending
                                  select new ModeloOdnMsActivTratamiento
                                  {
                                      Odn_nroreg_odac = odneventosactms.odn_nroreg_odac,
                                      Odn_secreg_odac = (int)odneventosactms.odn_secreg_odac,
                                      Odn_nroreg_odev = odneventosactms.odn_nroreg_odev,
                                      Odn_tipreg_odac = odneventosactms.odn_tipreg_odac,
                                      Hcl_tipreg_hctr = odneventosactms.hcl_tipreg_hctr,
                                      Hcl_nroreg_hcev = odneventosactms.hcl_nroreg_hcev,
                                      Adm_secadm_rgad = odneventosactms.adm_secadm_rgad,
                                      Sia_idesec_usua = odneventosactms.sia_idesec_usua,
                                      Sia_tipide_tide = odneventosactms.sia_tipide_tide,
                                      Sia_nroide_usua = odneventosactms.sia_nroide_usua,
                                      Cto_seccon_cont = odneventosactms.cto_seccon_cont,
                                      Cto_nrocon_cont = odneventosactms.cto_nrocon_cont,
                                      Sia_codeps_teps = odneventosactms.sia_codeps_teps,
                                      Odn_fecact_odac = (DateTime)odneventosactms.odn_fecact_odac,
                                      Hcl_tiptur_hctu = odneventosactms.hcl_tiptur_hctu,
                                      Sia_codare_aser = odneventosactms.sia_codare_aser,
                                      Fcm_codcpr_cpro = odneventosactms.fcm_codcpr_cpro,
                                      Sia_codpfa_prof = odneventosactms.sia_codpfa_prof,
                                      Odn_sisfec_odac = (DateTime)odneventosactms.odn_sisfec_odac,
                                      Odn_sishor_odac = (Decimal)odneventosactms.odn_sishor_odac,
                                      Odn_observ_odac = odneventosactms.odn_observ_odac,
                                      Odn_secdet_odac = (int)odneventosactms.odn_secdet_odac,
                                      Odn_estact_odac = odneventosactms.odn_estact_odac,
                                      Sis_estpro_espr = odneventosactms.sis_estpro_espr,
                                  };
                return lobConsulta.ToList();
                #endregion
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// <para> Maestro detalle registro individual de cada una de las actividades dadas en una cita.</para>
    /// <para> Tabla: ODNEVENTOSACTDE es el archivo detalles para el maestro ODNEVENTOSACTMS</para>
    /// </summary>
    public class ModeloOdnDeActivTratamiento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Odn_nroreg_odde: Codigo detalle actividad
        private String _odn_nroreg_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Codigo detalle actividad</para>
        /// <para>NOMBRE: odn_nroreg_odde (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código registro detalle actividad
        /// </para>
        /// </summary>
        public String Odn_nroreg_odde
        {
            get { return _odn_nroreg_odde; }
            set
            {
                if (_odn_nroreg_odde == value) return;
                _odn_nroreg_odde = value;
                OnPropertyChanged("Odn_nroreg_odde");
            }
        }
        #endregion
        #region Odn_secreg_odde: Orden vista actividad
        private int _odn_secreg_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Orden vista actividad</para>
        /// <para>NOMBRE: odn_secreg_odde (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// en detalles de actividad
        /// </para>
        /// </summary>
        public int Odn_secreg_odde
        {
            get { return _odn_secreg_odde; }
            set
            {
                if (_odn_secreg_odde == value) return;
                _odn_secreg_odde = value;
                OnPropertyChanged("Odn_secreg_odde");
            }
        }
        #endregion
        #region Odn_nroreg_odac: Codigo actividad
        private String _odn_nroreg_odac;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Codigo actividad</para>
        /// <para>NOMBRE: odn_nroreg_odac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro actividad (registro
        /// principal)
        /// </para>
        /// </summary>
        public String Odn_nroreg_odac
        {
            get { return _odn_nroreg_odac; }
            set
            {
                if (_odn_nroreg_odac == value) return;
                _odn_nroreg_odac = value;
                OnPropertyChanged("Odn_nroreg_odac");
            }
        }
        #endregion
        #region Odn_nroreg_odev: Codigo registro evento
        private String _odn_nroreg_odev;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosmaest</para>
        /// <para>CAMPO: Codigo registro evento</para>
        /// <para>NOMBRE: odn_nroreg_odev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código maestro evento medico al cual pertenecen los detalles
        /// de esta actividad (ODNEVENTOSMAEST)
        /// </para>
        /// </summary>
        public String Odn_nroreg_odev
        {
            get { return _odn_nroreg_odev; }
            set
            {
                if (_odn_nroreg_odev == value) return;
                _odn_nroreg_odev = value;
                OnPropertyChanged("Odn_nroreg_odev");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Odn_tipreg_odac: Tipo registro actividad
        private String _odn_tipreg_odac;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: odn_tipreg_odac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo tipo registro actividad: 1= Diagnostico, 2= Plan de
        /// tratamiento, 3= Evolucion, 4 =  Toma de imágenes
        /// </para>
        /// </summary>
        public String Odn_tipreg_odac
        {
            get { return _odn_tipreg_odac; }
            set
            {
                if (_odn_tipreg_odac == value) return;
                _odn_tipreg_odac = value;
                OnPropertyChanged("Odn_tipreg_odac");
            }
        }
        #endregion
        #region Odn_auxreg_odde: Codigo detalle referencia
        private String _odn_auxreg_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Codigo detalle referencia</para>
        /// <para>NOMBRE: odn_auxreg_odde (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Registro detalle actividad referenciado como principa, para
        /// registros del plan de tratamiento debe ser un diagnostico y
        /// para evoluciones es tipo Plan de tratamiento (ODN_NROREG_ODDE)
        /// </para>
        /// </summary>
        public String Odn_auxreg_odde
        {
            get { return _odn_auxreg_odde; }
            set
            {
                if (_odn_auxreg_odde == value) return;
                _odn_auxreg_odde = value;
                OnPropertyChanged("Odn_auxreg_odde");
            }
        }
        #endregion
        #region Odn_fecact_odac: Fecha actividad
        private DateTime _odn_fecact_odac;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Fecha actividad</para>
        /// <para>NOMBRE: odn_fecact_odac (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha registro actividad
        /// </para>
        /// </summary>
        public DateTime Odn_fecact_odac
        {
            get { return _odn_fecact_odac; }
            set
            {
                if (_odn_fecact_odac == value) return;
                _odn_fecact_odac = value;
                OnPropertyChanged("Odn_fecact_odac");
            }
        }
        #endregion
        #region Odn_coddia_oddx: Codigo diagnostico tabla odontologia
        private String _odn_coddia_oddx;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odndiagnosticos</para>
        /// <para>CAMPO: Codigo diagnostico</para>
        /// <para>NOMBRE: odn_coddia_oddx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo registro unico tabla diagnostico odontologia para CIE-10
        /// </para>
        /// </summary>
        public String Odn_coddia_oddx
        {
            get { return _odn_coddia_oddx; }
            set
            {
                if (_odn_coddia_oddx == value) return;
                _odn_coddia_oddx = value;
                OnPropertyChanged("Odn_coddia_oddx");
            }
        }
        #endregion
        #region Sia_coddia_tdia: Diagnostico Cie10
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Cie10</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// codigo de la enfermedad según la tabla de diagnostico de la
        /// CIE-10
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
        #region Odn_codser_odsi: Servicio odontologico
        private String _odn_codser_odsi;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnserviciosips</para>
        /// <para>CAMPO: Servicio odontologico</para>
        /// <para>NOMBRE: odn_codser_odsi (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo  servicio IPS odontológico configurado en odontologia
        /// </para>
        /// </summary>
        public String Odn_codser_odsi
        {
            get { return _odn_codser_odsi; }
            set
            {
                if (_odn_codser_odsi == value) return;
                _odn_codser_odsi = value;
                OnPropertyChanged("Odn_codser_odsi");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Fcm_idesec_mant: Codigo unico tarifario
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Odn_desreg_odde: Descripcion registro
        private String _odn_desreg_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Descripcion registro</para>
        /// <para>NOMBRE: odn_desreg_odde (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Descripcion del servicio o diagnostico según el tipo de registro
        /// actividad
        /// </para>
        /// </summary>
        public String Odn_desreg_odde
        {
            get { return _odn_desreg_odde; }
            set
            {
                if (_odn_desreg_odde == value) return;
                _odn_desreg_odde = value;
                OnPropertyChanged("Odn_desreg_odde");
            }
        }
        #endregion
        #region Odn_totuni_odde: Total unidades
        private int _odn_totuni_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: odn_totuni_odde (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total unidades del servicio o procedimiento para efectos de
        /// facturacion
        /// </para>
        /// </summary>
        public int Odn_totuni_odde
        {
            get { return _odn_totuni_odde; }
            set
            {
                if (_odn_totuni_odde == value) return;
                _odn_totuni_odde = value;
                OnPropertyChanged("Odn_totuni_odde");
            }
        }
        #endregion
        #region Odn_coddie_oddi: Código Diente
        private String _odn_coddie_oddi;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Código Diente</para>
        /// <para>NOMBRE: odn_coddie_oddi (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Codigo del Diente segun el Odontograma al cual se realiza el
        /// servicio
        /// </para>
        /// </summary>
        public String Odn_coddie_oddi
        {
            get { return _odn_coddie_oddi; }
            set
            {
                if (_odn_coddie_oddi == value) return;
                _odn_coddie_oddi = value;
                OnPropertyChanged("Odn_coddie_oddi");
            }
        }
        #endregion
        #region Odn_codana_odan: Código anatomia
        private String _odn_codana_odan;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnanatomdiente</para>
        /// <para>CAMPO: Código anatomia</para>
        /// <para>NOMBRE: odn_codana_odan (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// (Para vista en reporte) Anatomia para caras y detalles del
        /// diente asi: 1=Vistibular, 2=Mesial,3=Palatino-Lingual,4=Distal,
        /// 5=Oclusal, 6 = corona 7 = Diente, 8 = NA
        /// </para>
        /// </summary>
        public String Odn_codana_odan
        {
            get { return _odn_codana_odan; }
            set
            {
                if (_odn_codana_odan == value) return;
                _odn_codana_odan = value;
                OnPropertyChanged("Odn_codana_odan");
            }
        }
        #endregion
        #region Odn_carmar_odde: Caras marcadas
        private String _odn_carmar_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Caras marcadas</para>
        /// <para>NOMBRE: odn_carmar_odde (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Caras marcadas del diente cuando la grafica es en la corona:
        /// "1" = Cara1,"2","3","4","5" = Cara5
        /// </para>
        /// </summary>
        public String Odn_carmar_odde
        {
            get { return _odn_carmar_odde; }
            set
            {
                if (_odn_carmar_odde == value) return;
                _odn_carmar_odde = value;
                OnPropertyChanged("Odn_carmar_odde");
            }
        }
        #endregion
        #region Odn_fecini_odde: Fecha inicio actividad
        private DateTime _odn_fecini_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Fecha inicio actividad</para>
        /// <para>NOMBRE: odn_fecini_odde (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Fecha inicia trabajos para la actividad
        /// </para>
        /// </summary>
        public DateTime Odn_fecini_odde
        {
            get { return _odn_fecini_odde; }
            set
            {
                if (_odn_fecini_odde == value) return;
                _odn_fecini_odde = value;
                OnPropertyChanged("Odn_fecini_odde");
            }
        }
        #endregion
        #region Odn_fecfin_odde: Fecha fin actividad
        private DateTime _odn_fecfin_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Fecha fin actividad</para>
        /// <para>NOMBRE: odn_fecfin_odde (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Fecha finalización actividad
        /// </para>
        /// </summary>
        public DateTime Odn_fecfin_odde
        {
            get { return _odn_fecfin_odde; }
            set
            {
                if (_odn_fecfin_odde == value) return;
                _odn_fecfin_odde = value;
                OnPropertyChanged("Odn_fecfin_odde");
            }
        }
        #endregion
        #region Odn_finpro_odde: actividad finaliza procedimiento
        private String _odn_finpro_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Finaliza procedimiento</para>
        /// <para>NOMBRE: odn_finpro_odde (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Actividad Finaliza procedimiento relacionado : 1= SI  2= No,
        /// solo aplica para Actividades de Evolucion, al confirmar las
        /// actividades se deben reflejar en  cada procedimiento del Plan
        /// de tratamiento
        /// </para>
        /// </summary>
        public String Odn_finpro_odde
        {
            get { return _odn_finpro_odde; }
            set
            {
                if (_odn_finpro_odde == value) return;
                _odn_finpro_odde = value;
                OnPropertyChanged("Odn_finpro_odde");
            }
        }
        #endregion
        #region Odn_prexis_odde: Procedimiento pre existentes
        private String _odn_prexis_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Procedimiento pre existentes</para>
        /// <para>NOMBRE: odn_prexis_odde (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Procedimiento pre existente : 1= SI  2= No, solo aplica para
        /// el Plan de Tratamiento, no se  deben mostrar como relacionados
        /// en actividades de evolucion del tratamiento ni se deben facturar
        /// </para>
        /// </summary>
        public String Odn_prexis_odde
        {
            get { return _odn_prexis_odde; }
            set
            {
                if (_odn_prexis_odde == value) return;
                _odn_prexis_odde = value;
                OnPropertyChanged("Odn_prexis_odde");
            }
        }
        #endregion
        #region Odn_estact_odac: Estado actividad
        private String _odn_estact_odac;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Estado actividad</para>
        /// <para>NOMBRE: odn_estact_odac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Estado actividad: 1= Pendiente  2= En proceso 3=Finalizada
        /// (cuando este finalizada se envia a facturacion) Para los registros
        /// de actividades relacionadas a un plan de tratamiento el valor
        /// sera 3 = Finalizada
        /// </para>
        /// </summary>
        public String Odn_estact_odac
        {
            get { return _odn_estact_odac; }
            set
            {
                if (_odn_estact_odac == value) return;
                _odn_estact_odac = value;
                OnPropertyChanged("Odn_estact_odac");
            }
        }
        #endregion
        #region Odn_codimg_odim: Codigo imagen
        private String _odn_codimg_odim;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnimagengrafms</para>
        /// <para>CAMPO: Codigo imagen</para>
        /// <para>NOMBRE: odn_codimg_odim (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Codigo unico de la imagen para graficar
        /// </para>
        /// </summary>
        public String Odn_codimg_odim
        {
            get { return _odn_codimg_odim; }
            set
            {
                if (_odn_codimg_odim == value) return;
                _odn_codimg_odim = value;
                OnPropertyChanged("Odn_codimg_odim");
            }
        }
        #endregion
        #region Odn_imagen_odde: Imagen graficada
        private String _odn_imagen_odde;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactde</para>
        /// <para>CAMPO: Imagen graficada</para>
        /// <para>NOMBRE: odn_imagen_odde (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// nombre de la imagen en formato jpg o png que se utilizo para
        /// graficar en odontograma (para poder usarla en vista detalles
        /// o browser)
        /// </para>
        /// </summary>
        public String Odn_imagen_odde
        {
            get { return _odn_imagen_odde; }
            set
            {
                if (_odn_imagen_odde == value) return;
                _odn_imagen_odde = value;
                OnPropertyChanged("Odn_imagen_odde");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Odn_observ_odac: Observacion
        private String _odn_observ_odac;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odneventosactms</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: odn_observ_odac (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Observacion de la actividad
        /// </para>
        /// </summary>
        public String Odn_observ_odac
        {
            get { return _odn_observ_odac; }
            set
            {
                if (_odn_observ_odac == value) return;
                _odn_observ_odac = value;
                OnPropertyChanged("Odn_observ_odac");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
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
        #region Odn_desdia_oddx: Descripcion  diagnostico
        private String _odn_desdia_oddx;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odndiagnosticos</para>
        /// <para>CAMPO: Descripcion  diagnostico</para>
        /// <para>NOMBRE: odn_desdia_oddx (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Diagnosticos
        /// </para>
        /// </summary>
        public String Odn_desdia_oddx
        {
            get { return _odn_desdia_oddx; }
            set
            {
                if (_odn_desdia_oddx == value) return;
                _odn_desdia_oddx = value;
                OnPropertyChanged("Odn_desdia_oddx");
            }
        }
        #endregion
        #region Fcm_desser_mant: Nombre servicio
        private String _fcm_desser_mant;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
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
        #region Odn_desdie_oddi: Descripcion  diente
        private String _odn_desdie_oddi;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Descripcion  diente</para>
        /// <para>NOMBRE: odn_desdie_oddi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Diente
        /// </para>
        /// </summary>
        public String Odn_desdie_oddi
        {
            get { return _odn_desdie_oddi; }
            set
            {
                if (_odn_desdie_oddi == value) return;
                _odn_desdie_oddi = value;
                OnPropertyChanged("Odn_desdie_oddi");
            }
        }
        #endregion
        #region Odn_desana_odan: Descripcion anatomia
        private String _odn_desana_odan;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TABLA NATIVA: odnanatomdiente</para>
        /// <para>CAMPO: Descripcion anatomia</para>
        /// <para>NOMBRE: odn_desana_odan (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion cara del diente
        /// </para>
        /// </summary>
        public String Odn_desana_odan
        {
            get { return _odn_desana_odan; }
            set
            {
                if (_odn_desana_odan == value) return;
                _odn_desana_odan = value;
                OnPropertyChanged("Odn_desana_odan");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
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
        #region Odn_serdnt_odsi: Servicio en diente
        private String _odn_serdnt_odsi;
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TABLA NATIVA: odnserviciosips</para>
        /// <para>CAMPO: Servicio en diente</para>
        /// <para>NOMBRE: odn_serdnt_odsi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Servicio realizable:  1= Realizable solo en piezas dentales
        /// 2 = En cualquier otro lugar de la boca
        /// </para>
        /// </summary>
        public String Odn_serdnt_odsi
        {
            get { return _odn_serdnt_odsi; }
            set
            {
                if (_odn_serdnt_odsi == value) return;
                _odn_serdnt_odsi = value;
                OnPropertyChanged("Odn_serdnt_odsi");
            }
        }
        #endregion
        #region Odn_tipvis_odsi: Tipo vista grafica
        private String _odn_tipvis_odsi;
        /// <summary>
        /// <para>TABLA: odnserviciosips</para>
        /// <para>TABLA NATIVA: odnserviciosips</para>
        /// <para>CAMPO: Tipo vista grafica</para>
        /// <para>NOMBRE: odn_tipvis_odsi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo Vista Grafica: 1=Graficar caras corona odontograma, 2=
        /// graficar diente odontograma ,3 = Otras graficas
        /// </para>
        /// </summary>
        public String Odn_tipvis_odsi
        {
            get { return _odn_tipvis_odsi; }
            set
            {
                if (_odn_tipvis_odsi == value) return;
                _odn_tipvis_odsi = value;
                OnPropertyChanged("Odn_tipvis_odsi");
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
        #region Adicionar Registro
        public static bool flgAddRegistro(ModeloOdnDeActivTratamiento tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFodneventosactde();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tobTempReg.Odn_nroreg_odde);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.odn_nroreg_odde = tobTempReg.Odn_nroreg_odde;
                            lobEFReg.odn_secreg_odde = (int)tobTempReg.Odn_secreg_odde;
                            lobEFReg.odn_nroreg_odac = tobTempReg.Odn_nroreg_odac;
                            lobEFReg.odn_nroreg_odev = tobTempReg.Odn_nroreg_odev;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.odn_tipreg_odac = tobTempReg.Odn_tipreg_odac;
                            lobEFReg.odn_auxreg_odde = tobTempReg.Odn_auxreg_odde;
                            lobEFReg.odn_fecact_odac = (DateTime)tobTempReg.Odn_fecact_odac;
                            lobEFReg.odn_coddia_oddx = tobTempReg.Odn_coddia_oddx;
                            lobEFReg.sia_coddia_tdia = tobTempReg.Sia_coddia_tdia;
                            lobEFReg.odn_codser_odsi = tobTempReg.Odn_codser_odsi;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.fcm_idesec_mant = tobTempReg.Fcm_idesec_mant;
                            lobEFReg.fcm_codser_mant = tobTempReg.Fcm_codser_mant;
                            lobEFReg.fcm_coddig_mant = tobTempReg.Fcm_coddig_mant;
                            lobEFReg.odn_desreg_odde = tobTempReg.Odn_desreg_odde;
                            lobEFReg.odn_totuni_odde = (int)tobTempReg.Odn_totuni_odde;
                            lobEFReg.odn_coddie_oddi = tobTempReg.Odn_coddie_oddi;
                            lobEFReg.odn_codana_odan = tobTempReg.Odn_codana_odan;
                            lobEFReg.odn_carmar_odde = tobTempReg.Odn_carmar_odde;
                            lobEFReg.odn_fecini_odde = (DateTime)tobTempReg.Odn_fecini_odde;
                            lobEFReg.odn_fecfin_odde = (DateTime)tobTempReg.Odn_fecfin_odde;
                            lobEFReg.odn_finpro_odde = tobTempReg.Odn_finpro_odde;
                            lobEFReg.odn_prexis_odde = tobTempReg.Odn_prexis_odde;
                            lobEFReg.odn_estact_odac = tobTempReg.Odn_estact_odac;
                            lobEFReg.odn_codimg_odim = tobTempReg.Odn_codimg_odim;
                            lobEFReg.odn_tipvis_odsi = tobTempReg.Odn_tipvis_odsi;
                            lobEFReg.odn_imagen_odde = tobTempReg.Odn_imagen_odde;
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
                                lobEFReg.odn_nroreg_odde = tcrCodigoR1 + lobEFReg.odn_nroreg_odde; // concatenar
                                //lobEFReg.odn_secreg_odde = ModeloOdnMsActivTratamiento.fnuGenerarSecuencialVista(tcrCodigoR1);
                                _context.AddToOdneventosactde(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tobTempReg.Odn_nroreg_odde);
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
        public static void fcvActualizar(ModeloOdnDeActivTratamiento tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tobjModelo.Odn_nroreg_odde);
                if (lobjRegistro != null)
                {
                    lobjRegistro.odn_nroreg_odde = tobjModelo.Odn_nroreg_odde;
                    lobjRegistro.odn_secreg_odde = tobjModelo.Odn_secreg_odde;
                    lobjRegistro.odn_nroreg_odac = tobjModelo.Odn_nroreg_odac;
                    lobjRegistro.odn_nroreg_odev = tobjModelo.Odn_nroreg_odev;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.odn_tipreg_odac = tobjModelo.Odn_tipreg_odac;
                    lobjRegistro.odn_auxreg_odde = tobjModelo.Odn_auxreg_odde;
                    lobjRegistro.odn_fecact_odac = (DateTime)tobjModelo.Odn_fecact_odac;
                    lobjRegistro.odn_coddia_oddx = tobjModelo.Odn_coddia_oddx;
                    lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                    lobjRegistro.odn_codser_odsi = tobjModelo.Odn_codser_odsi;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_idesec_mant = tobjModelo.Fcm_idesec_mant;
                    lobjRegistro.fcm_codser_mant = tobjModelo.Fcm_codser_mant;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.odn_desreg_odde = tobjModelo.Odn_desreg_odde;
                    lobjRegistro.odn_totuni_odde = (int)tobjModelo.Odn_totuni_odde;
                    lobjRegistro.odn_coddie_oddi = tobjModelo.Odn_coddie_oddi;
                    lobjRegistro.odn_codana_odan = tobjModelo.Odn_codana_odan;
                    lobjRegistro.odn_carmar_odde = tobjModelo.Odn_carmar_odde;
                    lobjRegistro.odn_fecini_odde = (DateTime)tobjModelo.Odn_fecini_odde;
                    lobjRegistro.odn_fecfin_odde = (DateTime)tobjModelo.Odn_fecfin_odde;
                    lobjRegistro.odn_finpro_odde = tobjModelo.Odn_finpro_odde;
                    lobjRegistro.odn_prexis_odde = tobjModelo.Odn_prexis_odde;
                    lobjRegistro.odn_estact_odac = tobjModelo.Odn_estact_odac;
                    lobjRegistro.odn_codimg_odim = tobjModelo.Odn_codimg_odim;
                    lobjRegistro.odn_tipvis_odsi = tobjModelo.Odn_tipvis_odsi;
                    lobjRegistro.odn_imagen_odde = tobjModelo.Odn_imagen_odde;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ODNEVENTOSACTDE: Logica
        /// <summary>
        /// <para>TABLA: odneventosactde</para>
        /// <para>TITULO: Maestro detalles de actividad</para>
        /// <para>MODULO: ODN</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalle registro individual de cada una de las actividades
        /// dadas en una cita (ODNEVENTOSACTMS)
        /// </para>
        /// </summary>
        public static bool flgBuscarOdneventosactde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Odneventosactde.FirstOrDefault(p => p.odn_nroreg_odde == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsListaOdneventosactde: Listar Registros
        /// <summary>
        /// <para>tcrTipo: "IG" = Odn_nroreg_odde uno solo  "R1" = Odn_nroreg_odac lista tipo detalles </para>
        /// </summary>
        public static List<ModeloOdnDeActivTratamiento> flsListaOdneventosactde(String tcrTipo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "R1")
                {
                    #region consulta
                    var lobConsulta = from odneventosactde in _context.Odneventosactde
                                      join odnmaestdientes in _context.Odnmaestdientes on odneventosactde.odn_coddie_oddi equals odnmaestdientes.odn_coddie_oddi into tmodnmaestdientes
                                      join odnanatomdiente in _context.Odnanatomdiente on odneventosactde.odn_codana_odan equals odnanatomdiente.odn_codana_odan into tmodnanatomdiente
                                      from oddi in tmodnmaestdientes.DefaultIfEmpty()
                                      from odan in tmodnanatomdiente.DefaultIfEmpty()
                                      where odneventosactde.odn_nroreg_odac == tcrBuscar
                                      orderby odneventosactde.odn_coddie_oddi, odneventosactde.odn_secreg_odde
                                      select new ModeloOdnDeActivTratamiento
                                      {
                                          Odn_nroreg_odde = odneventosactde.odn_nroreg_odde,
                                          Odn_secreg_odde = (int)odneventosactde.odn_secreg_odde,
                                          Odn_nroreg_odac = odneventosactde.odn_nroreg_odac,
                                          Odn_nroreg_odev = odneventosactde.odn_nroreg_odev,
                                          Sia_idesec_usua = odneventosactde.sia_idesec_usua,
                                          Odn_tipreg_odac = odneventosactde.odn_tipreg_odac,
                                          Odn_auxreg_odde = odneventosactde.odn_auxreg_odde,
                                          Odn_fecact_odac = (DateTime)odneventosactde.odn_fecact_odac,
                                          Odn_coddia_oddx = odneventosactde.odn_coddia_oddx,
                                          Sia_coddia_tdia = odneventosactde.sia_coddia_tdia,
                                          Odn_codser_odsi = odneventosactde.odn_codser_odsi,
                                          Fcm_idesec_sips = odneventosactde.fcm_idesec_sips,
                                          Fcm_idesec_mant = odneventosactde.fcm_idesec_mant,
                                          Fcm_codser_mant = odneventosactde.fcm_codser_mant,
                                          Fcm_coddig_mant = odneventosactde.fcm_coddig_mant,
                                          Odn_desreg_odde = odneventosactde.odn_desreg_odde,
                                          Odn_totuni_odde = (int)odneventosactde.odn_totuni_odde,
                                          Odn_coddie_oddi = odneventosactde.odn_coddie_oddi,
                                          Odn_codana_odan = odneventosactde.odn_codana_odan,
                                          Odn_carmar_odde = odneventosactde.odn_carmar_odde,
                                          Odn_fecini_odde = (DateTime)odneventosactde.odn_fecini_odde,
                                          Odn_fecfin_odde = (DateTime)odneventosactde.odn_fecfin_odde,
                                          Odn_finpro_odde = odneventosactde.odn_finpro_odde,
                                          Odn_prexis_odde = odneventosactde.odn_prexis_odde,
                                          Odn_estact_odac = odneventosactde.odn_estact_odac,
                                          Odn_codimg_odim = odneventosactde.odn_codimg_odim,
                                          Odn_tipvis_odsi = odneventosactde.odn_tipvis_odsi,
                                          Odn_imagen_odde = odneventosactde.odn_imagen_odde,
                                          Sis_estpro_espr = odneventosactde.sis_estpro_espr,
                                          Odn_desdie_oddi = oddi.odn_desdie_oddi,
                                          Odn_desana_odan = odan.odn_desana_odan,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from odneventosactde in _context.Odneventosactde
                                      join odnmaestdientes in _context.Odnmaestdientes on odneventosactde.odn_coddie_oddi equals odnmaestdientes.odn_coddie_oddi into tmodnmaestdientes
                                      join odnanatomdiente in _context.Odnanatomdiente on odneventosactde.odn_codana_odan equals odnanatomdiente.odn_codana_odan into tmodnanatomdiente
                                      from oddi in tmodnmaestdientes.DefaultIfEmpty()
                                      from odan in tmodnanatomdiente.DefaultIfEmpty()
                                      where odneventosactde.odn_nroreg_odde == tcrBuscar
                                      select new ModeloOdnDeActivTratamiento
                                      {
                                          Odn_nroreg_odde = odneventosactde.odn_nroreg_odde,
                                          Odn_secreg_odde = (int)odneventosactde.odn_secreg_odde,
                                          Odn_nroreg_odac = odneventosactde.odn_nroreg_odac,
                                          Odn_nroreg_odev = odneventosactde.odn_nroreg_odev,
                                          Sia_idesec_usua = odneventosactde.sia_idesec_usua,
                                          Odn_tipreg_odac = odneventosactde.odn_tipreg_odac,
                                          Odn_auxreg_odde = odneventosactde.odn_auxreg_odde,
                                          Odn_fecact_odac = (DateTime)odneventosactde.odn_fecact_odac,
                                          Odn_coddia_oddx = odneventosactde.odn_coddia_oddx,
                                          Sia_coddia_tdia = odneventosactde.sia_coddia_tdia,
                                          Odn_codser_odsi = odneventosactde.odn_codser_odsi,
                                          Fcm_idesec_sips = odneventosactde.fcm_idesec_sips,
                                          Fcm_idesec_mant = odneventosactde.fcm_idesec_mant,
                                          Fcm_codser_mant = odneventosactde.fcm_codser_mant,
                                          Fcm_coddig_mant = odneventosactde.fcm_coddig_mant,
                                          Odn_desreg_odde = odneventosactde.odn_desreg_odde,
                                          Odn_totuni_odde = (int)odneventosactde.odn_totuni_odde,
                                          Odn_coddie_oddi = odneventosactde.odn_coddie_oddi,
                                          Odn_codana_odan = odneventosactde.odn_codana_odan,
                                          Odn_carmar_odde = odneventosactde.odn_carmar_odde,
                                          Odn_fecini_odde = (DateTime)odneventosactde.odn_fecini_odde,
                                          Odn_fecfin_odde = (DateTime)odneventosactde.odn_fecfin_odde,
                                          Odn_finpro_odde = odneventosactde.odn_finpro_odde,
                                          Odn_prexis_odde = odneventosactde.odn_prexis_odde,
                                          Odn_estact_odac = odneventosactde.odn_estact_odac,
                                          Odn_codimg_odim = odneventosactde.odn_codimg_odim,
                                          Odn_tipvis_odsi = odneventosactde.odn_tipvis_odsi,
                                          Odn_imagen_odde = odneventosactde.odn_imagen_odde,
                                          Sis_estpro_espr = odneventosactde.sis_estpro_espr,
                                          Odn_desdie_oddi = oddi.odn_desdie_oddi,
                                          Odn_desana_odan = odan.odn_desana_odan,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #region flsListaOdneventosactdeEx: Listar Registros relacion diente
        /// <summary>
        /// <para>DESCRIPCION</para>
        /// <para>Devuelve un grupo de registros  de tipo Diagnostico o Plan de tratamiento relacionados con un Diente</para>
        /// <para>o una una actividad en particular durante la gestion del Plan de tratamiento o la evolucion de las actividades</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipo: "1" = Diagnostico inicial "2" = Plan de tratamiento.</para> 
        /// <para>tcrIdTratamiento: Codigo del Registro maestro de todo el traatamiento</para>
        /// <para>tcrNumeroDiente: Numero diente (11,45,NA,23,63...) relacionado con grupo de registros, Cuando el parametro</para>
        /// <para>es valor vacio, se devuelve un temporal con todos los registros del tipo de actividad dado en tcrTipo.</para>
        /// </summary>
        public static List<ModeloOdnDeActivTratamiento> flsListaOdneventosactdeEx(String tcrTipo, String tcrIdTratamiento, String tcrNumeroDiente)
        {
            using (_context = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrNumeroDiente))
                {
                    #region consulta
                    var lobConsulta = from odneventosactde in _context.Odneventosactde
                                      join odnmaestdientes in _context.Odnmaestdientes on odneventosactde.odn_coddie_oddi equals odnmaestdientes.odn_coddie_oddi into tmodnmaestdientes
                                      join odnanatomdiente in _context.Odnanatomdiente on odneventosactde.odn_codana_odan equals odnanatomdiente.odn_codana_odan into tmodnanatomdiente
                                      from oddi in tmodnmaestdientes.DefaultIfEmpty()
                                      from odan in tmodnanatomdiente.DefaultIfEmpty()
                                      where odneventosactde.odn_tipreg_odac == tcrTipo &&
                                            odneventosactde.odn_nroreg_odev == tcrIdTratamiento &&
                                            odneventosactde.odn_coddie_oddi == tcrNumeroDiente
                                      orderby odneventosactde.odn_secreg_odde
                                      select new ModeloOdnDeActivTratamiento
                                      {
                                          Odn_nroreg_odde = odneventosactde.odn_nroreg_odde,
                                          Odn_secreg_odde = (int)odneventosactde.odn_secreg_odde,
                                          Odn_nroreg_odac = odneventosactde.odn_nroreg_odac,
                                          Odn_nroreg_odev = odneventosactde.odn_nroreg_odev,
                                          Sia_idesec_usua = odneventosactde.sia_idesec_usua,
                                          Odn_tipreg_odac = odneventosactde.odn_tipreg_odac,
                                          Odn_auxreg_odde = odneventosactde.odn_auxreg_odde,
                                          Odn_fecact_odac = (DateTime)odneventosactde.odn_fecact_odac,
                                          Odn_coddia_oddx = odneventosactde.odn_coddia_oddx,
                                          Sia_coddia_tdia = odneventosactde.sia_coddia_tdia,
                                          Odn_codser_odsi = odneventosactde.odn_codser_odsi,
                                          Fcm_idesec_sips = odneventosactde.fcm_idesec_sips,
                                          Fcm_idesec_mant = odneventosactde.fcm_idesec_mant,
                                          Fcm_codser_mant = odneventosactde.fcm_codser_mant,
                                          Fcm_coddig_mant = odneventosactde.fcm_coddig_mant,
                                          Odn_desreg_odde = odneventosactde.odn_desreg_odde,
                                          Odn_totuni_odde = (int)odneventosactde.odn_totuni_odde,
                                          Odn_coddie_oddi = odneventosactde.odn_coddie_oddi,
                                          Odn_codana_odan = odneventosactde.odn_codana_odan,
                                          Odn_carmar_odde = odneventosactde.odn_carmar_odde,
                                          Odn_fecini_odde = (DateTime)odneventosactde.odn_fecini_odde,
                                          Odn_fecfin_odde = (DateTime)odneventosactde.odn_fecfin_odde,
                                          Odn_finpro_odde = odneventosactde.odn_finpro_odde,
                                          Odn_prexis_odde = odneventosactde.odn_prexis_odde,
                                          Odn_estact_odac = odneventosactde.odn_estact_odac,
                                          Odn_codimg_odim = odneventosactde.odn_codimg_odim,
                                          Odn_tipvis_odsi = odneventosactde.odn_tipvis_odsi,
                                          Odn_imagen_odde = odneventosactde.odn_imagen_odde,
                                          Sis_estpro_espr = odneventosactde.sis_estpro_espr,
                                          Odn_desdie_oddi = oddi.odn_desdie_oddi,
                                          Odn_desana_odan = odan.odn_desana_odan,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from odneventosactde in _context.Odneventosactde
                                      join odnmaestdientes in _context.Odnmaestdientes on odneventosactde.odn_coddie_oddi equals odnmaestdientes.odn_coddie_oddi into tmodnmaestdientes
                                      join odnanatomdiente in _context.Odnanatomdiente on odneventosactde.odn_codana_odan equals odnanatomdiente.odn_codana_odan into tmodnanatomdiente
                                      from oddi in tmodnmaestdientes.DefaultIfEmpty()
                                      from odan in tmodnanatomdiente.DefaultIfEmpty()
                                      where odneventosactde.odn_tipreg_odac == tcrTipo &&
                                            odneventosactde.odn_nroreg_odev == tcrIdTratamiento
                                      orderby odneventosactde.odn_coddie_oddi, odneventosactde.odn_secreg_odde
                                      select new ModeloOdnDeActivTratamiento
                                      {
                                          Odn_nroreg_odde = odneventosactde.odn_nroreg_odde,
                                          Odn_secreg_odde = (int)odneventosactde.odn_secreg_odde,
                                          Odn_nroreg_odac = odneventosactde.odn_nroreg_odac,
                                          Odn_nroreg_odev = odneventosactde.odn_nroreg_odev,
                                          Sia_idesec_usua = odneventosactde.sia_idesec_usua,
                                          Odn_tipreg_odac = odneventosactde.odn_tipreg_odac,
                                          Odn_auxreg_odde = odneventosactde.odn_auxreg_odde,
                                          Odn_fecact_odac = (DateTime)odneventosactde.odn_fecact_odac,
                                          Odn_coddia_oddx = odneventosactde.odn_coddia_oddx,
                                          Sia_coddia_tdia = odneventosactde.sia_coddia_tdia,
                                          Odn_codser_odsi = odneventosactde.odn_codser_odsi,
                                          Fcm_idesec_sips = odneventosactde.fcm_idesec_sips,
                                          Fcm_idesec_mant = odneventosactde.fcm_idesec_mant,
                                          Fcm_codser_mant = odneventosactde.fcm_codser_mant,
                                          Fcm_coddig_mant = odneventosactde.fcm_coddig_mant,
                                          Odn_desreg_odde = odneventosactde.odn_desreg_odde,
                                          Odn_totuni_odde = (int)odneventosactde.odn_totuni_odde,
                                          Odn_coddie_oddi = odneventosactde.odn_coddie_oddi,
                                          Odn_codana_odan = odneventosactde.odn_codana_odan,
                                          Odn_carmar_odde = odneventosactde.odn_carmar_odde,
                                          Odn_fecini_odde = (DateTime)odneventosactde.odn_fecini_odde,
                                          Odn_fecfin_odde = (DateTime)odneventosactde.odn_fecfin_odde,
                                          Odn_finpro_odde = odneventosactde.odn_finpro_odde,
                                          Odn_prexis_odde = odneventosactde.odn_prexis_odde,
                                          Odn_estact_odac = odneventosactde.odn_estact_odac,
                                          Odn_codimg_odim = odneventosactde.odn_codimg_odim,
                                          Odn_tipvis_odsi = odneventosactde.odn_tipvis_odsi,
                                          Odn_imagen_odde = odneventosactde.odn_imagen_odde,
                                          Sis_estpro_espr = odneventosactde.sis_estpro_espr,
                                          Odn_desdie_oddi = oddi.odn_desdie_oddi,
                                          Odn_desana_odan = odan.odn_desana_odan,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }

}

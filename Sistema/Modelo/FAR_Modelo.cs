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

namespace Sistema.Modelo
{
    #region Modelo Maestro Entrega Medicamentos
    /// <summary>
    /// Descripcion para la Vista de  la tabla: farmovmedicamma
    /// </summary>
    public class ModeloEntregaMedica : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Far_nroreg_fams: Codigo registro
        private String _far_nroreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: far_nroreg_fams (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro
        /// </para>
        /// </summary>
        public String Far_nroreg_fams
        {
            get { return _far_nroreg_fams; }
            set
            {
                if (_far_nroreg_fams == value) return;
                _far_nroreg_fams = value;
                OnPropertyChanged("Far_nroreg_fams");
            }
        }
        #endregion
        #region Hcl_nroreg_hcms: Num.Solicitud medica
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Num.Solicitud medica</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código registro entrega Formula media /Hoja de consumo intrahospitalaria
        /// en maestro HCLREGORDESERMS
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        /// <para>TABLA: farmovmedicamma</para>
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
        /// <para>TABLA: farmovmedicamma</para>
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
        #region Far_gesfec_fams: Fecha servicio
        private DateTime _far_gesfec_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: far_gesfec_fams (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del suministro al paciente
        /// </para>
        /// </summary>
        public DateTime Far_gesfec_fams
        {
            get { return _far_gesfec_fams; }
            set
            {
                if (_far_gesfec_fams == value) return;
                _far_gesfec_fams = value;
                OnPropertyChanged("Far_gesfec_fams");
            }
        }
        #endregion
        #region Far_geshor_fams: Hora servicio
        private Decimal _far_geshor_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: far_geshor_fams (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del servicio para el paciente en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Far_geshor_fams
        {
            get { return _far_geshor_fams; }
            set
            {
                if (_far_geshor_fams == value) return;
                _far_geshor_fams = value;
                OnPropertyChanged("Far_geshor_fams");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Sia_fecnac_usua: Fecha nacimiento
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region Sis_codsex_sexo: Sexo
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo del  usuario o paciente
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
        #region Sia_edaymd_usua: Edad formato largo
        private String _sia_edaymd_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 dias)
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
        #region Far_tipreg_fams: Tipo registro
        private String _far_tipreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: far_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public String Far_tipreg_fams
        {
            get { return _far_tipreg_fams; }
            set
            {
                if (_far_tipreg_fams == value) return;
                _far_tipreg_fams = value;
                OnPropertyChanged("Far_tipreg_fams");
            }
        }
        #endregion
        #region Far_tipges_fams: Tipo gestion
        private String _far_tipges_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: far_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public String Far_tipges_fams
        {
            get { return _far_tipges_fams; }
            set
            {
                if (_far_tipges_fams == value) return;
                _far_tipges_fams = value;
                OnPropertyChanged("Far_tipges_fams");
            }
        }
        #endregion
        #region Far_observ_fams: Nota detalle
        private String _far_observ_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Nota detalle</para>
        /// <para>NOMBRE: far_observ_fams (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Nota detalle u observacion del registro
        /// </para>
        /// </summary>
        public String Far_observ_fams
        {
            get { return _far_observ_fams; }
            set
            {
                if (_far_observ_fams == value) return;
                _far_observ_fams = value;
                OnPropertyChanged("Far_observ_fams");
            }
        }
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
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
        #region Fcm_codcpr_cpro: Centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción
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
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos (mañana tarde noche)
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
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que autoriza el servicio o medicamento
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
        #region Sys_codusu_usux: Usuario que gestiona
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario que gestiona</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Usuario del sistema que realiza gestion del registro de solicitud
        /// desde modulo clinico
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
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el cual se realiza el movimiento
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
        #region Far_entreg_fams: Tipo registro
        private String _far_entreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: far_entreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Para saber si  los medicamento en farmacia/almacen fueron entregados
        /// completos  1=Entrega realizada sin pendientes 2=Entrega realizada
        /// con medicamentos pendientes 3=Pendiente entregados totalmente
        /// </para>
        /// </summary>
        public String Far_entreg_fams
        {
            get { return _far_entreg_fams; }
            set
            {
                if (_far_entreg_fams == value) return;
                _far_entreg_fams = value;
                OnPropertyChanged("Far_entreg_fams");
            }
        }
        #endregion
        #region Far_entrex_fams: Pendientes entregados
        private String _far_entrex_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Pendientes entregados</para>
        /// <para>NOMBRE: far_entrex_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Medicamento pendientes fueron entregados:  1=Entrega realizada
        /// sin pendientes 2=Pendientes no entregados 3=Pendientes entregados
        /// parcialmente 4 = Pendientes entregados totalmente
        /// </para>
        /// </summary>
        public String Far_entrex_fams
        {
            get { return _far_entrex_fams; }
            set
            {
                if (_far_entrex_fams == value) return;
                _far_entrex_fams = value;
                OnPropertyChanged("Far_entrex_fams");
            }
        }
        #endregion
        #region Desys_codusx_usux:
        private String _desys_codusx_usux;
        /// <summary>
        /// <para>TABLA: </para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: desys_codusx_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - sys_codusx_usux: 
        /// </para>
        /// </summary>
        public String Desys_codusx_usux
        {
            get { return _desys_codusx_usux; }
            set
            {
                if (_desys_codusx_usux == value) return;
                _desys_codusx_usux = value;
                OnPropertyChanged("Desys_codusx_usux");
            }
        }
        #endregion
        #region Sys_codusx_usux: Usuario gestion almacen
        private String _sys_codusx_usux;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario gestion almacen</para>
        /// <para>NOMBRE: sys_codusx_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Usuario del sistema que realiza gestion en almacen
        /// </para>
        /// </summary>
        public String Sys_codusx_usux
        {
            get { return _sys_codusx_usux; }
            set
            {
                if (_sys_codusx_usux == value) return;
                _sys_codusx_usux = value;
                OnPropertyChanged("Sys_codusx_usux");
            }
        }
        #endregion
        #region Far_secdet_fams: Secuencial reg detalles
        private int _far_secdet_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: far_secdet_fams (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros serviciosdetalles
        /// </para>
        /// </summary>
        public int Far_secdet_fams
        {
            get { return _far_secdet_fams; }
            set
            {
                if (_far_secdet_fams == value) return;
                _far_secdet_fams = value;
                OnPropertyChanged("Far_secdet_fams");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        /// <para>TABLA: farmovmedicamma</para>
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
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        /// <para>TABLA: farmovmedicamma</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        /// <para>TABLA: farmovmedicamma</para>
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
        #region Hcl_destur_hctu: Descripcion turno
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion turno</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public String Inv_desalm_inal
        {
            get { return _inv_desalm_inal; }
            set
            {
                if (_inv_desalm_inal == value) return;
                _inv_desalm_inal = value;
                OnPropertyChanged("Inv_desalm_inal");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        public static String flgAddRegistro(ModeloEntregaMedica tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FAR-SECUE-ENTREMEDICAM", "FAR", "Secuencial Unico entrega de medicamentos");
            try
            {
                if (!flgBuscarFarmovmedicamma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfarmovmedicamma
                        {
                            #region cargar Registro
                            far_nroreg_fams = tobjModelo.Far_nroreg_fams,
                            hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            far_gesfec_fams = tobjModelo.Far_gesfec_fams,
                            far_geshor_fams = tobjModelo.Far_geshor_fams,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                            sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                            far_tipreg_fams = tobjModelo.Far_tipreg_fams,
                            far_tipges_fams = tobjModelo.Far_tipges_fams,
                            far_observ_fams = tobjModelo.Far_observ_fams,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                            sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            far_entreg_fams = tobjModelo.Far_entreg_fams,
                            far_entrex_fams = tobjModelo.Far_entrex_fams,
                            sys_codusx_usux = tobjModelo.Sys_codusx_usux,
                            far_secdet_fams = tobjModelo.Far_secdet_fams,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.far_nroreg_fams = lcrCodigoGen;
                        _context.AddToFarmovmedicamma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FAR-SECUE-ENTREMEDICAM': Secuencial Unico entrega de medicamentos en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloEntregaMedica tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tobjModelo.Far_nroreg_fams);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.far_nroreg_fams = tobjModelo.Far_nroreg_fams;
                        lobjRegistro.hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                        lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.far_gesfec_fams = (DateTime)tobjModelo.Far_gesfec_fams;
                        lobjRegistro.far_geshor_fams = (Decimal)tobjModelo.Far_geshor_fams;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                        lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                        lobjRegistro.far_tipreg_fams = tobjModelo.Far_tipreg_fams;
                        lobjRegistro.far_tipges_fams = tobjModelo.Far_tipges_fams;
                        lobjRegistro.far_observ_fams = tobjModelo.Far_observ_fams;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                        lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                        lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.far_entreg_fams = tobjModelo.Far_entreg_fams;
                        lobjRegistro.far_entrex_fams = tobjModelo.Far_entrex_fams;
                        lobjRegistro.sys_codusx_usux = tobjModelo.Sys_codusx_usux;
                        lobjRegistro.far_secdet_fams = (int)tobjModelo.Far_secdet_fams;
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
        #region Eliminar registro
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tcrCodigo);
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
        #region Buscar FARMOVMEDICAMMA: Logica
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TITULO: Maestro entrega formulas y medicamentos intrahospitalarios</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro movimientos entrega desde Almacen/Farmacia,
        /// de los medicamentos dados en Planes de manejo interno/consumo
        /// y externo (ordenes servicios y/o formulas receta medicas)
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmovmedicamma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicamma.FirstOrDefault(p => p.far_nroreg_fams == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloEntregaMedica> flsListaFarmovmedicamma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from farmovmedicamma in _context.Farmovmedicamma
                                      join admregadmision in _context.Admregadmision on farmovmedicamma.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join invalmacenmaest in _context.Invalmacenmaest on farmovmedicamma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join siausuarioatend in _context.Siausuarioatend on farmovmedicamma.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siamaeprofsalud in _context.Siamaeprofsalud on farmovmedicamma.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      select new ModeloEntregaMedica
                                      {
                                          #region Datos
                                          Far_nroreg_fams = farmovmedicamma.far_nroreg_fams,
                                          Hcl_nroreg_hcms = farmovmedicamma.hcl_nroreg_hcms,
                                          Adm_secadm_rgad = farmovmedicamma.adm_secadm_rgad,
                                          Far_gesfec_fams = (DateTime)farmovmedicamma.far_gesfec_fams,
                                          Far_geshor_fams = (Decimal)farmovmedicamma.far_geshor_fams,
                                          Sia_idesec_usua = farmovmedicamma.sia_idesec_usua,
                                          Sia_tipide_tide = farmovmedicamma.sia_tipide_tide,
                                          Sia_nroide_usua = farmovmedicamma.sia_nroide_usua,
                                          Far_tipreg_fams = farmovmedicamma.far_tipreg_fams,
                                          Far_tipges_fams = farmovmedicamma.far_tipges_fams,
                                          Inv_codalm_inal = farmovmedicamma.inv_codalm_inal,
                                          Far_observ_fams = farmovmedicamma.far_observ_fams,
                                          Sia_codare_aser = farmovmedicamma.sia_codare_aser,
                                          Fcm_codcpr_cpro = farmovmedicamma.fcm_codcpr_cpro,
                                          Hcl_tiptur_hctu = farmovmedicamma.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = farmovmedicamma.sia_codpfa_prof,
                                          Sys_codusu_usux = farmovmedicamma.sys_codusu_usux,
                                          Far_entreg_fams = farmovmedicamma.far_entreg_fams,
                                          Far_entrex_fams = farmovmedicamma.far_entrex_fams,
                                          Sys_codusx_usux = farmovmedicamma.sys_codusx_usux,
                                          Far_secdet_fams = (int)farmovmedicamma.far_secdet_fams,
                                          Sis_estpro_espr = farmovmedicamma.sis_estpro_espr,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,  
                                          Sia_edaymd_usua = usua.sia_edaymd_usua,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Cto_seccon_cont = farmovmedicamma.cto_seccon_cont,
                                          Sia_codeps_teps = farmovmedicamma.sia_codeps_teps,
                                          Cto_nrocon_cont = farmovmedicamma.cto_nrocon_cont, 
                                          Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == farmovmedicamma.sia_codeps_teps).sia_deseps_teps,
                                          Sia_desare_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == farmovmedicamma.sia_codare_aser).sia_desare_aser,
                                          Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == farmovmedicamma.fcm_codcpr_cpro).fcm_descpr_cpro,
                                          Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == farmovmedicamma.hcl_tiptur_hctu).hcl_destur_hctu,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == farmovmedicamma.sis_estpro_espr).sis_despro_espr,
                                          Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == farmovmedicamma.cto_seccon_cont).cto_nrocon_cont,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from farmovmedicamma in _context.Farmovmedicamma
                                      join admregadmision in _context.Admregadmision on farmovmedicamma.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join invalmacenmaest in _context.Invalmacenmaest on farmovmedicamma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join siausuarioatend in _context.Siausuarioatend on farmovmedicamma.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siamaeprofsalud in _context.Siamaeprofsalud on farmovmedicamma.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where farmovmedicamma.far_nroreg_fams.Contains(tcrBuscar) || farmovmedicamma.far_observ_fams.Contains(tcrBuscar)
                                      select new ModeloEntregaMedica
                                      {
                                          #region Datos
                                          Far_nroreg_fams = farmovmedicamma.far_nroreg_fams,
                                          Hcl_nroreg_hcms = farmovmedicamma.hcl_nroreg_hcms,
                                          Adm_secadm_rgad = farmovmedicamma.adm_secadm_rgad,
                                          Far_gesfec_fams = (DateTime)farmovmedicamma.far_gesfec_fams,
                                          Far_geshor_fams = (Decimal)farmovmedicamma.far_geshor_fams,
                                          Sia_idesec_usua = farmovmedicamma.sia_idesec_usua,
                                          Sia_tipide_tide = farmovmedicamma.sia_tipide_tide,
                                          Sia_nroide_usua = farmovmedicamma.sia_nroide_usua,
                                          Far_tipreg_fams = farmovmedicamma.far_tipreg_fams,
                                          Far_tipges_fams = farmovmedicamma.far_tipges_fams,
                                          Inv_codalm_inal = farmovmedicamma.inv_codalm_inal,
                                          Far_observ_fams = farmovmedicamma.far_observ_fams,
                                          Sia_codare_aser = farmovmedicamma.sia_codare_aser,
                                          Fcm_codcpr_cpro = farmovmedicamma.fcm_codcpr_cpro,
                                          Hcl_tiptur_hctu = farmovmedicamma.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = farmovmedicamma.sia_codpfa_prof,
                                          Sys_codusu_usux = farmovmedicamma.sys_codusu_usux,
                                          Far_entreg_fams = farmovmedicamma.far_entreg_fams,
                                          Far_entrex_fams = farmovmedicamma.far_entrex_fams,
                                          Sys_codusx_usux = farmovmedicamma.sys_codusx_usux,
                                          Far_secdet_fams = (int)farmovmedicamma.far_secdet_fams,
                                          Sis_estpro_espr = farmovmedicamma.sis_estpro_espr,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_edaymd_usua = usua.sia_edaymd_usua,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Cto_seccon_cont = farmovmedicamma.cto_seccon_cont,
                                          Sia_codeps_teps = farmovmedicamma.sia_codeps_teps,
                                          Cto_nrocon_cont = farmovmedicamma.cto_nrocon_cont,
                                          Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == farmovmedicamma.sia_codeps_teps).sia_deseps_teps,
                                          Sia_desare_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == farmovmedicamma.sia_codare_aser).sia_desare_aser,
                                          Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == farmovmedicamma.fcm_codcpr_cpro).fcm_descpr_cpro,
                                          Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == farmovmedicamma.hcl_tiptur_hctu).hcl_destur_hctu,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == farmovmedicamma.sis_estpro_espr).sis_despro_espr,
                                          Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == farmovmedicamma.cto_seccon_cont).cto_nrocon_cont,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Entrega Medicamentos
    /// <summary>
    /// Descripcion para la Vista de  la tabla: farmovmedicammd
    /// </summary>
    public class ModeloEntregaMedicad : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Far_nroreg_fads: Codigo registro
        private String _far_nroreg_fads;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: far_nroreg_fads (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial registro detalle
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
        #region Far_nroreg_fams: Codigo Reg.Maestro
        private String _far_nroreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Codigo Reg.Maestro</para>
        /// <para>NOMBRE: far_nroreg_fams (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro
        /// </para>
        /// </summary>
        public String Far_nroreg_fams
        {
            get { return _far_nroreg_fams; }
            set
            {
                if (_far_nroreg_fams == value) return;
                _far_nroreg_fams = value;
                OnPropertyChanged("Far_nroreg_fams");
            }
        }
        #endregion
        #region Hcl_nroreg_hcms: Num.Solicitud medica
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Num.Solicitud medica</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código registro entrega Formula media /Hoja de consumo intrahospitalaria
        /// en maestro HCLREGORDESERMS
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Far_gesfec_fams: Fecha servicio
        private DateTime _far_gesfec_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: far_gesfec_fams (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del suministro al paciente
        /// </para>
        /// </summary>
        public DateTime Far_gesfec_fams
        {
            get { return _far_gesfec_fams; }
            set
            {
                if (_far_gesfec_fams == value) return;
                _far_gesfec_fams = value;
                OnPropertyChanged("Far_gesfec_fams");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
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
        #region Far_tipreg_fams: Tipo registro
        private String _far_tipreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: far_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public String Far_tipreg_fams
        {
            get { return _far_tipreg_fams; }
            set
            {
                if (_far_tipreg_fams == value) return;
                _far_tipreg_fams = value;
                OnPropertyChanged("Far_tipreg_fams");
            }
        }
        #endregion
        #region Far_tipges_fams: Tipo gestion
        private String _far_tipges_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: far_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public String Far_tipges_fams
        {
            get { return _far_tipges_fams; }
            set
            {
                if (_far_tipges_fams == value) return;
                _far_tipges_fams = value;
                OnPropertyChanged("Far_tipges_fams");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el cual se realiza el movimiento
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
        #region Inv_secart_inar: Secuencial  Articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla:
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
        #region Inv_codaux_inar: Código Auxiliar Articulo
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region Fcm_idesec_sips: Servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS  para relacion con
        /// facturacion medica
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
        /// <para>TABLA: farmovmedicammd</para>
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
        #region Far_codcum_famd: Código CUM
        private String _far_codcum_famd;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// </para>
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
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public String Sis_codgme_sigr
        {
            get { return _sis_codgme_sigr; }
            set
            {
                if (_sis_codgme_sigr == value) return;
                _sis_codgme_sigr = value;
                OnPropertyChanged("Sis_codgme_sigr");
            }
        }
        #endregion
        #region Sis_codume_sium: Medida Almacenamiento
        private String _sis_codume_sium;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
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
        #region Far_unisol_fads: Unidades solicitadas
        private int _far_unisol_fads;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades solicitadas</para>
        /// <para>NOMBRE: far_unisol_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES SOLICITADAS, cantidad de unidades solicitadas
        /// en la orden medica
        /// </para>
        /// </summary>
        public int Far_unisol_fads
        {
            get { return _far_unisol_fads; }
            set
            {
                if (_far_unisol_fads == value) return;
                _far_unisol_fads = value;
                OnPropertyChanged("Far_unisol_fads");
            }
        }
        #endregion
        #region Far_unient_fads: Unidades entregadas
        private int _far_unient_fads;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades entregadas</para>
        /// <para>NOMBRE: far_unient_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES ENTREGADAS,  unidades entregadas en farmacia,
        /// es posible que sea una cantidad menor a la solicitada, esto
        /// generara cantidad pendiente
        /// </para>
        /// </summary>
        public int Far_unient_fads
        {
            get { return _far_unient_fads; }
            set
            {
                if (_far_unient_fads == value) return;
                _far_unient_fads = value;
                OnPropertyChanged("Far_unient_fads");
            }
        }
        #endregion
        #region Far_unipen_fads: Unidades pendientes
        private int _far_unipen_fads;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades pendientes</para>
        /// <para>NOMBRE: far_unipen_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES PENDIENTES, unidades pendientes por entregar
        /// se genera del calculo: UnidadesSolicitadas menos Unidades entrregadas
        /// </para>
        /// </summary>
        public int Far_unipen_fads
        {
            get { return _far_unipen_fads; }
            set
            {
                if (_far_unipen_fads == value) return;
                _far_unipen_fads = value;
                OnPropertyChanged("Far_unipen_fads");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor  Ingreso unidad
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO COMPRA, Valor Ingreso unidad de articulos en
        /// inventario es la base para calculo valor salida
        /// </para>
        /// </summary>
        public float Inv_valing_inar
        {
            get { return _inv_valing_inar; }
            set
            {
                if (_inv_valing_inar == value) return;
                _inv_valing_inar = value;
                OnPropertyChanged("Inv_valing_inar");
            }
        }
        #endregion
        #region Inv_valmov_inar: Valor salida unidad
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// VALOR SALIDA VENTA, Valor Movimiento de salida (valor venta)
        /// cada unidad
        /// </para>
        /// </summary>
        public float Inv_valmov_inar
        {
            get { return _inv_valmov_inar; }
            set
            {
                if (_inv_valmov_inar == value) return;
                _inv_valmov_inar = value;
                OnPropertyChanged("Inv_valmov_inar");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        #region Far_observ_fams: Nota detalle
        private String _far_observ_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Nota detalle</para>
        /// <para>NOMBRE: far_observ_fams (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Nota detalle u observacion del registro
        /// </para>
        /// </summary>
        public String Far_observ_fams
        {
            get { return _far_observ_fams; }
            set
            {
                if (_far_observ_fams == value) return;
                _far_observ_fams = value;
                OnPropertyChanged("Far_observ_fams");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        /// <para>TABLA: farmovmedicammd</para>
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
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public String Inv_desalm_inal
        {
            get { return _inv_desalm_inal; }
            set
            {
                if (_inv_desalm_inal == value) return;
                _inv_desalm_inal = value;
                OnPropertyChanged("Inv_desalm_inal");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public String Inv_nomart_inar
        {
            get { return _inv_nomart_inar; }
            set
            {
                if (_inv_nomart_inar == value) return;
                _inv_nomart_inar = value;
                OnPropertyChanged("Inv_nomart_inar");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Far_precom_famd: Descripcion presentacion
        private String _far_precom_famd;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Descripcion presentacion</para>
        /// <para>NOMBRE: far_precom_famd (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion presentacion comercial del producto según expediente
        /// </para>
        /// </summary>
        public String Far_precom_famd
        {
            get { return _far_precom_famd; }
            set
            {
                if (_far_precom_famd == value) return;
                _far_precom_famd = value;
                OnPropertyChanged("Far_precom_famd");
            }
        }
        #endregion
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public String Sis_desgme_sigr
        {
            get { return _sis_desgme_sigr; }
            set
            {
                if (_sis_desgme_sigr == value) return;
                _sis_desgme_sigr = value;
                OnPropertyChanged("Sis_desgme_sigr");
            }
        }
        #endregion
        #region Sis_desume_sium: Descripción unidad medida
        private String _sis_desume_sium;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public String Sis_desume_sium
        {
            get { return _sis_desume_sium; }
            set
            {
                if (_sis_desume_sium == value) return;
                _sis_desume_sium = value;
                OnPropertyChanged("Sis_desume_sium");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloEntregaMedicad tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfarmovmedicammd();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Farmovmedicammd.FirstOrDefault(p => p.far_nroreg_fads == tobTempReg.Far_nroreg_fads);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.far_nroreg_fads = tobTempReg.Far_nroreg_fads;
                            lobEFReg.far_nroreg_fams = tobTempReg.Far_nroreg_fams;
                            lobEFReg.hcl_nroreg_hcms = tobTempReg.Hcl_nroreg_hcms;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.far_gesfec_fams = (DateTime)tobTempReg.Far_gesfec_fams;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobTempReg.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.far_tipreg_fams = tobTempReg.Far_tipreg_fams;
                            lobEFReg.far_tipges_fams = tobTempReg.Far_tipges_fams;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;
                            lobEFReg.fcm_idesec_sips = tobTempReg.Fcm_idesec_sips;
                            lobEFReg.far_codcum_famd = tobTempReg.Far_codcum_famd;
                            lobEFReg.sis_codgme_sigr = tobTempReg.Sis_codgme_sigr;
                            lobEFReg.sis_codume_sium = tobTempReg.Sis_codume_sium;
                            lobEFReg.far_unisol_fads = (int)tobTempReg.Far_unisol_fads;
                            lobEFReg.far_unient_fads = (int)tobTempReg.Far_unient_fads;
                            lobEFReg.far_unipen_fads = (int)tobTempReg.Far_unipen_fads;
                            lobEFReg.inv_valing_inar = (float)tobTempReg.Inv_valing_inar;
                            lobEFReg.inv_valmov_inar = (float)tobTempReg.Inv_valmov_inar;
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
                                lobEFReg.far_nroreg_fads = tcrCodigoR1 + lobEFReg.far_nroreg_fads; // concatenar
                                _context.AddToFarmovmedicammd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Farmovmedicammd.FirstOrDefault(p => p.far_nroreg_fads == tobTempReg.Far_nroreg_fads);
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
        #region Buscar FARMOVMEDICAMMD: Logica
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TITULO: Maestro detalles entrega formulas y medicamentos intrahospit</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para detalles suministro de mdicamentos desde Almacen/Farmacia
        /// </para>
        /// </summary>
        public static bool flgBuscarFarmovmedicammd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farmovmedicammd.FirstOrDefault(p => p.far_nroreg_fads == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloEntregaMedicad> flsListaFarmovmedicammd(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from farmovmedicammd in _context.Farmovmedicammd
                                  join invmaearticulos in _context.Invmaearticulos on farmovmedicammd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join sisunidadmedida in _context.Sisunidadmedida on farmovmedicammd.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida //
                                  join sisestadoproces in _context.Sisestadoproces on farmovmedicammd.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  join fcmmanservicips in _context.Fcmmanservicips on farmovmedicammd.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from sium in tmsisunidadmedida.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  from sips in tmfcmmanservicips.DefaultIfEmpty()
                                  where farmovmedicammd.far_nroreg_fams == tcrBuscar
                                  select new ModeloEntregaMedicad
                                  {
                                      Far_nroreg_fads = farmovmedicammd.far_nroreg_fads,
                                      Far_nroreg_fams = farmovmedicammd.far_nroreg_fams,
                                      Hcl_nroreg_hcms = farmovmedicammd.hcl_nroreg_hcms,
                                      Adm_secadm_rgad = farmovmedicammd.adm_secadm_rgad,
                                      Far_gesfec_fams = (DateTime)farmovmedicammd.far_gesfec_fams,
                                      Sia_idesec_usua = farmovmedicammd.sia_idesec_usua,
                                      Sia_tipide_tide = farmovmedicammd.sia_tipide_tide,
                                      Sia_nroide_usua = farmovmedicammd.sia_nroide_usua,
                                      Far_tipreg_fams = farmovmedicammd.far_tipreg_fams,
                                      Far_tipges_fams = farmovmedicammd.far_tipges_fams,
                                      Inv_codalm_inal = farmovmedicammd.inv_codalm_inal,
                                      Inv_secart_inar = farmovmedicammd.inv_secart_inar,
                                      Inv_codaux_inar = farmovmedicammd.inv_codaux_inar,
                                      Fcm_idesec_sips = farmovmedicammd.fcm_idesec_sips,
                                      Sis_codgme_sigr = farmovmedicammd.sis_codgme_sigr,
                                      Sis_codume_sium = farmovmedicammd.sis_codume_sium,
                                      Far_unisol_fads = (int)farmovmedicammd.far_unisol_fads,
                                      Far_unient_fads = (int)farmovmedicammd.far_unient_fads,
                                      Far_unipen_fads = (int)farmovmedicammd.far_unipen_fads,
                                      Inv_valing_inar = (float)farmovmedicammd.inv_valing_inar,
                                      Inv_valmov_inar = (float)farmovmedicammd.inv_valmov_inar,
                                      Sis_estpro_espr = farmovmedicammd.sis_estpro_espr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Sis_desume_sium = sium.sis_desume_sium,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Fcm_coddig_mant = sips.fcm_coddig_mant,
                                      Fcm_desser_sips = sips.fcm_desser_sips,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo farexpedmedicma: Maestro expedientes medicamentos
    /// <summary>
    /// farexpedmedicma: Maestro expedientes medicamentos 
    /// </summary>
    public class ModeloFarExpedienteMedicamento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Far_expedi_fama: Expediente invima
        private String _far_expedi_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Expediente invima</para>
        /// <para>NOMBRE: far_expedi_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Numero del registro expediente INVIMA
        /// </para>
        /// </summary>
        public String Far_expedi_fama
        {
            get { return _far_expedi_fama; }
            set
            {
                if (_far_expedi_fama == value) return;
                _far_expedi_fama = value;
                OnPropertyChanged("Far_expedi_fama");
            }
        }
        #endregion
        #region Far_desexp_fama: Descripcion producto
        private String _far_desexp_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion producto</para>
        /// <para>NOMBRE: far_desexp_fama (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del producto comercial según expediente INVIMA
        /// </para>
        /// </summary>
        public String Far_desexp_fama
        {
            get { return _far_desexp_fama; }
            set
            {
                if (_far_desexp_fama == value) return;
                _far_desexp_fama = value;
                OnPropertyChanged("Far_desexp_fama");
            }
        }
        #endregion
        #region Far_codatc_fatc: Codigo ATC
        private String _far_codatc_fatc;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmaeclasifatc</para>
        /// <para>CAMPO: Codigo ATC</para>
        /// <para>NOMBRE: far_codatc_fatc (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo ATC ejemplo: A01AB01 según tabla Maestro clasificacion
        /// ATC
        /// </para>
        /// </summary>
        public String Far_codatc_fatc
        {
            get { return _far_codatc_fatc; }
            set
            {
                if (_far_codatc_fatc == value) return;
                _far_codatc_fatc = value;
                OnPropertyChanged("Far_codatc_fatc");
            }
        }
        #endregion
        #region Far_grufar_fagf: Grupo farmacologico
        private String _far_grufar_fagf;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Grupo farmacologico</para>
        /// <para>NOMBRE: far_grufar_fagf (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Grupo farmacologico según principos ATC
        /// </para>
        /// </summary>
        public String Far_grufar_fagf
        {
            get { return _far_grufar_fagf; }
            set
            {
                if (_far_grufar_fagf == value) return;
                _far_grufar_fagf = value;
                OnPropertyChanged("Far_grufar_fagf");
            }
        }
        #endregion
        #region Far_sugfar_fasg: Subgrupo farmacologico
        private String _far_sugfar_fasg;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Subgrupo farmacologico</para>
        /// <para>NOMBRE: far_sugfar_fasg (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public String Far_sugfar_fasg
        {
            get { return _far_sugfar_fasg; }
            set
            {
                if (_far_sugfar_fasg == value) return;
                _far_sugfar_fasg = value;
                OnPropertyChanged("Far_sugfar_fasg");
            }
        }
        #endregion
        #region Far_unimed_faum: Codigo Unidad medida
        private String _far_unimed_faum;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farunidadmedida</para>
        /// <para>CAMPO: Codigo Unidad medida</para>
        /// <para>NOMBRE: far_unimed_faum (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo unidad medida del medicamento
        /// </para>
        /// </summary>
        public String Far_unimed_faum
        {
            get { return _far_unimed_faum; }
            set
            {
                if (_far_unimed_faum == value) return;
                _far_unimed_faum = value;
                OnPropertyChanged("Far_unimed_faum");
            }
        }
        #endregion
        #region Far_viaadm_fava: Via administracion
        private String _far_viaadm_fava;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmedicamviadm</para>
        /// <para>CAMPO: Via administracion</para>
        /// <para>NOMBRE: far_viaadm_fava (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo via de adminstracion del medicamento (ORAL, CUTANEA,
        /// INTRAMUSCULAR Y OTRAS)
        /// </para>
        /// </summary>
        public String Far_viaadm_fava
        {
            get { return _far_viaadm_fava; }
            set
            {
                if (_far_viaadm_fava == value) return;
                _far_viaadm_fava = value;
                OnPropertyChanged("Far_viaadm_fava");
            }
        }
        #endregion
        #region Far_invima_fama: Registro sanitario INVIMA
        private String _far_invima_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Registro sanitario INVIMA</para>
        /// <para>NOMBRE: far_invima_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero registro sanitario INVIMA
        /// </para>
        /// </summary>
        public String Far_invima_fama
        {
            get { return _far_invima_fama; }
            set
            {
                if (_far_invima_fama == value) return;
                _far_invima_fama = value;
                OnPropertyChanged("Far_invima_fama");
            }
        }
        #endregion
        #region Far_fecexp_fama: Fecha registro INVIMA
        private DateTime _far_fecexp_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Fecha registro INVIMA</para>
        /// <para>NOMBRE: far_fecexp_fama (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha expedicion del registro sanitario INVIMA
        /// </para>
        /// </summary>
        public DateTime Far_fecexp_fama
        {
            get { return _far_fecexp_fama; }
            set
            {
                if (_far_fecexp_fama == value) return;
                _far_fecexp_fama = value;
                OnPropertyChanged("Far_fecexp_fama");
            }
        }
        #endregion
        #region Far_fecven_fama: Fecha vencimiento registro
        private DateTime _far_fecven_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Fecha vencimiento registro</para>
        /// <para>NOMBRE: far_fecven_fama (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha vencimiento del registro sanitario INVIMA
        /// </para>
        /// </summary>
        public DateTime Far_fecven_fama
        {
            get { return _far_fecven_fama; }
            set
            {
                if (_far_fecven_fama == value) return;
                _far_fecven_fama = value;
                OnPropertyChanged("Far_fecven_fama");
            }
        }
        #endregion
        #region Far_codlab_falb: laboratorio fabricante
        private String _far_codlab_falb;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: laboratorio fabricante</para>
        /// <para>NOMBRE: far_codlab_falb (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Codigo del laboratorio que lo fabrica
        /// </para>
        /// </summary>
        public String Far_codlab_falb
        {
            get { return _far_codlab_falb; }
            set
            {
                if (_far_codlab_falb == value) return;
                _far_codlab_falb = value;
                OnPropertyChanged("Far_codlab_falb");
            }
        }
        #endregion
        #region Far_comerc_falb: Codigo del Comerciante
        private String _far_comerc_falb;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: Codigo del Comerciante</para>
        /// <para>NOMBRE: far_comerc_falb (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo del laboratorio o quien realiza comercializacion del
        /// producto
        /// </para>
        /// </summary>
        public String Far_comerc_falb
        {
            get { return _far_comerc_falb; }
            set
            {
                if (_far_comerc_falb == value) return;
                _far_comerc_falb = value;
                OnPropertyChanged("Far_comerc_falb");
            }
        }
        #endregion
        #region Far_tiprol_fama: Tipo rol comerciente
        private String _far_tiprol_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Tipo rol comerciente</para>
        /// <para>NOMBRE: far_tiprol_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo rol del comerciante (puede ser el mismo que fabrica):
        /// FABRICANTE o IMPORTADOR
        /// </para>
        /// </summary>
        public String Far_tiprol_fama
        {
            get { return _far_tiprol_fama; }
            set
            {
                if (_far_tiprol_fama == value) return;
                _far_tiprol_fama = value;
                OnPropertyChanged("Far_tiprol_fama");
            }
        }
        #endregion
        #region Far_modcom_famc: Modalidad comercial
        private String _far_modcom_famc;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmodalicomerc</para>
        /// <para>CAMPO: Modalidad comercial</para>
        /// <para>NOMBRE: far_modcom_famc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Modalidad comercial del fabricante o comerciante: FABRICAR
        /// Y VENDER, IMPORTAR SEMIELABORAR Y VENDER … y otras
        /// </para>
        /// </summary>
        public String Far_modcom_famc
        {
            get { return _far_modcom_famc; }
            set
            {
                if (_far_modcom_famc == value) return;
                _far_modcom_famc = value;
                OnPropertyChanged("Far_modcom_famc");
            }
        }
        #endregion
        #region Far_forfar_fama: Forma Farmaceutica
        private String _far_forfar_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Forma Farmaceutica</para>
        /// <para>NOMBRE: far_forfar_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Forma farmaceutica del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_forfar_fama
        {
            get { return _far_forfar_fama; }
            set
            {
                if (_far_forfar_fama == value) return;
                _far_forfar_fama = value;
                OnPropertyChanged("Far_forfar_fama");
            }
        }
        #endregion
        #region Far_concen_fama: Concentracion medicamento
        private String _far_concen_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Concentracion medicamento</para>
        /// <para>NOMBRE: far_concen_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Concentracion del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_concen_fama
        {
            get { return _far_concen_fama; }
            set
            {
                if (_far_concen_fama == value) return;
                _far_concen_fama = value;
                OnPropertyChanged("Far_concen_fama");
            }
        }
        #endregion
        #region Far_unimed_fama: Unidad de medida
        private String _far_unimed_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: far_unimed_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Descripcion Unidad medida del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_unimed_fama
        {
            get { return _far_unimed_fama; }
            set
            {
                if (_far_unimed_fama == value) return;
                _far_unimed_fama = value;
                OnPropertyChanged("Far_unimed_fama");
            }
        }
        #endregion
        #region Far_secdet_fama: Secuencial reg detalles
        private int _far_secdet_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: far_secdet_fama (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros serviciosdetalles
        /// </para>
        /// </summary>
        public int Far_secdet_fama
        {
            get { return _far_secdet_fama; }
            set
            {
                if (_far_secdet_fama == value) return;
                _far_secdet_fama = value;
                OnPropertyChanged("Far_secdet_fama");
            }
        }
        #endregion
        #region Far_estreg_fama: Estado Registro
        private String _far_estreg_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: far_estreg_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public String Far_estreg_fama
        {
            get { return _far_estreg_fama; }
            set
            {
                if (_far_estreg_fama == value) return;
                _far_estreg_fama = value;
                OnPropertyChanged("Far_estreg_fama");
            }
        }
        #endregion
        #region Far_desatc_fatc: Descripcion ATC
        private String _far_desatc_fatc;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmaeclasifatc</para>
        /// <para>CAMPO: Descripcion ATC</para>
        /// <para>NOMBRE: far_desatc_fatc (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion del medicamento según clasificacion ATC
        /// </para>
        /// </summary>
        public String Far_desatc_fatc
        {
            get { return _far_desatc_fatc; }
            set
            {
                if (_far_desatc_fatc == value) return;
                _far_desatc_fatc = value;
                OnPropertyChanged("Far_desatc_fatc");
            }
        }
        #endregion
        #region Far_desgru_fagf: Descripcion Grupo
        private String _far_desgru_fagf;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: far_desgru_fagf (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion grupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public String Far_desgru_fagf
        {
            get { return _far_desgru_fagf; }
            set
            {
                if (_far_desgru_fagf == value) return;
                _far_desgru_fagf = value;
                OnPropertyChanged("Far_desgru_fagf");
            }
        }
        #endregion
        #region Far_desgru_fasg: Descripcion Subgrupo
        private String _far_desgru_fasg;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: far_desgru_fasg (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public String Far_desgru_fasg
        {
            get { return _far_desgru_fasg; }
            set
            {
                if (_far_desgru_fasg == value) return;
                _far_desgru_fasg = value;
                OnPropertyChanged("Far_desgru_fasg");
            }
        }
        #endregion
        #region Far_desmed_faum: Descripcion unidad medica
        private String _far_desmed_faum;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farunidadmedida</para>
        /// <para>CAMPO: Descripcion unidad medica</para>
        /// <para>NOMBRE: far_desmed_faum (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion unidad de medida medicamentos
        /// </para>
        /// </summary>
        public String Far_desmed_faum
        {
            get { return _far_desmed_faum; }
            set
            {
                if (_far_desmed_faum == value) return;
                _far_desmed_faum = value;
                OnPropertyChanged("Far_desmed_faum");
            }
        }
        #endregion
        #region Far_desvia_fava: Descripcion via administracion
        private String _far_desvia_fava;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmedicamviadm</para>
        /// <para>CAMPO: Descripcion via administracion</para>
        /// <para>NOMBRE: far_desvia_fava (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion via adminstracion medicamentos
        /// </para>
        /// </summary>
        public String Far_desvia_fava
        {
            get { return _far_desvia_fava; }
            set
            {
                if (_far_desvia_fava == value) return;
                _far_desvia_fava = value;
                OnPropertyChanged("Far_desvia_fava");
            }
        }
        #endregion
        #region Far_deslab_falb: Nombre laboratorio
        private String _far_deslab_falb;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: Nombre laboratorio</para>
        /// <para>NOMBRE: far_deslab_falb (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion del laboratorio que fabrica o comercializa
        /// medicamentos
        /// </para>
        /// </summary>
        public String Far_deslab_falb
        {
            get { return _far_deslab_falb; }
            set
            {
                if (_far_deslab_falb == value) return;
                _far_deslab_falb = value;
                OnPropertyChanged("Far_deslab_falb");
            }
        }
        #endregion
        #region Far_desmod_famc: Descripcion modalidad comercial
        private String _far_desmod_famc;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmodalicomerc</para>
        /// <para>CAMPO: Descripcion modalidad comercial</para>
        /// <para>NOMBRE: far_desmod_famc (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion modalidad comercializacion
        /// </para>
        /// </summary>
        public String Far_desmod_famc
        {
            get { return _far_desmod_famc; }
            set
            {
                if (_far_desmod_famc == value) return;
                _far_desmod_famc = value;
                OnPropertyChanged("Far_desmod_famc");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloFarExpedienteMedicamento tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfarexpedmedicma
                    {
                        #region cargar Registro
                        far_expedi_fama = tobjModelo.Far_expedi_fama,
                        far_desexp_fama = tobjModelo.Far_desexp_fama,
                        far_codatc_fatc = tobjModelo.Far_codatc_fatc,
                        far_grufar_fagf = tobjModelo.Far_grufar_fagf,
                        far_sugfar_fasg = tobjModelo.Far_sugfar_fasg,
                        far_unimed_faum = tobjModelo.Far_unimed_faum,
                        far_viaadm_fava = tobjModelo.Far_viaadm_fava,
                        far_invima_fama = tobjModelo.Far_invima_fama,
                        far_fecexp_fama = tobjModelo.Far_fecexp_fama,
                        far_fecven_fama = tobjModelo.Far_fecven_fama,
                        far_codlab_falb = tobjModelo.Far_codlab_falb,
                        far_comerc_falb = tobjModelo.Far_comerc_falb,
                        far_tiprol_fama = tobjModelo.Far_tiprol_fama,
                        far_modcom_famc = tobjModelo.Far_modcom_famc,
                        far_forfar_fama = tobjModelo.Far_forfar_fama,
                        far_concen_fama = tobjModelo.Far_concen_fama,
                        far_unimed_fama = tobjModelo.Far_unimed_fama,
                        far_secdet_fama = tobjModelo.Far_secdet_fama,
                        far_estreg_fama = tobjModelo.Far_estreg_fama,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.far_expedi_fama;
                    _context.AddToFarexpedmedicma(lobjRegistro);
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
        public static void fcvActualizar(ModeloFarExpedienteMedicamento tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tobjModelo.Far_expedi_fama);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.far_expedi_fama = tobjModelo.Far_expedi_fama;
                        lobjRegistro.far_desexp_fama = tobjModelo.Far_desexp_fama;
                        lobjRegistro.far_codatc_fatc = tobjModelo.Far_codatc_fatc;
                        lobjRegistro.far_grufar_fagf = tobjModelo.Far_grufar_fagf;
                        lobjRegistro.far_sugfar_fasg = tobjModelo.Far_sugfar_fasg;
                        lobjRegistro.far_unimed_faum = tobjModelo.Far_unimed_faum;
                        lobjRegistro.far_viaadm_fava = tobjModelo.Far_viaadm_fava;
                        lobjRegistro.far_invima_fama = tobjModelo.Far_invima_fama;
                        lobjRegistro.far_fecexp_fama = (DateTime)tobjModelo.Far_fecexp_fama;
                        lobjRegistro.far_fecven_fama = (DateTime)tobjModelo.Far_fecven_fama;
                        lobjRegistro.far_codlab_falb = tobjModelo.Far_codlab_falb;
                        lobjRegistro.far_comerc_falb = tobjModelo.Far_comerc_falb;
                        lobjRegistro.far_tiprol_fama = tobjModelo.Far_tiprol_fama;
                        lobjRegistro.far_modcom_famc = tobjModelo.Far_modcom_famc;
                        lobjRegistro.far_forfar_fama = tobjModelo.Far_forfar_fama;
                        lobjRegistro.far_concen_fama = tobjModelo.Far_concen_fama;
                        lobjRegistro.far_unimed_fama = tobjModelo.Far_unimed_fama;
                        lobjRegistro.far_secdet_fama = (int)tobjModelo.Far_secdet_fama;
                        lobjRegistro.far_estreg_fama = tobjModelo.Far_estreg_fama;
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
                    var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tcrCodigo);
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
        #region Buscar FAREXPEDMEDICMA: Logica
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TITULO: Maestro expediente registro medicamentos INVIMA</para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro expediente medicamentos INVIMA con registro Codigo
        /// Expediente codigo ATC (principio activo) y laboratorios
        /// </para>
        /// </summary>
        public static bool flgBuscarFarexpedmedicma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicma.FirstOrDefault(p => p.far_expedi_fama == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloFarExpedienteMedicamento> flsListaFarexpedmedicma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from farexpedmedicma in _context.Farexpedmedicma
                                      join farmaeclasifatc in _context.Farmaeclasifatc on farexpedmedicma.far_codatc_fatc equals farmaeclasifatc.far_codatc_fatc into tmfarmaeclasifatc
                                      join fargrufarmacoma in _context.Fargrufarmacoma on farexpedmedicma.far_grufar_fagf equals fargrufarmacoma.far_grufar_fagf into tmfargrufarmacoma
                                      join fargrufarmacomd in _context.Fargrufarmacomd on farexpedmedicma.far_sugfar_fasg equals fargrufarmacomd.far_sugfar_fasg into tmfargrufarmacomd
                                      join farunidadmedida in _context.Farunidadmedida on farexpedmedicma.far_unimed_faum equals farunidadmedida.far_unimed_faum into tmfarunidadmedida
                                      join farmedicamviadm in _context.Farmedicamviadm on farexpedmedicma.far_viaadm_fava equals farmedicamviadm.far_viaadm_fava into tmfarmedicamviadm
                                      //join farlaboratorios in _context.Farlaboratorios on farexpedmedicma.far_codlab_falb equals farlaboratorios.far_codlab_falb into tmfarlaboratorios
                                      join farlaboratorios in _context.Farlaboratorios on farexpedmedicma.far_comerc_falb equals farlaboratorios.far_codlab_falb into tmfarlaboratorios
                                      join farmodalicomerc in _context.Farmodalicomerc on farexpedmedicma.far_modcom_famc equals farmodalicomerc.far_modcom_famc into tmfarmodalicomerc
                                      from fatc in tmfarmaeclasifatc.DefaultIfEmpty()
                                      from fagf in tmfargrufarmacoma.DefaultIfEmpty()
                                      from fasg in tmfargrufarmacomd.DefaultIfEmpty()
                                      from faum in tmfarunidadmedida.DefaultIfEmpty()
                                      from fava in tmfarmedicamviadm.DefaultIfEmpty()
                                      //from falb in tmfarlaboratorios.DefaultIfEmpty()
                                      from falb in tmfarlaboratorios.DefaultIfEmpty()
                                      from famc in tmfarmodalicomerc.DefaultIfEmpty()
                                      select new ModeloFarExpedienteMedicamento
                                      {
                                          #region Datos
                                          Far_expedi_fama = farexpedmedicma.far_expedi_fama,
                                          Far_desexp_fama = farexpedmedicma.far_desexp_fama,
                                          Far_codatc_fatc = farexpedmedicma.far_codatc_fatc,
                                          Far_grufar_fagf = farexpedmedicma.far_grufar_fagf,
                                          Far_sugfar_fasg = farexpedmedicma.far_sugfar_fasg,
                                          Far_unimed_faum = farexpedmedicma.far_unimed_faum,
                                          Far_viaadm_fava = farexpedmedicma.far_viaadm_fava,
                                          Far_invima_fama = farexpedmedicma.far_invima_fama,
                                          Far_fecexp_fama = (DateTime)farexpedmedicma.far_fecexp_fama,
                                          Far_fecven_fama = (DateTime)farexpedmedicma.far_fecven_fama,
                                          Far_codlab_falb = farexpedmedicma.far_codlab_falb,
                                          Far_comerc_falb = farexpedmedicma.far_comerc_falb,
                                          Far_tiprol_fama = farexpedmedicma.far_tiprol_fama,
                                          Far_modcom_famc = farexpedmedicma.far_modcom_famc,
                                          Far_forfar_fama = farexpedmedicma.far_forfar_fama,
                                          Far_concen_fama = farexpedmedicma.far_concen_fama,
                                          Far_unimed_fama = farexpedmedicma.far_unimed_fama,
                                          Far_secdet_fama = (int)farexpedmedicma.far_secdet_fama,
                                          Far_estreg_fama = farexpedmedicma.far_estreg_fama,
                                          Far_desatc_fatc = fatc.far_desatc_fatc,
                                          Far_desgru_fagf = fagf.far_desgru_fagf,
                                          Far_desgru_fasg = fasg.far_desgru_fasg,
                                          Far_desmed_faum = faum.far_desmed_faum,
                                          Far_desvia_fava = fava.far_desvia_fava,
                                          Far_deslab_falb = falb.far_deslab_falb,
                                          Far_desmod_famc = famc.far_desmod_famc,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from farexpedmedicma in _context.Farexpedmedicma
                                      join farmaeclasifatc in _context.Farmaeclasifatc on farexpedmedicma.far_codatc_fatc equals farmaeclasifatc.far_codatc_fatc into tmfarmaeclasifatc
                                      join fargrufarmacoma in _context.Fargrufarmacoma on farexpedmedicma.far_grufar_fagf equals fargrufarmacoma.far_grufar_fagf into tmfargrufarmacoma
                                      join fargrufarmacomd in _context.Fargrufarmacomd on farexpedmedicma.far_sugfar_fasg equals fargrufarmacomd.far_sugfar_fasg into tmfargrufarmacomd
                                      join farunidadmedida in _context.Farunidadmedida on farexpedmedicma.far_unimed_faum equals farunidadmedida.far_unimed_faum into tmfarunidadmedida
                                      join farmedicamviadm in _context.Farmedicamviadm on farexpedmedicma.far_viaadm_fava equals farmedicamviadm.far_viaadm_fava into tmfarmedicamviadm
                                      //join farlaboratorios in _context.Farlaboratorios on farexpedmedicma.far_codlab_falb equals farlaboratorios.far_codlab_falb into tmfarlaboratorios
                                      join farlaboratorios in _context.Farlaboratorios on farexpedmedicma.far_comerc_falb equals farlaboratorios.far_codlab_falb into tmfarlaboratorios
                                      join farmodalicomerc in _context.Farmodalicomerc on farexpedmedicma.far_modcom_famc equals farmodalicomerc.far_modcom_famc into tmfarmodalicomerc
                                      from fatc in tmfarmaeclasifatc.DefaultIfEmpty()
                                      from fagf in tmfargrufarmacoma.DefaultIfEmpty()
                                      from fasg in tmfargrufarmacomd.DefaultIfEmpty()
                                      from faum in tmfarunidadmedida.DefaultIfEmpty()
                                      from fava in tmfarmedicamviadm.DefaultIfEmpty()
                                      //from falb in tmfarlaboratorios.DefaultIfEmpty()
                                      from falb in tmfarlaboratorios.DefaultIfEmpty()
                                      from famc in tmfarmodalicomerc.DefaultIfEmpty()
                                      where farexpedmedicma.far_expedi_fama.Contains(tcrBuscar) || farexpedmedicma.far_desexp_fama.Contains(tcrBuscar)
                                      select new ModeloFarExpedienteMedicamento
                                      {
                                          #region Datos
                                          Far_expedi_fama = farexpedmedicma.far_expedi_fama,
                                          Far_desexp_fama = farexpedmedicma.far_desexp_fama,
                                          Far_codatc_fatc = farexpedmedicma.far_codatc_fatc,
                                          Far_grufar_fagf = farexpedmedicma.far_grufar_fagf,
                                          Far_sugfar_fasg = farexpedmedicma.far_sugfar_fasg,
                                          Far_unimed_faum = farexpedmedicma.far_unimed_faum,
                                          Far_viaadm_fava = farexpedmedicma.far_viaadm_fava,
                                          Far_invima_fama = farexpedmedicma.far_invima_fama,
                                          Far_fecexp_fama = (DateTime)farexpedmedicma.far_fecexp_fama,
                                          Far_fecven_fama = (DateTime)farexpedmedicma.far_fecven_fama,
                                          Far_codlab_falb = farexpedmedicma.far_codlab_falb,
                                          Far_comerc_falb = farexpedmedicma.far_comerc_falb,
                                          Far_tiprol_fama = farexpedmedicma.far_tiprol_fama,
                                          Far_modcom_famc = farexpedmedicma.far_modcom_famc,
                                          Far_forfar_fama = farexpedmedicma.far_forfar_fama,
                                          Far_concen_fama = farexpedmedicma.far_concen_fama,
                                          Far_unimed_fama = farexpedmedicma.far_unimed_fama,
                                          Far_secdet_fama = (int)farexpedmedicma.far_secdet_fama,
                                          Far_estreg_fama = farexpedmedicma.far_estreg_fama,
                                          Far_desatc_fatc = fatc.far_desatc_fatc,
                                          Far_desgru_fagf = fagf.far_desgru_fagf,
                                          Far_desgru_fasg = fasg.far_desgru_fasg,
                                          Far_desmed_faum = faum.far_desmed_faum,
                                          Far_desvia_fava = fava.far_desvia_fava,
                                          Far_deslab_falb = falb.far_deslab_falb,
                                          Far_desmod_famc = famc.far_desmod_famc,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo farexpedmedicmd: Detalles expedientes medicamentos (lista presentaciones CUM)
    /// <summary>
    /// farexpedmedicmd: Detalles expedientes medicamentos (lista presentaciones CUM)
    /// </summary>
    public class ModeloFarExpedienteMedicamentoDetalle : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Far_secreg_famd: codigo unico registro
        private String _far_secreg_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: codigo unico registro</para>
        /// <para>NOMBRE: far_secreg_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial unico del registro (generado por el sistema)
        /// </para>
        /// </summary>
        public String Far_secreg_famd
        {
            get { return _far_secreg_famd; }
            set
            {
                if (_far_secreg_famd == value) return;
                _far_secreg_famd = value;
                OnPropertyChanged("Far_secreg_famd");
            }
        }
        #endregion
        #region Far_expedi_fama: Expediente invima
        private String _far_expedi_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Expediente invima</para>
        /// <para>NOMBRE: far_expedi_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero del registro expediente INVIMA
        /// </para>
        /// </summary>
        public String Far_expedi_fama
        {
            get { return _far_expedi_fama; }
            set
            {
                if (_far_expedi_fama == value) return;
                _far_expedi_fama = value;
                OnPropertyChanged("Far_expedi_fama");
            }
        }
        #endregion
        #region Far_concum_famd: Consecutivo presentacion
        private int _far_concum_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Consecutivo presentacion</para>
        /// <para>NOMBRE: far_concum_famd (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Consecutivo del regitro según presentacion que hace parte del
        /// codigo para generar el CUM
        /// </para>
        /// </summary>
        public int Far_concum_famd
        {
            get { return _far_concum_famd; }
            set
            {
                if (_far_concum_famd == value) return;
                _far_concum_famd = value;
                OnPropertyChanged("Far_concum_famd");
            }
        }
        #endregion
        #region Far_codcum_famd: Código CUM
        private String _far_codcum_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// según expediente INVIMA y presentacion comercial
        /// </para>
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
        #region Far_cancum_famd: Cantidad de unidades
        private int _far_cancum_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Cantidad de unidades</para>
        /// <para>NOMBRE: far_cancum_famd (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cantidade de unidades o contenidos según presentacion CUM ejemplo:
        /// Caja X 10 Unidades
        /// </para>
        /// </summary>
        public int Far_cancum_famd
        {
            get { return _far_cancum_famd; }
            set
            {
                if (_far_cancum_famd == value) return;
                _far_cancum_famd = value;
                OnPropertyChanged("Far_cancum_famd");
            }
        }
        #endregion
        #region Far_precom_famd: Descripcion presentacion
        private String _far_precom_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Descripcion presentacion</para>
        /// <para>NOMBRE: far_precom_famd (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion presentacion comercial del producto según expediente
        /// </para>
        /// </summary>
        public String Far_precom_famd
        {
            get { return _far_precom_famd; }
            set
            {
                if (_far_precom_famd == value) return;
                _far_precom_famd = value;
                OnPropertyChanged("Far_precom_famd");
            }
        }
        #endregion
        #region Far_secimg_faim: Código imagen JPG PNG
        private String _far_secimg_faim;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farmedicamimage</para>
        /// <para>CAMPO: Código imagen JPG PNG</para>
        /// <para>NOMBRE: far_secimg_faim (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codgo imagen JPG o PNG (por defecto) que representa el medicamento
        /// </para>
        /// </summary>
        public String Far_secimg_faim
        {
            get { return _far_secimg_faim; }
            set
            {
                if (_far_secimg_faim == value) return;
                _far_secimg_faim = value;
                OnPropertyChanged("Far_secimg_faim");
            }
        }
        #endregion
        #region Far_fecact_famd: Fecha activación
        private DateTime _far_fecact_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Fecha activación</para>
        /// <para>NOMBRE: far_fecact_famd (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha activacion del registro presentacion
        /// </para>
        /// </summary>
        public DateTime Far_fecact_famd
        {
            get { return _far_fecact_famd; }
            set
            {
                if (_far_fecact_famd == value) return;
                _far_fecact_famd = value;
                OnPropertyChanged("Far_fecact_famd");
            }
        }
        #endregion
        #region Far_fecina_famd: Fecha inactivación
        private DateTime _far_fecina_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Fecha inactivación</para>
        /// <para>NOMBRE: far_fecina_famd (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha inactivacion registro presentacion
        /// </para>
        /// </summary>
        public DateTime Far_fecina_famd
        {
            get { return _far_fecina_famd; }
            set
            {
                if (_far_fecina_famd == value) return;
                _far_fecina_famd = value;
                OnPropertyChanged("Far_fecina_famd");
            }
        }
        #endregion
        #region Far_estreg_famd: Estado Registro
        private String _far_estreg_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: far_estreg_famd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public String Far_estreg_famd
        {
            get { return _far_estreg_famd; }
            set
            {
                if (_far_estreg_famd == value) return;
                _far_estreg_famd = value;
                OnPropertyChanged("Far_estreg_famd");
            }
        }
        #endregion
        #region Far_desexp_fama: Descripcion producto
        private String _far_desexp_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion producto</para>
        /// <para>NOMBRE: far_desexp_fama (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del producto comercial según expediente INVIMA
        /// </para>
        /// </summary>
        public String Far_desexp_fama
        {
            get { return _far_desexp_fama; }
            set
            {
                if (_far_desexp_fama == value) return;
                _far_desexp_fama = value;
                OnPropertyChanged("Far_desexp_fama");
            }
        }
        #endregion
        #region Far_nomimg_faim: Archivo imagen
        private String _far_nomimg_faim;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farmedicamimage</para>
        /// <para>CAMPO: Archivo imagen</para>
        /// <para>NOMBRE: far_nomimg_faim (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre completo de la imagene con extencion ejemplo: IMG-0000012255-01-V0
        /// 1.PNG
        /// </para>
        /// </summary>
        public String Far_nomimg_faim
        {
            get { return _far_nomimg_faim; }
            set
            {
                if (_far_nomimg_faim == value) return;
                _far_nomimg_faim = value;
                OnPropertyChanged("Far_nomimg_faim");
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloFarExpedienteMedicamentoDetalle tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfarexpedmedicmd();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tobTempReg.Far_secreg_famd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.far_secreg_famd = tobTempReg.Far_secreg_famd;
                            lobEFReg.far_expedi_fama = tobTempReg.Far_expedi_fama;
                            lobEFReg.far_concum_famd = (int)tobTempReg.Far_concum_famd;
                            lobEFReg.far_codcum_famd = tobTempReg.Far_codcum_famd;
                            lobEFReg.far_cancum_famd = (int)tobTempReg.Far_cancum_famd;
                            lobEFReg.far_precom_famd = tobTempReg.Far_precom_famd;
                            lobEFReg.far_secimg_faim = tobTempReg.Far_secimg_faim;
                            lobEFReg.far_fecact_famd = (DateTime)tobTempReg.Far_fecact_famd;
                            lobEFReg.far_fecina_famd = (DateTime)tobTempReg.Far_fecina_famd;
                            lobEFReg.far_estreg_famd = tobTempReg.Far_estreg_famd;
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
                                lobEFReg.far_secreg_famd = tcrCodigoR1 + lobEFReg.far_secreg_famd; // concatenar
                                _context.AddToFarexpedmedicmd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tobTempReg.Far_secreg_famd);
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
        #region Buscar FAREXPEDMEDICMD: Logica
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TITULO: Detalles expediente medicamentos INVIMA según concentracion </para>
        /// <para>MODULO: FAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles medicamentos INVIMA según detallados según concentracion
        /// presentacion y expediente para los diferentes laboratorios
        /// </para>
        /// </summary>
        public static bool flgBuscarFarexpedmedicmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Farexpedmedicmd.FirstOrDefault(p => p.far_secreg_famd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros presentacion de un expediente
        /// <summary>
        /// Genera lista detalles presentaciones de un expediente CUM
        /// </summary>
        /// <param name="tcrCodigoR1">Codigo unico del Expediente Base para el CUM</param>
        /// <returns>Retorna una lista con todas las presentaciones CUM de un expediente</returns>
        public static List<ModeloFarExpedienteMedicamentoDetalle> flsListaFarexpedmedicmd(String tcrCodigoR1)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from farexpedmedicmd in _context.Farexpedmedicmd
                                  join farmedicamimage in _context.Farmedicamimage on farexpedmedicmd.far_secimg_faim equals farmedicamimage.far_secimg_faim into tmfarmedicamimage
                                  from faim in tmfarmedicamimage.DefaultIfEmpty()
                                  where farexpedmedicmd.far_expedi_fama == tcrCodigoR1
                                  select new ModeloFarExpedienteMedicamentoDetalle
                                  {
                                      Far_secreg_famd = farexpedmedicmd.far_secreg_famd,
                                      Far_expedi_fama = farexpedmedicmd.far_expedi_fama,
                                      Far_concum_famd = (int)farexpedmedicmd.far_concum_famd,
                                      Far_codcum_famd = farexpedmedicmd.far_codcum_famd,
                                      Far_cancum_famd = (int)farexpedmedicmd.far_cancum_famd,
                                      Far_precom_famd = farexpedmedicmd.far_precom_famd,
                                      Far_secimg_faim = farexpedmedicmd.far_secimg_faim,
                                      Far_fecact_famd = (DateTime)farexpedmedicmd.far_fecact_famd,
                                      Far_fecina_famd = (DateTime)farexpedmedicmd.far_fecina_famd,
                                      Far_estreg_famd = farexpedmedicmd.far_estreg_famd,
                                      Far_nomimg_faim = faim.far_nomimg_faim,
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

//- MARMOTA-GENCODE: VERSION 2.0 - 11/06/2015 11:42:53 AM
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

namespace Hospitalizacion.Modelo
{
    /// <summary>
    /// tabla: hosestanciapaci Lista de traslados pacientes a nueva cama
    /// </summary>
    public class ModeloTrasladoCamDe : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hos_codesp_espa: Codigo estancia hospitalaria
        private String _hos_codesp_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Codigo estancia hospitalaria</para>
        /// <para>NOMBRE: hos_codesp_espa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del registro de estancia hospitalaria generado
        /// por el sistema
        /// </para>
        /// </summary>
        public String Hos_codesp_espa
        {
            get { return _hos_codesp_espa; }
            set
            {
                if (_hos_codesp_espa == value) return;
                _hos_codesp_espa = value;
                OnPropertyChanged("Hos_codesp_espa");
            }
        }
        #endregion
        #region Hos_vistar_espa: Orden vista registro
        private int _hos_vistar_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Orden vista registro</para>
        /// <para>NOMBRE: hos_vistar_espa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Orden generado del registro para manejo de datos relacionados
        /// con registros anteriores de traslados
        /// </para>
        /// </summary>
        public int Hos_vistar_espa
        {
            get { return _hos_vistar_espa; }
            set
            {
                if (_hos_vistar_espa == value) return;
                _hos_vistar_espa = value;
                OnPropertyChanged("Hos_vistar_espa");
            }
        }
        #endregion
        #region Hos_tipesp_espa: Tipo traslado
        private String _hos_tipesp_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Tipo traslado</para>
        /// <para>NOMBRE: hos_tipesp_espa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo traslado para saber si es incial desde urgencias: 1=Traslado
        /// de Urgencias a Hospitalizacion 2=Traslado intrahospitalario
        /// </para>
        /// </summary>
        public String Hos_tipesp_espa
        {
            get { return _hos_tipesp_espa; }
            set
            {
                if (_hos_tipesp_espa == value) return;
                _hos_tipesp_espa = value;
                OnPropertyChanged("Hos_tipesp_espa");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
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
        #region Sia_idesec_usua: Codigo unico del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de datos ejm: CC= Cedula, RC= Rgistro
        /// Civil
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
        #region Desia_nroide_usua: Nombre paciente
        private String _desia_nroide_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: desia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_nroide_usua: Nombre concatenado del paciente
        /// (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public String Desia_nroide_usua
        {
            get { return _desia_nroide_usua; }
            set
            {
                if (_desia_nroide_usua == value) return;
                _desia_nroide_usua = value;
                OnPropertyChanged("Desia_nroide_usua");
            }
        }
        #endregion
        #region Sia_nroide_usua: Numero de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Dehos_codant_caho: Descripcion cama
        private String _dehos_codant_caho;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: dehos_codant_caho (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - hos_codant_caho: Descripcion cama según area
        /// funcional
        /// </para>
        /// </summary>
        public String Dehos_codant_caho
        {
            get { return _dehos_codant_caho; }
            set
            {
                if (_dehos_codant_caho == value) return;
                _dehos_codant_caho = value;
                OnPropertyChanged("Dehos_codant_caho");
            }
        }
        #endregion
        #region Hos_codant_caho: Cama anterior
        private String _hos_codant_caho;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama anterior</para>
        /// <para>NOMBRE: hos_codant_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo Cama anterior es la cama que tenia antes del traslado
        /// </para>
        /// </summary>
        public String Hos_codant_caho
        {
            get { return _hos_codant_caho; }
            set
            {
                if (_hos_codant_caho == value) return;
                _hos_codant_caho = value;
                OnPropertyChanged("Hos_codant_caho");
            }
        }
        #endregion
        #region Hos_codcam_caho: Cama actual
        private String _hos_codcam_caho;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama actual</para>
        /// <para>NOMBRE: hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo nueva cama asignada o actual en la cual queda instalado
        /// el paciente
        /// </para>
        /// </summary>
        public String Hos_codcam_caho
        {
            get { return _hos_codcam_caho; }
            set
            {
                if (_hos_codcam_caho == value) return;
                _hos_codcam_caho = value;
                OnPropertyChanged("Hos_codcam_caho");
            }
        }
        #endregion
        #region Hos_fecing_espa: Fecha ingreso
        private DateTime _hos_fecing_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Fecha ingreso</para>
        /// <para>NOMBRE: hos_fecing_espa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha en que inicia en la nueva cama asignada
        /// </para>
        /// </summary>
        public DateTime Hos_fecing_espa
        {
            get { return _hos_fecing_espa; }
            set
            {
                if (_hos_fecing_espa == value) return;
                _hos_fecing_espa = value;
                OnPropertyChanged("Hos_fecing_espa");
            }
        }
        #endregion
        #region Hos_horing_espa: Hora ingreso
        private Decimal _hos_horing_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Hora ingreso</para>
        /// <para>NOMBRE: hos_horing_espa (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Hora de ingreso formato militar ejm: 15.45
        /// </para>
        /// </summary>
        public Decimal Hos_horing_espa
        {
            get { return _hos_horing_espa; }
            set
            {
                if (_hos_horing_espa == value) return;
                _hos_horing_espa = value;
                OnPropertyChanged("Hos_horing_espa");
            }
        }
        #endregion
        #region Hos_fecsal_espa: Fecha salida
        private DateTime _hos_fecsal_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Fecha salida</para>
        /// <para>NOMBRE: hos_fecsal_espa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha en la que sale (sea por egreso hospitalario) o pasa a
        /// ocupar una nueva cama
        /// </para>
        /// </summary>
        public DateTime Hos_fecsal_espa
        {
            get { return _hos_fecsal_espa; }
            set
            {
                if (_hos_fecsal_espa == value) return;
                _hos_fecsal_espa = value;
                OnPropertyChanged("Hos_fecsal_espa");
            }
        }
        #endregion
        #region Hos_horsal_espa: Hora salida
        private Decimal _hos_horsal_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Hora salida</para>
        /// <para>NOMBRE: hos_horsal_espa (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Hora de de salida o finaliza la estancia en la cama, formato
        /// militar ejm: 15.45
        /// </para>
        /// </summary>
        public Decimal Hos_horsal_espa
        {
            get { return _hos_horsal_espa; }
            set
            {
                if (_hos_horsal_espa == value) return;
                _hos_horsal_espa = value;
                OnPropertyChanged("Hos_horsal_espa");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código Profesional Autoriza
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código Profesional Autoriza</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Código Profesional Que Autoriza traslado 
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
        #region Hos_diaest_espa: Dias de estancia
        private int _hos_diaest_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: hos_diaest_espa (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total dias de estancia que se generaron durante la estadia
        /// en la cama (se calculan al momento de ir a otro traslado o
        /// egreso de la IPS
        /// </para>
        /// </summary>
        public int Hos_diaest_espa
        {
            get { return _hos_diaest_espa; }
            set
            {
                if (_hos_diaest_espa == value) return;
                _hos_diaest_espa = value;
                OnPropertyChanged("Hos_diaest_espa");
            }
        }
        #endregion
        #region Hos_horest_espa: Horas de estancia
        private int _hos_horest_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: hos_horest_espa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Total hora de  estancia que se generaron durante la estadia
        /// en la cama (se calculan al momento de ir a otro traslado o
        /// egreso de la IPS)
        /// </para>
        /// </summary>
        public int Hos_horest_espa
        {
            get { return _hos_horest_espa; }
            set
            {
                if (_hos_horest_espa == value) return;
                _hos_horest_espa = value;
                OnPropertyChanged("Hos_horest_espa");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Estancia
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Estancia</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de estancia: 1=Abierto 2=confirmado 3=
        /// Anulado
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
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
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
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
        /// <para>TABLA: hosestanciapaci</para>
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
        #region Hos_descam_caho: Descripcion cama
        private String _hos_descam_caho;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public String Hos_descam_caho
        {
            get { return _hos_descam_caho; }
            set
            {
                if (_hos_descam_caho == value) return;
                _hos_descam_caho = value;
                OnPropertyChanged("Hos_descam_caho");
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: hosestanciapaci TEMPORAL</para>
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
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloTrasladoCamDe tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFhosestanciapaci();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Hosestanciapaci.FirstOrDefault(p => p.hos_codesp_espa == tobTempReg.Hos_codesp_espa);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.hos_codesp_espa = tobTempReg.Hos_codesp_espa;
                            lobEFReg.hos_vistar_espa = (int)tobTempReg.Hos_vistar_espa;
                            lobEFReg.hos_tipesp_espa = tobTempReg.Hos_tipesp_espa;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobTempReg.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.hos_codant_caho = tobTempReg.Hos_codant_caho;
                            lobEFReg.hos_codcam_caho = tobTempReg.Hos_codcam_caho;
                            lobEFReg.hos_fecing_espa = (DateTime)tobTempReg.Hos_fecing_espa;
                            lobEFReg.hos_horing_espa = (Decimal)tobTempReg.Hos_horing_espa;
                            lobEFReg.hos_fecsal_espa = (DateTime)tobTempReg.Hos_fecsal_espa;
                            lobEFReg.hos_horsal_espa = (Decimal)tobTempReg.Hos_horsal_espa;
                            lobEFReg.sia_codpfa_prof = tobTempReg.Sia_codpfa_prof;
                            lobEFReg.hos_diaest_espa = (int)tobTempReg.Hos_diaest_espa;
                            lobEFReg.hos_horest_espa = (int)tobTempReg.Hos_horest_espa;
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
                                lobEFReg.hos_codesp_espa = tcrCodigoR1 + lobEFReg.hos_codesp_espa; // concatenar
                                _context.AddToHosestanciapaci(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Hosestanciapaci.FirstOrDefault(p => p.hos_codesp_espa == tobTempReg.Hos_codesp_espa);
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
            //catch (Exception ex)
            catch (NotImplementedException ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HOSESTANCIAPACI: Logica
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TITULO: Maestro de estancias y traslados</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registrar las estancias y traslados de pacientes
        /// desde una cama a otra que esta en la misma area o difrentes
        /// areas de prestacion servicios
        /// </para>
        /// </summary>
        public static bool flgBuscarHosestanciapaci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosestanciapaci.FirstOrDefault(p => p.hos_codesp_espa == tcrCodigo);
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
        /// Retorna Lista registros detalles Traslados cama
        /// </summary>
        public static List<ModeloTrasladoCamDe> flsListaHosestanciapaci(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hosestanciapaci in _context.Hosestanciapaci
                                  join hoscamasareas in _context.Hoscamasareas on hosestanciapaci.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                  join sisestadoproces in _context.Sisestadoproces on hosestanciapaci.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  join siamaeprofsalud in _context.Siamaeprofsalud on hosestanciapaci.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  from caho in tmhoscamasareas.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  where hosestanciapaci.adm_secadm_rgad == tcrBuscar
                                  select new ModeloTrasladoCamDe
                                  {
                                      Hos_codesp_espa = hosestanciapaci.hos_codesp_espa,
                                      Hos_vistar_espa = (int)hosestanciapaci.hos_vistar_espa,
                                      Hos_tipesp_espa = hosestanciapaci.hos_tipesp_espa,
                                      Adm_secadm_rgad = hosestanciapaci.adm_secadm_rgad,
                                      Sia_idesec_usua = hosestanciapaci.sia_idesec_usua,
                                      Sia_tipide_tide = hosestanciapaci.sia_tipide_tide,
                                      Sia_nroide_usua = hosestanciapaci.sia_nroide_usua,
                                      Hos_codant_caho = hosestanciapaci.hos_codant_caho,
                                      Hos_codcam_caho = hosestanciapaci.hos_codcam_caho,
                                      Hos_fecing_espa = (DateTime)hosestanciapaci.hos_fecing_espa,
                                      Hos_horing_espa = (Decimal)hosestanciapaci.hos_horing_espa,
                                      Hos_fecsal_espa = (DateTime)hosestanciapaci.hos_fecsal_espa,
                                      Hos_horsal_espa = (Decimal)hosestanciapaci.hos_horsal_espa,
                                      Sia_codpfa_prof = hosestanciapaci.sia_codpfa_prof,
                                      Hos_diaest_espa = (int)hosestanciapaci.hos_diaest_espa,
                                      Hos_horest_espa = (int)hosestanciapaci.hos_horest_espa,
                                      Sis_estpro_espr = hosestanciapaci.sis_estpro_espr,
                                      Hos_descam_caho = caho.hos_descam_caho,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Dehos_codant_caho = _context.Hoscamasareas.FirstOrDefault(rxp => rxp.hos_codcam_caho == hosestanciapaci.hos_codant_caho).hos_descam_caho,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Un solo Registro
        /// <summary>
        /// Retorna un registro del tipo detalle Traslados cama
        /// </summary>
        public static ModeloTrasladoCamDe flsListaHosestanciapaciEx(String tcrIdRegistro)
        {
            using (_context = new DbAplicacion())
            {
                ModeloTrasladoCamDe lobReturn = null;

                var lobConsulta = from hosestanciapaci in _context.Hosestanciapaci
                                  join hoscamasareas in _context.Hoscamasareas on hosestanciapaci.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                  join sisestadoproces in _context.Sisestadoproces on hosestanciapaci.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  join siamaeprofsalud in _context.Siamaeprofsalud on hosestanciapaci.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  from caho in tmhoscamasareas.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  where hosestanciapaci.hos_codesp_espa == tcrIdRegistro
                                  select new ModeloTrasladoCamDe
                                  {
                                      Hos_codesp_espa = hosestanciapaci.hos_codesp_espa,
                                      Hos_vistar_espa = (int)hosestanciapaci.hos_vistar_espa,
                                      Hos_tipesp_espa = hosestanciapaci.hos_tipesp_espa,
                                      Adm_secadm_rgad = hosestanciapaci.adm_secadm_rgad,
                                      Sia_idesec_usua = hosestanciapaci.sia_idesec_usua,
                                      Sia_tipide_tide = hosestanciapaci.sia_tipide_tide,
                                      Sia_nroide_usua = hosestanciapaci.sia_nroide_usua,
                                      Hos_codant_caho = hosestanciapaci.hos_codant_caho,
                                      Hos_codcam_caho = hosestanciapaci.hos_codcam_caho,
                                      Hos_fecing_espa = (DateTime)hosestanciapaci.hos_fecing_espa,
                                      Hos_horing_espa = (Decimal)hosestanciapaci.hos_horing_espa,
                                      Hos_fecsal_espa = (DateTime)hosestanciapaci.hos_fecsal_espa,
                                      Hos_horsal_espa = (Decimal)hosestanciapaci.hos_horsal_espa,
                                      Sia_codpfa_prof = hosestanciapaci.sia_codpfa_prof,
                                      Hos_diaest_espa = (int)hosestanciapaci.hos_diaest_espa,
                                      Hos_horest_espa = (int)hosestanciapaci.hos_horest_espa,
                                      Sis_estpro_espr = hosestanciapaci.sis_estpro_espr,
                                      Hos_descam_caho = caho.hos_descam_caho,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Dehos_codant_caho = _context.Hoscamasareas.FirstOrDefault(rxp => rxp.hos_codcam_caho == hosestanciapaci.hos_codant_caho).hos_descam_caho,
                                      Sis_estado_imaen = "I",
                                  };
                if (lobConsulta!= null)
                {
                    lobReturn = lobConsulta.FirstOrDefault();
                }
                return lobReturn;
            }
        }
        #endregion
        #endregion
    }
}
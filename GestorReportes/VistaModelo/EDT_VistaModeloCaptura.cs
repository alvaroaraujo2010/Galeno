using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Media;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Sistema.Utilidades;
using Sistema.Modelo;
using GestorReportes.Utilidades;
using GestorReportes.Modelo;

namespace GestorReportes.VistaModelo
{
    public class VistaModeloCaptura : VistaModeloObjetoActivo
    {
        public String gcrIdVistaModeloForm = "HCL002";

        #region Vista Modelo Propiedad: GlgSIS_PuedeGuardar
        public string glgNomProp_PuedeGuardar = "GlgSIS_PuedeGuardar";
        private bool _glgSISPuedeGuardar = false;
        /// <summary>
        /// Permitir Activar la opcion guardar
        /// </summary>
        public bool GlgSIS_PuedeGuardar
        {
            get { return _glgSISPuedeGuardar; }
            set
            {
                if (_glgSISPuedeGuardar == value) { return; }
                _glgSISPuedeGuardar = value;
                RaisePropertyChanged(glgNomProp_PuedeGuardar);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedeConfirmar
        public string glgNomProp_PuedeConfirmar = "GlgSIS_PuedeConfirmar";
        private bool _glgSISPuedeConfirmar = false;
        /// <summary>
        /// Permitir Activar la opcion confirmar registro en vista (guardar definitivo)
        /// </summary>
        public bool GlgSIS_PuedeConfirmar
        {
            get { return _glgSISPuedeConfirmar; }
            set
            {
                if (_glgSISPuedeConfirmar == value) { return; }
                _glgSISPuedeConfirmar = value;
                RaisePropertyChanged(glgNomProp_PuedeConfirmar);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ValidacionOk
        public string glgNomProp_ValidacionOk = "GlgSIS_ValidacionOk";
        private bool _glgSISValidacionOk = false;
        /// <summary>
        /// Se activa cuando el registro diligenciado esta listo para ser confirmado
        /// </summary>
        public bool GlgSIS_ValidacionOk
        {
            get { return _glgSISValidacionOk; }
            set
            {
                if (_glgSISValidacionOk == value) { return; }
                _glgSISValidacionOk = value;
                RaisePropertyChanged(glgNomProp_ValidacionOk);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ExistenErrores
        public string glgNomProp_ExistenErrores = "GlgSIS_ExistenErrores";
        private bool _glgSISExistenErrores = false;
        /// <summary>
        /// Se activa cuando el registro diligenciado contiene errores
        /// </summary>
        public bool GlgSIS_ExistenErrores
        {
            get { return _glgSISExistenErrores; }
            set
            {
                if (_glgSISExistenErrores == value) { return; }
                _glgSISExistenErrores = value;
                RaisePropertyChanged(glgNomProp_ExistenErrores);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedeConfirmar
        public string glgNomProp_PuedeEliminarReg = "GlgSIS_PuedeEliminarReg";
        private bool _glgSISPuedeEliminarReg = false;
        /// <summary>
        /// Permitir Activar la opcion eliminar registro en estado sin confirmar
        /// </summary>
        public bool GlgSIS_PuedeEliminarReg
        {
            get { return _glgSISPuedeEliminarReg; }
            set
            {
                if (_glgSISPuedeEliminarReg == value) { return; }
                _glgSISPuedeEliminarReg = value;
                RaisePropertyChanged(glgNomProp_PuedeEliminarReg);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ModoGestionMultiSet
        public string glgNomProp_ModoGestionMultiSet = "GlgSIS_ModoGestionMultiSet";
        private bool _glgSISModoGestionMultiSet = false;
        /// <summary>
        /// Modo Gestion activado para datos multisesion en formulario (para activar opcion confirmar)
        /// </summary>
        public bool GlgSIS_ModoGestionMultiSet
        {
            get { return _glgSISModoGestionMultiSet; }
            set
            {
                if (_glgSISModoGestionMultiSet == value) { return; }
                _glgSISModoGestionMultiSet = value;
                RaisePropertyChanged(glgNomProp_ModoGestionMultiSet);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedePrnDiseñoVista
        public string glgNomProp_PuedePrnDiseñoVista = "GlgSIS_PuedePrnDiseñoVista";
        private bool _glgSISPuedePrnDiseñoVista = false;
        /// <summary>
        /// La plantilla tiene habilitado la opcion imprimir "Diseño vista en pantalla"
        /// </summary>
        public bool GlgSIS_PuedePrnDiseñoVista
        {
            get { return _glgSISPuedePrnDiseñoVista; }
            set
            {
                if (_glgSISPuedePrnDiseñoVista == value) { return; }
                _glgSISPuedePrnDiseñoVista = value;
                RaisePropertyChanged(glgNomProp_PuedePrnDiseñoVista);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedePrnTipoInforme
        public string glgNomProp_PuedePrnTipoInforme = "GlgSIS_PuedePrnTipoInforme";
        private bool _glgSISPuedePrnTipoInforme = false;
        /// <summary>
        /// La plantilla tiene habilitado la opcion imprimir formato "Tipo informe" 
        /// </summary>
        public bool GlgSIS_PuedePrnTipoInforme
        {
            get { return _glgSISPuedePrnTipoInforme; }
            set
            {
                if (_glgSISPuedePrnTipoInforme == value) { return; }
                _glgSISPuedePrnTipoInforme = value;
                RaisePropertyChanged(glgNomProp_PuedePrnTipoInforme);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedeFinAtencion
        public string glgNomProp_PuedeFinalAtencion = "GlgSIS_PuedeFinAtencion";
        private bool _glgSISPuedeFinalAtencion = false;
        /// <summary>
        /// Permitir Activar la opcion finalizar atencion ambulatoria
        /// </summary>
        public bool GlgSIS_PuedeFinAtencion
        {
            get { return _glgSISPuedeFinalAtencion; }
            set
            {
                if (_glgSISPuedeFinalAtencion == value) { return; }
                _glgSISPuedeFinalAtencion = value;
                RaisePropertyChanged(glgNomProp_PuedeFinalAtencion);
            }
        }
        #endregion
        #region Variables control perfil
        public String gcrSIS_PerfilCmdADD = String.Empty;
        //public String gcrSIS_PerfilCmdEDT = String.Empty;
        public String gcrSIS_PerfilCmdSAV = String.Empty;
        public String gcrSIS_PerfilCmdDEL = String.Empty;
        public String gcrSIS_PerfilCmdPRN = String.Empty;
        public String gcrSIS_PerfilCmdCON = String.Empty;
        public String gcrUsuaCodigoPerfil = String.Empty;
        #endregion
        //------------------------------------------------
        // Variables publicas de control general
        //------------------------------------------------
        /// <summary>Codigo de la admision activa en vista</summary>
        public String lcrIdAdmisionActiva = String.Empty;
        //------------------------------------------------
        //HCLREGISEVENTOS : Maestro registro secuencial de eventos historial
        //------------------------------------------------
        #region Notificacion campos: HCLREGISEVENTOS
        #region G1Hcl_nroreg_hcev: Codigo Evento medico
        public const string gcrNomProp_G1Hcl_nroreg_hcev = "G1Hcl_nroreg_hcev";
        private string _g1hcl_nroreg_hcev = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: g1hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial del evento medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Hcl_nroreg_hcev
        {
            get { return _g1hcl_nroreg_hcev; }
            set
            {
                if (_g1hcl_nroreg_hcev == value) return;
                _g1hcl_nroreg_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nroreg_hcev);
            }
        }
        #endregion
        #region G1Hcl_secreg_hcev: Secuencial evento
        public const string gcrNomProp_G1Hcl_secreg_hcev = "G1Hcl_secreg_hcev";
        private long _g1hcl_secreg_hcev = 0;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: g1hcl_secreg_hcev (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del evento medico, generado desde el contador
        /// en registro maestro de historia clinica del paciente
        /// </para>
        /// </summary>
        public long G1Hcl_secreg_hcev
        {
            get { return _g1hcl_secreg_hcev; }
            set
            {
                if (_g1hcl_secreg_hcev == value) return;
                _g1hcl_secreg_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_secreg_hcev);
            }
        }
        #endregion
        #region G1Hcl_nrohis_hicl: Numero historia clínica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G1Hcl_nrohis_hicl
        {
            get { return _g1hcl_nrohis_hicl; }
            set
            {
                if (_g1hcl_nrohis_hicl == value) return;
                _g1hcl_nrohis_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nrohis_hicl);
            }
        }
        #endregion
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
        /// </para>
        /// </summary>
        public string G1Adm_secadm_rgad
        {
            get { return _g1adm_secadm_rgad; }
            set
            {
                if (_g1adm_secadm_rgad == value) return;
                _g1adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secadm_rgad);
            }
        }
        #endregion
        #region G1Cit_codasi_mcit: Código registro cita
        public const string gcrNomProp_G1Cit_codasi_mcit = "G1Cit_codasi_mcit";
        private string _g1cit_codasi_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: g1cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código del registro asignación de cita a paciente, cuando el
        /// origen es desde citas medicas
        /// </para>
        /// </summary>
        public string G1Cit_codasi_mcit
        {
            get { return _g1cit_codasi_mcit; }
            set
            {
                if (_g1cit_codasi_mcit == value) return;
                _g1cit_codasi_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_codasi_mcit);
            }
        }
        #endregion
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public string G1Sia_idesec_usua
        {
            get { return _g1sia_idesec_usua; }
            set
            {
                if (_g1sia_idesec_usua == value) return;
                _g1sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_idesec_usua);
            }
        }
        #endregion
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public string G1Sia_tipide_tide
        {
            get { return _g1sia_tipide_tide; }
            set
            {
                if (_g1sia_tipide_tide == value) return;
                _g1sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipide_tide);
            }
        }
        #endregion
        #region G1Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G1Sia_nroide_usua
        {
            get { return _g1sia_nroide_usua; }
            set
            {
                if (_g1sia_nroide_usua == value) return;
                _g1sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nroide_usua);
            }
        }
        #endregion
        #region G1Hcl_gesfec_hcev: Fecha servicio
        public const string gcrNomProp_G1Hcl_gesfec_hcev = "G1Hcl_gesfec_hcev";
        private string _g1hcl_gesfec_hcev = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g1hcl_gesfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public string G1Hcl_gesfec_hcev
        {
            get { return _g1hcl_gesfec_hcev; }
            set
            {
                if (_g1hcl_gesfec_hcev == value) return;
                _g1hcl_gesfec_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_gesfec_hcev);
            }
        }
        #endregion
        #region G1Hcl_geshor_hcev: Hora servicio
        public const string gcrNomProp_G1Hcl_geshor_hcev = "G1Hcl_geshor_hcev";
        private String _g1hcl_geshor_hcev = "  :  :  ";
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: g1hcl_geshor_hcev (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora del evento o prestación del servicio al paciente en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Hcl_geshor_hcev
        {
            get { return _g1hcl_geshor_hcev; }
            set
            {
                if (_g1hcl_geshor_hcev == value) return;
                _g1hcl_geshor_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_geshor_hcev);
            }
        }
        #endregion
        #region G1Hcl_sisfec_hcev: Fecha sistema
        public const string gcrNomProp_G1Hcl_sisfec_hcev = "G1Hcl_sisfec_hcev";
        private string _g1hcl_sisfec_hcev = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: g1hcl_sisfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public string G1Hcl_sisfec_hcev
        {
            get { return _g1hcl_sisfec_hcev; }
            set
            {
                if (_g1hcl_sisfec_hcev == value) return;
                _g1hcl_sisfec_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_sisfec_hcev);
            }
        }
        #endregion
        #region G1Hcl_sishor_hcev: Hora sistema
        public const string gcrNomProp_G1Hcl_sishor_hcev = "G1Hcl_sishor_hcev";
        private String _g1hcl_sishor_hcev = "  :  :  ";
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: g1hcl_sishor_hcev (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Hcl_sishor_hcev
        {
            get { return _g1hcl_sishor_hcev; }
            set
            {
                if (_g1hcl_sishor_hcev == value) return;
                _g1hcl_sishor_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_sishor_hcev);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Código del profesional
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que realiza la atencion del evento
        /// </para>
        /// </summary>
        public string G1Sia_codpfa_prof
        {
            get { return _g1sia_codpfa_prof; }
            set
            {
                if (_g1sia_codpfa_prof == value) return;
                _g1sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpfa_prof);
            }
        }
        #endregion
        #region G1Grp_idepla_grpl: Código único plantilla
        public const string gcrNomProp_G1Grp_idepla_grpl = "G1Grp_idepla_grpl";
        private string _g1grp_idepla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: g1grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public string G1Grp_idepla_grpl
        {
            get { return _g1grp_idepla_grpl; }
            set
            {
                if (_g1grp_idepla_grpl == value) return;
                _g1grp_idepla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idepla_grpl);
            }
        }
        #endregion
        #region G1Grp_idepla_grpv: Código version plantilla
        public const string gcrNomProp_G1Grp_idepla_grpv = "G1Grp_idepla_grpv";
        private string _g1grp_idepla_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: g1grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la version plantilla usada
        /// </para>
        /// </summary>
        public string G1Grp_idepla_grpv
        {
            get { return _g1grp_idepla_grpv; }
            set
            {
                if (_g1grp_idepla_grpv == value) return;
                _g1grp_idepla_grpv = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idepla_grpv);
            }
        }
        #endregion
        #region G1Hcl_keydat_hcev: Palabras claves busqueda
        public const string gcrNomProp_G1Hcl_keydat_hcev = "G1Hcl_keydat_hcev";
        private String _g1hcl_keydat_hcev = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Palabras claves busqueda</para>
        /// <para>NOMBRE: g1hcl_keydat_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Palabras claves para usar como llaves de busqueda
        /// </para>
        /// </summary>
        public String G1Hcl_keydat_hcev
        {
            get { return _g1hcl_keydat_hcev; }
            set
            {
                if (_g1hcl_keydat_hcev == value) return;
                _g1hcl_keydat_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_keydat_hcev);
            }
        }
        #endregion
        #region G1Hcl_xmldat_hcev: Datos XML digitados
        public const string gcrNomProp_G1Hcl_xmldat_hcev = "G1Hcl_xmldat_hcev";
        private String _g1hcl_xmldat_hcev = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Datos XML digitados</para>
        /// <para>NOMBRE: g1hcl_xmldat_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Datos en formato XML diligenciados en el formato o plantilla
        /// (incluye imágenes y objetos vistas del muro)
        /// </para>
        /// </summary>
        public String G1Hcl_xmldat_hcev
        {
            get { return _g1hcl_xmldat_hcev; }
            set
            {
                if (_g1hcl_xmldat_hcev == value) return;
                _g1hcl_xmldat_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_xmldat_hcev);
            }
        }
        #endregion
        #region G1Hcl_xmltmp_hcev: Datos XML temporal
        public const string gcrNomProp_G1Hcl_xmltmp_hcev = "G1Hcl_xmltmp_hcev";
        private String _g1hcl_xmltmp_hcev = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Datos XML temporal</para>
        /// <para>NOMBRE: g1hcl_xmltmp_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Datos en formato XML diligenciados guardados de manera temporal
        /// por el sistema como respaldo de digitacion
        /// </para>
        /// </summary>
        public String G1Hcl_xmltmp_hcev
        {
            get { return _g1hcl_xmltmp_hcev; }
            set
            {
                if (_g1hcl_xmltmp_hcev == value) return;
                _g1hcl_xmltmp_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_xmltmp_hcev);
            }
        }
        #endregion
        #region G1Hcl_xmlcom_hcev: Comentarios XML
        public const string gcrNomProp_G1Hcl_xmlcom_hcev = "G1Hcl_xmlcom_hcev";
        private String _g1hcl_xmlcom_hcev = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Comentarios XML</para>
        /// <para>NOMBRE: g1hcl_xmlcom_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Datos en formato XML comentarios realizados al registro
        /// </para>
        /// </summary>
        public String G1Hcl_xmlcom_hcev
        {
            get { return _g1hcl_xmlcom_hcev; }
            set
            {
                if (_g1hcl_xmlcom_hcev == value) return;
                _g1hcl_xmlcom_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_xmlcom_hcev);
            }
        }
        #endregion
        #region G1Hcl_conobj_hcev: Contador generar objetos
        public const string gcrNomProp_G1Hcl_conobj_hcev = "G1Hcl_conobj_hcev";
        private int _g1hcl_conobj_hcev = 0;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Contador generar objetos</para>
        /// <para>NOMBRE: g1hcl_conobj_hcev (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Contador para generar Nombres unicos de objetos se agregan
        /// como etiquetas imágenes videos y otros
        /// </para>
        /// </summary>
        public int G1Hcl_conobj_hcev
        {
            get { return _g1hcl_conobj_hcev; }
            set
            {
                if (_g1hcl_conobj_hcev == value) return;
                _g1hcl_conobj_hcev = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_conobj_hcev);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Estado de procesos en atencion asistencial : 1= Abierto  2=
        /// Cerrado/Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public string G1Sis_estpro_espr
        {
            get { return _g1sis_estpro_espr; }
            set
            {
                if (_g1sis_estpro_espr == value) return;
                _g1sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estpro_espr);
            }
        }
        #endregion
        #region G1Hcl_notape_hicl: Nota de apertura
        public const string gcrNomProp_G1Hcl_notape_hicl = "G1Hcl_notape_hicl";
        private string _g1hcl_notape_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Nota de apertura</para>
        /// <para>NOMBRE: g1hcl_notape_hicl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota de apertura electronica de la historia clinica.
        /// </para>
        /// </summary>
        public string G1Hcl_notape_hicl
        {
            get { return _g1hcl_notape_hicl; }
            set
            {
                if (_g1hcl_notape_hicl == value) return;
                _g1hcl_notape_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_notape_hicl);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g1sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G1Sia_nomusu_usua
        {
            get { return _g1sia_nomusu_usua; }
            set
            {
                if (_g1sia_nomusu_usua == value) return;
                _g1sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nomusu_usua);
            }
        }
        #endregion
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: g1sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public string G1Sia_deside_tide
        {
            get { return _g1sia_deside_tide; }
            set
            {
                if (_g1sia_deside_tide == value) return;
                _g1sia_deside_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deside_tide);
            }
        }
        #endregion
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g1sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G1Sia_nompro_prof
        {
            get { return _g1sia_nompro_prof; }
            set
            {
                if (_g1sia_nompro_prof == value) return;
                _g1sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nompro_prof);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: g1sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string G1Sis_despro_espr
        {
            get { return _g1sis_despro_espr; }
            set
            {
                if (_g1sis_despro_espr == value) return;
                _g1sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_despro_espr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLREGISEVENTOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private HclModeloHistorialEventos _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hclregiseventos
        /// </summary>
        public HclModeloHistorialEventos TmpG1RegActivo
        {
            get { return _tmpg1regactivo; }
            set
            {
                if (_tmpg1regactivo == value) return;
                _tmpg1regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG1RegActivo);
            }
        }
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion varias
        //-------------------------------------------------
        #region Comandos para la gestion varias
        //Comandos para agregar Lista de ComboBoxItem
        public RelayCommand CmdActivarOpciones { get; set; }
        /// <summary>
        /// Comandos para activar botones
        /// </summary>
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdActivarOpciones = new RelayCommand(fcvAccBotones, CanActivarEdicion); 
        }
        #endregion
        //------------------------------------------------
        // Metodo instancia publica
        //------------------------------------------------
        public VistaModeloCaptura() { }
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region Adicionar Registro
        /// <summary>
        /// Adicionar Registro
        /// </summary>
        public virtual void Adicionar()
        {
            try
            {
                fcvReiniVariables();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public virtual void Guardar()
        {
            try
            {
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Hcl_nroreg_hcev = HclModeloHistorialEventos.fcrAddRegistro(TmpG1RegActivo);
                    G1Hcl_nroreg_hcev = TmpG1RegActivo.Hcl_nroreg_hcev;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    HclModeloHistorialEventos.fcvActualizar(TmpG1RegActivo);
                }
                GlgSIS_ModoAdicion = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            }
        }
        #endregion
        #region Eliminar Registro
        /// <summary>
        /// Eliminar Registro
        /// </summary>
        public virtual void Eliminar()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    HclModeloHistorialEventos.flgEliminar(TmpG1RegActivo.Hcl_nroreg_hcev);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Filtro
        /// <summary>
        /// Filtrar registros
        /// </summary>
        public void Filtro(String tcrFiltro)
        {
            try
            {
                List<HclModeloHistorialEventos> TmpG1ListaBrow = HclModeloHistorialEventos.flsBuscarHistorialEventos("HR",tcrFiltro);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = TmpG1ListaBrow.FirstOrDefault();
                    fcvCargarVariablesDesdeRegActivo();
                    GlgSIS_ModoEdicion = G1Sis_estpro_espr == "1" ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // COMANDOS DE ACTIVACION 
        //-------------------------------------------------
        #region Comandos de activacion Varios
        /// <summary>
        /// Activar o desactivar comandos varios
        /// </summary>
        public bool CanActivarEdicion()
        {
            bool llgReturn = false;
            try
            {
                GlgSIS_ModoEdicion = G1Sis_estpro_espr == "1" ? true : false;
                GlgSIS_ModoAdicion = GlgSIS_ModoEdicion;

                if (GlgSIS_ModoEdicion == true)
                {
                    GlgSIS_ValidacionOk = tmpLogErrores.Count != 0 ? false : true;
                    GlgSIS_PuedeGuardar = G1Sis_estpro_espr == "1" && String.IsNullOrWhiteSpace(gcrValorReturnChr) ? true : false;
                    GlgSIS_PuedeConfirmar = G1Sis_estpro_espr == "1" && GlgSIS_ValidacionOk == true ? true : false;
                    GlgSIS_ExistenErrores = tmpLogErrores.Count != 0 ? true : false;
                    GlgSIS_PuedeEliminarReg = G1Sis_estpro_espr == "1" && !String.IsNullOrWhiteSpace(G1Hcl_nroreg_hcev) ? true : false;

                    if (String.IsNullOrWhiteSpace(lcrIdAdmisionActiva))
                    {
                        GlgSIS_PuedeGuardar = false;
                        GlgSIS_PuedeConfirmar = false;
                    }

                    // verificar si el perfil tiene permiso
                    if (String.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(gcrUsuaCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { GlgSIS_PuedeEliminarReg = true; } else { GlgSIS_PuedeEliminarReg = false; }

                }
                else 
                {
                    GlgSIS_PuedeGuardar = false;
                    GlgSIS_PuedeConfirmar = false;
                    GlgSIS_ExistenErrores = false;
                    //GlgSIS_PuedeFinAtencion = false;
                }
                // Para objetos con multisession
                GlgSIS_PuedeConfirmar = GlgSIS_ModoGestionMultiSet == true ? true : GlgSIS_PuedeConfirmar;
                // Validar el tipo de formato para envio a impresora
                PropTxtPlantTipoImpresion = String.IsNullOrWhiteSpace(PropTxtPlantTipoImpresion) ? "2" : PropTxtPlantTipoImpresion;
                GlgSIS_PuedePrnDiseñoVista = PropTxtPlantTipoImpresion == "1" || PropTxtPlantTipoImpresion == "2" ? true : false;
                GlgSIS_PuedePrnTipoInforme = PropTxtPlantTipoImpresion == "1" || PropTxtPlantTipoImpresion == "3" ? true : false;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanActivarEdicion");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos Cargan los valores desde
        // variables al registro activo o lo contrario
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// </summary>
        public virtual void fcvReiniVariables()
        {
            try
            {
                #region Valores Variables
                G1Hcl_nroreg_hcev = string.Empty;
                G1Hcl_secreg_hcev = 0;
                G1Hcl_nrohis_hicl = string.Empty;
                G1Adm_secadm_rgad = string.Empty;
                G1Cit_codasi_mcit = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Hcl_gesfec_hcev = "  /  /    ";
                G1Hcl_geshor_hcev = "  :  :  ";
                G1Hcl_sisfec_hcev = "  /  /    ";
                G1Hcl_sishor_hcev = "  :  :  ";
                G1Sia_codpfa_prof = string.Empty;
                G1Grp_idepla_grpl = string.Empty;
                G1Grp_idepla_grpv = string.Empty;
                G1Hcl_keydat_hcev = string.Empty;
                G1Hcl_xmldat_hcev = string.Empty;
                G1Hcl_xmltmp_hcev = string.Empty;
                G1Hcl_xmlcom_hcev = string.Empty;
                G1Hcl_conobj_hcev = 0;
                G1Sis_estpro_espr = string.Empty;
                G1Hcl_notape_hicl = string.Empty;
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sis_despro_espr = string.Empty;
                #endregion
                TmpG1RegActivo = new HclModeloHistorialEventos();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                TmpG1RegActivo.Hcl_nroreg_hcev = G1Hcl_nroreg_hcev;
                TmpG1RegActivo.Hcl_secreg_hcev = G1Hcl_secreg_hcev;
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                TmpG1RegActivo.Cit_codasi_mcit = G1Cit_codasi_mcit;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Hcl_gesfec_hcev = Funciones.fdaConvertFecha("DMY", "/", G1Hcl_gesfec_hcev);
                TmpG1RegActivo.Hcl_geshor_hcev = Decimal.Parse(Funciones.fcrConvierteHora(G1Hcl_geshor_hcev, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Hcl_sisfec_hcev = Funciones.fdaConvertFecha("DMY", "/", G1Hcl_sisfec_hcev);
                TmpG1RegActivo.Hcl_sishor_hcev = Decimal.Parse(Funciones.fcrConvierteHora(G1Hcl_sishor_hcev, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG1RegActivo.Grp_idepla_grpv = G1Grp_idepla_grpv;
                TmpG1RegActivo.Hcl_keydat_hcev = G1Hcl_keydat_hcev;
                TmpG1RegActivo.Hcl_xmldat_hcev = G1Hcl_xmldat_hcev;
                TmpG1RegActivo.Hcl_xmltmp_hcev = G1Hcl_xmltmp_hcev;
                TmpG1RegActivo.Hcl_xmlcom_hcev = G1Hcl_xmlcom_hcev;
                TmpG1RegActivo.Hcl_conobj_hcev = G1Hcl_conobj_hcev;
                TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                TmpG1RegActivo.Hcl_notape_hicl = G1Hcl_notape_hicl;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region Cargar Variables desde Registro activo
        /// <summary>
        /// Cargar Variables desde Registro activo
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                G1Hcl_nroreg_hcev = TmpG1RegActivo.Hcl_nroreg_hcev;
                G1Hcl_secreg_hcev = TmpG1RegActivo.Hcl_secreg_hcev;
                G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                G1Cit_codasi_mcit = TmpG1RegActivo.Cit_codasi_mcit;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Hcl_gesfec_hcev = TmpG1RegActivo.Hcl_gesfec_hcev.ToShortDateString();
                G1Hcl_geshor_hcev = Funciones.fcrConvierteHora(TmpG1RegActivo.Hcl_geshor_hcev.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Hcl_sisfec_hcev = TmpG1RegActivo.Hcl_sisfec_hcev.ToShortDateString();
                G1Hcl_sishor_hcev = Funciones.fcrConvierteHora(TmpG1RegActivo.Hcl_sishor_hcev.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Grp_idepla_grpl = TmpG1RegActivo.Grp_idepla_grpl;
                G1Grp_idepla_grpv = TmpG1RegActivo.Grp_idepla_grpv;
                G1Hcl_keydat_hcev = TmpG1RegActivo.Hcl_keydat_hcev;
                G1Hcl_xmldat_hcev = TmpG1RegActivo.Hcl_xmldat_hcev;
                G1Hcl_xmltmp_hcev = TmpG1RegActivo.Hcl_xmltmp_hcev;
                G1Hcl_xmlcom_hcev = TmpG1RegActivo.Hcl_xmlcom_hcev;
                G1Hcl_conobj_hcev = TmpG1RegActivo.Hcl_conobj_hcev;
                G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                G1Hcl_notape_hicl = TmpG1RegActivo.Hcl_notape_hicl;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #endregion

    }
}

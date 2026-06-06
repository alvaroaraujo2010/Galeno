//- MARMOTA-GENCODE: VERSION 2.0 - 03/12/2013 07:06:53 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Datos.Modelos;
using ConsultaExterna.Modelo;

namespace ConsultaExterna.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloAtencionAmbulatoria : VistaModeloAtencionAmbulatoriaBase
    {
        //--------------------------------------------------------
        // Variables de notificación Zona 2 para activación
        //--------------------------------------------------------
        #region glgSIS_ActActoQuirurgico: Activar Campo Acto Quirurjico
        public string glgNomProp_SIS_ActActoQuirurgico = "GlgSIS_ActActoQuirurgico";
        private bool _glgSIS_ActActoQuirurgico = false;
        /// <summary>
        /// glgSIS_ActActoQuirurgico: Variable para el control de activacion
        /// la entrada en los campos para diagnosticos de 
        /// procedimientos solo cuando este sea acto quirurgico.
        /// </summary>
        public bool GlgSIS_ActActoQuirurgico
        {
            get { return _glgSIS_ActActoQuirurgico; }
            set
            {
                if (_glgSIS_ActActoQuirurgico == value) { return; }
                _glgSIS_ActActoQuirurgico = value;
                RaisePropertyChanged(glgNomProp_SIS_ActActoQuirurgico);
            }
        }
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO = new RelayCommand(fcvFiltro, CanFiltro);
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region CanFiltro
        /// <summary>
        ///Validación para saber si se permite ejecutar Filtro 
        /// </summary>
        public bool CanFiltro()
        {
            bool llgReturn = false;
            try
            {
                if (GcrSIS_FormModoPopup == "DFL" || (GlgSIS_ModoEdicion == false && GcrSIS_FormModoPopup == "EDT"))
                {
                    llgReturn = CanFIL();
                    if (GlgSIS_FormModoPopupIni == true && llgReturn == true && GcrSIS_FormModoPopup != "DFL")
                    {
                        GlgSIS_FormModoPopupIni = false;
                        Modificar();
                        GcrSIS_FormModoPopup = "DFL";
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFiltro");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region fcvFiltro: Filtro Auxiliar
        /// <summary>
        /// Filtro Auxiliar
        /// </summary>
        public void fcvFiltro()
        {
            Filtro();
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;
            try
            {
                GlgSIS_ActActoQuirurgico = G2Sia_codrip_trip == "04" && GlgSIS_ModoEdicion==true  ? true : false;
                switch (tcrNombrePropiedad)
                {
                    case "G1Adm_pacemb_rgad":
                        if (string.IsNullOrWhiteSpace(G1Adm_pacemb_rgad))
                        {
                            lcrValorReturn = "Dato estado  embarazada: Es requerido";
                        }
                        else if (!Funciones.flgExisteElemento(G1Adm_pacemb_rgad, ",", "1,2,3"))
                        {
                            lcrValorReturn = "Dato estado embarazada: no es valido";
                        }
                        else
                        {
                            if (G1Sis_codsex_sexo == "F" && G1Sia_codmed_tmed == "1") // Edad en años
                            {
                                if (G1Sia_edapac_usua >= 12 && G1Sia_edapac_usua <= 50 && G1Adm_pacemb_rgad=="3")
                                {
                                        lcrValorReturn = "Dato estado embarazada debe ser: 1=SI o 2=NO";
                                }
                            } 
                            else if (G1Adm_pacemb_rgad !="3")
                            {
                                  lcrValorReturn = "Dato estado embarazada debe ser: 3=NO APLICA";
                            }

                        }
                        break;

                    case "G1Adm_codoad_toad":
                        if (string.IsNullOrWhiteSpace(G1Adm_codoad_toad))
                        {
                            lcrValorReturn = "Código Origen admisión: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codoad_toad, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Código Origen admisión: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Adm_codcex_tcex":
                        if (string.IsNullOrWhiteSpace(G1Adm_codcex_tcex))
                        {
                            lcrValorReturn = "Causa Externa: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codcex_tcex, ",", "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15"))
                            {
                                lcrValorReturn = "Causa Externa: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Adm_caucon_rgad":
                        if (string.IsNullOrWhiteSpace(G1Adm_caucon_rgad))
                        {
                            lcrValorReturn = "Causa de Consulta: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Adm_caucon_rgad))
                            {
                                lcrValorReturn = "Causa de Consulta: Contiene Caracteres no validos";
                            }
                        }
                        break;

                    case "G1Adm_coddsa_tdsa":
                        if (string.IsNullOrWhiteSpace(G1Adm_dessal_regr))
                        {
                            lcrValorReturn = "Destino al salir: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_dessal_regr, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Destino al salir: Dato no es valido";
                            }
                        }
                        break;

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;
            try
            {
                if (G2Sia_codrip_trip == "01") // Consultas
                {
                    switch (tcrNombrePropiedad)
                    {
                        case "G2Sia_codfco_fcon":
                            #region Finalidad consulta
                            if (string.IsNullOrWhiteSpace(G2Sia_codfco_fcon))
                            {
                                lcrValorReturn = "Finalidad consulta: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G2Sia_codfco_fcon, ",", "01,02,03,04,05,06,07,08,09,10"))
                                {
                                    lcrValorReturn = "Finalidad consulta: Dato no es valido";
                                }
                            }
                            break;
                            #endregion

                        case "G2Adm_codcex_tcex":
                            #region Causa Externa
                            if (string.IsNullOrWhiteSpace(G2Adm_codcex_tcex))
                            {
                                lcrValorReturn = "Causa Externa: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G2Adm_codcex_tcex, ",", "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15"))
                                {
                                    lcrValorReturn = "Causa Externa: Dato no es valido";
                                }
                            }
                            break;
                            #endregion

                        case "G2Sia_coddia_tdia": // Diagnostico principal
                            #region Diagnostico principal
                            G2Sia_desdia_tdia = String.Empty;
                            if (string.IsNullOrWhiteSpace(G2Sia_coddia_tdia))
                            {
                                lcrValorReturn = "Diagnostico principal: Es requerido";
                            }
                            else
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddia_tdia);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                                {
                                    G2Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico principal: No existe";
                                }
                            }
                            break;
                            #endregion

                        case "G2Sia_coddx1_tdia":
                            #region Diagnostico relacionado 1
                            if (!string.IsNullOrWhiteSpace(G2Sia_coddx1_tdia))
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddx1_tdia);
                                if (tmp != null)
                                {
                                    G2Desia_coddx1_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico relacionado 1: No existe";
                                }
                            }
                            else 
                            {
                                G2Desia_coddx1_tdia = String.Empty;
                            }
                            break;
                            #endregion

                        case "G2Sia_coddx2_tdia":
                            #region Diagnostico relacionado 2
                            if (!string.IsNullOrWhiteSpace(G2Sia_coddx2_tdia))
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddx2_tdia);
                                if (tmp != null)
                                {
                                    G2Desia_coddx2_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico relacionado 2: No existe";
                                }
                            }
                            else 
                            {
                                G2Desia_coddx2_tdia = String.Empty;
                            }
                            break;
                            #endregion

                        case "G2Sia_coddx3_tdia":
                            #region Diagnostico relacionado 3
                            if (!string.IsNullOrWhiteSpace(G2Sia_coddx3_tdia))
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddx3_tdia);
                                if (tmp != null)
                                {
                                    G2Desia_coddx3_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico relacionado 3: No existe";
                                }
                            }
                            else 
                            {
                                G2Desia_coddx3_tdia = String.Empty;
                            }
                            break;
                            #endregion

                        case "G2Sia_tipdxp_tdix":
                            #region Tipo de diagnostico
                            if (string.IsNullOrWhiteSpace(G2Sia_tipdxp_tdix))
                            {
                                lcrValorReturn = "Tipo de diagnostico: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G2Sia_tipdxp_tdix, ",", "1,2,3"))
                                {
                                    lcrValorReturn = "Tipo de diagnostico: Dato no es valido";
                                }
                            }
                            break;
                            #endregion
                    }
                }
                else if (G2Sia_codrip_trip == "02" ||
                         G2Sia_codrip_trip == "03" ||
                         G2Sia_codrip_trip == "04" ||
                         G2Sia_codrip_trip == "05") // Procedimientos
                {
                    switch (tcrNombrePropiedad)
                    {
                        case "G2Sia_codfpr_fpor":
                            #region Finalidad Procedimiento
                            if (string.IsNullOrWhiteSpace(G2Sia_codfpr_fpor))
                            {
                                lcrValorReturn = "Finalidad Procedimiento: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G2Sia_codfpr_fpor, ",", "1,2,3,4,5"))
                                {
                                    lcrValorReturn = "Finalidad Procedimiento: Dato no es valido";
                                }
                            }
                            break;
                            #endregion

                        case "G2Sia_coddia_tdia": // Diagnostico principal
                            #region Diagnostico principal
                            if (GlgSIS_ActActoQuirurgico == true) // solo para procedimientos quirurjicos
                            {
                                G2Sia_desdia_tdia = String.Empty;
                                if (string.IsNullOrWhiteSpace(G2Sia_coddia_tdia))
                                {
                                    lcrValorReturn = "Diagnostico principal: Es requerido";
                                }
                                else
                                {
                                    EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                    tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddia_tdia);
                                    if (tmp != null)
                                    {
                                        G2Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                    }
                                    else
                                    {
                                        lcrValorReturn = "Diagnostico principal: No existe";
                                    }
                                }
                            }
                            break;
                            #endregion

                        case "G2Sia_coddx1_tdia":
                            #region Diagnostico relacionado 1
                            if (GlgSIS_ActActoQuirurgico == true) // solo para procedimientos quirurjicos
                            {
                                if (!string.IsNullOrWhiteSpace(G2Sia_coddx1_tdia))
                                {
                                    EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                    tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddx1_tdia);
                                    if (tmp != null)
                                    {
                                        G2Desia_coddx1_tdia = tmp.sia_desdia_tdia;
                                    }
                                    else
                                    {
                                        lcrValorReturn = "Diagnostico relacionado 1: No existe";
                                    }
                                }
                            }
                            break;
                            #endregion

                        case "G2Sia_coddxc_tdia": // Diagnostico complicacion
                            #region Diagnostico Complicación
                            if (GlgSIS_ActActoQuirurgico == true) // solo para procedimientos quirurjicos
                            {
                                if (!string.IsNullOrWhiteSpace(G2Sia_coddxc_tdia))
                                {
                                    EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                    tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddxc_tdia);
                                    if (tmp != null)
                                    {
                                        G2Desia_coddxc_tdia = tmp.sia_desdia_tdia;
                                    }
                                    else
                                    {
                                        lcrValorReturn = "Diagnostico complicación: No existe";
                                    }
                                }
                            }
                            break;
                            #endregion
                    }

                }
                else if (G2Sia_codrip_trip == "12" &&
                         G2Sia_codrip_trip == "13") // Medicamentos POS y NO POS
                {
                    switch (tcrNombrePropiedad)
                    {
                        case "G2Fcm_forfar_sips":
                            #region Forma farmacéutica
                            if (string.IsNullOrWhiteSpace(G2Fcm_forfar_sips))
                            {
                                lcrValorReturn = "Forma farmacéutica: Es requerido";
                            }
                            else
                            {
                            }
                            break;
                            #endregion

                        case "G2Fcm_conmed_sips":
                            #region Concentración
                            if (string.IsNullOrWhiteSpace(G2Fcm_conmed_sips))
                            {
                                lcrValorReturn = "Concentración: Es requerido";
                            }
                            else
                            {
                            }
                            break;
                            #endregion

                        case "G2Fcm_unimed_sips":
                            #region Unidad de medida
                            if (string.IsNullOrWhiteSpace(G2Fcm_unimed_sips))
                            {
                                lcrValorReturn = "Unidad de medida: Es requerido";
                            }
                            else
                            {
                            }
                            break;
                            #endregion
                    }
                }
                else // Otros servicios (Honorarios, Estancias, Bancos de Sangre, Traslados y otros)
                {
                    // Validacion 
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
    }
}
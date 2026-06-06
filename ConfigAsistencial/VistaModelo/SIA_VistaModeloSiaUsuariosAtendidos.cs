//- MARMOTA-GENCODE: VERSION 2.0 - 12/04/2015 07:04:40 PM
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
using Sistema.Clases;
using Datos.Modelos;
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siausuarioatend</para>
    /// <para>DESCRIPCION:
    ///  Maestro de usuarios/Pacientes que en algun momento recibieron
    ///  servicios medicos en la institucion, contiene todos los datos
    ///  personales de los pacientes, datos de demograficios, sisben,
    ///  afiliacion, nivel contributivo, gurpo poblacional
    /// </para>
    /// </summary>
    public class VistaModeloSiaUsuariosAtendidos : VistaModeloSiaUsuariosAtendidosBase
    {
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
        public String lcrIdAfiliado = String.Empty;
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
                    }
                }
                else if (GcrSIS_FormModoPopup == "ADD")
                {
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        if (!String.IsNullOrWhiteSpace(lcrIdAfiliado))
                        {
                            fcvAddRegDesdeMaestroAfiliados(lcrIdAfiliado);
                            lcrIdAfiliado = String.Empty;
                        }

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
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Hcl_nrohis_hicl":
                    	#region HCL_NROHIS_HICL: Historia Clínica
                        lcrNombreCampo = "Numero de historia clínica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                    	if (!string.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl))
                    	{
                            var tmp = HCLValidarCodigo.fobRegBuscarHclmaestrohiscl(G1Hcl_nrohis_hicl);
                            if (tmp ==null || String.IsNullOrWhiteSpace(tmp.hcl_nrohis_hicl))
                            {
                            	lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                    	}
                    	break;
                    	#endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código Eps/Asegurador
                        lcrNombreCampo = "Código Eps/Asegurador";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipide_tide":
                        #region SIA_TIPIDE_TIDE: Tipo Identificación
                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_tipide_tide = G1Sia_tipide_tide.ToUpper();

                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipide_tide))
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nroide_usua":
                        #region SIA_NROIDE_USUA: Identificación
                        lcrNombreCampo = "Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_nroide_usua = G1Sia_nroide_usua.Trim().ToUpper();

                            var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(G1Sia_nroide_usua);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Sia_idesec_usua != tmp.sia_idesec_usua) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_nroide_usua, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                                }
                                else
                                {
                                    if (Funciones.flgExisteSubCadenaStringEx(G1Sia_nroide_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": No debe ser solo texto";
                                    }
                                    if (G1Sia_tipide_tide == "CC" && !Funciones.flgExisteSubCadenaStringEx(G1Sia_nroide_usua, "0123456789"))
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Cedula solo debe contener números";
                                    }

                                    if (G1Sia_nroide_usua.Trim().Length < 4)
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": No es valida pocos caracteres (" + G1Sia_nroide_usua.Trim().Length.ToString() + ")";
                                    }
                                    else if (G1Sia_nroide_usua.Trim().Length == 4 && G1Sia_tipide_tide != "AS" && G1Sia_tipide_tide != "MS")
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": No es valida pocos caracteres (" + G1Sia_nroide_usua.Trim().Length.ToString() + ")";
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_priape_usua":
                        #region SIA_PRIAPE_USUA: Primer Apellido
                        lcrNombreCampo = "Primer Apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sia_priape_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_priape_usua = G1Sia_priape_usua.ToUpper();
                            if (G1Sia_priape_usua.Trim().Length <= 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Sia_priape_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_priape_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_segape_usua":
                        #region SIA_SEGAPE_USUA: Segundo Apellido
                        lcrNombreCampo = "Segundo Apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (!string.IsNullOrWhiteSpace(G1Sia_segape_usua))
                        {
                            G1Sia_segape_usua = G1Sia_segape_usua.ToUpper();
                            if (G1Sia_segape_usua.Trim().Length < 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Sia_segape_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_segape_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }

                        }
                        break;
                        #endregion

                    case "G1Sia_prinom_usua":
                        #region SIA_PRINOM_USUA: Primer Nombre
                        lcrNombreCampo = "Primer Nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Sia_prinom_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_prinom_usua = G1Sia_prinom_usua.ToUpper();
                            if (G1Sia_prinom_usua.Trim().Length <= 2)
                            {
                                lcrValorReturn = "Primer Nombre: No es valido pocos caracteres(" + G1Sia_prinom_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_prinom_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = "Primer Nombre: Contiene caracteres no validos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_segnom_usua":
                        #region SIA_SEGNOM_USUA: Segundo Nombre
                        lcrNombreCampo = "Segundo Nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (!string.IsNullOrWhiteSpace(G1Sia_segnom_usua))
                        {
                            G1Sia_segnom_usua = G1Sia_segnom_usua.ToUpper();
                            if (G1Sia_segnom_usua.Trim().Length < 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Sia_segnom_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_segnom_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_fecnac_usua":
                        #region SIA_FECNAC_USUA: Fecha nacimiento
                        lcrNombreCampo = "Fecha nacimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Sia_fecnac_usua, "Fecha nacimiento");
                        // cuando no hay error generar edad
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!flgGenerarDatosEdad())
                            {
                                lcrValorReturn = lcrNombreCampo+ ": Error en fecha de nacimiento";
                            }
                            /*
                                if (Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "AS,CC") && G1Sia_edaano_usua <= 17)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Tipo de identificación no corresponde con fecha de nacimiento";
                                }
                                else if (Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "MS,TI,RC") && G1Sia_edaano_usua >= 18)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Tipo de identificación no corresponde con fecha de nacimiento";
                                }

                            */
                        }
                        break;
                        #endregion

                    case "G1Sis_codsex_sexo":
                        #region SIS_CODSEX_SEXO: Sexo
                        lcrNombreCampo = "Sexo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sis_codsex_sexo))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sis_codsex_sexo = G1Sis_codsex_sexo.ToUpper();
                            var tmp = SISValidarCodigo.fobRegBuscarSistablasexos(G1Sis_codsex_sexo);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codsex_sexo))
                            {
                                G1Sis_dessex_sexo = tmp.sis_dessex_sexo;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipusu_regi":
                        #region SIA_TIPUSU_REGI: Régimen salud
                        lcrNombreCampo = "Régimen salud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (!string.IsNullOrWhiteSpace(G1Sia_tipusu_regi))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaregimensalud(G1Sia_tipusu_regi);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipusu_regi))
                            {
                                G1Sia_destip_regi = tmp.sia_destip_regi;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_tipcot_tcot":
                        #region SIA_TIPCOT_TCOT: Tipo cotizante
                        lcrNombreCampo = "Tipo cotizante contributivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (G1Sia_tipusu_regi == "1")
                        {
                            if (!string.IsNullOrWhiteSpace(G1Sia_tipcot_tcot))
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatipocotizante(G1Sia_tipcot_tcot);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipcot_tcot))
                                {
                                    G1Sia_descot_tcot = tmp.sia_descot_tcot;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": es requerido";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_tipcot_tcot))
                            {
                                lcrValorReturn = lcrNombreCampo + ":  Solo aplica pra contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipafi_tafi":
                        #region SIA_TIPAFI_TAFI: Tipo Afiliado Contributivo
                        lcrNombreCampo = "Tipo Afiliado Contributivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (G1Sia_tipusu_regi == "1")
                        {
                            if (!string.IsNullOrWhiteSpace(G1Sia_tipafi_tafi))
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatipaficontri(G1Sia_tipafi_tafi);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipafi_tafi))
                                {
                                    G1Sia_destaf_tafi = tmp.sia_destaf_tafi;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": es requerido";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Solo aplica pra contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_valibc_usua":
                        #region SIA_VALIBC_USUA: Ingreso base cotización
                        lcrNombreCampo = "Ingreso base cotización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A47";
                        if (G1Sia_valibc_usua < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o iagual a cero";
                        }
                        else
                        {
                            if (G1Sia_tipusu_regi != "1" && G1Sia_valibc_usua > 0)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Solo se aplica para Régimen Contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codper_pret":
                        #region SIA_CODPER_PRET: Pertenencia etnica
                        lcrNombreCampo = "Pertenencia etnica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A48";
                        if (String.IsNullOrWhiteSpace(G1Sia_codper_pret))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_codper_pret = G1Sia_codper_pret.ToUpper();
                            var tmp = SIAValidarCodigo.fobRegBuscarSiapertenetnica(G1Sia_codper_pret);
                            if (tmp != null)
                            {
                                G1Sia_desper_pret = tmp.sia_desper_pret;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nivedu_sine":
                        #region SIA_NIVEDU_SINE: Nivel educativo
                        lcrNombreCampo = "Nivel educativo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A47";
                        if (String.IsNullOrWhiteSpace(G1Sia_nivedu_sine))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSianiveleducati(G1Sia_nivedu_sine);
                            if (tmp != null)
                            {
                                G1Sia_desedu_sine = tmp.sia_desedu_sine;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tippob_tpob":
                        #region SIA_TIPPOB_TPOB: Tipo población especial
                        lcrNombreCampo = "Tipo población especial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (!string.IsNullOrWhiteSpace(G1Sia_tippob_tpob))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatippoblacion(G1Sia_tippob_tpob);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tippob_tpob))
                            {
                                G1Sia_despob_tpob = tmp.sia_despob_tpob;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_nivsbn_nsbn":
                        #region SIA_NIVSBN_NSBN: Nivel Sisben
                        lcrNombreCampo = "Nivel Sisben";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (!string.IsNullOrWhiteSpace(G1Sia_nivsbn_nsbn))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSianivelsisben(G1Sia_nivsbn_nsbn);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nivsbn_nsbn))
                            {
                                G1Sia_dessbn_nsbn = tmp.sia_dessbn_nsbn;
                                if (G1Sia_tipusu_regi != "2" && G1Sia_nivsbn_nsbn != "N")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Valor diferenente de N solo aplica pra regimen subsidiado";
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_nivcon_ncon":
                        #region SIA_NIVCON_NCON: Nivel Contributivo
                        lcrNombreCampo = "Nivel Contributivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (G1Sia_tipusu_regi == "1")
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSianivcontribut(G1Sia_nivcon_ncon);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nivcon_ncon))
                                {
                                    G1Sia_descon_ncon = tmp.sia_descon_ncon;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Nivel Contributivo: Dato es requerido";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                            {
                                lcrValorReturn = "Nivel Contributivo: solo aplica para régimen contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_idemun_muni":
                        #region SIS_IDEMUN_MUNI: Id Único Municipio
                        lcrNombreCampo = "Id Único Municipio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Sis_idemun_muni))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFsistabmunicipio tmp = new EFsistabmunicipio();
                            tmp = SISValidarCodigo.fobRegBuscarSistabmunicipio(G1Sis_idemun_muni);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_idemun_muni))
                            {
                                G1Sis_codmun_muni = tmp.sis_codmun_muni;
                                G1Sis_coddep_dpto = tmp.sis_coddep_dpto;
                                G1Sis_nommun_muni = tmp.sis_nommun_muni;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codmun_muni":
                        #region SIS_CODMUN_MUNI: Código Municipio
                        lcrNombreCampo = "Código Municipio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Sis_codmun_muni))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sis_coddep_dpto":
                        #region SIS_CODDEP_DPTO: Código Departamento
                        lcrNombreCampo = "Código Departamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Sis_coddep_dpto))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSistabdepartame(G1Sis_coddep_dpto);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_coddep_dpto))
                            {
                                G1Sis_desdep_dpto = tmp.sis_desdep_dpto;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_zonres_tzon":
                        #region SIS_ZONRES_TZON: Zona de residencia
                        lcrNombreCampo = "Zona de residencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (!string.IsNullOrWhiteSpace(G1Sis_zonres_tzon))
                        {
                            G1Sis_zonres_tzon = G1Sis_zonres_tzon.ToUpper();
                            var tmp = new EFsiszonaresidenc();
                            tmp = SISValidarCodigo.fobRegBuscarSiszonaresidenc(G1Sis_zonres_tzon);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_zonres_tzon))
                            {
                                G1Sis_deszon_tzon = tmp.sis_deszon_tzon;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_telres_usua":
                        #region SIA_TELRES_USUA: Telefono
                        lcrNombreCampo = "Numero telefono del afiliado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Sia_telres_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else 
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_telres_usua, "0123456789 -"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dirres_usua":
                        #region SIA_DIRRES_USUA: Dirección residencia
                        lcrNombreCampo = "Dirección residencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (String.IsNullOrWhiteSpace(G1Sia_dirres_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else 
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_dirres_usua, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ#- "))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_correo_usua":
                        #region SIA_CORREO_USUA: Correo electronico
                        lcrNombreCampo = "Correo electronico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (String.IsNullOrWhiteSpace(G1Sia_correo_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_correo_usua.ToUpper(), "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ._@-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codocu_ocup":
                        #region SIS_CODOCU_OCUP: Codigo ocupación
                        lcrNombreCampo = "Codigo ocupación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (String.IsNullOrWhiteSpace(G1Sis_codocu_ocup))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisocupaciones(G1Sis_codocu_ocup);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codocu_ocup))
                            {
                                G1Sis_desocu_ocup = tmp.sis_desocu_ocup;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_feceps_usua":
                        #region SIA_FECEPS_USUA: Fecha afiliación EPS
                        lcrNombreCampo = "Fecha afiliación EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", G1Sia_feceps_usua, "Fecha afiliación EPS");
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                        #region CTO_SECCON_CONT: Secuencial de Contrato
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
                            {
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Cto_descon_cont = tmp.cto_descon_cont;
                                G1Sia_tipusu_regi = tmp.sia_tipusu_regi;
                                if (tmp.cto_modeps_cont == "1") // cuando se permite cambiar la eps
                                {
                                    if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                }
                                else
                                {
                                    G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                }
                                fcvVerificarValoresPorDefecto();
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_discap_usua":
                        #region SIA_DISCAP_USUA: Discapacidad SI/NO
                        lcrNombreCampo = "Discapacidad SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A33";
                        if (!String.IsNullOrWhiteSpace(G1Sia_discap_usua))
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_discap_usua, ",", "S,N"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        else 
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_tipdis_tdis":
                        #region SIA_TIPDIS_TDIS: Tipo discapacidad
                        lcrNombreCampo = "Tipo discapacidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A34";
                        if (!string.IsNullOrWhiteSpace(G1Sia_tipdis_tdis))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipdiscapaci(G1Sia_tipdis_tdis);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipdis_tdis))
                            {
                                G1Sia_desdis_tdis = tmp.sia_desdis_tdis;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_edapac_usua":
                        #region SIA_EDAPAC_USUA: Edad Paciente
                        lcrNombreCampo = "Edad Paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A35";
                        if (G1Sia_edapac_usua > 0)
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_codmed_tmed":
                        #region SIA_CODMED_TMED: Medida Edad
                        lcrNombreCampo = "Medida Edad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codmed_tmed))
                        {
                            EFsiamedidaedad tmp = new EFsiamedidaedad();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamedidaedad(G1Sia_codmed_tmed);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codmed_tmed))
                            {
                                G1Sia_desmed_tmed = tmp.sia_desmed_tmed;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_edaymd_usua":
                        #region SIA_EDAYMD_USUA: Edad formato largo
                        lcrNombreCampo = "Edad formato largo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A40";
                        if (String.IsNullOrWhiteSpace(G1Sia_edaymd_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_codcat_ceat":
                        #region SIA_CODCAT_CEAT: Código centro atención
                        lcrNombreCampo = "Código centro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A42";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codcat_ceat))
                            {
                                G1Sia_descat_ceat = tmp.sia_descat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Código Estado Registro
                        lcrNombreCampo = "Código Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A46";
                        if (String.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G1Sis_estreg_esrg);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_estreg_esrg))
                            {
                                G1Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region Calculos edad usuario
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato loargo</para>
        /// </summary>
        public bool flgGenerarDatosEdad()
        {
            var llgValor = false;
            if (Funciones.flgValidarRangoFecha(G1Sia_fecnac_usua, DateTime.Today.ToShortDateString()))
            {
                llgValor = true;
                var ldaFechaNac = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                var ldaFechaFin = DateTime.Today;

                G1Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaFin);
                G1Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaFin);
                G1Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaFin);
                G1Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaFin);
                if (G1Sia_edaano_usua <= 120 && G1Sia_edaano_usua >= 0)
                {
                    fcvMedidaDatosEdad();
                }
                else
                {
                    llgValor = false;
                }
            }
            return llgValor;
        }
        /// <summary>
        /// <para>Asigna la edad y medidad edad</para>
        /// </summary>
        public void fcvMedidaDatosEdad()
        {
            if (G1Sia_edaano_usua > 0)
            {
                G1Sia_edapac_usua = G1Sia_edaano_usua;
                G1Sia_codmed_tmed = "1";
            }
            else if(G1Sia_edames_usua > 0)
            {
                G1Sia_edapac_usua = G1Sia_edames_usua;
                G1Sia_codmed_tmed = "2";
            }
            else
            {
                G1Sia_edapac_usua = G1Sia_edadia_usua;
                G1Sia_codmed_tmed = "3";
            }
        }
        #endregion
        #region fcvAddRegDesdeMaestroAfiliados
        /// <summary>
        /// Cargar datos del usuario desde archivo maestro afiliados contratos
        /// </summary>
        public void fcvAddRegDesdeMaestroAfiliados(String tcrIdUnico)
        {
            var lobReg = CTOValidarCodigo.fobRegBuscarCtomaeafiliados(tcrIdUnico);

            if (lobReg != null)
            {
                // Cargar datos 
                #region Valores Variables
                //G1Sia_idesec_usua = lobReg.cto_idesec_ctou;
                G1Hcl_nrohis_hicl = lobReg.hcl_nrohis_hicl;
                G1Sia_codeps_teps = lobReg.sia_codeps_teps;
                G1Sia_tipide_tide = lobReg.sia_tipide_tide;
                G1Sia_nroide_usua = lobReg.sia_nroide_usua;
                G1Sia_priape_usua = lobReg.sia_priape_usua;
                G1Sia_segape_usua = lobReg.sia_segape_usua;
                G1Sia_prinom_usua = lobReg.sia_prinom_usua;
                G1Sia_segnom_usua = lobReg.sia_segnom_usua;
                G1Sia_fecnac_usua = Funciones.fcrConvertFecha((DateTime)lobReg.sia_fecnac_usua);
                G1Sis_codsex_sexo = lobReg.sis_codsex_sexo;
                G1Sia_nomusu_usua = lobReg.sia_nomusu_usua;
                G1Sia_tipusu_regi = lobReg.sia_tipusu_regi;
                G1Sia_tipcot_tcot = lobReg.sia_tipcot_tcot;
                G1Sia_tipafi_tafi = lobReg.sia_tipafi_tafi;
                G1Sia_valibc_usua = (int)lobReg.sia_valibc_usua;
                G1Sia_tippob_tpob = lobReg.sia_tippob_tpob;
                G1Sia_codper_pret = lobReg.sia_codper_pret;
                G1Sia_nivsbn_nsbn = lobReg.sia_nivsbn_nsbn;
                G1Sia_nivcon_ncon = lobReg.sia_nivcon_ncon;
                G1Sis_idemun_muni = lobReg.sis_idemun_muni;
                G1Sis_codmun_muni = lobReg.sis_codmun_muni;
                G1Sis_coddep_dpto = lobReg.sis_coddep_dpto;
                G1Sis_zonres_tzon = lobReg.sis_zonres_tzon;
                G1Sia_telres_usua = lobReg.sia_telres_usua;
                G1Sia_dirres_usua = lobReg.sia_dirres_usua;
                G1Sia_correo_usua = lobReg.sia_correo_usua;
                G1Sis_codocu_ocup = lobReg.sis_codocu_ocup;
                G1Sia_feceps_usua = Funciones.fcrConvertFecha((DateTime)lobReg.sia_feceps_usua);
                G1Cto_seccon_cont = lobReg.cto_seccon_cont;
                G1Cto_nrocon_cont = lobReg.cto_nrocon_cont;
                G1Sia_tpidap_tide = lobReg.sia_tpidap_tide;
                G1Sia_ideapo_usua = lobReg.sia_ideapo_usua;
                G1Sia_modsub_usua = lobReg.sia_modsub_usua;
                G1Sia_discap_usua = lobReg.sia_discap_usua;
                G1Sia_tipdis_tdis = lobReg.sia_tipdis_tdis;
                G1Sia_codmed_tmed = lobReg.sia_codmed_tmed;
                G1Sia_codcat_ceat = lobReg.sia_codcat_ceat;
                G1Sys_codusu_usux = lobReg.sys_codusu_usux;
                G1Sis_estreg_esrg = lobReg.sis_estreg_esrg;
                #endregion

            }
        }
        #endregion
        #region fcvVerificarValoresPorDefecto: Verificar si hay valores por defecto
        /// <summary>
        /// <para>Verificar si hay valores por defecto y cambiar datos según regimen salud</para>
        /// </summary>
        public void fcvVerificarValoresPorDefecto()
        {
            if (larValDefault02 == null) { return; }
            // cuando hay valores 
            if (larValDefault02.Length != 0)
            {
                if (G1Sia_tipusu_regi == "1")
                {
                    G1Sia_nivsbn_nsbn = "N";
                    if (String.IsNullOrWhiteSpace(G1Sia_tipcot_tcot)) { G1Sia_tipcot_tcot = larValDefault02[1].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi)) { G1Sia_tipafi_tafi = larValDefault02[2].Trim(); }
                    if (G1Sia_valibc_usua <= 0) { G1Sia_valibc_usua = Convert.ToInt32(larValDefault02[3].Trim()); }
                    if (String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon)) { G1Sia_nivcon_ncon = larValDefault02[5].Trim(); }

                }
                else 
                {
                    G1Sia_tipcot_tcot = String.Empty;
                    G1Sia_tipafi_tafi = String.Empty;
                    G1Sia_valibc_usua = 0;
                    G1Sia_nivcon_ncon = String.Empty;

                    if (G1Sia_tipusu_regi != "2") // Diferente de subsidiado
                    {
                        G1Sia_nivsbn_nsbn = "N";
                    }
                    else 
                    {
                        // es subsidiado
                        G1Sia_nivsbn_nsbn = String.IsNullOrWhiteSpace(G1Sia_nivsbn_nsbn) || G1Sia_nivsbn_nsbn == "N"  ? "1" : G1Sia_nivsbn_nsbn;
                    }
                }

            }
        }
        #endregion

    }
}
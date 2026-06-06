//- MARMOTA-GENCODE: VERSION 2.0 - 02/04/2014 10:53:00 AM
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
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclmaestrohiscl</para>
    /// <para>DESCRIPCION:
    ///  Maestro de historias clínicas electrónicas abiertas a pacientes
    /// </para>
    /// </summary>
    public class VistaModeloHclmaehistoriasclinicas : VistaModeloHclmaehistoriasclinicasBase
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
                    var lcrCodigo1 = G1Hcl_nrohis_hicl;
                    var lcrCodigo2 = G1Sia_nroide_usua;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Hcl_nrohis_hicl = lcrCodigo1;
                        G1Sia_nroide_usua = lcrCodigo2;
                        fcrValidacion("G1Hcl_nrohis_hicl");
                        fcrValidacion("G1Sia_nroide_usua");
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

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_idesec_usua":
                        if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = "Código único del paciente: Es requerido";
                        }
                        else
                        {
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null)
                            {
                                G1Hcl_nrohis_hicl = String.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl) ? tmp.hcl_nrohis_hicl : G1Hcl_nrohis_hicl;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                            }
                            else
                            {
                                lcrValorReturn = "Código único del paciente: No existe";
                            }
                        }
                        break;

                    case "G1Sia_tipide_tide":
                        if (string.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = "Tipo Identificación: Es requerido";
                        }
                        else
                        {
                            EFsiatipideusario tmp = new EFsiatipideusario();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null)
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Identificación: No existe";
                            }
                        }
                        break;

                    case "G1Sia_nroide_usua":
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "número de Identificación: Es requerido";
                        }
                        else
                        {
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(G1Sia_nroide_usua);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Hcl_nrohis_hicl = String.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl) ? tmp.hcl_nrohis_hicl : G1Hcl_nrohis_hicl;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                            }
                            else
                            {
                                lcrValorReturn = "número de Identificación: No existe";
                            }
                        }
                        break;

                    case "G1Hcl_fecapp_hicl":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Hcl_fecapp_hicl, "Fecha apertura HC");
                        break;

                    case "G1Hcl_fecape_hicl":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Hcl_fecape_hicl, "Apertura electrónica");
                        break;

                    case "G1Sia_codpfa_prof":
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código del profesional: Es requerido";
                        }
                        else
                        {
                            G1Sia_codpfa_prof = G1Sia_codpfa_prof.Trim().ToUpper();
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Código del profesional: No existe";
                            }
                        }
                        break;

                    case "G1Hcl_hpapel_hicl":
                        if (string.IsNullOrWhiteSpace(G1Hcl_hpapel_hicl))
                        {
                            lcrValorReturn = "Historia clínica en papel: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_hpapel_hicl, ",", "1,2"))
                            {
                                lcrValorReturn = "Historia clínica en papel: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Hcl_papeld_hicl":
                        if (string.IsNullOrWhiteSpace(G1Hcl_papeld_hicl))
                        {
                            lcrValorReturn = "Historia clínica escaneada: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_papeld_hicl, ",", "1,2"))
                            {
                                lcrValorReturn = "Historia clínica escaneada: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Hcl_ncarpe_hicl":
                        if (!string.IsNullOrWhiteSpace(G1Hcl_ncarpe_hicl))
                        {
                        }
                        break;

                    case "G1Hcl_nestan_hicl":
                        if (!string.IsNullOrWhiteSpace(G1Hcl_nestan_hicl))
                        {
                        }
                        break;

                    case "G1Grc_iderec_grcm":
                        if (!string.IsNullOrWhiteSpace(G1Grc_iderec_grcm))
                        {
                        }
                        break;

                    case "G1Hcl_notape_hicl":
                        if (string.IsNullOrWhiteSpace(G1Hcl_notape_hicl))
                        {
                            lcrValorReturn = "Nota de apertura: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Hcl_notape_hicl))
                            {
                                lcrValorReturn = "Nota de apertura: Contiene Caracteres no validos";
                            }
                        }
                        break;

                    case "G1Sis_estreg_esrg":
                        #region Datos
                        if (string.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                    	{
                            lcrValorReturn = "Código Estado Registro: Es requerido";
                    	}
                    	else
                    	{
                            EFsisestadoproces tmp = new EFsisestadoproces();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estreg_esrg);
                            if (tmp!=null)
                            {
                                G1Sis_desest_esrg = tmp.sis_despro_espr;
                            }
                            else
                            {
                                lcrValorReturn = "Código Estado Registro: No existe";
                            }
                    	}
                    	break;
                        #endregion

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
    }
}
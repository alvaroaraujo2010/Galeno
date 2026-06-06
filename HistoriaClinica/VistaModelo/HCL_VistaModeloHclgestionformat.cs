//- MARMOTA-GENCODE: VERSION 2.0 - 15/01/2018 04:46:10 PM
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
using GalaSoft.MvvmLight.Messaging;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclformatvistma</para>
    /// <para>DESCRIPCION:
    ///  Grupos formatos de actividad o servicios para organización
    ///  en vista captura historias clinicas (capa Propiedades) y agrupados
    ///  según funcionalidad de cada formato y perfil de usuario
    /// </para>
    /// </summary>
    public class VistaModeloHclgestionformat : VistaModeloHclgestionformatBase
    {
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
        public override String fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Hcl_desgru_hcra":
                        #region HCL_DESGRU_HCRA: Nombre grupo actividad
                        lcrNombreCampo = "Nombre grupo actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hcl_desgru_hcra))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_tipvis_hcra":
                        #region HCL_TIPVIS_HCRA: Mostrar según admision
                        lcrNombreCampo = "Mostrar según admision";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Hcl_tipvis_hcra))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_tipvis_hcra, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_ordvis_hcra":
                        #region HCL_ORDVIS_HCRA: Orden visualizacion
                        lcrNombreCampo = "Orden visualizacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (G1Hcl_ordvis_hcra <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_imagen_hcra":
                        #region HCL_IMAGEN_HCRA: Imagen (jpg)
                        lcrNombreCampo = "Imagen (jpg)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hcl_imagen_hcra))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_estreg_hcra":
                        #region HCL_ESTREG_HCRA: Estado registro
                        lcrNombreCampo = "Estado registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Hcl_estreg_hcra))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_estreg_hcra, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        llgValidDefault = true;
                        break;
                }
                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
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
        public override String fcrValidacionRel(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Hcl_codreg_hcca":
                        #region HCL_CODREG_HCCA: Tipo registro actividad
                        lcrNombreCampo = "Tipo registro actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Hcl_codreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Convertir Texto a Mayuscula
                            G2Hcl_codreg_hcca = G2Hcl_codreg_hcca.ToUpper();
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(G2Hcl_codreg_hcca);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.hcl_secreg_hcca))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G2Hcl_secreg_hcca != tmp.hcl_secreg_hcca) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_desreg_hcca":
                        #region HCL_DESREG_HCCA: Descripcion tipo registro
                        lcrNombreCampo = "Descripcion tipo registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Hcl_desreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Grp_idepla_grpl":
                        #region GRP_IDEPLA_GRPL: Código único plantilla
                        lcrNombreCampo = "Código único plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (String.IsNullOrWhiteSpace(G2Grp_idepla_grpl))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(G2Grp_idepla_grpl);
                            if (tmp != null)
                            {
                                G2Grp_despla_grpl = tmp.grp_despla_grpl;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sys_codtip_sytm":
                        #region SYS_CODTIP_SYTM: Tipo de mensajes sistema
                        lcrNombreCampo = "Tipo de mensajes sistema";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Sys_codtip_sytm))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Convertir a Mayusculas
                            G2Sys_codtip_sytm = G2Sys_codtip_sytm.ToUpper();
                            if (G2Sys_codtip_sytm == "NA")
                            {
                                G2Sys_desmsj_sytm = "No asignado";
                            }
                            else
                            {
                                var tmp = SYSValidarCodigo.fobRegBuscarSysadmstipomens(G2Sys_codtip_sytm);
                                if (tmp != null)
                                {
                                    G2Sys_desmsj_sytm = tmp.sys_desmsj_sytm;
                                }
                            }

                        }
                        break;
                        #endregion

                    case "G2Hcl_imagen_hcca":
                        #region HCL_IMAGEN_HCCA: Imagen (jpg)
                        lcrNombreCampo = "Imagen (jpg)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Hcl_imagen_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Hcl_icolor_hcca":
                        #region HCL_ICOLOR_HCCA: Color fondo HC
                        lcrNombreCampo = "Color fondo HC";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Hcl_icolor_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Hcl_rutarc_hcca":
                        #region HCL_RUTARC_HCCA: Ruta archivos
                        lcrNombreCampo = "Ruta archivos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B09";
                        if (String.IsNullOrWhiteSpace(G2Hcl_rutarc_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Hcl_ordvis_hcca":
                        #region HCL_ORDVIS_HCCA: Orden visualizacion
                        lcrNombreCampo = "Orden visualizacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        if (G2Hcl_ordvis_hcca <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Hcl_psubgr_hcca":
                        #region HCL_PSUBGR_HCCA: Primer reg subgrupo
                        lcrNombreCampo = "Primer reg subgrupo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B11";
                        if (String.IsNullOrWhiteSpace(G2Hcl_psubgr_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_psubgr_hcca, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_mededi_hcca":
                        #region HCL_MEDEDI_HCCA: Medida edad Inicial
                        lcrNombreCampo = "Medida edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (String.IsNullOrWhiteSpace(G2Hcl_mededi_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_mededi_hcca, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_edaini_hcca":
                        #region HCL_EDAINI_HCCA: Edad Inicial
                        lcrNombreCampo = "Edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";
                        if (G2Hcl_edaini_hcca <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Hcl_edaini_hcca < 0 || G2Hcl_edaini_hcca > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_mededf_hcca":
                        #region HCL_MEDEDF_HCCA: Medida edad final
                        lcrNombreCampo = "Medida edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B14";
                        if (String.IsNullOrWhiteSpace(G2Hcl_mededf_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_mededf_hcca, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_edafin_hcca":
                        #region HCL_EDAFIN_HCCA: Edad final
                        lcrNombreCampo = "Edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B15";
                        if (G2Hcl_edafin_hcca <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Hcl_edafin_hcca < 0 || G2Hcl_edafin_hcca > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_sexapl_hcca":
                        #region HCL_SEXAPL_HCCA: Sexo que aplica
                        lcrNombreCampo = "Sexo que aplica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B16";
                        if (String.IsNullOrWhiteSpace(G2Hcl_sexapl_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_sexapl_hcca, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_mededl_hcca":
                        #region HCL_MEDEDL_HCCA: Medida edad lista
                        lcrNombreCampo = "Medida edad lista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B17";
                        if (String.IsNullOrWhiteSpace(G2Hcl_mededl_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_mededl_hcca, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_listar_hcca":
                        #region HCL_LISTAR_HCCA: Lista rango edades
                        lcrNombreCampo = "Lista rango edades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B18";
                        /*
                        if (String.IsNullOrWhiteSpace(G2Hcl_listar_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        */
                        break;
                        #endregion

                    case "G2Hcl_estreg_hcca":
                        #region HCL_ESTREG_HCCA: Estado registro
                        lcrNombreCampo = "Estado registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B19";
                        if (String.IsNullOrWhiteSpace(G2Hcl_estreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_estreg_hcca, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
   
    }
}
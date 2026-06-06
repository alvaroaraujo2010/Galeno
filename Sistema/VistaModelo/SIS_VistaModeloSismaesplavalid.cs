//- MARMOTA-GENCODE: VERSION 2.0 - 06/10/2014 05:17:31 PM
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

namespace Sistema.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sismaesplavalid</para>
    /// <para>DESCRIPCION:
    ///  Maestro de plantillas para configurar validacion personalizada
    ///  de archivos tales como: Archivos Rips  Archivo Resolución 4505
    ///  y otros.
    /// </para>
    /// </summary>
    public class VistaModeloSismaesplavalid : VistaModeloSismaesplavalidBase
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
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
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
                    case "G1Sis_codarc_siar":
                        lcrNombreCampo = "Identificador archivos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sis_codarc_siar))
                        {
                            lcrValorReturn = "Identificador archivos: Es requerido";
                        }
                        else
                        {
                            EFsistipoarchivos tmp = new EFsistipoarchivos();
                            tmp = SISValidarCodigo.fobRegBuscarSistipoarchivos(G1Sis_codarc_siar);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codarc_siar))
                            {
                                G1Sis_desarc_siar = tmp.sis_desarc_siar;
                            }
                            else
                            {
                                lcrValorReturn = "Identificador archivos: No existe";
                            }
                        }
                        break;

                    case "G1Sis_despla_siva":
                        lcrNombreCampo = "Descripción  plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sis_despla_siva))
                        {
                            lcrValorReturn = "Descripción  plantilla: Es requerido";
                        }
                        break;

                    case "G1Sis_tippla_siva":
                        lcrNombreCampo = "Tipo plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (string.IsNullOrWhiteSpace(G1Sis_tippla_siva))
                        {
                            lcrValorReturn = "Tipo plantilla: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_tippla_siva, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo plantilla: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sis_estreg_siva":
                        lcrNombreCampo = "Estado plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (string.IsNullOrWhiteSpace(G1Sis_estreg_siva))
                        {
                            lcrValorReturn = "Estado plantilla: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_estreg_siva, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado plantilla: Dato no es valido";
                            }
                        }
                        break;

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
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
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
                    case "G2Sis_codcam_sivd":
                        lcrNombreCampo = "Nombre unico campo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (string.IsNullOrWhiteSpace(G2Sis_codcam_sivd))
                        {
                            lcrValorReturn = "Nombre unico campo: Es requerido";
                        }
                        else
                        {
                            G2Sis_codcam_sivd = G2Sis_codcam_sivd.ToUpper();
                        }
                        break;

                    case "G2Sis_nomcam_sivd":
                        lcrNombreCampo = "Titulo o Etiqueta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (string.IsNullOrWhiteSpace(G2Sis_nomcam_sivd))
                        {
                            lcrValorReturn = "Titulo o Etiqueta: Es requerido";
                        }
                        else
                        {
                            if (G2Sis_nomcam_sivd.Length < 8)
                            {
                                lcrValorReturn = "Titulo o Etiqueta: debe tener al menos 8 caracteres";
                            }
                        }
                        break;

                    case "G2Sis_ordvis_sivd":
                        lcrNombreCampo = "Orden Vista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (G2Sis_ordvis_sivd < 0)
                        {
                            lcrValorReturn = "Orden Vista: Debe ser mayor que cero";
                        }
                        else if (G2Sis_ordvis_sivd > 118)
                        {
                            lcrValorReturn = "Orden Vista: no puede ser mayor que 118";
                        }
                        break;

                    case "G2Sis_estreg_sivd":
                        lcrNombreCampo = "Estado campo validación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (string.IsNullOrWhiteSpace(G2Sis_estreg_sivd))
                        {
                            lcrValorReturn = "Estado campo validación: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Sis_estreg_sivd, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado campo validación: Dato no es valido";
                            }
                        }
                        break;

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
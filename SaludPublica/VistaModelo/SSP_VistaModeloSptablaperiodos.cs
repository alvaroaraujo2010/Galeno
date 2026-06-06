//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 12:35:45 AM
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
using SaludPublica.Modelo;

namespace SaludPublica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablaperiodos</para>
    /// <para>DESCRIPCION:
    /// Tabla periodos para reportes informe SISPRO 4505
    /// </para>
    /// </summary>
    public class VistaModeloSptablaperiodos : VistaModeloSptablaperiodosBase
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
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Ssp_codper_peri":
                        if (string.IsNullOrWhiteSpace(G1Ssp_codper_peri))
                        {
                            lcrValorReturn = "Código de periodo: Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SSPValidarCodigo.flgBuscarSptablaperiodos(G1Ssp_codper_peri))
                            {
                                lcrValorReturn = "Código de periodo: Ya existe en Base de Datos";
                            }
                        }
                        break;

                    case "G1Ssp_desper_peri":
                        if (string.IsNullOrWhiteSpace(G1Ssp_desper_peri))
                        {
                            lcrValorReturn = "Descripción periodo: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_mesper_peri":
                        if (string.IsNullOrWhiteSpace(G1Ssp_mesper_peri))
                        {
                            lcrValorReturn = "Mes del periodo: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_anoper_peri":
                        if (string.IsNullOrWhiteSpace(G1Ssp_anoper_peri))
                        {
                            lcrValorReturn = "Año del periodo: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_fecini_peri":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_fecini_peri, "Fecha de inicio del periodo");
                        break;

                    case "G1Ssp_fecfin_peri":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_fecfin_peri, "Fecha de fin del periodo");
                        break;

                    case "G1Ssp_estper_peri":
                        if (string.IsNullOrWhiteSpace(G1Ssp_estper_peri))
                        {
                            lcrValorReturn = "Estado del periodo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_estper_peri, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado del periodo: Dato no es valido";
                            }
                        }
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
    }
}
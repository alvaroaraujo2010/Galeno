//- MARMOTA-GENCODE: VERSION 2.0 - 16/04/2014 10:01:47 AM
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
    /// <para>TABLA: sptabcampos4505</para>
    /// <para>DESCRIPCION:
    /// Lista de campos de la Tabla RES4505 (Resoluión 4505)
    /// </para>
    /// </summary>
    public class VistaModeloSptabcampos4505 : VistaModeloSptabcampos4505Base
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
                    case "G1Ssp_codcam_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_codcam_resc))
                        {
                            lcrValorReturn = "Código Campo: Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SSPValidarCodigo.flgBuscarSptabcampos4505(G1Ssp_codcam_resc))
                            {
                                lcrValorReturn = "Código Campo: Ya existe en Base de Datos";
                            }
                        }
                        break;

                    case "G1Ssp_nomcam_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_nomcam_resc))
                        {
                            lcrValorReturn = "Titulo o Etiqueta: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_ordvis_resc":
                        if (G1Ssp_ordvis_resc < 0)
                        {
                            lcrValorReturn = "Orden Vista: Es requerido";
                        }
                        break;

                    case "G1Ssp_descam_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_descam_resc))
                        {
                            lcrValorReturn = "Descripción: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_tipval_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_tipval_resc))
                        {
                            lcrValorReturn = "Tipo de Valor: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_tipval_resc, ",", "D,C,N"))
                            {
                                lcrValorReturn = "Tipo de Valor: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_valper_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_valper_resc))
                        {
                            lcrValorReturn = "Valor Permitido: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_camdig_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_camdig_resc))
                        {
                            lcrValorReturn = "Campo digitable: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_camdig_resc, ",", "1,2"))
                            {
                                lcrValorReturn = "Campo digitable: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_ranini_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_ranini_resc))
                        {
                            lcrValorReturn = "Rango inicial: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_ranfin_resc":
                        if (string.IsNullOrWhiteSpace(G1Ssp_ranfin_resc))
                        {
                            lcrValorReturn = "Rango final: Es requerido";
                        }
                        else
                        {
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
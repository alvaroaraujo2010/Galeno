//- MARMOTA-GENCODE: VERSION 2.0 - 26/08/2013 09:22:06 PM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siacopagcontrib</para>
    /// <para>DESCRIPCION:
    ///  Porcentajes  para cobro de copagos y cuotas moderadoras en
    ///  contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
    ///  260 de 2004, se crearan rangos para cada tipo poblacion especial
    /// </para>
    /// </summary>
    public class VistaModeloSiacopagcontrib : VistaModeloSiacopagcontribBase
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
                    case "G1Sia_codcpo_cpcb":
                        if (string.IsNullOrWhiteSpace(G1Sia_codcpo_cpcb))
                        {
                            lcrValorReturn = "Código rango: Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SIAValidarCodigo.flgBuscarSiacopagcontrib(G1Sia_codcpo_cpcb))
                            {
                                lcrValorReturn = "Código rango: Ya existe en Base de Datos";
                            }
                        }
                        break;

                    case "G1Sia_descpo_cpcb":
                        if (string.IsNullOrWhiteSpace(G1Sia_descpo_cpcb))
                        {
                            lcrValorReturn = "Descripción rango: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sia_tipafi_tafi":
                        if (string.IsNullOrWhiteSpace(G1Sia_tipafi_tafi))
                        {
                            lcrValorReturn = "Tipo Afiliado Contributivo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipafi_tafi, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Tipo Afiliado Contributivo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sia_nivcon_ncon":
                        if (string.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                        {
                            lcrValorReturn = "Nivel Contributivo: Es requerido";
                        }
                        else
                        {
                            EFsianivcontribut tmp = new EFsianivcontribut();
                            tmp = SIAValidarCodigo.fobRegBuscarSianivcontribut(G1Sia_nivcon_ncon);
                            if (tmp != null)
                            {
                                G1Sia_descon_ncon = tmp.sia_descon_ncon;
                            }
                            else
                            {
                                lcrValorReturn = "Nivel Contributivo: No existe";
                            }
                        }
                        break;

                    case "G1Sia_tipcob_cpcb":
                        if (string.IsNullOrWhiteSpace(G1Sia_tipcob_cpcb))
                        {
                            lcrValorReturn = "Tipo de Cobro: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipcob_cpcb, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo de Cobro: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sia_porapl_cpsb":
                        if (G1Sia_porapl_cpsb < 0)
                        {
                            lcrValorReturn = "Porcentaje de cobro: Debe ser mayor o igual que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sia_tippor_cpsb":
                        if (string.IsNullOrWhiteSpace(G1Sia_tippor_cpsb))
                        {
                            lcrValorReturn = "Tipo Porcentaje aplicación: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tippor_cpsb, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Tipo Porcentaje aplicación: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sia_maxeve_cpsb":
                        if (G1Sia_maxeve_cpsb < 0)
                        {
                            lcrValorReturn = "Máximo Porcentaje evento: Debe ser mayor o igual que cero";
                        }
                        else
                        {
                            if (G1Sia_maxeve_cpsb < 0 || G1Sia_maxeve_cpsb > 700)
                            {
                                lcrValorReturn = "Máximo Porcentaje evento: Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Sia_maxano_cpsb":
                        if (G1Sia_maxano_cpsb < 0)
                        {
                            lcrValorReturn = "Máximo Porcentaje año: Debe ser mayor o igual que cero";
                        }
                        else
                        {
                            if (G1Sia_maxano_cpsb < 0 || G1Sia_maxano_cpsb > 700)
                            {
                                lcrValorReturn = "Máximo Porcentaje año: Valor fuera del rango";
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
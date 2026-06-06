//- MARMOTA-GENCODE: VERSION 2.0 - 21/08/2017 03:40:45 PM
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
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invalmacexisten</para>
    /// <para>DESCRIPCION:
    ///  Detalles existencias totales en tiempo real por cada articulo
    ///  en un almacen, sin tener presente Lotes/Referencias
    /// </para>
    /// </summary>
    public class VistaModeloInvVistalmacen : VistaModeloInvVistalmacenBase
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
        //public override String fcrValidacion(String tcrNombrePropiedad)
        //{
        //    String lcrValorReturn = String.Empty;
        //    String lcrNumeroRegistro = "USUARIO";
        //    String lcrCodigoError = String.Empty;
        //    String lcrNombreCampo = String.Empty;
        //    String lcrNivelError = "ALTO";
        //    String lcrImgNivelError = "Edt_hist_vista_anulado.png";

        //    //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

        //    try
        //    {
        //        switch (tcrNombrePropiedad)
        //        {


        //        }
        //        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
        //                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
        //    }
        //    catch (NotImplementedException ex)
        //    {
        //        MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
        //    }
        //    return lcrValorReturn;
        //}
        #endregion
    }
}
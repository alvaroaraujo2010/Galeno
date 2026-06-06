//- MARMOTA-GENCODE: VERSION 2.0 - 18/09/2014 09:50:18 PM
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
using ContratoAseguramiento.Modelo;

namespace ContratoAseguramiento.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablmsres4505</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion RES4505
    /// </para>
    /// </summary>
    public class VistaModeloCargarbasededatos : VistaModeloCargarbasededatosBase
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
         public override string fcrValidacion(String tcrNombrePropiedad)
        {
        	String lcrValorReturn = string.Empty;
        	String lcrNumeroRegistro = "USUARIO";
        	String lcrCodigoError = String.Empty;
        	String lcrNombreCampo = String.Empty;
        	String lcrNivelError = "ALTO";
        	String lcrImgNivelError = "Edt_hist_vista_anulado.png";
        	bool llgValidDefault = false;

            try
            {
        		switch (tcrNombrePropiedad)
                {
                    case "G1Sis_secreg_siva":

                        lcrNombreCampo = "Codigo plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Sis_secreg_siva))
                        {
                            lcrValorReturn = "Codigo plantilla: Es requerido";
                        }
                        else
                        {
                            EFsismaesplavalid tmp = new EFsismaesplavalid();
                            tmp = SISValidarCodigo.fobRegBuscarSismaesplavalid(G1Sis_secreg_siva);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_secreg_siva))
                            {
                                G1Sis_despla_siva = tmp.sis_despla_siva;
                            }
                            else
                            {
                                lcrValorReturn = "Codigo plantilla: No existe";
                            }
                        }
                        break;

                    case "G1Cto_seccon_cont":
                        
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (string.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = "Secuencial de Contrato: Es requerido";
                        }
                        else
                        {
                            EFctomaescontrato tmp = new EFctomaescontrato();
                            tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
                            {
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Cto_descon_cont = tmp.cto_descon_cont;
                                G1Sia_codeps_teps = tmp.sia_codeps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codeps_teps":
                        
                        lcrNombreCampo = "Código EPS desde archivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            EFsiatablaeps tmp = new EFsiatablaeps();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
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
         // fcvGenerarNombreArchivoDestino: Generar Nombre archivo destino
        //-------------------------------------------------
         #region fcvGenerarNombreArchivoDestino: Generar el nombre del archivo destino
         /// <summary>
         /// <para>Generar el nombre del archivo destino</para>
         /// </summary>
         private void fcvGenerarNombreArchivoDestino()
         {
             /*
             if (!String.IsNullOrWhiteSpace(G1Ssp_fecfin_peri))
             {
                 var lcrAño = Funciones.fcrElementoFecha("AÑO", "DMY", "/", G1Ssp_fecfin_peri);
                 var lcrMes = Funciones.fcrElementoFecha("MES", "DMY", "/", G1Ssp_fecfin_peri);
                 var lcrDia = Funciones.fcrElementoFecha("DIA", "DMY", "/", G1Ssp_fecfin_peri);

                 G1ArchivoDestino = "SGD280RPED" + lcrAño + lcrMes + lcrDia + "NI" + G1Ssp_nitips_sscf + G1Ssp_regims_sgss + "01";
             }
             */
         }
         #endregion
    }
}
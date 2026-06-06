//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2014 09:42:29 AM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysperfiusuario</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestra para registrar perfiles de usuarios que creados
    ///  para gestión de datos en el sistema ejm: P01 =Súper Usuario
    ///  P02=Administrador  P03=Facturadores P04=Regente de farmacia
    /// </para>
    /// </summary>
    public class VistaModeloSysperfiusuario : VistaModeloSysperfiusuarioBase
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
                    case "G1Sys_desper_perf":
                        if (string.IsNullOrWhiteSpace(G1Sys_desper_perf))
                        {
                            lcrValorReturn = "Nombre del Perfil: Es requerido";
                        }
                        else
                        {
                            G1Sys_desper_perf = G1Sys_desper_perf.ToUpper();
                        }
                        break;

                    case "G1Sys_rutimg_perf":
                        if (string.IsNullOrWhiteSpace(G1Sys_rutimg_perf))
                        {
                            lcrValorReturn = "Imagen de  Vista: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_nivusu_perf":
                        if (string.IsNullOrWhiteSpace(G1Sys_nivusu_perf))
                        {
                            lcrValorReturn = "Nivel del Usuario: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_nivusu_perf, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Nivel del Usuario: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_estper_perf":
                        if (string.IsNullOrWhiteSpace(G1Sys_estper_perf))
                        {
                            lcrValorReturn = "Estado del perfil: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_estper_perf, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado del perfil: Dato no es valido";
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

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Sys_codcom_comd":
                        if (string.IsNullOrWhiteSpace(G2Sys_codcom_comd))
                        {
                            lcrValorReturn = "Código asignación en Módulo: Es requerido";
                        }
                        else
                        {
                            EFsyscompmodulos tmp = new EFsyscompmodulos();
                            tmp = SYSValidarCodigo.fobRegBuscarSyscompmodulos(G2Sys_codcom_comd);
                            if (tmp != null)
                            {
                                G2Sys_codmod_modu = tmp.sys_codmod_modu;
                                G2Sys_codcom_comp = tmp.sys_codcom_comp;
                                G2Sys_prmetr_comp = tmp.sys_prmetr_comp;
                            }
                            else
                            {
                                lcrValorReturn = "Código asignación en Módulo: No existe";
                            }
                        }
                        break;

                    case "G2Sys_codmod_modu":
                        if (string.IsNullOrWhiteSpace(G2Sys_codmod_modu))
                        {
                            lcrValorReturn = "Código Módulo: Es requerido";
                        }
                        else
                        {
                            EFsysmodulosistem tmp = new EFsysmodulosistem();
                            tmp = SYSValidarCodigo.fobRegBuscarSysmodulosistem(G2Sys_codmod_modu);
                            if (tmp != null)
                            {
                                G2Sys_nommod_modu = tmp.sys_nommod_modu;
                            }
                            else
                            {
                                lcrValorReturn = "Código Módulo: No existe";
                            }
                        }
                        break;

                    case "G2Sys_llavco_cper":
                        if (string.IsNullOrWhiteSpace(G2Sys_llavco_cper))
                        {
                            lcrValorReturn = "Llave verificación: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G2Sys_codcom_comp":
                        if (string.IsNullOrWhiteSpace(G2Sys_codcom_comp))
                        {
                            lcrValorReturn = "Código componente: Es requerido";
                        }
                        else
                        {
                            EFsyscomponentes tmp = new EFsyscomponentes();
                            tmp = SYSValidarCodigo.fobRegBuscarSyscomponentes(G2Sys_codcom_comp);
                            if (tmp != null)
                            {
                                G2Sys_titcom_comp = tmp.sys_titcom_comp;
                                G2Sys_prmetr_comp = tmp.sys_prmetr_comp;
                            }
                            else
                            {
                                lcrValorReturn = "Código componente: No existe";
                            }
                        }
                        break;

                    case "G2Sys_prmetr_comp":
                        if (string.IsNullOrWhiteSpace(G2Sys_prmetr_comp))
                        {
                            lcrValorReturn = "Parámetros: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G2Sys_estccp_cper":
                        if (string.IsNullOrWhiteSpace(G2Sys_estccp_cper))
                        {
                            lcrValorReturn = "Estado componente: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Sys_estccp_cper, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado componente: Dato no es valido";
                            }
                        }
                        break;

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
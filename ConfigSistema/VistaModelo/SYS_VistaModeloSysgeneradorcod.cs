//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2014 07:49:08 AM
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
    /// <para>TABLA: sysgeneradorcod</para>
    /// <para>DESCRIPCION:
    ///  Tabla del sistema donde se almacenan los secuenciales generados,
    ///  se agrupan según el módulo al cual pertenecen
    /// </para>
    /// </summary>
    public class VistaModeloSysgeneradorcod : VistaModeloSysgeneradorcodBase
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
                    case "G1Sys_codsec_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_codsec_gcod))
                        {
                            lcrValorReturn = "llave  Registro: Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SYSValidarCodigo.flgBuscarSysgeneradorcod(G1Sys_codsec_gcod))
                            {
                                lcrValorReturn = "llave  Registro: Ya existe en Base de Datos";
                            }
                        }
                        break;

                    case "G1Sys_codmod_modu":
                        if (string.IsNullOrWhiteSpace(G1Sys_codmod_modu))
                        {
                            lcrValorReturn = "Código Módulo: Es requerido";
                        }
                        else
                        {
                            EFsysmodulosistem tmp = new EFsysmodulosistem();
                            tmp = SYSValidarCodigo.fobRegBuscarSysmodulosistem(G1Sys_codmod_modu);
                            if (tmp != null)
                            {
                                G1Sys_nommod_modu = tmp.sys_nommod_modu;
                            }
                            else
                            {
                                lcrValorReturn = "Código Módulo: No existe";
                            }
                        }
                        break;

                    case "G1Sys_dessec_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_dessec_gcod))
                        {
                            lcrValorReturn = "Nombre Secuencial: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_ultsec_gcod":
                        if (G1Sys_ultsec_gcod <= 0)
                        {
                            lcrValorReturn = "Último Sec Generado: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_inisec_gcod":
                        if (G1Sys_inisec_gcod <= 0)
                        {
                            lcrValorReturn = "Número Sec Inicial: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_finsec_gcod":
                        if (G1Sys_finsec_gcod <= 0)
                        {
                            lcrValorReturn = "Número Sec Final: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_maxsec_gcod":
                        if (G1Sys_maxsec_gcod <= 0)
                        {
                            lcrValorReturn = "Tamaño Secuencial: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_alrsec_gcod":
                        if (G1Sys_alrsec_gcod <= 0)
                        {
                            lcrValorReturn = "Limite Sec Alarma: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Sys_relcer_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_relcer_gcod))
                        {
                            lcrValorReturn = "Rellenar con Ceros: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_relcer_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Rellenar con Ceros: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_prefij_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_prefij_gcod))
                        {
                            lcrValorReturn = "Prefijo: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    //case "G1Sys_sufijo_gcod":
                    //    if (string.IsNullOrWhiteSpace(G1Sys_sufijo_gcod))
                    //    {
                    //        lcrValorReturn = "Sufijo: Es requerido";
                    //    }
                    //    else
                    //    {
                    //    }
                    //    break;

                    case "G1Sys_incfec_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_incfec_gcod))
                        {
                            lcrValorReturn = "Incluir datos Fecha: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_incfec_gcod, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Incluir datos Fecha: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_locfec_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_locfec_gcod))
                        {
                            lcrValorReturn = "Localización: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_locfec_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Localización: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_forfec_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_forfec_gcod))
                        {
                            lcrValorReturn = "Formato de Fecha: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_forfec_gcod, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Formato de Fecha: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_incdia_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_incdia_gcod))
                        {
                            lcrValorReturn = "Incluir Día: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_incdia_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Incluir Día: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_incmes_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_incmes_gcod))
                        {
                            lcrValorReturn = "Incluir Mes: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_incmes_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Incluir Mes: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_incano_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_incano_gcod))
                        {
                            lcrValorReturn = "Incluir Año: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_incano_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Incluir Año: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sys_nivacc_gcod":
                        if (string.IsNullOrWhiteSpace(G1Sys_nivacc_gcod))
                        {
                            lcrValorReturn = "Nivel de acceso: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_nivacc_gcod, ",", "1,2"))
                            {
                                lcrValorReturn = "Nivel de acceso: Dato no es valido";
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
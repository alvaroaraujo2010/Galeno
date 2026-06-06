using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;

namespace Sistema.Validacion
{
    //---------------------------------------------------------------
    // INTERFACES PARA VALIDACION 
    //---------------------------------------------------------------
    #region IValidador4505: Interface para ejecutar validación Resolucion 4505
    /// <summary>
    /// <para>Interface para ejecutar validación Resolucion 4505</para>
    /// </summary>
    public interface IValidador4505
    {
        void EjecutarValidCampo(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, 
                                int tnuNumeroRegistro, ParamValid4505 tobParam);
    }
    #endregion
    #region IValidadorMS: Interface para ejecutar validación Maestro subsidiado 1344 y 812
    /// <summary>
    /// <para>Interface para ejecutar validación Maestro subsidiado 1344 y 812</para>
    /// </summary>
    public interface IValidadorMS
    {
        void EjecutarValidCampo(IRegistroError tobIRegistroError, ModeloCtomaestroafiliadosEx tobRegistro,
                                int tnuNumeroRegistro, ParamValidMS tobParam);
    }
    #endregion
    #region IRegistroError: Interface para registrar errores en validación
    /// <summary>
    /// <para>Interface para registrar errores en validación</para>
    /// </summary>
    public interface IRegistroError
    {
        void AddRegistroError(String tcrCodigoError, String tcrMensaje, int tnuNumeroRegistro, 
                              int tcrNumeroCampo, String tcrTituloCampo, String tcrValorCampo, String tcrNivelError);
    }
    #endregion
    //---------------------------------------------------------------
    // INTERFACES PARA EJECUTAR CONSULTAS DESDE CODIGO FUENTE
    //---------------------------------------------------------------
    #region IEjecutarConsulta: Interface para ejecutar las consultas compiladas
    /// <summary>
    /// <para>Interface para ejecutar las consultas compiladas codigo fuente</para>
    /// <para>Devuelve un temporal con los datos generados</para>
    /// </summary>
    public interface IEjecutarConsulta
    {
        List<ClasseTmpResumen> flsEjecutarConsulta(DateTime ldaFechaIni, DateTime ldaFechaFin);
    }
    #endregion
    //---------------------------------------------------------------
    // INTERFACES PARA EJECUTAR CONSULTAS DESDE CODIGO FUENTE
    //---------------------------------------------------------------
    #region fcrEjecutarCodigoFuente: Interface para ejecutar codigo fuente de cada plantilla en modo captura
    /// <summary>
    /// <para>Interface para ejecutar codigo fuente de cada plantilla en modo captura</para>
    /// </summary>
    public interface IEjecutarCodigoFuente
    {
        void fcrEjecutarCodigoFuente(Window tobWind, String tcrCodigoPlantilla, 
                                                                ref List<LogsErrores> tmpLogErrores,
                                                                ref List<ClassXmlPropObjeto> tmpObjetos,
                                                                ref List<ClassXmlPropDatos> tmpObDatos);
    }
    #endregion
}

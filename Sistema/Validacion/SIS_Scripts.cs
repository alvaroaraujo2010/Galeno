using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;

namespace Sistema.Validacion
{
    //---------------------------------------------------------------
    // FUNCIONES PARA COMPILACION 
    //---------------------------------------------------------------
    #region Compilador: Clase funciones para ejecutar el compliador
    /// <summary>
    /// <para>Clase funciones para ejecutar el compliador</para>
    /// </summary>
    public static class Compilador
    {
        #region fobCompilarEnsamblado: Compila la lista de codigo fuente en una dll en memoria
        /// <summary>
        /// Compila la lista de codigo fuente en una dll en memoria
        /// </summary>
        /// <param name="tcrLanguage">Lenguaje : "C#" "CSharp".</param>
        /// <param name="tarCodigoFuente">Lista de archivos de codigo fuente a compilar.</param>
        /// <returns>Retorna un objeto tipo: CompilerResults</returns>
        public static CompilerResults fobCompilarEnsamblado(String tcrLanguage, String tarCodigoFuente, List<String> tarReferences)
        {
            //var codeProvider = new CSharpCodeProvider();
            CodeDomProvider lobCodeProvider = CodeDomProvider.CreateProvider(tcrLanguage);

            var lobParameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false,
            };

            //Agregar las referencias
            foreach (String reference in tarReferences)
            {
                lobParameters.ReferencedAssemblies.Add(reference);
            }
            // Agregrar la localizacion del proyecto
            lobParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            var lobResult = lobCodeProvider.CompileAssemblyFromSource(lobParameters, tarCodigoFuente); // Compile

            return lobResult;
        }
        #endregion
        #region farGetTypesInterface: Devuelve todos los tipos que implementan la interfaz especificada
        /// <summary>
        /// Devuelve todos los tipos que implementan la interfaz especificada.
        /// </summary>
        /// <param name="tobEnsamblado">Ensamblado para la busqueda.</param>
        /// <param name="tobInterfaceType">Tipo de iterfaz que los tipos deben implementar.</param>
        /// <returns>Retorna una lista del tipo: interfaceType</returns>
        public static List<Type> farGetTypesInterface(Assembly tobEnsamblado, Type tobInterfaceType)
        {
            if (!tobInterfaceType.IsInterface) throw new ArgumentException("no es una interface.", "interfaceType");

            return tobEnsamblado.GetTypes().Where(t => tobInterfaceType.IsAssignableFrom(t)).ToList();
        }
        #endregion
    }
    #endregion
    //---------------------------------------------------------------
    // FUNCIONES PARA UTILIDADES PARA VALIDACION
    //---------------------------------------------------------------
    #region Validacion: clase para funciones utilidades de validacion
    /// <summary>
    /// <para>clase para funciones utilidades de validacion</para>
    /// </summary>
    public static class Validacion
    {
        #region flgValidCampoFecha: Validar datos relacionados tipo fecha
        /// <summary>
        /// <para>Validar datos relacionados tipo fecha para RIPS, RE4505 y otros</para>
        /// </summary>
        public static bool flgValidCampoFecha(String tcrNombreCampo, String tcrValor, String tcrFormato, String tcrSeparador)
        {
            var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tcrNombreCampo);
            var lcrValorReturn = true;
            // tcrValor ------------------------ ojo falta verificar que tenga formato DMY para la funcion flgValidarRangoFecha

            if (!String.IsNullOrWhiteSpace(lcrCampo.sis_ranini_siac) && !String.IsNullOrWhiteSpace(lcrCampo.sis_ranfin_siac))
            {
                if (!Funciones.flgValidarRangoFecha(tcrValor, lcrCampo.sis_ranini_siac, lcrCampo.sis_ranfin_siac))
                {
                    // Es posible que este en valores permitidos
                    if (!Funciones.flgExisteElemento(tcrValor, ",", lcrCampo.sis_valper_siac))
                    {
                        lcrValorReturn = false;
                    }
                }
            }
            else if (!String.IsNullOrWhiteSpace(lcrCampo.sis_valper_siac))
            {
                if (!Funciones.flgExisteElemento(tcrValor, ",", lcrCampo.sis_valper_siac))
                {
                    lcrValorReturn = false;
                }
            }
            return lcrValorReturn;
        }
        #endregion
    }
    #endregion
}

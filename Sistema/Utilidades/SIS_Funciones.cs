using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Markup;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class Funciones
    {
        //------------------------------------------------------------
        // fcrRemplazarChrDecimal(): Reemplazar el separador decimal
        //------------------------------------------------------------
        #region fcrRemplazarChrDecimal: Reemplazar el separador decimal
        /// <summary>
        /// <para>Reemplazar el separador decimal por el que esta en configuracion regional del PC</para>
        /// <returns>Devuelve  tcrValorDecimal con el el mismo valor, pero cambiando el separador 
        /// decimal por el correcto segun configuracion regional del PC</returns>
        /// </summary>
        public static String fcrRemplazarChrDecimal(String tcrValorDecimal)
        {
            var lcrSeparador = fcrLeerConfiguracionRegional("DECIMAL");

            return fcrRemplazarChrDecimal(tcrValorDecimal, lcrSeparador);
        }
        /// <summary>
        /// <para>Reemplazar el separador decimal por el que esta en configuracion regional del PC</para>
        /// <returns>Devuelve  tcrValorDecimal con el el mismo valor, pero cambiando el separador 
        /// decimal por el correcto segun configuracion regional del PC</returns>
        /// </summary>
        public static String fcrRemplazarChrDecimal(String tcrValorDecimal, String tcrSeparadorDecimal)
        {
            var lcrDato = String.Empty;
            if (tcrValorDecimal != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValorDecimal))
                {
                    tcrValorDecimal = tcrValorDecimal.Replace(".", tcrSeparadorDecimal);
                    tcrValorDecimal = tcrValorDecimal.Replace(",", tcrSeparadorDecimal);
                    lcrDato = tcrValorDecimal;
                }
            }
            return lcrDato;
        }
        #endregion
        //------------------------------------------------------------
        // fcrNotNull(): devolver texto texto segun valor null
        //------------------------------------------------------------
        #region fcrNotNull(): devolver la subcadena de texto
        /// <summary>
        /// <para>fcrNotNull()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Funcion para devolver texto segun parametro tcrValor</para>
        /// <para>cuando tcrValor es null devuelve el texto dado en tcrValorDefault</para>
        /// </summary>
        public static String fcrNotNull(String tcrValor, String tcrValorDefault)
        {
            var lcrValor = tcrValor != null ? tcrValor : tcrValorDefault;
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fuxExtraerElemento():devolver la subcadena de texto
        //------------------------------------------------------------
        #region fuxExtraerElemento(): devolver la subcadena de texto
        /// <summary>
        /// <para>fuxExtraerElemento()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Funcion para devolver la subcadena de texto de la lista string</para>
        /// <para>separada por coma (,) segun la posicion dada en el parametro tcrPosElemento</para>
        /// <para>PARAMETROS:</para>
        /// <para>tnuPosElemento: Posicion del elemento en la cadena string tipo (int)</para>
        /// <para>tcrListaString: Cadena string que contiene elementos separados por caracter tcrSeparador</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve el elemento en la posicion dada, cuando no
        /// existe elemento en la posicion o la lista esta vacia devuelve string vacia.</returns>
        /// </summary>
        public static string fuxExtraerElemento(int tnuPosElemento, string tcrSeparador, string tcrListaString) 
        {
            String lcrValor = string.Empty;
            char[] lcrCharSeparador = tcrSeparador.ToCharArray();
            String[] larArray = tcrListaString.Split(lcrCharSeparador);
            if (larArray.Length >= tnuPosElemento && tnuPosElemento > -1)
            {
                lcrValor = larArray[tnuPosElemento - 1];
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuDevolverPosElemento(): devolver posición elemento
        //------------------------------------------------------------
        #region fnuDevolverPosElemento(): devolver posición elemento
        /// <summary>
        /// <para>fnuDevolverPosElemento()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Funcion para devolver posicion del elemento dentro de la lista string</para>
        /// <para>separada por caracter dado en parametro tcrSeparador</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrElemento: Nombre del elemento a buscar en la cadena (tipo string)</para>
        /// <para>tcrListaString: Cadena string que contiene elementos separados por coma (,)</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve cero cuando no existe elemento en la lista o lista esta vacia.</returns>
        /// </summary>
        public static int fnuDevolverPosElemento(string tcrElemento, string tcrSeparador, string tcrListaString)
        {
            int lnuValor = 0;
            int i;

            if (tcrListaString != null)
            {
                //int lnuTotElemtos = fnuContarElemListaString(tcrSeparador, tcrListaString);
                char[] lcrCharSeparador = tcrSeparador.ToCharArray();
                String[] larArray = tcrListaString.Split(lcrCharSeparador);
                int lnuTotElemtos = larArray.Length;
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if (larArray[i].ToUpper() == tcrElemento.ToUpper() && lnuValor == 0)
                    {
                        lnuValor = i + 1; // es la primera coincidencia
                    }
                }
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuDevPosOcursElemento(): devolver posición ocurrencia elemento
        //------------------------------------------------------------
        #region fnuDevPosOcursElemento(): devolver posición ocurrencia elemento
        /// <summary>
        /// <para>fnuDevPosOcursElemento()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para devolver posicion donde se encuentra el numero de 
        /// la ocurrecina del elemento dentro de la cadena tcrCadenaString,
        /// no distingue mayusculas
        /// <para>PARAMETROS:</para>
        /// <para>tcrElemento:
        /// Nombre del elemento a buscar en la cadena (tipo string)</para>
        /// <para>tnuOcurrencia:
        /// Numero de la ocurencia que se espera encontrar en la cadena</para>
        /// <para>tcrCadenaString:
        /// Cadena string dentro de la cual se realizara la busqueda</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve cero cuando no se encuentra el numero de ocurrencias 
        /// esperadas o la cadena tcrCadenaString esta vacia.</returns>
        /// </summary>
        public static int fnuDevPosOcursElemento(String tcrElemento, int tnuOcurrencia, String tcrCadenaString)
        {
            int lnuOcurrencia = 0;
            int lnuPosicion = 0;
            int i;
            int lnuTotElemtos = tcrCadenaString.Trim().Length;
            int lnuTamElem = tcrElemento.Trim().Length;
            string lcrCadena = tcrCadenaString.Trim().ToUpper();
            string lcrElem = string.Empty;
            for (i = 0; i < lnuTotElemtos; i++)
            {
                if ((i + (lnuTamElem - 1)) < lnuTotElemtos) // Mientras llega a final de la cadena
                {
                    lcrElem = lcrCadena.Substring(i, lnuTamElem);
                    if (lcrElem == tcrElemento.ToUpper() && lnuOcurrencia < tnuOcurrencia)
                    {
                        lnuOcurrencia++; // suma las ocurenicas
                        lnuPosicion = i + 1;
                        if (lnuOcurrencia == tnuOcurrencia) { break; }
                    }
                }
            }
            if (lnuOcurrencia != tnuOcurrencia) { lnuPosicion = 0; } // menos ocurrencias entonces no se cumple
            return lnuPosicion;
        }
        #endregion
        //------------------------------------------------------------
        // flgExisteSubCadenaString(): devolver posición ocurrencia elemento
        //------------------------------------------------------------
        #region flgExisteSubCadenaString(): devolver posición ocurrencia elemento
        /// <summary>
        /// <para>flgExisteSubCadenaString()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devuelve True/False cuando existe o no la subcadena "tcrSubCadena" dentro de  "tcrCadenaString"
        /// no distingue mayusculas
        /// <para>PARAMETROS:</para>
        /// <para>tcrSubCadena:
        /// Nombre subcadena a buscar en la cadena (tipo string) acepta buscar caracter espacio en blanco</para>
        /// <para>tcrCadenaString:
        /// Cadena string dentro de la cual se realizara la busqueda</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve False cuando no se encuentra o la cadena tcrCadenaString esta vacia.</returns>
        /// </summary>
        public static bool flgExisteSubCadenaString(String tcrSubCadena, String tcrCadenaString)
        {
            int lnuOcurrencia = 0;
            var llgReturn = false;
            int i;
            int lnuTotElemtos = tcrCadenaString.Trim().Length;
            int lnuTamElem = !String.IsNullOrWhiteSpace(tcrSubCadena) ? tcrSubCadena.Trim().Length : tcrSubCadena.Length; // es espacios en blanco
            string lcrCadena = tcrCadenaString.Trim().ToUpper();
            string lcrElem = string.Empty;

            if (lnuTamElem > 0) // solo cuando existe uno mas o espacio en blanco
            {
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if ((i + (lnuTamElem - 1)) < lnuTotElemtos) // Mientras llega a final de la cadena
                    {
                        lcrElem = lcrCadena.Substring(i, lnuTamElem);
                        if (lcrElem == tcrSubCadena.ToUpper())
                        {
                            lnuOcurrencia++; // suma las ocurrenicas
                        }
                    }
                    if (lnuOcurrencia != 0) { break; }
                }
            }
            if (lnuOcurrencia != 0) { llgReturn = true; }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // flgExisteSubCadenaStringEx(): devolver posición ocurrencia elemento
        //------------------------------------------------------------
        #region flgExisteSubCadenaStringEx(): devolver posición ocurrencia elemento
        /// <summary>
        /// <para>flgExisteSubCadenaStringEx()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve True/False cuando los elementos de la subcadena "tcrSubCadena" estan contenidos en "tcrCadenaString".</para>
        /// <para>La cadena "tcrSubCadena" se valida como subconjunto de "tcrCadenaString", no distingue mayusculas.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrSubCadena:
        /// Nombre subcadena a buscar en la cadena (tipo string)</para>
        /// <para>tcrCadenaString:
        /// Cadena string dentro de la cual se realizara la busqueda</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve False cuando no se encuentra o la cadena tcrCadenaString esta vacia,</returns>
        /// <returns>los espacios en blanco son ignorados.</returns>
        /// </summary>
        public static bool flgExisteSubCadenaStringEx(String tcrSubCadena, String tcrCadenaString)
        {
            int lnuNoOcurrencia = 0;
            var llgReturn       = false;
            int i;
            int lnuTotElemtos   = tcrSubCadena.Trim().Length;
            string lcrCadena    = tcrSubCadena.Trim().ToUpper();
            string lcrElem      = String.Empty;

            for (i = 0; i < lnuTotElemtos; i++)
            {
                lcrElem = lcrCadena.Substring(i, 1);
                if (!String.IsNullOrWhiteSpace(lcrElem))
                {
                    if (!flgExisteSubCadenaString(lcrElem, tcrCadenaString))
                    {
                        lnuNoOcurrencia++; // suma las no ocurrenicas
                        break;
                    }
                }
            }
            if (lnuNoOcurrencia == 0) { llgReturn = true; }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // flgExisteSubCadenaStringEz(): Valida que algun caracter exista tcrCadenaString
        //------------------------------------------------------------
        #region flgExisteSubCadenaStringEz(): Valida que algun caracter exista tcrCadenaString
        /// <summary>
        /// <para>flgExisteSubCadenaStringEz()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve True cuando alguno de los elementos de la subcadena "tcrSubCadena" estan contenidos en "tcrCadenaString".</para>
        /// <para>La cadena "tcrSubCadena" se valida como subconjunto de "tcrCadenaString", no distingue mayusculas.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrSubCadena:
        /// Nombre subcadena a buscar en la cadena (tipo string)</para>
        /// <para>tcrCadenaString:
        /// Cadena string dentro de la cual se realizara la busqueda</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve False cuando no se encuentra o la cadena tcrCadenaString esta vacia,</returns>
        /// <returns>los espacios en blanco son ignorados.</returns>
        /// </summary>
        public static bool flgExisteSubCadenaStringEz(String tcrSubCadena, String tcrCadenaString)
        {
            int lnuOcurrencia = 0;
            var llgReturn = false;
            int i;
            int lnuTotElemtos = tcrSubCadena.Trim().Length;
            string lcrCadena = tcrSubCadena.Trim().ToUpper();
            string lcrElem = String.Empty;

            for (i = 0; i < lnuTotElemtos; i++)
            {
                lcrElem = lcrCadena.Substring(i, 1);
                if (!String.IsNullOrWhiteSpace(lcrElem))
                {
                    if (flgExisteSubCadenaString(lcrElem, tcrCadenaString))
                    {
                        lnuOcurrencia++; // suma las ocurrenicas
                        break;
                    }
                }
            }
            if (lnuOcurrencia > 0) { llgReturn = true; }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // flgExisteElemento(): Existe el elemento SI/NO en string
        //------------------------------------------------------------
        #region flgExisteElemento(): Existe el elemento SI/NO en string
        /// <summary>
        /// <para>fnuDevolverPosElemento()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para saber si el elemento existe dentro de la lista string
        /// separada por caracter dado en el parametro tcrSeparador
        /// <para>PARAMETROS:</para>
        /// <para>tcrElemento:
        /// Nombre del elemento a buscar en la cadena (tipo string)</para>
        /// <para>tcrListaString:
        /// Cadena string que contiene elementos separados por coma (,)</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve true cuando existe el elemento en la lista false 
        /// cuando no existe o lista esta vacia.</returns>
        /// </summary>
        public static bool flgExisteElemento(string tcrElemento, string tcrSeparador, string tcrListaString)
        {
            bool llgValor = false;
            if (fnuDevolverPosElemento(tcrElemento, tcrSeparador, tcrListaString) > 0) { llgValor = true; }
            return llgValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuContarElemListaString() Contador Elementos en una Cadena
        //------------------------------------------------------------
        #region fnuContarElemListaString() Contador Elementos en una Cadena
        /// <summary>
        /// <para>fnuContarElemListaString()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Cuenta cuantos elementos separados por tcrSeparador "," "-" y otros hay en la</para>
        /// <para>cadena dada en PARAMETRO: tcrListaString </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve un valor de tipo entero (int) si la lista esta vacia retorna cero.</para>
        /// </summary>
        public static int fnuContarElemListaString(string tcrSeparador, string tcrListaString)
        {
            char[] tcrCharSeparador = tcrSeparador.ToCharArray();
            string lcrValor = string.Empty;
            string[] larArray = tcrListaString.Split(tcrCharSeparador);
            return larArray.Length;
        }
        #endregion
        //------------------------------------------------------------
        // flgEsTexto(): Verificar que sea solo texto
        //------------------------------------------------------------
        #region flgSoloTexto(): Verificar que sea solo texto
        /// <summary>
        /// <para>flgSoloTexto()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Verificar si el parametro tcrTexto contiene una expresión</para>
        /// <para>de solo texto sin otro tipo de caracteres.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipo:</para>
        /// <para>"MX"= Verifica que sea solo texto (no distingue mayusculas y minusculas)</para>
        /// <para>"MA"= verifica que sea solo mayusculas</para>
        /// <para>"MI"= Verifica que solo sean minusculas</para>
        /// <para>"AN"= Texto y Numeros</para>
        /// <para>"AX"= Texto y Numeros con espacios o tabulacion (una oración)</para>
        /// <para>"AM"= Una sola expresion Alfanumerico con texto en mayuscuala y numeros</para>
        /// <para>tcrTexto:</para>
        /// <para>cadena de tipo string con los valores a verificar</para>
        /// <para>VALOR DE RETORNO:</para>
        /// <para>Devuelve True cuando la cadena es solo texto de lo contrario devuelve False.</para>
        /// </summary>
        public static bool flgSoloTexto(string tcrTipo,string tcrTexto) 
        {
            bool llgReturn = false;
            switch (tcrTipo)
            {
                case "MX":
                    // Texto no distingue mayusculas ni minusculas
                    Regex lcrTextMx = new Regex(@"^[^ ][a-zA-Z]+[^ ]$");
                    llgReturn = lcrTextMx.IsMatch(tcrTexto);
                    break;

                case "MA":
                    // Texto en mayusculas
                    Regex lcrTextMy = new Regex(@"[A-Z]");
                    llgReturn = lcrTextMy.IsMatch(tcrTexto);
                    break;

                case "MI":
                    // Texto solo minusculas
                    Regex lcrTextMi = new Regex(@"[a-z]");
                    llgReturn = lcrTextMi.IsMatch(tcrTexto);
                    break;

                case "AN":
                    // Alfanumerico - Texto y numeros: (Expresion o Expresion+Espacio+Expresion) repetidas n veces
                    Regex lcrTextAn = new Regex(@"^([^\W]|[^\W]+[^\S][^\W]|[^\W]+[^\S][^\W]+[^\S])*$");
                    llgReturn = lcrTextAn.IsMatch(tcrTexto);
                    break;

                case "AX":
                    // Texto y numeros con espacios o tabulacion al final y repetido n veces
                    //Regex lcrTextNx = new Regex(@"^([^\W]+([^\S]*?)|[^\W]+[^\S][^\W]+([^\S]*?))*$");
                    Regex lcrTextNx = new Regex(@"^([^\W]|[^\W]+([^\S]*?)|[^\W]+[^\S][^\W]+([^\S]*?))*$");
                    llgReturn = lcrTextNx.IsMatch(tcrTexto);
                    break;

                case "AM":
                    // Una sola expresion Alfanumerico con texto en mayuscuala y numeros
                    Regex lcrTextAm = new Regex(@"^([A-Z0-9])*$");
                    llgReturn = lcrTextAm.IsMatch(tcrTexto);
                    break;

            }
            return llgReturn;
        }
        /// <summary>
        /// <para>flgSoloTexto()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Verificar si el parametro tcrTexto contiene una expresión</para>
        /// <para>de solo texto sin otro tipo de caracteres.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:</para>
        /// <para>cadena de tipo string a verificar</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve True cuando la cadena es solo texto de lo contrario devuelve False.<para>
        /// </summary>
        public static bool flgSoloTexto(string tcrTexto)
        {
            Regex lcrTextMx = new Regex(@"^[^ ][a-zA-Z ]+[^ ]$");
            return lcrTextMx.IsMatch(tcrTexto);
        }
        #endregion
        //------------------------------------------------------------
        // flgSoloNumeros(): Verificar que solo sea numero
        //------------------------------------------------------------
        #region flgSoloNumeros(): Verificar que solo sea numero int
        /// <summary>
        /// <para>flgSoloNumeros()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// datos solo texto numerico sin otro tipo de caracteres.
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:
        /// cadena de tipo string con los valores a verificar</para>
        /// <para>tnuRangoini:
        /// Rango Inicial para Verificación</para>
        /// <para>tnuRangoFin:
        /// Rango Final para Verificación</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando la cadena es solo texto 
        /// numerico y esta en el rango, de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgSoloNumeros(string tcrTexto, int tnuRangoini, int tnuRangoFin)
        {
            //Regex lcrText = new Regex("^[0-9]*$");
            bool llgReturn = false;
            //if (lcrText.IsMatch(tcrTexto))
            if (flgSoloNumerosEx(tcrTexto))
            {
                if (tnuRangoini != tnuRangoFin)
                {
                    Decimal lnuDato = 0;
                    tcrTexto = fcrRemplazarChrDecimal(tcrTexto);
                    lnuDato = Convert.ToDecimal(tcrTexto);
                    if (lnuDato >= tnuRangoini && lnuDato <= tnuRangoFin)
                    {
                        llgReturn = true;
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSoloNumeros(): Verificar que solo sea numero Decimal
        /// <summary>
        /// <para>flgSoloNumeros()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// datos solo texto numerico sin otro tipo de caracteres.
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:
        /// cadena de tipo string con los valores a verificar</para>
        /// <para>tdeRangoini:
        /// Rango Inicial para Verificación</para>
        /// <para>tdeRangoFin:
        /// Rango Final para Verificación</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando la cadena es solo texto 
        /// numerico y esta en el rango, de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgSoloNumeros(String tcrTexto, Decimal tdeRangoini, Decimal tdeRangoFin)
        {
            //Regex lcrText = new Regex("^[0-9]*$");
            bool llgReturn = false;
            //if (lcrText.IsMatch(tcrTexto))
            if (flgSoloNumerosEx(tcrTexto))
            {
                if (tdeRangoini != 0 && tdeRangoFin != 0)
                {
                    tcrTexto  = fcrRemplazarChrDecimal(tcrTexto);

                    var lnuRes1 = Decimal.Compare(Convert.ToDecimal(tcrTexto), tdeRangoini);
                    var lnuRes2 = Decimal.Compare(Convert.ToDecimal(tcrTexto), tdeRangoFin);

                    llgReturn = lnuRes1 >= 0 && lnuRes2 <= 0 ? true : false;
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSoloNumeros(): Verificar que solo sea numero sin mas parametros
        /// <summary>
        /// <para>flgSoloNumeros()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene 
        /// solo texto numerico sin otro tipo de caracteres.
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:
        /// cadena de tipo string con valores a verificar</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando la cadena es solo texto 
        /// numerico de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgSoloNumeros(String tcrTexto)
        {
            Regex lcrText = new Regex("^[0-9]*$");
            bool llgReturn = false;
            if (lcrText.IsMatch(tcrTexto.Trim()))
            {
                llgReturn = true;
                llgReturn = String.IsNullOrWhiteSpace(tcrTexto) ? false : true;
            }
            return llgReturn;
        }
        #endregion
        #region flgSoloNumeros(): Verificar que solo sea numero flotantes
        /// <summary>
        /// <para>flgSoloNumeros()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// datos solo texto numerico sin otro tipo de caracteres.
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:
        /// cadena de tipo string con los valores a verificar</para>
        /// <para>tdeRangoini:
        /// Rango Inicial para Verificación</para>
        /// <para>tdeRangoFin:
        /// Rango Final para Verificación</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando la cadena es solo texto 
        /// numerico y esta en el rango, de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgSoloNumeros(String tcrTexto, float tdeRangoini, float tdeRangoFin)
        {
            //Regex lcrText = new Regex("^[0-9]*$");
            bool llgReturn = false;
            //if (lcrText.IsMatch(tcrTexto))
            if (flgSoloNumerosEx(tcrTexto))
            {
                tcrTexto = fcrRemplazarChrDecimal(tcrTexto);

                if (tdeRangoini != 0 && tdeRangoFin != 0)
                {
                    tcrTexto = fcrRemplazarChrDecimal(tcrTexto);
                    var lnuValor = (float)Convert.ToDecimal(tcrTexto);

                    if (lnuValor >= tdeRangoini && lnuValor <= tdeRangoFin)
                    {
                        llgReturn = true;
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // flgSoloNumerosEx(): Verificar que sean solo numeros o decimal
        //------------------------------------------------------------
        #region flgSoloNumerosEx(): Verificar que sean solo numeros o decimal
        /// <summary>
        /// <para>flgSoloNumeros()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene 
        /// texto numerico o numero decimal con separador.
        /// <para>PARAMETROS:</para>
        /// <para>tcrTexto:
        /// cadena de tipo string con valores a verificar</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando la cadena es solo texto 
        /// numerico o numero con posiciones decimales, de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgSoloNumerosEx(string tcrTexto)
        {
            Regex lcrText = new Regex("^[0-9]{1,20}([.,][0-9]{0,6})?$");
            bool llgReturn = false;
            if (lcrText.IsMatch(tcrTexto.Trim()))
            {
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // flgRangoNumero(): Verifica valor dado en rango
        //------------------------------------------------------------
        #region flgRangoNumero(): Verifica valor dado en rango
        /// <summary>
        /// <para>flgRangoNumero()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verifica que el valor dado en el parametro
        /// tcrNumero este dentro del rango de tnuRangoini y tnuRangoFin.
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumero:
        /// valor numerico a verificar</para>
        /// <para>tnuRangoini:
        /// Rango Inicial para Verificación</para>
        /// <para>tnuRangoFin:
        /// Rango Final para Verificación</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando el valor numerico  
        /// esta en el rango, de lo contrario devuelve Falso.</para>
        /// </summary>
        public static bool flgRangoNumero(int tcrNumero, int tnuRangoini, int tnuRangoFin)
        {
            bool llgReturn = false;
            if (tnuRangoini != tnuRangoFin)
            {
                if (tcrNumero >= tnuRangoini && tcrNumero <= tnuRangoFin)
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fflCalcularPuntajeUvr(): Calcular puntaje o valor en UVR del servicio
        //------------------------------------------------------------
        #region fflCalcularPuntajeUvr
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Calcular puntaje o valor en UVR del servicio</para> 
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoCalculo: 1=Calculo Puntaje Tipo Soat 2=Calculo Tipo UVR para ISS</para>
        /// <para>tflValorServicio: Valor del servicio para calculos</para>
        /// <para>tnuValorSalarioMes: Valor Salario Minimo Mensual</para>
        /// </summary>
        public static float fflCalcularPuntajeUvr(String tcrTipoCalculo, float tflValorServicio, int tnuValorSalarioMes)
        {
            float lflValor = 0;
            try
            {
                if (tcrTipoCalculo != "2") // Diferente de ISS (es soat o cups)
                {
                    // Soat y Cups se calculan igual
                    var lcrValorDia = tnuValorSalarioMes / 30;
                    lflValor = tflValorServicio / lcrValorDia;
                }
                else
                {
                    // Calculo para ISS
                    lflValor = tflValorServicio / 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Funciones Metodo: fflCalcularPuntajeUvr");
            }
            return lflValor;
        }
        #endregion
        //------------------------------------------------------------
        //  FUNCIONES PARA GESTION CON FECHAS
        //------------------------------------------------------------
        #region FUNCIONES PARA GESTION CON FECHAS
        //------------------------------------------------------------
        // fcrElementoFecha(): devolver dia,mes,año desde fecha
        //------------------------------------------------------------
        #region fcrElementoFecha(): devolver dia,mes,año desde fecha
        /// <summary>
        /// <para>fcrElementoFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para devolver el DIA, MES o el AÑO en tipo texto desde 
        /// string con formato fecha
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipo:
        /// Tipo de componente a devolver: "DIA","MES","AÑO"</para>
        /// <para>tcrFormato:
        /// Formato de fecha que contiene la cadena tcrStringFecha: DMY, MYD,YMD... </para>
        /// <para>tcrSeparador:
        /// Caracter separador de fecha "/", "-" y otros ejm: 01/10/2013  14-10-2001 </para>
        /// <para>tcrStringFecha:
        /// Cadena string con formato fecha segun tcrFormato dia/mes/año y otros</para>
        /// <para>VALOR DE RETORNO</para>
        /// <returns>Devuelve el valor del componente DIA MES O AÑO, cuando no es una 
        /// cadena valida tipo fecha o esta vacia devuelve string vacia.</returns>
        /// </summary>
        public static string fcrElementoFecha(string tcrTipo, string tcrFormato, string tcrSeparador, string tcrStringFecha)
        {
            string lcrValor = string.Empty;
            DateTime ldaFecha;
            // si es correcta seleccionar item
            if (DateTime.TryParse(tcrStringFecha, out ldaFecha))
            {
                int lnuPosElemento = 0;
                char[] tcrCharSeparador = tcrSeparador.ToCharArray();
                string[] larArray = tcrStringFecha.Split(tcrCharSeparador);
                switch (tcrTipo.ToUpper())
                {
                    case "DIA":
                        lnuPosElemento = fnuDevPosOcursElemento("D", 1, tcrFormato) - 1;
                        break;

                    case "MES":
                        lnuPosElemento = fnuDevPosOcursElemento("M", 1, tcrFormato) - 1;
                        break;

                    case "AÑO":
                        lnuPosElemento = fnuDevPosOcursElemento("Y", 1, tcrFormato) - 1;
                        break;
                }
                if (larArray.Length >= lnuPosElemento && lnuPosElemento > -1)
                {
                    lcrValor = larArray[lnuPosElemento];
                }
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // flgValidaFecha(): Verificar que sea una fecha 
        //------------------------------------------------------------
        #region flgValidaFecha(): Verificar que sea una fecha
        /// <summary>
        /// <para>flgValidaFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// una fecha correcta en formato: (dd/mm/aaaa).
        /// <para>PARAMETROS:</para>
        /// <para>tcrFormato:
        /// Tipo formato de cadena de a verificar "DMY", "YDM" y otros </para>
        /// <para>tcrSeparador:
        /// Caracter separador del formato ejm: "/" = 15/10/2013  "-" = 14-11-2012</para>
        /// <para>tcrFecha:
        /// Cadena de tipo string con texto a verificar ejemplo: "15/10/2011" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando es una fecha correcta
        /// devuelve falso cuando la cadena esta vacia o no es una fecha correcta.</para>
        /// </summary>
        public static bool flgValidaFecha(string tcrFormato, string tcrSeparador, string tcrFecha)
        {
            var llgValor = false;
            var lnuSumaError = 0;
            DateTime ldaFecha;
            // si es correcta genera el valor
            if (DateTime.TryParse(tcrFecha, out ldaFecha) && tcrFecha.Trim().Length == 10)
            {
                string lcrDia = ldaFecha.Day.ToString();
                string lcrMes = ldaFecha.Month.ToString();
                string lcrAño = ldaFecha.Year.ToString();
                if (Convert.ToInt32(lcrMes) < 1 && Convert.ToInt32(lcrMes) > 12)
                {
                    lnuSumaError++;
                }
                else 
                {
                    if (Convert.ToInt32(lcrMes) == 2)
                    {
                        if (Convert.ToInt32(lcrDia) < 1 && Convert.ToInt32(lcrDia) > 29) { lnuSumaError++; }
                    }
                    else 
                    {
                        if (Convert.ToInt32(lcrDia) < 1 && Convert.ToInt32(lcrDia) > 31) { lnuSumaError++; }
                    }
                }
                if (Convert.ToInt32(lcrAño) <= 1000) { lnuSumaError++; }
                if (lnuSumaError == 0) { llgValor = true; }
            }
            return llgValor;
        }
        #endregion
        //------------------------------------------------------------
        // fdaConvertFecha(): convierte una fecha texto a DateTime
        //------------------------------------------------------------
        #region fdaConvertFecha(): convierte una fecha texto a DateTime
        /// <summary>
        /// <para>fdaConvertFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// devuelve una expresion tipo DataTime en formato (dd/mm/aaaa)
        /// desde una expresion de texto con formato fecha.
        /// <para>PARAMETROS:</para>
        /// <para>tcrFormato:
        /// Tipo formato de cadena enviado "DMY", "YDM" y otros </para>
        /// <para>tcrSeparador:
        /// Caracter separador del formato ejm: "/" = 15/10/2013  "-" = 14-11-2012</para>
        /// <para>tcrFecha:
        /// Cadena de tipo string con texto fecha ejemplo: "15/10/2011" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve fecha correcta en DateTime, devuelve formato 
        /// 01/01/0001 cuando la cadena esta vacia o no es una fecha correcta.</para>
        /// </summary>
        public static DateTime fdaConvertFecha(string tcrFormato, string tcrSeparador, string tcrFecha)
        {
            DateTime ldaFecha;
            tcrFecha = tcrFecha.Length > 10 ? tcrFecha.Substring(0, 10) : tcrFecha;
            // si es correcta genera el valor
            if (flgValidaFecha(tcrFormato, tcrSeparador, tcrFecha))
            {
                if (tcrFormato == "DMY") { tcrFecha = fcrCorregirFechaTexto(tcrFecha); }
                ldaFecha = Convert.ToDateTime(tcrFecha);
            }
            else 
            {
                ldaFecha = Convert.ToDateTime("01/01/0001");
            }
            return ldaFecha;
        }
        #endregion
        //------------------------------------------------------------
        // fcrConvertFecha(): convierte fecha DateTime a fecha texto
        //------------------------------------------------------------
        #region fcrConvertFecha(): convierte fecha DateTime a fecha texto
        /// <summary>
        /// <para>fcrConvertFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// devuelve una expresion tipo texto en formato (dd/mm/aaaa)
        /// desde una expresion DataTime con formato fecha.
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna fecha en formato texto, devuelve una String Vacia
        /// cuando el valor dado es "01/01/0001".</para>
        /// </summary>
        public static String fcrConvertFecha(DateTime tdaFecha)
        {
            var lcrFecha = fcrCorregirFechaTexto(tdaFecha.ToShortDateString());

            return lcrFecha;
        }
        #endregion
        #region fcrCorregirFechaTexto(): convierte fecha texto a fecha texto ajustada
        /// <summary>
        /// <para>fcrCorregirFechaTexto()</para>
        /// <para>DESCRIPCIÓN</para>
        /// devuelve una expresion tipo texto en formato (dd/mm/aaaa)
        /// desde una expresion texto con formato fecha corregido.
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna fecha en formato texto, devuelve una String Vacia
        /// cuando el valor dado es "01/01/0001".</para>
        /// </summary>
        public static String fcrCorregirFechaTexto(String tcrFecha)
        {
            var lcrFecha = tcrFecha;
            var lcrDia = String.Empty;
            var lcrMes = String.Empty;
            var lcrAno = String.Empty;

            String[] larArray = lcrFecha.Split("/".ToCharArray());

            lcrDia = larArray[0].Trim().Length == 1 ? "0" + larArray[0].Trim() : larArray[0].Trim();
            lcrMes = larArray[1].Trim().Length == 1 ? "0" + larArray[1].Trim() : larArray[1].Trim();
            lcrAno = larArray[2].Trim().Length == 1 ? "0" + larArray[2].Trim() : larArray[2].Trim();

            lcrFecha = lcrDia + "/" + lcrMes + "/" + lcrAno;

            lcrFecha = lcrFecha == "01/01/0001" || lcrFecha == "01/01/1000" ? String.Empty : lcrFecha;

            return lcrFecha;
        }
        #endregion
        //------------------------------------------------------------
        // FdaFechaActual(): Devuelve la fecha acutal del servidor
        //------------------------------------------------------------
        #region fdaFechaActual(): Devuelve la fecha acutal del servidor
        /// <summary>
        /// <para>fdaFechaActual()</para>
        /// <para>DESCRIPCIÓN</para>
        /// devuelve una expresion tipo DataTime en formato (dd/mm/aaaa)
        /// desde el servidor de la aplicación o base de datos
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve fecha correcta en DateTime.</para>
        /// </summary>
        public static DateTime FdaFechaActual()
        {
            return DateTime.Today;
        }
        #endregion
        #region fcrFechaActual(): Devuelve la fecha acutal del servidor en formato texto
        /// <summary>
        /// <para>fcrFechaActual()</para>
        /// <para>DESCRIPCIÓN</para>
        /// devuelve una expresion tipo texto DataTime en formato (dd/mm/aaaa)
        /// desde el servidor de la aplicación o base de datos
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve String (dd/mm/aaaa) fecha correcta.</para>
        /// </summary>
        public static String fcrFechaActual()
        {
            return fcrConvertFecha(FdaFechaActual());
        }
        #endregion
        //------------------------------------------------------------
        // fcrValidaFechaTexto(): Verificar que sea una fecha correcta
        //------------------------------------------------------------
        #region fcrValidaFechaTexto(): Verificar que sea una fecha
        /// <summary>
        /// <para>flgValidaFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrFecha contiene  
        /// una fecha correcta en formato: (dd/mm/aaaa).
        /// <para>PARAMETROS:</para>
        /// <para>tcrRequerida:
        /// Para realizar vaidacion obligatoria o se acepta fecha vacia 
        /// true = Validacion obligatoria // false = Se aceptan fechas vacias </para>
        /// <para>tcrFormato:
        /// Tipo formato de cadena de a verificar "DMY", "YDM" y otros </para>
        /// <para>tcrSeparador:
        /// Caracter separador del formato ejm: "/" = 15/10/2013  "-" = 14-11-2012</para>
        /// <para>tcrFecha:
        /// Cadena de tipo string con texto a verificar ejemplo: "15/10/2011" </para>
        /// <para>tcrMsgTitulo:
        /// Cadena de tipo string con texto titulo para conactenear mensaje de retorno</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve vacio cuando es una fecha correcta,
        /// devuelve una cadena de texto con el mensaje de error cuando
        /// la cadena esta vacia o no es una fecha correcta</para>
        /// </summary>
        public static String fcrValidaFechaTexto(bool tlgRequerida, String tcrFormato, String tcrSeparador, String tcrFecha, String tcrMsgTitulo)
        {
            var lcrValorReturn=String.Empty;
            var lcrVal1 = tcrSeparador + tcrSeparador; // equivalente una fecha "//"
            var lcrVal2 = tcrSeparador +"  "+ tcrSeparador; // equivalente una fecha "/  /"
            var lcrVal3 = tcrSeparador + "    " + tcrSeparador; // equivalente una fecha "/    /"
            if (tlgRequerida == true)
            {
                if (string.IsNullOrWhiteSpace(tcrFecha) ||
                    tcrFecha.Trim() == lcrVal1 || tcrFecha.Trim() == lcrVal2 || tcrFecha.Trim() == lcrVal3)
                {
                    lcrValorReturn = tcrMsgTitulo + ": Es requerida";
                }
                else
                {
                    if (!flgValidaFecha(tcrFormato, tcrSeparador, tcrFecha))
                    {
                        lcrValorReturn = tcrMsgTitulo + ": Valor fecha no es valida";
                    }
                }
            }
            else 
            {
                if (!string.IsNullOrWhiteSpace(tcrFecha))
                {
                    if (tcrFecha.Trim() != lcrVal1 && tcrFecha.Trim() != lcrVal2 && tcrFecha.Trim() != lcrVal3)
                    {
                        if (!flgValidaFecha(tcrFormato, tcrSeparador, tcrFecha))
                        {
                            lcrValorReturn = tcrMsgTitulo + ": Valor fecha no es valida";
                        }
                    }
                }
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // flgValidarRangoFecha: Realiza la Validacion de
        // rango fechas
        //-------------------------------------------------
        #region flgValidarRangoFecha: Valida que el rango sea valido
        /// <summary>
        /// <para>flgValidarRangoFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si los valores tipo texto dados en tcrFechaIni y tcrFechaFin
        /// corresponden a un rango de fechas valido
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango a verificar ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango a verificar ejemplo: "15/10/2011" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve verdadero cuando el rango de fechas es valido.</para>
        /// </summary>
        public static bool flgValidarRangoFecha(String tcrFechaIni, String tcrFechaFin)
        {
            var llgValor = false;
            DateTime ldaFechaIni, ldaFechaFin;
            DateTime.TryParse(tcrFechaIni, out ldaFechaIni);
            DateTime.TryParse(tcrFechaFin, out ldaFechaFin);
            if (ldaFechaIni <= ldaFechaFin)
            {
                llgValor = true;
            }
            return llgValor;
        }
        #endregion
        //-------------------------------------------------
        // flgValidarRangoFecha: Realiza la Validacion de
        // rango fechas
        //-------------------------------------------------
        #region flgValidarRangoFecha: Verifica fecha dentro de un rango 
        /// <summary>
        /// <para>flgValidarRangoFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Verificar si el valor dado en el parametro tcrFechaVerific 
        /// es una fecha valida dentro del rango de fechas: tcrFechaIni y tcrFechaFin</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaVerific:
        /// Cadena de tipo string con texto de fecha que sera verificada en el rango</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango a verificar ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango a verificar ejemplo: "15/10/2011" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve verdadero cuando el rango de fechas es vaido y la fecha a verificar 
        /// esta dentro de este.</para>
        /// </summary>
        public static bool flgValidarRangoFecha(String tcrFechaVerific, String tcrFechaIni, String tcrFechaFin)
        {
            var llgValor = false;
            if (flgValidarRangoFecha(tcrFechaIni,tcrFechaFin))
            {
                DateTime ldaFechaIni, ldaFechaFin, ldaFechaVerf;
                DateTime.TryParse(tcrFechaIni, out ldaFechaIni);
                DateTime.TryParse(tcrFechaFin, out ldaFechaFin);
                DateTime.TryParse(tcrFechaVerific, out ldaFechaVerf);
                if (ldaFechaVerf >= ldaFechaIni && ldaFechaVerf <= ldaFechaFin)
                {
                    llgValor = true;
                }
            }
            return llgValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuCalcularFormatoAñosMesesDias(): devuelve años meses o dias segun tipo
        //------------------------------------------------------------
        #region fnuCalcularFormatoAñosMesesDias: devuelve años meses o dias segun tipo
        /// <summary>
        /// <para>fnuCalcularFormatoAñosMesesDias()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el valor cantidad de tiempo corespondiente (segun el parametro tcrTipo) en años 
        /// meses o dias</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipo: "AÑOS", "MESES", "DIAS"</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango Ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango Ejemplo: "12/02/2014" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor numerico entero correspondientesegun tipo.</para>
        /// </summary>
        public static int fnuCalcularFormatoAñosMesesDias(String tcrTipo, DateTime tdaFechaIni, DateTime tdaFechaFin)
        {
            var lcrValor = 0;

            var lnuEdadEnDias = fnuCalcularDiasFechas(tdaFechaIni, tdaFechaFin);
            var lnuEdadEnMeses = (int)(lnuEdadEnDias / 30);
            var lnuEdadEnAños = (int)(lnuEdadEnDias / 360);

            switch (tcrTipo)
            {
                case "AÑOS":
                    lcrValor = lnuEdadEnAños;
                    break;

                case "MESES":
                    lcrValor = lnuEdadEnMeses;
                    break;

                case "DIAS":
                    lcrValor = lnuEdadEnDias;
                    break;
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuValorAñosMesesDias(): Devuelve valor años meses o dias segun fechas
        //------------------------------------------------------------
        #region fnuValorAñosMesesDias: devuelve años meses o dias segun fechas
        /// <summary>
        /// <para>fcrMedidaAñosMesesDias()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>selecciona y devuelve el valor correspondiente entre dos fechas dados los parametros: tdaFechaIni y tdaFechaFin</para>
        /// <para>seleccionando segun prioridad: valorAño/ ValorMes/ ValorDia</para>
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo numerico que representa valor medida dada entre las dos fechas: Años/Meses/Dias</para>
        /// </summary>
        public static int fnuValorAñosMesesDias(DateTime tdaFechaIni, DateTime tdaFechaFin)
        {
            var lnuReturn = 0;
            var lnuAño = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", tdaFechaIni, tdaFechaFin);
            var lnuMes = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", tdaFechaIni, tdaFechaFin);
            var lnuDia = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", tdaFechaIni, tdaFechaFin);

            if (lnuAño > 0)
            {
                lnuReturn = lnuAño;
            }
            else if (lnuMes > 0)
            {
                lnuReturn = lnuMes;
            }
            else // dia
            {
                lnuReturn = lnuDia;
            }

            return lnuReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrMedidaAñosMesesDias(): devuelve medidas años meses o dias segun fechas
        //------------------------------------------------------------
        #region fcrMedidaAñosMesesDias: devuelve años meses o dias segun fechas
        /// <summary>
        /// <para>fcrMedidaAñosMesesDias()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>selecciona y devuelve el tipo medida correspondiente entre dos fechas dados los parametros: tdaFechaIni y tdaFechaFin</para>
        /// <para>seleccionando segun prioridad: 1=Año 2= Mes 3= Dia</para>
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo texto que representa al tipo medida dada entre las dos fechas: "1"= Años "2"= Meses "3"= Dias</para>
        /// </summary>
        public static String fcrMedidaAñosMesesDias(DateTime tdaFechaIni, DateTime tdaFechaFin)
        {
            var lcrReturn = "1";
            var lnuAño = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", tdaFechaIni, tdaFechaFin);
            var lnuMes = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", tdaFechaIni, tdaFechaFin);
            var lnuDia = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", tdaFechaIni, tdaFechaFin);

            lcrReturn = fcrMedidaAñosMesesDias(lnuAño, lnuMes, lnuDia);

            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrMedidaAñosMesesDias(): devuelve medidas años meses o dias
        //------------------------------------------------------------
        #region fcrMedidaAñosMesesDias: devuelve años meses o dias segun tipo
        /// <summary>
        /// <para>fcrMedidaAñosMesesDias()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>selecciona y devuelve el tipo medida correspondiente segun valores numericos en parametros tnuAños , tnuMeses , tnuDias</para>
        /// <para>segun prioridad valores: 1=Año 2= Mes 3= Dia</para>
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo texto que representa el tipo medida seleccionado: "1"= Año "2"=Meses "3"=Dias</para>
        /// </summary>
        public static String fcrMedidaAñosMesesDias(int tnuAños, int tnuMeses, int tnuDias)
        {
            var lcrReturn = "1";
            if (tnuAños > 0)
            {
                lcrReturn = "1";
            }
            else if (tnuMeses > 0)
            {
                lcrReturn = "2";
            }
            else // dia
            {
                lcrReturn = "3";
            }

            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrMedidaAñosMesesDias(): devuelve medidas años meses o dias
        //------------------------------------------------------------
        #region fcrMedidaAñosMesesDias: devuelve descripcion medida años meses o dias segun tipo
        /// <summary>
        /// <para>fcrMedidaAñosMesesDias()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve descripción medida correspondiente, segun tipo medida dada en parametro tcrTipoMedida</para>
        /// <para>PARAMETROS:</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor texto descripcion para tipo medida: "1"= Años "2"=Meses "3"=Dias</para>
        /// </summary>
        public static String fcrMedidaAñosMesesDias(String tcrTipoMedida)
        {
            var lcrReturn = "Años";
            if (tcrTipoMedida == "1")
            {
                lcrReturn = "Años";
            }
            else if (tcrTipoMedida =="2")
            {
                lcrReturn = "Meses";
            }
            else // dias
            {
                lcrReturn = "Días";
            }

            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrComponenteFecha(): devuelve años meses o dias segun tipo
        //------------------------------------------------------------
        #region fcrComponenteFecha: Devuelve componente fecha segun el parametro tcrTipo AÑO,MES,DIA
        /// <summary>
        /// <para>fcrComponenteFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el componente fecha segun el parametro tcrTipo AÑO,MES,DIA</para>
        /// <para>PARAMETROS:</para>
        /// <para>tdaFecha:
        /// Cadena tipo fecha de la cual se extraera el componente Ejemplo: 14/10/2011 </para>
        /// <para>tcrTipo: "AÑO", "MES", "DIA"</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor carater correspondiente al tipo componente.</para>
        /// </summary>
        public static String fcrComponenteFecha(DateTime tdaFecha, String tcrTipo)
        {
            var lcrFecha = fcrConvertFecha(tdaFecha);
            String lcrValor = fcrComponenteFecha(lcrFecha, tcrTipo);
            return lcrValor;
        }
        #endregion
        #region fcrComponenteFecha: Devuelve componente fecha segun el parametro tcrTipo AÑO,MES,DIA
        /// <summary>
        /// <para>fcrComponenteFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el componente fecha segun el parametro tcrTipo AÑO,MES,DIA</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFecha:
        /// Cadena tipo texto con formato dd/mm/aaaa de la cual se extraera el componente DIA MES o AÑO</para>
        /// <para>tcrTipo: "AÑO", "MES", "DIA"</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor carater correspondiente al tipo componente.</para>
        /// </summary>
        public static String fcrComponenteFecha(String tcrFecha, String tcrTipo)
        {
            String lcrValor = String.Empty;

            switch (tcrTipo)
            {
                case "AÑO":
                    lcrValor = tcrFecha.Substring(6, 4);
                    break;

                case "MES":
                    lcrValor = tcrFecha.Substring(3, 2);
                    break;

                case "DIA":
                    lcrValor = tcrFecha.Substring(0, 2);
                    break;
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrFechaRangoForamtoLargo(): devuelve edad en formato largo: años/meses/dias
        //------------------------------------------------------------
        #region fcrFechaRangoForamtoLargo(): Devuelve edad en formato largo: años/meses/dias
        /// <summary>
        /// <para>fcrFechaRangoForamtoLargo()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve formato largo: años/meses/dias como resultado del calculo de dos fechas</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango Ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango Ejemplo: "12/02/2014" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve String largo correspondiente al calculo del rango.</para>
        /// </summary>
        public static String fcrFechaRangoForamtoLargo(DateTime tdaFechaIni, DateTime tdaFechaFin)
        {
            var lcrAños = "Años";
            var lcrMeses  = "Meses";
            var lcrDias  = "Dias";
            var lcrValor = String.Empty;
            var lnuEdadEnDias = fnuCalcularDiasFechas(tdaFechaIni, tdaFechaFin);
            var lnuMeses = 0;
            var lnuDias = 0;
            var lnuAños = (int)(lnuEdadEnDias / 360);

            // Buscar Meses y dias
            lnuMeses = (int)(lnuEdadEnDias - (lnuAños * 360)) / 30;
            lnuDias = (int)(lnuEdadEnDias - ((lnuAños * 360) + (lnuMeses * 30)));
            lnuDias = lnuDias <= 0 ? 1 : lnuDias;
            // Textos
            lcrAños = lnuAños == 1 ? "Año" : lcrAños;
            lcrMeses = lnuMeses == 1 ? "Mes" : lcrMeses;
            lcrDias = lnuDias == 1 ? "Dia" : lcrDias;

            lcrValor = lnuAños.ToString() + " " + lcrAños + "/" + lnuMeses.ToString() + " " + lcrMeses + "/" + lnuDias.ToString() + " " + lcrDias;
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuCalcularDiasFechas(): devuelve total de dias entre dos fechas
        //------------------------------------------------------------
        #region fnuCalcularDiasFechas(): devuelve total de dias entre dos fechas
        /// <summary>
        /// <para>fnuCalcularDiasFechas()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el total de dias existentes como resultado del calculo de dos fechas</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaIni: Cadena de tipo string con texto de fecha inicial del rango Ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin: Cadena de tipo string con texto de fecha final del rango Ejemplo: "12/02/2014" </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor numerico correspondiente al calculo de dias del rango de fechas.</para>
        /// </summary>
        public static int fnuCalcularDiasFechas(DateTime tdaFechaIni, DateTime tdaFechaFin)
        {

            int lnuDia1, lnuDia2, lnuDia3, lnuDia4, lnuDia5;
            var lnuAñoFecIni = tdaFechaIni.Year;
            var lnuMesFecIni = tdaFechaIni.Month;
            var lnuDiaFecIni = tdaFechaIni.Day;
            var lnuAñoFecFin = tdaFechaFin.Year;
            var lnuMesFecFin = tdaFechaFin.Month;
            var lnuDiaFecFin = tdaFechaFin.Day;

            lnuDia1 = 0;
            lnuDia2 = 0;
            lnuDia3 = 0;
            lnuDia5 = 0;
            lnuDia4 = 0;

            if (lnuAñoFecIni == lnuAñoFecFin)
            {
                if ((lnuMesFecFin - lnuMesFecIni) > 0)
                {
                    //lnuDia1 = (fnuUltimodiaMes(tdaFechaIni) - lnuDiaFecIni) + 1;

                    lnuDia1 = fnuUltimodiaMes(tdaFechaIni) - lnuDiaFecIni;
                    lnuDia2 = ((lnuMesFecFin - lnuMesFecIni) - 1) * 30;
                    if (lnuMesFecFin == 2)
                    {
                        lnuDia5 = lnuDiaFecFin > 29 ? 28 : lnuDiaFecFin;
                    }
                    else
                    {
                        lnuDia5 = lnuDiaFecFin;
                    }
                }
                else if ((lnuMesFecFin - lnuMesFecIni) == 0)
                {
                    // El mismo mes 

                    //lnuDia1 = (lnuDiaFecFin - lnuDiaFecIni) + 1;
                    //lnuDia1 = lnuDia1 == 1 ? 0 : lnuDia1;

                    lnuDia1 = lnuDiaFecFin - lnuDiaFecIni;
                    lnuDia2 = 0;
                    lnuDia3 = 0;
                    lnuDia5 = 0;
                    lnuDia4 = 0;
                }
                else
                {
                    lnuDia1 = 0;
                    lnuDia2 = 0;
                    lnuDia3 = 0;
                    lnuDia5 = 0;
                    lnuDia4 = 0;
                }
            }
            else if (lnuAñoFecIni < lnuAñoFecFin)
            {
                //lnuDia1 = (fnuUltimodiaMes(tdaFechaIni) - lnuDiaFecIni) + 1;

                lnuDia1 = (fnuUltimodiaMes(tdaFechaIni) - lnuDiaFecIni);
                lnuDia2 = (12 - lnuMesFecIni) * 30;
                lnuDia3 = (((lnuAñoFecFin - lnuAñoFecIni) - 1) * 12) * 30;
                lnuDia4 = (lnuMesFecFin - 1) * 30;
                if (lnuMesFecFin == 2)
                {
                    lnuDia5 = lnuDiaFecFin > 29 ? 28 : lnuDiaFecFin;
                }
                else
                {
                    lnuDia5 = lnuDiaFecFin;
                }
            }
            else
            {
                lnuDia1 = 0;
                lnuDia2 = 0;
                lnuDia3 = 0;
                lnuDia5 = 0;
                lnuDia4 = 0;
            }
            return (lnuDia1 + lnuDia2 + lnuDia3 + lnuDia4 + lnuDia5);
        }
        #endregion
        //-------------------------------------------------
        // flgValidarRangoFechasHoras: Validar rango fechas y horas
        //-------------------------------------------------
        #region  flgValidarRangoFechasHoras: Validar rango fechas y horas
        /// <summary>
        /// <para>flgValidarRangoFechasHoras()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve verdader si el rango de fechas y horas dado es valido</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango a verificar ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango a verificar ejemplo: "15/10/2011" </para>
        /// <para>tcrFormatoFecha:
        /// Formato de la string de fecha DMY = (05/03/2013) , YMD=(2012/02/25)</para>
        /// <para>tcrHoraIni/tcrHoraFin:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tcrFormatoHora:
        /// parametro tipo string para indicar tipo formato de la hora: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dado tcrStringHora</para>
        /// <para>tcrSeparadorformatoHora:
        /// parametro string para indicar caracter separador del formato de hora
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve verdadero cuando el rango de fechas y horas es valido.</para>
        /// </summary>
        public static bool flgValidarRangoFechasHoras(String tcrFechaIni, String tcrFechaFin, String tcrFormatoFecha, String tcrSeparadorFecha,
                                                String tcrHoraIni, String tcrHoraFin, String tcrFormatoHora, String tcrSeparadorHora)
        {
            var llgValor = false;
            if (String.IsNullOrWhiteSpace(fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaIni, "Fecha Inicio")) &&
                String.IsNullOrWhiteSpace(fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaFin, "Fecha fin")))
            {
                if (String.IsNullOrWhiteSpace(fcrValidaHoraTexto(true, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora, "Hora Inicial")) &&
                    String.IsNullOrWhiteSpace(fcrValidaHoraTexto(true, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora, "Hora Final")))
                {
                    // Validar Rango 
                    if (flgValidarRangoFecha(tcrFechaIni, tcrFechaFin))
                    {
                        var lnullaveIni = Convert.ToInt64(fcrGenLlaveRangoFechaHora(tcrFechaIni, tcrFormatoFecha, tcrSeparadorFecha,
                                                                                              tcrHoraIni, tcrFormatoHora, tcrSeparadorHora));
                        var lnullaveFin = Convert.ToInt64(fcrGenLlaveRangoFechaHora(tcrFechaFin, tcrFormatoFecha, tcrSeparadorFecha,
                                                                                              tcrHoraFin, tcrFormatoHora, tcrSeparadorHora));
                        if (lnullaveIni < lnullaveFin) { llgValor = true; }
                    }
                }
            }
            return llgValor;
        }
        #endregion
        #region  flgValidarRangoFechasHorasEx: Validar rango fechas y horas exacto
        /// <summary>
        /// <para>flgValidarRangoFechasHorasEx()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve verdader si el rango de fechas y horas dado es valido</para>
        /// <para>tambien incluye como verdadero el rango de fechas horas y minutos iguales.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFechaIni:
        /// Cadena de tipo string con texto de fecha inicial del rango a verificar ejemplo: "14/10/2011" </para>
        /// <para>tcrFechaFin:
        /// Cadena de tipo string con texto de fecha final del rango a verificar ejemplo: "15/10/2011" </para>
        /// <para>tcrFormatoFecha:
        /// Formato de la string de fecha DMY = (05/03/2013) , YMD=(2012/02/25)</para>
        /// <para>tcrHoraIni/tcrHoraFin:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tcrFormatoHora:
        /// parametro tipo string para indicar tipo formato de la hora: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dado tcrStringHora</para>
        /// <para>tcrSeparadorformatoHora:
        /// parametro string para indicar caracter separador del formato de hora
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve verdadero cuando el rango de fechas y horas es valido, incluido fechas horas y minutos iguales.</para>
        /// </summary>
        public static bool flgValidarRangoFechasHorasEx(String tcrFechaIni, String tcrFechaFin, String tcrFormatoFecha, String tcrSeparadorFecha,
                                                String tcrHoraIni, String tcrHoraFin, String tcrFormatoHora, String tcrSeparadorHora)
        {
            var llgValor = false;
            if (String.IsNullOrWhiteSpace(fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaIni, "Fecha Inicio")) &&
                String.IsNullOrWhiteSpace(fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaFin, "Fecha fin")))
            {
                if (String.IsNullOrWhiteSpace(fcrValidaHoraTexto(true, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora, "Hora Inicial")) &&
                    String.IsNullOrWhiteSpace(fcrValidaHoraTexto(true, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora, "Hora Final")))
                {
                    // Validar Rango 
                    if (flgValidarRangoFecha(tcrFechaIni, tcrFechaFin))
                    {
                        var lnullaveIni = Convert.ToInt64(fcrGenLlaveRangoFechaHora(tcrFechaIni, tcrFormatoFecha, tcrSeparadorFecha,
                                                                                              tcrHoraIni, tcrFormatoHora, tcrSeparadorHora));
                        var lnullaveFin = Convert.ToInt64(fcrGenLlaveRangoFechaHora(tcrFechaFin, tcrFormatoFecha, tcrSeparadorFecha,
                                                                                              tcrHoraFin, tcrFormatoHora, tcrSeparadorHora));
                        if (lnullaveIni <= lnullaveFin) { llgValor = true; }
                    }
                }
            }
            return llgValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuUltimodiaMes(): Devuelve el ultimo dia del mes
        //------------------------------------------------------------
        #region fnuUltimodiaMes(): Devuelve el ultimo dia del mes
        /// <summary>
        /// <para>fnuUltimodiaMes()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el ultimo dia del mes correspondiente a la fecha dada como parametro</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFecha: Parametro tipo fcha Ejemplo: "14/04/2011"</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor numerico correspondiente al ultimo dia del mes para la fecha dada en tcrFecha.</para>
        /// </summary>
        public static int fnuUltimodiaMes(DateTime tcrFecha)
        {
            var lnuValor = 0;
            var lnuMesSiguiente     = (tcrFecha.Month + 1) > 12 ? 1 : (tcrFecha.Month + 1);
            String lnuAñoActual     = tcrFecha.Year.ToString();
            String lcrMesSiguiente  = (lnuMesSiguiente).ToString();

            lnuValor = (Convert.ToDateTime("01/" + lcrMesSiguiente + "/" + lnuAñoActual).AddDays(-1)).Day; //restar un día al mes siguiente

            return lnuValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrFechaTextoCambiarFormato(): Cambiar formato texto fecha 
        //------------------------------------------------------------
        #region fcrFechaTextoCambiarFormato(): Cambiar el formato de una fecha
        /// <summary>
        /// <para>fcrFechaTextoCambiarFormato()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Cambiar el formato de una fecha correcta ejemplo: (dd/mm/aaaa) -> (aaaa-mm-dd).
        /// <para>PARAMETROS:</para>
        /// <para>tcrFormato:
        /// Tipo formato fecha inicial sin cambiar "DMY", "YDM" y otros </para>
        /// <para>tcrSeparador:
        /// Caracter separador del formato ejm: "/" = 15/10/2013  "-" = 14-11-2012</para>
        /// <para>tcrFecha:
        /// Cadena de tipo string con texto fecha ejemplo: "15/10/2011" </para>
        /// <para>tcrFormatoDestino:
        /// Tipo formato destino para la String generada "DMY", "YDM" y otros </para>
        /// <para>tcrSeparadorDestino:
        /// Caracter separador del formato destino ejm: "/" = 15/10/2013  "-" = 14-11-2012</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve vacio cuando no es una fecha correcta,
        /// devuelve una cadena texto con el nuevo formato fecha</para>
        /// </summary>
        public static String fcrFechaTextoCambiarFormato(String tcrFormato, String tcrSeparador, String tcrFecha, String tcrFormatoDestino, String tcrSeparadorDestino)
        {
            var lcrValorReturn = String.Empty;
            var lcrDia = String.Empty;
            var lcrMes = String.Empty;
            var lcrAño = String.Empty;
            if (flgValidaFecha(tcrFormato, tcrSeparador, tcrFecha))
            {
                lcrDia = fcrElementoFecha("DIA", tcrFormato, tcrSeparador, tcrFecha);
                lcrMes = fcrElementoFecha("MES", tcrFormato, tcrSeparador, tcrFecha);
                lcrAño = fcrElementoFecha("AÑO", tcrFormato, tcrSeparador, tcrFecha);

                switch (tcrFormatoDestino)
                {
                    case "DMY":
                        lcrValorReturn = lcrDia + tcrSeparadorDestino + lcrMes + tcrSeparadorDestino + lcrAño;
                        break;

                    case "DYM":
                        lcrValorReturn = lcrDia + tcrSeparadorDestino + lcrAño + tcrSeparadorDestino + lcrMes;
                        break;

                    case "MDY":
                        lcrValorReturn = lcrMes + tcrSeparadorDestino + lcrDia + tcrSeparadorDestino + lcrAño;
                        break;

                    case "MYD":
                        lcrValorReturn = lcrMes + tcrSeparadorDestino + lcrAño + tcrSeparadorDestino + lcrDia;
                        break;

                    case "YMD":
                        lcrValorReturn = lcrAño + tcrSeparadorDestino + lcrMes + tcrSeparadorDestino + lcrDia;
                        break;

                    case "YDM":
                        lcrValorReturn = lcrAño + tcrSeparadorDestino + lcrDia + tcrSeparadorDestino + lcrMes;
                        break;
                }
            }
            return lcrValorReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrFechaNombreMes(): Devuelve nombre del mes dada fecha texto
        //------------------------------------------------------------
        #region fcrFechaNombreMes(): Devuelve el nombre del mes dada una fecha
        /// <summary>
        /// <para>fcrFechaNombreMes()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve nombre del mes dada fecha tipo texto</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrFormato:
        /// Formato fecha de la cadema tcrFecha: DMY, MYD,YMD... </para>
        /// <para>tcrFecha:
        /// Cadena tipo texto con formato de fecha Ejemplo: "14/10/2011"</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor carater correspondiente al nombre del mes.</para>
        /// </summary>
        public static String fcrFechaNombreMes(String tcrFormato, String tcrFecha)
        {
            String lcrValor = String.Empty;
            DateTime ldaFecha;
            // si es correcta seleccionar item
            if (DateTime.TryParse(tcrFecha, out ldaFecha))
            {
                var lcrMes = fcrComponenteFecha(ldaFecha, "MES");
                lcrValor = fcrFechaNombreMes(lcrMes);
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrFechaNombreMes(): Devuelve nombre del mes dada una fecha
        //------------------------------------------------------------
        #region fcrFechaNombreMes(): Devuelve el nombre del mes dada una fecha
        /// <summary>
        /// <para>fcrFechaNombreMes()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el nombre del mes dada una fecha</para>
        /// <para>PARAMETROS:</para>
        /// <para>tdaFecha:
        /// Cadena tipo fecha para devolver nombre del mes Ejemplo: 14/10/2011 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor carater correspondiente al nombre del mes.</para>
        /// </summary>
        public static String fcrFechaNombreMes(DateTime tdaFecha)
        {
            var lcrMes = fcrComponenteFecha(tdaFecha, "MES");
            String lcrValor = fcrFechaNombreMes(lcrMes);

            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrFechaNombreMes(): Devuelve nombre del mes segun numero
        //------------------------------------------------------------
        #region fcrFechaNombreMes(): Devuelve el nombre del mes
        /// <summary>
        /// <para>fcrFechaNombreMes()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve nombre del mes segun numero</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroMes: Numero del mes dado</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor carater o nombre correspondiente al mes.</para>
        /// </summary>
        public static String fcrFechaNombreMes(String tcrNumeroMes)
        {
            String lcrValor = String.Empty;
            int lnuMes = Convert.ToInt32(tcrNumeroMes);

            switch (lnuMes)
            {
                case 1:
                    lcrValor = "ENERO";
                    break;

                case 2:
                    lcrValor = "FEBRERO";
                    break;

                case 3:
                    lcrValor = "MARZO";
                    break;

                case 4:
                    lcrValor = "ABRIL";
                    break;

                case 5:
                    lcrValor = "MAYO";
                    break;

                case 6:
                    lcrValor = "JUNIO";
                    break;

                case 7:
                    lcrValor = "JULIO";
                    break;

                case 8:
                    lcrValor = "AGOSTO";
                    break;

                case 9:
                    lcrValor = "SEPTIEMBRE";
                    break;

                case 10:
                    lcrValor = "OCTUBRE";
                    break;

                case 11:
                    lcrValor = "NOVIEMBRE";
                    break;

                case 12:
                    lcrValor = "DICIEMBRE";
                    break;

            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuFechaLlaveIndiceRegistro(): Devuelve llave numerica fecha y hora
        //------------------------------------------------------------
        #region fnuFechaLlaveIndiceRegistro(): Devuelve una llave concatenando año mes dia y hora
        /// <summary>
        /// <para>fnuFechaLlaveIndiceRegistro()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Genera llave/indice segun fecha y hora del sistema para organizar los</para>
        /// <para>registros cronologicamente en las vistas de datos</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna llave numerica cronologica.</para>
        /// </summary>
        public static long fnuFechaLlaveIndiceRegistro()
        {
            var lnullaveIndice = fnuFechaLlaveIndiceRegistro(FdaFechaActual(), FdeHoraActualMilitar());

            return lnullaveIndice;
        }
        #endregion
        #region fnuFechaLlaveIndiceRegistro(): Devuelve una llave concatenando año mes dia y hora
        /// <summary>
        /// <para>fnuFechaLlaveIndiceRegistro()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Genera indice segun fecha y hora para organizar los</para>
        /// <para>registros cronologicamente en las vistas de datos</para>
        /// <para>PARAMETROS:</para>
        /// <para>tdaFecha: Fecha dada en formato dd/mm/aaaaa</para>
        /// <para>tduHora: Hora en formato militar</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna llave numerica cronologica.</para>
        /// </summary>
        public static long fnuFechaLlaveIndiceRegistro(DateTime tdaFecha, Decimal tduHora)
        {
            var lcrSeparadorDecimal = fcrLeerConfiguracionRegional("DECIMAL");
            var lcrFecha            = fcrConvertFecha(tdaFecha);
            String[] larArray       = (lcrFecha).Split("/".ToCharArray());

            var lcrDia = larArray[0].Trim().Length < 2 ? "0" + larArray[0].Trim() : larArray[0].Trim();
            var lcrMes = larArray[1].Trim().Length < 2 ? "0" + larArray[1].Trim() : larArray[1].Trim();
            var lcrAño = larArray[2].Trim().Substring(2, 2);

            var lcrllHora   = fcrCompletarFormatoHora(tduHora, lcrSeparadorDecimal);
            var lcrllaveAux = lcrAño + lcrMes + lcrDia + lcrllHora;

            var lnullaveIndice = Convert.ToInt64(lcrllaveAux);
            
            return lnullaveIndice;
        }
        #endregion
        //------------------------------------------------------------
        // fnuLlaveIdFecha(): Devuelve llave numerica fecha
        //------------------------------------------------------------
        #region fnuLlaveIdFecha(): Devuelve llave concatenando año mes dia desde la fecha actual
        /// <summary>
        /// <para>fnuFechaLlaveIndiceRegistro()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Genera una llave o indice numerico segun fecha actual del sitema</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna llave numerica concatenando año-mes-dia ejemplo: 20181026</para>
        /// </summary>
        public static long fnuLlaveIdFecha()
        {
            var lnullaveIndice = fnuLlaveIdFecha(FdaFechaActual()); 

            return lnullaveIndice;
        }
        #endregion
        #region fnuLlaveIdFecha(): Devuelve una llave concatenando año mes dia 
        /// <summary>
        /// <para>fnuLlaveIdFecha()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Genera una llave o indice  numerico segun fecha dada en parametro</para>
        /// <para>PARAMETROS:</para>
        /// <para>tdaFecha: Fecha dada en formato dd/mm/aaaaa</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Retorna llave numerica concatenando año-mes-dia ejemplo: 20181026</para>
        /// </summary>
        public static long fnuLlaveIdFecha(DateTime tdaFecha)
        {
            var lcrFecha = fcrConvertFecha(tdaFecha);
            String[] larArray = (lcrFecha).Split("/".ToCharArray());

            var lcrDia = larArray[0].Trim().Length < 2 ? "0" + larArray[0].Trim() : larArray[0].Trim();
            var lcrMes = larArray[1].Trim().Length < 2 ? "0" + larArray[1].Trim() : larArray[1].Trim();
            var lcrAño = larArray[2].Trim().Substring(0, 4);

            var lcrllaveAux = lcrAño + lcrMes + lcrDia;

            var lnullaveIndice = Convert.ToInt64(lcrllaveAux);

            return lnullaveIndice;
        }
        #endregion
        //------------------------------------------------------------
        // fcrCompletarFormatoHora(): Convertir formato hora a expresion numero tipo texto
        //------------------------------------------------------------
        #region fcrCompletarFormatoHora
        /// <summary>
        /// <para>fcrCompletarFormatoHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Convertir de formato hora a una expresion numero tipo texto</para>
        /// </summary>
        public static String fcrCompletarFormatoHora(Decimal tduHora, String tcrSeparador)
        {
            tduHora = tduHora == 0 ? Convert.ToDecimal("24") : tduHora;
            var lcrValor = String.Empty;
            var lcrComHora = fcrExtraerCompHora(tduHora.ToString(), "HH", "24", tcrSeparador);
            var lcrComMinuto = fcrExtraerCompHora(tduHora.ToString(), "MM", "24", tcrSeparador);

            if (lcrComHora.Trim().Length == 1) { lcrComHora = "0" + lcrComHora; }
            if (lcrComMinuto.Trim().Length == 1) { lcrComMinuto = "0" + lcrComMinuto; }

            lcrValor = lcrComHora + lcrComMinuto;

            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // FdaConcatenarFechaYHora(): Concatenar fecha y hora 
        //------------------------------------------------------------
        #region FdaConcatenarFechaYHora
        /// <summary>
        /// <para>FdaConcatenarFechaYHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Concatena la fecha dada en parametro con hora dada, devuelve una expresión tipo fecha con la hora incluida</para>
        /// </summary>
        public static DateTime FdaConcatenarFechaYHora(DateTime tdaFecha, decimal tduHora)
        {
            // separar horas y minutos
            var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            String[] larHora = tduHora.ToString().Split(lcrSeparadorDecimal.ToCharArray());

            var ldaFechaHora = new DateTime(tdaFecha.Year, tdaFecha.Month, tdaFecha.Day,
                             Convert.ToInt32(larHora[0]), Convert.ToInt32(larHora[1]), 0);
            return ldaFechaHora;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // fcrGenConsultaSql(): Generar consulta SQL 
        //------------------------------------------------------------
        #region fcrGenConsultaSqlBrowser(): Generar consulta SQL
        /// <summary>
        /// <para>fcrGenConsultaSql()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Generar string consulta SQL para los browser
        /// de busquedas acercadas
        /// <para>PARAMETROS:</para>
        /// <para>tcrtabla:
        /// Nombre de la tabla para la consulta a generar (opcional)</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve una cadena string con la expresion SQL generada.</para>
        /// </summary>
        public static string fcrGenConsultaSqlBrowser(string tcrtabla, string tcrTextBuscar, string tcrCondicional ,
                                                      string lcrConector, string tcrCamposBusq, string tcrfiltro)
        {
            var lcrLineaSql  = string.Empty;
            string lcrTablaMy=string.Empty;
            string lcrSqlP1  = string.Empty, lcrSqlP2 = string.Empty;
            string lcrSqlP3  = string.Empty, lcrSqlP4 = string.Empty;

            if (!string.IsNullOrEmpty(tcrtabla)) // si esta vacia es porque hay Select SQL
            {
                var lnuTam = tcrtabla.Trim().Length - 1;
                lcrTablaMy = tcrtabla.Trim().Substring(0, 1).ToUpper() + tcrtabla.Trim().Substring(1, lnuTam).ToLower();
            }
            //----------------------------------------------
            // Primera parte de linea SQL
            //----------------------------------------------
            if (fnuDevPosOcursElemento("SELECT", 1, tcrfiltro) > 0)
            {
                lcrSqlP1 = tcrfiltro;
            }
            else
            {
                lcrSqlP1 = "SELECT VALUE " + lcrTablaMy + " FROM " + lcrTablaMy + " AS " + lcrTablaMy;
            }

            //----------------------------------------------
            // Segunda parte de linea SQL WHERE
            //----------------------------------------------
            if (fnuDevPosOcursElemento("WHERE", 1, tcrfiltro) <= 0) 
            {
                if (!string.IsNullOrEmpty(tcrTextBuscar.Trim()) && !string.IsNullOrEmpty(tcrCamposBusq.Trim()))
                {
                    lcrSqlP2 = " WHERE ";
                }
                if (!string.IsNullOrEmpty(tcrfiltro))
                {
                    lcrSqlP2 = " WHERE ";
                }
            }
            //----------------------------------------------
            // Tercera Parte Condiciones de Busqueda adicionales
            //----------------------------------------------
            if (!string.IsNullOrEmpty(tcrTextBuscar.Trim()) && !string.IsNullOrEmpty(tcrCamposBusq.Trim()))
            {
                int i;
                int lnuTotElemtos = fnuContarElemListaString(",", tcrCamposBusq);
                string lcrCondicion = string.Empty;
                string lcrCampo = string.Empty;

                for (i = 1; i <= lnuTotElemtos; i++)
                {
                    lcrCampo = lcrTablaMy + "." + fuxExtraerElemento(i, ",", tcrCamposBusq).ToLower() + " like '%" + tcrTextBuscar.Trim() + "%'";
                    if (string.IsNullOrEmpty(lcrCondicion)) 
                    { 
                        lcrCondicion = lcrCampo; 
                    } 
                    else 
                    { 
                        lcrCondicion = lcrCondicion + " " + lcrConector.Trim().ToUpper() + " " + lcrCampo; 
                    }
                }
                lcrSqlP3 = "(" + lcrCondicion + ")";
                if (fnuDevPosOcursElemento("WHERE", 1, tcrfiltro) > 0) { lcrSqlP3 = " AND " + lcrSqlP3; }
            }
            //----------------------------------------------
            // Cuarta Parte  Filtro 
            //----------------------------------------------
            if (fnuDevPosOcursElemento("SELECT", 1, tcrfiltro) <= 0)
            {
                lcrSqlP4 = tcrfiltro; 
                if (!string.IsNullOrEmpty(tcrfiltro) && !string.IsNullOrEmpty(lcrSqlP3)) { lcrSqlP4 = " AND "+ tcrfiltro; }
            }
            lcrLineaSql = lcrSqlP1 + lcrSqlP2 + lcrSqlP3 + lcrSqlP4;
            return lcrLineaSql;
        }
        #endregion
        //------------------------------------------------------------
        // FUNCIONES GESTION DE HORAS CALCULOS Y VALIDACION
        //------------------------------------------------------------
        #region FUNCIONES GESTION DE HORAS CALCULOS Y VALIDACION
        //------------------------------------------------------------
        // flgValidaHora(): Verificar que sea una hora valida
        //------------------------------------------------------------
        #region flgValidaHora(): Verificar que sea una hora valida
        /// <summary>
        /// <para>flgValidaHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// una hora correcta en formato: 12 (hh:mm:am/pm) o formato milita
        /// 24 (hh:mm) 
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringHora:
        /// cadena de tipo string con texto a verificar</para>
        /// <para>tcrTipoFormato:
        /// parametro string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm)</para>
        /// <para>tcrSeparador:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve Verdadero cuando es una hora correcta
        /// devuelve falso cuando la cadena esta vacia o no es una hora valida segun formato.</para>
        /// </summary>
        public static bool flgValidaHora(String tcrStringHora, String tcrTipoFormato, String tcrSeparador)
        {
            if (tcrStringHora == null) { return false; }
            var llgValor = false;
            var lnuSumaError = 0;
            Char[] lcrCharSeparador = tcrSeparador.ToCharArray();
            String[] larHora = tcrStringHora.Split(lcrCharSeparador);
            // si es correcta genera el valor
            switch (tcrTipoFormato)
            {
                case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM (8 caracteres)
                    if (tcrStringHora.Trim().Length != 8 || larHora.Length != 3) // larHora debe tener tres componentes
                    {
                        lnuSumaError++;
                    }
                    else
                    {
                        // Validar componente hora 
                        if (flgSoloNumeros(larHora[0].Trim()))
                        {
                            if (Convert.ToInt32(larHora[0].Trim()) < 1 || Convert.ToInt32(larHora[0]) > 12) { lnuSumaError++; }
                        }
                        else
                        {
                            lnuSumaError++;
                        }
                        // Validar componente minutos
                        if (flgSoloNumeros(larHora[1].Trim()))
                        {
                            if (Convert.ToInt32(larHora[1]) < 0 || Convert.ToInt32(larHora[1]) > 59) { lnuSumaError++; }
                        }
                        else
                        {
                            lnuSumaError++;
                        }
                        // Validar componente AM/PM 
                        if (larHora[2].Trim().ToUpper() != "AM" && larHora[2].Trim().ToUpper() != "PM") { lnuSumaError++; }
                    }
                    if (lnuSumaError == 0) { llgValor = true; }
                    break;

                case "24": // Formato 
                    if (larHora.Length != 2) // larHora debe tener dos componentes
                    {
                        lnuSumaError++;
                    }
                    else
                    {
                        // Validar componente hora 
                        if (flgSoloNumeros(larHora[0].Trim()))
                        {
                            if (Convert.ToInt32(larHora[0].Trim()) < 0 || Convert.ToInt32(larHora[0].Trim()) > 23) { lnuSumaError++; }
                        }
                        else
                        {
                            lnuSumaError++;
                        }
                        // Validar componente minutos
                        if (flgSoloNumeros(larHora[1].Trim()))
                        {
                            if (Convert.ToInt32(larHora[1].Trim()) < 0 || Convert.ToInt32(larHora[1].Trim()) > 59) { lnuSumaError++; }
                        }
                        else
                        {
                            lnuSumaError++;
                        }
                    }
                    if (lnuSumaError == 0) { llgValor = true; }
                    break;
            }
            return llgValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrValidaHoraTexto(): Verificar que sea una hora valida
        //------------------------------------------------------------
        #region fcrValidaHoraTexto(): Verificar que sea una hora valida
        /// <summary>
        /// <para>fcrValidaHoraTexto()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Verificar si el parametro tcrTexto contiene  
        /// una hora correcta en formato: 12 (hh:mm:am/pm) o formato milita
        /// 24 (hh:mm) 
        /// <para>PARAMETROS:</para>
        /// <para>tcrRequerida:
        /// Para realizar vaidacion obligatoria o se acepta hora vacia 
        /// true = Validacion obligatoria // false = Se aceptan hora vacia </para>
        /// <para>tcrStringHora:
        /// cadena de tipo string con texto a verificar</para>
        /// <para>tcrTipoFormato:
        /// parametro string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm)</para>
        /// <para>tcrSeparador:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>tcrMsgTitulo:
        /// Cadena de tipo string con texto titulo para conactenear mensaje de retorno</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve vacio cuando es una Hora correcta
        /// devuelve una cadena de texto con el mensaje de error cuando
        /// la cadena esta vacia o no es una hora correcta.</para>
        /// </summary>
        public static String fcrValidaHoraTexto(bool tlgRequerida, String tcrStringHora, String tcrTipoFormato, String tcrSeparador, String tcrMsgTitulo)
        {
            var lcrValorReturn=String.Empty;
            var lcrVal1 = tcrSeparador + tcrSeparador; // equivalente una hora "::"
            var lcrVal2 = tcrSeparador +"  "+ tcrSeparador; // equivalente una hora  ":  :"
            if (tlgRequerida == true)
            {
                if (string.IsNullOrWhiteSpace(tcrStringHora) ||
                    tcrStringHora.Trim() == lcrVal1 || tcrStringHora.Trim() == lcrVal2)
                {
                    lcrValorReturn = tcrMsgTitulo + ": Es requerida";
                }
                else
                {
                    if (!flgValidaHora(tcrStringHora, tcrTipoFormato, tcrSeparador))
                    {
                        lcrValorReturn = tcrMsgTitulo + ": Valor hora no es valida";
                    }
                }
            }
            else 
            {
                if (!string.IsNullOrWhiteSpace(tcrStringHora))
                {
                    if (tcrStringHora.Trim() != lcrVal1 && tcrStringHora.Trim() != lcrVal2)
                    {
                        if (!flgValidaHora(tcrStringHora, tcrTipoFormato, tcrSeparador))
                        {
                            lcrValorReturn = tcrMsgTitulo + ": Valor hora no es valida";
                        }
                    }
                }
            }
            return lcrValorReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fcrExtraerCompHora(): devuelve un componente de la hora 
        //------------------------------------------------------------
        #region fcrExtraerCompHora(): devuelve un componente de la hora
        /// <summary>
        /// <para>fnuExtraerCompHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve un componente de la hora dada en el parametro tcrHora
        /// en formato: 12 = (hh:mm:am/pm) o formato milita 24=(hh:mm) 
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringHora:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tcrComponente:
        /// Componente a delveolver segun el formato "HH" = Hora "MM"= Minutos "AMPM"= Componente AM/PM 
        /// (solo para formato 12 (hh:mm:am/pm)) </para>
        /// <para>tcrTipoFormato:
        /// parametro tipo string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm)</para>
        /// <para>tcrSeparador:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve un valor tipo string cuando el formato hora es correcto 
        /// devuelve vacio cuando la cadena esta vacia o no es una hora valida segun formato.</para>
        /// </summary>
        public static string fcrExtraerCompHora(String tcrStringHora, String tcrComponente, String tcrTipoFormato, String tcrSeparador)
        {
            var lcrValor = String.Empty;

            if (flgValidaHora(tcrStringHora, tcrTipoFormato, tcrSeparador))
            {
                Char[] lcrCharSeparador = tcrSeparador.ToCharArray();
                String[] larHora = tcrStringHora.Split(lcrCharSeparador);
                switch (tcrTipoFormato)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM (8 caracteres)
                        switch (tcrComponente.ToUpper())
                        {
                            case "HH":
                                lcrValor = larHora[0].Trim();
                                lcrValor = lcrValor.Length == 1 ? "0" + lcrValor : lcrValor;
                                break;

                            case "MM":
                                lcrValor = larHora[1].Trim();
                                lcrValor = lcrValor.Length == 1 ? lcrValor + "0" : lcrValor;
                                break;

                            case "AMPM":
                                lcrValor = larHora[2].Trim().ToUpper();
                                break;
                        }
                        break;

                    case "24": // Formato 
                        switch (tcrComponente)
                        {
                            case "HH":
                                lcrValor = larHora[0].Trim();
                                lcrValor = lcrValor.Length == 1 ? "0" + lcrValor : lcrValor;
                                break;

                            case "MM":
                                lcrValor = larHora.Length > 1 ? larHora[1].Trim(): "0";
                                lcrValor = lcrValor.Length == 1 ? lcrValor + "0" : lcrValor;
                                break;
                        }
                        break;
                }
            }
            //lcrValor = lcrValor.Length == 1 ? "0" + lcrValor : lcrValor;

            return lcrValor;
        }

        public static int fnuExtraerCompHora(String tcrStringHora, String tcrComponente, String tcrTipoFormato, String tcrSeparador)
        {
            int lnuValor = 0;
            if (flgValidaHora(tcrStringHora, tcrTipoFormato, tcrSeparador))
            {
                switch (tcrComponente.ToUpper())
                {
                    case "HH":
                        lnuValor = Convert.ToInt32(fcrExtraerCompHora(tcrStringHora, "HH", tcrTipoFormato, tcrSeparador));
                        break;

                    case "MM":
                        lnuValor = Convert.ToInt32(fcrExtraerCompHora(tcrStringHora, "HH", tcrTipoFormato, tcrSeparador));
                        break;

                    default:
                        lnuValor = -1;
                        break;
                }
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrConvierteHora(): Convierte formato de hora
        //------------------------------------------------------------
        #region fcrConvierteHora(): Convierte formato de hora
        /// <summary>
        /// <para>fcrConvierteHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devuelve hora dada en el parametro tcrStringHora convertida al 
        /// formato destino tcrFormatoDestino: 12 = (hh:mm:am/pm) formato milita 24=(hh:mm) 
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringHora:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tcrFormatoOrigen:
        /// parametro tipo string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dado tcrStringHora</para>
        /// <para>tcrSeparador:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>tcrSeparadorDestino:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo string cuando el formato hora es correcto 
        /// El valor devuelto es formato contrario al formato origen "12" -> 24 // "24" -> 12 
        /// devuelve vacio cuando la cadena esta vacia o no es una hora valida segun formato.</para>
        /// </summary>
        public static string fcrConvierteHora(String tcrStringHora, String tcrFormatoOrigen,
                                              String tcrSeparador, String tcrSeparadorDestino)
        {
            var lcrValor     = String.Empty;
            var lcrComHora   = String.Empty;
            var lcrComMinuto = String.Empty;
            var lcrTipoAmPm  = String.Empty;
            var lcrNewHora   = String.Empty;

            // Forzar a cambiar el separador decimal para el formato hora militar
            if (tcrFormatoOrigen == "24")
            {
                tcrStringHora = fcrRemplazarChrDecimal(tcrStringHora, tcrSeparador);
            }

            if (flgValidaHora(tcrStringHora, tcrFormatoOrigen, tcrSeparador))
            {
                Char[] lcrCharSeparador = tcrSeparador.ToCharArray();
                String[] larHora = tcrStringHora.Split(lcrCharSeparador);
                switch (tcrFormatoOrigen)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM devolver formato militar

                        lcrComHora = fcrExtraerCompHora(tcrStringHora, "HH", tcrFormatoOrigen, tcrSeparador);
                        lcrComMinuto = fcrExtraerCompHora(tcrStringHora, "MM", tcrFormatoOrigen, tcrSeparador);
                        lcrTipoAmPm = fcrExtraerCompHora(tcrStringHora, "AMPM", tcrFormatoOrigen, tcrSeparador);

                        if (lcrTipoAmPm == "AM")
                        {
                            lcrNewHora = lcrComHora;
                            if (lcrComHora == "12") { lcrNewHora = "00"; }
                        }
                        else
                        {
                            lcrNewHora = (Convert.ToInt32(lcrComHora) + 12).ToString().Trim();
                            if (lcrComHora == "12") { lcrNewHora = lcrComHora; }
                        }

                        if (lcrNewHora.Trim().Length == 1) { lcrNewHora = "0" + lcrNewHora; }
                        lcrValor = lcrNewHora + tcrSeparadorDestino + lcrComMinuto;
                        break;

                    case "24": // Formato 24 horas ejemplo: 17:12 devolver formato AM/PM

                        lcrComHora = fcrExtraerCompHora(tcrStringHora, "HH", tcrFormatoOrigen, tcrSeparador);
                        lcrComMinuto = fcrExtraerCompHora(tcrStringHora, "MM", tcrFormatoOrigen, tcrSeparador);

                        if (Convert.ToInt32(lcrComHora) < 12) // AM
                        {
                            lcrTipoAmPm = "AM";
                            lcrNewHora = lcrComHora;
                            if (Convert.ToInt32(lcrNewHora) == 0) { lcrNewHora = "12"; }
                        }
                        else
                        {
                            lcrTipoAmPm = "PM";
                            lcrNewHora = (Convert.ToInt32(lcrComHora) - 12).ToString().Trim();
                            if (lcrComHora == "12") { lcrNewHora = lcrComHora; }
                        }
                        lcrValor = lcrNewHora + tcrSeparadorDestino + lcrComMinuto;
                        if (lcrNewHora.Trim().Length == 1) { lcrNewHora = "0" + lcrNewHora; }
                        if (lcrComMinuto.Trim().Length == 1) { lcrComMinuto = lcrComMinuto + "0"; }
                        lcrValor = lcrNewHora + tcrSeparadorDestino + lcrComMinuto + tcrSeparadorDestino + lcrTipoAmPm;
                        break;
                }
            }
            else
            {
                switch (tcrFormatoOrigen)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM devolver formato militar
                        lcrValor = "0";
                        break;

                    case "24": // Formato 24 horas ejemplo: 17:12 devolver formato AM/PM

                        lcrValor = "00" + tcrSeparadorDestino + "00" + tcrSeparadorDestino + "AM";
                        break;
                }

            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrGenSiguienteHora(): Genera la hora siguiente 
        //------------------------------------------------------------
        #region fcrGenSiguienteHora(): Genera la hora siguiente
        /// <summary>
        /// <para>fcrConvierteHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve siguiente hora generada desde tcrStringHora y sumandole minutos dados 
        /// en el parametro tnuMinutosSuma, convertida al formato tcrFormatoDestino:
        /// 12 = (hh:mm:am/pm) formato milita 24=(hh:mm) 
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringHora:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tnuMinutosSuma:
        /// Valor numerio en minutos para sumar y generar nueva hora</para>
        /// <para>tcrFormatoOrigen:
        /// parametro tipo string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dado tcrStringHora</para>
        /// <para>tcrFormatoDestino:
        /// parametro tipo string para indicar tipo formato: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) para la nueva hora</para>
        /// <para>tcrSeparadorOrigen:
        /// parametro string para indicar caracter separador del formato hora inicial
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>tcrSeparadorDestino:
        /// parametro string para indicar caracter separador del formato
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo string cuando el formato hora es correcto 
        /// El valor devuelto es formato contrario al formato origen "12" -> 24 // "24" -> 12 
        /// devuelve vacio cuando la cadena esta vacia o no es una hora valida segun formato.</para>
        /// </summary>
        public static string fcrGenSiguienteHora(String tcrStringHora, int tnuMinutosSuma,
                                                 String tcrFormatoOrigen, String tcrFormatoDestino,
                                                 String tcrSeparadorOrigen, String tcrSeparadorDestino)
        {
            var lcrValor = String.Empty;
            var lcrComHora = String.Empty;
            var lcrComMinuto = String.Empty;
            var lcrTipoAmPm = String.Empty;
            var lcrNewHora = String.Empty;
            var lcrNewMinuto = String.Empty;
            var lcrHoraMilitar = String.Empty;
            int lnuSumaHora = 0;

            if (flgValidaHora(tcrStringHora, tcrFormatoOrigen, tcrSeparadorOrigen))
            {
                // Separar componentes de la hora
                switch (tcrFormatoOrigen)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM 
                        lcrHoraMilitar = fcrConvierteHora(tcrStringHora, "12", tcrSeparadorOrigen, tcrSeparadorOrigen);
                        break;

                    case "24": // Formato 24 horas ejemplo: 17:12 
                        lcrHoraMilitar = tcrStringHora;
                        break;
                }
                // se hace el proceso en formato militar (24 horas)
                lcrComHora = fcrExtraerCompHora(lcrHoraMilitar, "HH", "24", tcrSeparadorOrigen);
                lcrComMinuto = fcrExtraerCompHora(lcrHoraMilitar, "MM", "24", tcrSeparadorOrigen);
                lnuSumaHora = (int)((Convert.ToInt32(lcrComMinuto) + tnuMinutosSuma) / 60);
                lcrNewMinuto = (Math.Abs((lnuSumaHora * 60) - (Convert.ToInt32(lcrComMinuto) + tnuMinutosSuma))).ToString().Trim(); // valor absoluto
                lcrNewHora = (Convert.ToInt32(lcrComHora) + lnuSumaHora).ToString().Trim();
                if (Convert.ToInt32(lcrNewHora) > 24)
                {
                    lcrNewHora = (lnuSumaHora - (24 - Convert.ToInt32(lcrComHora))).ToString().Trim();
                }
                else if (Convert.ToInt32(lcrNewHora) == 24)
                {
                    lcrNewHora = "00"; // 12 AM hora cero militar 
                }
                if (lcrNewHora.Trim().Length == 1) { lcrNewHora = "0" + lcrNewHora; }
                if (lcrNewMinuto.Trim().Length == 1) { lcrNewMinuto = "0" + lcrNewMinuto; }
                lcrValor = lcrNewHora + tcrSeparadorDestino + lcrNewMinuto;
                if (tcrFormatoDestino == "12")
                {
                    lcrValor = fcrConvierteHora(lcrValor, "24", tcrSeparadorDestino, tcrSeparadorDestino);
                }

            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrGenLlaveRangoFechaHora(): Genera llave para rango de horas
        //------------------------------------------------------------
        #region fcrGenLlaveRangoFechaHoraActual(): Genera llave para rango de horas
        /// <summary>
        /// <para>fcrGenLlaveRangoFechaHoraActual()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve una llave de tipo string, correspondiente a la concatenacion del 
        /// año+mes+dia+horamilitar+minutos, de fecha y hora actual del sistema ejemplo:
        /// fecha = (15/03/2012) Hora 07:25:AM  -> 1203150725
        /// <para>PARAMETROS:</para>
        /// <para>Devuelve valor tipo string cuando el formato de fecha y hora es correcto 
        /// devuelve o cuando fecha y hora estan vacias o no son validas segun formato.</para>
        /// </summary>
        public static String fcrGenLlaveRangoFechaHoraActual()
        {
            var lcrValor = fcrGenLlaveRangoFechaHora(fcrFechaActual(), "DMY", "/",fcrHoraActual("12",":"), "12", ":");
            return lcrValor;
        }
        #endregion
        #region fcrGenLlaveRangoFechaHora(): Genera llave para rango de horas
        /// <summary>
        /// <para>fcrGenLlaveRangoFechaHora()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve una llave de tipo string, correspondiente a la concatenacion del 
        /// año+mes+dia+horamilitar+minutos, con base a los parametros dados ejemplo:
        /// fecha = (15/03/2012) Hora 07:25:AM  -> 1203150725
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringFecha:
        /// cadena de tipo string que contiene la fecha segun formato tcrFormatoFecha
        /// ejemplo: (15/03/2012) (2012/02/25)</para>
        /// <para>tcrFormatoFecha:
        /// Formato de la string de fecha DMY = (05/03/2013) , YMD=(2012/02/25)</para>
        /// <para>tcrSeparadorFecha:
        /// Caracter separador del formato fecha ejemplo: "/"=(05/03/2013) "-"=(15-12-2012)</para>
        /// <para>tcrStringHora:
        /// cadena de tipo string que contiene la expresion tipo hora</para>
        /// <para>tcrFormatoHora:
        /// parametro tipo string para indicar tipo formato de la hora: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dado tcrStringHora</para>
        /// <para>tcrSeparadorHora:
        /// parametro string para indicar caracter separador del formato de hora
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo string cuando el formato de fecha y hora es correcto 
        /// devuelve o cuando fecha y hora estan vacias o no son validas segun formato.</para>
        /// </summary>
        public static string fcrGenLlaveRangoFechaHora(String tcrStringFecha, String tcrFormatoFecha, String tcrSeparadorFecha,
                                                 String tcrStringHora, String tcrFormatoHora, String tcrSeparadorHora)
        {
            var lcrValor = String.Empty;
            var lcrHoraMilitar = String.Empty;

            if (flgValidaFecha(tcrFormatoFecha, tcrSeparadorFecha, tcrStringFecha) &&
                flgValidaHora(tcrStringHora, tcrFormatoHora, tcrSeparadorHora))
            {
                // Convertir Hora cuando sea requerido
                switch (tcrFormatoHora)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM 
                        lcrHoraMilitar = fcrConvierteHora(tcrStringHora, "12", tcrSeparadorHora, tcrSeparadorHora);
                        break;

                    case "24": // Formato 24 horas ejemplo: 17:12 
                        lcrHoraMilitar = tcrStringHora;
                        break;
                }
                // se hace el proceso en formato militar (24 horas)
                var lcrComHora = fcrExtraerCompHora(lcrHoraMilitar, "HH", "24", tcrSeparadorHora);
                var lcrComMinuto = fcrExtraerCompHora(lcrHoraMilitar, "MM", "24", tcrSeparadorHora);

                if (lcrComHora.Trim().Length == 1) { lcrComHora = "0" + lcrComHora; }
                if (lcrComMinuto.Trim().Length == 1) { lcrComMinuto = lcrComMinuto + "0"; }

                var lcrDia = fcrElementoFecha("DIA", tcrFormatoFecha, tcrSeparadorFecha, tcrStringFecha);
                var lcrMes = fcrElementoFecha("MES", tcrFormatoFecha, tcrSeparadorFecha, tcrStringFecha);
                var lcrAño = fcrElementoFecha("AÑO", tcrFormatoFecha, tcrSeparadorFecha, tcrStringFecha);

                lcrValor = lcrAño.Trim().Substring(2, 2) + lcrMes.Trim() + lcrDia.Trim() + lcrComHora.Trim() + lcrComMinuto.Trim();
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuFechasCalHorasMinutos(): Horas o minutos desde rango fecha 
        //------------------------------------------------------------
        #region fnuFechasCalHorasMinutos(): Horas o minutos desde ranngo fecha
        /// <summary>
        /// <para>fnuFechasCalHorasMinutos()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve una valor tipo numerico (int), las horas o minutos existentes dentro
        /// del rango  de fechas y horas inicio y fin dadas en parametros
        /// <para>PARAMETROS:</para>
        /// <para>tdaFechaInicio:
        /// Parametro tipo fecha (DateTime) que contiene la fecha inicio del rango 
        /// ejemplo: (15/03/2012)</para>
        /// <para>tdaFechaFin:
        /// Parametro tipo fecha (DateTime) que contiene la fecha fin del rango 
        /// ejemplo: (16/03/2012)</para>
        /// <para>tcrHoraInicio:
        /// Cadena de tipo string que contiene la hora inicial desde fecha incio
        /// en formatode dado segun parametro tcrFormatoHora </para>
        /// <para>tcrHoraFin:
        /// Cadena de tipo string que contiene la hora finalizacion fecha fin del rango
        /// en formatode dado segun parametro tcrFormatoHora</para>
        /// <para>tcrFormatoHora:
        /// parametro tipo string para indicar tipo formato de la hora: "12" = (hh:mm:am/pm) 
        /// formato milita "24" = (hh:mm) en que esta dados: tcrHoraInicio y tcrHoraFin</para>
        /// <para>tcrSeparadorHora:
        /// parametro string para indicar caracter separador del formato de hora
        /// ":" ejemplo = 03:15:AM formato militar 15:14 </para>
        /// <para>tcrTipoRespuesta:
        /// Indica tipo respuesta a devolver "H" = Valor en horas "M" = Valor en Minutos</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo numerico que representa las horas o minutos contenidos 
        /// dentro del rango de fechas y horas dadas.</para>
        /// </summary>
        public static int fnuFechasCalHorasMinutos(DateTime tdaFechaInicio, DateTime tdaFechaFin,
                                                   String tcrHoraInicio, String tcrHoraFin,
                                                   String tcrFormatoHora, String tcrSeparadorHora, String tcrTipoRespuesta)
        {
            int lcrValor = 0;
            var lcrHoraMilIni = String.Empty;
            var lcrHoraMilFin = String.Empty;

            if (!String.IsNullOrWhiteSpace(tdaFechaInicio.ToShortDateString()) &&
                !String.IsNullOrWhiteSpace(tdaFechaFin.ToShortDateString()) &&
                flgValidaHora(tcrHoraInicio, tcrFormatoHora, tcrSeparadorHora) &&
                flgValidaHora(tcrHoraFin, tcrFormatoHora, tcrSeparadorHora))
            {
                // Convertir Hora cuando sea requerido
                switch (tcrFormatoHora)
                {
                    case "12": // Formato 12 horas AM/PM ejemplo: 07:12:PM 
                        lcrHoraMilIni = fcrConvierteHora(tcrHoraInicio, "12", tcrSeparadorHora, tcrSeparadorHora);
                        lcrHoraMilFin = fcrConvierteHora(tcrHoraFin, "12", tcrSeparadorHora, tcrSeparadorHora);
                        break;

                    case "24": // Formato 24 horas ejemplo: 17:12 
                        lcrHoraMilIni = tcrHoraInicio;
                        lcrHoraMilFin = tcrHoraFin;
                        break;
                }
                // se hace el proceso en formato militar (24 horas)
                var lcrHoraIni      = Convert.ToInt32(fcrExtraerCompHora(lcrHoraMilIni, "HH", "24", tcrSeparadorHora));
                var lcrMinutosIni   = Convert.ToInt32(fcrExtraerCompHora(lcrHoraMilIni, "MM", "24", tcrSeparadorHora));
                var lcrHoraFin      = Convert.ToInt32(fcrExtraerCompHora(lcrHoraMilFin, "HH", "24", tcrSeparadorHora));
                var lcrMinutosFin   = Convert.ToInt32(fcrExtraerCompHora(lcrHoraMilFin, "MM", "24", tcrSeparadorHora));
                // Generar valores
                if (tdaFechaInicio.ToShortDateString() == tdaFechaFin.ToShortDateString())
                {
                    lcrValor = ((lcrHoraFin * 60) + lcrMinutosFin) - ((lcrHoraIni * 60) + lcrMinutosIni);
                }
                else
                {
                    var lnuCal01 = (24 * 60) - ((lcrHoraIni * 60) + lcrMinutosIni);
                    var lnuCal02 = ((lcrHoraFin * 60) + lcrMinutosFin);
                    var lnuCal03 = (((tdaFechaFin.Subtract(tdaFechaInicio)).Days - 1) * 24) * 60;
                    lcrValor = lnuCal01 + lnuCal02 + lnuCal03;
                }
                if (tcrTipoRespuesta == "H") { lcrValor = (int)(lcrValor / 60); }
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcrHoraActual(): Horas actual del sistema
        //------------------------------------------------------------
        #region fcrHoraActual(): Para captura hora actual
        /// <summary>
        /// <para>Devuelve la hora actual del sistema en formato 12 o 24 horas</para>
        /// <para>Ejemplo formato 12 Horas: 01:25:PM </para>
        /// <para>Ejemplo formato 24 Horas: 13.25 </para>
        /// <para>Retorna un valor de tipo texto</para>
        /// </summary>
        public static String fcrHoraActual(String tcrFormato, String tcrSeparadorDestino)
        {
            String lcrHora = fcrHoraActual(tcrSeparadorDestino);

            if (lcrHora.Length > 5 && tcrFormato == "24") // esta en formato 11:12:am
            {
                // convertir a hora militar
                lcrHora = fcrConvierteHora(lcrHora, "12", tcrSeparadorDestino, tcrSeparadorDestino);
            }
            else if (lcrHora.Length <= 5 && tcrFormato == "12")
            {
                lcrHora = fcrConvierteHora(lcrHora, "24", tcrSeparadorDestino, tcrSeparadorDestino);
            }
            return lcrHora;
        }
        #endregion
        #region fcrHoraActual(): Para captura hora actual del sistema
        /// <summary>
        /// <para>Devuelve la hora actual segun formato configurado del sistema (12 horas o Militar 24)</para>
        /// <para>Retorna un valor de tipo texto</para>
        /// </summary>
        public static String fcrHoraActual(String tcrSeparadorDestino)
        {
            var lcrFormatos = "hh:mm tt-hh:mm:tt-h:mm tt-h:mm:tt";
            var lcrForamto = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern;
            if (!lcrFormatos.Contains(lcrForamto))
            {
                MessageBox.Show("El formato de la hora del sistema no es adecuado, se debe configurar en formato de 12 horas (AM/PM).");
            }
            var lcrHora = DateTime.Now.ToShortTimeString().Trim().ToUpper();

            lcrHora = lcrHora.Replace("A M", "AM");
            lcrHora = lcrHora.Replace("A M.", "AM");
            lcrHora = lcrHora.Replace("A. M", "AM");
            lcrHora = lcrHora.Replace("A. M.", "AM");
            lcrHora = lcrHora.Replace("A.M", "AM");
            lcrHora = lcrHora.Replace("A.M.", "AM");
            lcrHora = lcrHora.Replace("AM.", "AM");
            lcrHora = lcrHora.Replace("P M", "PM");
            lcrHora = lcrHora.Replace("P M.", "PM");
            lcrHora = lcrHora.Replace("P. M", "PM");
            lcrHora = lcrHora.Replace("P. M.", "PM");
            lcrHora = lcrHora.Replace("P.M", "PM");
            lcrHora = lcrHora.Replace("P.M.", "PM");
            lcrHora = lcrHora.Replace("PM.", "PM");
            lcrHora = lcrHora.Replace("PM.", "PM");
            lcrHora = lcrHora.Replace(" ", ":");
            var lcrHoraOk = String.Empty;

            // Hora formato 12 horas
            Regex lcrValidText1 = new Regex("^(?:0?[0-9]|1[0-2]).[0-5][0-9].[aApP][mM]$"); //este es general
            Regex lcrValidText2 = new Regex("^(?:0?[0-9]|1[0-2]).[0-5][0-9].[A.m.]|[a.m.]|[P.m.]|[p.m.]|[A.M.]|[P.M.]$"); //este es general
            //---------------------------------------------------
            // Primera validacion general para saber formato hora 
            //---------------------------------------------------
            if (lcrValidText1.IsMatch(lcrHora) || lcrValidText2.IsMatch(lcrHora))
            {
                var llgOk = false;
                //---------------------------------------------------
                // Hora 12 con separador y am/pm  ejemplo: 10/45/pm - 12 15 Am - 05,10,Pm
                //---------------------------------------------------
                #region Hora 12 con separador espacio o (:.,-) AM/PM
                lcrValidText1 = new Regex("^(?:0?[0-9]|1[0-2]).[0-5][0-9].[aApP][mM]$");
                if (lcrValidText1.IsMatch(lcrHora))
                {
                    llgOk = true;
                    String[] larValores;
                    String lcrSepara = fcrCharSeparadorHora(lcrHora);
                    lcrSepara = lcrSepara == "E" ? " " : lcrSepara;

                    larValores = lcrHora.Split(lcrSepara.ToCharArray());

                    larValores[0] = fcrComplementoHora(larValores[0]);
                    lcrHoraOk = larValores[0] + tcrSeparadorDestino + larValores[1] + tcrSeparadorDestino + larValores[2].ToUpper();
                }
                #endregion
                //---------------------------------------------------
                // Hora 12 con espacio y a.m./p.m. ejemplo: 10:45 p.m. - 12:15 A.m. - 05,10 P.m
                //---------------------------------------------------
                #region Hora 12 con separador espacio o (:.,-) a.m./p.m.
                lcrValidText1 = new Regex(@"^(?:0?[0-9]|1[0-2].[0-5][0-9]+\s)[A.m.]|[a.m.]|[P.m.]|[p.m.]|[A.M.]|[P.M.]$");
                if (lcrValidText1.IsMatch(lcrHora) && llgOk == false)
                {
                    llgOk = true;
                    String[] larValores;
                    String lcrSepara = " ";
                    String lcrValAmPm = String.Empty;
                    //- Primero separa desde el espacio
                    larValores = lcrHora.Split(lcrSepara.ToCharArray());

                    lcrValAmPm = larValores[1];
                    // Separar la hora y minutos
                    lcrSepara = fcrCharSeparadorHora(larValores[0]);
                    larValores = larValores[0].Split(lcrSepara.ToCharArray());
                    // 
                    lcrValAmPm = flgExisteSubCadenaString("A", lcrValAmPm) == true ? "AM" : "PM";

                    larValores[0] = fcrComplementoHora(larValores[0]);
                    lcrHoraOk = larValores[0] + tcrSeparadorDestino + larValores[1] + tcrSeparadorDestino + lcrValAmPm;
                }
                #endregion
                //---------------------------------------------------
                // Hora 12 con separado y a.m./p.m. ejemplo: 10:45:p.m. - 12 15 A.m. - 05,10,P.m
                //---------------------------------------------------
                #region Hora 12 con separador espacio o (:.,-) a.m./p.m.
                lcrValidText1 = new Regex("^(?:0?[0-9]|1[0-2]).[0-5][0-9].[A.m.]|[a.m.]|[P.m.]|[p.m.]|[A.M.]|[P.M.]$");
                if (lcrValidText1.IsMatch(lcrHora) && llgOk == false)
                {
                    llgOk = true;
                    String[] larValores;
                    String lcrSepara = flgExisteSubCadenaString(" ", lcrHora) == true ? " " : "X";

                    // Buscar cual es el caracte que separa
                    if (lcrSepara == "X")
                    {
                        lcrSepara = fcrCharSeparadorHora(lcrHora);
                    }
                    larValores = lcrHora.Split(lcrSepara.ToCharArray());

                    larValores[2] = flgExisteSubCadenaString("A", larValores[2]) == true ? "AM" : "PM";

                    larValores[0] = fcrComplementoHora(larValores[0]);
                    lcrHoraOk = larValores[0] + tcrSeparadorDestino + larValores[1] + tcrSeparadorDestino + larValores[2].ToUpper();
                }
                #endregion
            }
            else
            {
                //---------------------------------------------------
                // Hora formato militar general 
                //---------------------------------------------------
                #region Hora formato militar general
                lcrValidText1 = new Regex("^(?:0?[0-9]|1[0-9]|2[0-3]).[0-5][0-9]$");
                if (lcrValidText1.IsMatch(lcrHora))
                {
                    //var lcrSeparador = fcrLeerConfiguracionRegional("DECIMAL");
                    String[] larValores;
                    String lcrSepara = fcrCharSeparadorHora(lcrHora);
                    lcrSepara = lcrSepara == "E" ? " " : lcrSepara;

                    larValores = lcrHora.Split(lcrSepara.ToCharArray());
                    lcrHoraOk = larValores[0] + tcrSeparadorDestino + larValores[1];
                }
                #endregion
            }

            return lcrHoraOk;
        }
        private static String fcrComplementoHora(String tcrValorHora)
        {
            tcrValorHora = tcrValorHora.Trim();
            var lcrValor = tcrValorHora.Length == 1 ? "0" + tcrValorHora : tcrValorHora;
            return lcrValor;
        }
        #endregion
        #region fdeHoraActualMilitar(): Para captura hora actual enb formato militar
        /// <summary>
        /// <para>Devuelve la hora actual del sistema en formato 24 horas (Militar)</para>
        /// <para>Ejemplo formato 24 Horas: 13.25 </para>
        /// <para>Retorna un valor de tipo Decimal</para>
        /// </summary>
        public static decimal FdeHoraActualMilitar()
        {
            var _lcrSeparator = fcrLeerConfiguracionRegional("DECIMAL");
            var _lcrTime = Convert.ToDecimal(DateTime.Now.ToString("HH" + _lcrSeparator + "mm"));

            return _lcrTime;
        }
        #endregion
        //------------------------------------------------------------
        // fcrCharSeparadorHora(): Devolver el caracter separador de la hora
        //------------------------------------------------------------
        #region fcrCharSeparadorHora(): Devolver el caracter separador de la hora
        /// <summary>
        /// Devulve el caracter separador de la hora, cuando el separador es un espacio en blanco 
        /// devuelve "E"
        /// </summary>
        public static String fcrCharSeparadorHora(String tcrHora)
        {
            String lcrSepara = flgExisteSubCadenaString(" ", tcrHora) == true ? "E" : "X";

            // Buscar cual es el caracte que separa
            if (lcrSepara == "X")
            {
                if (flgExisteSubCadenaString(":", tcrHora) == true) { lcrSepara = ":"; }
                if (flgExisteSubCadenaString(".", tcrHora) == true) { lcrSepara = "."; }
                if (flgExisteSubCadenaString(",", tcrHora) == true) { lcrSepara = ","; }
                if (flgExisteSubCadenaString("-", tcrHora) == true) { lcrSepara = "-"; }
                if (flgExisteSubCadenaString("_", tcrHora) == true) { lcrSepara = "_"; }
                if (flgExisteSubCadenaString("/", tcrHora) == true) { lcrSepara = "/"; }
            }

            return lcrSepara;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // fcrLeerConfiguracionRegional(): Leer parametros Regionales del Sistem
        //------------------------------------------------------------
        #region fcrLeerConfiguracionRegional(): Leer parametros Regionales del Sistem
        /// <summary>
        /// <para>fcrLeerConfiguracionRegional()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Devulve parametros de la configuracion regional de Windows tales como 
        /// Caracter usado para separar decimales, tipo fecha del sistema y otros
        /// <para>PARAMETROS:</para>
        /// <para>tcrLlaveKey:
        /// Recibe el nombre de la llave de configuracion regional que se desea obtener
        /// ejemplo: "DECIMAL" -> devuelve el caracter que se usa para separar cifras decimales</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor tipo string que representa la peticion del parametro regional,
        /// devuelve vacio cuando el parametro tcrLlaveKey esta vacio o no es valido</para>
        /// </summary>
        public static String fcrLeerConfiguracionRegional(String tcrLlaveKey)
        {
            var lcrValor = String.Empty;
            var lcrllave = String.Empty;
            try
            {
                switch (tcrLlaveKey.ToUpper())
                {
                    case "DECIMAL-MONEDA": // Cantidad de digitos decimales para la moneda
                        lcrllave = "iCurrDigits";
                        break;

                    case "DECIMAL": // separador decimal de datos tipo numericos
                        lcrllave = "sDecimal";
                        break;
                }
                if (!String.IsNullOrWhiteSpace(lcrllave.Trim()))
                {
                    RegistryKey lobclave = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);
                    var lobDato = lobclave.GetValue(lcrllave, true);
                    lcrValor = lobDato.ToString();
                    lobclave.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------------------
        // fnuRedondeoAjuste(): Ajusta un valor al redondeo
        //------------------------------------------------------------
        #region fnuRedondeoAjuste(): Ajusta valor con tipo redondeo
        /// <summary>
        /// <para>fnuRedondeoAjuste()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el valor dado en el parametro tcrNumero ajustado a la unidad tecnicas de redondeo</para>
        /// <para>segun parametro tcrTipoRedondeo: 1=Redondeo valor punto Medio 2=Redondeo superior (llevar al siguente valor )</para>
        /// <para>3=Redondeo inferior (llevar al menor valor)</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumero: Valor numerico al cual se realizara el ajuste o redondeo</para>
        /// <para>tnuAjuste: Valor unidades del redondeo</para>
        /// <para>tcrTipoRedondeo: 1=Redondeo punto Medio, 2=Redondeo superior, 3= Redondeo inferior</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve el valor numerico ajustado al redondeo.</para>
        /// </summary>
        public static int fnuRedondeoAjuste(float tflNumero, int tnuAjuste, String tcrTipoRedondeo)
        {
            var lnuReturn = (int)tflNumero;
            if (tcrTipoRedondeo == "1")
            {
                lnuReturn = fnuRedondeoAjuste(tflNumero, tnuAjuste);
            }
            else
            {
                var llgTipo = tcrTipoRedondeo == "2" ? true : false;
                lnuReturn = fnuRedondeoAjuste(tflNumero, tnuAjuste, llgTipo);
            }
            return lnuReturn;
        }
        #endregion
        #region fnuRedondeoAjuste(): Ajusta valor redondeo punto medio
        /// <summary>
        /// <para>fnuRedondeoAjuste()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el valor dado en el parametro tcrNumero ajustado a la unidad aplicando el redondeo de punto medio</para>
        /// <para>Punto medio: si saldo es menor al 50%  del Valor ajuste se redondea inferior sino al superior</para>
        /// <para>dada en tnuUnidadAjuste.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumero: Valor numerico al cual se realizara el ajuste o redondeo</para>
        /// <para>tnuAjuste: Valor unidades del redondeo</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve el valor numerico ajustado al redondeo.</para>
        /// </summary>
        public static int fnuRedondeoAjuste(float tflNumero, int tnuAjuste)
        {
            var lnuReturn = (int)tflNumero;
            if (tnuAjuste > 0)
            {
                var lnuUnidades = (int)(tflNumero / tnuAjuste);        // Unidades de ajuste
                var lnuSaldo = tflNumero - (tnuAjuste * lnuUnidades);

                // Verificar si el saldo restante alcanza para generar una unidad mas
                if (lnuSaldo > 0)
                {
                    var lnuPuntomedio = (int)((lnuSaldo * 100) / tnuAjuste);
                    lnuReturn = (tnuAjuste * lnuUnidades);
                    if (lnuPuntomedio >= 50) { lnuReturn += tnuAjuste; }
                }
            }
            return lnuReturn;
        }
        #endregion
        #region fnuRedondeoAjuste(): Ajustar redondeo inferior o superior
        /// <summary>
        /// <para>fnuRedondeoAjuste()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devuelve el valor dado en el parametro tcrNumero ajustado a la unidad</para>
        /// <para>dada en tnuUnidadAjuste en redondeo superior/inferior segun parametro tlgRedondeoSaldo.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumero: Valor numerico al cual se realizara el ajuste o redondeo</para>
        /// <para>tnuAjuste: Valor unidades del redondeo</para>
        /// <para>tlgRedondeoSaldo: true = Genera redondeo superior cuando hay saldo / false = Genera redondeo inferior cuando hay saldo </para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve el valor numerico ajustado al redondeo.</para>
        /// </summary>
        public static int fnuRedondeoAjuste(float tflNumero, int tnuAjuste, bool tlgRedondeoSaldo)
        {
            var lnuReturn = (int)tflNumero;
            if (tnuAjuste > 0)
            {
                var lnuUnidades = (int)(tflNumero / tnuAjuste);        // Unidades de ajuste
                var lnuSaldo = tflNumero - (tnuAjuste * lnuUnidades);

                // Verificar si el saldo restante alcanza para generar redondeo superior/inferior
                if (lnuSaldo > 0)
                {
                    lnuReturn = (tnuAjuste * lnuUnidades);
                    if (tlgRedondeoSaldo == true) { lnuReturn += tnuAjuste; }
                }

                // cuando el valor es menor que el ajuste se asume como minimo el ajuste
                lnuReturn = lnuReturn < tnuAjuste ? tnuAjuste : lnuReturn;
            }
            lnuReturn = lnuReturn <= 0 ? (int)tflNumero : lnuReturn;

            return lnuReturn;
        }
        #endregion
        //------------------------------------------------------------
        // frtbCapturarPantallaAImagen: Convertir objeto visual a Imagen PNG
        //------------------------------------------------------------
        #region frtbCapturarPantallaAImagen(): Convertir objeto visual a Imagen PNG,JPG,BMP
        /// <summary>
        /// <para>frtbCapturarPantallaPNG()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Recibe la referencia a un objeto visual (Ventana, Canvas y otros) y lo convierte en</para>
        /// <para>una imagen de dibujo tipo PNG o jpg</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobObjeto: Referencia la objeto visual que sera convertido en imagen</para>
        /// <para>tnuDpiX y tnuDpiY: Valor para los pixeles de resoluicion de la imagen (96 pod defecto para ambos)</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve un objeto del tipo RenderTargetBitmap (imagen PNG,JPG,BMP codificada)</para>
        /// </summary>
        public static RenderTargetBitmap frtbCapturarPantallaAImagen(Visual tobObjeto, int tnuDpiX, int tnuDpiY)
        {
            Rect lobObjCuadro = VisualTreeHelper.GetDescendantBounds(tobObjeto);
            var rtbObjPng = new RenderTargetBitmap((int)lobObjCuadro.Width, (int)lobObjCuadro.Height, tnuDpiX, tnuDpiY, PixelFormats.Pbgra32);

            DrawingVisual ldvVisual = new DrawingVisual();
            using (DrawingContext ctx = ldvVisual.RenderOpen())
            {
                VisualBrush lvbVisualBrush = new VisualBrush(tobObjeto);
                ctx.DrawRectangle(lvbVisualBrush, null, new Rect(new System.Windows.Point(), lobObjCuadro.Size));
            }
            rtbObjPng.Render(ldvVisual);
            return rtbObjPng;
        }
        #endregion
        //------------------------------------------------------------
        // flgGuardarImagenPath: Exporta a una carpeta la imagen contenida en formato RenderTargetBitmap a archivo PNG
        //------------------------------------------------------------
        #region flgGuardarImagenPath(): Exporta a una carpeta la imagen contenida en formato RenderTargetBitmap a archivo PNG
        /// <summary>
        /// <para>flgGuardarImagenPNG()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Recibe un objeto del tipo RenderTargetBitmap y lo copia a una ruta como archivo png,jpg,bmp</para>
        /// <para>PARAMETROS:</para>
        /// <para>trtbObjetoImagen:
        /// Referencia la objeto visual que sera convertido en archivo de imagen</para>
        /// <para>tcrNombreArchivo:
        /// Nombre fisico para el nuevo archivo con la extencion PNG,JPG,BMP ejemplo: "foto.png"</para>
        /// <para>tcrRutaDestino:
        /// Ruta destino para la imagen</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve valor logico, cuando la operacion se realiza con exito retona True, cuando no se realiza retorna False</para>
        /// </summary>
        public static bool flgGuardarImagenPath(RenderTargetBitmap trtbObjetoImagen, String tcrNombreArchivo, String tcrRutaDestino)
        {
            var llgReturn = false;
            var lpngEncoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            lpngEncoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(trtbObjetoImagen));

            String lcrArchivoDestino = System.IO.Path.Combine(tcrRutaDestino, tcrNombreArchivo);

            using (var luxflujo = System.IO.File.Create(lcrArchivoDestino))
            {
                lpngEncoder.Save(luxflujo);
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // fuiClonarObjeto: Permite clonar un objeto 
        //------------------------------------------------------------
        #region fuiClonarObjeto(): Permite clonar un objeto
        /// <summary>
        /// <para>fuiClonarObjeto()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Recibe un objeto del tipo UIElement y genera una copia o clon del objeto</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobObjeto:
        /// Referencia la objeto visual que sera clonado</para>
        /// <para>VALOR DE RETORNO</para>
        /// <para>Devuelve el nuevo objeto clonado</para>
        /// </summary>
        public static UIElement fuiClonarObjeto(UIElement tobObjeto)
        {
            String lcrShapestring = XamlWriter.Save(tobObjeto);

            StringReader stringReader   = new StringReader(lcrShapestring);
            XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
            UIElement DeepCopyobject    = (UIElement)XamlReader.Load(xmlTextReader);

            return DeepCopyobject;
        }
        #endregion
        //------------------------------------------------------------
        // fnuArchivoTextoTotalLineas: Contar el total de lineas del archivo de texto
        //------------------------------------------------------------
        #region fnuArchivoTextoTotalLineas: Contar el total de lineas del archivo de texto
        /// <summary>
        /// <para>fnuArchivoTextoTotalLineas()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>devuelve un valor de tipo entero correspondiente al total de lineas que </para>
        /// <para>contenga el archivo de texto dado en el parametro tcrPathArchivo</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrPathArchivo: Referencia a la ruta y nombre del archivo a verificar total lineas</para>
        /// </summary>
        public static int fnuArchivoTextoTotalLineas(String tcrPathArchivo)
        {
            using (StreamReader r = new StreamReader(tcrPathArchivo))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
        #endregion
        //------------------------------------------------------------
        // fnuArchivoTextoTotalLineas: Contar el total de lineas del archivo de texto
        //------------------------------------------------------------
        #region fnuPorcentaje: Calcular porcentaje 
        /// <summary>
        /// <para>fnuPorcentaje()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>devuelve un valor de tipo entero correspondiente al porcentaje dentro tnuGranTotal </para>
        /// <para>PARAMETROS:</para>
        /// <para>tnuValor: Valor a calcular en porcentajde</para>
        /// <para>tnuGranTotal: Valor base gran total</para>
        /// </summary>
        public static int fnuPorcentaje(int tnuValor, int tnuGranTotal)
        {
            int lnuValorPorcentaje = 0;
            if (tnuValor > 0 && tnuValor <= tnuGranTotal)
            {
                lnuValorPorcentaje = (tnuValor * 100) / tnuGranTotal;
            }
            else if (tnuValor > tnuGranTotal)
            {
                lnuValorPorcentaje = 100;
            }
            else
            {
                lnuValorPorcentaje = 1;
            }
            lnuValorPorcentaje = lnuValorPorcentaje < 1 ? 1 : lnuValorPorcentaje;

            return lnuValorPorcentaje;
        }
        #endregion
        //------------------------------------------------------------
        // fcrConvertirNumeroALetras: Convertir expresiones numericas a letras
        //------------------------------------------------------------
        #region fcrConvertirNumeroALetras(): Convertir expresiones numericas a letras
        /// <summary>
        /// <para>fcrConvertirNumeroALetras()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Funcion para convertir una expresion numerica en el equivalente en letras</para>
        /// <para>Ejemplo: 142  = "CIENTO CUARENTA Y DOS"</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumero: Valor numerico en tipo texto</para>
        /// <para>tcrTipoMoneda: "PESOS","DOLAR" ... OTROS</para>
        /// </summary>
        public static String fcrConvertirNumeroALetras(String tcrNumero, String tcrTipoMoneda)
        {
            String lcrResultado, lcrDecimales = String.Empty;
            String lcrTipoMoneda = tcrTipoMoneda;
            Int64 lnuParteEntera, lnuMillon;
            int lnuParteDecimal;
            double lnuNumero;

            try
            {
                lnuNumero = Convert.ToDouble(tcrNumero);
            }
            catch
            {
                return String.Empty;
            }

            lnuParteEntera = Convert.ToInt64(Math.Truncate(lnuNumero));
            lnuParteDecimal = Convert.ToInt32(Math.Round((lnuNumero - lnuParteEntera) * 100, 2));
            // AJUSTE A DESCRIPCION TIPO MONEDA
            lnuMillon = Convert.ToInt32(Math.Truncate(lnuNumero / 1000000));
            lcrTipoMoneda = lnuMillon >= 1 && lnuMillon == lnuNumero / 1000000 ? " DE " + lcrTipoMoneda : " " + lcrTipoMoneda;

            if (lnuParteDecimal > 0)
            {
                var lcrLetraS = lnuParteDecimal > 1 ? "S" : "";
                lcrDecimales = " CON " + lnuParteDecimal.ToString() + " CENTAVO" + lcrLetraS;
            }

            lcrResultado = fcvNumeroAletrasAux(Convert.ToDouble(lnuParteEntera)) + lcrTipoMoneda + lcrDecimales;
            return lcrResultado;
        }

        private static String fcvNumeroAletrasAux(double tcrValor)
        {
            String lcrNumeroText = String.Empty;

            tcrValor = tcrValor < 0 ? 0 : tcrValor;
            tcrValor = Math.Truncate(tcrValor);

            if (tcrValor == 0) lcrNumeroText = "CERO";
            else if (tcrValor == 1) lcrNumeroText = "UN";
            else if (tcrValor == 2) lcrNumeroText = "DOS";
            else if (tcrValor == 3) lcrNumeroText = "TRES";
            else if (tcrValor == 4) lcrNumeroText = "CUATRO";
            else if (tcrValor == 5) lcrNumeroText = "CINCO";
            else if (tcrValor == 6) lcrNumeroText = "SEIS";
            else if (tcrValor == 7) lcrNumeroText = "SIETE";
            else if (tcrValor == 8) lcrNumeroText = "OCHO";
            else if (tcrValor == 9) lcrNumeroText = "NUEVE";
            else if (tcrValor == 10) lcrNumeroText = "DIEZ";
            else if (tcrValor == 11) lcrNumeroText = "ONCE";
            else if (tcrValor == 12) lcrNumeroText = "DOCE";
            else if (tcrValor == 13) lcrNumeroText = "TRECE";
            else if (tcrValor == 14) lcrNumeroText = "CATORCE";
            else if (tcrValor == 15) lcrNumeroText = "QUINCE";
            else if (tcrValor < 20) lcrNumeroText = "DIECI" + fcvNumeroAletrasAux(tcrValor - 10);
            else if (tcrValor == 20) lcrNumeroText = "VEINTE";
            else if (tcrValor < 30) lcrNumeroText = "VEINTI" + fcvNumeroAletrasAux(tcrValor - 20);
            else if (tcrValor == 30) lcrNumeroText = "TREINTA";
            else if (tcrValor == 40) lcrNumeroText = "CUARENTA";
            else if (tcrValor == 50) lcrNumeroText = "CINCUENTA";
            else if (tcrValor == 60) lcrNumeroText = "SESENTA";
            else if (tcrValor == 70) lcrNumeroText = "SETENTA";
            else if (tcrValor == 80) lcrNumeroText = "OCHENTA";
            else if (tcrValor == 90) lcrNumeroText = "NOVENTA";
            else if (tcrValor < 100) lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 10) * 10) + " Y " + fcvNumeroAletrasAux(tcrValor % 10);
            else if (tcrValor == 100) lcrNumeroText = "CIEN";
            else if (tcrValor < 200) lcrNumeroText = "CIENTO " + fcvNumeroAletrasAux(tcrValor - 100);
            else if ((tcrValor == 200) || (tcrValor == 300) || (tcrValor == 400) || (tcrValor == 600) || (tcrValor == 800)) lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 100)) + "CIENTOS";
            else if (tcrValor == 500) lcrNumeroText = "QUINIENTOS";
            else if (tcrValor == 700) lcrNumeroText = "SETECIENTOS";
            else if (tcrValor == 900) lcrNumeroText = "NOVECIENTOS";
            else if (tcrValor < 1000) lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 100) * 100) + " " + fcvNumeroAletrasAux(tcrValor % 100);
            else if (tcrValor == 1000) lcrNumeroText = "MIL";
            else if (tcrValor < 2000) lcrNumeroText = "MIL " + fcvNumeroAletrasAux(tcrValor % 1000);
            else if (tcrValor < 1000000)
            {
                lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 1000)) + " MIL";
                if ((tcrValor % 1000) > 0) lcrNumeroText = lcrNumeroText + " " + fcvNumeroAletrasAux(tcrValor % 1000);
            }

            else if (tcrValor == 1000000) lcrNumeroText = "UN MILLON";
            else if (tcrValor < 2000000) lcrNumeroText = "UN MILLON " + fcvNumeroAletrasAux(tcrValor % 1000000);
            else if (tcrValor < 1000000000000)
            {
                lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 1000000)) + " MILLONES ";
                if ((tcrValor - Math.Truncate(tcrValor / 1000000) * 1000000) > 0) lcrNumeroText = lcrNumeroText + " " + fcvNumeroAletrasAux(tcrValor - Math.Truncate(tcrValor / 1000000) * 1000000);
            }

            else if (tcrValor == 1000000000000) lcrNumeroText = "UN BILLON";
            else if (tcrValor < 2000000000000) lcrNumeroText = "UN BILLON " + fcvNumeroAletrasAux(tcrValor - Math.Truncate(tcrValor / 1000000000000) * 1000000000000);

            else
            {
                lcrNumeroText = fcvNumeroAletrasAux(Math.Truncate(tcrValor / 1000000000000)) + " BILLONES";
                if ((tcrValor - Math.Truncate(tcrValor / 1000000000000) * 1000000000000) > 0) lcrNumeroText = lcrNumeroText + " " + fcvNumeroAletrasAux(tcrValor - Math.Truncate(tcrValor / 1000000000000) * 1000000000000);
            }
            return lcrNumeroText;
        }
        #endregion
        //------------------------------------------------------------
        // GESTION CONFIGURACION CONEXION A BASE DE DATOS
        //------------------------------------------------------------
        #region Configuracion Conexion Base de datos
        #region flgSetConfiguracionConexionSql: Establecer parametros del sistema para conexion por defecto
        /// <summary>
        /// <para>Establecer parametros del sistema para conexion por defecto desde archivo del sistema</para>
        /// </summary>
        public static bool flgSetConfiguracionConexionSql()
        {
            return flgSetConfiguracionConexionSql(fcvGetConexionDefault());
        }
        #endregion
        #region flgSetConfiguracionConexionSql: Establecer parametros del sistema para conexion dada
        /// <summary>
        /// <para>Establecer parametros del sistema para conexion dada en parametro desde archivo del sistema</para>
        /// </summary>
        public static bool flgSetConfiguracionConexionSql(String tcrIdNombreConexion)
        {
            bool lcrReturn = false;
            Aplicacion oApp = Aplicacion.Instancia();
            DbContext oDbApp = DbContext.Instancia();

            String lcrPathSystem = Environment.GetFolderPath(Environment.SpecialFolder.Windows); // ruta system de windows
            //String lcrArchivo = lcrPathSystem + @"\system\GalenoConfig.dll";
            String lcrArchivo = lcrPathSystem + @"\system\" + oApp.gcrAppBdatosArchivoLineaConn;
            String lcrNombreConexDefalut = tcrIdNombreConexion;
            //Aplicacion oApp = Aplicacion.Instancia();
            //DbContext oDbApp = DbContext.Instancia();

            if (File.Exists(@lcrArchivo))
            {
                //Cargar el archivo
                XDocument doc = XDocument.Load(@lcrArchivo);

                //--------------------------------------------
                // connectionStrings: Buscar la seccion del conector
                //--------------------------------------------
                var tmpRegCon = from p in doc.Descendants("ConnectionStrings").Descendants() select p;
                // Establecer propiedades de la conexion
                oApp.gcrAppBdatosConexionDefault        = lcrNombreConexDefalut;
                oApp.gcrAppBdatosConexionDefaultDesc    = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnConexionDefaultDesc", tmpRegCon);
                oApp.gcrAppBdatosMotorBaseDeDatos       = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnMotorBaseDeDatos", tmpRegCon);
                oApp.gcrAppBdatoTipoIpServidor          = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnTipoIpServidor", tmpRegCon);
                oApp.gcrAppBdatosIpServidor             = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnIpServidor", tmpRegCon);
                oApp.gcrAppInicioPath                   = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnAppInicioPath", tmpRegCon);
                oApp.gcrAppBdatosSqlLineaConexion       = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnConnectionString", tmpRegCon);
                oApp.gcrAppBdatosSqlLineaConnNativa     = fcvGetPropiedadConexion(lcrNombreConexDefalut, "ConnConnectionStringNativa", tmpRegCon);

                // Establecer propiedades Ruta recursos
                oApp.gcrAppRecursoTipoIpServidor = fcvGetPropiedadConexion(lcrNombreConexDefalut, "RecursosTipoIpServidor", tmpRegCon);
                oApp.gcrAppRecursoIpServidor     = fcvGetPropiedadConexion(lcrNombreConexDefalut, "RecursosIpServidor", tmpRegCon);
                oApp.gcrAppRecursoPath           = fcvGetPropiedadConexion(lcrNombreConexDefalut, "RecursosPath", tmpRegCon);
                oApp.gcrAppRecursoInicioPath     = fcvGetPropiedadConexion(lcrNombreConexDefalut, "RecursosInicioPath", tmpRegCon);

                // Conexion para la base de datos Enttityframework
                oDbApp.gcrSqlLineaConexion = oApp.gcrAppBdatosSqlLineaConexion;

                // Ruta Base de la aplicacion concatenada
                oApp.gcrAppInicioPathCompleta = oApp.gcrAppBdatosIpServidor +
                                                 @"\" + oApp.gcrAppInicioPath;

                oApp.gcrAppInicioPathCompleta = oApp.gcrAppBdatoTipoIpServidor != "NORED" ?
                                                        @"\\" + oApp.gcrAppInicioPathCompleta : oApp.gcrAppInicioPathCompleta;

                // Rutas concatenadas para buscar archivos recursos
                oApp.gcrAppRecursoPathCompleta = oApp.gcrAppRecursoIpServidor + 
                                                 @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;

                oApp.gcrAppRecursoPathCompleta = oApp.gcrAppRecursoTipoIpServidor != "NORED" ? 
                                                        @"\\" + oApp.gcrAppRecursoPathCompleta : oApp.gcrAppRecursoPathCompleta;


                lcrReturn = true;
            }
            return lcrReturn;
        }
        #endregion
        #region fcvGetPropiedadConexion: Buscar Propiedades de una conexion en particular
        /// <summary>
        /// Buscar Propiedades de una conexion en particular
        /// </summary>
        private static String fcvGetPropiedadConexion(String tcrNombreConexion , String tcrPropiedad, IEnumerable<XElement> tmpListConn)
        {
            var lcrValor = String.Empty;
            var llgSiConexion = false;
            var llgSiPropiedad = false;
            foreach (var lobReg in tmpListConn)
            {
                //Buscar el atributo que contiene Nombre de la conexion
                foreach (var atr in lobReg.Attributes())
                {
                    if (atr.Name.LocalName == "Name" && atr.Value == tcrNombreConexion)
                    {
                        llgSiConexion = true;
                    }
                    if (atr.Name.LocalName == tcrPropiedad && llgSiConexion == true)
                    {
                        llgSiPropiedad = true;
                        lcrValor = atr.Value;
                    }
                    if (llgSiPropiedad == true && llgSiConexion == true) { break; }
                }
                if (llgSiPropiedad == true && llgSiConexion == true) { break; }
            }
            return lcrValor;
        }
        #endregion
        #region fcvGetConexionDefault: Buscar conexion base de datos por defecto
        /// <summary>
        /// <para>Devuelve el Nombre de conexion por defecto desde el archivo de configracion del sistema ruta Windows</para>
        /// </summary>
        public static String fcvGetConexionDefault()
        {
            String lcrPathSystem = Environment.GetFolderPath(Environment.SpecialFolder.Windows); // ruta system de windows
            String lcrArchivo = lcrPathSystem + @"\system\GalenoConfig.dll";
            String lcrNombreConexDefalut = "DbAplicacion";

            if (File.Exists(@lcrArchivo))
            {
                //Cargar el archivo
                XDocument doc = XDocument.Load(@lcrArchivo);

                //--------------------------------------------
                // DefaultConnection: Seccion para buscar conexion por defecto
                //--------------------------------------------
                var tmpReg = from p in doc.Descendants("DefaultConnection").Descendants() select p;

                //Buscar el atributo que contiene el nombre conexion por defecto
                foreach (var lobReg in tmpReg)
                {
                    foreach (var atr in lobReg.Attributes())
                    {
                        if (atr.Name.LocalName == "Name")
                        {
                            lcrNombreConexDefalut = atr.Value;
                        }
                    }
                }
            }
            return lcrNombreConexDefalut;
        }
        #endregion
        // Generar lista de conexiones a Base de datos
        #region fcvGetListaConexionDB: Generar lista de conexiones a Base de datos
        /// <summary>
        /// Buscar Propiedades de una conexion en particular
        /// </summary>
        public static List<CrtForms.ListaComboBox> fcvGetListaConexionDB()
        {
            var lstListReturn = new List<CrtForms.ListaComboBox>();
            String lcrPathSystem = Environment.GetFolderPath(Environment.SpecialFolder.Windows); // ruta system de windows
            String lcrArchivo = lcrPathSystem + @"\system\GalenoConfig.dll";

            if (File.Exists(@lcrArchivo))
            {
                //Cargar el archivo
                XDocument doc = XDocument.Load(@lcrArchivo);

                //--------------------------------------------
                // DefaultConnection: Seccion para buscar conexion por defecto
                //--------------------------------------------
                var tmpReg = from p in doc.Descendants("ConnectionStrings").Descendants() select p;

                var lobRegAdd = new CrtForms.ListaComboBox();
                var i = 0;
                //Buscar el atributo que contiene el nombre conexion por defecto
                foreach (var lobReg in tmpReg)
                {
                    lobRegAdd = new CrtForms.ListaComboBox();
                    lobRegAdd.IdIndice = i.ToString().Trim();
                    lobRegAdd.TotalOp = 0;
                    lobRegAdd.ListaValoresSel = "";

                    // Buscar el nombre y Descripcion de la Base de datos
                    foreach (var atr in lobReg.Attributes())
                    {
                        if (atr.Name.LocalName == "Name")
                        {
                            lobRegAdd.ValorSeleccion = atr.Value;
                        }
                        if (atr.Name.LocalName == "ConnConexionDefaultDesc")
                        {
                            lobRegAdd.NombreOpcion = atr.Value;
                        }
                    }
                    lstListReturn.Add(lobRegAdd);
                    i++;
                }
            }
            return lstListReturn;
        }
        #endregion
        // Ejecutar Consultas y por conexion nativa
        #region fobConsultaSqlDataAdapter: Generar temporal consultas Sql nativas
        /// <summary>
        /// <para>fobConsultaSqlDataAdapter()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Ejecuta consultas Sql con la conexion nativa y devuelve temporal del tipo DataTable</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrLineaSqlSelct: String linea para consulta Sql/MySql/FireBird/Oracle y otros</para>
        /// </summary>
        public static DataTable fobConsultaSqlDataAdapter(String tcrLineaSqlSelct)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            DataTable lobjDatosTabla = new DataTable();

            //- Consultas desde MySQL
            if (oApp.gcrAppBdatosMotorBaseDeDatos == "MYSQL")
            {
                var lcrSqlLineaConnNativa = oApp.gcrAppBdatosSqlLineaConnNativa + ";default command timeout = 0;";
                var gobSqlConexion = new MySqlConnection(lcrSqlLineaConnNativa);
                gobSqlConexion.Open();
                var objAdaptadorSql = new MySqlDataAdapter(tcrLineaSqlSelct, lcrSqlLineaConnNativa);
                objAdaptadorSql.Fill(lobjDatosTabla);
                gobSqlConexion.Close();
            }
            //- Consultas desde SQL Server
            if (oApp.gcrAppBdatosMotorBaseDeDatos == "SQL")
            {
                var gobSqlConexion = new SqlConnection(oApp.gcrAppBdatosSqlLineaConnNativa);
                gobSqlConexion.Open();
                var objAdaptadorSql = new SqlDataAdapter(tcrLineaSqlSelct, oApp.gcrAppBdatosSqlLineaConnNativa);
                objAdaptadorSql.Fill(lobjDatosTabla);
                gobSqlConexion.Close();
            }

            return lobjDatosTabla;
        }
        #endregion
        #region fcrConsultaSqlComando: Ejecuta una consulta tipo comando SQl
        /// <summary>
        /// <para>fcrConsultaSqlComando()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Ejecuta una consulta tipo comando SQl</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrLineaComando: String linea para consulta Sql/MySql/FireBird/Oracle y otros</para>
        /// <para>VALOR RETORNO: devuelve un valor tipo texto segun seal el comando enviado al motor sql</para>
        /// <para>devuelve la expresion "*ERROR*"cuando falla la consulta / "*-1*" cuando la consulta resulta vacia</para>
        /// </summary>
        public static String fcrConsultaSqlComando(String tcrLineaStringSql)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            var lcrReturn = "*-1*";

            //- Consultas desde MySQL
            if (oApp.gcrAppBdatosMotorBaseDeDatos == "MYSQL")
            {
                var gobSqlConexion = new MySqlConnection(oApp.gcrAppBdatosSqlLineaConnNativa);

                MySqlCommand cmd = new MySqlCommand(); // creamos un objeto para el manejo de la transacion en SQL
                Object luxObjetoValue;                // en este objeto guardaremos el dato obtenido (el password)

                cmd.CommandText = tcrLineaStringSql;    // esta es la cadena que se ejecutará por SQL
                cmd.CommandType = CommandType.Text;
                cmd.Connection = gobSqlConexion; // establecemos la conexion

                gobSqlConexion.Open();
                luxObjetoValue = cmd.ExecuteScalar(); // ejecuta la consulta y de vuelve el primer registro del objeto
                gobSqlConexion.Close();

                if (luxObjetoValue == null)
                {
                    lcrReturn = "*1*"; 
                }
                else
                {
                    lcrReturn = luxObjetoValue.ToString().Trim();
                }

            }
            //- Consultas desde SQL Server
            if (oApp.gcrAppBdatosMotorBaseDeDatos == "SQL")
            {
                var gobSqlConexion = new SqlConnection(oApp.gcrAppBdatosSqlLineaConnNativa);

                SqlCommand cmd = new SqlCommand(); // creamos un objeto para el manejo de la transacion en SQL
                Object luxObjetoValue;             // en este objeto guardaremos el dato obtenido (el password)

                cmd.CommandText = tcrLineaStringSql; // esta es la cadena que se ejecutará por SQL
                cmd.CommandType = CommandType.Text;
                cmd.Connection = gobSqlConexion;     // establecemos la conexion

                gobSqlConexion.Open();
                luxObjetoValue = cmd.ExecuteScalar(); // ejecuta la consulta y de vuelve el primer registro del objeto
                gobSqlConexion.Close();

                if (luxObjetoValue == null)
                {
                    lcrReturn = "*-1*";
                }
                else
                {
                    lcrReturn = luxObjetoValue.ToString().Trim();
                }
            }

            return lcrReturn;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GENERAR CODIGO FUENTE - CONVERSION DE DATOS A OTROS TIPOS  
        //------------------------------------------------------------
        #region fcrGenerarExpresionTextoItem: Generar expresion llave agrupar
        /// <summary>
        /// <para>fcrConvertirNumeroALetras()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Generar expresion de conversion para mostrar dato contenido en campo o una variable</para>
        /// <para>el parametro "tcrTipoDato" debe contener un tipo dato segun estandar de trabajo: "CARACTER"/"ENTERO"/"FECHA"...</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNombreItem: Nombre del campo o variable para el cual se necesita devolver la expresion de conversión</para>
        /// <para>tcrTipoDato: "CARACTER"/"ENTERO"/"FECHA"/"STRING"/"INT"...</para>
        /// </summary>
        public static String fcrGenCodConvertirTipoATipoTexto(String tcrNombreItem, String tcrTipoDato)
        {
            var lcrString = String.Empty;
            tcrTipoDato = tcrTipoDato.Trim().ToUpper();
            tcrNombreItem = tcrNombreItem.Trim();

            if (flgExisteElemento(tcrTipoDato, ",", "CHAR,CARACTER,TEXTO,STRING,LARGO,MEMO"))
            {
                // Tipo Caracter
                lcrString = tcrNombreItem + ".Trim()";
            }
            else if (flgExisteElemento(tcrTipoDato, ",", "FECHA,DATE,DATETIME"))
            {
                // Tipo Fecha
                lcrString = tcrNombreItem + ".ToShortDateString()";
            }
            else if (flgExisteElemento(tcrTipoDato, ",", "INT,NUMERO,NUMERICO,ENTERO"))
            {
                // Tipo Numerico o Entero
                lcrString = tcrNombreItem + ".ToString().Trim()";

            }
            else if (flgExisteElemento(tcrTipoDato, ",", "DOBLE,DOUBLE"))
            {
                // Tipo Double
                lcrString = tcrNombreItem + ".ToString().Trim()";

            }
            else if (tcrTipoDato == "DECIMAL")
            {
                // Tipo Decimal
                lcrString = tcrNombreItem + ".ToString().Trim()";
            }
            else if (flgExisteElemento(tcrTipoDato, ",", "TIME,HORA"))
            {
                // Tipo Hora (Decimal)
                lcrString = tcrNombreItem + ".ToString().Trim()";
            }
            return lcrString;
        }
        #endregion
        //------------------------------------------------------------
        // GESTION FUNCIONAMIENTO DE LA APLICACION
        //------------------------------------------------------------
        #region flgVistaErroresEjecucion: Vista errores de ejecución
        /// <summary>
        /// <para>flgVistaErroresEjecucion()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Mostrar vista log errores de ejecución</para>
        /// <para>PARAMETROS:</para>
        /// <para>ex: Objeto del compilador que contiene la gestion de errores en ejecución</para>
        /// <para>tcrTituloError: Titulo del error...</para>
        /// </summary>
        public static void fcvVistaErroresEjecucion(ref Exception ex, String tcrTituloError)
        {
            var lobVista = new VistaErroresEjecucion(ref ex, tcrTituloError);
            lobVista.ShowDialog();

            MessageBox.Show("Se cerrará el sistema.");
            Application.Current.Shutdown();
        }
        #endregion
        #region FcvVistaResponse: Vista lista resultados log de texto
        /// <summary>
        /// <para>fcvVistaResponse()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Mostrar vista log de ejecución</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrLog: Objeto del compilador que contiene la gestion log de ejecución</para>
        /// <para>tcrTitulo: Titulo de la vista...</para>
        /// </summary>
        public static void FcvVistaResponse(String tcrLog, String tcrTitulo, Window tobOwner = null)
        {
            var lobVista = new VistaResponse(tcrLog, tcrTitulo);
            lobVista.Owner = tobOwner;
            lobVista.ShowDialog();
        }
        #endregion
        #region flgWinAppAddNuevaVentana: Verificar y registrar nueva ventana en ejecucion
        /// <summary>
        /// <para>flgWinAppAddNuevaVentana()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Verifica y registra cuando hay nueva ventana en ejecucion</para>
        /// </summary>
        public static bool flgWinAppAddNuevaVentana()
        {
            Aplicacion oApp = Aplicacion.Instancia();
            oApp.glgWinGestionProcesos = true;

            var llgReturn = false;
            var lobWin = Application.Current.Windows;

            if (oApp.gnuWinTotalVentanas != lobWin.Count)
            {
                llgReturn = true;
                oApp.gnuWinTotalVentanas = lobWin.Count;

                oApp.gtmpWinVentanasAct = null;
                oApp.gtmpWinVentanasAct = new List<Clases.RefVistaWindows>();


                var i = 0;
                for (i = 0; i < lobWin.Count; i++)
                {
                    var lobReg = new RefVistaWindows();
                    lobWin[i].Name = String.IsNullOrWhiteSpace(lobWin[i].Name) ? "WINDOWS" + i.ToString().Trim() : lobWin[i].Name;

                    // Generar el registro
                    lobReg.IdWindows = i;
                    lobReg.RefWindows = lobWin[i];
                    lobReg.NombreWindows = lobWin[i].Name;
                    lobReg.EstadoWindows = lobWin[i].WindowState;

                    // Gaurdar en lista
                    oApp.gtmpWinVentanasAct.Add(lobReg);
                }
            }
            oApp.glgWinGestionProcesos = false;
            return llgReturn;
        }
        #endregion
        #region flgWinAppMaximizarMinimizar: Maximizar o Minimizar la aplicacion Ocultando ventanas
        /// <summary>
        /// <para>flgWinAppMaximizarMinimizar()</para>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Maximiza o minimiza la aplicacion segun parametro dado en tcrEstadoApp</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrEstadoApp: "MA"=Maximizar "MI"= Minimizar</para>
        /// </summary>
        public static bool flgWinAppMaximizarMinimizar(String tcrEstadoApp)
        {
            var llgReturn = true;
            var lobWin = Application.Current.Windows;
            // Maximizar o Minimizar
            var i = 0;
            for (i = 0; i < lobWin.Count; i++)
            {
                if (tcrEstadoApp == "MA")
                {
                    lobWin[i].Visibility = Visibility.Visible;
                    if (lobWin[i].Name == "Main" || lobWin[i].Name == "SubMain" || lobWin[i].Name.Substring(0, 3).ToUpper() == "MAX")
                    {
                        lobWin[i].WindowState = System.Windows.WindowState.Maximized;
                    }
                    lobWin[i].Activate();
                }
                else
                {
                    if (lobWin[i].Name != "Main")
                    {
                        lobWin[i].Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lobWin[i].WindowState = System.Windows.WindowState.Minimized;
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // FUNCION PARA BUSCAR VARIABLES DE CONFIGURACION GLOBAL
        //------------------------------------------------------------
        #region fcrLeerConfigVarSistema: leer valores variables configuracion global del sistema y Valor Default
        // PROGRAMDOR-----------: JOSE BARRIOS
        // FECHA CREACION-------: 02-10-2017
        // ULTIMA MODIFICACION--: 04-10-2017 
        // HORA-----------------: 11:20 AM
        /// <summary>
        /// <para>leer valores variables configuracion global del sistema</para>
        /// <para>Devuelve un valor tipo texto, cuando no existe devuelve el valor dado en el parametro tcrValorDefault</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrKeyVariableGlobal: llave (key) de variable global para leer valor, Ejemplo: "FCM-PRNFAC-FORMATO-DFL"</para>
        /// <para>tcrValorDefault: Valor por defecto a devolver cuando el dato no se encuenta Ejemplo: "FRM01"</para>
        /// </summary>
        public static String fcrLeerConfigVarSistema(String tcrKeyVariableGlobal, String tcrValorDefault)
        {
            var lcrReturn = fcrLeerConfigVarSistema(tcrKeyVariableGlobal);

            if (String.IsNullOrWhiteSpace(lcrReturn))
            {
                lcrReturn = tcrValorDefault;
            }

            return lcrReturn;
        }
        #endregion
        #region fcrLeerConfigVarSistema: leer valores variables configuracion global del sistema
        /// <summary>
        /// <para>leer valores variables configuracion global del sistema</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrKeyVariableGlobal: llave (key) de variable global para leer valor, Ejemplo: "FCM-PRNFAC-FORMATO-DFL"</para>
        /// <para>Devuelve un valor tipo texto, cuando no existe devuelve una string vacia</para>
        /// </summary>
        public static String fcrLeerConfigVarSistema(String tcrKeyVariableGlobal)
        {
            var lcrReturn = String.Empty;

            var lobReg = SYSValidarCodigo.fobRegBuscarSysvarconfigmdKey(tcrKeyVariableGlobal);
            if (lobReg != null)
            {
                lcrReturn = lobReg.sys_vardfl_sycv;
            }

            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // BUSCAR ARCHIVO DESDE EXPLORADOR DE WINDOWS
        //------------------------------------------------------------
        #region fobBuscarArchivoRecurso: Abrir el explorador de windows para buscar un archivo de recurso
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar un archivo de recurso</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrExtPorDefecto: ".jpg"</para>
        /// <para>tcrFiltro: "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg" </para>
        /// </summary>
        public static ArchivoRecurso fobBuscarArchivoRecurso(String tcrTitulo, String tcrExtPorDefecto, String tcrFiltro)
        {
            ArchivoRecurso lobValor = null;

            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title = tcrTitulo;
            lopenFileDialog.Filter = tcrFiltro;
            lopenFileDialog.DefaultExt = tcrExtPorDefecto; // Extencion de archivos por defecto
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;
            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                lobValor = new ArchivoRecurso();
                lobValor.RutayArchivo = lopenFileDialog.FileName;
                lobValor.NombreArchivo = lopenFileDialog.SafeFileName;
                lobValor.Extencion = lobValor.NombreArchivo.Substring(lobValor.NombreArchivo.Length - 3, 3).ToUpper();
            }
            return lobValor;
        }
        #endregion
        #region ArchivoRecurso: Datos del archivo de recursos localizado en sistema
        /// <summary>
        /// <para>Datos del archivo de recursos localizado desde el explorador de windows</para>
        /// </summary>
        public class ArchivoRecurso
        {
            public ArchivoRecurso() { }
            /// <summary>
            /// Ruta y nombre  del archivo de recurso localizado (ejemplo: c:\temp\carta.doc)
            /// </summary>
            public String RutayArchivo { get; set; }
            /// <summary>
            /// Nombre del archivo localizado
            /// </summary>
            public String NombreArchivo { get; set; }
            /// <summary>
            ///  Extencion del archivo localizado (Ejemplo: bmp,doc,txt y otros)
            /// </summary>
            public String Extencion { get; set; }
        }
        #endregion
        #region flgCopiarArchivoRecurso: Enviar el archivo recurso a ruta de almacenamiento en el servidor complemento
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Enviar el archivo recurso a ruta de almacenamiento en el servidor, retorna true si la operacion fue exitosa.</para>
        /// <para>de lo contrario retorna false, complementa el parametro ruta destino con los valores por defecto del sistema</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobArchivo: Parametro segun la clase 'Funciones.ArchivoRecurso', contiene los datos del archivo a copiar.</para>
        /// <para>tcrNombreArchivo: Nuevo nombre del archivo, incluye la extención.</para>
        /// <para>tcrRutaDestino: Ruta relativa destino del archivo ejemplo: '\Imagenes\General\Sistemas', el path completo lo complementa la funcion.</para>
        /// </summary>
        public static bool flgCopiarArchivoRecurso(ArchivoRecurso tobArchivo, String tcrNombreArchivo, String tcrRutaDestino, bool tlgComplementoRuta)
        {
            var llgReturn = false;
            try
            {
                if (tobArchivo != null)
                {
                    var lcrRutaDestino = fcrGenRutaArchivoRecurso(tcrRutaDestino);

                    llgReturn = flgCopiarArchivoRecurso(tobArchivo, tcrNombreArchivo, lcrRutaDestino);
                }
            }
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Error funcion: flgCopiarArchivoRecurso");
            }
            return llgReturn;
        }
        #endregion
        #region fcrGenRutaArchivoRecurso: Generar la ruta completa para gestionar archivos de recurso
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Generar la ruta completa para gestionar archivos de recurso.</para>
        /// <para>Incluye los valores de ruta inicio path galeria de recursos, no verifica entorno "RED" "NORED"</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrRutaRecurso: Ruta relativa dada en parametro ejemplo: '\Imagenes\General\Sistemas', el path completo lo complementa la funcion.</para>
        /// </summary>
        public static String fcrGenRutaArchivoRecurso(String tcrRutaRecurso)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + 
                                 oApp.gcrAppRecursoPath + @"\" + tcrRutaRecurso;

            return lcrRutaDestino;
        }
        #endregion
        #region flgCopiarArchivoRecurso: Enviar el archivo recurso a ruta de almacenamiento en el servidor
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Enviar el archivo recurso a ruta de almacenamiento en el servidor, retorna true si la operacion fue exitosa.</para>
        /// <para>de lo contrario retorna false.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobArchivo: Parametro segun la clase 'Funciones.ArchivoRecurso', contiene los datos del archivo a copiar.</para>
        /// <para>tcrNombreArchivo: Nuevo nombre del archivo, incluye la extención.</para>
        /// <para>tcrRutaDestino: Ruta completa destino del archivo</para>
        /// </summary>
        public static bool flgCopiarArchivoRecurso(ArchivoRecurso tobArchivo, String tcrNombreArchivo, String tcrRutaDestino)
        {
            var llgReturn = false;
            try
            {
                if (tobArchivo != null)
                {
                    // Colocar doble barras en divisores de ruta ejemplo: c://ruta//galeria
                    String lcrArchivoOrigen  = fcrSystemIOPathCombine(tobArchivo.RutayArchivo);
                    String lcrArchivoDestino = fcrSystemIOPathCombine(tcrNombreArchivo, tcrRutaDestino, true);

                    // Sobre escribir cuando el archivo exista
                    System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                    llgReturn = true;
                }
            }
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Error funcion: flgCopiarArchivoRecurso");
            }
            return  llgReturn;
        }
        #endregion
        #region flgCopiarArchivoRecurso: Enviar el archivo recurso a ruta de almacenamiento en el servidor
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Enviar el archivo recurso a ruta de almacenamiento en el servidor, retorna true si la operacion fue exitosa.</para>
        /// <para>de lo contrario retorna false.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrArchivoOrigen: Nombre del archivo origen con extencion incluida (archivo a copiar).</para>
        /// <para>tcrRutaOrigen: Ruta origen archivo a copiar</para>
        /// <para>tcrArchivoDestino: Nuevo nombre del archivo al copiar en destino, incluye la extención.</para>
        /// <para>tcrRutaDestino: Ruta completa destino del nuevo archivo</para>
        /// </summary>
        public static bool flgCopiarArchivoRecurso(String tcrArchivoOrigen, String tcrRutaOrigen, String tcrArchivoDestino, String tcrRutaDestino)
        {
            var llgReturn = false;
            try
            {
                // Colocar doble barras en divisores de ruta ejemplo: c://ruta//galeria
                String lcrArchivoOrigen = fcrSystemIOPathCombine(tcrArchivoOrigen, tcrRutaOrigen, true);
                String lcrArchivoDestino = fcrSystemIOPathCombine(tcrArchivoDestino, tcrRutaDestino, true);

                // Sobre escribir cuando el archivo exista
                System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                llgReturn = true;
            }
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Error funcion: flgCopiarArchivoRecurso");
            }
            return llgReturn;
        }
        #endregion
        #region flgCopiarArchivoRecurso: Enviar el archivo recurso a ruta de almacenamiento en el servidor
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Enviar el archivo recurso a ruta de almacenamiento en el servidor, retorna true si la operacion fue exitosa.</para>
        /// <para>de lo contrario retorna false.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrArchivoOrigen: Nombre archivo origen con extencion y ruta incluida (archivo a copiar).</para>
        /// <para>tcrArchivoDestino: Nuevo nombre del archivo al copiar en destino, incluye extención y ruta destino.</para>
        /// </summary>
        public static bool flgCopiarArchivoRecurso(String tcrArchivoOrigen, String tcrArchivoDestino)
        {
            var llgReturn = false;
            try
            {
                // Colocar doble barras en divisores de ruta ejemplo: c://ruta//galeria
                Aplicacion oApp = Aplicacion.Instancia();
                String lcrArchivoOrigen = fcrSystemIOPathCombine(tcrArchivoOrigen);
                String lcrArchivoDestino = fcrSystemIOPathCombine(tcrArchivoDestino);

                if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                {
                    lcrArchivoDestino = @"\\" + lcrArchivoDestino;
                }
                // Sobre escribir cuando el archivo exista
                System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                llgReturn = true;

            }
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Error funcion: flgCopiarArchivoRecurso");
            }
            return llgReturn;
        }
        #endregion
        #region fcvSystemIOPathCombine: Concatenar el nombre de un archivo y la ruta dada en el parametro
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Concatenar el nombre de un archivo y la ruta dada en el parametro.</para>
        /// <para>la funcion verifica si se trabaja en entorno de "RED" o "NORED" para agregar doble barras en la ruta</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNombreArchivo: Nuevo nombre del archivo, incluye la extención.</para>
        /// <para>tcrRuta: Ruta completa para combinar/concatenar con el archivo</para>
        /// <para>tlgVerficarRed: True = Forzar a realizar la verificacion de "RED" o "NORED" para incluir doble barras en la ruta</para>
        /// <para>False = No verificar y no incluir doble barras en la ruta</para>
        /// </summary>
        public static String fcrSystemIOPathCombine(String tcrNombreArchivo, String tcrRuta, bool tlgVerficarRed)
        {
            String lcrReturn = tcrRuta + @"\" + tcrNombreArchivo;
            if (tlgVerficarRed == true)
            {
                lcrReturn = fcrSystemIOPathCombine(lcrReturn);
            }
            return lcrReturn;
        }
        #endregion
        #region fcvSystemIOPathCombine: Colocar doble barras en divisores de ruta
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Verifica si se trabaja en entorno de "RED" o "NORED" para agregar doble barras en string Ruta o Path</para>
        /// <para>ejemplo: c://ruta//galeria</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrRuta: String que contiene la ruta dada para realizar el proceso</para>
        /// </summary>
        public static String fcrSystemIOPathCombine(String tcrRuta)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            String lcrReturn = tcrRuta;

            // Colocar doble barras en divisores de ruta ejemplo: c://ruta//galeria
            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrReturn = System.IO.Path.Combine(lcrReturn);
            }
            return lcrReturn;
        }
        #endregion
        // Cargar achivos en vista pantalla
        #region fobCargarBitmapImage: Cargar imagen desde ruta dada
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Carga y devuelvde un objeto tipo BitmapImage desde una ruta dada, la funcion verifica si se trabaja en</para>
        /// <para>"RED" o "NORED" para agregar doble barras en la ruta ejemplo: c://ruta//galeria</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrArchivoRuta: String que contiene el nombre y la ruta origen del archivo a cargar</para>
        /// </summary>
        public static BitmapImage fobCargarBitmapImage(String tcrArchivoRuta)
        {
            String lcrArchivoOrigen = Funciones.fcrSystemIOPathCombine(tcrArchivoRuta);
            var lobUri = new Uri(lcrArchivoOrigen, UriKind.RelativeOrAbsolute);

            // Cargar la imagen
            return new BitmapImage(lobUri);
        }
        #endregion
        //------------------------------------------------------------
        // VENTANAS MENSAJES AUXILIARES TIPO POPUP
        //------------------------------------------------------------
        #region fobWindEspera: Cargar imagen desde ruta dada
        /// <summary>
        /// <para>Muestra la ventana simple de espera sin barra de progreso</para>
        /// <para>PARAMETROS:</para>
        /// </summary>
        /// <param name="tcrTitulo">Titulo a mostrar en ventana simple de espera</param>
        /// <param name="tcrEstiloVista">Ubicación de la ventana en la pantalla del sistema: "ABAJO"/"CENTRO"/"ARRIBA"</param>
        /// <returns></returns>
        public static DialogProgressBarEx fobWindEspera(String tcrTitulo, String tcrEstiloVista)
        {
            //- iniciar barra de progreso 
            var lobDialogo = new DialogProgressBarEx();
            lobDialogo.fcvProgressBarIniciar(tcrTitulo, tcrEstiloVista);
            lobDialogo.Show();
            return lobDialogo;
        }
        #endregion
        //------------------------------------------------------------
        // GESTIO COLOR OBJETOS
        //------------------------------------------------------------
        #region FuxSetSolidColorBrush
        /// <summary>
        /// <para>Convertir propiedad de tipo texto a SolidColorBrush</para>
        /// </summary>
        /// <param name="tcrTextoColor">Color en formato tipo texto a convertir</param>
        /// <returns></returns>
        public static SolidColorBrush FuxSetSolidColorBrush(String tcrTextoColor)
        {
            var lsbColor = System.Windows.Media.Brushes.Black;
            if (tcrTextoColor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrTextoColor))
                {
                    lsbColor = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(tcrTextoColor));
                }
            }
            return lsbColor;
        }
        #endregion
        //------------------------------------------------------------
        // LEER OBJETOS EN UN FORMULARIO
        //------------------------------------------------------------
        #region flsListaObjetosVisualTreeDown: devolver una lista de todos los objeto segun tipo dado
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devolve una lista de todos los objeto segun tipo dado en parametro tuxType contenidos en tobReObjFormulario</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobReObjFormulario: referencia a un formulario o un objeto tipo contenedor donde se buscaran los objetos segun tipo</para>
        /// <para>tuxType: Tipo de objetos a buscar segun tipos nativos de c# (TextBox,ComboBox,ChkBox y otros)</para>
        /// <para>el parametro debe ser enviado con el formato ejemplo : typeof(TextBox)/ typeof(ComboBox) ... </para>
        /// <para>----------------------------- </para>
        /// <para>Ejemplo llamada a esta función : var lstObj = flsListaObjetosVisualTreeDown((this.grdPropSelectArea as Visual), typeof(TextBox));</para>
        /// </summary>
        public static IEnumerable<DependencyObject> flsListaObjetosVisualTreeDown(DependencyObject tobReObjFormulario, Type tuxType)
        {
            if (tobReObjFormulario != null)
            {
                if (tobReObjFormulario.GetType() == tuxType)
                {
                    yield return tobReObjFormulario;
                }

                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(tobReObjFormulario); i++)
                {
                    foreach (var obj in flsListaObjetosVisualTreeDown(VisualTreeHelper.GetChild(tobReObjFormulario, i), tuxType))
                    {
                        if (obj != null)
                        {
                            yield return obj;
                        }
                    }
                }
            }

            yield break;
        }
        #endregion
        #region flsListaObjetosVisualTreeDown: Leer lista de objetos contenidos en un objeto tipo contenedor
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devolve una lista de todos los objeto contenidos en tobReObjFormulario</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobReObjFormulario: referencia a un formulario o un objeto tipo contenedor donde se buscaran los objetos segun tipo</para>
        /// <para>----------------------------- </para>
        /// <para>Ejemplo llamada a esta función : var lstObj = flsListaObjetosVisualTreeDown((this.grdDatosUsuario as Visual));</para>
        /// </summary>
        public static List<object> flsListaObjetosVisualTreeDown(Visual tobReObjFormulario)
        {
            if (tobReObjFormulario == null)
            {
                throw new ArgumentNullException("Element {0} is null!", tobReObjFormulario.ToString());
            }

            var lstListaObjetos = new List<object>();

            fcvListaObjetosVisualTreeDown(tobReObjFormulario, ref lstListaObjetos);

            return lstListaObjetos;

        }
        #endregion
        #region fcvListaObjetosVisualTreeDown: listar objetos contenidos en un objeto tipo contenedor
        /// <summary>
        /// <para>DESCRIPCIÓN</para>
        /// <para>Devolve en tlsListObjetos la lista de todos los objeto contenidos en tobReObjFormulario</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobReObjFormulario: referencia a un formulario o un objeto tipo contenedor donde se buscaran los objetos segun tipo</para>
        /// <para>----------------------------- </para>
        /// <para>Ejemplo llamada a esta función:</para>
        /// <para>var lstListaObjetos = new List(object)();</para>
        /// <para>fcvListaObjetosVisualTreeDown(this as Visual, ref lstListaObjetos);</para>
        /// </summary>
        private static void fcvListaObjetosVisualTreeDown(Visual tobReObjFormulario, ref List<object> tlsListObjetos)
        {
            int lnuCountObj = VisualTreeHelper.GetChildrenCount(tobReObjFormulario);

            for (int i = 0; i <= lnuCountObj - 1; i++)
            {
                Visual lobj = (Visual)VisualTreeHelper.GetChild(tobReObjFormulario, i);

                tlsListObjetos.Add((object)lobj);

                if (VisualTreeHelper.GetChildrenCount(lobj) > 0)
                {
                    fcvListaObjetosVisualTreeDown(lobj, ref tlsListObjetos);
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // FUNCIONES GESTION CODIGO FUENTE PLANTILLAS HC
        //------------------------------------------------------------
        #region RefHCTextBoxObjeto: Obtener una referencia tipo TextBox objeto dado el nombre de objeto
        /// <summary>
        /// <para>Ejecutar codigo fuente Historia Clinica</para>
        /// <para>Obtener el valor dato que contiene el objeto, dado el nombre de objeto como parametro</para>
        /// </summary>
        public static TextBox RefHclinicaTextBoxObjeto(String tcrNombreObjeto, ref List<ClassXmlPropObjeto> tmpObjetos)
        {
            TextBox lobText = null;

            var lobRegistro = tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto));
            if (lobRegistro != null)
            {
                lobText = lobRegistro.RefObjeto as TextBox;
            }
            return lobText;
        }
        #endregion
        #region fcrHclinicaLeerValorDato: Obtener el valor del dato que contiene el objeto
        /// <summary>
        /// <para>Ejecutar codigo fuente Historia Clinica</para>
        /// <para>Obtener el valor dato que contiene el objeto, dado el nombre de objeto como parametro</para>
        /// </summary>
        public static String fcrHclinicaLeerValorDato(String tcrNombreObjeto, ref List<ClassXmlPropDatos> tmpObDatos)
        {
            var lcrReturn = String.Empty;

            var lobRegistro = tmpObDatos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto));
            if (lobRegistro != null)
            {
                lcrReturn = lobRegistro.Valor;
            }
            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // FUNCIONES GESTION FACTURA ELECTRONICA DIAN
        //------------------------------------------------------------
        #region FcrGenerarDigitoVerificacionNit: Obtener el digito de verificacion apartir del NIT
        /// <summary>
        /// <para>Obtener el digito de verificacion apartir del NIT</para>
        /// </summary>
        public static string FcrGenerarDigitoVerificacionNit(string tcrNit)
        {

            if (tcrNit == null) return null;
            var larPrimos = new[] { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 }; // Algunos números primos seleccionados por la DIAN.
            var largoNit = tcrNit.Length;
            var lnuSuma = 0;

            for (var i = 0; i < largoNit; i++)
            {
                lnuSuma += (int.Parse(tcrNit[i].ToString()) * larPrimos[largoNit - i - 1]);
            }

            int lnuResiduo = lnuSuma % 11; // Módulo el restante después de una división entera, por ejemplo 13 % 3 da 4,33.. con 4 como parte entera. El módulo se obtiene de 13 - 4 * 3 = 1.
            return lnuResiduo <= 1 ? lnuResiduo.ToString() : (11 - lnuResiduo).ToString();

        } // ObtenerDígitoVerificación>
        #endregion FcrGenerarDigitoVerificacionNit>
        #region FnuAEntero: Función muy rápida de conversión de texto a entero
        /// <summary>
        /// Función muy rápida de conversión de texto a entero. No realiza verificaciones de errores.
        /// </summary>
        //public static int FnuAEntero(this char tctCaracter) => (tctCaracter - '0');
        #endregion FnuAEntero>
        #region Gestion Imagen QR
        #region FobCodigoQrBitmapSource: Generar codigo QR BitmapSource
        /// <summary>
        /// Genera y devuelve una imagen Bitmap con el codigo QR correspondiente al texto dado en parametro 
        /// </summary>
        /// <param name="tcrTexto">Texto para generar el codigo QR</param>
        /// <param name="tnuSize">Tamaño de la imagen en Pixels</param>
        /// <returns></returns>
        public static BitmapSource FobCodigoQrBitmapSource(string tcrTexto, int tnuSize)
        {
            return BitmapConversion.ToWpfBitmap(FobCodigoQrBitmap(tcrTexto, tnuSize));
        }
        #endregion FobCodigoQrBitmapSource>
        #region FobCodigoQrBitmapArray: Generar codigo QR en array byte[]
        /// <summary>
        /// Genera y devuelve una imagen byte[] Bitmap con el codigo QR correspondiente al texto dado en parametro 
        /// </summary>
        /// <param name="tcrTexto">Texto para generar el codigo QR</param>
        /// <param name="tnuSize">Tamaño de la imagen en Pixels</param>
        /// <returns></returns>
        public static byte[] FobCodigoQrBitmapArray(string tcrTexto, int tnuSize)
        {
            return BitmapConversion.ToWpfBitmapArray(FobCodigoQrBitmap(tcrTexto, tnuSize));
        }
        #endregion FobCodigoQrBitmapArray>
        #region FobCodigoQrBitmap: Generar codigo QR en Bitmap
        /// <summary>
        /// Genera y devuelve una imagen con el codigo QR correspondiente al texto dado en parametro
        /// </summary>
        /// <param name="tcrTexto">Texto para generar el codigo QR</param>
        /// <param name="tnuSize">Tamaño de la imagen en Pixels</param>
        /// <returns></returns>
        public static Bitmap FobCodigoQrBitmap(string tcrTexto, int tnuSize)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(tcrTexto, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), System.Drawing.Brushes.Black, System.Drawing.Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var lobImageTemporal = new Bitmap(ms);
            var lobImagen = new Bitmap(lobImageTemporal, new System.Drawing.Size(new System.Drawing.Point(tnuSize, tnuSize)));

            return lobImagen;
        }
        #endregion FobCodigoQrBitmapSource
        #endregion Gestion Imagen QR>
    }
    public static class BitmapConversion
    {

        public static Bitmap ToWinFormsBitmap(this BitmapSource bitmapsource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(stream);

                using (var tempBitmap = new Bitmap(stream))
                {
                    // According to MSDN, one "must keep the stream open for the lifetime of the Bitmap."
                    // So we return a copy of the new bitmap, allowing us to dispose both the bitmap and the stream.
                    return new Bitmap(tempBitmap);
                }
            }
        }

        public static BitmapSource ToWpfBitmap(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        public static byte[] ToWpfBitmapArray(this Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                return stream.ToArray();
            }
        }
    }
}
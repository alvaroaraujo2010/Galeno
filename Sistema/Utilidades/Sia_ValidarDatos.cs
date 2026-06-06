using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SiaValidarDatos : clBaseInpc
    {
        //-------------------------------------------------------
        // SIA - Validaciones varias para datos y campos 
        //-------------------------------------------------------
        //private static DbAplicacion _context;
        //-------------------------------------------------------
        // EMBARAZADA - Paciente embarazada si/no
        //-------------------------------------------------------
        #region fcrEmbarazadaSINO: Validad si esta embarazada SI/NO
        /// <summary>
        /// <para>Validacion paciente embarazada </para>
        /// <para>PARAMETROS:</para>
        /// <para>tnuEdad: dato numerico edad del usuario</para>
        /// <para>tcrMedidaEdad: medida de la edad 1=Año 2=Mes 3= Dia</para>
        /// <para>tcrSexo: M = Masculino F = Femenino</para>
        /// <para>tcrTitulo: Titulo o nombre del campo</para>
        /// <para>DESCRIPCION:
        /// Devuelve una cadena de tipo texto con los errores encontrados</para>
        /// </summary>
        public static String fcrEmbarazadaSINO(String tcrDato, int tnuEdad, String tcrMedidaEdad,String tcrSexo, String tcrTitulo)
        {
            String lcrValorReturn = String.Empty;
            if (string.IsNullOrWhiteSpace(tcrDato))
            {
                lcrValorReturn = tcrTitulo + ": Es requerido";
            }
            else
            {
                if (!Funciones.flgExisteElemento(tcrDato, ",", "1,2,3"))
                {
                    lcrValorReturn = tcrTitulo + ": Dato no es válido";
                }
                else
                {
                    if (tcrMedidaEdad == "2")
                    {
                        tnuEdad = (tnuEdad / 12);
                    }
                    else if (tcrMedidaEdad == "3")
                    {
                        tnuEdad = (tnuEdad / 365);
                    }
                    if (tcrSexo == "F")
                    {
                        if (Funciones.flgExisteElemento(tcrDato, ",", "1,2"))
                        {
                            if (tnuEdad < 12 || tnuEdad > 49)
                            {
                                lcrValorReturn = tcrTitulo + ": Valor no aplica por la edad";
                            }
                        }
                        else
                        {
                            if (tnuEdad >= 12 && tnuEdad <= 49)
                            {
                                lcrValorReturn = tcrTitulo + ": Valor no es valido por la edad";
                            }
                        }
                    }
                    else
                    {
                        if (Funciones.flgExisteElemento(tcrDato, ",", "1,2"))
                        {
                            lcrValorReturn = tcrTitulo + ": Valor no aplica para sexo masculino";
                        }
                    }
                }
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------------
        // DIAGNOSTICOS - Validacion pertinencia de diagnosticos
        //-------------------------------------------------------
        #region fcrPerinenciaDiagnostico:  Validacion pertinencia de diagnosticos
        /// <summary>
        /// <para>Validacion pertinencia de diagnosticos</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigo: Codigo del diagnostico CIE-10</para>
        /// <para>tnuEdad: dato numerico edad del usuario</para>
        /// <para>tcrMedidaEdad: medida de la edad 1=Año 2=Mes 3= Dia</para>
        /// <para>tcrSexo: M = Masculino F = Femenino</para>
        /// <para>tcrSeparadorTexto: Caracter separador para los mensajes de textos error devueltos ejemplo: "*" "//"...</para>
        /// <para>tcrTitulo: Titulo o nombre del campo</para>
        /// <para>DESCRIPCION:
        /// Devuelve una cadena de tipo texto con los errores de pertinencia encontrados</para>
        /// </summary>
        public static String fcrPertinenciaDiagnostico(String tcrCodigo, int tnuEdad,String tcrMedidaEdad,
                                                      String tcrSexo,String tcrSeparadorTexto , String tcrTitulo)
        {
            String lcrValorReturn = String.Empty;

            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                lcrValorReturn = tcrTitulo + ": Es requerido";
            }
            else
            {
                int lnuEdadIni = 0, lnuEdadFin = 0, lnuEdadDias=0;
                String lcrMedidaEdadIni = String.Empty;
                String lcrMedidaEdadFin = String.Empty;
                String lcrSexoAplica    = String.Empty;

                var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                {
                    lnuEdadIni       = (int)tmp.sia_edaini_tdia;
                    lnuEdadFin       = (int)tmp.sia_edafin_tdia;
                    lcrMedidaEdadIni = tmp.sia_medini_tdia;
                    lcrMedidaEdadFin = tmp.sia_medfin_tdia;
                    lcrSexoAplica    = tmp.sia_sexapl_tdia;

                }else
                {
                    lcrValorReturn = tcrTitulo + ": No existe";
                }
                // cuando no hay error
                if (String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    lnuEdadDias=fnuConverEdadDias(tnuEdad, tcrMedidaEdad);
                    lnuEdadIni = fnuConverEdadDias(lnuEdadIni, lcrMedidaEdadIni);
                    lnuEdadFin = fnuConverEdadDias(lnuEdadFin, lcrMedidaEdadFin);

                    // Validad rango edad
                    if (lnuEdadFin > 0)
                    {
                        if (lnuEdadDias < lnuEdadIni || lnuEdadDias > lnuEdadFin)
                        {
                            lcrValorReturn = tcrTitulo + ": Edad fuera de rango permitido en diagnostico";
                        }
                    }

                    //Validar Sexo que aplica
                    if (lcrSexoAplica != "A")
                    {
                        var lcrSexo = tcrSexo == "M" ? "MASCULINO" : "FEMENINO";
                        if (lcrSexoAplica != tcrSexo)
                        {
                            var lcrTexto = tcrTitulo + ": Diagnostico no aplica para Sexo " + lcrSexo;
                            lcrValorReturn = fcrConcatenarTexto(lcrValorReturn, lcrTexto, tcrSeparadorTexto);
                        }
                    }
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fnuConverEdadDias: Convertir edad a dias
        /// <summary>
        /// <para>Convertir edad a dias</para>
        /// <para>PARAMETROS:</para>
        /// <para>tnuEdad: dato numerico edad del usuario</para>
        /// <para>tcrMedidaEdad: medida de la edad 1=Año 2=Mes 3= Dia</para>
        /// </summary>
        public static int fnuConverEdadDias(int tnuEdad, String tcrMedidaEdad)
        {
            int lnuEdadDia = tnuEdad;
            switch (tcrMedidaEdad)
            {
                case "1":   // Año
                    lnuEdadDia = tnuEdad * 365;
                    break;

                case "2":   // Mes
                    lnuEdadDia = tnuEdad * 30;
                    break;
            }
            return lnuEdadDia;
        }
        #endregion
        #region fcrConcatenarTexto: Concatenar textos agregando un separador
        /// <summary>
        /// <para>Concatenar textos agregando un separador</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrSeparador: Caracter separador para los mensajes de textos error devueltos ejemplo: "*" "//"...</para>
        /// </summary>
        public static String fcrConcatenarTexto(String tcrTexto1, String tcrTexto2, String tcrSeparador)
        {
            String lcrTexto = tcrTexto1;
            if (!String.IsNullOrWhiteSpace(tcrTexto1) && !String.IsNullOrWhiteSpace(tcrTexto2))
            {
                lcrTexto = tcrTexto1 + tcrSeparador + tcrTexto2;
            }
            else 
            {
                if (!String.IsNullOrWhiteSpace(tcrTexto2)) { lcrTexto = tcrTexto2; }
            }
            return lcrTexto;
        }
        #endregion
    }
}

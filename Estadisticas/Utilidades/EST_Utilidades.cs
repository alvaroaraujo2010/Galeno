using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Utilidades;
using Sistema.Clases;

namespace Estadisticas.Utilidades
{
    public class ESTUtilidades
    {
        //-------------------------------------------------------------------------------
        // flgValidarRangoHorasAdmisionEx: Validar rango fechas 
        // y horas de la admision sean validas 
        //-------------------------------------------------------------------------------
        #region  flgValidarRangoHorasAdmisionEx: Validar rango fechas y horas
        /// <summary>
        /// Devuelve verdader si el rango de fechas y horas para 
        /// la admision son validos, asumiendo fechas y horas con
        /// formato valido.
        /// </summary>
        public static bool flgValidarRangoHorasAdmisionEx(String tcrFechaIni, String tcrFechaFin, String tcrFormatoFecha,
                                                  String tcrSeparadorFecha, String tcrHoraIni, String tcrHoraFin,
                                                  String tcrFormatoHora, String tcrSeparadorHora)
        {
            var llgValor = false;
            var lcrValorReturn = String.Empty;
            //  Validar que las horas sean validas
            lcrValorReturn = Funciones.fcrValidaHoraTexto(true, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora, "Hora Inicio");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora, "Hora fin")))
            {
                var lnullaveIni = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(tcrFechaIni, tcrFormatoFecha, tcrSeparadorFecha, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora));
                var lnullaveFin = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(tcrFechaFin, tcrFormatoFecha, tcrSeparadorFecha, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora));
                if (lnullaveIni < lnullaveFin) { llgValor = true; }
            }
            return llgValor;
        }
        #endregion
        //-------------------------------------------------------------------------------
        // Hacer sumatorias en grupos 
        //-------------------------------------------------------------------------------
        #region fcrGuardarDatosResumenCentProdServicios: Guarda los datos del resumen general
        /// <summary>
        /// <para>Guarda los datos del resumen general por centros de produccion y servicios</para>
        /// <para>en un registro basado en la clase "ClasseTmpResumen"</para>
        /// <para>Retorna valor de tipo string que indica el grupo etareo al que fue registrado ejemplo: "CONSULTAEXTERNA"</para>
        /// </summary>
        public static String fcrGuardarDatosResumenCentProdServicios(String tcrCodigoCentProduccion, String tcrCodigoDigitacion, ref ClasseTmpResumen lcrRegDat, int tnuValor)
        {
            var lcrReturn = String.Empty;
            var llgRegsuma = false;

            #region Condiciones
            #region GR01 CONSULTA EXTERNA
            if (tcrCodigoCentProduccion == "1110" ||
                tcrCodigoCentProduccion == "1408" ||
                tcrCodigoCentProduccion == "1415")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo1 += tnuValor;
                }
            }
            #endregion
            // GR10 TOTALES GENERAL
            lcrRegDat.Grupo10 += tnuValor;
            #endregion

            return lcrReturn;
        }
        #endregion
        #region flgGuardarDatosGrupoEtareosAños: Sumar datos para resumen por grupos etareos edad en años
        /// <summary>
        /// <para>Sumar datos para resumen por grupos etareos, suma los datos campos "Grupo1, Grupo2, ..."</para>
        /// <para>en un registro basado en la clase "ClasseTmpResumen"</para>
        /// <para>el parametro "tnuEdad" debe estar en años</para>
        /// <para>Retorna valor de tipo string que indica el grupo etareo al que fue registrado ejemplo: "M45A64"=Masculino de 45 a 64 años</para>
        /// </summary>
        public static String  fcrGuardarDatosGrupoEtareosAños(int tnuEdad, String tcSexo, ref ClasseTmpResumen lcrRegDat, int tnuValor)
        {
            var lcrReturn = String.Empty;

            #region Datos del resumen
            // 0 AÑOS MASCULINO
            if (tnuEdad < 1 && tcSexo == "M")
            {
                lcrRegDat.Grupo1 += tnuValor;
                lcrReturn = "M00A00";
            }
            // 0 AÑOS FEMENINO
            if (tnuEdad < 1 && tcSexo == "F")
            {
                lcrRegDat.Grupo2 += tnuValor;
                lcrReturn = "F00A00";
            }
            // 1 a 4 AÑOS MASCULINO
            if (tnuEdad >= 1 && tnuEdad <= 4 && tcSexo == "M")
            {
                lcrRegDat.Grupo3 += tnuValor;
                lcrReturn = "M01A04";
            }
            // 1 a 4 AÑOS FEMENINO
            if (tnuEdad >= 1 && tnuEdad <= 4 && tcSexo == "F")
            {
                lcrRegDat.Grupo4 += tnuValor;
                lcrReturn = "F01A04";
            }
            // 5 a 14 AÑOS MASCULINO
            if (tnuEdad >= 5 && tnuEdad <= 14 && tcSexo == "M")
            {
                lcrRegDat.Grupo5 += tnuValor;
                lcrReturn = "M05A14";
            }
            // 5 a 14 AÑOS FEMENINO
            if (tnuEdad >= 5 && tnuEdad <= 14 && tcSexo == "F")
            {
                lcrRegDat.Grupo6 += tnuValor;
                lcrReturn = "F05A14";
            }
            // 15 a 44 AÑOS MASCULINO
            if (tnuEdad >= 15 && tnuEdad <= 44 && tcSexo == "M")
            {
                lcrRegDat.Grupo7 += tnuValor;
                lcrReturn = "M15A44";
            }
            // 15 a 44 AÑOS FEMENINO
            if (tnuEdad >= 15 && tnuEdad <= 44 && tcSexo == "F")
            {
                lcrRegDat.Grupo8 += tnuValor;
                lcrReturn = "F15A44";
            }
            // 45 a 64 AÑOS MASCULINO
            if (tnuEdad >= 45 && tnuEdad <= 64 && tcSexo == "M")
            {
                lcrRegDat.Grupo9 += tnuValor;
                lcrReturn = "M45A64";
            }
            // 45 a 64 AÑOS FEMENINO
            if (tnuEdad >= 45 && tnuEdad <= 64 && tcSexo == "F")
            {
                lcrRegDat.Grupo10 += tnuValor;
                lcrReturn = "F45A64";
            }
            // MAS DE 65 AÑOS MASCULINO
            if (tnuEdad >= 65 && tcSexo == "M")
            {
                lcrRegDat.Grupo11 += tnuValor;
                lcrReturn = "M65YMAS";
            }
            // MAS DE 65 AÑOS FEMENINO
            if (tnuEdad >= 65 && tcSexo == "F")
            {
                lcrRegDat.Grupo12 += tnuValor;
                lcrReturn = "F65YMAS";
            }
            // TOTAL MASCULINO
            if (tcSexo == "M")
            {
                lcrRegDat.Grupo13 += tnuValor;
            }
            // TOTAL FEMENINO
            if (tcSexo == "F")
            {
                lcrRegDat.Grupo14 += tnuValor;
            }
            // TOTAL GENERAL
            lcrRegDat.Grupo15 += tnuValor;
            #endregion
            return lcrReturn;
        }
        #endregion
        #region fcrGuardarDatosGrupoAreaServicios: Sumar datos para resumen areas de servicios
        /// <summary>
        /// <para>Sumar datos para resumen por grupos, suma los datos campos "Grupo1, Grupo2, ..."</para>
        /// <para>en un registro basado en la clase "ClasseTmpResumen"</para>
        /// <para>Retorna valor de tipo string que indica el grupo etareo al que fue registrado ejemplo: "CONSULTAEXTERNA"</para>
        /// </summary>
        public static String fcrGuardarDatosGrupoAreaServicios(String tcrCodigoCentProduccion,String tcrCodigoDigitacion , ref ClasseTmpResumen lcrRegDat, int tnuValor)
        {
            var lcrReturn = String.Empty;
            var llgRegsuma = false;

            #region Condiciones
            #region GR01 CONSULTA EXTERNA 
            if (tcrCodigoCentProduccion == "1110" ||
                tcrCodigoCentProduccion == "1408" ||
                tcrCodigoCentProduccion == "1415")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo1 += tnuValor;
                }
            }
            #endregion
            #region GR02 OBSERVACION URGENCIAS
            if (tcrCodigoCentProduccion == "1200" ||
                tcrCodigoCentProduccion == "1501" ||
                tcrCodigoCentProduccion == "1201" ||
                tcrCodigoCentProduccion == "1418")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo2 += tnuValor;
                }
            }
            #endregion
            #region GR03 ODONTOLOGIA
            if (tcrCodigoCentProduccion == "1311" ||
                tcrCodigoCentProduccion == "1312" ||
                tcrCodigoCentProduccion == "1313" ||
                tcrCodigoCentProduccion == "1314")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo3 += tnuValor;
                }
            }
            #endregion
            #region GR04 REMISIONES
            if (tcrCodigoDigitacion == "T001" ||
                tcrCodigoCentProduccion == "0008")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo4 += tnuValor;
                }
            }
            #endregion
            #region GR05 LABORATORIO CLINICO
            if (tcrCodigoCentProduccion == "3100")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo5 += tnuValor;
                }
            }
            #endregion
            #region GR06 HOSPITALIZACION
            if (tcrCodigoCentProduccion == "1502" ||
                tcrCodigoCentProduccion == "1503" ||
                tcrCodigoCentProduccion == "1504" ||
                tcrCodigoCentProduccion == "1506" ||
                tcrCodigoDigitacion == "U009")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo6 += tnuValor;
                }
            }
            #endregion
            #region GR07 PROMOCION Y PREVENCION
            if (tcrCodigoCentProduccion == "1114" ||
                tcrCodigoCentProduccion == "1125" ||
                tcrCodigoCentProduccion == "1314" ||
                tcrCodigoCentProduccion == "1401" ||
                tcrCodigoCentProduccion == "1402" ||
                tcrCodigoCentProduccion == "1405" ||
                tcrCodigoCentProduccion == "1407" ||
                tcrCodigoCentProduccion == "1408" ||
                tcrCodigoCentProduccion == "1409" ||
                tcrCodigoCentProduccion == "1410" ||
                tcrCodigoCentProduccion == "1411" ||
                tcrCodigoCentProduccion == "1413" ||
                tcrCodigoCentProduccion == "1415" ||
                tcrCodigoCentProduccion == "1422" ||
                tcrCodigoCentProduccion == "1423" ||
                tcrCodigoCentProduccion == "1111" ||
                tcrCodigoCentProduccion == "1112" ||
                tcrCodigoCentProduccion == "1114" ||
                tcrCodigoCentProduccion == "1113" ||
                tcrCodigoCentProduccion == "0009" ||
                tcrCodigoCentProduccion == "0010" ||
                tcrCodigoCentProduccion == "0011" ||
                tcrCodigoCentProduccion == "1406" ||
                tcrCodigoCentProduccion == "1414")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo7 += tnuValor;
                }
            }
            #endregion
            #region GR08 DROGRAS Y FARMACIA
            if (tcrCodigoCentProduccion == "6023" ||
                tcrCodigoCentProduccion == "7720")
            {
                if (llgRegsuma == false)
                {
                    llgRegsuma = true;
                    lcrRegDat.Grupo8 += tnuValor;
                }
            }
            #endregion
            #region GR09 OTROS
            if (llgRegsuma == false)
            {
                llgRegsuma = true;
                lcrRegDat.Grupo9 += tnuValor;
            }
            #endregion
            // GR10 TOTALES GENERAL
            lcrRegDat.Grupo10 += tnuValor;
            #endregion

            return lcrReturn;
        }
        #endregion
        #region RegistroResumen: Clase parametros basicos de registro para resumen estadisticas
        /// <summary>
        /// <para>Clase parametros basicos de registro para resumen estadisticas</para>
        /// </summary>
        public class RegistroResumen
        {
            #region Datos
            ///<summary>Llave unica secuencial del registro</summary>
            public String Registrollave { get; set; }
            ///<summary>Codigo del registro</summary>
            public String RegistroCodigo { get; set; }
            ///<summary>Codigo del registro 1</summary>
            public String RegistroCodigo1 { get; set; }
            ///<summary>Codigo del registro 2</summary>
            public String RegistroCodigo2 { get; set; }
            ///<summary>Codigo del registro 3</summary>
            public String RegistroCodigo3 { get; set; }
            ///<summary>Nombre o titulo del registro</summary>
            public String RegistroTitulo { get; set; }
            ///<summary>Nombre o titulo del registro</summary>
            public String RegistroTitulo1 { get; set; }
            ///<summary>Nombre o titulo del registro</summary>
            public String RegistroTitulo2 { get; set; }
            ///<summary>Orden visualizacion dentro del informe</summary>
            public int RegistroOrdVista { get; set; }
            ///<summary>Id del grupo al que pertenece el registro</summary>
            public String GrupoId { get; set; }
            ///<summary>Titulo del grupo al que pertenece el registro</summary>
            public String GrupoTitulo { get; set; }
            ///<summary>Tipo grupo para alguna utilidad</summary>
            public String GrupoTipo { get; set; }           
            ///<summary>Orden vista grupo</summary>
            public int GrupoOrdenVista { get; set; }
            ///<summary>Parametros utilitarios</summary>
            public String Parametro1 { get; set; }
            ///<summary>Parametros utilitarios</summary>
            public String Parametro2 { get; set; }
            ///<summary>Parametros utilitarios</summary>
            public String Parametro3 { get; set; }
            #endregion
        }
        #endregion
    }
}

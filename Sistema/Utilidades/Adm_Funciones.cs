using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Utilidades
{
    public class AdmFunciones
    {
        //-------------------------------------------------
        // flgValidarRangoHorasAdmisionEx: Validar rango fechas 
        // y horas de la admision sean validas 
        //-------------------------------------------------
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
        //-------------------------------------------------
        // flgValidarRangoHoras: Validar rango fechas 
        // y horas de la admision sean validas
        //-------------------------------------------------
        #region  flgValidarRangoHoras: Validar rango fechas y horas
        /// <summary>
        /// Devuelve verdader si el rango de fechas y horas para 
        /// la admision son validos.
        /// </summary>
        public static bool flgValidarRangoHorasAdmision(String tcrFechaIni, String tcrFechaFin, String tcrFormatoFecha,
                                                  String tcrSeparadorFecha, String tcrHoraIni, String tcrHoraFin,
                                                  String tcrFormatoHora, String tcrSeparadorHora)
        {
            var llgValor = false;
            var lcrValorReturn = String.Empty;

            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaIni, "Fecha Inicio")) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, tcrFormatoFecha, tcrSeparadorFecha, tcrFechaFin, "Fecha fin")))
            {
                // Validar Rango 
                if (Funciones.flgValidarRangoFecha(tcrFechaIni, tcrFechaFin))
                {
                    //  Validar que las horas sean validas
                    lcrValorReturn = Funciones.fcrValidaHoraTexto(true, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora, "Hora Inicio");
                    if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                        String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora, "Hora fin")))
                    {
                        var lnullaveIni = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(tcrFechaIni, tcrFormatoFecha, tcrSeparadorFecha, tcrHoraIni, tcrFormatoHora, tcrSeparadorHora));
                        var lnullaveFin = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(tcrFechaFin, tcrFormatoFecha, tcrSeparadorFecha, tcrHoraFin, tcrFormatoHora, tcrSeparadorHora));
                        if (lnullaveIni < lnullaveFin) { llgValor = true; }
                    }
                }
            }
            return llgValor;
        }
        #endregion
        //----------------------------------------------------------------------
        // fcrImagenEstadoRegAtencion : Devuelve el nombre de la imagen  del fondo 
        // del Tile segun el estado del registro de atención
        //----------------------------------------------------------------------
        #region fcrImagenEstadoRegAtencion : Devolver imagen fondo tiles
        /// <summary>
        /// fcrImagenEstadoRegAtencion : Devuelve el nombre de la imagen  del fondo 
        /// del Tile segun el estado del registro de atencion
        /// 1=Abierto 2=Cerrado 3=Anulado
        /// </summary>
        public static String fcrImagenEstadoRegAtencion(String tcrEstadoRegistro)
        {
            var lcrImagen = String.Empty;
            switch (tcrEstadoRegistro)
            {
                case "1": //Libre
                    lcrImagen = "sys_tiles2_verdemarino.png";
                    break;

                case "2": // Asginada
                    lcrImagen = "sys_tiles2_naranja.png";
                    break;

                case "3": // Confirmada
                    lcrImagen = "sys_tiles2_rojo.png";
                    break;
            }
            return lcrImagen;
        }
        #endregion
    }
}

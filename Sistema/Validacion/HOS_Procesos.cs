using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;

namespace Sistema.Validacion
{
    /// <summary>Ejecuta los procesos estandares del modulo Hospitalizacion</summary>
    public class HosProcesos
    {
        //-----------------------------------------------------------
        // Variables publicas 
        //-----------------------------------------------------------
        #region Variables Publicas 
        //-----------------------------------------------------------
        // Variables para liquidar Dias de estancia
        #region Variables para liquidar Dias de estancia
        /// <summary>Parametros estancias: Total Dias estancia Calculados</summary>
        public int gnuEstDiasEstancia = 0;
        /// <summary>Parametros estancias: Total horas estancia calculados</summary>
        public int gnuEstHorasEstancia = 0;
        /// <summary>Parametros estancias: Numero horas minimas cobro estancia en urgencias segun contrato</summary>
        public int gnuEstContHorasGenUrgencia = 0;
        /// <summary>Parametros estancias: Numero horas minimas cobro cobro estancia en hospitalizacion segun contrato</summary>
        public int gnuEstContHorasGenHospital = 0;
        /// <summary>Parametros estancias: Id Unico del contrato para liquidacion de la estancia</summary>
        public String gcrEstContNumeroContrato = String.Empty;
        /// <summary>Parametros estancias: Tipo de Atencion "1"=Ambualtoria "2"=Hospitalizacion "3"=Urgencias</summary>
        public String gcrEstTipoAtencionMedica = String.Empty;
        /// <summary>Parametros estancias: Fecha inicial para ralizar liquidacion</summary>
        public DateTime gdaEstFechaInicioLiqidacion;
        /// <summary>Parametros estancias: Fecha final para realizar liquidacion</summary>
        public DateTime gdaEstFechaFinLiqidacion;
        /// <summary>Parametros estancias: hora inicial para liquidacion en formato 12 o 24 horas</summary>
        public String gcrEstHoraInicialLiquidacion = String.Empty;
        /// <summary>Parametros estancias: hora final para liquidacion en formato 12 o 24 horas</summary>
        public String gcrEstHoraFinalLiquidacion = String.Empty;
        /// <summary>Parametros estancias: Formato horas para liquidacion "12"/"24"</summary>
        public String gcrEstHoraFormatoLiquiacion = String.Empty;
        /// <summary>Parametros estancias: Separador formato horas para liquidacion ":" "," segun formato</summary>
        public String gcrEstHoraSeparadorFormato = String.Empty;
        #endregion
        #endregion
        #region  fcvGenerarEstanciaHorasDias: Genera la estancia en horas y dias
        /// <summary>
        ///Genera los dias y horas de estancia segun parametros dados
        /// </summary>
        public void fcvEstGenerarEstanciaHorasDias()
        {
            var lcrValorReturn = String.Empty;
            //---------------------------------------------------
            gnuEstHorasEstancia = Funciones.fnuFechasCalHorasMinutos(gdaEstFechaInicioLiqidacion, gdaEstFechaFinLiqidacion,
                                                                   gcrEstHoraInicialLiquidacion, gcrEstHoraFinalLiquidacion,
                                                                   gcrEstHoraFormatoLiquiacion, gcrEstHoraSeparadorFormato, "H");
            gnuEstDiasEstancia = (int)(gnuEstHorasEstancia / 24);
            gnuEstDiasEstancia = gnuEstDiasEstancia * 24 != gnuEstHorasEstancia ? gnuEstDiasEstancia + 1 : gnuEstDiasEstancia;
            // Verificar segun el contrato para cobro dias de estancia
            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(gcrEstContNumeroContrato);
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_nrocon_cont))
            {
                gnuEstContHorasGenUrgencia = (int)tmp.cto_gestur_cont;
                gnuEstContHorasGenHospital = (int)tmp.cto_gestho_cont;
            }
            // Generar dias de estancia en hospitalizacion 
            if (gcrEstTipoAtencionMedica == "2")
            {
                gnuEstDiasEstancia = gnuEstContHorasGenHospital > gnuEstHorasEstancia ? 0 : gnuEstDiasEstancia;
            }
            // Generar dias de estancia en Urgencias 
            if (gcrEstTipoAtencionMedica == "3")
            {
                gnuEstDiasEstancia = gnuEstContHorasGenUrgencia > gnuEstHorasEstancia ? 0 : gnuEstDiasEstancia;
            }
        }
        #endregion
    }
}

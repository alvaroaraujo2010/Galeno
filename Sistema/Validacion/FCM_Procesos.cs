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
    /// <summary>Ejecuta los procesos estandares par liquidar valor de un servicio facturado</summary>
    public class FcmLiquidar
    {
        //-----------------------------------------------------------
        // Variables publicas facturación servicios
        //-----------------------------------------------------------
        #region Variables publicas facturación servicios 
        //-----------------------------------------------------------
        // Variables para validacion pertinencia servicios IPS
        #region Variables Servicios IPS
        /// <summary>Parametros servicio IPS: Edad inicial convertida en dias para validación</summary>
        public int gnuSipsEdadIniDia = 0;
        /// <summary>Parametros servicio IPS: Edad final convertida en dias para validación</summary>
        public int gnuSipsEdadFinDia = 0;
        /// <summary>Medida edad puntual aplica para validación pertinencia:1=Años 2=Meses 3=Días,4=No Aplica edad puntual</summary>
        public String gcrSipsEdadPuntualMedida = "4";
        /// <summary>Valores edad puntal validación separados por punto y coma (;), ejemplo: 45;50;55;60;65;70</summary>
        public String gcrSipsEdadPuntualValores = String.Empty;
        /// <summary>Parametros servicio IPS: Numero de dias en que aplica frecuencia de uso</summary>
        public int gnuSipsDiasFrecUso = 0;
        /// <summary>Periodo aplicar frecuencia uso: 1=Aplica corte año calendario 2=Hasta que cumpla futura fecha uso</summary>
        public String gcrSipsTipoPeriodoFrecUso = "2";
        /// <summary>Parametros servicio IPS: Cantidad maxima del servicio en una orden o factura</summary>
        public int gnuSipsCantMaxUnaOrden = 0;
        /// <summary>Parametros servicio IPS: Cantidad maxima del servicio en un periodo segun frecuencia de uso</summary>
        public int gnuSipsCantMaxPeriodo = 0;
        /// <summary>Parametros servicio IPS: Medida edad inicial 1=Año/2=Mes/3=Dia</summary>
        public String gcrSipsMedEdadInicial = "1";
        /// <summary>Parametros servicio IPS: Medida edad final 1=Año/2=Mes/3=Dia</summary>
        public String gcrSipsMedEdadFinal = "1";
        /// <summary>Parametros servicio IPS: Valor edad inicial segun medida (variable: gcrSipsMedEdadInicial)</summary>
        public int gnuSipsMedEdadInicialValor = 0;
        /// <summary>Parametros servicio IPS: Valor edad final segun medida (variable: gcrSipsMedEdadFinal)</summary>
        public int gnuSipsMedEdadFinalValor = 0;
        /// <summary>Texto para vista en ventana de error al mostrar rengo edad para la cual aplica el servicio</summary>
        public String gcrTextoRangoEdadServicio = String.Empty;
        /// <summary>Parametros servicio IPS: Sexo al que aplica 1=Masculino/2=Femenino/3=Ambos</summary>
        public String gcrSipsSexoAplica = "A";
        /// <summary>Parametros servicio IPS: El Servicio es POS: 1=POS/2=NO POS</summary>
        public String gcrSipsServPosNoPos = "1";
        /// <summary>Permitir editar el valor del servicio en pantalla, sin tener en cuenta liquidación: 1=Si/2=No</summary>
        public String gcrSipsEditarValorServicio = "2";
        /// <summary>Tipo diagnostico CIE10 del servicio (cuando aplique): 1=impresion diagnostica 2=Confirmado nuevo 3=Confirmado repetido</summary>
        public String gcrSipsDiagnostCie10Tipo = String.Empty;
        /// <summary>Codigo del diagnostico CIE10 del servicio (cuando aplique)</summary>
        public String gcrSipsDiagnostCie10Codigo = String.Empty;
        /// <summary>Finalidad de la consulta (cuando aplique) segun Resoluión RIPS</summary>
        public String gcrSipsFinalidadConsulta = String.Empty;
        /// <summary>Finalidad del procedimiento (cuando aplique) segun Resoluión RIPS</summary>
        public String gcrSipsFinalidadProcedimiento = String.Empty;
        /// <summary>Codigo unico digitacion servicio</summary>
        public String gcrSipsCodDigitacionServicio = String.Empty;
        /// <summary> codigo del procentaje iva cuando aplica</summary>
        public String gcrSipsCodigoPorcentajeIVA = String.Empty;
        /// <summary>Valor del procentaje iva cuando aplica</summary>
        public float gflSipsPorcentajeIVA = 0;
        /// <summary>Lista de rangos complejos de edad para validacion pertinencia</summary>
        public List<ValidRangoEdad> tmpRangoValidEdad = null;
        /// <summary>Lista descripcion rangos complejos de edad </summary>
        public String gcrRangoValidEdadDescripcion = String.Empty;
        
        #region ValidRangoEdad: Validacion rangos de edad pertinencia
        /// <summary>
        /// <para>Validacion rangos de edad pertinencia</para>
        /// </summary>
        public class ValidRangoEdad
        {
            #region Datos
            ///<summary>Indice registro</summary>
            public String Item { get; set; }
            ///<summary>Tipo valor o rango: VD=Valor dia/VM=Valor mes/VA=Valor año/RD=Rango dia/RM=rango mes/RA=Rango año</summary>
            public String Tipo { get; set; }
            ///<summary>Valor uno</summary>
            public int Valor1 { get; set; }
            ///<summary>Valor dos</summary>
            public int Valor2 { get; set; }
            #endregion
        }
        #endregion
        //------------------------------------------------
        // Gestion frecuencia de uso del servicio
        //------------------------------------------------
        /// <summary>Parametros servicio IPS: Aplica frecuencia de uso al servicio 1=SI/2=NO</summary>
        public String gcrSipsAplicaFrecuenUso = "2";
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, solo se accede al servicio una unica vez: 1= Unica Vez 2 = Multiples veces</summary>
        public String gcrSipsFreUsoUnicaVez = "2";
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, Numero de dias configurados para volver a usar el servicio</summary>
        public int gnuSipsFreUsoDiasFrecuen = 0;
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, existe registro en maestro historial: 1= Existe 2= No Existe</summary>
        public String gcrSipsFreUsoExistReg ="2";
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, total unidades facturadas anteriores</summary>
        public int gnuSipsFreUsoTotalUnidades = 0;
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, fecha ultima prestacion servicio (vacia es 01/01/0001)</summary>
        public DateTime gdaSipsFreUsoFechaAnterior = DateTime.Parse("01/01/0001");
        /// <summary>Parametros servicio IPS: Frecuencia uso de servicio, fecha futura proximo uso servicio (vacia es 01/01/0001)</summary>
        public DateTime gdaSipsFreUsoFechaFutura = DateTime.Parse("01/01/0001");
        #endregion
        //-----------------------------------------------------------
        // Variables para validacion manual tarifario servicios
        #region Variables manual tarifario servicios MANT
        /// <summary>Tarifario de venta: Liquidar en ambulatoria: 1= Copago 2=C.moderadora 3=Copago/C.Moderadora 4=No cobrar </summary>
        public String gcrMantLiqCopCmodAmbulat = "4";
        /// <summary>Tarifario de venta: Liquidar Hospitalizacion: 1= Copago 2=C.moderadora 3=Copago/C.Moderadora 4=No cobrar </summary>
        public String gcrMantLiqCopCmodHospita = "4";
        /// <summary>Tarifario de venta: Liquidar Urgencias: 1= Copago 2=C.moderadora 3=Copago/C.Moderadora 4=No cobrar </summary>
        public String gcrMantLiqCopCmodUrgenci = "4";
        /// <summary>Tarifario de venta: Alcance Pos en Ambulatoria 1 = Si 2= No</summary>
        public String gcrMantAlcancePosAmbulat = "1";
        /// <summary>Tarifario de venta: Alcance Pos en Hospitalización 1 = Si 2= No</summary>
        public String gcrMantAlcancePosHospita = "1";
        /// <summary>Tarifario de venta: Alcance Pos en Urgencias 1 = Si 2= No</summary>
        public String gcrMantAlcancePosUrgenci = "1";
        /// <summary>Recalcular precio segun porcentajes y cubrimientos del contrato: 1=Permitir recalcular según contrato/2=Cobrar Tarifa plena</summary>
        public String gcrMantPrecioTarifaContr = "1";
        /// <summary>Tarifario de venta: Valor servicio en manual</summary>
        public float gnuMantValorServicio = 0;
        /// <summary>Tarifario de venta: Puntaje para calcular valor servicio</summary>
        public float gnuMantPuntajeValorServ = 0;
        /// <summary>Tarifario de venta: Tipo liquidacion copagos c.moderadoras 1= Valor calculado 2=Valor fijo en tarifario</summary>
        public String gnuMantTipoLiqCopagoCmoderadora = "1";
        /// <summary>Tarifario de venta: Valor copago o cuota moderadora cuando es un valor fijo</summary>
        public float gnuMantValorFijoCopagoCModerad = 0;
        #endregion
        //-----------------------------------------------------------
        // Variables para validacion Contrato: CONT
        #region Variables Contrato en digitacion servicio
        /// <summary>Parametros Contrato: Regimen del afiliado segun contrato en digitacion: 1=Contributivo/2=Subsidiado/3=Vinculados/4=Particular/5=Otros (Resolucion: 3374 RIPS)</summary>
        public String gcrContTipoRegimenAfiliado = String.Empty;
        /// <summary>Parametros Contrato: Validar Frecuencia de uso servicios 1=SI/2=NO</summary>
        public String gcrContValidFrecUsoServi = "2";
        /// <summary>Parametros Contrato: Cubrimiento servicios: 1=Pos/2=No pos/3=Cubre ambos</summary>
        public String gcrContCubrimPosNoPos = "3";
        /// <summary>Parametros Contrato: No separar por asistencial pyp o salud publica: 1= Separar/2=No Separar</summary>
        public String gcrContSepararServicios = "2";
        /// <summary>Parametros Contrato: Aplicar descuentos 1=Si 2=No</summary>
        public String gcrContAplicarDescuentos = "2";
        /// <summary>Parametros Contrato: Realizar Deduccion de copago: 1=Si/2=NO</summary>
        public String gcrContAplicarCopago = "1";
        /// <summary>Parametros Contrato: Realizar deduccion de cuota moderadora: 1=Si/2=NO</summary>
        public String gcrContAplicarCmoderad = "1";
        /// <summary>Parametros Contrato: Cobro en efectivo servicios 1=Si/2=NO</summary>
        public String gcrContEfectivoServicios = "1";
        /// <summary>Parametros Contrato: Cobro en efectivo Copagos 1=Si/2=NO</summary>
        public String gcrContEfectivoCopago = "1";
        /// <summary>Parametros Contrato: Cobro en efectivo Cuotas moderadoras: 1=Si/2=NO</summary>
        public String gcrContEfectivoCmoderad = "1";
        /// <summary>Parametros Contrato: Cobro en efectivo cargo al usuario: 1=Si/2=NO</summary>
        public String gcrContEfectivoCargUsuar = "1";
        /// <summary>Parametros Contrato: Tipo liquidación 1=SOAT/2=ISS/3=Cups o valor simple</summary>
        public String gcrContTipLiqManualTarifa = "1";
        /// <summary>Parametros Contrato: Valor ajuste al calcular valor servicio a 0 5 10 20 50 100 ... </summary>
        public int gnuContValorAjustePrecio = 0;
        /// <summary>Parametros Contrato: Porcentaje de recargo o descuento precio 10, 05, -10 ...</summary>
        public float gnuContPorRecargoPrecio = 0;
        /// <summary>Parametros Contrato: Porcentaje de cubrimiento del servicio 100%, 50%... otro</summary>
        public float gnuContPorCubrimiePrecio = 0;
        /// <summary>Parametros Contrato: Codigo del manual tarifario ejm: 01=ISS/02=SOAT/03=CUPS ...</summary>
        public String gcrContManualTarifario = String.Empty;
        /// <summary>Parametros Contrato: descontar copago de valor servicio, 1=Descontar de valor servicio  2=No descontar de valor servicio</summary>
        public String gcrContDescontarCopago = String.Empty;
        /// <summary>
        /// <para>Parametros Contrato: Utilizar servicios personalizados tarifario: 1= Usar servicios personalizados y del tarifario</para>
        /// <para>2 = Usar solo servicios perzonalizados  3= No usar servicios personalizados</para>
        /// </summary>
        public String gcrContServPersonalizados = "1";
        #endregion
        //-----------------------------------------------------------
        // Variables Varios multipropositos y Varias: OTRS
        #region Variables Varios mutipropositos y Varias: OTRS
        /// <summary>Variables Varias: Valor del salario minimo mensual</summary>
        public int gnuOtrsValorSalarioMes = 0;
        /// <summary>Variables Varias: Valor del salario minimo un dia (mes/30)</summary>
        public float gnuOtrsValorSalarioDia = 0;
        #endregion
        //-----------------------------------------------------------
        //- Variables datos de la admision para calculos
        #region Variables datos de la admision para calculos
        /// <summary>Valores admisión: Id unico del Usuario en Base de Datos sistema</summary>
        public String gcrAdmIdUnicoUsuario = String.Empty;
        /// <summary>Valores admisión: Sexo del afiliado</summary>
        public String gcrAdmSexoDelAfiliado = String.Empty;
        /// <summary>Valores admisión: Regimen del afiliado 1=Contributivo/2=Subsidiado/3=Vinculados/4=Particular/5=Otros (Resolucion: 3374 RIPS)</summary>
        public String gcrAdmTipoRegimenAfiliado = String.Empty;
        /// <summary>Valores admisión: Ambito prestacion servicio: 1=Ambulatoria 2= Hospitalizacion 3= Urgencias</summary>
        public String gcrAdmAmbitoAtencion = String.Empty;
        /// <summary>Valores admisión: Tipo afiliado contributivo C=Cotizante/B=Beneficiario/A=Adicional</summary>
        public String gcrAdmTipoAfilContributivo = String.Empty;
        /// <summary>Valores admisión: Fecha de nacimiento</summary>
        public String gcrAdmFechaNacimiento = String.Empty;
        /// <summary>Valores admisión: Fecha de admision</summary>
        public String gcrAdmFechaAdmision = String.Empty;
        /// <summary>Valores admisión: Fecha prestación del servicio</summary>
        public String gcrAdmFechaServicio = String.Empty;
        /// <summary>Valores admisión: Fecha agenda de cita para prestación del servicio</summary>
        public String gcrAdmFechaAgendaCita = String.Empty;
        /// <summary>Valores admisión: Nivel Sisben: 1,2,3,N</summary>
        public String gcrAdmNivelSisben = String.Empty;
        /// <summary>Valores admisión: Código Nivel Contributivo "1","2","3"... segun tabla para Calcular cuotas Moderadoras y copagos</summary>
        public String gcrAdmNivelContributivo = String.Empty;
        /// <summary>Valores admisión: Edad en años del paciente</summary>
        public int gnuAdmEdadEnAños = 0;
        /// <summary>Valores admisión: Edad en meses del paciente</summary>
        public int gnuAdmEdadEnMeses = 0;
        /// <summary>Valores admisión: Edad en dias del paciente</summary>
        public int gnuAdmEdadEnDias = 0;
        #endregion
        //-----------------------------------------------------------
        // Parametros para retornar valor liquidado servicios en facturacion
        #region Parametros para retornar valor liquidado servicios en facturacion
        /// <summary>Valores liquidados: Valor total del descuento</summary>
        public float Fcm_valdes_dfac = 0;
        /// <summary>Valores liquidados: Valor porcentaje descuento</summary>
        public float Fcm_pordes_dfac = 0;
        /// <summary>Valores liquidados: Valor servicio calculado para venta segun tarifario (valor base)</summary>
        public float Fcm_valser_mant = 0;
        /// <summary>Valores liquidados: Valor bruto del servicio calculado sin descuentos</summary>
        public float Fcm_valbru_dfac = 0;
        /// <summary>Valores liquidados: Valor subtotal haciendo deducciones desde valor bruto: (bruto-(cargo a usuario + descuento)) </summary>
        public float Fcm_valsub_dfac = 0;
        /// <summary>Valores liquidados: Valor total final del servicio mas el IVA (cuando aplique IVA)</summary>
        public float Fcm_valfac_dfac = 0;
        /// <summary>Valores liquidados: Valor total cuota moderadora recaudada en servicio (cuando aplique)</summary>
        public float Fcm_valcmo_dfac = 0;
        /// <summary>Valores liquidados: Valor total copago del servicio (cuando aplique)</summary>
        public float Fcm_valcpa_dfac = 0;
        /// <summary>Valores liquidados: Total unidades facturadas del servicio</summary>
        public int Fcm_totuni_dfac = 1;
        /// <summary>Valores liquidados: Valor del cargo al usuario (cuando aplique)</summary>
        public float Fcm_valusu_dfac = 0;
        /// <summary>Valores liquidados: Porcentaje del iva para aplicar en servicio (cuando aplique)</summary>
        public float Fcm_poriva_dfac = 0;
        /// <summary>Valores liquidados: Valor del iva recaudado en servicio (cuando aplique)</summary>
        public float Fcm_valiva_dfac = 0;
        
        #endregion
        #endregion
        //-------------------------------------------------
        // flgCargarParametrosSalarioMinimo: Cargar el valor salario minimo mes 
        //-------------------------------------------------
        #region flgCargarParametrosSalarioMinimo: Cargar el valor salario minimo mes 
        /// <summary>
        /// <para>Cargar valor del salario minimo vigente para la fecha dada en parametro</para> 
        /// </summary>
        public bool flgCargarParametrosSalarioMinimo(DateTime tdaFecha)
        {
            var llgReturn = false;
            var lobjSalario = SISValidarCodigo.fobRegBuscarSissalariominFx(tdaFecha);

            gnuOtrsValorSalarioMes = 0;   // Valor del salario minimo mensual 
            gnuOtrsValorSalarioDia = 0;   // Valor del salario minimo un dia (mes/30)

            if (!String.IsNullOrWhiteSpace(lobjSalario.sis_dessal_tsal))
            {
                llgReturn = true;
                gnuOtrsValorSalarioMes = (int)lobjSalario.sis_valsal_tsal;
                gnuOtrsValorSalarioDia = gnuOtrsValorSalarioMes / 30;
            }

            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // fobParamServiValorDefectoVariables: Valores por defecto variables calculo valor servicio
        //-------------------------------------------------
        #region fcvValorDefectoVariables: Valores por defecto variables de control
        /// <summary>
        /// <para>Reiniciar los valores por defectos en las variables que controlan</para> 
        /// <para>Validacion pertinencia y calcular volor servicios.</para> 
        /// </summary>
        public void fcvValorDefectoVariables()
        {
            #region fcvValor Defecto Variables
            // Servicios IPS
            gnuSipsEdadIniDia           = 0;
            gnuSipsEdadFinDia           = 0;
            gcrSipsMedEdadInicial       = "1";
            gcrSipsMedEdadFinal         = "1";
            gcrSipsEdadPuntualMedida    = "4";
            gcrSipsEdadPuntualValores   = String.Empty;
            gnuSipsDiasFrecUso          = 0;
            gnuSipsCantMaxUnaOrden      = 0;
            gnuSipsCantMaxPeriodo       = 0;
            gcrSipsTipoPeriodoFrecUso   = "2";
            gcrSipsSexoAplica           = "A";
            gcrSipsAplicaFrecuenUso     = "2";
            gcrSipsFreUsoUnicaVez       = "2";
            gnuSipsFreUsoDiasFrecuen    = 0;
            gcrSipsFreUsoExistReg       ="2";
            gcrSipsDiagnostCie10Tipo    = String.Empty;
            gcrSipsDiagnostCie10Codigo  = String.Empty;
            gcrSipsFinalidadConsulta    = String.Empty;
            gcrSipsFinalidadProcedimiento = String.Empty;
            gnuSipsFreUsoTotalUnidades  = 0;
            gdaSipsFreUsoFechaAnterior  = DateTime.Parse("01/01/0001");
            gdaSipsFreUsoFechaFutura    = DateTime.Parse("01/01/0001");
            gcrSipsCodDigitacionServicio = String.Empty;
            tmpRangoValidEdad            = null;
            gcrRangoValidEdadDescripcion = String.Empty;
            // Manual tarifario
            gcrMantLiqCopCmodAmbulat  = "4";
            gcrMantLiqCopCmodHospita  = "4";
            gcrMantLiqCopCmodUrgenci  = "4";
            gcrMantPrecioTarifaContr  = "1";
            gnuMantValorServicio      = 0;
            gnuMantPuntajeValorServ   = 0;
            // Contrato
            gcrContTipoRegimenAfiliado= String.Empty; 
            gcrContValidFrecUsoServi  = "2";
            gcrContCubrimPosNoPos     = "3";
            gcrContSepararServicios   = "2"; // No separar por asistencial pyp o salud publica
            gcrContAplicarDescuentos  = "2"; // Aplicar descuentos 1=Si 2=No
            gcrContEfectivoServicios  = "1"; // Cobro en efectivo servicios 1=Si/2=NO
            gcrContEfectivoCopago     = "1"; // Cobro en efectivo Copagos
            gcrContEfectivoCmoderad   = "1"; // Cobro en efectivo Cuotas moderadoras
            gcrContEfectivoCargUsuar  = "1"; // Cobro en efectivo cargo al usuario
            gnuContValorAjustePrecio  = 0;   // Valor Ajuste al calcular valor servicio a 10 20 50 100 ... 
            gnuContPorRecargoPrecio   = 0;   // Porcentaje de recargo o descuento precio 10, 05, -10 ...
            gnuContPorCubrimiePrecio  = 0;   // Porcentaje cubrimiento precio 100%, 50%.. otros
            // Variables Admisión
            gcrAdmIdUnicoUsuario      = String.Empty;
            gcrAdmSexoDelAfiliado     = String.Empty;
            gcrAdmTipoRegimenAfiliado = String.Empty;
            gcrAdmAmbitoAtencion      = String.Empty;
            gcrAdmTipoAfilContributivo= String.Empty;
            gcrAdmFechaNacimiento     = String.Empty;
            gcrAdmFechaAdmision       = String.Empty;
            gcrAdmFechaServicio       = String.Empty;
            gcrAdmFechaAgendaCita     = String.Empty;
            gcrAdmNivelSisben         = String.Empty;
            gcrAdmNivelContributivo   = String.Empty;
            // Propositos varios 
            gnuOtrsValorSalarioMes = 0;   // Valor del salario minimo mensual 
            gnuOtrsValorSalarioDia = 0;   // Valor del salario minimo un dia (mes/30)
            //Parametros para retornar valor liquidado servicios en facturacion
            Fcm_valdes_dfac = 0;
            Fcm_pordes_dfac = 0;
            Fcm_valser_mant = 0;
            Fcm_valbru_dfac = 0;
            Fcm_valsub_dfac = 0;
            Fcm_valfac_dfac = 0;
            Fcm_valcmo_dfac = 0;
            Fcm_valcpa_dfac = 0;
            #endregion
        }
        #endregion
        //-------------------------------------------------
        // flgCargarParametrosContrato: Cargar parametros desde contrato
        //-------------------------------------------------
        #region flgCargarParametrosContrato: Cargar parametros desde contrato
        /// <summary>
        /// <para>Cargar parametros del contrato</para> 
        /// <para>tcrIdContrato: Id unico contrato</para> 
        /// </summary>
        public bool flgCargarParametrosContrato(String tcrIdContrato)
        {
            var llgReturn = false;

            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tcrIdContrato);
            llgReturn = flgCargarParametrosContrato(tmp);

            return llgReturn;
        }
        #endregion
        #region flgCargarParametrosContrato: Cargar parametros desde contrato desde registro
        /// <summary>
        /// <para>Cargar parametros del contrato desde registro temporal</para> 
        /// <para>tobRegContr: temporal registro tipo EFctomaescontrato</para> 
        /// </summary>
        public bool flgCargarParametrosContrato(EFctomaescontrato tobRegContr)
        {
            var llgReturn = false;

            if (tobRegContr != null && !String.IsNullOrWhiteSpace(tobRegContr.cto_nrocon_cont))
            {
                llgReturn = true;
                // Datos para variables de control
                gcrContTipoRegimenAfiliado  = tobRegContr.sia_tipusu_regi.Trim(); // Regimen salud del contrato
                gcrContValidFrecUsoServi    = tobRegContr.cto_frecus_cont.Trim(); // Frecuencia de uso del servicio
                gcrContCubrimPosNoPos       = tobRegContr.cto_posnpo_cont.Trim(); // pos no pos o ambos
                gcrContSepararServicios     = tobRegContr.cto_sepser_cont.Trim(); // 1=Si 2=No separar por asistencial pyp o salud publica    
                gnuContValorAjustePrecio    = (int)tobRegContr.cto_ajupre_cont;   // Ajuste al calcular valor servicio a 0 5 10 20 50 100  y otros...   
                gnuContPorRecargoPrecio     = (float)tobRegContr.cto_porrec_cont; // Porcentaje de recargo o descuento precio 10, 05, -10 ...
                gnuContPorCubrimiePrecio    = (float)tobRegContr.cto_porcub_cont; // Porcentaje cubrimiento precio 100%, 50%.. otros
                gcrContAplicarCopago        = tobRegContr.cto_liqcop_cont.Trim(); // Deduccion de copago: 1=Si/2=NO
                gcrContAplicarCmoderad      = tobRegContr.cto_liqmod_cont.Trim(); // deduccion de cuota moderadora: 1=Si/2=NO
                gcrContAplicarDescuentos    = tobRegContr.cto_apldes_cont.Trim(); // Aplicar descuentos 1=Si 2=No
                gcrContEfectivoServicios    = tobRegContr.cto_cobser_cont.Trim(); // Cobro en efectivo servicios 1=Si/2=NO
                gcrContEfectivoCopago       = tobRegContr.cto_cobcop_cont.Trim(); // Cobro en efectivo Copagos
                gcrContEfectivoCmoderad     = tobRegContr.cto_cobmod_cont.Trim(); // Cobro en efectivo Cuotas moderadoras
                gcrContEfectivoCargUsuar    = tobRegContr.cto_cobcus_cont.Trim(); // Cobro en efectivo cargo al usuario
                gcrContManualTarifario      = tobRegContr.fcm_codman_mans.Trim(); // Codigo del manual tarifario ejm: 01=ISS/02=SOAT/03=CUPS
                gcrContDescontarCopago      = tobRegContr.cto_dedcop_cont.Trim(); // Descontar copago de valor servicio, 1=Descontar 2=No descontar de valor servicio
                gcrContServPersonalizados   = tobRegContr.cto_serper_cont.Trim(); // Utilizar servicios personalizados configurados como detalles del contrato
                //- Tipo Manual
                var lobRegTipoMan = FCMValidarCodigo.fobRegBuscarFcmmantarifario(gcrContManualTarifario);
                gcrContTipLiqManualTarifa = lobRegTipoMan.fcm_codtar_ttar.Trim();
            }

            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // flgCargarParametrosServicio: Cargar parametros desde servicios
        //-------------------------------------------------
        #region flgCargarParametrosServicio: Cargar parametros desde manual tarifario 
        /// <summary>
        /// <para>Cargar parametros desde manual tarifario de ventas y servicios IPS</para> 
        /// <para>tcrCodigoDigitacion: Codigo de digitacion del servicio</para> 
        /// </summary>
        public bool flgCargarParametrosServicio(String tcrCodigoDigitacion)
        {
            var llgReturn = false;

            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(tcrCodigoDigitacion, gcrContManualTarifario);
            llgReturn = flgCargarParametrosServicio(tmp);

            return llgReturn;
        }
        #endregion
        #region flgCargarParametrosServicio: Cargar parametros desde manual tarifario dado el temporal
        /// <summary>
        /// <para>Cargar parametros desde manual tarifario de ventas y servicios IPS</para> 
        /// <para>tmpRegServ: temporal rregistro manual tarifario de servicio</para> 
        /// </summary>
        public bool flgCargarParametrosServicio(EFfcmmanservicios tmpRegServ)
        {
            var llgReturn = false;

            if (tmpRegServ != null)
            {
                var tmpIps = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(tmpRegServ.fcm_coddig_mant.Trim());

                if (tmpRegServ != null && tmpIps != null)
                {
                    llgReturn = true;
                    #region fcmmanservicios
                    gnuMantTipoLiqCopagoCmoderadora = tmpRegServ.fcm_tipccp_mant;
                    gnuMantValorFijoCopagoCModerad  = (float)tmpRegServ.fcm_vficop_mant;
                    gnuMantValorServicio            = (float)tmpRegServ.fcm_valser_mant;
                    gnuMantPuntajeValorServ         = (float)tmpRegServ.fcm_punuvr_mant;

                    // Para liquidacion de copagos y cuotas moderadoras
                    gcrMantLiqCopCmodAmbulat = tmpIps.fcm_lamccp_sips.Trim();
                    gcrMantLiqCopCmodHospita = tmpIps.fcm_lhoccp_sips.Trim();
                    gcrMantLiqCopCmodUrgenci = tmpIps.fcm_luoccp_sips.Trim();

                    //- alcance del servicio Pos o No Pos segun ambito
                    gcrMantAlcancePosAmbulat = tmpRegServ.fcm_alcamb_mant.Trim();
                    gcrMantAlcancePosHospita = tmpRegServ.fcm_alchos_mant.Trim();
                    gcrMantAlcancePosUrgenci = tmpRegServ.fcm_alcurg_mant.Trim();
                    gcrMantPrecioTarifaContr = tmpRegServ.fcm_facpln_mant.Trim();
                    #endregion
                    //-------------------------------------
                    //- Cargar parametros del servicio IPS
                    //-------------------------------------
                    // si hay cobro de IVA 
                    var lobReIVa = SISValidarCodigo.fobRegBuscarSistablaiva(tmpIps.sis_codiva_tiva);

                    #region Cargar parametros del servicio IPS
                    gcrSipsCodigoPorcentajeIVA  = tmpIps.sis_codiva_tiva.Trim();
                    gflSipsPorcentajeIVA        = lobReIVa.sis_poriva_tiva > 0 ? (float)lobReIVa.sis_poriva_tiva : 0;
                    gnuSipsMedEdadInicialValor  = (int)tmpIps.fcm_edaini_sips;
                    gnuSipsMedEdadFinalValor    = (int)tmpIps.fcm_edafin_sips;
                    gcrSipsMedEdadInicial       = tmpIps.fcm_mededi_sips.Trim();
                    gcrSipsMedEdadFinal         = tmpIps.fcm_mededf_sips.Trim();
                    gcrSipsEdadPuntualMedida    = tmpIps.fcm_mededp_sips.Trim();
                    gcrSipsEdadPuntualValores   = tmpIps.fcm_edapun_sips.Trim();
                    gnuSipsDiasFrecUso          = (int)tmpIps.fcm_intser_sips;
                    gnuSipsCantMaxUnaOrden      = (int)tmpIps.fcm_maxord_sips;
                    gnuSipsCantMaxPeriodo       = (int)tmpIps.fcm_maxint_sips;
                    gcrSipsAplicaFrecuenUso     = tmpIps.fcm_aplfus_sips.Trim();
                    gcrSipsTipoPeriodoFrecUso   = tmpIps.fcm_perfus_sips.Trim();
                    gnuSipsFreUsoDiasFrecuen    = (int)tmpIps.fcm_intser_sips;
                    gcrSipsSexoAplica           = tmpIps.fcm_sexapl_sips.Trim();
                    gcrSipsServPosNoPos         = tmpIps.fcm_serpos_sips.Trim();
                    gcrSipsEditarValorServicio  = tmpIps.fcm_edtval_sips.Trim();
                    gcrSipsDiagnostCie10Tipo    = tmpIps.sia_tipdxp_tdix.Trim();
                    gcrSipsDiagnostCie10Codigo  = tmpIps.sia_coddia_tdia.Trim();
                    gcrSipsFinalidadConsulta    = tmpIps.sia_codfco_fcon.Trim();
                    gcrSipsFinalidadProcedimiento = tmpIps.sia_codfpr_fpro.Trim();
                    gcrSipsCodDigitacionServicio = tmpIps.fcm_coddig_mant.Trim();

                    gnuSipsEdadIniDia           = fnuEdadEnDias(gcrSipsMedEdadInicial, gnuSipsMedEdadInicialValor);
                    gnuSipsEdadFinDia           = fnuEdadEnDias(gcrSipsMedEdadFinal, gnuSipsMedEdadFinalValor);
                    gcrTextoRangoEdadServicio   = fcrTextoRangoEdadServicio(gcrSipsMedEdadInicial, gnuSipsMedEdadInicialValor, gcrSipsMedEdadFinal, gnuSipsMedEdadFinalValor);
                    #endregion
                    //-------------------------------------
                    // Validar si aplica frecuencia de uso
                    //-------------------------------------
                    if (gcrContValidFrecUsoServi == "1" &&  gcrSipsAplicaFrecuenUso =="1")
                    {
                        gcrSipsFreUsoExistReg = "2";
                        var lobRegFrb = FCMValidarCodigo.fobRegBuscarFcmfrecuenciuso(gcrAdmIdUnicoUsuario, tmpRegServ.fcm_coddig_mant);

                        if (lobRegFrb != null)
                        {
                            gcrSipsFreUsoExistReg = "1";
                            gnuSipsFreUsoTotalUnidades  = (int)lobRegFrb.fcm_totuni_dfac;
                            gdaSipsFreUsoFechaAnterior  = (DateTime)lobRegFrb.fcm_fecser_dfac;
                            gdaSipsFreUsoFechaFutura    = gdaSipsFreUsoFechaAnterior.AddDays(gnuSipsFreUsoDiasFrecuen);
                            //gdaSipsFreUsoFechaFutura  = (DateTime)lobRegFrb.fcm_fecpro_fcfu;
                        }
                    }
                    //-------------------------------------
                    //- Ajustar parametro para tipo liquidacion servicios 
                    //- Personalizados configurados como detalles del contrato
                    //-------------------------------------
                    #region Servicios Personalizados
                    if (gcrContServPersonalizados != "3" && tmpRegServ.fcm_codman_mans != gcrContManualTarifario)
                    {
                        //- Tipo Manual
                        var lobRegTipoMan = FCMValidarCodigo.fobRegBuscarFcmmantarifario(tmpRegServ.fcm_codman_mans);
                        if (lobRegTipoMan != null)
                        {
                            gcrContTipLiqManualTarifa = lobRegTipoMan.fcm_codtar_ttar.Trim();
                        }
                    }
                    #endregion

                    if (!String.IsNullOrWhiteSpace(gcrSipsEdadPuntualValores) && gcrSipsEdadPuntualValores != "NA")
                    {
                        tmpRangoValidEdad = fobTempValidRangoEdad(gcrSipsEdadPuntualValores);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region fobTempValidRangoEdad : Genera el temporal de validacion de ramngos de edad 
        /// <summary>
        /// <para> Genera el temporal de validacion rangos de edad dado la string de valores y rangos complejos</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrStringLista: string con  valores complejos ejemplo VD-5*RD-20-30*VM-10*RA-1-2</para>
        /// </summary>
        public List<ValidRangoEdad> fobTempValidRangoEdad(String tcrStringLista)
        {
            List<ValidRangoEdad> lstTempReturn = null;
            var lobReg = new ValidRangoEdad();
            gcrRangoValidEdadDescripcion = String.Empty;

            String[] larArray = (tcrStringLista).Split("*".ToCharArray());
            int lnuTotElemtos = larArray.Length;
            var lcrComando = larArray[0].Trim();
            var i = 0;

            if (lnuTotElemtos > 0)
            {
                lstTempReturn = new List<ValidRangoEdad>();

                for (i = 0; i < lnuTotElemtos; i++)
                {
                    var lcrDescripValidEdad = String.Empty;
                    String[] larRangoValor = (larArray[i].Trim()).Split("-".ToCharArray());

                    // verificar el tipo segun string ejemplo: VD-5*RD-20-30*VM-10*RA-1-2
                    if (larRangoValor.Length > 1)
                    {
                        var lcrTipo = larRangoValor[0].Trim();
                        var lnuV1   = Convert.ToInt32(larRangoValor[1].Trim());
                        var lnuV2   = 0;

                        if (larRangoValor[0].Substring(0, 1) == "V")
                        {
                            // Es solo un valor ejemplo asi: VD-45
                            lstTempReturn.Add(new ValidRangoEdad
                            {
                                Item = i.ToString(),
                                Tipo = lcrTipo,
                                Valor1 = lnuV1,
                            });
                        }
                        else
                        {
                            // Es rango ejemplo asi: RD-4-50 puede ser RD - RA - RM 
                            lnuV2   = Convert.ToInt32(larRangoValor[2].Trim());

                            lstTempReturn.Add(new ValidRangoEdad
                            {
                                Item = i.ToString(),
                                Tipo = lcrTipo,
                                Valor1 =lnuV1,
                                Valor2 = lnuV2,
                            });

                        }
                        lcrDescripValidEdad = fcrTextoDescripRangoComplejoEdad(larRangoValor[0].Trim(),lnuV1,lnuV2);
                        gcrRangoValidEdadDescripcion = String.IsNullOrWhiteSpace(gcrRangoValidEdadDescripcion) ?
                                                              "EDADES PERMITIDAS: " + lcrDescripValidEdad : gcrRangoValidEdadDescripcion +"/" +lcrDescripValidEdad; 
                    }
                }
            }

            return lstTempReturn;
        }
        #endregion
        #region fcrTextoDescripRangoComplejoEdad: Genera el texto para vista rango complejo edad servicio
        /// <summary>
        /// <para>Genera el texto para vista rango edad servicio dado los parametros edad configracion del servicio IPS</para> 
        /// <para>PARAMETROS:</para> 
        /// <para>tcrMedidaEdad: Valor en dias-mese y años -->"VD","VM","VA" --- Rangos en dias mees y años "RD","RM","RA</para> 
        /// <para>tnuEdadInicial: valor numerico segun dias años o meses</para> 
        /// <para>tnuEdadFinal: valor numerico segun dias años o meses</para> 
        /// </summary>
        public static String fcrTextoDescripRangoComplejoEdad(String tcrMedidaEdad, int tnuEdadInicial, int tnuEdadFinal)
        {
            var lcrMedidaEdad = String.Empty;
            var lcrReturn = String.Empty;

            if (tcrMedidaEdad.Substring(1, 1) == "A") { lcrMedidaEdad = "1"; } //Año
            if (tcrMedidaEdad.Substring(1, 1) == "M") { lcrMedidaEdad = "2"; } //Mes 
            if (tcrMedidaEdad.Substring(1, 1) == "D") { lcrMedidaEdad = "3"; } //Dia 

            if (tcrMedidaEdad.Substring(0, 1) == "V")
            {
                // es en valor 
                lcrReturn = "Edad puntual " + fcrTextoMedidaEdad(lcrMedidaEdad, tnuEdadInicial);

            }
            else
            {
                // Es un rango 
                lcrReturn = "Rango edad " + fcrTextoRangoEdadServicio(lcrMedidaEdad, tnuEdadInicial, lcrMedidaEdad, tnuEdadFinal);
            }

            return lcrReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrTextoRangoEdadServicio: Genera el texto para vista rango edad servicio
        //-------------------------------------------------
        #region fcrTextoRangoEdadServicio: Genera el texto para vista rango edad servicio
        /// <summary>
        /// <para>Genera el texto para vista rango edad servicio dado los parametros edad configracion del servicio IPS</para> 
        /// <para>PARAMETROS:</para> 
        /// <para>tcrMedidaEdadInicial: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdadInicial: valor numerico segun dias años o meses</para> 
        /// <para>tcrMedidaEdadFinal: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdadFinal: valor numerico segun dias años o meses</para> 
        /// </summary>
        public static String fcrTextoRangoEdadServicio(String tcrMedidaEdadInicial, int tnuEdadInicial, String tcrMedidaEdadFinal, int tnuEdadFinal)
        {
            var lcrReturn = String.Empty;
            var lcrTexto1 = String.Empty;
            var lcrTexto2 = String.Empty;

            lcrTexto1 = fcrTextoMedidaEdad(tcrMedidaEdadInicial, tnuEdadInicial);
            lcrTexto2 = fcrTextoMedidaEdad(tcrMedidaEdadFinal, tnuEdadFinal);

            lcrReturn = lcrTexto1 + " hasta " + lcrTexto2;

            return lcrReturn;
        }

        /// <summary>
        /// <para>Genera el texto para vista rango edad servicio dado los parametros edad configracion del servicio IPS</para> 
        /// <para>PARAMETROS:</para> 
        /// <para>tcrMedidaEdad: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdad: valor numerico segun dias años o meses</para> 
        /// </summary>
        public static String fcrTextoMedidaEdad(String tcrMedidaEdad, int tnuEdad)
        {
            var lcrReturn = String.Empty;
            var lcrTexto = String.Empty;

            switch (tcrMedidaEdad)
            {
                case "1": // Años
                    lcrTexto = tnuEdad <= 1 ? "Año" : "Años";
                    break;

                case "2": // Mes
                    lcrTexto = tnuEdad <= 1 ? "Mes" : "Meses";
                    break;

                case "3": // Dias
                    lcrTexto = tnuEdad <= 1 ? "Dia" : "Dias";
                    break;
            }
            lcrReturn = tnuEdad.ToString().Trim() + " " + lcrTexto;

            return lcrReturn;
        }
        #endregion
        //-------------------------------------------------
        // fnuEdadEnDias: Convierte edad a dias segun la medida dada
        //-------------------------------------------------
        #region fnuEdadEnDias: Convierte edad a dias segun la medida dada
        /// <summary>
        /// <para>Convierte edad a dias segun la medida dada</para> 
        /// <para>tcrMedidaEdad: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdad: Dato de edad dada segun tcrMedidaEdad</para> 
        /// </summary>
        public static int fnuEdadEnDias(String tcrMedidaEdad, int tnuEdad)
        {
            var lnuReturn = tnuEdad;
            if (tnuEdad > 0)
            {
                switch (tcrMedidaEdad)
                {
                    case "1": // Años
                        lnuReturn = tnuEdad * 365;
                        break;

                    case "2": // Mes
                        lnuReturn = tnuEdad * 30;
                        break;
                }
            }
            return lnuReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia(ref List<LogsErrores> tmpLogErrores, String tcrNumeroRegistro)
        {
            var llgReturn = true;
            var lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = tcrNumeroRegistro;
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            //-------------------------------------
            // Cantidad del servicio 
            //-------------------------------------
            #region Cantidad del servicio
            lcrNombreCampo = "Total unidades del servicio";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P01";
            if (Fcm_totuni_dfac > gnuSipsCantMaxUnaOrden)
            {
                lcrValorReturn = "Unidades del Servicio es mayor que la Permitida (Maximo " + gnuSipsCantMaxUnaOrden.ToString().Trim() + " unidades)";
                llgReturn = false;
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            //-------------------------------------
            //- Fecha del servicio 
            //-------------------------------------
            #region Fecha del servicio
            lcrNombreCampo = "Fecha del servicio";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P02";

            if (!Funciones.flgValidarRangoFecha(gcrAdmFechaAdmision, gcrAdmFechaServicio))
            {
                lcrValorReturn = "Fecha del servicio es menor que fecha admisión";
                llgReturn = false;
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            //-------------------------------------
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P03";
            if (String.IsNullOrWhiteSpace(gcrAdmFechaAgendaCita))
            {

                if (!Funciones.flgValidarRangoFecha(gcrAdmFechaServicio, Funciones.fcrFechaActual()))
                {
                    lcrValorReturn = "Fecha servicio es mayor que fecha actual";
                    llgReturn = false;
                }
            }
            else 
            {
                if (!Funciones.flgValidarRangoFecha(gcrAdmFechaServicio, gcrAdmFechaAgendaCita))
                {
                    lcrValorReturn = "Fecha servicio es mayor que fecha actual";
                    llgReturn = false;
                }
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            //-------------------------------------
            //- Sexo que aplica al servicio 
            //-------------------------------------
            #region Sexo que aplica al servicio
            if (gcrAdmSexoDelAfiliado != null)
            {
                var lcrSexo = gcrAdmSexoDelAfiliado.Trim() == "M" ? "1" : "2";
                var lcrSexod = lcrSexo == "1" ? "MASCULINO" : "FEMENINO";

                lcrNombreCampo = "Sexo al que aplica el servicio";
                lcrValorReturn = String.Empty;
                lcrCodigoError = "P04";
                if (gcrSipsSexoAplica != lcrSexo && gcrSipsSexoAplica != "3")
                {
                    lcrValorReturn = "Servicio no permitido para sexo del usuario (sexo " + lcrSexod + ")";
                    llgReturn = false;
                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            //-------------------------------------
            //- Edad del paciente que aplica al servicio 
            //-------------------------------------
            #region Edad del paciente que aplica al servicio 
            //gnuAdmEdadEnAños gnuAdmEdadEnMeses gnuAdmEdadEnDias
            lcrNombreCampo = "Edad del paciente";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P05";
            if (tmpRangoValidEdad != null)
            {
                var llgSiAplica = false;
                foreach (var lobReg in tmpRangoValidEdad)
                {
                    if (lobReg.Tipo.Substring(0, 1) == "V")
                    {
                        // valor en dias
                        if (lobReg.Tipo == "VD" && gnuAdmEdadEnDias == lobReg.Valor1)
                        {
                            llgSiAplica = true;
                        }
                        // valor en meses
                        if (lobReg.Tipo == "VM" && gnuAdmEdadEnMeses == lobReg.Valor1)
                        {
                            llgSiAplica = true;
                        }
                        // valor en años
                        if (lobReg.Tipo == "VA" && gnuAdmEdadEnAños == lobReg.Valor1)
                        {
                            llgSiAplica = true;
                        }
                    }
                    else
                    {
                        // Rango en dias
                        if (lobReg.Tipo == "RD" && gnuAdmEdadEnDias >= lobReg.Valor1 && gnuAdmEdadEnDias <= lobReg.Valor2)
                        {
                            llgSiAplica = true;
                        }
                        // Rango en meses
                        if (lobReg.Tipo == "RM" && gnuAdmEdadEnMeses >= lobReg.Valor1 && gnuAdmEdadEnMeses <= lobReg.Valor2)
                        {
                            llgSiAplica = true;
                        }
                        // Rango en años
                        if (lobReg.Tipo == "RA" && gnuAdmEdadEnAños >= lobReg.Valor1 && gnuAdmEdadEnAños <= lobReg.Valor2)
                        {
                            llgSiAplica = true;
                        }

                    }
                }
                // si no cumplio con ninguan validacion
                if (llgSiAplica == false)
                {
                    llgReturn = false;
                    lcrValorReturn = "Edad del paciente no aplica para rango del servicio: " + gcrSipsCodDigitacionServicio + "//";
                    lcrValorReturn += fcrPertinenciaGenTextoEdadPaciente() + "//" + gcrRangoValidEdadDescripcion;
                }
            }
            else
            {
                if (gnuAdmEdadEnDias < gnuSipsEdadIniDia || gnuAdmEdadEnDias > gnuSipsEdadFinDia)
                {
                    lcrValorReturn = "Edad del paciente no aplica para rango del servicio: " + gcrSipsCodDigitacionServicio+ "//";
                    lcrValorReturn += fcrPertinenciaGenTextoEdadPaciente() + "//" + gcrTextoRangoEdadServicio;
                    llgReturn = false;
                }
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            //-------------------------------------
            //- Servicios POS y NO POS
            //-------------------------------------
            #region Servicios POS y NO POS
            lcrNombreCampo = "Cubrimento POS y No POS";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P07";
            var lcrDescripcion = "POS";

            var lcrDesConfContr = "POS Y NO POS";
            if (gcrContCubrimPosNoPos != "3")
            {
                lcrDesConfContr = gcrContCubrimPosNoPos == "1" ? "POS" : "NO POS";
            }

            if (gcrSipsServPosNoPos == "2") { lcrDescripcion = "NO POS"; }
            if (gcrSipsServPosNoPos != gcrContCubrimPosNoPos && gcrContCubrimPosNoPos != "3") // 3 es ambos
            {
                lcrValorReturn = $"Contrato no Permite Servicios - CONFIGURACIÓN SERVICIO  ({lcrDescripcion }) -  EN CONTRATO ({lcrDesConfContr})  " + lcrDescripcion;
                llgReturn = false;
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            //-------------------------------------
            lcrNombreCampo = "Cubrimento POS en Ambito de atención";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P08";
            var lcrAlcancePos = gcrMantAlcancePosAmbulat;
            var lcrNombreAmbito = "Atención Ambulatoria";
            switch (gcrAdmAmbitoAtencion)
            {
                case "1": // Atencion Ambulatoria
                    lcrAlcancePos = gcrMantAlcancePosAmbulat;
                    lcrNombreAmbito = "Atención Ambulatoria";
                    break;

                case "2": // Atencion Hospitalizacion
                    lcrAlcancePos = gcrMantAlcancePosHospita;
                    lcrNombreAmbito = "Atención Hospitalización";
                    break;

                case "3": // Atencion Urgencias
                    lcrAlcancePos = gcrMantAlcancePosUrgenci;
                    lcrNombreAmbito = "Atención Urgencias";
                    break;
            }
            if (lcrAlcancePos == "2") { lcrDescripcion = "NO POS"; }
            if (lcrAlcancePos != gcrContCubrimPosNoPos && gcrContCubrimPosNoPos != "3") // 3 es ambos
            {
                lcrValorReturn = "Contrato no Permite Servicios " + lcrDescripcion + " en " + lcrNombreAmbito;
                llgReturn = false;
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            //-------------------------------------
            // Pertinencia por Tipo Regimen de afiliacion
            //-------------------------------------
            #region Pertinencia por Tipo Regimen de afiliacion
            lcrNombreCampo = "Tipo afiliado contributivo";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P09";

            // Verificar segun tipo usuario regimen 
            if (gcrAdmTipoRegimenAfiliado == "1") // Contributivo
            {
                if (String.IsNullOrWhiteSpace(gcrAdmTipoAfilContributivo))
                {
                    lcrNombreCampo = "Tipo afiliado contributivo";
                    lcrValorReturn = lcrNombreCampo + ": Tipo afiliado contributivo (C=Cotizante,B=Beneficiario,A=Adicional) esta vacio";
                    llgReturn = false;
                }
                if (String.IsNullOrWhiteSpace(gcrAdmNivelContributivo))
                {
                    lcrNombreCampo = "Nivel contributivo del afiliado";
                    lcrValorReturn = lcrNombreCampo + ": se debe diligenciar datos para validar pertinencia";
                }

            }
            if (gcrAdmTipoRegimenAfiliado == "2") // Subsidiado
            {
                if (String.IsNullOrWhiteSpace(gcrAdmNivelSisben))
                {
                    lcrNombreCampo = "Nivel Sisben afiliado subsidiado";
                    lcrValorReturn = lcrNombreCampo + ": se debe diligenciar datos para validar pertinencia";
                    llgReturn = false;
                }
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            //-------------------------------------
            // Validar frecuencia de uso del servicio
            //-------------------------------------
            #region frecuencia de uso del servicio 
            lcrNombreCampo = "Frecuencia uso del servicio";
            lcrValorReturn = String.Empty;
            lcrCodigoError = "P10";
            if (gcrContValidFrecUsoServi == "1" && gcrSipsAplicaFrecuenUso == "1") // contrato Aplica frecuencia de uso y servicio IPS tambien
            {
                if (gcrSipsFreUsoExistReg == "1")
                {
                    var lcrFecha1 = Funciones.fcrConvertFecha(gdaSipsFreUsoFechaAnterior);
                    var lcrFecha2 = Funciones.fcrConvertFecha(gdaSipsFreUsoFechaFutura);

                    if (gcrSipsFreUsoUnicaVez == "2")
                    {
                        if (gdaSipsFreUsoFechaFutura > Funciones.fdaConvertFecha("DMY", "/", gcrAdmFechaServicio))
                        {
                            lcrValorReturn = "Fecha solicitud " + gcrAdmFechaServicio+ ", Ultima vez en el servicio " + lcrFecha1 + 
                                             ", la fecha para volver a acceder al servicio es " + lcrFecha2;
                            llgReturn = false;
                        }
                    }
                    else 
                    {
                        lcrValorReturn = "Ultima vez en el servicio (" + lcrFecha1 + "), no se puede volver a utlizar";
                        llgReturn = false;

                    }
                }
            }
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError, lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            #endregion
            return llgReturn;
        }
        #endregion
        #region fcrPertinenciaGenTextoEdadPaciente: Genera texto que describe la edad actual del paciente
        /// <summary>
        /// Genera el texto que describe la edad actual del paciente, para explicar la no pertinencia del servicio
        /// </summary>
        public String fcrPertinenciaGenTextoEdadPaciente()
        {
            var lcrValorReturn = String.Empty;
            if (gnuAdmEdadEnAños > 0)
            {
                lcrValorReturn += " la edad del paciente en años es " + gnuAdmEdadEnAños.ToString();
            }
            else if (gnuAdmEdadEnMeses > 0)
            {
                lcrValorReturn += " la edad del paciente en meses es " + gnuAdmEdadEnMeses.ToString();
            }
            else
            {
                lcrValorReturn += " la edad del paciente en dias es " + gnuAdmEdadEnDias.ToString();
            }

            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcularCopagoyCmoderadoras: calcular copagos y cuotas moderadoras
        //-------------------------------------------------
        #region fcvCalcularCopagoyCmoderadoras: Calcular copagos y cuotas moderadoras
        /// <summary>
        /// Calcular Valor de los copagos y cuotas moderadoras en servicios facturados
        /// </summary>
        public bool flgCalcularCopagoyCmoderadoras()
        {
            #region Saber si aplica copago o cuota moderadora en manual segun tipo admision
            var llgReturn = true;
            var lcrCpCmodServicio = "4"; // 1= Copago 2=C.moderadora 3=Copago/C.Moderadora 4= No cobrar 
            switch (gcrAdmAmbitoAtencion)
            {
                case "1": // Ambulatodia
                    lcrCpCmodServicio = gcrMantLiqCopCmodAmbulat;
                    break;

                case "2": // hospitalizacion
                    lcrCpCmodServicio = gcrMantLiqCopCmodHospita;
                    break;

                case "3": // Urgencias
                    lcrCpCmodServicio = gcrMantLiqCopCmodUrgenci;
                    break;
            }
            #endregion
            Fcm_valcmo_dfac = 0;
            Fcm_valcpa_dfac = 0;

            if ((gcrContEfectivoCopago == "1" || gcrContEfectivoCmoderad == "1") && lcrCpCmodServicio != "4")
            {
                if (gnuOtrsValorSalarioDia > 0)
                {
                    EFsiacopagosisben lobSisben = new EFsiacopagosisben();
                    EFsiacopagcontrib lobContrib = new EFsiacopagcontrib();
                    if (gcrContTipoRegimenAfiliado == "1") //Contributivo 
                    {
                        #region Liquidar Cuota moderadora / copago en contributivo
                        float lcrValorRecuperado = 0;
                        // Si es valor calculado o fijo en servicio
                        if (gnuMantTipoLiqCopagoCmoderadora == "1") 
                        {
                            // buscar la cuota moderadora o copago en la tabla porcentaje contributivo 
                            lobContrib = SIAValidarCodigo.fobRegBuscarSiacopagcontrib(gcrAdmTipoAfilContributivo, lcrCpCmodServicio, gcrAdmNivelContributivo);
                            if (lobContrib != null)
                            {
                                switch (lobContrib.sia_tippor_cpsb)
                                {
                                    case "1": // Liquidar por Tarifa 
                                        lcrValorRecuperado = ((float)lobContrib.sia_porapl_cpsb * Fcm_valser_mant) / 100;
                                        lcrValorRecuperado = lcrValorRecuperado + 1000;
                                        break;

                                    case "2": // Salario minimo mensual
                                        lcrValorRecuperado = ((float)lobContrib.sia_porapl_cpsb * gnuOtrsValorSalarioMes) / 100;
                                        lcrValorRecuperado = lcrValorRecuperado + 2000;
                                        break;

                                    case "3": // Salario minimo Dia
                                        lcrValorRecuperado = ((float)lobContrib.sia_porapl_cpsb * gnuOtrsValorSalarioDia) / 100;
                                        //lcrValorRecuperado = lcrValorRecuperado + 3000;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // Verificar que si aplica el cobro
                            lobContrib = SIAValidarCodigo.fobRegBuscarSiacopagcontrib(gcrAdmTipoAfilContributivo, lcrCpCmodServicio, gcrAdmNivelContributivo);
                            if (lobContrib != null)
                            {
                                lcrValorRecuperado = gnuMantValorFijoCopagoCModerad;
                            }
                        }
                        // Realizar el ajuste cuando exista
                        if (gnuContValorAjustePrecio > 0 && lcrValorRecuperado > 0)
                        {
                            lcrValorRecuperado = Funciones.fnuRedondeoAjuste((int)lcrValorRecuperado, gnuContValorAjustePrecio);
                        }
                        if (lcrValorRecuperado > 0 && lcrCpCmodServicio == "1") // 1 = Copago
                        {
                            Fcm_valcpa_dfac = lcrValorRecuperado;
                        }
                        else if (lcrValorRecuperado > 0) // 2 = Es cuota moderadora
                        {
                            Fcm_valcmo_dfac = lcrValorRecuperado; 
                        }
                        #endregion
                    }
                    else if (gcrContTipoRegimenAfiliado == "2" && gcrContEfectivoCopago == "1") //Subsidiado y cobro cuota moderadora
                    {
                        #region Liquidar Copagos en subsidiado
                        if (gnuMantTipoLiqCopagoCmoderadora == "1")
                        {
                            // Buscar en la tabla porcent subidiado
                            lobSisben = SIAValidarCodigo.fobRegBuscarSiacopagosisbenNv(gcrAdmNivelSisben);
                            if (lobSisben != null)
                            {
                                switch (lobSisben.sia_tippor_cpsb)
                                {
                                    case "1": // Liquidar por Tarifa 
                                        Fcm_valcpa_dfac = ((float)lobSisben.sia_porapl_cpsb * Fcm_valser_mant) / 100;
                                        break;

                                    case "2": // Salario minimo mensual
                                        Fcm_valcpa_dfac = ((float)lobSisben.sia_porapl_cpsb * gnuOtrsValorSalarioMes) / 100;
                                        break;

                                    case "3": // Salario minimo Dia
                                        Fcm_valcpa_dfac = ((float)lobSisben.sia_porapl_cpsb * gnuOtrsValorSalarioDia) / 100;
                                        break;
                                }
                            }
                        }
                        else 
                        {
                            Fcm_valcpa_dfac = gnuMantValorFijoCopagoCModerad;
                        }

                        if (gnuContValorAjustePrecio > 0 && Fcm_valcpa_dfac > 0)
                        {
                            Fcm_valcpa_dfac = Funciones.fnuRedondeoAjuste((int)Fcm_valcpa_dfac, gnuContValorAjustePrecio);
                        }
                        #endregion
                    }
                }
            }
            // Aplicar parametros del contrato 
            if (gcrContAplicarCopago != "1") { Fcm_valcpa_dfac = 0; }
            if (gcrContAplicarCmoderad != "1") { Fcm_valcmo_dfac = 0; }
            
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcualrTotServicio: calcular Valor del servicio
        //-------------------------------------------------
        #region fcvCalcularValorTotalServicio: calcular Valor del servico
        /// <summary>
        /// Calcular Valor del servicio y porcentajes segun aplique en contrato
        /// </summary>
        public void fcvCalcularValorTotalServicio()
        {
            float lflAuxFcm_valser_mant = 0;
            switch (gcrContTipLiqManualTarifa)
            {
                case "1": // Liquidar en modo SOAT
                    Fcm_valser_mant = (gnuMantPuntajeValorServ * gnuOtrsValorSalarioDia);
                    break;

                case "2": // Liquidar en modo ISS
                    Fcm_valser_mant = (gnuMantPuntajeValorServ * 100);
                    break;

                case "3": // Liquidar en modo normal (valor simple)
                    Fcm_valser_mant = gnuMantValorServicio;
                    break;
            }
            // Cuendo es el valor pleno sin liquidacion
            Fcm_valser_mant = gcrMantPrecioTarifaContr == "2" ? gnuMantValorServicio : Fcm_valser_mant;

            lflAuxFcm_valser_mant = Fcm_valser_mant; // se guarda el valor base sin tratar
            var lnuValorServicio = Fcm_valser_mant;

            // se permite recalcular segun parametros recargo y cubrimiento en contrato
            if (gcrMantPrecioTarifaContr == "1") 
            {
                if (gnuContPorRecargoPrecio != 0)
                {
                    Fcm_valser_mant += (Fcm_valser_mant * gnuContPorRecargoPrecio) / 100;
                }

                // Hay un cubrimiento diferente al 100%
                if (gnuContPorCubrimiePrecio > 0 && gnuContPorCubrimiePrecio < 100)
                {
                    Fcm_valser_mant -= (Fcm_valser_mant * gnuContPorCubrimiePrecio) / 100;
                }
            }

            // Realizar Redondeo a 50,100 y otros
            if (gnuContValorAjustePrecio > 0)
            {
                if (lnuValorServicio > Fcm_valser_mant)
                {
                    // cuando hay ajuste negativo
                    Fcm_valser_mant = Funciones.fnuRedondeoAjuste((int)Fcm_valser_mant, gnuContValorAjustePrecio, false);
                }
                else
                {
                    //Fcm_valser_mant = Funciones.fnuRedondeoAjuste((int)Fcm_valser_mant, gnuContValorAjustePrecio, false);
                    Fcm_valser_mant = Funciones.fnuRedondeoAjuste((int)Fcm_valser_mant, gnuContValorAjustePrecio);
                }
            }

            Fcm_valser_mant = (float)Math.Round(Fcm_valser_mant, 0);

            Fcm_valser_mant = Fcm_valser_mant <= 0 ? (float)Math.Round(lflAuxFcm_valser_mant, 0) : Fcm_valser_mant;
            Fcm_valbru_dfac = Fcm_totuni_dfac * Fcm_valser_mant;
            Fcm_valsub_dfac = Fcm_valbru_dfac - Fcm_valusu_dfac;

            // calcular iva
            Fcm_valiva_dfac = gflSipsPorcentajeIVA > 0 ? (float)Math.Round((Fcm_valsub_dfac * gflSipsPorcentajeIVA)) : 0;
            Fcm_poriva_dfac = gflSipsPorcentajeIVA;
            // valor total
            Fcm_valfac_dfac = (Fcm_valsub_dfac - Fcm_valdes_dfac) + Fcm_valiva_dfac;
        }
        #endregion
    }
    /// <summary>Gestion para Registro tipo detalle servicio facturado, dados los datos de admisión y servicio a facturar</summary>
    public class FcmFacturarServicios 
    {
        //------------------------------------------------
        // Variables Varias
        static Aplicacion oApp = Aplicacion.Instancia();
        String lcrUsuIdUsuario = oApp.gcrUsuIdUsuario;
        public bool GlgSIS_ActActoQuirurgico = false;
        public static String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        //------------------------------------------------
        //ADMREGADMISION: Registro Activo de Admisión 
        //------------------------------------------------
        #region Registro Activo de Admisión
        /// <summary>
        ///  Registro activo de la tabla: admregadmision - Registro adimisión pacientes
        /// </summary>
        public ADMModeloAdmadmisiones tmpRegAdm = new ADMModeloAdmadmisiones();
        #endregion
        //FCMMAESFACTURAS: Maestro de facturas en Ordenes de servicios medicos
        #region FCMMAESFACTURAS: Propiedad registro activo tmpRegFact
        /// <summary>
        ///  Registro activo tabla: Maestro facturas fcmmaesfacturas
        /// </summary>
        public FcmModeloMaestrofacturas tmpRegFact = new FcmModeloMaestrofacturas();
        #endregion
        #region FCMMAESFACTURAS: Propiedad lista registros maestro facturas: tmpListFact
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        public List<FcmModeloMaestrofacturas> tmpListFact = new List<FcmModeloMaestrofacturas>();
        #endregion
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        #region FCMMAEDETALLFAC: Propiedad registro activo detalles tmpRegDetall
        /// <summary>
        ///  Registro activo de la tabla: detalles facturas fcmmaedetallfac
        /// </summary>
        public FcmModeloServDetallFacturas tmpRegDetall = new FcmModeloServDetallFacturas();
        #endregion
        #region FCMMAEDETALLFAC: Propiedad Temporal para Edicion: tmpListDetallEdt
        /// <summary>
        ///  Lista registros tabla: detalles de facturación fcmmaedetallfac
        /// </summary>
        public List<FcmModeloServDetallFacturas> tmpListDetallEdt = new List<FcmModeloServDetallFacturas>();
        #endregion
        //------------------------------------------------
        // CLASE PARA LIQUIDAR SERVICIOS
        //------------------------------------------------
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmLiquidar m = new FcmLiquidar();
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        //------------------------------------------------
        #region FCMMAEDETALLFAC : G2 - Detalles servicios facturados
        #region G2Fcm_secreg_dfac: Código Único registro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: g2fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico del registro o servicio facturado , generado
        /// por el sistema
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_dfac = String.Empty;
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión o del registro de atencion ambulatoria
        /// </para>
        /// </summary>
        public string G2Adm_secadm_rgad = String.Empty;
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
        /// </para>
        /// </summary>
        public string G2Sia_idesec_usua = String.Empty;
        #endregion
        #region G2Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion
        /// y otros
        /// </para>
        /// </summary>
        public string G2Sia_tipide_tide = String.Empty;
        #endregion
        #region G2Sia_nroide_usua: Numero de Identificación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G2Sia_nroide_usua = String.Empty;
        #endregion
        #region G2Cto_seccon_cont: Secuencial de Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g2cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public string G2Cto_seccon_cont = String.Empty;
        #endregion
        #region G2Cto_nrocon_cont: Número Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g2cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G2Cto_nrocon_cont = String.Empty;
        #endregion
        #region G2Sia_codeps_teps: Código EPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g2sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G2Sia_codeps_teps = String.Empty;
        #endregion
        #region G2Sis_idterc_sitr: Código tercero (contable)
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g2Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public string G2Sis_idterc_sitr = String.Empty;
        #endregion
        #region G2Fcm_secreg_mfac: Código orden medica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: g2fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_mfac = String.Empty;
        #endregion
        #region G2Fcm_numfac_mfac: Numero Factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g2fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
        /// </para>
        /// </summary>
        public string G2Fcm_numfac_mfac = String.Empty;
        #endregion
        #region G2Fcm_tiprfa_mfac: Tipo registro facturación Pre-factura o valida Dian
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro facturación</para>
        /// <para>NOMBRE: g2fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro factura generada: 1= Registro ordenes de servicios
        /// (pre-factura) 2= Numero de Factura Valida Dian
        /// </para>
        /// </summary>
        public string G2Fcm_tiprfa_mfac = String.Empty;
        #endregion
        #region G2Fcm_fecfac_mfac: Fecha factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g2fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public string G2Fcm_fecfac_mfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
        #endregion
        #region G2Fcm_estfac_mfac: Estado Factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: g2fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public String G2Fcm_estfac_mfac = "1";
        #endregion
        #region G2Adm_nroaut_rgad: Numero Autorización
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: g2adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero Autorizacion solicitada a la EPS o Asegurador para adimision
        /// o servicio que requiera autorizacion
        /// </para>
        /// </summary>
        public string G2Adm_nroaut_rgad = String.Empty;
        #endregion
        #region G2Sia_codrip_trip: Tipo servicio RIPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: g2sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G2Sia_codrip_trip = String.Empty;
        #endregion
        #region G2Inv_secart_inar: Código único suministro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único suministro</para>
        /// <para>NOMBRE: g2inv_secart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del articulo relacionado con el inventario generado
        /// por el sistema
        /// </para>
        /// </summary>
        public string G2Inv_secart_inar = String.Empty;
        #endregion
        #region G2Inv_codaux_inar: Código suministro Invent
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código suministro Invent</para>
        /// <para>NOMBRE: g2inv_codart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo Auxiliar de digitacion en inventario para realizar
        /// descargas cuando se suminstra medicamentos o materiales a pacientes
        /// </para>
        /// </summary>
        public string G2Inv_codaux_inar = String.Empty;
        #endregion
        #region G2Fcm_idesec_sips: Código servicio IPS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g2fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado para referencia
        /// y validacion de pertinencia
        /// </para>
        /// </summary>
        public string G2Fcm_idesec_sips = String.Empty;
        #endregion
        #region G2Fcm_codbar_sips: Código de Barras
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: g2fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public string G2Fcm_codbar_sips = String.Empty;
        #endregion
        #region G2Fcm_idesec_mant: Codigo unico tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: g2fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del servicio para venta con manual tarifario (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Fcm_idesec_mant = String.Empty;
        #endregion
        #region G2Fcm_codser_mant: Código servicio en tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g2fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS
        /// </para>
        /// </summary>
        public string G2Fcm_codser_mant = String.Empty;
        #endregion
        #region G2Fcm_coddig_mant: Código digitación servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g2fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (puede ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public string G2Fcm_coddig_mant = String.Empty;
        #endregion
        #region G2Con_codsco_ccos: Código centro de costo
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g2con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Para identificar Servicios por centro de costos (desde contabilidad)
        /// </para>
        /// </summary>
        public string G2Con_codsco_ccos = String.Empty;
        #endregion
        #region G2Fcm_codcpr_cpro: Código centro producción
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g2fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de produccion donde se presta el servicio
        /// </para>
        /// </summary>
        public string G2Fcm_codcpr_cpro = String.Empty;
        #endregion
        #region G2Fcm_desser_dfac: Nombre servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_dfac (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string G2Fcm_desser_dfac = String.Empty;
        #endregion
        #region G2Fcm_codman_mans: Código manual tarifario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: g2fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios configurados para
        /// ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual
        /// SOAT para ventas contributivo (se todam desde el contrato)
        /// </para>
        /// </summary>
        public string G2Fcm_codman_mans = String.Empty;
        #endregion
        #region G2Fcm_fecser_dfac: Fecha servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g2fcm_fecser_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha de prestacion del servicio
        /// </para>
        /// </summary>
        public string G2Fcm_fecser_dfac = String.Empty;
        #endregion
        #region G2Fcm_horser_dfac: Hora Digitación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora Digitación</para>
        /// <para>NOMBRE: g2fcm_horser_dfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Hora  digitacion del servicio en facturacion en formato militar
        /// </para>
        /// </summary>
        public String G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
        #endregion
        #region G2Cit_feccit_mcit: Fecha  agenda cita para servicio
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha agenda de citas para servicio</para>
        /// <para>NOMBRE: G2Cit_feccit_mcit (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Fecha agenda de citas para servicio
        /// </para>
        /// </summary>
        public String G2Cit_feccit_mcit = String.Empty;
        #endregion
        #region G2Fcm_perman_sips: Código Pertenece al manual
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: g2fcm_perman_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public string G2Fcm_perman_sips = String.Empty;
        #endregion
        #region G2Fcm_forfar_sips: Forma farmacéutica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: g2fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Forma farmaceutica del medicamento (cuando el servicio sea
        /// un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_forfar_sips = String.Empty;
        #endregion
        #region G2Fcm_conmed_sips: Concentración
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: g2fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Concentración del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_conmed_sips  = String.Empty;
        #endregion
        #region G2Fcm_unimed_sips: Unidad de medida
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: g2fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Unidad medica del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_unimed_sips = String.Empty;
        #endregion
        #region G2Fcm_autdes_ades: Autorización descuento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g2fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
        /// </para>
        /// </summary>
        public string G2Fcm_autdes_ades = String.Empty;
        #endregion
        #region G2Fcm_valser_mant: Valor de servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: g2fcm_valser_mant (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public float G2Fcm_valser_mant = 0;
        #endregion
        #region G2Fcm_totuni_dfac: Total unidades
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: g2fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Total de unidades facturadas del servicio
        /// </para>
        /// </summary>
        public int G2Fcm_totuni_dfac = 0;
        #endregion
        #region G2Fcm_valbru_dfac: Valor bruto factura
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g2fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float G2Fcm_valbru_dfac = 0;
        #endregion
        #region G2Fcm_pordes_dfac: Porcentaje del descuento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g2fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float G2Fcm_pordes_dfac = 0;
        #endregion
        #region G2Fcm_valdes_dfac: Valor del descuento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g2fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float G2Fcm_valdes_dfac = 0;
        #endregion
        #region G2Fcm_poriva_dfac: Porcentaje del IVA
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g2fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float G2Fcm_poriva_dfac = 0;
        #endregion
        #region G2Fcm_valiva_dfac: Valor IVA
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float G2Fcm_valiva_dfac = 0;
        #endregion
        #region G2Fcm_valcpa_dfac: Valor copago
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g2fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float G2Fcm_valcpa_dfac = 0;
        #endregion
        #region G2Fcm_valcmo_dfac: Valor cuota moderadora
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g2fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float G2Fcm_valcmo_dfac = 0;
        #endregion
        #region G2Fcm_valusu_dfac: Valor cargo al usuario
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g2fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float G2Fcm_valusu_dfac = 0;
        #endregion
        #region G2Fcm_valcom_dfac: Valor comisión
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g2fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float G2Fcm_valcom_dfac = 0;
        #endregion
        #region G2Fcm_valsub_dfac: Valor subtotal servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g2fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// Subtotal = FCM_VALBRU_DFAC-(FCM_VALUSU_DFAC+FCM_VALDES_DFAC)
        /// </para>
        /// </summary>
        public float G2Fcm_valsub_dfac = 0;
        #endregion
        #region G2Fcm_valfac_dfac: Valor total facturado
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float G2Fcm_valfac_dfac = 0;
        #endregion
        #region G2Fcm_valref_dfac: Valor en efectivo
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g2fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float G2Fcm_valref_dfac = 0;
        #endregion
        #region G2Fcm_valefe_dfac: Valor efectivo final
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: a1fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public float G2Fcm_valefe_dfac = 0;
        #endregion
        #region G2Fcm_codtse_sips: Tipo procedimientos o servicios
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g2fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public string G2Fcm_codtse_sips = String.Empty;
        #endregion
        #region G2Fcm_codaqx_aqir: Tipo Acto Quirúrgico
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Tipo Acto Quirúrgico</para>
        /// <para>NOMBRE: g2fcm_codaqx_aqir (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public string G2Fcm_codaqx_aqir = String.Empty;
        #endregion
        #region G2Sia_tipact_tsac: Tipo servicio o activiad
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o activiad</para>
        /// <para>NOMBRE: g2sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
        /// </para>
        /// </summary>
        public string G2Sia_tipact_tsac = String.Empty;
        #endregion
        #region G2Adm_codtat_tatn: Tipo de Atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: g2adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito del servicio:1=Ambulatoria
        /// 2=Hospitalizacion 3=Urgencia
        /// </para>
        /// </summary>
        public string G2Adm_codtat_tatn = String.Empty;
        #endregion
        #region G2Sia_codfpr_fpor: Finalidad Procedimiento
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: g2sia_codfpr_fpor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Sia_codfpr_fpor = String.Empty;
        #endregion
        #region G2Sia_codfco_fcon: finalidad de la consulta
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g2sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        ///Finalidad de la consulta:01=Atención del Parto
        /// </para>
        /// </summary>
        public string G2Sia_codfco_fcon = String.Empty;
        #endregion
        #region G2Adm_codcex_tcex: Causa Externa
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g2adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atencion según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Adm_codcex_tcex = String.Empty;
        #endregion
        #region G2Sia_coddia_tdia: Diagnostico Principal
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Diagnostico Principal</para>
        /// <para>NOMBRE: g2sia_coddxa_mdxa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Codigo del diagnostico principal (para Rips AP o AC cuando
        /// sea requerido)  según la CIE 10, desde la tabla maestra de
        /// diagnosticos
        /// </para>
        /// </summary>
        public string G2Sia_coddia_tdia = String.Empty;
        #endregion
        #region G2Sia_tipdxp_tdix: Tipo de diagnostico
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: g2sia_tipdxa_tdxa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Tipo de diagnostico según CIE 10: 1=impresion diagnostica 2=Confirmado
        /// nuevo y otros
        /// </para>
        /// </summary>
        public string G2Sia_tipdxp_tdix = String.Empty;
        #endregion
        #region G2Sia_coddx1_tdia: Diagnostico relacionado 1
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 1</para>
        /// <para>NOMBRE: g2sia_coddx1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx1_tdia = String.Empty;
        #endregion
        #region G2Sia_coddx2_tdia: Diagnostico relacionado 2
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 2</para>
        /// <para>NOMBRE: g2sia_coddx2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx2_tdia = String.Empty;
        #endregion
        #region G2Sia_coddx3_tdia: Diagnostico relacionado 3
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 3</para>
        /// <para>NOMBRE: g2sia_coddx3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 3 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx3_tdia = String.Empty;
        #endregion
        #region G2Sia_coddxc_tdia: Diagnostico complicación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: g2sia_coddxc_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complizacion según tabla CIE10
        /// </para>
        /// </summary>
        public string G2Sia_coddxc_tdia = String.Empty;
        #endregion
        #region G2Sia_codgac_gpyp: Grupo Actividades PyP
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siagrupoactipyp</para>
        /// <para>CAMPO: Grupo Actividades PyP</para>
        /// <para>NOMBRE: g2sia_codgac_gpyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public string G2Sia_codgac_gpyp = String.Empty;
        #endregion
        #region G2Sia_codact_apyp: Actividades PyP
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaactividadpyp</para>
        /// <para>CAMPO: Actividades PyP</para>
        /// <para>NOMBRE: g2sia_codact_apyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public string G2Sia_codact_apyp = String.Empty;
        #endregion
        #region G2Fcm_serpos_sips: servicio POS/NO POS
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: servicio POS/NO POS</para>
        /// <para>NOMBRE: g2fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G2Fcm_serpos_sips = String.Empty;
        #endregion
        #region G2Cto_tipact_cont: Actividad que cubre Contrato
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Actividad que cubre Contrato</para>
        /// <para>NOMBRE: g2cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Salud Publica 4 =Todas
        /// </para>
        /// </summary>
        public string G2Cto_tipact_cont = String.Empty;
        #endregion
        #region G2Sia_codpat_tpat: Tipo de profesional
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: g2sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public string G2Sia_codpat_tpat = String.Empty;
        #endregion
        #region G2Sia_codpfa_prof: Código profesional atiende
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: g2sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        ///Codigo del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public string G2Sia_codpfa_prof = String.Empty;
        #endregion
        #region G2Fac_horprs_dfac: Hora servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: g2fac_horprs_dfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Hora en que recibe la prestacion del servicio (lo atiende el
        /// profesional) en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G2Fac_horprs_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
        #endregion
        #region G2Fcm_atepro_dfac: Servicio atendido SI/NO
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio atendido SI/NO</para>
        /// <para>NOMBRE: g2fcm_atepro_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Para confirmar si el servicio ya fue antendido por el profesional
        /// o esta pendiente para ser realizado 1= Servicio pendiente para
        /// profesional 2= Servicio atendido por profesional
        /// </para>
        /// </summary>
        public string G2Fcm_atepro_dfac = String.Empty;
        #endregion
        #region G2Sia_codare_aser: Código área servicio
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área servicio</para>
        /// <para>NOMBRE: g2sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        ///Codigo area donde se presta el servicio
        /// </para>
        /// </summary>
        public string G2Sia_codare_aser = String.Empty;
        #endregion
        #region G2Sia_aresol_aser: Código área solicita
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área solicita</para>
        /// <para>NOMBRE: g2sia_aresol_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        ///Codigo area que solicita el servicio
        /// </para>
        /// </summary>
        public string G2Sia_aresol_aser = String.Empty;
        #endregion
        #region G2Desia_aresol_aser: Código área solicita
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g2desia_aresol_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_aresol_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public string G2Desia_aresol_aser = String.Empty;
        #endregion
        #region G2Fcm_tipser_sips: Servicio o Suministro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: g2fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public string G2Fcm_tipser_sips = String.Empty;
        #endregion
        #region G2Fcm_fecedt_dfac: Fecha ultima modificación
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: g2fcm_fecedt_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Fecha ultima modificacion realizada por un usario o facturador
        /// </para>
        /// </summary>
        public string G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
        #endregion
        #region G2Sys_codusu_usux: Código Digitador
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g2sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Código del factuador  usuario del sistema que que realiza la
        /// ultima modificacion
        /// </para>
        /// </summary>
        public string G2Sys_codusu_usux = String.Empty;
        #endregion
        #region G2Fcm_otserv_sips: Tipo Rips otros servicios
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public String G2Fcm_otserv_sips = String.Empty;
        #endregion
        #region G2Sia_regate_rgat: Registro de atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: g2sia_regate_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public string G2Sia_regate_rgat = String.Empty;
        #endregion
        #region G2Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g2sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G2Sia_codcat_ceat = String.Empty;
        #endregion
        #region G2Fcm_ripsco_dfac: Rips completados SI/NO
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Rips completados SI/NO</para>
        /// <para>NOMBRE: g2fcm_ripsco_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si los datos del RIPS fueron completados por
        /// el profesional en la atencion medica: 1=Sin completar 2= Rips
        /// completados
        /// </para>
        /// </summary>
        public string G2Fcm_ripsco_dfac = String.Empty;
        #endregion
        #region G2Inv_codalm_inal: Código almacén
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código almacén</para>
        /// <para>NOMBRE: g2inv_codalm_malm (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Codigo del almacen (desde inventario) desde el cual se descargan
        /// los suministros facturados (cuando aplique según tipo servicio
        /// y el contrato)
        /// </para>
        /// </summary>
        public string G2Inv_codalm_inal = String.Empty;
        #endregion
        #region G2Inv_codgme_mgme: Patrón unidad medida
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Patrón unidad medida</para>
        /// <para>NOMBRE: g2inv_codgme_mgme (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Patrón Unidad de Medida (Masa, Volumen, etc) Viene del  almacén
        /// de donde se tome, desde el maestro grupos de medidas
        /// </para>
        /// </summary>
        public string G2Inv_codgme_mgme = String.Empty;
        #endregion
        #region G2Inv_coduma_muma: Unidad medida descarga
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Unidad medida descarga</para>
        /// <para>NOMBRE: g2inv_coduma_muma (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// Unidad de medida para descargar desde  almacén (litros, gramos,
        /// centilitros) Viene del Almacén de donde se tome
        /// </para>
        /// </summary>
        public string G2Inv_coduma_muma = String.Empty;
        #endregion
        #region G2Sis_estpro_espr: Estado Registro
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la admision: 1=Abierto
        /// 2=Cerrado 3=Anulado
        /// </para>
        /// </summary>
        public string G2Sis_estpro_espr = String.Empty;
        #endregion
        // Campos auxiliares
        #region G2Cto_fcdian_cont: Generar Secuencial facturas DIAN Si/No
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: cto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Generar Numeros de factura desde Secuencial autorizado DIAN:
        /// 1=SI 2=NO
        /// </para>
        /// </summary>
        public String G2Cto_fcdian_cont = String.Empty;
        #endregion
        #region G2Cto_sepser_cont: Separar Asistencial y PyP
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separar Asistencial y PyP</para>
        /// <para>NOMBRE: a1cto_sepser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial, PyP y Salud publica, para generar facturas
        /// por separado, cuando el contrato cubre varios tipos de servicios:
        /// 1=Si 2=No
        /// </para>
        /// </summary>
        public string G2Cto_sepser_cont = String.Empty;
        #endregion
        #region G2Hcl_codreg_hcca: Registro actividad en historial clinico 
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Registro actividad clinica</para>
        /// <para>NOMBRE: g2hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Generar registro actividad en historial clinico: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia
        /// </para>
        /// </summary>
        public String G2Hcl_codreg_hcca = String.Empty;
        #endregion
        #region G2Cto_serper_cont: Servicios personalizados
        /// <summary>
        /// <para>TABLA: Temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: g1cto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public string G2Cto_serper_cont = String.Empty;
        #endregion
        #region G2Sia_deseps_teps: Nombre Descripcion de la EPS o asegurador
        /// <summary>
        /// <para>CAMPO: Nombre Descripcion de la EPS o asegurador</para>
        /// <para>NOMBRE: G2Sia_deseps_teps (char:80)</para>
        /// <para>DESCRIPCION: Nombre Descripcion de la EPS o asegurador</para>
        /// </summary>
        public String G2Sia_deseps_teps = String.Empty;
        #endregion
        #region G2Sia_desact_tsac: Descripcion Tipo servicio o actividad 
        /// <summary>
        /// <para>CAMPO: Descripcion Tipo servicio o actividad </para>
        /// <para>NOMBRE: G2Sia_desact_tsac (char:80)</para>
        /// <para>DESCRIPCION: Descripcion Tipo servicio o actividad: Asistencial/Promocion y prevencion</para>
        /// </summary>
        public String G2Sia_desact_tsac = String.Empty;
        #endregion
        #region G2Cto_frecus_cont: Contrato Frecuencia uso servicios
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Frecuencia uso servicios</para>
        /// <para>NOMBRE: cto_frecus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Parametro desde maestro contrato: Aplicar Validacion frecuencia uso de servicios: 1=Si 2=No
        /// </para>
        /// </summary>
        public String G2Cto_frecus_cont = "2";
        #endregion
        #region G2Fcm_aplfus_sips: Frecuencia de uso
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso</para>
        /// <para>NOMBRE: fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Aplicar frecuencia de uso al servicio: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String G2Fcm_aplfus_sips = "2";
        #endregion
        #region G2Fcm_intser_sips: Intervalos días orden servicio
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Intervalos días orden servicio</para>
        /// <para>NOMBRE: fcm_intser_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Frecuencia uso servicio: Intervalo en dias para la nueva orden del servicio ejm: cada
        /// 15 o 3 dias , cada 90 dias es decir intser= 15 intser=30 intser=90
        /// </para>
        /// </summary>
        public int G2Fcm_intser_sips = 0;
        #endregion
        #region G2Sis_estado_imaen: Estado del registro para edicion
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public String G2Sis_estado_imaen = "I";
        #endregion
        #endregion
        //-------------------------------------------------
        // VALOR FINAL SERVICIO Y RESUMEN FACTURACION
        //-------------------------------------------------
        #region fobGenRegistroServicioFacturado: calcular Valor del servico
        /// <summary>
        /// Calcular Valor final del servicio facturado, genera el registro temporal activo servicio facturado
        /// </summary>
        public FcmModeloServDetallFacturas fobGenRegistroServicioFacturado()
        {
            // Generar valores 
            fcvCalcularTotalServicio();
            fcvCalcularCopagoyCmoderadoras();

            // Para acumular valor recaudo en efectivo
            G2Fcm_valref_dfac = 0;
            if (m.gcrContEfectivoServicios == "1") { G2Fcm_valref_dfac += G2Fcm_valfac_dfac; }
            if (m.gcrContEfectivoCopago == "1") { G2Fcm_valref_dfac += G2Fcm_valcpa_dfac; }
            if (m.gcrContEfectivoCmoderad == "1") { G2Fcm_valref_dfac += G2Fcm_valcmo_dfac; }
            if (m.gcrContEfectivoCargUsuar == "1") { G2Fcm_valref_dfac += G2Fcm_valusu_dfac; }
            // el usuario activo realiza ultimo cambio
            G2Fcm_valefe_dfac = G2Fcm_valref_dfac;
            G2Sys_codusu_usux = lcrUsuIdUsuario;

            fcvCargarRegActivoDesdeVariables();
            tmpListDetallEdt.Add(tmpRegDetall);

            return tmpRegDetall;
        }
        #endregion
        #region flsGenerarResumenFacturas: Generar temporal de facturas
        /// <summary>
        /// Generar temporal de facturas, agrupando los servicios por
        /// contrato ordenes de servicios y tipo actividad
        /// </summary>
        public List<FcmModeloMaestrofacturas> flsGenerarResumenFacturas()
        {
            var llgRealiza = false;
            try
            {
                tmpListFact = new List<FcmModeloMaestrofacturas>();
                if (tmpListDetallEdt.Count > 0) // adicionar desde detalles de servicios facturados
                {
                    foreach (FcmModeloServDetallFacturas lobReg in tmpListDetallEdt)
                    {
                        if (lobReg.Fcm_estfac_mfac == "1")
                        {
                            llgRealiza = true;
                            fcvSumaResumenFacturas(lobReg);
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarResumenFacturas");
            }
            if (llgRealiza == false) { tmpListFact = null; }

            return tmpListFact;
        }
        #endregion
        #region fcvSumaResumenFacturas: Genera sumatorias de facturas
        /// <summary>
        /// Genera las sumatorias de cada factura segun contrato y 
        /// tipo de servicio
        /// </summary>
        public void fcvSumaResumenFacturas(FcmModeloServDetallFacturas tobRegistro)
        {
            try
            {
                var llgEncontrado = false;
                if (tmpListFact.Count > 0)
                {
                    foreach (FcmModeloMaestrofacturas lobReg in tmpListFact)
                    {
                        if (lobReg.Fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac)
                        {
                            #region Valores Variables
                            lobReg.Fcm_valbru_dfac += tobRegistro.Fcm_valbru_dfac;
                            lobReg.Fcm_valbsi_dfac += tobRegistro.Fcm_valiva_dfac > 0 ? tobRegistro.Fcm_valbru_dfac : 0;
                            lobReg.Fcm_pordes_dfac = tobRegistro.Fcm_pordes_dfac;
                            lobReg.Fcm_valdes_dfac += tobRegistro.Fcm_valdes_dfac;
                            lobReg.Fcm_poriva_dfac = tobRegistro.Fcm_poriva_dfac;
                            lobReg.Fcm_valiva_dfac += tobRegistro.Fcm_valiva_dfac;
                            lobReg.Fcm_valcpa_dfac += tobRegistro.Fcm_valcpa_dfac;
                            lobReg.Fcm_valcmo_dfac += tobRegistro.Fcm_valcmo_dfac;
                            lobReg.Fcm_valusu_dfac += tobRegistro.Fcm_valusu_dfac;
                            lobReg.Fcm_valcom_dfac += tobRegistro.Fcm_valcom_dfac;
                            lobReg.Fcm_valsub_dfac += tobRegistro.Fcm_valsub_dfac;
                            lobReg.Fcm_valfac_dfac += tobRegistro.Fcm_valfac_dfac;
                            lobReg.Fcm_valref_dfac += tobRegistro.Fcm_valref_dfac;
                            lobReg.Fcm_valefe_dfac += tobRegistro.Fcm_valefe_dfac;
                            llgEncontrado = true;
                            #endregion
                        }
                    }
                }
                //- Adicionar cuando no existe
                if (llgEncontrado == false)
                {
                    var lobRegFac = new FcmModeloMaestrofacturas();

                    // Valores por defecto Facturas Electronica Dian
                    lobRegFac.Fcm_typdoc_fctd = "01";
                    lobRegFac.Fcm_metpag_mfac = "2";
                    lobRegFac.Fcm_codmpg_fcmp = "1";
                    lobRegFac.Fcm_diavfa_mfac = Convert.ToInt32(Funciones.fcrLeerConfigVarSistema("FCM-DIAN-FACTURA-DIAS-VENCIMIENTO", "30"));
                    lobRegFac.Fcm_fecven_mfac = (Funciones.FdaFechaActual()).AddDays(lobRegFac.Fcm_diavfa_mfac);
                    lobRegFac.Fcm_horfac_mfac = Funciones.FdeHoraActualMilitar();
                    lobRegFac.Fcm_codest_fcws = "NA";

                    // Datos de la resolucion Dian
                    var lobRegCntr = CTOValidarCodigo.FobRegBuscarContratoRazonSocialDataRow(tobRegistro.Cto_seccon_cont);
                    if (lobRegCntr != null)
                    {
                        lobRegFac.Fcm_secraz_fcem = lobRegCntr["fcm_secraz_fcem"].ToString().Trim();
                        lobRegFac.Fcm_secres_srfa = lobRegCntr["fcm_secres_srfa"].ToString().Trim();
                    }

                    // Completar el registro
                    #region Valores Variables
                    lobRegFac.Fcm_secreg_mfac = tobRegistro.Fcm_secreg_mfac;
                    lobRegFac.Fcm_numfac_mfac = tobRegistro.Fcm_numfac_mfac;
                    lobRegFac.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                    lobRegFac.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                    lobRegFac.Sia_tipide_tide = tobRegistro.Sia_tipide_tide;
                    lobRegFac.Sia_nroide_usua = tobRegistro.Sia_nroide_usua;
                    lobRegFac.Cto_seccon_cont = tobRegistro.Cto_seccon_cont;
                    lobRegFac.Cto_nrocon_cont = tobRegistro.Cto_nrocon_cont;
                    lobRegFac.Sia_codeps_teps = tobRegistro.Sia_codeps_teps;
                    lobRegFac.Sia_deseps_teps = tobRegistro.Sia_deseps_teps;
                    lobRegFac.Sis_idterc_sitr = tobRegistro.Sis_idterc_sitr;
                    lobRegFac.Fcm_fecfac_mfac = tobRegistro.Fcm_fecfac_mfac;
                    lobRegFac.Fcm_autdes_ades = tobRegistro.Fcm_autdes_ades;
                    lobRegFac.Fcm_valbru_dfac = tobRegistro.Fcm_valbru_dfac;
                    lobRegFac.Fcm_valbsi_dfac = tobRegistro.Fcm_valiva_dfac > 0 ? tobRegistro.Fcm_valbru_dfac : 0;
                    lobRegFac.Fcm_pordes_dfac = tobRegistro.Fcm_pordes_dfac;
                    lobRegFac.Fcm_valdes_dfac = tobRegistro.Fcm_valdes_dfac;
                    lobRegFac.Fcm_poriva_dfac = tobRegistro.Fcm_poriva_dfac;
                    lobRegFac.Fcm_valiva_dfac = tobRegistro.Fcm_valiva_dfac;
                    lobRegFac.Fcm_valcpa_dfac = tobRegistro.Fcm_valcpa_dfac;
                    lobRegFac.Fcm_valcmo_dfac = tobRegistro.Fcm_valcmo_dfac;
                    lobRegFac.Fcm_valusu_dfac = tobRegistro.Fcm_valusu_dfac;
                    lobRegFac.Fcm_valcom_dfac = tobRegistro.Fcm_valcom_dfac;
                    lobRegFac.Fcm_valsub_dfac = tobRegistro.Fcm_valsub_dfac;
                    lobRegFac.Fcm_valfac_dfac = tobRegistro.Fcm_valfac_dfac;
                    lobRegFac.Fcm_valref_dfac = tobRegistro.Fcm_valref_dfac;
                    lobRegFac.Fcm_valefe_dfac = tobRegistro.Fcm_valefe_dfac;
                    lobRegFac.Sia_tipact_tsac = tobRegistro.Sia_tipact_tsac;
                    lobRegFac.Sia_desact_tsac = tobRegistro.Sia_desact_tsac;
                    lobRegFac.Sia_regate_rgat = tobRegistro.Sia_regate_rgat;
                    lobRegFac.Fcm_estfac_mfac = tobRegistro.Fcm_estfac_mfac;
                    lobRegFac.Fcm_fecedt_mfac = tobRegistro.Fcm_fecedt_dfac;
                    lobRegFac.Sia_deseps_teps = tobRegistro.Sia_deseps_teps;
                    lobRegFac.Sia_desact_tsac = tobRegistro.Sia_desact_tsac;
                    lobRegFac.Sys_codusu_usux = lcrUsuIdUsuario;
                    lobRegFac.Sia_codcat_ceat = tobRegistro.Sia_codcat_ceat;
                    lobRegFac.Fcm_desfac_mfac = tobRegistro.Fcm_estfac_mfac == "1" ? "ABIERTA" :
                                                tobRegistro.Fcm_estfac_mfac == "2" ? "CONFIRMADA" : "ANULADA";
                    lobRegFac.Sis_estado_imaen = "A";
                    #endregion
                    tmpListFact.Add(lobRegFac);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Validación Facturas Error Metodo: fcvSumaResumenFacturas");
            }
        }
        #endregion
        #region flgConfirmarFacturas: Genera los numeros de factura
        /// <summary>
        /// <para>Genera los nuevos numeros de factura y guarda en maestro factura</para>  
        /// <para>actualiza los registros detalles facturacion en las ordenes de servicios</para>  
        /// </summary>
        public bool flgConfirmarFacturas()
        {
            var llgReturn = false;
            try
            {
                foreach (FcmModeloMaestrofacturas lobFact in tmpListFact)
                {

                    lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                    lobFact.Fcm_estfac_mfac = "2";
                    lobFact.Fcm_desfac_mfac = "CERRADA";
                    lobFact.Sis_estado_imaen = "A";
                    // Generar valor factura con descuento
                    lobFact.Fcm_valsub_dfac = lobFact.Fcm_valbru_dfac - (lobFact.Fcm_valcpa_dfac + lobFact.Fcm_valcmo_dfac +
                                                                         lobFact.Fcm_valusu_dfac + lobFact.Fcm_valdes_dfac);

                    lobFact.Fcm_valfac_dfac = lobFact.Fcm_valsub_dfac + lobFact.Fcm_valiva_dfac + lobFact.Fcm_valcom_dfac;

                    int lnuIndice = 1;
                    //- Actualizar detalles de servicios
                    foreach (FcmModeloServDetallFacturas lobServ in tmpListDetallEdt)
                    {
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                            lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                            lobServ.Sis_estado_imaen = "A";
                            FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                        }
                        lnuIndice++;
                    }
                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
                ADMModeloAdmadmisiones.fcvActualizarEstados(G2Adm_secadm_rgad, "", "", "", "", "",tmpRegAdm.Adm_conest_rgad);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // flgGenValidarRegistro: Valida y genera el registro tipo detalle del servicio facturado
        //-------------------------------------------------
        #region flgGenValidarRegistro: Valida y genera el registro tipo detalle del servicio facturado
        /// <summary>
        /// Valida y genera el registro tipo detalle servicio facturado para ser guardado
        /// </summary>
        public bool flgGenValidarRegistro(ref List<LogsErrores> tmpLogErrores, String tcrNumeroRegistro)
        {
            bool llgReturn = false;
            #region Valores Variables
            llgReturn = String.IsNullOrEmpty(fcrValidacionCampos("Cto_seccon_cont", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Fcm_coddig_mant", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Fcm_codcpr_cpro", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Fcm_fecser_dfac", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Sia_codpfa_prof", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Sia_codare_aser", ref tmpLogErrores, tcrNumeroRegistro)) &&
                                String.IsNullOrEmpty(fcrValidacionCampos("Sia_aresol_aser", ref tmpLogErrores, tcrNumeroRegistro));
            #endregion
            if (llgReturn == true)
            {
                llgReturn = flgValidacionPertinencia(ref tmpLogErrores, tcrNumeroRegistro);
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionCampos: Validacion campos
        //-------------------------------------------------
        #region fcrValidacionCampos: Validacion Campos para generar servicios facturados
        /// <summary>
        /// Funcion para validar los datos cargados en el registro para generar servicios facturados
        /// </summary>
        /// <param name="tcrNombreCampo">Nombre del campo a validar ejemplo "Cto_seccon_cont" = Secuencial unico de contrato</param>
        /// <param name="tmpLogErrores">Referencia al temporal Logs de errores validación</param>
        /// <param name="tcrNumeroRegistro">Codigo unico o numero del registro validado (cuando es un teporal con varios registros)</param>
        /// <returns>Retorna vacio o una cadena que describe el error del campo validado</returns>
        public String fcrValidacionCampos(String tcrNombreCampo, ref List<LogsErrores> tmpLogErrores, String tcrNumeroRegistro)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = tcrNumeroRegistro;
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombreCampo)
                {
                    case "Cto_seccon_cont": // 001
                        #region Validacion Secuencial de Contrato
                        lcrCodigoError = "V001";
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Cto_seccon_cont))
                        {
                            lcrValorReturn = "Secuencial de Contrato: Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G2Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_nrocon_cont))
                            {
                                fcvCargarValoresContrato(tmp);
                                // Verificar contrato inactivo
                                if (tmp.cto_estcon_cont == "2") // Contrato inactivo
                                {
                                    lcrValorReturn = "Contrato: " + G2Cto_nrocon_cont + " esta inactivo";
                                }
                                m.flgCargarParametrosContrato(tmp);
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato "+ G2Cto_seccon_cont + ": No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Fcm_coddig_mant": // 002
                        #region Validacion Código digitación servicio
                        lcrCodigoError = "V002";
                        lcrNombreCampo = "Código digitación servicio";
                        lcrNivelError = "ALTO";

                        G2Fcm_valser_mant = 0;
                        G2Fcm_valbru_dfac = 0;
                        G2Fcm_valsub_dfac = 0;
                        G2Fcm_valfac_dfac = 0;
                        G2Fcm_valcmo_dfac = 0;
                        G2Fcm_valcpa_dfac = 0;

                        if (string.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            lcrValorReturn = "Código digitación servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(G2Fcm_coddig_mant, G2Fcm_codman_mans, G2Cto_seccon_cont, G2Cto_serper_cont);
                            if (tmp != null)
                            {
                                if (tmp.fcm_codser_mant == "E%1") // Error en servicio personalizado
                                {
                                    lcrValorReturn = lcrNombreCampo + ": " + tmp.fcm_desser_mant;
                                }
                                else
                                {
                                    #region fcmmanservicios
                                    G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
                                    G2Fcm_idesec_mant = tmp.fcm_idesec_mant;
                                    G2Fcm_idesec_sips = tmp.fcm_idesec_sips;
                                    G2Fcm_desser_dfac = tmp.fcm_desser_mant;
                                    G2Fcm_codbar_sips = tmp.fcm_codbar_sips;
                                    G2Fcm_codser_mant = tmp.fcm_codser_mant;
                                    //G2Inv_secart_inar = tmp.inv_secart_mart;

                                    //cargar parametros
                                    if (!m.flgCargarParametrosServicio(tmp))
                                    {
                                        lcrValorReturn = "Código digitación servicio " + G2Fcm_coddig_mant + ": Error al cargar parametros para calcular valor servicio";
                                    }
                                    else
                                    {
                                        if (G2Fcm_totuni_dfac <= 0) { G2Fcm_totuni_dfac = 1; }
                                        // Precio menor que cero
                                        if (m.gnuMantValorServicio <= 0 || m.gnuMantPuntajeValorServ <= 0)
                                        {
                                            lcrValorReturn = "Servicio: " + G2Fcm_coddig_mant + " Valor del servicio o puntaje UVR no debe ser cero";
                                        }
                                        //- Cargar parametros del servicio IPS
                                        if (!flgCargarParametrosServiciosIps(G2Fcm_coddig_mant))
                                        {
                                            lcrValorReturn = "Servicio: " + G2Fcm_coddig_mant + " error en configuración, servicio no relacionado en Serivicios IPS";
                                        }
                                        // cuando no hay error, Cargar valor Dia salario minimo 
                                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                                        { 
                                            m.flgCargarParametrosSalarioMinimo(Convert.ToDateTime(G2Fcm_fecser_dfac));
                                        }
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Código digitación servicio " + G2Fcm_coddig_mant + ": No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Fcm_codcpr_cpro": // 003
                        #region Validacion Código centro producción
                        lcrCodigoError = "V003";
                        lcrNombreCampo = "Código centro producción";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            EFfcmcenproduccio tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G2Fcm_codcpr_cpro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_descpr_cpro))
                            {
                                if (String.IsNullOrWhiteSpace(G2Sia_codare_aser)) { G2Sia_codare_aser = tmp.sia_codare_aser; }
                                G2Sia_codcat_ceat = tmp.sia_codcat_ceat;
                                G2Con_codsco_ccos = tmp.con_codsco_ccos;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Fcm_fecser_dfac": // 004
                        #region Validacion Fecha servicio
                        lcrCodigoError = "V004";
                        lcrNombreCampo = "Fecha servicio";
                        lcrNivelError = "ALTO";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Fcm_fecser_dfac, "Fecha servicio");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!m.flgCargarParametrosSalarioMinimo(Convert.ToDateTime(G2Fcm_fecser_dfac)))
                            {
                                var lnuAño = Convert.ToDateTime(G2Fcm_fecser_dfac).Year.ToString();
                                lcrValorReturn = "Fecha servicio: No existe salario minimo configurado año: " + lnuAño + " / fecha servicio: " + G2Fcm_fecser_dfac;
                            }
                        }
                        #endregion
                        break;

                    case "Fcm_totuni_dfac": // 005
                        #region Validacion Total unidades
                        lcrCodigoError = "V005";
                        lcrNombreCampo = "Total unidades";
                        lcrNivelError = "ALTO";

                        if (G2Fcm_totuni_dfac <= 0)
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_totuni_dfac < 1 || G2Fcm_totuni_dfac > 1500)
                            {
                                lcrValorReturn = "Total unidades: Valor fuera del rango";
                            }
                        }
                        #endregion
                        break;

                    case "Fcm_codaqx_aqir": // 006
                        #region Validacion Tipo Acto Quirúrgico
                        lcrCodigoError = "V006";
                        lcrNombreCampo = "Tipo Acto Quirúrgico";
                        lcrNivelError = "ALTO";

                        if (GlgSIS_ActActoQuirurgico == true)
                        {
                            if (!String.IsNullOrWhiteSpace(G2Fcm_codaqx_aqir))
                            {
                                var lcrObj = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                                if (lcrObj != null && lcrObj.fcm_codtse_sips != null)
                                {
                                    if (lcrObj.fcm_codtse_sips.Trim() == "2")
                                    {
                                        EFfcmactquirurgic tmp = new EFfcmactquirurgic();
                                        tmp = FCMValidarCodigo.fobRegBuscarFcmactquirurgic(G2Fcm_codaqx_aqir);
                                        if (tmp == null && String.IsNullOrWhiteSpace(tmp.fcm_desaqx_aqir))
                                        {
                                            lcrValorReturn = "Tipo Acto Quirúrgico: No existe";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Acto Quirúrgico: Es requerido";
                            }
                        }
                        #endregion
                        break;

                    case "Sia_tipact_tsac": // 007
                        #region Validacion Tipo servicio o activiad
                        lcrCodigoError = "V007";
                        lcrNombreCampo = "Tipo servicio o activiad";
                        lcrNivelError = "ALTO";

                        if (String.IsNullOrWhiteSpace(G2Sia_tipact_tsac))
                        {
                            lcrValorReturn = "Tipo servicio o activiad: Es requerido";
                        }
                        else
                        {
                            EFsiatipactividad tmp = new EFsiatipactividad();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipactividad(G2Sia_tipact_tsac);
                            if (tmp == null && String.IsNullOrWhiteSpace(tmp.sia_desact_tsac))
                            {
                                lcrValorReturn = "Tipo servicio o activiad: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Sia_codpfa_prof": // 008
                        #region Validacion Código profesional que atiende
                        lcrCodigoError = "V008";
                        lcrNombreCampo = "Código profesional que atiende";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código profesional atiende: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G2Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                            {

                                G2Sia_codpat_tpat = tmp.sia_codpat_tpat;
                                //G2Sis_idterc_sitr = tmp.sis_idterc_sitr;
                            }
                            else
                            {
                                lcrValorReturn = "Código profesional que atiende: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Sia_aresol_aser": // 009
                        #region Validacion Código área solicita servicio
                        lcrCodigoError = "V009";
                        lcrNombreCampo = "Código área solicita servicio";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_aresol_aser))
                        {
                            lcrValorReturn = "Código área solicita servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G2Sia_aresol_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                if (String.IsNullOrWhiteSpace(G2Sia_codare_aser)) { G2Sia_codare_aser = tmp.sia_codare_aser; }
                            }
                            else
                            {
                                lcrValorReturn = "Código área solicita servicio: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "Sia_codare_aser": // 010
                        #region Validacion Código área que presta el servicio
                        lcrCodigoError = "V010";
                        lcrNombreCampo = "Código área que presta el servicio";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_codare_aser))
                        {
                            lcrValorReturn = "Código área que presta servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G2Sia_codare_aser);
                            if (tmp == null && String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                lcrValorReturn = "Código área que presta servicio: No existe";
                            }
                            else 
                            {
                                if (String.IsNullOrWhiteSpace(G2Sia_aresol_aser)) { G2Sia_aresol_aser = tmp.sia_codare_aser; }
                            }
                        }
                        #endregion
                        break;
                }
                if (tmpLogErrores != null)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionCampos");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcvCargarValoresContrato: Cargar Valores contrato activo
        //-------------------------------------------------
        #region fcvCargarValoresContrato: Cargar Valores contrato activo
        /// <summary>
        /// Cargar Valores contrato activo seleccionado en digitacion
        /// </summary>
        public void fcvCargarValoresContrato(EFctomaescontrato tmpRegContrato)
        {
            G2Cto_nrocon_cont = tmpRegContrato.cto_nrocon_cont;
            G2Cto_seccon_cont = tmpRegContrato.cto_seccon_cont;
            G2Sia_codeps_teps = tmpRegContrato.sia_codeps_teps;
            G2Sis_idterc_sitr = tmpRegContrato.sis_idterc_sitr;
            G2Cto_sepser_cont = tmpRegContrato.cto_sepser_cont;
            G2Fcm_codman_mans = tmpRegContrato.fcm_codman_mans;
            G2Cto_tipact_cont = tmpRegContrato.cto_tipact_cont;
            G2Cto_serper_cont = tmpRegContrato.cto_serper_cont;
            G2Cto_frecus_cont = tmpRegContrato.cto_frecus_cont;
            G2Cto_fcdian_cont = tmpRegContrato.cto_fcdian_cont;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcualrTotServicio: calcular Valor del servicio
        //-------------------------------------------------
        #region fcvCalcularTotalServicio: calcular Valor del servico
        /// <summary>
        /// calcular Valor del servicio y porcentajes segun aplique en contrato
        /// </summary>
        public void fcvCalcularTotalServicio()
        {
            m.Fcm_valusu_dfac = G2Fcm_valusu_dfac;
            m.Fcm_totuni_dfac = G2Fcm_totuni_dfac;
            // Calcualr valores
            m.fcvCalcularValorTotalServicio();
            G2Fcm_valcpa_dfac = m.Fcm_valcpa_dfac;
            G2Fcm_valcmo_dfac = m.Fcm_valcmo_dfac;
            G2Fcm_valser_mant = m.Fcm_valser_mant;
            G2Fcm_valbru_dfac = m.Fcm_valbru_dfac;
            G2Fcm_valsub_dfac = m.Fcm_valsub_dfac;
            G2Fcm_valfac_dfac = m.Fcm_valfac_dfac;
            G2Fcm_valdes_dfac = m.Fcm_valdes_dfac;
            G2Fcm_pordes_dfac = m.Fcm_pordes_dfac;
            G2Fcm_valiva_dfac = m.Fcm_valiva_dfac;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcularCopagoyCmoderadoras: calcular copagos y cuotas moderadoras
        //-------------------------------------------------
        #region fcvCalcularCopagoyCmoderadoras: Calcular copagos y cuotas moderadoras
        /// <summary>
        /// Calcular Valor de los copagos y cuotas moderadoras
        /// </summary>
        public void fcvCalcularCopagoyCmoderadoras()
        {
            //m.flgCargarParametrosServicio(G2Fcm_coddig_mant);
            m.gcrAdmTipoRegimenAfiliado  = tmpRegAdm.Sia_tipusu_regi;
            m.gcrAdmAmbitoAtencion       = tmpRegAdm.Adm_codtat_tatn;
            m.gcrAdmTipoAfilContributivo = tmpRegAdm.Sia_tipafi_tafi;
            m.gcrAdmNivelContributivo    = tmpRegAdm.Sia_nivcon_ncon;
            m.gcrAdmNivelSisben          = tmpRegAdm.Sia_nivsbn_nsbn;
            // Ejecutar calculo copagos
            m.flgCalcularCopagoyCmoderadoras();
            // tomar los nuevos valores
            //m.Fcm_valcpa_dfac = flgValidExisteCopagoCmod("1") ? 0 : m.Fcm_valcpa_dfac; // no se valida para que se sumen los copagos
            m.Fcm_valcmo_dfac = flgValidExisteCopagoCmod("2") ? 0 : m.Fcm_valcmo_dfac;
            G2Fcm_valcpa_dfac = m.Fcm_valcpa_dfac;
            G2Fcm_valcmo_dfac = m.Fcm_valcmo_dfac;
            // Realizar calculo para descontar copago del valor servicio
            if (m.gcrContDescontarCopago == "1") 
            {
                G2Fcm_valfac_dfac = m.Fcm_valfac_dfac - (G2Fcm_valcpa_dfac + G2Fcm_valcmo_dfac);
            }
        }
        #endregion
        //-------------------------------------------------
        // Validacion Existe copago o Cuota Moderadora
        //-------------------------------------------------
        #region flgValidExisteCopagoCmod: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion para saber si ya exite un copago o cuota moderadora ya facturada
        /// tcrTipoCobro: 1= Copago 2= Cuota moderadora
        /// </summary>
        public bool flgValidExisteCopagoCmod(String tcrTipoCobro)
        {
            var llgReturn = true;
            var llgCopago = false;
            var llgCmoder = false;

            foreach (var lobReg in tmpListDetallEdt)
            {
                llgCopago = lobReg.Fcm_valcpa_dfac > 0 ? true : llgCopago;
                llgCmoder = lobReg.Fcm_valcmo_dfac > 0 ? true : llgCmoder;
            }
            llgReturn = tcrTipoCobro == "1" ? llgCopago : llgCmoder;

            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia(ref List<LogsErrores> tmpLogErrores, String tcrNumeroRegistro)
        {
            var llgReturn = true;

            m.gcrAdmIdUnicoUsuario       = tmpRegAdm.Sia_idesec_usua;
            m.gcrAdmSexoDelAfiliado      = tmpRegAdm.Sis_codsex_sexo;
            m.gcrAdmTipoRegimenAfiliado  = tmpRegAdm.Sia_tipusu_regi;
            m.gcrAdmAmbitoAtencion       = tmpRegAdm.Adm_codtat_tatn;
            m.gcrAdmFechaNacimiento      = Funciones.fcrConvertFecha(tmpRegAdm.Sia_fecnac_usua);
            m.gcrAdmFechaAdmision        = Funciones.fcrConvertFecha(tmpRegAdm.Adm_fecadm_rgad);
            m.gcrAdmFechaServicio        = G2Fcm_fecser_dfac;
            m.gcrAdmFechaAgendaCita      = G2Cit_feccit_mcit;
            m.gcrAdmTipoAfilContributivo = tmpRegAdm.Sia_tipafi_tafi;
            m.gcrAdmNivelContributivo    = tmpRegAdm.Sia_nivcon_ncon;
            m.gcrAdmNivelSisben          = tmpRegAdm.Sia_nivsbn_nsbn;
            m.gnuAdmEdadEnAños           = tmpRegAdm.Sia_edaano_usua;
            m.gnuAdmEdadEnMeses          = tmpRegAdm.Sia_edames_usua;
            m.gnuAdmEdadEnDias           = tmpRegAdm.Sia_edadia_usua;
            m.Fcm_totuni_dfac            = G2Fcm_totuni_dfac;

            //Validar pertinencia
            llgReturn = m.flgValidacionPertinencia(ref tmpLogErrores, tcrNumeroRegistro);
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcvValorDefectoVariables: Valores por defecto variables de control
        //-------------------------------------------------
        #region fcvValorDefectoVariables: Valores por defecto variables de control
        /// <summary>
        /// Reiniciar los valores por defectos en las variables que controlarn
        /// activacion de algunso campos y validacion de pertinencia.
        /// </summary>
        public void fcvValorDefectoVariables()
        {
            try
            {
                G2Fcm_totuni_dfac = 1;
                G2Fcm_valbru_dfac = 0;
                G2Fcm_pordes_dfac = 0;
                G2Fcm_valdes_dfac = 0;
                G2Fcm_poriva_dfac = 0;
                G2Fcm_valiva_dfac = 0;
                G2Fcm_valcpa_dfac = 0;
                G2Fcm_valcmo_dfac = 0;
                G2Fcm_valusu_dfac = 0;
                G2Fcm_valcom_dfac = 0;
                G2Fcm_valsub_dfac = 0;
                G2Fcm_valfac_dfac = 0;
                G2Fcm_valref_dfac = 0;
                G2Fcm_valefe_dfac = 0;
                GlgSIS_ActActoQuirurgico = false;
                // Iniciar temporales
                tmpRegAdm        = new ADMModeloAdmadmisiones();
                tmpRegFact       = new FcmModeloMaestrofacturas();
                tmpListFact      = new List<FcmModeloMaestrofacturas>();
                tmpRegDetall     = new FcmModeloServDetallFacturas();
                tmpListDetallEdt = new List<FcmModeloServDetallFacturas>();
                // Iniciar las variables de gestion
                m.fcvValorDefectoVariables();

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvValorDefectoVar");
            }
        }
        #endregion
        //-------------------------------------------------
        // fcvCargarRegActivoDesdeVariables: Valores por defecto variables de control
        //-------------------------------------------------
        #region fcvCargarRegActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro del servicio desde  las Variables
        /// </summary>
        public void fcvCargarRegActivoDesdeVariables()
        {
            tmpRegDetall = new FcmModeloServDetallFacturas();
            #region Valores Variables
            tmpRegDetall.Fcm_secreg_dfac = G2Fcm_secreg_dfac;
            tmpRegDetall.Adm_secadm_rgad = G2Adm_secadm_rgad;
            //tmpRegDetall.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
            //tmpRegDetall.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
            //tmpRegDetall.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
            tmpRegDetall.Sia_idesec_usua = G2Sia_idesec_usua;
            tmpRegDetall.Sia_tipide_tide = G2Sia_tipide_tide;
            tmpRegDetall.Sia_nroide_usua = G2Sia_nroide_usua;
            tmpRegDetall.Cto_seccon_cont = G2Cto_seccon_cont;
            tmpRegDetall.Cto_nrocon_cont = G2Cto_nrocon_cont;
            tmpRegDetall.Sia_codeps_teps = G2Sia_codeps_teps;
            tmpRegDetall.Sis_idterc_sitr = G2Sis_idterc_sitr;
            tmpRegDetall.Fcm_secreg_mfac = G2Fcm_secreg_mfac;
            tmpRegDetall.Fcm_numfac_mfac = G2Fcm_numfac_mfac;
            tmpRegDetall.Fcm_tiprfa_mfac = G2Fcm_tiprfa_mfac;
            tmpRegDetall.Fcm_fecfac_mfac = Convert.ToDateTime(G2Fcm_fecfac_mfac);
            tmpRegDetall.Fcm_estfac_mfac = G2Fcm_estfac_mfac;
            tmpRegDetall.Adm_nroaut_rgad = G2Adm_nroaut_rgad;
            tmpRegDetall.Sia_codrip_trip = G2Sia_codrip_trip;
            tmpRegDetall.Inv_secart_inar = G2Inv_secart_inar;
            tmpRegDetall.Inv_codaux_inar = G2Inv_codaux_inar;
            tmpRegDetall.Fcm_idesec_sips = G2Fcm_idesec_sips;
            tmpRegDetall.Fcm_codbar_sips = G2Fcm_codbar_sips;
            tmpRegDetall.Fcm_idesec_mant = G2Fcm_idesec_mant;
            tmpRegDetall.Fcm_codser_mant = G2Fcm_codser_mant;
            tmpRegDetall.Fcm_coddig_mant = G2Fcm_coddig_mant;
            tmpRegDetall.Con_codsco_ccos = G2Con_codsco_ccos;
            tmpRegDetall.Fcm_codcpr_cpro = G2Fcm_codcpr_cpro;
            tmpRegDetall.Fcm_desser_dfac = G2Fcm_desser_dfac;
            tmpRegDetall.Fcm_codman_mans = G2Fcm_codman_mans;
            tmpRegDetall.Fcm_fecser_dfac = Convert.ToDateTime(G2Fcm_fecser_dfac);
            tmpRegDetall.Fcm_horser_dfac = Decimal.Parse(G2Fcm_horser_dfac);
            tmpRegDetall.Fcm_perman_sips = G2Fcm_perman_sips;
            tmpRegDetall.Fcm_forfar_sips = G2Fcm_forfar_sips;
            tmpRegDetall.Fcm_conmed_sips = G2Fcm_conmed_sips;
            tmpRegDetall.Fcm_unimed_sips = G2Fcm_unimed_sips;
            tmpRegDetall.Fcm_autdes_ades = G2Fcm_autdes_ades;
            tmpRegDetall.Fcm_valser_mant = G2Fcm_valser_mant;
            tmpRegDetall.Fcm_totuni_dfac = G2Fcm_totuni_dfac;
            tmpRegDetall.Fcm_valbru_dfac = G2Fcm_valbru_dfac;
            tmpRegDetall.Fcm_pordes_dfac = G2Fcm_pordes_dfac;
            tmpRegDetall.Fcm_valdes_dfac = G2Fcm_valdes_dfac;
            tmpRegDetall.Fcm_poriva_dfac = G2Fcm_poriva_dfac;
            tmpRegDetall.Fcm_valiva_dfac = G2Fcm_valiva_dfac;
            tmpRegDetall.Fcm_valcpa_dfac = G2Fcm_valcpa_dfac;
            tmpRegDetall.Fcm_valcmo_dfac = G2Fcm_valcmo_dfac;
            tmpRegDetall.Fcm_valusu_dfac = G2Fcm_valusu_dfac;
            tmpRegDetall.Fcm_valcom_dfac = G2Fcm_valcom_dfac;
            tmpRegDetall.Fcm_valsub_dfac = G2Fcm_valsub_dfac;
            tmpRegDetall.Fcm_valfac_dfac = G2Fcm_valfac_dfac;
            tmpRegDetall.Fcm_valref_dfac = G2Fcm_valref_dfac;
            tmpRegDetall.Fcm_valefe_dfac = G2Fcm_valefe_dfac;
            tmpRegDetall.Fcm_codtse_sips = G2Fcm_codtse_sips;
            tmpRegDetall.Fcm_codaqx_aqir = G2Fcm_codaqx_aqir;
            tmpRegDetall.Sia_tipact_tsac = G2Sia_tipact_tsac;
            tmpRegDetall.Adm_codtat_tatn = G2Adm_codtat_tatn;
            tmpRegDetall.Sia_codfpr_fpor = G2Sia_codfpr_fpor;
            tmpRegDetall.Sia_codfco_fcon = G2Sia_codfco_fcon;
            tmpRegDetall.Adm_codcex_tcex = G2Adm_codcex_tcex;
            tmpRegDetall.Sia_coddia_tdia = !String.IsNullOrWhiteSpace(G2Sia_coddia_tdia)?G2Sia_coddia_tdia: tmpRegAdm.Sia_coddia_tdia;
            tmpRegDetall.Sia_tipdxp_tdix = !String.IsNullOrWhiteSpace(G2Sia_tipdxp_tdix) ? G2Sia_tipdxp_tdix : tmpRegAdm.Sia_tipdxp_tdix; 
            tmpRegDetall.Sia_coddx1_tdia = G2Sia_coddx1_tdia;
            tmpRegDetall.Sia_coddx2_tdia = G2Sia_coddx2_tdia;
            tmpRegDetall.Sia_coddx3_tdia = G2Sia_coddx3_tdia;
            tmpRegDetall.Sia_coddxc_tdia = G2Sia_coddxc_tdia;
            tmpRegDetall.Sia_codgac_gpyp = G2Sia_codgac_gpyp;
            tmpRegDetall.Sia_codact_apyp = G2Sia_codact_apyp;
            tmpRegDetall.Fcm_serpos_sips = G2Fcm_serpos_sips;
            tmpRegDetall.Cto_tipact_cont = G2Cto_tipact_cont;
            tmpRegDetall.Sia_codpat_tpat = G2Sia_codpat_tpat;
            tmpRegDetall.Sia_codpfa_prof = G2Sia_codpfa_prof;
            tmpRegDetall.Fac_horprs_dfac = Decimal.Parse(G2Fac_horprs_dfac);
            tmpRegDetall.Fcm_atepro_dfac = G2Fcm_atepro_dfac;
            tmpRegDetall.Sia_codare_aser = G2Sia_codare_aser;
            tmpRegDetall.Sia_aresol_aser = G2Sia_aresol_aser;
            tmpRegDetall.Desia_aresol_aser = G2Desia_aresol_aser;
            tmpRegDetall.Fcm_tipser_sips = G2Fcm_tipser_sips;
            tmpRegDetall.Fcm_fecedt_dfac = Convert.ToDateTime(G2Fcm_fecedt_dfac);
            tmpRegDetall.Sys_codusu_usux = G2Sys_codusu_usux;
            tmpRegDetall.Fcm_otserv_sips = G2Fcm_otserv_sips;
            tmpRegDetall.Sia_regate_rgat = G2Sia_regate_rgat;
            tmpRegDetall.Sia_codcat_ceat = G2Sia_codcat_ceat;
            tmpRegDetall.Fcm_ripsco_dfac = G2Fcm_ripsco_dfac;
            tmpRegDetall.Inv_codalm_inal = G2Inv_codalm_inal;
            tmpRegDetall.Inv_codgme_mgme = G2Inv_codgme_mgme;
            tmpRegDetall.Inv_coduma_muma = G2Inv_coduma_muma;
            tmpRegDetall.Sis_estpro_espr = G2Sis_estpro_espr;
            tmpRegDetall.Cto_sepser_cont = G2Cto_sepser_cont;
            tmpRegDetall.Hcl_codreg_hcca = G2Hcl_codreg_hcca;
            tmpRegDetall.Sia_deseps_teps = G2Sia_deseps_teps;
            tmpRegDetall.Sia_desact_tsac = G2Sia_desact_tsac;
            tmpRegDetall.Cto_frecus_cont = G2Cto_frecus_cont;
            tmpRegDetall.Fcm_aplfus_sips = G2Fcm_aplfus_sips;
            tmpRegDetall.Fcm_intser_sips = G2Fcm_intser_sips;
            tmpRegDetall.Sis_estado_imaen = G2Sis_estado_imaen;
            
            #endregion
        }
        #endregion
        //-------------------------------------------------
        // Cargar parametros generales del servicio 
        //-------------------------------------------------
        #region flgCargarParametrosServiciosIps: Cargar parametros servicios IPS dado codigo de Digitación
        /// <summary>
        /// Cargar los parametros desde la tabla servicios IPS, dado el codigo de Digitación
        /// </summary>
        public bool flgCargarParametrosServiciosIps(String tcrCodigoDigitacion)
        {
            var llgReturn = true;
            GlgSIS_ActActoQuirurgico = false;

            var tmpAx = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(tcrCodigoDigitacion);
            llgReturn = flgCargarParametrosServiciosIps(tmpAx);

            return llgReturn;
        }
        #endregion
        #region flgCargarParametrosServiciosIps: Cargar parametros servicios IPS dado temporal Registro
        /// <summary>
        /// Cargar los parametros desde la tabla servicios IPS, dado temporal Registro 
        /// </summary>
        public bool flgCargarParametrosServiciosIps(EFfcmmanservicips tobRegServIPS)
        {
            var llgReturn = true;
            GlgSIS_ActActoQuirurgico = false;

            if (tobRegServIPS != null)
            {
                #region Cargar parametros del servicio IPS
                //- verificar si hay acto quirurgico
                if (tobRegServIPS.fcm_codtse_sips == "2") { GlgSIS_ActActoQuirurgico = true; } // es proc quirurgico
                // datos del servicio IPS adicionales
                G2Sia_codrip_trip = tobRegServIPS.sia_codrip_trip;
                G2Fcm_serpos_sips = tobRegServIPS.fcm_serpos_sips;
                G2Sia_tipact_tsac = tobRegServIPS.sia_tipact_tsac;
                G2Fcm_codtse_sips = tobRegServIPS.fcm_codtse_sips;
                G2Fcm_otserv_sips = tobRegServIPS.fcm_otserv_sips;
                G2Sia_codfco_fcon = tobRegServIPS.sia_codfco_fcon;
                G2Sia_codfpr_fpor = tobRegServIPS.sia_codfpr_fpro;
                G2Fcm_codcpr_cpro = tobRegServIPS.fcm_codcpr_cpro;
                G2Fcm_forfar_sips = tobRegServIPS.fcm_forfar_sips;
                G2Fcm_conmed_sips = tobRegServIPS.fcm_conmed_sips;
                G2Fcm_unimed_sips = tobRegServIPS.fcm_unimed_sips;
                G2Sia_codpat_tpat = tobRegServIPS.sia_codpat_tpat;
                G2Sia_tipdxp_tdix = tobRegServIPS.sia_tipdxp_tdix;
                G2Sia_coddia_tdia = tobRegServIPS.sia_coddia_tdia !="NA"? tobRegServIPS.sia_coddia_tdia : String.Empty;
                G2Fcm_aplfus_sips = tobRegServIPS.fcm_aplfus_sips;
                G2Fcm_intser_sips = (int)tobRegServIPS.fcm_intser_sips;
                G2Sia_desact_tsac = tobRegServIPS.sia_tipact_tsac == "1" ? "ASISTENCIAL" : "PROMOCIÓN Y PREVENCIÓN";
                #endregion
            }
            else
            {
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion
    }
}

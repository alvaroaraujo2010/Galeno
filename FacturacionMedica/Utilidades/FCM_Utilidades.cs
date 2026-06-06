using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Sistema.Modelo;
using Sistema.Clases;
using System.Windows.Media;
using System.Globalization;
using Datos.Modelos;
using Sistema.Utilidades;

namespace FacturacionMedica.Utilidades
{
    public class FCMUtilidades
    {
        //-------------------------------------------------
        // flgValidarRangoHorasAdmisionEx: Validar rango fechas 
        // y horas de la admision sean validas 
        //-------------------------------------------------
        #region  flgValidarRangoHorasAdmisionEx: Validar rango fechas y horas
        /*
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
        */
        #endregion
    }
    #region ISelccionFacturas: Interface para devolver Lista de facturas desde la vista seleccion para cuentas de cobro
    /// <summary>
    /// <para>Interface para devolver Lista de facturas desde la vista seleccion para cuentas de cobro</para>
    /// </summary>
    public interface ISelccionFacturas : SIS_Interface
    {
        void fcvISleeccionFacturas(List<SeleccionFacturas> tlsSeleccionFacturas);
    }
    #endregion
    #region ListaSeleccion: clase para devolver listas facturas seleccionada para cuenta de cobro
    /// <summary>
    /// <para>clase para devolver listas facturas seleccionada para cuenta de cobro</para>
    /// </summary>
    public class SeleccionFacturas
    {
        #region Parametros
        /// <summary>Secuencial unico de la orden medica facturada (generado por el sistema)</summary>
        public String Fcm_secreg_mfac { get; set; }
        /// <summary>Secuencial de Admisión o del registro de atencion ambulatoria</summary>
        public String Adm_secadm_rgad { get; set; }
        /// <summary>Numero de la factura generada en el cierre de facturación</summary>
        public String Fcm_numfac_mfac { get; set; }
        /// <summary>Consecutivo Unico de paciente en el sistema</summary>
        public String Sia_idesec_usua { get; set; }
        /// <summary>Tipo identificacion del usuario o Paciente </summary>
        public String Sia_tipide_tide { get; set; }
        /// <summary>Numero de identificacion del paciente</summary>
        public String Sia_nroide_usua { get; set; }
        /// <summary>Secuencial Unico de Contrato</summary>
        public String Cto_seccon_cont { get; set; }
        /// <summary>Codigo de Eps </summary>
        public String Sia_codeps_teps { get; set; }
        /// <summary>Empresa cliente y/o tercero contable EPS</summary>
        public String Sis_idterc_sitr { get; set; }
        /// <summary>Fecha de la factura</summary>
        public DateTime Fcm_fecfac_mfac { get; set; }
        /// <summary>Valor total  bruto facturado del servicio sin ninguna deducción: FCM_VALSER_SIPS x FCM_TOTUNI_DFA</summary>
        public float Fcm_valbru_dfac { get; set; }
        /// <summary>Porcentaje de descuento aplicado</summary>
        public float Fcm_pordes_dfac { get; set; }
        /// <summary>Valor total del descuento realizado al cliente</summary>
        public float Fcm_valdes_dfac { get; set; }
        /// <summary>Porcentaje del IVA aplicado al servicio</summary>
        public float Fcm_poriva_dfac { get; set; }
        /// <summary>Valor total del IVA recuadado en la factura</summary>
        public float Fcm_valiva_dfac { get; set; }
        /// <summary>Valor total del copago recudado en el srvicio como tal, suma en factura</summary>
        public float Fcm_valcpa_dfac { get; set; }
        /// <summary>Valor total de cuota moderadora recudada en servico y suma en la factura</summary>
        public float Fcm_valcmo_dfac { get; set; }
        /// <summary>Valor cargo al usuario, cobrado al paciente por porcentajes no cubiertos en el seguro</summary>
        public float Fcm_valusu_dfac { get; set; }
        /// <summary>Valor comision</summary>
        public float Fcm_valcom_dfac { get; set; }
        /// <summary>Valor subtotal del servicio facturado haciendo deducciones</summary>
        public float Fcm_valsub_dfac { get; set; }
        /// <summary>Valor total del servicio facturado (valor a entidad), incluyendo el IVA  y demas deducciones</summary>
        public float Fcm_valfac_dfac { get; set; }
        /// <summary>Primer apellido del usuario o paciente</summary>
        public String Sia_priape_usua { get; set; }
        /// <summary>Segundo apellido del usuario o paciente</summary>
        public String Sia_segape_usua { get; set; }
        /// <summary>Primer nombre del usuario o paciente</summary>
        public String Sia_prinom_usua { get; set; }
        /// <summary>Segundo nombre del usuario o paciente</summary>
        public String Sia_segnom_usua { get; set; }
        /// <summary>Nombre completo concatenado del paciente</summary>
        public String Sia_nomusu_usua { get; set; }
        /// <summary>Codigo Tipo servicio o actividad: 1=Asistencial 2=Promocion</summary>
        public String Sia_tipact_tsac { get; set; }
        /// <summary>Descripcion tipo servicio o actividad: 1=Asistencial 2=Promocion</summary>
        public String Sia_desact_tsac { get; set; }
        /// <summary>Codigo tipo Registro de Atencion: 1 = Admitidos 2=Ambulatoria</summary>
        public String Sia_regate_rgat { get; set; }
        /// <summary>Descripcion tipo Registro de Atencion: 1 = Admitidos 2=Ambulatoria</summary>
        public String Sia_desate_rgat { get; set; }
        /// <summary>marca de seleccion Boleana</summary>
        public bool MarcaBool { get; set; }
        #endregion
    }
    #endregion
    #region ForegroundColorEstado: Poner color a la fuente de la grilla segun estado del registro
    /// <summary>
    /// <para>Poner color a la fuente de la grilla segun estado del registro</para>
    /// </summary>
    public class ForegroundColorEstado : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                String lcrEstado = (String)value;
                switch (lcrEstado)
                {
                    case "1": // Rips no fue completado
                        return Brushes.Red;

                    case "2": // Rips completado
                        return Brushes.Black;

                    case "3": // No requiere completar
                        return Brushes.Black;

                    case "4": // Actualizado en el momento
                        return Brushes.Green;

                    default:
                        return Brushes.Black; // Valor por defecto
                }
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}

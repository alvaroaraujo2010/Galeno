using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    //--------------------------------------------------------------------
    //
    //--------------------------------------------------------------------
    #region LogsErrores: Clase para cargar lista de errores
    /// <summary>
    /// <para>Temporal para cargar lista de errores</para>
    /// </summary>
    public class LogsErrores
    {
        #region fcvAddLogErrores: Registros logs de errores
        public String Imagen { get; set; }                // Nombre de la imagen a mostrar segun nivel de error
        public String IdRegistro { get; set; }            // Numero unico del registro
        public String NumeroRegistro { get; set; }        // Numero dle registro en archivo plano o excel etc..
        public String CodigoError { get; set; }           // Codigo del error
        public String NombreCampo { get; set; }
        public String MensajeError { get; set; }
        public String NivelError { get; set; }
        #endregion
        //-------------------------------------------------
        // Adicionar registros al log de errores
        //-------------------------------------------------
        #region fcvAddLogErrores: Adicionar registros al log de errores
        /// <summary>
        /// Adicionar registros al log de errores
        /// </summary>
        public static void fcvAddLogErrores(ref List<LogsErrores> tobTmpLogErrores,  String tcrNumeroRegistro, String tcrCodigoError,
                                             String tcrNombreCampo, String tcrMensajeError, String tcrNivelError, String lcrImgNivelError)
        {
            try
            {
                var tmpRegLogActivo = new LogsErrores();
                var lnuIndiceReg = -1;

                lnuIndiceReg = fnuLocalizarRegistroError(ref tobTmpLogErrores, tcrCodigoError, tcrMensajeError);
                if (!String.IsNullOrWhiteSpace(tcrMensajeError) && lnuIndiceReg == -1)
                {
                    tmpRegLogActivo = new LogsErrores();
                    tmpRegLogActivo.NumeroRegistro = tcrNumeroRegistro;
                    tmpRegLogActivo.CodigoError = tcrCodigoError;
                    tmpRegLogActivo.NombreCampo = tcrNombreCampo;
                    tmpRegLogActivo.MensajeError = tcrMensajeError;
                    tmpRegLogActivo.NivelError = tcrNivelError;
                    tmpRegLogActivo.Imagen = lcrImgNivelError;
                    tobTmpLogErrores.Add(tmpRegLogActivo);
                }
                if (String.IsNullOrWhiteSpace(tcrMensajeError) && lnuIndiceReg != -1)
                {
                    while (lnuIndiceReg != -1)
                    {
                        lnuIndiceReg = fnuLocalizarRegistroError(ref tobTmpLogErrores, tcrCodigoError, tcrMensajeError);
                        if (lnuIndiceReg != -1)
                        {
                            tobTmpLogErrores.RemoveAt(lnuIndiceReg);
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAddLogErrores");
            }
        }
        #endregion
        #region fnuLocalizarRegistroError: Localizar el registro de error dado el codigo error en parametro
        /// <summary>
        /// Localizar el registro de error dado el codigo error en parametro
        /// </summary>
        public static int fnuLocalizarRegistroError(ref List<LogsErrores> tobTmpLogErrores, String tcrCodigoError, String tcrMensajeError)
        {
            int tcrIndice = -1;
            var lnuIndex = 0;

            try
            {
                if (tobTmpLogErrores.Count > 0 && !String.IsNullOrWhiteSpace(tcrCodigoError))
                {
                    foreach (LogsErrores lobReg in tobTmpLogErrores)
                    {
                        if (lobReg.CodigoError == tcrCodigoError)
                        {
                            tcrIndice = lnuIndex;
                            if (!String.IsNullOrWhiteSpace(tcrMensajeError))
                            {
                                lobReg.MensajeError = tcrMensajeError;
                            }
                        }
                        lnuIndex++;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fnuLocalizarRegistroError");
            }
            return tcrIndice;
        }
        #endregion
    }
    #endregion
    #region LogErrores: Clase para cargar lista de errores
    /// <summary>
    /// <para>Temporal para cargar lista de errores incluye datos de usuarios (nombre y apellidos)</para>
    /// </summary>
    public class LogErrores
    {
        #region fcvAddLogErrores: Registros logs de errores
        public int Secuencial { get; set; }               // Secuencial de registros de errores (campo unico)
        public String Imagen { get; set; }                // Nombre de la imagen a mostrar segun nivel de error
        public String IdRegistro { get; set; }            // Numero unico del registro
        public String NumeroRegistro { get; set; }        // Numero del registro en archivo plano o excel etc..
        public String NombreCampo { get; set; }
        public String ValorCampo { get; set; }
        public String CodigoError { get; set; }           // Codigo del error
        public String MensajeError { get; set; }
        public String NivelError { get; set; }
        public String IdUnicoUsuario { get; set; }
        public String IdUsuario { get; set; }
        public String PApellido { get; set; }
        public String SApellido { get; set; }
        public String PNombre { get; set; }
        public String SNombre { get; set; }
        public String LlaveBusqueda { get; set; }
        #endregion
    }
    #endregion
    #region ParamValid4505: clase para enviar Parametros a las funciones de validacion
    /// <summary>
    /// <para>clase para enviar Parametros a las funciones de validacion 4505 Rips y otros</para>
    /// </summary>
    public class ParamValid4505
    {
        #region ParamValid: Parametros para validacion 
        public DateTime FechaIniPeriodo { get; set; }     // Fecha inicio periodo validacion
        public DateTime FechaFinPeriodo { get; set; }     // Fecha fin periodo validacion
        public String FechaFormato { get; set; }          // Tipo formato fecha DMY, YMD ...
        public String FechaSeparador { get; set; }        // Caracter separador del formato fecha  Slash (/) o guion medio (-) y otros
        public String CodigoEps { get; set; }             // Codigo EPS
        public String OrigenDatos { get; set; }           // Origen Datos en la vista: BDATOS/EXCEL/PLANO
        public String CodigoPeriodo { get; set; }         // Codigo del periodo de datos activo (rango de fechas)
        public String CodigoPlantilla { get; set; }       // Codigo de la plantilla para validacion
        #endregion
    }
    #endregion
    #region ParamValidMS: clase para enviar Parametros a las funciones de validacion
    /// <summary>
    /// <para>clase para enviar Parametros a las funciones de validacion Maestro subsidiado 1344 y 812</para>
    /// </summary>
    public class ParamValidMS
    {
        #region ParamValid: Parametros para validacion
        public String FechaFormato { get; set; }          // Tipo formato fecha DMY, YMD ...
        public String FechaSeparador { get; set; }        // Caracter separador del formato fecha  Slash (/) o guion medio (-) y otros
        public DateTime FechaValidacion { get; set; }     // Fecha asumida como actual en la que se ejcuta la validacion
        public String CodigoEps { get; set; }             // Codigo EPS
        public String OrigenDatos { get; set; }           // Origen Datos en la vista: BDATOS/EXCEL/PLANO
        public String CodigoPlantilla { get; set; }       // Codigo de la plantilla para validacion
        #endregion
    }
    #endregion
    #region SysAdmGrupoNotifi: clase para cargar lista de notificaciones de gestion
    /// <summary>
    /// <para>clase para cargar lista resumen de notificaciones de gestion de datos</para>
    /// </summary>
    public class SysAdmGrupoNotifi
    {
        #region Parametros
        /// <summary>Referencia Objeto Boton</summary>
        public FrameworkElement RefObjeto { get; set; }
        /// <summary>Grupo o modulo al que se envia notificacion</summary>
        public String IdGrupo { get; set; }            
        /// <summary>Nombre Grupo o modulo al que se envia notificacion</summary>
        public String NombreGrupo { get; set; }
        /// <summary>Codigo Id tipo mensaje: ADM-ADMI-URGENCIAS = Registro de admisión Urgencias FCM-AUTORIZ-DESC-CAJA = Autorizacion descuento en caja facturacion</summary>
        public String IdNotificacion { get; set; }
        /// <summary>Nombre tipo mensaje: ADM-ADMI-URGENCIAS = Registro de admisión Urgencias FCM-AUTORIZ-DESC-CAJA = Autorizacion descuento en caja facturacion</summary>
        public String NombreNotificacion { get; set; }
        /// <summary>Codigo perfil del usuario que recibe notificación</summary>
        public String IdPerfil { get; set; }
        /// <summary>Codigo del usuario que recibe notificacion (requerido para notificaciones privadas)</summary>
        public String IdUsuario { get; set; }
        /// <summary>Tipo Notificacion: 1= Mensaje Publico 2= Mensaje publico con recibido 3= Mensaje Privado (solo a un usuario en particular)</summary>
        public String TipoNotifiPublico { get; set; }
        /// <summary>Texto string  activo que el usuario escribe como filtro en la busqueda superior de la ventana de notificaciones</summary>
        public String FiltroBusqueda { get; set; }
        /// <summary>Mensaje que va a leer el asistente de voz</summary>
        public String OnairisMensaje { get; set; }
        /// <summary>Llave numerica que contiene fecha y hora de la ultima notificacion generada</summary>
        public long LlaveFechaHora { get; set; } 
        /// <summary>Contador de Id notificaciones para vista en alertas</summary>
        public int Contador { get; set; } 
        #endregion
    }
    #endregion
    #region RefVistaWindows: clase para referenciar ventanas abiertas
    /// <summary>
    /// <para>Guardar una referencia de las ventanas abiertas en la aplicacion</para>
    /// </summary>
    public class RefVistaWindows
    {
        #region Parametros
        /// <summary>Referencia Objeto Ventana</summary>
        public Window RefWindows { get; set; }
        /// <summary>Id unico en orden lista segun pila  Application.Current.Windows</summary>
        public int IdWindows { get; set; }
        /// <summary>Nombre de la vista ventana abierta (propiedad Name)</summary>
        public String NombreWindows { get; set; }
        /// <summary>Estado de la ventana naturalmente Maximizado/Normal para restaurar despues de minimizar</summary>
        public System.Windows.WindowState EstadoWindows { get; set; }
        /// <summary>Dato auxiliar para multipropositos</summary>
        public String KeyAuxWindows { get; set; }
        #endregion
    }
    #endregion
    #region ListaSeleccion: clase para devolver listas de propositos generales en vistas de seleccion
    /// <summary>
    /// <para>clase para cargar lista de notificaciones de gestion de datos</para>
    /// </summary>
    public class ListaSeleccion
    {
        #region Parametros
        /// <summary>Referencia algun Objeto cuando sea requerido</summary>
        public FrameworkElement RefObjeto { get; set; }
        /// <summary>Id unico numerico (cuando sea requerido)</summary>
        public int IdUnicoNum { get; set; }
        /// <summary>Codigo unico del registro cuando sea requerido</summary>
        public String IdUnico { get; set; }
        /// <summary>Codigo del registro seleccionado</summary>
        public String Codigo { get; set; }
        /// <summary>Nombre o descripcion del registro seleccionada </summary>
        public String Descripcion { get; set; }
        /// <summary>marca de seleccion Boleana</summary>
        public bool MarcaBool { get; set; }
        /// <summary>marca de seleccion numerica</summary>
        public int MarcaInt { get; set; }
        /// <summary>marca de seleccion String</summary>
        public String MarcaString { get; set; }
        /// <summary>Imagen del registro (png/jpg)</summary>
        public String ImagenRegistro { get; set; }
        /// <summary>Imagen para marca seleccion registro (png/jpg)</summary>
        public String ImagenSelect { get; set; }
        /// <summary>Imagen para marca no seleccion registro (png/jpg)</summary>
        public String ImagenNoSelect { get; set; }
        #endregion
    }
    #endregion
    #region SelectFacturasMaestro: devolver listas facturas seleccionadas o modificadas
    /// <summary>
    /// <para>clase para devolver listas Maestro Facturas seleccionada o modificadas</para>
    /// </summary>
    public class SelectFacturasMaestro
    {
        #region Parametros
        /// <summary>Secuencial unico de la orden medica facturada (generado por el sistema)</summary>
        public String Fcm_secreg_mfac { get; set; }
        /// <summary>Secuencial de Admisión o del registro de atencion ambulatoria</summary>
        public String Adm_secadm_rgad { get; set; }
        /// <summary>Numero de autorizacion generado para descuento en pagos en efectivos</summary>
        public String Fcm_autdes_ades { get; set; }
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
        /// <summary>numero del contrato</summary>
        public String Cto_nrocon_cont { get; set; }
        /// <summary>Segun contrato: deduccion desde valor factura: 1= Descontar copagos 2=No Descontar copagos</summary>
        public String Cto_dedcop_cont { get; set; }
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
        /// <summary>Valor total pendiente para recaudo en efectivo</summary>
        public float Fcm_valref_dfac { get; set; }
        /// <summary>Valor final recuadado en efectivo con el descuento realizad (final transaccion)</summary>
        public float Fcm_valefe_dfac { get; set; }
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
        /// <summary>Descripcion de la EPS</summary>
        public String Sia_deseps_teps { get; set; }
        /// <summary>LLave o datos auxiliares para multipropositos</summary>
        public String Sis_auxiliar_datos { get; set; }
        /// <summary>marca de seleccion Boleana</summary>
        public bool MarcaBool { get; set; }
        #endregion
    }
    #endregion
    #region SelectFacturasDetalles: devolver listas registros detalles facturas seleccionadas o modificadas
    /// <summary>
    /// <para>clase para devolver listas registros detalles servicios facturas seleccionadas o modificadas</para>
    /// </summary>
    public class SelectFacturasDetalles
    {
        #region Parametros
        /// <summary>Secuencial unico registro detalle servicio facturado</summary>
        public String Fcm_secreg_dfac { get; set; }
        /// <summary>Secuencial unico de la orden medica facturada (generado por el sistema)</summary>
        public String Fcm_secreg_mfac { get; set; }
        /// <summary>Numero de la factura generada en el cierre de facturación</summary>
        public String Fcm_numfac_mfac { get; set; }
        /// <summary>Secuencial de Admisión o del registro de atencion ambulatoria</summary>
        public String Adm_secadm_rgad { get; set; }
        /// <summary>Consecutivo Unico de paciente en el sistema</summary>
        public String Sia_idesec_usua { get; set; }
        /// <summary>Tipo identificacion del usuario o Paciente </summary>
        public String Sia_tipide_tide { get; set; }
        /// <summary>Numero de identificacion del paciente</summary>
        public String Sia_nroide_usua { get; set; }
        /// <summary>Secuencial Unico de Contrato</summary>
        public String Cto_seccon_cont { get; set; }
        /// <summary>numero del contrato</summary>
        public String Cto_nrocon_cont { get; set; }
        /// <summary>Codigo de Eps </summary>
        public String Sia_codeps_teps { get; set; }
        /// <summary>Empresa cliente y/o tercero contable EPS</summary>
        public String Con_idesec_mter { get; set; }
        /// <summary>Fecha de la factura</summary>
        public DateTime Fcm_fecfac_mfac { get; set; }
        /// <summary>Fecha del servicio</summary>
        public DateTime Fcm_fecser_dfac { get; set; }
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
        /// <summary>Valor total pendiente para recaudo en efectivo</summary>
        public float Fcm_valref_dfac { get; set; }
        /// <summary>Valor final recuadado en efectivo con el descuento realizad (final transaccion)</summary>
        public float Fcm_valefe_dfac { get; set; }
        /// <summary>Codigo Tipo servicio o actividad: 1=Asistencial 2=Promocion</summary>
        public String Sia_tipact_tsac { get; set; }
        /// <summary>Codigo tipo Registro de Atencion: 1 = Admitidos 2=Ambulatoria</summary>
        public String Sia_regate_rgat { get; set; }
        /// <summary>LLave o datos auxiliares para multipropositos</summary>
        public String Sis_auxiliar_datos { get; set; }
        /// <summary>marca de seleccion Boleana</summary>
        public bool MarcaBool { get; set; }
        #endregion
    }
    #endregion
    //----------------------------------------------------------------------
    // GESTION CAMPOS/ITEMS => AGRUPAR, SELECCION, GRUPOS DE CONDICIONES 
    //----------------------------------------------------------------------
    #region TmpGestionItem: Estructura temporal Gestion Campos/items
    /// <summary>
    /// <para>Temporal Gestion Campos/items para seleccion y varios</para>
    /// </summary>
    public class TmpGestionItem
    {
        #region Datos
        /// <summary>Referencia algun Objeto cuando sea requerido</summary>
        public FrameworkElement RefObjeto { get; set; }
        ///<summary>Llave unica secuencial del registro</summary>
        public String Itemllave { get; set; }
        ///<summary>Secuencial numerico para organizar orden vista de elementos</summary>
        public int ItemOrdenVista { get; set; }
        ///<summary>Nombre item o alias Sql de un campo para cuando la selecion es para generar consultas Sql.</summary>
        public String ItemAliasSql { get; set; }
        ///<summary>Nombre unico del item o campo que se esta manipulando Ejemplo: Sia_nroide_usua/A,B,C,D.../1,2,3,4.../ITEM1,ITEM2,ITEM3...</summary>
        public String ItemNombre { get; set; }
        ///<summary>Nombre de la tabla o temporal que contiene el item cuando se trata de un campo</summary>
        public String ItemTabla { get; set; }
        ///<summary>Titulo corto para vista en pantalla del item o campo</summary>
        public String ItemTitulo { get; set; }
        ///<summary>Descripción detallada del elemento para ayuda contextual o focus con mouse</summary>
        public String ItemDescripcion { get; set; }
        ///<summary>Tipo dato cuando el item es un campo 'String'=Caracter 'int'=Numerico 'DateTime'=Fecha 'float'=Flotante 'Decimal'=Decimal ... </summary>
        public String ItemTipoDato { get; set; }
        ///<summary>Valor numerico ancho/largo del tipo item dato cuando es un campo o varaible (en cero cuando no aplique)</summary>
        public int ItemLargoDato { get; set; }
        ///<summary>Dato numerico flotante para valor inicial del rango cuando el campo es numerico</summary>
        public float ItemRangoInicial { get; set; }
        ///<summary>Dato numerico flotante para valor final del rango cuando el campo es numerico</summary>
        public float ItemRangoFinal { get; set; }
        ///<summary>Lista de valores permitidos cuando aplique A,B,C,D.../1,2,3,4.../ITEM1,ITEM2,ITEM3...</summary>
        public String ItemValorPermitido { get; set; }
        #endregion
    }
    #endregion
    #region TmpListCondicion: Estructura temporal para condiciones seleccionadas
    /// <summary>
    /// <para>Estructura temporal para condiciones seleccionadas</para>
    /// </summary>
    public class TmpListCondicion
    {
        #region Datos
        /// <summary>Referencia algun Objeto cuando sea requerido</summary>
        public FrameworkElement RefObjeto { get; set; }
        ///<summary>Llave unica del registro</summary>
        public String ItemllaveRegistro { get; set; }
        ///<summary>Secuencial numerico para organizar orden vista de elementos</summary>
        public int ItemOrdenVista { get; set; }
        ///<summary>Nombre unico del item o campo que se esta manipulando Ejemplo: Sia_nroide_usua/A,B,C,D.../1,2,3,4.../ITEM1,ITEM2,ITEM3...</summary>
        public String ItemNombre { get; set; }
        ///<summary>Condicional para la expresion: "!="=Diferentre "Like"=Contiene...</summary>
        public String Condicional { get; set; }
        ///<summary>Valor para filtro de la condicion</summary>
        public String ValorCondicion { get; set; }
        ///<summary>Conector logico "AND" "OR"..., segun el lenguaje</summary>
        public String ConectorLogico { get; set; }
        ///<summary>Expresion evaluable segun el lenguaje ejemplo: (CampoNombre = 'FREDDY' AND CampoApellido ='NAVARRO')</summary>
        public String ExpresionEvaluable { get; set; }
        #endregion
    }
    #endregion
    #region TmpListaComboBox: Clase para ComboBox Listas Desplegables
    /// <summary>
    /// <para>Temporal para gestion en la vista del ComboBox</para>
    /// </summary>
    public class TmpListaComboBox
    {
        ///<summary>Llave unica String del registro iniciando en cero: 0,1,2,3...</summary>
        public string IdIndice { get; set; }
        ///<summary>Titulo para vista en pantalla del item o campo</summary>
        public string NombreOpcion { get; set; }
        ///<summary>Nombre interno del item o campo que se devuelve como seleccion del cobobox</summary>
        public string ValorSeleccion { get; set; } 
    }
    #endregion
    #region TmpListaSeleccion: Temporal para lista de items o campos seleccionados
    /// <summary>
    /// <para>Temporal para lista de items o campos seleccionados para referencia</para>
    /// </summary>
    public class TmpListaSeleccion
    {
        ///<summary>Llave unica String del registro iniciando en cero: 0,1,2,3...</summary>
        public string IdIndice { get; set; }
        ///<summary>Nombre interno del item o campo seleccionado</summary>
        public string ValorSeleccion { get; set; }
        ///<summary>Descripcion del item o campo seleccionado cuando sea necesario</summary>
        public string NombreSeleccion { get; set; }
    }
    #endregion
    //----------------------------------------------------------------------
    // TEMPORAL GENERAL PARA DEVOLVER RESUMEN INFORMES 
    //----------------------------------------------------------------------
    #region TmpResumen: Estructura para vista informes 
    /// <summary>
    /// <para>Estructura para vista informes</para>
    /// </summary>
    public class ClasseTmpResumen
    {
        #region Datos
        ///<summary>llave unica registro</summary>
        public String LlaveRegistro { get; set; }
        public String GrupoIdRegistro { get; set; }     // Identificador para un grupo de registros
        public String GrupoTitulo { get; set; }         // Titulo del grupo 
        public String GrupoTipo { get; set; }           // Tipo grupo para alguna utilidad
        public int GrupoOrdenVista { get; set; }        // Orden visualizacion grupo
        public String RegistroCodigo { get; set; }      // Codigo del registro
        public String RegistroCodigo1 { get; set; }
        public String RegistroCodigo2 { get; set; }
        public String RegistroCodigo3 { get; set; }
        public String RegistroTitulo { get; set; }      // Titulo del Registro
        public String RegistroTitulo1 { get; set; }     // Titulos auxilares
        public String RegistroTitulo2 { get; set; }     // Titulos auxilares
        public String RegistroTitulo3 { get; set; }     // Titulos auxilares
        public int RegistroOrdenVista { get; set; }     // Orden visualizacion del registro
        public String Parametro1 { get; set; }     // Parametros o valores que se puedan usar en validacion
        public String Parametro2 { get; set; }
        public String Parametro3 { get; set; }
        public String Parametro4 { get; set; }
        public String Texto1 { get; set; }
        public String Texto2 { get; set; }
        public String Texto3 { get; set; }
        public String Texto4 { get; set; }
        public String Texto5 { get; set; }
        public String Texto6 { get; set; }
        public String Texto7 { get; set; }
        public String Texto8 { get; set; }
        public String Texto9 { get; set; }
        public String Texto10 { get; set; }
        public String Texto11 { get; set; }
        public String Texto12 { get; set; }
        public String Texto13 { get; set; }
        public String Texto14 { get; set; }
        public String Texto15 { get; set; }
        public String Texto16 { get; set; }
        public String Texto17 { get; set; }
        public String Texto18 { get; set; }
        public String Texto19 { get; set; }
        public String Texto20 { get; set; }
        public String Texto21 { get; set; }
        public String Texto22 { get; set; }
        public String Texto23 { get; set; }
        public String Texto24 { get; set; }
        public String Texto25 { get; set; }
        public String Texto26 { get; set; }
        public String Texto27 { get; set; }
        public String Texto28 { get; set; }
        public String Texto29 { get; set; }
        public String Texto30 { get; set; }
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }
        public DateTime Fecha3 { get; set; }
        public DateTime Fecha4 { get; set; }
        public DateTime Fecha5 { get; set; }
        public DateTime Fecha6 { get; set; }
        public DateTime Fecha7 { get; set; }
        public DateTime Fecha8 { get; set; }
        public DateTime Fecha9 { get; set; }
        public DateTime Fecha10 { get; set; }
        public DateTime Fecha11 { get; set; }
        public DateTime Fecha12 { get; set; }
        public DateTime Fecha13 { get; set; }
        public DateTime Fecha14 { get; set; }
        public DateTime Fecha15 { get; set; }
        public int Total1 { get; set; }
        public int Total2 { get; set; }
        public int Total3 { get; set; }
        public int Total4 { get; set; }
        public int Total5 { get; set; }
        public int Total6 { get; set; }
        public int Total7 { get; set; }
        public int Total8 { get; set; }
        public int Total9 { get; set; }
        public int Total10 { get; set; }
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public int Valor3 { get; set; }
        public int Valor4 { get; set; }
        public int Valor5 { get; set; }
        public int Valor6 { get; set; }
        public int Valor7 { get; set; }
        public int Valor8 { get; set; }
        public int Valor9 { get; set; }
        public int Valor10 { get; set; }
        public int Valor11 { get; set; }
        public int Valor12 { get; set; }
        public int Valor13 { get; set; }
        public int Valor14 { get; set; }
        public int Valor15 { get; set; }
        public int Valor16 { get; set; }
        public int Valor17 { get; set; }
        public int Valor18 { get; set; }
        public int Valor19 { get; set; }
        public int Valor20 { get; set; }
        public int Valor21 { get; set; }
        public int Valor23 { get; set; }
        public int Valor24 { get; set; }
        public int Valor25 { get; set; }
        public int Valor26 { get; set; }
        public int Valor27 { get; set; }
        public int Valor28 { get; set; }
        public int Valor29 { get; set; }
        public int Valor30 { get; set; }
        public int Valor31 { get; set; }
        public int Valor32 { get; set; }
        public int Valor33 { get; set; }
        public int Valor34 { get; set; }
        public int Valor35 { get; set; }
        public int Grupo1 { get; set; }
        public int Grupo2 { get; set; }
        public int Grupo3 { get; set; }
        public int Grupo4 { get; set; }
        public int Grupo5 { get; set; }
        public int Grupo6 { get; set; }
        public int Grupo7 { get; set; }
        public int Grupo8 { get; set; }
        public int Grupo9 { get; set; }
        public int Grupo10 { get; set; }
        public int Grupo11 { get; set; }
        public int Grupo12 { get; set; }
        public int Grupo13 { get; set; }
        public int Grupo14 { get; set; }
        public int Grupo15 { get; set; }
        public int Grupo16 { get; set; }
        public int Grupo17 { get; set; }
        public int Grupo18 { get; set; }
        public int Grupo19 { get; set; }
        public int Grupo20 { get; set; }
        public int Grupo21 { get; set; }
        public int Grupo22 { get; set; }
        public int Grupo23 { get; set; }
        public int Grupo24 { get; set; }
        public int Grupo25 { get; set; }
        public int Grupo26 { get; set; }
        public int Grupo27 { get; set; }
        public int Grupo28 { get; set; }
        public int Grupo29 { get; set; }
        public int Grupo30 { get; set; }
        public int TotalGrupo1 { get; set; }
        public int TotalGrupo2 { get; set; }
        public int TotalGrupo3 { get; set; }
        public int TotalGrupo4 { get; set; }
        public int TotalGrupo5 { get; set; }
        public int TotalGrupo6 { get; set; }
        public Decimal Decimal1 { get; set; }
        public Decimal Decimal2 { get; set; }
        public Decimal Decimal3 { get; set; }
        public Decimal Decimal4 { get; set; }
        public Decimal Decimal5 { get; set; }
        public Decimal Decimal6 { get; set; }
        public Decimal Decimal7 { get; set; }
        public Decimal Decimal8 { get; set; }
        public Decimal Decimal9 { get; set; }
        public Decimal Decimal10 { get; set; }
        #endregion
    }
    #endregion
    //----------------------------------------------------------------------
    // CLASES PARA EL GESTOR DE HISTORIAS CLINICAS
    //----------------------------------------------------------------------
    #region OBJETOS ClassXmlPropObjeto: Clase para cargar propiedades de Objetos
    /// <summary>
    /// <para>ClassXmlPropObjeto: Clase para cargar propiedades de Objetos (Gestion formatos H.C.)</para>
    /// </summary>
    public class ClassXmlPropObjeto
    {
        #region Clase
        ///----------------------------------------------
        // Referencias a objeto (son Propiedades para manejo interno)
        ///----------------------------------------------
        public FrameworkElement RefObjeto { get; set; }             // Referencia a la instancia del Objeto en la vista
        public FrameworkElement RefContenedorObjeto { get; set; }   // Referencia a al contenedor del objeto (para Paginas, Zonas y GrupoBox)
        public int IntTabIndex { get; set; }                        // Orden de tabulacion tipo numerico auxiliar para reorganizar la lista
        public int IntIndexAux { get; set; }                        // Indice auxiliar para reorganizar la lista y otras tareas
        //- Para las acciones de deshacer y rehacer
        public String Accion { get; set; }                          // "ELIMINADO", "ADICIONADO","MODIFICADO"
        public int IdAccion { get; set; }
        ///----------------------------------------------
        // Propiedades Básicas
        ///----------------------------------------------
        #region Propiedades Básicas
        public String Name { get; set; }
        public String NameContenedor { get; set; }          // Nombre del objeto contenedor dentro de Paginas, Zonas o GrupoBox
        public String Titulo { get; set; }
        public String ToolTip { get; set; }
        public String TituloVisible { get; set; }           // (True/False) Titulo Visible por defecto
        public String TipoObjeto { get; set; }              // Tipo objeto: Pagina,Zona,TextBox,ComboBox,Calendario,Hora,Imagen,Odontograma,Listbox...(independiene de su ClaseBase real)
        public String ClaseBase { get; set; }
        public String TipoControl { get; set; }             // BLIQ = Balance liqidos MEDI=Medicamentos SERV=servicios EVOL=Evoluciones NENF=Notas enfermeria ...
        public String SeccionCodigo { get; set; }           // Codigo Seccion del formato a la cual esta asociada el objeto 
        public String Parent { get; set; }                  // Objeto contenedor del nivel superior al cual pertenece el objeto
        public String OrdenVista { get; set; }              // Orden vizulizacion del objeto dentro de la seccion 
        public String TabIndex { get; set; }                // Orden de tabulacion o vista
        public String Pagina { get; set; }                  // Numero de la pagina donde esta anclado el objeto 
        public String CambiarTabs { get; set; }             // Para Saber si se incluye en lista visual para cambiar orden de visualizacion y tabs (manejo interno) 
        public String Focusable { get; set; }
        public String IsEnabled { get; set; }
        public String Visibility { get; set; }
        #endregion
        ///----------------------------------------------
        // Propiedades Apariencia
        ///----------------------------------------------
        #region Propiedades Apariencia
        public String VerticalAlignment { get; set; }
        public String HorizontalAlignment { get; set; }
        public String Style { get; set; }
        public String Margin { get; set; }
        public String Border { get; set; }
        public String Foreground { get; set; }
        public String BorderBrush { get; set; }
        public String Background { get; set; }
        public String Height { get; set; }
        public String Width { get; set; }
        public String Top { get; set; }
        public String Left { get; set; }
        public String FontFamily { get; set; }
        public String FontStyle { get; set; }
        public String FontWeight { get; set; }
        public String Decorations { get; set; }             // Decoracion del texto Font
        public String FontSize { get; set; }
        public String AlineacionTexto { get; set; }
        public String Orientacion { get; set; }
        public String Angulo { get; set; }
        #endregion
        ///----------------------------------------------
        // Propiedades Datos
        ///----------------------------------------------
        #region Propiedades Datos
        /// <summary>
        /// <para>Binding o referencia al campo asociado al archivo maestro historico eventos en</para>
        /// <para>Base de datos para guardar dato digitado ejemplo: HCL_VAL015_HCNU</para>
        /// </summary>
        public String Binding { get; set; }
        /// <summary>Referencia al campo descripcion relacionado con el objeto en tipos: TextBoxRel ComboBox y otros</summary>
        public String BindingDescripcion { get; set; }
        /// <summary>Nombre archivo maestro historico de eventos para  origen del campo o destino del dato al guardar</summary>
        public String BindingTabla { get; set; }
        /// <summary>Valor por defecto que toma el campo al Adicionar registro</summary>
        public String ValorDefault { get; set; }
        /// <summary>Indice de un objeto cuando es miembro de un Grupo (Radiobutton GroupChk ...)</summary>
        public String Indice { get; set; }
        /// <summary>Numero de opciones cuando es un combobox, radiobutton</summary>
        public String TotalItems { get; set; }
        /// <summary>Nombre de la variable que representa el campo en codigo fuente compilado (para manejo interno)</summary>
        public String NombreVariable { get; set; }
        //--------------------------------------------------
        /// <summary>Referencia a la variable pubica asociada con el objeto de captura de datos ejemplo: USUARIO_PERTENENCIA_ETNICA</summary>
        public String VariablePublica { get; set; }
        /// <summary>Tipo Valor gestion Variable Publica (cuando aplique)/N=No Aplica/0=Campo solo captura de datos/1= Posicion elemento1/2=Posicion elemento2 /3...</summary>
        public String VarGestPosVector { get; set; }
        //--------------------------------------------------
        /// <summary>Lista de objetos tipo campos referenciados por nombre variable interna para procesos de suma promedio y otros</summary>
        public String RefObjProceso { get; set; }
        /// <summary>Lista de objetos o valores auxiliares para multiproposito</summary>
        public String RefObjActList { get; set; }
        //--------------------------------------------------
        /// <summary>Registro temporal de Referencia a Propiedades de la variable publica asociada al objeto</summary>
        public ClassXmlPropVariablePublica PropVarPublica { get; set; }
        /// <summary>Tipo Campo para Reporte: 1= Solo Reporte 2=Reporte y Estadisticas 3= Solo Estadisticas 4 =Ninguno</summary>
        public String CampoReporte { get; set; }
        /// <summary>Tipo dato que captura el objeto TEXTO,FECHA,MEMO,NUMERICO,FLOTANTE (para manejo interno) </summary>
        public String TipoDato { get; set; }
        /// <summary>COLECCION,TABLA,CAPTURA,VARIABLEPUBLICA (para manejo interno)</summary>
        public String TipoOrigenDatos { get; set; }
        /// <summary>Origen datos Tablas relacion Diagnosticos, Usuarios,Pacientes,Profesionales --> MEDI,SERV,EVOL,NENF,SVIT,INCO,DIAG,BLIQ...</summary>
        public String TablaOrigen { get; set; }
        /// <summary>Codigo de la platilla tipo etiqueta de datos relacionada con el objeto</summary>
        public String CodigoEtiqueta { get; set; }
        /// <summary>Rango inicial para captura de datos tipo numero o flotante</summary>
        public String RangoInicial { get; set; }
        /// <summary>Rango final para captura de datos tipo numero o flotante</summary>
        public String RangoFinal { get; set; }
        /// <summary>Valor campo es requerido SI/NO: True=Campo es requerido False=Campo no es requerido</summary>
        public String IsRequerido { get; set; }
        /// <summary>Valor por defecto cuando es campo tipo fecha: 1=Valor Vacio 2=Fecha actual del sistema</summary>
        public String FechaDefault { get; set; }
        /// <summary>Valor por defecto cuando es campo tipo hora: 1=Hora vacia 2=Hora Actual del sistema.</summary>
        public String HoraDefault { get; set; }
        /// <summary>
        /// <para>Para gestion en multi sesiones, (True/False) True = si el registro esta confirmado,</para>
        /// <para>se puede modificar campo mientras este vacio, por defecto (False)</para>
        /// </summary>
        public String SiMultiSet { get; set; }
        /// <summary>El dato es solo lectura, activa o inactiva actualizar variable publica actualizable (variable no protegida)</summary>
        public String IsReadOnly { get; set; }

        //- Propiedades Validar Envio de datos a impresora
        /// <summary>1,2,3 validar si se envian a impresion valores digitados 1=Enviar todos,2=Enviar Solo valores lista, 3=Excluir valores de lista </summary>
        public String PrnSiValidar { get; set; }
        /// <summary>lista posibles valores por defecto para Validar envio a reporte impreso (lista separada por comas) ejemplo: TI,CC,RC..</summary>
        public String PrnValorDefault { get; set; }
        /// <summary>Valor de ejemplo para probar vista previa del reporte impreso</summary>
        public String PrnValorPreView { get; set; }
        /// <summary>"1"=Ver el titulo en impresión,"2"=No mostrar titulo en impresión</summary>
        public String PrnMostrarTitulo { get; set; }

        //- Propiedades para actualizar Rips y Resolucion 4505
        /// <summary>Tabla o Dato Referenciado para actualizar RIPS AC,AP... o Resolucion 4505 y otros</summary>
        public String RefVarDatosTipo { get; set; }
        /// <summary>Campo de la referencia a tabla RefArchivoTipo que sera acutaulizado (ejm: el campo14 de la 4505)</summary>
        public String RefVarDatosCampo { get; set; }
        #endregion
        ///----------------------------------------------
        // Propiedades Imagenes o archivos de recursos 
        ///----------------------------------------------
        #region Propiedades Imagenes o archivos de recursos
        public String RecursoArchivoTipo { get; set; }      // Tipo archivo IMAGEN,VIDEO,DOC,XLS,PDF...
        public String RecursoArchivoCodigo { get; set; }    // Codigo del recurso en la galeria de recursos
        public String RecursoArchivoUri { get; set; }       // Ruta de la imagen en galeria
        public String RecursoArchivoNombre { get; set; }    // Nombre del archivo de imagen 
        public String Stretch { get; set; }                 // Ajuste de la imagen dentro del contenedor
        public String StretchDirection { get; set; }        // Direccion del ajuste de la imagen dentro del contenedor
        #endregion
        ///----------------------------------------------
        // Propiedades Varias
        ///----------------------------------------------
        #region Propiedades Varias
        public String SiValorCalculado { get; set; }
        public String SiMostrarEnMuro { get; set; }         // True/False Para generar imagen o vista de variable en muro
        public String SiFiltroBusqueda { get; set; }        // True/False Incluir en metadatos para filtro busquedas desde muro
        public String SiImprimir { get; set; }              // True/False Si enviar a imprimir objeto o pagina (solo aplica a paginas por ahora)
        // Propiedades solo para Radiobutton grupo
        public String RadioButtonGroupName { get; set; }    // (GroupName) Nombre del Grupo que asocia varios Radiobutton para una unica respuesta
        // Control Nivel, Tree Objetos y Estado del objeto (solo para gestion interna)
        public String Navegador { get; set; }               // Contenedor donde se carga la plantilla para ser mostrada (ESCRITORIO/ETIQUETA)
        public String CodigoPlantilla { get; set; }         // Plantilla a la cual pertenece el objeto
        public int ObjetoNivel { get; set; }             // 1=Pagina / 2=Zona  / 3=Objetos dentro de Zona / 4=Grupos / 5= Objetos dentro de grupos
        public Double ObjetoPaginaPosVertical { get; set; } // Posicion vertical de la pagina dentro del escritorio (para la busqueda acercada con salto escritorio)
        public Double ObjetoPaginaPosHorizontal { get; set; } // Posicion Horizontal de la pagina dentro del escritorio (para la busqueda acercada con salto escritorio)
        public String ObjetoParentPagina { get; set; }
        public String ObjetoParentZona { get; set; }
        public String ObjetoParentGrupo { get; set; }
        public String ObjetoEstado { get; set; }            // para control de eliminacion Rehacer o deshacer "ACTIVO","ELIMINADO"
        public String ObjetoModo { get; set; }              // Campo para saber el modo de ejecucion del objeto 
        #endregion
        //--------------------------------------------------------
        // TipoControl: Control para captura de signos vitales medicamentos y otros
        //--------------------------------------------------------
        #region Informacion Varias
        //  LIQA = Balance liqidos admisnitrados 
        //  LIQE = Balance liqidos eliminados
        //  MEDI = Medicamentos intrahospitalarios/recetas
        //  SERV = Servicios intrahospitalarios
        //  EVOL = Evoluciones 
        //  NENF = Notas enfermeria
        //  SVIT = Signos Vitales
        //  INCO = Interconsultas
        //  DIAG = Diagnosticos
        //  MANT = Tarifario Servicios
        #endregion
        //--------------------------------------------------------
        // ObjetoModo: Modos de ejecucion de objetos
        //--------------------------------------------------------
        // "EDICION-ESCRITORIO"     => Modo diseño de la plantilla (objetos modificables)
        // "CAPTURA-ESCRITORIO"     => objetos en escritorio en modo captura de datos (objetos no son modificables)
        // "CAPTURA-ETIQUETA"       => objetos dentro de capa etiquetas en modo captura (objetos no son modificables)
        // "CAPTURA-EDT-ESCRITORIO" => objetos tipo etiquetas agregados en escritorio (objetos agregados en modo captura y modificables)
        // "CAPTURA-EDT-ETIQUETA"   => Objetos tipo etiquetas (objetos agregados en modo captura  y modificables)
        #endregion
    }
    #endregion
    #region DATOS ClassXmlPropDatos: Clase para cargar Datos diligenciados en modo captura
    /// <summary>
    /// <para>Clase para cargar Datos diligenciados en modo gestion captura y guardados en base de datos (Gestion formatos H.C.)</para>
    /// </summary>
    public class ClassXmlPropDatos
    {
        #region Clase
        // Referencia a objeto
        public FrameworkElement RefObjeto { get; set; }     // Referencia a la instancia del Objeto en la vista

        // Propiedades llave grupo registros 
        public String IgGrupoRegistro { get; set; }         // IG del grupo, puede ser el IG del Escritorio o Nombre del objeto que lo asocia como Etiqueta de datos
        public String Navegador { get; set; }               // ESCRITORIO/ETIQUETA: para saber por defecto donde esta el objeto que relaciona el dato
        public String CodigoPlantilla { get; set; }         // Plantilla a la cual pertenece el objeto
        // Propiedades Básicas
        public String Name { get; set; }                    // Nombre del objeto que relaciona el dato como campo
        public String Titulo { get; set; }
        public String Parent { get; set; }                  // Objeto contenedor del nivel superior al cual pertenece el objeto
        public String TipoObjeto { get; set; }              // Tipo objeto: Pagina,Zona,TextBox,ComboBox,Calendario,Hora,Imagen,Odontograma,Listbox...(independiene de su ClaseBase real)
        public String ClaseBase { get; set; }               // clase base del objeto que recibe el dato
        public String TipoControl { get; set; }             // BLIQ = Balance liqidos MEDI=Medicamentos SERV=servicios EVOL=Evoluciones NENF=Notas enfermeria ...
        public String OrdenVista { get; set; }              // Orden vizulizacion del objeto dentro de la seccion 
        public String SeccionCodigo { get; set; }           // Codigo Seccion del formato a la cual esta asociada el objeto 
        public String SeccionOrdenVista { get; set; }       // orden vizualizacion de la seccion en informes impresos
        public String SeccionNombre { get; set; }           // Nombre o descripcion de seccion en informes impresos
        public String SiFiltroBusqueda { get; set; }        // True/False Incluir en metadatos para filtro busquedas desde muro

        // Propiedades Datos
        public String Binding { get; set; }                 // Campo Binding asociado en la Base de datos
        public String BindingDescripcion { get; set; }      // Referencia al campo descripcion relacionado con el objeto en tipos: TextBoxRel ComboBox y otros
        public String BindingTabla { get; set; }            // Tabla origen dek campo Binding asociado en la Base de datos
        public String ValorDefault { get; set; }            // Valor por defecto que toma el campo al Adicionar registro (puede venir de una lista)
        public String Valor { get; set; }                   // Valor guardado del registro (puede ser numeros, texto, fechas y mas...)
        public String ValorAux { get; set; }                // Valor Auxiliar para algun proposito
        public String ValorDescripcion { get; set; }        // Descripcion del dato Valor, cuando el origen es una relacion tabla o un combobox 
        public String Indice { get; set; }                  // Indice de un objeto cuando es miembro de un Grupo (Radiobutton GroupChk ...)
        public String CampoReporte { get; set; }            // 1= Solo Reporte 2=Reporte y Estadisticas 3= Solo Estadisticas 4 =Ninguno
        public String TipoDato { get; set; }                // Tipo dato que captura el objeto TEXTO,FECHA,MEMO,NUMERICO,FLOTANTE (para manejo interno) 
        public String TipoOrigenDatos { get; set; }         // COLECCION,TABLA,CAPTURA (para manejo interno) 
        public String TablaOrigen { get; set; }             // Tabla origen del campo o destino del dato al guardar
        public String IdRegistro { get; set; }              // se utiliz como llave el Nombre de la zona donde esta el objeto que referencia el dato
        public String NombreVariable { get; set; }          // Nombre de la variable que representa el campo en codigo fuente compilado
        public String VariablePublica { get; set; }         // Referencia a la variable pubica asociada con el objeto de captura de datos
        // Propiedades Imagenes o archivos de recursos 
        public String RecursoArchivoTipo { get; set; }      // Tipo archivo IMAGEN,VIDEO,DOC,XLS,PDF...
        public String RecursoArchivoCodigo { get; set; }    // Codigo del recurso en la galeria de recursos
        public String RecursoArchivoUri { get; set; }       // Ruta de la imagen en galeria
        public String RecursoArchivoNombre { get; set; }    // Nombre del archivo de imagen,video,doc,pdf... 
        #endregion
    }
    #endregion
    #region ClassXmlPropVariablePublica: Clase para gestion Variables publicas en datos
    /// <summary>
    /// <para>Clase para gestion Variables publicas referenciadas en captura de datos</para>
    /// </summary>
    public class ClassXmlPropVariablePublica
    {
        #region Propiedades Variable publica
        /// <summary>
        /// Codigo grupo, al cual se asocia la variable
        /// </summary>
        public String Hcl_secgru_hcgv { get; set; }
        /// <summary>
        /// Numero para orden vista en gestion impresión en formatos dentro del grupo al que pertenece
        /// </summary>
        public int Hcl_ordvis_hcvr { get; set; }
        /// <summary>
        /// Titulo de la variable
        /// </summary>
        public String Hcl_titulo_hcvr { get; set; }
        /// <summary>
        /// Descripción larga de la variable
        /// </summary>
        public String Hcl_descri_hcvr { get; set; }
        /// <summary>
        /// Nombre unico identificador de variable ejemplo: VACUNACION_NIÑO_DPT_DOSIS, JOVEN_PLANIFICACION_SI_NO
        /// </summary>
        public String Hcl_nomvar_hcvr { get; set; }
        /// <summary>
        /// Tipo valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=Decimal
        /// </summary>
        public String Hcl_tipval_hcvr { get; set; }
        /// <summary>
        /// Valores permitidos para el campo
        /// </summary>
        public String Hcl_valper_hcvr { get; set; }
        /// <summary>
        /// Valor por defecto al iniciar captura de datos en la variable
        /// </summary>
        public String Hcl_valvar_hcvr { get; set; }
        /// <summary>
        /// <para>Campo digitable: 1=Modificable 2=Solo modficable desde procesos para variables resumen y otros, 3=Valor protegido.</para>
        /// </summary>
        public String Hcl_camdig_hcvr { get; set; }
        /// <summary>
        /// Rango inicial general del valor digitable
        /// </summary>
        public String Hcl_ranini_hcvr { get; set; }
        /// <summary>
        /// Rango final general del valor digitable
        /// </summary>
        public String Hcl_ranfin_hcvr { get; set; }
        /// <summary>
        /// Rango inicial valores normales dentro del rango general (para gestion posibles alarmas)
        /// </summary>
        public String Hcl_raninr_hcvr { get; set; }
        /// <summary>
        /// Rango final valores normales dentro del rango general (para gestion posibles alarmas)
        /// </summary>
        public String Hcl_ranfnr_hcvr { get; set; }
        /// <summary>
        /// <para>Nivel gestion variable (1,2,3) : 1= Unica  permanente en historia</para>
        /// <para>clinica, ejemplo: Numero admision activa 2=Unica tmporal en</para>
        /// <para>evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable</para>
        /// <para>temporal  gestion evento, ejemplo: resultado de laboratorio</para>
        /// </summary>
        public String Hcl_nivvar_hcvr { get; set; }
        /// <summary>
        /// <para>Evaluar gestion de datos y notifcar alarma para valores referenciados</para>
        /// <para>como anormales: 1= Variable normal 2=Genera notificacion cuando hay valores anormales</para>
        /// </summary>
        public String Hcl_sistem_hcvr { get; set; }
        /// <summary>
        /// <para>Modo captura de datos: 1=Variable simple captura de datos 2=Resumen general todas las variables</para>
        /// <para>del grupo 3=Resumen variables del grupo que contengan datos</para>
        /// </summary>
        public String Hcl_modoca_hcvr { get; set; }
        /// <summary>
        /// <para>Incluir valor capturado en variable resumen: 1=Incluir en Variables resumen 2= No incluir en variables resumen</para>
        /// </summary>
        public String Hcl_resume_hcvr { get; set; }
        /// <summary>
        /// <para>1=Incluir solo lista variables en resumen 2= No incluir lista variables en resumen 3=No Aplica</para>
        /// </summary>
        public String Hcl_siresu_hcvr { get; set; }
        /// <summary>
        /// <para>Lista separada por punto y comas para Nombre de variables que se tendran en cuenta en el resumen</para>
        /// </summary>
        public String Hcl_vresum_hcvr { get; set; }
        /// <summary>
        /// <para>Saber si Incluir valor en resumen: 1= Incluir en Resumen general y de Hallazgos 2=Solo General</para>
        /// </summary>
        public String Hcl_SiValorResumen { get; set; }
        /// <summary>
        /// <para>Valor digitado en formato para gestion resumen</para>
        /// </summary>
        public String Hcl_ValorDigitado { get; set; }
        /// <summary>
        /// <para>Vigencia en tiempo de la variable: 1= Indefinido 2=Dias 3=Meses 4 =Años</para>
        /// </summary>
        public String Hcl_tvigen_hcvr { get; set; }
        /// <summary>
        /// <para>Cantidad de tiempo según vigencia de la variable (por defecto cero cuando es indefinido), aplica solo cuando es diferente de indefinido</para>
        /// </summary>
        public int Hcl_vvigen_hcvr { get; set; }
        //--------------------------------------------------
        // gestion Pila (cuando aplique)
        //--------------------------------------------------
        /// <summary>
        /// <para>Variable es tipo pila (array) : 1= La variable es tipo Array 2=No es tipo array (valor por defecto)</para>
        /// </summary>
        public String Hcl_varray_hcvr { get; set; }
        /// <summary>
        /// <para>Tamaño en lista de valores que puede contener la pila (valores de la variable en diferentes tiempos)</para>
        /// </summary>
        public int Hcl_tmaray_hcvr { get; set; }
        /// <summary>
        /// <para>Valor en Historico texto o valores pila (pila -> cuando aplica separados por Asteriscos (*)) cuando es pila posiciones ejm: 121*4502*2566*-0-*-0-</para>
        /// </summary>
        public String Hcl_ValorHistTexto { get; set; }
        /// <summary>
        /// <para>Se genero el valor String desde la pila: 1=Si/2=No</para>
        /// </summary>
        public String Hcl_SiGenValorHistTexto { get; set; }
        /// <summary>
        /// <para>Referencia a lista  tipo pila que contiene todos los valores elementos</para>
        /// </summary>
        public List<ClassXmlPilaVariablePublica> Pila { get; set; }
        //--------------------------------------------------
        /// <summary>
        /// Variable protegida del sistema: 1= Protegida 2=Variable no protegida
        /// </summary>
        public String Hcl_sisvar_hcvr { get; set; }
        /// <summary>
        /// Estado edicion Variable: 1= Sin Modificar 2= Modificado
        /// </summary>
        public String EstadoEdicion { get; set; }
        /// <summary>
        /// Estado de registros  : 1= Activo 2= Inactivo
        /// </summary>
        public String Sis_estreg_esrg { get; set; }
        #endregion
    }
    #endregion
    #region ClassXmlPilaVariablePublica: Clase lista valores pila variable publica
    /// <summary>
    /// <para>Clase lista valores que contiene una pila dentro de una variable publica</para>
    /// </summary>
    public class ClassXmlPilaVariablePublica
    {
        #region Datos
        /// <summary>
        /// Posision del dato en la pila
        /// </summary>
        public int Posicion { get; set; }
        /// <summary>
        /// Dato contenido en la pila
        /// </summary>
        public String Dato { get; set; }
        /// <summary>
        /// Estado del Dato 1=Sin Modificar 2=Modificado
        /// </summary>
        public String Estado { get; set; }
        #endregion
    }
    #endregion
    //----------------------------------------------------------------------
    // Clases para gestion respuestas Servicios Dian
    //----------------------------------------------------------------------
    #region DianResponse: Respuesta del Response de consulta Documentos a la DIAN
    /// <summary>
    /// <para>Recoge los  valores respuesta cada campo del Response consulta Documento en la DIAN</para>
    /// </summary>
    public class DianResponse
    {
        /// <summary>
        /// Tipo response cargado: DocumentKey=Resultados envio documentos en modo producción  
        /// /ZipKey=Response inicial para obtener el ZipKey de consulta 
        /// /NA=Response no valido como gestion documento en DIAN
        /// </summary>
        public string TipoResponse = "DocumentKey";
        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/ErrorMessage</para>
        /// <para>Texto lista Mensajes de error: Entrega una descripción con cada una 
        /// de las validaciones fallidas o con obsevaciones</para>
        /// </summary> 
        public string ErrorMessage { get; set; } = "NA";

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/IsValid</para>
        /// <para>indica si el archivo enviado es validado con existo o tiene errores(true/false)</para>
        /// </summary>
        public string IsValid { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/StatusCode</para>
        /// <para>Codificación del estado de procesamiento:</para>
        /// <para>00 = Procesado Corectamente </para>
        /// <para>66 = NSU no encontrado </para>
        /// <para>90 = TrackId no encontrado </para>
        /// <para>99 = validaciones contienen errores en campos mandatorios</para>
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/StatusDescription</para>
        /// <para>La descripción del estado: 00 = Procesado Corectamente 66= NSU no encontrado 90 = TrackId no encontrado 
        /// 99 = validaciones contienen errores en campos mandatorios.</para>
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/StatusMessage</para>
        /// <para>Entrega una descripción del error de cada una de la vaidciones iniciales de estados. 
        /// Sino hay errores no entrega descripción.</para>
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/XmlBase64Bytes</para>
        /// <para>Entrega el UBL correspondiente al ApplicationResponse con la respuesta oficial del la DIAN en forma estructurada en base64.</para>
        /// </summary>
        public string XmlBase64Bytes { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/XmlBytes</para>
        /// <para>No esta definida claramente la finalidad y función, devuelve true/fslse.</para>
        /// </summary>
        public string XmlBytes { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/XmlDocumentKey</para>
        /// <para>TrackId o CUFE/CUDE del documento procesado.</para>
        /// </summary>
        public string XmlDocumentKey { get; set; }

        /// <summary>
        /// <para>Envelope/Body/GetStatusZipResponse/GetStatusZipResult/DianResponse/XmlFileName</para>
        /// <para>Nombre del archivo UBL procesado, ejemplo: fv08240046880002000000001.zip</para>
        /// </summary>
        public string XmlFileName { get; set; }

        /// <summary>
        /// <para>Envelope/Body/SendTestSetAsyncResponse/SendTestSetAsyncResult/ZipKey</para>
        /// <para>Nombre llave para consultar resultados de validacion docuemntos cuando esta activo el modo Set de Pruebas</para>
        /// </summary>
        public string ZipKey { get; set; } = "NA";

        /// <summary>
        /// <para>C01=El Servicio DIAN no respondio</para>
        /// <para>C02=Error de conexión Internet</para>
        /// <para>P01=Sin Enviar a DIAN</para>
        /// <para>R01=Aceptada con Exito  en DIAN</para>
        /// <para>R02=Rechazada DIAN errores en Validación</para>
        /// <para>R03=Enviado y Pendiente validación en DIAN</para>
        /// </summary>
        public string EstadoGestion { get; set; } = "P01";

        /// <summary>
        /// <para>Fecha de Generación de la respuesta</para>
        /// </summary>
        public DateTime DateTimeCreated { get; set; } = DateTime.Parse("01/01/0001");

    }
    #endregion DianResponseEnvio
}

using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    #region SIS_Interface: Interface para devolver id registro seleccionado desde Browser tablas
    /// <summary>
    /// <para>devolver id registro seleccionado desde Browser tablas</para>
    /// </summary>
    public interface SIS_Interface 
    {
        //------------------------------------------------
        // fcvBuscarRegistro: Para interface Buscar con F2
        //------------------------------------------------
        void fcvBuscarRegistro(string tcrCodigo);
    }
    #endregion
    #region INotificacion: Interface para devolver id registro notificacion, modulo y tipo Notificacion
    /// <summary>
    /// <para>Devolver id registro notificacion, modulo y tipo Notificacion</para>
    /// <para>PARAMETROS:</para>
    /// <para>tcrIdRegNotificacion: Id registro unico en maestro de notificaciones</para>
    /// <para>tcrIdModulo: Módulo al cual se envia notificación:  MSG = Mensajes general SYS: = Grupos mensajes de sistema FCM =Facturacion</para>
    /// <para>tcrTipoNotificacion: Tipo de notificacion: ADM001 = Registro de admisión FCM001 = Autorizacion descuento en caja facturacion</para>
    /// <para>tcrRegEvento: Registro evento que genera la notificacion: puede ser Id del paciente, Numero H.Clinica, Numero admision y otros.</para>
    /// </summary>
    public interface INotificacion : SIS_Interface
    {
        void fcvINotificacion(String tcrIdRegNotificacion, String tcrIdModulo, String tcrTipoNotificacion, String tcrRegEvento);
    }
    #endregion
    #region IGestionNotificacion: Interface para notificacion, Gestiones Browser seleccion y transacciones de pago en efectivo
    /// <summary>
    /// <para>Devolver id registro notificacion, Gestiones Browser seleccion y transacciones de pago en efectivo</para>
    /// </summary>
    public interface IGestionNotificacion : INotificacion
    {
        //------------------------------------------------
        // fcvBuscarRegistro
        //------------------------------------------------
        /// <summary>
        /// <para>Devolver id Gestiones Browser seleccion</para>
        /// </summary>
        //void fcvBuscarRegistro(string tcrCodigo);

        //------------------------------------------------
        // fcvINotificacion
        //------------------------------------------------
        /// <summary>
        /// <para>Devolver id registro notificacion, modulo y tipo Notificacion</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdRegNotificacion: Id registro unico en maestro de notificaciones</para>
        /// <para>tcrIdModulo: Módulo al cual se envia notificación:  MSG = Mensajes general SYS: = Grupos mensajes de sistema FCM =Facturacion</para>
        /// <para>tcrTipoNotificacion: Tipo de notificacion: ADM001 = Registro de admisión FCM001 = Autorizacion descuento en caja facturacion</para>
        /// <para>tcrRegEvento: Registro evento que genera la notificacion: puede ser Id del paciente, Numero H.Clinica, Numero admision y otros.</para>
        /// </summary>
        //void fcvINotificacion(String tcrIdRegNotificacion, String tcrIdModulo, String tcrTipoNotificacion, String tcrRegEvento);

        //------------------------------------------------
        // fcvIGestionTransaccion
        //------------------------------------------------
        /// <summary>
        /// <para>Devolver registros maestro de facturas y detalles en gestion pago en efectivo</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdTransaccionCaja: Id registro transaccion caja generado</para>
        /// <para>tlsSelectFacturas: Lista de facturas afectas en la transaccion</para>
        /// <para>tlsSelectDetallFacturas: Lista de registros detalles servicios asociados a facturas afectadas</para>
        /// </summary>
        void fcvIGestionTransaccion(String tcrIdTransaccionCaja, List<SelectFacturasMaestro> tlsSelectFacturas, List<SelectFacturasDetalles> tlsSelectDetallFacturas);

    }
    #endregion
    #region IAntencionAdmitidos: Interface para ejecutar el metodo finalizar atencion desde Vista H.C
    /// <summary>
    /// <para>Interface para ejecutar metodos en fomularios referenciados desde Vista gestion Historia clinica</para>
    /// </summary>
    public interface IAntencionAdmitidos : SIS_Interface
    {
        bool flgFinalizarAtencion(String tcrCodigoAdmision);
    }
    #endregion
    //------------------------------------------------
    // Controles de Formularios
    //------------------------------------------------
    #region Controles de Formularios
    public class CrtForms  
    {
        //------------------------------------------------
        // Gestion Valores para ComboBox Listas Desplegables
        //------------------------------------------------
        #region Gestion Valores para ComboBox Listas Desplegables
        //------------------------------------------------
        #region clase para ComboBox Listas Desplegables
        public class ListaComboBox
        {
            public ListaComboBox() { }
            public string IdIndice { get; set; }        // Indice en la lista (int)
            public string NombreOpcion { get; set; }    // Descripcion de la opcion
            public string ValorSeleccion { get; set; }  // valor que se lleva Binding
            public string ListaValoresSel { get; set; } // Lista de valores para busqueda
            public int TotalOp { get; set; }            // Cantidad total o maximo valor de opciones
        }
        #endregion
        //------------------------------------------------
        #region Cargar la clase del ComboBox Listas Desplegables
        public static List<ListaComboBox> flsCargarLista(string tcrListaValores, string tcrListaDescripcionOp)
        {
            int lnuTotLista = Funciones.fnuContarElemListaString(",",tcrListaValores);
            int i=0;
            string lcrValorSel = string.Empty;
            string lcrNombreOp = string.Empty;
            List<ListaComboBox> llsLista = new List<ListaComboBox>();

            llsLista.Add(new ListaComboBox() { IdIndice = "0", NombreOpcion = "Seleccione una opción...",
                                               ValorSeleccion = "", ListaValoresSel = tcrListaValores,
                                               TotalOp = lnuTotLista });
            for (i = 1; i <= lnuTotLista; i++)
            {
                //- Valor Seleccion
                lcrValorSel = Funciones.fuxExtraerElemento(i,",", tcrListaValores);
                if (string.IsNullOrEmpty(lcrValorSel)) { lcrValorSel = "OP" + i.ToString().Trim(); }
                //- Titulo
                lcrNombreOp = Funciones.fuxExtraerElemento(i,",", tcrListaDescripcionOp);
                if (string.IsNullOrEmpty(lcrNombreOp)) { lcrNombreOp = "Opcion Seleccion" + i.ToString().Trim(); }

                llsLista.Add(new ListaComboBox() { IdIndice = i.ToString().Trim(), NombreOpcion = lcrValorSel +
                                                " - " + lcrNombreOp, ValorSeleccion = lcrValorSel,
                                                ListaValoresSel = tcrListaValores, TotalOp = lnuTotLista });
            }

            return llsLista;
        }
        #endregion
        #region Cargar la clase del ComboBox Listas Desplegables
        /// <summary>
        /// <para>tcrTipo:</para>
        /// <para>"1" = No Incluye codigo identificador</para>
        /// <para>"2" = Incluye codigo identificador</para>
        /// </summary>
        public static List<ListaComboBox> flsCargarLista(string tcrListaValores, string tcrListaDescripcionOp, String tcrTipo)
        {
            int lnuTotLista = Funciones.fnuContarElemListaString(",", tcrListaValores);
            int i = 0;
            string lcrValorSel = string.Empty;
            string lcrNombreOp = string.Empty;
            List<ListaComboBox> llsLista = new List<ListaComboBox>();

            for (i = 1; i <= lnuTotLista; i++)
            {
                //- Valor Seleccion
                lcrValorSel = Funciones.fuxExtraerElemento(i, ",", tcrListaValores);
                if (string.IsNullOrEmpty(lcrValorSel)) { lcrValorSel = "OP" + i.ToString().Trim(); }
                //- Titulo
                lcrNombreOp = Funciones.fuxExtraerElemento(i, ",", tcrListaDescripcionOp);
                if (string.IsNullOrEmpty(lcrNombreOp)) { lcrNombreOp = "Opcion Seleccion" + i.ToString().Trim(); }

                if (tcrTipo == "2") // incluye identificador
                {
                    llsLista.Add(new ListaComboBox()
                    {
                        IdIndice        = (i - 1).ToString().Trim(),
                        NombreOpcion    = lcrValorSel + " - " + lcrNombreOp,
                        ValorSeleccion  = lcrValorSel,
                        ListaValoresSel = tcrListaValores,
                        TotalOp         = lnuTotLista
                    });
                }
                else 
                {
                    llsLista.Add(new ListaComboBox()
                    {
                        IdIndice        = (i - 1).ToString().Trim(),
                        NombreOpcion    = lcrNombreOp,
                        ValorSeleccion  = lcrValorSel,
                        ListaValoresSel = tcrListaValores,
                        TotalOp         = lnuTotLista
                    });
                }
            }
            return llsLista;
        }
        #endregion
        #region Cargar la clase del ComboBox Listas Desplegables sin mostrar valor seleccion en descripcion
        public static List<ListaComboBox> flsCargarListaEx(string tcrListaValores, string tcrListaDescripcionOp)
        {
            int lnuTotLista = Funciones.fnuContarElemListaString(",", tcrListaValores);
            int i = 0;
            string lcrValorSel = string.Empty;
            string lcrNombreOp = string.Empty;
            List<ListaComboBox> llsLista = new List<ListaComboBox>();

            llsLista.Add(new ListaComboBox()
            {
                IdIndice = "0",
                NombreOpcion = "Seleccione una opción...",
                ValorSeleccion = "",
                ListaValoresSel = tcrListaValores,
                TotalOp = lnuTotLista
            });

            for (i = 1; i <= lnuTotLista; i++)
            {
                //- Valor Seleccion
                lcrValorSel = Funciones.fuxExtraerElemento(i, ",", tcrListaValores);
                if (string.IsNullOrEmpty(lcrValorSel)) { lcrValorSel = "OP" + i.ToString().Trim(); }
                //- Titulo
                lcrNombreOp = Funciones.fuxExtraerElemento(i, ",", tcrListaDescripcionOp);
                if (string.IsNullOrEmpty(lcrNombreOp)) { lcrNombreOp = "Opcion Seleccion" + i.ToString().Trim(); }

                llsLista.Add(new ListaComboBox()
                {
                    IdIndice = i.ToString().Trim(),
                    NombreOpcion = lcrNombreOp,
                    ValorSeleccion = lcrValorSel,
                    ListaValoresSel = tcrListaValores,
                    TotalOp = lnuTotLista
                });
            }

            return llsLista;
        }
        #endregion
        //------------------------------------------------
        #region flsCargarListaComboBox: Cargar la clase del ComboBox Listas Desplegables
        /// <summary>
        /// <para>tcrItemValorSelect: Nombre del campo en la clase (TmpGestionItem -> lista itemas) que se se devolvera</para>
        /// <para>como valor seleccionado ejemplo: "Itemllave"/"ItemAliasSql"/"ItemNombre" </para>
        /// <para>tcrTipo:"1" = No Incluye codigo identificador "2" = Incluye codigo identificador</para>
        /// </summary>
        public static List<TmpListaComboBox> flsCargarListaComboBox(List<TmpGestionItem> tlsListaItems, String tcrItemValorSelect, String tcrTipo)
        {
            int i = 0;
            string lcrValorSel = String.Empty;
            string lcrNombreOp = String.Empty;
            var llsLista = new List<TmpListaComboBox>();

            foreach (var lobReg in tlsListaItems)
            {
                //- Valor Seleccion
                lcrValorSel = tcrItemValorSelect == "ItemllaveRegistro" ? lobReg.Itemllave != null ? lobReg.Itemllave : lcrValorSel : lcrValorSel;
                lcrValorSel = tcrItemValorSelect == "ItemAliasSql" ? lobReg.ItemAliasSql != null ? lobReg.ItemAliasSql : lcrValorSel : lcrValorSel;
                lcrValorSel = tcrItemValorSelect == "ItemNombre" ? lobReg.ItemNombre != null ? lobReg.ItemNombre : lcrValorSel : lcrValorSel;

                if (String.IsNullOrWhiteSpace(lcrValorSel))
                {
                    //- Titulo
                    lcrNombreOp = tcrTipo == "2" ? lcrValorSel + " - " + lobReg.ItemTitulo : lobReg.ItemTitulo;

                    // Generar la lista
                    llsLista.Add(new TmpListaComboBox()
                    {
                        IdIndice = i.ToString().Trim(),
                        NombreOpcion = lcrNombreOp,
                        ValorSeleccion = lcrValorSel,
                    });
                    i++;
                }
            }
            return llsLista;
        }
        #endregion
        #region fnuMostrarItemComboBox: Mostrar en opcion del combobox segun opcion escrita en textbox
        /// <summary>
        /// <para>Mostrar la opcion del ComboBox segun opcion escrita en textbox, ListaComboBox desde clase Sistemas.ListaComboBox</para> 
        /// <param name="tcrValor">Valor Escrito en el cuadro de texto</param>
        /// <param name="tlsListaValores">Temporal Lista de Valores aceptados validos</param>
        /// <returns>Retorna un valor de tipo entero para SelectedIndex del Combobox</returns>
        /// </summary>
        public static int fnuMostrarItemComboBox(String tcrValor, List<ListaComboBox> tlsListaValores)
        {
            int lnuValor = 0;
            if (tlsListaValores != null)
            {
                var lobReg = tlsListaValores.FirstOrDefault(x => x.ValorSeleccion == tcrValor);
                if (lobReg != null)
                {
                    lnuValor = Convert.ToInt32(lobReg.IdIndice);
                }
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------
        #region Mostrar en opcion del combobox segun opcion escrita en textbox
        /// <summary>
        /// Mostrar la opcion del combobox segun opcion escrita en textbox
        /// <para>Cuando tcrValor es vacio, retorna el index 0 para mostrar el Texto 'Seleccione una opcion...'</para>
        /// <param name="tcrValor">Valor Escrito en el cuadro de texto</param>
        /// <param name="tcrListaValores">Lista de Valores aceptados validos</param>
        /// <returns>Retorna un valor de tipo entero para SelectedIndex del Combobox</returns>
        /// </summary>
        public static int fnuMostrarItemCombo(string tcrValor,string tcrSeparador, string tcrListaValores)
        {
            int lnuValor = 0;
            if (!string.IsNullOrEmpty(tcrValor)) 
            {
                lnuValor = Funciones.fnuDevolverPosElemento(tcrValor, tcrSeparador, tcrListaValores);
            }
            return lnuValor;
        }
        #endregion
        #region Mostrar en opcion del combobox segun opcion escrita en textbox
        /// <summary>
        /// Mostrar la opcion del combobox segun opcion escrita en textbox
        /// <param name="tcrValor">Valor Escrito en el cuadro de texto</param>
        /// <param name="tlsListaValores">Temporal Lista de Valores aceptados validos</param>
        /// <returns>Retorna un valor de tipo entero para SelectedIndex del Combobox</returns>
        /// </summary>
        public static int fnuMostrarItemCombo(String tcrValor, List<CrtForms.ListaComboBox> tlsListaValores)
        {
            int lnuValor = 0;
            if (tlsListaValores != null)
            {
                var lobReg = tlsListaValores.FirstOrDefault(x => x.ValorSeleccion == tcrValor);
                if (lobReg != null)
                {
                    lnuValor = Convert.ToInt32(lobReg.IdIndice);
                }
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------
        #region Mostrar en el Texbox segun opcion seleccionada en comboBox
        /// <summary>
        /// Mostrar la opcion seleccionada desde combobox en el Texbox 
        /// <returns>Retorna un valor de tipo string que representa el valor seleccion
        /// para llenar en el Texbox </returns>
        /// </summary>
        public static string fcrSeletDesdeComb(string tcrIndiceComboBox,string lcrValoActualTexbox,string tcrSeparador, string tcrListaValores)
        {
            string lnuValor =string.Empty;
            if (tcrIndiceComboBox!="0") 
            {
                lnuValor = Funciones.fuxExtraerElemento(Convert.ToInt32(tcrIndiceComboBox), tcrSeparador, tcrListaValores);
            }
            else 
            {
                lnuValor=lcrValoActualTexbox;
            }
            return lnuValor;
        }
        #endregion
        #region Mostrar en el Texbox segun opcion seleccionada en comboBox
        /// <summary>
        /// Mostrar la opcion seleccionada desde combobox en el Texbox 
        /// <returns>Retorna un valor de tipo string que representa el valor seleccion
        /// para llenar en el Texbox </returns>
        /// </summary>
        public static string fcrSeletDesdeComb(string tcrIndiceComboBox, string tcrSeparador, string tcrListaValores)
        {
            String lnuValor = String.Empty;
            lnuValor = Funciones.fuxExtraerElemento(Convert.ToInt32(tcrIndiceComboBox) + 1, tcrSeparador, tcrListaValores);

            return lnuValor;
        }
        #endregion
        #endregion
        //------------------------------------------------
        // Gestion Control Fecha
        //------------------------------------------------
        #region Gestion Control Fecha
        #region fcrFormatoCapturaFecha(): Foramto para captura de fecha
        /// <summary>
        /// Convertir una expresion de texto con formato fecha a tipo Fecha 
        /// <returns>Retorna un valor de tipo  fecha </returns>
        /// </summary>
        public static string fcrFormatoCapturaFecha(string tcrFormato, string tcrSeparador, string tcrFecha)
        {
            //var lcrValor = string.Empty;
            //- Valores 
            string lcrDia = "  ";
            string lcrMes = "  ";
            string lcrAño = "    ";
            //- Posicion de compnente dentro de uno destos formatos  DMY  MDY YMD ...

            var lnuPosDia = Funciones.fnuDevPosOcursElemento("D", 1, tcrFormato);
            var lnuPosMes = Funciones.fnuDevPosOcursElemento("M", 1, tcrFormato);
            var lnuPosAño = Funciones.fnuDevPosOcursElemento("Y", 1, tcrFormato);

            if (!string.IsNullOrEmpty(tcrFecha)) // esta en proceso de escritura (mostrar el avance)
            {
                //- Valor en la cadena 

                lcrDia = Funciones.fuxExtraerElemento(lnuPosDia, tcrSeparador, tcrFecha);
                lcrMes = Funciones.fuxExtraerElemento(lnuPosMes, tcrSeparador, tcrFecha);
                lcrAño = Funciones.fuxExtraerElemento(lnuPosAño, tcrSeparador, tcrFecha);

                //tcrFecha = Funciones.fcrCorregirFechaTexto(tcrFecha);

                //lcrDia = Funciones.fcrElementoFecha("DIA", "DMY", "/", tcrFecha);
                //lcrMes = Funciones.fcrElementoFecha("MES", "DMY", "/", tcrFecha);
                //lcrAño = Funciones.fcrElementoFecha("AÑO", "DMY", "/", tcrFecha);

                //- Depurar el Componente Dia
                #region Gestion Captura del Componente Dia
                lcrDia = lcrDia.Trim();
                if (string.IsNullOrEmpty(lcrDia.Trim()))
                {
                    lcrDia = "  ";
                }
                else
                {
                    if (lcrDia.Length > 2)
                    {
                        lcrDia = lcrDia.Substring(0, 2);
                    }
                    else if (lcrDia.Length == 1)
                    {
                        lcrDia = lcrDia.Trim() + " ";
                    }
                }
                #endregion
                //- Depurar el Componente Mes
                #region Depurar el Componente Mes
                lcrMes = lcrMes.Trim();
                if (string.IsNullOrEmpty(lcrMes))
                {
                    lcrMes = "  ";
                }
                else
                {
                    if (lcrMes.Length > 2)
                    {
                        lcrMes = lcrMes.Substring(0, 2);
                    }
                    else if (lcrMes.Length == 1) { lcrMes = lcrMes + " "; }
                }
                #endregion
                //- Depurar el Componente Mes
                #region Depurar el Componente Año
                lcrAño = lcrAño.Trim();
                if (string.IsNullOrEmpty(lcrAño))
                {
                    lcrAño = "    ";
                }
                else
                {
                    if (lcrAño.Length > 4) { lcrAño = lcrAño.Substring(0, 4); }
                    else if (lcrAño.Length != 4)
                    {
                        var lnuRelleno = 4 - lcrAño.Length;
                        string lcrRelleno = " ";
                        lcrAño = lcrAño + lcrRelleno.PadLeft(lnuRelleno, ' ');
                    }
                }
                #endregion
            }
            return fcrConcatenarFecha(tcrFormato, tcrSeparador, lcrDia, lcrMes, lcrAño);
        }
        #endregion
        //------------------------------------------------
        #region Mover el cursor dentro del formato 
        public static int fnuNewPosCursorFecha(string tcrFormato, int tnuPosCursor)
        {
            var lnuValor = tnuPosCursor;
            if (tnuPosCursor >= 0 && tnuPosCursor <= 9)
            {
                tcrFormato=tcrFormato.ToUpper();

                if (tcrFormato == "DMY" || tcrFormato == "MDY")
                {
                    switch (tnuPosCursor)
                    {
                        case 2: // al final del componente dia o mes
                            lnuValor = 3;
                            break;

                        case 5: // al final del componente mes o dia
                            lnuValor = 6;
                            break;
                    }
                }

                if (tcrFormato == "DYM" || tcrFormato == "MYD")
                {
                    switch (tnuPosCursor)
                    {
                        case 2: // al final del componente dia o mes
                            lnuValor = 3;
                            break;

                        case 7: // al final del componente año
                            lnuValor = 8;
                            break;
                    }
                }
                if (tcrFormato == "YDM" || tcrFormato == "YMD")
                {
                    switch (tnuPosCursor)
                    {
                        case 4: // al final del componente año
                            lnuValor = 5;
                            break;

                        case 7: // al final del componente dia o mes
                            lnuValor = 8;
                            break;
                    }
                }
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------
        #region Generar Fecha Con formato
        public static string fcrConcatenarFecha(string tcrFormato, string tcrSeparador, string tcrDia, string tcrMes, string tcrAño)
        {
            var lcrValor = string.Empty;
            tcrDia = tcrDia.Length == 1 ? "0" + tcrDia : tcrDia;
            switch (tcrFormato.ToUpper())
            {
                case "DMY":
                    lcrValor = tcrDia + tcrSeparador + tcrMes + tcrSeparador + tcrAño;
                    break;

                case "DYM":
                    lcrValor = tcrDia + tcrSeparador + tcrAño + tcrSeparador + tcrMes;
                    break;

                case "MDY":
                    lcrValor = tcrMes + tcrSeparador + tcrDia + tcrSeparador + tcrAño;
                    break;

                case "MYD":
                    lcrValor = tcrMes + tcrSeparador + tcrAño + tcrSeparador + tcrDia;
                    break;

                case "YDM":
                    lcrValor = tcrAño + tcrSeparador + tcrDia + tcrSeparador + tcrMes;
                    break;

                case "YMD":
                    lcrValor = tcrAño + tcrSeparador + tcrMes + tcrSeparador + tcrDia;
                    break;
            }
            return lcrValor;
        }
        #endregion
        //------------------------------------------------
        #region fdaConvertTextoAFecha(): Convertir texto a fecha
        /// <summary>
        /// Convertir una expresion de texto con formato fecha a tipo Fecha 
        /// <returns>Retorna un valor de tipo  fecha </returns>
        /// </summary>
        public static DateTime fdaConvertTextoAFecha(string tcrFormato,string tcrSeparador, string tcrFecha)
        {

            DateTime ldaFecha;
            // si es correcta genera el valor
            if (DateTime.TryParse(tcrFecha, out ldaFecha) && tcrFecha.Trim().Length == 10)
            {
                    string lcrDia = Funciones.fcrElementoFecha("DIA", tcrFormato, tcrSeparador, tcrFecha);
                    string lcrMes = Funciones.fcrElementoFecha("MES", tcrFormato, tcrSeparador, tcrFecha);
                    string lcrAño = Funciones.fcrElementoFecha("AÑO", tcrFormato, tcrSeparador, tcrFecha);
                    ldaFecha = new DateTime(int.Parse(lcrAño), int.Parse(lcrMes), int.Parse(lcrDia));
            }
            return ldaFecha;
        }
        #endregion
        #endregion
        //------------------------------------------------
        // Gestion Control Hora
        //------------------------------------------------
        #region Gestion Control Hora
        #region fcrFormatoCapturaHora(): Foramto para captura hora
        /// <summary>
        /// <para>Maneja el formato para capturar hora</para>
        /// <returns> Retorna un valor de tipo texto hora  fecha </returns>
        /// </summary>
        public static string fcrFormatoCapturaHora(string tcrFormato, string tcrSeparador, string tcrHora)
        {
            //var lcrValor = string.Empty;
            //- Valores 
            string lcrHora = "  ";
            string lcrMinutos = "  ";
            string lcrAmPm = "AM";
            // Posicion componentes hora en formato (formato 12 por defecto) 
            var lnuPosHora = 1;
            var lnuPosMinutos = 2;
            var lnuPosAmPm = 3;
            if (tcrFormato == "24")
            {
                lnuPosHora = 1;
                lnuPosMinutos = 2;
                lnuPosAmPm = 0;
            }

            if (!string.IsNullOrEmpty(tcrHora)) // esta en proceso de escritura (mostrar el avance)
            {
                //- Valor en la cadena 
                lcrHora = Funciones.fuxExtraerElemento(lnuPosHora, tcrSeparador, tcrHora);
                lcrMinutos = Funciones.fuxExtraerElemento(lnuPosMinutos, tcrSeparador, tcrHora);
                if (tcrFormato == "12") { lcrAmPm = Funciones.fuxExtraerElemento(lnuPosAmPm, tcrSeparador, tcrHora); }
                //- Depurar el Componente Hora
                #region Gestion Captura del Componente Hora
                lcrHora = lcrHora.Trim();
                if (string.IsNullOrEmpty(lcrHora) || !Funciones.flgSoloNumeros(lcrHora))
                {
                    lcrHora = "  ";
                }
                else
                {
                    if (lcrHora.Length > 2)
                    {
                        lcrHora = lcrHora.Substring(0, 2);
                    }
                    else if (lcrHora.Length == 1) { lcrHora = lcrHora.Trim() + " "; }
                }
                #endregion
                //- Depurar el Componente Minutos
                #region Depurar el Componente Minutos
                lcrMinutos = lcrMinutos.Trim();
                if (string.IsNullOrEmpty(lcrMinutos) || !Funciones.flgSoloNumeros(lcrMinutos))
                {
                    lcrMinutos = "  ";
                }
                else
                {
                    if (lcrMinutos.Length > 2)
                    {
                        lcrMinutos = lcrMinutos.Substring(0, 2);
                    }
                    else if (lcrMinutos.Length == 1) { lcrMinutos = lcrMinutos + " "; }
                }
                #endregion
                //- Depurar el Componente AM PM  (solo para formato 12)
                #region Depurar el Componente AM PM
                if (tcrFormato == "12")
                {
                    lcrAmPm = lcrAmPm.Trim();
                    if (string.IsNullOrEmpty(lcrAmPm) || (lcrAmPm.Substring(0, 1).ToUpper() != "A" && lcrAmPm.Substring(0, 1).ToUpper() != "P"))
                    {
                        lcrAmPm = "AM";
                    }
                    else
                    {
                        lcrAmPm = lcrAmPm.Substring(0, 1).ToUpper() + "M";
                    }
                }
                #endregion
            }
            var lcrValorReturn = fcrConcatenarHora(tcrFormato, tcrSeparador, lcrHora, lcrMinutos, lcrAmPm);
            lcrValorReturn = lcrValorReturn.Trim()==":  :AM" || 
                             lcrValorReturn.Trim()==":  :PM" || 
                             lcrValorReturn.Trim()==":  :" ||
                             lcrValorReturn.Trim()=="::AM" ||
                             lcrValorReturn.Trim()=="::PM" ||
                             lcrValorReturn.Trim()=="::" ? "  :  :  " : lcrValorReturn;

            return lcrValorReturn;
        }
        #endregion
        //------------------------------------------------
        #region Mover el cursor dentro del formato
        public static int fnuNewPosCursorHora(string tcrFormato, int tnuPosCursor)
        {
            var lnuValor = tnuPosCursor;
            switch (tcrFormato)
            {
                case "12":
                    if (tnuPosCursor >= 0 && tnuPosCursor <= 8)
                    {
                        switch (tnuPosCursor)
                        {
                            case 2: // al final del componente hora
                                lnuValor = 3;
                                break;

                            case 5: // al final del componente Minutos
                                lnuValor = 6;
                                break;
                        }
                    }
                    break;

                case "24":
                    if (tnuPosCursor >= 0 && tnuPosCursor <= 5)
                    {
                        switch (tnuPosCursor)
                        {
                            case 2: // al final del componente Hora
                                lnuValor = 3;
                                break;

                            case 5: // al final del componente mes o dia
                                //lnuValor = 6;
                                break;
                        }
                    }
                    break;
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------
        #region Generar Hora Con formato
        public static string fcrConcatenarHora(string tcrFormato, string tcrSeparador, string tcrHora, string tcrMinutos, string tcrAmPm)
        {
            var lcrValor = string.Empty;
            switch (tcrFormato.ToUpper())
            {
                case "12":
                    lcrValor = tcrHora + tcrSeparador + tcrMinutos + tcrSeparador + tcrAmPm;
                    break;

                case "24":
                    lcrValor = tcrHora + tcrSeparador + tcrMinutos;
                    break;
            }
            return lcrValor;
        }
        #endregion
        #endregion

    }
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.Objects;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for FCM_FacturacionResumenFiltro.xaml
    /// </summary>
    public partial class FacturacionResumenFiltro : Window
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public string cto_seccon_cont { get; set; }
            public string cto_nrocon_cont { get; set; }
            public string cto_descon_cont { get; set; }
            public string sia_codeps_teps { get; set; }
            public string sia_deseps_teps { get; set; }
            public int fcm_totuni_dfac { get; set; }
            public long fcm_valfac_dfac { get; set; }
            public bool seleccion { get; set; }
            public String llave { get; set; }
            public String busqueda { get; set; }
        }
        #endregion

        Aplicacion oApp = Aplicacion.Instancia();
        public String gcrListaSelect = String.Empty;
        public List<BrowerTabla> tmpResumen = null;
        public List<BrowerTabla> tmpRegistros = null;
        // Sumatoria general total
        public int gnuGenCantidadFacturas = 0;
        public long gnuGenValorTotalFacturas = 0;
        // Solo sumatorias de seleccionadas
        public int gnuFillCantidadFacturas = 0;
        public long gnuFillValorTotalFacturas = 0;

        public FacturacionResumenFiltro(String tcrFechaInicio, String tcrFechaFinal)
        {
            InitializeComponent();

            this.txtFechaInicial.Text = tcrFechaInicio;
            this.txtFechaFinal.Text   = tcrFechaFinal;

            fcvConsultarDatosTablas(tcrFechaInicio, tcrFechaFinal);
            grdDataGrid.ItemsSource = flsBuscarItemLista("");
        }
        //-------------------------------------------------------
        // fcvSelectCheckBox: Marcar o desmarcar todos los registros
        //-------------------------------------------------------
        #region fcvSelectCheckBoxUno: Marcar o desmarcar solo un registro
        private void fcvSelectCheckBoxUno(object sender, RoutedEventArgs e)
        {
            var lobjChk = sender as CheckBox;
            fcvGenerarResumenGeneral();
        }
        #endregion
        #region fcvSelectCheckBoxTodos: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBoxTodos(object sender, RoutedEventArgs e)
        {
            var lobjChk = sender as CheckBox;

            if (tmpRegistros != null && lobjChk != null)
            {
                foreach (var lobReg in tmpRegistros)
                {
                    lobReg.seleccion = (bool)lobjChk.IsChecked;
                }
            }
            // Refrescar la vista de la grilla
            CollectionViewSource.GetDefaultView(this.grdDataGrid.ItemsSource).Refresh();
            fcvGenerarResumenGeneral();
        }
        #endregion
        #region fcvGenerarResumenGeneral: Genera el resumen general de registros seleccionados
        /// <summary>
        /// Genera el resumen general de registros seleccionados
        /// </summary>
        private void fcvGenerarResumenGeneral()
        {
            if (tmpResumen != null)
            {
                gnuFillCantidadFacturas   = 0;
                gnuFillValorTotalFacturas = 0;
                gcrListaSelect            = String.Empty;

                foreach (var lobReg in tmpResumen)
                {
                    if (lobReg.seleccion == true)
                    {
                        gnuFillCantidadFacturas   += lobReg.fcm_totuni_dfac;
                        gnuFillValorTotalFacturas += lobReg.fcm_valfac_dfac;

                        gcrListaSelect += fcrGenerarListaSeleccion(lobReg);
                    }
                }
                fcvActualizarVistaValores();
            }
        }
        #endregion
        //-------------------------------------------------------
        // fcvEDTRowEditEnding: Quitar la Marca del Check Header
        //-------------------------------------------------------
        #region fcvEDTRowEditEnding: Quitar la Marca del Check Header
        private void fcvEDTRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            FrameworkElement element = grdDataGrid.Columns[4].GetCellContent(e.Row);
            if (element.GetType() == typeof(CheckBox))
            {
                if (((CheckBox)element).IsChecked == false)
                {
                    // codigo para desactivar el chk del Header
                }
            }
        }
        #endregion
        //-------------------------------------------------------
        // Metodos de controles en formulario e interface
        //-------------------------------------------------------
        #region Metodos de controles en formulario e interface
        //-------------------------------------------------------
        // cmdAceptar_Click: Aceptar y cerrar vista 
        //-------------------------------------------------------
        /// <summary>
        /// Clic en Boton Aceptar
        /// </summary>
        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            oApp.gcrWinMsCodigoMensaje = gcrListaSelect;
            this.Close();
            //fcvRetornoInterface(fcrCodigoSeleccionado());
        }
        //-------------------------------------------------------
        // fcvRetornoInterface: Retornar el valor al formulario 
        // principal
        //-------------------------------------------------------
        #region fcvRetornoInterface: Retornar el valor al formulario
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(string tcrCodigSelect)
        {
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
                this.Close();
            }

        }
        #endregion
        //-------------------------------------------------------
        // fcrCodigoSeleccionado: Obtener Codigos Seleccionado
        //-------------------------------------------------------
        #region fcrCodigoSeleccionado: Obtener Codigos Seleccionado
        /// <summary>
        /// Recorre el Datagrid para incluir los codigos seleciconados
        /// en una variable String separada por coma(,)
        /// </summary>
        public string fcrCodigoSeleccionado()
        {
            string lcrReturnCodigo = string.Empty;
            foreach (var lobjItem in grdDataGrid.Items)
            {
                DataGridRow lobjFila = (DataGridRow)grdDataGrid.ItemContainerGenerator.ContainerFromItem(lobjItem);
                if (lobjFila != null)
                {
                    CheckBox lobChk = grdDataGrid.Columns[0].GetCellContent(lobjFila) as CheckBox;
                    TextBlock lobText = grdDataGrid.Columns[1].GetCellContent(lobjFila) as TextBlock;
                    if (lobChk.IsChecked == true)
                    {
                        if (!String.IsNullOrWhiteSpace(lcrReturnCodigo))
                        {
                            lcrReturnCodigo = lcrReturnCodigo + "," + lobText.Text.Trim();
                        }
                        else
                        {
                            lcrReturnCodigo = lobText.Text.Trim();
                        }
                    }
                }
            }
            return lcrReturnCodigo;
        }
        #endregion
        //-------------------------------------------------
        //  KeyDown y GotFocus General
        //-------------------------------------------------
        #region KeyDown y GotFocus General
        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }
        #endregion
        #endregion
        //-------------------------------------------------------
        // Metodos Varios
        //-------------------------------------------------------
        #region Metodos Varios
        /// <summary>
        /// Metodos Varios
        /// </summary>
        private void btnCerrar_Click(object sender, MouseButtonEventArgs e)
        {
            oApp.gcrWinMsCodigoMensaje = "%X%";
            this.Close();
        }
        //-------------------------------------------------------
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //-------------------------------------------------------
        private void objDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            cmdAceptar.IsEnabled = true;
        }
        //-------------------------------------------------------
        /// <summary>
        /// Clic en Boton Cancelar
        /// </summary>
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            oApp.gcrWinMsCodigoMensaje = "%X%";
            this.Close();
        }
        #endregion
        //------------------------------------------------------------
        // FILTRO DE BUSQUEDA
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            grdDataGrid.ItemsSource = flsBuscarItemLista(lobTexto.Text);
        }
        #endregion
        //----------------------------------------------------------------------
        // ACTUALIZAR VALORES EN VISTA Y FILTRO
        //----------------------------------------------------------------------
        #region Filtro general de busqueda filtra la lista en el browser
        public List<BrowerTabla> flsBuscarItemLista(String tcrTexto)
        {
            tmpRegistros = null;
            //-------------------------------------------------------------------
            // Rango Fecha Codigo o nombre profesional y Descripcion del turno
            //-------------------------------------------------------------------
            if (!String.IsNullOrWhiteSpace(tcrTexto))
            {
                tcrTexto = tcrTexto.Trim().ToLower();
                #region  consulta con filtro
                tmpRegistros = (from tmp in tmpResumen
                                where tmp.busqueda.Contains(tcrTexto)
                                select tmp).ToList();
                #endregion
            }
            else
            {
                tmpRegistros = (from tmp in tmpResumen select tmp).ToList();
            }
            return tmpRegistros;
        }
        #endregion
        #region fcvActualizarVistaValores: Actualizar los valores totales en la vista 
        /// <summary> Actualizar los valores totales en la vista</summary>
        private void fcvActualizarVistaValores()
        {
            this.txtTotalFacturas.Text      = gnuGenCantidadFacturas.ToString();
            this.txtSelectFacturas.Text     = gnuFillCantidadFacturas.ToString();
            this.txtValorFacturas.Text      = String.Format("{0,15:N0}", gnuGenValorTotalFacturas);
            this.txtValSelectFacturas.Text  = String.Format("{0,15:N0}", gnuFillValorTotalFacturas);

            //this.txtValorFacturas.Text = String.Format("{0:C2}", gnuGenValorTotalFacturas);

        }
        #endregion
        //----------------------------------------------------------------------
        //  FILTRO DE BUSQUEDA Y CONSULTA PARA TEMPORALES SQL  
        //----------------------------------------------------------------------
        #region fcvConsultarDatosTablas: Ejecutar consultas Sql para generar temporales de reporte
        /// <summary>
        /// <para>Ejecutar consultas Sql para generar temporales de reporte general</para>
        /// </summary>
        public void fcvConsultarDatosTablas(String tcrFechaInicio, String tcrFechaFinal)
        {
            gnuGenCantidadFacturas      = 0;
            gnuGenValorTotalFacturas    = 0;
            gnuFillCantidadFacturas     = 0;
            gnuFillValorTotalFacturas   = 0;
            gcrListaSelect              = String.Empty;

            var lcrLineaSqlSelct = String.Empty;
            var lcrLinea         = String.Empty;
            tmpResumen           = new List<BrowerTabla>();

            lcrLineaSqlSelct = fcrStringSQLInformes(tcrFechaInicio, tcrFechaFinal);
            var tmpConsulta = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            // Resumen general
            #region Primera parte - Resumen general
            if (tmpConsulta != null)
            {

                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    var lobNow = new BrowerTabla();

                    #region gestion de datos
                    lobNow.cto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lobNow.cto_nrocon_cont = lobReg["cto_nrocon_cont"].ToString().Trim();
                    lobNow.cto_descon_cont = lobReg["cto_descon_cont"].ToString().Trim();
                    lobNow.sia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    lobNow.sia_deseps_teps = lobReg["sia_deseps_teps"].ToString().Trim();
                    lobNow.fcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                    lobNow.fcm_valfac_dfac = Convert.ToInt64(lobReg["fcm_valfac_dfac"].ToString());
                    lobNow.llave = lobNow.cto_seccon_cont + "*" + lobNow.sia_codeps_teps;
                    lobNow.seleccion = true;

                    lobNow.busqueda = lobNow.cto_nrocon_cont.ToLower() + " " +
                                      lobNow.cto_descon_cont.ToLower() + " " +
                                      lobNow.sia_codeps_teps.ToLower() + " " +
                                      lobNow.sia_deseps_teps.ToLower();
                    #endregion
                    gnuGenCantidadFacturas   += lobNow.fcm_totuni_dfac;
                    gnuGenValorTotalFacturas += lobNow.fcm_valfac_dfac;

                    gcrListaSelect += fcrGenerarListaSeleccion(lobNow);

                    tmpResumen.Add(lobNow);
                }
                gnuFillCantidadFacturas   = gnuGenCantidadFacturas;
                gnuFillValorTotalFacturas = gnuGenValorTotalFacturas;
                fcvActualizarVistaValores();
            }
            #endregion
        }
        #endregion
        #region fcrStringSQLInformes: Generar String SQl para las consultas
        /// <summary>
        /// <para>Generar String SQl para las consultas</para>
        /// </summary>
        public String fcrStringSQLInformes(String tcrFechaIni, String tcrFechaFin)
        {
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaIni, "YMD", "-"); 
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaFin, "YMD", "-");
            String lcrLineaSqlSelct = String.Empty;

            #region Linea SQl para resumen general Valores y cantidades facturacion
            lcrLineaSqlSelct = "SELECT fcmmaesfacturas.cto_seccon_cont," +
	                                    "fcmmaesfacturas.cto_nrocon_cont," +
	                                    "ctomaescontrato.cto_descon_cont," +
	                                    "fcmmaesfacturas.sia_codeps_teps," +
	                                    "siatablaeps.sia_deseps_teps," +
		                                "count(fcmmaesfacturas.fcm_numfac_mfac) AS fcm_totuni_dfac," +
		                                "SUM(fcmmaesfacturas.fcm_valfac_dfac) AS fcm_valfac_dfac " +
                                   "FROM fcmmaesfacturas " +
			                                "INNER JOIN ctomaescontrato ON (fcmmaesfacturas.cto_seccon_cont = ctomaescontrato.cto_seccon_cont) " +
			                                "INNER JOIN siatablaeps ON (fcmmaesfacturas.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                                    "WHERE (fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                          "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
		                                  "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                   "GROUP BY fcmmaesfacturas.cto_seccon_cont,fcmmaesfacturas.sia_codeps_teps "+
                                   "ORDER BY ctomaescontrato.cto_descon_cont";
            #endregion
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcvGenerarListaSeleccion: Genera la lista de registros seleccionados
        /// <summary>
        /// Genera la lista de registros seleccionados en formato texto separado por comas
        /// </summary>
        private String fcrGenerarListaSeleccion(BrowerTabla tobRegistro)
        {
            var lcrLinea = tobRegistro.cto_seccon_cont.Trim() + "X" + tobRegistro.sia_codeps_teps.Trim();

            lcrLinea = String.IsNullOrWhiteSpace(gcrListaSelect) ? lcrLinea : "," + lcrLinea;

            return lcrLinea;
        }
        #endregion

    }
}

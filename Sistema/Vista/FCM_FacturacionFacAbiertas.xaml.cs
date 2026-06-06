/*
using System;
using System.Collections.Generic;
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

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for FCM_FacturacionFacAbiertas.xaml
    /// </summary>
    public partial class FacturacionFacAbiertas : Window
    {
        public FacturacionFacAbiertas()
        {
            InitializeComponent();
        }
    }
}
*/
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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Datos.Modelos;
using Sistema.Utilidades;
using System.Reflection;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for CIT_VistaFiltroturnos.xaml
    /// </summary>
    public partial class FacturacionFacAbiertas : Window
    {
        public String gcrParamFiltroPorProfesional = String.Empty;

        public FacturacionFacAbiertas()
        {
            InitializeComponent();
            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Cit_fecitr_turn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecftr_turn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            this.dpkG1Cit_fecitr_turn.SelectedDate = Funciones.FdaFechaActual().AddDays(-(Funciones.FdaFechaActual().Day - 1));
            this.dpkG1Cit_fecftr_turn.SelectedDate = Funciones.FdaFechaActual();

            fcvAddColGrid_Admregadmision();
            this.objDataGrid.ItemsSource = flsBuscarFiltro().DefaultView; 
        }
        //-------------------------------------------------------
        // fcvFiltroTextChanged: Filtro general 
        //-------------------------------------------------------
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            this.txtFiltro.Text = lobTexto.Text;

            this.objDataGrid.ItemsSource = flsBuscarFiltro().DefaultView; 
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
            fcvRetornoInterface(fcrSelect_Admregadmision());
        }
        /// <summary>
        /// Metodos para controles en el Formulario
        /// </summary>
        private void DataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                fcvRetornoInterface(fcrSelect_Admregadmision());
            }
        }
        /// <summary>
        /// al hacer Doble clic en DataGRid
        /// </summary>
        private void MouseDbClick(object sender, MouseButtonEventArgs e)
        {
            fcvRetornoInterface(fcrSelect_Admregadmision());
        }
        private void objDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            cmdAceptar.IsEnabled = true;
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
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        //  Actualizar Campo TextBox desde DatePiker
        //-------------------------------------------------
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkG1Cit_fecitr_turn":
                        txtG1Cit_fecitr_turn.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cit_fecitr_turn);
                        break;
                    case "dpkG1Cit_fecftr_turn":
                        txtG1Cit_fecftr_turn.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cit_fecftr_turn);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar DatePiker desde Campo Texto
        //-------------------------------------------------
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            try
            {
                DateTime ldaFecha;
                TextBox lobTexto = (TextBox)sender;
                var lnuPosCursor = lobTexto.SelectionStart;
                var lcrValor = CrtForms.fcrFormatoCapturaFecha("DMY", "/", lobTexto.Text);
                if (lobTexto.Text.Trim() != lcrValor.Trim())
                {
                    lobTexto.Text = lcrValor;
                    lobTexto.SelectionStart = CrtForms.fnuNewPosCursorFecha("DMY", lnuPosCursor);
                }
                if (DateTime.TryParse(lobTexto.Text, out ldaFecha) && lobTexto.Text.Trim().Length == 10)
                {
                    switch (lobTexto.Name)
                    {
                        case "txtG1Cit_fecitr_turn":
                            dpkG1Cit_fecitr_turn.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                            break;
                        case "txtG1Cit_fecftr_turn":
                            dpkG1Cit_fecftr_turn.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                            break;
                    }
                }
                var lobVista = flsBuscarFiltro();
                if (lobVista != null)
                {
                    this.objDataGrid.ItemsSource = lobVista.DefaultView;
                }
                else
                {
                    this.objDataGrid.ItemsSource = null;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarDatePicker");
            }
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
            this.Close();
        }
        //-------------------------------------------------------
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //-------------------------------------------------------
        /// <summary>
        /// Clic en Boton Cancelar
        /// </summary>
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        //----------------------------------------------------------------------
        // flgValidarRangoFechas: Validar Rango Fecha filtro
        //----------------------------------------------------------------------
        #region flgValidarRangoFechas: Validar Rango Fecha filtro
        public bool flgValidarRangoFechas()
        {
            var llgReturn = false;
            var lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Cit_fecitr_turn.Text, "Fecha Inicio turno");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Cit_fecftr_turn.Text, "Fecha fin turno")))
            {
                // Validar Rango 
                llgReturn = Funciones.flgValidarRangoFecha(txtG1Cit_fecitr_turn.Text, txtG1Cit_fecftr_turn.Text);
            }
            return llgReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        // FILTRO CITMAESTROTURNO - Maestro de turnos por profesional
        //----------------------------------------------------------------------
        #region Filtro
        #region Filtro de busquedas
        public DataTable flsBuscarFiltro()
        {
            DataTable lobjDatosTabla = null;
            var lcrLineaSqlSelct =String.Empty;
            this.txtTotalFacturas.Text = String.Empty;

            if (flgValidarRangoFechas())
            {
                var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Cit_fecitr_turn.Text, "YMD", "-");
                var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Cit_fecftr_turn.Text, "YMD", "-");
                /*
                var lcrFiltro1 = " WHERE fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "' AND " +
                                        "fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "' AND " +
                                        "fcmmaesfacturas.fcm_estfac_mfac = '1' ";
                */
                var lcrFiltro1 = " WHERE admregadmision.adm_fecadm_rgad >= '" + lcrFechaIni + "' AND " +
                                        "admregadmision.adm_fecadm_rgad <= '" + lcrFechaFin + "' AND " +
                                        "fcmmaesfacturas.fcm_estfac_mfac = '1' ";

                var lcrFiltro2 = String.Empty;
                if (!String.IsNullOrWhiteSpace(this.txtFiltro.Text))
                {
                    var lcrTexto = this.txtFiltro.Text;
                    lcrFiltro2 = " AND (siausuarioatend.sia_nomusu_usua LIKE '%" + lcrTexto + "%' OR " +
                                 "admregadmision.sia_nroide_usua LIKE '%" + lcrTexto + "%' OR " +
                                 "admregadmision.sia_codeps_teps LIKE '%" + lcrTexto + "%' OR " +
                                 "siatablaeps.sia_deseps_teps LIKE '%" + lcrTexto + "%' OR " +
                                 "sysusuarios.sys_nomusu_usux LIKE '%" + lcrTexto + "%' OR " +
                                 "admregadmision.adm_secadm_rgad LIKE '%" + lcrTexto + "%')";
                }

                var lcrGroupBy = " GROUP BY admregadmision.adm_secadm_rgad";
                lcrLineaSqlSelct = fcrLineaSqlAdmision() + lcrFiltro1 + lcrFiltro2 + lcrGroupBy;
                lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

                this.txtTotalFacturas.Text = lobjDatosTabla != null ? lobjDatosTabla.Rows.Count.ToString() : "0";
            }

            return lobjDatosTabla;
        }
        public String fcrLineaSqlAdmision()
        {
            var lcrLinea = "SELECT siatregatencion.sia_desreg_rgat," +
                                   "admregadmision.adm_secadm_rgad," +
	                               "admregadmision.adm_fecadm_rgad," +
	                               "admregadmision.sia_codeps_teps," +
	                               "siatablaeps.sia_deseps_teps," +
	                               "admregadmision.sia_idesec_usua," +
	                               "admregadmision.sia_tipide_tide," +
	                               "admregadmision.sia_nroide_usua," +
	                               "siausuarioatend.sia_priape_usua," +
	                               "siausuarioatend.sia_segape_usua," +
	                               "siausuarioatend.sia_prinom_usua," +
	                               "siausuarioatend.sia_segnom_usua," +
	                               "siausuarioatend.sia_fecnac_usua," +
	                               "fcmmaesfacturas.sys_codusu_usux," +
	                               "sysusuarios.sys_nomusu_usux" +
	                         " FROM admregadmision" +
                                    " INNER JOIN siatregatencion ON (admregadmision.sia_regate_rgat = siatregatencion.sia_regate_rgat)" +
                                    " INNER JOIN fcmmaesfacturas ON (admregadmision.adm_secadm_rgad = fcmmaesfacturas.adm_secadm_rgad)" +
	                                " INNER JOIN siatablaeps ON (admregadmision.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
	                                " INNER JOIN siausuarioatend ON (admregadmision.sia_idesec_usua = siausuarioatend.sia_idesec_usua)" +
	                               " INNER JOIN sysusuarios ON (admregadmision.sys_codusu_usux = sysusuarios.sys_codusu_usux)" ;
            return lcrLinea;
        }
        #endregion
        // Crear Columans del DataGrid
        #region Configurar lista de indices
        public void fcvAddColGrid_Admregadmision()
        {
            objGridView.Columns.Add(new GridViewColumn { Header = "Tipo atención", Width = 120, DisplayMemberBinding = new Binding("sia_desreg_rgat") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 090, DisplayMemberBinding = new Binding("sia_nroide_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Admisión", Width = 090, DisplayMemberBinding = new Binding("adm_secadm_rgad") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Fecha Admisión", Width = 090, DisplayMemberBinding = new Binding("adm_fecadm_rgad") { StringFormat = "dd/MM/yyyy" } });
            objGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido", Width = 120, DisplayMemberBinding = new Binding("sia_priape_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido", Width = 120, DisplayMemberBinding = new Binding("sia_segape_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre", Width = 120, DisplayMemberBinding = new Binding("sia_prinom_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre", Width = 120, DisplayMemberBinding = new Binding("sia_segnom_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Fecha Nacimiento", Width = 100, DisplayMemberBinding = new Binding("sia_fecnac_usua") { StringFormat = "dd/MM/yyyy" } });
            objGridView.Columns.Add(new GridViewColumn { Header = "Sexo", Width = 080, DisplayMemberBinding = new Binding("sis_codsex_sexo") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Id Unica Usuario", Width = 120, DisplayMemberBinding = new Binding("sia_idesec_usua") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 100, DisplayMemberBinding = new Binding("sia_codeps_teps") });
            objGridView.Columns.Add(new GridViewColumn { Header = "EPS", Width = 200, DisplayMemberBinding = new Binding("sia_deseps_teps") });
            objGridView.Columns.Add(new GridViewColumn { Header = "Facturador", Width = 120, DisplayMemberBinding = new Binding("sys_nomusu_usux") });
        }
        #endregion
        // Seleccionar Registro
        public string fcrSelect_Admregadmision()
        {
            var lcrReturn = string.Empty;
            if (objDataGrid.SelectedIndex != -1)
            {
                //var objReg = (BrowerAdmision)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                var objReg = (DataRowView)objDataGrid.Items[objDataGrid.SelectedIndex];
                lcrReturn = objReg["adm_secadm_rgad"].ToString().Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
}

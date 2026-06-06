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
    public partial class VistaFiltroturnos : Window
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public string cit_codtur_turn { get; set; }
            public string sia_codpfa_prof { get; set; }
            public string sia_nompro_prof { get; set; }
            public string sia_desprm_prom { get; set; }
            public string cit_destur_turn { get; set; }
            
        }
        #endregion
        public String gcrParamFiltroPorProfesional = String.Empty;

        public VistaFiltroturnos(String tcrParamFiltroPorProfesional)
        {
            InitializeComponent();
            gcrParamFiltroPorProfesional = tcrParamFiltroPorProfesional;
            txtProfesional.Text = gcrParamFiltroPorProfesional;
            txtProfesional.IsEnabled = String.IsNullOrWhiteSpace(gcrParamFiltroPorProfesional);
            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Cit_fecitr_turn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecftr_turn.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            this.dpkG1Cit_fecitr_turn.SelectedDate = Funciones.FdaFechaActual();
            this.dpkG1Cit_fecftr_turn.SelectedDate = Funciones.FdaFechaActual();
            grdDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
        }
        //-------------------------------------------------------
        // fcvFiltroTextChanged: Filtro general 
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            grdDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
        }
        #endregion
        //-------------------------------------------------------
        // fcvSelectCheckBox: Marcar o desmarcar todos los registros
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            var lobjChk = sender as CheckBox;
            foreach (var lobjItem in grdDataGrid.Items)
            {
                DataGridRow lobjFila = (DataGridRow)grdDataGrid.ItemContainerGenerator.ContainerFromItem(lobjItem);
                if (lobjFila != null)
                {
                    CheckBox lobChk = grdDataGrid.Columns[0].GetCellContent(lobjFila) as CheckBox;
                    if (lobjChk.IsChecked == true)
                    {
                        lobChk.IsChecked = true;
                    }
                    else
                    {
                        lobChk.IsChecked = false;
                    }
                }
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
            fcvRetornoInterface(fcrCodigoSeleccionado());
        }
        //-------------------------------------------------------
        // cmdLipiarFiltro_Click: Limpiar el filtro de busquea
        //-------------------------------------------------------
        /// <summary>
        /// Limpiar el filtro de busquea
        /// </summary>
        private void cmdLipiarFiltro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Cit_fecitr_turn.Text = String.Empty;
            txtG1Cit_fecftr_turn.Text = String.Empty;
            txtProfesional.Text = String.Empty;
            txtTurnos.Text = String.Empty;
            txtProfesional.Text = !String.IsNullOrWhiteSpace(gcrParamFiltroPorProfesional) ? gcrParamFiltroPorProfesional : String.Empty;
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
                grdDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
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
        #region CITMAESTROTURNO
        public List<BrowerTabla> flsBuscar_Citmaestroturno()
        {
            DateTime ldaFechaIni, ldaFechaFin;
            DateTime.TryParse(txtG1Cit_fecitr_turn.Text, out ldaFechaIni);
            DateTime.TryParse(txtG1Cit_fecftr_turn.Text, out ldaFechaFin);
            List<BrowerTabla> tmpRegistros = null;
            IQueryable<BrowerTabla> lcrQuery = null;

            using (DbAplicacion db = new DbAplicacion())
            {
                //-------------------------------------------------------------------
                // Rango Fecha Codigo o nombre profesional y Descripcion del turno
                //-------------------------------------------------------------------
                if (flgValidarRangoFechas() && !String.IsNullOrWhiteSpace(txtProfesional.Text) && 
                    !String.IsNullOrWhiteSpace(txtTurnos.Text)) 
                {
                    #region  Rango Fecha Codigo o nombre profesional y Descripcion del turno
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where (t1.cit_fecitr_turn>=ldaFechaIni &&
                                          t1.cit_fecftr_turn <= ldaFechaFin && 
                                          t1.sis_estpro_espr=="2") &&
                                        (t1.sia_codpfa_prof.Contains(txtProfesional.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(txtProfesional.Text.Trim()) ||
                                         t1.cit_destur_turn.Contains(txtTurnos.Text.Trim()))
                                   orderby t1.cit_fecitr_turn descending 
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       sia_desprm_prom = db.Siaprofesisalud.FirstOrDefault(x => x.sia_codprm_prom == t2.sia_codprm_prom).sia_desprm_prom,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Rango Fecha Codigo o nombre profesional 
                //-------------------------------------------------------------------
                else if (flgValidarRangoFechas() && !String.IsNullOrWhiteSpace(txtProfesional.Text)) // Solo Rango de fecha
                {
                    #region Rango de Fechas y profesional 
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where (t1.cit_fecitr_turn >= ldaFechaIni && 
                                          t1.cit_fecftr_turn <= ldaFechaFin && t1.sis_estpro_espr == "2") &&
                                        (t1.sia_codpfa_prof.Contains(txtProfesional.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(txtProfesional.Text.Trim()))
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Rango Fecha y Descripcion del turno
                //-------------------------------------------------------------------
                else if (flgValidarRangoFechas() && !String.IsNullOrWhiteSpace(txtTurnos.Text)) // Rango de fecha y Descripcion turno
                {
                    #region fecha y Descripcion turno
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where (t1.cit_fecitr_turn >= ldaFechaIni &&
                                          t1.cit_fecftr_turn <= ldaFechaFin && t1.sis_estpro_espr == "2") &&               
                                          t1.cit_destur_turn.Contains(txtTurnos.Text.Trim())
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    return lcrQuery.Take(200).ToList();
                    #endregion
                }
                //-------------------------------------------------------------------
                // Solo Rango de fecha
                //-------------------------------------------------------------------
                else if (flgValidarRangoFechas()) 
                {
                    #region Solo Rango de Fecha
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.cit_fecitr_turn >= ldaFechaIni && t1.cit_fecftr_turn <= ldaFechaFin && t1.sis_estpro_espr == "2"
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Descripcion turno y nombre del profesional
                //-------------------------------------------------------------------
                else if (!String.IsNullOrWhiteSpace(txtProfesional.Text) && !String.IsNullOrWhiteSpace(txtTurnos.Text)) //Descripcion turno y nombre del profesional
                {
                    #region Descripcion turno y nombre del profesional
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.sis_estpro_espr == "2" && (t1.cit_destur_turn.Contains(txtTurnos.Text.Trim()) ||
                                         t1.sia_codpfa_prof.Contains(txtProfesional.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(txtProfesional.Text.Trim()))
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Descripcion turno 
                //-------------------------------------------------------------------
                else if (!String.IsNullOrWhiteSpace(txtTurnos.Text)) //Descripcion turno 
                {
                    #region Descripcion turno
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.cit_destur_turn.Contains(txtTurnos.Text.Trim()) && t1.sis_estpro_espr == "2"
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Codigo y Nombre del profesional
                //-------------------------------------------------------------------
                else if (!String.IsNullOrWhiteSpace(txtProfesional.Text))
                {
                    #region Codigo y Nombre del profesional
                    lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.sis_estpro_espr == "2" && (t1.sia_codpfa_prof.Contains(txtProfesional.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(txtProfesional.Text.Trim()))
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       cit_codtur_turn = t1.cit_codtur_turn,
                                       sia_codpfa_prof = t1.sia_codpfa_prof,
                                       sia_nompro_prof = t2.sia_nompro_prof,
                                       cit_destur_turn = t1.cit_destur_turn
                                   };
                    #endregion
                }
                //-------------------------------------------------------------------
                // Resultado por defecto
                //-------------------------------------------------------------------
                else
                {
                    #region Sin ningun filtro
                    lcrQuery = (from t1 in db.Citmaestroturno
                                    join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                    where t1.sis_estpro_espr == "2"
                                    orderby t1.cit_fecitr_turn descending
                                    select new BrowerTabla
                                    {
                                        cit_codtur_turn = t1.cit_codtur_turn,
                                        sia_codpfa_prof = t1.sia_codpfa_prof,
                                        sia_nompro_prof = t2.sia_nompro_prof,
                                        cit_destur_turn = t1.cit_destur_turn
                                    });
                    #endregion
                }
                if (lcrQuery!= null)
                {
                    tmpRegistros = lcrQuery.Take(200).ToList();
                }
            }
            this.lblTotalRegistros.Text="REGISTROS: "+tmpRegistros.Count.ToString();

            return tmpRegistros;
        }
        #endregion
    }
}

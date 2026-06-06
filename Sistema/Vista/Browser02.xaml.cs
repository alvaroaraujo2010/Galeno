using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sistema.Utilidades;
using Sistema.Clases;
using Datos.Modelos;

namespace Sistema.Vista
{
    /// <summary>
    /// Clase para mostrar un Browser de Busqueda
    /// </summary>
    public partial class Browser02 : Window
    {
        public string gcrCodigoReturn =string.Empty;
        public string gcrCodigoModulo;
        public string gcrTabla;
        public int gnuIdIndiceInicial;
        public string gcrFiltroTabla;
        public List<AuxBrowser02.ComboItem> gclListaIndices = new List<AuxBrowser02.ComboItem>();

        #region Configuracion Inicial
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public Browser02(string tcrCodigoModulo, string tcrTabla, int tnuIdIndiceInicial, string tcrFiltroTabla, string tcrTituloVentana)
        {
            InitializeComponent();
            txtTituloVentana.Text   = tcrTituloVentana;
            gcrCodigoModulo         = tcrCodigoModulo;
            gcrTabla                = tcrTabla;
            gnuIdIndiceInicial      = tnuIdIndiceInicial;
            gcrFiltroTabla          = tcrFiltroTabla;

            switch (tcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    #region Configuracion para modulo hospitalizacion
                    HOS_Browser02 obj       = new HOS_Browser02();
                    obj.gobjForm            = this;
                    obj.gcrCodigoModulo     = gcrCodigoModulo;
                    obj.gcrTabla            = gcrTabla;
                    obj.gclListaIndices     = gclListaIndices;
                    obj.gnuIdIndiceInicial  = gnuIdIndiceInicial;
                    obj.gcrFiltroTabla      = gcrFiltroTabla;
                    obj.ConfigInicial();
                    #endregion
                    break;

                case "SIA": //Modulo Configuracion asistencial
                    #region Configuracion para modulo asistencial
                    SIA_Browser02 objSia = new SIA_Browser02();
                    objSia.gobjForm = this;
                    objSia.gcrCodigoModulo = gcrCodigoModulo;
                    objSia.gcrTabla = gcrTabla;
                    objSia.gclListaIndices = gclListaIndices;
                    objSia.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objSia.gcrFiltroTabla = gcrFiltroTabla;
                    objSia.ConfigInicial();
                    #endregion
                    break;

                case "CIT": //Modulo Citas medicas
                    #region Modulo Citas medicas
                    CIT_Browser02 objCit = new CIT_Browser02();
                    objCit.gobjForm = this;
                    objCit.gcrCodigoModulo = gcrCodigoModulo;
                    objCit.gcrTabla = gcrTabla;
                    objCit.gclListaIndices = gclListaIndices;
                    objCit.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objCit.gcrFiltroTabla = gcrFiltroTabla;
                    objCit.ConfigInicial();
                    #endregion
                    break;

                case "FCM": //Facturacion Servicios Medicos
                    break;

                case "ADM": //Modulo Admision
                    #region Modulo Admision
                    ADM_Browser02 objAdm = new ADM_Browser02();
                    objAdm.gobjForm = this;
                    objAdm.gcrCodigoModulo = gcrCodigoModulo;
                    objAdm.gcrTabla = gcrTabla;
                    objAdm.gclListaIndices = gclListaIndices;
                    objAdm.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objAdm.gcrFiltroTabla = gcrFiltroTabla;
                    objAdm.ConfigInicial();
                    #endregion
                    break;

                case "HCL": //Historias Clínicas
                    #region Modulo Historias Clínicas
                    HCL_Browser02 objHcl = new HCL_Browser02();
                    objHcl.gobjForm = this;
                    objHcl.gcrCodigoModulo = gcrCodigoModulo;
                    objHcl.gcrTabla = gcrTabla;
                    objHcl.gclListaIndices = gclListaIndices;
                    objHcl.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objHcl.gcrFiltroTabla = gcrFiltroTabla;
                    objHcl.ConfigInicial();
                    #endregion
                    break;

                case "CAR": //Modulo Cartera
                    #region Modulo Cartera
                    CAR_Browser02 objCar = new CAR_Browser02();
                    objCar.gobjForm = this;
                    objCar.gcrCodigoModulo = gcrCodigoModulo;
                    objCar.gcrTabla = gcrTabla;
                    objCar.gclListaIndices = gclListaIndices;
                    objCar.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objCar.gcrFiltroTabla = gcrFiltroTabla;
                    objCar.ConfigInicial();
                    #endregion
                    break;

                case "CTO": //Modulo Contratos
                    #region Modulo Cartera
                    CTO_Browser02 objCto = new CTO_Browser02();
                    objCto.gobjForm = this;
                    objCto.gcrCodigoModulo = gcrCodigoModulo;
                    objCto.gcrTabla = gcrTabla;
                    objCto.gclListaIndices = gclListaIndices;
                    objCto.gnuIdIndiceInicial = gnuIdIndiceInicial;
                    objCto.gcrFiltroTabla = gcrFiltroTabla;
                    objCto.ConfigInicial();
                    #endregion
                    break;

            }

        }
        #endregion
        #region Obtener Codigo Seleccionado
        /// <summary>
        /// Metodos para controles en el Formulario
        /// </summary>
        public string fcrCodigoSeleccionado()
        {
            string lcrReturnCodigo = string.Empty;
            switch (gcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    #region Configuracion para modulo hospitalizacion
                    HOS_Browser02 obj = new HOS_Browser02();
                    obj.gobjForm = this;
                    obj.gcrCodigoModulo = gcrCodigoModulo;
                    obj.gcrTabla = gcrTabla;
                    obj.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = obj.fcrRegistroSelect();
                    #endregion
                    break;

                case "SIA": //Modulo Configuracion asistencial
                    #region Configuracion asistencial
                    SIA_Browser02 objSia = new SIA_Browser02();
                    objSia.gobjForm = this;
                    objSia.gcrCodigoModulo = gcrCodigoModulo;
                    objSia.gcrTabla = gcrTabla;
                    objSia.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objSia.fcrRegistroSelect();
                    #endregion
                    break;

                case "CIT": //Modulo Citas medicas
                    #region Modulo Citas medicas
                    CIT_Browser02 objCit = new CIT_Browser02();
                    objCit.gobjForm = this;
                    objCit.gcrCodigoModulo = gcrCodigoModulo;
                    objCit.gcrTabla = gcrTabla;
                    objCit.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objCit.fcrRegistroSelect();
                    #endregion
                    break;

                case "FCM": //Facturacion Servicios Medicos
                    lcrReturnCodigo = string.Empty;
                    break;

                case "ADM": //Modulo Admision
                    lcrReturnCodigo = string.Empty;
                    #region Modulo Admision
                    ADM_Browser02 objAdm = new ADM_Browser02();
                    objAdm.gobjForm = this;
                    objAdm.gcrCodigoModulo = gcrCodigoModulo;
                    objAdm.gcrTabla = gcrTabla;
                    objAdm.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objAdm.fcrRegistroSelect();
                    #endregion
                    break;

                case "HCL": //Modulo Historias Clinicas
                    lcrReturnCodigo = string.Empty;
                    #region Modulo Admision
                    HCL_Browser02 objHcl = new HCL_Browser02();
                    objHcl.gobjForm = this;
                    objHcl.gcrCodigoModulo = gcrCodigoModulo;
                    objHcl.gcrTabla = gcrTabla;
                    objHcl.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objHcl.fcrRegistroSelect();
                    #endregion
                    break;

                case "CAR": //Modulo Cartera
                    lcrReturnCodigo = string.Empty;
                    #region Modulo Cartera
                    CAR_Browser02 objCar = new CAR_Browser02();
                    objCar.gobjForm = this;
                    objCar.gcrCodigoModulo = gcrCodigoModulo;
                    objCar.gcrTabla = gcrTabla;
                    objCar.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objCar.fcrRegistroSelect();
                    #endregion
                    break;

                case "CTO": //Modulo Contratos
                    lcrReturnCodigo = string.Empty;
                    #region Modulo Cartera
                    CTO_Browser02 objCto = new CTO_Browser02();
                    objCto.gobjForm = this;
                    objCto.gcrCodigoModulo = gcrCodigoModulo;
                    objCto.gcrTabla = gcrTabla;
                    objCto.gclListaIndices = gclListaIndices;
                    lcrReturnCodigo = objCto.fcrRegistroSelect();
                    #endregion
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        #region Metodos de controles en formulario e interface
        /// <summary>
        /// Clic en Boton Aceptar
        /// </summary>
        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            fcvRetornoInterface(fcrCodigoSeleccionado());
        }

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

        /// <summary>
        /// Metodos Buscar desde el Boton
        /// </summary>
        private void cmdBuscar_click(object sender, RoutedEventArgs e)
        {
            string lcrReturnCodigo = string.Empty;
            switch (gcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    #region Configuracion para modulo hospitalizacion
                    HOS_Browser02 obj = new HOS_Browser02();
                    obj.gobjForm = this;
                    obj.gcrCodigoModulo = gcrCodigoModulo;
                    obj.gcrTabla = gcrTabla;
                    obj.gclListaIndices = gclListaIndices;
                    obj.fcvBuscar();
                    #endregion
                    break;

                case "SIA": //Modulo Configuracion asistencial
                    #region Modulo Configuracion asistencial
                    SIA_Browser02 objSia = new SIA_Browser02();
                    objSia.gobjForm = this;
                    objSia.gcrCodigoModulo = gcrCodigoModulo;
                    objSia.gcrTabla = gcrTabla;
                    objSia.gclListaIndices = gclListaIndices;
                    objSia.fcvBuscar();
                    #endregion
                    break;

                case "CIT": //Modulo Citas medicas
                    #region Modulo Citas medicas
                    CIT_Browser02 objCit = new CIT_Browser02();
                    objCit.gobjForm = this;
                    objCit.gcrCodigoModulo = gcrCodigoModulo;
                    objCit.gcrTabla = gcrTabla;
                    objCit.gclListaIndices = gclListaIndices;
                    objCit.fcvBuscar();
                    #endregion
                    break;

                case "ADM": //Modulo Admision
                    #region Modulo Admision
                    ADM_Browser02 objAdm = new ADM_Browser02();
                    objAdm.gobjForm = this;
                    objAdm.gcrCodigoModulo = gcrCodigoModulo;
                    objAdm.gcrTabla = gcrTabla;
                    objAdm.gclListaIndices = gclListaIndices;
                    objAdm.fcvBuscar();
                    #endregion
                    break;

                case "HCL": //Modulo Historias Clinicas
                    #region Modulo Admision
                    HCL_Browser02 objHcl = new HCL_Browser02();
                    objHcl.gobjForm = this;
                    objHcl.gcrCodigoModulo = gcrCodigoModulo;
                    objHcl.gcrTabla = gcrTabla;
                    objHcl.gclListaIndices = gclListaIndices;
                    objHcl.fcvBuscar();
                    #endregion
                    break;

                case "CAR": //Modulo Cartera
                    #region Modulo Cartera
                    CAR_Browser02 objCar = new CAR_Browser02();
                    objCar.gobjForm = this;
                    objCar.gcrCodigoModulo = gcrCodigoModulo;
                    objCar.gcrTabla = gcrTabla;
                    objCar.gclListaIndices = gclListaIndices;
                    objCar.fcvBuscar();
                    #endregion
                    break;

                case "CTO": //Modulo Contrato
                    #region Modulo Cartera
                    CTO_Browser02 objCto = new CTO_Browser02();
                    objCto.gobjForm = this;
                    objCto.gcrCodigoModulo = gcrCodigoModulo;
                    objCto.gcrTabla = gcrTabla;
                    objCto.gclListaIndices = gclListaIndices;
                    objCto.fcvBuscar();
                    #endregion
                    break;

            }

        }

        /// <summary>
        /// Metodos para controles en el Formulario
        /// </summary>
        private void DataGridKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                fcvRetornoInterface(fcrCodigoSeleccionado());
            }
        }

        /// <summary>
        /// al hacer Doble clic en DataGRid
        /// </summary>
        private void MouseDbClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            fcvRetornoInterface(fcrCodigoSeleccionado());
        }

        /// <summary>
        /// Clic en Boton Cancelar
        /// </summary>
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// para saber si el texto de algun control cambio y luego
        /// ejecutar de nuevo el filtro
        /// </summary>
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            cmdAceptar.IsEnabled = false;
            switch (gcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    #region Configuracion para modulo hospitalizacion
                    HOS_Browser02 obj = new HOS_Browser02();
                    obj.gobjForm = this;
                    obj.gcrCodigoModulo = gcrCodigoModulo;
                    obj.gcrTabla = gcrTabla;
                    obj.gcrFiltroTabla = gcrFiltroTabla; 
                    obj.gclListaIndices = gclListaIndices;
                    obj.fcvBuscar();
                    #endregion
                    break;

                case "SIA": //Modulo Configuracion asistencial
                    #region Modulo Configuracion asistencial
                    SIA_Browser02 objSia = new SIA_Browser02();
                    objSia.gobjForm = this;
                    objSia.gcrCodigoModulo = gcrCodigoModulo;
                    objSia.gcrTabla = gcrTabla;
                    objSia.gcrFiltroTabla = gcrFiltroTabla; 
                    objSia.gclListaIndices = gclListaIndices;
                    objSia.fcvBuscar();
                    #endregion
                    break;

                case "CIT": //Modulo Citas medicas
                    #region Modulo Citas medicas
                    CIT_Browser02 objCit = new CIT_Browser02();
                    objCit.gobjForm = this;
                    objCit.gcrCodigoModulo = gcrCodigoModulo;
                    objCit.gcrTabla = gcrTabla;
                    objCit.gcrFiltroTabla = gcrFiltroTabla; 
                    objCit.gclListaIndices = gclListaIndices;
                    objCit.fcvBuscar();
                    #endregion
                    break;

                case "ADM": //Modulo Admision
                    #region Modulo Admision
                    ADM_Browser02 objAdm = new ADM_Browser02();
                    objAdm.gobjForm = this;
                    objAdm.gcrCodigoModulo = gcrCodigoModulo;
                    objAdm.gcrTabla = gcrTabla;
                    objAdm.gclListaIndices = gclListaIndices;
                    objAdm.gcrFiltroTabla = gcrFiltroTabla; 
                    objAdm.fcvBuscar();
                    #endregion
                    break;

                case "HCL": //Modulo Historias Clinicas
                    #region Modulo Admision
                    HCL_Browser02 objHcl = new HCL_Browser02();
                    objHcl.gobjForm = this;
                    objHcl.gcrCodigoModulo = gcrCodigoModulo;
                    objHcl.gcrTabla = gcrTabla;
                    objHcl.gclListaIndices = gclListaIndices;
                    objHcl.gcrFiltroTabla = gcrFiltroTabla;
                    objHcl.fcvBuscar();
                    #endregion
                    break;

                case "CAR": //Modulo Cartera
                    #region Modulo Cartera
                    CAR_Browser02 objCar = new CAR_Browser02();
                    objCar.gobjForm = this;
                    objCar.gcrCodigoModulo = gcrCodigoModulo;
                    objCar.gcrTabla = gcrTabla;
                    objCar.gclListaIndices = gclListaIndices;
                    objCar.gcrFiltroTabla = gcrFiltroTabla;
                    objCar.fcvBuscar();
                    #endregion
                    break;

                case "CTO": //Modulo Contrato
                    #region Modulo Cartera
                    CTO_Browser02 objCto = new CTO_Browser02();
                    objCto.gobjForm = this;
                    objCto.gcrCodigoModulo = gcrCodigoModulo;
                    objCto.gcrTabla = gcrTabla;
                    objCto.gclListaIndices = gclListaIndices;
                    objCto.gcrFiltroTabla = gcrFiltroTabla;
                    objCto.fcvBuscar();
                    #endregion
                    break;

            }
        }

        /// <summary>
        /// Se ejecuta al Seleccionar un indice de la lista
        /// </summary>
        private void fcvSeleccionIndice(object sender, SelectionChangedEventArgs e)
        {
            AuxBrowser02.ComboItem elemento = (AuxBrowser02.ComboItem)e.AddedItems[0];
            switch (gcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    #region Configuracion para modulo hospitalizacion
                    HOS_Browser02 obj = new HOS_Browser02();
                    obj.gobjForm = this;
                    obj.gcrCodigoModulo = gcrCodigoModulo;
                    obj.gcrTabla = gcrTabla;
                    obj.gclListaIndices = gclListaIndices;
                    obj.fcvReferenciaObjetos();
                    obj.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;

                case "SIA": //Modulo Configuracion asistencial
                    #region Modulo Configuracion asistencial
                    SIA_Browser02 objSia = new SIA_Browser02();
                    objSia.gobjForm = this;
                    objSia.gcrCodigoModulo = gcrCodigoModulo;
                    objSia.gcrTabla = gcrTabla;
                    objSia.gclListaIndices = gclListaIndices;
                    objSia.fcvReferenciaObjetos();
                    objSia.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;

                case "CIT": //Modulo Citas medicas
                    #region Modulo Citas medicas
                    CIT_Browser02 objCit = new CIT_Browser02();
                    objCit.gobjForm = this;
                    objCit.gcrCodigoModulo = gcrCodigoModulo;
                    objCit.gcrTabla = gcrTabla;
                    objCit.gclListaIndices = gclListaIndices;
                    objCit.fcvReferenciaObjetos();
                    objCit.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;

                case "ADM": //Modulo Admision
                    #region Modulo Admision
                    ADM_Browser02 objAdm = new ADM_Browser02();
                    objAdm.gobjForm = this;
                    objAdm.gcrCodigoModulo = gcrCodigoModulo;
                    objAdm.gcrTabla = gcrTabla;
                    objAdm.gclListaIndices = gclListaIndices;
                    objAdm.fcvReferenciaObjetos();
                    objAdm.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;


                case "HCL": //Modulo Historias Clinicas
                    #region Modulo Admision
                    HCL_Browser02 objHcl = new HCL_Browser02();
                    objHcl.gobjForm = this;
                    objHcl.gcrCodigoModulo = gcrCodigoModulo;
                    objHcl.gcrTabla = gcrTabla;
                    objHcl.gclListaIndices = gclListaIndices;
                    objHcl.fcvReferenciaObjetos();
                    objHcl.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;

                case "CAR": //Modulo Cartera
                    #region Modulo Cartera
                    CAR_Browser02 objCar = new CAR_Browser02();
                    objCar.gobjForm = this;
                    objCar.gcrCodigoModulo = gcrCodigoModulo;
                    objCar.gcrTabla = gcrTabla;
                    objCar.gclListaIndices = gclListaIndices;
                    objCar.fcvReferenciaObjetos();
                    objCar.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;

                case "CTO": //Modulo Contrato
                    #region Modulo Cartera
                    CTO_Browser02 objCto = new CTO_Browser02();
                    objCto.gobjForm = this;
                    objCto.gcrCodigoModulo = gcrCodigoModulo;
                    objCto.gcrTabla = gcrTabla;
                    objCto.gclListaIndices = gclListaIndices;
                    objCto.fcvReferenciaObjetos();
                    objCto.fcvActivarTab("Tab" + elemento.TotalCampos.ToString());
                    #endregion
                    break;
            }
        }

        /// <summary>
        /// Se ejecuta al que la grilla toma el enfoque
        /// Para activar el boton aceptar
        /// </summary>
        private void objDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            cmdAceptar.IsEnabled = true;
        }

        private void btnCerrar_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void fcvMoverFocus(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }

        private void fcvMoverFocus_aGrid(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int obj = objDataGrid.Items.Count;
                if (obj > 0)
                {
                    object objItem = objDataGrid.Items[0];
                    objDataGrid.SelectedItem = objItem;
                    ListViewItem item = objDataGrid.ItemContainerGenerator.ContainerFromItem(objDataGrid.SelectedItem) as ListViewItem;
                    item.Focus();
                }
                else
                {
                    ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
                }
            }
        }
        #endregion
        #region fcvTouchEnterTeclado: mostrar teclado virtual
        private void fcvTouchEnterTeclado(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                TextBox lobTexto = sender as TextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
            }
        }
        #endregion
    }
}
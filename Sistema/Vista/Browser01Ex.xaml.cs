using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using Datos.Modelos;
using System.Text;
using System;
using Sistema.Utilidades;
using Sistema.Clases;
using System.Windows.Media;
using Microsoft.Win32;

namespace Sistema.Vista
{
    /// <summary>
    /// Clase para mostrar un Browser de Busqueda
    /// </summary>
    public partial class Browser01Ex : Window
    {
        public string gcrCodigoReturn = string.Empty;
        public string gcrCodigoModulo;
        public string gcrTabla;
        public string gcrFiltroTabla;

        #region Configuracion Inicial
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public Browser01Ex(string tcrCodigoModulo, string tcrTabla, string tcrFiltroTabla, string tcrTituloVentana)
        {
            InitializeComponent();

            txtblockTitulo.Text = tcrTituloVentana;
            txtFiltroDatos.Focus();
            gcrCodigoModulo = tcrCodigoModulo;
            gcrTabla = tcrTabla;
            gcrFiltroTabla = tcrFiltroTabla;

            #region Configuracion Inicial
            switch (tcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    HOS_Browser01 lobjHos = new HOS_Browser01();
                    lobjHos.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "FCM": //Facturacion Servicios Medicos
                    FCM_Browser01 lobjFcm = new FCM_Browser01();
                    lobjFcm.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "ADM": //Modulo Admision
                    ADM_Browser01 lobjAdm = new ADM_Browser01();
                    lobjAdm.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "CIT": //Modulo Citas medicas
                    CIT_Browser01 lobjCit = new CIT_Browser01();
                    lobjCit.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "SIA": //Modulo Configuraion Asistencial
                    SIA_Browser01 lobjSia = new SIA_Browser01();
                    lobjSia.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "SYS": //Modulo Sistema
                    SYS_Browser01 lobjSys = new SYS_Browser01();
                    lobjSys.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "SIS": //Modulo Configuracion Sistema
                    SIS_Browser01 lobjSis = new SIS_Browser01();
                    lobjSis.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "CON": //Modulo Contabilidad
                    CON_Browser01 lobjCon = new CON_Browser01();
                    lobjCon.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "CTO": //Modulo Contrato
                    CTO_Browser01 lobjCto = new CTO_Browser01();
                    lobjCto.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "SSP": //Salud publica
                    SSP_Browser01 lobjSsp = new SSP_Browser01();
                    lobjSsp.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "GRP": //Gestor de reportes
                    GRP_Browser01 lobjGrp = new GRP_Browser01();
                    lobjGrp.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "HCL": //Historias Clínicas
                    HCL_Browser01 lobjHcl = new HCL_Browser01();
                    lobjHcl.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "ODN": // Odontologia
                    ODN_Browser01 lobjOdn = new ODN_Browser01();
                    lobjOdn.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "INV": // Inventarios
                    INV_Browser01 lobjInv = new INV_Browser01();
                    lobjInv.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "FAR": // Farmacia
                    FAR_Browser01 lobjFar = new FAR_Browser01();
                    lobjFar.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "MCI": // Meci
                    MCI_Browser01 lobjMci = new MCI_Browser01();
                    lobjMci.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "CAR": // Cartera
                    CAR_Browser01 lobjCar = new CAR_Browser01();
                    lobjCar.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

                case "EST": // Estadisticas
                    EST_Browser01 lobjEst = new EST_Browser01();
                    lobjEst.ConfigInicial(objDataGrid, objGridView, gcrTabla, "", gcrFiltroTabla);
                    break;

            }
            #endregion

            fcvResizePantalla();
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;

        }
        #endregion
        #region fcvResizePantalla: Tamaños de pantalla y objetos
        //------------------------------------------------------------
        // Evento para detectar el cambio de Resolucion de Pantalla en Windows
        //------------------------------------------------------------
        /// <summary>
        /// <para>Detectar el cambio de Resolucion de Pantalla en Windows y realizar ajustes</para>
        /// </summary>
        void SystemEvents_ReajustarVistaPantalla(object sender, EventArgs e)
        {
            fcvResizePantalla();
        }
        public void fcvResizePantalla()
        {
            var lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            this.Width = (lduBarraWidth * 80 / 100);
            this.Left = (lduBarraWidth * 10 / 100);
        }
        #endregion
        //------------------------------------------------------------
        // BUSCAR EN NOTIFICACIONES
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChangedEx);
            lobControl.txtBuscar.TouchEnter  += new EventHandler<TouchEventArgs>(fcvTouchEnterTeclado);
            lobControl.txtBuscar.KeyDown     += new KeyEventHandler(txtFiltroDatos_KeyDown);
            FocusManager.SetFocusedElement(this, lobControl.txtBuscar);

        }
        private void fcvFiltroTextChangedEx(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            this.txtFiltroDatos.Text = lobTexto.Text;
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
                    HOS_Browser01 lobjHos = new HOS_Browser01();
                    lcrReturnCodigo = lobjHos.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "FCM": //Facturacion Servicios Medicos
                    FCM_Browser01 lobjFcm = new FCM_Browser01();
                    lcrReturnCodigo = lobjFcm.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "ADM": //Modulo Admision
                    ADM_Browser01 lobjAdm = new ADM_Browser01();
                    lcrReturnCodigo = lobjAdm.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "CIT": //Modulo citas medicas
                    CIT_Browser01 lobjCit = new CIT_Browser01();
                    lcrReturnCodigo = lobjCit.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "SIA": //Modulo configuracion aistencial
                    SIA_Browser01 lobjSia = new SIA_Browser01();
                    lcrReturnCodigo = lobjSia.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "SYS": //Modulo sistema
                    SYS_Browser01 lobjSys = new SYS_Browser01();
                    lcrReturnCodigo = lobjSys.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "SIS": //Modulo configuracion del sistema general
                    SIS_Browser01 lobjSis = new SIS_Browser01();
                    lcrReturnCodigo = lobjSis.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "CON": //Modulo Contabilidad
                    CON_Browser01 lobjCon = new CON_Browser01();
                    lcrReturnCodigo = lobjCon.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "CTO": //Modulo Contrato
                    CTO_Browser01 lobjCto = new CTO_Browser01();
                    lcrReturnCodigo = lobjCto.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "SSP": //Salud publica
                    SSP_Browser01 lobjSsp = new SSP_Browser01();
                    lcrReturnCodigo = lobjSsp.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "GRP": //Gestor de reportes
                    GRP_Browser01 lobjGrp = new GRP_Browser01();
                    lcrReturnCodigo = lobjGrp.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "HCL": //Historias Clínicas
                    HCL_Browser01 lobjHcl = new HCL_Browser01();
                    lcrReturnCodigo = lobjHcl.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "ODN": // Odontologia
                    ODN_Browser01 lobjOdn = new ODN_Browser01();
                    lcrReturnCodigo = lobjOdn.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "INV": // Inventario
                    INV_Browser01 lobjInv = new INV_Browser01();
                    lcrReturnCodigo = lobjInv.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "FAR": // Farmacia
                    FAR_Browser01 lobjFar = new FAR_Browser01();
                    lcrReturnCodigo = lobjFar.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "MCI": // Meci
                    MCI_Browser01 lobjMci = new MCI_Browser01();
                    lcrReturnCodigo = lobjMci.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "CAR": // Cartera
                    CAR_Browser01 lobjCar = new CAR_Browser01();
                    lcrReturnCodigo = lobjCar.fcrRegistroSelect(objDataGrid, gcrTabla);
                    break;

                case "EST": // Estadisticas
                    EST_Browser01 lobjEst = new EST_Browser01();
                    lcrReturnCodigo = lobjEst.fcrRegistroSelect(objDataGrid, gcrTabla);
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
            HOS_Browser01 obj = new HOS_Browser01();
            obj.fcvBuscar(objDataGrid, gcrTabla, "", txtFiltroDatos.Text);
            ((Button)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
        }

        /// <summary>
        /// Metodos para controles en el Formulario
        /// </summary>
        private void DataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                fcvRetornoInterface(fcrCodigoSeleccionado());
            }
        }

        /// <summary>
        /// al hacer Doble clic en DataGRid
        /// </summary>
        private void MouseDbClick(object sender, MouseButtonEventArgs e)
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

        #endregion
        #region Metodos Varios
        /// <summary>
        /// Metodos Varios
        /// </summary>
        private void btnCerrar_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void txtFiltroDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int obj = objDataGrid.Items.Count;
                if (obj > 0)
                {
                    object objItem = objDataGrid.Items[0];
                    objDataGrid.SelectedItem = objItem;
                    ListViewItem item = objDataGrid.ItemContainerGenerator.ContainerFromItem(objDataGrid.SelectedItem) as ListViewItem;
                    if (item != null)
                    {
                        item.Focus();
                    }
                }
                else
                {
                    ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
                }
            }
        }

        private void objDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            cmdAceptar.IsEnabled = true;
        }
        #endregion
        #region Metodos Filtro
        /// <summary>
        /// para saber si el texto de algun control cambio y luego
        /// ejecutar de nuevo el filtro
        /// </summary>
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            switch (gcrCodigoModulo.ToUpper())
            {
                case "HOS": //Modulo Hospitalizacion
                    cmdAceptar.IsEnabled = false;
                    HOS_Browser01 objHos = new HOS_Browser01();
                    objHos.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "FCM": //Modulo Facturacion
                    cmdAceptar.IsEnabled = false;
                    FCM_Browser01 objFcm = new FCM_Browser01();
                    objFcm.FcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "ADM": //Modulo Admision
                    cmdAceptar.IsEnabled = false;
                    ADM_Browser01 objAdm = new ADM_Browser01();
                    objAdm.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "CIT": //Modulo Citas
                    cmdAceptar.IsEnabled = false;
                    CIT_Browser01 objCit = new CIT_Browser01();
                    objCit.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "SIA": //Modulo Asistencial
                    cmdAceptar.IsEnabled = false;
                    SIA_Browser01 objSia = new SIA_Browser01();
                    objSia.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "SIS": //Modulo Sistema general
                    cmdAceptar.IsEnabled = false;
                    SIS_Browser01 objSis = new SIS_Browser01();
                    objSis.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "SYS": //Modulo Sistema
                    cmdAceptar.IsEnabled = false;
                    SYS_Browser01 objSys = new SYS_Browser01();
                    objSys.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "CON": //Modulo Contabilidad
                    cmdAceptar.IsEnabled = false;
                    CON_Browser01 objCon = new CON_Browser01();
                    objCon.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "CTO": //Modulo Contrato
                    cmdAceptar.IsEnabled = false;
                    CTO_Browser01 objCto = new CTO_Browser01();
                    objCto.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "SSP": //Salud publica
                    cmdAceptar.IsEnabled = false;
                    SSP_Browser01 lobjSsp = new SSP_Browser01();
                    lobjSsp.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "GRP": //Gestor reportes
                    cmdAceptar.IsEnabled = false;
                    GRP_Browser01 lobjGrp = new GRP_Browser01();
                    lobjGrp.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "HCL": //Historias Clinicas
                    cmdAceptar.IsEnabled = false;
                    HCL_Browser01 lobjHcl = new HCL_Browser01();
                    lobjHcl.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "ODN": // Odontologia
                    cmdAceptar.IsEnabled = false;
                    ODN_Browser01 lobjOdn = new ODN_Browser01();
                    lobjOdn.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "INV": // Inventario
                    cmdAceptar.IsEnabled = false;
                    INV_Browser01 lobjInv = new INV_Browser01();
                    lobjInv.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "FAR": // Farmacia
                    cmdAceptar.IsEnabled = false;
                    FAR_Browser01 lobjFar = new FAR_Browser01();
                    lobjFar.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "MCI": // Meci
                    cmdAceptar.IsEnabled = false;
                    MCI_Browser01 lobjMci = new MCI_Browser01();
                    lobjMci.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "CAR": // Cartera
                    cmdAceptar.IsEnabled = false;
                    CAR_Browser01 lobjCar = new CAR_Browser01();
                    lobjCar.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

                case "EST": // Estadisticas
                    EST_Browser01 lobjEst = new EST_Browser01();
                    lobjEst.fcvBuscar(objDataGrid, gcrTabla, txtFiltroDatos.Text, gcrFiltroTabla);
                    break;

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
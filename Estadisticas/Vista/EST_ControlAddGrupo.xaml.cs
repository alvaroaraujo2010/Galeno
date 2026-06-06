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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema.Utilidades;
using Sistema.Clases;
using Estadisticas.Utilidades;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_ControlAddGrupo.xaml
    /// </summary>
    public partial class ControlAddGrupo : UserControl
    {
        //-------------------------------------------------
        // Variables de gestion
        //-------------------------------------------------
        #region Variables de gestion 
        /// <summary>
        /// <para>Nombre campo en clase (TmpGestionItem -> "ItemllaveRegistro"/"ItemAliasSql"/"ItemNombre")</para>
        /// <para>que se se devolvera como dato de gestion</para>
        /// </summary>
        public String lcrItemValorSelect = "ItemNombre";
        /// <summary>
        /// <para>"1" = No Incluye codigo identificador "2" = Incluye codigo identificador</para>
        /// </summary>
        //String lcrTipo = "1";
        /// <summary>
        /// <para>Lista de item/campos a cargar en la vista con todas las propiedades del objeto segun</para>
        /// <para>estructura completa de la clase TmpGestionItem</para>
        /// </summary>
        public List<TmpGestionItem> lstItemsListaGeneral;
        /// <summary>
        /// <para>Lista de item/campos para cargar en combobox</para>
        /// </summary>
        public List<TmpListaComboBox> lstItemsComboBox;
        /// <summary>
        /// <para>Lista de item/campos seleccionados en la vista</para>
        /// </summary>
        public List<TmpListCondicion> lstListaCondiciones = new List<TmpListCondicion>();
        /// <summary>
        /// <para>Contador para generar id unico de registros cargados en lista de seleccion</para>
        /// </summary>
        public int gnuContRegistros = 0;
        #endregion
        //-------------------------------------------------
        // Valores de Retorno para gestion desde externa
        //-------------------------------------------------
        #region Variables de utilidad retorno para gestion externa
        /// <summary>
        /// <para>Devuelve una String que contiene la expresion que suma conversiones de campos para generar llave</para>
        /// <para>ejemplo: "NombreEmpleado.Trin()+ValorSalario.ToString().Trim()"</para>
        /// </summary>
        public String gcrRetornoStrinLlaveGrupo = String.Empty;
        #endregion

        public bool llgObjetosCargados = false;

        public ControlAddGrupo()
        {
            InitializeComponent();
            llgObjetosCargados = true;
            fcvLimpiarVistaObjetos();
        }
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox desde lista general
        #region IniciarComboBoxListaGeneral: Generar Listas de Opciones Combobox desde temporal general
        /// <summary>
        /// <para>Generar Listas de Opciones Combobox desde temporal general</para>
        /// <para>tcrItemValorSelect: Nombre del campo en la clase (TmpGestionItem -> lista itemas) que se se devolvera</para>
        /// <para>como valor seleccionado ejemplo: "Itemllave"/"ItemAliasSql"/"ItemNombre" </para>
        /// <para>tcrTipo:"1" = No Incluye codigo identificador "2" = Incluye codigo identificador</para>
        /// </summary>
        public void IniciarComboBoxListaGeneral(List<TmpGestionItem> tlsListaItems, String tcrItemValorSelect, String tcrTipo)
        {
            try
            {
                lstItemsComboBox = CrtForms.flsCargarListaComboBox(tlsListaItems, tcrItemValorSelect, tcrTipo);

                this.cboListItems.ItemsSource   = lstItemsComboBox;
                this.cboListItems.SelectedIndex = Convert.ToInt32(lstItemsComboBox[0].IdIndice);
                this.cboListItems.IsEnabled = true;
                this.cmdAddItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBoxListaGeneral");
            }
        }
        #endregion
        // Generar Listas de Opciones Combobox desde lista seleccion
        #region IniciarComboBoxDesdeSelect: Generar Listas de Opciones Combobox desde lista seleccion
        /// <summary>
        /// <para>Generar Listas de Opciones Combobox desde temporal seleccion</para>
        /// <para>tcrItemValorSelect: Nombre del campo en la clase (TmpGestionItem -> lista itemas) que se se devolvera</para>
        /// <para>como valor seleccionado ejemplo: "Itemllave"/"ItemAliasSql"/"ItemNombre" </para>
        /// <para>tcrTipo:"1" = No Incluye codigo identificador "2" = Incluye codigo identificador</para>
        /// </summary>
        public void IniciarComboBoxDesdeSelect(List<TmpListaSeleccion> tlsListaSeleccion, String tcrTipo)
        {
            try
            {
                int i = 0;
                string lcrValorSel = String.Empty;
                string lcrNombreOp = String.Empty;
                TmpGestionItem lobRegTmp = null;
                lstItemsComboBox = new List<TmpListaComboBox>();
                fcvLimpiarVistaObjetos();

                foreach (var lobReg in tlsListaSeleccion)
                {
                    //- Valor Seleccion
                    lcrValorSel = lobReg.ValorSeleccion;
                    lobRegTmp = fobBuscarItemListaGeneral(lcrValorSel);

                    if (lobRegTmp!= null)
                    {
                        //- Titulo
                        lcrNombreOp = tcrTipo == "2" ? lcrValorSel + " - " + lobRegTmp.ItemTitulo : lobRegTmp.ItemTitulo;
                        // Generar la lista
                        lstItemsComboBox.Add(new TmpListaComboBox()
                        {
                            IdIndice = i.ToString().Trim(),
                            NombreOpcion = lcrNombreOp,
                            ValorSeleccion = lcrValorSel,
                        });
                        i++;
                    }
                }
                // referenciar en objeto
                if (tlsListaSeleccion.Count > 0)
                {
                    this.cboListItems.ItemsSource = lstItemsComboBox;
                    this.cboListItems.SelectedIndex = Convert.ToInt32(lstItemsComboBox[0].IdIndice);
                    this.cboListItems.IsEnabled = true;
                    this.cmdAddItem.IsEnabled = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBoxDesdeSelect");
            }
        }
        #endregion
        // Limpiar vista de objetos
        #region fcvLimpiarVista: Limpiar vista de objetos
        /// <summary>
        /// <para>Limpiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVistaObjetos()
        {
            try
            {
                this.cboListItems.ItemsSource = null;
                this.cboListItems.SelectedIndex = 0;
                this.cboListItems.IsEnabled = false;
                this.cmdAddItem.IsEnabled = false;
                lstListaCondiciones = new List<TmpListCondicion>();
                //- ojo el proceso de limpiar objetos requiere quitar referencia a eventos desde tempral de objetos
                this.wraAgrupar.Children.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " // STACKTRACE: " + ex.StackTrace, "Objeto ControlAddGrupo error metodo: fcvLimpiarVistaObjetos");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar Objetos TextBox  y CombBox Relacionados
        //-------------------------------------------------
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    ComboBox lobCombo = (ComboBox)sender;

                    switch (lobCombo.Name)
                    {
                        case "cboListItems":
                             if (lobCombo.SelectedIndex >= 0)
                             {
                                 this.txtIdItemSelect.Text = lstItemsComboBox[lobCombo.SelectedIndex].ValorSeleccion;
                                 fcvBuscarItemEnListaSeleccion(this.txtIdItemSelect.Text);
                             }
                             break;

                        case "XX":
                            //this.txtIdItemSelect.Text = lstItemsComboBox[lobCombo.SelectedIndex].ValorSeleccion;
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // AGREGAR/ELIMINAR ELEMENTOS DE LA LISTA
        //-------------------------------------------------
        #region cmdAddItem_Click: Adicionar registro en lista 
        /// <summary>
        /// <para>Agregar item a la lista</para>
        /// </summary>
        private void cmdAddItem_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si ya existe en la lista 
            var lobReg = fobBuscarItemEnListaSeleccion(this.txtIdItemSelect.Text);
            // Add cuando no existe 
            if (lobReg == null)
            {
                flgAddItemLista(this.txtIdItemSelect.Text);
                fcvBuscarItemEnListaSeleccion(this.txtIdItemSelect.Text);
                // Generar Reporte de cambios y  expresiones de retornos
                fcvGenReporteCambioControl("ADD");
            }
        }
        #endregion
        #region flgAddItemLista: Crear y adicionar objetos a la lista de seleccion
        /// <summary>
        /// <para>Agregar item a la lista</para>
        /// </summary>
        private bool flgAddItemLista(String tcrIdUnicoItem)
        {
            var llReturn = false;
            var lobRegItem = fobBuscarItemListaGeneral(tcrIdUnicoItem);
            if (lobRegItem != null)
            {
                llReturn = true;
                var lobItem = new ControlAddGrupoDe();
                gnuContRegistros++;

                lobItem.ItemllaveRegistro = "R" + gnuContRegistros.ToString().Trim();
                lobItem.gcrNombreItem = tcrIdUnicoItem;
                lobItem.txtDescripcion.Text = lobRegItem.ItemTitulo;
                lobItem.cmdQuitar.Click += new RoutedEventHandler(cmdEliminar_Click);

                lstListaCondiciones.Add(new TmpListCondicion { ItemllaveRegistro = lobItem.ItemllaveRegistro, 
                                                               ItemNombre = tcrIdUnicoItem, RefObjeto = lobItem });

                this.wraAgrupar.Children.Add(lobItem);

            }
            return llReturn;
        }
        #endregion
        #region cmdEliminar_Click Eliminar item de la lista
        /// <summary>
        /// <para>Eliminar item de la lista</para>
        /// </summary>
        private void cmdEliminar_Click(object sender, RoutedEventArgs e)
        {
            var lobBotn = sender as Button;
            var lobGrid = lobBotn.Parent as Grid;
            var lobCntr = lobGrid.Parent as ControlAddGrupoDe;

            // Buscar en temporal de seleccion agrupar para eliminar el registro
            var lobReg = fobBuscarItemEnListaSeleccion(lobCntr.gcrNombreItem);
            if (lobReg != null) { lstListaCondiciones.Remove(lobReg); }

            // Quitar los eventos asociados al bonton eliminar del objeto
            lobBotn.Click -= new RoutedEventHandler(cmdEliminar_Click);
            this.wraAgrupar.Children.Remove(lobCntr);

            fcvBuscarItemEnListaSeleccion(this.txtIdItemSelect.Text);

            // Generar Reporte de cambios y  expresiones de retornos
            fcvGenReporteCambioControl("DEL");
        }
        #endregion
        //-------------------------------------------------
        // Consultar temporales
        //-------------------------------------------------
        #region fobBuscarItemEnListaSeleccion: Buscar item en lista de condiciones seleccionadas
        /// <summary>
        /// <para>Buscar item en lista de condiciones seleccionadas vista</para>
        /// </summary>
        private TmpListCondicion fobBuscarItemEnListaSeleccion(String tcrIdUnicoItem)
        {
            TmpListCondicion lobReg = null;

            if (lstListaCondiciones != null)
            {
                lobReg = lstListaCondiciones.FirstOrDefault(x => x.ItemNombre == tcrIdUnicoItem);
            }
            return lobReg;
        }
        #endregion
        #region fcvBuscarItemEnListaSeleccion: Buscar item activo en lista de condiciones seleccionadas
        /// <summary>
        /// <para>Buscar item activo en lista de condiciones seleccionadas para activar boton vista</para>
        /// </summary>
        private void fcvBuscarItemEnListaSeleccion(String tcrIdUnicoItem)
        {
            var lobReg = fobBuscarItemEnListaSeleccion(tcrIdUnicoItem);
            this.cmdAddItem.IsEnabled = lobReg == null ? true : false;
        }
        #endregion
        #region fobBuscarItemListaGeneral: Buscar item en lista general
        /// <summary>
        /// <para>Buscar en lista general de items con todas las propiedades</para>
        /// </summary>
        private TmpGestionItem fobBuscarItemListaGeneral(String tcrIdUnicoItem)
        {
            TmpGestionItem lobReg = null;

            if (lcrItemValorSelect == "ItemllaveRegistro")
            {
                lobReg = lstItemsListaGeneral.FirstOrDefault(x => x.Itemllave == tcrIdUnicoItem);
            }
            else if (lcrItemValorSelect == "ItemAliasSql")
            {
                lobReg = lstItemsListaGeneral.FirstOrDefault(x => x.ItemAliasSql == tcrIdUnicoItem);
            }
            else // ItemNombre
            {
                lobReg = lstItemsListaGeneral.FirstOrDefault(x => x.ItemNombre == tcrIdUnicoItem);
            }
            return lobReg;
        }
        #endregion
        //-------------------------------------------------
        // Generar Expresiones de retorno
        //-------------------------------------------------
        #region fcvGenReporteCambioControl: Generar reporte del cambio
        /// <summary>
        /// <para>Generar reporte de cambios segun movimiento realizado en el UserControl</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrTipoCambio: "ADD"/"DEL"</para>
        /// </summary>
        public void fcvGenReporteCambioControl(String tcrTipoCambio)
        {
            this.txtControlAddGrupo.Text = "NA";
            // Generar expresiones de retorno utilidad
            gcrRetornoStrinLlaveGrupo = fcrGenExpresionllaveGrupo();
            this.txtControlAddGrupo.Text = tcrTipoCambio;
        }
        #endregion
        #region fcrGenExpresionllaveGrupo: Generar expresion llave agrupar 
        /// <summary>
        /// <para>Generar una String que suma los elementos seleccionados para usar como llave</para>
        /// <para>Devuelve una expresion tal como esta: "Campo3.Trim()+Campo2.ToString().Trim()"</para>
        /// </summary>
        public String fcrGenExpresionllaveGrupo()
        {
            var lcrLlaveGrupo = String.Empty;
            var lcrItem = String.Empty;

            foreach (var lobReg in lstListaCondiciones)
            {
                lcrItem = fcrGenerarExpresionTextoItem(lobReg.ItemNombre);
                if (!String.IsNullOrWhiteSpace(lcrItem))
                {
                    lcrLlaveGrupo += String.IsNullOrWhiteSpace(lcrLlaveGrupo) ? lcrItem : " + " + lcrItem;
                }
            }
            return lcrLlaveGrupo;
        }
        #endregion
        #region fcrGenerarExpresionTextoItem: Generar expresion llave agrupar
        /// <summary>
        /// <para>Generar la expresion de conversion para mostrar el dato contenido en campo</para>
        /// </summary>
        public String fcrGenerarExpresionTextoItem(String tcrIdUnicoItem)
        {
            var lcrString = String.Empty;
            var lobReg = fobBuscarItemListaGeneral(tcrIdUnicoItem);

            if (lobReg != null)
            {
                var lcrTipoDato = lobReg.ItemTipoDato.ToUpper();
                lcrString = Funciones.fcrGenCodConvertirTipoATipoTexto(tcrIdUnicoItem, lcrTipoDato);
            }
            return lcrString;
        }
        #endregion
    }
}

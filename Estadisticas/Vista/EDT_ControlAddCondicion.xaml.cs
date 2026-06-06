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
using Datos.Modelos;
using Sistema.Clases;
using Estadisticas.Utilidades;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_ControlAddCondicion.xaml
    /// </summary>
    public partial class ControlAddCondicion : UserControl
    {
        //-------------------------------------------------
        // Variables de gestion
        //-------------------------------------------------
        #region Variables de gestion
        /// <summary>
        /// <para>Tipo de lenguaje para el cual se generarn las expresiones condicionales</para>
        /// <para>"EF"= EnttityFramework Linq  "CS"= Lenguaje C# "SQL"=MySql Sql Server y otros</para>
        /// </summary>
        public String gcrTipoLenguajeExpresion = "EF";
        /// <summary>
        /// <para>Todas las expesiones evaluables lista para ejecutar</para>
        /// </summary>
        public String gcrExpresionEvaluable = String.Empty;
        /// <summary>
        /// <para>Nombre campo en clase (TmpGestionItem -> "ItemllaveRegistro"/"ItemAliasSql"/"ItemNombre")</para>
        /// <para>que se se devolvera como dato de gestion</para>
        /// </summary>
        public String gcrItemValorSelect = "ItemNombre";
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
        /// <para>Lista de condicionales para generar </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> lstCondicionesComboBox;
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

        public ControlAddCondicion()
        {
            InitializeComponent();
            llgObjetosCargados = true;
            fcvLimpiarVistaObjetos();
            IniciarComboBox();
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

                this.cboListItems.ItemsSource = lstItemsComboBox;
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

                    if (lobRegTmp != null)
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
            catch (Exception ex)
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
                // Limpiar combobox campos
                this.cboListItems.ItemsSource = null;
                this.cboListItems.SelectedIndex = 0;
                this.cboListItems.IsEnabled = false;
                this.cmdAddItem.IsEnabled = false;
                // Limpiar ComboBox condiciones
                //this.cboListCondiciones.ItemsSource = null;
                //this.cboListCondiciones.SelectedIndex = 0;
                //lstListaCondiciones = new List<TmpListCondicion>();
                //- ojo el proceso de limpiar objetos requiere quitar referencia a eventos desde tempral de objetos
                this.wraCondiciones.Children.Clear();
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
                                lobCombo.SelectedIndex = lobCombo.SelectedIndex <= 0 ? 0 : lobCombo.SelectedIndex;
                                this.txtIdItemSelect.Text = lstItemsComboBox[lobCombo.SelectedIndex].ValorSeleccion;
                            }
                            break;

                        case "cboListCondiciones":
                            if (lobCombo.SelectedIndex >= 0)
                            {
                                lobCombo.SelectedIndex = lobCombo.SelectedIndex <= 0 ? 0 : lobCombo.SelectedIndex;
                                this.txtListCondiciones.Text = lstCondicionesComboBox[lobCombo.SelectedIndex].ValorSeleccion;
                            }
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // TIPO FILTRO RIPS
                //-------------------------------------------------
                #region Tipo Filtro
                string lcrG11Seleccion = "IGUAL,MAYOR,MENOR,MAYORQUE,MENORQUE,CONTIENE,DIFERENTE";
                string lcrG11Descripcion = "Es Igual,Mayor,Menor,Mayor que,Menor que,Contiene,Diferente";
                lstCondicionesComboBox = new List<CrtForms.ListaComboBox>();
                lstCondicionesComboBox = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboListCondiciones.ItemsSource = lstCondicionesComboBox;
                this.cboListCondiciones.SelectedIndex = Convert.ToInt32(lstCondicionesComboBox[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
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
            flgAddItemLista(this.txtIdItemSelect.Text, this.txtListCondiciones.Text, this.txtValor.Text);
            // Generar Reporte de cambios y  expresiones de retornos
            gcrExpresionEvaluable = fcrGenerarListaCondicionesEvaluables();
            fcvGenReporteCambioControl("ADD");
        }
        #endregion
        #region flgAddItemLista: Crear y adicionar objetos a lista de condiciones
        /// <summary>
        /// <para>Agregar item a la lista</para>
        /// </summary>
        private bool flgAddItemLista(String tcrIdUnicoItem, String tcrIdCondicional, String tcrValorCondicion)
        {
            var llReturn = false;
            var lobRegItem = fobBuscarItemListaGeneral(tcrIdUnicoItem);

            if (lobRegItem != null)
            {
                llReturn = true;
                var lcrConectorLogico = String.Empty;
                var lcrExprEvaluable = String.Empty;
                var lobItem = new ControlAddGrupoDe();
                lobItem.Width = 320;
                gnuContRegistros++;

                lobItem.ItemllaveRegistro = "R" + gnuContRegistros.ToString().Trim();
                lobItem.gcrNombreItem = tcrIdUnicoItem;
                lobItem.cmdQuitar.Click += new RoutedEventHandler(cmdEliminar_Click);
                lobItem.txtDescripcion.Text = fcrGenExpresionTextual(tcrIdUnicoItem, tcrIdCondicional, tcrValorCondicion);
                // Agregar conector logico al final AND por ahora
                //flgAgregarQuitarConectorLogico("ADD", " && ");
                flgAgregarQuitarConectorLogico("ADD", " || ");
                // Gerara la verdadera expresion que se evaluara para consultas Sql/c#/EnttityFrameWork
                lcrExprEvaluable = fcrGenExpresionLenguaje(tcrIdUnicoItem, tcrIdCondicional, tcrValorCondicion);
                // agregar al temporal
                lstListaCondiciones.Add(new TmpListCondicion
                {
                    ItemllaveRegistro = lobItem.ItemllaveRegistro,
                    ItemNombre = tcrIdUnicoItem,
                    RefObjeto = lobItem,
                    ValorCondicion = tcrValorCondicion,
                    ExpresionEvaluable = lcrExprEvaluable,
                });
                this.wraCondiciones.Children.Add(lobItem);
            }
            return llReturn;
        }
        #endregion
        #region fcrGenExpresionTextual: Generar titulo para expresion textual
        /// <summary>
        /// <para>Generar titulo para expresion textual para la vista en objeto</para>
        /// </summary>
        private String fcrGenExpresionTextual(String tcrIdUnicoItem, String tcrIdCondicional, String tcrValorCondicion)
        {
            var lcrReturn = String.Empty;
            var lobRegItem = fobBuscarItemListaGeneral(tcrIdUnicoItem);
            var lobRegCond = fobBuscarItemEnCondicionales(tcrIdCondicional);

            if (lobRegItem != null && lobRegCond != null)
            {
                lcrReturn = lobRegItem.ItemTitulo + "<" + lobRegCond.NombreOpcion + "> " + tcrValorCondicion;
            }
            return lcrReturn;
        }
        #endregion
        #region fcrGenExpresionLenguaje: Generar la expresion evaluable para el lenguaje
        /// <summary>
        /// <para>Generar la expresion evaluable para el lenguaje: C#,SQL/EnttityFrameWork</para>
        /// </summary>
        private String fcrGenExpresionLenguaje(String tcrIdUnicoItem, String tcrIdCondicional, String tcrValorCondicion)
        {
            var lcrIdUnicoItem = tcrIdUnicoItem;
            var lcrReturn = String.Empty;
            var lcrValorCondicion = tcrValorCondicion;
            var lobRegItem = fobBuscarItemListaGeneral(lcrIdUnicoItem);
            var lobRegCond = fobBuscarItemEnCondicionales(tcrIdCondicional);
            var lcrCondici = fcrConvertirCondicionalLenguaje(tcrIdCondicional);

            if (lobRegItem != null && lobRegCond != null && !String.IsNullOrWhiteSpace(lcrCondici))
            {
                lcrValorCondicion = fcrComplementarValorCondicion(lcrValorCondicion, lobRegItem.ItemTipoDato);
                if (gcrTipoLenguajeExpresion == "EF" && lcrCondici == "Contains")
                {
                    lcrValorCondicion = ".Contains(" + lcrValorCondicion + ")";
                    lcrReturn = lcrIdUnicoItem + lcrValorCondicion;
                }
                else
                {
                    if (gcrTipoLenguajeExpresion == "EF")
                    {
                        lcrReturn = lobRegItem.ItemTabla + "." + lcrIdUnicoItem.ToLower() + lcrCondici + lcrValorCondicion;
                    }
                    else 
                    {
                        lcrReturn = lcrIdUnicoItem + lcrCondici + lcrValorCondicion;
                    }
                }
            }
            return lcrReturn;
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
            flgAgregarQuitarConectorLogico("DEL", "");

            // Quitar los eventos asociados al bonton eliminar del objeto
            lobBotn.Click -= new RoutedEventHandler(cmdEliminar_Click);
            this.wraCondiciones.Children.Remove(lobCntr);

            fcvBuscarItemEnListaSeleccion(this.txtIdItemSelect.Text);

            // Generar Reporte de cambios y  expresiones de retornos
            gcrExpresionEvaluable = fcrGenerarListaCondicionesEvaluables();
            fcvGenReporteCambioControl("DEL");
        }
        #endregion
        #region flgAgregarQuitarConectorLogico: Generar titulo para expresion textual
        /// <summary>
        /// <para>Agrega el conector logico (AND/OR) al final de la ultima condcion existente</para>
        /// <para>en la lista de condiciones</para>
        /// </summary>
        private bool flgAgregarQuitarConectorLogico(String tcrTipoAccion, String tcrConectorLogico)
        {
            var llgReturn = false;
            if (lstListaCondiciones.Count > 0)
            {
                // Recorrer hasta llegar al ultimo
                var lobRegRef = new TmpListCondicion();
                foreach (var lobReg in lstListaCondiciones)
                {
                    lobRegRef = lobReg;
                }
                llgReturn = true;
                if (tcrTipoAccion == "ADD")
                {
                    lobRegRef.ConectorLogico = tcrConectorLogico;
                }
                else
                {
                    lobRegRef.ConectorLogico = String.Empty;
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcrConvertirCondicionalLenguaje: Convierte el condicional al lenguaje requerido
        /// <summary>
        /// <para>Convierte el condicional al lenguaje requerido: C#,SQL/EnttityFrameWork</para>
        /// </summary>
        private String fcrConvertirCondicionalLenguaje(String tcrIdCondicional)
        {
            var lcrReturn = String.Empty;

            switch (gcrTipoLenguajeExpresion)
            {
                case "EF": // EnttityFrameWork Linq

                    #region EnttityFrameWork Linq
                    switch (tcrIdCondicional)
                    {
                        case "IGUAL":
                            lcrReturn = " == ";
                            break;

                        case "MAYOR":
                            lcrReturn = " > ";
                            break;

                        case "MENOR":
                            lcrReturn = " < ";
                            break;

                        case "MAYORIGUAL":
                            lcrReturn = " >= ";
                            break;

                        case "MENORIGUAL":
                            lcrReturn = " <= ";
                            break;

                        case "CONTIENE":
                            lcrReturn = "Contains";
                            break;

                        case "DIFERENTE":
                            lcrReturn = " != ";
                            break;
                    }
                    break;
                    #endregion

            }
            return lcrReturn;
        }
        #endregion
        #region fcrComplementarValorCondicion: Complementar el valor de la condicion
        /// <summary>
        /// <para>Complementar el valor condicion dependiendo del tipo de dato para agregar comillas</para>
        /// </summary>
        private String fcrComplementarValorCondicion(String tcrValorCondicion, String tcrTipoDato)
        {
            var lcrComilla = '\u0022'; // ASCII o Unicode de las comillas dobles 
            var lcrReturn = String.Empty;
                switch (gcrTipoLenguajeExpresion)
                {
                    case "EF": // EnttityFrameWork Linq
                        lcrReturn = Funciones.flgExisteElemento(tcrTipoDato, ",", "INT,NUMERO,NUMERICO,ENTERO,DOBLE,DOUBLE,TIME,HORA,DECIMAL") ?
                                                                tcrValorCondicion : lcrComilla + tcrValorCondicion + lcrComilla;
                        break;
                }

            return lcrReturn;
        }
        #endregion
        #region fcrGenerarListaCondicionesEvaluables: Sumar lista de condiciones en una String
        /// <summary>
        /// <para>Sumar lista de condiciones en una sola expresion tipo String</para>
        /// </summary>
        private String fcrGenerarListaCondicionesEvaluables()
        {
            var lcrReturn = String.Empty;
            if (lstListaCondiciones.Count > 0)
            {
                // Recorrer hasta llegar al ultimo
                foreach (var lobReg in lstListaCondiciones)
                {
                    lcrReturn += lobReg.ExpresionEvaluable + lobReg.ConectorLogico;
                }
            }
            return lcrReturn;
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
            //this.cmdAddItem.IsEnabled = lobReg == null ? true : false;
        }
        #endregion
        #region fobBuscarItemListaGeneral: Buscar item en lista general
        /// <summary>
        /// <para>Buscar en lista general de items con todas las propiedades</para>
        /// </summary>
        private TmpGestionItem fobBuscarItemListaGeneral(String tcrIdUnicoItem)
        {
            TmpGestionItem lobReg = null;

            if (gcrItemValorSelect == "ItemllaveRegistro")
            {
                lobReg = lstItemsListaGeneral.FirstOrDefault(x => x.Itemllave == tcrIdUnicoItem);
            }
            else if (gcrItemValorSelect == "ItemAliasSql")
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
        #region fobBuscarItemEnCondicionales: Buscar item en lista de condicionales
        /// <summary>
        /// <para>Buscar item en lista de condicionales</para>
        /// </summary>
        private CrtForms.ListaComboBox fobBuscarItemEnCondicionales(String tcrIdUnicoItem)
        {
            CrtForms.ListaComboBox lobReg = null;

            if (lstListaCondiciones != null)
            {
                lobReg = lstCondicionesComboBox.FirstOrDefault(x => x.ValorSeleccion == tcrIdUnicoItem);
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
            this.txtControlAddCondicion.Text = "NA";
            // Generar expresiones de retorno utilidad
            gcrRetornoStrinLlaveGrupo = fcrGenExpresionllaveGrupo();
            this.txtControlAddCondicion.Text = tcrTipoCambio;
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
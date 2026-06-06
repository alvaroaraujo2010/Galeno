using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics;
using Sistema.Vista;

namespace Sistema.Utilidades
{
    //------------------------------------------------
    // Clase para Implementacion de interface tipo Metro
    //------------------------------------------------
    #region IUMetro Controles de Formularios
    public class IUMetro
    {
        //-----------------------------------
        //- Referencias
        //-----------------------------------
        #region para Cargar lista de indices
        public Tiles01[] garRefTiles01;
        public Tiles02[] garRefTiles02;
        public WrapPanel[] garRefWPGrupos;
        public int gnuTotalTiles = 0;
        public int gnuTotalGrupos = 0;
        private double gnuPosVistaGrupo = 0;
        public Dictionary<string, string[]> larDiccAux;
        // Array de tipo Diccionario Auxiliar para actualizar.
        #endregion
        //------------------------------------------------------------
        // fcvDefinirArrayTiles(): Definir cual array de referencias 
        //------------------------------------------------------------
        #region fcvDefinirArrayTiles(): Mostrar Tiles tipo sistema
        public void fcvDefinirArrayTiles(ref Dictionary<string, string[]> tarDiccionarioVista, String tcrTipoTiles)
        {
            var lnuTotElem = tarDiccionarioVista.Count(p => !string.IsNullOrWhiteSpace(p.Key));

            switch (tcrTipoTiles)
            {
                case "TILES01": // Tiles tipo menu del sistema (imagen, titulo)
                    garRefTiles01 = new Tiles01[lnuTotElem];
                    break;

                case "TILES02": // Tiles tipo Horizontal para Citas medicas
                    garRefTiles02 = new Tiles02[lnuTotElem];
                    break;
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvVistaMetroTiles(): Mostrar los Tiles en pantalla
        //------------------------------------------------------------
        #region fcvVistaMetroTiles(): Mostrar los Tiles en pantalla
        /// <summary>
        /// <para>fcvMostrarTiles()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para mostrar los tiles en el browser metro organizados y
        /// agrupados segun el el componente del Diccionario en el orden tnuColGrupo
        /// <para>PARAMETROS:</para>
        /// <para>tarDiccionarioVista:
        /// Estructura Tipo Dictionary<string, string[]> que contiene los datos y 
        /// parametros necesarios para los Tiles</para>
        /// <para>tobMetroStackPanel:
        /// referencia al StackPanel browser del formulario </para>
        /// <para>tcrTipoVista:
        /// Tipo vista del browser "LISTA/GRUPO"</para>
        /// <para>tcrTipoTiles:
        /// Tipo de tiles segun modelos existentes "1,2,3,4,5..."</para>
        /// <para>tnuColGrupoCodigo:
        /// Columna del Diccionario que sera utlizada como codigo interno de grupos en vista</para>
        /// <para>tnuColGrupoTitulo:
        /// Columna del Diccionario que sera utlizada como titulo de grupos en vista </para>
        /// </summary>
        public void fcvVistaMetroTiles(ref Dictionary<string, string[]> tarDiccionarioVista,
                                        ref StackPanel tobMetroStackPanel, ref Dictionary<string, double> tarDiccPosGrupo,
                                        string tcrTipoVista, string tcrTipoTiles, int tnuColGrupoCodigo, int tnuColGrupoTitulo)
        {

            int lnuColGrupoCodigo = tnuColGrupoCodigo - 1;
            int lnuColGrupoTitulo = tnuColGrupoTitulo - 1;
            String lcrGrupoAux = String.Empty;
            fcvDefinirArrayTiles(ref tarDiccionarioVista, tcrTipoTiles);
            tobMetroStackPanel.Children.Clear();

            if (tcrTipoVista == "GRUPO") // Generar Array de grupos
            {
                #region Grupo
                String lcrListGrupos = String.Empty;
                foreach (KeyValuePair<string, string[]> lobReg in tarDiccionarioVista)
                {
                    String lcrValor = lobReg.Value[lnuColGrupoCodigo].Trim();
                    if (String.IsNullOrWhiteSpace(lcrListGrupos))
                    {
                        lcrListGrupos = lcrValor;
                    }
                    else
                    {
                        if (Funciones.flgExisteElemento(lcrValor, ",", lcrListGrupos) == false)
                        {
                            lcrListGrupos = lcrListGrupos + "," + lcrValor;
                        }
                    }
                }
                String lcrTituloGrupo = String.Empty;
                String[] larGrupos = lcrListGrupos.Split(',');
                gnuTotalGrupos = larGrupos.Length;
                garRefWPGrupos = new WrapPanel[gnuTotalGrupos]; // Genera en garRefWPGrupos  una cantidad de posiciones <gnuTotalGrupos> para referenciar grupos
                int lnuIndiceGrupo = 0;
                foreach (String lobGrupo in larGrupos)
                {
                    var lobDiccGrupo = tarDiccionarioVista.Where(k => k.Value[lnuColGrupoCodigo] == lobGrupo);
                    if (lobDiccGrupo.Count() > 0)
                    {
                        WrapPanel lobTileWrapPPal = new WrapPanel();
                        lobTileWrapPPal.Name = "G" + lobGrupo;
                        lobTileWrapPPal.Orientation = Orientation.Vertical;
                        garRefWPGrupos[lnuIndiceGrupo] = lobTileWrapPPal;

                        fcvAgregarTiles(lobDiccGrupo, ref lobTileWrapPPal, ref tarDiccPosGrupo,
                                        tcrTipoTiles, tnuColGrupoCodigo, tnuColGrupoTitulo, lnuIndiceGrupo);
                        tobMetroStackPanel.Children.Add(lobTileWrapPPal);
                        lnuIndiceGrupo++;
                    }
                }
                #endregion
            }
            else if (tcrTipoVista == "LISTA")
            {
                #region Lista
                gnuTotalGrupos = 1;
                garRefWPGrupos = new WrapPanel[gnuTotalGrupos];
                WrapPanel lobTileWrapPPal = new WrapPanel();
                lobTileWrapPPal.Name = "G001";
                lobTileWrapPPal.Orientation = Orientation.Vertical;
                garRefWPGrupos[0] = lobTileWrapPPal; // Referencia en array de grupos

                fcvAgregarTiles(tarDiccionarioVista, ref lobTileWrapPPal, ref tarDiccPosGrupo,
                                tcrTipoTiles, tnuColGrupoCodigo, tnuColGrupoTitulo, 0);
                tobMetroStackPanel.Children.Add(lobTileWrapPPal);
                #endregion
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvAgregarTiles(): Mostrar los Tiles en pantalla
        //------------------------------------------------------------
        #region fcvAgregarTiles(): Agregar Tiles a Vista Metro
        public void fcvAgregarTiles(IEnumerable<KeyValuePair<string, string[]>> tarDiccionarioVista,
                                    ref WrapPanel tobTileWrapPanelPpal, ref Dictionary<string, double> tarDiccPosGrupo,
                                    String tcrTipoTiles, int tnuColGrupoCodigo, int tnuColGrupoTitulo, int tnuIndiceGrupo)
        {
            int lnuColGrupoCodigo = tnuColGrupoCodigo - 1;
            int lnuColGrupoTitulo = tnuColGrupoTitulo - 1;
            String lcrTitulo = "A";
            bool llgGenTitulo = false;

            var lnuTotElem = tarDiccionarioVista.Count(p => !string.IsNullOrWhiteSpace(p.Key));
            var lnuTotCol = (int)((lnuTotElem - 1) / 4) + 1;// parte entera
            //tileWrapPanel.Width = (lnuTotCol * 160) + ((lnuTotCol-1) * 10);

            Grid lobGridContenedor = new Grid();

            WrapPanel lobTileWrapPanel = new WrapPanel();
            lobTileWrapPanel.Orientation = Orientation.Vertical;
            lobTileWrapPanel.Margin = new Thickness(0, 25, 30, 0);

            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccionarioVista)
            {
                if (tnuColGrupoTitulo > 0 && llgGenTitulo == false)
                {
                    //- Generar el titulo del grupo la primera vez en el ciclo
                    TituloGrupoTiles lobTxtTitulo = new TituloGrupoTiles();

                    lobTxtTitulo.txtTitulo.Text      = lobReDicc.Value[lnuColGrupoTitulo];
                    lcrTitulo                        = lobReDicc.Value[lnuColGrupoTitulo];
                    lobTxtTitulo.VerticalAlignment   = VerticalAlignment.Top;
                    lobTxtTitulo.HorizontalAlignment = HorizontalAlignment.Left;
                    lobTxtTitulo.Margin              = new Thickness(0);

                    lobGridContenedor.Children.Add(lobTxtTitulo);
                }
                llgGenTitulo = true; // para no generar mas titulo grupo

                switch (tcrTipoTiles)
                {
                    case "TILES01": // Tiles tipo menu del sistema (imagen, titulo 
                        fcvTiles01(lobReDicc, ref lobTileWrapPanel, tnuIndiceGrupo);
                        break;

                    case "TILES02":
                        fcvTiles02(lobReDicc, ref lobTileWrapPanel, tnuIndiceGrupo);
                        break;
                }
            }
            lobGridContenedor.Children.Add(lobTileWrapPanel);
            tobTileWrapPanelPpal.Children.Add(lobGridContenedor);

            fcvAddPosWrPanelGrupo(ref tarDiccPosGrupo, lcrTitulo, ref tobTileWrapPanelPpal, lobTileWrapPanel.Children.Count);
        }
        #endregion
        //------------------------------------------------------------
        // fcvTiles01(): Tiles Tipo sistema
        //------------------------------------------------------------
        #region fcvTiles01(): Mostrar Tiles tipo sistema
        /// <summary>
        /// <para>fcvTiles01()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para mostrar los tiles tipo sistema 
        /// <para>PARAMETROS DICCIONARIO TILES:</para>
        /// <para>1 - Indice </para>
        /// <para>2 - Codigo del Item </para>
        /// <para>3 - Titulo </para>
        /// <para>4 - Imagen icono </para>
        /// <para>5 - Imagen Fondo del Tiles </para>
        /// <para>6 - Ruta de las Imagenes </para>
        /// <para>7... N - Columnas datos adicionales</para>
        /// </summary>
        public void fcvTiles01(KeyValuePair<string, string[]> tobReDicc, ref WrapPanel tobTileWrapPanel, int tnuIndiceGrupo)
        {

            Tiles01 newTile = new Tiles01();

            newTile.gnuIndiceGrupo = tnuIndiceGrupo;
            newTile.gnuIndice = Convert.ToInt32(tobReDicc.Value[0].Trim());
            newTile.gcrCodigoItem = tobReDicc.Value[1].Trim(); // Codigo del Item
            newTile.gcrTitulo = tobReDicc.Value[2].Trim(); // Titulo
            newTile.gcrImgIcono = tobReDicc.Value[3].Trim(); // Icono
            newTile.gcrImgTiles = tobReDicc.Value[4].Trim(); // Imagen fondo
            newTile.gcrRutImagen = tobReDicc.Value[5].Trim(); // Ruta de imagenes
            newTile.gcrComponente = tobReDicc.Value[8].Trim(); // codigo del componente para ejecutar desde menu principal
            newTile.Name = "T" + newTile.gcrCodigoItem;

            String lobIcono = newTile.gcrRutImagen + newTile.gcrImgIcono; // /Sistema;component/Imagenes/
            String lobTiles = newTile.gcrRutImagen + newTile.gcrImgTiles;
            var lobIcono1 = new BitmapImage(new Uri(lobIcono, UriKind.RelativeOrAbsolute));
            var lobTiles1 = new BitmapImage(new Uri(lobTiles, UriKind.RelativeOrAbsolute));

            gnuTotalTiles++;
            //garRefTiles01[gnuTotalTiles - 1] = newTile;
            garRefTiles01[newTile.gnuIndice] = newTile;

            newTile.Icono.Source = lobIcono1;
            newTile.TileIcon.Source = lobTiles1;
            newTile.TileTxtBlck.Text = newTile.gcrTitulo;
            newTile.Margin = new Thickness(-5, -7, 0, -22);
            tobTileWrapPanel.Children.Add(newTile);
        }
        #endregion
        //------------------------------------------------------------
        // fcvTiles01(): Tiles Tipo sistema
        //------------------------------------------------------------
        #region fcvTiles02(): Mostrar Tiles para citas
        /// <summary>
        /// <para>fcvTiles01()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Funcion para mostrar los tiles tipo sistema 
        /// <para>PARAMETROS DICCIONARIO TILES:</para>
        /// <para>1 - Indice </para>
        /// <para>2 - Codigo del Item </para>
        /// <para>3 - Titulo </para>
        /// <para>4 - Imagen icono </para>
        /// <para>5 - Imagen Fondo del Tiles </para>
        /// <para>6 - Ruta de las Imagenes </para>
        /// <para>7... N - Columnas datos adicionales</para>
        /// </summary>
        public void fcvTiles02(KeyValuePair<string, string[]> tobReDicc, ref WrapPanel tobTileWrapPanel, int tnuIndiceGrupo)
        {

            Tiles02 newTile = new Tiles02();

            newTile.gnuIndiceGrupo = tnuIndiceGrupo;
            newTile.gnuIndice = Convert.ToInt32(tobReDicc.Value[0].Trim());
            newTile.gcrCodigoItem = tobReDicc.Value[1].Trim(); // Codigo del Item
            newTile.gcrTexto1 = tobReDicc.Value[2].Trim(); // Titulo
            newTile.gcrTexto2 = tobReDicc.Value[3].Trim(); // Titulo
            newTile.gcrTexto3 = tobReDicc.Value[4].Trim(); // Titulo
            newTile.gcrTexto4 = tobReDicc.Value[5].Trim(); // Titulo
            newTile.gcrTexto5 = tobReDicc.Value[6].Trim(); // Contador 1
            newTile.gcrTexto6 = tobReDicc.Value[7].Trim(); // Contador 2
            newTile.gcrTexto7 = tobReDicc.Value[8].Trim(); // Contador 2
            newTile.gcrImgIcono = tobReDicc.Value[12].Trim(); // Icono
            newTile.gcrImgTiles = tobReDicc.Value[13].Trim(); // Imagen fondo
            newTile.gcrImgCapa  = tobReDicc.Value[14].Trim(); // Imagen Capa inferior
            newTile.gcrRutImagen = tobReDicc.Value[15].Trim(); // Ruta de imagenes
            newTile.Name = "T" + newTile.gcrCodigoItem;

            String lobIcono = newTile.gcrRutImagen + newTile.gcrImgIcono; // /Sistema;component/Imagenes/
            String lobTiles = newTile.gcrRutImagen + newTile.gcrImgTiles;
            String lobCapa  = newTile.gcrRutImagen + newTile.gcrImgCapa;
            var lobIcono1   = new BitmapImage(new Uri(lobIcono, UriKind.RelativeOrAbsolute));
            var lobTiles1   = new BitmapImage(new Uri(lobTiles, UriKind.RelativeOrAbsolute));
            var lobCapa1    = new BitmapImage(new Uri(lobCapa, UriKind.RelativeOrAbsolute));

            gnuTotalTiles++;
            garRefTiles02[newTile.gnuIndice] = newTile;

            newTile.Icono.Source    = lobIcono1;
            newTile.TileIcon.Source = lobTiles1;
            newTile.Capa.Source     = lobCapa1;
            newTile.txtTexto1.Text  = newTile.gcrTexto1;
            newTile.txtTexto2.Text  = newTile.gcrTexto2;
            newTile.txtTexto3.Text  = newTile.gcrTexto3;
            newTile.txtTexto4.Text  = newTile.gcrTexto4;
            newTile.txtTexto5.Text  = newTile.gcrTexto5;
            newTile.txtTexto6.Text  = newTile.gcrTexto6;
            newTile.txtTexto7.Text  = newTile.gcrTexto7;

            if (newTile.gcrTexto6 == "0" || String.IsNullOrWhiteSpace(newTile.gcrTexto6)) 
            { newTile.txtTexto6.Visibility = Visibility.Collapsed; }

            if (newTile.gcrTexto7 == "0" || String.IsNullOrWhiteSpace(newTile.gcrTexto7))
            { newTile.txtTexto7.Visibility = Visibility.Collapsed; }

            newTile.Margin = new Thickness(-2, 0, -2, 0);
            tobTileWrapPanel.Children.Add(newTile);
        }
        #endregion
        //------------------------------------------------------------
        // fcvAddPosWrPanelGrupo(): Guardar la posicion del grupo
        //------------------------------------------------------------
        #region fcvAddPosWrPanelGrupo(): Guardar la posicion del grupo
        /// <summary>
        /// Determina la ubicación probable de un WrapPanelGrupo que se añade
        /// a MetroStackPanel (asumiendo que el MetroStackPanel sea
        /// como un Canvas).
        /// </summary>
        private void fcvAddPosWrPanelGrupo(ref Dictionary<string, double> tarDiccPosGrupo,
                                           String tcrTitulo, ref WrapPanel tobWrapPanel, int tnuTilesGrupo)
        {
            if (tarDiccPosGrupo.Count() == 0)
            {
                tarDiccPosGrupo.Add(tcrTitulo.ToLower(), -20);
            }
            else
            {
                tarDiccPosGrupo.Add(tcrTitulo.ToLower(), gnuPosVistaGrupo);
            }
            // Aumenta el valor de wrapPanelX según corresponda.
            //6 es el margen derecho de un Tile.
            if (tnuTilesGrupo <= 3)
            {
                gnuPosVistaGrupo += ((110 + 6) + 18);
            }
            else
            {
                // Ojo 110 es un valor problable segun el ancho de un tipo de tiles
                Double lduCount = tnuTilesGrupo;
                Double lduNumeroColumnas = Math.Ceiling(lduCount / 4);
                Double lduPosx = (lduNumeroColumnas * 110) + (lduNumeroColumnas * 6) + 18;
                gnuPosVistaGrupo += lduPosx;
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvIrPosVistaGrupo() para mover vista hacia un grupo
        //------------------------------------------------------------
        #region fcvIrPosVistaGrupo() para mover vista hacia un grupo
        /// <summary>
        /// <para>Dependiendo del titulo grupo dado en parametro mover el MetroStackPanel hacia ese</para>
        /// <para>WrapPanel que contiene los tiles requeridos para que esten a la vista.</para>
        /// </summary>
        public static void fcvIrPosVistaGrupo(String tcrTituloGrupo, ref StackPanel tcrMetroStackPanel, ref Dictionary<string, double> tobWrapPosGrupo)
        {
            var llave = tobWrapPosGrupo.FirstOrDefault(k => k.Key.Contains(tcrTituloGrupo.ToLower())).Key;
            if (!String.IsNullOrWhiteSpace(llave))
            {
                DoubleAnimationUsingKeyFrames doubleAnim = new DoubleAnimationUsingKeyFrames();
                double newX = tobWrapPosGrupo[llave];
                doubleAnim.Duration = TimeSpan.FromMilliseconds(1800);

                doubleAnim.KeyFrames.Add(new SplineDoubleKeyFrame(-newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                doubleAnim.FillBehavior = FillBehavior.HoldEnd;
                tcrMetroStackPanel.BeginAnimation(Canvas.LeftProperty, doubleAnim);
                doubleAnim.KeyFrames.Clear();
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvIrTopVistaGrupo() Ir al principio del MetroStackpanel
        //------------------------------------------------------------
        #region fcvIrTopVistaGrupo() Ir al principio del MetroStackpanel
        /// <summary>
        /// Ir al principio del MetroStackpanel
        /// </summary>
        public static void fcvIrTopVistaGrupo(ref StackPanel tcrMetroStackPanel, Double tcrPosVista)
        {
            DoubleAnimationUsingKeyFrames doubleAnim = new DoubleAnimationUsingKeyFrames();
            double newX = tcrPosVista;
            doubleAnim.Duration = TimeSpan.FromMilliseconds(1800);
            doubleAnim.KeyFrames.Add(new SplineDoubleKeyFrame(-newX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
            doubleAnim.FillBehavior = FillBehavior.HoldEnd;
            tcrMetroStackPanel.BeginAnimation(Canvas.LeftProperty, doubleAnim);
            doubleAnim.KeyFrames.Clear();
        }
        #endregion
        //------------------------------------------------------------
        // Funciones de Busquedas en Tiles
        //------------------------------------------------------------
        #region FILTRO - Funciones de Busquedas en Tiles
        //------------------------------------------------------------
        // fnuValorPosArrayBusq() Devuelve Valor Posicion 
        // Array Columnas para Busqueda en Diccionario 
        //------------------------------------------------------------
        #region fnuValorPosArrayBusq
        /// <summary>
        /// Devuelve Valor Posicion Array Columnas para Busqueda en Diccionario
        /// </summary>
        public static int fnuValorPosArrayBusq(String[] tarNBuscar, int tnuPosArray)
        {
            var lnuValor = 0;
            if (tnuPosArray <= tarNBuscar.Length)
            {
                lnuValor = Convert.ToInt32(tarNBuscar[tnuPosArray - 1]) - 1;
            }
            return lnuValor;
        }
        #endregion
        //------------------------------------------------------------
        // fcvFiltrarVistaTiles01() filtro Tiles01
        //------------------------------------------------------------
        #region fcvFiltrarVistaTiles01
        /// <summary>
        /// Para realizar filtro en Tiles01 (son los Tiles del menu principal)
        /// Visualiza y/o oculta los grupos o Valdosas que no cumplen con el filtro
        /// </summary>
        public static void fcvFiltrarVistaTiles01(ref Dictionary<string, string[]> tarDiccionarioVista,
                                            ref WrapPanel[] tarRefWPGrupos, ref Tiles01[] tarRefTiles,
                                            String tcrTexto, String tcrColumasBusqueda)
        {
            // columnas para busquedas
            String[] larNBuscar = tcrColumasBusqueda.Split(','); // convertir cadena en array
            int gnuNumColumBusq = larNBuscar.Length;
            int lnuCol1 = fnuValorPosArrayBusq(larNBuscar, 1);
            int lnuCol2 = fnuValorPosArrayBusq(larNBuscar, 2);
            int lnuCol3 = fnuValorPosArrayBusq(larNBuscar, 3);
            int lnuCol4 = fnuValorPosArrayBusq(larNBuscar, 4);
            // Ocultar los grupos 
            int i = 0;
            for (i = 0; i < tarRefWPGrupos.Length; i++)
            {
                tarRefWPGrupos[i].Visibility = Visibility.Collapsed;
            }

            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccionarioVista)
            {
                Tiles01 gobjTiles = tarRefTiles[Convert.ToInt32(lobReDicc.Value[0].Trim())] as Tiles01;
                gobjTiles.Visibility = Visibility.Collapsed;

                if (!string.IsNullOrEmpty(tcrTexto))
                {
                    var llgCumple = false;
                    var lcrTexto = lobReDicc.Value[2].ToLower();
                    switch (gnuNumColumBusq)
                    {
                        case 1: // Busca por una sola columan
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 2:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 3:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol3].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 4:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol3].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol4].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;
                    }
                    if (llgCumple == true)
                    {
                        gobjTiles.Visibility = Visibility.Visible;
                        tarRefWPGrupos[gobjTiles.gnuIndiceGrupo].Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    gobjTiles.Visibility = Visibility.Visible;
                    tarRefWPGrupos[gobjTiles.gnuIndiceGrupo].Visibility = Visibility.Visible;
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvFiltrarVistaTiles02() filtro Tiles02
        //------------------------------------------------------------
        #region fcvFiltrarVistaTiles02
        /// <summary>
        /// Para realizar filtro en Tiles02 (son los Tiles de los menus de citas  y otros)
        /// Visualiza y/o oculta los grupos o Valdosas que no cumplen con el filtro
        /// </summary>
        public static void fcvFiltrarVistaTiles02(ref Dictionary<string, string[]> tarDiccionarioVista,
                                            ref WrapPanel[] tarRefWPGrupos, ref Tiles02[] tarRefTiles,
                                            String tcrTexto, String tcrColumasBusqueda)
        {
            // columnas para busquedas
            String[] larNBuscar = tcrColumasBusqueda.Split(','); // convertir cadena en array
            int gnuNumColumBusq = larNBuscar.Length;
            int lnuCol1 = fnuValorPosArrayBusq(larNBuscar, 1);
            int lnuCol2 = fnuValorPosArrayBusq(larNBuscar, 2);
            int lnuCol3 = fnuValorPosArrayBusq(larNBuscar, 3);
            int lnuCol4 = fnuValorPosArrayBusq(larNBuscar, 4);
            // Ocultar los grupos 
            int i = 0;
            for (i = 0; i < tarRefWPGrupos.Length; i++)
            {
                tarRefWPGrupos[i].Visibility = Visibility.Collapsed;
            }

            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccionarioVista)
            {
                Tiles02 gobjTiles = tarRefTiles[Convert.ToInt32(lobReDicc.Value[0].Trim())] as Tiles02;
                gobjTiles.Visibility = Visibility.Collapsed;

                if (!string.IsNullOrEmpty(tcrTexto))
                {
                    var llgCumple = false;
                    var lcrTexto = lobReDicc.Value[2].ToLower();
                    switch (gnuNumColumBusq)
                    {
                        case 1: // Busca por una sola columan
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 2:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 3:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol3].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;

                        case 4:
                            if (lobReDicc.Value[lnuCol1].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol2].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol3].ToLower().Contains(tcrTexto.ToLower()) ||
                                lobReDicc.Value[lnuCol4].ToLower().Contains(tcrTexto.ToLower()))
                            { llgCumple = true; }
                            break;
                    }
                    if (llgCumple == true)
                    {
                        gobjTiles.Visibility = Visibility.Visible;
                        tarRefWPGrupos[gobjTiles.gnuIndiceGrupo].Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    gobjTiles.Visibility = Visibility.Visible;
                    tarRefWPGrupos[gobjTiles.gnuIndiceGrupo].Visibility = Visibility.Visible;
                }
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // Funciones par Actualizar vista de Tiles
        //------------------------------------------------------------
        #region Funciones par Actualizar vista de Tiles
        //------------------------------------------------------------
        // fcvActualizarTiles02() filtro Tiles02
        //------------------------------------------------------------
        #region fcvActualizarTiles02
        public static void fcvActualizarTiles02(ref Dictionary<string, string[]> tarDiccionarioVista,
                                                ref Dictionary<string, string[]> tarDiccActualizTiles, 
                                                ref Tiles02[] tarRefTiles)
        {
            int lnuPosTile = 0;
            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccActualizTiles)
            {
                var lcrCodigo=lobReDicc.Key.Trim(); // el codigo del item en el tiles
                var lobReg = tarDiccionarioVista.FirstOrDefault(k => k.Key.Trim().Equals(lcrCodigo));
                if (lobReg.Value != null)
                {
                    //var lcrllave = tarDiccionarioVista.FirstOrDefault(k => k.Key.Trim().Equals(lcrCodigo)).Value[0]; // el index en array referencia 
                    var lcrllave = lobReg.Value[0]; // el index en array referencia 
                    if (!String.IsNullOrWhiteSpace(lcrllave))
                    {
                        lnuPosTile = Convert.ToInt32(lcrllave);
                        fcvActualizarVistaTiles02(lobReDicc, ref tarRefTiles, lnuPosTile);
                        //fcvActualizarDiccionario(ref tarDiccionarioVista, lobReDicc);
                    }
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // fcvActualizarVistaTiles02()
        //------------------------------------------------------------
        #region fcvActualizarVistaTiles02(): Actualizar Tiles02
        /// <summary>
        /// <para>fcvTiles01()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Actualizar Tiles que Cambiaron sus valores
        /// </summary>
        //public void fcvActualizarVistaTiles02(KeyValuePair<string, string[]> tobReDicc, ref Tiles02 tobTiles)
        public static void fcvActualizarVistaTiles02(KeyValuePair<string, string[]> tobReDicc, ref Tiles02[] tarRefTiles, int tnuIndex)
        {
            Tiles02 gobjTiles = (Tiles02)tarRefTiles[tnuIndex] as Tiles02;

            gobjTiles.gcrTexto1 = tobReDicc.Value[2].Trim(); // Titulo
            gobjTiles.gcrTexto2 = tobReDicc.Value[3].Trim(); // Titulo
            gobjTiles.gcrTexto3 = tobReDicc.Value[4].Trim(); // Titulo
            gobjTiles.gcrTexto4 = tobReDicc.Value[5].Trim(); // Titulo
            gobjTiles.gcrTexto5 = tobReDicc.Value[6].Trim(); // Contador 1
            gobjTiles.gcrTexto6 = tobReDicc.Value[7].Trim(); // Contador 2
            gobjTiles.gcrTexto7 = tobReDicc.Value[8].Trim(); // Contador 2
            gobjTiles.gcrImgIcono = tobReDicc.Value[12].Trim(); // Icono
            gobjTiles.gcrImgTiles = tobReDicc.Value[13].Trim(); // Imagen fondo
            gobjTiles.gcrImgCapa = tobReDicc.Value[14].Trim(); // Imagen Capa inferior
            gobjTiles.gcrRutImagen = tobReDicc.Value[15].Trim(); // Ruta de imagenes

            String lobIcono = gobjTiles.gcrRutImagen + gobjTiles.gcrImgIcono; // /Sistema;component/Imagenes/
            String lobTiles = gobjTiles.gcrRutImagen + gobjTiles.gcrImgTiles;
            String lobCapa = gobjTiles.gcrRutImagen + gobjTiles.gcrImgCapa;
            var lobIcono1 = new BitmapImage(new Uri(lobIcono, UriKind.RelativeOrAbsolute));
            var lobTiles1 = new BitmapImage(new Uri(lobTiles, UriKind.RelativeOrAbsolute));
            var lobCapa1 = new BitmapImage(new Uri(lobCapa, UriKind.RelativeOrAbsolute));

            gobjTiles.Icono.Source = lobIcono1;
            gobjTiles.TileIcon.Source = lobTiles1;
            gobjTiles.Capa.Source = lobCapa1;
            gobjTiles.txtTexto1.Text = gobjTiles.gcrTexto1;
            gobjTiles.txtTexto2.Text = gobjTiles.gcrTexto2;
            gobjTiles.txtTexto3.Text = gobjTiles.gcrTexto3;
            gobjTiles.txtTexto4.Text = gobjTiles.gcrTexto4;
            gobjTiles.txtTexto5.Text = gobjTiles.gcrTexto5;
            gobjTiles.txtTexto6.Text = gobjTiles.gcrTexto6;
            gobjTiles.txtTexto7.Text = gobjTiles.gcrTexto7;

            if (gobjTiles.gcrTexto6 == "0" || String.IsNullOrWhiteSpace(gobjTiles.gcrTexto6))
            { gobjTiles.txtTexto6.Visibility = Visibility.Collapsed; }

            if (gobjTiles.gcrTexto7 == "0" || String.IsNullOrWhiteSpace(gobjTiles.gcrTexto7))
            { gobjTiles.txtTexto7.Visibility = Visibility.Collapsed; }

        }
        #endregion
        //------------------------------------------------------------
        // fcvActualizarDiccionario()
        //------------------------------------------------------------
        #region fcvActualizarDiccionario(): Actualizar diccionario
        /*
        /// <summary>
        /// <para>fcvActualizarDiccionario()</para>
        /// <para>DESCRIPCIÓN</para>
        /// Actualizar diccionario
        /// </summary>
        public static void fcvActualizarDiccionario(ref Dictionary<string, string[]> tarDiccionarioVista,
                                                    KeyValuePair<string, string[]> tobReDicc)
        {
            var lobReg = tarDiccionarioVista.FirstOrDefault(k => k.Key.Equals(tobReDicc.Key.Trim())); // el index en array referencia 
            var lcrllave = lobReg.Key.Trim(); // el index en array referencia 
            if (!String.IsNullOrWhiteSpace(lcrllave))
            {
                //- Actualizar el diccionario
                tobReDicc.Value[0] = lobReg.Value[0].Trim(); // Index
                tobReDicc.Value[1] = lobReg.Value[1].Trim(); // Codigo del Item
                tobReDicc.Value[16] = lobReg.Value[16].Trim(); // Codigo grupo
                tobReDicc.Value[17] = lobReg.Value[17].Trim(); // Nombre Titulo grupo
                // eliminar el registro 
                tarDiccionarioVista.Remove(lcrllave);
                MessageBox.Show("ELIMINADO " + tarDiccionarioVista.FirstOrDefault(k => k.Key.Equals(tobReDicc.Key.Trim())).Key);
                // add el nuevo
                tarDiccionarioVista.Add(lcrllave, new String[] {tobReDicc.Value[0],
                                            tobReDicc.Value[1],tobReDicc.Value[2],tobReDicc.Value[3],
                                            tobReDicc.Value[4],tobReDicc.Value[5],tobReDicc.Value[6],
                                            tobReDicc.Value[7],tobReDicc.Value[8],tobReDicc.Value[9],
                                            tobReDicc.Value[10],tobReDicc.Value[11],tobReDicc.Value[12],
                                            tobReDicc.Value[13],tobReDicc.Value[14],tobReDicc.Value[15],
                                            tobReDicc.Value[16],tobReDicc.Value[17]});

                MessageBox.Show("ADICIONADO " + tarDiccionarioVista.FirstOrDefault(k => k.Key.Equals(tobReDicc.Key.Trim())).Value[6]);
                //MessageBox.Show("aqui voy ACTUALIZAR  DICCIONARIO " + lcrllave);
            }
        }
        */
        #endregion
        #endregion
    }
    #endregion
}

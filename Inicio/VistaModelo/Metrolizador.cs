using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Inicio.Vista;

namespace Inicio.VistaModelo
{
    class clMetrolizador
    {
        private double wrapPanelX = 0;
        public void DisplayTiles(ref StackPanel metroStackPanel, String tcrModulo)
        {
            //metroStackPanel.Children.Clear();
            String lcrNivel = tcrModulo == "Ppal" ? "1" : "2";
            String[] alphabet = {"a", "b", "c", "d", "e", "f", "g", "h", "i","j", "k", "l", "m", "n", "o", "p", "q", "r",
                                        "s", "t", "u", "v", "w", "x", "y", "z"};
            //String[] lArTipoModulos = { "SYS", "SIS", "ADM" };
            //Coleccion que contiene los elementos a mostrar según el nivel en que se encuentre.
            Dictionary<string, string[]> lArdiccionario = new clrutaseiconos().fcArObtenerRutaseIconos(lcrNivel,"P001");
            // Recorremos en el orden alfabetico y se busca una nueva coleccion con elementos que inicien con la misma letra
            foreach (string s in alphabet)
            {
                string letter = s;
                var coll = lArdiccionario.Where(k => k.Key.StartsWith(letter, true, null));
                if (coll.Count() > 0)
                {
                    // si se encontraron elementos para un mismo grupo, se adicionan al metroStackPanel
                    fcvAgregarTiles(coll, ref metroStackPanel, letter, lcrNivel);
                }
            }
        }
        /// <summary>
        /// Agrega tiles al metroStackPanel agrupados segun la letra con la que comienzan
        /// </summary>
        /// <param name="coll">estructura con elementos de un grupo que se agregará al metroStackPanel</param>
        /// <param name="metroStackPanel"> es el metroStackPanel destino al que se agregarán los elementos</param>
        /// <param name="letter">indica el grupo al que se agregarán los elementos</param>
        /// <param name="tcrNivel">Nivel en que se agregarán</param>
        private void fcvAgregarTiles(IEnumerable<KeyValuePair<string, string[]>> coll, ref StackPanel metroStackPanel, string letter, String tcrNivel)
        {
            WrapPanel tileWrapPPal = new WrapPanel();
            tileWrapPPal.Orientation = Orientation.Vertical;

            TituloGrupoTiles lcrTitulo = new TituloGrupoTiles();
            lcrTitulo.txtTitulo.Text = "Titulo Grupo";
            tileWrapPPal.Children.Add(lcrTitulo);

            WrapPanel tileWrapPanel = new WrapPanel();
            tileWrapPanel.Orientation = Orientation.Vertical;
            tileWrapPanel.Margin = new Thickness(0, 0, 30, 0);
            //var lnuTotElem = coll.Count(p => !string.IsNullOrWhiteSpace(p.Key));
            //var lnuTotCol = (int)((lnuTotElem - 1) / 4) + 1;// parte entera
            //tileWrapPanel.Width = (lnuTotCol * 160) + ((lnuTotCol-1) * 10);

                        
            // Altura justa para que quepan tres tiles verticales
            //tileWrapPanel.Height = (170 * 3) +(3 * 3);
            
            foreach (KeyValuePair<string, string[]> kvp in coll)
            {
                Tile newTile = new Tile();
                if (tcrNivel == "1")
                {
                    newTile.gcrAccion = "AbrirModulo";
                    newTile.gcrModulo = kvp.Value[2];
                    newTile.gcrImgTiles = kvp.Value[3]; // Guardar imagen Tile
                }
                else
                {
                    newTile.gcrAccion = "AbrirFormulario";
                    newTile.gcrComponente = kvp.Value[3];
                    newTile.gcrImgTiles = kvp.Value[4]; // Guardar imagen Tile
                }
                //String lcrrutimg = kvp.Value[0];
                newTile.gcrImgIcono = kvp.Value[1]; 
                String lcrrutimg = "/Sistema;component/Imagenes/" + kvp.Value[1];
                String lcrRutIcon = "/Sistema;component/Imagenes/" + newTile.gcrImgTiles;
                //if (kvp.Value[0].Equals(""))
                if (kvp.Value[1].Equals(""))
                {
                    lcrrutimg = "/Sistema;component/Imagenes/sis_logo40.png";
                }
                var lobTemp = new BitmapImage(new Uri(lcrrutimg, UriKind.RelativeOrAbsolute));
                var lobicon = new BitmapImage(new Uri(lcrRutIcon, UriKind.RelativeOrAbsolute));
                newTile.TileIcon.Source = lobicon;
                newTile.Icono.Source = lobTemp;
                //newTile.TileTxtBlck.Text = kvp.Key;
                newTile.gcrTituloModulo     = kvp.Value[0];
                newTile.TileTxtBlck.Text    = kvp.Value[0];
                newTile.Margin              = new Thickness(-5, -7, 0, -22);
                tileWrapPanel.Children.Add(newTile);
            }
            tileWrapPPal.Children.Add(tileWrapPanel);
            //WrapPanelLocation(letter, tileWrapPanel);
            //metroStackPanel.Children.Add(tileWrapPanel);
            WrapPanelLocation(letter, tileWrapPPal);
            metroStackPanel.Children.Add(tileWrapPPal);
        }
        /// <summary>
        /// Determina la ubicación probable de un WrapPanel que se añade
        /// a MetroStackPanel (asumiendo que el MetroStackPanel sea
        /// como un Canvas).
        /// </summary>
        /// <param name="letter">La letra del alfabeto representa un grupo WrapPanel
        /// en el MetroStackPanel.</param>
        /// <param name="tileWrapPanel">El WrapPanel que será agregado al MetroStackPanel.</param>
        /// <remarks></remarks>
        private void WrapPanelLocation(String letter, WrapPanel tileWrapPanel)
        {
            if (QuickJumper.WrapPanelDi.Count() == 0)
            {
                QuickJumper.WrapPanelDi.Add(letter, 0);
            }
            else
            {
                //QuickJumper.WrapPanelDi.Add(letter, wrapPanelX);
            }

            // Aumenta el valor de wrapPanelX según corresponda.
            //6 es el margen derecho de un Tile.
            if (tileWrapPanel.Children.Count <= 3)
            {
                wrapPanelX += ((110 + 6) + 18);
            }
            else
            {
                Double lnuCount = tileWrapPanel.Children.Count;
                Double numberOfColumns = Math.Ceiling(lnuCount / 3);
                Double x = (numberOfColumns * 110) + (numberOfColumns * 6) + 18;
                wrapPanelX += x;
            }
        }
    }
}

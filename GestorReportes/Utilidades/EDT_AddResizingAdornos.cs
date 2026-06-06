using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace GestorReportes.Utilidades
{
    #region AddResizingAdornos : Colocar Adornos para inicializa reajustes a tamaños de objetos
    /// <summary>
    /// <para>Colocar Adornos para inicializa reajustes a tamaños de objetos</para>
    /// </summary>
    public class AddResizingAdornos : Adorner
    {
        // los Thumbs Objetos (adornos de las esquinas para Manejador con mouse y Resizing
        Thumb lobThumbArribaIzquierda, lobThumbArribaCentro, lobThumbArribaDerecha;
        Thumb lobThumbAbajoIzquierda, lobThumbAbajoCentro, lobThumbAbajoDerecha;
        Thumb lobThumbCentroIzquierda, lobThumbCentroDerecha;
        // Arbol Visual par Alamacenar los adornos 
        public static VisualCollection garArrayVisualChildren;
        public FrameworkElement gobObjetoFondo;
        public Double gduTamañoAdorno = 14;

        //-------------------------------------------------------
        // AddResizingAdornos
        //-------------------------------------------------------
        #region AddResizingAdornos : Inicializa los objetos Adornos para Resize del objeto seleccionado
        /// <summary>
        /// <para>Inicializa los objetos Adornos para Resize del objeto seleccionado</para>
        /// <para>tduTamAdorno: tamaño de los adornos para rezise del objeto</para>
        /// </summary>
        public AddResizingAdornos(UIElement tobObjetoParaAdornar, Double tduTamañoAdorno) : base(tobObjetoParaAdornar)
        {
            //gobObjetoFondo = tobObjetoFondo;
            gduTamañoAdorno = tduTamañoAdorno;
            garArrayVisualChildren = new VisualCollection(this);
            // Generar los Adornos de esquinas
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbArribaIzquierda, Cursors.SizeNWSE);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbArribaCentro, Cursors.SizeNS);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbArribaDerecha, Cursors.SizeNESW);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbAbajoIzquierda, Cursors.SizeNESW);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbAbajoCentro, Cursors.SizeNS);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbAbajoDerecha, Cursors.SizeNWSE);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbCentroIzquierda, Cursors.SizeWE);
            fcvGenerarAdornosEsquinasObjeto(ref lobThumbCentroDerecha, Cursors.SizeWE);
            // Adicionar Manejadores a los objetos para resizing con mouse.
            lobThumbArribaIzquierda.DragDelta += new DragDeltaEventHandler(fcvManejadorArribaIzquierda);
            lobThumbArribaCentro.DragDelta += new DragDeltaEventHandler(fcvManejadorArribaCentro);
            lobThumbArribaDerecha.DragDelta += new DragDeltaEventHandler(fcvManejadorArribaDerecha);
            lobThumbAbajoIzquierda.DragDelta += new DragDeltaEventHandler(fcvManejadorAbajoIzquierda);
            lobThumbAbajoCentro.DragDelta += new DragDeltaEventHandler(fcvManejadorAbajoCentro);
            lobThumbAbajoDerecha.DragDelta += new DragDeltaEventHandler(fcvManejadorAbajoDerecha);
            lobThumbCentroIzquierda.DragDelta += new DragDeltaEventHandler(fcvManejadorCentroIzquierda);
            lobThumbCentroDerecha.DragDelta += new DragDeltaEventHandler(fcvManejadorCentroDerecha);
        }
        #endregion
        //-------------------------------------------------------
        // Manejadores resizing 
        //-------------------------------------------------------
        #region fcvManejadorArribaIzquierda : Manejador resizing Arriba Izquierda
        /// <summary>
        /// <para>fcvManejadorArribaIzquierda: Manejador resizing Arriba Izquierda</para>
        /// </summary>
        void fcvManejadorArribaIzquierda(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = AdornedElement as FrameworkElement; // AdornedElement es un miembro de la clase base: Adorner
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);

            double lduWidthAnterior = lobRefObjetoParaAdornar.Width;
            double lduWidthNuevo = Math.Max(lobRefObjetoParaAdornar.Width - args.HorizontalChange, lobHitThumb.DesiredSize.Width);
            double lduLeftAnterior = Canvas.GetLeft(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Width = lduWidthNuevo;
            Canvas.SetLeft(lobRefObjetoParaAdornar, lduLeftAnterior - (lduWidthNuevo - lduWidthAnterior));

            double lduHeightAnterior = lobRefObjetoParaAdornar.Height;
            double lduHeightNuevo = Math.Max(lobRefObjetoParaAdornar.Height - args.VerticalChange, lobHitThumb.DesiredSize.Height);
            double lduTopAnterior = Canvas.GetTop(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Height = lduHeightNuevo;
            Canvas.SetTop(lobRefObjetoParaAdornar, lduTopAnterior - (lduHeightNuevo - lduHeightAnterior));
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorArribaCentro : Manejador resizing Arriba Centro
        /// <summary>
        /// <para>fcvManejadorArribaCentro: Manejador resizing Arriba Centro</para>
        /// </summary>
        void fcvManejadorArribaCentro(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = AdornedElement as FrameworkElement; // AdornedElement es un miembro de la clase base: Adorner
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);

            double lduHeightAnterior = lobRefObjetoParaAdornar.Height;
            double lduHeightNuevo = Math.Max(lobRefObjetoParaAdornar.Height - args.VerticalChange, lobHitThumb.DesiredSize.Height);
            double lduTopAnterior = Canvas.GetTop(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Height = lduHeightNuevo;
            Canvas.SetTop(lobRefObjetoParaAdornar, lduTopAnterior - (lduHeightNuevo - lduHeightAnterior));
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorArribaDerecha : Manejador resizing Arriba Derecha
        /// <summary>
        /// <para>fcvManejadorArribaDerecha: Manejador resizing Arriba Derecha</para>
        /// </summary>
        void fcvManejadorArribaDerecha(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = this.AdornedElement as FrameworkElement;
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;
            FrameworkElement parentElement = lobRefObjetoParaAdornar.Parent as FrameworkElement;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);

            lobRefObjetoParaAdornar.Width = Math.Max(lobRefObjetoParaAdornar.Width + args.HorizontalChange, lobHitThumb.DesiredSize.Width);

            double lduHeightAnterior = lobRefObjetoParaAdornar.Height;
            double lduHeightNuevo = Math.Max(lobRefObjetoParaAdornar.Height - args.VerticalChange, lobHitThumb.DesiredSize.Height);
            double lduTopAnterior = Canvas.GetTop(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Height = lduHeightNuevo;
            Canvas.SetTop(lobRefObjetoParaAdornar, lduTopAnterior - (lduHeightNuevo - lduHeightAnterior));
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorAbajoIzquierda : Manejador resizing Abajo Izquierda
        /// <summary>
        /// <para>fcvManejadorAbajoIzquierda: Manejador resizing Abajo Izquierda</para>
        /// </summary>
        void fcvManejadorAbajoIzquierda(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = AdornedElement as FrameworkElement;
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);

            lobRefObjetoParaAdornar.Height = Math.Max(args.VerticalChange + lobRefObjetoParaAdornar.Height, lobHitThumb.DesiredSize.Height);

            double lduWidthAnterior = lobRefObjetoParaAdornar.Width;
            double lduWidthNuevo = Math.Max(lobRefObjetoParaAdornar.Width - args.HorizontalChange, lobHitThumb.DesiredSize.Width);
            double lduLeftAnterior = Canvas.GetLeft(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Width = lduWidthNuevo;
            Canvas.SetLeft(lobRefObjetoParaAdornar, lduLeftAnterior - (lduWidthNuevo - lduWidthAnterior));
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorAbajoCentro : Manejador resizing Abajo Centro
        /// <summary>
        /// <para>fcvManejadorAbajoCentro : Manejador resizing Abajo Centro
        /// </summary>
        void fcvManejadorAbajoCentro(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = AdornedElement as FrameworkElement; // AdornedElement es un miembro de la clase base: Adorner
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return; // Regresar si es nulo
            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Height = Math.Max(args.VerticalChange + lobRefObjetoParaAdornar.Height, lobHitThumb.DesiredSize.Height);
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorAbajoDerecha : Manejador resizing Abajo Derecha
        /// <summary>
        /// <para>fcvManejadorAbajoDerecha: Manejador resizing Abajo Derecha</para>
        /// </summary>
        void fcvManejadorAbajoDerecha(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = this.AdornedElement as FrameworkElement;
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;
            FrameworkElement parentElement = lobRefObjetoParaAdornar.Parent as FrameworkElement;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);

            lobRefObjetoParaAdornar.Width = Math.Max(lobRefObjetoParaAdornar.Width + args.HorizontalChange, lobHitThumb.DesiredSize.Width);
            lobRefObjetoParaAdornar.Height = Math.Max(args.VerticalChange + lobRefObjetoParaAdornar.Height, lobHitThumb.DesiredSize.Height);
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorCentroIzquierda : Manejador resizing Centro extremo Izquierda
        /// <summary>
        /// <para> fcvManejadorCentroIzquierda : Manejador resizing Centro extremo Izquierda</para>
        /// </summary>
        void fcvManejadorCentroIzquierda(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = AdornedElement as FrameworkElement;
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);
            //- Estirar hacia la izquierda
            double lduWidthAnterior = lobRefObjetoParaAdornar.Width;
            double lduWidthNuevo = Math.Max(lobRefObjetoParaAdornar.Width - args.HorizontalChange, lobHitThumb.DesiredSize.Width);
            double lduLeftAnterior = Canvas.GetLeft(lobRefObjetoParaAdornar);
            lobRefObjetoParaAdornar.Width = lduWidthNuevo;
            Canvas.SetLeft(lobRefObjetoParaAdornar, lduLeftAnterior - (lduWidthNuevo - lduWidthAnterior));
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        #region fcvManejadorCentroDerecha : Manejador resizing extremo Derecha
        /// <summary>
        /// <para>fcvManejadorCentroDerecha : Manejador resizing extremo Derecha</para>
        /// </summary>
        void fcvManejadorCentroDerecha(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement lobRefObjetoParaAdornar = this.AdornedElement as FrameworkElement;
            Thumb lobHitThumb = sender as Thumb;

            if (lobRefObjetoParaAdornar == null || lobHitThumb == null) return;
            FrameworkElement parentElement = lobRefObjetoParaAdornar.Parent as FrameworkElement;

            // Asegurar que ancho y alto se inician apropiadamente antes del resize.
            fcvPreAjusteAnchAltoObjeto(lobRefObjetoParaAdornar);
            // Estirar hacia la Derecha
            lobRefObjetoParaAdornar.Width = Math.Max(lobRefObjetoParaAdornar.Width + args.HorizontalChange, lobHitThumb.DesiredSize.Width);
            //fcvAjusteFondoZona(lobRefObjetoParaAdornar);
        }
        #endregion
        //-------------------------------------------------------
        #region ArrangeOverride : Configuracion de la ubicacion de los adornos sobre el objeto.
        /// <summary>
        /// ArrangeOverride : Configuracion de la ubicacion de los adornos sobre el objeto.
        /// </summary>
        protected override Size ArrangeOverride(Size finalSize)
        {
            // lduObjetoWidth y lduObjetoHeight son la anchura y la altura del elemento que está siendo adornado,
            // estos serán utilizados para colocar la ResizingAdorner en las esquinas del elemento adornado.
            double lduObjetoWidth = AdornedElement.DesiredSize.Width <= 5 ? 15 : AdornedElement.DesiredSize.Width;
            double lduObjetoHeight = AdornedElement.DesiredSize.Height <= 5 ? 15 : AdornedElement.DesiredSize.Height; 
            // lduAdornoWidth y lduAdornoHeight se utilizan para la colocación también.
            double lduAdornoWidth   = this.DesiredSize.Width <= 5 ? 15 : this.DesiredSize.Width;
            double lduAdornoHeight  = this.DesiredSize.Height <= 5 ? 15 : this.DesiredSize.Height;
            double lduDistArriba    = (gduTamañoAdorno * 0.98);
            double lduDistAbajo     = 13;
            //- Configurar Posicion  y tamaño de los adornos sobre el Objeto 
            lobThumbArribaIzquierda.Arrange(new Rect(-(lduAdornoWidth + 35) / 2, -(lduAdornoHeight + lduDistArriba) / 2, lduAdornoWidth, lduAdornoHeight));
            lobThumbArribaCentro.Arrange(new Rect((lduObjetoWidth - lduAdornoWidth) / 4, -(lduAdornoHeight + lduDistArriba) / 2, lduAdornoWidth, lduAdornoHeight));
            lobThumbArribaDerecha.Arrange(new Rect((lduObjetoWidth + 18) - (lduAdornoWidth / 2), -(lduAdornoHeight + lduDistArriba) / 2, lduAdornoWidth, lduAdornoHeight));
            lobThumbAbajoIzquierda.Arrange(new Rect(-(lduAdornoWidth + 35) / 2, (lduObjetoHeight + lduDistAbajo) - (lduAdornoHeight / 2), lduAdornoWidth, lduAdornoHeight));
            lobThumbAbajoCentro.Arrange(new Rect((lduObjetoWidth - lduAdornoWidth) / 4, (lduObjetoHeight + lduDistAbajo) - (lduAdornoHeight / 2), lduAdornoWidth, lduAdornoHeight));
            lobThumbAbajoDerecha.Arrange(new Rect((lduObjetoWidth + 18) - (lduAdornoWidth / 2), (lduObjetoHeight + lduDistAbajo) - (lduAdornoHeight / 2), lduAdornoWidth, lduAdornoHeight));
            lobThumbCentroIzquierda.Arrange(new Rect(-(lduAdornoWidth + 35) / 2, (lduObjetoHeight - lduAdornoHeight) / 4, lduAdornoWidth, lduAdornoHeight));
            lobThumbCentroDerecha.Arrange(new Rect(lduObjetoWidth + 18 - (lduAdornoWidth / 2), (lduObjetoHeight - lduAdornoHeight) / 4, lduAdornoWidth, lduAdornoHeight));
            // Retorna el tamaño final.
            return finalSize;
        }
        #endregion
        #region fcvGenerarAdornosEsquinasObjeto : Ayuda para crear instancias de los Adornos de las esquinas
        /// <summary>
        /// <para>Método de ayuda para crear instancias de los Adornos de las esquinas</para>
        /// <para>Verifica que el objeto no exista antes de crear la nueva instancia. </para>
        /// <para>Configura el tipo de de cursor a mostrar, establece algunas propiedades de apariencia, y añade los </para>
        /// <para>elementos al árbol visual garArrayVisualChildren.</para>
        /// <para>tuxTipoCursorEsquina: Cursors.SizeNESW, Cursors.SizeNESW Cursors.SizeNWSE...</para>
        /// </summary>
        void fcvGenerarAdornosEsquinasObjeto(ref Thumb tobRefObjetoCornerThumb, Cursor tuxTipoCursorEsquina)
        {
            if (tobRefObjetoCornerThumb != null) return; // cuando ya existe se regresa

            tobRefObjetoCornerThumb = new Thumb();
            // Configurar caracteristicas de cada Objeto Adorno.
            tobRefObjetoCornerThumb.Cursor = tuxTipoCursorEsquina;
            tobRefObjetoCornerThumb.Height = tobRefObjetoCornerThumb.Width = gduTamañoAdorno;
            tobRefObjetoCornerThumb.BorderThickness = new Thickness(1, 1, 1, 1);
            tobRefObjetoCornerThumb.Opacity = 0.80;
            tobRefObjetoCornerThumb.Background = new SolidColorBrush(Colors.Transparent);

            garArrayVisualChildren.Add(tobRefObjetoCornerThumb);
        }
        #endregion
        #region fcvPreAjusteAnchAltoObjeto : Garantiza anchuras y alturas inicial ajustado contenedor Zona
        /// <summary>
        /// <para>Este método garantiza que las anchuras y alturas se inicializan ajustado al tamaño al contenedor de la zona </para>
        /// <para>Los valores de ancho y alto se redefinen de Double.NaN. Debido a que el adorno redimensiona explícitamente</para>
        /// <para>la anchura y la altura es necesario establecer primero. </para>
        /// <para>También establece el tamaño máximo del elemento adornado. </para>
        /// </summary>
        void fcvPreAjusteAnchAltoObjeto(FrameworkElement tobRefObjetoParaAdornar)
        {
            if (tobRefObjetoParaAdornar.Width.Equals(Double.NaN))
                tobRefObjetoParaAdornar.Width = tobRefObjetoParaAdornar.DesiredSize.Width;
            if (tobRefObjetoParaAdornar.Height.Equals(Double.NaN))
                tobRefObjetoParaAdornar.Height = tobRefObjetoParaAdornar.DesiredSize.Height;

            FrameworkElement lobZonaParent = tobRefObjetoParaAdornar.Parent as FrameworkElement; // Buscar la Zona que lo contiene
            if (lobZonaParent != null)
            {
                tobRefObjetoParaAdornar.MaxHeight = lobZonaParent.ActualHeight;
                tobRefObjetoParaAdornar.MaxWidth = lobZonaParent.ActualWidth;
            }
        }
        #endregion
        #region fcvAjusteFondoZona : Ajusta el Control GroupBox que hace las veces de fondo en cada zona
        /// <summary>
        /// <para>fcvAjusteFondoZona : Ajusta el Control GroupBox que hace las veces de fondo en cada zona</para>
        /// </summary>
        void fcvAjusteFondoZona(FrameworkElement tobRefObjetoReAjustado)
        {
            if (tobRefObjetoReAjustado.Name.Substring(0, 7).ToUpper() == "OBJZONA")
            {
                if (gobObjetoFondo != null)
                {
                    // Estirar al fondo de la zona
                    gobObjetoFondo.Height = (tobRefObjetoReAjustado as Canvas).Height;
                    gobObjetoFondo.Width = (tobRefObjetoReAjustado as Canvas).Width;
                }
            }
        }
        #endregion
        //-------------------------------------------------------
        // Las propiedades Override VisualChildrenCount  y GetVisualChild  son 
        // para interactuar con la colección visual garArrayVisualChildren.
        //-------------------------------------------------------
        protected override int VisualChildrenCount { get { return garArrayVisualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return garArrayVisualChildren[index]; }
    }
    #endregion
}

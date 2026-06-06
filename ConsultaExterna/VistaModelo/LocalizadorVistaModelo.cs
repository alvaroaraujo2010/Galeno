using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ConsultaExterna.VistaModelo
{
    /// <summary>
    /// Localizador para la VistaModelo de cada tabla 
    /// y asi poder asociarlas a las Vistas (Ventana/Formularios)
    /// respectivos
    /// </summary>
    public class LocalizadorVistaModelo
    {

        static LocalizadorVistaModelo()
        {
            //Constructor
        }
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAtencionAmbulatoria
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAtencionAmbulatoria
        private static VistaModeloAtencionAmbulatoria _vistaModeloAtencionAmbulatoria;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAtencionAmbulatoria
        /// </summary>
        public static VistaModeloAtencionAmbulatoria VistaModeloAtencionAmbulatoriaStatic
        {
            get
            {
                if (_vistaModeloAtencionAmbulatoria == null)
                {
                    fcvCrearVistaModeloAtencionAmbulatoria();
                }
                return _vistaModeloAtencionAmbulatoria;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAtencionAmbulatoria
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAtencionAmbulatoria VistaModeloAtencionAmbulatoria
        {
            get
            {
                return VistaModeloAtencionAmbulatoriaStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAtencionAmbulatoria
        /// </summary>
        public static void fcvLiberarVistaModeloAtencionAmbulatoria()
        {
            if (_vistaModeloAtencionAmbulatoria != null)
            {
                _vistaModeloAtencionAmbulatoria.Cleanup();
                _vistaModeloAtencionAmbulatoria = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAtencionAmbulatoria
        /// </summary>
        public static void fcvCrearVistaModeloAtencionAmbulatoria()
        {
            if (_vistaModeloAtencionAmbulatoria == null)
            {
                _vistaModeloAtencionAmbulatoria = new VistaModeloAtencionAmbulatoria();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Liberar todos los recursos cargados o montados
        //-------------------------------------------------------
        /// <summary>
        /// Liberar todos los recursos cargados o montados
        /// </summary>
        public static void Cleanup()
        {
            fcvLiberarVistaModeloAtencionAmbulatoria();
        }
    }
}
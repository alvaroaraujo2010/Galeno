using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Estadisticas.VistaModelo
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
        // Codigo Localizador para: VistaModeloEstParametros2193
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloEstParametros2193
        private static VistaModeloEstParametros2193 _vistaModeloEstParametros2193;
        /// <summary>
        ///Leer las Propiedades de VistaModeloEstParametros2193
        /// </summary>
        public static VistaModeloEstParametros2193 VistaModeloEstParametros2193Static
        {
            get
            {
                if (_vistaModeloEstParametros2193 == null)
                {
                    fcvCrearVistaModeloEstParametros2193();
                }
                return _vistaModeloEstParametros2193;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloEstParametros2193
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloEstParametros2193 VistaModeloEstParametros2193
        {
            get
            {
                return VistaModeloEstParametros2193Static;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloEstParametros2193
        /// </summary>
        public static void fcvLiberarVistaModeloEstParametros2193()
        {
            if (_vistaModeloEstParametros2193 != null)
            {
                _vistaModeloEstParametros2193.Cleanup();
                _vistaModeloEstParametros2193 = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloEstParametros2193
        /// </summary>
        public static void fcvCrearVistaModeloEstParametros2193()
        {
            if (_vistaModeloEstParametros2193 == null)
            {
                _vistaModeloEstParametros2193 = new VistaModeloEstParametros2193();
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
            //fcvLiberarHoscamasareasVistaModelo();
            fcvLiberarVistaModeloEstParametros2193();

        }
    }
}
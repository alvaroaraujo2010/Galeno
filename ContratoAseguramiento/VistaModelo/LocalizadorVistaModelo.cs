using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ContratoAseguramiento.VistaModelo
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
        // Codigo Localizador para: VistaModeloCtomaestrocontratos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCtomaestrocontratos
        private static VistaModeloCtomaestrocontratos _vistaModeloCtomaestrocontratos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCtomaestrocontratos
        /// </summary>
        public static VistaModeloCtomaestrocontratos VistaModeloCtomaestrocontratosStatic
        {
            get
            {
                if (_vistaModeloCtomaestrocontratos == null)
                {
                    fcvCrearVistaModeloCtomaestrocontratos();
                }
                return _vistaModeloCtomaestrocontratos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCtomaestrocontratos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCtomaestrocontratos VistaModeloCtomaestrocontratos
        {
            get
            {
                return VistaModeloCtomaestrocontratosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCtomaestrocontratos
        /// </summary>
        public static void fcvLiberarVistaModeloCtomaestrocontratos()
        {
            if (_vistaModeloCtomaestrocontratos != null)
            {
                _vistaModeloCtomaestrocontratos.Cleanup();
                _vistaModeloCtomaestrocontratos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCtomaestrocontratos
        /// </summary>
        public static void fcvCrearVistaModeloCtomaestrocontratos()
        {
            if (_vistaModeloCtomaestrocontratos == null)
            {
                _vistaModeloCtomaestrocontratos = new VistaModeloCtomaestrocontratos();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloCargarbasededatos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCargarbasededatos
        private static VistaModeloCargarbasededatos _vistaModeloCargarbasededatos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCargarbasededatos
        /// </summary>
        public static VistaModeloCargarbasededatos VistaModeloCargarbasededatosStatic
        {
            get
            {
                if (_vistaModeloCargarbasededatos == null)
                {
                    fcvCrearVistaModeloCargarbasededatos();
                }
                return _vistaModeloCargarbasededatos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCargarbasededatos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCargarbasededatos VistaModeloCargarbasededatos
        {
            get
            {
                return VistaModeloCargarbasededatosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCargarbasededatos
        /// </summary>
        public static void fcvLiberarVistaModeloCargarbasededatos()
        {
            if (_vistaModeloCargarbasededatos != null)
            {
                _vistaModeloCargarbasededatos.Cleanup();
                _vistaModeloCargarbasededatos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCargarbasededatos
        /// </summary>
        public static void fcvCrearVistaModeloCargarbasededatos()
        {
            if (_vistaModeloCargarbasededatos == null)
            {
                _vistaModeloCargarbasededatos = new VistaModeloCargarbasededatos();
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
            fcvLiberarVistaModeloCtomaestrocontratos();
            fcvLiberarVistaModeloCargarbasededatos();

        }
    }
}
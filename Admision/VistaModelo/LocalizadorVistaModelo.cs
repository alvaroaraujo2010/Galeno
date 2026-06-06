using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Admision.VistaModelo
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
        // Codigo Localizador para: VistaModeloAdmadmisiones
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAdmadmisiones
        private static VistaModeloAdmadmisiones _vistaModeloAdmadmisiones;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAdmadmisiones
        /// </summary>
        public static VistaModeloAdmadmisiones VistaModeloAdmadmisionesStatic
        {
            get
            {
                if (_vistaModeloAdmadmisiones == null)
                {
                    fcvCrearVistaModeloAdmadmisiones();
                }
                return _vistaModeloAdmadmisiones;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAdmadmisiones
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAdmadmisiones VistaModeloAdmadmisiones
        {
            get
            {
                return VistaModeloAdmadmisionesStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAdmadmisiones
        /// </summary>
        public static void fcvLiberarVistaModeloAdmadmisiones()
        {
            if (_vistaModeloAdmadmisiones != null)
            {
                _vistaModeloAdmadmisiones.Cleanup();
                _vistaModeloAdmadmisiones = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAdmadmisiones
        /// </summary>
        public static void fcvCrearVistaModeloAdmadmisiones()
        {
            if (_vistaModeloAdmadmisiones == null)
            {
                _vistaModeloAdmadmisiones = new VistaModeloAdmadmisiones();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloTriageValoracion
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloTriageValoracion
        private static VistaModeloTriageValoracion _vistaModeloTriageValoracion;
        /// <summary>
        ///Leer las Propiedades de VistaModeloTriageValoracion
        /// </summary>
        public static VistaModeloTriageValoracion VistaModeloTriageValoracionStatic
        {
            get
            {
                if (_vistaModeloTriageValoracion == null)
                {
                    fcvCrearVistaModeloTriageValoracion();
                }
                return _vistaModeloTriageValoracion;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloTriageValoracion
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloTriageValoracion VistaModeloTriageValoracion
        {
            get
            {
                return VistaModeloTriageValoracionStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloTriageValoracion
        /// </summary>
        public static void fcvLiberarVistaModeloTriageValoracion()
        {
            if (_vistaModeloTriageValoracion != null)
            {
                _vistaModeloTriageValoracion.Cleanup();
                _vistaModeloTriageValoracion = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloTriageValoracion
        /// </summary>
        public static void fcvCrearVistaModeloTriageValoracion()
        {
            if (_vistaModeloTriageValoracion == null)
            {
                _vistaModeloTriageValoracion = new VistaModeloTriageValoracion();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloConfigTriage
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloConfigTriage
        private static VistaModeloConfigTriage _vistaModeloConfigTriage;
        /// <summary>
        ///Leer las Propiedades de VistaModeloConfigTriage
        /// </summary>
        public static VistaModeloConfigTriage VistaModeloConfigTriageStatic
        {
            get
            {
                if (_vistaModeloConfigTriage == null)
                {
                    fcvCrearVistaModeloConfigTriage();
                }
                return _vistaModeloConfigTriage;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloConfigTriage
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloConfigTriage VistaModeloConfigTriage
        {
            get
            {
                return VistaModeloConfigTriageStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloConfigTriage
        /// </summary>
        public static void fcvLiberarVistaModeloConfigTriage()
        {
            if (_vistaModeloConfigTriage != null)
            {
                _vistaModeloConfigTriage.Cleanup();
                _vistaModeloConfigTriage = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloConfigTriage
        /// </summary>
        public static void fcvCrearVistaModeloConfigTriage()
        {
            if (_vistaModeloConfigTriage == null)
            {
                _vistaModeloConfigTriage = new VistaModeloConfigTriage();
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
            fcvLiberarVistaModeloAdmadmisiones();
            fcvLiberarVistaModeloTriageValoracion();
        }
    }
}
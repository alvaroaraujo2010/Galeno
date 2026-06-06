using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace SaludPublica.VistaModelo
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
        #region  Localizador para: VistaModeloSptablaperiodos
        private static VistaModeloSptablaperiodos _vistaModeloSptablaperiodos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSptablaperiodos
        /// </summary>
        public static VistaModeloSptablaperiodos VistaModeloSptablaperiodosStatic
        {
            get
            {
                if (_vistaModeloSptablaperiodos == null)
                {
                    fcvCrearVistaModeloSptablaperiodos();
                }
                return _vistaModeloSptablaperiodos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSptablaperiodos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSptablaperiodos VistaModeloSptablaperiodos
        {
            get
            {
                return VistaModeloSptablaperiodosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSptablaperiodos
        /// </summary>
        public static void fcvLiberarVistaModeloSptablaperiodos()
        {
            if (_vistaModeloSptablaperiodos != null)
            {
                _vistaModeloSptablaperiodos.Cleanup();
                _vistaModeloSptablaperiodos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSptablaperiodos
        /// </summary>
        public static void fcvCrearVistaModeloSptablaperiodos()
        {
            if (_vistaModeloSptablaperiodos == null)
            {
                _vistaModeloSptablaperiodos = new VistaModeloSptablaperiodos();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSptabcampos4505
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSptabcampos4505
        private static VistaModeloSptabcampos4505 _vistaModeloSptabcampos4505;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSptabcampos4505
        /// </summary>
        public static VistaModeloSptabcampos4505 VistaModeloSptabcampos4505Static
        {
            get
            {
                if (_vistaModeloSptabcampos4505 == null)
                {
                    fcvCrearVistaModeloSptabcampos4505();
                }
                return _vistaModeloSptabcampos4505;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSptabcampos4505
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSptabcampos4505 VistaModeloSptabcampos4505
        {
            get
            {
                return VistaModeloSptabcampos4505Static;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSptabcampos4505
        /// </summary>
        public static void fcvLiberarVistaModeloSptabcampos4505()
        {
            if (_vistaModeloSptabcampos4505 != null)
            {
                _vistaModeloSptabcampos4505.Cleanup();
                _vistaModeloSptabcampos4505 = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSptabcampos4505
        /// </summary>
        public static void fcvCrearVistaModeloSptabcampos4505()
        {
            if (_vistaModeloSptabcampos4505 == null)
            {
                _vistaModeloSptabcampos4505 = new VistaModeloSptabcampos4505();
            }
        }
        #endregion        
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSspRes4505
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSspRes4505
        private static VistaModeloSspRes4505 _vistaModeloSspRes4505;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSspRes4505
        /// </summary>
        public static VistaModeloSspRes4505 VistaModeloSspRes4505Static
        {
            get
            {
                if (_vistaModeloSspRes4505 == null)
                {
                    fcvCrearVistaModeloSspRes4505();
                }
                return _vistaModeloSspRes4505;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSspRes4505
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSspRes4505 VistaModeloSspRes4505
        {
            get
            {
                return VistaModeloSspRes4505Static;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSspRes4505
        /// </summary>
        public static void fcvLiberarVistaModeloSspRes4505()
        {
            if (_vistaModeloSspRes4505 != null)
            {
                _vistaModeloSspRes4505.Cleanup();
                _vistaModeloSspRes4505 = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSspRes4505
        /// </summary>
        public static void fcvCrearVistaModeloSspRes4505()
        {
            if (_vistaModeloSspRes4505 == null)
            {
                _vistaModeloSspRes4505 = new VistaModeloSspRes4505();
            }
        }
        #endregion        
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloGestionValidacion
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloGestionValidacion
        private static VistaModeloGestionValidacion _vistaModeloGestionValidacion;
        /// <summary>
        ///Leer las Propiedades de VistaModeloGestionValidacion
        /// </summary>
        public static VistaModeloGestionValidacion VistaModeloGestionValidacionStatic
        {
            get
            {
                if (_vistaModeloGestionValidacion == null)
                {
                    fcvCrearVistaModeloGestionValidacion();
                }
                return _vistaModeloGestionValidacion;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloGestionValidacion
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloGestionValidacion VistaModeloGestionValidacion
        {
            get
            {
                return VistaModeloGestionValidacionStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloGestionValidacion
        /// </summary>
        public static void fcvLiberarVistaModeloGestionValidacion()
        {
            if (_vistaModeloGestionValidacion != null)
            {
                _vistaModeloGestionValidacion.Cleanup();
                _vistaModeloGestionValidacion = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloGestionValidacion
        /// </summary>
        public static void fcvCrearVistaModeloGestionValidacion()
        {
            if (_vistaModeloGestionValidacion == null)
            {
                _vistaModeloGestionValidacion = new VistaModeloGestionValidacion();
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
            fcvLiberarVistaModeloSspRes4505();
            fcvLiberarVistaModeloSptablaperiodos();
            fcvLiberarVistaModeloSptabcampos4505();
            fcvLiberarVistaModeloGestionValidacion();
        }
    }
}
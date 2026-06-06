using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Hospitalizacion.VistaModelo
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
        // Codigo Localizador para: HoscamasareasVistaModelo
        //-------------------------------------------------------
        #region Localizador para: HoscamasareasVistaModelo
        private static HoscamasareasVistaModelo _hoscamasareasVistaModelo;
        /// <summary>
        /// Leer las Propiedades de HoscamasareasVistaModelo
        /// </summary>
        public static HoscamasareasVistaModelo HoscamasareasVistaModeloStatico
        {
            get
            {
                if (_hoscamasareasVistaModelo == null)
                {
                    fcvCrearHoscamasareasVistaModelo();
                }

                return _hoscamasareasVistaModelo;
            }
        }

        /// <summary>
        /// Leer las Propiedades de HoscamasareasVistaModelo
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HoscamasareasVistaModelo HoscamasareasVistaModelo
        {
            get
            {
                return HoscamasareasVistaModeloStatico;
            }
        }

        /// <summary>
		/// Proveer una ruta determinada para eliminar la propiedad  HoscamasareasVistaModelo
        /// </summary>
        public static void fcvLiberarHoscamasareasVistaModelo()
        {
            _hoscamasareasVistaModelo.Cleanup();
            _hoscamasareasVistaModelo = null;
        }

        /// <summary>
		/// Proveer una ruta determinada para crear la propiedad  HoscamasareasVistaModelo
        /// </summary>
        public static void fcvCrearHoscamasareasVistaModelo()
        {
            if (_hoscamasareasVistaModelo == null)
            {
                _hoscamasareasVistaModelo = new HoscamasareasVistaModelo();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHoscamasareas
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHoscamasareas
        private static VistaModeloHoscamasareas _vistaModeloHoscamasareas;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHoscamasareas
        /// </summary>
        public static VistaModeloHoscamasareas VistaModeloHoscamasareasStatic
        {
            get
            {
                if (_vistaModeloHoscamasareas == null)
                {
                    fcvCrearVistaModeloHoscamasareas();
                }
                return _vistaModeloHoscamasareas;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHoscamasareas
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHoscamasareas VistaModeloHoscamasareas
        {
            get
            {
                return VistaModeloHoscamasareasStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHoscamasareas
        /// </summary>
        public static void fcvLiberarVistaModeloHoscamasareas()
        {
            if (_vistaModeloHoscamasareas != null)
            {
                _vistaModeloHoscamasareas.Cleanup();
                _vistaModeloHoscamasareas = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHoscamasareas
        /// </summary>
        public static void fcvCrearVistaModeloHoscamasareas()
        {
            if (_vistaModeloHoscamasareas == null)
            {
                _vistaModeloHoscamasareas = new VistaModeloHoscamasareas();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloBxHoshabitaciones
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloBxHoshabitaciones
        private static VistaModeloBxHoshabitaciones _vistaModeloBxHoshabitaciones;
        /// <summary>
        ///Leer las Propiedades de VistaModeloBxHoshabitaciones
        /// </summary>
        public static VistaModeloBxHoshabitaciones VistaModeloBxHoshabitacionesStatic
        {
            get
            {
                if (_vistaModeloBxHoshabitaciones == null)
                {
                    fcvCrearVistaModeloBxHoshabitaciones();
                }
                return _vistaModeloBxHoshabitaciones;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloBxHoshabitaciones
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloBxHoshabitaciones VistaModeloBxHoshabitaciones
        {
            get
            {
                return VistaModeloBxHoshabitacionesStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloBxHoshabitaciones
        /// </summary>
        public static void fcvLiberarVistaModeloBxHoshabitaciones()
        {
            if (_vistaModeloBxHoshabitaciones != null)
            {
                _vistaModeloBxHoshabitaciones.Cleanup();
                _vistaModeloBxHoshabitaciones = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloBxHoshabitaciones
        /// </summary>
        public static void fcvCrearVistaModeloBxHoshabitaciones()
        {
            if (_vistaModeloBxHoshabitaciones == null)
            {
                _vistaModeloBxHoshabitaciones = new VistaModeloBxHoshabitaciones();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloBcHoshabitaciones
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloBcHoshabitaciones
        private static VistaModeloBcHoshabitaciones _vistaModeloBcHoshabitaciones;
        /// <summary>
        ///Leer las Propiedades de VistaModeloBcHoshabitaciones
        /// </summary>
        public static VistaModeloBcHoshabitaciones VistaModeloBcHoshabitacionesStatic
        {
            get
            {
                if (_vistaModeloBcHoshabitaciones == null)
                {
                    fcvCrearVistaModeloBcHoshabitaciones();
                }
                return _vistaModeloBcHoshabitaciones;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloBcHoshabitaciones
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloBcHoshabitaciones VistaModeloBcHoshabitaciones
        {
            get
            {
                return VistaModeloBcHoshabitacionesStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloBcHoshabitaciones
        /// </summary>
        public static void fcvLiberarVistaModeloBcHoshabitaciones()
        {
            if (_vistaModeloBcHoshabitaciones != null)
            {
                _vistaModeloBcHoshabitaciones.Cleanup();
                _vistaModeloBcHoshabitaciones = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloBcHoshabitaciones
        /// </summary>
        public static void fcvCrearVistaModeloBcHoshabitaciones()
        {
            if (_vistaModeloBcHoshabitaciones == null)
            {
                _vistaModeloBcHoshabitaciones = new VistaModeloBcHoshabitaciones();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloRegistroSalida
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloRegistroSalida
        private static VistaModeloRegistroSalida _vistaModeloRegistroSalida;
        /// <summary>
        ///Leer las Propiedades de VistaModeloRegistroSalida
        /// </summary>
        public static VistaModeloRegistroSalida VistaModeloRegistroSalidaStatic
        {
            get
            {
                if (_vistaModeloRegistroSalida == null)
                {
                    fcvCrearVistaModeloRegistroSalida();
                }
                return _vistaModeloRegistroSalida;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloRegistroSalida
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloRegistroSalida VistaModeloRegistroSalida
        {
            get
            {
                return VistaModeloRegistroSalidaStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloRegistroSalida
        /// </summary>
        public static void fcvLiberarVistaModeloRegistroSalida()
        {
            if (_vistaModeloRegistroSalida != null)
            {
                _vistaModeloRegistroSalida.Cleanup();
                _vistaModeloRegistroSalida = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloRegistroSalida
        /// </summary>
        public static void fcvCrearVistaModeloRegistroSalida()
        {
            if (_vistaModeloRegistroSalida == null)
            {
                _vistaModeloRegistroSalida = new VistaModeloRegistroSalida();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAutorizarEgreso
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAutorizarEgreso
        private static VistaModeloAutorizarEgreso _vistaModeloAutorizarEgreso;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAutorizarEgreso
        /// </summary>
        public static VistaModeloAutorizarEgreso VistaModeloAutorizarEgresoStatic
        {
            get
            {
                if (_vistaModeloAutorizarEgreso == null)
                {
                    fcvCrearVistaModeloAutorizarEgreso();
                }
                return _vistaModeloAutorizarEgreso;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAutorizarEgreso
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAutorizarEgreso VistaModeloAutorizarEgreso
        {
            get
            {
                return VistaModeloAutorizarEgresoStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAutorizarEgreso
        /// </summary>
        public static void fcvLiberarVistaModeloAutorizarEgreso()
        {
            if (_vistaModeloAutorizarEgreso != null)
            {
                _vistaModeloAutorizarEgreso.Cleanup();
                _vistaModeloAutorizarEgreso = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAutorizarEgreso
        /// </summary>
        public static void fcvCrearVistaModeloAutorizarEgreso()
        {
            if (_vistaModeloAutorizarEgreso == null)
            {
                _vistaModeloAutorizarEgreso = new VistaModeloAutorizarEgreso();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHosEgresoUrgencias
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHosEgresoUrgencias
        private static VistaModeloHosEgresoUrgencias _vistaModeloHosEgresoUrgencias;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHosEgresoUrgencias
        /// </summary>
        public static VistaModeloHosEgresoUrgencias VistaModeloHosEgresoUrgenciasStatic
        {
            get
            {
                if (_vistaModeloHosEgresoUrgencias == null)
                {
                    fcvCrearVistaModeloHosEgresoUrgencias();
                }
                return _vistaModeloHosEgresoUrgencias;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHosEgresoUrgencias
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHosEgresoUrgencias VistaModeloHosEgresoUrgencias
        {
            get
            {
                return VistaModeloHosEgresoUrgenciasStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHosEgresoUrgencias
        /// </summary>
        public static void fcvLiberarVistaModeloHosEgresoUrgencias()
        {
            if (_vistaModeloHosEgresoUrgencias != null)
            {
                _vistaModeloHosEgresoUrgencias.Cleanup();
                _vistaModeloHosEgresoUrgencias = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHosEgresoUrgencias
        /// </summary>
        public static void fcvCrearVistaModeloHosEgresoUrgencias()
        {
            if (_vistaModeloHosEgresoUrgencias == null)
            {
                _vistaModeloHosEgresoUrgencias = new VistaModeloHosEgresoUrgencias();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloTrasladoCama
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloTrasladoCama
        private static VistaModeloTrasladoCama _vistaModeloTrasladoCama;
        /// <summary>
        ///Leer las Propiedades de VistaModeloTrasladoCama
        /// </summary>
        public static VistaModeloTrasladoCama VistaModeloTrasladoCamaStatic
        {
            get
            {
                if (_vistaModeloTrasladoCama == null)
                {
                    fcvCrearVistaModeloTrasladoCama();
                }
                return _vistaModeloTrasladoCama;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloTrasladoCama
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloTrasladoCama VistaModeloTrasladoCama
        {
            get
            {
                return VistaModeloTrasladoCamaStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloTrasladoCama
        /// </summary>
        public static void fcvLiberarVistaModeloTrasladoCama()
        {
            if (_vistaModeloTrasladoCama != null)
            {
                _vistaModeloTrasladoCama.Cleanup();
                _vistaModeloTrasladoCama = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloTrasladoCama
        /// </summary>
        public static void fcvCrearVistaModeloTrasladoCama()
        {
            if (_vistaModeloTrasladoCama == null)
            {
                _vistaModeloTrasladoCama = new VistaModeloTrasladoCama();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHosconfigmodulo
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHosconfigmodulo
        private static VistaModeloHosconfigmodulo _vistaModeloHosconfigmodulo;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHosconfigmodulo
        /// </summary>
        public static VistaModeloHosconfigmodulo VistaModeloHosconfigmoduloStatic
        {
            get
            {
                if (_vistaModeloHosconfigmodulo == null)
                {
                    fcvCrearVistaModeloHosconfigmodulo();
                }
                return _vistaModeloHosconfigmodulo;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHosconfigmodulo
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHosconfigmodulo VistaModeloHosconfigmodulo
        {
            get
            {
                return VistaModeloHosconfigmoduloStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHosconfigmodulo
        /// </summary>
        public static void fcvLiberarVistaModeloHosconfigmodulo()
        {
            if (_vistaModeloHosconfigmodulo != null)
            {
                _vistaModeloHosconfigmodulo.Cleanup();
                _vistaModeloHosconfigmodulo = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHosconfigmodulo
        /// </summary>
        public static void fcvCrearVistaModeloHosconfigmodulo()
        {
            if (_vistaModeloHosconfigmodulo == null)
            {
                _vistaModeloHosconfigmodulo = new VistaModeloHosconfigmodulo();
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
            fcvLiberarHoscamasareasVistaModelo();
            fcvLiberarVistaModeloHoscamasareas();
            fcvLiberarVistaModeloBxHoshabitaciones();
            fcvLiberarVistaModeloBcHoshabitaciones();
            fcvLiberarVistaModeloRegistroSalida();
            fcvLiberarVistaModeloAutorizarEgreso();
            fcvLiberarVistaModeloHosEgresoUrgencias();
            fcvLiberarVistaModeloTrasladoCama();
            fcvLiberarVistaModeloHosconfigmodulo();
        }
    }
}
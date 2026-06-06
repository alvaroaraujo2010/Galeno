using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ConfigAsistencial.VistaModelo
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
        // Codigo Localizador para: VistaModeloSiamaeprofsalud
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiamaeprofsalud
        private static VistaModeloSiamaeprofsalud _vistaModeloSiamaeprofsalud;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiamaeprofsalud
        /// </summary>
        public static VistaModeloSiamaeprofsalud VistaModeloSiamaeprofsaludStatic
        {
            get
            {
                if (_vistaModeloSiamaeprofsalud == null)
                {
                    fcvCrearVistaModeloSiamaeprofsalud();
                }
                return _vistaModeloSiamaeprofsalud;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiamaeprofsalud
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiamaeprofsalud VistaModeloSiamaeprofsalud
        {
            get
            {
                return VistaModeloSiamaeprofsaludStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiamaeprofsalud
        /// </summary>
        public static void fcvLiberarVistaModeloSiamaeprofsalud()
        {
            if (_vistaModeloSiamaeprofsalud != null)
            {
                _vistaModeloSiamaeprofsalud.Cleanup();
                _vistaModeloSiamaeprofsalud = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiamaeprofsalud
        /// </summary>
        public static void fcvCrearVistaModeloSiamaeprofsalud()
        {
            if (_vistaModeloSiamaeprofsalud == null)
            {
                _vistaModeloSiamaeprofsalud = new VistaModeloSiamaeprofsalud();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSiaUsuariosAtendidos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiaUsuariosAtendidos
        private static VistaModeloSiaUsuariosAtendidos _vistaModeloSiaUsuariosAtendidos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiaUsuariosAtendidos
        /// </summary>
        public static VistaModeloSiaUsuariosAtendidos VistaModeloSiaUsuariosAtendidosStatic
        {
            get
            {
                if (_vistaModeloSiaUsuariosAtendidos == null)
                {
                    fcvCrearVistaModeloSiaUsuariosAtendidos();
                }
                return _vistaModeloSiaUsuariosAtendidos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiaUsuariosAtendidos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiaUsuariosAtendidos VistaModeloSiaUsuariosAtendidos
        {
            get
            {
                return VistaModeloSiaUsuariosAtendidosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiaUsuariosAtendidos
        /// </summary>
        public static void fcvLiberarVistaModeloSiaUsuariosAtendidos()
        {
            if (_vistaModeloSiaUsuariosAtendidos != null)
            {
                _vistaModeloSiaUsuariosAtendidos.Cleanup();
                _vistaModeloSiaUsuariosAtendidos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiaUsuariosAtendidos
        /// </summary>
        public static void fcvCrearVistaModeloSiaUsuariosAtendidos()
        {
            if (_vistaModeloSiaUsuariosAtendidos == null)
            {
                _vistaModeloSiaUsuariosAtendidos = new VistaModeloSiaUsuariosAtendidos();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSiacopagosisben
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiacopagosisben
        private static VistaModeloSiacopagosisben _vistaModeloSiacopagosisben;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiacopagosisben
        /// </summary>
        public static VistaModeloSiacopagosisben VistaModeloSiacopagosisbenStatic
        {
            get
            {
                if (_vistaModeloSiacopagosisben == null)
                {
                    fcvCrearVistaModeloSiacopagosisben();
                }
                return _vistaModeloSiacopagosisben;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiacopagosisben
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiacopagosisben VistaModeloSiacopagosisben
        {
            get
            {
                return VistaModeloSiacopagosisbenStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiacopagosisben
        /// </summary>
        public static void fcvLiberarVistaModeloSiacopagosisben()
        {
            if (_vistaModeloSiacopagosisben != null)
            {
                _vistaModeloSiacopagosisben.Cleanup();
                _vistaModeloSiacopagosisben = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiacopagosisben
        /// </summary>
        public static void fcvCrearVistaModeloSiacopagosisben()
        {
            if (_vistaModeloSiacopagosisben == null)
            {
                _vistaModeloSiacopagosisben = new VistaModeloSiacopagosisben();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSiacopagcontrib
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiacopagcontrib
        private static VistaModeloSiacopagcontrib _vistaModeloSiacopagcontrib;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiacopagcontrib
        /// </summary>
        public static VistaModeloSiacopagcontrib VistaModeloSiacopagcontribStatic
        {
            get
            {
                if (_vistaModeloSiacopagcontrib == null)
                {
                    fcvCrearVistaModeloSiacopagcontrib();
                }
                return _vistaModeloSiacopagcontrib;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiacopagcontrib
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiacopagcontrib VistaModeloSiacopagcontrib
        {
            get
            {
                return VistaModeloSiacopagcontribStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiacopagcontrib
        /// </summary>
        public static void fcvLiberarVistaModeloSiacopagcontrib()
        {
            if (_vistaModeloSiacopagcontrib != null)
            {
                _vistaModeloSiacopagcontrib.Cleanup();
                _vistaModeloSiacopagcontrib = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiacopagcontrib
        /// </summary>
        public static void fcvCrearVistaModeloSiacopagcontrib()
        {
            if (_vistaModeloSiacopagcontrib == null)
            {
                _vistaModeloSiacopagcontrib = new VistaModeloSiacopagcontrib();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSiatablaeps
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiatablaeps
        private static VistaModeloSiatablaeps _vistaModeloSiatablaeps;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiatablaeps
        /// </summary>
        public static VistaModeloSiatablaeps VistaModeloSiatablaepsStatic
        {
            get
            {
                if (_vistaModeloSiatablaeps == null)
                {
                    fcvCrearVistaModeloSiatablaeps();
                }
                return _vistaModeloSiatablaeps;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiatablaeps
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiatablaeps VistaModeloSiatablaeps
        {
            get
            {
                return VistaModeloSiatablaepsStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiatablaeps
        /// </summary>
        public static void fcvLiberarVistaModeloSiatablaeps()
        {
            if (_vistaModeloSiatablaeps != null)
            {
                _vistaModeloSiatablaeps.Cleanup();
                _vistaModeloSiatablaeps = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiatablaeps
        /// </summary>
        public static void fcvCrearVistaModeloSiatablaeps()
        {
            if (_vistaModeloSiatablaeps == null)
            {
                _vistaModeloSiatablaeps = new VistaModeloSiatablaeps();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSiaDiagnosticos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSiaDiagnosticos
        private static VistaModeloSiaDiagnosticos _vistaModeloSiaDiagnosticos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiaDiagnosticos
        /// </summary>
        public static VistaModeloSiaDiagnosticos VistaModeloSiaDiagnosticosStatic
        {
            get
            {
                if (_vistaModeloSiaDiagnosticos == null)
                {
                    fcvCrearVistaModeloSiaDiagnosticos();
                }
                return _vistaModeloSiaDiagnosticos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSiaDiagnosticos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSiaDiagnosticos VistaModeloSiaDiagnosticos
        {
            get
            {
                return VistaModeloSiaDiagnosticosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSiaDiagnosticos
        /// </summary>
        public static void fcvLiberarVistaModeloSiaDiagnosticos()
        {
            if (_vistaModeloSiaDiagnosticos != null)
            {
                _vistaModeloSiaDiagnosticos.Cleanup();
                _vistaModeloSiaDiagnosticos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSiaDiagnosticos
        /// </summary>
        public static void fcvCrearVistaModeloSiaDiagnosticos()
        {
            if (_vistaModeloSiaDiagnosticos == null)
            {
                _vistaModeloSiaDiagnosticos = new VistaModeloSiaDiagnosticos();
            }
        }
        #endregion

        //para la implementacion en el localizador VistaModelo 
        public static void Cleanup()
        {
            fcvLiberarVistaModeloSiamaeprofsalud();
            fcvLiberarVistaModeloSiaUsuariosAtendidos();
            fcvLiberarVistaModeloSiacopagosisben();
            fcvLiberarVistaModeloSiacopagcontrib();
            fcvLiberarVistaModeloSiatablaeps();
            fcvLiberarVistaModeloSiaDiagnosticos();
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Meci.VistaModelo
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
        // Codigo Localizador para: VistaModeloMciplantillmeci
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMciplantillmeci
        private static VistaModeloMciplantillmeci _vistaModeloMciplantillmeci;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMciplantillmeci
        /// </summary>
        public static VistaModeloMciplantillmeci VistaModeloMciplantillmeciStatic
        {
            get
            {
                if (_vistaModeloMciplantillmeci == null)
                {
                    fcvCrearVistaModeloMciplantillmeci();
                }
                return _vistaModeloMciplantillmeci;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMciplantillmeci
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMciplantillmeci VistaModeloMciplantillmeci
        {
            get
            {
                return VistaModeloMciplantillmeciStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMciplantillmeci
        /// </summary>
        public static void fcvLiberarVistaModeloMciplantillmeci()
        {
            if (_vistaModeloMciplantillmeci != null)
            {
                _vistaModeloMciplantillmeci.Cleanup();
                _vistaModeloMciplantillmeci = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMciplantillmeci
        /// </summary>
        public static void fcvCrearVistaModeloMciplantillmeci()
        {
            if (_vistaModeloMciplantillmeci == null)
            {
                _vistaModeloMciplantillmeci = new VistaModeloMciplantillmeci();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMcicomponenmeci
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMcicomponenmeci
        private static VistaModeloMcicomponenmeci _vistaModeloMcicomponenmeci;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcicomponenmeci
        /// </summary>
        public static VistaModeloMcicomponenmeci VistaModeloMcicomponenmeciStatic
        {
            get
            {
                if (_vistaModeloMcicomponenmeci == null)
                {
                    fcvCrearVistaModeloMcicomponenmeci();
                }
                return _vistaModeloMcicomponenmeci;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcicomponenmeci
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMcicomponenmeci VistaModeloMcicomponenmeci
        {
            get
            {
                return VistaModeloMcicomponenmeciStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMcicomponenmeci
        /// </summary>
        public static void fcvLiberarVistaModeloMcicomponenmeci()
        {
            if (_vistaModeloMcicomponenmeci != null)
            {
                _vistaModeloMcicomponenmeci.Cleanup();
                _vistaModeloMcicomponenmeci = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMcicomponenmeci
        /// </summary>
        public static void fcvCrearVistaModeloMcicomponenmeci()
        {
            if (_vistaModeloMcicomponenmeci == null)
            {
                _vistaModeloMcicomponenmeci = new VistaModeloMcicomponenmeci();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMciparametrmeci
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMciparametrmeci
        private static VistaModeloMciparametrmeci _vistaModeloMciparametrmeci;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMciparametrmeci
        /// </summary>
        public static VistaModeloMciparametrmeci VistaModeloMciparametrmeciStatic
        {
            get
            {
                if (_vistaModeloMciparametrmeci == null)
                {
                    fcvCrearVistaModeloMciparametrmeci();
                }
                return _vistaModeloMciparametrmeci;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMciparametrmeci
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMciparametrmeci VistaModeloMciparametrmeci
        {
            get
            {
                return VistaModeloMciparametrmeciStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMciparametrmeci
        /// </summary>
        public static void fcvLiberarVistaModeloMciparametrmeci()
        {
            if (_vistaModeloMciparametrmeci != null)
            {
                _vistaModeloMciparametrmeci.Cleanup();
                _vistaModeloMciparametrmeci = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMciparametrmeci
        /// </summary>
        public static void fcvCrearVistaModeloMciparametrmeci()
        {
            if (_vistaModeloMciparametrmeci == null)
            {
                _vistaModeloMciparametrmeci = new VistaModeloMciparametrmeci();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMcigrupoprgmeci
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMcigrupoprgmeci
        private static VistaModeloMcigrupoprgmeci _vistaModeloMcigrupoprgmeci;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcigrupoprgmeci
        /// </summary>
        public static VistaModeloMcigrupoprgmeci VistaModeloMcigrupoprgmeciStatic
        {
            get
            {
                if (_vistaModeloMcigrupoprgmeci == null)
                {
                    fcvCrearVistaModeloMcigrupoprgmeci();
                }
                return _vistaModeloMcigrupoprgmeci;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcigrupoprgmeci
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMcigrupoprgmeci VistaModeloMcigrupoprgmeci
        {
            get
            {
                return VistaModeloMcigrupoprgmeciStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMcigrupoprgmeci
        /// </summary>
        public static void fcvLiberarVistaModeloMcigrupoprgmeci()
        {
            if (_vistaModeloMcigrupoprgmeci != null)
            {
                _vistaModeloMcigrupoprgmeci.Cleanup();
                _vistaModeloMcigrupoprgmeci = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMcigrupoprgmeci
        /// </summary>
        public static void fcvCrearVistaModeloMcigrupoprgmeci()
        {
            if (_vistaModeloMcigrupoprgmeci == null)
            {
                _vistaModeloMcigrupoprgmeci = new VistaModeloMcigrupoprgmeci();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMcipreguntameci
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMcipreguntameci
        private static VistaModeloMcipreguntameci _vistaModeloMcipreguntameci;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcipreguntameci
        /// </summary>
        public static VistaModeloMcipreguntameci VistaModeloMcipreguntameciStatic
        {
            get
            {
                if (_vistaModeloMcipreguntameci == null)
                {
                    fcvCrearVistaModeloMcipreguntameci();
                }
                return _vistaModeloMcipreguntameci;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcipreguntameci
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMcipreguntameci VistaModeloMcipreguntameci
        {
            get
            {
                return VistaModeloMcipreguntameciStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMcipreguntameci
        /// </summary>
        public static void fcvLiberarVistaModeloMcipreguntameci()
        {
            if (_vistaModeloMcipreguntameci != null)
            {
                _vistaModeloMcipreguntameci.Cleanup();
                _vistaModeloMcipreguntameci = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMcipreguntameci
        /// </summary>
        public static void fcvCrearVistaModeloMcipreguntameci()
        {
            if (_vistaModeloMcipreguntameci == null)
            {
                _vistaModeloMcipreguntameci = new VistaModeloMcipreguntameci();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMcievaluacionms
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMcievaluacionms
        private static VistaModeloMcievaluacionms _vistaModeloMcievaluacionms;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcievaluacionms
        /// </summary>
        public static VistaModeloMcievaluacionms VistaModeloMcievaluacionmsStatic
        {
            get
            {
                if (_vistaModeloMcievaluacionms == null)
                {
                    fcvCrearVistaModeloMcievaluacionms();
                }
                return _vistaModeloMcievaluacionms;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMcievaluacionms
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMcievaluacionms VistaModeloMcievaluacionms
        {
            get
            {
                return VistaModeloMcievaluacionmsStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMcievaluacionms
        /// </summary>
        public static void fcvLiberarVistaModeloMcievaluacionms()
        {
            if (_vistaModeloMcievaluacionms != null)
            {
                _vistaModeloMcievaluacionms.Cleanup();
                _vistaModeloMcievaluacionms = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMcievaluacionms
        /// </summary>
        public static void fcvCrearVistaModeloMcievaluacionms()
        {
            if (_vistaModeloMcievaluacionms == null)
            {
                _vistaModeloMcievaluacionms = new VistaModeloMcievaluacionms();
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
            fcvLiberarVistaModeloMciplantillmeci();
            fcvLiberarVistaModeloMcicomponenmeci();
            fcvLiberarVistaModeloMciparametrmeci();
            fcvLiberarVistaModeloMcigrupoprgmeci();
            fcvLiberarVistaModeloMcipreguntameci();
            fcvLiberarVistaModeloMcievaluacionms();
        }
    }
}
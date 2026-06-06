using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Sistema.VistaModelo;


namespace Systemas.VistaModelo
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
        // Codigo Localizador para: VistaModeloSysgeneradorcod
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSysgeneradorcod
        private static VistaModeloSysgeneradorcod _vistaModeloSysgeneradorcod;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysgeneradorcod
        /// </summary>
        public static VistaModeloSysgeneradorcod VistaModeloSysgeneradorcodStatic
        {
            get
            {
                if (_vistaModeloSysgeneradorcod == null)
                {
                    fcvCrearVistaModeloSysgeneradorcod();
                }
                return _vistaModeloSysgeneradorcod;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysgeneradorcod
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSysgeneradorcod VistaModeloSysgeneradorcod
        {
            get
            {
                return VistaModeloSysgeneradorcodStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSysgeneradorcod
        /// </summary>
        public static void fcvLiberarVistaModeloSysgeneradorcod()
        {
            if (_vistaModeloSysgeneradorcod != null)
            {
                _vistaModeloSysgeneradorcod.Cleanup();
                _vistaModeloSysgeneradorcod = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSysgeneradorcod
        /// </summary>
        public static void fcvCrearVistaModeloSysgeneradorcod()
        {
            if (_vistaModeloSysgeneradorcod == null)
            {
                _vistaModeloSysgeneradorcod = new VistaModeloSysgeneradorcod();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSysusuarios
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSysusuarios
        private static VistaModeloSysusuarios _vistaModeloSysusuarios;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysusuarios
        /// </summary>
        public static VistaModeloSysusuarios VistaModeloSysusuariosStatic
        {
            get
            {
                if (_vistaModeloSysusuarios == null)
                {
                    fcvCrearVistaModeloSysusuarios();
                }
                return _vistaModeloSysusuarios;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysusuarios
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSysusuarios VistaModeloSysusuarios
        {
            get
            {
                return VistaModeloSysusuariosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSysusuarios
        /// </summary>
        public static void fcvLiberarVistaModeloSysusuarios()
        {
            if (_vistaModeloSysusuarios != null)
            {
                _vistaModeloSysusuarios.Cleanup();
                _vistaModeloSysusuarios = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSysusuarios
        /// </summary>
        public static void fcvCrearVistaModeloSysusuarios()
        {
            if (_vistaModeloSysusuarios == null)
            {
                _vistaModeloSysusuarios = new VistaModeloSysusuarios();
            }
        }
        #endregion        
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSysperfiusuario
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSysperfiusuario
        private static VistaModeloSysperfiusuario _vistaModeloSysperfiusuario;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysperfiusuario
        /// </summary>
        public static VistaModeloSysperfiusuario VistaModeloSysperfiusuarioStatic
        {
            get
            {
                if (_vistaModeloSysperfiusuario == null)
                {
                    fcvCrearVistaModeloSysperfiusuario();
                }
                return _vistaModeloSysperfiusuario;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSysperfiusuario
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSysperfiusuario VistaModeloSysperfiusuario
        {
            get
            {
                return VistaModeloSysperfiusuarioStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSysperfiusuario
        /// </summary>
        public static void fcvLiberarVistaModeloSysperfiusuario()
        {
            if (_vistaModeloSysperfiusuario != null)
            {
                _vistaModeloSysperfiusuario.Cleanup();
                _vistaModeloSysperfiusuario = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSysperfiusuario
        /// </summary>
        public static void fcvCrearVistaModeloSysperfiusuario()
        {
            if (_vistaModeloSysperfiusuario == null)
            {
                _vistaModeloSysperfiusuario = new VistaModeloSysperfiusuario();
            }
        }
        #endregion        
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSisparametroips
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSisparametroips
        private static VistaModeloSisparametroips _vistaModeloSisparametroips;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSisparametroips
        /// </summary>
        public static VistaModeloSisparametroips VistaModeloSisparametroipsStatic
        {
            get
            {
                if (_vistaModeloSisparametroips == null)
                {
                    fcvCrearVistaModeloSisparametroips();
                }
                return _vistaModeloSisparametroips;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSisparametroips
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSisparametroips VistaModeloSisparametroips
        {
            get
            {
                return VistaModeloSisparametroipsStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSisparametroips
        /// </summary>
        public static void fcvLiberarVistaModeloSisparametroips()
        {
            if (_vistaModeloSisparametroips != null)
            {
                _vistaModeloSisparametroips.Cleanup();
                _vistaModeloSisparametroips = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSisparametroips
        /// </summary>
        public static void fcvCrearVistaModeloSisparametroips()
        {
            if (_vistaModeloSisparametroips == null)
            {
                _vistaModeloSisparametroips = new VistaModeloSisparametroips();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloSisMaestroTerceros
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSisMaestroTerceros
        private static VistaModeloSisMaestroTerceros _vistaModeloSisMaestroTerceros;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSisMaestroTerceros
        /// </summary>
        public static VistaModeloSisMaestroTerceros VistaModeloSisMaestroTercerosStatic
        {
            get
            {
                if (_vistaModeloSisMaestroTerceros == null)
                {
                    fcvCrearVistaModeloSisMaestroTerceros();
                }
                return _vistaModeloSisMaestroTerceros;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSisMaestroTerceros
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSisMaestroTerceros VistaModeloSisMaestroTerceros
        {
            get
            {
                return VistaModeloSisMaestroTercerosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSisMaestroTerceros
        /// </summary>
        public static void fcvLiberarVistaModeloSisMaestroTerceros()
        {
            if (_vistaModeloSisMaestroTerceros != null)
            {
                _vistaModeloSisMaestroTerceros.Cleanup();
                _vistaModeloSisMaestroTerceros = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSisMaestroTerceros
        /// </summary>
        public static void fcvCrearVistaModeloSisMaestroTerceros()
        {
            if (_vistaModeloSisMaestroTerceros == null)
            {
                _vistaModeloSisMaestroTerceros = new VistaModeloSisMaestroTerceros();
            }
        }
        #endregion
        /// <summary>
        /// Liberar todos los recursos cargados o montados
        /// </summary>
        public static void Cleanup()
        {
            fcvLiberarVistaModeloSysgeneradorcod();
            fcvLiberarVistaModeloSysusuarios();
            fcvLiberarVistaModeloSysperfiusuario();
            fcvLiberarVistaModeloSisparametroips();
            fcvLiberarVistaModeloSisMaestroTerceros();
        }
    }
}
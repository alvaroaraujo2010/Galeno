using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HistoriasClinicas.VistaModelo
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
        // Codigo Localizador para: VistaModeloHclmaehistoriasclinicas
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHclmaehistoriasclinicas
        private static VistaModeloHclmaehistoriasclinicas _vistaModeloHclmaehistoriasclini;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclmaehistoriasclinicas
        /// </summary>
        public static VistaModeloHclmaehistoriasclinicas VistaModeloHclmaehistoriasclinicasStatic
        {
            get
            {
                if (_vistaModeloHclmaehistoriasclini == null)
                {
                    fcvCrearVistaModeloHclmaehistoriasclinicas();
                }
                return _vistaModeloHclmaehistoriasclini;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclmaehistoriasclinicas
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHclmaehistoriasclinicas VistaModeloHclmaehistoriasclinicas
        {
            get
            {
                return VistaModeloHclmaehistoriasclinicasStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHclmaehistoriasclinicas
        /// </summary>
        public static void fcvLiberarVistaModeloHclmaehistoriasclinicas()
        {
            if (_vistaModeloHclmaehistoriasclini != null)
            {
                _vistaModeloHclmaehistoriasclini.Cleanup();
                _vistaModeloHclmaehistoriasclini = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHclmaehistoriasclinicas
        /// </summary>
        public static void fcvCrearVistaModeloHclmaehistoriasclinicas()
        {
            if (_vistaModeloHclmaehistoriasclini == null)
            {
                _vistaModeloHclmaehistoriasclini = new VistaModeloHclmaehistoriasclinicas();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHcltiporegactiv
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHcltiporegactiv
        private static VistaModeloHcltiporegactiv _vistaModeloHcltiporegactiv;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHcltiporegactiv
        /// </summary>
        public static VistaModeloHcltiporegactiv VistaModeloHcltiporegactivStatic
        {
            get
            {
                if (_vistaModeloHcltiporegactiv == null)
                {
                    fcvCrearVistaModeloHcltiporegactiv();
                }
                return _vistaModeloHcltiporegactiv;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHcltiporegactiv
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHcltiporegactiv VistaModeloHcltiporegactiv
        {
            get
            {
                return VistaModeloHcltiporegactivStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHcltiporegactiv
        /// </summary>
        public static void fcvLiberarVistaModeloHcltiporegactiv()
        {
            if (_vistaModeloHcltiporegactiv != null)
            {
                _vistaModeloHcltiporegactiv.Cleanup();
                _vistaModeloHcltiporegactiv = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHcltiporegactiv
        /// </summary>
        public static void fcvCrearVistaModeloHcltiporegactiv()
        {
            if (_vistaModeloHcltiporegactiv == null)
            {
                _vistaModeloHcltiporegactiv = new VistaModeloHcltiporegactiv();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHclvariabmaestro
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHclvariabmaestro
        private static VistaModeloHclvariabmaestro _vistaModeloHclvariabmaestro;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclvariabmaestro
        /// </summary>
        public static VistaModeloHclvariabmaestro VistaModeloHclvariabmaestroStatic
        {
            get
            {
                if (_vistaModeloHclvariabmaestro == null)
                {
                    fcvCrearVistaModeloHclvariabmaestro();
                }
                return _vistaModeloHclvariabmaestro;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclvariabmaestro
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHclvariabmaestro VistaModeloHclvariabmaestro
        {
            get
            {
                return VistaModeloHclvariabmaestroStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHclvariabmaestro
        /// </summary>
        public static void fcvLiberarVistaModeloHclvariabmaestro()
        {
            if (_vistaModeloHclvariabmaestro != null)
            {
                _vistaModeloHclvariabmaestro.Cleanup();
                _vistaModeloHclvariabmaestro = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHclvariabmaestro
        /// </summary>
        public static void fcvCrearVistaModeloHclvariabmaestro()
        {
            if (_vistaModeloHclvariabmaestro == null)
            {
                _vistaModeloHclvariabmaestro = new VistaModeloHclvariabmaestro();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHclvariabgrupos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHclvariabgrupos
        private static VistaModeloHclvariabgrupos _vistaModeloHclvariabgrupos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclvariabgrupos
        /// </summary>
        public static VistaModeloHclvariabgrupos VistaModeloHclvariabgruposStatic
        {
            get
            {
                if (_vistaModeloHclvariabgrupos == null)
                {
                    fcvCrearVistaModeloHclvariabgrupos();
                }
                return _vistaModeloHclvariabgrupos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclvariabgrupos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHclvariabgrupos VistaModeloHclvariabgrupos
        {
            get
            {
                return VistaModeloHclvariabgruposStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHclvariabgrupos
        /// </summary>
        public static void fcvLiberarVistaModeloHclvariabgrupos()
        {
            if (_vistaModeloHclvariabgrupos != null)
            {
                _vistaModeloHclvariabgrupos.Cleanup();
                _vistaModeloHclvariabgrupos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHclvariabgrupos
        /// </summary>
        public static void fcvCrearVistaModeloHclvariabgrupos()
        {
            if (_vistaModeloHclvariabgrupos == null)
            {
                _vistaModeloHclvariabgrupos = new VistaModeloHclvariabgrupos();
            }
        }
        #endregion
        //-------------------------------------------------------
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFormatoPorPerfil
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFormatoPorPerfil
        private static VistaModeloFormatoPorPerfil _vistaModeloFormatoPorPerfil;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFormatoPorPerfil
        /// </summary>
        public static VistaModeloFormatoPorPerfil VistaModeloFormatoPorPerfilStatic
        {
            get
            {
                if (_vistaModeloFormatoPorPerfil == null)
                {
                    fcvCrearVistaModeloFormatoPorPerfil();
                }
                return _vistaModeloFormatoPorPerfil;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFormatoPorPerfil
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFormatoPorPerfil VistaModeloFormatoPorPerfil
        {
            get
            {
                return VistaModeloFormatoPorPerfilStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFormatoPorPerfil
        /// </summary>
        public static void fcvLiberarVistaModeloFormatoPorPerfil()
        {
            if (_vistaModeloFormatoPorPerfil != null)
            {
                _vistaModeloFormatoPorPerfil.Cleanup();
                _vistaModeloFormatoPorPerfil = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFormatoPorPerfil
        /// </summary>
        public static void fcvCrearVistaModeloFormatoPorPerfil()
        {
            if (_vistaModeloFormatoPorPerfil == null)
            {
                _vistaModeloFormatoPorPerfil = new VistaModeloFormatoPorPerfil();
            }
        }
        #endregion
        //------------------------------------------------------
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloHclgestionformat
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloHclgestionformat
        private static VistaModeloHclgestionformat _vistaModeloHclgestionformat;
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclgestionformat
        /// </summary>
        public static VistaModeloHclgestionformat VistaModeloHclgestionformatStatic
        {
            get
            {
                if (_vistaModeloHclgestionformat == null)
                {
                    fcvCrearVistaModeloHclgestionformat();
                }
                return _vistaModeloHclgestionformat;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloHclgestionformat
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloHclgestionformat VistaModeloHclgestionformat
        {
            get
            {
                return VistaModeloHclgestionformatStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloHclgestionformat
        /// </summary>
        public static void fcvLiberarVistaModeloHclgestionformat()
        {
            if (_vistaModeloHclgestionformat != null)
            {
                _vistaModeloHclgestionformat.Cleanup();
                _vistaModeloHclgestionformat = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloHclgestionformat
        /// </summary>
        public static void fcvCrearVistaModeloHclgestionformat()
        {
            if (_vistaModeloHclgestionformat == null)
            {
                _vistaModeloHclgestionformat = new VistaModeloHclgestionformat();
            }
        }
        #endregion
        //------------------------------------------------------
        // Liberar todos los recursos cargados o montados
        //-------------------------------------------------------
        /// <summary>
        /// Liberar todos los recursos cargados o montados
        /// </summary>
        public static void Cleanup()
        {
            fcvLiberarVistaModeloHclmaehistoriasclinicas();
            fcvLiberarVistaModeloHcltiporegactiv();
            fcvLiberarVistaModeloHclvariabmaestro();
            fcvLiberarVistaModeloHclvariabgrupos();
            fcvLiberarVistaModeloFormatoPorPerfil();
            fcvLiberarVistaModeloHclgestionformat();
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace Cartera.VistaModelo
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
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //SimpleIoc.Default.Register<VistaModeloAsignarCitas>();
        }
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloCarGenFactDian
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCarGenFactDian
        private static VistaModeloCarGenFactDian _vistaModeloCarGenFactDian;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCarGenFactDian
        /// </summary>
        public static VistaModeloCarGenFactDian VistaModeloCarGenFactDianStatic
        {
            get
            {
                if (_vistaModeloCarGenFactDian == null)
                {
                    fcvCrearVistaModeloCarGenFactDian();
                }
                return _vistaModeloCarGenFactDian;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCarGenFactDian
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCarGenFactDian VistaModeloCarGenFactDian
        {
            get
            {
                return VistaModeloCarGenFactDianStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCarGenFactDian
        /// </summary>
        public static void fcvLiberarVistaModeloCarGenFactDian()
        {
            if (_vistaModeloCarGenFactDian != null)
            {
                _vistaModeloCarGenFactDian.Cleanup();
                _vistaModeloCarGenFactDian = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCarGenFactDian
        /// </summary>
        public static void fcvCrearVistaModeloCarGenFactDian()
        {
            if (_vistaModeloCarGenFactDian == null)
            {
                _vistaModeloCarGenFactDian = new VistaModeloCarGenFactDian();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloCarconceptfact
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCarconceptfact
        private static VistaModeloCarconceptfact _vistaModeloCarconceptfact;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCarconceptfact
        /// </summary>
        public static VistaModeloCarconceptfact VistaModeloCarconceptfactStatic
        {
            get
            {
                if (_vistaModeloCarconceptfact == null)
                {
                    fcvCrearVistaModeloCarconceptfact();
                }
                return _vistaModeloCarconceptfact;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCarconceptfact
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCarconceptfact VistaModeloCarconceptfact
        {
            get
            {
                return VistaModeloCarconceptfactStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCarconceptfact
        /// </summary>
        public static void fcvLiberarVistaModeloCarconceptfact()
        {
            if (_vistaModeloCarconceptfact != null)
            {
                _vistaModeloCarconceptfact.Cleanup();
                _vistaModeloCarconceptfact = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCarconceptfact
        /// </summary>
        public static void fcvCrearVistaModeloCarconceptfact()
        {
            if (_vistaModeloCarconceptfact == null)
            {
                _vistaModeloCarconceptfact = new VistaModeloCarconceptfact();
            }
        }
        #endregion

        //para la implementacion en el localizador VistaModelo 
        public static void Cleanup()
        {
            fcvLiberarVistaModeloCarGenFactDian();
            fcvLiberarVistaModeloCarconceptfact();
            System.GC.Collect();
        }
    }
}
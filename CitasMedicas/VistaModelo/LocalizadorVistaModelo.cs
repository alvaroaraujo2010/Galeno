using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace CitasMedicas.VistaModelo
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
        // Codigo Localizador para: VistaModeloCitmaestroturno
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCitmaestroturno
        private static VistaModeloCitmaestroturno _vistaModeloCitmaestroturno;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCitmaestroturno
        /// </summary>
        public static VistaModeloCitmaestroturno VistaModeloCitmaestroturnoStatic
        {
            get
            {
                if (_vistaModeloCitmaestroturno == null)
                {
                    fcvCrearVistaModeloCitmaestroturno();
                }
                return _vistaModeloCitmaestroturno;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCitmaestroturno
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCitmaestroturno VistaModeloCitmaestroturno
        {
            get
            {
                return VistaModeloCitmaestroturnoStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCitmaestroturno
        /// </summary>
        public static void fcvLiberarVistaModeloCitmaestroturno()
        {
            if (_vistaModeloCitmaestroturno != null)
            {
                _vistaModeloCitmaestroturno.Cleanup();
                _vistaModeloCitmaestroturno = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCitmaestroturno
        /// </summary>
        public static void fcvCrearVistaModeloCitmaestroturno()
        {
            if (_vistaModeloCitmaestroturno == null)
            {
                _vistaModeloCitmaestroturno = new VistaModeloCitmaestroturno();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloCitmaestroserviciosprog
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCitmaestroserviciosprog
        private static VistaModeloCitmaestroserviciosprog _vistaModeloCitmaestroserviciosp;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCitmaestroserviciosprog
        /// </summary>
        public static VistaModeloCitmaestroserviciosprog VistaModeloCitmaestroserviciosprogStatic
        {
            get
            {
                if (_vistaModeloCitmaestroserviciosp == null)
                {
                    fcvCrearVistaModeloCitmaestroserviciosprog();
                }
                return _vistaModeloCitmaestroserviciosp;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCitmaestroserviciosprog
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCitmaestroserviciosprog VistaModeloCitmaestroserviciosprog
        {
            get
            {
                return VistaModeloCitmaestroserviciosprogStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCitmaestroserviciosprog
        /// </summary>
        public static void fcvLiberarVistaModeloCitmaestroserviciosprog()
        {
            if (_vistaModeloCitmaestroserviciosp != null)
            {
                _vistaModeloCitmaestroserviciosp.Cleanup();
                _vistaModeloCitmaestroserviciosp = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCitmaestroserviciosprog
        /// </summary>
        public static void fcvCrearVistaModeloCitmaestroserviciosprog()
        {
            if (_vistaModeloCitmaestroserviciosp == null)
            {
                _vistaModeloCitmaestroserviciosp = new VistaModeloCitmaestroserviciosprog();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAsignarCitas
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAsignarCitas
        private static VistaModeloAsignarCitas _vistaModeloAsignarCitas;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAsignarCitas
        /// </summary>
        public static VistaModeloAsignarCitas VistaModeloAsignarCitasStatic
        {
            get
            {
                if (_vistaModeloAsignarCitas == null)
                {
                    fcvCrearVistaModeloAsignarCitas();
                }
                return _vistaModeloAsignarCitas;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAsignarCitas
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAsignarCitas VistaModeloAsignarCitas
        {
            get
            {
                return VistaModeloAsignarCitasStatic;
                //return ServiceLocator.Current.GetInstance<VistaModeloAsignarCitas>();
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAsignarCitas
        /// </summary>
        public static void fcvLiberarVistaModeloAsignarCitas()
        {
            if (_vistaModeloAsignarCitas != null)
            {
                _vistaModeloAsignarCitas.Cleanup();
                _vistaModeloAsignarCitas = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAsignarCitas
        /// </summary>
        public static void fcvCrearVistaModeloAsignarCitas()
        {
            if (_vistaModeloAsignarCitas == null)
            {
                _vistaModeloAsignarCitas = new VistaModeloAsignarCitas();

            }
        }
        #endregion

        //para la implementacion en el localizador VistaModelo 
        public static void Cleanup()
        {
            fcvLiberarVistaModeloCitmaestroturno();
            fcvLiberarVistaModeloCitmaestroserviciosprog();
            fcvLiberarVistaModeloAsignarCitas();
            System.GC.Collect();
        }
    }
}
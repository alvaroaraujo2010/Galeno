using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace Sistema.VistaModelo
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
        // Codigo Localizador para: VistaModeloSismaesplavalid
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloSismaesplavalid
        private static VistaModeloSismaesplavalid _vistaModeloSismaesplavalid;
        /// <summary>
        ///Leer las Propiedades de VistaModeloSismaesplavalid
        /// </summary>
        public static VistaModeloSismaesplavalid VistaModeloSismaesplavalidStatic
        {
            get
            {
                if (_vistaModeloSismaesplavalid == null)
                {
                    fcvCrearVistaModeloSismaesplavalid();
                }
                return _vistaModeloSismaesplavalid;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloSismaesplavalid
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloSismaesplavalid VistaModeloSismaesplavalid
        {
            get
            {
                return VistaModeloSismaesplavalidStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloSismaesplavalid
        /// </summary>
        public static void fcvLiberarVistaModeloSismaesplavalid()
        {
            if (_vistaModeloSismaesplavalid != null)
            {
                _vistaModeloSismaesplavalid.Cleanup();
                _vistaModeloSismaesplavalid = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloSismaesplavalid
        /// </summary>
        public static void fcvCrearVistaModeloSismaesplavalid()
        {
            if (_vistaModeloSismaesplavalid == null)
            {
                _vistaModeloSismaesplavalid = new VistaModeloSismaesplavalid();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloTransacpagoservicios
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloTransacpagoservicios
        private static VistaModeloTransacCajaFacturacion _vistaModeloTransacCajaFacturacion;
        /// <summary>
        ///Leer las Propiedades de VistaModeloTransacpagoservicios
        /// </summary>
        public static VistaModeloTransacCajaFacturacion VistaModeloTransacCajaFacturacionStatic
        {
            get
            {
                if (_vistaModeloTransacCajaFacturacion == null)
                {
                    fcvCrearVistaModeloTransacCajaPagos();
                }
                return _vistaModeloTransacCajaFacturacion;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloTransacpagoservicios
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloTransacCajaFacturacion VistaModeloTransacCajaFacturacion
        {
            get
            {
                return VistaModeloTransacCajaFacturacionStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloTransacpagoservicios
        /// </summary>
        public static void fcvLiberarVistaModeloTransacCajaFacturacion()
        {
            if (_vistaModeloTransacCajaFacturacion != null)
            {
                _vistaModeloTransacCajaFacturacion.Cleanup();
                _vistaModeloTransacCajaFacturacion = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloTransacpagoservicios
        /// </summary>
        public static void fcvCrearVistaModeloTransacCajaPagos()
        {
            if (_vistaModeloTransacCajaFacturacion == null)
            {
                _vistaModeloTransacCajaFacturacion = new VistaModeloTransacCajaFacturacion();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloGestorCorreos
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloGestorCorreos
        private static VistaModeloGestorCorreos _VistaModeloGestorCorreos;
        /// <summary>
        ///Leer las Propiedades de VistaModeloGestorCorreos
        /// </summary>
        public static VistaModeloGestorCorreos VistaModeloGestorCorreosStatic
        {
            get
            {
                if (_VistaModeloGestorCorreos == null)
                {
                    fcvCrearVistaModeloGestorCorreos();
                }
                return _VistaModeloGestorCorreos;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloGestorCorreos
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloGestorCorreos VistaModeloGestorCorreos
        {
            get
            {
                return VistaModeloGestorCorreosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloGestorCorreos
        /// </summary>
        public static void fcvLiberarVistaModeloGestorCorreos()
        {
            if (_VistaModeloGestorCorreos != null)
            {
                _VistaModeloGestorCorreos.Cleanup();
                _VistaModeloGestorCorreos = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloGestorCorreos
        /// </summary>
        public static void fcvCrearVistaModeloGestorCorreos()
        {
            if (_VistaModeloGestorCorreos == null)
            {
                _VistaModeloGestorCorreos = new VistaModeloGestorCorreos();
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
            fcvLiberarVistaModeloSismaesplavalid();
            fcvLiberarVistaModeloTransacCajaFacturacion();
            fcvLiberarVistaModeloGestorCorreos();
            System.GC.Collect();
        }
    }
}
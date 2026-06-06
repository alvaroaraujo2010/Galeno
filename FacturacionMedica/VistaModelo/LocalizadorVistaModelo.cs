using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace FacturacionMedica.VistaModelo
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
        // Codigo Localizador para: VistaModeloOrdenesmedicas
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloOrdenesmedicas
        private static VistaModeloOrdenesmedicas _vistaModeloOrdenesmedicas;
        /// <summary>
        ///Leer las Propiedades de VistaModeloOrdenesmedicas
        /// </summary>
        public static VistaModeloOrdenesmedicas VistaModeloOrdenesmedicasStatic
        {
            get
            {
                if (_vistaModeloOrdenesmedicas == null)
                {
                    fcvCrearVistaModeloOrdenesmedicas();
                }
                return _vistaModeloOrdenesmedicas;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloOrdenesmedicas
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloOrdenesmedicas VistaModeloOrdenesmedicas
        {
            get
            {
                return VistaModeloOrdenesmedicasStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloOrdenesmedicas
        /// </summary>
        public static void fcvLiberarVistaModeloOrdenesmedicas()
        {
            if (_vistaModeloOrdenesmedicas != null)
            {
                _vistaModeloOrdenesmedicas.Cleanup();
                _vistaModeloOrdenesmedicas = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloOrdenesmedicas
        /// </summary>
        public static void fcvCrearVistaModeloOrdenesmedicas()
        {
            if (_vistaModeloOrdenesmedicas == null)
            {
                _vistaModeloOrdenesmedicas = new VistaModeloOrdenesmedicas();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFcmManualdeserviciosIPS
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFcmManualdeserviciosIPS
        private static VistaModeloFcmManualdeserviciosIPS _vistaModeloFcmManualdeservicios;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmManualdeserviciosIPS
        /// </summary>
        public static VistaModeloFcmManualdeserviciosIPS VistaModeloFcmManualdeserviciosIPSStatic
        {
            get
            {
                if (_vistaModeloFcmManualdeservicios == null)
                {
                    fcvCrearVistaModeloFcmManualdeserviciosIPS();
                }
                return _vistaModeloFcmManualdeservicios;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmManualdeserviciosIPS
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFcmManualdeserviciosIPS VistaModeloFcmManualdeserviciosIPS
        {
            get
            {
                return VistaModeloFcmManualdeserviciosIPSStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFcmManualdeserviciosIPS
        /// </summary>
        public static void fcvLiberarVistaModeloFcmManualdeserviciosIPS()
        {
            if (_vistaModeloFcmManualdeservicios != null)
            {
                _vistaModeloFcmManualdeservicios.Cleanup();
                _vistaModeloFcmManualdeservicios = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFcmManualdeserviciosIPS
        /// </summary>
        public static void fcvCrearVistaModeloFcmManualdeserviciosIPS()
        {
            if (_vistaModeloFcmManualdeservicios == null)
            {
                _vistaModeloFcmManualdeservicios = new VistaModeloFcmManualdeserviciosIPS();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloTransacpagoservicios
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloTransacpagoservicios
        private static VistaModeloTransacpagoservicios _vistaModeloTransacpagoservicios;
        /// <summary>
        ///Leer las Propiedades de VistaModeloTransacpagoservicios
        /// </summary>
        public static VistaModeloTransacpagoservicios VistaModeloTransacpagoserviciosStatic
        {
            get
            {
                if (_vistaModeloTransacpagoservicios == null)
                {
                    fcvCrearVistaModeloTransacpagoservicios();
                }
                return _vistaModeloTransacpagoservicios;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloTransacpagoservicios
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloTransacpagoservicios VistaModeloTransacpagoservicios
        {
            get
            {
                return VistaModeloTransacpagoserviciosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloTransacpagoservicios
        /// </summary>
        public static void fcvLiberarVistaModeloTransacpagoservicios()
        {
            if (_vistaModeloTransacpagoservicios != null)
            {
                _vistaModeloTransacpagoservicios.Cleanup();
                _vistaModeloTransacpagoservicios = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloTransacpagoservicios
        /// </summary>
        public static void fcvCrearVistaModeloTransacpagoservicios()
        {
            if (_vistaModeloTransacpagoservicios == null)
            {
                _vistaModeloTransacpagoservicios = new VistaModeloTransacpagoservicios();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAutorizarDescuento
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAutorizarDescuento
        private static VistaModeloAutorizarDescuento _vistaModeloAutorizarDescuento;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAutorizarDescuento
        /// </summary>
        public static VistaModeloAutorizarDescuento VistaModeloAutorizarDescuentoStatic
        {
            get
            {
                if (_vistaModeloAutorizarDescuento == null)
                {
                    fcvCrearVistaModeloAutorizarDescuento();
                }
                return _vistaModeloAutorizarDescuento;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAutorizarDescuento
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAutorizarDescuento VistaModeloAutorizarDescuento
        {
            get
            {
                return VistaModeloAutorizarDescuentoStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAutorizarDescuento
        /// </summary>
        public static void fcvLiberarVistaModeloAutorizarDescuento()
        {
            if (_vistaModeloAutorizarDescuento != null)
            {
                _vistaModeloAutorizarDescuento.Cleanup();
                _vistaModeloAutorizarDescuento = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAutorizarDescuento
        /// </summary>
        public static void fcvCrearVistaModeloAutorizarDescuento()
        {
            if (_vistaModeloAutorizarDescuento == null)
            {
                _vistaModeloAutorizarDescuento = new VistaModeloAutorizarDescuento();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFcmcenproduccio
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFcmcenproduccio
        private static VistaModeloFcmcenproduccio _vistaModeloFcmcenproduccio;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmcenproduccio
        /// </summary>
        public static VistaModeloFcmcenproduccio VistaModeloFcmcenproduccioStatic
        {
            get
            {
                if (_vistaModeloFcmcenproduccio == null)
                {
                    fcvCrearVistaModeloFcmcenproduccio();
                }
                return _vistaModeloFcmcenproduccio;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmcenproduccio
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFcmcenproduccio VistaModeloFcmcenproduccio
        {
            get
            {
                return VistaModeloFcmcenproduccioStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFcmcenproduccio
        /// </summary>
        public static void fcvLiberarVistaModeloFcmcenproduccio()
        {
            if (_vistaModeloFcmcenproduccio != null)
            {
                _vistaModeloFcmcenproduccio.Cleanup();
                _vistaModeloFcmcenproduccio = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFcmcenproduccio
        /// </summary>
        public static void fcvCrearVistaModeloFcmcenproduccio()
        {
            if (_vistaModeloFcmcenproduccio == null)
            {
                _vistaModeloFcmcenproduccio = new VistaModeloFcmcenproduccio();
            }
        }
        #endregion        
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloRegistroAmbulatorio
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloRegistroAmbulatorio
        private static VistaModeloRegistroAmbulatorio _VistaModeloRegistroAmbulatorio;
        /// <summary>
        ///Leer las Propiedades de VistaModeloRegistroAmbulatorio
        /// </summary>
        public static VistaModeloRegistroAmbulatorio VistaModeloRegistroAmbulatorioStatic
        {
            get
            {
                if (_VistaModeloRegistroAmbulatorio == null)
                {
                    fcvCrearVistaModeloRegistroAmbulatorio();
                }
                return _VistaModeloRegistroAmbulatorio;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloRegistroAmbulatorio
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloRegistroAmbulatorio VistaModeloRegistroAmbulatorio
        {
            get
            {
                return VistaModeloRegistroAmbulatorioStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloRegistroAmbulatorio
        /// </summary>
        public static void fcvLiberarVistaModeloRegistroAmbulatorio()
        {
            if (_VistaModeloRegistroAmbulatorio != null)
            {
                _VistaModeloRegistroAmbulatorio.Cleanup();
                _VistaModeloRegistroAmbulatorio = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloRegistroAmbulatorio
        /// </summary>
        public static void fcvCrearVistaModeloRegistroAmbulatorio()
        {
            if (_VistaModeloRegistroAmbulatorio == null)
            {
                _VistaModeloRegistroAmbulatorio = new VistaModeloRegistroAmbulatorio();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFcmManualServicios
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFcmManualServicios
        private static VistaModeloFcmManualServicios _vistaModeloFcmManualServicios;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmManualServicios
        /// </summary>
        public static VistaModeloFcmManualServicios VistaModeloFcmManualServiciosStatic
        {
            get
            {
                if (_vistaModeloFcmManualServicios == null)
                {
                    fcvCrearVistaModeloFcmManualServicios();
                }
                return _vistaModeloFcmManualServicios;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmManualServicios
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFcmManualServicios VistaModeloFcmManualServicios
        {
            get
            {
                return VistaModeloFcmManualServiciosStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFcmManualServicios
        /// </summary>
        public static void fcvLiberarVistaModeloFcmManualServicios()
        {
            if (_vistaModeloFcmManualServicios != null)
            {
                _vistaModeloFcmManualServicios.Cleanup();
                _vistaModeloFcmManualServicios = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFcmManualServicios
        /// </summary>
        public static void fcvCrearVistaModeloFcmManualServicios()
        {
            if (_vistaModeloFcmManualServicios == null)
            {
                _vistaModeloFcmManualServicios = new VistaModeloFcmManualServicios();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloCuentaCobro
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloCuentaCobro
        private static VistaModeloCuentaCobro _vistaModeloCuentaCobro;
        /// <summary>
        ///Leer las Propiedades de VistaModeloCuentaCobro
        /// </summary>
        public static VistaModeloCuentaCobro VistaModeloCuentaCobroStatic
        {
            get
            {
                if (_vistaModeloCuentaCobro == null)
                {
                    fcvCrearVistaModeloCuentaCobro();
                }
                return _vistaModeloCuentaCobro;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloCuentaCobro
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCuentaCobro VistaModeloCuentaCobro
        {
            get
            {
                return VistaModeloCuentaCobroStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloCuentaCobro
        /// </summary>
        public static void fcvLiberarVistaModeloCuentaCobro()
        {
            if (_vistaModeloCuentaCobro != null)
            {
                _vistaModeloCuentaCobro.Cleanup();
                _vistaModeloCuentaCobro = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloCuentaCobro
        /// </summary>
        public static void fcvCrearVistaModeloCuentaCobro()
        {
            if (_vistaModeloCuentaCobro == null)
            {
                _vistaModeloCuentaCobro = new VistaModeloCuentaCobro();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAtencionAmbulatoria
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAtencionAmbulatoria
        private static VistaModeloCompletarRips _vistaModeloCompletarRips;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAtencionAmbulatoria
        /// </summary>
        public static VistaModeloCompletarRips VistaModeloCompletarRipsStatic
        {
            get
            {
                if (_vistaModeloCompletarRips == null)
                {
                    fcvCrearVistaModeloCompletarRips();
                }
                return _vistaModeloCompletarRips;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAtencionAmbulatoria
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloCompletarRips VistaModeloCompletarRips
        {
            get
            {
                return VistaModeloCompletarRipsStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAtencionAmbulatoria
        /// </summary>
        public static void fcvLiberarVistaModeloCompletarRips()
        {
            if (_vistaModeloCompletarRips != null)
            {
                _vistaModeloCompletarRips.Cleanup();
                _vistaModeloCompletarRips = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAtencionAmbulatoria
        /// </summary>
        public static void fcvCrearVistaModeloCompletarRips()
        {
            if (_vistaModeloCompletarRips == null)
            {
                _vistaModeloCompletarRips = new VistaModeloCompletarRips();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloVistaResolucionDian
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloVistaResolucionDian
        private static VistaModeloVistaResolucionDian _vistaModeloVistaResolucionDian;
        /// <summary>
        ///Leer las Propiedades de VistaModeloVistaResolucionDian
        /// </summary>
        public static VistaModeloVistaResolucionDian VistaModeloVistaResolucionDianStatic
        {
            get
            {
                if (_vistaModeloVistaResolucionDian == null)
                {
                    fcvCrearVistaModeloVistaResolucionDian();
                }
                return _vistaModeloVistaResolucionDian;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloVistaResolucionDian
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloVistaResolucionDian VistaModeloVistaResolucionDian
        {
            get
            {
                return VistaModeloVistaResolucionDianStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloVistaResolucionDian
        /// </summary>
        public static void fcvLiberarVistaModeloVistaResolucionDian()
        {
            if (_vistaModeloVistaResolucionDian != null)
            {
                _vistaModeloVistaResolucionDian.Cleanup();
                _vistaModeloVistaResolucionDian = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloVistaResolucionDian
        /// </summary>
        public static void fcvCrearVistaModeloVistaResolucionDian()
        {
            if (_vistaModeloVistaResolucionDian == null)
            {
                _vistaModeloVistaResolucionDian = new VistaModeloVistaResolucionDian();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFcmsoatmanualma
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFcmsoatmanualma
        private static VistaModeloFcmsoatmanualma _vistaModeloFcmsoatmanualma;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmsoatmanualma
        /// </summary>
        public static VistaModeloFcmsoatmanualma VistaModeloFcmsoatmanualmaStatic
        {
            get
            {
                if (_vistaModeloFcmsoatmanualma == null)
                {
                    fcvCrearVistaModeloFcmsoatmanualma();
                }
                return _vistaModeloFcmsoatmanualma;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFcmsoatmanualma
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFcmsoatmanualma VistaModeloFcmsoatmanualma
        {
            get
            {
                return VistaModeloFcmsoatmanualmaStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFcmsoatmanualma
        /// </summary>
        public static void fcvLiberarVistaModeloFcmsoatmanualma()
        {
            if (_vistaModeloFcmsoatmanualma != null)
            {
                _vistaModeloFcmsoatmanualma.Cleanup();
                _vistaModeloFcmsoatmanualma = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFcmsoatmanualma
        /// </summary>
        public static void fcvCrearVistaModeloFcmsoatmanualma()
        {
            if (_vistaModeloFcmsoatmanualma == null)
            {
                _vistaModeloFcmsoatmanualma = new VistaModeloFcmsoatmanualma();
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
            fcvLiberarVistaModeloOrdenesmedicas();
            fcvLiberarVistaModeloFcmManualdeserviciosIPS();
            fcvLiberarVistaModeloTransacpagoservicios();
            fcvLiberarVistaModeloAutorizarDescuento();
            fcvLiberarVistaModeloFcmcenproduccio();
            fcvLiberarVistaModeloFcmManualServicios();
            fcvLiberarVistaModeloCuentaCobro();
            fcvLiberarVistaModeloCompletarRips();
            fcvLiberarVistaModeloVistaResolucionDian();
            fcvLiberarVistaModeloFcmsoatmanualma();
        }
    }
}
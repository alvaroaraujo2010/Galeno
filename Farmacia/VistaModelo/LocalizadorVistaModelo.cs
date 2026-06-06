using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Farmacia.VistaModelo
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
        // Codigo Localizador para: VistaModeloEntregaMedica
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloEntregaMedica
        private static VistaModeloEntregaMedica _vistaModeloEntregaMedica;
        /// <summary>
        ///Leer las Propiedades de VistaModeloEntregaMedica
        /// </summary>
        public static VistaModeloEntregaMedica VistaModeloEntregaMedicaStatic
        {
            get
            {
                if (_vistaModeloEntregaMedica == null)
                {
                    fcvCrearVistaModeloEntregaMedica();
                }
                return _vistaModeloEntregaMedica;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloEntregaMedica
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloEntregaMedica VistaModeloEntregaMedica
        {
            get
            {
                return VistaModeloEntregaMedicaStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloEntregaMedica
        /// </summary>
        public static void fcvLiberarVistaModeloEntregaMedica()
        {
            if (_vistaModeloEntregaMedica != null)
            {
                _vistaModeloEntregaMedica.Cleanup();
                _vistaModeloEntregaMedica = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloEntregaMedica
        /// </summary>
        public static void fcvCrearVistaModeloEntregaMedica()
        {
            if (_vistaModeloEntregaMedica == null)
            {
                _vistaModeloEntregaMedica = new VistaModeloEntregaMedica();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloFarExpedienteMedicamento
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloFarExpedienteMedicamento
        private static VistaModeloFarExpedienteMedicamento _vistaModeloFarExpedienteMedicam;
        /// <summary>
        ///Leer las Propiedades de VistaModeloFarExpedienteMedicamento
        /// </summary>
        public static VistaModeloFarExpedienteMedicamento VistaModeloFarExpedienteMedicamentoStatic
        {
            get
            {
                if (_vistaModeloFarExpedienteMedicam == null)
                {
                    fcvCrearVistaModeloFarExpedienteMedicamento();
                }
                return _vistaModeloFarExpedienteMedicam;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloFarExpedienteMedicamento
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloFarExpedienteMedicamento VistaModeloFarExpedienteMedicamento
        {
            get
            {
                return VistaModeloFarExpedienteMedicamentoStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloFarExpedienteMedicamento
        /// </summary>
        public static void fcvLiberarVistaModeloFarExpedienteMedicamento()
        {
            if (_vistaModeloFarExpedienteMedicam != null)
            {
                _vistaModeloFarExpedienteMedicam.Cleanup();
                _vistaModeloFarExpedienteMedicam = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloFarExpedienteMedicamento
        /// </summary>
        public static void fcvCrearVistaModeloFarExpedienteMedicamento()
        {
            if (_vistaModeloFarExpedienteMedicam == null)
            {
                _vistaModeloFarExpedienteMedicam = new VistaModeloFarExpedienteMedicamento();
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
            //fcvLiberarHoscamasareasVistaModelo();
            fcvLiberarVistaModeloEntregaMedica();
            fcvLiberarVistaModeloFarExpedienteMedicamento();

        }
    }
}
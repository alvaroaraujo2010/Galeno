using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace GestorReportes.VistaModelo
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
        // Codigo Localizador para: VistaModeloObjetoActivo
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloObjetoActivo
        private static VistaModeloObjetoActivo _vistaModeloObjetoActivo;
        /// <summary>
        ///Leer las Propiedades de VistaModeloObjetoActivo
        /// </summary>
        public static VistaModeloObjetoActivo VistaModeloObjetoActivoStatic
        {
            get
            {
                if (_vistaModeloObjetoActivo == null)
                {
                    fcvCrearVistaModeloObjetoActivo();
                }
                return _vistaModeloObjetoActivo;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloObjetoActivo
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloObjetoActivo VistaModeloObjetoActivo
        {
            get
            {
                return VistaModeloObjetoActivoStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloObjetoActivo
        /// </summary>
        public static void fcvLiberarVistaModeloObjetoActivo()
        {
            if (_vistaModeloObjetoActivo != null)
            {
                _vistaModeloObjetoActivo.Cleanup();
                _vistaModeloObjetoActivo = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloObjetoActivo
        /// </summary>
        public static void fcvCrearVistaModeloObjetoActivo()
        {
            if (_vistaModeloObjetoActivo == null)
            {
                _vistaModeloObjetoActivo = new VistaModeloObjetoActivo();
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
            //fcvLiberarVistaModeloMaestroActividades();
        }
    }
}
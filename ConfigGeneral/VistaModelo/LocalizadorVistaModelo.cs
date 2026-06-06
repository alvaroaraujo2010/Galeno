using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ConfigGeneral.VistaModelo
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
        // Liberar todos los recursos cargados o montados
        //-------------------------------------------------------
        /// <summary>
        /// Liberar todos los recursos cargados o montados
        /// </summary>
        public static void Cleanup()
        {
            //fcvLiberarHoscamasareasVistaModelo();

        }
    }
}
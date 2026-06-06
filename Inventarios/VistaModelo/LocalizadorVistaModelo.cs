using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventarios.VistaModelo
{
    public class LocalizadorVistaModelo
    {

        static LocalizadorVistaModelo()
        {
            //Constructor
        }
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloEntradaCompras
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloEntradaCompras
        private static VistaModeloEntradaCompras _vistaModeloEntradaCompras;
        /// <summary>
        ///Leer las Propiedades de VistaModeloEntradaCompras
        /// </summary>
        public static VistaModeloEntradaCompras VistaModeloEntradaComprasStatic
        {
            get
            {
                if (_vistaModeloEntradaCompras == null)
                {
                    fcvCrearVistaModeloEntradaCompras();
                }
                return _vistaModeloEntradaCompras;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloEntradaCompras
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloEntradaCompras VistaModeloEntradaCompras
        {
            get
            {
                return VistaModeloEntradaComprasStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloEntradaCompras
        /// </summary>
        public static void fcvLiberarVistaModeloEntradaCompras()
        {
            if (_vistaModeloEntradaCompras != null)
            {
                _vistaModeloEntradaCompras.Cleanup();
                _vistaModeloEntradaCompras = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloEntradaCompras
        /// </summary>
        public static void fcvCrearVistaModeloEntradaCompras()
        {
            if (_vistaModeloEntradaCompras == null)
            {
                _vistaModeloEntradaCompras = new VistaModeloEntradaCompras();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvMaestroalmacen
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvMaestroalmacen
        private static VistaModeloInvMaestroalmacen _vistaModeloInvMaestroalmacen;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvMaestroalmacen
        /// </summary>
        public static VistaModeloInvMaestroalmacen VistaModeloInvMaestroalmacenStatic
        {
            get
            {
                if (_vistaModeloInvMaestroalmacen == null)
                {
                    fcvCrearVistaModeloInvMaestroalmacen();
                }
                return _vistaModeloInvMaestroalmacen;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvMaestroalmacen
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvMaestroalmacen VistaModeloInvMaestroalmacen
        {
            get
            {
                return VistaModeloInvMaestroalmacenStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvMaestroalmacen
        /// </summary>
        public static void fcvLiberarVistaModeloInvMaestroalmacen()
        {
            if (_vistaModeloInvMaestroalmacen != null)
            {
                _vistaModeloInvMaestroalmacen.Cleanup();
                _vistaModeloInvMaestroalmacen = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvMaestroalmacen
        /// </summary>
        public static void fcvCrearVistaModeloInvMaestroalmacen()
        {
            if (_vistaModeloInvMaestroalmacen == null)
            {
                _vistaModeloInvMaestroalmacen = new VistaModeloInvMaestroalmacen();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvmaestroarticulo
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvmaestroarticulo
        private static VistaModeloInvmaestroarticulo _vistaModeloInvmaestroarticulo;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvmaestroarticulo
        /// </summary>
        public static VistaModeloInvmaestroarticulo VistaModeloInvmaestroarticuloStatic
        {
            get
            {
                if (_vistaModeloInvmaestroarticulo == null)
                {
                    fcvCrearVistaModeloInvmaestroarticulo();
                }
                return _vistaModeloInvmaestroarticulo;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvmaestroarticulo
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvmaestroarticulo VistaModeloInvmaestroarticulo
        {
            get
            {
                return VistaModeloInvmaestroarticuloStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvmaestroarticulo
        /// </summary>
        public static void fcvLiberarVistaModeloInvmaestroarticulo()
        {
            if (_vistaModeloInvmaestroarticulo != null)
            {
                _vistaModeloInvmaestroarticulo.Cleanup();
                _vistaModeloInvmaestroarticulo = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvmaestroarticulo
        /// </summary>
        public static void fcvCrearVistaModeloInvmaestroarticulo()
        {
            if (_vistaModeloInvmaestroarticulo == null)
            {
                _vistaModeloInvmaestroarticulo = new VistaModeloInvmaestroarticulo();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvcontenedores
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvcontenedores
        private static VistaModeloInvcontenedores _vistaModeloInvcontenedores;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvcontenedores
        /// </summary>
        public static VistaModeloInvcontenedores VistaModeloInvcontenedoresStatic
        {
            get
            {
                if (_vistaModeloInvcontenedores == null)
                {
                    fcvCrearVistaModeloInvcontenedores();
                }
                return _vistaModeloInvcontenedores;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvcontenedores
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvcontenedores VistaModeloInvcontenedores
        {
            get
            {
                return VistaModeloInvcontenedoresStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvcontenedores
        /// </summary>
        public static void fcvLiberarVistaModeloInvcontenedores()
        {
            if (_vistaModeloInvcontenedores != null)
            {
                _vistaModeloInvcontenedores.Cleanup();
                _vistaModeloInvcontenedores = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvcontenedores
        /// </summary>
        public static void fcvCrearVistaModeloInvcontenedores()
        {
            if (_vistaModeloInvcontenedores == null)
            {
                _vistaModeloInvcontenedores = new VistaModeloInvcontenedores();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvperiodomaest
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvperiodomaest
        private static VistaModeloInvperiodomaest _vistaModeloInvperiodomaest;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvperiodomaest
        /// </summary>
        public static VistaModeloInvperiodomaest VistaModeloInvperiodomaestStatic
        {
            get
            {
                if (_vistaModeloInvperiodomaest == null)
                {
                    fcvCrearVistaModeloInvperiodomaest();
                }
                return _vistaModeloInvperiodomaest;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvperiodomaest
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvperiodomaest VistaModeloInvperiodomaest
        {
            get
            {
                return VistaModeloInvperiodomaestStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvperiodomaest
        /// </summary>
        public static void fcvLiberarVistaModeloInvperiodomaest()
        {
            if (_vistaModeloInvperiodomaest != null)
            {
                _vistaModeloInvperiodomaest.Cleanup();
                _vistaModeloInvperiodomaest = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvperiodomaest
        /// </summary>
        public static void fcvCrearVistaModeloInvperiodomaest()
        {
            if (_vistaModeloInvperiodomaest == null)
            {
                _vistaModeloInvperiodomaest = new VistaModeloInvperiodomaest();
            }
        }
        #endregion      
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvresponsables
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvresponsables
        private static VistaModeloInvresponsables _vistaModeloInvresponsables;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvresponsables
        /// </summary>
        public static VistaModeloInvresponsables VistaModeloInvresponsablesStatic
        {
            get
            {
                if (_vistaModeloMovSuministro == null)
                {
                    fcvCrearVistaModeloInvresponsables();
                }
                return _vistaModeloInvresponsables;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvresponsables
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvresponsables VistaModeloInvresponsables
        {
            get
            {
                return VistaModeloInvresponsablesStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvresponsables
        /// </summary>
        public static void fcvLiberarVistaModeloInvresponsables()
        {
            if (_vistaModeloInvresponsables != null)
            {
                _vistaModeloInvresponsables.Cleanup();
                _vistaModeloInvresponsables = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvresponsables
        /// </summary>
        public static void fcvCrearVistaModeloInvresponsables()
        {
            if (_vistaModeloInvresponsables == null)
            {
                _vistaModeloInvresponsables = new VistaModeloInvresponsables();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvajusteconcep
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvajusteconcep
        private static VistaModeloInvajusteconcep _vistaModeloInvajusteconcep;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvajusteconcep
        /// </summary>
        public static VistaModeloInvajusteconcep VistaModeloInvajusteconcepStatic
        {
            get
            {
                if (_vistaModeloInvajusteconcep == null)
                {
                    fcvCrearVistaModeloInvajusteconcep();
                }
                return _vistaModeloInvajusteconcep;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvajusteconcep
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvajusteconcep VistaModeloInvajusteconcep
        {
            get
            {
                return VistaModeloInvajusteconcepStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvajusteconcep
        /// </summary>
        public static void fcvLiberarVistaModeloInvajusteconcep()
        {
            if (_vistaModeloInvajusteconcep != null)
            {
                _vistaModeloInvajusteconcep.Cleanup();
                _vistaModeloInvajusteconcep = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvajusteconcep
        /// </summary>
        public static void fcvCrearVistaModeloInvajusteconcep()
        {
            if (_vistaModeloInvajusteconcep == null)
            {
                _vistaModeloInvajusteconcep = new VistaModeloInvajusteconcep();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloMovSuministro
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloMovSuministro
        private static VistaModeloMovSuministro _vistaModeloMovSuministro;
        /// <summary>
        ///Leer las Propiedades de VistaModeloMovSuministro
        /// </summary>
        public static VistaModeloMovSuministro VistaModeloMovSuministroStatic
        {
            get
            {
                if (_vistaModeloMovSuministro == null)
                {
                    fcvCrearVistaModeloMovSuministro();
                }
                return _vistaModeloMovSuministro;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloMovSuministro
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloMovSuministro VistaModeloMovSuministro
        {
            get
            {
                return VistaModeloMovSuministroStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloMovSuministro
        /// </summary>
        public static void fcvLiberarVistaModeloMovSuministro()
        {
            if (_vistaModeloMovSuministro != null)
            {
                _vistaModeloMovSuministro.Cleanup();
                _vistaModeloMovSuministro = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloMovSuministro
        /// </summary>
        public static void fcvCrearVistaModeloMovSuministro()
        {
            if (_vistaModeloMovSuministro == null)
            {
                _vistaModeloMovSuministro = new VistaModeloMovSuministro();
            }
        }
        #endregion       
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloAjustInven
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloAjustInven
        private static VistaModeloAjustInven _vistaModeloAjustInven;
        /// <summary>
        ///Leer las Propiedades de VistaModeloAjustInven
        /// </summary>
        public static VistaModeloAjustInven VistaModeloAjustInvenStatic
        {
            get
            {
                if (_vistaModeloAjustInven == null)
                {
                    fcvCrearVistaModeloAjustInven();
                }
                return _vistaModeloAjustInven;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloAjustInven
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloAjustInven VistaModeloAjustInven
        {
            get
            {
                return VistaModeloAjustInvenStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloAjustInven
        /// </summary>
        public static void fcvLiberarVistaModeloAjustInven()
        {
            if (_vistaModeloAjustInven != null)
            {
                _vistaModeloAjustInven.Cleanup();
                _vistaModeloAjustInven = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloAjustInven
        /// </summary>
        public static void fcvCrearVistaModeloAjustInven()
        {
            if (_vistaModeloAjustInven == null)
            {
                _vistaModeloAjustInven = new VistaModeloAjustInven();
            }
        }
        #endregion
        //-------------------------------------------------------
        // Codigo Localizador para: VistaModeloInvVistalmacen
        //-------------------------------------------------------
        #region  Localizador para: VistaModeloInvVistalmacen
        private static VistaModeloInvVistalmacen _vistaModeloInvVistalmacen;
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvVistalmacen
        /// </summary>
        public static VistaModeloInvVistalmacen VistaModeloInvVistalmacenStatic
        {
            get
            {
                if (_vistaModeloInvVistalmacen == null)
                {
                    fcvCrearVistaModeloInvVistalmacen();
                }
                return _vistaModeloInvVistalmacen;
            }
        }
        /// <summary>
        ///Leer las Propiedades de VistaModeloInvVistalmacen
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VistaModeloInvVistalmacen VistaModeloInvVistalmacen
        {
            get
            {
                return VistaModeloInvVistalmacenStatic;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para eliminar la propiedad VistaModeloInvVistalmacen
        /// </summary>
        public static void fcvLiberarVistaModeloInvVistalmacen()
        {
            if (_vistaModeloInvVistalmacen != null)
            {
                _vistaModeloInvVistalmacen.Cleanup();
                _vistaModeloInvVistalmacen = null;
            }
        }
        /// <summary>
        ///Proveer una ruta determinada para crear la propiedad VistaModeloInvVistalmacen
        /// </summary>
        public static void fcvCrearVistaModeloInvVistalmacen()
        {
            if (_vistaModeloInvVistalmacen == null)
            {
                _vistaModeloInvVistalmacen = new VistaModeloInvVistalmacen();
            }
        }
        #endregion

        public static void Cleanup()
        {
            fcvLiberarVistaModeloEntradaCompras();
            fcvLiberarVistaModeloInvMaestroalmacen();
            fcvLiberarVistaModeloInvmaestroarticulo();
            fcvLiberarVistaModeloInvcontenedores();
            fcvLiberarVistaModeloInvperiodomaest();
            fcvLiberarVistaModeloInvresponsables();
            fcvLiberarVistaModeloInvajusteconcep();
            fcvLiberarVistaModeloMovSuministro();
            fcvLiberarVistaModeloAjustInven();
            fcvLiberarVistaModeloInvVistalmacen();            
        }

    }
}

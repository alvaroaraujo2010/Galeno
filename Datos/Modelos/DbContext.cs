using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class DbContext
    {
        private static DbContext oDbApp;

        private DbContext()
        {
        }

        public static DbContext Instancia()
        {
            if (oDbApp == null)
            {
                oDbApp = new DbContext();
            }

            return oDbApp;
        }
        /// <summary>
        /// Linea de conexion para la base de datos
        /// </summary>
        public String gcrSqlLineaConexion = String.Empty;

        /* Lineas para la funcion 
        public DbAplicacion() : base("name=DbAplicacion", "DbAplicacion")
        {
            this.CommandTimeout = 0;
            DbContext oDbApp = DbContext.Instancia();
            ((EntityConnection)this.Connection).StoreConnection.ConnectionString =  oDbApp.gcrSqlLineaConexion;

            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
        */
    }
}

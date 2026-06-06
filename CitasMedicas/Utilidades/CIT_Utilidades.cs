using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas.Utilidades
{
    public class CITUtilidades
    {
        //----------------------------------------------------------------------
        // fcrImagenEstadoAsigCitas : Devuelve el nombre de la imagen  del fondo 
        // del Tile segun el estado de asignacion de la cita medica
        //----------------------------------------------------------------------
        #region fcrImagenEstadoAsigCitas : Devolver imagen fondo tiles
        /// <summary>
        /// fcrImagenEstadoAsigCitas : Devuelve el nombre de la imagen  del fondo 
        /// del Tile segun el estado de asignacion de la cita medica
        /// 1=Libre 2=Asignada 3=Confirmada o cumplida 4 = Atendida  
        /// 5=Cancelada  6=No disponible (algún motivo)
        /// </summary>
        public static String fcrImagenEstadoAsigCitas(String tcrEstadoCita)
        {
            var lcrImagen = String.Empty;
            switch (tcrEstadoCita)
            {
                case "1": //Libre
                    lcrImagen = "sys_tiles2_verdemarino.png";
                    break;

                case "2": // Asignada
                    lcrImagen = "sys_tiles2_naranja.png";
                    break;

                case "3": // Confirmada
                    lcrImagen = "sys_tiles2_rojofucsia.png";
                    break;

                case "4": // Atendida
                    lcrImagen = "sys_tiles2_verde.png";
                    break;

                case "5": // Cancelada
                    lcrImagen = "sys_tiles2_rojo.png";
                    break;

                case "6": // Inactiva o no disponible
                    lcrImagen = "sys_tiles2_gris.png";
                    break;
            }
            return lcrImagen;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Utilidades;


namespace ConsultaExterna.Utilidades
{
    public class CEXUtilidades
    {
        //----------------------------------------------------------------------
        // fcrImagenEstadoRegAtencion : Devuelve el nombre de la imagen  del fondo 
        // del Tile segun el estado del registro de atención
        //----------------------------------------------------------------------
        #region fcrImagenEstadoRegAtencion : Devolver imagen fondo tiles
        /// <summary>
        /// <para>fcrImagenEstadoRegAtencion : Devuelve el nombre de la imagen  del fondo</para>
        /// <para>del Tile segun el estado del registro de atencion para el profesional</para>
        /// <para>1=No antendido 2=Atendidio 3=Finalizado 5 = Anulado</para>
        /// </summary>
        public static String fcrImagenEstadoRegAtencion(String tcrEstadoRegistro)
        {
            var lcrImagen = String.Empty;
            switch (tcrEstadoRegistro)
            {
                case "1": //No atendido 
                    lcrImagen = "sys_tiles2_verdemarino.png";
                    break;

                case "2": // Atendido
                    lcrImagen = "sys_tiles2_naranja.png";
                    break;

                case "3": // Finalizado
                    lcrImagen = "sys_tiles2_verde.png";
                    break;

                case "5": // Anulado
                    lcrImagen = "sys_tiles2_rojo.png";
                    break;

            }
            return lcrImagen;
        }
        #endregion
    }
}

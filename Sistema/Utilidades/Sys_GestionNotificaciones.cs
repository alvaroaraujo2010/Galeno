using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SysNotificaciones
    {
        //-------------------------------------------------------
        // flgGenerarNotificaciones: Genera los registros de notificacion para perfiles y modulos
        //-------------------------------------------------------
        #region flgGenerarNotificaciones: Genera los registros de notificacion para perfiles y modulos
        /// <summary>
        /// Genera los registros de notificacion para perfiles y modulos en los que sea requerido
        /// </summary>
        public static bool flgGenerarNotificaciones(SysModeloAdminMensajes tobRegNotificacion)
        {
            var llgReturn = false;
            var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobRegNotificacion.Sys_sisfec_syam, tobRegNotificacion.Sys_sishor_syam);
            var lcrParentReferencia = "XX";

            tobRegNotificacion.Sys_llavis_syam = lnullaveIndice;
            tobRegNotificacion.Sys_parent_syam = lcrParentReferencia;

            if (tobRegNotificacion.Sys_tipmsj_syam != "3")
            {
                //  es un mensaje masivo, enviar a varios perfiles (buscar a quien se enviara)
                var tmpLista = SysModeloNotifiPorGrupo.flsListaSysadmNotiGrupoPerfilModulo(tobRegNotificacion.Sys_codtip_sytm, "1");
                int lnuContador = 0;
                var lcrIdRegistroGen = String.Empty;

                if (tmpLista != null)
                {
                    foreach (var lobReg in tmpLista)
                    {
                        llgReturn = true;
                        tobRegNotificacion.Sys_llavis_syam = lnullaveIndice + lnuContador;
                        tobRegNotificacion.Sys_parent_syam = lcrParentReferencia;
                        tobRegNotificacion.Sys_codmsg_symg = lobReg.Sys_codmsg_symg;
                        tobRegNotificacion.Sys_codper_perf = lobReg.Sys_codper_perf;

                        lcrIdRegistroGen = SysModeloAdminMensajes.flgAddRegistro(tobRegNotificacion);
                        lcrParentReferencia = lnuContador == 0 ? lcrIdRegistroGen : lcrParentReferencia;

                        lnuContador++;
                    }
                }
            }
            else
            {
                // Mensaje privado solo para un usuario en particular
                llgReturn = true;
                SysModeloAdminMensajes.flgAddRegistro(tobRegNotificacion);
            }

            return llgReturn;
        }
        #endregion
    }
}

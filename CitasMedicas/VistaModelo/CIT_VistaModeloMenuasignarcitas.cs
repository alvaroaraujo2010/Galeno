using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Datos.Modelos;
using System.Windows;
using Sistema.Utilidades;
using CitasMedicas.Utilidades;

namespace CitasMedicas.VistaModelo
{
    class clTilesTurno
    {
        // Array de tipo Diccionario para el manejo de las rutas e iconos de los módulos y componentes para los tiles.
        public Dictionary<string, string[]> gArDicRutaseIconos = new Dictionary<string, string[]>();
        //----------------------------------------------------------------------
        // fcArListaMenuTilesTurnos : Menu Cargar lista de Turnos por  profesional 
        //----------------------------------------------------------------------
        #region fcArListaMenuTilesTurnos : Menu Cargar lista de Turnos por  profesional
        /// <summary>
        /// Devuelve una estructura tipo Diccionario para cargar lista de turnos
        /// profesionales y el manejo de las rutas e iconos para los tiles. 
        /// </summary>
        public Dictionary<string, string[]> fcArListaMenuTilesTurnos(String tcrTipoFiltro, String tcrFiltro1, String tcrFiltro2, String tcrFiltro3, String tcrFiltro4)
        {
            switch (tcrTipoFiltro)
            {
                case "1": // Filtro por turno en particular 
                    fcvFiltro1(tcrFiltro1);
                    break;

                case "2": // Filtro por registros de citas en particular (no tiene en cuenta el turno)
                    fcvFiltro2(tcrFiltro1);
                    break;
            }
            return gArDicRutaseIconos;
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvFiltro1 : Codigo turno en particular 
        //----------------------------------------------------------------------
        #region fcvFiltro1 : profesional y turno en particular
        /// <summary>
        /// Codigo turno en particular 
        /// </summary>
        private void fcvFiltro1(String tcrCodigoTurno)
        {
            if (String.IsNullOrWhiteSpace(tcrCodigoTurno)){return;}

            gArDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                int lnuContadorTiles = 0;
                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                int lnuTotElemtos = Funciones.fnuContarElemListaString(",", tcrCodigoTurno);
                string[] larArray = tcrCodigoTurno.Split(',');
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if (lnuContadorTiles <= 200)
                    {
                        //-------------------------------------------------
                        // Generar la consulta
                        //-------------------------------------------------
                        #region Generar la consulta
                        lcrCodigoTurno = larArray[i].Trim().ToUpper();

                        var lobConsulta = (from tmp in db.Citmaesasigcita
                                           where tmp.cit_codtur_turn == lcrCodigoTurno
                                           orderby tmp.cit_idehin_mcit
                                           select new
                                           {
                                               Cit_codasi_mcit = tmp.cit_codasi_mcit,
                                               Cit_codtur_turn = tmp.cit_codtur_turn,
                                               Cit_ordvis_mcit = (int)tmp.cit_ordvis_mcit,
                                               Cit_ordcon_mcit = (int)tmp.cit_ordcon_mcit,
                                               Cit_codspr_spro = tmp.cit_codspr_spro,
                                               Sia_codesp_esme = tmp.sia_codesp_esme,
                                               Sia_idesec_usua = tmp.sia_idesec_usua,
                                               Sia_tipide_tide = tmp.sia_tipide_tide,
                                               Sia_nroide_usua = tmp.sia_nroide_usua,
                                               Adm_secadm_rgad = tmp.adm_secadm_rgad,
                                               Cit_feccit_mcit = (DateTime)tmp.cit_feccit_mcit,
                                               Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                               Cit_horini_mcit = (Decimal)tmp.cit_horini_mcit,
                                               Cit_horfni_mcit = (Decimal)tmp.cit_horfni_mcit,
                                               Cit_caucan_ccan = tmp.cit_caucan_ccan,
                                               Cit_estcit_easi = tmp.cit_estcit_easi,
                                               Sis_estpro_espr = tmp.sis_estpro_espr,
                                               Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == tmp.cit_codtur_turn).cit_destur_turn,
                                               Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                               Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == tmp.sia_codpfa_prof).sia_nompro_prof,
                                               Sia_desesp_esme = db.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                               Cit_descan_ccan = db.Citcausacancita.FirstOrDefault(rxp => rxp.cit_caucan_ccan == tmp.cit_caucan_ccan).cit_descan_ccan,
                                               Cit_descit_easi = db.Citestadoascita.FirstOrDefault(rxp => rxp.cit_estcit_easi == tmp.cit_estcit_easi).cit_descit_easi,
                                               Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                               Sia_nomusu_usua = db.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == tmp.sia_idesec_usua).sia_nomusu_usua,
                                           }).ToList();
                        #endregion
                        //-------------------------------------------------
                        // cargar en la lista
                        //-------------------------------------------------
                        #region cargar en la lista
                        foreach (var p in lobConsulta)
                        {
                            if (lnuContadorTiles <= 200)
                            {
                                var lcrOrdenVista       = p.Cit_ordvis_mcit.ToString().Trim();
                                var lcrOrdenllegada     = p.Cit_ordcon_mcit.ToString().Trim();
                                var lcrCit_horini_mcit  = Funciones.fcrConvierteHora(p.Cit_horini_mcit.ToString(), "24", lcrSeparadorDecimal, ":");
                                var lcrCit_horfni_mcit  = Funciones.fcrConvierteHora(p.Cit_horfni_mcit.ToString(), "24", lcrSeparadorDecimal, ":");
                                var lcrHoraCita         = lcrCit_horini_mcit + " a " + lcrCit_horfni_mcit;
                                var lcrCit_feccit_mcit  = p.Cit_feccit_mcit.ToShortDateString().Trim();
                                var lcrFoto             = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                                var lcrFondo            = CITUtilidades.fcrImagenEstadoAsigCitas(p.Cit_estcit_easi.Trim());  // sys_cit03.png
                                var lcrCapa             = "sys_panel_fondo2.png";  // sys_cit03.png
                                var lcrNomPaciente      = "USUARIO NO ASIGNADO";
                                var lcrServicio         = "SERVICIO NO ASIGNADO";
                                var lcrCodigoGrupo      = p.Cit_codtur_turn.Trim();
                                var lcrNombreGrupo      = p.Sia_nompro_prof.Trim() + " - " + p.Cit_destur_turn.Trim();

                                if (p.Sia_nomusu_usua != null) { lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim(); }
                                if (p.Cit_desspr_spro != null) { lcrServicio = p.Cit_desspr_spro.Trim(); }

                                gArDicRutaseIconos.Add(p.Cit_codasi_mcit.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Cit_codasi_mcit.Trim(),lcrHoraCita,p.Sia_desesp_esme.Trim(),
                                            lcrServicio,p.Cit_codasi_mcit.Trim()+" - "+p.Cit_descit_easi.Trim(),lcrNomPaciente,lcrOrdenVista,lcrOrdenllegada,
                                            lcrCit_feccit_mcit,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                                lnuIndice++;
                                lnuContadorTiles++;
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvFiltro2 : Filtro por un registro de cita en particular
        //----------------------------------------------------------------------
        #region fcvFiltro2 : Filtro por un registro de cita en particular
        /// <summary>
        /// Filtro por un registro de cita en particular
        /// </summary>
        private void fcvFiltro2(String tcrCodigoRegCita)
        {
            if (String.IsNullOrWhiteSpace(tcrCodigoRegCita)) { return; }

            gArDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                int lnuContadorTiles = 0;
                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                int lnuTotElemtos = Funciones.fnuContarElemListaString(",", tcrCodigoRegCita);
                string[] larArray = tcrCodigoRegCita.Split(',');
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if (lnuContadorTiles <= 200)
                    {
                        //-------------------------------------------------
                        // Generar la consulta
                        //-------------------------------------------------
                        #region Generar la consulta
                        lcrCodigoTurno = larArray[i].Trim().ToUpper();

                        var lobConsulta = (from tmp in db.Citmaesasigcita
                                           where tmp.cit_codasi_mcit == lcrCodigoTurno
                                           orderby tmp.cit_idehin_mcit
                                           select new
                                           {
                                               Cit_codasi_mcit = tmp.cit_codasi_mcit,
                                               Cit_codtur_turn = tmp.cit_codtur_turn,
                                               Cit_ordvis_mcit = (int)tmp.cit_ordvis_mcit,
                                               Cit_ordcon_mcit = (int)tmp.cit_ordcon_mcit,
                                               Cit_codspr_spro = tmp.cit_codspr_spro,
                                               Sia_codesp_esme = tmp.sia_codesp_esme,
                                               Sia_idesec_usua = tmp.sia_idesec_usua,
                                               Sia_tipide_tide = tmp.sia_tipide_tide,
                                               Sia_nroide_usua = tmp.sia_nroide_usua,
                                               Adm_secadm_rgad = tmp.adm_secadm_rgad,
                                               Cit_feccit_mcit = (DateTime)tmp.cit_feccit_mcit,
                                               Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                               Cit_horini_mcit = (Decimal)tmp.cit_horini_mcit,
                                               Cit_horfni_mcit = (Decimal)tmp.cit_horfni_mcit,
                                               Cit_caucan_ccan = tmp.cit_caucan_ccan,
                                               Cit_estcit_easi = tmp.cit_estcit_easi,
                                               Sis_estpro_espr = tmp.sis_estpro_espr,
                                               Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == tmp.cit_codtur_turn).cit_destur_turn,
                                               Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                               Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == tmp.sia_codpfa_prof).sia_nompro_prof,
                                               Sia_desesp_esme = db.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                               Cit_descan_ccan = db.Citcausacancita.FirstOrDefault(rxp => rxp.cit_caucan_ccan == tmp.cit_caucan_ccan).cit_descan_ccan,
                                               Cit_descit_easi = db.Citestadoascita.FirstOrDefault(rxp => rxp.cit_estcit_easi == tmp.cit_estcit_easi).cit_descit_easi,
                                               Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                               Sia_nomusu_usua = db.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == tmp.sia_idesec_usua).sia_nomusu_usua,
                                           }).ToList();
                        #endregion
                        //-------------------------------------------------
                        // cargar en la lista
                        //-------------------------------------------------
                        #region cargar en la lista
                        foreach (var p in lobConsulta)
                        {
                            if (lnuContadorTiles <= 200)
                            {
                                var lcrOrdenVista       = p.Cit_ordvis_mcit.ToString().Trim();
                                var lcrOrdenllegada     = p.Cit_ordcon_mcit.ToString().Trim();
                                var lcrCit_horini_mcit  = Funciones.fcrConvierteHora(p.Cit_horini_mcit.ToString(), "24", lcrSeparadorDecimal, ":");
                                var lcrCit_horfni_mcit  = Funciones.fcrConvierteHora(p.Cit_horfni_mcit.ToString(), "24", lcrSeparadorDecimal, ":");
                                var lcrHoraCita         = lcrCit_horini_mcit + " a " + lcrCit_horfni_mcit;
                                var lcrCit_feccit_mcit  = p.Cit_feccit_mcit.ToShortDateString().Trim();
                                var lcrFoto             = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                                var lcrFondo            = CITUtilidades.fcrImagenEstadoAsigCitas(p.Cit_estcit_easi.Trim());  // sys_cit03.png
                                var lcrCapa             = "sys_panel_fondo2.png";  // sys_cit03.png
                                var lcrNomPaciente      = "USUARIO NO ASIGNADO";
                                var lcrServicio         = "SERVICIO NO ASIGNADO";
                                var lcrCodigoGrupo      = p.Cit_codtur_turn.Trim();
                                var lcrNombreGrupo      = p.Sia_nompro_prof.Trim() + " - " + p.Cit_destur_turn.Trim();

                                if (p.Sia_nomusu_usua != null) { lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim(); }
                                if (p.Cit_desspr_spro != null) { lcrServicio = p.Cit_desspr_spro.Trim(); }

                                gArDicRutaseIconos.Add(p.Cit_codasi_mcit.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Cit_codasi_mcit.Trim(),lcrHoraCita,p.Sia_desesp_esme.Trim(),
                                            lcrServicio,p.Cit_codasi_mcit.Trim()+" - "+p.Cit_descit_easi.Trim(),lcrNomPaciente,lcrOrdenVista,lcrOrdenllegada,
                                            lcrCit_feccit_mcit,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                                lnuIndice++;
                                lnuContadorTiles++;
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        //  ACTUALIZAR Diccionario de Tiles02
        //------------------------------------------------------------
        #region fcvActualizDiccTiles02()
        public Dictionary<string, string[]> fcvActualizDiccTiles02(ref Dictionary<string, string[]> tarDiccionarioVista,
                                                ref Dictionary<string, string[]> tarDiccActualizTiles)
        {
            String lcrllave=String.Empty;
            String lcrPrueba = String.Empty;
            gArDicRutaseIconos = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccionarioVista)
            {
                var lcrCodigo = lobReDicc.Key.Trim(); // el codigo del item en el tiles
                lcrllave = tarDiccActualizTiles.FirstOrDefault(k => k.Key.Equals(lcrCodigo)).Key;
                if (!String.IsNullOrWhiteSpace(lcrllave))
                {
                    lcrPrueba = lcrllave;
                    var lobRegAux = tarDiccActualizTiles.FirstOrDefault(k => k.Key.Trim().Equals(lcrCodigo));
                    //- Actualizar el diccionario
                    /*
                    lobReDicc.Value[0] = lobRegAux.Value[0].Trim(); // Index
                    lobReDicc.Value[1] = lobRegAux.Value[1].Trim(); // Codigo del Item
                    lobReDicc.Value[16] = lobRegAux.Value[16].Trim(); // Codigo grupo
                    lobReDicc.Value[17] = lobRegAux.Value[17].Trim(); // Nombre Titulo grupo
                    */
                    lobReDicc.Value[2] = lobRegAux.Value[2].Trim();
                    lobReDicc.Value[3] = lobRegAux.Value[3].Trim();
                    lobReDicc.Value[4] = lobRegAux.Value[4].Trim();
                    lobReDicc.Value[5] = lobRegAux.Value[5].Trim();
                    lobReDicc.Value[6] = lobRegAux.Value[6].Trim();
                    lobReDicc.Value[7] = lobRegAux.Value[7].Trim();
                    lobReDicc.Value[8] = lobRegAux.Value[8].Trim();
                    lobReDicc.Value[9] = lobRegAux.Value[9].Trim();
                    lobReDicc.Value[10] = lobRegAux.Value[10].Trim();
                    lobReDicc.Value[11] = lobRegAux.Value[11].Trim();
                    lobReDicc.Value[12] = lobRegAux.Value[12].Trim();
                    lobReDicc.Value[13] = lobRegAux.Value[13].Trim();
                    lobReDicc.Value[14] = lobRegAux.Value[14].Trim();
                    lobReDicc.Value[15] = lobRegAux.Value[15].Trim();
                }
                gArDicRutaseIconos.Add(lobReDicc.Key.Trim(), new String[] {lobReDicc.Value[0],
                                            lobReDicc.Value[1],lobReDicc.Value[2],lobReDicc.Value[3],
                                            lobReDicc.Value[4],lobReDicc.Value[5],lobReDicc.Value[6],
                                            lobReDicc.Value[7],lobReDicc.Value[8],lobReDicc.Value[9],
                                            lobReDicc.Value[10],lobReDicc.Value[11],lobReDicc.Value[12],
                                            lobReDicc.Value[13],lobReDicc.Value[14],lobReDicc.Value[15],
                                            lobReDicc.Value[16],lobReDicc.Value[17]});

            }
            return gArDicRutaseIconos;
        }
        #endregion
    }
}

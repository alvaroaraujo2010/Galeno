using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing.Imaging;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Reportes.Utilidades
{
    /// <summary>
    /// <para>Imprimir reportes modulo de Odontologia</para>
    /// </summary>
    public class ODNImprimir
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        /// <summary>
        /// "REG" = Solo un registro particular con sus detalles "ADM" = Todos los registros de la admision
        /// </summary>
        public String gcrFiltroReporte      = String.Empty;
        public String gcrCodigoAdmision     = String.Empty;
        public String gcrCodigoRegistro     = String.Empty; // Puede ser el codigo del tratamiento odontologico
        public String gcrTipoRegistro       = "ODTR";       // "ODTR" = Tratamiento odontologico
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia          = true;         // true = mostrar vista previa / fase = no mostrar vista previa
        public Window gobOwner;
        public DataSet01 gobDataSet = new DataSet01();
        public byte[] gobArrayImgDiag = null;
        public byte[] gobArrayImgPlan = null;

        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reporte
        /// <summary>
        /// Mostrar la vista del reoprte
        /// </summary>
        public void fcvEjecutar()
        {
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            fcvCargarEncabezados();
            // Tratamiento odontologico
            if (gcrTipoRegistro == "ODTR")
            {
                #region Tratamiento odontologico
                if (flgCargarTratamientoOdontologico())
                {
                    //- Reporte 1
                    var lobRepPMInterno = new ODN_HistoriaTratamientos();
                    lobRepPMInterno.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepPMInterno;
                    lobVisorPm.Owner = gobOwner;
                    lobVisorPm.Activate();
                    lobDlgAdd.Close();
                    lobVisorPm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay datos");
                }
                #endregion
            }
            else if (gcrTipoRegistro == "XXX")
            {
            }
            else // otros casos
            {
                // otros casos
            }
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
        }
        #endregion
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void fcvCargarEncabezados()
        {
            // Encabezados 
            var lobEncab = REPUtilidades.fobDataSet01Encabezado(ref gobDataSet);
            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);

            // Datos Admision
            var lobAdm = REPUtilidades.fobDataSet01Admision(ref gobDataSet, gcrCodigoAdmision);
            gobDataSet.AdmAdmision.AddAdmAdmisionRow(lobAdm);

        }
        #endregion
        //-------------------------------------------------
        // flgCargarTratamientoOdontologico: Cargar los datos del tratamiento odontologico
        //-------------------------------------------------
        #region flgCargarTratamientoOdontologico: Cargar los datos del tratamiento odontologico
        /// <summary>
        /// Cargar los datos del tratamiento odontologico
        /// </summary>
        private bool flgCargarTratamientoOdontologico()
        {
            var llgReturn = true;
            #region Cargar registro
            // Cargar odontogramas en registro 
            var lobReg = ODNValidarCodigo.fobRegBuscarOdneventosmaest(gcrCodigoRegistro);
            DataSet01.OdnodontogramasDataTable lobDetalles = gobDataSet.Odnodontogramas;
            DataSet01.OdnodontogramasRow lobRegistro = lobDetalles.NewOdnodontogramasRow();
            // llenar el registro
            lobRegistro.TituloImagen1 = "DIAGNOSTICO";
            lobRegistro.TituloImagen2 = "TRATAMIENTO";
            lobRegistro.Imagen1 = gobArrayImgDiag;
            lobRegistro.Imagen2 = gobArrayImgPlan;
            lobRegistro.Observacion = lobReg.odn_obsape_odev;
            gobDataSet.Odnodontogramas.AddOdnodontogramasRow(lobRegistro);
            #endregion

            llgReturn = flgODTRCargarDetallesTratamientos();
            return llgReturn;
        }
        #endregion
        #region fcrEstadoActividadTratamiento: Estado ejecucion actividad tratamiento odontologico
        /// <summary>
        /// Estado ejecucion actividad tratamiento odontologico
        /// </summary>
        public String fcrEstadoActividadTratamiento(String tcrTipoRegistro, String tcrEstado, String tcrPreExistente)
        {
            String lcrEstado = String.Empty;
            switch (tcrEstado)
            {
                case "1":
                    lcrEstado = "PENDIENTE";
                    break;

                case "2":
                    lcrEstado = "EN PROCESO";
                    break;

                case "3":
                    lcrEstado = tcrTipoRegistro == "1" ? "CONFIRMADO" : "FINALIZADO";
                    break;
            }
            lcrEstado = tcrPreExistente == "1" ? "PRE-EXISTENTE" : lcrEstado;

            return lcrEstado;
        }
        #endregion
        #region fcrTipoRegistroTratamiento: Tipo registro tratamiento
        /// <summary>
        /// Tipo registro tratamiento
        /// </summary>
        public String fcrTipoRegistroTratamiento(String tcrTipoRegistro)
        {
            String lcrTipoRegistro = String.Empty;
            switch (tcrTipoRegistro)
            {
                case "1":
                    lcrTipoRegistro = "DIAGNOSTICO";
                    break;

                case "2":
                    lcrTipoRegistro = "TRATAMIENTO";
                    break;

                case "3":
                    lcrTipoRegistro = "EVOLUCIÓN";
                    break;
            }

            return lcrTipoRegistro;
        }
        #endregion
        //-------------------------------------------------
        // ODTR: flgCargarTempDatosOdnTratamientos: Cargar datos tratamiento
        //-------------------------------------------------
        #region flgODTRCargarTempDatosOdnTratamientos: Cargar datos tratamiento
        /// <summary>
        /// <para>datos tratamientos odontologicos</para>
        /// </summary>
        private bool flgODTRCargarDetallesTratamientos()
        {
            var llgReturn = false;

            // Definir temporales para los datos 
            List<ModeloOdnDeActivTratamiento> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.OdneventosactdeDataTable lobDetalles = gobDataSet.Odneventosactde;
            //----------------------------------------------------------
            // Detalles Eventos para cada Diente (en actividades cada evento)
            //----------------------------------------------------------
            #region Detalles cada registro actividad en cada evento
            DataSet01.OdneventosactdeRow lobRegistro = lobDetalles.NewOdneventosactdeRow();
            lobTempDetalles = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeDetallesTodos(gcrCodigoRegistro);
            var lcrOdn_nroreg_odac = "XX";
            var lcrOdn_observ_odac = String.Empty;

            llgReturn = false;
            foreach (var lobReg in lobTempDetalles)
            {
                #region Registros
                llgReturn = true;
                lobRegistro = lobDetalles.NewOdneventosactdeRow();

                // Para consultar los datos de la evolucion
                if (lobReg.Odn_nroreg_odac != lcrOdn_nroreg_odac)
                {
                    var tmp = ODNValidarCodigo.fobRegBuscarOdneventosactms(lobReg.Odn_nroreg_odac);
                    if (tmp != null)
                    {
                        lcrOdn_observ_odac = tmp.odn_observ_odac;
                    }
                }
                lcrOdn_nroreg_odac = lobReg.Odn_nroreg_odac;

                lobRegistro.Odn_nroreg_odde = lobReg.Odn_nroreg_odde;
                lobRegistro.Odn_nroreg_odac = lobReg.Odn_nroreg_odac;
                lobRegistro.Odn_nroreg_odev = lobReg.Odn_nroreg_odev;
                lobRegistro.GrupoFechaEvento = lobReg.Odn_fecact_odac;
                lobRegistro.Odn_fecact_odac = Funciones.fcrConvertFecha(lobReg.Odn_fecact_odac);
                lobRegistro.Odn_tipreg_odac = lobReg.Odn_tipreg_odac;
                lobRegistro.Odn_desreg_odac = fcrTipoRegistroTratamiento(lobReg.Odn_tipreg_odac) + " - " + lobRegistro.Odn_fecact_odac;
                lobRegistro.Odn_auxreg_odde = lobReg.Odn_auxreg_odde;
                lobRegistro.Odn_coddia_oddx = lobReg.Odn_coddia_oddx;
                lobRegistro.Sia_coddia_tdia = lobReg.Sia_coddia_tdia;
                lobRegistro.Odn_codser_odsi = lobReg.Odn_codser_odsi;
                lobRegistro.Fcm_idesec_sips = lobReg.Fcm_idesec_sips;
                lobRegistro.Fcm_idesec_mant = lobReg.Fcm_idesec_mant;
                lobRegistro.Fcm_codser_mant = lobReg.Odn_tipreg_odac =="1"? lobReg.Odn_coddia_oddx : lobReg.Fcm_codser_mant;
                lobRegistro.Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
                lobRegistro.Odn_desreg_odde = lobReg.Odn_desana_odan + " - " + lobReg.Odn_desreg_odde;
                lobRegistro.Odn_totuni_odde = (int)lobReg.Odn_totuni_odde;
                lobRegistro.Odn_coddie_oddi = lobReg.Odn_coddie_oddi;
                lobRegistro.Odn_codana_odan = lobReg.Odn_codana_odan;
                lobRegistro.Odn_carmar_odde = lobReg.Odn_carmar_odde;
                lobRegistro.Odn_fecini_odde = Funciones.fcrConvertFecha(lobReg.Odn_fecini_odde);
                lobRegistro.Odn_fecfin_odde = Funciones.fcrConvertFecha(lobReg.Odn_fecfin_odde);
                lobRegistro.Odn_finpro_odde = lobReg.Odn_finpro_odde;
                lobRegistro.Odn_prexis_odde = lobReg.Odn_prexis_odde;
                lobRegistro.Odn_estact_odac = fcrEstadoActividadTratamiento(lobReg.Odn_tipreg_odac,lobReg.Odn_estact_odac, lobReg.Odn_prexis_odde);
                lobRegistro.Odn_codimg_odim = lobReg.Odn_codimg_odim;
                lobRegistro.Odn_imagen_odde = lobReg.Odn_imagen_odde;
                lobRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistro.Odn_desana_odan = lobReg.Odn_desana_odan;
                lobRegistro.Sia_nompro_prof = "PROFESIONAL: " + lobReg.Sia_nompro_prof;
                lobRegistro.Odn_desdie_oddi = lobReg.Odn_coddie_oddi == "NA" ? "NA - " + lobReg.Odn_desdie_oddi : "DIENTE " + 
                                              lobReg.Odn_coddie_oddi + " - " + lobReg.Odn_desdie_oddi;

                // para mostrar el texto de la evolucin
                lobRegistro.Odn_observ_odac = lcrOdn_observ_odac;

                // Add en temporal
                gobDataSet.Odneventosactde.AddOdneventosactdeRow(lobRegistro);
                #endregion
            }
            #endregion
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // XXX: flgCargarTempDatosOdnTratamientos: Cargar datos tratamiento
        //-------------------------------------------------
        #region flgCargarTempDatosOdnTratamientos: Cargar datos tratamiento
        /// <summary>
        /// <para>datos tratamientos odontologicos</para>
        /// </summary>
        private bool flgCargarTempDatosOdnTratamientos(String tcrTitulo)
        {
            var llgReturn = false;

            // Definir temporales para los datos 
            List<ModeloOdnMsActivTratamiento> lobTempMaestro = null;
            List<ModeloOdnDeActivTratamiento> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.OdneventosactmsDataTable lobMaestro = gobDataSet.Odneventosactms;
            DataSet01.OdneventosactdeDataTable lobDetalles = gobDataSet.Odneventosactde;
            //----------------------------------------------------------
            // Maestro Eventos 
            //----------------------------------------------------------
            #region Maestro Eventos
            DataSet01.OdneventosactmsRow lobRegistroMa = lobMaestro.NewOdneventosactmsRow();
            lobTempMaestro = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("R1", gcrCodigoRegistro);

            foreach (var lobReg in lobTempMaestro)
            {
                #region Registros 
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewOdneventosactmsRow();
                /*
                lobRegistroMa.Hcl_titulo_reporte = tcrTitulo;
                lobRegistroMa.Hcl_nroreg_hcms = lobReg.Hcl_nroreg_hcms;
                lobRegistroMa.Hcl_secreg_hcms = lobReg.Hcl_secreg_hcms;
                lobRegistroMa.Hcl_nroreg_hcev = lobReg.Hcl_nroreg_hcev;
                lobRegistroMa.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                lobRegistroMa.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                lobRegistroMa.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                lobRegistroMa.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                lobRegistroMa.Hcl_tipreg_hctr = lobReg.Hcl_tipreg_hctr;
                lobRegistroMa.Sia_codare_aser = lobReg.Sia_codare_aser;
                lobRegistroMa.Hcl_gesfec_hcms = Funciones.fcrConvertFecha(lobReg.Hcl_gesfec_hcms);
                lobRegistroMa.Hcl_geshor_hcms = lobReg.Hcl_geshor_hcms;
                lobRegistroMa.Hcl_horges_hcms = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                lobRegistroMa.Hcl_tiptur_hctu = lobReg.Hcl_tiptur_hctu;
                lobRegistroMa.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMa.Hcl_desreg_hcev = lobReg.Hcl_desreg_hcev;
                lobRegistroMa.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                lobRegistroMa.Sia_deside_tide = lobReg.Sia_deside_tide;
                lobRegistroMa.Hcl_desreg_hctr = lobReg.Hcl_desreg_hctr;
                lobRegistroMa.Sia_desare_aser = lobReg.Sia_desare_aser;
                lobRegistroMa.Hcl_destur_hctu = "NA";
                lobRegistroMa.Sia_nompro_prof = lobReg.Sia_nompro_prof;
                lobRegistroMa.Sis_despro_espr = lobReg.Sis_despro_espr;
                */
                // Add en temporal
                gobDataSet.Odneventosactms.AddOdneventosactmsRow(lobRegistroMa);
                #endregion
            }
            #endregion
            //----------------------------------------------------------
            // Detalles Eventos (actividades cada evento)
            //----------------------------------------------------------
            #region Detalles plan de manejo interno / formula medica
            DataSet01.OdneventosactdeRow lobRegistro = lobDetalles.NewOdneventosactdeRow();
            lobTempDetalles = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeDxPlanTra(gcrCodigoRegistro);

            llgReturn = false;
            foreach (var lobReg in lobTempDetalles)
            {
                #region Registros
                llgReturn = true;
                lobRegistro = lobDetalles.NewOdneventosactdeRow();
                /*
                lobRegistro.Hcl_nroreg_hcor = lobReg.Hcl_nroreg_hcor;
                lobRegistro.Hcl_nroreg_hcms = lobReg.Hcl_nroreg_hcms;
                lobRegistro.Hcl_secreg_hcor = lobReg.Hcl_secreg_hcor;
                lobRegistro.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                lobRegistro.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                lobRegistro.Hcl_tipreg_hcor = lobReg.Hcl_tipreg_hcor;
                lobRegistro.Fcm_secreg_dfac = lobReg.Fcm_secreg_dfac;
                lobRegistro.Fcm_idesec_sips = lobReg.Fcm_idesec_sips;
                lobRegistro.Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
                if (gcrTipoRegistro == "SERV" || gcrTipoRegistro == "FMED")
                {
                    lobRegistro.Fcm_desser_sips = lobReg.Fcm_codser_sips + " - " + lobReg.Fcm_desser_sips;
                }
                else
                {
                    lobRegistro.Fcm_desser_sips = lobReg.Fcm_desser_sips;
                }
                lobRegistro.Fcm_codser_sips = lobReg.Fcm_codser_sips;
                lobRegistro.Hcl_totuni_hcor = lobReg.Hcl_totuni_hcor;
                lobRegistro.Inv_secart_mart = lobReg.Inv_secart_mart;
                lobRegistro.Hcl_aplmed_hcor = fcrViaAdmMedicamentos(lobReg.Hcl_aplmed_hcor); // via adminstracion
                lobRegistro.Hcl_termed_hcor = lobReg.Hcl_dester_hcor;
                lobRegistro.Hcl_nrodia_hcor = lobReg.Hcl_nrodia_hcor;
                lobRegistro.Hcl_gesfec_hcor = Funciones.fcrConvertFecha(lobReg.Hcl_gesfec_hcor);
                lobRegistro.Hcl_geshor_hcor = (Decimal)lobReg.Hcl_geshor_hcor;
                lobRegistro.Hcl_horges_hcor = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcor.ToString(), "24", gcrSeparadorDecimal, ":");
                lobRegistro.Hcl_tiptur_hctu = lobReg.Hcl_tiptur_hctu;
                lobRegistro.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                lobRegistro.Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                lobRegistro.Sia_codare_aser = lobReg.Sia_codare_aser;
                lobRegistro.Hcl_sisfec_hcor = (DateTime)lobReg.Hcl_sisfec_hcor;
                lobRegistro.Hcl_sishor_hcor = (Decimal)lobReg.Hcl_sishor_hcor;
                lobRegistro.Hcl_notreg_hcor = lobReg.Hcl_notreg_hcor;
                lobRegistro.Hcl_tipser_hcor = lobReg.Hcl_tipser_hcor;
                lobRegistro.Hcl_envfac_hcor = lobReg.Hcl_envfac_hcor;
                lobRegistro.Hcl_envalm_hcor = lobReg.Hcl_envalm_hcor;
                lobRegistro.Hcl_confac_hcor = lobReg.Hcl_confac_hcor;
                lobRegistro.Hcl_conalm_hcor = lobReg.Hcl_conalm_hcor;
                lobRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                */
                // Add en temporal
                gobDataSet.Odneventosactde.AddOdneventosactdeRow(lobRegistro);
                #endregion
            }
            #endregion
            return llgReturn;
        }
        #endregion
    }
}

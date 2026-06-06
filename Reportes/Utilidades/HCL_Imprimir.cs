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
using System.Drawing.Printing;
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
    /// <para>Imprimir registros para formatos modulo Historias clinicas</para>
    /// </summary>
    public class HCLImprimir
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
        public String gcrCodigoRegistro     = String.Empty; // Codigo Hcl_nroreg_hcms
        public String gcrTipoRegistro       = "SERV";       // "SERV" = Plan manejo interno "BLIQ" = Balance de liquido ...
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia          = true;              // true = mostrar vista previa / fase = no mostrar vista previa
        public int gnuNumeroCopias          = 1; // Por defecto una sola copia
        public Window gobOwner;
        public DataSet01 gobDataSet = new DataSet01();
        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reoprte
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
            // Plan de manejo interno / Formula medica
            if (gcrTipoRegistro == "SERV" || gcrTipoRegistro == "FMED")
            {
                #region Plan de manejo interno / Formula medica
                if (flgCargarTempDatosPlanManejo())
                {
                    VisorReportes lobVisorPm = new VisorReportes();

                    if (gcrTipoRegistro == "SERV")
                    {
                        // Plan de manejo interno
                        HCL_PlanManejoInterno lobRepPMInterno = new HCL_PlanManejoInterno();
                        lobRepPMInterno.SetDataSource(gobDataSet);
                        lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepPMInterno;
                    }
                    else
                    {
                        //- Formula medica
                        HCL_FormulaMedica lobRepPMInterno = new HCL_FormulaMedica();
                        lobRepPMInterno.SetDataSource(gobDataSet);
                        lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepPMInterno;
                    }

                    // Mostrar la vista en pantalla
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
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
            else if (gcrTipoRegistro == "HCON")
            {
                #region Hoja de consumo
                if (flgCargarTempDatosHojaConsumo())
                {
                    //- Reporte 1
                    HCL_HojaDeConsumo lobRepPMInterno = new HCL_HojaDeConsumo();
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
            else if (gcrTipoRegistro == "EVOL" || gcrTipoRegistro == "NENF")
            {
                #region Evoluciones medicas y Notas de enfermeria
                if (flgCargarTempDatosEvoluciones())
                {
                    //- Reporte 1
                    HCL_NotasMedicas lobRepPMInterno = new HCL_NotasMedicas();
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
                    MessageBox.Show("No hay Evoluciones");
                }
                #endregion
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
        // flgCargarTempDatosPlanManejo: Plan de manejo interno / Formula medica
        //-------------------------------------------------
        #region flgCargarTempDatosPlanManejo Plan de manejo interno / Formula medica
        /// <summary>
        /// Imprimir formula medica / Plan Manejo Interno
        /// </summary>
        private bool flgCargarTempDatosPlanManejo()
        {
            var llgReturn = false;
            var lcrTitulo = gcrTipoRegistro == "SERV" ? "PLAN DE MANEJO INTERNO" : "FORMULA MEDICA";
            llgReturn = flgCargarTempDatosHclOrdenServicios(lcrTitulo);
            return llgReturn;
        }
        #endregion
        #region fcrViaAdmMedicamentos Via administraccion medicamentos
        /// <summary>
        /// Via administraccion medicamentos = "1,2,3,4,5" = Via Oral,Intramuscular,Intravenosa,Topica,Otras
        /// </summary>
        public String fcrViaAdmMedicamentos(String tcrVia)
        {
            String lcrViaAdm = String.Empty;
            switch (tcrVia)
            {
                case "1":
                    lcrViaAdm = "Via Oral";
                    break;

                case "2":
                    lcrViaAdm = "Intramuscular";
                    break;

                case "3":
                    lcrViaAdm = "Intravenosa";
                    break;

                case "4":
                    lcrViaAdm = "Topica";
                    break;

                case "5":
                    lcrViaAdm = "Otras";
                    break;
            }
            return lcrViaAdm;
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosHojaConsumo: Plan de manejo interno / Formula medica
        //-------------------------------------------------
        #region flgCargarTempDatosHojaConsumo: Cargar datos Hoja de consumo
        /// <summary>
        /// Cargar datos Hoja de consumo
        /// </summary>
        private bool flgCargarTempDatosHojaConsumo()
        {
            var llgReturn = false;
            var lcrTitulo = "HOJA DE CONSUMO MEDICAMENTOS Y SERVICIOS";
            llgReturn = flgCargarTempDatosHclOrdenServicios(lcrTitulo);
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosEvoluciones: Evoluciones medicas y Notas de enfermeria
        //-------------------------------------------------
        #region flgCargarTempDatosEvoluciones: Evoluciones medicas y Notas de enfermeria
        /// <summary>
        /// Evoluciones medicas y Notas de enfermeria
        /// </summary>
        private bool flgCargarTempDatosEvoluciones()
        {
            var llgReturn = false;
            var lcrTitulo = gcrTipoRegistro == "EVOL" ? "EVOLUCIONES MEDICAS" : "NOTAS DE ENFERMERIA";
            llgReturn = flgCargarTempDatosHclEvoluciones(lcrTitulo);
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosHclOrdenServicios Cargar datos 
        //-------------------------------------------------
        #region flgCargarTempDatosHclOrdenServicios: Registro maestro  para ordenes de servicios y o medicamen, solicitud de examenes
        /// <summary>
        /// <para>Registro maestro  para ordenes de servicios y o medicamen, solicitud de examenes</para>
        /// <para>Cargar datos desde Tabla HCLREGORDESERMS: MEDI= Medicamentos SERV = Servicios EVOL= Evoluciones </para>
        /// <para>NENF = Notas de enfermeria  y otros SVIT,INCO,DIAG,ALIQ,ELIQ…</para>
        /// </summary>
        private bool flgCargarTempDatosHclOrdenServicios(String tcrTitulo)
        {
            var llgReturn = false;

            // Definir temporales para los datos 
            List<ModeloHclregordeserms> lobTempMaestro = null;
            List<ModeloHclregordeserde> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.HclOrdenServiciosMaDataTable lobMaestro = gobDataSet.HclOrdenServiciosMa;
            DataSet01.HclOrdenServiciosDeDataTable lobDetalles = gobDataSet.HclOrdenServiciosDe;
            //----------------------------------------------------------
            // Maestro Hoja de consumo
            //----------------------------------------------------------
            #region Maestro servicios / formula
            DataSet01.HclOrdenServiciosMaRow lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();
            if (gcrFiltroReporte == "REG")
            {
                lobTempMaestro = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", gcrCodigoRegistro, "");
            }
            else // ADM - Todos segun gcrTipoRegistro
            {
                lobTempMaestro = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoRegistro, gcrCodigoAdmision, "");
            }

            var i = 0;
            for (i = 1; i <= gnuNumeroCopias; i++)
            {
                foreach (var lobReg in lobTempMaestro)
                {
                    llgReturn = true;
                    lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();

                    lobRegistroMa.Hcl_num_copia = i;

                    lobRegistroMa.Hcl_titulo_reporte = tcrTitulo;
                    lobRegistroMa.Hcl_nroreg_hcms = lobReg.Hcl_nroreg_hcms;
                    lobRegistroMa.Hcl_secreg_hcms = (int)lobReg.Hcl_secreg_hcms;
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
                    // Add en temporal
                    gobDataSet.HclOrdenServiciosMa.AddHclOrdenServiciosMaRow(lobRegistroMa);
                }
            }
            #endregion
            //----------------------------------------------------------
            // Detalles registros
            //----------------------------------------------------------
            #region Detalles plan de manejo interno / formula medica
            DataSet01.HclOrdenServiciosDeRow lobRegistro = lobDetalles.NewHclOrdenServiciosDeRow();
            if (gcrFiltroReporte == "REG")
            {
                lobTempDetalles = ModeloHclregordeserde.flsListaHclregordeserde("R1", gcrCodigoRegistro);
            }
            else
            {
                lobTempDetalles = ModeloHclregordeserde.flsListaHclregordeserdeEx(gcrTipoRegistro, gcrCodigoAdmision);
            }
            llgReturn = false;

            //for (i = 1; i < gnuNumeroCopias; i++)
            //{
                foreach (var lobReg in lobTempDetalles)
                {
                    llgReturn = true;
                    lobRegistro = lobDetalles.NewHclOrdenServiciosDeRow();

                    lobRegistro.Hcl_num_copia = i;

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
                        lobRegistro.Fcm_desser_sips = String.Empty;

                        if (lobReg.Hcl_tserax_hcor != null)
                        {
                            if (lobReg.Hcl_tserax_hcor == "1") // Medicamento desde vademecum
                            {
                                var tmp = FARValidarCodigo.fobRegBuscarFarexpedmedicmdCUM(lobReg.Fcm_coddig_mant);
                                if (tmp != null)
                                {
                                    lobRegistro.Fcm_desser_sips = tmp.far_precom_famd;
                                }
                            }
                        }
                        if (String.IsNullOrWhiteSpace(lobRegistro.Fcm_desser_sips))
                        {
                            lobRegistro.Fcm_desser_sips = lobReg.Fcm_codser_sips + " - " + lobReg.Fcm_desser_sips;
                        }
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
                    // Add en temporal
                    gobDataSet.HclOrdenServiciosDe.AddHclOrdenServiciosDeRow(lobRegistro);
                }
            //}
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgCargarTempDatosHclEvoluciones: Registro maestro  Evoluciones y notas medicas
        /// <summary>
        /// <para>Registro maestro  Evoluciones y notas medicas</para>
        /// <para>EVOL = Evoluciones Medicas y NENF = Notas de enfermeria</para>
        /// </summary>
        private bool flgCargarTempDatosHclEvoluciones(String tcrTitulo)
        {
            var llgReturn = false;

            // Definir temporales para los datos 
            List<ModeloHclregordeserms> lobTempMaestro = null;
            List<ModeloHclregnotasmedi> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.HclOrdenServiciosMaDataTable lobMaestro = gobDataSet.HclOrdenServiciosMa;
            DataSet01.HclOrdenServiciosDeDataTable lobDetalles = gobDataSet.HclOrdenServiciosDe;
            //----------------------------------------------------------
            // Maestro Hoja de consumo
            //----------------------------------------------------------
            #region Maestro servicios / formula
            DataSet01.HclOrdenServiciosMaRow lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();
            if (gcrFiltroReporte == "REG")
            {
                lobTempMaestro = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", gcrCodigoRegistro, "");
            }
            else // ADM - Todos segun gcrTipoRegistro
            {
                lobTempMaestro = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoRegistro, gcrCodigoAdmision, "");
            }

            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();

                lobRegistroMa.Hcl_titulo_reporte = tcrTitulo;
                lobRegistroMa.Hcl_nroreg_hcms = lobReg.Hcl_nroreg_hcms;
                lobRegistroMa.Hcl_secreg_hcms = (int)lobReg.Hcl_secreg_hcms;
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
                // Add en temporal
                gobDataSet.HclOrdenServiciosMa.AddHclOrdenServiciosMaRow(lobRegistroMa);
            }
            #endregion
            //----------------------------------------------------------
            // Detalles registros
            //----------------------------------------------------------
            #region Detalles plan de manejo interno / formula medica
            DataSet01.HclOrdenServiciosDeRow lobRegistro = lobDetalles.NewHclOrdenServiciosDeRow();
            if (gcrFiltroReporte == "REG")
            {
                lobTempDetalles = ModeloHclregnotasmedi.flsListaHclregnotasmedi("R1", gcrCodigoRegistro);
            }
            else
            {
                lobTempDetalles = ModeloHclregnotasmedi.flsListaHclregnotasmediEx(gcrTipoRegistro, gcrCodigoAdmision);
            }
            llgReturn = false;
            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistro = lobDetalles.NewHclOrdenServiciosDeRow();

                lobRegistro.Hcl_nroreg_hcor = lobReg.Hcl_nroreg_hcnm;
                lobRegistro.Hcl_nroreg_hcms = lobReg.Hcl_nroreg_hcms;
                lobRegistro.Hcl_secreg_hcor = lobReg.Hcl_secreg_hcnm;
                lobRegistro.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                lobRegistro.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                lobRegistro.Hcl_tipreg_hcor = lobReg.Hcl_tipreg_hcnm=="1"? "EVOLUCION MEDICA": "NOTA DE ENFERMERIA";
                lobRegistro.Hcl_gesfec_hcor = Funciones.fcrConvertFecha(lobReg.Hcl_gesfec_hcnm);
                lobRegistro.Hcl_geshor_hcor = (Decimal)lobReg.Hcl_geshor_hcnm;
                lobRegistro.Hcl_horges_hcor = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcnm.ToString(), "24", gcrSeparadorDecimal, ":");
                lobRegistro.Hcl_notreg_hcor = lobRegistro.Hcl_gesfec_hcor + "\t" + lobRegistro.Hcl_horges_hcor + " - " + lobReg.Hcl_notreg_hcnm;
                lobRegistro.Hcl_tiptur_hctu = lobReg.Hcl_tiptur_hctu;
                lobRegistro.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                lobRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                // Add en temporal
                gobDataSet.HclOrdenServiciosDe.AddHclOrdenServiciosDeRow(lobRegistro);
            }
            #endregion
            return llgReturn;
        }
        #endregion
    }
}

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
    /// <para>Imprimir registros para traslados y salidas</para>
    /// </summary>
    public class INVImprimir
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegistro = String.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public String gcrTipoRegistro = "GENERAL";    // "GENERAL" = Formato Suministro Interno
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia = true;          // true = mostrar vista previa / fase = no mostrar vista previa
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
            // Reporte Suministro Interno
            if (gcrTipoRegistro == "GENERAL")
            {
                #region Formato impresion traslado interno
                if (flgCargarTempDatosSuministro())
                {
                    //- Formato de Suministro Interno 
                    INV_MovSuministro lobRepSuministro01 = new INV_MovSuministro();
                    lobRepSuministro01.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepSuministro01;
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
            // Reporte Suministro Interno Detalles
            else if (gcrTipoRegistro == "DETALLES")
            {
                #region Formato impresion detalles suministro interno
                if (flgCargarTempDatosSuministro())
                {
                    //- Suministro interno detalles
                    INV_MovSuministroDe lobRepsSuministro02 = new INV_MovSuministroDe();
                    lobRepsSuministro02.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepsSuministro02;
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
        }
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void fcvCargarEncabezados()
        {
            // Encabezados 
            var lobEncab = REPUtilidades.fobDataSet01Encabezado(ref gobDataSet);
            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosSuministro: Cargar Datos suministro interno
        //-------------------------------------------------
        #region flgCargarTempDatosSuministro: Cargar Datos Suministro Interno
        /// <summary>
        /// <para>Cargar Datos suministro interno</para>
        /// </summary>
        private bool flgCargarTempDatosSuministro()
        {
            var llgReturn = false;

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            List<ModeloInvMovSuministro> lobTempMaestro = null;
            List<ModeloInvMovSuministroDe> lobTempDetalles = null;
            List<ModeloInvKardexMaestro> lobTempKardex = null;

            //gobDataSet = new DataSet01();
            DataSet01.InvmovdiariosmaDataTable lobMaestro = gobDataSet.Invmovdiariosma;
            DataSet01.InvmovdiariosmdDataTable lobDetalles = gobDataSet.Invmovdiariosmd;
            DataSet01.InvkardexmaestrDataTable lobKardex = gobDataSet.Invkardexmaestr;
            //----------------------------------------------------------
            // Maestro suministro interno
            //----------------------------------------------------------
            #region Maestro Suministro Interno
            DataSet01.InvmovdiariosmaRow lobRegistroMa = lobMaestro.NewInvmovdiariosmaRow();
            lobTempMaestro = ModeloInvMovSuministro.flsListaInvmovdiariosma(gcrCodigoRegistro);

            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewInvmovdiariosmaRow();

                lobRegistroMa.Inv_secreg_inma = lobReg.Inv_secreg_inma;
                lobRegistroMa.Inv_tipmov_intr = lobReg.Inv_tipmov_intr;
                lobRegistroMa.Inv_desreg_intr = lobReg.Inv_desreg_intr;
                lobRegistroMa.Inv_conmov_incm = lobReg.Inv_conmov_incm;
                lobRegistroMa.Inv_descon_incm = lobReg.Inv_descon_incm;
                lobRegistroMa.Inv_desreg_inma = lobReg.Inv_desreg_inma;
                lobRegistroMa.Inv_fecges_inma = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inma);
                lobRegistroMa.Inv_secref_inma = lobReg.Inv_secref_inma;
                lobRegistroMa.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMa.Inv_desalm_inal = lobReg.Inv_desalm_inal;
                lobRegistroMa.Inv_codald_inal = lobReg.Inv_codald_inal;
                lobRegistroMa.Deinv_codald_inal = lobReg.Deinv_codald_inal;
                lobRegistroMa.Con_codsco_ccos = lobReg.Con_codsco_ccos;
                lobRegistroMa.Inv_fecdoc_inma = Funciones.fcrConvertFecha(lobReg.Inv_fecdoc_inma);
                lobRegistroMa.Inv_codres_inre = lobReg.Inv_codres_inre;
                lobRegistroMa.Inv_nomres_inre = lobReg.Inv_nomres_inre;
                lobRegistroMa.Sis_coddep_sidp = lobReg.Sis_coddep_sidp;
                lobRegistroMa.Sis_nomdep_sidp = lobReg.Sis_nomdep_sidp;
                lobRegistroMa.Sia_codare_aser = lobReg.Sia_codare_aser;
                lobRegistroMa.Sia_desare_aser = lobReg.Sia_desare_aser;
                lobRegistroMa.Inv_brufac_inmd = lobReg.Inv_brufac_inmd;
                lobRegistroMa.Inv_pordes_inmd = lobReg.Inv_pordes_inmd;
                lobRegistroMa.Inv_valiva_inmd = lobReg.Inv_valiva_inmd;
                lobRegistroMa.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMa.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroMa.Inv_valfac_inmd = lobReg.Inv_valfac_inmd;
                lobRegistroMa.Inv_fecanu_inma = Funciones.fcrConvertFecha(lobReg.Inv_fecanu_inma);
                lobRegistroMa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroMa.Inv_conreg_inma = lobReg.Inv_conreg_inma;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMa.Sis_despro_espr = lobReg.Sis_despro_espr;

                // Add en temporal
                gobDataSet.Invmovdiariosma.AddInvmovdiariosmaRow(lobRegistroMa);
            }
            #endregion
            //----------------------------------------------------------
            // Detalles suministro interno
            //----------------------------------------------------------
            #region Detalles Suministro Interno
            DataSet01.InvmovdiariosmdRow lobRegistroMd = lobDetalles.NewInvmovdiariosmdRow();
            lobTempDetalles = ModeloInvMovSuministroDe.flsListaInvmovdiariosmdRpt(gcrCodigoRegistro);
            llgReturn = false;

            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistroMd = lobDetalles.NewInvmovdiariosmdRow();

                lobRegistroMd.Inv_secreg_inmd = lobReg.Inv_secreg_inmd;
                lobRegistroMd.Inv_secreg_inma = lobReg.Inv_secreg_inma;
                lobRegistroMd.Inv_fecges_inma = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inma);
                lobRegistroMd.Inv_secart_inar = lobReg.Inv_secart_inar;
                lobRegistroMd.Inv_codaux_inar = lobReg.Inv_codaux_inar;
                lobRegistroMd.Inv_codbar_inar = lobReg.Inv_codbar_inar;
                lobRegistroMd.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMd.Inv_codald_inal = lobReg.Inv_codald_inal;
                lobRegistroMd.Con_codsco_ccos = lobReg.Con_codsco_ccos;
                lobRegistroMd.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                lobRegistroMd.Inv_coduma_sium = lobReg.Inv_coduma_sium;
                lobRegistroMd.Inv_codctn_intc = lobReg.Inv_codctn_intc;
                lobRegistroMd.Inv_totctn_inmd = lobReg.Inv_totctn_inmd;
                lobRegistroMd.Inv_unictn_inmd = lobReg.Inv_unictn_inmd;
                lobRegistroMd.Inv_unisue_inmd = lobReg.Inv_unisue_inmd;
                lobRegistroMd.Inv_unitot_inmd = lobReg.Inv_unitot_inmd;
                lobRegistroMd.Inv_unidev_inmd = lobReg.Inv_unidev_inmd;
                lobRegistroMd.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMd.Inv_brufac_inmd = lobReg.Inv_brufac_inmd;
                lobRegistroMd.Inv_pordes_inmd = lobReg.Inv_pordes_inmd;
                lobRegistroMd.Inv_valiva_inmd = lobReg.Inv_valiva_inmd;
                lobRegistroMd.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroMd.Inv_valfac_inmd = lobReg.Inv_valfac_inmd;
                lobRegistroMd.Inv_codest_ines = lobReg.Inv_codest_ines;
                lobRegistroMd.Inv_seccio_ines = lobReg.Inv_seccio_ines;
                lobRegistroMd.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroMd.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMd.Inv_nomart_inar = lobReg.Inv_nomart_inar;
                lobRegistroMd.Inv_desalm_inal = lobReg.Inv_desalm_inal;
                lobRegistroMd.Sis_desgme_sigr = lobReg.Sis_desgme_sigr;
                lobRegistroMd.Sis_desume_sium = lobReg.Sis_desume_sium;
                lobRegistroMd.Inv_desctn_intc = lobReg.Inv_desctn_intc;
                lobRegistroMd.Sis_despro_espr = lobReg.Sis_despro_espr;
                lobRegistroMd.Inv_codgru_ingr = lobReg.Inv_codgru_ingr;
                lobRegistroMd.Inv_desgru_ingr = lobReg.Inv_desgru_ingr;

                // Add en temporal
                gobDataSet.Invmovdiariosmd.AddInvmovdiariosmdRow(lobRegistroMd);
            }
            #endregion
            //----------------------------------------------------------
            // Maestro kardex
            //----------------------------------------------------------
            #region Maestro Kardex
            DataSet01.InvkardexmaestrRow lobRegistroKa = lobKardex.NewInvkardexmaestrRow();
            lobTempKardex = ModeloInvKardexMaestro.flsListaInvkardexMaestroRpt(gcrCodigoRegistro);

            foreach (var lobReg in lobTempKardex)
            {
                llgReturn = true;
                lobRegistroKa = lobKardex.NewInvkardexmaestrRow();

                lobRegistroKa.Inv_seckar_inka = lobReg.Inv_seckar_inka;
                lobRegistroKa.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroKa.Inv_codper_inpe = lobReg.Inv_codper_inpe;
                lobRegistroKa.Inv_llavkr_inka = lobReg.Inv_llavkr_inka;
                lobRegistroKa.Inv_tiparc_inag = lobReg.Inv_tiparc_inag;
                lobRegistroKa.Inv_fecges_inka = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inka);
                lobRegistroKa.Inv_numdoc_inka = lobReg.Inv_numdoc_inka;
                lobRegistroKa.Inv_refkar_inka = lobReg.Inv_refkar_inka;
                lobRegistroKa.Inv_tipreg_inka = lobReg.Inv_tipreg_inka;
                lobRegistroKa.Inv_tipmov_intr = lobReg.Inv_tipmov_intr;
                lobRegistroKa.Inv_conmov_incm = lobReg.Inv_conmov_incm;
                lobRegistroKa.Inv_secart_inar = lobReg.Inv_secart_inar;
                lobRegistroKa.Inv_codaux_inar = lobReg.Inv_codaux_inar;
                lobRegistroKa.Inv_lotref_inar = lobReg.Inv_lotref_inar;
                lobRegistroKa.Inv_fecven_inka = Funciones.fcrConvertFecha(lobReg.Inv_fecven_inka);
                lobRegistroKa.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                lobRegistroKa.Sis_codume_sium = lobReg.Sis_codume_sium;
                lobRegistroKa.Inv_totuni_inex = lobReg.Inv_totuni_inex;
                lobRegistroKa.Inv_tottra_inex = lobReg.Inv_tottra_inex;
                lobRegistroKa.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroKa.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroKa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroKa.Sis_estpro_espr = lobReg.Sis_estpro_espr;

                // Add en temporal
                gobDataSet.Invkardexmaestr.AddInvkardexmaestrRow(lobRegistroKa);
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #endregion
    }
}


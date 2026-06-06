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
    public class INVImprimirAjustInven
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegistro = String.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public String gcrCodigoAlmacen = String.Empty;  // Codigo de almacen
        public String gcrTipoRegistro = "GENERAL";    // "GENERAL" = Formato Ajuste Inventario
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
            // formatos de impresion ajuste inventario
            if (gcrTipoRegistro == "GENERAL")
            {
                #region Formato impresion ajuste inventario
                if (flgCargarTempDatosAjusteInventario())
                {
                    //- Formato de Ajuste Inventario
                    INV_AjusteInventario lobRepAjustInven01 = new INV_AjusteInventario();
                    lobRepAjustInven01.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepAjustInven01;
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
        // flgCargarTempDatosAjusteInventario: Cargar datos ajuste inventario
        //-------------------------------------------------
        #region flgCargarTempDatosAjusteInventario: Cargar Datos Ajuste Inventario
        /// <summary>
        /// <para>Cargar datos ajuste inventario</para>
        /// </summary>
        private bool flgCargarTempDatosAjusteInventario()
        {
            var llgReturn = false;

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            List<ModeloInvajustesmaema> lobTempMaestro = null;
            List<ModeloInvajustesmaemd> lobTempDetalles = null;
            List<ModeloInvajustesmaemr> lobTempExistenMr = null;
            //List<ModeloInvAlmacenExistencias> lobTempEx = null;
            //List<ModeloInvKardexMaestro> lobTempKardex = null;

            //gobDataSet = new DataSet01();
            DataSet01.InvajustesmaemaDataTable lobMaestro = gobDataSet.Invajustesmaema;
            DataSet01.InvajustesmaemdDataTable lobDetalles = gobDataSet.Invajustesmaemd;
            DataSet01.InvajustesmaemrDataTable lobExistenMr = gobDataSet.Invajustesmaemr;
            //DataSet01.InvalmacexistenDataTable lobExisten = gobDataSet.Invalmacexisten;
            //DataSet01.InvkardexmaestrDataTable lobKardex = gobDataSet.Invkardexmaestr;
            //----------------------------------------------------------
            // Maestro ajuste inventario
            //----------------------------------------------------------
            #region Maestro Ajuste Inventario
            DataSet01.InvajustesmaemaRow lobRegistroMa = lobMaestro.NewInvajustesmaemaRow();
            lobTempMaestro = ModeloInvajustesmaema.flsListaInvajustesmaema(gcrCodigoRegistro);

            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewInvajustesmaemaRow();

                lobRegistroMa.Inv_secreg_inja = lobReg.Inv_secreg_inja;
                lobRegistroMa.Inv_fecges_inja = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inja);
                lobRegistroMa.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMa.Inv_conaju_incp = lobReg.Inv_conaju_incp;
                lobRegistroMa.Inv_conmov_incm = lobReg.Inv_conmov_incm;
                lobRegistroMa.Inv_desaju_inja = lobReg.Inv_desaju_inja;
                lobRegistroMa.Sia_codare_aser = lobReg.Sia_codare_aser;
                lobRegistroMa.Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                lobRegistroMa.Sia_codcat_ceat = lobReg.Sia_codcat_ceat;
                lobRegistroMa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroMa.Inv_conreg_inja = lobReg.Inv_conreg_inja;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;

                // Add en temporal
                gobDataSet.Invajustesmaema.AddInvajustesmaemaRow(lobRegistroMa);
            }
            #endregion
            //----------------------------------------------------------
            // Detalles ajuste inventario
            //----------------------------------------------------------
            #region Detalles Ajuste Inventario
            DataSet01.InvajustesmaemdRow lobRegistroMd = lobDetalles.NewInvajustesmaemdRow();
            lobTempDetalles = ModeloInvajustesmaemd.flsListaInvajustesmaemdRpt(gcrCodigoRegistro);           

            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistroMd = lobDetalles.NewInvajustesmaemdRow();

                lobRegistroMd.Inv_secreg_injd = lobReg.Inv_secreg_injd;
                lobRegistroMd.Inv_secreg_inja = lobReg.Inv_secreg_inja;
                lobRegistroMd.Inv_fecges_inja = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inja);
                lobRegistroMd.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMd.Inv_secart_inar = lobReg.Inv_secart_inar;
                lobRegistroMd.Inv_codaux_inar = lobReg.Inv_codaux_inar;
                lobRegistroMd.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                lobRegistroMd.Inv_totuni_inex = lobReg.Inv_totuni_inex;
                lobRegistroMd.Inv_totuni_injd = lobReg.Inv_totuni_injd;
                lobRegistroMd.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMd.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroMd.Sis_estpro_espr = lobReg.Sis_estpro_espr;

                // Add en temporal
                gobDataSet.Invajustesmaemd.AddInvajustesmaemdRow(lobRegistroMd);
            }          
            #endregion
            //----------------------------------------------------------
            // Registros tipo detalles lotes o referencias
            //----------------------------------------------------------
            #region Registros tipo detalles lotes o referencias
            DataSet01.InvajustesmaemrRow lobRegistroMr = lobExistenMr.NewInvajustesmaemrRow();
            lobTempExistenMr = ModeloInvajustesmaemr.flsListaInvajustesmaemrRpt(gcrCodigoRegistro);          

            foreach (var lobReg in lobTempExistenMr)
            {
                llgReturn = true;
                lobRegistroMr = lobExistenMr.NewInvajustesmaemrRow();

                lobRegistroMr.Inv_secreg_injr = lobReg.Inv_secreg_injr;
                lobRegistroMr.Inv_secreg_injd = lobReg.Inv_secreg_injd;
                lobRegistroMr.Inv_secreg_inja = lobReg.Inv_secreg_inja;
                lobRegistroMr.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMr.Inv_tipmov_intr = lobReg.Inv_tipmov_intr;
                lobRegistroMr.Inv_seckar_inka = lobReg.Inv_seckar_inka;
                lobRegistroMr.Inv_secart_inar = lobReg.Inv_secart_inar;
                lobRegistroMr.Inv_codaux_inar = lobReg.Inv_codaux_inar;
                lobRegistroMr.Inv_lotref_inar = lobReg.Inv_lotref_inar;
                lobRegistroMr.Inv_fecven_inka = Funciones.fcrConvertFecha(lobReg.Inv_fecven_inka);
                lobRegistroMr.Inv_codest_ines = lobReg.Inv_codest_ines;
                lobRegistroMr.Inv_seccio_ines = lobReg.Inv_seccio_ines;
                lobRegistroMr.Inv_totuni_inex = lobReg.Inv_totuni_inex;
                lobRegistroMr.Inv_totaju_injd = lobReg.Inv_totaju_injd;
                lobRegistroMr.Inv_totmov_injd = lobReg.Inv_totmov_injd;
                lobRegistroMr.Inv_totuni_injd = lobReg.Inv_totuni_injd;
                lobRegistroMr.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMr.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroMr.Inv_desalm_inal = lobReg.Inv_desalm_inal;
                lobRegistroMr.Inv_desreg_intr = lobReg.Inv_desreg_intr;
                lobRegistroMr.Inv_nomart_inar = lobReg.Inv_nomart_inar;
                lobRegistroMr.Inv_desest_ines = lobReg.Inv_desest_ines;
                lobRegistroMr.Sis_estpro_espr = lobReg.Sis_estpro_espr;

                // Add en temporal
                gobDataSet.Invajustesmaemr.AddInvajustesmaemrRow(lobRegistroMr);
            }      
            return llgReturn;
            #endregion
            //----------------------------------------------------------
            // Maestro Existencias en Inventario
            //----------------------------------------------------------
            #region Maestro Existencias en Inventario
            //DataSet01.InvalmacexistenRow lobRegistroEx = lobExisten.NewInvalmacexistenRow();
            //lobTempEx = ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm(gcrCodigoRegistro, gcrCodigoAlmacen);

            //foreach (var lobReg in lobTempEx)
            //{
            //    llgReturn = true;
            //    lobRegistroEx = lobExisten.NewInvalmacexistenRow();

            //    lobRegistroEx.Inv_secreg_incx = lobReg.Inv_secreg_incx;
            //    lobRegistroEx.Inv_codalm_inal = lobReg.Inv_codalm_inal;
            //    lobRegistroEx.Inv_secart_inar = lobReg.Inv_secart_inar;
            //    lobRegistroEx.Inv_codaux_inar = lobReg.Inv_codaux_inar;
            //    lobRegistroEx.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
            //    //lobRegistroEx.Inv_fecges_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inca);
            //    lobRegistroEx.Sis_codume_sium = lobReg.Sis_codume_sium;
            //    lobRegistroEx.Inv_totuni_inex = lobReg.Inv_totuni_inex;
            //    lobRegistroEx.Inv_valing_inar = lobReg.Inv_valing_inar;
            //    lobRegistroEx.Inv_valmov_inar = lobReg.Inv_valmov_inar;
            //    lobRegistroEx.Inv_valcos_inex = lobReg.Inv_valcos_inex;
            //    //lobRegistroEx.Inv_fecdoc_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecdoc_inca);
            //    //lobRegistroEx.Inv_fecsol_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecsol_inca);
            //    lobRegistroEx.Inv_codest_ines = lobReg.Inv_codest_ines;
            //    lobRegistroEx.Inv_seccio_ines = lobReg.Inv_seccio_ines;
            //    lobRegistroEx.Inv_estant_ines = lobReg.Inv_estant_ines;
            //    lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
            //    lobRegistroEx.Inv_nomart_inar = lobReg.Inv_nomart_inar;
            //    lobRegistroEx.Inv_desalm_inal = lobReg.Inv_desalm_inal;
            //    lobRegistroEx.Inv_codgru_ingr = lobReg.Inv_codgru_ingr;
            //    lobRegistroEx.Inv_desgru_ingr = lobReg.Inv_desgru_ingr;

            //    // Add en temporal
            //    gobDataSet.Invalmacexisten.AddInvalmacexistenRow(lobRegistroEx);
            //}
            #endregion
            //----------------------------------------------------------
            // Maestro kardex
            //----------------------------------------------------------
            #region Maestro Kardex
            //DataSet01.InvkardexmaestrRow lobRegistroKa = lobKardex.NewInvkardexmaestrRow();
            //lobTempKardex = ModeloInvKardexMaestro.flsListaInvkardexMaestroRpt(gcrCodigoRegistro);
            //llgReturn = false;

            //foreach (var lobReg in lobTempKardex)
            //{
            //    llgReturn = true;
            //    lobRegistroKa = lobKardex.NewInvkardexmaestrRow();

            //    lobRegistroKa.Inv_seckar_inka = lobReg.Inv_seckar_inka;
            //    lobRegistroKa.Inv_codalm_inal = lobReg.Inv_codalm_inal;
            //    lobRegistroKa.Inv_codper_inpe = lobReg.Inv_codper_inpe;
            //    lobRegistroKa.Inv_llavkr_inka = lobReg.Inv_llavkr_inka;
            //    lobRegistroKa.Inv_tiparc_inag = lobReg.Inv_tiparc_inag;
            //    lobRegistroKa.Inv_fecges_inka = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inka);
            //    lobRegistroKa.Inv_numdoc_inka = lobReg.Inv_numdoc_inka;
            //    lobRegistroKa.Inv_refkar_inka = lobReg.Inv_refkar_inka;
            //    lobRegistroKa.Inv_tipreg_inka = lobReg.Inv_tipreg_inka;
            //    lobRegistroKa.Inv_tipmov_intr = lobReg.Inv_tipmov_intr;
            //    lobRegistroKa.Inv_conmov_incm = lobReg.Inv_conmov_incm;
            //    lobRegistroKa.Inv_secart_inar = lobReg.Inv_secart_inar;
            //    lobRegistroKa.Inv_codaux_inar = lobReg.Inv_codaux_inar;
            //    lobRegistroKa.Inv_lotref_inar = lobReg.Inv_lotref_inar;
            //    lobRegistroKa.Inv_fecven_inka = Funciones.fcrConvertFecha(lobReg.Inv_fecven_inka);
            //    lobRegistroKa.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
            //    lobRegistroKa.Sis_codume_sium = lobReg.Sis_codume_sium;
            //    lobRegistroKa.Inv_totuni_inex = lobReg.Inv_totuni_inex;
            //    lobRegistroKa.Inv_tottra_inex = lobReg.Inv_tottra_inex;
            //    lobRegistroKa.Inv_valing_inar = lobReg.Inv_valing_inar;
            //    lobRegistroKa.Inv_valmov_inar = lobReg.Inv_valmov_inar;
            //    lobRegistroKa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
            //    lobRegistroKa.Sis_estpro_espr = lobReg.Sis_estpro_espr;

            //    // Add en temporal
            //    gobDataSet.Invkardexmaestr.AddInvkardexmaestrRow(lobRegistroKa);
            //}
            //return llgReturn;
            #endregion
        }
        #endregion
        #endregion
    }
}
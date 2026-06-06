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
    public class INVImprimirFormato
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegistro = String.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public String gcrTipoRegistro = "COMPRAS";    // "COMPRAS" = Formato Entrada Compras
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
        #region fcvEjecutar: Funcion para ejecutar reportes
        public void fcvEjecutar()
        {
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            fcvCargarEncabezados();
            // formatos de impresion entrada compras
            if (gcrTipoRegistro == "COMPRAS")
            {
                #region Formato impresion entrada compras
                if (flgCargarTempDatosEntradaCompras())
                {
                    //- Formato de Entrada Compras
                    INV_EntradaCompras lobRepEntradaCompra01 = new INV_EntradaCompras();
                    lobRepEntradaCompra01.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepEntradaCompra01;
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
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosEntradaCompras: Cargar datos entrada compras
        //-------------------------------------------------
        #region flgCargarTempDatosEntradaCompras: Cargar Datos Entrada Compras
        /// <summary>
        /// <para>Cargar datos entrada compras</para>
        /// </summary>
        private bool flgCargarTempDatosEntradaCompras()
        {
            var llgReturn = false;

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            List<ModeloEntradaCompras> lobTempMaestro = null;
            List<ModeloDetallEntCompra> lobTempDetalles = null;
            //List<ModeloInvKardexMaestro> lobTempKardex = null;

            //gobDataSet = new DataSet01();
            DataSet01.InvmovcomprasmaDataTable lobMaestro = gobDataSet.Invmovcomprasma;
            DataSet01.InvmovcomprasmdDataTable lobDetalles = gobDataSet.Invmovcomprasmd;
            //DataSet01.InvkardexmaestrDataTable lobKardex = gobDataSet.Invkardexmaestr;
            //----------------------------------------------------------
            // Maestro entrada compras
            //----------------------------------------------------------
            #region Maestro Entrada Compras
            DataSet01.InvmovcomprasmaRow lobRegistroMa = lobMaestro.NewInvmovcomprasmaRow();
            lobTempMaestro = ModeloEntradaCompras.flsListaInvmovcomprasma(gcrCodigoRegistro);

            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewInvmovcomprasmaRow();

                lobRegistroMa.Inv_secreg_inca = lobReg.Inv_secreg_inca;
                lobRegistroMa.Inv_tipmov_intr = lobReg.Inv_tipmov_intr;
                lobRegistroMa.Inv_tipreg_incx = lobReg.Inv_tipreg_incx;
                lobRegistroMa.Inv_conmov_incm = lobReg.Inv_conmov_incm;
                lobRegistroMa.Inv_desreg_inca = lobReg.Inv_desreg_inca;
                lobRegistroMa.Inv_fecges_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecges_inca);
                lobRegistroMa.Inv_numref_inca = lobReg.Inv_numref_inca;
                lobRegistroMa.Sis_secpro_sipr = lobReg.Sis_secpro_sipr;
                lobRegistroMa.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMa.Con_codsco_ccos = lobReg.Con_codsco_ccos;
                lobRegistroMa.Inv_numdoc_inca = lobReg.Inv_numdoc_inca;
                lobRegistroMa.Inv_fecdoc_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecdoc_inca);
                lobRegistroMa.Inv_fecsol_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecsol_inca);
                lobRegistroMa.Inv_diapla_inca = lobReg.Inv_diapla_inca;
                lobRegistroMa.Inv_brufac_incd = lobReg.Inv_brufac_incd;
                lobRegistroMa.Inv_pordes_incd = lobReg.Inv_pordes_incd;
                lobRegistroMa.Inv_valdes_incd = lobReg.Inv_valdes_incd;
                lobRegistroMa.Inv_valiva_incd = lobReg.Inv_valiva_incd;
                lobRegistroMa.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMa.Inv_valfac_incd = lobReg.Inv_valfac_incd;
                lobRegistroMa.Inv_salpag_inca = lobReg.Inv_salpag_inca;
                lobRegistroMa.Inv_valred_inar = lobReg.Inv_valred_inar;
                lobRegistroMa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroMa.Inv_fecanu_inca = Funciones.fcrConvertFecha(lobReg.Inv_fecanu_inca);
                lobRegistroMa.Inv_conreg_inca = lobReg.Inv_conreg_inca;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMa.Inv_desreg_intr = lobReg.Inv_desreg_intr;
                lobRegistroMa.Inv_desreg_incx = lobReg.Inv_desreg_incx;
                lobRegistroMa.Inv_descon_incm = lobReg.Inv_descon_incm;
                lobRegistroMa.Sis_razsoc_sipr = lobReg.Sis_razsoc_sipr;
                lobRegistroMa.Inv_desalm_inal = lobReg.Inv_desalm_inal;
                lobRegistroMa.Sys_nomusu_usux = lobReg.Sys_nomusu_usux;
                lobRegistroMa.Sis_despro_espr = lobReg.Sis_despro_espr;
                lobRegistroMa.Con_dessco_ccos = lobReg.Con_dessco_ccos;

                // Add en temporal
                gobDataSet.Invmovcomprasma.AddInvmovcomprasmaRow(lobRegistroMa);
            }
            #endregion
            //----------------------------------------------------------
            // Detalles entrada compras
            //----------------------------------------------------------
            #region Detalles Entrada Compras
            DataSet01.InvmovcomprasmdRow lobRegistroMd = lobDetalles.NewInvmovcomprasmdRow();
            lobTempDetalles = ModeloDetallEntCompra.flsListaInvmovcomprasmdRpt(gcrCodigoRegistro);
            llgReturn = false;

            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistroMd = lobDetalles.NewInvmovcomprasmdRow();

                lobRegistroMd.Inv_secreg_incd = lobReg.Inv_secreg_incd;
                lobRegistroMd.Inv_secreg_inca = lobReg.Inv_secreg_inca;
                lobRegistroMd.Inv_codalm_inal = lobReg.Inv_codalm_inal;
                lobRegistroMd.Inv_tipreg_incx = lobReg.Inv_tipreg_incx;
                lobRegistroMd.Inv_conmov_incm = lobReg.Inv_conmov_incm;
                lobRegistroMd.Inv_secart_inar = lobReg.Inv_secart_inar;
                lobRegistroMd.Inv_codaux_inar = lobReg.Inv_codaux_inar;
                lobRegistroMd.Inv_lotref_inar = lobReg.Inv_lotref_inar;
                lobRegistroMd.Inv_regsan_inar = lobReg.Inv_regsan_inar;
                lobRegistroMd.Inv_fecven_incd = Funciones.fcrConvertFecha(lobReg.Inv_fecven_incd);
                lobRegistroMd.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                lobRegistroMd.Sis_codume_sium = lobReg.Sis_codume_sium;
                lobRegistroMd.Inv_codctn_intc = lobReg.Inv_codctn_intc;
                lobRegistroMd.Inv_totctn_incd = lobReg.Inv_totctn_incd;
                lobRegistroMd.Inv_unictn_incd = lobReg.Inv_unictn_incd;
                lobRegistroMd.Inv_unisue_incd = lobReg.Inv_unisue_incd;
                lobRegistroMd.Inv_unitot_incd = lobReg.Inv_unitot_incd;
                lobRegistroMd.Inv_unidev_incd = lobReg.Inv_unidev_incd;
                lobRegistroMd.Inv_valing_inar = lobReg.Inv_valing_inar;
                lobRegistroMd.Inv_brufac_incd = lobReg.Inv_brufac_incd;
                lobRegistroMd.Inv_pordes_incd = lobReg.Inv_pordes_incd;
                lobRegistroMd.Inv_valdes_incd = lobReg.Inv_valdes_incd;
                lobRegistroMd.Inv_valiva_incd = lobReg.Inv_valiva_incd;
                lobRegistroMd.Inv_porive_inar = lobReg.Inv_porive_inar;
                lobRegistroMd.Inv_valred_inar = lobReg.Inv_valred_inar;
                lobRegistroMd.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                lobRegistroMd.Inv_valfac_incd = lobReg.Inv_valfac_incd;
                lobRegistroMd.Inv_codest_ines = lobReg.Inv_codest_ines;
                lobRegistroMd.Inv_seccio_ines = lobReg.Inv_seccio_ines;
                lobRegistroMd.Inv_estant_ines = lobReg.Inv_estant_ines;
                lobRegistroMd.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                lobRegistroMd.Inv_fecedt_ines = Funciones.fcrConvertFecha(lobReg.Inv_fecedt_ines);
                lobRegistroMd.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMd.Inv_desreg_inca = lobReg.Inv_desreg_inca;
                lobRegistroMd.Inv_desalm_inal = lobReg.Inv_desalm_inal;
                lobRegistroMd.Inv_desreg_incx = lobReg.Inv_desreg_incx;
                lobRegistroMd.Inv_descon_incm = lobReg.Inv_descon_incm;
                lobRegistroMd.Inv_nomart_inar = lobReg.Inv_nomart_inar;
                lobRegistroMd.Sis_desgme_sigr = lobReg.Sis_desgme_sigr;
                lobRegistroMd.Sis_desume_sium = lobReg.Sis_desume_sium;
                lobRegistroMd.Inv_desctn_intc = lobReg.Inv_desctn_intc;
                lobRegistroMd.Inv_desest_ines = lobReg.Inv_desest_ines;
                lobRegistroMd.Sys_nomusu_usux = lobReg.Sys_nomusu_usux;
                lobRegistroMd.Sis_despro_espr = lobReg.Sis_despro_espr;
                lobRegistroMd.Inv_codgru_ingr = lobReg.Inv_codgru_ingr;
                lobRegistroMd.Inv_desgru_ingr = lobReg.Inv_desgru_ingr;

                // Add en temporal
                gobDataSet.Invmovcomprasmd.AddInvmovcomprasmdRow(lobRegistroMd);
            }
            return llgReturn;
            #endregion
            //----------------------------------------------------------
            // Maestro kardex
            //----------------------------------------------------------
            #region Maestro Kardex
            //DataSet01.InvkardexmaestrRow lobRegistroKa = lobKardex.NewInvkardexmaestrRow();
            //lobTempKardex = ModeloInvKardexMaestro.flsListaInvkardexMaestroRpt(gcrCodigoRegistro);

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
        }
            #endregion
            #endregion
            #endregion
    }        
}

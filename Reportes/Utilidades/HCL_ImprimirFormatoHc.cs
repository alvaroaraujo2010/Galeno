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
    public class HCLImprimirFormatoHc
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        /// <summary>
        /// "REG" = Solo un registro particular con sus detalles "ADM" = Todos los registros de la admision
        /// </summary>
        public String gcrCodigoAdmision = String.Empty; // Numero de admision paciente / "PRUEBA"
        public String gcrCodigoRegistro = String.Empty; // Codigo registro en historial clinico hcl_nroreg_hcev
        public String gcrTipoFormato = "01";            // "01" = Vista Formato Carta maximo 4 col  "02" = Foramto Oficio "03" = Media carta
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia = true;              // true = mostrar vista previa / fase = no mostrar vista previa
        public byte[] gobArrayImgFirma = null;
        public TmpDatosFormatosMa lobRegMa = null;
        public List<TmpDatosFormatosDe> tmpDetalles = new List<TmpDatosFormatosDe>();
        public Window gobOwner;
        public DataSet01 gobDataSet = new DataSet01();
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
            // Reporte formato carta
            if (gcrTipoFormato == "01")
            {
                #region Reporte de una sola columna
                if (flgCargarTempDatosMaestro())
                {
                    // cargar los detalles
                    flgCargarTempDetalles();

                    //- Hoja tamaño carta maximo 5 columnas
                    HCL_ReporteFormatoHc01 lobRepPMInterno = new HCL_ReporteFormatoHc01();
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
            else if (gcrTipoFormato == "02")
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
        // flgCargarTempDatosMaestro Cargar datos 
        //-------------------------------------------------
        #region flgCargarTempDatosMaestro: Cargar registro maestro
        /// <summary>
        /// <para>Cargar registro maestro</para>
        /// </summary>
        private bool flgCargarTempDatosMaestro()
        {
            var llgReturn = false;

            DataSet01.HclOrdenServiciosMaDataTable lobMaestro = gobDataSet.HclOrdenServiciosMa;
            DataSet01.HclOrdenServiciosMaRow lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();

            // Registro maestro datos
            #region Registro maestro datos

            llgReturn = true;
            lobRegistroMa = lobMaestro.NewHclOrdenServiciosMaRow();

            lobRegistroMa.Hcl_titulo_reporte = lobRegMa.Hcl_titulo_reporte;  // Titulo
            lobRegistroMa.Hcl_nroreg_hcms = lobRegMa.Hcl_nroreg_hcms; // secuencial unico registro
            lobRegistroMa.Hcl_nroreg_hcev = lobRegMa.Hcl_nroreg_hcev; // Codigo registro en historial clinico
            lobRegistroMa.Adm_secadm_rgad = lobRegMa.Adm_secadm_rgad; // Admision
            lobRegistroMa.Sia_idesec_usua = lobRegMa.Sia_idesec_usua; // Id unico susuario
            lobRegistroMa.Sia_tipide_tide = lobRegMa.Sia_tipide_tide; // Tipo Ie
            lobRegistroMa.Sia_nroide_usua = lobRegMa.Sia_nroide_usua; // Numero identificacion
            lobRegistroMa.Hcl_tipreg_hctr = lobRegMa.Hcl_tipreg_hctr; // Tipo registro "SERV"/"MEDI" ...
            lobRegistroMa.Sia_codare_aser = lobRegMa.Sia_codare_aser; // Area prestacion de servicios
            lobRegistroMa.Hcl_gesfec_hcms = lobRegMa.Hcl_gesfec_hcms; // Fecha gestion
            lobRegistroMa.Hcl_geshor_hcms = lobRegMa.Hcl_geshor_hcms; // Hora gestion
            lobRegistroMa.Hcl_horges_hcms = Funciones.fcrConvierteHora(lobRegMa.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":"); // Hora gestion formato 12H
            lobRegistroMa.Hcl_tiptur_hctu = lobRegMa.Hcl_tiptur_hctu; // Tipo Turno clsificacion turno
            lobRegistroMa.Sia_codpfa_prof = lobRegMa.Sia_codpfa_prof; // Codigo del profesional
            lobRegistroMa.Sis_estpro_espr = lobRegMa.Sis_estpro_espr; // Estado del registro
            lobRegistroMa.Hcl_desreg_hcev = lobRegMa.Hcl_desreg_hcev; // Descripcion evento medico
            lobRegistroMa.Sia_nomusu_usua = lobRegMa.Sia_nomusu_usua; // Nombre completo del usuario o paciente 
            lobRegistroMa.Sia_deside_tide = lobRegMa.Sia_deside_tide; // Descrip tipo identificacion
            lobRegistroMa.Hcl_desreg_hctr = lobRegMa.Hcl_desreg_hctr; // Descripcion tipo registro "MEDICAMENTOS"/"SERVICIOS"...
            lobRegistroMa.Sia_desare_aser = lobRegMa.Sia_desare_aser; // Descripcion area prestacion servicio
            lobRegistroMa.Hcl_destur_hctu = "NA";
            lobRegistroMa.Sia_nompro_prof = lobRegMa.Sia_nompro_prof; // Nombre del profesional
            lobRegistroMa.Sis_despro_espr = lobRegMa.Sis_despro_espr; // Estado del proceso
            // Cargar la firma
            if (!String.IsNullOrWhiteSpace(lobRegMa.Hcl_objeto_imagen1))
            { 
                lobRegistroMa.Hcl_objeto_imagen1 = REPUtilidades.FobCargarImagenes(lobRegMa.Hcl_objeto_imagen1, @"\Imagenes\General\Sistemas");
            }
            // Add en temporal
            gobDataSet.HclOrdenServiciosMa.AddHclOrdenServiciosMaRow(lobRegistroMa);
            #endregion

            return llgReturn;
        }
        #endregion
        #region flgCargarTempDetalles: Registro detalles para vista en una sola columna
        /// <summary>
        /// <para>Registro detalles para vista en una sola columna</para>
        /// </summary>
        private bool flgCargarTempDetalles()
        {
            var llgReturn = false;

            DataSet01.HclregistroevDeDataTable lobDetalles = gobDataSet.HclregistroevDe;
            //----------------------------------------------------------
            // Detalles registros
            //----------------------------------------------------------
            #region Detalles registros
            DataSet01.HclregistroevDeRow lobRegistro = lobDetalles.NewHclregistroevDeRow();
            llgReturn = false;
            foreach (var lobReg in tmpDetalles)
            {
                llgReturn = true;
                lobRegistro = lobDetalles.NewHclregistroevDeRow();

                lobRegistro.Hcl_general_datos = "DATOS"; // referencia solo para generar un grupo y mostrar datos basicos del paciente
                lobRegistro.Hcl_seccion_codigo = lobReg.Hcl_seccion_codigo;
                lobRegistro.Hcl_seccion_titulo = lobReg.Hcl_seccion_titulo;
                lobRegistro.Hcl_secuen_registro = lobReg.Hcl_secuen_registro;
                lobRegistro.Hcl_seccion_columna = lobReg.Hcl_seccion_columna;
                lobRegistro.Hcl_titulo_dato1 = lobReg.Hcl_titulo_dato1;
                lobRegistro.Hcl_valor_dato1 = lobReg.Hcl_valor_dato1;
                lobRegistro.Hcl_titulo_dato2 = lobReg.Hcl_titulo_dato2;
                lobRegistro.Hcl_valor_dato2 = lobReg.Hcl_valor_dato2;
                lobRegistro.Hcl_titulo_dato3 = lobReg.Hcl_titulo_dato3;
                lobRegistro.Hcl_valor_dato3 = lobReg.Hcl_valor_dato3;
                lobRegistro.Hcl_titulo_dato4 = lobReg.Hcl_titulo_dato4;
                lobRegistro.Hcl_valor_dato4 = lobReg.Hcl_valor_dato4;
                lobRegistro.Hcl_titulo_dato5 = lobReg.Hcl_titulo_dato5;
                lobRegistro.Hcl_valor_dato5 = lobReg.Hcl_valor_dato5;
                lobRegistro.Hcl_titulo_dato6 = lobReg.Hcl_titulo_dato6;
                lobRegistro.Hcl_valor_dato6 = lobReg.Hcl_valor_dato6;
                lobRegistro.Hcl_titulo_dato7 = lobReg.Hcl_titulo_dato7;
                lobRegistro.Hcl_valor_dato7 = lobReg.Hcl_valor_dato7;
                lobRegistro.Hcl_titulo_dato8 = lobReg.Hcl_titulo_dato8;
                lobRegistro.Hcl_valor_dato8 = lobReg.Hcl_valor_dato8;
                lobRegistro.Hcl_titulo_dato9 = lobReg.Hcl_titulo_dato9;
                lobRegistro.Hcl_valor_dato9 = lobReg.Hcl_valor_dato9;
                lobRegistro.Hcl_titulo_dato10 = lobReg.Hcl_titulo_dato10;
                lobRegistro.Hcl_valor_dato10 = lobReg.Hcl_valor_dato10;

                gobDataSet.HclregistroevDe.AddHclregistroevDeRow(lobRegistro);

            }
            #endregion
            return llgReturn;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Reportes.Utilidades;
using Datos.Modelos;
using Sistema.Modelo;
using Sistema.Utilidades;
using System.IO;
using System.Drawing.Imaging;

namespace Reportes.Utilidades
{
    public static class REPUtilidades
    {
        //-----------------------------------------------------------------------------
        //  fobDataSet01Encabezado: Cargar registro de datos generales configuración IPS
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //  fobDataSet01Encabezado: Cargar registro de datos generales configuración IPS
        //-----------------------------------------------------------------------------
        #region FobDataSet01EncabezadoEx: Cargar registro de datos generales configuración IPS
        /// <summary>
        /// <para>Cargar registro de datos generales configuración IPS</para>
        /// </summary>
        public static DataSet01.SisEncabezadoRow FobDataSet01EncabezadoEx(String tcrTipo, String tcrIdRegistro, ref DataSet01 tobDataSet)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            //EFsisparametroips lobReg = SISValidarCodigo.fobRegBuscarSisparametroips();
            var lobReg = ModeloFeRazonSocial.FlsListaFcmfemaesrazsocmaID(tcrTipo, tcrIdRegistro);

            // DataSet y Encabezados 
            DataSet01.SisEncabezadoDataTable lobEncab = tobDataSet.SisEncabezado;
            var lobRegistro = lobEncab.NewSisEncabezadoRow();
            // Llenar los datos
            lobRegistro.RazonSocial         = lobReg.Fcm_razsoc_fcem;
            lobRegistro.Nit                 = lobReg.Fcm_numprn_fcem;
            lobRegistro.CodigoIPS           = lobReg.Fcm_codips_fcem;
            lobRegistro.Direccion           = lobReg.Fcm_dirres_fcem;
            lobRegistro.Ciudad              = lobReg.Sis_nommun_muni.Trim() + " - " + lobReg.Sis_desdep_dpto.Trim();
            lobRegistro.Telefonos           = lobReg.Fcm_nrotel_fcem;
            lobRegistro.Eslogan             = lobReg.Fcm_slogan_fcem;
            lobRegistro.FechaActual         = DateTime.Today.ToShortDateString();
            lobRegistro.FechaActualLarga    = DateTime.Today.ToLongDateString() + " - " + Funciones.fcrHoraActual("12", ":");
            lobRegistro.NombreEmpresa       = "Galeno 4.0 - Megassoft ®";
            lobRegistro.NombreUsuarioActivo = oApp.gcrUsuIdUsuario + " - " + oApp.gcrUsuNombreUsuario;
            lobRegistro.ImagenLogo          = fobCargarImagenes(lobReg.Fcm_imglog_fcem);
            lobRegistro.ImagenEncabezado    = fobCargarImagenes(lobReg.Fcm_imgcab_fcem);

            return lobRegistro;
        }
        #endregion FobDataSet01EncabezadoEx>

        #region fobDataSet01Encabezado: Cargar registro de datos generales configuración IPS
        /// <summary>
        /// <para>Cargar registro de datos generales configuración IPS</para>
        /// </summary>
        public static DataSet01.SisEncabezadoRow fobDataSet01Encabezado(ref DataSet01 tobDataSet)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            EFsisparametroips lobReg = SISValidarCodigo.fobRegBuscarSisparametroips();

            // DataSet y Encabezados 
            DataSet01.SisEncabezadoDataTable lobEncab = tobDataSet.SisEncabezado;
            var lobRegistro = lobEncab.NewSisEncabezadoRow();
            // Llenar los datos
            lobRegistro.RazonSocial = lobReg.sis_razsoc_pips;
            lobRegistro.Nit         = lobReg.sis_nitipx_pips;
            lobRegistro.CodigoIPS   = lobReg.sis_codips_pips;
            lobRegistro.Direccion   = lobReg.sis_dirips_pips;
            lobRegistro.Ciudad      = lobReg.sis_nommun_pips.Trim() + " - " + lobReg.sis_nomdpt_pips.Trim();
            lobRegistro.Telefonos   = lobReg.sis_telefo_pips;
            lobRegistro.Eslogan     = lobReg.sis_eslog_pips;
            lobRegistro.FechaActual         = DateTime.Today.ToShortDateString();
            lobRegistro.FechaActualLarga    = DateTime.Today.ToLongDateString() +" - "+Funciones.fcrHoraActual("12",":");
            lobRegistro.NombreEmpresa       = "Galeno 4.0 - Megassoft ®";
            lobRegistro.NombreUsuarioActivo = oApp.gcrUsuIdUsuario +" - "+ oApp.gcrUsuNombreUsuario;
            lobRegistro.ImagenLogo          = fobCargarImagenes("IMG001_Logotipo01.png");
            lobRegistro.ImagenEncabezado    = fobCargarImagenes("IMG001_Encabezado01.png");

            return lobRegistro;
        }
        #endregion
        //-----------------------------------------------------------------------------
        //  fobDataSet01Admision: Cargar registro datos de la admision dada 
        //-----------------------------------------------------------------------------
        #region fobDataSet01Admision: Cargar registro datos de la admision dada
        /// <summary>
        /// <para>Cargar registro datos de la admision dada</para>
        /// </summary>
        public static DataSet01.AdmAdmisionRow fobDataSet01Admision(ref DataSet01 tobDataSet, String tcrCodigoAdmision)
        {
            var llgAccion = true;
            var lobReg = new ADMModeloAdmadmisiones();
            DataSet01.AdmAdmisionDataTable lobAdm = tobDataSet.AdmAdmision;
            var lobRegistro = lobAdm.NewAdmAdmisionRow();

            if (tcrCodigoAdmision != "PRUEBA")
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(tcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { llgAccion = false; }
                lobReg = lobRegAdm.FirstOrDefault();

                // Llenar los datos
                if (llgAccion == true)
                {
                    #region Llenar los datos
                    lobRegistro.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                    lobRegistro.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                    lobRegistro.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                    lobRegistro.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                    lobRegistro.Hcl_nrohis_hicl = lobReg.Hcl_nrohis_hicl;
                    lobRegistro.Cit_codasi_mcit = lobReg.Cit_codasi_mcit;
                    lobRegistro.Adm_fecadm_rgad = lobReg.Adm_fecadm_rgad.ToShortDateString();
                    lobRegistro.Adm_horadm_rgad = lobReg.Adm_horadm_rgad;
                    lobRegistro.Adm_pacemb_rgad = lobReg.Adm_pacemb_rgad;
                    lobRegistro.Adm_nroreg_tria = lobReg.Adm_nroreg_tria;
                    lobRegistro.Sia_codare_aser = lobReg.Sia_codare_aser;
                    lobRegistro.Sia_areing_aser = lobReg.Sia_areing_aser;
                    lobRegistro.Adm_codtat_tatn = lobReg.Adm_codtat_tatn;
                    lobRegistro.Adm_codcex_tcex = lobReg.Adm_codcex_tcex;
                    lobRegistro.Sia_dixing_tdia = lobReg.Sia_dixing_tdia;
                    lobRegistro.Adm_caucon_rgad = lobReg.Adm_caucon_rgad;
                    lobRegistro.Cto_seccon_cont = lobReg.Cto_seccon_cont;
                    lobRegistro.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                    lobRegistro.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                    lobRegistro.Sia_edapac_usua = lobReg.Sia_edapac_usua;
                    lobRegistro.Sia_codmed_tmed = lobReg.Sia_codmed_tmed;
                    lobRegistro.Sia_edaymd_usua = lobReg.Sia_edaymd_usua;
                    lobRegistro.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                    lobRegistro.Adm_nroaut_rgad = lobReg.Adm_nroaut_rgad;
                    lobRegistro.Adm_nropol_rgad = lobReg.Adm_nropol_rgad;
                    lobRegistro.Sia_tipusu_regi = lobReg.Sia_tipusu_regi;
                    lobRegistro.Sia_tipafi_tafi = lobReg.Sia_tipafi_tafi;
                    lobRegistro.Sia_nivsbn_nsbn = lobReg.Sia_nivsbn_nsbn;
                    lobRegistro.Sia_tippob_tpob = lobReg.Sia_tippob_tpob;
                    lobRegistro.Sia_nivcon_ncon = lobReg.Sia_nivcon_ncon;
                    lobRegistro.Adm_nomaco_rgad = lobReg.Adm_nomaco_rgad;
                    lobRegistro.Adm_diraco_rgad = lobReg.Adm_diraco_rgad;
                    lobRegistro.Adm_telaco_rgad = lobReg.Adm_telaco_rgad;
                    lobRegistro.Adm_nrorem_rgad = lobReg.Adm_nrorem_rgad;
                    lobRegistro.Sis_idemun_muni = lobReg.Sis_idemun_muni;
                    lobRegistro.Sia_codips_tips = lobReg.Sia_codips_tips;
                    lobRegistro.Adm_fecrem_rgad = lobReg.Adm_fecrem_rgad;
                    lobRegistro.Adm_secite_rgad = lobReg.Adm_secite_rgad;
                    lobRegistro.Sia_regate_rgat = lobReg.Sia_regate_rgat;
                    lobRegistro.Adm_estfac_rgad = lobReg.Adm_estfac_rgad;
                    lobRegistro.Adm_estrad_rgad = lobReg.Adm_estrad_rgad;
                    lobRegistro.Adm_liqest_rgad = lobReg.Adm_liqest_rgad;
                    lobRegistro.Adm_ctarip_rgad = lobReg.Adm_ctarip_rgad;
                    lobRegistro.Sia_codfco_fcon = lobReg.Sia_codfco_fcon;
                    lobRegistro.Sia_coddia_tdia = lobReg.Sia_coddia_tdia;
                    lobRegistro.Adm_dessal_regr = lobReg.Adm_dessal_regr;
                    lobRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                    lobRegistro.Sia_priape_usua = lobReg.Sia_priape_usua;
                    lobRegistro.Sia_segape_usua = lobReg.Sia_segape_usua;
                    lobRegistro.Sia_prinom_usua = lobReg.Sia_prinom_usua;
                    lobRegistro.Sia_segnom_usua = lobReg.Sia_segnom_usua;
                    lobRegistro.Sia_destip_regi = lobReg.Sia_destip_regi;
                    lobRegistro.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                    lobRegistro.Sia_fecnac_usua = lobReg.Sia_fecnac_usua.ToShortDateString();
                    lobRegistro.Sis_codsex_sexo = lobReg.Sis_codsex_sexo;
                    lobRegistro.Adm_destat_tatn = lobReg.Adm_destat_tatn;
                    lobRegistro.Adm_descex_tcex = lobReg.Adm_descex_tcex;
                    lobRegistro.Sis_dessex_sexo = lobReg.Sis_dessex_sexo;
                    lobRegistro.Sia_telres_usua = lobReg.Sia_telres_usua;
                    lobRegistro.Sia_dirres_usua = lobReg.Sia_dirres_usua;
                    lobRegistro.Sia_correo_usua = lobReg.Sia_correo_usua;
                    lobRegistro.Sis_codocu_ocup = lobReg.Sis_codocu_ocup;
                    lobRegistro.Sia_tipdis_tdis = lobReg.Sia_tipdis_tdis;
                    lobRegistro.Sia_desdis_tdis = lobReg.Sia_desdis_tdis;
                    lobRegistro.Sis_desocu_ocup = lobReg.Sis_desocu_ocup;
                    lobRegistro.Sis_nommun_muni = lobReg.Sis_nommun_muni;
                    lobRegistro.Sis_despro_espr = lobReg.Sis_despro_espr;
                    lobRegistro.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                    lobRegistro.Sia_desper_pret = lobReg.Sia_desper_pret;
                    lobRegistro.Sia_desedu_sine = lobReg.Sia_desedu_sine;
                    #endregion
                }
            }
            else
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                #region Llenar los datos
                lobRegistro.Adm_secadm_rgad = "AP000000000";
                lobRegistro.Sia_idesec_usua = "ID000000010";
                lobRegistro.Sia_tipide_tide = "CC";
                lobRegistro.Sia_nroide_usua = "78454545454";
                lobRegistro.Hcl_nrohis_hicl = "HC000000000";
                lobRegistro.Cit_codasi_mcit = "AC000000000";
                lobRegistro.Adm_fecadm_rgad = Funciones.fcrFechaActual();
                lobRegistro.Adm_horadm_rgad = Convert.ToDecimal(Funciones.fcrHoraActual("24", lcrSeparadorDecimal));
                lobRegistro.Adm_pacemb_rgad = "3";
                lobRegistro.Adm_nroreg_tria = "TR0000000";
                lobRegistro.Sia_codare_aser = "003";
                lobRegistro.Sia_areing_aser = "003";
                lobRegistro.Adm_codtat_tatn = "2";
                lobRegistro.Adm_codcex_tcex = "15";
                lobRegistro.Sia_dixing_tdia = "Z00X";
                lobRegistro.Adm_caucon_rgad = "MALESTAR GENERAL";
                lobRegistro.Cto_seccon_cont = "CT0001";
                lobRegistro.Cto_nrocon_cont = "CT001-25-335";
                lobRegistro.Sia_codeps_teps = "EPS000";
                lobRegistro.Sia_edapac_usua = 20;
                lobRegistro.Sia_codmed_tmed = "1";
                lobRegistro.Sia_edaymd_usua = "20 Años/3 Meses/10 Dias";
                lobRegistro.Sia_codpfa_prof = "P025";
                lobRegistro.Adm_nroaut_rgad = "4512-25";
                lobRegistro.Sia_tipusu_regi = "1";
                lobRegistro.Sia_tipafi_tafi = "A";
                lobRegistro.Sia_nivsbn_nsbn = "N";
                lobRegistro.Sia_tippob_tpob = "5";
                lobRegistro.Sia_nivcon_ncon = "2";
                lobRegistro.Adm_nomaco_rgad = "MARIA PEREZ NOREÑA";
                lobRegistro.Adm_diraco_rgad = "CALLE 16 No 16A-45 - Barrio Dangond";
                lobRegistro.Adm_telaco_rgad = "322 455 2223";
                lobRegistro.Adm_nrorem_rgad = "RM-25222-98";
                lobRegistro.Sis_idemun_muni = "20356";
                lobRegistro.Sia_codips_tips = "20001-245222552";
                lobRegistro.Adm_fecrem_rgad = Convert.ToDateTime(Funciones.fcrFechaActual());
                lobRegistro.Adm_secite_rgad = 0;
                lobRegistro.Sia_regate_rgat = "1";
                lobRegistro.Adm_estfac_rgad = "1";
                lobRegistro.Adm_estrad_rgad = "1";
                lobRegistro.Adm_liqest_rgad = "1";
                lobRegistro.Adm_ctarip_rgad = "1";
                lobRegistro.Sia_codfco_fcon = "10";
                lobRegistro.Sia_coddia_tdia = "Z010";
                lobRegistro.Adm_dessal_regr = "1";
                lobRegistro.Sis_estpro_espr = "2";
                lobRegistro.Sia_priape_usua = "PAREDES";
                lobRegistro.Sia_segape_usua = "DIAZ";
                lobRegistro.Sia_prinom_usua = "PEDRO";
                lobRegistro.Sia_segnom_usua = "LUIS";
                lobRegistro.Sia_destip_regi = "CONTRIBUTIVO";
                lobRegistro.Sia_nomusu_usua = "PAREDES DIAZ PEDRO LUIS";
                lobRegistro.Sia_fecnac_usua = "20/05/1995";
                lobRegistro.Sis_codsex_sexo = "M";
                lobRegistro.Adm_destat_tatn = "HOSPITALIZACION";
                lobRegistro.Adm_descex_tcex = "ACCIDENTE";
                lobRegistro.Sis_dessex_sexo = "MASCULINO";
                lobRegistro.Sia_telres_usua = "322 5888 8888";
                lobRegistro.Sia_dirres_usua = "CALLE 12 Kra 23 No 11-78 Barrio Candelaria";
                lobRegistro.Sia_correo_usua = "paredesluis2@hotmail.com";
                lobRegistro.Sis_codocu_ocup = "250";
                lobRegistro.Sia_tipdis_tdis = "N";
                lobRegistro.Sia_desdis_tdis = "NINGUNA";
                lobRegistro.Sis_desocu_ocup = "OFICIOS VARIOS";
                lobRegistro.Sis_nommun_muni = "VALLEDUPAR";
                lobRegistro.Sis_despro_espr = "CONFIRMADO";
                lobRegistro.Sia_deseps_teps = "EPS VIDA";
                #endregion
            }
           
            return llgAccion == true ? lobRegistro : null;
        }
        #endregion
        //-----------------------------------------------------------------------------
        //  fobCargarImagenes: Cargar imagenes o logotipos desde ruta servidor
        //-----------------------------------------------------------------------------
        #region fobCargarImagenes: Cargar logotipos desde ruta servidor
        /// <summary>
        /// <para>Cargar logotipos desde ruta servidor </para>
        /// </summary>
        public static byte[] fobCargarImagenes(String tcrNombreImgLotipo)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            byte[] lobImagen = null;
            System.Drawing.Image lobImg = null;
            var lcrNombreArchivo = tcrNombreImgLotipo;

            // Definir la ruta servidor de los archivos de imagen
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            }

            // Ruta de recursos para reporte
            String lcrArchivoDestino = lcrRutaDestino + @"\Imagenes\Reportes\" + lcrNombreArchivo;
            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino + @"\Imagenes\Reportes\", lcrNombreArchivo);
            }

            if (File.Exists(lcrArchivoDestino))
            {
                lobImg = System.Drawing.Image.FromFile(lcrArchivoDestino);
                if (lobImg != null)
                {
                    MemoryStream ms = new MemoryStream();
                    lobImg.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            return lobImagen;
        }
        #endregion
        #region fobCargarImagenes: Cargar cualquier imagenes desde ruta servidor
        /// <summary>
        /// <para>Cargar cualquier imagenes desde ruta servidor</para>
        /// <para>tcrRutaImagen: Ruta final de la imagen dentro de la ruta de recursos ejemplo: "\Imagenes\Reportes\FotosOdontologia\"</para>
        /// </summary>
        public static byte[] FobCargarImagenes(String tcrNombreImagen, String tcrRutaImagen)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            byte[] lobImagen = null;
            System.Drawing.Image lobImg = null;
            var lcrNombreArchivo = tcrNombreImagen;

            // Definir la ruta servidor de los archivos de imagen
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath;
            }

            // Ruta de recursos para reporte
            String lcrArchivoDestino = lcrRutaDestino + tcrRutaImagen + @"\" + lcrNombreArchivo;
            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino + tcrRutaImagen + @"\", lcrNombreArchivo);
            }

            if (File.Exists(lcrArchivoDestino))
            {
                lobImg = System.Drawing.Image.FromFile(lcrArchivoDestino);
                if (lobImg != null)
                {
                    MemoryStream ms = new MemoryStream();
                    lobImg.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            return lobImagen; // cuando es null sale por aqui
        }
        #endregion
    }
    //----------------------------------------------------------------------
    // TEMPORAL DATOS INFORMES FORMATOS HISTORIA CLINICA CREADOS CON EDITOR
    //----------------------------------------------------------------------
    #region TmpDatosFormatosMa: Temporal para registro maestro en formatos creados con el editor de HC
    /// <summary>
    /// <para>Temporal para registro maestro en formatos creados con el editor de HC</para>
    /// </summary>
    public class TmpDatosFormatosMa
    {
        ///<summary>Titulo del reporte</summary>
        public string Hcl_titulo_reporte { get; set; }
        ///<summary>secuencial unico registro</summary>
        public string Hcl_nroreg_hcms { get; set; }
        ///<summary>secuencial unico registro</summary>
        public string Hcl_secreg_hcms { get; set; }
        ///<summary>Codigo registro en historial clinico</summary>
        public string Hcl_nroreg_hcev { get; set; }
        ///<summary>Numero admisión del paciente</summary>
        public string Adm_secadm_rgad { get; set; }
        ///<summary>Id unico susuario</summary>
        public string Sia_idesec_usua { get; set; }
        ///<summary>Tipo Identificación</summary>
        public string Sia_tipide_tide { get; set; }
        ///<summary>Numero identificación</summary>
        public string Sia_nroide_usua { get; set; }
        ///<summary>Tipo formmato informe (tamaño hoja): "01","02"...</summary>
        public string Hcl_tipreg_hctr { get; set; }
        ///<summary>Area prestacion de servicios</summary>
        public string Sia_codare_aser { get; set; }
        ///<summary>Fecha gestión</summary>
        public string Hcl_gesfec_hcms { get; set; }
        ///<summary>Hora gestión</summary>
        public Decimal Hcl_geshor_hcms { get; set; }
        ///<summary>Hora gestion formato 12 Horas ejemplo: 02:30:PM</summary>
        public string Hcl_horges_hcms { get; set; }
        ///<summary>Tipo Turno clsificacion: "MAÑANA/TARDE/NOCHE"</summary>
        public string Hcl_tiptur_hctu { get; set; }
        ///<summary>Codigo del profesional que presta el servicio</summary>
        public string Sia_codpfa_prof { get; set; }
        ///<summary>Estado del registro 1,2,3</summary>
        public string Sis_estpro_espr { get; set; }
        ///<summary>Descripcion evento medico en registro historial clinico</summary>
        public string Hcl_desreg_hcev { get; set; }
        ///<summary>Nombre completo del usuario o paciente </summary>
        public string Sia_nomusu_usua { get; set; }
        ///<summary>Descripcion tipo identificación</summary>
        public string Sia_deside_tide { get; set; }
        ///<summary>Descripcion tipo formato registro: "01"=Una soloa columna...</summary>
        public string Hcl_desreg_hctr { get; set; }
        ///<summary>Descripcion area prestacion servicio</summary>
        public string Sia_desare_aser { get; set; }
        ///<summary>Descripcion del turno</summary>
        public string Hcl_destur_hctu { get; set; }
        ///<summary>Nombre del profesional que presta servicio</summary>
        public string Sia_nompro_prof { get; set; }
        ///<summary>Estado del proceso 1= Abierto 2= Confirmado 3 { get; set; } Anulado</summary>
        public string Sis_despro_espr { get; set; }
        ///<summary>Numero registro medico del Profesional</summary>
        public string Sia_rmedic_prof { get; set; }
        ///<summary>Titulo de la imagen 1</summary>
        public string Hcl_titulo_imagen1 { get; set; }
        ///<summary>Imagen 1 en formato jpg</summary>
        public string Hcl_objeto_imagen1 { get; set; }
        ///<summary>Titulo de la imagen 2</summary>
        public string Hcl_titulo_imagen2 { get; set; }
        ///<summary>Imagen 2 en formato jpg</summary>
        public string Hcl_objeto_imagen2 { get; set; }
        ///<summary>Titulo de la imagen 1</summary>
        public string Hcl_titulo_imagen3 { get; set; }
        ///<summary>Imagen 3 en formato jpg</summary>
        public string Hcl_objeto_imagen3 { get; set; }
        ///<summary>Nota u observacion</summary>
        public string Hcl_observ_nota { get; set; }
    }
    #endregion
    #region TmpDatosFormatosDe: Temporal lista detalles valores digitados en formatos creados con el editor de HC
    /// <summary>
    /// <para>Temporal para lista valores digitados en formatos creados con el editor de HC</para>
    /// </summary>
    public class TmpDatosFormatosDe
    {
        
        ///<summary>Codigo grupo general para organizar varias copias del formato</summary>
        public string Hcl_general_datos { get; set; }
        ///<summary>Codigo seccion</summary>
        public string Hcl_seccion_codigo { get; set; }
        ///<summary>Titulo de la seccion </summary>
        public string Hcl_seccion_titulo { get; set; }
        ///<summary>Orden visualizacion seccion </summary>
        public int Hcl_seccion_ordvista { get; set; }
        ///<summary>Id unico del registro</summary>
        public string Hcl_secuen_registro { get; set; }
        ///<summary>Numero de columnas que tiene la seccion</summary>
        public string Hcl_seccion_columna { get; set; }
        ///<summary>Orden visualizacion del registro de dato dentro de la seccion</summary>
        public int Hcl_registro_ordvista { get; set; }
        ///<summary>Titulo del dato 1 a mostrar </summary>
        public string Hcl_titulo_dato1 { get; set; }
        ///<summary>Valor del dato 1</summary>
        public string Hcl_valor_dato1 { get; set; }
        ///<summary>Titulo del dato 2 a mostrar</summary>
        public string Hcl_titulo_dato2 { get; set; }
        ///<summary>Valor del dato 2</summary>
        public string Hcl_valor_dato2 { get; set; }
        ///<summary>Titulo del dato 3 a mostrar</summary>
        public string Hcl_titulo_dato3 { get; set; }
        ///<summary>Valor del dato 3</summary>
        public string Hcl_valor_dato3 { get; set; }
        ///<summary>Titulo del dato 4 a mostrar</summary>
        public string Hcl_titulo_dato4 { get; set; }
        ///<summary>Valor del dato 4</summary>
        public string Hcl_valor_dato4 { get; set; }
        ///<summary>Titulo del dato 5 a mostrar</summary>
        public string Hcl_titulo_dato5 { get; set; }
        ///<summary>Valor del dato 5</summary>
        public string Hcl_valor_dato5 { get; set; }
        ///<summary>Titulo del dato 6 a mostrar</summary>
        public string Hcl_titulo_dato6 { get; set; }
        ///<summary>Valor del dato 6</summary>
        public string Hcl_valor_dato6 { get; set; }
        ///<summary>Titulo del dato 7 a mostrar</summary>
        public string Hcl_titulo_dato7 { get; set; }
        ///<summary>Valor del dato 7</summary>
        public string Hcl_valor_dato7 { get; set; }
        ///<summary>Titulo del dato 8 a mostrar</summary>
        public string Hcl_titulo_dato8 { get; set; }
        ///<summary>Valor del dato 8</summary>
        public string Hcl_valor_dato8 { get; set; }
        ///<summary>Titulo del dato 9 a mostrar</summary>
        public string Hcl_titulo_dato9 { get; set; }
        ///<summary>Valor del dato 9</summary>
        public string Hcl_valor_dato9 { get; set; }
        ///<summary>Titulo del dato 10 a mostrar</summary>
        public string Hcl_titulo_dato10 { get; set; }
        ///<summary>Valor del dato 10</summary>
        public string Hcl_valor_dato10 { get; set; }

    }
    #endregion

}

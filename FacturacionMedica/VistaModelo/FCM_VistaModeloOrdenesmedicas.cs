//- MARMOTA-GENCODE: VERSION 2.0 - 15/06/2013 05:13:24 AM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Vista;
using Sistema.Clases;
using Sistema.Validacion;
using Datos.Modelos;
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloOrdenesmedicas : VistaModeloOrdenesmedicasBase
    {

        //--------------------------------------------------------
        // Variables Auxiliares
        //--------------------------------------------------------
        public String lcrG2Fcm_coddig_mant = String.Empty;
        //--------------------------------------------------------
        // Variables de notificación Zona 1
        //--------------------------------------------------------
        #region A1Sis_dessex_sexo: Sexo
        public const string gcrNomProp_A1Sis_dessex_sexo = "A1Sis_dessex_sexo";
        private string _a1sis_dessex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: a1sis_dessex_sexo (char:25)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion(Masculino,Femenino)
        /// </para>
        /// </summary>
        public string A1Sis_dessex_sexo
        {
            get { return _a1sis_dessex_sexo; }
            set
            {
                if (_a1sis_dessex_sexo == value) return;
                _a1sis_dessex_sexo = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_dessex_sexo);
            }
        }
        #endregion
        #region A1Sia_descot_tcot: Descripción tipo cotizante
        public const string gcrNomProp_A1Sia_descot_tcot = "A1Sia_descot_tcot";
        private string _a1sia_descot_tcot = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Descripción tipo cotizante</para>
        /// <para>NOMBRE: a1sia_descot_tcot (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo cotizante
        /// </para>
        /// </summary>
        public string A1Sia_descot_tcot
        {
            get { return _a1sia_descot_tcot; }
            set
            {
                if (_a1sia_descot_tcot == value) return;
                _a1sia_descot_tcot = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_descot_tcot);
            }
        }
        #endregion
        #region A1Sia_destaf_tafi: Descripción tipo afiliado
        public const string gcrNomProp_A1Sia_destaf_tafi = "A1Sia_destaf_tafi";
        private string _a1sia_destaf_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Descripción tipo afiliado</para>
        /// <para>NOMBRE: a1sia_destaf_tafi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción tipo afiliado contributivo
        /// </para>
        /// </summary>
        public string A1Sia_destaf_tafi
        {
            get { return _a1sia_destaf_tafi; }
            set
            {
                if (_a1sia_destaf_tafi == value) return;
                _a1sia_destaf_tafi = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_destaf_tafi);
            }
        }
        #endregion
        #region A1Sia_despob_tpob: Descripción población especial
        public const string gcrNomProp_A1Sia_despob_tpob = "A1Sia_despob_tpob";
        private string _a1sia_despob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Descripción población especial</para>
        /// <para>NOMBRE: a1sia_despob_tpob (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo población especial régimen subsidiado
        /// </para>
        /// </summary>
        public string A1Sia_despob_tpob
        {
            get { return _a1sia_despob_tpob; }
            set
            {
                if (_a1sia_despob_tpob == value) return;
                _a1sia_despob_tpob = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_despob_tpob);
            }
        }
        #endregion
        #region A1Sis_deszon_tzon: Zona de residencia
        public const string gcrNomProp_A1Sis_deszon_tzon = "A1Sis_deszon_tzon";
        private string _a1sis_deszon_tzon = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: Zona de residencia</para>
        /// <para>NOMBRE: a1sis_deszon_tzon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion zona  recidencia
        /// </para>
        /// </summary>
        public string A1Sis_deszon_tzon
        {
            get { return _a1sis_deszon_tzon; }
            set
            {
                if (_a1sis_deszon_tzon == value) return;
                _a1sis_deszon_tzon = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_deszon_tzon);
            }
        }
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public RelayCommand CmdSAVERELAUX { get; set; }
        public RelayCommand CmdACTUALFECFAC { get; set; }
        public RelayCommand CmdPRNFACT { get; set; }
        public RelayCommand CmdPRNCAJA { get; set; }
        public RelayCommand CmdLOGERRORES { get; set; }
        

        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO       = new RelayCommand(fcvFiltro, CanFiltro);
            CmdSAVERELAUX   = new RelayCommand(GuardarRelAux, CanSAVRELAUX);
            CmdACTUALFECFAC = new RelayCommand(fcvActualizarFechafactura, CanACTFACTURA);
            CmdLOGERRORES   = new RelayCommand(fcvVistaLogErrores, CanLOGERRORES);
            CmdPRNFACT      = new RelayCommand(fcvDefault, CanPRNFACT);
            CmdPRNCAJA      = new RelayCommand(fcvDefault, CanPRNCAJA);
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region CanFiltro
        /// <summary>
        ///Validación para saber si se permite ejecutar Filtro 
        /// </summary>
        public bool CanFiltro()
        {
            bool llgReturn = false;
            try
            {
                if (GcrSIS_FormModoPopup == "DFL" || (GlgSIS_ModoEdicion == false && GcrSIS_FormModoPopup == "EDT"))
                {
                    llgReturn = CanFIL();
                    if (GlgSIS_FormModoPopupIni == true && llgReturn == true && GcrSIS_FormModoPopup != "DFL")
                    {
                        GlgSIS_FormModoPopupIni = false;
                        Modificar();
                        GcrSIS_FormModoPopup = "DFL";
                        fcvAdicionarDatosRelacionR1();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFiltro");
            }
            return llgReturn;
        }
        #endregion
        #region CanSAVRELAUX
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar Registro Relación
        /// </summary>
        public bool CanSAVRELAUX()
        {
            bool llgReturn = false;
            try
            {
                if (CanSAVREL() && G2Fcm_estfac_mfac=="1") 
                 {
                     fcvCalcularTotalServicio();
                     if (flgValidacionPertinencia())
                     {
                         llgReturn = true;
                         fcvCalcularCopagoyCmoderadoras();
                     }
                 }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAVRELAUX");
            }
            return llgReturn;
        }
        #endregion
        #region CanACTFACTURA
        /// <summary>
        ///Validación para saber si se permite
        ///Activar el boton actualizar fecha factura y el campo 
        ///Fecha factura
        /// </summary>
        public virtual bool CanACTFACTURA()
        {
            bool llgReturn = false;
            GlgSIS_ActFechaFactura = false;
            try
            {

                //if (GlgSIS_ModoEdicion == true && G1Fcm_estfac_mfac == "1")
                if (GlgSIS_ModoEdicion == false && TmpG1RegActivo != null) // Cuando no estan enviadas a Dian
                {
                    if (GlgSIS_ModoEdicion == false && TmpG1RegActivo.Fcm_codest_fcws != "R01") 
                    {
                        GlgSIS_ActFechaFactura = true;
                        if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecfac_mfac, "Fecha Factura")))
                        {
                            llgReturn = true;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanACTFACTURA");
            }
            return llgReturn;
        }
        #endregion
        #region CanLOGERRORES
        /// <summary>
        ///Validación para saber si se permite
        ///Activar el boton par aver el log de errores
        /// </summary>
        public virtual bool CanLOGERRORES()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG2LogError.Count > 0)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanLOGERRORES");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRNFACT
        /// <summary>
        ///Validación para saber si se permite
        ///Activar opcion imprimir facturas
        /// </summary>
        public bool CanPRNFACT()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1ListaBrow.Count > 0 && GlgSIS_ModoEdicion == false)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNFACT");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRNCAJA
        /// <summary>
        ///Validación para saber si se permite
        ///Activar opcion imprimir recibos de caja
        /// </summary>
        public bool CanPRNCAJA()
        {
            bool llgReturn = false;
            try
            {
                llgReturn = false; 
                if (TmpG1ListaBrow != null)
                {
                    var lobReg = TmpG1ListaBrow.FirstOrDefault(x => x.Fcm_valefe_dfac > 0);
                    if (lobReg != null) { llgReturn = true; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNCAJA");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region fcvFiltro: Filtro Auxiliar
        /// <summary>
        /// Filtro Auxiliar
        /// </summary>
        public void fcvFiltro()
        {
            Filtro();
        }
        #endregion
        #region GuardarRelAux: Guardar en temporal Registro Relacion auxiliar
        /// <summary>
        /// Guardar Registro Relacion en temporal
        /// </summary>
        public void GuardarRelAux()
        {
            try
            {
                // Acumular cobros en efectivo
                G2Fcm_valref_dfac = 0;
                if (m.gcrContEfectivoServicios == "1") { G2Fcm_valref_dfac += G2Fcm_valfac_dfac; }
                if (m.gcrContEfectivoCopago == "1") { G2Fcm_valref_dfac += G2Fcm_valcpa_dfac; }
                if (m.gcrContEfectivoCmoderad == "1") { G2Fcm_valref_dfac += G2Fcm_valcmo_dfac; }
                if (m.gcrContEfectivoCargUsuar == "1") { G2Fcm_valref_dfac += G2Fcm_valusu_dfac; }
                //G2Fcm_valefe_dfac = G2Fcm_valref_dfac;
                //- Guardar datos en grilla
                GlgSIS_ActCodigoEps = false;
                GuardarRel();
                //fcvGuardarResumenServicios("1");
                //fcvSuamtoriaGeneralFacturas();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRelAux");
            }
        }
        #endregion
        #region fcvActualizarFechafactura: Actualizar fecha factura
        /// <summary>
        /// Actualizar fecha factura cuando el estado de esta
        /// sea 1 = Abierta
        /// </summary>
        public void fcvActualizarFechafactura()
        {
            try
            {
                if (MessageBox.Show("Desea actualizar la fecha de esta factura?", "Confirmación",
                                 MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (TmpG1ListaBrow.Count > 0)
                    {
                        FcmModeloMaestrofacturas lobRegMod = null;

                        foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                        {
                            if (lobReg.Fcm_secreg_mfac == G1Fcm_secreg_mfac)
                            {
                                lobReg.Sis_estado_imaen = "M"; // para modificar el registro
                                lobReg.Fcm_fecfac_mfac = Convert.ToDateTime(G1Fcm_fecfac_mfac);
                                lobRegMod = lobReg;
                                break;
                            }
                        }
                        if (lobRegMod != null)
                        {
                            FcmModeloMaestrofacturas.flgAddRegistro(lobRegMod);
                            lobRegMod.Sis_estado_imaen = "I"; // volver al estado normal
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvActualizarFechafactura");
            }
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        /// <summary>
        /// Mostrar la vista de errores
        /// </summary>
        public void fcvVistaLogErrores()
        {
            return;
        }
        #endregion
        #region fcvDefault
        /// <summary>
        /// Default Estado por defecto
        /// del formulario
        /// </summary>
        public void fcvDefault()
        {
            // Para Implementación
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "DIGITACION";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Cto_seccon_cont": // 001
                        #region Validacion Secuencial de Contrato
                        lcrCodigoError = "001";
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Cto_seccon_cont))
                        {
                            lcrValorReturn = "Secuencial de Contrato: Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G2Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_nrocon_cont))
                            {
                                G2Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G2Sia_codeps_teps = tmp.sia_codeps_teps;
                                G2Sis_idterc_sitr = tmp.sis_idterc_sitr;
                                G2Cto_descon_cont = tmp.cto_descon_cont;
                                G2Fcm_codman_mans = tmp.fcm_codman_mans;
                                G2Cto_tipact_cont = tmp.cto_tipact_cont;
                                G2Cto_serper_cont = tmp.cto_serper_cont;
                                //G2Sia_tipact_tsac = String.IsNullOrWhiteSpace(G2Sia_tipact_tsac) ? tmp.cto_tipact_cont : G2Sia_tipact_tsac;
                                G2Cto_sepser_cont = tmp.cto_sepser_cont;
                                // Descripcion EPS y Manual tarifario
                                G2Sia_deseps_teps = SIAValidarCodigo.fobRegBuscarSiatablaeps(G2Sia_codeps_teps).sia_deseps_teps;
                                //- Tipo Manual
                                var lobRegTipoMan   = FCMValidarCodigo.fobRegBuscarFcmmantarifario(G2Fcm_codman_mans);
                                G2Fcm_desman_mans   = lobRegTipoMan.fcm_desman_mans.Trim();
                                //- Para activar el campo codigo eps al digitar
                                if (tmp.cto_modeps_cont == "1" && GlgSIS_ModoEdicion == true) { GlgSIS_ActCodigoEps = true; } // para activar captura codigo EPS
                                // Verificar contrato inactivo
                                if (tmp.cto_estcon_cont == "2") // Contrato inactivo
                                {
                                    lcrValorReturn = "Contrato esta inactivo";
                                }
                                m.flgCargarParametrosContrato(G2Cto_seccon_cont);
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G2Fcm_coddig_mant": // 002
                        #region Validacion Código digitación servicio
                        lcrCodigoError = "002";
                        lcrNombreCampo = "Código digitación servicio";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            fcvLimpiarVariablesValorServicio();
                            lcrG2Fcm_coddig_mant = String.Empty;
                            lcrValorReturn = "Código digitación servicio: Es requerido";
                        }
                        else
                        {
                            G2Fcm_coddig_mant = G2Fcm_coddig_mant.ToUpper().Trim();

                            //var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(G2Fcm_coddig_mant, G2Fcm_codman_mans);
                            //if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_coddig_mant))
                            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(G2Fcm_coddig_mant, G2Fcm_codman_mans, 
                                                                                         G2Cto_seccon_cont, m.gcrContServPersonalizados);
                            if (tmp != null)
                            {
                                if (lcrG2Fcm_coddig_mant != G2Fcm_coddig_mant) 
                                {
                                    // Para los valores servicios que se digitan en pantalla (no usan liquidar valor servicios)
                                    lcrG2Fcm_coddig_mant = G2Fcm_coddig_mant;
                                    fcvLimpiarVariablesValorServicio();
                                }

                                if (tmp.fcm_codser_mant == "E%1") // Error en servicio personalizado
                                {
                                    lcrValorReturn = lcrNombreCampo + ": " + tmp.fcm_desser_mant;
                                }
                                else
                                {
                                    #region fcmmanservicios
                                    G2Adm_codtat_tatn = A1Adm_codtat_tatn;
                                    G2Fcm_idesec_mant = tmp.fcm_idesec_mant;
                                    G2Fcm_idesec_sips = tmp.fcm_idesec_sips;
                                    G2Fcm_desser_dfac = tmp.fcm_desser_mant;
                                    G2Fcm_codbar_sips = tmp.fcm_codbar_sips;
                                    G2Fcm_codser_mant = tmp.fcm_codser_mant;

                                    //G2Inv_secart_mart = tmp.inv_secart_mart;
                                    //cargar parametros
                                    if (!m.flgCargarParametrosServicio(tmp))
                                    {
                                        lcrValorReturn = "Código digitación servicio: Error al cargar parametros para calcular valor servicio";
                                    }
                                    else
                                    {
                                        if (G2Fcm_totuni_dfac <= 0) { G2Fcm_totuni_dfac = 1; }
                                        // Precio menor que cero
                                        if (m.gnuMantValorServicio <= 0 || m.gnuMantPuntajeValorServ < 0)
                                        {
                                            lcrValorReturn = "Valor del servicio o puntaje UVR no debe ser cero (" + m.gnuMantPuntajeValorServ.ToString() + ")";
                                        }
                                        fcvCalcularTotalServicio();
                                        //-------------------------------------
                                        //- Cargar parametros del servicio IPS
                                        //-------------------------------------
                                        GlgSIS_ActActoQuirurgico = false;
                                        var tmpAx = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(G2Fcm_coddig_mant);
                                        if (tmpAx != null)
                                        {
                                            #region Cargar parametros del servicio IPS
                                            //- verificar si hay acto quirurgico
                                            if (tmpAx.fcm_codtse_sips == "2") { GlgSIS_ActActoQuirurgico = true; } // es proc quirurgico
                                            // datos del servicio IPS adicionales
                                            G2Sia_codrip_trip = tmpAx.sia_codrip_trip;
                                            G2Fcm_serpos_sips = tmpAx.fcm_serpos_sips;
                                            G2Sia_tipact_tsac = String.IsNullOrWhiteSpace(G2Sia_tipact_tsac) ? tmpAx.sia_tipact_tsac : G2Sia_tipact_tsac;
                                            G2Fcm_codtse_sips = tmpAx.fcm_codtse_sips;
                                            G2Fcm_otserv_sips = tmpAx.fcm_otserv_sips;
                                            G2Fcm_forfar_sips = tmpAx.fcm_forfar_sips;
                                            G2Fcm_conmed_sips = tmpAx.fcm_conmed_sips;
                                            G2Fcm_unimed_sips = tmpAx.fcm_unimed_sips;
                                            G2Sia_codfco_fcon = tmpAx.sia_codfco_fcon;
                                            G2Sia_codfpr_fpor = tmpAx.sia_codfpr_fpro;
                                            G2Sia_codpat_tpat = tmpAx.sia_codpat_tpat;
                                            G2Fcm_codcpr_cpro = String.IsNullOrWhiteSpace(G2Fcm_codcpr_cpro) ? tmpAx.fcm_codcpr_cpro : G2Fcm_codcpr_cpro;
                                            #endregion
                                        }
                                        else
                                        {
                                            lcrValorReturn = "Código configuración servicio no relacionado en Serivicios IPS";
                                        }
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Código digitación servicio: No existe";
                            }
                        }
                        #endregion
                        break;
                        
                    case "G2Fcm_codcpr_cpro": // 003
                        #region Validacion Código centro producción
                        lcrCodigoError = "003";
                        lcrNombreCampo = "Código centro producción";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            EFfcmcenproduccio tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G2Fcm_codcpr_cpro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_descpr_cpro))
                            {
                                G2Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                                if (String.IsNullOrWhiteSpace(G2Sia_codare_aser)) { G2Sia_codare_aser = tmp.sia_codare_aser; }
                                G2Sia_codcat_ceat = tmp.sia_codcat_ceat;
                                G2Con_codsco_ccos = tmp.con_codsco_ccos;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G2Fcm_fecser_dfac": // 004
                        #region Validacion Fecha servicio
                        lcrCodigoError = "004";
                        lcrNombreCampo = "Fecha servicio";
                        lcrNivelError = "ALTO";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Fcm_fecser_dfac, "Fecha servicio");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!m.flgCargarParametrosSalarioMinimo(Convert.ToDateTime(G2Fcm_fecser_dfac)))
                            { 
                                var lnuAño = Convert.ToDateTime(G2Fcm_fecser_dfac).Year.ToString();
                                lcrValorReturn = "Fecha servicio: No existe salario minimo configurado año: " + lnuAño + " / fecha servicio: " + G2Fcm_fecser_dfac;
                            }
                       }
                        #endregion
                        break;

                    case "G2Fcm_totuni_dfac": // 005
                        #region Validacion Total unidades
                        lcrCodigoError = "005";
                        lcrNombreCampo = "Total unidades";
                        lcrNivelError = "ALTO";

                        if (G2Fcm_totuni_dfac <= 0)
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_totuni_dfac < 1 || G2Fcm_totuni_dfac > 500)
                            {
                                lcrValorReturn = "Total unidades: Valor fuera del rango";
                            }
                            else if (G2Fcm_valser_mant > 0)
                            {
                                fcvCalcularTotalServicio();
                            }
                        }
                        #endregion
                        break;

                    case "G2Fcm_codaqx_aqir": // 006
                        #region Validacion Tipo Acto Quirúrgico
                        lcrCodigoError = "006";
                        lcrNombreCampo = "Tipo Acto Quirúrgico";
                        lcrNivelError = "ALTO";

                        if (GlgSIS_ActActoQuirurgico == true)
                        {
                            if (!String.IsNullOrWhiteSpace(G2Fcm_codaqx_aqir))
                            {
                                var lcrObj = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                                if (lcrObj != null && lcrObj.fcm_codtse_sips != null)
                                {
                                    if (lcrObj.fcm_codtse_sips.Trim() == "2")
                                    {
                                        EFfcmactquirurgic tmp = new EFfcmactquirurgic();
                                        tmp = FCMValidarCodigo.fobRegBuscarFcmactquirurgic(G2Fcm_codaqx_aqir);
                                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_desaqx_aqir))
                                        {
                                            G2Fcm_desaqx_aqir = tmp.fcm_desaqx_aqir;
                                        }
                                        else
                                        {
                                            lcrValorReturn = "Tipo Acto Quirúrgico: No existe";
                                        }
                                    }
                                }
                            }
                            else 
                            {
                                lcrValorReturn = "Tipo Acto Quirúrgico: Es requerido";
                            }
                        }
                        #endregion
                        break;

                    case "G2Sia_tipact_tsac": // 007
                        #region Validacion Tipo servicio o activiad
                        lcrCodigoError = "007";
                        lcrNombreCampo = "Tipo servicio o activiad";
                        lcrNivelError = "ALTO";

                        if (String.IsNullOrWhiteSpace(G2Sia_tipact_tsac))
                        {
                            lcrValorReturn = "Tipo servicio o activiad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Sia_tipact_tsac, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatipactividad(G2Sia_tipact_tsac);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desact_tsac))
                                {
                                    G2Sia_desact_tsac = tmp.sia_desact_tsac;
                                }
                                else
                                {
                                    lcrValorReturn = "Tipo servicio o activiad: No existe";
                                }
                            }
                        }
                        #endregion
                        break;

                    case "G2Sia_codpfa_prof": // 008
                        #region Validacion Código profesional que atiende
                        lcrCodigoError = "008";
                        lcrNombreCampo = "Código profesional que atiende";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código profesional atiende: Es requerido";
                        }
                        else
                        {
                            G2Sia_codpfa_prof = G2Sia_codpfa_prof.ToUpper();

                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G2Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                            {

                                G2Sia_nompro_prof = tmp.sia_nompro_prof;
                                G2Sia_codpat_tpat = tmp.sia_codpat_tpat;
                                G2Sis_idterc_sitr = tmp.sis_idterc_sitr;
                            }
                            else
                            {
                                lcrValorReturn = "Código profesional que atiende: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G2Sia_aresol_aser": // 009
                        #region Validacion Código área solicita servicio
                        lcrCodigoError = "009";
                        lcrNombreCampo = "Código área solicita servicio";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_aresol_aser))
                        {
                            lcrValorReturn = "Código área solicita servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G2Sia_aresol_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                G2Desia_aresol_aser = tmp.sia_desare_aser;
                                if (String.IsNullOrWhiteSpace(G2Sia_codare_aser)) { G2Sia_codare_aser = tmp.sia_codare_aser; }
                            }
                            else
                            {
                                lcrValorReturn = "Código área solicita servicio: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G2Sia_codare_aser": // 010
                        #region Validacion Código área que presta el servicio
                        lcrCodigoError = "010";
                        lcrNombreCampo = "Código área que presta el servicio";
                        lcrNivelError = "ALTO";

                        if (string.IsNullOrWhiteSpace(G2Sia_codare_aser))
                        {
                            lcrValorReturn = "Código área que presta servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G2Sia_codare_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                G2Sia_desare_aser = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código área que presta servicio: No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G2Adm_nroaut_rgad":
                        #region Datos
                        lcrNombreCampo = "Numero de autorizazión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "011";
                        if (!string.IsNullOrWhiteSpace(G2Adm_nroaut_rgad))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G2Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }
                        break;
                        #endregion

                }
                LogsErrores.fcvAddLogErrores(ref TmpG2LogError, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvLimpiarVariablesValorServicio: Vaciar los valores en variables
        /// <summary>
        ///  Vaciar los valores en variables para iniciar captura 
        /// </summary>
        public void fcvLimpiarVariablesValorServicio()
        {
            G2Fcm_valser_mant = 0;
            G2Fcm_valbru_dfac = 0;
            G2Fcm_valsub_dfac = 0;
            G2Fcm_valfac_dfac = 0;
            G2Fcm_valcmo_dfac = 0;
            G2Fcm_valcpa_dfac = 0;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcualrTotServicio: calcular Valor del servicio
        //-------------------------------------------------
        #region fcvCalcularTotalServicio: calcular Valor del servico
        /// <summary>
        /// calcular Valor del servicio y porcentajes segun aplique en contrato
        /// </summary>
        public void fcvCalcularTotalServicio()
        {
            GlgSIS_EdtValorTotalServ = m.gcrSipsEditarValorServicio == "1" && gcrSIS_PerfilCmdEDT == "OK" ? true : false;
            m.Fcm_valusu_dfac = G2Fcm_valusu_dfac;
            m.Fcm_totuni_dfac = G2Fcm_totuni_dfac;

            if (m.gcrSipsEditarValorServicio == "1") // se digita el valor del servicio en pantalla
            {
                // si hay cobro de IVA 
                var lobReIVa = SISValidarCodigo.fobRegBuscarSistablaiva(m.gcrSipsCodigoPorcentajeIVA);

                #region Cargar parametros del servicio IPS
                // calcular iva
                var gflSipsPorcentajeIVA = lobReIVa.sis_poriva_tiva > 0 ? (float)lobReIVa.sis_poriva_tiva : 0;
                m.Fcm_valiva_dfac = gflSipsPorcentajeIVA > 0 ? (float)Math.Round((G2Fcm_valser_mant * gflSipsPorcentajeIVA)) : 0;
                #endregion

                G2Fcm_valser_mant = G2Fcm_valser_mant <= 0 ? m.gnuMantValorServicio : G2Fcm_valser_mant;
                G2Fcm_totuni_dfac = 1;
                m.Fcm_totuni_dfac = 1;
                m.Fcm_valcpa_dfac = 0;
                m.Fcm_valcmo_dfac = 0;
                m.Fcm_valser_mant = G2Fcm_valser_mant;
                m.Fcm_valbru_dfac = G2Fcm_valser_mant;
                m.Fcm_valsub_dfac = G2Fcm_valser_mant;
                m.Fcm_valfac_dfac = G2Fcm_valser_mant + m.Fcm_valiva_dfac;
                m.Fcm_valdes_dfac = 0;
                m.Fcm_pordes_dfac = 0;
                m.Fcm_poriva_dfac = gflSipsPorcentajeIVA;

            }
            else
            {
                // Calcualr valores
                m.fcvCalcularValorTotalServicio();
            }
            G2Fcm_valcpa_dfac = m.Fcm_valcpa_dfac;
            G2Fcm_valcmo_dfac = m.Fcm_valcmo_dfac;
            G2Fcm_valser_mant = m.Fcm_valser_mant;
            G2Fcm_valbru_dfac = m.Fcm_valbru_dfac;
            G2Fcm_valsub_dfac = m.Fcm_valsub_dfac;
            G2Fcm_valfac_dfac = m.Fcm_valfac_dfac;
            G2Fcm_valdes_dfac = m.Fcm_valdes_dfac;
            G2Fcm_pordes_dfac = m.Fcm_pordes_dfac;
            G2Fcm_valiva_dfac = m.Fcm_valiva_dfac;
            G2Fcm_poriva_dfac = m.Fcm_poriva_dfac;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcularCopagoyCmoderadoras: calcular copagos y cuotas moderadoras
        //-------------------------------------------------
        #region fcvCalcularCopagoyCmoderadoras: Calcular copagos y cuotas moderadoras
        /// <summary>
        /// Calcular Valor de los copagos y cuotas moderadoras
        /// </summary>
        public void fcvCalcularCopagoyCmoderadoras()
        {
            m.gcrAdmTipoRegimenAfiliado  = A1Adm_codtat_tatn;
            m.gcrAdmTipoAfilContributivo = A1Sia_tipafi_tafi;
            m.gcrAdmNivelContributivo    = A1Sia_nivcon_ncon;
            m.gcrAdmNivelSisben          = A1Sia_nivsbn_nsbn;
            // Ejecutar calculo copagos
            m.flgCalcularCopagoyCmoderadoras();
            // tomar los nuevos valores
            G2Fcm_valcpa_dfac = flgValidExisteCopagoCmod("1") ? 0 : m.Fcm_valcpa_dfac;
            G2Fcm_valcmo_dfac = flgValidExisteCopagoCmod("2") ? 0 : m.Fcm_valcmo_dfac;
            // Realizar calculo para descontar copago del valor servicio
            if (m.gcrContDescontarCopago == "1")
            {
                G2Fcm_valfac_dfac = m.Fcm_valfac_dfac - (G2Fcm_valcpa_dfac + G2Fcm_valcmo_dfac);
            }
        } 
        #endregion
        #region flgValidExisteCopagoCmod: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion para saber si ya exite un copago o cuota moderadora ya facturada
        /// tcrTipoCobro: 1= Copago 2= Cuota moderadora
        /// </summary>
        public bool flgValidExisteCopagoCmod(String tcrTipoCobro)
        {
            var llgReturn = true;
            var llgCopago = false;
            var llgCmoder = false;

            foreach (var lobReg in TmpG2ListaBrow)
            {
                llgCopago = lobReg.Fcm_valcpa_dfac > 0 ? true : llgCopago;
                llgCmoder = lobReg.Fcm_valcmo_dfac > 0 ? true : llgCmoder;
            }
            llgReturn = tcrTipoCobro == "1" ? llgCopago : llgCmoder;

            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia()
        {
            var llgReturn = true;

            m.gcrAdmSexoDelAfiliado      = A1Sis_codsex_sexo;
            m.gcrAdmIdUnicoUsuario       = A1Sia_idesec_usua;
            m.gcrAdmTipoRegimenAfiliado  = A1Sia_tipusu_regi;
            m.gcrAdmAmbitoAtencion       = A1Adm_codtat_tatn;
            m.gcrAdmFechaNacimiento      = A1Sia_fecnac_usua;
            m.gcrAdmFechaAdmision        = A1Adm_fecadm_rgad;
            m.gcrAdmFechaServicio        = G2Fcm_fecser_dfac;
            m.gcrAdmTipoAfilContributivo = A1Sia_tipafi_tafi;
            m.gcrAdmNivelContributivo    = A1Sia_nivcon_ncon;
            m.gcrAdmNivelSisben          = A1Sia_nivsbn_nsbn;
            m.Fcm_totuni_dfac            = G2Fcm_totuni_dfac;
            m.gnuAdmEdadEnAños           = A1Sia_edaano_usua;
            m.gnuAdmEdadEnMeses          = A1Sia_edames_usua;
            m.gnuAdmEdadEnDias           = A1Sia_edadia_usua;

            //Validar pertinencia
            llgReturn = m.flgValidacionPertinencia(ref TmpG2LogError, "PERTINENCIA");
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcvValorDefectoVariables: Valores por defecto variables de control
        //-------------------------------------------------
        #region fcvValorDefectoVariables: Valores por defecto variables de control
        /// <summary>
        /// Reiniciar los valores por defectos en las variables que controlan
        /// activacion de algunos campos y validacion de pertinencia.
        /// </summary>
        public void fcvValorDefectoVariables()
        {
            try
            {
                G2Fcm_valcmo_dfac = 0;
                G2Fcm_valcpa_dfac = 0;
                // Activar campos 
                GlgSIS_ActActoQuirurgico = false;
                GlgSIS_ActCodigoEps = false;
                m.fcvValorDefectoVariables();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvValorDefectoVar");
            }
        }
        #endregion

    }
}
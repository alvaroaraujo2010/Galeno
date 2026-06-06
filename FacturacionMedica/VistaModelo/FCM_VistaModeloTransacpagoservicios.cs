//- MARMOTA-GENCODE: VERSION 2.0 - 05/09/2013 08:44:57 AM
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
using Sistema.Clases;
using Datos.Modelos;
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmmaescajatran</para>
    /// <para>DESCRIPCION:
    ///  Maestro para almacenar los datos de recibos de cajas que se
    ///  generen en facturacion por concepto de pagos en efectivo o
    ///  en cheque de: copagos, cuotas moderadoras, pagos particulares
    ///  y otros pagos
    /// </para>
    /// </summary>
    public class VistaModeloTransacpagoservicios : VistaModeloTransacpagoserviciosBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO   { get; set; }
        public RelayCommand CmdACTVALOR { get; set; }
        public RelayCommand CmdQUITARVALOR { get; set; }
        public RelayCommand CmdAUTABRIR { get; set; }
        public RelayCommand CmdAUTSOLICITAR { get; set; }
        public RelayCommand CmdAUTELIMINAR { get; set; }
        public RelayCommand CmdAUTIMPRIMIR { get; set; }
        public RelayCommand CmdAUTLIMPIAR { get; set; }

        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO       = new RelayCommand(fcvFiltro, CanFiltro);
            CmdACTVALOR     = new RelayCommand(fcvActualizarValorDescuento, CanDescuento);
            CmdQUITARVALOR  = new RelayCommand(fcvQuitarValorDescuento, CanQitarDescuento);
            CmdAUTABRIR     = new RelayCommand(fcvAbrirAutorizacion, CanAbrirAutorizacion);
            CmdAUTSOLICITAR = new RelayCommand(fcvAutorizarDescuento, CanAutorizar);
            CmdAUTELIMINAR  = new RelayCommand(fcvEliminarAutDescuento, CanEliminarAutorizacion);
            CmdAUTIMPRIMIR  = new RelayCommand(fcvImprimirAutDescuento, CanImprimirAutorizacion);
            CmdAUTLIMPIAR   = new RelayCommand(fcvLimpiarAutDescuento, CanLimpiarAutDescuento);

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
                if (GcrSIS_FormModoPopup == "ADD")
                {
                    var lcrCodigo1 = G1Adm_secadm_rgad;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_secadm_rgad = lcrCodigo1;
                        GcrFiltroDatos = G1Adm_secadm_rgad;
                        Filtro();
                        fcrValidacion("G1Adm_secadm_rgad");
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
        #region CanDescuento
        /// <summary>
        /// Validación para saber si se permite descuento
        /// y tambien activar el boton actualizar descuento
        /// </summary>
        public bool CanDescuento()
        {
            bool llgReturn = false;
            try
            {
                if (G3Fcm_valref_dfac > 0 && GlgSIS_ModoEdicion == true && G3Fcm_pordes_dfac > 0)
                {
                    if (G4Fcm_aplcad_ades=="2" || String.IsNullOrWhiteSpace(G4Fcm_aplcad_ades)) // sin aplicar
                    {
                        if (String.IsNullOrWhiteSpace(G4Fcm_estaut_ades) || G4Fcm_estaut_ades.Trim() == "1" || G4Fcm_estaut_ades.Trim() == "2")
                        {
                            llgReturn = true;
                        }
                    }
                    if (G3Fcm_poraux_dfac > 0 && G3Fcm_valdes_dfac == 0) { llgReturn = false; }
                    if (G3Fcm_pordes_dfac > 100) { llgReturn = false; }
                    
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDescuento");
            }
            return llgReturn;
        }
        #endregion
        #region CanQitarDescuento
        /// <summary>
        /// Validación para saber si se permite activar la opcion quitar descuento aplicado a en la orden activa
        /// </summary>
        public bool CanQitarDescuento()
        {
            bool llgReturn = false;
            try
            {
                if (G3Fcm_valref_dfac > 0 && GlgSIS_ModoEdicion == true)
                {
                    if (G4Fcm_aplcad_ades == "2" || String.IsNullOrWhiteSpace(G4Fcm_aplcad_ades)) // sin aplicar
                    {
                        if (String.IsNullOrWhiteSpace(G4Fcm_estaut_ades) || G4Fcm_estaut_ades.Trim() == "1" || G4Fcm_estaut_ades.Trim() == "2")
                        {
                            llgReturn = true;
                        }
                        if (TmpG3RegActivo.Fcm_pordes_dfac > 0 || G3Fcm_pordes_dfac > 0) { llgReturn = true; }
                    }
                    if (TmpG3RegActivo.Fcm_pordes_dfac <= 0 && G3Fcm_pordes_dfac <= 0) { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDescuento");
            }
            return llgReturn;
        }
        #endregion
        #region CanAbrirAutorizacion
        /// <summary>
        /// Validación para activar la opcion del menu
        /// que permite buscar una autorizacion ya existente.
        /// </summary>
        public bool CanAbrirAutorizacion()
        {
            bool llgReturn = false;
            try
            {
                llgReturn = GlgSIS_ModoEdicion;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanAbrirAutorizacion");
            }
            return llgReturn;
        }
        #endregion
        #region CanAutorizar
        /// <summary>
        /// Validación para saber si se permite autorizar descuento
        /// y tambien activar el boton autorizar descuentos
        /// </summary>
        public bool CanAutorizar()
        {
            bool llgReturn = false;
            try
            {
                G4FMsgError = String.Empty;
                if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades) && GlgSIS_ModoEdicion == true)
                {
                    var lcrFcm_desest_ades = String.IsNullOrWhiteSpace(G4Fcm_desest_ades) ? "ABIERTA" : G4Fcm_desest_ades;
                    G4Fcm_aplcad_ades = "";
                    G4Fcm_desest_ades = "";
                    if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades))
                    {
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmdescueautori(G4Fcm_autdes_ades.Trim());
                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_autdes_ades))
                        {
                            #region Cargar Valores desde tabla
                            G4Fcm_autdes_ades = tmp.fcm_autdes_ades;
                            G4Adm_secadm_rgad = tmp.adm_secadm_rgad;
                            G4Sia_idesec_usua = tmp.sia_idesec_usua;
                            G4Sia_nroide_usua = tmp.sia_nroide_usua;
                            G4Fcm_fecsol_ades = ((DateTime)tmp.fcm_fecsol_ades).ToShortDateString();
                            G4Fcm_horsol_ades = Funciones.fcrConvierteHora(tmp.fcm_horsol_ades.ToString(), "24", gcrSeparadorDecimal, ":");
                            G4Fcm_fecaut_ades = ((DateTime)tmp.fcm_fecaut_ades).ToShortDateString();
                            G4Fcm_horaut_ades = Funciones.fcrConvierteHora(tmp.fcm_horaut_ades.ToString(), "24", gcrSeparadorDecimal, ":");
                            G4Fcm_valref_dfac = (float)tmp.fcm_valref_dfac;
                            G4Fcm_valdes_ades = (float)tmp.fcm_valdes_ades;
                            G4Fcm_valdes_dfac = (float)tmp.fcm_valdes_dfac;
                            G4Fcm_pordes_dfac = (float)tmp.fcm_pordes_dfac;
                            G4Fcm_valefe_dfac = (float)tmp.fcm_valefe_dfac;
                            G4Fcm_notaut_ades = tmp.fcm_notaut_ades;
                            G4Sys_ususol_usux = tmp.sys_ususol_usux;
                            G4Sys_codusu_usux = tmp.sys_codusu_usux;
                            G4Fcm_aplcad_ades = tmp.fcm_aplcad_ades;
                            G4Fcm_estaut_ades = tmp.fcm_estaut_ades;
                            #endregion
                            if (tmp.fcm_estaut_ades == "1")
                            {
                                G4Fcm_desest_ades = "ABIERTA";
                            }
                            else if (tmp.fcm_estaut_ades == "2")
                            {
                                G4Fcm_desest_ades = "AUTORIZADA";

                            }
                            else if (tmp.fcm_estaut_ades == "3")
                            {
                                G4Fcm_desest_ades = "APLICADA";
                            }
                            else
                            {
                                G4Fcm_desest_ades = "NEGADA";
                            }
                        }
                    }
                    if (lcrFcm_desest_ades != G4Fcm_desest_ades && !String.IsNullOrWhiteSpace(G4Fcm_desest_ades) && G4Fcm_desest_ades.Trim() == "AUTORIZADA")
                    {
                        fcrValidacion("G1Fcm_valdes_dfac");
                        MessageBox.Show("Autorización:" + G4Fcm_desest_ades);
                    }
                }
                //- Para activar el Boton
                if (G1Fcm_valdes_dfac > 0 && String.IsNullOrWhiteSpace(G1Fcm_codtra_mtrc))
                {
                    llgReturn = true;
                }
                if (G1Fcm_valdes_dfac != G4Fcm_valdes_dfac)
                {
                    String lcrNumeroRegistro = "USUARIO";
                    String lcrCodigoError = "E01";
                    String lcrNombreCampo = "Valor descuento autorizado";
                    String lcrNivelError = "ALTO";
                    String lcrImgNivelError = "Edt_hist_vista_anulado.png";

                    G4FMsgError = "Valor Autorizado (" + G4Fcm_valdes_dfac.ToString() + ") no igual a sumatoria descuentos (" + G1Fcm_valdes_dfac.ToString()+")"+
                                " diferencia (" + (G4Fcm_valdes_dfac - G1Fcm_valdes_dfac).ToString()+")";

                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                 lcrNombreCampo, G4FMsgError, lcrNivelError, lcrImgNivelError);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanAutorizar");
            }
            return llgReturn;
        }
        #endregion
        #region CanEliminarAutorizacion
        /// <summary>
        ///Validación para saber si se permite descuento
        /// y tambien activar el boton actualizar descuento
        /// </summary>
        public bool CanEliminarAutorizacion()
        {
            bool llgReturn = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades) && G4Fcm_desest_ades == "ABIERTA")
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDescuento");
            }
            return llgReturn;
        }
        #endregion
        #region CanImprimirAutorizacion
        /// <summary>
        /// Imprimir Autorizacion descuento activa
        /// </summary>
        public bool CanImprimirAutorizacion()
        {
            bool llgReturn = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades))
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanImprimirAutorizacion");
            }
            return llgReturn;
        }
        #endregion
        #region CanLimpiarAutDescuento
        /// <summary>
        /// Limpiar Autorizacion descuento activa
        /// </summary>
        public bool CanLimpiarAutDescuento()
        {
            bool llgReturn = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades) && GlgSIS_ModoEdicion==true)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanLimpiarAutDescuento");
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
        #region fcvActualizarValorDescuento: Actualizar el valor del descuento cuando aplique
        /// <summary>
        /// Actualizar el valor del descuento cuando aplique
        /// </summary>
        public void fcvActualizarValorDescuento()
        {
            try
            {
                if (TmpG3ListaBrow.Count > 0)
                {
                    var llgEncontrado = false;
                    G4Fcm_valref_dfac = 0;
                    G4Fcm_valdes_ades = 0;
                    G4Fcm_valdes_dfac = 0;
                    G4Fcm_pordes_dfac = 0;
                    G4Fcm_valefe_dfac = 0;
                    G1Fcm_valref_dfac = 0;
                    G1Fcm_valdes_dfac = 0;
                    G1Fcm_valefe_dfac = 0;
                    foreach (FcmModeloMaestrofacturas lobReg in TmpG3ListaBrow)
                    {
                        if (lobReg.Fcm_secreg_mfac == G3Fcm_secreg_mfac && llgEncontrado==false)
                        {
                            lobReg.Fcm_pordes_dfac = G3Fcm_pordes_dfac;
                            lobReg.Fcm_valdes_dfac = G3Fcm_valdes_dfac;
                            lobReg.Fcm_valefe_dfac = G3Fcm_valefe_dfac;
                            lobReg.Fcm_tipdes_mfac = G3Fcm_tipdes_mfac;
                            lobReg.Sis_estado_imaen = "M";
                            llgEncontrado = true;
                        }
                        G1Fcm_valref_dfac += lobReg.Fcm_valref_dfac;
                        G1Fcm_valdes_dfac += lobReg.Fcm_valdes_dfac;
                        G1Fcm_valefe_dfac += lobReg.Fcm_valefe_dfac;
                    }
                    G4Fcm_valref_dfac = G1Fcm_valref_dfac;
                    G4Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                    G4Fcm_valdes_ades = G1Fcm_valdes_dfac;
                    G4Fcm_valefe_dfac = G1Fcm_valefe_dfac;
                    if (G4Fcm_valdes_dfac > 0)
                    {
                        G4Fcm_pordes_dfac = (G4Fcm_valdes_dfac * 100) / G4Fcm_valref_dfac; // ojo falta el redondeo
                    }
                    fcrValidacion("G1Fcm_valefe_mtrc");
                    // Limpar la vista gestion descuento de nuevo
                    G3Fcm_poraux_dfac = 0;
                    fcvCalcularValorDescuento();
                    fcrValidacion("G1Fcm_valdes_dfac");
                    fcrValidacion("G4Fcm_valdes_dfac");
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvActualizarFechafactura");
            }
        }
        #endregion
        #region fcvQuitarValorDescuento: Quitar valor del descuento cuando aplique
        /// <summary>
        /// Actualizar el valor del descuento cuando aplique
        /// </summary>
        public void fcvQuitarValorDescuento()
        {
            G3Fcm_poraux_dfac = 0;
            fcvCalcularValorDescuento();
            fcvActualizarValorDescuento();
        }
        #endregion
        #region fcvAbrirAutorizacion: Abrir o buscar autorizacion existente
        /// <summary>
        /// Abrir o buscar autorizacion existente
        /// </summary>
        public void fcvAbrirAutorizacion()
        {
            // Datos
        }
        #endregion
        #region fcvAutorizarDescuento: Generar Autorización descuento cuando aplique
        /// <summary>
        /// Generar autorización descuento cuando aplique
        /// </summary>
        public void fcvAutorizarDescuento()
        {
            try
            {
                // Preguntar si generar autorizacion descuento
                if (MessageBox.Show("Generar Solicitud de descuento?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    fcvCargarRegActivoDesdeVariables("4");
                    if (String.IsNullOrWhiteSpace(G4Fcm_autdes_ades))
                    {
                        TmpG4RegActivo.Fcm_autdes_ades = ModeloAutorizarDescuento.flgAddRegistro(TmpG4RegActivo);
                        G4Fcm_autdes_ades = TmpG4RegActivo.Fcm_autdes_ades;
                    }
                    else
                    {
                        ModeloAutorizarDescuento.fcvActualizar(TmpG4RegActivo);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAutorizarDescuento");
            }
        }
        #endregion
        #region fcvEliminarAutDescuento: Eliminar registro autorización descuento
        /// <summary>
        /// Eliminar Registro registro Autorización Descuento activo
        /// </summary>
        public virtual void fcvEliminarAutDescuento()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar registro Autorización Descuento?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ModeloAutorizarDescuento.fcvEliminar(TmpG4RegActivo.Fcm_autdes_ades);
                    fcvReiniVariables("4");
                    fcvSuamtoriaValorEnEfectivo(); 
                    fcvRetomarValoresDescuento();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvEliminarAutDescuento");
            }
        }
        #endregion
        #region fcvImprimirAutDescuento: Imprimir registro autorización descuento
        /// <summary>
        /// Eliminar Registro registro Autorización Descuento activo
        /// </summary>
        public virtual void fcvImprimirAutDescuento()
        {
            try
            {
                if (MessageBox.Show("Desea Imprimir registro Autorización Descuento?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //Imprimir();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvImprimirAutDescuento");
            }
        }
        #endregion
        #region fcvLimpiarAutDescuento: Limpiar vista registro autorización descuento
        /// <summary>
        /// Limpiar vista registro autorización descuento
        /// </summary>
        public virtual void fcvLimpiarAutDescuento()
        {
            try
            {
                if (MessageBox.Show("Desea limpiar la vida registro Autorización Descuento?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    fcvReiniVariables("4");
                    fcvRetomarValoresDescuento();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvLimpiarAutDescuento");
            }
        }
        #endregion
        #region fcvCalcularValorDescuento: Calcular valor descuento
        /// <summary>
        /// Calcular valor descuento
        /// </summary>
        public void fcvCalcularValorDescuento()
        {
            try
            {
                G3Fcm_pordes_dfac = 0;
                G3Fcm_valdes_dfac = 0;
                G3Fcm_valefe_dfac = 0;
                if (G3Fcm_tipdes_mfac == "1") // Porcentaje Descuento
                {
                    if (G3Fcm_poraux_dfac > 0 && G3Fcm_valref_dfac > 0) 
                    {
                        G3Fcm_poraux_dfac = (float)Math.Round(G3Fcm_poraux_dfac, 2);
                        G3Fcm_valdes_dfac = (float)Math.Round(((G3Fcm_valref_dfac * G3Fcm_poraux_dfac) / 100),0);
                        G3Fcm_pordes_dfac = G3Fcm_poraux_dfac;
                        G3Fcm_valefe_dfac = G3Fcm_valref_dfac - G3Fcm_valdes_dfac;

                    }
                }
                else if (G3Fcm_tipdes_mfac == "2") // Valor descuento
                {
                    if (G3Fcm_poraux_dfac > 0 && G3Fcm_valref_dfac > 0)
                    {
                        G3Fcm_poraux_dfac = (float)Math.Round(G3Fcm_poraux_dfac, 0);
                        G3Fcm_valdes_dfac = G3Fcm_poraux_dfac;
                        G3Fcm_pordes_dfac = (float)Math.Round(((G3Fcm_poraux_dfac * 100) / G3Fcm_valref_dfac),2);
                        G3Fcm_valefe_dfac = G3Fcm_valref_dfac - G3Fcm_valdes_dfac;
                    }
                }
                else if (G3Fcm_tipdes_mfac == "3") // Valor Rebajado con el desucento
                {
                    if (G3Fcm_poraux_dfac > 0 && G3Fcm_valref_dfac > 0)
                    {
                        G3Fcm_poraux_dfac = (float)Math.Round(G3Fcm_poraux_dfac, 0);
                        G3Fcm_valdes_dfac = G3Fcm_valref_dfac - G3Fcm_poraux_dfac;
                        G3Fcm_pordes_dfac = (float)Math.Round(((G3Fcm_valdes_dfac * 100) / G3Fcm_valref_dfac),2);
                        G3Fcm_valefe_dfac = G3Fcm_poraux_dfac;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCalcularValorDescuento");
            }
        }
        #endregion
        #region fcvRetomarValoresDescuento: Retoma los valores que estan en descuentos
        /// <summary>
        /// Carga los valores de sumatoria en descuentos realizados en cada orden de 
        /// servicio y los carga en las variables para la gestion descuento.
        /// </summary>
        public void fcvRetomarValoresDescuento()
        {
            try
            {
                G4Fcm_valref_dfac = G1Fcm_valref_dfac;
                G4Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                G4Fcm_valdes_ades = G1Fcm_valdes_dfac;
                G4Fcm_valefe_dfac = G1Fcm_valefe_dfac;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvRetoamrValoresDescuento");
            }
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
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgOpcionDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Adm_secadm_rgad":
                        if (!string.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                            if (tmp != null)
                            {
                                G1Adm_secadm_rgad = tmp.adm_secadm_rgad;
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                            }
                        }
                        break;

                    case "G1Fcm_descon_mtrc":
                        lcrNombreCampo = "Concepto del pago";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";

                        if (String.IsNullOrWhiteSpace(G1Fcm_descon_mtrc))
                        {
                            lcrValorReturn = "Concepto del pago: Es requerido";
                        }
                        break;

                    case "G1Fcm_rfecha_mtrc":

                        lcrNombreCampo = "Fecha del recibo caja";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";

                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_rfecha_mtrc, lcrNombreCampo);
                        break;

                    case "G1Fcm_rehora_mtrc":

                        lcrNombreCampo = "Hora del recibo caja";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";

                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Fcm_rehora_mtrc, "12", ":", lcrNombreCampo);
                        break;

                    case "G1Fcm_valdes_dfac":

                        lcrNombreCampo = "Valor descuento calculado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        if (G1Fcm_valdes_dfac > 0 )
                        {
                            /*
                            if (String.IsNullOrWhiteSpace(G4Fcm_autdes_ades))
                            {
                                lcrValorReturn = "Debe existir un numero de autorización para el descuento";
                            }
                            else if (G4Fcm_desest_ades.Trim() != "AUTORIZADA")
                            {
                                lcrValorReturn = "Estado de la autorización no es valido para aplicar el descuento";
                            }
                            else if (G4Fcm_aplcad_ades.Trim() != "2")
                            {
                                lcrValorReturn = "Autorización ya fue aplicada en algun otro descuento";
                            }
                            else if (G1Fcm_valdes_dfac != G4Fcm_valdes_dfac)
                            {
                                lcrValorReturn = "Valor Autorizado (" + G4Fcm_valdes_dfac.ToString() + ") no igual a sumatoria descuentos (" + G1Fcm_valdes_dfac.ToString() + ")" +
                                                 " diferencia (" + (G4Fcm_valdes_dfac - G1Fcm_valdes_dfac).ToString() + ")";
                            }
                            */
                        }
                        break;



                    case "G4Fcm_valdes_dfac":

                        lcrNombreCampo = "Valor descuento autorizado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E01";
                        if (G4Fcm_valdes_dfac > 0)
                        {
                            /*
                            if (G1Fcm_valdes_dfac != G4Fcm_valdes_dfac)
                            {
                                lcrValorReturn = "Valor Autorizado (" + G4Fcm_valdes_dfac.ToString() + ") no igual a sumatoria descuentos (" + G1Fcm_valdes_dfac.ToString() + ")" +
                                                 " diferencia (" + (G4Fcm_valdes_dfac - G1Fcm_valdes_dfac).ToString() + ")";
                            }
                            */
                        }
                        break;

                    case "G1Fcm_valefe_mtrc":

                        lcrNombreCampo = "Valor en efectivo para transacción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        if (G1Fcm_valefe_mtrc > 0)
                        {
                            G1Fcm_valcam_mtrc = (int)(G1Fcm_valefe_mtrc - G1Fcm_valefe_dfac);
                            if (G1Fcm_valefe_mtrc < G1Fcm_valefe_dfac)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser igual o mayor que: " + G1Fcm_valefe_dfac.ToString();
                            }
                        }
                        else 
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        break;
                }
                if (!llgOpcionDefault)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
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
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G3Fcm_tipdes_mfac": // Tipo calculo descuento 
                        fcvCalcularValorDescuento();
                        break;

                    case "G3Fcm_poraux_dfac": // Porcentaje de descuento o valor

                            lcrNombreCampo = "Porcentaje o valor descuento";
                            lcrValorReturn = String.Empty;
                            lcrCodigoError = "B02";

                            var llgCalcular = true;
                            G3Fcm_valdes_dfac = 0;
                            G3Fcm_pordes_dfac = 0;
                            G3Fcm_valefe_dfac = 0;
                            if (G3Fcm_tipdes_mfac == "1") // Porcentaje Descuento
                            {
                                if (G3Fcm_poraux_dfac > 100 || G3Fcm_poraux_dfac < 0)
                                {
                                    lcrValorReturn = "Porcentaje para calcular descuento errado";
                                    llgCalcular = false;
                                }
                            }
                            else if (G3Fcm_tipdes_mfac == "2") // Valor descuento
                            {
                                if (G3Fcm_poraux_dfac > G3Fcm_valref_dfac || G3Fcm_poraux_dfac < 0)
                                {
                                    lcrValorReturn = "Valor del descuento errado";
                                    llgCalcular = false;
                                }
                            }
                            else if (G3Fcm_tipdes_mfac == "3") // Valor Rebajado con el desucento
                            {
                                if (G3Fcm_poraux_dfac >= G3Fcm_valref_dfac || G3Fcm_poraux_dfac < 0)
                                {
                                    lcrValorReturn = "Valor a pagar con descuento realizado errado";
                                    llgCalcular = false;
                                }
                            }
                            if (llgCalcular == true)
                            {
                                fcvCalcularValorDescuento();
                            }
                        break;
                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
    }
}
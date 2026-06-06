using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
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
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using GestorReportes.VistaModelo;
using Sistema.Utilidades;
using Sistema.Modelo;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using Reportes.Utilidades;

namespace GestorReportes.Utilidades
{
    public class XmlEntornoEdicion : XmlEntorno
    {
        public string gcrModoEdicionPlantilla = "EDT"; // ADD/EDT
        public XmlEntornoEdicion()
        {
            //- codigo de gestion
        }
        //---------------------------------------------------------------
        // ABRIR GUARDAR IMPORTAR Y EXPORTAR
        //---------------------------------------------------------------
        #region flgDialogoBuscarPlantilla: Dialogo Buscar plantilla
        public bool flgDialogoBuscarPlantilla()
        {
            var llgReturn = false;
            gcrTipoOrigenArchivo = "ARCHIVO";
            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title = "Buscar plantillas de reporte...";
            lopenFileDialog.Filter = "Buscar plantilla de reporte |*.xml";
            lopenFileDialog.DefaultExt = ".xml"; // Extencion de archivos
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;

            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                fcvGestionReiniciarValriables();
                gcrXmlDocument            = lopenFileDialog.FileName;
                gcrImportArchivoDatos     = String.Empty;
                gcrImportArchivoPlantilla = gcrXmlDocument;
                gcrPlantillaNombreArchivo = lopenFileDialog.SafeFileName;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgDialogoExportarPlantilla: Dialogo Exportar plantilla
        public bool flgDialogoExportarPlantilla()
        {
            var llgReturn = false;
            SaveFileDialog lsaveFileDialog = new SaveFileDialog();
            lsaveFileDialog.Title = "Exportar Plantillas de Reporte...";
            lsaveFileDialog.Filter = "Exportar Plantilla de Reporte  (.xml)|*.xml|All Files (*.*)|*.*";
            lsaveFileDialog.DefaultExt = ".xml"; // Extencion de archivos
            lsaveFileDialog.FilterIndex = 1;
            bool? llgSelectOK = lsaveFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                gcrXmlNombreArchivo = lsaveFileDialog.FileName;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region fcvExportarPlantilla: Exportar la plantilla
        public void fcvExportarPlantilla()
        {
            if (!string.IsNullOrEmpty(gcrXmlNombreArchivo))
            {
                var lcrPlantilla = fcrGenerarTextoXmlPlantilla();
                System.IO.File.WriteAllText(@gcrXmlNombreArchivo, lcrPlantilla);
            }
        }
        #endregion
        // Abrir y Guardar datos desde base de datos
        #region flgBDatosBuscarPlantilla: Buscar plantilla en Base de datos
        /// <summary>
        /// <para>Abre la version de la plantilla por defecto</para>
        /// </summary>
        public bool flgBDatosBuscarPlantilla(String tcrCodigoPlantilla)
        {
            gcrTipoOrigenArchivo        = "BDATOS";
            gcrModoEdicionPlantilla     = "EDT";
            gcrImportArchivoPlantilla   = String.Empty;

            var llgReturn = false;
            var lobRegPlantilla = ModeloPlantilla.flsListaGrpmaeplantilla(tcrCodigoPlantilla);

            if (lobRegPlantilla != null)
            {
                if (lobRegPlantilla.Count == 0) { return llgReturn; }
                fcvGestionReiniciarValriables();
                var lobRegistro = lobRegPlantilla.FirstOrDefault();
                // Cargar los datos Digitados del registro tcrCodigoRegHistorial
                gcrImportArchivoDatos     = String.Empty;
                gcrImportArchivoPlantilla = lobRegistro.Grp_xmlpla_grpv;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgBDatosBuscarPlantillaVersion: Buscar plantilla en Base de datos por version
        /// <summary>
        /// <para>Abre la version plantilla dada en el parametro</para>
        /// </summary>
        public bool flgBDatosBuscarPlantillaVersion(String tcrCodigoVersionPlantilla)
        {
            gcrTipoOrigenArchivo = "BDATOS";
            gcrModoEdicionPlantilla = "EDT";
            gcrImportArchivoPlantilla = String.Empty;

            var llgReturn = false;
            var lobRegPlantilla = VersionPlantilla.flsBuscarVersionPlantilla(tcrCodigoVersionPlantilla);

            if (lobRegPlantilla != null)
            {
                if (lobRegPlantilla.Count == 0) { return llgReturn; }

                fcvGestionReiniciarValriables();
                var lobRegistro = lobRegPlantilla.FirstOrDefault();
                // Cargar los datos Digitados del registro tcrCodigoRegHistorial
                gcrImportArchivoDatos = String.Empty;
                gcrImportArchivoPlantilla = fcrStringXmlCargarPlantilla(lobRegistro);
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgMostrarVistaPlantilla: Cargar vista de la plantilla
        /// <summary>
        /// <para>Muestra en pantalla la vista de la plantilla</para>
        /// </summary>
        public bool flgMostrarVistaPlantilla()
        {
            var llgReturn = true;

            if (!string.IsNullOrEmpty(gcrImportArchivoPlantilla))
            {
                llgReturn = true;
                XmlElement lobXmlPlantilla = null;
                if (gcrTipoOrigenArchivo == "BDATOS") // desde base de datos
                {
                    gobXml.LoadXml(gcrImportArchivoPlantilla);
                    lobXmlPlantilla = gobXml.DocumentElement;
                }
                else
                {
                    gobXml.Load(gcrImportArchivoPlantilla);
                    lobXmlPlantilla = gobXml.DocumentElement;
                }

                //- Cargar paginas y objetos 
                tmpPlantilla = new List<XmlPropPlantilla>();
                tmpEtiquetas = new List<ClassXmlItemEtiquetas>();
                tmpSecciones = new List<ClassXmlComboBoxItems>();
                gduMinimoAnchoPlantilla = 20;
                refTreeObj.Plantilla = gobRefPlantillaEscritorio;
                refTreeObj.NivelObjetoSelect = 1;
                refTreeObj.Navegador = "ESCRITORIO";

                fcvRegCargarXMLPlantilla(lobXmlPlantilla, "ESCRITORIO", "EDICION-ESCRITORIO");
                fobRegCargarXMLSecciones(lobXmlPlantilla);
                fcvEdtAccionReAsiganarCodigoSeccionObjetos();
                fcvRegCargarXMLEtiquetas(lobXmlPlantilla);
                fcvRegCargarXMLPaginas(lobXmlPlantilla);
                fcvRegCargarXMLImgPredefinidas(lobXmlPlantilla);
                fcvEdtCamposTablasReAsiganar();

            }
            return llgReturn;
        }
        #endregion
        #region flgBDatosGuardarRegistroDatos: Gaurdar datos en la base de datos
        /// <summary>
        /// <para>Guardar en base de datos los cambios realizados en registro activo</para>
        /// </summary>
        public bool flgBDatosGuardarRegistroDatos()
        {
            var llgReturn = false;
            var lobRegistro = new ModeloPlantilla();
            var lobRegPlantilla = new List<ModeloPlantilla>();
            if (gcrModoEdicionPlantilla == "EDT")
            {
                // Actualizar maestro plantilla
                lobRegPlantilla             = ModeloPlantilla.flsListaGrpmaeplantilla(gcrPlantillaCodigoPlantilla);
                lobRegistro                 = lobRegPlantilla.FirstOrDefault();
                lobRegistro.Grp_conobj_grpl = gnuPlantillaGenerSecObjeto;
                lobRegistro.Grp_despla_grpl = gcrPlantillaNombreTitulo;
                lobRegistro.Grp_prefij_grpl = gcrPlantillaPrefijoObjetos;
                llgReturn = true;
                ModeloPlantilla.fcvActualizar(lobRegistro);

                // Actualizar la version que esta en uso (por defecto) para plantilla
                var lobRegVersion = VersionPlantilla.flsBuscarVersionPlantilla(lobRegistro.Grp_idepla_grpv).FirstOrDefault();
                var lcrTextoXml = fcrGenerarTextoXmlPlantilla();
                var lobRegAux   =  fcrStringXmlDividirTextoPlantilla(lcrTextoXml);

                lobRegVersion.Grp_xmlpla_grpv = lobRegAux.Grp_xmlpla_grpv;
                lobRegVersion.Grp_xmlplb_grpv = lobRegAux.Grp_xmlplb_grpv;
                lobRegVersion.Grp_xmlplc_grpv = lobRegAux.Grp_xmlplc_grpv;
                lobRegVersion.Grp_xmlpld_grpv = lobRegAux.Grp_xmlpld_grpv;

                VersionPlantilla.fcvActualizar(lobRegVersion);

                // Guardar referencias secciones y campos en tablas
                flgGuardarRefSeccionesPlantilla();
                flgGuardarRefCamposSeccionesPlantilla(lobRegistro.Grp_idepla_grpv);
                flgGuardarRefCamposResolucion4505(lobRegistro.Grp_idepla_grpv);
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarRefSeccionesPlantilla: Guardar en tabla las referencias a las secciones 
        /// <summary>
        /// <para>Guardar en tabla las referencias a las secciones de la version plantilla</para>
        /// </summary>
        public bool flgGuardarRefSeccionesPlantilla()
        {
            bool llgReturn = true;
            int lnuContador = 0;
            var lobjRegistro = new ModeloGrpplantvistsec();
            var lobCodigoVersion = tmpPlantilla.FirstOrDefault().VersionPlantilla;

            // Eliminar registros existentes en tabla
            ModeloGrpplantvistsec.fcvEliminar(lobCodigoVersion);

            // Generar nuevos registros
            foreach (var lobItem in tmpSecciones)
            {
                lnuContador++;
                lobjRegistro = new ModeloGrpplantvistsec();
                #region cargar Registro
                lobjRegistro.Grp_idesec_grse = "R" + lnuContador.ToString().Trim();
                lobjRegistro.Grp_idepla_grpv = lobCodigoVersion;
                lobjRegistro.Grp_idepla_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                lobjRegistro.Grp_codsec_grse = lobItem.Codigo;
                lobjRegistro.Grp_dessec_grse = lobItem.Descripcion;
                lobjRegistro.Grp_ordvis_grse = Convert.ToInt32(lobItem.IntOrden);
                lobjRegistro.Grp_numcol_grse = Convert.ToInt32(lobItem.IntTotalColumnas);
                lobjRegistro.Grp_titvis_grse = "1"; // Visible por defecto
                lobjRegistro.Sis_estado_imaen = "A"; // Agregar nuevo siempre
                #endregion
                // guardar en tabla 
                ModeloGrpplantvistsec.fcvActualizar(lobjRegistro, lobCodigoVersion);
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarRefCamposSeccionesPlantilla: Guardar referencias objetos y campos en secciones
        /// <summary>
        /// <para>Guardar las referencias de objetos y campos en secciones de la version plantilla</para>
        /// </summary>
        public bool flgGuardarRefCamposSeccionesPlantilla(String tcrCodigoVersion)
        {
            bool llgReturn = true;
            int lnuContador = 0;
            var lobjRegistro = new ModeloGrpplantvistcam();
            //var lobCodigoVersion = tmpPlantilla.FirstOrDefault().VersionPlantilla;

            // Eliminar registros existentes en tabla
            ModeloGrpplantvistcam.fcvEliminar(tcrCodigoVersion);

            // Generar nuevos registros
            foreach (var lobItem in tmpObjetos)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.Binding) && !String.IsNullOrWhiteSpace(lobItem.BindingTabla))
                {

                    lnuContador++;
                    lobjRegistro = new ModeloGrpplantvistcam();

                    // Por si estan vacios 
                    lobItem.OrdenVista = String.IsNullOrWhiteSpace(lobItem.OrdenVista) ? "0" : lobItem.OrdenVista;
                    lobItem.SeccionCodigo = String.IsNullOrWhiteSpace(lobItem.SeccionCodigo) ? "01" : lobItem.SeccionCodigo;

                    // Cargar los datos
                    #region cargar Registro
                    lobjRegistro.Grp_idereg_grob = "R" + lnuContador.ToString().Trim();
                    lobjRegistro.Grp_idepla_grpv = tcrCodigoVersion;
                    lobjRegistro.Grp_idepla_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                    lobjRegistro.Grp_nomobj_grob = lobItem.Name;
                    lobjRegistro.Grp_desobj_grob = lobItem.Titulo.Trim().Length > 150 ? lobItem.Titulo.Substring(0, 150) : lobItem.Titulo.Trim();
                    lobjRegistro.Grp_varobj_grob = lobItem.NombreVariable;
                    lobjRegistro.Grp_claseb_grob = lobItem.ClaseBase;
                    lobjRegistro.Grp_claseg_grob = lobItem.TipoObjeto;
                    lobjRegistro.Grp_codsec_grse = lobItem.SeccionCodigo;
                    lobjRegistro.Grp_ordvis_grob = (int)Convert.ToInt32(lobItem.OrdenVista);
                    lobjRegistro.Hcl_nomcam_hccm = lobItem.Binding;
                    lobjRegistro.Hcl_camdes_hccm = lobItem.BindingDescripcion;
                    lobjRegistro.Hcl_nomvar_hcvr = lobItem.VariablePublica;
                    lobjRegistro.Grp_repcam_grob = lobItem.CampoReporte;
                    lobjRegistro.Sis_estado_imaen = "A"; // Agregar nuevo siempre
                    #endregion
                    // guardar en tabla 
                    ModeloGrpplantvistcam.fcvActualizar(lobjRegistro, tcrCodigoVersion);
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarRefCamposResulucion4505: Guardar referencias campos que generan datos 4505
        /// <summary>
        /// <para>Guardar en tabla Sptabcamposplan referencias de campos que generan datos para Resolucion 4505</para>
        /// </summary>
        public bool flgGuardarRefCamposResolucion4505(String tcrCodigoVersion)
        {
            bool llgReturn = true;
            int lnuContador = 0;
            var lobjRegistro = new ModeloSptabcamposplan(); // ojo -aqui 
            // Eliminar registros existentes en tabla
            ModeloSptabcamposplan.fcvEliminar(tcrCodigoVersion); // ojo -aqui

            // Generar nuevos registros
            foreach (var lobItem in tmpObjetos)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.Binding) && !String.IsNullOrWhiteSpace(lobItem.BindingTabla))
                {
                    if (lobItem.RefVarDatosTipo == "RE4505")
                    {
                        lnuContador++;
                        lobjRegistro = new ModeloSptabcamposplan(); // ojo -aqui

                        // Cargar los datos
                        #region cargar Registro
                        lobjRegistro.Ssp_secreg_sscp = "R" + lnuContador.ToString().Trim(); // ojo -aqui
                        lobjRegistro.Grp_idepla_grpv = tcrCodigoVersion;
                        lobjRegistro.Grp_idepla_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                        lobjRegistro.Hcl_nomcam_hccm = lobItem.Binding.ToUpper();
                        lobjRegistro.Ssp_codcam_resc = lobItem.RefVarDatosCampo.ToUpper(); // RefVarDatosCampo referencia un campo tipo 4505
                        lobjRegistro.Ssp_estreg_sscp = "1";
                        lobjRegistro.Sis_estado_imaen = "A"; // Agregar nuevo siempre
                        #endregion
                        // guardar en tabla 
                        ModeloSptabcamposplan.fcvActualizar(lobjRegistro, tcrCodigoVersion); // ojo -aqui
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        //- GESTION EDICION MODIFICAR, ELIMINAR OBJETOS O RESTAURAR 
        //------------------------------------------------------------
        #region fobEdtAccionEliminarItemComboBox : Eliminar los item de un combobox
        /// <summary>
        /// <para>Eliminar registros del temporal dado en tcrTmpArchivo</para>
        /// <para>tcrArchivoOrigen: "OBJETOS" / "ELIMINADOS" </para>
        /// <para>Mueve al temporal relacionado: tmpComboItems -> tmpComboItemsEliminado / tmpComboItemsEliminado -> tmpComboItems</para>
        /// <para>la funcion retorna una copia de los registros movidos segun el tree del objeto dado en parametro</para>
        /// </summary>
        public List<ClassXmlComboBoxItems> fobEdtAccionEliminarItemComboBox(String tcrArchivoOrigen, String tcrObjeto)
        {
            List<ClassXmlComboBoxItems> lcrQuery = null;
            lcrQuery = fobRegSelectParenItemTreeComboBox(tcrArchivoOrigen, tcrObjeto);

            if (lcrQuery != null)
            {
                foreach (ClassXmlComboBoxItems lobReg in lcrQuery)
                {
                    if (!String.IsNullOrWhiteSpace(lobReg.Descripcion))
                    {
                        if (tcrArchivoOrigen == "OBJETOS")
                        {
                            tmpComboItemsEliminado.Add(lobReg);
                            tmpComboItems.Remove(lobReg);
                        }
                        else
                        {
                            tmpComboItems.Add(lobReg);
                            tmpComboItemsEliminado.Remove(lobReg);
                        }
                    }
                }
            }
            return lcrQuery;
        }
        #endregion
        //- Eliminar registros
        #region flgEliminarParenComboBoxItems : Eliminar registros ComboBox
        /// <summary>
        /// <para>Eliminar registros de lista de Items para ComboBox</para>
        /// <para>tcrObjeto="NombreObjeto" : Elimina todos item que tienen como padre al objeto dado.</para>
        /// </summary>
        public bool flgEliminarParenComboBoxItems(String tcrObjeto)
        {
            var llgValor = true;
            var lcrQuery = (from registro in tmpComboItems
                            where registro.Parent.Equals(tcrObjeto)
                            orderby registro.Parent, registro.IntIndice
                            select registro).ToList();

            foreach (ClassXmlComboBoxItems lobReg in lcrQuery)
            {
                tmpComboItems.Remove(lobReg);
            }
            return llgValor;
        }
        #endregion
        //- Adicionar registros
        #region flgAdicionarRegComboBoxItems : Adicionar registros
        /// <summary>
        /// <para>Adicionar registros de lista de Items para ComboBox</para>
        /// </summary>
        public bool flgAdicionarRegComboBoxItems(ClassXmlComboBoxItems tobRegistro)
        {
            var llgValor = true;
            tmpComboItems.Add(tobRegistro);
            return llgValor;
        }
        #endregion
        // ReAsiganr codigo seccion eliminada
        #region fcvEdtSeccionReAsiganarSeccionObjetos: Reasignar a seccion por defecto objetos de seccion eliminada
        /// <summary>
        /// <para>Esta funcion se ultiliza al eliminar una seccion en el diseño de una plantilla</para>
        /// <para>Para re-asignar el codigo seccion del objeto por defecto, cuando el codigo seccion no existe porque fue eliminada</para>
        /// <para>tcrCodigoSeccionDefault: codigo seccion que se asigna por defecto para objetos que no tienen o se elimino</para>
        /// </summary>
        public void fcvEdtSeccionReAsiganarSeccionObjetos(String tcrCodigoSeccionDefault)
        {
            foreach (var lobReg in tmpObjetos)
            {
                var lobSecc = fobPrnSeccionLocate(lobReg.SeccionCodigo);
                if (lobSecc == null)
                {
                    lobReg.SeccionCodigo = tcrCodigoSeccionDefault;
                }
            }
        }
        #endregion
        //---------------------------------------------------------------
        // REINICIAR VARIABLES Y TEMPORALES
        //---------------------------------------------------------------
        #region fcvGestionReiniciarValriables: Reinicia las Variables y temporales
        /// <summary>
        /// <para>Reinicia las Variables y temporales</para>
        /// </summary>
        public override void fcvGestionReiniciarValriables()
        {
            // Temporales de gestion
            base.fcvGestionReiniciarValriables();
            gcrImportArchivoPlantilla = String.Empty;
            gcrImportArchivoDatos     = String.Empty;
            gcrImportArchivoRuta      = String.Empty;
            gcrModoEdicionPlantilla   = "EDT";
        }
        #endregion
        //---------------------------------------------------------------
        // VISTA PRELIMINAR IMPRESION FORMATO
        //---------------------------------------------------------------
        #region flgPrnReporteImpresoraDetalles: Generar detalles datos para envio a impresora
        /// <summary>
        /// <para>Generar detalles datos para envio a impresora</para>
        /// </summary>
        public bool flgPrnReporteImpresoraDetalles()
        {
            var llgReturn = false;
            var llgValor = false;
            var llgTitulo = true;
            var lcrValor = String.Empty;
            var lcrTitulo = String.Empty;
            var lcrSeccionCodigo = String.Empty;
            var lcrSeccionNombre = String.Empty;
            var lnuSeccionOrdVis = 0;
            var lnuSeccionColumn = fnuPrnPlantTipoHojaReporteMaxCol(gcrPlantillaTipoHojaReporte);

            tmpPrnDetalles = null;
            tmpPrnDetallAux = null;
            tmpPrnDetalles = new List<TmpDatosFormatosDe>();
            tmpPrnDetallAux = new List<TmpDatosFormatosDe>();
            flgPrnReiniciarTotalRegistrosSeccion();            

            foreach (var lobReg in tmpObjetos)
            {
                lobReg.PrnSiValidar = String.IsNullOrWhiteSpace(lobReg.PrnSiValidar) ? "1" : lobReg.PrnSiValidar;
                llgValor = false;
                lcrValor = !String.IsNullOrWhiteSpace(lobReg.PrnValorPreView) ? lobReg.PrnValorPreView : lobReg.ValorDefault;
                lcrTitulo = lobReg.Titulo;
                llgTitulo = lobReg.PrnMostrarTitulo == "2" ? false : true;  
                lcrSeccionCodigo = lobReg.SeccionCodigo;

                #region datos de objetos
                switch (lobReg.TipoObjeto)
                {
                    case "TEXTBOX":
                        llgValor = flgPrnValidGenDatosImpresora(lobReg, lcrValor);
                        break;

                    case "TEXTBOXDATE":
                        llgValor = flgPrnValidGenDatosImpresora(lobReg, lcrValor);
                        break;

                    case "TEXTBOXTIME":
                        llgValor = flgPrnValidGenDatosImpresora(lobReg, lcrValor);
                        break;

                    case "RICHTEXTBOX":
                        llgValor = flgPrnValidGenDatosImpresora(lobReg, lcrValor);
                        break;

                    case "COMBOBOX":
                        #region Generar registro detalle
                        if (flgPrnValidGenDatosImpresora(lobReg, lcrValor))
                        {
                            llgValor = true;
                            // Buscar el valor descripcion
                            var lobRegCombo = fobRegSelectParenComboBoxItems(lobReg.Name, lcrValor);
                            if (lobRegCombo != null && lobRegCombo.Count != 0)
                            {
                                lcrValor = lcrValor + " - " + lobRegCombo.FirstOrDefault().Descripcion.Trim();
                            }
                        }
                        break;
                        #endregion

                    case "TEXTBOXRELCOD":
                        #region Generar registro detalle
                        if (flgPrnValidGenDatosImpresora(lobReg, lcrValor))
                        {
                            llgValor = true;

                            // Buscar el titulo del valor
                            var lobRel = fobRegSelectParenObjeto("OBJETOS", "", lobReg.Parent).FirstOrDefault();
                            if (lobRel != null)
                            {
                                lcrTitulo = lobRel.Titulo;
                                lcrSeccionCodigo = lobRel.SeccionCodigo;
                            }

                            // Buscar el valor descripcion
                            var lobObjDes = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobReg.Parent).FirstOrDefault();
                            if (lobObjDes != null)
                            {
                                lcrValor = lcrValor + " - " + lobObjDes.PrnValorPreView.Trim();
                            }
                        }
                        break;
                        #endregion

                    case "MULTICHKBOX":
                        #region Generar registro detalle
                        if (flgPrnValidGenDatosImpresora(lobReg, lcrValor))
                        {
                            llgValor = true;
                            // Buscar el titulo del valor
                            var lobRel = fobRegSelectParenObjeto("OBJETOS", "", lobReg.Parent).FirstOrDefault();
                            if (lobRel != null)
                            {
                                lcrTitulo = lobRel.Titulo;
                                lcrSeccionCodigo = lobRel.SeccionCodigo;
                            }

                            lcrValor = lcrValor.ToUpper() == "TRUE" ? "[X] " + lobReg.Titulo : "[_] " + lobReg.Titulo;
                        }
                        break;
                        #endregion

                    case "MULTIGROUPRADIOBUTTON":
                        #region Generar registro detalle
                        if (flgPrnValidGenDatosImpresora(lobReg, lcrValor))
                        {
                            var lobTemp = fobRegSelectParenObjeto("OBJETOS", "PARENT", lobReg.Name);

                            // buscar item seleccionado
                            if (lobTemp != null)
                            {
                                var lobx = lobTemp.FirstOrDefault(x => x.Indice == lcrValor);
                                if (lobx != null)
                                {
                                    llgValor = true;
                                    lcrValor = "(X) " + lobx.Titulo;
                                }
                            }
                        }
                        break;
                        #endregion
                }
                #endregion

                // Generar registro detalle
                #region Generar registro detalle
                if (llgValor == true)
                {
                    llgReturn = true;
                    var lobSecc = fobPrnSeccionLocateDefault(lcrSeccionCodigo);
                    if (lobSecc!= null)
                    {
                        lobSecc.IntTotalRegistros++; // sumar registros para dicha seccion

                        lcrSeccionCodigo = lobSecc.Codigo;
                        lcrSeccionNombre = lobSecc.Descripcion;
                        lnuSeccionOrdVis = lobSecc.IntOrden;
                        lnuSeccionColumn = lobSecc.IntTotalColumnas;
                    }
                    var lobRegAux = new TmpDatosFormatosDe();

                    lobRegAux.Hcl_seccion_codigo    = lcrSeccionCodigo;
                    lobRegAux.Hcl_seccion_titulo    = lcrSeccionNombre;
                    lobRegAux.Hcl_seccion_ordvista  = lnuSeccionOrdVis;
                    lobRegAux.Hcl_seccion_columna   = lnuSeccionColumn.ToString().Trim();
                    lobRegAux.Hcl_secuen_registro   = lobReg.Name;
                    lobRegAux.Hcl_registro_ordvista = !String.IsNullOrWhiteSpace(lobReg.OrdenVista) ? Convert.ToInt32(lobReg.OrdenVista) : 0;
                    lobRegAux.Hcl_titulo_dato1      = lcrTitulo;
                    lobRegAux.Hcl_valor_dato1       = llgTitulo == true ? lcrTitulo + ": " + lcrValor : lcrValor;

                    tmpPrnDetallAux.Add(lobRegAux);
                }
                #endregion
            }

            // organizar registros 
            if (llgReturn == true)
            {
                flgPrnOrganizarDatosImprimir();
            }
            return llgReturn;
        }
        #endregion
        #region flgPrnReporteImpresoraMaestro: Generar detalles datos para envio a impresora
        /// <summary>
        /// <para>Generar detalles datos para envio a impresora</para>
        /// </summary>
        public bool flgPrnReporteImpresoraMaestro()
        {
            var llgReturn = true;
            lobPrnRegMa = new TmpDatosFormatosMa();

            // Registro maestro datos
            #region Registro maestro datos
            lobPrnRegMa.Hcl_titulo_reporte = gcrPlantillaTituloReporte;  // debe ser  el titulo del reporte
            lobPrnRegMa.Hcl_nroreg_hcms = "R000000000"; // secuencial unico registro
            lobPrnRegMa.Hcl_nroreg_hcev = "HC000000000"; // Codigo registro en historial clinico
            lobPrnRegMa.Adm_secadm_rgad = "PRUEBA"; // Admision
            lobPrnRegMa.Sia_idesec_usua = "ID000000010"; // Id unico susuario
            lobPrnRegMa.Sia_tipide_tide = "CC"; // Tipo Ie
            lobPrnRegMa.Sia_nroide_usua = "78454545454"; // Numero identificacion
            lobPrnRegMa.Hcl_tipreg_hctr = gcrPlantillaTipoHojaReporte; // Tamaño Hoja para imprimir ejemplo:"01" = Hoja carta
            lobPrnRegMa.Sia_codare_aser = "003"; // Area prestacion de servicios
            lobPrnRegMa.Hcl_gesfec_hcms = Funciones.fcrFechaActual(); // Fecha gestion
            lobPrnRegMa.Hcl_geshor_hcms = Convert.ToDecimal(Funciones.fcrHoraActual("24",gcrSysSeparadorDecimal)); // Hora gestion
            lobPrnRegMa.Hcl_horges_hcms = Funciones.fcrConvierteHora(lobPrnRegMa.Hcl_geshor_hcms.ToString(), "24", gcrSysSeparadorDecimal, ":"); // Hora gestion formato 12H
            lobPrnRegMa.Hcl_tiptur_hctu = "T01"; // Mañana /Tipo Turno clsificacion turno
            lobPrnRegMa.Sia_codpfa_prof = "P025"; // Codigo del profesional
            lobPrnRegMa.Sis_estpro_espr = "2"; // Estado del registro
            lobPrnRegMa.Hcl_desreg_hcev = gcrPlantillaNombreTitulo; // Descripcion evento medico
            lobPrnRegMa.Sia_nomusu_usua = "MARIA PEREZ NOREÑA"; // Nombre completo del usuario o paciente 
            lobPrnRegMa.Sia_deside_tide = "CEDULA"; // Descrip tipo identificacion
            lobPrnRegMa.Hcl_desreg_hctr = "EMPLEADO NORMAL"; // Descripcion tipo actividad
            lobPrnRegMa.Sia_desare_aser = "URGENCIAS"; // Descripcion area prestacion servicio
            lobPrnRegMa.Hcl_destur_hctu = "NA";
            lobPrnRegMa.Sia_nompro_prof = "FREDDY NAVARRO R."; // Nombre del profesional
            lobPrnRegMa.Sis_despro_espr = "CONFIRMADO"; // Estado del proceso
            // Add en temporal
            #endregion

            return llgReturn;

        }
        #endregion
    }
}
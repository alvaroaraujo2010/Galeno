using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Text;
using System.Threading;
using System.ComponentModel;
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
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Reflection;
using GestorReportes.VistaModelo;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Vista;
using Sistema.Clases;
using Sistema.Validacion;
using Datos.Modelos;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using SaludPublica.Modelo;
using Reportes.Utilidades;

namespace GestorReportes.Utilidades
{
    public class XmlEntornoCaptura : XmlEntorno
    {
        // Temporales para guardar registros en tablas
        #region Temporales para guardar historial en tablas
        public ModeloHclregisextxa tmpRegTextBoxa = null;
        public ModeloHclregisextxb tmpRegTextBoxb = null;
        public ModeloHclregisextxc tmpRegTextBoxc = null;
        public ModeloHclregisexnum tmpRegNumerico = null;
        public ModeloHclregisexcbo tmpRegComboBox = null;
        public ModeloHclregisexcbx tmpRegCombocbx = null;
        public ModeloHclregisexrec tmpRegRecursos = null;
        public ModeloHclregisexfec tmpRegDatFecha = null;
        public ModeloHclregisexrel tmpRegRelacion = null;
        public ModeloHclregisexrbt tmpRegRdButon1 = null;
        public ModeloHclregisexrbm tmpRegRdButon2 = null;
        public ModeloHclregisexrbn tmpRegRdButon3 = null;
        public ModeloHclregisexrbo tmpRegRdButon4 = null;
        public ModeloHclregisexmem tmpRegRichText = null;
        public ModeloHclregisexmen tmpRegRichTmen = null;
        public ModeloHclregisexmeo tmpRegRichTmeo = null;
        public ModeloHclregisexchk tmpRegCheckBox = null;
        public ModeloHclregisexchl tmpRegCheckchl = null;
        public ModeloHclregisexchm tmpRegCheckchm = null;
        public List<ClassTempArchivoHistorico> tmpArchvioHist = null;
        #endregion
        // Temporales para actualizacion de archivos
        #region Temporales para actualizacion de archivos
        public ModeloSspRes4505 tmpRegActMS4505 = null;
        public ModeloSspNsRes4505 tmpRegActNS4505 = null;
        public FcmModeloServDetallFacturas tmpRecActServFac = null;
        public List<FcmModeloServDetallFacturas> tmpDetallesServFac = null;
        #endregion
        #region Variables generales
        public WrapPanel gobRefVistaHistorial;
        public String gcrIdRegHistorialEventoActivo = String.Empty;
        public String gcrIdRegHistActiviMedicDescrip = String.Empty; // Descripcion actividad medica
        public String gcrIdRegHistActiviMedicCodigo  = String.Empty; // ejemplo HCR-CONSULTA-EXRT
        public bool glgHistorialAddNuevoRegistro = false; // para saber si se add un nuevo registro en historial del paciente al guardar

        public List<ClassXmlPropDatos> tmpCapturaEtiqueta           = new List<ClassXmlPropDatos>();
        public ClassXmlPropPlanDatos gobRegPropPlantillaDatos       = null;
        public List<ADMModeloTreeAdmHistorial> tmpVistaHistAdmi     = null;
        public List<HclModeloHistorialEventos> tmpVistaHistorial    = null;
        public ADMModeloAdmadmisiones tmpRegAdmision                = null;
        public ClassRipsAmbulatoria gobRegRipsAmb                   = null;
        public SIAModeloUsuariosAtendidos tmpUsuarioAtendido        = null;
        public HclModeloHistorialEventos gobRegHistorial            = null;
        public HclModeloHistorialEventos gobRegHistorialActivo      = null;
        public EFsisparametroips gobRegValoresIPS                    = null;
        public List<ClassXmlPropVariablePublica> tmpVarPublicResumen = null;
        public List<ClassXmlPropVariablePublica> tmpVarPublicGeneral = null;
        public List<ClassTempResumenVarPublicas> tmpGrupoVarPublicas = null;
        public List<ClassTempResumenVarPublicas> tmpGrupoListaVarPublicas = null;
        public bool glgNuevoRegistroPlantilla = false; // Para saber si es nuevo registro de alguna plantilla (para usar admision activa)
        //public Aplicacion oApp = Aplicacion.Instancia();
        #endregion

        // Variables validacion captura de datos 
        #region Variables validacion captura de datos
        /// <summary>
        /// <para>Cuando hay caracteres no validos en captura de datos, esta variable contiene el valor "ERROR"</para>
        /// </summary>
        public String gcrValorReturnChr = String.Empty;
        /// <summary>
        /// <para>Contador errores de campos obligatorios no completados</para>
        /// </summary>
        public int gnuContErroresIsRequerido = 0;
        #endregion
        public XmlEntornoCaptura()
        {
            tmpCapturaDatos = new List<ClassXmlPropDatos>();
        }

        #region HISTORIAL ClassTempHistorial: Clase para temporal referencias a los Tiles del Historial
        /// <summary>
        /// <para>Clase para temporal referencias a los Tiles del Historial que permite realizar</para>
        /// <para>busquedas y Filtro desde el muro, ocultar/mostrar Tiles y demas utilidades</para>
        /// </summary>
        public class ClassTempHistorial
        {
            #region Clase
            public FrameworkElement RefObjeto { get; set; } // Referencia a la instancia del Objeto Tile en la vista muro
            public String RegEvento { get; set; }           // HCL_NROREG_HCEV	Código secuencial del evento medico  (generado por el sistema)
            public int IntRegEvento { get; set; }           // HCL_SECREG_HCEV	Numero secuencial para orden descendente
            public String NumeroAdmision { get; set; }      // ADM_SECADM_RGAD	Secuencial de Admisión del paciente
            public String NumeroAsigCita { get; set; }      // CIT_CODASI_MCIT	Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas
            public String ServicioFecha { get; set; }       // HCL_GESFEC_HCEV	Fecha del evento o prestacion del servicio al paciente
            public String ServicioHora { get; set; }        // HCL_GESHOR_HCEV	Hora del evento o prestación del servicio al paciente en formato militar  (HH) ejm: 16
            public String CodigoProfesional { get; set; }   // SIA_CODPFA_PROF	Código del Profesional que realiza la atencion del evento
            public String CodigoPlantilla { get; set; }     // GRP_IDEPLA_GRPL	Consecutivo Único de la plantilla  base
            public String CodigoVPlantilla { get; set; }    // GRP_IDEPLA_GRPV	Consecutivo Único de la version plantilla usada
            public String LlaveBusqueda { get; set; }       // HCL_KEYDAT_HCEV	Palabras claves para usar como llaves de busqueda 
            public String EstadoRegistro { get; set; }      // SIS_ESTPRO_ESPR	Estado de procesos en atencion asistencial : 1= Abierto  2= Cerrado/Confirmado 3=Anulado
            #endregion
        }
        #endregion
        #region  COMPLETRAR RIPS ClassRipsAmbulatoria: Clase para temporal referencias datos para completar atencion ambulatoria
        /// <summary>
        /// <para>Clase para temporal referencias a valores para completar RIPS atencion ambualtoria</para>
        /// </summary>
        public class ClassRipsAmbulatoria
        {
            #region Clase
            /// <summary>Secuencial de Admisión del paciente</summary>
            public String Adm_secadm_rgad { get; set; }
            /// <summary>Código del registro asignación de cita a paciente, cuando el origen es desde citas medicas</summary>
            public String Cit_codasi_mcit { get; set; }
            /// <summary>Codigo secuencial unico de usuario en sistema</summary>
            public String Sia_idesec_usua { get; set; }
            /// <summary>Código Tipo de Atención o ámbito donde se prestara el servicio :1=Ambulatoria 2=Hospitalización 3=Urgencia</summary>
            public String Adm_codtat_tatn { get; set; }
            /// <summary>Causa Externa Origen que origina la atención según Resolución: 3374 RIPS</summary>
            public String Adm_codcex_tcex { get; set; }
            /// <summary>Diagnostico de Ingreso a hospitalización/Urgencias con Observación</summary>
            public String Sia_dixing_tdia { get; set; }
            /// <summary>Causa textual del motivo consulta ambulatoria</summary>
            public String Adm_caucon_rgad { get; set; }
            /// <summary>Código del Profesional que realiza la atencion del evento</summary>
            public String Sia_codpfa_prof { get; set; }
            /// <summary>Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada</summary>
            public String Adm_estfac_rgad { get; set; }
            /// <summary>Estado de datos  atención medica para este Paciente 1=Abierta 2=Cerrada</summary>
            public String Adm_estrad_rgad { get; set; }
            /// <summary>Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No</summary>
            public String Adm_liqest_rgad { get; set; }
            /// <summary>Marca de Rips Completado 1=No Completado 2=Rips Completado 3=No Requiere Completado</summary>
            public String Adm_ctarip_rgad { get; set; }
            /// <summary>(Registro atencion ambulatoria) Finalidad de la consulta:01=Atención del Parto 02=Atencion... según Resolucion 3374 RIPS</summary>
            public String Sia_codfco_fcon { get; set; }
            /// <summary>(via de ingreso) Codigo origen de la atencion o admision</summary>
            public String Adm_codoad_toad { get; set; }
            /// <summary>(Registro atencion ambulatoria) Diagnostico principal CIE-10</summary>
            public String Sia_coddia_tdia { get; set; } 
            /// <summary>(Registro atencion ambulatoria) Tipo diagnostico principal</summary>
            public String Sia_tipdxp_tdix { get; set; }
            /// <summary>(Registro atencion ambulatoria)  Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion</summary>
            public String Adm_dessal_regr { get; set; }
            /// <summary>(Registro atencion ambulatoria)  Paciente embarazada: 1=Si 2= No 3 = No aplica</summary>
            public String Adm_pacemb_rgad { get; set; }
            /// <summary>Diagnostico relacionado 1 según CIE-10</summary>
            public String Sia_coddx1_tdia { get; set; }
            /// <summary>Diagnostico relacionado 2 según CIE-10</summary>
            public String Sia_coddx2_tdia { get; set; }
            /// <summary>Diagnostico relacionado 3 según CIE-10</summary>
            public String Sia_coddx3_tdia { get; set; }
            #endregion
        }
        #endregion
        #region VARIABLES RESUMEN ClassTempResumenVarPublicas: Clase para temporal generar valores en variables resumen 
        /// <summary>
        /// <para>Clase para temporal generar valores en variables resumen </para>
        /// </summary>
        public class ClassTempResumenVarPublicas
        {
            #region Clase
            /// <summary>Codigo del grupo de variables</summary>
            public String Hcl_secgru_hcgv { get; set; } 
            /// <summary>Titulo de la variable</summary>
            public String Hcl_titulo_hcvr { get; set; } 
            /// <summary>Nombre de la variable</summary>
            public String Hcl_nomvar_hcvr { get; set; } 
            /// <summary>Valor para solo tipo variable resumen: 2= Resumen general 3=Resumen solo hallazgos</summary>
            public String Hcl_modoca_hcvr { get; set; } 
            /// <summary>1=Incluir solo lista variables en resumen 2= No incluir lista variables en resumen 3=No Aplica</summary>
            public String Hcl_siresu_hcvr { get; set; } 
            /// <summary>Lista separada por punto y comas para Nombre de variables que se tendran en cuenta en el resumen</summary>
            public String Hcl_vresum_hcvr { get; set; } 
            /// <summary>Sumatoria valores de variables (resumen generado)</summary>
            public String Hcl_ValorResumen { get; set; } 
            #endregion
        }
        #endregion
        #region LISTA ARCHVIOS HISTORICOS ClassTempArchivoHistorico: Clase lista archivos historicos activos
        /// <summary>
        /// <para>Clase lista archivos historicos activos para guardar datos segun formato historias clinicas</para>
        /// </summary>
        public class ClassTempArchivoHistorico
        {
            #region Clase
            /// <summary>Identificador de archivo</summary>
            public String IdArchivo { get; set; }
            /// <summary>Nombre Tabla archivo historico activo ejemplo: HCLREGISEXTXB,HCLREGISEXNUM,...</summary>
            public String NombreArchivo { get; set; }
            #endregion
        }
        #endregion
        //------------------------------------------------------------
        //- CARGAR DATOS DESDE PLANTILLA DATOS
        //------------------------------------------------------------
        #region Cargar Datos y plantilla desde xml
        #region fobRegCargarXMLDatosPlantilla: Cargar Datos desde XML
        /// <summary>
        /// <para>Cargar propiedades de plantilla datos digitados para Plantilla Base desde XML</para>
        /// </summary>
        public ClassXmlPropPlanDatos fobRegCargarXMLDatosPlantilla(XmlElement tobjXmlPlantilla)
        {
            //gobRefVM.gnuPropValorProgressBar = 10;
            ClassXmlPropPlanDatos lobRegProp = null;
            foreach (XmlElement lobNodos in tobjXmlPlantilla.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Propiedades")
                {
                    lobRegProp = fobLeerXmlAttribPlantillaDatos(lobNodos);
                    break;
                }
            }
            return lobRegProp;
        }
        #endregion
        #region fcvRegCargarXMLDatosRegistros: Cargar datos digitados desde archivo XML
        /// <summary>
        /// <para>Cargar datos digitados desde archivo XML en el temporal de gestion</para>
        /// </summary>
        public void fcvRegCargarXMLDatosRegistros(XmlElement tobjXmlDatos)
        {
            //gobRefVM.gnuPropValorProgressBar = 40;
            foreach (XmlElement lobNodos in tobjXmlDatos.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Datos")
                {
                    tmpCapturaDatos = new List<ClassXmlPropDatos>();
                    var lobjRegistro = new ClassXmlPropDatos();

                    foreach (XmlNode lobCampo in lobNodos.ChildNodes)
                    {
                        lobjRegistro = fobLeerXmlAttributosDatos(lobCampo);
                        tmpCapturaDatos.Add(lobjRegistro);
                    }
                    break;
                }
            }
            //gobRefVM.gnuPropValorProgressBar = 100;
        }
        #endregion
        #region fcvRegCargarXMLDatosObjetos: Cargar objetos creados en modo captura
        /// <summary>
        /// <para>Cargar objetos creados en modo captura</para>
        /// </summary>
        public void fcvRegCargarXMLDatosObjetos(XmlNode tobjXmlDatos)
        {
            foreach (XmlElement lobNodos in tobjXmlDatos.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Objetos")
                {

                    foreach (XmlNode lobjItem in lobNodos)
                    {
                        var lobjRegistro = fobLeerXmlAttributosObjeto(lobjItem);
                        var lobObjBas = fobRegSelectParenObjeto("OBJETOS", "", lobjRegistro.Parent).FirstOrDefault();

                        //-Establecer Nivel del objeto en tree
                        var lnuNivel = fnuDefineNivelObjeto(lobObjBas);
                        lobjRegistro.ObjetoNivel = lnuNivel > 3 ? 5 : 3;
                        lobjRegistro.ObjetoParentPagina = lobObjBas.ObjetoParentPagina;
                        if (lobjRegistro.ObjetoNivel <=3 )
                        {
                            lobjRegistro.ObjetoParentZona = lobObjBas.Name;
                        }
                        else
                        {
                            lobjRegistro.ObjetoParentZona = lobObjBas.ObjetoParentZona;
                            lobjRegistro.ObjetoParentGrupo = lobObjBas.Name;
                        }
                        // Resto de datos y generar objeto
                        lobjRegistro.ObjetoEstado    = "ACTIVO";
                        lobjRegistro.Navegador       = lobObjBas.Navegador;
                        lobjRegistro.ObjetoModo      = lobObjBas.Navegador == "ESCRITORIO" ? "CAPTURA-EDT-ESCRITORIO" : "CAPTURA-EDT-ETIQUETA";
                        lobjRegistro.CodigoPlantilla = lobObjBas.CodigoPlantilla;
                        refRegObjActivo              = lobjRegistro;
                        fcvGenerarObjetoTreeReferencia("OBJETOS", lobjRegistro);

                        lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                        // Tipos objetos que tienen lista de items u objetos
                    }
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLDatosObjHistorial: Cargar objetos en la vista Historial
        /// <summary>
        /// <para>Cargar objetos en la vista Historial</para>
        /// </summary>
        public void fcvRegCargarXMLDatosObjHistorial(ref TileHistorial tobTile, XmlNode tobjXmlDatos)
        {
            foreach (XmlElement lobNodos in tobjXmlDatos.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "VistaHistorial")
                {
                    tobTile.stkHistorial.Children.Clear();
                    foreach (XmlNode lobjItem in lobNodos)
                    {
                        var lobjRegistro = fobLeerXmlAttributosHistorial(lobjItem);
                        switch (lobjRegistro.TipoObjeto)
                        {
                            case "IMAGEN":
                                var lobTileImagen = new TileHistorialImagen();
                                Image lobObjeto   = new Image();
                                lobObjeto.Margin = new Thickness(0, 5, 0, 5);

                                var lobUri = new EdtUtilidades.ObjetoBitmapImage();

                                lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
                                lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
                                lobUri.RutaGaleria   = lobjRegistro.RecursoArchivoUri;
                                lobUri.NombreArchivo = lobjRegistro.RecursoArchivoNombre;
                                lobObjeto.Source     = EdtUtilidades.SetBitmapImageUri(lobUri);
                                lobTileImagen.stkImagen.Children.Add(lobObjeto);
                                tobTile.stkHistorial.Children.Add(lobTileImagen);
                                break;

                            case "TEXTO":
                                var lobjTexto = new TileHistorialTexto();
                                lobjTexto.Margin = new Thickness(0, 5, 0, 5);

                                lobjTexto.txtTitulo.Text = lobjRegistro.Titulo;
                                lobjTexto.txtTexto.Text = lobjRegistro.Texto;
                                tobTile.stkHistorial.Children.Add(lobjTexto);
                                break;
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // LEER ATRIBUTOS DE PLANTILLA y DATOS GUARDADOS
        //------------------------------------------------------------
        #region Leer Atributos desde XML
        #region fobLeerXmlAttribPlantillaDatos: leer los atributos porpiedad pantilla Datos
        /// <summary>
        /// <para>leer los atributos porpiedad pantilla Datos</para>
        /// </summary>
        public static ClassXmlPropPlanDatos fobLeerXmlAttribPlantillaDatos(XmlNode tobNodoObjeto)
        {
            ClassXmlPropPlanDatos lobClassObjeto = new ClassXmlPropPlanDatos();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                #region Propiedades
                switch (lobAttrColl[i].Name)
                {
                    case "Codigo":
                        lobClassObjeto.Codigo = lobAttrColl[i].Value;
                        break;

                    case "Name":
                        lobClassObjeto.Name = lobAttrColl[i].Value;
                        break;

                    case "NombreArchivoPlantilla":
                        lobClassObjeto.NombreArchivoPlantilla = lobAttrColl[i].Value;
                        break;

                    case "VersionSistema":
                        lobClassObjeto.VersionSistema = lobAttrColl[i].Value;
                        break;

                    case "VersionPlantilla":
                        lobClassObjeto.VersionPlantilla = lobAttrColl[i].Value;
                        break;

                    case "Clave":
                        lobClassObjeto.Clave = lobAttrColl[i].Value;
                        break;

                    case "CodigoGrupo":
                        lobClassObjeto.CodigoGrupo = lobAttrColl[i].Value;
                        break;

                    case "TipoFormato":
                        lobClassObjeto.TipoFormato = lobAttrColl[i].Value;
                        break;

                    case "GenerSecObjeto":
                        lobClassObjeto.GenerSecObjeto = lobAttrColl[i].Value;
                        break;

                    case "PrefijoObjetos":
                        lobClassObjeto.PrefijoObjetos = lobAttrColl[i].Value;
                        break;

                    case "SeparadorDecimal":
                        lobClassObjeto.SeparadorDecimal = lobAttrColl[i].Value;
                        break;

                    case "DatosModoVista":
                        lobClassObjeto.DatosModoVista = lobAttrColl[i].Value;
                        break;
                       
                }
                #endregion
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosDatos: leer los atributos de porpiedad de un Nodo Registro de Datos
        /// <summary>
        /// <para>leer los atributos Propiedad de Nodo que representa registro de datos de un objeto</para>
        /// <para>Devuelve un registro tipo ClassXmlPropObjeto con todas las propiedades cargadas.</para>
        /// </summary>
        public static ClassXmlPropDatos fobLeerXmlAttributosDatos(XmlNode tobNodoObjeto)
        {
            var lobClassObjeto = new ClassXmlPropDatos();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;
            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                #region Propiedades
                switch (lobAttrColl[i].Name)
                {
                    case "IgGrupoRegistro":
                        lobClassObjeto.IgGrupoRegistro = lobAttrColl[i].Value;
                        break;

                    case "Navegador":
                        lobClassObjeto.Navegador = lobAttrColl[i].Value;
                        break;

                    case "CodigoPlantilla":
                        lobClassObjeto.CodigoPlantilla = lobAttrColl[i].Value;
                        break;

                    case "Name":
                        lobClassObjeto.Name = lobAttrColl[i].Value;
                        break;

                    case "Titulo":
                        lobClassObjeto.Titulo = lobAttrColl[i].Value;
                        break;

                    case "TipoObjeto":
                        lobClassObjeto.TipoObjeto = lobAttrColl[i].Value;
                        break;

                    case "ClaseBase":
                        lobClassObjeto.ClaseBase = lobAttrColl[i].Value;
                        break;

                    case "CampoReporte":
                        lobClassObjeto.CampoReporte = lobAttrColl[i].Value;
                        break;

                    case "SiFiltroBusqueda":
                        lobClassObjeto.SiFiltroBusqueda = lobAttrColl[i].Value;
                        break;

                    case "Binding":
                        lobClassObjeto.Binding = lobAttrColl[i].Value;
                        break;

                    case "ValorDefault":
                        lobClassObjeto.ValorDefault = lobAttrColl[i].Value;
                        break;

                    case "Valor":
                        lobClassObjeto.Valor = lobAttrColl[i].Value;
                        break;

                    case "ValorDescipcion":
                        lobClassObjeto.ValorDescripcion = lobAttrColl[i].Value;
                        break;

                    case "Indice":
                        lobClassObjeto.Indice = lobAttrColl[i].Value;
                        break;

                    case "TipoDato":
                        lobClassObjeto.TipoDato = lobAttrColl[i].Value;
                        break;

                    case "TipoOrigenDatos":
                        lobClassObjeto.TipoOrigenDatos = lobAttrColl[i].Value;
                        break;

                    case "TablaOrigen":
                        lobClassObjeto.TablaOrigen = lobAttrColl[i].Value;
                        break;

                    case "IdRegistro":
                        lobClassObjeto.IdRegistro = lobAttrColl[i].Value;
                        break;

                    case "NombreVariable":
                        lobClassObjeto.NombreVariable = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoTipo":
                        lobClassObjeto.RecursoArchivoTipo = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoCodigo":
                        lobClassObjeto.RecursoArchivoCodigo = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoUri":
                        lobClassObjeto.RecursoArchivoUri = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoNombre":
                        lobClassObjeto.RecursoArchivoNombre = lobAttrColl[i].Value;
                        break;
                }
                #endregion
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosHistorial: leer los atributos para objetos a mostrar en historial
        /// <summary>
        /// <para>leer los atributos Propiedad de Nodo los objetos a mostrar en el Muro Historial</para>
        /// <para>Devuelve un registro tipo ClassXmlVistaObjHistorial con todas las propiedades cargadas.</para>
        /// </summary>
        public static ClassXmlVistaObjHistorial fobLeerXmlAttributosHistorial(XmlNode tobNodoObjeto)
        {
            var lobClassObjeto = new ClassXmlVistaObjHistorial();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;
            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                #region Propiedades
                switch (lobAttrColl[i].Name)
                {
                    case "Name":
                        lobClassObjeto.Name = lobAttrColl[i].Value;
                        break;

                    case "Titulo":
                        lobClassObjeto.Titulo = lobAttrColl[i].Value;
                        break;

                    case "TipoObjeto":
                        lobClassObjeto.TipoObjeto = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoTipo":
                        lobClassObjeto.RecursoArchivoTipo = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoCodigo":
                        lobClassObjeto.RecursoArchivoCodigo = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoUri":
                        lobClassObjeto.RecursoArchivoUri = lobAttrColl[i].Value;
                        break;

                    case "RecursoArchivoNombre":
                        lobClassObjeto.RecursoArchivoNombre = lobAttrColl[i].Value;
                        break;
                }
                if (lobClassObjeto.TipoObjeto == "TEXTO")
                {
                    lobClassObjeto.Texto = tobNodoObjeto.InnerText.Trim();
                }
                #endregion
            }
            return lobClassObjeto;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        //- CONSULTAS LINQ EN TEMPORALES
        //------------------------------------------------------------
        //- Traer lista de registros 
        #region fobRegSelectParentRegistro : Seleccionar registros desde temporal datos digitados
        /// <summary>
        /// <para>Seleccionar registros desde temporal de datos digitados en modo captura</para>
        /// <para>Devolver registro del nombre objeto dado en parametro tcrObjeto o una lista segun parametro tcrTipoObjeto</para>
        /// <para>tcrArchivoOrigen: "DATOS"/"TEMP-ETIQUETA/TEMP-AUXILIAR"</para>
        /// <para>Posibles Valores tcrTipoObjeto:</para>
        /// <para>tcrTipoObjeto = "PLANTILLA"        y tcrObjeto ="IgGrupoRegistro"     : Retorna lista todos los valores correspondientes al IgGrupoRegistro </para>
        /// <para>tcrTipoObjeto = "IgGrupoRegistro"  y tcrObjeto ="NombreObjeto" : Retorna el regisro del objeto dado segun IgGrupoRegistro al que pertenece</para>
        /// </summary>
        public List<ClassXmlPropDatos> fobRegSelectParentRegistro(String tcrArchivoOrigen, String tcrTipoObjeto, String tcrObjeto)
        {
            List<ClassXmlPropDatos> tobTemp = fobRegSelectReferenciaRegistro(tcrArchivoOrigen);
            List<ClassXmlPropDatos> lcrQuery = null;

            if (tobTemp != null && tobTemp.Count != 0)
            {
                if (tcrTipoObjeto != "PLANTILLA")                  // solo el objeto dado.
                {
                    lcrQuery = (from lst in tobTemp
                                where lst.IgGrupoRegistro.Equals(tcrTipoObjeto) && lst.Name.Equals(tcrObjeto)
                                select lst).ToList();
                }
                else // Lista valores de la plantilla
                {
                    lcrQuery = (from lst in tobTemp
                                where lst.IgGrupoRegistro.Equals(tcrObjeto)
                                select lst).ToList();
                }
            }
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectReferenciaRegistro : Seleccionar referencia datos digitados
        /// <summary>
        /// <para>Seleccionar referencia datos digitados "tcrArchivoOrigen"</para>
        /// <para>tcrArchivoOrigen: "DATOS"/"TEMP-ETIQUETA/TEMP-AUXILIAR"</para>
        /// <para>Devuelve una referencia a :tmpCapturaDatos/tmpCapturaEtiqueta/aux/</para>
        /// </summary>
        public List<ClassXmlPropDatos> fobRegSelectReferenciaRegistro(String tcrArchivoOrigen)
        {
            List<ClassXmlPropDatos> tobTemp = tmpCapturaDatos;
            switch (tcrArchivoOrigen)
            {
                case "DATOS": //  Temporal de todos los datos digitados
                    tobTemp = tmpCapturaDatos;
                    break;

                case "TEMP-ETIQUETA": // Temporal etiqueta activa
                    tobTemp = tmpCapturaEtiqueta;
                    break;

                case "TEMP-AUXILIAR": // Adicionar el objeto eliminado, crear de nuevo
                    break;
            }
            return tobTemp;
        }
        #endregion
        #region fobRegSelectRegistroHistorial : Seleccionar registros desde temporal vista historial
        /// <summary>
        /// <para>Seleccionar registros desde tmpVistaHistorial temporal de registros en la vista historial</para>
        /// <para>Posibles Valores tcrTipoId:</para>
        /// <para>tcrTipoId = "REGISTRO"    y tcrLlave = "IgRegistro"  : Retorna el registro dado en "IgRegistro"</para>
        /// <para>tcrTipoId = "LLAVE"       y tcrLlave = "texto...  "  : Retorna lista de registros contengan el texto en campo llave</para>
        /// <para>tcrTipoId = "ADMISION"    y tcrLlave = "admision..." : Retorna lista de registros contengan numero de admision</para>
        /// </summary>
        public List<HclModeloHistorialEventos> fobRegSelectRegistroHistorial(String tcrTipoId, String tcrLlave)
        {
            List<HclModeloHistorialEventos> lcrQuery = null;

            if (tmpVistaHistorial != null)
            {
                if (tcrTipoId == "REGISTRO")    // solo el regigstro dado
                {
                    lcrQuery = (from lst in tmpVistaHistorial
                                where lst.Hcl_nroreg_hcev.Equals(tcrLlave)
                                select lst).ToList();
                }
                else if (tcrTipoId == "LLAVE")  // llave de busqueda general 
                {
                    lcrQuery = (from lst in tmpVistaHistorial
                                where lst.Hcl_nroreg_hcev.Contains(tcrLlave)
                                select lst).ToList();
                }
                else if (tcrTipoId == "ADMISION")  // Numero de admision
                {
                    if (!String.IsNullOrWhiteSpace(tcrLlave))
                    {
                        lcrQuery = (from lst in tmpVistaHistorial
                                    where lst.Adm_secadm_rgad == tcrLlave &&
                                          lst.GestionEstadoRegistro =="XX"
                                    select lst).ToList();
                    }
                    else
                    {
                        lcrQuery = (from lst in tmpVistaHistorial
                                    where lst.GestionEstadoRegistro =="XX"
                                    select lst).ToList();
                    }
                }
            }
            return lcrQuery;
        }
        #endregion
        //---------------------------------------------------------------
        // ABRIR GUARDAR IMPORTAR Y EXPORTAR
        //---------------------------------------------------------------
        // Importar y exprtar datos archivos externos
        #region flgDialogoBuscarPlantilla: Dialogo Buscar plantilla
        public bool flgDialogoBuscarPlantilla()
        {
            var llgReturn = false;
            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title       = "Buscar Plantillas de Reporte...";
            lopenFileDialog.Filter      = "Buscar registro o plantilla de reporte |*.xdb;*.xml";
            lopenFileDialog.DefaultExt  = ".xml"; // Extencion de archivos
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;

            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                gcrTipoOrigenArchivo = "ARCHIVO";
                fcvGestionReiniciarValriables();

                gcrXmlDocument              = lopenFileDialog.FileName;
                var lcrNombreArchivo        = lopenFileDialog.SafeFileName;
                gcrImportArchivoRuta        = gcrXmlDocument.Substring(0, gcrXmlDocument.Length - lcrNombreArchivo.Length);
                gcrPlantillaNombreArchivo   = String.Empty;
                gcrImportArchivoPlantilla   = String.Empty;

                // comprobar si es archivo de registro .xdb o plantilla .xml
                if (Funciones.flgExisteSubCadenaString(".xdb", gcrXmlDocument))
                {
                    gcrImportArchivoDatos = gcrXmlDocument;
                    gobXml.Load(gcrXmlDocument);
                    XmlElement lobXmlPlantilla = gobXml.DocumentElement;
                    gobRegPropPlantillaDatos = fobRegCargarXMLDatosPlantilla(lobXmlPlantilla);
                    if (gobRegPropPlantillaDatos != null)
                    {
                        gcrPlantillaNombreArchivo = gobRegPropPlantillaDatos.NombreArchivoPlantilla;
                        gcrImportArchivoPlantilla = System.IO.Path.Combine(gcrImportArchivoRuta, gcrPlantillaNombreArchivo);
                    }
                }
                else
                {
                    gcrImportArchivoDatos       = String.Empty;
                    gcrImportArchivoPlantilla   = gcrXmlDocument;
                    gcrPlantillaNombreArchivo   = lcrNombreArchivo;
                }
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
            lsaveFileDialog.Title = "Exportar datos digitados reporte...";
            lsaveFileDialog.Filter = "Exportar datos digitados reporte |*.xdb";
            lsaveFileDialog.DefaultExt = ".xdb"; // Extencion de archivos
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
                //var lcrPlantilla = fcrGenerarTextoXmlDatos("1");
                //System.IO.File.WriteAllText(@gcrXmlNombreArchivo, lcrPlantilla);
            }
        }
        #endregion
        // Abrir datos desde base de datos
        #region flgBDatosPlantillayDatos: Buscar plantilla datos en Base de datos
        /// <summary>
        /// <para>Buscar datos digitados en Base de datos para un registro del historial</para>
        /// <para>abre tambien la version de la plantilla con la cual fueron generados</para>
        /// </summary>
        public bool flgBDatosPlantillayDatos(String tcrCodigoRegHistorial)
        {
            gcrIdRegHistorialEventoActivo   = tcrCodigoRegHistorial;
            gcrTipoOrigenArchivo            = "BDATOS";
            gcrImportArchivoPlantilla       = String.Empty;
            gobRegHistorial                 = null;

            var llgReturn   = false;
            var lobRegHistorial = HclModeloHistorialEventos.flsBuscarHistorialEventos("HR", tcrCodigoRegHistorial);
            if (lobRegHistorial != null)
            {
                fcvGestionReiniciarValriables();

                // Cargar los datos Digitados del registro tcrCodigoRegHistorial
                gcrIdRegHistorialEventoActivo   = tcrCodigoRegHistorial;
                gcrImportArchivoDatos           = String.Empty;
                gobRegHistorial                 = lobRegHistorial.FirstOrDefault();
                gobRegHistorialActivo           = lobRegHistorial.FirstOrDefault();
                gcrDatosModoVista               = gobRegHistorial.Sis_estpro_espr.Trim() == "1" ? "E" : "V";

                tmpUsuarioAtendido = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(gobRegHistorial.Sia_idesec_usua).FirstOrDefault();


                //* -----------aqui----ojo por ahora para que solo busque guardados en tabla nada de XML
                //gobRegHistorialActivo.Hcl_archiv_hcev = "01";

                // Cargar datos digitados y guardados en historial para la plantilla
                if (gobRegHistorialActivo.Hcl_archiv_hcev == "XM")
                {
                    if (!String.IsNullOrWhiteSpace(gobRegHistorial.Hcl_xmldat_hcev))
                    {
                        gcrImportArchivoDatos = gobRegHistorial.Hcl_xmldat_hcev;
                        gobXml.LoadXml(gcrImportArchivoDatos);
                        XmlElement lobXmlPlantilla = gobXml.DocumentElement;
                        gobRegPropPlantillaDatos = fobRegCargarXMLDatosPlantilla(lobXmlPlantilla);
                        gcrDatosModoVista = gobRegPropPlantillaDatos.DatosModoVista;
                    }
                }
                // Buscar la version de la plantilla con la que fue digitado el registro
                var lobPlantilla = VersionPlantilla.flsBuscarVersionPlantilla(gobRegHistorial.Grp_idepla_grpv);
                if (lobPlantilla != null)
                {
                    //var lobRegPlant = lobPlantilla.FirstOrDefault();
                    gobRegPlantVersion = lobPlantilla.FirstOrDefault();
                    gcrImportArchivoPlantilla = fcrStringXmlCargarPlantilla(gobRegPlantVersion);
                    llgReturn = true;
                }
            }

            return llgReturn;
        }
        #endregion
        #region flgMostrarVistaPlantilla: Cargar la plantilla en pantalla
        /// <summary>
        /// <para>Muestra en pantalla la vista de la plantilla antes de cargar en ella los datos diligenciados</para>
        /// </summary>
        public bool flgMostrarVistaPlantilla(String tcrCodigoVersion)
        {
            var llgReturn = false;
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
                var lobEtq = new ClassXmlItemEtiquetas();
                lobEtq.IntIndice    = 1;
                lobEtq.Indice       = "1";
                lobEtq.Codigo       = "NA";
                lobEtq.Icono        = "NA";
                lobEtq.Descripcion  = "SIN ETIQUETA ASIGNADA";
                lobEtq.Archivo      = "NA";
                tmpEtiquetas.Add(lobEtq);

                gduMinimoAnchoPlantilla = 20;
                refTreeObj.Plantilla = gobRefPlantillaEscritorio;
                refTreeObj.NivelObjetoSelect = 1;
                refTreeObj.Navegador = "ESCRITORIO";

                fcvRegCargarXMLPlantilla(lobXmlPlantilla, "ESCRITORIO", "CAPTURA-ESCRITORIO");
                fobRegCargarXMLSecciones(lobXmlPlantilla);
                flgCargarValoresIniPlantillaDatos();
                fcvRegCargarXMLEtiquetas(lobXmlPlantilla);
                // Generar la vista objetos en pantalla
                fcvRegCargarXMLPaginas(lobXmlPlantilla);

                //-aqui- -ojo- revisar este es un parche barato
                // Parche para corregir problemas de asignacion campos
                #region Parche Barato
                var tmpCampos = ModeloGrpplantvistcam.flsListaGrpplantvistcam(tcrCodigoVersion);
                var lcrCampos = "-TEXTBOX-TEXTBOXDATE-TEXTBOXTIME-RICHTEXTBOX-" +
                                "COMBOBOX-TEXTBOXRELCOD-MULTICHKBOX-MULTIGROUPRADIOBUTTON-";

                foreach (var lobReg in tmpObjetos)
                {
                    // Saber si es un campo que guarda datos
                    if (!String.IsNullOrWhiteSpace(lobReg.NombreVariable))
                    {
                        if (lcrCampos.Contains(lobReg.TipoObjeto))
                        {
                            var lobRegx = tmpCampos.FirstOrDefault(x => x.Grp_nomobj_grob == lobReg.Name);
                            if (lobRegx != null)
                            {
                                lobReg.Binding = lobRegx.Hcl_nomcam_hccm;
                                lobReg.BindingDescripcion = lobRegx.Hcl_camdes_hccm != null ? lobRegx.Hcl_camdes_hccm : lobReg.BindingDescripcion;

                                // Buscar nombre tabla
                                var lcrTab = tmpCamposBindig.FirstOrDefault(x => x.Hcl_nomcam_hccm == lobReg.Binding.ToUpper());
                                if (lcrTab != null)
                                {
                                    lobReg.BindingTabla = lcrTab.Hcl_nomarc_hccm.Trim();
                                }
                            }
                        }
                    }
                }
                #endregion
                //- fin parche 
                // Cargar imagenes predefinidas 
                fcvRegCargarXMLImgPredefinidas(lobXmlPlantilla);
                flgCargarPlantillaEtiqueta();
                flgCargarObjetosCaptura();
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarPlantillaEtiqueta: Cargar las plantillas tipo etiquetas
        /// <summary>
        /// <para>Cargar y Muestra las plantillas tipo etiquetas existentes</para>
        /// </summary>
        public bool flgCargarPlantillaEtiqueta()
        {
            var llgReturn = false;
            if (tmpEtiquetas.Count > 0)
            {
                llgReturn = true;
                // guardar Referencia valores plantilla Escritorio
                #region Valores parametros plantilla Escritorio
                var lnuPlantillaGenerObjPagina      = gnuPlantillaGenerObjPagina;
                var lnuPlantillaGenerSecObjeto      = gnuPlantillaGenerSecObjeto;
                var lcrPlantillaPrefijoObjetos      = gcrPlantillaPrefijoObjetos;
                var lnuPlantillaHeight              = gnuPlantillaHeight;
                var lnuPlantillaWidth               = gnuPlantillaWidth;
                var lnuPlantillaMargenVertical      = gnuPlantillaMargenVertical;
                var lnuPlantillaMargenHorizontal    = gnuPlantillaMargenHorizontal;
                var lcrPlantillaSeparadorDecimal    = gcrPlantillaSeparadorDecimal;
                var lcrPlantillaNavegadorPlantilla  = gcrPlantillaNavegadorPlantilla;
                var lcrPlantillaCodigoPlantilla     = gcrPlantillaCodigoPlantilla;
                var lcrPlantillaObjetoModo          = gcrPlantillaObjetoModo;
                var lduMinimoAnchoPlantilla         = gduMinimoAnchoPlantilla;
                #endregion
                //- Cargar paginas y objetos 
                refTreeObj.Plantilla = gobRefPlantillaEtiqueta;
                refTreeObj.NivelObjetoSelect = 1;
                refTreeObj.Navegador = "ETIQUETA";
                var lcrArchivo       = String.Empty;
                XmlElement lobXmlPlantilla = null;

                foreach (var lobItem in tmpEtiquetas)
                {
                    lcrArchivo = String.Empty;
                    if (lobItem.Codigo != "NA")
                    {
                        if (gcrTipoOrigenArchivo == "BDATOS") // desde base de datos
                        {
                            var lobPlantilla = VersionPlantilla.flsBuscarVersionPlantilla(lobItem.Codigo.Trim() + "V10"); // V10 -> ojo por ahora *-*-*-*-*-*-*-*-*-*-*-*
                            if (lobPlantilla != null)
                            {
                                lcrArchivo = fcrStringXmlCargarPlantilla(lobPlantilla.FirstOrDefault());
                                gobXml.LoadXml(lcrArchivo);
                                lobXmlPlantilla = gobXml.DocumentElement;
                            }
                        }
                        else // es desde 'ARCHIVO'
                        {
                            lcrArchivo = System.IO.Path.Combine(gcrImportArchivoRuta, lobItem.Archivo);
                            gobXml.Load(lcrArchivo);
                            lobXmlPlantilla = gobXml.DocumentElement;
                        }
                        if (!String.IsNullOrWhiteSpace(lcrArchivo))
                        {

                            fcvRegCargarXMLPlantilla(lobXmlPlantilla, "ETIQUETA", "CAPTURA-ETIQUETA");
                            fcvRegCargarXMLPaginas(lobXmlPlantilla);
                        }
                    }
                }
                // Restaurar Referencia valores plantilla base
                #region Valores parametros plantilla Escritorio
                gnuPlantillaGenerObjPagina = lnuPlantillaGenerObjPagina;
                gnuPlantillaGenerSecObjeto      = lnuPlantillaGenerSecObjeto;
                gcrPlantillaPrefijoObjetos      = lcrPlantillaPrefijoObjetos;
                gnuPlantillaHeight              = lnuPlantillaHeight;
                gnuPlantillaWidth               = lnuPlantillaWidth;
                gnuPlantillaMargenVertical      = lnuPlantillaMargenVertical;
                gnuPlantillaMargenHorizontal    = lnuPlantillaMargenHorizontal;
                gcrPlantillaSeparadorDecimal    = lcrPlantillaSeparadorDecimal;
                gcrPlantillaNavegadorPlantilla  = lcrPlantillaNavegadorPlantilla;
                gcrPlantillaCodigoPlantilla     = lcrPlantillaCodigoPlantilla;
                gcrPlantillaObjetoModo          = lcrPlantillaObjetoModo;
                gduMinimoAnchoPlantilla         = lduMinimoAnchoPlantilla;
                #endregion
            }
            return llgReturn;
        }
        #endregion
        #region fcrBDatosGenerarllaveFiltro: Generar llave filtro en historial
        /// <summary>
        /// <para>Generar llave filtro en historial</para>
        /// </summary>
        public String fcrBDatosGenerarllaveFiltro()
        {
            String lcrListaLlave = String.Empty;

            foreach (var lobItem in tmpCapturaDatos)
            {
                if (lobItem.TipoObjeto == "RADIOBUTTON" || lobItem.TipoObjeto == "MULTIRADIOBUTTON")
                {
                    var lobObjOpc = fobRegSelectParenObjeto("OBJETOS", "PARENT", lobItem.Name);
                    foreach (ClassXmlPropObjeto lobReg in lobObjOpc)
                    {
                        if (lobReg.ClaseBase == "RadioButton" && lobReg.SiFiltroBusqueda == "True" && lobReg.Indice == lobItem.Valor)
                        {
                            lcrListaLlave += "  " + lobReg.Titulo.ToLower();
                        }
                    }
                }
                else if (lobItem.SiFiltroBusqueda == "True")
                {
                    if (lobItem.TipoObjeto == "TEXTBOXREL")
                    {
                        var lcrllave = String.Empty;
                        var lobObjCod = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELCOD", lobItem.Name).FirstOrDefault();
                        var lobObjDes = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobItem.Name).FirstOrDefault();
                        if (lobObjCod != null)
                        {
                            lcrllave = ((TextBox)lobObjCod.RefObjeto).Text;
                        }
                        if (lobObjDes != null)
                        {
                            lcrllave += " "+((TextBox)lobObjDes.RefObjeto).Text;
                        }
                        lcrListaLlave += " " + lcrllave.ToLower();
                    }
                    else if ((lobItem.TipoObjeto == "COMBOBOX" || lobItem.TipoObjeto == "MULTICHKBOX") && lobItem.Valor=="True")
                    {
                        lcrListaLlave += " " + lobItem.Titulo.ToLower();
                    }
                    else
                    {
                        if (lobItem.Valor != null)
                        {
                            lcrListaLlave += " " + lobItem.Valor.ToLower();
                        }
                    }
                }
            }
            return lcrListaLlave;
        }
        #endregion
        // Gaurdar datos en base de datos y Actualizar archivos
        #region flgBDatosGuardarRegistroDatos: Guardar datos en la base de datos
        /// <summary>
        /// <para>Guardar en base de datos los cambios realizados en registro activo</para>
        /// <para>tcrEstado: 1= Guardar sin confirmar 2 = Guardar y Confirmar 3 = Anular</para>
        /// </summary>
        public bool flgBDatosGuardarRegistroDatos(String tcrEstado)
        {
            var llgReturn = false;
            try
            {
                glgHistorialAddNuevoRegistro = false;
                if (String.IsNullOrWhiteSpace(gcrIdRegHistorialEventoActivo))
                {
                    // cuando es nuevo desde formato seleccionado por el profesional  generar el registro en historial
                    glgHistorialAddNuevoRegistro = true;
                    gcrIdRegHistorialEventoActivo = fcrHclinicaGenerarActividad();
                }
                var lobRegHistorial = HclModeloHistorialEventos.flsBuscarHistorialEventos("HR", gcrIdRegHistorialEventoActivo);

                if (lobRegHistorial != null)
                {
                    if (lobRegHistorial.Count > 0)
                    {
                        llgReturn = true;
                        gobRegHistorial       = lobRegHistorial.FirstOrDefault();
                        var lobRegistro       = gobRegHistorial;
                        var lcrllaves         = fcrBDatosGenerarllaveFiltro();
                        gcrDatosModoVista     = tcrEstado == "1" ? "E" : "V";
                        gobRegHistorialActivo = lobRegistro;
                        lobRegistro.Hcl_keydat_hcev = !String.IsNullOrWhiteSpace(lcrllaves) ? lcrllaves : lobRegistro.Hcl_keydat_hcev.Trim();
                        lobRegistro.Sis_estpro_espr = tcrEstado;

                        // gaurdar los datos 
                        //if (gcrFormatoArchvioGuardarDatos == "XM") // Para poder probar guardado en tablas
                        if (gobRegHistorialActivo.Hcl_archiv_hcev == "XM") 
                        {
                            // Formato XML
                            var lcrPlantilla = tcrEstado == "3" ? lobRegistro.Hcl_xmldat_hcev : fcrGenerarTextoXmlDatos(tcrEstado);
                            lobRegistro.Hcl_xmldat_hcev = lcrPlantilla;
                        }
                        else
                        { 
                            // Pasar datos digitados en la vista a temporales de tablas 
                            fcvGTablaSetValorDatosDigitados(tcrEstado);
                            // Temporales Se guardan en tablas
                            fcvGTablaGuardarHistDatosDigitados(gobRegHistorialActivo.Hcl_archiv_hcev);
                        }

                        // Actualizar archivos historicos
                        HclModeloHistorialEventos.fcvActualizar(lobRegistro);
                        flgBDatosActualizarCamposArchivos();
                        if (tcrEstado != "1") { fcvActualizarVariablesPublicasMaestro(); }

                        // Actualizar vista historial si el registro no es nuevo 
                        if (glgHistorialAddNuevoRegistro == false)
                        {
                            flgVistaHistorialActualizRegistroEvento(gcrIdRegHistorialEventoActivo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "XmlEntornoCaptura Error Metodo: flgBDatosGuardarRegistroDatos");
            }

            return llgReturn;
        }
        #endregion
        #region fcvHclinicaGenerarActividad: Generar registro en historial clinico segun nuevo formato activo
        /// <summary>
        /// <para>Generar registro en historial clinico segun nuevo formato activo</para>
        /// </summary>
        public String fcrHclinicaGenerarActividad()
        {
            var lcrCodigoHistorial = String.Empty;
            var lcrProfesional = tmpRegAdmision.Sia_codpfa_prof;
            var lcrCentProducc = tmpRegAdmision.Fcm_codcpr_cpro;
            var lobRegProf = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario);
            var lobRegCpro = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(tmpRegAdmision.Fcm_codcpr_cpro);

            lcrProfesional = lobRegProf != null ? lobRegProf.sia_codpfa_prof : lcrProfesional;
            lcrCentProducc = lobRegCpro != null ? lobRegCpro.fcm_descpr_cpro : lcrCentProducc;

            var lobHist = new HclModeloHistorialEventos();

            #region Datos del registro
            lobHist.Hcl_secreg_hcev = 1; // por el momento
            lobHist.Hcl_nrohis_hicl = tmpRegAdmision.Hcl_nrohis_hicl;
            lobHist.Adm_secadm_rgad = tmpRegAdmision.Adm_secadm_rgad;
            lobHist.Cit_codasi_mcit = tmpRegAdmision.Cit_codasi_mcit;
            lobHist.Fcm_codcpr_cpro = tmpRegAdmision.Fcm_codcpr_cpro;
            lobHist.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
            lobHist.Sia_tipide_tide = tmpRegAdmision.Sia_tipide_tide;
            lobHist.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
            lobHist.Hcl_gesfec_hcev = Convert.ToDateTime(Funciones.fcrFechaActual());
            lobHist.Hcl_geshor_hcev = Convert.ToDecimal(Funciones.fcrHoraActual("24", Funciones.fcrLeerConfiguracionRegional("DECIMAL")));
            lobHist.Sia_codpfa_prof = lcrProfesional;
            lobHist.Hcl_keydat_hcev = (gobRegPlantMaestro.Grp_despla_grpl.Trim() + " " + lcrCentProducc + " " + Funciones.fcrFechaActual()).Trim().ToLower();
            lobHist.Hcl_xmldat_hcev = String.Empty;
            lobHist.Hcl_xmltmp_hcev = String.Empty;
            lobHist.Hcl_xmlcom_hcev = String.Empty;
            lobHist.Hcl_conobj_hcev = 1; 
            lobHist.Sis_estpro_espr = "1";
            lobHist.Hcl_desreg_hcev = gcrIdRegHistActiviMedicDescrip.Trim();
            lobHist.Hcl_codreg_hcca = gcrIdRegHistActiviMedicCodigo;
            lobHist.Grp_idepla_grpl = gobRegPlantMaestro.Grp_idepla_grpl;
            lobHist.Grp_idepla_grpv = gobRegPlantMaestro.Grp_idepla_grpv;
            lobHist.Fcm_secreg_dfac = "NA";
            lobHist.Hcl_archiv_hcev = gcrFormatoArchvioGuardarDatos;
            lobHist.Sis_estpro_espr = "1";  // abierto por defecto
            lcrCodigoHistorial = HclModeloHistorialEventos.fcrAddRegistro(lobHist);
            #endregion
            return lcrCodigoHistorial;
        }
        #endregion
        #region flgBDatosActualizarCamposArchivos: Actualizar los campos en archivos
        /// <summary>
        /// <para>Actualizar los Archivos correspondiente a campos relacionados en objetos</para>
        /// <para>tales como RIPS, 4505 y otros</para>
        /// </summary>
        public bool flgBDatosActualizarCamposArchivos()
        {
            // Temporales para actualizacion de archivos
            #region Temporales para actualizacion de archivos
            tmpRegActMS4505     = null;
            tmpRegActNS4505     = null;
            tmpDetallesServFac  = null;
            gobRegRipsAmb = new ClassRipsAmbulatoria();
            var lcrAdmision = String.Empty;

            // Buscar registro de atencion 
            if (gobRegHistorial != null)
            {
                lcrAdmision = !String.IsNullOrWhiteSpace(gobRegHistorial.Adm_secadm_rgad) ? gobRegHistorial.Adm_secadm_rgad : tmpRegAdmision.Adm_secadm_rgad;
            }
            else
            {
                lcrAdmision = tmpRegAdmision.Adm_secadm_rgad;
            }
            #endregion

            var llgReturn = false;
            // datos del registro de admision
            //tmpRegAdmision = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(lcrAdmision);
            tmpRegAdmision = ADMModeloAdmadmisiones.flsListaAdmregadmision(lcrAdmision).FirstOrDefault();
            if (tmpRegAdmision == null) { return false; }

            foreach (var lobRegDato in tmpCapturaDatos)
            {
                var lobObjeto = tmpObjetos.FirstOrDefault(x => x.Name == lobRegDato.Name);
                if (lobObjeto != null)
                {
                    lobRegDato.Valor = lobRegDato.Valor != null ? lobRegDato.Valor : String.Empty;

                    switch (lobObjeto.RefVarDatosTipo)
                    {
                        case "RE4505": // Resolucion 4505
                            //flgTempActualizarCamposRE4505(lobObjeto.Name, lobRegDato.Valor, lobObjeto.RefVarDatosCampo);
                            break;

                        case "RIPSAC": // Rips de consulta
                            flgTempActualizarCamposRips(lobObjeto.Name, lobRegDato.Valor, lobObjeto.RefVarDatosCampo);
                            break;

                        case "RIPSAP": // Rips de Procedimientos
                            flgTempActualizarCamposRips(lobObjeto.Name, lobRegDato.Valor, lobObjeto.RefVarDatosCampo);
                            break;

                    }
                    if (lobObjeto.RefVarDatosTipo == "RIPSAC" || lobObjeto.RefVarDatosTipo == "RIPSAP")
                    {
                        switch (lobObjeto.RefVarDatosCampo)
                        {
                            case "RIPS_EMBARAZADASINO":
                                gobRegRipsAmb.Adm_pacemb_rgad = lobRegDato.Valor;
                                break;

                            case "RIPS_DESTINOALSALIR":
                                gobRegRipsAmb.Adm_dessal_regr = lobRegDato.Valor;
                                break;

                            case "RIPS_CAUSATEXTUAL":
                                gobRegRipsAmb.Adm_caucon_rgad = lobRegDato.Valor.Trim().Length > 150 ? lobRegDato.Valor.Trim().Substring(0, 150) : lobRegDato.Valor.Trim();
                                break;

                            case "RIPS_VIAINGRESO":
                                gobRegRipsAmb.Adm_codoad_toad = lobRegDato.Valor;
                                break;

                            default:
                                if (lobObjeto.RefVarDatosCampo == "SSP_CAM014_MS45")
                                { 
                                    // Paciente embarazada (SI/NO/NO APLICA) 4505
                                    gobRegRipsAmb.Adm_pacemb_rgad = lobRegDato.Valor;
                                }
                                break;
                        }
                    }
                }
            }
            // Verificar si es ambulatoria
            if (tmpRegAdmision.Adm_codtat_tatn == "1")
            {
                if (flgValidarDatosRipsCompletos())
                {
                    // Marcar rips completados
                    tmpRegAdmision.Adm_ctarip_rgad = "2";
                }
                tmpRegAdmision.Adm_codoad_toad = String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_codoad_toad) ? 
                                                                           gobRegRipsAmb.Adm_codoad_toad : tmpRegAdmision.Adm_codoad_toad;
                tmpRegAdmision.Adm_codcex_tcex = String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_codcex_tcex) ?
                                                                           gobRegRipsAmb.Adm_codcex_tcex : tmpRegAdmision.Adm_codcex_tcex;
                tmpRegAdmision.Adm_dessal_regr = String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_dessal_regr) ?
                                                                           gobRegRipsAmb.Adm_dessal_regr : tmpRegAdmision.Adm_dessal_regr;
                tmpRegAdmision.Adm_pacemb_rgad = String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_pacemb_rgad) ?
                                                                           gobRegRipsAmb.Adm_pacemb_rgad : tmpRegAdmision.Adm_pacemb_rgad;
                tmpRegAdmision.Adm_caucon_rgad = String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_caucon_rgad) ?
                                                                           gobRegRipsAmb.Adm_caucon_rgad : tmpRegAdmision.Adm_caucon_rgad;
                // Cambiar prioridad de diagnosticos 
                tmpRegAdmision.Sia_codfco_fcon = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_codfco_fcon) ?
                                                                           gobRegRipsAmb.Sia_codfco_fcon : tmpRegAdmision.Sia_codfco_fcon;
                tmpRegAdmision.Sia_tipdxp_tdix = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_tipdxp_tdix) ?
                                                                           gobRegRipsAmb.Sia_tipdxp_tdix : tmpRegAdmision.Sia_tipdxp_tdix;
                tmpRegAdmision.Sia_coddia_tdia = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddia_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddia_tdia : tmpRegAdmision.Sia_coddia_tdia;
                tmpRegAdmision.Sia_dixre1_tdia = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx1_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx1_tdia : tmpRegAdmision.Sia_dixre1_tdia;
                tmpRegAdmision.Sia_dixre2_tdia = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx2_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx2_tdia : tmpRegAdmision.Sia_dixre2_tdia;
                tmpRegAdmision.Sia_dixre3_tdia = !String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx3_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx3_tdia : tmpRegAdmision.Sia_dixre3_tdia;
                // datos anteriores (inactivos ahora)
                #region asi estaba antes
                /*
                tmpRegAdmision.Sia_codfco_fcon = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_codfco_fcon) ?
                                                           gobRegRipsAmb.Sia_codfco_fcon : tmpRegAdmision.Sia_codfco_fcon;
                tmpRegAdmision.Sia_tipdxp_tdix = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_tipdxp_tdix) ?
                                                                           gobRegRipsAmb.Sia_tipdxp_tdix : tmpRegAdmision.Sia_tipdxp_tdix;
                tmpRegAdmision.Sia_coddia_tdia = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_coddia_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddia_tdia : tmpRegAdmision.Sia_coddia_tdia;
                tmpRegAdmision.Sia_dixre1_tdia = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_dixre1_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx1_tdia : tmpRegAdmision.Sia_dixre1_tdia;
                tmpRegAdmision.Sia_dixre2_tdia = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_dixre2_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx2_tdia : tmpRegAdmision.Sia_dixre2_tdia;
                tmpRegAdmision.Sia_dixre3_tdia = String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_dixre3_tdia) ?
                                                                           gobRegRipsAmb.Sia_coddx3_tdia : tmpRegAdmision.Sia_dixre3_tdia;
                */
                #endregion

                tmpRegAdmision.Sia_coddia_tdia = tmpRegAdmision.Sia_coddia_tdia == null ? String.Empty : tmpRegAdmision.Sia_coddia_tdia.ToUpper();
                tmpRegAdmision.Sia_dixre1_tdia = tmpRegAdmision.Sia_dixre1_tdia == null ? String.Empty : tmpRegAdmision.Sia_dixre1_tdia.ToUpper();
                tmpRegAdmision.Sia_dixre2_tdia = tmpRegAdmision.Sia_dixre2_tdia == null ? String.Empty : tmpRegAdmision.Sia_dixre2_tdia.ToUpper();
                tmpRegAdmision.Sia_dixre3_tdia = tmpRegAdmision.Sia_dixre3_tdia == null ? String.Empty : tmpRegAdmision.Sia_dixre3_tdia.ToUpper();

                // Actualizar el registro maestro
                ADMModeloAdmadmisiones.fcvActualizar(tmpRegAdmision);
            }
            #region Actualizacion de archivos 
            flgActualizarBdatosRips();
            //flgActualizarBdatosRE4505();
            ADMModeloAdmadmisiones.fcvActualizarEstados(tmpRegAdmision.Adm_secadm_rgad, "", "", "", "", tmpRegAdmision.Adm_ctarip_rgad, 0);
            #endregion
            return llgReturn;
        }
        #endregion
        // Completar RIPS
        #region flgTempActualizarCamposRips: Actualizar los campos en registros RIPS
        /// <summary>
        /// <para>Actualizar los campos en registros RIPS</para>
        /// </summary>
        public bool flgTempActualizarCamposRips(String tcrNombreObjeto, String tcrValor, String tcrNombreCampo)
        {

            var llgReturn = false;
            var lcrAdmision = String.Empty;

            // Buscar registro de atencion 
            if (tmpRegAdmision != null)
            {
                lcrAdmision = !String.IsNullOrWhiteSpace(tmpRegAdmision.Adm_secadm_rgad) ? tmpRegAdmision.Adm_secadm_rgad : gobRegHistorial.Adm_secadm_rgad;
            }
            else
            {
                lcrAdmision = gobRegHistorial.Adm_secadm_rgad;
            }

            // Iniciar el registro
            if (tmpDetallesServFac == null)
            {
                tmpDetallesServFac = FcmModeloServDetallFacturas.flsListaFcmmaedetallfac("AP", lcrAdmision);
            }
            if (tmpDetallesServFac != null)
            {
                foreach (var lobReg in tmpDetallesServFac)
                {
                    var lobRegistro = lobReg;

                    if (lobReg.Sia_codrip_trip=="01") //Consultas
                    {
                        llgReturn = flgActualizarRegActivoRipsAC(ref lobRegistro, tcrNombreCampo, tcrValor);
                    }
                    else if (lobReg.Sia_codrip_trip == "02" || lobReg.Sia_codrip_trip == "03" ||
                             lobReg.Sia_codrip_trip == "04" || lobReg.Sia_codrip_trip == "05") // Procedimientos
                    {
                        llgReturn = flgActualizarRegActivoRipsAP(ref lobRegistro, tcrNombreCampo, tcrValor);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgActualizarBdatosRips: Actualizar cambios en Base de datos Rips en servicios facturados
        /// <summary>
        /// <para>Actualizar cambios en Base de datos Rips en servicios facturados</para>
        /// </summary>
        public bool flgActualizarBdatosRips()
        {

            var llgReturn = false;

            // Iniciar el registro
            if (tmpDetallesServFac != null)
            {
                foreach (var lobReg in tmpDetallesServFac)
                {
                    if (lobReg.Modificado == "M")
                    {
                        FcmModeloServDetallFacturas.fcvActualizar(lobReg);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgValidarDatosRipsCompletos: para saber si los datos RIPS estan completos
        /// <summary>
        /// Validar los registros para saber si los datos RIPS estan completos
        /// </summary>
        public bool flgValidarDatosRipsCompletos()
        {
            var llgReturn = false;
            var lnuConRipsIncom = 0;
            if (tmpDetallesServFac != null)
            {
                foreach (FcmModeloServDetallFacturas lobReg in tmpDetallesServFac)
                {
                    if (!FcmValidarRips.flgValidarRegistroExt(lobReg, ref tmpLogErrores))
                    {
                        lnuConRipsIncom++;
                    }
                }
            }
            llgReturn = lnuConRipsIncom > 0 ? false : true;

            return llgReturn;
        }
        #endregion
        // Resolucion 4505
        #region flgTempActualizarCamposRE4505: Actualizar los campos en archivo resolucion 4505
        /// <summary>
        /// <para>Actualizar los campos en archivo resolucion 4505</para>
        /// </summary>
        public bool flgTempActualizarCamposRE4505(String tcrNombreObjeto, String tcrValor, String tcrNombreCampo)
        {

            var llgReturn = false;
            // Iniciar el registro
            if (tmpRegActMS4505 == null)
            {
                //Buscar registro en maestro 4505
                tmpRegActMS4505 = ModeloSspRes4505.flsListaSptablmsres4505Ex("IG", gobRegHistorial.Sia_idesec_usua);
                tmpUsuarioAtendido = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(gobRegHistorial.Sia_idesec_usua).FirstOrDefault();

                // Agragar registro por defecto cuando no existe ningun dato
                if (tmpRegActMS4505 == null)
                {
                    // Agregar registro por defecto
                    tmpRegActMS4505 = new ModeloSspRes4505();
                    tmpRegActMS4505.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                    tmpRegActMS4505.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
                    tmpRegActMS4505.Sia_codeps_teps = tmpRegAdmision.Sia_codeps_teps;
                    tmpRegActMS4505.Ssp_cam000_ms45 = "2"; 
                    tmpRegActMS4505.Ssp_cam002_ms45 = ModeloSpconfigura4505.fcrBuscarIpsSpconfigura4505(); 
                    tmpRegActMS4505.Ssp_cam003_ms45 = tmpRegAdmision.Sia_tipide_tide;
                    tmpRegActMS4505.Ssp_cam004_ms45 = tmpRegAdmision.Sia_nroide_usua;
                    tmpRegActMS4505.Ssp_cam005_ms45 = tmpRegAdmision.Sia_priape_usua;
                    tmpRegActMS4505.Ssp_cam006_ms45 = tmpRegAdmision.Sia_segape_usua;
                    tmpRegActMS4505.Ssp_cam007_ms45 = tmpRegAdmision.Sia_prinom_usua;
                    tmpRegActMS4505.Ssp_cam008_ms45 = tmpRegAdmision.Sia_segnom_usua;
                    tmpRegActMS4505.Ssp_cam009_ms45 = tmpRegAdmision.Sia_fecnac_usua;
                    tmpRegActMS4505.Ssp_cam010_ms45 = tmpRegAdmision.Sis_codsex_sexo;
                    //tmpRegActMS4505.Ssp_cam011_ms45 = tmpRegAdmision.Ssp_cam011_ms45;
                    tmpRegActMS4505.Ssp_cam011_ms45 = "6"; // OJO CORREGIR... debe venir de alguna tabla como usuarios atendidos o admisión (en ninguna existe el campo)
                    tmpRegActMS4505.Ssp_codocu_ciuo = tmpUsuarioAtendido.Sis_codocu_ocup;

                    tmpRegActMS4505 = ModeloSspRes4505.flsAddRegistrodefault(tmpRegAdmision.Sia_edadia_usua, tmpRegAdmision.Sis_codsex_sexo, tmpRegActMS4505);

                }
            }
            // Iniciar el registro
            if (tmpRegActMS4505 != null)
            {
                llgReturn = flgActualizarRegActivoMS4505_R029(tcrNombreCampo, tcrValor);

                if (!llgReturn)
                {
                    llgReturn = flgActualizarRegActivoMS4505_R3059(tcrNombreCampo, tcrValor);
                }
                if (!llgReturn)
                {
                    llgReturn = flgActualizarRegActivoMS4505_R6089(tcrNombreCampo, tcrValor);
                }
                if (!llgReturn)
                {
                    llgReturn = flgActualizarRegActivoMS4505_R90118(tcrNombreCampo, tcrValor);
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgActualizarBdatosRE4505: Actualizar cambios en Base de datos archivo resolucion 4505
        /// <summary>
        /// <para>Actualizar en Base de datos los campos modificados en vista objetos</para>
        /// <para>relacionados con archivo resolucion 4505</para>
        /// </summary>
        public bool flgActualizarBdatosRE4505()
        {
            var llgReturn   = false;
            var lcrAño      = Funciones.fcrComponenteFecha(gobRegHistorial.Hcl_gesfec_hcev, "AÑO");
            var lcrMes      = Funciones.fcrComponenteFecha(gobRegHistorial.Hcl_gesfec_hcev, "MES");
            var lcrPeriodo   = lcrAño + lcrMes;
            // Iniciar el registro
            if (tmpRegActMS4505 != null)
            {
                ModeloSspRes4505.fcvActualizar(tmpRegActMS4505, lcrAño, lcrMes);
            }
            return llgReturn;
        }
        #endregion
        // Gestion desde datos en Base de datos
        #region flgCargarObjetosCaptura: Mostrar objetos creados en modo captura 
        /// <summary>
        /// <para>Mostrar objetos creados en modo captura</para>
        /// </summary>
        public bool flgCargarObjetosCaptura()
        {
            var llgReturn = false;
            // Cargar datos cuando existe una plantilla de datos 
            if (!String.IsNullOrEmpty(gcrImportArchivoDatos))
            {
                llgReturn = true;
                XmlElement lobXmlDatos = null;
                if (gcrTipoOrigenArchivo == "BDATOS") // desde base de datos
                {
                    gobXml.LoadXml(gcrImportArchivoDatos);
                    lobXmlDatos = gobXml.DocumentElement;
                }
                else
                {
                    gobXml.Load(gcrImportArchivoDatos);
                    lobXmlDatos = gobXml.DocumentElement;
                }
                fcvRegCargarXMLDatosObjetos(lobXmlDatos);
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarValoresDatosObjetos: Mostrar valores en vista objetos para la plantilla escritorio
        /// <summary>
        /// <para>Mostrar valores en vista objetos para la plantilla escritorio</para>
        /// <para>desde valores por defecto o digitados en plantilla de datos</para>
        /// </summary>
        public bool flgCargarValoresDatosVistaObjetos()
        {
            var llgReturn = false;
            // Cargar datos digitados en temporal de gestion, "tmpCapturaDatos" para vista
            flgCargarValoresDatosEnTemporal();

            // Cargar valores y popiedades variables publicas cuando hay edicion de datos
            if (gcrDatosModoVista != "V")
            {
                SetPropiedadesVariablesPublicasObjetos("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo);
            }

            // Cargar datos cuando existe una plantilla de datos 
            if (tmpCapturaDatos.Count > 0)
            {
                //MessageBox.Show("aqui voy ");
                // Referenciar posibles objetos nuevos no relacionados en datos historicos (en versiones anteriores del formato)
                flgGestVistaCapturaGenerarNuevoRegistroGex("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo, tmpPlantilla.FirstOrDefault().Codigo);

                //Mostrar valores desde temporal de digitacion, en vista objetos para la plantilla escritorio
                flgGestVistaSetVistaValorDigitadosObjetos(tmpPlantilla.FirstOrDefault().Codigo,"ESCRITORIO");
            }
            else
            {
                // Cargar valores por defecto plantilla escritiorio
                SetVistaValorDefaultObjetos("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo);
                flgGestVistaCapturaGenerarNuevoRegistro("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo, tmpPlantilla.FirstOrDefault().Codigo);
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarValoresDatosEnTemporal: Cargar valores desde base de datos (valores digitados) en temporal de gestion.
        /// <summary>
        /// <para>Cargar valores desde base de datos (valores digitados) en temporal de gestion.</para>
        /// </summary>
        public bool flgCargarValoresDatosEnTemporal()
        {
            var llgReturn = false;
            // Cargar datos cuando existe una plantilla de datos 
            // Cargar digitados desde formatos XML 
            if (!String.IsNullOrEmpty(gcrImportArchivoDatos))
            {
                llgReturn = true;
                XmlElement lobXmlDatos = null;
                if (gcrTipoOrigenArchivo == "BDATOS") // desde base de datos
                {
                    gobXml.LoadXml(gcrImportArchivoDatos);
                    lobXmlDatos = gobXml.DocumentElement;
                }
                else
                {
                    gobXml.Load(gcrImportArchivoDatos);
                    lobXmlDatos = gobXml.DocumentElement;
                }
                fcvRegCargarXMLDatosRegistros(lobXmlDatos);
            }
            // Activar Temporales de gestion cuando el guardado es en tablas
            if (gcrFormatoArchvioGuardarDatos != "XM")
            {
                // Activar temporales de guardado en tablas
                fcvGTablaActivarTablasDatosDigitados("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo);
            }
            // Cargar desde historicos en tablas
            if (gobRegHistorialActivo!= null)
            {
                if (gobRegHistorialActivo.Hcl_archiv_hcev != "XM")
                {
                    var lcrArchivo = gobRegHistorialActivo.Hcl_archiv_hcev.Trim();
                    if (flgGTablaConsultarHistDatosDigitados(lcrArchivo))
                    {
                        // Cargar valores desde historial
                        fcvGTablaGetValorDatosDigitados("OBJETOS", tmpPlantilla.FirstOrDefault().Codigo);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarValoresIniPlantillaDatos: llenar los valores iniciales para plantilla datos
        /// <summary>
        /// <para>Llenar los valores iniciales para plantilla datos, cuando se inicia la digitacion</para>
        /// <para>desde valores por defecto de la plantilla base (es decir no se abrió plantilla de datos digitados)</para>
        /// </summary>
        public bool flgCargarValoresIniPlantillaDatos()
        {
            var llgReturn = false;
            // Iniciar los datos desde plantilla base 
            if (gobRegPropPlantillaDatos == null && tmpPlantilla != null)
            {
                gobRegPropPlantillaDatos = new ClassXmlPropPlanDatos();

                gobRegPropPlantillaDatos.Codigo                 = tmpPlantilla.FirstOrDefault().Codigo;
                gobRegPropPlantillaDatos.Name                   = tmpPlantilla.FirstOrDefault().Name;
                gobRegPropPlantillaDatos.NombreArchivoPlantilla = gcrPlantillaNombreArchivo;
                gobRegPropPlantillaDatos.VersionSistema         = tmpPlantilla.FirstOrDefault().VersionSistema;
                gobRegPropPlantillaDatos.VersionPlantilla       = tmpPlantilla.FirstOrDefault().VersionPlantilla;
                gobRegPropPlantillaDatos.Clave                  = tmpPlantilla.FirstOrDefault().Clave;
                gobRegPropPlantillaDatos.CodigoGrupo            = tmpPlantilla.FirstOrDefault().CodigoGrupo;
                gobRegPropPlantillaDatos.TipoFormato            = "DATOS";
                gobRegPropPlantillaDatos.GenerSecObjeto         = tmpPlantilla.FirstOrDefault().GenerSecObjeto;
                gobRegPropPlantillaDatos.PrefijoObjetos         = tmpPlantilla.FirstOrDefault().PrefijoObjetos + "I";
                gobRegPropPlantillaDatos.SeparadorDecimal       = tmpPlantilla.FirstOrDefault().SeparadorDecimal;
                gobRegPropPlantillaDatos.DatosModoVista         = "E";

                gcrPlantillaPrefijoObjetos = gobRegPropPlantillaDatos.PrefijoObjetos;
                gcrDatosModoVista = gobRegPropPlantillaDatos.DatosModoVista;
                llgReturn = true;
            }
            else
            {
                if (gobRegPropPlantillaDatos != null)
                {
                    gnuPlantillaGenerSecObjeto  = Convert.ToInt32(gobRegPropPlantillaDatos.GenerSecObjeto);
                    gcrPlantillaPrefijoObjetos  = gobRegPropPlantillaDatos.PrefijoObjetos;
                    gcrDatosModoVista           = gobRegPropPlantillaDatos.DatosModoVista;
                }
            }
            // Se cambia el modo vista segun  estado registro del evento
            if (gobRegHistorialActivo != null) { gcrDatosModoVista = gobRegHistorialActivo.Sis_estpro_espr == "1" ? "E" : "V"; }

            return llgReturn;
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION VISTA EVENTOS EN MURO - FILTRO
        //---------------------------------------------------------------
        #region flgVistaHistorialActualizRegistroEvento: actualizar el registro del evento activo 
        /// <summary>
        /// <para>actualizar el registro del evento activo en el historial</para>
        /// </summary>
        public bool flgVistaHistorialActualizRegistroEvento(String tcrIdCodigo)
        {
            var llgReturn = false;
            var lobRegHistorial = HclModeloHistorialEventos.flsBuscarHistorialEventos("HR", tcrIdCodigo);
            if (lobRegHistorial != null)
            {
                var lobReg = lobRegHistorial.FirstOrDefault();
                var lobRegHist = fobRegSelectRegistroHistorial("REGISTRO", tcrIdCodigo);
                if (lobRegHist == null) { return false; }

                llgReturn = true;
                var lobjTitle = lobRegHist.FirstOrDefault().RefObjEvento as TileHistorial;
                if (lobjTitle != null)
                {
                    var lcrUri = "/GestorReportes;component/Imagenes/";
                    if (lobReg.Sis_estpro_espr == "2") // confirmado 
                    {
                        lobjTitle.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_confirmado.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (lobReg.Sis_estpro_espr == "3") // Anulado
                    {
                        lobjTitle.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_anulado.png", UriKind.RelativeOrAbsolute));
                    }
                    // Actualizar el registro temporal
                    var lobHist          = tmpVistaHistorial.FirstOrDefault(x => x.Hcl_nroreg_hcev.Equals(tcrIdCodigo));
                    var lcrServicioFecha = lobReg.Hcl_gesfec_hcev.ToShortDateString();
                    var lcrServicioHora  = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcev.ToString(), "24", gcrSysSeparadorDecimal, ":");

                    lobHist.RefObjEvento    = lobjTitle;
                    lobHist.Hcl_nroreg_hcev = lobReg.Hcl_nroreg_hcev;
                    lobHist.Hcl_secreg_hcev = lobReg.Hcl_secreg_hcev;
                    lobHist.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = lobReg.Cit_codasi_mcit;
                    lobHist.Hcl_gesfec_hcev = lobReg.Hcl_gesfec_hcev;
                    lobHist.Hcl_geshor_hcev = lobReg.Hcl_geshor_hcev;
                    lobHist.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                    lobHist.Grp_idepla_grpl = lobReg.Grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = lobReg.Grp_idepla_grpv;
                    lobHist.Hcl_keydat_hcev = lobReg.Hcl_keydat_hcev;
                    lobHist.Sis_estpro_espr = lobReg.Sis_estpro_espr;

                    // Datos para vista en el Tiles
                    lobjTitle.RegistroEvento    = lobReg.Hcl_nroreg_hcev;
                    lobjTitle.IntRegistroEvento = lobReg.Hcl_secreg_hcev;
                    lobjTitle.txtTitulo.Text    = lobReg.Hcl_nroreg_hcev + " - " + lobReg.Hcl_desreg_hcev;
                    lobjTitle.txtPrograma.Text  = lobReg.Fcm_codcpr_cpro + " " + lobReg.Fcm_descpr_cpro + " - " + lcrServicioFecha + " " + lcrServicioHora;
                    lobjTitle.txtTexto1.Text    = "Profesional: " + lobReg.Sia_codpfa_prof + " " + lobReg.Sia_nompro_prof;
                    lobjTitle.txtTexto2.Text    = "Registro de atención: " + lobReg.Adm_secadm_rgad + " / " + lobReg.Sis_despro_espr;
                    // Objetos para la vista del Evento en Muro
                    if (!String.IsNullOrWhiteSpace(lobReg.Hcl_xmldat_hcev))
                    {
                        gobXml.LoadXml(lobReg.Hcl_xmldat_hcev);
                        XmlElement lobXmlDatos = gobXml.DocumentElement;
                        fcvRegCargarXMLDatosObjHistorial(ref lobjTitle, lobXmlDatos);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvVistaHistorialFiltro: filtro acercado del historial de eventos en el muro
        /// <summary>
        /// <para>filtro acercado del historial de eventos en el muro, oculta los eventos que </para>
        /// <para>no cumplen con el parametro texto del filtro.</para>
        /// </summary>
        public void fcvVistaHistorialFiltro(String tcrTexto)
        {
            if (tmpVistaHistorial == null || tmpVistaHistorial.Count == 0) { return; }

            var lcrTexto = tcrTexto.ToLower();
            // Ocultar Admision y titulos grupos 
            foreach (var lobReg in tmpVistaHistAdmi)
            {
                lobReg.RegistroVisible = String.IsNullOrWhiteSpace(lcrTexto) ? "1" : "2";
            }

            TileHistorial lobTile = null;
            foreach (var lobReg in tmpVistaHistorial)
            {
                lobTile = null;

                if (lobReg.GestionEstadoRegistro == "OK")
                {
                    lobTile = lobReg.RefObjEvento as TileHistorial;
                    lobTile.stkHistorial.Visibility = Visibility.Collapsed;
                    lobTile.Visibility = Visibility.Visible;
                }

                if (!String.IsNullOrWhiteSpace(tcrTexto))
                {
                    if (lobReg.Hcl_keydat_hcev != null)
                    {
                        if (!lobReg.Hcl_keydat_hcev.Contains(lcrTexto))
                        {
                            if (lobTile != null) { lobTile.Visibility = Visibility.Collapsed; }
                        }
                        else
                        {
                            // Activar el grupo admision y gurpo fecha
                           var lobRegAdm = tmpVistaHistAdmi.FirstOrDefault(x => x.Adm_secadm_rgad == lobReg.Adm_secadm_rgad &&
                                                            x.TipoRegistro == "ADM");
                           if (lobRegAdm != null) { lobRegAdm.RegistroVisible = "1"; }

                           var lobRegFec = tmpVistaHistAdmi.FirstOrDefault(x => x.Adm_secadm_rgad == lobReg.Adm_secadm_rgad &&
                                                            x.Hcl_gesfec_hcev == lobReg.Hcl_gesfec_hcev && x.TipoRegistro == "DAT");
                           if (lobRegFec != null) { lobRegFec.RegistroVisible = "1"; }
                        }
                    }
                    else
                    {
                        if (lobTile != null) { lobTile.Visibility = Visibility.Collapsed; }
                    }
                }
            }
            // Mostrar/ocultar titulos de grupos
            foreach (var lobReg in tmpVistaHistAdmi)
            {

                if (lobReg.TipoRegistro == "ADM")
                {
                    var lobObjAdm = lobReg.RefObjAdm as TileAdmision;
                    if (lobObjAdm != null)
                    {
                        lobObjAdm.Visibility = lobReg.RegistroVisible == "1" ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
                if (lobReg.TipoRegistro == "DAT")
                {
                    var lobObjFec = lobReg.RefObjFecha as TileAdmisionFecha;
                    if (lobObjFec != null)
                    {
                        lobObjFec.Visibility = lobReg.RegistroVisible == "1" ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            }
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION REGISTRO DE DATOS Y VISTA OBJETOS PARA PLANTILLAS 
        //---------------------------------------------------------------
        // Generar nuevos valores para una plantilla y etiqueta /escritorio
        #region flgGestVistaCapturaGenerarNuevoRegistro: Genera nuevamente el temporal de datos
        /// <summary>
        /// <para>Recorre temporal de objetos para generar registros tipo campo valores para una plantilla</para>
        /// <para>la cual puede ser el escritorio o una plantilla tipo etiqueta de datos (en la capa etiquetas)</para>
        /// <para>tcrCodigoPlantilla:</para>
        /// <para>Codigo de la plantilla cargada en el archivo de objetos (tcrArchivoOrigen) para la cual se generaran los registros</para>
        /// <para>tcrIgGrupoRegistro:</para>
        /// <para>Puede ser el IG del escritorio o nombre del objeto que asocia los registros como etiqueta de datos</para>
        /// </summary>
        public bool flgGestVistaCapturaGenerarNuevoRegistro(String tcrArchivoOrigen, String tcrCodigoPlantilla, String tcrIgGrupoRegistro)
        {
            var llgValor = false;
            var lobDatos = new ClassXmlPropDatos();
            var lobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);

            foreach (var lobItem in lobTemp)
            {
                llgValor = true;
                if (!String.IsNullOrWhiteSpace(lobItem.NombreVariable))
                {
                    lobDatos = new ClassXmlPropDatos();
                    lobDatos.IgGrupoRegistro = tcrIgGrupoRegistro;

                    // Valores por defecto para chckbox
                    if (lobItem.TipoObjeto == "CHECKBOX" || lobItem.TipoObjeto == "MULTICHKBOX")
                    {
                        lobItem.ValorDefault = lobItem.ValorDefault == "True" || lobItem.ValorDefault == "1" ? "1" : "2";
                    }

                    fcvGestVistaCapturaSetPropiedadRegistro(ref lobDatos, lobItem);
                    
                    // Valores especiales 
                    if (lobItem.TipoObjeto == "TEXTBOXTIME")
                    {
                        // Es la hora del sistema por defecto en valor default
                        if (lobItem.HoraDefault == "2")
                        {
                            lobDatos.Valor = Funciones.fcrHoraActual("24", ".");
                            lobItem.ValorDefault = lobDatos.Valor;
                        }
                    }
                    else if (lobItem.TipoObjeto == "TEXTBOXDATE")
                    {
                        // Es la fecha del sistema por defecto en valor default
                        if (lobItem.FechaDefault == "2")
                        {
                            lobDatos.Valor = Funciones.fcrFechaActual();
                            lobItem.ValorDefault = lobDatos.Valor;
                        }
                    }
                    else if (lobItem.TipoObjeto == "COMBOBOX")
                    {
                        lobDatos.ValorDescripcion = fcrSetVistaValorObjComboBoxDes(lobItem.Name, lobDatos.Valor);
                    }
                    tmpCapturaDatos.Add(lobDatos);
                }
            }
            return llgValor;
        }
        #endregion
        // Generar nuevos valores para objetos no registrados en datos historicos de versiones anteriores
        #region flgGestVistaCapturaGenerarNuevoRegistroGex: Generar nuevos valores para objetos no registrados en datos historicos
        /// <summary>
        /// <para>Generar nuevos valores en temporal de datos digitados, para efectos de compatibilidad,</para>
        /// <para>con nuevos objetos no aparecen registrados en datos historicos digitados con versiones anteriores del formato</para>
        /// <para>Recorre temporal de objetos para generar registros tipo campo valores para una plantilla</para>
        /// <para>la cual puede ser el escritorio o una plantilla tipo etiqueta de datos (en la capa etiquetas)</para>
        /// <para>tcrCodigoPlantilla:</para>
        /// <para>Codigo de la plantilla cargada en el archivo de objetos (tcrArchivoOrigen) para la cual se generaran los registros</para>
        /// <para>tcrIgGrupoRegistro:</para>
        /// <para>Puede ser el IG del escritorio o nombre del objeto que asocia los registros como etiqueta de datos</para>
        /// </summary>
        public bool flgGestVistaCapturaGenerarNuevoRegistroGex(String tcrArchivoOrigen, String tcrCodigoPlantilla ,String tcrIgGrupoRegistro)
        {
            var llgValor = false;
            var lobDatos = new ClassXmlPropDatos();
            var lobTemp  = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);

            foreach (var lobItem in lobTemp)
            {
                llgValor = true;
                if (!String.IsNullOrWhiteSpace(lobItem.NombreVariable)) // Solo objetos para captura de datos
                {
                    var lobRegEx = tmpCapturaDatos.FirstOrDefault(x => x.Name == lobItem.Name);

                    // cuando no existele objeto se agrega al temporal de datos digitados
                    if (lobRegEx == null)
                    {
                        lobDatos = new ClassXmlPropDatos();
                        lobDatos.IgGrupoRegistro = tcrIgGrupoRegistro;

                        // Valores por defecto para chckbox
                        if (lobItem.TipoObjeto == "CHECKBOX" || lobItem.TipoObjeto == "MULTICHKBOX")
                        {
                            lobItem.ValorDefault = lobItem.ValorDefault == "True" || lobItem.ValorDefault == "1" ? "1" : "2";
                        }

                        fcvGestVistaCapturaSetPropiedadRegistro(ref lobDatos, lobItem);

                        // Valores especiales 
                        if (lobItem.TipoObjeto == "TEXTBOXTIME")
                        {
                            // Es la hora del sistema por defecto en valor default
                            if (lobItem.HoraDefault == "2")
                            {
                                lobDatos.Valor = Funciones.fcrHoraActual("24", ".");
                                lobItem.ValorDefault = lobDatos.Valor;
                            }
                        }
                        else if (lobItem.TipoObjeto == "TEXTBOXDATE")
                        {
                            // Es la fecha del sistema por defecto en valor default
                            if (lobItem.FechaDefault == "2")
                            {
                                lobDatos.Valor = Funciones.fcrFechaActual();
                                lobItem.ValorDefault = lobDatos.Valor;
                            }
                        }
                        else if (lobItem.TipoObjeto == "COMBOBOX")
                        {
                            lobDatos.ValorDescripcion = fcrSetVistaValorObjComboBoxDes(lobItem.Name, lobDatos.Valor);
                        }

                        tmpCapturaDatos.Add(lobDatos);
                    }
                }
            }
            return llgValor;
        }
        #endregion
        // Asignar propiedades del objeto al nuevo registro temporal de captura
        #region fcvGestVistaCapturaSetPropiedadRegistro: Asiganr propiedades del objeto al nuevo registro temporal de captura
        /// <summary>
        /// <para>Asignar propiedades del objeto al nuevo registro temporal de captura</para>
        /// </summary>
        public void fcvGestVistaCapturaSetPropiedadRegistro(ref ClassXmlPropDatos tobRegistro, ClassXmlPropObjeto tobObjeto)
        {
            #region Asignar valores
            tobRegistro.RefObjeto          = tobObjeto.RefObjeto;
            tobRegistro.Navegador          = tobObjeto.Navegador;
            tobRegistro.CodigoPlantilla    = tobObjeto.CodigoPlantilla;
            tobRegistro.Name               = tobObjeto.Name;
            tobRegistro.Titulo             = tobObjeto.Titulo;
            tobRegistro.TipoObjeto         = tobObjeto.TipoObjeto;
            tobRegistro.ClaseBase          = tobObjeto.ClaseBase;
            tobRegistro.Parent             = tobObjeto.Parent;
            tobRegistro.SiFiltroBusqueda   = tobObjeto.SiFiltroBusqueda;
            tobRegistro.Binding            = tobObjeto.Binding;
            tobRegistro.BindingTabla       = tobObjeto.BindingTabla;
            tobRegistro.BindingDescripcion = tobObjeto.BindingDescripcion;
            tobRegistro.ValorDefault       = tobObjeto.ValorDefault;
            tobRegistro.Valor              = fcrSetVistaValorParaCargarUserControl(tobRegistro.TipoObjeto, tobObjeto.ValorDefault);
            tobRegistro.Indice             = tobObjeto.Indice;
            tobRegistro.CampoReporte       = tobObjeto.CampoReporte;
            tobRegistro.TipoDato           = tobObjeto.TipoDato;
            tobRegistro.TipoOrigenDatos    = tobObjeto.TipoOrigenDatos;
            tobRegistro.TablaOrigen        = tobObjeto.TablaOrigen;
            tobRegistro.IdRegistro         = tobObjeto.ObjetoParentZona;
            tobRegistro.NombreVariable     = tobObjeto.NombreVariable;
            // Datos archivos de recurso
            tobRegistro.RecursoArchivoTipo   = tobObjeto.RecursoArchivoTipo;
            tobRegistro.RecursoArchivoCodigo = tobObjeto.RecursoArchivoCodigo;
            tobRegistro.RecursoArchivoUri    = tobObjeto.RecursoArchivoUri;
            tobRegistro.RecursoArchivoNombre = tobObjeto.RecursoArchivoNombre;
            #endregion
        }
        #endregion
        //---------------------------------------------------------------
        // Mostrar valores por defecto o digitados
        //---------------------------------------------------------------
        #region flgGestVistaSetVistaValorDigitadosObjetos: Mostrar valores en objeto desde temporal datos digitados
        /// <summary>
        /// <para>Mostrar valores en objeto desde temporal datos digitados</para>
        /// </summary>
        public bool flgGestVistaSetVistaValorDigitadosObjetos(String tcrIgGrupoRegistro, String tcrTipoNavegador)
        {
            var llgReturn = false;
            ClassXmlPropObjeto lobObjBas = null;

            // Ver si son etiquetas
            if (tcrTipoNavegador == "ETIQUETA")
            {
                tmpCapturaEtiqueta = fobRegSelectParentRegistro("DATOS","PLANTILLA", tcrIgGrupoRegistro);
            }
            var tobTemp = fobRegSelectParentRegistro("DATOS","PLANTILLA", tcrIgGrupoRegistro);

            foreach (var lobItem in tobTemp)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.NombreVariable))
                {
                    llgReturn = true;
                    #region objetos
                    //lobItem.ValorDefault
                    lobObjBas = fobRegSelectParenObjeto("OBJETOS", "", lobItem.Name).FirstOrDefault();
                    if (lobObjBas != null)
                    {
                        // Referenciar propiedades del objeto en temporal de datos
                        lobItem.RefObjeto        = lobObjBas.RefObjeto;
                        lobItem.Titulo           = lobObjBas.Titulo;
                        lobItem.TipoObjeto       = lobObjBas.TipoObjeto;
                        lobItem.ClaseBase        = lobObjBas.ClaseBase;
                        lobItem.Parent           = lobObjBas.Parent;
                        lobItem.SiFiltroBusqueda = lobObjBas.SiFiltroBusqueda;
                        lobItem.Binding          = lobObjBas.Binding;
                        lobItem.ValorDefault     = lobObjBas.ValorDefault;
                        lobItem.VariablePublica  = lobObjBas.VariablePublica;

                        switch (lobObjBas.TipoObjeto)
                        {
                            case "TEXTBOX":
                                SetVistaValorObjTexBox(lobItem.Name, lobItem.Valor);
                                break;

                            case "RICHTEXTBOX":
                                SetVistaValorObjRichTextBox(lobItem.Name, lobItem.Valor);
                                break;

                            case "COMBOBOX":
                                var lcrValor = gcrDatosModoVista != "V" ? lobItem.Valor : lobItem.ValorDescripcion;
                                SetVistaValorObjComboBox(lobItem.Name, lcrValor);
                                break;

                            case "CHECKBOX":
                                SetVistaValorObjCheckBox(lobItem.Name, lobItem.Valor);
                                break;

                            case "TEXTBOXRELCOD":
                                SetVistaValorObjTexBoxRelCod(lobItem.Name, lobItem.Valor);
                                break;

                            case "TEXTBOXRELDES":
                                SetVistaValorObjTexBoxRelCod(lobItem.Name, lobItem.Valor);
                                break;

                            case "MULTIGROUPRADIOBUTTON":
                                SetVistaValorObjMultiGrupoRadioButton(lobItem.Name, lobItem.Valor);
                                break;

                            case "MULTICHKBOX":
                                SetVistaValorObjCheckBox(lobItem.Name, lobItem.Valor);
                                break;
                        }
                        if (lobObjBas.ClaseBase == "UserControl")
                        {
                            if (String.IsNullOrWhiteSpace(lobItem.Valor))
                            {
                                lobItem.Valor = fcrSetVistaValorParaCargarUserControl(lobObjBas.TipoObjeto, lobItem.ValorDefault);
                            }
                            //MessageBox.Show("aqui voy - valores digitados ");
                            SetVistaValorObjUserControl(lobItem.Name, lobItem.Valor, "DIGITADO");
                        }

                        // cargar valores de Variables especiales
                        if (lobItem.VariablePublica == "HOSPIT_RESUM_EVOLUCI_NOTASMED")
                        {
                            // siempre desde el registro historial para no tomar de la admision activa, porque es posible que no sea 
                            // el mismo numero de admision
                            var lcrCodigoAdmision = gobRegHistorialActivo != null ? gobRegHistorialActivo.Adm_secadm_rgad : String.Empty;

                            lobItem.Valor = SetValoVarPublicaEvolucionMedica("EVOL", lcrCodigoAdmision);
                        }

                    }
                    #endregion
                }
            }
            // Cargar valores en objetos que no se relacionan en el XML de datos
            foreach (var lobItem in tmpObjetos)
            {
                switch (lobItem.TipoObjeto)
                {

                    case "AUTORIZAREGRESO":
                        // no por ahora 
                        break;

                    case "CONTROLADMISION":
                        //var lobObjAdm = lobObjeto.RefObjeto as ControlVistaAdmision;
                        //lobObjAdm.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLFIRMAPROFESIONAL":

                        var lobObjFirm = lobItem.RefObjeto as ControlFirmaProfesional;
                        var lcrCodigoPorfesional = SetVistaValorCodigoProfesionalQueFirma(gobRegHistorialActivo);

                        if (gobRegHistorialActivo != null && lobObjFirm != null)
                        {
                            lobObjFirm.fcvCargarVista(lcrCodigoPorfesional);
                        }
                        break;
                }
            }
            return llgReturn;
        }
        #endregion
        #region SetVistaValorDefaultObjetos: Mostrar valores en objeto segun ValorDefault (Para nueva captura de datos)
        /// <summary>
        /// <para>Recorre temporal de objetos y segun el tipo de objeto activa el valor existente en  ValorDefault</para>
        /// <para>tcrArchivoOrigen: "OBJETOS"/"AUXILIAR"/"ELIMINADOS"</para>
        /// <para>es util para cuando se pretende crear una nueva captura  de datos en la vista.</para>
        /// </summary>
        public void SetVistaValorDefaultObjetos(String tcrArchivoOrigen, String tcrCodigoPlantilla)
        {
            var tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);

            foreach (var lobItem in tobTemp)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.NombreVariable))
                {
                    #region objetos
                    //lobItem.ValorDefault
                    switch (lobItem.TipoObjeto)
                    {
                        case "TEXTBOX":
                            SetVistaValorObjTexBox(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "RICHTEXTBOX":
                            SetVistaValorObjRichTextBox(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "COMBOBOX":
                            SetVistaValorObjComboBox(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "CHECKBOX":
                            SetVistaValorObjCheckBox(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "TEXTBOXRELCOD":
                            SetVistaValorObjTexBoxRelCod(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "TEXTBOXRELDES":
                            // no por ahora 
                            break;

                        case "MULTIGROUPRADIOBUTTON":
                            SetVistaValorObjMultiGrupoRadioButton(lobItem.Name, lobItem.ValorDefault);
                            break;

                        case "MULTICHKBOX":
                            SetVistaValorObjCheckBox(lobItem.Name, lobItem.ValorDefault);
                            break;
                    }
                    #endregion
                    if (lobItem.ClaseBase == "UserControl")
                    {
                        var lcrValor = fcrSetVistaValorParaCargarUserControl(lobItem.TipoObjeto, lobItem.ValorDefault);
                        SetVistaValorObjUserControl(lobItem.Name, lcrValor,"DEFAULT");
                    }
                }
            }
        }
        #endregion
        #region fcrSetVistaValorParaCargarUserControl: Seleccionar el tipo de valor para mostrar en objeto UserControl
        /// <summary>
        /// <para>Seleccionar el tipo de valor para mostrar en objeto UserControl</para>
        /// </summary>
        public String fcrSetVistaValorParaCargarUserControl(String tcrTipoObjeto, String tcrValor)
        {
            var lcrCodigoAdmision = tmpRegAdmision != null ? tmpRegAdmision.Adm_secadm_rgad : String.Empty;
            var lcrValorReturn = tcrValor;
            switch (tcrTipoObjeto)
            {
                case "CONTROLORDENSERVMED":
                    // no por ahora 
                    break;

                case "CONTROLNOTAENFERMERIA":
                    // no por ahora 
                    break;

                case "CONTROLTRIAGE":
                    lcrValorReturn = gobRegHistorial.Hcl_codaux_hcev;
                    break;

                case "CONTROLUSUATENDIDO":
                    lcrValorReturn = tmpUsuarioAtendido.Sia_idesec_usua;
                    break;

                case "AUTORIZAREGRESO":
                    // no por ahora 
                    break;

                case "CONTROLCAPTURA":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLADMISION":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLFRAMINGHAM":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLEADAUDICIONLENGUAJE":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLEADMOTRICIFINOADAPT":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLEADMOTRICIGRUESA":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLEADPERSONALSOCIAL":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLEADGRAFPUNTUACION":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;

                case "CONTROLFIRMAPROFESIONAL":

                    lcrValorReturn = SetVistaValorCodigoProfesionalQueFirma(gobRegHistorialActivo);
                    break;

                case "CONTROLHOJAADMISION":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;
                    
                case "CONTROLADMITIDO":
                    lcrValorReturn = SetVistaValorCodigoAdmisionActiva();
                    break;
            }
            return lcrValorReturn;
        }
        #endregion
        #region SetVistaValorObjTexBox: Mostrar valores en objeto TextBox
        /// <summary>
        /// <para>Mostrar valores en objeto TextBox</para>
        /// </summary>
        public void SetVistaValorObjTexBox(String tcrNombre, String tcrValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                var lobObj = lobObjeto.RefObjeto as TextBox;
                lobObj.Text = tcrValor;

                // Cuando hay variable publica, verificar si el campo es de solo lectura 
                if (lobObjeto.PropVarPublica != null)
                {
                    var ob = lobObjeto.PropVarPublica;
                    if (ob.Hcl_camdig_hcvr == "2")
                    {
                        //lobObj.IsReadOnly = true;
                    }
                }
            }
        }
        #endregion
        #region SetVistaValorObjRichTextBox: Mostrar valores en objeto RichTextBox
        /// <summary>
        /// <para>Mostrar valores en objeto RichTextBox</para>
        /// </summary>
        public void SetVistaValorObjRichTextBox(String tcrNombre, String tcrValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                var lobObj = lobObjeto.RefObjeto as RichTextBox;
                TextRange textRange = new TextRange(lobObj.Document.ContentStart, lobObj.Document.ContentEnd);
                textRange.Text = tcrValor != null ? tcrValor : "";

                // Cuando hay variable publica, verificar si el campo es de solo lectura 
                if (lobObjeto.PropVarPublica != null)
                {
                    var ob = lobObjeto.PropVarPublica;
                    if (ob.Hcl_camdig_hcvr == "2")
                    {
                        //lobObj.IsReadOnly = true;
                    }
                }

            }
        }
        #endregion
        #region SetVistaValorObjComboBox: Mostrar valores en objeto ComboBox
        /// <summary>
        /// <para>Mostrar valores en objeto ComboBox</para>
        /// </summary>
        public void SetVistaValorObjComboBox(String tcrNombre, String tcrValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                if (gcrDatosModoVista != "V")
                {
                    ClassXmlComboBoxItems lobReg = null;
                    var lnuIndex = 0;
                    var lobRegTm = fobRegSelectParenComboBoxItems(tcrNombre, tcrValor);

                    lobReg = lobRegTm != null ? lobRegTm.FirstOrDefault() : null;
                    if (lobReg != null) { lnuIndex = Convert.ToInt32(lobReg.Indice) - 1; }

                    var lobObj = lobObjeto.RefObjeto as ComboBox;
                    lobObj.SelectedIndex = lnuIndex;
                    // Cuando hay variable publica, verificar si el campo es de solo lectura 
                    if (lobObjeto.PropVarPublica != null)
                    {
                        var ob = lobObjeto.PropVarPublica;
                        if (ob.Hcl_camdig_hcvr == "2")
                        {
                            //lobObj.IsEnabled = false;
                        }
                    }
                }
                else
                {
                    SetVistaValorObjTexBox(tcrNombre, tcrValor);
                }
            }
        }
        #endregion
        #region fcrSetVistaValorObjComboBoxDes: Mostrar Descripción del valor seleccionado en un combobox
        /// <summary>
        /// <para>Mostrar Descripción del valor seleccionado en un combobox</para>
        /// </summary>
        public String fcrSetVistaValorObjComboBoxDes(String tcrNombre, String tcrCodigo)
        {
            var lcrReturn = String.Empty;
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                ClassXmlComboBoxItems lobReg = null;
                var lobRegTm = fobRegSelectParenComboBoxItems(tcrNombre, tcrCodigo);

                lobReg = lobRegTm != null ? lobRegTm.FirstOrDefault() : null;
                if (lobReg != null) { lcrReturn = lobReg.Descripcion; }
            }
            return lcrReturn;
        }
        #endregion
        #region SetVistaValorObjCheckBox: Mostrar valores en objeto CheckBox
        /// <summary>
        /// <para>Mostrar valores en objeto CheckBox</para> 
        /// </summary>
        public void SetVistaValorObjCheckBox(String tcrNombre, String tcrValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                if (gcrDatosModoVista != "V")
                {
                    var lobObj = lobObjeto.RefObjeto as CheckBox;
                    lobObj.IsChecked = tcrValor == "True" || tcrValor == "1" ? true : false;
                    // Cuando hay variable publica, verificar si el campo es de solo lectura 
                    if (lobObjeto.PropVarPublica != null)
                    {
                        var ob = lobObjeto.PropVarPublica;
                        if (ob.Hcl_camdig_hcvr == "2")
                        {
                            //lobObj.IsEnabled = false;
                        }
                    }
                }
                else
                {
                    var Contenedor = lobObjeto.RefObjeto as Canvas;
                    SetVistaValorOkChkRbutton(ref Contenedor, tcrValor);
                }
            }
        }
        #endregion
        #region SetVistaValorObjTexBoxRelCod: Mostrar valores en objeto TextBoxRelCod
        // Se supone que el TextChanged hace el resto para buscar en la tabla relacionada
        /// <summary>
        /// <para>Mostrar valores en objeto TextBoxRelCod</para>
        /// </summary>
        public void SetVistaValorObjTexBoxRelCod(String tcrNombre, String tcrValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                var lobObj = lobObjeto.RefObjeto as TextBox;
                lobObj.Text = tcrValor;
                // Cuando hay variable publica, verificar si el campo es de solo lectura 
                if (lobObjeto.PropVarPublica != null)
                {
                    var ob = lobObjeto.PropVarPublica;
                    if (ob.Hcl_camdig_hcvr == "2")
                    {
                        /*
                        lobObj.IsReadOnly = true;
                        // Buscar y olcultar el boton que muestra el Browser
                        var lobObjBas = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.Parent).FirstOrDefault();
                        var lobObjBtn = fobRegSelectParenObjeto("OBJETOS", "BUTTON", lobObjBas.Name).FirstOrDefault();

                        var lobButton = lobObjBtn.RefObjeto as Button;
                        lobButton.Visibility = Visibility.Collapsed;
                        */
                    }
                }
            }
        }
        #endregion
        #region SetVistaValorObjMultiGrupoRadioButton: Mostrar valores en objeto MultiGrupoRadioButton
        /// <summary>
        /// <para>Mostrar valores en objeto MultiGrupoRadioButton</para>
        /// </summary>
        public void SetVistaValorObjMultiGrupoRadioButton(String tcrNombre, String tcrValor)
        {
            RadioButton lobObj = null;
            RadioButton lobOpc1 = null;
            Canvas lobCanvas = null;
            Canvas lobCanvas1 = null;
            var llgSiValor = false;

            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            var lobObjOpc = fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNombre);

            foreach (ClassXmlPropObjeto lobReg in lobObjOpc)
            {
                if (lobReg.ClaseBase == "RadioButton")
                {
                    if (gcrDatosModoVista != "V")
                    {
                        lobObj = lobReg.RefObjeto as RadioButton;

                        if (lobOpc1 == null) { lobOpc1 = lobObj; }
                        if (lobReg.Indice == tcrValor)
                        {
                            lobObj.IsChecked = true;
                            llgSiValor = true;
                        }
                        else
                        {
                            lobObj.IsChecked = false;
                        }
                        // Cuando hay variable publica, verificar si el campo es de solo lectura 
                        if (lobObjeto.PropVarPublica != null)
                        {
                            var ob = lobObjeto.PropVarPublica;
                            if (ob.Hcl_camdig_hcvr == "2")
                            {
                                //lobObj.IsEnabled = false;
                            }
                        }
                    }
                    else 
                    {
                        lobCanvas = lobReg.RefObjeto as Canvas;

                        if (lobCanvas1 == null) { lobCanvas1 = lobCanvas; }
                        if (lobReg.Indice == tcrValor)
                        {
                            SetVistaValorOkChkRbutton(ref lobCanvas, "True");
                            llgSiValor = true;
                        }
                    }
                }
            }
            //- Para finalizar
            if (gcrDatosModoVista != "V")
            {
                if (llgSiValor == false && lobOpc1 != null)
                {
                    lobOpc1.IsChecked = true; // el primero cuando no se encontro tcrValor
                }
            }
            else 
            {
                if (llgSiValor == false && lobCanvas1 != null)
                {
                    SetVistaValorOkChkRbutton(ref lobCanvas1, "True"); // el primero cuando no se encontro tcrValor
                }
            }
        }
        #endregion
        #region SetVistaValorOkChkRbutton: Mostrar valores Ok seleccion en objetos CheckBox y Radiobutton
        /// <summary>
        /// <para>Mostrar valores Ok seleccion en objetos CheckBox y Radiobutton</para> 
        /// </summary>
        public void SetVistaValorOkChkRbutton(ref Canvas tobObjeto, String tcrValor)
        {
            if (tcrValor == "True" || tcrValor == "1")
            {
                var lcrUri = "/GestorReportes;component/Imagenes/";

                Image lobObjImagen = new Image();
                lobObjImagen.Name = "imgImagnOK" + tobObjeto.Name;
                lobObjImagen.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_selectok.png", UriKind.RelativeOrAbsolute));
                lobObjImagen.Height = 10;
                lobObjImagen.Width = 10;

                Canvas.SetLeft(lobObjImagen, 2);
                Canvas.SetTop(lobObjImagen, 2);
                tobObjeto.Children.Add(lobObjImagen);
            }
        }
        #endregion
        #region SetVistaValorObjUserControl: Mostrar valores en objeto UserControl
        /// <summary>
        /// <para>Mostrar valores en objeto UserControl</para>
        /// </summary>
        public void SetVistaValorObjUserControl(String tcrNombre, String tcrValor,String tcrTipoOrigenValor)
        {
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombre).FirstOrDefault();
            if (lobObjeto != null)
            {
                switch (lobObjeto.TipoObjeto)
                {

                    case "AUTORIZAREGRESO":
                        // no por ahora 
                        break;

                    case "CONTROLADMISION":
                        var lobObjAdm = lobObjeto.RefObjeto as ControlVistaAdmision;
                        lobObjAdm.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLFRAMINGHAM":
                        #region datos
                        var lobObjFrmg = lobObjeto.RefObjeto as ControlVistaFramingHam;
                        lobObjFrmg.lcrModoVistaObjeto = gcrDatosModoVista;
                        if (tcrTipoOrigenValor == "DEFAULT")
                        {
                            lobObjFrmg.txtFrgSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                            lobObjFrmg.txtFrgSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();

                            lobObjFrmg.fcvCargarVista("");
                        }
                        else
                        {
                            lobObjFrmg.fcvCargarVista(tcrValor);
                            if (String.IsNullOrWhiteSpace(lobObjFrmg.txtFrgSis_codsex_sexo.Text))
                            {
                                lobObjFrmg.txtFrgSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                                lobObjFrmg.txtFrgSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                            }
                        }
                        #endregion
                        break;

                    case "CONTROLIMC":
                        var lobObjIMC = lobObjeto.RefObjeto as ControlVistaImc;
                        lobObjIMC.lcrModoVistaObjeto = gcrDatosModoVista;
                        lobObjIMC.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLEADAUDICIONLENGUAJE":
                        SetVistaValorEdadSexoTestEscalaAbreviada(ref lobObjeto, tcrValor, tcrTipoOrigenValor);
                        break;

                    case "CONTROLEADMOTRICIFINOADAPT":
                        SetVistaValorEdadSexoTestEscalaAbreviada(ref lobObjeto, tcrValor, tcrTipoOrigenValor);
                        break;

                    case "CONTROLEADMOTRICIGRUESA":
                        SetVistaValorEdadSexoTestEscalaAbreviada(ref lobObjeto, tcrValor, tcrTipoOrigenValor);
                        break;

                    case "CONTROLEADPERSONALSOCIAL":
                        //MessageBox.Show("aqui voy ps " + tcrValor);
                        SetVistaValorEdadSexoTestEscalaAbreviada(ref lobObjeto, tcrValor, tcrTipoOrigenValor);
                        break;

                    case "CONTROLEADGRAFPUNTUACION":
                        SetVistaValorEdadSexoTestEscalaAbreviada(ref lobObjeto, tcrValor, tcrTipoOrigenValor);
                        break;

                    case "CONTROLFIRMAPROFESIONAL":
                        var lobObjFirm = lobObjeto.RefObjeto as ControlFirmaProfesional;
                        lobObjFirm.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLCAPTURA":
                        var lobObjCap = lobObjeto.RefObjeto as ControlCaptura;
                        lobObjCap.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLHOJAADMISION":
                        var lobObjHojaAdm = lobObjeto.RefObjeto as ControlHojaAdmision;
                        lobObjHojaAdm.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLTRIAGE":
                        var lobObjTriage = lobObjeto.RefObjeto as ControlVistaTriage;
                        lobObjTriage.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLUSUATENDIDO":
                        var lobObjUsuAten = lobObjeto.RefObjeto as ControlUsuarioAtendido;
                        lobObjUsuAten.fcvCargarVista(tcrValor);
                        break;

                    case "CONTROLADMITIDO":
                        var lobObjAdt = lobObjeto.RefObjeto as ControlVistaAdmitido;
                        lobObjAdt.fcvCargarVista(tcrValor);
                        break;

                    case "TEXTBOXTIME":
                        #region datos
                        if (gcrDatosModoVista != "V")
                        {
                            var lcrValor = tcrValor;
                            // Es la hora del sistema por defecto en valor default
                            if (lobObjeto.HoraDefault == "2" && tcrTipoOrigenValor == "DEFAULT")
                            {
                                lcrValor = Funciones.fcrHoraActual("24", ".");
                            }

                            var lobObjHora = lobObjeto.RefObjeto as ControlHora;
                            lobObjHora.fcvCargarHora(lcrValor);
                            // Cuando hay variable publica, verificar si el campo es de solo lectura 
                            if (lobObjeto.PropVarPublica != null)
                            {
                                var ob = lobObjeto.PropVarPublica;
                                if (ob.Hcl_camdig_hcvr == "2")
                                {
                                    //lobObjHora.txtHora.IsReadOnly= true;
                                }
                            }

                        }
                        else 
                        {
                            var lobObjHora = lobObjeto.RefObjeto as TextBox;
                            lobObjHora.Text = Funciones.fcrConvierteHora(tcrValor, "24", ".", ":");
                        }
                        #endregion
                        break;

                    case "TEXTBOXDATE":
                        #region Datos
                        if (gcrDatosModoVista != "V")
                        {
                            var lcrValor = tcrValor;
                            var lcrValorDefect = String.Empty;

                            // Vaidar la fecha dada en valor por defecto
                            if (!String.IsNullOrWhiteSpace(lobObjeto.ValorDefault))
                            {
                                var lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", lobObjeto.ValorDefault, "Valor tipo Fecha");
                                if (String.IsNullOrWhiteSpace(lcrValorReturn)) { lcrValorDefect = lobObjeto.ValorDefault; }

                            }
                            // si hay valor por defecto fecha
                            if (!String.IsNullOrWhiteSpace(lcrValorDefect) && tcrTipoOrigenValor == "DEFAULT")
                            {
                                lcrValor = lcrValorDefect;
                            }
                            else if (lobObjeto.FechaDefault == "2" && tcrTipoOrigenValor == "DEFAULT")
                            {
                                // Es la fecha del sistema por defecto en valor default
                                lcrValor = Funciones.fcrFechaActual();
                            }

                            var lobObjFecha = lobObjeto.RefObjeto as ControlFecha;
                            lobObjFecha.txtFechaVista.Text = lcrValor;
                            if (lobObjeto.PropVarPublica != null)
                            {
                                var ob = lobObjeto.PropVarPublica;
                                if (ob.Hcl_camdig_hcvr == "2")
                                {
                                    //lobObjFecha.txtFechaVista.IsReadOnly = true;
                                    //lobObjFecha.dpkFecha.IsEnabled = false;
                                }
                            }
                        }
                        else 
                        {
                            var lobObjFecha = lobObjeto.RefObjeto as TextBox;
                            lobObjFecha.Text = tcrValor;
                        }
                        #endregion
                        break;
                }
            }
        }
        #endregion
        #region SetVistaValorCodigoAdmisionActiva: Devolver codigo admision activa
        /// <summary>
        /// <para>Devolver codigo admision activa segun el estado del registro</para>
        /// <para>Cuando es captura nuevo registro, se toma codigo admision activa en vista historial clinico.</para>
        /// </summary>
        public String SetVistaValorCodigoAdmisionActiva()
        {
            var lcrValorReturn = String.Empty;

            if (tmpRegAdmision != null) { lcrValorReturn = tmpRegAdmision.Adm_secadm_rgad; }
            if (gobRegHistorial != null)
            {
                lcrValorReturn = !String.IsNullOrWhiteSpace(gobRegHistorial.Adm_secadm_rgad) ?
                                  gobRegHistorial.Adm_secadm_rgad : lcrValorReturn;
            }
            // Cuando es captura nuevo registro, se toma la admision activa en vista historial clinico
            if (glgNuevoRegistroPlantilla == true)
            {
                if (tmpRegAdmision != null) { lcrValorReturn = tmpRegAdmision.Adm_secadm_rgad; }
            }
            return lcrValorReturn;
        }
        #endregion
        #region SetVistaValorCodigoProfesionalQueFirma: Devolver codigo del profesional que firma
        /// <summary>
        /// <para>Devolver codigo del profesional que debe aparecer como firma en el formato activo</para>
        /// <para>Dependiendo del estado del registro, cuando el formato esta sin confirmar debe firmar el usuario activo en el sistema.</para>
        /// </summary>
        public String SetVistaValorCodigoProfesionalQueFirma(HclModeloHistorialEventos tobRegistroEvento)
        {
            var lcrValorReturn = String.Empty;
            if (tobRegistroEvento != null)
            {
                lcrValorReturn = tobRegistroEvento.Sis_estpro_espr != "1" ? tobRegistroEvento.Sia_codpfa_prof : String.Empty;
            }
            if (String.IsNullOrWhiteSpace(lcrValorReturn))
            {
                var lobReg = ModeloSiamaeprofsalud.flsListaSiamaeprofsaludEx("3", oApp.gcrUsuIdUsuario);
                if (lobReg != null)
                {
                    lcrValorReturn = lobReg.Sia_codpfa_prof;
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region SetVistaValorTestEscalaAbreviada: Cargar valores de sexo y edad en test
        /// <summary>
        /// <para>Cargar los valores de edad y sexo en cotroles de usuarios para escala abreviada</para>
        /// </summary>
        public void SetVistaValorEdadSexoTestEscalaAbreviada(ref ClassXmlPropObjeto tobObjeto, String tcrValor, String tcrTipoOrigenValor)
        {
            switch (tobObjeto.TipoObjeto)
            {

                case "CONTROLEADAUDICIONLENGUAJE":
                    #region datos
                    var lobObjAudLen = tobObjeto.RefObjeto as ControlEscalaEadAudicionLenguage;
                    lobObjAudLen.lcrModoVistaObjeto = gcrDatosModoVista;

                    lobObjAudLen.txtEadAlSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                    lobObjAudLen.txtEadAlSia_edaano_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                    lobObjAudLen.txtEadAlSia_edames_usua.Text = tmpRegAdmision.Sia_edames_usua.ToString().Trim();
                    lobObjAudLen.txtEadAlSia_edadia_usua.Text = tmpRegAdmision.Sia_edadia_usua.ToString().Trim();
                    lobObjAudLen.txtEadAlSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaymd_usua.ToString().Trim();

                    lobObjAudLen.Refresh();
                    if (tcrTipoOrigenValor == "DEFAULT")
                    {
                        lobObjAudLen.fcvCargarVista("");
                    }
                    else
                    {
                        lobObjAudLen.fcvCargarVista(tcrValor);
                    }
                    lobObjAudLen.Refresh();
                    #endregion
                    break;

                case "CONTROLEADMOTRICIFINOADAPT":
                    #region datos
                    var lobObjAudMf = tobObjeto.RefObjeto as ControlEscalaEadMotriFinoAdaptativa;
                    lobObjAudMf.lcrModoVistaObjeto = gcrDatosModoVista;

                    lobObjAudMf.txtEadMfSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                    lobObjAudMf.txtEadMfSia_edaano_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                    lobObjAudMf.txtEadMfSia_edames_usua.Text = tmpRegAdmision.Sia_edames_usua.ToString().Trim();
                    lobObjAudMf.txtEadMfSia_edadia_usua.Text = tmpRegAdmision.Sia_edadia_usua.ToString().Trim();
                    lobObjAudMf.txtEadMfSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaymd_usua.ToString().Trim();

                    lobObjAudMf.Refresh();
                    if (tcrTipoOrigenValor == "DEFAULT")
                    {
                        lobObjAudMf.fcvCargarVista("");
                    }
                    else
                    {
                        lobObjAudMf.fcvCargarVista(tcrValor);
                    }
                    lobObjAudMf.Refresh();
                    #endregion
                    break;

                case "CONTROLEADMOTRICIGRUESA":
                    #region datos
                    var lobObjAudMg = tobObjeto.RefObjeto as ControlEscalaEadMotricidadGruesa;
                    lobObjAudMg.lcrModoVistaObjeto = gcrDatosModoVista;

                    lobObjAudMg.txtEadMgSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                    lobObjAudMg.txtEadMgSia_edaano_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                    lobObjAudMg.txtEadMgSia_edames_usua.Text = tmpRegAdmision.Sia_edames_usua.ToString().Trim();
                    lobObjAudMg.txtEadMgSia_edadia_usua.Text = tmpRegAdmision.Sia_edadia_usua.ToString().Trim();
                    lobObjAudMg.txtEadMgSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaymd_usua.ToString().Trim();

                    lobObjAudMg.Refresh();
                    if (tcrTipoOrigenValor == "DEFAULT")
                    {
                        lobObjAudMg.fcvCargarVista("");
                    }
                    else
                    {
                        lobObjAudMg.fcvCargarVista(tcrValor);
                    }
                    lobObjAudMg.Refresh();
                    #endregion
                    break;

                case "CONTROLEADPERSONALSOCIAL":
                    #region datos
                    var lobObjAudPs = tobObjeto.RefObjeto as ControlEscalaEadPersonalSocial;
                    lobObjAudPs.lcrModoVistaObjeto = gcrDatosModoVista;

                    lobObjAudPs.txtEadPsSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                    lobObjAudPs.txtEadPsSia_edaano_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                    lobObjAudPs.txtEadPsSia_edames_usua.Text = tmpRegAdmision.Sia_edames_usua.ToString().Trim();
                    lobObjAudPs.txtEadPsSia_edadia_usua.Text = tmpRegAdmision.Sia_edadia_usua.ToString().Trim();
                    lobObjAudPs.txtEadPsSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaymd_usua.ToString().Trim();

                    lobObjAudPs.Refresh();
                    if (tcrTipoOrigenValor == "DEFAULT")
                    {
                        lobObjAudPs.fcvCargarVista("");
                    }
                    else
                    {
                        lobObjAudPs.fcvCargarVista(tcrValor);
                    }
                    lobObjAudPs.Refresh();
                    #endregion
                    break;

                case "CONTROLEADGRAFPUNTUACION":
                    #region datos
                    var lobObjAudPn = tobObjeto.RefObjeto as ControlVistaEscalaEadPuntuacion;
                    lobObjAudPn.lcrModoVistaObjeto = gcrDatosModoVista;

                    lobObjAudPn.txtEadPnSis_codsex_sexo.Text = tmpRegAdmision.Sis_codsex_sexo;
                    lobObjAudPn.txtEadPnSia_edaano_usua.Text = tmpRegAdmision.Sia_edaano_usua.ToString().Trim();
                    lobObjAudPn.txtEadPnSia_edames_usua.Text = tmpRegAdmision.Sia_edames_usua.ToString().Trim();
                    lobObjAudPn.txtEadPnSia_edadia_usua.Text = tmpRegAdmision.Sia_edadia_usua.ToString().Trim();
                    lobObjAudPn.txtEadPnSia_edaymd_usua.Text = tmpRegAdmision.Sia_edaymd_usua.ToString().Trim();

                    lobObjAudPn.Refresh();
                    if (tcrTipoOrigenValor == "DEFAULT")
                    {
                        lobObjAudPn.fcvCargarVista("");
                    }
                    else
                    {
                        lobObjAudPn.fcvCargarVista(tcrValor);
                    }
                    lobObjAudPn.Refresh();
                    #endregion
                    break;
            }      
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION VARIABLES PUBLICAS ASOCIADAS A CAMPOS  AL INICIAR EDICION
        //---------------------------------------------------------------
        #region SetPropiedadesVariablePublicaObjetos: Asigna las propiedades de variable publica asociadas a objeto
        /// <summary>
        /// <para>Asigna las propiedades de variable publica asociadas a un objeto que guarda datos en base de datos</para>
        /// <para>asigna los valores por defecto desde la variable publica para dicho objeto</para>
        /// <para>tcrArchivoOrigen: "OBJETOS"/"AUXILIAR"/"ELIMINADOS"</para>
        /// <para>es util para cuando se pretende crear una nueva captura  de datos en la vista.</para>
        /// </summary>
        public void SetPropiedadesVariablesPublicasObjetos(String tcrArchivoOrigen, String tcrCodigoPlantilla)
        {
            tmpVarPublicGeneral = new List<ClassXmlPropVariablePublica>();
            var tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);
            
            foreach (var lobItem in tobTemp)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.NombreVariable) && !String.IsNullOrWhiteSpace(lobItem.VariablePublica))
                {
                    if (lobItem.PropVarPublica == null)
                    {
                        lobItem.PropVarPublica = SetCargarValoresVariablesPublicas(lobItem.VariablePublica);
                    }

                    if (lobItem.PropVarPublica != null)
                    {
                        var vp = lobItem.PropVarPublica;
                        // Buscar valor por defecto desde variable
                        lobItem.ValorDefault = !String.IsNullOrWhiteSpace(lobItem.ValorDefault) ? lobItem.ValorDefault : vp.Hcl_valvar_hcvr;

                        // Variables que se gestionan especial 
                        var lcrReturn = SetValorDefaultVariablePublicaEspecial(lobItem.NombreVariable);

                        if (String.IsNullOrWhiteSpace(lcrReturn))
                        {
                            // Buscar el historial del paciente
                            if (lobItem.VarGestPosVector != "N" && lobItem.VarGestPosVector != "0" && !String.IsNullOrWhiteSpace(lobItem.VarGestPosVector))
                            {
                                if (vp.Pila == null) { vp.Pila = new List<ClassXmlPilaVariablePublica>(); }
                                // Devolver posicion pila para la variable
                                var lnuPos = Convert.ToInt32(lobItem.VarGestPosVector);
                                if (vp.Pila.Count >= lnuPos && lnuPos >= 1)
                                {
                                    lcrReturn = vp.Pila[lnuPos].Dato.Trim() != "-N-" ? vp.Pila[lnuPos].Dato.Trim() : String.Empty;
                                }
                            }
                            else
                            {
                                if (lobItem.VarGestPosVector != "0")
                                {
                                    lcrReturn = vp.Hcl_ValorHistTexto;
                                }
                            }
                        }

                        // Prioridad para los datos que vienen del historico del paciente
                        lobItem.ValorDefault = !String.IsNullOrWhiteSpace(lcrReturn) ? lcrReturn : lobItem.ValorDefault;
                    }
                }
            }
        }
        #endregion
        #region SetValorDefaultVariablePublicaEspecial: Valor defecto desde variable publica especial
        /// <summary>
        /// <para>Devuelve valor de variable con valores especiales tales como: Nit de la IPS  y otros</para>
        /// <para>tcrValorDefault: Valor por defecto, la funcion devuelve este mismo valor, cuando no hay dato en la variable publica.</para>
        /// <para>tcrNombreVariable: Nombre de la variable a consultar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public String SetValorDefaultVariablePublicaEspecial(String tcrNombreVariable)
        {
            var llgReturn = String.Empty;
            // Parametros generales IPS
            #region Parametros generales IPS
            if (tcrNombreVariable.Substring(0, 11) == "GENERAL_IPS")
            {
                if (gobRegValoresIPS == null)
                {
                    gobRegValoresIPS = SISValidarCodigo.fobRegBuscarSisparametroips("SIS001");
                }
                // Razon Social IPS
                #region GENERAL_IPS_RAZON_SOCIAL
                if (tcrNombreVariable == "GENERAL_IPS_RAZON_SOCIAL")
                {
                    llgReturn = gobRegValoresIPS.sis_razsoc_pips;
                }
                #endregion
                // Nit de la IPS con puntos separadores
                #region GENERAL_IPS_IDENTIFI_NIT
                if (tcrNombreVariable == "GENERAL_IPS_IDENTIFI_NIT")
                {
                    llgReturn = gobRegValoresIPS.sis_nitipx_pips; // Con puntos separadores
                }
                #endregion
                // Nit de la IPS sin separadores
                #region GENERAL_IPS_IDENTIFI_NITSIN
                if (tcrNombreVariable == "GENERAL_IPS_IDENTIFI_NITSIN")
                {
                    llgReturn = gobRegValoresIPS.sis_nitips_pips; // Con puntos separadores
                }
                #endregion
                // Codigo prestador de servicio de salud
                #region GENERAL_IPS_IDE_PRESTADOR
                if (tcrNombreVariable == "GENERAL_IPS_IDE_PRESTADOR")
                {
                    llgReturn = gobRegValoresIPS.sis_codips_pips; 
                }
                #endregion
                // Direccion Sede IPS
                #region GENERAL_IPS_DIRECCION_SEDE
                if (tcrNombreVariable == "GENERAL_IPS_DIRECCION_SEDE")
                {
                    llgReturn = gobRegValoresIPS.sis_dirips_pips;
                }
                #endregion
                // Departamento / Distrito
                #region GENERAL_IPS_NOMBRE_DPTO
                if (tcrNombreVariable == "GENERAL_IPS_NOMBRE_DPTO")
                {
                    llgReturn = gobRegValoresIPS.sis_nomdpt_pips;
                }
                #endregion
                // Municipio
                #region GENERAL_IPS_NOMBRE_MUNICIPIO
                if (tcrNombreVariable == "GENERAL_IPS_NOMBRE_MUNICIPIO")
                {
                    llgReturn = gobRegValoresIPS.sis_nommun_pips;
                }
                #endregion
            }
            #endregion
            // Resumen evoluciones medicas
            #region HOSPIT_RESUM_EVOLUCI_NOTASMED
            if (tcrNombreVariable == "HOSPIT_RESUM_EVOLUCI_NOTASMED")
            {
                var lcrCodigoAdmision = gobRegHistorialActivo != null ? gobRegHistorialActivo.Adm_secadm_rgad : String.Empty;
                lcrCodigoAdmision = tmpRegAdmision != null ? tmpRegAdmision.Adm_secadm_rgad : lcrCodigoAdmision;

                llgReturn = SetValoVarPublicaEvolucionMedica("EVOL", lcrCodigoAdmision);
            }
            #endregion

            return llgReturn;
        }
        #endregion
        #region SetValoVarPublicaEvolucionMedica: Evolucion medica o notas de enfermeria
        /// <summary>
        /// <para>Devuelve valor de variable publica evolucion medica o notas de enfermeria</para>
        /// <para>tcrTipoRegistro: "EVOL" = Evoluiones "NENF" = Notas de enfermeria.</para>
        /// <para>tcrCodigoAdmision: Codigo de la admision.</para>
        /// </summary>
        public String SetValoVarPublicaEvolucionMedica(String tcrTipoRegistro, String tcrCodigoAdmision)
        {
            var llgReturn = String.Empty;
            if (!String.IsNullOrWhiteSpace(tcrCodigoAdmision))
            {
                // Generar el texto de la variable
                var lcrFechaHora = String.Empty;
                var lcrProfesional = String.Empty;
                var lobTmpEvol = ModeloHclregnotasmedi.flsListaHclregnotasmediEx(tcrTipoRegistro, tcrCodigoAdmision);

                if (lobTmpEvol != null && lobTmpEvol.Count != 0)
                {
                    foreach (var lobReg in lobTmpEvol)
                    {
                        lcrFechaHora = lobReg.Hcl_gesfec_hcnm.ToShortDateString() + " " +
                                            Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcnm.ToString(), "24", gcrSysSeparadorDecimal, ":");

                        lcrProfesional = "[" + lobReg.Sia_codpfa_prof + "] " + lobReg.Sia_nompro_prof;

                        llgReturn += lcrFechaHora + " - " + lcrProfesional + "\r\n" + lobReg.Hcl_notreg_hcnm + "\r\n" + "\r\n";
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region SetCargarValoresVariablesPublicas: Cargar valores en temporal general de variables
        /// <summary>
        /// <para>Cargar valores en temporal general de variables y devuelve un objeto </para>
        /// <para>tcrNombreVariable: Nombre de la variable a consultar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public ClassXmlPropVariablePublica SetCargarValoresVariablesPublicas(String tcrNombreVariablePublica)
        {
            var lobRegVar = tmpVarPublicGeneral.FirstOrDefault(x => x.Hcl_nomvar_hcvr == tcrNombreVariablePublica);

            if (lobRegVar == null)
            {
                var lobReg = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrNombreVariablePublica);
                if (lobReg != null)
                {
                    lobRegVar = new ClassXmlPropVariablePublica
                    {
                        #region datos
                        Hcl_secgru_hcgv = lobReg.hcl_secgru_hcgv,
                        Hcl_ordvis_hcvr = (int)lobReg.hcl_ordvis_hcvr,
                        Hcl_titulo_hcvr = lobReg.hcl_titulo_hcvr,
                        Hcl_descri_hcvr = lobReg.hcl_descri_hcvr,
                        Hcl_nomvar_hcvr = lobReg.hcl_nomvar_hcvr,
                        Hcl_tipval_hcvr = lobReg.hcl_tipval_hcvr,
                        Hcl_valper_hcvr = lobReg.hcl_valper_hcvr,
                        Hcl_valvar_hcvr = lobReg.hcl_valvar_hcvr,
                        Hcl_camdig_hcvr = lobReg.hcl_camdig_hcvr,
                        Hcl_ranini_hcvr = lobReg.hcl_ranini_hcvr,
                        Hcl_ranfin_hcvr = lobReg.hcl_ranfin_hcvr,
                        Hcl_raninr_hcvr = lobReg.hcl_raninr_hcvr,
                        Hcl_ranfnr_hcvr = lobReg.hcl_ranfnr_hcvr,
                        Hcl_nivvar_hcvr = lobReg.hcl_nivvar_hcvr,
                        Hcl_sistem_hcvr = lobReg.hcl_sistem_hcvr,
                        Hcl_modoca_hcvr = lobReg.hcl_modoca_hcvr,
                        Hcl_resume_hcvr = lobReg.hcl_resume_hcvr,
                        Hcl_tvigen_hcvr = lobReg.hcl_tvigen_hcvr,
                        Hcl_vvigen_hcvr = (int)lobReg.hcl_vvigen_hcvr,
                        Hcl_varray_hcvr = lobReg.hcl_varray_hcvr,
                        Hcl_tmaray_hcvr = (int)lobReg.hcl_tmaray_hcvr,
                        Hcl_sisvar_hcvr = lobReg.hcl_sisvar_hcvr,
                        Sis_estreg_esrg = lobReg.sis_estreg_esrg,
                        Pila = null,
                        EstadoEdicion = "1"
                        #endregion
                    };
                    // Se toma desde el historial de la variable en el paciente o Valor por defecto
                    lobRegVar.Hcl_ValorHistTexto = SetValorDefaultVariablePublica(tcrNombreVariablePublica);

                    // verificar si es una variable tipo pila
                    if (lobRegVar.Hcl_varray_hcvr == "1")
                    {
                        if (!String.IsNullOrWhiteSpace(lobRegVar.Hcl_ValorHistTexto))
                        {
                            lobRegVar.Pila = SetValoresPilaEnVariablePublica(lobRegVar.Hcl_ValorHistTexto);
                        }
                        else
                        {
                            lobRegVar.Hcl_ValorHistTexto = SetValoresPilaEnVariablePublica(lobRegVar.Hcl_tmaray_hcvr);
                            lobRegVar.Pila = SetValoresPilaEnVariablePublica(lobRegVar.Hcl_ValorHistTexto);
                        }
                    }

                    tmpVarPublicGeneral.Add(lobRegVar);
                }
            }
            return lobRegVar;
        }
        #endregion
        #region SetValorDefaultVariablePublica: Devuelve valor dvariable publica desde maestro historial
        /// <summary>
        /// <para>Devuelve valor por defecto desde variable publica utlizando el historial del paciente activo</para>
        /// <para>tcrNombreVariable: Nombre de la variable a consultar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public String SetValorDefaultVariablePublica(String tcrNombreVariable)
        {
            var llgReturn = String.Empty;
            var lobRegistro = ModeloHclvariabactual.flsListaHclvariabactual("3", tmpUsuarioAtendido.Sia_idesec_usua, tcrNombreVariable);
            if (lobRegistro != null && lobRegistro.Count != 0)
            {
                llgReturn = lobRegistro.FirstOrDefault().Hcl_valvar_hcvr;
            }
            return llgReturn;
        }
        #endregion
        #region SetValoresPilaEnVariablePublica: Cargar valores de la pila para cada variable publica
        /// <summary>
        /// <para>Cargar valores de la pila para cada variable publica</para>
        /// </summary>
        public List<ClassXmlPilaVariablePublica> SetValoresPilaEnVariablePublica(String tcrValorTexto)
        {
            List<ClassXmlPilaVariablePublica> lobReturn = null;

            if (!String.IsNullOrWhiteSpace(tcrValorTexto))
            {
                String[] larArray = tcrValorTexto.Split("*".ToCharArray());
                var lnuTotElemtos = larArray.Length;
                var i = 0;
                // cuando hay valores
                if (lnuTotElemtos > 0)
                {
                    lobReturn = new List<ClassXmlPilaVariablePublica>();
                    for (i = 0; i < lnuTotElemtos; i++)
                    {
                        var lobReg = new ClassXmlPilaVariablePublica();

                        lobReg.Posicion = i;
                        lobReg.Dato     = larArray[i];
                        lobReg.Estado   = "1";

                        lobReturn.Add(lobReg);
                    }
                }
            }

            return lobReturn;
        }
        #endregion
        #region SetValoresPilaEnVariablePublica: Genera la string de texto para valores iniciales de la pila
        /// <summary>
        /// <para>Genera la string de texto para valores iniciales de la pila</para>
        /// <para>PARAMETROS</para>
        /// <para>tnuTotalValoresPila: Cantidad de posiciones que contiene la variable tipo pila</para>
        /// </summary>
        public String SetValoresPilaEnVariablePublica(int tnuTotalValoresPila)
        {
            var lcrReturn = "-D-";
            var i = 0;

            for (i = 0; i < tnuTotalValoresPila; i++)
            {
                lcrReturn += "*-N-";
            }
            return lcrReturn;
        }
        #endregion
        //---------------------------------------------------------------
        // Mostrar u ocultar la vista de una plantilla y sus objetos
        //---------------------------------------------------------------
        #region flgGestVistaVerObjetosPlantilla: Mostrar u ocultar la vista de una plantilla y sus objetos
        /// <summary>
        /// <para>Recorre temporal de objetos para buscar una plantilla</para>
        /// <para>mostrar u ocultar los objetos, o mostrar las plantillas restantes</para>
        /// <para>tcrCodigoPlantilla:</para>
        /// <para>Codigo de la plantilla cargada en el archivo de objetos (tcrArchivoOrigen) para la cual se generaran los registros</para>
        /// <para>Valores para tcrTipoVista:</para>
        /// <para>"VT" =  Visibles todos los objetos</para>
        /// <para>"VD" =  Visibles todos los objetos diferentes a tcrCodigoPlantilla o Navegador dado</para>
        /// <para>"VP" =  Visibles solo los objetos de tcrCodigoPlantilla o navegador dado</para>
        /// <para>"OT" =  Ocultos todos los objetos</para>
        /// <para>"OD" =  Ocultos todos los objetos diferentes a tcrCodigoPlantilla</para>
        /// <para>"OP" =  Ocultos solo los objetos de tcrCodigoPlantilla</para>
        /// <para></para>
        /// <para>Valores para tcrCodigoPlantilla:</para>
        /// <para>"tcrCodigoPlantilla" = Codigo de la plantilla referencia </para>
        /// <para>"VACIO"              = La Accion aplica para todas las plantillas del Navegador tcrNavegador</para>
        /// <para></para>
        /// <para>Valores para tcrNavegador:</para>
        /// <para>"TODOS/ESCRITORIO/ETIQUETA/PLANTILLA" = Solo lista de objetos del navegador dado o grupo objetos de la plantilla</para>
        /// </summary>
        public bool flgGestVistaVerObjetosPlantilla(String tcrArchivoOrigen, String tcrTipoVista, String tcrNavegador,  String tcrCodigoPlantilla)
        {
            //var lcrNavegador =
            var llgValor = false;
            var lobDatos = new ClassXmlPropDatos();
            var lobTemp = new List< ClassXmlPropObjeto>();
            // Buscar navegador
            if (tcrNavegador == "ESCRITORIO" || tcrNavegador == "ETIQUETA")
            {
                lobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "NAVEGADOR", tcrNavegador);
            }
            else if (tcrNavegador == "PLANTILLA")
            {
                lobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);
            }
            else // "TODOS" Son Todos los navegadores
            {
                lobTemp = fobRegSelectReferenciaArchivo(tcrArchivoOrigen);
            } 

            foreach (var lobItem in lobTemp)
            {
                llgValor = true;
                if (lobItem.TipoObjeto == "PAGINA")
                {
                    var lobPagina = lobItem.RefObjeto as Canvas;
                    switch (tcrTipoVista)
                    {
                        case "VT": // Visbles todos
                            lobPagina.Visibility = Visibility.Visible;
                            break;

                        case "VD": // Visbles todos diferentes a plantilla / navegador dado
                            #region Acciones
                             if (lobItem.CodigoPlantilla == tcrCodigoPlantilla)
                             {
                                    lobPagina.Visibility = Visibility.Collapsed;
                             }
                             else
                             {
                                    lobPagina.Visibility = Visibility.Visible;
                            }
                            break;
                            #endregion

                        case "VP": // Visibles solo los objetos de tcrCodigoPlantilla o navegador dado
                            #region Acciones
                                if (lobItem.CodigoPlantilla == tcrCodigoPlantilla)
                                {
                                    lobPagina.Visibility = Visibility.Visible;
                                }
                                else 
                                {
                                    lobPagina.Visibility = Visibility.Collapsed;
                                }
                            break;
                            #endregion

                        case "OT": // Ocultos todos
                            lobPagina.Visibility = Visibility.Collapsed;
                            break;

                        case "OD": // Oculto todos diferentes a plantilla / navegador dado
                            #region Acciones
                                if (lobItem.CodigoPlantilla == tcrCodigoPlantilla)
                                {
                                    lobPagina.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    lobPagina.Visibility = Visibility.Collapsed;
                                }
                            break;
                            #endregion

                        case "OP": // Ocultos solo los objetos de tcrCodigoPlantilla o navegador dado
                            #region Acciones
                                if (lobItem.CodigoPlantilla == tcrCodigoPlantilla)
                                {
                                    lobPagina.Visibility = Visibility.Collapsed;
                                }
                                else
                                {
                                    lobPagina.Visibility = Visibility.Visible;
                                }
                            break;
                            #endregion

                    }

                }
            }
            return llgValor;
        }
        #endregion
        //---------------------------------------------------------------
        // Actulizar valores en registros de datos y validacion campos 
        //---------------------------------------------------------------
        #region SetActualizarValorDatoPlantilla: Actualizar los valores digitados en temporal de registros
        /// <summary>
        /// <para>Actualizar los valores digitados en temporal de registros</para>
        /// </summary>
        public bool flgSetActualizarValorDatoPlantilla(String tcrCodigoPlantilla, String tcrNombreObjeto, String tcrValor)
        {
            var llgReturn = false;
            var lobRegistro= tmpCapturaDatos.FirstOrDefault(x => x.IgGrupoRegistro.Equals(tcrCodigoPlantilla) && x.Name.Equals(tcrNombreObjeto));
            if (lobRegistro != null) 
            {
                lobRegistro.Valor = tcrValor;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region SetActualizarValorDatoPlantilla: Actualizar los valores digitados en temporal de registros para objetos con descripcion
        /// <summary>
        /// <para>Actualizar los valores digitados en temporal de registros para objetos con descripcion</para>
        /// <para>tales como combobox u objetos con relación tablas</para>
        /// </summary>
        public bool flgSetActualizarValorDatoPlantilla(String tcrCodigoPlantilla, String tcrNombreObjeto, String tcrValor, String tcrDescripcion)
        {
            var llgReturn = false;
            var lobRegistro = tmpCapturaDatos.FirstOrDefault(x => x.IgGrupoRegistro.Equals(tcrCodigoPlantilla) && x.Name.Equals(tcrNombreObjeto));
            if (lobRegistro != null)
            {
                lobRegistro.Valor = tcrValor;
                lobRegistro.ValorDescripcion = tcrDescripcion;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //---------------------------------------------------------------
        //  VALIDACION OBJETOS Campos relacionados y variables publicas
        //---------------------------------------------------------------
        #region flgValidVarDatosCampo: Validar datos libres y relacionados con archivos RIPS 4505 y Variables publicas
        /// <summary>
        /// <para>Validar datos libres (no relacionados con Rips o 4505 y otros) y datos digitados que correspondan</para>
        /// <para>a valores permitidos para el campo corespondiente en archivo actualizable RIPS RE4505 y Variables Publicas</para>
        /// </summary>
        public bool flgValidVarDatosCampo(String tcrNombreObjeto, String tcrValor)
        {
            String lcrValorReturn   = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError   = String.Empty;
            String lcrtituloCampo   = String.Empty;
            String lcrNivelError    = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            var llgReturn           = false;
            var lobObjObjeto        = fobRegSelectParenObjeto("OBJETOS", "", tcrNombreObjeto).FirstOrDefault();
            var llgValidCompleja    = false;
            // Validar 4505 Rips y otros
            var lcrNombreCampo      = lobObjObjeto.RefVarDatosCampo;
            var lcrCampo  = SISValidarCodigo.fobRegBuscarSisactualizcampIu(lcrNombreCampo);

            // decidir ruta de validacion 
            llgValidCompleja = (lcrCampo != null || lobObjObjeto.PropVarPublica != null) ? true : false;

            // cuando hay relacion de campo 4505 Rips o variables publicas
            if (llgValidCompleja==true)
            {
                lcrtituloCampo = lobObjObjeto.Titulo;
                lcrValorReturn = String.Empty;
                lcrCodigoError = lobObjObjeto.TabIndex + "A";
                var lcrTipoValor =String.Empty;

                // Validar Referencias a 4505 y Rips
                if (lcrCampo != null)
                {
                    lcrTipoValor = lcrCampo.sis_tipval_siac;
                    lcrValorReturn = fcrValidVarDatosCamposVariables("1", tcrNombreObjeto, lcrTipoValor, tcrValor);
                }
                 
                // Validar referencias a variables publicas
                if (String.IsNullOrWhiteSpace(lcrValorReturn) && lobObjObjeto.PropVarPublica != null)
                {
                    lcrTipoValor = lobObjObjeto.PropVarPublica.Hcl_tipval_hcvr;
                    lcrValorReturn = fcrValidVarDatosCamposVariables("2", tcrNombreObjeto, lcrTipoValor, tcrValor);
                }
            }
            else 
            {
                // Validacion normal segun tipo campo
                if (lobObjObjeto != null)
                {
                    lcrtituloCampo = lobObjObjeto.Titulo;
                    lcrCodigoError = lobObjObjeto.TabIndex + "B";

                    switch (lobObjObjeto.TipoObjeto.Trim())
                    {
                        case "TEXTBOX": // Tipo Texto
                            lcrValorReturn = fcrValidVarDatosCampolibreTexto(lobObjObjeto, tcrValor);
                            break;

                        case "RICHTEXTBOX": // Editor de Texto
                            lcrValorReturn = fcrValidVarDatosCampolibreTexto(lobObjObjeto, tcrValor);
                            break;

                        case "TEXTBOXNUMERO": // Tipo Numerico
                            lcrValorReturn = fcrValidVarDatosCampolibreNumero(lobObjObjeto, tcrValor);
                            break;

                        case "TEXTBOXREL": // Tipo Relacion tablas
                            lcrValorReturn = fcrValidVarDatosCampolibreTexto(lobObjObjeto, tcrValor);
                            break;

                        case "TEXTBOXDATE": // Tipo Fechas
                            lcrValorReturn = fcrValidVarDatosCampolibreFecha(lobObjObjeto, tcrValor);
                            break;

                        case "TEXTBOXTIME": // Tipo Hora
                            lcrValorReturn = fcrValidVarDatosCampolibreHora(lobObjObjeto, tcrValor);
                            break;
                    }
                }
            }
            // Sumar errores
            gnuContErroresIsRequerido = String.IsNullOrWhiteSpace(lcrValorReturn) ? gnuContErroresIsRequerido : gnuContErroresIsRequerido + 1;
            // Mostrar borde iluminado para vista de errores
            #region Mostrar borde iluminado para vista de errores
            if (lobObjObjeto.TipoObjeto == "TEXTBOX" || lobObjObjeto.TipoObjeto == "TEXTBOXREL" ||
                lobObjObjeto.TipoObjeto == "TEXTBOXDES")
            {
                var lobTextBox = lobObjObjeto.RefObjeto as TextBox;
                fcvSetBorderColorError(lcrValorReturn, ref lobTextBox, ref lobObjObjeto);
            }
            if (lobObjObjeto.TipoObjeto == "RICHTEXTBOX")
            {
                var lobRichTextBox = lobObjObjeto.RefObjeto as RichTextBox;
                fcvSetBorderColorErrorRichTextBox(lcrValorReturn, ref lobRichTextBox, ref lobObjObjeto);
            }
            else if (lobObjObjeto.TipoObjeto == "TEXTBOXDATE")
            {
                var lobjFecha = lobObjObjeto.RefObjeto as ControlFecha;
                lobjFecha.fcvColorBorder(lcrValorReturn, lobObjObjeto.BorderBrush);
            }
            else if (lobObjObjeto.TipoObjeto == "TEXTBOXTIME")
            {
                var lobjHora = lobObjObjeto.RefObjeto as ControlHora;
                lobjHora.fcvColorBorder(lcrValorReturn, lobObjObjeto.BorderBrush);
            }
            else if (lobObjObjeto.TipoObjeto == "COMBOBOX")
            {
                var lobComboBox = lobObjObjeto.RefObjeto as ComboBox;
                fcvSetBorderColorError(lcrValorReturn, ref lobComboBox, ref lobObjObjeto);
            }
            #endregion
            // si hay error registrar en el log con el nombre y titulo del objeto 
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

            llgReturn = !String.IsNullOrWhiteSpace(lcrValorReturn) ? false : true;

            return llgReturn;
        }
        #endregion
        #region fcrValidVarDatosCamposVariables: Validar relacionados con archivos RIPS 4505 y Variables Publicas
        /// <summary>
        /// Validar datos digitados que correspondan segun las referencias en 4505 Rips y Variables publicas
        /// </summary>
        /// <param name="tcrTipoArchivo">"1" = Rips o Res4505 "2"=Variables Publicas</param>
        /// <param name="tcrNombreObjeto">Nombre del objeto en la vista pantalla</param>
        /// <param name="tcrTipoValor">Tipo Valor: "D"= Fecha "C"=Caracter "N"= Numerico...</param>
        /// <param name="tcrValor">Valor a validar</param>
        /// <returns>Retorna una expresion tipo texto que repesenta el error encontado, cuando no hay error retorna vacio</returns>
        public String fcrValidVarDatosCamposVariables(String tcrTipoArchivo, String tcrNombreObjeto, String tcrTipoValor,  String tcrValor)
        {
            var lcrValorReturn = String.Empty;
            var lobObjObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombreObjeto).FirstOrDefault();

            switch (tcrTipoValor)
            {
                case "D": // Tipo Fecha
                    lcrValorReturn = fcrValidVarDatosCampolibreFecha(lobObjObjeto, tcrValor);
                    if (String.IsNullOrWhiteSpace(lcrValorReturn))
                    {
                        lcrValorReturn = fcrValidVarDatosCampoTablaFecha(tcrTipoArchivo, lobObjObjeto, tcrValor);
                    }
                    break;

                case "C":  // Tipo texto
                    lcrValorReturn = fcrValidVarDatosCampoTablaTexto(tcrTipoArchivo, lobObjObjeto, tcrValor);
                    break;

                case "N":  // Tipo Numerico
                    lcrValorReturn = fcrValidVarDatosCampoTablaNumerico(tcrTipoArchivo, lobObjObjeto, tcrValor);
                    break;

                case "F":  // Tipo Numerico Flotante
                    lcrValorReturn = fcrValidVarDatosCampoTablaNumerico(tcrTipoArchivo, lobObjObjeto, tcrValor);
                    break;

                case "R":  // Tipo Relacion tabla
                    lcrValorReturn = String.Empty;
                    break;

                case "H":  // Tipo Hora 
                    lcrValorReturn = fcrValidVarDatosCampolibreHora(lobObjObjeto, tcrValor);
                    break;
            }

            return lcrValorReturn;
        }
        #endregion
        // Validaciones para campos libres
        #region fcrValidVarDatosCampolibreTexto: Validar datos tipo texto
        /// <summary>
        /// <para>Validar datos tipo texto</para>
        /// </summary>
        public String fcrValidVarDatosCampolibreTexto(ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;
            gcrValorReturnChr = String.Empty;

            if (String.IsNullOrWhiteSpace(tcrValor))
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Valor es requerido";
                }
            }
            else
            {
                if (Funciones.flgExisteSubCadenaStringEz(tcrValor, "&'´<>"))
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Contiene caracteres no permitidos  &'´< >";
                    gcrValorReturnChr = "ERROR";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampolibreFecha: Validar datos tipo fecha
        /// <summary>
        /// <para>Validar datos tipo fecha, solo valida estructura</para>
        /// </summary>
        public String fcrValidVarDatosCampolibreFecha(ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;

            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tcrValor, tobObjObjeto.Titulo);
                }
                else
                {
                    lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", tcrValor, tobObjObjeto.Titulo);
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Valor es requerido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampolibreHora: Validar datos tipo Hora
        /// <summary>
        /// <para>Validar datos tipo Hora</para>
        /// </summary>
        public String fcrValidVarDatosCampolibreHora(ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;

            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = Funciones.fcrValidaHoraTexto(true, tcrValor, "12", ":", tobObjObjeto.Titulo);
                }
                else
                {
                    lcrValorReturn = Funciones.fcrValidaHoraTexto(false, tcrValor, "12", ":", tobObjObjeto.Titulo);
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Valor es requerido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampolibreNumero: Validar datos tipo Numerico
        /// <summary>
        /// <para>Validar datos tipo Numerico</para>
        /// </summary>
        public String fcrValidVarDatosCampolibreNumero(ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;

            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                // Valor es requerido 
                if (!Funciones.flgSoloNumerosEx(tcrValor))
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Valor debe ser númerico";
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = tobObjObjeto.Titulo + ": Valor es requerido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        // Validaciones para campos desde tablas
        #region fcrValidVarDatosCampoTablaFecha: Validar datos relacionados tipo fecha
        /// <summary>
        /// <para>Validar datos relacionados tipo fecha para actualizar RIPS, RE4505, Variables Publicas y otros</para>
        /// </summary>
        /// <param name="tcrTipoArchivo">"1" = Rips o Res4505 "2"=Variables Publicas</param>
        /// <param name="tobObjObjeto"> Referencia del objeto en la vista pantalla</param>
        /// <param name="tcrValor">Valor a validar</param>
        /// <returns>Retorna una expresion tipo texto que repesenta el error encontado, cuando no hay error retorna vacio</returns>
        public String fcrValidVarDatosCampoTablaFecha(String tcrTipoArchivo, ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;
            var lcrValorPermitido = String.Empty;
            var lcrRangoInicial = String.Empty;
            var lcrRangoFinal = String.Empty;
            var lcrTitulo = tobObjObjeto.Titulo;

            // Resolucion 4505 y Rips
            if (tcrTipoArchivo == "1")
            {
                var lcrCampo      = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tobObjObjeto.RefVarDatosCampo);
                lcrRangoInicial   = lcrCampo.sis_ranini_siac;
                lcrRangoFinal     = lcrCampo.sis_ranfin_siac;
                lcrValorPermitido = lcrCampo.sis_valper_siac;
                lcrTitulo         = lcrCampo.sis_codarc_siaa + " - " + lcrCampo.sis_nomcam_siac;
            }
            // Variables publicas
            if (tcrTipoArchivo == "2")
            {
                var lcrCampo = tobObjObjeto.PropVarPublica;
                lcrRangoInicial   = lcrCampo.Hcl_ranini_hcvr;
                lcrRangoFinal     = lcrCampo.Hcl_ranfin_hcvr;
                lcrValorPermitido = lcrCampo.Hcl_valper_hcvr;
                lcrTitulo         = "Variable - " + lcrCampo.Hcl_titulo_hcvr;
            }
            lcrValorPermitido = lcrValorPermitido == "FECHA" ? String.Empty : lcrValorPermitido;

            if (!String.IsNullOrWhiteSpace(tcrValor) && tcrValor.Trim() != "//" && tcrValor.Trim() != "/  /")
            {
                if (!String.IsNullOrWhiteSpace(lcrRangoInicial) && !String.IsNullOrWhiteSpace(lcrRangoFinal))
                {
                    if (!Funciones.flgValidarRangoFecha(tcrValor, lcrRangoInicial, lcrRangoFinal))
                    {
                        // Es posible que este en valores permitidos
                        if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                        {
                            lcrValorReturn = lcrTitulo + ": Valor no esta dentro del rango " + lcrRangoInicial + " - " + lcrRangoFinal;
                        }
                    }
                }
                else if (!String.IsNullOrWhiteSpace(lcrValorPermitido))
                {
                    if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                    {
                        lcrValorReturn = lcrTitulo + ": Valor no esta permitido";
                    }
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = lcrTitulo + ": Valor es requerido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampoTablaTexto: Validar datos relacionados tipo texto
        /// <summary>
        /// <para>Validar datos relacionados tipo texto para actualizar RIPS, RE4505 y otros</para>
        /// </summary>
        /// <param name="tcrTipoArchivo">"1" = Rips o Res4505 "2"=Variables Publicas</param>
        /// <param name="tobObjObjeto"> Referencia del objeto en la vista pantalla</param>
        /// <param name="tcrValor">Valor a validar</param>
        /// <returns>Retorna una expresion tipo texto que repesenta el error encontado, cuando no hay error retorna vacio</returns>
        public String fcrValidVarDatosCampoTablaTexto(String tcrTipoArchivo, ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;
            var lcrValorPermitido = String.Empty;
            var lcrTitulo = tobObjObjeto.Titulo;

            // Resolucion 4505 y Rips
            if (tcrTipoArchivo == "1")
            {
                var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tobObjObjeto.RefVarDatosCampo);
                lcrValorPermitido = lcrCampo.sis_valper_siac;
                lcrTitulo         = lcrCampo.sis_codarc_siaa + " - " + lcrCampo.sis_nomcam_siac;
            }
            // Variables publicas
            if (tcrTipoArchivo == "2")
            {
                var lcrCampo = tobObjObjeto.PropVarPublica;
                lcrValorPermitido = lcrCampo.Hcl_valper_hcvr;
                lcrTitulo         = "Variable - " + lcrCampo.Hcl_titulo_hcvr;
            }

            gcrValorReturnChr = String.Empty;

            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                if (Funciones.flgExisteSubCadenaStringEz(tcrValor, "&'´<>"))
                {
                    lcrValorReturn = lcrTitulo + ": Contiene caracteres no permitidos  &'´< >";
                    gcrValorReturnChr = "ERROR";
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(lcrValorPermitido) && lcrValorPermitido != "TEXTO")
                    {
                        // Es posible que este en valores permitidos
                        if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                        {
                            if (!Funciones.flgExisteElemento("VP", ",", lcrValorPermitido))
                            {
                                lcrValorReturn = lcrTitulo + ": Valor no es valido";
                            }
                        }
                    }
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = lcrTitulo + ": Valor es requerido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampoTablaNumerico: Validar datos relacionados tipo Numerico
        /// <summary>
        /// <para>Validar datos relacionados tipo numerico para actualizar RIPS, RE4505 y otros</para>
        /// </summary>
        /// <param name="tcrTipoArchivo">"1" = Rips o Res4505 "2"=Variables Publicas</param>
        /// <param name="tobObjObjeto"> Referencia del objeto en la vista pantalla</param>
        /// <param name="tcrValor">Valor a validar</param>
        /// <returns>Retorna una expresion tipo texto que repesenta el error encontado, cuando no hay error retorna vacio</returns>
        public String fcrValidVarDatosCampoTablaNumerico(String tcrTipoArchivo, ClassXmlPropObjeto tobObjObjeto, String tcrValor)
        {
            var lcrValorReturn = String.Empty;
            var lcrValorPermitido = String.Empty;
            var lcrRangoInicial = String.Empty;
            var lcrRangoFinal = String.Empty;
            var lcrTitulo = tobObjObjeto.Titulo;

            // Resolucion 4505 y Rips
            if (tcrTipoArchivo == "1")
            {
                var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tobObjObjeto.RefVarDatosCampo);
                lcrRangoInicial     = lcrCampo.sis_ranini_siac;
                lcrRangoFinal       = lcrCampo.sis_ranfin_siac;
                lcrValorPermitido   = lcrCampo.sis_valper_siac;
                lcrTitulo           = lcrCampo.sis_codarc_siaa + " - " + lcrCampo.sis_nomcam_siac;
            }
            // Variables publicas
            if (tcrTipoArchivo == "2")
            {
                var lcrCampo = tobObjObjeto.PropVarPublica;
                lcrRangoInicial     = lcrCampo.Hcl_ranini_hcvr;
                lcrRangoFinal       = lcrCampo.Hcl_ranfin_hcvr;
                lcrValorPermitido   = lcrCampo.Hcl_valper_hcvr;
                lcrTitulo           = "Variable - " + lcrCampo.Hcl_titulo_hcvr;
            }

            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                tcrValor        = Funciones.fcrRemplazarChrDecimal(tcrValor);
                lcrRangoInicial = Funciones.fcrRemplazarChrDecimal(lcrRangoInicial);
                lcrRangoFinal   = Funciones.fcrRemplazarChrDecimal(lcrRangoFinal);

                if (!Funciones.flgSoloNumerosEx(tcrValor))
                {
                    lcrValorReturn = lcrTitulo + ": Valor no esta permitido";
                    return lcrValorReturn;
                }
                if (!String.IsNullOrWhiteSpace(lcrRangoInicial) && !String.IsNullOrWhiteSpace(lcrRangoFinal))
                {
                    if (Funciones.flgSoloNumerosEx(tcrValor) && Funciones.flgSoloNumerosEx(lcrRangoInicial) &&
                        Funciones.flgSoloNumerosEx(lcrRangoFinal))
                    {
                        // Cuando no hay puntos decimales
                        if (Funciones.flgSoloNumeros(tcrValor) && Funciones.flgSoloNumeros(lcrRangoInicial) &&
                            Funciones.flgSoloNumeros(lcrRangoFinal))
                        {
                            #region Numero entero sin decimal
                            if (!Funciones.flgSoloNumeros(tcrValor, Convert.ToInt32(lcrRangoInicial), Convert.ToInt32(lcrRangoFinal)))
                            {
                                // Es posible que este en valores permitidos
                                if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                                {
                                    lcrValorReturn = lcrTitulo + ": Valor (" + tcrValor + ")  no esta dentro del rango: " + lcrRangoInicial + " - " + lcrRangoFinal;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region Numero entero con decimal
                            if (!Funciones.flgSoloNumeros(tcrValor, Convert.ToDecimal(lcrRangoInicial), Convert.ToDecimal(lcrRangoFinal)))
                            {
                                // Es posible que este en valores permitidos
                                if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                                {
                                    lcrValorReturn = lcrTitulo + ": Valor (" + tcrValor + ")  no esta dentro del rango: " + lcrRangoInicial + " - " + lcrRangoFinal;
                                }
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        lcrValorReturn = lcrTitulo + ": Valor (" + tcrValor + ") no esta dentro del rango: " +
                                         lcrRangoInicial + " - " + lcrRangoFinal;
                    }

                }
                else if (!String.IsNullOrWhiteSpace(lcrValorPermitido))
                {
                    //if (!Funciones.flgExisteSubCadenaString(tcrValorFecha,lcrCampo.sis_valper_siac))
                    if (!Funciones.flgExisteElemento(tcrValor, ",", lcrValorPermitido))
                    {
                        if (!Funciones.flgSoloNumerosEx(tcrValor))
                        {
                            lcrValorReturn = lcrTitulo + ": Valor (" + tcrValor + ") no esta permitido: (" + lcrValorPermitido + ")";
                        }
                    }
                }
            }
            else
            {
                // Valor es requerido 
                if (tobObjObjeto.IsRequerido == "True")
                {
                    lcrValorReturn = lcrTitulo + ": Valor es requerido";
                }
            }

            return lcrValorReturn;
        }
        #endregion
        //---------------------------------------------------------------
        //  GESTION VALIDACION DE OBJETOS TEXTBOXREL
        //---------------------------------------------------------------
        #region flgValidRegRelacionTabla: Validar Codigos desde tablas relacion
        /// <summary>
        /// <para>Mostrar valores en objeto desde temporal datos digitados</para>
        /// </summary>
        public bool flgValidRegRelacionTabla(String tcrNombreTextBoxRelCodigo)
        {
            String lcrValorReturn    = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError    = String.Empty;
            String lcrNombreCampo    = String.Empty;
            String lcrNivelError     = "ALTO";
            String lcrImgNivelError  = "Edt_hist_vista_anulado.png";

            var llgReturn = false;

            var lobObjCod = fobRegSelectParenObjeto("OBJETOS", "", tcrNombreTextBoxRelCodigo).FirstOrDefault();

            if (lobObjCod != null)
            {
                var lobObjBas = fobRegSelectParenObjeto("OBJETOS", "", lobObjCod.Parent).FirstOrDefault();
                var lobObjDes = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobObjCod.Parent).FirstOrDefault();

                var lobTextBoxCod = lobObjCod.RefObjeto as TextBox;
                var lobTextBoxDes = lobObjDes.RefObjeto as TextBox;
                lobTextBoxDes.Text = String.Empty;

                lcrNombreCampo = lobObjBas.Titulo;
                lcrValorReturn = String.Empty;
                lcrCodigoError = lobObjCod.TabIndex;

                switch (lobObjBas.TablaOrigen)
                {
                    case "RGAD": // Maestro Admision Pacientes
                        lcrValorReturn = fcrValidAdmregadmision(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "TDIA":    // Diagnosticos CIE 10
                        llgReturn = true;
                        lcrValorReturn = fcrValidSiadiagnosticos(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "USUA":    // Usuarios Pacientes
                        lcrValorReturn = fcrValidSiausuarioatend(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "USUX":    // Usuarios del sistema
                        lcrValorReturn = fobRegBuscarSysusuarios(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "TIDE":    // Tipo identificacion
                        llgReturn = true;
                        lcrValorReturn = fcrValidSiatipideusario(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "PROF": // Profesionales que prestan servicios
                        lcrValorReturn = fcrValidSiamaeprofsalud(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "TPAT":    // Tipo Profesional que atiende
                        llgReturn = true;
                        lcrValorReturn = fcrValidSiatipprofatien(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "TDIS":    // Tipo discapacidad
                        llgReturn = true;
                        lcrValorReturn = fcrValidSiatipdiscapaci(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "OCUP":    // Ocupaciones o actividades de trabajo
                        llgReturn = true;
                        lcrValorReturn = fcrValidSisocupaciones(lobTextBoxCod.Text, lobObjBas, ref lobTextBoxDes);
                        break;

                    case "MANT":    // Manual tarifario de serivicos (CUPS/SOAT/ISS...)
                        llgReturn = true;
                        lcrValorReturn = fcrValidFcmServTarifario(lobTextBoxCod.Text, lobObjCod, lobObjBas, ref lobTextBoxDes);
                        break;

                }
                fcvSetBorderColorErrorRel(lcrValorReturn, ref lobTextBoxCod, ref lobTextBoxDes, ref lobObjCod, ref lobObjDes);
                //lobTextBoxDes.Text = lcrValor;
            }
            // si hay error registrar en el log con el nombre y titulo del objeto 
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

            llgReturn = !String.IsNullOrWhiteSpace(lcrValorReturn) ? false : true;

            return llgReturn;
        }
        #endregion
        // Cambiar bordes de objetos cuando hay error
        #region fcvSetBorderColorErrorRel
        /// <summary>
        /// <para>Cambia el color del borde del TextboxRelacion que presenta error de validacion</para>
        /// </summary>
        public void fcvSetBorderColorErrorRel(String tcrTextoError, ref TextBox tobTextBoxCod,
                                            ref TextBox tobTextBoxDes, ref ClassXmlPropObjeto tobObjCod, ref ClassXmlPropObjeto tobObjDes)
        {
            if (!String.IsNullOrWhiteSpace(tcrTextoError))
            {
                tobTextBoxCod.ToolTip = tcrTextoError;
                tobTextBoxDes.ToolTip = tcrTextoError;
                tobTextBoxCod.BorderBrush = Brushes.Red;
                tobTextBoxDes.BorderBrush = Brushes.Red;
            }
            else
            {
                tobTextBoxCod.ToolTip = EdtUtilidades.SetToolTip(tobObjCod.ToolTip);
                tobTextBoxDes.ToolTip = EdtUtilidades.SetToolTip(tobObjDes.ToolTip);
                tobTextBoxCod.BorderBrush = EdtUtilidades.SetSolidColorBrush(tobObjCod.BorderBrush, Brushes.DarkTurquoise);
                tobTextBoxDes.BorderBrush = EdtUtilidades.SetSolidColorBrush(tobObjDes.BorderBrush, Brushes.DarkTurquoise);
            }
        }
        #endregion
        #region fcvSetBorderColorError
        /// <summary>
        /// <para>Cambia el color del borde del TextBox que presenta error de validacion</para>
        /// </summary>
        public void fcvSetBorderColorError(String tcrTextoError, ref TextBox tobTextBox, ref ClassXmlPropObjeto tobRegistroObj)
        {
            if (!String.IsNullOrWhiteSpace(tcrTextoError))
            {
                tobTextBox.ToolTip = tcrTextoError;
                tobTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                tobTextBox.ToolTip = EdtUtilidades.SetToolTip(tobRegistroObj.ToolTip);
                tobTextBox.BorderBrush = EdtUtilidades.SetSolidColorBrush(tobRegistroObj.BorderBrush, Brushes.DarkTurquoise);
            }
        }
        #endregion
        #region fcvSetBorderColorErrorRichTextBox
        /// <summary>
        /// <para>Cambia el color del borde del RichTextBox que presenta error de validacion</para>
        /// </summary>
        public void fcvSetBorderColorErrorRichTextBox(String tcrTextoError, ref RichTextBox lobRichTextBox, ref ClassXmlPropObjeto tobRegistroObj)
        {
            if (!String.IsNullOrWhiteSpace(tcrTextoError))
            {
                lobRichTextBox.ToolTip = tcrTextoError;
                lobRichTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                lobRichTextBox.ToolTip = EdtUtilidades.SetToolTip(tobRegistroObj.ToolTip);
                lobRichTextBox.BorderBrush = EdtUtilidades.SetSolidColorBrush(tobRegistroObj.BorderBrush, Brushes.DarkTurquoise);
            }
        }
        #endregion
        #region fcvSetBorderColorError ComboBox
        /// <summary>
        /// <para>Cambia el color del borde del ComboBox que presenta error de validacion</para>
        /// </summary>
        public void fcvSetBorderColorError(String tcrTextoError, ref ComboBox tobComboBox, ref ClassXmlPropObjeto tobRegistroObj)
        {
            if (!String.IsNullOrWhiteSpace(tcrTextoError))
            {
                tobComboBox.ToolTip = tcrTextoError;
                //tobComboBox.BorderBrush = Brushes.Red;
                tobComboBox.Foreground = Brushes.Red;
            }
            else
            {
                tobComboBox.ToolTip = EdtUtilidades.SetToolTip(tobRegistroObj.ToolTip);
                //tobComboBox.BorderBrush = EdtUtilidades.SetSolidColorBrush(tobRegistroObj.BorderBrush, Brushes.DarkTurquoise);
                tobComboBox.Foreground = EdtUtilidades.SetSolidColorBrush(tobRegistroObj.Foreground, Brushes.Black);

            }
        }
        #endregion
        //Validaciones en tablas relacionadas
        #region fcrValidAdmregadmision
        /// <summary>
        /// <para>Validacion Maestro admision de pacientes</para>
        /// </summary>
        public String fcrValidAdmregadmision(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                using (DbAplicacion db = new DbAplicacion())
                {
                    var lcrQuery = from admregadmision in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   where admregadmision.sia_regate_rgat.Equals(tcrCodigo)
                                   select new
                                   {
                                       Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                       Sia_nomusu_usua = usua.sia_nomusu_usua,
                                   };

                    if (lcrQuery != null)
                    {
                        tobTextBoxDes.Text = lcrQuery.FirstOrDefault().Sia_nomusu_usua;
                    }
                    else
                    {
                        lcrValor = tobObjBas.Titulo + ": No existe";
                    }
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiadiagnosticos
        /// <summary>
        /// <para>Validacion codigos tabla CIE 10</para>
        /// </summary>
        public String fcrValidSiadiagnosticos(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tcrCodigo);

                if (tmp != null)
                {
                    tobTextBoxDes.Text = tmp.sia_desdia_tdia;
                    //  Validar Sexo que aplica 
                    if (tmpRegAdmision != null)
                    {
                        if (tmpRegAdmision.Sis_codsex_sexo != tmp.sia_sexapl_tdia && tmp.sia_sexapl_tdia != "A")
                        {
                            lcrValor = tobObjBas.Titulo + ": Diagnostico no permitido para sexo del usuario";
                        }
                        else
                        {
                            var lnuSipsEdadIniDia = fnuEdadEnDias(tmp.sia_medini_tdia, (int)tmp.sia_edaini_tdia);
                            var lnuSipsEdadFinDia = fnuEdadEnDias(tmp.sia_medfin_tdia, (int)tmp.sia_edafin_tdia);

                            var lcrTextoRangoEdadDx = fcrTextoRangoEdadServicio(tmp.sia_medini_tdia, (int)tmp.sia_edaini_tdia,
                                                                                      tmp.sia_medfin_tdia, (int)tmp.sia_edafin_tdia);

                            if (tmpRegAdmision.Sia_edadia_usua < lnuSipsEdadIniDia || tmpRegAdmision.Sia_edadia_usua > lnuSipsEdadFinDia)
                            {
                                lcrValor = "Edad del paciente no aplica para rango edad del diagnóstico: " + tcrCodigo + " (" + lcrTextoRangoEdadDx + ")";
                                if (tmpRegAdmision.Sia_edaano_usua > 0)
                                {
                                    lcrValor += " la edad del paciente en años es " + tmpRegAdmision.Sia_edaano_usua.ToString();
                                }
                                else if (tmpRegAdmision.Sia_edames_usua > 0)
                                {
                                    lcrValor += " la edad del paciente en meses es " + tmpRegAdmision.Sia_edames_usua.ToString();
                                }
                                else
                                {
                                    lcrValor += " la edad del paciente en dias es " + tmpRegAdmision.Sia_edadia_usua.ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fobRegBuscarSysusuarios
        /// <summary>
        /// <para>Validacion usuarios del sistema</para>
        /// </summary>
        public String fobRegBuscarSysusuarios(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sys_nomusu_usux))
                {
                    tobTextBoxDes.Text = tmp.sys_nomusu_usux;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiausuarioatend
        /// <summary>
        /// <para>Validacion Maestro de usuarios/pacientes atendidos</para>
        /// </summary>
        public String fcrValidSiausuarioatend(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nomusu_usua))
                {
                    tobTextBoxDes.Text = tmp.sia_nomusu_usua;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiatipideusario
        /// <summary>
        /// <para>Validacion tipo identificacion usuarios/pacientes atendidos</para>
        /// </summary>
        public String fcrValidSiatipideusario(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_deside_tide))
                {
                    tobTextBoxDes.Text = tmp.sia_deside_tide;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiamaeprofsalud
        /// <summary>
        /// <para>Validacion Profesionales que prestan servicios medicos</para>
        /// </summary>
        public String fcrValidSiamaeprofsalud(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                {
                    tobTextBoxDes.Text = tmp.sia_nompro_prof;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiatablaeps
        /// <summary>
        /// <para>Validacion Tabla EPS Aseguradoras</para>
        /// </summary>
        public String fcrValidSiatablaeps(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                {
                    tobTextBoxDes.Text = tmp.sia_codeps_teps;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiatipdiscapaci
        /// <summary>
        /// <para>Validacion tipo discapacidad del usuario o paciente</para>
        /// </summary>
        public String fcrValidSiatipdiscapaci(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiatipdiscapaci(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdis_tdis))
                {
                    tobTextBoxDes.Text = tmp.sia_desdis_tdis;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSiatipprofatien
        /// <summary>
        /// <para>Tipo de profesional que atiende el servicio</para>
        /// </summary>
        public String fcrValidSiatipprofatien(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SIAValidarCodigo.fobRegBuscarSiatipprofatien(tcrCodigo);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_despat_tpat))
                {
                    tobTextBoxDes.Text = tmp.sia_despat_tpat;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidSisocupaciones
        /// <summary>
        /// <para>Lista de ocupaciones o profesiones para usuarios atendidos y o terceros</para>
        /// </summary>
        public String fcrValidSisocupaciones(String tcrCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = SISValidarCodigo.fobRegBuscarSisocupaciones(tcrCodigo);
                if (tmp != null)
                {
                    tobTextBoxDes.Text = tmp.sis_desocu_ocup;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        #region fcrValidFcmServTarifario
        /// <summary>
        /// <para>Codigos y servicios en tarifarios</para>
        /// </summary>
        public String fcrValidFcmServTarifario(String tcrCodigo, ClassXmlPropObjeto tobObjCodigo, ClassXmlPropObjeto tobObjBas, ref TextBox tobTextBoxDes)
        {
            var lcrValor = String.Empty;
            if (String.IsNullOrWhiteSpace(tcrCodigo))
            {
                // Valor es requerido 
                if (tobObjBas.IsRequerido == "True")
                {
                    lcrValor = tobObjBas.Titulo + ": Es requerido";
                }
            }
            else
            {
                var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(tcrCodigo, tmpRegAdmision.Fcm_codman_mans);
                if (tmp != null)
                {
                    var lobRegistro      = tmpCapturaDatos.FirstOrDefault(x => x.IgGrupoRegistro.Equals(tobObjBas.CodigoPlantilla) && x.Name.Equals(tobObjCodigo.Name));
                    lobRegistro.ValorAux = tmp.fcm_coddig_mant.Trim() + "*" + tmp.fcm_codser_mant.Trim();
                    tobTextBoxDes.Text   = tmp.fcm_desser_mant;
                }
                else
                {
                    lcrValor = tobObjBas.Titulo + ": No existe";
                }
            }
            return lcrValor;
        }
        #endregion
        //-------------------------------------------------
        // Genera texto para edad servicio y valores edad
        //-------------------------------------------------
        #region fnuEdadEnDias: Convierte edad a dias segun la medida dada
        /// <summary>
        /// <para>Convierte edad a dias segun la medida dada</para> 
        /// <para>tcrMedidaEdad: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdad: Dato de edad dada segun tcrMedidaEdad</para> 
        /// </summary>
        public static int fnuEdadEnDias(String tcrMedidaEdad, int tnuEdad)
        {
            var lnuReturn = tnuEdad;
            if (tnuEdad > 0)
            {
                switch (tcrMedidaEdad)
                {
                    case "1": // Años
                        lnuReturn = tnuEdad * 365;
                        break;

                    case "2": // Mes
                        lnuReturn = tnuEdad * 30;
                        break;
                }
            }
            return lnuReturn;
        }
        #endregion
        #region fcrTextoRangoEdadServicio: Genera el texto para vista rango edad servicio
        /// <summary>
        /// <para>Genera el texto para vista rango edad servicio dado los parametros edad configracion del servicio IPS</para> 
        /// <para>PARAMETROS:</para> 
        /// <para>tcrMedidaEdadInicial: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdadInicial: valor numerico segun dias años o meses</para> 
        /// <para>tcrMedidaEdadFinal: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdadFinal: valor numerico segun dias años o meses</para> 
        /// </summary>
        public static String fcrTextoRangoEdadServicio(String tcrMedidaEdadInicial, int tnuEdadInicial, String tcrMedidaEdadFinal, int tnuEdadFinal)
        {
            var lcrReturn = String.Empty;
            var lcrTexto1 = String.Empty;
            var lcrTexto2 = String.Empty;

            lcrTexto1 = fcrTextoMedidaEdad(tcrMedidaEdadInicial, tnuEdadInicial);
            lcrTexto2 = fcrTextoMedidaEdad(tcrMedidaEdadFinal, tnuEdadFinal);

            lcrReturn = lcrTexto1 + " hasta " + lcrTexto2;

            return lcrReturn;
        }
        public static String fcrTextoMedidaEdad(String tcrMedidaEdad, int tnuEdad)
        {
            var lcrReturn = String.Empty;
            var lcrTexto = String.Empty;

            switch (tcrMedidaEdad)
            {
                case "1": // Años
                    lcrTexto = tnuEdad <= 1 ? "Año" : "Años";
                    break;

                case "2": // Mes
                    lcrTexto = tnuEdad <= 1 ? "Mes" : "Meses";
                    break;

                case "3": // Dias
                    lcrTexto = tnuEdad <= 1 ? "Dia" : "Dias";
                    break;
            }
            lcrReturn = tnuEdad.ToString().Trim() + " " + lcrTexto;

            return lcrReturn;
        }
        #endregion
        //---------------------------------------------------------------
        // ELIMINAR DATOS DE PLANTILLAS EN ETIQUETAS
        //---------------------------------------------------------------
        #region flgEdtAccionEliminarDatosEtiqueta : Eliminar registros una etiqueta
        /// <summary>
        /// <para>Eliminar del temporal los registros asociados al objeto etiqueta tgGrupoRegistro</para>
        /// </summary>
        public bool flgEdtAccionEliminarDatosEtiqueta(String tcrArchivoOrigen, String tgGrupoRegistro)
        {
            var llgReturn =false;
            List<ClassXmlPropDatos> lcrQuery = null;
            lcrQuery = fobRegSelectParentRegistro(tcrArchivoOrigen, "PLANTILLA", tgGrupoRegistro);

            if (lcrQuery != null)
            {
                llgReturn =true;
                foreach (ClassXmlPropDatos lobReg in lcrQuery)
                {
                     tmpCapturaDatos.Remove(lobReg);
                }
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        //- GENERAR TEXTO PARA GUARDAR ARCHIVO XML DATOS Y OBJETOS
        //------------------------------------------------------------
        #region fcrGenerarTextoXmlDatos: Generar el texto completo de los datos digitados
        /// <summary>
        /// <para>Generar el texto completo de los datos digitados</para>
        /// </summary>
        public String fcrGenerarTextoXmlDatos(String tcrEstado)
        {
            String lcrPlantilla     = String.Empty;
            String lcrPropiedades   = fcrTextoXmlPlantillaDatos();
            String lcrDatos         = fcrTextoXmlDatosDigitados(tcrEstado);
            String lcrObjetos       = fcrTextoXmlObjetoDigitados();
            String lcrObjetosHist   = tcrEstado == "2" ? fcrTextoXmlImagenesObjetosHistorial() : String.Empty;

            lcrPlantilla = "<?xml version='1.0' encoding='utf-8'?>\n" +
                           "<General>\n" +
                                lcrPropiedades + "\n" +
                                "\t<Datos>\n" +
                                lcrDatos +
                                "\t</Datos>\n" +
                                "\t<Objetos>\n" +
                                lcrObjetos + "\n" +
                                "\t</Objetos>\n" +
                                "\t<VistaHistorial>\n" +
                                lcrObjetosHist + "\n" +
                                "\t</VistaHistorial>\n" +
                           "</General>";

            return lcrPlantilla;
        }
        #endregion
        #region fcrTextoXmlPlantillaDatos: Generar propiedad plantilla de datos
        /// <summary>
        /// <para>Generar propiedad plantilla datos</para>
        /// </summary>
        public String fcrTextoXmlPlantillaDatos()
        {
            String lcrPlantilla = String.Empty;
            String lcrTabNivel2 = "\t";
            String lcrTabNivel3 = "\t\t\t\t";

            lcrPlantilla = lcrTabNivel2 + "<Propiedades Codigo ='" + gobRegPropPlantillaDatos.Codigo + "'\n" +
                           lcrTabNivel3 + " Name ='" + gobRegPropPlantillaDatos.Name + "'\n" +
                           lcrTabNivel3 + " NombreArchivoPlantilla='" + gcrPlantillaNombreArchivo + "'\n" +
                           lcrTabNivel3 + " VersionSistema='" + gobRegPropPlantillaDatos.VersionSistema + "'\n" +
                           lcrTabNivel3 + " VersionPlantilla='" + gobRegPropPlantillaDatos.VersionPlantilla + "'\n" +
                           lcrTabNivel3 + " Clave='" + gobRegPropPlantillaDatos.Clave + "'\n" +
                           lcrTabNivel3 + " CodigoGrupo='" + gobRegPropPlantillaDatos.CodigoGrupo + "'\n" +
                           lcrTabNivel3 + " TipoFormato='" + gobRegPropPlantillaDatos.TipoFormato + "'\n" +
                           lcrTabNivel3 + " GenerSecObjeto='" + gnuPlantillaGenerSecObjeto.ToString() + "'\n" +
                           lcrTabNivel3 + " PrefijoObjetos='" + gobRegPropPlantillaDatos.PrefijoObjetos + "'\n" +
                           lcrTabNivel3 + " DatosModoVista='" + gcrDatosModoVista + "'\n" +
                           lcrTabNivel3 + " SeparadorDecimal='" + gcrSysSeparadorDecimal + "'>\n" +
                           lcrTabNivel2 + "</Propiedades>";

            return lcrPlantilla;
        }
        #endregion
        #region fcrTextoXmlObjetoDigitados: Generar texto Xml objetos creados en modo captura
        /// <summary>
        /// <para>Generar texto Xml objetos creados en modo captura</para>
        /// </summary>
        public String fcrTextoXmlObjetoDigitados()
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenObjeto("OBJETOS", "CAPTURA", "");

            foreach (var lobItem in lobObjetos)
            {
                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += fcrTextoXmlObjetoTexto(lobItem, "1", lcrFinLinea);
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlDatosDigitados: Generar texto Xml datos creados en modo captura
        /// <summary>
        /// <para>Generar texto Xml datos creados en modo captura</para>
        /// </summary>
        public String fcrTextoXmlDatosDigitados(String tcrEstado)
        {
            String lcrPaginas   = String.Empty;
            String lcrListItem  = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t\t";
            String lcrFinLinea  = "\n";
            int lnuContador     = 0;

            // Para evitar guardar descripciones vacias al confirmar
            fcvGTablaComplementarDatosDigitados(tcrEstado);

            foreach (var lobItem in tmpCapturaDatos)
            {
                lnuContador++;
                if (lnuContador >= tmpCapturaDatos.Count) { lcrFinLinea = String.Empty; }
                #region Texto
                lcrListItem += lcrTabNivel2 + "<Campo IgGrupoRegistro='" + lobItem.IgGrupoRegistro + "'\n" +
                               lcrTabNivel3 + "Name='" + lobItem.Name + "'\n" +
                               lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "SiFiltroBusqueda='" + lobItem.SiFiltroBusqueda + "'\n" +
                               lcrTabNivel3 + "Binding='" + lobItem.Binding + "'\n" +
                               lcrTabNivel3 + "Valor='" + lobItem.Valor + "'\n" +
                               lcrTabNivel3 + "ValorDescipcion='" + lobItem.ValorDescripcion + "'\n" +
                               lcrTabNivel3 + "Indice='" + lobItem.Indice + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + lobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "TipoDato='" + lobItem.TipoDato + "'\n" +
                               lcrTabNivel3 + "TipoOrigenDatos='" + lobItem.TipoOrigenDatos + "'\n" +
                               lcrTabNivel3 + "TablaOrigen='" + lobItem.TablaOrigen + "'\n" +
                               lcrTabNivel3 + "IdRegistro='" + lobItem.IdRegistro + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + lobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "CodigoPlantilla='" + lobItem.CodigoPlantilla + "'\n" +
                               lcrTabNivel3 + "Navegador='" + lobItem.Navegador + "'>\n" +
                               lcrTabNivel2 + "</Campo>" + lcrFinLinea;
                #endregion
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlObjetosVistaHistorial: Generar texto Xml e imagenes vista muro del historial
        /// <summary>
        /// <para>Generar texto Xml e imagenes del historial vista en muro</para>
        /// </summary>
        public String fcrTextoXmlImagenesObjetosHistorial()
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t\t";
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenObjeto("OBJETOS", "NAVEGADOR", "ESCRITORIO");

            foreach (var lobItem in lobObjetos)
            {
                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                if (lobItem.SiMostrarEnMuro == "True")
                {
                    if (lobItem.TipoObjeto != "TEXTBOX" && 
                        lobItem.TipoObjeto != "TEXTBOXREL" && 
                        lobItem.TipoObjeto != "RICHTEXTBOX")
                    {
                        var lcrImagen = fobGenerarImagenVistaHistorial(lobItem.Name);
                        if (!String.IsNullOrWhiteSpace(lcrImagen.NombreArchivo))
                        {
                            #region Texto
                            lcrListItem += lcrTabNivel2 + "<Image Name='" + lobItem.Name + "'\n" +
                                           lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                           lcrTabNivel3 + "TipoObjeto='IMAGEN'\n" +
                                           lcrTabNivel3 + "RecursoArchivoTipo='IMAGEN'\n" +
                                           lcrTabNivel3 + "RecursoArchivoCodigo='" + lcrImagen.RecursoCodigo + "'\n" +
                                           lcrTabNivel3 + "RecursoArchivoUri='" + lcrImagen.RutaGaleria + "'\n" +
                                           lcrTabNivel3 + "RecursoArchivoNombre='" + lcrImagen.NombreArchivo + "'>\n" +
                                           lcrTabNivel2 + "</Image>" + lcrFinLinea;
                            #endregion
                        }
                    }
                    else 
                    {
                        var lcrTexto = fobGenerarTextoVistaHistorial(lobItem.Name);
                        if (!String.IsNullOrWhiteSpace(lcrTexto))
                        {
                            #region Texto
                            lcrListItem += lcrTabNivel2 + "<Texto Name='" + lobItem.Name + "'\n" +
                                           lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                           lcrTabNivel3 + "TipoObjeto='TEXTO'>\n" +
                                           lcrTabNivel3 + lcrTexto + "\n" +
                                           lcrTabNivel2 + "</Texto>" + lcrFinLinea;
                            #endregion
                        }
                    }
                }
            }
            return lcrListItem;
        }
        #endregion
        #region fobGenerarImagenVistaHistorial: Generar imagen para vista en historial del paciente
        /// <summary>
        /// <para>Generar imagen para vista en historial del paciente</para>
        /// </summary>
        public EdtUtilidades.ObjetoBitmapImage fobGenerarImagenVistaHistorial(String tcrNombreObjeto)
        {
            var llgGenerar = false;
            var lobImagen = new EdtUtilidades.ObjetoBitmapImage();
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombreObjeto).FirstOrDefault();
            try
            {
                // si la zona o la pagina se envio al muro el objeto ya no lo requiere
                if (lobObjeto.TipoObjeto != "ZONA" && lobObjeto.TipoObjeto != "PAGINA")
                {
                    var lobZona = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.ObjetoParentZona).FirstOrDefault();
                    var lobPagina = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.ObjetoParentPagina).FirstOrDefault();
                    if (lobZona.SiMostrarEnMuro == "False" && lobPagina.SiMostrarEnMuro == "False")
                    {
                        llgGenerar = true;
                    }
                }
                else
                {
                    llgGenerar = true;
                    if (lobObjeto.TipoObjeto == "ZONA")
                    {
                        var lobPagina = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.ObjetoParentPagina).FirstOrDefault();
                        if (lobPagina.SiMostrarEnMuro == "True")
                        {
                            llgGenerar = false;
                        }
                    }

                }
                // Generar el archivo de imagen
                if (llgGenerar == true)
                {
                    lobImagen.NombreArchivo = (gcrIdRegHistorialEventoActivo + "_" + lobObjeto.Name + ".png").ToLower();
                    lobImagen.RutaGaleria   = @"GaleriaRecursos\Imagenes\HistoriasClinicas\Historial";
                    lobImagen.RecursoCodigo = "IM000155";
                    lobImagen.RecursoTitulo = "Titulo";
                    lobImagen.RecursoDescripcion = "Imagen para el historial";
                    Visual lobRefVisual = null;

                    if (lobObjeto.TipoObjeto == "PAGINA")
                    {
                        lobRefVisual = lobObjeto.RefObjeto as Canvas;
                    }
                    else if (lobObjeto.ClaseBase == "GroupBox") // incluye Zonas, GrupoChk y gruporadibutton
                    {
                        lobRefVisual = lobObjeto.RefObjeto as GroupBox;

                    }
                    else if (lobObjeto.ClaseBase == "Image") // imagen
                    {
                        lobRefVisual = lobObjeto.RefObjeto as Image;

                    }
                    else 
                    {
                        lobImagen.NombreArchivo = String.Empty; // para saber que no se generó
                    }

                    if (lobRefVisual != null)
                    {
                        var lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lobImagen.RutaGaleria;
                        if (oApp.gcrAppRecursoTipoIpServidor == "NORED")
                        {
                            lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lobImagen.RutaGaleria;
                        }
                        var lobRenderImagen = Funciones.frtbCapturarPantallaAImagen(lobRefVisual, 96, 96);
                        if (lobRenderImagen != null)
                        {
                            Funciones.flgGuardarImagenPath(lobRenderImagen, lobImagen.NombreArchivo, lcrRutaDestino);
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fobGenerarImagenVistaHistorial");
            }
            return lobImagen;
        }
        #endregion
        #region fobGenerarTextoVistaHistorial: Generar texto de objetos para vista en historial del paciente
        /// <summary>
        /// <para>Generar texto de objetos para vista en historial del paciente</para>
        /// </summary>
        public String fobGenerarTextoVistaHistorial(String tcrNombreObjeto)
        {
            var lcrTexto = String.Empty;
            var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", tcrNombreObjeto).FirstOrDefault();
            try
            {
                // si la zona o la pagina se envio al muro el objeto ya no lo requiere
                if (lobObjeto.TipoObjeto == "TEXTBOXREL")
                {
                    var lobCodigo = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELCOD", tcrNombreObjeto).FirstOrDefault();
                    var lobDescrip = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", tcrNombreObjeto).FirstOrDefault();
                    if (lobCodigo!=null)
                    {
                        var lobjCod = lobCodigo.RefObjeto as TextBox;
                        lcrTexto = lobjCod.Text;
                    }
                    if (lobDescrip != null)
                    {
                        var lobjCod = lobDescrip.RefObjeto as TextBox;
                        lcrTexto = !String.IsNullOrWhiteSpace(lobjCod.Text) ? lcrTexto + " - " + lobjCod.Text : String.Empty;
                    }
                }
                else if (lobObjeto.TipoObjeto == "TEXTBOX")
                {
                    var lobjCod = lobObjeto.RefObjeto as TextBox;
                    lcrTexto = lobjCod.Text;
                }
                else if (lobObjeto.TipoObjeto == "RICHTEXTBOX")
                {
                    var lobjCod = lobObjeto.RefObjeto as RichTextBox;
                    TextRange textRange = new TextRange(lobjCod.Document.ContentStart, lobjCod.Document.ContentEnd);
                    lcrTexto = textRange.Text;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fobGenerarTextoVistaHistorial");
            }
            return lcrTexto;
        }
        #endregion
        //---------------------------------------------------------------
        //- GESTION GUARDAR DATOS DIGITADOS EN TABLAS 
        //---------------------------------------------------------------
        #region fcvGTablaActivarTablasDatosDigitados: Generar lista de temporales activos o usados para guardar datos
        /// <summary>
        /// <para>Generar lista de temporales (archivo para guardado historial H.C) activos o usados para datos segun los Binding de cada campo</para>
        /// </summary>
        public void fcvGTablaActivarTablasDatosDigitados(String tcrArchivoOrigen, String tcrCodigoPlantilla)
        {
            var lobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);
            //tmpArchvioHist = new List<ClassTempArchivoHistorico>();

            foreach (var lobItem in lobTemp)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.Binding) && !String.IsNullOrWhiteSpace(lobItem.BindingTabla))
                {
                    fcvGTablaActivarTablasDatosDigitados(lobItem.BindingTabla);
                }
            }
        }
        #endregion
        #region fcvGTablaActivarTablasDatosDigitados: Activar temporales de tablas para datos digitados
        /// <summary>
        /// <para>Activar temporales de tablas para datos digitados y registrar en temporal de referencia de archivos historicos activos</para>
        /// </summary>
        public void fcvGTablaActivarTablasDatosDigitados(String tcrNombreArchivo)
        {
            var lcrNombreArchivo = tcrNombreArchivo.ToUpper();
            var lcrIdArchivo = String.Empty;
            var lobReg = tmpArchvioHist.FirstOrDefault(x => x.NombreArchivo == lcrNombreArchivo);

            // cuando no existe hay que activar registro y Generar referencia en archivos activos
            if (lobReg == null)
            {
                lcrIdArchivo = String.Empty;

                switch (lcrNombreArchivo)
                {
                    case "HCLREGISEXTXA":
                        lcrIdArchivo = "1";
                        tmpRegTextBoxa = new ModeloHclregisextxa();
                        break;

                    case "HCLREGISEXTXB":
                        lcrIdArchivo = "2";
                        tmpRegTextBoxb = new ModeloHclregisextxb();
                        break;

                    case "HCLREGISEXTXC":
                        lcrIdArchivo = "3";
                        tmpRegTextBoxc = new ModeloHclregisextxc();
                        break;

                    case "HCLREGISEXNUM":
                        lcrIdArchivo = "4";
                        tmpRegNumerico = new ModeloHclregisexnum();
                        break;

                    case "HCLREGISEXCBO":
                        lcrIdArchivo = "5";
                        tmpRegComboBox = new ModeloHclregisexcbo();
                        break;

                    case "HCLREGISEXCBX":
                        lcrIdArchivo = "6";
                        tmpRegCombocbx = new ModeloHclregisexcbx();
                        break;

                    case "HCLREGISEXREC":
                        lcrIdArchivo = "7";
                        tmpRegRecursos = new ModeloHclregisexrec();
                        break;

                    case "HCLREGISEXFEC":
                        lcrIdArchivo = "8";
                        tmpRegDatFecha = new ModeloHclregisexfec();
                        break;

                    case "HCLREGISEXREL":
                        lcrIdArchivo = "9";
                        tmpRegRelacion = new ModeloHclregisexrel();
                        break;

                    case "HCLREGISEXRBT":
                        lcrIdArchivo = "10";
                        tmpRegRdButon1 = new ModeloHclregisexrbt();
                        break;

                    case "HCLREGISEXRBM":
                        lcrIdArchivo = "11";
                        tmpRegRdButon2 = new ModeloHclregisexrbm();
                        break;

                    case "HCLREGISEXRBN":
                        lcrIdArchivo = "12";
                        tmpRegRdButon3 = new ModeloHclregisexrbn();
                        break;

                    case "HCLREGISEXRBO":
                        lcrIdArchivo = "13";
                        tmpRegRdButon4 = new ModeloHclregisexrbo();
                        break;

                    case "HCLREGISEXMEM":
                        lcrIdArchivo = "14";
                        tmpRegRichText = new ModeloHclregisexmem();
                        break;

                    case "HCLREGISEXMEN":
                        lcrIdArchivo = "15";
                        tmpRegRichTmen = new ModeloHclregisexmen();
                        break;

                    case "HCLREGISEXMEO":
                        lcrIdArchivo = "16";
                        tmpRegRichTmeo = new ModeloHclregisexmeo();
                        break;

                    case "HCLREGISEXCHK":
                        lcrIdArchivo = "17";
                        tmpRegCheckBox = new ModeloHclregisexchk();
                        break;

                    case "HCLREGISEXCHL":
                        lcrIdArchivo = "18";
                        tmpRegCheckchl = new ModeloHclregisexchl();
                        break;

                    case "HCLREGISEXCHM":
                        lcrIdArchivo = "19";
                        tmpRegCheckchm = new ModeloHclregisexchm();
                        break;
                }
                if (!String.IsNullOrWhiteSpace(lcrIdArchivo))
                {
                    tmpArchvioHist.Add(new ClassTempArchivoHistorico { IdArchivo = lcrIdArchivo, NombreArchivo = lcrNombreArchivo });
                }
            }
        }
        #endregion
        #region flgGTablaConsultarHistDatosDigitados: Consultar los archivos historicos de datos
        /// <summary>
        /// <para>Consultar los archivos historicos de datos y cargar en temporales de gestion </para>
        /// <para>tcrGrupoArchivos: "01" "02" "03"...</para>
        /// </summary>
        public bool flgGTablaConsultarHistDatosDigitados(String tcrGrupoArchivos)
        {
            var lcrLlave = gobRegHistorialActivo.Hcl_nroreg_hcev;
            var lnuContNew = 0;
            var llgReturn = true;

            foreach (var lobReg in tmpArchvioHist)
            {
                switch (lobReg.NombreArchivo)
                {
                    case "HCLREGISEXTXA":
                        tmpRegTextBoxa = ModeloHclregisextxa.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegTextBoxa == null) { tmpRegTextBoxa = new ModeloHclregisextxa(); lnuContNew++; }

                        break;

                    case "HCLREGISEXTXB":
                        tmpRegTextBoxb = ModeloHclregisextxb.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegTextBoxb == null) { tmpRegTextBoxb = new ModeloHclregisextxb(); lnuContNew++; }

                        break;

                    case "HCLREGISEXTXC":
                        tmpRegTextBoxc = ModeloHclregisextxc.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegTextBoxc == null) { tmpRegTextBoxc = new ModeloHclregisextxc(); lnuContNew++; }

                        break;

                    case "HCLREGISEXNUM":
                        tmpRegNumerico = ModeloHclregisexnum.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegNumerico == null) { tmpRegNumerico = new ModeloHclregisexnum(); lnuContNew++; }
                        break;

                    case "HCLREGISEXCBO":
                        tmpRegComboBox = ModeloHclregisexcbo.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegComboBox == null) { tmpRegComboBox = new ModeloHclregisexcbo(); lnuContNew++; }

                        break;

                    case "HCLREGISEXCBX":
                        tmpRegCombocbx = ModeloHclregisexcbx.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegCombocbx == null) { tmpRegCombocbx = new ModeloHclregisexcbx(); lnuContNew++; }

                        break;

                    case "HCLREGISEXREC":
                        tmpRegRecursos = ModeloHclregisexrec.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRecursos == null) { tmpRegRecursos = new ModeloHclregisexrec(); lnuContNew++; }

                        break;

                    case "HCLREGISEXFEC":
                        tmpRegDatFecha = ModeloHclregisexfec.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegDatFecha == null) { tmpRegDatFecha = new ModeloHclregisexfec(); lnuContNew++; }

                        break;

                    case "HCLREGISEXREL":
                        tmpRegRelacion = ModeloHclregisexrel.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRelacion == null) { tmpRegRelacion = new ModeloHclregisexrel(); lnuContNew++; }

                        break;

                    case "HCLREGISEXRBT":
                        tmpRegRdButon1 = ModeloHclregisexrbt.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRdButon1 == null) { tmpRegRdButon1 = new ModeloHclregisexrbt(); lnuContNew++; }

                        break;

                    case "HCLREGISEXRBM":
                        tmpRegRdButon2 = ModeloHclregisexrbm.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRdButon2 == null) { tmpRegRdButon2 = new ModeloHclregisexrbm(); lnuContNew++; }

                        break;

                    case "HCLREGISEXRBN":
                        tmpRegRdButon3 = ModeloHclregisexrbn.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRdButon3 == null) { tmpRegRdButon3 = new ModeloHclregisexrbn(); lnuContNew++; }

                        break;

                    case "HCLREGISEXRBO":
                        tmpRegRdButon4 = ModeloHclregisexrbo.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRdButon4 == null) { tmpRegRdButon4 = new ModeloHclregisexrbo(); lnuContNew++; }

                        break;

                    case "HCLREGISEXMEM":
                        tmpRegRichText = ModeloHclregisexmem.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRichText == null) { tmpRegRichText = new ModeloHclregisexmem(); lnuContNew++; }

                        break;

                    case "HCLREGISEXMEN":
                        tmpRegRichTmen = ModeloHclregisexmen.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRichTmen == null) { tmpRegRichTmen = new ModeloHclregisexmen(); ; lnuContNew++; }

                        break;

                    case "HCLREGISEXMEO":
                        tmpRegRichTmeo = ModeloHclregisexmeo.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegRichTmeo == null) { tmpRegRichTmeo = new ModeloHclregisexmeo(); lnuContNew++; }

                        break;

                    case "HCLREGISEXCHK":
                        tmpRegCheckBox = ModeloHclregisexchk.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegCheckBox == null) { tmpRegCheckBox = new ModeloHclregisexchk(); lnuContNew++; }

                        break;

                    case "HCLREGISEXCHL":
                        tmpRegCheckchl = ModeloHclregisexchl.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegCheckchl == null) { tmpRegCheckchl = new ModeloHclregisexchl(); lnuContNew++; }

                        break;

                    case "HCLREGISEXCHM":
                        tmpRegCheckchm = ModeloHclregisexchm.fobRegistroArchivo("R1", lcrLlave, tcrGrupoArchivos);
                        if (tmpRegCheckchl == null) { tmpRegCheckchm = new ModeloHclregisexchm(); lnuContNew++; }

                        break;
                }
            }
            if (tmpArchvioHist.Count != 0)
            {
                // no se cargo nada devolver falso para cargar valores por defecto
                llgReturn = lnuContNew == tmpArchvioHist.Count ? false : true;
            }
            return llgReturn;
        }
        #endregion
        #region fcvGTablaSetValorDatosDigitados: llevar los datos digitados a cada temporal de tablas
        /// <summary>
        /// <para>Usando Refelxion de (InvokeMember) llevar los datos digitados a cada temporal antes de confirmar en tablas</para>
        /// </summary>
        public void fcvGTablaSetValorDatosDigitados(String tcrEstado)
        {
            var lcrValor = String.Empty;
            // Variables para Reflexion de datos
            #region Reflexion
            Type RefTextBoxa = tmpRegTextBoxa != null ? tmpRegTextBoxa.GetType() : null;
            Type RefTextBoxb = tmpRegTextBoxb != null ? tmpRegTextBoxb.GetType() : null;
            Type RefTextBoxc = tmpRegTextBoxc != null ? tmpRegTextBoxc.GetType() : null;
            Type RefNumerico = tmpRegNumerico != null ? tmpRegNumerico.GetType() : null;
            Type RefComboBox = tmpRegComboBox != null ? tmpRegComboBox.GetType() : null;
            Type RefComboCbx = tmpRegCombocbx != null ? tmpRegCombocbx.GetType() : null;
            Type RefRecursos = tmpRegRecursos != null ? tmpRegRecursos.GetType() : null;
            Type RefDatFecha = tmpRegDatFecha != null ? tmpRegDatFecha.GetType() : null;
            Type RefRelacion = tmpRegRelacion != null ? tmpRegRelacion.GetType() : null;
            Type RefRdButon1 = tmpRegRdButon1 != null ? tmpRegRdButon1.GetType() : null;
            Type RefRdButon2 = tmpRegRdButon2 != null ? tmpRegRdButon2.GetType() : null;
            Type RefRdButon3 = tmpRegRdButon3 != null ? tmpRegRdButon3.GetType() : null;
            Type RefRdButon4 = tmpRegRdButon4 != null ? tmpRegRdButon4.GetType() : null;
            Type RefRichText = tmpRegRichText != null ? tmpRegRichText.GetType() : null;
            Type RefRichTmen = tmpRegRichTmen != null ? tmpRegRichTmen.GetType() : null;
            Type RefRichTmeo = tmpRegRichTmeo != null ? tmpRegRichTmeo.GetType() : null;
            Type RefCheckBox = tmpRegCheckBox != null ? tmpRegCheckBox.GetType() : null;
            Type RefCheckChl = tmpRegCheckchl != null ? tmpRegCheckchl.GetType() : null;
            Type RefCheckChm = tmpRegCheckchm != null ? tmpRegCheckchm.GetType() : null;
            #endregion

            // Para evitar guardar descripciones vacias al confirmar
            fcvGTablaComplementarDatosDigitados(tcrEstado);

            foreach (var lobItem in tmpCapturaDatos)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.BindingTabla))
                {
                    lcrValor = lobItem.Valor;
                    // Verificar datos en variables especiales
                    if (lobItem.VariablePublica == "HOSPIT_RESUM_EVOLUCI_NOTASMED") // Evoluiones medicas no se guardan 
                    {
                        lcrValor = String.Empty;
                    }

                    #region Reflexion Datos
                    var lcrNombreArchivo = lobItem.BindingTabla.ToUpper();

                    switch (lcrNombreArchivo)
                    {
                        case "HCLREGISEXTXA":
                            #region Gestion
                            if (tmpRegTextBoxa != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegTextBoxa.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegTextBoxa.Hcl_nroreg_hctx = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegTextBoxa.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegTextBoxa.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegTextBoxa.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                    tmpRegTextBoxa.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegTextBoxa.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegTextBoxa.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegTextBoxa.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegTextBoxa.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegTextBoxa.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegTextBoxa.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegTextBoxa.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegTextBoxa.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefTextBoxa.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegTextBoxa,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXTXB":
                            #region Gestion
                            if (tmpRegTextBoxb != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegTextBoxb.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegTextBoxb.Hcl_nroreg_hcta = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegTextBoxb.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegTextBoxb.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegTextBoxb.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                    tmpRegTextBoxb.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegTextBoxb.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegTextBoxb.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegTextBoxb.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegTextBoxb.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegTextBoxb.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegTextBoxb.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegTextBoxb.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegTextBoxb.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefTextBoxb.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegTextBoxb,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXTXC":
                            #region Gestion
                            if (tmpRegTextBoxc != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegTextBoxc.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegTextBoxc.Hcl_nroreg_hctc = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegTextBoxc.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegTextBoxc.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegTextBoxc.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                    tmpRegTextBoxc.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegTextBoxc.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegTextBoxc.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegTextBoxc.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegTextBoxc.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegTextBoxc.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegTextBoxc.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegTextBoxc.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegTextBoxc.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefTextBoxc.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegTextBoxc,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXNUM":
                            #region Gestion
                            if (tmpRegNumerico != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegNumerico.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegNumerico.Hcl_nroreg_hcnu = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegNumerico.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegNumerico.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegNumerico.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegNumerico.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegNumerico.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegNumerico.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegNumerico.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegNumerico.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegNumerico.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegNumerico.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegNumerico.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegNumerico.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefNumerico.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegNumerico,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCBO":
                            #region Gestion
                            if (tmpRegComboBox != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegComboBox.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegComboBox.Hcl_nroreg_hccb = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegComboBox.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegComboBox.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegComboBox.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegComboBox.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegComboBox.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegComboBox.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegComboBox.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegComboBox.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegComboBox.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegComboBox.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegComboBox.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegComboBox.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefComboBox.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegComboBox,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                                // Guardar la descripcion del dato
                                if (!String.IsNullOrWhiteSpace(lobItem.BindingDescripcion))
                                {
                                    RefComboBox.InvokeMember(lobItem.BindingDescripcion, BindingFlags.SetField, null, tmpRegComboBox,
                                                             new Object[] { lobItem.ValorDescripcion }, System.Globalization.CultureInfo.CurrentCulture);
                                }
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCBX":
                            #region Gestion
                            if (tmpRegCombocbx != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegCombocbx.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegCombocbx.Hcl_nroreg_hcbx = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegCombocbx.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegCombocbx.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegCombocbx.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegCombocbx.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegCombocbx.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegCombocbx.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegCombocbx.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegCombocbx.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegCombocbx.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegCombocbx.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegCombocbx.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegCombocbx.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefComboCbx.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegCombocbx,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                                // Guardar la descripcion del dato
                                if (!String.IsNullOrWhiteSpace(lobItem.BindingDescripcion))
                                {
                                    RefComboCbx.InvokeMember(lobItem.BindingDescripcion, BindingFlags.SetField, null, tmpRegCombocbx,
                                                             new Object[] { lobItem.ValorDescripcion }, System.Globalization.CultureInfo.CurrentCulture);
                                }
                            }
                            break;
                            #endregion

                        case "HCLREGISEXREC":
                            #region Gestion
                            if (tmpRegRecursos != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRecursos.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRecursos.Hcl_nroreg_hcrc = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRecursos.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRecursos.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRecursos.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRecursos.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRecursos.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRecursos.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRecursos.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRecursos.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRecursos.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRecursos.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRecursos.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRecursos.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRecursos.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRecursos,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXFEC":
                            #region Gestion
                            if (tmpRegDatFecha != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegDatFecha.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegDatFecha.Hcl_nroreg_hcfc = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegDatFecha.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegDatFecha.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegDatFecha.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegDatFecha.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegDatFecha.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegDatFecha.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegDatFecha.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegDatFecha.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegDatFecha.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegDatFecha.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegDatFecha.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegDatFecha.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefDatFecha.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegDatFecha,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXREL":
                            #region Gestion
                            if (tmpRegRelacion != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRelacion.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRelacion.Hcl_nroreg_hcre = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRelacion.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRelacion.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRelacion.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRelacion.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRelacion.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRelacion.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRelacion.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRelacion.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRelacion.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRelacion.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRelacion.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRelacion.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                // cuando sea Tipo Objeto "TEXTBOXRELCOD" y tiene valor en Valor Auxiliar
                                if (lobItem.TipoObjeto == "TEXTBOXRELCOD")
                                {
                                    if (!String.IsNullOrWhiteSpace(lobItem.ValorAux))
                                    {
                                        lcrValor = lobItem.ValorAux;
                                    }
                                }
                                RefRelacion.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRelacion,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBT":
                            #region Gestion
                            if (tmpRegRdButon1 != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRdButon1.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRdButon1.Hcl_nroreg_hcrb = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRdButon1.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRdButon1.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRdButon1.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRdButon1.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRdButon1.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRdButon1.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRdButon1.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRdButon1.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRdButon1.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRdButon1.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRdButon1.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRdButon1.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRdButon1.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRdButon1,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBM":
                            #region Gestion
                            if (tmpRegRdButon2 != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRdButon2.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRdButon2.Hcl_nroreg_hcbm = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRdButon2.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRdButon2.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRdButon2.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRdButon2.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRdButon2.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRdButon2.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRdButon2.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRdButon2.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRdButon2.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRdButon2.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRdButon2.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRdButon2.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRdButon2.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRdButon2,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBN":
                            #region Gestion
                            if (tmpRegRdButon3 != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRdButon3.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRdButon3.Hcl_nroreg_hcbn = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRdButon3.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRdButon3.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRdButon3.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRdButon3.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRdButon3.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRdButon3.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRdButon3.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRdButon3.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRdButon3.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRdButon3.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRdButon3.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRdButon3.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRdButon3.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRdButon3,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBO":
                            #region Gestion
                            if (tmpRegRdButon4 != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRdButon4.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRdButon4.Hcl_nroreg_hcbo = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRdButon4.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRdButon4.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRdButon4.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRdButon4.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRdButon4.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRdButon4.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRdButon4.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRdButon4.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRdButon4.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRdButon4.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRdButon4.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRdButon4.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRdButon4.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRdButon4,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEM":
                            #region Gestion
                            if (tmpRegRichText != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRichText.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRichText.Hcl_nroreg_hcme = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRichText.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRichText.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRichText.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRichText.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRichText.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRichText.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRichText.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRichText.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRichText.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRichText.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRichText.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRichText.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRichText.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRichText,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEN":
                            #region Gestion
                            if (tmpRegRichTmen != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRichTmen.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRichTmen.Hcl_nroreg_hcmn = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRichTmen.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRichTmen.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRichTmen.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRichTmen.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRichTmen.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRichTmen.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRichTmen.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRichTmen.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRichTmen.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRichTmen.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRichTmen.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRichTmen.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRichTmen.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRichTmen,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEO":
                            #region Gestion
                            if (tmpRegRichTmeo != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegRichTmeo.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegRichTmeo.Hcl_nroreg_hcmo = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegRichTmeo.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegRichTmeo.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegRichTmeo.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegRichTmeo.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegRichTmeo.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegRichTmeo.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegRichTmeo.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegRichTmeo.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegRichTmeo.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegRichTmeo.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegRichTmeo.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegRichTmeo.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                RefRichTmeo.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegRichTmeo,
                                                         new Object[] { lcrValor }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHK":
                            #region Gestion
                            if (tmpRegCheckBox != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegCheckBox.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegCheckBox.Hcl_nroreg_hchk = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegCheckBox.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegCheckBox.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegCheckBox.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegCheckBox.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegCheckBox.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegCheckBox.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegCheckBox.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegCheckBox.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegCheckBox.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegCheckBox.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegCheckBox.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegCheckBox.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                var lcrValorEx = lcrValor.ToUpper() == "TRUE" || lcrValor == "1" ? "1" : "2";
                                RefCheckBox.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegCheckBox,
                                                         new Object[] { lcrValorEx }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHL":
                            #region Gestion
                            if (tmpRegCheckchl != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegCheckchl.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegCheckchl.Hcl_nroreg_hchl = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegCheckchl.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegCheckchl.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegCheckchl.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegCheckchl.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegCheckchl.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegCheckchl.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegCheckchl.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegCheckchl.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegCheckchl.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegCheckchl.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegCheckchl.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegCheckchl.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                var lcrValorEx = lcrValor.ToUpper() == "TRUE" || lcrValor == "1" ? "1" : "2";
                                RefCheckChl.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegCheckchl,
                                                         new Object[] { lcrValorEx }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHM":
                            #region Gestion
                            if (tmpRegCheckchm != null)
                            {
                                if (String.IsNullOrWhiteSpace(tmpRegCheckchm.Hcl_nroreg_hcev))
                                {
                                    #region Datos Basicos del registro
                                    tmpRegCheckchm.Hcl_nroreg_hchm = gobRegHistorialActivo.Hcl_nroreg_hcev.Trim() + "R1";
                                    tmpRegCheckchm.Grp_idereg_grpl = tmpPlantilla.FirstOrDefault().Codigo;
                                    tmpRegCheckchm.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev;
                                    tmpRegCheckchm.Grp_idepla_grpl = gobRegHistorialActivo.Grp_idepla_grpl;
                                    tmpRegCheckchm.Grp_idepla_grpv = gobRegHistorialActivo.Grp_idepla_grpv;
                                    #endregion
                                }
                                #region Datos Basicos del registro
                                tmpRegCheckchm.Hcl_codreg_hcca = gobRegHistorialActivo.Hcl_codreg_hcca;
                                tmpRegCheckchm.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad;
                                tmpRegCheckchm.Cit_codasi_mcit = gobRegHistorialActivo.Cit_codasi_mcit;
                                tmpRegCheckchm.Fcm_codcpr_cpro = gobRegHistorialActivo.Fcm_codcpr_cpro;
                                tmpRegCheckchm.Sia_idesec_usua = gobRegHistorialActivo.Sia_idesec_usua;
                                tmpRegCheckchm.Hcl_gesfec_hcev = gobRegHistorialActivo.Hcl_gesfec_hcev;
                                tmpRegCheckchm.Hcl_geshor_hcev = gobRegHistorialActivo.Hcl_geshor_hcev;
                                tmpRegCheckchm.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof;
                                #endregion

                                var lcrValorEx = lcrValor.ToUpper() == "TRUE" || lcrValor == "1" ? "1" : "2";
                                RefCheckChm.InvokeMember(lobItem.Binding, BindingFlags.SetField, null, tmpRegCheckchm,
                                                         new Object[] { lcrValorEx }, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion
                    }
                    #endregion
                }
            }
        }
        #endregion
        #region fcvGTablaGetValorDatosDigitados: Cargar en temporal de captura los datos desde tablas historicas
        /// <summary>
        /// <para>Cargar en temporal de captura los datos desde tablas historicas</para>
        /// </summary>
        public void fcvGTablaGetValorDatosDigitados(String tcrArchivoOrigen, String tcrCodigoPlantilla)
        {
            // Variables para Reflexion de datos
            #region Reflexion temporales de datos
            Type RefTextBoxa = tmpRegTextBoxa != null ? tmpRegTextBoxa.GetType() : null;
            Type RefTextBoxb = tmpRegTextBoxb != null ? tmpRegTextBoxb.GetType() : null;
            Type RefTextBoxc = tmpRegTextBoxc != null ? tmpRegTextBoxc.GetType() : null;
            Type RefNumerico = tmpRegNumerico != null ? tmpRegNumerico.GetType() : null;
            Type RefComboBox = tmpRegComboBox != null ? tmpRegComboBox.GetType() : null;
            Type RefComboCbx = tmpRegCombocbx != null ? tmpRegCombocbx.GetType() : null;
            Type RefRecursos = tmpRegRecursos != null ? tmpRegRecursos.GetType() : null;
            Type RefDatFecha = tmpRegDatFecha != null ? tmpRegDatFecha.GetType() : null;
            Type RefRelacion = tmpRegRelacion != null ? tmpRegRelacion.GetType() : null;
            Type RefRdButon1 = tmpRegRdButon1 != null ? tmpRegRdButon1.GetType() : null;
            Type RefRdButon2 = tmpRegRdButon2 != null ? tmpRegRdButon2.GetType() : null;
            Type RefRdButon3 = tmpRegRdButon3 != null ? tmpRegRdButon3.GetType() : null;
            Type RefRdButon4 = tmpRegRdButon4 != null ? tmpRegRdButon4.GetType() : null;
            Type RefRichText = tmpRegRichText != null ? tmpRegRichText.GetType() : null;
            Type RefRichTmen = tmpRegRichTmen != null ? tmpRegRichTmen.GetType() : null;
            Type RefRichTmeo = tmpRegRichTmeo != null ? tmpRegRichTmeo.GetType() : null;
            Type RefCheckBox = tmpRegCheckBox != null ? tmpRegCheckBox.GetType() : null;
            Type RefCheckChl = tmpRegCheckchl != null ? tmpRegCheckchl.GetType() : null;
            Type RefCheckChm = tmpRegCheckchm != null ? tmpRegCheckchm.GetType() : null;
            #endregion

            var lobDatos = new ClassXmlPropDatos();
            var lobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PLANTILLA", tcrCodigoPlantilla);

            foreach (var lobItem in lobTemp)
            {
                if (!String.IsNullOrWhiteSpace(lobItem.Binding))
                {
                    lobDatos = new ClassXmlPropDatos();
                    lobDatos.IgGrupoRegistro = tcrCodigoPlantilla; // Por defecto
                    fcvGestVistaCapturaSetPropiedadRegistro(ref lobDatos, lobItem);
                    // Leer datos
                    #region Reflexion Datos
                    var lcrNombreArchivo = lobItem.BindingTabla.ToUpper();
                    switch (lcrNombreArchivo)
                    {
                        case "HCLREGISEXTXA":
                            #region Gestion Datos
                            if (RefTextBoxa != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegTextBoxa.Grp_idereg_grpl) ? 
                                                                                     lobDatos.IgGrupoRegistro : tmpRegTextBoxa.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefTextBoxa.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegTextBoxa,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXTXB":
                            #region Gestion Datos
                            if (RefTextBoxb != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegTextBoxb.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegTextBoxb.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefTextBoxb.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegTextBoxb,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXTXC":
                            #region Gestion Datos
                            if (RefTextBoxc != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegTextBoxc.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegTextBoxc.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefTextBoxc.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegTextBoxc,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXNUM":
                            #region Gestion Datos
                            if (RefNumerico != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegNumerico.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegNumerico.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefNumerico.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegNumerico,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCBO":
                            #region Gestion Datos
                            if (RefComboBox != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegComboBox.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegComboBox.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefComboBox.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegComboBox,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                                // Guardar la descripcion del dato
                                if (!String.IsNullOrWhiteSpace(lobItem.BindingDescripcion))
                                {
                                    lobDatos.ValorDescripcion = (String)RefComboBox.InvokeMember(lobItem.BindingDescripcion, BindingFlags.GetField, null, tmpRegComboBox,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                                }
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCBX":
                            #region Gestion Datos
                            if (RefComboCbx != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegCombocbx.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegCombocbx.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefComboCbx.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegCombocbx,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                                // Guardar la descripcion del dato
                                if (!String.IsNullOrWhiteSpace(lobItem.BindingDescripcion))
                                {
                                    lobDatos.ValorDescripcion = (String)RefComboCbx.InvokeMember(lobItem.BindingDescripcion, BindingFlags.GetField, null, tmpRegCombocbx,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                                }
                            }
                            break;
                            #endregion

                        case "HCLREGISEXREC":
                            #region Gestion Datos
                            if (RefRecursos != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRecursos.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRecursos.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRecursos.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRecursos,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXFEC":
                            #region Gestion Datos
                            if (RefDatFecha != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegDatFecha.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegDatFecha.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefDatFecha.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegDatFecha,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXREL":
                            #region Gestion Datos
                            if (RefRelacion != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRelacion.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRelacion.Grp_idereg_grpl;
                                // Revisar si TEXTBOXRELCODO
                                var lcrValorDato = (String)RefRelacion.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRelacion,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                                if (lobItem.TipoObjeto == "TEXTBOXRELCOD" && lcrValorDato != null)
                                {
                                    if (!String.IsNullOrWhiteSpace(lcrValorDato))
                                    {
                                        // Revisar cuando hay codigo auxiliar de digitacion
                                        String[] larArray = lcrValorDato.Split("*".ToCharArray());

                                        if (larArray.Length > 1)
                                        {
                                            lobDatos.ValorAux = lcrValorDato;
                                            lcrValorDato = gobRegHistorialActivo.Sis_estpro_espr == "1" ? larArray[0].Trim() : larArray[1].Trim();
                                        }
                                    }
                                }
                                lobDatos.Valor = lcrValorDato;
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBT":
                            #region Gestion Datos
                            if (RefRdButon1 != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRdButon1.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRdButon1.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRdButon1.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRdButon1,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBM":
                            #region Gestion Datos
                            if (RefRdButon2 != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRdButon2.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRdButon2.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRdButon2.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRdButon2,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBN":
                            #region Gestion Datos
                            if (RefRdButon3 != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRdButon3.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRdButon3.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRdButon3.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRdButon3,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXRBO":
                            #region Gestion Datos
                            if (RefRdButon4 != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRdButon4.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRdButon4.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRdButon4.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRdButon4,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEM":
                            #region Gestion Datos
                            if (RefRichText != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRichText.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRichText.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRichText.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRichText,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEN":
                            #region Gestion Datos
                            if (RefRichTmen != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRichTmen.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRichTmen.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRichTmen.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRichTmen,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXMEO":
                            #region Gestion Datos
                            if (RefRichTmeo != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegRichTmeo.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegRichTmeo.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefRichTmeo.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegRichTmeo,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHK":
                            #region Gestion Datos
                            if (RefCheckBox != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegCheckBox.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegCheckBox.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefCheckBox.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegCheckBox,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHL":
                            #region Gestion Datos
                            if (RefCheckChl != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegCheckchl.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegCheckchl.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefCheckChl.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegCheckchl,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion

                        case "HCLREGISEXCHM":
                            #region Gestion Datos
                            if (RefCheckChm != null)
                            {
                                lobDatos.IgGrupoRegistro = String.IsNullOrWhiteSpace(tmpRegCheckchm.Grp_idereg_grpl) ?
                                                                                     lobDatos.IgGrupoRegistro : tmpRegCheckchm.Grp_idereg_grpl;

                                lobDatos.Valor = (String)RefCheckChm.InvokeMember(lobItem.Binding, BindingFlags.GetField, null, tmpRegCheckchm,
                                                                                        null, System.Globalization.CultureInfo.CurrentCulture);
                            }
                            break;
                            #endregion
                    }
                    #endregion
                    // Agregar al temporal 
                    tmpCapturaDatos.Add(lobDatos);
                }
            }
        }
        #endregion
        #region fcvGTablaComplementarDatosDigitados: Para evitar guardar descripciones vacias al confirmar
        /// <summary>
        /// <para>Completar datos para evitar guardar descripciones de campos relacion y Combobox vacias al confirmar en tablas</para>
        /// </summary>
        public void fcvGTablaComplementarDatosDigitados(String tcrEstado)
        {
            if (tcrEstado != "2") { return; }

            foreach (var lobItem in tmpCapturaDatos)
            {
                switch (lobItem.TipoObjeto)
                {
                    case "COMBOBOX":
                        #region Generar registro detalle
                        // Buscar el valor descripcion
                        var lobRegCombo = fobRegSelectParenComboBoxItems(lobItem.Name, lobItem.Valor);
                        if (lobRegCombo != null && lobRegCombo.Count != 0)
                        {
                            lobItem.ValorDescripcion = lobRegCombo.FirstOrDefault().Descripcion.Trim();
                        }
                        break;
                        #endregion

                    case "TEXTBOXRELDES":
                        #region Generar registro detalle
                        // Buscar valor descripcion en objeto vista
                        if (String.IsNullOrWhiteSpace(lobItem.Valor))
                        {
                            var lobObjDes = fobRegSelectParenObjeto("OBJETOS", "", lobItem.Name).FirstOrDefault();
                            if (lobObjDes != null)
                            {
                                var lobTextBox = lobObjDes.RefObjeto as TextBox;
                                lobItem.Valor = lobTextBox != null ? lobTextBox.Text : lobItem.Valor;

                                var lobObjCod = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELCOD", lobItem.Parent).FirstOrDefault();
                                if (lobObjCod != null)
                                {
                                    var lobCod = tmpCapturaDatos.FirstOrDefault(x => x.Name == lobObjCod.Name);
                                    if (lobCod != null)
                                    {
                                        lobCod.ValorDescripcion = lobItem.Valor;
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "TEXTBOXRELCOD":
                        #region Generar registro detalle
                        // Buscar el valor descripcion en objeto vista
                        if (String.IsNullOrWhiteSpace(lobItem.ValorDescripcion))
                        {
                            var lobObjDes1 = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobItem.Parent).FirstOrDefault();
                            if (lobObjDes1 != null)
                            {
                                var lobTextBox = lobObjDes1.RefObjeto as TextBox;
                                var lobDes = tmpCapturaDatos.FirstOrDefault(x => x.Name == lobObjDes1.Name);
                                if (lobDes != null)
                                {
                                    lobDes.Valor = lobTextBox != null ? lobTextBox.Text : lobItem.ValorDescripcion;
                                    lobItem.ValorDescripcion = lobDes.Valor;
                                }
                            }
                        }
                        break;
                        #endregion
                }
            }
        }
        #endregion
        #region fcvGTablaGuardarHistDatosDigitados: Guardar en archivos historicos los datos digitados
        /// <summary>
        /// <para>Guardar en archivos historicos los datos digitados</para>
        /// <para>tcrGrupoArchivos: "01" "02" "03"...</para>
        /// </summary>
        public void fcvGTablaGuardarHistDatosDigitados(String tcrGrupoArchivos)
        {
            var lcrLlave = gobRegHistorialActivo.Hcl_nroreg_hcev;

            foreach (var lobReg in tmpArchvioHist)
            {
                #region Gestion
                switch (lobReg.NombreArchivo)
                {
                    case "HCLREGISEXTXA":
                        ModeloHclregisextxa.fcvActualizar(tmpRegTextBoxa, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXTXB":
                        ModeloHclregisextxb.fcvActualizar(tmpRegTextBoxb, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXTXC":
                        ModeloHclregisextxc.fcvActualizar(tmpRegTextBoxc, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXNUM":
                        ModeloHclregisexnum.fcvActualizar(tmpRegNumerico, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXCBO":
                        ModeloHclregisexcbo.fcvActualizar(tmpRegComboBox, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXCBX":
                        ModeloHclregisexcbx.fcvActualizar(tmpRegCombocbx, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXREC":
                        ModeloHclregisexrec.fcvActualizar(tmpRegRecursos, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXFEC":
                        ModeloHclregisexfec.fcvActualizar(tmpRegDatFecha, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXREL":
                        ModeloHclregisexrel.fcvActualizar(tmpRegRelacion, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXRBT":
                        ModeloHclregisexrbt.fcvActualizar(tmpRegRdButon1, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXRBM":
                        ModeloHclregisexrbm.fcvActualizar(tmpRegRdButon2, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXRBN":
                        ModeloHclregisexrbn.fcvActualizar(tmpRegRdButon3, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXRBO":
                        ModeloHclregisexrbo.fcvActualizar(tmpRegRdButon4, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXMEM":
                        ModeloHclregisexmem.fcvActualizar(tmpRegRichText, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXMEN":
                        ModeloHclregisexmen.fcvActualizar(tmpRegRichTmen, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXMEO":
                        ModeloHclregisexmeo.fcvActualizar(tmpRegRichTmeo, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXCHK":
                        ModeloHclregisexchk.fcvActualizar(tmpRegCheckBox, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXCHL":
                        ModeloHclregisexchl.fcvActualizar(tmpRegCheckchl, tcrGrupoArchivos);
                        break;

                    case "HCLREGISEXCHM":
                        ModeloHclregisexchm.fcvActualizar(tmpRegCheckchm, tcrGrupoArchivos);
                        break;
                }
                #endregion
            }
        }
        #endregion
        #region fcvGTablaEliminarHistDatosDigitados: Eliminar en archivos historicos los datos digitados
        /// <summary>
        /// <para>Eliminar en archivos historicos los datos digitados</para>
        /// <para>tcrGrupoArchivos: "01" "02" "03"...</para>
        /// </summary>
        public void fcvGTablaEliminarHistDatosDigitados(String tcrGrupoArchivos)
        {
            var lcrLlave = gobRegHistorialActivo.Hcl_nroreg_hcev;

            foreach (var lobReg in tmpArchvioHist)
            {
                #region Gestion
                switch (lobReg.NombreArchivo)
                {
                    case "HCLREGISEXTXA":
                        if (tmpRegTextBoxa != null)
                        {
                            ModeloHclregisextxa.fcvEliminar(tmpRegTextBoxa.Hcl_nroreg_hctx, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXTXB":
                        if (tmpRegTextBoxb != null)
                        {
                            ModeloHclregisextxb.fcvEliminar(tmpRegTextBoxb.Hcl_nroreg_hcta, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXTXC":
                        if (tmpRegTextBoxc != null)
                        {
                            ModeloHclregisextxc.fcvEliminar(tmpRegTextBoxc.Hcl_nroreg_hctc, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXNUM":
                        if (tmpRegTextBoxa != null)
                        {
                        ModeloHclregisexnum.fcvEliminar(tmpRegNumerico.Hcl_nroreg_hcnu, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXCBO":
                        if (tmpRegComboBox != null)
                        {
                            ModeloHclregisexcbo.fcvEliminar(tmpRegComboBox.Hcl_nroreg_hccb, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXCBX":
                        if (tmpRegCombocbx != null)
                        {
                            ModeloHclregisexcbx.fcvEliminar(tmpRegCombocbx.Hcl_nroreg_hcbx, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXREC":
                        if (tmpRegRecursos != null)
                        {
                            ModeloHclregisexrec.fcvEliminar(tmpRegRecursos.Hcl_nroreg_hcrc, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXFEC":
                        if (tmpRegDatFecha != null)
                        {
                            ModeloHclregisexfec.fcvEliminar(tmpRegDatFecha.Hcl_nroreg_hcfc, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXREL":
                        if (tmpRegRelacion != null)
                        {
                            ModeloHclregisexrel.fcvEliminar(tmpRegRelacion.Hcl_nroreg_hcre, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXRBT":
                        if (tmpRegRdButon1 != null)
                        {
                        ModeloHclregisexrbt.fcvEliminar(tmpRegRdButon1.Hcl_nroreg_hcrb, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXRBM":
                        if (tmpRegRdButon2 != null)
                        {
                            ModeloHclregisexrbm.fcvEliminar(tmpRegRdButon2.Hcl_nroreg_hcbm, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXRBN":
                        if (tmpRegRdButon3 != null)
                        {
                            ModeloHclregisexrbn.fcvEliminar(tmpRegRdButon3.Hcl_nroreg_hcbn, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXRBO":
                        if (tmpRegRdButon4 != null)
                        {
                            ModeloHclregisexrbo.fcvEliminar(tmpRegRdButon4.Hcl_nroreg_hcbo, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXMEM":
                        if (tmpRegRichText != null)
                        {
                            ModeloHclregisexmem.fcvEliminar(tmpRegRichText.Hcl_nroreg_hcme, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXMEN":
                        if (tmpRegRichTmen != null)
                        {
                            ModeloHclregisexmem.fcvEliminar(tmpRegRichTmen.Hcl_nroreg_hcmn, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXMEO":
                        if (tmpRegRichTmeo != null)
                        {
                            ModeloHclregisexmeo.fcvEliminar(tmpRegRichTmeo.Hcl_nroreg_hcmo, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXCHK":
                        if (tmpRegCheckBox != null)
                        {
                            ModeloHclregisexchk.fcvEliminar(tmpRegCheckBox.Hcl_nroreg_hchk, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXCHL":
                        if (tmpRegCheckchl != null)
                        {
                            ModeloHclregisexchl.fcvEliminar(tmpRegCheckchl.Hcl_nroreg_hchl, tcrGrupoArchivos);
                        }
                        break;

                    case "HCLREGISEXCHM":
                        if (tmpRegCheckchm != null)
                        {
                            ModeloHclregisexchm.fcvEliminar(tmpRegCheckchm.Hcl_nroreg_hchm, tcrGrupoArchivos);
                        }
                        break;
                }
                #endregion
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

            tmpCapturaDatos             = new List<ClassXmlPropDatos>();
            tmpCapturaEtiqueta          = new List<ClassXmlPropDatos>();
            tmpLogErrores               = new List<LogsErrores>();
            gobRegPropPlantillaDatos    = null;
            gobRegPlantMaestro          = null;
            gobRegPlantVersion          = null;
            gcrImportArchivoPlantilla   = String.Empty;
            gcrImportArchivoDatos       = String.Empty;
            gcrImportArchivoRuta        = String.Empty;
            gcrIdRegHistorialEventoActivo = String.Empty;
            glgHistorialAddNuevoRegistro = false;
            gnuContErroresIsRequerido   = 0;
            gobRegHistorial             = null;
            gobRegHistorialActivo       = null;

            // Temporales del guardado en tablas
            tmpRegTextBoxa = null;
            tmpRegTextBoxb = null;
            tmpRegTextBoxc = null;
            tmpRegNumerico = null;
            tmpRegComboBox = null;
            tmpRegRecursos = null;
            tmpRegDatFecha = null;
            tmpRegRelacion = null;
            tmpRegRdButon1 = null;
            tmpRegRdButon2 = null;
            tmpRegRdButon3 = null;
            tmpRegRdButon4 = null;
            tmpRegRichText = null;
            tmpRegCheckBox = null;
            tmpRegCheckchl = null;
            tmpRegCheckchm = null;
            tmpArchvioHist = null; // Lista de archivos activos para gestion
            tmpArchvioHist = new List<ClassTempArchivoHistorico>();
        }
        #endregion
        //---------------------------------------------------------------
        // ACTUALIZAR ARCHIVOS MAESTROS, VARIABLES 
        //---------------------------------------------------------------
        // Actualizar datos RIPS
        #region flgActualizarRegActivoRipsAC: Registro Rips de consulta
        /// <summary>
        /// <para>Actualizar campos RIPS de consultas</para>
        /// </summary>
        public bool flgActualizarRegActivoRipsAC(ref FcmModeloServDetallFacturas tobRegRips, String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Registro Rips AC
            if (tmpDetallesServFac != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                //MessageBox.Show("RIPS AC CAMPO : " + tcrNombreCampo + " valor " + tcrValor);

                switch (tcrNombreCampo)
                {
                    case "RIPSAC_FECHACONS":
                        llgReturn = true;
                        //tobRegRips.Fcm_fecser_dfac = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        //tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_AUTORIZACION":
                        llgReturn = true;
                        //tobRegRips.Adm_nroaut_rgad = tcrValor;
                        //tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_FINALIDADCON":

                        llgReturn = true;
                        //tobRegRips.Sia_codfco_fcon  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_codfco_fcon;
                        tobRegRips.Sia_codfco_fcon    = tcrValor;
                        tobRegRips.Sia_codfco_fcon    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_codfco_fcon) ? tobRegRips.Sia_codfco_fcon : tcrValor;
                        gobRegRipsAmb.Sia_codfco_fcon = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_codfco_fcon) ? tcrValor : gobRegRipsAmb.Sia_codfco_fcon;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_CAUSAEXTERNA":
                        llgReturn = true;
                        //tobRegRips.Adm_codcex_tcex  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Adm_codcex_tcex;
                        tobRegRips.Adm_codcex_tcex    = tcrValor;
                        tobRegRips.Adm_codcex_tcex    = !String.IsNullOrWhiteSpace(tobRegRips.Adm_codcex_tcex) ? tobRegRips.Adm_codcex_tcex : tcrValor;
                        gobRegRipsAmb.Adm_codcex_tcex = String.IsNullOrWhiteSpace(gobRegRipsAmb.Adm_codcex_tcex) ? tcrValor : gobRegRipsAmb.Adm_codcex_tcex;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_DIAGPRINCIPAL":
                        llgReturn = true;
                        //tobRegRips.Sia_coddia_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddia_tdia;
                        tobRegRips.Sia_coddia_tdia    = tcrValor;
                        tobRegRips.Sia_coddia_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? tobRegRips.Sia_coddia_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddia_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddia_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddia_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_TIPODIAGPRIN":
                        llgReturn = true;
                        //tobRegRips.Sia_tipdxp_tdix  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_tipdxp_tdix;
                        tobRegRips.Sia_tipdxp_tdix    = tcrValor;
                        tobRegRips.Sia_tipdxp_tdix    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_tipdxp_tdix) ? tobRegRips.Sia_tipdxp_tdix : tcrValor;
                        gobRegRipsAmb.Sia_tipdxp_tdix = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_tipdxp_tdix) ? tcrValor : gobRegRipsAmb.Sia_tipdxp_tdix;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_DIAGRELACION1":
                        llgReturn = true;
                        //tobRegRips.Sia_coddx1_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddx1_tdia;
                        tobRegRips.Sia_coddx1_tdia    = tcrValor;
                        tobRegRips.Sia_coddx1_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia) ? tobRegRips.Sia_coddx1_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddx1_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx1_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddx1_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_DIAGRELACION2":
                        llgReturn = true;
                        //tobRegRips.Sia_coddx2_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddx2_tdia;
                        tobRegRips.Sia_coddx2_tdia    = tcrValor;
                        tobRegRips.Sia_coddx2_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx2_tdia) ? tobRegRips.Sia_coddx2_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddx2_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx2_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddx2_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAC_DIAGRELACION3":
                        llgReturn = true;
                        //tobRegRips.Sia_coddx3_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddx3_tdia;
                        tobRegRips.Sia_coddx3_tdia    = tcrValor;
                        tobRegRips.Sia_coddx3_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx3_tdia) ? tobRegRips.Sia_coddx3_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddx3_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx3_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddx3_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarRegActivoRipsAP: Registro Rips de procedimientos
        /// <summary>
        /// <para>Actualizar campos RIPS de procedimientos</para>
        /// </summary>
        public bool flgActualizarRegActivoRipsAP(ref FcmModeloServDetallFacturas tobRegRips, String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Registro Rips AC
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNombreCampo)
                {
                    case "RIPSAP_FECHAPROCED":
                        llgReturn = true;
                        //tobRegRips.Fcm_fecser_dfac = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        //tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_AUTORIZACION":
                        llgReturn = true;
                        //tobRegRips.Adm_nroaut_rgad = tcrValor;
                        //tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_AMBITOPROC":
                        llgReturn = true;
                        tobRegRips.Adm_codtat_tatn = !String.IsNullOrWhiteSpace(tobRegRips.Adm_codtat_tatn) ? tobRegRips.Adm_codtat_tatn : tcrValor;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_FINALIDADPROC":
                        llgReturn = true;
                        //tobRegRips.Sia_codfpr_fpor = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_codfpr_fpor;
                        tobRegRips.Sia_codfpr_fpor = tcrValor;
                        tobRegRips.Sia_codfpr_fpor = !String.IsNullOrWhiteSpace(tobRegRips.Sia_codfpr_fpor) ? tobRegRips.Sia_codfpr_fpor : tcrValor;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_PERSOATIENDE":
                        llgReturn = true;
                        //tobRegRips.Sia_codpat_tpat = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_codpat_tpat;
                        tobRegRips.Sia_codpat_tpat = tcrValor;
                        tobRegRips.Sia_codpat_tpat = !String.IsNullOrWhiteSpace(tobRegRips.Sia_codpat_tpat) ? tobRegRips.Sia_codpat_tpat : tcrValor;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_DIAGPRINCIPAL":
                        llgReturn = true;
                        //tobRegRips.Sia_coddia_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddia_tdia;
                        tobRegRips.Sia_coddia_tdia    = tcrValor;
                        tobRegRips.Sia_coddia_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? tobRegRips.Sia_coddia_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddia_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddia_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddia_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_DIAGRELACION":
                        llgReturn = true;
                        //tobRegRips.Sia_coddx1_tdia  = tobRegRips.Sia_tipact_tsac == "1" ? tcrValor : tobRegRips.Sia_coddx1_tdia;
                        tobRegRips.Sia_coddx1_tdia    = tcrValor;
                        tobRegRips.Sia_coddx1_tdia    = !String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia) ? tobRegRips.Sia_coddx1_tdia : tcrValor;
                        gobRegRipsAmb.Sia_coddx1_tdia = String.IsNullOrWhiteSpace(gobRegRipsAmb.Sia_coddx1_tdia) ? tcrValor : gobRegRipsAmb.Sia_coddx1_tdia;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_DIAGCOMPLICA":
                        llgReturn = true;
                        tobRegRips.Sia_coddxc_tdia = tcrValor;
                        tobRegRips.Modificado = "M";
                        break;

                    case "RIPSAP_FORMACTQUIR":
                        llgReturn = true;
                        tobRegRips.Fcm_codaqx_aqir = tcrValor;
                        tobRegRips.Modificado = "M";
                        break;

                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        // Resolucion 4505 Rangos 0-29,30-59,60-89,90-118
        #region flgActualizarRegActivoMS4505_R029: Registro Resolucion 4505 Rango 0 a 29
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 0 a 29</para>
        /// </summary>
        public bool flgActualizarRegActivoMS4505_R029(String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Campos desde 0 a 29
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNombreCampo)
                {
                    case "SIA_IDESEC_USUA":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_idesec_usua = tcrValor;
                        break;

                    case "SIA_NROIDE_USUA":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_nroide_usua = tcrValor;
                        break;

                    case "SIA_CODEPS_TEPS":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_codeps_teps = tcrValor;
                        break;

                    case "SSP_CAM000_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam000_ms45 = tcrValor;
                        break;

                    case "SSP_CAM001_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam001_ms45 = tcrValor;
                        break;

                    case "SSP_CAM002_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam002_ms45 = tcrValor;
                        break;

                    case "SSP_CAM003_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam003_ms45 = tcrValor;
                        break;

                    case "SSP_CAM004_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam004_ms45 = tcrValor;
                        break;

                    case "SSP_CAM005_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam005_ms45 = tcrValor;
                        break;

                    case "SSP_CAM006_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam006_ms45 = tcrValor;
                        break;

                    case "SSP_CAM007_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam007_ms45 = tcrValor;
                        break;

                    case "SSP_CAM008_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam008_ms45 = tcrValor;
                        break;

                    case "SSP_CAM009_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam009_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM010_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam010_ms45 = tcrValor;
                        break;

                    case "SSP_CAM011_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam011_ms45 = tcrValor;
                        break;

                    case "SSP_CAM012_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_codocu_ciuo = tcrValor;
                        break;

                    case "SSP_CAM013_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam013_ms45 = tcrValor;
                        break;

                    case "SSP_CAM014_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam014_ms45 = tcrValor;
                        break;

                    case "SSP_CAM015_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam015_ms45 = tcrValor;
                        break;

                    case "SSP_CAM016_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam016_ms45 = tcrValor;
                        break;

                    case "SSP_CAM017_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam017_ms45 = tcrValor;
                        break;

                    case "SSP_CAM018_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam018_ms45 = tcrValor;
                        break;

                    case "SSP_CAM019_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam019_ms45 = tcrValor;
                        break;

                    case "SSP_CAM020_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam020_ms45 = tcrValor;
                        break;

                    case "SSP_CAM021_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam021_ms45 = tcrValor;
                        break;

                    case "SSP_CAM022_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam022_ms45 = tcrValor;
                        break;

                    case "SSP_CAM023_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam023_ms45 = tcrValor;
                        break;

                    case "SSP_CAM024_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam024_ms45 = tcrValor;
                        break;

                    case "SSP_CAM025_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam025_ms45 = tcrValor;
                        break;

                    case "SSP_CAM026_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam026_ms45 = tcrValor;
                        break;

                    case "SSP_CAM027_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam027_ms45 = tcrValor;
                        break;

                    case "SSP_CAM028_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam028_ms45 = tcrValor;
                        break;

                    case "SSP_CAM029_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam029_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarRegActivoMS4505_R3059: Registro Resolucion 4505 Rango 30 a 59
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 30 a 59</para>
        /// </summary>
        public bool flgActualizarRegActivoMS4505_R3059(String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Campos desde 0 a 29
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNombreCampo)
                {
                    case "SSP_CAM030_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam030_ms45 = (float)Convert.ToDecimal(Funciones.fcrRemplazarChrDecimal(tcrValor, gcrSysSeparadorDecimal));
                        break;

                    case "SSP_CAM031_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam031_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM032_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam032_ms45 = (int)Convert.ToDecimal(Funciones.fcrRemplazarChrDecimal(tcrValor, gcrSysSeparadorDecimal));
                        break;

                    case "SSP_CAM033_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam033_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM034_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam034_ms45 = Convert.ToInt32(tcrValor);
                        break;

                    case "SSP_CAM035_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam035_ms45 = tcrValor;
                        break;

                    case "SSP_CAM036_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam036_ms45 = tcrValor;
                        break;

                    case "SSP_CAM037_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam037_ms45 = tcrValor;
                        break;

                    case "SSP_CAM038_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam038_ms45 = tcrValor;
                        break;

                    case "SSP_CAM039_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam039_ms45 = tcrValor;
                        break;

                    case "SSP_CAM040_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam040_ms45 = tcrValor;
                        break;

                    case "SSP_CAM041_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam041_ms45 = tcrValor;
                        break;

                    case "SSP_CAM042_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam042_ms45 = tcrValor;
                        break;

                    case "SSP_CAM043_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam043_ms45 = tcrValor;
                        break;

                    case "SSP_CAM044_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam044_ms45 = tcrValor;
                        break;

                    case "SSP_CAM045_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam045_ms45 = tcrValor;
                        break;

                    case "SSP_CAM046_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam046_ms45 = tcrValor;
                        break;

                    case "SSP_CAM047_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam047_ms45 = tcrValor;
                        break;

                    case "SSP_CAM048_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam048_ms45 = tcrValor;
                        break;

                    case "SSP_CAM049_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam049_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM050_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam050_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM051_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam051_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM052_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam052_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM053_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam053_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM054_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam054_ms45 = tcrValor;
                        break;

                    case "SSP_CAM055_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam055_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;
                    case "SSP_CAM056_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam056_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM057_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam057_ms45 = Convert.ToInt32(tcrValor);
                        break;

                    case "SSP_CAM058_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam058_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM059_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam059_ms45 = tcrValor;
                        break;

                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarRegActivoMS4505_R6089: Registro Resolucion 4505 Rango 60 a 89
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 60 a 89</para>
        /// </summary>
        public bool flgActualizarRegActivoMS4505_R6089(String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Campos desde 60 a 89
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNombreCampo)
                {
                    case "SSP_CAM060_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam060_ms45 = tcrValor;
                        break;

                    case "SSP_CAM061_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam061_ms45 = tcrValor;
                        break;

                    case "SSP_CAM062_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam062_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM063_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam063_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM064_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam064_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM065_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam065_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM066_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam066_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM067_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam067_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM068_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam068_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM069_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam069_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM070_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam070_ms45 = tcrValor;
                        break;

                    case "SSP_CAM071_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam071_ms45 = tcrValor;
                        break;

                    case "SSP_CAM072_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam072_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM073_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam073_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM074_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam074_ms45 = Convert.ToInt32(tcrValor);
                        break;

                    case "SSP_CAM075_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam075_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM076_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam076_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM077_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam077_ms45 = tcrValor;
                        break;

                    case "SSP_CAM078_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam078_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM079_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam079_ms45 = tcrValor;
                        break;

                    case "SSP_CAM080_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam080_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM081_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam081_ms45 = tcrValor;
                        break;

                    case "SSP_CAM082_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam082_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM083_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam083_ms45 = tcrValor;
                        break;

                    case "SSP_CAM084_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam084_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM085_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam085_ms45 = tcrValor;
                        break;
                    case "SSP_CAM086_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam086_ms45 = tcrValor;
                        break;

                    case "SSP_CAM087_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam087_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM088_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam088_ms45 = tcrValor;
                        break;

                    case "SSP_CAM089_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam089_ms45 = tcrValor;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarRegActivoMS4505_R90118: Registro Resolucion 4505 Rango 90 a 118
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 90 a 118</para>
        /// </summary>
        public bool flgActualizarRegActivoMS4505_R90118(String tcrNombreCampo, String tcrValor)
        {
            var llgReturn = false;
            #region Campos desde 90 a 118
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNombreCampo)
                {
                    case "SSP_CAM090_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam090_ms45 = tcrValor;
                        break;

                    case "SSP_CAM091_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam091_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM092_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam092_ms45 = tcrValor;
                        break;

                    case "SSP_CAM093_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam093_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM094_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam094_ms45 = tcrValor;
                        break;

                    case "SSP_CAM095_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam095_ms45 = tcrValor;
                        break;

                    case "SSP_CAM096_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam096_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM097_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam097_ms45 = tcrValor;
                        break;

                    case "SSP_CAM098_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam098_ms45 = tcrValor;
                        break;

                    case "SSP_CAM099_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam099_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM100_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam100_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM101_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam101_ms45 = tcrValor;
                        break;

                    case "SSP_CAM102_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam102_ms45 = tcrValor;
                        break;

                    case "SSP_CAM103_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam103_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM104_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam104_ms45 = (float)Convert.ToDecimal(Funciones.fcrRemplazarChrDecimal(tcrValor, gcrSysSeparadorDecimal));
                        break;

                    case "SSP_CAM105_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam105_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM106_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam106_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM107_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam107_ms45 = (float)Convert.ToDecimal(Funciones.fcrRemplazarChrDecimal(tcrValor, gcrSysSeparadorDecimal));
                        break;

                    case "SSP_CAM108_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam108_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM109_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam109_ms45 = (float)Convert.ToDecimal(Funciones.fcrRemplazarChrDecimal(tcrValor, gcrSysSeparadorDecimal));
                        break;

                    case "SSP_CAM110_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam110_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM111_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam111_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM112_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam112_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;

                    case "SSP_CAM113_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam113_ms45 = tcrValor;
                        break;

                    case "SSP_CAM114_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam114_ms45 = tcrValor;
                        break;

                    case "SSP_CAM115_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam115_ms45 = tcrValor;
                        break;
                    case "SSP_CAM116_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam116_ms45 = tcrValor;
                        break;

                    case "SSP_CAM117_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam117_ms45 = tcrValor;
                        break;

                    case "SSP_CAM118_MS45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam118_ms45 = Funciones.fdaConvertFecha("DMY", "/", tcrValor);
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        //---------------------------------------------------------------
        //- ASCTUALIZAR MAESTRO VARIABLES PUBLICAS
        //---------------------------------------------------------------
        #region fcvActualizarVariablesPublicasMaestro: Actualizar maestro variables publicas y usuarios atendidos
        /// <summary>
        /// <para>Actualizar maestro variables publicas y maestro usuarios atendidos</para>
        /// </summary>
        public void fcvActualizarVariablesPublicasMaestro()
        {
            var lnuDatEdtUsuarios   = 0;
            var lcrCodigoAdmision   = gobRegHistorialActivo.Adm_secadm_rgad;
            var lcrIdUnicoUsuario   = gobRegHistorialActivo.Sia_idesec_usua;
            var lcrTipoIde          = gobRegHistorialActivo.Sia_tipide_tide;
            var lcrNumeroIdUsuario  = gobRegHistorialActivo.Sia_nroide_usua;
            var lnuContadorIdeReg   = ADMModeloAdmadmisiones.fnuGenerarIdItems(lcrCodigoAdmision);
            var llgActualizoDatos   = false;

            tmpVarPublicResumen = new List<ClassXmlPropVariablePublica>();
            tmpGrupoVarPublicas = new List<ClassTempResumenVarPublicas>();

            // Generar valores desde todas las variables tambien variables tipo pila
            #region Generar valores desde todas las variables
            foreach (var lobItem in tmpCapturaDatos)
            {
                // hcl_camdig_hcvr = campo digitable
                var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", lobItem.Name).FirstOrDefault();
                if (lobObjeto != null)
                {
                    if (lobObjeto.PropVarPublica != null)
                    {
                        var ob = lobObjeto.PropVarPublica;
                        // Actualizar cuando el campo es digitable y no esta protegido
                        if (ob.Hcl_camdig_hcvr == "1" && lobObjeto.IsReadOnly != "True" && ob.Hcl_modoca_hcvr == "1")
                        {
                            ob.Hcl_SiGenValorHistTexto = "1";
                            ob.EstadoEdicion = "2";
                            // Cuando es una variable tipo pila
                            if (lobObjeto.VarGestPosVector != "N" && !String.IsNullOrWhiteSpace(lobObjeto.VarGestPosVector))
                            {
                                flgActualizarPilaVariablesPublicas(lobItem.Valor, lobObjeto.VarGestPosVector, ref ob);
                            }
                            else
                            {
                                ob.Hcl_ValorHistTexto = lobItem.Valor;
                            }
                            // no permitir valores vacios
                            if (!String.IsNullOrWhiteSpace(ob.Hcl_ValorHistTexto))
                            {
                                fcvGuardarValoresParaVariablesResumen(ob, lobObjeto, ob.Hcl_ValorHistTexto);
                            }
                        }
                    }
                }
            }
            #endregion
            // Gaurdar los valores desde las variables publicas
            #region Guardar los valores
            foreach (var lobItem in tmpVarPublicGeneral)
            {
                var ob = lobItem;

                // Actualizar cuando el dato es digitable y esta modificado
                if (ob.EstadoEdicion == "2" && ob.Hcl_modoca_hcvr == "1")
                {
                    llgActualizoDatos = true;

                    if (ob.Pila != null)
                    {
                        ob.Hcl_ValorHistTexto = SetValoresPilaToStringTexto(ob.Pila);
                    }

                    lnuContadorIdeReg++;
                    ModeloHclvariabactual.fcvActualizarVariablePublica("2", lcrCodigoAdmision, lcrIdUnicoUsuario, lcrTipoIde,
                                                                        lcrNumeroIdUsuario, ob.Hcl_nomvar_hcvr,
                                                                        ob.Hcl_ValorHistTexto, lnuContadorIdeReg, gcrSysSeparadorDecimal);
                }
                if (flgActualizarVariablesPublicasUsuario(ob, ob.Hcl_ValorHistTexto)) { lnuDatEdtUsuarios++; }
            }
            #endregion
            // si se actualizo variables publicas 
            if (llgActualizoDatos == true)
            {
                ADMModeloAdmadmisiones.fcvActualizGenIdItems(lcrCodigoAdmision, lnuContadorIdeReg);
            }
            // Guardar valores variables resumen
            fcvGenerarVariablesResumen();

            // Actualizar maestro de usuarios atendidos
            if (lnuDatEdtUsuarios > 0)
            { 
                SIAModeloUsuariosAtendidos.fcvActualizar(tmpUsuarioAtendido);
            }
        }
        #endregion
        #region flgActualizarPilaVariablesPublicas: Actualiza valores en Pila de variables publicas
        /// <summary>
        /// <para>Actualiza valores en la Pila de una variables publicas tipo vector o Pila</para>
        /// <para>buscar una posicion sin datos para agregar el nuevo valor o actualizar en una posicion definida por: tcrVarGestPosVector</para>
        /// </summary>
        public bool flgActualizarPilaVariablesPublicas(String tcrValor, String tcrVarGestPosVector, ref ClassXmlPropVariablePublica tobVariable)
        {
            var llgReturn = true;
            var Pila = tobVariable.Pila;
            var lnuPos = 0;

            if (tcrVarGestPosVector == "0")
            {
                MessageBox.Show(tobVariable.Hcl_nomvar_hcvr);

                foreach (var lobReg in Pila)
                {
                    // Buscar posicion que este libre
                    if (lobReg.Dato == "-N-")
                    {
                        lobReg.Dato     = tcrValor;
                        lobReg.Estado   = "2";
                        lobReg.Posicion = lnuPos;
                        break;
                    }
                    lnuPos++;
                }
            }
            else
            {
                lnuPos = Convert.ToInt32(tcrVarGestPosVector);

                Pila[lnuPos].Dato   = tcrValor;
                Pila[lnuPos].Estado = "2";
            }

            // Cuando es el primer varlor de la pila, guardar la fecha inicio gestion
            if (Pila[0].Dato == "-D-")
            {
                Pila[0].Dato        = Funciones.fcrFechaActual();
                Pila[0].Estado      = "2";
                Pila[0].Posicion    = 0;
            }

            return llgReturn;
        }
        #endregion
        #region SetValoresPilaToStringTexto: Generar String texto desde regitros pila
        /// <summary>
        /// <para>Generar String texto desde registros pila</para>
        /// </summary>
        public String SetValoresPilaToStringTexto(List<ClassXmlPilaVariablePublica> tobPila)
        {
            var Pila = tobPila;
            String lcrTexto = String.Empty;

            foreach (var lobReg in Pila)
            {
                lcrTexto += String.IsNullOrWhiteSpace(lcrTexto) ? lobReg.Dato : "*" + lobReg.Dato;
            }
            return lcrTexto;
        }
        #endregion
        //---------------------------
        #region fcvActualizarVariablesPublicasUsuario: Actualizar Variables en campos maestro usuarios
        /// <summary>
        /// <para>fcvActualizarVariablesPublicasUsuario()</para>
        /// <para>Actualizar Variables en campos maestro usuarios</para>
        /// </summary>
        public bool flgActualizarVariablesPublicasUsuario(ClassXmlPropVariablePublica tobObjeto, String tcrValor)
        {
            var llgReturn = false;
            try
            {
                if (tobObjeto != null)
                {
                    // Actualizar cuando el campo es digitable y no esta protegido
                    if (tobObjeto.Hcl_camdig_hcvr == "1" && tobObjeto.Hcl_SiGenValorHistTexto == "1")
                    {
                        #region VARIABLES DATOS BASICOS USUARIO
                        switch (tobObjeto.Hcl_nomvar_hcvr)
                        {
                            case "USUARIO_TIPO_IDENTIFICACION":
                                tmpUsuarioAtendido.Sia_tipide_tide = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_NUMERO_IDENTIFICACION":
                                tmpUsuarioAtendido.Sia_nroide_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_PRIMER_APELLIDO":
                                tmpUsuarioAtendido.Sia_priape_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_SEGUNDO_APELLIDO":
                                tmpUsuarioAtendido.Sia_segape_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_PRIMER_NOMBRE":
                                tmpUsuarioAtendido.Sia_prinom_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_SEGUNDO_NOMBRE":
                                tmpUsuarioAtendido.Sia_segnom_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_NOMBRE_COMPLETO":
                                tmpUsuarioAtendido.Sia_nomusu_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_FECHA_NACIMIENTO":
                                tmpUsuarioAtendido.Sia_fecnac_usua = Convert.ToDateTime(tcrValor);
                                llgReturn = true;
                                break;

                            case "USUARIO_SEXO_CODIGO":
                                tmpUsuarioAtendido.Sis_codsex_sexo = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_SEXO_DESCRIPCION":
                                tmpUsuarioAtendido.Sis_dessex_sexo = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_EDAD_FORMATO_LARGO":
                                tmpUsuarioAtendido.Sia_edaymd_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_EDAD_EN_AÑOS":
                                tmpUsuarioAtendido.Sia_edaano_usua = Convert.ToInt32(tcrValor);
                                llgReturn = true;
                                break;

                            case "USUARIO_EDAD_EN_MESES":
                                tmpUsuarioAtendido.Sia_edames_usua = Convert.ToInt32(tcrValor);
                                llgReturn = true;
                                break;

                            case "USUARIO_EDAD_EN_DIAS":
                                tmpUsuarioAtendido.Sia_edadia_usua = Convert.ToInt32(tcrValor);
                                llgReturn = true;
                                break;

                            case "USUARIO_REGIMEN_SALUD_CODIGO":
                                tmpUsuarioAtendido.Sia_tipusu_regi = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_REGIMEN_SALUD_NOMBRE":
                                tmpUsuarioAtendido.Sia_destip_regi = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_ZONA_RESIDENCIA_CODIGO":
                                tmpUsuarioAtendido.Sis_zonres_tzon = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_ZONA_RESIDENCIA_NOMBRE":
                                tmpUsuarioAtendido.Sis_deszon_tzon = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_NUMERO_TELEFONO":
                                tmpUsuarioAtendido.Sia_telres_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_DIRECCION_RESIDENCIA":
                                tmpUsuarioAtendido.Sia_dirres_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_CORREO_ELECTRONICO":
                                tmpUsuarioAtendido.Sia_correo_usua = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_OCUPACION_CODIGO":
                                tmpUsuarioAtendido.Sis_codocu_ocup = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_DISCAPACIDAD_CODIGO":
                                tmpUsuarioAtendido.Sia_tipdis_tdis = tcrValor;
                                llgReturn = true;
                                break;

                            case "USUARIO_DISCAPACIDAD_NOMBRE":
                                tmpUsuarioAtendido.Sia_desdis_tdis = tcrValor;
                                llgReturn = true;
                                break;

                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: flgActualizarVariablesPublicasUsuario");
            }
            return llgReturn;
        }
        #endregion
        #region fcvGuardarValoresParaVariablesResumen: guardar variables publicas con valores modificados
        /// <summary>
        /// <para>Guardar variables publicas con valores modificados para luego generar resumen del grupo de variables</para>
        /// </summary>
        public void fcvGuardarValoresParaVariablesResumen(ClassXmlPropVariablePublica tobRegVar, ClassXmlPropObjeto tobObjeto, String tcrValor)
        {
            if (tobRegVar.Hcl_resume_hcvr == "1")
            {
                var lobReg = new ClassXmlPropVariablePublica();

                // validar donde se incluye
                lobReg.Hcl_SiValorResumen = "1";
                lobReg.Hcl_SiValorResumen = flgPrnValidGenDatosImpresora(tobObjeto, tcrValor) == true ? "1" : "2";
                lobReg.Hcl_SiValorResumen = lobReg.Hcl_SiValorResumen == "1" && tobObjeto.ValorDefault != tcrValor && 
                                                                                !String.IsNullOrWhiteSpace(tcrValor) ? "1" : "2";
                lobReg.Hcl_ValorDigitado = tcrValor;

                lobReg.Hcl_secgru_hcgv = tobRegVar.Hcl_secgru_hcgv;
                lobReg.Hcl_ordvis_hcvr = tobRegVar.Hcl_ordvis_hcvr;
                lobReg.Hcl_titulo_hcvr = tobObjeto.Titulo;
                lobReg.Hcl_descri_hcvr = tobRegVar.Hcl_descri_hcvr;
                lobReg.Hcl_nomvar_hcvr = tobRegVar.Hcl_nomvar_hcvr;
                lobReg.Hcl_tipval_hcvr = tobRegVar.Hcl_tipval_hcvr;
                lobReg.Hcl_valper_hcvr = tobRegVar.Hcl_valper_hcvr;
                lobReg.Hcl_valvar_hcvr = tobRegVar.Hcl_valvar_hcvr;
                lobReg.Hcl_camdig_hcvr = tobRegVar.Hcl_camdig_hcvr;
                lobReg.Hcl_ranini_hcvr = tobRegVar.Hcl_ranini_hcvr;
                lobReg.Hcl_ranfin_hcvr = tobRegVar.Hcl_ranfin_hcvr;
                lobReg.Hcl_raninr_hcvr = tobRegVar.Hcl_raninr_hcvr;
                lobReg.Hcl_ranfnr_hcvr = tobRegVar.Hcl_ranfnr_hcvr;
                lobReg.Hcl_nivvar_hcvr = tobRegVar.Hcl_nivvar_hcvr;
                lobReg.Hcl_sistem_hcvr = tobRegVar.Hcl_sistem_hcvr;
                lobReg.Hcl_modoca_hcvr = tobRegVar.Hcl_modoca_hcvr;
                lobReg.Hcl_resume_hcvr = tobRegVar.Hcl_resume_hcvr;
                lobReg.Hcl_siresu_hcvr = tobRegVar.Hcl_siresu_hcvr;
                lobReg.Hcl_vresum_hcvr = tobRegVar.Hcl_vresum_hcvr;
                lobReg.Hcl_tvigen_hcvr = tobRegVar.Hcl_tvigen_hcvr;
                lobReg.Hcl_vvigen_hcvr = tobRegVar.Hcl_vvigen_hcvr;
                lobReg.Hcl_varray_hcvr = tobRegVar.Hcl_varray_hcvr;
                lobReg.Hcl_tmaray_hcvr = tobRegVar.Hcl_tmaray_hcvr;
                lobReg.Hcl_sisvar_hcvr = tobRegVar.Hcl_sisvar_hcvr;
                lobReg.Sis_estreg_esrg = tobRegVar.Sis_estreg_esrg;

                tmpVarPublicResumen.Add(lobReg);

                // Buscar si ya esta en lista las variables resumen del grupo
                var lobRegx = tmpGrupoVarPublicas.FirstOrDefault(x => x.Hcl_secgru_hcgv == tobRegVar.Hcl_secgru_hcgv);
                if (lobRegx == null)
                {
                    var lobTmpVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVrResumen(tobRegVar.Hcl_secgru_hcgv);
                    if (lobTmpVar != null)
                    {
                        foreach (var obx in lobTmpVar)
                        {
                            tmpGrupoVarPublicas.Add(new ClassTempResumenVarPublicas
                            {
                                Hcl_secgru_hcgv = obx.hcl_secgru_hcgv,
                                Hcl_titulo_hcvr = obx.hcl_titulo_hcvr,
                                Hcl_nomvar_hcvr = obx.hcl_nomvar_hcvr,
                                Hcl_modoca_hcvr = obx.hcl_modoca_hcvr,
                                Hcl_siresu_hcvr = obx.hcl_siresu_hcvr,
                                Hcl_vresum_hcvr = obx.hcl_vresum_hcvr,
                                Hcl_ValorResumen = String.Empty
                            });
                        }
                    }
                    else 
                    {
                        //No hay variables resumen registrar vacio
                        tmpGrupoVarPublicas.Add(new ClassTempResumenVarPublicas
                        {
                            Hcl_secgru_hcgv = tobRegVar.Hcl_secgru_hcgv,
                            Hcl_titulo_hcvr = "NO ASGINADA",
                            Hcl_nomvar_hcvr = "NA",
                            Hcl_modoca_hcvr = "",
                            Hcl_siresu_hcvr = "",
                            Hcl_vresum_hcvr = "",
                            Hcl_ValorResumen = ""
                        });
                    }
                }
            }
        }
        #endregion
        #region fcvGenerarVariablesResumen: Generar valores en variables tipo resumen y guardar 
        /// <summary>
        /// <para>Generar valores en variables tipo resumen y guardar</para>
        /// </summary>
        public void fcvGenerarVariablesResumen()
        {
            var lcrCodigoAdmision  = gobRegHistorialActivo.Adm_secadm_rgad;
            var lcrIdUnicoUsuario  = gobRegHistorialActivo.Sia_idesec_usua;
            var lcrTipoIde         = gobRegHistorialActivo.Sia_tipide_tide;
            var lcrNumeroIdUsuario = gobRegHistorialActivo.Sia_nroide_usua;
            var lnuContadorIdeReg  = ADMModeloAdmadmisiones.fnuGenerarIdItems(lcrCodigoAdmision);
            var llgActualizoDatos  = false;

            var lcrNombreVar = String.Empty;
            var lcrValorResumen = String.Empty;
            var lcrValorVariable = String.Empty;

            tmpVarPublicResumen = (from tmp in tmpVarPublicResumen orderby tmp.Hcl_secgru_hcgv, tmp.Hcl_ordvis_hcvr select tmp).ToList();

            foreach (var ob in tmpGrupoVarPublicas)
            {
                lcrValorResumen = String.Empty;
                if (ob.Hcl_nomvar_hcvr != "NA")
                {
                    fcvGenListaVarValidaResumen(ob.Hcl_vresum_hcvr);

                    foreach (var lobReg in tmpVarPublicResumen)
                    {
                        if (flgValidarSiIncluirEnResumen(ob, lobReg))
                        { 
                            lcrValorVariable = lobReg.Hcl_titulo_hcvr+": "+lobReg.Hcl_ValorDigitado.Trim();

                            // Tipo variables de resumen: 2=Resumen General y 3=Solo Hallazgos
                            if (ob.Hcl_modoca_hcvr == "3")
                            {
                                //  Verificar si tambien se incluye en Resumen: "Solo Hallazgos"
                                if (lobReg.Hcl_SiValorResumen == "1")
                                {
                                    lcrValorResumen += String.IsNullOrWhiteSpace(lcrValorResumen) ? lcrValorVariable : " " + lcrValorVariable;
                                }
                            }
                            else 
                            {
                                // se incluye Resumen general
                                lcrValorResumen += String.IsNullOrWhiteSpace(lcrValorResumen) ? lcrValorVariable : " " + lcrValorVariable;
                            }
                        }
                    }
                    // Guardar datos de la variable resumen
                    llgActualizoDatos = true;
                    lnuContadorIdeReg++;
                    ModeloHclvariabactual.fcvActualizarVariablePublica("2", lcrCodigoAdmision, lcrIdUnicoUsuario, lcrTipoIde,
                                                                        lcrNumeroIdUsuario, ob.Hcl_nomvar_hcvr, 
                                                                        lcrValorResumen, lnuContadorIdeReg, gcrSysSeparadorDecimal);
                }
            }
            // si se actualizo variables publicas 
            if (llgActualizoDatos == true)
            {
                ADMModeloAdmadmisiones.fcvActualizGenIdItems(lcrCodigoAdmision, lnuContadorIdeReg);
            }

        }
        #endregion
        #region fcvGenListaVarValidaResumen: Generar lista variables para validacion del resumen
        /// <summary>
        /// <para>Generar lista variables para validacion incluir/excluir del resumen</para>
        /// </summary>
        public void fcvGenListaVarValidaResumen(String tcrListaVariables)
        {
            if (String.IsNullOrWhiteSpace(tcrListaVariables))
            {
                tmpGrupoListaVarPublicas = null;
            }
            else
            {
                tmpGrupoListaVarPublicas = new List<ClassTempResumenVarPublicas>();
                string[] larArray = tcrListaVariables.Split((";").ToCharArray());
                var lnuTotElemtos = larArray.Length;
                var lcrValor = String.Empty;
                var i = 0;

                // Revisar lista
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    // Solo guardar nombre de variable para saber si se incluye/excluye del resumen
                    lcrValor = larArray[i].ToUpper();
                    tmpGrupoListaVarPublicas.Add(new ClassTempResumenVarPublicas
                    {
                        Hcl_secgru_hcgv = "",
                        Hcl_titulo_hcvr = "",
                        Hcl_nomvar_hcvr = lcrValor,
                        Hcl_modoca_hcvr = "",
                        Hcl_siresu_hcvr = "",
                        Hcl_vresum_hcvr = "",
                        Hcl_ValorResumen = ""
                    });
                }
            }

        }
        #endregion
        #region flgValidarSiIncluirEnResumen: Validar incluir/excluir lista de variables del resumen
        /// <summary>
        /// <para>Validar si incluir/excluir la variable en resumen</para>
        /// <para>Devuelve valor logico "True" para indicar que si se incluye y "False" para no incluir</para>
        /// </summary>
        public bool flgValidarSiIncluirEnResumen(ClassTempResumenVarPublicas tobGrupo, ClassXmlPropVariablePublica tobVariable)
        {
            var llgReturn = true;

            // Hay variables en la lista y Hcl_siresu_hcvr es diferente de "No aplica"
            // Hcl_siresu_hcvr: 1=Incluir solo lista variables en resumen 2= No incluir lista variables en resumen 3=No Aplica
            if (tmpGrupoListaVarPublicas != null && tobGrupo.Hcl_siresu_hcvr!= "3")
            {
                var lobReg = tmpGrupoListaVarPublicas.FirstOrDefault(x => x.Hcl_nomvar_hcvr == tobVariable.Hcl_nomvar_hcvr);
                if (lobReg != null)
                {
                    llgReturn = tobGrupo.Hcl_siresu_hcvr == "1" ? true : false;
                }
                else
                {
                    llgReturn = tobGrupo.Hcl_siresu_hcvr == "1" ? false : true;
                }
            }

            return llgReturn;
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
            var lnuOrdenVista = 0;
            var lcrSeccionCodigo = String.Empty;
            var lcrSeccionNombre = String.Empty;
            var lnuSeccionOrdVis = 0;
            var lnuSeccionColumn = fnuPrnPlantTipoHojaReporteMaxCol(gcrPlantillaTipoHojaReporte);

            tmpPrnDetalles = null;
            tmpPrnDetallAux = null;
            tmpPrnDetalles = new List<TmpDatosFormatosDe>();
            tmpPrnDetallAux = new List<TmpDatosFormatosDe>();
            flgPrnReiniciarTotalRegistrosSeccion();

            foreach (var lobReg in tmpCapturaDatos)
            {
                var lobObjeto = fobRegSelectParenObjeto("OBJETOS", "", lobReg.Name).FirstOrDefault();
                if (lobObjeto != null)
                {
                    lobObjeto.PrnSiValidar = String.IsNullOrWhiteSpace(lobObjeto.PrnSiValidar) ? "1" : lobObjeto.PrnSiValidar;
                    llgValor = false;
                    lcrValor = lobReg.Valor;
                    lcrTitulo = lobObjeto.Titulo;
                    llgTitulo = lobObjeto.PrnMostrarTitulo == "2" ? false : true;
                    lnuOrdenVista = String.IsNullOrWhiteSpace(lobObjeto.OrdenVista) ? 0 : Convert.ToInt32(lobObjeto.OrdenVista);
                    lcrSeccionCodigo = lobObjeto.SeccionCodigo;

                    #region datos de objetos
                    switch (lobReg.TipoObjeto)
                    {
                        case "TEXTBOX":
                            llgValor = flgPrnValidGenDatosImpresora(lobObjeto, lcrValor);
                            break;

                        case "TEXTBOXDATE":
                            llgValor = flgPrnValidGenDatosImpresora(lobObjeto, lcrValor);
                            break;

                        case "TEXTBOXTIME":
                            llgValor = flgPrnValidGenDatosImpresora(lobObjeto, lcrValor);
                            break;

                        case "RICHTEXTBOX":
                            llgValor = flgPrnValidGenDatosImpresora(lobObjeto, lcrValor);
                            break;

                        case "COMBOBOX":
                            #region Generar registro detalle
                            if (flgPrnValidGenDatosImpresora(lobObjeto, lcrValor))
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
                            if (flgPrnValidGenDatosImpresora(lobObjeto, lcrValor))
                            {
                                llgValor = true;

                                // Buscar el titulo del valor
                                var lobRel = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.Parent).FirstOrDefault();
                                if (lobRel != null)
                                {
                                    lcrTitulo = lobRel.Titulo;
                                    lcrSeccionCodigo = lobRel.SeccionCodigo;
                                }

                                // Buscar el valor descripcion
                                var lobObjDes = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobObjeto.Parent).FirstOrDefault();
                                if (lobObjDes != null)
                                {
                                    var lobDes = tmpCapturaDatos.FirstOrDefault(x => x.Name == lobObjDes.Name);
                                    if (lobDes != null)
                                    {
                                        lcrValor = lcrValor + " - " + lobDes.Valor.Trim();
                                    }
                                }
                            }
                            break;
                            #endregion

                        case "MULTICHKBOX":
                            #region Generar registro detalle
                            if (flgPrnValidGenDatosImpresora(lobObjeto, lcrValor))
                            {
                                llgValor = true;
                                // Buscar el titulo del valor
                                var lobRel = fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.Parent).FirstOrDefault();
                                if (lobRel != null)
                                {
                                    lcrTitulo = lobRel.Titulo;
                                    lcrSeccionCodigo = lobRel.SeccionCodigo;
                                }

                                lcrValor = lcrValor.ToUpper() == "TRUE" || lcrValor.ToUpper() == "1" ? "[X] " + lobReg.Titulo : "[_] " + lobReg.Titulo;
                            }
                            break;
                            #endregion

                        case "MULTIGROUPRADIOBUTTON":
                            #region Generar registro detalle
                            if (flgPrnValidGenDatosImpresora(lobObjeto, lcrValor))
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
                        if (lobSecc != null)
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
                        lobRegAux.Hcl_registro_ordvista = lnuOrdenVista;
                        lobRegAux.Hcl_titulo_dato1      = lcrTitulo;
                        lobRegAux.Hcl_valor_dato1       = llgTitulo == true ? lcrTitulo + ": " + lcrValor : lcrValor;

                        tmpPrnDetallAux.Add(lobRegAux);
                    }
                    #endregion
                }
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
            var lcrCodigoProf = gobRegHistorialActivo.Sia_codpfa_prof;
            lobPrnRegMa = new TmpDatosFormatosMa();

            // cargar imagen de la firma cuando exista Hcl_objeto_imagen1
            lobPrnRegMa.Sia_codpfa_prof = lcrCodigoProf; // Codigo del profesional
            lobPrnRegMa.Hcl_objeto_imagen1 = String.Empty; // Nombre imagen firma 
            var tmp = ModeloSiamaeprofsalud.flsListaSiamaeprofsaludEx("1", lcrCodigoProf);
            if (tmp != null)
            {
                var lcrRegistro = !String.IsNullOrWhiteSpace(tmp.Sia_rmedic_prof) ? " REGISTRO: " + tmp.Sia_rmedic_prof.Trim() : String.Empty;
                // Nombre
                lobPrnRegMa.Sia_nompro_prof = "[" + lcrCodigoProf + "] " + tmp.Sia_nompro_prof.Trim() + lcrRegistro; 
                                              
                // Imagen Firma 
                lobPrnRegMa.Hcl_objeto_imagen1 = !String.IsNullOrWhiteSpace(tmp.Sia_ifirma_prof) ? tmp.Sia_ifirma_prof : String.Empty; 
            }
            // Registro maestro datos
            #region Registro maestro datos
            lobPrnRegMa.Hcl_titulo_reporte = gcrPlantillaTituloReporte;  // debe ser  el titulo del reporte
            lobPrnRegMa.Hcl_nroreg_hcms = gobRegHistorialActivo.Hcl_nroreg_hcev; // secuencial unico registro
            lobPrnRegMa.Hcl_nroreg_hcev = gobRegHistorialActivo.Hcl_nroreg_hcev; // Codigo registro en historial clinico
            lobPrnRegMa.Adm_secadm_rgad = gobRegHistorialActivo.Adm_secadm_rgad; // Admision
            lobPrnRegMa.Sia_idesec_usua = tmpUsuarioAtendido.Sia_idesec_usua; // Id unico susuario
            lobPrnRegMa.Sia_tipide_tide = tmpUsuarioAtendido.Sia_tipide_tide; // Tipo Ie
            lobPrnRegMa.Sia_nroide_usua = tmpUsuarioAtendido.Sia_nroide_usua; // Numero identificacion
            lobPrnRegMa.Hcl_tipreg_hctr = gcrPlantillaTipoHojaReporte; // Tamaño Hoja para imprimir ejemplo:"01" = Hoja carta
            lobPrnRegMa.Sia_codare_aser = "NA"; // Area prestacion de servicios
            lobPrnRegMa.Hcl_gesfec_hcms = gobRegHistorialActivo.Hcl_gesfec_hcev.ToShortDateString(); // Fecha gestion
            lobPrnRegMa.Hcl_geshor_hcms = gobRegHistorialActivo.Hcl_geshor_hcev; // Hora gestion
            lobPrnRegMa.Hcl_horges_hcms = Funciones.fcrConvierteHora(lobPrnRegMa.Hcl_geshor_hcms.ToString(), "24", gcrSysSeparadorDecimal, ":"); // Hora gestion formato 12H
            lobPrnRegMa.Hcl_tiptur_hctu = "T01"; // Mañana /Tipo Turno clsificacion turno
            //lobPrnRegMa.Sia_codpfa_prof = gobRegHistorialActivo.Sia_codpfa_prof; // Codigo del profesional
            lobPrnRegMa.Sis_estpro_espr = "2"; // Estado del registro
            lobPrnRegMa.Hcl_desreg_hcev = gcrPlantillaNombreTitulo; // Descripcion evento medico
            lobPrnRegMa.Sia_nomusu_usua = tmpUsuarioAtendido.Sia_nomusu_usua; // Nombre completo del usuario o paciente 
            lobPrnRegMa.Sia_deside_tide = ""; // Descrip tipo identificacion
            lobPrnRegMa.Hcl_desreg_hctr = ""; // Descripcion tipo actividad
            lobPrnRegMa.Sia_desare_aser = "NA"; // Descripcion area prestacion servicio
            lobPrnRegMa.Hcl_destur_hctu = "NA";
            //lobPrnRegMa.Sia_nompro_prof = ""; // Nombre del profesional
            lobPrnRegMa.Sis_despro_espr = "CONFIRMADO"; // Estado del proceso
            // Add en temporal
            #endregion
            return llgReturn;

        }
        #endregion
    }
    #region Refresh para los controles de usuario
    /// <summary>
    /// <para>Refresh para los controles de usuario</para>
    /// </summary>
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
    #endregion
} 
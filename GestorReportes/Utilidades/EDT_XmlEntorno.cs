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
using GestorReportes.Vista;
using GestorReportes.VistaModelo;
using GestorReportes.Modelo;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Clases;
using Sistema.Modelo;
using Reportes.Utilidades;

namespace GestorReportes.Utilidades
{
    //---------------------------------------------------------------
    // GESTION GENERAL DE PROCESOS 
    //---------------------------------------------------------------
    public class XmlEntorno
    {
        #region Datos varios
        //- Referencias 
        public UIElement gobRefObjeto;
        public WrapPanel gobRefPlantillaEscritorio;
        public WrapPanel gobRefPlantillaEtiqueta;
        public VistaModeloObjetoActivo gobRefVM;
        public ProgressBar gobProgressBar;
        public static Aplicacion oApp = Aplicacion.Instancia();
        //Variables de control
        public double gduMinimoAnchoPlantilla       = 20;
        public XmlDocument gobXml                   = new XmlDocument();
        public String gcrXmlDocument                = String.Empty;
        public String gcrXmlNombreArchivo           = String.Empty;
        public static String gcrSysSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrFormatoArchvioGuardarDatos = oApp.gcrAppBdatosArchvioGuardarDatos; // "01" => Guardado en tablas por defecto el otro seria "XM" => Xml
        public String gcrSeccionDefault             = "01"; // Seccion activa por defecto (cambia en diseño)
        // Variables para control al importar datos externos o desde base de datos
        public String gcrImportArchivoPlantilla = String.Empty;
        public String gcrImportArchivoDatos     = String.Empty;
        public String gcrImportArchivoRuta      = String.Empty;
        public String gcrTipoOrigenArchivo      = String.Empty; // BDATOS/ARCHIVO
        //- Gestion Edicion
        public int gnuTopeIdAccionEdicion    = 0;
        public int gnuIdAccionEdicionPuntero = 0;
        #endregion
        // DATOS DESDE PLANTILLA
        #region Datos desde plantilla
        public int gnuPlantillaGenerObjPagina             = 0;
        public int gnuPlantillaGenerSecObjeto             = 0;
        public int gnuPlantillaHeight                     = 0;
        public int gnuPlantillaWidth                      = 0;
        public String gcrPlantillaNombreArchivo           = String.Empty;
        public String gcrPlantillaNombreTitulo            = String.Empty;
        public String gcrPlantillaPrefijoObjetos          = String.Empty;
        public String gcrPlantillaNavegadorPlantilla      = "ESCRITORIO";
        public String gcrPlantillaObjetoModo              = "EDICION-ESCRITORIO";
        public String gcrPlantillaCodigoPlantilla         = String.Empty;
        public String gcrPlantillaTipoImpresion           = String.Empty;
        public String gcrPlantillaTituloReporte           = String.Empty;
        public String gcrPlantillaTipoHojaReporte         = String.Empty;
        public bool glgPlaniillaOptimizarTabsGenChar      = true;  // Activar la optimizacion cuando el XML es mayor a 800000
        public bool glgPlaniillaOptimizarTabsXml          = false;  // Para indicar si se optimizo el XML que se acaba de generar
        public static String gcrPlantillaSeparadorDecimal = String.Empty;
        public int gnuPlantillaMargenVertical   = 60;
        public int gnuPlantillaMargenHorizontal = 20;
        // Temporales registro en Bdatos para plantilla activa
        /// <summary>
        /// <para>Registro maestro (desde la tabla grpmaeplantilla) para la plantilla activa en pantalla</para>
        /// </summary>
        public ModeloPlantilla gobRegPlantMaestro = null;
        /// <summary>
        /// <para>Registro version plantilla (desde la tabla grpmaeversplant) para la plantilla activa en pantalla</para>
        /// </summary>
        public VersionPlantilla gobRegPlantVersion = null;
        #endregion
        // DATOS DESDE DIGITACION PLANTILLA
        #region Datos desde Digitacion
        public String gcrDatosModoVista = "D"; // D = Diseño E= Edicion o Captura V=Vista solo lectura
        public String gcrDatosModoGestion = "D"; // D = Diseño Cambia a "G" =Gestion, cuando se encuentra algun objeto Multiseccion
        public List<ClassXmlPropDatos> tmpCapturaDatos = new List<ClassXmlPropDatos>();
        #endregion
        //- TEMPORALES
        #region Gestion temprales del sistema
        // Temporales de gestion vista modelo propiedades plantilla
        public List<XmlPropPlantilla> tmpPlantilla;
        public List<ClassXmlItemEtiquetas> tmpEtiquetas;
        public List<ClassXmlImgPredefinidas> tmpImagenesPredef;
        public List<ClassXmlComboBoxItems> tmpSecciones;
        // Gestion de objetos
        public List<ClassXmlPropObjeto> tmpObjetos          = new List<ClassXmlPropObjeto>();
        public List<ClassXmlPropObjeto> tmpObjetosAux       = new List<ClassXmlPropObjeto>();
        public List<ClassXmlPropObjeto> tmpObjetosAccion    = new List<ClassXmlPropObjeto>();
        public List<ClassXmlPropObjeto> tmpObjetosEliminado = new List<ClassXmlPropObjeto>();
        // Temporales par vista reporte impreso
        public List<TmpDatosFormatosDe> tmpPrnDetalles  = new List<TmpDatosFormatosDe>();
        public List<TmpDatosFormatosDe> tmpPrnDetallAux = new List<TmpDatosFormatosDe>();
        public TmpDatosFormatosMa lobPrnRegMa           = new TmpDatosFormatosMa();
        // Items en combos y objetos relacion
        public List<ClassXmlCamposRelacion> tmpCamposRelacion       = new List<ClassXmlCamposRelacion>();
        public List<ClassXmlComboBoxItems> tmpComboItems            = new List<ClassXmlComboBoxItems>(); // contiene todos los items de todos los objetos ComboBox 
        public List<ClassXmlComboBoxItems> tmpComboItemsEliminado   = new List<ClassXmlComboBoxItems>();
        public List<ClassXmlObjetosRelacion> tmpObjetosRelacion     = new List<ClassXmlObjetosRelacion>();
        #endregion
        // referencias a registro de objeto seleccionado
        public ClassXmlPropObjeto refRegObjActivo = new ClassXmlPropObjeto();
        public ClassRefTreeObjeto refTreeObj = new ClassRefTreeObjeto();
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public List<ModeloHclregisevcampo> tmpCamposBindig = new List<ModeloHclregisevcampo>();

        public XmlEntorno()
        {
            //- codigo de gestion
        }
        //------------------------------------------------------------
        // CLASES PARA CREAR ESTRUCTURAS
        //------------------------------------------------------------
        #region Estructuras Gestion de objetos y edicion formatos
        #region PLANTILLA ClassXmlPropPlantilla: Clase para cargar propiedades de la plantilla
        /// <summary>
        /// <para>Clase para cargar propiedades (atributos) de la plantilla</para>
        /// </summary>
        public class XmlPropPlantilla
        {
            public String Codigo { get; set; }
            public String Name { get; set; }                // Nombre o Titulo en texto 
            public String HL7Formato { get; set; }
            public String VersionSistema { get; set; }
            public String VersionPlantilla { get; set; }
            public String Clave { get; set; }
            public String CodigoGrupo { get; set; }
            public String TipoFormato { get; set; }         //PLANTILLA,ETIQUETA/REPORTE/...
            public String VistaEnMuroHc { get; set; }
            public String GenerObjPagina { get; set; }
            public String GenerSecObjeto { get; set; }
            public String ImagenIcono { get; set; }
            public String PlantTipoImpresion { get; set; }      // 1 = Vista diseño y Reporte, 2=Solo vista diseño,3=Solo reporte
            public String PlantTituloReporte { get; set; }      // Titulo para el reporte impreso
            public String PlantTipoHojaReporte { get; set; }    // 01 = hoja carta maximi 5 columnas 02 = hoja Oficio maximo 5 columnas, .... 
            public String PlantillaWidth { get; set; }
            public String PlantillaHeight { get; set; }
            public String MargenVertical { get; set; }
            public String MargenHorizontal { get; set; }
            public String PlantillaBackground { get; set; }
            public String PrefijoObjetos { get; set; }
            public String EstiloModoDis { get; set; }
            public String EstiloModoEdt { get; set; }
            public String EstiloModoVis { get; set; }
            public String ImagenFondoCodigo { get; set; }     
            public String ImagenFondoUri { get; set; }
            public String ImagenFondoNombre { get; set; }           
            public String SeparadorDecimal { get; set; }
            public String Navegador { get; set; }
            
        }
        #endregion
        #region PAGINA ClassXmlPropPagina: Clase para cargar propiedades Pagina
        /// <summary>
        /// <para>ClassXmlPropPagina: Clase para cargar propiedades (atributos) Pagina</para>
        /// </summary>
        public class ClassXmlPropPagina
        {
            public String Name { get; set; }                    //Nombre del Objeto
            public String Pagina { get; set; }                  //Numero de pagina en orden de vista
            public String Titulo { get; set; }
            public String TipoObjeto { get; set; }
            public String Parent { get; set; }
            public String TabIndex { get; set; }
            public String Style { get; set; }
            public String VerticalAlignment { get; set; }
            public String HorizontalAlignment { get; set; }
            public String Background { get; set; }
            public String Margin { get; set; }
            public String Width { get; set; }
            public String Height { get; set; }
        }
        #endregion
        #region ZONA ClassXmlPropZona: Clase para cargar propiedades Zona
        /// <summary>
        /// <para>ClassXmlPropZona: Clase para cargar propiedades (atributos) Zona</para>
        /// </summary>
        public class ClassXmlPropZona
        {
            public String Name { get; set; }
            public String Pagina { get; set; }
            public String Titulo { get; set; }
            public String TipoObjeto { get; set; }
            public String Parent { get; set; }
            public String TabIndex { get; set; }
            public String Style { get; set; }
            public String Margin { get; set; }
            public String Border { get; set; }
            public String VerticalAlignment { get; set; }
            public String HorizontalAlignment { get; set; }
            public String Background { get; set; }
            public String Height { get; set; }
            public String Width { get; set; }
            public String Top { get; set; }
            public String Left { get; set; }
        }
        #endregion
        #region ETIQUETAS ClassXmlItemEtiquetas: Clase para Item tipo etiquetas inteligentes
        /// <summary>
        /// <para>Clase para Item tipo etiquetas inteligentes</para>
        /// </summary>
        public class ClassXmlItemEtiquetas
        {
            public int IntIndice { get; set; }
            public String Indice { get; set; }
            public String Codigo { get; set; }
            public String Version { get; set; }
            public String Icono { get; set; }
            public String Descripcion { get; set; }
            public String Archivo { get; set; }
            public String Imaen { get; set; }
        }
        #endregion
        #region IMAGENES ClassXmlImgPredefinidas: Clase para Item tipo imagenes predefinidas
        /// <summary>
        /// <para>Clase para cargar lista de imagenes predefinidas</para>
        /// </summary>
        public class ClassXmlImgPredefinidas
        {
            public FrameworkElement RefObjeto { get; set; }   // Referencia a la instancia de la imagen en vista imagenes predefinidas
            public int IntCodigo { get; set; }
            public String Codigo { get; set; }
            public String TipoObjeto { get; set; }
            public String ClaseBase { get; set; }
            public String Titulo { get; set; }
            public String ImagenWidth { get; set; }
            public String ImagenHeight { get; set; }
            public String RecursoArchivoTipo { get; set; }
            public String RecursoArchivoCodigo { get; set; }
            public String RecursoArchivoUri { get; set; }
            public String RecursoArchivoNombre { get; set; }
            public String Imaen { get; set; }
        }
        #endregion
        #region CAMPOS RELACION ClassXmlCamposRelacion: Lista campos de tabla que estan en uso por algun objeto en alguna zona
        /// <summary>
        /// <para>Lista campos de tabla que estan en uso por algun objeto en una Zona</para>
        /// </summary>
        public class ClassXmlCamposRelacion
        {
            public String Name { get; set; }
            public String Parent { get; set; }
            public String Tipo { get; set; }
            public String Ancho { get; set; }
            public String NameCampoDE { get; set; }
            public String ObjetoBinding { get; set; }
        }
        #endregion
        #region ITEM COMBOBOX ClassXmlComboBoxItems: Lista items para seleccion desde combobox
        /// <summary>
        /// <para>Lista items para seleccion desde combobox</para>
        /// </summary>
        public class ClassXmlComboBoxItems
        {
            public int IntIndice { get; set; }
            public int IntOrden { get; set; }
            public String Parent { get; set; }
            public String Indice { get; set; }
            public String Codigo { get; set; }
            public String Descripcion { get; set; }
            public String Auxiliar { get; set; }
            public String Imaen { get; set; }
            public String Imprimir { get; set; } // Secciones: "1"=Enviar a impresion "2"= No enviar a impresion
            public int IntTotalRegistros { get; set; }
            public int IntTotalFilas { get; set; }
            public int IntTotalColumnas { get; set; }
            
        }
        #endregion
        #region OBJETOS RELACION ClassXmlObjetosRelacion: Lista objetos relacionados para mostrar en pagina muro
        /// <summary>
        /// <para>Lista objetos relacionados para mostrar en pagina muro</para>
        /// </summary>
        public class ClassXmlObjetosRelacion
        {
            public String RelacionPagina { get; set; }
            public String RelacionZona { get; set; }
            public String RelacionObjeto { get; set; }
            public String NameObjeto { get; set; }          // objeto que hace las veces de copia par vista en muro
        }
        #endregion
        #region VISTA TREE ClassRefTreeObjeto: Referencia al contenedor del objeto de nivel superior
        /// <summary>
        /// <para>Referencia al contenedor del objeto de nivel superior para generar objetos en cascada</para>
        /// <para>al momento de cargar desde XML</para>
        /// </summary>
        public class ClassRefTreeObjeto
        {
            public String CodigoPlantilla { get; set; }         // Plantilla a la cual pertenece el objeto activo  o el nivel tree
            public WrapPanel Plantilla { get; set; }
            public String Navegador { get; set; }
            public Canvas Pagina { get; set; }
            public GroupBox Zona { get; set; }
            public GroupBox Grupo { get; set; }
            public WrapPanel ContenedorPagina { get; set; }
            public Canvas ContenedorZona { get; set; }
            public Canvas ContenedorGrupo { get; set; }
            public int NivelObjetoSelect { get; set; } // Nivel del objeto seleccionado con clik  1=Pagina / 2=Zona  / 3=Objetos dentro de Zona / 4=Objetos dentro de grupos
        }
        #endregion
        #region ClassXmlRefActualizArchivos: Lista ref campos actualizar archivos 4505/Rips y otros
        /// <summary>
        /// <para>Lista de referencias campos para actualizar archivos 4505/Rips y otros</para>
        /// </summary>
        public class ClassXmlRefActualizArchivos
        {
            public int IntIndice { get; set; }
            public String Parent { get; set; }
            /// <summary>
            /// <para>Indice de tipo String para gestion del registro</para>
            /// </summary>
            public String Indice { get; set; }
            /// <summary>
            /// <para>Nombre del campo para actualizar archivos 4505/Rips y otros</para>
            /// </summary>
            public String Campo { get; set; }
            /// <summary>
            /// <para>Titulo o descripcion del campo 4505/Rips y otros</para>
            /// </summary>
            public String CampoTitulo { get; set; }
            /// <summary>
            /// <para>Nombre del campo 4505/Rips, del cual es dependiente el campo actual</para>
            /// </summary>
            public String DependienteDe { get; set; }
            /// <summary>
            /// <para>Valor que reporta, debe estar dentro del rango valores permitidos del campo</para>
            /// </summary>
            public String ValorReporta { get; set; }
            /// <summary>
            /// <para>Codigo archivo 4505/Rips, AC=Rips Consulta AP=Ripos Procedimiento y otros</para>
            /// </summary>
            public String Archivo { get; set; }
            /// <summary>
            /// <para>Titulo o descripcion del archivo 4505/Rips, AC=Rips Consulta AP=Ripos Procedimiento y otros</para>
            /// </summary>
            public String ArchivoTitulo { get; set; }
            public String Imaen { get; set; }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // CLASES ESTRUCTURAS QUE GUARDAN DATOS DILIGENCIADOS MODO CAPTURA
        //------------------------------------------------------------
        #region Estructuras para captura de datos en modo Captura
        #region PLANTILLA Datos ClassXmlPropPlanDatos: Clase para cargar propiedades plantilla Datos
        /// <summary>
        /// <para>Clase para cargar propiedades plantilla Datos</para>
        /// </summary>
        public class ClassXmlPropPlanDatos
        {
            public String Codigo { get; set; }                  // Igual que codigo de plantilla
            public String Name { get; set; }                    // Nombre o Titulo en texto (igual que la plantilla)
            public String NombreArchivoPlantilla { get; set; }
            public String VersionSistema { get; set; }
            public String VersionPlantilla { get; set; }
            public String Clave { get; set; }
            public String CodigoGrupo { get; set; }     
            public String TipoFormato { get; set; }             //PLANTILLA,ETIQUETA/REPORTE/DATOS/... (DATOS-> datos diligenciados en modo captura)
            public String GenerSecObjeto { get; set; }
            public String PrefijoObjetos { get; set; }
            public String DatosModoVista { get; set; }      // D = Diseño E= Edicion o Captura V=Vista solo lectura
            public String SeparadorDecimal { get; set; }
        }
        #endregion
        #region MURO ClassXmlPropMuro: Clase para cargar objetos a mostrar en el muro
        /// <summary>
        /// <para>Clase para cargar objetos a mostrar en vista historial cada evento o registro</para>
        /// </summary>
        public class ClassXmlVistaObjHistorial
        {
            #region Clase
            // Propiedades Básicas
            public String Name { get; set; }                    // Nombre del objeto que relaciona el dato como campo
            public String Titulo { get; set; }
            public String TipoObjeto { get; set; }              // IMAGEN/TEXTO
            public String Texto { get; set; }                   // Texto Diligenciado en modo captura
            // Propiedades Imagenes o archivos de recursos 
            public String RecursoArchivoTipo { get; set; }      // Tipo archivo IMAGEN,VIDEO,DOC,XLS,PDF...
            public String RecursoArchivoCodigo { get; set; }    // Codigo del recurso en la galeria de recursos
            public String RecursoArchivoUri { get; set; }       // Ruta de la imagen en galeria
            public String RecursoArchivoNombre { get; set; }    // Nombre del archivo de imagen 
            #endregion
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        //- CARGAR PLANTILLA PAGINAS ZONAS Y OBJETOS DESDE XML
        //------------------------------------------------------------
        #region Cargar Plantillas Paginas y otros
        #region fcvRegCargarXMLPlantilla: Cargar Plantilla Base desde XML
        /// <summary>
        /// <para>Cargar Plantilla Base desde XML </para>
        /// <para>tcrObjetoModoEjecucion:</para>
        /// <para>EDICION-ESCRITORIO    => Modo diseño de la plantilla (modificables)</para>
        /// <para>CAPTURA-ESCRITORIO    => objetos en escritorio en modo captura de datos (no son modificables)</para>
        /// <para>CAPTURA-ETIQUETA      => objetos dentro de capa etiquetas en modo captura (no son modificables)</para>
        /// <para>CAPTURA-EDT-ESCRITORIO=> objetos tipo etiquetas agregados en escritorio (agregados en modo captura y modificables)</para>
        /// <para>CAPTURA-EDT-ETIQUETA  => Objetos tipo etiquetas agregados en capa etiqueta (agregados en modo captura  y modificables)</para>
        /// </summary>
        public void fcvRegCargarXMLPlantilla(XmlElement tobjXmlPlantilla, String tcrNavegador, String tcrObjetoModoEjecucion)
        {
            gobRefVM.gnuPropValorProgressBar = 10;
            foreach (XmlElement lobNodos in tobjXmlPlantilla.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Propiedades")
                {
                    var lobjRegistro = fobLeerXmlAttributosPlantilla(lobNodos);

                    lobjRegistro.Navegador           = tcrNavegador;
                    gnuPlantillaGenerObjPagina       = Convert.ToInt32(lobjRegistro.GenerObjPagina);
                    gnuPlantillaGenerSecObjeto       = Convert.ToInt32(lobjRegistro.GenerSecObjeto);
                    gcrPlantillaPrefijoObjetos       = lobjRegistro.PrefijoObjetos.Trim();
                    gnuPlantillaHeight               = Convert.ToInt32(lobjRegistro.PlantillaHeight);
                    gnuPlantillaWidth                = Convert.ToInt32(lobjRegistro.PlantillaWidth);
                    gnuPlantillaMargenVertical       = Convert.ToInt32(lobjRegistro.MargenVertical);
                    gnuPlantillaMargenHorizontal     = Convert.ToInt32(lobjRegistro.MargenHorizontal);
                    gcrPlantillaSeparadorDecimal     = lobjRegistro.SeparadorDecimal.Trim();
                    gcrPlantillaNavegadorPlantilla   = tcrNavegador;
                    gcrPlantillaCodigoPlantilla      = lobjRegistro.Codigo;
                    gcrPlantillaObjetoModo           = tcrObjetoModoEjecucion;
                    gcrPlantillaTipoImpresion        = lobjRegistro.PlantTipoImpresion;
                    gcrPlantillaTituloReporte        = lobjRegistro.PlantTituloReporte;
                    gcrPlantillaTipoHojaReporte      = lobjRegistro.PlantTipoHojaReporte;

                    tmpPlantilla.Add(lobjRegistro);
                    break;
                }
            }
        }
        #endregion
        #region fobRegCargarXMLSecciones: Cargar secciones del formato
        /// <summary>
        /// <para>Cargar secciones del formato</para>
        /// </summary>
        public void fobRegCargarXMLSecciones(XmlElement tobjXmlPlantilla)
        {
            var llgReturn = false;
            gobRefVM.gnuPropValorProgressBar = 20;
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlPlantilla.SelectNodes("descendant::Propiedades/Secciones");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode item in lobLista)
                {
                    var lobjRegistro = fobLeerXmlAttributosSecciones(item);
                    tmpSecciones.Add(lobjRegistro);
                    llgReturn = true;
                }
            }
            // Verificar si hay al menos una seccion
            if (llgReturn == false)
            {
                fobRegCargarXMLSeccionDefault();
            }

        }
        #endregion
        #region fobRegCargarXMLSeccionDefault: Generar Seccion por defecto
        /// <summary>
        /// <para>Generar seccion por defecto o inicial del formato</para>
        /// </summary>
        public void fobRegCargarXMLSeccionDefault()
        {
            tmpSecciones = null;
            tmpSecciones = new List<ClassXmlComboBoxItems>();
            var lobjRegistro = new ClassXmlComboBoxItems();

            lobjRegistro.Indice = "1";
            lobjRegistro.IntIndice = 1;
            lobjRegistro.Codigo = "01";
            lobjRegistro.IntOrden = 1;
            lobjRegistro.Descripcion = "DATOS BASICOS";
            gcrSeccionDefault = "01";

            tmpSecciones.Add(lobjRegistro);
        }
        #endregion
        #region fobRegCargarXMLEtiquetas: Cargar Etiquetas inteligentes Base desde XML
        /// <summary>
        /// <para>Cargar Etiquetas inteligentes Base desde XML</para>
        /// </summary>
        public void fcvRegCargarXMLEtiquetas(XmlElement tobjXmlPlantilla)
        {
            gobRefVM.gnuPropValorProgressBar = 20;
            var lnuCont = tmpEtiquetas.Count;
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlPlantilla.SelectNodes("descendant::Propiedades/Etiquetas");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode item in lobLista)
                {
                    lnuCont++;
                    var lobjRegistro = fobLeerXmlAttributosEtiquetas(item);
                    lobjRegistro.IntIndice = lnuCont;
                    lobjRegistro.Indice = lnuCont.ToString();
                    tmpEtiquetas.Add(lobjRegistro);
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLImgPredefinidas: Cargar XML Imagenes predefinidas
        /// <summary>
        /// <para>Cargar XML Imagenes predefinidas</para>
        /// </summary>
        public void fcvRegCargarXMLImgPredefinidas(XmlElement tobjXmlGaleria)
        {
            tmpImagenesPredef = new List<ClassXmlImgPredefinidas>();
            foreach (XmlElement lobNodos in tobjXmlGaleria.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Galeria")
                {
                    foreach (XmlNode lobImagen in lobNodos.ChildNodes)
                    {
                        var lobjRegistro = fobLeerXmlAttributosImgPredefinidas(lobImagen);
                        tmpImagenesPredef.Add(lobjRegistro);
                    }
                    break;
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLPaginas: Cargar Paginas desde XML
        /// <summary>
        /// <para>Generar en pantalla Cargar objetos tipo paginas desde XML y sus respectivas zonas y objetos de datos</para>
        /// </summary>
        public void fcvRegCargarXMLPaginas(XmlElement tobjXmlPaginas)
        {
            gobRefVM.gnuPropValorProgressBar = 40;
            foreach (XmlElement lobNodos in tobjXmlPaginas.ChildNodes)
            {
                if (lobNodos.NodeType == XmlNodeType.Element && lobNodos.Name == "Paginas")
                {
                    foreach (XmlNode lobPagina in lobNodos.ChildNodes)
                    {
                        var lobjRegistro = fobLeerXmlAttributosObjeto(lobPagina);
                        //-Establecer datos para gestion
                        lobjRegistro.ObjetoNivel     = 1;
                        lobjRegistro.ObjetoEstado    = "ACTIVO";
                        lobjRegistro.Navegador       = gcrPlantillaNavegadorPlantilla;
                        lobjRegistro.ObjetoModo      = gcrPlantillaObjetoModo;
                        lobjRegistro.CodigoPlantilla = gcrPlantillaCodigoPlantilla;
                        refRegObjActivo              = lobjRegistro;
                        lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();

                        fcvMinimoWithPlantilla(lobjRegistro.Width);
                        fcvRegCargarXMLObjetosRelacion(lobPagina);
                        // Cargar las zonas con sus respectios objetos
                        fcvRegCargarXMLZonas(lobPagina, lobjRegistro);
                    }
                    break;
                }
            }
            gobRefVM.gnuPropValorProgressBar = 100;
        }
        #endregion
        #region fcvRegCargarXMLZonas: Cargar Zonas desde XML
        /// <summary>
        /// <para>Cargar lista de Zonas desde XML</para>
        /// </summary>
        public void fcvRegCargarXMLZonas(XmlNode tobjXmlPagina, ClassXmlPropObjeto toRegPagina)
        {
            try
            {
                XmlNodeList lobXmlNodo;
                lobXmlNodo = tobjXmlPagina.SelectNodes("descendant::Zonas");
                foreach (XmlNode lobLista in lobXmlNodo)
                {
                    foreach (XmlNode item in lobLista)
                    {
                        var lobjRegistro = fobLeerXmlAttributosObjeto(item);
                        //-Establecer datos para gestion
                        lobjRegistro.ObjetoNivel        = 2;
                        lobjRegistro.ObjetoParentPagina = toRegPagina.Name;
                        lobjRegistro.ObjetoEstado       = "ACTIVO";
                        lobjRegistro.Navegador          = gcrPlantillaNavegadorPlantilla;
                        lobjRegistro.ObjetoModo         = gcrPlantillaObjetoModo;
                        lobjRegistro.CodigoPlantilla    = gcrPlantillaCodigoPlantilla;
                        refRegObjActivo                 = lobjRegistro;

                        lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                        // Generar los objetos contenidos en la zona
                        fcvRegCargarXMLObjetosZonas(item, lobjRegistro);
                        fcvRegCargarXMLCamposRelacion(item);
                        fcvMinimoWithPlantilla(lobjRegistro.Width);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: fcvRegCargarXMLZonas");
                //MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvRegCargarXMLZonas");
            }
        }
        #endregion
        #region fcvRegCargarXMLObjetosZonas: Cargar objetos de Zonas desde XML
        /// <summary>
        /// <para>Cargar objetos de Zonas desde XML</para>
        /// </summary>
        public void fcvRegCargarXMLObjetosZonas(XmlNode tobjXmlZona, ClassXmlPropObjeto toRegZona)
        {
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlZona.SelectNodes("descendant::ObjetosEnZona");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode lobjItem in lobLista)
                {
                    var lobjRegistro = fobLeerXmlAttributosObjeto(lobjItem);
                    //-Establecer datos para gestion
                    lobjRegistro.ObjetoNivel        = fnuDefineNivelObjeto(lobjRegistro);
                    lobjRegistro.ObjetoParentPagina = toRegZona.ObjetoParentPagina;
                    lobjRegistro.ObjetoParentZona   = toRegZona.Name;
                    lobjRegistro.ObjetoEstado       = "ACTIVO";
                    lobjRegistro.Navegador          = gcrPlantillaNavegadorPlantilla;
                    lobjRegistro.ObjetoModo         = gcrPlantillaObjetoModo;
                    lobjRegistro.CodigoPlantilla    = gcrPlantillaCodigoPlantilla;
                    refRegObjActivo                 = lobjRegistro;

                    lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                    // Tipos objetos que tienen lista de items u objetos
                    switch (lobjRegistro.TipoObjeto)
                    {
                        case "GROUPBOX":
                            fcvRegCargarXMLObjetosGrupos(lobjItem, lobjRegistro);
                            break;

                        case "MULTIGROUPCHKBOX":
                            fcvRegCargarXMLObjetosGrupos(lobjItem, lobjRegistro);
                            break;

                        case "MULTIGROUPRADIOBUTTON":
                            fcvRegCargarXMLObjetosGrupos(lobjItem, lobjRegistro);
                            break;

                        case "TEXTBOXREL":
                            fcvRegCargarXMLObjetosGrupos(lobjItem, lobjRegistro);
                            break;

                        case "COMBOBOX":
                            fcvRegCargarXMLObjetosComboItems(lobjItem);
                            break;
                    }
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLObjetosGrupos: Cargar objetos contenidos en grupos
        /// <summary>
        /// <para>Cargar objetos contenidos en grupos</para>
        /// </summary>
        public void fcvRegCargarXMLObjetosGrupos(XmlNode tobjXmlNodo, ClassXmlPropObjeto toRegGrupo)
        {
            foreach (XmlNode item in tobjXmlNodo.ChildNodes)
            {
                var lobjRegistro = fobLeerXmlAttributosObjeto(item);
                //-Establecer datos para gestion
                lobjRegistro.ObjetoNivel        = 5;
                lobjRegistro.ObjetoParentPagina = toRegGrupo.ObjetoParentPagina;
                lobjRegistro.ObjetoParentZona   = toRegGrupo.ObjetoParentZona;
                lobjRegistro.ObjetoParentGrupo  = toRegGrupo.Name;
                lobjRegistro.ObjetoEstado       = "ACTIVO";
                lobjRegistro.Navegador          = gcrPlantillaNavegadorPlantilla;
                lobjRegistro.ObjetoModo         = gcrPlantillaObjetoModo;
                lobjRegistro.CodigoPlantilla    = gcrPlantillaCodigoPlantilla;
                refRegObjActivo                 = lobjRegistro;

                lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
            }
        }
        #endregion
        #region fcvRegCargarXMLObjetosComboItems: Cargar lista items de CoboBox
        /// <summary>
        /// <para>Cargar lista items de ComboBox en temporal general que los junta todos</para>
        /// </summary>
        public void fcvRegCargarXMLObjetosComboItems(XmlNode tobjXmlNodo)
        {
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlNodo.SelectNodes("descendant::ComboValoresItems");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode item in lobLista)
                {
                    var lobjRegistro = fobLeerXmlAttributosComboItems(item);
                    lobjRegistro.Imaen = "I";
                    tmpComboItems.Add(lobjRegistro);
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLCamposRelacion: Cargar campos relacion con objetos de Zonas desde XML
        /// <summary>
        /// <para>Cargar campos relacion con objetos de Zonas desde XML</para>
        /// </summary>
        public void fcvRegCargarXMLCamposRelacion(XmlNode tobjXmlZona)
        {
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlZona.SelectNodes("descendant::CamposRelacion");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode lobjItem in lobLista)
                {
                    var lobjRegistro = fobLeerXmlAttributosCamposRelacion(lobjItem);
                    tmpCamposRelacion.Add(lobjRegistro);
                }
            }
        }
        #endregion
        #region fcvRegCargarXMLObjetosRelacion: Cargar Objetos Relacion pagina muro desde XML
        /// <summary>
        /// <para>Cargar Objetos Relacion pagina muro desde XML</para>
        /// </summary>
        public void fcvRegCargarXMLObjetosRelacion(XmlNode tobjXmlPagina)
        {
            XmlNodeList lobXmlNodo;
            lobXmlNodo = tobjXmlPagina.SelectNodes("descendant::ObjetosRelacion");
            foreach (XmlNode lobLista in lobXmlNodo)
            {
                foreach (XmlNode item in lobLista)
                {
                    var lobjRegistro = fobLeerXmlAttributosObjetosRelacion(item);
                    tmpObjetosRelacion.Add(lobjRegistro);
                }
            }
        }
        #endregion
        #region fobRegCargarXMLGenerarObjeto: Generar objetos al cargar plantilla
        /// <summary>
        /// <para>Genera un nuevo objeto segun el tipo proveniente de la plantilla </para>
        /// <para>las caracteristicas del objeto deben estar en refRegObjActivo</para>
        /// </summary>
        public FrameworkElement fobRegCargarXMLGenerarObjeto()
        {
            var lcrModoVsitaObjeto = gcrDatosModoVista;
            FrameworkElement lobObjeto = new FrameworkElement();
            #region objetos
            switch (refRegObjActivo.TipoObjeto)
            {
                case "PAGINA":
                    lobObjeto = fobjAddObjetoPagina();
                    break;

                case "ZONA":
                    lobObjeto = fcvAddObjetoZona();
                    break;

                case "TEXTBOX":
                    lobObjeto = fobjAddObjetoTextBox();
                    break;

                case "RICHTEXTBOX":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto == "D") 
                    {
                        // D= Modo diseño, mostrar un TextBox normal
                        lobObjeto = fobjAddObjetoTextBox();
                    }
                    else
                    {
                        // E = Edicion o Modo captura de datos /  V = Modo vista solo lectura
                        lobObjeto = fobjAddObjetoRichTextBox();
                    }
                    break;

                case "TEXTBOXDATE":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto != "V")
                    {
                        lobObjeto = fobjAddObjetoControlFecha();
                    }
                    else 
                    {
                        lobObjeto = fobjAddObjetoTextBox();
                    }
                    break;

                case "TEXTBOXTIME":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto != "V")
                    {
                        lobObjeto = fobjAddObjetoControlHora();
                    }
                    else
                    {
                        lobObjeto = fobjAddObjetoTextBox();
                    }
                    break;

                case "COMBOBOX":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto != "V")
                    {
                        lobObjeto = fobjAddObjetoComboBox();
                    }
                    else
                    {
                        lobObjeto = fobjAddObjetoTextBox();
                    }
                    break;

                case "TEXTBLOCK":
                    lobObjeto = fobjAddObjetoTextBlock();
                    break;

                case "RADIOBUTTON":
                    break;

                case "CHECKBOX":
                    lobObjeto = fobjAddObjetoCheckBox();
                    break;

                case "BUTTON":
                    lobObjeto = fobjAddObjetoButton();
                    break;

                case "GROUPBOX":
                    lobObjeto = fobjAddObjetoGroupBox();
                    break;

                case "TEXTBOXREL":
                    lobObjeto = fobjAddObjetoGroupBox();
                    break;

                case "CONTROLADMISION":
                    lobObjeto = fobjAddObjetoControlVistaAdmision();
                    break;

                case "CONTROLFRAMINGHAM":
                    lobObjeto = fobjAddObjetoControlVistaFramingHam();
                    break;

                case "CONTROLIMC":
                    lobObjeto = fobjAddObjetoControlVistaImc();
                    break;

                case "CONTROLEADAUDICIONLENGUAJE":
                    lobObjeto = fobjAddObjetoControlEscalaEadAudicionLenguage();
                    break;

                case "CONTROLEADMOTRICIFINOADAPT":
                    lobObjeto = fobjAddObjetoControlEscalaEadMotriFinoAdaptativa();
                    break;

                case "CONTROLEADMOTRICIGRUESA":
                    lobObjeto = fobjAddObjetoControlEscalaEadMotricidadGruesa();
                    break;

                case "CONTROLEADPERSONALSOCIAL":
                    lobObjeto = fobjAddObjetoControlEscalaEadPersonalSocial();
                    break;

                case "CONTROLEADGRAFPUNTUACION":
                    lobObjeto = fobjAddObjetoControlVistaEscalaEadPuntuacion();
                    break;

                case "CONTROLFIRMAPROFESIONAL":
                    lobObjeto = fobjAddObjetoControlFirmaProfesional();
                    break;

                case "CONTROLHOJAADMISION":
                    lobObjeto = fobjAddObjetoControlHojaAdmision();
                    break;

                case "CONTROLADMITIDO":
                    lobObjeto = fobjAddObjetoControlVistaAdmitido();
                    break;

                case "CONTROLTRIAGE":
                    lobObjeto = fobjAddObjetoControlVistaTriage();
                    break;

                case "CONTROLUSUATENDIDO":
                    lobObjeto = fobjAddObjetoControlUsuarioAtendido();
                    break;

                case "CONTROLCAPTURA":
                    lobObjeto = fobjAddObjetoControlCaptura();
                    break;

                case "TEXTBOXRELCOD":
                    lobObjeto = fobjAddObjetoTextBox();
                    break;

                case "TEXTBOXRELDES":
                    lobObjeto = fobjAddObjetoTextBox();
                    break;
                    
                case "MULTIGROUPCHKBOX":
                    lobObjeto = fobjAddObjetoGroupBox();
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    lobObjeto = fobjAddObjetoGroupBox();
                    break;

                case "MULTICHKBOX":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto != "V")
                    {
                        lobObjeto = fobjAddObjetoCheckBox();
                    }
                    else
                    {
                        lobObjeto = fobjAddObjetoChkrButton("CHK");
                    }
                    break;

                case "MULTIRADIOBUTTON":
                    lcrModoVsitaObjeto = fcrModoVisualizarObjeto(refRegObjActivo);
                    if (lcrModoVsitaObjeto != "V")
                    {
                        lobObjeto = fobjAddObjetoRadioButton();
                    }
                    else
                    {
                        lobObjeto = fobjAddObjetoChkrButton("RBT");
                    }
                    break;

                case "IMAGEN":
                    lobObjeto = fobjAddObjetoImage();
                    break;

                case "RECTANGULO":
                    lobObjeto = fobjAddObjetoRectangle();
                    break;

                case "ELIPSE":
                    lobObjeto = fobjAddObjetoEllipse();
                    break;

                case "POLYLINE":
                    break;

                case "POLYGON":
                    break;

                case "LINEA-VERTICAL":
                    lobObjeto = fobjAddObjetoLineaVertical();
                    break;

                case "LINEA-HORIZONTAL":
                    lobObjeto = fobjAddObjetoLineaHorizontal();
                    break;

                case "LINEA-DERECHA":
                    lobObjeto = fobjAddObjetoLineaDerecha();
                    break;

                case "LINEA-IZQUIERDA":
                    lobObjeto = fobjAddObjetoLineaIzquierda();
                    break;

                case "FLECHA-DERECHA":
                    lobObjeto = fobjAddObjetoFlechaDerecha();
                    break;

                case "FLECHA-IZQUIERDA":
                    lobObjeto = fobjAddObjetoFlechaIzquierda();
                    break;

                case "FLECHA-ARRIBA":
                    lobObjeto = fobjAddObjetoFlechaArriba();
                    break;

                case "FLECHA-ABAJO":
                    lobObjeto = fobjAddObjetoFlechaAbajo();
                    break;
            }
            #endregion
            return lobObjeto;
        }
        #endregion
        #region fcrModoVisualizarObjeto: Define el modo visualizacion del objeto
        /// <summary>
        /// <para>Define el modo visualizacion del objeto, segun la propiedad multisesion y si ya esta diligenciado el dato y</para>
        /// <para>segun el modo D=Diseño,V=Vista,E=Edicion captura del formulario, G=Gestion con objetos multisession</para>
        /// </summary>
        public String fcrModoVisualizarObjeto(ClassXmlPropObjeto toRegObjeto)
        {
            var lcrModoVista = gcrDatosModoVista;

            if (gcrDatosModoVista != "D" && toRegObjeto.SiMultiSet == "True") // diferente del modo diseño
            {
                gcrDatosModoGestion = "G";
                var lobReg = fobRegSelectValorDigitadoObjeto(toRegObjeto.Name);

                /* VER EL ERROR EN PANTALLA */
                if (lobReg != null)
                {
                    //MessageBox.Show("error fcrModoVisualizarObjeto: " + toRegObjeto.Name);
                    if (lcrModoVista == "V" && String.IsNullOrWhiteSpace(lobReg.Valor))
                    {
                        lcrModoVista = "E";
                    }
                }
                else
                {
                    lcrModoVista = "E";
                }
            }

            return lcrModoVista;
        }
        #endregion
        #region fnuDefineNivelObjeto: Define el nivel del objeto dentro del tree
        /// <summary>
        /// <para>Define el nivel del objeto dentro del tree</para>
        /// </summary>
        public int fnuDefineNivelObjeto(ClassXmlPropObjeto toRegObjeto)
        {
            int lnuNivel = 3;
            if (toRegObjeto.TipoObjeto == "MULTIGROUPCHKBOX" ||
                toRegObjeto.TipoObjeto == "TEXTBOXREL" ||
                toRegObjeto.TipoObjeto == "MULTIGROUPRADIOBUTTON" ||
                toRegObjeto.TipoObjeto == "GROUPBOX")
            {
                lnuNivel = 4;
            }
            else
            {
                lnuNivel = 3;
            }
            return lnuNivel;
        }
        #endregion
        #region fcvMinimoWithPlantilla: Establecer el valor minimo de ancho de la plantilla
        /// <summary>
        /// <para>Establecer el valor minimo de ancho de la plantilla</para>
        /// </summary>
        public void fcvMinimoWithPlantilla(String tcrWidth)
        {
            if (!String.IsNullOrWhiteSpace(tcrWidth))
            {
                var lduValor = Convert.ToDouble(tcrWidth);
                gduMinimoAnchoPlantilla = (lduValor > gduMinimoAnchoPlantilla) ? lduValor : gduMinimoAnchoPlantilla;
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // LEER ATRIBUTOS DE PLANTILLA PAGINAS Y OTROS DESDE XML
        //------------------------------------------------------------
        #region Leer Atributos desde XML
        #region fobLeerXmlAttributosPlantilla: leer los atributos porpiedad de la pantilla
        /// <summary>
        /// <para>Leer los atributos porpiedad de la pantilla</para>
        /// </summary>
        public static XmlPropPlantilla fobLeerXmlAttributosPlantilla(XmlNode tobNodoObjeto)
        {
            XmlPropPlantilla lobClassObjeto = new XmlPropPlantilla();
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

                    case "HL7Formato":
                        lobClassObjeto.HL7Formato = lobAttrColl[i].Value;
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

                    case "VistaEnMuroHc":
                        lobClassObjeto.VistaEnMuroHc = lobAttrColl[i].Value;
                        break;

                    case "ImagenIcono":
                        lobClassObjeto.ImagenIcono = lobAttrColl[i].Value;
                        break;

                    case "PlantTipoImpresion":
                        lobClassObjeto.PlantTipoImpresion = lobAttrColl[i].Value;
                        break;

                    case "PlantTituloReporte":
                        lobClassObjeto.PlantTituloReporte = lobAttrColl[i].Value;
                        break;

                    case "PlantTipoHojaReporte":
                        lobClassObjeto.PlantTipoHojaReporte = !String.IsNullOrWhiteSpace(lobAttrColl[i].Value) ? lobAttrColl[i].Value : "01";
                        break;

                    case "GenerObjPagina":
                        lobClassObjeto.GenerObjPagina = lobAttrColl[i].Value;
                        break;

                    case "GenerSecObjeto":
                        lobClassObjeto.GenerSecObjeto = lobAttrColl[i].Value;
                        break;

                    case "PlantillaWidth":
                        lobClassObjeto.PlantillaWidth = lobAttrColl[i].Value;
                        break;

                    case "PlantillaHeight":
                        lobClassObjeto.PlantillaHeight = lobAttrColl[i].Value;
                        break;

                    case "MargenVertical":
                        lobClassObjeto.MargenVertical = lobAttrColl[i].Value;
                        break;

                    case "MargenHorizontal":
                        lobClassObjeto.MargenHorizontal = lobAttrColl[i].Value;
                        break;

                    case "PlantillaBackground":
                        lobClassObjeto.PlantillaBackground = lobAttrColl[i].Value;
                        break;

                    case "PrefijoObjetos":
                        lobClassObjeto.PrefijoObjetos = lobAttrColl[i].Value;
                        break;

                    case "EstiloModoDis":
                        lobClassObjeto.EstiloModoDis = lobAttrColl[i].Value;
                        break;

                    case "EstiloModoEdt":
                        lobClassObjeto.EstiloModoEdt = lobAttrColl[i].Value;
                        break;

                    case "EstiloModoVis":
                        lobClassObjeto.EstiloModoVis = lobAttrColl[i].Value;
                        break;

                    case "ImagenFondoCodigo":
                        lobClassObjeto.ImagenFondoCodigo = lobAttrColl[i].Value;
                        break;

                    case "ImagenFondoUri":
                        lobClassObjeto.ImagenFondoUri = lobAttrColl[i].Value;
                        break;

                    case "ImagenFondoNombre":
                        lobClassObjeto.ImagenFondoNombre = lobAttrColl[i].Value;
                        break;

                    case "SeparadorDecimal":
                        lobClassObjeto.SeparadorDecimal = lobAttrColl[i].Value;
                        break;

                }
                #endregion
            }
            // acciones adicionales
            lobClassObjeto.PlantTipoHojaReporte = !String.IsNullOrWhiteSpace(lobClassObjeto.PlantTipoHojaReporte) ? lobClassObjeto.PlantTipoHojaReporte : "01";

            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosSecciones: leer los atributos Secciones del formato
        /// <summary>
        /// <para>leer los atributos Secciones del formato</para>
        /// </summary>
        public static ClassXmlComboBoxItems fobLeerXmlAttributosSecciones(XmlNode tobNodoObjeto)
        {
            ClassXmlComboBoxItems lobClassObjeto = new ClassXmlComboBoxItems();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "Indice":
                        lobClassObjeto.Indice = lobAttrColl[i].Value;
                        lobClassObjeto.IntIndice = Convert.ToInt32(lobAttrColl[i].Value);
                        break;

                    case "Codigo":
                        lobClassObjeto.Codigo = lobAttrColl[i].Value;
                        break;

                    case "Orden":
                        lobClassObjeto.IntOrden = Convert.ToInt32(lobAttrColl[i].Value);
                        break;

                    case "Columnas":
                        lobClassObjeto.IntTotalColumnas = Convert.ToInt32(lobAttrColl[i].Value);
                        break;

                    case "Descripcion":
                        lobClassObjeto.Descripcion = lobAttrColl[i].Value;
                        break;
                }
                lobClassObjeto.IntTotalColumnas = lobClassObjeto.IntTotalColumnas == 0 ? 1 : lobClassObjeto.IntTotalColumnas; 
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosEtiquetas: leer los atributos porpiedad de etiquetas
        /// <summary>
        /// <para>fobLeerXmlAttributosEtiquetas: leer los atributos porpiedad de etiquetas</para>
        /// </summary>
        public static ClassXmlItemEtiquetas fobLeerXmlAttributosEtiquetas(XmlNode tobNodoObjeto)
        {
            ClassXmlItemEtiquetas lobClassObjeto = new ClassXmlItemEtiquetas();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "Indice":
                        lobClassObjeto.Indice = lobAttrColl[i].Value;
                        break;

                    case "Codigo":
                        lobClassObjeto.Codigo = lobAttrColl[i].Value;
                        break;

                    case "Icono":
                        lobClassObjeto.Icono = lobAttrColl[i].Value;
                        break;
                    case "Version":
                        lobClassObjeto.Version = lobAttrColl[i].Value;
                        break;
                        
                    case "Descripcion":
                        lobClassObjeto.Descripcion = lobAttrColl[i].Value;
                        break;

                    case "Archivo":
                        lobClassObjeto.Archivo = lobAttrColl[i].Value;
                        break;
                }
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosImgPredefinidas: leer los atributos imagenes predefinidas
        /// <summary>
        /// <para>leer los atributos imagenes predefinidas</para>
        /// </summary>
        public static ClassXmlImgPredefinidas fobLeerXmlAttributosImgPredefinidas(XmlNode tobNodoObjeto)
        {
            ClassXmlImgPredefinidas lobClassObjeto = new ClassXmlImgPredefinidas();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "Codigo":
                        lobClassObjeto.Codigo = lobAttrColl[i].Value;
                        break;

                    case "TipoObjeto":
                        lobClassObjeto.TipoObjeto = lobAttrColl[i].Value;
                        break;
                    case "ClaseBase":
                        lobClassObjeto.ClaseBase = lobAttrColl[i].Value;
                        break;

                    case "Titulo":
                        lobClassObjeto.Titulo = lobAttrColl[i].Value;
                        break;

                    case "ImagenWidth":
                        lobClassObjeto.ImagenWidth = lobAttrColl[i].Value;
                        break;

                    case "ImagenHeight":
                        lobClassObjeto.ImagenHeight = lobAttrColl[i].Value;
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
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosObjeto: leer los atributos de propiedad de un Nodo Objeto
        /// <summary>
        /// <para>fobLeerXmlAttributosObjeto: leer los atributos Propiedad de un Nodo Objeto</para>
        /// <para>Devuelve un registro tipo ClassXmlPropObjeto con todas las propiedades cargadas.</para>
        /// </summary>
        public static ClassXmlPropObjeto fobLeerXmlAttributosObjeto(XmlNode tobNodoObjeto)
        {
            ClassXmlPropObjeto lobClassObjeto = new ClassXmlPropObjeto();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;
            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                #region Propiedades
                switch (lobAttrColl[i].Name)
                {
                    case "Name":
                        lobClassObjeto.Name = lobAttrColl[i].Value;
                        break;

                    case "NameContenedor":
                        lobClassObjeto.NameContenedor = lobAttrColl[i].Value;
                        break;

                    case "Titulo":
                        lobClassObjeto.Titulo = lobAttrColl[i].Value;
                        break;

                    case "ToolTip":
                        lobClassObjeto.ToolTip = lobAttrColl[i].Value;
                        break;

                    case "TituloVisible":
                        lobClassObjeto.TituloVisible = lobAttrColl[i].Value;
                        break;

                    case "TipoObjeto":
                        lobClassObjeto.TipoObjeto = lobAttrColl[i].Value;
                        break;

                    case "ClaseBase":
                        lobClassObjeto.ClaseBase = lobAttrColl[i].Value;
                        break;

                    case "TipoControl":
                        lobClassObjeto.TipoControl = lobAttrColl[i].Value;
                        break;

                    case "OrdenVista":
                        lobClassObjeto.OrdenVista = lobAttrColl[i].Value;
                        break;

                    case "SeccionCodigo":
                        lobClassObjeto.SeccionCodigo = lobAttrColl[i].Value;
                        break;
                        
                    case "Parent":
                        lobClassObjeto.Parent = lobAttrColl[i].Value;
                        break;

                    case "TabIndex":
                        lobClassObjeto.TabIndex = lobAttrColl[i].Value;
                        break;

                    case "CampoReporte":
                        lobClassObjeto.CampoReporte = lobAttrColl[i].Value;
                        break;

                    case "Pagina":
                        lobClassObjeto.Pagina = lobAttrColl[i].Value;
                        break;

                    case "CambiarTabs":
                        lobClassObjeto.CambiarTabs = lobAttrColl[i].Value;
                        break;

                    case "Focusable":
                        lobClassObjeto.Focusable = lobAttrColl[i].Value;
                        break;

                    case "IsEnabled":
                        lobClassObjeto.IsEnabled = lobAttrColl[i].Value;
                        break;

                    case "Visibility":
                        lobClassObjeto.Visibility = lobAttrColl[i].Value;
                        break;

                    case "VerticalAlignment":
                        lobClassObjeto.VerticalAlignment = lobAttrColl[i].Value;
                        break;

                    case "HorizontalAlignment":
                        lobClassObjeto.HorizontalAlignment = lobAttrColl[i].Value;
                        break;

                    case "Style":
                        lobClassObjeto.Style = lobAttrColl[i].Value;
                        break;

                    case "Margin":
                        lobClassObjeto.Margin = lobAttrColl[i].Value;
                        break;

                    case "Border":
                        lobClassObjeto.Border = lobAttrColl[i].Value;
                        break;

                    case "Foreground":
                        lobClassObjeto.Foreground = lobAttrColl[i].Value;
                        break;

                    case "BorderBrush":
                        lobClassObjeto.BorderBrush = lobAttrColl[i].Value;
                        break;

                    case "Background":
                        lobClassObjeto.Background = lobAttrColl[i].Value;
                        break;

                    case "Height":
                        lobClassObjeto.Height = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "Width":
                        lobClassObjeto.Width = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "Top":
                        lobClassObjeto.Top = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "Left":
                        lobClassObjeto.Left = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "FontFamily":
                        lobClassObjeto.FontFamily = lobAttrColl[i].Value;
                        break;

                    case "FontStyle":
                        lobClassObjeto.FontStyle = lobAttrColl[i].Value;
                        break;

                    case "FontWeight":
                        lobClassObjeto.FontWeight = lobAttrColl[i].Value;
                        break;

                    case "Decorations":
                        lobClassObjeto.Decorations = lobAttrColl[i].Value;
                        break;

                    case "FontSize":
                        lobClassObjeto.FontSize = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "AlineacionTexto":
                        lobClassObjeto.AlineacionTexto = lobAttrColl[i].Value;
                        break;

                    case "Orientacion":
                        lobClassObjeto.Orientacion = lobAttrColl[i].Value;
                        break;

                    case "Angulo":
                        lobClassObjeto.Angulo = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "Binding":
                        lobClassObjeto.Binding = lobAttrColl[i].Value;
                        break;

                    case "BindingDescripcion":
                        lobClassObjeto.BindingDescripcion = lobAttrColl[i].Value;
                        break;

                    case "BindingTabla":
                        lobClassObjeto.BindingTabla = lobAttrColl[i].Value;
                        break;
                        
                    case "ValorDefault":
                        lobClassObjeto.ValorDefault = lobAttrColl[i].Value;
                        break;

                    case "Indice":
                        lobClassObjeto.Indice = lobAttrColl[i].Value;
                        break;

                    case "TotalItems":
                        lobClassObjeto.TotalItems = lobAttrColl[i].Value;
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

                    case "CodigoEtiqueta":
                        lobClassObjeto.CodigoEtiqueta = lobAttrColl[i].Value;
                        break;

                    case "RangoInicial":
                        lobClassObjeto.RangoInicial = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "RangoFinal":
                        lobClassObjeto.RangoFinal = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "IsRequerido":
                        lobClassObjeto.IsRequerido = lobAttrColl[i].Value;
                        break;

                    case "FechaDefault":
                        lobClassObjeto.FechaDefault = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "HoraDefault":
                        lobClassObjeto.HoraDefault = fcrConfigRegionalNumero(lobAttrColl[i].Value);
                        break;

                    case "SiMultiSet":
                        lobClassObjeto.SiMultiSet = lobAttrColl[i].Value;
                        break;

                    case "IsReadOnly":
                        lobClassObjeto.IsReadOnly = lobAttrColl[i].Value;
                        break;

                    case "PrnSiValidar":
                        lobClassObjeto.PrnSiValidar = lobAttrColl[i].Value;
                        break;

                    case "PrnValorDefault":
                        lobClassObjeto.PrnValorDefault = lobAttrColl[i].Value;
                        break;

                    case "PrnValorPreView":
                        lobClassObjeto.PrnValorPreView = lobAttrColl[i].Value;
                        break;

                    case "PrnMostrarTitulo":
                        lobClassObjeto.PrnMostrarTitulo = lobAttrColl[i].Value;
                        break;
                        
                    case "RefVarDatosTipo":
                        lobClassObjeto.RefVarDatosTipo = lobAttrColl[i].Value;
                        break;

                    case "RefVarDatosCampo":
                        lobClassObjeto.RefVarDatosCampo = lobAttrColl[i].Value;
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

                    case "Stretch":
                        lobClassObjeto.Stretch = lobAttrColl[i].Value;
                        break;

                    case "SiValorCalculado":
                        lobClassObjeto.SiValorCalculado = lobAttrColl[i].Value;
                        break;

                    case "NombreVariable":
                        lobClassObjeto.NombreVariable = lobAttrColl[i].Value;
                        break;

                    case "VariablePublica":
                        lobClassObjeto.VariablePublica = lobAttrColl[i].Value;
                        break;

                    case "VarGestPosVector":
                        lobClassObjeto.VarGestPosVector = lobAttrColl[i].Value;
                        break;

                    case "SiMostrarEnMuro":
                        lobClassObjeto.SiMostrarEnMuro = lobAttrColl[i].Value;
                        break;

                    case "SiFiltroBusqueda":
                        lobClassObjeto.SiFiltroBusqueda = lobAttrColl[i].Value;
                        break;

                    case "SiImprimir":
                        lobClassObjeto.SiImprimir = lobAttrColl[i].Value;
                        break;

                    case "RadioButtonGroupName":
                        lobClassObjeto.RadioButtonGroupName = lobAttrColl[i].Value;
                        break;
                }
                #endregion
            }
            if (lobClassObjeto.ClaseBase == "TextBlock") 
            {
                lobClassObjeto.Titulo = tobNodoObjeto.InnerText.Trim();
            }
            lobClassObjeto.IntTabIndex = String.IsNullOrWhiteSpace(lobClassObjeto.TabIndex) ? 1 : Convert.ToInt32(lobClassObjeto.TabIndex);
            lobClassObjeto.IntIndexAux = String.IsNullOrWhiteSpace(lobClassObjeto.Indice) ? 1 : Convert.ToInt32(lobClassObjeto.Indice);
            lobClassObjeto.ObjetoParentPagina = "NA";
            lobClassObjeto.ObjetoParentZona = "NA";
            lobClassObjeto.ObjetoParentGrupo = "NA";

            lobClassObjeto.OrdenVista = String.IsNullOrWhiteSpace(lobClassObjeto.OrdenVista) ? "0" : lobClassObjeto.OrdenVista;
            lobClassObjeto.SeccionCodigo = String.IsNullOrWhiteSpace(lobClassObjeto.SeccionCodigo) ? "01" : lobClassObjeto.SeccionCodigo;

            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosCamposRelacion: Leer los atributos campos relacion
        /// <summary>
        /// <para>Leer los atributos campos relacion</para>
        /// </summary>
        public static ClassXmlCamposRelacion fobLeerXmlAttributosCamposRelacion(XmlNode tobNodoObjeto)
        {
            ClassXmlCamposRelacion lobClassObjeto = new ClassXmlCamposRelacion();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "Name":
                        lobClassObjeto.Name = lobAttrColl[i].Value;
                        break;

                    case "Parent":
                        lobClassObjeto.Parent = lobAttrColl[i].Value;
                        break;

                    case "Tipo":
                        lobClassObjeto.Tipo = lobAttrColl[i].Value;
                        break;

                    case "Ancho":
                        lobClassObjeto.Ancho = lobAttrColl[i].Value;
                        break;

                    case "NameCampoDE":
                        lobClassObjeto.NameCampoDE = lobAttrColl[i].Value;
                        break;

                    case "ObjetoBinding":
                        lobClassObjeto.ObjetoBinding = lobAttrColl[i].Value;
                        break;
                }
            }
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosComboItems: Leer los atributos items de ComboBox
        /// <summary>
        /// <para>Leer los atributos items de ComboBox</para>
        /// </summary>
        public static ClassXmlComboBoxItems fobLeerXmlAttributosComboItems(XmlNode tobNodoObjeto)
        {
            ClassXmlComboBoxItems lobClassObjeto = new ClassXmlComboBoxItems();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "Parent":
                        lobClassObjeto.Parent = lobAttrColl[i].Value;
                        break;

                    case "Indice":
                        lobClassObjeto.Indice = lobAttrColl[i].Value;
                        break;

                    case "Codigo":
                        lobClassObjeto.Codigo = lobAttrColl[i].Value;
                        break;

                    case "Descripcion":
                        lobClassObjeto.Descripcion = lobAttrColl[i].Value;
                        break;
                }
            }
            lobClassObjeto.IntIndice = Convert.ToInt32(lobClassObjeto.Indice);
            return lobClassObjeto;
        }
        #endregion
        #region fobLeerXmlAttributosObjetosRelacion: Leer los atributos items de ComboBox
        /// <summary>
        /// <para>Leer los atributos items de ComboBox</para>
        /// </summary>
        public static ClassXmlObjetosRelacion fobLeerXmlAttributosObjetosRelacion(XmlNode tobNodoObjeto)
        {
            ClassXmlObjetosRelacion lobClassObjeto = new ClassXmlObjetosRelacion();
            XmlAttributeCollection lobAttrColl = tobNodoObjeto.Attributes;

            for (int i = 0; i < lobAttrColl.Count; i++)
            {
                switch (lobAttrColl[i].Name)
                {
                    case "RelacionPagina":
                        lobClassObjeto.RelacionPagina = lobAttrColl[i].Value;
                        break;

                    case "RelacionZona":
                        lobClassObjeto.RelacionZona = lobAttrColl[i].Value;
                        break;

                    case "RelacionObjeto":
                        lobClassObjeto.RelacionObjeto = lobAttrColl[i].Value;
                        break;

                    case "NameObjeto":
                        lobClassObjeto.NameObjeto = lobAttrColl[i].Value;
                        break;
                }
            }
            return lobClassObjeto;
        }
        #endregion
        #region fcrConfigRegionalNumero: Reemplazar separador decimal
        /// <summary>
        /// <para>Reemplazar separador decimal de la plantilla por</para>
        /// <para>el separador de configuracion regional</para>
        /// </summary>
        public static String fcrConfigRegionalNumero(String tcrValor)
        {
            return tcrValor.Replace(gcrPlantillaSeparadorDecimal, gcrSysSeparadorDecimal);
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        //- CARGAR PLANTILLA PAGINAS ZONAS Y OBJETOS DESDE TEMPORALES
        //------------------------------------------------------------
        #region Cargar Plantillas Pagians y otros desde Temporales
        #region fcvGenerarObjetoIniciar: Inicia proceso generar objetos desde temporales
        /// <summary>
        /// <para>Inicia proceso generar objetos desde temporales</para>
        /// </summary>
        public void fcvGenerarObjetoIniciar(String tcrArchivoOrigen, ClassXmlPropObjeto tobObjeto)
        {
            fcvGenerarObjetoTreeReferencia(tcrArchivoOrigen, tobObjeto);
            switch (tobObjeto.ObjetoNivel)
            {
                case 1:
                    fcvGenerarObjetoPaginas(tcrArchivoOrigen, tobObjeto.Name);
                    break;

                case 2:
                    fcvGenerarObjetoZona(tcrArchivoOrigen, "", tobObjeto.Name);
                    break;

                case 3:
                    fcvGenerarObjetoEnZonas(tcrArchivoOrigen, "", tobObjeto.Name);
                    break;

                case 4:
                    fcvGenerarObjetoEnZonas(tcrArchivoOrigen, "", tobObjeto.Name);
                    break;

                case 5:
                    fcvGenerarObjetoEnZonas(tcrArchivoOrigen, "", tobObjeto.Name);
                    break;
            }
        }
        #endregion
        #region fcvGenerarObjetoPaginas: Cargar Paginas desde temporales
        /// <summary>
        /// <para>Cargar Paginas desde temporales</para>
        /// <para>cuando tcrNombreObjeto es vacio, se cargan todas las pagians desde el temporal</para>
        /// <para>dado en parametro tcrArchivoOrigen</para>
        /// </summary>
        public void fcvGenerarObjetoPaginas(String tcrArchivoOrigen, String tcrPagina)
        {
            var lcrParent = String.IsNullOrWhiteSpace(tcrPagina) ? "PAGINA" : String.Empty;
            List<ClassXmlPropObjeto> tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, lcrParent, tcrPagina);

            foreach (ClassXmlPropObjeto lobjRegistro in tobTemp)
            {
                //-Establecer datos para gestion
                refRegObjActivo = lobjRegistro;
                lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                fcvGenerarObjetoZona(tcrArchivoOrigen, tcrPagina, "");
            }
        }
        #endregion
        #region fcvGenerarObjetoZona: Cargar Zonas desde temporales
        /// <summary>
        /// <para>Cargar Zonas desde temporales</para>
        /// </summary>
        public void fcvGenerarObjetoZona(String tcrArchivoOrigen, String tcrPagina, String tcrZona)
        {
            List<ClassXmlPropObjeto> tobTemp = null;
            if (!String.IsNullOrWhiteSpace(tcrPagina))
            {
                tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PARENT", tcrPagina);
            }
            else
            {
                tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "", tcrZona); // Solo un objeto tipo Zona
            }
            foreach (ClassXmlPropObjeto lobjRegistro in tobTemp)
            {
                if (lobjRegistro.TipoObjeto == "ZONA")
                {
                    refRegObjActivo = lobjRegistro;
                    lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                    fcvGenerarObjetoEnZonas(tcrArchivoOrigen, lobjRegistro.Name, "");
                }
            }
        }
        #endregion
        #region fcvGenerarObjetoEnZonas: Cargar objetos de Zonas desde temporales
        /// <summary>
        /// <para>Cargar objetos de Zonas desde temporal</para>
        /// </summary>
        public void fcvGenerarObjetoEnZonas(String tcrArchivoOrigen, String tcrZona, String tcrObjeto)
        {
            List<ClassXmlPropObjeto> tobTemp = null;
            if (!String.IsNullOrWhiteSpace(tcrZona))
            {
                tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "PARENT", tcrZona);
            }
            else
            {
                tobTemp = fobRegSelectParenObjeto(tcrArchivoOrigen, "", tcrObjeto); // Solo un objeto tipo 
            }
            foreach (ClassXmlPropObjeto lobjRegistro in tobTemp)
            {
                refRegObjActivo = lobjRegistro;
                lobjRegistro.RefObjeto = fobRegCargarXMLGenerarObjeto();
                // Tipos objetos que tienen lista de items u objetos
                switch (lobjRegistro.TipoObjeto)
                {
                    case "GROUPBOX":
                        fcvGenerarObjetoEnZonas(tcrArchivoOrigen, lobjRegistro.Name, "");
                        break;

                    case "TEXTBOXREL":
                        fcvGenerarObjetoEnZonas(tcrArchivoOrigen, lobjRegistro.Name, "");
                        break;

                    case "MULTIGROUPCHKBOX":
                        fcvGenerarObjetoEnZonas(tcrArchivoOrigen, lobjRegistro.Name, "");
                        break;

                    case "MULTIGROUPRADIOBUTTON":
                        fcvGenerarObjetoEnZonas(tcrArchivoOrigen, lobjRegistro.Name, "");
                        break;
                }
            }
        }
        #endregion
        #region fcvGenerarObjetoTreeReferencia: Generar referencias Tree para objetos
        /// <summary>
        /// <para>Generar las referencias en la clase Tree requerida para generar objetos</para>
        /// </summary>
        public void fcvGenerarObjetoTreeReferencia(String tcrArchivoOrigen, ClassXmlPropObjeto tobObjeto)
        {
            refTreeObj.Plantilla         = null;
            refTreeObj.Pagina            = null;
            refTreeObj.ContenedorPagina  = null;
            refTreeObj.Zona              = null;
            refTreeObj.ContenedorZona    = null;
            refTreeObj.Grupo             = null;
            refTreeObj.ContenedorGrupo   = null;
            refTreeObj.NivelObjetoSelect = 0;
            refTreeObj.Navegador         = tobObjeto.Navegador;
            refTreeObj.CodigoPlantilla   = tobObjeto.CodigoPlantilla;

            switch (tobObjeto.ObjetoNivel)
            {
                case 1:         // Es una pagina Generar refrencia nivel Plantilla 
                    if (tobObjeto.Navegador == "ESCRITORIO")
                    {
                        refTreeObj.Plantilla = gobRefPlantillaEscritorio;
                        refTreeObj.NivelObjetoSelect = 1;
                        refTreeObj.Navegador = "ESCRITORIO";
                    }
                    else
                    {
                        refTreeObj.Plantilla = gobRefPlantillaEtiqueta;
                        refTreeObj.NivelObjetoSelect = 1;
                        refTreeObj.Navegador = "ETIQUETA";
                    }
                    //-Referencia a objetos
                    break;
                case 2:         // Es una Zona Generar refrencia nivel pagina
                    WrapPanel lobContPagina = fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Parent).FirstOrDefault().RefContenedorObjeto as WrapPanel;

                    refTreeObj.Pagina = lobContPagina.Parent as Canvas;
                    refTreeObj.ContenedorPagina = lobContPagina;
                    refTreeObj.NivelObjetoSelect = 2;
                    //-Referencia a objetos
                    break;

                case 3:         // Es un objeto dentro de Zona  generar referencia nivel zona
                    Canvas lobContZona = fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Parent).FirstOrDefault().RefContenedorObjeto as Canvas;

                    refTreeObj.Zona = lobContZona.Parent as GroupBox;
                    refTreeObj.ContenedorZona = lobContZona;
                    refTreeObj.NivelObjetoSelect = 3;
                    break;

                case 4:         // Es un objeto grupo en Zona  generar referencia nivel zona
                    Canvas lobContZona1 = fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Parent).FirstOrDefault().RefContenedorObjeto as Canvas;

                    refTreeObj.Zona = lobContZona1.Parent as GroupBox;
                    refTreeObj.ContenedorZona = lobContZona1;
                    refTreeObj.NivelObjetoSelect = 4;
                    break;

                case 5:         // Es un objeto dentro de grupo generar referencia nivel grupo
                    Canvas lobContGrupo = fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Parent).FirstOrDefault().RefContenedorObjeto as Canvas;

                    refTreeObj.Grupo = lobContGrupo.Parent as GroupBox;
                    refTreeObj.ContenedorGrupo = lobContGrupo;
                    refTreeObj.NivelObjetoSelect = 5;
                    break;
            }
        }
        #endregion
        #region fcvGenerarObjetoAsigValorRegistro: Asignar nuevos valores a registro
        /// <summary>
        /// <para>Asignar nuevos valores a registro</para>
        /// </summary>
        public ClassXmlPropObjeto fobGenerarObjetoAsigValorRegistro(ClassXmlPropObjeto tobObjeto)
        {
            var lobObjeto = new ClassXmlPropObjeto();
            if (tobObjeto!= null)
            {
                #region Clase
                // Referencias a objeto (son Propiedades para manejo interno)
                lobObjeto.RefObjeto = tobObjeto.RefObjeto;
                lobObjeto.RefContenedorObjeto = tobObjeto.RefContenedorObjeto;
                lobObjeto.IntTabIndex = tobObjeto.IntTabIndex;
                lobObjeto.IntIndexAux = tobObjeto.IntIndexAux;
                //- Para las acciones de deshacer y rehacer
                lobObjeto.Accion = tobObjeto.Accion;
                lobObjeto.IdAccion = tobObjeto.IdAccion;
                // Propiedades Básicas
                #region Propiedades Básicas
                lobObjeto.Name = tobObjeto.Name;
                lobObjeto.NameContenedor = tobObjeto.NameContenedor;
                lobObjeto.Titulo = tobObjeto.Titulo;
                lobObjeto.ToolTip = tobObjeto.ToolTip;
                lobObjeto.TituloVisible = tobObjeto.TituloVisible;
                lobObjeto.TipoObjeto = tobObjeto.TipoObjeto;
                lobObjeto.ClaseBase = tobObjeto.ClaseBase;
                lobObjeto.TipoControl = tobObjeto.TipoControl;
                lobObjeto.OrdenVista = tobObjeto.OrdenVista;
                lobObjeto.SeccionCodigo = tobObjeto.SeccionCodigo;
                lobObjeto.Parent = tobObjeto.Parent;
                lobObjeto.TabIndex = tobObjeto.TabIndex;
                lobObjeto.Pagina = tobObjeto.Pagina;
                lobObjeto.CambiarTabs = tobObjeto.CambiarTabs;
                lobObjeto.Focusable = tobObjeto.Focusable;
                lobObjeto.IsEnabled = tobObjeto.IsEnabled;
                lobObjeto.Visibility = tobObjeto.Visibility;
                #endregion
                // Propiedades Apariencia
                #region Propiedades Apariencia
                lobObjeto.VerticalAlignment = tobObjeto.VerticalAlignment;
                lobObjeto.HorizontalAlignment = tobObjeto.HorizontalAlignment;
                lobObjeto.Style = tobObjeto.Style;
                lobObjeto.Margin = tobObjeto.Margin;
                lobObjeto.Border = tobObjeto.Border;
                lobObjeto.Foreground = tobObjeto.Foreground;
                lobObjeto.BorderBrush = tobObjeto.BorderBrush;
                lobObjeto.Background = tobObjeto.Background;
                lobObjeto.Height = tobObjeto.Height;
                lobObjeto.Width = tobObjeto.Width;
                lobObjeto.Top = tobObjeto.Top;
                lobObjeto.Left = tobObjeto.Left;
                lobObjeto.FontFamily = tobObjeto.FontFamily;
                lobObjeto.FontStyle = tobObjeto.FontStyle;
                lobObjeto.FontWeight = tobObjeto.FontWeight;
                lobObjeto.Decorations = tobObjeto.Decorations;
                lobObjeto.FontSize = tobObjeto.FontSize;
                lobObjeto.AlineacionTexto = tobObjeto.AlineacionTexto;
                lobObjeto.Orientacion = tobObjeto.Orientacion;
                lobObjeto.Angulo = tobObjeto.Angulo;
                #endregion
                // Propiedades Datos
                #region Propiedades Datos
                lobObjeto.Binding = tobObjeto.Binding;
                lobObjeto.BindingDescripcion = tobObjeto.BindingDescripcion;
                lobObjeto.BindingTabla = tobObjeto.BindingTabla;
                lobObjeto.ValorDefault = tobObjeto.ValorDefault;
                lobObjeto.Indice = tobObjeto.Indice;
                lobObjeto.TotalItems = tobObjeto.TotalItems;
                lobObjeto.CampoReporte = tobObjeto.CampoReporte;
                lobObjeto.TipoDato = tobObjeto.TipoDato;
                lobObjeto.VariablePublica = tobObjeto.VariablePublica;
                lobObjeto.TipoOrigenDatos = tobObjeto.TipoOrigenDatos;
                lobObjeto.TablaOrigen = tobObjeto.TablaOrigen;
                lobObjeto.CodigoEtiqueta = tobObjeto.CodigoEtiqueta;
                lobObjeto.RangoInicial = tobObjeto.RangoInicial;
                lobObjeto.RangoFinal = tobObjeto.RangoFinal;
                lobObjeto.IsRequerido = tobObjeto.IsRequerido;
                lobObjeto.FechaDefault = tobObjeto.FechaDefault;
                lobObjeto.HoraDefault = tobObjeto.HoraDefault;
                lobObjeto.SiMultiSet = tobObjeto.SiMultiSet;
                lobObjeto.IsReadOnly = tobObjeto.IsReadOnly;
                lobObjeto.RefVarDatosTipo = tobObjeto.RefVarDatosTipo;
                lobObjeto.RefVarDatosCampo = tobObjeto.RefVarDatosCampo;
                lobObjeto.PrnSiValidar = tobObjeto.PrnSiValidar;
                lobObjeto.PrnValorDefault = tobObjeto.PrnValorDefault;
                lobObjeto.PrnValorPreView = tobObjeto.PrnValorPreView;
                lobObjeto.PrnMostrarTitulo = tobObjeto.PrnMostrarTitulo;
                
                #endregion
                // Propiedades Imagen 
                #region Propiedades Imagen
                lobObjeto.RecursoArchivoTipo = tobObjeto.RecursoArchivoTipo;
                lobObjeto.RecursoArchivoCodigo = tobObjeto.RecursoArchivoCodigo;
                lobObjeto.RecursoArchivoUri = tobObjeto.RecursoArchivoUri;
                lobObjeto.RecursoArchivoNombre = tobObjeto.RecursoArchivoNombre;
                lobObjeto.Stretch = tobObjeto.Stretch;
                lobObjeto.StretchDirection = tobObjeto.StretchDirection;
                #endregion
                // Propiedades Varias
                #region Propiedades Varias
                lobObjeto.SiValorCalculado = tobObjeto.SiValorCalculado;
                lobObjeto.NombreVariable = tobObjeto.NombreVariable;
                lobObjeto.SiMostrarEnMuro = tobObjeto.SiMostrarEnMuro;
                lobObjeto.SiFiltroBusqueda = tobObjeto.SiFiltroBusqueda;
                lobObjeto.SiImprimir = tobObjeto.SiImprimir;
                // Propiedades solo para Radiobutton grupo
                lobObjeto.RadioButtonGroupName = tobObjeto.RadioButtonGroupName;
                // Control Nivel, Tree Objetos y Estado del objeto (solo para gestion interna)
                lobObjeto.Navegador = tobObjeto.Navegador;
                lobObjeto.CodigoPlantilla = tobObjeto.CodigoPlantilla;
                lobObjeto.ObjetoNivel = tobObjeto.ObjetoNivel;
                lobObjeto.ObjetoParentPagina = tobObjeto.ObjetoParentPagina;
                lobObjeto.ObjetoParentZona = tobObjeto.ObjetoParentZona;
                lobObjeto.ObjetoParentGrupo = tobObjeto.ObjetoParentGrupo;
                lobObjeto.ObjetoEstado = tobObjeto.ObjetoEstado;
                lobObjeto.ObjetoModo = tobObjeto.ObjetoModo;
                #endregion
                #endregion
            }
            return lobObjeto;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        //- GENERAR COMPONENTES TIPO TEXTO PARA GUARDAR ARCHIVO XML 
        //------------------------------------------------------------
        #region fcrGenerarTextoXmlPlantilla: Generar el texto completo de la plantilla
        /// <summary>
        /// <para>Generar el texto completo de la plantilla</para>
        /// </summary>
        public String fcrGenerarTextoXmlPlantilla()
        {
            String lcrPlantilla = String.Empty;
            String lcrPropiedades = fcrTextoXmlPropiedadPlantilla();
            String lcrSecciones = fcrTextoXmlSeccionesPlantilla();
            String lcrEtiquetas = fcrTextoXmlEtiquetasPlantilla();
            String lcrImgPredef = fcrTextoXmlImgPredefinidas();
            String lcrPaginas = fcrTextoXmlPaginasPlantilla();
            //Verificar que existan etiquetas
            lcrPropiedades = lcrPropiedades + "\n" + lcrEtiquetas + "\n" + lcrSecciones + "\n" + "\t</Propiedades>";

            lcrPlantilla = "<?xml version='1.0' encoding='utf-8'?>\n" +
                           "<General>\n" +
                                lcrPropiedades + "\n" +
                                "\t<Galeria>\n" +
                                lcrImgPredef +
                                "\t</Galeria>\n" +
                                "\t<Paginas>\n" +
                                lcrPaginas +
                                "\t</Paginas>\n" +
                           "</General>";
            return lcrPlantilla;
        }
        #endregion
        #region fcrTextoXmlPropiedadPlantilla: Generar propiedad de plantilla
        /// <summary>
        /// <para>Generar propiedad de plantilla desde registro temporal</para>
        /// </summary>
        public String fcrTextoXmlPropiedadPlantilla()
        {
            String lcrPlantilla = String.Empty;
            String lcrTabNivel2 = "\t";
            String lcrTabNivel3 = "\t\t\t\t";

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            lcrPlantilla = lcrTabNivel2 + "<Propiedades Codigo ='" + tmpPlantilla.FirstOrDefault().Codigo + "'\n" +
                           lcrTabNivel3 + " Name ='" + tmpPlantilla.FirstOrDefault().Name + "'\n" +
                           lcrTabNivel3 + " HL7Formato='" + tmpPlantilla.FirstOrDefault().HL7Formato + "'\n" +
                           lcrTabNivel3 + " VersionSistema='" + tmpPlantilla.FirstOrDefault().VersionSistema + "'\n" +
                           lcrTabNivel3 + " VersionPlantilla='" + tmpPlantilla.FirstOrDefault().VersionPlantilla + "'\n" +
                           lcrTabNivel3 + " Clave='" + tmpPlantilla.FirstOrDefault().Clave + "'\n" +
                           lcrTabNivel3 + " CodigoGrupo='" + tmpPlantilla.FirstOrDefault().CodigoGrupo + "'\n" +
                           lcrTabNivel3 + " TipoFormato='" + tmpPlantilla.FirstOrDefault().TipoFormato + "'\n" +
                           lcrTabNivel3 + " VistaEnMuroHc='" + tmpPlantilla.FirstOrDefault().VistaEnMuroHc + "'\n" +
                           lcrTabNivel3 + " ImagenIcono='" + tmpPlantilla.FirstOrDefault().ImagenIcono + "'\n" +
                           lcrTabNivel3 + " PlantTipoImpresion='" + tmpPlantilla.FirstOrDefault().PlantTipoImpresion + "'\n" +
                           lcrTabNivel3 + " PlantTituloReporte='" + tmpPlantilla.FirstOrDefault().PlantTituloReporte + "'\n" +
                           lcrTabNivel3 + " PlantTipoHojaReporte='" + tmpPlantilla.FirstOrDefault().PlantTipoHojaReporte + "'\n" +
                           lcrTabNivel3 + " GenerObjPagina='" + tmpPlantilla.FirstOrDefault().GenerObjPagina + "'\n" +
                           lcrTabNivel3 + " GenerSecObjeto='" + tmpPlantilla.FirstOrDefault().GenerSecObjeto + "'\n" +
                           lcrTabNivel3 + " PlantillaWidth='" + tmpPlantilla.FirstOrDefault().PlantillaWidth + "'\n" +
                           lcrTabNivel3 + " PlantillaHeight='" + tmpPlantilla.FirstOrDefault().PlantillaHeight + "'\n" +
                           lcrTabNivel3 + " MargenVertical='" + tmpPlantilla.FirstOrDefault().MargenVertical + "'\n" +
                           lcrTabNivel3 + " MargenHorizontal='" + tmpPlantilla.FirstOrDefault().MargenHorizontal + "'\n" +
                           lcrTabNivel3 + " PrefijoObjetos='" + tmpPlantilla.FirstOrDefault().PrefijoObjetos + "'\n" +
                           lcrTabNivel3 + " EstiloModoDis='" + tmpPlantilla.FirstOrDefault().EstiloModoDis + "'\n" +
                           lcrTabNivel3 + " EstiloModoEdt='" + tmpPlantilla.FirstOrDefault().EstiloModoEdt + "'\n" +
                           lcrTabNivel3 + " EstiloModoVis='" + tmpPlantilla.FirstOrDefault().EstiloModoVis + "'\n" +
                           lcrTabNivel3 + " SeparadorDecimal='" + gcrSysSeparadorDecimal + "'>\n";

            return lcrPlantilla;

        }
        #endregion
        #region fcrTextoXmlSeccionesPlantilla: Generar lista de secciones de la plantilla
        /// <summary>
        /// <para>Generar lista de secciones de la plantilla</para>
        /// </summary>
        public String fcrTextoXmlSeccionesPlantilla()
        {
            String lcrEtiqueta = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t";
            String lcrFinLinea = "\n";
            int lnuContador = 0;

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in tmpSecciones)
            {
                lnuContador++;
                if (lnuContador >= tmpSecciones.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += lcrTabNivel3 + "<Item Indice='" + lobItem.Indice + "'" +
                                              " Codigo='" + lobItem.Codigo + "'" +
                                              " Orden='" + Convert.ToInt32(lobItem.IntOrden) + "'" +
                                              " Columnas='" + Convert.ToInt32(lobItem.IntTotalColumnas) + "'" +
                                              " Descripcion='" + lobItem.Descripcion + "'/>" + lcrFinLinea;
            }
            lcrEtiqueta = lcrTabNivel2 + "<Secciones>" + (String.IsNullOrWhiteSpace(lcrListItem) ?
                                                          "</Secciones>" : "\n" + lcrListItem + "\n" + lcrTabNivel2 + "</Secciones>");
            return lcrEtiqueta;
        }
        #endregion
        #region fcrTextoXmlEtiquetasPlantilla: Generar lista de etiquetas inteligentes de la plantilla
        /// <summary>
        /// <para>Generar lista de etiquetas inteligentes de la plantilla</para>
        /// </summary>
        public String fcrTextoXmlEtiquetasPlantilla()
        {
            String lcrEtiqueta = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t";
            String lcrFinLinea = "\n";
            int lnuContador = 0;

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }


            foreach (var lobItem in tmpEtiquetas)
            {
                lnuContador++;
                if (lnuContador >= tmpEtiquetas.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += lcrTabNivel3 + "<Item Indice='" + lobItem.Indice + "'" +
                                              " Codigo='" + lobItem.Codigo + "'" +
                                              " Version='" + lobItem.Version + "'" +
                                              " Icono='" + lobItem.Icono + "'" +
                                              " Descripcion='" + lobItem.Descripcion + "'" +
                                              " Archivo='" + lobItem.Archivo + "'/>" + lcrFinLinea;
            }
            lcrEtiqueta = lcrTabNivel2 + "<Etiquetas>" + (String.IsNullOrWhiteSpace(lcrListItem) ?
                                                          "</Etiquetas>" : "\n" + lcrListItem + "\n" + lcrTabNivel2 + "</Etiquetas>");
            return lcrEtiqueta;
        }
        #endregion
        #region fcrTextoXmlImgPredefinidas: Generar lista de imagenes predefinidas de la plantilla
        /// <summary>
        /// <para>Generar lista imagenes predefinidas en plantilla</para>
        /// </summary>
        public String fcrTextoXmlImgPredefinidas()
        {
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t";

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in tmpImagenesPredef)
            {
                lcrListItem += lcrTabNivel2 + "<Image Codigo='" + lobItem.Codigo + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ImagenWidth='" + lobItem.ImagenWidth + "'\n" +
                               lcrTabNivel3 + "ImagenHeight='" + lobItem.ImagenHeight + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoTipo='" + lobItem.RecursoArchivoTipo + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoCodigo='" + lobItem.RecursoArchivoCodigo + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoUri='" + lobItem.RecursoArchivoUri + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoNombre='" + lobItem.RecursoArchivoNombre + "'>\n" +
                               lcrTabNivel2 + "</Image>\n";
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlPaginasPlantilla: Generar texto Xml de paginas exitentes en la plantilla
        /// <summary>
        /// <para>Generar texto Xml de paginas existentes en la plantilla</para>
        /// </summary>
        public String fcrTextoXmlPaginasPlantilla()
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t";
            String lcrTabNivel3 = "\t\t\t\t";

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            String lcrObjRelacion = fcrTextoXmlObjetosRelacion();
            int lnuContador = 0;
            var lobPaginas = fobRegSelectParenObjeto("OBJETOS", "PAGINA", "");


            foreach (var lobItem in lobPaginas)
            {
                #region Texto
                lnuContador++;
                lcrListItem += lcrTabNivel2 + "<Pagina Name='" + lobItem.Name + "'\n" +
                               lcrTabNivel3 + "NameContenedor='" + lobItem.NameContenedor + "'\n" +
                               lcrTabNivel3 + "Pagina='" + lobItem.Pagina + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "Parent='" + lobItem.Parent + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + lobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Style='" + lobItem.Style + "'\n" +
                               lcrTabNivel3 + "VerticalAlignment='" + lobItem.VerticalAlignment + "'\n" +
                               lcrTabNivel3 + "HorizontalAlignment='" + lobItem.HorizontalAlignment + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Width='" + lobItem.Width + "'\n" +
                               lcrTabNivel3 + "Height='" + lobItem.Height + "'>\n" +
                               "\t\t\t<Zonas>\n" +
                               fcrTextoXmlZonaPagina(lobItem.Name) + "\n" +
                               "\t\t\t</Zonas>\n" +
                               lcrTabNivel2 + "</Pagina>\n";
                #endregion
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlZonaPagina: Generar texto Xml de las zonas dentro de paginas
        /// <summary>
        /// <para>Generar texto Xml de las zonas existentes dentro de pagina dada en parametro tcrNombrePagina</para>
        /// </summary>
        public String fcrTextoXmlZonaPagina(String tcrNombrePagina)
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t\t\t";
            String lcrTabNivel3 = "\t\t\t\t\t  ";
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobZonas = fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNombrePagina);

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in lobZonas)
            {
                if (lobItem.TipoObjeto == "ZONA" || lobItem.TipoObjeto == "ZONAENCABEZADO")
                {
                    lnuContador++;
                    if (lnuContador >= lobZonas.Count) { lcrFinLinea = String.Empty; }
                    #region Texto
                    lcrListItem += lcrTabNivel2 + "<Zona Name='" + lobItem.Name + "'\n" +
                                   lcrTabNivel3 + "NameContenedor='" + lobItem.NameContenedor + "'\n" +
                                   lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                                   lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                                   lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                   lcrTabNivel3 + "Parent='" + lobItem.Parent + "'\n" +
                                   lcrTabNivel3 + "Pagina='" + lobItem.Pagina + "'\n" +
                                   lcrTabNivel3 + "TabIndex='" + lobItem.TabIndex + "'\n" +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "TituloVisible", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Style", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Border", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "IsEnabled", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Visibility", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Focusable", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "BorderBrush", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Foreground", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Background", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontFamily", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontStyle", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontWeight", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Decorations", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontSize", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Orientacion", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Angulo", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Margin", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Width", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Height", lcrTabNivel3, "\n") +
                                   lcrTabNivel3 + "Top='" + lobItem.Top + "'\n" +
                                   lcrTabNivel3 + "Left='" + lobItem.Left + "'>\n" +
                                   fcrTextoXmlCamposRelacionZona(lobItem.Name) + "\n" +
                                   lcrTabNivel3 + "<ObjetosEnZona>\n" +
                                   fcrTextoXmlObjetoEnZona(lobItem.Name) + "\n" +
                                   lcrTabNivel3 + "</ObjetosEnZona>\n" +
                                   lcrTabNivel2 + "</Zona>" + lcrFinLinea;
                    #endregion
                }

            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlObjetoEnZona: Generar texto Xml de objetos dentro de Zonas
        /// <summary>
        /// <para>Generar texto Xml de objetos dentro de Zonas</para>
        /// </summary>
        public String fcrTextoXmlObjetoEnZona(String tcrNombreZona)
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t\t\t\t\t\t";
            String lcrTabNivel3 = "\t\t\t\t\t\t\t\t\t  ";
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNombreZona);

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in lobObjetos)
            {
                //--------------------------
                // -aqui- ojo parche solo para caso de pueblo bello 21-10-2016 formatos viejos sin tablas
                // - para permitir reasignar tipo objetos y campos en formatos viejos 
                if (lobItem.TipoObjeto == "TEXTBOX" && lobItem.ToolTip == "RICH11")
                {
                    // se cambia el tipo objeto y se elimina el Binding
                    lobItem.TipoObjeto   = "RICHTEXTBOX";
                    lobItem.ClaseBase    = "RichTextBox";
                    lobItem.Binding      = String.Empty;
                    lobItem.BindingTabla = String.Empty;
                    lobItem.ToolTip      = String.Empty; // para que no lo vuelva a hacer
                }
                //-------------------------

                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                if (lobItem.TipoObjeto == "MULTIGROUPCHKBOX" || lobItem.TipoObjeto == "GROUPBOX")
                {
                    #region Texto Contenedores que no referencian campos
                    lcrListItem += lcrTabNivel2 + "<" + lobItem.ClaseBase + " Name='" + lobItem.Name + "'\n" +
                                   lcrTabNivel3 + "NameContenedor='" + lobItem.NameContenedor + "'\n" +
                                   lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                                   lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                                   lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                   lcrTabNivel3 + "ToolTip='" + lobItem.ToolTip + "'\n" +
                                   lcrTabNivel3 + "Parent='" + lobItem.Parent + "'\n" +
                                   lcrTabNivel3 + "TabIndex='" + lobItem.TabIndex + "'\n" +
                                   lcrTabNivel3 + "SeccionCodigo='" + lobItem.SeccionCodigo + "'\n" +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "TituloVisible", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiImprimir", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Style", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Border", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "IsEnabled", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Visibility", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Focusable", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "BorderBrush", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Foreground", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Background", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontFamily", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontStyle", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontWeight", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Decorations", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontSize", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Orientacion", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Angulo", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Width", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Height", lcrTabNivel3, "\n") +
                                   lcrTabNivel3 + "Top='" + lobItem.Top + "'\n" +
                                   lcrTabNivel3 + "Left='" + lobItem.Left + "'>\n" +
                                   fcrTextoXmlObjetoEnZonaGrupo(lobItem.Name, "5") + "\n" +
                                   lcrTabNivel2 + "</" + lobItem.ClaseBase + ">" + lcrFinLinea;
                    #endregion
                }
                else if (lobItem.TipoObjeto == "TEXTBOXREL")
                {
                    #region Texto
                    lcrListItem += lcrTabNivel2 + "<" + lobItem.ClaseBase + " Name='" + lobItem.Name + "'\n" +
                                   lcrTabNivel3 + "NameContenedor='" + lobItem.NameContenedor + "'\n" +
                                   lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                                   lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                                   lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                   lcrTabNivel3 + "ToolTip='" + lobItem.ToolTip + "'\n" +
                                   lcrTabNivel3 + "Parent='" + lobItem.Parent + "'\n" +
                                   lcrTabNivel3 + "TabIndex='" + lobItem.TabIndex + "'\n" +
                                   lcrTabNivel3 + "TablaOrigen='" + lobItem.TablaOrigen + "'\n" +
                                   lcrTabNivel3 + "SeccionCodigo='" + lobItem.SeccionCodigo + "'\n" +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "IsRequerido", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiImprimir", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "TituloVisible", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Style", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Border", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "IsEnabled", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Visibility", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Focusable", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "BorderBrush", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Foreground", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Background", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontFamily", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontStyle", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontWeight", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Decorations", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontSize", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Orientacion", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Angulo", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Width", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Height", lcrTabNivel3, "\n") +
                                   lcrTabNivel3 + "Top='" + lobItem.Top + "'\n" +
                                   lcrTabNivel3 + "Left='" + lobItem.Left + "'>\n" +
                                   fcrTextoXmlObjetoEnZonaGrupo(lobItem.Name, "5") + "\n" +
                                   lcrTabNivel2 + "</" + lobItem.ClaseBase + ">" + lcrFinLinea;
                    #endregion
                }
                else if (lobItem.TipoObjeto == "MULTIGROUPRADIOBUTTON")
                {
                    #region Texto - Contenedor de los RadioButton (es quien referencia las variables de campos y otras)
                    lcrListItem += lcrTabNivel2 + "<" + lobItem.ClaseBase + " Name='" + lobItem.Name + "'\n" +
                                   lcrTabNivel3 + "NameContenedor='" + lobItem.NameContenedor + "'\n" +
                                   lcrTabNivel3 + "TipoObjeto='" + lobItem.TipoObjeto + "'\n" +
                                   lcrTabNivel3 + "ClaseBase='" + lobItem.ClaseBase + "'\n" +
                                   lcrTabNivel3 + "Titulo='" + lobItem.Titulo + "'\n" +
                                   lcrTabNivel3 + "ToolTip='" + lobItem.ToolTip + "'\n" +
                                   lcrTabNivel3 + "Parent='" + lobItem.Parent + "'\n" +
                                   lcrTabNivel3 + "TabIndex='" + lobItem.TabIndex + "'\n" +
                                   lcrTabNivel3 + "Binding='" + lobItem.Binding + "'\n" +
                                   lcrTabNivel3 + "BindingDescripcion='" + lobItem.BindingDescripcion + "'\n" +
                                   lcrTabNivel3 + "BindingTabla='" + lobItem.BindingTabla + "'\n" +
                                   lcrTabNivel3 + "NombreVariable='" + lobItem.NombreVariable + "'\n" +
                                   lcrTabNivel3 + "VariablePublica='" + lobItem.VariablePublica + "'\n" +
                                   lcrTabNivel3 + "VarGestPosVector='" + lobItem.VarGestPosVector + "'\n" +
                                   lcrTabNivel3 + "PrnSiValidar='" + lobItem.PrnSiValidar + "'\n" +
                                   lcrTabNivel3 + "PrnValorDefault='" + lobItem.PrnValorDefault + "'\n" +
                                   lcrTabNivel3 + "PrnValorPreView='" + lobItem.PrnValorPreView + "'\n" +
                                   lcrTabNivel3 + "PrnMostrarTitulo='" + lobItem.PrnMostrarTitulo + "'\n" +
                                   lcrTabNivel3 + "TipoDato='" + lobItem.TipoDato + "'\n" +
                                   lcrTabNivel3 + "TipoOrigenDatos='" + lobItem.TipoOrigenDatos + "'\n" +
                                   lcrTabNivel3 + "CampoReporte='" + lobItem.CampoReporte + "'\n" +
                                   lcrTabNivel3 + "ValorDefault='" + lobItem.ValorDefault + "'\n" +
                                   lcrTabNivel3 + "SeccionCodigo='" + lobItem.SeccionCodigo + "'\n" +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "TituloVisible", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "SiImprimir", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Style", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Border", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "IsEnabled", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Visibility", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Focusable", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "BorderBrush", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Foreground", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Background", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontFamily", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontStyle", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontWeight", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Decorations", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "FontSize", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Orientacion", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Angulo", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Width", lcrTabNivel3, "\n") +
                                   fcrTextoXmlLeerPropiedadObjeto(lobItem, "Height", lcrTabNivel3, "\n") +
                                   lcrTabNivel3 + "Top='" + lobItem.Top + "'\n" +
                                   lcrTabNivel3 + "Left='" + lobItem.Left + "'>\n" +
                                   fcrTextoXmlObjetoEnZonaGrupo(lobItem.Name, "5") + "\n" +
                                   lcrTabNivel2 + "</" + lobItem.ClaseBase + ">" + lcrFinLinea;
                    #endregion
                }
                else
                {
                    lcrListItem += fcrTextoXmlObjetoTexto(lobItem, "3", lcrFinLinea);
                }
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlObjetoEnZonaGrupo: Generar texto Xml objetos de grupos en Zonas
        /// <summary>
        /// <para>Generar texto Xml objetos de grupos en Zonas</para>
        /// </summary>
        public String fcrTextoXmlObjetoEnZonaGrupo(String tcrNombreGrupo, String tcrNivel)
        {
            String lcrPaginas = String.Empty;
            String lcrListItem = String.Empty;
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNombreGrupo);

            foreach (var lobItem in lobObjetos)
            {
                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += fcrTextoXmlObjetoTexto(lobItem, tcrNivel, lcrFinLinea);
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlObjetoTexto: Genera texto Xml del Registro dado en parametro
        /// <summary>
        /// <para>Gener texto Xml del Registro dado en parametro</para>
        /// </summary>
        public String fcrTextoXmlObjetoTexto(ClassXmlPropObjeto tobItem, String tcrNivel, String tcrFinLinea)
        {
            String lcrListItem = String.Empty;
            // por defecto es nivel 3
            String lcrTabNivel2 = "\t\t\t\t\t\t\t";
            String lcrTabNivel3 = "\t\t\t\t\t\t\t\t\t  ";

            if (tcrNivel == "1") // Nivel para datos digitados
            {
                lcrTabNivel2 = "\t\t";
                lcrTabNivel3 = "\t\t\t\t";
            }
            else if (tcrNivel == "5")
            {
                lcrTabNivel2 = "\t\t\t\t\t\t\t\t\t";
                lcrTabNivel3 = "\t\t\t\t\t\t\t\t\t\t\t  ";
            }

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            // Generar los objetos
            if (tobItem.TipoObjeto == "MULTICHKBOX")
            {
                #region Texto - Estes es un objeto CHKBOX individual dentro del contenedor
                lcrListItem += lcrTabNivel2 + "<CheckBox Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Indice='" + tobItem.Indice + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TituloVisible", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Margin", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'/>" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "MULTIRADIOBUTTON")
            {
                // 
                #region Texto - Este es solo una opcion dentro del contenedor (no referencia campos ni variables)
                lcrListItem += lcrTabNivel2 + "<RadioButton Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Indice='" + tobItem.Indice + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TituloVisible", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RadioButtonGroupName", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Margin", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'/>" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "COMBOBOX")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<ComboBox Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingDescripcion='" + tobItem.BindingDescripcion + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               fcrTextoXmlComboBoxItems(tobItem.Name) + "\n" +
                               lcrTabNivel2 + "</ComboBox>" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBOXDATE")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "TablaOrigen='" + tobItem.TablaOrigen + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoInicial", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoFinal", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsRequerido", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FechaDefault", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBOXTIME")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "TablaOrigen='" + tobItem.TablaOrigen + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoInicial", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoFinal", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsRequerido", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HoraDefault", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBOXRELCOD")
            {
                #region Texto
                tobItem.TablaOrigen = fobRegSelectParenObjeto("OBJETOS", "", tobItem.Parent).FirstOrDefault().TablaOrigen;
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingDescripcion='" + tobItem.BindingDescripcion + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "TablaOrigen='" + tobItem.TablaOrigen + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoInicial", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoFinal", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "AlineacionTexto", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBOXRELDES")
            {
                #region Texto
                tobItem.TablaOrigen = fobRegSelectParenObjeto("OBJETOS", "", tobItem.Parent).FirstOrDefault().TablaOrigen;
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "TablaOrigen='" + tobItem.TablaOrigen + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoInicial", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoFinal", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "AlineacionTexto", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBLOCK")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "AlineacionTexto", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel3 + tobItem.Titulo + "\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "IMAGEN" || tobItem.TipoObjeto == "VIDEO" ||
                     tobItem.TipoObjeto == "WORD" || tobItem.TipoObjeto == "EXCEL" ||
                     tobItem.TipoObjeto == "PDF" || tobItem.TipoObjeto == "ARCHIVO")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoTipo='" + tobItem.RecursoArchivoTipo + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoCodigo='" + tobItem.RecursoArchivoCodigo + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoUri='" + tobItem.RecursoArchivoUri + "'\n" +
                               lcrTabNivel3 + "RecursoArchivoNombre='" + tobItem.RecursoArchivoNombre + "'\n" +
                               lcrTabNivel3 + "Stretch='" + tobItem.Stretch + "'\n" +
                               lcrTabNivel3 + "StretchDirection='" + tobItem.StretchDirection + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else if (tobItem.TipoObjeto == "TEXTBOX" || tobItem.TipoObjeto == "TEXTBOXEDITOR" ||
                     tobItem.TipoObjeto == "TEXTBOXNUMERICO" || tobItem.TipoObjeto == "CHECKBOX" || 
                     tobItem.TipoObjeto == "RICHTEXTBOX")
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "OrdenVista='" + tobItem.OrdenVista + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "Binding='" + tobItem.Binding + "'\n" +
                               lcrTabNivel3 + "BindingTabla='" + tobItem.BindingTabla + "'\n" +
                               lcrTabNivel3 + "NombreVariable='" + tobItem.NombreVariable + "'\n" +
                               lcrTabNivel3 + "VariablePublica='" + tobItem.VariablePublica + "'\n" +
                               lcrTabNivel3 + "VarGestPosVector='" + tobItem.VarGestPosVector + "'\n" +
                               lcrTabNivel3 + "IsReadOnly='" + tobItem.IsReadOnly + "'\n" +
                               lcrTabNivel3 + "PrnSiValidar='" + tobItem.PrnSiValidar + "'\n" +
                               lcrTabNivel3 + "PrnValorDefault='" + tobItem.PrnValorDefault + "'\n" +
                               lcrTabNivel3 + "PrnValorPreView='" + tobItem.PrnValorPreView + "'\n" +
                               lcrTabNivel3 + "PrnMostrarTitulo='" + tobItem.PrnMostrarTitulo + "'\n" +
                               lcrTabNivel3 + "CampoReporte='" + tobItem.CampoReporte + "'\n" +
                               lcrTabNivel3 + "ValorDefault='" + tobItem.ValorDefault + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiFiltroBusqueda", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMultiSet", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiImprimir", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoDato", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoOrigenDatos", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoInicial", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RangoFinal", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsRequerido", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosTipo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "RefVarDatosCampo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "AlineacionTexto", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            else
            {
                #region Texto
                lcrListItem += lcrTabNivel2 + "<" + tobItem.ClaseBase + " Name='" + tobItem.Name + "'\n" +
                               lcrTabNivel3 + "TipoObjeto='" + tobItem.TipoObjeto + "'\n" +
                               lcrTabNivel3 + "ClaseBase='" + tobItem.ClaseBase + "'\n" +
                               lcrTabNivel3 + "Titulo='" + tobItem.Titulo + "'\n" +
                               lcrTabNivel3 + "ToolTip='" + tobItem.ToolTip + "'\n" +
                               lcrTabNivel3 + "Parent='" + tobItem.Parent + "'\n" +
                               lcrTabNivel3 + "TabIndex='" + tobItem.TabIndex + "'\n" +
                               lcrTabNivel3 + "SeccionCodigo='" + tobItem.SeccionCodigo + "'\n" +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "TipoControl", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "SiMostrarEnMuro", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Binding", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BindingTabla", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "NombreVariable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CampoReporte", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Style", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "CodigoEtiqueta", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "VerticalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "HorizontalAlignment", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Border", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "IsEnabled", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Visibility", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Focusable", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "BorderBrush", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Foreground", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Background", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontFamily", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontStyle", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontWeight", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Decorations", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "FontSize", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Orientacion", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Angulo", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Width", lcrTabNivel3, "\n") +
                               fcrTextoXmlLeerPropiedadObjeto(tobItem, "Height", lcrTabNivel3, "\n") +
                               lcrTabNivel3 + "Top='" + tobItem.Top + "'\n" +
                               lcrTabNivel3 + "Left='" + tobItem.Left + "'>\n" +
                               lcrTabNivel2 + "</" + tobItem.ClaseBase + ">" + tcrFinLinea;
                #endregion
            }
            return lcrListItem;
        }
        #endregion
        #region fcrTextoXmlComboBoxItems: Generar lista de etiquetas inteligentes de la plantilla
        /// <summary>
        /// <para>Generar lista de etiquetas inteligentes de la plantilla</para>
        /// </summary>
        public String fcrTextoXmlComboBoxItems(String tcrNombreCoboBox)
        {
            String lcrEtiqueta = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t\t\t\t\t\t\t\t  ";
            String lcrTabNivel3 = "\t\t\t\t\t\t\t\t\t\t\t";
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenComboBoxItems("PARENT", tcrNombreCoboBox);

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in lobObjetos)
            {
                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += lcrTabNivel3 + "<Item Parent='" + lobItem.Parent + "'" +
                                              " Indice='" + lobItem.Indice + "'" +
                                              " Codigo='" + lobItem.Codigo + "'" +
                                              " Descripcion='" + lobItem.Descripcion + "'/>" + lcrFinLinea;
            }
            lcrEtiqueta = lcrTabNivel2 + "<ComboValoresItems>" + (String.IsNullOrWhiteSpace(lcrListItem) ?
                                                          "</ComboValoresItems>" : "\n" + lcrListItem + "\n" + lcrTabNivel2 + "</ComboValoresItems>");
            return lcrEtiqueta;
        }
        #endregion
        #region fcrTextoXmlCamposRelacionZona: Generar lista campos relacion en zonas
        /// <summary>
        /// <para>Generar lista campos relacion en zonas</para>
        /// </summary>
        public String fcrTextoXmlCamposRelacionZona(String tcrNombreZona)
        {
            String lcrEtiqueta = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t\t\t\t  ";
            String lcrTabNivel3 = "\t\t\t\t\t\t\t";
            String lcrFinLinea = "\n";
            int lnuContador = 0;
            var lobObjetos = fobRegSelectParenCamposRelacion("PARENT", tcrNombreZona);

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in lobObjetos)
            {
                lnuContador++;
                if (lnuContador >= lobObjetos.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += lcrTabNivel3 + "<Campo Name='" + lobItem.Name + "'" +
                                              " Parent='" + lobItem.Parent + "'" +
                                              " Tipo='" + lobItem.Tipo + "'" +
                                              " Ancho='" + lobItem.Ancho + "'" +
                                              " NameCampoDE='" + lobItem.NameCampoDE + "'" +
                                              " ObjetoBinding='" + lobItem.ObjetoBinding + "'/>" + lcrFinLinea;
            }
            lcrEtiqueta = lcrTabNivel2 + "<CamposRelacion>" + (String.IsNullOrWhiteSpace(lcrListItem) ?
                                                          "</CamposRelacion>" : "\n" + lcrListItem + "\n" + lcrTabNivel2 + "</CamposRelacion>");
            return lcrEtiqueta;
        }
        #endregion
        #region fcrTextoXmlObjetosRelacion: Generar lista de objetos relacion para vista en pagina muro
        /// <summary>
        /// <para>Generar lista de objetos relacion para vista en pagina muro</para>
        /// </summary>
        public String fcrTextoXmlObjetosRelacion()
        {
            String lcrObjetosRelacion = String.Empty;
            String lcrListItem = String.Empty;
            String lcrTabNivel2 = "\t\t\t";
            String lcrTabNivel3 = "\t\t\t\t  ";
            String lcrFinLinea = "\n";
            int lnuContador = 0;

            if (glgPlaniillaOptimizarTabsXml == true)
            {
                lcrTabNivel2 = String.Empty;
                lcrTabNivel3 = String.Empty;
            }

            foreach (var lobItem in tmpObjetosRelacion)
            {
                lnuContador++;
                if (lnuContador >= tmpObjetosRelacion.Count) { lcrFinLinea = String.Empty; }
                lcrListItem += lcrTabNivel3 + "<Objeto RelacionPagina='" + lobItem.RelacionPagina + "'" +
                                              " RelacionZona='" + lobItem.RelacionZona + "'" +
                                              " RelacionObjeto='" + lobItem.RelacionObjeto + "'" +
                                              " NameObjeto='" + lobItem.NameObjeto + "'/>" + lcrFinLinea;
            }
            lcrObjetosRelacion = lcrTabNivel2 + "<ObjetosRelacion>" + (String.IsNullOrWhiteSpace(lcrListItem) ?
                                                          "</ObjetosRelacion>" : "\n" + lcrListItem + "\n" + lcrTabNivel2 + "</ObjetosRelacion>");
            return lcrObjetosRelacion;
        }
        #endregion
        #region fcrTextoXmlLeerPropiedadObjeto: Leer valor para asignar a la propiedad
        /// <summary>
        /// <para>Leer valor para asignar a la propiedad</para>
        /// </summary>
        public static String fcrTextoXmlLeerPropiedadObjeto(ClassXmlPropObjeto tobObjeto, String tcrPropiedad, String tcrTabs, String tcrFinLinea)
        {
            #region Propíedades
            String lcrValorPropiedad = String.Empty;
            switch (tcrPropiedad)
            {
                case "TituloVisible":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TituloVisible) ? "" :
                                        tcrTabs + "TituloVisible='" + tobObjeto.TituloVisible + "'" + tcrFinLinea;
                    break;

                case "OrdenVista":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.OrdenVista) ? "" :
                                        tcrTabs + "OrdenVista='" + tobObjeto.OrdenVista + "'" + tcrFinLinea;
                    break;

                case "TabIndex":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TabIndex) ? "" :
                                        tcrTabs + "TabIndex='" + tobObjeto.TabIndex + "'" + tcrFinLinea;
                    break;

                case "Focusable":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Focusable) ? "" :
                                        tcrTabs + "Focusable='" + tobObjeto.Focusable + "'" + tcrFinLinea;
                    break;

                case "IsEnabled":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.IsEnabled) ? "" :
                                        tcrTabs + "IsEnabled='" + tobObjeto.IsEnabled + "'" + tcrFinLinea;
                    break;

                case "Visibility":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Visibility) ? "" :
                                        tcrTabs + "Visibility='" + tobObjeto.Visibility + "'" + tcrFinLinea;
                    break;

                case "VerticalAlignment":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.VerticalAlignment) ? "" :
                                        tcrTabs + "VerticalAlignment='" + tobObjeto.VerticalAlignment + "'" + tcrFinLinea;
                    break;

                case "HorizontalAlignment":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.HorizontalAlignment) ? "" :
                                        tcrTabs + "HorizontalAlignment='" + tobObjeto.HorizontalAlignment + "'" + tcrFinLinea;
                    break;

                case "Style":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Style) ? "" :
                                        tcrTabs + "Style='" + tobObjeto.Style + "'" + tcrFinLinea;
                    break;

                case "Margin":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Margin) ? "" :
                                        tcrTabs + "Margin='" + tobObjeto.Margin + "'" + tcrFinLinea;
                    break;

                case "Border":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Border) ? "" :
                                        tcrTabs + "Border='" + tobObjeto.Border + "'" + tcrFinLinea;
                    break;

                case "Foreground":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Foreground) ? "" :
                                        tcrTabs + "Foreground='" + tobObjeto.Foreground + "'" + tcrFinLinea;
                    break;

                case "BorderBrush":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.BorderBrush) ? "" :
                                        tcrTabs + "BorderBrush='" + tobObjeto.BorderBrush + "'" + tcrFinLinea;
                    break;

                case "Background":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Background) ? "" :
                                        tcrTabs + "Background='" + tobObjeto.Background + "'" + tcrFinLinea;
                    break;

                case "Height":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Height) ? "" :
                                        tcrTabs + "Height='" + tobObjeto.Height + "'" + tcrFinLinea;
                    break;

                case "Width":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Width) ? "" :
                                        tcrTabs + "Width='" + tobObjeto.Width + "'" + tcrFinLinea;
                    break;

                case "Top":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Top) ? "" :
                                        tcrTabs + "Top='" + tobObjeto.Top + "'" + tcrFinLinea;
                    break;

                case "Left":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Left) ? "" :
                                        tcrTabs + "Left='" + tobObjeto.Left + "'" + tcrFinLinea;
                    break;

                case "FontFamily":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.FontFamily) ? "" :
                                        tcrTabs + "FontFamily='" + tobObjeto.FontFamily + "'" + tcrFinLinea;
                    break;

                case "FontStyle":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.FontStyle) ? "" :
                                        tcrTabs + "FontStyle='" + tobObjeto.FontStyle + "'" + tcrFinLinea;
                    break;

                case "FontWeight":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.FontWeight) ? "" :
                                        tcrTabs + "FontWeight='" + tobObjeto.FontWeight + "'" + tcrFinLinea;
                    break;

                case "Decorations":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Decorations) ? "" :
                                        tcrTabs + "Decorations='" + tobObjeto.Decorations + "'" + tcrFinLinea;
                    break;

                case "FontSize":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.FontSize) ? "" :
                                        tcrTabs + "FontSize='" + tobObjeto.FontSize + "'" + tcrFinLinea;
                    break;

                case "AlineacionTexto":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.AlineacionTexto) ? "" :
                                        tcrTabs + "AlineacionTexto='" + tobObjeto.AlineacionTexto + "'" + tcrFinLinea;
                    break;

                case "Orientacion":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Orientacion) ? "" :
                                        tcrTabs + "Orientacion='" + tobObjeto.Orientacion + "'" + tcrFinLinea;
                    break;

                case "Angulo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Angulo) ? "" :
                                        tcrTabs + "Angulo='" + tobObjeto.Angulo + "'" + tcrFinLinea;
                    break;

                case "Binding":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Binding) ? "" :
                                        tcrTabs + "Binding='" + tobObjeto.Binding + "'" + tcrFinLinea;
                    break;

                case "BindingDescripcion":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.BindingDescripcion) ? "" :
                                        tcrTabs + "BindingDescripcion='" + tobObjeto.BindingDescripcion + "'" + tcrFinLinea;
                    break;
                    
                case "BindingTabla":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.BindingTabla) ? "" :
                                        tcrTabs + "BindingTabla='" + tobObjeto.BindingTabla + "'" + tcrFinLinea;
                    break;

                case "ValorDefault":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.ValorDefault) ? "" :
                                        tcrTabs + "ValorDefault='" + tobObjeto.ValorDefault + "'" + tcrFinLinea;
                    break;

                case "Indice":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.Indice) ? "" :
                                        tcrTabs + "Indice='" + tobObjeto.Indice + "'" + tcrFinLinea;
                    break;

                case "TotalItems":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TotalItems) ? "" :
                                        tcrTabs + "TotalItems='" + tobObjeto.TotalItems + "'" + tcrFinLinea;
                    break;

                case "TipoDato":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TipoDato) ? "" :
                                        tcrTabs + "TipoDato='" + tobObjeto.TipoDato + "'" + tcrFinLinea;
                    break;

                case "TipoControl":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TipoControl) ? "" :
                                        tcrTabs + "TipoControl='" + tobObjeto.TipoControl + "'" + tcrFinLinea;
                    break;

                case "SeccionCodigo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SeccionCodigo) ? "" :
                                        tcrTabs + "SeccionCodigo='" + tobObjeto.SeccionCodigo + "'" + tcrFinLinea;
                    break;

                case "TipoOrigenDatos":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TipoOrigenDatos) ? "" :
                                        tcrTabs + "TipoOrigenDatos='" + tobObjeto.TipoOrigenDatos + "'" + tcrFinLinea;
                    break;

                case "TablaOrigen":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.TablaOrigen) ? "" :
                                        tcrTabs + "TablaOrigen='" + tobObjeto.TablaOrigen + "'" + tcrFinLinea;
                    break;

                case "CodigoEtiqueta":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.CodigoEtiqueta) ? "" :
                                        tcrTabs + "CodigoEtiqueta='" + tobObjeto.CodigoEtiqueta + "'" + tcrFinLinea;
                    break;

                case "RangoInicial":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RangoInicial) ? "" :
                                        tcrTabs + "RangoInicial='" + tobObjeto.RangoInicial + "'" + tcrFinLinea;
                    break;

                case "RangoFinal":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RangoFinal) ? "" :
                                        tcrTabs + "RangoFinal='" + tobObjeto.RangoFinal + "'" + tcrFinLinea;
                    break;

                case "IsRequerido":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.IsRequerido) ? "" :
                                        tcrTabs + "IsRequerido='" + tobObjeto.IsRequerido + "'" + tcrFinLinea;
                    break;

                case "FechaDefault":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.FechaDefault) ? "" :
                                        tcrTabs + "FechaDefault='" + tobObjeto.FechaDefault + "'" + tcrFinLinea;
                    break;

                case "HoraDefault":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.HoraDefault) ? "" :
                                        tcrTabs + "HoraDefault='" + tobObjeto.HoraDefault + "'" + tcrFinLinea;
                    break;

                case "SiMultiSet":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SiMultiSet) ? "" :
                                        tcrTabs + "SiMultiSet='" + tobObjeto.SiMultiSet + "'" + tcrFinLinea;
                    break;

                case "IsReadOnly":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.IsReadOnly) ? "" :
                                        tcrTabs + "IsReadOnly='" + tobObjeto.IsReadOnly + "'" + tcrFinLinea;
                    break;

                case "PrnSiValidar":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.PrnSiValidar) ? "" :
                                        tcrTabs + "PrnSiValidar='" + tobObjeto.PrnSiValidar + "'" + tcrFinLinea;
                    break;

                case "PrnValorDefault":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.PrnValorDefault) ? "" :
                                        tcrTabs + "PrnValorDefault='" + tobObjeto.PrnValorDefault + "'" + tcrFinLinea;
                    break;

                case "PrnValorPreView":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.PrnValorPreView) ? "" :
                                        tcrTabs + "PrnValorPreView='" + tobObjeto.PrnValorPreView + "'" + tcrFinLinea;
                    break;

                case "PrnMostrarTitulo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.PrnMostrarTitulo) ? "" :
                                        tcrTabs + "PrnMostrarTitulo='" + tobObjeto.PrnMostrarTitulo + "'" + tcrFinLinea;
                    break;

                case "VariablePublica":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.VariablePublica) ? "" :
                                        tcrTabs + "VariablePublica='" + tobObjeto.VariablePublica + "'" + tcrFinLinea;
                    break;

                case "VarGestPosVector":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.VarGestPosVector) ? "" :
                                        tcrTabs + "VarGestPosVector='" + tobObjeto.VarGestPosVector + "'" + tcrFinLinea;
                    break;

                case "RefVarDatosTipo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RefVarDatosTipo) ? "" :
                                        tcrTabs + "RefVarDatosTipo='" + tobObjeto.RefVarDatosTipo + "'" + tcrFinLinea;
                    break;

                case "RefVarDatosCampo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RefVarDatosCampo) ? "" :
                                        tcrTabs + "RefVarDatosCampo='" + tobObjeto.RefVarDatosCampo + "'" + tcrFinLinea;
                    break;

                case "RecursoArchivoTipo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RecursoArchivoTipo) ? "" :
                                        tcrTabs + "RecursoArchivoTipo='" + tobObjeto.RecursoArchivoTipo + "'" + tcrFinLinea;
                    break;

                case "RecursoArchivoCodigo":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RecursoArchivoCodigo) ? "" :
                                        tcrTabs + "RecursoArchivoCodigo='" + tobObjeto.RecursoArchivoCodigo + "'" + tcrFinLinea;
                    break;

                case "RecursoArchivoUri":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RecursoArchivoUri) ? "" :
                                        tcrTabs + "RecursoArchivoUri='" + tobObjeto.RecursoArchivoUri + "'" + tcrFinLinea;
                    break;

                case "RecursoArchivoNombre":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RecursoArchivoNombre) ? "" :
                                        tcrTabs + "RecursoArchivoNombre='" + tobObjeto.RecursoArchivoNombre + "'" + tcrFinLinea;
                    break;

                case "SiValorCalculado":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SiValorCalculado) ? "" :
                                        tcrTabs + "SiValorCalculado='" + tobObjeto.SiValorCalculado + "'" + tcrFinLinea;
                    break;

                case "NombreVariable":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.NombreVariable) ? "" :
                                        tcrTabs + "NombreVariable='" + tobObjeto.NombreVariable + "'" + tcrFinLinea;
                    break;

                case "CampoReporte":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.CampoReporte) ? "" :
                                        tcrTabs + "CampoReporte='" + tobObjeto.CampoReporte + "'" + tcrFinLinea;
                    break;

                case "SiMostrarEnMuro":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SiMostrarEnMuro) ? "" :
                                        tcrTabs + "SiMostrarEnMuro='" + tobObjeto.SiMostrarEnMuro + "'" + tcrFinLinea;
                    break;

                case "SiFiltroBusqueda":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SiFiltroBusqueda) ? "" :
                                        tcrTabs + "SiFiltroBusqueda='" + tobObjeto.SiFiltroBusqueda + "'" + tcrFinLinea;
                    break;

                case "SiImprimir":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.SiImprimir) ? "" :
                                        tcrTabs + "SiImprimir='" + tobObjeto.SiImprimir + "'" + tcrFinLinea;
                    break;

                case "RadioButtonGroupName":
                    lcrValorPropiedad = String.IsNullOrWhiteSpace(tobObjeto.RadioButtonGroupName) ? "" :
                                        tcrTabs + "RadioButtonGroupName='" + tobObjeto.RadioButtonGroupName + "'" + tcrFinLinea;
                    break;
            }
            #endregion
            return lcrValorPropiedad;
        }
        #endregion
        //------------------------------------------------------------
        //- CONSULTAS LINQ EN TEMPORALES
        //------------------------------------------------------------
        //- Traer lista de registros 
        #region fobRegSelectParenObjeto : Seleccionar registros desde lista de objetos
        /// <summary>
        /// <para>Seleccionar registros desde lista de objetos</para>
        /// <para>Devolver registro del nombre objeto dado en parametro tcrObjeto o una lista segun parametro tcrParent</para>
        /// <para>tcrArchivoOrigen: OBJETOS/ELIMINADOS/AUXILIAR</para>
        /// <para>Posibles Valores tcrParent:</para>
        /// <para>tcrParent = "PAGINA"/"ZONA/BUTTON..."----y tcrObjeto="NombreObjeto"        : Retorna lista objetos del tipo dado que pertenecen al tree de tcrObjeto.</para>
        /// <para>tcrParent = "PARENT"---------------------y tcrObjeto="NombreObjeto"        : Retorna lista todos los objetos que tienen como padre al objeto dado.</para>
        /// <para>tcrParent = "PLANTILLA"------------------y tcrObjeto="CodigoPlantilla"     : Retorna lista todos los objetos que pertenecen a la plantilla dada.</para>
        /// <para>tcrParent = "NAVEGADOR"------------------y tcrObjeto="ESCRITORIO/ETIQUETA" : Retorna lista todos los objetos que pertenecen al navegador dado.</para>
        /// <para>tcrParent = "CAPTURA"--------------------y tcrObjeto="-EDT-.."             : Retorna lista objetos segun CAPTURA-EDT-ESCRITORIO/CAPTURA-EDT-ETIQUETA  o ambos</para>
        /// <para>tcrParent = "PAGINA"/"ZONA/BUTTON..."----y tcrObjeto=""                    : Retorna lista todos los objetos del tipo dado.</para>
        /// <para>tcrParent = ""                  y tcrObjeto="NombreObjeto"        : Retorna objeto dado.</para>
        /// </summary>
        public List<ClassXmlPropObjeto> fobRegSelectParenObjeto(String tcrArchivoOrigen, String tcrParent, String tcrObjeto)
        {
            List<ClassXmlPropObjeto> lobTemp = fobRegSelectReferenciaArchivo(tcrArchivoOrigen);
            List<ClassXmlPropObjeto> lcrQuery = null;

            // Devolver lista tree de objetos del tipo tcrParent que pertenecen a tcrObjeto (PAGINA/ZONA/TEXTBOX...)
            if (!String.IsNullOrWhiteSpace(tcrParent) && 
                !String.IsNullOrWhiteSpace(tcrObjeto) &&
                tcrParent != "PARENT" && tcrParent != "PLANTILLA" && tcrParent != "NAVEGADOR" && tcrParent != "CAPTURA")   
            {
                lcrQuery = (from lst in lobTemp
                            where lst.TipoObjeto.Equals(tcrParent) && lst.Parent.Equals(tcrObjeto) 
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else if (tcrParent == "PARENT")             // Todos los objetos que tienen como padre al objeto dado.
            {
                lcrQuery = (from lst in lobTemp
                            where lst.Parent.Equals(tcrObjeto) && lst.TipoObjeto != "CONTENEDOR"
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else if (tcrParent == "PLANTILLA")          // Todos los objetos que pertenecen a la plantilla dada como objeto
            {
                lcrQuery = (from lst in lobTemp
                            where lst.CodigoPlantilla.Equals(tcrObjeto) 
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else if (tcrParent == "NAVEGADOR")          // Todos los objetos que pertenecen al navegador dado como objeto
            {
                lcrQuery = (from lst in lobTemp
                            where lst.Navegador.Equals(tcrObjeto)
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else if (tcrParent == "CAPTURA")          // Todos los objetos Creados en modo captura 
            {
                if (!String.IsNullOrWhiteSpace(tcrObjeto))
                {
                    lcrQuery = (from lst in lobTemp
                                where lst.ObjetoModo.Equals(tcrObjeto) // puede ser uno:  CAPTURA-EDT-ESCRITORIO / CAPTURA-EDT-ETIQUETA
                                orderby lst.IntTabIndex
                                select lst).ToList();
                }
                else
                {
                    lcrQuery = (from lst in lobTemp
                                where lst.ObjetoModo.Equals("CAPTURA-EDT-ESCRITORIO") || lst.ObjetoModo.Equals("CAPTURA-EDT-ETIQUETA")
                                orderby lst.IntTabIndex
                                select lst).ToList();
                }
            }
            else if (String.IsNullOrWhiteSpace(tcrObjeto))   // Devolver lista del tipo dado PAGINA/ZONA/TEXTBOX...
            {
                lcrQuery = (from lst in lobTemp
                            where lst.TipoObjeto.Equals(tcrParent)
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else if (String.IsNullOrWhiteSpace(tcrParent)) // Retorna solo objeto dado.
            {
                lcrQuery = (from lst in lobTemp
                            where lst.Name.Equals(tcrObjeto)
                            orderby lst.IntTabIndex
                            select lst).ToList();
            }
            else { lcrQuery = null; }

            return lcrQuery;
        }
        #endregion
        #region fobRegSelectParenTreeObjeto : Seleccionar Tree de un objeto
        /// <summary>
        /// <para>Seleccionar registros desde archivo origen "tcrArchivoOrigen"</para>
        /// <para>Devuelve el objeto dado en parametro y todos los que estan dentro del Tree</para>
        /// <para>tcrArchivoOrigen: "OBJETOS"/"AUXILIAR"/"ELIMINADOS"</para>
        /// </summary>
        public List<ClassXmlPropObjeto> fobRegSelectParenTreeObjeto(String tcrArchivoOrigen, String tcrObjeto, int tnuIdAccion)
        {
            List<ClassXmlPropObjeto> tobTemp = fobRegSelectReferenciaArchivo(tcrArchivoOrigen);
            List<ClassXmlPropObjeto> lcrQuery = null;

            var lobReg = (from lst in tobTemp where lst.Name.Equals(tcrObjeto) select lst).FirstOrDefault();

            if (lobReg != null)
            {
                if (lobReg.TipoObjeto == "PAGINA")
                {
                    #region Datos
                    if (tnuIdAccion > 0)
                    {
                        lcrQuery = (from lst in tobTemp
                                    where (lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentPagina.Equals(tcrObjeto)) && lst.IdAccion.Equals(tnuIdAccion)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    else
                    {
                        lcrQuery = (from lst in tobTemp
                                    where lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentPagina.Equals(tcrObjeto)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    #endregion
                }
                else if (lobReg.TipoObjeto == "ZONA")
                {
                    #region Datos
                    if (tnuIdAccion > 0)
                    {
                        lcrQuery = (from lst in tobTemp
                                    where (lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentZona.Equals(tcrObjeto)) && lst.IdAccion.Equals(tnuIdAccion)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    else
                    {
                        lcrQuery = (from lst in tobTemp
                                    where lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentZona.Equals(tcrObjeto)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    #endregion
                }
                else if (lobReg.TipoObjeto == "GRUPO" ||
                         lobReg.TipoObjeto == "MULTIGROUPRADIOBUTTON" ||
                         lobReg.TipoObjeto == "TEXTBOXREL" ||
                         lobReg.TipoObjeto == "MULTIGROUPCHKBOX")
                {
                    #region Datos
                    if (tnuIdAccion > 0)
                    {
                        lcrQuery = (from lst in tobTemp
                                    where (lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentGrupo.Equals(tcrObjeto)) && lst.IdAccion.Equals(tnuIdAccion)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    else
                    {
                        lcrQuery = (from lst in tobTemp
                                    where lst.Name.Equals(tcrObjeto) ||
                                    lst.ObjetoParentGrupo.Equals(tcrObjeto)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    #endregion
                }
                else
                {
                    #region Datos
                    if (tnuIdAccion > 0)
                    {
                        lcrQuery = (from lst in tobTemp
                                    where lst.Name.Equals(tcrObjeto) && lst.IdAccion.Equals(tnuIdAccion)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    else
                    {
                        lcrQuery = (from lst in tobTemp
                                    where lst.Name.Equals(tcrObjeto)
                                    orderby lst.IntTabIndex
                                    select lst).ToList();
                    }
                    #endregion
                }
            }
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectParenComboBoxItems : Seleccionar registros desde lista de Items para ComboBox
        /// <summary>
        /// <para>Seleccionar registros desde lista de Items para ComboBox</para>
        /// <para>Devolver registro del nombre objeto dado en parametro tcrObjeto o una lista segun parametro tcrParent</para>
        /// <para>Posibles Valores tcrParent:</para>
        /// <para>tcrParent = "PARENT"  y  tcrObjeto="NombreObjeto"     : Retorna lista todos los objetos que tienen como padre al objeto dado.</para>
        /// <para>tcrParent = "NombreObjeto" y  tcrObjeto="CodigoItem"  : Retorna solo el item del objeto dado.</para>
        /// </summary>
        public List<ClassXmlComboBoxItems> fobRegSelectParenComboBoxItems(String tcrParent, String tcrObjeto)
        {
            List<ClassXmlComboBoxItems> lcrQuery = new List<ClassXmlComboBoxItems>();
            if (tcrParent == "PARENT")             // Todos los objetos que tienen como padre al combobox dado.
            {
                lcrQuery = (from lst in tmpComboItems
                            where lst.Parent.Equals(tcrObjeto)
                            orderby lst.IntIndice
                            select new ClassXmlComboBoxItems
                            {
                                IntIndice = lst.IntIndice,
                                Parent = lst.Parent,
                                Indice = lst.Indice,
                                Codigo = lst.Codigo,
                                Descripcion = lst.Descripcion,

                            }).ToList();
            }
            else if (!String.IsNullOrWhiteSpace(tcrParent)) // Retorna solo el item dado para el objeto.
            {
                lcrQuery = (from lst in tmpComboItems
                            where lst.Codigo.Equals(tcrObjeto) && lst.Parent.Equals(tcrParent)
                            orderby lst.IntIndice
                            select new ClassXmlComboBoxItems
                            {
                                IntIndice = lst.IntIndice,
                                Parent = lst.Parent,
                                Indice = lst.Indice,
                                Codigo = lst.Codigo,
                                Descripcion = lst.Descripcion,

                            }).ToList();
            }
            else { lcrQuery = null; }

            return lcrQuery;
        }
        #endregion
        #region fobRegSelectParenItemTreeComboBox : Seleccionar lista Items objeto Combobox
        /// <summary>
        /// <para>Seleccionar registros desde archivo origen "tcrArchivoOrigen"</para>
        /// <para>Devuelve lista de items que pertenecen al objeto</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrArchivoOrigen "OBJETOS" / "ELIMINADOS"</para>
        /// <para>tcrObjeto : Nombre del objeto ComboBox padre del grupo de elemento que hacen parte de su lista de opciones </para>
        /// </summary>
        public List<ClassXmlComboBoxItems> fobRegSelectParenItemTreeComboBox(String tcrArchivoOrigen, String tcrObjeto)
        {
            List<ClassXmlComboBoxItems> tobTemp = tcrArchivoOrigen == "OBJETOS" ? tmpComboItems : tmpComboItemsEliminado;
            List<ClassXmlComboBoxItems> lcrQuery = null;

            lcrQuery = (from lst in tobTemp where lst.Parent.Equals(tcrObjeto) select lst).ToList();
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectParenCamposRelacion : Seleccionar registros desde lista campos tabla relacion en zona
        /// <summary>
        /// <para>Seleccionar registros desde lista campos tabla relacion en zona</para>
        /// <para>Devolver registro del nombre objeto dado en parametro tcrObjeto o una lista segun parametro tcrParent</para>
        /// <para>Posibles Valores tcrParent:</para>
        /// <para>tcrParent = "PARENT"  y  tcrObjeto="NombreObjeto"     : Retorna lista todos los objetos que tienen como padre al objeto dado.</para>
        /// <para>tcrParent = "OBJETO"  y  tcrObjeto="NombreObjeto"     : Retorna registro de objeto dado.</para>
        /// <para>tcrParent = "CAMPO"   y  tcrObjeto="NombreCampo"      : Retorna registro de campo dado.</para>
        /// </summary>
        public List<ClassXmlCamposRelacion> fobRegSelectParenCamposRelacion(String tcrParent, String tcrObjeto)
        {
            List<ClassXmlCamposRelacion> lcrQuery = new List<ClassXmlCamposRelacion>();
            if (tcrParent == "PARENT")             // Todos los objetos que tienen como padre la zona dada.
            {
                lcrQuery = (from lst in tmpCamposRelacion
                            where lst.Parent.Equals(tcrObjeto)
                            select new ClassXmlCamposRelacion
                            {
                                Name = lst.Name,
                                Parent = lst.Parent,
                                Tipo = lst.Tipo,
                                Ancho = lst.Ancho,
                                NameCampoDE = lst.NameCampoDE,
                                ObjetoBinding = lst.ObjetoBinding
                            }).ToList();
            }
            else if (tcrParent == "CAMPO") // Retorna registro del nombre campo dado.
            {
                lcrQuery = (from lst in tmpCamposRelacion
                            where lst.Name.Equals(tcrObjeto)
                            select new ClassXmlCamposRelacion
                            {
                                Name = lst.Name,
                                Parent = lst.Parent,
                                Tipo = lst.Tipo,
                                Ancho = lst.Ancho,
                                NameCampoDE = lst.NameCampoDE,
                                ObjetoBinding = lst.ObjetoBinding
                            }).ToList();
            }
            else if (tcrParent == "OBJETO") // Retorna solo objeto dado.
            {
                lcrQuery = (from lst in tmpCamposRelacion
                            where lst.ObjetoBinding.Equals(tcrObjeto)
                            select new ClassXmlCamposRelacion
                            {
                                Name = lst.Name,
                                Parent = lst.Parent,
                                Tipo = lst.Tipo,
                                Ancho = lst.Ancho,
                                NameCampoDE = lst.NameCampoDE,
                                ObjetoBinding = lst.ObjetoBinding
                            }).ToList();
            }
            else { lcrQuery = null; }

            return lcrQuery;
        }
        #endregion
        #region fobRegSelectItemsSecciones : Seleccionar registros desde lista de Secciones del formato
        /// <summary>
        /// <para>Seleccionar registros desde lista de Secciones del formato</para>
        /// <para>Posibles Valores CodigoItem:</para>
        /// <para>CodigoItem="CodigoItem"   : Retorna item dado</para>
        /// <para>CodigoItem=""             : Retorna lista con todos los items</para>
        /// </summary>
        public List<ClassXmlComboBoxItems> fobRegSelectItemsSecciones(String CodigoItem)
        {
            List<ClassXmlComboBoxItems> lcrQuery = new List<ClassXmlComboBoxItems>();
            if (!String.IsNullOrWhiteSpace(CodigoItem))             // Solo item dado en CodigoItem
            {
                lcrQuery = (from tmp in tmpSecciones
                            where tmp.Codigo.Equals(CodigoItem)
                            select tmp).ToList();
            }
            else
            {
                lcrQuery = (from tmp in tmpSecciones
                            orderby tmp.IntOrden
                            select tmp).ToList();
            }

            return lcrQuery;
        }
        #endregion
        #region fobRegSelectItemsEtiquetas : Seleccionar registros desde lista de Items Etiquetas
        /// <summary>
        /// <para>Seleccionar registros desde lista de Items Etiquetas</para>
        /// <para>Posibles Valores CodigoItem:</para>
        /// <para>CodigoItem="CodigoItem"   : Retorna item dado</para>
        /// <para>CodigoItem=""             : Retorna lista con todos los items</para>
        /// </summary>
        public List<ClassXmlItemEtiquetas> fobRegSelectItemsEtiquetas(String CodigoItem)
        {
            List<ClassXmlItemEtiquetas> lcrQuery = new List<ClassXmlItemEtiquetas>();
            if (!String.IsNullOrWhiteSpace(CodigoItem))             // Solo item dado en CodigoItem
            {
                lcrQuery = (from etiquetas in tmpEtiquetas
                            where etiquetas.Codigo.Equals(CodigoItem)
                            select etiquetas).ToList();
            }
            else
            {
                lcrQuery = (from etiquetas in tmpEtiquetas
                            orderby etiquetas.IntIndice
                            select etiquetas).ToList();
            }

            return lcrQuery;
        }
        #endregion
        #region fobRegSelectEdtAccion : Seleccionar una accion desde la lista de acciones
        /// <summary>
        /// <para>Seleccionar registros segun el valor del puntero de acciones realizadas</para>
        /// </summary>
        public ClassXmlPropObjeto fobRegSelectEdtAccion(int tnuIdAccion)
        {
            ClassXmlPropObjeto lcrQuery = null;
            if (tnuIdAccion >= 1)
            {
                lcrQuery = (from lst in tmpObjetosAccion where lst.IdAccion.Equals(tnuIdAccion) select lst).FirstOrDefault();
            }
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectEdtObjetoEliminado : Seleccionar un objeto de la lista de eliminados
        /// <summary>
        /// <para>Seleccionar un objeto de la lista de eliminados</para>
        /// </summary>
        public ClassXmlPropObjeto fobRegSelectEdtObjetoEliminado(String tcrNombreObjeto, int tnuIdAccion)
        {
            ClassXmlPropObjeto lcrQuery = null;
            lcrQuery = (from lst in tmpObjetosEliminado
                        where lst.Name.Equals(tcrNombreObjeto) && lst.IdAccion.Equals(tnuIdAccion)
                        select lst).FirstOrDefault();
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectValorDigitadoObjeto : Seleccionar valor digitado (en modo captura/gestion) del objeto desde temporal de datos
        /// <summary>
        /// <para>Seleccionar valor digitado (en modo captura/gestion) del objeto desde temporal de datos</para>
        /// </summary>
        public ClassXmlPropDatos fobRegSelectValorDigitadoObjeto(String tcrNombreObjeto)
        {
            ClassXmlPropDatos lcrQuery = null;
            if (tmpCapturaDatos != null)
            {
                lcrQuery = (from lst in tmpCapturaDatos
                            where lst.Name.Equals(tcrNombreObjeto)
                            select lst).FirstOrDefault();
            }
            return lcrQuery;
        }
        #endregion
        #region fobRegSelectReferenciaArchivo : Seleccionar referencia a archivo de datos
        /// <summary>
        /// <para>Seleccionar referencia a archivo de datos segun "tcrArchivoOrigen"</para>
        /// <para>tcrArchivoOrigen: "OBJETOS"/"AUXILIAR"/"ELIMINADOS"</para>
        /// <para>Devuelve una referencia a :tmpObjetos/tmpObjetosAux/tmpObjetosEliminado/</para>
        /// </summary>
        public List<ClassXmlPropObjeto> fobRegSelectReferenciaArchivo(String tcrArchivoOrigen)
        {
            List<ClassXmlPropObjeto> tobTemp = tmpObjetos;
            switch (tcrArchivoOrigen)
            {
                case "OBJETOS": // Objetos
                    tobTemp = tmpObjetos;
                    break;

                case "AUXILIAR": // Temporal Auxiliar
                    tobTemp = tmpObjetosAux;
                    break;

                case "ELIMINADOS": // Eliminados
                    tobTemp = tmpObjetosEliminado;
                    break;
            }
            return tobTemp;
        }
        #endregion
        //------------------------------------------------------------
        //- GESTION EDICION MODIFICAR, ELIMINAR OBJETOS O RESTAURAR 
        //------------------------------------------------------------
        //- Eliminar Restaurar los datos
        #region fnuEdtAccionAddObjetoPila : Adicionar una accion realizada en objeto a la pila
        /// <summary>
        /// <para>Registrar en el temporal de acciones (pila de acciones), los eventos realizados</para>
        /// <para>a objetos para poder deshacer cambios.</para>
        /// <para>La funcion retorna el Id (numerico) generado para la accion registrada</para>
        /// </summary>
        public int fnuEdtAccionAddObjetoPila(String tcrAccion, ClassXmlPropObjeto tobObjeto)
        {
            gnuTopeIdAccionEdicion++;
            gnuIdAccionEdicionPuntero = gnuTopeIdAccionEdicion;

            tobObjeto.Accion = tcrAccion;
            tobObjeto.IdAccion = gnuTopeIdAccionEdicion;

            tmpObjetosAccion.Add(fobGenerarObjetoAsigValorRegistro(tobObjeto));
            return gnuIdAccionEdicionPuntero;
        }
        #endregion
        //- Navegar Deshacer y Rehacer (Atras y Adelante)
        #region fnuEdtAccionDesHacer : Deshacer cambios Atras (flecha a la izquierda)
        /// <summary>
        /// <para>Deshacer cambios (flecha a la izquierda)</para>
        /// </summary>
        public int fnuEdtAccionDesHacer()
        {
            var lnuIdAccion = 0;
            if (gnuTopeIdAccionEdicion > 0 && gnuIdAccionEdicionPuntero > 0 && lnuIdAccion <= gnuTopeIdAccionEdicion) // hay acciones realizadas
            {
                lnuIdAccion = gnuIdAccionEdicionPuntero;
                var lobRegistro = fobRegSelectEdtAccion(lnuIdAccion);

                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "MODIFICADO": // Hacer SetPropiedades
                            flgEdtAccionSetPropiedadObjeto(lobRegistro, true);
                            break;

                        case "ADICIONADO": // deshace Adicionar es eliminar el objeto
                            // Verificar que exista en objetos creados, la accion se hace en codigosubyacente
                            var lobjAdd = fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault();
                            lnuIdAccion = lobjAdd != null ? lnuIdAccion : 0;
                            break;

                        case "ELIMINADO": // Adicionar el objeto eliminado, crear de nuevo
                            // Verificar que exista en objetos eliminados
                            var lobjDel = fobRegSelectEdtObjetoEliminado(lobRegistro.Name, lnuIdAccion);
                            lnuIdAccion = lobjDel != null ? lnuIdAccion : 0;
                            if (lnuIdAccion > 0)
                            {
                                tmpObjetosAux = fobRegSelectParenTreeObjeto("ELIMINADOS", lobRegistro.Name, lnuIdAccion);
                                fcvGenerarObjetoIniciar("AUXILIAR", lobRegistro);
                                fobEdtAccionEliminarObjetos("ELIMINADOS", lobRegistro.Name, lobRegistro.Accion, lnuIdAccion);
                                // Cargar desde Objetos con IdAccion (aun los objetos tienen el ultimo IdAccion)
                                tmpObjetosAux = fobRegSelectParenTreeObjeto("OBJETOS", lobRegistro.Name, lnuIdAccion);
                            }
                            break;

                        default: // Para el resto de objetos
                            break;
                    }
                }
                gnuIdAccionEdicionPuntero--;
            }
            return lnuIdAccion;
        }
        #endregion
        #region fnuEdtAccionReHacer : Rehacer cambios (flecha a la derecha)
        /// <summary>
        /// <para>Rehacer cambios adelante (flecha a la derecha)</para>
        /// </summary>
        public int fnuEdtAccionReHacer()
        {
            var lnuIdAccion = 0;

            if (gnuTopeIdAccionEdicion > 0 && gnuIdAccionEdicionPuntero < gnuTopeIdAccionEdicion) // hay acciones realizadas
            {
                gnuIdAccionEdicionPuntero++;
                lnuIdAccion = gnuIdAccionEdicionPuntero;

                var lobRegistro = fobRegSelectEdtAccion(gnuIdAccionEdicionPuntero);
                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "MODIFICADO": // Hacer SetPropiedades
                            flgEdtAccionSetPropiedadObjeto(lobRegistro, true);
                            break;

                        case "ADICIONADO": //Rehacer Adicionar (generar el objeto nuevamente)
                            // Verificar que exista en objetos eliminados
                            var lobjDel = fobRegSelectEdtObjetoEliminado(lobRegistro.Name, lnuIdAccion);
                            lnuIdAccion = lobjDel != null ? lnuIdAccion : 0;
                            if (lnuIdAccion > 0)
                            {
                                tmpObjetosAux = fobRegSelectParenTreeObjeto("ELIMINADOS", lobRegistro.Name, lnuIdAccion);
                                fcvGenerarObjetoIniciar("AUXILIAR", lobRegistro);
                                fobEdtAccionEliminarObjetos("ELIMINADOS", lobRegistro.Name, lobRegistro.Accion, lnuIdAccion);
                                // Cargar desde Objetos con IdAccion (aun los objetos tienen el ultimo IdAccion)
                                tmpObjetosAux = fobRegSelectParenTreeObjeto("OBJETOS", lobRegistro.Name, lnuIdAccion);
                            }
                            break;

                        case "ELIMINADO": // eliminar el objeto nuevamente (accion en codigsubyacente)
                            var lobjAdd = fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault();
                            lnuIdAccion = lobjAdd != null ? lnuIdAccion : 0;
                            break;
                    }
                }
            }
            return lnuIdAccion;
        }
        #endregion
        #region fobEdtAccionEliminarObjetos : Eliminar registros de objetos
        /// <summary>
        /// <para>Eliminar registros del temporal dado en tcrTmpArchivo y los mueve al archivo relacionado opuesto </para>
        /// <para>Solo en el caso tcrArchivoOrigen: = "OBJETOS", realiza copia de los registros en  "ELIMINADOS" </para>
        /// <para>la funcion retorna una copia de los registros eliminados</para>
        /// </summary>
        public List<ClassXmlPropObjeto> fobEdtAccionEliminarObjetos(String tcrArchivoOrigen, String tcrNombreObjeto, String tcrAccion, int tnuIdAccion)
        {
            List<ClassXmlPropObjeto> lcrQuery = null;
            lcrQuery = fobRegSelectParenTreeObjeto(tcrArchivoOrigen, tcrNombreObjeto, tcrArchivoOrigen == "OBJETOS" ? 0 : tnuIdAccion);

            if (lcrQuery != null && lcrQuery.Count != 0)
            {
                foreach (ClassXmlPropObjeto lobReg in lcrQuery)
                {
                    if (!String.IsNullOrWhiteSpace(lobReg.Name))
                    {
                        if (tcrArchivoOrigen == "OBJETOS")
                        {
                            lobReg.Accion = tcrAccion;
                            lobReg.IdAccion = tnuIdAccion;
                            tmpObjetosEliminado.Add(fobGenerarObjetoAsigValorRegistro(lobReg));
                            tmpObjetos.Remove(lobReg);
                        }
                        else if (tcrArchivoOrigen == "ELIMINADOS")
                        {
                            tmpObjetosEliminado.Remove(lobReg);
                        }
                        else if (tcrArchivoOrigen == "AUXILIAR")
                        {
                            tmpObjetosAux.Remove(lobReg);
                        }
                    }
                }
            }
            return lcrQuery;
        }
        #endregion
        #region flgEdtAccionSetPropiedadObjeto: Deshacer cambios en propiedades de objetos
        /// <summary>
        /// <para>Deshacer cambios en propiedades de objetos</para>
        /// </summary>
        public bool flgEdtAccionSetPropiedadObjeto(ClassXmlPropObjeto tobRegObjeto, bool tlgActualizarTemp)
        {
            var llgReturn = false;
            refRegObjActivo = tobRegObjeto;
            if (tlgActualizarTemp == true)
            {
                var lobReg = fobRegSelectParenObjeto("OBJETOS", "", tobRegObjeto.Name).FirstOrDefault();
                if (lobReg != null)
                {
                    tmpObjetos.Remove(lobReg); 
                    tmpObjetos.Add(tobRegObjeto);
                }
            }
            #region objetos
            switch (tobRegObjeto.TipoObjeto.ToUpper())
            {
                case "PAGINA":
                    #region objeto
                    llgReturn = true;
                    var lobPagina = refRegObjActivo.RefObjeto as Canvas;
                    var lobContenedorPagina = refRegObjActivo.RefContenedorObjeto as WrapPanel;
                    SetPropiedadPagina(ref lobPagina, ref lobContenedorPagina);
                    #endregion
                    break;

                case "ZONA":
                    #region objeto
                    llgReturn = true;
                    var lobZona = refRegObjActivo.RefObjeto as GroupBox;
                    var lobContenedorZona = refRegObjActivo.RefContenedorObjeto as Canvas;
                    SetPropiedadZona(ref lobZona, ref lobContenedorZona);
                    #endregion
                    break;

                case "TEXTBOX":
                    #region objeto
                    llgReturn = true;
                    var lobTextBox = refRegObjActivo.RefObjeto as TextBox;
                    SetPropiedadTextBox(ref lobTextBox);
                    #endregion
                    break;

                case "RICHTEXTBOX":
                    #region objeto
                    llgReturn = true;
                    var lobRichTextBox = refRegObjActivo.RefObjeto as RichTextBox;
                    SetPropiedadRichTextBox(ref lobRichTextBox);
                    #endregion
                    break;

                case "COMBOBOX":
                    #region objeto
                    llgReturn = true;
                    var lobComboBox = refRegObjActivo.RefObjeto as ComboBox;
                    SetPropiedadComboBox(ref lobComboBox);
                    #endregion
                    break;

                case "BUTTON":
                    #region objeto
                    llgReturn = true;
                    var lobButton = refRegObjActivo.RefObjeto as Button;
                    SetPropiedadButton(ref lobButton);
                    #endregion
                    break;

                case "TEXTBLOCK":
                    #region objeto
                    llgReturn = true;
                    var lobTextBlock = refRegObjActivo.RefObjeto as TextBlock;
                    SetPropiedadTextBlock(ref lobTextBlock);
                    #endregion
                    break;

                case "RADIOBUTTON":
                    llgReturn = true;
                    break;

                case "CHECKBOX":
                    #region objeto
                    llgReturn = true;
                    var lobCheckBox = refRegObjActivo.RefObjeto as CheckBox;
                    SetPropiedadCheckBox(ref lobCheckBox);
                    #endregion
                    break;

                case "GROUPBOX":
                    #region objeto
                    llgReturn = true;
                    var lobGroupBox = refRegObjActivo.RefObjeto as GroupBox;
                    var lobContenedorGrupo = refRegObjActivo.RefContenedorObjeto as Canvas;
                    SetPropiedadGroupBox(ref lobGroupBox, ref lobContenedorGrupo);
                    #endregion
                    break;

                case "MULTIGROUPCHKBOX":
                    #region objeto
                    llgReturn = true;
                    var lobGroupBox1 = refRegObjActivo.RefObjeto as GroupBox;
                    var lobContenedorGrupo1 = refRegObjActivo.RefContenedorObjeto as Canvas;
                    SetPropiedadGroupBox(ref lobGroupBox1, ref lobContenedorGrupo1);
                    #endregion
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    #region objeto
                    llgReturn = true;
                    var lobGroupBox2 = refRegObjActivo.RefObjeto as GroupBox;
                    var lobContenedorGrupo2 = refRegObjActivo.RefContenedorObjeto as Canvas;
                    SetPropiedadGroupBox(ref lobGroupBox2, ref lobContenedorGrupo2);
                    #endregion
                    break;

                case "MULTICHKBOX":
                    #region objeto
                    llgReturn = true;
                    var lobCheckBox2 = refRegObjActivo.RefObjeto as CheckBox;
                    SetPropiedadCheckBox(ref lobCheckBox2);
                    #endregion
                    break;

                case "MULTIRADIOBUTTON":
                    #region objeto
                    llgReturn = true;
                    var lobRadioButton1 = refRegObjActivo.RefObjeto as RadioButton;
                    SetPropiedadRadioButton(ref lobRadioButton1);
                    #endregion
                    break;

                case "RECTANGULO":
                    #region objeto
                    llgReturn = true;
                    var lobRectangle = refRegObjActivo.RefObjeto as Rectangle;
                    SetPropiedadRectangle(ref lobRectangle);
                    #endregion
                    break;

                case "ELIPSE":
                    #region objeto
                    llgReturn = true;
                    var lobEllipse = refRegObjActivo.RefObjeto as Ellipse;
                    SetPropiedadEllipse(ref lobEllipse);
                    #endregion
                    break;

                case "LINEA-HORIZONTAL":
                    #region objeto
                    llgReturn = true;
                    var lobLineH = refRegObjActivo.RefObjeto as Line;
                    SetPropiedadLineaHorizontal(ref lobLineH);
                    #endregion
                    break;

                case "LINEA-VERTICAL":
                    #region objeto
                    llgReturn = true;
                    var lobLineV = refRegObjActivo.RefObjeto as Line;
                    SetPropiedadLineaVertical(ref lobLineV);
                    #endregion
                    break;

                case "LINEA-DERECHA":
                    #region objeto
                    llgReturn = true;
                    var lobLineD = refRegObjActivo.RefObjeto as Line;
                    SetPropiedadLineaDerecha(ref lobLineD);
                    #endregion
                    break;

                case "LINEA-IZQUIERDA":
                    #region objeto
                    llgReturn = true;
                    var lobLineI = refRegObjActivo.RefObjeto as Line;
                    SetPropiedadLineaIzquierda(ref lobLineI);
                    #endregion
                    break;

                case "FLECHA-DERECHA":
                    #region objeto
                    llgReturn = true;
                    var lobFlechaD = refRegObjActivo.RefObjeto as Polygon;
                    SetPropiedadFlechaDerecha(ref lobFlechaD);
                    #endregion
                    break;

                case "FLECHA-IZQUIERDA":
                    #region objeto
                    llgReturn = true;
                    var lobFlechaI = refRegObjActivo.RefObjeto as Polygon;
                    SetPropiedadFlechaIzquierda(ref lobFlechaI);
                    #endregion
                    break;

                case "FLECHA-ARRIBA":
                    #region objeto
                    llgReturn = true;
                    var lobFlechaA = refRegObjActivo.RefObjeto as Polygon;
                    SetPropiedadFlechaArriba(ref lobFlechaA);
                    #endregion
                    break;

                case "FLECHA-ABAJO":
                    #region objeto
                    llgReturn = true;
                    var lobFlechaB = refRegObjActivo.RefObjeto as Polygon;
                    SetPropiedadFlechaAbajo(ref lobFlechaB);
                    #endregion
                    break;

                case "POLYLINE":
                    llgReturn = true;
                    break;

                case "POLYGON":
                    llgReturn = true;
                    break;

            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region fcvEdtAccionReAsiganarCodigoSeccionObjetos: Reasignar a seccion por defecto objetos
        /// <summary>
        /// <para>Reasignar el codigo de seccion al valor seccion por defecto, cuando el codigo seccion del objeto</para>
        /// <para>no existe porque fue eliminada o no asigado</para>
        /// </summary>
        public void fcvEdtAccionReAsiganarCodigoSeccionObjetos()
        {
            foreach (var lobReg in tmpObjetos)
            {
                var lobSecc = fobPrnSeccionLocateDefault(lobReg.SeccionCodigo);
                if (lobSecc != null)
                {
                    lobReg.SeccionCodigo = lobSecc.Codigo;
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        //- GESTION ASIGNACION DE CAMPOS PARA GUARDADO EN TABLAS
        //------------------------------------------------------------
        #region fcvEdtCamposTablasReAsiganar: Asignar/marcar campos relacionados con objetos
        /// <summary>
        /// <para>Asignar/marcar campos relacionados con objetos para guardar datos en tablas</para>
        /// </summary>
        public void fcvEdtCamposTablasReAsiganar()
        {
            var lcrCampos = "-TEXTBOX-TEXTBOXDATE-TEXTBOXTIME-RICHTEXTBOX-" +
                            "COMBOBOX-TEXTBOXRELCOD-MULTICHKBOX-MULTIGROUPRADIOBUTTON-"+
                            "CONTROLFRAMINGHAM-CONTROLIMC-CONTROLEADAUDICIONLENGUAJE-"+
                            "CONTROLEADMOTRICIFINOADAPT-CONTROLEADMOTRICIGRUESA-"+
                            "CONTROLEADPERSONALSOCIAL-CONTROLEADGRAFPUNTUACION-";

            foreach (var lobReg in tmpObjetos)
            {
                // Saber si es un campo que guarda datos
                if (!String.IsNullOrWhiteSpace(lobReg.NombreVariable))
                {
                    if (lcrCampos.Contains(lobReg.TipoObjeto))
                    {
                        var lobRefObj = lobReg;
                        flgEdtCamposTablasAsiganar(ref lobRefObj);
                    }
                }
            }
        }
        #endregion
        #region flgEdtCamposTablasAsiganar: Buscar y marcar los campos como asignados a objetos
        /// <summary>
        /// <para>Buscar y marcar los campos como asignados a objetos</para>
        /// <para>cuando el objeto no esta relacionado con un campo se le asigna uno</para>
        /// </summary>
        public bool flgEdtCamposTablasAsiganar(ref ClassXmlPropObjeto tobjObjeto)
        {
            var llgAsigando = false;
            var lcrAccion = "NA";
            ModeloHclregisevcampo lobCampoCod = null;
            ModeloHclregisevcampo lobCampoDes = null;
            var lcrCampo = tobjObjeto.Binding != null? tobjObjeto.Binding.ToLower(): string.Empty;
            //tobjObjeto.Binding = ""; //------------------------------------------- OJO SOLO PARA REASIGNAR 
            // saber si esta asigando correctamente
            if (!String.IsNullOrWhiteSpace(tobjObjeto.Binding))
            {
                lobCampoCod = tmpCamposBindig.FirstOrDefault(x => x.Hcl_nomcam_hccm == lcrCampo);
                lcrAccion = lobCampoCod == null ? "NA" : "RELACION";
            }
            if (lobCampoCod == null)
            {
                //var lcrTipoObjeto = tobjObjeto.TipoObjeto;
                //lcrTipoObjeto = lcrTipoObjeto == "CONTROLFRAMINGHAM" || lcrTipoObjeto == "CONTROLIMC" ? "TEXTBOX" : lcrTipoObjeto;

                lobCampoCod = fobEdtCamposTablasBuscarLibre(tobjObjeto.TipoObjeto);
                lcrAccion = lobCampoCod == null ? "NA" : "NUEVO";
            }

            // Verificar si se encontro campo disponible o asignado al objeto
            if (lcrAccion != "NA")
            {
                if (lobCampoCod.Hcl_relobj_hccm == "2")
                {
                    // campo libre 
                    llgAsigando = true;
                }
                else if (lobCampoCod.Grp_nomobj_grob == tobjObjeto.Name.ToLower())
               {
                    // cuando campo esta asigando al mismo objeto todo ok
                    llgAsigando = true;
               }
            }

            // Hacer la asignacion de datos
            if (llgAsigando == true)
            {
                ClassXmlPropObjeto lobObjRelDes = null;
                lobCampoCod.Hcl_relobj_hccm = "1"; // marcar como usado/Relacionado con objeto
                lobCampoCod.Grp_nomobj_grob = tobjObjeto.Name.ToLower();
                tobjObjeto.Binding          = fcrEdtCamposMyNombreCampo(lobCampoCod.Hcl_nomcam_hccm);
                tobjObjeto.BindingTabla     = lobCampoCod.Hcl_nomarc_hccm;

                // Cuanod es un objeto "TEXTBOXREL"
                if (tobjObjeto.TipoObjeto == "TEXTBOXRELCOD")
                {
                    // Buscar el valor descripcion
                    lobObjRelDes = fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", tobjObjeto.Parent).FirstOrDefault();
                }

                // Buscar el campo descripcion 
                lobCampoDes = fobEdtCamposTablasBuscarDesCampoRCodigo(lobCampoCod.Hcl_nomcam_hccm);
                if (lobCampoDes != null)
                {
                    tobjObjeto.BindingDescripcion = fcrEdtCamposMyNombreCampo(lobCampoDes.Hcl_nomcam_hccm);
                    lobCampoDes.Hcl_relobj_hccm = "1"; // marcar como usado/Relacionado con objeto
                    lobCampoDes.Grp_nomobj_grob = tobjObjeto.Name.ToLower();

                    if (tobjObjeto.TipoObjeto == "TEXTBOXRELCOD")
                    {
                        if (lobObjRelDes != null)
                        {
                            lobObjRelDes.Binding        = fcrEdtCamposMyNombreCampo(lobCampoDes.Hcl_nomcam_hccm);
                            lobObjRelDes.BindingTabla   = lobCampoDes.Hcl_nomarc_hccm;
                            lobCampoDes.Grp_nomobj_grob = lobObjRelDes.Name.ToLower();
                        }
                    }
                }

            }
            else 
            {
                // Error al asignar campo
                tobjObjeto.Binding      = "ERROR";
                tobjObjeto.BindingTabla = "ERROR";
            }

            return llgAsigando;
        }
        #endregion
        #region fcrEdtCamposMyNombreCampo: Genera el nombre del campo con la primera letra en mayuscula
        /// <summary>
        /// <para>Genera el nombre del campo con la primera letra en mayuscula</para>
        /// <para>esto para compatibilidad del guardado modo reflexion (InvokeMember) para cada campo</para>
        /// </summary>
        public String fcrEdtCamposMyNombreCampo(String tcrNombreCampo)
        {
            var lnuLen = tcrNombreCampo.Length;

            // Primera letra en mayuscula y resto en minuscula
            tcrNombreCampo =  tcrNombreCampo.Substring(0,1).ToUpper() + tcrNombreCampo.Substring(1,lnuLen - 1).ToLower();
            return tcrNombreCampo;
        }
        #endregion
        #region fobEdtCamposTablasBuscarLibre: Buscar campos libres para asignar a objetos
        /// <summary>
        /// <para>Buscar campos no marcados como usados para asignar a objetos y poder guardar en tablas</para>
        /// </summary>
        public ModeloHclregisevcampo fobEdtCamposTablasBuscarLibre(String tcrTipoObjeto)
        {
            ModeloHclregisevcampo lobRegistro = null;

            #region datos de objetos
            switch (tcrTipoObjeto)
            {
                case "TEXTBOX":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "TEXTBOXDATE":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOXDATE-") && x.Hcl_relobj_hccm == "2");
                    break;
                #endregion

                case "TEXTBOXTIME":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOXTIME-") && x.Hcl_relobj_hccm == "2");
                    break;
                #endregion

                case "RICHTEXTBOX":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-RICHTEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                #endregion

                case "COMBOBOX":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-COMBOBOX-") &&
                                                                 x.Hcl_tipcam_hccm.Contains("CODIGO") && x.Hcl_relobj_hccm == "2");
                    break;
                #endregion

                case "TEXTBOXRELCOD":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOXREL-") &&
                                                                 x.Hcl_tipcam_hccm.Contains("CODIGO") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "TEXTBOXRELDES":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOXREL-") &&
                                                                 x.Hcl_tipcam_hccm.Contains("DESCRIPCION") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "MULTICHKBOX":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-CHECKBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                #endregion

                case "CONTROLFRAMINGHAM":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLIMC":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLEADAUDICIONLENGUAJE":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLEADMOTRICIFINOADAPT":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLEADMOTRICIGRUESA":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLEADPERSONALSOCIAL":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "CONTROLEADGRAFPUNTUACION":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOX-") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                case "MULTIGROUPRADIOBUTTON":
                    #region Buscar datos
                    lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-RADIOBUTTON-") &&
                                                                 x.Hcl_tipcam_hccm.Contains("CODIGO") && x.Hcl_relobj_hccm == "2");
                    break;
                    #endregion

                default:

                    #region Buscar datos TexboxRel
                    if (tcrTipoObjeto == "TEXTBOXREL")
                    {
                        lobRegistro = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains("-TEXTBOXREL-") &&
                                                                     x.Hcl_tipcam_hccm.Contains("CODIGO") && x.Hcl_relobj_hccm == "2");
                    }
                    #endregion
                    break;
            }
            #endregion
            return lobRegistro;
        }
        #endregion
        #region fobEdtCamposTablasBuscarDesCampoRCodigo: Buscar campos descripcion dado nombre del campo
        /// <summary>
        /// <para>Buscar campos descripcion dado el nombre del campo Codigo que esta relacionado con el objeto</para>
        /// </summary>
        public ModeloHclregisevcampo fobEdtCamposTablasBuscarDesCampoRCodigo(String tcrNombreCampo)
        {
            ModeloHclregisevcampo lobRegistro = null;

            var lobReg = tmpCamposBindig.FirstOrDefault(x => x.Hcl_nomcam_hccm == tcrNombreCampo);
            if (lobReg != null) 
            {
                var lobRegx = tmpCamposBindig.FirstOrDefault(x => x.Hcl_grupos_hccm.Contains(lobReg.Hcl_grupos_hccm) && 
                                                             x.Hcl_tipcam_hccm.Contains("DESCRIPCION") && x.Hcl_idecam_hccm == lobReg.Hcl_idecam_hccm);
                if (lobRegx != null) { lobRegistro = lobRegx; }
            }
            return lobRegistro;
        }
        #endregion
        #region flgEdtCamposLiberarCampo: Liberar campos marcados 
        /// <summary>
        /// <para>Liberar campos /Quitar enlace del campo con algun objeto relacionado</para>
        /// </summary>
        public bool flgEdtCamposLiberarCampo(String tcrNombreCampo)
        {
            var llgReturn = false;
            var lobCampoCod = tmpCamposBindig.FirstOrDefault(x => x.Hcl_nomcam_hccm == tcrNombreCampo.ToLower());
            if (lobCampoCod != null)
            {
                llgReturn = true;
                lobCampoCod.Hcl_relobj_hccm = "2"; // marcar como Libre
                lobCampoCod.Grp_nomobj_grob = String.Empty;
            }
            return llgReturn;
        }
        #endregion
        //---------------------------------------------------------------
        // ACTUALIZAR PROPIEDADES DE OBJETOS EN TEMPORAL DESDE EDICION
        //---------------------------------------------------------------
        #region SetPropiedadObjeto: Actualizar las porpiedades del objeto
        /// <summary>
        /// <para>Actualizar las propiedades del objeto en temporal desde la vista diseño</para>
        /// </summary>
        public void SetPropiedadObjeto(String tcrNombreObjeto, String tcrPropiedad, String tcrValor)
        {
            #region Propiedades
            switch (tcrPropiedad.Trim())
            {

                case "Titulo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Titulo = tcrValor;
                    break;

                case "ToolTip":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).ToolTip = tcrValor;
                    break;

                case "TituloVisible":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TituloVisible = tcrValor;
                    break;

                case "Parent":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Parent = tcrValor;
                    break;

                case "OrdenVista":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).OrdenVista = tcrValor;
                    break;
                    
                case "TabIndex":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TabIndex = tcrValor;
                    break;

                case "CampoReporte":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).CampoReporte = tcrValor;
                    break;

                case "Pagina":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Pagina = tcrValor;
                    break;

                case "CambiarTabs":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).CambiarTabs = tcrValor;
                    break;

                case "Focusable":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Focusable = tcrValor;
                    break;

                case "IsEnabled":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).IsEnabled = tcrValor;
                    break;

                case "Visibility":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Visibility = tcrValor;
                    break;

                case "VerticalAlignment":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).VerticalAlignment = tcrValor;
                    break;

                case "HorizontalAlignment":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).HorizontalAlignment = tcrValor;
                    break;

                case "Style":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Style = tcrValor;
                    break;

                case "Margin":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Margin = tcrValor;
                    break;

                case "Border":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Border = tcrValor;
                    break;

                case "Foreground":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Foreground = tcrValor;
                    break;

                case "BorderBrush":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).BorderBrush = tcrValor;
                    break;

                case "Background":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Background = tcrValor;
                    break;

                case "Height":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Height = tcrValor;
                    break;

                case "Width":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Width = tcrValor;
                    break;

                case "Top":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Top = tcrValor;
                    break;

                case "Left":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Left = tcrValor;
                    break;

                case "FontFamily":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).FontFamily = tcrValor;
                    break;

                case "FontStyle":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).FontStyle = tcrValor;
                    break;

                case "FontWeight":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).FontWeight = tcrValor;
                    break;

                case "Decorations":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Decorations = tcrValor;
                    break;

                case "FontSize":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).FontSize = tcrValor;
                    break;

                case "AlineacionTexto":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).AlineacionTexto = tcrValor;
                    break;

                case "Orientacion":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Orientacion = tcrValor;
                    break;

                case "Angulo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Angulo = tcrValor;
                    break;

                case "Binding":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Binding = tcrValor;
                    break;

                case "BindingDescripcion":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).BindingDescripcion = tcrValor;
                    break;

                case "BindingTabla":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).BindingTabla = tcrValor;
                    break;

                case "IsReadOnly":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).IsReadOnly = tcrValor;
                    break;

                case "PrnSiValidar":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).PrnSiValidar = tcrValor;
                    break;

                case "PrnValorDefault":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).PrnValorDefault = tcrValor;
                    break;

                case "PrnValorPreView":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).PrnValorPreView = tcrValor;
                    break;

                case "PrnMostrarTitulo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).PrnMostrarTitulo = tcrValor;
                    break;
                    
                case "VariablePublica":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).VariablePublica = tcrValor;
                    break;

                case "VarGestPosVector":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).VarGestPosVector = tcrValor;
                    break;

                case "ValorDefault":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).ValorDefault = tcrValor;
                    break;

                case "Indice":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Indice = tcrValor;
                    break;

                case "TipoControl":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TipoControl = tcrValor;
                    break;

                case "SeccionCodigo":
                    //tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SeccionCodigo = tcrValor;
                    var lobReg = tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto));
                    lobReg.SeccionCodigo = tcrValor;

                    // porner seccion para objetos dentro de objetos Grupos checkbox radio button y TextboRel
                    if (lobReg.TipoObjeto == "TEXTBOXREL" || lobReg.TipoObjeto == "MULTIGROUPCHKBOX" || lobReg.TipoObjeto == "MULTIGROUPRADIOBUTTON")
                    {
                        var lobTmpObj = fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNombreObjeto);
                        if (lobTmpObj != null)
                        {
                            foreach (var lobx in lobTmpObj)
                            {
                                lobx.SeccionCodigo = tcrValor;
                            }
                        }

                    }
                    break;
                    
                case "TotalItems":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TotalItems = tcrValor;
                    break;

                case "TipoDato":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TipoDato = tcrValor;
                    break;

                case "TipoOrigenDatos":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TipoOrigenDatos = tcrValor;
                    break;

                case "TablaOrigen":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).TablaOrigen = tcrValor;
                    break;

                case "CodigoEtiqueta":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).CodigoEtiqueta = tcrValor;
                    break;
                    
                case "RangoInicial":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RangoInicial = tcrValor;
                    break;

                case "RangoFinal":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RangoFinal = tcrValor;
                    break;

                case "IsRequerido":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).IsRequerido = tcrValor;
                    break;

                case "FechaDefault":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).FechaDefault = tcrValor;
                    break;

                case "HoraDefault":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).HoraDefault = tcrValor;
                    break;

                case "SiMultiSet":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SiMultiSet = tcrValor;
                    break;

                case "RefVarDatosTipo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RefVarDatosTipo = tcrValor;
                    break;

                case "RefVarDatosCampo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RefVarDatosCampo = tcrValor;
                    break;

                case "RecursoArchivoTipo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RecursoArchivoTipo = tcrValor;
                    break;

                case "RecursoArchivoCodigo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RecursoArchivoCodigo = tcrValor;
                    break;

                case "RecursoArchivoUri":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RecursoArchivoUri = tcrValor;
                    break;

                case "RecursoArchivoNombre":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RecursoArchivoNombre = tcrValor;
                    break;

                case "Stretch":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).Stretch = tcrValor;
                    break;

                case "StretchDirection":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).StretchDirection = tcrValor;
                    break;

                case "SiValorCalculado":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SiValorCalculado = tcrValor;
                    break;

                case "NombreVariable":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).NombreVariable = tcrValor;
                    break;

                case "SiMostrarEnMuro":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SiMostrarEnMuro = tcrValor;
                    break;

                case "SiFiltroBusqueda":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SiFiltroBusqueda = tcrValor;
                    break;

                case "SiImprimir":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).SiImprimir = tcrValor;
                    break;
                    
                case "RadioButtonGroupName":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).RadioButtonGroupName = tcrValor;
                    break;

                case "ObjetoModo":
                    tmpObjetos.FirstOrDefault(x => x.Name.Equals(tcrNombreObjeto)).ObjetoModo = tcrValor;
                    break;
                    
            }
            #endregion
        }
        #endregion
        #region SetPropiedadPlantilla: Actualizar las porpiedades de la plantilla
        /// <summary>
        /// <para>Actualizar las porpiedades de la plantilla</para>
        /// </summary>
        public void SetPropiedadPlantilla(String tcrCodigoPlantilla, String tcrPropiedad, String tcrValor)
        {
            #region Propiedades
            switch (tcrPropiedad.Trim())
            {
                case "Name":
                    tmpPlantilla.FirstOrDefault(x => x.Codigo.Equals(tcrCodigoPlantilla)).Name = tcrValor;
                    break;

                case "HL7Formato":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).HL7Formato = tcrValor;
                    break;

                case "VersionSistema":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).VersionSistema = tcrValor;
                    break;

                case "VersionPlantilla":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).VersionPlantilla = tcrValor;
                    break;

                case "Clave":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).Clave = tcrValor;
                    break;

                case "CodigoGrupo":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).CodigoGrupo = tcrValor;
                    break;

                case "TipoFormato":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).TipoFormato = tcrValor;
                    break;

                case "VistaEnMuroHc":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).VistaEnMuroHc = tcrValor;
                    break;

                case "GenerObjPagina":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).GenerObjPagina = tcrValor;
                    break;

                case "GenerSecObjeto":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).GenerSecObjeto = tcrValor;
                    break;

                case "ImagenIcono":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).ImagenIcono = tcrValor;
                    break;

                case "PlantTipoImpresion":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantTipoImpresion = tcrValor;
                    gcrPlantillaTipoImpresion = tcrValor;
                    break;

                case "PlantTituloReporte":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantTituloReporte = tcrValor;
                    gcrPlantillaTituloReporte = tcrValor;
                    break;

                case "PlantTipoHojaReporte":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantTipoHojaReporte = tcrValor;
                    gcrPlantillaTipoHojaReporte = tcrValor;
                    break;

                case "PlantillaWidth":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantillaWidth = tcrValor;
                    break;

                case "PlantillaHeight":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantillaHeight = tcrValor;
                    break;

                case "MargenVertical":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).MargenVertical = tcrValor;
                    break;

                case "MargenHorizontal":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).MargenHorizontal = tcrValor;
                    break;

                case "PlantillaBackground":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PlantillaBackground = tcrValor;
                    break;

                case "PrefijoObjetos":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).PrefijoObjetos = tcrValor;
                    break;

                case "EstiloModoDis":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).EstiloModoDis = tcrValor;
                    break;

                case "EstiloModoEdt":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).EstiloModoEdt = tcrValor;
                    break;

                case "EstiloModoVis":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).EstiloModoVis = tcrValor;
                    break;

                case "ImagenFondoCodigo":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).ImagenFondoCodigo = tcrValor;
                    break;

                case "ImagenFondoUri":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).ImagenFondoUri = tcrValor;
                    break;

                case "ImagenFondoNombre":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).ImagenFondoNombre = tcrValor;
                    break;

                case "SeparadorDecimal":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).SeparadorDecimal = tcrValor;
                    break;

                case "Navegador":
                    tmpPlantilla.FirstOrDefault(x => x.Name.Equals(tcrCodigoPlantilla)).Navegador = tcrValor;
                    break;
            }
            #endregion
        }
        #endregion
        //---------------------------------------------------------------
        // GENERAR OBJETOS PLANTILLA
        //---------------------------------------------------------------
        #region GENERAR OBJETOS PLANTILLA
        #region flgAddNuevoObjeto: Generar Nuevo objeto en vista Diseño
        /// <summary>
        /// <para>Genera un nuevo objeto segun el tipo dado en parametro tcrTipoObjeto desde la vista diseño</para>
        /// <para>dentro del contenedor seleccionado en la posicion: tduLeftX / tduTopY.</para>
        /// </summary>
        public bool flgAddNuevoObjeto(String tcrTipoObjeto, Double tduLeftX, Double tduTopY)
        {
            gnuPlantillaGenerSecObjeto++;
            tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();

            var llgReturn = false;
            var lcrPrefijo = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo = new ClassXmlPropObjeto();

            refRegObjActivo.Left = "0";
            refRegObjActivo.Top  = "0";
            refRegObjActivo.SeccionCodigo = gcrSeccionDefault;
            if (tcrTipoObjeto != "PAGINA")
            {
                refRegObjActivo.Left = tduLeftX.ToString().Trim();
                refRegObjActivo.Top = tduTopY.ToString().Trim();
            }
            refRegObjActivo.HorizontalAlignment = "Left";
            refRegObjActivo.VerticalAlignment   = "Top";
            refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
            refRegObjActivo.Navegador           = refTreeObj.Navegador;
            refRegObjActivo.CodigoPlantilla     = refTreeObj.CodigoPlantilla;

            #region objetos
            switch (tcrTipoObjeto.ToUpper())
            {
                case "PAGINA":
                    #region objeto
                    llgReturn = true;
                    gnuPlantillaGenerObjPagina++;
                    tmpPlantilla.FirstOrDefault().GenerObjPagina = gnuPlantillaGenerObjPagina.ToString().Trim();

                    refRegObjActivo.Name                = "objPagina" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Titulo pagina";
                    refRegObjActivo.TipoObjeto          = "PAGINA";
                    refRegObjActivo.ClaseBase           = "Canvas";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = "NA";
                    refRegObjActivo.ObjetoParentZona    = "NA";
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 1;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.VerticalAlignment   = "Top";
                    refRegObjActivo.NameContenedor      = "objCPagina" + lcrPrefijo;
                    refRegObjActivo.Pagina              = gnuPlantillaGenerObjPagina.ToString().Trim();
                    refRegObjActivo.Height              = gnuPlantillaHeight.ToString().Trim();
                    refRegObjActivo.Width               = gnuPlantillaWidth.ToString().Trim();
                    refRegObjActivo.Parent              = "this";
                    refRegObjActivo.Background          = "White";
                    refRegObjActivo.SiImprimir          = "True";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoPagina();
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();

                    #endregion
                    break;

                case "ZONA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objZona" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Titulo";
                    refRegObjActivo.Height              = "170";
                    refRegObjActivo.Width               = "500";
                    refRegObjActivo.Parent              = refTreeObj.Pagina.Name;
                    refRegObjActivo.TipoObjeto          = "ZONA";
                    refRegObjActivo.ClaseBase           = "GroupBox";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = "NA";
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 2;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.NameContenedor      = "objCZona" + lcrPrefijo;
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.Background          = "Transparent";
                    refRegObjActivo.SiImprimir          = "True";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fcvAddObjetoZona();
                    refRegObjActivo.RefContenedorObjeto = refTreeObj.ContenedorZona;
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "TEXTBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "txtTextBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto";
                    refRegObjActivo.FontFamily          = "Arial";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.AlineacionTexto     = "Left";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.BorderBrush         = "#FF34C4EE";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "TEXTBOX";
                    refRegObjActivo.ClaseBase           = "TextBox";
                    refRegObjActivo.TipoDato            = "TEXTO";
                    refRegObjActivo.TipoOrigenDatos     = "CAPTURA";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoTextBox();
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "RICHTEXTBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "txtRichTextBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto";
                    refRegObjActivo.FontFamily          = "Arial";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.AlineacionTexto     = "Justify";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.BorderBrush         = "#FF34C4EE";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "RICHTEXTBOX";
                    refRegObjActivo.ClaseBase           = "RichTextBox";
                    refRegObjActivo.TipoDato            = "TEXTO";
                    refRegObjActivo.TipoOrigenDatos     = "CAPTURA";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "1";
                    refRegObjActivo.SiMultiSet          = "False";

                    // Generar objeto Tipo TextoBox para simular el control RichTextBox en modo diseño
                    refRegObjActivo.RefObjeto = fobjAddObjetoTextBox(); // no se llama a la funcion fobjAddObjetoRichTextBox()
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "TEXTBOXDATE":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlDate" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Captura datos fecha";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.BorderBrush         = "#FF34C4EE";
                    refRegObjActivo.Height              = "25";
                    refRegObjActivo.Width               = "144";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "TEXTBOXDATE";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlFecha();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "TEXTBOXTIME":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlTime" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Captura datos tipo hora";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.BorderBrush         = "#FF34C4EE";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "25";
                    refRegObjActivo.Width               = "144";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "TEXTBOXTIME";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlHora();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "COMBOBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "cboComboBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "ComboBox";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "COMBOBOX";
                    refRegObjActivo.ClaseBase           = "ComboBox";
                    refRegObjActivo.TipoDato            = "TEXTO";
                    refRegObjActivo.TipoOrigenDatos     = "COLECCION";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoComboBox();
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "BUTTON":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "cmdBoton" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto Boton";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "50";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "BUTTON";
                    refRegObjActivo.ClaseBase           = "Button";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoButton();
                    #endregion
                    break;

                case "TEXTBLOCK":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "lblTextBlock" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Etiqueta texto";
                    refRegObjActivo.FontFamily          = "Arial";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.AlineacionTexto     = "Left";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "50";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "TEXTBLOCK";
                    refRegObjActivo.ClaseBase           = "TextBlock";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoTextBlock();
                    #endregion
                    break;

                case "RADIOBUTTON":
                    llgReturn = true;
                    break;

                case "CHECKBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "chkCheckBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto titulo";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CHECKBOX";
                    refRegObjActivo.ClaseBase           = "CheckBox";
                    refRegObjActivo.TipoDato            = "TEXTOLOGICO";
                    refRegObjActivo.TipoOrigenDatos     = "CAPTURA";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoCheckBox();
                    //tmpObjetos.Add(refRegObjActivo);
                    #endregion
                    break;

                case "GROUPBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objGrupoGroupBox" + lcrPrefijo;
                    refRegObjActivo.NameContenedor      = "objCGrupoGroupBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Grupo de objetos";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Height              = "150";
                    refRegObjActivo.Width               = "200";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "GROUPBOX";
                    refRegObjActivo.ClaseBase           = "GroupBox";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 4;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoGroupBox();
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "TEXTBOXREL":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objGrupoTextBoxRel" + lcrPrefijo;
                    refRegObjActivo.NameContenedor      = "objCGrupoTextBoxRel" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Text Box Relación";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "45";
                    refRegObjActivo.Width               = "350";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "TEXTBOXREL";
                    refRegObjActivo.ClaseBase           = "GroupBox";
                    refRegObjActivo.TablaOrigen         = "TDIA";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 4;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Background          = "#19A9A9FB";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    var lcrNombreObj = refRegObjActivo.Name;
                    refRegObjActivo.RefObjeto = fobjAddObjetoGroupBox();
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    flgAddNuevoObjetoRel();
                    tmpObjetosAux = fobRegSelectParenTreeObjeto("OBJETOS", lcrNombreObj, 0);
                    #endregion
                    break;

                case "CONTROLADMISION":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlAdmision" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Datos admisión paciente";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "200";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLADMISION";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaAdmision();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLFRAMINGHAM":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlFramingham" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Test de Framingham";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "430";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLFRAMINGHAM";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaFramingHam();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLIMC":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlIMC" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Indice de Masa corporal (IMC)";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "50";
                    refRegObjActivo.Width               = "500";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLIMC";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaImc();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLEADAUDICIONLENGUAJE":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsEscalaEadAudicionLenguage" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Test Escala Audicion y lenguaje";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "1020";
                    refRegObjActivo.Width               = "710";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLEADAUDICIONLENGUAJE";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlEscalaEadAudicionLenguage();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLEADMOTRICIFINOADAPT":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsEscalaEadMotriFinoAdaptativa" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Test Escala Motricidad Fina";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "1020";
                    refRegObjActivo.Width               = "710";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLEADMOTRICIFINOADAPT";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlEscalaEadMotriFinoAdaptativa();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLEADMOTRICIGRUESA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlEscalaEadMotricidadGruesa" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Test Escala Motricidad gruesa";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "1020";
                    refRegObjActivo.Width               = "710";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLEADMOTRICIGRUESA";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlEscalaEadMotricidadGruesa();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLEADPERSONALSOCIAL":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlEscalaEadPersonalSocial" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Test Escala Personal social";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "1020";
                    refRegObjActivo.Width               = "710";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLEADPERSONALSOCIAL";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlEscalaEadPersonalSocial();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLEADGRAFPUNTUACION":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlEscalaEadPuntuacion" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Grafica Escala de puintuación";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "1020";
                    refRegObjActivo.Width               = "800";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLEADGRAFPUNTUACION";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaEscalaEadPuntuacion();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLFIRMAPROFESIONAL":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlFirmaProf" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Datos del profesional medico que atiende";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "90";
                    refRegObjActivo.Width               = "280";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLFIRMAPROFESIONAL";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlFirmaProfesional();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLHOJAADMISION":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlHojaAdmision" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Hoja de Admisión Paciente";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "500";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLHOJAADMISION";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlHojaAdmision();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLADMITIDO":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlAdmitido" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Datos paciente admitido";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "140";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLADMITIDO";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaAdmitido();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLTRIAGE":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlTriage" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Datos triage de urgencias";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "560";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLTRIAGE";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlVistaTriage();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLUSUATENDIDO":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlUsuAtendido" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Datos usuario en base de datos";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "120";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLUSUATENDIDO";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlUsuarioAtendido();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "CONTROLCAPTURA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objCrtsControlCaptura" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Control captura datos Ventana auxiliar";
                    refRegObjActivo.TituloVisible       = "False";
                    refRegObjActivo.Height              = "600";
                    refRegObjActivo.Width               = "720";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "CONTROLCAPTURA";
                    refRegObjActivo.ClaseBase           = "UserControl";
                    refRegObjActivo.TipoControl         = "MEDI";               // Medicamentos
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 3;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "4";
                    refRegObjActivo.Border              = "0";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoControlCaptura();

                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "MULTIGROUPCHKBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objGrupoMultiChkBox" + lcrPrefijo;
                    refRegObjActivo.NameContenedor      = "objCGrupoMultiChkBox" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Seleccion Multiples opciones";
                    refRegObjActivo.Height              = "150";
                    refRegObjActivo.Width               = "200";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "MULTIGROUPCHKBOX";
                    refRegObjActivo.ClaseBase           = "GroupBox";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 4;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Border              = "1";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoGroupBox();
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    #endregion
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objGrupoMultiRButton" + lcrPrefijo;
                    refRegObjActivo.NameContenedor      = "objCGrupoMultiRButton" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Seleccion unica";
                    refRegObjActivo.Height              = "150";
                    refRegObjActivo.Width               = "200";
                    refRegObjActivo.Parent              = refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "MULTIGROUPRADIOBUTTON";
                    refRegObjActivo.ClaseBase           = "GroupBox";
                    refRegObjActivo.TipoDato            = "TEXTO";
                    refRegObjActivo.TipoOrigenDatos     = "COLECCION";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = "NA";
                    refRegObjActivo.ObjetoNivel         = 4;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.Border              = "1";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoGroupBox();
                    //- Espacio para el TabIndex del contenedor
                    gnuPlantillaGenerSecObjeto++;
                    tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "MULTICHKBOX":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "chkMultiOp" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto titulo";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.IntIndexAux         = gnuPlantillaGenerSecObjeto;            // indice temporal para luego generarl el Indice real
                    refRegObjActivo.Parent              = refTreeObj.Grupo.Name;
                    refRegObjActivo.TipoObjeto          = "MULTICHKBOX";
                    refRegObjActivo.ClaseBase           = "CheckBox";
                    refRegObjActivo.TipoDato            = "TEXTOLOGICO";
                    refRegObjActivo.TipoOrigenDatos     = "CAPTURA";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.Grupo.Name;
                    refRegObjActivo.ObjetoNivel =        5;
                    refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
                    refRegObjActivo.CampoReporte        = "3";
                    refRegObjActivo.SiMultiSet          = "False";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoCheckBox();
                    //tmpObjetos.Add(refRegObjActivo);
                    // Asignar campos
                    flgEdtCamposTablasAsiganar(ref refRegObjActivo);
                    #endregion
                    break;

                case "MULTIRADIOBUTTON":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "objRadioButton" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Texto titulo";
                    refRegObjActivo.FontSize            = "12";
                    refRegObjActivo.Height              = "24";
                    refRegObjActivo.Width               = "130";
                    refRegObjActivo.IntIndexAux         = gnuPlantillaGenerSecObjeto;            // indice temporal para luego generarl el Indice real
                    refRegObjActivo.Parent              = refTreeObj.Grupo.Name;
                    refRegObjActivo.TipoObjeto          = "MULTIRADIOBUTTON";
                    refRegObjActivo.ClaseBase           = "RadioButton";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.Grupo.Name;
                    refRegObjActivo.ObjetoNivel         = 5;
                    refRegObjActivo.RadioButtonGroupName = refTreeObj.Grupo.Name;
                    refRegObjActivo.CampoReporte        = "3";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoRadioButton();
                    //tmpObjetos.Add(refRegObjActivo);
                    #endregion
                    break;

                case "IMAGEN":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "imgImagen" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Imagen";
                    refRegObjActivo.Height              = "90";
                    refRegObjActivo.Width               = "90";
                    refRegObjActivo.Stretch             = "Fill";
                    refRegObjActivo.StretchDirection    = "Both";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "IMAGEN";
                    refRegObjActivo.ClaseBase           = "Image";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.RecursoArchivoTipo  = "IMAGEN";
                    refRegObjActivo.RecursoArchivoCodigo= "IMG0001";
                    refRegObjActivo.RecursoArchivoUri   = @"GaleriaRecursos\Imagenes\Plantillas";
                    refRegObjActivo.RecursoArchivoNombre= "Edt_controles_imagensimple.png";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoImage();
                    #endregion
                    break;

                case "RECTANGULO":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name                = "recRectangulo" + lcrPrefijo;
                    refRegObjActivo.Titulo              = "Rectangulo";
                    refRegObjActivo.Height              = "60";
                    refRegObjActivo.Width               = "90";
                    refRegObjActivo.Background          = "White";
                    refRegObjActivo.BorderBrush         = "DarkBlue";
                    refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto          = "RECTANGULO";
                    refRegObjActivo.ClaseBase           = "Rectangle";
                    refRegObjActivo.ObjetoEstado        = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte        = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoRectangle();
                    //tmpObjetos.Add(refRegObjActivo);
                    #endregion
                    break;

                case "ELIPSE":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "elpEllipse" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Circulo";
                    refRegObjActivo.Height = "40";
                    refRegObjActivo.Width = "80";
                    refRegObjActivo.Border = "1";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "ELIPSE";
                    refRegObjActivo.ClaseBase = "Ellipse";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoEllipse();
                    //tmpObjetos.Add(refRegObjActivo);
                    #endregion
                    break;

                case "LINEA-HORIZONTAL":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "linLineaHorizontal" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Linea Horizontal";
                    refRegObjActivo.Height = "40";
                    refRegObjActivo.Width = "40";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "LINEA-HORIZONTAL";
                    refRegObjActivo.ClaseBase = "Line";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoLineaHorizontal();
                    #endregion
                    break;

                case "LINEA-VERTICAL":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "linLineVertical" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Linea Vertical";
                    refRegObjActivo.Height = "40";
                    refRegObjActivo.Width = "40";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "LINEA-VERTICAL";
                    refRegObjActivo.ClaseBase = "Line";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoLineaVertical();
                    #endregion
                    break;

                case "LINEA-DERECHA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "linLineaDerecha" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Linea inclinada a la derecha";
                    refRegObjActivo.Height = "40";
                    refRegObjActivo.Width = "40";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "LINEA-DERECHA";
                    refRegObjActivo.ClaseBase = "Line";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoLineaDerecha();
                    #endregion
                    break;

                case "LINEA-IZQUIERDA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "linLineaIzquierda" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Linea inclinada a la Izquierda";
                    refRegObjActivo.Height = "40";
                    refRegObjActivo.Width = "40";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "LINEA-IZQUIERDA";
                    refRegObjActivo.ClaseBase = "Line";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoLineaIzquierda();
                    #endregion
                    break;

                case "FLECHA-DERECHA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "fleFlechaDerecha" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Flecha a la Derecha";
                    refRegObjActivo.Height = "100";
                    refRegObjActivo.Width = "100";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "FLECHA-DERECHA";
                    refRegObjActivo.ClaseBase = "Polygon";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoFlechaDerecha();
                    #endregion
                    break;

                case "FLECHA-IZQUIERDA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "fleFlechaIzquierda" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Flecha a la Izquierda";
                    refRegObjActivo.Height = "100";
                    refRegObjActivo.Width = "100";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "FLECHA-IZQUIERDA";
                    refRegObjActivo.ClaseBase = "Polygon";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoFlechaIzquierda();
                    #endregion
                    break;

                case "FLECHA-ARRIBA":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "fleFlechaArriba" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Flecha a Arriba";
                    refRegObjActivo.Height = "100";
                    refRegObjActivo.Width = "100";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "FLECHA-ARRIBA";
                    refRegObjActivo.ClaseBase = "Polygon";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoFlechaArriba();
                    #endregion
                    break;

                case "FLECHA-ABAJO":
                    #region objeto
                    llgReturn = true;
                    refRegObjActivo.Name = "fleFlechaAbajo" + lcrPrefijo;
                    refRegObjActivo.Titulo = "Flecha Abajo";
                    refRegObjActivo.Height = "100";
                    refRegObjActivo.Width = "100";
                    refRegObjActivo.Border = "2";
                    refRegObjActivo.VerticalAlignment = "Center";
                    refRegObjActivo.HorizontalAlignment = "Center";
                    refRegObjActivo.Background = "White";
                    refRegObjActivo.BorderBrush = "DarkBlue";
                    refRegObjActivo.Parent = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
                    refRegObjActivo.TipoObjeto = "FLECHA-ABAJO";
                    refRegObjActivo.ClaseBase = "Polygon";
                    refRegObjActivo.ObjetoEstado = "ACTIVO";
                    refRegObjActivo.ObjetoParentPagina = refTreeObj.Pagina.Name;
                    refRegObjActivo.ObjetoParentZona = refTreeObj.Zona.Name;
                    refRegObjActivo.ObjetoParentGrupo = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
                    refRegObjActivo.ObjetoNivel = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
                    refRegObjActivo.CampoReporte = "4";
                    // Generar objeto 
                    refRegObjActivo.RefObjeto = fobjAddObjetoFlechaAbajo();
                    #endregion
                    break;

                case "POLYLINE":
                    llgReturn = true;
                    break;

                case "POLYGON":
                    llgReturn = true;
                    break;

            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgAddNuevoObjeto: Generar Nuevo objeto Imagen
        /// <summary>
        /// <para>Funcion Sobrecargada Genera un nuevo objeto segun el tipo dado en parametro tcrTipoObjeto</para>
        /// <para>para galeria de imagenes predefinidas en una plantilla</para>
        /// </summary>
        public bool flgAddNuevoObjeto(String tcrTipoObjeto, Double tduLeftX, Double tduTopY, 
                                      String tcHeight, String tcrWidth,  String tcrRuta, String tcrNombreArchivo)
        {
            gnuPlantillaGenerSecObjeto++;
            tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();

            var lcrPrefijo = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo = new ClassXmlPropObjeto();

            refRegObjActivo.Left                = tduLeftX.ToString().Trim();
            refRegObjActivo.Top                 = tduTopY.ToString().Trim();
            refRegObjActivo.HorizontalAlignment = "Left";
            refRegObjActivo.VerticalAlignment   = "Top";
            refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
            refRegObjActivo.Navegador           = refTreeObj.Navegador;
            refRegObjActivo.CodigoPlantilla     = refTreeObj.CodigoPlantilla;

            #region objeto
            refRegObjActivo.Name                 = "imgImagen" + lcrPrefijo;
            refRegObjActivo.Titulo               = "Imagen";
            refRegObjActivo.Height               = tcHeight;
            refRegObjActivo.Width                = tcrWidth;
            refRegObjActivo.Stretch              = "Fill";
            refRegObjActivo.StretchDirection     = "Both";
            refRegObjActivo.Parent               = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
            refRegObjActivo.TipoObjeto           = "IMAGEN";
            refRegObjActivo.ClaseBase            = "Image";
            refRegObjActivo.ObjetoEstado         = "ACTIVO";
            refRegObjActivo.RecursoArchivoTipo   = "IMAGEN";
            refRegObjActivo.RecursoArchivoCodigo = "IMG0001";
            refRegObjActivo.RecursoArchivoUri    = tcrRuta;
            refRegObjActivo.RecursoArchivoNombre = tcrNombreArchivo;
            refRegObjActivo.ObjetoParentPagina   = refTreeObj.Pagina.Name;
            refRegObjActivo.ObjetoParentZona     = refTreeObj.Zona.Name;
            refRegObjActivo.ObjetoParentGrupo    = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
            refRegObjActivo.ObjetoNivel          = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
            refRegObjActivo.CampoReporte         = "4";
            // Generar objeto 
            refRegObjActivo.RefObjeto = fobjAddObjetoImage();
            #endregion

            return true;
        }
        #endregion
        #region Objeto Pagina
        private Canvas fobjAddObjetoPagina()
        {
            Canvas lobPagina = new Canvas();

            WrapPanel lobContenedorPagina = new WrapPanel();
            lobPagina.Children.Add(lobContenedorPagina);

            refTreeObj.Pagina           = lobPagina;
            refTreeObj.ContenedorPagina = lobContenedorPagina;
            refTreeObj.Zona             = null;
            refTreeObj.Grupo            = null;
            refTreeObj.ContenedorZona   = null;
            refTreeObj.ContenedorGrupo  = null;
            refTreeObj.NivelObjetoSelect = 1;
            //- Propiedades

            SetPropiedadPagina(ref lobPagina, ref lobContenedorPagina);
            //-----------------------------------------------
            //- registrar el contenedor en Temporarl de Objetos
            var RegContenedor = new ClassXmlPropObjeto();
            RegContenedor.RefObjeto             = lobContenedorPagina;
            RegContenedor.Name                  = refRegObjActivo.NameContenedor;
            RegContenedor.Height                = lobContenedorPagina.Height.ToString();
            RegContenedor.Width                 = lobContenedorPagina.Width.ToString();
            RegContenedor.Parent                = refRegObjActivo.Name;
            RegContenedor.TipoObjeto            = "CONTENEDOR";
            RegContenedor.ClaseBase             = "WrapPanel";
            RegContenedor.ObjetoEstado          = "ACTIVO";
            RegContenedor.ObjetoParentPagina    = refRegObjActivo.Name;
            RegContenedor.ObjetoParentZona      = "NA";
            RegContenedor.ObjetoParentGrupo     = "NA";
            RegContenedor.ObjetoNivel           = 1;
            RegContenedor.CampoReporte          = "4";
            RegContenedor.Background            = "Transparent";
            RegContenedor.Navegador             = refRegObjActivo.Navegador;
            RegContenedor.CodigoPlantilla       = refRegObjActivo.CodigoPlantilla;
            RegContenedor.ObjetoModo            = refRegObjActivo.ObjetoModo;
            //-----------------------------------------------
            RegContenedor.IntTabIndex   = refRegObjActivo.IntTabIndex + 1;
            RegContenedor.TabIndex      = RegContenedor.IntTabIndex.ToString().Trim();
            //-----------------------------------------------
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);
            tmpObjetos.Add(RegContenedor);

            refTreeObj.Plantilla.Children.Add(lobPagina);
            return lobPagina;
        }
        private void SetPropiedadPagina(ref Canvas tobPagina, ref WrapPanel tobContenedorPagina)
        {
            tobPagina.Name                      = refRegObjActivo.Name;
            tobPagina.Height                    = Convert.ToDouble(refRegObjActivo.Height);
            tobPagina.Width                     = Convert.ToDouble(refRegObjActivo.Width);
            tobPagina.Background                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobPagina.HorizontalAlignment       = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobPagina.VerticalAlignment         = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobPagina.Background                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            if (refRegObjActivo.Navegador == "ETIQUETA")
            {
                tobPagina.Margin = new Thickness(2, 2, 0, 0);
            }
            else 
            {
                tobPagina.Margin = new Thickness(10, 10, 0, 10);
            }
            refRegObjActivo.RefObjeto           = tobPagina;
            refRegObjActivo.RefContenedorObjeto = tobContenedorPagina;
            //-----------------------------------------------
            //- Contenedor de la Pagina
            tobContenedorPagina.Name        = refRegObjActivo.NameContenedor;
            tobContenedorPagina.Background  = Brushes.Transparent;
            SetPropiedadMargenContenedorPagina(ref tobPagina, ref tobContenedorPagina);
        }
        public void SetPropiedadMargenContenedorPagina(ref Canvas tobPagina, ref WrapPanel tobContenedorPagina)
        {
            var lduHeight   = Convert.ToDouble(tobPagina.Height) - gnuPlantillaMargenVertical;
            var lduWidth    = Convert.ToDouble(tobPagina.Width) - gnuPlantillaMargenHorizontal;

            if (lduHeight > 0 && lduWidth > 0)
            {
                tobContenedorPagina.Height  = lduHeight;
                tobContenedorPagina.Width   = lduWidth;

                String lnuMarginHori = ((tobPagina.Width - tobContenedorPagina.Width) / 2).ToString().Trim();
                String lnuMarginVert = ((tobPagina.Height - tobContenedorPagina.Height) / 2).ToString().Trim();
                tobContenedorPagina.Margin = EdtUtilidades.SetMargin(lnuMarginHori + "," + lnuMarginVert + "," + lnuMarginHori + "," + lnuMarginVert);
            }
        }
        #endregion
        #region Objeto Zona
        private GroupBox fcvAddObjetoZona()
        {
            GroupBox lobZona            = new GroupBox();
            Canvas lobContenedorZona    = new Canvas();
            lobZona.Content             = lobContenedorZona;

            refTreeObj.Zona                 = lobZona;
            refTreeObj.ContenedorZona       = lobContenedorZona;
            refTreeObj.Grupo                = null;
            refTreeObj.ContenedorGrupo      = null;
            refTreeObj.NivelObjetoSelect    = 2;
            //- Propiedades
            SetPropiedadZona(ref lobZona, ref lobContenedorZona);
            //-----------------------------------------------
            //- registrar el contenedor en Temporarl de Objetos
            var RegContenedor                   = new ClassXmlPropObjeto();
            RegContenedor.RefObjeto             = lobContenedorZona;
            RegContenedor.Name                  = refRegObjActivo.NameContenedor;
            RegContenedor.Parent                = refRegObjActivo.Name;
            RegContenedor.TipoObjeto            = "CONTENEDOR";
            RegContenedor.ClaseBase             = "Canvas";
            RegContenedor.ObjetoEstado          = "ACTIVO";
            RegContenedor.ObjetoParentPagina    = refRegObjActivo.ObjetoParentPagina;
            RegContenedor.ObjetoParentZona      = refRegObjActivo.Name;
            RegContenedor.ObjetoParentGrupo     = "NA";
            RegContenedor.ObjetoNivel           = 2;
            RegContenedor.CampoReporte          = "4";
            RegContenedor.Background            = "Transparent";
            RegContenedor.Navegador             = refRegObjActivo.Navegador;
            RegContenedor.CodigoPlantilla       = refRegObjActivo.CodigoPlantilla;
            RegContenedor.ObjetoModo            = refRegObjActivo.ObjetoModo;
            //-----------------------------------------------
            RegContenedor.IntTabIndex   = refRegObjActivo.IntTabIndex + 1;
            RegContenedor.TabIndex      = RegContenedor.IntTabIndex.ToString().Trim();
            //-----------------------------------------------
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);
            tmpObjetos.Add(RegContenedor);
            //-----------------------------------------------
            refTreeObj.ContenedorPagina.Children.Add(lobZona);
            return lobZona;
        }
        private void SetPropiedadZona(ref GroupBox tobZona, ref Canvas tobContenedorZona)
        {
            //- Propiedades
            tobZona.Name                        = refRegObjActivo.Name;
            tobZona.Header                      = EdtUtilidades.SetTituloObjeto(refRegObjActivo.Titulo, refRegObjActivo.TituloVisible);
            tobZona.Height                      = Convert.ToDouble(refRegObjActivo.Height);
            tobZona.Width                       = Convert.ToDouble(refRegObjActivo.Width);
            tobZona.HorizontalAlignment         = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobZona.VerticalAlignment           = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobZona.Background                  = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobZona.BorderBrush                 = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            tobZona.Foreground                  = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobZona.BorderThickness             = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobZona.FontFamily                  = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobZona.FontSize                    = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobZona.FontStyle                   = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobZona.FontWeight                  = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            refRegObjActivo.RefObjeto           = tobZona;
            refRegObjActivo.RefContenedorObjeto = tobContenedorZona;
            //- Contenedor de la Zona
            tobContenedorZona.Name          = refRegObjActivo.NameContenedor;
            tobContenedorZona.Background    = Brushes.Transparent;

            Canvas.SetLeft(tobZona, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobZona, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto TextBox
        private TextBox fobjAddObjetoTextBox()
        {
            TextBox lobObjeto = new TextBox();
            //- Propiedades
            SetPropiedadTextBox(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadTextBox(ref TextBox tobObjeto)
        {
            var lcrDatosModoVista = fcrModoVisualizarObjeto(refRegObjActivo);

            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.Text                  = refRegObjActivo.Titulo;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.TabIndex              = Convert.ToInt32(refRegObjActivo.TabIndex);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush, "#FF34C4EE");
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground, Brushes.Black);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.TextAlignment         = EdtUtilidades.SetTextAlignment(refRegObjActivo.AlineacionTexto);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Focusable             = EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.Focusable, true);
            tobObjeto.TextWrapping          = TextWrapping.Wrap;
            tobObjeto.MaxLength             = 130; // POR AHORA PARA CORREGIR ERROR DE DIGITACION -------------------------------------------  OJO
            //tobObjeto.IsEnabled           = EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsEnabled, true);
            //tobObjeto.Focusable           = gcrDatosModoVista == "V" ? false : true;
            tobObjeto.IsReadOnly            = lcrDatosModoVista == "V" ? true : EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsReadOnly, false);
            refRegObjActivo.RefObjeto       = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto RichTextBox
        private RichTextBox fobjAddObjetoRichTextBox()
        {
            RichTextBox lobObjeto = new RichTextBox();
            //- Propiedades
            SetPropiedadRichTextBox(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadRichTextBox(ref RichTextBox tobObjeto)
        {
            TextRange textRange = new TextRange(tobObjeto.Document.ContentStart, tobObjeto.Document.ContentEnd);

            tobObjeto.Name                  = refRegObjActivo.Name;
            textRange.Text                  = refRegObjActivo.Titulo;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.TabIndex              = Convert.ToInt32(refRegObjActivo.TabIndex);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush, "#FF34C4EE");
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground, Brushes.Black);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.Document.LineHeight   = 3; // Espacio entre lineas
            //tobObjeto.TextAlignment       = EdtUtilidades.SetTextAlignment(refRegObjActivo.AlineacionTexto);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Focusable             = EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.Focusable, true);
            tobObjeto.IsReadOnly            = gcrDatosModoVista == "V" ? true : EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsReadOnly, false);
            tobObjeto.Language              = System.Windows.Markup.XmlLanguage.GetLanguage("es-US");
            tobObjeto.SpellCheck.IsEnabled  = true; // Corrector de ortografia
            tobObjeto.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto TextBlock
        private TextBlock fobjAddObjetoTextBlock()
        {
            TextBlock lobObjeto = new TextBlock();
            //- Propiedades
            SetPropiedadTextBlock(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadTextBlock(ref TextBlock tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.Text                  = refRegObjActivo.Titulo;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.TextWrapping          = TextWrapping.Wrap;
            tobObjeto.TextAlignment         = EdtUtilidades.SetTextAlignment(refRegObjActivo.AlineacionTexto);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto Button
        private Button fobjAddObjetoButton()
        {
            Button lobObjeto = new Button();
            //- Propiedades
            SetPropiedadButton(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadButton(ref Button tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.Content               = refRegObjActivo.Titulo;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.TabIndex              = Convert.ToInt32(refRegObjActivo.TabIndex);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush, Brushes.DarkTurquoise);
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Visibility            = gcrDatosModoVista == "V" ? Visibility.Collapsed : Visibility.Visible;
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ComboBox
        private ComboBox fobjAddObjetoComboBox()
        {
            ComboBox lobObjeto = new ComboBox();
            //- Propiedades
            SetPropiedadComboBox(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadComboBox(ref ComboBox tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.TabIndex              = Convert.ToInt32(refRegObjActivo.TabIndex);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush, Brushes.DarkTurquoise);
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Focusable             = gcrDatosModoVista == "V" ? true : EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsReadOnly, true);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto CheckBox
        private CheckBox fobjAddObjetoCheckBox()
        {
            CheckBox lobObjeto = new CheckBox();
            //- Propiedades
            SetPropiedadCheckBox(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadCheckBox(ref CheckBox tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.Content               = EdtUtilidades.SetTituloObjeto(refRegObjActivo.Titulo, refRegObjActivo.TituloVisible);
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.TabIndex              = Convert.ToInt32(refRegObjActivo.TabIndex);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Focusable             = gcrDatosModoVista == "V" ? false : EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsReadOnly, true);
            refRegObjActivo.RefObjeto       = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto RadioButton
        private RadioButton fobjAddObjetoRadioButton()
        {
            RadioButton lobObjeto = new RadioButton();
            //- Propiedades
            SetPropiedadRadioButton(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadRadioButton(ref RadioButton tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.Content               = EdtUtilidades.SetTituloObjeto(refRegObjActivo.Titulo, refRegObjActivo.TituloVisible);
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.GroupName             = String.IsNullOrWhiteSpace(refRegObjActivo.RadioButtonGroupName) ? "NA" : refRegObjActivo.RadioButtonGroupName;
            tobObjeto.Background            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.BorderBrush           = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            tobObjeto.Foreground            = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.BorderThickness       = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily            = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize              = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle             = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight            = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            tobObjeto.Focusable             = gcrDatosModoVista == "V" ? false : EdtUtilidades.SetEstadoTrueFalse(refRegObjActivo.IsReadOnly, true);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto CheckBox/RadioButton
        private Canvas fobjAddObjetoChkrButton(String tcrTipoObjeto)
        {
            Canvas lobObjeto = new Canvas();
            //- Propiedades
            SetPropiedadChkRbutton(ref lobObjeto, tcrTipoObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadChkRbutton(ref Canvas tobObjeto, String tcrTipoObjeto)
        {
            //---------------------------------
            // Contenedor
            //---------------------------------
            tobObjeto.Name                = refRegObjActivo.Name;
            tobObjeto.ToolTip             = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height              = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width               = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment   = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background          = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);

            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
            //---------------------------------
            // El Titulo 
            //---------------------------------
            TextBlock lobObTitulo = new TextBlock();
            lobObTitulo.Name        = "lblTitulo" + refRegObjActivo.Name;
            lobObTitulo.Text        = EdtUtilidades.SetTituloObjeto(refRegObjActivo.Titulo, refRegObjActivo.TituloVisible);
            lobObTitulo.Foreground  = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            lobObTitulo.FontFamily  = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            lobObTitulo.FontSize    = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            lobObTitulo.FontStyle   = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            lobObTitulo.FontWeight  = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);

            Canvas.SetLeft(lobObTitulo, 15);
            Canvas.SetTop(lobObTitulo, 0);
            tobObjeto.Children.Add(lobObTitulo);

            //---------------------------------
            // La imagen
            //---------------------------------
            if (tcrTipoObjeto == "CHK") // CHK o RBT 
            {
                Rectangle lobObjImagen = new Rectangle();
                lobObjImagen.Height = 14;
                lobObjImagen.Width = 14;
                lobObjImagen.StrokeThickness = 1;
                lobObjImagen.Stroke = Brushes.Black;

                Canvas.SetLeft(lobObjImagen, 0);
                Canvas.SetTop(lobObjImagen, 0);
                tobObjeto.Children.Add(lobObjImagen);
            }
            else
            {
                Ellipse lobObjImagen = new Ellipse();
                lobObjImagen.Height = 14;
                lobObjImagen.Width  = 14;
                lobObjImagen.StrokeThickness = 1;
                lobObjImagen.Stroke = Brushes.Black;

                Canvas.SetLeft(lobObjImagen, 0);
                Canvas.SetTop(lobObjImagen, 0);
                tobObjeto.Children.Add(lobObjImagen);
            }
        }
        #endregion
        #region Objeto GroupBox
        private GroupBox fobjAddObjetoGroupBox()
        {
            GroupBox lobObjeto = new GroupBox();
            Canvas lobContenedorGrupo = new Canvas();
            lobObjeto.Content = lobContenedorGrupo;

            refTreeObj.Grupo                = lobObjeto;
            refTreeObj.ContenedorGrupo      = lobContenedorGrupo;
            refTreeObj.NivelObjetoSelect    = 4;
            //- Propiedades
            SetPropiedadGroupBox(ref lobObjeto, ref lobContenedorGrupo);
            //-----------------------------------------------
            refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            //- registrar el contenedor en Temporarl de Objetos
            var RegContenedor = new ClassXmlPropObjeto();
            RegContenedor.RefObjeto             = lobContenedorGrupo;
            RegContenedor.Name                  = refRegObjActivo.NameContenedor;
            RegContenedor.Height                = lobObjeto.Height.ToString();
            RegContenedor.Width                 = lobObjeto.Width.ToString();
            RegContenedor.Parent                = refRegObjActivo.Name;
            RegContenedor.TipoObjeto            = "CONTENEDOR";
            RegContenedor.ClaseBase             = "Canvas";
            RegContenedor.ObjetoEstado          = "ACTIVO";
            RegContenedor.ObjetoParentPagina    = refRegObjActivo.ObjetoParentPagina;
            RegContenedor.ObjetoParentZona      = refRegObjActivo.ObjetoParentZona;
            RegContenedor.ObjetoParentGrupo     = refRegObjActivo.Name;
            RegContenedor.ObjetoNivel           = 4;
            RegContenedor.CampoReporte          = "4";
            RegContenedor.Background            = "Transparent";
            RegContenedor.Navegador             = refRegObjActivo.Navegador;
            RegContenedor.CodigoPlantilla       = refRegObjActivo.CodigoPlantilla;
            RegContenedor.ObjetoModo            = refRegObjActivo.ObjetoModo;
            //-----------------------------------------------
            RegContenedor.IntTabIndex   = refRegObjActivo.IntTabIndex + 1;
            RegContenedor.TabIndex      = RegContenedor.IntTabIndex.ToString().Trim();
            //-----------------------------------------------
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);
            tmpObjetos.Add(RegContenedor);

            return lobObjeto;
        }
        private void SetPropiedadGroupBox(ref GroupBox tobObjeto, ref Canvas lobContenedorGrupo)
        {
            //- Propiedades
            tobObjeto.Name                      = refRegObjActivo.Name;
            tobObjeto.Header                    = EdtUtilidades.SetTituloObjeto(refRegObjActivo.Titulo, refRegObjActivo.TituloVisible);
            tobObjeto.ToolTip                   = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                    = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                     = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment       = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment         = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Background                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background, Brushes.Transparent);
            tobObjeto.BorderBrush               = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            tobObjeto.Foreground                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Foreground);
            tobObjeto.BorderThickness           = EdtUtilidades.SetBorderThickness(refRegObjActivo.Border);
            tobObjeto.FontFamily                = EdtUtilidades.SetFontFamily(refRegObjActivo.FontFamily);
            tobObjeto.FontSize                  = EdtUtilidades.SetFontSize(refRegObjActivo.FontSize);
            tobObjeto.FontStyle                 = EdtUtilidades.SetFontStyle(refRegObjActivo.FontStyle);
            tobObjeto.FontWeight                = EdtUtilidades.SetFontWeight(refRegObjActivo.FontWeight);
            refRegObjActivo.RefObjeto           = tobObjeto;
            refRegObjActivo.RefContenedorObjeto = lobContenedorGrupo;

            //- Contenedor del Grupo
            lobContenedorGrupo.Name         = refRegObjActivo.NameContenedor;
            lobContenedorGrupo.Background   = Brushes.Transparent;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto Imagen
        private Image fobjAddObjetoImage()
        {
            Image lobObjeto = new Image();
            //- Propiedades
            SetPropiedadImage(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadImage(ref Image tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch               = EdtUtilidades.SetStretch(refRegObjActivo.Stretch);
            tobObjeto.StretchDirection      = EdtUtilidades.SetStretchDirection(refRegObjActivo.StretchDirection);
            refRegObjActivo.RefObjeto       = tobObjeto;

            var lobUri = new EdtUtilidades.ObjetoBitmapImage();
            lobUri.AppIpServidor    = oApp.gcrAppRecursoIpServidor;
            lobUri.AppInicioPath    = oApp.gcrAppRecursoInicioPath;
            lobUri.RutaGaleria      = refRegObjActivo.RecursoArchivoUri;
            lobUri.NombreArchivo    = refRegObjActivo.RecursoArchivoNombre;
            tobObjeto.Source = EdtUtilidades.SetBitmapImageUri(lobUri);

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto Rectangulo
        private Rectangle fobjAddObjetoRectangle()
        {
            Rectangle lobObjeto = new Rectangle();
            //- Propiedades
            SetPropiedadRectangle(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadRectangle(ref Rectangle tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch               = Stretch.Fill;
            tobObjeto.Fill                  = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            tobObjeto.StrokeThickness       = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            refRegObjActivo.RefObjeto       = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto Elipse
        private Ellipse fobjAddObjetoEllipse()
        {
            Ellipse lobObjeto = new Ellipse();
            //- Propiedades
            SetPropiedadEllipse(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadEllipse(ref Ellipse tobObjeto)
        {
            tobObjeto.Name                  = refRegObjActivo.Name;
            tobObjeto.ToolTip               = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height                = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width                 = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment   = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment     = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch               = Stretch.Fill;
            tobObjeto.StrokeThickness       = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill                  = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke                = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto       = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto LineaHorizontal
        private Line fobjAddObjetoLineaHorizontal()
        {
            Line lobObjeto = new Line();
            lobObjeto.X1 = 0;
            lobObjeto.X2 = 80;
            lobObjeto.Y1 = 20;
            lobObjeto.Y2 = 20;
            //- Propiedades
            SetPropiedadLineaHorizontal(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadLineaHorizontal(ref Line tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = HorizontalAlignment.Center;
            tobObjeto.VerticalAlignment = VerticalAlignment.Center;
            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto LineaVertical
        private Line fobjAddObjetoLineaVertical()
        {
            Line lobObjeto = new Line();
            lobObjeto.X1 = 20;
            lobObjeto.X2 = 20;
            lobObjeto.Y1 = 1;
            lobObjeto.Y2 = 80;
            //- Propiedades
            SetPropiedadLineaVertical(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadLineaVertical(ref Line tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto LineaDerecha
        private Line fobjAddObjetoLineaDerecha()
        {
            Line lobObjeto = new Line();
            lobObjeto.X1 = 80;
            lobObjeto.X2 = 1;
            lobObjeto.Y1 = 0;
            lobObjeto.Y2 = 80;
            //- Propiedades
            SetPropiedadLineaDerecha(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadLineaDerecha(ref Line tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto LineaIzquierda
        private Line fobjAddObjetoLineaIzquierda()
        {
            Line lobObjeto = new Line();
            lobObjeto.X1 = 1;
            lobObjeto.X2 = 80;
            lobObjeto.Y1 = 1;
            lobObjeto.Y2 = 80;
            //- Propiedades
            SetPropiedadLineaIzquierda(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadLineaIzquierda(ref Line tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);
            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto FlechaDerecha
        private Polygon fobjAddObjetoFlechaDerecha()
        {
            PointCollection luxPuntos = new PointCollection();
            luxPuntos.Add(new Point(80, 30));
            luxPuntos.Add(new Point(40, 0));
            luxPuntos.Add(new Point(40, 20));
            luxPuntos.Add(new Point(10, 20));
            luxPuntos.Add(new Point(10, 40));
            luxPuntos.Add(new Point(40, 40));
            luxPuntos.Add(new Point(40, 60));
            luxPuntos.Add(new Point(80, 30));

            Polygon lobObjeto = new Polygon();
            lobObjeto.Points = luxPuntos;
            //- Propiedades
            SetPropiedadFlechaDerecha(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadFlechaDerecha(ref Polygon tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);

            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto FlechaIzquierda
        private Polygon fobjAddObjetoFlechaIzquierda()
        {
            PointCollection luxPuntos = new PointCollection();
            luxPuntos.Add(new Point(60, 20));
            luxPuntos.Add(new Point(40, 20));
            luxPuntos.Add(new Point(40, 0));
            luxPuntos.Add(new Point(0, 30));
            luxPuntos.Add(new Point(40, 60));
            luxPuntos.Add(new Point(40, 40));
            luxPuntos.Add(new Point(60, 40));
            luxPuntos.Add(new Point(60, 20));

            Polygon lobObjeto = new Polygon();
            lobObjeto.Points = luxPuntos;
            //- Propiedades
            SetPropiedadFlechaIzquierda(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadFlechaIzquierda(ref Polygon tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);

            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto FlechaArriba
        private Polygon fobjAddObjetoFlechaArriba()
        {
            PointCollection luxPuntos = new PointCollection();
            luxPuntos.Add(new Point(65, 40));
            luxPuntos.Add(new Point(34, 0));
            luxPuntos.Add(new Point(0, 40));
            luxPuntos.Add(new Point(23, 40));
            luxPuntos.Add(new Point(23, 65));
            luxPuntos.Add(new Point(43, 65));
            luxPuntos.Add(new Point(43, 40));
            luxPuntos.Add(new Point(65, 40));

            Polygon lobObjeto = new Polygon();
            lobObjeto.Points = luxPuntos;
            //- Propiedades
            SetPropiedadFlechaArriba(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadFlechaArriba(ref Polygon tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);

            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto FlechaAbajo
        private Polygon fobjAddObjetoFlechaAbajo()
        {
            PointCollection luxPuntos = new PointCollection();
            luxPuntos.Add(new Point(20, 0));
            luxPuntos.Add(new Point(20, 25));
            luxPuntos.Add(new Point(0, 25));
            luxPuntos.Add(new Point(30, 70));
            luxPuntos.Add(new Point(60, 25));
            luxPuntos.Add(new Point(40, 25));
            luxPuntos.Add(new Point(40, 0));
            luxPuntos.Add(new Point(20, 0));

            Polygon lobObjeto = new Polygon();
            lobObjeto.Points = luxPuntos;
            //- Propiedades
            SetPropiedadFlechaAbajo(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        private void SetPropiedadFlechaAbajo(ref Polygon tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(refRegObjActivo.ToolTip);
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.HorizontalAlignment = EdtUtilidades.SetHorizontalAlignment(refRegObjActivo.HorizontalAlignment);
            tobObjeto.VerticalAlignment = EdtUtilidades.SetVerticalAlignment(refRegObjActivo.VerticalAlignment);

            tobObjeto.Stretch = Stretch.Fill;
            tobObjeto.StrokeThickness = EdtUtilidades.SetStrokeThickness(refRegObjActivo.Border);
            tobObjeto.Fill = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.Background);
            tobObjeto.Stroke = EdtUtilidades.SetSolidColorBrush(refRegObjActivo.BorderBrush);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));

            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

        }
        #endregion
        #region Objeto flgAddNuevoObjetoRel: Generar Nuevo objetos Relacion
        /// <summary>
        /// <para>Genera los objetos que conforman el objeto Relacion tabla</para>
        /// </summary>
        public bool flgAddNuevoObjetoRel()
        {
            var lcrPrefijoRel = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();
            //-----------------------------------------------------------
            // TexboxCodigo
            //-----------------------------------------------------------
            #region objeto
            gnuPlantillaGenerSecObjeto++;
            tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
            var lcrPrefijo = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();

            refRegObjActivo = new ClassXmlPropObjeto();
            refRegObjActivo.Name                = "txtTextBoxCod" + lcrPrefijoRel;
            refRegObjActivo.Titulo              = "Texto";
            refRegObjActivo.Height              = "24";
            refRegObjActivo.Width               = "80";
            refRegObjActivo.Left                = "0";
            refRegObjActivo.Top                 = "0";
            refRegObjActivo.HorizontalAlignment = "Left";
            refRegObjActivo.VerticalAlignment   = "Top";
            refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
            refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
            refRegObjActivo.TipoObjeto          = "TEXTBOXRELCOD";
            refRegObjActivo.ClaseBase           = "TextBox";
            refRegObjActivo.TipoDato            = "TEXTO";
            refRegObjActivo.TipoOrigenDatos     = "TABLA";
            refRegObjActivo.ObjetoEstado        = "ACTIVO";
            refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
            refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
            refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
            refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
            refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
            refRegObjActivo.CampoReporte        = "3";
            refRegObjActivo.Navegador           = refTreeObj.Navegador;
            refRegObjActivo.ObjetoModo          = "NUEVO";
            refRegObjActivo.CodigoPlantilla     = refTreeObj.CodigoPlantilla;
            // Generar objeto 
            fobjAddObjetoTextBox();
            #endregion
            //-----------------------------------------------------------
            // Boton
            //-----------------------------------------------------------
            #region objeto
            gnuPlantillaGenerSecObjeto++;
            tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
            lcrPrefijo = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();

            refRegObjActivo = new ClassXmlPropObjeto();
            refRegObjActivo.Name                = "cmdBotonRel" + lcrPrefijoRel;
            refRegObjActivo.Titulo              = "...";
            refRegObjActivo.Height              = "24";
            refRegObjActivo.Width               = "28";
            refRegObjActivo.Left                = "82";
            refRegObjActivo.Top                 = "0";
            refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
            refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
            refRegObjActivo.TipoObjeto          = "BUTTON";
            refRegObjActivo.ClaseBase           = "Button";
            refRegObjActivo.ObjetoEstado        = "ACTIVO";
            refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
            refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
            refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
            refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
            refRegObjActivo.CampoReporte        = "4";
            refRegObjActivo.Navegador           = refTreeObj.Navegador;
            refRegObjActivo.CodigoPlantilla     = refTreeObj.CodigoPlantilla;
            refRegObjActivo.ObjetoModo          = "NUEVO";
            // Generar objeto 
            refRegObjActivo.RefObjeto = fobjAddObjetoButton();
            #endregion
            //-----------------------------------------------------------
            // TexboxDescripcion
            //-----------------------------------------------------------
            #region objeto
            gnuPlantillaGenerSecObjeto++;
            tmpPlantilla.FirstOrDefault().GenerSecObjeto = gnuPlantillaGenerSecObjeto.ToString().Trim();
            lcrPrefijo = gcrPlantillaPrefijoObjetos.Trim() + gnuPlantillaGenerSecObjeto.ToString().Trim();

            refRegObjActivo = new ClassXmlPropObjeto();
            refRegObjActivo.Name                = "txtTextBoxDes" + lcrPrefijoRel;
            refRegObjActivo.Titulo              = "Texto";
            refRegObjActivo.Height              = "24";
            refRegObjActivo.Width               = "230";
            refRegObjActivo.Left                = "112";
            refRegObjActivo.Top                 = "0";
            refRegObjActivo.HorizontalAlignment = "Left";
            refRegObjActivo.VerticalAlignment   = "Top";
            refRegObjActivo.TabIndex            = gnuPlantillaGenerSecObjeto.ToString().Trim();
            refRegObjActivo.IntTabIndex         = gnuPlantillaGenerSecObjeto;
            refRegObjActivo.Parent              = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : refTreeObj.Zona.Name;
            refRegObjActivo.TipoObjeto          = "TEXTBOXRELDES";
            refRegObjActivo.ClaseBase           = "TextBox";
            refRegObjActivo.Focusable           = "False";
            refRegObjActivo.TipoDato            = "TEXTO";
            refRegObjActivo.TipoOrigenDatos     = "TABLA";
            refRegObjActivo.ObjetoEstado        = "ACTIVO";
            refRegObjActivo.ObjetoParentPagina  = refTreeObj.Pagina.Name;
            refRegObjActivo.ObjetoParentZona    = refTreeObj.Zona.Name;
            refRegObjActivo.ObjetoParentGrupo   = refTreeObj.NivelObjetoSelect >= 4 ? refTreeObj.Grupo.Name : "NA";
            refRegObjActivo.ObjetoNivel         = refTreeObj.NivelObjetoSelect >= 4 ? 5 : 3;
            refRegObjActivo.NombreVariable      = "lvr" + refRegObjActivo.ClaseBase.Trim() + lcrPrefijo;
            refRegObjActivo.CampoReporte        = "3";
            refRegObjActivo.Navegador           = refTreeObj.Navegador;
            refRegObjActivo.CodigoPlantilla     = refTreeObj.CodigoPlantilla;
            refRegObjActivo.ObjetoModo          = "NUEVO";
            // Generar objeto 
            fobjAddObjetoTextBox();
            #endregion
            return true;
        }
        #endregion
        #region Objeto ControlFecha: Captura fecha
        private ControlFecha fobjAddObjetoControlFecha()
        {
            ControlFecha lobObjeto = new ControlFecha();
            //- Propiedades
            SetPropiedadControlFecha(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlFecha(ref ControlFecha tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlHora: Captura hora
        private ControlHora fobjAddObjetoControlHora()
        {
            ControlHora lobObjeto = new ControlHora();
            //- Propiedades
            SetPropiedadControlHora(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlHora(ref ControlHora tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaAdmision datos de la admision
        private ControlVistaAdmision fobjAddObjetoControlVistaAdmision()
        {
            ControlVistaAdmision lobObjeto = new ControlVistaAdmision();
            //- Propiedades
            SetPropiedadControlVistaAdmision(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaAdmision(ref ControlVistaAdmision tobObjeto)
        {
            tobObjeto.Name            = refRegObjActivo.Name;
            tobObjeto.Height          = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width           = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaAdmitido datos usuario admitido
        private ControlVistaAdmitido fobjAddObjetoControlVistaAdmitido()
        {
            ControlVistaAdmitido lobObjeto = new ControlVistaAdmitido();
            //- Propiedades
            SetPropiedadControlVistaAdmitido(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaAdmitido(ref ControlVistaAdmitido tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaTriage
        private ControlVistaTriage fobjAddObjetoControlVistaTriage()
        {
            ControlVistaTriage lobObjeto = new ControlVistaTriage();
            //- Propiedades
            SetPropiedadControlVistaTriage(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaTriage(ref ControlVistaTriage tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlUsuarioAtendido
        private ControlUsuarioAtendido fobjAddObjetoControlUsuarioAtendido()
        {
            ControlUsuarioAtendido lobObjeto = new ControlUsuarioAtendido();
            //- Propiedades
            SetPropiedadControlUsuarioAtendido(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlUsuarioAtendido(ref ControlUsuarioAtendido tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlHojaAdmision
        private ControlHojaAdmision fobjAddObjetoControlHojaAdmision()
        {
            ControlHojaAdmision lobObjeto = new ControlHojaAdmision();
            //- Propiedades
            SetPropiedadControlHojaAdmision(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlHojaAdmision(ref ControlHojaAdmision tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlCaptura
        private ControlCaptura fobjAddObjetoControlCaptura()
        {
            ControlCaptura lobObjeto = new ControlCaptura();
            //- Propiedades
            SetPropiedadControlCaptura(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlCaptura(ref ControlCaptura tobObjeto)
        {
            tobObjeto.Name            = refRegObjActivo.Name;
            tobObjeto.Height          = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width           = Convert.ToDouble(refRegObjActivo.Width);
            tobObjeto.gcrTipoControl  = refRegObjActivo.TipoControl;
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlFirmaProfesional
        private ControlFirmaProfesional fobjAddObjetoControlFirmaProfesional()
        {
            ControlFirmaProfesional lobObjeto = new ControlFirmaProfesional();
            //- Propiedades
            SetPropiedadControlFirmaProfesional(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlFirmaProfesional(ref ControlFirmaProfesional tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaFramingHam datos test Framingham
        private ControlVistaFramingHam fobjAddObjetoControlVistaFramingHam()
        {
            ControlVistaFramingHam lobObjeto = new ControlVistaFramingHam();
            //- Propiedades
            SetPropiedadControlVistaFramingHam(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaFramingHam(ref ControlVistaFramingHam tobObjeto)
        {
            tobObjeto.Name      = refRegObjActivo.Name;
            tobObjeto.Height    = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width     = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaImc datos IMC
        private ControlVistaImc fobjAddObjetoControlVistaImc()
        {
            ControlVistaImc lobObjeto = new ControlVistaImc();
            //- Propiedades
            SetPropiedadControlVistaImc(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaImc(ref ControlVistaImc tobObjeto)
        {
            tobObjeto.Name      = refRegObjActivo.Name;
            tobObjeto.Height    = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width     = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlEscalaEadAudicionLenguage Audicion y lenguaje
        private ControlEscalaEadAudicionLenguage fobjAddObjetoControlEscalaEadAudicionLenguage()
        {
            var lobObjeto = new ControlEscalaEadAudicionLenguage();
            //- Propiedades
            SetPropiedadControlEscalaEadAudicionLenguage(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlEscalaEadAudicionLenguage(ref ControlEscalaEadAudicionLenguage tobObjeto)
        {
            tobObjeto.Name              = refRegObjActivo.Name;
            tobObjeto.Height            = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width             = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto   = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlEscalaEadMotriFinoAdaptativa Motricidad Fina
        private ControlEscalaEadMotriFinoAdaptativa fobjAddObjetoControlEscalaEadMotriFinoAdaptativa()
        {
            var lobObjeto = new ControlEscalaEadMotriFinoAdaptativa();
            //- Propiedades
            SetPropiedadControlEscalaEadMotriFinoAdaptativa(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlEscalaEadMotriFinoAdaptativa(ref ControlEscalaEadMotriFinoAdaptativa tobObjeto)
        {
            tobObjeto.Name              = refRegObjActivo.Name;
            tobObjeto.Height            = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width             = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto   = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlEscalaEadMotricidadGruesa Motricidad gruesa
        private ControlEscalaEadMotricidadGruesa fobjAddObjetoControlEscalaEadMotricidadGruesa()
        {
            var lobObjeto = new ControlEscalaEadMotricidadGruesa();
            //- Propiedades
            SetPropiedadControlEscalaEadMotricidadGruesa(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlEscalaEadMotricidadGruesa(ref ControlEscalaEadMotricidadGruesa tobObjeto)
        {
            tobObjeto.Name              = refRegObjActivo.Name;
            tobObjeto.Height            = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width             = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto   = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlEscalaEadPersonalSocial Personal social
        private ControlEscalaEadPersonalSocial fobjAddObjetoControlEscalaEadPersonalSocial()
        {
            var lobObjeto = new ControlEscalaEadPersonalSocial();
            //- Propiedades
            SetPropiedadControlEscalaEadPersonalSocial(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlEscalaEadPersonalSocial(ref ControlEscalaEadPersonalSocial tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #region Objeto ControlVistaEscalaEadPuntuacion Escala de puintuación
        private ControlVistaEscalaEadPuntuacion fobjAddObjetoControlVistaEscalaEadPuntuacion()
        {
            var lobObjeto = new ControlVistaEscalaEadPuntuacion();
            //- Propiedades
            SetPropiedadControlVistaFramingHam(ref lobObjeto);
            if (refRegObjActivo.ObjetoNivel <= 3)
            {
                refTreeObj.ContenedorZona.Children.Add(lobObjeto);
            }
            else
            {
                refTreeObj.ContenedorGrupo.Children.Add(lobObjeto);
            }
            // Agregar a lista de objetos
            tmpObjetos.Add(refRegObjActivo);

            return lobObjeto;
        }
        public void SetPropiedadControlVistaFramingHam(ref ControlVistaEscalaEadPuntuacion tobObjeto)
        {
            tobObjeto.Name = refRegObjActivo.Name;
            tobObjeto.Height = Convert.ToDouble(refRegObjActivo.Height);
            tobObjeto.Width = Convert.ToDouble(refRegObjActivo.Width);
            refRegObjActivo.RefObjeto = tobObjeto;

            Canvas.SetLeft(tobObjeto, Convert.ToDouble(refRegObjActivo.Left));
            Canvas.SetTop(tobObjeto, Convert.ToDouble(refRegObjActivo.Top));
        }
        #endregion
        #endregion
        //---------------------------------------------------------------
        // GESTION TEMPORALES Y VARIABLES
        //---------------------------------------------------------------
        #region fcvGestionReiniciarValriables: Reinicia las Variables y temporales
        /// <summary>
        /// <para>Reinicia las Variables y temporales</para>
        /// </summary>
        public virtual void fcvGestionReiniciarValriables()
        {
            // Temporales de gestion
            tmpPlantilla            = new List<XmlPropPlantilla>();
            tmpEtiquetas            = new List<ClassXmlItemEtiquetas>();
            tmpSecciones            = new List<ClassXmlComboBoxItems>();
            tmpCamposRelacion       = new List<ClassXmlCamposRelacion>();
            tmpComboItems           = new List<ClassXmlComboBoxItems>();
            tmpComboItemsEliminado  = new List<ClassXmlComboBoxItems>();
            tmpObjetosRelacion      = new List<ClassXmlObjetosRelacion>();
            tmpObjetos              = new List<ClassXmlPropObjeto>();
            tmpObjetosAux           = new List<ClassXmlPropObjeto>();
            tmpObjetosAccion        = new List<ClassXmlPropObjeto>();
            tmpObjetosEliminado     = new List<ClassXmlPropObjeto>();
            tmpLogErrores           = new List<LogsErrores>();
            tmpCamposBindig         = ModeloHclregisevcampo.flsListaHclregisevcampo("");

            // referencias a registro de objeto seleccionado
            refRegObjActivo         = new ClassXmlPropObjeto();
            refTreeObj              = new ClassRefTreeObjeto();

            // Gestion edicion
            gnuTopeIdAccionEdicion = 0;
            gnuIdAccionEdicionPuntero = 0;

            // Temporales para reporte impreso
            tmpPrnDetalles = new List<TmpDatosFormatosDe>();
            lobPrnRegMa = new TmpDatosFormatosMa();

            // Datos plantilla
            #region Datos desde plantilla
            gnuPlantillaGenerObjPagina      = 0;
            gnuPlantillaGenerSecObjeto      = 0;
            gnuPlantillaHeight              = 0;
            gnuPlantillaWidth               = 0;
            gcrPlantillaNombreArchivo       = String.Empty;
            gcrPlantillaPrefijoObjetos      = String.Empty;
            gcrPlantillaNavegadorPlantilla  = "ESCRITORIO";
            gcrPlantillaObjetoModo          = "EDICION-ESCRITORIO";
            gcrPlantillaCodigoPlantilla     = String.Empty;
            gcrPlantillaSeparadorDecimal    = String.Empty;
            gnuPlantillaMargenVertical      = 60;
            gnuPlantillaMargenHorizontal    = 20;
            #endregion

        }
        #endregion
        //---------------------------------------------------------------
        // GESTION Y VALIDACION PARA VISTA DATOS EN REPORTE IMPRESORA
        //---------------------------------------------------------------
        #region flgPrnValidGenDatosImpresora: Valida y generar datos para envio a impresora
        /// <summary>
        /// <para>Realiza la validacion segun configuracion de lista ("PrnValorDefault") valores por defecto</para>
        /// <para>y decide si se enviara vista del dato a impresora</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrValor: Valor digitado que se requiere validar</para>
        /// </summary>
        public bool flgPrnValidGenDatosImpresora(ClassXmlPropObjeto tobObjeto, String tcrValor)
        {
            var llgReturn = false;
            var lcrValorAux = !String.IsNullOrWhiteSpace(tcrValor) ? tcrValor.Trim().ToUpper() : String.Empty;
            var lcrPrnValorDefault = tobObjeto.PrnValorDefault.Trim().ToUpper();

            // Para compatibilidad con True/False
            lcrPrnValorDefault = Funciones.flgExisteElemento("TRUE", ",", lcrPrnValorDefault) ? lcrPrnValorDefault + ",1" : lcrPrnValorDefault;
            lcrPrnValorDefault = Funciones.flgExisteElemento("FALSE", ",", lcrPrnValorDefault) ? lcrPrnValorDefault + ",2" : lcrPrnValorDefault;
            lcrPrnValorDefault = Funciones.flgExisteElemento("1", ",", lcrPrnValorDefault) ? lcrPrnValorDefault + ",TRUE" : lcrPrnValorDefault;
            lcrPrnValorDefault = Funciones.flgExisteElemento("2", ",", lcrPrnValorDefault) ? lcrPrnValorDefault + ",FALSE" : lcrPrnValorDefault;

            // Realizar validacion
            if (tobObjeto.PrnSiValidar == "1")
            {
                // se envian todos por defecto
                llgReturn = llgEstado(lcrValorAux);
            }
            else if (tobObjeto.PrnSiValidar == "2")
            {
                // Solo valores en lista 
                if (!String.IsNullOrWhiteSpace(tobObjeto.PrnValorDefault))
                {
                    if (Funciones.flgExisteElemento(lcrValorAux, ",", lcrPrnValorDefault))
                    {
                        llgReturn = llgEstado(lcrValorAux);
                    }

                }
                else
                {
                    llgReturn = llgEstado(lcrValorAux);
                }
            }
            else if (tobObjeto.PrnSiValidar == "3")
            {
                // Excluir cuendo exista en lista 
                if (!String.IsNullOrWhiteSpace(tobObjeto.PrnValorDefault))
                {
                    if (!Funciones.flgExisteElemento(lcrValorAux, ",", lcrPrnValorDefault))
                    {
                        llgReturn = llgEstado(lcrValorAux);
                    }
                }
                else
                {
                    llgReturn = llgEstado(lcrValorAux);
                }
            }

            return llgReturn;
        }
        public bool llgEstado(String tcrValor)
        {
            return !String.IsNullOrWhiteSpace(tcrValor) ? true : false;
        }
        #endregion
        #region fobPrnSeccionLocateDefault: devuelve un registro del tipo seccion
        /// <summary>
        /// <para>devuelve un registro del tipo seccion, cuando no lo encuentra devuelve la primera seccion por defecto</para>
        /// </summary>
        public ClassXmlComboBoxItems fobPrnSeccionLocateDefault(String tcrCodigoSeccion)
        {
            var lobSecc = tmpSecciones.FirstOrDefault(x => x.Codigo == tcrCodigoSeccion);
            if (lobSecc == null)
            {
                lobSecc = tmpSecciones.FirstOrDefault();
            }
            return lobSecc;
        }
        #endregion
        #region fobPrnSeccionLocate: devuelve un registro del tipo seccion
        /// <summary>
        /// <para>devuelve un registro del tipo seccion, cuando no lo encuentra devuelve nulo </para>
        /// </summary>
        public ClassXmlComboBoxItems fobPrnSeccionLocate(String tcrCodigoSeccion)
        {
            var lobSecc = tmpSecciones.FirstOrDefault(x => x.Codigo == tcrCodigoSeccion);
            return lobSecc;
        }
        #endregion
        #region fnuPrnSetSumaRegsitroSeccion: Suma numeros de registros para seccion
        /// <summary>
        /// <para>Genera columna sumatoria total del numeros de registros para cada seccion de la plantilla</para>
        /// <para>y devuelve la sumatoria total para dicha seccion</para>
        /// <para>tnuNumeroIncremento: Valor numerico que se sumara al total de la seccion dada en tcrCodigoSeccion</para>
        /// </summary>
        public int fnuPrnSetSumaRegsitroSeccion(String tcrCodigoSeccion, int tnuNumeroIncremento)
        {
            var lobSecc = tmpSecciones.FirstOrDefault(x => x.Codigo == tcrCodigoSeccion);
            var lnuReturn = 0;

            if (lobSecc != null)
            {
                tmpSecciones.FirstOrDefault().IntTotalRegistros += tnuNumeroIncremento;
                lnuReturn = tmpSecciones.FirstOrDefault().IntTotalRegistros;
            }
            return lnuReturn;
        }
        #endregion
        #region fnuPrnPlantTipoHojaReporteMaxCol: devuelve numero maximo de columnas configuradas para imprimir formato
        /// <summary>
        /// <para>Devuelve numero maximo de columnas permitidas para el Formato Hoja papel configurado en la plantilla</para>
        /// <para>tcrTipoHojaReporte: Codigo del formato configurado en la plantilla activa</para>
        /// <para>"01"=Hoja tamaño carta "02"=Hoja tamaño oficio "03"=...</para>
        /// </summary>
        public int fnuPrnPlantTipoHojaReporteMaxCol(String tcrTipoHojaReporte)
        {
            var lnuReturn = 5;
            #region datos de objetos
            switch (tcrTipoHojaReporte)
            {
                case "01": // Formato hoja tamaño carta con maximo 10 columnas
                    lnuReturn = 10;
                    break;

                case "02": // Formato hoja tamaño oficio con maximo 10 columnas
                    lnuReturn = 10;
                    break;

                case "03": // Futura configuracion
                    //lnuReturn = 10;
                    break;
            }
            #endregion
            return lnuReturn;
        }
        #endregion
        #region flgPrnGenerarTotalFilasPorSeccion: Calcular numero de filas del reporte por cada seccion
        /// <summary>
        /// <para>Calcular numero de filas del reporte por cada seccion, segun total registros de la seccion</para>
        /// </summary>
        public bool flgPrnGenerarTotalFilasPorSeccion()
        {
            var llgReturn = false;
            var lnuColumnas = fnuPrnPlantTipoHojaReporteMaxCol(gcrPlantillaTipoHojaReporte);

            foreach (var lobReg in tmpSecciones)
            {
                llgReturn = true;
                lobReg.IntTotalColumnas = lobReg.IntTotalColumnas == 0 ? 1 : lobReg.IntTotalColumnas;
                lobReg.IntTotalColumnas = lobReg.IntTotalColumnas > lnuColumnas ? lnuColumnas : lobReg.IntTotalColumnas;

                var lnuValor1 = lobReg.IntTotalRegistros / lobReg.IntTotalColumnas;
                var lnuValor2 = (double)lobReg.IntTotalRegistros / lobReg.IntTotalColumnas;

                lobReg.IntTotalFilas = (int)lnuValor1;
                if (lnuValor2 > lnuValor1)
                {
                    // cuando hay un valor decimal, sumar una fila
                    lobReg.IntTotalFilas++;
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgPrnReiniciarTotalRegistrosSeccion: Poner en cero los totales de registros en cada seccion
        /// <summary>
        /// <para>Poner en cero los totales de registros en cada seccion</para>
        /// </summary>
        public bool flgPrnReiniciarTotalRegistrosSeccion()
        {
            var llgReturn = false;
            foreach (var lobReg in tmpSecciones)
            {
                llgReturn = true;
                lobReg.IntTotalRegistros = 0;
                lobReg.IntTotalFilas = 0;
            }
            return llgReturn;
        }
        #endregion
        #region flgPrnOrganizarDatosImprimir: Organiza los datos segun numero de columnas vista reporte
        /// <summary>
        /// <para>Organiza los datos segun numero de columnas configuradas en vista reporte de la plantilla</para>
        /// </summary>
        public bool flgPrnOrganizarDatosImprimir()
        {
            var llgReturn = false;
            var lnuColumnas = fnuPrnPlantTipoHojaReporteMaxCol(gcrPlantillaTipoHojaReporte);

            var lcrSeccion           = String.Empty;
            var lcrAuxSeccion        = String.Empty;
            var lnuTotalFilasSeccion = 0;
            var lnuAuxFila           = 0;
            var lnuAuxTotRegistros   = 0;
            var lnuAuxColumna        = 0;
            var lnuTotalRegSeccion   = 0;
            var lnuTotalColumnas     = 0;
            var lobSeccion = new ClassXmlComboBoxItems();
            tmpPrnDetalles = new List<TmpDatosFormatosDe>();

            tmpPrnDetallAux = (from tmp in tmpPrnDetallAux orderby tmp.Hcl_seccion_ordvista, tmp.Hcl_registro_ordvista select tmp).ToList();
            flgPrnGenerarTotalFilasPorSeccion();

            foreach (var lobReg in tmpPrnDetallAux)
            {
                lcrSeccion = lobReg.Hcl_seccion_codigo;

                if (lcrSeccion != lcrAuxSeccion)
                {
                    lobSeccion           = fobPrnSeccionLocate(lcrSeccion);
                    lnuTotalFilasSeccion = lobSeccion.IntTotalFilas;
                    lnuTotalRegSeccion   = lobSeccion.IntTotalRegistros;
                    lnuTotalColumnas     = lobSeccion.IntTotalColumnas;
                    lnuAuxFila           = 1;
                    lnuAuxColumna        = 1;
                }
                else
                {
                    lnuAuxFila++;

                    if (lnuAuxFila > lnuTotalFilasSeccion)
                    {
                        lnuAuxFila = 1;
                        lnuAuxColumna++;
                    }

                    // Validar para no permitir valores en ultimas columnas de ultima fila que no deberian tener valores
                    lnuAuxTotRegistros = ((lnuAuxFila - 1) * lnuTotalColumnas) + lnuAuxColumna;
                    if (lnuAuxTotRegistros > lnuTotalRegSeccion)
                    {
                        lnuAuxFila = 1;
                        lnuAuxColumna++;
                    }
                }
                // Registrar datos en temporal
                lobReg.Hcl_seccion_columna = lobSeccion.IntTotalColumnas.ToString().Trim();
                flgPrnOrganizarDatosAddRegistro(lobReg, lnuAuxFila, lnuAuxColumna);

                lcrAuxSeccion = lcrSeccion;
            }
            return llgReturn;
        }
        #endregion
        #region flgPrnOrganizarDatosAddRegistro: Adicionar el dato en la fila y columna correspondiente
        /// <summary>
        /// <para>Adicionar el dato en la fila y columna correspondiente en el temporal "tmpPrnDetalles"</para>
        /// </summary>
        public bool flgPrnOrganizarDatosAddRegistro(TmpDatosFormatosDe tobRegistro, int tnuAuxFila, int AuxColumna)
        {
            var llgReturn = true;
            var lcrLlaveRegistro = tobRegistro.Hcl_seccion_codigo.Trim() + "R" + tnuAuxFila.ToString().Trim();

            // Buscar el registro 
            var lobReg = tmpPrnDetalles.FirstOrDefault(x => x.Hcl_secuen_registro == lcrLlaveRegistro);
            if (lobReg == null)
            {
                // Generar nuevo registro
                var lobRegAux = new TmpDatosFormatosDe();

                //lobRegAux.Hcl_seccion_codigo = tobRegistro.Hcl_seccion_codigo;
                lobRegAux.Hcl_seccion_codigo = (tobRegistro.Hcl_seccion_ordvista + 300).ToString().Trim() + tobRegistro.Hcl_seccion_codigo.Trim();
                lobRegAux.Hcl_seccion_titulo = tobRegistro.Hcl_seccion_titulo;
                lobRegAux.Hcl_seccion_ordvista = tobRegistro.Hcl_seccion_ordvista;
                lobRegAux.Hcl_secuen_registro = lcrLlaveRegistro;
                lobRegAux.Hcl_registro_ordvista = tobRegistro.Hcl_registro_ordvista;
                lobRegAux.Hcl_seccion_columna = tobRegistro.Hcl_seccion_columna;
                lcvAsignarValorcolumna(AuxColumna, tobRegistro, ref lobRegAux);

                tmpPrnDetalles.Add(lobRegAux);
            }
            else
            {
                lcvAsignarValorcolumna(AuxColumna, tobRegistro, ref lobReg);
            }

            return llgReturn;
        }
        // asignar el valor segun la columna que corresponde
        public void lcvAsignarValorcolumna(int NumeroColumna, TmpDatosFormatosDe tobRegistro, ref TmpDatosFormatosDe tobRegistroNuevo)
        {
            switch (NumeroColumna)
            {
                case 1:
                    tobRegistroNuevo.Hcl_titulo_dato1 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato1 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 2:
                    tobRegistroNuevo.Hcl_titulo_dato2 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato2 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 3:
                    tobRegistroNuevo.Hcl_titulo_dato3 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato3 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 4:
                    tobRegistroNuevo.Hcl_titulo_dato4 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato4 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 5:
                    tobRegistroNuevo.Hcl_titulo_dato5 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato5 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 6:
                    tobRegistroNuevo.Hcl_titulo_dato6 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato6 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 7:
                    tobRegistroNuevo.Hcl_titulo_dato7 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato7 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 8:
                    tobRegistroNuevo.Hcl_titulo_dato8 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato8 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 9:
                    tobRegistroNuevo.Hcl_titulo_dato9 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato9 = tobRegistro.Hcl_valor_dato1;
                    break;

                case 10:
                    tobRegistroNuevo.Hcl_titulo_dato10 = tobRegistro.Hcl_titulo_dato1;
                    tobRegistroNuevo.Hcl_valor_dato10 = tobRegistro.Hcl_valor_dato1;
                    break;
            }
        }
        #endregion
        //---------------------------------------------------------------
        // GESTION STRING XML PLANTILLAS
        //---------------------------------------------------------------
        #region fcrStringXmlCargarPlantilla: Cargar en tipo String los xml diseño
        /// <summary>
        /// <para>Carga en un solo String los datos XML contenidos en campos memos de la tabla maestro plantillas</para>
        /// </summary>
        public String fcrStringXmlCargarPlantilla(VersionPlantilla tobRegistro)
        {
            var lcrStrin = tobRegistro.Grp_xmlpla_grpv;
            var lcrValor2 = tobRegistro.Grp_xmlplb_grpv != null ? tobRegistro.Grp_xmlplb_grpv : String.Empty;
            var lcrValor3 = tobRegistro.Grp_xmlplc_grpv != null ? tobRegistro.Grp_xmlplc_grpv : String.Empty;
            var lcrValor4 = tobRegistro.Grp_xmlpld_grpv != null ? tobRegistro.Grp_xmlpld_grpv : String.Empty;

            lcrStrin = lcrStrin + lcrValor2 + lcrValor3 + lcrValor4;

            return lcrStrin;
        }
        #endregion
        #region fcrStringXmlDividirTextoPlantilla: Dividir el texto XML para cargar en campos al guardar
        /// <summary>
        /// <para>Dividir el texto XML para cargar en campos al guardar</para>
        /// </summary>
        public VersionPlantilla fcrStringXmlDividirTextoPlantilla(String tcrTextoXmlPlantilla)
        {
            var lcrValor1 = tcrTextoXmlPlantilla;
            var lcrValor2 = String.Empty;
            var lcrValor3 = String.Empty;
            var lcrValor4 = String.Empty;

            var lobRegistro   = new VersionPlantilla();
            int lnuTotalChar  = tcrTextoXmlPlantilla.Length;
            int lnuMaximoChr  = 800000; // tamaño maximo en caracteres cada bloque
            float lnuPromedio = lnuTotalChar / lnuMaximoChr; // Para saber en cuantos bloques de archivos se va a guardar

            if (lnuPromedio <= 1)  // Cabe en un solo campo
            {
                lcrValor1 = tcrTextoXmlPlantilla;
            }
            else if (lnuPromedio > 1 && lnuPromedio <= 2)
            {
                lcrValor1 = tcrTextoXmlPlantilla.Substring(0,lnuMaximoChr);
                lcrValor2 = tcrTextoXmlPlantilla.Substring(lnuMaximoChr, lnuTotalChar - lnuMaximoChr);
            }
            else if (lnuPromedio > 2 && lnuPromedio <= 3)
            {
                lcrValor1 = tcrTextoXmlPlantilla.Substring(0, lnuMaximoChr);
                lcrValor2 = tcrTextoXmlPlantilla.Substring(lnuMaximoChr, lnuMaximoChr);
                lcrValor3 = tcrTextoXmlPlantilla.Substring((lnuMaximoChr * 2), lnuTotalChar - (lnuMaximoChr * 2));
            }
            else
            { 
                // aqui  -> Cuatro bloques  es el maximo permitido por ahora

                var lnuRestoFin = lnuTotalChar - (lnuMaximoChr * 3);

                lcrValor1 = tcrTextoXmlPlantilla.Substring(0, lnuMaximoChr);
                lcrValor2 = tcrTextoXmlPlantilla.Substring(lnuMaximoChr, lnuMaximoChr);
                lcrValor3 = tcrTextoXmlPlantilla.Substring((lnuMaximoChr * 2), lnuMaximoChr);
                lcrValor4 = tcrTextoXmlPlantilla.Substring((lnuMaximoChr * 3), lnuRestoFin);
            }

            lobRegistro.Grp_xmlpla_grpv = lcrValor1;
            lobRegistro.Grp_xmlplb_grpv = lcrValor2;
            lobRegistro.Grp_xmlplc_grpv = lcrValor3;
            lobRegistro.Grp_xmlpld_grpv = lcrValor4;

            return lobRegistro;
        }
        #endregion

    }
}
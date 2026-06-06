//- MARMOTA-GENCODE: VERSION 2.0 - 07/11/2016 03:47:43 PM
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
using GalaSoft.MvvmLight.Messaging;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invmaearticulos</para>
    /// <para>DESCRIPCION:
    ///  Contiene el manual de artículos, los cuales alimentaran el
    ///  inventario en la tabla maestro de inventario.
    /// </para>
    /// </summary>
    public class VistaModeloInvmaestroarticuloBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV002";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public String gcrSIS_PerfilCmdADD = String.Empty;
        public String gcrSIS_PerfilCmdEDT = String.Empty;
        public String gcrSIS_PerfilCmdSAV = String.Empty;
        public String gcrSIS_PerfilCmdDEL = String.Empty;
        public String gcrSIS_PerfilCmdPRN = String.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public String gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private String _gcrUsuIdUsuario = String.Empty;
        public String GcrUsuIdUsuario
        {
            get { return _gcrUsuIdUsuario; }
            set
            {
                if (_gcrUsuIdUsuario == value) { return; }
                _gcrUsuIdUsuario = value;
                RaisePropertyChanged(gcrNomProp_UsuIdUsuario);
            }
        }
        #endregion
        #region  Vista Modelo Propiedad: gcrUsuCodigoPerfil
        public String gcrNomProp_UsuCodigoPerfil = "GcrUsuCodigoPerfil";
        private String _gcrUsuCodigoPerfil = String.Empty;
        public String GcrUsuCodigoPerfil
        {
            get { return _gcrUsuCodigoPerfil; }
            set
            {
                if (_gcrUsuCodigoPerfil == value) { return; }
                _gcrUsuCodigoPerfil = value;
                RaisePropertyChanged(gcrNomProp_UsuCodigoPerfil);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //-Variables Control Edicion 
        //------------------------------------------------
        #region Variables de control Edicion
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();

        #region Vista Modelo Propiedad: glgSIS_ModoDefault
        /// <summary>
        /// glgSIS_ModoDefault: Variable para el modo por defecto
        /// del VistaModelo. 
        /// </summary>
        public String glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
        private bool _glgSIS_ModoDefault = true;
        public bool GlgSIS_ModoDefault
        {
            get { return _glgSIS_ModoDefault; }
            set
            {
                if (_glgSIS_ModoDefault == value) { return; }
                _glgSIS_ModoDefault = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoDefault);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ModoAdicion
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
        public String glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        public bool GlgSIS_ModoAdicion
        {
            get { return _glgSIS_ModoAdicion; }
            set
            {
                if (_glgSIS_ModoAdicion == value) { return; }
                _glgSIS_ModoAdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAdicion);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
        public String glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        public bool GlgSIS_ModoEdicion
        {
            get { return _glgSIS_ModoEdicion; }
            set
            {
                if (_glgSIS_ModoEdicion == value) { return; }
                _glgSIS_ModoEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicion);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        /// <summary>
        /// <para>GlgSIS_ModoEdicionMedicamento: Variable para el control del modo edicion en campos</para>
        /// <para>cuando el articulo es un medicamento</para>
        /// </summary>
        public String glgNomProp_SIS_ModoEdicionMedicamento = "GlgSIS_ModoEdicionMedicamento";
        private bool _glgSIS_ModoEdicionMedicamento = false;
        public bool GlgSIS_ModoEdicionMedicamento
        {
            get { return _glgSIS_ModoEdicionMedicamento; }
            set
            {
                if (_glgSIS_ModoEdicionMedicamento == value) { return; }
                _glgSIS_ModoEdicionMedicamento = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicionMedicamento);
            }
        }
        #endregion
        #endregion
        #region Vista Modelo Propiedad: gcrSIS_FormModoPopup
        /// <summary>
        /// gcrSIS_FormModoPopup: Variable para el control del modo
        /// adicion(ADD), edicion(EDT) Vista (VIE), cuando el formulario es llamado desde 
        /// un fomulario principal para adicionar un registro en particula o 
        /// para modificar uno ya existente.
        /// el valor por defecto es: DFL =Valor por defecto
        /// </summary>
        public const String gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private String _gcrSIS_FormModoPopup = "DFL";
        public String GcrSIS_FormModoPopup
        {
            get { return _gcrSIS_FormModoPopup; }
            set
            {
                if (_gcrSIS_FormModoPopup == value) { return; }
                _gcrSIS_FormModoPopup = value;
                RaisePropertyChanged(gcrNomProp_SIS_FormModoPopup);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_FormModoPopupIni
        /// <summary>
        /// glgSIS_FormModoPopupIni: Variable para control del momento de cargue inicial 
        /// del formulario en modo Popup
        /// </summary>
        public String gcrNomProp_SIS_FormModoPopupIni = "GlgSIS_FormModoPopupIni";
        private bool _glgSIS_FormModoPopupIni = true;
        public bool GlgSIS_FormModoPopupIni
        {
            get { return _glgSIS_FormModoPopupIni; }
            set
            {
                if (_glgSIS_FormModoPopupIni == value) { return; }
                _glgSIS_FormModoPopupIni = value;
                RaisePropertyChanged(gcrNomProp_SIS_FormModoPopupIni);
            }
        }
        #endregion
        //------------------------------------------------
        //-Variables Filtro activo de datos
        //------------------------------------------------
        #region Variables Filtro activo
        #region Control Filtro Propiedad: gcrFiltroAplicado
        /// <summary>
        /// gcrFiltroAplicado: Variable para saber si ya el filtro
        /// actual fue aplicado (toma el valor del filtro activo).
        /// </summary>
        public String gcrFiltroAplicado = String.Empty;
        /// <summary>
        /// gcrFiltroAplicado: Para tipos de vista artculos o medicamentos
        /// "1"=Articulos o Suministros "2"=Medicamentos "3"=Todos
        /// </summary>
        public String gcrFiltroTipoVistaBrowser = "3";
        #endregion
        #region Control Click Browser Expedientes CUM
        /// <summary>
        /// Se activa cuando se selecciona un registro de la grilla principal de expedientes
        /// </summary>
        public bool glgPressKeyExpediente = true;
        #endregion

        #region Control Filtro Propiedad: gcrFiltroDatos
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatos: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo.
        /// </summary>
        ///--------------------------------------------------------
        public const String glgNomProp_SIS_FiltroDatos = "GcrFiltroDatos";
        private String _gcrFiltroDatos = String.Empty;
        public String GcrFiltroDatos
        {
            get { return _gcrFiltroDatos; }
            set
            {
                if (_gcrFiltroDatos == value) { return; }
                _gcrFiltroDatos = value;
                RaisePropertyChanged(glgNomProp_SIS_FiltroDatos);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //INVMAEARTICULOS : Tabla Maestro Artículos
        //------------------------------------------------
        #region Notificacion campos: INVMAEARTICULOS
        #region G1Inv_secart_inar: Secuencial Unico
        public const String gcrNomProp_G1Inv_secart_inar = "G1Inv_secart_inar";
        private string _g1inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Unico</para>
        /// <para>NOMBRE: g1inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de articulo generado por el sistema
        /// </para>
        /// </summary>
        public string G1Inv_secart_inar
        {
            get { return _g1inv_secart_inar; }
            set
            {
                if (_g1inv_secart_inar == value) return;
                _g1inv_secart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secart_inar);
            }
        }
        #endregion
        #region G1Inv_tipart_inar: Tipo articulo
        public const String gcrNomProp_G1Inv_tipart_inar = "G1Inv_tipart_inar";
        private string _g1inv_tipart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Tipo articulo</para>
        /// <para>NOMBRE: g1inv_tipart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de articulo: 1=Suministro 2=Medicamentos
        /// </para>
        /// </summary>
        public string G1Inv_tipart_inar
        {
            get { return _g1inv_tipart_inar; }
            set
            {
                if (_g1inv_tipart_inar == value) return;
                _g1inv_tipart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_tipart_inar);
            }
        }
        #endregion
        #region G1Inv_codgru_ingr: Grupo Clasificación
        public const String gcrNomProp_G1Inv_codgru_ingr = "G1Inv_codgru_ingr";
        private string _g1inv_codgru_ingr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventgrupos</para>
        /// <para>CAMPO: Grupo Clasificación</para>
        /// <para>NOMBRE: g1inv_codgru_ingr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Grupo de articulos para gestion contable y clasificacion de
        /// inventarios
        /// </para>
        /// </summary>
        public string G1Inv_codgru_ingr
        {
            get { return _g1inv_codgru_ingr; }
            set
            {
                if (_g1inv_codgru_ingr == value) return;
                _g1inv_codgru_ingr = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codgru_ingr);
            }
        }
        #endregion
        #region G1Inv_codsub_insg: Subgrupo Clasificación
        public const String gcrNomProp_G1Inv_codsub_insg = "G1Inv_codsub_insg";
        private string _g1inv_codsub_insg = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventsubgru</para>
        /// <para>CAMPO: Subgrupo Clasificación</para>
        /// <para>NOMBRE: g1inv_codsub_insg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo subgrupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public string G1Inv_codsub_insg
        {
            get { return _g1inv_codsub_insg; }
            set
            {
                if (_g1inv_codsub_insg == value) return;
                _g1inv_codsub_insg = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codsub_insg);
            }
        }
        #endregion
        #region G1Inv_codaux_inar: Código Auxiliar
        public const String gcrNomProp_G1Inv_codaux_inar = "G1Inv_codaux_inar";
        private string _g1inv_codaux_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar</para>
        /// <para>NOMBRE: g1inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public string G1Inv_codaux_inar
        {
            get { return _g1inv_codaux_inar; }
            set
            {
                if (_g1inv_codaux_inar == value) return;
                _g1inv_codaux_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codaux_inar);
            }
        }
        #endregion
        #region G1Inv_codbar_inar: Código Barra
        public const String gcrNomProp_G1Inv_codbar_inar = "G1Inv_codbar_inar";
        private string _g1inv_codbar_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barra</para>
        /// <para>NOMBRE: g1inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Código de Barra Artículo
        /// </para>
        /// </summary>
        public string G1Inv_codbar_inar
        {
            get { return _g1inv_codbar_inar; }
            set
            {
                if (_g1inv_codbar_inar == value) return;
                _g1inv_codbar_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codbar_inar);
            }
        }
        #endregion
        #region G1Inv_lotref_inar: Lote o Referencia
        public const String gcrNomProp_G1Inv_lotref_inar = "G1Inv_lotref_inar";
        private string _g1inv_lotref_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: g1inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Lote o Referencia del articulo Artículo
        /// </para>
        /// </summary>
        public string G1Inv_lotref_inar
        {
            get { return _g1inv_lotref_inar; }
            set
            {
                if (_g1inv_lotref_inar == value) return;
                _g1inv_lotref_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_lotref_inar);
            }
        }
        #endregion
        #region G1Inv_regsan_inar: Registro sanitario
        public const String gcrNomProp_G1Inv_regsan_inar = "G1Inv_regsan_inar";
        private string _g1inv_regsan_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Registro sanitario</para>
        /// <para>NOMBRE: g1inv_regsan_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Registro sanitario (IMVIMA)
        /// </para>
        /// </summary>
        public string G1Inv_regsan_inar
        {
            get { return _g1inv_regsan_inar; }
            set
            {
                if (_g1inv_regsan_inar == value) return;
                _g1inv_regsan_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_regsan_inar);
            }
        }
        #endregion
        #region G1Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G1Inv_nomart_inar = "G1Inv_nomart_inar";
        private string _g1inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: g1inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public string G1Inv_nomart_inar
        {
            get { return _g1inv_nomart_inar; }
            set
            {
                if (_g1inv_nomart_inar == value) return;
                _g1inv_nomart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_nomart_inar);
            }
        }
        #endregion
        #region G1Inv_desart_inar: Descripción Artículo
        public const String gcrNomProp_G1Inv_desart_inar = "G1Inv_desart_inar";
        private string _g1inv_desart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Descripción Artículo</para>
        /// <para>NOMBRE: g1inv_desart_inar (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Descripción del larga del artículo 250 caracteres
        /// </para>
        /// </summary>
        public string G1Inv_desart_inar
        {
            get { return _g1inv_desart_inar; }
            set
            {
                if (_g1inv_desart_inar == value) return;
                _g1inv_desart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desart_inar);
            }
        }
        #endregion
        #region G1Inv_secimg_inaj: Código imagen JPG PNG
        public const String gcrNomProp_G1Inv_secimg_inaj = "G1Inv_secimg_inaj";
        private string _g1inv_secimg_inaj = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaeartimagen</para>
        /// <para>CAMPO: Código imagen JPG PNG</para>
        /// <para>NOMBRE: g1inv_secimg_inaj (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo imagen JPG o PNG que representa la grafica del articulo
        /// en vista por defecto
        /// </para>
        /// </summary>
        public string G1Inv_secimg_inaj
        {
            get { return _g1inv_secimg_inaj; }
            set
            {
                if (_g1inv_secimg_inaj == value) return;
                _g1inv_secimg_inaj = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secimg_inaj);
            }
        }
        #endregion
        #region G1Inv_simcrt_inar: Medicamento de control
        public const String gcrNomProp_G1Inv_simcrt_inar = "G1Inv_simcrt_inar";
        private string _g1inv_simcrt_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Medicamento de control</para>
        /// <para>NOMBRE: g1inv_simcrt_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Activar si el medicamento es de control: 1=Medicamento Es de
        /// control 2=Medicamento no es de control 3=No es medicamento
        /// </para>
        /// </summary>
        public string G1Inv_simcrt_inar
        {
            get { return _g1inv_simcrt_inar; }
            set
            {
                if (_g1inv_simcrt_inar == value) return;
                _g1inv_simcrt_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_simcrt_inar);
            }
        }
        #endregion
        #region G1Far_forfar_fama: Forma Farmaceutica
        public const String gcrNomProp_G1Far_forfar_fama = "G1Far_forfar_fama";
        private string _g1far_forfar_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Forma Farmaceutica</para>
        /// <para>NOMBRE: g1far_forfar_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Forma farmaceutica del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_forfar_fama
        {
            get { return _g1far_forfar_fama; }
            set
            {
                if (_g1far_forfar_fama == value) return;
                _g1far_forfar_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_forfar_fama);
            }
        }
        #endregion
        #region G1Far_concen_fama: Concentracion medicamento
        public const String gcrNomProp_G1Far_concen_fama = "G1Far_concen_fama";
        private string _g1far_concen_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Concentracion medicamento</para>
        /// <para>NOMBRE: g1far_concen_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Concentracion del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_concen_fama
        {
            get { return _g1far_concen_fama; }
            set
            {
                if (_g1far_concen_fama == value) return;
                _g1far_concen_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_concen_fama);
            }
        }
        #endregion
        #region G1Far_unimed_fama: Descripcion Unidad medida
        public const String gcrNomProp_G1Far_unimed_fama = "G1Far_unimed_fama";
        private string _g1far_unimed_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion Unidad medida</para>
        /// <para>NOMBRE: g1far_unimed_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Descripcion Unidad medida del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_unimed_fama
        {
            get { return _g1far_unimed_fama; }
            set
            {
                if (_g1far_unimed_fama == value) return;
                _g1far_unimed_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_unimed_fama);
            }
        }
        #endregion
        #region G1Far_codcum_famd: Código CUM
        public const String gcrNomProp_G1Far_codcum_famd = "G1Far_codcum_famd";
        private string _g1far_codcum_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: g1far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// </para>
        /// </summary>
        public string G1Far_codcum_famd
        {
            get { return _g1far_codcum_famd; }
            set
            {
                if (_g1far_codcum_famd == value) return;
                _g1far_codcum_famd = value;
                RaisePropertyChanged(gcrNomProp_G1Far_codcum_famd);
            }
        }
        #endregion
        #region G1Inv_gesips_inar: Activar servicio IPS
        public const String gcrNomProp_G1Inv_gesips_inar = "G1Inv_gesips_inar";
        private string _g1inv_gesips_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Activar servicio IPS</para>
        /// <para>NOMBRE: g1inv_gesips_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Activar gestion de servicios IPS, para enlace con manuales
        /// tarifarios y facturacion: 1= Activar referencia a servicio
        /// IPS 2= Inactivar referencia a servicio IPS
        /// </para>
        /// </summary>
        public string G1Inv_gesips_inar
        {
            get { return _g1inv_gesips_inar; }
            set
            {
                if (_g1inv_gesips_inar == value) return;
                _g1inv_gesips_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_gesips_inar);
            }
        }
        #endregion
        #region G1Fcm_coddig_mant: Código digitación servicio ips
        public const string gcrNomProp_G1Fcm_coddig_mant = "G1Fcm_coddig_mant";
        private string _g1fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo digitacion servicio IPS en facturacion se usa para refrenciar articulos que se
        /// venden desde facturacion medica</para>
        /// </summary>
        public string G1Fcm_coddig_mant
        {
            get { return _g1fcm_coddig_mant; }
            set
            {
                if (_g1fcm_coddig_mant == value) return;
                _g1fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_coddig_mant);
            }
        }
        #endregion
        #region G1Fcm_idesec_sips: Servicio IPS
        public const String gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo unico secuencial del servicio IPS para referencia a gestion con modulo facturacion medica, 
        /// Cuando no aplique el valor es NA y el campo de activacion INV_GESIPS_INAR = 2</para>
        /// </summary>
        public string G1Fcm_idesec_sips
        {
            get { return _g1fcm_idesec_sips; }
            set
            {
                if (_g1fcm_idesec_sips == value) return;
                _g1fcm_idesec_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idesec_sips);
            }
        }
        #endregion
        #region G1Fcm_codser_sips: Código servicio en tarifario
        public const string gcrNomProp_G1Fcm_codser_sips = "G1Fcm_codser_sips";
        private string _g1fcm_codser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g1fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public string G1Fcm_codser_sips
        {
            get { return _g1fcm_codser_sips; }
            set
            {
                if (_g1fcm_codser_sips == value) return;
                _g1fcm_codser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codser_sips);
            }
        }
        #endregion
        #region G1Far_grufar_fagf: Grupo farmaceutico
        public const String gcrNomProp_G1Far_grufar_fagf = "G1Far_grufar_fagf";
        private string _g1far_grufar_fagf = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Grupo farmaceutico</para>
        /// <para>NOMBRE: g1far_grufar_fagf (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Grupo farmaceutico cuando el articulos es un medicamento, NA
        /// Cuando no no aplique
        /// </para>
        /// </summary>
        public string G1Far_grufar_fagf
        {
            get { return _g1far_grufar_fagf; }
            set
            {
                if (_g1far_grufar_fagf == value) return;
                _g1far_grufar_fagf = value;
                RaisePropertyChanged(gcrNomProp_G1Far_grufar_fagf);
            }
        }
        #endregion
        #region G1Far_sugfar_fasg: Subgrupo farmaceutico
        public const String gcrNomProp_G1Far_sugfar_fasg = "G1Far_sugfar_fasg";
        private string _g1far_sugfar_fasg = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Subgrupo farmaceutico</para>
        /// <para>NOMBRE: g1far_sugfar_fasg (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Subgrupo farmacologico del medicamento, NA cuando no aplique
        /// </para>
        /// </summary>
        public string G1Far_sugfar_fasg
        {
            get { return _g1far_sugfar_fasg; }
            set
            {
                if (_g1far_sugfar_fasg == value) return;
                _g1far_sugfar_fasg = value;
                RaisePropertyChanged(gcrNomProp_G1Far_sugfar_fasg);
            }
        }
        #endregion
        #region G1Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G1Sis_codgme_sigr = "G1Sis_codgme_sigr";
        private string _g1sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g1sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public string G1Sis_codgme_sigr
        {
            get { return _g1sis_codgme_sigr; }
            set
            {
                if (_g1sis_codgme_sigr == value) return;
                _g1sis_codgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codgme_sigr);
            }
        }
        #endregion
        #region G1Sis_codume_sium: Medida Almacenamiento
        public const String gcrNomProp_G1Sis_codume_sium = "G1Sis_codume_sium";
        private string _g1sis_codume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: g1sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public string G1Sis_codume_sium
        {
            get { return _g1sis_codume_sium; }
            set
            {
                if (_g1sis_codume_sium == value) return;
                _g1sis_codume_sium = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codume_sium);
            }
        }
        #endregion
        #region G1Inv_codctn_intc: Contenedor de gestion
        public const String gcrNomProp_G1Inv_codctn_intc = "G1Inv_codctn_intc";
        private string _g1inv_codctn_intc = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Contenedor de gestion</para>
        /// <para>NOMBRE: g1inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tipo de Contenedor para gestion entradas y salidas del Inventario
        /// </para>
        /// </summary>
        public string G1Inv_codctn_intc
        {
            get { return _g1inv_codctn_intc; }
            set
            {
                if (_g1inv_codctn_intc == value) return;
                _g1inv_codctn_intc = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codctn_intc);
            }
        }
        #endregion
        #region G1Inv_valing_inar: Costo Unidad ingreso
        public const String gcrNomProp_G1Inv_valing_inar = "G1Inv_valing_inar";
        private float _g1inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Costo Unidad ingreso</para>
        /// <para>NOMBRE: g1inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Valor  al Ingreso a Inventario o costo de compra unidad
        /// </para>
        /// </summary>
        public float G1Inv_valing_inar
        {
            get { return _g1inv_valing_inar; }
            set
            {
                if (_g1inv_valing_inar == value) return;
                _g1inv_valing_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valing_inar);
            }
        }
        #endregion
        #region G1Inv_uvalin_inar: Ultimo costo unidad
        public const String gcrNomProp_G1Inv_uvalin_inar = "G1Inv_uvalin_inar";
        private float _g1inv_uvalin_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Ultimo costo unidad</para>
        /// <para>NOMBRE: g1inv_uvalin_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Ultimo valor costo de ingreso por compra (costo inmediatamente
        /// anterior)
        /// </para>
        /// </summary>
        public float G1Inv_uvalin_inar
        {
            get { return _g1inv_uvalin_inar; }
            set
            {
                if (_g1inv_uvalin_inar == value) return;
                _g1inv_uvalin_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_uvalin_inar);
            }
        }
        #endregion
        #region G1Inv_porive_inar: Porcentaje Incremento
        public const String gcrNomProp_G1Inv_porive_inar = "G1Inv_porive_inar";
        private float _g1inv_porive_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Porcentaje Incremento</para>
        /// <para>NOMBRE: g1inv_porive_inar (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de Incremento para Generar Precio de Venta (con
        /// Base  en Precio de Compra)
        /// </para>
        /// </summary>
        public float G1Inv_porive_inar
        {
            get { return _g1inv_porive_inar; }
            set
            {
                if (_g1inv_porive_inar == value) return;
                _g1inv_porive_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_porive_inar);
            }
        }
        #endregion
        #region G1Inv_valmov_inar: Valor Unidad Salida
        public const String gcrNomProp_G1Inv_valmov_inar = "G1Inv_valmov_inar";
        private float _g1inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Unidad Salida</para>
        /// <para>NOMBRE: g1inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Valor al Movimiento o venta este valor puede incluir porcentaje
        /// de incremento venta
        /// </para>
        /// </summary>
        public float G1Inv_valmov_inar
        {
            get { return _g1inv_valmov_inar; }
            set
            {
                if (_g1inv_valmov_inar == value) return;
                _g1inv_valmov_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valmov_inar);
            }
        }
        #endregion
        #region G1Sis_codiva_tiva: Codigo Valor I.V.A
        public const String gcrNomProp_G1Sis_codiva_tiva = "G1Sis_codiva_tiva";
        private string _g1sis_codiva_tiva = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Codigo Valor I.V.A</para>
        /// <para>NOMBRE: g1sis_codiva_tiva (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Código de IVA aplicable al Artículo
        /// </para>
        /// </summary>
        public string G1Sis_codiva_tiva
        {
            get { return _g1sis_codiva_tiva; }
            set
            {
                if (_g1sis_codiva_tiva == value) return;
                _g1sis_codiva_tiva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codiva_tiva);
            }
        }
        #endregion
        #region G1Inv_sistok_inar: Maneja stock minimo
        public const String gcrNomProp_G1Inv_sistok_inar = "G1Inv_sistok_inar";
        private string _g1inv_sistok_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Maneja stock minimo</para>
        /// <para>NOMBRE: g1inv_sistok_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Activar si el articulo maneja stock minimo y maximo: 1=Maneja
        /// stock minimo y maximo 2=No maneja stock minimo y maximo
        /// </para>
        /// </summary>
        public string G1Inv_sistok_inar
        {
            get { return _g1inv_sistok_inar; }
            set
            {
                if (_g1inv_sistok_inar == value) return;
                _g1inv_sistok_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_sistok_inar);
            }
        }
        #endregion
        #region G1Inv_stkmin_inar: Stock minimo
        public const String gcrNomProp_G1Inv_stkmin_inar = "G1Inv_stkmin_inar";
        private int _g1inv_stkmin_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Stock minimo</para>
        /// <para>NOMBRE: g1inv_stkmin_inar (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// cantidad Stock minimo del articulo en inventario, 1=Manejar
        /// Stock minimo 2=No manejar Stock minimo
        /// </para>
        /// </summary>
        public int G1Inv_stkmin_inar
        {
            get { return _g1inv_stkmin_inar; }
            set
            {
                if (_g1inv_stkmin_inar == value) return;
                _g1inv_stkmin_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_stkmin_inar);
            }
        }
        #endregion
        #region G1Inv_stkmax_inar: Stock maximo
        public const String gcrNomProp_G1Inv_stkmax_inar = "G1Inv_stkmax_inar";
        private int _g1inv_stkmax_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Stock maximo</para>
        /// <para>NOMBRE: g1inv_stkmax_inar (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Cantidad Stock maximo del articulo en inventario
        /// </para>
        /// </summary>
        public int G1Inv_stkmax_inar
        {
            get { return _g1inv_stkmax_inar; }
            set
            {
                if (_g1inv_stkmax_inar == value) return;
                _g1inv_stkmax_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_stkmax_inar);
            }
        }
        #endregion
        #region G1Inv_stkntf_inar: Unidades notificar stock
        public const String gcrNomProp_G1Inv_stkntf_inar = "G1Inv_stkntf_inar";
        private int _g1inv_stkntf_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Unidades notificar stock</para>
        /// <para>NOMBRE: g1inv_stkntf_inar (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Numero de unidades para generar notificacion  antes de llegar
        /// a cantidad stock minimo ejemplo:  20 unidades antes
        /// </para>
        /// </summary>
        public int G1Inv_stkntf_inar
        {
            get { return _g1inv_stkntf_inar; }
            set
            {
                if (_g1inv_stkntf_inar == value) return;
                _g1inv_stkntf_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_stkntf_inar);
            }
        }
        #endregion
        #region G1Inv_conreg_inar: Contador items
        public const String gcrNomProp_G1Inv_conreg_inar = "G1Inv_conreg_inar";
        private int _g1inv_conreg_inar = 0;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1inv_conreg_inar (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int G1Inv_conreg_inar
        {
            get { return _g1inv_conreg_inar; }
            set
            {
                if (_g1inv_conreg_inar == value) return;
                _g1inv_conreg_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conreg_inar);
            }
        }
        #endregion
        #region G1Inv_estart_inar: Estado Artículo
        public const String gcrNomProp_G1Inv_estart_inar = "G1Inv_estart_inar";
        private string _g1inv_estart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Estado Artículo</para>
        /// <para>NOMBRE: g1inv_estart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Estado Artículo 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Inv_estart_inar
        {
            get { return _g1inv_estart_inar; }
            set
            {
                if (_g1inv_estart_inar == value) return;
                _g1inv_estart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_estart_inar);
            }
        }
        #endregion
        #region G1Inv_desgru_ingr: Descripcion Grupo
        public const String gcrNomProp_G1Inv_desgru_ingr = "G1Inv_desgru_ingr";
        private string _g1inv_desgru_ingr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventgrupos</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: g1inv_desgru_ingr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public string G1Inv_desgru_ingr
        {
            get { return _g1inv_desgru_ingr; }
            set
            {
                if (_g1inv_desgru_ingr == value) return;
                _g1inv_desgru_ingr = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desgru_ingr);
            }
        }
        #endregion
        #region G1Inv_dessub_insg: Descripcion Subgrupo
        public const String gcrNomProp_G1Inv_dessub_insg = "G1Inv_dessub_insg";
        private string _g1inv_dessub_insg = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventsubgru</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: g1inv_dessub_insg (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripcion subgrupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public string G1Inv_dessub_insg
        {
            get { return _g1inv_dessub_insg; }
            set
            {
                if (_g1inv_dessub_insg == value) return;
                _g1inv_dessub_insg = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_dessub_insg);
            }
        }
        #endregion
        #region G1Inv_nomimg_inaj: Archivo imagen
        public const String gcrNomProp_G1Inv_nomimg_inaj = "G1Inv_nomimg_inaj";
        private string _g1inv_nomimg_inaj = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaeartimagen</para>
        /// <para>CAMPO: Archivo imagen</para>
        /// <para>NOMBRE: g1inv_nomimg_inaj (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre completo de la imagene con extencion ejemplo: A453_ARTICULO_2.PNG
        /// </para>
        /// </summary>
        public string G1Inv_nomimg_inaj
        {
            get { return _g1inv_nomimg_inaj; }
            set
            {
                if (_g1inv_nomimg_inaj == value) return;
                _g1inv_nomimg_inaj = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_nomimg_inaj);
            }
        }
        #endregion
        #region G1Fcm_desser_sips: Nombre servicio
        public const String gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g1fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string G1Fcm_desser_sips
        {
            get { return _g1fcm_desser_sips; }
            set
            {
                if (_g1fcm_desser_sips == value) return;
                _g1fcm_desser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desser_sips);
            }
        }
        #endregion
        #region G1Far_desgru_fagf: Descripcion Grupo
        public const String gcrNomProp_G1Far_desgru_fagf = "G1Far_desgru_fagf";
        private string _g1far_desgru_fagf = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: g1far_desgru_fagf (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion grupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public string G1Far_desgru_fagf
        {
            get { return _g1far_desgru_fagf; }
            set
            {
                if (_g1far_desgru_fagf == value) return;
                _g1far_desgru_fagf = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desgru_fagf);
            }
        }
        #endregion
        #region G1Far_desgru_fasg: Descripcion Subgrupo
        public const String gcrNomProp_G1Far_desgru_fasg = "G1Far_desgru_fasg";
        private string _g1far_desgru_fasg = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: g1far_desgru_fasg (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public string G1Far_desgru_fasg
        {
            get { return _g1far_desgru_fasg; }
            set
            {
                if (_g1far_desgru_fasg == value) return;
                _g1far_desgru_fasg = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desgru_fasg);
            }
        }
        #endregion
        #region G1Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G1Sis_desgme_sigr = "G1Sis_desgme_sigr";
        private string _g1sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: g1sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public string G1Sis_desgme_sigr
        {
            get { return _g1sis_desgme_sigr; }
            set
            {
                if (_g1sis_desgme_sigr == value) return;
                _g1sis_desgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desgme_sigr);
            }
        }
        #endregion
        #region G1Sis_desume_sium: Descripción unidad medida
        public const String gcrNomProp_G1Sis_desume_sium = "G1Sis_desume_sium";
        private string _g1sis_desume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: g1sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public string G1Sis_desume_sium
        {
            get { return _g1sis_desume_sium; }
            set
            {
                if (_g1sis_desume_sium == value) return;
                _g1sis_desume_sium = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desume_sium);
            }
        }
        #endregion
        #region G1Inv_desctn_intc: Descripción Contenedor
        public const String gcrNomProp_G1Inv_desctn_intc = "G1Inv_desctn_intc";
        private string _g1inv_desctn_intc = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Descripción Contenedor</para>
        /// <para>NOMBRE: g1inv_desctn_intc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public string G1Inv_desctn_intc
        {
            get { return _g1inv_desctn_intc; }
            set
            {
                if (_g1inv_desctn_intc == value) return;
                _g1inv_desctn_intc = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desctn_intc);
            }
        }
        #endregion
        #region G1Sis_desiva_tiva: Descripción del I.V.A
        public const String gcrNomProp_G1Sis_desiva_tiva = "G1Sis_desiva_tiva";
        private string _g1sis_desiva_tiva = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Descripción del I.V.A</para>
        /// <para>NOMBRE: g1sis_desiva_tiva (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del I.V.A Ejemplo 16%
        /// </para>
        /// </summary>
        public string G1Sis_desiva_tiva
        {
            get { return _g1sis_desiva_tiva; }
            set
            {
                if (_g1sis_desiva_tiva == value) return;
                _g1sis_desiva_tiva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desiva_tiva);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVMAEARTICULOS COMBOBOX: Tabla Maestro Artículos
        //------------------------------------------------
        #region Campos ComboBox: INVMAEARTICULOS
        #region  G1CbInv_tipart_inar: Tipo articulo
        public const String gcrNomProp_G1CbInv_tipart_inar = "G1CbInv_tipart_inar";
        private List<CrtForms.ListaComboBox> _g1cbinv_tipart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Tipo articulo</para>
        /// <para>NOMBRE: g1cbinv_tipart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de articulo: 1=Suministro 2=Medicamentos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_tipart_inar
        {
            get { return _g1cbinv_tipart_inar; }
            set
            {
                if (_g1cbinv_tipart_inar == value) return;
                _g1cbinv_tipart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_tipart_inar);
            }
        }
        #endregion
        #region  G1CbInv_simcrt_inar: Medicamento de control
        public const String gcrNomProp_G1CbInv_simcrt_inar = "G1CbInv_simcrt_inar";
        private List<CrtForms.ListaComboBox> _g1cbinv_simcrt_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Medicamento de control</para>
        /// <para>NOMBRE: g1cbinv_simcrt_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Activar si el medicamento es de control: 1=Medicamento Es de
        /// control 2=Medicamento no es de control 3=No es medicamento
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_simcrt_inar
        {
            get { return _g1cbinv_simcrt_inar; }
            set
            {
                if (_g1cbinv_simcrt_inar == value) return;
                _g1cbinv_simcrt_inar = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_simcrt_inar);
            }
        }
        #endregion
        #region  G1CbInv_gesips_inar: Activar servicio IPS
        public const String gcrNomProp_G1CbInv_gesips_inar = "G1CbInv_gesips_inar";
        private List<CrtForms.ListaComboBox> _g1cbinv_gesips_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Activar servicio IPS</para>
        /// <para>NOMBRE: g1cbinv_gesips_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Activar gestion de servicios IPS, para enlace con manuales
        /// tarifarios y facturacion: 1= Activar referencia a servicio
        /// IPS 2= Inactivar referencia a servicio IPS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_gesips_inar
        {
            get { return _g1cbinv_gesips_inar; }
            set
            {
                if (_g1cbinv_gesips_inar == value) return;
                _g1cbinv_gesips_inar = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_gesips_inar);
            }
        }
        #endregion
        #region  G1CbInv_sistok_inar: Maneja stock minimo
        public const String gcrNomProp_G1CbInv_sistok_inar = "G1CbInv_sistok_inar";
        private List<CrtForms.ListaComboBox> _g1cbinv_sistok_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Maneja stock minimo</para>
        /// <para>NOMBRE: g1cbinv_sistok_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Activar si el articulo maneja stock minimo y maximo: 1=Maneja
        /// stock minimo y maximo 2=No maneja stock minimo y maximo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_sistok_inar
        {
            get { return _g1cbinv_sistok_inar; }
            set
            {
                if (_g1cbinv_sistok_inar == value) return;
                _g1cbinv_sistok_inar = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_sistok_inar);
            }
        }
        #endregion
        #region  G1CbInv_estart_inar: Estado Artículo
        public const String gcrNomProp_G1CbInv_estart_inar = "G1CbInv_estart_inar";
        private List<CrtForms.ListaComboBox> _g1cbinv_estart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Estado Artículo</para>
        /// <para>NOMBRE: g1cbinv_estart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Estado Artículo 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_estart_inar
        {
            get { return _g1cbinv_estart_inar; }
            set
            {
                if (_g1cbinv_estart_inar == value) return;
                _g1cbinv_estart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_estart_inar);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVMAEARTICULOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvmaestroarticulo _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invmaearticulos
        /// </summary>
        public ModeloInvmaestroarticulo TmpG1RegActivo
        {
            get { return _tmpg1regactivo; }
            set
            {
                if (_tmpg1regactivo == value) return;
                _tmpg1regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG1RegActivo);
            }
        }
        #endregion
        #region propiedad lista registros activos: TmpG1ListaBrow
        public const String gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloInvmaestroarticulo> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: invmaearticulos
        /// </summary>
        public ObservableCollection<ModeloInvmaestroarticulo> TmpG1ListaBrow
        {
            get { return _tmpg1listabrow; }
            set
            {
                if (_tmpg1listabrow == value) return;
                _tmpg1listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG1ListaBrow);
            }
        }
        #endregion
        #region propiedad Lista Presentaciones CUM del medicamento: TmpG2ListaCum
        public const String gcrNomProp_TmpG2ListaCum = "TmpG2ListaCum";
        private ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> _tmpg2ListaCum;
        /// <summary>
        ///  Lista Presentaciones CUM del medicamento
        /// </summary>
        public ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> TmpG2ListaCum
        {
            get { return _tmpg2ListaCum; }
            set
            {
                if (_tmpg2ListaCum == value) return;
                _tmpg2ListaCum = value;
                RaisePropertyChanged(gcrNomProp_TmpG2ListaCum);
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand<ModeloInvmaestroarticulo> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);	//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);	//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);	//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);	//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);	//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            SelectionChangedCommand = new RelayCommand<ModeloInvmaestroarticulo>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;

                glgPressKeyExpediente = true;
                TmpG1RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo();
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloInvmaestroarticuloBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloInvmaestroarticulo>(ModeloInvmaestroarticulo.flsListaInvmaearticulos("","3"));
            TmpG2ListaCum = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>();
            fcvRegistrarComandos();
        }
        // Finalizar Vista Modelo
        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region Adicionar Registro
        /// <summary>
        /// Adicionar Registro
        /// </summary>
        public virtual void Adicionar()
        {
            try
            {
                fcvReiniVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region Modificar Registro
        /// <summary>
        /// Modificar Registro
        /// </summary>
        public virtual void Modificar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                tmpLogErrores = new List<LogsErrores>();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Modificar");
            }
        }
        #endregion
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public virtual void Guardar()
        {
            try
            {
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Inv_secart_inar = ModeloInvmaestroarticulo.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_secart_inar = TmpG1RegActivo.Inv_secart_inar;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloInvmaestroarticulo.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Inv_secart_inar))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            }
        }
        #endregion
        #region Cancelar
        /// <summary>
        /// Cancelar
        /// </summary>
        public virtual void Cancelar()
        {
            Restaurar();
        }
        #endregion
        #region Eliminar Registro
        /// <summary>
        /// Eliminar Registro
        /// </summary>
        public virtual void Eliminar()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ModeloInvmaestroarticulo.fcvEliminar(TmpG1RegActivo.Inv_secart_inar);
                    TmpG1ListaBrow.Remove(TmpG1RegActivo);
                    Restaurar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Salir
        /// <summary>
        /// Salir del formulario
        /// </summary>
        public virtual void Salir()
        {
            Restaurar();
            GcrSIS_FormModoPopup = "DFL";
            GcrFiltroDatos = String.Empty;
            GlgSIS_FormModoPopupIni = true;
        }
        #endregion
        #region Restaurar
        /// <summary>
        /// Restaurar
        /// </summary>
        public virtual void Restaurar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                GlgSIS_ModoDefault = true;
                fcvReiniVariables();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Restaurar");
            }
        }
        #endregion
        #region Imprimir
        /// <summary>
        /// Imprimir
        /// </summary>
        public virtual void Imprimir()
        {
            try
            {
                // Para imprimir
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Imprimir");
            }
        }
        #endregion
        #region Filtro
        /// <summary>
        /// Filtrar registros
        /// </summary>
        public void Filtro()
        {
            try
            {
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvmaestroarticulo>(ModeloInvmaestroarticulo.flsListaInvmaearticulos(GcrFiltroDatos, gcrFiltroTipoVistaBrowser));
                    gcrFiltroAplicado = GcrFiltroDatos;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #region Filtro detalles presentaciones
        /// <summary>
        /// Filtrar registros detalles presentaciones 
        /// </summary>
        public void FiltroExpedientes()
        {
            try
            {
                TmpG2ListaCum = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle >(ModeloFarExpedienteMedicamentoDetalle.flsListaFarexpedmedicmd(G1Inv_lotref_inar));
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FiltroExpedientes");
            }
        }
        #endregion
        #region Default
        /// <summary>
        /// Default Estado por defecto
        /// del formulario
        /// </summary>
        public virtual void Default()
        {
            // Para Implementación
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos Cargan los valores desde
        // variables al registro activo o lo contrario
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// </summary>
        public virtual void fcvReiniVariables()
        {
            try
            {
                #region Valores Variables
                G1Inv_secart_inar = String.Empty;
                G1Inv_tipart_inar = String.Empty;
                G1Inv_codgru_ingr = String.Empty;
                G1Inv_codsub_insg = String.Empty;
                G1Inv_codaux_inar = String.Empty;
                G1Inv_codbar_inar = String.Empty;
                G1Inv_lotref_inar = String.Empty;
                G1Inv_regsan_inar = String.Empty;
                G1Inv_nomart_inar = String.Empty;
                G1Inv_desart_inar = String.Empty;
                G1Inv_secimg_inaj = String.Empty;
                G1Inv_simcrt_inar = String.Empty;
                G1Far_forfar_fama = String.Empty;
                G1Far_concen_fama = String.Empty;
                G1Far_unimed_fama = String.Empty;
                G1Far_codcum_famd = String.Empty;
                G1Inv_gesips_inar = "2";
                G1Fcm_idesec_sips = "NA";
                G1Fcm_coddig_mant = "NA";
                G1Far_grufar_fagf = String.Empty;
                G1Far_sugfar_fasg = String.Empty;
                G1Sis_codgme_sigr = String.Empty;
                G1Sis_codume_sium = String.Empty;
                G1Inv_codctn_intc = String.Empty;
                G1Inv_valing_inar = 0;
                G1Inv_uvalin_inar = 0;
                G1Inv_porive_inar = 0;
                G1Inv_valmov_inar = 0;
                G1Sis_codiva_tiva = String.Empty;
                G1Inv_sistok_inar = String.Empty;
                G1Inv_stkmin_inar = 0;
                G1Inv_stkmax_inar = 0;
                G1Inv_stkntf_inar = 0;
                G1Inv_conreg_inar = 0;
                G1Inv_estart_inar = String.Empty;
                G1Inv_desgru_ingr = String.Empty;
                G1Inv_dessub_insg = String.Empty;
                G1Inv_nomimg_inaj = String.Empty;
                G1Fcm_desser_sips = String.Empty;
                G1Fcm_codser_sips = String.Empty;
                G1Far_desgru_fagf = String.Empty;
                G1Far_desgru_fasg = String.Empty;
                G1Sis_desgme_sigr = String.Empty;
                G1Sis_desume_sium = String.Empty;
                G1Inv_desctn_intc = String.Empty;
                G1Sis_desiva_tiva = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloInvmaestroarticulo();
                tmpLogErrores = new List<LogsErrores>();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                TmpG1RegActivo.Inv_secart_inar = G1Inv_secart_inar;
                TmpG1RegActivo.Inv_tipart_inar = G1Inv_tipart_inar;
                TmpG1RegActivo.Inv_codgru_ingr = G1Inv_codgru_ingr;
                TmpG1RegActivo.Inv_codsub_insg = G1Inv_codsub_insg;
                TmpG1RegActivo.Inv_codaux_inar = G1Inv_codaux_inar;
                TmpG1RegActivo.Inv_codbar_inar = G1Inv_codbar_inar;
                TmpG1RegActivo.Inv_lotref_inar = G1Inv_lotref_inar;
                TmpG1RegActivo.Inv_regsan_inar = G1Inv_regsan_inar;
                TmpG1RegActivo.Inv_nomart_inar = G1Inv_nomart_inar;
                TmpG1RegActivo.Inv_desart_inar = G1Inv_desart_inar;
                TmpG1RegActivo.Inv_secimg_inaj = G1Inv_secimg_inaj;
                TmpG1RegActivo.Inv_simcrt_inar = G1Inv_simcrt_inar;
                TmpG1RegActivo.Far_forfar_fama = G1Far_forfar_fama;
                TmpG1RegActivo.Far_concen_fama = G1Far_concen_fama;
                TmpG1RegActivo.Far_unimed_fama = G1Far_unimed_fama;
                TmpG1RegActivo.Far_codcum_famd = G1Far_codcum_famd;
                TmpG1RegActivo.Inv_gesips_inar = G1Inv_gesips_inar;
                TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                TmpG1RegActivo.Fcm_coddig_mant = G1Fcm_coddig_mant;
                TmpG1RegActivo.Far_grufar_fagf = G1Far_grufar_fagf;
                TmpG1RegActivo.Far_sugfar_fasg = G1Far_sugfar_fasg;
                TmpG1RegActivo.Sis_codgme_sigr = G1Sis_codgme_sigr;
                TmpG1RegActivo.Sis_codume_sium = G1Sis_codume_sium;
                TmpG1RegActivo.Inv_codctn_intc = G1Inv_codctn_intc;
                TmpG1RegActivo.Inv_valing_inar = G1Inv_valing_inar;
                TmpG1RegActivo.Inv_uvalin_inar = G1Inv_uvalin_inar;
                TmpG1RegActivo.Inv_porive_inar = G1Inv_porive_inar;
                TmpG1RegActivo.Inv_valmov_inar = G1Inv_valmov_inar;
                TmpG1RegActivo.Sis_codiva_tiva = G1Sis_codiva_tiva;
                TmpG1RegActivo.Inv_sistok_inar = G1Inv_sistok_inar;
                TmpG1RegActivo.Inv_stkmin_inar = G1Inv_stkmin_inar;
                TmpG1RegActivo.Inv_stkmax_inar = G1Inv_stkmax_inar;
                TmpG1RegActivo.Inv_stkntf_inar = G1Inv_stkntf_inar;
                TmpG1RegActivo.Inv_conreg_inar = G1Inv_conreg_inar;
                TmpG1RegActivo.Inv_estart_inar = G1Inv_estart_inar;
                TmpG1RegActivo.Inv_desgru_ingr = G1Inv_desgru_ingr;
                TmpG1RegActivo.Inv_dessub_insg = G1Inv_dessub_insg;
                TmpG1RegActivo.Inv_nomimg_inaj = G1Inv_nomimg_inaj;
                TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
                TmpG1RegActivo.Fcm_codser_sips = G1Fcm_codser_sips;
                TmpG1RegActivo.Far_desgru_fagf = G1Far_desgru_fagf;
                TmpG1RegActivo.Far_desgru_fasg = G1Far_desgru_fasg;
                TmpG1RegActivo.Sis_desgme_sigr = G1Sis_desgme_sigr;
                TmpG1RegActivo.Sis_desume_sium = G1Sis_desume_sium;
                TmpG1RegActivo.Inv_desctn_intc = G1Inv_desctn_intc;
                TmpG1RegActivo.Sis_desiva_tiva = G1Sis_desiva_tiva;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region Cargar Variables desde Registro activo
        /// <summary>
        /// Cargar Variables desde Registro activo
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                G1Inv_secart_inar = TmpG1RegActivo.Inv_secart_inar;
                G1Inv_tipart_inar = TmpG1RegActivo.Inv_tipart_inar;
                G1Inv_codgru_ingr = TmpG1RegActivo.Inv_codgru_ingr;
                G1Inv_codsub_insg = TmpG1RegActivo.Inv_codsub_insg;
                G1Inv_codaux_inar = TmpG1RegActivo.Inv_codaux_inar;
                G1Inv_codbar_inar = TmpG1RegActivo.Inv_codbar_inar;
                G1Inv_lotref_inar = TmpG1RegActivo.Inv_lotref_inar;
                G1Inv_regsan_inar = TmpG1RegActivo.Inv_regsan_inar;
                G1Inv_nomart_inar = TmpG1RegActivo.Inv_nomart_inar;
                G1Inv_desart_inar = TmpG1RegActivo.Inv_desart_inar;
                G1Inv_secimg_inaj = TmpG1RegActivo.Inv_secimg_inaj;
                G1Inv_simcrt_inar = TmpG1RegActivo.Inv_simcrt_inar;
                G1Far_forfar_fama = TmpG1RegActivo.Far_forfar_fama;
                G1Far_concen_fama = TmpG1RegActivo.Far_concen_fama;
                G1Far_unimed_fama = TmpG1RegActivo.Far_unimed_fama;
                G1Far_codcum_famd = TmpG1RegActivo.Far_codcum_famd;
                G1Inv_gesips_inar = TmpG1RegActivo.Inv_gesips_inar;
                G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                G1Fcm_coddig_mant = TmpG1RegActivo.Fcm_coddig_mant;
                G1Fcm_codser_sips = TmpG1RegActivo.Fcm_codser_sips;
                G1Far_grufar_fagf = TmpG1RegActivo.Far_grufar_fagf;
                G1Far_sugfar_fasg = TmpG1RegActivo.Far_sugfar_fasg;
                G1Sis_codgme_sigr = TmpG1RegActivo.Sis_codgme_sigr;
                G1Sis_codume_sium = TmpG1RegActivo.Sis_codume_sium;
                G1Inv_codctn_intc = TmpG1RegActivo.Inv_codctn_intc;
                G1Inv_valing_inar = TmpG1RegActivo.Inv_valing_inar;
                G1Inv_uvalin_inar = TmpG1RegActivo.Inv_uvalin_inar;
                G1Inv_porive_inar = TmpG1RegActivo.Inv_porive_inar;
                G1Inv_valmov_inar = TmpG1RegActivo.Inv_valmov_inar;
                G1Sis_codiva_tiva = TmpG1RegActivo.Sis_codiva_tiva;
                G1Inv_sistok_inar = TmpG1RegActivo.Inv_sistok_inar;
                G1Inv_stkmin_inar = TmpG1RegActivo.Inv_stkmin_inar;
                G1Inv_stkmax_inar = TmpG1RegActivo.Inv_stkmax_inar;
                G1Inv_stkntf_inar = TmpG1RegActivo.Inv_stkntf_inar;
                G1Inv_conreg_inar = TmpG1RegActivo.Inv_conreg_inar;
                G1Inv_estart_inar = TmpG1RegActivo.Inv_estart_inar;
                G1Inv_desgru_ingr = TmpG1RegActivo.Inv_desgru_ingr;
                G1Inv_dessub_insg = TmpG1RegActivo.Inv_dessub_insg;
                G1Inv_nomimg_inaj = TmpG1RegActivo.Inv_nomimg_inaj;
                G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
                G1Far_desgru_fagf = TmpG1RegActivo.Far_desgru_fagf;
                G1Far_desgru_fasg = TmpG1RegActivo.Far_desgru_fasg;
                G1Sis_desgme_sigr = TmpG1RegActivo.Sis_desgme_sigr;
                G1Sis_desume_sium = TmpG1RegActivo.Sis_desume_sium;
                G1Inv_desctn_intc = TmpG1RegActivo.Inv_desctn_intc;
                G1Sis_desiva_tiva = TmpG1RegActivo.Sis_desiva_tiva;
                #endregion
                if (G1Fcm_coddig_mant == "NA")
                {
                    G1Fcm_desser_sips = "REFERENCIA NO ESTABLECIDA CON SERVICIOS IPS";
                    G1Fcm_codser_sips = String.Empty;
                    G1Fcm_coddig_mant = "NA";
                }
                TmpG2ListaCum = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region Metodos para Activacion de opciones
        #region CanADD
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Adicionar
        /// </summary>
        public virtual bool CanADD()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdADD))
                    {
                        gcrSIS_PerfilCmdADD = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDADICIONAR-ADD", "ADD");
                    }
                    if (gcrSIS_PerfilCmdADD == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanADD");
            }
            return llgReturn;
        }
        #endregion
        #region CanEDT
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Modificar
        /// </summary>
        public virtual bool CanEDT()
        {
            bool llgReturn = false;
            try
            {
                GlgSIS_ModoEdicionMedicamento = GlgSIS_ModoEdicion == true && G1Inv_tipart_inar == "2" ? true : false;
                G1Inv_simcrt_inar = GlgSIS_ModoEdicion == true && G1Inv_tipart_inar == "1" ? "3" : G1Inv_simcrt_inar;

                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_secart_inar) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEDT");
            }
            return llgReturn;
        }
        #endregion
        #region CanSAV
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar
        /// </summary>
        public virtual bool CanSAV()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_tipart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codgru_ingr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codsub_insg")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codaux_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codbar_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_lotref_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_regsan_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_nomart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_desart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_secimg_inaj")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_simcrt_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_forfar_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_concen_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_prinac_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codcum_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_gesips_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_coddig_mant")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_grufar_fagf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_sugfar_fasg")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codgme_sigr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codume_sium")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codctn_intc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valing_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_uvalin_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_porive_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valmov_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codiva_tiva")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_sistok_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_stkmin_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_stkmax_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_stkntf_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conreg_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_estart_inar"));
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            }
            return llgReturn;
        }
        #endregion
        #region CanCAN
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Cancelar
        /// </summary>
        public virtual bool CanCAN()
        {
            return GlgSIS_ModoEdicion;
        }
        #endregion
        #region CanSAL
        /// <summary>
        ///Validación para activar o desactivar
        ///opciones salir del formulario
        /// </summary>
        public virtual bool CanSAL()
        {
            return GlgSIS_ModoDefault;
        }
        #endregion
        #region CanDEL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Eliminar
        /// </summary>
        public virtual bool CanDEL()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_secart_inar) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDEL");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRN
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir
        /// </summary>
        public virtual bool CanPRN()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRN))
                    {
                        gcrSIS_PerfilCmdPRN = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRN", "PRN");
                    }
                    if (gcrSIS_PerfilCmdPRN == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRN");
            }
            return llgReturn;
        }
        #endregion
        #region CanFIL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Filtro en formularios tipo uno
        ///se ejecuta el filtro automatico (por ser pocos registros)
        /// </summary>
        public virtual bool CanFIL()
        {
            bool llgReturn = false;
            try
            {
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvmaestroarticulo>(ModeloInvmaestroarticulo.flsListaInvmaearticulos(GcrFiltroDatos, gcrFiltroTipoVistaBrowser));
                    gcrFiltroAplicado = GcrFiltroDatos;
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFIL");
            }
            return llgReturn;
        }
        #endregion
        #region CanDFL
        /// <summary>
        ///Validación para devolver al modo Default
        ///del formulario
        /// </summary>
        public virtual bool CanDFL()
        {
            return GlgSIS_ModoDefault;
        }
        #endregion
        #region CanERR
        /// <summary>
        ///Validación para saber si se permite
        ///Activar el boton par aver el log de errores
        /// </summary>
        public virtual bool CanERR()
        {
            bool llgReturn = false;
            try
            {
                if (tmpLogErrores.Count > 0)
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
        #endregion
        //-------------------------------------------------
        // Implementacion para validacion
        //-------------------------------------------------
        #region Implementacion para validacion
        public String Error
        {
            get { throw new NotImplementedException(); }
        }
        public String this[String tcrNombrePropiedad]
        {
            get
            {
                String lcrResult = String.Empty;
                if (GlgSIS_ModoEdicion == true)
                {
                    lcrResult = fcrValidacion(tcrNombrePropiedad);
                }
                return lcrResult;
            }
        }
        #endregion
        //-------------------------------------------------
        // Validacion de campos
        //-------------------------------------------------
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public virtual String fcrValidacion(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
        }
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //INV_TIPART_INAR: Tipo articulo
                //-------------------------------------------------
                #region INV_TIPART_INAR: Tipo articulo
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Suministro,Medicamento";
                G1CbInv_tipart_inar = new List<CrtForms.ListaComboBox>();
                G1CbInv_tipart_inar = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_SIMCRT_INAR: Medicamento de control
                //-------------------------------------------------
                #region INV_SIMCRT_INAR: Medicamento de control
                String lcrG12Seleccion = "1,2,3";
                String lcrG12Descripcion = "Medicamento Es de control,Medicamento no es de control,No es medicamento";
                G1CbInv_simcrt_inar = new List<CrtForms.ListaComboBox>();
                G1CbInv_simcrt_inar = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_GESIPS_INAR: Activar servicio IPS
                //-------------------------------------------------
                #region INV_GESIPS_INAR: Activar servicio IPS
                String lcrG13Seleccion = "1,2";
                String lcrG13Descripcion = "Activar referencia a servicio IPS,Inactivar referencia a servicio IPS";
                G1CbInv_gesips_inar = new List<CrtForms.ListaComboBox>();
                G1CbInv_gesips_inar = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_SISTOK_INAR: Maneja stock minimo
                //-------------------------------------------------
                #region INV_SISTOK_INAR: Maneja stock minimo
                String lcrG14Seleccion = "1,2";
                String lcrG14Descripcion = "Maneja stock minimo y maximo,No maneja stock minimo y maximo";
                G1CbInv_sistok_inar = new List<CrtForms.ListaComboBox>();
                G1CbInv_sistok_inar = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_ESTART_INAR: Estado Artículo
                //-------------------------------------------------
                #region INV_ESTART_INAR: Estado Artículo
                String lcrG15Seleccion = "1,2";
                String lcrG15Descripcion = "Activo,Inactivo";
                G1CbInv_estart_inar = new List<CrtForms.ListaComboBox>();
                G1CbInv_estart_inar = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #endregion
    }
}
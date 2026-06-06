//- MARMOTA-GENCODE: VERSION 2.0 - 27/04/2015 05:12:42 PM
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
using Sistema.Vista;
using Meci.Modelo;

namespace Meci.VistaModelo
{
    /// <summary>
    /// <para>TABLA: mcievaluacionms</para>
    /// <para>DESCRIPCION:
    ///  Tabla para almacenar las evaluaciones que se realizan con una
    ///  plantilla MECI en el sistema
    /// </para>
    /// </summary>
    public class VistaModeloMcievaluacionmsBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "MCI006";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public string gcrSIS_PerfilCmdADD = string.Empty;
        public string gcrSIS_PerfilCmdEDT = string.Empty;
        public string gcrSIS_PerfilCmdSAV = string.Empty;
        public string gcrSIS_PerfilCmdDEL = string.Empty;
        public string gcrSIS_PerfilCmdPRN = string.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public string gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private string _gcrUsuIdUsuario = string.Empty;
        public string GcrUsuIdUsuario
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
        public string gcrNomProp_UsuCodigoPerfil = "GcrUsuCodigoPerfil";
        private string _gcrUsuCodigoPerfil = string.Empty;
        public string GcrUsuCodigoPerfil
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
        public string glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
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
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
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
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
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
        #endregion
        #region Vista Modelo Propiedad: gcrSIS_FormModoPopup
        /// <summary>
        /// gcrSIS_FormModoPopup: Variable para el control del modo
        /// adicion(ADD), edicion(EDT) Vista (VIE), cuando el formulario es llamado desde 
        /// un fomulario principal para adicionar un registro en particula o 
        /// para modificar uno ya existente.
        /// el valor por defecto es: DFL =Valor por defecto
        /// </summary>
        public const string gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private string _gcrSIS_FormModoPopup = "DFL";
        public string GcrSIS_FormModoPopup
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
        public string gcrNomProp_SIS_FormModoPopupIni = "GlgSIS_FormModoPopupIni";
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
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroAplicado: Variable para saber si ya el filtro
        /// actual fue aplicado (toma el valor del filtro activo).
        /// </summary>
        ///--------------------------------------------------------
        public string gcrFiltroAplicado = string.Empty;
        #endregion
        #region Control Filtro Propiedad: gcrFiltroDatos
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatos: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo.
        /// </summary>
        ///--------------------------------------------------------
        public const string glgNomProp_SIS_FiltroDatos = "GcrFiltroDatos";
        private string _gcrFiltroDatos = string.Empty;
        public string GcrFiltroDatos
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
        //MCIEVALUACIONMS : Maestro de Evaluaciones Meci
        //------------------------------------------------
        #region Notificacion campos: MCIEVALUACIONMS
        #region G1Mci_idesec_mcms: Código
        public const string gcrNomProp_G1Mci_idesec_mcms = "G1Mci_idesec_mcms";
        private string _g1mci_idesec_mcms = string.Empty;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: g1mci_idesec_mcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de evaluaciones en el sistema, se genera
        /// al momento de crear el registro o cuando la base de datos es
        /// cargada en el sistema
        /// </para>
        /// </summary>
        public string G1Mci_idesec_mcms
        {
            get { return _g1mci_idesec_mcms; }
            set
            {
                if (_g1mci_idesec_mcms == value) return;
                _g1mci_idesec_mcms = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idesec_mcms);
            }
        }
        #endregion
        #region G1Mci_deseva_mcms: Evaluación
        public const string gcrNomProp_G1Mci_deseva_mcms = "G1Mci_deseva_mcms";
        private string _g1mci_deseva_mcms = string.Empty;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Evaluación</para>
        /// <para>NOMBRE: g1mci_deseva_mcms (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la Evaluación
        /// </para>
        /// </summary>
        public string G1Mci_deseva_mcms
        {
            get { return _g1mci_deseva_mcms; }
            set
            {
                if (_g1mci_deseva_mcms == value) return;
                _g1mci_deseva_mcms = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_deseva_mcms);
            }
        }
        #endregion
        #region G1Mci_feceva_mcms: Fecha
        public const string gcrNomProp_G1Mci_feceva_mcms = "G1Mci_feceva_mcms";
        private string _g1mci_feceva_mcms = "  /  /    ";
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Fecha</para>
        /// <para>NOMBRE: g1mci_feceva_mcms (date:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha Evaluación
        /// </para>
        /// </summary>
        public string G1Mci_feceva_mcms
        {
            get { return _g1mci_feceva_mcms; }
            set
            {
                if (_g1mci_feceva_mcms == value) return;
                _g1mci_feceva_mcms = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_feceva_mcms);
            }
        }
        #endregion
        #region G1Mci_idepla_mcpl: Plantilla
        public const string gcrNomProp_G1Mci_idepla_mcpl = "G1Mci_idepla_mcpl";
        private string _g1mci_idepla_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: g1mci_idepla_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo en sistema  de plantilla a utilizar en esta evaluación
        /// </para>
        /// </summary>
        public string G1Mci_idepla_mcpl
        {
            get { return _g1mci_idepla_mcpl; }
            set
            {
                if (_g1mci_idepla_mcpl == value) return;
                _g1mci_idepla_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idepla_mcpl);
            }
        }
        #endregion
        #region G1Mci_estreg_mcms: Estado Evaluación
        public const string gcrNomProp_G1Mci_estreg_mcms = "G1Mci_estreg_mcms";
        private string _g1mci_estreg_mcms = string.Empty;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Estado Evaluación</para>
        /// <para>NOMBRE: g1mci_estreg_mcms (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado Evaluación 1=Abierta 2= Cerrada
        /// </para>
        /// </summary>
        public string G1Mci_estreg_mcms
        {
            get { return _g1mci_estreg_mcms; }
            set
            {
                if (_g1mci_estreg_mcms == value) return;
                _g1mci_estreg_mcms = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_estreg_mcms);
            }
        }
        #endregion
        #region G1Mci_despla_mcpl: Plantilla
        public const string gcrNomProp_G1Mci_despla_mcpl = "G1Mci_despla_mcpl";
        private string _g1mci_despla_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: g1mci_despla_mcpl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la plantilla
        /// </para>
        /// </summary>
        public string G1Mci_despla_mcpl
        {
            get { return _g1mci_despla_mcpl; }
            set
            {
                if (_g1mci_despla_mcpl == value) return;
                _g1mci_despla_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_despla_mcpl);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIEVALUACIONMS COMBOBOX: Maestro de Evaluaciones Meci
        //------------------------------------------------
        #region Campos ComboBox: MCIEVALUACIONMS
        #region  G1CbMci_estreg_mcms: Estado Evaluación
        public const string gcrNomProp_G1CbMci_estreg_mcms = "G1CbMci_estreg_mcms";
        private List<CrtForms.ListaComboBox> _g1cbmci_estreg_mcms;
        /// <summary>
        /// <para>TABLA: mcievaluacionms</para>
        /// <para>TABLA NATIVA: mcievaluacionms</para>
        /// <para>CAMPO: Estado Evaluación</para>
        /// <para>NOMBRE: g1cbmci_estreg_mcms (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado Evaluación 1=Abierta 2= Cerrada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbMci_estreg_mcms
        {
            get { return _g1cbmci_estreg_mcms; }
            set
            {
                if (_g1cbmci_estreg_mcms == value) return;
                _g1cbmci_estreg_mcms = value;
                RaisePropertyChanged(gcrNomProp_G1CbMci_estreg_mcms);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIEVALUACIONMS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloMcievaluacionms _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: mcievaluacionms
        /// </summary>
        public ModeloMcievaluacionms TmpG1RegActivo
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
        public const string gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloMcievaluacionms> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: mcievaluacionms
        /// </summary>
        public ObservableCollection<ModeloMcievaluacionms> TmpG1ListaBrow
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
        public RelayCommand<ModeloMcievaluacionms> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloMcievaluacionms>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG1RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo();
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloMcievaluacionmsBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloMcievaluacionms>(ModeloMcievaluacionms.flsListaMcievaluacionms(""));
            fcvRegistrarComandos();
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
                    DialogProgressBarEx lobDlgCon = new DialogProgressBarEx();
                    lobDlgCon.fcvProgressBarIniciar("Generando datos evaluación...", "CENTRO");
                    lobDlgCon.Show();

                    TmpG1RegActivo.Mci_idesec_mcms = ModeloMcievaluacionms.flgAddRegistro(TmpG1RegActivo);
                    G1Mci_idesec_mcms = TmpG1RegActivo.Mci_idesec_mcms;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);

                    lobDlgCon.Close();
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloMcievaluacionms.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Mci_idesec_mcms))
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
                    ModeloMcievaluacionms.fcvEliminar(TmpG1RegActivo.Mci_idesec_mcms);
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
        public virtual void Filtro()
        {
            try
            {
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloMcievaluacionms>(ModeloMcievaluacionms.flsListaMcievaluacionms(GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
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
                G1Mci_idesec_mcms = string.Empty;
                G1Mci_deseva_mcms = string.Empty;
                G1Mci_feceva_mcms = "  /  /    ";
                G1Mci_idepla_mcpl = string.Empty;
                G1Mci_estreg_mcms = string.Empty;
                G1Mci_despla_mcpl = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloMcievaluacionms();
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
                TmpG1RegActivo.Mci_idesec_mcms = G1Mci_idesec_mcms;
                TmpG1RegActivo.Mci_deseva_mcms = G1Mci_deseva_mcms;
                TmpG1RegActivo.Mci_feceva_mcms = Funciones.fdaConvertFecha("DMY", "/", G1Mci_feceva_mcms);
                TmpG1RegActivo.Mci_idepla_mcpl = G1Mci_idepla_mcpl;
                TmpG1RegActivo.Mci_estreg_mcms = G1Mci_estreg_mcms;
                TmpG1RegActivo.Mci_despla_mcpl = G1Mci_despla_mcpl;
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
                G1Mci_idesec_mcms = TmpG1RegActivo.Mci_idesec_mcms;
                G1Mci_deseva_mcms = TmpG1RegActivo.Mci_deseva_mcms;
                G1Mci_feceva_mcms = TmpG1RegActivo.Mci_feceva_mcms.ToShortDateString();
                G1Mci_idepla_mcpl = TmpG1RegActivo.Mci_idepla_mcpl;
                G1Mci_estreg_mcms = TmpG1RegActivo.Mci_estreg_mcms;
                G1Mci_despla_mcpl = TmpG1RegActivo.Mci_despla_mcpl;
                #endregion
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Mci_idesec_mcms) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Mci_deseva_mcms")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_feceva_mcms")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_idepla_mcpl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_estreg_mcms"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Mci_idesec_mcms) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloMcievaluacionms>(ModeloMcievaluacionms.flsListaMcievaluacionms(GcrFiltroDatos));
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
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string tcrNombrePropiedad]
        {
            get
            {
                string lcrResult = string.Empty;
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
        public virtual string fcrValidacion(string tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return string.Empty;
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
                //MCI_ESTREG_MCMS: Estado Evaluación
                //-------------------------------------------------
                #region MCI_ESTREG_MCMS: Estado Evaluación
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Abierta,Cerrada";
                G1CbMci_estreg_mcms = new List<CrtForms.ListaComboBox>();
                G1CbMci_estreg_mcms = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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
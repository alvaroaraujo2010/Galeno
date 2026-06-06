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
    /// <para>TABLA: invajusteconcep</para>
    /// <para>DESCRIPCION:
    ///  Lista de concepto de ajuste inventario: 01=Por reconteo inventario
    ///  02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro
    ///  del producto y otros
    /// </para>
    /// </summary>
    public class VistaModeloInvajusteconcepBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV011";
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
        //INVAJUSTECONCEP : Conceptos de ajuste inventario
        //------------------------------------------------
        #region Notificacion campos: INVAJUSTECONCEP
        #region G1Inv_conaju_incp: Código concepto ajuste
        public const string gcrNomProp_G1Inv_conaju_incp = "G1Inv_conaju_incp";
        private string _g1inv_conaju_incp = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Código concepto ajuste</para>
        /// <para>NOMBRE: g1inv_conaju_incp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código concepto de Ajuste inventario: 01=Por reconteo inventario
        /// 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro
        /// del producto y otros
        /// </para>
        /// </summary>
        public string G1Inv_conaju_incp
        {
            get { return _g1inv_conaju_incp; }
            set
            {
                if (_g1inv_conaju_incp == value) return;
                _g1inv_conaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conaju_incp);
            }
        }
        #endregion
        #region G1Inv_desaju_incp: Descripción Concepto
        public const string gcrNomProp_G1Inv_desaju_incp = "G1Inv_desaju_incp";
        private string _g1inv_desaju_incp = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Descripción Concepto</para>
        /// <para>NOMBRE: g1inv_desaju_incp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto de Ajuste
        /// </para>
        /// </summary>
        public string G1Inv_desaju_incp
        {
            get { return _g1inv_desaju_incp; }
            set
            {
                if (_g1inv_desaju_incp == value) return;
                _g1inv_desaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desaju_incp);
            }
        }
        #endregion
        #region G1Inv_tipaju_incp: Tipo ajuste
        public const string gcrNomProp_G1Inv_tipaju_incp = "G1Inv_tipaju_incp";
        private string _g1inv_tipaju_incp = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Tipo ajuste</para>
        /// <para>NOMBRE: g1inv_tipaju_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo ajuste 1= Reconteo Total inventario 2= Por suma o Resta
        /// de Unidades
        /// </para>
        /// </summary>
        public string G1Inv_tipaju_incp
        {
            get { return _g1inv_tipaju_incp; }
            set
            {
                if (_g1inv_tipaju_incp == value) return;
                _g1inv_tipaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_tipaju_incp);
            }
        }
        #endregion
        #region G1Inv_conmov_incm: Concepto Movimiento
        public const string gcrNomProp_G1Inv_conmov_incm = "G1Inv_conmov_incm";
        private string _g1inv_conmov_incm = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: g1inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento diario: E11 =Entrada saldo inicial inventario
        /// o del mes E12= Entradas compras ...  S21= Salidas Ventas 22=
        /// Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida
        /// entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public string G1Inv_conmov_incm
        {
            get { return _g1inv_conmov_incm; }
            set
            {
                if (_g1inv_conmov_incm == value) return;
                _g1inv_conmov_incm = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conmov_incm);
            }
        }
        #endregion
        #region G1Inv_estreg_incp: Estado del registro
        public const string gcrNomProp_G1Inv_estreg_incp = "G1Inv_estreg_incp";
        private string _g1inv_estreg_incp = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g1inv_estreg_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Inv_estreg_incp
        {
            get { return _g1inv_estreg_incp; }
            set
            {
                if (_g1inv_estreg_incp == value) return;
                _g1inv_estreg_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_estreg_incp);
            }
        }
        #endregion
        #region G1Inv_descon_incm: Descripción concepto
        public const string gcrNomProp_G1Inv_descon_incm = "G1Inv_descon_incm";
        private string _g1inv_descon_incm = string.Empty;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: g1inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public string G1Inv_descon_incm
        {
            get { return _g1inv_descon_incm; }
            set
            {
                if (_g1inv_descon_incm == value) return;
                _g1inv_descon_incm = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_descon_incm);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVAJUSTECONCEP COMBOBOX: Conceptos de ajuste inventario
        //------------------------------------------------
        #region Campos ComboBox: INVAJUSTECONCEP
        #region  G1CbInv_tipaju_incp: Tipo ajuste
        public const string gcrNomProp_G1CbInv_tipaju_incp = "G1CbInv_tipaju_incp";
        private List<CrtForms.ListaComboBox> _g1cbinv_tipaju_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Tipo ajuste</para>
        /// <para>NOMBRE: g1cbinv_tipaju_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo ajuste 1= Reconteo Total inventario 2= Por suma o Resta
        /// de Unidades
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_tipaju_incp
        {
            get { return _g1cbinv_tipaju_incp; }
            set
            {
                if (_g1cbinv_tipaju_incp == value) return;
                _g1cbinv_tipaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_tipaju_incp);
            }
        }
        #endregion
        #region  G1CbInv_estreg_incp: Estado del registro
        public const string gcrNomProp_G1CbInv_estreg_incp = "G1CbInv_estreg_incp";
        private List<CrtForms.ListaComboBox> _g1cbinv_estreg_incp;
        /// <summary>
        /// <para>TABLA: invajusteconcep</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g1cbinv_estreg_incp (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_estreg_incp
        {
            get { return _g1cbinv_estreg_incp; }
            set
            {
                if (_g1cbinv_estreg_incp == value) return;
                _g1cbinv_estreg_incp = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_estreg_incp);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVAJUSTECONCEP: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvajusteconcep _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invajusteconcep
        /// </summary>
        public ModeloInvajusteconcep TmpG1RegActivo
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
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }

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
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloInvajusteconcepBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                GcrFiltroDatos = string.Empty;
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
                gcrFiltroAplicado = string.Empty;
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
                    TmpG1RegActivo.Inv_conaju_incp = ModeloInvajusteconcep.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_conaju_incp = TmpG1RegActivo.Inv_conaju_incp;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloInvajusteconcep.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Inv_conaju_incp))
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
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Inv_conaju_incp = GcrFiltroDatos;
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
                    ModeloInvajusteconcep.fcvEliminar(TmpG1RegActivo.Inv_conaju_incp);
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
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloInvajusteconcep> TmpG1ListaBrow = ModeloInvajusteconcep.flsListaInvajusteconcep(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloInvajusteconcep)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo();
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
                G1Inv_conaju_incp = string.Empty;
                G1Inv_desaju_incp = string.Empty;
                G1Inv_tipaju_incp = string.Empty;
                G1Inv_conmov_incm = string.Empty;
                G1Inv_estreg_incp = string.Empty;
                G1Inv_descon_incm = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloInvajusteconcep();
                gcrFiltroAplicado = string.Empty;
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
                TmpG1RegActivo.Inv_conaju_incp = G1Inv_conaju_incp;
                TmpG1RegActivo.Inv_desaju_incp = G1Inv_desaju_incp;
                TmpG1RegActivo.Inv_tipaju_incp = G1Inv_tipaju_incp;
                TmpG1RegActivo.Inv_conmov_incm = G1Inv_conmov_incm;
                TmpG1RegActivo.Inv_estreg_incp = G1Inv_estreg_incp;
                TmpG1RegActivo.Inv_descon_incm = G1Inv_descon_incm;
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
                G1Inv_conaju_incp = TmpG1RegActivo.Inv_conaju_incp;
                G1Inv_desaju_incp = TmpG1RegActivo.Inv_desaju_incp;
                G1Inv_tipaju_incp = TmpG1RegActivo.Inv_tipaju_incp;
                G1Inv_conmov_incm = TmpG1RegActivo.Inv_conmov_incm;
                G1Inv_estreg_incp = TmpG1RegActivo.Inv_estreg_incp;
                G1Inv_descon_incm = TmpG1RegActivo.Inv_descon_incm;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_conaju_incp) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Inv_conaju_incp")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_desaju_incp")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_tipaju_incp")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_conmov_incm")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_estreg_incp"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_conaju_incp) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Inv_conaju_incp))
                {
                    GcrFiltroDatos = G1Inv_conaju_incp;
                    if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                    {
                        Filtro();
                        llgReturn = true;
                    }
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
                //INV_TIPAJU_INCP: Tipo ajuste
                //-------------------------------------------------
                #region INV_TIPAJU_INCP: Tipo ajuste
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Reconteo total inventario,Por suma o resta de unidades";
                G1CbInv_tipaju_incp = new List<CrtForms.ListaComboBox>();
                G1CbInv_tipaju_incp = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_ESTREG_INCP: Estado del registro
                //-------------------------------------------------
                #region INV_ESTREG_INCP: Estado del registro
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Activo,Inactivo";
                G1CbInv_estreg_incp = new List<CrtForms.ListaComboBox>();
                G1CbInv_estreg_incp = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
